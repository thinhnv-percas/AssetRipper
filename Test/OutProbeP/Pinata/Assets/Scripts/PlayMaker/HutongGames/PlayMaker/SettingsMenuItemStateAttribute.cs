using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x73EA78", Offset = "0x73EA78")]
	[Token(Token = "0x2000030")]
	public sealed class SettingsMenuItemStateAttribute : Attribute
	{
		[CompilerGenerated]
		[Token(Token = "0x40000DE")]
		[FieldOffset(Offset = "0x10")]
		private string _003CMenuItem_003Ek__BackingField;

		[Token(Token = "0x17000035")]
		public string MenuItem
		{
			[CompilerGenerated]
			[Token(Token = "0x6000102")]
			[Address(RVA = "0xE53AFC", Offset = "0xE53AFC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<MenuItem>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MenuItem;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000103")]
			[Address(RVA = "0xE53B04", Offset = "0xE53B04", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<MenuItem>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CMenuItem_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x6000104")]
		[Address(RVA = "0xE53B0C", Offset = "0xE53B0C", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tthis.<MenuItem>k__BackingField = menuItem;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SettingsMenuItemStateAttribute(string menuItem)
		{
			MenuItem = menuItem;
		}
	}
}
