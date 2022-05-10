#pragma once
#include <string>

namespace Hiker
{
class IComponent
{
public:
	virtual std::string GetName() const = 0;
	virtual void		SetName(const std::string& name) = 0;

	virtual ~IComponent() {}
};
}
