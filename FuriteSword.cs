using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace FuriteMod.Items.Weapons
{
	public class FuriteSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Furite Blade");
            Tooltip.SetDefault("'It has an odd warmth to it.'"
                + "\nFlings fire particles that do damage");
		}
		public override void SetDefaults()
		{
			item.damage = 30;
			item.melee = true;
			item.width = 38;
			item.height = 38;
			item.useTime = 50;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 4;
            item.rare = 5;
			item.UseSound = SoundID.Item1;
            item.shoot = ProjectileID.MolotovFire2;
            item.shootSpeed = 10.3f;
            item.autoReuse = true;
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 1; 
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(13)); // 13 degree spread.
				// If you want to randomize the speed to stagger the projectiles
				float scale = 1f - (Main.rand.NextFloat() * .3f);
				perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false; // return false because we don't want tModLoader to shoot projectile
		}
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FuriteShard", 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
