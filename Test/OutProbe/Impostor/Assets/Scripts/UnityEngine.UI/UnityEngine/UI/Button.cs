using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace UnityEngine.UI
{
	[AddComponentMenu("UI/Button", 30)]
	[Token(Token = "0x2000005")]
	public class Button : Selectable, IPointerClickHandler, IEventSystemHandler, ISubmitHandler
	{
		[Serializable]
		[Token(Token = "0x2000006")]
		public class ButtonClickedEvent : UnityEvent
		{
			[Token(Token = "0x6000015")]
			[Address(RVA = "0x16C1034", Offset = "0x16C1034", Length = "0x8")]
			public ButtonClickedEvent()
			{
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000007")]
		private sealed class _003COnFinishSubmit_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000011")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x4000012")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000013")]
			[FieldOffset(Offset = "0x20")]
			public Button _003C_003E4__this;

			[Token(Token = "0x4000014")]
			[FieldOffset(Offset = "0x28")]
			private float _003CfadeTime_003E5__2;

			[Token(Token = "0x4000015")]
			[FieldOffset(Offset = "0x2C")]
			private float _003CelapsedTime_003E5__3;

			[Token(Token = "0x17000007")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000019")]
				[Address(RVA = "0x16C1300", Offset = "0x16C1300", Length = "0x8")]
				get
				{
					return null;
				}
			}

			[Token(Token = "0x17000008")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600001B")]
				[Address(RVA = "0x16C1340", Offset = "0x16C1340", Length = "0x8")]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000016")]
			[Address(RVA = "0x16C11E0", Offset = "0x16C11E0", Length = "0x28")]
			public _003COnFinishSubmit_003Ed__9(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			[Token(Token = "0x6000017")]
			[Address(RVA = "0x16C1208", Offset = "0x16C1208", Length = "0x4")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000018")]
			[Address(RVA = "0x16C120C", Offset = "0x16C120C", Length = "0xF4")]
			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600001A")]
			[Address(RVA = "0x16C1308", Offset = "0x16C1308", Length = "0x38")]
			void IEnumerator.Reset()
			{
			}
		}

		[FormerlySerializedAs("onClick")]
		[SerializeField]
		[Token(Token = "0x4000010")]
		[FieldOffset(Offset = "0x100")]
		private ButtonClickedEvent m_OnClick;

		[Token(Token = "0x17000006")]
		public ButtonClickedEvent onClick
		{
			[Token(Token = "0x600000F")]
			[Address(RVA = "0x16C103C", Offset = "0x16C103C", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000010")]
			[Address(RVA = "0x16C1044", Offset = "0x16C1044", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0x16C0FA8", Offset = "0x16C0FA8", Length = "0x8C")]
		protected Button()
		{
		}

		[Token(Token = "0x6000011")]
		[Address(RVA = "0x16C104C", Offset = "0x16C104C", Length = "0x98")]
		private void Press()
		{
		}

		[Token(Token = "0x6000012")]
		[Address(RVA = "0x16C10E4", Offset = "0x16C10E4", Length = "0x24")]
		public virtual void OnPointerClick(PointerEventData eventData)
		{
		}

		[Token(Token = "0x6000013")]
		[Address(RVA = "0x16C1108", Offset = "0x16C1108", Length = "0x78")]
		public virtual void OnSubmit(BaseEventData eventData)
		{
		}

		[IteratorStateMachine(typeof(_003COnFinishSubmit_003Ed__9))]
		[Token(Token = "0x6000014")]
		[Address(RVA = "0x16C1180", Offset = "0x16C1180", Length = "0x60")]
		private IEnumerator OnFinishSubmit()
		{
			return null;
		}
	}
}
