using FantasyBattle.Items;
using Xunit;

namespace FantasyBattle.Tests
{
	public class EquipmentTest
	{
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

        [Fact]
        public void CalculateBaseDamage_RingShouldNotBeConsidered()
        {
            // Arrange
            var equipment = new Equipment(null, null, null, null, null, new BasicItem("golden ring", 1, 2.0F));

            // Act
            var damage = equipment.CalculateBaseDamage();

            // Assert
            Assert.Equal(0, damage);
        }

        [Fact]
        public void CalculateBaseDamage_ShouldReturnZero_WhenNoEquipment()
        {
            // Arrange
            var equipment = new Equipment(null, null, null, null, null);

            // Act
            var damage = equipment.CalculateBaseDamage();

            // Assert
            Assert.Equal(0, damage);
        }

        [Fact]
        public void CalculateBaseDamage_ShouldReturn_WhenOneEquipment()
        {
            // Arrange
            var equipment = new Equipment(new BasicItem("excalibur", 20, 1.5f),
                null,
                null,
                null,
                null);

            // Act
            var damage = equipment.CalculateBaseDamage();

            // Assert
            Assert.Equal(20, damage);
        }

        [Fact]
        public void CalculateDamageModifier_ShouldReturn_WhenFullSet_AndNoRing()
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
            var modifier = equipment.CalculateDamageModifier();

            // Assert
            Assert.Equal(5.6F, modifier, 3);
        }

        [Fact]
        public void CalculateDamageModifier_ShouldReturn_WhenFullSet_AndRing()
        {
            // Arrange
            var equipment = new Equipment(
                    new BasicItem("round shield", 0, 1.4f),
                    new BasicItem("excalibur", 20, 1.5f),
                    new BasicItem("helmet of swiftness", 0, 1.2f),
                    new BasicItem("boots", 0, 0.1f),
                    new BasicItem("breastplate of steel", 0, 1.4f),
                    new BasicItem("golden ring", 1, 2.0F));

            // Act
            var modifier = equipment.CalculateDamageModifier();

            // Assert
            Assert.Equal(7.6F, modifier, 3);
        }

        [Fact]
        public void CalculateDamageModifier_ShouldReturnZero_WhenNoEquipment()
        {
            // Arrange
            var equipment = new Equipment(null, null, null, null, null);

            // Act
            var modifier = equipment.CalculateDamageModifier();

            // Assert
            Assert.Equal(0, modifier);
        }

        [Fact]
        public void CalculateDamageModifier_ShouldReturn_WhenOneEquipment()
        {
            // Arrange
            var equipment = new Equipment(
                new BasicItem("round shield", 0, 1.4f),
                null,
                null,
                null,
                null);

            // Act
            var modifier = equipment.CalculateDamageModifier();

            // Assert
            Assert.Equal(1.4F, modifier, 3);
        }

        [Fact]
        public void CalculateDamageModifier_ShouldConsiderRing()
        {
            // Arrange
            var equipment = new Equipment(
                null,
                null,
                null,
                null,
                null,
                new BasicItem("golden ring", 1, 2.0F));

            // Act
            var modifier = equipment.CalculateDamageModifier();

            // Assert
            Assert.Equal(2.0F, modifier, 3);
        }
    }
}

