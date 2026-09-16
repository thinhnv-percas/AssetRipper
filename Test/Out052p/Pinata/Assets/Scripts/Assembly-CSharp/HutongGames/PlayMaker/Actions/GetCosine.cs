using System;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x760570", Offset = "0x760570")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x760570", Offset = "0x760570")]
	[Token(Token = "0x20003B1")]
	public class GetCosine : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CF2DC", Offset = "0x7CF2DC")]
		[Token(Token = "0x4001D59")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat angle;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CF328", Offset = "0x7CF328")]
		[Token(Token = "0x4001D5A")]
		[FieldOffset(Offset = "0x58")]
		public FsmBool DegToRad;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CF360", Offset = "0x7CF360")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CF360", Offset = "0x7CF360")]
		[Token(Token = "0x4001D5B")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat result;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CF3C0", Offset = "0x7CF3C0")]
		[Token(Token = "0x4001D5C")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x600126B")]
		[Address(RVA = "0xA2A72C", Offset = "0xA2A72C", Length = "0x34")]
		public override void Reset()
		{
			angle = null;
			FsmBool degToRad = true;
			everyFrame = false;
			DegToRad = degToRad;
			result = null;
		}

		[Token(Token = "0x600126C")]
		[Address(RVA = "0xA2A760", Offset = "0xA2A760", Length = "0x3C")]
		public override void OnEnter()
		{
			DoCosine();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x600126D")]
		[Address(RVA = "0xA2A860", Offset = "0xA2A860", Length = "0x4")]
		public override void OnUpdate()
		{
			DoCosine();
		}

		[Token(Token = "0x600126E")]
		[Address(RVA = "0xA2A79C", Offset = "0xA2A79C", Length = "0xC4")]
		private void DoCosine()
		{
			float value = angle.Value;
			bool value2 = DegToRad.Value;
			FsmFloat fsmFloat = result;
			bool flag = !value2;
			float num = value * ((float)Math.PI / 180f);
			float value3 = (flag ? value : num);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D3020 (native cosf)");
			fsmFloat.Value = value3;
		}

		[Token(Token = "0x600126F")]
		[Address(RVA = "0xA2A864", Offset = "0xA2A864", Length = "0x8")]
		public GetCosine()
		{
		}
	}
}
