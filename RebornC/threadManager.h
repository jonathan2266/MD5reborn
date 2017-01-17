#ifndef THREADMANAGER_H
#define THREADMANAGER_H
#include <string>
#include <thread>
#include "dataChecker.h"
#include "hasher.h"

using namespace std;

class threadManager
{
public:
	threadManager(iDataChecker * dChecker, vector<string>* dir, string * fileUnFinishedTag, iHash * hash);
	~threadManager();
private:
	string echo;
	//logger
	iDataChecker* dChecker;
	vector<string>* dir;
	string* fileUnFinishedTag;
	string finishedFilePath;
	//threads?
	//datasaver
	int currentFileNr;
	string currentWord;
	bool isProgramRunning;
	bool* isDone;
	int nrOfGroupedHashes;
	folderState state;
	iHash* hash;
	int currentDriveGiven;

	void init(folderState state);
};


#endif // !THREADMANAGER_H
