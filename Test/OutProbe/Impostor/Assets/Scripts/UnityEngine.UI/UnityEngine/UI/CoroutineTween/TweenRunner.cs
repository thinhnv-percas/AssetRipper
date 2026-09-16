using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;

namespace UnityEngine.UI.CoroutineTween
{
	[Token(Token = "0x2000090")]
	internal class TweenRunner<T> where T : struct, ITweenValue
	{
		[CompilerGenerated]
		[Token(Token = "0x2000091")]
		private sealed class _003CStart_003Ed__2 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000288")]
			[FieldOffset(Offset = "0x0")]
			private int _003C_003E1__state;

			[Token(Token = "0x4000289")]
			[FieldOffset(Offset = "0x0")]
			private object _003C_003E2__current;

			[Token(Token = "0x400028A")]
			[FieldOffset(Offset = "0x0")]
			public T tweenInfo;

			[Token(Token = "0x400028B")]
			[FieldOffset(Offset = "0x0")]
			private float _003CelapsedTime_003E5__2;

			[Token(Token = "0x17000167")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000585")]
				[Address(RVA = "0xDCF174", Offset = "0xDCF174", Length = "0x8")]
				get
				{
					return null;
				}
			}

			[Token(Token = "0x17000168")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000587")]
				[Address(RVA = "0xDCF1B0", Offset = "0xDCF1B0", Length = "0x8")]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000582")]
			[Address(RVA = "0xDCF04C", Offset = "0xDCF04C", Length = "0x28")]
			public _003CStart_003Ed__2(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			[Token(Token = "0x6000583")]
			[Address(RVA = "0xDCF074", Offset = "0xDCF074", Length = "0x4")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000584")]
			[Address(RVA = "0xDCF078", Offset = "0xDCF078", Length = "0xFC")]
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
			[Token(Token = "0x6000586")]
			[Address(RVA = "0xDCF17C", Offset = "0xDCF17C", Length = "0x34")]
			void IEnumerator.Reset()
			{
			}
		}

		[Token(Token = "0x4000286")]
		[FieldOffset(Offset = "0x0")]
		protected MonoBehaviour m_CoroutineContainer;

		[Token(Token = "0x4000287")]
		[FieldOffset(Offset = "0x0")]
		protected IEnumerator m_Tween;

		[IteratorStateMachine(typeof(TweenRunner<>._003CStart_003Ed__2))]
		[Token(Token = "0x600057D")]
		[Address(RVA = "0x11C7DC4", Offset = "0x11C7DC4", Length = "0xC0")]
		private static IEnumerator Start(T tweenInfo)
		{
			return null;
		}

		[Token(Token = "0x600057E")]
		[Address(RVA = "0x11C7E84", Offset = "0x11C7E84", Length = "0x8")]
		public void Init(MonoBehaviour coroutineContainer)
		{
		}

		[Token(Token = "0x600057F")]
		[Address(RVA = "0x11C7E8C", Offset = "0x11C7E8C", Length = "0x178")]
		public void StartTween(T info)
		{
		}

		[Token(Token = "0x6000580")]
		[Address(RVA = "0x11C8004", Offset = "0x11C8004", Length = "0x30")]
		public void StopTween()
		{
		}

		[Token(Token = "0x6000581")]
		[Address(RVA = "0x11C8034", Offset = "0x11C8034", Length = "0x8")]
		public TweenRunner()
		{
		}
	}
}
