﻿using SWLOR.Game.Server.Enumeration;
using SWLOR.Game.Server.GameObject;

using NWN;
using SWLOR.Game.Server.NWNX;
using SWLOR.Game.Server.Service;

using static NWN._;

namespace SWLOR.Game.Server.Perk.Weapons
{
    public abstract class ImprovedCriticalBase : IPerkHandler
    {
        public abstract PerkType PerkType { get; }

        public string CanCastSpell(NWCreature oPC, NWObject oTarget, int spellTier)
        {
            return string.Empty;
        }
        
        public int FPCost(NWCreature oPC, int baseFPCost, int spellTier)
        {
            return baseFPCost;
        }

        public float CastingTime(NWCreature oPC, float baseCastingTime, int spellTier)
        {
            return baseCastingTime;
        }

        public float CooldownTime(NWCreature oPC, float baseCooldownTime, int spellTier)
        {
            return baseCooldownTime;
        }

        public int? CooldownCategoryID(NWCreature creature, int? baseCooldownCategoryID, int spellTier)
        {
            return baseCooldownCategoryID;
        }

        public void OnImpact(NWCreature creature, NWObject target, int perkLevel, int spellTier)
        {
        }

        public void OnPurchased(NWCreature creature, int newLevel)
        {
            ApplyFeatChanges(creature, null);
        }

        public void OnRemoved(NWCreature creature)
        {
            ApplyFeatChanges(creature, null);
        }

        public void OnItemEquipped(NWCreature creature, NWItem oItem)
        {
            ApplyFeatChanges(creature, null);
        }

        public void OnItemUnequipped(NWCreature creature, NWItem oItem)
        {
            ApplyFeatChanges(creature, oItem);
        }

        public void OnCustomEnmityRule(NWCreature creature, int amount)
        {
        }

        private void ApplyFeatChanges(NWCreature creature, NWItem oItem)
        {
            NWItem equipped = oItem ?? creature.RightHand;
            RemoveAllFeats(creature);

            // Unarmed check
            NWItem mainHand = creature.RightHand;
            NWItem offHand = creature.LeftHand;
            if (oItem != null && Equals(oItem, mainHand))
            {
                mainHand = (new NWGameObject());
            }
            else if (oItem != null && Equals(oItem, offHand))
            {
                offHand = (new NWGameObject());
            }

            if (!mainHand.IsValid && !offHand.IsValid)
            {
                if (PerkService.GetCreaturePerkLevel(creature, PerkType.ImprovedCriticalMartialArts) > 0)
                {
                    NWNXCreature.AddFeat(creature, FEAT_IMPROVED_CRITICAL_UNARMED_STRIKE);
                }
                return;
            }

            if (oItem != null && Equals(oItem, equipped)) return;

            // All other weapon types
            PerkType perkType;
            switch (equipped.CustomItemType)
            {
                case CustomItemType.Vibroblade: perkType = PerkType.ImprovedCriticalVibroblades; break;
                case CustomItemType.FinesseVibroblade: perkType = PerkType.ImprovedCriticalFinesseVibroblades; break;
                case CustomItemType.Baton: perkType = PerkType.ImprovedCriticalBatons; break;
                case CustomItemType.HeavyVibroblade: perkType = PerkType.ImprovedCriticalHeavyVibroblades; break;
                case CustomItemType.Polearm: perkType = PerkType.ImprovedCriticalPolearms; break;
                case CustomItemType.TwinBlade: perkType = PerkType.ImprovedCriticalTwinVibroblades; break;
                case CustomItemType.MartialArtWeapon: perkType = PerkType.ImprovedCriticalMartialArts; break;
                case CustomItemType.BlasterPistol: perkType = PerkType.ImprovedCriticalBlasterPistols; break;
                case CustomItemType.BlasterRifle: perkType = PerkType.ImprovedCriticalBlasterRifles; break;
                case CustomItemType.Throwing: perkType = PerkType.ImprovedCriticalThrowing; break;
                case CustomItemType.Lightsaber: perkType = PerkType.ImprovedCriticalLightsabers; break;
                case CustomItemType.Saberstaff: perkType = PerkType.ImprovedCriticalSaberstaffs; break;
                default: return;
            }

            if (equipped.GetLocalInt("LIGHTSABER") == true)
            {
                perkType = PerkType.ImprovedCriticalLightsabers;
            }
            
            int perkLevel = PerkService.GetCreaturePerkLevel(creature, perkType);
            int type = equipped.BaseItemType;
            if (perkLevel > 0)
            {
                AddCriticalFeat(creature, type);
            }
        }

