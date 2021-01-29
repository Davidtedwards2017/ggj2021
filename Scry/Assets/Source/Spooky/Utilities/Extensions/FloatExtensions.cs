using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spooky.Utilities
{
    public static class FloatExtensions
    {
        public static string ToLargeTimeFormat(this float time)
        {
            string minutes = Mathf.Floor(time / 60).ToString("00");
            string seconds = Mathf.Floor(time % 60).ToString("00");
            string prettyTime = string.Format("{0:0}:{1:00}", minutes, seconds);
            return prettyTime;
        }

        public static string ToSmallTimeFormat(this float time)
        {
            TimeSpan TimeInSeconds = TimeSpan.FromSeconds(time);
            return TimeInSeconds.ToString(@"s\.ff");


            // string minutes = Mathf.Floor(time / 60).ToString("00");
            // string seconds = Mathf.Floor(time % 60).ToString("00");
            // string prettyTime = string.Format("{0:0}:{1:00}", minutes, seconds);
            // return prettyTime;
        }
    }
}