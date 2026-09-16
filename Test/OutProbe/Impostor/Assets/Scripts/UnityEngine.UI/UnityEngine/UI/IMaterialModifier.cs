using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[Token(Token = "0x2000059")]
	public interface IMaterialModifier
	{
		[Token(Token = "0x6000361")]
		Material GetModifiedMaterial(Material baseMaterial);
	}
}
