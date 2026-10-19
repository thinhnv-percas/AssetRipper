using System;
using Systems.FlowSystem.Scripts.Core;
using Systems.TutorialSystem.Scripts.UI;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using Unco.Utils;
using UnityEngine;
using _game.CoreGameKit.UiControllers;
using _game.Systems.UncoInput;

namespace _game.CoreGameKit.Flows
{
	[Serializable]
	[Token(Token = "0x20005FE")]
	public class MultipleMaskFlow : LevelBasedFlowStep
	{
		[Inject(false)]
		[Token(Token = "0x40014AC")]
		[FieldOffset(Offset = "0x60")]
		private UiManager _uiManager;

		[SerializeField]
		[Token(Token = "0x40014AD")]
		[FieldOffset(Offset = "0x68")]
		private InputConfig m_inputMode;

		[Token(Token = "0x17000267")]
		public override FlowId FlowId
		{
			[Token(Token = "0x60019A5")]
			[Address(RVA = "0x3D4B8EC", Offset = "0x3D4B8EC", Length = "0x8")]
			get
			{
				return FlowId.ExampleMultipleMaskFlow;
			}
		}

		[Token(Token = "0x60019A6")]
		[Address(RVA = "0x3D4B8F4", Offset = "0x3D4B8F4", Length = "0xBC")]
		protected override void StartTutorial()
		{
			//IL_002f: Expected O, but got I4
			object obj = 0;
			int num = 192761856 + 1336;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			Action onComplete = delegate
			{
				MaskUiController maskUiController = _uiManager.Show<MaskUiController>();
				Action onComplete2 = base.OnTutorialComplete;
				maskUiController.InitializeNewWithRectTransforms(null, m_inputMode, default(HoleType), onComplete2);
			};
			object target = default(object);
			Tween tween = Tween.Delay(target, 0.5f, onComplete);
		}

		[Token(Token = "0x60019A7")]
		[Address(RVA = "0x3D4B9B0", Offset = "0x3D4B9B0", Length = "0x88")]
		public MultipleMaskFlow()
		{
			Pair<int, int> levelRange = new Pair<int, int>(0, 10);
			m_levelRange = levelRange;
			m_persistCompletion = true;
		}
	}
}
