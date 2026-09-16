using System;
using System.Collections.Generic;
using System.Reflection;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Sirenix.Utilities
{
	[Serializable]
	[AttributeAttribute(Type = typeof(DefaultMemberAttribute), RVA = "0x741B7C", Offset = "0x741B7C")]
	[Token(Token = "0x2000005")]
	public class DoubleLookupDictionary<TFirstKey, TSecondKey, TValue> : Dictionary<TFirstKey, Dictionary<TSecondKey, TValue>>
	{
		[Token(Token = "0x4000010")]
		[FieldOffset(Offset = "0x0")]
		private readonly IEqualityComparer<TSecondKey> secondKeyComparer;

		[Token(Token = "0x600000C")]
		[Address(RVA = "0x11E7038", Offset = "0x11E7038", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = System.Collections.Generic.Dictionary`2<TFirstKey, System.Collections.Generic.Dictionary`2<TSecondKey, TValue>>::.ctor(this);\n\tv39 = System.Collections.Generic.EqualityComparer`1<TSecondKey>::get_Default();\n\tthis.secondKeyComparer = v39;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DoubleLookupDictionary()
		{
			IEqualityComparer<TSecondKey> equalityComparer = EqualityComparer<TSecondKey>.Default;
			secondKeyComparer = equalityComparer;
		}
	}
}
