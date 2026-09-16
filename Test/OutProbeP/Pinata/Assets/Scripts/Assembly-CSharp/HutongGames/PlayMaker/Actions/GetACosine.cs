using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x760390", Offset = "0x760390")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x760390", Offset = "0x760390")]
	[Token(Token = "0x20003AB")]
	public class GetACosine : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CEB88", Offset = "0x7CEB88")]
		[Token(Token = "0x4001D3E")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat Value;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CEBD4", Offset = "0x7CEBD4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CEBD4", Offset = "0x7CEBD4")]
		[Token(Token = "0x4001D3F")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat angle;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CEC34", Offset = "0x7CEC34")]
		[Token(Token = "0x4001D40")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool RadToDeg;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CEC6C", Offset = "0x7CEC6C")]
		[Token(Token = "0x4001D41")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x600124D")]
		[Address(RVA = "0xB7D514", Offset = "0xB7D514", Length = "0x38")]
		public override void Reset()
		{
			angle = null;
			FsmBool radToDeg = true;
			RadToDeg = radToDeg;
			everyFrame = false;
			Value = null;
		}

		[Token(Token = "0x600124E")]
		[Address(RVA = "0xB7D54C", Offset = "0xB7D54C", Length = "0x3C")]
		public override void OnEnter()
		{
			DoACosine();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x600124F")]
		[Address(RVA = "0xB7D64C", Offset = "0xB7D64C", Length = "0x4")]
		public override void OnUpdate()
		{
			DoACosine();
		}

		[Token(Token = "0x6001250")]
		[Address(RVA = "0xB7D588", Offset = "0xB7D588", Length = "0xC4")]
		private void DoACosine()
		{
			float value = Value.Value;
			Il2CppRuntime.Boundary("SYSTEM_API:acosf", "Method not found @6D2AB0 (native acosf)");
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

		[Token(Token = "0x6001251")]
		[Address(RVA = "0xB7D650", Offset = "0xB7D650", Length = "0x8")]
		public GetACosine()
		{
		}
	}
}
