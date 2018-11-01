# OsuBeatmapParser [![nuget](https://img.shields.io/nuget/v/OsuBeatmapParser.svg)](https://www.nuget.org/packages/OsuBeatmapParser)

.osu file format parser library written in C#

Feel free to use it and report any issues you might run into.  
Cuz, you know, i might have broke something in the last few commits ;)  

- [Installation](#installation)  
- [Building and Requirements](#building-and-requirements)  
- [Usage](#usage)  
- [Methods](#methods)  
    - [ParseBeatmap(path)](#parsebeatmappath)
    - [ParseStoryboard(path)](#parsestoryboardpath)
- [Beatmap properties](#beatmap-properties)  
    - [TimingPoint properties](#timingpoint-properties)  
    - [HitObject properties](#hitobject-properties)  
        - [HitObject specific properties](#hitobject-specific-properties)  
        - [HitObject Extras properties](#hitobject-extras-properties)  
    - [General Section properties](#general-section-properties)  
    - [Editor Section properties](#editor-section-properties)  
    - [Metadata Section properties](#metadata-section-properties)  
    - [Difficulty Section properties](#difficulty-section-properties)  
    - [Events Section properties](#events-section-properties)  
        - [Break Event properties](#break-event-properties)
- [TODO list](#todo-list)

# Installation
Download latest version of parser from [releases](https://github.com/mrflashstudio/OsuBeatmapParser/releases), then add the dll into your project references.  
Or you can just install [NuGet package](https://www.nuget.org/packages/OsuBeatmapParser). (`Install-Package OsuBeatmapParser -Version 1.1.0`)

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
            Parser parser = new Parser();
            Beatmap beatmap = parser.Parse(@"beatmapPath.osu");
            
            //for example, if we want to print beatmap's title
            System.Console.WriteLine(beatmap.MetadataSection.TitleUnicode);
        }
    }
}
```

# Methods
### ParseBeatmap(path)
Parses the given .osu file, then returns parsed Beatmap.
```
Parser parser = new Parser();
Beatmap beatmap = parser.ParseBeatmap(@"pathToBeatmap.osu");
```

### ParseStoryboard(path)
Parses the given .osb file, then returns parsed Storyboard.
```
Parser parser = new Parser();
Storyboard storyboard = parser.ParseStoryboard(@"pathToStoryboard.osb");
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
| EndTime    | int                     | End time offset of this object.                                                     |
| Extras     | HitObjectExtras         | Class which contains Extras properties.                                             |
| HitSound   | HitSoundType            | HitSound of this object (e.g. Normal, Whistle)                                      |
| MaxCombo   | int                     | Never used in code. Should be maximum combo that can be achieved by this hitobject. |
| IsNewCombo | bool                    | Is it a new combo? (Present in all rulesets, except osu!mania)                      |
| Position   | Point                   | HitObject's position.                                                               |
| StartTime  | int                     | Start time offset of this object.                                                   |

### HitObject specific properties
| HitObject                                  | Name          | Type                          | Description                                      |
|--------------------------------------------|---------------|-------------------------------|--------------------------------------------------|
| StandardSlider, CatchSlider                | CurveType     | CurveType                     | Curve type of this slider. (e.g. Bezier, Linear) |
| StandardSlider, CatchSlider                | Points        | List\<Point\>                 | List of all slider points.                       |
| StandardSlider, CatchSlider                | Repeats       | int                           | Number of slider repeats.                        |
| StandardSlider, TaikoDrumroll, CatchSlider | PixelLength   | int                           | Slider length in osu! pixels.                    |
| StandardSlider, TaikoDrumroll, CatchSlider | EdgeHitSounds | HitSoundType[]                | Slider edge HitSound additions.                  |
| StandardSlider, TaikoDrumroll, CatchSlider | EdgeAdditions | Tuple<SampleSet, SampleSet>[] | Slider edge SampleSet additions.                 |
| TaikoHitCircle                             | Color         | TaikoColor                    | Color of taiko hitcircle. (e.g. Red)             |
| TaikoHitCircle, TaikoDrumroll              | IsBig         | bool                          | Is this HitObject big?                           |
| ManiaHitObject                             | Collumn       | int                           | Collumn index of this HitObject.                 |

### HitObject Extras properties
| Name           | Type      | Description                                                                             |
|----------------|-----------|-----------------------------------------------------------------------------------------|
| SampleSet      | SampleSet | SampleSet that changes the sample set of the normal HitSound.                           |
| AdditionSet    | SampleSet | SampleSet that changes the sample set for the other hit sounds. (whistle, finish, clap) |
| CustomIndex    | int       | Custom SampleSet index. (e.g. 3 in soft-hitnormal3.wav)                                 |
| Volume         | int       | Volume of the sample from 0 to 100.                                                     |
| SampleFileName | string    | This names an audio file in the folder to play instead of sounds from SampleSets.       |

### General Section properties
| Name                 | Type      | Description                                                                                |
|----------------------|-----------|--------------------------------------------------------------------------------------------|
| AudioFilename        | string    | Specifies the location of the audio file relative to the current folder.                   |
| AudioLeadIn          | int       | The amount of time added before the audio file begins playing.                             |
| PreviewTime          | int       | Defines when the audio file should begin playing when selected in the song selection menu. |
| Countdown            | bool      | Specifies whether or not a countdown occurs before the first hit object appears.           |
| SampleSet            | SampleSet | Specifies which set of hit sounds will be used throughout the beatmap.                     |
| StackLeniency        | float     | Is how often closely placed hit objects will be stacked together.                          |
| Mode                 | Ruleset   | Defines the game mode of the beatmap.                                                      |
| ModeId               | int       | Id of the game mode. (0=osu!, 1=Taiko, 2=Catch the Beat, 3=osu!mania)                      |
| LetterboxInBreaks    | bool      | Specifies whether the letterbox appears during breaks.                                     |
| WidescreenStoryboard | bool      | Specifies whether or not the storyboard should be widescreen.                              |
| SpecialStyle         | bool      | Specifies whether or not use the special N+1 style for osu!mania.                          |
| EpilepsyWarning      | bool      | Specifies whether or not show a epilepsy warning at the beginning of the beatmap.          |
| UseSkinSprites       | bool      | Specifies whether or not the storyboard can use user's skin resources.                     |
| CirclesCount         | int       | Total amount of HitCircles in the beatmap.                                                 |
| SlidersCount         | int       | Total amount of Sliders in the beatmap.                                                    |
| SpinnerCount         | int       | Total amount of Spinners in the beatmap.                                                   |
| Length               | int       | Beatmap length in ms.                                                                      |

### Editor Section properties
| Name            | Type   | Description                                                 |
|-----------------|--------|-------------------------------------------------------------|
| Bookmarks       | int[]  | Array of times of editor bookmarks.                         |
| BookmarksString | string | A list of comma-separated times of editor bookmarks.        |
| DistanceSpacing | float  | A multiplier for the "Distance Snap" feature.               |
| BeatDivisor     | int    | Specifies the beat division for placing objects.            |
| GridSize        | int    | Specifies the size of the grid for the "Grid Snap" feature. |
| TimelineZoom    | float  | Specifies the zoom in the editor timeline.                  |

### Metadata Section properties
| Type          | Name     | Description                                                |
|---------------|----------|------------------------------------------------------------|
| Title         | string   | The title of the song limited to ASCII characters.         |
| TitleUnicode  | string   | The title of the song with unicode support.                |
| Artist        | string   | The name of the song's artist limited to ASCII characters. |
| ArtistUnicode | string   | The name of the song's artist with unicode support.        |
| Creator       | string   | The username of the mapper.                                |
| Version       | string   | the name of the beatmap's difficulty.                      |
| Source        | string   | Describes the origin of the song.                          |
| Tags          | string[] | Array of words describing the song.                        |
| TagsString    | string   | String of words describing the song.                       |
| BeatmapID     | int      | The ID of the single beatmap.                              |
| BeatmapSetID  | int      | The ID of the beatmap set.                                 |

### Difficulty Section properties
| Name              | Type  | Description                                                                                    |
|-------------------|-------|------------------------------------------------------------------------------------------------|
| HPDrainRate       | float | Specifies how fast the health decreases.                                                       |
| CircleSize        | float | Defines the size of the hit objects in the osu!standard mode. (number of columns in osu!mania) |
| OverallDifficulty | float | The harshness of the hit window and the difficulty of spinners.                                |
| ApproachRate      | float | Defines when hit objects start to fade in relatively to when they should be hit.               |
| SliderMultiplier  | float | Specifies the multiplier of the slider velocity.                                               |
| SliderTickRate    | float | The number of ticks per beat.                                                                  |

### Events Section properties
| Name            | Type             | Description                                                                                    |
|-----------------|------------------|------------------------------------------------------------------------------------------------|
| BackgroundImage | string           | The filename specifies the location of the background image relative to the beatmap directory. |
| Video           | string           | The filename specifies the location of the video relative to the beatmap directory.            |
| VideoOffset     | int              | Video offset in ms.                                                                            |
| Breaks          | List<BreakEvent> | List of break periods.                                                                         |

### Break Event properties
| Name      | Type | Description                                                                                         |
|-----------|------|-----------------------------------------------------------------------------------------------------|
| StartTime | int  | Number of milliseconds from the beginning of the song defining the start point of the break period. |
| EndTime   | int  | Number of milliseconds from the beginning of the song defining the end point of the break period.   |

# TODO list
### Low priority
- Implement .osr file format parser.
- Implement .osu/.osb/.osr writer. (idk if that will be useful)
