using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using CodeStage.AntiCheat.Common;
using CodeStage.AntiCheat.Detectors;
using CodeStage.AntiCheat.Utils;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeStage.AntiCheat.ObscuredTypes
{
	[Serializable]
	[Token(Token = "0x200000F")]
	public struct ObscuredBool : IObscuredType, IEquatable<ObscuredBool>, IComparable<ObscuredBool>, IComparable<bool>, IComparable
	{
		[SerializeField]
		[Token(Token = "0x400004E")]
		[FieldOffset(Offset = "0x0")]
		private byte currentCryptoKey;

		[SerializeField]
		[Token(Token = "0x400004F")]
		[FieldOffset(Offset = "0x4")]
		private int hiddenValue;

		[SerializeField]
		[Token(Token = "0x4000050")]
		[FieldOffset(Offset = "0x8")]
		private bool inited;

		[SerializeField]
		[Token(Token = "0x4000051")]
		[FieldOffset(Offset = "0x9")]
		private bool fakeValue;

		[FormerlySerializedAs("fakeValueChanged")]
		[SerializeField]
		[Token(Token = "0x4000052")]
		[FieldOffset(Offset = "0xA")]
		private bool fakeValueActive;

		[Token(Token = "0x6000093")]
		[Address(RVA = "0xBDAF94", Offset = "0xBDAF94", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateByteKey();\n\tv13 = value == 0;\n\tv18 = ~v13;\n\tv19 = ~v18;\n\tif (v19) goto L_FFFFFFFF;\n\tgoto L_0015;\nL_0015:\n\tv23 = v10 & 0xFF;\n\tthis.currentCryptoKey = v10;\n\tv24 = v22 ^ v23;\n\tthis.hiddenValue = v24;\n\tv26 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv27 = v26 & value;\n\tthis.fakeValueActive = v26;\n\tthis.fakeValue = v27;\n\tthis.inited = 1;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private ObscuredBool(bool value)
		{
			byte b = RandomUtils.GenerateByteKey();
			int num = ((!value) ? 181 : 213);
			int num2 = b & 0xFF;
			currentCryptoKey = b;
			int num3 = num ^ num2;
			hiddenValue = num3;
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			bool flag = existsAndIsRunning && value;
			fakeValueActive = existsAndIsRunning;
			fakeValue = flag;
			inited = true;
		}

		[Token(Token = "0x6000094")]
		[Address(RVA = "0xBDAFFC", Offset = "0xBDAFFC", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = value == 0;\n\tv8 = ~v3;\n\tv9 = ~v8;\n\tif (v9) goto L_FFFFFFFF;\n\tgoto L_000E;\nL_000E:\n\tv13 = key & 0xFF;\n\treturnVal1 = v12 ^ v13;\n\treturn returnVal1;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int Encrypt(bool value, byte key)
		{
			int num = ((!value) ? 181 : 213);
			int num2 = key & 0xFF;
			return num ^ num2;
		}

		[Token(Token = "0x6000095")]
		[Address(RVA = "0xBDB018", Offset = "0xBDB018", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = key & 0xFF;\n\tv2 = v0 ^ value;\n\tv6 = v2 - 0xB5;\n\tv8 = v6 == 0;\n\tv13 = ~v8;\n\treturn v13;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool Decrypt(int value, byte key)
		{
			int num = key & 0xFF;
			int num2 = num ^ value;
			int num3 = num2 - 181;
			bool flag = num3 == 0;
			return !flag;
		}

		[Token(Token = "0x6000096")]
		[Address(RVA = "0xBDB02C", Offset = "0xBDB02C", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = 0;\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredBool::SetEncrypted(&v7 @ stack_-20_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredBool), encrypted, key);\n\treturn 0;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ObscuredBool FromEncrypted(int encrypted, byte key)
		{
			default(ObscuredBool).SetEncrypted(encrypted, key);
			return default(ObscuredBool);
		}

		[Token(Token = "0x6000097")]
		[Address(RVA = "0xBDAFF8", Offset = "0xBDAFF8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateByteKey();\n\treturn returnVal1;\n")]
		public static byte GenerateKey()
		{
			return RandomUtils.GenerateByteKey();
		}

		[Token(Token = "0x6000098")]
		[Address(RVA = "0xBDB0AC", Offset = "0xBDB0AC", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([key @ X1 (System.Byte&)]) = this.currentCryptoKey;\n\treturn this.hiddenValue;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe int GetEncrypted(out byte key)
		{
			key = default(byte);
			ref byte reference = ref *(byte*)currentCryptoKey;
			return hiddenValue;
		}

		[Token(Token = "0x6000099")]
		[Address(RVA = "0xBDB060", Offset = "0xBDB060", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.hiddenValue = encrypted;\n\tthis.inited = 1;\n\tthis.currentCryptoKey = key;\n\tv12 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tthis.fakeValueActive = 0;\n\tv14 = v12 == 0;\n\tif (v14) goto L_0018;\n\tv16 = CodeStage.AntiCheat.ObscuredTypes.ObscuredBool::InternalDecrypt(this);\n\tthis.fakeValue = v16;\n\tthis.fakeValueActive = 1;\nL_0018:\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetEncrypted(int encrypted, byte key)
		{
			hiddenValue = encrypted;
			inited = true;
			currentCryptoKey = key;
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			fakeValueActive = false;
			if (existsAndIsRunning)
			{
				bool flag = InternalDecrypt();
				fakeValue = flag;
				fakeValueActive = true;
			}
		}

		[Token(Token = "0x600009A")]
		[Address(RVA = "0xBDB1B4", Offset = "0xBDB1B4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredBool::InternalDecrypt(this);\n\treturn returnVal1;\n")]
		public bool GetDecrypted()
		{
			return InternalDecrypt();
		}

		[Token(Token = "0x600009B")]
		[Address(RVA = "0xBDB1B8", Offset = "0xBDB1B8", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = CodeStage.AntiCheat.ObscuredTypes.ObscuredBool::InternalDecrypt(this);\n\tv11 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateByteKey();\n\tv14 = v8 == 0;\n\tv19 = ~v14;\n\tv20 = ~v19;\n\tif (v20) goto L_FFFFFFFF;\n\tgoto L_0016;\nL_0016:\n\tv24 = v11 & 0xFF;\n\tv25 = v23 ^ v24;\n\tthis.currentCryptoKey = v11;\n\tthis.hiddenValue = v25;\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RandomizeCryptoKey()
		{
			bool flag = InternalDecrypt();
			byte b = RandomUtils.GenerateByteKey();
			int num = ((!flag) ? 181 : 213);
			int num2 = b & 0xFF;
			int num3 = num ^ num2;
			currentCryptoKey = b;
			hiddenValue = num3;
		}

		[Token(Token = "0x600009C")]
		[Address(RVA = "0xBDB0BC", Offset = "0xBDB0BC", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv16 = Il2CppMethodInfo;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv35 = 1;\n\t*([1A3544A]) = v35;\nL_0012:\n\tv37 = ~v33.inited;\n\tif (v37) goto L_005B;\n\tv41 = v33.hiddenValue ^ v33.currentCryptoKey;\n\tv44 = v41 - 0xB5;\n\tv46 = v44 == 0;\n\tv51 = ~v46;\n\tv53 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv56 = v53 == 0;\n\tif (v56) goto L_006B;\n\tv63 = ~v33.fakeValueActive;\n\tif (v63) goto L_006B;\n\tv112 = v41 - 0xB5;\n\tv114 = v112 == 0;\n\tv68 = ~v114;\n\tv83 = v33.fakeValue == v68;\n\tif (v83) goto L_006B;\n\tgoto L_0050;\n\tv148 = 0xB348B0(v143, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0050:\n\tgoto L_0059;\n\tv156 = 0xB348B0(v151, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0059:\n\tv98 = CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector>::OnCheatingDetected(v138.<Instance>k__BackingField);\n\tgoto L_006B;\nL_005B:\n\tv54 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateByteKey();\n\tv58 = v54 ^ 0xB5;\n\tv60 = v58 & 0xFF;\n\tv33.currentCryptoKey = v54;\n\tv33.fakeValueActive = 0;\n\tv33.hiddenValue = v60;\n\tv33.inited = 1;\nL_006B:\n\treturn v104;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool InternalDecrypt()
		{
			bool result;
			if (inited)
			{
				int num = hiddenValue ^ currentCryptoKey;
				int num2 = num - 181;
				bool flag = num2 == 0;
				bool flag2 = !flag;
				bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
				bool flag3 = !existsAndIsRunning;
				result = flag2;
				if (!flag3)
				{
					bool flag4 = !fakeValueActive;
					result = flag2;
					if (!flag4)
					{
						int num3 = num - 181;
						bool flag5 = num3 == 0;
						bool flag6 = !flag5;
						bool flag7 = fakeValue == flag6;
						result = flag2;
						if (!flag7)
						{
							KeepAliveBehaviour<ObscuredCheatingDetector>.Instance.OnCheatingDetected();
							result = flag2;
						}
					}
				}
			}
			else
			{
				byte b = RandomUtils.GenerateByteKey();
				int num4 = b ^ 0xB5;
				int num5 = num4 & 0xFF;
				currentCryptoKey = b;
				fakeValueActive = false;
				hiddenValue = num5;
				inited = true;
				fakeValue = false;
				result = false;
			}
			return result;
		}

		[Token(Token = "0x600009D")]
		[Address(RVA = "0xBDB1FC", Offset = "0xBDB1FC", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateByteKey();\n\tv13 = value == 0;\n\tv18 = v10 & 0xFF;\n\tv19 = ~v13;\n\tv20 = ~v19;\n\tif (v20) goto L_FFFFFFFF;\n\tgoto L_0016;\nL_0016:\n\tv24 = v10 & 0xFF;\n\tv26 = v23 ^ v24;\n\tv27 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv28 = v27 & value;\n\tv32 = v28 == 0;\n\tv35 = v26 & 0xFF;\n\tv36 = v35 << 0x20;\n\tv37 = v18 & 0xFFFFFF00FFFFFFFF;\n\tv38 = v37 | v36;\n\tv39 = ~v32;\n\tv40 = ~v39;\n\tif (v40) goto L_002E;\n\tgoto L_002E;\nL_002E:\n\tv46 = v27 == 0;\n\tv53 = ~v46;\n\tv54 = ~v53;\n\tif (v54) goto L_0040;\n\tgoto L_0040;\nL_0040:\n\treturn v38;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static implicit operator ObscuredBool(bool value)
		{
			//IL_00de: Expected I4, but got I8
			//IL_0147: Expected O, but got I4
			byte b = RandomUtils.GenerateByteKey();
			bool flag = !value;
			int num = b & 0xFF;
			int num2 = (flag ? 181 : 213);
			int num3 = b & 0xFF;
			int num4 = num2 ^ num3;
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			bool flag2 = existsAndIsRunning && value;
			bool flag3 = !flag2;
			int num5 = num4 & 0xFF;
			int num6 = num5 << 32;
			int num7 = (int)(num & -1095216660481L);
			int num8 = num7 | num6;
			if (!flag3)
			{
			}
			if (existsAndIsRunning)
			{
			}
			return (ObscuredBool)num8;
		}

		[Token(Token = "0x600009E")]
		[Address(RVA = "0xBDB264", Offset = "0xBDB264", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = CodeStage.AntiCheat.ObscuredTypes.ObscuredBool::InternalDecrypt(&value @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredBool));\n\treturn v7;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static implicit operator bool(ObscuredBool value)
		{
			ObscuredBool obscuredBool = default(ObscuredBool);
			return obscuredBool.InternalDecrypt();
		}

		[Token(Token = "0x600009F")]
		[Address(RVA = "0xBDB28C", Offset = "0xBDB28C", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = System.Boolean;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A3544B]) = v37;\nL_0014:\n\tv39 = CodeStage.AntiCheat.ObscuredTypes.ObscuredBool::InternalDecrypt(this);\n\tgoto L_0020;\n\tv46 = v40;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v46, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0020:\n\treturnVal1 = System.Boolean::GetHashCode(&v39 @ X0_v3 (System.Boolean));\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override int GetHashCode()
		{
			return InternalDecrypt().GetHashCode();
		}

		[Token(Token = "0x60000A0")]
		[Address(RVA = "0xBDB304", Offset = "0xBDB304", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = System.Boolean;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A3544C]) = v37;\nL_0014:\n\tv39 = CodeStage.AntiCheat.ObscuredTypes.ObscuredBool::InternalDecrypt(this);\n\tgoto L_0020;\n\tv46 = v40;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v46, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0020:\n\treturnVal1 = System.Boolean::ToString(&v39 @ X0_v3 (System.Boolean));\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			return InternalDecrypt().ToString();
		}

		[Token(Token = "0x60000A1")]
		[Address(RVA = "0xBDB37C", Offset = "0xBDB37C", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredBool;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, obj, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A3544D]) = v36;\nL_0012:\n\tv37 = obj == 0;\n\tif (v37) goto L_0028;\n\tv46 = *([obj @ X1 (System.Object)]) == CodeStage.AntiCheat.ObscuredTypes.ObscuredBool;\n\tif (v46) goto L_002A;\nL_0028:\n\treturn 0;\nL_002A:\n\tv76 = \"il2cpp_vm_object_unbox\"(obj, obj, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\treturnVal2 = CodeStage.AntiCheat.ObscuredTypes.ObscuredBool::Equals(this, *([v76 @ X0_v4]));\n\treturn returnVal2;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override bool Equals(object obj)
		{
			if (obj == null || (object)obj.GetType() != typeof(ObscuredBool))
			{
				return false;
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
			object obj2 = default(object);
			return Equals((ObscuredBool)obj2);
		}

		[Token(Token = "0x60000A2")]
		[Address(RVA = "0xBDB3F8", Offset = "0xBDB3F8", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = obj >> 0x20;\n\tgoto L_0015;\n\tv21 = System.Boolean;\n\tv22 = \"il2cpp_codegen_initialize_runtime_metadata\"(v21, obj, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A3544E]) = v39;\nL_0015:\n\tv41 = this + 4;\n\tv51 = this.currentCryptoKey != obj;\n\tif (v51) goto L_0029;\n\tv111 = System.Int32::Equals(v41, v16);\n\tgoto L_0053;\nL_0029:\n\tv59 = v41.m_value ^ this.currentCryptoKey;\n\tv63 = v59 - 0xB5;\n\tv65 = v63 == 0;\n\tv51 = ~v65;\n\tv74 = obj & 0xFF;\n\tv75 = v74 ^ v16;\n\tgoto L_0040;\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v60, obj, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0040:\n\tv82 = v75 - 0xB5;\n\tv84 = v82 == 0;\n\tv51 = ~v84;\n\tv111 = System.Boolean::Equals(&v51 @ TEMPCOND_v1 (System.Boolean), v51);\nL_0053:\n\treturn v111;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe bool Equals(ObscuredBool obj)
		{
			//IL_000e: Expected I4, but got O
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Expected I4, but got Unknown
			int num = (object)obj >> 32;
			int num2 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 4));
			if ((int)currentCryptoKey == (nint)obj)
			{
				return ((int*)num2)->Equals(num);
			}
			int num3 = ((int*)num2)->m_value ^ currentCryptoKey;
			int num4 = num3 - 181;
			bool flag = num4 == 0;
			bool flag2 = !flag;
			int num5 = obj & 0xFF;
			int num6 = num5 ^ num;
			int num7 = num6 - 181;
			bool flag3 = num7 == 0;
			flag2 = !flag3;
			return flag2.Equals(flag2);
		}

		[Token(Token = "0x60000A3")]
		[Address(RVA = "0xBDB4AC", Offset = "0xBDB4AC", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = System.Boolean;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, other, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A3544F]) = v39;\nL_0016:\n\tv41 = CodeStage.AntiCheat.ObscuredTypes.ObscuredBool::InternalDecrypt(this);\n\tv45 = CodeStage.AntiCheat.ObscuredTypes.ObscuredBool::InternalDecrypt(&other @ X1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredBool));\n\tgoto L_0026;\n\tv51 = v46;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v51, other, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0026:\n\treturnVal1 = System.Boolean::CompareTo(&v41 @ X0_v3 (System.Boolean), v45);\n\treturn returnVal1;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int CompareTo(ObscuredBool other)
		{
			bool flag = InternalDecrypt();
			ObscuredBool obscuredBool = default(ObscuredBool);
			bool value = obscuredBool.InternalDecrypt();
			return flag.CompareTo(value);
		}

		[Token(Token = "0x60000A4")]
		[Address(RVA = "0xBDB53C", Offset = "0xBDB53C", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = System.Boolean;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, other, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A35450]) = v40;\nL_0016:\n\tv42 = CodeStage.AntiCheat.ObscuredTypes.ObscuredBool::InternalDecrypt(this);\n\tgoto L_0023;\n\tv49 = v43;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v49, other, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0023:\n\treturnVal1 = System.Boolean::CompareTo(&v42 @ X0_v3 (System.Boolean), other);\n\treturn returnVal1;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int CompareTo(bool other)
		{
			return InternalDecrypt().CompareTo(other);
		}

		[Token(Token = "0x60000A5")]
		[Address(RVA = "0xBDB5BC", Offset = "0xBDB5BC", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = System.Boolean;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, obj, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A35451]) = v40;\nL_0016:\n\tv42 = CodeStage.AntiCheat.ObscuredTypes.ObscuredBool::InternalDecrypt(this);\n\tgoto L_0023;\n\tv49 = v43;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v49, obj, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0023:\n\treturnVal1 = System.Boolean::CompareTo(&v42 @ X0_v3 (System.Boolean), obj);\n\treturn returnVal1;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int CompareTo(object obj)
		{
			return InternalDecrypt().CompareTo(obj);
		}

		[Obsolete("This API is redundant and does not perform any actions. It will be removed in future updates.")]
		[Token(Token = "0x60000A6")]
		[Address(RVA = "0xBDB63C", Offset = "0xBDB63C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public static void SetNewCryptoKey(byte newKey)
		{
		}

		[Obsolete("This API is redundant and does not perform any actions. It will be removed in future updates.")]
		[Token(Token = "0x60000A7")]
		[Address(RVA = "0xBDB640", Offset = "0xBDB640", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void ApplyNewCryptoKey()
		{
		}

		[Obsolete("Please use new Encrypt(value, key) API instead.", true)]
		[Token(Token = "0x60000A8")]
		[Address(RVA = "0xBDB644", Offset = "0xBDB644", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int Encrypt(bool value)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new Decrypt(value, key) API instead.", true)]
		[Token(Token = "0x60000A9")]
		[Address(RVA = "0xBDB67C", Offset = "0xBDB67C", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool Decrypt(int value)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new FromEncrypted(encrypted, key) API instead.", true)]
		[Token(Token = "0x60000AA")]
		[Address(RVA = "0xBDB6B4", Offset = "0xBDB6B4", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ObscuredBool FromEncrypted(int encrypted)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new GetEncrypted(out key) API instead.", true)]
		[Token(Token = "0x60000AB")]
		[Address(RVA = "0xBDB6EC", Offset = "0xBDB6EC", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int GetEncrypted()
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new SetEncrypted(encrypted, key) API instead.", true)]
		[Token(Token = "0x60000AC")]
		[Address(RVA = "0xBDB724", Offset = "0xBDB724", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetEncrypted(int encrypted)
		{
		}
	}
}
