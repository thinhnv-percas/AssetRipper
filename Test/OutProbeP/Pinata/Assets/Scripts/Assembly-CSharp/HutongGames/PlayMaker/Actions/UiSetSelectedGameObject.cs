using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x760F70", Offset = "0x760F70")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x760F70", Offset = "0x760F70")]
	[Token(Token = "0x20003D2")]
	public class UiSetSelectedGameObject : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D0FA8", Offset = "0x7D0FA8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D0FA8", Offset = "0x7D0FA8")]
		[Token(Token = "0x4001DCB")]
		[FieldOffset(Offset = "0x50")]
		public FsmGameObject gameObject;

		[Token(Token = "0x60012FB")]
		[Address(RVA = "0x98309C", Offset = "0x98309C", Length = "0x8")]
		public override void Reset()
		{
			gameObject = null;
		}

		[Token(Token = "0x60012FC")]
		[Address(RVA = "0x9830A4", Offset = "0x9830A4", Length = "0x28")]
		public override void OnEnter()
		{
			DoSetSelectedGameObject();
			Finish();
		}

		[Token(Token = "0x60012FD")]
		[Address(RVA = "0x9830CC", Offset = "0x9830CC", Length = "0x98")]
		private void DoSetSelectedGameObject()
		{
			EventSystem current = EventSystem.current;
			GameObject value = gameObject.Value;
			current.SetSelectedGameObject(value);
		}

		[Token(Token = "0x60012FE")]
		[Address(RVA = "0x983164", Offset = "0x983164", Length = "0x8")]
		public UiSetSelectedGameObject()
		{
		}
	}
}
