using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CraftingGod;

internal class Main : Game
{
	public const string Version = "0.0.02 Pre-Alpha";

	public const string SettingsFile = "Settings.UCF";

	public const string PlayerFile = "Player.UCF";

	public const string WorldFile = "World.UCF";

	public static bool cos;

	public static double FPS;

	public static short MaxMobCount = 200;

	public static short MaxItemCount = 300;

	public static short MaxProjectileCount = 50;

	public static short MaxRecipeCount = 25;

	public static short MapHeight = 60;

	public static short MapWidth = 100;

	public static Vector2 ScreenPosition = new Vector2(0f, 0f);

	public static byte ActiveSlot = 0;

	public static bool InventoryOpen = false;

	public static Random rand = new Random();

	public static GameState GameState = GameState.Playing;

	private GraphicsDeviceManager graphicsDevice;

	public static SpriteBatch spriteBatch;

	public static KeyboardState KeyboardState;

	private KeyboardState OldKeyboardState;

	public static MouseState MouseState;

	private MouseState OldMouseState;

	public static SpriteFont Font;

	public static Texture2D InventorySlot;

	public static Texture2D Bar;

	public static Texture2D WorkbenchGui;

	public static Texture2D FurnaceGui;

	public static Texture2D AnvilGui;

	public static Texture2D Cursor;

	public static Texture2D CursorTile;

	public static Texture2D SocketTexture;

	public static Texture2D[] PlayerTexture = (Texture2D[])(object)new Texture2D[2];

	public static Texture2D[] ItemTextures = (Texture2D[])(object)new Texture2D[35];

	public static Texture2D[] TileTextures = (Texture2D[])(object)new Texture2D[15];

	public static Texture2D TileDestroyVisual;

	public static Texture2D[] MonsterTextures = (Texture2D[])(object)new Texture2D[5];

	public static Texture2D[] ProjectileTextures = (Texture2D[])(object)new Texture2D[5];

	public static Texture2D UncolouredPixel;

	public static SoundEffect[] TileHitSounds = (SoundEffect[])(object)new SoundEffect[5];

	public static Recipe[] recipe;

	public static Player Player;

	public static EntityItem[] Item;

	public static Projectile[] Projectile;

	public static Entity[] Mob;

	public static Tile[,] Tile;

	public static string UsingTileID;

	public static EQSlot[] UsingTileInventory;

	public static void SaveWorld()
	{
		checked
		{
			using BinaryWriter binaryWriter = new BinaryWriter(File.Open("World.UCF", FileMode.Create));
			for (int i = 0; i < MapWidth; i++)
			{
				for (int j = 0; j < MapHeight; j++)
				{
					if (Tile[i, j] != null)
					{
						binaryWriter.Write(Tile[i, j].ID);
						binaryWriter.Write(Tile[i, j].IsWall);
					}
					else
					{
						binaryWriter.Write("NULL");
					}
				}
			}
		}
	}

	public static void LoadWorld()
	{
		if (!File.Exists("World.UCF"))
		{
			return;
		}
		checked
		{
			for (int i = 0; i < MaxItemCount; i++)
			{
				Item[i] = null;
			}
			for (int i = 0; i < MaxMobCount; i++)
			{
				Mob[i] = null;
			}
			for (int i = 0; i < MaxProjectileCount; i++)
			{
				Projectile[i] = null;
			}
			using BinaryReader binaryReader = new BinaryReader(File.Open("World.UCF", FileMode.Open));
			for (int j = 0; j < MapWidth; j++)
			{
				for (int k = 0; k < MapHeight; k++)
				{
					Tile[j, k] = null;
					string text = binaryReader.ReadString();
					if (text != "NULL")
					{
						ForcePlaceTile(text, (short)j, (short)k, binaryReader.ReadBoolean());
					}
				}
			}
		}
	}

	public static void SavePlayer()
	{
		using BinaryWriter binaryWriter = new BinaryWriter(File.Open("Player.UCF", FileMode.Create));
		for (int i = 0; i < 30; i = checked(i + 1))
		{
			if (Player.Inventory[i].Item != null)
			{
				binaryWriter.Write(Player.Inventory[i].Item.ID);
				binaryWriter.Write(Player.Inventory[i].Item.Count);
				binaryWriter.Write(Player.Inventory[i].Item.Durability);
			}
			else
			{
				binaryWriter.Write("NULL");
			}
		}
	}

	public static void LoadPlayer()
	{
		if (!File.Exists("Player.UCF"))
		{
			return;
		}
		using BinaryReader binaryReader = new BinaryReader(File.Open("Player.UCF", FileMode.Open));
		for (int i = 0; i < 30; i = checked(i + 1))
		{
			Player.Inventory[i].Item = null;
			string text = binaryReader.ReadString();
			if (text != "NULL")
			{
				Player.Inventory[i].Item = new Item(text);
				Player.Inventory[i].Item.Count = binaryReader.ReadInt32();
				Player.Inventory[i].Item.Durability = binaryReader.ReadInt16();
			}
		}
	}

