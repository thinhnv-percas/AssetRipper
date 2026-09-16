using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x763508", Offset = "0x763508")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x763508", Offset = "0x763508")]
	[Token(Token = "0x2000446")]
	public class Vector3Lerp : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7DADC4", Offset = "0x7DADC4")]
		[Token(Token = "0x400201C")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector3 fromVector;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7DAE10", Offset = "0x7DAE10")]
		[Token(Token = "0x400201D")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 toVector;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7DAE5C", Offset = "0x7DAE5C")]
		[Token(Token = "0x400201E")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat amount;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7DAEA8", Offset = "0x7DAEA8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7DAEA8", Offset = "0x7DAEA8")]
		[Token(Token = "0x400201F")]
		[FieldOffset(Offset = "0x68")]
		public FsmVector3 storeResult;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7DAF08", Offset = "0x7DAF08")]
		[Token(Token = "0x4002020")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x6001527")]
		[Address(RVA = "0x988F44", Offset = "0x988F44", Length = "0xA4")]
		public override void Reset()
		{
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = true;
			fromVector = fsmVector;
			FsmVector3 fsmVector2 = new FsmVector3();
			fsmVector2.useVariable = true;
			toVector = fsmVector2;
			storeResult = null;
			everyFrame = true;
		}

		[Token(Token = "0x6001528")]
		[Address(RVA = "0x988FE8", Offset = "0x988FE8", Length = "0x3C")]
		public override void OnEnter()
		{
			DoVector3Lerp();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001529")]
		[Address(RVA = "0x989130", Offset = "0x989130", Length = "0x4")]
		public override void OnUpdate()
		{
			DoVector3Lerp();
		}

		[Token(Token = "0x600152A")]
		[Address(RVA = "0x989024", Offset = "0x989024", Length = "0x10C")]
		private void DoVector3Lerp()
		{
			FsmVector3 fsmVector = storeResult;
			Vector3 value = fromVector.Value;
			Vector3 value2 = toVector.Value;
			float value3 = amount.Value;
			Vector3 vector = (fsmVector.value = Vector3.Lerp(value, value2, value3));
			fsmVector.value.y = vector.y;
			fsmVector.value.z = vector.z;
		}

		[Token(Token = "0x600152B")]
		[Address(RVA = "0x989134", Offset = "0x989134", Length = "0x8")]
		public Vector3Lerp()
		{
		}
	}
}
