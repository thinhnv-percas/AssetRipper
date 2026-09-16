using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace HutongGames.PlayMaker.Actions
{
	[Token(Token = "0x20003BA")]
	public abstract class EventTriggerActionBase : ComponentAction<EventTrigger>
	{
		[Attribute(Type = typeof(DisplayOrderAttribute), RVA = "0x7CFC30", Offset = "0x7CFC30")]
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CFC30", Offset = "0x7CFC30")]
		[Token(Token = "0x4001D85")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(DisplayOrderAttribute), RVA = "0x7CFC90", Offset = "0x7CFC90")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CFC90", Offset = "0x7CFC90")]
		[Token(Token = "0x4001D86")]
		[FieldOffset(Offset = "0x68")]
		public FsmEventTarget eventTarget;

		[Token(Token = "0x4001D87")]
		[FieldOffset(Offset = "0x70")]
		protected EventTrigger trigger;

		[Token(Token = "0x4001D88")]
		[FieldOffset(Offset = "0x78")]
		protected EventTrigger.Entry entry;

		[Token(Token = "0x6001299")]
		[Address(RVA = "0xB74B08", Offset = "0xB74B08", Length = "0x2C")]
		public override void Reset()
		{
			gameObject = null;
			FsmEventTarget self = FsmEventTarget.Self;
			eventTarget = self;
		}

		[Token(Token = "0x600129A")]
		[Address(RVA = "0xB74B34", Offset = "0xB74B34", Length = "0x11C")]
		protected internal void Init(EventTriggerType eventTriggerType, UnityAction<BaseEventData> call)
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.EventTriggerActionBase)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCacheAddComponent(ownerDefaultTarget))
			{
				EventTrigger.Entry entry = this.entry;
				trigger = cachedComponent;
				if (this.entry == null)
				{
					entry = (this.entry = new EventTrigger.Entry());
				}
				entry.eventID = eventTriggerType;
				EventTrigger.Entry entry2 = this.entry;
				entry2.callback.AddListener(call);
				List<EventTrigger.Entry> triggers = trigger.triggers;
				triggers.Add(this.entry);
			}
		}

		[Token(Token = "0x600129B")]
		[Address(RVA = "0xB74C50", Offset = "0xB74C50", Length = "0x84")]
		public override void OnExit()
		{
			EventTrigger.Entry entry = this.entry;
			entry.callback.RemoveAllListeners();
			List<EventTrigger.Entry> triggers = trigger.triggers;
			bool flag = triggers.Remove(this.entry);
		}

		[Token(Token = "0x600129C")]
		[Address(RVA = "0xB74CD4", Offset = "0xB74CD4", Length = "0x50")]
		protected internal EventTriggerActionBase()
		{
		}
	}
}
