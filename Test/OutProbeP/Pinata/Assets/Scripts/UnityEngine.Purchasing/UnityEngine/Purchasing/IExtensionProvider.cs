using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000005")]
	public interface IExtensionProvider
	{
		[Token(Token = "0x6000012")]
		T GetExtension<T>() where T : IStoreExtension;
	}
}
