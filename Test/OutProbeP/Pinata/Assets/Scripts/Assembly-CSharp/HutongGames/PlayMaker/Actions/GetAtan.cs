using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x760430", Offset = "0x760430")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x760430", Offset = "0x760430")]
	[Token(Token = "0x20003AD")]
	public class GetAtan : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CEDC0", Offset = "0x7CEDC0")]
		[Token(Token = "0x4001D46")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat Value;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CEE0C", Offset = "0x7CEE0C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CEE0C", Offset = "0x7CEE0C")]
		[Token(Token = "0x4001D47")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat angle;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CEE6C", Offset = "0x7CEE6C")]
		[Token(Token = "0x4001D48")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool RadToDeg;

		[Token(Token = "0x4001D49")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x6001257")]
		[Address(RVA = "0xB82C30", Offset = "0xB82C30", Length = "0x34")]
		public override void Reset()
		{
			Value = null;
			FsmBool radToDeg = true;
			angle = null;
			RadToDeg = radToDeg;
			everyFrame = false;
		}

		[Token(Token = "0x6001258")]
		[Address(RVA = "0xB82C64", Offset = "0xB82C64", Length = "0x3C")]
		public override void OnEnter()
		{
			DoATan();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001259")]
		[Address(RVA = "0xB82D64", Offset = "0xB82D64", Length = "0x4")]
		public override void OnUpdate()
		{
			DoATan();
		}

		[Token(Token = "0x600125A")]
		[Address(RVA = "0xB82CA0", Offset = "0xB82CA0", Length = "0xC4")]
		private void DoATan()
		{
			float value = Value.Value;
			Il2CppRuntime.Boundary("SYSTEM_API:atanf", "Method not found @6D2E90 (native atanf)");
			bool value2 = RadToDeg.Value;
			FsmFloat fsmFloat = angle;
			bool flag = !value2;
			float value3 = value * 57.29578f;
			if (flag)
			{
				value3 = value;
			}
			fsmFloat.Value = value3;
		}

		[Token(Token = "0x600125B")]
		[Address(RVA = "0xB82D68", Offset = "0xB82D68", Length = "0x8")]
		public GetAtan()
		{
		}
	}
}
