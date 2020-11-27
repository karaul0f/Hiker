///////////////////////////////////////////////////////////
// Log.h
// �����:	������� �.�.
// ����:	11.11.20
//
// �����, �������������� ��������� �����������.
///////////////////////////////////////////////////////////
#pragma once
#include <string>
#define HLOG(msg) Utils::Log::Instance()->Print(msg)

namespace Utils
{
class Log
{
public:
					// ����� ���������
	static Log*		Instance();

					// ������� ��������� � ���
	void			Print(const std::string& message) const;
};
}