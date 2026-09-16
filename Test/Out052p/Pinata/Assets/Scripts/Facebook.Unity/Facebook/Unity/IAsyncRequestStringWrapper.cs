using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace Facebook.Unity
{
	[Token(Token = "0x2000041")]
	internal interface IAsyncRequestStringWrapper
	{
		[Token(Token = "0x6000161")]
		void Request(Uri url, HttpMethod method, WWWForm query = null, FacebookDelegate<IGraphResult> callback = null);

		[Token(Token = "0x6000162")]
		void Request(Uri url, HttpMethod method, IDictionary<string, string> formData = null, FacebookDelegate<IGraphResult> callback = null);
	}
}
