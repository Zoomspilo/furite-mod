using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;


namespace FuriteMod.NPCs.TownNPCs
{
	[AutoloadHead]
	public class Mage : ModNPC
	{
		public override string Texture
		{
			get
			{
				return "FuriteMod/NPCs/TownNPCs/Mage";
			}
		}

		public override bool Autoload(ref string name)
		{
			name = "Mage";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName automatically assigned from .lang files, but the commented line below is the normal approach.
			DisplayName.SetDefault("Mage");
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 700;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 10;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Guide;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			int num = npc.life > 0 ? 1 : 5;
			for (int k = 0; k < num; k++)
			{
				Dust.NewDust(npc.position, npc.width, npc.height, DustID.Blood);
			}
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (player.active)
				{

						if (NPC.downedBoss1 == true)
						{
							return true;
						}
				}
			}
			return false;
		}

		public override string TownNPCName()
		{
			switch (WorldGen.genRand.Next(4))
			{
				case 0:
					return "Ethelbert";
				case 1:
					return "Mortimer";
				case 2:
					return "Artemis";
				default:
					return "Boethias";
			}
		}

		public override void FindFrame(int frameHeight)
		{
			/*npc.frame.Width = 40;
			if (((int)Main.time / 10) % 2 == 0)
			{
				npc.frame.X = 40;
			}
			else
			{
				npc.frame.X = 0;
			}*/
		}

		public override string GetChat()
		{
			int wizardHere = NPC.FindFirstNPC(NPCID.Wizard);
			if (wizardHere >= 0 && Main.rand.Next(9) == 0)
			{
				return "I'm glad you found " + Main.npc[wizardHere].GivenName + ". Now I can learn even more about magic! ";
			}

            int clothierHere = NPC.FindFirstNPC(NPCID.Clothier);
            if (clothierHere >= 0 && Main.rand.Next(9) == 0)
            {
                return "Have you ever wondered how Skeletron's curse works? I've been studying " + Main.npc[clothierHere].GivenName + " ever since he got here, and I'm still stumped.";
            }
            int demolitionistHere = NPC.FindFirstNPC(NPCID.Demolitionist);
            int armsDealerHere = NPC.FindFirstNPC(NPCID.ArmsDealer);
            if (armsDealerHere >= 0 && Main.rand.Next(9) == 0)
            {
                if (demolitionistHere >= 0 && Main.rand.Next(9) == 0)
                {
                    return "Can you tell " + Main.npc[armsDealerHere].GivenName + " and " + Main.npc[demolitionistHere].GivenName + " to stop their ceaseless arguing? It's interrupting my studies!";
                } 
            }

            switch (Main.rand.Next(8))
			{
				case 0:
					return "The people around here are too loud. I can't study without somebody interrupting me!";
                case 1:
                    return "Researching magic is no small task. I constantly risk messing up and, for example, turning myself into a frog. Ribbit!... Uh, you didn't hear that.";
                case 2:
                    return "The pursuit of knowledge feels like my calling, do you feel the same? What do you mean you already know how to create literally everything?";
                case 3:
                    return "If you fancy yourself a Mage, you've come to the right man.";
                default:
					return "Stay still! I accidentally placed a rune somewhere in the vicinity!";
			}
		}

		/* 
		// Consider using this alternate approach to choosing a random thing. Very useful for a variety of use cases.
		// The WeightedRandom class needs "using Terraria.Utilities;" to use
		public override string GetChat()
		{
			WeightedRandom<string> chat = new WeightedRandom<string>();

			int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
			if (partyGirl >= 0 && Main.rand.Next(4) == 0)
			{
				chat.Add("Can you please tell " + Main.npc[partyGirl].GivenName + " to stop decorating my house with colors?");
			}
			chat.Add("Sometimes I feel like I'm different from everyone else here.");
			chat.Add("What's your favorite color? My favorite colors are white and black.");
			chat.Add("What? I don't have any arms or legs? Oh, don't be ridiculous!");
			chat.Add("This message has a weight of 5, meaning it appears 5 times more often.", 5.0);
			chat.Add("This message has a weight of 0.1, meaning it appears 10 times as rare.", 0.1);
			return chat; // chat is implicitly cast to a string. You can also do "return chat.Get();" if that makes you feel better
		}
		*/

		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Language.GetTextValue("LegacyInterface.28");
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				shop = true;
			}
		}

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			shop.item[nextSlot].SetDefaults(mod.ItemType("GlowTome"));
			nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.Book);
            nextSlot++;

            shop.item[nextSlot].SetDefaults(mod.ItemType("TopazPin"));
            nextSlot++;

            shop.item[nextSlot].SetDefaults(mod.ItemType("RubyPin"));
            nextSlot++;

            if (NPC.downedBoss2 == true)
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType("AmethystPin"));
                nextSlot++;

                shop.item[nextSlot].SetDefaults(mod.ItemType("EmeraldPin"));
                nextSlot++;

                shop.item[nextSlot].SetDefaults(mod.ItemType("GlowStaff"));
                nextSlot++;
            }

            if (NPC.downedMechBossAny == true)
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType("DiamondPin"));
                nextSlot++;
            }
		}

		public override void NPCLoot()
		{
			Item.NewItem(npc.getRect(), ItemID.Book, 1);
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 20;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 30;
			randExtraCooldown = 30;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = ProjectileID.WaterBolt;
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 10f;
			randomOffset = 2f;
		}
	}
}