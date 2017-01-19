#ifndef THREADMANAGER_H
#define THREADMANAGER_H
#include <string>
#include <thread>
#include <boost/thread.hpp>
#include "dataChecker.h"
#include "hasher.h"
#include "iDataSaver.h"
#include "dataSaverLocalHDD.h"
#include "wordGenerator.h"
#include "wordJumper.h"

using namespace std;
using namespace boost;
using namespace boost::this_thread;

class threadManager
{
public:
	threadManager(iDataChecker * dChecker, vector<string>* dir, string * fileUnFinishedTag, iHash * hash);
	threadManager(iDataChecker * dChecker, vector<string>* dir, string * fileUnFinishedTag, string* finishedFilePath, iHash * hash);
	~threadManager();
	void Start();
private:
	string echo;
	//logger
	iDataChecker* dChecker;
	vector<string>* dir;
	string* fileUnFinishedTag;
	string finishedFilePath;
	boost::thread* workers;
	iDataSaver** saver;
	int currentFileNr;
	string currentWord;
	bool isProgramRunning;
	bool* isDone;
	int nrOfGroupedHashes;
	folderState state;
	iHash* hash;
	int currentDriveGiven;

	void init(folderState state);
	void manage();
	void hashing(int threadID, string startWord, int lenght);
	void driveCounter();
};


#endif // !THREADMANAGER_H
