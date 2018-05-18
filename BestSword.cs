using Terraria.ID;
using Terraria.ModLoader;

namespace FuriteMod.Items.Weapons
{
	public class BestSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Debug Blade");
			Tooltip.SetDefault("DEBUG");
		}
		public override void SetDefaults()
		{
			item.damage = 10000;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 6;
			item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.useTurn = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
