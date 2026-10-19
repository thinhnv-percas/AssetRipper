using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.TextViewSystem
{
	[Token(Token = "0x200001B")]
	public abstract class TextView : MonoBehaviour
	{
		[Token(Token = "0x6000064")]
		public abstract void SetText(string text);

		[Token(Token = "0x6000065")]
		public abstract string GetText();

		[Token(Token = "0x6000066")]
		public abstract void SetColor(Color color);

		[Token(Token = "0x6000067")]
		public abstract Color GetColor();

		[Token(Token = "0x6000068")]
		[Address(RVA = "0x81C1C08", Offset = "0x81C1C08", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public TextView()
		{
		}
	}
}
