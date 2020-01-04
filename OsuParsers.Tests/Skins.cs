using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using OsuParsers.Decoders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace OsuParsers.Tests
{
    [TestClass]
    public class Skins
    {
        private static readonly string[] skinNames = new string[]
        {
            "AngelsimSkin.ini",
            "BeasttrollMCSkin.ini",
            "CookieziSkin.ini",
            "DokidokilolixxSkin.ini",
            "InformousSkin.ini",
            "MathiTunaSkin.ini",
            "RafisSkin.ini",
            "VarvalianSkin.ini",
            "VaxeiSkin.ini",
            "YugenSkin.ini"
        };

        private List<(string FileName, IEnumerable<string> RawFile)> rawFiles = new List<(string, IEnumerable<string>)>();

        public Skins()
        {
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            PrepareSkins();
        }

        private void PrepareSkins()
        {
            var assembly = Assembly.GetExecutingAssembly();
            foreach (var skin in skinNames)
                rawFiles.Add((skin, assembly.GetManifestResourceStream($"OsuParsers.Tests.Resources.Skins.{skin}").ReadAllLines()));
        }

        private void ParseAndWriteAll()
        {
            foreach (var file in rawFiles)
            {
                var timer = new Stopwatch();
                timer.Start();
                var skin = SkinDecoder.Decode(file.RawFile);
                timer.Stop();

                Trace.WriteLine(string.Format(
                    "Skin parsed in {0}ms: {1} by {2}.",
                    timer.Elapsed.Milliseconds,
                    skin.GeneralSection.Name,
                    skin.GeneralSection.Author));

                timer.Restart();
                string filePath = Path.Combine(Path.GetTempPath(), file.FileName);
                skin.Write(filePath);
                timer.Stop();

                Trace.WriteLine(string.Format("Skin written in {0}ms: {1} to path {2}.", timer.Elapsed.Milliseconds, file.FileName, filePath));

                var parsed = SkinDecoder.Decode(filePath);
                Assert.AreEqual(JsonConvert.SerializeObject(skin), JsonConvert.SerializeObject(parsed));
            }
        }

        [TestMethod]
        public void ParseAndWriteAllTestingSkins()
        {
            ParseAndWriteAll();
        }

        [AssemblyCleanup]
        public static void Cleanup()
        {
            foreach (var file in skinNames)
            {
                var filePath = Path.Combine(Path.GetTempPath(), file);
                if (File.Exists(filePath))
                    File.Delete(filePath);
            }
        }
    }
}
