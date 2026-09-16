using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x753C34", Offset = "0x753C34")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x753C34", Offset = "0x753C34")]
	[Token(Token = "0x2000179")]
	public class ArrayLength : FsmStateAction
	{
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A9E58", Offset = "0x7A9E58")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A9E58", Offset = "0x7A9E58")]
		[Token(Token = "0x4001269")]
		[FieldOffset(Offset = "0x50")]
		public FsmArray array;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A9EA8", Offset = "0x7A9EA8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A9EA8", Offset = "0x7A9EA8")]
		[Token(Token = "0x400126A")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt length;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A9EF8", Offset = "0x7A9EF8")]
		[Token(Token = "0x400126B")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x6000835")]
		[Address(RVA = "0xA89A5C", Offset = "0xA89A5C", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.array = 0;\n\tthis.length = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			array = null;
			length = null;
		}

		[Token(Token = "0x6000836")]
		[Address(RVA = "0xA89A68", Offset = "0xA89A68", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this.length;\n\tv16 = HutongGames.PlayMaker.FsmArray::get_Length(this.array);\n\tv14.value = v16;\n\tv41 = ~this.everyFrame;\n\tif (v41) goto L_0020;\n\treturn;\nL_0020:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			FsmInt fsmInt = length;
			int value = array.Length;
			fsmInt.Value = value;
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000837")]
		[Address(RVA = "0xA89AC8", Offset = "0xA89AC8", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.length;\n\tv14 = HutongGames.PlayMaker.FsmArray::get_Length(this.array);\n\tv12.value = v14;\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			FsmInt fsmInt = length;
			int value = array.Length;
			fsmInt.Value = value;
		}

		[Token(Token = "0x6000838")]
		[Address(RVA = "0xA89B0C", Offset = "0xA89B0C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ArrayLength()
		{
		}
	}
}
