using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using ElephantUniTask.Threading.Tasks;

namespace ElephantSocial.Chat.Interface
{
	[Token(Token = "0x200092D")]
	public interface IWebSocketClient
	{
		[Token(Token = "0x17000455")]
		WebSocketState State
		{
			[Token(Token = "0x600271A")]
			get;
		}

		[Token(Token = "0x1400004A")]
		event Action OnOpen;

		[Token(Token = "0x1400004B")]
		event Action<string> OnClose;

		[Token(Token = "0x1400004C")]
		event Action<string> OnError;

		[Token(Token = "0x1400004D")]
		event Action<byte[]> OnMessage;

		[Token(Token = "0x600271B")]
		UniTask ConnectAsync(string url, Dictionary<string, string> headers = null);

		[Token(Token = "0x600271C")]
		UniTask CloseAsync();

		[Token(Token = "0x600271D")]
		UniTask SendTextAsync(string data);
	}
}
