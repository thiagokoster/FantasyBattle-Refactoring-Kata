using System;
using System.Linq;

namespace FantasyBattle
{
    public class Player : Target
    {
        public Inventory Inventory { get; }
        public Stats Stats { get; }

        public Player(Inventory inventory, Stats stats)
        {
            Inventory = inventory;
            Stats = stats;
        }

        public Damage CalculateDamage(Target other)
        {
            int baseDamage = Inventory.Equipment.CalculateBaseDamage();
            float damageModifier = CalculateDamageModifier();
            int totalDamage = (int)Math.Round(baseDamage * damageModifier, 0);
            int soak = GetSoak(other, totalDamage);
            return new Damage(Math.Max(0, totalDamage - soak));
        }

        private float CalculateDamageModifier()
        {
            var equipmentDamageModifier = Inventory.Equipment.CalculateDamageModifier();
            float strengthModifier = Stats.Strength * 0.1f;
            return strengthModifier + equipmentDamageModifier;

        }

        private int GetSoak(Target other, int totalDamage)
        {
            int soak = 0;
            if (other is Player)
            {
                // TODO: Not implemented yet
                //  Add friendly fire
                soak = totalDamage;
            }
            else if (other is SimpleEnemy simpleEnemy)
            {
                soak = (int)Math.Round(
                    simpleEnemy.Armor.DamageSoak *
                    (
                        simpleEnemy.Buffs.Select(x => x.SoakModifier).Sum() + 1
                    ), 0
                );
            }

            return soak;
        }
    }
}