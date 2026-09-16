using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine.Events;

namespace TMPro
{
	[Token(Token = "0x2000071")]
	internal class TMP_ObjectPool<T> where T : new()
	{
		[Token(Token = "0x4000301")]
		[FieldOffset(Offset = "0x0")]
		private readonly Stack<T> m_Stack;

		[Token(Token = "0x4000302")]
		[FieldOffset(Offset = "0x0")]
		private readonly UnityAction<T> m_ActionOnGet;

		[Token(Token = "0x4000303")]
		[FieldOffset(Offset = "0x0")]
		private readonly UnityAction<T> m_ActionOnRelease;

		[Token(Token = "0x170000BA")]
		public int countAll
		{
			[Token(Token = "0x60003B9")]
			[Address(RVA = "0x116C394", Offset = "0x116C394", Length = "0x8")]
			get;
			[Token(Token = "0x60003BA")]
			[Address(RVA = "0x116C39C", Offset = "0x116C39C", Length = "0x8")]
			private set;
		}

		[Token(Token = "0x170000BB")]
		public int countActive
		{
			[Token(Token = "0x60003BB")]
			[Address(RVA = "0x116C3A4", Offset = "0x116C3A4", Length = "0x24")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x170000BC")]
		public int countInactive
		{
			[Token(Token = "0x60003BC")]
			[Address(RVA = "0x116C3C8", Offset = "0x116C3C8", Length = "0x1C")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x60003BD")]
		[Address(RVA = "0x116C3E4", Offset = "0x116C3E4", Length = "0x7C")]
		public TMP_ObjectPool(UnityAction<T> actionOnGet, UnityAction<T> actionOnRelease)
		{
		}

		[Token(Token = "0x60003BE")]
		[Address(RVA = "0x116C460", Offset = "0x116C460", Length = "0x7C")]
		public T Get()
		{
			return default(T);
		}

		[Token(Token = "0x60003BF")]
		[Address(RVA = "0x116C4DC", Offset = "0x116C4DC", Length = "0xE4")]
		public void Release(T element)
		{
		}
	}
}
