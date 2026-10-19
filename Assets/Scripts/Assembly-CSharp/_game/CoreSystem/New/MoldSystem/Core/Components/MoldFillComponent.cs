using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;

namespace _game.CoreSystem.New.MoldSystem.Core.Components
{
	[Serializable]
	[Token(Token = "0x2000308")]
	public struct MoldFillComponent : IEntityData
	{
		[Token(Token = "0x400093D")]
		[FieldOffset(Offset = "0x0")]
		public int capacity;

		[Token(Token = "0x400093E")]
		[FieldOffset(Offset = "0x4")]
		public int dataFill;

		[Token(Token = "0x400093F")]
		[FieldOffset(Offset = "0x8")]
		public int visualFill;

		[Token(Token = "0x4000940")]
		[FieldOffset(Offset = "0xC")]
		public bool dataComplete;

		[Token(Token = "0x4000941")]
		[FieldOffset(Offset = "0xD")]
		public bool visualComplete;

		[Token(Token = "0x6000D52")]
		[Address(RVA = "0x3EED790", Offset = "0x3EED790", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\nL_0024:\n\tv56 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(*([builder @ X1 (_game.BaseLayerSystems.EntitySystem.EntityBuilder&)]), this.capacity);\n\treturn;\n")]
		public void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldFillComponent::Apply");
		}
	}
}
