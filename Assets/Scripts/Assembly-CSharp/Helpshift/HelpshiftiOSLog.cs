using System.Runtime.InteropServices;
using Cpp2ILInjected;

namespace Helpshift
{
	[Token(Token = "0x2000803")]
	public class HelpshiftiOSLog
	{
		[DllImport("__Internal")]
		[Token(Token = "0x6002223")]
		[Address(RVA = "0x3DCD68C", Offset = "0x3DCD68C", Length = "0x28")]
		private static extern void HsAddDebugLog(string log);

		[Token(Token = "0x6002224")]
		[Address(RVA = "0x3DCD6B4", Offset = "0x3DCD6B4", Length = "0x8")]
		private HelpshiftiOSLog()
		{
		}

		[Token(Token = "0x6002225")]
		[Address(RVA = "0x3DCC634", Offset = "0x3DCC634", Length = "0x9C")]
		public static int v(string tag, string log)
		{
			string text = "HelpshiftLog:Verbose::" + tag + "::" + log;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1814");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BEFCFC");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1828");
			return 0;
		}

		[Token(Token = "0x6002226")]
		[Address(RVA = "0x3DCC76C", Offset = "0x3DCC76C", Length = "0x9C")]
		public static int d(string tag, string log)
		{
			string text = "HelpshiftLog:Debug::" + tag + "::" + log;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1814");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BEFCFC");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1828");
			return 0;
		}

		[Token(Token = "0x6002227")]
		[Address(RVA = "0x3DCC8A4", Offset = "0x3DCC8A4", Length = "0x9C")]
		public static int i(string tag, string log)
		{
			string text = "HelpshiftLog:Info::" + tag + "::" + log;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1814");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BEFCFC");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1828");
			return 0;
		}

		[Token(Token = "0x6002228")]
		[Address(RVA = "0x3DCC9DC", Offset = "0x3DCC9DC", Length = "0x9C")]
		public static int w(string tag, string log)
		{
			string text = "HelpshiftLog:Warn::" + tag + "::" + log;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1814");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BEFCFC");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1828");
			return 0;
		}

		[Token(Token = "0x6002229")]
		[Address(RVA = "0x3DCCB14", Offset = "0x3DCCB14", Length = "0x9C")]
		public static int e(string tag, string log)
		{
			string text = "HelpshiftLog:Error::" + tag + "::" + log;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1814");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BEFCFC");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1828");
			return 0;
		}

		[Token(Token = "0x600222A")]
		[Address(RVA = "0x3DCD6BC", Offset = "0x3DCD6BC", Length = "0x30")]
		public static int log(string log)
		{
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1814");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BEFCFC");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1828");
			return 0;
		}
	}
}
