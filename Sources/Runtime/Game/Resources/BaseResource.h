#pragma once
#include "IResource.h"

namespace Hiker
{
class BaseResource: public IResource
{
	std::string _filePath;
	std::string _name;

public:
	BaseResource()
	{
		
	}

	BaseResource(const std::string& name, const std::string& filePath)
	{
		_filePath = filePath;
		_name = name;
	}

	std::string GetFilePath() const override
	{
		return _filePath;
	}

	void SetFilePath(const std::string& filePath) override
	{
		_filePath = filePath;
	}

	std::string GetName() const override
	{
		return _name;
	}

	void SetName(const std::string& name) override
	{
		_name = name;
	}
};
}
