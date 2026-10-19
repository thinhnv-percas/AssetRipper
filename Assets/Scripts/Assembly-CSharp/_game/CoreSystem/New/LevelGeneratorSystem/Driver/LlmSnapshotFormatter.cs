using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;
using _game.BaseLayerSystems.EntitySystem.Serialization;
using _game.CoreSystem.LevelCreator;
using _game.CoreSystem.MoldSystem.Components;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.Shared.Components;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.LevelData;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Data;
using _game.CoreSystem.SandSystem.Components;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Driver
{
	[Token(Token = "0x2000379")]
	public static class LlmSnapshotFormatter
	{
		[Token(Token = "0x200037A")]
		internal sealed class Ctx
		{
			[Token(Token = "0x4000A84")]
			[FieldOffset(Offset = "0x10")]
			public readonly SortedDictionary<(int x, int y), List<string>> CellModifiers;

			[Token(Token = "0x4000A85")]
			[FieldOffset(Offset = "0x18")]
			public readonly SortedDictionary<(int x, int y), List<string>> MoldModifiers;

			[Token(Token = "0x4000A86")]
			[FieldOffset(Offset = "0x20")]
			public readonly List<string> GroupLines;

			[Token(Token = "0x4000A87")]
			[FieldOffset(Offset = "0x28")]
			public readonly SortedDictionary<string, int> CubeCounts;

			[Token(Token = "0x4000A88")]
			[FieldOffset(Offset = "0x30")]
			public readonly SortedDictionary<string, int> MoldCounts;

			[Token(Token = "0x4000A89")]
			[FieldOffset(Offset = "0x38")]
			public readonly SortedDictionary<string, int> TunnelQueueCounts;

			[Token(Token = "0x4000A8A")]
			[FieldOffset(Offset = "0x40")]
			public readonly HashSet<GameColor> UsedColors;

			[Token(Token = "0x4000A8B")]
			[FieldOffset(Offset = "0x48")]
			public readonly HashSet<char> TunnelGlyphsUsed;

			[Token(Token = "0x4000A8C")]
			[FieldOffset(Offset = "0x50")]
			public readonly HashSet<(int x, int y)> GarageAnchorCells;

			[Token(Token = "0x4000A8D")]
			[FieldOffset(Offset = "0x58")]
			public readonly Dictionary<(int x, int y), char> SandBaseChar;

			[Token(Token = "0x4000A8E")]
			[FieldOffset(Offset = "0x60")]
			public readonly Dictionary<(int x, int y), char> MoldBaseChar;

			[Token(Token = "0x4000A8F")]
			private static readonly Comparer<(int x, int y)> CoordCmp;

			[Token(Token = "0x6000E7A")]
			[Address(RVA = "0x3F0D4C8", Offset = "0x3F0D4C8", Length = "0x42C")]
			public Ctx()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter.Ctx::.ctor");
			}

			[Token(Token = "0x6000E7B")]
			[Address(RVA = "0x3F1544C", Offset = "0x3F1544C", Length = "0xF4")]
			unsafe static Ctx()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter.Ctx::.cctor");
			}
		}

		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200037C")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000A91")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000A92")]
			public static Func<GridCoord, bool> _003C_003E9__0_0;

			[Token(Token = "0x4000A93")]
			public static Func<GridCoord, bool> _003C_003E9__0_1;

			[Token(Token = "0x4000A94")]
			public static Func<ICellComponent, bool> _003C_003E9__6_0;

			[Token(Token = "0x4000A95")]
			public static Comparison<(int x, int y, SnakeSegmentComponent seg)> _003C_003E9__8_0;

			[Token(Token = "0x4000A96")]
			public static Func<(int x, int y), int> _003C_003E9__10_1;

			[Token(Token = "0x4000A97")]
			public static Func<(int x, int y), int> _003C_003E9__10_2;

			[Token(Token = "0x4000A98")]
			public static Comparison<(int x, int y)> _003C_003E9__10_3;

			[Token(Token = "0x4000A99")]
			public static Comparison<List<(int x, int y)>> _003C_003E9__10_0;

			[Token(Token = "0x4000A9A")]
			public static Func<((int x, int y) a, (int x, int y) b), int> _003C_003E9__11_0;

			[Token(Token = "0x4000A9B")]
			public static Func<((int x, int y) a, (int x, int y) b), int> _003C_003E9__11_1;

			[Token(Token = "0x4000A9C")]
			public static Func<((int x, int y) a, (int x, int y) b), int> _003C_003E9__11_2;

			[Token(Token = "0x4000A9D")]
			public static Func<((int x, int y) a, (int x, int y) b), int> _003C_003E9__11_3;

			[Token(Token = "0x4000A9E")]
			public static Func<string, bool> _003C_003E9__15_0;

			[Token(Token = "0x4000A9F")]
			public static Func<GameColor, string> _003C_003E9__15_1;

			[Token(Token = "0x4000AA0")]
			public static Func<GameColor, string> _003C_003E9__20_0;

			[Token(Token = "0x4000AA1")]
			public static Func<KeyValuePair<string, int>, string> _003C_003E9__26_0;

			[Token(Token = "0x4000AA2")]
			public static Func<KeyValuePair<(int x, int y), (int snakeId, int segIdx, bool isHead)>, int> _003C_003E9__27_0;

			[Token(Token = "0x4000AA3")]
			public static Func<IGrouping<int, KeyValuePair<(int x, int y), (int snakeId, int segIdx, bool isHead)>>, int> _003C_003E9__27_1;

			[Token(Token = "0x4000AA4")]
			public static Func<KeyValuePair<(int x, int y), (int snakeId, int segIdx, bool isHead)>, int> _003C_003E9__27_2;

			[Token(Token = "0x4000AA5")]
			public static Func<KeyValuePair<(int x, int y), (int snakeId, int segIdx, bool isHead)>, string> _003C_003E9__27_3;

			[Token(Token = "0x4000AA6")]
			public static Func<KeyValuePair<(int x, int y), (int pinId, int pathIdx, bool isTrigger)>, int> _003C_003E9__28_0;

			[Token(Token = "0x4000AA7")]
			public static Func<IGrouping<int, KeyValuePair<(int x, int y), (int pinId, int pathIdx, bool isTrigger)>>, int> _003C_003E9__28_1;

			[Token(Token = "0x4000AA8")]
			public static Func<KeyValuePair<(int x, int y), (int pinId, int pathIdx, bool isTrigger)>, int> _003C_003E9__28_2;

			[Token(Token = "0x4000AA9")]
			public static Func<KeyValuePair<(int x, int y), (int pinId, int pathIdx, bool isTrigger)>, string> _003C_003E9__28_3;

			[Token(Token = "0x4000AAA")]
			public static Func<KeyValuePair<(int x, int y), int>, int> _003C_003E9__29_0;

			[Token(Token = "0x4000AAB")]
			public static Func<IGrouping<int, KeyValuePair<(int x, int y), int>>, int> _003C_003E9__29_1;

			[Token(Token = "0x4000AAC")]
			public static Func<KeyValuePair<(int x, int y), int>, int> _003C_003E9__29_2;

			[Token(Token = "0x4000AAD")]
			public static Func<KeyValuePair<(int x, int y), int>, int> _003C_003E9__29_3;

			[Token(Token = "0x4000AAE")]
			public static Func<KeyValuePair<(int x, int y), int>, string> _003C_003E9__29_4;

			[Token(Token = "0x4000AAF")]
			public static Func<KeyValuePair<(int x, int y), (int sizeX, int sizeY, int counter)>, int> _003C_003E9__30_0;

			[Token(Token = "0x4000AB0")]
			public static Func<KeyValuePair<(int x, int y), (int sizeX, int sizeY, int counter)>, int> _003C_003E9__30_1;

			[Token(Token = "0x4000AB1")]
			public static Func<KeyValuePair<(int x, int y), int>, int> _003C_003E9__31_0;

			[Token(Token = "0x4000AB2")]
			public static Func<IGrouping<int, KeyValuePair<(int x, int y), int>>, int> _003C_003E9__31_1;

			[Token(Token = "0x4000AB3")]
			public static Func<KeyValuePair<(int x, int y), int>, int> _003C_003E9__31_2;

			[Token(Token = "0x4000AB4")]
			public static Func<KeyValuePair<(int x, int y), int>, int> _003C_003E9__31_3;

			[Token(Token = "0x4000AB5")]
			public static Func<KeyValuePair<(int x, int y), int>, string> _003C_003E9__31_4;

			[Token(Token = "0x6000E7F")]
			[Address(RVA = "0x3F1560C", Offset = "0x3F1560C", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000E80")]
			[Address(RVA = "0x3F15670", Offset = "0x3F15670", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal bool _003CFormat_003Eb__0_0(GridCoord _)
			{
				return false;
			}

			internal bool _003CFormat_003Eb__0_1(GridCoord _)
			{
				return false;
			}

			internal bool _003CBuildContext_003Eb__6_0(ICellComponent c)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter._003C_003Ec::_003CBuildContext_003Eb__6_0");
				return default;
			}

			internal unsafe int _003CWalkSnake_003Eb__8_0((int x, int y, SnakeSegmentComponent seg) a, (int x, int y, SnakeSegmentComponent seg) b)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter._003C_003Ec::_003CWalkSnake_003Eb__8_0");
				return default;
			}

			internal int _003CBuildLinkedSandGroups_003Eb__10_1((int x, int y) k)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter._003C_003Ec::_003CBuildLinkedSandGroups_003Eb__10_1");
				return default;
			}

			internal int _003CBuildLinkedSandGroups_003Eb__10_2((int x, int y) k)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter._003C_003Ec::_003CBuildLinkedSandGroups_003Eb__10_2");
				return default;
			}

			internal unsafe int _003CBuildLinkedSandGroups_003Eb__10_3((int x, int y) a, (int x, int y) b)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter._003C_003Ec::_003CBuildLinkedSandGroups_003Eb__10_3");
				return default;
			}

			internal unsafe int _003CBuildLinkedSandGroups_003Eb__10_0(List<(int x, int y)> a, List<(int x, int y)> b)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter._003C_003Ec::_003CBuildLinkedSandGroups_003Eb__10_0");
				return default;
			}

			internal int _003CBuildLinkedMoldGroups_003Eb__11_0(((int x, int y) a, (int x, int y) b) p)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter._003C_003Ec::_003CBuildLinkedMoldGroups_003Eb__11_0");
				return default;
			}

			internal int _003CBuildLinkedMoldGroups_003Eb__11_1(((int x, int y) a, (int x, int y) b) p)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter._003C_003Ec::_003CBuildLinkedMoldGroups_003Eb__11_1");
				return default;
			}

			internal int _003CBuildLinkedMoldGroups_003Eb__11_2(((int x, int y) a, (int x, int y) b) p)
			{
				int result = default(int);
				return result;
			}

			internal int _003CBuildLinkedMoldGroups_003Eb__11_3(((int x, int y) a, (int x, int y) b) p)
			{
				object obj = default(object);
				return (int)((nint)obj >> 32);
			}

			internal bool _003CBuildTunnelQueueLine_003Eb__15_0(string s)
			{
				return s.Contains(" + ");
			}

			internal string _003CBuildTunnelQueueLine_003Eb__15_1(GameColor c)
			{
				//IL_0026: Expected O, but got I4
				int num = 187228160 + 2232;
				object obj = num;
				return ((Enum)obj).ToString();
			}

			internal string _003CAppendLegend_003Eb__20_0(GameColor c)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter._003C_003Ec::_003CAppendLegend_003Eb__20_0");
				return default;
			}

			internal string _003CFormatCountMap_003Eb__26_0(KeyValuePair<string, int> kv)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter._003C_003Ec::_003CFormatCountMap_003Eb__26_0");
				return default;
			}

			internal int _003CAppendSnakeGroups_003Eb__27_0(KeyValuePair<(int x, int y), (int snakeId, int segIdx, bool isHead)> kv)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [kv @ X1 (System.Collections.Generic.KeyValuePair`2<System.ValueTuple`2<System.Int32, System.Int32>, System.ValueTuple`3<System.Int32, System.Int32, System.Boolean>>)+8]");
				return 0;
			}

			internal int _003CAppendSnakeGroups_003Eb__27_1(IGrouping<int, KeyValuePair<(int x, int y), (int snakeId, int segIdx, bool isHead)>> g)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter._003C_003Ec::_003CAppendSnakeGroups_003Eb__27_1");
				return default;
			}

			internal int _003CAppendSnakeGroups_003Eb__27_2(KeyValuePair<(int x, int y), (int snakeId, int segIdx, bool isHead)> kv)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [kv @ X1 (System.Collections.Generic.KeyValuePair`2<System.ValueTuple`2<System.Int32, System.Int32>, System.ValueTuple`3<System.Int32, System.Int32, System.Boolean>>)+C]");
				return 0;
			}

			internal string _003CAppendSnakeGroups_003Eb__27_3(KeyValuePair<(int x, int y), (int snakeId, int segIdx, bool isHead)> kv)
			{
				//IL_0040: Expected O, but got I
				int num = 192761856 + 1336;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [kv @ X1 (System.Collections.Generic.KeyValuePair`2<System.ValueTuple`2<System.Int32, System.Int32>, System.ValueTuple`3<System.Int32, System.Int32, System.Boolean>>)+4]");
				object obj = 0;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				object arg = default(object);
				object arg2 = default(object);
				return $"({arg},{arg2})";
			}

			internal int _003CAppendPinGroups_003Eb__28_0(KeyValuePair<(int x, int y), (int pinId, int pathIdx, bool isTrigger)> kv)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [kv @ X1 (System.Collections.Generic.KeyValuePair`2<System.ValueTuple`2<System.Int32, System.Int32>, System.ValueTuple`3<System.Int32, System.Int32, System.Boolean>>)+8]");
				return 0;
			}

			internal int _003CAppendPinGroups_003Eb__28_1(IGrouping<int, KeyValuePair<(int x, int y), (int pinId, int pathIdx, bool isTrigger)>> g)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter._003C_003Ec::_003CAppendPinGroups_003Eb__28_1");
				return default;
			}

			internal int _003CAppendPinGroups_003Eb__28_2(KeyValuePair<(int x, int y), (int pinId, int pathIdx, bool isTrigger)> kv)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [kv @ X1 (System.Collections.Generic.KeyValuePair`2<System.ValueTuple`2<System.Int32, System.Int32>, System.ValueTuple`3<System.Int32, System.Int32, System.Boolean>>)+C]");
				return 0;
			}

			internal string _003CAppendPinGroups_003Eb__28_3(KeyValuePair<(int x, int y), (int pinId, int pathIdx, bool isTrigger)> kv)
			{
				//IL_0040: Expected O, but got I
				int num = 192761856 + 1336;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [kv @ X1 (System.Collections.Generic.KeyValuePair`2<System.ValueTuple`2<System.Int32, System.Int32>, System.ValueTuple`3<System.Int32, System.Int32, System.Boolean>>)+4]");
				object obj = 0;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				object arg = default(object);
				object arg2 = default(object);
				return $"({arg},{arg2})";
			}

			internal int _003CAppendLinkedSandGroups_003Eb__29_0(KeyValuePair<(int x, int y), int> kv)
			{
				int result = default(int);
				return result;
			}

			internal int _003CAppendLinkedSandGroups_003Eb__29_1(IGrouping<int, KeyValuePair<(int x, int y), int>> g)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter._003C_003Ec::_003CAppendLinkedSandGroups_003Eb__29_1");
				return default;
			}

			internal int _003CAppendLinkedSandGroups_003Eb__29_2(KeyValuePair<(int x, int y), int> kv)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter._003C_003Ec::_003CAppendLinkedSandGroups_003Eb__29_2");
				return default;
			}

			internal int _003CAppendLinkedSandGroups_003Eb__29_3(KeyValuePair<(int x, int y), int> kv)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter._003C_003Ec::_003CAppendLinkedSandGroups_003Eb__29_3");
				return default;
			}

			internal string _003CAppendLinkedSandGroups_003Eb__29_4(KeyValuePair<(int x, int y), int> kv)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter._003C_003Ec::_003CAppendLinkedSandGroups_003Eb__29_4");
				return default;
			}

			internal int _003CAppendGarageGroups_003Eb__30_0(KeyValuePair<(int x, int y), (int sizeX, int sizeY, int counter)> kv)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter._003C_003Ec::_003CAppendGarageGroups_003Eb__30_0");
				return default;
			}

			internal int _003CAppendGarageGroups_003Eb__30_1(KeyValuePair<(int x, int y), (int sizeX, int sizeY, int counter)> kv)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [kv @ X1 (System.Collections.Generic.KeyValuePair`2<System.ValueTuple`2<System.Int32, System.Int32>, System.ValueTuple`3<System.Int32, System.Int32, System.Int32>>)+4]");
				return 0;
			}

			internal int _003CAppendLinkedMoldGroups_003Eb__31_0(KeyValuePair<(int x, int y), int> kv)
			{
				int result = default(int);
				return result;
			}

			internal int _003CAppendLinkedMoldGroups_003Eb__31_1(IGrouping<int, KeyValuePair<(int x, int y), int>> g)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter._003C_003Ec::_003CAppendLinkedMoldGroups_003Eb__31_1");
				return default;
			}

			internal int _003CAppendLinkedMoldGroups_003Eb__31_2(KeyValuePair<(int x, int y), int> kv)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter._003C_003Ec::_003CAppendLinkedMoldGroups_003Eb__31_2");
				return default;
			}

			internal int _003CAppendLinkedMoldGroups_003Eb__31_3(KeyValuePair<(int x, int y), int> kv)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter._003C_003Ec::_003CAppendLinkedMoldGroups_003Eb__31_3");
				return default;
			}

			internal string _003CAppendLinkedMoldGroups_003Eb__31_4(KeyValuePair<(int x, int y), int> kv)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter._003C_003Ec::_003CAppendLinkedMoldGroups_003Eb__31_4");
				return default;
			}
		}

		[Token(Token = "0x4000A83")]
		internal static readonly IReadOnlyDictionary<GameColor, char> ColorLetterMap = new Dictionary<GameColor, char>
		{
			{
				default(GameColor),
				'R'
			},
			{
				GameColor.Blue,
				'L'
			},
			{
				GameColor.Yellow,
				'Y'
			},
			{
				GameColor.Green,
				'G'
			},
			{
				GameColor.Brown,
				'B'
			},
			{
				GameColor.DarkGreen,
				'D'
			},
			{
				GameColor.DarkGrey,
				'K'
			},
			{
				GameColor.LightBlue,
				'E'
			},
			{
				GameColor.LightGrey,
				'I'
			},
			{
				GameColor.Orange,
				'O'
			},
			{
				GameColor.Pink,
				'N'
			},
			{
				GameColor.Purple,
				'P'
			},
			{
				GameColor.Turquoise,
				'T'
			}
		};

		[Token(Token = "0x6000E5A")]
		[Address(RVA = "0x3F0A0D8", Offset = "0x3F0A0D8", Length = "0x2C0")]
		public static string Format(LevelCreatorData data, Func<GridCoord, bool> isNoPlace, Func<GridCoord, bool> isNoPlaceWall = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter::Format");
			return default;
		}

		[Token(Token = "0x6000E5B")]
		[Address(RVA = "0x3F0D308", Offset = "0x3F0D308", Length = "0x124")]
		internal unsafe static char ColorLetter(GameColor c)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter::ColorLetter");
			return default;
		}

		[Token(Token = "0x6000E5C")]
		[Address(RVA = "0x3F0D42C", Offset = "0x3F0D42C", Length = "0x70")]
		internal static string ColorName(GameColor c)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter::ColorName");
			return default;
		}

		[Token(Token = "0x6000E5D")]
		[Address(RVA = "0x3F0D49C", Offset = "0x3F0D49C", Length = "0x2C")]
		private static char TunnelGlyph(TunnelDirection d)
		{
			//IL_0012: Expected I4, but got I8
			//IL_0032: Expected I4, but got I8
			int num = (int)((long)d & 0xFFFFFFFFL);
			int num2 = num << 4;
			int num3 = (int)(17451706260258934L >> num2);
			if ((uint)d >= 4u)
			{
				num3 = 118;
			}
			return (char)(num3 & 0x7E);
		}

		[Token(Token = "0x6000E5E")]
		[Address(RVA = "0x3F0A398", Offset = "0x3F0A398", Length = "0x1974")]
		internal unsafe static Ctx BuildContext(LevelCreatorData data)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter::BuildContext");
			return default;
		}

		[Token(Token = "0x6000E5F")]
		[Address(RVA = "0x3F0EE0C", Offset = "0x3F0EE0C", Length = "0x618")]
		private static void CollectSandSnakeNodes(GridData<SandCubeCellData> grid, Dictionary<(int x, int y), (int snakeId, int segIdx, bool isHead)> outMap)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter::CollectSandSnakeNodes");
		}

		[Token(Token = "0x6000E60")]
		[Address(RVA = "0x3F14038", Offset = "0x3F14038", Length = "0x3FC")]
		private unsafe static void WalkSnake(int x, int y, int snakeId, ref int idx, Dictionary<(int, int), List<(int x, int y, SnakeSegmentComponent seg)>> childrenByParent, Dictionary<(int x, int y), (int snakeId, int segIdx, bool isHead)> outMap)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter::WalkSnake");
		}

		[Token(Token = "0x6000E61")]
		[Address(RVA = "0x3F0F424", Offset = "0x3F0F424", Length = "0x3C4")]
		private static (int, int, bool)? ExtractPinNode(DrawableEntity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter::ExtractPinNode");
			return default;
		}

		[Token(Token = "0x6000E62")]
		[Address(RVA = "0x3F0D8F4", Offset = "0x3F0D8F4", Length = "0xE94")]
		internal unsafe static Dictionary<(int, int), int> BuildLinkedSandGroups(GridData<SandCubeCellData> grid)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter::BuildLinkedSandGroups");
			return default;
		}

		[Token(Token = "0x6000E63")]
		[Address(RVA = "0x3F0E788", Offset = "0x3F0E788", Length = "0x684")]
		private static Dictionary<(int, int), int> BuildLinkedMoldGroups(GridData<MoldCellData> grid)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter::BuildLinkedMoldGroups");
			return default;
		}

		[Token(Token = "0x6000E64")]
		[Address(RVA = "0x3F14434", Offset = "0x3F14434", Length = "0x110")]
		private static void AddEdge(Dictionary<(int x, int y), HashSet<(int x, int y)>> adj, (int x, int y) a, (int x, int y) b)
		{
			HashSet<(int, int)> hashSet = default(HashSet<(int, int)>);
			if (!adj.TryGetValue(a, out HashSet<(int, int)> _))
			{
				hashSet = (adj[a] = new HashSet<(int, int)>());
			}
			bool flag = hashSet.Add(b);
		}

		[Token(Token = "0x6000E65")]
		[Address(RVA = "0x3F0F7E8", Offset = "0x3F0F7E8", Length = "0x360")]
		private unsafe static char ResolveSandBaseChar(SandCubeCellData cell, bool isGarageAnchor, out GameColor? cubeColor)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter::ResolveSandBaseChar");
			cubeColor = default;
			return default;
		}

		[Token(Token = "0x6000E66")]
		[Address(RVA = "0x3F0FBEC", Offset = "0x3F0FBEC", Length = "0x874")]
		private unsafe static List<string> CollectSandModifiers(SandCubeCellData cell, (int x, int y) coord, Dictionary<(int x, int y), (int snakeId, int segIdx, bool isHead)> snakeIdByCoord, Dictionary<(int x, int y), (int pinId, int pathIdx, bool isTrigger)> pinIdByCoord, Dictionary<(int x, int y), int> linkedSandGroups)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter::CollectSandModifiers");
			return default;
		}

		[Token(Token = "0x6000E67")]
		[Address(RVA = "0x3F10460", Offset = "0x3F10460", Length = "0x64C")]
		private static string BuildTunnelQueueLine(SandCubeCellData cell)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter::BuildTunnelQueueLine");
			return default;
		}

		[Token(Token = "0x6000E68")]
		[Address(RVA = "0x3F14544", Offset = "0x3F14544", Length = "0x9FC")]
		private unsafe static string BuildModernTunnelSlot(TunnelSlotData slot)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter::BuildModernTunnelSlot");
			return default;
		}

		[Token(Token = "0x6000E69")]
		[Address(RVA = "0x3F14F40", Offset = "0x3F14F40", Length = "0x188")]
		private static GameColor? TryGetEntityColor(object component)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter::TryGetEntityColor");
			return default;
		}

		[Token(Token = "0x6000E6A")]
		[Address(RVA = "0x3F10AAC", Offset = "0x3F10AAC", Length = "0x9BC")]
		private static void AccumulateTunnelQueueCounts(SandCubeCellData cell, SortedDictionary<string, int> counts)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter::AccumulateTunnelQueueCounts");
		}

		[Token(Token = "0x6000E6B")]
		[Address(RVA = "0x3F0BD0C", Offset = "0x3F0BD0C", Length = "0x44C")]
		private static void AppendSandGrid(StringBuilder sb, GridData<SandCubeCellData> grid, Ctx ctx, Func<GridCoord, bool> isNoPlace, Func<GridCoord, bool> isNoPlaceWall)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter::AppendSandGrid");
		}

		[Token(Token = "0x6000E6C")]
		[Address(RVA = "0x3F0C158", Offset = "0x3F0C158", Length = "0x424")]
		private static void AppendLegend(StringBuilder sb, Ctx ctx)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter::AppendLegend");
		}

		[Token(Token = "0x6000E6D")]
		[Address(RVA = "0x3F0C57C", Offset = "0x3F0C57C", Length = "0x354")]
		private static void AppendCellDetails(StringBuilder sb, Ctx ctx)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter::AppendCellDetails");
		}

		[Token(Token = "0x6000E6E")]
		[Address(RVA = "0x3F0C8D0", Offset = "0x3F0C8D0", Length = "0x3AC")]
		private static void AppendMoldGrid(StringBuilder sb, GridData<MoldCellData> grid, Ctx ctx)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter::AppendMoldGrid");
		}

		[Token(Token = "0x6000E6F")]
		[Address(RVA = "0x3F0CC7C", Offset = "0x3F0CC7C", Length = "0x310")]
		private static void AppendMoldDetails(StringBuilder sb, Ctx ctx)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter::AppendMoldDetails");
		}

		[Token(Token = "0x6000E70")]
		[Address(RVA = "0x3F0CF8C", Offset = "0x3F0CF8C", Length = "0x1F0")]
		private unsafe static void AppendGroups(StringBuilder sb, Ctx ctx)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter::AppendGroups");
		}

		[Token(Token = "0x6000E71")]
		[Address(RVA = "0x3F0D17C", Offset = "0x3F0D17C", Length = "0x18C")]
		private static void AppendCounts(StringBuilder sb, Ctx ctx)
		{
			StringBuilder stringBuilder = sb.Append("counts:\n");
			StringBuilder stringBuilder2 = sb.Append("  cubes:        ");
			string value = FormatCountMap(ctx.CubeCounts);
			StringBuilder stringBuilder3 = stringBuilder2.Append(value);
			StringBuilder stringBuilder4 = stringBuilder3.Append('\n');
			StringBuilder stringBuilder5 = sb.Append("  molds:        ");
			string value2 = FormatCountMap(ctx.MoldCounts);
			StringBuilder stringBuilder6 = stringBuilder5.Append(value2);
			StringBuilder stringBuilder7 = stringBuilder6.Append('\n');
			StringBuilder stringBuilder8 = sb.Append("  tunnelQueue:  ");
			string value3 = FormatCountMap(ctx.TunnelQueueCounts);
			StringBuilder stringBuilder9 = stringBuilder8.Append(value3);
			StringBuilder stringBuilder10 = stringBuilder9.Append('\n');
		}

		[Token(Token = "0x6000E72")]
		[Address(RVA = "0x3F150C8", Offset = "0x3F150C8", Length = "0x1D0")]
		private static string FormatCountMap(SortedDictionary<string, int> counts)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter::FormatCountMap");
			return default;
		}

		[Token(Token = "0x6000E73")]
		[Address(RVA = "0x3F11468", Offset = "0x3F11468", Length = "0x824")]
		private static void AppendSnakeGroups(Ctx ctx, GridData<SandCubeCellData> grid, Dictionary<(int x, int y), (int snakeId, int segIdx, bool isHead)> snakeIdByCoord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter::AppendSnakeGroups");
		}

		[Token(Token = "0x6000E74")]
		[Address(RVA = "0x3F11C8C", Offset = "0x3F11C8C", Length = "0xB08")]
		private static void AppendPinGroups(Ctx ctx, Dictionary<(int x, int y), (int pinId, int pathIdx, bool isTrigger)> pinIdByCoord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter::AppendPinGroups");
		}

		[Token(Token = "0x6000E75")]
		[Address(RVA = "0x3F12794", Offset = "0x3F12794", Length = "0x8B0")]
		private static void AppendLinkedSandGroups(Ctx ctx, Dictionary<(int x, int y), int> linkedSandGroups)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter::AppendLinkedSandGroups");
		}

		[Token(Token = "0x6000E76")]
		[Address(RVA = "0x3F13044", Offset = "0x3F13044", Length = "0x730")]
		private unsafe static void AppendGarageGroups(Ctx ctx, Dictionary<(int x, int y), (int sizeX, int sizeY, int counter)> garageAnchors)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter::AppendGarageGroups");
		}

		[Token(Token = "0x6000E77")]
		[Address(RVA = "0x3F13774", Offset = "0x3F13774", Length = "0x8C4")]
		private static void AppendLinkedMoldGroups(Ctx ctx, Dictionary<(int x, int y), int> linkedMoldGroups)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LlmSnapshotFormatter::AppendLinkedMoldGroups");
		}

		[Token(Token = "0x6000E78")]
		[Address(RVA = "0x3F0FB48", Offset = "0x3F0FB48", Length = "0xA4")]
		private static void Bump(SortedDictionary<string, int> map, string key)
		{
			bool flag = map.TryGetValue(key, out var value);
			int value2 = value + 1;
			map[key] = value2;
		}
	}
}
