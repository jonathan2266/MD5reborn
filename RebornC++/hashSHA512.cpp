#include "hashSHA512.h"



hashSHA512::hashSHA512()
{
}


hashSHA512::~hashSHA512()
{
}

std::string hashSHA512::Hash(const char text[])
{
	unsigned char digest[SHA512_DIGEST_LENGTH];
	SHA512_CTX sha512;
	SHA512_Init(&sha512);
	SHA512_Update(&sha512, text, strlen(text));
	SHA512_Final(digest, &sha512);

	char out[SHA512_DIGEST_LENGTH * 2 + 1];

	for (size_t i = 0; i < SHA512_DIGEST_LENGTH; i++)
	{
		sprintf(&out[i * 2], "%02x", digest[i]);
	}

	std::string m = std::string(out);
	return m;
}
