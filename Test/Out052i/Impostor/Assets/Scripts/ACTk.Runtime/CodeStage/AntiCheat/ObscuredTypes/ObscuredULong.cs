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
	[Token(Token = "0x2000020")]
	public struct ObscuredULong : IObscuredType, IFormattable, IEquatable<ObscuredULong>, IComparable<ObscuredULong>, IComparable<ulong>, IComparable
	{
		[SerializeField]
		[Token(Token = "0x40000A2")]
		[FieldOffset(Offset = "0x0")]
		private ulong currentCryptoKey;

		[SerializeField]
		[Token(Token = "0x40000A3")]
		[FieldOffset(Offset = "0x8")]
		private ulong hiddenValue;

		[SerializeField]
		[Token(Token = "0x40000A4")]
		[FieldOffset(Offset = "0x10")]
		private bool inited;

		[SerializeField]
		[Token(Token = "0x40000A5")]
		[FieldOffset(Offset = "0x18")]
		private ulong fakeValue;

		[SerializeField]
		[Token(Token = "0x40000A6")]
		[FieldOffset(Offset = "0x20")]
		private bool fakeValueActive;

		[Token(Token = "0x6000259")]
		[Address(RVA = "0xBE22B8", Offset = "0xBE22B8", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tv12 = v10 ^ value;\n\tthis.currentCryptoKey = v10;\n\tthis.hiddenValue = v12;\n\tv14 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv17 = v14 == 0;\n\tv21 = ~v17;\n\tv22 = ~v21;\n\tif (v22) goto L_FFFFFFFF;\n\tgoto L_001A;\nL_001A:\n\tthis.fakeValueActive = v14;\n\tthis.fakeValue = v25;\n\tthis.inited = 1;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private ObscuredULong(ulong value)
		{
			//IL_0016: Expected I4, but got I8
			//IL_0020: Expected I8, but got I4
			//IL_002a: Expected I8, but got I4
			//IL_0081: Expected I8, but got I4
			int num = RandomUtils.GenerateIntKey();
			int num2 = (int)((long)num ^ (long)value);
			currentCryptoKey = (ulong)num;
			hiddenValue = (ulong)num2;
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			ulong num3 = ((!existsAndIsRunning) ? 0 : value);
			fakeValueActive = existsAndIsRunning;
			fakeValue = num3;
			inited = true;
		}

		[Token(Token = "0x600025A")]
		[Address(RVA = "0xBE2318", Offset = "0xBE2318", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = key ^ value;\n\treturn returnVal1;\n")]
		public static ulong Encrypt(ulong value, ulong key)
		{
			return key ^ value;
		}

		[Token(Token = "0x600025B")]
		[Address(RVA = "0xBE2320", Offset = "0xBE2320", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = key ^ value;\n\treturn returnVal1;\n")]
		public static ulong Decrypt(ulong value, ulong key)
		{
			return key ^ value;
		}

		[Token(Token = "0x600025C")]
		[Address(RVA = "0xBE2328", Offset = "0xBE2328", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0;\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredULong::SetEncrypted(&v10 @ stack_-40_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredULong), encrypted, key);\n\treturnBuffer.fakeValueActive = 0;\n\treturnBuffer.currentCryptoKey = 0;\n\treturnBuffer.inited = 0;\n\treturn &v10 @ stack_-40_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredULong);\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredULong FromEncrypted(ulong encrypted, ulong key)
		{
			//IL_0024: Expected native int or pointer, but got O
			//IL_0037: Expected I8, but got I4
			//IL_0032: Expected native int or pointer, but got O
			//IL_0040: Expected native int or pointer, but got O
			//IL_004a: Expected O, but got Ref
			ObscuredULong obscuredULong = default(ObscuredULong);
			obscuredULong.SetEncrypted(encrypted, key);
			ObscuredULong obscuredULong2 = default(ObscuredULong);
			((ObscuredULong*)(nint)obscuredULong2)->fakeValueActive = false;
			((ObscuredULong*)(nint)obscuredULong2)->currentCryptoKey = 0uL;
			((ObscuredULong*)(nint)obscuredULong2)->inited = false;
			return (ObscuredULong)(&obscuredULong);
		}

		[Token(Token = "0x600025D")]
		[Address(RVA = "0xBE2304", Offset = "0xBE2304", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\treturn v2;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ulong GenerateKey()
		{
			//IL_000e: Expected I8, but got I4
			int num = RandomUtils.GenerateIntKey();
			return (ulong)num;
		}

		[Token(Token = "0x600025E")]
		[Address(RVA = "0xBE23B0", Offset = "0xBE23B0", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([key @ X1 (System.UInt64&)]) = this.currentCryptoKey;\n\treturn this.hiddenValue;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe ulong GetEncrypted(out ulong key)
		{
			key = default(ulong);
			ref ulong reference = ref *(ulong*)currentCryptoKey;
			return hiddenValue;
		}

		[Token(Token = "0x600025F")]
		[Address(RVA = "0xBE236C", Offset = "0xBE236C", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.inited = 1;\n\tthis.currentCryptoKey = key;\n\tthis.hiddenValue = encrypted;\n\tv12 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tthis.fakeValueActive = 0;\n\tv14 = v12 == 0;\n\tif (v14) goto L_0017;\n\tv16 = CodeStage.AntiCheat.ObscuredTypes.ObscuredULong::InternalDecrypt(this);\n\tthis.fakeValue = v16;\n\tthis.fakeValueActive = 1;\nL_0017:\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetEncrypted(ulong encrypted, ulong key)
		{
			inited = true;
			currentCryptoKey = key;
			hiddenValue = encrypted;
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			fakeValueActive = false;
			if (existsAndIsRunning)
			{
				ulong num = InternalDecrypt();
				fakeValue = num;
				fakeValueActive = true;
			}
		}

		[Token(Token = "0x6000260")]
		[Address(RVA = "0xBE249C", Offset = "0xBE249C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredULong::InternalDecrypt(this);\n\treturn returnVal1;\n")]
		public ulong GetDecrypted()
		{
			return InternalDecrypt();
		}

		[Token(Token = "0x6000261")]
		[Address(RVA = "0xBE24A0", Offset = "0xBE24A0", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = CodeStage.AntiCheat.ObscuredTypes.ObscuredULong::InternalDecrypt(this);\n\tv11 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tv13 = v8 ^ v11;\n\tthis.currentCryptoKey = v11;\n\tthis.hiddenValue = v13;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RandomizeCryptoKey()
		{
			//IL_002f: Expected I8, but got I4
			ulong num = InternalDecrypt();
			int num2 = RandomUtils.GenerateIntKey();
			long num3 = (long)num ^ (long)num2;
			currentCryptoKey = (ulong)num2;
			hiddenValue = (ulong)num3;
		}

		[Token(Token = "0x6000262")]
		[Address(RVA = "0xBE23C0", Offset = "0xBE23C0", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A35493]) = v33;\nL_0011:\n\tv35 = ~v31.inited;\n\tif (v35) goto L_0044;\n\tv84 = v31.currentCryptoKey ^ v31.hiddenValue;\n\tv40 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv43 = v40 == 0;\n\tif (v43) goto L_0052;\n\tv48 = ~v31.fakeValueActive;\n\tif (v48) goto L_0052;\n\tv65 = v84 == v31.fakeValue;\n\tif (v65) goto L_0052;\n\tgoto L_0039;\n\tv116 = 0xB348B0(v111, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0039:\n\tgoto L_0042;\n\tv124 = 0xB348B0(v119, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0042:\n\tv78 = CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector>::OnCheatingDetected(v106.<Instance>k__BackingField);\n\tgoto L_0052;\nL_0044:\n\tv41 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tv31.fakeValue = 0;\n\tv31.fakeValueActive = 0;\n\tv31.currentCryptoKey = v41;\n\tv31.hiddenValue = v41;\n\tv31.inited = 1;\nL_0052:\n\treturn v84;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private ulong InternalDecrypt()
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
				if (ObscuredCheatingDetector.ExistsAndIsRunning && fakeValueActive && (ulong)num != fakeValue)
				{
					KeepAliveBehaviour<ObscuredCheatingDetector>.Instance.OnCheatingDetected();
				}
			}
			else
			{
				int num2 = RandomUtils.GenerateIntKey();
				fakeValue = 0uL;
				fakeValueActive = false;
				currentCryptoKey = (ulong)num2;
				hiddenValue = (ulong)num2;
				inited = true;
				num = 0;
			}
			return (ulong)num;
		}

		[Token(Token = "0x6000263")]
		[Address(RVA = "0xBE24D0", Offset = "0xBE24D0", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnBuffer.fakeValueActive = 0;\n\treturnBuffer.currentCryptoKey = 0;\n\treturnBuffer.inited = 0;\n\tv11 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tv13 = v11 ^ value;\n\treturnBuffer.currentCryptoKey = v11;\n\treturnBuffer.hiddenValue = v13;\n\treturnVal1 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv16 = returnVal1 & 1;\n\tv18 = v16 == 0;\n\tv22 = ~v18;\n\tv23 = ~v22;\n\tif (v23) goto L_FFFFFFFF;\n\tgoto L_001E;\nL_001E:\n\treturnBuffer.fakeValueActive = v16;\n\treturnBuffer.fakeValue = v26;\n\treturnBuffer.inited = 1;\n\treturn returnVal1;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static implicit operator ObscuredULong(ulong value)
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
			ObscuredULong obscuredULong = default(ObscuredULong);
			((ObscuredULong*)(nint)obscuredULong)->fakeValueActive = false;
			((ObscuredULong*)(nint)obscuredULong)->currentCryptoKey = 0uL;
			((ObscuredULong*)(nint)obscuredULong)->inited = false;
			int num = RandomUtils.GenerateIntKey();
			int num2 = (int)((long)num ^ (long)value);
			((ObscuredULong*)(nint)obscuredULong)->currentCryptoKey = (ulong)num;
			((ObscuredULong*)(nint)obscuredULong)->hiddenValue = (ulong)num2;
			ObscuredULong obscuredULong2 = (ObscuredULong)ObscuredCheatingDetector.ExistsAndIsRunning;
			int num3 = (int)(obscuredULong2 & 1);
			ulong num4 = ((num3 == 0) ? 0 : value);
			((ObscuredULong*)(nint)obscuredULong)->fakeValueActive = (byte)num3 != 0;
			((ObscuredULong*)(nint)obscuredULong)->fakeValue = num4;
			((ObscuredULong*)(nint)obscuredULong)->inited = true;
			return obscuredULong2;
		}

		[Token(Token = "0x6000264")]
		[Address(RVA = "0xBE2528", Offset = "0xBE2528", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredULong::InternalDecrypt(value);\n\treturn returnVal1;\n")]
		public unsafe static implicit operator ulong(ObscuredULong value)
		{
			return ((ObscuredULong*)value)->InternalDecrypt();
		}

		[Token(Token = "0x6000265")]
		[Address(RVA = "0xBE252C", Offset = "0xBE252C", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = input.currentCryptoKey;\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredULong::Increment(&v8 @ V1_v1 (System.UInt64), 1);\n\treturnBuffer.fakeValueActive = returnVal1.fakeValueActive;\n\treturnBuffer.currentCryptoKey = returnVal1.currentCryptoKey;\n\treturnBuffer.inited = returnVal1.inited;\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredULong operator ++(ObscuredULong input)
		{
			//IL_001b: Expected O, but got Ref
			//IL_002c: Expected native int or pointer, but got O
			//IL_003e: Expected native int or pointer, but got O
			//IL_0050: Expected native int or pointer, but got O
			ulong num = input.currentCryptoKey;
			ObscuredULong result = Increment((ObscuredULong)(&num), 1);
			ObscuredULong obscuredULong = default(ObscuredULong);
			((ObscuredULong*)(nint)obscuredULong)->fakeValueActive = result.fakeValueActive;
			((ObscuredULong*)(nint)obscuredULong)->currentCryptoKey = result.currentCryptoKey;
			((ObscuredULong*)(nint)obscuredULong)->inited = result.inited;
			return result;
		}

		[Token(Token = "0x6000266")]
		[Address(RVA = "0xBE25E8", Offset = "0xBE25E8", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = input.currentCryptoKey;\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredULong::Increment(&v8 @ V1_v1 (System.UInt64), 0xFFFFFFFF);\n\treturnBuffer.fakeValueActive = returnVal1.fakeValueActive;\n\treturnBuffer.currentCryptoKey = returnVal1.currentCryptoKey;\n\treturnBuffer.inited = returnVal1.inited;\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredULong operator --(ObscuredULong input)
		{
			//IL_001b: Expected O, but got Ref
			//IL_002c: Expected native int or pointer, but got O
			//IL_003e: Expected native int or pointer, but got O
			//IL_0050: Expected native int or pointer, but got O
			ulong num = input.currentCryptoKey;
			ObscuredULong result = Increment((ObscuredULong)(&num), -1);
			ObscuredULong obscuredULong = default(ObscuredULong);
			((ObscuredULong*)(nint)obscuredULong)->fakeValueActive = result.fakeValueActive;
			((ObscuredULong*)(nint)obscuredULong)->currentCryptoKey = result.currentCryptoKey;
			((ObscuredULong*)(nint)obscuredULong)->inited = result.inited;
			return result;
		}

		[Token(Token = "0x6000267")]
		[Address(RVA = "0xBE2578", Offset = "0xBE2578", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = CodeStage.AntiCheat.ObscuredTypes.ObscuredULong::InternalDecrypt(input);\n\tv18 = increment - 1;\n\tv20 = v18 == 0;\n\tv26 = ~v20;\n\tv27 = ~v26;\n\tif (v27) goto L_FFFFFFFF;\n\tgoto L_001B;\nL_001B:\n\tv31 = v14 + v30;\n\tv32 = input.currentCryptoKey ^ v31;\n\tinput.hiddenValue = v32;\n\treturnVal1 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv35 = returnVal1 & 1;\n\tv36 = v35 == 0;\n\tif (v36) goto L_FFFFFFFF;\n\tinput.fakeValue = v31;\n\tgoto L_0027;\nL_0027:\n\tinput.fakeValueActive = v39;\n\treturnBuffer.fakeValueActive = input.fakeValueActive;\n\treturnBuffer.currentCryptoKey = input.currentCryptoKey;\n\treturnBuffer.inited = input.inited;\n\treturn returnVal1;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe static ObscuredULong Increment(ObscuredULong input, int increment)
		{
			//IL_0065: Expected O, but got I4
			//IL_00b3: Expected I4, but got I8
			//IL_00c0: Expected I8, but got I4
			//IL_00bb: Expected native int or pointer, but got O
			//IL_00c9: Expected O, but got I4
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected I4, but got Unknown
			//IL_0057: Expected O, but got I4
			//IL_00fc: Expected native int or pointer, but got O
			//IL_010e: Expected native int or pointer, but got O
			//IL_0120: Expected native int or pointer, but got O
			//IL_0132: Expected native int or pointer, but got O
			//IL_0072: Expected native int or pointer, but got O
			ulong num = ((ObscuredULong*)input)->InternalDecrypt();
			object obj = ((increment - 1 == 0) ? ((object)1) : ((object)(-1)));
			ulong num2 = num + (ulong)(nint)obj;
			int num3 = (int)(input.currentCryptoKey ^ num2);
			((ObscuredULong*)(nint)input)->hiddenValue = (ulong)num3;
			ObscuredULong obscuredULong = (ObscuredULong)ObscuredCheatingDetector.ExistsAndIsRunning;
			bool flag;
			if ((int)(obscuredULong & 1) != 0)
			{
				((ObscuredULong*)(nint)input)->fakeValue = num2;
				flag = true;
			}
			else
			{
				flag = false;
			}
			((ObscuredULong*)(nint)input)->fakeValueActive = flag;
			ObscuredULong obscuredULong2 = default(ObscuredULong);
			((ObscuredULong*)(nint)obscuredULong2)->fakeValueActive = input.fakeValueActive;
			((ObscuredULong*)(nint)obscuredULong2)->currentCryptoKey = input.currentCryptoKey;
			((ObscuredULong*)(nint)obscuredULong2)->inited = input.inited;
			return obscuredULong;
		}

		[Token(Token = "0x6000268")]
		[Address(RVA = "0xBE2634", Offset = "0xBE2634", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = CodeStage.AntiCheat.ObscuredTypes.ObscuredULong::InternalDecrypt(this);\n\treturnVal1 = System.UInt64::GetHashCode(&v2 @ X0_v1 (System.UInt64));\n\treturn returnVal1;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override int GetHashCode()
		{
			return InternalDecrypt().GetHashCode();
		}

		[Token(Token = "0x6000269")]
		[Address(RVA = "0xBE2654", Offset = "0xBE2654", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = CodeStage.AntiCheat.ObscuredTypes.ObscuredULong::InternalDecrypt(this);\n\treturnVal1 = System.UInt64::ToString(&v2 @ X0_v1 (System.UInt64));\n\treturn returnVal1;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			return InternalDecrypt().ToString();
		}

		[Token(Token = "0x600026A")]
		[Address(RVA = "0xBE2674", Offset = "0xBE2674", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredULong::InternalDecrypt(this);\n\treturnVal1 = System.UInt64::ToString(&v6 @ X0_v1 (System.UInt64), format);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string ToString(string format)
		{
			return InternalDecrypt().ToString(format);
		}

		[Token(Token = "0x600026B")]
		[Address(RVA = "0xBE26A4", Offset = "0xBE26A4", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredULong::InternalDecrypt(this);\n\treturnVal1 = System.UInt64::ToString(&v6 @ X0_v1 (System.UInt64), provider);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string ToString(IFormatProvider provider)
		{
			return InternalDecrypt().ToString(provider);
		}

		[Token(Token = "0x600026C")]
		[Address(RVA = "0xBE26D4", Offset = "0xBE26D4", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = CodeStage.AntiCheat.ObscuredTypes.ObscuredULong::InternalDecrypt(this);\n\treturnVal1 = System.UInt64::ToString(&v10 @ X0_v1 (System.UInt64), format, provider);\n\treturn returnVal1;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string ToString(string format, IFormatProvider provider)
		{
			return InternalDecrypt().ToString(format, provider);
		}

		[Token(Token = "0x600026D")]
		[Address(RVA = "0xBE270C", Offset = "0xBE270C", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredULong;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, obj, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A35494]) = v36;\nL_0012:\n\tv37 = obj == 0;\n\tif (v37) goto L_FFFFFFFF;\n\tv46 = *([obj @ X1 (System.Object)]) == CodeStage.AntiCheat.ObscuredTypes.ObscuredULong;\n\tif (v46) goto L_0025;\n\tgoto L_0035;\nL_0025:\n\tv72 = \"il2cpp_vm_object_unbox\"(obj, obj, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv26 = *([v72 @ X0_v6]);\n\tv97 = CodeStage.AntiCheat.ObscuredTypes.ObscuredULong::Equals(this, &v26 @ V0);\nL_0035:\n\treturn v97;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override bool Equals(object obj)
		{
			//IL_0056: Expected O, but got Ref
			if (obj == null || (object)obj.GetType() != typeof(ObscuredULong))
			{
				return false;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
			object obj3 = default(object);
			object obj2 = obj3;
			return Equals((ObscuredULong)(&obj2));
		}

		[Token(Token = "0x600026E")]
		[Address(RVA = "0xBE279C", Offset = "0xBE279C", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv29 = this + 8;\n\tv16 = this.currentCryptoKey != obj.currentCryptoKey;\n\tif (v16) goto L_0014;\n\tv28 = obj.hiddenValue;\n\tgoto L_0019;\nL_0014:\n\tv21 = this.hiddenValue ^ this.currentCryptoKey;\n\tv23 = obj.hiddenValue ^ obj.currentCryptoKey;\nL_0019:\n\tv32 = System.UInt64::Equals(v29, v28);\n\treturn v32;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe bool Equals(ObscuredULong obj)
		{
			ulong num = (ulong)(nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			ulong obj2;
			if (currentCryptoKey == obj.currentCryptoKey)
			{
				obj2 = obj.hiddenValue;
			}
			else
			{
				long num2 = (long)(hiddenValue ^ currentCryptoKey);
				long num3 = (long)(obj.hiddenValue ^ obj.currentCryptoKey);
				obj2 = (ulong)num3;
				num = (ulong)(nint)(&num2);
			}
			return ((ulong*)num)->Equals(obj2);
		}

		[Token(Token = "0x600026F")]
		[Address(RVA = "0xBE27E4", Offset = "0xBE27E4", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredULong::InternalDecrypt(this);\n\tv10 = CodeStage.AntiCheat.ObscuredTypes.ObscuredULong::InternalDecrypt(other);\n\treturnVal1 = System.UInt64::CompareTo(&v6 @ X0_v1 (System.UInt64), v10);\n\treturn returnVal1;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe int CompareTo(ObscuredULong other)
		{
			ulong num = InternalDecrypt();
			ulong value = ((ObscuredULong*)other)->InternalDecrypt();
			return num.CompareTo(value);
		}

		[Token(Token = "0x6000270")]
		[Address(RVA = "0xBE281C", Offset = "0xBE281C", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredULong::InternalDecrypt(this);\n\treturnVal1 = System.UInt64::CompareTo(&v6 @ X0_v1 (System.UInt64), other);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int CompareTo(ulong other)
		{
			return InternalDecrypt().CompareTo(other);
		}

		[Token(Token = "0x6000271")]
		[Address(RVA = "0xBE284C", Offset = "0xBE284C", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredULong::InternalDecrypt(this);\n\treturnVal1 = System.UInt64::CompareTo(&v6 @ X0_v1 (System.UInt64), obj);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int CompareTo(object obj)
		{
			return InternalDecrypt().CompareTo(obj);
		}

		[Obsolete("This API is redundant and does not perform any actions. It will be removed in future updates.")]
		[Token(Token = "0x6000272")]
		[Address(RVA = "0xBE287C", Offset = "0xBE287C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public static void SetNewCryptoKey(ulong newKey)
		{
		}

		[Obsolete("This API is redundant and does not perform any actions. It will be removed in future updates.")]
		[Token(Token = "0x6000273")]
		[Address(RVA = "0xBE2880", Offset = "0xBE2880", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void ApplyNewCryptoKey()
		{
		}

		[Obsolete("Please use new Encrypt(value, key) API instead.", true)]
		[Token(Token = "0x6000274")]
		[Address(RVA = "0xBE2884", Offset = "0xBE2884", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ulong Encrypt(ulong value)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new Decrypt(value, key) API instead.", true)]
		[Token(Token = "0x6000275")]
		[Address(RVA = "0xBE28BC", Offset = "0xBE28BC", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ulong Decrypt(ulong value)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new FromEncrypted(encrypted, key) API instead.", true)]
		[Token(Token = "0x6000276")]
		[Address(RVA = "0xBE28F4", Offset = "0xBE28F4", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ObscuredULong FromEncrypted(ulong encrypted)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new GetEncrypted(out key) API instead.", true)]
		[Token(Token = "0x6000277")]
		[Address(RVA = "0xBE292C", Offset = "0xBE292C", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ulong GetEncrypted()
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new SetEncrypted(encrypted, key) API instead.", true)]
		[Token(Token = "0x6000278")]
		[Address(RVA = "0xBE2964", Offset = "0xBE2964", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetEncrypted(ulong encrypted)
		{
		}
	}
}
