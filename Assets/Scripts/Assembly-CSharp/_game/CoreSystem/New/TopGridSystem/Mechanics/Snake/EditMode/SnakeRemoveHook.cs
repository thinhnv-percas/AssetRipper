using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.TopGridSystem.EditMode;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.ECS.Data;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.EditMode
{
	[Token(Token = "0x2000175")]
	public class SnakeRemoveHook : IEntityRemoveHook
	{
		[Inject(false)]
		[Token(Token = "0x4000497")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Inject(true)]
		[Token(Token = "0x4000498")]
		[FieldOffset(Offset = "0x18")]
		private SnakeEditorMutations _mutations;

		[Inject(true)]
		[Token(Token = "0x4000499")]
		[FieldOffset(Offset = "0x20")]
		private SnakeBlockerVisualHandler _visualHandler;

		[Token(Token = "0x400049A")]
		[FieldOffset(Offset = "0x28")]
		private readonly HashSet<int> _touchedSnakes;

		[Token(Token = "0x400049B")]
		[FieldOffset(Offset = "0x30")]
		private readonly HashSet<int> _headlessSnakes;

		[Token(Token = "0x6000716")]
		[Address(RVA = "0x3E5EFB0", Offset = "0x3E5EFB0", Length = "0x25C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tSystem.Collections.Generic.HashSet`1<System.Int32>::Clear(this._touchedSnakes);\n\tSystem.Collections.Generic.HashSet`1<System.Int32>::Clear(this._headlessSnakes);\n\tv141 = entities == 0;\n\tif (v141) goto L_00F4;\n\tv148 = 0;\n\tgoto L_0049;\nL_0047:\n\tv148 = v148 + 1;\n\tv121 = *([v299 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv121 = v121 + 0x10;\n\tv305 = v327 - 1;\n\tv304 = v327 != 1;\n\tv327 = v305;\n\tif (v304) goto L_0054;\nL_006D:\n\tv138 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(entities);\n\tv80 = v148 < v138;\n\tif (v80) goto L_0092;\n\tgoto L_00F4;\nL_007C:\n\tv74 = *([v121 @ X10_v14]) << 4;\n\tv349 = v299 + v74;\n\tv350 = v349 + 0x138;\n\t*([v350 @ X0_v30])(v139, entities, *([v350 @ X0_v30+8]), v77, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv81 = v148 >= v139;\n\tif (v81) goto L_00F4;\nL_0092:\n\tgoto L_00B9;\n\tv434 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v433);\n\tv435 = ~v434;\n\tv77 = 0;\n\tif (v435) goto L_0047;\n\tv438 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v433);\n\tv441 = ~v438;\n\tv77 = Il2CppMethodInfo;\n\tif (v441) goto L_0047;\n\tv443 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v433);\n\tv439 = System.Collections.Generic.HashSet`1<System.Int32>::Add(this._touchedSnakes, v443);\n\tv444 = v443 & 0x8000000000000000;\n\tv445 = v444 == 0;\n\tv446 = ~v445;\n\tif (v446) goto L_00E5;\n\tv447 = v433 & 0x80000000;\n\tv442 = v447 == 0;\n\tv77 = Il2CppMethodInfo;\n\tif (v442) goto L_0047;\nL_00E5:\n\tv440 = System.Collections.Generic.HashSet`1<System.Int32>::Add(this._headlessSnakes, v443);\n\tv77 = Il2CppMethodInfo;\n\tgoto L_0047;\nL_00F4:\n\treturn;\nL_002B:\n\tv57 = this._visualHandler == 0;\n\tif (v57) goto L_00F4;\nL_0049:\n\tv299 = entities->klass;\n\tv327 = entities->klass->interface_offsets_count;\n\tv142 = *([v299 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v142) goto L_006D;\nL_0054:\n\tv340 = *([v121 @ X10_v14-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v340) goto L_007C;\nL_00B9:\n\tv433 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(entities, v148);\n")]
		public void OnBeforeRemove(IReadOnlyList<Entity> entities)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SnakeRemoveHook::OnBeforeRemove");
		}

		[Token(Token = "0x6000717")]
		[Address(RVA = "0x3E5F21C", Offset = "0x3E5F21C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void OnBeforeDestroyEntity(Entity entity)
		{
		}

		[Token(Token = "0x6000718")]
		[Address(RVA = "0x3E5F220", Offset = "0x3E5F220", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv44 = v39.Count == 0;\n\tif (v44) goto L_004F;\n\tv74 = this._headlessSnakes;\n\tv47 = v74.Count < 1;\n\tif (v47) goto L_0030;\n\tv117 = this._mutations == 0;\n\tif (v117) goto L_0030;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Snake.EditMode.SnakeEditorMutations::UnmakeSnakesById(this._mutations, v74);\nL_0030:\n\tv121 = this._mutations == 0;\n\tif (v121) goto L_0035;\n\tv74 = this._touchedSnakes;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Snake.EditMode.SnakeEditorMutations::DemoteLoneSurvivors(this._mutations, this._touchedSnakes);\nL_0035:\n\tv124 = this._visualHandler == 0;\n\tif (v124) goto L_003E;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler::ResyncAll(this._visualHandler);\nL_003E:\n\tSystem.Collections.Generic.HashSet`1<System.Int32>::Clear(this._touchedSnakes);\n\tSystem.Collections.Generic.HashSet`1<System.Int32>::Clear(this._headlessSnakes);\n\treturn;\nL_004F:\n\treturn;\nL_0015:\n\tv39 = this._touchedSnakes;\n")]
		public void OnAfterRemove()
		{
			HashSet<int> touchedSnakes = _touchedSnakes;
			if (touchedSnakes.Count != 0)
			{
				HashSet<int> headlessSnakes = _headlessSnakes;
				if (headlessSnakes.Count >= 1 && _mutations != null)
				{
					_mutations.UnmakeSnakesById(headlessSnakes);
				}
				if (_mutations != null)
				{
					headlessSnakes = _touchedSnakes;
					_mutations.DemoteLoneSurvivors(_touchedSnakes);
				}
				if (_visualHandler != null)
				{
					_visualHandler.ResyncAll();
				}
				_touchedSnakes.Clear();
				_headlessSnakes.Clear();
			}
		}

		[Token(Token = "0x6000719")]
		[Address(RVA = "0x3E59BDC", Offset = "0x3E59BDC", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv58 = new System.Collections.Generic.HashSet`1<System.Int32>();\n\tSystem.Collections.Generic.HashSet`1<System.Int32>::.ctor(v58);\n\tthis._headlessSnakes = v58;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.HashSet`1<System.Int32>();\n\tSystem.Collections.Generic.HashSet`1<System.Int32>::.ctor(v48);\n\tthis._touchedSnakes = v48;\n")]
		public SnakeRemoveHook()
		{
			HashSet<int> touchedSnakes = new HashSet<int>();
			_touchedSnakes = touchedSnakes;
			HashSet<int> headlessSnakes = new HashSet<int>();
			_headlessSnakes = headlessSnakes;
		}
	}
}
