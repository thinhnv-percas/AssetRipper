using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.SandPhysics.SDF
{
	[Token(Token = "0x200010F")]
	public static class SandSDFLogger
	{
		[Token(Token = "0x17000086")]
		public static string CurrentPath
		{
			[Token(Token = "0x60005BB")]
			[Address(RVA = "0x3DAE24C", Offset = "0x3DAE24C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x60005BC")]
		[Address(RVA = "0x3DAE254", Offset = "0x3DAE254", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public static void BeginSession(string sessionTag = null)
		{
		}

		[Token(Token = "0x60005BD")]
		[Address(RVA = "0x3DAE1AC", Offset = "0x3DAE1AC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public static void Log(string message)
		{
		}

		[Token(Token = "0x60005BE")]
		[Address(RVA = "0x3DAE088", Offset = "0x3DAE088", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\nL_002B:\n\tUnityEngine.Debug::LogError(v50);\n\treturn;\nL_001E:\n\tv50 = System.String::Concat(\"[SDF] \", message);\n\tgoto L_002B;\n")]
		public static void LogError(string message)
		{
			string message2 = "[SDF] " + message;
			Debug.LogError(message2);
		}

		[Token(Token = "0x60005BF")]
		[Address(RVA = "0x3DAE258", Offset = "0x3DAE258", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public static void EndSession()
		{
		}
	}
}
