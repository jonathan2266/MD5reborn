#include <vector>
#include <string>
#include <boost/filesystem.hpp>
#include <iostream>
#include "iHash.h"
#include "hashMD5.h"
#include "hasher.h"
#include "hashSHA256.h"
#include "hashSHA512.h"
#include "dataChecker.h"
#include "dataCheckerLocalHDD.h"
#include "threadManager.h"

using namespace std;
using namespace boost::filesystem;


int main(int argc, char* argv[]) {

	vector<string>* directory = new vector<string>();
	int count = 1;
	for (size_t i = 1; i < argc; i++)
	{
		if (is_directory(argv[i]))
		{
			directory->push_back(argv[i]);
			count++;
		}
		else
		{
			break;
		}
	}
	iHash* hashh;

	std::string hashType = argv[count]; //add try
	if (hashType == "MD5")
	{
		hashh = new hashMD5();
	}
	else if (hashType == "SHA256")
	{
		hashh = new hashSHA256();
	}
	else if (hashType == "SHA512")
	{
		hashh = new hashSHA512();
	}
	else
	{
		std::cout << "Error parsing second command line argument: " << argv[count];
		char m[50];
		std::cin >> m;
		return -1;
	}

	string fileUnfinishedTag = "unf";
	string logFileName = "MD5rebornLogs";

	//init logger and terminal

	//dircheck
	iDataChecker* dChecker = new dataCheckerLocalHDD(directory, &fileUnfinishedTag);

	folderState state;
	std::vector<std::string> files;

	dChecker->GetStatus(state, files);

	threadManager* tManager;
	if (state == folderState::finished)
	{
		tManager = new threadManager(dChecker, directory, &fileUnfinishedTag, &files.at(0), hashh);
	}
	else if (state == folderState::none)
	{
		tManager = new threadManager(dChecker, directory, &fileUnfinishedTag, hashh);
	}

	tManager->Start();

	//char lol[50];
	//std::cin >> lol;

	return 0;
}
