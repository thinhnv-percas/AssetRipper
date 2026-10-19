using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.MoldSystem;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.MoldSystem.Core.Components.Tags;
using _game.CoreSystem.New.MoldSystem.EditMode;
using _game.CoreSystem.New.Shared.Components;
using _game.CoreSystem.New.Shared.EditMode;

namespace _game.CoreSystem.New.MoldSystem.Visual.EditMode
{
	[Token(Token = "0x20002B0")]
	public class MoldEntityActions : EntityActionsBase
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20002B1")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000853")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000854")]
			public static Action<MoldEntityActions> _003C_003E9__5_0;

			[Token(Token = "0x6000C0C")]
			[Address(RVA = "0x3ECF588", Offset = "0x3ECF588", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.MoldSystem.Visual.EditMode.MoldEntityActions+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000C0D")]
			[Address(RVA = "0x3ECF5EC", Offset = "0x3ECF5EC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal void _003CToggleHidden_003Eb__5_0(MoldEntityActions a)
			{
				a.DoToggleHidden();
			}
		}

		[Token(Token = "0x170000FB")]
		private static MoldEditorMutations _mutations
		{
			[Token(Token = "0x6000C00")]
			[Address(RVA = "0x3ECE984", Offset = "0x3ECE984", Length = "0x4C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001B:\n\treturn v40.Instance;\n")]
			get
			{
				return MoldEditorMutations.Instance;
			}
		}

		[Token(Token = "0x6000C01")]
		[Address(RVA = "0x3ECE9D0", Offset = "0x3ECE9D0", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\treturn;\nL_001A:\n\tthis._entity = entity;\n\tv52 = UnityEngine.Component::GetComponent(this);\n\tthis._entityMono = v52;\n\tthis._history = history;\n")]
		public void Bind(Entity entity, EditorHistory history)
		{
			_entity = entity;
			EntityMono component = GetComponent<EntityMono>();
			_entityMono = component;
			_history = history;
		}

		[Token(Token = "0x6000C02")]
		[Address(RVA = "0x3ECEA58", Offset = "0x3ECEA58", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv55.newColor = newColor;\n\tv79 = new System.Action`1<_game.CoreSystem.New.MoldSystem.Visual.EditMode.MoldEntityActions>();\n\tSystem.Action`1<_game.CoreSystem.New.MoldSystem.Visual.EditMode.MoldEntityActions>::.ctor(v79, v55, Il2CppMethodInfo);\n\tv91 = v55.newColor;\n\t// 71 Box v94 @ X0_v8 (System.Object), typeof(_game.CoreSystem.GameColor), &v91 @ stack_-54_v1 (_game.CoreSystem.GameColor)\n\tv129 = System.String::Format(\"ChangeColor({0})\", v94);\n\t_game.CoreSystem.New.Shared.EditMode.EntityActionsBase::ForEachSelected(this, v79, v129);\n\treturn;\nL_002B:\n\tv55 = new _game.CoreSystem.New.MoldSystem.Visual.EditMode.MoldEntityActions+<>c__DisplayClass3_0();\n\tSystem.Object::.ctor(v55);\n")]
		public void ChangeColor(GameColor newColor)
		{
			Action<MoldEntityActions> action = delegate(MoldEntityActions a)
			{
				a.DoChangeColor(newColor);
			};
			GameColor gameColor = newColor;
			object arg = gameColor;
			string label = $"ChangeColor({arg})";
			ForEachSelected(action, label);
		}

		[Token(Token = "0x6000C03")]
		[Address(RVA = "0x3ECEBA0", Offset = "0x3ECEBA0", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv75 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v49, v51);\n\tv79 = ~v75;\n\tif (v79) goto L_0061;\n\tv130 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(v49, v51);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::SetComponent(v49, v51, newColor);\n\tv76 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v49, v51);\n\tv134 = v76 == 0;\n\tv80 = ~v134;\n\tif (v80) goto L_0061;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(v49, v51, 0);\nL_0061:\n\treturn;\nL_0027:\n\tv52 = _game.CoreSystem.New.Shared.EditMode.EntityActionsBase::TryResolve(this, &v49 @ stack_-38_v2 (_game.BaseLayerSystems.EntitySystem.Core.EntityManager), &v51 @ stack_-40_v2 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv56 = ~v52;\n\tif (v56) goto L_0061;\n")]
		private void DoChangeColor(GameColor newColor)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldEntityActions::DoChangeColor");
		}

		[Token(Token = "0x6000C04")]
		[Address(RVA = "0x3ECECDC", Offset = "0x3ECECDC", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0015;\nL_0015:\n\tv95 = v49.<>9__5_0;\n\tv51 = v49.<>9__5_0 == 0;\n\tif (v51) goto L_004B;\nL_0029:\n\t_game.CoreSystem.New.Shared.EditMode.EntityActionsBase::ForEachSelected(this, v95, \"ToggleHidden\");\n\treturn;\nL_004B:\n\tgoto L_0053;\n\tv156 = this == 0;\n\tv92 = ~v156;\n\tv95 = v128;\n\tif (v92) goto L_0029;\n\tthrow System.NullReferenceException;\nL_0053:\n\tv128 = new System.Action`1<_game.CoreSystem.New.MoldSystem.Visual.EditMode.MoldEntityActions>();\n\tSystem.Action`1<_game.CoreSystem.New.MoldSystem.Visual.EditMode.MoldEntityActions>::.ctor(v128, v123.<>9, Il2CppMethodInfo);\n\tv152.<>9__5_0 = v128;\n")]
		public void ToggleHidden()
		{
			Action<MoldEntityActions> action = _003C_003Ec._003C_003E9__5_0;
			if (_003C_003Ec._003C_003E9__5_0 == null)
			{
				Action<MoldEntityActions> action2 = (_003C_003Ec._003C_003E9__5_0 = delegate(MoldEntityActions a)
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

		[Token(Token = "0x6000C05")]
		[Address(RVA = "0x3ECEE14", Offset = "0x3ECEE14", Length = "0x20C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\tv70 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v44, v46);\n\tv74 = ~v70;\n\tif (v74) goto L_006A;\n\tv160 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v44, v46);\n\tv164 = ~v160;\n\tif (v164) goto L_0072;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::RemoveComponent(v44, v46);\n\tv168 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v44, v46);\n\tv172 = v168 == 0;\n\tv173 = ~v172;\n\tv69 = v168;\n\tif (v173) goto L_0064;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(v44, v46, 0);\n\tv69 = v44;\nL_0064:\n\t_game.CoreSystem.New.MoldSystem.Visual.EditMode.MoldEntityActions::EnsureCoverOpen(v69, v44, v46);\nL_006A:\n\treturn;\nL_0072:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(v44, v46, 0);\n\tv170 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v44, v46);\n\tv175 = v170 == 0;\n\tv176 = ~v175;\n\tif (v176) goto L_008F;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(v44, v46, 0);\nL_008F:\n\tv71 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v44, v46);\n\tv193 = v71 == 0;\n\tv75 = ~v193;\n\tif (v75) goto L_006A;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(v44, v46, 0);\n\treturn;\nL_002D:\n\tv47 = _game.CoreSystem.New.Shared.EditMode.EntityActionsBase::TryResolve(this, &v44 @ stack_-28_v2 (_game.BaseLayerSystems.EntitySystem.Core.EntityManager), &v46 @ stack_-30_v2 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv51 = ~v47;\n\tif (v51) goto L_006A;\n")]
		private void DoToggleHidden()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldEntityActions::DoToggleHidden");
		}

		[Token(Token = "0x6000C06")]
		[Address(RVA = "0x3ECF1E0", Offset = "0x3ECF1E0", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\nL_0016:\n\treturn;\n")]
		public void MoveBack()
		{
		}

		[Token(Token = "0x6000C07")]
		[Address(RVA = "0x3ECF21C", Offset = "0x3ECF21C", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\nL_0016:\n\treturn;\n")]
		public void MoveForward()
		{
		}

		[Token(Token = "0x6000C08")]
		[Address(RVA = "0x3ECF218", Offset = "0x3ECF218", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void RunColumnShift(int deltaY, string label)
		{
		}

		[Token(Token = "0x6000C09")]
		[Address(RVA = "0x3ECF254", Offset = "0x3ECF254", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv71 = moves.Count < 1;\n\tif (v71) goto L_007B;\n\tv160 = 0;\n\tgoto L_0052;\nL_003C:\n\t;\n\tv287 = _game.CoreSystem.New.MoldSystem.EditMode.MoldEditorMutations::TryMoveMold(v157.Instance, v73, v240.Item3);\nL_0041:\n\tv160 = v160 + 1;\n\tv189 = v160 >= moves.Count;\n\tif (v189) goto L_007B;\nL_0052:\n\tv240 = System.Collections.Generic.List`1<System.ValueTuple`3<System.Object, _game.CoreSystem.New.GridEcsBinding.GridCoord, _game.CoreSystem.New.GridEcsBinding.GridCoord>>::get_Item(moves, v160);\n\tv277 = _game.CoreSystem.New.Shared.EditMode.EntityActionsBase::TryResolve(v240.Item1, &v55 @ stack_-70_v1 (_game.BaseLayerSystems.EntitySystem.Core.EntityManager), &v73 @ stack_-68_v5 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv278 = ~v277;\n\tif (v278) goto L_0041;\n\tgoto L_003C;\nL_007B:\n\treturn;\nL_001D:\n\tv55 = 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ApplyMoves(List<(MoldEntityActions actions, GridCoord src, GridCoord tgt)> moves)
		{
			EntityManager em = null;
			if (moves.Count < 1)
			{
				return;
			}
			int num = 0;
			do
			{
				(object, GridCoord, GridCoord) tuple = moves[num];
				if (((EntityActionsBase)tuple.Item1).TryResolve(out em, out Entity entity))
				{
					bool flag = MoldEditorMutations.Instance.TryMoveMold(entity, tuple.Item3);
				}
				num++;
			}
			while (num < moves.Count);
		}

		[Token(Token = "0x6000C0A")]
		[Address(RVA = "0x3ECF020", Offset = "0x3ECF020", Length = "0x1C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0034;\nL_0034:\n\tv53 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(em, entity);\n\tv59 = v53 == 0;\n\tv60 = ~v59;\n\tif (v60) goto L_0087;\n\tv69 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(em, entity);\n\tv116 = ~v69;\n\tif (v116) goto L_004C;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::RemoveComponent(em, entity);\nL_004C:\n\tv134 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(em, entity);\n\tv138 = ~v134;\n\tif (v138) goto L_005A;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::RemoveComponent(em, entity);\nL_005A:\n\tv156 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(em, entity);\n\tv159 = ~v156;\n\tif (v159) goto L_0069;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::RemoveComponent(em, entity);\nL_0069:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(em, entity, 0);\n\tv78 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(entity);\n\tv81 = v78 == 0;\n\tif (v81) goto L_0087;\n\tv79 = UnityEngine.Component::GetComponent(v78);\n\tv82 = v79 == 0;\n\tif (v82) goto L_0087;\n\tv79 = _game.CoreSystem.MoldSystem.MoldMonoBase::SetOpen_Editor(v79);\n\treturn;\nL_0087:\n\treturn;\n")]
		private void EnsureCoverOpen(EntityManager em, Entity entity)
		{
			if (!em.HasComponent<CoverOpenTag>(entity))
			{
				if (em.HasComponent<CoverClosedTag>(entity))
				{
					em.RemoveComponent<CoverClosedTag>(entity);
				}
				if (em.HasComponent<CoverOpeningTag>(entity))
				{
					em.RemoveComponent<CoverOpeningTag>(entity);
				}
				if (em.HasComponent<CoverClosingTag>(entity))
				{
					em.RemoveComponent<CoverClosingTag>(entity);
				}
				em.AddComponent(entity, default(CoverOpenTag));
				entity.GetMonoBinding()?.GetComponent<MoldMonoBase>()?.SetOpen_Editor();
			}
		}

		[Token(Token = "0x6000C0B")]
		[Address(RVA = "0x3ECF580", Offset = "0x3ECF580", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public MoldEntityActions()
		{
		}
	}
}
