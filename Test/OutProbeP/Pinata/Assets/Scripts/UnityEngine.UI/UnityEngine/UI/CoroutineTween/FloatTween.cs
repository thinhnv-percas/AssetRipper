using Cpp2ILInjected;
using UnityEngine.Events;

namespace UnityEngine.UI.CoroutineTween
{
	[Token(Token = "0x2000049")]
	internal struct FloatTween : ITweenValue
	{
		[Token(Token = "0x20000B6")]
		public class FloatTweenCallback : UnityEvent<float>
		{
			[Token(Token = "0x6000695")]
			[Address(RVA = "0xC4FF28", Offset = "0xC4FF28", Length = "0x60")]
			public FloatTweenCallback()
			{
			}
		}

		[Token(Token = "0x400018F")]
		[FieldOffset(Offset = "0x0")]
		private FloatTweenCallback m_Target;

		[Token(Token = "0x4000190")]
		[FieldOffset(Offset = "0x8")]
		private float m_StartValue;

		[Token(Token = "0x4000191")]
		[FieldOffset(Offset = "0xC")]
		private float m_TargetValue;

		[Token(Token = "0x4000192")]
		[FieldOffset(Offset = "0x10")]
		private float m_Duration;

		[Token(Token = "0x4000193")]
		[FieldOffset(Offset = "0x14")]
		private bool m_IgnoreTimeScale;

		[Token(Token = "0x1700014B")]
		public float startValue
		{
			[Token(Token = "0x60004BE")]
			[Address(RVA = "0x84C1F8", Offset = "0x84C1F8", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60004BF")]
			[Address(RVA = "0x84C200", Offset = "0x84C200", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700014C")]
		public float targetValue
		{
			[Token(Token = "0x60004C0")]
			[Address(RVA = "0x84C208", Offset = "0x84C208", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60004C1")]
			[Address(RVA = "0x84C210", Offset = "0x84C210", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700014D")]
		public float duration
		{
			[Token(Token = "0x60004C2")]
			[Address(RVA = "0x84C218", Offset = "0x84C218", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60004C3")]
			[Address(RVA = "0x84C220", Offset = "0x84C220", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700014E")]
		public bool ignoreTimeScale
		{
			[Token(Token = "0x60004C4")]
			[Address(RVA = "0x84C228", Offset = "0x84C228", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60004C5")]
			[Address(RVA = "0x84C230", Offset = "0x84C230", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x60004C6")]
		[Address(RVA = "0x84C23C", Offset = "0x84C23C", Length = "0x8")]
		public void TweenValue(float floatPercentage)
		{
		}

		[Token(Token = "0x60004C7")]
		[Address(RVA = "0x84C244", Offset = "0x84C244", Length = "0x8")]
		public void AddOnChangedCallback(UnityAction<float> callback)
		{
		}

		[Token(Token = "0x60004C8")]
		[Address(RVA = "0x84C24C", Offset = "0x84C24C", Length = "0x8")]
		public bool GetIgnoreTimescale()
		{
			return false;
		}

		[Token(Token = "0x60004C9")]
		[Address(RVA = "0x84C254", Offset = "0x84C254", Length = "0x8")]
		public float GetDuration()
		{
			return 0f;
		}

		[Token(Token = "0x60004CA")]
		[Address(RVA = "0x84C25C", Offset = "0x84C25C", Length = "0x224")]
		public bool ValidTarget()
		{
			return false;
		}
	}
}
