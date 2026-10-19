using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.Shared.Components;
using _game.CoreSystem.New.Shared.Components.Tags;
using _game.CoreSystem.New.Shared.EditMode;
using _game.CoreSystem.New.TopGridSystem.Core.Handlers;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts;

namespace _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.EditMode
{
	[Token(Token = "0x200013C")]
	public class SandCubeEntityActions : SandCubeFamilyEntityActions
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200013D")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000401")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000402")]
			public static Action<SandCubeEntityActions> _003C_003E9__1_0;

			[Token(Token = "0x4000403")]
			public static Action<SandCubeEntityActions> _003C_003E9__5_0;

			[Token(Token = "0x4000404")]
			public static Action<SandCubeEntityActions> _003C_003E9__7_0;

			[Token(Token = "0x4000405")]
			public static Action<SandCubeEntityActions> _003C_003E9__9_0;

			[Token(Token = "0x6000654")]
			[Address(RVA = "0x3DB51D4", Offset = "0x3DB51D4", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.EditMode.SandCubeEntityActions+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000655")]
			[Address(RVA = "0x3DB5238", Offset = "0x3DB5238", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal void _003CBreak_003Eb__1_0(SandCubeEntityActions a)
			{
				a.DoBreak();
			}

			internal void _003CToggleHidden_003Eb__5_0(SandCubeEntityActions a)
			{
				a.DoToggleHidden();
			}

			internal void _003CToggleFrozen_003Eb__7_0(SandCubeEntityActions a)
			{
				a.DoToggleFrozen();
			}

			internal void _003CToggleFreezer_003Eb__9_0(SandCubeEntityActions a)
			{
				a.DoToggleFreezer();
			}
		}

		[Token(Token = "0x6000647")]
		[Address(RVA = "0x3DB4474", Offset = "0x3DB4474", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.New.Shared.EditMode.EntityActionsBase::BindCore(this, entity, history);\n\treturn;\n")]
		public void Bind(Entity entity, EditorHistory history)
		{
			BindCore(entity, history);
		}

		[Token(Token = "0x6000648")]
		[Address(RVA = "0x3DB447C", Offset = "0x3DB447C", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0015;\nL_0015:\n\tv95 = v49.<>9__1_0;\n\tv51 = v49.<>9__1_0 == 0;\n\tif (v51) goto L_004B;\nL_0029:\n\t_game.CoreSystem.New.Shared.EditMode.EntityActionsBase::ForEachSelected(this, v95, \"Break\");\n\treturn;\nL_004B:\n\tgoto L_0053;\n\tv156 = this == 0;\n\tv92 = ~v156;\n\tv95 = v128;\n\tif (v92) goto L_0029;\n\tthrow System.NullReferenceException;\nL_0053:\n\tv128 = new System.Action`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.EditMode.SandCubeEntityActions>();\n\tSystem.Action`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.EditMode.SandCubeEntityActions>::.ctor(v128, v123.<>9, Il2CppMethodInfo);\n\tv152.<>9__1_0 = v128;\n")]
		public void Break()
		{
			Action<SandCubeEntityActions> action = _003C_003Ec._003C_003E9__1_0;
			if (_003C_003Ec._003C_003E9__1_0 == null)
			{
				Action<SandCubeEntityActions> action2 = (_003C_003Ec._003C_003E9__1_0 = delegate(SandCubeEntityActions a)
				{
					a.DoBreak();
				});
				bool flag = (object)this == null;
				bool flag2 = !flag;
				action = action2;
				if (!flag2)
				{
					throw new NullReferenceException();
				}
			}
			ForEachSelected(action, "Break");
		}

		[Token(Token = "0x6000649")]
		[Address(RVA = "0x3DB45B4", Offset = "0x3DB45B4", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv65 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v44, v46);\n\tv94 = v65 == 0;\n\tv68 = ~v94;\n\tif (v68) goto L_0039;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(v44, v46, 0);\nL_0039:\n\treturn;\nL_001C:\n\tv48 = _game.CoreSystem.New.Shared.EditMode.EntityActionsBase::TryResolve(this, &v44 @ stack_-28_v2 (_game.BaseLayerSystems.EntitySystem.Core.EntityManager), &v46 @ stack_-30_v2 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv52 = ~v48;\n\tif (v52) goto L_0039;\n")]
		private void DoBreak()
		{
			if (TryResolve(out var em, out var entity) && !em.HasComponent<PendingBreakTag>(entity))
			{
				em.AddComponent(entity, default(PendingBreakTag));
			}
		}

		[Token(Token = "0x600064A")]
		[Address(RVA = "0x3DB4668", Offset = "0x3DB4668", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv55.newColor = newColor;\n\tv79 = new System.Action`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.EditMode.SandCubeEntityActions>();\n\tSystem.Action`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.EditMode.SandCubeEntityActions>::.ctor(v79, v55, Il2CppMethodInfo);\n\tv91 = v55.newColor;\n\t// 71 Box v94 @ X0_v8 (System.Object), typeof(_game.CoreSystem.GameColor), &v91 @ stack_-54_v1 (_game.CoreSystem.GameColor)\n\tv129 = System.String::Format(\"ChangeColor({0})\", v94);\n\t_game.CoreSystem.New.Shared.EditMode.EntityActionsBase::ForEachSelected(this, v79, v129);\n\treturn;\nL_002B:\n\tv55 = new _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.EditMode.SandCubeEntityActions+<>c__DisplayClass3_0();\n\tSystem.Object::.ctor(v55);\n")]
		public void ChangeColor(GameColor newColor)
		{
			Action<SandCubeEntityActions> action = delegate(SandCubeEntityActions a)
			{
				a.DoChangeColor(newColor);
			};
			GameColor gameColor = newColor;
			object arg = gameColor;
			string label = $"ChangeColor({arg})";
			ForEachSelected(action, label);
		}

		[Token(Token = "0x600064B")]
		[Address(RVA = "0x3DB47B0", Offset = "0x3DB47B0", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv76 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v49, v51);\n\tv80 = ~v76;\n\tif (v80) goto L_0057;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::SetComponent(v49, v51, newColor);\n\tv77 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v49, v51);\n\tv125 = v77 == 0;\n\tv81 = ~v125;\n\tif (v81) goto L_0057;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(v49, v51, 0);\nL_0057:\n\treturn;\nL_0025:\n\tv53 = _game.CoreSystem.New.Shared.EditMode.EntityActionsBase::TryResolve(this, &v49 @ stack_-38_v2 (_game.BaseLayerSystems.EntitySystem.Core.EntityManager), &v51 @ stack_-40_v2 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv57 = ~v53;\n\tif (v57) goto L_0057;\n")]
		private void DoChangeColor(GameColor newColor)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandCubeEntityActions::DoChangeColor");
		}

		[Token(Token = "0x600064C")]
		[Address(RVA = "0x3DB48C8", Offset = "0x3DB48C8", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0015;\nL_0015:\n\tv95 = v49.<>9__5_0;\n\tv51 = v49.<>9__5_0 == 0;\n\tif (v51) goto L_004B;\nL_0029:\n\t_game.CoreSystem.New.Shared.EditMode.EntityActionsBase::ForEachSelected(this, v95, \"ToggleHidden\");\n\treturn;\nL_004B:\n\tgoto L_0053;\n\tv156 = this == 0;\n\tv92 = ~v156;\n\tv95 = v128;\n\tif (v92) goto L_0029;\n\tthrow System.NullReferenceException;\nL_0053:\n\tv128 = new System.Action`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.EditMode.SandCubeEntityActions>();\n\tSystem.Action`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.EditMode.SandCubeEntityActions>::.ctor(v128, v123.<>9, Il2CppMethodInfo);\n\tv152.<>9__5_0 = v128;\n")]
		public void ToggleHidden()
		{
			Action<SandCubeEntityActions> action = _003C_003Ec._003C_003E9__5_0;
			if (_003C_003Ec._003C_003E9__5_0 == null)
			{
				Action<SandCubeEntityActions> action2 = (_003C_003Ec._003C_003E9__5_0 = delegate(SandCubeEntityActions a)
				{
					a.DoToggleHidden();
				});
				bool flag = (object)this == null;
				bool flag2 = !flag;
				action = action2;
				if (!flag2)
				{
					throw new NullReferenceException();
				}
			}
			ForEachSelected(action, "ToggleHidden");
		}

		[Token(Token = "0x600064D")]
		[Address(RVA = "0x3DB4A00", Offset = "0x3DB4A00", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv88 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v42, v44);\n\tv124 = ~v88;\n\tif (v124) goto L_0042;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::RemoveComponent(v42, v44);\n\tgoto L_0047;\nL_0042:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(v42, v44, 0);\nL_0047:\n\tv142 = UnityEngine.Component::GetComponent(this);\n\tgoto L_0052;\nL_0052:\n\tv66 = UnityEngine.Object::op_Inequality(v142, 0);\n\tv149 = ~v66;\n\tv69 = ~v149;\n\tif (v69) goto L_0065;\nL_005B:\n\treturn;\nL_0065:\n\tv111 = v88 ^ 1;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeMonoBase::SetHidden(v142, v111);\n\treturn;\nL_0024:\n\tv47 = _game.CoreSystem.New.Shared.EditMode.EntityActionsBase::TryResolve(this, &v42 @ stack_-28_v2 (_game.BaseLayerSystems.EntitySystem.Core.EntityManager), &v44 @ stack_-30_v2 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv51 = ~v47;\n\tif (v51) goto L_005B;\n")]
		private void DoToggleHidden()
		{
			if (TryResolve(out var em, out var entity))
			{
				bool flag = em.HasComponent<ColorHiddenComponent>(entity);
				if (flag)
				{
					em.RemoveComponent<ColorHiddenComponent>(entity);
				}
				else
				{
					em.AddComponent(entity, default(ColorHiddenComponent));
				}
				SandCubeMonoBase component = GetComponent<SandCubeMonoBase>();
				if (component != null)
				{
					bool hidden = (byte)((flag ? 1u : 0u) ^ 1u) != 0;
					component.SetHidden(hidden);
				}
			}
		}

		[Token(Token = "0x600064E")]
		[Address(RVA = "0x3DB4B70", Offset = "0x3DB4B70", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0015;\nL_0015:\n\tv95 = v49.<>9__7_0;\n\tv51 = v49.<>9__7_0 == 0;\n\tif (v51) goto L_004B;\nL_0029:\n\t_game.CoreSystem.New.Shared.EditMode.EntityActionsBase::ForEachSelected(this, v95, \"ToggleFrozen\");\n\treturn;\nL_004B:\n\tgoto L_0053;\n\tv156 = this == 0;\n\tv92 = ~v156;\n\tv95 = v128;\n\tif (v92) goto L_0029;\n\tthrow System.NullReferenceException;\nL_0053:\n\tv128 = new System.Action`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.EditMode.SandCubeEntityActions>();\n\tSystem.Action`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.EditMode.SandCubeEntityActions>::.ctor(v128, v123.<>9, Il2CppMethodInfo);\n\tv152.<>9__7_0 = v128;\n")]
		public void ToggleFrozen()
		{
			Action<SandCubeEntityActions> action = _003C_003Ec._003C_003E9__7_0;
			if (_003C_003Ec._003C_003E9__7_0 == null)
			{
				Action<SandCubeEntityActions> action2 = (_003C_003Ec._003C_003E9__7_0 = delegate(SandCubeEntityActions a)
				{
					a.DoToggleFrozen();
				});
				bool flag = (object)this == null;
				bool flag2 = !flag;
				action = action2;
				if (!flag2)
				{
					throw new NullReferenceException();
				}
			}
			ForEachSelected(action, "ToggleFrozen");
		}

		[Token(Token = "0x600064F")]
		[Address(RVA = "0x3DB4CA8", Offset = "0x3DB4CA8", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv81 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v44, v46);\n\tv115 = ~v81;\n\tif (v115) goto L_0042;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::RemoveComponent(v44, v46);\n\tv65 = v44;\n\tgoto L_0058;\nL_0042:\n\tv121 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v44, v46);\n\tv122 = ~v121;\n\tif (v122) goto L_0055;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::RemoveComponent(v44, v46);\nL_0055:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(v44, v46, 0);\n\tv65 = v44;\nL_0058:\n\t_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.EditMode.SandCubeEntityActions::ReevalSelfAndNeighbors(v65, v44, v46);\nL_005E:\n\treturn;\nL_0025:\n\tv48 = _game.CoreSystem.New.Shared.EditMode.EntityActionsBase::TryResolve(this, &v44 @ stack_-28_v2 (_game.BaseLayerSystems.EntitySystem.Core.EntityManager), &v46 @ stack_-30_v2 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv52 = ~v48;\n\tif (v52) goto L_005E;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoToggleFrozen()
		{
			if (!TryResolve(out var em, out var entity))
			{
				return;
			}
			SandCubeEntityActions sandCubeEntityActions;
			if (em.HasComponent<FrozenTag>(entity))
			{
				em.RemoveComponent<FrozenTag>(entity);
				sandCubeEntityActions = (SandCubeEntityActions)(object)em;
			}
			else
			{
				if (em.HasComponent<FreezerTag>(entity))
				{
					em.RemoveComponent<FreezerTag>(entity);
				}
				em.AddComponent(entity, default(FrozenTag));
				sandCubeEntityActions = (SandCubeEntityActions)(object)em;
			}
			sandCubeEntityActions.ReevalSelfAndNeighbors(em, entity);
		}

		[Token(Token = "0x6000650")]
		[Address(RVA = "0x3DB4F58", Offset = "0x3DB4F58", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0015;\nL_0015:\n\tv95 = v49.<>9__9_0;\n\tv51 = v49.<>9__9_0 == 0;\n\tif (v51) goto L_004B;\nL_0029:\n\t_game.CoreSystem.New.Shared.EditMode.EntityActionsBase::ForEachSelected(this, v95, \"ToggleFreezer\");\n\treturn;\nL_004B:\n\tgoto L_0053;\n\tv156 = this == 0;\n\tv92 = ~v156;\n\tv95 = v128;\n\tif (v92) goto L_0029;\n\tthrow System.NullReferenceException;\nL_0053:\n\tv128 = new System.Action`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.EditMode.SandCubeEntityActions>();\n\tSystem.Action`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.EditMode.SandCubeEntityActions>::.ctor(v128, v123.<>9, Il2CppMethodInfo);\n\tv152.<>9__9_0 = v128;\n")]
		public void ToggleFreezer()
		{
			Action<SandCubeEntityActions> action = _003C_003Ec._003C_003E9__9_0;
			if (_003C_003Ec._003C_003E9__9_0 == null)
			{
				Action<SandCubeEntityActions> action2 = (_003C_003Ec._003C_003E9__9_0 = delegate(SandCubeEntityActions a)
				{
					a.DoToggleFreezer();
				});
				bool flag = (object)this == null;
				bool flag2 = !flag;
				action = action2;
				if (!flag2)
				{
					throw new NullReferenceException();
				}
			}
			ForEachSelected(action, "ToggleFreezer");
		}

		[Token(Token = "0x6000651")]
		[Address(RVA = "0x3DB5090", Offset = "0x3DB5090", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv81 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v44, v46);\n\tv115 = ~v81;\n\tif (v115) goto L_0042;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::RemoveComponent(v44, v46);\n\tv65 = v44;\n\tgoto L_0058;\nL_0042:\n\tv121 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v44, v46);\n\tv122 = ~v121;\n\tif (v122) goto L_0055;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::RemoveComponent(v44, v46);\nL_0055:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(v44, v46, 0);\n\tv65 = v44;\nL_0058:\n\t_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.EditMode.SandCubeEntityActions::ReevalSelfAndNeighbors(v65, v44, v46);\nL_005E:\n\treturn;\nL_0025:\n\tv48 = _game.CoreSystem.New.Shared.EditMode.EntityActionsBase::TryResolve(this, &v44 @ stack_-28_v2 (_game.BaseLayerSystems.EntitySystem.Core.EntityManager), &v46 @ stack_-30_v2 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv52 = ~v48;\n\tif (v52) goto L_005E;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoToggleFreezer()
		{
			if (!TryResolve(out var em, out var entity))
			{
				return;
			}
			SandCubeEntityActions sandCubeEntityActions;
			if (em.HasComponent<FreezerTag>(entity))
			{
				em.RemoveComponent<FreezerTag>(entity);
				sandCubeEntityActions = (SandCubeEntityActions)(object)em;
			}
			else
			{
				if (em.HasComponent<FrozenTag>(entity))
				{
					em.RemoveComponent<FrozenTag>(entity);
				}
				em.AddComponent(entity, default(FreezerTag));
				sandCubeEntityActions = (SandCubeEntityActions)(object)em;
			}
			sandCubeEntityActions.ReevalSelfAndNeighbors(em, entity);
		}

		[Token(Token = "0x6000652")]
		[Address(RVA = "0x3DB4DE4", Offset = "0x3DB4DE4", Length = "0x174")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\nL_002D:\n\tv55 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(em, entity);\n\tv61 = v55 == 0;\n\tif (v61) goto L_0043;\n\tv116 = 0xB2D1000 + 0xA0;\n\tgoto L_0038;\nL_0038:\n\tv148 = UnityEngine.Object::FindObjectOfType /* +1 sharing this address */(*([v116 @ X22_v8 (System.Int32)]));\n\tv140 = v148 == 0;\n\tv141 = ~v140;\n\tif (v141) goto L_0051;\n\tgoto L_0076;\nL_0043:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(em, entity, 0);\n\tv116 = 0xB2D1000 + 0xA0;\n\tgoto L_0038;\nL_0051:\n\tv153 = *([v148 @ X0_v6+30]) == 0;\n\tif (v153) goto L_0076;\n\tv157 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(em, entity);\n\tv95 = ~v157;\n\tif (v95) goto L_0076;\n\tv166 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(em, entity);\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::MarkNeighborsForReeval(*([v148 @ X0_v6+30]), v166);\n\treturn;\nL_0076:\n\treturn;\n")]
		private void ReevalSelfAndNeighbors(EntityManager em, Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandCubeEntityActions::ReevalSelfAndNeighbors");
		}

		[Token(Token = "0x6000653")]
		[Address(RVA = "0x3DB51CC", Offset = "0x3DB51CC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.New.Shared.EditMode.EntityActionsBase::.ctor(this);\n\treturn;\n")]
		public SandCubeEntityActions()
		{
		}
	}
}
