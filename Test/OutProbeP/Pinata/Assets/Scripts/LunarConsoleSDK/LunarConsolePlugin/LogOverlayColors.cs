using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace LunarConsolePlugin
{
	[Serializable]
	[Token(Token = "0x2000010")]
	public class LogOverlayColors
	{
		[SerializeField]
		[Token(Token = "0x4000022")]
		[FieldOffset(Offset = "0x10")]
		public LogEntryColors exception;

		[SerializeField]
		[Token(Token = "0x4000023")]
		[FieldOffset(Offset = "0x18")]
		public LogEntryColors error;

		[SerializeField]
		[Token(Token = "0x4000024")]
		[FieldOffset(Offset = "0x20")]
		public LogEntryColors warning;

		[SerializeField]
		[Token(Token = "0x4000025")]
		[FieldOffset(Offset = "0x28")]
		public LogEntryColors debug;

		[Token(Token = "0x6000046")]
		[Address(RVA = "0x13D58F8", Offset = "0x13D58F8", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EB5938]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, background, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028A62]) = v41;\nL_0018:\n\tv45 = new LunarConsolePlugin.LogEntryColors();\n\tSystem.Object::.ctor(v45);\n\tv48 = foreground >> 0x18;\n\tv49 = foreground >> 8;\n\tv50 = foreground >> 0x10;\n\tv52 = 0;\n\tv55 = 0x1010E50(&v52 @ stack_-38_v1 (UnityEngine.Color32), v50, v49, foreground, v48, 0, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv58 = background >> 0x18;\n\tv59 = background >> 8;\n\tv60 = background >> 0x10;\n\tv45.foreground = 0;\n\tv62 = 0;\n\tv65 = 0x1010E50(&v62 @ stack_-28_v1 (UnityEngine.Color32), v60, v59, background, v58, 0, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv45.background = 0;\n\treturn v45;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static LogEntryColors MakeColors(uint foreground, uint background)
		{
			LogEntryColors logEntryColors = new LogEntryColors();
			int num = (int)foreground >> 24;
			int num2 = (int)foreground >> 8;
			int num3 = (int)foreground >> 16;
			Color32 color = default(Color32);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1010E50 (inside UnityEngine.Color::op_Implicit +0x4)");
			int num4 = (int)background >> 24;
			int num5 = (int)background >> 8;
			int num6 = (int)background >> 16;
			logEntryColors.foreground = default(Color32);
			Color32 color2 = default(Color32);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1010E50 (inside UnityEngine.Color::op_Implicit +0x4)");
			logEntryColors.background = default(Color32);
			return logEntryColors;
		}

		[Token(Token = "0x6000047")]
		[Address(RVA = "0x13D59C8", Offset = "0x13D59C8", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = argb >> 0x18;\n\tv9 = argb >> 8;\n\tv10 = argb >> 0x10;\n\tv12 = 0;\n\tv15 = 0x1010E50(&v12 @ stack_-18_v1 (UnityEngine.Color32), v10, v9, argb, v8, 0, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25);\n\treturn 0;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Color32 MakeColor(uint argb)
		{
			int num = (int)argb >> 24;
			int num2 = (int)argb >> 8;
			int num3 = (int)argb >> 16;
			Color32 color = default(Color32);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1010E50 (inside UnityEngine.Color::op_Implicit +0x4)");
			return default(Color32);
		}

		[Token(Token = "0x6000048")]
		[Address(RVA = "0x13D5A08", Offset = "0x13D5A08", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = LunarConsolePlugin.LogOverlayColors::MakeColors(0xFFEA4646, 0xFF1E1E1E);\n\tthis.exception = v14;\n\tv20 = LunarConsolePlugin.LogOverlayColors::MakeColors(0xFFEA4646, 0xFF1E1E1E);\n\tthis.error = v20;\n\tv25 = LunarConsolePlugin.LogOverlayColors::MakeColors(0xFFCBCB40, 0xFF1E1E1E);\n\tthis.warning = v25;\n\tv30 = LunarConsolePlugin.LogOverlayColors::MakeColors(0xFF9BDDFF, 0xFF1E1E1E);\n\tthis.debug = v30;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public LogOverlayColors()
		{
			LogEntryColors logEntryColors = MakeColors(4293543494u, 4280163870u);
			exception = logEntryColors;
			LogEntryColors logEntryColors2 = MakeColors(4293543494u, 4280163870u);
			error = logEntryColors2;
			LogEntryColors logEntryColors3 = MakeColors(4291545920u, 4280163870u);
			warning = logEntryColors3;
			LogEntryColors logEntryColors4 = MakeColors(4288404991u, 4280163870u);
			debug = logEntryColors4;
		}
	}
}
