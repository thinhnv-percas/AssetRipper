using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x755460", Offset = "0x755460")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x755460", Offset = "0x755460")]
	[Token(Token = "0x20001BF")]
	public class DebugObject : BaseLogAction
	{
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AE608", Offset = "0x7AE608")]
		[Token(Token = "0x4001386")]
		[FieldOffset(Offset = "0x4C")]
		public LogLevel logLevel;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7AE640", Offset = "0x7AE640")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AE640", Offset = "0x7AE640")]
		[Token(Token = "0x4001387")]
		[FieldOffset(Offset = "0x50")]
		public FsmObject fsmObject;

		[Token(Token = "0x6000965")]
		[Address(RVA = "0xA85ED8", Offset = "0xA85ED8", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.logLevel = 0;\n\tthis.fsmObject = 0;\n\tHutongGames.PlayMaker.Actions.BaseLogAction::Reset(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			logLevel = default(LogLevel);
			fsmObject = null;
			base.Reset();
		}

		[Token(Token = "0x6000966")]
		[Address(RVA = "0xA85EE8", Offset = "0xA85EE8", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1F05560]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022195]) = v38;\nL_001A:\n\tv45 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.fsmObject);\n\tv48 = v45 == 0;\n\tv49 = ~v48;\n\tif (v49) goto L_002E;\n\tv51 = this.fsmObject;\n\tv66 = System.String::Concat(v51.name, \": \", this.fsmObject);\nL_002E:\n\tHutongGames.PlayMaker.ActionHelpers::DebugLog(this.fsm, this.logLevel, v70, this.sendToUnityLog);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			bool isNone = this.fsmObject.IsNone;
			bool flag = !isNone;
			bool flag2 = !flag;
			string text = "None";
			if (!flag2)
			{
				FsmObject fsmObject = this.fsmObject;
				string text2 = fsmObject.Name + ": " + this.fsmObject;
				text = text2;
			}
			ActionHelpers.DebugLog(Fsm, logLevel, text, sendToUnityLog);
			Finish();
		}

		[Token(Token = "0x6000967")]
		[Address(RVA = "0xA85F98", Offset = "0xA85F98", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BaseLogAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DebugObject()
		{
		}
	}
}
