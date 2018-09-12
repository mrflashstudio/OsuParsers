# OsuBeatmapParser
.osu file format parser library written in C#

Feel free to use it and report any issues you might run into.

Cuz, you know, i might have broke something in the last few commits ;)

# Installation
NuGet package and releases are coming soon!™

# Building and Requirements
Coming soon!™

# Usage
```
using OsuBeatmapParser;

namespace SomeNamespace
{
    class Program
    {
        public static void Main(string[] args)
        {
            Parser parser = new Parser(@"beatmapPath.osu");
            
            //for example, if we want to print beatmap's title
            System.Console.WriteLine(parser.Beatmap.MetadataSection.TitleUnicode);
        }
    }
}
```

# Beatmap properties
Coming soon!™
