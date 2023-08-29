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
            return totalDamage / 2 + (int)Stats.CalculateSoak();
        }

        private float CalculateDamageModifier()
        {
            var equipmentDamageModifier = Inventory.EquipmentDamageModifier();
            return Stats.CalculateDamageModifier() + equipmentDamageModifier;
        }

        private int GetSoak(ITarget other, int totalDamage)
        {
            return other.CalculateSoak(totalDamage);
        }
    }
}