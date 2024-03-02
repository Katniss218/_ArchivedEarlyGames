using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace CraftingGod;

public class Tile
{
	public short UUIDx = short.MaxValue;

	public short UUIDy = short.MaxValue;

	public string ID;

	public string DropID;

	public int HitPoints = 1;

	public int MaxHitPoints = 1;

	public Tool Tool = Tool.Pickaxe;

	public Vector2 Position;

	public Rectangle CollisionBox;

	public Texture2D Texture;

	public SoundEffect DigSound = Main.TileHitSounds[1];

	public bool IsWall = false;

	public bool Behind = false;

	public Vector2 Size = new Vector2(1f, 1f);

	public Tile(string ID, Vector2 Position, bool IsWall)
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		this.ID = ID;
		this.Position = Position;
		this.IsWall = IsWall;
		SetDefaults();
	}

	public void SetDefaults()
	{
		//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_034b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0350: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b7: Unknown result type (might be due to invalid IL or missing references)
		if (ID == "Air")
		{
			Behind = true;
		}
		if (ID == "Dirt")
		{
			Texture = Main.TileTextures[0];
			HitPoints = 3;
			DropID = "Dirt";
			Tool = Tool.Shovel;
			DigSound = Main.TileHitSounds[0];
		}
		if (ID == "Grass")
		{
			Texture = Main.TileTextures[1];
			HitPoints = 3;
			DropID = "Dirt";
			Tool = Tool.Shovel;
			DigSound = Main.TileHitSounds[0];
		}
		if (ID == "Stone")
		{
			Texture = Main.TileTextures[2];
			HitPoints = 10;
			DropID = "Cobblestone";
			Tool = Tool.Pickaxe;
			DigSound = Main.TileHitSounds[2];
		}
		if (ID == "Cobblestone")
		{
			Texture = Main.TileTextures[3];
			HitPoints = 7;
			DropID = "Cobblestone";
			Tool = Tool.Pickaxe;
			DigSound = Main.TileHitSounds[2];
		}
		if (ID == "Wood Log")
		{
			Texture = Main.TileTextures[4];
			HitPoints = 5;
			DropID = "Wood Log";
			Tool = Tool.Axe;
			Behind = true;
			DigSound = Main.TileHitSounds[1];
		}
		if (ID == "Wood Planks")
		{
			Texture = Main.TileTextures[5];
			HitPoints = 4;
			DropID = "Wood Planks";
			Tool = Tool.Axe;
			DigSound = Main.TileHitSounds[1];
		}
		if (ID == "Leaves")
		{
			Texture = Main.TileTextures[6];
			HitPoints = 1;
			DropID = "Stick";
			Tool = Tool.Axe;
			Behind = true;
			DigSound = Main.TileHitSounds[3];
		}
		if (ID == "Acorn")
		{
			Texture = Main.TileTextures[7];
			HitPoints = 1;
			DropID = "Acorn";
			Tool = Tool.Axe;
			Behind = true;
			DigSound = Main.TileHitSounds[3];
		}
		if (ID == "Workbench")
		{
			Texture = Main.ItemTextures[18];
			HitPoints = 4;
			DropID = "Workbench";
			Tool = Tool.Axe;
			Size = new Vector2(2f, 1f);
			Behind = true;
			DigSound = Main.TileHitSounds[1];
		}
		if (ID == "Furnace")
		{
			Texture = Main.ItemTextures[19];
			HitPoints = 9;
			DropID = "Furnace";
			Tool = Tool.Pickaxe;
			Size = new Vector2(3f, 2f);
			Behind = true;
			DigSound = Main.TileHitSounds[2];
		}
		if (ID == "Stone Anvil")
		{
			Texture = Main.ItemTextures[20];
			HitPoints = 11;
			DropID = "Stone Anvil";
			Tool = Tool.Pickaxe;
			Size = new Vector2(2f, 1f);
			Behind = true;
			DigSound = Main.TileHitSounds[2];
		}
		if (ID == "Coal Ore")
		{
			Texture = Main.TileTextures[8];
			HitPoints = 13;
			DropID = "Coal";
			Tool = Tool.Pickaxe;
			DigSound = Main.TileHitSounds[2];
		}
		if (ID == "Copper Ore")
		{
			Texture = Main.TileTextures[9];
			HitPoints = 15;
			DropID = "Copper Ore";
			Tool = Tool.Pickaxe;
			DigSound = Main.TileHitSounds[2];
		}
		MaxHitPoints = HitPoints;
		CollisionBox = checked(new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X * 20, (int)Size.Y * 20));
	}

	public void Hit(int Power)
	{
		DigSound.Play();
		checked
		{
			HitPoints -= Power;
			if (HitPoints < 1)
			{
				WorldGenerator.DigTile(UUIDx, UUIDy);
			}
		}
	}

	public string TileAbove()
	{
		checked
		{
			if (Main.Tile[UUIDx, UUIDy - 1] != null)
			{
				return Main.Tile[UUIDx, UUIDy - 1].ID;
			}
			return "";
		}
	}

	public string TileBelow()
	{
		checked
		{
			if (Main.Tile[UUIDx, UUIDy + 1] != null)
			{
				return Main.Tile[UUIDx, UUIDy + 1].ID;
			}
			return "";
		}
	}

	public string TileLeft()
	{
		checked
		{
			if (Main.Tile[UUIDx - 1, UUIDy] != null)
			{
				return Main.Tile[UUIDx - 1, UUIDy].ID;
			}
			return "";
		}
	}

	public string TileRight()
	{
		checked
		{
			if (Main.Tile[UUIDx + 1, UUIDy] != null)
			{
				return Main.Tile[UUIDx + 1, UUIDy].ID;
			}
			return "";
		}
	}

	public void Draw()
	{
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0311: Unknown result type (might be due to invalid IL or missing references)
		//IL_031d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0327: Unknown result type (might be due to invalid IL or missing references)
		//IL_0397: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_041d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0429: Unknown result type (might be due to invalid IL or missing references)
		//IL_0433: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04af: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0529: Unknown result type (might be due to invalid IL or missing references)
		//IL_0538: Unknown result type (might be due to invalid IL or missing references)
		//IL_0542: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_063e: Unknown result type (might be due to invalid IL or missing references)
		//IL_064d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0657: Unknown result type (might be due to invalid IL or missing references)
		if (!(ID != "Air"))
		{
			return;
		}
		checked
		{
			if (!IsWall)
			{
				Main.spriteBatch.Draw(Texture, new Rectangle((int)((float)(UUIDx * 20) + Main.ScreenPosition.X), (int)((float)(UUIDy * 20) + Main.ScreenPosition.Y), (int)Size.X * 20, (int)Size.Y * 20), Color.White);
			}
			else
			{
				Main.spriteBatch.Draw(Texture, new Rectangle((int)((float)(UUIDx * 20) + Main.ScreenPosition.X), (int)((float)(UUIDy * 20) + Main.ScreenPosition.Y), (int)Size.X * 20, (int)Size.Y * 20), new Color(100, 100, 100));
			}
		}
		float num = checked(HitPoints * 100) / MaxHitPoints;
		checked
		{
			if (num != 100f)
			{
				if (num >= 90f)
				{
					Main.spriteBatch.Draw(Main.TileDestroyVisual, new Rectangle((int)((float)(UUIDx * 20) + Main.ScreenPosition.X), (int)((float)(UUIDy * 20) + Main.ScreenPosition.Y), (int)Size.X * 20, (int)Size.Y * 20), (Rectangle?)new Rectangle(0, 0, 20, 20), Color.White);
				}
				else if (num >= 80f)
				{
					Main.spriteBatch.Draw(Main.TileDestroyVisual, new Rectangle((int)((float)(UUIDx * 20) + Main.ScreenPosition.X), (int)((float)(UUIDy * 20) + Main.ScreenPosition.Y), (int)Size.X * 20, (int)Size.Y * 20), (Rectangle?)new Rectangle(20, 0, 20, 20), Color.White);
				}
				else if (num >= 70f)
				{
					Main.spriteBatch.Draw(Main.TileDestroyVisual, new Rectangle((int)((float)(UUIDx * 20) + Main.ScreenPosition.X), (int)((float)(UUIDy * 20) + Main.ScreenPosition.Y), (int)Size.X * 20, (int)Size.Y * 20), (Rectangle?)new Rectangle(40, 0, 20, 20), Color.White);
				}
				else if (num >= 60f)
				{
					Main.spriteBatch.Draw(Main.TileDestroyVisual, new Rectangle((int)((float)(UUIDx * 20) + Main.ScreenPosition.X), (int)((float)(UUIDy * 20) + Main.ScreenPosition.Y), (int)Size.X * 20, (int)Size.Y * 20), (Rectangle?)new Rectangle(60, 0, 20, 20), Color.White);
				}
				else if (num >= 50f)
				{
					Main.spriteBatch.Draw(Main.TileDestroyVisual, new Rectangle((int)((float)(UUIDx * 20) + Main.ScreenPosition.X), (int)((float)(UUIDy * 20) + Main.ScreenPosition.Y), (int)Size.X * 20, (int)Size.Y * 20), (Rectangle?)new Rectangle(80, 0, 20, 20), Color.White);
				}
				else if (num >= 40f)
				{
					Main.spriteBatch.Draw(Main.TileDestroyVisual, new Rectangle((int)((float)(UUIDx * 20) + Main.ScreenPosition.X), (int)((float)(UUIDy * 20) + Main.ScreenPosition.Y), (int)Size.X * 20, (int)Size.Y * 20), (Rectangle?)new Rectangle(100, 0, 20, 20), Color.White);
				}
				else if (num >= 30f)
				{
					Main.spriteBatch.Draw(Main.TileDestroyVisual, new Rectangle((int)((float)(UUIDx * 20) + Main.ScreenPosition.X), (int)((float)(UUIDy * 20) + Main.ScreenPosition.Y), (int)Size.X * 20, (int)Size.Y * 20), (Rectangle?)new Rectangle(120, 0, 20, 20), Color.White);
				}
				else if (num >= 20f)
				{
					Main.spriteBatch.Draw(Main.TileDestroyVisual, new Rectangle((int)((float)(UUIDx * 20) + Main.ScreenPosition.X), (int)((float)(UUIDy * 20) + Main.ScreenPosition.Y), (int)Size.X * 20, (int)Size.Y * 20), (Rectangle?)new Rectangle(140, 0, 20, 20), Color.White);
				}
				else if (num >= 10f)
				{
					Main.spriteBatch.Draw(Main.TileDestroyVisual, new Rectangle((int)((float)(UUIDx * 20) + Main.ScreenPosition.X), (int)((float)(UUIDy * 20) + Main.ScreenPosition.Y), (int)Size.X * 20, (int)Size.Y * 20), (Rectangle?)new Rectangle(160, 0, 20, 20), Color.White);
				}
				else if (num > 0f)
				{
					Main.spriteBatch.Draw(Main.TileDestroyVisual, new Rectangle((int)((float)(UUIDx * 20) + Main.ScreenPosition.X), (int)((float)(UUIDy * 20) + Main.ScreenPosition.Y), (int)Size.X * 20, (int)Size.Y * 20), (Rectangle?)new Rectangle(180, 0, 20, 20), Color.White);
				}
			}
		}
	}

	public void ChangePosition(Vector2 Motion)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		Position -= Motion;
	}

	public void Update()
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		CollisionBox = checked(new Rectangle((int)((float)(UUIDx * 20) + Main.ScreenPosition.X), (int)((float)(UUIDy * 20) + Main.ScreenPosition.Y), (int)Size.X * 20, (int)Size.Y * 20));
	}
}
