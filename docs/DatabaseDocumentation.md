# Navigation
- [OsuDatabase properties](#osudatabase-properties)
    - [DbBeatmap properties](#dbbeatmap-properties)
        - [DbTimingPoint properties](#dbtimingpoint-properties)
- [CollectionDatabase properties](#collectiondatabase-properties)
    - [Collection properties](#collection-properties)
- [ScoresDatabase properties](#scoresdatabase-properties)
    - [Score properties](#score-properties)
- [PresenceDatabase properties](#presencedatabase-properties)
    - [Player properties](#player-properties)

Also, see an [official documentation](https://osu.ppy.sh/help/wiki/osu!_File_Formats/Db_(file_format)).

# OsuDatabase properties
| Name               | Type            | Description                                                 |
|--------------------|-----------------|-------------------------------------------------------------|
| OsuVersion         | int             | osu! version                                                |
| FolderCount        | int             | Folder count.                                               |
| AccountUnlocked    | bool            | Only false when the account is locked or banned in any way. |
| UnlockDate         | DateTime        | Date the account will be unlocked.                          |
| PlayerName         | string          | Player name.                                                |
| BeatmapCount       | int             | Number of beatmaps.                                         |
| Beatmaps           | List<DbBeatmap> | Aforementioned beatmaps.                                    |
| Permissions        | Permissions     | Represents all permissions you have. (e.g. Supporter)       |
| Write(string path) | void            | Writes this OsuDatabase to the specified path.              |

### DbBeatmap properties
| Name                      | Type                       | Description                                                                                         |
|---------------------------|----------------------------|-----------------------------------------------------------------------------------------------------|
| BytesOfBeatmapEntry       | int                        | Size in bytes of the beatmap entry.                                                                 |
| Artist                    | string                     | Artist name.                                                                                        |
| ArtistUnicode             | string                     | Artist name, in Unicode.                                                                            |
| Title                     | string                     | Song title.                                                                                         |
| TitleUnicode              | string                     | Song title, in Unicode.                                                                             |
| Creator                   | string                     | Creator name.                                                                                       |
| Difficulty                | string                     | Difficulty (e.g. Hard, Insane, etc.)                                                                |
| AudioFileName             | string                     | Audio file name.                                                                                    |
| MD5Hash                   | string                     | MD5 hash of the beatmap.                                                                            |
| FileName                  | string                     | Name of the .osu file corresponding to this beatmap.                                                |
| RankedStatus              | RankedStatus               | Ranked status.                                                                                      |
| CirclesCount              | ushort                     | Number of hitcircles.                                                                               |
| SlidersCount              | ushort                     | Number of sliders.                                                                                  |
| SpinnersCount             | ushort                     | Number of spinners.                                                                                 |
| LastModifiedTime          | DateTime                   | Last modification time.                                                                             |
| ApproachRate              | float                      | Approach rate.                                                                                      |
| CircleSize                | float                      | Circle size.                                                                                        |
| HPDrain                   | float                      | HP drain.                                                                                           |
| OverallDifficulty         | float                      | Overall difficulty.                                                                                 |
| SliderVelocity            | double                     | Slider velocity.                                                                                    |
| StandardStarRating        | Dictionary\<Mods, double\> | Star rating info for osu!standard.                                                                  |
| TaikoStarRating           | Dictionary\<Mods, double\> | Star rating info for osu!taiko.                                                                     |
| CatchStarRating           | Dictionary\<Mods, double\> | Star rating info for osu!catch.                                                                     |
| ManiaStarRating           | Dictionary\<Mods, double\> | Star rating info for osu!mania.                                                                     |
| DrainTime                 | int                        | Drain time, in seconds.                                                                             |
| TotalTime                 | int                        | Total time, in milliseconds.                                                                        |
| AudioPreviewTime          | int                        | Time when the audio preview when hovering over a beatmap in beatmap select starts, in milliseconds. |
| TimingPoints              | List\<DbTimingPoint\>      | Timing points of this beatmap.                                                                      |
| BeatmapId                 | int                        | Beatmap ID.                                                                                         |
| BeatmapSetId              | int                        | Beatmap set ID.                                                                                     |
| ThreadId                  | int                        | Thread ID.                                                                                          |
| StandardGrade             | Grade                      | Grade achieved in osu!standard.                                                                     |
| TaikoGrade                | Grade                      | Grade achieved in osu!taiko.                                                                        |
| CatchGrade                | Grade                      | Grade achieved in osu!catch.                                                                        |
| CatchGrade                | Grade                      | Grade achieved in osu!mania.                                                                        |
| LocalOffset               | short                      | Local beatmap offset.                                                                               |
| StackLeniency             | float                      | Stack leniency.                                                                                     |
| Ruleset                   | Ruleset                    | Ruleset.                                                                                            |
| Source                    | string                     | Song source.                                                                                        |
| Tags                      | string                     | Song tags.                                                                                          |
| OnlineOffset              | short                      | Online offset.                                                                                      |
| TitleFont                 | string                     | Font used for the title of the song.                                                                |
| IsUnplayed                | bool                       | Is beatmap unplayed.                                                                                |
| LastPlayed                | DateTime                   | Last time when beatmap was played.                                                                  |
| IsOsz2                    | bool                       | Is the beatmap osz2.                                                                                |
| FolderName                | string                     | Folder name of the beatmap, relative to Songs folder.                                               |
| LastCheckedAgainstOsuRepo | DateTime                   | Last time when beatmap was checked against osu! repository.                                         |
| IgnoreBeatmapSound        | bool                       | Ignore beatmap sound.                                                                               |
| IgnoreBeatmapSkin         | bool                       | Ignore beatmap skin.                                                                                |
| DisableStoryboard         | bool                       | Disable storyboard.                                                                                 |
| DisableVideo              | bool                       | Disable video.                                                                                      |
| VisualOverride            | bool                       | Visual override.                                                                                    |
| ManiaScrollSpeed          | byte                       | Mania scroll speed                                                                                  |

### DbTimingPoint properties
| Name      | Type   | Description                                                                         |
|-----------|--------|-------------------------------------------------------------------------------------|
| BPM       | double | BPM of this timing point.                                                           |
| Offset    | double | Offset into the song.                                                               |
| Inherited | bool   | Is this timing point inherited. (if false, then this timing point is inherited) (?) |

# CollectionDatabase properties
| Name               | Type               | Description                                           |
|--------------------|--------------------|-------------------------------------------------------|
| OsuVersion         | int                | osu! version                                          |
| CollectionCount    | int                | Number of collections.                                |
| Collections        | List\<Collection\> | Collections.                                          |
| Write(string path) | void               | Writes this CollectionDatabase to the specified path. |

### Collection properties
| Name      | Type           | Description                           |
|-----------|----------------|---------------------------------------|
| Name      | string         | Name of the collection.               |
| Count     | int            | Number of beatmaps in the collection. |
| MD5Hashes | List\<string\> | MD5 hashes of beatmaps.               |

# ScoresDatabase properties
| Name               | Type                             | Description                                                        |
|--------------------|----------------------------------|--------------------------------------------------------------------|
| OsuVersion         | int                              | osu! version                                                       |
| Scores             | List<Tuple<string, List<Score>>> | List with pairs of Beatmap MD5 hash and scores of this beatmap.    |
| Write(string path) | void                             | Writes this ScoresDatabase to the specified path.                  |

### Score properties
| Name           | Type            | Description                                                            |
|----------------|-----------------|------------------------------------------------------------------------|
| Ruleset        | Ruleset         | Ruleset of the score.                                                  |
| OsuVersion     | int             | Version of the game when the score was created.                        |
| BeatmapMD5Hash | string          | osu! beatmap MD5 hash.                                                 |
| PlayerName     | string          | Player name.                                                           |
| ReplayMD5Hash  | string          | osu! replay MD5 hash.                                                  |
| Count300       | ushort          | Number of 300s.                                                        |
| Count100       | ushort          | Number of 100s in standard, 150s in Taiko, 100s in CTB, 200s in mania. |
| Count50        | ushort          | Number of 50s in standard, small fruit in CTB, 50s in mania.           |
| CountGeki      | ushort          | Number of Gekis in standard, Max 300s in mania.                        |
| CountKatu      | ushort          | Number of Katus in standard, 100s in mania.                            |
| CountMiss      | ushort          | Number of misses.                                                      |
| ReplayScore    | int             | Replay score.                                                          |
| Combo          | ushort          | Max combo.                                                             |
| PerfectCombo   | bool            | Perfect/full combo.                                                    |
| Mods           | Mods            | Mods used.                                                             |
| DateTime       | ReplayTimestamp | Time stamp.                                                            |
| ScoreId        | int             | Online Score ID.                                                       |

# PresenceDatabase properties
| Name               | Type           | Description                                         |
|--------------------|----------------|-----------------------------------------------------|
| OsuVersion         | int            | osu! version                                        |
| Players            | List\<Player\> | All players of this database.                       |
| Write(string path) | void           | Writes this PresenceDatabase to the specified path. |

### Player properties
| Name           | Type        | Description                                        |
|----------------|-------------|----------------------------------------------------|
| UserId         | int         | Id of this player.                                 |
| Username       | string      | Player name.                                       |
| Timezone       | int         | Timezone.                                          |
| CountryCode    | byte        | Country code of this player.                       |
| Permissions    | Permissions | Permissions of this player.                        |
| Ruleset        | Ruleset     | Ruleset of this player.                            |
| Longitude      | float       | Longitude of this player.                          |
| Latitude       | float       | Latitude of this player.                           |
| Rank           | int         | Rank of this player.                               |
| LastUpdateTime | DateTime    | When this player was last updated in the database. |
