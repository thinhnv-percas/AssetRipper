using Cpp2ILInjected;
using UnityEngine.Events;

namespace TMPro
{
	[Token(Token = "0x2000030")]
	internal struct FloatTween : ITweenValue
	{
		[Token(Token = "0x2000031")]
		public class FloatTweenCallback : UnityEvent<float>
		{
			[Token(Token = "0x6000169")]
			[Address(RVA = "0x15D0C88", Offset = "0x15D0C88", Length = "0x48")]
			public FloatTweenCallback()
			{
			}
		}

		[Token(Token = "0x400016E")]
		[FieldOffset(Offset = "0x0")]
		private FloatTweenCallback m_Target;

		[Token(Token = "0x400016F")]
		[FieldOffset(Offset = "0x8")]
		private float m_StartValue;

		[Token(Token = "0x4000170")]
		[FieldOffset(Offset = "0xC")]
		private float m_TargetValue;

		[Token(Token = "0x4000171")]
		[FieldOffset(Offset = "0x10")]
		private float m_Duration;

		[Token(Token = "0x4000172")]
		[FieldOffset(Offset = "0x14")]
		private bool m_IgnoreTimeScale;

		[Token(Token = "0x17000033")]
		public float startValue
		{
			[Token(Token = "0x600015C")]
			[Address(RVA = "0x15D0B20", Offset = "0x15D0B20", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600015D")]
			[Address(RVA = "0x15D0B28", Offset = "0x15D0B28", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000034")]
		public float targetValue
		{
			[Token(Token = "0x600015E")]
			[Address(RVA = "0x15D0B30", Offset = "0x15D0B30", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600015F")]
			[Address(RVA = "0x15D0B38", Offset = "0x15D0B38", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000035")]
		public float duration
		{
			[Token(Token = "0x6000160")]
			[Address(RVA = "0x15D0B40", Offset = "0x15D0B40", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000161")]
			[Address(RVA = "0x15D0B48", Offset = "0x15D0B48", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000036")]
		public bool ignoreTimeScale
		{
			[Token(Token = "0x6000162")]
			[Address(RVA = "0x15D0B50", Offset = "0x15D0B50", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000163")]
			[Address(RVA = "0x15D0B58", Offset = "0x15D0B58", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x6000164")]
		[Address(RVA = "0x15D0B64", Offset = "0x15D0B64", Length = "0x8C")]
		public void TweenValue(float floatPercentage)
		{
		}

		[Token(Token = "0x6000165")]
		[Address(RVA = "0x15D0C00", Offset = "0x15D0C00", Length = "0x88")]
		public void AddOnChangedCallback(UnityAction<float> callback)
		{
		}

		[Token(Token = "0x6000166")]
		[Address(RVA = "0x15D0CD0", Offset = "0x15D0CD0", Length = "0x8")]
		public bool GetIgnoreTimescale()
		{
			return false;
		}

		[Token(Token = "0x6000167")]
		[Address(RVA = "0x15D0CD8", Offset = "0x15D0CD8", Length = "0x8")]
		public float GetDuration()
		{
			return 0f;
		}

		[Token(Token = "0x6000168")]
		[Address(RVA = "0x15D0BF0", Offset = "0x15D0BF0", Length = "0x10")]
		public bool ValidTarget()
		{
			return false;
		}
	}
}
