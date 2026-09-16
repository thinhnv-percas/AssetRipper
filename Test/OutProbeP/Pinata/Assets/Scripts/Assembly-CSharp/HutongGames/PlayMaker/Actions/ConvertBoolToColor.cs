using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x754D5C", Offset = "0x754D5C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x754D5C", Offset = "0x754D5C")]
	[Token(Token = "0x20001A8")]
	public class ConvertBoolToColor : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AD254", Offset = "0x7AD254")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AD254", Offset = "0x7AD254")]
		[Token(Token = "0x400133B")]
		[FieldOffset(Offset = "0x50")]
		public FsmBool boolVariable;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AD2B4", Offset = "0x7AD2B4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AD2B4", Offset = "0x7AD2B4")]
		[Token(Token = "0x400133C")]
		[FieldOffset(Offset = "0x58")]
		public FsmColor colorVariable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AD314", Offset = "0x7AD314")]
		[Token(Token = "0x400133D")]
		[FieldOffset(Offset = "0x60")]
		public FsmColor falseColor;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AD34C", Offset = "0x7AD34C")]
		[Token(Token = "0x400133E")]
		[FieldOffset(Offset = "0x68")]
		public FsmColor trueColor;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AD384", Offset = "0x7AD384")]
		[Token(Token = "0x400133F")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x6000906")]
		[Address(RVA = "0xA91FE0", Offset = "0xA91FE0", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.boolVariable = 0;\n\tthis.colorVariable = 0;\n\tv11 = UnityEngine.Color::get_black();\n\tv17 = HutongGames.PlayMaker.FsmColor::op_Implicit(v11);\n\tthis.falseColor = v17;\n\tv19 = UnityEngine.Color::get_white();\n\tv25 = HutongGames.PlayMaker.FsmColor::op_Implicit(v19);\n\tthis.trueColor = v25;\n\tthis.everyFrame = 0;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			boolVariable = null;
			colorVariable = null;
			Color black = Color.black;
			FsmColor fsmColor = black;
			falseColor = fsmColor;
			Color white = Color.white;
			FsmColor fsmColor2 = white;
			trueColor = fsmColor2;
			everyFrame = false;
		}

		[Token(Token = "0x6000907")]
		[Address(RVA = "0xA9202C", Offset = "0xA9202C", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ConvertBoolToColor::DoConvertBoolToColor(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoConvertBoolToColor();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000908")]
		[Address(RVA = "0xA920D8", Offset = "0xA920D8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ConvertBoolToColor::DoConvertBoolToColor(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoConvertBoolToColor();
		}

		[Token(Token = "0x6000909")]
		[Address(RVA = "0xA92068", Offset = "0xA92068", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this.colorVariable;\n\tv16 = HutongGames.PlayMaker.FsmBool::get_Value(this.boolVariable);\n\tv43 = v16 == 0;\n\tif (v43) goto L_0015;\n\tv69 = this.trueColor;\n\tv45 = this.trueColor == 0;\n\tv46 = ~v45;\n\tif (v46) goto L_001D;\n\tgoto L_0027;\nL_0015:\n\tv69 = this.falseColor;\nL_001D:\n\tv14.value.r = v69.value;\n\tv14.value.g = v69.value.g;\n\tv14.value.a = v69.value.a;\n\treturn;\nL_0027:\n\tv26 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoConvertBoolToColor()
		{
			FsmColor fsmColor = colorVariable;
			FsmColor fsmColor2;
			if (boolVariable.Value)
			{
				fsmColor2 = trueColor;
				if (trueColor == null)
				{
					NullReferenceException ex = new NullReferenceException();
					throw new NullReferenceException();
				}
			}
			else
			{
				fsmColor2 = falseColor;
			}
			fsmColor.value.r = fsmColor2.value.r;
			fsmColor.value.g = fsmColor2.value.g;
			fsmColor.value.a = fsmColor2.value.a;
		}

		[Token(Token = "0x600090A")]
		[Address(RVA = "0xA920DC", Offset = "0xA920DC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ConvertBoolToColor()
		{
		}
	}
}
