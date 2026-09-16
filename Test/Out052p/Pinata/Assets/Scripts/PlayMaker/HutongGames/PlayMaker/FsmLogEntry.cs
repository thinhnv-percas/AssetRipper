using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Token(Token = "0x200006F")]
	public class FsmLogEntry
	{
		[Token(Token = "0x40002C0")]
		[FieldOffset(Offset = "0x88")]
		private string text;

		[Token(Token = "0x40002C2")]
		[FieldOffset(Offset = "0x98")]
		private string textWithTimecode;

		[Token(Token = "0x1700017B")]
		public FsmLog Log
		{
			[CompilerGenerated]
			[Token(Token = "0x60004FE")]
			[Address(RVA = "0xCAEDEC", Offset = "0xCAEDEC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Log>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Log;
			}
			[CompilerGenerated]
			[Token(Token = "0x60004FF")]
			[Address(RVA = "0xCAEDF4", Offset = "0xCAEDF4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Log>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Log = value;
			}
		}

		[Token(Token = "0x1700017C")]
		public FsmLogType LogType
		{
			[CompilerGenerated]
			[Token(Token = "0x6000500")]
			[Address(RVA = "0xCAEDFC", Offset = "0xCAEDFC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<LogType>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return LogType;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000501")]
			[Address(RVA = "0xCAEE04", Offset = "0xCAEE04", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<LogType>k__BackingField = value;\n\treturn;\n")]
			set
			{
				LogType = value;
			}
		}

		[Token(Token = "0x1700017D")]
		public Fsm Fsm
		{
			[Token(Token = "0x6000502")]
			[Address(RVA = "0xCADE24", Offset = "0xCADE24", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.<Log>k__BackingField;\n\treturn v0.<Fsm>k__BackingField;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				FsmLog log = Log;
				return log.Fsm;
			}
		}

		[Token(Token = "0x1700017E")]
		public FsmState State
		{
			[CompilerGenerated]
			[Token(Token = "0x6000503")]
			[Address(RVA = "0xCAEE0C", Offset = "0xCAEE0C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<State>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return State;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000504")]
			[Address(RVA = "0xCAEE14", Offset = "0xCAEE14", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<State>k__BackingField = value;\n\treturn;\n")]
			set
			{
				State = value;
			}
		}

		[Token(Token = "0x1700017F")]
		public FsmState SentByState
		{
			[CompilerGenerated]
			[Token(Token = "0x6000505")]
			[Address(RVA = "0xCAEE1C", Offset = "0xCAEE1C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<SentByState>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return SentByState;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000506")]
			[Address(RVA = "0xCAEE24", Offset = "0xCAEE24", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<SentByState>k__BackingField = value;\n\treturn;\n")]
			set
			{
				SentByState = value;
			}
		}

		[Token(Token = "0x17000180")]
		public FsmStateAction Action
		{
			[CompilerGenerated]
			[Token(Token = "0x6000507")]
			[Address(RVA = "0xCAEE2C", Offset = "0xCAEE2C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Action>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Action;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000508")]
			[Address(RVA = "0xCAEE34", Offset = "0xCAEE34", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Action>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Action = value;
			}
		}

		[Token(Token = "0x17000181")]
		public FsmEvent Event
		{
			[CompilerGenerated]
			[Token(Token = "0x6000509")]
			[Address(RVA = "0xCAEE3C", Offset = "0xCAEE3C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Event>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Event;
			}
			[CompilerGenerated]
			[Token(Token = "0x600050A")]
			[Address(RVA = "0xCAEE44", Offset = "0xCAEE44", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Event>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Event = value;
			}
		}

		[Token(Token = "0x17000182")]
		public FsmTransition Transition
		{
			[CompilerGenerated]
			[Token(Token = "0x600050B")]
			[Address(RVA = "0xCAEE4C", Offset = "0xCAEE4C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Transition>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Transition;
			}
			[CompilerGenerated]
			[Token(Token = "0x600050C")]
			[Address(RVA = "0xCAEE54", Offset = "0xCAEE54", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Transition>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Transition = value;
			}
		}

		[Token(Token = "0x17000183")]
		public FsmEventTarget EventTarget
		{
			[CompilerGenerated]
			[Token(Token = "0x600050D")]
			[Address(RVA = "0xCAEE5C", Offset = "0xCAEE5C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<EventTarget>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return EventTarget;
			}
			[CompilerGenerated]
			[Token(Token = "0x600050E")]
			[Address(RVA = "0xCAEE64", Offset = "0xCAEE64", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<EventTarget>k__BackingField = value;\n\treturn;\n")]
			set
			{
				EventTarget = value;
			}
		}

		[Token(Token = "0x17000184")]
		public float Time
		{
			[CompilerGenerated]
			[Token(Token = "0x600050F")]
			[Address(RVA = "0xCAEE6C", Offset = "0xCAEE6C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Time>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Time;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000510")]
			[Address(RVA = "0xCAEE74", Offset = "0xCAEE74", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Time>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Time = value;
			}
		}

		[Token(Token = "0x17000185")]
		public float StateTime
		{
			[CompilerGenerated]
			[Token(Token = "0x6000511")]
			[Address(RVA = "0xCAEE7C", Offset = "0xCAEE7C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<StateTime>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return StateTime;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000512")]
			[Address(RVA = "0xCAEE84", Offset = "0xCAEE84", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<StateTime>k__BackingField = value;\n\treturn;\n")]
			set
			{
				StateTime = value;
			}
		}

		[Token(Token = "0x17000186")]
		public int FrameCount
		{
			[CompilerGenerated]
			[Token(Token = "0x6000513")]
			[Address(RVA = "0xCAEE8C", Offset = "0xCAEE8C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<FrameCount>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return FrameCount;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000514")]
			[Address(RVA = "0xCAEE94", Offset = "0xCAEE94", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<FrameCount>k__BackingField = value;\n\treturn;\n")]
			set
			{
				FrameCount = value;
			}
		}

		[Token(Token = "0x17000187")]
		public FsmVariables FsmVariablesCopy
		{
			[CompilerGenerated]
			[Token(Token = "0x6000515")]
			[Address(RVA = "0xCAEE9C", Offset = "0xCAEE9C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<FsmVariablesCopy>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return FsmVariablesCopy;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000516")]
			[Address(RVA = "0xCAEEA4", Offset = "0xCAEEA4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<FsmVariablesCopy>k__BackingField = value;\n\treturn;\n")]
			set
			{
				FsmVariablesCopy = value;
			}
		}

		[Token(Token = "0x17000188")]
		public FsmVariables GlobalVariablesCopy
		{
			[CompilerGenerated]
			[Token(Token = "0x6000517")]
			[Address(RVA = "0xCAEEAC", Offset = "0xCAEEAC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<GlobalVariablesCopy>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return GlobalVariablesCopy;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000518")]
			[Address(RVA = "0xCAEEB4", Offset = "0xCAEEB4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<GlobalVariablesCopy>k__BackingField = value;\n\treturn;\n")]
			set
			{
				GlobalVariablesCopy = value;
			}
		}

		[Token(Token = "0x17000189")]
		public GameObject GameObject
		{
			[CompilerGenerated]
			[Token(Token = "0x6000519")]
			[Address(RVA = "0xCAEEBC", Offset = "0xCAEEBC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<GameObject>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return GameObject;
			}
			[CompilerGenerated]
			[Token(Token = "0x600051A")]
			[Address(RVA = "0xCAEEC4", Offset = "0xCAEEC4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<GameObject>k__BackingField = value;\n\treturn;\n")]
			set
			{
				GameObject = value;
			}
		}

		[Token(Token = "0x1700018A")]
		public string GameObjectName
		{
			[CompilerGenerated]
			[Token(Token = "0x600051B")]
			[Address(RVA = "0xCAEECC", Offset = "0xCAEECC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<GameObjectName>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return GameObjectName;
			}
			[CompilerGenerated]
			[Token(Token = "0x600051C")]
			[Address(RVA = "0xCAEED4", Offset = "0xCAEED4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<GameObjectName>k__BackingField = value;\n\treturn;\n")]
			set
			{
				GameObjectName = value;
			}
		}

		[Token(Token = "0x1700018B")]
		public Texture GameObjectIcon
		{
			[CompilerGenerated]
			[Token(Token = "0x600051D")]
			[Address(RVA = "0xCAEEDC", Offset = "0xCAEEDC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<GameObjectIcon>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return GameObjectIcon;
			}
			[CompilerGenerated]
			[Token(Token = "0x600051E")]
			[Address(RVA = "0xCAEEE4", Offset = "0xCAEEE4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<GameObjectIcon>k__BackingField = value;\n\treturn;\n")]
			set
			{
				GameObjectIcon = value;
			}
		}

		[Token(Token = "0x1700018C")]
		public string Text
		{
			[Token(Token = "0x600051F")]
			[Address(RVA = "0xCADE44", Offset = "0xCADE44", Length = "0x184")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EAF408]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023607]) = v38;\nL_0014:\n\tv40 = this.text == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_0069;\n\tv42 = this.<LogType>k__BackingField;\n\tv43 = this.<LogType>k__BackingField < 0xA;\n\tv44 = ~v43;\n\tv45 = this.<LogType>k__BackingField - 0xA;\n\tv47 = v45 == 0;\n\tv52 = ~v47;\n\tv53 = v44 & v52;\n\tif (v53) goto L_006D;\n\tv59 = 0x181A000 + 0x890;\n\tv62 = *([v59 @ X9_v2 (System.Int32)+v42 @ X8_v3 (HutongGames.PlayMaker.FsmLogType)*4]) + v59;\n\t// 41 IndirectJump v62 @ X8_v9, 0, 0, methodInfo @ X1 (Il2CppMethodInfo), v22 @ X2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tX8 = *([X19+38]);\n\tif (TEMP) goto L_0077;\n\tX1 = *([X8+10]);\n\tX8 = *([1EA5820]);\n\tgoto L_0059;\n\tX8 = *([X19+20]);\n\tif (TEMP) goto L_0077;\n\tX20 = *([X8+40]);\n\tX8 = *([X19+54]);\n\tX9 = *([1EE1A60]);\n\tX1 = &stack[C];\n\tstack[C] = X8;\n\tX0 = *([X9]);\n\tX0 = 0x8D82A8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EEC0C0]);\n\tX2 = X0;\n\tX1 = X20;\n\tX3 = 0;\n\tX8 = *([X8]);\n\tX0 = X8;\n\tX0 = System.String::Format(X0, X1, X2, X3);\n\tgoto L_0063;\n\tX8 = *([X19+20]);\n\tif (TEMP) goto L_0077;\n\tX1 = *([X8+40]);\n\tX8 = *([1EED7B0]);\n\tgoto L_0059;\n\tX8 = *([X19+20]);\n\tif (TEMP) goto L_0077;\n\tX1 = *([X8+40]);\n\tX8 = *([1EDBB28]);\n\tgoto L_0059;\n\tX8 = *([X19+38]);\n\tif (TEMP) goto L_0077;\n\tX1 = *([X8+10]);\n\tX8 = *([1EBCA48]);\nL_0059:\n\tX0 = *([X8]);\n\tX2 = 0;\n\tX0 = System.String::Concat(X0, X1, X2);\n\tgoto L_0063;\n\tX8 = *([1EAF038]);\n\tgoto L_0062;\n\tX8 = *([1EB6930]);\nL_0062:\n\tX0 = *([X8]);\nL_0063:\n\t*([X19+88]) = X0;\nL_0069:\n\treturn this.text;\nL_006D:\n\tv66 = new System.ArgumentOutOfRangeException();\n\tSystem.ArgumentOutOfRangeException::.ctor(v66);\n\tthrow v66;\nL_0077:\n\t;\n\treturn returnVal2;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0094: Expected O, but got I
				if (text == null)
				{
					FsmLogType logType = LogType;
					bool flag = LogType < FsmLogType.Stop;
					bool flag2 = !flag;
					int num = (int)(LogType - 10);
					bool flag3 = num == 0;
					bool flag4 = !flag3;
					if (!(flag2 && flag4))
					{
						int num2 = 25272320 + 2192;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X9_v2 (System.Int32)+v42 @ X8_v3 (HutongGames.PlayMaker.FsmLogType)*4]");
						object obj = 0L + (long)num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v62 @ X8_v9 (should have been resolved before IL gen)");
					}
					ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
					throw ex;
				}
				return text;
			}
			[Token(Token = "0x6000520")]
			[Address(RVA = "0xCAEEEC", Offset = "0xCAEEEC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.text = value;\n\treturn;\n")]
			set
			{
				Text = value;
			}
		}

		[Token(Token = "0x1700018D")]
		public string Text2
		{
			[CompilerGenerated]
			[Token(Token = "0x6000521")]
			[Address(RVA = "0xCAEEF4", Offset = "0xCAEEF4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Text2>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Text2;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000522")]
			[Address(RVA = "0xCAEEFC", Offset = "0xCAEEFC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Text2>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Text2 = value;
			}
		}

		[Token(Token = "0x1700018E")]
		public string TextWithTimecode
		{
			[Token(Token = "0x6000523")]
			[Address(RVA = "0xCAEF04", Offset = "0xCAEF04", Length = "0x7C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EC63A8]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023608]) = v38;\nL_0013:\n\treturnVal1 = this.textWithTimecode;\n\tv40 = this.textWithTimecode == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_0029;\n\tv43 = HutongGames.PlayMaker.FsmTime::FormatTime(this.<Time>k__BackingField);\n\tv62 = HutongGames.PlayMaker.FsmLogEntry::get_Text(this);\n\treturnVal1 = System.String::Concat(v43, \" \", v62);\n\tthis.textWithTimecode = returnVal1;\nL_0029:\n\treturn returnVal1;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				string result = textWithTimecode;
				if (textWithTimecode == null)
				{
					string text = FsmTime.FormatTime(Time);
					string text2 = Text;
					result = (textWithTimecode = text + " " + text2);
				}
				return result;
			}
		}

		[Token(Token = "0x6000524")]
		[Address(RVA = "0xCAF008", Offset = "0xCAF008", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EDE5B0]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023609]) = v40;\nL_0014:\n\tv94 = this.<Log>k__BackingField;\nL_0018:\n\tv45 = v94.entries;\n\tv105 = v144 >= v45._size;\n\tif (v105) goto L_FFFFFFFF;\n\tv151 = v45._size < v144;\n\tv152 = ~v151;\n\tv153 = v45._size - v144;\n\tv155 = v153 == 0;\n\tv160 = ~v155;\n\tv51 = v152 & v160;\n\tif (v51) goto L_0035;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0035:\n\tv162 = v45._items;\n\tv71 = v162[v144 @ X20_v2 (System.Int32)] == this;\n\tif (v71) goto L_0052;\n\tv94 = this.<Log>k__BackingField;\n\tv144 = v144 + 1;\n\tv165 = this.<Log>k__BackingField == 0;\n\tv90 = ~v165;\n\tif (v90) goto L_0018;\n\tthrow System.NullReferenceException;\nL_0052:\n\treturn v144;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int GetIndex()
		{
			FsmLog log = Log;
			int num = 0;
			while (true)
			{
				List<FsmLogEntry> entries = log.Entries;
				if (num < entries.Count)
				{
					bool flag = entries.Count < num;
					bool flag2 = !flag;
					int num2 = entries.Count - num;
					bool flag3 = num2 == 0;
					bool flag4 = !flag3;
					if (!(flag2 && flag4))
					{
						throw new ArgumentOutOfRangeException();
					}
					FsmLogEntry[] items = entries._items;
					if (items[num] == this)
					{
						break;
					}
					log = Log;
					num++;
					if (Log == null)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				num = -1;
				break;
			}
			return num;
		}

		[Token(Token = "0x6000525")]
		[Address(RVA = "0xCAE2EC", Offset = "0xCAE2EC", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Log>k__BackingField = 0;\n\tthis.<Time>k__BackingField = 0f;\n\tthis.<FrameCount>k__BackingField = 0;\n\tthis.<Action>k__BackingField = 0;\n\tthis.<Transition>k__BackingField = 0;\n\tthis.<State>k__BackingField = 0;\n\tthis.<GameObjectIcon>k__BackingField = 0;\n\tthis.<Text2>k__BackingField = 0;\n\tthis.<FsmVariablesCopy>k__BackingField = 0;\n\tthis.<GameObject>k__BackingField = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Reset()
		{
			Log = null;
			Time = 0f;
			FrameCount = 0;
			Action = null;
			Transition = null;
			State = null;
			GameObjectIcon = null;
			Text2 = null;
			FsmVariablesCopy = null;
			GameObject = null;
		}

		[Token(Token = "0x6000526")]
		[Address(RVA = "0xCAF0B0", Offset = "0xCAF0B0", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1ECAB58]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202360A]) = v38;\nL_0014:\n\tv40 = HutongGames.PlayMaker.FsmUtility::GetPath(this.<SentByState>k__BackingField);\n\tv50 = this.<Action>k__BackingField + 0x10;\n\tv60 = this.<Action>k__BackingField != 0;\n\tif (v60) goto L_FFFFFFFF;\n\tgoto L_0032;\nL_0032:\n\tv68 = System.String::Concat(\"Sent By: \", v40, \" : \", *([v63 @ X9_v2 (System.String)]));\n\tgoto L_0048;\n\tv76 = *([v72 @ X8_v8+E0]);\n\tv77 = v76 == 0;\n\tv78 = ~v77;\n\tgoto L_0048;\n\tv89 = v72;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v89, v65, v48, v64, v67, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0048:\n\tUnityEngine.Debug::Log(v68);\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void DebugLog()
		{
			//IL_004a: Expected O, but got I
			string path = FsmUtility.GetPath(SentByState);
			string text = (string)((long)(IntPtr)Action + 16L);
			string text2 = ((Action != null) ? text : "None (Action)");
			string message = "Sent By: " + path + " : " + text2;
			Debug.Log(message);
		}

		[Token(Token = "0x6000527")]
		[Address(RVA = "0xCAD3A0", Offset = "0xCAD3A0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmLogEntry()
		{
		}
	}
}
