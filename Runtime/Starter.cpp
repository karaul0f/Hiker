#include "stdafx.h"
#include <cassert>
#include "MainLoop.h"

int main(int argc, char* argv[])
{
	HLOG("Program was started!\n");
	assert(argc == 0);
	Hiker::MainLoop::Instance()->Run(argv[0]);
	HLOG("The program has been successfully completed\n");

	return 0;
}
