using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using CodeStage.AntiCheat.Common;
using CodeStage.AntiCheat.Detectors;
using CodeStage.AntiCheat.Utils;
using Cpp2ILInjected;
using UnityEngine;

namespace CodeStage.AntiCheat.ObscuredTypes
{
	[Serializable]
	[Token(Token = "0x2000019")]
	public struct ObscuredLong : IObscuredType, IFormattable, IEquatable<ObscuredLong>, IComparable<ObscuredLong>, IComparable<long>, IComparable
	{
		[SerializeField]
		[Token(Token = "0x400007D")]
		[FieldOffset(Offset = "0x0")]
		public long currentCryptoKey;

		[SerializeField]
		[Token(Token = "0x400007E")]
		[FieldOffset(Offset = "0x8")]
		private long hiddenValue;

		[SerializeField]
		[Token(Token = "0x400007F")]
		[FieldOffset(Offset = "0x10")]
		public bool inited;

		[SerializeField]
		[Token(Token = "0x4000080")]
		[FieldOffset(Offset = "0x18")]
		private long fakeValue;

		[SerializeField]
		[Token(Token = "0x4000081")]
		[FieldOffset(Offset = "0x20")]
		public bool fakeValueActive;

		[Token(Token = "0x600018D")]
		[Address(RVA = "0xBDEEC8", Offset = "0xBDEEC8", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tv12 = v10 ^ value;\n\tthis.currentCryptoKey = v10;\n\tthis.hiddenValue = v12;\n\tv14 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv17 = v14 == 0;\n\tv21 = ~v17;\n\tv22 = ~v21;\n\tif (v22) goto L_FFFFFFFF;\n\tgoto L_001A;\nL_001A:\n\tthis.fakeValueActive = v14;\n\tthis.fakeValue = v25;\n\tthis.inited = 1;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private ObscuredLong(long value)
		{
			//IL_0016: Expected I4, but got I8
			//IL_0020: Expected I8, but got I4
			//IL_002a: Expected I8, but got I4
			//IL_0081: Expected I8, but got I4
			int num = RandomUtils.GenerateIntKey();
			int num2 = (int)(num ^ value);
			currentCryptoKey = num;
			hiddenValue = num2;
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			long num3 = ((!existsAndIsRunning) ? 0 : value);
			fakeValueActive = existsAndIsRunning;
			fakeValue = num3;
			inited = true;
		}

		[Token(Token = "0x600018E")]
		[Address(RVA = "0xBDEF28", Offset = "0xBDEF28", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = key ^ value;\n\treturn returnVal1;\n")]
		public static long Encrypt(long value, long key)
		{
			return key ^ value;
		}

		[Token(Token = "0x600018F")]
		[Address(RVA = "0xBDEF30", Offset = "0xBDEF30", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = key ^ value;\n\treturn returnVal1;\n")]
		public static long Decrypt(long value, long key)
		{
			return key ^ value;
		}

		[Token(Token = "0x6000190")]
		[Address(RVA = "0xBDEF38", Offset = "0xBDEF38", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0;\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredLong::SetEncrypted(&v10 @ stack_-40_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredLong), encrypted, key);\n\treturnBuffer.fakeValueActive = 0;\n\treturnBuffer.currentCryptoKey = 0;\n\treturnBuffer.inited = 0;\n\treturn &v10 @ stack_-40_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredLong);\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredLong FromEncrypted(long encrypted, long key)
		{
			//IL_0024: Expected native int or pointer, but got O
			//IL_0037: Expected I8, but got I4
			//IL_0032: Expected native int or pointer, but got O
			//IL_0040: Expected native int or pointer, but got O
			//IL_004a: Expected O, but got Ref
			ObscuredLong obscuredLong = default(ObscuredLong);
			obscuredLong.SetEncrypted(encrypted, key);
			ObscuredLong obscuredLong2 = default(ObscuredLong);
			((ObscuredLong*)(nint)obscuredLong2)->fakeValueActive = false;
			((ObscuredLong*)(nint)obscuredLong2)->currentCryptoKey = 0L;
			((ObscuredLong*)(nint)obscuredLong2)->inited = false;
			return (ObscuredLong)(&obscuredLong);
		}

		[Token(Token = "0x6000191")]
		[Address(RVA = "0xBDEF14", Offset = "0xBDEF14", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\treturn v2;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static long GenerateKey()
		{
			//IL_000e: Expected I8, but got I4
			int num = RandomUtils.GenerateIntKey();
			return num;
		}

		[Token(Token = "0x6000192")]
		[Address(RVA = "0xBDEFC0", Offset = "0xBDEFC0", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([key @ X1 (System.Int64&)]) = this.currentCryptoKey;\n\treturn this.hiddenValue;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe long GetEncrypted(out long key)
		{
			key = default(long);
			ref long reference = ref *(long*)currentCryptoKey;
			return hiddenValue;
		}

		[Token(Token = "0x6000193")]
		[Address(RVA = "0xBDEF7C", Offset = "0xBDEF7C", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.inited = 1;\n\tthis.currentCryptoKey = key;\n\tthis.hiddenValue = encrypted;\n\tv12 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tthis.fakeValueActive = 0;\n\tv14 = v12 == 0;\n\tif (v14) goto L_0017;\n\tv16 = CodeStage.AntiCheat.ObscuredTypes.ObscuredLong::InternalDecrypt(this);\n\tthis.fakeValue = v16;\n\tthis.fakeValueActive = 1;\nL_0017:\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetEncrypted(long encrypted, long key)
		{
			inited = true;
			currentCryptoKey = key;
			hiddenValue = encrypted;
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			fakeValueActive = false;
			if (existsAndIsRunning)
			{
				long num = InternalDecrypt();
				fakeValue = num;
				fakeValueActive = true;
			}
		}

		[Token(Token = "0x6000194")]
		[Address(RVA = "0xBDF0AC", Offset = "0xBDF0AC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredLong::InternalDecrypt(this);\n\treturn returnVal1;\n")]
		public long GetDecrypted()
		{
			return InternalDecrypt();
		}

		[Token(Token = "0x6000195")]
		[Address(RVA = "0xBDF0B0", Offset = "0xBDF0B0", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = CodeStage.AntiCheat.ObscuredTypes.ObscuredLong::InternalDecrypt(this);\n\tv11 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tv13 = v8 ^ v11;\n\tthis.currentCryptoKey = v11;\n\tthis.hiddenValue = v13;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RandomizeCryptoKey()
		{
			//IL_002f: Expected I8, but got I4
			long num = InternalDecrypt();
			int num2 = RandomUtils.GenerateIntKey();
			long num3 = num ^ num2;
			currentCryptoKey = num2;
			hiddenValue = num3;
		}

		[Token(Token = "0x6000196")]
		[Address(RVA = "0xBDEFD0", Offset = "0xBDEFD0", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A35473]) = v33;\nL_0011:\n\tv35 = ~v31.inited;\n\tif (v35) goto L_0044;\n\tv84 = v31.currentCryptoKey ^ v31.hiddenValue;\n\tv40 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv43 = v40 == 0;\n\tif (v43) goto L_0052;\n\tv48 = ~v31.fakeValueActive;\n\tif (v48) goto L_0052;\n\tv65 = v84 == v31.fakeValue;\n\tif (v65) goto L_0052;\n\tgoto L_0039;\n\tv116 = 0xB348B0(v111, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0039:\n\tgoto L_0042;\n\tv124 = 0xB348B0(v119, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0042:\n\tv78 = CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector>::OnCheatingDetected(v106.<Instance>k__BackingField);\n\tgoto L_0052;\nL_0044:\n\tv41 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tv31.fakeValue = 0;\n\tv31.fakeValueActive = 0;\n\tv31.currentCryptoKey = v41;\n\tv31.hiddenValue = v41;\n\tv31.inited = 1;\nL_0052:\n\treturn v84;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private long InternalDecrypt()
		{
			//IL_00a2: Expected I8, but got I4
			//IL_00b7: Expected I8, but got I4
			//IL_00c1: Expected I8, but got I4
			//IL_00fa: Expected I8, but got I4
			//IL_0016: Expected I4, but got I8
			int num;
			if (inited)
			{
				num = (int)(currentCryptoKey ^ hiddenValue);
				if (ObscuredCheatingDetector.ExistsAndIsRunning && fakeValueActive && num != fakeValue)
				{
					KeepAliveBehaviour<ObscuredCheatingDetector>.Instance.OnCheatingDetected();
				}
			}
			else
			{
				int num2 = RandomUtils.GenerateIntKey();
				fakeValue = 0L;
				fakeValueActive = false;
				currentCryptoKey = num2;
				hiddenValue = num2;
				inited = true;
				num = 0;
			}
			return num;
		}

		[Token(Token = "0x6000197")]
		[Address(RVA = "0xBDF0E0", Offset = "0xBDF0E0", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnBuffer.fakeValueActive = 0;\n\treturnBuffer.currentCryptoKey = 0;\n\treturnBuffer.inited = 0;\n\tv11 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tv13 = v11 ^ value;\n\treturnBuffer.currentCryptoKey = v11;\n\treturnBuffer.hiddenValue = v13;\n\treturnVal1 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv16 = returnVal1 & 1;\n\tv18 = v16 == 0;\n\tv22 = ~v18;\n\tv23 = ~v22;\n\tif (v23) goto L_FFFFFFFF;\n\tgoto L_001E;\nL_001E:\n\treturnBuffer.fakeValueActive = v16;\n\treturnBuffer.fakeValue = v26;\n\treturnBuffer.inited = 1;\n\treturn returnVal1;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static implicit operator ObscuredLong(long value)
		{
			//IL_0009: Expected native int or pointer, but got O
			//IL_001c: Expected I8, but got I4
			//IL_0017: Expected native int or pointer, but got O
			//IL_0025: Expected native int or pointer, but got O
			//IL_0040: Expected I4, but got I8
			//IL_004d: Expected I8, but got I4
			//IL_0048: Expected native int or pointer, but got O
			//IL_005a: Expected I8, but got I4
			//IL_0055: Expected native int or pointer, but got O
			//IL_0063: Expected O, but got I4
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Expected I4, but got Unknown
			//IL_00bf: Expected I8, but got I4
			//IL_00cc: Expected native int or pointer, but got O
			//IL_00d9: Expected native int or pointer, but got O
			//IL_00e7: Expected native int or pointer, but got O
			ObscuredLong obscuredLong = default(ObscuredLong);
			((ObscuredLong*)(nint)obscuredLong)->fakeValueActive = false;
			((ObscuredLong*)(nint)obscuredLong)->currentCryptoKey = 0L;
			((ObscuredLong*)(nint)obscuredLong)->inited = false;
			int num = RandomUtils.GenerateIntKey();
			int num2 = (int)(num ^ value);
			((ObscuredLong*)(nint)obscuredLong)->currentCryptoKey = num;
			((ObscuredLong*)(nint)obscuredLong)->hiddenValue = num2;
			ObscuredLong obscuredLong2 = (ObscuredLong)ObscuredCheatingDetector.ExistsAndIsRunning;
			int num3 = (int)(obscuredLong2 & 1);
			long num4 = ((num3 == 0) ? 0 : value);
			((ObscuredLong*)(nint)obscuredLong)->fakeValueActive = (byte)num3 != 0;
			((ObscuredLong*)(nint)obscuredLong)->fakeValue = num4;
			((ObscuredLong*)(nint)obscuredLong)->inited = true;
			return obscuredLong2;
		}

		[Token(Token = "0x6000198")]
		[Address(RVA = "0xBDF138", Offset = "0xBDF138", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredLong::InternalDecrypt(value);\n\treturn returnVal1;\n")]
		public unsafe static implicit operator long(ObscuredLong value)
		{
			return ((ObscuredLong*)value)->InternalDecrypt();
		}

		[Token(Token = "0x6000199")]
		[Address(RVA = "0xBDF13C", Offset = "0xBDF13C", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = input.currentCryptoKey;\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredLong::Increment(&v8 @ V1_v1 (System.Int64), 1);\n\treturnBuffer.fakeValueActive = returnVal1.fakeValueActive;\n\treturnBuffer.currentCryptoKey = returnVal1.currentCryptoKey;\n\treturnBuffer.inited = returnVal1.inited;\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredLong operator ++(ObscuredLong input)
		{
			//IL_001b: Expected O, but got Ref
			//IL_002c: Expected native int or pointer, but got O
			//IL_003e: Expected native int or pointer, but got O
			//IL_0050: Expected native int or pointer, but got O
			long num = input.currentCryptoKey;
			ObscuredLong result = Increment((ObscuredLong)(&num), 1);
			ObscuredLong obscuredLong = default(ObscuredLong);
			((ObscuredLong*)(nint)obscuredLong)->fakeValueActive = result.fakeValueActive;
			((ObscuredLong*)(nint)obscuredLong)->currentCryptoKey = result.currentCryptoKey;
			((ObscuredLong*)(nint)obscuredLong)->inited = result.inited;
			return result;
		}

		[Token(Token = "0x600019A")]
		[Address(RVA = "0xBDF1EC", Offset = "0xBDF1EC", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = input.currentCryptoKey;\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredLong::Increment(&v8 @ V1_v1 (System.Int64), 0xFFFFFFFF);\n\treturnBuffer.fakeValueActive = returnVal1.fakeValueActive;\n\treturnBuffer.currentCryptoKey = returnVal1.currentCryptoKey;\n\treturnBuffer.inited = returnVal1.inited;\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredLong operator --(ObscuredLong input)
		{
			//IL_001b: Expected O, but got Ref
			//IL_002c: Expected native int or pointer, but got O
			//IL_003e: Expected native int or pointer, but got O
			//IL_0050: Expected native int or pointer, but got O
			long num = input.currentCryptoKey;
			ObscuredLong result = Increment((ObscuredLong)(&num), -1);
			ObscuredLong obscuredLong = default(ObscuredLong);
			((ObscuredLong*)(nint)obscuredLong)->fakeValueActive = result.fakeValueActive;
			((ObscuredLong*)(nint)obscuredLong)->currentCryptoKey = result.currentCryptoKey;
			((ObscuredLong*)(nint)obscuredLong)->inited = result.inited;
			return result;
		}

		[Token(Token = "0x600019B")]
		[Address(RVA = "0xBDF188", Offset = "0xBDF188", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = CodeStage.AntiCheat.ObscuredTypes.ObscuredLong::InternalDecrypt(input);\n\tv16 = v14 + increment;\n\tv18 = input.currentCryptoKey ^ v16;\n\tinput.hiddenValue = v18;\n\treturnVal1 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv20 = returnVal1 & 1;\n\tv21 = v20 == 0;\n\tif (v21) goto L_FFFFFFFF;\n\tinput.fakeValue = v16;\n\tgoto L_0016;\nL_0016:\n\tinput.fakeValueActive = v24;\n\treturnBuffer.fakeValueActive = input.fakeValueActive;\n\treturnBuffer.currentCryptoKey = input.currentCryptoKey;\n\treturnBuffer.inited = input.inited;\n\treturn returnVal1;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe static ObscuredLong Increment(ObscuredLong input, int increment)
		{
			//IL_0034: Expected native int or pointer, but got O
			//IL_0042: Expected O, but got I4
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Expected I4, but got Unknown
			//IL_00a3: Expected native int or pointer, but got O
			//IL_00b5: Expected native int or pointer, but got O
			//IL_00c7: Expected native int or pointer, but got O
			//IL_00d9: Expected native int or pointer, but got O
			//IL_007a: Expected native int or pointer, but got O
			long num = ((ObscuredLong*)input)->InternalDecrypt();
			long num2 = num + increment;
			long num3 = input.currentCryptoKey ^ num2;
			((ObscuredLong*)(nint)input)->hiddenValue = num3;
			ObscuredLong obscuredLong = (ObscuredLong)ObscuredCheatingDetector.ExistsAndIsRunning;
			bool flag;
			if ((int)(obscuredLong & 1) != 0)
			{
				((ObscuredLong*)(nint)input)->fakeValue = num2;
				flag = true;
			}
			else
			{
				flag = false;
			}
			((ObscuredLong*)(nint)input)->fakeValueActive = flag;
			ObscuredLong obscuredLong2 = default(ObscuredLong);
			((ObscuredLong*)(nint)obscuredLong2)->fakeValueActive = input.fakeValueActive;
			((ObscuredLong*)(nint)obscuredLong2)->currentCryptoKey = input.currentCryptoKey;
			((ObscuredLong*)(nint)obscuredLong2)->inited = input.inited;
			return obscuredLong;
		}

		[Token(Token = "0x600019C")]
		[Address(RVA = "0xBDF238", Offset = "0xBDF238", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = CodeStage.AntiCheat.ObscuredTypes.ObscuredLong::InternalDecrypt(this);\n\treturnVal1 = System.Int64::GetHashCode(&v2 @ X0_v1 (System.Int64));\n\treturn returnVal1;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override int GetHashCode()
		{
			return InternalDecrypt().GetHashCode();
		}

		[Token(Token = "0x600019D")]
		[Address(RVA = "0xBDF258", Offset = "0xBDF258", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = CodeStage.AntiCheat.ObscuredTypes.ObscuredLong::InternalDecrypt(this);\n\treturnVal1 = System.Int64::ToString(&v2 @ X0_v1 (System.Int64));\n\treturn returnVal1;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			return InternalDecrypt().ToString();
		}

		[Token(Token = "0x600019E")]
		[Address(RVA = "0xBDF278", Offset = "0xBDF278", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredLong::InternalDecrypt(this);\n\treturnVal1 = System.Int64::ToString(&v6 @ X0_v1 (System.Int64), format);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string ToString(string format)
		{
			return InternalDecrypt().ToString(format);
		}

		[Token(Token = "0x600019F")]
		[Address(RVA = "0xBDF2A8", Offset = "0xBDF2A8", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredLong::InternalDecrypt(this);\n\treturnVal1 = System.Int64::ToString(&v6 @ X0_v1 (System.Int64), provider);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string ToString(IFormatProvider provider)
		{
			return InternalDecrypt().ToString(provider);
		}

		[Token(Token = "0x60001A0")]
		[Address(RVA = "0xBDF2D8", Offset = "0xBDF2D8", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = CodeStage.AntiCheat.ObscuredTypes.ObscuredLong::InternalDecrypt(this);\n\treturnVal1 = System.Int64::ToString(&v10 @ X0_v1 (System.Int64), format, provider);\n\treturn returnVal1;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string ToString(string format, IFormatProvider provider)
		{
			return InternalDecrypt().ToString(format, provider);
		}

		[Token(Token = "0x60001A1")]
		[Address(RVA = "0xBDF310", Offset = "0xBDF310", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredLong;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, obj, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A35474]) = v36;\nL_0012:\n\tv37 = obj == 0;\n\tif (v37) goto L_FFFFFFFF;\n\tv46 = *([obj @ X1 (System.Object)]) == CodeStage.AntiCheat.ObscuredTypes.ObscuredLong;\n\tif (v46) goto L_0025;\n\tgoto L_0035;\nL_0025:\n\tv72 = \"il2cpp_vm_object_unbox\"(obj, obj, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv26 = *([v72 @ X0_v6]);\n\tv97 = CodeStage.AntiCheat.ObscuredTypes.ObscuredLong::Equals(this, &v26 @ V0);\nL_0035:\n\treturn v97;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override bool Equals(object obj)
		{
			//IL_005b: Expected O, but got Ref
			if (obj == null || (object)obj.GetType() != typeof(ObscuredLong))
			{
				return false;
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
			object obj3 = default(object);
			object obj2 = obj3;
			return Equals((ObscuredLong)(&obj2));
		}

		[Token(Token = "0x60001A2")]
		[Address(RVA = "0xBDF3A0", Offset = "0xBDF3A0", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.currentCryptoKey;\n\tv29 = this + 8;\n\tv16 = this.currentCryptoKey != obj.currentCryptoKey;\n\tif (v16) goto L_0014;\n\tv28 = obj.hiddenValue;\n\tgoto L_0019;\nL_0014:\n\tv2 = this.hiddenValue ^ v2;\n\tv2 = obj.hiddenValue;\n\tv28 = obj.hiddenValue ^ obj.currentCryptoKey;\nL_0019:\n\tv32 = System.Int64::Equals(v29, v28);\n\treturn v32;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe bool Equals(ObscuredLong obj)
		{
			long num = currentCryptoKey;
			long num2 = (nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			long obj2;
			if (currentCryptoKey == obj.currentCryptoKey)
			{
				obj2 = obj.hiddenValue;
			}
			else
			{
				num = hiddenValue ^ num;
				num = obj.hiddenValue;
				obj2 = obj.hiddenValue ^ obj.currentCryptoKey;
				num2 = (nint)(&num);
			}
			return ((long*)num2)->Equals(obj2);
		}

		[Token(Token = "0x60001A3")]
		[Address(RVA = "0xBDF3E8", Offset = "0xBDF3E8", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredLong::InternalDecrypt(this);\n\tv10 = CodeStage.AntiCheat.ObscuredTypes.ObscuredLong::InternalDecrypt(other);\n\treturnVal1 = System.Int64::CompareTo(&v6 @ X0_v1 (System.Int64), v10);\n\treturn returnVal1;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe int CompareTo(ObscuredLong other)
		{
			long num = InternalDecrypt();
			long value = ((ObscuredLong*)other)->InternalDecrypt();
			return num.CompareTo(value);
		}

		[Token(Token = "0x60001A4")]
		[Address(RVA = "0xBDF420", Offset = "0xBDF420", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredLong::InternalDecrypt(this);\n\treturnVal1 = System.Int64::CompareTo(&v6 @ X0_v1 (System.Int64), other);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int CompareTo(long other)
		{
			return InternalDecrypt().CompareTo(other);
		}

		[Token(Token = "0x60001A5")]
		[Address(RVA = "0xBDF450", Offset = "0xBDF450", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredLong::InternalDecrypt(this);\n\treturnVal1 = System.Int64::CompareTo(&v6 @ X0_v1 (System.Int64), obj);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int CompareTo(object obj)
		{
			return InternalDecrypt().CompareTo(obj);
		}

		[Obsolete("This API is redundant and does not perform any actions. It will be removed in future updates.")]
		[Token(Token = "0x60001A6")]
		[Address(RVA = "0xBDF480", Offset = "0xBDF480", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public static void SetNewCryptoKey(long newKey)
		{
		}

		[Obsolete("This API is redundant and does not perform any actions. It will be removed in future updates.")]
		[Token(Token = "0x60001A7")]
		[Address(RVA = "0xBDF484", Offset = "0xBDF484", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void ApplyNewCryptoKey()
		{
		}

		[Obsolete("Please use new Encrypt(value, key) API instead.", true)]
		[Token(Token = "0x60001A8")]
		[Address(RVA = "0xBDF488", Offset = "0xBDF488", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static long Encrypt(long value)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new Decrypt(value, key) API instead.", true)]
		[Token(Token = "0x60001A9")]
		[Address(RVA = "0xBDF4C0", Offset = "0xBDF4C0", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static long Decrypt(long value)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new FromEncrypted(encrypted, key) API instead.", true)]
		[Token(Token = "0x60001AA")]
		[Address(RVA = "0xBDF4F8", Offset = "0xBDF4F8", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ObscuredLong FromEncrypted(long encrypted)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new GetEncrypted(out key) API instead.", true)]
		[Token(Token = "0x60001AB")]
		[Address(RVA = "0xBDF530", Offset = "0xBDF530", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public long GetEncrypted()
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new SetEncrypted(encrypted, key) API instead.", true)]
		[Token(Token = "0x60001AC")]
		[Address(RVA = "0xBDF568", Offset = "0xBDF568", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetEncrypted(long encrypted)
		{
		}
	}
}
