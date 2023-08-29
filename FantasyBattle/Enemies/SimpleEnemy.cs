using System;
using System.Collections.Generic;
using System.Linq;
using FantasyBattle.Items;

namespace FantasyBattle
{
    public class SimpleEnemy : ITarget
    {
        public virtual IArmor Armor { get; }
        public virtual List<Buff> Buffs { get; }

        public SimpleEnemy(IArmor armor, List<Buff> buffs)
        {
            Armor = armor;
            Buffs = buffs;
        }

        public int CalculateSoak(int totalDamage)
        {
            return (int)Math.Round(
                    Armor.DamageSoak *
                    (
                        Buffs.Select(x => x.SoakModifier).Sum() + 1
                    ), 0
                );
        }
    }

    public interface Buff
    {
        float SoakModifier { get; }
        float DamageModifier { get; }
    }
}