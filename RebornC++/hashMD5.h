#ifndef HASHMD5_H
#define HASHMD5_H
#include "hasher.h"
#include <openssl/md5.h>
#include <string>
#include <cstring>

class hashMD5 : public hasher
{
public:
	virtual std::string Hash(const char text[]);
	~hashMD5();
};

#endif // !HASHMD5_H


