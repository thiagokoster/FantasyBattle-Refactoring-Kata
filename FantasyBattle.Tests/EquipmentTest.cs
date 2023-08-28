using Xunit;

namespace FantasyBattle.Tests
{
	public class EquipmentTest
	{
		public EquipmentTest()
		{
		}

        [Fact]
		public void CalculateBaseDamage_ShouldReturn_WhenFullSet()
		{
            // Arrange
            var equipment = new Equipment(
                    new BasicItem("round shield", 0, 1.4f),
                    new BasicItem("excalibur", 20, 1.5f),
                    new BasicItem("helmet of swiftness", 0, 1.2f),
                    new BasicItem("boots", 0, 0.1f),
                    new BasicItem("breastplate of steel", 0, 1.4f)
                    );

            // Act
            var damage = equipment.CalculateBaseDamage();

            // Assert
            Assert.Equal(20, damage);
        }
    }
}

