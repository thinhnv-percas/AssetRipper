using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;

namespace _game.CoreSystem.CollisionSystem.ECS.Tags
{
	[Serializable]
	[StructLayout((LayoutKind)0, Size = 1)]
	[Token(Token = "0x2000517")]
	public struct CollisionBlockerTag : IEntityData
	{
		[Token(Token = "0x6001549")]
		[Address(RVA = "0x3D0F36C", Offset = "0x3D0F36C", Length = "0x64")]
		public unsafe void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CollisionBlockerTag::Apply");
		}
	}
}
