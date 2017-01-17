#include "dataCheckerLocalHDD.h"



dataCheckerLocalHDD::dataCheckerLocalHDD(std::vector<std::string>* directory, std::string * unfinishedTag)
{
	//logger
	_directory = *directory;
	_unfinishedTag = unfinishedTag;
}

dataCheckerLocalHDD::~dataCheckerLocalHDD()
{
}

void dataCheckerLocalHDD::GetStatus(folderState & out_state, std::vector<std::string>& out_files)
{
	out_state = folderState::finished;
	std::vector<std::string>* temp;
	std::vector<std::string>* unfList = new std::vector<std::string>();

	try
	{
		temp = GetDirectoryFromDrives();

		//test none state
		if (temp->size() == 0)
		{
			out_state = folderState::none;
		}
		//test for unf state
		int countNonUnf = 0;
		for (size_t i = 0; i < temp->size(); i++)
		{
			int s = temp->at(i).find(*_unfinishedTag);
			if (s > -1)
			{
				boost::filesystem::remove(temp->at(i));
			}
			else
			{
				countNonUnf++;
			}
		}
		if (countNonUnf > 0)
		{
			out_state = folderState::finished;
			temp = GetDirectoryFromDrives();
		}
	}
	catch (const std::exception& e)
	{
		//log stuff :)
	}

	if (out_state == folderState::finished)
	{
		delete unfList;
		unfList = getLastestFile(*temp);
	}

	out_files = *unfList;

	delete unfList;
	delete temp;
}

void dataCheckerLocalHDD::GetLastWordOfFileInfo(std::string fileDir, int & lineNumber, std::string & word)
{
	std::ifstream* reader;
	std::string read = "";
	int iterations = 0;
	bool isEven = true;
	
	try
	{
		reader = new std::ifstream(fileDir);
		std::string temp;
		while (true)
		{
			std::getline(*reader, temp);
			if (temp == "")
			{
				break;
			}
			if (temp != "")
			{
				if (isEven)
				{
					read = temp;
				}
				isEven = !isEven;
				iterations++;
			}
			else
			{
				break;
			}
		}
	}
	catch (const std::exception&)
	{
		//logger :)
	}

	reader->close();
	delete reader;
	word = read;
	lineNumber = iterations;

}

std::vector<std::string>* dataCheckerLocalHDD::GetDirectoryFromDrives()
{
	std::vector<std::string>* complete = new std::vector<std::string>();
	for (size_t i = 0; i < _directory.size(); i++)
	{
		for (boost::filesystem::directory_entry& e : boost::filesystem::directory_iterator(_directory.at(i)))
		{
			complete->push_back(e.path().string());
		}
	}

	return complete;
}

std::vector<std::string>* dataCheckerLocalHDD::getLastestFile(std::vector<std::string>& temp)
{
	std::vector<std::string>* ret = new std::vector<std::string>();
	std::string* local = new std::string[temp.size()];
	int biggest = 0;

	for (size_t i = 0; i < temp.size(); i++)
	{
		boost::filesystem::path p(temp.at(i));
		local[i] = p.stem().string();

		try
		{
			if (atoi(local[biggest].c_str()) < atoi(local[i].c_str()))
			{
				biggest = i;
			}
		}
		catch (const std::exception&)
		{
			//logger
		}
	}
	if (temp.size() > 0)
	{
		ret->push_back(temp.at(biggest));
	}

	delete[] local;
	return ret;

}
