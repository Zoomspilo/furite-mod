using Terraria.ID;
using Terraria.ModLoader;

namespace FuriteMod.Items.Weapons
{
	public class IronWarhammer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Iron Warhammer");
			Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
			item.damage = 17;
			item.melee = true;
			item.width = 48;
			item.height = 48;
			item.useTime = 20;
			item.useAnimation = 40;
            item.hammer = 33;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 30;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 5);
            recipe.AddIngredient(ItemID.IronBar, 12);
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
