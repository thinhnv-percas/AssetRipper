using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7604D0", Offset = "0x7604D0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7604D0", Offset = "0x7604D0")]
	[Token(Token = "0x20003AF")]
	public class GetAtan2FromVector2 : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CF00C", Offset = "0x7CF00C")]
		[Token(Token = "0x4001D4F")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector2 vector2;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CF058", Offset = "0x7CF058")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CF058", Offset = "0x7CF058")]
		[Token(Token = "0x4001D50")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat angle;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CF0B8", Offset = "0x7CF0B8")]
		[Token(Token = "0x4001D51")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool RadToDeg;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CF0F0", Offset = "0x7CF0F0")]
		[Token(Token = "0x4001D52")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x6001261")]
		[Address(RVA = "0xB82EC8", Offset = "0xB82EC8", Length = "0x34")]
		public override void Reset()
		{
			vector2 = null;
			FsmBool radToDeg = true;
			angle = null;
			RadToDeg = radToDeg;
			everyFrame = false;
		}

		[Token(Token = "0x6001262")]
		[Address(RVA = "0xB82EFC", Offset = "0xB82EFC", Length = "0x3C")]
		public override void OnEnter()
		{
			DoATan();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001263")]
		[Address(RVA = "0xB82FF4", Offset = "0xB82FF4", Length = "0x4")]
		public override void OnUpdate()
		{
			DoATan();
		}

		[Token(Token = "0x6001264")]
		[Address(RVA = "0xB82F38", Offset = "0xB82F38", Length = "0xBC")]
		private void DoATan()
		{
			FsmVector2 fsmVector = vector2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D29A0 (native atan2f)");
			bool value = RadToDeg.Value;
			FsmFloat fsmFloat = angle;
			bool flag = !value;
			float value2 = fsmVector.value.y * 57.29578f;
			if (flag)
			{
				value2 = fsmVector.value.y;
			}
			fsmFloat.Value = value2;
		}

		[Token(Token = "0x6001265")]
		[Address(RVA = "0xB82FF8", Offset = "0xB82FF8", Length = "0x8")]
		public GetAtan2FromVector2()
		{
		}
	}
}
