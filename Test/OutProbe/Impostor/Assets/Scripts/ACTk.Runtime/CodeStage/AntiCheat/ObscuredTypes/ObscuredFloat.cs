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
	[Token(Token = "0x2000016")]
	public struct ObscuredFloat : IObscuredType, IFormattable, IEquatable<ObscuredFloat>, IComparable<ObscuredFloat>, IComparable<float>, IComparable
	{
		[StructLayout((LayoutKind)2)]
		[Token(Token = "0x2000017")]
		internal struct FloatIntBytesUnion
		{
			[System.Runtime.InteropServices.FieldOffset(0)]
			[Token(Token = "0x4000075")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			internal float f;

			[System.Runtime.InteropServices.FieldOffset(0)]
			[Token(Token = "0x4000076")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			internal int i;

			[System.Runtime.InteropServices.FieldOffset(0)]
			[Token(Token = "0x4000077")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			internal ACTkByte4 b4;

			[Token(Token = "0x6000163")]
			[Address(RVA = "0xBDDFD0", Offset = "0xBDDFD0", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = fromVersion & 0xFF;\n\tv4 = v2 < 1;\n\tv5 = ~v4;\n\tv6 = v2 - 1;\n\tv8 = v6 == 0;\n\tv15 = ~v8;\n\tv16 = v5 & v15;\n\tif (v16) goto L_0022;\n\tv17 = toVersion & 0xFF;\n\tv28 = v17 != 2;\n\tif (v28) goto L_0022;\n\tCodeStage.AntiCheat.Common.ACTkByte4::Shuffle(&v35 @ stack_-8_v3 (CodeStage.AntiCheat.Common.ACTkByte4));\nL_0022:\n\treturn v35;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public static int Migrate(int value, byte fromVersion, byte toVersion)
			{
				//IL_00ac: Expected I4, but got O
				int num = fromVersion & 0xFF;
				bool flag = num < 1;
				bool flag2 = !flag;
				int num2 = num - 1;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				ACTkByte4 aCTkByte = default(ACTkByte4);
				if (!(flag2 && flag4))
				{
					int num3 = toVersion & 0xFF;
					if (num3 == 2)
					{
						aCTkByte.Shuffle();
					}
				}
				return (int)aCTkByte;
			}

			[Token(Token = "0x6000164")]
			[Address(RVA = "0xBDDF08", Offset = "0xBDDF08", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = value ^ key;\n\tCodeStage.AntiCheat.Common.ACTkByte4::Shuffle(&v4 @ X8_v2 (System.Int32));\n\treturn v4;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			internal unsafe static int XorFloatToInt(float value, int key)
			{
				//IL_0008: Unknown result type (might be due to invalid IL or missing references)
				//IL_000d: Expected I4, but got Unknown
				int result = value ^ key;
				((ACTkByte4*)(&result))->Shuffle();
				return result;
			}

			[Token(Token = "0x6000165")]
			[Address(RVA = "0xBDDF64", Offset = "0xBDDF64", Length = "0x34")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tCodeStage.AntiCheat.Common.ACTkByte4::UnShuffle(&v9 @ stack_-18_v2 (CodeStage.AntiCheat.Common.ACTkByte4));\n\tv12 = v9 ^ key;\n\treturn v12;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			internal static float XorIntToFloat(int value, int key)
			{
				//IL_0011: Unknown result type (might be due to invalid IL or missing references)
				//IL_0016: Expected I4, but got Unknown
				ACTkByte4 aCTkByte = default(ACTkByte4);
				aCTkByte.UnShuffle();
				int num = aCTkByte ^ key;
				return num;
			}

			[Token(Token = "0x6000166")]
			[Address(RVA = "0xBDE6BC", Offset = "0xBDE6BC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn value;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private static FloatIntBytesUnion FromFloat(float value)
			{
				//IL_0005: Expected O, but got F4
				return (FloatIntBytesUnion)value;
			}

			[Token(Token = "0x6000167")]
			[Address(RVA = "0xBDE6B4", Offset = "0xBDE6B4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn value;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private static FloatIntBytesUnion FromInt(int value)
			{
				//IL_0005: Expected O, but got I4
				return (FloatIntBytesUnion)value;
			}

			[Token(Token = "0x6000168")]
			[Address(RVA = "0xBDE6C4", Offset = "0xBDE6C4", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = this.f ^ key;\n\tthis.f = v7;\n\tCodeStage.AntiCheat.Common.ACTkByte4::Shuffle(this);\n\treturn this.f;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private FloatIntBytesUnion Shuffle(int key)
			{
				//IL_000a: Unknown result type (might be due to invalid IL or missing references)
				//IL_000f: Expected I4, but got Unknown
				//IL_0027: Expected O, but got F4
				int num = f ^ key;
				f = num;
				((ACTkByte4)this).Shuffle();
				return (FloatIntBytesUnion)f;
			}

			[Token(Token = "0x6000169")]
			[Address(RVA = "0xBDE6EC", Offset = "0xBDE6EC", Length = "0x30")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tCodeStage.AntiCheat.Common.ACTkByte4::UnShuffle(this);\n\treturnVal1 = this.f ^ key;\n\tthis.f = returnVal1;\n\treturn returnVal1;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private FloatIntBytesUnion UnShuffle(int key)
			{
				//IL_0010: Unknown result type (might be due to invalid IL or missing references)
				//IL_0015: Expected O, but got Unknown
				//IL_001f: Expected F4, but got O
				((ACTkByte4)this).UnShuffle();
				FloatIntBytesUnion floatIntBytesUnion = (FloatIntBytesUnion)(f ^ key);
				f = (float)floatIntBytesUnion;
				return floatIntBytesUnion;
			}
		}

		[SerializeField]
		[Token(Token = "0x400006F")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		internal int currentCryptoKey;

		[SerializeField]
		[Token(Token = "0x4000070")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
		private int hiddenValue;

		[SerializeField]
		[FormerlySerializedAs("hiddenValue")]
		[Token(Token = "0x4000071")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		private ACTkByte4 hiddenValueOldByte4;

		[SerializeField]
		[Token(Token = "0x4000072")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xC")]
		private bool inited;

		[SerializeField]
		[Token(Token = "0x4000073")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		internal float fakeValue;

		[SerializeField]
		[Token(Token = "0x4000074")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x14")]
		private bool fakeValueActive;

		[Token(Token = "0x6000142")]
		[Address(RVA = "0xBDDE74", Offset = "0xBDDE74", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tthis.currentCryptoKey = v10;\n\tv12 = v10 ^ v30;\n\tCodeStage.AntiCheat.Common.ACTkByte4::Shuffle(&v12 @ X8_v2 (System.Int32));\n\tthis.hiddenValue = v12;\n\tthis.hiddenValueOldByte4 = 0;\n\tv18 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv21 = v18 == 0;\n\tv26 = ~v21;\n\tv27 = ~v26;\n\tif (v27) goto L_0021;\n\tgoto L_0021;\nL_0021:\n\tthis.fakeValueActive = v18;\n\tthis.fakeValue = 0f;\n\tthis.inited = 1;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe ObscuredFloat(float value)
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Expected I4, but got Unknown
			float num2 = default(float);
			int num = (currentCryptoKey = RandomUtils.GenerateIntKey()) ^ num2;
			((ACTkByte4*)(&num))->Shuffle();
			hiddenValue = num;
			hiddenValueOldByte4 = default(ACTkByte4);
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			if (existsAndIsRunning)
			{
			}
			fakeValueActive = existsAndIsRunning;
			fakeValue = 0f;
			inited = true;
		}

		[Token(Token = "0x6000143")]
		[Address(RVA = "0xBDDEE0", Offset = "0xBDDEE0", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = value ^ key;\n\tCodeStage.AntiCheat.Common.ACTkByte4::Shuffle(&v4 @ X8_v2 (System.Int32));\n\treturn v4;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static int Encrypt(float value, int key)
		{
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected I4, but got Unknown
			int result = value ^ key;
			((ACTkByte4*)(&result))->Shuffle();
			return result;
		}

		[Token(Token = "0x6000144")]
		[Address(RVA = "0xBDDF30", Offset = "0xBDDF30", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tCodeStage.AntiCheat.Common.ACTkByte4::UnShuffle(&v9 @ stack_-18_v2 (CodeStage.AntiCheat.Common.ACTkByte4));\n\tv12 = v9 ^ key;\n\treturn v12;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float Decrypt(int value, int key)
		{
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected I4, but got Unknown
			ACTkByte4 aCTkByte = default(ACTkByte4);
			aCTkByte.UnShuffle();
			int num = aCTkByte ^ key;
			return num;
		}

		[Token(Token = "0x6000145")]
		[Address(RVA = "0xBDDF98", Offset = "0xBDDF98", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = fromVersion & 0xFF;\n\tv4 = v2 < 1;\n\tv5 = ~v4;\n\tv6 = v2 - 1;\n\tv8 = v6 == 0;\n\tv15 = ~v8;\n\tv16 = v5 & v15;\n\tif (v16) goto L_0022;\n\tv17 = toVersion & 0xFF;\n\tv28 = v17 != 2;\n\tif (v28) goto L_0022;\n\tCodeStage.AntiCheat.Common.ACTkByte4::Shuffle(&v35 @ stack_-8_v3 (CodeStage.AntiCheat.Common.ACTkByte4));\nL_0022:\n\treturn v35;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int MigrateEncrypted(int encrypted, byte fromVersion = 0, byte toVersion = 2)
		{
			//IL_00ac: Expected I4, but got O
			int num = fromVersion & 0xFF;
			bool flag = num < 1;
			bool flag2 = !flag;
			int num2 = num - 1;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			ACTkByte4 aCTkByte = default(ACTkByte4);
			if (!(flag2 && flag4))
			{
				int num3 = toVersion & 0xFF;
				if (num3 == 2)
				{
					aCTkByte.Shuffle();
				}
			}
			return (int)aCTkByte;
		}

		[Token(Token = "0x6000146")]
		[Address(RVA = "0xBDE008", Offset = "0xBDE008", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = 0;\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredFloat::SetEncrypted(&v9 @ stack_-28_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat), encrypted, key);\n\treturnBuffer.fakeValue = 0f;\n\treturnBuffer.currentCryptoKey = 0;\n\treturn &v9 @ stack_-28_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat);\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredFloat FromEncrypted(int encrypted, int key)
		{
			//IL_0024: Expected native int or pointer, but got O
			//IL_0032: Expected native int or pointer, but got O
			//IL_003c: Expected O, but got Ref
			ObscuredFloat obscuredFloat = default(ObscuredFloat);
			obscuredFloat.SetEncrypted(encrypted, key);
			ObscuredFloat obscuredFloat2 = default(ObscuredFloat);
			((ObscuredFloat*)(nint)obscuredFloat2)->fakeValue = 0f;
			((ObscuredFloat*)(nint)obscuredFloat2)->currentCryptoKey = 0;
			return (ObscuredFloat)(&obscuredFloat);
		}

		[Token(Token = "0x6000147")]
		[Address(RVA = "0xBDDEDC", Offset = "0xBDDEDC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\treturn returnVal1;\n")]
		public static int GenerateKey()
		{
			return RandomUtils.GenerateIntKey();
		}

		[Token(Token = "0x6000148")]
		[Address(RVA = "0xBDE08C", Offset = "0xBDE08C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([key @ X1 (System.Int32&)]) = this.currentCryptoKey;\n\treturn this.hiddenValue;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe int GetEncrypted(out int key)
		{
			key = default(int);
			ref int reference = ref *(int*)currentCryptoKey;
			return hiddenValue;
		}

		[Token(Token = "0x6000149")]
		[Address(RVA = "0xBDE048", Offset = "0xBDE048", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.inited = 1;\n\tthis.currentCryptoKey = key;\n\tthis.hiddenValue = encrypted;\n\tv12 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tthis.fakeValueActive = 0;\n\tv14 = v12 == 0;\n\tif (v14) goto L_0017;\n\tv16 = CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat::InternalDecrypt(this);\n\tthis.fakeValue = v16;\n\tthis.fakeValueActive = 1;\nL_0017:\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetEncrypted(int encrypted, int key)
		{
			inited = true;
			currentCryptoKey = key;
			hiddenValue = encrypted;
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			fakeValueActive = false;
			if (existsAndIsRunning)
			{
				float num = InternalDecrypt();
				fakeValue = num;
				fakeValueActive = true;
			}
		}

		[Token(Token = "0x600014A")]
		[Address(RVA = "0xBDE214", Offset = "0xBDE214", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat::InternalDecrypt(this);\n\treturn returnVal1;\n")]
		public float GetDecrypted()
		{
			return InternalDecrypt();
		}

		[Token(Token = "0x600014B")]
		[Address(RVA = "0xBDE218", Offset = "0xBDE218", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat::InternalDecrypt(this);\n\tv11 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tthis.currentCryptoKey = v11;\n\tv13 = v11 ^ v8;\n\tCodeStage.AntiCheat.Common.ACTkByte4::Shuffle(&v13 @ X8_v2 (System.Int32));\n\tthis.hiddenValue = v13;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void RandomizeCryptoKey()
		{
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Expected I4, but got Unknown
			float num = InternalDecrypt();
			int num2 = (currentCryptoKey = RandomUtils.GenerateIntKey()) ^ num;
			((ACTkByte4*)(&num2))->Shuffle();
			hiddenValue = num2;
		}

		[Token(Token = "0x600014C")]
		[Address(RVA = "0xBDE09C", Offset = "0xBDE09C", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv42 = System.Math;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A3546F]) = v38;\nL_0015:\n\t;\n\tv40 = ~v35.inited;\n\tif (v40) goto L_0070;\n\tv44 = v35.hiddenValue;\n\tCodeStage.AntiCheat.Common.ACTkByte4::UnShuffle(&v44 @ X8_v6 (CodeStage.AntiCheat.Common.ACTkByte4));\n\tv51 = v44 ^ v35.currentCryptoKey;\n\tv53 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv59 = v53 == 0;\n\tif (v59) goto L_0084;\n\tv64 = ~v35.fakeValueActive;\n\tif (v64) goto L_0084;\n\tgoto L_003A;\n\tv165 = \"il2cpp_codegen_runtime_class_init\"(v126, v47, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_003A:\n\tgoto L_0042;\n\tv174 = 0xB348B0(v169, v47, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0042:\n\tgoto L_0045;\n\tv182 = 0xB348B0(v177, v47, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0045:\n\tv115 = v183.<Instance>k__BackingField;\n\t// 73 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv72 = v28 <= v115.floatEpsilon;\n\tif (v72) goto L_0084;\n\tgoto L_0065;\n\tv196 = 0xB348B0(v191, v47, v21, v22, v23, v24, v25, v26, v98, v28, v29, v30, v31, v32, v33, v34);\nL_0065:\n\tgoto L_006E;\n\tv204 = 0xB348B0(v199, v47, v21, v22, v23, v24, v25, v26, v98, v28, v29, v30, v31, v32, v33, v34);\nL_006E:\n\tv108 = CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector>::OnCheatingDetected(v189.<Instance>k__BackingField);\n\tgoto L_0084;\nL_0070:\n\tv48 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tv35.currentCryptoKey = v48;\n\tCodeStage.AntiCheat.Common.ACTkByte4::Shuffle(&v56 @ stack_-38_v3 (CodeStage.AntiCheat.Common.ACTkByte4));\n\tv35.fakeValue = 0f;\n\tv35.fakeValueActive = 0;\n\tv35.inited = 1;\n\tv35.hiddenValue = v56;\nL_0084:\n\treturn v101;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 91 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal float InternalDecrypt()
		{
			//IL_013f: Expected I4, but got O
			//IL_000f: Expected O, but got I4
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected I4, but got Unknown
			int num2;
			if (inited)
			{
				ACTkByte4 aCTkByte = (ACTkByte4)hiddenValue;
				aCTkByte.UnShuffle();
				int num = aCTkByte ^ currentCryptoKey;
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
						bool flag3 = !((float)obj > _003CInstance_003Ek__BackingField.floatEpsilon);
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
				ACTkByte4 aCTkByte2 = default(ACTkByte4);
				aCTkByte2.Shuffle();
				fakeValue = 0f;
				fakeValueActive = false;
				inited = true;
				hiddenValue = (int)aCTkByte2;
				num2 = 0;
			}
			return num2;
		}

		[Token(Token = "0x600014D")]
		[Address(RVA = "0xBDE260", Offset = "0xBDE260", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnBuffer.currentCryptoKey = 0;\n\treturnBuffer.hiddenValueOldByte4 = 0;\n\treturnBuffer.fakeValue = 0f;\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredFloat::.ctor(returnBuffer, value);\n\treturn returnBuffer;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static implicit operator ObscuredFloat(float value)
		{
			//IL_0009: Expected native int or pointer, but got O
			//IL_0020: Expected native int or pointer, but got O
			//IL_002e: Expected native int or pointer, but got O
			//IL_003b: Expected native int or pointer, but got O
			ObscuredFloat obscuredFloat = default(ObscuredFloat);
			((ObscuredFloat*)(nint)obscuredFloat)->currentCryptoKey = 0;
			((ObscuredFloat*)(nint)obscuredFloat)->hiddenValueOldByte4 = default(ACTkByte4);
			((ObscuredFloat*)(nint)obscuredFloat)->fakeValue = 0f;
			*(ObscuredFloat*)(nint)obscuredFloat = new ObscuredFloat(value);
			return obscuredFloat;
		}

		[Token(Token = "0x600014E")]
		[Address(RVA = "0xBDCACC", Offset = "0xBDCACC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat::InternalDecrypt(value);\n\treturn returnVal1;\n")]
		public unsafe static implicit operator float(ObscuredFloat value)
		{
			return ((ObscuredFloat*)value)->InternalDecrypt();
		}

		[Token(Token = "0x600014F")]
		[Address(RVA = "0xBDE270", Offset = "0xBDE270", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = input.currentCryptoKey;\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat::Increment(&v8 @ V0_v1 (System.Int32), 1);\n\treturnBuffer.fakeValue = returnVal1.fakeValue;\n\treturnBuffer.currentCryptoKey = returnVal1.currentCryptoKey;\n\treturn returnVal1;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredFloat operator ++(ObscuredFloat input)
		{
			//IL_001b: Expected O, but got Ref
			//IL_002c: Expected native int or pointer, but got O
			//IL_003e: Expected native int or pointer, but got O
			int num = input.currentCryptoKey;
			ObscuredFloat result = Increment((ObscuredFloat)(&num), 1);
			ObscuredFloat obscuredFloat = default(ObscuredFloat);
			((ObscuredFloat*)(nint)obscuredFloat)->fakeValue = result.fakeValue;
			((ObscuredFloat*)(nint)obscuredFloat)->currentCryptoKey = result.currentCryptoKey;
			return result;
		}

		[Token(Token = "0x6000150")]
		[Address(RVA = "0xBDE340", Offset = "0xBDE340", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = input.currentCryptoKey;\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat::Increment(&v8 @ V0_v1 (System.Int32), 0xFFFFFFFF);\n\treturnBuffer.fakeValue = returnVal1.fakeValue;\n\treturnBuffer.currentCryptoKey = returnVal1.currentCryptoKey;\n\treturn returnVal1;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredFloat operator --(ObscuredFloat input)
		{
			//IL_001b: Expected O, but got Ref
			//IL_002c: Expected native int or pointer, but got O
			//IL_003e: Expected native int or pointer, but got O
			int num = input.currentCryptoKey;
			ObscuredFloat result = Increment((ObscuredFloat)(&num), -1);
			ObscuredFloat obscuredFloat = default(ObscuredFloat);
			((ObscuredFloat*)(nint)obscuredFloat)->fakeValue = result.fakeValue;
			((ObscuredFloat*)(nint)obscuredFloat)->currentCryptoKey = result.currentCryptoKey;
			return result;
		}

		[Token(Token = "0x6000151")]
		[Address(RVA = "0xBDE2B8", Offset = "0xBDE2B8", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat::InternalDecrypt(input);\n\tv19 = v16 + increment;\n\tv21 = input.currentCryptoKey ^ v19;\n\tCodeStage.AntiCheat.Common.ACTkByte4::Shuffle(&v21 @ X8_v2 (CodeStage.AntiCheat.Common.ACTkByte4));\n\tinput.hiddenValue = v21;\n\treturnVal1 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv28 = returnVal1 & 1;\n\tv29 = v28 == 0;\n\tif (v29) goto L_FFFFFFFF;\n\tinput.fakeValue = v19;\n\tgoto L_001E;\nL_001E:\n\tinput.fakeValueActive = v32;\n\treturnBuffer.fakeValue = input.fakeValue;\n\treturnBuffer.currentCryptoKey = input.currentCryptoKey;\n\treturn returnVal1;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe static ObscuredFloat Increment(ObscuredFloat input, int increment)
		{
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Expected O, but got Unknown
			//IL_004a: Expected I4, but got O
			//IL_0045: Expected native int or pointer, but got O
			//IL_0053: Expected O, but got I4
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Expected I4, but got Unknown
			//IL_00af: Expected native int or pointer, but got O
			//IL_00c1: Expected native int or pointer, but got O
			//IL_00d3: Expected native int or pointer, but got O
			//IL_0086: Expected native int or pointer, but got O
			float num = ((ObscuredFloat*)input)->InternalDecrypt();
			float num2 = num + (float)increment;
			ACTkByte4 aCTkByte = (ACTkByte4)(input.currentCryptoKey ^ num2);
			aCTkByte.Shuffle();
			((ObscuredFloat*)(nint)input)->hiddenValue = (int)aCTkByte;
			ObscuredFloat obscuredFloat = (ObscuredFloat)ObscuredCheatingDetector.ExistsAndIsRunning;
			bool flag;
			if ((obscuredFloat & 1) != 0)
			{
				((ObscuredFloat*)(nint)input)->fakeValue = num2;
				flag = true;
			}
			else
			{
				flag = false;
			}
			((ObscuredFloat*)(nint)input)->fakeValueActive = flag;
			ObscuredFloat obscuredFloat2 = default(ObscuredFloat);
			((ObscuredFloat*)(nint)obscuredFloat2)->fakeValue = input.fakeValue;
			((ObscuredFloat*)(nint)obscuredFloat2)->currentCryptoKey = input.currentCryptoKey;
			return obscuredFloat;
		}

		[Token(Token = "0x6000152")]
		[Address(RVA = "0xBDE388", Offset = "0xBDE388", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat::InternalDecrypt(this);\n\treturnVal1 = System.Single::GetHashCode(&v2 @ V0_v1 (System.Single));\n\treturn returnVal1;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override int GetHashCode()
		{
			return InternalDecrypt().GetHashCode();
		}

		[Token(Token = "0x6000153")]
		[Address(RVA = "0xBDE3A8", Offset = "0xBDE3A8", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat::InternalDecrypt(this);\n\treturnVal1 = System.Single::ToString(&v2 @ V0_v1 (System.Single));\n\treturn returnVal1;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			return InternalDecrypt().ToString();
		}

		[Token(Token = "0x6000154")]
		[Address(RVA = "0xBDE3C8", Offset = "0xBDE3C8", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat::InternalDecrypt(this);\n\treturnVal1 = System.Single::ToString(&v6 @ V0_v1 (System.Single), format);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string ToString(string format)
		{
			return InternalDecrypt().ToString(format);
		}

		[Token(Token = "0x6000155")]
		[Address(RVA = "0xBDE3F8", Offset = "0xBDE3F8", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat::InternalDecrypt(this);\n\treturnVal1 = System.Single::ToString(&v6 @ V0_v1 (System.Single), provider);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string ToString(IFormatProvider provider)
		{
			return InternalDecrypt().ToString(provider);
		}

		[Token(Token = "0x6000156")]
		[Address(RVA = "0xBDE428", Offset = "0xBDE428", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat::InternalDecrypt(this);\n\treturnVal1 = System.Single::ToString(&v10 @ V0_v1 (System.Single), format, provider);\n\treturn returnVal1;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string ToString(string format, IFormatProvider provider)
		{
			return InternalDecrypt().ToString(format, provider);
		}

		[Token(Token = "0x6000157")]
		[Address(RVA = "0xBDE460", Offset = "0xBDE460", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, obj, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A35470]) = v36;\nL_0012:\n\tv37 = obj == 0;\n\tif (v37) goto L_FFFFFFFF;\n\tv46 = *([obj @ X1 (System.Object)]) == CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat;\n\tif (v46) goto L_0025;\n\tgoto L_0033;\nL_0025:\n\tv72 = \"il2cpp_vm_object_unbox\"(obj, obj, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv26 = *([v72 @ X0_v6]);\n\tv92 = CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat::Equals(this, &v26 @ V0);\nL_0033:\n\treturn v92;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override bool Equals(object obj)
		{
			//IL_005b: Expected O, but got Ref
			if (obj == null || (object)obj.GetType() != typeof(ObscuredFloat))
			{
				return false;
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
			object obj3 = default(object);
			object obj2 = obj3;
			return Equals((ObscuredFloat)(&obj2));
		}

		[Token(Token = "0x6000158")]
		[Address(RVA = "0xBDE4F0", Offset = "0xBDE4F0", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat::InternalDecrypt(obj);\n\tv8 = CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat::InternalDecrypt(this);\n\tv14 = System.Single::Equals(&v8 @ V0_v1 (System.Single), v8);\n\treturn v14;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe bool Equals(ObscuredFloat obj)
		{
			float num = ((ObscuredFloat*)obj)->InternalDecrypt();
			num = InternalDecrypt();
			return num.Equals(num);
		}

		[Token(Token = "0x6000159")]
		[Address(RVA = "0xBDE52C", Offset = "0xBDE52C", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat::InternalDecrypt(this);\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat::InternalDecrypt(other);\n\treturnVal1 = System.Single::CompareTo(&v6 @ V0_v1 (System.Single), v6);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe int CompareTo(ObscuredFloat other)
		{
			float num = InternalDecrypt();
			num = ((ObscuredFloat*)other)->InternalDecrypt();
			return num.CompareTo(num);
		}

		[Token(Token = "0x600015A")]
		[Address(RVA = "0xBDE560", Offset = "0xBDE560", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat::InternalDecrypt(this);\n\treturnVal1 = System.Single::CompareTo(&v6 @ V0_v1 (System.Single), v6);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int CompareTo(float other)
		{
			float value = InternalDecrypt();
			return value.CompareTo(value);
		}

		[Token(Token = "0x600015B")]
		[Address(RVA = "0xBDE598", Offset = "0xBDE598", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat::InternalDecrypt(this);\n\treturnVal1 = System.Single::CompareTo(&v6 @ V0_v1 (System.Single), obj);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int CompareTo(object obj)
		{
			return InternalDecrypt().CompareTo(obj);
		}

		[Obsolete("This API is redundant and does not perform any actions. It will be removed in future updates.")]
		[Token(Token = "0x600015C")]
		[Address(RVA = "0xBDE5C8", Offset = "0xBDE5C8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public static void SetNewCryptoKey(int newKey)
		{
		}

		[Obsolete("This API is redundant and does not perform any actions. It will be removed in future updates.")]
		[Token(Token = "0x600015D")]
		[Address(RVA = "0xBDE5CC", Offset = "0xBDE5CC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void ApplyNewCryptoKey()
		{
		}

		[Obsolete("Please use new Encrypt(value, key) API instead.", true)]
		[Token(Token = "0x600015E")]
		[Address(RVA = "0xBDE5D0", Offset = "0xBDE5D0", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int Encrypt(float value)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new Decrypt(value, key) API instead.", true)]
		[Token(Token = "0x600015F")]
		[Address(RVA = "0xBDE608", Offset = "0xBDE608", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float Decrypt(int value)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new FromEncrypted(encrypted, key) API instead.", true)]
		[Token(Token = "0x6000160")]
		[Address(RVA = "0xBDE640", Offset = "0xBDE640", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ObscuredFloat FromEncrypted(int encrypted)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new GetEncrypted(out key) API instead.", true)]
		[Token(Token = "0x6000161")]
		[Address(RVA = "0xBDE678", Offset = "0xBDE678", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int GetEncrypted()
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new SetEncrypted(encrypted, key) API instead.", true)]
		[Token(Token = "0x6000162")]
		[Address(RVA = "0xBDE6B0", Offset = "0xBDE6B0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetEncrypted(int encrypted)
		{
		}
	}
}
