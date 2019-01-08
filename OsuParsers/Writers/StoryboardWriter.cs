using OsuParsers.Helpers;
using OsuParsers.Storyboards;
using System.Collections.Generic;

namespace OsuParsers.Writers
{
    internal class StoryboardWriter
    {
        public static List<string> Write(Storyboard storyboard)
        {
            var list = new List<string>();
            list.AddRange(new List<string>
            {
                "[Events]",
                "//Background and Video events",
            });
            list.Add(@"//Storyboard Layer 0 (Background)");
            storyboard.BackgroundLayer.ForEach(sbObject => list.AddRange(FormatHelper.StoryboardObject(sbObject, Enums.StoryboardLayer.Background)));
            list.Add(@"//Storyboard Layer 1 (Fail)");
            storyboard.FailLayer.ForEach(sbObject => list.AddRange(FormatHelper.StoryboardObject(sbObject, Enums.StoryboardLayer.Fail)));
            list.Add(@"//Storyboard Layer 2 (Pass)");
            storyboard.PassLayer.ForEach(sbObject => list.AddRange(FormatHelper.StoryboardObject(sbObject, Enums.StoryboardLayer.Pass)));
            list.Add(@"//Storyboard Layer 3 (Foreground)");
            storyboard.ForegroundLayer.ForEach(sbObject => list.AddRange(FormatHelper.StoryboardObject(sbObject, Enums.StoryboardLayer.Foreground)));
            list.Add(@"//Storyboard Sound Samples");
            storyboard.SamplesLayer.ForEach(sbObject => list.AddRange(FormatHelper.StoryboardObject(sbObject, (sbObject as Storyboards.Objects.StoryboardSample).Layer)));
            return list;
        }
    }
}
