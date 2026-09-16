using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x755C70", Offset = "0x755C70")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x755C70", Offset = "0x755C70")]
	[Token(Token = "0x20001D7")]
	public class SetEnumValue : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AFF80", Offset = "0x7AFF80")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AFF80", Offset = "0x7AFF80")]
		[Token(Token = "0x4001414")]
		[FieldOffset(Offset = "0x50")]
		public FsmEnum enumVariable;

		[AttributeAttribute(Type = typeof(MatchFieldTypeAttribute), RVA = "0x7AFFD0", Offset = "0x7AFFD0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AFFD0", Offset = "0x7AFFD0")]
		[Token(Token = "0x4001415")]
		[FieldOffset(Offset = "0x58")]
		public FsmEnum enumValue;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B0030", Offset = "0x7B0030")]
		[Token(Token = "0x4001416")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x60009C7")]
		[Address(RVA = "0xB2CEF0", Offset = "0xB2CEF0", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.enumVariable = 0;\n\tthis.enumValue = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			enumVariable = null;
			enumValue = null;
		}

		[Token(Token = "0x60009C8")]
		[Address(RVA = "0xB2CEFC", Offset = "0xB2CEFC", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetEnumValue::DoSetEnumValue(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetEnumValue();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60009C9")]
		[Address(RVA = "0xB2CF84", Offset = "0xB2CF84", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetEnumValue::DoSetEnumValue(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoSetEnumValue();
		}

		[Token(Token = "0x60009CA")]
		[Address(RVA = "0xB2CF38", Offset = "0xB2CF38", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = HutongGames.PlayMaker.FsmEnum::get_Value(this.enumValue);\n\tHutongGames.PlayMaker.FsmEnum::set_Value(this.enumVariable, v14);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetEnumValue()
		{
			Enum value = enumValue.Value;
			enumVariable.Value = value;
		}

		[Token(Token = "0x60009CB")]
		[Address(RVA = "0xB2CF88", Offset = "0xB2CF88", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetEnumValue()
		{
		}
	}
}
