#ifndef DATACHECKER_H
#define DATACHECKER_H
#include "iDataChecker.h"

class dataChecker : public iDataChecker
{
public:
	dataChecker();
	~dataChecker();
	virtual void GetStatus(folderState& state, std::vector<std::string>& files) = 0;
	virtual void GetLastWordOfFileInfo(std::string fileDir, int& lineNumber, std::string& word) = 0;
};

#endif // !DATACHECKER_H

