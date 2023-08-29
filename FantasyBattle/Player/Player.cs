using System;

namespace FantasyBattle
{
    public class Player : ITarget
    {
        public IInventory Inventory { get; }
        public Stats Stats { get; }

        public Player(IInventory inventory, Stats stats)
        {
            Inventory = inventory;
            Stats = stats;
        }

        public Damage CalculateDamage(ITarget other)
        {
            int baseDamage = Inventory.EquipmentBaseDamage();
            float damageModifier = CalculateDamageModifier();
            int totalDamage = (int)Math.Round(baseDamage * damageModifier, 0);
            int soak = GetSoak(other, totalDamage);
            return new Damage(Math.Max(0, totalDamage - soak));
        }

        public int CalculateSoak(int totalDamage)
        {
            // TODO: Not implemented yet
            //  Add friendly fire
            return totalDamage;
        }

        private float CalculateDamageModifier()
        {
            var equipmentDamageModifier = Inventory.EquipmentDamageModifier();
            float strengthModifier = Stats.Strength * 0.1f;
            return strengthModifier + equipmentDamageModifier;
        }

        private int GetSoak(ITarget other, int totalDamage)
        {
            return other.CalculateSoak(totalDamage);
        }
    }
}