using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x763198", Offset = "0x763198")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x763198", Offset = "0x763198")]
	[Token(Token = "0x200043B")]
	public class GetVector3XYZ : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7DA96C", Offset = "0x7DA96C")]
		[Token(Token = "0x4001FEE")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector3 vector3Variable;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7DA9A8", Offset = "0x7DA9A8")]
		[Token(Token = "0x4001FEF")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat storeX;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7DA9BC", Offset = "0x7DA9BC")]
		[Token(Token = "0x4001FF0")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat storeY;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7DA9D0", Offset = "0x7DA9D0")]
		[Token(Token = "0x4001FF1")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat storeZ;

		[Token(Token = "0x4001FF2")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x60014F6")]
		[Address(RVA = "0xA3732C", Offset = "0xA3732C", Length = "0x10")]
		public override void Reset()
		{
			everyFrame = false;
			vector3Variable = null;
			storeY = null;
		}

		[Token(Token = "0x60014F7")]
		[Address(RVA = "0xA3733C", Offset = "0xA3733C", Length = "0x3C")]
		public override void OnEnter()
		{
			DoGetVector3XYZ();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60014F8")]
		[Address(RVA = "0xA373EC", Offset = "0xA373EC", Length = "0x4")]
		public override void OnUpdate()
		{
			DoGetVector3XYZ();
		}

		[Token(Token = "0x60014F9")]
		[Address(RVA = "0xA37378", Offset = "0xA37378", Length = "0x74")]
		private void DoGetVector3XYZ()
		{
			if (vector3Variable != null)
			{
				FsmFloat fsmFloat = storeX;
				if (storeX != null)
				{
					fsmFloat.Value = vector3Variable.Value.x;
				}
				FsmFloat fsmFloat2 = storeY;
				if (storeY != null)
				{
					fsmFloat2.Value = vector3Variable.Value.y;
				}
				FsmFloat fsmFloat3 = storeZ;
				if (storeZ != null)
				{
					fsmFloat3.Value = vector3Variable.Value.z;
				}
			}
		}

		[Token(Token = "0x60014FA")]
		[Address(RVA = "0xA373F0", Offset = "0xA373F0", Length = "0x8")]
		public GetVector3XYZ()
		{
		}
	}
}
