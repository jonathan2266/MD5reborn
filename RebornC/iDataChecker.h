#ifndef IDATACHECKER_H
#define IDATACHECKER_H
#include "enum.h"
#include <vector>
#include <string>

class iDataChecker
{
public:
	virtual void GetStatus(folderState& state, std::vector<std::string>& files) = 0;
	virtual void GetLastWordOfFileInfo(std::string fileDir, int& lineNumber, std::string& word) = 0;
};

#endif // !IDATACHECKER_H

