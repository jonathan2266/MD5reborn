#include "threadManager.h"



threadManager::threadManager(iDataChecker* dChecker, vector<string>* dir, string* fileUnFinishedTag, iHash* hash) // state none
{
	//logger
	this->dir = dir;
	this->fileUnFinishedTag = fileUnFinishedTag;
	this->dChecker = dChecker;
	this->hash = hash;

	init(folderState::none);
	currentFileNr = 0;
	currentWord = "";
}

threadManager::threadManager(iDataChecker* dChecker, vector<string>* dir, string* fileUnFinishedTag, string* finishedFilePath, iHash* hash) // state fin
{
	//logger
	this->dir = dir;
	this->fileUnFinishedTag = fileUnFinishedTag;
	this->dChecker = dChecker;
	this->hash = hash;

	init(folderState::none);
	currentFileNr = 0;
	currentWord = "";
}

threadManager::~threadManager()
{
}

void threadManager::Start()
{
	manage();
}

void threadManager::init(folderState state)
{
	isProgramRunning = true;
	nrOfGroupedHashes = 6000000;

	this->state = state;
	isDone = new bool[std::thread::hardware_concurrency()];
	workers = new boost::thread[std::thread::hardware_concurrency()];

	saver = nullptr;
	if (state == folderState::none || state == folderState::finished)
	{
		for (size_t i = 0; i < std::thread::hardware_concurrency(); i++)
		{
			isDone[i] = true;
		}
	}

	currentDriveGiven = 0;
}

void threadManager::manage()
{
	while (isProgramRunning)
	{
		for (size_t i = 0; i < std::thread::hardware_concurrency(); i++)
		{
			if (isDone[i] == true)
			{
				//new job and start
				currentFileNr++;
				if (saver == nullptr)
				{
					saver = new iDataSaver*[std::thread::hardware_concurrency()];
				}
				driveCounter();
				saver[i] = new dataSaverLocalHDD(dir->at(currentDriveGiven), std::to_string(currentFileNr) + ".txt", fileUnFinishedTag);
				workers[i] = boost::thread(&threadManager::hashing, this, i, currentWord, nrOfGroupedHashes);
				isDone[i] = false;

				//logger
				wordGenerator* w = new wordGenerator(&currentWord);

				for (int j = 0; j < nrOfGroupedHashes; j++) //temp cuz wordjumper no ready
				{
					w->Next();
				}
				currentWord = w->GetCurrentWord();
				delete w;
				//logger.log(DateTime.Now + "::Next job found");
			}
		}
		boost::this_thread::sleep(boost::posix_time::microsec(1000));
	}
}

void threadManager::hashing(int threadID, string startWord, int lenght)
{
	//logger
	wordGenerator* wGen = new wordGenerator(&startWord);

	for (int i = 0; i < lenght; i++)
	{
		wGen->Next();
		saver[threadID]->PushData(&wGen->GetCurrentWord(), &this->hash->Hash(wGen->GetCurrentWord().c_str()));
	}

	saver[threadID]->Finish();
	isDone[threadID] = true;
	delete wGen;
	//logger
}

void threadManager::driveCounter()
{
	currentDriveGiven++;
	if (currentDriveGiven == dir->size())
	{
		currentDriveGiven = 0;
	}
}
