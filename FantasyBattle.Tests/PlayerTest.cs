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
    }
}
