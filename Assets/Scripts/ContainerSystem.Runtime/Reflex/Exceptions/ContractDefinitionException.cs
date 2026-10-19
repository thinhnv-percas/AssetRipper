using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Extensions;

namespace Reflex.Exceptions
{
	[Token(Token = "0x200002B")]
	internal sealed class ContractDefinitionException : Exception
	{
		[Token(Token = "0x6000077")]
		[Address(RVA = "0x3F34468", Offset = "0x3F34468", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tgoto L_004E;\nL_004E:\n\tSystem.Exception::.ctor(this, v82);\n\treturn;\nL_0025:\n\tgoto L_002F;\nL_002F:\n\tv71 = Reflex.Extensions.TypeExtensions::GetFullName(concrete);\n\tv76 = Reflex.Extensions.TypeExtensions::GetFullName(contract);\n\tv82 = System.String::Concat(v71, \" does not implement \", v76, \" contract\");\n")]
		public ContractDefinitionException(Type concrete, Type contract)
		{
			string fullName = concrete.GetFullName();
			string fullName2 = contract.GetFullName();
			string message = fullName + " does not implement " + fullName2 + " contract";
		}

		[Token(Token = "0x6000078")]
		[Address(RVA = "0x3F34554", Offset = "0x3F34554", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\treturn returnVal1;\nL_0020:\n\tv54 = Reflex.Extensions.TypeExtensions::GetFullName(v49);\n\tv60 = Reflex.Extensions.TypeExtensions::GetFullName(contract);\n\treturnVal1 = System.String::Concat(v54, \" does not implement \", v60, \" contract\");\n")]
		private static string GenerateMessage(Type concrete, Type contract)
		{
			Type type = default(Type);
			string fullName = type.GetFullName();
			string fullName2 = contract.GetFullName();
			return fullName + " does not implement " + fullName2 + " contract";
		}
	}
}
