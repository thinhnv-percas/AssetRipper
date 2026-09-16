using System;
using Cpp2ILInjected;
using UnityEngine.Serialization;

namespace UnityEngine.UI
{
	[Serializable]
	[Token(Token = "0x2000004")]
	public class AnimationTriggers
	{
		[Token(Token = "0x4000006")]
		private const string kDefaultNormalAnimName = "Normal";

		[Token(Token = "0x4000007")]
		private const string kDefaultHighlightedAnimName = "Highlighted";

		[Token(Token = "0x4000008")]
		private const string kDefaultPressedAnimName = "Pressed";

		[Token(Token = "0x4000009")]
		private const string kDefaultSelectedAnimName = "Selected";

		[Token(Token = "0x400000A")]
		private const string kDefaultDisabledAnimName = "Disabled";

		[FormerlySerializedAs("normalTrigger")]
		[SerializeField]
		[Token(Token = "0x400000B")]
		[FieldOffset(Offset = "0x10")]
		private string m_NormalTrigger;

		[FormerlySerializedAs("highlightedTrigger")]
		[SerializeField]
		[Token(Token = "0x400000C")]
		[FieldOffset(Offset = "0x18")]
		private string m_HighlightedTrigger;

		[FormerlySerializedAs("pressedTrigger")]
		[SerializeField]
		[Token(Token = "0x400000D")]
		[FieldOffset(Offset = "0x20")]
		private string m_PressedTrigger;

		[SerializeField]
		[FormerlySerializedAs("m_HighlightedTrigger")]
		[Token(Token = "0x400000E")]
		[FieldOffset(Offset = "0x28")]
		private string m_SelectedTrigger;

		[FormerlySerializedAs("disabledTrigger")]
		[SerializeField]
		[Token(Token = "0x400000F")]
		[FieldOffset(Offset = "0x30")]
		private string m_DisabledTrigger;

		[Token(Token = "0x17000001")]
		public string normalTrigger
		{
			[Token(Token = "0x6000003")]
			[Address(RVA = "0x16C0E90", Offset = "0x16C0E90", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000004")]
			[Address(RVA = "0x16C0E98", Offset = "0x16C0E98", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000002")]
		public string highlightedTrigger
		{
			[Token(Token = "0x6000005")]
			[Address(RVA = "0x16C0EA0", Offset = "0x16C0EA0", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000006")]
			[Address(RVA = "0x16C0EA8", Offset = "0x16C0EA8", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000003")]
		public string pressedTrigger
		{
			[Token(Token = "0x6000007")]
			[Address(RVA = "0x16C0EB0", Offset = "0x16C0EB0", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000008")]
			[Address(RVA = "0x16C0EB8", Offset = "0x16C0EB8", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000004")]
		public string selectedTrigger
		{
			[Token(Token = "0x6000009")]
			[Address(RVA = "0x16C0EC0", Offset = "0x16C0EC0", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600000A")]
			[Address(RVA = "0x16C0EC8", Offset = "0x16C0EC8", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000005")]
		public string disabledTrigger
		{
			[Token(Token = "0x600000B")]
			[Address(RVA = "0x16C0ED0", Offset = "0x16C0ED0", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600000C")]
			[Address(RVA = "0x16C0ED8", Offset = "0x16C0ED8", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x600000D")]
		[Address(RVA = "0x16C0EE0", Offset = "0x16C0EE0", Length = "0xC8")]
		public AnimationTriggers()
		{
		}
	}
}
