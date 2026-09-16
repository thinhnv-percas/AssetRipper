using System;
using AssetRipperInjected;
using CodeStage.AntiCheat.Common;
using CodeStage.AntiCheat.Detectors;
using CodeStage.AntiCheat.Utils;
using Cpp2ILInjected;
using UnityEngine;

namespace CodeStage.AntiCheat.ObscuredTypes
{
	[Serializable]
	[Token(Token = "0x200001E")]
	public sealed class ObscuredString : IObscuredType, IComparable<ObscuredString>, IComparable<string>, IComparable
	{
		[SerializeField]
		[Token(Token = "0x4000096")]
		[FieldOffset(Offset = "0x10")]
		private string currentCryptoKey;

		[SerializeField]
		[Token(Token = "0x4000097")]
		[FieldOffset(Offset = "0x18")]
		private byte[] hiddenValue;

		[SerializeField]
		[Token(Token = "0x4000098")]
		[FieldOffset(Offset = "0x20")]
		private char[] cryptoKey;

		[SerializeField]
		[Token(Token = "0x4000099")]
		[FieldOffset(Offset = "0x28")]
		private char[] hiddenChars;

		[SerializeField]
		[Token(Token = "0x400009A")]
		[FieldOffset(Offset = "0x30")]
		private bool inited;

		[SerializeField]
		[Token(Token = "0x400009B")]
		[FieldOffset(Offset = "0x38")]
		private string fakeValue;

		[SerializeField]
		[Token(Token = "0x400009C")]
		[FieldOffset(Offset = "0x40")]
		private bool fakeValueActive;

