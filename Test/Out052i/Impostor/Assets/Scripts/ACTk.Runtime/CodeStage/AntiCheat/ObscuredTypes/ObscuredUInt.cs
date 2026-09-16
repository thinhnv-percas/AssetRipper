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
	[Token(Token = "0x200001F")]
	public struct ObscuredUInt : IObscuredType, IFormattable, IEquatable<ObscuredUInt>, IComparable<ObscuredUInt>, IComparable<uint>, IComparable
	{
		[SerializeField]
		[Token(Token = "0x400009D")]
		[FieldOffset(Offset = "0x0")]
		internal uint currentCryptoKey;

		[SerializeField]
		[Token(Token = "0x400009E")]
		[FieldOffset(Offset = "0x4")]
		internal uint hiddenValue;

		[SerializeField]
		[Token(Token = "0x400009F")]
		[FieldOffset(Offset = "0x8")]
		internal bool inited;

		[SerializeField]
		[Token(Token = "0x40000A0")]
		[FieldOffset(Offset = "0xC")]
		internal uint fakeValue;

		[SerializeField]
		[Token(Token = "0x40000A1")]
		[FieldOffset(Offset = "0x10")]
		internal bool fakeValueActive;

		[Token(Token = "0x6000238")]
		[Address(RVA = "0xBE1C2C", Offset = "0xBE1C2C", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tv11 = v10 ^ value;\n\tthis.currentCryptoKey = v10;\n\tthis.hiddenValue = v11;\n\tv13 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv16 = v13 == 0;\n\tv20 = ~v16;\n\tv21 = ~v20;\n\tif (v21) goto L_FFFFFFFF;\n\tgoto L_0019;\nL_0019:\n\tthis.fakeValueActive = v13;\n\tthis.fakeValue = v24;\n\tthis.inited = 1;\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private ObscuredUInt(uint value)
		{
			int num = RandomUtils.GenerateIntKey();
			int num2 = num ^ (int)value;
			currentCryptoKey = (uint)num;
			hiddenValue = (uint)num2;
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			uint num3 = (existsAndIsRunning ? value : 0u);
			fakeValueActive = existsAndIsRunning;
			fakeValue = num3;
			inited = true;
		}

		[Token(Token = "0x6000239")]
		[Address(RVA = "0xBE1C78", Offset = "0xBE1C78", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = key ^ value;\n\treturn returnVal1;\n")]
		public static uint Encrypt(uint value, uint key)
		{
			return key ^ value;
		}

		[Token(Token = "0x600023A")]
		[Address(RVA = "0xBE1C80", Offset = "0xBE1C80", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = key ^ value;\n\treturn returnVal1;\n")]
		public static uint Decrypt(uint value, uint key)
		{
			return key ^ value;
		}

		[Token(Token = "0x600023B")]
		[Address(RVA = "0xBE1C88", Offset = "0xBE1C88", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = 0;\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredUInt::SetEncrypted(&v9 @ stack_-28_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredUInt), encrypted, key);\n\treturnBuffer.fakeValueActive = 0;\n\treturnBuffer.currentCryptoKey = 0;\n\treturn &v9 @ stack_-28_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredUInt);\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredUInt FromEncrypted(uint encrypted, uint key)
		{
			//IL_0024: Expected native int or pointer, but got O
			//IL_0032: Expected native int or pointer, but got O
			//IL_003c: Expected O, but got Ref
			ObscuredUInt obscuredUInt = default(ObscuredUInt);
			obscuredUInt.SetEncrypted(encrypted, key);
			ObscuredUInt obscuredUInt2 = default(ObscuredUInt);
			((ObscuredUInt*)(nint)obscuredUInt2)->fakeValueActive = false;
			((ObscuredUInt*)(nint)obscuredUInt2)->currentCryptoKey = 0u;
			return (ObscuredUInt)(&obscuredUInt);
		}

		[Token(Token = "0x600023C")]
		[Address(RVA = "0xBE1C74", Offset = "0xBE1C74", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\treturn returnVal1;\n")]
		public static uint GenerateKey()
		{
			return (uint)RandomUtils.GenerateIntKey();
		}

		[Token(Token = "0x600023D")]
		[Address(RVA = "0xBE1D0C", Offset = "0xBE1D0C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([key @ X1 (System.UInt32&)]) = this.currentCryptoKey;\n\treturn this.hiddenValue;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe uint GetEncrypted(out uint key)
		{
			key = default(uint);
			ref uint reference = ref *(uint*)currentCryptoKey;
			return hiddenValue;
		}

		[Token(Token = "0x600023E")]
		[Address(RVA = "0xBE1CC8", Offset = "0xBE1CC8", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.inited = 1;\n\tthis.currentCryptoKey = key;\n\tthis.hiddenValue = encrypted;\n\tv12 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tthis.fakeValueActive = 0;\n\tv14 = v12 == 0;\n\tif (v14) goto L_0017;\n\tv16 = CodeStage.AntiCheat.ObscuredTypes.ObscuredUInt::InternalDecrypt(this);\n\tthis.fakeValue = v16;\n\tthis.fakeValueActive = 1;\nL_0017:\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetEncrypted(uint encrypted, uint key)
		{
			inited = true;
			currentCryptoKey = key;
			hiddenValue = encrypted;
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			fakeValueActive = false;
			if (existsAndIsRunning)
			{
				uint num = InternalDecrypt();
				fakeValue = num;
				fakeValueActive = true;
			}
		}

		[Token(Token = "0x600023F")]
		[Address(RVA = "0xBE1DF4", Offset = "0xBE1DF4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredUInt::InternalDecrypt(this);\n\treturn returnVal1;\n")]
		public uint GetDecrypted()
		{
			return InternalDecrypt();
		}

		[Token(Token = "0x6000240")]
		[Address(RVA = "0xBE1DF8", Offset = "0xBE1DF8", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = CodeStage.AntiCheat.ObscuredTypes.ObscuredUInt::InternalDecrypt(this);\n\tv11 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tv12 = v11 ^ v8;\n\tthis.currentCryptoKey = v11;\n\tthis.hiddenValue = v12;\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RandomizeCryptoKey()
		{
			uint num = InternalDecrypt();
			int num2 = RandomUtils.GenerateIntKey();
			int num3 = num2 ^ (int)num;
			currentCryptoKey = (uint)num2;
			hiddenValue = (uint)num3;
		}

		[Token(Token = "0x6000241")]
		[Address(RVA = "0xBE1D1C", Offset = "0xBE1D1C", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A35491]) = v33;\nL_0011:\n\tv35 = ~v31.inited;\n\tif (v35) goto L_0044;\n\tv84 = v31.currentCryptoKey ^ v31.hiddenValue;\n\tv40 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv43 = v40 == 0;\n\tif (v43) goto L_0051;\n\tv47 = ~v31.fakeValueActive;\n\tif (v47) goto L_0051;\n\tv64 = v84 == v31.fakeValue;\n\tif (v64) goto L_0051;\n\tgoto L_0039;\n\tv116 = 0xB348B0(v111, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0039:\n\tgoto L_0042;\n\tv124 = 0xB348B0(v119, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0042:\n\tv78 = CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector>::OnCheatingDetected(v106.<Instance>k__BackingField);\n\tgoto L_0051;\nL_0044:\n\tv41 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tv31.currentCryptoKey = v41;\n\tv31.hiddenValue = v41;\n\tv31.fakeValue = 0;\n\tv31.fakeValueActive = 0;\n\tv31.inited = 1;\nL_0051:\n\treturn v84;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private uint InternalDecrypt()
		{
			int num;
			if (inited)
			{
				num = (int)(currentCryptoKey ^ hiddenValue);
				if (ObscuredCheatingDetector.ExistsAndIsRunning && fakeValueActive && num != (int)fakeValue)
				{
					KeepAliveBehaviour<ObscuredCheatingDetector>.Instance.OnCheatingDetected();
				}
			}
			else
			{
				hiddenValue = (currentCryptoKey = (uint)RandomUtils.GenerateIntKey());
				fakeValue = 0u;
				fakeValueActive = false;
				inited = true;
				num = 0;
			}
			return (uint)num;
		}

		[Token(Token = "0x6000242")]
		[Address(RVA = "0xBDEA50", Offset = "0xBDEA50", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnBuffer.currentCryptoKey = 0;\n\treturnBuffer.inited = 0;\n\treturnBuffer.fakeValueActive = 0;\n\tv10 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tv11 = v10 ^ value;\n\treturnBuffer.currentCryptoKey = v10;\n\treturnBuffer.hiddenValue = v11;\n\treturnVal1 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv14 = returnVal1 & 1;\n\tv16 = v14 == 0;\n\tv20 = ~v16;\n\tv21 = ~v20;\n\tif (v21) goto L_FFFFFFFF;\n\tgoto L_001C;\nL_001C:\n\treturnBuffer.fakeValueActive = v14;\n\treturnBuffer.fakeValue = v24;\n\treturnBuffer.inited = 1;\n\treturn returnVal1;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static implicit operator ObscuredUInt(uint value)
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
			ObscuredUInt obscuredUInt = default(ObscuredUInt);
			((ObscuredUInt*)(nint)obscuredUInt)->currentCryptoKey = 0u;
			((ObscuredUInt*)(nint)obscuredUInt)->inited = false;
			((ObscuredUInt*)(nint)obscuredUInt)->fakeValueActive = false;
			int num = RandomUtils.GenerateIntKey();
			int num2 = num ^ (int)value;
			((ObscuredUInt*)(nint)obscuredUInt)->currentCryptoKey = (uint)num;
			((ObscuredUInt*)(nint)obscuredUInt)->hiddenValue = (uint)num2;
			ObscuredUInt obscuredUInt2 = (ObscuredUInt)ObscuredCheatingDetector.ExistsAndIsRunning;
			int num3 = (int)(obscuredUInt2 & 1);
			uint num4 = ((num3 != 0) ? value : 0u);
			((ObscuredUInt*)(nint)obscuredUInt)->fakeValueActive = (byte)num3 != 0;
			((ObscuredUInt*)(nint)obscuredUInt)->fakeValue = num4;
			((ObscuredUInt*)(nint)obscuredUInt)->inited = true;
			return obscuredUInt2;
		}

		[Token(Token = "0x6000243")]
		[Address(RVA = "0xBE1E24", Offset = "0xBE1E24", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredUInt::InternalDecrypt(value);\n\treturn returnVal1;\n")]
		public unsafe static implicit operator uint(ObscuredUInt value)
		{
			return ((ObscuredUInt*)value)->InternalDecrypt();
		}

		[Token(Token = "0x6000244")]
		[Address(RVA = "0xBE1E28", Offset = "0xBE1E28", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = CodeStage.AntiCheat.ObscuredTypes.ObscuredUInt::InternalDecrypt(value);\n\tv16 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tv18 = v16 ^ v12;\n\treturnVal1 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv21 = returnVal1 & 1;\n\tv23 = v21 == 0;\n\tv27 = ~v23;\n\tv28 = ~v27;\n\tif (v28) goto L_FFFFFFFF;\n\tgoto L_001B;\nL_001B:\n\treturnBuffer.currentCryptoKey = v16;\n\treturnBuffer.hiddenValue = v18;\n\t*([returnBuffer @ X8 (CodeStage.AntiCheat.ObscuredTypes.ObscuredInt)+9]) = 0;\n\t*([returnBuffer @ X8 (CodeStage.AntiCheat.ObscuredTypes.ObscuredInt)+B]) = 0;\n\t*([returnBuffer @ X8 (CodeStage.AntiCheat.ObscuredTypes.ObscuredInt)+11]) = 0;\n\treturnBuffer.inited = 1;\n\treturnBuffer.fakeValueActive = v21;\n\treturnBuffer.fakeValue = v31;\n\t*([returnBuffer @ X8 (CodeStage.AntiCheat.ObscuredTypes.ObscuredInt)+13]) = 0;\n\treturn returnVal1;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static explicit operator ObscuredInt(ObscuredUInt value)
		{
			//IL_0031: Expected O, but got I4
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Expected I4, but got Unknown
			//IL_0095: Expected native int or pointer, but got O
			//IL_00a2: Expected native int or pointer, but got O
			//IL_00c2: Expected native int or pointer, but got O
			//IL_00cf: Expected native int or pointer, but got O
			//IL_00dc: Expected native int or pointer, but got O
			uint num = ((ObscuredUInt*)value)->InternalDecrypt();
			int num2 = RandomUtils.GenerateIntKey();
			int num3 = num2 ^ (int)num;
			ObscuredInt obscuredInt = (ObscuredInt)ObscuredCheatingDetector.ExistsAndIsRunning;
			int num4 = obscuredInt & 1;
			uint num5 = ((num4 != 0) ? num : 0u);
			ObscuredInt obscuredInt2 = default(ObscuredInt);
			((ObscuredInt*)(nint)obscuredInt2)->currentCryptoKey = num2;
			((ObscuredInt*)(nint)obscuredInt2)->hiddenValue = num3;
			_ = 0;
			_ = 0;
			_ = 0;
			((ObscuredInt*)(nint)obscuredInt2)->inited = true;
			((ObscuredInt*)(nint)obscuredInt2)->fakeValueActive = (byte)num4 != 0;
			((ObscuredInt*)(nint)obscuredInt2)->fakeValue = (int)num5;
			_ = 0;
			return obscuredInt;
		}

		[Token(Token = "0x6000245")]
		[Address(RVA = "0xBE1E90", Offset = "0xBE1E90", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = input.currentCryptoKey;\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredUInt::Increment(&v8 @ V0_v1 (System.UInt32), 1);\n\treturnBuffer.fakeValueActive = returnVal1.fakeValueActive;\n\treturnBuffer.currentCryptoKey = returnVal1.currentCryptoKey;\n\treturn returnVal1;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredUInt operator ++(ObscuredUInt input)
		{
			//IL_001b: Expected O, but got Ref
			//IL_002c: Expected native int or pointer, but got O
			//IL_003e: Expected native int or pointer, but got O
			uint num = input.currentCryptoKey;
			ObscuredUInt result = Increment((ObscuredUInt)(&num), 1);
			ObscuredUInt obscuredUInt = default(ObscuredUInt);
			((ObscuredUInt*)(nint)obscuredUInt)->fakeValueActive = result.fakeValueActive;
			((ObscuredUInt*)(nint)obscuredUInt)->currentCryptoKey = result.currentCryptoKey;
			return result;
		}

		[Token(Token = "0x6000246")]
		[Address(RVA = "0xBE1F3C", Offset = "0xBE1F3C", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = input.currentCryptoKey;\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredUInt::Increment(&v8 @ V0_v1 (System.UInt32), 0xFFFFFFFF);\n\treturnBuffer.fakeValueActive = returnVal1.fakeValueActive;\n\treturnBuffer.currentCryptoKey = returnVal1.currentCryptoKey;\n\treturn returnVal1;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredUInt operator --(ObscuredUInt input)
		{
			//IL_001b: Expected O, but got Ref
			//IL_002c: Expected native int or pointer, but got O
			//IL_003e: Expected native int or pointer, but got O
			uint num = input.currentCryptoKey;
			ObscuredUInt result = Increment((ObscuredUInt)(&num), -1);
			ObscuredUInt obscuredUInt = default(ObscuredUInt);
			((ObscuredUInt*)(nint)obscuredUInt)->fakeValueActive = result.fakeValueActive;
			((ObscuredUInt*)(nint)obscuredUInt)->currentCryptoKey = result.currentCryptoKey;
			return result;
		}

		[Token(Token = "0x6000247")]
		[Address(RVA = "0xBE1ED8", Offset = "0xBE1ED8", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = CodeStage.AntiCheat.ObscuredTypes.ObscuredUInt::InternalDecrypt(input);\n\tv16 = v14 + increment;\n\tv18 = input.currentCryptoKey ^ v16;\n\tinput.hiddenValue = v18;\n\treturnVal1 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv20 = returnVal1 & 1;\n\tv21 = v20 == 0;\n\tif (v21) goto L_FFFFFFFF;\n\tinput.fakeValue = v16;\n\tgoto L_0016;\nL_0016:\n\tinput.fakeValueActive = v24;\n\treturnBuffer.fakeValueActive = input.fakeValueActive;\n\treturnBuffer.currentCryptoKey = input.currentCryptoKey;\n\treturn returnVal1;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe static ObscuredUInt Increment(ObscuredUInt input, int increment)
		{
			//IL_0034: Expected native int or pointer, but got O
			//IL_0042: Expected O, but got I4
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Expected I4, but got Unknown
			//IL_00a3: Expected native int or pointer, but got O
			//IL_00b5: Expected native int or pointer, but got O
			//IL_00c7: Expected native int or pointer, but got O
			//IL_007a: Expected native int or pointer, but got O
			uint num = ((ObscuredUInt*)input)->InternalDecrypt();
			int num2 = (int)num + increment;
			int num3 = (int)input.currentCryptoKey ^ num2;
			((ObscuredUInt*)(nint)input)->hiddenValue = (uint)num3;
			ObscuredUInt obscuredUInt = (ObscuredUInt)ObscuredCheatingDetector.ExistsAndIsRunning;
			bool flag;
			if ((int)(obscuredUInt & 1) != 0)
			{
				((ObscuredUInt*)(nint)input)->fakeValue = (uint)num2;
				flag = true;
			}
			else
			{
				flag = false;
			}
			((ObscuredUInt*)(nint)input)->fakeValueActive = flag;
			ObscuredUInt obscuredUInt2 = default(ObscuredUInt);
			((ObscuredUInt*)(nint)obscuredUInt2)->fakeValueActive = input.fakeValueActive;
			((ObscuredUInt*)(nint)obscuredUInt2)->currentCryptoKey = input.currentCryptoKey;
			return obscuredUInt;
		}

		[Token(Token = "0x6000248")]
		[Address(RVA = "0xBE1F84", Offset = "0xBE1F84", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = CodeStage.AntiCheat.ObscuredTypes.ObscuredUInt::InternalDecrypt(this);\n\treturnVal1 = System.UInt32::GetHashCode(&v2 @ X0_v1 (System.UInt32));\n\treturn returnVal1;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override int GetHashCode()
		{
			return InternalDecrypt().GetHashCode();
		}

		[Token(Token = "0x6000249")]
		[Address(RVA = "0xBE1FA4", Offset = "0xBE1FA4", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = CodeStage.AntiCheat.ObscuredTypes.ObscuredUInt::InternalDecrypt(this);\n\treturnVal1 = System.UInt32::ToString(&v2 @ X0_v1 (System.UInt32));\n\treturn returnVal1;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			return InternalDecrypt().ToString();
		}

		[Token(Token = "0x600024A")]
		[Address(RVA = "0xBE1FC4", Offset = "0xBE1FC4", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredUInt::InternalDecrypt(this);\n\treturnVal1 = System.UInt32::ToString(&v6 @ X0_v1 (System.UInt32), format);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string ToString(string format)
		{
			return InternalDecrypt().ToString(format);
		}

		[Token(Token = "0x600024B")]
		[Address(RVA = "0xBE1FF4", Offset = "0xBE1FF4", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredUInt::InternalDecrypt(this);\n\treturnVal1 = System.UInt32::ToString(&v6 @ X0_v1 (System.UInt32), provider);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string ToString(IFormatProvider provider)
		{
			return InternalDecrypt().ToString(provider);
		}

		[Token(Token = "0x600024C")]
		[Address(RVA = "0xBE2024", Offset = "0xBE2024", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = CodeStage.AntiCheat.ObscuredTypes.ObscuredUInt::InternalDecrypt(this);\n\treturnVal1 = System.UInt32::ToString(&v10 @ X0_v1 (System.UInt32), format, provider);\n\treturn returnVal1;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string ToString(string format, IFormatProvider provider)
		{
			return InternalDecrypt().ToString(format, provider);
		}

		[Token(Token = "0x600024D")]
		[Address(RVA = "0xBE205C", Offset = "0xBE205C", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredUInt;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, obj, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A35492]) = v36;\nL_0012:\n\tv37 = obj == 0;\n\tif (v37) goto L_FFFFFFFF;\n\tv46 = *([obj @ X1 (System.Object)]) == CodeStage.AntiCheat.ObscuredTypes.ObscuredUInt;\n\tif (v46) goto L_0025;\n\tgoto L_0033;\nL_0025:\n\tv72 = \"il2cpp_vm_object_unbox\"(obj, obj, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv26 = *([v72 @ X0_v6]);\n\tv92 = CodeStage.AntiCheat.ObscuredTypes.ObscuredUInt::Equals(this, &v26 @ V0);\nL_0033:\n\treturn v92;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override bool Equals(object obj)
		{
			//IL_0056: Expected O, but got Ref
			if (obj == null || (object)obj.GetType() != typeof(ObscuredUInt))
			{
				return false;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
			object obj3 = default(object);
			object obj2 = obj3;
			return Equals((ObscuredUInt)(&obj2));
		}

		[Token(Token = "0x600024E")]
		[Address(RVA = "0xBE20EC", Offset = "0xBE20EC", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv29 = this + 4;\n\tv16 = this.currentCryptoKey != obj.currentCryptoKey;\n\tif (v16) goto L_0014;\n\tv28 = obj.hiddenValue;\n\tgoto L_0019;\nL_0014:\n\tv21 = this.hiddenValue ^ this.currentCryptoKey;\n\tv23 = obj.hiddenValue ^ obj.currentCryptoKey;\nL_0019:\n\tv32 = System.UInt32::Equals(v29, v28);\n\treturn v32;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe bool Equals(ObscuredUInt obj)
		{
			uint num = (uint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 4));
			uint obj2;
			if (currentCryptoKey == obj.currentCryptoKey)
			{
				obj2 = obj.hiddenValue;
			}
			else
			{
				int num2 = (int)(hiddenValue ^ currentCryptoKey);
				int num3 = (int)(obj.hiddenValue ^ obj.currentCryptoKey);
				obj2 = (uint)num3;
				num = (uint)(&num2);
			}
			return ((uint*)num)->Equals(obj2);
		}

		[Token(Token = "0x600024F")]
		[Address(RVA = "0xBE2134", Offset = "0xBE2134", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredUInt::InternalDecrypt(this);\n\tv10 = CodeStage.AntiCheat.ObscuredTypes.ObscuredUInt::InternalDecrypt(other);\n\treturnVal1 = System.UInt32::CompareTo(&v6 @ X0_v1 (System.UInt32), v10);\n\treturn returnVal1;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe int CompareTo(ObscuredUInt other)
		{
			uint num = InternalDecrypt();
			uint value = ((ObscuredUInt*)other)->InternalDecrypt();
			return num.CompareTo(value);
		}

		[Token(Token = "0x6000250")]
		[Address(RVA = "0xBE216C", Offset = "0xBE216C", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredUInt::InternalDecrypt(this);\n\treturnVal1 = System.UInt32::CompareTo(&v6 @ X0_v1 (System.UInt32), other);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int CompareTo(uint other)
		{
			return InternalDecrypt().CompareTo(other);
		}

		[Token(Token = "0x6000251")]
		[Address(RVA = "0xBE219C", Offset = "0xBE219C", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredUInt::InternalDecrypt(this);\n\treturnVal1 = System.UInt32::CompareTo(&v6 @ X0_v1 (System.UInt32), obj);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int CompareTo(object obj)
		{
			return InternalDecrypt().CompareTo(obj);
		}

		[Obsolete("This API is redundant and does not perform any actions. It will be removed in future updates.")]
		[Token(Token = "0x6000252")]
		[Address(RVA = "0xBE21CC", Offset = "0xBE21CC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public static void SetNewCryptoKey(uint newKey)
		{
		}

		[Obsolete("This API is redundant and does not perform any actions. It will be removed in future updates.")]
		[Token(Token = "0x6000253")]
		[Address(RVA = "0xBE21D0", Offset = "0xBE21D0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void ApplyNewCryptoKey()
		{
		}

		[Obsolete("Please use new Encrypt(value, key) API instead.", true)]
		[Token(Token = "0x6000254")]
		[Address(RVA = "0xBE21D4", Offset = "0xBE21D4", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int Encrypt(uint value)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new Decrypt(value, key) API instead.", true)]
		[Token(Token = "0x6000255")]
		[Address(RVA = "0xBE220C", Offset = "0xBE220C", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int Decrypt(uint value)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new FromEncrypted(encrypted, key) API instead.", true)]
		[Token(Token = "0x6000256")]
		[Address(RVA = "0xBE2244", Offset = "0xBE2244", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ObscuredUInt FromEncrypted(uint encrypted)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new GetEncrypted(out key) API instead.", true)]
		[Token(Token = "0x6000257")]
		[Address(RVA = "0xBE227C", Offset = "0xBE227C", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public uint GetEncrypted()
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new SetEncrypted(encrypted, key) API instead.", true)]
		[Token(Token = "0x6000258")]
		[Address(RVA = "0xBE22B4", Offset = "0xBE22B4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetEncrypted(uint encrypted)
		{
		}
	}
}
