using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.InitializationSystem.Runtime
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
	[Token(Token = "0x2000010")]
	public class OnDeInitializeAttribute : InitializationAttribute
	{
		[Token(Token = "0x600002F")]
		[Address(RVA = "0x81B1BEC", Offset = "0x81B1BEC", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tthis.TargetTypes = targetTypes;\n\treturn;\n")]
		public OnDeInitializeAttribute(params Type[] targetTypes)
			: base(targetTypes)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("OnDeInitializeAttribute::.ctor");
		}
	}
}
