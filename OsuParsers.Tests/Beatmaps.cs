using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using OsuParsers.Beatmaps;
using OsuParsers.Beatmaps.Sections;
using OsuParsers.Decoders;

namespace OsuParsers.Tests
{
    [TestClass]
    public class Beatmaps
    {
        public Beatmaps()
        {
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
        }

        public async Task GetTestingBeatmaps()
        {
            Trace.WriteLine("Downloading all beatmaps...");
            foreach (var id in BeatmapIDs)
                await AddBeatmap(id);
        }

        public async Task<bool> AddBeatmap(uint id)
        {
            var client = new HttpClient();
            Trace.Write($"Downloading beatmap '{BaseUrl}{id}'...\t");
                
            var dlTimer = new Stopwatch();
            dlTimer.Start();
            byte[] data = await client.GetByteArrayAsync(new Uri(BaseUrl + id));
            dlTimer.Stop();

            var file = Encoding.UTF8.GetString(data, 0, data.Length);
            var lines = file.Split("\r\n", StringSplitOptions.None);

            if (data.Length == 0)
            {
                Trace.WriteLine("Failed, file empty.");
                return false;
            }
            
            Trace.WriteLine($"Completed in {dlTimer.ElapsedMilliseconds}ms ({Math.Round((double)data.Length / 1024d, 3)}KB)");
            RawFiles.Add(lines);
            return true;
        }

        public void ParseAll()
        {
            foreach (var file in RawFiles)
            {
                var timer = new Stopwatch();
                timer.Start();
                var beatmap = BeatmapDecoder.Decode(file);
                timer.Stop();
                
                Maps.Add(beatmap);
                Trace.WriteLine(string.Format(
                    "Beatmap parsed in {0}ms: {1} - {2} [{3}] created by {4}.",
                    timer.Elapsed.Milliseconds,
                    beatmap.MetadataSection.Artist,
                    beatmap.MetadataSection.Title,
                    beatmap.MetadataSection.Version,
                    beatmap.MetadataSection.Creator));
            }
        }

        private string BaseUrl => @"https://osu.ppy.sh/osu/";

        private List<uint> BeatmapIDs =  new List<uint>
        {
            557821, // Soleily - Renatus [Insane]
            557818, // Soleily - Renatus [Oni]
            557811, // Soleily - Renatus [Rain]
            557819, // Soleily - Renatus [Another]
            315552, // Rostik - Liquid (Paul Rosenthal Remix) [Insane]
            1037478, // cYsmix - Moonlight Sonata [Expert]
            1002358, // Asterisk - Ren-chon no Drum 'n' Bass [Nap's 7K Uta Desu]
            373781, // ginkiha - EOS [Lycoris]
            1883745, // Himeringo - Idola no Circus [Salvation]
            1922277, // nano - Rock on. [Finale]
        };

        private List<IEnumerable<string>> RawFiles = new List<IEnumerable<string>>();
        private List<Beatmap> Maps = new List<Beatmap>();

        [TestMethod]
        public async Task ParseAllTestingBeatmaps()
        {
            RawFiles.Clear();
            await GetTestingBeatmaps();

            Trace.WriteLine("Parsing beatmaps...");
            ParseAll();
        }

        [DataTestMethod]
        [DataRow(10)]
        public async Task ParseRandomBeatmaps(int amount)
        {
            Trace.WriteLine($"Attempting to parse {amount} beatmaps...");
            RawFiles.Clear();
            for (int i = 0; i <= amount;)
            {
                var rand = (uint)new Random().Next(2000000);
                if (await AddBeatmap(rand))
                    i++;
            }

            Trace.WriteLine($"Parsing {amount} random beatmaps...");
            ParseAll();
            Trace.WriteLine($"Parsed {amount} beatmaps.");
        }
    }
}