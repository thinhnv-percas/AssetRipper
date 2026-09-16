using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x760480", Offset = "0x760480")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x760480", Offset = "0x760480")]
	[Token(Token = "0x20003AE")]
	public class GetAtan2 : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CEEA4", Offset = "0x7CEEA4")]
		[Token(Token = "0x4001D4A")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat xValue;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CEEF0", Offset = "0x7CEEF0")]
		[Token(Token = "0x4001D4B")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat yValue;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CEF3C", Offset = "0x7CEF3C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CEF3C", Offset = "0x7CEF3C")]
		[Token(Token = "0x4001D4C")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat angle;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CEF9C", Offset = "0x7CEF9C")]
		[Token(Token = "0x4001D4D")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool RadToDeg;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CEFD4", Offset = "0x7CEFD4")]
		[Token(Token = "0x4001D4E")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x600125C")]
		[Address(RVA = "0xB82D70", Offset = "0xB82D70", Length = "0x34")]
		public override void Reset()
		{
			xValue = null;
			yValue = null;
			FsmBool radToDeg = true;
			angle = null;
			RadToDeg = radToDeg;
			everyFrame = false;
		}

		[Token(Token = "0x600125D")]
		[Address(RVA = "0xB82DA4", Offset = "0xB82DA4", Length = "0x3C")]
		public override void OnEnter()
		{
			DoATan();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x600125E")]
		[Address(RVA = "0xB82EBC", Offset = "0xB82EBC", Length = "0x4")]
		public override void OnUpdate()
		{
			DoATan();
		}

		[Token(Token = "0x600125F")]
		[Address(RVA = "0xB82DE0", Offset = "0xB82DE0", Length = "0xDC")]
		private void DoATan()
		{
			float value = yValue.Value;
			float value2 = xValue.Value;
			Il2CppRuntime.Boundary("SYSTEM_API:atan2f", "Method not found @6D29A0 (native atan2f)");
			bool value3 = RadToDeg.Value;
			FsmFloat fsmFloat = angle;
			bool flag = !value3;
			float value4 = value * 57.29578f;
			if (flag)
			{
				value4 = value;
			}
			fsmFloat.Value = value4;
		}

		[Token(Token = "0x6001260")]
		[Address(RVA = "0xB82EC0", Offset = "0xB82EC0", Length = "0x8")]
		public GetAtan2()
		{
		}
	}
}
