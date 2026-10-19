using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.Shared.Components;
using _game.CoreSystem.New.Shared.Components.Tags;
using _game.CoreSystem.New.Shared.EditMode;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.EditMode;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts
{
	[Token(Token = "0x20001E4")]
	public class KeyEntityActions : SandCubeFamilyEntityActions
	{
		[Token(Token = "0x600089A")]
		[Address(RVA = "0x3E826AC", Offset = "0x3E826AC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.New.Shared.EditMode.EntityActionsBase::BindCore(this, entity, history);\n\treturn;\n")]
		public void Bind(Entity entity, EditorHistory history)
		{
			BindCore(entity, history);
		}

		[Token(Token = "0x600089B")]
		[Address(RVA = "0x3E826B4", Offset = "0x3E826B4", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv55.color = color;\n\tv79 = new System.Action`1<_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.KeyEntityActions>();\n\tSystem.Action`1<_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.KeyEntityActions>::.ctor(v79, v55, Il2CppMethodInfo);\n\tv91 = v55.color;\n\t// 71 Box v94 @ X0_v8 (System.Object), typeof(_game.CoreSystem.GameColor), &v91 @ stack_-54_v1 (_game.CoreSystem.GameColor)\n\tv129 = System.String::Format(\"ChangeKeyColor({0})\", v94);\n\t_game.CoreSystem.New.Shared.EditMode.EntityActionsBase::ForEachSelected(this, v79, v129);\n\treturn;\nL_002B:\n\tv55 = new _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.KeyEntityActions+<>c__DisplayClass1_0();\n\tSystem.Object::.ctor(v55);\n")]
		public void ChangeColor(GameColor color)
		{
			Action<KeyEntityActions> action = delegate(KeyEntityActions a)
			{
				a.DoChangeColor(color);
			};
			GameColor gameColor = color;
			object arg = gameColor;
			string label = $"ChangeKeyColor({arg})";
			ForEachSelected(action, label);
		}

		[Token(Token = "0x600089C")]
		[Address(RVA = "0x3E827FC", Offset = "0x3E827FC", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv76 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v49, v51);\n\tv80 = ~v76;\n\tif (v80) goto L_0057;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::SetComponent(v49, v51, color);\n\tv77 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v49, v51);\n\tv125 = v77 == 0;\n\tv81 = ~v125;\n\tif (v81) goto L_0057;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(v49, v51, 0);\nL_0057:\n\treturn;\nL_0025:\n\tv53 = _game.CoreSystem.New.Shared.EditMode.EntityActionsBase::TryResolve(this, &v49 @ stack_-38_v2 (_game.BaseLayerSystems.EntitySystem.Core.EntityManager), &v51 @ stack_-40_v2 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv57 = ~v53;\n\tif (v57) goto L_0057;\n")]
		private void DoChangeColor(GameColor color)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("KeyEntityActions::DoChangeColor");
		}

		[Token(Token = "0x600089D")]
		[Address(RVA = "0x3E82914", Offset = "0x3E82914", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.EditMode.SandCubeFamilyEntityActions::.ctor(this);\n\treturn;\n")]
		public KeyEntityActions()
		{
		}
	}
}
