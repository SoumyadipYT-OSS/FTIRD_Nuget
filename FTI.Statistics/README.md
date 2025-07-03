# FTI.Statistics

[![NuGet Version](https://img.shields.io/nuget/v/FTI.Statistics.svg)](https://www.nuget.org/packages/FTI.Statistics/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/FTI.Statistics.svg)](https://www.nuget.org/packages/FTI.Statistics/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![.NET](https://img.shields.io/badge/.NET-Framework_4.8%7CStandard_2.0%7C2.1%7CCore_3.1%7C6%7C7%7C8%7C9-512BD4)](https://dotnet.microsoft.com/)

[![Build Status](https://img.shields.io/badge/build-passing-brightgreen.svg)]()

A comprehensive, high-performance statistics library for .NET providing essential mathematical statistics functions for real-valued numerical data. FTI.Statistics offers robust statistical analysis capabilities with production-ready reliability, comprehensive input validation, and zero external dependencies.

## Table of Contents

- [Key Features](#key-features)
- [Installation](#installation)
- [Framework Support](#framework-support)
- [Platform-Specific Benefits](#platform-specific-benefits)
- [Quick Start Examples](#quick-start-examples)
- [Complete Function Reference](#complete-function-reference)
- [Error Handling](#error-handling)
- [Performance Considerations](#performance-considerations)
- [Best Practices & Common Patterns](#best-practices--common-patterns)
- [Use Cases](#use-cases)
- [Version History](#version-history)
- [License](#license)
- [Contributing](#contributing)
- [Contact & Support](#contact--support)

## Key Features

### Central Tendency & Descriptive Statistics
- **Mean**: Arithmetic, geometric, and harmonic means with optional weights
- **Median**: Standard median with robust median-low and median-high variants
- **Mode**: Single and multi-mode detection for discrete data
- **Summary**: Comprehensive statistical overview (count, mean, std, min, Q1, median, Q3, max)

### Dispersion & Variability Analysis  
- **Variance & Standard Deviation**: Sample and population variants
- **Range**: Simple data range calculation (max - min)
- **Interquartile Range (IQR)**: Robust dispersion measure (Q3 - Q1)
- **Root Mean Square (RMS)**: For signal processing and quality metrics

### Distribution & Percentile Analysis
- **Quantiles**: Flexible n-quantile calculation with exclusive/inclusive methods
- **Percentiles**: Get values at any percentile (0-100) with linear interpolation
- **Grouped Statistics**: Median estimation for binned/grouped data

### Relationships & Correlation
- **Correlation**: Pearson (linear) and Spearman (rank) correlation coefficients
- **Covariance**: Sample covariance for joint variability analysis
- **Linear Regression**: Ordinary least squares with proportional fitting option

### Advanced Statistical Functions
- **Kernel Density Estimation (KDE)**: Multiple kernel types with bandwidth control
- **Normal Distribution**: PDF, CDF calculations with error function approximation
- **Combinatorial Functions**: Binomial and multinomial coefficients
- **Special Functions**: Beta, Gamma, Polygamma, and Riemann Zeta functions

### Robust Design
- **Comprehensive Input Validation**: NaN, Infinity, and edge case handling
- **Consistent Error Handling**: Custom `StatisticsError` for clear error reporting
- **Performance Optimized**: Efficient algorithms with minimal memory allocation
- **Zero Dependencies**: Lightweight package with no external dependencies

## Installation

### Package Manager Console
```powershell
Install-Package FTI.Statistics
```

### .NET CLI
```bash
dotnet add package FTI.Statistics
```

### PackageReference
```xml
<PackageReference Include="FTI.Statistics" Version="1.1.2" />
```

## Framework Support

- ✅ **.NET Framework 4.8** - Legacy Windows applications and enterprise environments
- ✅ **.NET Standard 2.0** - Broad ecosystem compatibility, Unity game development
- ✅ **.NET Standard 2.1** - Enhanced performance features and Xamarin mobile apps
- ✅ .NET Core 3.1
- ✅ .NET 6.0
- ✅ .NET 7.0  
- ✅ .NET 8.0
- ✅ .NET 9.0



### Platform-Specific Benefits
- **Enterprise Legacy Systems**: Full .NET Framework 4.8 support for existing Windows applications
- **Game Development**: Unity compatibility through .NET Standard 2.0
- **Mobile Development**: Xamarin support via .NET Standard 2.0/2.1
- **Cross-Platform**: Linux, macOS, and Windows support with .NET Core/6+
- **Cloud-Native**: Optimized for containerized and serverless deployments
- **IoT & Embedded**: Lightweight deployment for resource-constrained environments



## Quick Start Examples

### Basic Descriptive Statistics
```csharp
using FTI.Statistics;

var data = new List<double> { 1.2, 2.5, 3.1, 4.7, 5.3, 6.8, 7.2, 8.9, 9.1, 10.5 };

// Central tendency
double mean = Stats.Mean(data);                    // 5.83
double median = Stats.Median(data);                // 6.05
double mode = Stats.Mode(new[] { 1, 2, 2, 3, 3, 3 }); // 3

// Dispersion
double range = Stats.Range(data);                  // 9.3
double iqr = Stats.InterquartileRange(data);       // 4.55
double stdev = Stats.Stdev(data);                  // 3.12

// Percentiles
double p25 = Stats.Percentile(data, 25);           // 25th percentile
double p75 = Stats.Percentile(data, 75);           // 75th percentile
double p90 = Stats.Percentile(data, 90);           // 90th percentile
```

### Comprehensive Data Summary
```csharp
var data = new List<double> { 12.5, 15.2, 18.7, 22.1, 25.8, 28.3, 31.9, 35.4, 38.7, 42.1 };

var summary = Stats.Summary(data);
Console.WriteLine(summary);
// Output: Count: 10, Mean: 27.0700, Std: 9.8234, Min: 12.5000, Q1: 19.4000, Median: 27.0500, Q3: 33.6500, Max: 42.1000

// Access individual properties
Console.WriteLine($"Dataset has {summary.Count} points");
Console.WriteLine($"Mean: {summary.Mean:F2}");
Console.WriteLine($"Standard Deviation: {summary.StandardDeviation:F2}");
Console.WriteLine($"Median: {summary.Median:F2}");
```

### Correlation and Regression Analysis
```csharp
var x = new List<double> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
var y = new List<double> { 2.1, 3.9, 6.2, 7.8, 10.1, 12.3, 14.2, 16.1, 18.3, 20.2 };

// Correlation analysis
double pearson = Stats.Correlation(x, y);                    // Pearson correlation
double spearman = Stats.Correlation(x, y, "ranked");         // Spearman correlation
double covariance = Stats.Covariance(x, y);                  // Sample covariance

// Linear regression
var (slope, intercept) = Stats.LinearRegression(x, y);
Console.WriteLine($"y = {slope:F3}x + {intercept:F3}");
```

### Advanced Statistical Functions
```csharp
var data = new double[] { 1.2, 2.3, 2.1, 3.4, 2.8, 3.9, 4.1, 3.7, 4.5, 5.2 };

// Kernel Density Estimation
var evalPoints = new double[] { 1.0, 2.0, 3.0, 4.0, 5.0 };
var kdeResult = Stats.Kde(data, evalPoints, h: 0.5, kernel: "normal");

// Normal distribution
var normalDist = new Stats.NormalDist(mu: 3.0, sigma: 1.5);
double pdf = normalDist.Pdf(2.5);    // Probability density at x=2.5
double cdf = normalDist.Cdf(2.5);    // Cumulative probability at x=2.5

// Combinatorial functions
long binomial = Stats.Binomial(10, 3);                       // 10 choose 3 = 120
long multinomial = Stats.Multinomial(10, new List<int> { 3, 3, 4 }); // Multinomial coefficient
```

### Enterprise Applications
```csharp
// Legacy .NET Framework 4.8 enterprise systems
var performanceMetrics = GetSystemMetrics();
var summary = Stats.Summary(performanceMetrics);
var trend = Stats.LinearRegression(timeStamps, cpuUsage);
```

### Game Development (Unity)
```csharp
// Unity game analytics with .NET Standard 2.0
var playerScores = GetPlayerPerformanceData();
double avgScore = Stats.Mean(playerScores);
double difficulty = Stats.Percentile(playerScores, 75); // Adjust game difficulty
```

### Modern Cloud Applications
```csharp
// .NET 6+ cloud-native microservices
var apiResponseTimes = GetResponseTimeMetrics();
double p95 = Stats.Percentile(apiResponseTimes, 95); // SLA monitoring
var outliers = apiResponseTimes.Where(t => t > Stats.Mean(apiResponseTimes) + 2 * Stats.Stdev(apiResponseTimes));
```


### Working with Different Data Types
```csharp
// Works with various IEnumerable<double> sources
var array = new double[] { 1, 2, 3, 4, 5 };
var list = new List<double> { 1, 2, 3, 4, 5 };
var enumerable = Enumerable.Range(1, 5).Select(x => (double)x);

double arrayMean = Stats.Mean(array);        // All work the same
double listMean = Stats.Mean(list);
double enumerableMean = Stats.Mean(enumerable);

// Robust error handling
try 
{
    Stats.Mean(new double[] { });  // Empty data
}
catch (Stats.StatisticsError ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
```

## Complete Function Reference

### Central Tendency
| Function | Description | Example |
|----------|-------------|---------|
| `Mean()` | Arithmetic mean | `Stats.Mean(data)` |
| `FMean()` | Fast mean with optional weights | `Stats.FMean(data, weights)` |
| `GeometricMean()` | Geometric mean | `Stats.GeometricMean(data)` |
| `HarmonicMean()` | Harmonic mean with optional weights | `Stats.HarmonicMean(data, weights)` |
| `Median()` | Standard median | `Stats.Median(data)` |
| `MedianLow()` | Low median (actual data point) | `Stats.MedianLow(data)` |
| `MedianHigh()` | High median (actual data point) | `Stats.MedianHigh(data)` |
| `MedianGrouped()` | Median for grouped/binned data | `Stats.MedianGrouped(data, interval)` |
| `Mode<T>()` | Most frequent value | `Stats.Mode(data)` |
| `Multimode<T>()` | All most frequent values | `Stats.Multimode(data)` |

### Dispersion & Spread
| Function | Description | Example |
|----------|-------------|---------|
| `Range()` | Data range (max - min) | `Stats.Range(data)` |
| `InterquartileRange()` | IQR (Q3 - Q1) | `Stats.InterquartileRange(data)` |
| `Variance()` | Sample variance | `Stats.Variance(data)` |
| `Pvariance()` | Population variance | `Stats.Pvariance(data)` |
| `Stdev()` | Sample standard deviation | `Stats.Stdev(data)` |
| `Pstdev()` | Population standard deviation | `Stats.Pstdev(data)` |

### Distribution Analysis
| Function | Description | Example |
|----------|-------------|---------|
| `Percentile()` | Value at given percentile | `Stats.Percentile(data, 75)` |
| `Quantiles()` | N-quantile cut points | `Stats.Quantiles(data, 4)` |
| `Summary()` | Comprehensive statistics | `Stats.Summary(data)` |

### Relationships & Correlation
| Function | Description | Example |
|----------|-------------|---------|
| `Correlation()` | Pearson/Spearman correlation | `Stats.Correlation(x, y)` |
| `Covariance()` | Sample covariance | `Stats.Covariance(x, y)` |
| `LinearRegression()` | Linear regression (OLS) | `Stats.LinearRegression(x, y)` |

### Advanced Functions
| Function | Description | Example |
|----------|-------------|---------|
| `Kde()` | Kernel density estimation | `Stats.Kde(data, evalPoints)` |
| `NormalDist` | Normal distribution class | `new Stats.NormalDist(mu, sigma)` |
| `Binomial()` | Binomial coefficient | `Stats.Binomial(n, k)` |
| `Multinomial()` | Multinomial coefficient | `Stats.Multinomial(n, groups)` |

## Error Handling

FTI.Statistics uses a custom `StatisticsError` exception for all statistical errors:

```csharp
try 
{
    var result = Stats.Mean(emptyData);
}
catch (Stats.StatisticsError ex)
{
    // Handle statistical errors (empty data, invalid parameters, etc.)
    Console.WriteLine($"Statistical Error: {ex.Message}");
}
```

Common error scenarios:
- Empty or null data sequences
- Insufficient data points (e.g., variance needs ≥2 points)
- Invalid parameters (e.g., negative percentiles)
- NaN or Infinity values in data
- Mismatched data lengths for paired functions

## Performance Considerations

- **Lazy Evaluation**: Functions accept `IEnumerable<double>` for maximum flexibility
- **Efficient Enumeration**: Data is materialized only when necessary to minimize memory usage
- **Memory Optimization**: Minimal object allocation in hot paths for better GC performance
- **Algorithm Efficiency**: O(n) or O(n log n) complexity for most functions
- **Single-Pass Processing**: Most functions process data in a single enumeration where possible
- **Input Validation**: Comprehensive validation with minimal performance overhead
- **Zero Dependencies**: No external dependencies for lightweight deployment

### Performance Tips
```csharp
// ✅ Good: Use List<double> for multiple operations on the same data
var dataList = data.ToList();
var mean = Stats.Mean(dataList);
var stdev = Stats.Stdev(dataList);

// ⚠️ Avoid: Multiple enumerations of expensive IEnumerable
var expensiveData = database.GetValues(); // Expensive query
var mean = Stats.Mean(expensiveData);     // First enumeration
var stdev = Stats.Stdev(expensiveData);   // Second enumeration - BAD
```

## Best Practices & Common Patterns

### Data Preparation
```csharp
// Always validate and clean your data first
var rawData = GetRawData();
var cleanData = rawData.Where(x => !double.IsNaN(x) && !double.IsInfinity(x)).ToList();

// Use Summary() for initial data exploration
var summary = Stats.Summary(cleanData);
Console.WriteLine($"Data quality check: {summary}");
```

### Efficient Data Processing
```csharp
// Materialize expensive enumerables once
var data = expensiveQuery.ToList();

// Perform multiple analyses efficiently
var stats = new {
    Count = data.Count,
    Mean = Stats.Mean(data),
    Median = Stats.Median(data),
    StdDev = Stats.Stdev(data),
    Range = Stats.Range(data),
    IQR = Stats.InterquartileRange(data)
};
```

### Robust Statistical Analysis
```csharp
// Use IQR and median for robust statistics (less sensitive to outliers)
double robustCenter = Stats.Median(data);
double robustSpread = Stats.InterquartileRange(data);

// Combine with traditional statistics for comprehensive analysis
double traditionalCenter = Stats.Mean(data);
double traditionalSpread = Stats.Stdev(data);

// Detect potential outliers
var outlierThreshold = robustCenter + 1.5 * robustSpread;
var outliers = data.Where(x => Math.Abs(x - robustCenter) > outlierThreshold);
```

## Use Cases

### Business Analytics
```csharp
var salesData = GetMonthlySales();
var summary = Stats.Summary(salesData);
var trend = Stats.LinearRegression(months, salesData);
```

### Quality Control
```csharp
var measurements = GetProductMeasurements();
double mean = Stats.Mean(measurements);
double controlLimit = mean + 3 * Stats.Stdev(measurements);
```

### Research & Data Science
```csharp
var experimentData = GetExperimentResults();
var (slope, intercept) = Stats.LinearRegression(dosage, response);
double correlation = Stats.Correlation(treatment, outcome);
```

## Version History

- **NEW**: Professional logo and enhanced visual branding for better package recognition
- **NEW**: Expanded framework support - Now compatible with 8 major .NET platforms
- **NEW**: Universal compatibility from legacy .NET Framework 4.8 to cutting-edge .NET 9
- Enhanced package presentation and professional identity across NuGet ecosystem
- Optimized for Unity game development, Xamarin mobile apps, and enterprise solutions
- Comprehensive platform support for legacy, modern, and future .NET applications

### Version 1.1.2
- Enhanced XML documentation with comprehensive examples and tooltips
- Improved code comments and developer experience
- Documentation improvements and clarity enhancements
- Better IntelliSense support with detailed parameter descriptions

### Version 1.1.1
- Documentation improvements and usage examples

### Version 1.1.0
- **NEW**: `Range()` - Calculate data range
- **NEW**: `InterquartileRange()` - Calculate IQR for robust dispersion
- **NEW**: `Percentile()` - Get values at any percentile with interpolation  
- **NEW**: `Summary()` - Comprehensive descriptive statistics
- Enhanced performance through optimized enumerable handling
- Improved input validation with NaN/Infinity checking
- Extensive XML documentation with examples
- Removed unused dependencies for lighter package

### Version 1.0.0  
- Initial release with core statistical functions

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contributing

Contributions are welcome! Whether you're fixing bugs, adding features, or improving documentation, your help is appreciated.

### How to Contribute
1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Make your changes with appropriate tests
4. Commit your changes (`git commit -m 'Add amazing feature'`)
5. Push to the branch (`git push origin feature/amazing-feature`)
6. Open a Pull Request

### Development Guidelines
- Follow existing code style and conventions
- Add comprehensive XML documentation for new functions
- Include unit tests for new functionality
- Ensure backward compatibility unless major version change
- Update README.md for new features

### Reporting Issues
- Use the GitHub issue tracker
- Provide clear description and reproduction steps
- Include relevant error messages and stack traces
- Specify .NET version and environment details

## Contact & Support

- **Author**: Soumyadip Majumder
- **NuGet Package**: [FTI.Statistics](https://www.nuget.org/packages/FTI.Statistics/)
- **Issues**: [GitHub Issues](https://github.com/SoumyadipYT-OSS/FTIRD_Nuget/issues)
- **Documentation**: [API Reference](https://github.com/SoumyadipYT-OSS/FTIRD_Nuget/wiki)

### Support
- Check the README and examples first
- Search existing issues before creating new ones
- Use GitHub Discussions for questions and ideas
- Report bugs with detailed reproduction steps

---

© 2025 Soumyadip Majumder, FTIRD. All rights reserved.

**Made with ❤️ for the .NET community**
