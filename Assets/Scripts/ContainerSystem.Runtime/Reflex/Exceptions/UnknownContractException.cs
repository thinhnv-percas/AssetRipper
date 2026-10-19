using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Extensions;

namespace Reflex.Exceptions
{
	[Token(Token = "0x2000031")]
	public sealed class UnknownContractException : Exception
	{
		[Token(Token = "0x6000087")]
		[Address(RVA = "0x3F3558C", Offset = "0x3F3558C", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\nL_0045:\n\tSystem.Exception::.ctor(this, v73);\n\treturn;\nL_0022:\n\tgoto L_002C;\nL_002C:\n\tv66 = Reflex.Extensions.TypeExtensions::GetFullName(contract);\n\tv73 = System.String::Concat(\"Cannot resolve contract '\", v66, \"'.\");\n\tgoto L_0045;\n")]
		public UnknownContractException(Type contract)
		{
			string fullName = contract.GetFullName();
			string message = "Cannot resolve contract '" + fullName + "'.";
		}

		[Token(Token = "0x6000088")]
		[Address(RVA = "0x3F3565C", Offset = "0x3F3565C", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\nL_001D:\n\tv49 = Reflex.Extensions.TypeExtensions::GetFullName(v44);\n\treturnVal1 = System.String::Concat(\"Cannot resolve contract '\", v49, \"'.\");\n\treturn returnVal1;\n")]
		private static string GenerateMessage(Type contract)
		{
			Type type = default(Type);
			string fullName = type.GetFullName();
			return "Cannot resolve contract '" + fullName + "'.";
		}
	}
}
