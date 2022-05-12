#pragma once
#include "ECS/IEcsSystem.h"

namespace Hiker
{
class RenderSystem : public IEcsSystem
{
	sf::RenderWindow* _window;
	EcsWorld* _ecsWorld;

	std::vector<sf::Sprite>				_backgroundSprites;
	std::vector<sf::Sprite>				_sprites;
	std::map<std::string, sf::Texture>	_textures;

	sf::View  _view;
public:
	RenderSystem(EcsWorld* ecsWorld, sf::RenderWindow* window)
	{
		_ecsWorld = ecsWorld;
		_window = window;
	}

	void Init() override
	{
		for(std::unique_ptr<IEntity>& resource: _ecsWorld->GetEntities())
		{
			VisualComponent* vc = resource->GetVisualComponent();
			std::string filePath = std::filesystem::current_path().string() + "\\" + vc->GetImage()->GetFilePath();

			if(_textures.count(filePath) == 0)
				_textures[filePath].loadFromFile(filePath);

			sf::Texture& texture = _textures[filePath];

			sf::Sprite sprite;
			sprite.setTexture(texture);
			sprite.setPosition(vc->GetPosition());
			sprite.setOrigin(texture.getSize().x / 2, texture.getSize().y / 2);

			if (!vc->IsBackground())
				_sprites.emplace_back(sprite);
			else
				_backgroundSprites.emplace_back(sprite);
		}

		_view.reset(sf::FloatRect(0, 0, 640, 480));
		_view.setCenter(0, 0);
	}

	void OnFrame() override
	{
		sf::Event event;
		while (_window->pollEvent(event))
		{
			if (event.type == sf::Event::Closed)
				_window->close();
		}

		_window->setView(_view);
		_window->clear();

		for (const auto& sprite : _backgroundSprites)
			_window->draw(sprite);

		for (const auto& sprite : _sprites)
			_window->draw(sprite);

		_window->display();
	}

	void Deinit() override
	{
		
	}
};
}
