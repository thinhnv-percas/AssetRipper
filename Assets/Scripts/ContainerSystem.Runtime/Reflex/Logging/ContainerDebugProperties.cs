using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Reflex.Logging
{
	[Token(Token = "0x2000018")]
	public sealed class ContainerDebugProperties
	{
		[Token(Token = "0x1700000F")]
		[field: Token(Token = "0x400002A")]
		[field: FieldOffset(Offset = "0x10")]
		public List<CallSite> BuildCallsite
		{
			[Token(Token = "0x6000048")]
			[Address(RVA = "0x3F316F4", Offset = "0x3F316F4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.BuildCallsite;\n")]
			get;
		}

		[Token(Token = "0x6000049")]
		[Address(RVA = "0x3F316FC", Offset = "0x3F316FC", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.List`1<CallSite>();\n\tSystem.Collections.Generic.List`1<CallSite>::.ctor(v48);\n\tthis.BuildCallsite = v48;\n")]
		public ContainerDebugProperties()
		{
			List<CallSite> list = new List<CallSite>();
			BuildCallsite = list;
		}
	}
}
