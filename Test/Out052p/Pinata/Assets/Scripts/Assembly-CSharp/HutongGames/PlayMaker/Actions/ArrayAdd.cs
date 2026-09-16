using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x753914", Offset = "0x753914")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x753914", Offset = "0x753914")]
	[Token(Token = "0x200016F")]
	public class ArrayAdd : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A9090", Offset = "0x7A9090")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A9090", Offset = "0x7A9090")]
		[Token(Token = "0x400123A")]
		[FieldOffset(Offset = "0x50")]
		public FsmArray array;

		[RequiredField]
		[Attribute(Type = typeof(MatchElementTypeAttribute), RVA = "0x7A90F0", Offset = "0x7A90F0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A90F0", Offset = "0x7A90F0")]
		[Token(Token = "0x400123B")]
		[FieldOffset(Offset = "0x58")]
		public FsmVar value;

		[Token(Token = "0x6000804")]
		[Address(RVA = "0xA88710", Offset = "0xA88710", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.array = 0;\n\tthis.value = 0;\n\treturn;\n")]
		public override void Reset()
		{
			array = null;
			value = null;
		}

		[Token(Token = "0x6000805")]
		[Address(RVA = "0xA88718", Offset = "0xA88718", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ArrayAdd::DoAddValue(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoAddValue();
			Finish();
		}

		[Token(Token = "0x6000806")]
		[Address(RVA = "0xA88740", Offset = "0xA88740", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = HutongGames.PlayMaker.FsmArray::get_Length(this.array);\n\tv38 = v16 + 1;\n\tHutongGames.PlayMaker.FsmArray::Resize(this.array, v38);\n\tHutongGames.PlayMaker.FsmVar::UpdateValue(this.value);\n\tv29 = HutongGames.PlayMaker.FsmArray::get_Length(this.array);\n\tv83 = HutongGames.PlayMaker.FsmVar::GetValue(this.value);\n\tv70 = v29 - 1;\n\tHutongGames.PlayMaker.FsmArray::Set(this.array, v70, v83);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoAddValue()
		{
			int length = array.Length;
			int newLength = length + 1;
			array.Resize(newLength);
			value.UpdateValue();
			int length2 = array.Length;
			object obj = value.GetValue();
			int index = length2 - 1;
			array.Set(index, obj);
		}

		[Token(Token = "0x6000807")]
		[Address(RVA = "0xA887D4", Offset = "0xA887D4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ArrayAdd()
		{
		}
	}
}
