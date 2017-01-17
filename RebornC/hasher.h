#ifndef HASHER_H
#define HASHER_H
#include "iHash.h"
#include <string>

class hasher : public iHash
{
public:
	hasher();
	~hasher();
	virtual std::string Hash(const char text[]) = 0;
};

#endif // !HASHER_H

