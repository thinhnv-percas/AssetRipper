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
	[Token(Token = "0x2000010")]
	public struct ObscuredByte : IObscuredType, IFormattable, IEquatable<ObscuredByte>, IComparable<ObscuredByte>, IComparable<byte>, IComparable
	{
		[Token(Token = "0x4000053")]
		[FieldOffset(Offset = "0x0")]
		private byte currentCryptoKey;

		[Token(Token = "0x4000054")]
		[FieldOffset(Offset = "0x1")]
		private byte hiddenValue;

		[Token(Token = "0x4000055")]
		[FieldOffset(Offset = "0x2")]
		private bool inited;

		[Token(Token = "0x4000056")]
		[FieldOffset(Offset = "0x3")]
		private byte fakeValue;

		[Token(Token = "0x4000057")]
		[FieldOffset(Offset = "0x4")]
		private bool fakeValueActive;

		[Token(Token = "0x60000AD")]
		[Address(RVA = "0xBDB728", Offset = "0xBDB728", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateByteKey();\n\tthis.currentCryptoKey = v10;\n\tv11 = v10 ^ value;\n\tthis.hiddenValue = v11;\n\tv13 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv16 = v13 == 0;\n\tv20 = ~v16;\n\tv21 = ~v20;\n\tif (v21) goto L_FFFFFFFF;\n\tgoto L_0019;\nL_0019:\n\tthis.fakeValueActive = v13;\n\tthis.fakeValue = v24;\n\tthis.inited = 1;\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private ObscuredByte(byte value)
		{
			int num = (currentCryptoKey = RandomUtils.GenerateByteKey()) ^ value;
			hiddenValue = (byte)num;
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			byte b = (byte)(existsAndIsRunning ? value : 0);
			fakeValueActive = existsAndIsRunning;
			fakeValue = b;
			inited = true;
		}

		[Token(Token = "0x60000AE")]
		[Address(RVA = "0xBDB778", Offset = "0xBDB778", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = key ^ value;\n\treturn returnVal1;\n")]
		public static byte Encrypt(byte value, byte key)
		{
			return (byte)(key ^ value);
		}

		[Token(Token = "0x60000AF")]
		[Address(RVA = "0xBDB780", Offset = "0xBDB780", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = value.Length < 1;\n\tif (v15) goto L_002F;\n\tv55 = value.Length & 0xFFFFFFFF;\nL_001F:\n\tv75 = value[v25 @ X8_v4 (System.Int32)] ^ key;\n\tvalue[v25 @ X8_v4 (System.Int32)] = v75;\n\tv25 = v25 + 1;\n\tv80 = v55 != v25;\n\tif (v80) goto L_001F;\nL_002F:\n\treturn;\n\tv17 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Encrypt(byte[] value, byte key)
		{
			//IL_0033: Expected I4, but got I8
			if (value.Length >= 1)
			{
				int num = (int)(value.Length & 0xFFFFFFFFL);
				int num2 = 0;
				do
				{
					int num3 = value[num2] ^ key;
					value[num2] = (byte)num3;
					num2++;
				}
				while (num != num2);
			}
		}

		[Token(Token = "0x60000B0")]
		[Address(RVA = "0xBDB7D0", Offset = "0xBDB7D0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = key ^ value;\n\treturn returnVal1;\n")]
		public static byte Decrypt(byte value, byte key)
		{
			return (byte)(key ^ value);
		}

		[Token(Token = "0x60000B1")]
		[Address(RVA = "0xBDB7D8", Offset = "0xBDB7D8", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = value.Length < 1;\n\tif (v15) goto L_002F;\n\tv55 = value.Length & 0xFFFFFFFF;\nL_001F:\n\tv75 = value[v25 @ X8_v4 (System.Int32)] ^ key;\n\tvalue[v25 @ X8_v4 (System.Int32)] = v75;\n\tv25 = v25 + 1;\n\tv80 = v55 != v25;\n\tif (v80) goto L_001F;\nL_002F:\n\treturn;\n\tv17 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Decrypt(byte[] value, byte key)
		{
			//IL_0033: Expected I4, but got I8
			if (value.Length >= 1)
			{
				int num = (int)(value.Length & 0xFFFFFFFFL);
				int num2 = 0;
				do
				{
					int num3 = value[num2] ^ key;
					value[num2] = (byte)num3;
					num2++;
				}
				while (num != num2);
			}
		}

		[Token(Token = "0x60000B2")]
		[Address(RVA = "0xBDB828", Offset = "0xBDB828", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = 0;\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredByte::SetEncrypted(&v7 @ stack_-8_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredByte), encrypted, key);\n\treturn 0;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ObscuredByte FromEncrypted(byte encrypted, byte key)
		{
			default(ObscuredByte).SetEncrypted(encrypted, key);
			return default(ObscuredByte);
		}

		[Token(Token = "0x60000B3")]
		[Address(RVA = "0xBDB774", Offset = "0xBDB774", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateByteKey();\n\treturn returnVal1;\n")]
		public static byte GenerateKey()
		{
			return RandomUtils.GenerateByteKey();
		}

		[Token(Token = "0x60000B4")]
		[Address(RVA = "0xBDB8A0", Offset = "0xBDB8A0", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([key @ X1 (System.Byte&)]) = this.currentCryptoKey;\n\treturn this.hiddenValue;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe byte GetEncrypted(out byte key)
		{
			key = default(byte);
			ref byte reference = ref *(byte*)currentCryptoKey;
			return hiddenValue;
		}

		[Token(Token = "0x60000B5")]
		[Address(RVA = "0xBDB858", Offset = "0xBDB858", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.hiddenValue = encrypted;\n\tthis.inited = 1;\n\tthis.currentCryptoKey = key;\n\tv12 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tthis.fakeValueActive = 0;\n\tv14 = v12 == 0;\n\tif (v14) goto L_0017;\n\tv16 = CodeStage.AntiCheat.ObscuredTypes.ObscuredByte::InternalDecrypt(this);\n\tthis.fakeValue = v16;\n\tthis.fakeValueActive = 1;\nL_0017:\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetEncrypted(byte encrypted, byte key)
		{
			hiddenValue = encrypted;
			inited = true;
			currentCryptoKey = key;
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			fakeValueActive = false;
			if (existsAndIsRunning)
			{
				byte b = InternalDecrypt();
				fakeValue = b;
				fakeValueActive = true;
			}
		}

		[Token(Token = "0x60000B6")]
		[Address(RVA = "0xBDB98C", Offset = "0xBDB98C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredByte::InternalDecrypt(this);\n\treturn returnVal1;\n")]
		public byte GetDecrypted()
		{
			return InternalDecrypt();
		}

		[Token(Token = "0x60000B7")]
		[Address(RVA = "0xBDB990", Offset = "0xBDB990", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = CodeStage.AntiCheat.ObscuredTypes.ObscuredByte::InternalDecrypt(this);\n\tv11 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateByteKey();\n\tv12 = v11 ^ v8;\n\tthis.currentCryptoKey = v11;\n\tthis.hiddenValue = v12;\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RandomizeCryptoKey()
		{
			byte b = InternalDecrypt();
			byte b2 = RandomUtils.GenerateByteKey();
			int num = b2 ^ b;
			currentCryptoKey = b2;
			hiddenValue = (byte)num;
		}

		[Token(Token = "0x60000B8")]
		[Address(RVA = "0xBDB8B0", Offset = "0xBDB8B0", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A35452]) = v33;\nL_0011:\n\tv35 = ~v31.inited;\n\tif (v35) goto L_0044;\n\tv84 = v31.currentCryptoKey ^ v31.hiddenValue;\n\tv40 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv43 = v40 == 0;\n\tif (v43) goto L_0050;\n\tv47 = ~v31.fakeValueActive;\n\tif (v47) goto L_0050;\n\tv64 = v31.fakeValue == v84;\n\tif (v64) goto L_0050;\n\tgoto L_0039;\n\tv116 = 0xB348B0(v111, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0039:\n\tgoto L_0042;\n\tv124 = 0xB348B0(v119, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0042:\n\tv78 = CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector>::OnCheatingDetected(v106.<Instance>k__BackingField);\n\tgoto L_0050;\nL_0044:\n\tv41 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateByteKey();\n\tv31.currentCryptoKey = v41;\n\tv31.hiddenValue = v41;\n\tv31.fakeValueActive = 0;\n\tv31.inited = 1;\nL_0050:\n\treturn v84;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private byte InternalDecrypt()
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
				hiddenValue = (currentCryptoKey = RandomUtils.GenerateByteKey());
				fakeValueActive = false;
				inited = true;
				fakeValue = 0;
				num = 0;
			}
			return (byte)num;
		}

		[Token(Token = "0x60000B9")]
		[Address(RVA = "0xBDB9C0", Offset = "0xBDB9C0", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateByteKey();\n\tv12 = v10 ^ value;\n\tv14 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv16 = value & 0xFF;\n\tv20 = v14 == 0;\n\tv24 = v16 & 0xFF;\n\tv25 = v24 << 0x18;\n\tv27 = 0x100010000 | v25;\n\tv28 = ~v20;\n\tv29 = ~v28;\n\tif (v29) goto L_FFFFFFFF;\n\tgoto L_0020;\nL_0020:\n\tv34 = v10 & 0xFF;\n\tv35 = v32 & 0xFFFFFFFFFFFFFF00;\n\tv36 = v35 | v34;\n\tv39 = v12 & 0xFF;\n\tv40 = v39 & 0xFF;\n\tv41 = v40 << 8;\n\tv42 = v36 & 0xFFFFFFFFFFFF00FF;\n\treturnVal1 = v42 | v41;\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static implicit operator ObscuredByte(byte value)
		{
			//IL_006f: Expected I4, but got I8
			//IL_011c: Expected O, but got I4
			byte b = RandomUtils.GenerateByteKey();
			int num = b ^ value;
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			int num2 = value & 0xFF;
			bool flag = !existsAndIsRunning;
			int num3 = num2 & 0xFF;
			int num4 = num3 << 24;
			int num5 = (int)(0x100010000L | num4);
			int num6 = (flag ? 65536 : num5);
			int num7 = b & 0xFF;
			int num8 = num6 & -256;
			int num9 = num8 | num7;
			int num10 = num & 0xFF;
			int num11 = num10 & 0xFF;
			int num12 = num11 << 8;
			int num13 = num9 & -65281;
			return (ObscuredByte)(num13 | num12);
		}

		[Token(Token = "0x60000BA")]
		[Address(RVA = "0xBDBA14", Offset = "0xBDBA14", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredByte::InternalDecrypt(&value @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredByte));\n\treturn returnVal1;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static implicit operator byte(ObscuredByte value)
		{
			ObscuredByte obscuredByte = default(ObscuredByte);
			return obscuredByte.InternalDecrypt();
		}

		[Token(Token = "0x60000BB")]
		[Address(RVA = "0xBDBA34", Offset = "0xBDBA34", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = input & 0xFFFFFFFFFF;\n\tv5 = CodeStage.AntiCheat.ObscuredTypes.ObscuredByte::Increment(v2, 1);\n\treturnVal1 = v5 & 0xFFFFFFFFFF;\n\treturn returnVal1;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ObscuredByte operator ++(ObscuredByte input)
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Expected O, but got Unknown
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Expected O, but got Unknown
			ObscuredByte input2 = (ObscuredByte)(input & 0xFFFFFFFFFFL);
			ObscuredByte obscuredByte = Increment(input2, 1);
			return (ObscuredByte)(obscuredByte & 0xFFFFFFFFFFL);
		}

		[Token(Token = "0x60000BC")]
		[Address(RVA = "0xBDBAB8", Offset = "0xBDBAB8", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = input & 0xFFFFFFFFFF;\n\tv5 = CodeStage.AntiCheat.ObscuredTypes.ObscuredByte::Increment(v2, 0xFFFFFFFF);\n\treturnVal1 = v5 & 0xFFFFFFFFFF;\n\treturn returnVal1;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ObscuredByte operator --(ObscuredByte input)
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Expected O, but got Unknown
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Expected O, but got Unknown
			ObscuredByte input2 = (ObscuredByte)(input & 0xFFFFFFFFFFL);
			ObscuredByte obscuredByte = Increment(input2, -1);
			return (ObscuredByte)(obscuredByte & 0xFFFFFFFFFFL);
		}

		[Token(Token = "0x60000BD")]
		[Address(RVA = "0xBDBA50", Offset = "0xBDBA50", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = CodeStage.AntiCheat.ObscuredTypes.ObscuredByte::InternalDecrypt(&v8 @ stack_-18_v2 (CodeStage.AntiCheat.ObscuredTypes.ObscuredByte));\n\tv18 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv20 = v18 == 0;\n\tif (v20) goto L_FFFFFFFF;\n\tgoto L_001A;\nL_001A:\n\tv31 = v26 & 0xFF;\n\tv32 = v31 & 0xFF;\n\tv33 = v32 << 0x20;\n\tv34 = v8 & 0xFFFFFF00FFFFFFFF;\n\treturnVal1 = v34 | v33;\n\treturn returnVal1;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static ObscuredByte Increment(ObscuredByte input, int increment)
		{
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Expected I4, but got Unknown
			//IL_009d: Expected O, but got I4
			ObscuredByte obscuredByte = default(ObscuredByte);
			byte b = obscuredByte.InternalDecrypt();
			int num = (ObscuredCheatingDetector.ExistsAndIsRunning ? 1 : 0);
			int num2 = num & 0xFF;
			int num3 = num2 & 0xFF;
			int num4 = num3 << 32;
			int num5 = (int)(obscuredByte & -1095216660481L);
			return (ObscuredByte)(num5 | num4);
		}

		[Token(Token = "0x60000BE")]
		[Address(RVA = "0xBDBAD4", Offset = "0xBDBAD4", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = CodeStage.AntiCheat.ObscuredTypes.ObscuredByte::InternalDecrypt(this);\n\treturnVal1 = System.Byte::GetHashCode(&v2 @ X0_v1 (System.Byte));\n\treturn returnVal1;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override int GetHashCode()
		{
			return InternalDecrypt().GetHashCode();
		}

		[Token(Token = "0x60000BF")]
		[Address(RVA = "0xBDBAF4", Offset = "0xBDBAF4", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = CodeStage.AntiCheat.ObscuredTypes.ObscuredByte::InternalDecrypt(this);\n\treturnVal1 = System.Byte::ToString(&v2 @ X0_v1 (System.Byte));\n\treturn returnVal1;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			return InternalDecrypt().ToString();
		}

		[Token(Token = "0x60000C0")]
		[Address(RVA = "0xBDBB14", Offset = "0xBDBB14", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredByte::InternalDecrypt(this);\n\treturnVal1 = System.Byte::ToString(&v6 @ X0_v1 (System.Byte), format);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string ToString(string format)
		{
			return InternalDecrypt().ToString(format);
		}

		[Token(Token = "0x60000C1")]
		[Address(RVA = "0xBDBB44", Offset = "0xBDBB44", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredByte::InternalDecrypt(this);\n\treturnVal1 = System.Byte::ToString(&v6 @ X0_v1 (System.Byte), provider);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string ToString(IFormatProvider provider)
		{
			return InternalDecrypt().ToString(provider);
		}

		[Token(Token = "0x60000C2")]
		[Address(RVA = "0xBDBB74", Offset = "0xBDBB74", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = CodeStage.AntiCheat.ObscuredTypes.ObscuredByte::InternalDecrypt(this);\n\treturnVal1 = System.Byte::ToString(&v10 @ X0_v1 (System.Byte), format, provider);\n\treturn returnVal1;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string ToString(string format, IFormatProvider provider)
		{
			return InternalDecrypt().ToString(format, provider);
		}

		[Token(Token = "0x60000C3")]
		[Address(RVA = "0xBDBBAC", Offset = "0xBDBBAC", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredByte;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, obj, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A35453]) = v36;\nL_0012:\n\tv37 = obj == 0;\n\tif (v37) goto L_0028;\n\tv46 = *([obj @ X1 (System.Object)]) == CodeStage.AntiCheat.ObscuredTypes.ObscuredByte;\n\tif (v46) goto L_002A;\nL_0028:\n\treturn 0;\nL_002A:\n\tv76 = \"il2cpp_vm_object_unbox\"(obj, obj, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv104 = *([v76 @ X0_v4+4]) & 0xFF;\n\tv93 = v104 << 0x20;\n\tv105 = *([v76 @ X0_v4]) & 0xFFFFFF00FFFFFFFF;\n\tv78 = v105 | v93;\n\treturnVal2 = CodeStage.AntiCheat.ObscuredTypes.ObscuredByte::Equals(this, v78);\n\treturn returnVal2;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override bool Equals(object obj)
		{
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Expected I4, but got Unknown
			//IL_0084: Expected O, but got I4
			if (obj == null || (object)obj.GetType() != typeof(ObscuredByte))
			{
				return false;
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ X0_v4+4]");
			int num = (int)((nint)0 & (nint)0xFF);
			int num2 = num << 32;
			object obj2 = default(object);
			int num3 = (int)(obj2 & -1095216660481L);
			ObscuredByte obj3 = (ObscuredByte)(num3 | num2);
			return Equals(obj3);
		}

		[Token(Token = "0x60000C4")]
		[Address(RVA = "0xBDBC2C", Offset = "0xBDBC2C", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv28 = this + 1;\n\tv7 = obj >> 8;\n\tv17 = this.currentCryptoKey != obj;\n\tif (v17) goto L_0013;\n\tgoto L_0018;\nL_0013:\n\tv19 = v7 ^ obj;\n\tv22 = this.hiddenValue ^ this.currentCryptoKey;\nL_0018:\n\tv31 = System.Byte::Equals(v28, v27);\n\treturn v31;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe bool Equals(ObscuredByte obj)
		{
			//IL_0019: Expected I4, but got O
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Expected I4, but got Unknown
			byte b = (byte)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 1));
			int num = (object)obj >> 8;
			byte obj2;
			if ((int)currentCryptoKey == (nint)obj)
			{
				obj2 = (byte)num;
			}
			else
			{
				int num2 = num ^ obj;
				int num3 = hiddenValue ^ currentCryptoKey;
				obj2 = (byte)num2;
				b = (byte)(&num3);
			}
			return ((byte*)b)->Equals(obj2);
		}

		[Token(Token = "0x60000C5")]
		[Address(RVA = "0xBDBC70", Offset = "0xBDBC70", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredByte::InternalDecrypt(this);\n\tv10 = CodeStage.AntiCheat.ObscuredTypes.ObscuredByte::InternalDecrypt(&other @ X1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredByte));\n\treturnVal1 = System.Byte::CompareTo(&v6 @ X0_v1 (System.Byte), v10);\n\treturn returnVal1;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int CompareTo(ObscuredByte other)
		{
			byte b = InternalDecrypt();
			ObscuredByte obscuredByte = default(ObscuredByte);
			byte value = obscuredByte.InternalDecrypt();
			return b.CompareTo(value);
		}

		[Token(Token = "0x60000C6")]
		[Address(RVA = "0xBDBCB0", Offset = "0xBDBCB0", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredByte::InternalDecrypt(this);\n\treturnVal1 = System.Byte::CompareTo(&v6 @ X0_v1 (System.Byte), other);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int CompareTo(byte other)
		{
			return InternalDecrypt().CompareTo(other);
		}

		[Token(Token = "0x60000C7")]
		[Address(RVA = "0xBDBCE0", Offset = "0xBDBCE0", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredByte::InternalDecrypt(this);\n\treturnVal1 = System.Byte::CompareTo(&v6 @ X0_v1 (System.Byte), obj);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int CompareTo(object obj)
		{
			return InternalDecrypt().CompareTo(obj);
		}

		[Obsolete("This API is redundant and does not perform any actions. It will be removed in future updates.")]
		[Token(Token = "0x60000C8")]
		[Address(RVA = "0xBDBD10", Offset = "0xBDBD10", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public static void SetNewCryptoKey(byte newKey)
		{
		}

		[Obsolete("This API is redundant and does not perform any actions. It will be removed in future updates.")]
		[Token(Token = "0x60000C9")]
		[Address(RVA = "0xBDBD14", Offset = "0xBDBD14", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void ApplyNewCryptoKey()
		{
		}

		[Obsolete("Please use new Encrypt(value, key) or Decrypt(value, key) API instead.", true)]
		[Token(Token = "0x60000CA")]
		[Address(RVA = "0xBDBD18", Offset = "0xBDBD18", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static byte EncryptDecrypt(byte value)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new Encrypt(value, key) or Decrypt(value, key) API instead.", true)]
		[Token(Token = "0x60000CB")]
		[Address(RVA = "0xBDBD50", Offset = "0xBDBD50", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static byte EncryptDecrypt(byte[] value)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new Encrypt(value, key) or Decrypt(value, key) APIs instead. This API will be removed in future updates.")]
		[Token(Token = "0x60000CC")]
		[Address(RVA = "0xBDBD88", Offset = "0xBDBD88", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = key ^ value;\n\treturn returnVal1;\n")]
		public static byte EncryptDecrypt(byte value, byte key)
		{
			return (byte)(key ^ value);
		}

		[Obsolete("Please use new Encrypt(value, key) or Decrypt(value, key) APIs instead. This API will be removed in future updates.")]
		[Token(Token = "0x60000CD")]
		[Address(RVA = "0xBDBD90", Offset = "0xBDBD90", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = value.Length < 1;\n\tif (v15) goto L_002F;\n\tv55 = value.Length & 0xFFFFFFFF;\nL_001F:\n\tv75 = value[v25 @ X8_v4 (System.Int32)] ^ key;\n\tvalue[v25 @ X8_v4 (System.Int32)] = v75;\n\tv25 = v25 + 1;\n\tv80 = v55 != v25;\n\tif (v80) goto L_001F;\nL_002F:\n\treturn;\n\tv17 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void EncryptDecrypt(byte[] value, byte key)
		{
			//IL_0033: Expected I4, but got I8
			if (value.Length >= 1)
			{
				int num = (int)(value.Length & 0xFFFFFFFFL);
				int num2 = 0;
				do
				{
					int num3 = value[num2] ^ key;
					value[num2] = (byte)num3;
					num2++;
				}
				while (num != num2);
			}
		}

		[Obsolete("Please use new FromEncrypted(encrypted, key) API instead.", true)]
		[Token(Token = "0x60000CE")]
		[Address(RVA = "0xBDBDE0", Offset = "0xBDBDE0", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ObscuredByte FromEncrypted(byte encrypted)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new GetEncrypted(out key) API instead.", true)]
		[Token(Token = "0x60000CF")]
		[Address(RVA = "0xBDBE18", Offset = "0xBDBE18", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public byte GetEncrypted()
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new SetEncrypted(encrypted, key) API instead.", true)]
		[Token(Token = "0x60000D0")]
		[Address(RVA = "0xBDBE50", Offset = "0xBDBE50", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetEncrypted(byte encrypted)
		{
		}
	}
}
