using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.Shared.Components;
using _game.CoreSystem.New.Shared.EditMode;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.ECS.IdentifierTags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Data;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.EditMode;
using _game.CoreSystem.SandSystem.Components;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts
{
	[Token(Token = "0x200014B")]
	public class TunnelEntityActions : SandCubeFamilyEntityActions
	{
		[Token(Token = "0x4000431")]
		[FieldOffset(Offset = "0x38")]
		private List<TunnelQueueItem> Queue;

		[Token(Token = "0x6000673")]
		[Address(RVA = "0x3DB6710", Offset = "0x3DB6710", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.New.Shared.EditMode.EntityActionsBase::BindCore(this, entity, history);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelEntityActions::RefreshQueueView(this);\n\treturn;\n")]
		public void Bind(Entity entity, EditorHistory history)
		{
			BindCore(entity, history);
			RefreshQueueView();
		}

		[Token(Token = "0x6000674")]
		[Address(RVA = "0x3DB6738", Offset = "0x3DB6738", Length = "0x18C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelQueueItem>::Clear(v49);\n\tv67 = v49.Count < 1;\n\tif (v67) goto L_003D;\nL_003D:\n\tv153 = _game.CoreSystem.New.Shared.EditMode.EntityActionsBase::TryResolve(this, &v88 @ stack_-48_v3 (_game.BaseLayerSystems.EntitySystem.Core.EntityManager), &v86 @ stack_-50_v3 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv156 = ~v153;\n\tif (v156) goto L_009D;\n\tv129 = _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Data.TunnelQueueHelper::GetOrderedSlots(v88, v86);\n\tv222 = v129.Count < 1;\n\tif (v222) goto L_009D;\n\tv84 = 0;\n\tgoto L_006F;\nL_005D:\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelQueueItem>::Add(v130, v262);\nL_005E:\n\tv84 = v84 + 1;\n\tv223 = v84 >= v129.Count;\n\tif (v223) goto L_009D;\nL_006F:\n\tv259 = System.Collections.Generic.List`1<System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>::get_Item(v129, v84);\n\tv262 = _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelEntityActions::SlotToItem(v88, v259);\n\tv263 = v262 == 0;\n\tif (v263) goto L_005E;\n\tv130 = this.Queue;\n\tgoto L_005D;\nL_009D:\n\treturn;\nL_0021:\n\tv49 = this.Queue;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RefreshQueueView()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TunnelEntityActions::RefreshQueueView");
		}

		[Token(Token = "0x6000675")]
		[Address(RVA = "0x3DB6C58", Offset = "0x3DB6C58", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv55.direction = direction;\n\tv79 = new System.Action`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelEntityActions>();\n\tSystem.Action`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelEntityActions>::.ctor(v79, v55, Il2CppMethodInfo);\n\tv91 = v55.direction;\n\t// 71 Box v94 @ X0_v8 (System.Object), typeof(_game.CoreSystem.SandSystem.Components.TunnelDirection), &v91 @ stack_-54_v1 (_game.CoreSystem.SandSystem.Components.TunnelDirection)\n\tv129 = System.String::Format(\"SetTunnelDirection({0})\", v94);\n\t_game.CoreSystem.New.Shared.EditMode.EntityActionsBase::ForEachSelected(this, v79, v129);\n\treturn;\nL_002B:\n\tv55 = new _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelEntityActions+<>c__DisplayClass3_0();\n\tSystem.Object::.ctor(v55);\n")]
		public void SetDirection(TunnelDirection direction)
		{
			Action<TunnelEntityActions> action = delegate(TunnelEntityActions a)
			{
				a.DoSetDirection(direction);
			};
			TunnelDirection tunnelDirection = direction;
			object arg = tunnelDirection;
			string label = $"SetTunnelDirection({arg})";
			ForEachSelected(action, label);
		}

		[Token(Token = "0x6000676")]
		[Address(RVA = "0x3DB6DA0", Offset = "0x3DB6DA0", Length = "0x1C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv75 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v49, v51);\n\tv79 = ~v75;\n\tif (v79) goto L_005F;\n\tv200 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(v49, v51);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::SetComponent(v49, v51, direction);\n\tv207 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(v51);\n\tv208 = v207 == 0;\n\tif (v208) goto L_FFFFFFFF;\n\tv210 = UnityEngine.Component::get_gameObject(v207);\nL_FFFFFFFF:\n\tv159 = v210;\n\tgoto L_0054;\nL_0054:\n\tv74 = UnityEngine.Object::op_Inequality(v159, 0);\n\tv233 = ~v74;\n\tv78 = ~v233;\n\tif (v78) goto L_0073;\nL_005F:\n\treturn;\nL_FFFFFFFF:\n\tv159 = 0;\n\tgoto L_0054;\nL_0073:\n\tv236 = UnityEngine.GameObject::get_transform(v159);\n\tv238 = direction < 3;\n\tv133 = ~v238;\n\tv130 = direction - 3;\n\tv124 = v130 == 0;\n\tv239 = ~v124;\n\tv109 = v133 & v239;\nL_FFFFFFFF:\n\tv243 = 0;\n\tif (v109) goto L_0088;\n\tv241 = 0x9308000 + 0x190;\n\tv243 = *([v241 @ X8_v14 (System.Int32)+direction @ X1 (_game.CoreSystem.SandSystem.Components.TunnelDirection)*4]);\n\tUnityEngine.Transform::set_localRotation(v236, v102);\n\treturn;\nL_0025:\n\tv53 = _game.CoreSystem.New.Shared.EditMode.EntityActionsBase::TryResolve(this, &v49 @ stack_-38_v2 (_game.BaseLayerSystems.EntitySystem.Core.EntityManager), &v51 @ stack_-40_v2 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv57 = ~v53;\n\tif (v57) goto L_005F;\nL_0088:\n\t// 136 MakeStruct v100 @ AGG3DB6F3C_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, 0, v243 @ V2_v3 (System.Int32)\n\tv102 = UnityEngine.Quaternion::Internal_FromEulerRad(v100);\n")]
		private void DoSetDirection(TunnelDirection direction)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TunnelEntityActions::DoSetDirection");
		}

		[Token(Token = "0x6000677")]
		[Address(RVA = "0x3DB6F84", Offset = "0x3DB6F84", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv47.kind = 0;\n\tgoto L_0050;\nL_0050:\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelQueueItem>::Add(v45, v47);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelEntityActions::OnQueueChanged(this);\n\treturn;\nL_0019:\n\tv45 = this.Queue;\n\tv47 = new _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelQueueItem();\n\tSystem.Object::.ctor(v47);\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddSandCube()
		{
			List<TunnelQueueItem> queue = Queue;
			TunnelQueueItem tunnelQueueItem = new TunnelQueueItem();
			tunnelQueueItem.kind = default(TunnelQueueItemKind);
			queue.Add(tunnelQueueItem);
			OnQueueChanged();
		}

		[Token(Token = "0x6000678")]
		[Address(RVA = "0x3DB7160", Offset = "0x3DB7160", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv47.kind = 1;\n\tgoto L_0051;\nL_0051:\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelQueueItem>::Add(v45, v47);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelEntityActions::OnQueueChanged(this);\n\treturn;\nL_0019:\n\tv45 = this.Queue;\n\tv47 = new _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelQueueItem();\n\tSystem.Object::.ctor(v47);\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddLockedSandCube()
		{
			List<TunnelQueueItem> queue = Queue;
			TunnelQueueItem tunnelQueueItem = new TunnelQueueItem();
			tunnelQueueItem.kind = TunnelQueueItemKind.LockedSandCube;
			queue.Add(tunnelQueueItem);
			OnQueueChanged();
		}

		[Token(Token = "0x6000679")]
		[Address(RVA = "0x3DB725C", Offset = "0x3DB725C", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv47.kind = 2;\n\tgoto L_0051;\nL_0051:\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelQueueItem>::Add(v45, v47);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelEntityActions::OnQueueChanged(this);\n\treturn;\nL_0019:\n\tv45 = this.Queue;\n\tv47 = new _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelQueueItem();\n\tSystem.Object::.ctor(v47);\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddKeyedSandCube()
		{
			List<TunnelQueueItem> queue = Queue;
			TunnelQueueItem tunnelQueueItem = new TunnelQueueItem();
			tunnelQueueItem.kind = TunnelQueueItemKind.KeyedSandCube;
			queue.Add(tunnelQueueItem);
			OnQueueChanged();
		}

		[Token(Token = "0x600067A")]
		[Address(RVA = "0x3DB7084", Offset = "0x3DB7084", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv52 = this._history == 0;\n\tif (v52) goto L_0029;\n\t_game.CoreSystem.New.Shared.EditMode.EditorHistory::Push(this._history, \"EditTunnelQueue\");\nL_0029:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelEntityActions::FlushQueueToEcs(this, v42, v44);\n\tv65 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(v44);\n\tv69 = v65 == 0;\n\tif (v69) goto L_0045;\n\tv66 = UnityEngine.Component::GetComponent(v65);\n\tv68 = v66 == 0;\n\tif (v68) goto L_0045;\n\tv93 = _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Data.TunnelQueueHelper::GetSlotCount(v42, v44);\n\tv64 = _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelVisualMono::UpdateQueueCount(v66, v93);\nL_001B:\n\tv47 = _game.CoreSystem.New.Shared.EditMode.EntityActionsBase::TryResolve(this, &v42 @ stack_-28_v2 (_game.BaseLayerSystems.EntitySystem.Core.EntityManager), &v44 @ stack_-30_v2 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv50 = ~v47;\n\tif (v50) goto L_0045;\nL_0045:\n\treturn;\n")]
		private void OnQueueChanged()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TunnelEntityActions::OnQueueChanged");
		}

		[Token(Token = "0x600067B")]
		[Address(RVA = "0x3DB7358", Offset = "0x3DB7358", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv119 = 0;\n\tgoto L_003A;\nL_002B:\n\tv200 = _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Data.TunnelQueueHelper::EnqueueLockedSandCubeSlot(em, tunnelId, v110.cubeColor, v110.lockColor);\nL_002C:\n\tv119 = v119 + 1;\n\tv132 = this.Queue;\nL_003A:\n\tv62 = v119 >= v132.Count;\n\tif (v62) goto L_007E;\n\tv110 = System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelQueueItem>::get_Item(v132, v119);\n\tv173 = v110.kind == 2;\n\tif (v173) goto L_0070;\n\tv182 = v110.kind == 1;\n\tif (v182) goto L_002B;\n\tv193 = v110.kind == 0;\n\tv194 = ~v193;\n\tif (v194) goto L_002C;\n\tv214 = v110.isHidden != 1;\n\tif (v214) goto L_0073;\n\tv218 = _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Data.TunnelQueueHelper::EnqueueHiddenSandCubeSlot(em, tunnelId, v110.cubeColor);\n\tgoto L_002C;\nL_0070:\n\tv192 = _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Data.TunnelQueueHelper::EnqueueKeyedSandCubeSlot(em, tunnelId, v110.cubeColor, v110.keyColor);\n\tgoto L_002C;\nL_0073:\n\tv219 = _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Data.TunnelQueueHelper::EnqueueSandCubeSlot(em, tunnelId, v110.cubeColor);\n\tgoto L_002C;\nL_007E:\n\treturn;\nL_001E:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Data.TunnelQueueHelper::DestroyAllQueuedFor(em, tunnelId);\n\tv132 = this.Queue;\n")]
		private void FlushQueueToEcs(EntityManager em, EntityId tunnelId)
		{
			TunnelQueueHelper.DestroyAllQueuedFor(em, tunnelId);
			List<TunnelQueueItem> queue = Queue;
			int num = 0;
			while (num < queue.Count)
			{
				TunnelQueueItem tunnelQueueItem = queue[num];
				if (tunnelQueueItem.kind != TunnelQueueItemKind.KeyedSandCube)
				{
					if (tunnelQueueItem.kind == TunnelQueueItemKind.LockedSandCube)
					{
						IReadOnlyList<Entity> readOnlyList = TunnelQueueHelper.EnqueueLockedSandCubeSlot(em, tunnelId, tunnelQueueItem.cubeColor, tunnelQueueItem.lockColor);
					}
					else if (tunnelQueueItem.kind == TunnelQueueItemKind.SandCube)
					{
						if (tunnelQueueItem.isHidden)
						{
							IReadOnlyList<Entity> readOnlyList2 = TunnelQueueHelper.EnqueueHiddenSandCubeSlot(em, tunnelId, tunnelQueueItem.cubeColor);
						}
						else
						{
							IReadOnlyList<Entity> readOnlyList3 = TunnelQueueHelper.EnqueueSandCubeSlot(em, tunnelId, tunnelQueueItem.cubeColor);
						}
					}
				}
				else
				{
					IReadOnlyList<Entity> readOnlyList4 = TunnelQueueHelper.EnqueueKeyedSandCubeSlot(em, tunnelId, tunnelQueueItem.cubeColor, tunnelQueueItem.keyColor);
				}
				num++;
				queue = Queue;
			}
		}

		[Token(Token = "0x600067C")]
		[Address(RVA = "0x3DB68C4", Offset = "0x3DB68C4", Length = "0x394")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_001A:\n\tgoto L_001B;\nL_001B:\n\tv62 = slot == 0;\n\tv63 = ~v62;\n\tif (v63) goto L_004B;\n\tgoto L_0139;\nL_004B:\n\tv79 = em == 0;\n\tif (v79) goto L_0133;\n\tv372 = v144.Invalid;\n\tv183 = slot.Count < 1;\n\tif (v183) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv256 = v144.Invalid;\nL_FFFFFFFF:\n\tv257 = 0;\nL_FFFFFFFF:\n\tv286 = v144.Invalid;\n\tgoto L_0074;\nL_FFFFFFFF:\n\tv286 = v290;\nL_0074:\n\tv290 = System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(slot, v257);\n\tv308 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(em, v290);\n\tv316 = v308 == 0;\n\tv317 = ~v316;\n\tif (v317) goto L_FFFFFFFF;\n\tv341 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(em, v290);\n\tv348 = v341 == 0;\n\tif (v348) goto L_008C;\nL_FFFFFFFF:\n\tv256 = v290;\n\tgoto L_0064;\nL_008C:\n\tv371 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(em, v290);\n\tv364 = v371 == 0;\n\tv354 = ~v364;\n\tv349 = ~v354;\n\tif (v349) goto L_009D;\nL_FFFFFFFF:\n\tv372 = v290;\n\tgoto L_009D;\nL_FFFFFFFF:\n\tv99 = v144.Invalid;\nL_FFFFFFFF:\n\tv296 = v144.Invalid;\nL_FFFFFFFF:\n\tv164 = v144.Invalid;\n\tv322 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(em, v164);\n\tv343 = ~v322;\n\tif (v343) goto L_00D6;\n\tv381 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(em, v164);\n\tv396 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(em, v99);\n\tv401 = ~v396;\n\tv402 = ~v401;\nL_FFFFFFFF:\n\tv169 = v381;\nL_FFFFFFFF:\n\tv170 = v381;\n\tif (v402) goto L_00DC;\nL_00C1:\n\tv419 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(em, v296);\n\tv423 = ~v419;\n\tif (v423) goto L_00EA;\n\tv434 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(em, v296);\n\tv443 = ~v434;\n\tif (v443) goto L_FFFFFFFF;\n\tv449 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(em, v296);\nL_FFFFFFFF:\n\tv167 = v449;\n\tgoto L_0110;\nL_00D6:\n\tv386 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(em, v99);\n\tv397 = ~v386;\nL_FFFFFFFF:\n\tv169 = 0;\nL_FFFFFFFF:\n\tv170 = 0;\n\tif (v397) goto L_00C1;\nL_00DC:\n\tv411 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(em, v99);\n\tv422 = ~v411;\n\tif (v422) goto L_FFFFFFFF;\n\tv429 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(em, v99);\nL_FFFFFFFF:\n\tv166 = v429;\n\tgoto L_0100;\nL_00EA:\n\treturnVal2 = new _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelQueueItem();\n\tSystem.Object::.ctor(returnVal2);\n\treturnVal2.kind = 0;\n\treturnVal2.cubeColor = v169;\n\tv460 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(em, v164);\n\treturnVal2.isHidden = v460;\n\tgoto L_0128;\nL_FFFFFFFF:\n\tv166 = 0;\n\treturnVal2.kind = 1;\n\treturnVal2.cubeColor = v170;\n\treturnVal2.lockColor = v166;\n\tgoto L_0128;\nL_FFFFFFFF:\n\tv167 = 0;\n\treturnVal2.kind = 2;\n\treturnVal2.cubeColor = v169;\n\treturnVal2.keyColor = v167;\nL_0133:\n\tv107 = slot.Count < 1;\n\tif (v107) goto L_0139;\n\tv147 = System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(slot, 0);\nL_0139:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\nL_00A3:\n\tv301 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(em, v164);\n\tv311 = ~v301;\nL_FFFFFFFF:\n\treturnVal2 = 0;\n\tif (v311) goto L_0128;\nL_0064:\n\tv257 = v257 + 1;\n\tv260 = v257 >= slot.Count;\nL_FFFFFFFF:\n\tv99 = v256;\nL_FFFFFFFF:\n\tv296 = v372;\nL_FFFFFFFF:\n\tv164 = v286;\n\tif (v260) goto L_00A3;\nL_009D:\n\tgoto L_0064;\nL_0128:\n\treturn returnVal2;\nL_0110:\n\treturnVal2 = new _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelQueueItem();\n\tSystem.Object::.ctor(returnVal2);\nL_0100:\n\treturnVal2 = new _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelQueueItem();\n\tSystem.Object::.ctor(returnVal2);\n")]
		private static TunnelQueueItem SlotToItem(EntityManager em, List<Entity> slot)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TunnelEntityActions::SlotToItem");
			return default;
		}

		[Token(Token = "0x600067D")]
		[Address(RVA = "0x3DB7484", Offset = "0x3DB7484", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\t_game.CoreSystem.New.Shared.EditMode.EntityActionsBase::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelQueueItem>();\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelQueueItem>::.ctor(v48);\n\tthis.Queue = v48;\n")]
		public TunnelEntityActions()
		{
			List<TunnelQueueItem> queue = new List<TunnelQueueItem>();
			Queue = queue;
		}
	}
}
