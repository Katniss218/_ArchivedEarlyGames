/*
 * Created by SharpDevelop.
 * User: Kuba
 * Date: 2015-11-20
 * Time: 08:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace WarTime
{
	/// <summary>
	/// returns a boolean value.
	/// </summary>
	public class Chance
	{
		public Chance( int chance )
		{
			private bool bool1 = false;
			Random rand = new Random();
			int random = (int)rand.Next(1000);
			if( random <= chance )
			{
				bool1 = true;
			}
			return (bool1);
		}
	}
}
