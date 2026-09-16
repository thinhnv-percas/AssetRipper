using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75B6C0", Offset = "0x75B6C0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75B6C0", Offset = "0x75B6C0")]
	[Token(Token = "0x20002EC")]
	public class SetProceduralVector3 : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C11C0", Offset = "0x7C11C0")]
		[Token(Token = "0x40018F2")]
		[FieldOffset(Offset = "0x50")]
		public FsmMaterial substanceMaterial;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C120C", Offset = "0x7C120C")]
		[Token(Token = "0x40018F3")]
		[FieldOffset(Offset = "0x58")]
		public FsmString vector3Property;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C1258", Offset = "0x7C1258")]
		[Token(Token = "0x40018F4")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector3 vector3Value;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C12A4", Offset = "0x7C12A4")]
		[Token(Token = "0x40018F5")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x6000E96")]
		[Address(RVA = "0x998844", Offset = "0x998844", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.vector3Property = 0;\n\tthis.vector3Value = 0;\n\tthis.substanceMaterial = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			vector3Property = null;
			vector3Value = null;
			substanceMaterial = null;
		}

		[Token(Token = "0x6000E97")]
		[Address(RVA = "0x998854", Offset = "0x998854", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = ~this.everyFrame;\n\tif (v2) goto L_0005;\n\treturn;\nL_0005:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000E98")]
		[Address(RVA = "0x99886C", Offset = "0x99886C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void OnUpdate()
		{
		}

		[Token(Token = "0x6000E99")]
		[Address(RVA = "0x998868", Offset = "0x998868", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void DoSetProceduralVector()
		{
		}

		[Token(Token = "0x6000E9A")]
		[Address(RVA = "0x998870", Offset = "0x998870", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetProceduralVector3()
		{
		}
	}
}
