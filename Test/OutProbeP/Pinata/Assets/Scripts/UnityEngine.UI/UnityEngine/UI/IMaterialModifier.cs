using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[Token(Token = "0x200002C")]
	public interface IMaterialModifier
	{
		[Token(Token = "0x60002E1")]
		Material GetModifiedMaterial(Material baseMaterial);
	}
}
