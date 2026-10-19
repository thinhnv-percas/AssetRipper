using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.IdentifierTags
{
	[StructLayout((LayoutKind)0, Size = 1)]
	[Token(Token = "0x20001B5")]
	public struct PinNodeTag : IEntityData
	{
		[Token(Token = "0x60007E9")]
		[Address(RVA = "0x3E716AC", Offset = "0x3E716AC", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv55 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(*([builder @ X1 (_game.BaseLayerSystems.EntitySystem.EntityBuilder&)]), *([this @ X0 (_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.IdentifierTags.PinNodeTag)]));\n\treturn;\n")]
		public unsafe void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PinNodeTag::Apply");
		}
	}
}
