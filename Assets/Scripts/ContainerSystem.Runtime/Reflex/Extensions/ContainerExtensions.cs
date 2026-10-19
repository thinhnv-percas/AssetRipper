using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Core;
using Reflex.Logging;

namespace Reflex.Extensions
{
	[Token(Token = "0x2000022")]
	public static class ContainerExtensions
	{
		[Token(Token = "0x4000033")]
		internal static readonly ConditionalWeakTable<Container, ContainerDebugProperties> _containerDebugProperties;

		[Token(Token = "0x600005F")]
		[Address(RVA = "0x3F309B8", Offset = "0x3F309B8", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0023;\nL_0023:\n\treturnVal1 = System.Runtime.CompilerServices.ConditionalWeakTable`2<Reflex.Core.Container, Reflex.Logging.ContainerDebugProperties>::GetOrCreateValue(v49._containerDebugProperties, container);\n\treturn returnVal1;\n")]
		internal static ContainerDebugProperties GetDebugProperties(this Container container)
		{
			return _containerDebugProperties.GetOrCreateValue(container);
		}

		[Token(Token = "0x6000060")]
		[Address(RVA = "0x3F339E0", Offset = "0x3F339E0", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\treturn;\nL_0020:\n\tv49 = new System.Runtime.CompilerServices.ConditionalWeakTable`2<Reflex.Core.Container, Reflex.Logging.ContainerDebugProperties>();\n\tSystem.Runtime.CompilerServices.ConditionalWeakTable`2<Reflex.Core.Container, Reflex.Logging.ContainerDebugProperties>::.ctor(v49);\n\tv58._containerDebugProperties = v49;\n")]
		static ContainerExtensions()
		{
			ConditionalWeakTable<Container, ContainerDebugProperties> containerDebugProperties = new ConditionalWeakTable<Container, ContainerDebugProperties>();
			_containerDebugProperties = containerDebugProperties;
		}
	}
}
