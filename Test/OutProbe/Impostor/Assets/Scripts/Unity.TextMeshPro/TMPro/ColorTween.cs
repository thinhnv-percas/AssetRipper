using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;

namespace TMPro
{
	[Token(Token = "0x200002D")]
	internal struct ColorTween : ITweenValue
	{
		[Token(Token = "0x200002E")]
		public enum ColorTweenMode
		{
			[Token(Token = "0x400016B")]
			All = 0,
			[Token(Token = "0x400016C")]
			RGB = 1,
			[Token(Token = "0x400016D")]
			Alpha = 2
		}

		[Token(Token = "0x200002F")]
		public class ColorTweenCallback : UnityEvent<Color>
		{
			[Token(Token = "0x600015B")]
			[Address(RVA = "0x15D0AC8", Offset = "0x15D0AC8", Length = "0x48")]
			public ColorTweenCallback()
			{
			}
		}

		[Token(Token = "0x4000164")]
		[FieldOffset(Offset = "0x0")]
		private ColorTweenCallback m_Target;

		[Token(Token = "0x4000165")]
		[FieldOffset(Offset = "0x8")]
		private Color m_StartColor;

		[Token(Token = "0x4000166")]
		[FieldOffset(Offset = "0x18")]
		private Color m_TargetColor;

		[Token(Token = "0x4000167")]
		[FieldOffset(Offset = "0x28")]
		private ColorTweenMode m_TweenMode;

		[Token(Token = "0x4000168")]
		[FieldOffset(Offset = "0x2C")]
		private float m_Duration;

		[Token(Token = "0x4000169")]
		[FieldOffset(Offset = "0x30")]
		private bool m_IgnoreTimeScale;

		[Token(Token = "0x1700002E")]
		public Color startColor
		{
			[Token(Token = "0x600014C")]
			[Address(RVA = "0x15D08F0", Offset = "0x15D08F0", Length = "0xC")]
			get
			{
				return default(Color);
			}
			[Token(Token = "0x600014D")]
			[Address(RVA = "0x15D08FC", Offset = "0x15D08FC", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x1700002F")]
		public Color targetColor
		{
			[Token(Token = "0x600014E")]
			[Address(RVA = "0x15D0908", Offset = "0x15D0908", Length = "0xC")]
			get
			{
				return default(Color);
			}
			[Token(Token = "0x600014F")]
			[Address(RVA = "0x15D0914", Offset = "0x15D0914", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x17000030")]
		public ColorTweenMode tweenMode
		{
			[Token(Token = "0x6000150")]
			[Address(RVA = "0x15D0920", Offset = "0x15D0920", Length = "0x8")]
			get
			{
				return ColorTweenMode.All;
			}
			[Token(Token = "0x6000151")]
			[Address(RVA = "0x15D0928", Offset = "0x15D0928", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000031")]
		public float duration
		{
			[Token(Token = "0x6000152")]
			[Address(RVA = "0x15D0930", Offset = "0x15D0930", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000153")]
			[Address(RVA = "0x15D0938", Offset = "0x15D0938", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000032")]
		public bool ignoreTimeScale
		{
			[Token(Token = "0x6000154")]
			[Address(RVA = "0x15D0940", Offset = "0x15D0940", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000155")]
			[Address(RVA = "0x15D0948", Offset = "0x15D0948", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x6000156")]
		[Address(RVA = "0x15D0954", Offset = "0x15D0954", Length = "0xDC")]
		public void TweenValue(float floatPercentage)
		{
		}

		[Token(Token = "0x6000157")]
		[Address(RVA = "0x15D0A40", Offset = "0x15D0A40", Length = "0x88")]
		public void AddOnChangedCallback(UnityAction<Color> callback)
		{
		}

		[Token(Token = "0x6000158")]
		[Address(RVA = "0x15D0B10", Offset = "0x15D0B10", Length = "0x8")]
		public bool GetIgnoreTimescale()
		{
			return false;
		}

		[Token(Token = "0x6000159")]
		[Address(RVA = "0x15D0B18", Offset = "0x15D0B18", Length = "0x8")]
		public float GetDuration()
		{
			return 0f;
		}

		[Token(Token = "0x600015A")]
		[Address(RVA = "0x15D0A30", Offset = "0x15D0A30", Length = "0x10")]
		public bool ValidTarget()
		{
			return false;
		}
	}
}
