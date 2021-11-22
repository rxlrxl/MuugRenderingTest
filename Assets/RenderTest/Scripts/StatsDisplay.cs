using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

namespace RenderTest
{
    public class StatsDisplay : MonoBehaviour
    {
        [SerializeField] private Text _statsText = null;

        private Queue<double> _frameSamples = new Queue<double>(60);
        private Stopwatch _frameStopwatch = new Stopwatch();

        private void Update()
        {
            _frameStopwatch.Stop();

            _frameSamples.Enqueue(_frameStopwatch.Elapsed.TotalMilliseconds);
            if (_frameSamples.Count > 60)
                _frameSamples.Dequeue();

            ShowFrameTimeStats();

            _frameStopwatch.Restart();
        }

        private void ShowFrameTimeStats()
        {
            var minFrameTime = double.MaxValue;
            var maxFrameTime = double.MinValue;
            double totalFrameTime = 0.0;
            foreach (var sample in _frameSamples)
            {
                totalFrameTime += sample;
                minFrameTime = Math.Min(minFrameTime, sample);
                maxFrameTime = Math.Max(maxFrameTime, sample);
            }

            string frameAvg = (totalFrameTime / _frameSamples.Count).ToString("F2");
            string frameMin = minFrameTime.ToString("F2");
            string frameMax = maxFrameTime.ToString("F2");
            _statsText.text = $@"60 last samples stats:
Frame Avg: {frameAvg}ms
Frame Min: {frameMin}ms
Frame Max: {frameMax}ms";
        }
    }
}
