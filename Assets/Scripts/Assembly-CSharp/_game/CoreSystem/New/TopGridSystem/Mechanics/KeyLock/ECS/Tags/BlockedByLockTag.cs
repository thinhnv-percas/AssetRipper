using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.ECS.Tags
{
	[StructLayout((LayoutKind)0, Size = 1)]
	[Token(Token = "0x20001FB")]
	public struct BlockedByLockTag : IEntityData
	{
		[Token(Token = "0x600090D")]
		[Address(RVA = "0x3E8C8A8", Offset = "0x3E8C8A8", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv55 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(*([builder @ X1 (_game.BaseLayerSystems.EntitySystem.EntityBuilder&)]), *([this @ X0 (_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.ECS.Tags.BlockedByLockTag)]));\n\treturn;\n")]
		public unsafe void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BlockedByLockTag::Apply");
		}
	}
}
