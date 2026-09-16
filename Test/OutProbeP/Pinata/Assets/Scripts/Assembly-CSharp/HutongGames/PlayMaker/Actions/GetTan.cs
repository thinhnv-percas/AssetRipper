using System;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x760610", Offset = "0x760610")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x760610", Offset = "0x760610")]
	[Token(Token = "0x20003B3")]
	public class GetTan : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CF514", Offset = "0x7CF514")]
		[Token(Token = "0x4001D61")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat angle;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CF560", Offset = "0x7CF560")]
		[Token(Token = "0x4001D62")]
		[FieldOffset(Offset = "0x58")]
		public FsmBool DegToRad;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CF598", Offset = "0x7CF598")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CF598", Offset = "0x7CF598")]
		[Token(Token = "0x4001D63")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat result;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CF5F8", Offset = "0x7CF5F8")]
		[Token(Token = "0x4001D64")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x6001275")]
		[Address(RVA = "0xA366B4", Offset = "0xA366B4", Length = "0x34")]
		public override void Reset()
		{
			angle = null;
			FsmBool degToRad = true;
			everyFrame = false;
			DegToRad = degToRad;
			result = null;
		}

		[Token(Token = "0x6001276")]
		[Address(RVA = "0xA366E8", Offset = "0xA366E8", Length = "0x3C")]
		public override void OnEnter()
		{
			DoTan();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001277")]
		[Address(RVA = "0xA367E8", Offset = "0xA367E8", Length = "0x4")]
		public override void OnUpdate()
		{
			DoTan();
		}

		[Token(Token = "0x6001278")]
		[Address(RVA = "0xA36724", Offset = "0xA36724", Length = "0xC4")]
		private void DoTan()
		{
			float value = angle.Value;
			bool value2 = DegToRad.Value;
			FsmFloat fsmFloat = result;
			bool flag = !value2;
			float num = value * ((float)Math.PI / 180f);
			float value3 = (flag ? value : num);
			Il2CppRuntime.Boundary("SYSTEM_API:tanf", "Method not found @6D25B0 (native tanf)");
			fsmFloat.Value = value3;
		}

		[Token(Token = "0x6001279")]
		[Address(RVA = "0xA367EC", Offset = "0xA367EC", Length = "0x8")]
		public GetTan()
		{
		}
	}
}
