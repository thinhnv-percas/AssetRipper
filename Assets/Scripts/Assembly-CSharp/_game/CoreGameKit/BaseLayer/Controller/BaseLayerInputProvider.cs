using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Installers;
using _game.CoreGameKit.BaseLayer.Installers.Unco.ContainerSystem.Runtime;

namespace _game.CoreGameKit.BaseLayer.Controller
{
	[Token(Token = "0x20006BE")]
	public class BaseLayerInputProvider : IInputProvider, IRequireUpdateCall, IDisposable
	{
		[Token(Token = "0x40016C8")]
		[FieldOffset(Offset = "0x10")]
		private readonly IRawInputProvider _rawProvider;

		[Token(Token = "0x40016C9")]
		[FieldOffset(Offset = "0x18")]
		private int _lastFramePointCount;

		[Token(Token = "0x40016CA")]
		[FieldOffset(Offset = "0x1C")]
		private float2 _previousFramePosition;

		[Token(Token = "0x40016CB")]
		[FieldOffset(Offset = "0x24")]
		private float _previousFrameDistance;

		[Token(Token = "0x40016CC")]
		[FieldOffset(Offset = "0x28")]
		private InputState _orbitState;

		[Token(Token = "0x40016CD")]
		[FieldOffset(Offset = "0x2B")]
		private InputState _zoomPanState;

		[Token(Token = "0x40016CE")]
		[FieldOffset(Offset = "0x2E")]
		private bool _isEnabled;

		[Token(Token = "0x40016CF")]
		[FieldOffset(Offset = "0x30")]
		private InputData _currentInputState;

		[Token(Token = "0x6001C88")]
		[Address(RVA = "0x3D6F478", Offset = "0x3D6F478", Length = "0x3C")]
		public BaseLayerInputProvider(IRawInputProvider rawProvider)
		{
			_isEnabled = true;
			_rawProvider = rawProvider;
		}

		[Token(Token = "0x6001C89")]
		[Address(RVA = "0x3D6F4B4", Offset = "0x3D6F4B4", Length = "0xD0")]
		public void Dispose()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerInputProvider::Dispose");
		}

		[Token(Token = "0x6001C8A")]
		[Address(RVA = "0x3D6F584", Offset = "0x3D6F584", Length = "0x40")]
		public void SetEnabled(bool b)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerInputProvider::SetEnabled");
		}

		[Token(Token = "0x6001C8B")]
		[Address(RVA = "0x3D6F97C", Offset = "0x3D6F97C", Length = "0x3C")]
		public void Update()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerInputProvider::Update");
		}

		[Token(Token = "0x6001C8C")]
		[Address(RVA = "0x3D6F9B8", Offset = "0x3D6F9B8", Length = "0x14")]
		public InputData GetInputState()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerInputProvider::GetInputState");
			return default;
		}

		[Token(Token = "0x6001C8D")]
		[Address(RVA = "0x3D6F5C4", Offset = "0x3D6F5C4", Length = "0x3B8")]
		private unsafe InputData CreateInputState()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerInputProvider::CreateInputState");
			return default;
		}

		[Token(Token = "0x6001C8E")]
		[Address(RVA = "0x3D6F9CC", Offset = "0x3D6F9CC", Length = "0x10")]
		private void ResetInputStates()
		{
			_orbitState.IsDown = false;
			_orbitState.IsUp = false;
			_zoomPanState.IsUp = false;
		}

		[Token(Token = "0x6001C8F")]
		[Address(RVA = "0x3D700F8", Offset = "0x3D700F8", Length = "0xC")]
		private void ResetInputState(ref InputState state)
		{
			state.IsDown = false;
			state.IsUp = false;
		}

		[Token(Token = "0x6001C90")]
		[Address(RVA = "0x3D70104", Offset = "0x3D70104", Length = "0x14")]
		private void SetPressed(ref InputState state)
		{
			if (!state.IsPressed)
			{
				state.IsDown = true;
				state.IsPressed = true;
			}
		}

		[Token(Token = "0x6001C91")]
		[Address(RVA = "0x3D70118", Offset = "0x3D70118", Length = "0x18")]
		private void SetReleased(ref InputState state)
		{
			if (state.IsPressed)
			{
				state.IsPressed = false;
				state.IsUp = true;
			}
		}

		[Token(Token = "0x6001C92")]
		[Address(RVA = "0x3D6FA0C", Offset = "0x3D6FA0C", Length = "0xC8")]
		private void OnOrbitInputBegin(IReadOnlyList<ScreenPointInput> points)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerInputProvider::OnOrbitInputBegin");
		}

		[Token(Token = "0x6001C93")]
		[Address(RVA = "0x3D6FAD4", Offset = "0x3D6FAD4", Length = "0x26C")]
		private void OnZoomPanInputBegin(IReadOnlyList<ScreenPointInput> points)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerInputProvider::OnZoomPanInputBegin");
		}

		[Token(Token = "0x6001C94")]
		[Address(RVA = "0x3D6F9DC", Offset = "0x3D6F9DC", Length = "0x18")]
		private void OnOrbitInputEnded()
		{
			if (_orbitState.IsPressed)
			{
				_orbitState.IsPressed = false;
			}
		}

		[Token(Token = "0x6001C95")]
		[Address(RVA = "0x3D6F9F4", Offset = "0x3D6F9F4", Length = "0x18")]
		private void OnZoomPanInputEnded()
		{
			if (_zoomPanState.IsPressed)
			{
				_zoomPanState.IsPressed = false;
			}
		}

		[Token(Token = "0x6001C96")]
		[Address(RVA = "0x3D6FD40", Offset = "0x3D6FD40", Length = "0xF8")]
		private unsafe InputData HandleOrbitInput(IReadOnlyList<ScreenPointInput> points)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerInputProvider::HandleOrbitInput");
			return default;
		}

		[Token(Token = "0x6001C97")]
		[Address(RVA = "0x3D6FE38", Offset = "0x3D6FE38", Length = "0x2C0")]
		private unsafe InputData HandleZoomPanInput(IReadOnlyList<ScreenPointInput> points)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerInputProvider::HandleZoomPanInput");
			return default;
		}
	}
}
