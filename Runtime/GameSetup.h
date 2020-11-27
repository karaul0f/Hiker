///////////////////////////////////////////////////////////
// GameSetup.h
// Автор:	Воинков А.В.
// Дата:	11.11.20
//
// Основные настройки для взаимодействия с игрой.
///////////////////////////////////////////////////////////
#pragma once
#include <string>

namespace Hiker
{
class GameSetup
{
public:
	// Вызов синглтона
	static GameSetup* Instance();

				// Инициализировать игровой мир
	void		Init(const std::string filename);
	
				// Получить название игры
	std::string	GetTitle();
private:
	bool	m_isActive;

	std::string m_title;
};
}