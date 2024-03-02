using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CraftingGod;

public class Entity
{
	public Stopwatch melleimmunity = new Stopwatch();

	public short UUID = short.MaxValue;

	public string ID;

	public int Health = 50;

	public int MaxHealth = 50;

	public int Damage = 5;

	public int Defense = 5;

	public Rectangle CollisionBox;

	public Vector2 Position;

	public Vector2 OldPosition;

	public Vector2 Motion;

	public Texture2D Texture;

	public string DropID = "Cobblestone";

	public byte DropCount = 1;

	public bool MeleeImmunity = false;

	public bool a;

	public Entity(string ID, Vector2 Position)
	{
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		this.ID = ID;
		this.Position = Position;
		SetDefaults();
	}

	public void SetDefaults()
	{
		melleimmunity.Start();
		checked
		{
			if (ID == "Green Slime")
			{
				Texture = Main.MonsterTextures[0];
				Health = 16;
				Damage = 7;
				Defense = 1;
				DropID = "Slime Ball";
				DropCount = (byte)Main.rand.Next(1, 3);
			}
			if (ID == "Blue Slime")
			{
				Texture = Main.MonsterTextures[1];
				Health = 25;
				Damage = 10;
				Defense = 2;
				DropID = "Slime Ball";
				DropCount = (byte)Main.rand.Next(1, 4);
			}
			if (ID == "Yellow Slime")
			{
				Texture = Main.MonsterTextures[2];
				Health = 40;
				Damage = 12;
				Defense = 6;
				DropID = "Slime Ball";
				DropCount = (byte)Main.rand.Next(1, 4);
			}
			if (ID == "Red Slime")
			{
				Texture = Main.MonsterTextures[3];
				Health = 45;
				Damage = 17;
				Defense = 1;
				DropID = "Slime Ball";
				DropCount = (byte)Main.rand.Next(1, 3);
			}
			MaxHealth = Health;
		}
	}

	public static void Kill(short UUID)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < Main.Mob[UUID].DropCount; i = checked(i + 1))
		{
			Main.DropItem(Main.Mob[UUID].DropID, Main.Mob[UUID].Position);
		}
		Main.Mob[UUID] = null;
	}

	public void Draw()
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		if (!MeleeImmunity)
		{
			Main.spriteBatch.Draw(Texture, Position, Color.White);
		}
		else
		{
			Main.spriteBatch.Draw(Texture, Position, new Color(210, 210, 210));
		}
		float num = checked(Health * 100) / MaxHealth;
		Main.DrawRectangle(new Vector2(Position.X + (float)(Texture.Width / 2) - 15f, Position.Y - 20f), new Vector2(num / 100f * 30f, 5f), Color.Red);
		Main.DrawText(string.Concat(Health), Position, Color.Black);
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
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		if (melleimmunity.ElapsedMilliseconds >= 500)
		{
			MeleeImmunity = false;
		}
		OldPosition = Position;
		a = true;
		checked
		{
			CollisionBox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
			for (int i = 0; i < Main.MapWidth; i++)
			{
				for (int j = 0; j < Main.MapHeight; j++)
				{
					if (Main.Tile[i, j] != null && Main.Tile[i, j].ID != "Air" && Main.Tile[i, j].ID != "WoodLog" && Main.Tile[i, j].ID != "Leaves" && Main.Tile[i, j].ID != "Acorn" && ((Rectangle)(ref Main.Tile[i, j].CollisionBox)).Intersects(new Rectangle((int)(Position.X + Motion.X), (int)(Position.Y + Motion.Y), Texture.Width, Texture.Height)))
					{
						a = false;
					}
				}
			}
			if (a)
			{
				ref Vector2 motion = ref Motion;
				motion.Y += 0.1f;
				if (Motion.Y >= 20f)
				{
					Motion.Y = 20f;
				}
			}
			else
			{
				Motion.Y = 0f;
			}
			Position += Motion;
		}
	}
}
