#include "link.h"

#ifndef WORDGENERATOR_H
#define WORDGENERATOR_H
#include <string>
#include <vector>
#include <algorithm>

using namespace std;

class wordGenerator
{
public:
	wordGenerator(string* wordToStartFrom);
	~wordGenerator();
	void Next();
	string GetCurrentWord();
private:
	vector<int> listOfNumbers;
	string text;
	link* l;
	int* base;

	void transLateToLetters();
	void convertToNumbers(string* lastEntry);
	void checkOverflow();
};

#endif // !WORDGENERATOR_H


