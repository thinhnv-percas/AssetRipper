using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Resolvers;

namespace Reflex.Extensions
{
	[Token(Token = "0x2000029")]
	internal static class ResolverExtensions
	{
		[Token(Token = "0x400003E")]
		internal static readonly ConditionalWeakTable<IResolver, ResolverDebugProperties> _registry;

		[Token(Token = "0x6000072")]
		[Address(RVA = "0x3F2FD94", Offset = "0x3F2FD94", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0023;\nL_0023:\n\treturnVal1 = System.Runtime.CompilerServices.ConditionalWeakTable`2<Reflex.Resolvers.IResolver, Reflex.Resolvers.ResolverDebugProperties>::GetOrCreateValue(v49._registry, resolver);\n\treturn returnVal1;\n")]
		public static ResolverDebugProperties GetDebugProperties(this IResolver resolver)
		{
			return _registry.GetOrCreateValue(resolver);
		}

		[Token(Token = "0x6000073")]
		[Address(RVA = "0x3F33F98", Offset = "0x3F33F98", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\treturn;\nL_0020:\n\tv49 = new System.Runtime.CompilerServices.ConditionalWeakTable`2<Reflex.Resolvers.IResolver, Reflex.Resolvers.ResolverDebugProperties>();\n\tSystem.Runtime.CompilerServices.ConditionalWeakTable`2<Reflex.Resolvers.IResolver, Reflex.Resolvers.ResolverDebugProperties>::.ctor(v49);\n\tv58._registry = v49;\n")]
		static ResolverExtensions()
		{
			ConditionalWeakTable<IResolver, ResolverDebugProperties> registry = new ConditionalWeakTable<IResolver, ResolverDebugProperties>();
			_registry = registry;
		}
	}
}
