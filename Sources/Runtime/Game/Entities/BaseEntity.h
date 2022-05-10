#pragma once
#include "ECS/IEntity.h"

namespace Hiker
{
class BaseEntity: public IEntity
{
	std::string _name;

	std::vector<std::unique_ptr<IComponent>> _components;
public:
	BaseEntity()
	{
		
	}

	BaseEntity(const std::string& name)
	{
		_name = name;
	}

	void AddComponent(IComponent* component) override
	{
		_components.emplace_back(component);
	}

	void SetName(const std::string& name) override
	{
		_name = name;
	}

	std::string GetName() const override
	{
		return _name;
	}

	VisualComponent* GetVisualComponent() const override
	{
		if (_components.empty())
			return nullptr;

		return dynamic_cast<VisualComponent*>(_components[0].get());
	}

	std::vector<std::unique_ptr<IComponent>>& GetComponents() override
	{
		return _components;
	}
};
}
