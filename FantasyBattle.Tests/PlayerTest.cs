using Moq;
using Xunit;

namespace FantasyBattle.Tests
{
    public class PlayerTest
    {
        [Fact]
        public void DamageCalculations()
        {
            var inventory = new Mock<Inventory>();
            inventory.Setup(i => i.Equipment).Returns(
                new Equipment(
                    new BasicItem("round shield", 0, 1.4f),
                    new BasicItem("excalibur", 20, 1.5f),
                    new BasicItem("helmet of swiftness", 0, 1.2f),
                    new BasicItem("boots", 0, 0.1f),
                    new BasicItem("breastplate of steel", 0, 1.4f)
                    )
                );

            var stats = new Stats(1);
            var target = new Mock<Target>();

            var damage = new Player(inventory.Object, stats).CalculateDamage(target.Object);
            Assert.Equal(114, damage.Amount);
        }
    }
}
