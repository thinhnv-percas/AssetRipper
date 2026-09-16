using Cpp2ILInjected;
using UnityEngine.Events;

namespace UnityEngine.UI.CoroutineTween
{
	[Token(Token = "0x200008B")]
	internal struct ColorTween : ITweenValue
	{
		[Token(Token = "0x200008C")]
		public enum ColorTweenMode
		{
			[Token(Token = "0x400027E")]
			All = 0,
			[Token(Token = "0x400027F")]
			RGB = 1,
			[Token(Token = "0x4000280")]
			Alpha = 2
		}

		[Token(Token = "0x200008D")]
		public class ColorTweenCallback : UnityEvent<Color>
		{
			[Token(Token = "0x600056E")]
			[Address(RVA = "0x183EF40", Offset = "0x183EF40", Length = "0x48")]
			public ColorTweenCallback()
			{
			}
		}

		[Token(Token = "0x4000277")]
		[FieldOffset(Offset = "0x0")]
		private ColorTweenCallback m_Target;

		[Token(Token = "0x4000278")]
		[FieldOffset(Offset = "0x8")]
		private Color m_StartColor;

		[Token(Token = "0x4000279")]
		[FieldOffset(Offset = "0x18")]
		private Color m_TargetColor;

		[Token(Token = "0x400027A")]
		[FieldOffset(Offset = "0x28")]
		private ColorTweenMode m_TweenMode;

		[Token(Token = "0x400027B")]
		[FieldOffset(Offset = "0x2C")]
		private float m_Duration;

		[Token(Token = "0x400027C")]
		[FieldOffset(Offset = "0x30")]
		private bool m_IgnoreTimeScale;

		[Token(Token = "0x1700015E")]
		public Color startColor
		{
			[Token(Token = "0x600055F")]
			[Address(RVA = "0x183ED68", Offset = "0x183ED68", Length = "0xC")]
			get
			{
				return default(Color);
			}
			[Token(Token = "0x6000560")]
			[Address(RVA = "0x183ED74", Offset = "0x183ED74", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x1700015F")]
		public Color targetColor
		{
			[Token(Token = "0x6000561")]
			[Address(RVA = "0x183ED80", Offset = "0x183ED80", Length = "0xC")]
			get
			{
				return default(Color);
			}
			[Token(Token = "0x6000562")]
			[Address(RVA = "0x183ED8C", Offset = "0x183ED8C", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x17000160")]
		public ColorTweenMode tweenMode
		{
			[Token(Token = "0x6000563")]
			[Address(RVA = "0x183ED98", Offset = "0x183ED98", Length = "0x8")]
			get
			{
				return ColorTweenMode.All;
			}
			[Token(Token = "0x6000564")]
			[Address(RVA = "0x183EDA0", Offset = "0x183EDA0", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000161")]
		public float duration
		{
			[Token(Token = "0x6000565")]
			[Address(RVA = "0x183EDA8", Offset = "0x183EDA8", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000566")]
			[Address(RVA = "0x183EDB0", Offset = "0x183EDB0", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000162")]
		public bool ignoreTimeScale
		{
			[Token(Token = "0x6000567")]
			[Address(RVA = "0x183EDB8", Offset = "0x183EDB8", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000568")]
			[Address(RVA = "0x183EDC0", Offset = "0x183EDC0", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x6000569")]
		[Address(RVA = "0x183EDCC", Offset = "0x183EDCC", Length = "0xDC")]
		public void TweenValue(float floatPercentage)
		{
		}

		[Token(Token = "0x600056A")]
		[Address(RVA = "0x183EEB8", Offset = "0x183EEB8", Length = "0x88")]
		public void AddOnChangedCallback(UnityAction<Color> callback)
		{
		}

		[Token(Token = "0x600056B")]
		[Address(RVA = "0x183EF88", Offset = "0x183EF88", Length = "0x8")]
		public bool GetIgnoreTimescale()
		{
			return false;
		}

		[Token(Token = "0x600056C")]
		[Address(RVA = "0x183EF90", Offset = "0x183EF90", Length = "0x8")]
		public float GetDuration()
		{
			return 0f;
		}

		[Token(Token = "0x600056D")]
		[Address(RVA = "0x183EEA8", Offset = "0x183EEA8", Length = "0x10")]
		public bool ValidTarget()
		{
			return false;
		}
	}
}
