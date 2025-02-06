## FTI.Statistics
FTI.Statistics is a comprehensive library offering a variety of statistical functions to help you perform complex statistical analyses with ease. This library includes functions for calculating basic statistics, measures of spread, advanced statistical measures, combinatorial functions, and special functions.


### Features

#### • Basic Descriptive Statistics

    Median: Calculate the median of a data set.

    Mode: Find the most frequently occurring value in a data set.

    Range: Determine the difference between the maximum and minimum values.

    CountEach: Count the occurrences of each value in a data set.


#### • Measures of Spread and Variability

    Standard Deviation: Compute the standard deviation for sample and population data sets.

    Variance: Calculate the variance for sample and population data sets.

    Root Mean Square (RMS): Calculate the square root of the average of the squares of a set of values. 


#### • Advanced Statistical Measures
    Covariance: Measure the joint variability of two random variables.

    Pearson's Correlation Coefficient: Determine the linear relationship two variables.


#### • Data Representation
    Histogram: Create a histogram by counting the frequency of each value and grouping them into bins.


#### • Statistical Methods
    Least Squares Linear Regression: Find the best-fitting straight line through a set of points.


#### • Combinatorial Functions
    
    Binomial Coefficient: Calculate the number of ways to choose 𝑘 items from 𝑛 items without regard to order.

    Multinomial Coefficient: Generalize the binomial coefficient to partition a set of 𝑛 items into 𝑟 groups.


#### • Special Functions
    Beta Function: Evaluate the beta function for given parameters.

    Digamma Function: Compute the logarithmic derivative of the gamma function.

    Polygamma Function: Calculate the (n+1)th derivative of the logarithm of the gamma function.

    Riemann Zeta Function: Evaluate the Riemann zeta function for a given value.



### Installation

To install the FTI.Statistics NuGet package, use the following command:

```Bash
dotnet add package FTI.Statistics
```


### Usage

#### Example Code

```csharp
using System;
using FTI.Statistics;

class Program
{
    static void Main(string[] args)
    {
        var data = new List<double> {1, 2, 2, 3, 3, 3, 4, 4, 4, 4};

        // Calculate the range
        double range = Statistics.Range(data);
        Console.WriteLine($"Range: {range}");

        // Calculate the root mean square
        double rms = Statistics.RootMeanSquare(data);
        Console.WriteLine($"Root Mean Square: {rms}");

        // Calculate Pearson's correlation coefficient
        var x = new List<double> {1, 2, 3, 4, 5};
        var y = new List<double> {2, 3, 5, 7, 11};
        double correlation = Statistics.PearsonCorrelation(x, y);
        Console.WriteLine($"Pearson's Correlation Coefficient: {correlation}");

        // Create a histogram
        var histogram = Statistics.Histogram(data, 5);
        foreach (var bin in histogram)
        {
            Console.WriteLine($"Range: {bin.Key}, Count: {bin.Value}");
        }
    }
}
```


### Package Version
    - Initial Version: 1.0.0

    Upcoming version will be updated and documentation will come, stay tuned!


Feel free to contact.


Happy Coding!