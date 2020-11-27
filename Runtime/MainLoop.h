///////////////////////////////////////////////////////////
// Game.h
// �����:	������� �.�.
// ����:	11.11.20
//
// ���� ������. ����� ����� ���������� ������������� 
// � �������� ���� ����.
///////////////////////////////////////////////////////////

#pragma once
#include <string>

namespace Hiker
{

class MainLoop final
{
public:
						// ����� ���������
	static MainLoop*	Instance();

					// ��������� ������� ����
	void			Run(const std::string& filename);

private:
			// �������������� �������� ������� ������ (�������, ��������...)
	void	InitSubsystems();

			// �������� ���� ����
	void	Tick();

			// ����� ������� ��������� ��� ����
	void	Render();

	bool	m_isActive;
};

}