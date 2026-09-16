using Cpp2ILInjected;

namespace UnityEngine.Purchasing.Extension
{
	[Token(Token = "0x2000020")]
	public abstract class AbstractPurchasingModule : IPurchasingModule
	{
		[Token(Token = "0x400005C")]
		[FieldOffset(Offset = "0x10")]
		protected IPurchasingBinder m_Binder;

		[Token(Token = "0x600009B")]
		[Address(RVA = "0x160DFB0", Offset = "0x160DFB0", Length = "0x8")]
		protected AbstractPurchasingModule()
		{
		}

		[Token(Token = "0x600009C")]
		[Address(RVA = "0x160DFB8", Offset = "0x160DFB8", Length = "0x10")]
		public void Configure(IPurchasingBinder binder)
		{
		}

		[Token(Token = "0x600009D")]
		[Address(RVA = "0x160DFC8", Offset = "0x160DFC8", Length = "0xCC")]
		protected void RegisterStore(string name, IStore a)
		{
		}

		[Token(Token = "0x600009E")]
		[Address(RVA = "0xB86548", Offset = "0xB86548", Length = "0xB4")]
		protected void BindExtension<T>(T instance) where T : IStoreExtension
		{
		}

		[Token(Token = "0x600009F")]
		[Address(RVA = "0xB86494", Offset = "0xB86494", Length = "0xB4")]
		protected void BindConfiguration<T>(T instance) where T : IStoreConfiguration
		{
		}

		[Token(Token = "0x60000A0")]
		public abstract void Configure();
	}
}
