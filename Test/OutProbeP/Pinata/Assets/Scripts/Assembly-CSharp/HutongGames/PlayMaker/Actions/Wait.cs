using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75FCDC", Offset = "0x75FCDC")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75FCDC", Offset = "0x75FCDC")]
	[Token(Token = "0x2000396")]
	public class Wait : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x4001C9E")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat time;

		[Token(Token = "0x4001C9F")]
		[FieldOffset(Offset = "0x58")]
		public FsmEvent finishEvent;

		[Token(Token = "0x4001CA0")]
		[FieldOffset(Offset = "0x60")]
		public bool realTime;

		[Token(Token = "0x4001CA1")]
		[FieldOffset(Offset = "0x64")]
		private float startTime;

		[Token(Token = "0x4001CA2")]
		[FieldOffset(Offset = "0x68")]
		private float timer;

		[Token(Token = "0x60011D3")]
		[Address(RVA = "0x98A134", Offset = "0x98A134", Length = "0x30")]
		public override void Reset()
		{
			FsmFloat fsmFloat = 1f;
			time = fsmFloat;
			finishEvent = null;
			realTime = false;
		}

		[Token(Token = "0x60011D4")]
		[Address(RVA = "0x98A164", Offset = "0x98A164", Length = "0x70")]
		public override void OnEnter()
		{
			float value = time.Value;
			bool flag = value < 0f;
			bool flag2 = !flag;
			bool flag3 = value == 0f;
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

		[Token(Token = "0x60011D5")]
		[Address(RVA = "0x98A1D4", Offset = "0x98A1D4", Length = "0xA0")]
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
			float value = time.Value;
			if (!(num < value))
			{
				Finish();
				if (finishEvent != null)
				{
					Fsm.Event(finishEvent);
				}
			}
		}

		[Token(Token = "0x60011D6")]
		[Address(RVA = "0x98A274", Offset = "0x98A274", Length = "0x8")]
		public Wait()
		{
		}
	}
}
