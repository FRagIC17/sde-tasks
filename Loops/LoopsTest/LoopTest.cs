namespace LoopsTest
{
    public class LoopTest
    {
        [Fact]
        public void ToThePowerOfNextNumberExpectedOutput()
        {
            // Arrange
            int expected = 3125;

            // Act
            int actual = Loops.Program.ToThePowerOfNextNumber(3, 5);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}