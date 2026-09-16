using Cpp2ILInjected;

namespace Tayx.Graphy.UI
{
	[Token(Token = "0x2000033")]
	public interface IModifiableState
	{
		[Token(Token = "0x6000171")]
		void SetState(GraphyManager.ModuleState newState, bool silentUpdate);
	}
}
