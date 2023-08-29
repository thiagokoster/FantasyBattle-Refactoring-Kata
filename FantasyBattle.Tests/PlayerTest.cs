using System.Collections.Generic;
using FantasyBattle.Items;
using Moq;
using Xunit;

namespace FantasyBattle.Tests
{
    public class PlayerTest
    {
        [Fact]
        public void DamageCalculations()
        {
            // Arrange
            var inventory = new Mock<IInventory>();
            inventory.Setup(i => i.EquipmentBaseDamage()).Returns(20);
            inventory.Setup(i => i.EquipmentDamageModifier()).Returns(5.6F);
           
            var stats = new Stats(1, 0);
            var target = new Mock<ITarget>();

            // Act
            var damage = new Player(inventory.Object, stats).CalculateDamage(target.Object);

            // Assert
            Assert.Equal(114, damage.Amount);
        }

        [Fact]
        public void CalculateDamage_ShouldConsiderArmor_WhenTargetIsSimpleEnemy()
        {
            // Arrange
            var inventory = new Mock<IInventory>();
            inventory.Setup(i => i.EquipmentBaseDamage()).Returns(20);
            inventory.Setup(i => i.EquipmentDamageModifier()).Returns(1.0F);

            var stats = new Stats(2, 5);
            var target = new SimpleEnemy(
                new SimpleArmor(5),
                new List<Buff>(){ new BasicBuff(1.0F, 1.0F)
                });

            var player = new Player(inventory.Object, stats);

            // Act
            var damage = player.CalculateDamage(target);

            // Assert
            Assert.Equal(19, damage.Amount);
        }

        [Fact]
        public void CalculateDamage_CanAttackAnotherPlayer()
        {
            // Arrange
            var inventory = new Mock<IInventory>();
            inventory.Setup(i => i.EquipmentBaseDamage()).Returns(20);
            inventory.Setup(i => i.EquipmentDamageModifier()).Returns(1.0F);
            var stats = new Stats(2, 5);
            var player = new Player(inventory.Object, stats);

            var target = new Player(null,new Stats(0, 20));

            // Act
            var damage = player.CalculateDamage(target);

            // Assert
            Assert.Equal(14, damage.Amount);
        }
    }
}
