using yatzy_spil;
using Xunit;

namespace Yatzy_spil_unittest
{
    public class UnitTest1
    {
        [Fact]
        public void AddScore_ShouldIncreaseScore()
        {
            // Arrange
            var player = new Player("Test");

            // Act
            player.AddScore(5);

            // Assert
            Assert.Equal(5, player.score);
        }

        [Fact]
        public void ResetScore_ShouldSetScoreToZero()
        {
            // Arrange
            var player = new Player("Test");
            player.AddScore(10);

            // Act
            player.ResetScore();

            // Assert
            Assert.Equal(0, player.score);
        }
    }
}