using System.Collections.Generic;
using BurningKnight.assets.items;
using BurningKnight.util;
using Lens.util;

namespace BurningKnight.entity.item {
	public class ItemPool {
		public static Dictionary<string, ItemPool> ByName = new Dictionary<string, ItemPool>();
		public static ItemPool[] ById = new ItemPool[32];
		public static string[] Names = new string[32];

		static ItemPool() {
			// So that imgui doesnt crash
			for (var i = 0; i < 32; i++) {
				Names[i] = "";
			}
		}

		public static readonly ItemPool Consumable = new ItemPool("consumable");
		public static readonly ItemPool Treasure = new ItemPool("treasure");
		public static readonly ItemPool Secret = new ItemPool("secret");
		public static readonly ItemPool Hat = new ItemPool("hat");
		public static readonly ItemPool Crate = new ItemPool("crate");
		public static readonly ItemPool StartingWeapon = new ItemPool("starting_weapon");
		public static readonly ItemPool Shop = new ItemPool("shop");
		public static readonly ItemPool Boss = new ItemPool("boss");
		public static readonly ItemPool ShopConsumable = new ItemPool("shop_consumable");
		public static readonly ItemPool Safe = new ItemPool("safe");
		public static readonly ItemPool Charger = new ItemPool("charger");
		public static readonly ItemPool WoodenChest = new ItemPool("wooden_chest");
		public static readonly ItemPool GoldChest = new ItemPool("gold_chest");
		public static readonly ItemPool CursedChest = new ItemPool("cursed_chest");
		public static readonly ItemPool DoubleChest = new ItemPool("double_chest");
		public static readonly ItemPool TripleChest = new ItemPool("triple_chest");
		public static readonly ItemPool RedChest = new ItemPool("red_chest");
		public static readonly ItemPool Pet = new ItemPool("pet");
		public static readonly ItemPool Orbital = new ItemPool("orbital");

		private static int count;
		public static int Count => count;
		
		public readonly string Name;
		public readonly int Id;

		public ItemPool(string name) {
			if (count >= 32) {
				Log.Error($"Can not define item pool {name}, 32 pools were already defined");
				return;
			}
			
			Name = name;
			Id = count;

			ById[Id] = this;
			ByName[name] = this;
			Names[Id] = name;
			
			count++;
		}

		public int Apply(int pools, bool add = true) {
			return BitHelper.SetBit(pools, Id, add);
		}
		
		public bool Contains(int pools) {
			return BitHelper.IsBitSet(pools, Id);
		}
	}
}