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
	[Token(Token = "0x2000075")]
	internal class Color2Plugin : ABSTweenPlugin<Color2, Color2, ColorOptions>
	{
		[Token(Token = "0x60002C4")]
		[Address(RVA = "0xC1D2E0", Offset = "0xC1D2E0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Reset(TweenerCore<Color2, Color2, ColorOptions> t)
		{
		}

		[Token(Token = "0x60002C5")]
		[Address(RVA = "0xC1D2E4", Offset = "0xC1D2E4", Length = "0x1F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv147 = DG.Tweening.Core.DOGetter`1<DG.Tweening.Color2>::Invoke(t.getter);\n\tt.endValue = v146;\n\tt.endValue.cb = v150;\n\tv154 = isRelative == 0;\n\tif (v154) goto L_FFFFFFFF;\n\tv267 = t.endValue + t.endValue;\n\tv268 = t.endValue.ca.g + t.endValue.ca.g;\n\tv85 = t.endValue.ca.b + t.endValue.ca.b;\n\tv82 = t.endValue.ca.a + t.endValue.ca.a;\n\tv168 = t.endValue.cb + t.endValue.cb;\n\tv76 = t.endValue.cb.g + t.endValue.cb.g;\n\tv73 = t.endValue.cb.b + t.endValue.cb.b;\n\tv70 = t.endValue.cb.a + t.endValue.cb.a;\n\tgoto L_004D;\nL_004D:\n\t// 77 MakeStruct v46 @ AGGC213DC_1_v2 (UnityEngine.Color), typeof(UnityEngine.Color), v267 @ V0_v3 (DG.Tweening.Color2), v268 @ V1_v3 (System.Single), v85 @ V2_v2 (System.Single), v82 @ V3_v2 (System.Single)\n\t// 78 MakeStruct v43 @ AGGC213DC_2_v2 (UnityEngine.Color), typeof(UnityEngine.Color), v168 @ V4_v5 (System.Single), v76 @ V5_v2 (System.Single), v73 @ V6_v2 (System.Single), v70 @ V7_v2 (System.Single)\n\tDG.Tweening.Color2::.ctor(v125, v46, v43);\n\tt.startValue = v175;\n\tt.startValue.cb = v88;\n\tv282 = t.plugOptions == 0;\n\tif (v282) goto L_006A;\n\tgoto L_006E;\nL_006A:\n\t;\nL_006E:\n\t;\n\tDG.Tweening.Core.DOSetter`1<DG.Tweening.Color2>::Invoke(t.setter, &v146 @ stack_-B0_v2 (DG.Tweening.Color2));\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 124 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override void SetFrom(TweenerCore<Color2, Color2, ColorOptions> t, bool isRelative)
		{
			//IL_027d: Expected O, but got Ref
			//IL_02c8: Expected F4, but got O
			//IL_032f: Expected native int or pointer, but got O
			//IL_01b8: Expected O, but got Ref
			//IL_02ba: Expected O, but got Ref
			object obj = t.getter();
			Color2 endValue = default(Color2);
			t.endValue = endValue;
			Color cb = default(Color);
			t.endValue.cb = cb;
			Color2 color;
			float g;
			float b;
			float a;
			float r;
			float g2;
			float b2;
			float a2;
			Color cb2;
			Color2 color2;
			Color2 startValue = default(Color2);
			if (isRelative)
			{
				color = t.endValue + t.endValue;
				g = t.endValue.ca.g + t.endValue.ca.g;
				b = t.endValue.ca.b + t.endValue.ca.b;
				a = t.endValue.ca.a + t.endValue.ca.a;
				r = t.endValue.cb.r + t.endValue.cb.r;
				g2 = t.endValue.cb.g + t.endValue.cb.g;
				b2 = t.endValue.cb.b + t.endValue.cb.b;
				a2 = t.endValue.cb.a + t.endValue.cb.a;
				cb2 = default(Color);
				color2 = (Color2)(&startValue);
			}
			else
			{
				a2 = t.endValue.cb.a;
				b2 = t.endValue.cb.b;
				g2 = t.endValue.cb.g;
				r = t.endValue.cb.r;
				a = t.endValue.ca.a;
				b = t.endValue.ca.b;
				cb2 = default(Color);
				color = t.endValue;
				g = t.endValue.ca.g;
				color2 = (Color2)(&startValue);
			}
			Color ca = default(Color);
			ca.r = (float)color;
			ca.g = g;
			ca.b = b;
			ca.a = a;
			Color cb3 = default(Color);
			cb3.r = r;
			cb3.g = g2;
			cb3.b = b2;
			cb3.a = a2;
			*(Color2*)(nint)color2 = new Color2(ca, cb3);
			t.startValue = startValue;
			t.startValue.cb = cb2;
			endValue = (((object)t.plugOptions == null) ? t.startValue : t.endValue);
			t.setter((Color2)(&endValue));
		}

		[Token(Token = "0x60002C6")]
		[Address(RVA = "0xC1D4D4", Offset = "0xC1D4D4", Length = "0x1D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = isRelative == 0;\n\tif (v24) goto L_FFFFFFFF;\n\tv194 = DG.Tweening.Core.DOGetter`1<DG.Tweening.Color2>::Invoke(t.getter);\n\tv198 = &v250 @ stack_-B0_v5 (DG.Tweening.Color2);\n\tv203 = t.endValue;\n\tv210 = DG.Tweening.Color2::op_Addition(&v203 @ V3_v3 (DG.Tweening.Color2), &v379 @ stack_-50_v5 (UnityEngine.Color));\n\tt.endValue = *([v198 @ X8_v16]);\n\tt.endValue.cb = *([v198 @ X8_v16+10]);\n\tv258 = fromValue.ca;\n\tv241 = DG.Tweening.Color2::op_Addition(&v258 @ V1_v9 (UnityEngine.Color), &v379 @ stack_-50_v5 (UnityEngine.Color));\n\tfromValue.ca = v241.ca;\n\tfromValue.cb = v241.cb;\n\tv258 = fromValue.ca;\n\tgoto L_0064;\nL_0064:\n\tt.startValue = *([v243 @ X8_v1]);\n\tt.startValue.cb = *([v243 @ X8_v1+10]);\n\tv249 = setImmediately == 0;\n\tif (v249) goto L_00A8;\n\tv357 = t.plugOptions == 0;\n\tif (v357) goto L_0087;\n\tv381 = DG.Tweening.Core.DOGetter`1<DG.Tweening.Color2>::Invoke(t.getter);\nL_0087:\n\t;\n\tDG.Tweening.Core.DOSetter`1<DG.Tweening.Color2>::Invoke(t.setter, &v178 @ stack_-80_v4 (UnityEngine.Color));\nL_00A8:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 145 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override void SetFrom(TweenerCore<Color2, Color2, ColorOptions> t, Color2 fromValue, bool setImmediately, bool isRelative)
		{
			//IL_018e: Expected O, but got I
			//IL_0057: Expected O, but got Ref
			//IL_0057: Expected O, but got Ref
			//IL_0082: Expected O, but got I
			//IL_009c: Expected O, but got Ref
			//IL_009c: Expected O, but got Ref
			//IL_00b2: Expected native int or pointer, but got O
			//IL_00c4: Expected native int or pointer, but got O
			//IL_0162: Expected O, but got Ref
			Color color4 = default(Color);
			object startValue;
			if (isRelative)
			{
				object obj = t.getter();
				Color2 color = default(Color2);
				object endValue = color;
				Color2 color2 = t.endValue;
				Color2 color3 = (Color2)(&color2) + (Color2)(&color4);
				t.endValue = (Color2)endValue;
				ref Color2 endValue2 = ref t.endValue;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ X8_v16+10]");
				endValue2.cb = (Color)0;
				Color ca = fromValue.ca;
				Color2 color5 = (Color2)(&ca) + (Color2)(&color4);
				((Color2*)(nint)fromValue)->ca = color5.ca;
				((Color2*)(nint)fromValue)->cb = color5.cb;
				ca = fromValue.ca;
				object obj2 = default(object);
				color2 = (Color2)obj2;
				startValue = ca;
			}
			else
			{
				startValue = color4;
			}
			t.startValue = (Color2)startValue;
			ref Color2 startValue2 = ref t.startValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ X8_v1+10]");
			startValue2.cb = (Color)0;
			if (setImmediately)
			{
				bool flag = (object)t.plugOptions == null;
				Color color6 = fromValue.ca;
				if (!flag)
				{
					object obj3 = t.getter();
					color6 = color4;
				}
				t.setter((Color2)(&color6));
			}
		}

		[Token(Token = "0x60002C7")]
		[Address(RVA = "0xC1D6A8", Offset = "0xC1D6A8", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnBuffer.ca = value->klass;\n\treturnBuffer.cb = value.tweenType;\n\treturn this;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override Color2 ConvertToStartValue(TweenerCore<Color2, Color2, ColorOptions> t, Color2 value)
		{
			//IL_0008: Expected native int or pointer, but got O
			//IL_001f: Expected O, but got I4
			//IL_001a: Expected native int or pointer, but got O
			Color2 color = default(Color2);
			((Color2*)(nint)color)->ca = (Color)value;
			((Color2*)(nint)color)->cb = (Color)((TweenerCore<Color2, Color2, ColorOptions>)value).tweenType;
			return (Color2)this;
		}

		[Token(Token = "0x60002C8")]
		[Address(RVA = "0xC1D6B4", Offset = "0xC1D6B4", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = t.endValue;\n\tv7 = t.startValue;\n\tv21 = DG.Tweening.Color2::op_Addition(&v7 @ V1_v1 (DG.Tweening.Color2), &v7 @ V1_v1 (DG.Tweening.Color2));\n\tt.endValue = v21.ca;\n\tt.endValue.cb = v21.cb;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override void SetRelativeEndValue(TweenerCore<Color2, Color2, ColorOptions> t)
		{
			//IL_0027: Expected O, but got Ref
			//IL_0027: Expected O, but got Ref
			Color2 color = t.endValue;
			color = t.startValue;
			Color2 color2 = (Color2)(&color) + (Color2)(&color);
			t.endValue = (Color2)color2.ca;
			t.endValue.cb = color2.cb;
		}

		[Token(Token = "0x60002C9")]
		[Address(RVA = "0xC1D708", Offset = "0xC1D708", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = t.endValue;\n\tv7 = t.startValue;\n\tv22 = DG.Tweening.Color2::op_Subtraction(&v7 @ V1_v1 (DG.Tweening.Color2), &v7 @ V1_v1 (DG.Tweening.Color2));\n\tt.changeValue = v22.ca;\n\tt.changeValue.cb = v22.cb;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override void SetChangeValue(TweenerCore<Color2, Color2, ColorOptions> t)
		{
			//IL_0027: Expected O, but got Ref
			//IL_0027: Expected O, but got Ref
			Color2 color = t.endValue;
			color = t.startValue;
			Color2 color2 = (Color2)(&color) - (Color2)(&color);
			t.changeValue = (Color2)color2.ca;
			t.changeValue.cb = color2.cb;
		}

		[Token(Token = "0x60002CA")]
		[Address(RVA = "0xC1D764", Offset = "0xC1D764", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = 1f / unitsXSecond;\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override float GetSpeedBasedDuration(ColorOptions options, float unitsXSecond, Color2 changeValue)
		{
			return 1f / unitsXSecond;
		}

		[Token(Token = "0x60002CB")]
		[Address(RVA = "0xC1D770", Offset = "0xC1D770", Length = "0x418")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv80 = t.loopType != 2;\n\tif (v80) goto L_0099;\n\tv426 = startValue.ca;\n\tv426 = changeValue.ca;\n\tv435 = ~t.isComplete;\n\tif (v435) goto L_FFFFFFFF;\n\tv495 = t.completedLoops - 1;\n\tgoto L_0066;\nL_0066:\n\tv426 = *([v457 @ X10_v6]);\n\tv251 = *([v458 @ X9_v12]);\n\tv721 = &v426 @ V1_v27 (UnityEngine.Color);\n\tv722 = DG.Tweening.Color2::op_Multiply(&v426 @ V1_v27 (UnityEngine.Color), v712);\n\tv727 = *([v721 @ X8_v26]);\n\tv450 = DG.Tweening.Color2::op_Addition(&v251 @ V3_v4 (System.Single), &v727 @ stack_-70_v13);\n\tv462 = v450.ca;\n\tstartValue.ca = v450.ca;\n\tstartValue.cb = v450.cb;\nL_0099:\n\tv483 = ~t.isSequenced;\n\tif (v483) goto L_0137;\n\tv333 = t.sequenceParent;\n\tv542 = v333.loopType != 2;\n\tif (v542) goto L_0137;\n\tv426 = startValue.ca;\n\tv426 = changeValue.ca;\n\tv289 = t.loopType != 2;\n\tif (v289) goto L_FFFFFFFF;\n\tgoto L_00DC;\nL_00DC:\n\tv817 = &v520 @ stack_-310_v7 (UnityEngine.Color);\n\tv211 = DG.Tweening.Color2::op_Multiply(&v462 @ stack_-1F0_v9 (UnityEngine.Color), v815);\n\tv520 = *([v817 @ X8_v16]);\n\tv334 = t.sequenceParent;\n\tv554 = ~v334.isComplete;\n\tif (v554) goto L_FFFFFFFF;\n\tv845 = v334.completedLoops - 1;\n\tgoto L_0102;\nL_0102:\n\tv426 = *([v533 @ X9_v9]);\n\tv862 = &v520 @ stack_-310_v7 (UnityEngine.Color);\n\tv863 = DG.Tweening.Color2::op_Multiply(&v426 @ V1_v27 (UnityEngine.Color), v853);\n\tv727 = *([v862 @ X8_v19]);\n\tv526 = DG.Tweening.Color2::op_Addition(&v164 @ stack_-210_v3 (UnityEngine.Color), &v727 @ stack_-70_v13);\n\tstartValue.ca = v526.ca;\n\tstartValue.cb = v526.cb;\nL_0137:\n\tv251 = t.easePeriod;\n\tv419 = DG.Tweening.Core.Easing.EaseManager::Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);\n\tv724 = options & 1;\n\tv725 = v724 == 0;\n\tv726 = ~v725;\n\tif (v726) goto L_017F;\n\tv426 = startValue.ca;\n\tv745 = v419 * changeValue.ca;\n\tv746 = startValue.ca + v745;\n\tstartValue.ca = v746;\n\tv748 = v419 * *([changeValue @ X7 (DG.Tweening.Color2)+4]);\n\tv749 = *([startValue @ X6 (DG.Tweening.Color2)+4]) + v748;\n\t*([startValue @ X6 (DG.Tweening.Color2)+4]) = v749;\n\tv426 = *([startValue @ X6 (DG.Tweening.Color2)+8]);\n\tv753 = v419 * *([changeValue @ X7 (DG.Tweening.Color2)+8]);\n\tv754 = *([startValue @ X6 (DG.Tweening.Color2)+8]) + v753;\n\t*([startValue @ X6 (DG.Tweening.Color2)+8]) = v754;\n\tv756 = v419 * *([changeValue @ X7 (DG.Tweening.Color2)+C]);\n\tv757 = *([startValue @ X6 (DG.Tweening.Color2)+C]) + v756;\n\t*([startValue @ X6 (DG.Tweening.Color2)+C]) = v757;\n\tv426 = startValue.cb;\n\tv761 = v419 * changeValue.cb;\n\tv762 = startValue.cb + v761;\n\tstartValue.cb = v762;\n\tv764 = v419 * *([changeValue @ X7 (DG.Tweening.Color2)+14]);\n\tv765 = *([startValue @ X6 (DG.Tweening.Color2)+14]) + v764;\n\t*([startValue @ X6 (DG.Tweening.Color2)+14]) = v765;\n\tv426 = *([startValue @ X6 (DG.Tweening.Color2)+18]);\n\tv768 = v419 * *([changeValue @ X7 (DG.Tweening.Color2)+18]);\n\tv769 = *([startValue @ X6 (DG.Tweening.Color2)+18]) + v768;\n\t*([startValue @ X6 (DG.Tweening.Color2)+18]) = v769;\n\tv771 = v419 * *([changeValue @ X7 (DG.Tweening.Color2)+1C]);\n\tv772 = *([startValue @ X6 (DG.Tweening.Color2)+1C]) + v771;\n\t*([startValue @ X6 (DG.Tweening.Color2)+1C]) = v772;\n\tv426 = startValue.ca;\n\tDG.Tweening.Core.DOSetter`1<DG.Tweening.Color2>::Invoke(setter, &v426 @ V1_v27 (UnityEngine.Color));\n\tgoto L_01B2;\nL_017F:\n\tv213 = DG.Tweening.Core.DOGetter`1<DG.Tweening.Color2>::Invoke(getter);\n\tv251 = *([changeValue @ X7 (DG.Tweening.Color2)+1C]);\n\tv251 = v419 * v251;\n\tDG.Tweening.Core.DOSetter`1<DG.Tweening.Color2>::Invoke(setter, &v727 @ stack_-70_v13);\nL_01B2:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 351 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override void EvaluateAndApply(ColorOptions options, Tween t, bool isRelative, DOGetter<Color2> getter, DOSetter<Color2> setter, float elapsed, Color2 startValue, Color2 changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice)
		{
			//IL_0510: Unknown result type (might be due to invalid IL or missing references)
			//IL_0515: Expected I4, but got Unknown
			//IL_0406: Expected F4, but got I
			//IL_00ab: Expected F4, but got I4
			//IL_042a: Expected O, but got Ref
			//IL_0227: Expected O, but got F4
			//IL_0222: Expected native int or pointer, but got O
			//IL_026a: Expected O, but got I
			//IL_031c: Expected O, but got F4
			//IL_0317: Expected native int or pointer, but got O
			//IL_035f: Expected O, but got I
			//IL_045d: Expected F4, but got O
			//IL_0472: Expected O, but got Ref
			//IL_048b: Expected O, but got Ref
			//IL_048b: Expected O, but got Ref
			//IL_04a9: Expected native int or pointer, but got O
			//IL_04bb: Expected native int or pointer, but got O
			//IL_03e4: Expected O, but got Ref
			//IL_0552: Expected O, but got Ref
			//IL_014d: Expected F4, but got I4
			//IL_01d6: Expected F4, but got I4
			//IL_058d: Expected O, but got Ref
			//IL_05a6: Expected O, but got Ref
			//IL_05a6: Expected O, but got Ref
			//IL_05b7: Expected native int or pointer, but got O
			//IL_05c9: Expected native int or pointer, but got O
			Color color;
			float num3;
			object obj4 = default(object);
			Color ca;
			if (t.loopType == LoopType.Incremental)
			{
				color = startValue.ca;
				color = changeValue.ca;
				object obj;
				object obj2;
				float num2;
				if (t.isComplete)
				{
					int num = t.completedLoops - 1;
					obj = color;
					obj2 = color;
					num2 = num;
				}
				else
				{
					obj = color;
					obj2 = color;
					num2 = t.completedLoops;
				}
				color = (Color)obj;
				num3 = (float)obj2;
				object obj3 = color;
				Color2 color2 = (Color2)(&color) * num2;
				obj4 = obj3;
				Color2 color3 = (Color2)(&num3) + (Color2)(&obj4);
				ca = color3.ca;
				((Color2*)(nint)startValue)->ca = color3.ca;
				((Color2*)(nint)startValue)->cb = color3.cb;
			}
			if (t.isSequenced)
			{
				Sequence sequenceParent = t.sequenceParent;
				if (sequenceParent.loopType == LoopType.Incremental)
				{
					color = startValue.ca;
					color = changeValue.ca;
					Color ca2;
					float num4;
					if (t.loopType == LoopType.Incremental)
					{
						ca2 = changeValue.ca;
						ca = changeValue.ca;
						num4 = t.loops;
					}
					else
					{
						ca2 = changeValue.ca;
						ca = changeValue.ca;
						num4 = 1f;
					}
					Color color4 = default(Color);
					object obj5 = color4;
					Color2 color5 = (Color2)(&ca) * num4;
					color4 = (Color)obj5;
					Sequence sequenceParent2 = t.sequenceParent;
					object obj6;
					float num6;
					if (sequenceParent2.isComplete)
					{
						int num5 = sequenceParent2.completedLoops - 1;
						obj6 = color4;
						num6 = num5;
					}
					else
					{
						obj6 = color4;
						num6 = sequenceParent2.completedLoops;
					}
					color = (Color)obj6;
					object obj7 = color4;
					Color2 color6 = (Color2)(&color) * num6;
					obj4 = obj7;
					Color2 color7 = (Color2)(&ca2) + (Color2)(&obj4);
					((Color2*)(nint)startValue)->ca = color7.ca;
					((Color2*)(nint)startValue)->cb = color7.cb;
				}
			}
			num3 = t.easePeriod;
			float num7 = EaseManager.Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);
			if ((options & 1) == 0)
			{
				color = startValue.ca;
				float num8 = num7 * changeValue.ca.r;
				float num9 = startValue.ca.r + num8;
				((Color2*)(nint)startValue)->ca = (Color)num9;
				float num10 = num7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [changeValue @ X7 (DG.Tweening.Color2)+4]");
				float num11 = num10 * 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [startValue @ X6 (DG.Tweening.Color2)+4]");
				float num12 = 0f + num11;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [startValue @ X6 (DG.Tweening.Color2)+8]");
				color = (Color)0;
				float num13 = num7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [changeValue @ X7 (DG.Tweening.Color2)+8]");
				float num14 = num13 * 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [startValue @ X6 (DG.Tweening.Color2)+8]");
				float num15 = 0f + num14;
				float num16 = num7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [changeValue @ X7 (DG.Tweening.Color2)+C]");
				float num17 = num16 * 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [startValue @ X6 (DG.Tweening.Color2)+C]");
				float num18 = 0f + num17;
				color = startValue.cb;
				float num19 = num7 * changeValue.cb.r;
				float num20 = startValue.cb.r + num19;
				((Color2*)(nint)startValue)->cb = (Color)num20;
				float num21 = num7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [changeValue @ X7 (DG.Tweening.Color2)+14]");
				float num22 = num21 * 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [startValue @ X6 (DG.Tweening.Color2)+14]");
				float num23 = 0f + num22;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [startValue @ X6 (DG.Tweening.Color2)+18]");
				color = (Color)0;
				float num24 = num7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [changeValue @ X7 (DG.Tweening.Color2)+18]");
				float num25 = num24 * 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [startValue @ X6 (DG.Tweening.Color2)+18]");
				float num26 = 0f + num25;
				float num27 = num7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [changeValue @ X7 (DG.Tweening.Color2)+1C]");
				float num28 = num27 * 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [startValue @ X6 (DG.Tweening.Color2)+1C]");
				float num29 = 0f + num28;
				color = startValue.ca;
				setter((Color2)(&color));
			}
			else
			{
				object obj8 = getter();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [changeValue @ X7 (DG.Tweening.Color2)+1C]");
				num3 = 0f;
				num3 = num7 * num3;
				setter((Color2)(&obj4));
			}
		}

		[Token(Token = "0x60002CC")]
		[Address(RVA = "0xC1DB88", Offset = "0xC1DB88", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A3575E]) = v37;\nL_001A:\n\tDG.Tweening.Plugins.Core.ABSTweenPlugin`3<DG.Tweening.Color2, DG.Tweening.Color2, DG.Tweening.Plugins.Options.ColorOptions>::.ctor(this);\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Color2Plugin()
		{
		}
	}
}
