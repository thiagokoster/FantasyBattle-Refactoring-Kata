namespace FantasyBattle.Items
{
    public interface IItem
    {
        int BaseDamage { get; }
        float DamageModifier { get; }
    }
}