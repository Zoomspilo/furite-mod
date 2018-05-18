using Terraria.ID;
using Terraria.ModLoader;

namespace FuriteMod.Items.Weapons
{
	public class LightsBaneShortsword2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Day's Bane MK2");
			Tooltip.SetDefault("'It emanates a power similar to that of Light's Bane.'");
		}
		public override void SetDefaults()
		{
			item.damage = 14;
			item.melee = true;
			item.width = 36;
			item.height = 36;
			item.useTime = 13;
			item.useAnimation = 13;
			item.useStyle = 3;
			item.knockBack = 4;
            item.rare = 1;
			item.value = 145;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "LightsBaneShortsword", 1);
            recipe.AddIngredient(null, "MuramasaShortsword", 1);
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
