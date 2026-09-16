using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75B660", Offset = "0x75B660")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75B660", Offset = "0x75B660")]
	[Token(Token = "0x20002EB")]
	public class SetProceduralVector2 : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C10A4", Offset = "0x7C10A4")]
		[Token(Token = "0x40018EE")]
		[FieldOffset(Offset = "0x50")]
		public FsmMaterial substanceMaterial;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C10F0", Offset = "0x7C10F0")]
		[Token(Token = "0x40018EF")]
		[FieldOffset(Offset = "0x58")]
		public FsmString vector2Property;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C113C", Offset = "0x7C113C")]
		[Token(Token = "0x40018F0")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector2 vector2Value;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C1188", Offset = "0x7C1188")]
		[Token(Token = "0x40018F1")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x6000E91")]
		[Address(RVA = "0x998810", Offset = "0x998810", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.vector2Property = 0;\n\tthis.vector2Value = 0;\n\tthis.substanceMaterial = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			vector2Property = null;
			vector2Value = null;
			substanceMaterial = null;
		}

		[Token(Token = "0x6000E92")]
		[Address(RVA = "0x998820", Offset = "0x998820", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = ~this.everyFrame;\n\tif (v2) goto L_0005;\n\treturn;\nL_0005:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000E93")]
		[Address(RVA = "0x998838", Offset = "0x998838", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void OnUpdate()
		{
		}

		[Token(Token = "0x6000E94")]
		[Address(RVA = "0x998834", Offset = "0x998834", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void DoSetProceduralVector()
		{
		}

		[Token(Token = "0x6000E95")]
		[Address(RVA = "0x99883C", Offset = "0x99883C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetProceduralVector2()
		{
		}
	}
}
