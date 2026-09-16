using Cpp2ILInjected;
using Uniject;
using UnityEngine.Purchasing.Extension;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000048")]
	internal interface INativeStoreProvider
	{
		[Token(Token = "0x600010A")]
		INativeStore GetAndroidStore(IUnityCallback callback, AppStore store, IPurchasingBinder binder, IUtil util);

		[Token(Token = "0x600010B")]
		INativeAppleStore GetStorekit(IUnityCallback callback);

		[Token(Token = "0x600010C")]
		INativeTizenStore GetTizenStore(IUnityCallback callback, IPurchasingBinder binder);

		[Token(Token = "0x600010D")]
		INativeFacebookStore GetFacebookStore();
	}
}
