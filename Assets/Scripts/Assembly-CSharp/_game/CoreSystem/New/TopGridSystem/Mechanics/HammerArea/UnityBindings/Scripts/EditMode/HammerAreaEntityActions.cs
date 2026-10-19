using System;
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
using _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.ECS.Data;
using _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.ECS.Tags;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts.EditMode
{
	[Token(Token = "0x2000209")]
	public class HammerAreaEntityActions : EntityActionsBase
	{
		[Token(Token = "0x170000BC")]
		public unsafe int Counter
		{
			[Token(Token = "0x600092D")]
			[Address(RVA = "0x3E8F60C", Offset = "0x3E8F60C", Length = "0xBC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv84 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v44, v46);\n\tv87 = ~v84;\n\treturnVal1 = v84;\n\tif (v87) goto L_003F;\n\tv121 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(v44, v46);\n\treturnVal1 = v121.dataCounter;\nL_001C:\n\tv48 = _game.CoreSystem.New.Shared.EditMode.EntityActionsBase::TryResolve(this, &v44 @ stack_-28_v2 (_game.BaseLayerSystems.EntitySystem.Core.EntityManager), &v46 @ stack_-30_v2 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv52 = ~v48;\n\treturnVal1 = v48;\n\tif (v52) goto L_003F;\nL_003F:\n\treturn returnVal1;\n")]
			get
			{
				bool flag = TryResolve(out var em, out var entity);
				bool flag2 = !flag;
				int result = (flag ? 1 : 0);
				if (!flag2)
				{
					bool flag3 = em.HasComponent<HammerAreaComponent>(entity);
					bool flag4 = !flag3;
					result = (flag3 ? 1 : 0);
					if (!flag4)
					{
						result = em.GetComponent<HammerAreaComponent>(entity).dataCounter;
					}
				}
				return result;
			}
			[Token(Token = "0x600092E")]
			[Address(RVA = "0x3E8F6C8", Offset = "0x3E8F6C8", Length = "0x104")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv100 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v49, v51);\n\tv103 = ~v100;\n\tif (v103) goto L_0055;\n\tv158 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(v49, v51);\n\tv123 = v158.groupId;\n\t// 73 NotImplemented \"Instruction DUP not yet implemented.\"\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::SetComponent(v49, v51, &v123 @ stack_-4C_v3 (System.Int32));\nL_0055:\n\treturn;\nL_0022:\n\tv53 = _game.CoreSystem.New.Shared.EditMode.EntityActionsBase::TryResolve(this, &v49 @ stack_-58_v2 (_game.BaseLayerSystems.EntitySystem.Core.EntityManager), &v51 @ stack_-60_v2 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv57 = ~v53;\n\tif (v57) goto L_0055;\n")]
			set
			{
				global::AssetRipperInjected.RecoveryStub.Missing("HammerAreaEntityActions::set_Counter");
			}
		}

		[Token(Token = "0x170000BD")]
		public unsafe int GroupId
		{
			[Token(Token = "0x600092F")]
			[Address(RVA = "0x3E8F7CC", Offset = "0x3E8F7CC", Length = "0xBC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv84 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v44, v46);\n\tv87 = ~v84;\n\treturnVal1 = v84;\n\tif (v87) goto L_003F;\n\tv121 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(v44, v46);\n\treturnVal1 = v121.groupId;\nL_001C:\n\tv48 = _game.CoreSystem.New.Shared.EditMode.EntityActionsBase::TryResolve(this, &v44 @ stack_-28_v2 (_game.BaseLayerSystems.EntitySystem.Core.EntityManager), &v46 @ stack_-30_v2 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv52 = ~v48;\n\treturnVal1 = v48;\n\tif (v52) goto L_003F;\nL_003F:\n\treturn returnVal1;\n")]
			get
			{
				bool flag = TryResolve(out var em, out var entity);
				bool flag2 = !flag;
				int result = (flag ? 1 : 0);
				if (!flag2)
				{
					bool flag3 = em.HasComponent<HammerAreaComponent>(entity);
					bool flag4 = !flag3;
					result = (flag3 ? 1 : 0);
					if (!flag4)
					{
						result = em.GetComponent<HammerAreaComponent>(entity).groupId;
					}
				}
				return result;
			}
			[Token(Token = "0x6000930")]
			[Address(RVA = "0x3E8F888", Offset = "0x3E8F888", Length = "0x124")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv102 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v49, v51);\n\tv105 = ~v102;\n\tif (v105) goto L_005D;\n\tv170 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(v49, v51);\n\tv131 = v170.groupId;\n\tv131 = value;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::SetComponent(v49, v51, &v131 @ stack_-4C_v3 (System.Int32));\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts.EditMode.HammerAreaEntityActions::CascadeGroupIdToCovers(v49, value, value);\nL_005D:\n\treturn;\nL_0022:\n\tv53 = _game.CoreSystem.New.Shared.EditMode.EntityActionsBase::TryResolve(this, &v49 @ stack_-58_v2 (_game.BaseLayerSystems.EntitySystem.Core.EntityManager), &v51 @ stack_-60_v2 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv57 = ~v53;\n\tif (v57) goto L_005D;\n")]
			set
			{
				global::AssetRipperInjected.RecoveryStub.Missing("HammerAreaEntityActions::set_GroupId");
			}
		}

		[Token(Token = "0x600092C")]
		[Address(RVA = "0x3E8F604", Offset = "0x3E8F604", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.New.Shared.EditMode.EntityActionsBase::BindCore(this, entity, history);\n\treturn;\n")]
		public void Bind(Entity entity, EditorHistory history)
		{
			BindCore(entity, history);
		}

		[Token(Token = "0x6000931")]
		[Address(RVA = "0x3E8FBDC", Offset = "0x3E8FBDC", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv55 = this._history == 0;\n\tif (v55) goto L_002A;\n\t_game.CoreSystem.New.Shared.EditMode.EditorHistory::Push(this._history, \"EditHammerAreaCounter\");\nL_002A:\n\tv75 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(v47);\n\tv79 = v75 == 0;\n\tif (v79) goto L_007B;\n\tv76 = UnityEngine.Component::GetComponent(v75);\n\tv80 = v76 == 0;\n\tif (v80) goto L_007B;\n\tv120 = _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts.EditMode.HammerAreaEntityActions::get_Counter(this);\n\tv64 = v120;\n\tgoto L_0042;\nL_0042:\n\tgoto L_0046;\nL_0046:\n\tv144 = UnityEngine.Object::op_Equality(v76.m_counterText, 0);\n\tv153 = v144 == 0;\n\tif (v153) goto L_0062;\n\tgoto L_006C;\nL_0062:\n\tv164 = System.Int32::ToString(&v64 @ stack_-34_v2 (System.Int32));\n\tv174 = TMPro.TMP_Text::set_text(v76.m_counterText, v164);\nL_007B:\n\treturn;\nL_0017:\n\tv43 = 0;\n\tv50 = _game.CoreSystem.New.Shared.EditMode.EntityActionsBase::TryResolve(this, &v43 @ stack_-48_v1 (_game.BaseLayerSystems.EntitySystem.Core.EntityManager), &v47 @ stack_-40_v2 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv53 = ~v50;\n\tif (v53) goto L_007B;\nL_006C:\n\tv177 = _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts.EditMode.HammerAreaEntityActions::get_Counter(this);\n\tv179 = _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts.EditMode.HammerAreaEntityActions::get_Counter(this);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts.HammerAreaMono::SetFill(v76, v177, v179);\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnCounterChanged()
		{
			EntityManager em = null;
			if (!TryResolve(out em, out var entity))
			{
				return;
			}
			if (_history != null)
			{
				_history.Push("EditHammerAreaCounter");
			}
			EntityMono monoBinding = entity.GetMonoBinding();
			if ((object)monoBinding == null)
			{
				return;
			}
			HammerAreaMono component = monoBinding.GetComponent<HammerAreaMono>();
			if ((object)component != null)
			{
				int counter = Counter;
				int num = counter;
				if (!(component.m_counterText == null))
				{
					string text = num.ToString();
					component.m_counterText.text = text;
				}
				int counter2 = Counter;
				int counter3 = Counter;
				component.SetFill(counter2, counter3);
			}
		}

		[Token(Token = "0x6000932")]
		[Address(RVA = "0x3E8FD6C", Offset = "0x3E8FD6C", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv47 = this._history == 0;\n\tif (v47) goto L_0028;\n\t_game.CoreSystem.New.Shared.EditMode.EditorHistory::Push(this._history, \"EditHammerAreaGroupId\");\nL_0028:\n\treturn;\nL_0012:\n\tv38 = 0;\n\tv39 = 0;\n\tv44 = _game.CoreSystem.New.Shared.EditMode.EntityActionsBase::TryResolve(this, &v38 @ stack_-30_v1 (_game.BaseLayerSystems.EntitySystem.Core.EntityManager), &v39 @ stack_-28_v1 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv45 = ~v44;\n\tif (v45) goto L_0028;\n")]
		private void OnGroupIdChanged()
		{
			EntityManager em = null;
			Entity entity = default(Entity);
			if (TryResolve(out em, out entity) && _history != null)
			{
				_history.Push("EditHammerAreaGroupId");
			}
		}

		[Token(Token = "0x6000933")]
		[Address(RVA = "0x3E8FDE8", Offset = "0x3E8FDE8", Length = "0x3F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\n\tv189 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v62, v64);\n\tv372 = ~v189;\n\tif (v372) goto L_FFFFFFFF;\n\tv451 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(v62, v64);\nL_FFFFFFFF:\n\tv277 = v451.sizeX;\nL_FFFFFFFF:\n\tv281 = v451.sizeY;\nL_FFFFFFFF:\n\tv365 = v451.groupId;\n\tgoto L_0061;\nL_FFFFFFFF:\n\tv277 = 0;\nL_FFFFFFFF:\n\tv281 = 0;\nL_FFFFFFFF:\n\tv365 = 0;\nL_0061:\n\tv468 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v62, v64);\n\tv473 = ~v468;\n\tif (v473) goto L_007A;\n\tv500 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(v62, v64);\n\tv269 = v500 >> 0x20;\n\tv265 = 0xB292000 + 0x5A0;\nL_FFFFFFFF:\n\tv342 = v500;\n\tgoto L_0084;\nL_007A:\n\tv265 = 0xB292000 + 0x5A0;\nL_FFFFFFFF:\n\tv269 = 0;\nL_FFFFFFFF:\n\tv342 = 0;\n\tgoto L_0084;\nL_0084:\n\tv523 = UnityEngine.Object::FindObjectOfType();\n\tv335 = UnityEngine.Object::op_Inequality(v523, 0);\n\tv551 = ~v335;\nL_FFFFFFFF:\n\t;\n\tif (v551) goto L_00C0;\n\tv590 = v523.GridHandler == 0;\n\tv595 = ~v590;\n\tv596 = ~v595;\n\tif (v596) goto L_FFFFFFFF;\n\tv602 = v277 - 1;\n\tv620 = v602 < 0;\n\tv605 = v277 ^ 1;\n\tv606 = v277 ^ v602;\n\tv607 = v605 & v606;\n\tv615 = v607 < 0;\n\tgoto L_00AA;\nL_FFFFFFFF:\n\tv615 = 0;\nL_FFFFFFFF:\n\tv620 = 1;\n\tv628 = v281 - 1;\n\tv565 = v628 < 0;\n\tv631 = v281 ^ 1;\n\tv632 = v281 ^ v628;\n\tv633 = v631 & v632;\n\tv555 = v633 < 0;\n\tgoto L_00BC;\nL_FFFFFFFF:\n\tv555 = 0;\nL_FFFFFFFF:\n\tv565 = 1;\nL_00C0:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts.EditMode.HammerAreaEntityActions::DestroyCoversByGroupId(v62, v365);\n\tv599 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(v64);\n\tv613 = *([v265 @ X25_v8 (System.Int32)]);\n\tv614 = *([v613 @ X0_v39+E4]) == 0;\n\tif (v614) goto L_00D5;\n\tv545 = UnityEngine.Object::op_Inequality(v599, 0);\n\tv639 = ~v545;\n\tv548 = ~v639;\n\tif (v548) goto L_00DA;\n\tgoto L_0166;\nL_00D5:\n\tv546 = UnityEngine.Object::op_Inequality(v599, 0);\n\tv549 = ~v546;\nL_FFFFFFFF:\n\tv169 = v599;\n\tif (v549) goto L_0166;\nL_00DA:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::UnbindMono(v64);\n\tgoto L_00E2;\nL_00E2:\n\tv469 = UnityEngine.Application::get_isPlaying();\n\tv471 = ~v469;\nL_FFFFFFFF:\n\tv169 = v599;\nL_FFFFFFFF:\n\tv529 = v599;\n\tif (v471) goto L_0155;\nL_00E9:\n\tv479 = UnityEngine.Component::get_gameObject(v169);\n\tgoto L_00F4;\nL_FFFFFFFF:\n\tv364 = 0;\n\tgoto L_FFFFFFFF;\nL_00F8:\n\tv364 = v364 + 1;\n\tv564 = v364 == v277;\n\tif (v564) goto L_00C0;\nL_FFFFFFFF:\n\tv208 = v281;\nL_FFFFFFFF:\n\tv212 = v269;\n\tgoto L_0117;\nL_0109:\n\tUnityEngine.GameObject::SetActive(v332, 1);\nL_FFFFFFFF:\n\t;\nL_010A:\n\tv212 = v212 + 1;\n\tv680 = v208 == 1;\n\tv208 = v208 - 1;\n\tif (v680) goto L_00F8;\nL_0117:\n\tv691 = v364 + v342;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v204 @ stack_-80_v11 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v691, v212);\n\tv695 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::GetSandCubeAt(v523.GridHandler, v204);\n\tv698 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(v62, v695);\n\tv699 = ~v698;\nL_FFFFFFFF:\n\t;\n\tif (v699) goto L_010A;\n\tv702 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(v695);\n\tv714 = *([v265 @ X25_v8 (System.Int32)]);\n\tv715 = *([v714 @ X0_v59+E4]) == 0;\n\tif (v715) goto L_013F;\n\tv709 = UnityEngine.Object::op_Inequality(v702, 0);\n\tv711 = ~v709;\nL_FFFFFFFF:\n\t;\n\tif (v711) goto L_010A;\n\tgoto L_0146;\nL_013F:\n\tv710 = UnityEngine.Object::op_Inequality(v702, 0);\n\tv712 = ~v710;\nL_FFFFFFFF:\n\t;\n\tif (v712) goto L_010A;\nL_0146:\n\tv332 = UnityEngine.Component::get_gameObject(v702);\n\tv722 = v332 == 0;\n\tv346 = ~v722;\nL_FFFFFFFF:\n\tv169 = v364;\n\tif (v346) goto L_0109;\n\tv368 = new System.NullReferenceException();\n\tv442 = UnityEngine.Application::get_isPlaying();\n\tv465 = ~v442;\n\tv466 = ~v465;\nL_FFFFFFFF:\n\tv529 = v364;\n\tif (v466) goto L_00E9;\nL_0155:\n\tv476 = UnityEngine.Component::get_gameObject(v529);\n\tgoto L_0160;\nL_0166:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::DestroyEntity(v62, v64);\nL_0174:\n\treturn;\nL_0035:\n\tv66 = _game.CoreSystem.New.Shared.EditMode.EntityActionsBase::TryResolve(this, &v62 @ stack_-68_v2 (_game.BaseLayerSystems.EntitySystem.Core.EntityManager), &v64 @ stack_-70_v2 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv70 = ~v66;\n\tif (v70) goto L_0174;\nL_00AA:\n\tv623 = v620 == v615;\n\tv220 = ~v623;\n\tif (v220) goto L_FFFFFFFF;\nL_00BC:\n\tv224 = v565 == v555;\nL_FFFFFFFF:\n\t;\n\tif (v224) goto L_FFFFFFFF;\nL_00F4:\n\tUnityEngine.Object::Destroy(v479);\n\tgoto L_0166;\nL_0160:\n\tUnityEngine.Object::DestroyImmediate(v476);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal override void DoRemove()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HammerAreaEntityActions::DoRemove");
		}

		[Token(Token = "0x6000934")]
		[Address(RVA = "0x3E8F9AC", Offset = "0x3E8F9AC", Length = "0x230")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0034;\nL_0043:\n\treturn;\nL_004A:\n\tv200 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(em);\n\tv82 = newGroupId;\n\tv132 = 0;\n\tgoto L_005B;\nL_0059:\n\tv132 = v132 + 1;\n\tv117 = *([v254 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv117 = v117 + 0x10;\n\tv260 = v282 - 1;\n\tv259 = v282 != 1;\n\tv282 = v260;\n\tif (v259) goto L_0066;\nL_007F:\n\tv134 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v200);\n\tv84 = v132 < v134;\n\tif (v84) goto L_00A4;\n\tgoto L_0043;\nL_008E:\n\tv79 = *([v117 @ X10_v12]) << 4;\n\tv304 = v254 + v79;\n\tv305 = v304 + 0x138;\n\t*([v305 @ X0_v26])(v135, v200, *([v305 @ X0_v26+8]), v82, Il2CppMethodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv85 = v132 >= v135;\n\tif (v85) goto L_0043;\nL_00A4:\n\tgoto L_00CB;\n\tv409 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(em, v400);\n\tv426 = ~v409;\n\tv82 = Il2CppMethodInfo;\n\tif (v426) goto L_0059;\n\tv424 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(em, v400);\n\tv413 = v424 != oldGroupId;\n\tv82 = Il2CppMethodInfo;\n\tif (v413) goto L_0059;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::SetComponent(em, v400, newGroupId);\n\tv82 = newGroupId;\n\tgoto L_0059;\nL_0034:\n\tv66 = oldGroupId != newGroupId;\n\tif (v66) goto L_004A;\nL_005B:\n\tv254 = *([v200 @ X0_v5 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv282 = *([v254 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv137 = *([v254 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v137) goto L_007F;\nL_0066:\n\tv295 = *([v117 @ X10_v12-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v295) goto L_008E;\nL_00CB:\n\tv400 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v200, v132);\n\tv404 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(em, v400);\n\tv405 = ~v404;\n\tv82 = 0;\n\tif (v405) goto L_0059;\n")]
		private static void CascadeGroupIdToCovers(EntityManager em, int oldGroupId, int newGroupId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HammerAreaEntityActions::CascadeGroupIdToCovers");
		}

		[Token(Token = "0x6000935")]
		[Address(RVA = "0x3E901DC", Offset = "0x3E901DC", Length = "0x208")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\nL_002B:\n\tv60 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(em);\n\tv77 = *([v60 @ X0_v5 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv191 = *([v77 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv79 = *([v77 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v79) goto L_0056;\n\tv190 = *([v77 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv190 = v190 + 0x10;\n\tv176 = v191 - 1;\n\tv156 = v191 != 1;\n\tv191 = v176;\n\tif (v156) goto L_003D;\nL_0056:\n\tv204 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v60);\n\tv287 = v204 - 1;\n\tv215 = v204 >= 1;\n\tif (v215) goto L_007D;\n\tgoto L_00E5;\nL_0065:\n\tv218 = *([v190 @ X10_v13]) << 4;\n\tv219 = v77 + v218;\n\tv220 = v219 + 0x138;\n\t*([v220 @ X0_v27])(v224, v60, *([v220 @ X0_v27+8]), methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv228 = v224 < 1;\n\tv287 = v224 - 1;\n\tif (v228) goto L_00E5;\nL_007D:\n\tgoto L_0091;\nL_007E:\n\tv283 = v287 - 1;\n\tv269 = v287 <= 0;\n\tv287 = v283;\n\tif (v269) goto L_00E5;\nL_0091:\n\tgoto L_00B8;\n\tv388 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(em, v379);\n\tv413 = ~v388;\n\tif (v413) goto L_007E;\n\tv411 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(em, v379);\n\tv392 = v411 != groupId;\n\tif (v392) goto L_007E;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::DestroyEntity(em, v379);\n\tgoto L_007E;\nL_00E5:\n\treturn;\nL_003D:\n\tv196 = *([v190 @ X10_v13-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v196) goto L_0065;\nL_00B8:\n\tv379 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v60, v287);\n\tv383 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(em, v379);\n\tv384 = ~v383;\n\tif (v384) goto L_007E;\n")]
		private static void DestroyCoversByGroupId(EntityManager em, int groupId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HammerAreaEntityActions::DestroyCoversByGroupId");
		}

		[Token(Token = "0x6000936")]
		[Address(RVA = "0x3E903E4", Offset = "0x3E903E4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.New.Shared.EditMode.EntityActionsBase::.ctor(this);\n\treturn;\n")]
		public HammerAreaEntityActions()
		{
		}
	}
}
