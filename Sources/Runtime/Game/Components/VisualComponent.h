#pragma once
#include "Game/Resources/BaseResource.h"

namespace Hiker
{
class VisualComponent: public IComponent
{
	std::string			_name;
	BaseResource*		_image;
	sf::Vector2f		_position;
	bool				_isBackground;

public:
	VisualComponent()
	{
		_image = nullptr;
		_name = "Visual Component";
	}

	VisualComponent(BaseResource* image)
	{
		_image = image;
		_name = "Visual Component";
	}
	
	std::string GetName() const override
	{
		return _name;
	}

	void SetName(const std::string& name) override
	{
		_name = name;
	}

	void SetImage(BaseResource* image)
	{
		_image = image;
	}

	BaseResource* GetImage() const
	{
		return _image;
	}

	void SetPosition(const sf::Vector2f& position)
	{
		_position = position;
	}

	sf::Vector2f GetPosition() const
	{
		return _position;
	}

	bool IsBackground() const
	{
		return _isBackground;
	}

	void SetBackgroundFlag(bool isBackground)
	{
		_isBackground = isBackground;
	}
};
}
