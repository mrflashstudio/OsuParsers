# Navigation
- [Beatmap properties](#beatmap-properties)  
    - [TimingPoint properties](#timingpoint-properties)  
    - [HitObject properties](#hitobject-properties)  
        - [Circle properties](#circle-properties)  
        - [Slider properties](#slider-properties)  
        - [Spinner properties](#spinner-properties)  
        - [HitObject specific properties](#hitobject-specific-properties)  
        - [HitObject Extras properties](#hitobject-extras-properties)  
    - [General Section properties](#general-section-properties)  
    - [Editor Section properties](#editor-section-properties)  
    - [Metadata Section properties](#metadata-section-properties)  
    - [Difficulty Section properties](#difficulty-section-properties)  
    - [Events Section properties](#events-section-properties)  
        - [Break Event properties](#break-event-properties)
        
Also, see an [official documentation](https://osu.ppy.sh/help/wiki/osu!_File_Formats/Osu_(file_format)).
        
### Beatmap properties
| Name               | Type                 | Description                                |
|--------------------|----------------------|--------------------------------------------|
| Colours            | List\<Color\>        | List of combo colours.                     |
| DifficultySection  | DifficultySection    | Section with difficulty properties.        |
| EditorSection      | EditorSection        | Section with editor properties.            |
| GeneralSection     | GeneralSection       | Section with general properties.           |
| HitObjects         | List\<HitObject\>    | List of all hitobjects.                    |
| MetadataSection    | MetadataSection      | Section with metadata properties.          |
| TimingPoints       | List\<TimingPoints\> | List of all timing points.                 |
| Version            | int                  | .osu file format version (e.g. 12, 14)     |
| Write(string path) | void                 | Writes this Beatmap to the specified path. |

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
Base class for all objects.  

| Name        | Type                    | Description                                                                         |
|-------------|-------------------------|-------------------------------------------------------------------------------------|
| EndTime     | int                     | End time offset of this object.                                                     |
| Extras      | Extras                  | Class which contains Extras properties.                                             |
| HitSound    | HitSoundType            | HitSound of this object (e.g. Normal, Whistle)                                      |
| MaxCombo    | int                     | Never used in code. Should be maximum combo that can be achieved by this hitobject. |
| IsNewCombo  | bool                    | Is it a new combo?                                                                  |
| ComboOffset | int                     | Represents how many combo colours this object is skipping.                          |
| Position    | Point                   | HitObject's position.                                                               |
| StartTime   | int                     | Start time offset of this object.                                                   |

### Circle properties
Represents osu!standard HitCircle. Base class for TaikoHit, CatchFruit and ManiaHit classes.  
Properties are the same as the HitObject's.

### Slider properties
Represents osu!standard Slider. Base class for TaikoDrumroll and CatchDroplets.  

| Name            | Type                                | Description                                                                         |
|-----------------|-------------------------------------|-------------------------------------------------------------------------------------|
| EndTime         | int                                 | End time offset of this object.                                                                   |
| Extras          | Extras                              | Class which contains Extras properties.                                                           |
| HitSound        | HitSoundType                        | HitSound of this object (e.g. Normal, Whistle)                                                     |
| MaxCombo        | int                                 | Never used in code. Should be maximum combo that can be achieved by this hitobject.          |
| IsNewCombo      | bool                                | Is it a new combo?                                                                                 |
| ComboOffset     | int                                 | Represents how many combo colours this object is skipping.                                         |
| Position        | Point                               | HitObject's position.                                                                             |
| StartTime       | int                                 | Start time offset of this object.                                                                 |
| CurveType       | CurveType                           | Curve type of this slider. (e.g. Bezier, Linear)                                                   |
| SliderPoints    | List\<Point\>                       | List of all slider points.                                                                         |
| Repeats         | int                                 | Number of slider repeats.                                                                         |
| PixelLength     | double                              | Slider length in osu! pixels.                                                                     |
| EdgeHitSounds   | List\<HitSoundType\>                | Slider edge HitSound additions.                                                                   |
| EdgeAdditions   | List\<Tuple<SampleSet, SampleSet>\> | Slider edge SampleSet additions.                                                                   |

### Spinner properties
Represents osu!standard Spinner. Base class for TaikoSpinner and CatchSpinner.  
Properties are the same as the HitObject's.

### HitObject specific properties
| HitObject               | Name       | Type       | Description                          |
|-------------------------|------------|------------|--------------------------------------|
| TaikoHit, TaikoDrumroll | IsBig      | bool       | Is this HitObject big?               |
| TaikoHit                | Color      | TaikoColor | Color of taiko hitcircle. (e.g. Red) |
| ManiaHit, ManiaHold     | GetCollumn | int        | Returns column index of this object. |
| ManiaHit, ManiaHold     | SetCollumn | void       | Sets column index.                   |

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
| StoryFireInFront     | bool      | Specifies whether or not display the storyboard in front of combo fire.                    |
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
| Storyboard      | Storyboard       | Storyboard of this beatmap.                                                                    |

### Break Event properties
| Name      | Type | Description                                                                                         |
|-----------|------|-----------------------------------------------------------------------------------------------------|
| StartTime | int  | Number of milliseconds from the beginning of the song defining the start point of the break period. |
| EndTime   | int  | Number of milliseconds from the beginning of the song defining the end point of the break period.   |
