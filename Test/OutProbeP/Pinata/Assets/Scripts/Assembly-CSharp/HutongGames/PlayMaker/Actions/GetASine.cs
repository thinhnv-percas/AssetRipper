using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7603E0", Offset = "0x7603E0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7603E0", Offset = "0x7603E0")]
	[Token(Token = "0x20003AC")]
	public class GetASine : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CECA4", Offset = "0x7CECA4")]
		[Token(Token = "0x4001D42")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat Value;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CECF0", Offset = "0x7CECF0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CECF0", Offset = "0x7CECF0")]
		[Token(Token = "0x4001D43")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat angle;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CED50", Offset = "0x7CED50")]
		[Token(Token = "0x4001D44")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool RadToDeg;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CED88", Offset = "0x7CED88")]
		[Token(Token = "0x4001D45")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x6001252")]
		[Address(RVA = "0xB7D658", Offset = "0xB7D658", Length = "0x38")]
		public override void Reset()
		{
			angle = null;
			FsmBool radToDeg = true;
			RadToDeg = radToDeg;
			everyFrame = false;
			Value = null;
		}

		[Token(Token = "0x6001253")]
		[Address(RVA = "0xB7D690", Offset = "0xB7D690", Length = "0x3C")]
		public override void OnEnter()
		{
			DoASine();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001254")]
		[Address(RVA = "0xB7D790", Offset = "0xB7D790", Length = "0x4")]
		public override void OnUpdate()
		{
			DoASine();
		}

		[Token(Token = "0x6001255")]
		[Address(RVA = "0xB7D6CC", Offset = "0xB7D6CC", Length = "0xC4")]
		private void DoASine()
		{
			float value = Value.Value;
			Il2CppRuntime.Boundary("SYSTEM_API:asinf", "Method not found @6D2B00 (native asinf)");
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

		[Token(Token = "0x6001256")]
		[Address(RVA = "0xB7D794", Offset = "0xB7D794", Length = "0x8")]
		public GetASine()
		{
		}
	}
}
