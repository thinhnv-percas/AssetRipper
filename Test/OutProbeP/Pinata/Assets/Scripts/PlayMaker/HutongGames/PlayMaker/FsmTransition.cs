using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Serializable]
	[Token(Token = "0x2000073")]
	public class FsmTransition : IEquatable<FsmTransition>
	{
		[Token(Token = "0x2000098")]
		public enum CustomLinkStyle : byte
		{
			[Token(Token = "0x4000386")]
			Default = 0,
			[Token(Token = "0x4000387")]
			Bezier = 1,
			[Token(Token = "0x4000388")]
			Circuit = 2,
			[Token(Token = "0x4000389")]
			Direct = 3
		}

		[Token(Token = "0x2000099")]
		public enum CustomLinkConstraint : byte
		{
			[Token(Token = "0x400038B")]
			None = 0,
			[Token(Token = "0x400038C")]
			LockLeft = 1,
			[Token(Token = "0x400038D")]
			LockRight = 2
		}

		[SerializeField]
		[Token(Token = "0x40002F2")]
		[FieldOffset(Offset = "0x10")]
		private FsmEvent fsmEvent;

		[SerializeField]
		[Token(Token = "0x40002F3")]
		[FieldOffset(Offset = "0x18")]
		private string toState;

		[SerializeField]
		[Token(Token = "0x40002F4")]
		[FieldOffset(Offset = "0x20")]
		private CustomLinkStyle linkStyle;

		[SerializeField]
		[Token(Token = "0x40002F5")]
		[FieldOffset(Offset = "0x21")]
		private CustomLinkConstraint linkConstraint;

		[SerializeField]
		[Token(Token = "0x40002F6")]
		[FieldOffset(Offset = "0x22")]
		private byte colorIndex;

		[NonSerialized]
		[Token(Token = "0x40002F7")]
		[FieldOffset(Offset = "0x28")]
		private FsmState toFsmState;

		[Token(Token = "0x170001B0")]
		public FsmEvent FsmEvent
		{
			[Token(Token = "0x60005BC")]
			[Address(RVA = "0xCB6CA4", Offset = "0xCB6CA4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.fsmEvent;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return FsmEvent;
			}
			[Token(Token = "0x60005BD")]
			[Address(RVA = "0xCB6CAC", Offset = "0xCB6CAC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.fsmEvent = value;\n\treturn;\n")]
			set
			{
				FsmEvent = value;
			}
		}

		[Token(Token = "0x170001B1")]
		public string ToState
		{
			[Token(Token = "0x60005BE")]
			[Address(RVA = "0xCB6CB4", Offset = "0xCB6CB4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.toState;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ToState;
			}
			[Token(Token = "0x60005BF")]
			[Address(RVA = "0xCB6CBC", Offset = "0xCB6CBC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.toState = value;\n\treturn;\n")]
			set
			{
				ToState = value;
			}
		}

		[Token(Token = "0x170001B2")]
		public FsmState ToFsmState
		{
			[Token(Token = "0x60005C0")]
			[Address(RVA = "0xCB6CC4", Offset = "0xCB6CC4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.toFsmState;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ToFsmState;
			}
			[Token(Token = "0x60005C1")]
			[Address(RVA = "0xCB6CCC", Offset = "0xCB6CCC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.toFsmState = value;\n\treturn;\n")]
			set
			{
				ToFsmState = value;
			}
		}

		[Token(Token = "0x170001B3")]
		public CustomLinkStyle LinkStyle
		{
			[Token(Token = "0x60005C2")]
			[Address(RVA = "0xCB6CD4", Offset = "0xCB6CD4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.linkStyle;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return LinkStyle;
			}
			[Token(Token = "0x60005C3")]
			[Address(RVA = "0xCB6CDC", Offset = "0xCB6CDC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.linkStyle = value;\n\treturn;\n")]
			set
			{
				LinkStyle = value;
			}
		}

		[Token(Token = "0x170001B4")]
		public CustomLinkConstraint LinkConstraint
		{
			[Token(Token = "0x60005C4")]
			[Address(RVA = "0xCB6CE4", Offset = "0xCB6CE4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.linkConstraint;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return LinkConstraint;
			}
			[Token(Token = "0x60005C5")]
			[Address(RVA = "0xCB6CEC", Offset = "0xCB6CEC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.linkConstraint = value;\n\treturn;\n")]
			set
			{
				LinkConstraint = value;
			}
		}

		[Token(Token = "0x170001B5")]
		public int ColorIndex
		{
			[Token(Token = "0x60005C6")]
			[Address(RVA = "0xCB6CF4", Offset = "0xCB6CF4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.colorIndex;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return colorIndex;
			}
			[Token(Token = "0x60005C7")]
			[Address(RVA = "0xCB6CFC", Offset = "0xCB6CFC", Length = "0xBC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EC8C28]);\n\tv23 = *([v22 @ X8_v16]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202366D]) = v41;\nL_001B:\n\tgoto L_0022;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0022;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0022:\n\tv56 = PlayMakerPrefs::get_Colors();\n\tgoto L_0036;\n\tv66 = *([v61 @ X0_v7+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tif (v68) goto L_0036;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v61, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0036:\n\tv77 = v56.Length - 1;\n\tv78 = UnityEngine.Mathf::Clamp(value, 0, v77);\n\tthis.colorIndex = v78;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				Color[] colors = PlayMakerPrefs.Colors;
				int max = colors.Length - 1;
				int num = Mathf.Clamp(value, 0, max);
				colorIndex = (byte)num;
			}
		}

		[Token(Token = "0x170001B6")]
		public string EventName
		{
			[Token(Token = "0x60005C8")]
			[Address(RVA = "0xCB6DB8", Offset = "0xCB6DB8", Length = "0xAC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EDF390]);\n\tv19 = *([v18 @ X8_v19]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202366E]) = v38;\nL_0015:\n\tv41 = this.fsmEvent;\n\tv42 = HutongGames.PlayMaker.FsmEvent;\n\tv44 = *([v42 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+12F]) & 2;\n\tv45 = v44 == 0;\n\tif (v45) goto L_001E;\n\tv47 = *([v42 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]) == 0;\n\tif (v47) goto L_0037;\nL_001E:\n\tv50 = this.fsmEvent == 0;\n\tif (v50) goto L_002A;\nL_0022:\n\tv58 = System.String::IsNullOrEmpty(v41.name);\n\tv62 = v58 == 0;\n\tif (v62) goto L_0035;\nL_002A:\n\tgoto L_0035;\nL_0035:\n\treturn v74.Empty;\nL_0037:\n\tv68 = this.fsmEvent == 0;\n\tv54 = ~v68;\n\tif (v54) goto L_0022;\n\tgoto L_002A;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_00c4: Expected I, but got O
				FsmEvent fsmEvent = FsmEvent;
				IntPtr intPtr = (IntPtr)typeof(FsmEvent);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+12F]");
				if (0u != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						if (FsmEvent != null)
						{
							goto IL_0049;
						}
						goto IL_00f7;
					}
				}
				if (FsmEvent != null)
				{
					goto IL_0049;
				}
				goto IL_00f7;
				IL_0049:
				if (!string.IsNullOrEmpty(fsmEvent.Name))
				{
				}
				goto IL_00f7;
				IL_00f7:
				return string.Empty;
			}
		}

		[Token(Token = "0x60005BA")]
		[Address(RVA = "0xCB6C9C", Offset = "0xCB6C9C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmTransition()
		{
		}

		[Token(Token = "0x60005BB")]
		[Address(RVA = "0xCB3410", Offset = "0xCB3410", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.fsmEvent = source.fsmEvent;\n\tthis.toState = source.toState;\n\tthis.linkStyle = source.linkStyle;\n\tthis.linkConstraint = source.linkConstraint;\n\tthis.colorIndex = source.colorIndex;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmTransition(FsmTransition source)
		{
			FsmEvent = source.FsmEvent;
			ToState = source.ToState;
			LinkStyle = source.LinkStyle;
			LinkConstraint = source.LinkConstraint;
			colorIndex = source.colorIndex;
		}

		[Token(Token = "0x60005C9")]
		[Address(RVA = "0xCB6E64", Offset = "0xCB6E64", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = other == 0;\n\tif (v14) goto L_FFFFFFFF;\n\tv19 = this == other;\n\tif (v19) goto L_FFFFFFFF;\n\tv30 = System.String::op_Inequality(other.toState, this.toState);\n\tv48 = v30 == 0;\n\tif (v48) goto L_0025;\n\tgoto L_0023;\nL_0023:\n\treturn returnVal1;\nL_0025:\n\tv93 = HutongGames.PlayMaker.FsmTransition::get_EventName(other);\n\tv96 = HutongGames.PlayMaker.FsmTransition::get_EventName(this);\n\treturnVal2 = System.String::op_Equality(v93, v96);\n\treturn returnVal2;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool Equals(FsmTransition other)
		{
			if (other != null)
			{
				if (this == other)
				{
					return true;
				}
				if (!(other.ToState != ToState))
				{
					string eventName = other.EventName;
					string eventName2 = EventName;
					return eventName == eventName2;
				}
			}
			return false;
		}
	}
}
