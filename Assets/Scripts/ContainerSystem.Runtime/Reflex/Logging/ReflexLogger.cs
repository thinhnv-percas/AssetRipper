using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Configuration;
using UnityEngine;

namespace Reflex.Logging
{
	[Token(Token = "0x200001A")]
	internal static class ReflexLogger
	{
		[Token(Token = "0x4000030")]
		internal static LogLevel _logLevel;

		[Token(Token = "0x600004A")]
		[Address(RVA = "0x3F31788", Offset = "0x3F31788", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tgoto L_0034;\nL_0034:\n\tgoto L_0042;\nL_0042:\n\tv94 = v81._logLevel <= 0;\n\tif (v94) goto L_0070;\n\treturn;\nL_0070:\n\tgoto L_0075;\nL_0075:\n\tUnityEngine.Debug::Log(v63, 0);\n\treturn;\nL_001F:\n\tv48 = Reflex.Configuration.ReflexSettings::get_LogLevel();\n\tv53._logLevel = v48;\n\tv54 = v48;\n\t// 38 Box v57 @ X0_v4 (System.Object), typeof(Reflex.Logging.LogLevel), &v54 @ stack_-34_v1 (Reflex.Logging.LogLevel)\n\tv63 = System.String::Format(\"Reflex LogLevel set to {0}\", v57);\n")]
		static ReflexLogger()
		{
			object arg = (_logLevel = ReflexSettings.LogLevel);
			string message = $"Reflex LogLevel set to {arg}";
			if (_logLevel <= LogLevel.Info)
			{
				Debug.Log(message, null);
			}
		}

		[Token(Token = "0x600004B")]
		[Address(RVA = "0x3F31C58", Offset = "0x3F31C58", Length = "0x1A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_001F;\nL_001F:\n\tv60 = v49._logLevel != logLevel;\n\tif (v60) goto L_004E;\nL_0028:\n\treturn;\nL_004E:\n\tgoto L_0052;\nL_0064:\n\tgoto L_0072;\nL_0072:\n\tv83 = v232._logLevel > 0;\n\tif (v83) goto L_0028;\n\tgoto L_0099;\nL_0099:\n\tgoto L_009E;\nL_009E:\n\tUnityEngine.Debug::Log(v218, 0);\n\treturn;\nL_0052:\n\tv209._logLevel = logLevel;\n\tv70 = logLevel;\n\t// 86 Box v213 @ X0_v4 (System.Object), typeof(Reflex.Logging.LogLevel), &v70 @ stack_-34_v1 (Reflex.Logging.LogLevel)\n\tv218 = System.String::Format(\"Reflex LogLevel set to {0}\", v213);\n\tgoto L_0064;\n")]
		public static void UpdateLogLevel(LogLevel logLevel)
		{
			if (_logLevel != logLevel)
			{
				_logLevel = logLevel;
				object arg = logLevel;
				string message = $"Reflex LogLevel set to {arg}";
				if (_logLevel <= LogLevel.Info)
				{
					Debug.Log(message, null);
				}
			}
		}

		[Token(Token = "0x600004C")]
		[Address(RVA = "0x3F31A64", Offset = "0x3F31A64", Length = "0x1F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tgoto L_0025;\nL_0025:\n\tv68 = v55._logLevel <= logLevel;\n\tif (v68) goto L_005A;\n\treturn;\nL_005A:\n\tv134 = logLevel > 0;\n\tif (v134) goto L_0084;\n\tv190 = logLevel == -1;\n\tif (v190) goto L_0070;\n\tv252 = logLevel == 0;\n\tv253 = ~v252;\n\tif (v253) goto L_00C1;\nL_0070:\n\tgoto L_007E;\nL_007E:\n\tUnityEngine.Debug::Log(message, context);\n\treturn;\nL_0084:\n\tv192 = logLevel == 1;\n\tif (v192) goto L_00B1;\n\tv167 = logLevel != 2;\n\tif (v167) goto L_00C1;\n\tgoto L_00A9;\nL_00A9:\n\tUnityEngine.Debug::LogError(message, context);\n\treturn;\nL_00B1:\n\tgoto L_00BF;\nL_00BF:\n\tUnityEngine.Debug::LogWarning(message, context);\n\treturn;\nL_00C1:\n\tv146 = logLevel;\n\tv265 = 0xB291000 + 0x648;\n\tv276 = \"il2cpp_vm_object_box\"(v265, &v146 @ stack_-44_v1 (Reflex.Logging.LogLevel), context, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv280 = 0xB28B000 + 0x608;\n\tv282 = new v280();\n\tSystem.ArgumentOutOfRangeException::.ctor(v282, \"logLevel\", v276, 0);\n\tthrow v282;\n")]
		public static void Log(object message, LogLevel logLevel, UnityEngine.Object context = null)
		{
			if (_logLevel <= logLevel)
			{
				switch (logLevel)
				{
				case LogLevel.Development:
				case LogLevel.Info:
					Debug.Log(message, context);
					return;
				case LogLevel.Error:
					Debug.LogError(message, context);
					return;
				case LogLevel.Warning:
					Debug.LogWarning(message, context);
					return;
				}
				int num = 187240448 + 1608;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				int num2 = 187215872 + 1544;
				object actualValue = default(object);
				ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("logLevel", actualValue, null);
				throw ex;
			}
		}
	}
}
