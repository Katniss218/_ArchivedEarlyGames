using Microsoft.Xna.Framework;

namespace CraftingGod;

public class EntityItem
{
	public short UUID = short.MaxValue;

	public Rectangle CollisionBox;

	public Vector2 Position;

	public Vector2 Motion;

	public Item Item;

	public bool CanMove;

	public EntityItem(string ID, Vector2 Position)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		Item = new Item(ID);
		this.Position = Position;
		SetDefaults();
	}

	public void SetDefaults()
	{
	}

	public void Draw()
	{
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		if (Item.ID != "")
		{
			Main.spriteBatch.Draw(Item.Texture, checked(new Rectangle((int)(Position.X + Main.ScreenPosition.X), (int)(Position.Y + Main.ScreenPosition.Y), Item.Texture.Width, Item.Texture.Height)), new Color(220, 220, 220));
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
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		if (!(Item.ID != ""))
		{
			return;
		}
		CanMove = true;
		checked
		{
			CollisionBox = new Rectangle((int)(Position.X + Main.ScreenPosition.X), (int)(Position.Y + 1f + Main.ScreenPosition.Y), Item.Texture.Width, Item.Texture.Height - 1);
			for (int i = 0; i < Main.MapWidth; i++)
			{
				for (int j = 0; j < Main.MapHeight; j++)
				{
					if (Main.Tile[i, j] != null && Main.Tile[i, j].ID != "Air" && ((Rectangle)(ref Main.Tile[i, j].CollisionBox)).Intersects(CollisionBox))
					{
						CanMove = false;
						ref Vector2 position = ref Position;
						position.Y -= 0.25f;
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
			else
			{
				Motion.Y = 0f;
			}
			if (((Rectangle)(ref Main.Player.CollisionBox)).Intersects(CollisionBox))
			{
				for (int k = 0; k < 30; k++)
				{
					if (Main.Player.Inventory[k].Item != null)
					{
						if (Main.Player.Inventory[k].Item.ID == Item.ID && Main.Player.Inventory[k].Item.Count < Main.Player.Inventory[k].Item.MaxStack)
						{
							Main.Player.Inventory[k].Item.Count++;
							Main.DeleteItem(UUID);
							k = 999999;
						}
					}
					else
					{
						Main.Player.Inventory[k].Item = new Item(Item.ID);
						Main.DeleteItem(UUID);
						k = 999999;
					}
				}
			}
			Position += Motion;
		}
	}
}
