using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x754C1C", Offset = "0x754C1C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x754C1C", Offset = "0x754C1C")]
	[Token(Token = "0x20001A3")]
	public class GetColorRGBA : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7ACED8", Offset = "0x7ACED8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7ACED8", Offset = "0x7ACED8")]
		[Token(Token = "0x4001327")]
		[FieldOffset(Offset = "0x50")]
		public FsmColor color;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7ACF38", Offset = "0x7ACF38")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7ACF38", Offset = "0x7ACF38")]
		[Token(Token = "0x4001328")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat storeRed;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7ACF88", Offset = "0x7ACF88")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7ACF88", Offset = "0x7ACF88")]
		[Token(Token = "0x4001329")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat storeGreen;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7ACFD8", Offset = "0x7ACFD8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7ACFD8", Offset = "0x7ACFD8")]
		[Token(Token = "0x400132A")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat storeBlue;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7AD028", Offset = "0x7AD028")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AD028", Offset = "0x7AD028")]
		[Token(Token = "0x400132B")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat storeAlpha;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AD078", Offset = "0x7AD078")]
		[Token(Token = "0x400132C")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[Token(Token = "0x60008E6")]
		[Address(RVA = "0xB848F4", Offset = "0xB848F4", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.storeAlpha = 0;\n\tthis.color = 0;\n\tthis.storeGreen = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			everyFrame = false;
			storeAlpha = null;
			color = null;
			storeGreen = null;
		}

		[Token(Token = "0x60008E7")]
		[Address(RVA = "0xB84908", Offset = "0xB84908", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetColorRGBA::DoGetColorRGBA(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetColorRGBA();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60008E8")]
		[Address(RVA = "0xB849E0", Offset = "0xB849E0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetColorRGBA::DoGetColorRGBA(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetColorRGBA();
		}

		[Token(Token = "0x60008E9")]
		[Address(RVA = "0xB84944", Offset = "0xB84944", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.color);\n\tv42 = v13 == 0;\n\tv43 = ~v42;\n\tif (v43) goto L_0033;\n\tv44 = this.color;\n\tv63 = this.storeRed;\n\tv63.value = v44.value;\n\tv67 = this.color;\n\tv65 = this.storeGreen;\n\tv65.value = v67.value.g;\n\tv68 = this.color;\n\tv66 = this.storeBlue;\n\tv66.value = v68.value.b;\n\tv69 = this.color;\n\tv47 = this.storeAlpha;\n\tv47.value = v69.value.a;\nL_0033:\n\treturn;\n\tv25 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetColorRGBA()
		{
			if (!color.IsNone)
			{
				FsmColor fsmColor = color;
				FsmFloat fsmFloat = storeRed;
				fsmFloat.Value = fsmColor.value.r;
				FsmColor fsmColor2 = color;
				FsmFloat fsmFloat2 = storeGreen;
				fsmFloat2.Value = fsmColor2.value.g;
				FsmColor fsmColor3 = color;
				FsmFloat fsmFloat3 = storeBlue;
				fsmFloat3.Value = fsmColor3.value.b;
				FsmColor fsmColor4 = color;
				FsmFloat fsmFloat4 = storeAlpha;
				fsmFloat4.Value = fsmColor4.value.a;
			}
		}

		[Token(Token = "0x60008EA")]
		[Address(RVA = "0xB849E4", Offset = "0xB849E4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetColorRGBA()
		{
		}
	}
}
