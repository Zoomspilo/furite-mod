using Terraria.ID;
using Terraria.ModLoader;

namespace FuriteMod.Items.Weapons
{
	public class MahoganyWarhammer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rich Mahogany Warhammer");
			Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
			item.damage = 14;
			item.melee = true;
			item.width = 48;
			item.height = 48;
			item.useTime = 20;
			item.useAnimation = 40;
            item.hammer = 23;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.RichMahogany, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
