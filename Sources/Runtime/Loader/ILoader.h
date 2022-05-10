#pragma once

namespace Hiker
{
class ILoader
{
public:
	virtual void Load() = 0;

	virtual ~ILoader() {}
};
}
