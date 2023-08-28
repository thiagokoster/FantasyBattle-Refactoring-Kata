namespace FantasyBattle
{
    public class Inventory : IInventory
    {
        public virtual Equipment Equipment { get; }

        public Inventory(Equipment equipment)
        {
            Equipment = equipment;
        }

        public int EquipmentBaseDamage()
        {
            return Equipment.CalculateBaseDamage();
        }

        public float EquipmentDamageModifier()
        {
            return Equipment.CalculateDamageModifier();
        }
    }
}