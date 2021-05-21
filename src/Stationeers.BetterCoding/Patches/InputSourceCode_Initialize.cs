// Copyright (c) Raphael Strotz. All rights reserved.

using System.Collections.Generic;
using Assets.Scripts.UI;
using HarmonyLib;
using Stationeers.BetterCoding.Internal;

namespace Stationeers.BetterCoding.Patches
{
    [HarmonyPatch(typeof(InputSourceCode), "Initialize")]
    public class InputSourceCode_Initialize
    {
        public static void Prefix(InputSourceCode __instance)
        {
            Log.Info("Applying '{0}'", nameof(InputSourceCode_Initialize));

            __instance.MaxLines = Configuration.MaxLines;

            if (InputSourceCode.LinesOfCode != null &&
                InputSourceCode.LinesOfCode.Capacity < Configuration.MaxLines)
            {
                var previous = InputSourceCode.LinesOfCode;

                InputSourceCode.LinesOfCode = new List<EditorLineOfCode>(Configuration.MaxLines);
                InputSourceCode.LinesOfCode.AddRange(previous);
            }

            Log.Info("Done");
        }
    }
}
