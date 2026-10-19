using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Systems.TutorialSystem.Scripts.Data;
using Systems.TutorialSystem.Scripts.UI;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using UnityEngine;
using UnityEngine.UI;
using _game.CoreGameKit.BaseLayer.Boosters;
using _game.CoreGameKit.BaseLayer.Services;
using _game.CoreGameKit.Ui.UiControllers;
using _game.CoreGameKit.UiControllers;
using _game.CoreSystem.Events;
using _game.Systems.UncoInput;

namespace _game.CoreGameKit.Flows
{
	[Serializable]
	[Token(Token = "0x20005F9")]
	public abstract class BoosterTutorialFlowBase : LevelBasedFlowStep
	{
		[CompilerGenerated]
		[Token(Token = "0x20005FA")]
		private sealed class _003C_003Ec__DisplayClass14_0
		{
			[Token(Token = "0x4001498")]
			[FieldOffset(Offset = "0x10")]
			public BoosterTutorialFlowBase _003C_003E4__this;

			[Token(Token = "0x4001499")]
			[FieldOffset(Offset = "0x18")]
			public Action onHoleClicked;

			[Token(Token = "0x400149A")]
			[FieldOffset(Offset = "0x20")]
			public Action _003C_003E9__0;

			[Token(Token = "0x600198F")]
			[Address(RVA = "0x3D4A0D4", Offset = "0x3D4A0D4", Length = "0x8")]
			public _003C_003Ec__DisplayClass14_0()
			{
			}

			internal void _003COverrideHoleCallbacks_003Eb__0()
			{
				_003C_003E4__this.HideOverlay();
				if (onHoleClicked != null)
				{
					onHoleClicked();
				}
			}
		}

		[Header("Mask Settings")]
		[SerializeField]
		[Token(Token = "0x400148C")]
		[FieldOffset(Offset = "0x5C")]
		protected internal Color m_maskColor;

		[SerializeField]
		[Token(Token = "0x400148D")]
		[FieldOffset(Offset = "0x6C")]
		protected internal HoleType m_holeType;

		[SerializeField]
		[Token(Token = "0x400148E")]
		[FieldOffset(Offset = "0x70")]
		protected InputConfig m_inputConfig;

		[Header("Finger Settings")]
		[SerializeField]
		[Token(Token = "0x400148F")]
		[FieldOffset(Offset = "0x78")]
		protected internal Vector2 m_fingerSize;

		[SerializeField]
		[Token(Token = "0x4001490")]
		[FieldOffset(Offset = "0x80")]
		protected Vector3 m_fingerOffset;

		[Inject(false)]
		[Token(Token = "0x4001491")]
		[FieldOffset(Offset = "0x90")]
		protected internal UiManager _uiManager;

		[Inject(false)]
		[Token(Token = "0x4001492")]
		[FieldOffset(Offset = "0x98")]
		protected internal InputBlockService _inputBlockService;

		[Inject(false)]
		[Token(Token = "0x4001493")]
		[FieldOffset(Offset = "0xA0")]
		protected internal BaseLayerBoosterController _boosterController;

		[Token(Token = "0x4001494")]
		[FieldOffset(Offset = "0xA8")]
		protected internal MaskUiController _maskController;

		[Token(Token = "0x4001495")]
		[FieldOffset(Offset = "0xB0")]
		protected TapFingerUiController _fingerController;

		[Token(Token = "0x4001496")]
		[FieldOffset(Offset = "0xB8")]
		protected internal IDisposable _inputBlock;

		[Token(Token = "0x4001497")]
		[FieldOffset(Offset = "0xC0")]
		protected internal Tween _delayTween;

		[Token(Token = "0x6001984")]
		[Address(RVA = "0x3D4932C", Offset = "0x3D4932C", Length = "0x9DC")]
		protected internal void ShowMaskOnWorldPos(Vector3 worldPos, Vector2 holeSize, Action onHoleClicked)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BoosterTutorialFlowBase::ShowMaskOnWorldPos");
		}

		[Token(Token = "0x6001985")]
		[Address(RVA = "0x3D49F70", Offset = "0x3D49F70", Length = "0x164")]
		protected internal void ShowMaskOnRectTransform(RectTransform target, Action onHoleClicked)
		{
			MaskUiController maskController = _uiManager.Show<MaskUiController>();
			_maskController = maskController;
			List<RectTransform> list = new List<RectTransform>();
			list.Add(target);
			_maskController.InitializeNewWithRectTransforms(list, m_inputConfig, m_holeType, null);
			OverrideHoleCallbacks(onHoleClicked);
		}

