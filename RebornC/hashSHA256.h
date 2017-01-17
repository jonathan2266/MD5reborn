#ifndef HASHSHA256_H
#define HASHSHA256_H
#include "hasher.h"

class hashSHA256 : public hasher
{
public:
	hashSHA256();
	~hashSHA256();
	virtual std::string Hash(const char text[]);
};

#endif // !HASHSHA256_H

