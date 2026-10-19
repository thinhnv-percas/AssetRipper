using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.TextViewSystem
{
	[Token(Token = "0x2000019")]
	public abstract class ProgressView : MonoBehaviour
	{
		[Token(Token = "0x17000007")]
		public abstract float Progress
		{
			[Token(Token = "0x600005C")]
			get;
		}

		[Token(Token = "0x600005D")]
		public abstract void SetProgress(float value);

		[Token(Token = "0x600005E")]
		[Address(RVA = "0x81C1CB8", Offset = "0x81C1CB8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		protected internal ProgressView()
		{
		}
	}
}
