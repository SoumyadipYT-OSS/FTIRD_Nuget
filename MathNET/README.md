## MathNET Library


### About

This package will help you to use mathematical functions with ease to 
implement logic with less lines of codes. It gives better performance.

Documentation will be updated soon. Stay connected.

### Release Notes
#### Version 1.0.0 - Initial Release
#### Version 1.3.0 - Latest Stable Release

- Initial release of the MathNET library.
- Provides basic mathematical functions.
- Includes support for .NET Core, .NET Standard, .NET Framework.
- Added dependency on Newtonsoft.Json version 13.0.1.
- Comprehensive documentation and examples included in the README.md file.


## Description
A global library for basic mathematical functions. This package will help you to use mathematical functions with ease to implement logic with fewer lines of code. It gives better performance.

## Installation
To install MathNET, run the following command:

`dotnet add package FTI.MathNET`
or,
`dotnet add package FTI.MathNET --version <version-number>`

#### Distribute Pre-Built DLLs
`csc -reference:FTI.MathNET.dll Program.cs`

#### Restore Packages and Build
`dotnet restore
dotnet build
`


### Usage
Here's an example of how to use the library:
```csharp
using FTI.MathNET;

class Program
{
    static void Main(string[] args)
    {
        int result = Math.Factorial(5);
        Console.WriteLine($"Factorial(5) = {result}");
    }
}
```
------