	public static bool MouseLeftClicked()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		if ((int)((MouseState)(ref MouseState)).LeftButton == 1)
		{
			return true;
		}
		return false;
	}

	public static bool MouseRightClicked()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		if ((int)((MouseState)(ref MouseState)).RightButton == 1)
		{
			return true;
		}
		return false;
	}

	public static void SpawnMob(string ID, Vector2 Position)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			for (int i = 0; i < MaxMobCount; i++)
			{
				if (Mob[i] == null)
				{
					Mob[i] = new Entity(ID, Position);
					Mob[i].UUID = (short)i;
					i = 999999;
				}
			}
		}
	}

	public static void ForcePlaceTile(string ID, short x, short y, bool IsWall)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		Tile[x, y] = null;
		Tile[x, y] = new Tile(ID, checked(new Vector2((float)(x * 20) + ScreenPosition.X, (float)(y * 20) + ScreenPosition.Y)), IsWall);
		Tile[x, y].UUIDx = x;
		Tile[x, y].UUIDy = y;
	}

	public static void DeleteItem(short UUID)
	{
		Item[UUID] = null;
	}

	public static void DropItem(string ID, Vector2 Position)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		if (!(ID != ""))
		{
			return;
		}
		for (int i = 0; i < MaxItemCount; i = checked(i + 1))
		{
			if (Item[i] == null)
			{
				Item[i] = new EntityItem(ID, Position);
				i = 999999;
			}
		}
	}

	public static void PickItem(byte InventorySlot)
	{
		if (Player.HeldItem == null && Player.Inventory[InventorySlot].Item != null)
		{
			Player.HeldItem = Player.Inventory[InventorySlot].Item;
		}
	}

	public static void LeaveItem(byte InventorySlot)
	{
		if (Player.HeldItem != null && Player.Inventory[InventorySlot].Item == null)
		{
			Player.Inventory[InventorySlot].Item = Player.HeldItem;
		}
	}

	public static void DrawRectangle(Vector2 Position, Vector2 Size, Color Color)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		spriteBatch.Draw(UncolouredPixel, checked(new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y)), Color);
	}

	public static void DrawText(string Text, Vector2 Position, Color Color)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		spriteBatch.DrawString(Font, Text, Position, Color);
	}

	public Main()
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected O, but got Unknown
		graphicsDevice = new GraphicsDeviceManager((Game)(object)this);
		((Game)this).Content.RootDirectory = "Content";
		graphicsDevice.PreferredBackBufferWidth = 1280;
		graphicsDevice.PreferredBackBufferHeight = 744;
		((Game)this).Window.Title = "Crafting God v0.0.02 Pre-Alpha";
	}

	protected override void Initialize()
	{
		((Game)this).Initialize();
	}

	protected override void LoadContent()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		//IL_0585: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05df: Unknown result type (might be due to invalid IL or missing references)
		//IL_060c: Unknown result type (might be due to invalid IL or missing references)
		//IL_064c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0672: Unknown result type (might be due to invalid IL or missing references)
		//IL_0681: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ee: Unknown result type (might be due to invalid IL or missing references)
		spriteBatch = new SpriteBatch(((Game)this).GraphicsDevice);
		Font = ((Game)this).Content.Load<SpriteFont>("czcionka");
		UncolouredPixel = ((Game)this).Content.Load<Texture2D>("sprite_1x1WhitePixel");
		InventorySlot = ((Game)this).Content.Load<Texture2D>("Slot");
		Bar = ((Game)this).Content.Load<Texture2D>("Bar");
		WorkbenchGui = ((Game)this).Content.Load<Texture2D>("Gui_Workbench");
		FurnaceGui = ((Game)this).Content.Load<Texture2D>("Gui_Furnace");
		AnvilGui = ((Game)this).Content.Load<Texture2D>("Gui_Anvil");
		Cursor = ((Game)this).Content.Load<Texture2D>("Cursor");
		CursorTile = ((Game)this).Content.Load<Texture2D>("CursorBlock");
		TileDestroyVisual = ((Game)this).Content.Load<Texture2D>("TileDestroyVisual");
		PlayerTexture[0] = ((Game)this).Content.Load<Texture2D>("HumanLeft");
		PlayerTexture[1] = ((Game)this).Content.Load<Texture2D>("HumanRight");
		ItemTextures[0] = ((Game)this).Content.Load<Texture2D>("Dirt_Item");
		TileTextures[0] = ((Game)this).Content.Load<Texture2D>("Dirt");
		ItemTextures[1] = ((Game)this).Content.Load<Texture2D>("Grass_Item");
		TileTextures[1] = ((Game)this).Content.Load<Texture2D>("Grass");
		ItemTextures[2] = ((Game)this).Content.Load<Texture2D>("Stone_Item");
		TileTextures[2] = ((Game)this).Content.Load<Texture2D>("Stone");
		ItemTextures[3] = ((Game)this).Content.Load<Texture2D>("Cobblestone_Item");
		TileTextures[3] = ((Game)this).Content.Load<Texture2D>("Cobblestone");
		ItemTextures[4] = ((Game)this).Content.Load<Texture2D>("Log_Item");
		TileTextures[4] = ((Game)this).Content.Load<Texture2D>("Log");
		ItemTextures[5] = ((Game)this).Content.Load<Texture2D>("WoodPlanks_Item");
		TileTextures[5] = ((Game)this).Content.Load<Texture2D>("WoodPlanks");
		ItemTextures[6] = ((Game)this).Content.Load<Texture2D>("Leaves_Item");
		TileTextures[6] = ((Game)this).Content.Load<Texture2D>("Leaves");
		ItemTextures[7] = ((Game)this).Content.Load<Texture2D>("Acorn_Item");
		TileTextures[7] = ((Game)this).Content.Load<Texture2D>("Acorn");
		ItemTextures[8] = ((Game)this).Content.Load<Texture2D>("SlimeBall");
		ItemTextures[9] = ((Game)this).Content.Load<Texture2D>("WoodenDagger");
		ItemTextures[10] = ((Game)this).Content.Load<Texture2D>("WoodenSword");
		ItemTextures[11] = ((Game)this).Content.Load<Texture2D>("WoodenPickaxe");
		ItemTextures[12] = ((Game)this).Content.Load<Texture2D>("WoodenAxe");
		ItemTextures[13] = ((Game)this).Content.Load<Texture2D>("WoodenShovel");
		ItemTextures[18] = ((Game)this).Content.Load<Texture2D>("WorkBench");
		ItemTextures[19] = ((Game)this).Content.Load<Texture2D>("Furnace");
		ItemTextures[20] = ((Game)this).Content.Load<Texture2D>("StoneAnvil");
		ItemTextures[21] = ((Game)this).Content.Load<Texture2D>("Stick");
		ItemTextures[22] = ((Game)this).Content.Load<Texture2D>("WoodenHammer");
		ItemTextures[23] = ((Game)this).Content.Load<Texture2D>("WoodenBow");
		ItemTextures[24] = ((Game)this).Content.Load<Texture2D>("Coal_Item");
		ItemTextures[25] = ((Game)this).Content.Load<Texture2D>("CopperOre_Item");
		TileTextures[8] = ((Game)this).Content.Load<Texture2D>("CoalOre");
		TileTextures[9] = ((Game)this).Content.Load<Texture2D>("CopperOre");
		ItemTextures[26] = ((Game)this).Content.Load<Texture2D>("StoneSword");
		ItemTextures[27] = ((Game)this).Content.Load<Texture2D>("StonePickaxe");
		ItemTextures[28] = ((Game)this).Content.Load<Texture2D>("StoneAxe");
		ItemTextures[29] = ((Game)this).Content.Load<Texture2D>("WoodenShovel");
		ItemTextures[30] = ((Game)this).Content.Load<Texture2D>("StoneHammer");
		MonsterTextures[0] = ((Game)this).Content.Load<Texture2D>("GreenSlime");
		MonsterTextures[1] = ((Game)this).Content.Load<Texture2D>("BlueSlime");
		MonsterTextures[2] = ((Game)this).Content.Load<Texture2D>("YellowSlime");
		MonsterTextures[3] = ((Game)this).Content.Load<Texture2D>("RedSlime");
		ProjectileTextures[0] = ((Game)this).Content.Load<Texture2D>("Projectile_WoodenArrow");
		SocketTexture = ((Game)this).Content.Load<Texture2D>("SocketEmpty");
		Player.Texture = PlayerTexture;
		TileHitSounds[0] = ((Game)this).Content.Load<SoundEffect>("sound_Dirt");
		TileHitSounds[1] = ((Game)this).Content.Load<SoundEffect>("sound_Wood");
		TileHitSounds[2] = ((Game)this).Content.Load<SoundEffect>("sound_Stone");
		TileHitSounds[3] = ((Game)this).Content.Load<SoundEffect>("sound_Leaves");
		Recipe.SetupRecipes();
		Item[0] = new EntityItem("Workbench", new Vector2(640f, 372f));
		Item[0].UUID = 0;
		Item[1] = new EntityItem("Wooden Dagger", new Vector2(640f, 372f));
		Item[1].UUID = 1;
		Item[2] = new EntityItem("Wooden Axe", new Vector2(640f, 372f));
		Item[2].UUID = 2;
		Item[3] = new EntityItem("Wooden Bow", new Vector2(640f, 372f));
		Item[3].UUID = 3;
		Player.Inventory[0].IsClicked = true;
		Tile[1, 1] = new Tile("Stone", new Vector2(20f, 20f), IsWall: false);
		Projectile[0] = new Projectile("Wooden Arrow", 5, new Vector2(50f, 50f), new Vector2(0f, -0.5f), IsPlayer: true);
		WorldGenerator.GenerateWorld();
		for (int i = 0; i < 15; i = checked(i + 1))
		{
			UsingTileInventory[i] = new EQSlot(PlayerInv: false);
			UsingTileInventory[i].Item = new Item("");
			UsingTileInventory[i].Position = new Vector2(9999f, 9999f);
			UsingTileInventory[i].CollisionBox = new Rectangle(9999, 9999, 1, 1);
		}
	}

	protected override void UnloadContent()
	{
		((Game)this).Content.Unload();
	}

	protected override void Update(GameTime gameTime)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_030b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Unknown result type (might be due to invalid IL or missing references)
		//IL_0327: Unknown result type (might be due to invalid IL or missing references)
		//IL_032c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0347: Unknown result type (might be due to invalid IL or missing references)
		//IL_034c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0363: Unknown result type (might be due to invalid IL or missing references)
		//IL_0368: Unknown result type (might be due to invalid IL or missing references)
		//IL_0383: Unknown result type (might be due to invalid IL or missing references)
		//IL_0388: Unknown result type (might be due to invalid IL or missing references)
		//IL_039f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03db: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0400: Unknown result type (might be due to invalid IL or missing references)
		//IL_0416: Unknown result type (might be due to invalid IL or missing references)
		//IL_041b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0435: Unknown result type (might be due to invalid IL or missing references)
		//IL_043a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0473: Unknown result type (might be due to invalid IL or missing references)
		//IL_0478: Unknown result type (might be due to invalid IL or missing references)
		//IL_0492: Unknown result type (might be due to invalid IL or missing references)
		//IL_0497: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0506: Unknown result type (might be due to invalid IL or missing references)
		//IL_050b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0521: Unknown result type (might be due to invalid IL or missing references)
		//IL_0526: Unknown result type (might be due to invalid IL or missing references)
		//IL_0540: Unknown result type (might be due to invalid IL or missing references)
		//IL_0545: Unknown result type (might be due to invalid IL or missing references)
		//IL_055b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0560: Unknown result type (might be due to invalid IL or missing references)
		//IL_057a: Unknown result type (might be due to invalid IL or missing references)
		//IL_057f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0595: Unknown result type (might be due to invalid IL or missing references)
		//IL_059a: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0609: Unknown result type (might be due to invalid IL or missing references)
		//IL_060e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0628: Unknown result type (might be due to invalid IL or missing references)
		//IL_062d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0644: Unknown result type (might be due to invalid IL or missing references)
		//IL_0649: Unknown result type (might be due to invalid IL or missing references)
		//IL_0664: Unknown result type (might be due to invalid IL or missing references)
		//IL_0669: Unknown result type (might be due to invalid IL or missing references)
		//IL_0680: Unknown result type (might be due to invalid IL or missing references)
		//IL_0685: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0718: Unknown result type (might be due to invalid IL or missing references)
		//IL_071d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0734: Unknown result type (might be due to invalid IL or missing references)
		//IL_0739: Unknown result type (might be due to invalid IL or missing references)
		//IL_0754: Unknown result type (might be due to invalid IL or missing references)
		//IL_0759: Unknown result type (might be due to invalid IL or missing references)
		//IL_0770: Unknown result type (might be due to invalid IL or missing references)
		//IL_0775: Unknown result type (might be due to invalid IL or missing references)
		//IL_0790: Unknown result type (might be due to invalid IL or missing references)
		//IL_0795: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_07cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0808: Unknown result type (might be due to invalid IL or missing references)
		//IL_080d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0827: Unknown result type (might be due to invalid IL or missing references)
		//IL_082c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0842: Unknown result type (might be due to invalid IL or missing references)
		//IL_0847: Unknown result type (might be due to invalid IL or missing references)
		//IL_0861: Unknown result type (might be due to invalid IL or missing references)
		//IL_0866: Unknown result type (might be due to invalid IL or missing references)
		//IL_087c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0881: Unknown result type (might be due to invalid IL or missing references)
		//IL_089b: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_08bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_08da: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cfa: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ca4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0912: Unknown result type (might be due to invalid IL or missing references)
		//IL_0917: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ea7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1eb1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1eb6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ebb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0948: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a3a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e29: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e36: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e3c: Invalid comparison between Unknown and I4
		//IL_0e78: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c89: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d95: Unknown result type (might be due to invalid IL or missing references)
		//IL_10be: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ace: Unknown result type (might be due to invalid IL or missing references)
		//IL_146a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1479: Unknown result type (might be due to invalid IL or missing references)
		//IL_14e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_14f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bb9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bd3: Unknown result type (might be due to invalid IL or missing references)
		//IL_15c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b70: Unknown result type (might be due to invalid IL or missing references)
		//IL_195e: Unknown result type (might be due to invalid IL or missing references)
		FPS = 1.0 / gameTime.ElapsedGameTime.TotalSeconds;
		cos = false;
		KeyboardState = Keyboard.GetState();
		MouseState = Mouse.GetState();
		if (((KeyboardState)(ref KeyboardState)).IsKeyDown((Keys)27))
		{
			SavePlayer();
			((Game)this).Exit();
		}
		if (((KeyboardState)(ref KeyboardState)).IsKeyDown((Keys)112))
		{
			SavePlayer();
		}
		if (((KeyboardState)(ref KeyboardState)).IsKeyDown((Keys)113))
		{
			LoadPlayer();
		}
		if (((KeyboardState)(ref KeyboardState)).IsKeyDown((Keys)116))
		{
			SaveWorld();
		}
		if (((KeyboardState)(ref KeyboardState)).IsKeyDown((Keys)117))
		{
			LoadWorld();
		}
		checked
		{
			if (GameState == GameState.Playing)
			{
				for (int i = 0; i < 10; i++)
				{
					Player.Inventory[i].IsClicked = false;
				}
				Player.Inventory[ActiveSlot].IsClicked = true;
				if (UsingTileID == "Workbench")
				{
					InventoryOpen = true;
					UsingTileInventory[1].Position = new Vector2(410f, 260f);
					UsingTileInventory[1].CollisionBox = new Rectangle(410, 260, 44, 44);
					UsingTileInventory[2].Position = new Vector2(454f, 260f);
					UsingTileInventory[2].CollisionBox = new Rectangle(454, 260, 44, 44);
					UsingTileInventory[3].Position = new Vector2(498f, 260f);
					UsingTileInventory[3].CollisionBox = new Rectangle(498, 260, 44, 44);
					UsingTileInventory[4].Position = new Vector2(410f, 304f);
					UsingTileInventory[4].CollisionBox = new Rectangle(410, 304, 44, 44);
					UsingTileInventory[5].Position = new Vector2(454f, 304f);
					UsingTileInventory[5].CollisionBox = new Rectangle(454, 304, 44, 44);
					UsingTileInventory[6].Position = new Vector2(498f, 304f);
					UsingTileInventory[6].CollisionBox = new Rectangle(498, 304, 44, 44);
					UsingTileInventory[7].Position = new Vector2(410f, 348f);
					UsingTileInventory[7].CollisionBox = new Rectangle(410, 348, 44, 44);
					UsingTileInventory[8].Position = new Vector2(454f, 348f);
					UsingTileInventory[8].CollisionBox = new Rectangle(454, 348, 44, 44);
					UsingTileInventory[9].Position = new Vector2(498f, 348f);
					UsingTileInventory[9].CollisionBox = new Rectangle(498, 348, 44, 44);
					UsingTileInventory[10].Position = new Vector2(410f, 392f);
					UsingTileInventory[10].CollisionBox = new Rectangle(410, 392, 44, 44);
					UsingTileInventory[11].Position = new Vector2(454f, 392f);
					UsingTileInventory[11].CollisionBox = new Rectangle(454, 392, 44, 44);
					UsingTileInventory[12].Position = new Vector2(498f, 392f);
					UsingTileInventory[12].CollisionBox = new Rectangle(498, 392, 44, 44);
					UsingTileInventory[0].Position = new Vector2(576f, 326f);
					UsingTileInventory[0].CollisionBox = new Rectangle(576, 326, 44, 44);
				}
				if (UsingTileID == "Stone Anvil")
				{
					InventoryOpen = true;
					UsingTileInventory[1].Position = new Vector2(410f, 260f);
					UsingTileInventory[1].CollisionBox = new Rectangle(410, 260, 44, 44);
					UsingTileInventory[2].Position = new Vector2(454f, 260f);
					UsingTileInventory[2].CollisionBox = new Rectangle(454, 260, 44, 44);
					UsingTileInventory[3].Position = new Vector2(498f, 260f);
					UsingTileInventory[3].CollisionBox = new Rectangle(498, 260, 44, 44);
					UsingTileInventory[4].Position = new Vector2(410f, 304f);
					UsingTileInventory[4].CollisionBox = new Rectangle(410, 304, 44, 44);
					UsingTileInventory[5].Position = new Vector2(454f, 304f);
					UsingTileInventory[5].CollisionBox = new Rectangle(454, 304, 44, 44);
					UsingTileInventory[6].Position = new Vector2(498f, 304f);
					UsingTileInventory[6].CollisionBox = new Rectangle(498, 304, 44, 44);
					UsingTileInventory[7].Position = new Vector2(410f, 348f);
					UsingTileInventory[7].CollisionBox = new Rectangle(410, 348, 44, 44);
					UsingTileInventory[8].Position = new Vector2(454f, 348f);
					UsingTileInventory[8].CollisionBox = new Rectangle(454, 348, 44, 44);
					UsingTileInventory[9].Position = new Vector2(498f, 348f);
					UsingTileInventory[9].CollisionBox = new Rectangle(498, 348, 44, 44);
					UsingTileInventory[10].Position = new Vector2(410f, 392f);
					UsingTileInventory[10].CollisionBox = new Rectangle(410, 392, 44, 44);
					UsingTileInventory[11].Position = new Vector2(454f, 392f);
					UsingTileInventory[11].CollisionBox = new Rectangle(454, 392, 44, 44);
					UsingTileInventory[12].Position = new Vector2(498f, 392f);
					UsingTileInventory[12].CollisionBox = new Rectangle(498, 392, 44, 44);
					UsingTileInventory[13].Position = new Vector2(454f, 392f);
					UsingTileInventory[13].CollisionBox = new Rectangle(454, 392, 44, 44);
					UsingTileInventory[14].Position = new Vector2(498f, 392f);
					UsingTileInventory[14].CollisionBox = new Rectangle(498, 392, 44, 44);
					UsingTileInventory[0].Position = new Vector2(576f, 260f);
					UsingTileInventory[0].CollisionBox = new Rectangle(576, 260, 44, 44);
				}
				if (UsingTileID == "Furnace")
				{
					InventoryOpen = true;
					UsingTileInventory[1].Position = new Vector2(410f, 260f);
					UsingTileInventory[1].CollisionBox = new Rectangle(410, 260, 44, 44);
					UsingTileInventory[2].Position = new Vector2(460f, 260f);
					UsingTileInventory[2].CollisionBox = new Rectangle(460, 260, 44, 44);
					UsingTileInventory[3].Position = new Vector2(460f, 362f);
					UsingTileInventory[3].CollisionBox = new Rectangle(460, 362, 44, 44);
					UsingTileInventory[0].Position = new Vector2(538f, 260f);
					UsingTileInventory[0].CollisionBox = new Rectangle(538, 260, 44, 44);
				}
				if (UsingTileID == "")
				{
					for (int i = 0; i < 15; i++)
					{
						UsingTileInventory[i].Position = new Vector2(9999f, 9999f);
						if (UsingTileInventory[i].Item != null)
						{
							DropItem(UsingTileInventory[i].Item.ID, Player.Position);
							UsingTileInventory[i].Item = new Item("");
						}
					}
				}
				if (((KeyboardState)(ref KeyboardState)).IsKeyDown((Keys)32) && !Player.CanMove)
				{
					ref Vector2 position = ref Player.Position;
					position.Y -= 2f;
					ref Vector2 motion = ref Player.Motion;
					motion.Y -= 2.4f;
				}
				if (((KeyboardState)(ref KeyboardState)).IsKeyDown((Keys)84) && ((KeyboardState)(ref OldKeyboardState)).IsKeyUp((Keys)84))
				{
					for (int i = 0; i < Player.Inventory[ActiveSlot].Item.Count; i++)
					{
						DropItem(Player.Inventory[ActiveSlot].Item.ID, new Vector2((float)((MouseState)(ref MouseState)).X, (float)((MouseState)(ref MouseState)).Y));
					}
					Player.Inventory[ActiveSlot].Item = null;
				}
				if (((KeyboardState)(ref KeyboardState)).IsKeyDown((Keys)49))
				{
					ActiveSlot = 0;
				}
				if (((KeyboardState)(ref KeyboardState)).IsKeyDown((Keys)50))
				{
					ActiveSlot = 1;
				}
				if (((KeyboardState)(ref KeyboardState)).IsKeyDown((Keys)51))
				{
					ActiveSlot = 2;
				}
				if (((KeyboardState)(ref KeyboardState)).IsKeyDown((Keys)52))
				{
					ActiveSlot = 3;
				}
				if (((KeyboardState)(ref KeyboardState)).IsKeyDown((Keys)53))
				{
					ActiveSlot = 4;
				}
				if (((KeyboardState)(ref KeyboardState)).IsKeyDown((Keys)54))
				{
					ActiveSlot = 5;
				}
				if (((KeyboardState)(ref KeyboardState)).IsKeyDown((Keys)55))
				{
					ActiveSlot = 6;
				}
				if (((KeyboardState)(ref KeyboardState)).IsKeyDown((Keys)56))
				{
					ActiveSlot = 7;
				}
				if (((KeyboardState)(ref KeyboardState)).IsKeyDown((Keys)57))
				{
					ActiveSlot = 8;
				}
				if (((KeyboardState)(ref KeyboardState)).IsKeyDown((Keys)48))
				{
					ActiveSlot = 9;
				}
				if (((KeyboardState)(ref KeyboardState)).IsKeyDown((Keys)69) && ((KeyboardState)(ref OldKeyboardState)).IsKeyUp((Keys)69))
				{
					if (InventoryOpen)
					{
						InventoryOpen = false;
						UsingTileID = "";
					}
					else
					{
						InventoryOpen = true;
					}
				}
				Player.Motion.X = 0f;
				if (((KeyboardState)(ref KeyboardState)).IsKeyDown((Keys)65))
				{
					for (int j = 0; j < MapWidth; j++)
					{
						for (int k = 0; k < MapHeight; k++)
						{
							if (Tile[j, k] != null && Tile[j, k].ID != "Air" && !((Rectangle)(ref Tile[j, k].CollisionBox)).Intersects(Player.CollisionBox) && !Tile[j, k].IsWall && !Tile[j, k].Behind)
							{
								Player.Motion.X = -2f;
								Player.Direction = Direction.Left;
							}
						}
					}
				}
				if (((KeyboardState)(ref KeyboardState)).IsKeyDown((Keys)68))
				{
					for (int j = 0; j < MapWidth; j++)
					{
						for (int k = 0; k < MapHeight; k++)
						{
							if (Tile[j, k] != null && Tile[j, k].ID != "Air" && !((Rectangle)(ref Tile[j, k].CollisionBox)).Intersects(Player.CollisionBox) && !Tile[j, k].IsWall && !Tile[j, k].Behind)
							{
								Player.Motion.X = 2f;
								Player.Direction = Direction.Right;
							}
						}
					}
				}
				if (unchecked((int)((MouseState)(ref MouseState)).LeftButton == 0 && (int)((MouseState)(ref OldMouseState)).LeftButton == 1))
				{
					for (int i = 0; i < 15; i++)
					{
						if (!((Rectangle)(ref UsingTileInventory[i].CollisionBox)).Intersects(new Rectangle(((MouseState)(ref MouseState)).X, ((MouseState)(ref MouseState)).Y, 1, 1)))
						{
							continue;
						}
						if (i != 0)
						{
							if (Player.HeldItem != null)
							{
								if (UsingTileInventory[i].Item.ID == "")
								{
									Player.HeldItem.Count--;
									UsingTileInventory[i].Item = new Item(Player.HeldItem.ID);
									UsingTileInventory[i].Item.Count = 1;
									if (Player.HeldItem.Count < 1)
									{
										Player.HeldItem = null;
									}
								}
							}
							else if (UsingTileInventory[i].Item != null)
							{
								Player.HeldItem = new Item(UsingTileInventory[i].Item.ID);
								Player.HeldItem.Count = 1;
								UsingTileInventory[i].Item = new Item("");
							}
						}
						else if (UsingTileInventory[0].Item != null && UsingTileInventory[0].Item.ID != "" && Player.HeldItem == null)
						{
							Player.HeldItem = new Item(UsingTileInventory[0].Item.ID);
							Player.HeldItem.Count = UsingTileInventory[0].Item.Count;
							for (int l = 0; l < 15; l++)
							{
								UsingTileInventory[l].Item = new Item("");
							}
						}
					}
					for (int i = 0; i < 30; i++)
					{
						if (!((Rectangle)(ref Player.Inventory[i].CollisionBox)).Intersects(new Rectangle(((MouseState)(ref MouseState)).X, ((MouseState)(ref MouseState)).Y, 1, 1)))
						{
							continue;
						}
						if (Player.HeldItem == null)
						{
							if (Player.Inventory[i].Item != null)
							{
								Player.HeldItem = Player.Inventory[i].Item;
								Player.Inventory[i].Item = null;
							}
						}
						else if (Player.Inventory[i].Item == null)
						{
							Player.Inventory[i].Item = Player.HeldItem;
							Player.HeldItem = null;
						}
						else if (Player.Inventory[i].Item.ID == Player.HeldItem.ID)
						{
							if (Player.Inventory[i].Item.Count + Player.HeldItem.Count <= Player.Inventory[i].Item.MaxStack)
							{
								Player.Inventory[i].Item.Count += Player.HeldItem.Count;
								Player.HeldItem = null;
							}
							else
							{
								Player.HeldItem.Count -= Player.Inventory[i].Item.MaxStack - Player.Inventory[i].Item.Count;
								Player.Inventory[i].Item.Count = Player.Inventory[i].Item.MaxStack;
							}
						}
					}
					if ((float)((MouseState)(ref MouseState)).X < Player.Position.X)
					{
						Player.Direction = Direction.Left;
					}
					else
					{
						Player.Direction = Direction.Right;
					}
				}
				if (MouseLeftClicked() && Player.Inventory[ActiveSlot].Item != null)
				{
					if (!Player.Inventory[ActiveSlot].Item.Using)
					{
						Player.Inventory[ActiveSlot].Item.Using = true;
					}
					if (Player.Inventory[ActiveSlot].Item.Type == ItemType.Ranged && unchecked(Player.useTime.ElapsedMilliseconds / 10) >= Player.Inventory[ActiveSlot].Item.UseTime)
					{
						for (int i = 0; i < MaxProjectileCount; i++)
						{
							if (Projectile[i] == null)
							{
								Player.useTime.Restart();
								if (Player.Direction == Direction.Left)
								{
									Projectile[i] = new Projectile("Wooden Arrow", Player.Inventory[ActiveSlot].Item.Damage, new Vector2(Player.Position.X, Player.Position.Y + 20f), new Vector2(-10f, -0.5f), IsPlayer: true);
								}
								if (Player.Direction == Direction.Right)
								{
									Projectile[i] = new Projectile("Wooden Arrow", Player.Inventory[ActiveSlot].Item.Damage, new Vector2(Player.Position.X, Player.Position.Y + 20f), new Vector2(10f, -0.5f), IsPlayer: true);
								}
								i = 999999;
							}
						}
					}
					if (Player.Inventory[ActiveSlot].Item.Type == ItemType.Tool)
					{
						for (int j = 0; j < MapWidth; j++)
						{
							for (int k = 0; k < MapHeight; k++)
							{
								unchecked
								{
									if (Tile[j, k] != null && Tile[j, k].ID != "Air" && ((Rectangle)(ref Tile[j, k].CollisionBox)).Intersects(new Rectangle(((MouseState)(ref MouseState)).X, ((MouseState)(ref MouseState)).Y, 1, 1)))
									{
										if (Tile[j, k].Tool == Tool.Pickaxe && Player.Inventory[ActiveSlot].Item.PowerPickaxe > 0 && Player.useTime.ElapsedMilliseconds / 10 >= Player.Inventory[ActiveSlot].Item.UseTime)
										{
											Player.useTime.Restart();
											Tile[j, k].Hit(Player.Inventory[ActiveSlot].Item.PowerPickaxe / 10);
											checked
											{
												Player.Inventory[ActiveSlot].Item.Durability--;
											}
										}
										if (Tile[j, k].Tool == Tool.Axe && Player.Inventory[ActiveSlot].Item.PowerAxe > 0 && Player.useTime.ElapsedMilliseconds / 10 >= Player.Inventory[ActiveSlot].Item.UseTime)
										{
											Player.useTime.Restart();
											Tile[j, k].Hit(Player.Inventory[ActiveSlot].Item.PowerAxe / 10);
											checked
											{
												Player.Inventory[ActiveSlot].Item.Durability--;
											}
										}
										if (Tile[j, k].Tool == Tool.Shovel && Player.Inventory[ActiveSlot].Item.PowerShovel > 0 && Player.useTime.ElapsedMilliseconds / 10 >= Player.Inventory[ActiveSlot].Item.UseTime)
										{
											Player.useTime.Restart();
											Tile[j, k].Hit(Player.Inventory[ActiveSlot].Item.PowerShovel / 10);
											checked
											{
												Player.Inventory[ActiveSlot].Item.Durability--;
											}
										}
									}
								}
							}
						}
					}
					if (Player.Inventory[ActiveSlot].Item.Type == ItemType.Hammer)
					{
						for (int j = 0; j < MapWidth; j++)
						{
							for (int k = 0; k < MapHeight; k++)
							{
								if (Tile[j, k] != null && Tile[j, k].ID != "Air" && ((Rectangle)(ref Tile[j, k].CollisionBox)).Intersects(new Rectangle(((MouseState)(ref MouseState)).X, ((MouseState)(ref MouseState)).Y, 1, 1)) && unchecked(Player.useTime.ElapsedMilliseconds / 10) >= Player.Inventory[ActiveSlot].Item.UseTime)
								{
									Player.useTime.Restart();
									Tile[j, k].IsWall = !Tile[j, k].IsWall;
								}
							}
						}
					}
				}
				if (MouseRightClicked() && Player.Inventory[ActiveSlot].Item != null && Player.Inventory[ActiveSlot].Item.Type == ItemType.Placeable)
				{
					for (int j = 0; j < MapWidth; j++)
					{
						for (int k = 0; k < MapHeight; k++)
						{
							if (Tile[j, k].ID == "Air")
							{
								if (!((Rectangle)(ref Tile[j, k].CollisionBox)).Intersects(new Rectangle(((MouseState)(ref MouseState)).X, ((MouseState)(ref MouseState)).Y, 1, 1)))
								{
									continue;
								}
								if (Player.Inventory[ActiveSlot].Item.ID == "Acorn")
								{
									if (Tile[j, k].TileBelow() == "Grass")
									{
										WorldGenerator.GrowTree((short)j, (short)(k + 1), new Vector2(Tile[j, k].Position.X, Tile[j, k].Position.Y + 20f), ConsumePlayerResource: true);
										j = 999999;
										k = 999999;
									}
								}
								else
								{
									WorldGenerator.PlaceTile(Player.Inventory[ActiveSlot].Item.PlacedID, (short)j, (short)k, IsWall: false, ConsumePlayerResource: true, Tile[j, k].Position, Player.Inventory[ActiveSlot].Item.PlacedSize);
									j = 999999;
									k = 999999;
								}
							}
							else
							{
								cos = true;
							}
						}
					}
				}
			}
			if (MouseRightClicked() && !InventoryOpen)
			{
				for (int j = 0; j < MapWidth; j++)
				{
					for (int k = 0; k < MapHeight; k++)
					{
						if (Tile[j, k].ID != "Air")
						{
							if (((Rectangle)(ref Tile[j, k].CollisionBox)).Intersects(new Rectangle(((MouseState)(ref MouseState)).X, ((MouseState)(ref MouseState)).Y, 1, 1)))
							{
								UsingTileID = Tile[j, k].ID;
							}
						}
						else if (((Rectangle)(ref Tile[j, k].CollisionBox)).Intersects(new Rectangle(((MouseState)(ref MouseState)).X, ((MouseState)(ref MouseState)).Y, 1, 1)))
						{
							UsingTileID = "";
							InventoryOpen = false;
						}
					}
				}
			}
			Player.Update();
			for (int j = 0; j < MapWidth; j++)
			{
				for (int k = 0; k < MapHeight; k++)
				{
					if (Tile[j, k] != null)
					{
						Tile[j, k].UUIDx = (short)j;
						Tile[j, k].UUIDy = (short)k;
						Tile[j, k].Update();
					}
				}
			}
			for (int i = 0; i < MaxItemCount; i++)
			{
				if (Item[i] != null)
				{
					Item[i].UUID = (short)i;
					Item[i].Update();
				}
			}
			for (int i = 0; i < MaxMobCount; i++)
			{
				if (Mob[i] != null)
				{
					Mob[i].UUID = (short)i;
					Mob[i].Update();
				}
			}
			for (int i = 0; i < MaxProjectileCount; i++)
			{
				if (Projectile[i] != null)
				{
					Projectile[i].UUID = (short)i;
					Projectile[i].AI();
				}
			}
			ScreenPosition -= Player.Motion;
			Recipe.CheckedUUID = short.MaxValue;
			for (int i = 0; i < MaxRecipeCount; i++)
			{
				if (recipe[i] != null && Recipe.IsSet == short.MaxValue)
				{
					recipe[i].Update();
				}
			}
			for (int i = 0; i < MaxRecipeCount; i++)
			{
				if (recipe[i] != null && Recipe.IsSet == recipe[i].UUID)
				{
					recipe[i].Update();
				}
			}
			((Game)this).Update(gameTime);
		}
	}

	protected override void Draw(GameTime gameTime)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_0457: Unknown result type (might be due to invalid IL or missing references)
		//IL_045c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0487: Unknown result type (might be due to invalid IL or missing references)
		//IL_048c: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0428: Unknown result type (might be due to invalid IL or missing references)
		//IL_042d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0400: Unknown result type (might be due to invalid IL or missing references)
		((Game)this).GraphicsDevice.Clear(new Color(150, 210, 255));
		spriteBatch.Begin();
		checked
		{
			for (int i = 0; i < MapWidth; i++)
			{
				for (int j = 0; j < MapHeight; j++)
				{
					if (Tile[i, j] != null)
					{
						Tile[i, j].Draw();
						if (((Rectangle)(ref Tile[i, j].CollisionBox)).Intersects(new Rectangle(((MouseState)(ref MouseState)).X, ((MouseState)(ref MouseState)).Y, 1, 1)))
						{
							spriteBatch.Draw(CursorTile, new Vector2((float)(i * 20) + ScreenPosition.X - 1f, (float)(j * 20) + ScreenPosition.Y), Color.White);
						}
					}
				}
			}
			for (int k = 0; k < MaxItemCount; k++)
			{
				if (Item[k] != null)
				{
					Item[k].Draw();
				}
			}
			for (int k = 0; k < MaxMobCount; k++)
			{
				if (Mob[k] != null)
				{
					Mob[k].Draw();
				}
			}
			for (int k = 0; k < MaxProjectileCount; k++)
			{
				if (Projectile[k] != null)
				{
					Projectile[k].Draw();
				}
			}
			Player.Draw();
			if (UsingTileID == "Workbench")
			{
				spriteBatch.Draw(WorkbenchGui, new Vector2(400f, 250f), Color.White);
			}
			else if (UsingTileID == "Furnace")
			{
				spriteBatch.Draw(FurnaceGui, new Vector2(400f, 250f), Color.White);
			}
			else if (UsingTileID == "Stone Anvil")
			{
				spriteBatch.Draw(AnvilGui, new Vector2(400f, 250f), Color.White);
			}
			for (int k = 0; k < 15; k++)
			{
				UsingTileInventory[k].Draw();
			}
			for (int k = 0; k < 10; k++)
			{
				Player.Inventory[k].Draw();
			}
			if (InventoryOpen)
			{
				for (int k = 10; k < 30; k++)
				{
					Player.Inventory[k].Draw();
				}
				for (int k = 0; k < 4; k++)
				{
					Player.Armor[k].Draw();
				}
				for (int k = 0; k < 4; k++)
				{
					Player.Accessory[k].Draw();
				}
			}
			for (int k = 0; k < 10; k++)
			{
				Player.Inventory[k].DrawItemInfo();
			}
			if (Player.HeldItem != null && Player.HeldItem.ID != "")
			{
				spriteBatch.Draw(Player.HeldItem.Texture, new Vector2((float)(((MouseState)(ref MouseState)).X + 3), (float)(((MouseState)(ref MouseState)).Y - 1)), Color.White);
				DrawText(string.Concat(Player.HeldItem.Count), new Vector2((float)(((MouseState)(ref MouseState)).X + 3), (float)(((MouseState)(ref MouseState)).Y + 25)), new Color(50, 50, 50));
			}
			if (cos)
			{
				DrawText("#######", new Vector2(40f, 500f), Color.Black);
			}
			DrawText("fps: " + (int)FPS, new Vector2(100f, 680f), Color.Black);
			spriteBatch.Draw(Cursor, new Vector2((float)((MouseState)(ref MouseState)).X, (float)((MouseState)(ref MouseState)).Y), Color.White);
			spriteBatch.End();
			OldMouseState = MouseState;
			OldKeyboardState = KeyboardState;
			((Game)this).Draw(gameTime);
		}
	}

	static Main()
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			recipe = new Recipe[MaxRecipeCount + 1];
			Player = new Player(new Vector2(640f, 372f), 100);
			Item = new EntityItem[MaxItemCount + 1];
			Projectile = new Projectile[MaxProjectileCount + 1];
			Mob = new Entity[MaxMobCount + 1];
			Tile = new Tile[MapWidth + 1, MapHeight + 1];
			UsingTileID = "";
			UsingTileInventory = new EQSlot[15];
		}
	}
}
