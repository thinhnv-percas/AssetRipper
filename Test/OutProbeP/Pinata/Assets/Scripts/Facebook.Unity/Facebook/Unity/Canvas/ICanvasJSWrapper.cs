using System.Collections.Generic;
using Cpp2ILInjected;

namespace Facebook.Unity.Canvas
{
	[Token(Token = "0x2000076")]
	internal interface ICanvasJSWrapper
	{
		[Token(Token = "0x60002DD")]
		string GetSDKVersion();

		[Token(Token = "0x60002DE")]
		void DisableFullScreen();

		[Token(Token = "0x60002DF")]
		void Init(string connectFacebookUrl, string locale, int debug, string initParams, int status);

		[Token(Token = "0x60002E0")]
		void Login(IEnumerable<string> scope, string callback_id);

		[Token(Token = "0x60002E1")]
		void Logout();

		[Token(Token = "0x60002E2")]
		void ActivateApp();

		[Token(Token = "0x60002E3")]
		void LogAppEvent(string eventName, float? valueToSum, string parameters);

		[Token(Token = "0x60002E4")]
		void LogPurchase(float purchaseAmount, string currency, string parameters);

		[Token(Token = "0x60002E5")]
		void Ui(string x, string uid, string callbackMethodName);

		[Token(Token = "0x60002E6")]
		void InitScreenPosition();
	}
}
