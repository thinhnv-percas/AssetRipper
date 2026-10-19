using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Cpp2ILInjected;
using _game.CoreSystem.LevelCreator;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.LevelData;
using _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.LevelData;
using _game.CoreSystem.SandSystem.Components;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Driver
{
	[Token(Token = "0x2000394")]
	public static class VisualSnapshotFormatter
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000395")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000AF4")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000AF5")]
			public static Func<ICellComponent, bool> _003C_003E9__3_1;

			[Token(Token = "0x4000AF6")]
			public static Func<int, string> _003C_003E9__3_0;

			[Token(Token = "0x4000AF7")]
			public static Func<string, bool> _003C_003E9__7_0;

			[Token(Token = "0x4000AF8")]
			public static Func<string, bool> _003C_003E9__10_0;

			[Token(Token = "0x4000AF9")]
			public static Func<string, bool> _003C_003E9__11_0;

			[Token(Token = "0x4000AFA")]
			public static Func<KeyValuePair<string, int>, string> _003C_003E9__12_1;

			[Token(Token = "0x4000AFB")]
			public static Func<GameColor, string> _003C_003E9__13_0;

			[Token(Token = "0x4000AFC")]
			public static Func<GameColor, string> _003C_003E9__13_1;

			[Token(Token = "0x6000F10")]
			[Address(RVA = "0x3C95320", Offset = "0x3C95320", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000F11")]
			[Address(RVA = "0x3C95384", Offset = "0x3C95384", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal bool _003CAppendBreakable_003Eb__3_1(ICellComponent c)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("VisualSnapshotFormatter._003C_003Ec::_003CAppendBreakable_003Eb__3_1");
				return default;
			}

			internal string _003CAppendBreakable_003Eb__3_0(int i)
			{
				int num = 192761856 + 1336;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				object arg = default(object);
				return $"cell {arg}";
			}

			internal bool _003CAppendCellDetails_003Eb__7_0(string m)
			{
				bool flag = m.StartsWith("tunnel(");
				return (byte)((flag ? 1u : 0u) ^ 1u) != 0;
			}

			internal bool _003CQueuePart_003Eb__10_0(string m)
			{
				return m.StartsWith("tunnel(");
			}

			internal bool _003CAppendGroups_003Eb__11_0(string l)
			{
				bool flag = l.StartsWith("linkedMold");
				return (byte)((flag ? 1u : 0u) ^ 1u) != 0;
			}

			internal string _003CAppendCounts_003Eb__12_1(KeyValuePair<string, int> kv)
			{
				object obj2 = default(object);
				object obj = obj2;
				int num = 192761856 + 1336;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				object arg = default(object);
				return $"{kv}:{arg}";
			}

			internal string _003CAppendLegend_003Eb__13_0(GameColor c)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("VisualSnapshotFormatter._003C_003Ec::_003CAppendLegend_003Eb__13_0");
				return default;
			}

			internal string _003CAppendLegend_003Eb__13_1(GameColor c)
			{
				char c2 = LlmSnapshotFormatter.ColorLetter(c);
				char c3 = c2;
				int num = 192761856 + 1336;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				string arg = LlmSnapshotFormatter.ColorName(c);
				object arg2 = default(object);
				return $"{arg2}={arg}";
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000396")]
		private sealed class _003C_003Ec__DisplayClass11_0
		{
			[Token(Token = "0x4000AFD")]
			[FieldOffset(Offset = "0x10")]
			public VisualIndexMap map;

			[Token(Token = "0x6000F1A")]
			[Address(RVA = "0x3C951A4", Offset = "0x3C951A4", Length = "0x8")]
			public _003C_003Ec__DisplayClass11_0()
			{
			}

			internal string _003CAppendGroups_003Eb__1(string l)
			{
				return VisualIndexText.TranslateCoords(l, map);
			}
		}

		[Token(Token = "0x4000AF2")]
		private const int LabelWidth = 6;

		[Token(Token = "0x4000AF3")]
		private const int CellWidth = 4;

		[Token(Token = "0x6000F03")]
		[Address(RVA = "0x3C9243C", Offset = "0x3C9243C", Length = "0x1C4")]
		public static string Format(LevelCreatorData data, VisualIndexMap map, Func<GridCoord, bool> isPourableAtStart = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VisualSnapshotFormatter::Format");
			return default;
		}

		[Token(Token = "0x6000F04")]
		[Address(RVA = "0x3C92E24", Offset = "0x3C92E24", Length = "0x508")]
		private static void AppendBreakable(StringBuilder sb, LevelCreatorData data, VisualIndexMap map, Func<GridCoord, bool> isPourableAtStart)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VisualSnapshotFormatter::AppendBreakable");
		}

		[Token(Token = "0x6000F05")]
		[Address(RVA = "0x3C92600", Offset = "0x3C92600", Length = "0x4D8")]
		private static void AppendHeader(StringBuilder sb, VisualIndexMap map)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VisualSnapshotFormatter::AppendHeader");
		}

		[Token(Token = "0x6000F06")]
		[Address(RVA = "0x3C92AD8", Offset = "0x3C92AD8", Length = "0x34C")]
		private static void AppendPicture(StringBuilder sb, LevelCreatorData data, VisualIndexMap map)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VisualSnapshotFormatter::AppendPicture");
		}

		[Token(Token = "0x6000F07")]
		[Address(RVA = "0x3C94A2C", Offset = "0x3C94A2C", Length = "0x4E0")]
		private unsafe static char GlyphAt(LevelCreatorData data, VisualIndexMap map, int index, GridCoord c)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VisualSnapshotFormatter::GlyphAt");
			return default;
		}

		[Token(Token = "0x6000F08")]
		[Address(RVA = "0x3C9332C", Offset = "0x3C9332C", Length = "0x638")]
		private unsafe static void AppendCellDetails(StringBuilder sb, LlmSnapshotFormatter.Ctx ctx, VisualIndexMap map)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VisualSnapshotFormatter::AppendCellDetails");
		}

		[Token(Token = "0x6000F09")]
		[Address(RVA = "0x3C93964", Offset = "0x3C93964", Length = "0x838")]
		private unsafe static void AppendTunnels(StringBuilder sb, LevelCreatorData data, LlmSnapshotFormatter.Ctx ctx, VisualIndexMap map)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VisualSnapshotFormatter::AppendTunnels");
		}

		[Token(Token = "0x6000F0A")]
		[Address(RVA = "0x3C94F0C", Offset = "0x3C94F0C", Length = "0xB0")]
		private unsafe static GridCoord FedCell(GridCoord at, TunnelDirection d)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VisualSnapshotFormatter::FedCell");
			return default;
		}

		[Token(Token = "0x6000F0B")]
		[Address(RVA = "0x3C94FBC", Offset = "0x3C94FBC", Length = "0x1E8")]
		private static string QueuePart(LlmSnapshotFormatter.Ctx ctx, (int x, int y) key)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VisualSnapshotFormatter::QueuePart");
			return default;
		}

		[Token(Token = "0x6000F0C")]
		[Address(RVA = "0x3C9419C", Offset = "0x3C9419C", Length = "0x364")]
		private unsafe static void AppendGroups(StringBuilder sb, LlmSnapshotFormatter.Ctx ctx, VisualIndexMap map)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VisualSnapshotFormatter::AppendGroups");
		}

		[Token(Token = "0x6000F0D")]
		[Address(RVA = "0x3C94500", Offset = "0x3C94500", Length = "0xF4")]
		private static void AppendCounts(StringBuilder sb, LlmSnapshotFormatter.Ctx ctx)
		{
			string text = Join(ctx.CubeCounts);
			string value = "cubes:       " + text;
			StringBuilder stringBuilder = sb.AppendLine(value);
			int count = ctx.TunnelQueueCounts.Count;
			if (count >= 1)
			{
				string text2 = Join(ctx.TunnelQueueCounts);
				string value2 = "tunnelQueue: " + text2;
				StringBuilder stringBuilder2 = sb.AppendLine(value2);
			}
			StringBuilder stringBuilder3 = sb.AppendLine();
			[Token(Token = "0x6000F0F")]
			[Address(RVA = "0x3C951AC", Offset = "0x3C951AC", Length = "0x174")]
			static string Join(SortedDictionary<string, int> d)
			{
				bool flag = _003C_003Ec._003C_003E9__12_1 == null;
				bool flag2 = !flag;
				Func<KeyValuePair<object, int>, object> selector = (Func<KeyValuePair<object, int>, object>)(object)_003C_003Ec._003C_003E9__12_1;
				if (!flag2)
				{
					selector = (Func<KeyValuePair<object, int>, object>)(object)(_003C_003Ec._003C_003E9__12_1 = delegate(KeyValuePair<string, int> kv)
					{
						object obj2 = default(object);
						object obj = obj2;
						int num = 192761856 + 1336;
						Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
						object arg = default(object);
						return $"{kv}:{arg}";
					});
				}
				IEnumerable<object> values = ((IEnumerable<KeyValuePair<object, int>>)d).Select(selector);
				string text3 = string.Join(", ", (IEnumerable<string>)values);
				return "{" + text3 + "}";
			}
		}

		[Token(Token = "0x6000F0E")]
		[Address(RVA = "0x3C945F4", Offset = "0x3C945F4", Length = "0x438")]
		private static void AppendLegend(StringBuilder sb, LlmSnapshotFormatter.Ctx ctx)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VisualSnapshotFormatter::AppendLegend");
		}
	}
}
