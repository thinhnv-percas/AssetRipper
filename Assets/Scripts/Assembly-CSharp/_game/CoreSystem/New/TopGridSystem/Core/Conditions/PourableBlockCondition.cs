using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.TopGridSystem.Core.Handlers;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.ECS.Tags;

namespace _game.CoreSystem.New.TopGridSystem.Core.Conditions
{
	[Token(Token = "0x200027D")]
	public abstract class PourableBlockCondition<TTag> : IPourableBlockCondition where TTag : struct, IEntityData
	{
		[Token(Token = "0x170000D2")]
		public abstract BlockReason Reason
		{
			[Token(Token = "0x6000B2A")]
			get;
		}

		[Token(Token = "0x170000D3")]
		public virtual bool AffectsCover
		{
			[Token(Token = "0x6000B2B")]
			[Address(RVA = "0x5ED992C", Offset = "0x5ED992C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n")]
			get
			{
				return true;
			}
		}

		[Token(Token = "0x6000B2C")]
		[Address(RVA = "0x5ED9934", Offset = "0x5ED9934", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(em, entity);\n\treturn returnVal1;\n")]
		public bool HasBlockTag(EntityManager em, Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PourableBlockCondition::HasBlockTag");
			return default;
		}

		[Token(Token = "0x6000B2D")]
		[Address(RVA = "0x5ED9960", Offset = "0x5ED9960", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(em, entity);\n\tv42 = v26 == 0;\n\tif (v42) goto L_002B;\n\treturn;\nL_002B:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(em, entity, 0);\n\treturn;\n")]
		public void AddBlockTagIfMissing(EntityManager em, Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PourableBlockCondition::AddBlockTagIfMissing");
		}

		[Token(Token = "0x6000B2E")]
		[Address(RVA = "0x5ED99D8", Offset = "0x5ED99D8", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(em, entity);\n\tv41 = ~v26;\n\tif (v41) goto L_002A;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::RemoveComponent(em, entity);\n\treturn;\nL_002A:\n\treturn;\n")]
		public void RemoveBlockTagIfPresent(EntityManager em, Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PourableBlockCondition::RemoveBlockTagIfPresent");
		}

		[Token(Token = "0x6000B2F")]
		public abstract bool IsBlocking(Entity entity, EntityManager em, TopGridHandler grid);

		[Token(Token = "0x6000B30")]
		[Address(RVA = "0x5ED9A4C", Offset = "0x5ED9A4C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		protected internal PourableBlockCondition()
		{
		}
	}
}
