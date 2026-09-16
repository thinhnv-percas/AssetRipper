using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine.Purchasing;

namespace Mycom.Tracker.Unity.Internal.Interfaces
{
	[Token(Token = "0x200000A")]
	internal interface ITracker : IDisposable
	{
		[Token(Token = "0x17000020")]
		MyTrackerParams MyTrackerParams
		{
			[Token(Token = "0x600004D")]
			get;
		}

		[Token(Token = "0x600004E")]
		void Create(string id);

		[Token(Token = "0x600004F")]
		void Init();

		[Token(Token = "0x6000050")]
		bool IsDebugMode();

		[Token(Token = "0x6000051")]
		bool IsEnabled();

		[Token(Token = "0x6000052")]
		void SetAttributionListener(Action<MyTrackerAttribution> listener);

		[Token(Token = "0x6000053")]
		void SetDebugMode(bool value);

		[Token(Token = "0x6000054")]
		void SetEnabled(bool value);

		[Token(Token = "0x6000055")]
		bool TrackEvent(string name, IDictionary<string, string> eventParams = null);

		[Token(Token = "0x6000056")]
		bool TrackInviteEvent(IDictionary<string, string> eventParams = null);

		[Token(Token = "0x6000057")]
		bool TrackLevelEvent(int? level = null, IDictionary<string, string> eventParams = null);

		[Token(Token = "0x6000058")]
		bool TrackLoginEvent(IDictionary<string, string> eventParams = null);

		[Token(Token = "0x6000059")]
		bool TrackRegistrationEvent(IDictionary<string, string> eventParams = null);

		[Token(Token = "0x600005A")]
		bool Flush();

		[Token(Token = "0x600005B")]
		bool TrackPurchaseEvent(string skuDetails, string purchaseData, string dataSignature, IDictionary<string, string> eventParams = null);

		[Token(Token = "0x600005C")]
		bool TrackPurchaseEvent(Product product, IDictionary<string, string> eventParams = null);
	}
}
