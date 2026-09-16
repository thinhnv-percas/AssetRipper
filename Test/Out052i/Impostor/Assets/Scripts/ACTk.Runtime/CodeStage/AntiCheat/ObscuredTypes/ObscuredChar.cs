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
	[Token(Token = "0x2000011")]
	public struct ObscuredChar : IObscuredType, IEquatable<ObscuredChar>, IComparable<ObscuredChar>, IComparable<char>, IComparable
	{
		[Token(Token = "0x4000058")]
		[FieldOffset(Offset = "0x0")]
		private char currentCryptoKey;

		[Token(Token = "0x4000059")]
		[FieldOffset(Offset = "0x2")]
		private char hiddenValue;

		[Token(Token = "0x400005A")]
		[FieldOffset(Offset = "0x4")]
		private bool inited;

		[Token(Token = "0x400005B")]
		[FieldOffset(Offset = "0x6")]
		private char fakeValue;

		[Token(Token = "0x400005C")]
		[FieldOffset(Offset = "0x8")]
		private bool fakeValueActive;

		[Token(Token = "0x60000D1")]
		[Address(RVA = "0xBDBE54", Offset = "0xBDBE54", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateCharKey();\n\tthis.currentCryptoKey = v10;\n\tv11 = v10 ^ value;\n\tthis.hiddenValue = v11;\n\tv13 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv16 = v13 == 0;\n\tv20 = ~v16;\n\tv21 = ~v20;\n\tif (v21) goto L_FFFFFFFF;\n\tgoto L_0019;\nL_0019:\n\tthis.fakeValueActive = v13;\n\tthis.fakeValue = v24;\n\tthis.inited = 1;\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private ObscuredChar(char value)
		{
			int num = (currentCryptoKey = RandomUtils.GenerateCharKey()) ^ value;
			hiddenValue = (char)num;
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			char c = (existsAndIsRunning ? value : '\0');
			fakeValueActive = existsAndIsRunning;
			fakeValue = c;
			inited = true;
		}

		[Token(Token = "0x60000D2")]
		[Address(RVA = "0xBDBEA4", Offset = "0xBDBEA4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = key ^ value;\n\treturn returnVal1;\n")]
		public static char Encrypt(char value, char key)
		{
			return (char)(key ^ value);
		}

		[Token(Token = "0x60000D3")]
		[Address(RVA = "0xBDBEAC", Offset = "0xBDBEAC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = key ^ value;\n\treturn returnVal1;\n")]
		public static char Decrypt(char value, char key)
		{
			return (char)(key ^ value);
		}

		[Token(Token = "0x60000D4")]
		[Address(RVA = "0xBDBEB4", Offset = "0xBDBEB4", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = 0;\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredChar::SetEncrypted(&v7 @ stack_-20_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredChar), encrypted, key);\n\treturn 0;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ObscuredChar FromEncrypted(char encrypted, char key)
		{
			default(ObscuredChar).SetEncrypted(encrypted, key);
			return default(ObscuredChar);
		}

		[Token(Token = "0x60000D5")]
		[Address(RVA = "0xBDBEA0", Offset = "0xBDBEA0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateCharKey();\n\treturn returnVal1;\n")]
		public static char GenerateKey()
		{
			return RandomUtils.GenerateCharKey();
		}

		[Token(Token = "0x60000D6")]
		[Address(RVA = "0xBDBF30", Offset = "0xBDBF30", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([key @ X1 (System.Char&)]) = this.currentCryptoKey;\n\treturn this.hiddenValue;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe char GetEncrypted(out char key)
		{
			key = default(char);
			ref char reference = ref *(char*)(ushort)currentCryptoKey;
			return hiddenValue;
		}

		[Token(Token = "0x60000D7")]
		[Address(RVA = "0xBDBEE8", Offset = "0xBDBEE8", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.hiddenValue = encrypted;\n\tthis.inited = 1;\n\tthis.currentCryptoKey = key;\n\tv12 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tthis.fakeValueActive = 0;\n\tv14 = v12 == 0;\n\tif (v14) goto L_0017;\n\tv16 = CodeStage.AntiCheat.ObscuredTypes.ObscuredChar::InternalDecrypt(this);\n\tthis.fakeValue = v16;\n\tthis.fakeValueActive = 1;\nL_0017:\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetEncrypted(char encrypted, char key)
		{
			hiddenValue = encrypted;
			inited = true;
			currentCryptoKey = key;
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			fakeValueActive = false;
			if (existsAndIsRunning)
			{
				char c = InternalDecrypt();
				fakeValue = c;
				fakeValueActive = true;
			}
		}

		[Token(Token = "0x60000D8")]
		[Address(RVA = "0xBDC020", Offset = "0xBDC020", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredChar::InternalDecrypt(this);\n\treturn returnVal1;\n")]
		public char GetDecrypted()
		{
			return InternalDecrypt();
		}

		[Token(Token = "0x60000D9")]
		[Address(RVA = "0xBDC024", Offset = "0xBDC024", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = CodeStage.AntiCheat.ObscuredTypes.ObscuredChar::InternalDecrypt(this);\n\tv11 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateCharKey();\n\tv12 = v11 ^ v8;\n\tthis.currentCryptoKey = v11;\n\tthis.hiddenValue = v12;\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RandomizeCryptoKey()
		{
			char c = InternalDecrypt();
			char c2 = RandomUtils.GenerateCharKey();
			int num = c2 ^ c;
			currentCryptoKey = c2;
			hiddenValue = (char)num;
		}

		[Token(Token = "0x60000DA")]
		[Address(RVA = "0xBDBF40", Offset = "0xBDBF40", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A35454]) = v33;\nL_0011:\n\tv35 = ~v31.inited;\n\tif (v35) goto L_0044;\n\tv84 = v31.currentCryptoKey ^ v31.hiddenValue;\n\tv40 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv43 = v40 == 0;\n\tif (v43) goto L_0051;\n\tv47 = ~v31.fakeValueActive;\n\tif (v47) goto L_0051;\n\tv64 = v31.fakeValue == v84;\n\tif (v64) goto L_0051;\n\tgoto L_0039;\n\tv116 = 0xB348B0(v111, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0039:\n\tgoto L_0042;\n\tv124 = 0xB348B0(v119, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0042:\n\tv78 = CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector>::OnCheatingDetected(v106.<Instance>k__BackingField);\n\tgoto L_0051;\nL_0044:\n\tv41 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateCharKey();\n\tv31.currentCryptoKey = v41;\n\tv31.hiddenValue = v41;\n\tv31.fakeValue = 0;\n\tv31.fakeValueActive = 0;\n\tv31.inited = 1;\nL_0051:\n\treturn v84;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private char InternalDecrypt()
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
				hiddenValue = (currentCryptoKey = RandomUtils.GenerateCharKey());
				fakeValue = '\0';
				fakeValueActive = false;
				inited = true;
				num = 0;
			}
			return (char)num;
		}

		[Token(Token = "0x60000DB")]
		[Address(RVA = "0xBDC054", Offset = "0xBDC054", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateCharKey();\n\tv12 = v10 ^ value;\n\tv14 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv19 = v14 == 0;\n\tv22 = value & 0xFFFF;\n\tv23 = v22 << 0x30;\n\tv25 = 0x100000000 | v23;\n\tv26 = ~v19;\n\tv27 = ~v26;\n\tif (v27) goto L_FFFFFFFF;\n\tgoto L_001E;\nL_001E:\n\tv32 = v10 & 0xFFFF;\n\tv33 = v30 & 0xFFFFFFFFFFFF0000;\n\tv34 = v33 | v32;\n\tv37 = v12 & 0xFFFF;\n\tv38 = v37 & 0xFFFF;\n\tv39 = v38 << 0x10;\n\tv40 = v34 & 0xFFFFFFFF0000FFFF;\n\tv41 = v40 | v39;\n\treturn v41;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static implicit operator ObscuredChar(char value)
		{
			//IL_0061: Expected I4, but got I8
			//IL_009f: Expected I4, but got I8
			//IL_0109: Expected I4, but got I8
			//IL_011b: Expected O, but got I4
			char c = RandomUtils.GenerateCharKey();
			int num = c ^ value;
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			bool flag = !existsAndIsRunning;
			int num2 = value & 0xFFFF;
			int num3 = num2 << 48;
			int num4 = (int)(0x100000000L | num3);
			int num5 = (int)(flag ? 4294967296L : num4);
			int num6 = c & 0xFFFF;
			int num7 = num5 & -65536;
			int num8 = num7 | num6;
			int num9 = num & 0xFFFF;
			int num10 = num9 & 0xFFFF;
			int num11 = num10 << 16;
			int num12 = (int)(num8 & -4294901761L);
			int num13 = num12 | num11;
			return (ObscuredChar)num13;
		}

		[Token(Token = "0x60000DC")]
		[Address(RVA = "0xBDC0A8", Offset = "0xBDC0A8", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredChar::InternalDecrypt(&value @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredChar));\n\treturn returnVal1;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static implicit operator char(ObscuredChar value)
		{
			ObscuredChar obscuredChar = default(ObscuredChar);
			return obscuredChar.InternalDecrypt();
		}

		[Token(Token = "0x60000DD")]
		[Address(RVA = "0xBDC0CC", Offset = "0xBDC0CC", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = methodInfo & 0xFFFF;\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredChar::Increment(input, v2);\n\treturn returnVal1;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ObscuredChar operator ++(ObscuredChar input)
		{
			IntPtr intPtr = default(IntPtr);
			int increment = (int)((nint)intPtr & 0xFFFF);
			return Increment(input, increment);
		}

		[Token(Token = "0x60000DE")]
		[Address(RVA = "0xBDC148", Offset = "0xBDC148", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = methodInfo & 0xFFFF;\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredChar::Increment(input, v2);\n\treturn returnVal1;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ObscuredChar operator --(ObscuredChar input)
		{
			IntPtr intPtr = default(IntPtr);
			int increment = (int)((nint)intPtr & 0xFFFF);
			return Increment(input, increment);
		}

		[Token(Token = "0x60000DF")]
		[Address(RVA = "0xBDC0E8", Offset = "0xBDC0E8", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = CodeStage.AntiCheat.ObscuredTypes.ObscuredChar::InternalDecrypt(&v7 @ stack_-20_v2 (CodeStage.AntiCheat.ObscuredTypes.ObscuredChar));\n\tv18 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv20 = v18 == 0;\n\tif (v20) goto L_001B;\n\tgoto L_001B;\nL_001B:\n\treturn v7;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static ObscuredChar Increment(ObscuredChar input, int increment)
		{
			ObscuredChar result = default(ObscuredChar);
			char c = result.InternalDecrypt();
			if (ObscuredCheatingDetector.ExistsAndIsRunning)
			{
			}
			return result;
		}

		[Token(Token = "0x60000E0")]
		[Address(RVA = "0xBDC164", Offset = "0xBDC164", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = System.Char;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35455]) = v37;\nL_0014:\n\tv39 = CodeStage.AntiCheat.ObscuredTypes.ObscuredChar::InternalDecrypt(this);\n\tgoto L_001F;\n\tv45 = v40;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001F:\n\treturnVal1 = System.Char::GetHashCode(&v39 @ X0_v3 (System.Char));\n\treturn returnVal1;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override int GetHashCode()
		{
			return InternalDecrypt().GetHashCode();
		}

		[Token(Token = "0x60000E1")]
		[Address(RVA = "0xBDC1D8", Offset = "0xBDC1D8", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = System.Char;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35456]) = v37;\nL_0014:\n\tv39 = CodeStage.AntiCheat.ObscuredTypes.ObscuredChar::InternalDecrypt(this);\n\tgoto L_001F;\n\tv45 = v40;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001F:\n\treturnVal1 = System.Char::ToString(&v39 @ X0_v3 (System.Char));\n\treturn returnVal1;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			return InternalDecrypt().ToString();
		}

		[Token(Token = "0x60000E2")]
		[Address(RVA = "0xBDC24C", Offset = "0xBDC24C", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = System.Char;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, provider, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A35457]) = v40;\nL_0016:\n\tv42 = CodeStage.AntiCheat.ObscuredTypes.ObscuredChar::InternalDecrypt(this);\n\tgoto L_0022;\n\tv48 = v43;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v48, provider, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0022:\n\treturnVal1 = System.Char::ToString(&v42 @ X0_v3 (System.Char), provider);\n\treturn returnVal1;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string ToString(IFormatProvider provider)
		{
			return InternalDecrypt().ToString(provider);
		}

		[Token(Token = "0x60000E3")]
		[Address(RVA = "0xBDC2C8", Offset = "0xBDC2C8", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredChar;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, obj, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A35458]) = v36;\nL_0012:\n\tv37 = obj == 0;\n\tif (v37) goto L_0028;\n\tv46 = *([obj @ X1 (System.Object)]) == CodeStage.AntiCheat.ObscuredTypes.ObscuredChar;\n\tif (v46) goto L_002A;\nL_0028:\n\treturn 0;\nL_002A:\n\tv76 = \"il2cpp_vm_object_unbox\"(obj, obj, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\treturnVal2 = CodeStage.AntiCheat.ObscuredTypes.ObscuredChar::Equals(this, *([v76 @ X0_v4]));\n\treturn returnVal2;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override bool Equals(object obj)
		{
			if (obj == null || (object)obj.GetType() != typeof(ObscuredChar))
			{
				return false;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
			object obj2 = default(object);
			return Equals((ObscuredChar)obj2);
		}

		[Token(Token = "0x60000E4")]
		[Address(RVA = "0xBDC344", Offset = "0xBDC344", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = System.Char;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, obj, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A35459]) = v36;\nL_0013:\n\tv38 = this + 2;\n\tv41 = obj >> 0x10;\n\tv51 = this.currentCryptoKey != obj;\n\tif (v51) goto L_002D;\n\tgoto L_FFFFFFFF;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v52, obj, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tgoto L_0038;\nL_002D:\n\tv58 = v41 ^ obj;\n\tv59 = this.hiddenValue ^ this.currentCryptoKey;\n\tgoto L_FFFFFFFF;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v57, obj, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0038:\n\tv82 = System.Char::Equals(v77, v76);\n\treturn v82;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe bool Equals(ObscuredChar obj)
		{
			//IL_0070: Expected I4, but got O
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Expected I4, but got Unknown
			char c = (char)(ushort)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 2));
			int num = (object)obj >> 16;
			char obj2;
			char c2;
			if ((int)currentCryptoKey == (nint)obj)
			{
				obj2 = (char)num;
				c2 = c;
			}
			else
			{
				int num2 = num ^ obj;
				int num3 = hiddenValue ^ currentCryptoKey;
				obj2 = (char)num2;
				c2 = (char)(ushort)(&num3);
			}
			return ((char*)(ushort)c2)->Equals(obj2);
		}

		[Token(Token = "0x60000E5")]
		[Address(RVA = "0xBDC3F0", Offset = "0xBDC3F0", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = System.Char;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, other, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A3545A]) = v39;\nL_0016:\n\tv41 = CodeStage.AntiCheat.ObscuredTypes.ObscuredChar::InternalDecrypt(this);\n\tv44 = CodeStage.AntiCheat.ObscuredTypes.ObscuredChar::InternalDecrypt(&other @ X1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredChar));\n\tgoto L_0025;\n\tv50 = v45;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v50, other, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0025:\n\treturnVal1 = System.Char::CompareTo(&v41 @ X0_v3 (System.Char), v44);\n\treturn returnVal1;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int CompareTo(ObscuredChar other)
		{
			char c = InternalDecrypt();
			ObscuredChar obscuredChar = default(ObscuredChar);
			char value = obscuredChar.InternalDecrypt();
			return c.CompareTo(value);
		}

		[Token(Token = "0x60000E6")]
		[Address(RVA = "0xBDC47C", Offset = "0xBDC47C", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = System.Char;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, other, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A3545B]) = v40;\nL_0016:\n\tv42 = CodeStage.AntiCheat.ObscuredTypes.ObscuredChar::InternalDecrypt(this);\n\tgoto L_0022;\n\tv48 = v43;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v48, other, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0022:\n\treturnVal1 = System.Char::CompareTo(&v42 @ X0_v3 (System.Char), other);\n\treturn returnVal1;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int CompareTo(char other)
		{
			return InternalDecrypt().CompareTo(other);
		}

		[Token(Token = "0x60000E7")]
		[Address(RVA = "0xBDC4F8", Offset = "0xBDC4F8", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = System.Char;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, obj, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A3545C]) = v40;\nL_0016:\n\tv42 = CodeStage.AntiCheat.ObscuredTypes.ObscuredChar::InternalDecrypt(this);\n\tgoto L_0022;\n\tv48 = v43;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v48, obj, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0022:\n\treturnVal1 = System.Char::CompareTo(&v42 @ X0_v3 (System.Char), obj);\n\treturn returnVal1;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int CompareTo(object obj)
		{
			return InternalDecrypt().CompareTo(obj);
		}

		[Obsolete("This API is redundant and does not perform any actions. It will be removed in future updates.")]
		[Token(Token = "0x60000E8")]
		[Address(RVA = "0xBDC574", Offset = "0xBDC574", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public static void SetNewCryptoKey(char newKey)
		{
		}

		[Obsolete("This API is redundant and does not perform any actions. It will be removed in future updates.")]
		[Token(Token = "0x60000E9")]
		[Address(RVA = "0xBDC578", Offset = "0xBDC578", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void ApplyNewCryptoKey()
		{
		}

		[Obsolete("Please use new Encrypt(value, key) or Decrypt(value, key) API instead.", true)]
		[Token(Token = "0x60000EA")]
		[Address(RVA = "0xBDC57C", Offset = "0xBDC57C", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static char EncryptDecrypt(char value)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new Encrypt(value, key) or Decrypt(value, key) APIs instead. This API will be removed in future updates.")]
		[Token(Token = "0x60000EB")]
		[Address(RVA = "0xBDC5B4", Offset = "0xBDC5B4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = key ^ value;\n\treturn returnVal1;\n")]
		public static char EncryptDecrypt(char value, char key)
		{
			return (char)(key ^ value);
		}

		[Obsolete("Please use new FromEncrypted(encrypted, key) API instead.", true)]
		[Token(Token = "0x60000EC")]
		[Address(RVA = "0xBDC5BC", Offset = "0xBDC5BC", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ObscuredChar FromEncrypted(char encrypted)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new GetEncrypted(out key) API instead.", true)]
		[Token(Token = "0x60000ED")]
		[Address(RVA = "0xBDC5F4", Offset = "0xBDC5F4", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public char GetEncrypted()
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new SetEncrypted(encrypted, key) API instead.", true)]
		[Token(Token = "0x60000EE")]
		[Address(RVA = "0xBDC62C", Offset = "0xBDC62C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetEncrypted(char encrypted)
		{
		}
	}
}
