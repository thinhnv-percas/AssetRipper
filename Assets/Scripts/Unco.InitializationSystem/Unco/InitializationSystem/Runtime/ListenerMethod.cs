using System;
using System.Reflection;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.InitializationSystem.Runtime
{
	[Token(Token = "0x2000009")]
	internal struct ListenerMethod
	{
		[Token(Token = "0x400000C")]
		[FieldOffset(Offset = "0x0")]
		internal readonly Type[] dependencies;

		[Token(Token = "0x400000D")]
		[FieldOffset(Offset = "0x8")]
		internal readonly MethodInfo methodInfo;

		[Token(Token = "0x400000E")]
		[FieldOffset(Offset = "0x10")]
		internal readonly object owner;

		[Token(Token = "0x6000019")]
		[Address(RVA = "0x81B0CE0", Offset = "0x81B0CE0", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.methodInfo = methodInfo;\n\tthis.owner = owner;\n\tthis.dependencies = dependencies;\n\treturn;\n")]
		internal ListenerMethod(object owner, MethodInfo methodInfo, Type[] dependencies)
		{
			this.methodInfo = methodInfo;
			this.owner = owner;
			this.dependencies = dependencies;
		}
	}
}
