///////////////////////////////////////////////////////////
// Game.h
// Автор:	Воинков А.В.
// Дата:	11.11.20
//
// Ядро движка. Здесь также происходит инициализация 
// и основной цикл игры.
///////////////////////////////////////////////////////////

#pragma once
#include <string>

namespace Hiker
{

class MainLoop final
{
public:
						// Вызов синглтона
	static MainLoop*	Instance();

					// Запускает игровой цикл
	void			Run(const std::string& filename);

private:
			// Инициализируем основные системы движка (графика, геймплей...)
	void	InitSubsystems();

			// Основной цикл игры
	void	Tick();

			// Вызов функций отрисовки для игры
	void	Render();

	bool	m_isActive;
};

}