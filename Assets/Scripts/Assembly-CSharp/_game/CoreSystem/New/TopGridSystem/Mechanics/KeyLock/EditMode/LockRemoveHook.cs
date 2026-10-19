using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.TopGridSystem.EditMode;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.ECS.IdentifierTags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.EditMode
{
	[Token(Token = "0x20001FA")]
	public class LockRemoveHook : IEntityRemoveHook
	{
		[Inject(false)]
		[Token(Token = "0x4000659")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Inject(true)]
		[Token(Token = "0x400065A")]
		[FieldOffset(Offset = "0x18")]
		private LockVisualHandler _lockVisualHandler;

		[Token(Token = "0x400065B")]
		[FieldOffset(Offset = "0x20")]
		private bool _touched;

		[Token(Token = "0x6000909")]
		[Address(RVA = "0x3E8C6B8", Offset = "0x3E8C6B8", Length = "0x1AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv154 = 0;\n\tgoto L_002C;\nL_002A:\n\tv154 = v154 + 1;\n\tv137 = *([v190 @ X8_v5 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv137 = v137 + 0x10;\n\tv228 = v250 - 1;\n\tv227 = v250 != 1;\n\tv250 = v228;\n\tif (v227) goto L_0037;\nL_0050:\n\tv144 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(entities);\n\tv86 = v154 < v144;\n\tif (v86) goto L_0075;\n\tgoto L_00BB;\nL_005F:\n\tv74 = *([v137 @ X10_v13]) << 4;\n\tv272 = v190 + v74;\n\tv273 = v272 + 0x138;\n\t*([v273 @ X0_v22])(v145, entities, *([v273 @ X0_v22+8]), v83, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv87 = v154 >= v145;\n\tif (v87) goto L_00BB;\nL_0075:\n\tgoto L_009C;\n\tv363 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v358);\n\tv367 = ~v363;\n\tv83 = 0;\n\tif (v367) goto L_002A;\n\tv143 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v358);\n\tv147 = ~v143;\n\tv83 = Il2CppMethodInfo;\n\tif (v147) goto L_002A;\n\tthis._touched = 1;\nL_001F:\n\tthis._touched = 0;\n\tv52 = entities == 0;\n\tif (v52) goto L_00BB;\nL_002C:\n\tv190 = entities->klass;\n\tv250 = entities->klass->interface_offsets_count;\n\tv148 = *([v190 @ X8_v5 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v148) goto L_0050;\nL_0037:\n\tv263 = *([v137 @ X10_v13-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v263) goto L_005F;\nL_00BB:\n\treturn;\nL_009C:\n\tv358 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(entities, v154);\n")]
		public void OnBeforeRemove(IReadOnlyList<Entity> entities)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LockRemoveHook::OnBeforeRemove");
		}

		[Token(Token = "0x600090A")]
		[Address(RVA = "0x3E8C864", Offset = "0x3E8C864", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void OnBeforeDestroyEntity(Entity entity)
		{
		}

		[Token(Token = "0x600090B")]
		[Address(RVA = "0x3E8C868", Offset = "0x3E8C868", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = v21._touched != 1;\n\tif (v11) goto L_001F;\n\tv13 = v21._lockVisualHandler == 0;\n\tif (v13) goto L_001E;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.LockVisualHandler::ReconcileGroupVisuals(v21._lockVisualHandler);\nL_001F:\n\treturn;\nL_001E:\n\tv21._touched = 0;\n")]
		public void OnAfterRemove()
		{
			if (_touched)
			{
				if (_lockVisualHandler != null)
				{
					_lockVisualHandler.ReconcileGroupVisuals();
				}
				_touched = false;
			}
		}

		[Token(Token = "0x600090C")]
		[Address(RVA = "0x3E8B304", Offset = "0x3E8B304", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public LockRemoveHook()
		{
		}
	}
}
