using System;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Exceptions;
using Reflex.Resolvers;

namespace Reflex.Core
{
	[Token(Token = "0x2000034")]
	internal sealed class Binding
	{
		[Token(Token = "0x17000013")]
		[field: Token(Token = "0x4000045")]
		[field: FieldOffset(Offset = "0x10")]
		internal IResolver Resolver
		{
			[Token(Token = "0x600008D")]
			[Address(RVA = "0x3F3586C", Offset = "0x3F3586C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Resolver>k__BackingField;\n")]
			get;
		}

		[Token(Token = "0x17000014")]
		[field: Token(Token = "0x4000046")]
		[field: FieldOffset(Offset = "0x18")]
		internal Type[] Contracts
		{
			[Token(Token = "0x600008E")]
			[Address(RVA = "0x3F35874", Offset = "0x3F35874", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Contracts>k__BackingField;\n")]
			get;
		}

		[Token(Token = "0x600008F")]
		[Address(RVA = "0x3F3587C", Offset = "0x3F3587C", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<Resolver>k__BackingField = resolver;\n\tthis.<Contracts>k__BackingField = contracts;\n\treturn;\n")]
		private Binding(IResolver resolver, Type[] contracts)
		{
			Resolver = resolver;
			Contracts = contracts;
		}

		[Token(Token = "0x6000090")]
		[Address(RVA = "0x3F358CC", Offset = "0x3F358CC", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\nL_0025:\n\tv60 = contracts.Length < 1;\n\tif (v60) goto L_0046;\n\tv71 = 0;\nL_0031:\n\tv137 = System.Type::IsAssignableFrom(contracts[v71 @ X23_v6 (System.Int32)], concrete);\n\tv139 = v137 == 0;\n\tif (v139) goto L_0061;\n\tv71 = v71 + 1;\n\tv119 = v71 < contracts.Length;\n\tif (v119) goto L_0031;\nL_0046:\n\tv146 = new Reflex.Core.Binding();\n\tSystem.Object::.ctor(v146);\n\tv146.<Resolver>k__BackingField = resolver;\n\tv146.<Contracts>k__BackingField = contracts;\n\treturn v146;\nL_0061:\n\tv167 = 0xB28C000 + 0xBC8;\n\tv173 = new v167();\n\tReflex.Exceptions.ContractDefinitionException::.ctor(v173, concrete, v165);\n\tthrow v173;\n")]
		internal static Binding Validated(IResolver resolver, Type concrete, params Type[] contracts)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Binding::Validated");
			return default;
		}
	}
}
