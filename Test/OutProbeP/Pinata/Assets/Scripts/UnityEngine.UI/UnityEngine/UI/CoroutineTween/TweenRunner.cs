using System.Collections;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;

namespace UnityEngine.UI.CoroutineTween
{
	[Token(Token = "0x200004A")]
	internal class TweenRunner<T> where T : struct, ITweenValue
	{
		[Token(Token = "0x4000194")]
		[FieldOffset(Offset = "0x0")]
		protected MonoBehaviour m_CoroutineContainer;

		[Token(Token = "0x4000195")]
		[FieldOffset(Offset = "0x0")]
		protected IEnumerator m_Tween;

		[Attribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x72A4A4", Offset = "0x72A4A4")]
		[Token(Token = "0x60004CB")]
		[Address(RVA = "0x11DC8D8", Offset = "0x11DC8D8", Length = "0x10C")]
		private static IEnumerator Start(T tweenInfo)
		{
			return null;
		}

		[Token(Token = "0x60004CC")]
		[Address(RVA = "0x11DC9E4", Offset = "0x11DC9E4", Length = "0x8")]
		public void Init(MonoBehaviour coroutineContainer)
		{
		}

		[Token(Token = "0x60004CD")]
		[Address(RVA = "0x11DC9EC", Offset = "0x11DC9EC", Length = "0x198")]
		public void StartTween(T info)
		{
		}

		[Token(Token = "0x60004CE")]
		[Address(RVA = "0x11DCB84", Offset = "0x11DCB84", Length = "0x3C")]
		public void StopTween()
		{
		}

		[Token(Token = "0x60004CF")]
		[Address(RVA = "0x11DCBC0", Offset = "0x11DCBC0", Length = "0x18")]
		public TweenRunner()
		{
		}
	}
}
