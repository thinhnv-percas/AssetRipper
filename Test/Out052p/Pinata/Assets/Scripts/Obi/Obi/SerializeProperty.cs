using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x7449F8", Offset = "0x7449F8")]
	[Token(Token = "0x200004E")]
	public class SerializeProperty : PropertyAttribute
	{
		[CompilerGenerated]
		[Token(Token = "0x400016A")]
		[FieldOffset(Offset = "0x10")]
		private string _003CPropertyName_003Ek__BackingField;

		[Token(Token = "0x17000084")]
		public string PropertyName
		{
			[CompilerGenerated]
			[Token(Token = "0x6000370")]
			[Address(RVA = "0x1035884", Offset = "0x1035884", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<PropertyName>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return PropertyName;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000371")]
			[Address(RVA = "0x103588C", Offset = "0x103588C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<PropertyName>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CPropertyName_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x6000372")]
		[Address(RVA = "0x1035894", Offset = "0x1035894", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.PropertyAttribute::.ctor(this);\n\tthis.<PropertyName>k__BackingField = propertyName;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SerializeProperty(string propertyName)
		{
			PropertyName = propertyName;
		}
	}
}
