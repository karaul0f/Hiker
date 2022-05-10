#pragma once
#include "IComponent.h"

namespace Hiker
{
class VisualComponent;

class IEntity
{
public:
	virtual void		SetName(const std::string& name) = 0;
	virtual std::string	GetName() const = 0;

	virtual void AddComponent(IComponent* component) = 0;

	virtual VisualComponent* GetVisualComponent() const = 0;

	virtual std::vector<std::unique_ptr<IComponent>>& GetComponents() = 0;

	virtual ~IEntity() {}
};
}
