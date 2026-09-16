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
	[Token(Token = "0x200001C")]
	public struct ObscuredSByte : IObscuredType, IFormattable, IEquatable<ObscuredSByte>, IComparable<ObscuredSByte>, IComparable<sbyte>, IComparable
	{
		[Token(Token = "0x400008C")]
		[FieldOffset(Offset = "0x0")]
		private sbyte currentCryptoKey;

		[Token(Token = "0x400008D")]
		[FieldOffset(Offset = "0x1")]
		private sbyte hiddenValue;

		[Token(Token = "0x400008E")]
		[FieldOffset(Offset = "0x2")]
		private bool inited;

		[Token(Token = "0x400008F")]
		[FieldOffset(Offset = "0x3")]
		private sbyte fakeValue;

		[Token(Token = "0x4000090")]
		[FieldOffset(Offset = "0x4")]
		private bool fakeValueActive;

		[Token(Token = "0x60001C6")]
		[Address(RVA = "0xBE01E4", Offset = "0xBE01E4", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateSByteKey();\n\tthis.currentCryptoKey = v10;\n\tv11 = v10 ^ value;\n\tthis.hiddenValue = v11;\n\tv13 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv16 = v13 == 0;\n\tv20 = ~v16;\n\tv21 = ~v20;\n\tif (v21) goto L_FFFFFFFF;\n\tgoto L_0019;\nL_0019:\n\tthis.fakeValueActive = v13;\n\tthis.fakeValue = v24;\n\tthis.inited = 1;\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private ObscuredSByte(sbyte value)
		{
			int num = (currentCryptoKey = RandomUtils.GenerateSByteKey()) ^ value;
			hiddenValue = (sbyte)num;
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			sbyte b = (sbyte)(existsAndIsRunning ? value : 0);
			fakeValueActive = existsAndIsRunning;
			fakeValue = b;
			inited = true;
		}

		[Token(Token = "0x60001C7")]
		[Address(RVA = "0xBE0234", Offset = "0xBE0234", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = key ^ value;\n\treturn returnVal1;\n")]
		public static sbyte Encrypt(sbyte value, sbyte key)
		{
			return (sbyte)(key ^ value);
		}

		[Token(Token = "0x60001C8")]
		[Address(RVA = "0xBE023C", Offset = "0xBE023C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = key ^ value;\n\treturn returnVal1;\n")]
		public static sbyte Decrypt(sbyte value, sbyte key)
		{
			return (sbyte)(key ^ value);
		}

		[Token(Token = "0x60001C9")]
		[Address(RVA = "0xBE0244", Offset = "0xBE0244", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = 0;\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredSByte::SetEncrypted(&v7 @ stack_-8_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredSByte), encrypted, key);\n\treturn 0;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ObscuredSByte FromEncrypted(sbyte encrypted, sbyte key)
		{
			default(ObscuredSByte).SetEncrypted(encrypted, key);
			return default(ObscuredSByte);
		}

		[Token(Token = "0x60001CA")]
		[Address(RVA = "0xBE0230", Offset = "0xBE0230", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateSByteKey();\n\treturn returnVal1;\n")]
		public static sbyte GenerateKey()
		{
			return RandomUtils.GenerateSByteKey();
		}

		[Token(Token = "0x60001CB")]
		[Address(RVA = "0xBE02BC", Offset = "0xBE02BC", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([key @ X1 (System.SByte&)]) = this.currentCryptoKey;\n\treturn this.hiddenValue;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe sbyte GetEncrypted(out sbyte key)
		{
			key = default(sbyte);
			ref sbyte reference = ref *(sbyte*)currentCryptoKey;
			return hiddenValue;
		}

		[Token(Token = "0x60001CC")]
		[Address(RVA = "0xBE0274", Offset = "0xBE0274", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.hiddenValue = encrypted;\n\tthis.inited = 1;\n\tthis.currentCryptoKey = key;\n\tv12 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tthis.fakeValueActive = 0;\n\tv14 = v12 == 0;\n\tif (v14) goto L_0017;\n\tv16 = CodeStage.AntiCheat.ObscuredTypes.ObscuredSByte::InternalDecrypt(this);\n\tthis.fakeValue = v16;\n\tthis.fakeValueActive = 1;\nL_0017:\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetEncrypted(sbyte encrypted, sbyte key)
		{
			hiddenValue = encrypted;
			inited = true;
			currentCryptoKey = key;
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			fakeValueActive = false;
			if (existsAndIsRunning)
			{
				sbyte b = InternalDecrypt();
				fakeValue = b;
				fakeValueActive = true;
			}
		}

		[Token(Token = "0x60001CD")]
		[Address(RVA = "0xBE03A8", Offset = "0xBE03A8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredSByte::InternalDecrypt(this);\n\treturn returnVal1;\n")]
		public sbyte GetDecrypted()
		{
			return InternalDecrypt();
		}

		[Token(Token = "0x60001CE")]
		[Address(RVA = "0xBE03AC", Offset = "0xBE03AC", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = CodeStage.AntiCheat.ObscuredTypes.ObscuredSByte::InternalDecrypt(this);\n\tv11 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateSByteKey();\n\tv12 = v11 ^ v8;\n\tthis.currentCryptoKey = v11;\n\tthis.hiddenValue = v12;\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RandomizeCryptoKey()
		{
			sbyte b = InternalDecrypt();
			sbyte b2 = RandomUtils.GenerateSByteKey();
			int num = b2 ^ b;
			currentCryptoKey = b2;
			hiddenValue = (sbyte)num;
		}

		[Token(Token = "0x60001CF")]
		[Address(RVA = "0xBE02CC", Offset = "0xBE02CC", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A35483]) = v33;\nL_0011:\n\tv35 = ~v31.inited;\n\tif (v35) goto L_0044;\n\tv84 = v31.currentCryptoKey ^ v31.hiddenValue;\n\tv40 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv43 = v40 == 0;\n\tif (v43) goto L_0050;\n\tv47 = ~v31.fakeValueActive;\n\tif (v47) goto L_0050;\n\tv64 = v31.fakeValue == v84;\n\tif (v64) goto L_0050;\n\tgoto L_0039;\n\tv116 = 0xB348B0(v111, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0039:\n\tgoto L_0042;\n\tv124 = 0xB348B0(v119, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0042:\n\tv78 = CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector>::OnCheatingDetected(v106.<Instance>k__BackingField);\n\tgoto L_0050;\nL_0044:\n\tv41 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateSByteKey();\n\tv31.currentCryptoKey = v41;\n\tv31.hiddenValue = v41;\n\tv31.fakeValueActive = 0;\n\tv31.inited = 1;\nL_0050:\n\treturn v84;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private sbyte InternalDecrypt()
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
				hiddenValue = (currentCryptoKey = RandomUtils.GenerateSByteKey());
				fakeValueActive = false;
				inited = true;
				fakeValue = 0;
				num = 0;
			}
			return (sbyte)num;
		}

		[Token(Token = "0x60001D0")]
		[Address(RVA = "0xBE03DC", Offset = "0xBE03DC", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateSByteKey();\n\tv12 = v10 ^ value;\n\tv14 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv16 = value & 0xFF;\n\tv20 = v14 == 0;\n\tv24 = v16 & 0xFF;\n\tv25 = v24 << 0x18;\n\tv27 = 0x100010000 | v25;\n\tv28 = ~v20;\n\tv29 = ~v28;\n\tif (v29) goto L_FFFFFFFF;\n\tgoto L_0020;\nL_0020:\n\tv34 = v10 & 0xFF;\n\tv35 = v32 & 0xFFFFFFFFFFFFFF00;\n\tv36 = v35 | v34;\n\tv39 = v12 & 0xFF;\n\tv40 = v39 & 0xFF;\n\tv41 = v40 << 8;\n\tv42 = v36 & 0xFFFFFFFFFFFF00FF;\n\treturnVal1 = v42 | v41;\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static implicit operator ObscuredSByte(sbyte value)
		{
			//IL_006f: Expected I4, but got I8
			//IL_011c: Expected O, but got I4
			sbyte b = RandomUtils.GenerateSByteKey();
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
			return (ObscuredSByte)(num13 | num12);
		}

		[Token(Token = "0x60001D1")]
		[Address(RVA = "0xBE0430", Offset = "0xBE0430", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredSByte::InternalDecrypt(&value @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredSByte));\n\treturn returnVal1;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static implicit operator sbyte(ObscuredSByte value)
		{
			ObscuredSByte obscuredSByte = default(ObscuredSByte);
			return obscuredSByte.InternalDecrypt();
		}

		[Token(Token = "0x60001D2")]
		[Address(RVA = "0xBE0450", Offset = "0xBE0450", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = input & 0xFFFFFFFFFF;\n\tv5 = CodeStage.AntiCheat.ObscuredTypes.ObscuredSByte::Increment(v2, 1);\n\treturnVal1 = v5 & 0xFFFFFFFFFF;\n\treturn returnVal1;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ObscuredSByte operator ++(ObscuredSByte input)
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Expected O, but got Unknown
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Expected O, but got Unknown
			ObscuredSByte input2 = (ObscuredSByte)(input & 0xFFFFFFFFFFL);
			ObscuredSByte obscuredSByte = Increment(input2, 1);
			return (ObscuredSByte)(obscuredSByte & 0xFFFFFFFFFFL);
		}

		[Token(Token = "0x60001D3")]
		[Address(RVA = "0xBE04D4", Offset = "0xBE04D4", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = input & 0xFFFFFFFFFF;\n\tv5 = CodeStage.AntiCheat.ObscuredTypes.ObscuredSByte::Increment(v2, 0xFFFFFFFF);\n\treturnVal1 = v5 & 0xFFFFFFFFFF;\n\treturn returnVal1;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ObscuredSByte operator --(ObscuredSByte input)
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Expected O, but got Unknown
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Expected O, but got Unknown
			ObscuredSByte input2 = (ObscuredSByte)(input & 0xFFFFFFFFFFL);
			ObscuredSByte obscuredSByte = Increment(input2, -1);
			return (ObscuredSByte)(obscuredSByte & 0xFFFFFFFFFFL);
		}

		[Token(Token = "0x60001D4")]
		[Address(RVA = "0xBE046C", Offset = "0xBE046C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = CodeStage.AntiCheat.ObscuredTypes.ObscuredSByte::InternalDecrypt(&v8 @ stack_-18_v2 (CodeStage.AntiCheat.ObscuredTypes.ObscuredSByte));\n\tv18 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv20 = v18 == 0;\n\tif (v20) goto L_FFFFFFFF;\n\tgoto L_001A;\nL_001A:\n\tv31 = v26 & 0xFF;\n\tv32 = v31 & 0xFF;\n\tv33 = v32 << 0x20;\n\tv34 = v8 & 0xFFFFFF00FFFFFFFF;\n\treturnVal1 = v34 | v33;\n\treturn returnVal1;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static ObscuredSByte Increment(ObscuredSByte input, int increment)
		{
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Expected I4, but got Unknown
			//IL_009d: Expected O, but got I4
			ObscuredSByte obscuredSByte = default(ObscuredSByte);
			sbyte b = obscuredSByte.InternalDecrypt();
			int num = (ObscuredCheatingDetector.ExistsAndIsRunning ? 1 : 0);
			int num2 = num & 0xFF;
			int num3 = num2 & 0xFF;
			int num4 = num3 << 32;
			int num5 = (int)(obscuredSByte & -1095216660481L);
			return (ObscuredSByte)(num5 | num4);
		}

		[Token(Token = "0x60001D5")]
		[Address(RVA = "0xBE04F0", Offset = "0xBE04F0", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = CodeStage.AntiCheat.ObscuredTypes.ObscuredSByte::InternalDecrypt(this);\n\treturnVal1 = System.SByte::GetHashCode(&v2 @ X0_v1 (System.SByte));\n\treturn returnVal1;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override int GetHashCode()
		{
			return InternalDecrypt().GetHashCode();
		}

		[Token(Token = "0x60001D6")]
		[Address(RVA = "0xBE0510", Offset = "0xBE0510", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = CodeStage.AntiCheat.ObscuredTypes.ObscuredSByte::InternalDecrypt(this);\n\treturnVal1 = System.SByte::ToString(&v2 @ X0_v1 (System.SByte));\n\treturn returnVal1;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			return InternalDecrypt().ToString();
		}

		[Token(Token = "0x60001D7")]
		[Address(RVA = "0xBE0530", Offset = "0xBE0530", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredSByte::InternalDecrypt(this);\n\treturnVal1 = System.SByte::ToString(&v6 @ X0_v1 (System.SByte), format);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string ToString(string format)
		{
			return InternalDecrypt().ToString(format);
		}

		[Token(Token = "0x60001D8")]
		[Address(RVA = "0xBE0560", Offset = "0xBE0560", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredSByte::InternalDecrypt(this);\n\treturnVal1 = System.SByte::ToString(&v6 @ X0_v1 (System.SByte), provider);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string ToString(IFormatProvider provider)
		{
			return InternalDecrypt().ToString(provider);
		}

		[Token(Token = "0x60001D9")]
		[Address(RVA = "0xBE0590", Offset = "0xBE0590", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = CodeStage.AntiCheat.ObscuredTypes.ObscuredSByte::InternalDecrypt(this);\n\treturnVal1 = System.SByte::ToString(&v10 @ X0_v1 (System.SByte), format, provider);\n\treturn returnVal1;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string ToString(string format, IFormatProvider provider)
		{
			return InternalDecrypt().ToString(format, provider);
		}

		[Token(Token = "0x60001DA")]
		[Address(RVA = "0xBE05C8", Offset = "0xBE05C8", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredSByte;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, obj, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A35484]) = v36;\nL_0012:\n\tv37 = obj == 0;\n\tif (v37) goto L_0028;\n\tv46 = *([obj @ X1 (System.Object)]) == CodeStage.AntiCheat.ObscuredTypes.ObscuredSByte;\n\tif (v46) goto L_002A;\nL_0028:\n\treturn 0;\nL_002A:\n\tv76 = \"il2cpp_vm_object_unbox\"(obj, obj, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv104 = *([v76 @ X0_v4+4]) & 0xFF;\n\tv93 = v104 << 0x20;\n\tv105 = *([v76 @ X0_v4]) & 0xFFFFFF00FFFFFFFF;\n\tv78 = v105 | v93;\n\treturnVal2 = CodeStage.AntiCheat.ObscuredTypes.ObscuredSByte::Equals(this, v78);\n\treturn returnVal2;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override bool Equals(object obj)
		{
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Expected I4, but got Unknown
			//IL_007f: Expected O, but got I4
			if (obj == null || (object)obj.GetType() != typeof(ObscuredSByte))
			{
				return false;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ X0_v4+4]");
			int num = (int)((nint)0 & (nint)0xFF);
			int num2 = num << 32;
			object obj2 = default(object);
			int num3 = (int)(obj2 & -1095216660481L);
			ObscuredSByte obj3 = (ObscuredSByte)(num3 | num2);
			return Equals(obj3);
		}

		[Token(Token = "0x60001DB")]
		[Address(RVA = "0xBE0648", Offset = "0xBE0648", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv28 = this + 1;\n\tv7 = obj >> 8;\n\tv17 = this.currentCryptoKey != obj;\n\tif (v17) goto L_0013;\n\tgoto L_0018;\nL_0013:\n\tv19 = v7 ^ obj;\n\tv22 = this.hiddenValue ^ this.currentCryptoKey;\nL_0018:\n\tv31 = System.SByte::Equals(v28, v27);\n\treturn v31;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe bool Equals(ObscuredSByte obj)
		{
			//IL_0019: Expected I4, but got O
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Expected I4, but got Unknown
			sbyte b = (sbyte)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 1));
			int num = (object)obj >> 8;
			sbyte obj2;
			if (currentCryptoKey == (nint)obj)
			{
				obj2 = (sbyte)num;
			}
			else
			{
				int num2 = num ^ obj;
				int num3 = hiddenValue ^ currentCryptoKey;
				obj2 = (sbyte)num2;
				b = (sbyte)(&num3);
			}
			return ((sbyte*)b)->Equals(obj2);
		}

		[Token(Token = "0x60001DC")]
		[Address(RVA = "0xBE068C", Offset = "0xBE068C", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredSByte::InternalDecrypt(this);\n\tv10 = CodeStage.AntiCheat.ObscuredTypes.ObscuredSByte::InternalDecrypt(&other @ X1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredSByte));\n\treturnVal1 = System.SByte::CompareTo(&v6 @ X0_v1 (System.SByte), v10);\n\treturn returnVal1;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int CompareTo(ObscuredSByte other)
		{
			sbyte b = InternalDecrypt();
			ObscuredSByte obscuredSByte = default(ObscuredSByte);
			sbyte value = obscuredSByte.InternalDecrypt();
			return b.CompareTo(value);
		}

		[Token(Token = "0x60001DD")]
		[Address(RVA = "0xBE06CC", Offset = "0xBE06CC", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredSByte::InternalDecrypt(this);\n\treturnVal1 = System.SByte::CompareTo(&v6 @ X0_v1 (System.SByte), other);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int CompareTo(sbyte other)
		{
			return InternalDecrypt().CompareTo(other);
		}

		[Token(Token = "0x60001DE")]
		[Address(RVA = "0xBE06FC", Offset = "0xBE06FC", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredSByte::InternalDecrypt(this);\n\treturnVal1 = System.SByte::CompareTo(&v6 @ X0_v1 (System.SByte), obj);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int CompareTo(object obj)
		{
			return InternalDecrypt().CompareTo(obj);
		}

		[Obsolete("This API is redundant and does not perform any actions. It will be removed in future updates.")]
		[Token(Token = "0x60001DF")]
		[Address(RVA = "0xBE072C", Offset = "0xBE072C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public static void SetNewCryptoKey(sbyte newKey)
		{
		}

		[Obsolete("This API is redundant and does not perform any actions. It will be removed in future updates.")]
		[Token(Token = "0x60001E0")]
		[Address(RVA = "0xBE0730", Offset = "0xBE0730", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void ApplyNewCryptoKey()
		{
		}

		[Obsolete("Please use new Encrypt(value, key) or Decrypt(value, key) API instead.", true)]
		[Token(Token = "0x60001E1")]
		[Address(RVA = "0xBE0734", Offset = "0xBE0734", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static sbyte EncryptDecrypt(sbyte value)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new Encrypt(value, key) or Decrypt(value, key) APIs instead. This API will be removed in future updates.")]
		[Token(Token = "0x60001E2")]
		[Address(RVA = "0xBE076C", Offset = "0xBE076C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = key ^ value;\n\treturn returnVal1;\n")]
		public static sbyte EncryptDecrypt(sbyte value, sbyte key)
		{
			return (sbyte)(key ^ value);
		}

		[Obsolete("Please use new FromEncrypted(encrypted, key) API instead.", true)]
		[Token(Token = "0x60001E3")]
		[Address(RVA = "0xBE0774", Offset = "0xBE0774", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ObscuredSByte FromEncrypted(sbyte encrypted)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new GetEncrypted(out key) API instead.", true)]
		[Token(Token = "0x60001E4")]
		[Address(RVA = "0xBE07AC", Offset = "0xBE07AC", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public sbyte GetEncrypted()
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new SetEncrypted(encrypted, key) API instead.", true)]
		[Token(Token = "0x60001E5")]
		[Address(RVA = "0xBE07E4", Offset = "0xBE07E4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetEncrypted(sbyte encrypted)
		{
		}
	}
}
