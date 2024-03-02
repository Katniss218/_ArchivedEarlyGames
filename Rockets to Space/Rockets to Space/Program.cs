using System;

namespace Rockets_to_Space
{
	static class Program
	{
		static void Main()
		{
			using (Main game = new Main())
			{
				game.Run();
			}
		}
	}
}

