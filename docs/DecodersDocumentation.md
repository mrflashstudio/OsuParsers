# Navigation
- [Methods](#methods)
    - [BeatmapDecoder's methods](#beatmapdecoders-methods)
        - [Decode(string path)](#beatmapdecoderdecodestring-path)
        - [Decode(IEnumerable\<string\> lines)](#beatmapdecoderdecodeienumerablestring-lines)
        - [Decode(Stream stream)](#beatmapdecoderdecodestream-stream)
    - [StoryboardDecoder's methods](#storyboarddecoders-methods)
        - [Decode(string path)](#storyboarddecoderdecodestring-path)
        - [Decode(IEnumerable\<string\> lines)](#storyboarddecoderdecodeienumerablestring-lines)
        - [Decode(Stream stream)](#storyboarddecoderdecodestream-stream)
    - [ReplayDecoder's methods](#replaydecoders-methods)
        - [Decode(string path)](#replaydecoderdecodestring-path)
        - [Decode(Stream stream)](#replaydecoderdecodestream-stream)
    - [DatabaseDecoder's methods](#databasedecoders-methods)
        - [DecodeOsu(string path)](#databasedecoderdecodeosustring-path)
        - [DecodeOsu(Stream stream)](#databasedecoderdecodeosustream-stream)
        - [DecodeCollection(string path)](#databasedecoderdecodecollectionstring-path)
        - [DecodeCollection(Stream stream)](#databasedecoderdecodecollectionstream-stream)
        - [DecodeScores(string path)](#databasedecoderdecodescoresstring-path)
        - [DecodeScores(Stream stream)](#databasedecoderdecodescoresstream-stream)
        - [DecodePresence(string path)](#databasedecoderdecodepresencestring-path)
        - [DecodePresence(Stream stream)](#databasedecoderdecodepresencestream-stream)
    
Also, see use cases in the [**Usage** section of readme](../README.md#usage).
        
# Methods
# BeatmapDecoder's methods
### BeatmapDecoder.Decode(string path)
Parses the given .osu file, then returns parsed Beatmap.
```cs
Beatmap beatmap = BeatmapDecoder.Decode(@"pathToBeatmap.osu");
```

### BeatmapDecoder.Decode(IEnumerable\<string\> lines)
Parses the given array containing beatmap data, then returns parsed Beatmap.
```cs
Beatmap beatmap = BeatmapDecoder.Decode(File.ReadAllLines(@"pathToBeatmap.osu"));
```

### BeatmapDecoder.Decode(Stream stream)
Parses the given stream containing beatmap data, then returns parsed Beatmap.
```cs
Beatmap beatmap = BeatmapDecoder.Decode(new FileStream(@"pathToBeatmap.osu", FileMode.Open, FileAccess.Read));
```

# StoryboardDecoder's methods
### StoryboardDecoder.Decode(string path)
Parses the given .osb file, then returns parsed Storyboard.
```cs
Storyboard storyboard = StoryboardDecoder.Decode(@"pathToStoryboard.osb");
```

### StoryboardDecoder.Decode(IEnumerable\<string\> lines)
Parses the given array containing storyboard data, then returns parsed Storyboard.
```cs
Storyboard storyboard = StoryboardDecoder.Decode(File.ReadAllLines(@"pathToStoryboard.osb"));
```

### StoryboardDecoder.Decode(Stream stream)
Parses the given stream containing storyboard data, then returns parsed Storyboard.
```cs
Storyboard storyboard = StoryboardDecoder.Decode(new FileStream(@"pathToStoryboard.osb", FileMode.Open, FileAccess.Read));
```

# ReplayDecoder's methods
### ReplayDecoder.Decode(string path)
Parses the given .osr file, then returns the parsed Replay.
```cs
Replay replay = ReplayDecoder.Decode(@"pathToReplay.osr");
```

### ReplayDecoder.Decode(Stream stream)
Parses the given stream containing replay data, then returns the parsed Replay.
```cs
Replay replay = ReplayDecoder.Decode(new FileStream(@"pathToReplay.osr", FileMode.Open, FileAccess.Read));
```

# DatabaseDecoder's methods
### DatabaseDecoder.DecodeOsu(string path)
Parses the given osu!.db file, then returns parsed OsuDatabase.
```cs
OsuDatabase osuDatabase = DatabaseDecoder.DecodeOsu(@"pathToOsuDatabase.osb");
```

### DatabaseDecoder.DecodeOsu(Stream stream)
Parses the given stream containing osu!.db data, then returns parsed OsuDatabase.
```cs
OsuDatabase osuDatabase = DatabaseDecoder.DecodeOsu(new FileStream(@"pathToOsuDatabase.osb", FileMode.Open, FileAccess.Read));
```

### DatabaseDecoder.DecodeCollection(string path)
Parses the given collection.db file, then returns parsed CollectionDatabase.
```cs
CollectionDatabase collectionDatabase = DatabaseDecoder.DecodeCollection(@"pathToCollectionDb.db");
```

### DatabaseDecoder.DecodeCollection(Stream stream)
Parses the given stream containing collection.db data, then returns parsed CollectionDatabase.
```cs
CollectionDatabase collectionDatabase = DatabaseDecoder.DecodeCollection(new FileStream(@"pathToCollectionDb.db", FileMode.Open, FileAccess.Read));
```

### DatabaseDecoder.DecodeScores(string path)
Parses the given stream containing scores.db data, then returns parsed ScoresDatabase.
```cs
ScoresDatabase scoresDatabase = DatabaseDecoder.DecodeScores(@"pathToScoresDb.db");
```

### DatabaseDecoder.DecodeScores(Stream stream)
Parses the given scores.db file, then returns parsed ScoresDatabase.
```cs
ScoresDatabase scoresDatabase = DatabaseDecoder.DecodeScores(new FileStream(@"pathToScoresDb.db", FileMode.Open, FileAccess.Read));
```

### DatabaseDecoder.DecodePresence(string path)
Parses the given presence.db file, then returns the parsed PresenceDatabase.
```cs
PresenceDatabase presenceDatabase = DatabaseDecoder.DecodePresence(@"pathToPresenceDb.db");
```

### DatabaseDecoder.DecodePresence(Stream stream)
Parses the given stream containing presence.db data, then returns the parsed PresenceDatabase.
```cs
PresenceDatabase presenceDatabase = DatabaseDecoder.DecodePresence(new FileStream(@"pathToPresenceDb.db", FileMode.Open, FileAccess.Read));
```