		[Token(Token = "0x1700000A")]
		public int Length
		{
			[Token(Token = "0x600021D")]
			[Address(RVA = "0xBE15A8", Offset = "0xBE15A8", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.hiddenChars;\n\treturn v2.Length;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				char[] array = hiddenChars;
				return array.Length;
			}
		}

		[Token(Token = "0x1700000B")]
		public char this[int index]
		{
			[Token(Token = "0x600021E")]
			[Address(RVA = "0xBE15C4", Offset = "0xBE15C4", Length = "0x80")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = index & 0x80000000;\n\tv6 = v4 == 0;\n\tv7 = ~v6;\n\tif (v7) goto L_0033;\n\tv8 = this.hiddenChars;\n\tv13 = v8.Length <= index;\n\tif (v13) goto L_0033;\n\tv68 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::InternalDecrypt(this);\n\treturn v68[index @ X1 (System.Int32)];\nL_0033:\n\tv84 = new System.IndexOutOfRangeException();\n\tSystem.IndexOutOfRangeException::.ctor(v84);\n\tthrow v84;\n\tv83 = new System.NullReferenceException();\n\treturnVal1 = new System.IndexOutOfRangeException();\n\treturn returnVal1;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0012: Expected I4, but got I8
				if ((int)(index & 0x80000000L) == 0)
				{
					char[] array = hiddenChars;
					if (array.Length > index)
					{
						char[] array2 = InternalDecrypt();
						return array2[index];
					}
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
		}

		[Token(Token = "0x6000206")]
		[Address(RVA = "0xBE0DE8", Offset = "0xBE0DE8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private ObscuredString()
		{
		}

		[Token(Token = "0x6000207")]
		[Address(RVA = "0xBE0DF0", Offset = "0xBE0DF0", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = System.Char[];\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, value, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A35487]) = v40;\nL_0017:\n\tSystem.Object::.ctor(this);\n\t// 26 NewArr v45 @ X0_v4 (System.Char[]), typeof(System.Char[]), 7\n\tthis.cryptoKey = v45;\n\tv46 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateCharArrayKey(v45);\n\tv50 = System.String::ToCharArray(value);\n\tv53 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::InternalEncryptDecrypt(v50, this.cryptoKey);\n\tthis.hiddenChars = v53;\n\tv55 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv77 = v55 == 0;\n\tv65 = ~v77;\n\tv62 = ~v65;\n\tif (v62) goto L_FFFFFFFF;\n\tgoto L_0034;\nL_0034:\n\tthis.fakeValueActive = v55;\n\tthis.fakeValue = v59;\n\tthis.inited = 1;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private ObscuredString(string value)
		{
			char[] array = RandomUtils.GenerateCharArrayKey(cryptoKey = new char[7]);
			hiddenChars = InternalEncryptDecrypt(value.ToCharArray(), cryptoKey);
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			string text = ((!existsAndIsRunning) ? null : value);
			fakeValueActive = existsAndIsRunning;
			fakeValue = text;
			inited = true;
		}

		[Token(Token = "0x6000208")]
		[Address(RVA = "0xBE0FD0", Offset = "0xBE0FD0", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = System.String::ToCharArray(key);\n\treturnVal2 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::Encrypt(value, v10);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static char[] Encrypt(string value, string key)
		{
			char[] key2 = key.ToCharArray();
			return Encrypt(value, key2);
		}

		[Token(Token = "0x6000209")]
		[Address(RVA = "0xBE0FFC", Offset = "0xBE0FFC", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = System.String::ToCharArray(value);\n\treturnVal2 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::InternalEncryptDecrypt(v9, key);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static char[] Encrypt(string value, char[] key)
		{
			char[] value2 = value.ToCharArray();
			return InternalEncryptDecrypt(value2, key);
		}

		[Token(Token = "0x600020A")]
		[Address(RVA = "0xBDA798", Offset = "0xBDA798", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::InternalEncryptDecrypt(value, key);\n\treturn returnVal1;\n")]
		public static char[] Encrypt(char[] value, char[] key)
		{
			return InternalEncryptDecrypt(value, key);
		}

		[Token(Token = "0x600020B")]
		[Address(RVA = "0xBE1020", Offset = "0xBE1020", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = System.String::ToCharArray(key);\n\tv28 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::InternalEncryptDecrypt(value, v10);\n\treturnVal2 = System.String::CreateString(0, v28);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string Decrypt(char[] value, string key)
		{
			char[] key2 = key.ToCharArray();
			char[] val = InternalEncryptDecrypt(value, key2);
			return ((string)null).CreateString(val);
		}

		[Token(Token = "0x600020C")]
		[Address(RVA = "0xBE105C", Offset = "0xBE105C", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::InternalEncryptDecrypt(value, key);\n\treturnVal1 = System.String::CreateString(0, v2);\n\treturn returnVal1;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string Decrypt(char[] value, char[] key)
		{
			char[] val = InternalEncryptDecrypt(value, key);
			return ((string)null).CreateString(val);
		}

		[Token(Token = "0x600020D")]
		[Address(RVA = "0xBE1078", Offset = "0xBE1078", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, key, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A35488]) = v40;\nL_0016:\n\tv42 = new CodeStage.AntiCheat.ObscuredTypes.ObscuredString();\n\tSystem.Object::.ctor(v42);\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredString::SetEncrypted(v42, encrypted, key);\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ObscuredString FromEncrypted(char[] encrypted, char[] key)
		{
			ObscuredString obscuredString = new ObscuredString();
			obscuredString.SetEncrypted(encrypted, key);
			return obscuredString;
		}

		[Obsolete("Use this only to decrypt data encrypted with previous ACTk versions. Please use FromEncrypted(char[], char[]) in other cases.")]
		[Token(Token = "0x600020E")]
		[Address(RVA = "0xBE1148", Offset = "0xBE1148", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, key, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A35489]) = v40;\nL_0016:\n\tv42 = new CodeStage.AntiCheat.ObscuredTypes.ObscuredString();\n\tSystem.Object::.ctor(v42);\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredString::SetEncrypted(v42, encrypted, key);\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ObscuredString FromEncrypted(string encrypted, string key = "4441")
		{
			ObscuredString obscuredString = new ObscuredString();
			obscuredString.SetEncrypted(encrypted, key);
			return obscuredString;
		}

		[Token(Token = "0x600020F")]
		[Address(RVA = "0xBDA790", Offset = "0xBDA790", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateCharArrayKey(0);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static char[] GenerateKey()
		{
			return RandomUtils.GenerateCharArrayKey();
		}

		[Token(Token = "0x6000210")]
		[Address(RVA = "0xBE0E9C", Offset = "0xBE0E9C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateCharArrayKey(arrayToFill);\n\treturn returnVal1;\n")]
		public static char[] GenerateKey(char[] arrayToFill)
		{
			return RandomUtils.GenerateCharArrayKey(arrayToFill);
		}

		[Token(Token = "0x6000211")]
		[Address(RVA = "0xBE0EA0", Offset = "0xBE0EA0", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = System.Char[];\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, key, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv42 = UnityEngine.Debug;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, key, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv118 = \"[ACTk] Empty key can't be used for string encryption or decryption!\";\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v118, key, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 1;\n\t*([1A3548A]) = v39;\nL_0019:\n\tv40 = value == 0;\n\tif (v40) goto L_0086;\n\tv45 = value.Length == 0;\n\tif (v45) goto L_0086;\n\tv166 = key.Length == 0;\n\tif (v166) goto L_0078;\n\t// 39 NewArr v101 @ X0_v11 (System.Char[]), typeof(System.Char[]), value.Length\n\tv216 = value.Length < 1;\n\tif (v216) goto L_FFFFFFFF;\n\tv174 = value.Length & 0xFFFFFFFF;\nL_0044:\n\tv254 = v197 / key.Length;\n\tv255 = v254 * key.Length;\n\tv169 = v197 - v255;\n\tv222 = key[v169 @ X13_v7] ^ value[v197 @ X8_v14 (System.Int32)];\n\tv101[v197 @ X8_v14 (System.Int32)] = v222;\n\tv197 = v197 + 1;\n\tv224 = v174 != v197;\n\tif (v224) goto L_0044;\n\tgoto L_0086;\nL_0078:\n\tgoto L_007E;\n\tv217 = \"il2cpp_codegen_runtime_class_init\"(v203, key, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_007E:\n\tUnityEngine.Debug::LogError(\"[ACTk] Empty key can't be used for string encryption or decryption!\");\nL_0086:\n\treturn v105;\n\tv194 = new System.IndexOutOfRangeException();\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 103 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static char[] InternalEncryptDecrypt(char[] value, char[] key)
		{
			//IL_008d: Expected I4, but got I8
			//IL_00b9: Expected O, but got I4
			//IL_00c7: Expected O, but got I
			bool flag = value == null;
			char[] result = value;
			if (!flag)
			{
				bool flag2 = value.Length == 0;
				result = value;
				if (!flag2)
				{
					if (key.Length != 0)
					{
						char[] array = new char[value.Length];
						if (value.Length >= 1)
						{
							int num = (int)(value.Length & 0xFFFFFFFFL);
							int num2 = 0;
							do
							{
								int num3 = num2 / key.Length;
								object obj = num3 * key.Length;
								object obj2 = num2 - (nint)obj;
								int num4 = key[obj2] ^ value[num2];
								array[num2] = (char)num4;
								num2++;
							}
							while (num != num2);
						}
						result = array;
					}
					else
					{
						Debug.LogError("[ACTk] Empty key can't be used for string encryption or decryption!");
						result = value;
					}
				}
			}
			return result;
		}

		[Token(Token = "0x6000212")]
		[Address(RVA = "0xBDA284", Offset = "0xBDA284", Length = "0x188")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv28 = System.Char[];\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, key, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv54 = UnityEngine.Debug;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, key, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv60 = System.String;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, key, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv86 = \"[ACTk] Empty key can't be used for string encryption or decryption!\";\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v86, key, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv47 = 1;\n\t*([1A3548B]) = v47;\nL_0024:\n\tv52 = System.String::IsNullOrEmpty(value);\n\tv57 = v52 == 0;\n\tv58 = ~v57;\n\tif (v58) goto L_0049;\n\tv64 = System.String::IsNullOrEmpty(key);\n\tv88 = v64 == 0;\n\tif (v88) goto L_0054;\n\tgoto L_003B;\n\tv170 = \"il2cpp_codegen_runtime_class_init\"(v166, v63, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_003B:\n\tUnityEngine.Debug::LogError(\"[ACTk] Empty key can't be used for string encryption or decryption!\");\nL_0049:\n\treturn v80.Empty;\nL_0054:\n\t// 84 NewArr v219 @ X0_v13 (System.Char[]), typeof(System.Char[]), value._stringLength (System.Int32)\n\tv240 = value._stringLength < 1;\n\tif (v240) goto L_0097;\nL_0067:\n\tv269 = System.String::get_Chars(value, v199);\n\tv211 = v199 / key._stringLength;\n\tv270 = v211 * key._stringLength;\n\tv205 = v199 - v270;\n\tv207 = System.String::get_Chars(key, v205);\n\tv258 = v207 ^ v269;\n\tv219[v199 @ X23_v7 (System.Int32)] = v258;\n\tv199 = v199 + 1;\n\tv243 = value._stringLength != v199;\n\tif (v243) goto L_0067;\nL_0097:\n\treturnVal3 = System.String::CreateString(0, v219);\n\treturn returnVal3;\n\tv214 = new System.NullReferenceException();\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\n// 116 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static string EncryptDecryptObsolete(string value, string key)
		{
			if (!string.IsNullOrEmpty(value))
			{
				if (!string.IsNullOrEmpty(key))
				{
					char[] array = new char[value.Length];
					if (value.Length >= 1)
					{
						int num = 0;
						do
						{
							char c = value[num];
							int num2 = num / key.Length;
							int num3 = num2 * key.Length;
							int index = num - num3;
							char c2 = key[index];
							int num4 = c2 ^ c;
							array[num] = (char)num4;
							num++;
						}
						while (value.Length != num);
					}
					return ((string)null).CreateString(array);
				}
				Debug.LogError("[ACTk] Empty key can't be used for string encryption or decryption!");
			}
			return string.Empty;
		}

		[Token(Token = "0x6000213")]
		[Address(RVA = "0xBE1240", Offset = "0xBE1240", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([key @ X1 (System.Char[]&)]) = this.cryptoKey;\n\treturn this.hiddenChars;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe char[] GetEncrypted(out char[] key)
		{
			key = null;
			ref char[] reference = ref *(char[]*)cryptoKey;
			return hiddenChars;
		}

		[Token(Token = "0x6000214")]
		[Address(RVA = "0xBE10F4", Offset = "0xBE10F4", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.inited = 1;\n\tthis.cryptoKey = key;\n\tthis.hiddenChars = encrypted;\n\tv12 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tthis.fakeValueActive = 0;\n\tv14 = v12 == 0;\n\tif (v14) goto L_001B;\n\tv16 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::InternalDecrypt(this);\n\tv22 = System.String::CreateString(0, v16);\n\tthis.fakeValue = v22;\n\tthis.fakeValueActive = 1;\nL_001B:\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetEncrypted(char[] encrypted, char[] key)
		{
			inited = true;
			cryptoKey = key;
			hiddenChars = encrypted;
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			fakeValueActive = false;
			if (existsAndIsRunning)
			{
				char[] val = InternalDecrypt();
				string text = ((string)null).CreateString(val);
				fakeValue = text;
				fakeValueActive = true;
			}
		}

		[Obsolete("Use this only to decrypt data encrypted with previous ACTk versions. Please use SetEncrypted(char[], char[]) in other cases.")]
		[Token(Token = "0x6000215")]
		[Address(RVA = "0xBE11C4", Offset = "0xBE11C4", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.inited = 1;\n\tv15 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::EncryptDecryptObsolete(encrypted, key);\n\tv18 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateCharArrayKey(0);\n\tthis.cryptoKey = v18;\n\tv21 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::Encrypt(v15, v18);\n\tthis.hiddenChars = v21;\n\tv23 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tthis.fakeValueActive = 0;\n\tv25 = v23 == 0;\n\tif (v25) goto L_0026;\n\tv27 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::InternalDecrypt(this);\n\tv33 = System.String::CreateString(0, v27);\n\tthis.fakeValue = v33;\n\tthis.fakeValueActive = 1;\nL_0026:\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetEncrypted(string encrypted, string key)
		{
			inited = true;
			string value = EncryptDecrypt(encrypted, key);
			char[] array = Encrypt(value, cryptoKey = RandomUtils.GenerateCharArrayKey());
			hiddenChars = array;
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			fakeValueActive = false;
			if (existsAndIsRunning)
			{
				char[] val = InternalDecrypt();
				string text = ((string)null).CreateString(val);
				fakeValue = text;
				fakeValueActive = true;
			}
		}

		[Token(Token = "0x6000216")]
		[Address(RVA = "0xBE126C", Offset = "0xBE126C", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::InternalDecrypt(this);\n\treturnVal1 = System.String::CreateString(0, v2);\n\treturn returnVal1;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetDecrypted()
		{
			char[] val = InternalDecrypt();
			return ((string)null).CreateString(val);
		}

		[Token(Token = "0x6000217")]
		[Address(RVA = "0xBE1288", Offset = "0xBE1288", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::InternalDecrypt(this);\n\treturn returnVal1;\n")]
		public char[] GetDecryptedToChars()
		{
			return InternalDecrypt();
		}

		[Token(Token = "0x6000218")]
		[Address(RVA = "0xBE13E8", Offset = "0xBE13E8", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::InternalDecrypt(this);\n\tv13 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateCharArrayKey(this.cryptoKey);\n\tv16 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::InternalEncryptDecrypt(v8, this.cryptoKey);\n\tthis.hiddenChars = v16;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RandomizeCryptoKey()
		{
			char[] value = InternalDecrypt();
			char[] array = RandomUtils.GenerateCharArrayKey(cryptoKey);
			char[] array2 = InternalEncryptDecrypt(value, cryptoKey);
			hiddenChars = array2;
		}

		[Token(Token = "0x6000219")]
		[Address(RVA = "0xBE1250", Offset = "0xBE1250", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::InternalDecrypt(this);\n\treturnVal1 = System.String::CreateString(0, v2);\n\treturn returnVal1;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private string InternalDecryptToString()
		{
			char[] val = InternalDecrypt();
			return ((string)null).CreateString(val);
		}

		[Token(Token = "0x600021A")]
		[Address(RVA = "0xBE128C", Offset = "0xBE128C", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = System.Char[];\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv38 = Il2CppMethodInfo;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv49 = System.String;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A3548C]) = v34;\nL_0017:\n\tv36 = ~this.inited;\n\tif (v36) goto L_0059;\n\tv42 = System.String::IsNullOrEmpty(this.currentCryptoKey);\n\tv51 = v42 == 0;\n\tv52 = ~v51;\n\tif (v52) goto L_0024;\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredString::MigrateFromACTkV1(this);\nL_0024:\n\tv58 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::InternalEncryptDecrypt(this.hiddenChars, this.cryptoKey);\n\tv64 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv68 = v64 == 0;\n\tif (v68) goto L_0054;\n\tv82 = ~this.fakeValueActive;\n\tif (v82) goto L_0054;\n\tv93 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::CompareCharsToString(v64, v58, this.fakeValue);\n\tv115 = v93 == 0;\n\tv96 = ~v115;\n\tif (v96) goto L_0054;\n\tgoto L_0045;\n\tv124 = 0xB348B0(v119, v90, v87, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0045:\n\tgoto L_004E;\n\tv132 = 0xB348B0(v127, v90, v87, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_004E:\n\tv92 = CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector>::OnCheatingDetected(v112.<Instance>k__BackingField);\nL_0054:\n\treturn v58;\nL_0059:\n\t// 89 NewArr v47 @ X0_v3 (System.Char[]), typeof(System.Char[]), 7\n\tthis.cryptoKey = v47;\n\tv53 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateCharArrayKey(v47);\n\t// 94 NewArr v61 @ X0_v6 (System.Char[]), typeof(System.Char[]), 0\n\tv66 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::InternalEncryptDecrypt(v61, this.cryptoKey);\n\tthis.hiddenChars = v66;\n\tthis.fakeValueActive = 0;\n\tthis.inited = 1;\n\tthis.fakeValue = v74.Empty;\n\t// 113 NewArr returnVal2 @ X0_v9 (System.Char[]), typeof(System.Char[]), 0\n\treturn returnVal2;\n\treturnVal3 = new System.NullReferenceException();\n\treturn returnVal3;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private char[] InternalDecrypt()
		{
			//IL_00b5: Expected O, but got I4
			if (inited)
			{
				if (!string.IsNullOrEmpty(currentCryptoKey))
				{
					MigrateFromACTkV1();
				}
				char[] array = InternalEncryptDecrypt(hiddenChars, cryptoKey);
				bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
				if (existsAndIsRunning && fakeValueActive && !((ObscuredString)existsAndIsRunning).CompareCharsToString(array, fakeValue))
				{
					KeepAliveBehaviour<ObscuredCheatingDetector>.Instance.OnCheatingDetected();
				}
				return array;
			}
			char[] array2 = RandomUtils.GenerateCharArrayKey(cryptoKey = new char[7]);
			char[] value = new char[0];
			char[] array3 = InternalEncryptDecrypt(value, cryptoKey);
			hiddenChars = array3;
			fakeValueActive = false;
			inited = true;
			fakeValue = string.Empty;
			return new char[0];
		}

		[Token(Token = "0x600021B")]
		[Address(RVA = "0xBE1480", Offset = "0xBE1480", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv91 = s._stringLength != chars.Length;\n\tif (v91) goto L_FFFFFFFF;\n\tv102 = s._stringLength < 1;\n\tif (v102) goto L_FFFFFFFF;\nL_0036:\n\tv184 = System.String::get_Chars(s, v29);\n\tv168 = chars[v29 @ X21_v5 (System.Int32)] - v184;\n\tv164 = v168 == 0;\n\tv154 = chars[v29 @ X21_v5 (System.Int32)] != v184;\n\tif (v154) goto L_005C;\n\tv29 = v29 + 1;\n\tv155 = v29 < chars.Length;\n\tif (v155) goto L_0036;\n\tgoto L_005C;\n\tgoto L_005C;\nL_005C:\n\treturn returnVal2;\n\tv22 = new System.IndexOutOfRangeException();\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool CompareCharsToString(char[] chars, string s)
		{
			bool result;
			if (s.Length == chars.Length)
			{
				if (s.Length >= 1)
				{
					int num = 0;
					while (true)
					{
						char c = s[num];
						int num2 = chars[num] - c;
						bool flag = num2 == 0;
						bool flag2 = chars[num] != c;
						result = flag;
						if (flag2)
						{
							break;
						}
						num++;
						if (num >= chars.Length)
						{
							result = flag;
							break;
						}
					}
				}
				else
				{
					result = true;
				}
			}
			else
			{
				result = false;
			}
			return result;
		}

		[Token(Token = "0x600021C")]
		[Address(RVA = "0xBE1424", Offset = "0xBE1424", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::GetStringObsolete(this.hiddenValue);\n\tv12 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::EncryptDecryptObsolete(v9, this.currentCryptoKey);\n\tv17 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateCharArrayKey(this.cryptoKey);\n\tv21 = System.String::ToCharArray(v12);\n\tv37 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::InternalEncryptDecrypt(v21, this.cryptoKey);\n\tthis.hiddenChars = v37;\n\tthis.currentCryptoKey = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void MigrateFromACTkV1()
		{
			string stringObsolete = GetStringObsolete(hiddenValue);
			string text = EncryptDecrypt(stringObsolete, currentCryptoKey);
			char[] array = RandomUtils.GenerateCharArrayKey(cryptoKey);
			char[] value = text.ToCharArray();
			char[] array2 = InternalEncryptDecrypt(value, cryptoKey);
			hiddenChars = array2;
			currentCryptoKey = null;
		}

		[Token(Token = "0x600021F")]
		[Address(RVA = "0xBE1644", Offset = "0xBE1644", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\n\tv14 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A3548D]) = v33;\nL_0010:\n\tv34 = value == 0;\n\tif (v34) goto L_FFFFFFFF;\n\treturnVal1 = new CodeStage.AntiCheat.ObscuredTypes.ObscuredString();\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredString::.ctor(returnVal1, value);\n\tgoto L_0020;\nL_0020:\n\treturn returnVal1;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static implicit operator ObscuredString(string value)
		{
			if (value != null)
			{
				return new ObscuredString(value);
			}
			return null;
		}

		[Token(Token = "0x6000220")]
		[Address(RVA = "0xBE16A8", Offset = "0xBE16A8", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = value == 0;\n\tif (v0) goto L_000C;\n\tv4 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::InternalDecrypt(value);\n\treturnVal2 = System.String::CreateString(0, v4);\n\treturn returnVal2;\nL_000C:\n\treturn value;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static implicit operator string(ObscuredString value)
		{
			if ((object)value != null)
			{
				char[] val = value.InternalDecrypt();
				return ((string)null).CreateString(val);
			}
			return value;
		}

		[Token(Token = "0x6000221")]
		[Address(RVA = "0xBE16CC", Offset = "0xBE16CC", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = a == b;\n\tif (v12) goto L_FFFFFFFF;\n\tv18 = a == 0;\n\tif (v18) goto L_002D;\n\tv21 = b == 0;\n\tif (v21) goto L_002D;\n\tv36 = a.cryptoKey == b.cryptoKey;\n\tif (v36) goto L_002E;\n\tv71 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::InternalDecrypt(a);\n\tv68 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::InternalDecrypt(b);\n\tgoto L_0034;\nL_002D:\n\treturn v25;\nL_002E:\n\tv71 = a.hiddenChars;\n\tv44 = b.hiddenChars;\nL_0034:\n\treturnVal2 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::ArraysEquals(v71, v44);\n\treturn returnVal2;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool operator ==(ObscuredString a, ObscuredString b)
		{
			bool result;
			if ((object)a != b)
			{
				bool flag = (object)a == null;
				result = false;
				if (!flag)
				{
					bool flag2 = (object)b == null;
					result = false;
					if (!flag2)
					{
						char[] a2;
						char[] a3;
						if (a.cryptoKey != b.cryptoKey)
						{
							a2 = a.InternalDecrypt();
							char[] array = b.InternalDecrypt();
							a3 = array;
						}
						else
						{
							a2 = a.hiddenChars;
							a3 = b.hiddenChars;
						}
						return ArraysEquals(a2, a3);
					}
				}
			}
			else
			{
				result = true;
			}
			return result;
		}

		[Token(Token = "0x6000222")]
		[Address(RVA = "0xBE17D4", Offset = "0xBE17D4", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::op_Equality(a, b);\n\tv6 = ~v2;\n\treturn v6;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool operator !=(ObscuredString a, ObscuredString b)
		{
			bool flag = a == b;
			return !flag;
		}

		[Token(Token = "0x6000223")]
		[Address(RVA = "0xBE17EC", Offset = "0xBE17EC", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.hiddenChars;\n\tv6 = v2.Length - startIndex;\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::Substring(this, startIndex, v6);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string Substring(int startIndex)
		{
			char[] array = hiddenChars;
			int length = array.Length - startIndex;
			return Substring(startIndex, length);
		}

		[Token(Token = "0x6000224")]
		[Address(RVA = "0xBE180C", Offset = "0xBE180C", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::InternalDecrypt(this);\n\tv15 = System.String::CreateString(0, v10);\n\treturnVal1 = System.String::Substring(v15, startIndex, length);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string Substring(int startIndex, int length)
		{
			char[] val = InternalDecrypt();
			string text = ((string)null).CreateString(val);
			return text.Substring(startIndex, length);
		}

		[Token(Token = "0x6000225")]
		[Address(RVA = "0xBE1850", Offset = "0xBE1850", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::InternalDecrypt(this);\n\tv15 = System.String::CreateString(0, v10);\n\treturnVal1 = System.String::StartsWith(v15, value, comparisonType);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool StartsWith(string value, StringComparison comparisonType = StringComparison.CurrentCulture)
		{
			char[] val = InternalDecrypt();
			string text = ((string)null).CreateString(val);
			return text.StartsWith(value, comparisonType);
		}

		[Token(Token = "0x6000226")]
		[Address(RVA = "0xBE1894", Offset = "0xBE1894", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::InternalDecrypt(this);\n\tv15 = System.String::CreateString(0, v10);\n\treturnVal1 = System.String::EndsWith(v15, value, comparisonType);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool EndsWith(string value, StringComparison comparisonType = StringComparison.CurrentCulture)
		{
			char[] val = InternalDecrypt();
			string text = ((string)null).CreateString(val);
			return text.EndsWith(value, comparisonType);
		}

		[Token(Token = "0x6000227")]
		[Address(RVA = "0xBE18D8", Offset = "0xBE18D8", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::InternalDecrypt(this);\n\tv8 = System.String::CreateString(0, v2);\n\tv10 = *([v8 @ X0_v3 (System.String)]);\n\tv11 = *([v10 @ X8_v1 (Il2CppClass<System.String>)+158]);\n\tv12 = *([v10 @ X8_v1 (Il2CppClass<System.String>)+160]);\n\t// 14 IndirectJump v11 @ X2_v2, v8 @ X0_v3 (System.String), v8 @ X0_v3 (System.String), v12 @ X1_v2, v11 @ X2_v2, v14 @ X3, v15 @ X4, v16 @ X5, v17 @ X6, v18 @ X7, v19 @ V0, v20 @ V1, v21 @ V2, v22 @ V3, v23 @ V4, v24 @ V5, v25 @ V6, v26 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override int GetHashCode()
		{
			//IL_0025: Expected I, but got O
			//IL_0035: Expected O, but got I
			//IL_0045: Expected O, but got I
			char[] val = InternalDecrypt();
			string text = ((string)null).CreateString(val);
			nint num = (nint)text;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X8_v1 (Il2CppClass<System.String>)+158]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X8_v1 (Il2CppClass<System.String>)+160]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v11 @ X2_v2 (should have been resolved before IL gen)");
			return 0;
		}

		[Token(Token = "0x6000228")]
		[Address(RVA = "0xBE1908", Offset = "0xBE1908", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::InternalDecrypt(this);\n\treturnVal1 = System.String::CreateString(0, v2);\n\treturn returnVal1;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			char[] val = InternalDecrypt();
			return ((string)null).CreateString(val);
		}

		[Token(Token = "0x6000229")]
		[Address(RVA = "0xBE1924", Offset = "0xBE1924", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, obj, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A3548E]) = v36;\nL_0012:\n\tv37 = obj == 0;\n\tif (v37) goto L_0028;\n\tv46 = *([obj @ X1 (System.Object)]) == CodeStage.AntiCheat.ObscuredTypes.ObscuredString;\n\tif (v46) goto L_0030;\nL_0028:\n\treturn 0;\nL_0030:\n\treturnVal2 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::Equals(this, obj);\n\treturn returnVal2;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override bool Equals(object obj)
		{
			if (obj == null || (object)obj.GetType() != typeof(ObscuredString))
			{
				return false;
			}
			return Equals((ObscuredString)obj);
		}

		[Token(Token = "0x600022A")]
		[Address(RVA = "0xBE1994", Offset = "0xBE1994", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = value == 0;\n\tif (v6) goto L_001F;\n\tv16 = this.cryptoKey == value.cryptoKey;\n\tif (v16) goto L_0020;\n\tv63 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::InternalDecrypt(this);\n\tv60 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::InternalDecrypt(value);\n\tgoto L_0026;\nL_001F:\n\treturn 0;\nL_0020:\n\tv63 = this.hiddenChars;\n\tv31 = value.hiddenChars;\nL_0026:\n\treturnVal2 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::ArraysEquals(v63, v31);\n\treturn returnVal2;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool Equals(ObscuredString value)
		{
			if ((object)value != null)
			{
				char[] a;
				char[] a2;
				if (cryptoKey != value.cryptoKey)
				{
					a = InternalDecrypt();
					char[] array = value.InternalDecrypt();
					a2 = array;
				}
				else
				{
					a = hiddenChars;
					a2 = value.hiddenChars;
				}
				return ArraysEquals(a, a2);
			}
			return false;
		}

		[Token(Token = "0x600022B")]
		[Address(RVA = "0xBE19F4", Offset = "0xBE19F4", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = value == 0;\n\tif (v0) goto L_0021;\n\tv13 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::InternalDecrypt(this);\n\tv19 = System.String::CreateString(0, v13);\n\tv47 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::InternalDecrypt(value);\n\tv51 = System.String::CreateString(0, v47);\n\treturnVal2 = System.String::Equals(v19, v51, comparisonType);\n\treturn returnVal2;\nL_0021:\n\treturn 0;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool Equals(ObscuredString value, StringComparison comparisonType)
		{
			if ((object)value != null)
			{
				char[] val = InternalDecrypt();
				string a = ((string)null).CreateString(val);
				char[] val2 = value.InternalDecrypt();
				string b = ((string)null).CreateString(val2);
				return string.Equals(a, b, comparisonType);
			}
			return false;
		}

		[Token(Token = "0x600022C")]
		[Address(RVA = "0xBE1A5C", Offset = "0xBE1A5C", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::InternalDecrypt(this);\n\tv13 = System.String::CreateString(0, v8);\n\tv17 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::InternalDecrypt(other);\n\tv26 = System.String::CreateString(0, v17);\n\treturnVal2 = System.String::CompareTo(v13, v26);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int CompareTo(ObscuredString other)
		{
			char[] val = InternalDecrypt();
			string text = ((string)null).CreateString(val);
			char[] val2 = other.InternalDecrypt();
			string strB = ((string)null).CreateString(val2);
			return text.CompareTo(strB);
		}

		[Token(Token = "0x600022D")]
		[Address(RVA = "0xBE1ABC", Offset = "0xBE1ABC", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::InternalDecrypt(this);\n\tv11 = System.String::CreateString(0, v6);\n\treturnVal1 = System.String::CompareTo(v11, other);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int CompareTo(string other)
		{
			char[] val = InternalDecrypt();
			string text = ((string)null).CreateString(val);
			return text.CompareTo(other);
		}

		[Token(Token = "0x600022E")]
		[Address(RVA = "0xBE1AF0", Offset = "0xBE1AF0", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::InternalDecrypt(this);\n\tv11 = System.String::CreateString(0, v6);\n\treturnVal1 = System.String::CompareTo(v11, obj);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int CompareTo(object obj)
		{
			char[] val = InternalDecrypt();
			string text = ((string)null).CreateString(val);
			return text.CompareTo(obj);
		}

		[Obsolete("This API is redundant and does not perform any actions. It will be removed in future updates.")]
		[Token(Token = "0x600022F")]
		[Address(RVA = "0xBE1B24", Offset = "0xBE1B24", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public static void SetNewCryptoKey(string newKey)
		{
		}

		[Obsolete("This API is redundant and does not perform any actions. It will be removed in future updates.")]
		[Token(Token = "0x6000230")]
		[Address(RVA = "0xBE1B28", Offset = "0xBE1B28", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void ApplyNewCryptoKey()
		{
		}

		[Obsolete("Please use new Encrypt(value, key) or Decrypt(value, key) API instead.", true)]
		[Token(Token = "0x6000231")]
		[Address(RVA = "0xBE1B2C", Offset = "0xBE1B2C", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string EncryptDecrypt(string value)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new Encrypt(value, key) or Decrypt(value, key) APIs instead. This API will be removed in future updates.")]
		[Token(Token = "0x6000232")]
		[Address(RVA = "0xBE1B64", Offset = "0xBE1B64", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::EncryptDecryptObsolete(value, key);\n\treturn returnVal1;\n")]
		public static string EncryptDecrypt(string value, string key)
		{
			return EncryptDecrypt(value, key);
		}

		[Obsolete("Please use new GetEncrypted(out key) API instead.", true)]
		[Token(Token = "0x6000233")]
		[Address(RVA = "0xBE1B68", Offset = "0xBE1B68", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetEncrypted()
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new SetEncrypted(encrypted, key) API instead.", true)]
		[Token(Token = "0x6000234")]
		[Address(RVA = "0xBE1BA0", Offset = "0xBE1BA0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetEncrypted(string encrypted)
		{
		}

		[Token(Token = "0x6000235")]
		[Address(RVA = "0xBE151C", Offset = "0xBE151C", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv14 = System.Char[];\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A3548F]) = v33;\nL_0013:\n\tv54 = bytes.Length;\n\tv41 = bytes.Length < 0;\n\tv44 = bytes.Length ^ bytes.Length;\n\tv45 = bytes.Length & v44;\n\tv46 = v45 < 0;\n\tv48 = v41 == v46;\n\tv49 = ~v48;\n\tv50 = ~v49;\n\tif (v50) goto L_0027;\n\tv54 = v54 + 1;\n\tgoto L_0027;\nL_0027:\n\tv55 = v54 >> 1;\n\t// 40 NewArr v56 @ X0_v4 (System.Char[]), typeof(System.Char[]), v55 @ X1_v1 (System.Int32)\n\tSystem.Buffer::BlockCopy(bytes, 0, v56, 0, bytes.Length);\n\treturnVal2 = System.String::CreateString(0, v56);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static string GetStringObsolete(byte[] bytes)
		{
			//IL_000f: Expected O, but got I4
			//IL_0090: Expected O, but got I
			object obj = bytes.Length;
			bool flag = bytes.Length < 0;
			int num = bytes.Length ^ bytes.Length;
			int num2 = bytes.Length & num;
			bool flag2 = num2 < 0;
			if (flag != flag2)
			{
				obj = (nint)obj + 1;
			}
			int num3 = (int)((nint)obj >> 1);
			char[] array = new char[num3];
			Buffer.BlockCopy(bytes, 0, array, 0, bytes.Length);
			return ((string)null).CreateString(array);
		}

		[Token(Token = "0x6000236")]
		[Address(RVA = "0xBE1BA4", Offset = "0xBE1BA4", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = System.Byte[];\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A35490]) = v33;\nL_0016:\n\tv39 = str._stringLength << 1;\n\t// 23 NewArr v40 @ X0_v5 (System.Byte[]), typeof(System.Byte[]), v39 @ X1_v2 (System.Int32)\n\tv46 = System.String::ToCharArray(str);\n\tSystem.Buffer::BlockCopy(v46, 0, v40, 0, v40.Length);\n\treturn v40;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static byte[] GetBytesObsolete(string str)
		{
			int num = str.Length << 1;
			byte[] array = new byte[num];
			char[] src = str.ToCharArray();
			Buffer.BlockCopy(src, 0, array, 0, array.Length);
			return array;
		}

		[Token(Token = "0x6000237")]
		[Address(RVA = "0xBE1740", Offset = "0xBE1740", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = a1 == a2;\n\tif (v8) goto L_FFFFFFFF;\n\tv14 = a1 == 0;\n\tif (v14) goto L_005C;\n\tv23 = a2 == 0;\n\tif (v23) goto L_005C;\n\tv61 = a1.Length != a2.Length;\n\tif (v61) goto L_FFFFFFFF;\n\tv17 = a1.Length < 1;\n\tif (v17) goto L_FFFFFFFF;\n\tv63 = 0 - a1.Length;\nL_0039:\n\tv46 = v63 + v116;\n\tv95 = a1[v116 @ X10_v3 (System.Int32)] - a2[v116 @ X10_v3 (System.Int32)];\n\tv153 = v95 == 0;\n\tv65 = v46 + 1;\n\tv87 = v65 == 0;\n\tif (v87) goto L_005C;\n\tv88 = a1[v116 @ X10_v3 (System.Int32)] == a2[v116 @ X10_v3 (System.Int32)];\n\tv116 = v116 + 1;\n\tif (v88) goto L_0039;\n\tgoto L_005C;\n\tgoto L_005C;\nL_005C:\n\treturn v66;\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool ArraysEquals(char[] a1, char[] a2)
		{
			//IL_00ba: Expected O, but got I4
			//IL_00d6: Expected O, but got I
			//IL_0113: Expected O, but got I
			if (a1 == a2)
			{
				goto IL_0181;
			}
			bool flag = a1 == null;
			bool result = false;
			if (!flag)
			{
				bool flag2 = a2 == null;
				result = false;
				if (!flag2)
				{
					if (a1.Length == a2.Length)
					{
						if (a1.Length < 1)
						{
							goto IL_0181;
						}
						object obj = -a1.Length;
						int num = 0;
						while (true)
						{
							object obj2 = (nint)obj + num;
							int num2 = a1[num] - a2[num];
							bool flag3 = num2 == 0;
							object obj3 = (nint)obj2 + 1;
							bool flag4 = obj3 == null;
							result = flag3;
							if (flag4)
							{
								break;
							}
							bool flag5 = a1[num] == a2[num];
							num++;
							if (!flag5)
							{
								result = flag3;
								break;
							}
						}
					}
					else
					{
						result = false;
					}
				}
			}
			goto IL_019d;
			IL_0181:
			result = true;
			goto IL_019d;
			IL_019d:
			return result;
		}
	}
}
