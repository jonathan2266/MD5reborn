#include <vector>
#include <string>
#include <boost\filesystem.hpp>
#include <iostream>
#include <openssl\md5.h>
#include "iHash.h"
#include "hashMD5.h"

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




	char lol[50];
	std::cin >> lol;
}
