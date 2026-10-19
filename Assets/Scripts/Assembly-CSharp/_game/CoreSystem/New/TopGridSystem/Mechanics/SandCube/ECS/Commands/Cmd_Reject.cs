using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Commands
{
	[StructLayout((LayoutKind)0, Size = 1)]
	[Token(Token = "0x20001A5")]
	public struct Cmd_Reject : IEntityData
	{
		[Token(Token = "0x60007A4")]
		[Address(RVA = "0x3E6BC74", Offset = "0x3E6BC74", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv55 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(*([builder @ X1 (_game.BaseLayerSystems.EntitySystem.EntityBuilder&)]), *([this @ X0 (_game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Commands.Cmd_Reject)]));\n\treturn;\n")]
		public unsafe void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Cmd_Reject::Apply");
		}
	}
}
