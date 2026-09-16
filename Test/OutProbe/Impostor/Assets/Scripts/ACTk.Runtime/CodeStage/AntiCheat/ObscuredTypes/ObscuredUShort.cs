using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using CodeStage.AntiCheat.Common;
using CodeStage.AntiCheat.Detectors;
using CodeStage.AntiCheat.Utils;
using Cpp2ILInjected;

namespace CodeStage.AntiCheat.ObscuredTypes
{
	[Serializable]
	[Token(Token = "0x2000021")]
	public struct ObscuredUShort : IObscuredType, IFormattable, IEquatable<ObscuredUShort>, IComparable<ObscuredUShort>, IComparable<ushort>, IComparable
	{
		[Token(Token = "0x40000A7")]
		[FieldOffset(Offset = "0x0")]
		private ushort currentCryptoKey;

		[Token(Token = "0x40000A8")]
		[FieldOffset(Offset = "0x2")]
		private ushort hiddenValue;

		[Token(Token = "0x40000A9")]
		[FieldOffset(Offset = "0x4")]
		private bool inited;

		[Token(Token = "0x40000AA")]
		[FieldOffset(Offset = "0x6")]
		private ushort fakeValue;

		[Token(Token = "0x40000AB")]
		[FieldOffset(Offset = "0x8")]
		private bool fakeValueActive;

