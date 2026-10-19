using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.Shared.Components;
using _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.ECS.Data;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts;
using _game.CoreSystem.SandPhysics;
using _game.CoreSystem.SandPhysics.Services;

namespace _game.CoreSystem.New.TopGridSystem.Core.Reconciliation
{
	[Token(Token = "0x2000259")]
	public class SandReconcile_ParticleSpawnSystem
	{
		[Token(Token = "0x200025A")]
		private struct PendingBreak
		{
			[Token(Token = "0x4000735")]
			[FieldOffset(Offset = "0x0")]
			public float fireTime;

			[Token(Token = "0x4000736")]
			[FieldOffset(Offset = "0x4")]
			public CubeBreakEvent evt;
		}

		[Inject(false)]
		[Token(Token = "0x4000731")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x4000732")]
		[FieldOffset(Offset = "0x18")]
		private TopGridVisualGridController _visualGrid;

		[Inject(false)]
		[Token(Token = "0x4000733")]
		[FieldOffset(Offset = "0x20")]
		private SandCubeConfig _config;

		[Token(Token = "0x4000734")]
		[FieldOffset(Offset = "0x28")]
		private readonly List<PendingBreak> _pending;

		[Token(Token = "0x6000A47")]
		[Address(RVA = "0x3EAD108", Offset = "0x3EAD108", Length = "0x640")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv42 = *([B78E76E]) & 1;\n\tv43 = v42 == 0;\n\tif (v43) goto L_0053;\n\tv70 = 0xB293000 + 0xDC8;\n\tv48 = *([B193A9A]) & 1;\n\tv49 = v48 == 0;\n\tv84 = v70;\n\tif (v49) goto L_0060;\nL_0021:\n\tv78 = *([v70 @ X21_v19 (System.Int32)]);\n\tv79 = *([v78 @ X8_v53+B8]);\n\tv249 = *([v79 @ X8_v54]);\n\tv81 = *([v79 @ X8_v54]) == 0;\n\tv82 = ~v81;\n\tif (v82) goto L_0069;\n\tgoto L_0286;\nL_0053:\n\t*([B19376E]) = 1;\n\tv70 = 0xB293000 + 0xDC8;\n\tv832 = *([B193A9A]) & 1;\n\tv833 = v832 == 0;\n\tv73 = ~v833;\n\tv84 = v70;\n\tif (v73) goto L_0021;\nL_0060:\n\t*([B193A9A]) = 1;\n\tv108 = *([v84 @ X21_v16 (System.Int32)]);\n\tv101 = *([v108 @ X8_v48+B8]);\n\tv249 = *([v101 @ X8_v49]);\n\tv99 = *([v101 @ X8_v49]) == 0;\n\tif (v99) goto L_0286;\nL_0069:\n\tv106 = UnityEngine.Time::get_time();\n\tgoto L_0072;\nL_0072:\n\tv389 = UnityEngine.Object::op_Inequality(this._config, 0);\n\tv397 = ~v389;\n\tv398 = ~v397;\n\tv540 = 0;\n\tif (v398) goto L_0082;\n\tv230 = 0;\n\tv540 = 0;\n\tgoto L_008C;\nL_0082:\n\tv414 = this._config;\n\tv230 = v414.ParticleSpawnDelay;\nL_008C:\n\tv585 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv654 = *([v585 @ X0_v7 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv703 = *([v654 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv656 = *([v654 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v656) goto L_00B7;\n\tv702 = *([v654 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv702 = v702 + 0x10;\n\tv685 = v703 - 1;\n\tv665 = v703 != 1;\n\tv703 = v685;\n\tif (v665) goto L_009E;\nL_00B7:\n\tv716 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v585);\n\tv726 = v716 >= 1;\n\tv540 = 0;\n\tif (v726) goto L_00DC;\n\tgoto L_0216;\nL_00C5:\n\tv732 = *([v702 @ X10_v25]) << 4;\n\tv733 = v654 + v732;\n\tv734 = v733 + 0x138;\n\t*([v734 @ X0_v60])(v738, v585, *([v734 @ X0_v60+8]), v540, v55, v56, v57, v58, v59, v106, v61, v62, v63, v64, v65, v66, v67);\n\tv749 = v738 < 1;\n\tif (v749) goto L_0216;\nL_00DC:\n\tv576 = _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualGridController::get_EffectiveCubeSize(this._visualGrid);\n\tv588 = UnityEngine.Component::get_transform(this._visualGrid);\n\tv814 = UnityEngine.Transform::get_eulerAngles(v588);\n\tv845 = *([v585 @ X0_v7 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv885 = *([v845 @ X8_v17 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv824 = *([v845 @ X8_v17 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v824) goto L_010F;\n\tv804 = *([v845 @ X8_v17 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv804 = v804 + 0x10;\n\tv873 = v885 - 1;\n\tv855 = v885 != 1;\n\tv885 = v873;\n\tif (v855) goto L_00F6;\nL_010F:\n\tv816 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v585);\n\tv606 = v816 - 1;\n\tv776 = v816 >= 1;\n\tif (v776) goto L_0135;\n\tgoto L_0216;\nL_011E:\n\tv775 = *([v804 @ X10_v20]) << 4;\n\tv898 = v845 + v775;\n\tv899 = v898 + 0x138;\n\t*([v899 @ X0_v53])(v817, v585, *([v899 @ X0_v53+8]), v540, v55, v56, v57, v58, v59, v814, v814.y, v814.z, v63, v64, v65, v66, v67);\n\tv795 = v817 < 1;\n\tv606 = v817 - 1;\n\tif (v795) goto L_0216;\nL_0135:\n\t;\n\tgoto L_0158;\nL_013A:\n\tv1111 = v1092;\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.SandReconcile_ParticleSpawnSystem+PendingBreak>::Add(v596, &v1111 @ stack_-AC_v10 (System.Single));\n\tv169 = v1092;\nL_0144:\n\t;\nL_0158:\n\tgoto L_017F;\n\tv1008 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v1007);\n\tv1009 = ~v1008;\n\tif (v1009) goto L_0145;\n\tv1043 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v1007);\n\tv1047 = ~v1043;\n\tif (v1047) goto L_0145;\n\tv1044 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v1007);\n\tv1054 = v1044 == 0;\n\tv1048 = ~v1054;\n\tif (v1048) goto L_0145;\n\tv1056 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v1007);\n\tv1058 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v1007);\n\tv578 = _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualGridController::GridToWorld(this._visualGrid, v1056);\n\tv1061 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v1007);\n\tv1062 = ~v1061;\n\tv1065 = 0;\n\tif (v1062) goto L_01D2;\n\tv1068 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v1007);\n\tv1065 = v1068;\n\tv596 = this._pending;\n\tv1092 = v106 + v580;\n\tgoto L_013A;\nL_0208:\n\t;\n\tv169 = v578;\n\t_game.CoreSystem.SandPhysics.Services.SandBreakEventQueue::EnqueueBreakEvent(*([v249 @ X25_v4+20]), &v169 @ stack_-AC (UnityEngine.Vector3));\n\tv169 = v578;\n\tgoto L_0144;\nL_0216:\n\tv257 = this._pending;\n\tv641 = v257.Count;\n\tv216 = v257.Count < 1;\n\tif (v216) goto L_0286;\n\tgoto L_023A;\nL_0235:\n\tv193 = v641 <= 0;\n\tv169 = v171;\n\tif (v193) goto L_0286;\nL_023A:\n\tv641 = v641 - 1;\n\tv637 = &v169 @ stack_-AC (UnityEngine.Vector3);\n\tv839 = System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.SandReconcile_ParticleSpawnSystem+PendingBreak>::get_Item(this._pending, v641);\n\tv171 = *([v637 @ X8_v12]);\n\tv524 = *([v637 @ X8_v12]) < v106;\n\tv518 = *([v637 @ X8_v12]) == v106;\n\tv842 = *([v637 @ X8_v12]) == *([v637 @ X8_v12]);\n\tv512 = v106 == v106;\n\tv530 = v842 & v512;\n\tv499 = ~v530;\n\tv843 = v524 == v499;\n\tv120 = ~v518;\n\tv493 = v843 & v120;\n\tif (v493) goto L_0235;\n\tv600 = System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.SandReconcile_ParticleSpawnSystem+PendingBreak>::get_Item(this._pending, v641);\n\tv171 = v600.fireTime;\n\tv431 = v169.y;\n\t_game.CoreSystem.SandPhysics.Services.SandBreakEventQueue::EnqueueBreakEvent(*([v249 @ X25_v4+20]), &v431 @ stack_-D0_v3);\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.SandReconcile_ParticleSpawnSystem+PendingBreak>::RemoveAt(this._pending, v641);\n\tgoto L_0235;\nL_0286:\n\treturn;\nL_009E:\n\tv708 = *([v702 @ X10_v25-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v708) goto L_00C5;\nL_00F6:\n\tv890 = *([v804 @ X10_v20-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v890) goto L_011E;\nL_017F:\n\tv1007 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v585, v606);\nL_0145:\n\tv829 = v606 - 1;\n\tv778 = v606 <= 0;\n\tv606 = v829;\n\tv249 = v249;\n\tif (v778) goto L_0216;\nL_01D2:\n\t;\n\tv580 = v230 + v1065;\n\tv521 = v580 < 0;\n\tv515 = v580 == 0;\n\tv527 = v580 == v580;\n\tv496 = ~v527;\n\tv1075 = v521 == v496;\n\tv1076 = ~v1075;\n\tv491 = v1076 | v515;\n\tif (v491) goto L_0208;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void Execute()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandReconcile_ParticleSpawnSystem::Execute");
		}

		[Token(Token = "0x6000A48")]
		[Address(RVA = "0x3EAD748", Offset = "0x3EAD748", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.SandReconcile_ParticleSpawnSystem+PendingBreak>();\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.SandReconcile_ParticleSpawnSystem+PendingBreak>::.ctor(v48);\n\tthis._pending = v48;\n")]
		public SandReconcile_ParticleSpawnSystem()
		{
			List<PendingBreak> pending = new List<PendingBreak>();
			_pending = pending;
		}
	}
}
