using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CraftingGod;

public class Projectile
{
	public short UUID = short.MaxValue;

	public string ID;

	public int Damage = 5;

	public Rectangle CollisionBox;

	public Vector2 Position;

	public Vector2 OldPosition;

	public Vector2 Velocity;

	public Texture2D Texture;

	public float Rotation;

	public bool TileColliding;

	public bool NoGravity = true;

	public bool IsPlayer = true;

	public Direction Heading = Direction.Left;

	public Projectile(string ID, int Damage, Vector2 Position, Vector2 Velocity, bool IsPlayer)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		this.ID = ID;
		this.Damage = Damage;
		this.Position = Position;
		this.Velocity = Velocity;
		this.IsPlayer = IsPlayer;
		SetDefaults();
	}

	public void SetDefaults()
	{
		if (ID == "Wooden Arrow")
		{
			Texture = Main.ProjectileTextures[0];
			NoGravity = false;
		}
	}

	public static void Kill(short UUID)
	{
		Main.Projectile[UUID] = null;
	}

	public void Draw()
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		Main.spriteBatch.Draw(Texture, new Vector2(Position.X + Main.ScreenPosition.X, Position.Y + Main.ScreenPosition.Y), (Rectangle?)new Rectangle(0, 0, Texture.Width, Texture.Height), Color.White, Rotation, new Vector2((float)Texture.Width, (float)Texture.Height), 1f, (SpriteEffects)0, 0f);
	}

	public void PreKill()
	{
	}

	public void AI()
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		if (Velocity.X > 0f)
		{
			Heading = Direction.Right;
		}
		if (Velocity.X < 0f)
		{
			Heading = Direction.Left;
		}
		OldPosition = Position;
		TileColliding = false;
		if (!NoGravity)
		{
			if (Heading == Direction.Right)
			{
				if ((double)Velocity.X >= 0.03)
				{
					ref Vector2 velocity = ref Velocity;
					velocity.X -= 0.001f;
				}
				ref Vector2 velocity2 = ref Velocity;
				velocity2.Y += 0.045f;
			}
			if (Heading == Direction.Left)
			{
				if ((double)Velocity.X <= 0.03)
				{
					ref Vector2 velocity3 = ref Velocity;
					velocity3.X += 0.001f;
				}
				ref Vector2 velocity4 = ref Velocity;
				velocity4.Y += 0.045f;
			}
		}
		checked
		{
			CollisionBox = new Rectangle((int)(Position.X + Main.ScreenPosition.X), (int)(Position.Y + Main.ScreenPosition.Y), 5, 5);
			Rotation = (float)Math.Atan2(Velocity.Y, Velocity.X) + 1.57f;
			for (int i = 0; i < Main.MapWidth; i++)
			{
				for (int j = 0; j < Main.MapHeight; j++)
				{
					if (Main.Tile[i, j] != null && !Main.Tile[i, j].Behind && !Main.Tile[i, j].IsWall && ((Rectangle)(ref Main.Tile[i, j].CollisionBox)).Intersects(CollisionBox))
					{
						TileColliding = true;
					}
				}
			}
			if (IsPlayer)
			{
				for (int k = 0; k < Main.MaxMobCount; k++)
				{
					if (Main.Mob[k] != null && ((Rectangle)(ref Main.Mob[k].CollisionBox)).Intersects(CollisionBox))
					{
						Main.Mob[k].Health -= Damage - unchecked(Main.Mob[k].Defense / 2);
						PreKill();
						Kill(UUID);
						if (Main.Mob[k].Health < 1)
						{
							Entity.Kill((short)k);
						}
					}
				}
			}
			if (!TileColliding)
			{
				Position += Velocity;
				return;
			}
			PreKill();
			Kill(UUID);
		}
	}
}
