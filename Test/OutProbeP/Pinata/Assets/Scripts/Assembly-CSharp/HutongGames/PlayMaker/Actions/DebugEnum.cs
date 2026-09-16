using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x755280", Offset = "0x755280")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x755280", Offset = "0x755280")]
	[Token(Token = "0x20001B9")]
	public class DebugEnum : BaseLogAction
	{
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AE2E0", Offset = "0x7AE2E0")]
		[Token(Token = "0x400137A")]
		[FieldOffset(Offset = "0x4C")]
		public LogLevel logLevel;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AE318", Offset = "0x7AE318")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AE318", Offset = "0x7AE318")]
		[Token(Token = "0x400137B")]
		[FieldOffset(Offset = "0x50")]
		public FsmEnum enumVariable;

		[Token(Token = "0x6000953")]
		[Address(RVA = "0xA859F8", Offset = "0xA859F8", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.logLevel = 0;\n\tthis.enumVariable = 0;\n\tHutongGames.PlayMaker.Actions.BaseLogAction::Reset(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			logLevel = default(LogLevel);
			enumVariable = null;
			base.Reset();
		}

		[Token(Token = "0x6000954")]
		[Address(RVA = "0xA85A08", Offset = "0xA85A08", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EBD778]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022190]) = v38;\nL_001A:\n\tv45 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.enumVariable);\n\tv55 = v45 == 0;\n\tv56 = ~v55;\n\tif (v56) goto L_0032;\n\tv48 = this.enumVariable;\n\tv94 = HutongGames.PlayMaker.FsmEnum::get_Value(this.enumVariable);\n\tv64 = System.String::Concat(v48.name, \": \", v94);\nL_0032:\n\tHutongGames.PlayMaker.ActionHelpers::DebugLog(this.fsm, this.logLevel, v68, this.sendToUnityLog);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			bool isNone = enumVariable.IsNone;
			bool flag = !isNone;
			bool flag2 = !flag;
			string text = "None";
			if (!flag2)
			{
				FsmEnum fsmEnum = enumVariable;
				Enum value = enumVariable.Value;
				string text2 = fsmEnum.Name + ": " + value;
				text = text2;
			}
			ActionHelpers.DebugLog(Fsm, logLevel, text, sendToUnityLog);
			Finish();
		}

		[Token(Token = "0x6000955")]
		[Address(RVA = "0xA85AC0", Offset = "0xA85AC0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BaseLogAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DebugEnum()
		{
		}
	}
}
