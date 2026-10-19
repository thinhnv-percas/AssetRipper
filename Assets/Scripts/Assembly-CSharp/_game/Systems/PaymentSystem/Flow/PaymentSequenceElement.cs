using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.RewardSystem;
using Unco.RewardSystem.SimpleSequenceSystem;
using _game.Systems.PaymentSystem.Core;
using _game.Systems.PaymentSystem.Data;

namespace _game.Systems.PaymentSystem.Flow
{
	[Token(Token = "0x200074D")]
	public class PaymentSequenceElement : ISequenceElement
	{
		[Token(Token = "0x4001869")]
		[FieldOffset(Offset = "0x10")]
		private readonly Instancer _instancer;

		[Token(Token = "0x400186A")]
		[FieldOffset(Offset = "0x18")]
		private readonly PaymentExecutor _executor;

		[Token(Token = "0x400186B")]
		[FieldOffset(Offset = "0x20")]
		private readonly ShopItemData _itemData;

		[Token(Token = "0x400186C")]
		[FieldOffset(Offset = "0x28")]
		private readonly CostData _costData;

		[Token(Token = "0x400186D")]
		[FieldOffset(Offset = "0x30")]
		private readonly Action _onFailed;

		[CompilerGenerated]
		[Token(Token = "0x400186E")]
		[FieldOffset(Offset = "0x38")]
		private Action _003COnComplete_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400186F")]
		[FieldOffset(Offset = "0x40")]
		private Action _003COnStart_003Ek__BackingField;

		[Token(Token = "0x14000027")]
		public event Action OnComplete
		{
			[CompilerGenerated]
			[Token(Token = "0x6001EB9")]
			[Address(RVA = "0x3D8870C", Offset = "0x3D8870C", Length = "0xA4")]
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
			[Token(Token = "0x6001EBA")]
			[Address(RVA = "0x3D887B0", Offset = "0x3D887B0", Length = "0xA4")]
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

		[Token(Token = "0x14000028")]
		public event Action OnStart
		{
			[CompilerGenerated]
			[Token(Token = "0x6001EBB")]
			[Address(RVA = "0x3D88854", Offset = "0x3D88854", Length = "0xA4")]
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
			[Token(Token = "0x6001EBC")]
			[Address(RVA = "0x3D888F8", Offset = "0x3D888F8", Length = "0xA4")]
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

		[Token(Token = "0x6001EBD")]
		[Address(RVA = "0x3D87BBC", Offset = "0x3D87BBC", Length = "0x94")]
		public PaymentSequenceElement(Instancer instancer, PaymentExecutor executor, ShopItemData itemData, CostData costData, Action onFailed = null)
		{
			_instancer = instancer;
			_executor = executor;
			_itemData = itemData;
			_costData = costData;
			_onFailed = onFailed;
		}

		[Token(Token = "0x6001EBE")]
		[Address(RVA = "0x3D8899C", Offset = "0x3D8899C", Length = "0x10C")]
		public void Start()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PaymentSequenceElement::Start");
		}
	}
}