        private void RemoveAllFeats(NWCreature creature)
        {
            NWNXCreature.RemoveFeat(creature, FEAT_IMPROVED_CRITICAL_BASTARD_SWORD);
            NWNXCreature.RemoveFeat(creature, FEAT_IMPROVED_CRITICAL_BATTLE_AXE);
            NWNXCreature.RemoveFeat(creature, FEAT_IMPROVED_CRITICAL_CLUB);
            NWNXCreature.RemoveFeat(creature, FEAT_IMPROVED_CRITICAL_DAGGER);
            NWNXCreature.RemoveFeat(creature, FEAT_IMPROVED_CRITICAL_DART);
            NWNXCreature.RemoveFeat(creature, FEAT_IMPROVED_CRITICAL_DIRE_MACE);
            NWNXCreature.RemoveFeat(creature, FEAT_IMPROVED_CRITICAL_DOUBLE_AXE);
            NWNXCreature.RemoveFeat(creature, FEAT_IMPROVED_CRITICAL_DWAXE);
            NWNXCreature.RemoveFeat(creature, FEAT_IMPROVED_CRITICAL_GREAT_AXE);
            NWNXCreature.RemoveFeat(creature, FEAT_IMPROVED_CRITICAL_GREAT_SWORD);
            NWNXCreature.RemoveFeat(creature, FEAT_IMPROVED_CRITICAL_HALBERD);
            NWNXCreature.RemoveFeat(creature, FEAT_IMPROVED_CRITICAL_HAND_AXE);
            NWNXCreature.RemoveFeat(creature, FEAT_IMPROVED_CRITICAL_HEAVY_CROSSBOW);
            NWNXCreature.RemoveFeat(creature, FEAT_IMPROVED_CRITICAL_HEAVY_FLAIL);
            NWNXCreature.RemoveFeat(creature, FEAT_IMPROVED_CRITICAL_KAMA);
            NWNXCreature.RemoveFeat(creature, FEAT_IMPROVED_CRITICAL_KATANA);
            NWNXCreature.RemoveFeat(creature, FEAT_IMPROVED_CRITICAL_KUKRI);
            NWNXCreature.RemoveFeat(creature, FEAT_IMPROVED_CRITICAL_LIGHT_CROSSBOW);
            NWNXCreature.RemoveFeat(creature, FEAT_IMPROVED_CRITICAL_LIGHT_FLAIL);
            NWNXCreature.RemoveFeat(creature, FEAT_IMPROVED_CRITICAL_LIGHT_HAMMER);
            NWNXCreature.RemoveFeat(creature, FEAT_IMPROVED_CRITICAL_LIGHT_MACE);
            NWNXCreature.RemoveFeat(creature, FEAT_IMPROVED_CRITICAL_LONGBOW);
            NWNXCreature.RemoveFeat(creature, FEAT_IMPROVED_CRITICAL_LONG_SWORD);
            NWNXCreature.RemoveFeat(creature, FEAT_IMPROVED_CRITICAL_MORNING_STAR);
            NWNXCreature.RemoveFeat(creature, FEAT_IMPROVED_CRITICAL_RAPIER);
            NWNXCreature.RemoveFeat(creature, FEAT_IMPROVED_CRITICAL_SCIMITAR);
            NWNXCreature.RemoveFeat(creature, FEAT_IMPROVED_CRITICAL_SCYTHE);
            NWNXCreature.RemoveFeat(creature, FEAT_IMPROVED_CRITICAL_SHORTBOW);
            NWNXCreature.RemoveFeat(creature, FEAT_IMPROVED_CRITICAL_SHORT_SWORD);
            NWNXCreature.RemoveFeat(creature, FEAT_IMPROVED_CRITICAL_SHURIKEN);
            NWNXCreature.RemoveFeat(creature, FEAT_IMPROVED_CRITICAL_SICKLE);
            NWNXCreature.RemoveFeat(creature, FEAT_IMPROVED_CRITICAL_SLING);
            NWNXCreature.RemoveFeat(creature, FEAT_IMPROVED_CRITICAL_SPEAR);
            NWNXCreature.RemoveFeat(creature, FEAT_IMPROVED_CRITICAL_STAFF);
            NWNXCreature.RemoveFeat(creature, FEAT_IMPROVED_CRITICAL_THROWING_AXE);
            NWNXCreature.RemoveFeat(creature, FEAT_IMPROVED_CRITICAL_TRIDENT);
            NWNXCreature.RemoveFeat(creature, FEAT_IMPROVED_CRITICAL_TWO_BLADED_SWORD);
            NWNXCreature.RemoveFeat(creature, FEAT_IMPROVED_CRITICAL_UNARMED_STRIKE);
            NWNXCreature.RemoveFeat(creature, FEAT_IMPROVED_CRITICAL_WAR_HAMMER);
            NWNXCreature.RemoveFeat(creature, FEAT_IMPROVED_CRITICAL_WHIP);
        }

