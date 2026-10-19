using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.BaseLayerSystems.EntitySystem.CommonComponents
{
	[Serializable]
	[Token(Token = "0x200007E")]
	public struct TransformComponent : IEntityData
	{
		[Token(Token = "0x4000140")]
		[FieldOffset(Offset = "0x0")]
		public Vector3 pos;

		[Token(Token = "0x4000141")]
		[FieldOffset(Offset = "0xC")]
		public Vector3 euler;

		[Token(Token = "0x4000142")]
		[FieldOffset(Offset = "0x18")]
		public Vector3 scale;

		[Token(Token = "0x600022D")]
		[Address(RVA = "0x3C74FF8", Offset = "0x3C74FF8", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tv49 = this.pos;\n\tv55 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(*([builder @ X1 (_game.BaseLayerSystems.EntitySystem.EntityBuilder&)]), &v49 @ stack_-60_v1 (UnityEngine.Vector3));\n\treturn;\n")]
		public unsafe void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TransformComponent::Apply");
		}
	}
}
