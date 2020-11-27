///////////////////////////////////////////////////////////
// Log.h
// Автор:	Воинков А.В.
// Дата:	11.11.20
//
// Класс, обеспечивающий поддержку логирования.
///////////////////////////////////////////////////////////
#pragma once
#include <string>
#define HLOG(msg) Utils::Log::Instance()->Print(msg)

namespace Utils
{
class Log
{
public:
					// Вызов синглтона
	static Log*		Instance();

					// Занести сообщение в лог
	void			Print(const std::string& message) const;
};
}