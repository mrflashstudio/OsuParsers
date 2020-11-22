using OsuParsers.Enums.Storyboards;
using OsuParsers.Helpers;
using OsuParsers.Storyboards;
using System.Collections.Generic;
using System.Linq;

namespace OsuParsers.Writers
{
    internal class StoryboardEncoder
    {
        public static List<string> Encode(Storyboard storyboard)
        {
            var list = new List<string>();

            if (storyboard.Variables != null && storyboard.Variables.Any())
            {
                list.Add("[Variables]");

                foreach (var v in storyboard.Variables)
                    list.Add($"{v.Key}={v.Value}");

                list.Add(string.Empty);
            }

            list.AddRange(new List<string>
            {
                "[Events]",
                "//Background and Video events",
            });

            list.Add(@"//Storyboard Layer 0 (Background)");
            storyboard.BackgroundLayer.ForEach(sbObject => list.AddRange(WriteHelper.StoryboardObject(sbObject, StoryboardLayer.Background)));
            list.Add(@"//Storyboard Layer 1 (Fail)");
            storyboard.FailLayer.ForEach(sbObject => list.AddRange(WriteHelper.StoryboardObject(sbObject, StoryboardLayer.Fail)));
            list.Add(@"//Storyboard Layer 2 (Pass)");
            storyboard.PassLayer.ForEach(sbObject => list.AddRange(WriteHelper.StoryboardObject(sbObject, StoryboardLayer.Pass)));
            list.Add(@"//Storyboard Layer 3 (Foreground)");
            storyboard.ForegroundLayer.ForEach(sbObject => list.AddRange(WriteHelper.StoryboardObject(sbObject, StoryboardLayer.Foreground)));
            list.Add(@"//Storyboard Layer 4 (Overlay)");
            storyboard.OverlayLayer.ForEach(sbObject => list.AddRange(WriteHelper.StoryboardObject(sbObject, StoryboardLayer.Overlay)));
            list.Add(@"//Storyboard Sound Samples");
            storyboard.SamplesLayer.ForEach(sbObject => list.AddRange(WriteHelper.StoryboardObject(sbObject, (sbObject as Storyboards.Objects.StoryboardSample).Layer)));

            for (int i = 0; i < list.Count; i++)
                foreach (var v in storyboard.Variables)
                    list[i] = list[i].Replace($",{v.Value}", $",{v.Key}");

            return list;
        }
    }
}
