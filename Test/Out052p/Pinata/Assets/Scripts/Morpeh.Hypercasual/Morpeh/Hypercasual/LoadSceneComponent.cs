using Cpp2ILInjected;
using Morpeh.Utils;

namespace Morpeh.Hypercasual
{
	[Token(Token = "0x2000007")]
	public struct LoadSceneComponent : IComponent
	{
		[Token(Token = "0x400001A")]
		[FieldOffset(Offset = "0x0")]
		public SceneReference scene;
	}
}
