using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.Shared;
using _game.CoreSystem.New.TopGridSystem.Core.Handlers;

namespace _game.CoreSystem.New.TopGridSystem.Core.Reconciliation
{
	[Token(Token = "0x2000255")]
	public class SandReconcile_CellStateSystem : IEcsSystem
	{
		[Inject(false)]
		[Token(Token = "0x4000726")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x4000727")]
		[FieldOffset(Offset = "0x18")]
		private TopGridHandler _gridHandler;

		[Token(Token = "0x4000728")]
		[FieldOffset(Offset = "0x20")]
		private ComponentPoolWithInterface<GridPositionComponent> _gridPosPool;

		[Token(Token = "0x4000729")]
		[FieldOffset(Offset = "0x28")]
		private ComponentPoolWithInterface<BusyComponent> _busyPool;

		[Token(Token = "0x400072A")]
		[FieldOffset(Offset = "0x30")]
		private ComponentPoolWithInterface<CellTransitionLockComponent> _lockPool;

		[Token(Token = "0x400072B")]
		[FieldOffset(Offset = "0x38")]
		private ComponentPoolWithInterface<CellStateChangedThisTickTag> _changedPool;

		[Token(Token = "0x6000A3D")]
		[Address(RVA = "0x3EABD4C", Offset = "0x3EABD4C", Length = "0x4F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0047;\nL_0047:\n\tv66 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv185 = 0xB285000 + 0x5F8;\n\tv248 = *([v66 @ X0_v5 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv365 = *([v248 @ X8_v6 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv250 = *([v248 @ X8_v6 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v250) goto L_0072;\n\tv364 = *([v248 @ X8_v6 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv364 = v364 + 0x10;\n\tv347 = v365 - 1;\n\tv327 = v365 != 1;\n\tv365 = v347;\n\tif (v327) goto L_0059;\nL_0072:\n\tv378 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v66);\n\tv379 = v378 == 0;\n\tv380 = ~v379;\n\tv416 = 0;\n\tif (v380) goto L_0082;\n\tgoto L_01C9;\nL_0078:\n\tv386 = *([v364 @ X10_v20]) << 4;\n\tv387 = v248 + v386;\n\tv388 = v387 + 0x138;\n\t*([v388 @ X0_v65])(v392, v66, *([v388 @ X0_v65+8]), v416, v473, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv393 = v392 == 0;\n\tif (v393) goto L_01C9;\nL_0082:\n\tv113 = this + 0x20;\n\tv398 = this._gridPosPool == 0;\n\tv399 = ~v398;\n\tif (v399) goto L_00BA;\n\tv467 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetPool(this._em);\n\tthis._gridPosPool = v467;\n\tv572 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetPool(this._em);\n\tthis._busyPool = v572;\n\tv656 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetPool(this._em);\n\tthis._lockPool = v656;\n\tv674 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetPool(this._em);\n\tthis._changedPool = v674;\nL_00BA:\n\tv104 = 0xB285000 + 0x780;\n\tv100 = 0xB2A0000 + 0x958;\n\tv96 = 0xB2A0000 + 0x930;\n\tv108 = 0;\n\tgoto L_00C2;\nL_00C0:\n\tv108 = v108 + 1;\n\tv436 = *([v510 @ X8_v12 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv436 = v436 + 0x10;\n\tv538 = v554 - 1;\n\tv520 = v554 != 1;\n\tv554 = v538;\n\tif (v520) goto L_00CD;\nL_00E2:\n\tv540 = 0x220C5E0(v66, *([v185 @ X27_v8 (System.Int32)]), 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v540 @ X0_v38])(v442, v66, *([v540 @ X0_v38+8]), 0, v473, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv417 = v108 < v442;\n\tif (v417) goto L_0108;\n\tgoto L_01C9;\nL_00F5:\n\tv414 = *([v436 @ X10_v15]) << 4;\n\tv574 = v510 + v414;\n\tv575 = v574 + 0x138;\n\t*([v575 @ X0_v41])(v443, v66, *([v575 @ X0_v41+8]), v416, v473, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv418 = v108 >= v443;\n\tif (v418) goto L_01C9;\nL_0108:\n\tv596 = *([v66 @ X0_v5 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv644 = *([v596 @ X8_v14 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv598 = *([v596 @ X8_v14 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v598) goto L_0128;\n\tv643 = *([v596 @ X8_v14 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv643 = v643 + 0x10;\n\tv629 = v644 - 1;\n\tv609 = v644 != 1;\n\tv644 = v629;\n\tif (v609) goto L_0113;\nL_0128:\n\tv663 = 0x220C5E0(v66, *([v104 @ X28_v8 (System.Int32)]), 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0132;\nL_012B:\n\tv659 = *([v643 @ X10_v10]) << 4;\n\tv660 = v596 + v659;\n\tv663 = v660 + 0x138;\n\tv670 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v666);\n\tv671 = ~v670;\n\tv416 = 0;\n\tif (v671) goto L_00C0;\n\tv473 = *([v100 @ X26_v8 (System.Int32)]);\n\tv701 = _game.BaseLayerSystems.EntitySystem.Core.ComponentPool`1<_game.CoreSystem.New.GridEcsBinding.Components.GridPositionComponent>::TryGet(*([v113 @ X21_v8]), v666, &v87 @ stack_-70_v5 (_game.CoreSystem.New.GridEcsBinding.Components.GridPositionComponent));\n\tv705 = ~v701;\n\tv416 = &v87 @ stack_-70_v5 (_game.CoreSystem.New.GridEcsBinding.Components.GridPositionComponent);\n\tif (v705) goto L_00C0;\n\tv473 = *([v96 @ X23_v8 (System.Int32)]);\n\tv702 = _game.BaseLayerSystems.EntitySystem.Core.ComponentPool`1<_game.CoreSystem.New.GridEcsBinding.Components.BusyComponent>::TryGet(this._busyPool, v666, &v84 @ stack_-71_v5 (_game.CoreSystem.New.GridEcsBinding.Components.BusyComponent));\n\tv706 = ~v702;\n\tv416 = &v84 @ stack_-71_v5 (_game.CoreSystem.New.GridEcsBinding.Components.BusyComponent);\n\tif (v706) goto L_00C0;\n\tgoto L_0167;\nL_0167:\n\tv703 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::HasPrimaryAt(this._gridHandler, v87);\n\tv726 = ~v703;\n\tif (v726) goto L_017F;\n\tv96 = 0xB2A0000 + 0x930;\n\tv728 = v84 & 1;\n\tv729 = v728 == 0;\n\tv707 = ~v729;\n\tv416 = 0;\n\tif (v707) goto L_00C0;\n\tv80 = 1;\n\tgoto L_019A;\nL_017F:\n\tv704 = _game.BaseLayerSystems.EntitySystem.Core.ComponentPool`1<_game.CoreSystem.New.GridEcsBinding.Components.CellTransitionLockComponent>::Has(this._lockPool, v666);\n\tv709 = v84 & 1;\n\tv692 = v704 == v709;\n\tv96 = 0xB2A0000 + 0x930;\n\tv416 = Il2CppMethodInfo;\n\tif (v692) goto L_00C0;\n\tv80 = v704;\nL_019A:\n\t_game.BaseLayerSystems.EntitySystem.Core.ComponentPool`1<_game.CoreSystem.New.GridEcsBinding.Components.BusyComponent>::Set(this._busyPool, v666, v80);\n\tv741 = v84 & 1;\n\tv81 = v741 | v80;\n\tv744 = _game.BaseLayerSystems.EntitySystem.Core.ComponentPool`1<_game.CoreSystem.New.GridEcsBinding.Components.CellStateChangedThisTickTag>::Has(this._changedPool, v666);\n\tv745 = ~v744;\n\tif (v745) goto L_01BA;\n\t_game.BaseLayerSystems.EntitySystem.Core.ComponentPool`1<_game.CoreSystem.New.GridEcsBinding.Components.CellStateChangedThisTickTag>::Set(this._changedPool, v666, v81);\n\tv473 = Il2CppMethodInfo;\n\tv416 = v81;\n\tgoto L_00C0;\nL_01BA:\n\t_game.BaseLayerSystems.EntitySystem.Core.ComponentPool`1<_game.CoreSystem.New.GridEcsBinding.Components.CellStateChangedThisTickTag>::Add(this._changedPool, v666, v81);\n\tv473 = Il2CppMethodInfo;\n\tv416 = v81;\n\tgoto L_00C0;\nL_01C9:\n\treturn;\nL_0059:\n\tv370 = *([v364 @ X10_v20-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v370) goto L_0078;\nL_00C2:\n\tv510 = *([v66 @ X0_v5 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv554 = *([v510 @ X8_v12 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv444 = *([v510 @ X8_v12 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v444) goto L_00E2;\nL_00CD:\n\tv559 = *([v436 @ X10_v15-8]) == *([v185 @ X27_v8 (System.Int32)]);\n\tif (v559) goto L_00F5;\nL_0113:\n\tv649 = *([v643 @ X10_v10-8]) == *([v104 @ X28_v8 (System.Int32)]);\n\tif (v649) goto L_012B;\nL_0132:\n\t*([v663 @ X0_v11])(v666, v66, v108, *([v663 @ X0_v11+8]), v473, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n")]
		public void Execute()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandReconcile_CellStateSystem::Execute");
		}

		[Token(Token = "0x6000A3E")]
		[Address(RVA = "0x3EAC240", Offset = "0x3EAC240", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tv53 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::HasPrimaryAt(this._gridHandler, coord);\n\tv62 = v53 == 0;\n\tif (v62) goto L_003E;\n\treturn 1;\nL_003E:\n\treturnVal3 = _game.BaseLayerSystems.EntitySystem.Core.ComponentPool`1<_game.CoreSystem.New.GridEcsBinding.Components.CellTransitionLockComponent>::Has(this._lockPool, cell);\n\treturn returnVal3;\n")]
		private bool ComputeIsBusy(Entity cell, GridCoord coord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandReconcile_CellStateSystem::ComputeIsBusy");
			return default;
		}

		[Token(Token = "0x6000A3F")]
		[Address(RVA = "0x3EAC390", Offset = "0x3EAC390", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public SandReconcile_CellStateSystem()
		{
		}
	}
}
