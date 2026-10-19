using System;
using Systems.ResourceSystem;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.Extensions;
using Unco.ResourceSystem;
using _game.Systems.PaymentSystem.Data;

namespace _game.Systems.PaymentSystem.Core
{
	[Token(Token = "0x200075B")]
	internal class ResourcePaymentExecutor : IPaymentInnerExecutor
	{
		[Token(Token = "0x170002F4")]
		public CostData.CostType CostType
		{
			[Token(Token = "0x6001F00")]
			[Address(RVA = "0x3D8AA00", Offset = "0x3D8AA00", Length = "0x8")]
			get
			{
				return CostData.CostType.Resource;
			}
		}

		[Token(Token = "0x6001F01")]
		[Address(RVA = "0x3D8AA08", Offset = "0x3D8AA08", Length = "0x274")]
		public unsafe void Execute(Instancer instancer, PaymentContext context)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ResourcePaymentExecutor::Execute");
		}

		[Token(Token = "0x6001F02")]
		[Address(RVA = "0x3D8AC7C", Offset = "0x3D8AC7C", Length = "0x108")]
		public bool IsAffordable(Instancer instancer, CostData costData)
		{
			bool flag = instancer.TryResolve<IResourceService>(out var result);
			return result.IsEnough(costData.resourceType, costData.amount);
		}

		[Token(Token = "0x6001F03")]
		[Address(RVA = "0x3D8AD84", Offset = "0x3D8AD84", Length = "0x8")]
		public ResourcePaymentExecutor()
		{
		}
	}
}
