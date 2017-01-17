#include <vector>
#include <string>
#include <boost\filesystem.hpp>
#include <iostream>
#include <openssl\md5.h>
#include "iHash.h"
#include "hashMD5.h"
#include "hasher.h"
#include "hashSHA256.h"

using namespace std;
using namespace boost::filesystem;


int main(int argc, char* argv[]) {

	vector<string>* directory = new vector<string>();
	int count = 1;
	for (size_t i = 1; i < argc; i++)
	{
		if (is_directory(argv[i]))
		{
			directory->push_back(argv[i]);
			count++;
		}
		else
		{
			break;
		}
	}
	hasher* hash;

	std::string hashType = argv[count]; //add try
	if (hashType == "MD5")
	{
		hash = new hashMD5();
	}
	else if (hashType == "SHA256")
	{
		hash = new hashSHA256();
	}
	else
	{
		std::cout << "Error parsing second command line argument: " << argv[count];
		char m[50];
		std::cin >> m;
		return -1;
	}

	string fileUnfinishedTag = "unf";
	string logFileName = "MD5rebornLogs";

	char lol[50];
	std::cin >> lol;
}
