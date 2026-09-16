using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[AddComponentMenu("UI/Effects/Outline", 81)]
	[Token(Token = "0x2000086")]
	public class Outline : Shadow
	{
		[Token(Token = "0x6000536")]
		[Address(RVA = "0x183E368", Offset = "0x183E368", Length = "0x8")]
		protected Outline()
		{
		}

		[Token(Token = "0x6000537")]
		[Address(RVA = "0x183E370", Offset = "0x183E370", Length = "0x240")]
		public override void ModifyMesh(VertexHelper vh)
		{
		}
	}
}
