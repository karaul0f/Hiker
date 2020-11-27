#include "Log.h"

namespace Utils
{
//-----------------------------------------------------------------------
Log* Log::Instance()
{
	static Log instance;
	return &instance;
}
//-----------------------------------------------------------------------
void Log::Print(const std::string& message) const
{
	
}
//-----------------------------------------------------------------------
}