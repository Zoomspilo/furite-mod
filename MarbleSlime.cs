using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace FuriteMod.NPCs
{
    public class MarbleSlime : ModNPC //ModNPC makes it a custom NPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Marble Slime");
        }
        public override void SetDefaults()
        {
            npc.width = 32;
            npc.height = 24;
            npc.damage = 20;
            npc.defense = 6;
            npc.lifeMax = 70;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 24f;
            npc.knockBackResist = 1.1f;
            npc.aiStyle = 1;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.SandSlime]; //Main.npcFrameCount[3];
            aiType = NPCID.SandSlime; //537;
            animationType = NPCID.SandSlime; //537;
        }
       
            /*public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.Underground.Chance * 0.65f;
        }*/
    }
}
