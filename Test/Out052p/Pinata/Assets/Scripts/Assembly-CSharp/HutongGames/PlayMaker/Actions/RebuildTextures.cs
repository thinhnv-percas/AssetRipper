using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75B4E0", Offset = "0x75B4E0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75B4E0", Offset = "0x75B4E0")]
	[Token(Token = "0x20002E7")]
	public class RebuildTextures : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x40018DF")]
		[FieldOffset(Offset = "0x50")]
		public FsmMaterial substanceMaterial;

		[RequiredField]
		[Token(Token = "0x40018E0")]
		[FieldOffset(Offset = "0x58")]
		public FsmBool immediately;

		[Token(Token = "0x40018E1")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x6000E7D")]
		[Address(RVA = "0xB1E840", Offset = "0xB1E840", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.substanceMaterial = 0;\n\tv12 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.immediately = v12;\n\tthis.everyFrame = 0;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			substanceMaterial = null;
			FsmBool fsmBool = false;
			immediately = fsmBool;
			everyFrame = false;
		}

		[Token(Token = "0x6000E7E")]
		[Address(RVA = "0xB1E874", Offset = "0xB1E874", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = ~this.everyFrame;\n\tif (v2) goto L_0005;\n\treturn;\nL_0005:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000E7F")]
		[Address(RVA = "0xB1E88C", Offset = "0xB1E88C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void OnUpdate()
		{
		}

		[Token(Token = "0x6000E80")]
		[Address(RVA = "0xB1E888", Offset = "0xB1E888", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void DoRebuildTextures()
		{
		}

		[Token(Token = "0x6000E81")]
		[Address(RVA = "0xB1E890", Offset = "0xB1E890", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RebuildTextures()
		{
		}
	}
}
