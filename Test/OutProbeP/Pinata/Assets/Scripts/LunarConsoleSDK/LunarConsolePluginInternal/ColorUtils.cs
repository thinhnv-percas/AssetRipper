using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace LunarConsolePluginInternal
{
	[Token(Token = "0x2000028")]
	internal static class ColorUtils
	{
		[Token(Token = "0x400007A")]
		private const float kMultiplier = 0.003921569f;

		[Token(Token = "0x6000106")]
		[Address(RVA = "0x13DFE00", Offset = "0x13DFE00", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = value >> 0x10;\n\tv8 = v6 & 0xFF;\n\tv12 = value >> 8;\n\tv13 = v12 & 0xFF;\n\tv15 = value & 0xFF;\n\tv16 = value >> 0x18;\n\tv23 = v8 * 0.003921569f;\n\tv24 = v13 * 0.003921569f;\n\tv25 = v15 * 0.003921569f;\n\tv26 = v16 * 0.003921569f;\n\tv28 = 0;\n\tv31 = 0x101059C(&v28 @ stack_-20_v1 (UnityEngine.Color), 0, v32, v33, v34, v35, v36, v37, v26, v23, v24, v25, 0.003921569f, v13, v15, v16);\n\treturn 0;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Color FromRGBA(uint value)
		{
			int num = (int)value >> 16;
			int num2 = num & 0xFF;
			int num3 = (int)value >> 8;
			int num4 = num3 & 0xFF;
			int num5 = (int)(value & 0xFF);
			int num6 = (int)value >> 24;
			float num7 = (float)num2 * 0.003921569f;
			float num8 = (float)num4 * 0.003921569f;
			float num9 = (float)num5 * 0.003921569f;
			float num10 = (float)num6 * 0.003921569f;
			Color color = default(Color);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @101059C (inside UnityEngine.ClassLibraryInitializer::Init +0x8)");
			return default(Color);
		}

		[Token(Token = "0x6000107")]
		[Address(RVA = "0x13DFE78", Offset = "0x13DFE78", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = value >> 8;\n\tv8 = v6 & 0xFF;\n\tv12 = value & 0xFF;\n\tv13 = value >> 0x10;\n\tv14 = v13 & 0xFF;\n\tv20 = v8 * 0.003921569f;\n\tv21 = v12 * 0.003921569f;\n\tv22 = v14 * 0.003921569f;\n\tv25 = 0;\n\tv28 = 0x101059C(&v25 @ stack_-20_v1 (UnityEngine.Color), 0, v29, v30, v31, v32, v33, v34, v22, v20, v21, 1f, v12, v14, v35, v36);\n\treturn 0;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Color FromRGB(uint value)
		{
			int num = (int)value >> 8;
			int num2 = num & 0xFF;
			int num3 = (int)(value & 0xFF);
			int num4 = (int)value >> 16;
			int num5 = num4 & 0xFF;
			float num6 = (float)num2 * 0.003921569f;
			float num7 = (float)num3 * 0.003921569f;
			float num8 = (float)num5 * 0.003921569f;
			Color color = default(Color);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @101059C (inside UnityEngine.ClassLibraryInitializer::Init +0x8)");
			return default(Color);
		}

		[Token(Token = "0x6000108")]
		[Address(RVA = "0x13DFEE4", Offset = "0x13DFEE4", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t// 6 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv8 = *([value @ X0 (UnityEngine.Color&)+C]) * 255f;\n\tv9 = *([value @ X0 (UnityEngine.Color&)]) * 255f;\n\tv11 = *([value @ X0 (UnityEngine.Color&)+4]) * v12;\n\t// 12 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 15 NotImplemented \"Instruction USHL not yet implemented.\"\n\tv15 = v11 & 0xFF0000FF0000;\n\tv19 = v15 | v9;\n\tv21 = v8 & 0xFF;\n\tv22 = v19 | v18;\n\treturnVal1 = v22 | v21;\n\treturn returnVal1;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static uint ToRGBA(ref Color value)
		{
			//IL_004d: Expected O, but got I
			//IL_0074: Expected I4, but got I8
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Expected I4, but got Unknown
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Expected O, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [value @ X0 (UnityEngine.Color&)+C]");
			float num = 0f * 255f;
			float num2 = (float)value * 255f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [value @ X0 (UnityEngine.Color&)+4]");
			object obj2 = default(object);
			object obj = 0L * (long)(IntPtr)obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction USHL not yet implemented.\"");
			int num3 = (int)((long)(IntPtr)obj & 0xFF0000FF0000L);
			int num4 = num3 | num2;
			object obj3 = num & 0xFF;
			object obj4 = default(object);
			int num5 = (int)((long)num4 | (long)(IntPtr)obj4);
			return (uint)((ulong)num5 | (ulong)(long)(IntPtr)obj3);
		}
	}
}
