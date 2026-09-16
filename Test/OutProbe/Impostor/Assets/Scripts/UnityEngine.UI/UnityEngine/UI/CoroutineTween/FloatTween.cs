using Cpp2ILInjected;
using UnityEngine.Events;

namespace UnityEngine.UI.CoroutineTween
{
	[Token(Token = "0x200008E")]
	internal struct FloatTween : ITweenValue
	{
		[Token(Token = "0x200008F")]
		public class FloatTweenCallback : UnityEvent<float>
		{
			[Token(Token = "0x600057C")]
			[Address(RVA = "0x183F100", Offset = "0x183F100", Length = "0x48")]
			public FloatTweenCallback()
			{
			}
		}

		[Token(Token = "0x4000281")]
		[FieldOffset(Offset = "0x0")]
		private FloatTweenCallback m_Target;

		[Token(Token = "0x4000282")]
		[FieldOffset(Offset = "0x8")]
		private float m_StartValue;

		[Token(Token = "0x4000283")]
		[FieldOffset(Offset = "0xC")]
		private float m_TargetValue;

		[Token(Token = "0x4000284")]
		[FieldOffset(Offset = "0x10")]
		private float m_Duration;

		[Token(Token = "0x4000285")]
		[FieldOffset(Offset = "0x14")]
		private bool m_IgnoreTimeScale;

		[Token(Token = "0x17000163")]
		public float startValue
		{
			[Token(Token = "0x600056F")]
			[Address(RVA = "0x183EF98", Offset = "0x183EF98", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000570")]
			[Address(RVA = "0x183EFA0", Offset = "0x183EFA0", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000164")]
		public float targetValue
		{
			[Token(Token = "0x6000571")]
			[Address(RVA = "0x183EFA8", Offset = "0x183EFA8", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000572")]
			[Address(RVA = "0x183EFB0", Offset = "0x183EFB0", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000165")]
		public float duration
		{
			[Token(Token = "0x6000573")]
			[Address(RVA = "0x183EFB8", Offset = "0x183EFB8", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000574")]
			[Address(RVA = "0x183EFC0", Offset = "0x183EFC0", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000166")]
		public bool ignoreTimeScale
		{
			[Token(Token = "0x6000575")]
			[Address(RVA = "0x183EFC8", Offset = "0x183EFC8", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000576")]
			[Address(RVA = "0x183EFD0", Offset = "0x183EFD0", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x6000577")]
		[Address(RVA = "0x183EFDC", Offset = "0x183EFDC", Length = "0x8C")]
		public void TweenValue(float floatPercentage)
		{
		}

		[Token(Token = "0x6000578")]
		[Address(RVA = "0x183F078", Offset = "0x183F078", Length = "0x88")]
		public void AddOnChangedCallback(UnityAction<float> callback)
		{
		}

		[Token(Token = "0x6000579")]
		[Address(RVA = "0x183F148", Offset = "0x183F148", Length = "0x8")]
		public bool GetIgnoreTimescale()
		{
			return false;
		}

		[Token(Token = "0x600057A")]
		[Address(RVA = "0x183F150", Offset = "0x183F150", Length = "0x8")]
		public float GetDuration()
		{
			return 0f;
		}

		[Token(Token = "0x600057B")]
		[Address(RVA = "0x183F068", Offset = "0x183F068", Length = "0x10")]
		public bool ValidTarget()
		{
			return false;
		}
	}
}
