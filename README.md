# MiniAnalyzer
MiniAnalyzer is an analysis tool for [MiniProfiler](https://miniprofiler.com) results.

## How to Get MiniProfiler Analysis Result for MiniAnalyzer
When you completed your profiling with MiniProfiler, simply serialize your MiniProfiler instance with:

```CSharp
string json = miniProfiler.ToJson(); // ToJson() method can be found in StackExchange.Profiling.Internal.ExtensionMethods class
```

## How to Open MiniProfiler JSON Result on MiniAnalyzer
You can open MiniProfiler JSON result on MiniAnalyzer in two ways:

**1. Loading a JSON File:** Useful when you serialized one MiniProfiler instance into a JSON file.  
**2. Loading a JSON Text:** Useful when you serialized multiple MiniProfiler instances into one file and want to analyze one of them.
