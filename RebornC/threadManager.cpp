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


threadManager::~threadManager()
{
}

void threadManager::init(folderState state)
{
	isProgramRunning = true;
	nrOfGroupedHashes = 6000000;

	this->state = state;
	isDone = new bool[thread::hardware_concurrency()];
	//threads


}
