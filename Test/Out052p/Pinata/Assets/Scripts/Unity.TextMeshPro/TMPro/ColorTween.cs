using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;

namespace TMPro
{
	[Token(Token = "0x2000013")]
	internal struct ColorTween : ITweenValue
	{
		[Token(Token = "0x2000070")]
		public enum ColorTweenMode
		{
			[Token(Token = "0x4000486")]
			All = 0,
			[Token(Token = "0x4000487")]
			RGB = 1,
			[Token(Token = "0x4000488")]
			Alpha = 2
		}

		[Token(Token = "0x2000071")]
		public class ColorTweenCallback : UnityEvent<Color>
		{
			[Token(Token = "0x6000543")]
			[Address(RVA = "0x917364", Offset = "0x917364", Length = "0x60")]
			public ColorTweenCallback()
			{
			}
		}

		[Token(Token = "0x4000089")]
		[FieldOffset(Offset = "0x0")]
		private ColorTweenCallback m_Target;

		[Token(Token = "0x400008A")]
		[FieldOffset(Offset = "0x8")]
		private Color m_StartColor;

		[Token(Token = "0x400008B")]
		[FieldOffset(Offset = "0x18")]
		private Color m_TargetColor;

		[Token(Token = "0x400008C")]
		[FieldOffset(Offset = "0x28")]
		private ColorTweenMode m_TweenMode;

		[Token(Token = "0x400008D")]
		[FieldOffset(Offset = "0x2C")]
		private float m_Duration;

		[Token(Token = "0x400008E")]
		[FieldOffset(Offset = "0x30")]
		private bool m_IgnoreTimeScale;

		[Token(Token = "0x17000021")]
		public Color startColor
		{
			[Token(Token = "0x60000EA")]
			[Address(RVA = "0x8461E0", Offset = "0x8461E0", Length = "0xC")]
			get
			{
				return default(Color);
			}
			[Token(Token = "0x60000EB")]
			[Address(RVA = "0x8461EC", Offset = "0x8461EC", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x17000022")]
		public Color targetColor
		{
			[Token(Token = "0x60000EC")]
			[Address(RVA = "0x8461F8", Offset = "0x8461F8", Length = "0xC")]
			get
			{
				return default(Color);
			}
			[Token(Token = "0x60000ED")]
			[Address(RVA = "0x846204", Offset = "0x846204", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x17000023")]
		public ColorTweenMode tweenMode
		{
			[Token(Token = "0x60000EE")]
			[Address(RVA = "0x846210", Offset = "0x846210", Length = "0x8")]
			get
			{
				return ColorTweenMode.All;
			}
			[Token(Token = "0x60000EF")]
			[Address(RVA = "0x846218", Offset = "0x846218", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000024")]
		public float duration
		{
			[Token(Token = "0x60000F0")]
			[Address(RVA = "0x846220", Offset = "0x846220", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60000F1")]
			[Address(RVA = "0x846228", Offset = "0x846228", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000025")]
		public bool ignoreTimeScale
		{
			[Token(Token = "0x60000F2")]
			[Address(RVA = "0x846230", Offset = "0x846230", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60000F3")]
			[Address(RVA = "0x846238", Offset = "0x846238", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x60000F4")]
		[Address(RVA = "0x846244", Offset = "0x846244", Length = "0x8")]
		public void TweenValue(float floatPercentage)
		{
		}

		[Token(Token = "0x60000F5")]
		[Address(RVA = "0x84624C", Offset = "0x84624C", Length = "0x8")]
		public void AddOnChangedCallback(UnityAction<Color> callback)
		{
		}

		[Token(Token = "0x60000F6")]
		[Address(RVA = "0x846254", Offset = "0x846254", Length = "0x8")]
		public bool GetIgnoreTimescale()
		{
			return false;
		}

		[Token(Token = "0x60000F7")]
		[Address(RVA = "0x84625C", Offset = "0x84625C", Length = "0x8")]
		public float GetDuration()
		{
			return 0f;
		}

		[Token(Token = "0x60000F8")]
		[Address(RVA = "0x846264", Offset = "0x846264", Length = "0x10")]
		public bool ValidTarget()
		{
			return false;
		}
	}
}
