using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Systems.FlowSystem.Scripts.Core;
using Systems.TutorialSystem.Scripts.Data;
using Systems.TutorialSystem.Scripts.UI;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using Unco.Utils;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreGameKit.Ui.UiControllers;
using _game.CoreGameKit.UiControllers;
using _game.CoreGameKit.UiControllers.ScriptableObjects;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts;

namespace _game.CoreGameKit.Flows
{
	[Serializable]
	[Token(Token = "0x2000601")]
	public class TapTutorialWithMaskFlow : LevelBasedFlowStep
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x2000602")]
		private struct _003CStartTutorialWhenGridReady_003Ed__16 : IAsyncStateMachine
		{
			[Token(Token = "0x40014C3")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x40014C4")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public Awaitable.AwaitableAsyncMethodBuilder _003C_003Et__builder;

			[Token(Token = "0x40014C5")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			public TapTutorialWithMaskFlow _003C_003E4__this;

			[Token(Token = "0x40014C6")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			private Awaitable.Awaiter _003C_003Eu__1;

			[Token(Token = "0x60019BB")]
			[Address(RVA = "0x3D4CAA8", Offset = "0x3D4CAA8", Length = "0x5FC")]
			private unsafe void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TapTutorialWithMaskFlow._003CStartTutorialWhenGridReady_003Ed__16::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60019BC")]
			[Address(RVA = "0x3D4D0A4", Offset = "0x3D4D0A4", Length = "0x4")]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[Header("Target Cube")]
		[SerializeField]
		[Token(Token = "0x40014B6")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x5C")]
		private Vector2Int m_targetCubeGridPos;

		[Header("Mask Settings")]
		[SerializeField]
		[Token(Token = "0x40014B7")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x64")]
		private Vector2 m_maskSize;

		[SerializeField]
		[Token(Token = "0x40014B8")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x6C")]
		private HoleType m_holeType;

		[SerializeField]
		[Token(Token = "0x40014B9")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x70")]
		private Color m_maskColor;

		[Header("Tap Tutorial Settings")]
		[SerializeField]
		[Token(Token = "0x40014BA")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x80")]
		private Vector2 m_fingerSize;

		[SerializeField]
		[Token(Token = "0x40014BB")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x88")]
		private Vector3 m_fingerOffset;

		[Inject(false)]
		[Token(Token = "0x40014BC")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x98")]
		private UiManager _uiManager;

		[Inject(false)]
		[Token(Token = "0x40014BD")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xA0")]
		private new EventBus _eventBus;

		[Inject(false)]
		[Token(Token = "0x40014BE")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xA8")]
		private TempTopGridVisualHolder _topGridVisualHolder;

		[Token(Token = "0x40014BF")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xB0")]
		private MaskUiController _maskController;

		[Token(Token = "0x40014C0")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xB8")]
		private TapFingerUiController _tapTutorialController;

		[Token(Token = "0x40014C1")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xC0")]
		private Vector3 _worldPosition;

		[Token(Token = "0x40014C2")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xCC")]
		private bool _aborted;

		[Token(Token = "0x1700026A")]
		public override FlowId FlowId
		{
			[Token(Token = "0x60019B3")]
			[Address(RVA = "0x3D4BFC4", Offset = "0x3D4BFC4", Length = "0x8")]
			get
			{
				return FlowId.ExampleTapTutorialWithMaskFlow;
			}
		}

		[Token(Token = "0x60019B4")]
		[Address(RVA = "0x3D4BFCC", Offset = "0x3D4BFCC", Length = "0xB4")]
		protected unsafe override void StartTutorial()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TapTutorialWithMaskFlow::StartTutorial");
		}

		[AsyncStateMachine(typeof(_003CStartTutorialWhenGridReady_003Ed__16))]
		[Token(Token = "0x60019B5")]
		[Address(RVA = "0x3D4C080", Offset = "0x3D4C080", Length = "0xB0")]
		private unsafe Awaitable StartTutorialWhenGridReady()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TapTutorialWithMaskFlow::StartTutorialWhenGridReady");
			return default;
		}

		[Token(Token = "0x60019B6")]
		[Address(RVA = "0x3D4C130", Offset = "0x3D4C130", Length = "0x4B4")]
		private void ShowMaskAtWorldPosition()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TapTutorialWithMaskFlow::ShowMaskAtWorldPosition");
		}

		[Token(Token = "0x60019B7")]
		[Address(RVA = "0x3D4C5E4", Offset = "0x3D4C5E4", Length = "0x120")]
		private void ShowTapTutorial()
		{
			TapFingerUiController tapTutorialController = _uiManager.Show<TapFingerUiController>();
			_tapTutorialController = tapTutorialController;
			Action onTapComplete = OnTapComplete;
			Vector3 worldPosition = default(Vector3);
			worldPosition.x = _worldPosition.x;
			worldPosition.y = _worldPosition.y;
			worldPosition.z = _worldPosition.z;
			Vector2 fingerSize = default(Vector2);
			fingerSize.x = m_fingerSize.x;
			fingerSize.y = m_fingerSize.y;
			Vector3 offset = default(Vector3);
			offset.x = m_fingerOffset.x;
			offset.y = m_fingerOffset.y;
			offset.z = m_fingerOffset.z;
			_tapTutorialController.StartTapAnimation(worldPosition, fingerSize, offset, onTapComplete);
		}

		[Token(Token = "0x60019B8")]
		[Address(RVA = "0x3D4C704", Offset = "0x3D4C704", Length = "0x138")]
		private void OnTapComplete()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TapTutorialWithMaskFlow::OnTapComplete");
		}

		[Token(Token = "0x60019B9")]
		[Address(RVA = "0x3D4C83C", Offset = "0x3D4C83C", Length = "0x17C")]
		protected internal override void RemoveTutorial()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TapTutorialWithMaskFlow::RemoveTutorial");
		}

		[Token(Token = "0x60019BA")]
		[Address(RVA = "0x3D4C9B8", Offset = "0x3D4C9B8", Length = "0xF0")]
		public TapTutorialWithMaskFlow()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TapTutorialWithMaskFlow::.ctor");
		}
	}
}
