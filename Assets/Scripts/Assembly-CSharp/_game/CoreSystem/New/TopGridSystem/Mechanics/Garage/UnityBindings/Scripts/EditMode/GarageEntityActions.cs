using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.Shared.EditMode;
using _game.CoreSystem.New.TopGridSystem.Core.Reconciliation.EditMode;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.ECS.Data;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.ECS.Tags;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.EditMode
{
	[Token(Token = "0x2000224")]
	public class GarageEntityActions : EntityActionsBase
	{
		[Token(Token = "0x170000C0")]
		public int Counter
		{
			[Token(Token = "0x6000985")]
			[Address(RVA = "0x3E96574", Offset = "0x3E96574", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv63 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v44, v46);\n\tv66 = ~v63;\n\treturnVal1 = v63;\n\tif (v66) goto L_0037;\n\tv92 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(v44, v46);\n\treturnVal1 = v92.counter;\nL_001C:\n\tv48 = _game.CoreSystem.New.Shared.EditMode.EntityActionsBase::TryResolve(this, &v44 @ stack_-28_v2 (_game.BaseLayerSystems.EntitySystem.Core.EntityManager), &v46 @ stack_-30_v2 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv52 = ~v48;\n\treturnVal1 = v48;\n\tif (v52) goto L_0037;\nL_0037:\n\treturn returnVal1;\n")]
			get
			{
				bool flag = TryResolve(out var em, out var entity);
				bool flag2 = !flag;
				int result = (flag ? 1 : 0);
				if (!flag2)
				{
					bool flag3 = em.HasComponent<GarageComponent>(entity);
					bool flag4 = !flag3;
					result = (flag3 ? 1 : 0);
					if (!flag4)
					{
						result = em.GetComponent<GarageComponent>(entity).counter;
					}
				}
				return result;
			}
			[Token(Token = "0x6000986")]
			[Address(RVA = "0x3E96628", Offset = "0x3E96628", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv75 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v49, v51);\n\tv78 = ~v75;\n\tif (v78) goto L_004C;\n\tv116 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(v49, v51);\n\tv117 = value & 0xFFFFFFFF;\n\tv77 = v117 << 0x20;\n\tv118 = v116 & 0xFFFFFFFF;\n\tv68 = v118 | v77;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::SetComponent(v49, v51, v68);\nL_004C:\n\treturn;\nL_0022:\n\tv53 = _game.CoreSystem.New.Shared.EditMode.EntityActionsBase::TryResolve(this, &v49 @ stack_-38_v2 (_game.BaseLayerSystems.EntitySystem.Core.EntityManager), &v51 @ stack_-40_v2 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv57 = ~v53;\n\tif (v57) goto L_004C;\n")]
			set
			{
				global::AssetRipperInjected.RecoveryStub.Missing("GarageEntityActions::set_Counter");
			}
		}

		[Token(Token = "0x170000C1")]
		public int GroupId
		{
			[Token(Token = "0x6000987")]
			[Address(RVA = "0x3E96718", Offset = "0x3E96718", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv63 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v44, v46);\n\tv66 = ~v63;\n\treturnVal1 = v63;\n\tif (v66) goto L_0036;\n\tv62 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(v44, v46);\n\treturnVal1 = v62;\nL_0036:\n\treturn returnVal1;\nL_001C:\n\tv48 = _game.CoreSystem.New.Shared.EditMode.EntityActionsBase::TryResolve(this, &v44 @ stack_-28_v2 (_game.BaseLayerSystems.EntitySystem.Core.EntityManager), &v46 @ stack_-30_v2 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv52 = ~v48;\n\treturnVal1 = v48;\n\tif (v52) goto L_0036;\n")]
			get
			{
				bool flag = TryResolve(out var em, out var entity);
				bool flag2 = !flag;
				int result = (flag ? 1 : 0);
				if (!flag2)
				{
					bool flag3 = em.HasComponent<GarageComponent>(entity);
					bool flag4 = !flag3;
					result = (flag3 ? 1 : 0);
					if (!flag4)
					{
						result = em.GetComponent<GarageComponent>(entity).groupId;
					}
				}
				return result;
			}
			[Token(Token = "0x6000988")]
			[Address(RVA = "0x3E967C8", Offset = "0x3E967C8", Length = "0x108")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv81 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v49, v51);\n\tv84 = ~v81;\n\tif (v84) goto L_004F;\n\tv126 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(v49, v51);\n\tv86 = v126 & 0xFFFFFFFF00000000;\n\tv129 = v86 | value;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::SetComponent(v49, v51, v129);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.EditMode.GarageEntityActions::CascadeGroupIdToCovers(v49, v126, value);\nL_004F:\n\treturn;\nL_0022:\n\tv53 = _game.CoreSystem.New.Shared.EditMode.EntityActionsBase::TryResolve(this, &v49 @ stack_-38_v2 (_game.BaseLayerSystems.EntitySystem.Core.EntityManager), &v51 @ stack_-40_v2 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv57 = ~v53;\n\tif (v57) goto L_004F;\n")]
			set
			{
				global::AssetRipperInjected.RecoveryStub.Missing("GarageEntityActions::set_GroupId");
			}
		}

		[Token(Token = "0x6000984")]
		[Address(RVA = "0x3E9656C", Offset = "0x3E9656C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.New.Shared.EditMode.EntityActionsBase::BindCore(this, entity, history);\n\treturn;\n")]
		public void Bind(Entity entity, EditorHistory history)
		{
			BindCore(entity, history);
		}

		[Token(Token = "0x6000989")]
		[Address(RVA = "0x3E96B00", Offset = "0x3E96B00", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv51 = this._history == 0;\n\tif (v51) goto L_0028;\n\t_game.CoreSystem.New.Shared.EditMode.EditorHistory::Push(this._history, \"EditGarageCounter\");\nL_0028:\n\tv60 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(v43);\n\tv64 = v60 == 0;\n\tif (v64) goto L_003C;\n\tv61 = UnityEngine.Component::GetComponent(v60);\n\tv63 = v61 == 0;\n\tif (v63) goto L_003C;\n\tv82 = _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.EditMode.GarageEntityActions::get_Counter(this);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageMono::SetCounter(v61, v82);\nL_003C:\n\treturn;\nL_0015:\n\tv39 = 0;\n\tv46 = _game.CoreSystem.New.Shared.EditMode.EntityActionsBase::TryResolve(this, &v39 @ stack_-30_v1 (_game.BaseLayerSystems.EntitySystem.Core.EntityManager), &v43 @ stack_-28_v2 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv49 = ~v46;\n\tif (v49) goto L_003C;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnCounterChanged()
		{
			EntityManager em = null;
			if (!TryResolve(out em, out var entity))
			{
				return;
			}
			if (_history != null)
			{
				_history.Push("EditGarageCounter");
			}
			EntityMono monoBinding = entity.GetMonoBinding();
			if ((object)monoBinding != null)
			{
				GarageMono component = monoBinding.GetComponent<GarageMono>();
				if ((object)component != null)
				{
					int counter = Counter;
					component.SetCounter(counter);
				}
			}
		}

		[Token(Token = "0x600098A")]
		[Address(RVA = "0x3E96BC4", Offset = "0x3E96BC4", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv47 = this._history == 0;\n\tif (v47) goto L_0028;\n\t_game.CoreSystem.New.Shared.EditMode.EditorHistory::Push(this._history, \"EditGarageGroupId\");\nL_0028:\n\treturn;\nL_0012:\n\tv38 = 0;\n\tv39 = 0;\n\tv44 = _game.CoreSystem.New.Shared.EditMode.EntityActionsBase::TryResolve(this, &v38 @ stack_-30_v1 (_game.BaseLayerSystems.EntitySystem.Core.EntityManager), &v39 @ stack_-28_v1 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv45 = ~v44;\n\tif (v45) goto L_0028;\n")]
		private void OnGroupIdChanged()
		{
			EntityManager em = null;
			Entity entity = default(Entity);
			if (TryResolve(out em, out entity) && _history != null)
			{
				_history.Push("EditGarageGroupId");
			}
		}

		[Token(Token = "0x600098B")]
		[Address(RVA = "0x3E96C40", Offset = "0x3E96C40", Length = "0x434")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\n\tv165 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v62, v64);\n\tv301 = ~v165;\n\tif (v301) goto L_FFFFFFFF;\n\tv313 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(v62, v64);\nL_FFFFFFFF:\n\tv208 = v313;\n\tgoto L_0052;\nL_FFFFFFFF:\n\tv208 = 0;\nL_0052:\n\tv317 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v62, v64);\n\tv318 = ~v317;\n\tif (v318) goto L_FFFFFFFF;\n\tv325 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(v62, v64);\n\tv330 = v64 >> 0x20;\nL_FFFFFFFF:\n\tv128 = v330;\nL_FFFFFFFF:\n\tv139 = v64;\n\tgoto L_006A;\nL_FFFFFFFF:\n\tv128 = 0;\nL_FFFFFFFF:\n\tv139 = 0;\nL_006A:\n\tv332 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v62, v64);\n\tv333 = ~v332;\n\tif (v333) goto L_0083;\n\tv346 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(v62, v64);\n\tv123 = v346 >> 0x20;\n\tv121 = 0xB292000 + 0x5A0;\nL_FFFFFFFF:\n\tv131 = v346;\n\tgoto L_008D;\nL_0083:\n\tv121 = 0xB292000 + 0x5A0;\nL_FFFFFFFF:\n\tv123 = 0;\nL_FFFFFFFF:\n\tv131 = 0;\n\tgoto L_008D;\nL_008D:\n\tv369 = UnityEngine.Object::FindObjectOfType();\n\tv234 = UnityEngine.Object::op_Inequality(v369, 0);\n\tv372 = ~v234;\nL_FFFFFFFF:\n\t;\n\tif (v372) goto L_0108;\n\tv408 = v369.GridHandler == 0;\nL_FFFFFFFF:\n\t;\n\tif (v408) goto L_0108;\n\tv376 = v139 < 1;\nL_FFFFFFFF:\n\t;\n\tif (v376) goto L_0108;\n\tv183 = v128 < 1;\nL_FFFFFFFF:\n\t;\n\tif (v183) goto L_0108;\nL_FFFFFFFF:\n\tv264 = 0;\n\tgoto L_FFFFFFFF;\nL_00B4:\n\tv264 = v264 + 1;\n\tv391 = v264 == v139;\n\tif (v391) goto L_0108;\nL_FFFFFFFF:\n\tv179 = v128;\nL_FFFFFFFF:\n\tv181 = v123;\n\tgoto L_00D0;\nL_00C3:\n\tv181 = v181 + 1;\n\tv476 = v179 == 1;\n\tv179 = v179 - 1;\n\tif (v476) goto L_00B4;\nL_00D0:\n\tv486 = v264 + v131;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v177 @ stack_-80_v7 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v486, v181);\n\tv508 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::GetSandCubeAt(v369.GridHandler, v177);\n\tv517 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(v62, v508);\n\tv522 = ~v517;\nL_FFFFFFFF:\n\t;\n\tif (v522) goto L_00C3;\n\tv531 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(v508);\n\tv545 = *([v121 @ X26_v4 (System.Int32)]);\n\tv546 = *([v545 @ X0_v61+E4]) == 0;\n\tif (v546) goto L_00F8;\n\tv538 = UnityEngine.Object::op_Inequality(v531, 0);\n\tv540 = ~v538;\nL_FFFFFFFF:\n\t;\n\tif (v540) goto L_00C3;\n\tgoto L_00FF;\nL_00F8:\n\tv539 = UnityEngine.Object::op_Inequality(v531, 0);\n\tv541 = ~v539;\nL_FFFFFFFF:\n\t;\n\tif (v541) goto L_00C3;\nL_00FF:\n\tv237 = UnityEngine.Component::get_gameObject(v531);\n\tUnityEngine.GameObject::SetActive(v237, 1);\nL_FFFFFFFF:\n\t;\n\tgoto L_00C3;\nL_0108:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.EditMode.GarageEntityActions::DestroyCoversByGroupId(v62, v208);\n\tv419 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(v64);\n\tv422 = *([v121 @ X26_v4 (System.Int32)]);\n\tv424 = *([v422 @ X0_v22+E4]) == 0;\n\tif (v424) goto L_011D;\n\tv430 = UnityEngine.Object::op_Inequality(v419, 0);\n\tv433 = ~v430;\n\tv434 = ~v433;\n\tif (v434) goto L_0122;\n\tgoto L_0159;\nL_011D:\n\tv438 = UnityEngine.Object::op_Inequality(v419, 0);\n\tv465 = ~v438;\n\tif (v465) goto L_0159;\nL_0122:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::UnbindMono(v64);\n\tgoto L_012A;\nL_012A:\n\tv510 = UnityEngine.Application::get_isPlaying();\n\tv512 = ~v510;\n\tif (v512) goto L_0148;\n\tv525 = UnityEngine.Component::get_gameObject(v419);\n\tgoto L_013C;\nL_0148:\n\tv528 = UnityEngine.Component::get_gameObject(v419);\n\tgoto L_0153;\nL_0159:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::DestroyEntity(v62, v64);\nL_0167:\n\treturn;\nL_0035:\n\tv66 = _game.CoreSystem.New.Shared.EditMode.EntityActionsBase::TryResolve(this, &v62 @ stack_-68_v2 (_game.BaseLayerSystems.EntitySystem.Core.EntityManager), &v64 @ stack_-70_v2 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv70 = ~v66;\n\tif (v70) goto L_0167;\nL_013C:\n\tUnityEngine.Object::Destroy(v525);\n\tgoto L_0159;\nL_0153:\n\tUnityEngine.Object::DestroyImmediate(v528);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal override void DoRemove()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GarageEntityActions::DoRemove");
		}

		[Token(Token = "0x600098C")]
		[Address(RVA = "0x3E968D0", Offset = "0x3E968D0", Length = "0x230")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0034;\nL_0043:\n\treturn;\nL_004A:\n\tv200 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(em);\n\tv82 = newGroupId;\n\tv132 = 0;\n\tgoto L_005B;\nL_0059:\n\tv132 = v132 + 1;\n\tv117 = *([v254 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv117 = v117 + 0x10;\n\tv260 = v282 - 1;\n\tv259 = v282 != 1;\n\tv282 = v260;\n\tif (v259) goto L_0066;\nL_007F:\n\tv134 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v200);\n\tv84 = v132 < v134;\n\tif (v84) goto L_00A4;\n\tgoto L_0043;\nL_008E:\n\tv79 = *([v117 @ X10_v12]) << 4;\n\tv304 = v254 + v79;\n\tv305 = v304 + 0x138;\n\t*([v305 @ X0_v26])(v135, v200, *([v305 @ X0_v26+8]), v82, Il2CppMethodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv85 = v132 >= v135;\n\tif (v85) goto L_0043;\nL_00A4:\n\tgoto L_00CB;\n\tv409 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(em, v400);\n\tv426 = ~v409;\n\tv82 = Il2CppMethodInfo;\n\tif (v426) goto L_0059;\n\tv424 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(em, v400);\n\tv413 = v424 != oldGroupId;\n\tv82 = Il2CppMethodInfo;\n\tif (v413) goto L_0059;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::SetComponent(em, v400, newGroupId);\n\tv82 = newGroupId;\n\tgoto L_0059;\nL_0034:\n\tv66 = oldGroupId != newGroupId;\n\tif (v66) goto L_004A;\nL_005B:\n\tv254 = *([v200 @ X0_v5 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv282 = *([v254 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv137 = *([v254 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v137) goto L_007F;\nL_0066:\n\tv295 = *([v117 @ X10_v12-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v295) goto L_008E;\nL_00CB:\n\tv400 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v200, v132);\n\tv404 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(em, v400);\n\tv405 = ~v404;\n\tv82 = 0;\n\tif (v405) goto L_0059;\n")]
		private static void CascadeGroupIdToCovers(EntityManager em, int oldGroupId, int newGroupId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GarageEntityActions::CascadeGroupIdToCovers");
		}

		[Token(Token = "0x600098D")]
		[Address(RVA = "0x3E97074", Offset = "0x3E97074", Length = "0x208")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\nL_002B:\n\tv60 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(em);\n\tv77 = *([v60 @ X0_v5 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv191 = *([v77 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv79 = *([v77 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v79) goto L_0056;\n\tv190 = *([v77 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv190 = v190 + 0x10;\n\tv176 = v191 - 1;\n\tv156 = v191 != 1;\n\tv191 = v176;\n\tif (v156) goto L_003D;\nL_0056:\n\tv204 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v60);\n\tv287 = v204 - 1;\n\tv215 = v204 >= 1;\n\tif (v215) goto L_007D;\n\tgoto L_00E5;\nL_0065:\n\tv218 = *([v190 @ X10_v13]) << 4;\n\tv219 = v77 + v218;\n\tv220 = v219 + 0x138;\n\t*([v220 @ X0_v27])(v224, v60, *([v220 @ X0_v27+8]), methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv228 = v224 < 1;\n\tv287 = v224 - 1;\n\tif (v228) goto L_00E5;\nL_007D:\n\tgoto L_0091;\nL_007E:\n\tv283 = v287 - 1;\n\tv269 = v287 <= 0;\n\tv287 = v283;\n\tif (v269) goto L_00E5;\nL_0091:\n\tgoto L_00B8;\n\tv388 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(em, v379);\n\tv413 = ~v388;\n\tif (v413) goto L_007E;\n\tv411 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(em, v379);\n\tv392 = v411 != groupId;\n\tif (v392) goto L_007E;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::DestroyEntity(em, v379);\n\tgoto L_007E;\nL_00E5:\n\treturn;\nL_003D:\n\tv196 = *([v190 @ X10_v13-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v196) goto L_0065;\nL_00B8:\n\tv379 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v60, v287);\n\tv383 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(em, v379);\n\tv384 = ~v383;\n\tif (v384) goto L_007E;\n")]
		private static void DestroyCoversByGroupId(EntityManager em, int groupId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GarageEntityActions::DestroyCoversByGroupId");
		}

		[Token(Token = "0x600098E")]
		[Address(RVA = "0x3E9727C", Offset = "0x3E9727C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.New.Shared.EditMode.EntityActionsBase::.ctor(this);\n\treturn;\n")]
		public GarageEntityActions()
		{
		}
	}
}
