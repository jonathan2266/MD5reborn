#include "wordGenerator.h"



wordGenerator::wordGenerator(string * wordToStartFrom)
{
	l = new link();
	base = l->GetIndexLenght();
	text = *wordToStartFrom;
	if (*wordToStartFrom == "")
	{
		listOfNumbers.push_back(0);
	}
	else
	{
		convertToNumbers(wordToStartFrom);
	}
}

wordGenerator::~wordGenerator()
{
	delete l;
}

void wordGenerator::Next()
{
	listOfNumbers[0] += 1;

	checkOverflow();

	transLateToLetters();
}

string wordGenerator::GetCurrentWord()
{
	return text;
}

void wordGenerator::transLateToLetters()
{
	vector<int> reversed = listOfNumbers;
	string builder = "";
	std::reverse(reversed.begin(), reversed.end());

	for (size_t i = 0; i < listOfNumbers.size(); i++)
	{
		builder.append(l->NumberToString(reversed.at(i)));
	}
	text = builder;
}

void wordGenerator::convertToNumbers(string * lastEntry)
{
	std::vector<char> entry((*lastEntry).c_str(), (*lastEntry).c_str() + (*lastEntry).size());

	for (size_t i = 0; i < entry.size(); i++)
	{
		listOfNumbers.push_back(l->StringToNumber(entry.at(i)));
	}

	std::reverse(listOfNumbers.begin(), listOfNumbers.end());
}

void wordGenerator::checkOverflow()
{
	bool overflowFound = false;
	for (size_t i = 0; i < listOfNumbers.size(); i++)
	{
		if (listOfNumbers[i] == 64)
		{
			overflowFound = true;
			listOfNumbers[i] = 1;
			//check if can carry
			if (i + 1 < listOfNumbers.size()) //space to carry
			{
				listOfNumbers[i + 1] += 1;
			}
			else
			{
				listOfNumbers.push_back(1);
			}
		}
	}

	if (overflowFound)
	{
		checkOverflow();
	}
}
