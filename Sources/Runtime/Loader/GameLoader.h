#pragma once
#include <filesystem>
#include <boost/lexical_cast.hpp>

#include "Utils/tinyxml2.h"
#include <string>
#include <filesystem>
#include "ILoader.h"
#include "ECS/EcsWorld.h"
#include "Game/Components/VisualComponent.h"
#include "Game/Resources/BaseResource.h"
#include "Game/Entities/BaseEntity.h"
#include "Game/Systems/RenderSystem.h"

namespace boost {
	template<>
	bool lexical_cast<bool, std::string>(const std::string& arg) {
		std::istringstream ss(arg);
		bool b;
		ss >> std::boolalpha >> b;
		return b;
	}

	template<>
	std::string lexical_cast<std::string, bool>(const bool& b) {
		std::ostringstream ss;
		ss << std::boolalpha << b;
		return ss.str();
	}
}

namespace Hiker
{
class GameLoader: public ILoader 
{
public:
	typedef std::map<std::string, std::unique_ptr<IResource>> TResourceMap;

private:
	EcsWorld*		_ecsWorld;
	TResourceMap*	_resources;
	std::string		_pathToDirectory;

public:
	GameLoader(TResourceMap* resources, EcsWorld* ecsWorld, const std::string pathToDirectory)
	{
		_resources = resources;
		_ecsWorld = ecsWorld;
		_pathToDirectory = pathToDirectory;
	}

	void Load() override
	{
		std::string projectPath = std::filesystem::current_path().string() + "\\" + "project.xml";
		tinyxml2::XMLDocument doc;
		doc.LoadFile(projectPath.c_str());

		tinyxml2::XMLElement* xProject = doc.FirstChildElement("Project");

		tinyxml2::XMLElement* xResources = xProject->FirstChildElement("Resources");

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

			auto imageResourceName = std::string(xComponent->Attribute("Image"));

			VisualComponent* visualComponent = new VisualComponent();
			visualComponent->SetImage(dynamic_cast<BaseResource*>(_resources->at(imageResourceName).get()));
			visualComponent->SetPosition(sf::Vector2f(atof(xComponent->Attribute("XPos")), 
				-atof(xComponent->Attribute("YPos"))));
			visualComponent->SetBackgroundFlag(boost::lexical_cast<bool>(std::string(xComponent->Attribute("IsBackground"))));
			baseEntity->AddComponent(visualComponent);

			_ecsWorld->AddEntity(baseEntity);
		}
	}
};
}
