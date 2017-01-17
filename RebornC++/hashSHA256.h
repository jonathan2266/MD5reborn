#ifndef HASHSHA256_H
#define HASHSHA256_H
#include "hasher.h"
#include <openssl/sha.h>
#include <string>
#include <cstring>
#include <algorithm>

class hashSHA256 : public hasher
{
public:
	hashSHA256();
	~hashSHA256();
	virtual std::string Hash(const char text[]);
};

#endif // !HASHSHA256_H

