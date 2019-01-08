# Navigation
- [Methods](#methods)  
    - [ParseBeatmap(path)](#parsebeatmappath)
    - [ParseStoryboard(path)](#parsestoryboardpath)
    - [ParseReplay(path)](#parsereplaypath)
    - [ParseOsuDatabase(path)](#parseosudatabasepath)
    - [ParseCollectionDatabase(path)](#parsecollectiondatabasepath)
    - [ParseScoresDatabase(path)](#parsescoresdatabasepath)
    - [ParsePresenceDatabase(path)](#parsepresencedatabasepath)  
    
Also, see use cases in the [**Usage** section of readme](README.md#usage).
        
# Methods
### ParseBeatmap(path)
Parses the given .osu file, then returns parsed Beatmap.
```cs
Beatmap beatmap = Parser.ParseBeatmap(@"pathToBeatmap.osu");
```

### ParseStoryboard(path)
Parses the given .osb file, then returns parsed Storyboard.
```cs
Storyboard storyboard = Parser.ParseStoryboard(@"pathToStoryboard.osb");
```

### ParseReplay(path)
Parses the given .osr file, then returns the parsed Replay.
```cs
Replay replay = Parser.ParseReplay(@"pathToReplay.osr");
```

### ParseOsuDatabase(path)
Parses the given osu!.db file, then returns parsed OsuDatabase.
```cs
OsuDatabase osuDatabase = Parser.ParseOsuDatabase(@"pathToOsuDatabase.osb");
```

### ParseCollectionDatabase(path)
Parses the given collection.db file, then returns parsed CollectionDatabase.
```cs
CollectionDatabase collectionDatabase = Parser.ParseCollectionDatabase(@"pathToCollectionDb.db");
```

### ParseScoresDatabase(path)
Parses the given scores.db file, then returns parsed ScoresDatabase.
```cs
ScoresDatabase scoresDatabase = Parser.ParseScoresDatabase(@"pathToScoresDb.db");
```

### ParsePresenceDatabase(path)
Parses the given presence.db file, then returns the parsed PresenceDatabase.
```cs
PresenceDatabase presenceDatabase = Parser.ParsePresenceDatabase(@"pathToPresenceDb.db");
```
