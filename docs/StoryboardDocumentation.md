# Navigation
- [Storyboard properties](#storyboard-properties)
- [Interfaces](#interfaces)
    - [IStoryboardObject](#istoryboardobject)
    - [IHasCommands](#ihascommands)
    - [ICommand](#icommand)
- [Objects](#objects)
    - [StoryboardSprite](#storyboardsprite)
    - [StoryboardAnimation](#storyboardanimation)
    - [StoryboardSample](#storyboardsample)
- [Commands](#commands)
    - [CommandGroup](#commandgroup)
    - [Command](#command)
    - [TriggerCommand](#triggercommand)
    - [LoopCommand](#loopcommand)  
    
Also, see an [official documentation](https://osu.ppy.sh/help/wiki/Storyboard_Scripting).

# Storyboard properties
| Name                            | Type                      | Description                                                      |
|---------------------------------|---------------------------|------------------------------------------------------------------|
| BackgroundLayer                 | List\<IStoryboardObject\> | Storyboard layer that overrides default beatmap background.      |
| FailLayer                       | List\<IStoryboardObject\> | Storyboard layer that appears only when player is in fail state. |
| PassLayer                       | List\<IStoryboardObject\> | Storyboard layer that appears only when player is in pass state. |
| ForegroundLayer                 | List\<IStoryboardObject\> | The "highest" layer of storyboard.                               |
| GetLayer(StoryboardLayer layer) | List\<IStoryboardObject\> | Returns one of the four lists specified above.                   |

# Interfaces
### IStoryboardObject
Indicates that object is a storyboard object. (StoryboardSprite, StoryboardAnimation or StoryboardSample)  

| Name     | Type   | Description               |
|----------|--------|---------------------------|
| FilePath | string | Path to sprite or sample. |

### IHasCommands
Indicates that object has CommandGroup.  

| Name     | Type         | Description                                  |
|----------|--------------|----------------------------------------------|
| Commands | CommandGroup | Contains all commands that some object uses. |

### ICommand
Indicates that this object is storyboard command.  

| Name      | Type   | Description                                                                                 |
|-----------|--------|---------------------------------------------------------------------------------------------|
| Easing    | Easing | Indicates if the command should "accelerate". See [http://easings.net](http://easings.net). |
| StartTime | int    | Starting time of this command in ms.                                                        |
| EndTime   | int    | Ending time of this command in ms.                                                          |

# Objects
### StoryboardSprite
| Name     | Type         | Description                                  |
|----------|--------------|----------------------------------------------|
| Commands | CommandGroup | Contains all commands that this object uses. |
| Origin   | Origins      | Image's origin (coordinate).                 |
| FilePath | string       | Path to sprite.                              |
| X        | float        | X coordinate of where the object should be.  |
| Y        | float        | Y coordinate of where the object should be.  |

### StoryboardAnimation
| Name       | Type         | Description                                            |
|------------|--------------|--------------------------------------------------------|
| Commands   | CommandGroup | Contains all commands that this object uses.           |
| Origin     | Origins      | Image's origin (coordinate).                           |
| FilePath   | string       | Path to sprite.                                        |
| X          | float        | X coordinate of where the object should be.            |
| Y          | float        | Y coordinate of where the object should be.            |
| FrameCount | int          | Indicates how many frames the animation has.           |
| FrameDelay | int          | Indicates how many ms should be in between each frame. |
| LoopType   | LoopType     | Indicates if the animation should loop or not.         |

### StoryboardSample
| Name     | Type   | Description                         |
|----------|--------|-------------------------------------|
| Time     | int    | Starting time of this sample in ms. |
| FilePath | string | Path to sample.                     |
| Volume   | int    | Volume of this sample.              |

# Commands
### CommandGroup
| Name         | Type                               | Description                                        |
|--------------|------------------------------------|----------------------------------------------------|
| X            | List<Command\<float\>>               | Contains commads that change X coordinate.         |
| Y            | List<Command\<float\>>               | Contains commads that change Y coordinate.         |
| Scale        | List<Command\<float\>>               | Contains commads that change scale.                |
| VectorScale  | List<Command<Tuple<float, float>>> | Contains commads that change vector scale.         |
| Rotation     | List<Command\<float\>>               | Contains commads that change rotation.             |
| Colour       | List<Command\<Color\>>               | Contains commads that change X colour.             |
| Alpha        | List<Command\<float\>>               | Contains commads that change alpha.                |
| BlendingMode | List<Command\<BlendingMode\>>        | Contains commads that change blending mode.        |
| FlipH        | List<Command\<bool\>>                | Contains commads that flip the image horizontally. |
| FlipV        | List<Command\<bool\>>                | Contains commads that flip the image vertically.   |
| Triggers     | List\<TriggerCommand\>               | Contains all trigger commands of this object.      |
| Loops        | List\<LoopCommand\>                  | Contains all loop commands of this object.         |

### Command

| Name       | Type   | Description                                                                                 |
|------------|--------|---------------------------------------------------------------------------------------------|
| Easing     | Easing | Indicates if the command should "accelerate". See [http://easings.net](http://easings.net). |
| StartTime  | int    | Starting time of this command in ms.                                                        |
| EndTime    | int    | Ending time of this command in ms.                                                          |
| StartValue | T      | Start value of this command.                                                                |
| EndValue   | T      | End value of this command.                                                                  |

### TriggerCommand
| Name             | Type         | Description                                                                                                             |
|------------------|--------------|-------------------------------------------------------------------------------------------------------------------------|
| TriggerName      | string       | Indicates the trigger condition.                                                                                        |
| TriggerStartTime | int          | Timestamp at which the trigger becomes valid.                                                                           |
| TriggerEndTime   | int          | Timestamp at which the trigger stops being valid.                                                                       |
| GroupNumber      | int          | Allows triggers on the same sprite to be grouped so that all triggers of the group are stopped when one trigger starts. |
| Commands         | CommandGroup | Commands of this trigger.                                                                                               |

### LoopCommand
| Name          | Type         | Description                                        |
|---------------|--------------|----------------------------------------------------|
| LoopStartTime | int          | Timestamp at which the loop begins.                |
| LoopCount     | int          | Number of times the loop executes before stopping. |
| Commands      | CommandGroup | Commands of this loop.                             |
