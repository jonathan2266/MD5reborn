#include "hashMD5.h"


char * hashMD5::Hash(const char text[])
{
	unsigned char digest[MD5_DIGEST_LENGTH];
	MD5((unsigned char*)text, strlen(text), (unsigned char*)digest);
	char* md = new char[33];
	for (size_t i = 0; i < MD5_DIGEST_LENGTH; i++)
	{
		sprintf(&md[i * 2], "%02x", digest[i]);
	}
	
	return md;
}

hashMD5::~hashMD5()
{
}
