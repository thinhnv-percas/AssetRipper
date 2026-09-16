using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Core.Easing;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening.Plugins
{
	[Token(Token = "0x200001D")]
	internal class Color2Plugin : ABSTweenPlugin<Color2, Color2, ColorOptions>
	{
		[Token(Token = "0x600017F")]
		[Address(RVA = "0x107F32C", Offset = "0x107F32C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Reset(TweenerCore<Color2, Color2, ColorOptions> t)
		{
		}

		[Token(Token = "0x6000180")]
		[Address(RVA = "0x107F330", Offset = "0x107F330", Length = "0x230")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv40 = *([1EEE6E8]);\n\tv41 = *([v40 @ X8_v22]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, t, isRelative, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv59 = 0 | 1;\n\t*([2026A3C]) = v59;\nL_0029:\n\tv157 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+140]);\n\tv155 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+144]);\n\tv153 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+148]);\n\tv151 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+14C]);\n\tv149 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+150]);\n\tv147 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+154]);\n\tv145 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+158]);\n\tv81 = DG.Tweening.Core.DOGetter`1<DG.Tweening.Color2>::Invoke(t.getter);\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+14C]) = v170;\n\tt.endValue = v80;\n\tv173 = isRelative == 0;\n\tif (v173) goto L_0064;\n\t// 70 MakeStruct v183 @ AGG107F410_0_v3 (UnityEngine.Color), typeof(UnityEngine.Color), t.endValue (DG.Tweening.Color2), [t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+140], [t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+144], [t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+148]\n\t// 71 MakeStruct v184 @ AGG107F410_1_v3 (UnityEngine.Color), typeof(UnityEngine.Color), t.endValue (DG.Tweening.Color2), [t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+140], [t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+144], [t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+148]\n\tv185 = UnityEngine.Color::op_Addition(v183, v184);\n\t// 90 MakeStruct v187 @ AGG107F44C_0_v3 (UnityEngine.Color), typeof(UnityEngine.Color), [t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+14C], [t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+150], [t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+154], [t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+158]\n\t// 91 MakeStruct v186 @ AGG107F44C_1_v3 (UnityEngine.Color), typeof(UnityEngine.Color), [t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+14C], [t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+150], [t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+154], [t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+158]\n\tv195 = UnityEngine.Color::op_Addition(v187, v186);\nL_0064:\n\tt.startValue = v159;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+120]) = v157;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+124]) = v155;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+128]) = v153;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+12C]) = v151;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+130]) = v149;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+134]) = v147;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+138]) = v145;\n\tv215 = t.plugOptions == 0;\n\tv216 = ~v215;\n\tif (v216) goto L_009B;\nL_009B:\n\tDG.Tweening.Core.DOSetter`1<DG.Tweening.Color2>::Invoke(t.setter, &v105 @ stack_-A0_v4 (DG.Tweening.Color2));\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 136 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override void SetFrom(TweenerCore<Color2, Color2, ColorOptions> t, bool isRelative)
		{
			//IL_0015: Expected F4, but got I
			//IL_0025: Expected F4, but got I
			//IL_0035: Expected F4, but got I
			//IL_0045: Expected O, but got I
			//IL_0055: Expected F4, but got I
			//IL_0065: Expected F4, but got I
			//IL_0075: Expected F4, but got I
			//IL_02bb: Expected O, but got Ref
			//IL_00d5: Expected F4, but got O
			//IL_00ea: Expected F4, but got I
			//IL_00ff: Expected F4, but got I
			//IL_0114: Expected F4, but got I
			//IL_0126: Expected F4, but got O
			//IL_013b: Expected F4, but got I
			//IL_0150: Expected F4, but got I
			//IL_0165: Expected F4, but got I
			//IL_018b: Expected F4, but got I
			//IL_01a0: Expected F4, but got I
			//IL_01b5: Expected F4, but got I
			//IL_01ca: Expected F4, but got I
			//IL_01df: Expected F4, but got I
			//IL_01f4: Expected F4, but got I
			//IL_0209: Expected F4, but got I
			//IL_021e: Expected F4, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+140]");
			float num = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+144]");
			float num2 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+148]");
			float num3 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+14C]");
			Color color = (Color)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+150]");
			float num4 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+154]");
			float num5 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+158]");
			float num6 = 0f;
			Color2 color2 = t.getter();
			Color2 endValue = default(Color2);
			t.endValue = endValue;
			bool flag = !isRelative;
			Color startValue = (Color)t.endValue;
			if (!flag)
			{
				Color color3 = default(Color);
				color3.r = (float)t.endValue;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+140]");
				color3.g = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+144]");
				color3.b = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+148]");
				color3.a = 0f;
				Color color4 = default(Color);
				color4.r = (float)t.endValue;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+140]");
				color4.g = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+144]");
				color4.b = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+148]");
				color4.a = 0f;
				Color color5 = color3 + color4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+14C]");
				Color color6 = default(Color);
				color6.r = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+150]");
				color6.g = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+154]");
				color6.b = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+158]");
				color6.a = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+14C]");
				Color color7 = default(Color);
				color7.r = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+150]");
				color7.g = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+154]");
				color7.b = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+158]");
				color7.a = 0f;
				Color color8 = color6 + color7;
				num6 = color8.a;
				num5 = color8.b;
				num4 = color8.g;
				color = color8;
				num3 = color5.a;
				num2 = color5.b;
				num = color5.g;
				startValue = color5;
			}
			t.startValue = (Color2)startValue;
			bool flag2 = (object)t.plugOptions == null;
			bool flag3 = !flag2;
			Color2 color9 = t.endValue;
			if (!flag3)
			{
				color9 = t.startValue;
			}
			t.setter((Color2)(&color9));
		}

		[Token(Token = "0x6000181")]
		[Address(RVA = "0x107F560", Offset = "0x107F560", Length = "0x174")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv26 = *([1EDD810]);\n\tv27 = *([v26 @ X8_v22]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, t, fromValue, setImmediately, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([2026A3D]) = v44;\nL_0023:\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+12C]) = fromValue.cb;\n\tt.startValue = fromValue.ca;\n\tv59 = setImmediately == 0;\n\tif (v59) goto L_0069;\n\tv71 = t.plugOptions == 0;\n\tif (v71) goto L_0061;\n\tv181 = DG.Tweening.Core.DOGetter`1<DG.Tweening.Color2>::Invoke(t.getter);\nL_0061:\n\tDG.Tweening.Core.DOSetter`1<DG.Tweening.Color2>::Invoke(t.setter, &v123 @ stack_-60_v5 (UnityEngine.Color));\nL_0069:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 92 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override void SetFrom(TweenerCore<Color2, Color2, ColorOptions> t, Color2 fromValue, bool setImmediately)
		{
			//IL_009e: Expected O, but got Ref
			_ = fromValue.cb;
			t.startValue = (Color2)fromValue.ca;
			if (setImmediately)
			{
				bool flag = (object)t.plugOptions == null;
				Color color = fromValue.ca;
				if (!flag)
				{
					Color2 color2 = t.getter();
					Color color3 = default(Color);
					color = color3;
				}
				t.setter((Color2)(&color));
			}
		}

		[Token(Token = "0x6000182")]
		[Address(RVA = "0x107F6D4", Offset = "0x107F6D4", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnBuffer.cb = value.tweenType;\n\treturnBuffer.ca = value->klass;\n\treturn this;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override Color2 ConvertToStartValue(TweenerCore<Color2, Color2, ColorOptions> t, Color2 value)
		{
			//IL_0012: Expected O, but got I4
			//IL_000d: Expected native int or pointer, but got O
			//IL_001a: Expected native int or pointer, but got O
			Color2 color = default(Color2);
			((Color2*)(IntPtr)color)->cb = (Color)((TweenerCore<Color2, Color2, ColorOptions>)value).tweenType;
			((Color2*)(IntPtr)color)->ca = (Color)value;
			return (Color2)this;
		}

		[Token(Token = "0x6000183")]
		[Address(RVA = "0x107F6E8", Offset = "0x107F6E8", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = &v9 @ stack_-10_v2;\n\tv17 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+14C]);\n\tv16 = &v9 @ stack_-10_v2 - 0x30;\n\t*([v8 @ X29_v1-20]) = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+14C]);\n\tv17 = t.endValue;\n\t*([v8 @ X29_v1-30]) = t.endValue;\n\tv17 = t.startValue;\n\tv26 = DG.Tweening.Color2::op_Addition(v16, &v17 @ V0_v2 (DG.Tweening.Color2));\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+14C]) = v26.cb;\n\tt.endValue = v26.ca;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override void SetRelativeEndValue(TweenerCore<Color2, Color2, ColorOptions> t)
		{
			//IL_001d: Expected O, but got I
			//IL_002c: Expected O, but got I
			//IL_006a: Expected O, but got Ref
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+14C]");
			Color2 color = (Color2)0;
			Color2 color2 = (Color2)((long)(IntPtr)obj2 - 48L);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+14C]");
			_ = 0;
			color = t.endValue;
			_ = t.endValue;
			color = t.startValue;
			Color2 color3 = color2 + (Color2)(&color);
			_ = color3.cb;
			t.endValue = (Color2)color3.ca;
		}

		[Token(Token = "0x6000184")]
		[Address(RVA = "0x107F764", Offset = "0x107F764", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = &v7 @ stack_-10_v2;\n\tv17 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+14C]);\n\tv14 = &v7 @ stack_-10_v2 - 0x30;\n\t*([v6 @ X29_v1-20]) = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+14C]);\n\tv17 = t.endValue;\n\t*([v6 @ X29_v1-30]) = t.endValue;\n\tv17 = t.startValue;\n\tv25 = DG.Tweening.Color2::op_Subtraction(v14, &v17 @ V0_v2 (DG.Tweening.Color2));\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+16C]) = v25.cb;\n\tt.changeValue = v25.ca;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override void SetChangeValue(TweenerCore<Color2, Color2, ColorOptions> t)
		{
			//IL_001d: Expected O, but got I
			//IL_002c: Expected O, but got I
			//IL_006a: Expected O, but got Ref
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+14C]");
			Color2 color = (Color2)0;
			Color2 color2 = (Color2)((long)(IntPtr)obj2 - 48L);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>)+14C]");
			_ = 0;
			color = t.endValue;
			_ = t.endValue;
			color = t.startValue;
			Color2 color3 = color2 - (Color2)(&color);
			_ = color3.cb;
			t.changeValue = (Color2)color3.ca;
		}

		[Token(Token = "0x6000185")]
		[Address(RVA = "0x107F7EC", Offset = "0x107F7EC", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = 1f / unitsXSecond;\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override float GetSpeedBasedDuration(ColorOptions options, float unitsXSecond, Color2 changeValue)
		{
			return 1f / unitsXSecond;
		}

		[Token(Token = "0x6000186")]
		[Address(RVA = "0x107F7F8", Offset = "0x107F7F8", Length = "0x45C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = &v25 @ stack_-10_v2;\n\tgoto L_0024;\n\tv48 = *([1EC70E8]);\n\tv49 = *([v48 @ X8_v40]);\n\tv50 = \"il2cpp_codegen_initialize_method\"(v49, options, t, isRelative, getter, setter, startValue, changeValue, elapsed, duration, v52, v53, v54, v55, v56, v57);\n\tv61 = 0 | 1;\n\t*([2026A3E]) = v61;\nL_0024:\n\t*([v24 @ X29_v1-90]) = 0;\n\t*([v24 @ X29_v1-80]) = 0;\n\t*([v24 @ X29_v1-B0]) = 0;\n\t*([v24 @ X29_v1-A0]) = 0;\n\t*([v24 @ X29_v1-D0]) = 0;\n\t*([v24 @ X29_v1-C0]) = 0;\n\t*([v24 @ X29_v1-F0]) = 0;\n\t*([v24 @ X29_v1-E0]) = 0;\n\tv102 = t.loopType != 2;\n\tif (v102) goto L_00A8;\n\t*([v24 @ X29_v1-60]) = startValue.cb;\n\t*([v24 @ X29_v1-70]) = startValue.ca;\n\t*([v24 @ X29_v1-D0]) = changeValue.ca;\n\t*([v24 @ X29_v1-C0]) = changeValue.cb;\n\t*([v24 @ X29_v1-F0]) = *([v24 @ X29_v1-70]);\n\t*([v24 @ X29_v1-E0]) = *([v24 @ X29_v1-60]);\n\tv397 = ~t.isComplete;\n\tif (v397) goto L_FFFFFFFF;\n\t*([v24 @ X29_v1-90]) = changeValue.ca;\n\t*([v24 @ X29_v1-80]) = changeValue.cb;\n\t*([v24 @ X29_v1-B0]) = *([v24 @ X29_v1-70]);\n\t*([v24 @ X29_v1-A0]) = *([v24 @ X29_v1-60]);\n\tv435 = t.completedLoops - 1;\n\tgoto L_0089;\nL_0089:\n\tv631 = &v287 @ stack_-340;\n\tv632 = DG.Tweening.Color2::op_Multiply(&v412 @ stack_-120_v4, v626);\n\tv287 = *([v631 @ X8_v33]);\n\tv419 = DG.Tweening.Color2::op_Addition(&v411 @ stack_-140_v4, &v287 @ stack_-340);\n\tstartValue.cb = *([v24 @ X29_v1-60]);\n\tstartValue.ca = *([v24 @ X29_v1-70]);\nL_00A8:\n\tv424 = ~t.isSequenced;\n\tif (v424) goto L_0152;\n\tv382 = t.sequenceParent;\n\tv483 = v382.loopType != 2;\n\tif (v483) goto L_0152;\n\t*([v24 @ X29_v1-60]) = startValue.cb;\n\t*([v24 @ X29_v1-70]) = startValue.ca;\n\tv333 = t.loopType != 2;\n\tif (v333) goto L_FFFFFFFF;\n\tgoto L_00F5;\nL_00F5:\n\tv370 = DG.Tweening.Color2::op_Multiply(&v209 @ stack_-1E0_v4 (UnityEngine.Color), v328);\n\tv383 = t.sequenceParent;\n\tv495 = ~v383.isComplete;\n\tif (v495) goto L_FFFFFFFF;\n\tv759 = v383.completedLoops - 1;\n\tgoto L_012E;\nL_012E:\n\tv778 = &v169 @ stack_-3C0;\n\tv779 = DG.Tweening.Color2::op_Multiply(&v463 @ stack_-2A0_v4, v773);\n\tv169 = *([v778 @ X8_v26]);\n\tv493 = DG.Tweening.Color2::op_Addition(&v461 @ stack_-2C0_v4, &v169 @ stack_-3C0);\n\tstartValue.cb = *([v24 @ X29_v1-60]);\n\tstartValue.ca = *([v24 @ X29_v1-70]);\nL_0152:\n\tv329 = DG.Tweening.Core.Easing.EaseManager::Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);\n\tv384 = options & 0xFF;\n\tv634 = v384 == 0;\n\tif (v634) goto L_0182;\n\tv372 = DG.Tweening.Core.DOGetter`1<DG.Tweening.Color2>::Invoke(getter);\n\tv730 = v329 * *([changeValue @ X7 (DG.Tweening.Color2)+C]);\n\tv732 = *([startValue @ X6 (DG.Tweening.Color2)+C]) + v730;\n\t*([v24 @ X29_v1-70]) = v306;\n\t*([v24 @ X29_v1-68]) = v725;\n\t*([v24 @ X29_v1-64]) = v732;\n\t*([v24 @ X29_v1-60]) = v299;\n\tv731 = v329 * *([changeValue @ X7 (DG.Tweening.Color2)+1C]);\n\tv733 = *([startValue @ X6 (DG.Tweening.Color2)+1C]) + v731;\n\t*([v24 @ X29_v1-58]) = v726;\n\t*([v24 @ X29_v1-54]) = v733;\n\tgoto L_01B4;\nL_0182:\n\tv656 = v329 * changeValue.ca;\n\tv657 = startValue.ca + v656;\n\tstartValue.ca = v657;\n\tv659 = v329 * *([changeValue @ X7 (DG.Tweening.Color2)+4]);\n\tv660 = *([startValue @ X6 (DG.Tweening.Color2)+4]) + v659;\n\t*([startValue @ X6 (DG.Tweening.Color2)+4]) = v660;\n\tv664 = v329 * *([changeValue @ X7 (DG.Tweening.Color2)+8]);\n\tv665 = *([startValue @ X6 (DG.Tweening.Color2)+8]) + v664;\n\t*([startValue @ X6 (DG.Tweening.Color2)+8]) = v665;\n\tv667 = v329 * *([changeValue @ X7 (DG.Tweening.Color2)+C]);\n\tv668 = *([startValue @ X6 (DG.Tweening.Color2)+C]) + v667;\n\t*([startValue @ X6 (DG.Tweening.Color2)+C]) = v668;\n\tv672 = v329 * changeValue.cb;\n\tv673 = startValue.cb + v672;\n\tstartValue.cb = v673;\n\tv675 = v329 * *([changeValue @ X7 (DG.Tweening.Color2)+14]);\n\tv676 = *([startValue @ X6 (DG.Tweening.Color2)+14]) + v675;\n\t*([startValue @ X6 (DG.Tweening.Color2)+14]) = v676;\n\tv678 = v329 * *([changeValue @ X7 (DG.Tweening.Color2)+18]);\n\tv679 = *([startValue @ X6 (DG.Tweening.Color2)+18]) + v678;\n\t*([startValue @ X6 (DG.Tweening.Color2)+18]) = v679;\n\tv681 = v329 * *([changeValue @ X7 (DG.Tweening.Color2)+1C]);\n\tv682 = *([startValue @ X6 (DG.Tweening.Color2)+1C]) + v681;\n\t*([startValue @ X6 (DG.Tweening.Color2)+1C]) = v682;\n\t*([v24 @ X29_v1-70]) = startValue.ca;\n\t*([v24 @ X29_v1-60]) = startValue.cb;\nL_01B4:\n\tv564 = &v25 @ stack_-10_v2 - 0x70;\n\tDG.Tweening.Core.DOSetter`1<DG.Tweening.Color2>::Invoke(setter, v564);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 351 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override void EvaluateAndApply(ColorOptions options, Tween t, bool isRelative, DOGetter<Color2> getter, DOSetter<Color2> setter, float elapsed, Color2 startValue, Color2 changeValue, float duration, bool usingInversePosition, UpdateNotice updateNotice)
		{
			//IL_05e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_05e5: Expected I4, but got Unknown
			//IL_0350: Expected O, but got F4
			//IL_034b: Expected native int or pointer, but got O
			//IL_0428: Expected O, but got F4
			//IL_0423: Expected native int or pointer, but got O
			//IL_0112: Expected O, but got I
			//IL_0122: Expected O, but got I
			//IL_012f: Expected F4, but got I4
			//IL_0548: Expected O, but got Ref
			//IL_0561: Expected O, but got Ref
			//IL_0561: Expected O, but got Ref
			//IL_057a: Expected O, but got I
			//IL_0575: Expected native int or pointer, but got O
			//IL_058f: Expected O, but got I
			//IL_058a: Expected native int or pointer, but got O
			//IL_00e4: Expected O, but got I
			//IL_00f4: Expected O, but got I
			//IL_06a2: Expected O, but got I
			//IL_01e3: Expected O, but got I
			//IL_060f: Expected O, but got Ref
			//IL_01b4: Expected O, but got I
			//IL_01ce: Expected F4, but got I4
			//IL_026d: Expected O, but got I
			//IL_027a: Expected F4, but got I4
			//IL_063a: Expected O, but got Ref
			//IL_0653: Expected O, but got Ref
			//IL_0653: Expected O, but got Ref
			//IL_066c: Expected O, but got I
			//IL_0667: Expected native int or pointer, but got O
			//IL_0681: Expected O, but got I
			//IL_067c: Expected native int or pointer, but got O
			//IL_0247: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			if (t.loopType == LoopType.Incremental)
			{
				_ = startValue.cb;
				_ = startValue.ca;
				_ = changeValue.ca;
				_ = changeValue.cb;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-70]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-60]");
				_ = 0;
				object obj3;
				object obj4;
				float num2;
				if (t.isComplete)
				{
					_ = changeValue.ca;
					_ = changeValue.cb;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-70]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-60]");
					_ = 0;
					int num = t.completedLoops - 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-B0]");
					obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-90]");
					obj4 = 0;
					num2 = num;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-F0]");
					obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-D0]");
					obj4 = 0;
					num2 = t.completedLoops;
				}
				object obj6 = default(object);
				object obj5 = obj6;
				Color2 color = (Color2)(&obj4) * num2;
				obj6 = obj5;
				Color2 color2 = (Color2)(&obj3) + (Color2)(&obj6);
				Color2 color3 = startValue;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-60]");
				((Color2*)(IntPtr)color3)->cb = (Color)0;
				Color2 color4 = startValue;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-70]");
				((Color2*)(IntPtr)color4)->ca = (Color)0;
				Color cb = changeValue.cb;
			}
			if (t.isSequenced)
			{
				Sequence sequenceParent = t.sequenceParent;
				if (sequenceParent.loopType == LoopType.Incremental)
				{
					_ = startValue.cb;
					_ = startValue.ca;
					object obj7;
					Color ca;
					float num3;
					if (t.loopType == LoopType.Incremental)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-70]");
						obj7 = 0;
						ca = changeValue.ca;
						num3 = t.loops;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-70]");
						obj7 = 0;
						ca = changeValue.ca;
						num3 = 1f;
					}
					Color2 color5 = (Color2)(&ca) * num3;
					Sequence sequenceParent2 = t.sequenceParent;
					object obj8;
					object obj9;
					float num5;
					if (sequenceParent2.isComplete)
					{
						int num4 = sequenceParent2.completedLoops - 1;
						obj8 = obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-70]");
						obj9 = 0;
						num5 = num4;
					}
					else
					{
						obj8 = obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-70]");
						obj9 = 0;
						num5 = sequenceParent2.completedLoops;
					}
					object obj11 = default(object);
					object obj10 = obj11;
					Color2 color6 = (Color2)(&obj9) * num5;
					obj11 = obj10;
					Color2 color7 = (Color2)(&obj8) + (Color2)(&obj11);
					Color2 color8 = startValue;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-60]");
					((Color2*)(IntPtr)color8)->cb = (Color)0;
					Color2 color9 = startValue;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-70]");
					((Color2*)(IntPtr)color9)->ca = (Color)0;
					Color cb = changeValue.cb;
				}
			}
			float num6 = EaseManager.Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);
			if ((options & 0xFF) != 0)
			{
				Color2 color10 = getter();
				float num7 = num6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [changeValue @ X7 (DG.Tweening.Color2)+C]");
				float num8 = num7 * 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [startValue @ X6 (DG.Tweening.Color2)+C]");
				float num9 = 0f + num8;
				float num10 = num6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [changeValue @ X7 (DG.Tweening.Color2)+1C]");
				float num11 = num10 * 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [startValue @ X6 (DG.Tweening.Color2)+1C]");
				float num12 = 0f + num11;
			}
			else
			{
				float num13 = num6 * changeValue.ca.r;
				float num14 = startValue.ca.r + num13;
				((Color2*)(IntPtr)startValue)->ca = (Color)num14;
				float num15 = num6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [changeValue @ X7 (DG.Tweening.Color2)+4]");
				float num16 = num15 * 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [startValue @ X6 (DG.Tweening.Color2)+4]");
				float num17 = 0f + num16;
				float num18 = num6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [changeValue @ X7 (DG.Tweening.Color2)+8]");
				float num19 = num18 * 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [startValue @ X6 (DG.Tweening.Color2)+8]");
				float num20 = 0f + num19;
				float num21 = num6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [changeValue @ X7 (DG.Tweening.Color2)+C]");
				float num22 = num21 * 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [startValue @ X6 (DG.Tweening.Color2)+C]");
				float num23 = 0f + num22;
				float num24 = num6 * changeValue.cb.r;
				float num25 = startValue.cb.r + num24;
				((Color2*)(IntPtr)startValue)->cb = (Color)num25;
				float num26 = num6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [changeValue @ X7 (DG.Tweening.Color2)+14]");
				float num27 = num26 * 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [startValue @ X6 (DG.Tweening.Color2)+14]");
				float num28 = 0f + num27;
				float num29 = num6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [changeValue @ X7 (DG.Tweening.Color2)+18]");
				float num30 = num29 * 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [startValue @ X6 (DG.Tweening.Color2)+18]");
				float num31 = 0f + num30;
				float num32 = num6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [changeValue @ X7 (DG.Tweening.Color2)+1C]");
				float num33 = num32 * 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [startValue @ X6 (DG.Tweening.Color2)+1C]");
				float num34 = 0f + num33;
				_ = startValue.ca;
				_ = startValue.cb;
			}
			Color2 pNewValue = (Color2)((long)(IntPtr)obj2 - 112L);
			setter(pNewValue);
		}

		[Token(Token = "0x6000187")]
		[Address(RVA = "0x107FC54", Offset = "0x107FC54", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EF1C48]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026A3F]) = v38;\nL_001C:\n\tDG.Tweening.Plugins.Core.ABSTweenPlugin`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Color2Plugin()
		{
		}
	}
}
