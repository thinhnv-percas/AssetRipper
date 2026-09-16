using System;
using Cpp2ILInjected;

namespace EasyMobile.Internal.NativeAPIs.Contacts
{
	[Token(Token = "0x20000FB")]
	internal interface INativeContactsProvider
	{
		[Token(Token = "0x1700024C")]
		bool IsFetchingContacts
		{
			[Token(Token = "0x60008DA")]
			get;
		}

		[Token(Token = "0x60008DB")]
		void GetContacts(Action<string, Contact[]> callback);

		[Token(Token = "0x60008DC")]
		string AddContact(Contact contact);

		[Token(Token = "0x60008DD")]
		string DeleteContact(string id);

		[Token(Token = "0x60008DE")]
		void PickContact(Action<string, Contact> callback);
	}
}
