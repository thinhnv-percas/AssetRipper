using System;
using System.Runtime.InteropServices;
using AssetRipperInjected;
using CodeStage.AntiCheat.Common;
using CodeStage.AntiCheat.Detectors;
using CodeStage.AntiCheat.Utils;
using Cpp2ILInjected;
using UnityEngine;

namespace CodeStage.AntiCheat.ObscuredTypes
{
	[Serializable]
	[Token(Token = "0x2000012")]
	public struct ObscuredDecimal : IObscuredType, IFormattable, IEquatable<ObscuredDecimal>, IComparable<ObscuredDecimal>, IComparable<decimal>, IComparable
	{
		[StructLayout((LayoutKind)2)]
		[Token(Token = "0x2000013")]
		private struct DecimalLongBytesUnion
		{
			[System.Runtime.InteropServices.FieldOffset(0)]
			[Token(Token = "0x4000062")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			private decimal d;

			[System.Runtime.InteropServices.FieldOffset(0)]
			[Token(Token = "0x4000063")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			private long l1;

			[System.Runtime.InteropServices.FieldOffset(8)]
			[Token(Token = "0x4000064")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			private long l2;

			[System.Runtime.InteropServices.FieldOffset(0)]
			[Token(Token = "0x4000065")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			private ACTkByte16 b16;

			[Token(Token = "0x6000111")]
			[Address(RVA = "0xBDC704", Offset = "0xBDC704", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = value ^ methodInfo;\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			internal static decimal XorDecimalToDecimal(decimal value, long key)
			{
				//IL_0009: Unknown result type (might be due to invalid IL or missing references)
				//IL_000e: Expected O, but got Unknown
				IntPtr intPtr = default(IntPtr);
				return value ^ (nint)intPtr;
			}

			[Token(Token = "0x6000112")]
			[Address(RVA = "0xBDC99C", Offset = "0xBDC99C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = value ^ methodInfo;\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			internal static ACTkByte16 XorDecimalToB16(decimal value, long key)
			{
				//IL_0009: Unknown result type (might be due to invalid IL or missing references)
				//IL_000e: Expected O, but got Unknown
				IntPtr intPtr = default(IntPtr);
				return (ACTkByte16)(value ^ (nint)intPtr);
			}

			[Token(Token = "0x6000113")]
			[Address(RVA = "0xBDC9A8", Offset = "0xBDC9A8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = value ^ methodInfo;\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			internal static decimal XorB16ToDecimal(ACTkByte16 value, long key)
			{
				//IL_0009: Unknown result type (might be due to invalid IL or missing references)
				//IL_000e: Expected O, but got Unknown
				IntPtr intPtr = default(IntPtr);
				return (decimal)(value ^ (nint)intPtr);
			}

			[Token(Token = "0x6000114")]
			[Address(RVA = "0xBDC7F4", Offset = "0xBDC7F4", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn value;\n")]
			internal static decimal ConvertB16ToDecimal(ACTkByte16 value)
			{
				return (decimal)value;
			}

			[Token(Token = "0x6000115")]
			[Address(RVA = "0xBDC7F8", Offset = "0xBDC7F8", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn value;\n")]
			internal static ACTkByte16 ConvertDecimalToB16(decimal value)
			{
				return (ACTkByte16)value;
			}

			[Token(Token = "0x6000116")]
			[Address(RVA = "0xBDD528", Offset = "0xBDD528", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn value;\n")]
			private static DecimalLongBytesUnion FromDecimal(decimal value)
			{
				return (DecimalLongBytesUnion)value;
			}

			[Token(Token = "0x6000117")]
			[Address(RVA = "0xBDD544", Offset = "0xBDD544", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn value;\n")]
			private static DecimalLongBytesUnion FromB16(ACTkByte16 value)
			{
				return (DecimalLongBytesUnion)value;
			}

			[Token(Token = "0x6000118")]
			[Address(RVA = "0xBDD52C", Offset = "0xBDD52C", Length = "0x18")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = this.d ^ key;\n\tv5 = this.l2 ^ key;\n\tthis.d = v3;\n\tthis.l2 = v5;\n\treturn v3;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private DecimalLongBytesUnion XorLongs(long key)
			{
				//IL_000a: Unknown result type (might be due to invalid IL or missing references)
				//IL_000f: Expected I8, but got Unknown
				//IL_0028: Expected O, but got I8
				//IL_0037: Expected O, but got I8
				long num = d ^ key;
				long num2 = l2 ^ key;
				d = num;
				l2 = num2;
				return (DecimalLongBytesUnion)num;
			}
		}

		[SerializeField]
		[Token(Token = "0x400005D")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		private long currentCryptoKey;

		[SerializeField]
		[Token(Token = "0x400005E")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		private ACTkByte16 hiddenValue;

		[SerializeField]
		[Token(Token = "0x400005F")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
		private bool inited;

		[Token(Token = "0x4000060")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
		private decimal fakeValue;

		[SerializeField]
		[Token(Token = "0x4000061")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
		private bool fakeValueActive;

		[Token(Token = "0x60000EF")]
		[Address(RVA = "0xBDC630", Offset = "0xBDC630", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv22 = System.Decimal;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, value, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A3545D]) = v39;\nL_0014:\n\tv40 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tv42 = value ^ v40;\n\tv43 = methodInfo ^ v40;\n\tv37.currentCryptoKey = v40;\n\tv37.hiddenValue = v42;\n\t*([v37 @ X0_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal)+10]) = v43;\n\tv45 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv48 = v45 == 0;\n\tv49 = ~v48;\n\tif (v49) goto L_0030;\n\tgoto L_002B;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v52, value, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv73 = System.Decimal;\nL_002B:\n\tv64 = *([v57 @ X0_v7 (Il2CppClass<System.Decimal>)+B8]);\n\tv59 = v64.Zero;\n\tv61 = *([v64 @ X8_v7 (Il2CppStaticFields<System.Decimal>)+8]);\nL_0030:\n\tv37.fakeValue = v59;\n\t*([v37 @ X0_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal)+28]) = v61;\n\tv37.fakeValueActive = v45;\n\tv37.inited = 1;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private ObscuredDecimal(decimal value)
		{
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Expected I4, but got Unknown
			//IL_0046: Expected I8, but got I4
			//IL_0050: Expected O, but got I4
			//IL_0013: Expected I, but got O
			//IL_00c4: Expected I, but got O
			int num = RandomUtils.GenerateIntKey();
			int num2 = value ^ num;
			IntPtr intPtr = default(IntPtr);
			int num3 = (int)((nint)intPtr ^ num);
			currentCryptoKey = num;
			hiddenValue = (ACTkByte16)num2;
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			bool flag = !existsAndIsRunning;
			bool flag2 = !flag;
			decimal num4 = value;
			nint num5 = intPtr;
			if (!flag2)
			{
				nint num6 = (nint)typeof(decimal);
				nint num7 = (nint)0;
				num4 = 0m;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ X8_v7 (Il2CppStaticFields<System.Decimal>)+8]");
				num5 = 0;
			}
			fakeValue = num4;
			fakeValueActive = existsAndIsRunning;
			inited = true;
		}

		[Token(Token = "0x60000F0")]
		[Address(RVA = "0xBDC6F8", Offset = "0xBDC6F8", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = value ^ methodInfo;\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static decimal Encrypt(decimal value, long key)
		{
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Expected O, but got Unknown
			IntPtr intPtr = default(IntPtr);
			return value ^ (nint)intPtr;
		}

		[Token(Token = "0x60000F1")]
		[Address(RVA = "0xBDC710", Offset = "0xBDC710", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = value ^ methodInfo;\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static decimal Decrypt(decimal value, long key)
		{
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Expected O, but got Unknown
			IntPtr intPtr = default(IntPtr);
			return value ^ (nint)intPtr;
		}

		[Token(Token = "0x60000F2")]
		[Address(RVA = "0xBDC71C", Offset = "0xBDC71C", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = 0;\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal::SetEncrypted(&v19 @ stack_-60_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal), encrypted, key);\n\treturnBuffer.fakeValueActive = 0;\n\t*([returnBuffer @ X8 (CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal)+10]) = 0;\n\treturnBuffer.fakeValue = 0;\n\treturnBuffer.currentCryptoKey = 0;\n\tv39 = *([v7 @ SYSREG+28]) != *([v7 @ SYSREG+28]);\n\tif (v39) goto L_002C;\n\treturn &v19 @ stack_-60_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal);\nL_002C:\n\treturnVal2 = 0x1854EB0(&v19 @ stack_-60_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal), encrypted, key, methodInfo, v44, v45, v46, v47, 0, 0, 0, v48, v49, v50, v51, v52);\n\treturn returnVal2;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredDecimal FromEncrypted(decimal encrypted, long key)
		{
			//IL_0024: Expected native int or pointer, but got O
			//IL_0041: Expected native int or pointer, but got O
			//IL_0054: Expected I8, but got I4
			//IL_004f: Expected native int or pointer, but got O
			//IL_0088: Expected O, but got Ref
			ObscuredDecimal obscuredDecimal = default(ObscuredDecimal);
			obscuredDecimal.SetEncrypted(encrypted, key);
			ObscuredDecimal obscuredDecimal2 = default(ObscuredDecimal);
			((ObscuredDecimal*)(nint)obscuredDecimal2)->fakeValueActive = false;
			_ = 0;
			((ObscuredDecimal*)(nint)obscuredDecimal2)->fakeValue = default(decimal);
			((ObscuredDecimal*)(nint)obscuredDecimal2)->currentCryptoKey = 0L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ SYSREG+28]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ SYSREG+28]");
			if (num == 0)
			{
				return (ObscuredDecimal)(&obscuredDecimal);
			}
			Il2CppRuntime.Boundary("SYSTEM_API:__stack_chk_fail", "Method not found @1854EB0 (native __stack_chk_fail)");
			ObscuredDecimal result = default(ObscuredDecimal);
			return result;
		}

		[Token(Token = "0x60000F3")]
		[Address(RVA = "0xBDC6D8", Offset = "0xBDC6D8", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\treturn v2;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static long GenerateKey()
		{
			//IL_000e: Expected I8, but got I4
			int num = RandomUtils.GenerateIntKey();
			return num;
		}

		[Token(Token = "0x60000F4")]
		[Address(RVA = "0xBDC7E0", Offset = "0xBDC7E0", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([key @ X1 (System.Int64&)]) = this.currentCryptoKey;\n\treturn this.hiddenValue;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe decimal GetEncrypted(out long key)
		{
			key = default(long);
			ref long reference = ref *(long*)currentCryptoKey;
			return (decimal)hiddenValue;
		}

		[Token(Token = "0x60000F5")]
		[Address(RVA = "0xBDC798", Offset = "0xBDC798", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.hiddenValue = encrypted;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal)+10]) = key;\n\tthis.inited = 1;\n\tthis.currentCryptoKey = methodInfo;\n\tv13 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tthis.fakeValueActive = 0;\n\tv15 = v13 == 0;\n\tif (v15) goto L_0019;\n\tv17 = CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal::InternalDecrypt(this);\n\tthis.fakeValue = v17;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal)+28]) = encrypted;\n\tthis.fakeValueActive = 1;\nL_0019:\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetEncrypted(decimal encrypted, long key)
		{
			//IL_0024: Expected I8, but got I
			hiddenValue = (ACTkByte16)encrypted;
			inited = true;
			IntPtr intPtr = default(IntPtr);
			currentCryptoKey = (long)intPtr;
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			fakeValueActive = false;
			if (existsAndIsRunning)
			{
				decimal num = InternalDecrypt();
				fakeValue = num;
				fakeValueActive = true;
			}
		}

		[Token(Token = "0x60000F6")]
		[Address(RVA = "0xBDC95C", Offset = "0xBDC95C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal::InternalDecrypt(this);\n\treturn returnVal1;\n")]
		public decimal GetDecrypted()
		{
			return InternalDecrypt();
		}

		[Token(Token = "0x60000F7")]
		[Address(RVA = "0xBDC960", Offset = "0xBDC960", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal::InternalDecrypt(this);\n\tv14 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tv16 = v10 ^ v14;\n\tv17 = methodInfo ^ v14;\n\tthis.currentCryptoKey = v14;\n\tthis.hiddenValue = v16;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal)+10]) = v17;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RandomizeCryptoKey()
		{
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Expected I4, but got Unknown
			//IL_003d: Expected I8, but got I4
			//IL_0047: Expected O, but got I4
			decimal num = InternalDecrypt();
			int num2 = RandomUtils.GenerateIntKey();
			int num3 = num ^ num2;
			IntPtr intPtr = default(IntPtr);
			int num4 = (int)((nint)intPtr ^ num2);
			currentCryptoKey = num2;
			hiddenValue = (ACTkByte16)num3;
		}

		[Token(Token = "0x60000F8")]
		[Address(RVA = "0xBDC6EC", Offset = "0xBDC6EC", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = value ^ methodInfo;\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static ACTkByte16 InternalEncrypt(decimal value, long key)
		{
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Expected O, but got Unknown
			IntPtr intPtr = default(IntPtr);
			return (ACTkByte16)(value ^ (nint)intPtr);
		}

		[Token(Token = "0x60000F9")]
		[Address(RVA = "0xBDC7FC", Offset = "0xBDC7FC", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = System.Decimal;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv42 = Il2CppMethodInfo;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A3545E]) = v38;\nL_0016:\n\tv40 = ~v35.inited;\n\tif (v40) goto L_0053;\n\tv97 = v35.currentCryptoKey ^ v35.hiddenValue;\n\tv48 = v35.currentCryptoKey ^ *([v35 @ X0_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal)+10]);\n\tv49 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv52 = v49 == 0;\n\tif (v52) goto L_0075;\n\tv61 = ~v35.fakeValueActive;\n\tif (v61) goto L_0075;\n\tgoto L_0034;\n\tv134 = \"il2cpp_codegen_runtime_class_init\"(v113, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0034:\n\tv86 = System.Decimal::op_Inequality(v97, v48);\n\tv89 = v86 == 0;\n\tif (v89) goto L_0075;\n\tgoto L_0048;\n\tv146 = 0xB348B0(v141, v73, v71, v69, v67, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0048:\n\tgoto L_0051;\n\tv154 = 0xB348B0(v149, v73, v71, v69, v67, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0051:\n\tv87 = CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector>::OnCheatingDetected(v132.<Instance>k__BackingField);\n\tgoto L_0075;\nL_0053:\n\tv50 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tv35.currentCryptoKey = v50;\n\tgoto L_0061;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v56, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv107 = System.Decimal;\nL_0061:\n\t// 97 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv35.fakeValue = 0;\n\t*([v35 @ X0_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal)+28]) = 0;\n\tv35.fakeValueActive = 0;\n\tv35.inited = 1;\n\tv63 = v27 ^ v82.Zero;\n\tv35.hiddenValue = v63;\nL_0075:\n\treturn v97;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private decimal InternalDecrypt()
		{
			//IL_00cd: Expected I8, but got I4
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			//IL_013b: Expected I4, but got Unknown
			//IL_0145: Expected O, but got I4
			//IL_014e: Expected I4, but got O
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected I4, but got Unknown
			//IL_002d: Expected I4, but got I8
			//IL_00f2: Expected O, but got I4
			//IL_0080: Expected O, but got I4
			//IL_0080: Expected O, but got I4
			int num;
			if (inited)
			{
				num = (int)(currentCryptoKey ^ hiddenValue);
				long num2 = currentCryptoKey;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ X0_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal)+10]");
				int num3 = (int)(num2 ^ 0);
				if (ObscuredCheatingDetector.ExistsAndIsRunning && fakeValueActive && (decimal)num != (decimal)num3)
				{
					KeepAliveBehaviour<ObscuredCheatingDetector>.Instance.OnCheatingDetected();
				}
			}
			else
			{
				int num4 = RandomUtils.GenerateIntKey();
				currentCryptoKey = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
				fakeValue = default(decimal);
				_ = 0;
				fakeValueActive = false;
				inited = true;
				object obj = default(object);
				int num5 = (nint)obj ^ 0m;
				hiddenValue = (ACTkByte16)num5;
				num = 0;
			}
			return num;
		}

		[Token(Token = "0x60000FA")]
		[Address(RVA = "0xBDC9B4", Offset = "0xBDC9B4", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnBuffer.fakeValueActive = 0;\n\t*([returnBuffer @ X8 (CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal)+10]) = 0;\n\treturnBuffer.fakeValue = 0;\n\treturnBuffer.currentCryptoKey = 0;\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal::.ctor(returnBuffer, value);\n\treturn returnBuffer;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static implicit operator ObscuredDecimal(decimal value)
		{
			//IL_0009: Expected native int or pointer, but got O
			//IL_0026: Expected native int or pointer, but got O
			//IL_0039: Expected I8, but got I4
			//IL_0034: Expected native int or pointer, but got O
			//IL_0041: Expected native int or pointer, but got O
			ObscuredDecimal obscuredDecimal = default(ObscuredDecimal);
			((ObscuredDecimal*)(nint)obscuredDecimal)->fakeValueActive = false;
			_ = 0;
			((ObscuredDecimal*)(nint)obscuredDecimal)->fakeValue = default(decimal);
			((ObscuredDecimal*)(nint)obscuredDecimal)->currentCryptoKey = 0L;
			*(ObscuredDecimal*)(nint)obscuredDecimal = new ObscuredDecimal(value);
			return obscuredDecimal;
		}

		[Token(Token = "0x60000FB")]
		[Address(RVA = "0xBDC9D4", Offset = "0xBDC9D4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal::InternalDecrypt(value);\n\treturn returnVal1;\n")]
		public unsafe static implicit operator decimal(ObscuredDecimal value)
		{
			return ((ObscuredDecimal*)value)->InternalDecrypt();
		}

		[Token(Token = "0x60000FC")]
		[Address(RVA = "0xBDC9D8", Offset = "0xBDC9D8", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv30 = System.Decimal;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 1;\n\t*([1A3545F]) = v49;\nL_001B:\n\tv51 = f.currentCryptoKey;\n\tv55 = CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat::InternalDecrypt(&v51 @ V0_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat));\n\tgoto L_0029;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v56, methodInfo, v33, v34, v35, v36, v37, v38, v55, v40, v41, v42, v43, v44, v45, v46);\nL_0029:\n\tv65 = System.Decimal::op_Explicit(v55);\n\tv70 = 0;\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal::.ctor(&v70 @ stack_-80_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal), v65);\n\treturnBuffer.fakeValueActive = 0;\n\t*([returnBuffer @ X8 (CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal)+10]) = 0;\n\treturnBuffer.fakeValue = 0;\n\treturnBuffer.currentCryptoKey = 0;\n\tv91 = *([v15 @ SYSREG+28]) != *([v15 @ SYSREG+28]);\n\tif (v91) goto L_0053;\n\treturn &v70 @ stack_-80_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal);\nL_0053:\n\treturnVal2 = 0x1854EB0(&v70 @ stack_-80_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal), v65, methodInfo, methodInfo, v35, v36, v37, v38, 0, 0, 0, v42, v43, v44, v45, v46);\n\treturn returnVal2;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static explicit operator ObscuredDecimal(ObscuredFloat f)
		{
			//IL_00bc: Expected O, but got I4
			//IL_0037: Expected native int or pointer, but got O
			//IL_0054: Expected native int or pointer, but got O
			//IL_0067: Expected I8, but got I4
			//IL_0062: Expected native int or pointer, but got O
			//IL_009b: Expected O, but got Ref
			float num = ((ObscuredFloat)f.currentCryptoKey).InternalDecrypt();
			decimal value = (decimal)num;
			ObscuredDecimal obscuredDecimal = default(ObscuredDecimal);
			obscuredDecimal = new ObscuredDecimal(value);
			ObscuredDecimal obscuredDecimal2 = default(ObscuredDecimal);
			((ObscuredDecimal*)(nint)obscuredDecimal2)->fakeValueActive = false;
			_ = 0;
			((ObscuredDecimal*)(nint)obscuredDecimal2)->fakeValue = default(decimal);
			((ObscuredDecimal*)(nint)obscuredDecimal2)->currentCryptoKey = 0L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ SYSREG+28]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ SYSREG+28]");
			if (num2 == 0)
			{
				return (ObscuredDecimal)(&obscuredDecimal);
			}
			Il2CppRuntime.Boundary("SYSTEM_API:__stack_chk_fail", "Method not found @1854EB0 (native __stack_chk_fail)");
			ObscuredDecimal result = default(ObscuredDecimal);
			return result;
		}

		[Token(Token = "0x60000FD")]
		[Address(RVA = "0xBDCAD0", Offset = "0xBDCAD0", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv28 = System.Decimal;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 1;\n\t*([1A35460]) = v47;\nL_001C:\n\tv51 = input.currentCryptoKey;\n\tgoto L_0028;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v52, methodInfo, v31, v32, v33, v34, v35, v36, v49, v51, v48, v40, v41, v42, v43, v44);\n\tv62 = System.Decimal;\nL_0028:\n\tv63 = *([v61 @ X0_v3 (Il2CppClass<System.Decimal>)+B8]);\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal::Increment(&v51 @ V1_v1 (System.Int64), v63.One);\n\treturnBuffer.fakeValueActive = returnVal1.fakeValueActive;\n\t*([returnBuffer @ X8 (CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal)+10]) = *([returnVal1 @ X0_v5 (CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal)+10]);\n\treturnBuffer.fakeValue = returnVal1.fakeValue;\n\treturnBuffer.currentCryptoKey = returnVal1.currentCryptoKey;\n\tv107 = *([v13 @ SYSREG+28]) != *([v13 @ SYSREG+28]);\n\tif (v107) goto L_0061;\n\treturn returnVal1;\nL_0061:\n\treturnVal2 = 0x1854EB0(returnVal1, v63.One, *([v63 @ X8_v6 (Il2CppStaticFields<System.Decimal>)+18]), v32, v33, v34, v35, v36, returnVal1.fakeValue, *([returnVal1 @ X0_v5 (CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal)+10]), returnVal1.currentCryptoKey, v40, v41, v42, v43, v44);\n\treturn returnVal2;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredDecimal operator ++(ObscuredDecimal input)
		{
			//IL_0039: Expected I, but got O
			//IL_0047: Expected I, but got O
			//IL_0055: Expected O, but got Ref
			//IL_0066: Expected native int or pointer, but got O
			//IL_0085: Expected native int or pointer, but got O
			//IL_0097: Expected native int or pointer, but got O
			long num = input.currentCryptoKey;
			nint num2 = (nint)typeof(decimal);
			nint num3 = (nint)0;
			ObscuredDecimal result = Increment((ObscuredDecimal)(&num), 1m);
			ObscuredDecimal obscuredDecimal = default(ObscuredDecimal);
			((ObscuredDecimal*)(nint)obscuredDecimal)->fakeValueActive = result.fakeValueActive;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal1 @ X0_v5 (CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal)+10]");
			_ = 0;
			((ObscuredDecimal*)(nint)obscuredDecimal)->fakeValue = result.fakeValue;
			((ObscuredDecimal*)(nint)obscuredDecimal)->currentCryptoKey = result.currentCryptoKey;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ SYSREG+28]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ SYSREG+28]");
			if (num4 == 0)
			{
				return result;
			}
			Il2CppRuntime.Boundary("SYSTEM_API:__stack_chk_fail", "Method not found @1854EB0 (native __stack_chk_fail)");
			ObscuredDecimal result2 = default(ObscuredDecimal);
			return result2;
		}

		[Token(Token = "0x60000FE")]
		[Address(RVA = "0xBDCC9C", Offset = "0xBDCC9C", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv28 = System.Decimal;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 1;\n\t*([1A35461]) = v47;\nL_001C:\n\tv51 = input.currentCryptoKey;\n\tgoto L_0028;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v52, methodInfo, v31, v32, v33, v34, v35, v36, v49, v51, v48, v40, v41, v42, v43, v44);\n\tv62 = System.Decimal;\nL_0028:\n\tv63 = *([v61 @ X0_v3 (Il2CppClass<System.Decimal>)+B8]);\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal::Increment(&v51 @ V1_v1 (System.Int64), v63.MinusOne);\n\treturnBuffer.fakeValueActive = returnVal1.fakeValueActive;\n\t*([returnBuffer @ X8 (CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal)+10]) = *([returnVal1 @ X0_v5 (CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal)+10]);\n\treturnBuffer.fakeValue = returnVal1.fakeValue;\n\treturnBuffer.currentCryptoKey = returnVal1.currentCryptoKey;\n\tv107 = *([v13 @ SYSREG+28]) != *([v13 @ SYSREG+28]);\n\tif (v107) goto L_0061;\n\treturn returnVal1;\nL_0061:\n\treturnVal2 = 0x1854EB0(returnVal1, v63.MinusOne, *([v63 @ X8_v6 (Il2CppStaticFields<System.Decimal>)+28]), v32, v33, v34, v35, v36, returnVal1.fakeValue, *([returnVal1 @ X0_v5 (CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal)+10]), returnVal1.currentCryptoKey, v40, v41, v42, v43, v44);\n\treturn returnVal2;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredDecimal operator --(ObscuredDecimal input)
		{
			//IL_0039: Expected I, but got O
			//IL_0047: Expected I, but got O
			//IL_0055: Expected O, but got Ref
			//IL_0066: Expected native int or pointer, but got O
			//IL_0085: Expected native int or pointer, but got O
			//IL_0097: Expected native int or pointer, but got O
			long num = input.currentCryptoKey;
			nint num2 = (nint)typeof(decimal);
			nint num3 = (nint)0;
			ObscuredDecimal result = Increment((ObscuredDecimal)(&num), -1m);
			ObscuredDecimal obscuredDecimal = default(ObscuredDecimal);
			((ObscuredDecimal*)(nint)obscuredDecimal)->fakeValueActive = result.fakeValueActive;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal1 @ X0_v5 (CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal)+10]");
			_ = 0;
			((ObscuredDecimal*)(nint)obscuredDecimal)->fakeValue = result.fakeValue;
			((ObscuredDecimal*)(nint)obscuredDecimal)->currentCryptoKey = result.currentCryptoKey;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ SYSREG+28]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ SYSREG+28]");
			if (num4 == 0)
			{
				return result;
			}
			Il2CppRuntime.Boundary("SYSTEM_API:__stack_chk_fail", "Method not found @1854EB0 (native __stack_chk_fail)");
			ObscuredDecimal result2 = default(ObscuredDecimal);
			return result2;
		}

		[Token(Token = "0x60000FF")]
		[Address(RVA = "0xBDCBB8", Offset = "0xBDCBB8", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv30 = System.Decimal;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, increment, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 1;\n\t*([1A35462]) = v47;\nL_001A:\n\tv49 = CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal::InternalDecrypt(input);\n\tgoto L_0028;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v51, increment, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0028:\n\tv63 = System.Decimal::op_Addition(v49, increment);\n\tv67 = v63 ^ input.currentCryptoKey;\n\tv68 = increment ^ input.currentCryptoKey;\n\tinput.hiddenValue = v67;\n\t*([input @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal)+10]) = v68;\n\treturnVal1 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv71 = returnVal1 & 1;\n\tv72 = v71 == 0;\n\tif (v72) goto L_FFFFFFFF;\n\tinput.fakeValue = v63;\n\t*([input @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal)+28]) = increment;\n\tgoto L_003A;\nL_003A:\n\tinput.fakeValueActive = v75;\n\t*([returnBuffer @ X8 (CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal)+10]) = *([input @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal)+10]);\n\treturnBuffer.fakeValue = input.fakeValue;\n\treturnBuffer.fakeValueActive = input.fakeValueActive;\n\treturnBuffer.currentCryptoKey = input.currentCryptoKey;\n\treturn returnVal1;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe static ObscuredDecimal Increment(ObscuredDecimal input, decimal increment)
		{
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Expected I4, but got Unknown
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Expected I4, but got Unknown
			//IL_0047: Expected O, but got I4
			//IL_0042: Expected native int or pointer, but got O
			//IL_0055: Expected O, but got I4
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Expected I4, but got Unknown
			//IL_00cd: Expected native int or pointer, but got O
			//IL_00ec: Expected native int or pointer, but got O
			//IL_00fe: Expected native int or pointer, but got O
			//IL_0110: Expected native int or pointer, but got O
			//IL_008d: Expected native int or pointer, but got O
			decimal num = ((ObscuredDecimal*)input)->InternalDecrypt();
			decimal num2 = num + increment;
			int num3 = num2 ^ input.currentCryptoKey;
			int num4 = increment ^ input.currentCryptoKey;
			((ObscuredDecimal*)(nint)input)->hiddenValue = (ACTkByte16)num3;
			ObscuredDecimal obscuredDecimal = (ObscuredDecimal)ObscuredCheatingDetector.ExistsAndIsRunning;
			bool flag;
			if ((obscuredDecimal & 1) != 0)
			{
				((ObscuredDecimal*)(nint)input)->fakeValue = num2;
				flag = true;
			}
			else
			{
				flag = false;
			}
			((ObscuredDecimal*)(nint)input)->fakeValueActive = flag;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [input @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal)+10]");
			_ = 0;
			ObscuredDecimal obscuredDecimal2 = default(ObscuredDecimal);
			((ObscuredDecimal*)(nint)obscuredDecimal2)->fakeValue = input.fakeValue;
			((ObscuredDecimal*)(nint)obscuredDecimal2)->fakeValueActive = input.fakeValueActive;
			((ObscuredDecimal*)(nint)obscuredDecimal2)->currentCryptoKey = input.currentCryptoKey;
			return obscuredDecimal;
		}

		[Token(Token = "0x6000100")]
		[Address(RVA = "0xBDCD84", Offset = "0xBDCD84", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = System.Decimal;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 1;\n\t*([1A35463]) = v43;\nL_0018:\n\tv45 = CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal::InternalDecrypt(this);\n\tgoto L_0024;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0024:\n\treturnVal1 = System.Decimal::GetHashCode(&v45 @ X0_v3 (System.Decimal));\n\tv69 = *([v11 @ SYSREG+28]) != *([v11 @ SYSREG+28]);\n\tif (v69) goto L_0039;\n\treturn returnVal1;\nL_0039:\n\treturnVal2 = 0x1854EB0(returnVal1, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\treturn returnVal2;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override int GetHashCode()
		{
			int hashCode = InternalDecrypt().GetHashCode();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ SYSREG+28]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ SYSREG+28]");
			if (num == 0)
			{
				return hashCode;
			}
			Il2CppRuntime.Boundary("SYSTEM_API:__stack_chk_fail", "Method not found @1854EB0 (native __stack_chk_fail)");
			int result = default(int);
			return result;
		}

		[Token(Token = "0x6000101")]
		[Address(RVA = "0xBDCE20", Offset = "0xBDCE20", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = System.Decimal;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 1;\n\t*([1A35464]) = v43;\nL_0018:\n\tv45 = CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal::InternalDecrypt(this);\n\tgoto L_0024;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0024:\n\treturnVal1 = System.Decimal::ToString(&v45 @ X0_v3 (System.Decimal));\n\tv69 = *([v11 @ SYSREG+28]) != *([v11 @ SYSREG+28]);\n\tif (v69) goto L_0039;\n\treturn returnVal1;\nL_0039:\n\treturnVal2 = 0x1854EB0(returnVal1, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\treturn returnVal2;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			string result = InternalDecrypt().ToString();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ SYSREG+28]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ SYSREG+28]");
			if (num == 0)
			{
				return result;
			}
			Il2CppRuntime.Boundary("SYSTEM_API:__stack_chk_fail", "Method not found @1854EB0 (native __stack_chk_fail)");
			string result2 = default(string);
			return result2;
		}

		[Token(Token = "0x6000102")]
		[Address(RVA = "0xBDCEBC", Offset = "0xBDCEBC", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv28 = System.Decimal;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, format, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 1;\n\t*([1A35465]) = v46;\nL_001A:\n\tv48 = CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal::InternalDecrypt(this);\n\tgoto L_0027;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v50, format, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0027:\n\treturnVal1 = System.Decimal::ToString(&v48 @ X0_v3 (System.Decimal), format);\n\tv73 = *([v13 @ SYSREG+28]) != *([v13 @ SYSREG+28]);\n\tif (v73) goto L_003D;\n\treturn returnVal1;\nL_003D:\n\treturnVal2 = 0x1854EB0(returnVal1, format, 0, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\treturn returnVal2;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string ToString(string format)
		{
			string result = InternalDecrypt().ToString(format);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ SYSREG+28]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ SYSREG+28]");
			if (num == 0)
			{
				return result;
			}
			Il2CppRuntime.Boundary("SYSTEM_API:__stack_chk_fail", "Method not found @1854EB0 (native __stack_chk_fail)");
			string result2 = default(string);
			return result2;
		}

		[Token(Token = "0x6000103")]
		[Address(RVA = "0xBDCF60", Offset = "0xBDCF60", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv28 = System.Decimal;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, provider, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 1;\n\t*([1A35466]) = v46;\nL_001A:\n\tv48 = CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal::InternalDecrypt(this);\n\tgoto L_0027;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v50, provider, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0027:\n\treturnVal1 = System.Decimal::ToString(&v48 @ X0_v3 (System.Decimal), provider);\n\tv73 = *([v13 @ SYSREG+28]) != *([v13 @ SYSREG+28]);\n\tif (v73) goto L_003D;\n\treturn returnVal1;\nL_003D:\n\treturnVal2 = 0x1854EB0(returnVal1, provider, 0, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\treturn returnVal2;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string ToString(IFormatProvider provider)
		{
			string result = InternalDecrypt().ToString(provider);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ SYSREG+28]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ SYSREG+28]");
			if (num == 0)
			{
				return result;
			}
			Il2CppRuntime.Boundary("SYSTEM_API:__stack_chk_fail", "Method not found @1854EB0 (native __stack_chk_fail)");
			string result2 = default(string);
			return result2;
		}

		[Token(Token = "0x6000104")]
		[Address(RVA = "0xBDD004", Offset = "0xBDD004", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv32 = System.Decimal;\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, format, provider, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 1;\n\t*([1A35467]) = v49;\nL_001C:\n\tv51 = CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal::InternalDecrypt(this);\n\tgoto L_002A;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v53, format, provider, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_002A:\n\treturnVal1 = System.Decimal::ToString(&v51 @ X0_v3 (System.Decimal), format, provider);\n\tv77 = *([v15 @ SYSREG+28]) != *([v15 @ SYSREG+28]);\n\tif (v77) goto L_0041;\n\treturn returnVal1;\nL_0041:\n\treturnVal2 = 0x1854EB0(returnVal1, format, provider, 0, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\treturn returnVal2;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string ToString(string format, IFormatProvider provider)
		{
			string result = InternalDecrypt().ToString(format, provider);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ SYSREG+28]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ SYSREG+28]");
			if (num == 0)
			{
				return result;
			}
			Il2CppRuntime.Boundary("SYSTEM_API:__stack_chk_fail", "Method not found @1854EB0 (native __stack_chk_fail)");
			string result2 = default(string);
			return result2;
		}

		[Token(Token = "0x6000105")]
		[Address(RVA = "0xBDD0B8", Offset = "0xBDD0B8", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, obj, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A35468]) = v42;\nL_0016:\n\tv43 = obj == 0;\n\tif (v43) goto L_FFFFFFFF;\n\tv52 = *([obj @ X1 (System.Object)]) == CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal;\n\tif (v52) goto L_0029;\n\tgoto L_0040;\nL_0029:\n\tv78 = \"il2cpp_vm_object_unbox\"(obj, obj, methodInfo, v27, v28, v29, v30, v31, v95, v33, v97, v35, v36, v37, v38, v39);\n\tv33 = *([v78 @ X0_v8]);\n\tv108 = CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal::Equals(this, &v33 @ V1);\nL_0040:\n\tv123 = *([v11 @ SYSREG+28]) != *([v11 @ SYSREG+28]);\n\tif (v123) goto L_004A;\n\treturn v108;\nL_004A:\n\treturnVal2 = 0x1854EB0(v108, &v33 @ V1, methodInfo, v27, v28, v29, v30, v31, *([v78 @ X0_v8+20]), v33, *([v78 @ X0_v8+10]), v35, v36, v37, v38, v39);\n\treturn returnVal2;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override bool Equals(object obj)
		{
			//IL_005b: Expected O, but got Ref
			bool result;
			if (obj == null || (object)obj.GetType() != typeof(ObscuredDecimal))
			{
				result = false;
			}
			else
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				object obj3 = default(object);
				object obj2 = obj3;
				result = Equals((ObscuredDecimal)(&obj2));
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ SYSREG+28]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ SYSREG+28]");
			if (num == 0)
			{
				return result;
			}
			Il2CppRuntime.Boundary("SYSTEM_API:__stack_chk_fail", "Method not found @1854EB0 (native __stack_chk_fail)");
			bool result2 = default(bool);
			return result2;
		}

		[Token(Token = "0x6000106")]
		[Address(RVA = "0xBDD178", Offset = "0xBDD178", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv28 = System.Decimal;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, obj, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 1;\n\t*([1A35469]) = v46;\nL_001A:\n\tv48 = CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal::InternalDecrypt(obj);\n\tv48 = CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal::InternalDecrypt(this);\n\tgoto L_002B;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v54, obj, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_002B:\n\tv65 = System.Decimal::Equals(&v48 @ X0_v3 (System.Decimal), v48);\n\tv77 = *([v13 @ SYSREG+28]) != *([v13 @ SYSREG+28]);\n\tif (v77) goto L_0042;\n\treturn v65;\nL_0042:\n\treturnVal2 = 0x1854EB0(v65, v48, obj, 0, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\treturn returnVal2;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe bool Equals(ObscuredDecimal obj)
		{
			decimal num = ((ObscuredDecimal*)obj)->InternalDecrypt();
			num = InternalDecrypt();
			bool result = num.Equals(num);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ SYSREG+28]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ SYSREG+28]");
			if (num2 == 0)
			{
				return result;
			}
			Il2CppRuntime.Boundary("SYSTEM_API:__stack_chk_fail", "Method not found @1854EB0 (native __stack_chk_fail)");
			bool result2 = default(bool);
			return result2;
		}

		[Token(Token = "0x6000107")]
		[Address(RVA = "0xBDD230", Offset = "0xBDD230", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv28 = System.Decimal;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, other, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 1;\n\t*([1A3546A]) = v46;\nL_001A:\n\tv48 = CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal::InternalDecrypt(this);\n\tv52 = CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal::InternalDecrypt(other);\n\tgoto L_002B;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v54, other, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_002B:\n\treturnVal1 = System.Decimal::CompareTo(&v48 @ X0_v3 (System.Decimal), v52);\n\tv77 = *([v13 @ SYSREG+28]) != *([v13 @ SYSREG+28]);\n\tif (v77) goto L_0041;\n\treturn returnVal1;\nL_0041:\n\treturnVal2 = 0x1854EB0(returnVal1, v52, other, 0, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\treturn returnVal2;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe int CompareTo(ObscuredDecimal other)
		{
			decimal num = InternalDecrypt();
			decimal value = ((ObscuredDecimal*)other)->InternalDecrypt();
			int result = num.CompareTo(value);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ SYSREG+28]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ SYSREG+28]");
			if (num2 == 0)
			{
				return result;
			}
			Il2CppRuntime.Boundary("SYSTEM_API:__stack_chk_fail", "Method not found @1854EB0 (native __stack_chk_fail)");
			int result2 = default(int);
			return result2;
		}

		[Token(Token = "0x6000108")]
		[Address(RVA = "0xBDD2E4", Offset = "0xBDD2E4", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv32 = System.Decimal;\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, other, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 1;\n\t*([1A3546B]) = v49;\nL_001C:\n\tv51 = CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal::InternalDecrypt(this);\n\tgoto L_002A;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v53, other, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_002A:\n\treturnVal1 = System.Decimal::CompareTo(&v51 @ X0_v3 (System.Decimal), other);\n\tv77 = *([v15 @ SYSREG+28]) != *([v15 @ SYSREG+28]);\n\tif (v77) goto L_0041;\n\treturn returnVal1;\nL_0041:\n\treturnVal2 = 0x1854EB0(returnVal1, other, methodInfo, 0, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\treturn returnVal2;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int CompareTo(decimal other)
		{
			int result = InternalDecrypt().CompareTo(other);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ SYSREG+28]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ SYSREG+28]");
			if (num == 0)
			{
				return result;
			}
			Il2CppRuntime.Boundary("SYSTEM_API:__stack_chk_fail", "Method not found @1854EB0 (native __stack_chk_fail)");
			int result2 = default(int);
			return result2;
		}

		[Token(Token = "0x6000109")]
		[Address(RVA = "0xBDD398", Offset = "0xBDD398", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv28 = System.Decimal;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, obj, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 1;\n\t*([1A3546C]) = v46;\nL_001A:\n\tv48 = CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal::InternalDecrypt(this);\n\tgoto L_0027;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v50, obj, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0027:\n\treturnVal1 = System.Decimal::CompareTo(&v48 @ X0_v3 (System.Decimal), obj);\n\tv73 = *([v13 @ SYSREG+28]) != *([v13 @ SYSREG+28]);\n\tif (v73) goto L_003D;\n\treturn returnVal1;\nL_003D:\n\treturnVal2 = 0x1854EB0(returnVal1, obj, 0, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\treturn returnVal2;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int CompareTo(object obj)
		{
			int result = InternalDecrypt().CompareTo(obj);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ SYSREG+28]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ SYSREG+28]");
			if (num == 0)
			{
				return result;
			}
			Il2CppRuntime.Boundary("SYSTEM_API:__stack_chk_fail", "Method not found @1854EB0 (native __stack_chk_fail)");
			int result2 = default(int);
			return result2;
		}

		[Obsolete("This API is redundant and does not perform any actions. It will be removed in future updates.")]
		[Token(Token = "0x600010A")]
		[Address(RVA = "0xBDD43C", Offset = "0xBDD43C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public static void SetNewCryptoKey(long newKey)
		{
		}

		[Obsolete("This API is redundant and does not perform any actions. It will be removed in future updates.")]
		[Token(Token = "0x600010B")]
		[Address(RVA = "0xBDD440", Offset = "0xBDD440", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void ApplyNewCryptoKey()
		{
		}

		[Obsolete("Please use new Encrypt(value, key) API instead.", true)]
		[Token(Token = "0x600010C")]
		[Address(RVA = "0xBDD444", Offset = "0xBDD444", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static decimal Encrypt(decimal value)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new Decrypt(value, key) API instead.", true)]
		[Token(Token = "0x600010D")]
		[Address(RVA = "0xBDD47C", Offset = "0xBDD47C", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static decimal Decrypt(decimal value)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new FromEncrypted(encrypted, key) API instead.", true)]
		[Token(Token = "0x600010E")]
		[Address(RVA = "0xBDD4B4", Offset = "0xBDD4B4", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ObscuredDecimal FromEncrypted(decimal encrypted)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new GetEncrypted(out key) API instead.", true)]
		[Token(Token = "0x600010F")]
		[Address(RVA = "0xBDD4EC", Offset = "0xBDD4EC", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public decimal GetEncrypted()
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new SetEncrypted(encrypted, key) API instead.", true)]
		[Token(Token = "0x6000110")]
		[Address(RVA = "0xBDD524", Offset = "0xBDD524", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetEncrypted(decimal encrypted)
		{
		}
	}
}
