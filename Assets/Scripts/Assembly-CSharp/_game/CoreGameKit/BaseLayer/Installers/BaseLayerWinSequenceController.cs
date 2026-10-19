using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.ContainerSystem.Runtime;
using UnityEngine;

namespace _game.CoreGameKit.BaseLayer.Installers
{
	[Serializable]
	[Token(Token = "0x20006A5")]
	public class BaseLayerWinSequenceController : IDisposable
	{
		[SerializeReference]
		[Token(Token = "0x4001696")]
		[FieldOffset(Offset = "0x10")]
		private IBaseLayerUiActionElement[] m_winSequenceElements;

		[Token(Token = "0x4001697")]
		[FieldOffset(Offset = "0x18")]
		internal int _currentIndex;

		[Token(Token = "0x4001698")]
		[FieldOffset(Offset = "0x20")]
		internal Action _onComplete;

		[Token(Token = "0x170002D5")]
		public IBaseLayerUiActionElement[] WinSequenceElements
		{
			[Token(Token = "0x6001C1E")]
			[Address(RVA = "0x3D685FC", Offset = "0x3D685FC", Length = "0x8")]
			get
			{
				return m_winSequenceElements;
			}
		}

		[Inject(false)]
		[Token(Token = "0x6001C1F")]
		[Address(RVA = "0x3D68604", Offset = "0x3D68604", Length = "0xA8")]
		public void Inject(Instancer instancer)
		{
			IBaseLayerUiActionElement[] winSequenceElements = WinSequenceElements;
			if (instancer != null)
			{
				if (winSequenceElements.Length >= 1)
				{
					int num = 0;
					do
					{
						IBaseLayerUiActionElement baseLayerUiActionElement = instancer.InjectInstance(winSequenceElements[num]);
						num++;
					}
					while (num < winSequenceElements.Length);
				}
			}
			else if (winSequenceElements.Length > 0)
			{
				throw new NullReferenceException();
			}
		}

		[Token(Token = "0x6001C20")]
		[Address(RVA = "0x3D5718C", Offset = "0x3D5718C", Length = "0x30")]
		public void Play(Action onComplete)
		{
			_currentIndex = -1;
			_onComplete = onComplete;
			TryPlayNext();
		}

		[Token(Token = "0x6001C21")]
		[Address(RVA = "0x3D686AC", Offset = "0x3D686AC", Length = "0x158")]
		internal void TryPlayNext()
		{
			int num = ++_currentIndex;
			IBaseLayerUiActionElement[] winSequenceElements = WinSequenceElements;
			if (num < winSequenceElements.Length)
			{
				Action onComplete = TryPlayNext;
				winSequenceElements[num].Play(onComplete);
			}
			else if (_onComplete != null)
			{
				_onComplete();
			}
		}

		[Token(Token = "0x6001C22")]
		[Address(RVA = "0x3D68804", Offset = "0x3D68804", Length = "0x4")]
		public void Dispose()
		{
		}

		[Token(Token = "0x6001C23")]
		[Address(RVA = "0x3D68808", Offset = "0x3D68808", Length = "0x8")]
		public BaseLayerWinSequenceController()
		{
		}
	}
}
