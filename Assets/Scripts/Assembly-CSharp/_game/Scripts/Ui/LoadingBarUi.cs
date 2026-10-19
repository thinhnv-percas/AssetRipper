using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.GameBootstrap.Core;
using UnityEngine;
using UnityEngine.UI;

namespace _game.Scripts.Ui
{
	[Token(Token = "0x2000703")]
	public class LoadingBarUi : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x400177F")]
		[FieldOffset(Offset = "0x20")]
		private Image m_fill;

		[Token(Token = "0x4001780")]
		[FieldOffset(Offset = "0x28")]
		private ILoadTask _loadTask;

		[Inject(true)]
		[Token(Token = "0x6001D8F")]
		[Address(RVA = "0x3D7A760", Offset = "0x3D7A760", Length = "0x2F4")]
		private void Inject(ILoadTask loadTask)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LoadingBarUi::Inject");
		}

		[Token(Token = "0x6001D90")]
		[Address(RVA = "0x3D7AB20", Offset = "0x3D7AB20", Length = "0x1CC")]
		private void OnDisable()
		{
			if (_loadTask != null)
			{
				Action<float> value = OnProgressChanged;
				_loadTask.OnProgressChanged -= value;
				Action value2 = OnComplete;
				_loadTask.OnComplete -= value2;
			}
		}

		[Token(Token = "0x6001D91")]
		[Address(RVA = "0x3D7ACEC", Offset = "0x3D7ACEC", Length = "0xCC")]
		private void OnProgressChanged(float progress)
		{
			if (m_fill != null)
			{
				m_fill.fillAmount = progress;
			}
		}

		[Token(Token = "0x6001D92")]
		[Address(RVA = "0x3D7ADB8", Offset = "0x3D7ADB8", Length = "0xBC")]
		private void OnComplete()
		{
			if (m_fill != null)
			{
				m_fill.fillAmount = 1f;
			}
		}

		[Token(Token = "0x6001D93")]
		[Address(RVA = "0x3D7AA54", Offset = "0x3D7AA54", Length = "0xCC")]
		public void SetDirectFill(float progress)
		{
			if (m_fill != null)
			{
				m_fill.fillAmount = progress;
			}
		}

		[Token(Token = "0x6001D94")]
		[Address(RVA = "0x3D7AE74", Offset = "0x3D7AE74", Length = "0x8")]
		public LoadingBarUi()
		{
		}
	}
}
