using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7551E0", Offset = "0x7551E0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7551E0", Offset = "0x7551E0")]
	[Token(Token = "0x20001B7")]
	public class DebugBool : BaseLogAction
	{
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AE12C", Offset = "0x7AE12C")]
		[Token(Token = "0x4001373")]
		[FieldOffset(Offset = "0x4C")]
		public LogLevel logLevel;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7AE164", Offset = "0x7AE164")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AE164", Offset = "0x7AE164")]
		[Token(Token = "0x4001374")]
		[FieldOffset(Offset = "0x50")]
		public FsmBool boolVariable;

		[Token(Token = "0x600094D")]
		[Address(RVA = "0xA8561C", Offset = "0xA8561C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.logLevel = 0;\n\tthis.boolVariable = 0;\n\tHutongGames.PlayMaker.Actions.BaseLogAction::Reset(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			logLevel = default(LogLevel);
			boolVariable = null;
			base.Reset();
		}

		[Token(Token = "0x600094E")]
		[Address(RVA = "0xA8562C", Offset = "0xA8562C", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = *([1EDF238]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202218E]) = v38;\nL_001B:\n\tv46 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.boolVariable);\n\tv56 = v46 == 0;\n\tv57 = ~v56;\n\tif (v57) goto L_0038;\n\tv49 = this.boolVariable;\n\tv98 = HutongGames.PlayMaker.FsmBool::get_Value(this.boolVariable);\n\tv102 = 0xE8F14C(&v98 @ X0_v10 (System.Boolean), 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv67 = System.String::Concat(v49.name, \": \", v102);\nL_0038:\n\tHutongGames.PlayMaker.ActionHelpers::DebugLog(this.fsm, this.logLevel, v71, this.sendToUnityLog);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			bool isNone = boolVariable.IsNone;
			bool flag = !isNone;
			bool flag2 = !flag;
			string text = "None";
			if (!flag2)
			{
				FsmBool fsmBool = boolVariable;
				bool value = boolVariable.Value;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @E8F14C (inside System.BitConverter::.cctor +0x64)");
				string text3 = default(string);
				string text2 = fsmBool.Name + ": " + text3;
				text = text2;
			}
			ActionHelpers.DebugLog(Fsm, logLevel, text, sendToUnityLog);
			Finish();
		}

		[Token(Token = "0x600094F")]
		[Address(RVA = "0xA85708", Offset = "0xA85708", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BaseLogAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DebugBool()
		{
		}
	}
}
