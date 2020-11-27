///////////////////////////////////////////////////////////
// GameSetup.h
// �����:	������� �.�.
// ����:	11.11.20
//
// �������� ��������� ��� �������������� � �����.
///////////////////////////////////////////////////////////
#pragma once
#include <string>

namespace Hiker
{
class GameSetup
{
public:
	// ����� ���������
	static GameSetup* Instance();

				// ���������������� ������� ���
	void		Init(const std::string filename);
	
				// �������� �������� ����
	std::string	GetTitle();
private:
	bool	m_isActive;

	std::string m_title;
};
}