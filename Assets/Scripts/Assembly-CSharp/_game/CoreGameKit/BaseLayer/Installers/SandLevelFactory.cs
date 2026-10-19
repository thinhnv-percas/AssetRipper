using Cpp2ILInjected;
using _game.CoreGameKit.BaseLayer.LevelSystem;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;
using _game.CoreSystem.LevelCreator;

namespace _game.CoreGameKit.BaseLayer.Installers
{
	[Token(Token = "0x20006AA")]
	public class SandLevelFactory : LevelFactory<LevelCreatorData>
	{
		[Token(Token = "0x6001C2E")]
		[Address(RVA = "0x3D69B88", Offset = "0x3D69B88", Length = "0xC")]
		protected override bool CreateLevel(ILevel levelData, LevelCreatorData creationData)
		{
			bool flag = creationData == null;
			return !flag;
		}

		[Token(Token = "0x6001C2F")]
		[Address(RVA = "0x3D69B28", Offset = "0x3D69B28", Length = "0x58")]
		public SandLevelFactory()
		{
		}
	}
}
