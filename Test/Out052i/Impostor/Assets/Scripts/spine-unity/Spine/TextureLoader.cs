using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x2000030")]
	public interface TextureLoader
	{
		[Token(Token = "0x6000159")]
		void Load(AtlasPage page, string path);

		[Token(Token = "0x600015A")]
		void Unload(object texture);
	}
}
