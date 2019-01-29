# Navigation
- [Replay properties](#replay-properties)
    - [LifeFrame properties](#lifeframe-properties)
    - [ReplayFrame properties](#replayframe-properties)

Also, see an [official documentation](https://osu.ppy.sh/help/wiki/osu!_File_Formats/Osr_(file_format)).

# Replay properties
| Name           | Type                | Description                                                            |
|----------------|---------------------|------------------------------------------------------------------------|
| Ruleset        | Ruleset             | Ruleset of the replay.                                                 |
| OsuVersion     | int                 | Version of the game when the replay was created.                       |
| BeatmapMD5Hash | string              | osu! beatmap MD5 hash.                                                 |
| PlayerName     | string              | Player name.                                                           |
| ReplayMD5Hash  | string              | osu! replay MD5 hash.                                                  |
| Count300       | ushort              | Number of 300s.                                                        |
| Count100       | ushort              | Number of 100s in standard, 150s in Taiko, 100s in CTB, 200s in mania. |
| Count50        | ushort              | Number of 50s in standard, small fruit in CTB, 50s in mania.           |
| CountGeki      | ushort              | Number of Gekis in standard, Max 300s in mania.                        |
| CountKatu      | ushort              | Number of Katus in standard, 100s in mania.                            |
| CountMiss      | ushort              | Number of misses.                                                      |
| ReplayScore    | int                 | Total score displayed on the score report.                             |
| Combo          | ushort              | Greatest combo displayed on the score report.                          |
| PerfectCombo   | bool                | Perfect/full combo.                                                    |
| Mods           | Mods                | Mods used.                                                             |
| DateTime       | ReplayTimestamp     | Time stamp.                                                            |
| ReplayLength   | int                 | Length in bytes of compressed replay data.                             |
| ReplayFrames   | List\<ReplayFrame\> | Replay data.                                                           |
| LifeFrames     | List\<LifeFrame\>   | Life bar graph data.                                                   |
| Seed           | int                 | RNG seed. (used in replays with osu!mania random mod)                  |
| OnlineId       | long                | Online Score ID                                                        |

### LifeFrame properties
| Name       | Type  | Description                                               |
|------------|-------|-----------------------------------------------------------|
| Time       | int   | Time in ms into the song.                                 |
| Percentage | float | Represents the amount of life you have at the given time. |

### ReplayFrame properties
| Name         | Type         | Description                                                                                   |
|--------------|--------------|-----------------------------------------------------------------------------------------------|
| X            | float        | X-coordinate of the cursor from 0 - 512.                                                      |
| Y            | float        | Y-coordinate of the cursor from 0 - 384.                                                      |
| TimeDiff     | int          | Time in ms since the previous frame.                                                          |
| Time         | int          | Current frame's time in ms.                                                                   |
| StandardKeys | StandardKeys | Represents the osu!standard keys pressed in this frame. (None if Ruleset is not osu!standard) |
| TaikoKeys    | TaikoKeys    | Represents the osu!taiko keys pressed in this frame. (None if Ruleset is not osu!taiko)       |
| CatchKeys    | CatchKeys    | Represents the osu!catch keys pressed in this frame. (None if Ruleset is not osu!catch)       |
| ManiaKeys    | ManiaKeys    | Represents the osu!mania keys pressed in this frame. (None if Ruleset is not osu!mania)       |