		[Token(Token = "0x6001986")]
		[Address(RVA = "0x3D49D08", Offset = "0x3D49D08", Length = "0x268")]
		private unsafe void OverrideHoleCallbacks(Action onHoleClicked)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BoosterTutorialFlowBase::OverrideHoleCallbacks");
		}

		[Token(Token = "0x6001987")]
		[Address(RVA = "0x3D4A0DC", Offset = "0x3D4A0DC", Length = "0xB0")]
		protected internal void ShowFingerAtWorldPos(Vector3 worldPos)
		{
			TapFingerUiController fingerController = _uiManager.Show<TapFingerUiController>();
			_fingerController = fingerController;
			Vector2 fingerSize = default(Vector2);
			fingerSize.x = m_fingerSize.x;
			fingerSize.y = m_fingerSize.y;
			Vector3 offset = default(Vector3);
			offset.x = m_fingerOffset.x;
			offset.y = m_fingerOffset.y;
			offset.z = m_fingerOffset.z;
			_fingerController.StartTapAnimation(worldPos, fingerSize, offset, null);
		}

		[Token(Token = "0x6001988")]
		[Address(RVA = "0x3D4A18C", Offset = "0x3D4A18C", Length = "0x98")]
		protected internal void ShowFingerOnRectTransform(RectTransform target)
		{
			TapFingerUiController fingerController = _uiManager.Show<TapFingerUiController>();
			_fingerController = fingerController;
			Vector2 fingerSize = default(Vector2);
			fingerSize.x = m_fingerSize.x;
			fingerSize.y = m_fingerSize.y;
			Vector3 offset = default(Vector3);
			offset.x = m_fingerOffset.x;
			offset.y = m_fingerOffset.y;
			offset.z = m_fingerOffset.z;
			_fingerController.StartTapAnimationOnRectTransform(target, fingerSize, offset, null);
		}

		[Token(Token = "0x6001989")]
		[Address(RVA = "0x3D4A224", Offset = "0x3D4A224", Length = "0x17C")]
		protected internal void HideOverlay()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BoosterTutorialFlowBase::HideOverlay");
		}

		[Token(Token = "0x600198A")]
		[Address(RVA = "0x3D4A3A0", Offset = "0x3D4A3A0", Length = "0x68")]
		protected internal IDisposable RequestInputBlock(InputChannel channels)
		{
			return _inputBlockService.RequestBlock("BoosterTutorial", channels);
		}

		[Token(Token = "0x600198B")]
		[Address(RVA = "0x3D4A408", Offset = "0x3D4A408", Length = "0xB0")]
		protected internal void DisposeInputBlock()
		{
			if (_inputBlock != null)
			{
				_inputBlock.Dispose();
			}
			_inputBlock = null;
		}

		[Token(Token = "0x600198C")]
		[Address(RVA = "0x3D4A4B8", Offset = "0x3D4A4B8", Length = "0xB0")]
		protected internal void SuppressFail(bool suppress)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BoosterTutorialFlowBase::SuppressFail");
		}

		[Token(Token = "0x600198D")]
		[Address(RVA = "0x3D4A568", Offset = "0x3D4A568", Length = "0x11C")]
		protected internal override void RemoveTutorial()
		{
			if (!_delayTween.isAlive)
			{
				HideOverlay();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DCF2]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					goto IL_006d;
				}
			}
			else
			{
				_delayTween.Stop();
				HideOverlay();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DCF2]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					goto IL_006d;
				}
			}
			_ = 1;
			IDisposable inputBlock = _inputBlock;
			if (_inputBlock == null)
			{
				goto IL_0128;
			}
			goto IL_0145;
			IL_0128:
			_inputBlock = null;
			SuppressFail(suppress: false);
			base.RemoveTutorial();
			return;
			IL_0145:
			inputBlock.Dispose();
			goto IL_0128;
			IL_006d:
			inputBlock = _inputBlock;
			if (_inputBlock == null)
			{
				goto IL_0128;
			}
			goto IL_0145;
		}

		[Token(Token = "0x600198E")]
		[Address(RVA = "0x3D4A684", Offset = "0x3D4A684", Length = "0x8C")]
		protected internal BoosterTutorialFlowBase()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BoosterTutorialFlowBase::.ctor");
		}
	}
}
