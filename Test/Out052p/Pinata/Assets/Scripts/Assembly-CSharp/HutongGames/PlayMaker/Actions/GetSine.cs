using System;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7605C0", Offset = "0x7605C0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7605C0", Offset = "0x7605C0")]
	[Token(Token = "0x20003B2")]
	public class GetSine : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CF3F8", Offset = "0x7CF3F8")]
		[Token(Token = "0x4001D5D")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat angle;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CF444", Offset = "0x7CF444")]
		[Token(Token = "0x4001D5E")]
		[FieldOffset(Offset = "0x58")]
		public FsmBool DegToRad;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CF47C", Offset = "0x7CF47C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CF47C", Offset = "0x7CF47C")]
		[Token(Token = "0x4001D5F")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat result;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CF4DC", Offset = "0x7CF4DC")]
		[Token(Token = "0x4001D60")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x6001270")]
		[Address(RVA = "0xA35A00", Offset = "0xA35A00", Length = "0x34")]
		public override void Reset()
		{
			angle = null;
			FsmBool degToRad = true;
			everyFrame = false;
			DegToRad = degToRad;
			result = null;
		}

		[Token(Token = "0x6001271")]
		[Address(RVA = "0xA35A34", Offset = "0xA35A34", Length = "0x3C")]
		public override void OnEnter()
		{
			DoSine();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001272")]
		[Address(RVA = "0xA35B34", Offset = "0xA35B34", Length = "0x4")]
		public override void OnUpdate()
		{
			DoSine();
		}

		[Token(Token = "0x6001273")]
		[Address(RVA = "0xA35A70", Offset = "0xA35A70", Length = "0xC4")]
		private void DoSine()
		{
			float value = angle.Value;
			bool value2 = DegToRad.Value;
			FsmFloat fsmFloat = result;
			bool flag = !value2;
			float num = value * ((float)Math.PI / 180f);
			float value3 = (flag ? value : num);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2D20 (native sinf)");
			fsmFloat.Value = value3;
		}

		[Token(Token = "0x6001274")]
		[Address(RVA = "0xA35B38", Offset = "0xA35B38", Length = "0x8")]
		public GetSine()
		{
		}
	}
}
