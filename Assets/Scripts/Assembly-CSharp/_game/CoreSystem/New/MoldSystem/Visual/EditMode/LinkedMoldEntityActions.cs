using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.MoldSystem.Core.Components;
using _game.CoreSystem.New.MoldSystem.Core.Components.Commands;
using _game.CoreSystem.New.MoldSystem.Core.Components.Tags;
using _game.CoreSystem.New.MoldSystem.LinkSystem.UnityBindings;
using _game.CoreSystem.New.Shared.EditMode;

namespace _game.CoreSystem.New.MoldSystem.Visual.EditMode
{
	[Token(Token = "0x20002AE")]
	public class LinkedMoldEntityActions : EntityActionsBase
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20002AF")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000851")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000852")]
			public static Action<LinkedMoldEntityActions> _003C_003E9__2_0;

			[Token(Token = "0x6000BFD")]
			[Address(RVA = "0x3ECE900", Offset = "0x3ECE900", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.MoldSystem.Visual.EditMode.LinkedMoldEntityActions+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000BFE")]
			[Address(RVA = "0x3ECE964", Offset = "0x3ECE964", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal void _003CBreakLink_003Eb__2_0(LinkedMoldEntityActions a)
			{
				a.DoBreakLink();
			}
		}

		[Token(Token = "0x4000850")]
		[FieldOffset(Offset = "0x38")]
		internal MoldLinkVisualController _linkVisual;

		[Token(Token = "0x6000BF6")]
		[Address(RVA = "0x3ECE428", Offset = "0x3ECE428", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tthis._linkVisual = linkVisual;\n\treturn;\nL_001B:\n\tthis._entity = entity;\n\tv53 = UnityEngine.Component::GetComponent(this);\n\tthis._entityMono = v53;\n\tthis._history = history;\n")]
		public void Bind(Entity entity, EditorHistory history, MoldLinkVisualController linkVisual)
		{
			_entity = entity;
			EntityMono component = GetComponent<EntityMono>();
			_entityMono = component;
			_history = history;
			_linkVisual = linkVisual;
		}

		[Token(Token = "0x6000BF7")]
		[Address(RVA = "0x3ECE4C4", Offset = "0x3ECE4C4", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0015;\nL_0015:\n\tv95 = v49.<>9__2_0;\n\tv51 = v49.<>9__2_0 == 0;\n\tif (v51) goto L_004B;\nL_0029:\n\t_game.CoreSystem.New.Shared.EditMode.EntityActionsBase::ForEachSelected(this, v95, \"BreakLink\");\n\treturn;\nL_004B:\n\tgoto L_0053;\n\tv156 = this == 0;\n\tv92 = ~v156;\n\tv95 = v128;\n\tif (v92) goto L_0029;\n\tthrow System.NullReferenceException;\nL_0053:\n\tv128 = new System.Action`1<_game.CoreSystem.New.MoldSystem.Visual.EditMode.LinkedMoldEntityActions>();\n\tSystem.Action`1<_game.CoreSystem.New.MoldSystem.Visual.EditMode.LinkedMoldEntityActions>::.ctor(v128, v123.<>9, Il2CppMethodInfo);\n\tv152.<>9__2_0 = v128;\n")]
		public void BreakLink()
		{
			Action<LinkedMoldEntityActions> action = _003C_003Ec._003C_003E9__2_0;
			if (_003C_003Ec._003C_003E9__2_0 == null)
			{
				Action<LinkedMoldEntityActions> action2 = (_003C_003Ec._003C_003E9__2_0 = delegate(LinkedMoldEntityActions a)
				{
					a.DoBreakLink();
				});
				bool flag = (object)this == null;
				bool flag2 = !flag;
				action = action2;
				if (!flag2)
				{
					throw new NullReferenceException();
				}
			}
			ForEachSelected(action, "BreakLink");
		}

		[Token(Token = "0x6000BF8")]
		[Address(RVA = "0x3ECE5FC", Offset = "0x3ECE5FC", Length = "0x270")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv83 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v48, v50);\n\tv91 = ~v83;\n\tif (v91) goto L_0058;\n\tv195 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(v48, v50);\n\tgoto L_004D;\nL_004D:\n\tv82 = _game.BaseLayerSystems.EntitySystem.Core.EntityId::get_IsValid(&v66 @ stack_-48_v6 (_game.BaseLayerSystems.EntitySystem.Core.EntityId));\n\tv206 = ~v82;\n\tv90 = ~v206;\n\tif (v90) goto L_0064;\nL_0058:\n\treturn;\nL_0064:\n\tv85 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::EntityExists(v48, v66);\n\tv93 = ~v85;\n\tif (v93) goto L_0058;\n\tgoto L_0077;\nL_0077:\n\tv218 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v48, v50);\n\tv220 = v218 == 0;\n\tv221 = ~v220;\n\tif (v221) goto L_008C;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(v48, v50, 0);\nL_008C:\n\tv230 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v48, v50);\n\tv232 = v230 == 0;\n\tv233 = ~v232;\n\tif (v233) goto L_009F;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(v48, v50, 0);\nL_009F:\n\tv241 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v48, v66);\n\tv243 = v241 == 0;\n\tv244 = ~v243;\n\tif (v244) goto L_00B2;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(v48, v66, 0);\nL_00B2:\n\tv86 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v48, v66);\n\tv253 = v86 == 0;\n\tv94 = ~v253;\n\tif (v94) goto L_0058;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(v48, v66, 0);\n\treturn;\nL_002F:\n\tv51 = _game.CoreSystem.New.Shared.EditMode.EntityActionsBase::TryResolve(this, &v48 @ stack_-38_v2 (_game.BaseLayerSystems.EntitySystem.Core.EntityManager), &v50 @ stack_-40_v2 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv55 = ~v51;\n\tif (v55) goto L_0058;\n")]
		private void DoBreakLink()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LinkedMoldEntityActions::DoBreakLink");
		}

		[Token(Token = "0x6000BF9")]
		[Address(RVA = "0x3ECE86C", Offset = "0x3ECE86C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void LinkMolds()
		{
		}

		[Token(Token = "0x6000BFA")]
		[Address(RVA = "0x3ECE870", Offset = "0x3ECE870", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\treturnVal1 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v44, v46);\nL_0028:\n\treturn returnVal1;\nL_0018:\n\treturnVal1 = _game.CoreSystem.New.Shared.EditMode.EntityActionsBase::TryResolve(this, &v44 @ stack_-28_v2 (_game.BaseLayerSystems.EntitySystem.Core.EntityManager), &v46 @ stack_-30_v2 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv48 = ~returnVal1;\n\tif (v48) goto L_0028;\n")]
		private bool IsCurrentlyLinked()
		{
			bool flag = TryResolve(out var em, out var entity);
			if (flag)
			{
				flag = em.HasComponent<MoldLinkedComponent>(entity);
			}
			return flag;
		}

		[Token(Token = "0x6000BFB")]
		[Address(RVA = "0x3ECE8F0", Offset = "0x3ECE8F0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n")]
		private bool CanLinkSelected()
		{
			return false;
		}

		[Token(Token = "0x6000BFC")]
		[Address(RVA = "0x3ECE8F8", Offset = "0x3ECE8F8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public LinkedMoldEntityActions()
		{
		}
	}
}
