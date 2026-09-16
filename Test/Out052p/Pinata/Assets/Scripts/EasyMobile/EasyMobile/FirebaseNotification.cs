using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile
{
	[Token(Token = "0x2000071")]
	public class FirebaseNotification
	{
		[CompilerGenerated]
		[Token(Token = "0x400029E")]
		[FieldOffset(Offset = "0x10")]
		private string _003CTitle_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400029F")]
		[FieldOffset(Offset = "0x18")]
		private string _003CBody_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x40002A0")]
		[FieldOffset(Offset = "0x20")]
		private string _003CIcon_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x40002A1")]
		[FieldOffset(Offset = "0x28")]
		private string _003CSound_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x40002A2")]
		[FieldOffset(Offset = "0x30")]
		private string _003CBadge_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x40002A3")]
		[FieldOffset(Offset = "0x38")]
		private string _003CTag_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x40002A4")]
		[FieldOffset(Offset = "0x40")]
		private string _003CColor_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x40002A5")]
		[FieldOffset(Offset = "0x48")]
		private string _003CClickAction_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x40002A6")]
		[FieldOffset(Offset = "0x50")]
		private string _003CBodyLocalizationKey_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x40002A7")]
		[FieldOffset(Offset = "0x58")]
		private IEnumerable<string> _003CBodyLocalizationArgs_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x40002A8")]
		[FieldOffset(Offset = "0x60")]
		private string _003CTitleLocalizationKey_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x40002A9")]
		[FieldOffset(Offset = "0x68")]
		private IEnumerable<string> _003CTitleLocalizationArgs_003Ek__BackingField;

		[Token(Token = "0x1700018C")]
		public string Title
		{
			[CompilerGenerated]
			[Token(Token = "0x6000546")]
			[Address(RVA = "0xA567B0", Offset = "0xA567B0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Title>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Title;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000547")]
			[Address(RVA = "0xA567B8", Offset = "0xA567B8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Title>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CTitle_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700018D")]
		public string Body
		{
			[CompilerGenerated]
			[Token(Token = "0x6000548")]
			[Address(RVA = "0xA567C0", Offset = "0xA567C0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Body>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Body;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000549")]
			[Address(RVA = "0xA567C8", Offset = "0xA567C8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Body>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CBody_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700018E")]
		public string Icon
		{
			[CompilerGenerated]
			[Token(Token = "0x600054A")]
			[Address(RVA = "0xA567D0", Offset = "0xA567D0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Icon>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Icon;
			}
			[CompilerGenerated]
			[Token(Token = "0x600054B")]
			[Address(RVA = "0xA567D8", Offset = "0xA567D8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Icon>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CIcon_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700018F")]
		public string Sound
		{
			[CompilerGenerated]
			[Token(Token = "0x600054C")]
			[Address(RVA = "0xA567E0", Offset = "0xA567E0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Sound>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Sound;
			}
			[CompilerGenerated]
			[Token(Token = "0x600054D")]
			[Address(RVA = "0xA567E8", Offset = "0xA567E8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Sound>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CSound_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000190")]
		public string Badge
		{
			[CompilerGenerated]
			[Token(Token = "0x600054E")]
			[Address(RVA = "0xA567F0", Offset = "0xA567F0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Badge>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Badge;
			}
			[CompilerGenerated]
			[Token(Token = "0x600054F")]
			[Address(RVA = "0xA567F8", Offset = "0xA567F8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Badge>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CBadge_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000191")]
		public string Tag
		{
			[CompilerGenerated]
			[Token(Token = "0x6000550")]
			[Address(RVA = "0xA56800", Offset = "0xA56800", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Tag>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Tag;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000551")]
			[Address(RVA = "0xA56808", Offset = "0xA56808", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Tag>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CTag_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000192")]
		public string Color
		{
			[CompilerGenerated]
			[Token(Token = "0x6000552")]
			[Address(RVA = "0xA56810", Offset = "0xA56810", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Color>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Color;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000553")]
			[Address(RVA = "0xA56818", Offset = "0xA56818", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Color>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CColor_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000193")]
		public string ClickAction
		{
			[CompilerGenerated]
			[Token(Token = "0x6000554")]
			[Address(RVA = "0xA56820", Offset = "0xA56820", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<ClickAction>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ClickAction;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000555")]
			[Address(RVA = "0xA56828", Offset = "0xA56828", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<ClickAction>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CClickAction_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000194")]
		public string BodyLocalizationKey
		{
			[CompilerGenerated]
			[Token(Token = "0x6000556")]
			[Address(RVA = "0xA56830", Offset = "0xA56830", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<BodyLocalizationKey>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return BodyLocalizationKey;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000557")]
			[Address(RVA = "0xA56838", Offset = "0xA56838", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<BodyLocalizationKey>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CBodyLocalizationKey_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000195")]
		public IEnumerable<string> BodyLocalizationArgs
		{
			[CompilerGenerated]
			[Token(Token = "0x6000558")]
			[Address(RVA = "0xA56840", Offset = "0xA56840", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<BodyLocalizationArgs>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return BodyLocalizationArgs;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000559")]
			[Address(RVA = "0xA56848", Offset = "0xA56848", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<BodyLocalizationArgs>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CBodyLocalizationArgs_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000196")]
		public string TitleLocalizationKey
		{
			[CompilerGenerated]
			[Token(Token = "0x600055A")]
			[Address(RVA = "0xA56850", Offset = "0xA56850", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<TitleLocalizationKey>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return TitleLocalizationKey;
			}
			[CompilerGenerated]
			[Token(Token = "0x600055B")]
			[Address(RVA = "0xA56858", Offset = "0xA56858", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<TitleLocalizationKey>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CTitleLocalizationKey_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000197")]
		public IEnumerable<string> TitleLocalizationArgs
		{
			[CompilerGenerated]
			[Token(Token = "0x600055C")]
			[Address(RVA = "0xA56860", Offset = "0xA56860", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<TitleLocalizationArgs>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return TitleLocalizationArgs;
			}
			[CompilerGenerated]
			[Token(Token = "0x600055D")]
			[Address(RVA = "0xA56868", Offset = "0xA56868", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<TitleLocalizationArgs>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CTitleLocalizationArgs_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x600055E")]
		[Address(RVA = "0xA56870", Offset = "0xA56870", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FirebaseNotification()
		{
		}
	}
}
