using System.Diagnostics;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Logging;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Reflex.Injectors
{
	[Token(Token = "0x2000020")]
	internal static class UnityInjector
	{
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
		[Token(Token = "0x6000058")]
		[Address(RVA = "0x3F33840", Offset = "0x3F33840", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private static void AfterAssembliesLoaded()
		{
		}

		[Conditional("UNITY_EDITOR")]
		[Token(Token = "0x6000059")]
		[Address(RVA = "0x3F33844", Offset = "0x3F33844", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private static void ResetStaticState()
		{
		}

		[Conditional("REFLEX_DEBUG")]
		[Token(Token = "0x600005A")]
		[Address(RVA = "0x3F33848", Offset = "0x3F33848", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\nL_0010:\n\tv49 = 0xB2FD000 + 0x620;\n\tgoto L_0015;\nL_0015:\n\tv168 = *([v49 @ X19_v14 (System.Int32)]);\n\tv54 = *([B78EB62]) & 1;\n\tv55 = v54 == 0;\n\tif (v55) goto L_0054;\n\tgoto L_002C;\nL_002C:\n\tv110 = v97._logLevel <= 1;\n\tif (v110) goto L_0071;\n\treturn;\nL_0054:\n\t*([B78EB62]) = 1;\n\tv168 = v168;\n\tgoto L_002C;\nL_0071:\n\tgoto L_007D;\nL_007D:\n\tUnityEngine.Debug::LogWarning(v168, 0);\n\treturn;\n")]
		private static void ReportReflexDebuggerStatus()
		{
			//IL_0021: Expected O, but got I4
			int num = 187682816 + 1568;
			object obj = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78EB62]");
			if ((int)((nint)0 & (nint)1) == 0)
			{
				_ = 1;
				obj = obj;
			}
			if (ReflexLogger._logLevel <= LogLevel.Warning)
			{
				Debug.LogWarning(obj, null);
			}
		}
	}
}
