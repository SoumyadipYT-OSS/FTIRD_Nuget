using System;
using Xunit;
using FTI.Statistics;

namespace StatisticsNET.Tests
{
    public class StatsTests
    {
        private const double Tolerance = 1e-9; // Define a tolerance level for floating-point comparisons

        [Fact]
        public void Mean_ShouldReturnCorrectResult()
        {
            // Arrange
            var data = new List<double> { 1, 2, 3, 4, 5 };

            // Act
            var result = Stats.Mean(data);

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void FMean_ShouldReturnCorrectResult()
        {
            // Arrange
            var data = new List<double> { 1, 2, 3, 4, 5 };

            // Act
            var result = Stats.FMean(data);

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void GeometricMean_ShouldReturnCorrectResult()
        {
            // Arrange
            var data = new List<double> { 1, 3, 9 };

            // Act
            var result = Stats.GeometricMean(data);

            // Assert
            Assert.Equal(3, result, 1);
        }

        [Fact]
        public void HarmonicMean_ShouldReturnCorrectResult()
        {
            // Arrange
            var data = new List<double> { 40, 60 };

            // Act
            var result = Stats.HarmonicMean(data);

            // Assert
            Assert.True(Math.Abs(result - 48) < Tolerance); // Use tolerance for floating-point comparison
        }

        [Fact]
        public void HarmonicMean_WithWeights_ShouldReturnCorrectResult()
        {
            // Arrange
            var data = new List<double> { 40, 60 };
            var weights = new List<double> { 5, 30 };

            // Act
            var result = Stats.HarmonicMean(data, weights);

            // Assert
            Assert.Equal(56, result);
        }



        private const double ToleranceKDE = 1e-6; // Adjust as needed

        [Fact]
        public void Kde_ShouldReturnPDF()
        {
            // Arrange
            double[] data = [-2.1, -1.3, -0.4, 1.9, 5.1, 6.2];
            double[] evalPoints = [-7.5, -2.0, 0.0, 2.0, 5.0, 11.0]; // Separate evalPoints and testPoints
            double h = 1.5;
            string kernel = "normal";

            // Act
            double[] pdfValues = Stats.Kde(data, evalPoints, h, kernel: kernel);

            // Expected values (from Python scipy.stats - CRITICAL: Replace with your actual values)
            double[] expectedValues = [7.72402702961225E-05, 0.110587947176061, 0.109882139944976, 0.0676703221993142, 0.081730125988322, 0.000284270427082346];

            // Assert - Method 1 (individual comparisons with tolerance)
            for (int i = 0; i < evalPoints.Length; i++) // Iterate over evalPoints
            {
                double actual = pdfValues[i];
                Console.WriteLine($"Eval Point: {evalPoints[i]}, Expected: {expectedValues[i]}, Actual: {actual}");
                Assert.True(Math.Abs(actual - expectedValues[i]) < ToleranceKDE, $"PDF assertion failed for x = {evalPoints[i]}");
            }

            // Assert - Method 2 (optional: sequence equality if evalPoints and testPoints are the same)
            //if (evalPoints.SequenceEqual(testPoints)) // Only if evalPoints and testPoints are identical
            //{
            //    Assert.True(pdfValues.SequenceEqual(expectedValues), "PDF sequences do not match.");
            //}
        }

        [Fact]
        public void Kde_ShouldReturnCDF()
        {
            // Arrange
            double[] data = [-2.1, -1.3, -0.4, 1.9, 5.1, 6.2];
            double[] evalPoints = [-7.5, -2.0, 0.0, 2.0, 5.0, 11.0]; // Separate evalPoints and testPoints
            double h = 1.5;
            string kernel = "normal";

            // Act
            double[] cdfValues = Stats.Kde(data, evalPoints, h, kernel: kernel, cumulative: true);

            // Expected values (from Python scipy.stats - CRITICAL: Replace with your actual values)
            double[] expectedValues = [0, 0.304116854734167, 1.2503203452, 3.70874921784864, 13.0355471292534, 71.5737668331926];

            // Assert - Method 1 (individual comparisons with tolerance)
            for (int i = 0; i < evalPoints.Length; i++) // Iterate over evalPoints
            {
                double actual = cdfValues[i];
                Console.WriteLine($"Eval Point: {evalPoints[i]}, Expected: {expectedValues[i]}, Actual: {actual}");
                Assert.True(Math.Abs(actual - expectedValues[i]) < ToleranceKDE, $"CDF assertion failed for x = {evalPoints[i]}");
            }

            // Assert - Method 2 (optional: sequence equality if evalPoints and testPoints are the same)
            //if (evalPoints.SequenceEqual(testPoints)) // Only if evalPoints and testPoints are identical
            //{
            //    Assert.True(cdfValues.SequenceEqual(expectedValues), "CDF sequences do not match.");
            //}
        }
    }
}
