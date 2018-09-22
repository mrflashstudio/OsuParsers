# OsuBeatmapParser

.osu file format parser library written in C#

Feel free to use it and report any issues you might run into.  
Cuz, you know, i might have broke something in the last few commits ;)  

- [Installation](#installation)  
- [Building and Requirements](#building-and-requirements)  
- [Usage](#usage)  
- [Beatmap properties](#beatmap-properties)  
    - [TimingPoint properties](#timingpoint-properties)  
    - [HitObject properties](#hitobject-properties)  
        - [HitObject specific properties](#hitobject-specific-properties)  
- [TODO list](#todo-list)

# Installation
NuGet package and releases are coming soon!™

# Building and Requirements
- You need a desktop platform that can compile .NET 4.5
- Clone the repository `git clone https://github.com/mrflashstudio/OsuBeatmapParser`
- And then you can build the project in your IDE.

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
| Name              | Type                 | Description                           |
|-------------------|----------------------|---------------------------------------|
| Colours           | List\<Color\>        | List of combo colours.                |
| DifficultySection | DifficultySection    | Section with difficulty properties.   |
| EditorSection     | EditorSection        | Section with editor properties.       |
| GeneralSection    | GeneralSection       | Section with general properties.      |
| HitObjects        | List\<HitObject\>    | List of all hitobjects.               |
| MetadataSection   | MetadataSection      | Section with metadata properties.     |
| TimingPoints      | List\<TimingPoints\> | List of all timing points.            |
| Version           | int                  | .osu file format version (e.g. 12, 14) |

### TimingPoint properties
| Name            | Type          | Description                                                         |
|-----------------|---------------|---------------------------------------------------------------------|
| BeatLength      | float         | Length of a single beat in ms.                                      |
| CustomSampleSet | int           | Index of custom sound sample.                                       |
| Inherited       | bool          | Is parameters inherited from parent timing point?                   |
| KiaiMode        | bool          | Are we in kiai section right now?                                   |
| Offset          | int           | Offset in ms.                                                       |
| Sample          | SampleSet     | TimingPoint's sample set. (e.g. Normal, Soft)                        |
| TimeSignature   | TimeSignature | Time signature, used in editor. (e.g. SimpleTriple, SimpleQuadruple) |
| Volume          | int           | Volume of samples from 0 to 100.                                    |

### HitObject properties
| Name       | Type                    | Description                                                                         |
|------------|-------------------------|-------------------------------------------------------------------------------------|
| Additions  | List\<object\> probably | Will be added soon!                                                                 |
| EndTime    | int                     | End time offset of this object.                                                     |
| HitSound   | HitSoundType            | HitSound of this object (e.g. Normal, Whistle)                                      |
| MaxCombo   | int                     | Never used in code. Should be maximum combo that can be achieved by this hitobject. |
| IsNewCombo | bool                    | Is it a new combo? (Present in all rulesets, except osu!mania)                      |
| Position   | Point                   | HitObject's position.                                                               |
| StartTime  | int                     | Start time offset of this object.                                                   |

### HitObject specific properties
| HitObject                                  | Name        | Type          | Description                                      |
|--------------------------------------------|-------------|---------------|--------------------------------------------------|
| StandardSlider, CatchSlider                | CurveType   | CurveType     | Curve type of this slider. (e.g. Bezier, Linear) |
| StandardSlider, CatchSlider                | Points      | List\<Point\> | List of all slider points.                       |
| StandardSlider, CatchSlider                | Repeats     | int           | Number of slider repeats.                        |
| StandardSlider, TaikoDrumroll, CatchSlider | PixelLength | int           | Slider length in osu! pixels.                    |
| TaikoHitCircle                             | Color       | TaikoColor    | Color of taiko hitcircle. (e.g. Red)             |
| TaikoHitCircle, TaikoDrumroll              | IsBig       | bool          | Is this HitObject big?                           |
| ManiaHitObject                             | Collumn     | int           | Collumn index of this HitObject.                 |

# TODO list
### High priority
- Documentation
- Cleanup
- Implement Storyboard parser.
### Low priority
- Implement .osb file format parser.
- Implement .osr file format parser.
- Implement .osu/.osb/.osr writer. (idk if that will be useful)
