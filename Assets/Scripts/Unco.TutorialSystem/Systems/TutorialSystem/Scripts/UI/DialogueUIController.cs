using System;
using Systems.TutorialSystem.Scripts.Data;
using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using Unco.Objects;
using Unco.UncoButtonSystem;
using UnityEngine;
using _game.CoreGameKit.UiControllers;

namespace Systems.TutorialSystem.Scripts.UI
{
	[Token(Token = "0x2000017")]
	public class DialogueUIController : UIController
	{
		[SerializeField]
		[Token(Token = "0x4000053")]
		[FieldOffset(Offset = "0x48")]
		private UncoTMP m_text;

		[SerializeField]
		[Token(Token = "0x4000054")]
		[FieldOffset(Offset = "0x50")]
		private UncoButton m_fillTextButton;

		[SerializeField]
		[Token(Token = "0x4000055")]
		[FieldOffset(Offset = "0x58")]
		private RectTransform m_rectTransform;

		[SerializeField]
		[Token(Token = "0x4000056")]
		[FieldOffset(Offset = "0x60")]
		private GameObject m_tapToContinue;

		[SerializeField]
		[Token(Token = "0x4000057")]
		[FieldOffset(Offset = "0x68")]
		private UncoButton m_nextButton;

		[SerializeField]
		[Token(Token = "0x4000058")]
		[FieldOffset(Offset = "0x70")]
		private CanvasGroup m_canvasGroup;

		[Token(Token = "0x4000059")]
		[FieldOffset(Offset = "0x78")]
		private Tween _tapDelay;

		[Token(Token = "0x400005A")]
		[FieldOffset(Offset = "0x88")]
		private bool _nextAction;

		[Token(Token = "0x600006E")]
		[Address(RVA = "0x81E169C", Offset = "0x81E169C", Length = "0x1E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv59 = rectData.m_AnchorData;\n\t// 50 MakeStruct v83 @ AGG81E1730_1_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v59.m_Min (UnityEngine.Vector2), v59.m_Min.y (System.Single)\n\tUnityEngine.RectTransform::set_anchorMin(this.m_rectTransform, v83);\n\t// 56 MakeStruct v80 @ AGG81E1740_1_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v59.m_Max (UnityEngine.Vector2), v59.m_Max.y (System.Single)\n\tUnityEngine.RectTransform::set_anchorMax(this.m_rectTransform, v80);\n\t// 68 MakeStruct v74 @ AGG81E1764_1_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), rectData.m_Position (UnityEngine.Vector3), rectData.m_Position.y (System.Single)\n\tUnityEngine.RectTransform::set_anchoredPosition(this.m_rectTransform, v74);\n\tv101 = new System.Action();\n\tSystem.Action::.ctor(v101, this, Il2CppMethodInfo);\n\tUnco.Objects.UncoTMP::TypeText(this.m_text, text, v101);\n\tv102 = new System.Action();\n\tSystem.Action::.ctor(v102, this, Il2CppMethodInfo);\n\tUnco.UncoButtonSystem.UncoButton::AddListener(this.m_fillTextButton, v102, 1, 0);\n\tv183 = ~tapToContinue;\n\tif (v183) goto L_0084;\n\tv185 = new System.Action();\n\tSystem.Action::.ctor(v185, this, Il2CppMethodInfo);\n\tv201 = PrimeTween.Tween::Delay(1f, v185, 0, 1);\n\tthis._tapDelay.tween = 0;\n\tthis._tapDelay.id = v201;\nL_0084:\n\tUnityEngine.CanvasGroup::set_blocksRaycasts(this.m_canvasGroup, nextAction);\n\tUnityEngine.CanvasGroup::set_interactable(this.m_canvasGroup, nextAction);\n\treturn;\nL_0025:\n\tthis._nextAction = nextAction;\n")]
		public void Show(RectData rectData, string text, bool tapToContinue = true, bool nextAction = true)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DialogueUIController::Show");
		}

		[Token(Token = "0x600006F")]
		[Address(RVA = "0x81E18C0", Offset = "0x81E18C0", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.Objects.UncoTMP::FinishTypeText(this.m_text);\n\tPrimeTween.Tween::Complete(&this._tapDelay (PrimeTween.Tween));\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void FillText()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DialogueUIController::FillText");
		}

		[Token(Token = "0x6000070")]
		[Address(RVA = "0x81E18F8", Offset = "0x81E18F8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void InitNextButton()
		{
		}

		[Token(Token = "0x6000071")]
		[Address(RVA = "0x81E18FC", Offset = "0x81E18FC", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tPrimeTween.Tween::Stop(&this._tapDelay (PrimeTween.Tween));\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDestroy()
		{
			_tapDelay.Stop();
		}

		[Token(Token = "0x6000072")]
		[Address(RVA = "0x81E1908", Offset = "0x81E1908", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreGameKit.UiControllers.UIController::.ctor(this);\n\treturn;\n")]
		public DialogueUIController()
		{
		}
	}
}
