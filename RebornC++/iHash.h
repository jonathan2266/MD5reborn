#ifndef IHASH_H
#define IHASH_H
#include <string>

class iHash
{
public:
	virtual std::string Hash(const char text[]) = 0;
};

#endif // !IHASH_H

