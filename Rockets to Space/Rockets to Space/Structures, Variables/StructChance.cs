using System;

namespace Rockets_to_Space
{
	public struct Chance
	{
		public static bool Define( float Chance )
		{
			Random rand = new Random();
			if( (int)rand.Next(10000) <= (int)Chance * 100 )
			{
				return true;
			}
			return false;
		}
	}
}
