#pragma once
#include "GameSetup.h"

namespace Hiker
{
//-----------------------------------------------------------------------
GameSetup* GameSetup::Instance()
{
	static GameSetup instance;
	return &instance;
}
//-----------------------------------------------------------------------
void GameSetup::Init(const std::string filename)
{

}
//-----------------------------------------------------------------------
std::string GameSetup::GetTitle()
{
	return m_title;
}
//-----------------------------------------------------------------------
}