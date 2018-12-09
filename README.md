# OsuParsers [![CodeFactor](https://www.codefactor.io/repository/github/mrflashstudio/osuparsers/badge)](https://www.codefactor.io/repository/github/mrflashstudio/osuparsers) [![nuget](https://img.shields.io/nuget/v/OsuParsers.svg)](https://www.nuget.org/packages/OsuParsers)

Library for parsing files associated with osu! written in C#

Feel free to use it and report any issues you might run into.  
Cuz, you know, i might have broke something in the last few commits ;)  

# Navigation
- [Installation](#installation)  
- [Building and Requirements](#building-and-requirements)  
- [Methods](#methods)  
    - [ParseBeatmap(path)](#parsebeatmappath)
    - [ParseStoryboard(path)](#parsestoryboardpath)
    - [ParseReplay(path)](#parsereplaypath)
    - [ParseOsuDatabase(path)](#parseosudatabasepath)
    - [ParseCollectionDatabase(path)](#parsecollectiondatabasepath)
    - [ParseScoresDatabase(path)](#parsescoresdatabasepath)
    - [ParsePresenceDatabase(path)](#parsepresencedatabasepath)
- [Usage](#usage)  
    - [Beatmap parser](#beatmap-parser)
    - [Storyboard parser](#storyboard-parser)
    - [Replay parser](#replay-parser)
    - [Database parser](#database-parser)
- [Documentation](#documentation)  
    - [Beatmap documentation](docs/BeatmapDocumentation.md)
    - [Storyboard documentation](docs/StoryboardDocumentation.md)
    - [Replay documentation](docs/ReplayDocumentation.md)
    - [Database documentation](docs/DatabaseDocumentation.md)

# Installation
Download latest version of parser from [releases](https://github.com/mrflashstudio/OsuParsers/releases), then add the dll into your project references.  
Or you can just install [NuGet package](https://www.nuget.org/packages/OsuParsers). (`Install-Package OsuParsers -Version 1.3.1`)

# Building and Requirements
- You need a desktop platform that can compile .NET 4.5
- Clone the repository `git clone https://github.com/mrflashstudio/OsuParsers`
- And then you can build the project in your IDE.

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

# Usage
### Beatmap parser
```cs
using OsuParsers;
using OsuParsers.Beatmaps;

namespace SomeNamespace
{
    class Program
    {
        public static void Main(string[] args)
        {
            Beatmap beatmap = Parser.ParseBeatmap(@"beatmapPath.osu");
            
            //printing beatmap's title
            System.Console.WriteLine(beatmap.MetadataSection.TitleUnicode);
        }
    }
}
```

### Storyboard parser
```cs
using OsuParsers;
using OsuParsers.Storyboards;

namespace SomeNamespace
{
    class Program
    {
        public static void Main(string[] args)
        {
            Storyboard storyboard = Parser.ParseStoryboard(@"storyboardPath.osb");
            
            //getting first object of foreground layer
            IStoryboardObject object = storyboard.ForegroundLayer[0];
        }
    }
}
```

### Replay parser
```cs
using OsuParsers;
using OsuParsers.Replays;

namespace SomeNamespace
{
    class Program
    {
        public static void Main(string[] args)
        {
            Replay replay = Parser.ParseReplay(@"replayPath.osr");
            
            //printing player's nickname
            System.Console.WriteLine(replay.PlayerName);
        }
    }
}
```

### Database parser
```cs
using OsuParsers;
using OsuParsers.Database;

namespace SomeNamespace
{
    class Program
    {
        public static void Main(string[] args)
        {
            //parsing all available databases
            OsuDatabase osuDb = Parser.ParseOsuDatabase(@"osuDbPath.db");
            CollectionDatabase collectionDb = Parser.ParseCollectionDatabase(@"collectionDbPath.db");
            ScoresDatabase scoresDb = Parser.ParseScoresDatabase(@"scoresDbPath.db");
            PresenceDatabase presenceDb = Parser.ParsePresenceDatabase(@"presenceDbPath.db");
            
            //printing player's nickname
            System.Console.WriteLine(osuDb.PlayerName);
            //printing collection count
            System.Console.WriteLine(collectionDb.CollectionCount);
            //printing beatmap's md5 hash of first score
            System.Console.WriteLine(scoresDb.Scores[0].Item1);
            //printing first player's nickname
            System.Console.WriteLine(presenceDb.Players[0].Username);
        }
    }
}
```

### Beatmap writer
```cs
using OsuParsers;
using OsuParsers.Beatmaps;

namespace SomeNamespace
{
    class Program
    {
        public static void Main(string[] args)
        {
            //getting console output text as the song's new title
            string newTitle = System.Console.ReadLine();
            //parsing beatmap
            using (Beatmap beatmap = Parser.ParseBeatmap(@"pathToBeatmap.osu"))
            {
                //changing song title
                beatmap.MetadataSection.Title = newTitle;
                //writing beatmap to file
                beatmap.Write(@"pathToNewBeatmap.osu");
            }
        }
    }
}
```

# Documentation
For detailed description of available methods and fields, see [documentation](docs).
