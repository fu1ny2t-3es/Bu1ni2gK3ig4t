using BurningKnight.assets.items;
using BurningKnight.entity.component;
using Lens.entity;
using Microsoft.Xna.Framework;

namespace BurningKnight.level.entities.statue {
	public class StoneStatue : Statue {
		public override void AddComponents() {
			base.AddComponents();

			Sprite = "stone_statue";
			Width = 20;
			Height = 26;
		}

		protected override Rectangle GetCollider() {
			return new Rectangle(0, 18, 20, 15);
		}

		protected override bool Interact(Entity e) {
			Items.Unlock("bk:broken_stone");

			for (var i = 0; i < 3; i++) {
				e.GetComponent<InventoryComponent>().Pickup(Items.CreateAndAdd("bk:broken_stone", Area));
			}

			Break();
			return true;
		}
	}
}