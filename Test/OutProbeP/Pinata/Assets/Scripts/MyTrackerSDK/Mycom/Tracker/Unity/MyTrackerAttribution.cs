using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Mycom.Tracker.Unity
{
	[Token(Token = "0x2000005")]
	public sealed class MyTrackerAttribution
	{
		[CompilerGenerated]
		[Token(Token = "0x4000009")]
		[FieldOffset(Offset = "0x10")]
		internal string _003CDeeplink_003Ek__BackingField;

		[Token(Token = "0x17000004")]
		public string Deeplink
		{
			[CompilerGenerated]
			[Token(Token = "0x6000014")]
			[Address(RVA = "0x1623D9C", Offset = "0x1623D9C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Deeplink>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Deeplink;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000015")]
			[Address(RVA = "0x1623DA4", Offset = "0x1623DA4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Deeplink>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CDeeplink_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x6000016")]
		[Address(RVA = "0x161F810", Offset = "0x161F810", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<Deeplink>k__BackingField = deeplink;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal MyTrackerAttribution(string deeplink)
		{
			Deeplink = deeplink;
		}
	}
}
