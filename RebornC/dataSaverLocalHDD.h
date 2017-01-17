#ifndef DATASAVERLOCALHDD_H
#define DATASAVERLOCALHDD_H
#include "dataSaver.h"
#include <fstream>
#include <boost\filesystem.hpp>

using namespace std;

class dataSaverLocalHDD : public dataSaver
{
public:
	dataSaverLocalHDD();
	dataSaverLocalHDD(string directory, string filename, string* unfinishedTag);
	~dataSaverLocalHDD();
	virtual void PushData(string* text, string* hash);
	virtual void Finish();
private:
	string echo = "DataSaverLocalHDD: ";
	std::ofstream* writer;
	string* _unfinishedTag;
	string _directory;
	string _filename;
	void configWriter();
};

#endif // !DATASAVERLOCALHDD_H

