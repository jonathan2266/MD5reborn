#include "wordGenerator.h"






wordGenerator::wordGenerator(string * wordToStartFrom)
{
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
}

void wordGenerator::Next()
{

}

string wordGenerator::GetCurrentWord()
{
	return "a";
}

void wordGenerator::transLateToLetters()
{
}

void wordGenerator::convertToNumbers(string * lastEntry)
{
}
