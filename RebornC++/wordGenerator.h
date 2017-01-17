#ifndef WORDGENERATOR_H
#define WORDGENERATOR_H
#include <string>
#include <vector>
#include "link.h"

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

	void transLateToLetters();
	void convertToNumbers(string* lastEntry);
};

#endif // !WORDGENERATOR_H


