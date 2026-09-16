using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x755370", Offset = "0x755370")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x755370", Offset = "0x755370")]
	[Token(Token = "0x20001BC")]
	public class DebugGameObject : BaseLogAction
	{
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AE488", Offset = "0x7AE488")]
		[Token(Token = "0x4001380")]
		[FieldOffset(Offset = "0x4C")]
		public LogLevel logLevel;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7AE4C0", Offset = "0x7AE4C0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AE4C0", Offset = "0x7AE4C0")]
		[Token(Token = "0x4001381")]
		[FieldOffset(Offset = "0x50")]
		public FsmGameObject gameObject;

		[Token(Token = "0x600095C")]
		[Address(RVA = "0xA85C34", Offset = "0xA85C34", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.logLevel = 0;\n\tthis.gameObject = 0;\n\tHutongGames.PlayMaker.Actions.BaseLogAction::Reset(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			logLevel = default(LogLevel);
			gameObject = null;
			base.Reset();
		}

		[Token(Token = "0x600095D")]
		[Address(RVA = "0xA85C44", Offset = "0xA85C44", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EDE068]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022192]) = v38;\nL_001A:\n\tv45 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.gameObject);\n\tv48 = v45 == 0;\n\tv49 = ~v48;\n\tif (v49) goto L_002E;\n\tv51 = this.gameObject;\n\tv66 = System.String::Concat(v51.name, \": \", this.gameObject);\nL_002E:\n\tHutongGames.PlayMaker.ActionHelpers::DebugLog(this.fsm, this.logLevel, v70, this.sendToUnityLog);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			bool isNone = gameObject.IsNone;
			bool flag = !isNone;
			bool flag2 = !flag;
			string text = "None";
			if (!flag2)
			{
				FsmGameObject fsmGameObject = gameObject;
				string text2 = fsmGameObject.Name + ": " + gameObject;
				text = text2;
			}
			ActionHelpers.DebugLog(Fsm, logLevel, text, sendToUnityLog);
			Finish();
		}

		[Token(Token = "0x600095E")]
		[Address(RVA = "0xA85CF4", Offset = "0xA85CF4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BaseLogAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DebugGameObject()
		{
		}
	}
}
