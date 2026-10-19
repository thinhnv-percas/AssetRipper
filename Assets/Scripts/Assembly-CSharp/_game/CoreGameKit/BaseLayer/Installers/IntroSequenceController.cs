using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States;

namespace _game.CoreGameKit.BaseLayer.Installers
{
	[Serializable]
	[Token(Token = "0x200068E")]
	public class IntroSequenceController : IDisposable
	{
		[Token(Token = "0x400166B")]
		[FieldOffset(Offset = "0x10")]
		private BaseLayerStateMachine _stateMachine;

		[Token(Token = "0x400166C")]
		[FieldOffset(Offset = "0x18")]
		private BaseLayerState _readyState;

		[Token(Token = "0x400166D")]
		[FieldOffset(Offset = "0x20")]
		private IBaseLayerIntroElement[] _introElements;

		[Token(Token = "0x400166E")]
		[FieldOffset(Offset = "0x28")]
		private int _currentIndex;

		[Inject(false)]
		[Token(Token = "0x6001BCF")]
		[Address(RVA = "0x3D6547C", Offset = "0x3D6547C", Length = "0xD0")]
		public void Initialize(BaseLayerStateMachine stateMachine, BaseLayerIntroState introState, BaseLayerReadyState readyState, IEnumerable<IBaseLayerIntroElement> introElements)
		{
			object[] introElements2 = ((IEnumerable<object>)introElements).ToArray();
			_introElements = (IBaseLayerIntroElement[])introElements2;
			_stateMachine = stateMachine;
			_readyState = readyState;
			_stateMachine.SetState(introState);
			_currentIndex = -1;
			TryPlayNext();
		}

		[Token(Token = "0x6001BD0")]
		[Address(RVA = "0x3D65690", Offset = "0x3D65690", Length = "0xE4")]
		public void Dispose()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("IntroSequenceController::Dispose");
		}

		[Token(Token = "0x6001BD1")]
		[Address(RVA = "0x3D6554C", Offset = "0x3D6554C", Length = "0x144")]
		private void TryPlayNext()
		{
			int num = ++_currentIndex;
			IBaseLayerIntroElement[] introElements = _introElements;
			if (num < introElements.Length)
			{
				Action onComplete = TryPlayNext;
				introElements[num].Play(onComplete);
			}
			else
			{
				_stateMachine.SetState(_readyState);
			}
		}

		[Token(Token = "0x6001BD2")]
		[Address(RVA = "0x3D65384", Offset = "0x3D65384", Length = "0x8")]
		public IntroSequenceController()
		{
		}
	}
}
