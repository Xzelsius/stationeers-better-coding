// Copyright (c) Raphael Strotz. All rights reserved.

using BepInEx;
using HarmonyLib;
using Stationeers.BetterCoding.Internal;

namespace Stationeers.BetterCoding
{
    [BepInPlugin(Id, Name, Version)]
    public class BetterCodingPlugin : BaseUnityPlugin
    {
        public const string Id = "com.xzelsius.bettercoding";
        public const string Name = "Better Coding";
        public const string Version = "1.0.0.0";

        public void Awake()
        {
            Log.Info("Loading...");

            LoadConfiguration();

            Log.Info("Applying patches...");

            var harmony = new Harmony(Id);
            harmony.PatchAll();

            Log.Info("Loading successful");
        }

        private void LoadConfiguration()
        {
            var maxLines = Config.Bind<int>(
                section: "General",
                key: "MaxLines",
                defaultValue: 256,
                description: "The amount of lines supported by the IC code editor."
            );

            Configuration.MaxLines = maxLines.Value;
        }
    }
}
