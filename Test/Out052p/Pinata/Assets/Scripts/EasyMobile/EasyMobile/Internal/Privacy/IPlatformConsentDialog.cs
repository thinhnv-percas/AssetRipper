using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace EasyMobile.Internal.Privacy
{
	[Token(Token = "0x20000E2")]
	internal interface IPlatformConsentDialog
	{
		[Token(Token = "0x14000041")]
		event Action<IPlatformConsentDialog, string, bool> ToggleStateUpdated;

		[Token(Token = "0x14000042")]
		event Action<IPlatformConsentDialog, string, Dictionary<string, bool>> Completed;

		[Token(Token = "0x14000043")]
		event Action<IPlatformConsentDialog> Dismissed;

		[Token(Token = "0x600084D")]
		bool IsShowing();

		[Token(Token = "0x600084E")]
		void Show(string title, string content, bool isDismissible);

		[Token(Token = "0x600084F")]
		void SetButtonInteractable(string buttonId, bool interactable);

		[Token(Token = "0x6000850")]
		void SetToggleInteractable(string toggleId, bool interactable);

		[Token(Token = "0x6000851")]
		void SetToggleIsOn(string toggleId, bool isOn, bool animated);
	}
}
