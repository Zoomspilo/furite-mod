using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace FuriteMod.NPCs
{
    public class RockSlime : ModNPC //ModNPC makes it a custom NPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stone Slime");
        }
        public override void SetDefaults()
        {
            npc.width = 32;
            npc.height = 24;
            npc.scale = 1.1f;
            npc.damage = 20;
            npc.defense = 6;
            npc.lifeMax = 70;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 24f;
            npc.knockBackResist = 0.9f;
            npc.aiStyle = 1;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.BlueSlime]; //Main.npcFrameCount[2];
            aiType = NPCID.BlueSlime; //537;
            animationType = NPCID.BlueSlime; //537;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.Cavern.Chance * 0.65f;
        }
        public override void NPCLoot()
        {
            Item.NewItem(npc.getRect(), ItemID.StoneBlock, 10);
            Item.NewItem(npc.getRect(), ItemID.Gel, 2 + Main.rand.Next(6)); // 2, 3, 4, 5, 6, or 7
        }
        public override void OnHitPlayer(Player player, int damage, bool crit)
        {
            player.AddBuff(mod.BuffType("BleedingOut"), 550, true);
        }
    }
}
