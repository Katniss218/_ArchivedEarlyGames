using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CraftingGod;

public class Item
{
	public short UUID = short.MaxValue;

	public string ID;

	public string PlacedID;

	public ItemType Type;

	public int Count = 1;

	public int MaxStack = 50;

	public int Damage;

	public int Defense;

	public int UseTime = 75;

	public bool Using = false;

	public int UseAnimation = 75;

	public byte PowerPickaxe = 0;

	public byte PowerAxe = 0;

	public byte PowerShovel = 0;

	public short Durability = 1;

	public short MaxDurability = 1;

	public byte UseStyle;

	public Texture2D Texture;

	public Vector2 PlacedSize = new Vector2(1f, 1f);

	public Item(string ID)
	{
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		this.ID = ID;
		SetDefaults();
	}

	public void SetDefaults()
	{
		//IL_0434: Unknown result type (might be due to invalid IL or missing references)
		//IL_0439: Unknown result type (might be due to invalid IL or missing references)
		//IL_048a: Unknown result type (might be due to invalid IL or missing references)
		//IL_048f: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e5: Unknown result type (might be due to invalid IL or missing references)
		if (ID == "")
		{
		}
		if (ID == "Dirt")
		{
			Texture = Main.ItemTextures[0];
			MaxStack = 75;
			Type = ItemType.Placeable;
			PlacedID = "Dirt";
		}
		if (ID == "Stone")
		{
			Texture = Main.ItemTextures[2];
			MaxStack = 75;
			Type = ItemType.Placeable;
			PlacedID = "Stone";
		}
		if (ID == "Cobblestone")
		{
			Texture = Main.ItemTextures[3];
			MaxStack = 75;
			Type = ItemType.Placeable;
			PlacedID = "Cobblestone";
		}
		if (ID == "Wood Log")
		{
			Texture = Main.ItemTextures[4];
			MaxStack = 75;
			Type = ItemType.Placeable;
			PlacedID = "Wood Log";
		}
		if (ID == "Wood Planks")
		{
			Texture = Main.ItemTextures[5];
			MaxStack = 75;
			Type = ItemType.Placeable;
			PlacedID = "Wood Planks";
		}
		if (ID == "Leaves")
		{
			Texture = Main.ItemTextures[6];
			MaxStack = 75;
			Type = ItemType.Placeable;
			PlacedID = "Leaves";
		}
		if (ID == "Acorn")
		{
			Texture = Main.ItemTextures[7];
			MaxStack = 75;
			Type = ItemType.Placeable;
			PlacedID = "Acorn";
		}
		if (ID == "Slime Ball")
		{
			Texture = Main.ItemTextures[8];
			MaxStack = 75;
			Type = ItemType.Material;
		}
		if (ID == "Wooden Dagger")
		{
			Texture = Main.ItemTextures[9];
			MaxStack = 1;
			Type = ItemType.Melee;
			Damage = 4;
			UseTime = 100;
			UseAnimation = 100;
			Durability = 100;
			UseStyle = 1;
		}
		if (ID == "Wooden Sword")
		{
			Texture = Main.ItemTextures[10];
			MaxStack = 1;
			Type = ItemType.Melee;
			Damage = 7;
			UseTime = 170;
			UseAnimation = 170;
			Durability = 100;
			UseStyle = 2;
		}
		if (ID == "Wooden Pickaxe")
		{
			Texture = Main.ItemTextures[11];
			MaxStack = 1;
			Type = ItemType.Tool;
			Damage = 4;
			UseTime = 50;
			UseAnimation = 80;
			PowerPickaxe = 10;
			Durability = 100;
			UseStyle = 2;
		}
		if (ID == "Wooden Axe")
		{
			Texture = Main.ItemTextures[12];
			MaxStack = 1;
			Type = ItemType.Tool;
			Damage = 5;
			UseTime = 50;
			UseAnimation = 120;
			PowerAxe = 10;
			Durability = 100;
			UseStyle = 2;
		}
		if (ID == "Wooden Shovel")
		{
			Texture = Main.ItemTextures[13];
			MaxStack = 1;
			Type = ItemType.Tool;
			Damage = 2;
			UseTime = 50;
			UseAnimation = 80;
			PowerShovel = 10;
			Durability = 100;
			UseStyle = 2;
		}
		if (ID == "Workbench")
		{
			Texture = Main.ItemTextures[18];
			MaxStack = 75;
			Type = ItemType.Placeable;
			PlacedSize = new Vector2(2f, 1f);
			PlacedID = "Workbench";
		}
		if (ID == "Furnace")
		{
			Texture = Main.ItemTextures[19];
			MaxStack = 75;
			Type = ItemType.Placeable;
			PlacedSize = new Vector2(3f, 2f);
			PlacedID = "Furnace";
		}
		if (ID == "Stone Anvil")
		{
			Texture = Main.ItemTextures[20];
			MaxStack = 75;
			Type = ItemType.Placeable;
			PlacedSize = new Vector2(2f, 1f);
			PlacedID = "Stone Anvil";
		}
		if (ID == "Stick")
		{
			Texture = Main.ItemTextures[21];
			MaxStack = 75;
			Type = ItemType.Material;
		}
		if (ID == "Wooden Hammer")
		{
			Texture = Main.ItemTextures[22];
			MaxStack = 1;
			Type = ItemType.Hammer;
			UseStyle = 2;
			Durability = 100;
		}
		if (ID == "Wooden Bow")
		{
			Texture = Main.ItemTextures[23];
			MaxStack = 1;
			Type = ItemType.Ranged;
			Damage = 8;
			Durability = 100;
			UseTime = 50;
			UseAnimation = 80;
			UseStyle = 1;
		}
		if (ID == "Coal")
		{
			Texture = Main.ItemTextures[24];
			MaxStack = 75;
			Type = ItemType.Placeable;
			PlacedID = "Coal Ore";
		}
		if (ID == "Copper Ore")
		{
			Texture = Main.ItemTextures[25];
			MaxStack = 75;
			Type = ItemType.Placeable;
			PlacedID = "Copper Ore";
		}
		if (ID == "Stone Sword")
		{
			Texture = Main.ItemTextures[26];
			MaxStack = 1;
			Type = ItemType.Melee;
			Damage = 11;
			UseTime = 220;
			UseAnimation = 220;
			Durability = 260;
			UseStyle = 2;
		}
		if (ID == "Stone Pickaxe")
		{
			Texture = Main.ItemTextures[27];
			MaxStack = 1;
			Type = ItemType.Tool;
			Damage = 8;
			UseTime = 50;
			UseAnimation = 180;
			PowerPickaxe = 30;
			Durability = 260;
			UseStyle = 2;
		}
		if (ID == "Stone Axe")
		{
			Texture = Main.ItemTextures[28];
			MaxStack = 1;
			Type = ItemType.Tool;
			Damage = 10;
			UseTime = 50;
			UseAnimation = 260;
			PowerAxe = 30;
			Durability = 260;
			UseStyle = 2;
		}
		if (ID == "Stone Shovel")
		{
			Texture = Main.ItemTextures[29];
			MaxStack = 1;
			Type = ItemType.Tool;
			Damage = 6;
			UseTime = 50;
			UseAnimation = 180;
			PowerShovel = 30;
			Durability = 260;
			UseStyle = 2;
		}
		if (ID == "Stone Hammer")
		{
			Texture = Main.ItemTextures[30];
			MaxStack = 1;
			Type = ItemType.Hammer;
			UseStyle = 2;
			Durability = 260;
		}
		MaxDurability = Durability;
	}

