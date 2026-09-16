using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75FC3C", Offset = "0x75FC3C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75FC3C", Offset = "0x75FC3C")]
	[Token(Token = "0x2000394")]
	public class RandomWait : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CD1F4", Offset = "0x7CD1F4")]
		[Token(Token = "0x4001C94")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat min;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CD240", Offset = "0x7CD240")]
		[Token(Token = "0x4001C95")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat max;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CD28C", Offset = "0x7CD28C")]
		[Token(Token = "0x4001C96")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent finishEvent;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CD2C4", Offset = "0x7CD2C4")]
		[Token(Token = "0x4001C97")]
		[FieldOffset(Offset = "0x68")]
		public bool realTime;

		[Token(Token = "0x4001C98")]
		[FieldOffset(Offset = "0x6C")]
		private float startTime;

		[Token(Token = "0x4001C99")]
		[FieldOffset(Offset = "0x70")]
		private float timer;

		[Token(Token = "0x4001C9A")]
		[FieldOffset(Offset = "0x74")]
		private float time;

		[Token(Token = "0x60011CA")]
		[Address(RVA = "0xB1CFD8", Offset = "0xB1CFD8", Length = "0x40")]
		public override void Reset()
		{
			FsmFloat fsmFloat = 0f;
			min = fsmFloat;
			FsmFloat fsmFloat2 = 1f;
			max = fsmFloat2;
			finishEvent = null;
			realTime = false;
		}

		[Token(Token = "0x60011CB")]
		[Address(RVA = "0xB1D018", Offset = "0xB1D018", Length = "0xA4")]
		public override void OnEnter()
		{
			float value = min.Value;
			float value2 = max.Value;
			float num = Random.Range(value, value2);
			bool flag = num < 0f;
			bool flag2 = !flag;
			bool flag3 = num == 0f;
			time = num;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				float realtimeSinceStartup = FsmTime.RealtimeSinceStartup;
				startTime = realtimeSinceStartup;
				timer = 0f;
			}
			else
			{
				Fsm.Event(finishEvent);
				Finish();
			}
		}

		[Token(Token = "0x60011CC")]
		[Address(RVA = "0xB1D0BC", Offset = "0xB1D0BC", Length = "0x94")]
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
				num = timer + deltaTime;
			}
			timer = num;
			if (!(num < time))
			{
				Finish();
				if (finishEvent != null)
				{
					Fsm.Event(finishEvent);
				}
			}
		}

		[Token(Token = "0x60011CD")]
		[Address(RVA = "0xB1D150", Offset = "0xB1D150", Length = "0x8")]
		public RandomWait()
		{
		}
	}
}
