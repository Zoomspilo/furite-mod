using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FuriteMod
{
    public class FuriteGlobalNPC : GlobalNPC //ModNPC makes it a custom NPC
    {
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }
        public override void NPCLoot(NPC npc)
        {
            if (npc.type == NPCID.KingSlime)
            {
                // Place added drops specific to Frankenstein here
                Item.NewItem(npc.getRect(), mod.ItemType("SlimeChunk"), 12 + Main.rand.Next(6)); // 12, 13, 14, 15, 16, or 17
            }
            // Addtional if statements here if you would like to add drops to other vanilla npc.
        }
        public bool bleedOut = false;


        public override void ResetEffects(NPC npc)
        {
            bleedOut = false;
        }
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (bleedOut)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.stepSpeed *= 0.8f;
            }
        }
    }
}
