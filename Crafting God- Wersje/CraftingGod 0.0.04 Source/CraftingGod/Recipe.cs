namespace CraftingGod;

public class Recipe
{
	public static short CheckedUUID = short.MaxValue;

	public short UUID = short.MaxValue;

	public string[] RequiredItemID = new string[15]
	{
		"", "", "", "", "", "", "", "", "", "",
		"", "", "", "", ""
	};

	public string RequiredTileID = "Workbench";

	public string ResultID;

	public byte ResultCount;

	public static short IsSet = short.MaxValue;

	public bool Check = false;

	public void SetIngredient(short Slot, string ID)
	{
		RequiredItemID[Slot] = ID;
	}

	public void SetResult(string ID, byte Count)
	{
		ResultID = ID;
		ResultCount = Count;
	}

	public static void SetupRecipes()
	{
		Main.recipe[0] = new Recipe();
		Main.recipe[0].UUID = 0;
		Main.recipe[0].RequiredTileID = "Workbench";
		Main.recipe[0].SetIngredient(0, "Wood Log");
		Main.recipe[0].SetResult("Wood Planks", 5);
		Main.recipe[1] = new Recipe();
		Main.recipe[1].UUID = 1;
		Main.recipe[1].RequiredTileID = "Workbench";
		Main.recipe[1].SetIngredient(0, "Wood Planks");
		Main.recipe[1].SetResult("Stick", 5);
		Main.recipe[2] = new Recipe();
		Main.recipe[2].UUID = 2;
		Main.recipe[2].RequiredTileID = "Workbench";
		Main.recipe[2].SetIngredient(0, "Wood Planks");
		Main.recipe[2].SetIngredient(1, "Wood Planks");
		Main.recipe[2].SetIngredient(2, "Wood Planks");
		Main.recipe[2].SetIngredient(4, "Stick");
		Main.recipe[2].SetIngredient(7, "Stick");
		Main.recipe[2].SetIngredient(10, "Stick");
		Main.recipe[2].SetResult("Wooden Pickaxe", 1);
		Main.recipe[3] = new Recipe();
		Main.recipe[3].UUID = 3;
		Main.recipe[3].RequiredTileID = "Workbench";
		Main.recipe[3].SetIngredient(0, "Wood Planks");
		Main.recipe[3].SetIngredient(1, "Stick");
		Main.recipe[3].SetIngredient(3, "Wood Planks");
		Main.recipe[3].SetIngredient(4, "Wood Planks");
		Main.recipe[3].SetIngredient(5, "Wood Planks");
		Main.recipe[3].SetIngredient(6, "Wood Planks");
		Main.recipe[3].SetIngredient(7, "Stick");
		Main.recipe[3].SetIngredient(10, "Stick");
		Main.recipe[3].SetResult("Wooden Axe", 1);
		Main.recipe[4] = new Recipe();
		Main.recipe[4].UUID = 4;
		Main.recipe[4].RequiredTileID = "Workbench";
		Main.recipe[4].SetIngredient(4, "Wood Planks");
		Main.recipe[4].SetIngredient(7, "Wood Planks");
		Main.recipe[4].SetIngredient(10, "Stick");
		Main.recipe[4].SetResult("Wooden Dagger", 1);
		Main.recipe[5] = new Recipe();
		Main.recipe[5].UUID = 5;
		Main.recipe[5].RequiredTileID = "Workbench";
		Main.recipe[5].SetIngredient(1, "Wood Planks");
		Main.recipe[5].SetIngredient(4, "Wood Planks");
		Main.recipe[5].SetIngredient(7, "Wood Planks");
		Main.recipe[5].SetIngredient(10, "Stick");
		Main.recipe[5].SetResult("Wooden Sword", 1);
		Main.recipe[6] = new Recipe();
		Main.recipe[6].UUID = 6;
		Main.recipe[6].RequiredTileID = "Workbench";
		Main.recipe[6].SetIngredient(1, "Wood Planks");
		Main.recipe[6].SetIngredient(4, "Stick");
		Main.recipe[6].SetIngredient(7, "Stick");
		Main.recipe[6].SetIngredient(10, "Stick");
		Main.recipe[6].SetResult("Wooden Shovel", 1);
		Main.recipe[7] = new Recipe();
		Main.recipe[7].UUID = 7;
		Main.recipe[7].RequiredTileID = "Workbench";
		Main.recipe[7].SetIngredient(0, "Cobblestone");
		Main.recipe[7].SetIngredient(1, "Cobblestone");
		Main.recipe[7].SetIngredient(2, "Cobblestone");
		Main.recipe[7].SetIngredient(3, "Cobblestone");
		Main.recipe[7].SetIngredient(5, "Cobblestone");
		Main.recipe[7].SetIngredient(6, "Cobblestone");
		Main.recipe[7].SetIngredient(7, "Cobblestone");
		Main.recipe[7].SetIngredient(8, "Cobblestone");
		Main.recipe[7].SetIngredient(9, "Cobblestone");
		Main.recipe[7].SetIngredient(10, "Wood Planks");
		Main.recipe[7].SetIngredient(11, "Cobblestone");
		Main.recipe[7].SetResult("Furnace", 1);
		Main.recipe[8] = new Recipe();
		Main.recipe[8].UUID = 8;
		Main.recipe[8].RequiredTileID = "Workbench";
		Main.recipe[8].SetIngredient(3, "Cobblestone");
		Main.recipe[8].SetIngredient(4, "Cobblestone");
		Main.recipe[8].SetIngredient(5, "Cobblestone");
		Main.recipe[8].SetIngredient(6, "Cobblestone");
		Main.recipe[8].SetIngredient(7, "Cobblestone");
		Main.recipe[8].SetIngredient(8, "Cobblestone");
		Main.recipe[8].SetIngredient(9, "Cobblestone");
		Main.recipe[8].SetIngredient(11, "Cobblestone");
		Main.recipe[8].SetResult("Stone Anvil", 1);
		Main.recipe[9] = new Recipe();
		Main.recipe[9].UUID = 9;
		Main.recipe[9].RequiredTileID = "Workbench";
		Main.recipe[9].SetIngredient(9, "Wood Log");
		Main.recipe[9].SetIngredient(10, "Wood Planks");
		Main.recipe[9].SetIngredient(11, "Wood Log");
		Main.recipe[9].SetResult("Workbench", 1);
		Main.recipe[10] = new Recipe();
		Main.recipe[10].UUID = 10;
		Main.recipe[10].RequiredTileID = "Workbench";
		Main.recipe[10].SetIngredient(1, "Stick");
		Main.recipe[10].SetIngredient(3, "Wood Planks");
		Main.recipe[10].SetIngredient(4, "Wood Planks");
		Main.recipe[10].SetIngredient(5, "Wood Planks");
		Main.recipe[10].SetIngredient(7, "Stick");
		Main.recipe[10].SetIngredient(10, "Stick");
		Main.recipe[10].SetResult("Wooden Hammer", 1);
		Main.recipe[11] = new Recipe();
		Main.recipe[11].UUID = 11;
		Main.recipe[11].RequiredTileID = "Stone Anvil";
		Main.recipe[11].SetIngredient(1, "Stick");
		Main.recipe[11].SetIngredient(3, "Cobblestone");
		Main.recipe[11].SetIngredient(4, "Cobblestone");
		Main.recipe[11].SetIngredient(5, "Cobblestone");
		Main.recipe[11].SetIngredient(7, "Stick");
		Main.recipe[11].SetIngredient(10, "Stick");
		Main.recipe[11].SetResult("Stone Hammer", 1);
		Main.recipe[12] = new Recipe();
		Main.recipe[12].UUID = 12;
		Main.recipe[12].RequiredTileID = "Stone Anvil";
		Main.recipe[12].SetIngredient(0, "Cobblestone");
		Main.recipe[12].SetIngredient(1, "Cobblestone");
		Main.recipe[12].SetIngredient(2, "Cobblestone");
		Main.recipe[12].SetIngredient(4, "Stick");
		Main.recipe[12].SetIngredient(7, "Stick");
		Main.recipe[12].SetIngredient(10, "Stick");
		Main.recipe[12].SetResult("Stone Pickaxe", 1);
		Main.recipe[13] = new Recipe();
		Main.recipe[13].UUID = 13;
		Main.recipe[13].RequiredTileID = "Stone Anvil";
		Main.recipe[13].SetIngredient(0, "Cobblestone");
		Main.recipe[13].SetIngredient(1, "Stick");
		Main.recipe[13].SetIngredient(3, "Cobblestone");
		Main.recipe[13].SetIngredient(4, "Cobblestone");
		Main.recipe[13].SetIngredient(5, "Cobblestone");
		Main.recipe[13].SetIngredient(6, "Cobblestone");
		Main.recipe[13].SetIngredient(7, "Stick");
		Main.recipe[13].SetIngredient(10, "Stick");
		Main.recipe[13].SetResult("Stone Axe", 1);
		Main.recipe[14] = new Recipe();
		Main.recipe[14].UUID = 14;
		Main.recipe[14].RequiredTileID = "Stone Anvil";
		Main.recipe[14].SetIngredient(4, "Wood Planks");
		Main.recipe[14].SetIngredient(7, "Wood Planks");
		Main.recipe[14].SetIngredient(10, "Wood Planks");
		Main.recipe[14].SetResult("Wooden Bow", 1);
		Main.recipe[15] = new Recipe();
		Main.recipe[15].UUID = 15;
		Main.recipe[15].RequiredTileID = "Stone Anvil";
		Main.recipe[15].SetIngredient(1, "Cobblestone");
		Main.recipe[15].SetIngredient(4, "Cobblestone");
		Main.recipe[15].SetIngredient(7, "Cobblestone");
		Main.recipe[15].SetIngredient(10, "Stick");
		Main.recipe[15].SetResult("Stone Sword", 1);
		Main.recipe[16] = new Recipe();
		Main.recipe[16].UUID = 16;
		Main.recipe[16].RequiredTileID = "Stone Anvil";
		Main.recipe[16].SetIngredient(1, "Cobblestone");
		Main.recipe[16].SetIngredient(4, "Stick");
		Main.recipe[16].SetIngredient(7, "Stick");
		Main.recipe[16].SetIngredient(10, "Stick");
		Main.recipe[16].SetResult("Stone Shovel", 1);
		Main.recipe[17] = new Recipe();
		Main.recipe[17].UUID = 17;
		Main.recipe[17].RequiredTileID = "Furnace";
		Main.recipe[17].SetIngredient(1, "Cobblestone");
		Main.recipe[17].SetIngredient(3, "Wood Log");
		Main.recipe[17].SetResult("Stone", 1);
	}

	public void Update()
	{
		if (!(ResultID != "") || !(Main.UsingTileID == RequiredTileID))
		{
			return;
		}
		byte b = 0;
		checked
		{
			for (int i = 0; i < 12; i++)
			{
				if (Main.UsingTileInventory[i + 1].Item.ID == RequiredItemID[i])
				{
					b++;
				}
			}
			if (b == 12)
			{
				IsSet = UUID;
				if (Main.UsingTileInventory[0].Item == null)
				{
					Main.UsingTileInventory[0].Item = new Item(ResultID);
					Main.UsingTileInventory[0].Item.Count = ResultCount;
				}
				else if (Main.UsingTileInventory[0].Item.ID == "")
				{
					Main.UsingTileInventory[0].Item = new Item(ResultID);
					Main.UsingTileInventory[0].Item.Count = ResultCount;
				}
			}
			else
			{
				IsSet = short.MaxValue;
				Main.UsingTileInventory[0].Item = new Item("");
			}
		}
	}
}
