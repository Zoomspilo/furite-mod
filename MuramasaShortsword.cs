using Terraria.ID;
using Terraria.ModLoader;

namespace FuriteMod.Items.Weapons
{
	public class MuramasaShortsword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Muramini");
			Tooltip.SetDefault("'It's a little baby Muramasa!'");
		}
		public override void SetDefaults()
		{
			item.damage = 14;
			item.melee = true;
			item.width = 38;
			item.height = 40;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 3;
			item.knockBack = 4;
            item.rare = 2;
			item.value = 1500;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.useTurn = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DemoniteBar, 7);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
