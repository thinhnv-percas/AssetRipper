using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.TextViewSystem;
using UnityEngine;
using _game.Systems.ElephantStorage;

namespace _game.CoreSystem.HealthSystem
{
	[Token(Token = "0x20004CD")]
	public class HealthCountView : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4001016")]
		[FieldOffset(Offset = "0x20")]
		private TextView m_countText;

		[SerializeField]
		[Token(Token = "0x4001017")]
		[FieldOffset(Offset = "0x28")]
		private GameObject m_normalRoot;

		[SerializeField]
		[Token(Token = "0x4001018")]
		[FieldOffset(Offset = "0x30")]
		private GameObject m_infiniteRoot;

		[Token(Token = "0x4001019")]
		[FieldOffset(Offset = "0x38")]
		private HealthController _healthController;

		[Inject(false)]
		[Token(Token = "0x6001447")]
		[Address(RVA = "0x3CF3CCC", Offset = "0x3CF3CCC", Length = "0x1F8")]
		private void Construct(HealthController healthController)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HealthCountView::Construct");
		}

		[Token(Token = "0x6001448")]
		[Address(RVA = "0x3CF3F98", Offset = "0x3CF3F98", Length = "0x1E4")]
		private void OnDestroy()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HealthCountView::OnDestroy");
		}

		[Token(Token = "0x6001449")]
		[Address(RVA = "0x3CF417C", Offset = "0x3CF417C", Length = "0x4")]
		private void OnHealthChanged(int health)
		{
			Refresh();
		}

		[Token(Token = "0x600144A")]
		[Address(RVA = "0x3CF4180", Offset = "0x3CF4180", Length = "0x4")]
		private void OnHealthStateChanged(HealthState state)
		{
			Refresh();
		}

		[Token(Token = "0x600144B")]
		[Address(RVA = "0x3CF3EC4", Offset = "0x3CF3EC4", Length = "0xD4")]
		private void Refresh()
		{
			HealthController healthController = _healthController;
			if (healthController.State == HealthState.Infinite)
			{
				m_normalRoot.SetActive(value: false);
				m_infiniteRoot.SetActive(value: true);
				return;
			}
			m_normalRoot.SetActive(value: true);
			m_infiniteRoot.SetActive(value: false);
			HealthController healthController2 = _healthController;
			HealthStorageData healthData = healthController2._healthData;
			string text = healthData.CurrentHealth.ToString();
			m_countText.SetText(text);
		}

		[Token(Token = "0x600144C")]
		[Address(RVA = "0x3CF4184", Offset = "0x3CF4184", Length = "0x8")]
		public HealthCountView()
		{
		}
	}
}
