#pragma once
#include "stdafx.h"
#include "MainLoop.h"

namespace Hiker
{
//-----------------------------------------------------------------------
MainLoop* MainLoop::Instance()
{
	static MainLoop instance;
	return &instance;
}
//-----------------------------------------------------------------------
void MainLoop::Run(const std::string& filename)
{
	if (m_isActive)
		return;

	//HLOG("Game was started!");

	InitSubsystems();
}
//-----------------------------------------------------------------------
void MainLoop::InitSubsystems()
{
	
}
//-----------------------------------------------------------------------
void MainLoop::Tick()
{
	Render();
}
//-----------------------------------------------------------------------
void MainLoop::Render()
{
	
}
//-----------------------------------------------------------------------
}