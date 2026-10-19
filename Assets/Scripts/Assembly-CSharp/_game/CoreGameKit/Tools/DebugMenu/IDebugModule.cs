using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreGameKit.Tools.DebugMenu
{
	[Token(Token = "0x20005B5")]
	public interface IDebugModule
	{
		[Token(Token = "0x1700024F")]
		string Id
		{
			[Token(Token = "0x6001871")]
			get;
		}

		[Token(Token = "0x17000250")]
		string DisplayName
		{
			[Token(Token = "0x6001872")]
			get;
		}

		[Token(Token = "0x17000251")]
		int Order
		{
			[Token(Token = "0x6001873")]
			get;
		}

		[Token(Token = "0x6001874")]
		void OnPanelOpened();

		[Token(Token = "0x6001875")]
		void OnPanelClosed();

		[Token(Token = "0x6001876")]
		void DrawGUI(Rect contentArea);

		[Token(Token = "0x6001877")]
		IEnumerable<PinnedTriggerHandle> GetPinnedTriggers();
	}
}
