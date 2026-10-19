using Cpp2ILInjected;
using ElephantSDK;

namespace _game.Systems.ElephantStorage
{
	[Token(Token = "0x2000781")]
	public class ElephantStorageDataHandler : IPlayerDataHandler
	{
		[Token(Token = "0x40018FA")]
		[FieldOffset(Offset = "0x10")]
		private GameStorage _storage;

		[Token(Token = "0x6001F9B")]
		[Address(RVA = "0x3D9253C", Offset = "0x3D9253C", Length = "0x80")]
		public void Load(GameStorage storage)
		{
			_storage = storage;
			Elephant.LoadStorage(storage);
		}

		[Token(Token = "0x6001F9C")]
		[Address(RVA = "0x3D925BC", Offset = "0x3D925BC", Length = "0x70")]
		public void Save()
		{
			Elephant.SaveStorage();
		}

		[Token(Token = "0x6001F9D")]
		[Address(RVA = "0x3D9262C", Offset = "0x3D9262C", Length = "0x8")]
		public ElephantStorageDataHandler()
		{
		}
	}
}