	public void Draw()
	{
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0304: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Unknown result type (might be due to invalid IL or missing references)
		//IL_032b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0344: Unknown result type (might be due to invalid IL or missing references)
		if (!(ID != "") || !Using)
		{
			return;
		}
		if (UseStyle == 1)
		{
			if (Main.Player.Direction == Direction.Left)
			{
				Main.spriteBatch.Draw(Texture, new Vector2(Main.Player.Position.X + (float)(Main.Player.Texture[0].Width / 2) - (float)Texture.Width, Main.Player.Position.Y + 10f), (Rectangle?)new Rectangle(0, 0, Texture.Width, Texture.Height), Color.White, MathHelper.ToRadians(225f), new Vector2((float)Texture.Width, (float)Texture.Height), 1f, (SpriteEffects)0, 0f);
			}
			else if (Main.Player.Direction == Direction.Right)
			{
				Main.spriteBatch.Draw(Texture, new Vector2(Main.Player.Position.X + (float)(Main.Player.Texture[1].Width / 2) + (float)Texture.Width, Main.Player.Position.Y + 10f), (Rectangle?)new Rectangle(0, 0, Texture.Width, Texture.Height), Color.White, MathHelper.ToRadians(45f), new Vector2(0f, 0f), 1f, (SpriteEffects)0, 0f);
			}
		}
		if (UseStyle == 2)
		{
			if (Main.Player.Direction == Direction.Left)
			{
				Main.spriteBatch.Draw(Texture, new Vector2(Main.Player.Position.X + (float)(Main.Player.Texture[0].Width / 2) - 5f, Main.Player.Position.Y), (Rectangle?)new Rectangle(0, 0, Texture.Width, Texture.Height), Color.White, MathHelper.ToRadians(270f), new Vector2((float)Texture.Width, (float)Texture.Height), 1f, (SpriteEffects)0, 0f);
			}
			else if (Main.Player.Direction == Direction.Right)
			{
				Main.spriteBatch.Draw(Texture, new Vector2(Main.Player.Position.X + (float)(Main.Player.Texture[1].Width / 2) + 5f, Main.Player.Position.Y), (Rectangle?)new Rectangle(0, 0, Texture.Width, Texture.Height), Color.White, MathHelper.ToRadians(0f), new Vector2(0f, 0f), 1f, (SpriteEffects)0, 0f);
			}
		}
	}

	public void UpdateItem()
	{
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		if (!Using)
		{
			return;
		}
		checked
		{
			Rectangle val = default(Rectangle);
			for (int i = 0; i < Main.MaxMobCount; i++)
			{
				if (Main.Mob[i] == null)
				{
					continue;
				}
				((Rectangle)(ref val))._002Ector(9999, 9999, 1, 1);
				if (Main.Player.Direction == Direction.Left)
				{
					((Rectangle)(ref val))._002Ector((int)Main.Player.Position.X - 35, (int)Main.Player.Position.Y, 35, 50);
				}
				else if (Main.Player.Direction == Direction.Right)
				{
					((Rectangle)(ref val))._002Ector((int)Main.Player.Position.X, (int)Main.Player.Position.Y, 35, 50);
				}
				if (((Rectangle)(ref val)).Intersects(Main.Mob[i].CollisionBox) && !Main.Mob[i].MeleeImmunity)
				{
					Main.Mob[i].Health -= Damage - unchecked(Main.Mob[i].Defense / 2);
					Main.Mob[i].MeleeImmunity = true;
					Durability--;
					Main.Mob[i].melleimmunity.Restart();
					if (Main.Mob[i].Health <= 0)
					{
						Entity.Kill((short)i);
					}
				}
			}
		}
	}
}
