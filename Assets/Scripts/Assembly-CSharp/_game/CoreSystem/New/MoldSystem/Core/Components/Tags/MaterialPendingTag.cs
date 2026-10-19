using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;

namespace _game.CoreSystem.New.MoldSystem.Core.Components.Tags
{
	[StructLayout((LayoutKind)0, Size = 1)]
	[Token(Token = "0x2000314")]
	public struct MaterialPendingTag : IEntityData
	{
		[Token(Token = "0x6000D5E")]
		[Address(RVA = "0x3EEDBE8", Offset = "0x3EEDBE8", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv55 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(*([builder @ X1 (_game.BaseLayerSystems.EntitySystem.EntityBuilder&)]), *([this @ X0 (_game.CoreSystem.New.MoldSystem.Core.Components.Tags.MaterialPendingTag)]));\n\treturn;\n")]
		public unsafe void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MaterialPendingTag::Apply");
		}
	}
}
