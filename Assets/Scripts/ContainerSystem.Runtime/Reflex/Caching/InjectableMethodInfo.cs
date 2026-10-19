using System.Reflection;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Reflex.Caching
{
	[Token(Token = "0x200003A")]
	internal sealed class InjectableMethodInfo
	{
		[Token(Token = "0x4000056")]
		[FieldOffset(Offset = "0x10")]
		public readonly MethodInfo MethodInfo;

		[Token(Token = "0x4000057")]
		[FieldOffset(Offset = "0x18")]
		public readonly ParameterInfo[] Parameters;

		[Token(Token = "0x60000CA")]
		[Address(RVA = "0x3F37D04", Offset = "0x3F37D04", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.MethodInfo = methodInfo;\n\tv38 = System.Reflection.MethodBase::GetParameters(methodInfo);\n\tthis.Parameters = v38;\n\treturn;\n")]
		public InjectableMethodInfo(MethodInfo methodInfo)
		{
			MethodInfo = methodInfo;
			ParameterInfo[] parameters = methodInfo.GetParameters();
			Parameters = parameters;
		}
	}
}
