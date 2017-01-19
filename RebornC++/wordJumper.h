#ifndef WORDJUMPER_H
#define WORDJUMPER_H
#include <string>
#include <cmath>
#include "link.h"

class wordJumper
{
public:
	wordJumper();
	~wordJumper();
	std::string Jump(std::string word, int increaseBy);
private:
	link* l;
};

#endif // !WORDJUMPER_H

