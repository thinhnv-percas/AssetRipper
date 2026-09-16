using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x761420", Offset = "0x761420")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x761420", Offset = "0x761420")]
	[Token(Token = "0x20003E1")]
	public class UiButtonOnClickEvent : ComponentAction<Button>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D2C98", Offset = "0x7D2C98")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D2C98", Offset = "0x7D2C98")]
		[Token(Token = "0x4001E40")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D2D30", Offset = "0x7D2D30")]
		[Token(Token = "0x4001E41")]
		[FieldOffset(Offset = "0x68")]
		public FsmEventTarget eventTarget;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D2D68", Offset = "0x7D2D68")]
		[Token(Token = "0x4001E42")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent sendEvent;

		[Token(Token = "0x4001E43")]
		[FieldOffset(Offset = "0x78")]
		private Button button;

		[Token(Token = "0x6001345")]
		[Address(RVA = "0x9A2DA4", Offset = "0x9A2DA4", Length = "0xC")]
		public override void Reset()
		{
			gameObject = null;
			sendEvent = null;
		}

		[Token(Token = "0x6001346")]
		[Address(RVA = "0x9A2DB0", Offset = "0x9A2DB0", Length = "0x1EC")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiButtonOnClickEvent)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			string text3;
			if (UpdateCache(ownerDefaultTarget))
			{
				if (this.button != null)
				{
					Button button = this.button;
					UnityAction call = DoOnClick;
					button.onClick.RemoveListener(call);
				}
				this.button = cachedComponent;
				if (cachedComponent != null)
				{
					Button button2 = this.button;
					UnityAction call2 = DoOnClick;
					button2.onClick.AddListener(call2);
					return;
				}
				string text = ownerDefaultTarget.name;
				string text2 = "Missing UI.Button on " + text;
				text3 = text2;
			}
			else
			{
				text3 = "Missing GameObject ";
			}
			LogError(text3);
		}

		[Token(Token = "0x6001347")]
		[Address(RVA = "0x9A2F9C", Offset = "0x9A2F9C", Length = "0xE0")]
		public override void OnExit()
		{
			if (this.button != null)
			{
				Button button = this.button;
				UnityAction call = DoOnClick;
				button.onClick.RemoveListener(call);
			}
		}

		[Token(Token = "0x6001348")]
		[Address(RVA = "0x9A307C", Offset = "0x9A307C", Length = "0x54")]
		public void DoOnClick()
		{
			SendEvent(eventTarget, sendEvent);
		}

		[Token(Token = "0x6001349")]
		[Address(RVA = "0x9A30D0", Offset = "0x9A30D0", Length = "0x50")]
		public UiButtonOnClickEvent()
		{
		}
	}
}
