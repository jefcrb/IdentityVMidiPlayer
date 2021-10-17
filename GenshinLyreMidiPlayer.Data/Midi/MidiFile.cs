﻿using System;
using System.Collections.Generic;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using Melanchall.DryWetMidi.Tools;
using Stylet;
using static System.IO.Path;

namespace GenshinLyreMidiPlayer.Data.Midi
{
    public class MidiFile : Screen
    {
        private readonly ReadingSettings? _settings;
        private int _position;

        public MidiFile(string path, ReadingSettings? settings = null)
        {
            _settings = settings;

            Path = path;
            InitializeMidi();
        }

        public int Position
        {
            get => _position + 1;
            set => SetAndNotify(ref _position, value);
        }

        public Melanchall.DryWetMidi.Core.MidiFile Midi { get; private set; } = null!;

        public string Path { get; }

        public string Title => GetFileNameWithoutExtension(Path);

        public TimeSpan Duration => Midi.GetDuration<MetricTimeSpan>();

        public IEnumerable<Melanchall.DryWetMidi.Core.MidiFile> Split(uint bars, uint beats, uint ticks) =>
            Midi.SplitByGrid(new SteppedGrid(new BarBeatTicksTimeSpan(bars, beats, ticks)));

        public void InitializeMidi() { Midi = Melanchall.DryWetMidi.Core.MidiFile.Read(Path, _settings); }
    }
}