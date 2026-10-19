using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.ECS.Responds
{
	[StructLayout((LayoutKind)0, Size = 1)]
	[Token(Token = "0x2000233")]
	public struct Resp_GarageOpened : IEntityData
	{
		[Token(Token = "0x60009B3")]
		[Address(RVA = "0x3E99D8C", Offset = "0x3E99D8C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv55 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(*([builder @ X1 (_game.BaseLayerSystems.EntitySystem.EntityBuilder&)]), *([this @ X0 (_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.ECS.Responds.Resp_GarageOpened)]));\n\treturn;\n")]
		public unsafe void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Resp_GarageOpened::Apply");
		}
	}
}
