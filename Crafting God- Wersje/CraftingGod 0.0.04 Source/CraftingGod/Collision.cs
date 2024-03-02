using Microsoft.Xna.Framework;

namespace CraftingGod;

public class Collision
{
	public static bool TileHit(short UUIDx, short UUIDy, Vector2 Position, Vector2 Size)
	{
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		if (!Main.Tile[UUIDx, UUIDy].Behind && !Main.Tile[UUIDx, UUIDy].IsWall && Main.Tile[UUIDx, UUIDy].ID != "Air")
		{
			Rectangle val = checked(new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y));
			if (((Rectangle)(ref val)).Intersects(Main.Tile[UUIDx, UUIDy].CollisionBox))
			{
				return true;
			}
		}
		return false;
	}

	public static bool TileHit(short UUIDx, short UUIDy, Vector2 Position, Vector2 Motion, Vector2 Size)
	{
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		if (!Main.Tile[UUIDx, UUIDy].Behind && !Main.Tile[UUIDx, UUIDy].IsWall && Main.Tile[UUIDx, UUIDy].ID != "Air")
		{
			Rectangle val = checked(new Rectangle((int)(Position.X + Motion.X), (int)(Position.Y + Motion.Y), (int)Size.X, (int)Size.Y));
			if (((Rectangle)(ref val)).Intersects(Main.Tile[UUIDx, UUIDy].CollisionBox))
			{
				return true;
			}
		}
		return false;
	}
}
