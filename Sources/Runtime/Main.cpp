#include "Game/Game.h"

int main(int argc, char* argv[])
{
	Hiker::Game game;

	game.Init();

	while (game.IsRun())
		game.OnFrame();

	return 0;
}
