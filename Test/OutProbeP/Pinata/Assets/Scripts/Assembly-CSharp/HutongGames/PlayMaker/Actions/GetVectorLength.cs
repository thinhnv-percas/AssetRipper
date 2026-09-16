using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7631E8", Offset = "0x7631E8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7631E8", Offset = "0x7631E8")]
	[Token(Token = "0x200043C")]
	public class GetVectorLength : FsmStateAction
	{
		[Token(Token = "0x4001FF3")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector3 vector3;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7DA9E4", Offset = "0x7DA9E4")]
		[Token(Token = "0x4001FF4")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat storeLength;

		[Token(Token = "0x60014FB")]
		[Address(RVA = "0xA373F8", Offset = "0xA373F8", Length = "0x8")]
		public override void Reset()
		{
			vector3 = null;
			storeLength = null;
		}

		[Token(Token = "0x60014FC")]
		[Address(RVA = "0xA37400", Offset = "0xA37400", Length = "0x28")]
		public override void OnEnter()
		{
			DoVectorLength();
			Finish();
		}

		[Token(Token = "0x60014FD")]
		[Address(RVA = "0xA37428", Offset = "0xA37428", Length = "0x5C")]
		private void DoVectorLength()
		{
			if (vector3 != null)
			{
				FsmFloat fsmFloat = storeLength;
				if (storeLength != null)
				{
					Vector3 value = vector3.Value;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158AD58 (inside UnityEngine.Vector3::ClampMagnitude +0xDC)");
					fsmFloat.Value = value.x;
				}
			}
		}

		[Token(Token = "0x60014FE")]
		[Address(RVA = "0xA37484", Offset = "0xA37484", Length = "0x8")]
		public GetVectorLength()
		{
		}
	}
}
