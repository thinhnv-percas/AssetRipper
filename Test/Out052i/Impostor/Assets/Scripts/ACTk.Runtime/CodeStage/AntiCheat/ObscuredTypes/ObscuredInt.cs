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
	[Token(Token = "0x2000018")]
	public struct ObscuredInt : IObscuredType, IFormattable, IEquatable<ObscuredInt>, IComparable<ObscuredInt>, IComparable<int>, IComparable
	{
		[SerializeField]
		[Token(Token = "0x4000078")]
		[FieldOffset(Offset = "0x0")]
		public int currentCryptoKey;

		[SerializeField]
		[Token(Token = "0x4000079")]
		[FieldOffset(Offset = "0x4")]
		internal int hiddenValue;

		[SerializeField]
		[Token(Token = "0x400007A")]
		[FieldOffset(Offset = "0x8")]
		internal bool inited;

		[SerializeField]
		[Token(Token = "0x400007B")]
		[FieldOffset(Offset = "0xC")]
		internal int fakeValue;

		[SerializeField]
		[Token(Token = "0x400007C")]
		[FieldOffset(Offset = "0x10")]
		public bool fakeValueActive;

		[Token(Token = "0x600016A")]
		[Address(RVA = "0xBDE71C", Offset = "0xBDE71C", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tv11 = v10 ^ value;\n\tthis.currentCryptoKey = v10;\n\tthis.hiddenValue = v11;\n\tv13 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv16 = v13 == 0;\n\tv20 = ~v16;\n\tv21 = ~v20;\n\tif (v21) goto L_FFFFFFFF;\n\tgoto L_0019;\nL_0019:\n\tthis.fakeValueActive = v13;\n\tthis.fakeValue = v24;\n\tthis.inited = 1;\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private ObscuredInt(int value)
		{
			int num = RandomUtils.GenerateIntKey();
			int num2 = num ^ value;
			currentCryptoKey = num;
			hiddenValue = num2;
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			int num3 = (existsAndIsRunning ? value : 0);
			fakeValueActive = existsAndIsRunning;
			fakeValue = num3;
			inited = true;
		}

		[Token(Token = "0x600016B")]
		[Address(RVA = "0xBDE768", Offset = "0xBDE768", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = key ^ value;\n\treturn returnVal1;\n")]
		public static int Encrypt(int value, int key)
		{
			return key ^ value;
		}

		[Token(Token = "0x600016C")]
		[Address(RVA = "0xBDE770", Offset = "0xBDE770", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = key ^ value;\n\treturn returnVal1;\n")]
		public static int Decrypt(int value, int key)
		{
			return key ^ value;
		}

		[Token(Token = "0x600016D")]
		[Address(RVA = "0xBDE778", Offset = "0xBDE778", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = 0;\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredInt::SetEncrypted(&v9 @ stack_-28_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredInt), encrypted, key);\n\treturnBuffer.fakeValueActive = 0;\n\treturnBuffer.currentCryptoKey = 0;\n\treturn &v9 @ stack_-28_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredInt);\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredInt FromEncrypted(int encrypted, int key)
		{
			//IL_0024: Expected native int or pointer, but got O
			//IL_0032: Expected native int or pointer, but got O
			//IL_003c: Expected O, but got Ref
			ObscuredInt obscuredInt = default(ObscuredInt);
			obscuredInt.SetEncrypted(encrypted, key);
			ObscuredInt obscuredInt2 = default(ObscuredInt);
			((ObscuredInt*)(nint)obscuredInt2)->fakeValueActive = false;
			((ObscuredInt*)(nint)obscuredInt2)->currentCryptoKey = 0;
			return (ObscuredInt)(&obscuredInt);
		}

		[Token(Token = "0x600016E")]
		[Address(RVA = "0xBDE764", Offset = "0xBDE764", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\treturn returnVal1;\n")]
		public static int GenerateKey()
		{
			return RandomUtils.GenerateIntKey();
		}

		[Token(Token = "0x600016F")]
		[Address(RVA = "0xBDE7FC", Offset = "0xBDE7FC", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([key @ X1 (System.Int32&)]) = this.currentCryptoKey;\n\treturn this.hiddenValue;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe int GetEncrypted(out int key)
		{
			key = default(int);
			ref int reference = ref *(int*)currentCryptoKey;
			return hiddenValue;
		}

		[Token(Token = "0x6000170")]
		[Address(RVA = "0xBDE7B8", Offset = "0xBDE7B8", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.inited = 1;\n\tthis.currentCryptoKey = key;\n\tthis.hiddenValue = encrypted;\n\tv12 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tthis.fakeValueActive = 0;\n\tv14 = v12 == 0;\n\tif (v14) goto L_0017;\n\tv16 = CodeStage.AntiCheat.ObscuredTypes.ObscuredInt::InternalDecrypt(this);\n\tthis.fakeValue = v16;\n\tthis.fakeValueActive = 1;\nL_0017:\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetEncrypted(int encrypted, int key)
		{
			inited = true;
			currentCryptoKey = key;
			hiddenValue = encrypted;
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			fakeValueActive = false;
			if (existsAndIsRunning)
			{
				int num = InternalDecrypt();
				fakeValue = num;
				fakeValueActive = true;
			}
		}

		[Token(Token = "0x6000171")]
		[Address(RVA = "0xBDE8E4", Offset = "0xBDE8E4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredInt::InternalDecrypt(this);\n\treturn returnVal1;\n")]
		public int GetDecrypted()
		{
			return InternalDecrypt();
		}

		[Token(Token = "0x6000172")]
		[Address(RVA = "0xBDE8E8", Offset = "0xBDE8E8", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredInt::InternalDecrypt(this);\n\tthis.hiddenValue = v6;\n\tv8 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tv10 = this.hiddenValue ^ v8;\n\tthis.currentCryptoKey = v8;\n\tthis.hiddenValue = v10;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RandomizeCryptoKey()
		{
			int num = InternalDecrypt();
			hiddenValue = num;
			int num2 = RandomUtils.GenerateIntKey();
			int num3 = hiddenValue ^ num2;
			currentCryptoKey = num2;
			hiddenValue = num3;
		}

		[Token(Token = "0x6000173")]
		[Address(RVA = "0xBDE80C", Offset = "0xBDE80C", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A35471]) = v33;\nL_0011:\n\tv35 = ~v31.inited;\n\tif (v35) goto L_0044;\n\tv84 = v31.currentCryptoKey ^ v31.hiddenValue;\n\tv40 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv43 = v40 == 0;\n\tif (v43) goto L_0051;\n\tv47 = ~v31.fakeValueActive;\n\tif (v47) goto L_0051;\n\tv64 = v84 == v31.fakeValue;\n\tif (v64) goto L_0051;\n\tgoto L_0039;\n\tv116 = 0xB348B0(v111, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0039:\n\tgoto L_0042;\n\tv124 = 0xB348B0(v119, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0042:\n\tv78 = CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector>::OnCheatingDetected(v106.<Instance>k__BackingField);\n\tgoto L_0051;\nL_0044:\n\tv41 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tv31.currentCryptoKey = v41;\n\tv31.hiddenValue = v41;\n\tv31.fakeValue = 0;\n\tv31.fakeValueActive = 0;\n\tv31.inited = 1;\nL_0051:\n\treturn v84;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private int InternalDecrypt()
		{
			int num;
			if (inited)
			{
				num = currentCryptoKey ^ hiddenValue;
				if (ObscuredCheatingDetector.ExistsAndIsRunning && fakeValueActive && num != fakeValue)
				{
					KeepAliveBehaviour<ObscuredCheatingDetector>.Instance.OnCheatingDetected();
				}
			}
			else
			{
				hiddenValue = (currentCryptoKey = RandomUtils.GenerateIntKey());
				fakeValue = 0;
				fakeValueActive = false;
				inited = true;
				num = 0;
			}
			return num;
		}

		[Token(Token = "0x6000174")]
		[Address(RVA = "0xBDE910", Offset = "0xBDE910", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnBuffer.currentCryptoKey = 0;\n\treturnBuffer.inited = 0;\n\treturnBuffer.fakeValueActive = 0;\n\tv10 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tv11 = v10 ^ value;\n\treturnBuffer.currentCryptoKey = v10;\n\treturnBuffer.hiddenValue = v11;\n\treturnVal1 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv14 = returnVal1 & 1;\n\tv16 = v14 == 0;\n\tv20 = ~v16;\n\tv21 = ~v20;\n\tif (v21) goto L_FFFFFFFF;\n\tgoto L_001C;\nL_001C:\n\treturnBuffer.fakeValueActive = v14;\n\treturnBuffer.fakeValue = v24;\n\treturnBuffer.inited = 1;\n\treturn returnVal1;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static implicit operator ObscuredInt(int value)
		{
			//IL_0009: Expected native int or pointer, but got O
			//IL_0017: Expected native int or pointer, but got O
			//IL_0025: Expected native int or pointer, but got O
			//IL_0048: Expected native int or pointer, but got O
			//IL_0055: Expected native int or pointer, but got O
			//IL_0063: Expected O, but got I4
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Expected I4, but got Unknown
			//IL_00cc: Expected native int or pointer, but got O
			//IL_00d9: Expected native int or pointer, but got O
			//IL_00e7: Expected native int or pointer, but got O
			ObscuredInt obscuredInt = default(ObscuredInt);
			((ObscuredInt*)(nint)obscuredInt)->currentCryptoKey = 0;
			((ObscuredInt*)(nint)obscuredInt)->inited = false;
			((ObscuredInt*)(nint)obscuredInt)->fakeValueActive = false;
			int num = RandomUtils.GenerateIntKey();
			int num2 = num ^ value;
			((ObscuredInt*)(nint)obscuredInt)->currentCryptoKey = num;
			((ObscuredInt*)(nint)obscuredInt)->hiddenValue = num2;
			ObscuredInt obscuredInt2 = (ObscuredInt)ObscuredCheatingDetector.ExistsAndIsRunning;
			int num3 = obscuredInt2 & 1;
			int num4 = ((num3 != 0) ? value : 0);
			((ObscuredInt*)(nint)obscuredInt)->fakeValueActive = (byte)num3 != 0;
			((ObscuredInt*)(nint)obscuredInt)->fakeValue = num4;
			((ObscuredInt*)(nint)obscuredInt)->inited = true;
			return obscuredInt2;
		}

		[Token(Token = "0x6000175")]
		[Address(RVA = "0xBDE960", Offset = "0xBDE960", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredInt::InternalDecrypt(value);\n\treturn returnVal1;\n")]
		public unsafe static implicit operator int(ObscuredInt value)
		{
			return ((ObscuredInt*)value)->InternalDecrypt();
		}

		[Token(Token = "0x6000176")]
		[Address(RVA = "0xBDE964", Offset = "0xBDE964", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredInt::InternalDecrypt(value);\n\tv11 = 0;\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredFloat::.ctor(&v11 @ stack_-28_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat), v6);\n\treturnBuffer.fakeValue = 0f;\n\treturnBuffer.currentCryptoKey = 0;\n\treturn &v11 @ stack_-28_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat);\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static implicit operator ObscuredFloat(ObscuredInt value)
		{
			//IL_0033: Expected native int or pointer, but got O
			//IL_0041: Expected native int or pointer, but got O
			//IL_004b: Expected O, but got Ref
			int num = ((ObscuredInt*)value)->InternalDecrypt();
			ObscuredFloat obscuredFloat = default(ObscuredFloat);
			obscuredFloat = new ObscuredFloat(num);
			ObscuredFloat obscuredFloat2 = default(ObscuredFloat);
			((ObscuredFloat*)(nint)obscuredFloat2)->fakeValue = 0f;
			((ObscuredFloat*)(nint)obscuredFloat2)->currentCryptoKey = 0;
			return (ObscuredFloat)(&obscuredFloat);
		}

		[Token(Token = "0x6000177")]
		[Address(RVA = "0xBDE9A4", Offset = "0xBDE9A4", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredInt::InternalDecrypt(value);\n\tv12 = 0;\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredDouble::.ctor(&v12 @ stack_-40_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredDouble), v6);\n\treturnBuffer.hiddenValueOldByte8 = 0;\n\treturnBuffer.fakeValue = 0d;\n\treturnBuffer.currentCryptoKey = 0;\n\treturn &v12 @ stack_-40_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredDouble);\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static implicit operator ObscuredDouble(ObscuredInt value)
		{
			//IL_003c: Expected native int or pointer, but got O
			//IL_004e: Expected native int or pointer, but got O
			//IL_0060: Expected native int or pointer, but got O
			//IL_0072: Expected native int or pointer, but got O
			//IL_007c: Expected O, but got Ref
			int num = ((ObscuredInt*)value)->InternalDecrypt();
			ObscuredDouble obscuredDouble = default(ObscuredDouble);
			obscuredDouble = new ObscuredDouble(num);
			ObscuredDouble obscuredDouble2 = default(ObscuredDouble);
			((ObscuredDouble*)(nint)obscuredDouble2)->hiddenValueOldByte8 = default(ACTkByte8);
			((ObscuredDouble*)(nint)obscuredDouble2)->fakeValue = 0.0;
			((ObscuredDouble*)(nint)obscuredDouble2)->currentCryptoKey = 0L;
			((ObscuredDouble*)(nint)obscuredDouble2)->hiddenValue = 0L;
			return (ObscuredDouble)(&obscuredDouble);
		}

		[Token(Token = "0x6000178")]
		[Address(RVA = "0xBDE9E8", Offset = "0xBDE9E8", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = CodeStage.AntiCheat.ObscuredTypes.ObscuredInt::InternalDecrypt(value);\n\tv16 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tv18 = v16 ^ v12;\n\treturnVal1 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv21 = returnVal1 & 1;\n\tv23 = v21 == 0;\n\tv27 = ~v23;\n\tv28 = ~v27;\n\tif (v28) goto L_FFFFFFFF;\n\tgoto L_001B;\nL_001B:\n\treturnBuffer.currentCryptoKey = v16;\n\treturnBuffer.hiddenValue = v18;\n\t*([returnBuffer @ X8 (CodeStage.AntiCheat.ObscuredTypes.ObscuredUInt)+9]) = 0;\n\t*([returnBuffer @ X8 (CodeStage.AntiCheat.ObscuredTypes.ObscuredUInt)+B]) = 0;\n\t*([returnBuffer @ X8 (CodeStage.AntiCheat.ObscuredTypes.ObscuredUInt)+11]) = 0;\n\treturnBuffer.inited = 1;\n\treturnBuffer.fakeValueActive = v21;\n\treturnBuffer.fakeValue = v31;\n\t*([returnBuffer @ X8 (CodeStage.AntiCheat.ObscuredTypes.ObscuredUInt)+13]) = 0;\n\treturn returnVal1;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static explicit operator ObscuredUInt(ObscuredInt value)
		{
			//IL_0031: Expected O, but got I4
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Expected I4, but got Unknown
			//IL_0095: Expected native int or pointer, but got O
			//IL_00a2: Expected native int or pointer, but got O
			//IL_00c2: Expected native int or pointer, but got O
			//IL_00cf: Expected native int or pointer, but got O
			//IL_00dc: Expected native int or pointer, but got O
			int num = ((ObscuredInt*)value)->InternalDecrypt();
			int num2 = RandomUtils.GenerateIntKey();
			int num3 = num2 ^ num;
			ObscuredUInt obscuredUInt = (ObscuredUInt)ObscuredCheatingDetector.ExistsAndIsRunning;
			int num4 = (int)(obscuredUInt & 1);
			int num5 = ((num4 != 0) ? num : 0);
			ObscuredUInt obscuredUInt2 = default(ObscuredUInt);
			((ObscuredUInt*)(nint)obscuredUInt2)->currentCryptoKey = (uint)num2;
			((ObscuredUInt*)(nint)obscuredUInt2)->hiddenValue = (uint)num3;
			_ = 0;
			_ = 0;
			_ = 0;
			((ObscuredUInt*)(nint)obscuredUInt2)->inited = true;
			((ObscuredUInt*)(nint)obscuredUInt2)->fakeValueActive = (byte)num4 != 0;
			((ObscuredUInt*)(nint)obscuredUInt2)->fakeValue = (uint)num5;
			_ = 0;
			return obscuredUInt;
		}

		[Token(Token = "0x6000179")]
		[Address(RVA = "0xBDEAA0", Offset = "0xBDEAA0", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = input.currentCryptoKey;\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredInt::Increment(&v8 @ V0_v1 (System.Int32), 1);\n\treturnBuffer.fakeValueActive = returnVal1.fakeValueActive;\n\treturnBuffer.currentCryptoKey = returnVal1.currentCryptoKey;\n\treturn returnVal1;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredInt operator ++(ObscuredInt input)
		{
			//IL_001b: Expected O, but got Ref
			//IL_002c: Expected native int or pointer, but got O
			//IL_003e: Expected native int or pointer, but got O
			int num = input.currentCryptoKey;
			ObscuredInt result = Increment((ObscuredInt)(&num), 1);
			ObscuredInt obscuredInt = default(ObscuredInt);
			((ObscuredInt*)(nint)obscuredInt)->fakeValueActive = result.fakeValueActive;
			((ObscuredInt*)(nint)obscuredInt)->currentCryptoKey = result.currentCryptoKey;
			return result;
		}

		[Token(Token = "0x600017A")]
		[Address(RVA = "0xBDEB4C", Offset = "0xBDEB4C", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = input.currentCryptoKey;\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredInt::Increment(&v8 @ V0_v1 (System.Int32), 0xFFFFFFFF);\n\treturnBuffer.fakeValueActive = returnVal1.fakeValueActive;\n\treturnBuffer.currentCryptoKey = returnVal1.currentCryptoKey;\n\treturn returnVal1;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredInt operator --(ObscuredInt input)
		{
			//IL_001b: Expected O, but got Ref
			//IL_002c: Expected native int or pointer, but got O
			//IL_003e: Expected native int or pointer, but got O
			int num = input.currentCryptoKey;
			ObscuredInt result = Increment((ObscuredInt)(&num), -1);
			ObscuredInt obscuredInt = default(ObscuredInt);
			((ObscuredInt*)(nint)obscuredInt)->fakeValueActive = result.fakeValueActive;
			((ObscuredInt*)(nint)obscuredInt)->currentCryptoKey = result.currentCryptoKey;
			return result;
		}

		[Token(Token = "0x600017B")]
		[Address(RVA = "0xBDEAE8", Offset = "0xBDEAE8", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = CodeStage.AntiCheat.ObscuredTypes.ObscuredInt::InternalDecrypt(input);\n\tv16 = v14 + increment;\n\tv18 = input.currentCryptoKey ^ v16;\n\tinput.hiddenValue = v18;\n\treturnVal1 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv20 = returnVal1 & 1;\n\tv21 = v20 == 0;\n\tif (v21) goto L_FFFFFFFF;\n\tinput.fakeValue = v16;\n\tgoto L_0016;\nL_0016:\n\tinput.fakeValueActive = v24;\n\treturnBuffer.fakeValueActive = input.fakeValueActive;\n\treturnBuffer.currentCryptoKey = input.currentCryptoKey;\n\treturn returnVal1;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe static ObscuredInt Increment(ObscuredInt input, int increment)
		{
			//IL_0034: Expected native int or pointer, but got O
			//IL_0042: Expected O, but got I4
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Expected I4, but got Unknown
			//IL_00a3: Expected native int or pointer, but got O
			//IL_00b5: Expected native int or pointer, but got O
			//IL_00c7: Expected native int or pointer, but got O
			//IL_007a: Expected native int or pointer, but got O
			int num = ((ObscuredInt*)input)->InternalDecrypt();
			int num2 = num + increment;
			int num3 = input.currentCryptoKey ^ num2;
			((ObscuredInt*)(nint)input)->hiddenValue = num3;
			ObscuredInt obscuredInt = (ObscuredInt)ObscuredCheatingDetector.ExistsAndIsRunning;
			bool flag;
			if ((obscuredInt & 1) != 0)
			{
				((ObscuredInt*)(nint)input)->fakeValue = num2;
				flag = true;
			}
			else
			{
				flag = false;
			}
			((ObscuredInt*)(nint)input)->fakeValueActive = flag;
			ObscuredInt obscuredInt2 = default(ObscuredInt);
			((ObscuredInt*)(nint)obscuredInt2)->fakeValueActive = input.fakeValueActive;
			((ObscuredInt*)(nint)obscuredInt2)->currentCryptoKey = input.currentCryptoKey;
			return obscuredInt;
		}

		[Token(Token = "0x600017C")]
		[Address(RVA = "0xBDEB94", Offset = "0xBDEB94", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = CodeStage.AntiCheat.ObscuredTypes.ObscuredInt::InternalDecrypt(this);\n\treturnVal1 = System.Int32::GetHashCode(&v2 @ X0_v1 (System.Int32));\n\treturn returnVal1;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override int GetHashCode()
		{
			return InternalDecrypt().GetHashCode();
		}

		[Token(Token = "0x600017D")]
		[Address(RVA = "0xBDEBB4", Offset = "0xBDEBB4", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = CodeStage.AntiCheat.ObscuredTypes.ObscuredInt::InternalDecrypt(this);\n\treturnVal1 = System.Int32::ToString(&v2 @ X0_v1 (System.Int32));\n\treturn returnVal1;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			return InternalDecrypt().ToString();
		}

		[Token(Token = "0x600017E")]
		[Address(RVA = "0xBDEBD4", Offset = "0xBDEBD4", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredInt::InternalDecrypt(this);\n\treturnVal1 = System.Int32::ToString(&v6 @ X0_v1 (System.Int32), format);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string ToString(string format)
		{
			return InternalDecrypt().ToString(format);
		}

		[Token(Token = "0x600017F")]
		[Address(RVA = "0xBDEC04", Offset = "0xBDEC04", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredInt::InternalDecrypt(this);\n\treturnVal1 = System.Int32::ToString(&v6 @ X0_v1 (System.Int32), provider);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string ToString(IFormatProvider provider)
		{
			return InternalDecrypt().ToString(provider);
		}

		[Token(Token = "0x6000180")]
		[Address(RVA = "0xBDEC34", Offset = "0xBDEC34", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = CodeStage.AntiCheat.ObscuredTypes.ObscuredInt::InternalDecrypt(this);\n\treturnVal1 = System.Int32::ToString(&v10 @ X0_v1 (System.Int32), format, provider);\n\treturn returnVal1;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string ToString(string format, IFormatProvider provider)
		{
			return InternalDecrypt().ToString(format, provider);
		}

		[Token(Token = "0x6000181")]
		[Address(RVA = "0xBDEC6C", Offset = "0xBDEC6C", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredInt;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, obj, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A35472]) = v36;\nL_0012:\n\tv37 = obj == 0;\n\tif (v37) goto L_FFFFFFFF;\n\tv46 = *([obj @ X1 (System.Object)]) == CodeStage.AntiCheat.ObscuredTypes.ObscuredInt;\n\tif (v46) goto L_0025;\n\tgoto L_0033;\nL_0025:\n\tv72 = \"il2cpp_vm_object_unbox\"(obj, obj, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv26 = *([v72 @ X0_v6]);\n\tv92 = CodeStage.AntiCheat.ObscuredTypes.ObscuredInt::Equals(this, &v26 @ V0);\nL_0033:\n\treturn v92;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override bool Equals(object obj)
		{
			//IL_0056: Expected O, but got Ref
			if (obj == null || (object)obj.GetType() != typeof(ObscuredInt))
			{
				return false;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
			object obj3 = default(object);
			object obj2 = obj3;
			return Equals((ObscuredInt)(&obj2));
		}

		[Token(Token = "0x6000182")]
		[Address(RVA = "0xBDECFC", Offset = "0xBDECFC", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.currentCryptoKey;\n\tv29 = this + 4;\n\tv16 = this.currentCryptoKey != obj.currentCryptoKey;\n\tif (v16) goto L_0014;\n\tv28 = obj.hiddenValue;\n\tgoto L_0019;\nL_0014:\n\tv2 = this.hiddenValue ^ v2;\n\tv2 = obj.hiddenValue;\n\tv28 = obj.hiddenValue ^ obj.currentCryptoKey;\nL_0019:\n\tv32 = System.Int32::Equals(v29, v28);\n\treturn v32;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe bool Equals(ObscuredInt obj)
		{
			int num = currentCryptoKey;
			int num2 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 4));
			int obj2;
			if (currentCryptoKey == obj.currentCryptoKey)
			{
				obj2 = obj.hiddenValue;
			}
			else
			{
				num = hiddenValue ^ num;
				num = obj.hiddenValue;
				obj2 = obj.hiddenValue ^ obj.currentCryptoKey;
				num2 = (int)(&num);
			}
			return ((int*)num2)->Equals(obj2);
		}

		[Token(Token = "0x6000183")]
		[Address(RVA = "0xBDED44", Offset = "0xBDED44", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredInt::InternalDecrypt(this);\n\tv10 = CodeStage.AntiCheat.ObscuredTypes.ObscuredInt::InternalDecrypt(other);\n\treturnVal1 = System.Int32::CompareTo(&v6 @ X0_v1 (System.Int32), v10);\n\treturn returnVal1;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe int CompareTo(ObscuredInt other)
		{
			int num = InternalDecrypt();
			int value = ((ObscuredInt*)other)->InternalDecrypt();
			return num.CompareTo(value);
		}

		[Token(Token = "0x6000184")]
		[Address(RVA = "0xBDED7C", Offset = "0xBDED7C", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredInt::InternalDecrypt(this);\n\treturnVal1 = System.Int32::CompareTo(&v6 @ X0_v1 (System.Int32), other);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int CompareTo(int other)
		{
			return InternalDecrypt().CompareTo(other);
		}

		[Token(Token = "0x6000185")]
		[Address(RVA = "0xBDEDAC", Offset = "0xBDEDAC", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredInt::InternalDecrypt(this);\n\treturnVal1 = System.Int32::CompareTo(&v6 @ X0_v1 (System.Int32), obj);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int CompareTo(object obj)
		{
			return InternalDecrypt().CompareTo(obj);
		}

		[Obsolete("This API is redundant and does not perform any actions. It will be removed in future updates.")]
		[Token(Token = "0x6000186")]
		[Address(RVA = "0xBDEDDC", Offset = "0xBDEDDC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public static void SetNewCryptoKey(int newKey)
		{
		}

		[Obsolete("This API is redundant and does not perform any actions. It will be removed in future updates.")]
		[Token(Token = "0x6000187")]
		[Address(RVA = "0xBDEDE0", Offset = "0xBDEDE0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void ApplyNewCryptoKey()
		{
		}

		[Obsolete("Please use new Encrypt(value, key) API instead.", true)]
		[Token(Token = "0x6000188")]
		[Address(RVA = "0xBDEDE4", Offset = "0xBDEDE4", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int Encrypt(int value)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new Decrypt(value, key) API instead.", true)]
		[Token(Token = "0x6000189")]
		[Address(RVA = "0xBDEE1C", Offset = "0xBDEE1C", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int Decrypt(int value)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new FromEncrypted(encrypted, key) API instead.", true)]
		[Token(Token = "0x600018A")]
		[Address(RVA = "0xBDEE54", Offset = "0xBDEE54", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ObscuredInt FromEncrypted(int encrypted)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new GetEncrypted(out key) API instead.", true)]
		[Token(Token = "0x600018B")]
		[Address(RVA = "0xBDEE8C", Offset = "0xBDEE8C", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int GetEncrypted()
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new SetEncrypted(encrypted, key) API instead.", true)]
		[Token(Token = "0x600018C")]
		[Address(RVA = "0xBDEEC4", Offset = "0xBDEEC4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetEncrypted(int encrypted)
		{
		}
	}
}
