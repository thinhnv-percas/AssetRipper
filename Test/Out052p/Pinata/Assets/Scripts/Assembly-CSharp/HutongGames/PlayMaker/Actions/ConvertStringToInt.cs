using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7550F0", Offset = "0x7550F0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7550F0", Offset = "0x7550F0")]
	[Token(Token = "0x20001B3")]
	public class ConvertStringToInt : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7ADF40", Offset = "0x7ADF40")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7ADF40", Offset = "0x7ADF40")]
		[Token(Token = "0x4001368")]
		[FieldOffset(Offset = "0x50")]
		public FsmString stringVariable;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7ADFA0", Offset = "0x7ADFA0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7ADFA0", Offset = "0x7ADFA0")]
		[Token(Token = "0x4001369")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt intVariable;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AE000", Offset = "0x7AE000")]
		[Token(Token = "0x400136A")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x600093D")]
		[Address(RVA = "0xA92F28", Offset = "0xA92F28", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.stringVariable = 0;\n\tthis.intVariable = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			stringVariable = null;
			intVariable = null;
		}

		[Token(Token = "0x600093E")]
		[Address(RVA = "0xA92F34", Offset = "0xA92F34", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ConvertStringToInt::DoConvertStringToInt(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoConvertStringToInt();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x600093F")]
		[Address(RVA = "0xA92FBC", Offset = "0xA92FBC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ConvertStringToInt::DoConvertStringToInt(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoConvertStringToInt();
		}

		[Token(Token = "0x6000940")]
		[Address(RVA = "0xA92F70", Offset = "0xA92F70", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.intVariable;\n\tv14 = HutongGames.PlayMaker.FsmString::get_Value(this.stringVariable);\n\tv32 = System.Int32::Parse(v14);\n\tv12.value = v32;\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoConvertStringToInt()
		{
			FsmInt fsmInt = intVariable;
			string value = stringVariable.Value;
			int value2 = int.Parse(value);
			fsmInt.Value = value2;
		}

		[Token(Token = "0x6000941")]
		[Address(RVA = "0xA92FC0", Offset = "0xA92FC0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ConvertStringToInt()
		{
		}
	}
}
