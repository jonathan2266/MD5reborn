#include "wordJumper.h"



wordJumper::wordJumper()
{
	l = new link();
}


wordJumper::~wordJumper()
{
	delete l;
}

std::string wordJumper::Jump(std::string word, int increaseBy)
{
	int* base = l->GetIndexLenght();
	int combination = 0;

	std::reverse(word.begin(), word.end());
	for (size_t i = 0; i < word.size(); i++)
	{
		combination += std::pow(*base, i) * l->StringToNumber(word[i]);
	}

	combination += increaseBy;

	//check exponent size
	int expNr = 0;
	if (combination > (*base * 2) + 1)
	{
		while (true)
		{
			int res = combination - std::pow(*base, expNr);
			if (res > *base)
			{
				expNr++;
			}
			else if (res < *base)
			{
				expNr--;
				break;
			}
			else if (res == *base)
			{
				break;
			}
		}
	}
	else
	{
		while (true)
		{
			int res = combination - std::pow(*base, expNr);
			if (res > 0)
			{
				expNr++;
			}
			else if (res < 0)
			{
				expNr--;
				break;
			}
			else if (res == 0)
			{
				break;
			}
		}
	}


	//convert back to string
	std::string result = "";
	int combPig = combination;
	int count = 0;
	while (true)
	{
		if (expNr < 0)
		{
			result += l->NumberToString(0);
			break;
		}
		combPig = combination - std::pow(*base, expNr);
		if (combPig > 0)
		{
			combination = combPig;
			count++;
		}
		else if (combPig < 0)
		{
			combPig = combination;
			count--;
			expNr--;
			result += l->NumberToString(count);
			count = 0;
		}
		else if (combPig == 0)
		{
			if (combination != *base)
			{
				count++;
			}
			result += l->NumberToString(count);
			if (expNr > 0)
			{
				for (size_t i = 0; i < expNr; i++)
				{
					result += l->NumberToString(0);
				}
			}
			break;
		}
	}

	return result;
}
