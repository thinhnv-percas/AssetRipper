using Cpp2ILInjected;
using UnityEngine.Events;

namespace UnityEngine.UI.CoroutineTween
{
	[Token(Token = "0x2000048")]
	internal struct ColorTween : ITweenValue
	{
		[Token(Token = "0x20000B4")]
		public enum ColorTweenMode
		{
			[Token(Token = "0x40002F4")]
			All = 0,
			[Token(Token = "0x40002F5")]
			RGB = 1,
			[Token(Token = "0x40002F6")]
			Alpha = 2
		}

		[Token(Token = "0x20000B5")]
		public class ColorTweenCallback : UnityEvent<Color>
		{
			[Token(Token = "0x6000694")]
			[Address(RVA = "0xC4FD24", Offset = "0xC4FD24", Length = "0x204")]
			public ColorTweenCallback()
			{
			}
		}

		[Token(Token = "0x4000189")]
		[FieldOffset(Offset = "0x0")]
		private ColorTweenCallback m_Target;

		[Token(Token = "0x400018A")]
		[FieldOffset(Offset = "0x8")]
		private Color m_StartColor;

		[Token(Token = "0x400018B")]
		[FieldOffset(Offset = "0x18")]
		private Color m_TargetColor;

		[Token(Token = "0x400018C")]
		[FieldOffset(Offset = "0x28")]
		private ColorTweenMode m_TweenMode;

		[Token(Token = "0x400018D")]
		[FieldOffset(Offset = "0x2C")]
		private float m_Duration;

		[Token(Token = "0x400018E")]
		[FieldOffset(Offset = "0x30")]
		private bool m_IgnoreTimeScale;

		[Token(Token = "0x17000146")]
		public Color startColor
		{
			[Token(Token = "0x60004AF")]
			[Address(RVA = "0x84C120", Offset = "0x84C120", Length = "0xC")]
			get
			{
				return default(Color);
			}
			[Token(Token = "0x60004B0")]
			[Address(RVA = "0x84C12C", Offset = "0x84C12C", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x17000147")]
		public Color targetColor
		{
			[Token(Token = "0x60004B1")]
			[Address(RVA = "0x84C138", Offset = "0x84C138", Length = "0xC")]
			get
			{
				return default(Color);
			}
			[Token(Token = "0x60004B2")]
			[Address(RVA = "0x84C144", Offset = "0x84C144", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x17000148")]
		public ColorTweenMode tweenMode
		{
			[Token(Token = "0x60004B3")]
			[Address(RVA = "0x84C150", Offset = "0x84C150", Length = "0x8")]
			get
			{
				return ColorTweenMode.All;
			}
			[Token(Token = "0x60004B4")]
			[Address(RVA = "0x84C158", Offset = "0x84C158", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000149")]
		public float duration
		{
			[Token(Token = "0x60004B5")]
			[Address(RVA = "0x84C160", Offset = "0x84C160", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60004B6")]
			[Address(RVA = "0x84C168", Offset = "0x84C168", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700014A")]
		public bool ignoreTimeScale
		{
			[Token(Token = "0x60004B7")]
			[Address(RVA = "0x84C170", Offset = "0x84C170", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60004B8")]
			[Address(RVA = "0x84C178", Offset = "0x84C178", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x60004B9")]
		[Address(RVA = "0x84C184", Offset = "0x84C184", Length = "0x8")]
		public void TweenValue(float floatPercentage)
		{
		}

		[Token(Token = "0x60004BA")]
		[Address(RVA = "0x84C18C", Offset = "0x84C18C", Length = "0x8")]
		public void AddOnChangedCallback(UnityAction<Color> callback)
		{
		}

		[Token(Token = "0x60004BB")]
		[Address(RVA = "0x84C194", Offset = "0x84C194", Length = "0x8")]
		public bool GetIgnoreTimescale()
		{
			return false;
		}

		[Token(Token = "0x60004BC")]
		[Address(RVA = "0x84C19C", Offset = "0x84C19C", Length = "0x8")]
		public float GetDuration()
		{
			return 0f;
		}

		[Token(Token = "0x60004BD")]
		[Address(RVA = "0x84C1A4", Offset = "0x84C1A4", Length = "0x54")]
		public bool ValidTarget()
		{
			return false;
		}
	}
}
