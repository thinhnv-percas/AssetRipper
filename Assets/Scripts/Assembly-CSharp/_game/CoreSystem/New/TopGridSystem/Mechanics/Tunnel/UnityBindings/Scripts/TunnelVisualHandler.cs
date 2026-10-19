using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Data;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts;
using _game.CoreSystem.Pooling;
using _game.CoreSystem.SandSystem.Components;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts
{
	[Token(Token = "0x200014F")]
	public class TunnelVisualHandler : ITopGridVisualHandler
	{
		[Inject(false)]
		[Token(Token = "0x400043C")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x400043D")]
		[FieldOffset(Offset = "0x18")]
		private TopGridVisualGridController _visualGrid;

		[Inject(false)]
		[Token(Token = "0x400043E")]
		[FieldOffset(Offset = "0x20")]
		private TunnelConfig _config;

		[Inject(true)]
		[Token(Token = "0x400043F")]
		[FieldOffset(Offset = "0x28")]
		private IVfxPool _vfxPool;

		[Token(Token = "0x4000440")]
		[FieldOffset(Offset = "0x30")]
		private Transform _parent;

		[Token(Token = "0x6000681")]
		[Address(RVA = "0x3DB6F68", Offset = "0x3DB6F68", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = direction < 3;\n\tv3 = ~v1;\n\tv4 = direction - 3;\n\tv6 = v4 == 0;\n\tv11 = ~v6;\n\tv12 = v3 & v11;\n\treturnVal1 = 0;\n\tif (v12) goto L_0010;\n\tv14 = 0x9308000 + 0x180;\n\treturnVal1 = *([v14 @ X8_v3 (System.Int32)+direction @ X0 (_game.CoreSystem.SandSystem.Components.TunnelDirection)*4]);\nL_0010:\n\treturn returnVal1;\n")]
		public static float TunnelRotationZ(TunnelDirection direction)
		{
			//IL_0085: Expected F4, but got I
			bool flag = (uint)direction < 3u;
			bool flag2 = !flag;
			int num = (int)(direction - 3);
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			bool flag5 = flag2 && flag4;
			float result = 0f;
			if (!flag5)
			{
				int num2 = 154173440 + 384;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ X8_v3 (System.Int32)+direction @ X0 (_game.CoreSystem.SandSystem.Components.TunnelDirection)*4]");
				result = 0f;
			}
			return result;
		}

		[Token(Token = "0x6000682")]
		[Address(RVA = "0x3DB7530", Offset = "0x3DB7530", Length = "0x19C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv65 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv173 = 0;\n\tgoto L_0040;\nL_003A:\n\tv347 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v65, v173);\n\tv176 = _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelVisualHandler::Spawn(this, v347);\n\tv173 = v173 + 1;\n\tv224 = *([v182 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv224 = v224 + 0x10;\n\tv191 = v215 - 1;\n\tv189 = v215 != 1;\n\tv215 = v191;\n\tif (v189) goto L_004B;\nL_0064:\n\tv237 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v65);\n\tv248 = v173 < v237;\n\tif (v248) goto L_0089;\n\tgoto L_00B3;\nL_0073:\n\tv251 = *([v224 @ X10_v13]) << 4;\n\tv252 = v182 + v251;\n\tv253 = v252 + 0x138;\n\t*([v253 @ X0_v23])(v257, v65, *([v253 @ X0_v23+8]), 0, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv267 = v173 >= v257;\n\tif (v267) goto L_00B3;\nL_0089:\n\tgoto L_003A;\nL_00B3:\n\treturn;\nL_0020:\n\tthis._parent = v44;\nL_0040:\n\tv182 = *([v65 @ X0_v7 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv215 = *([v182 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv134 = *([v182 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v134) goto L_0064;\nL_004B:\n\tv229 = *([v224 @ X10_v13-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v229) goto L_0073;\n")]
		public void InitVisuals(Transform visualParent)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TunnelVisualHandler::InitVisuals");
		}

		[Token(Token = "0x6000683")]
		[Address(RVA = "0x3DB7A34", Offset = "0x3DB7A34", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tv52 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv61 = ~v52;\n\tif (v61) goto L_003F;\n\tv67 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv69 = ~v67;\n\tif (v69) goto L_003F;\n\treturnVal3 = _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelVisualHandler::Spawn(this, entity);\n\treturn returnVal3;\nL_003F:\n\treturn 0;\n")]
		public GameObject TrySpawn(Entity entity)
		{
			if (_em.HasComponent<TunnelTag>(entity) && _em.HasComponent<GridPositionComponent>(entity))
			{
				return Spawn(entity);
			}
			return null;
		}

		[Token(Token = "0x6000684")]
		[Address(RVA = "0x3DB7AE8", Offset = "0x3DB7AE8", Length = "0x250")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\nL_0025:\n\tv55 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv115 = 0;\n\tgoto L_0044;\nL_0038:\n\tv108 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v55, v115);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::UnbindMono(v108);\n\tv420 = UnityEngine.Component::get_gameObject(v403);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::DestroyGo(v420);\n\tv207 = 0;\nL_0042:\n\tv115 = v115 + 1;\n\tv261 = *([v219 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv261 = v261 + 0x10;\n\tv228 = v252 - 1;\n\tv226 = v252 != 1;\n\tv252 = v228;\n\tif (v226) goto L_004F;\nL_0068:\n\tv274 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v55);\n\tv285 = v115 < v274;\n\tif (v285) goto L_008D;\n\tgoto L_00FC;\nL_0077:\n\tv288 = *([v261 @ X10_v21]) << 4;\n\tv289 = v219 + v288;\n\tv290 = v289 + 0x138;\n\t*([v290 @ X0_v36])(v294, v55, *([v290 @ X0_v36+8]), v207, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv304 = v115 >= v294;\n\tif (v304) goto L_00FC;\nL_008D:\n\tgoto L_00B4;\nL_00BF:\n\tv410 = UnityEngine.Object::op_Equality(v403, 0);\n\tv413 = v410 == 0;\n\tv414 = ~v413;\n\tv207 = 0;\n\tif (v414) goto L_0042;\n\tgoto L_00D2;\nL_00D2:\n\tgoto L_0038;\nL_00FC:\n\treturn;\nL_0044:\n\tv219 = *([v55 @ X0_v5 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv252 = *([v219 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv171 = *([v219 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v171) goto L_0068;\nL_004F:\n\tv266 = *([v261 @ X10_v21-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v266) goto L_0077;\nL_00B4:\n\tv401 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v55, v115);\n\tv403 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(v401);\n\tgoto L_00BF;\n")]
		public void Cleanup()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TunnelVisualHandler::Cleanup");
		}

		[Token(Token = "0x6000685")]
		[Address(RVA = "0x3DB7D38", Offset = "0x3DB7D38", Length = "0x4B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv59 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv234 = *([v59 @ X0_v48 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv293 = *([v234 @ X8_v27 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv236 = *([v234 @ X8_v27 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v236) goto L_005D;\n\tv292 = *([v234 @ X8_v27 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv292 = v292 + 0x10;\n\tv265 = v293 - 1;\n\tv245 = v293 != 1;\nL_FFFFFFFF:\n\tv293 = v265;\n\tif (v245) goto L_0043;\nL_005D:\n\tv353 = System.Collections.Generic.IEnumerable`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::GetEnumerator(v59);\n\tv313 = v353 == 0;\n\tv314 = ~v313;\nL_FFFFFFFF:\n\tv478 = &v310 @ stack_-48_v10 (System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\nL_FFFFFFFF:\n\tv338 = 0;\n\tif (v314) goto L_FFFFFFFF;\n\tgoto L_01D1;\nL_0067:\n\tv323 = *([v292 @ X10_v44]) << 4;\n\tv324 = v234 + v323;\n\tv325 = v324 + 0x138;\n\t*([v325 @ X8_v44])(v353, v59, *([v325 @ X8_v44+8]), methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv334 = v353 == 0;\nL_FFFFFFFF:\n\tv478 = &v310 @ stack_-48_v10 (System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\nL_FFFFFFFF:\n\tv338 = 0;\n\tif (v334) goto L_01D1;\nL_FFFFFFFF:\n\tv429 = v353;\n\tgoto L_0083;\nL_007B:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelVisualHandler::SetVisual(this, v805);\nL_007D:\n\tv405 = v310 == 0;\nL_FFFFFFFF:\n\tv429 = v310;\n\tif (v405) goto L_01D1;\nL_0083:\n\tgoto L_00A9;\n\tgoto L_00DA;\n\tv863 = _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelVisualHandler::Spawn(this, v805);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelVisualHandler::SetVisual(this, v805);\n\tgoto L_007D;\nL_00EC:\n\tv513 = &v310 @ stack_-48_v10 (System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\n\tv474 = *([v513 @ X8_v35]);\n\tv511 = *([v513 @ X8_v35]) == 0;\nL_FFFFFFFF:\n\tv472 = 5;\nL_FFFFFFFF:\n\tv514 = 0;\nL_FFFFFFFF:\n\tv516 = oldData;\nL_FFFFFFFF:\n\tv71 = 5;\nL_FFFFFFFF:\n\tv85 = v478;\nL_FFFFFFFF:\n\tv708 = 0;\nL_FFFFFFFF:\n\tv218 = 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv181 = 0;\nL_FFFFFFFF:\n\tv225 = oldData;\n\tif (v511) goto L_011D;\nL_00F6:\n\tgoto L_011C;\n\tv126 = v71 == 5;\n\tif (v126) goto L_0131;\n\tv685 = v71 == 0;\n\tv686 = ~v685;\n\tif (v686) goto L_01D0;\nL_0131:\n\tv165 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(v225);\nL_FFFFFFFF:\n\tv182 = 0;\n\tgoto L_013D;\nL_013B:\n\tv182 = v182 + 1;\n\tv728 = *([v832 @ X8_v6 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv728 = v728 + 0x10;\n\tv858 = v876 - 1;\n\tv840 = v876 != 1;\nL_FFFFFFFF:\n\tv876 = v858;\n\tif (v840) goto L_0148;\nL_0161:\n\tv734 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v165);\n\tv709 = v182 < v734;\n\tif (v709) goto L_0186;\n\tgoto L_01D0;\nL_0170:\n\tv706 = *([v728 @ X10_v14]) << 4;\n\tv892 = v832 + v706;\n\tv893 = v892 + 0x138;\n\t*([v893 @ X0_v26])(v735, v165, *([v893 @ X0_v26+8]), v708, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv710 = v182 >= v735;\n\tif (v710) goto L_01D0;\nL_0186:\n\tgoto L_01AD;\n\tv979 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::EntityExists(this._em, v976);\n\tv981 = v979 == 0;\n\tv982 = ~v981;\nL_FFFFFFFF:\n\tv708 = 0;\n\tif (v982) goto L_013B;\n\tv984 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::TryGetMonoBinding(v976, &v67 @ stack_-58_v5 (_game.BaseLayerSystems.EntitySystem.EntityMono));\n\tv987 = ~v984;\nL_FFFFFFFF:\n\tv708 = 0;\n\tif (v987) goto L_013B;\n\tv986 = UnityEngine.Component::get_gameObject(v67);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::DestroyGo(v986);\nL_FFFFFFFF:\n\tv708 = 0;\n\tgoto L_013B;\nL_01D0:\n\treturn;\nL_01D1:\n\tv410 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv708 = 0;\nL_FFFFFFFF:\n\tv218 = 0;\n\tgoto L_01D4;\nL_01D4:\n\t// 468 Interrupt\nL_01D7:\n\tv227 = new System.OutOfMemoryException();\n\tgoto L_01E8;\nL_01E8:\n\tv278 = v218 != 1;\n\tif (v278) goto L_01F7;\n\tv315 = 0x8BF5BC4(v227, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv514 = *([v315 @ X0_v39]);\n\tv364 = 0x8BF5BF4(v315, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv474 = *([v85 @ stack_-60_v1]);\n\tv437 = *([v85 @ stack_-60_v1]) == 0;\n\tv438 = ~v437;\nL_FFFFFFFF:\n\tv472 = 0;\nL_FFFFFFFF:\n\tv338 = *([v315 @ X0_v39]);\nL_FFFFFFFF:\n\tv516 = v225;\n\tif (v438) goto L_00F6;\nL_FFFFFFFF:\n\tv71 = 0;\nL_FFFFFFFF:\n\tv85 = v85;\nL_FFFFFFFF:\n\tv338 = *([v315 @ X0_v39]);\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv181 = *([v315 @ X0_v39]);\n\tgoto L_011D;\nL_01F7:\n\tv318 = 0x3175484(&v338 @ stack_-68_v8 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv366 = 0x8BF0368(v227, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv439 = 0xA1B8(v366, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0029:\n\tv48 = 0;\n\tthrow System.NullReferenceException;\nL_0043:\n\tv298 = *([v292 @ X10_v44-8]) == System.Collections.Generic.IEnumerable`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v298) goto L_0067;\nL_00A9:\n\tv509 = System.Collections.IEnumerator::MoveNext(v429);\n\tv662 = v509 == 0;\n\tif (v662) goto L_00EC;\nL_00DA:\n\tv805 = System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Current(v310);\n\tv808 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::TryGetMonoBinding(v805, &v48 @ stack_-50_v1 (_game.BaseLayerSystems.EntitySystem.EntityMono));\n\tv835 = v808 == 0;\n\tv836 = ~v835;\n\tif (v836) goto L_007B;\nL_011D:\n\tv566 = v181 == 0;\n\tv222 = ~v566;\nL_FFFFFFFF:\n\tv478 = v85;\nL_FFFFFFFF:\n\t;\n\tif (v222) goto L_01D7;\nL_011C:\n\tSystem.IDisposable::Dispose(v474);\nL_FFFFFFFF:\n\tv71 = v472;\nL_FFFFFFFF:\n\tv85 = v478;\nL_FFFFFFFF:\n\tv708 = 0;\nL_FFFFFFFF:\n\tv218 = 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv181 = v514;\nL_FFFFFFFF:\n\tv225 = v516;\nL_013D:\n\tv832 = *([v165 @ X0_v6 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv876 = *([v832 @ X8_v6 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv736 = *([v832 @ X8_v6 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v736) goto L_0161;\nL_0148:\n\tv881 = *([v728 @ X10_v14-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v881) goto L_0170;\nL_01AD:\n\tv976 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v165, v182);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SyncWithData(EntityManager oldData)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TunnelVisualHandler::SyncWithData");
		}

		[Token(Token = "0x6000686")]
		[Address(RVA = "0x3DB81EC", Offset = "0x3DB81EC", Length = "0x224")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv59 = UnityEngine.Component::get_gameObject(v50);\n\tv135 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, entity);\n\tv240 = UnityEngine.GameObject::get_transform(v59);\n\tv107 = _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualGridController::GridToWorld(this._visualGrid, v135);\n\tUnityEngine.Transform::set_position(v240, v107);\n\tv137 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::GenerateName(this._em, entity);\n\tv248 = System.Text.StringBuilder::Insert(v137, 0, \"Tunnel_\");\n\tv251 = System.Text.StringBuilder::ToString(v137);\n\tUnityEngine.Object::set_name(v59, v251);\n\tv254 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv255 = ~v254;\n\tif (v255) goto L_00B8;\n\tv264 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, entity);\n\tv266 = UnityEngine.GameObject::get_transform(v59);\n\tv268 = v264 < 3;\n\tv91 = ~v268;\n\tv88 = v264 - 3;\n\tv82 = v88 == 0;\n\tv269 = ~v82;\n\tv67 = v91 & v269;\n\tv273 = 0;\n\tif (v67) goto L_0089;\n\tv271 = 0x9308000 + 0x190;\n\tv273 = *([v271 @ X8_v19 (System.Int32)+v264 @ X0_v23 (_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Data.TunnelQueueComponent)*4]);\n\tUnityEngine.Transform::set_localRotation(v266, v108);\n\tv259 = UnityEngine.GameObject::GetComponent(v59);\n\tv222 = v259 == 0;\n\tif (v222) goto L_00B8;\n\tv284 = _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Data.TunnelQueueHelper::GetSlotCount(this._em, entity);\n\tv219 = _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelVisualMono::UpdateQueueCount(v219, v284);\n\treturn;\nL_00B8:\n\treturn;\nL_0025:\n\tv50 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(entity);\nL_0089:\n\t// 137 MakeStruct v62 @ AGG3DB8394_0_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, 0, v273 @ V2_v5 (System.Int32)\n\tv108 = UnityEngine.Quaternion::Internal_FromEulerRad(v62);\n")]
		private void SetVisual(Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TunnelVisualHandler::SetVisual");
		}

		[Token(Token = "0x6000687")]
		[Address(RVA = "0x3DB76CC", Offset = "0x3DB76CC", Length = "0x368")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0034;\nL_0034:\n\tv65 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, entity);\n\tv214 = this._config;\n\tv161 = _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualGridController::GridToWorld(this._visualGrid, v65);\n\tgoto L_0060;\n\tv350 = System.Text.StringBuilder::Insert(v192, 0, \"Tunnel_\");\n\tv193 = System.Text.StringBuilder::ToString(v192);\n\tUnityEngine.Object::set_name(v345, v193);\n\tv217 = this._visualGrid;\n\tv134 = 0;\n\tv353 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::TryGetGridComponent(v217._gridHandler, &v134 @ stack_-70_v2 (_game.CoreSystem.New.GridEcsBinding.Components.GridComponent));\n\tv355 = ~v353;\nL_FFFFFFFF:\n\tv144 = 1f;\n\tif (v355) goto L_00A2;\n\tv359 = v358 + v358;\n\tv360 = v358 < 0;\n\tv361 = v358 == 0;\n\tv364 = v358 == v358;\n\tv365 = ~v364;\n\tv369 = v360 == v365;\n\tv370 = ~v361;\n\tv371 = v369 & v370;\n\tv372 = ~v371;\n\tif (v372) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv374 = v359;\n\tgoto L_009F;\nL_FFFFFFFF:\n\tv374 = 0x3DCCCCCD;\n\t// 169 MakeStruct v98 @ AGG3DB78C4_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v144 @ V8_v4 (System.Single), v144 @ V8_v4 (System.Single), v144 @ V8_v4 (System.Single)\n\tUnityEngine.Transform::set_localScale(v196, v98);\n\tv379 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv380 = ~v379;\n\tif (v380) goto L_010F;\n\tv407 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, entity);\n\tv411 = UnityEngine.GameObject::get_transform(v345);\n\tv413 = v407 < 3;\n\tv120 = ~v413;\n\tv116 = v407 - 3;\n\tv124 = v116 == 0;\n\tv414 = ~v124;\n\tv108 = v120 & v414;\nL_FFFFFFFF:\n\tv418 = 0;\n\tif (v108) goto L_00D5;\n\tv416 = 0x9308000 + 0x190;\n\tv418 = *([v416 @ X8_v30 (System.Int32)+v407 @ X0_v28 (_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Data.TunnelQueueComponent)*4]);\n\tUnityEngine.Transform::set_localRotation(v411, v164);\n\tv427 = UnityEngine.GameObject::GetComponent(v345);\n\tgoto L_00EF;\nL_00EF:\n\tv395 = UnityEngine.Object::op_Inequality(v427, 0);\n\tv434 = ~v395;\n\tv397 = ~v434;\n\tif (v397) goto L_0100;\n\tgoto L_010F;\nL_0100:\n\tv427._vfxPool = this._vfxPool;\n\tv444 = _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Data.TunnelQueueHelper::GetSlotCount(this._em, entity);\n\tv394 = _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelVisualMono::UpdateQueueCount(v427, v444);\nL_0060:\n\t// 96 MakeStruct v74 @ AGG3DB7800_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v161 @ V0_v3 (UnityEngine.Vector3), v161.y (System.Single), v161.z (System.Single)\n\t// 97 MakeStruct v71 @ AGG3DB7800_2_v2 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v215.identity (UnityEngine.Quaternion), v215.identity.y (System.Single), v215.identity.z (System.Single), v215.identity.w (System.Single)\n\tv345 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::Instantiate(v214.tunnelPrefab, v74, v71, this._parent);\n\tv192 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::GenerateName(this._em, entity);\nL_00A2:\n\tv196 = UnityEngine.GameObject::get_transform(v345);\nL_009F:\n\tv144 = 0 - v374;\nL_010F:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::BindEntityMono(v345, entity);\n\tv409 = _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelVisualHandler::OnSpawned(this, v345, entity);\n\treturn v345;\nL_00D5:\n\t// 213 MakeStruct v68 @ AGG3DB793C_0_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, 0, v418 @ V2_v8 (System.Int32)\n\tv164 = UnityEngine.Quaternion::Internal_FromEulerRad(v68);\n")]
		public GameObject Spawn(Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TunnelVisualHandler::Spawn");
			return default;
		}

		[Token(Token = "0x6000688")]
		[Address(RVA = "0x3DB8410", Offset = "0x3DB8410", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected virtual void OnSpawned(GameObject go, Entity entity)
		{
		}

		[Token(Token = "0x6000689")]
		[Address(RVA = "0x3DB8414", Offset = "0x3DB8414", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public TunnelVisualHandler()
		{
		}
	}
}
