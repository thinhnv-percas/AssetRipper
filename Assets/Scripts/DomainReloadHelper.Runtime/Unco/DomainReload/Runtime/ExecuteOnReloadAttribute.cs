using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.DomainReload.Runtime
{
	[AttributeUsage(AttributeTargets.Method)]
	[Token(Token = "0x2000005")]
	public class ExecuteOnReloadAttribute : Attribute
	{
		[Token(Token = "0x6000006")]
		[Address(RVA = "0x3F448A8", Offset = "0x3F448A8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\treturn;\n")]
		public ExecuteOnReloadAttribute()
		{
		}
	}
}
