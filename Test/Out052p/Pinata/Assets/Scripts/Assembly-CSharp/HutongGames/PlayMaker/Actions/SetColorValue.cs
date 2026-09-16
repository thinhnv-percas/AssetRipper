using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x754D0C", Offset = "0x754D0C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x754D0C", Offset = "0x754D0C")]
	[Token(Token = "0x20001A6")]
	public class SetColorValue : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7AD208", Offset = "0x7AD208")]
		[Token(Token = "0x4001336")]
		[FieldOffset(Offset = "0x50")]
		public FsmColor colorVariable;

		[RequiredField]
		[Token(Token = "0x4001337")]
		[FieldOffset(Offset = "0x58")]
		public FsmColor color;

		[Token(Token = "0x4001338")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x60008F4")]
		[Address(RVA = "0xB2CCE0", Offset = "0xB2CCE0", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.colorVariable = 0;\n\tthis.color = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			colorVariable = null;
			color = null;
		}

		[Token(Token = "0x60008F5")]
		[Address(RVA = "0xB2CCEC", Offset = "0xB2CCEC", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetColorValue::DoSetColorValue(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetColorValue();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60008F6")]
		[Address(RVA = "0xB2CD64", Offset = "0xB2CD64", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetColorValue::DoSetColorValue(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoSetColorValue();
		}

		[Token(Token = "0x60008F7")]
		[Address(RVA = "0xB2CD28", Offset = "0xB2CD28", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.colorVariable;\n\tv2 = this.colorVariable == 0;\n\tif (v2) goto L_000C;\n\tv3 = this.color;\n\tv0.value.r = v3.value;\n\tv0.value.g = v3.value.g;\n\tv0.value.a = v3.value.a;\nL_000C:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetColorValue()
		{
			FsmColor fsmColor = colorVariable;
			if (colorVariable != null)
			{
				FsmColor fsmColor2 = color;
				fsmColor.value.r = fsmColor2.value.r;
				fsmColor.value.g = fsmColor2.value.g;
				fsmColor.value.a = fsmColor2.value.a;
			}
		}

		[Token(Token = "0x60008F8")]
		[Address(RVA = "0xB2CD68", Offset = "0xB2CD68", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetColorValue()
		{
		}
	}
}
