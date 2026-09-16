using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75BC70", Offset = "0x75BC70")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75BC70", Offset = "0x75BC70")]
	[Token(Token = "0x20002FF")]
	public class SetRectValue : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C242C", Offset = "0x7C242C")]
		[Token(Token = "0x400193B")]
		[FieldOffset(Offset = "0x50")]
		public FsmRect rectVariable;

		[RequiredField]
		[Token(Token = "0x400193C")]
		[FieldOffset(Offset = "0x58")]
		public FsmRect rectValue;

		[Token(Token = "0x400193D")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x6000F0E")]
		[Address(RVA = "0x999184", Offset = "0x999184", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.rectVariable = 0;\n\tthis.rectValue = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			rectVariable = null;
			rectValue = null;
		}

		[Token(Token = "0x6000F0F")]
		[Address(RVA = "0x999190", Offset = "0x999190", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.rectValue;\n\tv9 = this.rectVariable;\n\tv9.value.m_XMin = v6.value;\n\tv9.value.m_YMin = v6.value.m_YMin;\n\tv9.value.m_Height = v6.value.m_Height;\n\tv35 = ~this.everyFrame;\n\tif (v35) goto L_001B;\n\treturn;\nL_001B:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			FsmRect fsmRect = rectValue;
			FsmRect fsmRect2 = rectVariable;
			fsmRect2.value.x = fsmRect.value.x;
			fsmRect2.value.y = fsmRect.value.y;
			fsmRect2.value.height = fsmRect.value.height;
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000F10")]
		[Address(RVA = "0x9991E4", Offset = "0x9991E4", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.rectValue;\n\tv9 = this.rectVariable;\n\tv9.value.m_XMin = v6.value;\n\tv9.value.m_YMin = v6.value.m_YMin;\n\tv9.value.m_Height = v6.value.m_Height;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			FsmRect fsmRect = rectValue;
			FsmRect fsmRect2 = rectVariable;
			fsmRect2.value.x = fsmRect.value.x;
			fsmRect2.value.y = fsmRect.value.y;
			fsmRect2.value.height = fsmRect.value.height;
		}

		[Token(Token = "0x6000F11")]
		[Address(RVA = "0x999224", Offset = "0x999224", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetRectValue()
		{
		}
	}
}
