#include "hashSHA256.h"



hashSHA256::hashSHA256()
{
}


hashSHA256::~hashSHA256()
{
}

std::string hashSHA256::Hash(const char text[])
{
	unsigned char digest[SHA256_DIGEST_LENGTH];
	SHA256_CTX sha256;
	SHA256_Init(&sha256);
	SHA256_Update(&sha256, text, strlen(text));
	SHA256_Final(digest, &sha256);

	char out[65];

	for (size_t i = 0; i < SHA256_DIGEST_LENGTH; i++)
	{
		sprintf(&out[i * 2], "%02x", digest[i]);
	}

	std::string m = std::string(out);
	return m;
}
