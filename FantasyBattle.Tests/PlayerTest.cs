using System.Collections.Generic;
using Moq;
using Xunit;

namespace FantasyBattle.Tests
{
    public class PlayerTest
    {
        [Fact]
        public void DamageCalculations()
        {
            var inventory = new Mock<IInventory>();
            inventory.Setup(i => i.EquipmentBaseDamage()).Returns(20);
            inventory.Setup(i => i.EquipmentDamageModifier()).Returns(5.6F);
           
            var stats = new Stats(1);
            var target = new Mock<Target>();

            var damage = new Player(inventory.Object, stats).CalculateDamage(target.Object);
            Assert.Equal(114, damage.Amount);
        }

        [Fact]
        public void CalculateDamage_ShouldConsiderArmor_WhenTargetIsSimpleEnemy()
        {
            var inventory = new Mock<IInventory>();
            inventory.Setup(i => i.EquipmentBaseDamage()).Returns(20);
            inventory.Setup(i => i.EquipmentDamageModifier()).Returns(1.0F);

            var stats = new Stats(1);
            var target = new SimpleEnemy(
                new SimpleArmor(5),
                new List<Buff>(){ new BasicBuff(1.0F, 1.0F)
                });

            var player = new Player(inventory.Object, stats);
            var damage = player.CalculateDamage(target);
            Assert.Equal(12, damage.Amount);
        }
    }
}
