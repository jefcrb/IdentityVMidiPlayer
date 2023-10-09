using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using WindowsInput.Native;

namespace GenshinLyreMidiPlayer.WPF.Core;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "StringLiteralTypo")]
[SuppressMessage("ReSharper", "IdentifierTypo")]
[SuppressMessage("ReSharper", "CollectionNeverQueried.Global")]
public static class Keyboard
{
    public enum Instrument
    {
        Harp,
        Piano,
        Piano_Black_Keys,
        Flute
    }

    public enum Layout
    {
        QWERTY,
        QWERTY_MODIFIED
    }

    public static readonly Dictionary<Instrument, string> InstrumentNames = new()
    {
        [Instrument.Harp]               = "Piano / Strings of the Sands",
        [Instrument.Piano_Black_Keys]   = "Piano (black keys enabled)",
        [Instrument.Flute]              = "Flute"
    };

    public static readonly Dictionary<Layout, string> LayoutNames = new()
    {
        [Layout.QWERTY]             = "QWERTY",
        [Layout.QWERTY_MODIFIED]    = "QWERTY black keys"
    };

    private static readonly IReadOnlyList<VirtualKeyCode> QWERTY = new List<VirtualKeyCode>
    {
        VirtualKeyCode.VK_Z,
        VirtualKeyCode.VK_X,
        VirtualKeyCode.VK_C,
        VirtualKeyCode.VK_V,
        VirtualKeyCode.VK_B,
        VirtualKeyCode.VK_N,
        VirtualKeyCode.VK_M,

        VirtualKeyCode.VK_A,
        VirtualKeyCode.VK_S,
        VirtualKeyCode.VK_D,
        VirtualKeyCode.VK_F,
        VirtualKeyCode.VK_G,
        VirtualKeyCode.VK_H,
        VirtualKeyCode.VK_J,

        VirtualKeyCode.VK_Q,
        VirtualKeyCode.VK_W,
        VirtualKeyCode.VK_E,
        VirtualKeyCode.VK_R,
        VirtualKeyCode.VK_T,
        VirtualKeyCode.VK_Y,
        VirtualKeyCode.VK_U
    };

    private static readonly IReadOnlyList<VirtualKeyCode> QWERTY_MODIFIED = new List<VirtualKeyCode>
    {
        VirtualKeyCode.OEM_COMMA,
        VirtualKeyCode.VK_L,      // C#3
        VirtualKeyCode.OEM_PERIOD,
        VirtualKeyCode.OEM_1,     // D#3
        VirtualKeyCode.OEM_2,
        VirtualKeyCode.VK_I,
        VirtualKeyCode.VK_9,      // F#3
        VirtualKeyCode.VK_O,
        VirtualKeyCode.VK_0,      // G#3
        VirtualKeyCode.VK_P,
        VirtualKeyCode.OEM_MINUS, // A#3
        VirtualKeyCode.OEM_4,

        VirtualKeyCode.VK_Z,
        VirtualKeyCode.VK_S,      // C#4
        VirtualKeyCode.VK_X,
        VirtualKeyCode.VK_D,      // D#4
        VirtualKeyCode.VK_C,
        VirtualKeyCode.VK_V,
        VirtualKeyCode.VK_G,      // F#4
        VirtualKeyCode.VK_B,
        VirtualKeyCode.VK_H,      // G#4
        VirtualKeyCode.VK_N,
        VirtualKeyCode.VK_J,      // A#4
        VirtualKeyCode.VK_M,

        VirtualKeyCode.VK_Q,
        VirtualKeyCode.VK_2,      // C#5
        VirtualKeyCode.VK_W,
        VirtualKeyCode.VK_3,      // D#5
        VirtualKeyCode.VK_E,
        VirtualKeyCode.VK_R,
        VirtualKeyCode.VK_5,      // F#5
        VirtualKeyCode.VK_T,
        VirtualKeyCode.VK_6,      // G#5
        VirtualKeyCode.VK_Y,
        VirtualKeyCode.VK_7,      // A#5
        VirtualKeyCode.VK_U
    };

    private static readonly List<int> DefaultNotes = new()
    {
        48, // C3
        50, // D3
        52, // E3
        53, // F3
        55, // G3
        57, // A3
        59, // B3

        60, // C4
        62, // D4
        64, // E4
        65, // F4
        67, // G4
        69, // A4
        71, // B4

        72, // C5
        74, // D5
        76, // E5
        77, // F5
        79, // G5
        81, // A5
        83  // B5
    };

    private static readonly List<int> NotesFlute = new()
    {
        48, // C3
        50, // D3
        52, // E3
        53, // F3
        55, // G3
        57, // A3
        59, // B3

        60, // C4
        62, // D4
        64, // E4
        65, // F4
        67, // G4
        69, // A4
        71, // B4
    };

    private static readonly List<int> IncludeBlackKeys = new()
    {
        48, // C3
        49,     // C#3
        50, // D3
        51,     // D#3
        52, // E3
        53, // F3
        54,     // F#3
        55, // G3
        56,     // G#3
        57, // A3
        58,     // A#3
        59, // B3

        60, // C4
        61,     // C#4
        62, // D4
        63,     // D#4
        64, // E4
        65, // F4
        66,     // F#4
        67, // G4
        68,     // G#4
        69, // A4
        70,     // A#4
        71, // B4

        72, // C5
        73,     // C#5
        74, // D5
        75,     // D#5
        76, // E5
        77, // F5
        78,     // F#5
        79, // G5
        80,     // G#5
        81, // A5
        82,     // A#5
        83  // B5
    };

    public static IEnumerable<VirtualKeyCode> GetLayout(Layout layout) => layout switch
    {
        Layout.QWERTY           => QWERTY,
        Layout.QWERTY_MODIFIED  => QWERTY_MODIFIED,
        _                       => QWERTY
    };

    public static IList<int> GetNotes(Instrument instrument) => instrument switch
    {
        Instrument.Harp     => DefaultNotes,
        Instrument.Piano_Black_Keys => IncludeBlackKeys,
        Instrument.Flute    => NotesFlute,
        _                   => DefaultNotes
    };
}