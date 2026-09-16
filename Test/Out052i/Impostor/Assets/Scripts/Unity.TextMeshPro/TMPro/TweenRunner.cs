using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Token(Token = "0x2000032")]
	internal class TweenRunner<T> where T : struct, ITweenValue
	{
		[CompilerGenerated]
		[Token(Token = "0x2000033")]
		private sealed class _003CStart_003Ed__2 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000175")]
			[FieldOffset(Offset = "0x0")]
			private int _003C_003E1__state;

			[Token(Token = "0x4000176")]
			[FieldOffset(Offset = "0x0")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000177")]
			[FieldOffset(Offset = "0x0")]
			public T tweenInfo;

			[Token(Token = "0x4000178")]
			[FieldOffset(Offset = "0x0")]
			private float _003CelapsedTime_003E5__2;

			[Token(Token = "0x17000037")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000172")]
				[Address(RVA = "0xDCF2E0", Offset = "0xDCF2E0", Length = "0x8")]
				get
				{
					return null;
				}
			}

			[Token(Token = "0x17000038")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000174")]
				[Address(RVA = "0xDCF31C", Offset = "0xDCF31C", Length = "0x8")]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x600016F")]
			[Address(RVA = "0xDCF1B8", Offset = "0xDCF1B8", Length = "0x28")]
			public _003CStart_003Ed__2(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			[Token(Token = "0x6000170")]
			[Address(RVA = "0xDCF1E0", Offset = "0xDCF1E0", Length = "0x4")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000171")]
			[Address(RVA = "0xDCF1E4", Offset = "0xDCF1E4", Length = "0xFC")]
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
			[Token(Token = "0x6000173")]
			[Address(RVA = "0xDCF2E8", Offset = "0xDCF2E8", Length = "0x34")]
			void IEnumerator.Reset()
			{
			}
		}

		[Token(Token = "0x4000173")]
		[FieldOffset(Offset = "0x0")]
		protected MonoBehaviour m_CoroutineContainer;

		[Token(Token = "0x4000174")]
		[FieldOffset(Offset = "0x0")]
		protected IEnumerator m_Tween;

		[IteratorStateMachine(typeof(TweenRunner<>._003CStart_003Ed__2))]
		[Token(Token = "0x600016A")]
		[Address(RVA = "0x11C7770", Offset = "0x11C7770", Length = "0xB0")]
		private static IEnumerator Start(T tweenInfo)
		{
			return null;
		}

		[Token(Token = "0x600016B")]
		[Address(RVA = "0x11C7820", Offset = "0x11C7820", Length = "0x8")]
		public void Init(MonoBehaviour coroutineContainer)
		{
		}

		[Token(Token = "0x600016C")]
		[Address(RVA = "0x11C7828", Offset = "0x11C7828", Length = "0x16C")]
		public void StartTween(T info)
		{
		}

		[Token(Token = "0x600016D")]
		[Address(RVA = "0x11C7994", Offset = "0x11C7994", Length = "0x30")]
		public void StopTween()
		{
		}

		[Token(Token = "0x600016E")]
		[Address(RVA = "0x11C79C4", Offset = "0x11C79C4", Length = "0x8")]
		public TweenRunner()
		{
		}
	}
}
