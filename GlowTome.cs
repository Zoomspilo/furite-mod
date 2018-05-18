using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace FuriteMod.Items.Weapons
{
	public class GlowTome : ModItem
	{
        public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Divine Light");
            Tooltip.SetDefault("");
		}

		public override void SetDefaults()
		{
            item.magic = true;
            item.damage = 17;
            item.scale = 0.9f;
            item.reuseDelay = 7;
			item.mana = 10;
			item.width = 30;
			item.height = 30;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 1;
			item.value = 10500;
			item.rare = 1;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("SparklingBall");
			item.shootSpeed = 12f;
		}
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
        }
    }
}