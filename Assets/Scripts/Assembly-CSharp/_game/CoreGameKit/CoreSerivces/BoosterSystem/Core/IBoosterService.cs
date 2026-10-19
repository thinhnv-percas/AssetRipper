using System;
using Cpp2ILInjected;

namespace _game.CoreGameKit.CoreSerivces.BoosterSystem.Core
{
	[Token(Token = "0x200062B")]
	public interface IBoosterService
	{
		[Token(Token = "0x14000020")]
		event Action<string, int> OnCountChanged;

		[Token(Token = "0x6001A6A")]
		int GetCount(string boosterId);

		[Token(Token = "0x6001A6B")]
		bool HasBooster(string boosterId);

		[Token(Token = "0x6001A6C")]
		BoosterDefinition GetDefinition(string boosterId);

		[Token(Token = "0x6001A6D")]
		bool IsUnlocked(string boosterId);

		[Token(Token = "0x6001A6E")]
		void AddBoosters(string boosterId, int amount, string sourceType);

		[Token(Token = "0x6001A6F")]
		bool UseBooster(string boosterId);

		[Token(Token = "0x6001A70")]
		void ResetAll();

		[Token(Token = "0x6001A71")]
		void MarkUnlocked(string boosterId);
	}
}