		[Token(Token = "0x6000279")]
		[Address(RVA = "0xBE2968", Offset = "0xBE2968", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateUShortKey();\n\tthis.currentCryptoKey = v10;\n\tv11 = v10 ^ value;\n\tthis.hiddenValue = v11;\n\tv13 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv16 = v13 == 0;\n\tv20 = ~v16;\n\tv21 = ~v20;\n\tif (v21) goto L_FFFFFFFF;\n\tgoto L_0019;\nL_0019:\n\tthis.fakeValueActive = v13;\n\tthis.fakeValue = v24;\n\tthis.inited = 1;\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private ObscuredUShort(ushort value)
		{
			int num = (currentCryptoKey = RandomUtils.GenerateUShortKey()) ^ value;
			hiddenValue = (ushort)num;
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			ushort num2 = (ushort)(existsAndIsRunning ? value : 0);
			fakeValueActive = existsAndIsRunning;
			fakeValue = num2;
			inited = true;
		}

		[Token(Token = "0x600027A")]
		[Address(RVA = "0xBE29B8", Offset = "0xBE29B8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = key ^ value;\n\treturn returnVal1;\n")]
		public static ushort Encrypt(ushort value, ushort key)
		{
			return (ushort)(key ^ value);
		}

		[Token(Token = "0x600027B")]
		[Address(RVA = "0xBE29C0", Offset = "0xBE29C0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = key ^ value;\n\treturn returnVal1;\n")]
		public static ushort Decrypt(ushort value, ushort key)
		{
			return (ushort)(key ^ value);
		}

		[Token(Token = "0x600027C")]
		[Address(RVA = "0xBE29C8", Offset = "0xBE29C8", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = 0;\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredUShort::SetEncrypted(&v7 @ stack_-20_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredUShort), encrypted, key);\n\treturn 0;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ObscuredUShort FromEncrypted(ushort encrypted, ushort key)
		{
			default(ObscuredUShort).SetEncrypted(encrypted, key);
			return default(ObscuredUShort);
		}

		[Token(Token = "0x600027D")]
		[Address(RVA = "0xBE29B4", Offset = "0xBE29B4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateUShortKey();\n\treturn returnVal1;\n")]
		public static ushort GenerateKey()
		{
			return RandomUtils.GenerateUShortKey();
		}

		[Token(Token = "0x600027E")]
		[Address(RVA = "0xBE2A44", Offset = "0xBE2A44", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([key @ X1 (System.UInt16&)]) = this.currentCryptoKey;\n\treturn this.hiddenValue;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe ushort GetEncrypted(out ushort key)
		{
			key = default(ushort);
			ref ushort reference = ref *(ushort*)currentCryptoKey;
			return hiddenValue;
		}

		[Token(Token = "0x600027F")]
		[Address(RVA = "0xBE29FC", Offset = "0xBE29FC", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.hiddenValue = encrypted;\n\tthis.inited = 1;\n\tthis.currentCryptoKey = key;\n\tv12 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tthis.fakeValueActive = 0;\n\tv14 = v12 == 0;\n\tif (v14) goto L_0017;\n\tv16 = CodeStage.AntiCheat.ObscuredTypes.ObscuredUShort::InternalDecrypt(this);\n\tthis.fakeValue = v16;\n\tthis.fakeValueActive = 1;\nL_0017:\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetEncrypted(ushort encrypted, ushort key)
		{
			hiddenValue = encrypted;
			inited = true;
			currentCryptoKey = key;
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			fakeValueActive = false;
			if (existsAndIsRunning)
			{
				ushort num = InternalDecrypt();
				fakeValue = num;
				fakeValueActive = true;
			}
		}

		[Token(Token = "0x6000280")]
		[Address(RVA = "0xBE2B34", Offset = "0xBE2B34", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredUShort::InternalDecrypt(this);\n\treturn returnVal1;\n")]
		public ushort GetDecrypted()
		{
			return InternalDecrypt();
		}

		[Token(Token = "0x6000281")]
		[Address(RVA = "0xBE2B38", Offset = "0xBE2B38", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = CodeStage.AntiCheat.ObscuredTypes.ObscuredUShort::InternalDecrypt(this);\n\tv11 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateUShortKey();\n\tv12 = v11 ^ v8;\n\tthis.currentCryptoKey = v11;\n\tthis.hiddenValue = v12;\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RandomizeCryptoKey()
		{
			ushort num = InternalDecrypt();
			ushort num2 = RandomUtils.GenerateUShortKey();
			int num3 = num2 ^ num;
			currentCryptoKey = num2;
			hiddenValue = (ushort)num3;
		}

		[Token(Token = "0x6000282")]
		[Address(RVA = "0xBE2A54", Offset = "0xBE2A54", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A35495]) = v33;\nL_0011:\n\tv35 = ~v31.inited;\n\tif (v35) goto L_0044;\n\tv84 = v31.currentCryptoKey ^ v31.hiddenValue;\n\tv40 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv43 = v40 == 0;\n\tif (v43) goto L_0051;\n\tv47 = ~v31.fakeValueActive;\n\tif (v47) goto L_0051;\n\tv64 = v31.fakeValue == v84;\n\tif (v64) goto L_0051;\n\tgoto L_0039;\n\tv116 = 0xB348B0(v111, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0039:\n\tgoto L_0042;\n\tv124 = 0xB348B0(v119, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0042:\n\tv78 = CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector>::OnCheatingDetected(v106.<Instance>k__BackingField);\n\tgoto L_0051;\nL_0044:\n\tv41 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateUShortKey();\n\tv31.currentCryptoKey = v41;\n\tv31.hiddenValue = v41;\n\tv31.fakeValue = 0;\n\tv31.fakeValueActive = 0;\n\tv31.inited = 1;\nL_0051:\n\treturn v84;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private ushort InternalDecrypt()
		{
			int num;
			if (inited)
			{
				num = currentCryptoKey ^ hiddenValue;
				if (ObscuredCheatingDetector.ExistsAndIsRunning && fakeValueActive && fakeValue != num)
				{
					KeepAliveBehaviour<ObscuredCheatingDetector>.Instance.OnCheatingDetected();
				}
			}
			else
			{
				hiddenValue = (currentCryptoKey = RandomUtils.GenerateUShortKey());
				fakeValue = 0;
				fakeValueActive = false;
				inited = true;
				num = 0;
			}
			return (ushort)num;
		}

		[Token(Token = "0x6000283")]
		[Address(RVA = "0xBE2B68", Offset = "0xBE2B68", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateUShortKey();\n\tv12 = v10 ^ value;\n\tv14 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv19 = v14 == 0;\n\tv22 = value & 0xFFFF;\n\tv23 = v22 << 0x30;\n\tv25 = 0x100000000 | v23;\n\tv26 = ~v19;\n\tv27 = ~v26;\n\tif (v27) goto L_FFFFFFFF;\n\tgoto L_001E;\nL_001E:\n\tv32 = v10 & 0xFFFF;\n\tv33 = v30 & 0xFFFFFFFFFFFF0000;\n\tv34 = v33 | v32;\n\tv37 = v12 & 0xFFFF;\n\tv38 = v37 & 0xFFFF;\n\tv39 = v38 << 0x10;\n\tv40 = v34 & 0xFFFFFFFF0000FFFF;\n\tv41 = v40 | v39;\n\treturn v41;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static implicit operator ObscuredUShort(ushort value)
		{
			//IL_0061: Expected I4, but got I8
			//IL_009f: Expected I4, but got I8
			//IL_0109: Expected I4, but got I8
			//IL_011b: Expected O, but got I4
			ushort num = RandomUtils.GenerateUShortKey();
			int num2 = num ^ value;
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			bool flag = !existsAndIsRunning;
			int num3 = value & 0xFFFF;
			int num4 = num3 << 48;
			int num5 = (int)(0x100000000L | num4);
			int num6 = (int)(flag ? 4294967296L : num5);
			int num7 = num & 0xFFFF;
			int num8 = num6 & -65536;
			int num9 = num8 | num7;
			int num10 = num2 & 0xFFFF;
			int num11 = num10 & 0xFFFF;
			int num12 = num11 << 16;
			int num13 = (int)(num9 & -4294901761L);
			int num14 = num13 | num12;
			return (ObscuredUShort)num14;
		}

		[Token(Token = "0x6000284")]
		[Address(RVA = "0xBE2BBC", Offset = "0xBE2BBC", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredUShort::InternalDecrypt(&value @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredUShort));\n\treturn returnVal1;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static implicit operator ushort(ObscuredUShort value)
		{
			ObscuredUShort obscuredUShort = default(ObscuredUShort);
			return obscuredUShort.InternalDecrypt();
		}

		[Token(Token = "0x6000285")]
		[Address(RVA = "0xBE2BE0", Offset = "0xBE2BE0", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = methodInfo & 0xFFFF;\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredUShort::Increment(input, v2);\n\treturn returnVal1;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ObscuredUShort operator ++(ObscuredUShort input)
		{
			IntPtr intPtr = default(IntPtr);
			int increment = (int)((nint)intPtr & 0xFFFF);
			return Increment(input, increment);
		}

		[Token(Token = "0x6000286")]
		[Address(RVA = "0xBE2C5C", Offset = "0xBE2C5C", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = methodInfo & 0xFFFF;\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredUShort::Increment(input, v2);\n\treturn returnVal1;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ObscuredUShort operator --(ObscuredUShort input)
		{
			IntPtr intPtr = default(IntPtr);
			int increment = (int)((nint)intPtr & 0xFFFF);
			return Increment(input, increment);
		}

		[Token(Token = "0x6000287")]
		[Address(RVA = "0xBE2BFC", Offset = "0xBE2BFC", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = CodeStage.AntiCheat.ObscuredTypes.ObscuredUShort::InternalDecrypt(&v7 @ stack_-20_v2 (CodeStage.AntiCheat.ObscuredTypes.ObscuredUShort));\n\tv18 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv20 = v18 == 0;\n\tif (v20) goto L_001B;\n\tgoto L_001B;\nL_001B:\n\treturn v7;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static ObscuredUShort Increment(ObscuredUShort input, int increment)
		{
			ObscuredUShort result = default(ObscuredUShort);
			ushort num = result.InternalDecrypt();
			if (ObscuredCheatingDetector.ExistsAndIsRunning)
			{
			}
			return result;
		}

		[Token(Token = "0x6000288")]
		[Address(RVA = "0xBE2C78", Offset = "0xBE2C78", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = CodeStage.AntiCheat.ObscuredTypes.ObscuredUShort::InternalDecrypt(this);\n\treturnVal1 = System.UInt16::GetHashCode(&v2 @ X0_v1 (System.UInt16));\n\treturn returnVal1;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override int GetHashCode()
		{
			return InternalDecrypt().GetHashCode();
		}

		[Token(Token = "0x6000289")]
		[Address(RVA = "0xBE2C98", Offset = "0xBE2C98", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = CodeStage.AntiCheat.ObscuredTypes.ObscuredUShort::InternalDecrypt(this);\n\treturnVal1 = System.UInt16::ToString(&v2 @ X0_v1 (System.UInt16));\n\treturn returnVal1;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			return InternalDecrypt().ToString();
		}

		[Token(Token = "0x600028A")]
		[Address(RVA = "0xBE2CB8", Offset = "0xBE2CB8", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredUShort::InternalDecrypt(this);\n\treturnVal1 = System.UInt16::ToString(&v6 @ X0_v1 (System.UInt16), format);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string ToString(string format)
		{
			return InternalDecrypt().ToString(format);
		}

		[Token(Token = "0x600028B")]
		[Address(RVA = "0xBE2CE8", Offset = "0xBE2CE8", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredUShort::InternalDecrypt(this);\n\treturnVal1 = System.UInt16::ToString(&v6 @ X0_v1 (System.UInt16), provider);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string ToString(IFormatProvider provider)
		{
			return InternalDecrypt().ToString(provider);
		}

		[Token(Token = "0x600028C")]
		[Address(RVA = "0xBE2D18", Offset = "0xBE2D18", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = CodeStage.AntiCheat.ObscuredTypes.ObscuredUShort::InternalDecrypt(this);\n\treturnVal1 = System.UInt16::ToString(&v10 @ X0_v1 (System.UInt16), format, provider);\n\treturn returnVal1;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string ToString(string format, IFormatProvider provider)
		{
			return InternalDecrypt().ToString(format, provider);
		}

		[Token(Token = "0x600028D")]
		[Address(RVA = "0xBE2D50", Offset = "0xBE2D50", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredUShort;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, obj, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A35496]) = v36;\nL_0012:\n\tv37 = obj == 0;\n\tif (v37) goto L_0028;\n\tv46 = *([obj @ X1 (System.Object)]) == CodeStage.AntiCheat.ObscuredTypes.ObscuredUShort;\n\tif (v46) goto L_002A;\nL_0028:\n\treturn 0;\nL_002A:\n\tv76 = \"il2cpp_vm_object_unbox\"(obj, obj, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\treturnVal2 = CodeStage.AntiCheat.ObscuredTypes.ObscuredUShort::Equals(this, *([v76 @ X0_v4]));\n\treturn returnVal2;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override bool Equals(object obj)
		{
			if (obj == null || (object)obj.GetType() != typeof(ObscuredUShort))
			{
				return false;
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
			object obj2 = default(object);
			return Equals((ObscuredUShort)obj2);
		}

		[Token(Token = "0x600028E")]
		[Address(RVA = "0xBE2DCC", Offset = "0xBE2DCC", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv28 = this + 2;\n\tv7 = obj >> 0x10;\n\tv17 = this.currentCryptoKey != obj;\n\tif (v17) goto L_0013;\n\tgoto L_0018;\nL_0013:\n\tv19 = v7 ^ obj;\n\tv22 = this.hiddenValue ^ this.currentCryptoKey;\nL_0018:\n\tv31 = System.UInt16::Equals(v28, v27);\n\treturn v31;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe bool Equals(ObscuredUShort obj)
		{
			//IL_0019: Expected I4, but got O
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Expected I4, but got Unknown
			ushort num = (ushort)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 2));
			int num2 = (object)obj >> 16;
			ushort obj2;
			if ((int)currentCryptoKey == (nint)obj)
			{
				obj2 = (ushort)num2;
			}
			else
			{
				int num3 = num2 ^ obj;
				int num4 = hiddenValue ^ currentCryptoKey;
				obj2 = (ushort)num3;
				num = (ushort)(&num4);
			}
			return ((ushort*)num)->Equals(obj2);
		}

		[Token(Token = "0x600028F")]
		[Address(RVA = "0xBE2E10", Offset = "0xBE2E10", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredUShort::InternalDecrypt(this);\n\tv10 = CodeStage.AntiCheat.ObscuredTypes.ObscuredUShort::InternalDecrypt(&other @ X1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredUShort));\n\treturnVal1 = System.UInt16::CompareTo(&v6 @ X0_v1 (System.UInt16), v10);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int CompareTo(ObscuredUShort other)
		{
			ushort num = InternalDecrypt();
			ObscuredUShort obscuredUShort = default(ObscuredUShort);
			ushort value = obscuredUShort.InternalDecrypt();
			return num.CompareTo(value);
		}

		[Token(Token = "0x6000290")]
		[Address(RVA = "0xBE2E4C", Offset = "0xBE2E4C", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredUShort::InternalDecrypt(this);\n\treturnVal1 = System.UInt16::CompareTo(&v6 @ X0_v1 (System.UInt16), other);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int CompareTo(ushort other)
		{
			return InternalDecrypt().CompareTo(other);
		}

		[Token(Token = "0x6000291")]
		[Address(RVA = "0xBE2E7C", Offset = "0xBE2E7C", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredUShort::InternalDecrypt(this);\n\treturnVal1 = System.UInt16::CompareTo(&v6 @ X0_v1 (System.UInt16), obj);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int CompareTo(object obj)
		{
			return InternalDecrypt().CompareTo(obj);
		}

		[Obsolete("This API is redundant and does not perform any actions. It will be removed in future updates.")]
		[Token(Token = "0x6000292")]
		[Address(RVA = "0xBE2EAC", Offset = "0xBE2EAC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public static void SetNewCryptoKey(ushort newKey)
		{
		}

		[Obsolete("This API is redundant and does not perform any actions. It will be removed in future updates.")]
		[Token(Token = "0x6000293")]
		[Address(RVA = "0xBE2EB0", Offset = "0xBE2EB0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void ApplyNewCryptoKey()
		{
		}

		[Obsolete("Please use new Encrypt(value, key) or Decrypt(value, key) API instead.", true)]
		[Token(Token = "0x6000294")]
		[Address(RVA = "0xBE2EB4", Offset = "0xBE2EB4", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ushort EncryptDecrypt(ushort value)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new Encrypt(value, key) or Decrypt(value, key) APIs instead. This API will be removed in future updates.")]
		[Token(Token = "0x6000295")]
		[Address(RVA = "0xBE2EEC", Offset = "0xBE2EEC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = key ^ value;\n\treturn returnVal1;\n")]
		public static ushort EncryptDecrypt(ushort value, ushort key)
		{
			return (ushort)(key ^ value);
		}

		[Obsolete("Please use new FromEncrypted(encrypted, key) API instead.", true)]
		[Token(Token = "0x6000296")]
		[Address(RVA = "0xBE2EF4", Offset = "0xBE2EF4", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ObscuredUShort FromEncrypted(ushort encrypted)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new GetEncrypted(out key) API instead.", true)]
		[Token(Token = "0x6000297")]
		[Address(RVA = "0xBE2F2C", Offset = "0xBE2F2C", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ushort GetEncrypted()
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new SetEncrypted(encrypted, key) API instead.", true)]
		[Token(Token = "0x6000298")]
		[Address(RVA = "0xBE2F64", Offset = "0xBE2F64", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetEncrypted(ushort encrypted)
		{
		}
	}
}
