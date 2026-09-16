using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7553C0", Offset = "0x7553C0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7553C0", Offset = "0x7553C0")]
	[Token(Token = "0x20001BD")]
	public class DebugInt : BaseLogAction
	{
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AE510", Offset = "0x7AE510")]
		[Token(Token = "0x4001382")]
		[FieldOffset(Offset = "0x4C")]
		public LogLevel logLevel;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7AE548", Offset = "0x7AE548")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AE548", Offset = "0x7AE548")]
		[Token(Token = "0x4001383")]
		[FieldOffset(Offset = "0x50")]
		public FsmInt intVariable;

		[Token(Token = "0x600095F")]
		[Address(RVA = "0xA85CFC", Offset = "0xA85CFC", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.logLevel = 0;\n\tthis.intVariable = 0;\n\treturn;\n")]
		public override void Reset()
		{
			logLevel = default(LogLevel);
			intVariable = null;
		}

		[Token(Token = "0x6000960")]
		[Address(RVA = "0xA85D08", Offset = "0xA85D08", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EC4BB8]);\n\tv19 = *([v18 @ X8_v14]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022193]) = v38;\nL_001A:\n\tv45 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.intVariable);\n\tv55 = v45 == 0;\n\tv56 = ~v55;\n\tif (v56) goto L_0039;\n\tv48 = this.intVariable;\n\tv98 = HutongGames.PlayMaker.FsmInt::get_Value(this.intVariable);\n\t// 43 Box v104 @ X0_v12 (System.Object), typeof(System.Int32), &v98 @ X0_v10 (System.Int32)\n\tv67 = System.String::Concat(v48.name, \": \", v104);\nL_0039:\n\tHutongGames.PlayMaker.ActionHelpers::DebugLog(this.fsm, this.logLevel, v71, this.sendToUnityLog);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			bool isNone = intVariable.IsNone;
			bool flag = !isNone;
			bool flag2 = !flag;
			string text = "None";
			if (!flag2)
			{
				FsmInt fsmInt = intVariable;
				int value = intVariable.Value;
				object obj = value;
				string text2 = fsmInt.Name + ": " + obj;
				text = text2;
			}
			ActionHelpers.DebugLog(Fsm, logLevel, text, sendToUnityLog);
			Finish();
		}

		[Token(Token = "0x6000961")]
		[Address(RVA = "0xA85DE8", Offset = "0xA85DE8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BaseLogAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DebugInt()
		{
		}
	}
}
