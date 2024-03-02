using System;
using Microsoft.Xna.Framework;

namespace CraftingGod;

internal static class Program
{
	private static void Main()
	{
		Main main = new Main();
		try
		{
			((Game)main).Run();
		}
		finally
		{
			((IDisposable)main)?.Dispose();
		}
	}
}
