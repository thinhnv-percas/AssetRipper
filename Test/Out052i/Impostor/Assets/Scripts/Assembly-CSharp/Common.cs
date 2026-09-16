using System.Diagnostics;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000017")]
public class Common
{
	[Conditional("ENABLE_LOG")]
	[Token(Token = "0x6000080")]
	[Address(RVA = "0xBFA358", Offset = "0xBFA358", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
	public static void Log(object message)
	{
	}

	[Conditional("ENABLE_LOG")]
	[Token(Token = "0x6000081")]
	[Address(RVA = "0xBFA35C", Offset = "0xBFA35C", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
	public static void Log(string format, params object[] args)
	{
	}

	[Conditional("ENABLE_LOG")]
	[Token(Token = "0x6000082")]
	[Address(RVA = "0xBFA360", Offset = "0xBFA360", Length = "0x68")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = UnityEngine.Debug;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, context, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A355D5]) = v40;\nL_0019:\n\tgoto L_0024;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, context, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tUnityEngine.Debug::LogWarning(message, context);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void LogWarning(object message, Object context)
	{
		Debug.LogWarning(message, context);
	}

	[Conditional("ENABLE_LOG")]
	[Token(Token = "0x6000083")]
	[Address(RVA = "0xBFA3C8", Offset = "0xBFA3C8", Length = "0x80")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = UnityEngine.Debug;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, format, args, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 1;\n\t*([1A355D6]) = v43;\nL_0019:\n\tv46 = UtilityGame::Format(format, args);\n\tgoto L_002C;\n\tv52 = v47;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v52, v45, args, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_002C:\n\tUnityEngine.Debug::LogWarning(v46, context);\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void LogWarning(Object context, string format, params object[] args)
	{
		string message = UtilityGame.Format(format, args);
		Debug.LogWarning(message, context);
	}

	[Conditional("ENABLE_LOG")]
	[Token(Token = "0x6000084")]
	[Address(RVA = "0xBFA448", Offset = "0xBFA448", Length = "0x70")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = *([1A355D7]) & 1;\n\tv15 = v14 == 0;\n\tif (v15) goto L_0019;\n\tv17 = condition == 0;\n\tif (v17) goto L_0024;\nL_0014:\n\treturn;\nL_0019:\n\t*([1A355D7]) = 1;\n\tv54 = condition == 0;\n\tv37 = ~v54;\n\tif (v37) goto L_0014;\nL_0024:\n\tgoto L_002D;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v49, message, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_002D:\n\tUnityEngine.Debug::LogWarning(message);\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void Warning(bool condition, object message)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1A355D7]");
		if ((uint)((nuint)0u & (nuint)1u) != 0)
		{
			if (condition)
			{
				return;
			}
		}
		else
		{
			_ = 1;
			if (condition)
			{
				return;
			}
		}
		Debug.LogWarning(message);
	}

	[Conditional("ENABLE_LOG")]
	[Token(Token = "0x6000085")]
	[Address(RVA = "0xBFA4B8", Offset = "0xBFA4B8", Length = "0x84")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0x1A35000;\n\tv18 = *([1A355D8]) & 1;\n\tv19 = v18 == 0;\n\tif (v19) goto L_001C;\n\tv21 = condition == 0;\n\tif (v21) goto L_0027;\nL_0017:\n\treturn;\nL_001C:\n\t*([v10 @ X22_v1+5D8]) = 1;\n\tv58 = condition == 0;\n\tv40 = ~v58;\n\tif (v40) goto L_0017;\nL_0027:\n\tgoto L_0032;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v53, message, context, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0032:\n\tUnityEngine.Debug::LogWarning(message, context);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void Warning(bool condition, object message, Object context)
	{
		//IL_0009: Expected O, but got I4
		object obj = 27480064;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1A355D8]");
		if ((uint)((nuint)0u & (nuint)1u) != 0)
		{
			if (condition)
			{
				return;
			}
		}
		else
		{
			_ = 1;
			if (condition)
			{
				return;
			}
		}
		Debug.LogWarning(message, context);
	}

	[Conditional("ENABLE_LOG")]
	[Token(Token = "0x6000086")]
	[Address(RVA = "0xBFA53C", Offset = "0xBFA53C", Length = "0x9C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([1A355D9]) & 1;\n\tv23 = v22 == 0;\n\tif (v23) goto L_001F;\n\tv25 = condition == 0;\n\tif (v25) goto L_0028;\nL_001A:\n\treturn;\nL_001F:\n\t*([1A355D9]) = 1;\n\tv61 = condition == 0;\n\tv43 = ~v61;\n\tif (v43) goto L_001A;\nL_0028:\n\tv59 = UtilityGame::Format(format, args);\n\tgoto L_003B;\n\tv89 = v84;\n\tv90 = \"il2cpp_codegen_runtime_class_init\"(v89, v58, format, args, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_003B:\n\tUnityEngine.Debug::LogWarning(v59, context);\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void Warning(bool condition, Object context, string format, params object[] args)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1A355D9]");
		if ((uint)((nuint)0u & (nuint)1u) != 0)
		{
			if (condition)
			{
				return;
			}
		}
		else
		{
			_ = 1;
			if (condition)
			{
				return;
			}
		}
		string message = UtilityGame.Format(format, args);
		Debug.LogWarning(message, context);
	}

	[Conditional("ASSERT")]
	[Token(Token = "0x6000087")]
	[Address(RVA = "0xBFA5D8", Offset = "0xBFA5D8", Length = "0x40")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = condition == 0;\n\tif (v2) goto L_000A;\n\treturn;\nL_000A:\n\tv35 = new UnityEngine.UnityException();\n\tUnityEngine.UnityException::.ctor(v35);\n\tthrow v35;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void Assert(bool condition)
	{
		if (condition)
		{
			return;
		}
		UnityException ex = new UnityException();
		throw ex;
	}

	[Conditional("ASSERT")]
	[Token(Token = "0x6000088")]
	[Address(RVA = "0xBFA618", Offset = "0xBFA618", Length = "0x4C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = condition == 0;\n\tif (v2) goto L_000C;\n\treturn;\nL_000C:\n\tv43 = new UnityEngine.UnityException();\n\tUnityEngine.UnityException::.ctor(v43, message);\n\tthrow v43;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void Assert(bool condition, string message)
	{
		if (condition)
		{
			return;
		}
		UnityException ex = new UnityException(message);
		throw ex;
	}

	[Conditional("ASSERT")]
	[Token(Token = "0x6000089")]
	[Address(RVA = "0xBFA664", Offset = "0xBFA664", Length = "0x58")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = condition == 0;\n\tif (v2) goto L_000A;\n\treturn;\nL_000A:\n\tv13 = UtilityGame::Format(format, args);\n\tv46 = new UnityEngine.UnityException();\n\tUnityEngine.UnityException::.ctor(v46, v13);\n\tthrow v46;\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void Assert(bool condition, string format, params object[] args)
	{
		if (condition)
		{
			return;
		}
		string message = UtilityGame.Format(format, args);
		UnityException ex = new UnityException(message);
		throw ex;
	}

	[Token(Token = "0x600008A")]
	[Address(RVA = "0xBFA6BC", Offset = "0xBFA6BC", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public Common()
	{
	}
}
