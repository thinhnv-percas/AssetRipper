using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.RewardSystem;
using Unco.RewardSystem.SimpleSequenceSystem;
using _game.Systems.PaymentSystem.Core;
using _game.Systems.PaymentSystem.Data;

namespace _game.Systems.ShopSystem.Scripts.Core.Flow
{
	[Token(Token = "0x200073A")]
	public class PaymentSequenceElement : ISequenceElement
	{
		[Token(Token = "0x4001829")]
		[FieldOffset(Offset = "0x10")]
		private readonly PaymentExecutor _executor;

		[Token(Token = "0x400182A")]
		[FieldOffset(Offset = "0x18")]
		private readonly ShopItemData _itemData;

		[Token(Token = "0x400182B")]
		[FieldOffset(Offset = "0x20")]
		private readonly CostData _costData;

		[Token(Token = "0x400182C")]
		[FieldOffset(Offset = "0x28")]
		private readonly Action _onFailed;

		[Token(Token = "0x400182D")]
		[FieldOffset(Offset = "0x30")]
		private Instancer _instancer;

		[CompilerGenerated]
		[Token(Token = "0x400182E")]
		[FieldOffset(Offset = "0x38")]
		private Action _003COnComplete_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400182F")]
		[FieldOffset(Offset = "0x40")]
		private Action _003COnStart_003Ek__BackingField;

		[Token(Token = "0x14000025")]
		public event Action OnComplete
		{
			[CompilerGenerated]
			[Token(Token = "0x6001E6E")]
			[Address(RVA = "0x3D84DF4", Offset = "0x3D84DF4", Length = "0xA4")]
			add
			{
				Action action = _003COnComplete_003Ek__BackingField;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, value);
					action = Interlocked.CompareExchange(ref _003COnComplete_003Ek__BackingField, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			[Token(Token = "0x6001E6F")]
			[Address(RVA = "0x3D84E98", Offset = "0x3D84E98", Length = "0xA4")]
			remove
			{
				Action action = _003COnComplete_003Ek__BackingField;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange(ref _003COnComplete_003Ek__BackingField, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		[Token(Token = "0x14000026")]
		public event Action OnStart
		{
			[CompilerGenerated]
			[Token(Token = "0x6001E70")]
			[Address(RVA = "0x3D84F3C", Offset = "0x3D84F3C", Length = "0xA4")]
			add
			{
				Action action = _003COnStart_003Ek__BackingField;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, value);
					action = Interlocked.CompareExchange(ref _003COnStart_003Ek__BackingField, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			[Token(Token = "0x6001E71")]
			[Address(RVA = "0x3D84FE0", Offset = "0x3D84FE0", Length = "0xA4")]
			remove
			{
				Action action = _003COnStart_003Ek__BackingField;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange(ref _003COnStart_003Ek__BackingField, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		[Token(Token = "0x6001E72")]
		[Address(RVA = "0x3D8405C", Offset = "0x3D8405C", Length = "0x94")]
		public PaymentSequenceElement(Instancer instancer, PaymentExecutor executor, ShopItemData itemData, CostData costData, Action onFailed = null)
		{
			_instancer = instancer;
			_executor = executor;
			_itemData = itemData;
			_costData = costData;
			_onFailed = onFailed;
		}

		[Token(Token = "0x6001E73")]
		[Address(RVA = "0x3D85084", Offset = "0x3D85084", Length = "0x110")]
		public void Start()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PaymentSequenceElement::Start");
		}
	}
}
