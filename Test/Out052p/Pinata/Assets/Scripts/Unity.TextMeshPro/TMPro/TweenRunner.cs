using System.Collections;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Token(Token = "0x2000015")]
	internal class TweenRunner<T> where T : struct, ITweenValue
	{
		[Token(Token = "0x4000094")]
		[FieldOffset(Offset = "0x0")]
		protected MonoBehaviour m_CoroutineContainer;

		[Token(Token = "0x4000095")]
		[FieldOffset(Offset = "0x0")]
		protected IEnumerator m_Tween;

		[Attribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x749508", Offset = "0x749508")]
		[Token(Token = "0x6000106")]
		[Address(RVA = "0x11CE960", Offset = "0x11CE960", Length = "0xEC")]
		private static IEnumerator Start(T tweenInfo)
		{
			return null;
		}

		[Token(Token = "0x6000107")]
		[Address(RVA = "0x11CEA4C", Offset = "0x11CEA4C", Length = "0x8")]
		public void Init(MonoBehaviour coroutineContainer)
		{
		}

		[Token(Token = "0x6000108")]
		[Address(RVA = "0x11CEA54", Offset = "0x11CEA54", Length = "0x18C")]
		public void StartTween(T info)
		{
		}

		[Token(Token = "0x6000109")]
		[Address(RVA = "0x11CEBE0", Offset = "0x11CEBE0", Length = "0x3C")]
		public void StopTween()
		{
		}

		[Token(Token = "0x600010A")]
		[Address(RVA = "0x11CEC1C", Offset = "0x11CEC1C", Length = "0x18")]
		public TweenRunner()
		{
		}
	}
}
