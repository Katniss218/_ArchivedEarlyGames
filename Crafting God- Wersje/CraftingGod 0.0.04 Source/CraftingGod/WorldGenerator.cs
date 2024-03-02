using System;
using Microsoft.Xna.Framework;

namespace CraftingGod;

public class WorldGenerator
{
	public static int Seed = 5344;

	public static void DestroyTile(short x, short y)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		Main.Tile[x, y] = null;
		Main.Tile[x, y] = new Tile("Air", checked(new Vector2((float)(x * 20) + Main.ScreenPosition.X, (float)(y * 20) + Main.ScreenPosition.Y)), IsWall: false);
	}

	public static void DigTile(short x, short y)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		Main.DropItem(Main.Tile[x, y].DropID, Main.Tile[x, y].Position);
		Main.Tile[x, y] = null;
		Main.Tile[x, y] = new Tile("Air", checked(new Vector2((float)(x * 20) + Main.ScreenPosition.X, (float)(y * 20) + Main.ScreenPosition.Y)), IsWall: false);
	}

	public static void PlaceTile(string ID, short x, short y, bool IsWall, bool ConsumePlayerResource, Vector2 Position, Vector2 PlacedSize)
	{
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		bool flag = true;
		checked
		{
			for (int i = 1; (float)i <= PlacedSize.X; i++)
			{
				for (int j = 1; (float)j <= PlacedSize.Y; j++)
				{
					if (!(Main.Tile[x + i - 1, y + j - 1].ID == "Air"))
					{
						flag = false;
					}
				}
			}
			if (flag)
			{
				if (ConsumePlayerResource)
				{
					Main.Tile[x, y] = new Tile(ID, new Vector2(Position.X, Position.Y), IsWall);
					Main.Player.Inventory[Main.ActiveSlot].Item.Count--;
				}
				else
				{
					Main.Tile[x, y] = new Tile(ID, new Vector2(Position.X, Position.Y), IsWall);
				}
				Main.Tile[x, y].UUIDx = x;
				Main.Tile[x, y].UUIDy = y;
			}
		}
	}

	public static void GrowTree(short x, short y, Vector2 Position, bool ConsumePlayerResource)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0318: Unknown result type (might be due to invalid IL or missing references)
		//IL_0327: Unknown result type (might be due to invalid IL or missing references)
		//IL_035b: Unknown result type (might be due to invalid IL or missing references)
		//IL_036a: Unknown result type (might be due to invalid IL or missing references)
		//IL_039e: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_041b: Unknown result type (might be due to invalid IL or missing references)
		//IL_042a: Unknown result type (might be due to invalid IL or missing references)
		//IL_045e: Unknown result type (might be due to invalid IL or missing references)
		//IL_046d: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04db: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ea: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			PlaceTile("Wood Log", x, (short)(y - 1), IsWall: false, ConsumePlayerResource: false, new Vector2(Position.X, Position.Y - 20f), new Vector2(1f, 1f));
			PlaceTile("Wood Log", x, (short)(y - 2), IsWall: false, ConsumePlayerResource: false, new Vector2(Position.X, Position.Y - 40f), new Vector2(1f, 1f));
			PlaceTile("Wood Log", x, (short)(y - 3), IsWall: false, ConsumePlayerResource: false, new Vector2(Position.X, Position.Y - 60f), new Vector2(1f, 1f));
			PlaceTile("Wood Log", x, (short)(y - 4), IsWall: false, ConsumePlayerResource: false, new Vector2(Position.X, Position.Y - 80f), new Vector2(1f, 1f));
			PlaceTile("Wood Log", x, (short)(y - 5), IsWall: false, ConsumePlayerResource: false, new Vector2(Position.X, Position.Y - 100f), new Vector2(1f, 1f));
			PlaceTile("Wood Log", x, (short)(y - 6), IsWall: false, ConsumePlayerResource: false, new Vector2(Position.X, Position.Y - 120f), new Vector2(1f, 1f));
			PlaceTile("Leaves", (short)(x - 1), (short)(y - 4), IsWall: false, ConsumePlayerResource: false, new Vector2(Position.X - 20f, Position.Y - 80f), new Vector2(1f, 1f));
			PlaceTile("Leaves", (short)(x + 1), (short)(y - 4), IsWall: false, ConsumePlayerResource: false, new Vector2(Position.X + 20f, Position.Y - 80f), new Vector2(1f, 1f));
			PlaceTile("Leaves", (short)(x - 1), (short)(y - 5), IsWall: false, ConsumePlayerResource: false, new Vector2(Position.X - 20f, Position.Y - 100f), new Vector2(1f, 1f));
			PlaceTile("Leaves", (short)(x + 1), (short)(y - 5), IsWall: false, ConsumePlayerResource: false, new Vector2(Position.X + 20f, Position.Y - 100f), new Vector2(1f, 1f));
			PlaceTile("Leaves", (short)(x - 2), (short)(y - 5), IsWall: false, ConsumePlayerResource: false, new Vector2(Position.X - 40f, Position.Y - 100f), new Vector2(1f, 1f));
			PlaceTile("Leaves", (short)(x + 2), (short)(y - 5), IsWall: false, ConsumePlayerResource: false, new Vector2(Position.X + 40f, Position.Y - 100f), new Vector2(1f, 1f));
			PlaceTile("Leaves", (short)(x - 1), (short)(y - 6), IsWall: false, ConsumePlayerResource: false, new Vector2(Position.X - 20f, Position.Y - 120f), new Vector2(1f, 1f));
			PlaceTile("Leaves", (short)(x + 1), (short)(y - 6), IsWall: false, ConsumePlayerResource: false, new Vector2(Position.X + 20f, Position.Y - 120f), new Vector2(1f, 1f));
			PlaceTile("Leaves", (short)(x - 2), (short)(y - 6), IsWall: false, ConsumePlayerResource: false, new Vector2(Position.X - 40f, Position.Y - 120f), new Vector2(1f, 1f));
			PlaceTile("Leaves", (short)(x + 2), (short)(y - 6), IsWall: false, ConsumePlayerResource: false, new Vector2(Position.X + 40f, Position.Y - 120f), new Vector2(1f, 1f));
			PlaceTile("Acorn", x, (short)(y - 7), IsWall: false, ConsumePlayerResource: false, new Vector2(Position.X, Position.Y - 140f), new Vector2(1f, 1f));
			PlaceTile("Leaves", (short)(x - 1), (short)(y - 7), IsWall: false, ConsumePlayerResource: false, new Vector2(Position.X - 20f, Position.Y - 140f), new Vector2(1f, 1f));
			PlaceTile("Leaves", (short)(x + 1), (short)(y - 7), IsWall: false, ConsumePlayerResource: false, new Vector2(Position.X + 20f, Position.Y - 140f), new Vector2(1f, 1f));
			PlaceTile("Leaves", x, (short)(y - 8), IsWall: false, ConsumePlayerResource: false, new Vector2(Position.X, Position.Y - 160f), new Vector2(1f, 1f));
			if (ConsumePlayerResource)
			{
				Main.Player.Inventory[Main.ActiveSlot].Item.Count--;
			}
		}
	}

	public static void CreateVein(short x, short y, double Strength, int Rolls, string ID)
	{
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		double num = Strength;
		float num2 = Rolls;
		Vector2 val = default(Vector2);
		val.X = x;
		val.Y = y;
		Vector2 val2 = default(Vector2);
		val2.X = (float)Main.rand.Next(-10, 11) * 0.1f;
		val2.Y = (float)Main.rand.Next(-10, 11) * 0.1f;
		checked
		{
			while (num > 0.0 && num2 > 0f)
			{
				if (val.Y < 0f && num2 > 0f)
				{
					num2 = 0f;
				}
				num = Strength * (double)(num2 / (float)Rolls);
				num2 -= 1f;
				int num3 = (int)((double)val.X - num * 0.5);
				int num4 = (int)((double)val.X + num * 0.5);
				int num5 = (int)((double)val.Y - num * 0.5);
				int num6 = (int)((double)val.Y + num * 0.5);
				if (num3 < 0)
				{
					num3 = 0;
				}
				if (num4 > Main.MapWidth)
				{
					num4 = Main.MapWidth;
				}
				if (num5 < 0)
				{
					num5 = 0;
				}
				if (num6 > Main.MapHeight)
				{
					num6 = Main.MapHeight;
				}
				for (int i = num3; i < num4; i++)
				{
					for (int j = num5; j < num6; j++)
					{
						if ((double)(Math.Abs((float)i - val.X) + Math.Abs((float)j - val.Y)) < Strength * 0.5 * (1.0 + (double)Main.rand.Next(-10, 11) * 0.015))
						{
							Main.ForcePlaceTile(ID, (short)i, (short)j, IsWall: false);
						}
					}
				}
				val += val2;
				val2.X += (float)Main.rand.Next(-10, 11) * 0.05f;
				if (val2.X > 1f)
				{
					val2.X = 1f;
				}
				if (val2.X < -1f)
				{
					val2.X = -1f;
				}
			}
		}
	}

	public static void ChasmRunnerSideways(int i, int j, int direction, int steps)
	{
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		float num = steps;
		Vector2 val = default(Vector2);
		val.X = i;
		val.Y = j;
		Vector2 val2 = default(Vector2);
		val2.X = (float)Main.rand.Next(10, 21) * 0.1f * (float)direction;
		val2.Y = (float)Main.rand.Next(-10, 10) * 0.01f;
		checked
		{
			double num2 = Main.rand.Next(5) + 7;
			while (num2 > 0.0)
			{
				if (num > 0f)
				{
					num2 += (double)Main.rand.Next(3);
					num2 -= (double)Main.rand.Next(3);
					if (num2 < 7.0)
					{
						num2 = 7.0;
					}
					if (num2 > 20.0)
					{
						num2 = 20.0;
					}
					if (num == 1f && num2 < 10.0)
					{
						num2 = 10.0;
					}
				}
				else
				{
					num2 -= (double)Main.rand.Next(4);
				}
				num -= 1f;
				int num3 = (int)((double)val.X - num2 * 0.5);
				int num4 = (int)((double)val.X + num2 * 0.5);
				int num5 = (int)((double)val.Y - num2 * 0.5);
				int num6 = (int)((double)val.Y + num2 * 0.5);
				if (num3 < 0)
				{
					num3 = 0;
				}
				if (num4 > Main.MapWidth - 1)
				{
					num4 = Main.MapWidth - 1;
				}
				if (num5 < 0)
				{
					num5 = 0;
				}
				if (num6 > Main.MapHeight)
				{
					num6 = Main.MapHeight;
				}
				for (int k = num3; k < num4; k++)
				{
					for (int l = num5; l < num6; l++)
					{
						if ((double)(Math.Abs((float)k - val.X) + Math.Abs((float)l - val.Y)) < num2 * 0.5 * (1.0 + (double)Main.rand.Next(-10, 11) * 0.015))
						{
						}
					}
				}
				val += val2;
				val2.Y += (float)Main.rand.Next(-10, 10) * 0.1f;
				if (val.Y < (float)(j - 20))
				{
					val2.Y += (float)Main.rand.Next(20) * 0.01f;
				}
				if (val.Y > (float)(j + 20))
				{
					val2.Y -= (float)Main.rand.Next(20) * 0.01f;
				}
				if ((double)val2.Y < -0.5)
				{
					val2.Y = -0.5f;
				}
				if ((double)val2.Y > 0.5)
				{
					val2.Y = 0.5f;
				}
				val2.X += (float)Main.rand.Next(-10, 11) * 0.01f;
				switch (direction)
				{
				case -1:
					if ((double)val2.X > -0.5)
					{
						val2.X = -0.5f;
					}
					if (val2.X < -2f)
					{
						val2.X = -2f;
					}
					break;
				case 1:
					if ((double)val2.X < 0.5)
					{
						val2.X = 0.5f;
					}
					if (val2.X > 2f)
					{
						val2.X = 2f;
					}
					break;
				}
				num3 = (int)((double)val.X - num2 * 1.1);
				num4 = (int)((double)val.X + num2 * 1.1);
				num5 = (int)((double)val.Y - num2 * 1.1);
				num6 = (int)((double)val.Y + num2 * 1.1);
				if (num3 < 1)
				{
					num3 = 1;
				}
				if (num4 > Main.MapWidth - 1)
				{
					num4 = Main.MapWidth - 1;
				}
				if (num5 < 0)
				{
					num5 = 0;
				}
				if (num6 > Main.MapHeight)
				{
					num6 = Main.MapHeight;
				}
				for (int m = num3; m < num4; m++)
				{
					for (int n = num5; n < num6; n++)
					{
						if ((double)(Math.Abs((float)m - val.X) + Math.Abs((float)n - val.Y)) < num2 * 1.1 * (1.0 + (double)Main.rand.Next(-10, 11) * 0.015))
						{
						}
					}
				}
				for (int num7 = num3; num7 < num4; num7++)
				{
					for (int num8 = num5; num8 < num6; num8++)
					{
						if ((double)(Math.Abs((float)num7 - val.X) + Math.Abs((float)num8 - val.Y)) < num2 * 1.1 * (1.0 + (double)Main.rand.Next(-10, 11) * 0.015))
						{
							Main.ForcePlaceTile(Main.Tile[num7, num8].ID, (short)num7, (short)num8, IsWall: true);
						}
					}
				}
			}
			if (Main.rand.Next(3) == 0)
			{
				int num9 = (int)val.X;
				int num10 = (int)val.Y;
			}
		}
	}

	public static void Meteor(int x, int y, short Size)
	{
		checked
		{
			for (int i = x - Size; i < x + Size; i++)
			{
				for (int j = y - Size; j < y + Size; j++)
				{
					if (j > y + Main.rand.Next(-2, 3) - 5 && (double)(Math.Abs(x - i) + Math.Abs(y - j)) < (double)Size * 1.5 + (double)Main.rand.Next(-5, 5) && Main.Tile[i, j].ID != "Air")
					{
						Main.ForcePlaceTile("Cobblestone", (short)i, (short)j, IsWall: false);
					}
				}
			}
			Size = (short)unchecked(Size / 2);
			for (int i = x - Size; i < x + Size; i++)
			{
				for (int j = y - Size; j < y + Size; j++)
				{
					if (Main.Tile[i, j].Behind)
					{
						Main.ForcePlaceTile("Air", (short)i, (short)j, IsWall: false);
					}
				}
			}
			Size -= (short)unchecked(Size / 9);
			for (int i = x - Size; i < x + Size; i++)
			{
				for (int j = y - Size; j < y + Size; j++)
				{
					if (Main.rand.Next(10) == 0 && (double)(Math.Abs(x - i) + Math.Abs(y - j)) < (double)Size * 1.3 && Main.Tile[i, j].ID != "Air")
					{
						Main.ForcePlaceTile("Cobblestone", (short)i, (short)j, IsWall: false);
					}
				}
			}
			Size -= (short)unchecked(Size / 5);
			for (int i = x - Size; i < x + Size; i++)
			{
				for (int j = y - Size; j < y + Size; j++)
				{
					if (j > y + Main.rand.Next(-2, 3) - 5 && (double)(Math.Abs(x - i) + Math.Abs(y - j)) < (double)Size * 1.5 + (double)Main.rand.Next(-5, 5) && Main.Tile[i, j].ID != "Air")
					{
						Main.Tile[i, j].IsWall = true;
					}
				}
			}
		}
	}

	public static void GenerateWorld()
	{
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		Seed = Main.rand.Next(1, 2147483646);
		checked
		{
			for (int i = 0; i < Main.MapWidth; i++)
			{
				for (int j = 0; j < Main.MapHeight; j++)
				{
					if (Main.Tile[i, j] == null)
					{
						Main.ForcePlaceTile("Air", (short)i, (short)j, IsWall: false);
					}
				}
				for (int j = 22; j < 23; j++)
				{
					Main.ForcePlaceTile("Grass", (short)i, (short)j, IsWall: false);
				}
				for (int j = 23; j < 33; j++)
				{
					Main.ForcePlaceTile("Dirt", (short)i, (short)j, IsWall: false);
				}
				for (int j = 33; j < Main.MapHeight; j++)
				{
					Main.ForcePlaceTile("Stone", (short)i, (short)j, IsWall: false);
				}
			}
			for (int k = 0; k < Main.rand.Next(3, 7); k++)
			{
				short num = (short)Main.rand.Next(2, 98);
				GrowTree(num, 22, Main.Tile[num, 22].Position, ConsumePlayerResource: false);
			}
			for (int k = 0; k < Main.rand.Next(5, 9); k++)
			{
				CreateVein((short)Main.rand.Next(2, 98), (short)Main.rand.Next(29, Main.MapHeight), 4.0, 5, "Coal Ore");
			}
			for (int k = 0; k < Main.rand.Next(4, 6); k++)
			{
				CreateVein((short)Main.rand.Next(2, 98), (short)Main.rand.Next(34, Main.MapHeight), 4.0, 5, "Copper Ore");
			}
			Meteor(60, 25, 12);
		}
	}
}
