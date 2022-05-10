#pragma once
#include <SFML/Graphics.hpp>
#include "ECS/EcsWorld.h"
#include "Loader/GameLoader.h"
#include "Resources/IResource.h"

namespace Hiker
{
class Game final
{
	bool _isRun;
	std::unique_ptr<sf::RenderWindow> _window;

	std::string _name;
	EcsWorld	_ecsWorld;

	std::map<std::string, std::unique_ptr<IResource>> _resources;
public:
	Game()
	{
		_name = "Hiker";
		_isRun = false;
	}

	void Init()
	{
		_isRun = true;

		GameLoader gameLoader(&_name, &_resources, &_ecsWorld, "/project.xml");
		gameLoader.Load();

		_window = std::make_unique<sf::RenderWindow>(sf::VideoMode(640, 480), _name);
		_ecsWorld.Init();
	}

	void OnFrame()
	{
		if(_isRun)
		{
			_ecsWorld.OnFrame();

			if (_window->isOpen())
			{
				sf::Event event;
				while (_window->pollEvent(event))
				{
					if (event.type == sf::Event::Closed)
						_window->close();
				}
				_window->display();
			}
			else
				_isRun = false;
		}
	}

	void Deinit()
	{
		_ecsWorld.Deinit();
	}

	bool IsRun() const
	{
		return _isRun;
	}
};
}
