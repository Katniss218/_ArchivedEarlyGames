using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CraftingGod;

public class Player
{
	public Stopwatch useTime = new Stopwatch();

	public Stopwatch useAnimation = new Stopwatch();

	public EQSlot[] Inventory = new EQSlot[30];

	public EQSlot[] Armor = new EQSlot[4];

	public EQSlot[] Accessory = new EQSlot[4];

	public Item HeldItem;

	public int Health;

	public int MaxHealth;

	public int Mana = 50;

	public int MaxMana = 50;

	public int PhysicDamage;

	public int MagicDamage;

	public int Defense;

	public Rectangle CollisionBox;

	public Rectangle FallCollisionBox;

	public Vector2 Position;

	public Vector2 OldPosition;

	public Vector2 Motion;

	public Vector2 Coordinates = new Vector2(32f, 18f);

	public Texture2D[] Texture = (Texture2D[])(object)new Texture2D[2];

	public Direction Direction = Direction.Right;

	public bool CanMove;

	public Player(Vector2 Position, int Health)
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		this.Position = Position;
		this.Health = Health;
		SetDefaults();
	}

	public void SetDefaults()
	{
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		useTime.Start();
		useAnimation.Start();
		Texture[0] = Main.PlayerTexture[0];
		Texture[1] = Main.PlayerTexture[1];
		checked
		{
			for (int i = 0; i < 30; i++)
			{
				Inventory[i] = new EQSlot(PlayerInv: true);
			}
			for (int i = 0; i < 4; i++)
			{
				Armor[i] = new EQSlot(PlayerInv: true);
			}
			for (int i = 0; i < 4; i++)
			{
				Accessory[i] = new EQSlot(PlayerInv: true);
			}
			for (int i = 0; i < 10; i++)
			{
				Inventory[i].Position = new Vector2((float)(i * 49 + 10), 10f);
				Inventory[i].CollisionBox = new Rectangle((int)Inventory[i].Position.X, 10, 48, 48);
			}
			for (int i = 0; i < 10; i++)
			{
				Inventory[i + 10].Position = new Vector2((float)(i * 49 + 10), 70f);
				Inventory[i + 10].CollisionBox = new Rectangle((int)Inventory[i].Position.X, 70, 48, 48);
			}
			for (int i = 0; i < 10; i++)
			{
				Inventory[i + 20].Position = new Vector2((float)(i * 49 + 10), 119f);
				Inventory[i + 20].CollisionBox = new Rectangle((int)Inventory[i].Position.X, 119, 48, 48);
			}
			for (int i = 0; i < 4; i++)
			{
				Armor[i].Position = new Vector2(550f, (float)(i * 49 + 10));
				Armor[i].CollisionBox = new Rectangle(550, (int)Inventory[i].Position.Y, 48, 48);
			}
			for (int i = 0; i < 4; i++)
			{
				Accessory[i].Position = new Vector2(599f, (float)(i * 49 + 10));
				Accessory[i].CollisionBox = new Rectangle(599, (int)Inventory[i].Position.Y, 48, 48);
			}
			MaxHealth = Health;
		}
	}

	public void InverseMotion()
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		Motion = -Motion;
	}

	public void InverseMotionX()
	{
		Motion.X = 0f - Motion.X;
	}

	public void InverseMotionY()
	{
		Motion.Y = 0f - Motion.Y;
	}

	public bool HasItem(string ID)
	{
		for (int i = 0; i < 30; i = checked(i + 1))
		{
			if (Inventory[i].Item != null && ID == Inventory[i].Item.ID && Inventory[i].Item.Count > 0)
			{
				return true;
			}
		}
		return false;
	}

	public bool HasItem(string ID, byte Count)
	{
		byte b = 0;
		checked
		{
			for (int i = 0; i < 30; i++)
			{
				if (Inventory[i].Item != null && ID == Inventory[i].Item.ID && Inventory[i].Item.Count > 0)
				{
					b += (byte)Inventory[i].Item.Count;
				}
			}
			if (b >= Count)
			{
				return true;
			}
			return false;
		}
	}

	public short ReqItem_SlotUUID(string ID)
	{
		checked
		{
			for (int i = 0; i < 30; i++)
			{
				if (Inventory[i].Item != null && ID == Inventory[i].Item.ID && Inventory[i].Item.Count > 0)
				{
					return (short)i;
				}
			}
			return short.MaxValue;
		}
	}

	public bool HasEmptyInv()
	{
		for (int i = 0; i < 30; i = checked(i + 1))
		{
			if (Inventory[i].Item == null)
			{
				return true;
			}
		}
		return false;
	}

	public short EmptyInvUUID()
	{
		checked
		{
			for (int i = 0; i < 30; i++)
			{
				if (Inventory[i].Item == null)
				{
					return (short)i;
				}
			}
			return short.MaxValue;
		}
	}

	public void Draw()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		if (Direction == Direction.Left)
		{
			Main.spriteBatch.Draw(Texture[0], Position, Color.White);
		}
		else if (Direction == Direction.Right)
		{
			Main.spriteBatch.Draw(Texture[1], Position, Color.White);
		}
		float num = checked(Health * 100) / MaxHealth;
		float num2 = checked(Mana * 100) / MaxMana;
		Main.DrawRectangle(new Vector2(1000f, 20f), new Vector2(250f, 24f), Color.Black);
		checked
		{
			Main.spriteBatch.Draw(Main.Bar, new Vector2(1000f, 20f), (Rectangle?)new Rectangle(0, 0, (int)(num / 100f * 250f), 24), Color.Red);
			Main.DrawText(Health + "/" + MaxHealth, new Vector2(1085f, 23f), new Color(255, 210, 210));
			Main.DrawRectangle(new Vector2(1000f, 45f), new Vector2(250f, 24f), Color.Black);
			Main.spriteBatch.Draw(Main.Bar, new Vector2(1000f, 45f), (Rectangle?)new Rectangle(0, 0, (int)(num2 / 100f * 250f), 24), new Color(0, 80, 255));
			Main.DrawText(Mana + "/" + MaxMana, new Vector2(1085f, 49f), new Color(190, 220, 255));
		}
	}

	public void Update()
	{
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Unknown result type (might be due to invalid IL or missing references)
		//IL_033f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0344: Unknown result type (might be due to invalid IL or missing references)
		//IL_0349: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < 10; i = checked(i + 1))
		{
			Inventory[i].Update();
			if (Inventory[i].Item != null && Inventory[i].Item.Using && useAnimation.ElapsedMilliseconds / 10 >= Inventory[i].Item.UseAnimation)
			{
				Inventory[i].Item.Using = false;
				useAnimation.Restart();
			}
		}
		OldPosition = Position;
		CanMove = true;
		checked
		{
			CollisionBox = new Rectangle((int)Position.X + 5, (int)Position.Y, Texture[0].Width - 10, Texture[0].Height - 10);
			FallCollisionBox = new Rectangle((int)Position.X, (int)Position.Y, Texture[0].Width, Texture[0].Height);
			for (int j = 0; j < Main.MapWidth; j++)
			{
				for (int k = 0; k < Main.MapHeight; k++)
				{
					if (Main.Tile[j, k] == null || Main.Tile[j, k].Behind || Main.Tile[j, k].IsWall)
					{
						continue;
					}
					if (Collision.TileHit((short)j, (short)k, Position, Motion, new Vector2((float)Texture[0].Width, (float)Texture[0].Height)))
					{
						if (Main.Tile[j, k].CollisionBox.Y > Main.Player.FallCollisionBox.Y)
						{
							Motion.Y = -0.1f;
							CanMove = false;
						}
						else
						{
							Motion.Y = 0f;
							CanMove = false;
						}
						if (Main.Tile[j, k].CollisionBox.X < Main.Player.CollisionBox.X)
						{
							Motion.X = 0.0001f;
							CanMove = false;
						}
						else
						{
							Motion.X = -0.0001f;
							CanMove = false;
						}
					}
					if (((Rectangle)(ref Main.Tile[j, k].CollisionBox)).Intersects(CollisionBox))
					{
						InverseMotion();
					}
				}
			}
			if (CanMove)
			{
				ref Vector2 motion = ref Motion;
				motion.Y += 0.1f;
				if (Motion.Y >= 20f)
				{
					Motion.Y = 20f;
				}
			}
			Main.ScreenPosition -= Motion;
		}
	}
}
