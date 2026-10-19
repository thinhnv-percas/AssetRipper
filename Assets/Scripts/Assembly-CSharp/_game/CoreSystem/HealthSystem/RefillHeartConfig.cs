using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unco.RewardSystem;
using UnityEngine;
using _game.Systems.PaymentSystem.Data;

namespace _game.CoreSystem.HealthSystem
{
	[Serializable]
	[Token(Token = "0x20004D8")]
	public class RefillHeartConfig
	{
		[Serializable]
		[Token(Token = "0x20004D9")]
		public struct PurchaseOption
		{
			[SerializeField]
			[Token(Token = "0x4001039")]
			[FieldOffset(Offset = "0x0")]
			private CostData.CostType m_costType;

			[SerializeField]
			[Token(Token = "0x400103A")]
			[FieldOffset(Offset = "0x4")]
			internal int m_costAmount;

			[SerializeField]
			[Token(Token = "0x400103B")]
			[FieldOffset(Offset = "0x8")]
			internal LootDrop m_reward;

			[Token(Token = "0x170001C2")]
			public CostData.CostType CostType
			{
				[Token(Token = "0x6001469")]
				[Address(RVA = "0x3CF5350", Offset = "0x3CF5350", Length = "0x8")]
				get
				{
					return m_costType;
				}
			}

			[Token(Token = "0x170001C3")]
			public LootDrop LootData
			{
				[Token(Token = "0x600146A")]
				[Address(RVA = "0x3CF5358", Offset = "0x3CF5358", Length = "0x14")]
				get
				{
					global::AssetRipperInjected.RecoveryStub.Missing("RefillHeartConfig.PurchaseOption::get_LootData");
					return default;
				}
			}

			[Token(Token = "0x170001C4")]
			public int CostAmount
			{
				[Token(Token = "0x600146B")]
				[Address(RVA = "0x3CF536C", Offset = "0x3CF536C", Length = "0x8")]
				get
				{
					return m_costAmount;
				}
			}
		}

		[SerializeField]
		[Token(Token = "0x4001038")]
		[FieldOffset(Offset = "0x10")]
		internal PurchaseOption[] m_purchaseOptions;

		[Token(Token = "0x170001C1")]
		public IEnumerable<PurchaseOption> PurchaseOptions
		{
			[Token(Token = "0x6001467")]
			[Address(RVA = "0x3CF5340", Offset = "0x3CF5340", Length = "0x8")]
			get
			{
				return m_purchaseOptions;
			}
		}

		[Token(Token = "0x6001468")]
		[Address(RVA = "0x3CF5348", Offset = "0x3CF5348", Length = "0x8")]
		public RefillHeartConfig()
		{
		}
	}
}
