using System;
using System.Runtime.InteropServices;
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
	[Token(Token = "0x2000014")]
	public struct ObscuredDouble : IObscuredType, IFormattable, IEquatable<ObscuredDouble>, IComparable<ObscuredDouble>, IComparable<double>, IComparable
	{
		[StructLayout((LayoutKind)2)]
		[Token(Token = "0x2000015")]
		private struct DoubleLongBytesUnion
		{
			[System.Runtime.InteropServices.FieldOffset(0)]
			[Token(Token = "0x400006C")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			internal double d;

			[System.Runtime.InteropServices.FieldOffset(0)]
			[Token(Token = "0x400006D")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			internal long l;

			[System.Runtime.InteropServices.FieldOffset(0)]
			[Token(Token = "0x400006E")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			internal ACTkByte8 b8;

			[Token(Token = "0x600013B")]
			[Address(RVA = "0xBDD6B8", Offset = "0xBDD6B8", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = fromVersion & 0xFF;\n\tv4 = v2 < 1;\n\tv5 = ~v4;\n\tv6 = v2 - 1;\n\tv8 = v6 == 0;\n\tv15 = ~v8;\n\tv16 = v5 & v15;\n\tif (v16) goto L_0022;\n\tv17 = toVersion & 0xFF;\n\tv28 = v17 != 2;\n\tif (v28) goto L_0022;\n\tCodeStage.AntiCheat.Common.ACTkByte8::Shuffle(&v35 @ stack_-8_v3 (CodeStage.AntiCheat.Common.ACTkByte8));\nL_0022:\n\treturn v35;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			internal static long Migrate(long value, byte fromVersion, byte toVersion)
			{
				//IL_00ac: Expected I8, but got O
				int num = fromVersion & 0xFF;
				bool flag = num < 1;
				bool flag2 = !flag;
				int num2 = num - 1;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				ACTkByte8 aCTkByte = default(ACTkByte8);
				if (!(flag2 && flag4))
				{
					int num3 = toVersion & 0xFF;
					if (num3 == 2)
					{
						aCTkByte.Shuffle();
					}
				}
				return (long)aCTkByte;
			}

			[Token(Token = "0x600013C")]
			[Address(RVA = "0xBDD5F0", Offset = "0xBDD5F0", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = value ^ key;\n\tCodeStage.AntiCheat.Common.ACTkByte8::Shuffle(&v4 @ X8_v2 (System.Int64));\n\treturn v4;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			internal unsafe static long XorDoubleToLong(double value, long key)
			{
				//IL_0008: Unknown result type (might be due to invalid IL or missing references)
				//IL_000d: Expected I8, but got Unknown
				long result = value ^ key;
				((ACTkByte8*)(&result))->Shuffle();
				return result;
			}

			[Token(Token = "0x600013D")]
			[Address(RVA = "0xBDD64C", Offset = "0xBDD64C", Length = "0x34")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tCodeStage.AntiCheat.Common.ACTkByte8::UnShuffle(&v9 @ stack_-18_v2 (CodeStage.AntiCheat.Common.ACTkByte8));\n\tv12 = v9 ^ key;\n\treturn v12;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			internal static double XorLongToDouble(long value, long key)
			{
				//IL_0011: Unknown result type (might be due to invalid IL or missing references)
				//IL_0016: Expected I8, but got Unknown
				ACTkByte8 aCTkByte = default(ACTkByte8);
				aCTkByte.UnShuffle();
				long num = aCTkByte ^ key;
				return num;
			}

			[Token(Token = "0x600013E")]
			[Address(RVA = "0xBDDE14", Offset = "0xBDDE14", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn value;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private static DoubleLongBytesUnion FromDouble(double value)
			{
				//IL_0005: Expected O, but got F8
				return (DoubleLongBytesUnion)value;
			}

			[Token(Token = "0x600013F")]
			[Address(RVA = "0xBDDE10", Offset = "0xBDDE10", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn value;\n")]
			private static DoubleLongBytesUnion FromLong(long value)
			{
				//IL_0005: Expected O, but got I8
				return (DoubleLongBytesUnion)value;
			}

			[Token(Token = "0x6000140")]
			[Address(RVA = "0xBDDE1C", Offset = "0xBDDE1C", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = this.d ^ key;\n\tthis.d = v7;\n\tCodeStage.AntiCheat.Common.ACTkByte8::Shuffle(this);\n\treturn this.d;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private DoubleLongBytesUnion Shuffle(long key)
			{
				//IL_000a: Unknown result type (might be due to invalid IL or missing references)
				//IL_000f: Expected I8, but got Unknown
				//IL_0027: Expected O, but got F8
				long num = d ^ key;
				d = num;
				((ACTkByte8)this).Shuffle();
				return (DoubleLongBytesUnion)d;
			}

			[Token(Token = "0x6000141")]
			[Address(RVA = "0xBDDE44", Offset = "0xBDDE44", Length = "0x30")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tCodeStage.AntiCheat.Common.ACTkByte8::UnShuffle(this);\n\treturnVal1 = this.d ^ key;\n\tthis.d = returnVal1;\n\treturn returnVal1;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private DoubleLongBytesUnion UnShuffle(long key)
			{
				//IL_0010: Unknown result type (might be due to invalid IL or missing references)
				//IL_0015: Expected O, but got Unknown
				//IL_001f: Expected F8, but got O
				((ACTkByte8)this).UnShuffle();
				DoubleLongBytesUnion doubleLongBytesUnion = (DoubleLongBytesUnion)(d ^ key);
				d = (double)doubleLongBytesUnion;
				return doubleLongBytesUnion;
			}
		}

		[SerializeField]
		[Token(Token = "0x4000066")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		internal long currentCryptoKey;

		[SerializeField]
		[Token(Token = "0x4000067")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		internal long hiddenValue;

		[FormerlySerializedAs("hiddenValue")]
		[SerializeField]
		[Token(Token = "0x4000068")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		internal ACTkByte8 hiddenValueOldByte8;

		[SerializeField]
		[Token(Token = "0x4000069")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
		private bool inited;

		[SerializeField]
		[Token(Token = "0x400006A")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
		internal double fakeValue;

		[SerializeField]
		[Token(Token = "0x400006B")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
		private bool fakeValueActive;

		[Token(Token = "0x6000119")]
		[Address(RVA = "0xBDD548", Offset = "0xBDD548", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tthis.currentCryptoKey = v10;\n\tv13 = v10 ^ v31;\n\tCodeStage.AntiCheat.Common.ACTkByte8::Shuffle(&v13 @ X8_v2 (System.Int32));\n\tthis.hiddenValue = v13;\n\tthis.hiddenValueOldByte8 = 0;\n\tv19 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv22 = v19 == 0;\n\tv27 = ~v22;\n\tv28 = ~v27;\n\tif (v28) goto L_0022;\n\tgoto L_0022;\nL_0022:\n\tthis.fakeValueActive = v19;\n\tthis.fakeValue = 0d;\n\tthis.inited = 1;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe ObscuredDouble(double value)
		{
			//IL_0013: Expected I8, but got I4
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Expected I4, but got Unknown
			//IL_0038: Expected I8, but got I4
			int num = RandomUtils.GenerateIntKey();
			currentCryptoKey = num;
			double num3 = default(double);
			int num2 = num ^ num3;
			((ACTkByte8*)(&num2))->Shuffle();
			hiddenValue = num2;
			hiddenValueOldByte8 = default(ACTkByte8);
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			if (existsAndIsRunning)
			{
			}
			fakeValueActive = existsAndIsRunning;
			fakeValue = 0.0;
			inited = true;
		}

		[Token(Token = "0x600011A")]
		[Address(RVA = "0xBDD5C8", Offset = "0xBDD5C8", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = value ^ key;\n\tCodeStage.AntiCheat.Common.ACTkByte8::Shuffle(&v4 @ X8_v2 (System.Int64));\n\treturn v4;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static long Encrypt(double value, long key)
		{
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected I8, but got Unknown
			long result = value ^ key;
			((ACTkByte8*)(&result))->Shuffle();
			return result;
		}

		[Token(Token = "0x600011B")]
		[Address(RVA = "0xBDD618", Offset = "0xBDD618", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tCodeStage.AntiCheat.Common.ACTkByte8::UnShuffle(&v9 @ stack_-18_v2 (CodeStage.AntiCheat.Common.ACTkByte8));\n\tv12 = v9 ^ key;\n\treturn v12;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static double Decrypt(long value, long key)
		{
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected I8, but got Unknown
			ACTkByte8 aCTkByte = default(ACTkByte8);
			aCTkByte.UnShuffle();
			long num = aCTkByte ^ key;
			return num;
		}

		[Token(Token = "0x600011C")]
		[Address(RVA = "0xBDD680", Offset = "0xBDD680", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = fromVersion & 0xFF;\n\tv4 = v2 < 1;\n\tv5 = ~v4;\n\tv6 = v2 - 1;\n\tv8 = v6 == 0;\n\tv15 = ~v8;\n\tv16 = v5 & v15;\n\tif (v16) goto L_0022;\n\tv17 = toVersion & 0xFF;\n\tv28 = v17 != 2;\n\tif (v28) goto L_0022;\n\tCodeStage.AntiCheat.Common.ACTkByte8::Shuffle(&v35 @ stack_-8_v3 (CodeStage.AntiCheat.Common.ACTkByte8));\nL_0022:\n\treturn v35;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static long MigrateEncrypted(long encrypted, byte fromVersion = 0, byte toVersion = 2)
		{
			//IL_00ac: Expected I8, but got O
			int num = fromVersion & 0xFF;
			bool flag = num < 1;
			bool flag2 = !flag;
			int num2 = num - 1;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			ACTkByte8 aCTkByte = default(ACTkByte8);
			if (!(flag2 && flag4))
			{
				int num3 = toVersion & 0xFF;
				if (num3 == 2)
				{
					aCTkByte.Shuffle();
				}
			}
			return (long)aCTkByte;
		}

		[Token(Token = "0x600011D")]
		[Address(RVA = "0xBDD6F0", Offset = "0xBDD6F0", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0;\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredDouble::SetEncrypted(&v10 @ stack_-40_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredDouble), encrypted, key);\n\treturnBuffer.hiddenValueOldByte8 = 0;\n\treturnBuffer.fakeValue = 0d;\n\treturnBuffer.currentCryptoKey = 0;\n\treturn &v10 @ stack_-40_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredDouble);\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredDouble FromEncrypted(long encrypted, long key)
		{
			//IL_002d: Expected native int or pointer, but got O
			//IL_003f: Expected native int or pointer, but got O
			//IL_0051: Expected native int or pointer, but got O
			//IL_0063: Expected native int or pointer, but got O
			//IL_006d: Expected O, but got Ref
			ObscuredDouble obscuredDouble = default(ObscuredDouble);
			obscuredDouble.SetEncrypted(encrypted, key);
			ObscuredDouble obscuredDouble2 = default(ObscuredDouble);
			((ObscuredDouble*)(nint)obscuredDouble2)->hiddenValueOldByte8 = default(ACTkByte8);
			((ObscuredDouble*)(nint)obscuredDouble2)->fakeValue = 0.0;
			((ObscuredDouble*)(nint)obscuredDouble2)->currentCryptoKey = 0L;
			((ObscuredDouble*)(nint)obscuredDouble2)->hiddenValue = 0L;
			return (ObscuredDouble)(&obscuredDouble);
		}

		[Token(Token = "0x600011E")]
		[Address(RVA = "0xBDD5B4", Offset = "0xBDD5B4", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\treturn v2;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static long GenerateKey()
		{
			//IL_000e: Expected I8, but got I4
			int num = RandomUtils.GenerateIntKey();
			return num;
		}

		[Token(Token = "0x600011F")]
		[Address(RVA = "0xBDD778", Offset = "0xBDD778", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([key @ X1 (System.Int64&)]) = this.currentCryptoKey;\n\treturn this.hiddenValue;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe long GetEncrypted(out long key)
		{
			key = default(long);
			ref long reference = ref *(long*)currentCryptoKey;
			return hiddenValue;
		}

		[Token(Token = "0x6000120")]
		[Address(RVA = "0xBDD734", Offset = "0xBDD734", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.inited = 1;\n\tthis.currentCryptoKey = key;\n\tthis.hiddenValue = encrypted;\n\tv12 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tthis.fakeValueActive = 0;\n\tv14 = v12 == 0;\n\tif (v14) goto L_0017;\n\tv16 = CodeStage.AntiCheat.ObscuredTypes.ObscuredDouble::InternalDecrypt(this);\n\tthis.fakeValue = v16;\n\tthis.fakeValueActive = 1;\nL_0017:\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetEncrypted(long encrypted, long key)
		{
			inited = true;
			currentCryptoKey = key;
			hiddenValue = encrypted;
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			fakeValueActive = false;
			if (existsAndIsRunning)
			{
				double num = InternalDecrypt();
				fakeValue = num;
				fakeValueActive = true;
			}
		}

		[Token(Token = "0x6000121")]
		[Address(RVA = "0xBDD8FC", Offset = "0xBDD8FC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredDouble::InternalDecrypt(this);\n\treturn returnVal1;\n")]
		public double GetDecrypted()
		{
			return InternalDecrypt();
		}

		[Token(Token = "0x6000122")]
		[Address(RVA = "0xBDD900", Offset = "0xBDD900", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = CodeStage.AntiCheat.ObscuredTypes.ObscuredDouble::InternalDecrypt(this);\n\tv11 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tthis.currentCryptoKey = v11;\n\tv14 = v11 ^ v8;\n\tCodeStage.AntiCheat.Common.ACTkByte8::Shuffle(&v14 @ X8_v2 (System.Int32));\n\tthis.hiddenValue = v14;\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void RandomizeCryptoKey()
		{
			//IL_0022: Expected I8, but got I4
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Expected I4, but got Unknown
			//IL_0042: Expected I8, but got I4
			double num = InternalDecrypt();
			int num2 = RandomUtils.GenerateIntKey();
			currentCryptoKey = num2;
			int num3 = num2 ^ num;
			((ACTkByte8*)(&num3))->Shuffle();
			hiddenValue = num3;
		}

		[Token(Token = "0x6000123")]
		[Address(RVA = "0xBDD788", Offset = "0xBDD788", Length = "0x174")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv42 = System.Math;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A3546D]) = v38;\nL_0015:\n\t;\n\tv40 = ~this.inited;\n\tif (v40) goto L_0070;\n\tv44 = this.hiddenValue;\n\tCodeStage.AntiCheat.Common.ACTkByte8::UnShuffle(&v44 @ X8_v7 (CodeStage.AntiCheat.Common.ACTkByte8));\n\tv51 = v44 ^ this.currentCryptoKey;\n\tv53 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv59 = v53 == 0;\n\tif (v59) goto L_0085;\n\tv64 = ~this.fakeValueActive;\n\tif (v64) goto L_0085;\n\tgoto L_003A;\n\tv161 = \"il2cpp_codegen_runtime_class_init\"(v123, v47, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_003A:\n\tgoto L_0042;\n\tv170 = 0xB348B0(v165, v47, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0042:\n\tgoto L_0045;\n\tv178 = 0xB348B0(v173, v47, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0045:\n\tv112 = v179.<Instance>k__BackingField;\n\t// 73 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv70 = v28 <= v112.doubleEpsilon;\n\tif (v70) goto L_0085;\n\tgoto L_0065;\n\tv192 = 0xB348B0(v187, v47, v21, v22, v23, v24, v25, v26, v96, v28, v29, v30, v31, v32, v33, v34);\nL_0065:\n\tgoto L_006E;\n\tv200 = 0xB348B0(v195, v47, v21, v22, v23, v24, v25, v26, v96, v28, v29, v30, v31, v32, v33, v34);\nL_006E:\n\tthis = CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector>::OnCheatingDetected(v185.<Instance>k__BackingField);\n\tgoto L_0085;\nL_0070:\n\tv48 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tthis.currentCryptoKey = v48;\n\tCodeStage.AntiCheat.Common.ACTkByte8::Shuffle(&v48 @ X0_v3 (System.Int32));\n\tthis.fakeValue = 0d;\n\tthis.fakeValueActive = 0;\n\tthis.inited = 1;\n\tthis.hiddenValue = v48;\nL_0085:\n\treturn v99;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 92 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe double InternalDecrypt()
		{
			//IL_0106: Expected I8, but got I4
			//IL_0143: Expected I8, but got I4
			//IL_000f: Expected O, but got I8
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected I4, but got Unknown
			int num2;
			if (inited)
			{
				ACTkByte8 aCTkByte = (ACTkByte8)hiddenValue;
				aCTkByte.UnShuffle();
				int num = (int)(aCTkByte ^ currentCryptoKey);
				bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
				bool flag = !existsAndIsRunning;
				num2 = num;
				if (!flag)
				{
					bool flag2 = !fakeValueActive;
					num2 = num;
					if (!flag2)
					{
						ObscuredCheatingDetector _003CInstance_003Ek__BackingField = KeepAliveBehaviour<ObscuredCheatingDetector>.Instance;
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
						object obj = default(object);
						bool flag3 = !((double)obj > _003CInstance_003Ek__BackingField.doubleEpsilon);
						num2 = num;
						if (!flag3)
						{
							KeepAliveBehaviour<ObscuredCheatingDetector>.Instance.OnCheatingDetected();
							num2 = num;
						}
					}
				}
			}
			else
			{
				int num3 = RandomUtils.GenerateIntKey();
				currentCryptoKey = num3;
				((ACTkByte8*)(&num3))->Shuffle();
				fakeValue = 0.0;
				fakeValueActive = false;
				inited = true;
				hiddenValue = num3;
				num2 = 0;
			}
			return num2;
		}

		[Token(Token = "0x6000124")]
		[Address(RVA = "0xBDD94C", Offset = "0xBDD94C", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnBuffer.hiddenValueOldByte8 = 0;\n\treturnBuffer.fakeValue = 0d;\n\treturnBuffer.currentCryptoKey = 0;\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredDouble::.ctor(returnBuffer, value);\n\treturn returnBuffer;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static implicit operator ObscuredDouble(double value)
		{
			//IL_0012: Expected native int or pointer, but got O
			//IL_0024: Expected native int or pointer, but got O
			//IL_0036: Expected native int or pointer, but got O
			//IL_0048: Expected native int or pointer, but got O
			//IL_0055: Expected native int or pointer, but got O
			ObscuredDouble obscuredDouble = default(ObscuredDouble);
			((ObscuredDouble*)(nint)obscuredDouble)->hiddenValueOldByte8 = default(ACTkByte8);
			((ObscuredDouble*)(nint)obscuredDouble)->fakeValue = 0.0;
			((ObscuredDouble*)(nint)obscuredDouble)->currentCryptoKey = 0L;
			((ObscuredDouble*)(nint)obscuredDouble)->hiddenValue = 0L;
			*(ObscuredDouble*)(nint)obscuredDouble = new ObscuredDouble(value);
			return obscuredDouble;
		}

		[Token(Token = "0x6000125")]
		[Address(RVA = "0xBDD960", Offset = "0xBDD960", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredDouble::InternalDecrypt(value);\n\treturn returnVal1;\n")]
		public unsafe static implicit operator double(ObscuredDouble value)
		{
			return ((ObscuredDouble*)value)->InternalDecrypt();
		}

		[Token(Token = "0x6000126")]
		[Address(RVA = "0xBDD964", Offset = "0xBDD964", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = f.currentCryptoKey;\n\tv12 = CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat::InternalDecrypt(&v8 @ V0_v1 (System.Int32));\n\tv17 = 0;\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredDouble::.ctor(&v17 @ stack_-60_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredDouble), v12);\n\treturnBuffer.hiddenValueOldByte8 = 0;\n\treturnBuffer.fakeValue = 0d;\n\treturnBuffer.currentCryptoKey = 0;\n\treturn &v17 @ stack_-60_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredDouble);\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static explicit operator ObscuredDouble(ObscuredFloat f)
		{
			//IL_0048: Expected native int or pointer, but got O
			//IL_005a: Expected native int or pointer, but got O
			//IL_006c: Expected native int or pointer, but got O
			//IL_007e: Expected native int or pointer, but got O
			//IL_0088: Expected O, but got Ref
			int num = f.currentCryptoKey;
			float num2 = ((ObscuredFloat*)(&num))->InternalDecrypt();
			ObscuredDouble obscuredDouble = default(ObscuredDouble);
			obscuredDouble = new ObscuredDouble(num2);
			ObscuredDouble obscuredDouble2 = default(ObscuredDouble);
			((ObscuredDouble*)(nint)obscuredDouble2)->hiddenValueOldByte8 = default(ACTkByte8);
			((ObscuredDouble*)(nint)obscuredDouble2)->fakeValue = 0.0;
			((ObscuredDouble*)(nint)obscuredDouble2)->currentCryptoKey = 0L;
			((ObscuredDouble*)(nint)obscuredDouble2)->hiddenValue = 0L;
			return (ObscuredDouble)(&obscuredDouble);
		}

		[Token(Token = "0x6000127")]
		[Address(RVA = "0xBDD9BC", Offset = "0xBDD9BC", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = input.currentCryptoKey;\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredDouble::Increment(&v7 @ V2_v1 (System.Int64), 1d);\n\treturnBuffer.hiddenValueOldByte8 = returnVal1.hiddenValueOldByte8;\n\treturnBuffer.fakeValue = returnVal1.fakeValue;\n\treturnBuffer.currentCryptoKey = returnVal1.currentCryptoKey;\n\treturn returnVal1;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredDouble operator ++(ObscuredDouble input)
		{
			//IL_001f: Expected O, but got Ref
			//IL_0030: Expected native int or pointer, but got O
			//IL_0042: Expected native int or pointer, but got O
			//IL_0054: Expected native int or pointer, but got O
			//IL_006c: Expected native int or pointer, but got O
			long num = input.currentCryptoKey;
			ObscuredDouble result = Increment((ObscuredDouble)(&num), 1.0);
			ObscuredDouble obscuredDouble = default(ObscuredDouble);
			((ObscuredDouble*)(nint)obscuredDouble)->hiddenValueOldByte8 = result.hiddenValueOldByte8;
			((ObscuredDouble*)(nint)obscuredDouble)->fakeValue = result.fakeValue;
			((ObscuredDouble*)(nint)obscuredDouble)->currentCryptoKey = result.currentCryptoKey;
			((ObscuredDouble*)(nint)obscuredDouble)->hiddenValue = (long)((ulong)result.currentCryptoKey >> 64);
			return result;
		}

		[Token(Token = "0x6000128")]
		[Address(RVA = "0xBDDA90", Offset = "0xBDDA90", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = input.currentCryptoKey;\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredDouble::Increment(&v7 @ V2_v1 (System.Int64), -1d);\n\treturnBuffer.hiddenValueOldByte8 = returnVal1.hiddenValueOldByte8;\n\treturnBuffer.fakeValue = returnVal1.fakeValue;\n\treturnBuffer.currentCryptoKey = returnVal1.currentCryptoKey;\n\treturn returnVal1;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredDouble operator --(ObscuredDouble input)
		{
			//IL_001f: Expected O, but got Ref
			//IL_0030: Expected native int or pointer, but got O
			//IL_0042: Expected native int or pointer, but got O
			//IL_0054: Expected native int or pointer, but got O
			//IL_006c: Expected native int or pointer, but got O
			long num = input.currentCryptoKey;
			ObscuredDouble result = Increment((ObscuredDouble)(&num), -1.0);
			ObscuredDouble obscuredDouble = default(ObscuredDouble);
			((ObscuredDouble*)(nint)obscuredDouble)->hiddenValueOldByte8 = result.hiddenValueOldByte8;
			((ObscuredDouble*)(nint)obscuredDouble)->fakeValue = result.fakeValue;
			((ObscuredDouble*)(nint)obscuredDouble)->currentCryptoKey = result.currentCryptoKey;
			((ObscuredDouble*)(nint)obscuredDouble)->hiddenValue = (long)((ulong)result.currentCryptoKey >> 64);
			return result;
		}

		[Token(Token = "0x6000129")]
		[Address(RVA = "0xBDDA04", Offset = "0xBDDA04", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = CodeStage.AntiCheat.ObscuredTypes.ObscuredDouble::InternalDecrypt(input);\n\tv17 = v14 + increment;\n\tv21 = input.currentCryptoKey ^ v17;\n\tCodeStage.AntiCheat.Common.ACTkByte8::Shuffle(&v21 @ X8_v2 (CodeStage.AntiCheat.Common.ACTkByte8));\n\tinput.hiddenValue = v21;\n\treturnVal1 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv26 = returnVal1 & 1;\n\tv27 = v26 == 0;\n\tif (v27) goto L_FFFFFFFF;\n\tinput.fakeValue = v17;\n\tgoto L_001C;\nL_001C:\n\tinput.fakeValueActive = v30;\n\treturnBuffer.hiddenValueOldByte8 = input.hiddenValueOldByte8;\n\treturnBuffer.fakeValue = input.fakeValue;\n\treturnBuffer.currentCryptoKey = input.currentCryptoKey;\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe static ObscuredDouble Increment(ObscuredDouble input, double increment)
		{
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Expected O, but got Unknown
			//IL_0049: Expected I8, but got O
			//IL_0044: Expected native int or pointer, but got O
			//IL_0052: Expected O, but got I4
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Expected I4, but got Unknown
			//IL_00ae: Expected native int or pointer, but got O
			//IL_00c0: Expected native int or pointer, but got O
			//IL_00d2: Expected native int or pointer, but got O
			//IL_00e4: Expected native int or pointer, but got O
			//IL_00fc: Expected native int or pointer, but got O
			//IL_0085: Expected native int or pointer, but got O
			double num = ((ObscuredDouble*)input)->InternalDecrypt();
			double num2 = num + increment;
			ACTkByte8 aCTkByte = (ACTkByte8)(input.currentCryptoKey ^ num2);
			aCTkByte.Shuffle();
			((ObscuredDouble*)(nint)input)->hiddenValue = (long)aCTkByte;
			ObscuredDouble obscuredDouble = (ObscuredDouble)ObscuredCheatingDetector.ExistsAndIsRunning;
			bool flag;
			if ((obscuredDouble & 1) != 0)
			{
				((ObscuredDouble*)(nint)input)->fakeValue = num2;
				flag = true;
			}
			else
			{
				flag = false;
			}
			((ObscuredDouble*)(nint)input)->fakeValueActive = flag;
			ObscuredDouble obscuredDouble2 = default(ObscuredDouble);
			((ObscuredDouble*)(nint)obscuredDouble2)->hiddenValueOldByte8 = input.hiddenValueOldByte8;
			((ObscuredDouble*)(nint)obscuredDouble2)->fakeValue = input.fakeValue;
			((ObscuredDouble*)(nint)obscuredDouble2)->currentCryptoKey = input.currentCryptoKey;
			((ObscuredDouble*)(nint)obscuredDouble2)->hiddenValue = (long)((ulong)input.currentCryptoKey >> 64);
			return obscuredDouble;
		}

		[Token(Token = "0x600012A")]
		[Address(RVA = "0xBDDAD8", Offset = "0xBDDAD8", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = CodeStage.AntiCheat.ObscuredTypes.ObscuredDouble::InternalDecrypt(this);\n\tv6 = 0 - v2;\n\tv7 = v2 & 0x7FF0000000000000;\n\tv8 = v6 & 0x7FF0000000000000;\n\tv10 = v8 == 0;\n\tv13 = ~v10;\n\tif (v13) goto L_FFFFFFFF;\n\tgoto L_0011;\nL_0011:\n\tv17 = v16 >> 0x20;\n\treturnVal1 = v17 ^ v16;\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override int GetHashCode()
		{
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected F8, but got Unknown
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Expected O, but got Unknown
			//IL_0092: Expected O, but got F8
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Expected I4, but got Unknown
			double num = InternalDecrypt();
			double num2 = 0.0 - num;
			double num3 = num & 0x7FF0000000000000L;
			object obj = num2 & 0x7FF0000000000000L;
			double num4 = ((obj != null) ? num : num3);
			object obj2 = num4 >> 32;
			return (nint)obj2 ^ num4;
		}

		[Token(Token = "0x600012B")]
		[Address(RVA = "0xBDDB04", Offset = "0xBDDB04", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = CodeStage.AntiCheat.ObscuredTypes.ObscuredDouble::InternalDecrypt(this);\n\treturnVal1 = System.Double::ToString(&v2 @ V0_v1 (System.Double));\n\treturn returnVal1;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			return InternalDecrypt().ToString();
		}

		[Token(Token = "0x600012C")]
		[Address(RVA = "0xBDDB24", Offset = "0xBDDB24", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredDouble::InternalDecrypt(this);\n\treturnVal1 = System.Double::ToString(&v6 @ V0_v1 (System.Double), format);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string ToString(string format)
		{
			return InternalDecrypt().ToString(format);
		}

		[Token(Token = "0x600012D")]
		[Address(RVA = "0xBDDB54", Offset = "0xBDDB54", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredDouble::InternalDecrypt(this);\n\treturnVal1 = System.Double::ToString(&v6 @ V0_v1 (System.Double), provider);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string ToString(IFormatProvider provider)
		{
			return InternalDecrypt().ToString(provider);
		}

		[Token(Token = "0x600012E")]
		[Address(RVA = "0xBDDB84", Offset = "0xBDDB84", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = CodeStage.AntiCheat.ObscuredTypes.ObscuredDouble::InternalDecrypt(this);\n\treturnVal1 = System.Double::ToString(&v10 @ V0_v1 (System.Double), format, provider);\n\treturn returnVal1;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string ToString(string format, IFormatProvider provider)
		{
			return InternalDecrypt().ToString(format, provider);
		}

		[Token(Token = "0x600012F")]
		[Address(RVA = "0xBDDBBC", Offset = "0xBDDBBC", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredDouble;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, obj, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A3546E]) = v36;\nL_0012:\n\tv37 = obj == 0;\n\tif (v37) goto L_FFFFFFFF;\n\tv46 = *([obj @ X1 (System.Object)]) == CodeStage.AntiCheat.ObscuredTypes.ObscuredDouble;\n\tif (v46) goto L_0025;\n\tgoto L_0035;\nL_0025:\n\tv72 = \"il2cpp_vm_object_unbox\"(obj, obj, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv26 = *([v72 @ X0_v6]);\n\tv99 = CodeStage.AntiCheat.ObscuredTypes.ObscuredDouble::Equals(this, &v26 @ V0);\nL_0035:\n\treturn v99;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override bool Equals(object obj)
		{
			//IL_0056: Expected O, but got Ref
			if (obj == null || (object)obj.GetType() != typeof(ObscuredDouble))
			{
				return false;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
			object obj3 = default(object);
			object obj2 = obj3;
			return Equals((ObscuredDouble)(&obj2));
		}

		[Token(Token = "0x6000130")]
		[Address(RVA = "0xBDDC4C", Offset = "0xBDDC4C", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = CodeStage.AntiCheat.ObscuredTypes.ObscuredDouble::InternalDecrypt(obj);\n\tv8 = CodeStage.AntiCheat.ObscuredTypes.ObscuredDouble::InternalDecrypt(this);\n\tv14 = System.Double::Equals(&v8 @ V0_v1 (System.Double), v8);\n\treturn v14;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe bool Equals(ObscuredDouble obj)
		{
			double num = ((ObscuredDouble*)obj)->InternalDecrypt();
			num = InternalDecrypt();
			return num.Equals(num);
		}

		[Token(Token = "0x6000131")]
		[Address(RVA = "0xBDDC88", Offset = "0xBDDC88", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredDouble::InternalDecrypt(this);\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredDouble::InternalDecrypt(other);\n\treturnVal1 = System.Double::CompareTo(&v6 @ V0_v1 (System.Double), v6);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe int CompareTo(ObscuredDouble other)
		{
			double num = InternalDecrypt();
			num = ((ObscuredDouble*)other)->InternalDecrypt();
			return num.CompareTo(num);
		}

		[Token(Token = "0x6000132")]
		[Address(RVA = "0xBDDCBC", Offset = "0xBDDCBC", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredDouble::InternalDecrypt(this);\n\treturnVal1 = System.Double::CompareTo(&v6 @ V0_v1 (System.Double), v6);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int CompareTo(double other)
		{
			double value = InternalDecrypt();
			return value.CompareTo(value);
		}

		[Token(Token = "0x6000133")]
		[Address(RVA = "0xBDDCF4", Offset = "0xBDDCF4", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredDouble::InternalDecrypt(this);\n\treturnVal1 = System.Double::CompareTo(&v6 @ V0_v1 (System.Double), obj);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int CompareTo(object obj)
		{
			return InternalDecrypt().CompareTo(obj);
		}

		[Obsolete("This API is redundant and does not perform any actions. It will be removed in future updates.")]
		[Token(Token = "0x6000134")]
		[Address(RVA = "0xBDDD24", Offset = "0xBDDD24", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public static void SetNewCryptoKey(long newKey)
		{
		}

		[Obsolete("This API is redundant and does not perform any actions. It will be removed in future updates.")]
		[Token(Token = "0x6000135")]
		[Address(RVA = "0xBDDD28", Offset = "0xBDDD28", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void ApplyNewCryptoKey()
		{
		}

		[Obsolete("Please use new Encrypt(value, key) API instead.", true)]
		[Token(Token = "0x6000136")]
		[Address(RVA = "0xBDDD2C", Offset = "0xBDDD2C", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static long Encrypt(double value)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new Decrypt(value, key) API instead.", true)]
		[Token(Token = "0x6000137")]
		[Address(RVA = "0xBDDD64", Offset = "0xBDDD64", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static double Decrypt(long value)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new FromEncrypted(encrypted, key) API instead.", true)]
		[Token(Token = "0x6000138")]
		[Address(RVA = "0xBDDD9C", Offset = "0xBDDD9C", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ObscuredDouble FromEncrypted(long encrypted)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new GetEncrypted(out key) API instead.", true)]
		[Token(Token = "0x6000139")]
		[Address(RVA = "0xBDDDD4", Offset = "0xBDDDD4", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public long GetEncrypted()
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new SetEncrypted(encrypted, key) API instead.", true)]
		[Token(Token = "0x600013A")]
		[Address(RVA = "0xBDDE0C", Offset = "0xBDDE0C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetEncrypted(long encrypted)
		{
		}
	}
}
