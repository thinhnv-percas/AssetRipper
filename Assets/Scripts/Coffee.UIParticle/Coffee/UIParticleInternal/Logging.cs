using System;
using System.Diagnostics;
using System.Text;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Coffee.UIParticleInternal
{
	[Token(Token = "0x2000012")]
	internal static class Logging
	{
		[Token(Token = "0x4000011")]
		private const string k_DisableSymbol = "DISABLE_COFFEE_LOGGER";

		[Conditional("DISABLE_COFFEE_LOGGER")]
		[Token(Token = "0x600003F")]
		[Address(RVA = "0x3F20020", Offset = "0x3F20020", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private static void Log_Internal(LogType type, object tag, object message, UnityEngine.Object context)
		{
		}

		[Conditional("DISABLE_COFFEE_LOGGER")]
		[Token(Token = "0x6000040")]
		[Address(RVA = "0x3F20024", Offset = "0x3F20024", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public static void LogIf(bool enable, object tag, object message, UnityEngine.Object context = null)
		{
		}

		[Conditional("DISABLE_COFFEE_LOGGER")]
		[Token(Token = "0x6000041")]
		[Address(RVA = "0x3F20028", Offset = "0x3F20028", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public static void Log(object tag, object message, UnityEngine.Object context = null)
		{
		}

		[Conditional("DISABLE_COFFEE_LOGGER")]
		[Token(Token = "0x6000042")]
		[Address(RVA = "0x3F2002C", Offset = "0x3F2002C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public static void LogWarning(object tag, object message, UnityEngine.Object context = null)
		{
		}

		[Token(Token = "0x6000043")]
		[Address(RVA = "0x3F20030", Offset = "0x3F20030", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv67 = System.String::Format(\"{0}: {1}\", tag, message);\n\tgoto L_0038;\nL_0038:\n\tUnityEngine.Debug::LogError(v67, context);\n\treturn;\n")]
		public static void LogError(object tag, object message, UnityEngine.Object context = null)
		{
			string message2 = $"{tag}: {message}";
			Debug.LogError(message2, context);
		}

		[Conditional("DISABLE_COFFEE_LOGGER")]
		[Token(Token = "0x6000044")]
		[Address(RVA = "0x3F200D8", Offset = "0x3F200D8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public static void LogMulticast(Type type, string fieldName, object instance = null, string message = null)
		{
		}

		[Conditional("DISABLE_COFFEE_LOGGER")]
		[Token(Token = "0x6000045")]
		[Address(RVA = "0x3F200DC", Offset = "0x3F200DC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private static void AppendTag(StringBuilder sb, object tag)
		{
		}

		[Conditional("DISABLE_COFFEE_LOGGER")]
		[Token(Token = "0x6000046")]
		[Address(RVA = "0x3F200E0", Offset = "0x3F200E0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private static void AppendType(StringBuilder sb, Type type)
		{
		}

		[Conditional("DISABLE_COFFEE_LOGGER")]
		[Token(Token = "0x6000047")]
		[Address(RVA = "0x3F200E4", Offset = "0x3F200E4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private static void AppendReadableCode(StringBuilder sb, object tag)
		{
		}
	}
}
