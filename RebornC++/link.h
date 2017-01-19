#ifndef LINK_H
#define LINK_H
#include <string>
#include <algorithm>

class link
{
public:
	link();
	~link();
	int* GetIndexLenght();
	std::string NumberToString(int i);
	int StringToNumber(char letter);

private:
	int indexLenght = 64;
};

#endif // !LINK_H.



