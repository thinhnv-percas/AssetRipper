using System;
using Cpp2ILInjected;
using UnityEngine.Serialization;

namespace UnityEngine.UI
{
	[Serializable]
	[Token(Token = "0x200001C")]
	public class FontData : ISerializationCallbackReceiver
	{
		[SerializeField]
		[FormerlySerializedAs("font")]
		[Token(Token = "0x4000060")]
		[FieldOffset(Offset = "0x10")]
		private Font m_Font;

		[SerializeField]
		[FormerlySerializedAs("fontSize")]
		[Token(Token = "0x4000061")]
		[FieldOffset(Offset = "0x18")]
		private int m_FontSize;

		[SerializeField]
		[FormerlySerializedAs("fontStyle")]
		[Token(Token = "0x4000062")]
		[FieldOffset(Offset = "0x1C")]
		private FontStyle m_FontStyle;

		[SerializeField]
		[Token(Token = "0x4000063")]
		[FieldOffset(Offset = "0x20")]
		private bool m_BestFit;

		[SerializeField]
		[Token(Token = "0x4000064")]
		[FieldOffset(Offset = "0x24")]
		private int m_MinSize;

		[SerializeField]
		[Token(Token = "0x4000065")]
		[FieldOffset(Offset = "0x28")]
		private int m_MaxSize;

		[SerializeField]
		[FormerlySerializedAs("alignment")]
		[Token(Token = "0x4000066")]
		[FieldOffset(Offset = "0x2C")]
		private TextAnchor m_Alignment;

		[SerializeField]
		[Token(Token = "0x4000067")]
		[FieldOffset(Offset = "0x30")]
		private bool m_AlignByGeometry;

		[FormerlySerializedAs("richText")]
		[SerializeField]
		[Token(Token = "0x4000068")]
		[FieldOffset(Offset = "0x31")]
		private bool m_RichText;

		[SerializeField]
		[Token(Token = "0x4000069")]
		[FieldOffset(Offset = "0x34")]
		private HorizontalWrapMode m_HorizontalOverflow;

		[SerializeField]
		[Token(Token = "0x400006A")]
		[FieldOffset(Offset = "0x38")]
		private VerticalWrapMode m_VerticalOverflow;

		[SerializeField]
		[Token(Token = "0x400006B")]
		[FieldOffset(Offset = "0x3C")]
		private float m_LineSpacing;

		[Token(Token = "0x17000028")]
		public static FontData defaultFontData
		{
			[Token(Token = "0x60000C3")]
			[Address(RVA = "0x16CB154", Offset = "0x16CB154", Length = "0x90")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000029")]
		public Font font
		{
			[Token(Token = "0x60000C4")]
			[Address(RVA = "0x16CB1EC", Offset = "0x16CB1EC", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60000C5")]
			[Address(RVA = "0x16CB1F4", Offset = "0x16CB1F4", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700002A")]
		public int fontSize
		{
			[Token(Token = "0x60000C6")]
			[Address(RVA = "0x16CB1FC", Offset = "0x16CB1FC", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x60000C7")]
			[Address(RVA = "0x16CB204", Offset = "0x16CB204", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700002B")]
		public FontStyle fontStyle
		{
			[Token(Token = "0x60000C8")]
			[Address(RVA = "0x16CB20C", Offset = "0x16CB20C", Length = "0x8")]
			get
			{
				return FontStyle.Normal;
			}
			[Token(Token = "0x60000C9")]
			[Address(RVA = "0x16CB214", Offset = "0x16CB214", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700002C")]
		public bool bestFit
		{
			[Token(Token = "0x60000CA")]
			[Address(RVA = "0x16CB21C", Offset = "0x16CB21C", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60000CB")]
			[Address(RVA = "0x16CB224", Offset = "0x16CB224", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x1700002D")]
		public int minSize
		{
			[Token(Token = "0x60000CC")]
			[Address(RVA = "0x16CB230", Offset = "0x16CB230", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x60000CD")]
			[Address(RVA = "0x16CB238", Offset = "0x16CB238", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700002E")]
		public int maxSize
		{
			[Token(Token = "0x60000CE")]
			[Address(RVA = "0x16CB240", Offset = "0x16CB240", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x60000CF")]
			[Address(RVA = "0x16CB248", Offset = "0x16CB248", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700002F")]
		public TextAnchor alignment
		{
			[Token(Token = "0x60000D0")]
			[Address(RVA = "0x16CB250", Offset = "0x16CB250", Length = "0x8")]
			get
			{
				return TextAnchor.UpperLeft;
			}
			[Token(Token = "0x60000D1")]
			[Address(RVA = "0x16CB258", Offset = "0x16CB258", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000030")]
		public bool alignByGeometry
		{
			[Token(Token = "0x60000D2")]
			[Address(RVA = "0x16CB260", Offset = "0x16CB260", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60000D3")]
			[Address(RVA = "0x16CB268", Offset = "0x16CB268", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x17000031")]
		public bool richText
		{
			[Token(Token = "0x60000D4")]
			[Address(RVA = "0x16CB274", Offset = "0x16CB274", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60000D5")]
			[Address(RVA = "0x16CB27C", Offset = "0x16CB27C", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x17000032")]
		public HorizontalWrapMode horizontalOverflow
		{
			[Token(Token = "0x60000D6")]
			[Address(RVA = "0x16CB288", Offset = "0x16CB288", Length = "0x8")]
			get
			{
				return HorizontalWrapMode.Wrap;
			}
			[Token(Token = "0x60000D7")]
			[Address(RVA = "0x16CB290", Offset = "0x16CB290", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000033")]
		public VerticalWrapMode verticalOverflow
		{
			[Token(Token = "0x60000D8")]
			[Address(RVA = "0x16CB298", Offset = "0x16CB298", Length = "0x8")]
			get
			{
				return VerticalWrapMode.Truncate;
			}
			[Token(Token = "0x60000D9")]
			[Address(RVA = "0x16CB2A0", Offset = "0x16CB2A0", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000034")]
		public float lineSpacing
		{
			[Token(Token = "0x60000DA")]
			[Address(RVA = "0x16CB2A8", Offset = "0x16CB2A8", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60000DB")]
			[Address(RVA = "0x16CB2B0", Offset = "0x16CB2B0", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x60000DC")]
		[Address(RVA = "0x16CB2B8", Offset = "0x16CB2B8", Length = "0x4")]
		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		[Token(Token = "0x60000DD")]
		[Address(RVA = "0x16CB2BC", Offset = "0x16CB2BC", Length = "0x44")]
		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
		}

		[Token(Token = "0x60000DE")]
		[Address(RVA = "0x16CB1E4", Offset = "0x16CB1E4", Length = "0x8")]
		public FontData()
		{
		}
	}
}
