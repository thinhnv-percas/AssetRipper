using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.InitializationSystem.Runtime
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
	[Token(Token = "0x200000F")]
	public class OnInitializeAttribute : InitializationAttribute
	{
		[Token(Token = "0x600002E")]
		[Address(RVA = "0x81B1B84", Offset = "0x81B1B84", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tthis.TargetTypes = targetTypes;\n\treturn;\n")]
		public OnInitializeAttribute(params Type[] targetTypes)
			: base(targetTypes)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("OnInitializeAttribute::.ctor");
		}
	}
}
