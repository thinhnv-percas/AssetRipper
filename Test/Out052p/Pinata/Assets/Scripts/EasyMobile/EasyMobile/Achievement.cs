using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile
{
	[Serializable]
	[Token(Token = "0x200003F")]
	public class Achievement : GameServicesItem
	{
		[Token(Token = "0x600038F")]
		[Address(RVA = "0xA42750", Offset = "0xA42750", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEasyMobile.GameServicesItem::.ctor(this, name, iosId, androidId);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Achievement(string name, string iosId, string androidId)
			: base(name, iosId, androidId)
		{
		}
	}
}
