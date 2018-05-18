using FuriteMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FuriteMod.Items.Weapons
{
	public class RubyYoyo : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Ruby Throw");

			// These are all related to gamepad controls and don't seem to affect anything else
			ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 14;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.useStyle = 5;
			item.width = 24;
			item.height = 24;
			item.useAnimation = 25;
			item.useTime = 25;
			item.shootSpeed = 16f;
			item.knockBack = 2.5f;
			item.damage = 19;
			item.rare = 1;

			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.noUseGraphic = true;

			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(gold: 1, silver: 12);
			item.shoot = mod.ProjectileType<RubyYoyoProjectile>();
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "YoyoBlueprint", 1);
            recipe.AddIngredient(ItemID.Ruby, 11);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(null, "RubyYoyo");
            recipe.AddRecipe();
        }
    }
}
