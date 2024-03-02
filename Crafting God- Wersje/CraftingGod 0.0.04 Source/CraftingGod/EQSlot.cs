using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CraftingGod;

public class EQSlot
{
	public Vector2 Position;

	public Rectangle CollisionBox;

	public Item Item;

	public bool IsClicked = false;

	public bool PlayerInv = false;

	public EQSlot(bool PlayerInv)
	{
		this.PlayerInv = PlayerInv;
	}

	public void DrawItemInfo()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c27: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c64: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c78: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c9e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d36: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0694: Unknown result type (might be due to invalid IL or missing references)
		//IL_069f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b31: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b45: Unknown result type (might be due to invalid IL or missing references)
		//IL_0baf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bba: Unknown result type (might be due to invalid IL or missing references)
		//IL_098a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0995: Unknown result type (might be due to invalid IL or missing references)
		//IL_09bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_09de: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a04: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a99: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0840: Unknown result type (might be due to invalid IL or missing references)
		//IL_084f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0863: Unknown result type (might be due to invalid IL or missing references)
		//IL_0889: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_091e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0929: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0704: Unknown result type (might be due to invalid IL or missing references)
		//IL_072a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0739: Unknown result type (might be due to invalid IL or missing references)
		//IL_074d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0773: Unknown result type (might be due to invalid IL or missing references)
		//IL_078a: Unknown result type (might be due to invalid IL or missing references)
		//IL_079e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0808: Unknown result type (might be due to invalid IL or missing references)
		//IL_0813: Unknown result type (might be due to invalid IL or missing references)
		//IL_0519: Unknown result type (might be due to invalid IL or missing references)
		//IL_0524: Unknown result type (might be due to invalid IL or missing references)
		//IL_054a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0559: Unknown result type (might be due to invalid IL or missing references)
		//IL_056d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0593: Unknown result type (might be due to invalid IL or missing references)
		//IL_05aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_05be: Unknown result type (might be due to invalid IL or missing references)
		//IL_0628: Unknown result type (might be due to invalid IL or missing references)
		//IL_0633: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0418: Unknown result type (might be due to invalid IL or missing references)
		//IL_042f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0443: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0302: Unknown result type (might be due to invalid IL or missing references)
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_032d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0397: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a2: Unknown result type (might be due to invalid IL or missing references)
		if (Item == null || !((Rectangle)(ref CollisionBox)).Intersects(new Rectangle(((MouseState)(ref Main.MouseState)).X, ((MouseState)(ref Main.MouseState)).Y, 1, 1)))
		{
			return;
		}
		float num = checked(Item.Durability * 100) / Item.MaxDurability;
		checked
		{
			Main.DrawText(Item.ID ?? "", new Vector2((float)(((MouseState)(ref Main.MouseState)).X + 10), (float)(((MouseState)(ref Main.MouseState)).Y + 5)), new Color(0, 0, 0));
			if (Item.Damage > 0)
			{
				Main.DrawText("Damage: " + Item.Damage, new Vector2((float)(((MouseState)(ref Main.MouseState)).X + 10), (float)(((MouseState)(ref Main.MouseState)).Y + 25)), new Color(100, 100, 100));
				if (Item.Defense > 0)
				{
					Main.DrawText("Defense: " + Item.Defense, new Vector2((float)(((MouseState)(ref Main.MouseState)).X + 10), (float)(((MouseState)(ref Main.MouseState)).Y + 45)), new Color(100, 100, 100));
				}
				else if (Item.PowerPickaxe > 0)
				{
					Main.DrawText("Pickaxe Power: " + Item.PowerPickaxe, new Vector2((float)(((MouseState)(ref Main.MouseState)).X + 10), (float)(((MouseState)(ref Main.MouseState)).Y + 45)), new Color(100, 100, 100));
					if (Item.PowerAxe > 0)
					{
						Main.DrawText("Axe Power: " + Item.PowerAxe, new Vector2((float)(((MouseState)(ref Main.MouseState)).X + 10), (float)(((MouseState)(ref Main.MouseState)).Y + 65)), new Color(100, 100, 100));
						if (Item.PowerShovel > 0)
						{
							Main.DrawText("Shovel Power: " + Item.PowerShovel, new Vector2((float)(((MouseState)(ref Main.MouseState)).X + 10), (float)(((MouseState)(ref Main.MouseState)).Y + 85)), new Color(100, 100, 100));
							Main.DrawRectangle(new Vector2((float)(((MouseState)(ref Main.MouseState)).X + 8), (float)(((MouseState)(ref Main.MouseState)).Y + 105)), new Vector2(120f, 18f), new Color(150, 150, 150));
							Main.DrawRectangle(new Vector2((float)(((MouseState)(ref Main.MouseState)).X + 8), (float)(((MouseState)(ref Main.MouseState)).Y + 105)), new Vector2(num / 100f * 120f, 18f), new Color(200, 200, 200));
							Main.DrawText("Uses: " + Item.Durability + "/" + Item.MaxDurability, new Vector2((float)(((MouseState)(ref Main.MouseState)).X + 10), (float)(((MouseState)(ref Main.MouseState)).Y + 105)), new Color(100, 100, 100));
						}
						else
						{
							Main.DrawRectangle(new Vector2((float)(((MouseState)(ref Main.MouseState)).X + 8), (float)(((MouseState)(ref Main.MouseState)).Y + 85)), new Vector2(120f, 18f), new Color(150, 150, 150));
							Main.DrawRectangle(new Vector2((float)(((MouseState)(ref Main.MouseState)).X + 8), (float)(((MouseState)(ref Main.MouseState)).Y + 85)), new Vector2(num / 100f * 120f, 18f), new Color(200, 200, 200));
							Main.DrawText("Uses: " + Item.Durability + "/" + Item.MaxDurability, new Vector2((float)(((MouseState)(ref Main.MouseState)).X + 10), (float)(((MouseState)(ref Main.MouseState)).Y + 85)), new Color(100, 100, 100));
						}
					}
					else if (Item.PowerShovel > 0)
					{
						Main.DrawText("Shovel Power: " + Item.PowerShovel, new Vector2((float)(((MouseState)(ref Main.MouseState)).X + 10), (float)(((MouseState)(ref Main.MouseState)).Y + 65)), new Color(100, 100, 100));
						Main.DrawRectangle(new Vector2((float)(((MouseState)(ref Main.MouseState)).X + 8), (float)(((MouseState)(ref Main.MouseState)).Y + 85)), new Vector2(120f, 18f), new Color(150, 150, 150));
						Main.DrawRectangle(new Vector2((float)(((MouseState)(ref Main.MouseState)).X + 8), (float)(((MouseState)(ref Main.MouseState)).Y + 85)), new Vector2(num / 100f * 120f, 18f), new Color(200, 200, 200));
						Main.DrawText("Uses: " + Item.Durability + "/" + Item.MaxDurability, new Vector2((float)(((MouseState)(ref Main.MouseState)).X + 10), (float)(((MouseState)(ref Main.MouseState)).Y + 85)), new Color(100, 100, 100));
					}
				}
				else if (Item.PowerAxe > 0)
				{
					Main.DrawText("Axe Power: " + Item.PowerAxe, new Vector2((float)(((MouseState)(ref Main.MouseState)).X + 10), (float)(((MouseState)(ref Main.MouseState)).Y + 45)), new Color(100, 100, 100));
					if (Item.PowerShovel > 0)
					{
						Main.DrawText("Shovel Power: " + Item.PowerShovel, new Vector2((float)(((MouseState)(ref Main.MouseState)).X + 10), (float)(((MouseState)(ref Main.MouseState)).Y + 65)), new Color(100, 100, 100));
						Main.DrawRectangle(new Vector2((float)(((MouseState)(ref Main.MouseState)).X + 8), (float)(((MouseState)(ref Main.MouseState)).Y + 85)), new Vector2(120f, 18f), new Color(150, 150, 150));
						Main.DrawRectangle(new Vector2((float)(((MouseState)(ref Main.MouseState)).X + 8), (float)(((MouseState)(ref Main.MouseState)).Y + 85)), new Vector2(num / 100f * 120f, 18f), new Color(200, 200, 200));
						Main.DrawText("Uses: " + Item.Durability + "/" + Item.MaxDurability, new Vector2((float)(((MouseState)(ref Main.MouseState)).X + 10), (float)(((MouseState)(ref Main.MouseState)).Y + 85)), new Color(100, 100, 100));
					}
					else
					{
						Main.DrawRectangle(new Vector2((float)(((MouseState)(ref Main.MouseState)).X + 8), (float)(((MouseState)(ref Main.MouseState)).Y + 65)), new Vector2(120f, 18f), new Color(150, 150, 150));
						Main.DrawRectangle(new Vector2((float)(((MouseState)(ref Main.MouseState)).X + 8), (float)(((MouseState)(ref Main.MouseState)).Y + 65)), new Vector2(num / 100f * 120f, 18f), new Color(200, 200, 200));
						Main.DrawText("Uses: " + Item.Durability + "/" + Item.MaxDurability, new Vector2((float)(((MouseState)(ref Main.MouseState)).X + 10), (float)(((MouseState)(ref Main.MouseState)).Y + 65)), new Color(100, 100, 100));
					}
				}
				else if (Item.PowerShovel > 0)
				{
					Main.DrawText("Shovel Power: " + Item.PowerShovel, new Vector2((float)(((MouseState)(ref Main.MouseState)).X + 10), (float)(((MouseState)(ref Main.MouseState)).Y + 45)), new Color(100, 100, 100));
					Main.DrawRectangle(new Vector2((float)(((MouseState)(ref Main.MouseState)).X + 8), (float)(((MouseState)(ref Main.MouseState)).Y + 65)), new Vector2(120f, 18f), new Color(150, 150, 150));
					Main.DrawRectangle(new Vector2((float)(((MouseState)(ref Main.MouseState)).X + 8), (float)(((MouseState)(ref Main.MouseState)).Y + 65)), new Vector2(num / 100f * 120f, 18f), new Color(200, 200, 200));
					Main.DrawText("Uses: " + Item.Durability + "/" + Item.MaxDurability, new Vector2((float)(((MouseState)(ref Main.MouseState)).X + 10), (float)(((MouseState)(ref Main.MouseState)).Y + 65)), new Color(100, 100, 100));
				}
				else
				{
					Main.DrawRectangle(new Vector2((float)(((MouseState)(ref Main.MouseState)).X + 8), (float)(((MouseState)(ref Main.MouseState)).Y + 45)), new Vector2(120f, 18f), new Color(150, 150, 150));
					Main.DrawRectangle(new Vector2((float)(((MouseState)(ref Main.MouseState)).X + 8), (float)(((MouseState)(ref Main.MouseState)).Y + 45)), new Vector2(num / 100f * 120f, 18f), new Color(200, 200, 200));
					Main.DrawText("Uses: " + Item.Durability + "/" + Item.MaxDurability, new Vector2((float)(((MouseState)(ref Main.MouseState)).X + 10), (float)(((MouseState)(ref Main.MouseState)).Y + 45)), new Color(100, 100, 100));
				}
			}
			else if (Item.Defense > 0)
			{
				Main.DrawText("Defense: " + Item.Defense, new Vector2((float)(((MouseState)(ref Main.MouseState)).X + 10), (float)(((MouseState)(ref Main.MouseState)).Y + 25)), new Color(100, 100, 100));
				Main.DrawRectangle(new Vector2((float)(((MouseState)(ref Main.MouseState)).X + 8), (float)(((MouseState)(ref Main.MouseState)).Y + 45)), new Vector2(num / 100f * 120f, 18f), new Color(200, 200, 200));
				Main.DrawRectangle(new Vector2((float)(((MouseState)(ref Main.MouseState)).X + 8), (float)(((MouseState)(ref Main.MouseState)).Y + 45)), new Vector2(120f, 18f), new Color(150, 150, 150));
				Main.DrawText("Uses: " + Item.Durability + "/" + Item.MaxDurability, new Vector2((float)(((MouseState)(ref Main.MouseState)).X + 10), (float)(((MouseState)(ref Main.MouseState)).Y + 45)), new Color(100, 100, 100));
			}
		}
	}

	public void Draw()
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0677: Unknown result type (might be due to invalid IL or missing references)
		//IL_0682: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Unknown result type (might be due to invalid IL or missing references)
		//IL_035a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0371: Unknown result type (might be due to invalid IL or missing references)
		//IL_037e: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0421: Unknown result type (might be due to invalid IL or missing references)
		//IL_0438: Unknown result type (might be due to invalid IL or missing references)
		//IL_0448: Unknown result type (might be due to invalid IL or missing references)
		//IL_0486: Unknown result type (might be due to invalid IL or missing references)
		//IL_049d: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_04eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0502: Unknown result type (might be due to invalid IL or missing references)
		//IL_0512: Unknown result type (might be due to invalid IL or missing references)
		//IL_0550: Unknown result type (might be due to invalid IL or missing references)
		//IL_0567: Unknown result type (might be due to invalid IL or missing references)
		//IL_0574: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0611: Unknown result type (might be due to invalid IL or missing references)
		//IL_0628: Unknown result type (might be due to invalid IL or missing references)
		//IL_0634: Unknown result type (might be due to invalid IL or missing references)
		if (PlayerInv)
		{
			if (IsClicked)
			{
				Main.spriteBatch.Draw(Main.InventorySlot, Position, new Color(255, 255, 20, 200));
			}
			else
			{
				Main.spriteBatch.Draw(Main.InventorySlot, Position, new Color(155, 255, 0, 200));
			}
		}
		if (Item == null || !(Item.ID != ""))
		{
			return;
		}
		float num = 1f;
		if (Item.Texture.Width > 44 || Item.Texture.Height > 44)
		{
			num = ((Item.Texture.Width <= 44) ? (44f / (float)Item.Texture.Height) : (44f / (float)Item.Texture.Width));
		}
		Main.spriteBatch.Draw(Item.Texture, new Vector2(Position.X + 24f - (float)(Item.Texture.Width / 2) * num, Position.Y + 24f - (float)(Item.Texture.Height / 2) * num), (Rectangle?)new Rectangle(0, 0, Item.Texture.Width, Item.Texture.Height), Color.White, 0f, default(Vector2), num, (SpriteEffects)0, 0f);
		if (Item.MaxDurability > 1)
		{
			float num2 = checked(Item.Durability * 100) / Item.MaxDurability;
			Main.DrawRectangle(new Vector2(Position.X + 3f, Position.Y + 42f), new Vector2(42f, 3f), new Color(90, 90, 90, 185));
			if (num2 == 100f)
			{
				Main.DrawRectangle(new Vector2(Position.X + 3f, Position.Y + 42f), new Vector2(num2 / 100f * 42f, 3f), new Color(0, 255, 0));
			}
			else if (num2 >= 90f)
			{
				Main.DrawRectangle(new Vector2(Position.X + 3f, Position.Y + 42f), new Vector2(num2 / 100f * 42f, 3f), new Color(75, 250, 0));
			}
			else if (num2 >= 80f)
			{
				Main.DrawRectangle(new Vector2(Position.X + 3f, Position.Y + 42f), new Vector2(num2 / 100f * 42f, 3f), new Color(125, 240, 0));
			}
			else if (num2 >= 70f)
			{
				Main.DrawRectangle(new Vector2(Position.X + 3f, Position.Y + 42f), new Vector2(num2 / 100f * 42f, 3f), new Color(180, 230, 0));
			}
			else if (num2 >= 60f)
			{
				Main.DrawRectangle(new Vector2(Position.X + 3f, Position.Y + 42f), new Vector2(num2 / 100f * 42f, 3f), new Color(220, 220, 0));
			}
			else if (num2 >= 50f)
			{
				Main.DrawRectangle(new Vector2(Position.X + 3f, Position.Y + 42f), new Vector2(num2 / 100f * 42f, 3f), new Color(220, 220, 0));
			}
			else if (num2 >= 40f)
			{
				Main.DrawRectangle(new Vector2(Position.X + 3f, Position.Y + 42f), new Vector2(num2 / 100f * 42f, 3f), new Color(230, 180, 0));
			}
			else if (num2 >= 30f)
			{
				Main.DrawRectangle(new Vector2(Position.X + 3f, Position.Y + 42f), new Vector2(num2 / 100f * 42f, 3f), new Color(240, 125, 0));
			}
			else if (num2 >= 20f)
			{
				Main.DrawRectangle(new Vector2(Position.X + 3f, Position.Y + 42f), new Vector2(num2 / 100f * 42f, 3f), new Color(250, 75, 0));
			}
			else if (num2 >= 10f)
			{
				Main.DrawRectangle(new Vector2(Position.X + 3f, Position.Y + 42f), new Vector2(num2 / 100f * 42f, 3f), new Color(255, 0, 0));
			}
		}
		Main.DrawText(string.Concat(Item.Count), new Vector2(Position.X + 3f, Position.Y + 30f), new Color(50, 50, 50));
		Item.Draw();
		if (Item.Count < 1)
		{
			Item = null;
		}
		else if (Item.Durability <= 0)
		{
			Item = null;
		}
	}

	public void Update()
	{
		if (Item != null)
		{
			Item.UpdateItem();
		}
	}
}
