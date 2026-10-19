using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AlmostEngine.SimpleLocalization
{
	[Token(Token = "0x2000072")]
	public abstract class ISimpleLocalizer : MonoBehaviour
	{
		[Token(Token = "0x6000210")]
		public abstract void OnLanguageChanged(string ID);

		[Token(Token = "0x6000211")]
		public abstract void Save();

		[Token(Token = "0x6000212")]
		public abstract void Restore();

		[Token(Token = "0x6000213")]
		[Address(RVA = "0x3C4B930", Offset = "0x3C4B930", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		protected internal ISimpleLocalizer()
		{
		}
	}
}
