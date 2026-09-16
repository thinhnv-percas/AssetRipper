using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile.Internal
{
	[Token(Token = "0x20000B7")]
	public class RenameAttribute : PropertyAttribute
	{
		[CompilerGenerated]
		[Token(Token = "0x40003A3")]
		[FieldOffset(Offset = "0x10")]
		private string _003CNewName_003Ek__BackingField;

		[Token(Token = "0x17000221")]
		public string NewName
		{
			[CompilerGenerated]
			[Token(Token = "0x60006E5")]
			[Address(RVA = "0xB50D00", Offset = "0xB50D00", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<NewName>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return NewName;
			}
			[CompilerGenerated]
			[Token(Token = "0x60006E6")]
			[Address(RVA = "0xB50D08", Offset = "0xB50D08", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<NewName>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CNewName_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x60006E7")]
		[Address(RVA = "0xB50D10", Offset = "0xB50D10", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.PropertyAttribute::.ctor(this);\n\tthis.<NewName>k__BackingField = name;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RenameAttribute(string name)
		{
			NewName = name;
		}
	}
}
