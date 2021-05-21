// Copyright (c) Raphael Strotz. All rights reserved.

using UnityEngine;

namespace Stationeers.BetterCoding.Internal
{
    internal static class Log
    {
        public const string Prefix = "[" + BetterCodingPlugin.Name + "]";

        public static void Info(string format, params object[] args)
        {
            Debug.Log(Prefix + string.Format(format, args));
        }

        public static void Warning(string format, params object[] args)
        {
            Debug.LogWarning(string.Format(format, args));
        }

        public static void Error(string format, params object[] args)
        {
            Debug.LogError(Prefix + string.Format(format, args));
        }
    }
}
