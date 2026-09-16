using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x762BA8", Offset = "0x762BA8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x762BA8", Offset = "0x762BA8")]
	[Token(Token = "0x2000428")]
	public class GetVector2XY : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D9598", Offset = "0x7D9598")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D9598", Offset = "0x7D9598")]
		[Token(Token = "0x4001FA3")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector2 vector2Variable;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D95F8", Offset = "0x7D95F8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D95F8", Offset = "0x7D95F8")]
		[Token(Token = "0x4001FA4")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat storeX;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D9648", Offset = "0x7D9648")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D9648", Offset = "0x7D9648")]
		[Token(Token = "0x4001FA5")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat storeY;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D9698", Offset = "0x7D9698")]
		[Token(Token = "0x4001FA6")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x60014A3")]
		[Address(RVA = "0xA37290", Offset = "0xA37290", Length = "0x10")]
		public override void Reset()
		{
			everyFrame = false;
			storeX = null;
			storeY = null;
			vector2Variable = null;
		}

		[Token(Token = "0x60014A4")]
		[Address(RVA = "0xA372A0", Offset = "0xA372A0", Length = "0x3C")]
		public override void OnEnter()
		{
			DoGetVector2XYZ();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60014A5")]
		[Address(RVA = "0xA37320", Offset = "0xA37320", Length = "0x4")]
		public override void OnUpdate()
		{
			DoGetVector2XYZ();
		}

		[Token(Token = "0x60014A6")]
		[Address(RVA = "0xA372DC", Offset = "0xA372DC", Length = "0x44")]
		private void DoGetVector2XYZ()
		{
			FsmVector2 fsmVector = vector2Variable;
			if (vector2Variable != null)
			{
				FsmFloat fsmFloat = storeX;
				if (storeX != null)
				{
					fsmFloat.Value = fsmVector.value.x;
				}
				FsmFloat fsmFloat2 = storeY;
				if (storeY != null)
				{
					FsmVector2 fsmVector2 = vector2Variable;
					fsmFloat2.Value = fsmVector2.value.y;
				}
			}
		}

		[Token(Token = "0x60014A7")]
		[Address(RVA = "0xA37324", Offset = "0xA37324", Length = "0x8")]
		public GetVector2XY()
		{
		}
	}
}
