#include "wordGenerator.h"



wordGenerator::wordGenerator(string * wordToStartFrom)
{
	l = new link();
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
	bool addLetter = false;
	bool changed = false;
	for (int i = 0; i < listOfNumbers.size(); i++)
	{
		if (listOfNumbers[0] < 63 && i == 0)
		{
			listOfNumbers[0]++;
			changed = true;
		}
		if (listOfNumbers[0] == 63 && i < listOfNumbers.size() - 1 && i == 0 && changed == false)
		{
			listOfNumbers[0] = 1;
			listOfNumbers[1]++;
			changed = true;
		}
		if (listOfNumbers[i] == 63 && i == listOfNumbers.size() - 1 && changed == false)
		{
			listOfNumbers[i] = 1;
			addLetter = true;
			changed = true;
		}

		if (listOfNumbers[i] == 64 && i < listOfNumbers.size() - 1 && changed == false)
		{
			listOfNumbers[i] = 1;
			listOfNumbers[i + 1]++;
			changed = true;
		}
		if (listOfNumbers[i] == 64 && i == listOfNumbers.size() - 1 && changed == false)
		{
			listOfNumbers[i] = 1;
			addLetter = true;
			changed = true;
		}
		changed = false;
	}
	if (addLetter == true)
	{
		std::vector<int>::iterator it;
		it = listOfNumbers.begin();
		listOfNumbers.insert(it, 1);
	}
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
	std::vector<char> entry((*lastEntry).c_str(), (*lastEntry).c_str() + (*lastEntry).size() + 1);

	for (size_t i = 0; i < entry.size(); i++)
	{
		listOfNumbers.push_back(l->StringToNumber(entry.at(i)));
	}

	std::reverse(listOfNumbers.begin(), listOfNumbers.end());
}