        private void AddCriticalFeat(NWCreature creature, int type)
        {
            int feat;

            switch (type)
            {
                case (BaseItemType.BastardSword): feat = FEAT_IMPROVED_CRITICAL_BASTARD_SWORD; break;
                case (BaseItemType.BattleAxe): feat = FEAT_IMPROVED_CRITICAL_BATTLE_AXE; break;
                case (BaseItemType.Club): feat = FEAT_IMPROVED_CRITICAL_CLUB; break;
                case (BaseItemType.Dagger): feat = FEAT_IMPROVED_CRITICAL_DAGGER; break;
                case (BaseItemType.Dart): feat = FEAT_IMPROVED_CRITICAL_DART; break;
                case (BaseItemType.DireMace): feat = FEAT_IMPROVED_CRITICAL_DIRE_MACE; break;
                case (BaseItemType.DoubleAxe): feat = FEAT_IMPROVED_CRITICAL_DOUBLE_AXE; break;
                case (BaseItemType.DwarvenWaraxe): feat = FEAT_IMPROVED_CRITICAL_DWAXE; break;
                case (BaseItemType.GreatAxe): feat = FEAT_IMPROVED_CRITICAL_GREAT_AXE; break;
                case (BaseItemType.GreatSword): feat = FEAT_IMPROVED_CRITICAL_GREAT_SWORD; break;
                case (BaseItemType.Halberd): feat = FEAT_IMPROVED_CRITICAL_HALBERD; break;
                case (BaseItemType.HandAxe): feat = FEAT_IMPROVED_CRITICAL_HAND_AXE; break;
                case (BaseItemType.HeavyCrossBow): feat = FEAT_IMPROVED_CRITICAL_HEAVY_CROSSBOW; break;
                case (BaseItemType.HeavyFlail): feat = FEAT_IMPROVED_CRITICAL_HEAVY_FLAIL; break;
                case (BaseItemType.Kama): feat = FEAT_IMPROVED_CRITICAL_KAMA; break;
                case (BaseItemType.Katana): feat = FEAT_IMPROVED_CRITICAL_KATANA; break;
                case (BaseItemType.Kukri): feat = FEAT_IMPROVED_CRITICAL_KUKRI; break;
                case (BaseItemType.LightCrossBow): feat = FEAT_IMPROVED_CRITICAL_LIGHT_CROSSBOW; break;
                case (BaseItemType.LightFlail): feat = FEAT_IMPROVED_CRITICAL_LIGHT_FLAIL; break;
                case (BaseItemType.LightHammer): feat = FEAT_IMPROVED_CRITICAL_LIGHT_HAMMER; break;
                case (BaseItemType.LightMace): feat = FEAT_IMPROVED_CRITICAL_LIGHT_MACE; break;
                case (BaseItemType.LongBow): feat = FEAT_IMPROVED_CRITICAL_LONGBOW; break;
                case (BaseItemType.LongSword): feat = FEAT_IMPROVED_CRITICAL_LONG_SWORD; break;
                case (BaseItemType.Morningstar): feat = FEAT_IMPROVED_CRITICAL_MORNING_STAR; break;
                case (BaseItemType.Rapier): feat = FEAT_IMPROVED_CRITICAL_RAPIER; break;
                case (BaseItemType.Scimitar): feat = FEAT_IMPROVED_CRITICAL_SCIMITAR; break;
                case (BaseItemType.Scythe): feat = FEAT_IMPROVED_CRITICAL_SCYTHE; break;
                case (BaseItemType.ShortBow): feat = FEAT_IMPROVED_CRITICAL_SHORTBOW; break;
                case (BaseItemType.ShortSword): feat = FEAT_IMPROVED_CRITICAL_SHORT_SWORD; break;
                case (BaseItemType.Shuriken): feat = FEAT_IMPROVED_CRITICAL_SHURIKEN; break;
                case (BaseItemType.Sickle): feat = FEAT_IMPROVED_CRITICAL_SICKLE; break;
                case (BaseItemType.Sling): feat = FEAT_IMPROVED_CRITICAL_SLING; break;
                case (BaseItemType.ShortSpear): feat = FEAT_IMPROVED_CRITICAL_SPEAR; break;
                case (BaseItemType.QuarterStaff): feat = FEAT_IMPROVED_CRITICAL_STAFF; break;
                case (BaseItemType.ThrowingAxe): feat = FEAT_IMPROVED_CRITICAL_THROWING_AXE; break;
                case (BaseItemType.Trident): feat = FEAT_IMPROVED_CRITICAL_TRIDENT; break;
                case (BaseItemType.TwoBladedSword): feat = FEAT_IMPROVED_CRITICAL_TWO_BLADED_SWORD; break;
                case (BASE_ITEM_INVALID): feat = FEAT_IMPROVED_CRITICAL_UNARMED_STRIKE; break;
                case (BaseItemType.Warhammer): feat = FEAT_IMPROVED_CRITICAL_WAR_HAMMER; break;
                case (BaseItemType.Whip): feat = FEAT_IMPROVED_CRITICAL_WHIP; break;
                case (BaseItemType.Lightsaber): feat = FEAT_IMPROVED_CRITICAL_LONG_SWORD; break;
                case (BaseItemType.Saberstaff): feat = FEAT_IMPROVED_CRITICAL_TWO_BLADED_SWORD; break;
                default: return;
            }

            NWNXCreature.AddFeat(creature, feat);
        }

        public bool IsHostile()
        {
            return false;
        }

        public void OnConcentrationTick(NWCreature creature, NWObject target, int perkLevel, int tick)
        {
            
        }
    }
}
