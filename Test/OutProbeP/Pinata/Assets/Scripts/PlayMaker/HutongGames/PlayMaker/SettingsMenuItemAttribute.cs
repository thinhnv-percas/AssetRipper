using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x73EA50", Offset = "0x73EA50")]
	[Token(Token = "0x200002E")]
	public sealed class SettingsMenuItemAttribute : Attribute
	{
		[CompilerGenerated]
		[Token(Token = "0x40000DC")]
		[FieldOffset(Offset = "0x10")]
		private string _003CMenuItem_003Ek__BackingField;

		[Token(Token = "0x17000033")]
		public string MenuItem
		{
			[CompilerGenerated]
			[Token(Token = "0x60000FC")]
			[Address(RVA = "0xE53AC0", Offset = "0xE53AC0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<MenuItem>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MenuItem;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000FD")]
			[Address(RVA = "0xE53AC8", Offset = "0xE53AC8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<MenuItem>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CMenuItem_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x60000FE")]
		[Address(RVA = "0xE53AD0", Offset = "0xE53AD0", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tthis.<MenuItem>k__BackingField = menuItem;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SettingsMenuItemAttribute(string menuItem)
		{
			MenuItem = menuItem;
		}
	}
}
