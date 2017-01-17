#include "dataSaverLocalHDD.h"



dataSaverLocalHDD::dataSaverLocalHDD()
{
}

dataSaverLocalHDD::dataSaverLocalHDD(string directory, string filename, string * unfinishedTag)
{
	//logger
	_directory = directory;
	_filename = filename;
	_unfinishedTag = unfinishedTag;
	configWriter();
}

dataSaverLocalHDD::~dataSaverLocalHDD()
{

}

void dataSaverLocalHDD::PushData(string * text, string* hash)
{
	try
	{
		*writer << *text << "\n" << *hash << "\n";
	}
	catch (const std::exception&)
	{
		//logger
	}
}

void dataSaverLocalHDD::Finish()
{
	writer->close();
	try
	{
		boost::filesystem::rename(_directory + *_unfinishedTag + _filename, _directory + _filename);
	}
	catch (const std::exception&)
	{
		//logging
	}
}

void dataSaverLocalHDD::configWriter()
{
	try
	{
		writer = new ofstream(_directory + *_unfinishedTag + _filename);
	}
	catch (const std::exception&)
	{
		//logger lol
	}
}
