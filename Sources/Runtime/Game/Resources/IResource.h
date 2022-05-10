#pragma once
#include <string>

namespace Hiker
{
class IResource
{
public:
	virtual std::string GetFilePath() const = 0;
	virtual void		SetFilePath(const std::string& filePath) = 0;

	virtual std::string GetName() const = 0;
	virtual void		SetName(const std::string& name) = 0;

	virtual ~IResource() { };
};
}
