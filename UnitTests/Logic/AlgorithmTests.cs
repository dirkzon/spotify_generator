using SpotifyGenerator.Logic;
using System.Collections.Generic;
using Xunit;

namespace SpotifyGenerator.Tests.Logic
{
    public class AlgorithmTests
    {
        public List<double> answers = new List<double>();

        [Fact]
        public void ShouldGiveNormalValue()
        {
            //Arrange
            answers.Add(0.5);
            var expected = 0.75;
            //Act
            var actual = Algorithm.GetValue(answers, 1);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldWorkWithNegativeValues()
        {
            //Arrange
            answers.Add(0.5);
            var expected = -0.25;
            //Act
            var actual = Algorithm.GetValue(answers, -1);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldWorkWith0()
        {
            //Arrange
            answers.Add(0.5);
            var expected = 0.25;
            //Act
            var actual = Algorithm.GetValue(answers, 0);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldWorkWithAlotOfValues()
        {
            //Arrange
            var expected = 0.48;
            answers.Add(0.3);
            answers.Add(0.85);
            answers.Add(0.16);
            answers.Add(0.67);
            //Act
            var actual = Algorithm.GetValue(answers, 0.4);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldWorkWithNoValuesInList()
        {
            //Arrange
            var expected = 0.75;
            //Act
            var actual = Algorithm.GetValue(answers, 0.75);
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
