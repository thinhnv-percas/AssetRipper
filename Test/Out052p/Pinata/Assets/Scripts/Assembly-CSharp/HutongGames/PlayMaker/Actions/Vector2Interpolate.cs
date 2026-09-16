using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x762E28", Offset = "0x762E28")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x762E28", Offset = "0x762E28")]
	[Token(Token = "0x2000430")]
	public class Vector2Interpolate : FsmStateAction
	{
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D9DEC", Offset = "0x7D9DEC")]
		[Token(Token = "0x4001FC1")]
		[FieldOffset(Offset = "0x4C")]
		public InterpolationType mode;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D9E24", Offset = "0x7D9E24")]
		[Token(Token = "0x4001FC2")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector2 fromVector;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D9E70", Offset = "0x7D9E70")]
		[Token(Token = "0x4001FC3")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector2 toVector;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D9EBC", Offset = "0x7D9EBC")]
		[Token(Token = "0x4001FC4")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat time;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D9F08", Offset = "0x7D9F08")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D9F08", Offset = "0x7D9F08")]
		[Token(Token = "0x4001FC5")]
		[FieldOffset(Offset = "0x68")]
		public FsmVector2 storeResult;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D9F68", Offset = "0x7D9F68")]
		[Token(Token = "0x4001FC6")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent finishEvent;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D9FA0", Offset = "0x7D9FA0")]
		[Token(Token = "0x4001FC7")]
		[FieldOffset(Offset = "0x78")]
		public bool realTime;

		[Token(Token = "0x4001FC8")]
		[FieldOffset(Offset = "0x7C")]
		private float startTime;

		[Token(Token = "0x4001FC9")]
		[FieldOffset(Offset = "0x80")]
		private float currentTime;

		[Token(Token = "0x60014C8")]
		[Address(RVA = "0x986E08", Offset = "0x986E08", Length = "0xB8")]
		public override void Reset()
		{
			mode = default(InterpolationType);
			FsmVector2 fsmVector = new FsmVector2();
			fsmVector.useVariable = true;
			fromVector = fsmVector;
			FsmVector2 fsmVector2 = new FsmVector2();
			fsmVector2.useVariable = true;
			toVector = fsmVector2;
			FsmFloat fsmFloat = 1f;
			realTime = false;
			storeResult = null;
			finishEvent = null;
			time = fsmFloat;
		}

		[Token(Token = "0x60014C9")]
		[Address(RVA = "0x986EC0", Offset = "0x986EC0", Length = "0x60")]
		public override void OnEnter()
		{
			float realtimeSinceStartup = FsmTime.RealtimeSinceStartup;
			FsmVector2 fsmVector = storeResult;
			startTime = realtimeSinceStartup;
			currentTime = 0f;
			if (storeResult != null)
			{
				FsmVector2 fsmVector2 = fromVector;
				fsmVector.value = fsmVector2.value;
				fsmVector.value.y = fsmVector2.value.y;
			}
			else
			{
				Finish();
			}
		}

		[Token(Token = "0x60014CA")]
		[Address(RVA = "0x986F20", Offset = "0x986F20", Length = "0x190")]
		public override void OnUpdate()
		{
			float num;
			if (realTime)
			{
				float realtimeSinceStartup = FsmTime.RealtimeSinceStartup;
				num = realtimeSinceStartup - startTime;
			}
			else
			{
				float deltaTime = Time.deltaTime;
				num = currentTime + deltaTime;
			}
			currentTime = num;
			float value = time.Value;
			float num2 = num / value;
			if (mode == InterpolationType.EaseInOut)
			{
				float num3 = Mathf.SmoothStep(0f, 1f, num2);
				num2 = num3;
			}
			FsmVector2 fsmVector = fromVector;
			FsmVector2 fsmVector2 = toVector;
			FsmVector2 fsmVector3 = storeResult;
			Vector2 a = default(Vector2);
			a.x = fsmVector.value.x;
			a.y = fsmVector.value.y;
			Vector2 b = default(Vector2);
			b.x = fsmVector2.value.x;
			b.y = fsmVector2.value.y;
			Vector2 vector = (fsmVector3.value = Vector2.Lerp(a, b, num2));
			fsmVector3.value.y = vector.y;
			if (!(num2 < 1f))
			{
				if (finishEvent != null)
				{
					Fsm.Event(finishEvent);
				}
				Finish();
			}
		}

		[Token(Token = "0x60014CB")]
		[Address(RVA = "0x9870B0", Offset = "0x9870B0", Length = "0x8")]
		public Vector2Interpolate()
		{
		}
	}
}
