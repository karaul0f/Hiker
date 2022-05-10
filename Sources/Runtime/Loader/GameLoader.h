#pragma once
#include "Utils/tinyxml2.h"
#include <string>
#include "ILoader.h"
#include "ECS/EcsWorld.h"
#include "Game/Components/VisualComponent.h"
#include "Game/Resources/BaseResource.h"
#include "Game/Entities/BaseEntity.h"
#include "Game/Systems/RenderSystem.h"

namespace Hiker
{
class GameLoader: public ILoader 
{
public:
	typedef std::map<std::string, std::unique_ptr<IResource>> TResourceMap;

private:
	std::string*	_gameName;
	EcsWorld*		_ecsWorld;
	TResourceMap*	_resources;
	std::string		_pathToDirectory;

public:
	GameLoader(std::string* gameName, TResourceMap* resources, EcsWorld* ecsWorld, const std::string pathToDirectory)
	{
		_gameName = gameName;
		_resources = resources;
		_ecsWorld = ecsWorld;
		_pathToDirectory = pathToDirectory;
	}

	void Load() override
	{
		_ecsWorld->AddSystem(new Hiker::RenderSystem);

		tinyxml2::XMLDocument doc;
		doc.LoadFile("/Project.xml");

		tinyxml2::XMLElement* xProject = doc.FirstChildElement("Project");
		_gameName->append(xProject->Attribute("Name"));

		tinyxml2::XMLElement* xResources = xProject->FirstChildElement("Recources");

		for (tinyxml2::XMLElement* xResource = xResources->FirstChildElement("Resource");
			xResource != nullptr; xResource = xResource->NextSiblingElement())
		{
			const auto& resourceName = std::string(xResource->Attribute("Name"));
			const auto& resourceFilePath = std::string(xResource->Attribute("FilePath"));

			_resources->emplace(resourceName, std::make_unique<BaseResource>(resourceName, resourceFilePath));
		}

		tinyxml2::XMLElement* xEntities = xProject->FirstChildElement("Entities");
		for (tinyxml2::XMLElement* xEntity = xEntities->FirstChildElement("Entity");
			xEntity != nullptr; xEntity = xEntity->NextSiblingElement())
		{
			BaseEntity* baseEntity = new BaseEntity(xEntity->Attribute("Name"));

			tinyxml2::XMLElement* xComponent = xEntity->FirstChildElement("Component");

			auto imageResourceName = std::string(xComponent->Attribute("Name"));

			VisualComponent* visualComponent = new VisualComponent(dynamic_cast<BaseResource*>(_resources->at(imageResourceName).get()));
			baseEntity->AddComponent(visualComponent);
			_ecsWorld->AddEntity(baseEntity);
		}
	}
};
}
