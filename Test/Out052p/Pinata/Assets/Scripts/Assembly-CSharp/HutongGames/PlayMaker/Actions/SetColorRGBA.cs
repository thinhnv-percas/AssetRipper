using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x754CBC", Offset = "0x754CBC")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x754CBC", Offset = "0x754CBC")]
	[Token(Token = "0x20001A5")]
	public class SetColorRGBA : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7AD16C", Offset = "0x7AD16C")]
		[Token(Token = "0x4001330")]
		[FieldOffset(Offset = "0x50")]
		public FsmColor colorVariable;

		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7AD1A8", Offset = "0x7AD1A8")]
		[Token(Token = "0x4001331")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat red;

		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7AD1C0", Offset = "0x7AD1C0")]
		[Token(Token = "0x4001332")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat green;

		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7AD1D8", Offset = "0x7AD1D8")]
		[Token(Token = "0x4001333")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat blue;

		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7AD1F0", Offset = "0x7AD1F0")]
		[Token(Token = "0x4001334")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat alpha;

		[Token(Token = "0x4001335")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[Token(Token = "0x60008EF")]
		[Address(RVA = "0xB2CB3C", Offset = "0xB2CB3C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.colorVariable = 0;\n\tv12 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0f);\n\tthis.red = v12;\n\tv15 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0f);\n\tthis.green = v15;\n\tv18 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0f);\n\tthis.blue = v18;\n\tv21 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.alpha = v21;\n\tthis.everyFrame = 0;\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			colorVariable = null;
			FsmFloat fsmFloat = 0f;
			red = fsmFloat;
			FsmFloat fsmFloat2 = 0f;
			green = fsmFloat2;
			FsmFloat fsmFloat3 = 0f;
			blue = fsmFloat3;
			FsmFloat fsmFloat4 = 1f;
			alpha = fsmFloat4;
			everyFrame = false;
		}

		[Token(Token = "0x60008F0")]
		[Address(RVA = "0xB2CBA0", Offset = "0xB2CBA0", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetColorRGBA::DoSetColorRGBA(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetColorRGBA();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60008F1")]
		[Address(RVA = "0xB2CCD4", Offset = "0xB2CCD4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetColorRGBA::DoSetColorRGBA(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoSetColorRGBA();
		}

		[Token(Token = "0x60008F2")]
		[Address(RVA = "0xB2CBDC", Offset = "0xB2CBDC", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = this.colorVariable;\n\tv19 = this.colorVariable == 0;\n\tif (v19) goto L_005C;\n\tv33 = v18.value.g;\n\tv31 = v18.value.b;\n\tv29 = v18.value.a;\n\tv54 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.red);\n\tv122 = v54 == 0;\n\tv123 = ~v122;\n\tif (v123) goto L_0024;\n\tv126 = HutongGames.PlayMaker.FsmFloat::get_Value(this.red);\nL_0024:\n\tv131 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.green);\n\tv133 = v131 == 0;\n\tv134 = ~v133;\n\tif (v134) goto L_0033;\n\tv135 = HutongGames.PlayMaker.FsmFloat::get_Value(this.green);\nL_0033:\n\tv140 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.blue);\n\tv142 = v140 == 0;\n\tv143 = ~v142;\n\tif (v143) goto L_0042;\n\tv144 = HutongGames.PlayMaker.FsmFloat::get_Value(this.blue);\nL_0042:\n\tv149 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.alpha);\n\tv151 = v149 == 0;\n\tv152 = ~v151;\n\tif (v152) goto L_004D;\n\tv153 = HutongGames.PlayMaker.FsmFloat::get_Value(this.alpha);\nL_004D:\n\tv41 = this.colorVariable;\n\tv41.value = v35;\n\tv41.value.g = v33;\n\tv41.value.b = v31;\n\tv41.value.a = v29;\nL_005C:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetColorRGBA()
		{
			//IL_01ca: Expected O, but got F4
			FsmColor fsmColor = colorVariable;
			if (colorVariable != null)
			{
				float g = fsmColor.value.g;
				float b = fsmColor.value.b;
				float a = fsmColor.value.a;
				bool isNone = red.IsNone;
				bool flag = !isNone;
				bool flag2 = !flag;
				float num = fsmColor.value.r;
				if (!flag2)
				{
					float value = red.Value;
					num = value;
				}
				if (!green.IsNone)
				{
					float value2 = green.Value;
					g = value2;
				}
				if (!blue.IsNone)
				{
					float value3 = blue.Value;
					b = value3;
				}
				if (!alpha.IsNone)
				{
					float value4 = alpha.Value;
					a = value4;
				}
				FsmColor fsmColor2 = colorVariable;
				fsmColor2.value = (Color)num;
				fsmColor2.value.g = g;
				fsmColor2.value.b = b;
				fsmColor2.value.a = a;
			}
		}

		[Token(Token = "0x60008F3")]
		[Address(RVA = "0xB2CCD8", Offset = "0xB2CCD8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetColorRGBA()
		{
		}
	}
}
