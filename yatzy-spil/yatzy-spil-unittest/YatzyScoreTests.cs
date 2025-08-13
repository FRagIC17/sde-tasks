using Xunit;
using yatzy_spil; // Make sure namespace matches your main project

namespace yatzy_spil_unittest
{
    public class YatzyScoreTests
    {
        [Fact]
        public void CalculateScore_Ones_ShouldReturnCorrectSum()
        {
            // Arrange
            int[] dice = { 1, 1, 1, 4, 6 };
            int categoryIndex = 0; // Ones

            // Act
            int result = Program.CalculateScore(dice, categoryIndex);

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void CalculateScore_TwoPairs_ShouldReturnCorrectSum()
        {
            // Arrange
            int[] dice = { 3, 3, 5, 5, 6 };
            int categoryIndex = 7; // Two Pairs

            // Act
            int result = Program.CalculateScore(dice, categoryIndex);

            // Assert
            Assert.Equal(16, result);
        }

        [Fact]
        public void CalculateScore_Yatzy_ShouldReturn50()
        {
            // Arrange
            int[] dice = { 6, 6, 6, 6, 6 };
            int categoryIndex = 14; // Yatzy

            // Act
            int result = Program.CalculateScore(dice, categoryIndex);

            // Assert
            Assert.Equal(50, result);
        }

        [Theory]
        [InlineData(new[] { 2, 2, 2, 4, 5 }, 8, 8)] // Fours category
        [InlineData(new[] { 1, 2, 3, 4, 5 }, 10, 15)] // Small Straight
        [InlineData(new[] { 2, 3, 4, 5, 6 }, 11, 20)] // Large Straight
        public void CalculateScore_VariousCases_ShouldReturnExpected(int[] dice, int categoryIndex, int expected)
        {
            // Act
            int result = Program.CalculateScore(dice, categoryIndex);

        }
    }
}