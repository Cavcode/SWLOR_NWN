﻿using System.Collections.Generic;
using SWLOR.Game.Server.Enumeration;
using SWLOR.Game.Server.GameObject;
using SWLOR.Game.Server.NWScript.Enumerations;
using Skill = SWLOR.Game.Server.Enumeration.Skill;

namespace SWLOR.Game.Server.Perk.General
{
	public class SpeedyCrafting : IPerk
	{
		public PerkType PerkType => PerkType.SpeedyCrafting;
		public string Name => "Speedy Crafting";
		public bool IsActive => true;
		public string Description => "Reduces the amount of time it takes to craft items.";
		public PerkCategoryType Category => PerkCategoryType.General;
		public PerkCooldownGroup CooldownGroup => PerkCooldownGroup.None;
		public PerkExecutionType ExecutionType => PerkExecutionType.None;
		public bool IsTargetSelfOnly => false;
		public int Enmity => 0;
		public EnmityAdjustmentRuleType EnmityAdjustmentType => EnmityAdjustmentRuleType.None;
		public ForceBalanceType ForceBalanceType => ForceBalanceType.Universal;
		public Animation CastAnimation => Animation.Invalid;

		public string CanCastSpell(NWCreature oPC, NWObject oTarget, int spellTier)
		{
			return string.Empty;
		}

		public int FPCost(NWCreature oPC, int baseFPCost, int spellTier)
		{
			return baseFPCost;
		}

		public float CastingTime(NWCreature oPC, int spellTier)
		{
			return 0f;
		}

		public float CooldownTime(NWCreature oPC, float baseCooldownTime, int spellTier)
		{
			return baseCooldownTime;
		}

		public void OnImpact(NWCreature creature, NWObject target, int perkLevel, int spellTier)
		{
		}

		public void OnPurchased(NWCreature creature, int newLevel)
		{
		}

		public void OnRemoved(NWCreature creature)
		{
		}

		public void OnItemEquipped(NWCreature creature, NWItem oItem)
		{
		}

		public void OnItemUnequipped(NWCreature creature, NWItem oItem)
		{
		}

		public void OnCustomEnmityRule(NWCreature creature, int amount)
		{
		}

		public bool IsHostile()
		{
			return false;
		}

		public Dictionary<int, PerkLevel> PerkLevels => new Dictionary<int, PerkLevel>
		{
			{
				1, new PerkLevel(2, "+10% Crafting Speed",
				new Dictionary<Skill, int>
				{

				})
			},
			{
				2, new PerkLevel(3, "+20% Crafting Speed",
				new Dictionary<Skill, int>
				{
					
				})
			},
			{
				3, new PerkLevel(4, "+30% Crafting Speed",
				new Dictionary<Skill, int>
				{
					
				})
			},
			{
				4, new PerkLevel(5, "+40% Crafting Speed",
				new Dictionary<Skill, int>
				{
					
				})
			},
			{
				5, new PerkLevel(6, "+50% Crafting Speed",
				new Dictionary<Skill, int>
				{
					
				})
			},
			{
				6, new PerkLevel(7, "+60% Crafting Speed",
				new Dictionary<Skill, int>
				{
					
				})
			},
			{
				7, new PerkLevel(8, "+70% Crafting Speed",
				new Dictionary<Skill, int>
				{
				
				})
			},
			{
				8, new PerkLevel(9, "+80% Crafting Speed",
				new Dictionary<Skill, int>
				{
				
				})
			},
			{
				9, new PerkLevel(10, "+90% Crafting Speed",
				new Dictionary<Skill, int>
				{
					
				})
			},
			{
				10, new PerkLevel(10, "+99% Crafting Speed",
				new Dictionary<Skill, int>
				{
					
				})
			},
		};

		public Dictionary<int, List<PerkFeat>> PerkFeats { get; } = new Dictionary<int, List<PerkFeat>>();


		public void OnConcentrationTick(NWCreature creature, NWObject target, int perkLevel, int tick)
		{

		}
	}
}