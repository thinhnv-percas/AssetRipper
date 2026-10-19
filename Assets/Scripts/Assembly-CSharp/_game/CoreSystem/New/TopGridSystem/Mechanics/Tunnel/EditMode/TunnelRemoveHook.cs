using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.TopGridSystem.EditMode;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Data;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Tags;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.EditMode
{
	[Token(Token = "0x200015F")]
	public class TunnelRemoveHook : IEntityRemoveHook
	{
		[Inject(false)]
		[Token(Token = "0x4000469")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Token(Token = "0x60006BC")]
		[Address(RVA = "0x3E548D8", Offset = "0x3E548D8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void OnBeforeRemove(IReadOnlyList<Entity> entities)
		{
		}

		[Token(Token = "0x60006BD")]
		[Address(RVA = "0x3E548DC", Offset = "0x3E548DC", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_001A:\n\tv47 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, entity);\n\tv55 = ~v47;\n\tif (v55) goto L_0039;\n\tv61 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv63 = ~v61;\n\tif (v63) goto L_0039;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Data.TunnelQueueHelper::DestroyAllQueuedFor(this._em, entity);\n\treturn;\nL_0039:\n\treturn;\n")]
		public void OnBeforeDestroyEntity(Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TunnelRemoveHook::OnBeforeDestroyEntity");
		}

		[Token(Token = "0x60006BE")]
		[Address(RVA = "0x3E54AB0", Offset = "0x3E54AB0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void OnAfterRemove()
		{
		}

		[Token(Token = "0x60006BF")]
		[Address(RVA = "0x3E53B8C", Offset = "0x3E53B8C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public TunnelRemoveHook()
		{
		}
	}
}
