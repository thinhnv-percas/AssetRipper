using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Morpeh.Hypercasual.Code.Utils.Editor
{
	[Token(Token = "0x2000011")]
	public class GameSettings : ScriptableObject
	{
		[Token(Token = "0x6000017")]
		[Address(RVA = "0x16337DC", Offset = "0x16337DC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void Start()
		{
		}

		[Token(Token = "0x6000018")]
		[Address(RVA = "0x16337E0", Offset = "0x16337E0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void Update()
		{
		}

		[Token(Token = "0x6000019")]
		[Address(RVA = "0x16337E4", Offset = "0x16337E4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GameSettings()
		{
		}
	}
}
