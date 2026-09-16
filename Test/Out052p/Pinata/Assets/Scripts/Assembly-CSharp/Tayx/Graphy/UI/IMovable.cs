using Cpp2ILInjected;

namespace Tayx.Graphy.UI
{
	[Token(Token = "0x2000034")]
	public interface IMovable
	{
		[Token(Token = "0x6000172")]
		void SetPosition(GraphyManager.ModulePosition newModulePosition);
	}
}
