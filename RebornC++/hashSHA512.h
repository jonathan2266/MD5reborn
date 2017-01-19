#ifndef HASHSHA512
#define HASHSHA512
#include "hasher.h"
#include <openssl/sha.h>
#include <string>
#include <cstring>

class hashSHA512 : public hasher
{
public:
	hashSHA512();
	~hashSHA512();
	virtual std::string Hash(const char text[]);
};

#endif // !HASHSHA512

