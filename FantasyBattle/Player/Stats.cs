namespace FantasyBattle
{
    public class Stats
    {
        public virtual int Strength { get; }
        public virtual int Dexterity { get; }

        public Stats(){}

        public Stats(int strength, int dexterity)
        {
            Strength = strength;
            Dexterity = dexterity;
        }

        public float CalculateDamageModifier()
        {
            float strengthModifier = Strength * 0.1f;
            float dexterityModifier = Dexterity * 0.05f;
            return strengthModifier + dexterityModifier;
        }

        public float CalculateSoak()
        {
            float dexterityModifier = Dexterity * 0.05f;
            return dexterityModifier;
        }
    }
}