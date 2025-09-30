using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Media;
using System.Reflection;

namespace BPM_Calculator
{
    public partial class MainWindow : Window
    {
        private readonly List<double> _tapIntervals = new List<double>();
        private DateTime _lastTapTime;
        private const int TapsToAverage = 4;
        //next to lines new
        private readonly SoundPlayer _tapSoundPlayer = new SoundPlayer();
        private bool isMuted = false;

        public MainWindow()
        {
            InitializeComponent();
            //following code till Reset Calculation added
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                using (var stream = assembly.GetManifestResourceStream("BPM_Calculator.wilhelm.wav"))
                {
                    _tapSoundPlayer.Stream = stream;
                    _tapSoundPlayer.Load();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading sound stream: {ex.Message}");
            }

            ResetCalculation();
        }

        private void TapButton_Click(object sender, RoutedEventArgs e)
        {
            //following till DateTime now is new
            if (!isMuted)
            {
                _tapSoundPlayer.Play();
            }

            DateTime now = DateTime.Now;
            if (_lastTapTime != DateTime.MinValue)
            {
                double interval = (now - _lastTapTime).TotalMilliseconds;
                _tapIntervals.Add(interval);
            }
            _lastTapTime = now;
            while (_tapIntervals.Count > TapsToAverage)
            {
                _tapIntervals.RemoveAt(0);
            }
            if (_tapIntervals.Any())
            {
                double averageInterval = _tapIntervals.Average();
                if (averageInterval > 0)
                {
                    double bpm = 60000 / averageInterval;
                    BPMTextBlock.Text = $"BPM: {bpm:F1}";
                }
            }
        }
        //folowing private void code is new
        private void MuteButton_Click(object sender, RoutedEventArgs e)
        {
            isMuted = !isMuted;
            MuteButton.Content = isMuted ? "Unmute" : "Mute";
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            ResetCalculation();
        }

        private void ResetCalculation()
        {
            _tapIntervals.Clear();
            _lastTapTime = DateTime.MinValue;
            BPMTextBlock.Text = "Tap to start";
        }
    }
}