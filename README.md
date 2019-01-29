# OsuParsers [![CodeFactor](https://www.codefactor.io/repository/github/mrflashstudio/osuparsers/badge)](https://www.codefactor.io/repository/github/mrflashstudio/osuparsers) [![nuget](https://img.shields.io/nuget/v/OsuParsers.svg)](https://www.nuget.org/packages/OsuParsers)

Library for parsing files associated with osu! written in C#

Feel free to use it and report any issues you might run into.  
Cuz, you know, i might have broke something in the last few commits ;)  

# Navigation
- [Installation](#installation)  
- [Building and Requirements](#building-and-requirements)  
- [Usage](#usage)  
    - [Beatmap parser](#beatmap-parser)
    - [Storyboard parser](#storyboard-parser)
    - [Replay parser](#replay-parser)
    - [Database parser](#database-parser)
    - [Beatmap writer](#beatmap-writer)
    - [Storyboard writer](#storyboard-writer)
    - [Replay writer](#replay-writer)
- [Documentation](#documentation)  
    - [Parser documentation](docs/ParserDocumentation.md)
    - [Beatmap documentation](docs/BeatmapDocumentation.md)
    - [Storyboard documentation](docs/StoryboardDocumentation.md)
    - [Replay documentation](docs/ReplayDocumentation.md)
    - [Database documentation](docs/DatabaseDocumentation.md)

# Installation
Download latest version of parser from [releases](https://github.com/mrflashstudio/OsuParsers/releases), then add the dll into your project references.  
Or you can just install [NuGet package](https://www.nuget.org/packages/OsuParsers). (`Install-Package OsuParsers -Version 1.5.0`)

# Building and Requirements
- You need a desktop platform that can compile .NET 4.5
- Clone the repository `git clone https://github.com/mrflashstudio/OsuParsers`
- And then you can build the project in your IDE.

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

### Storyboard writer
```cs
using OsuParsers;
using OsuParsers.Storyboards;

namespace SomeNamespace
{
    class Program
    {
        public static void Main(string[] args)
        {
            //getting console output text as the object's new filepath
            string newFilePath = System.Console.ReadLine();
            //parsing storyboard
            using (Storyboard storyboard = Parser.ParseStoryboard(@"pathToStoryboard.osb"))
            {
                //changing filepath of the first storyboard object in background layer
                storyboard.BackgroundLayer[0].FilePath = newFilePath;
                //writing storyboard to file
                beatmap.Write(@"pathToNewStoryboard.osb");
            }
        }
    }
}
```

### Replay writer
```cs
using OsuParsers;
using OsuParsers.Replays;

namespace SomeNamespace
{
    class Program
    {
        public static void Main(string[] args)
        {
            //getting console output text as the new player's name
            string newPlayerName = System.Console.ReadLine();
            //parsing replay
            using (Replay replay = Parser.ParseReplay(@"pathToReplay.osr"))
            {
                //changing player name
                replay.PlayerName = newPlayerName;
                //writing replay to file
                replay.Write(@"pathToNewReplay.osr");
            }
        }
    }
}
```

# Documentation
For detailed description of available methods and fields, see [documentation](docs).
