#ifndef DATACHECKERLOCALHDD_H
#define DATACHECKERLOCALHDD_H
#include "dataChecker.h"
#include <boost\filesystem.hpp>

class dataCheckerLocalHDD : public dataChecker
{
public:
	dataCheckerLocalHDD(std::vector<std::string>* directory, std::string* unfinishedTag);
	~dataCheckerLocalHDD();
	virtual void GetStatus(folderState& state, std::vector<std::string>& files);
	virtual void GetLastWordOfFileInfo(std::string fileDir, int& lineNumber, std::string& word);
private:
	std::string echo = "DataCheckerLocalHDD :";
	std::string* _unfinishedTag;
	std::vector<std::string> _directory;
	std::vector<std::string>* GetDirectoryFromDrives();
	std::vector<std::string>* getLastestFile(std::vector<std::string>& temp);

};

#endif // !DATACHECKERLOCALHDD_H

