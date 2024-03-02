using System;
using System.Runtime.InteropServices;

namespace CraftingGod;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct Chance
{
	public static bool Define(float Chance)
	{
		Random random = new Random();
		if ((float)random.Next(10001) <= Chance * 100f)
		{
			return true;
		}
		return false;
	}
}
