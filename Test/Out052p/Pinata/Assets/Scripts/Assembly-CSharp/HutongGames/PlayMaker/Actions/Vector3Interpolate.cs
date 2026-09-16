using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x763468", Offset = "0x763468")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x763468", Offset = "0x763468")]
	[Token(Token = "0x2000444")]
	public class Vector3Interpolate : FsmStateAction
	{
		[Token(Token = "0x4002011")]
		[FieldOffset(Offset = "0x4C")]
		public InterpolationType mode;

		[RequiredField]
		[Token(Token = "0x4002012")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector3 fromVector;

		[RequiredField]
		[Token(Token = "0x4002013")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 toVector;

		[RequiredField]
		[Token(Token = "0x4002014")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat time;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7DAD14", Offset = "0x7DAD14")]
		[Token(Token = "0x4002015")]
		[FieldOffset(Offset = "0x68")]
		public FsmVector3 storeResult;

		[Token(Token = "0x4002016")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent finishEvent;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7DAD50", Offset = "0x7DAD50")]
		[Token(Token = "0x4002017")]
		[FieldOffset(Offset = "0x78")]
		public bool realTime;

		[Token(Token = "0x4002018")]
		[FieldOffset(Offset = "0x7C")]
		private float startTime;

		[Token(Token = "0x4002019")]
		[FieldOffset(Offset = "0x80")]
		private float currentTime;

		[Token(Token = "0x600151F")]
		[Address(RVA = "0x988AB0", Offset = "0x988AB0", Length = "0xB8")]
		public override void Reset()
		{
			mode = default(InterpolationType);
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = true;
			fromVector = fsmVector;
			FsmVector3 fsmVector2 = new FsmVector3();
			fsmVector2.useVariable = true;
			toVector = fsmVector2;
			FsmFloat fsmFloat = 1f;
			realTime = false;
			storeResult = null;
			finishEvent = null;
			time = fsmFloat;
		}

		[Token(Token = "0x6001520")]
		[Address(RVA = "0x988B68", Offset = "0x988B68", Length = "0x64")]
		public override void OnEnter()
		{
			float realtimeSinceStartup = FsmTime.RealtimeSinceStartup;
			FsmVector3 fsmVector = storeResult;
			startTime = realtimeSinceStartup;
			currentTime = 0f;
			if (storeResult != null)
			{
				Vector3 vector = (fsmVector.value = fromVector.Value);
				fsmVector.value.y = vector.y;
				fsmVector.value.z = vector.z;
			}
			else
			{
				Finish();
			}
		}

		[Token(Token = "0x6001521")]
		[Address(RVA = "0x988BCC", Offset = "0x988BCC", Length = "0x1C8")]
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
			FsmVector3 fsmVector = storeResult;
			Vector3 value2 = fromVector.Value;
			Vector3 value3 = toVector.Value;
			Vector3 vector = (fsmVector.value = Vector3.Lerp(value2, value3, num2));
			fsmVector.value.y = vector.y;
			fsmVector.value.z = vector.z;
			if (!(num2 < 1f))
			{
				if (finishEvent != null)
				{
					Fsm.Event(finishEvent);
				}
				Finish();
			}
		}

		[Token(Token = "0x6001522")]
		[Address(RVA = "0x988D94", Offset = "0x988D94", Length = "0x8")]
		public Vector3Interpolate()
		{
		}
	}
}
