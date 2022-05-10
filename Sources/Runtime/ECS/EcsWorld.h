#pragma once
#include <vector>

#include "IEntity.h"
#include "IEcsSystem.h"

namespace Hiker
{
class EcsWorld
{
	std::vector<std::unique_ptr<IEcsSystem>> _systems;
	std::vector<std::unique_ptr<IEntity>>	 _entities;

public:
	void AddSystem(IEcsSystem* system)
	{
		_systems.emplace_back(system);
	}

	void AddEntity(IEntity* entity)
	{
		_entities.emplace_back(entity);
	}

	std::vector<std::unique_ptr<IEntity>>& GetEntities()
	{
		return _entities;
	}

	void Init()
	{
		for(auto& system: _systems)
		{
			system->Init();
		}
	}

	void OnFrame()
	{
		for (auto& system: _systems)
		{
			system->OnFrame();
		}
	}

	void Deinit()
	{
		for (auto& system : _systems)
			system->Deinit();

		_systems.clear();
	}
};
}
