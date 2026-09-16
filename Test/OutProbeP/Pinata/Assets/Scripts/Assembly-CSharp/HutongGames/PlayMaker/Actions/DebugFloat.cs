using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7552D0", Offset = "0x7552D0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7552D0", Offset = "0x7552D0")]
	[Token(Token = "0x20001BA")]
	public class DebugFloat : BaseLogAction
	{
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AE368", Offset = "0x7AE368")]
		[Token(Token = "0x400137C")]
		[FieldOffset(Offset = "0x4C")]
		public LogLevel logLevel;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7AE3A0", Offset = "0x7AE3A0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AE3A0", Offset = "0x7AE3A0")]
		[Token(Token = "0x400137D")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat floatVariable;

		[Token(Token = "0x6000956")]
		[Address(RVA = "0xA85AC8", Offset = "0xA85AC8", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.logLevel = 0;\n\tthis.floatVariable = 0;\n\tHutongGames.PlayMaker.Actions.BaseLogAction::Reset(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			logLevel = default(LogLevel);
			floatVariable = null;
			base.Reset();
		}

		[Token(Token = "0x6000957")]
		[Address(RVA = "0xA85AD8", Offset = "0xA85AD8", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EBE988]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022191]) = v38;\nL_001A:\n\tv45 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.floatVariable);\n\tv55 = v45 == 0;\n\tv56 = ~v55;\n\tif (v56) goto L_0038;\n\tv48 = this.floatVariable;\n\tv65 = HutongGames.PlayMaker.FsmFloat::get_Value(this.floatVariable);\n\t// 42 Box v105 @ X0_v11 (System.Object), typeof(System.Single), &v65 @ V0_v2 (System.Single)\n\tv69 = System.String::Concat(v48.name, \": \", v105);\nL_0038:\n\tHutongGames.PlayMaker.ActionHelpers::DebugLog(this.fsm, this.logLevel, v73, this.sendToUnityLog);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			bool isNone = floatVariable.IsNone;
			bool flag = !isNone;
			bool flag2 = !flag;
			string text = "None";
			if (!flag2)
			{
				FsmFloat fsmFloat = floatVariable;
				float value = floatVariable.Value;
				object obj = value;
				string text2 = fsmFloat.Name + ": " + obj;
				text = text2;
			}
			ActionHelpers.DebugLog(Fsm, logLevel, text, sendToUnityLog);
			Finish();
		}

		[Token(Token = "0x6000958")]
		[Address(RVA = "0xA85BB4", Offset = "0xA85BB4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BaseLogAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DebugFloat()
		{
		}
	}
}
