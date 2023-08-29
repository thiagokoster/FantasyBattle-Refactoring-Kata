using FantasyBattle.Items;

namespace FantasyBattle
{
    public class Equipment
    {
        public IItem LeftHand { get; }
        public IItem RightHand { get; }
        public IItem Head { get; }
        public IItem Feet { get; }
        public IItem Chest { get; }
        public IItem Ring { get; }


        public Equipment(IItem leftHand, IItem rightHand, IItem head, IItem feet, IItem chest, IItem ring = null)
        {
            LeftHand = leftHand;
            RightHand = rightHand;
            Head = head;
            Feet = feet;
            Chest = chest;
            Ring = ring;
        }

        public int CalculateBaseDamage()
        {
             return GetBaseDamage(LeftHand) +
                   GetBaseDamage(RightHand) +
                   GetBaseDamage(Head) +
                   GetBaseDamage(Feet) +
                   GetBaseDamage(Chest);
        }

        public float CalculateDamageModifier()
        {
            return GetDamageModifier(LeftHand) +
                   GetDamageModifier(RightHand) +
                   GetDamageModifier(Head) +
                   GetDamageModifier(Feet) +
                   GetDamageModifier(Chest) +
                   GetDamageModifier(Ring);
        }

        private static int GetBaseDamage(IItem item)
        {
            return item is null ? 0 : item.BaseDamage;
        }

        private static float GetDamageModifier(IItem item)
        {
            return item is null ? 0 : item.DamageModifier;
        }
    }
}