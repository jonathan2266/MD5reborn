#ifndef DATASAVER_H
#define DATASAVER_H
#include "iDataSaver.h"

class dataSaver : public iDataSaver
{
public:
	dataSaver(); //logger
	~dataSaver();
	virtual void PushData(std::string* text, std::string* hash) = 0;
	virtual void Finish() = 0;
};

#endif // !DATASAVER_H

