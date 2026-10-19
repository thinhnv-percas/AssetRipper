using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.ResourceSystem;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Interface;

namespace _game.CoreGameKit.CoreSerivces.LevelProgresService.Core
{
	[Token(Token = "0x200060D")]
	public class LevelTransactionContextProvider : ITransactionContextProvider
	{
		[Inject(false)]
		[Token(Token = "0x40014E9")]
		[FieldOffset(Offset = "0x10")]
		private ILevelProgressService _levelProgressService;

		[Token(Token = "0x17000280")]
		public int CurrentLevel
		{
			[Token(Token = "0x6001A05")]
			[Address(RVA = "0x3D4F7B8", Offset = "0x3D4F7B8", Length = "0xAC")]
			get
			{
				int currentLevelIndex = _levelProgressService.CurrentLevelIndex;
				return currentLevelIndex + 1;
			}
		}

		[Token(Token = "0x6001A06")]
		[Address(RVA = "0x3D4EAE8", Offset = "0x3D4EAE8", Length = "0x8")]
		public LevelTransactionContextProvider()
		{
		}
	}
}
