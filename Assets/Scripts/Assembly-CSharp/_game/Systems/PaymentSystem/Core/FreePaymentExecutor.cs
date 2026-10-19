using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using _game.Systems.PaymentSystem.Data;

namespace _game.Systems.PaymentSystem.Core
{
	[Token(Token = "0x2000754")]
	internal class FreePaymentExecutor : IPaymentInnerExecutor
	{
		[Token(Token = "0x170002EF")]
		public CostData.CostType CostType
		{
			[Token(Token = "0x6001EE4")]
			[Address(RVA = "0x3D89D58", Offset = "0x3D89D58", Length = "0x8")]
			get
			{
				return default(CostData.CostType);
			}
		}

		[Token(Token = "0x6001EE5")]
		[Address(RVA = "0x3D89D60", Offset = "0x3D89D60", Length = "0x18")]
		public void Execute(Instancer instancer, PaymentContext context)
		{
			context.CompletePayment();
		}

		[Token(Token = "0x6001EE6")]
		[Address(RVA = "0x3D89D78", Offset = "0x3D89D78", Length = "0x8")]
		public bool IsAffordable(Instancer instancer, CostData costData)
		{
			return true;
		}

		[Token(Token = "0x6001EE7")]
		[Address(RVA = "0x3D89D80", Offset = "0x3D89D80", Length = "0x8")]
		public FreePaymentExecutor()
		{
		}
	}
}
