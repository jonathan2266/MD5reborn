#include "dataSaverLocalHDD.h"


std::ofstream* writer;

dataSaverLocalHDD::dataSaverLocalHDD()
{
}

dataSaverLocalHDD::dataSaverLocalHDD(string directory, string filename, string * unfinishedTag)
{
	//logger
	this->directory = directory;
	this->filename = filename;
	this->unfinishedTag = unfinishedTag;
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
		boost::filesystem::rename(directory + "\\" +*unfinishedTag + filename, directory + "\\" + filename);
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
		writer = new ofstream(directory + "\\" + *unfinishedTag + filename);
		*writer << "lol plz";
	}
	catch (const std::exception&)
	{
		//logger lol
	}
}
