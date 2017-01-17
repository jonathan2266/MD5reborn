#ifndef IDATASAVER_H
#define IDATASAVER_H
#include <string>

class iDataSaver
{
public:
	virtual void PushData(std::string* text, std::string* hash) = 0;
	virtual void Finish() = 0; //or deconstructor :p
};

#endif // !IDATASAVER_H

