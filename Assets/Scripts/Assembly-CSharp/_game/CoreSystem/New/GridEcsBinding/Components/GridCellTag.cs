using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;

namespace _game.CoreSystem.New.GridEcsBinding.Components
{
	[Serializable]
	[StructLayout((LayoutKind)0, Size = 1)]
	[Token(Token = "0x20003D9")]
	public struct GridCellTag : IEntityData
	{
		[Token(Token = "0x600103C")]
		[Address(RVA = "0x3CAEA90", Offset = "0x3CAEA90", Length = "0x64")]
		public unsafe void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GridCellTag::Apply");
		}
	}
}
