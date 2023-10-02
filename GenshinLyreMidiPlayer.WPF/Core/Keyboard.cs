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
        WindsongLyre,
        FloralZither,
        VintageLyre,
        IDV_Piano
    }

    public enum Layout
    {
        QWERTY,
        QWERTZ,
        AZERTY,
        DVORAK,
        DVORAKLeft,
        DVORAKRight,
        Colemak,
        QWERTY_MODIFIED
    }

    public static readonly Dictionary<Instrument, string> InstrumentNames = new()
    {
        [Instrument.WindsongLyre] = "Winsong Lyre",
        [Instrument.FloralZither] = "Floral Zither",
        [Instrument.VintageLyre]  = "Vintage Lyre",
        [Instrument.IDV_Piano]    = "IDV Piano"
    };

    public static readonly Dictionary<Layout, string> LayoutNames = new()
    {
        [Layout.QWERTY]      = "QWERTY",
        [Layout.QWERTZ]      = "QWERTZ",
        [Layout.AZERTY]      = "AZERTY",
        [Layout.DVORAK]      = "DVORAK",
        [Layout.DVORAKLeft]  = "DVORAK Left Handed",
        [Layout.DVORAKRight] = "DVORAK Right Handed",
        [Layout.Colemak]     = "Colemak",
        [Layout.QWERTY_MODIFIED] = "QWERTY Modified"
    };

    private static readonly IReadOnlyList<VirtualKeyCode> AZERTY = new List<VirtualKeyCode>
    {
        VirtualKeyCode.VK_W,
        VirtualKeyCode.VK_X,
        VirtualKeyCode.VK_C,
        VirtualKeyCode.VK_V,
        VirtualKeyCode.VK_B,
        VirtualKeyCode.VK_N,
        VirtualKeyCode.OEM_COMMA,

        VirtualKeyCode.VK_Q,
        VirtualKeyCode.VK_S,
        VirtualKeyCode.VK_D,
        VirtualKeyCode.VK_F,
        VirtualKeyCode.VK_G,
        VirtualKeyCode.VK_H,
        VirtualKeyCode.VK_J,

        VirtualKeyCode.VK_A,
        VirtualKeyCode.VK_Z,
        VirtualKeyCode.VK_E,
        VirtualKeyCode.VK_R,
        VirtualKeyCode.VK_T,
        VirtualKeyCode.VK_Y,
        VirtualKeyCode.VK_U
    };

    private static readonly IReadOnlyList<VirtualKeyCode> Colemak = new List<VirtualKeyCode>
    {
        VirtualKeyCode.VK_Z,
        VirtualKeyCode.VK_X,
        VirtualKeyCode.VK_C,
        VirtualKeyCode.VK_V,
        VirtualKeyCode.VK_B,
        VirtualKeyCode.VK_J,
        VirtualKeyCode.VK_M,

        VirtualKeyCode.VK_A,
        VirtualKeyCode.VK_D,
        VirtualKeyCode.VK_G,
        VirtualKeyCode.VK_E,
        VirtualKeyCode.VK_T,
        VirtualKeyCode.VK_H,
        VirtualKeyCode.VK_Y,

        VirtualKeyCode.VK_Q,
        VirtualKeyCode.VK_W,
        VirtualKeyCode.VK_K,
        VirtualKeyCode.VK_S,
        VirtualKeyCode.VK_F,
        VirtualKeyCode.VK_O,
        VirtualKeyCode.VK_I
    };

    private static readonly IReadOnlyList<VirtualKeyCode> DVORAK = new List<VirtualKeyCode>
    {
        VirtualKeyCode.OEM_2,
        VirtualKeyCode.VK_B,
        VirtualKeyCode.VK_I,
        VirtualKeyCode.OEM_PERIOD,
        VirtualKeyCode.VK_N,
        VirtualKeyCode.VK_L,
        VirtualKeyCode.VK_M,

        VirtualKeyCode.VK_A,
        VirtualKeyCode.OEM_1,
        VirtualKeyCode.VK_H,
        VirtualKeyCode.VK_Y,
        VirtualKeyCode.VK_U,
        VirtualKeyCode.VK_J,
        VirtualKeyCode.VK_C,

        VirtualKeyCode.VK_X,
        VirtualKeyCode.OEM_COMMA,
        VirtualKeyCode.VK_D,
        VirtualKeyCode.VK_O,
        VirtualKeyCode.VK_K,
        VirtualKeyCode.VK_T,
        VirtualKeyCode.VK_F
    };

    private static readonly IReadOnlyList<VirtualKeyCode> DVORAKLeft = new List<VirtualKeyCode>
    {
        VirtualKeyCode.VK_L,
        VirtualKeyCode.VK_X,
        VirtualKeyCode.VK_D,
        VirtualKeyCode.VK_V,
        VirtualKeyCode.VK_E,
        VirtualKeyCode.VK_N,
        VirtualKeyCode.VK_6,

        VirtualKeyCode.VK_K,
        VirtualKeyCode.VK_U,
        VirtualKeyCode.VK_F,
        VirtualKeyCode.VK_5,
        VirtualKeyCode.VK_C,
        VirtualKeyCode.VK_H,
        VirtualKeyCode.VK_8,

        VirtualKeyCode.VK_W,
        VirtualKeyCode.VK_B,
        VirtualKeyCode.VK_J,
        VirtualKeyCode.VK_Y,
        VirtualKeyCode.VK_G,
        VirtualKeyCode.VK_R,
        VirtualKeyCode.VK_T
    };

    private static readonly IReadOnlyList<VirtualKeyCode> DVORAKRight = new List<VirtualKeyCode>
    {
        VirtualKeyCode.VK_D,
        VirtualKeyCode.VK_C,
        VirtualKeyCode.VK_L,
        VirtualKeyCode.OEM_COMMA,
        VirtualKeyCode.VK_P,
        VirtualKeyCode.VK_N,
        VirtualKeyCode.VK_7,

        VirtualKeyCode.VK_F,
        VirtualKeyCode.VK_U,
        VirtualKeyCode.VK_K,
        VirtualKeyCode.VK_8,
        VirtualKeyCode.OEM_PERIOD,
        VirtualKeyCode.VK_H,
        VirtualKeyCode.VK_5,

        VirtualKeyCode.VK_E,
        VirtualKeyCode.VK_M,
        VirtualKeyCode.VK_G,
        VirtualKeyCode.VK_Y,
        VirtualKeyCode.VK_J,
        VirtualKeyCode.VK_O,
        VirtualKeyCode.VK_I
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

    private static readonly IReadOnlyList<VirtualKeyCode> QWERTZ = new List<VirtualKeyCode>
    {
        VirtualKeyCode.VK_Y,
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
        VirtualKeyCode.VK_Z,
        VirtualKeyCode.VK_U
    };

    private static readonly IReadOnlyList<VirtualKeyCode> QWERTY_MODIFIED = new List<VirtualKeyCode>
    {
        VirtualKeyCode.OEM_COMMA,
        VirtualKeyCode.OEM_PERIOD,
        VirtualKeyCode.OEM_2,
        VirtualKeyCode.VK_I,
        VirtualKeyCode.VK_O,
        VirtualKeyCode.VK_P,
        VirtualKeyCode.OEM_4,

        VirtualKeyCode.VK_Z,
        VirtualKeyCode.VK_X,
        VirtualKeyCode.VK_C,
        VirtualKeyCode.VK_V,
        VirtualKeyCode.VK_B,
        VirtualKeyCode.VK_N,
        VirtualKeyCode.VK_M,

        VirtualKeyCode.VK_Q,
        VirtualKeyCode.VK_W,
        VirtualKeyCode.VK_E,
        VirtualKeyCode.VK_R,
        VirtualKeyCode.VK_T,
        VirtualKeyCode.VK_Y,
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

    private static readonly List<int> VintageNotes = new()
    {
        48, // C3
        50, // D3
        51, // Eb3
        53, // F3
        55, // G3
        57, // A3
        58, // Bb3

        60, // C4
        62, // D4
        63, // Eb4
        65, // F4
        67, // G4
        69, // A4
        70, // Bb4

        72, // C5
        74, // Db5
        76, // Eb5
        77, // F5
        79, // G5
        80, // Ab5
        82  // Bb5
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
        Layout.QWERTZ           => QWERTZ,
        Layout.AZERTY           => AZERTY,
        Layout.DVORAK           => DVORAK,
        Layout.DVORAKLeft       => DVORAKLeft,
        Layout.DVORAKRight      => DVORAKRight,
        Layout.Colemak          => Colemak,
        _                       => QWERTY
    };

    public static IList<int> GetNotes(Instrument instrument) => instrument switch
    {
        Instrument.WindsongLyre => DefaultNotes,
        Instrument.FloralZither => DefaultNotes,
        Instrument.VintageLyre  => VintageNotes,
        Instrument.IDV_Piano    => IncludeBlackKeys,
        _                       => DefaultNotes
    };
}