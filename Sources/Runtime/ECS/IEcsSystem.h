#pragma once

namespace Hiker
{
class EcsWorld;

class IEcsSystem
{
public:
	virtual void Init() = 0;
	virtual void OnFrame() = 0;
	virtual void Deinit() = 0;

	virtual ~IEcsSystem() {}
};
}
