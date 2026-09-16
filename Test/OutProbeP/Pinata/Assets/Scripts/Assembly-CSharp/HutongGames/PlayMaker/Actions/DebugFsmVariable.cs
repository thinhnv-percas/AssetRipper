using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x755320", Offset = "0x755320")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x755320", Offset = "0x755320")]
	[Token(Token = "0x20001BB")]
	public class DebugFsmVariable : BaseLogAction
	{
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AE3F0", Offset = "0x7AE3F0")]
		[Token(Token = "0x400137E")]
		[FieldOffset(Offset = "0x4C")]
		public LogLevel logLevel;

		[HideTypeFilter]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7AE428", Offset = "0x7AE428")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AE428", Offset = "0x7AE428")]
		[Token(Token = "0x400137F")]
		[FieldOffset(Offset = "0x50")]
		public FsmVar variable;

		[Token(Token = "0x6000959")]
		[Address(RVA = "0xA85BBC", Offset = "0xA85BBC", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.logLevel = 0;\n\tthis.variable = 0;\n\tHutongGames.PlayMaker.Actions.BaseLogAction::Reset(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			logLevel = default(LogLevel);
			variable = null;
			base.Reset();
		}

		[Token(Token = "0x600095A")]
		[Address(RVA = "0xA85BCC", Offset = "0xA85BCC", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = HutongGames.PlayMaker.FsmVar::DebugString(this.variable);\n\tHutongGames.PlayMaker.ActionHelpers::DebugLog(this.fsm, this.logLevel, v19, this.sendToUnityLog);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			string text = variable.DebugString();
			ActionHelpers.DebugLog(Fsm, logLevel, text, sendToUnityLog);
			Finish();
		}

		[Token(Token = "0x600095B")]
		[Address(RVA = "0xA85C2C", Offset = "0xA85C2C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BaseLogAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DebugFsmVariable()
		{
		}
	}
}
