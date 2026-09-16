using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x762B58", Offset = "0x762B58")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x762B58", Offset = "0x762B58")]
	[Token(Token = "0x2000427")]
	public class GetVector2Length : FsmStateAction
	{
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D94C8", Offset = "0x7D94C8")]
		[Token(Token = "0x4001FA0")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector2 vector2;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D9500", Offset = "0x7D9500")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D9500", Offset = "0x7D9500")]
		[Token(Token = "0x4001FA1")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat storeLength;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D9560", Offset = "0x7D9560")]
		[Token(Token = "0x4001FA2")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x600149E")]
		[Address(RVA = "0xA371F8", Offset = "0xA371F8", Length = "0xC")]
		public override void Reset()
		{
			everyFrame = false;
			vector2 = null;
			storeLength = null;
		}

		[Token(Token = "0x600149F")]
		[Address(RVA = "0xA37204", Offset = "0xA37204", Length = "0x3C")]
		public override void OnEnter()
		{
			DoVectorLength();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60014A0")]
		[Address(RVA = "0xA37284", Offset = "0xA37284", Length = "0x4")]
		public override void OnUpdate()
		{
			DoVectorLength();
		}

		[Token(Token = "0x60014A1")]
		[Address(RVA = "0xA37240", Offset = "0xA37240", Length = "0x44")]
		private void DoVectorLength()
		{
			FsmVector2 fsmVector = vector2;
			if (vector2 != null)
			{
				FsmFloat fsmFloat = storeLength;
				if (storeLength != null)
				{
					Vector2 value = fsmVector.value;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1588E30 (inside UnityEngine.Vector2::Scale +0xC8)");
					float value2 = default(float);
					fsmFloat.Value = value2;
				}
			}
		}

		[Token(Token = "0x60014A2")]
		[Address(RVA = "0xA37288", Offset = "0xA37288", Length = "0x8")]
		public GetVector2Length()
		{
		}
	}
}
