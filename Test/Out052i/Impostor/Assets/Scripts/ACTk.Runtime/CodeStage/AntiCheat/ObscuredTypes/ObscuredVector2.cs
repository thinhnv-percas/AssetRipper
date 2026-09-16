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
	[Token(Token = "0x2000022")]
	public struct ObscuredVector2 : IObscuredType
	{
		[Serializable]
		[Token(Token = "0x2000023")]
		public struct RawEncryptedVector2
		{
			[Token(Token = "0x40000B2")]
			[FieldOffset(Offset = "0x0")]
			public int x;

			[Token(Token = "0x40000B3")]
			[FieldOffset(Offset = "0x4")]
			public int y;
		}

		[Token(Token = "0x40000AC")]
		private static readonly Vector2 Zero = Vector2.zero;

		[SerializeField]
		[Token(Token = "0x40000AD")]
		[FieldOffset(Offset = "0x0")]
		private int currentCryptoKey;

		[SerializeField]
		[Token(Token = "0x40000AE")]
		[FieldOffset(Offset = "0x4")]
		private RawEncryptedVector2 hiddenValue;

		[SerializeField]
		[Token(Token = "0x40000AF")]
		[FieldOffset(Offset = "0xC")]
		private bool inited;

		[SerializeField]
		[Token(Token = "0x40000B0")]
		[FieldOffset(Offset = "0x10")]
		private Vector2 fakeValue;

		[SerializeField]
		[Token(Token = "0x40000B1")]
		[FieldOffset(Offset = "0x18")]
		private bool fakeValueActive;

		[Token(Token = "0x1700000C")]
		public unsafe float x
		{
			[Token(Token = "0x600029B")]
			[Address(RVA = "0xBE31BC", Offset = "0xBE31BC", Length = "0x130")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = System.Math;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A35499]) = v38;\nL_0016:\n\tv40 = this.hiddenValue;\n\tCodeStage.AntiCheat.Common.ACTkByte4::UnShuffle(&v40 @ X8_v3 (CodeStage.AntiCheat.Common.ACTkByte4));\n\tv48 = v40 ^ this.currentCryptoKey;\n\tv50 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv52 = v50 == 0;\n\tif (v52) goto L_0073;\n\tv54 = ~this.fakeValueActive;\n\tif (v54) goto L_0073;\n\tgoto L_0037;\n\tv147 = \"il2cpp_codegen_runtime_class_init\"(v110, v43, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0037:\n\tgoto L_003F;\n\tv156 = 0xB348B0(v151, v43, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_003F:\n\tgoto L_0042;\n\tv164 = 0xB348B0(v159, v43, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0042:\n\tv101 = v165.<Instance>k__BackingField;\n\t// 70 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv61 = v28 <= v101.vector2Epsilon;\n\tif (v61) goto L_0073;\n\tgoto L_0062;\n\tv178 = 0xB348B0(v173, v43, v21, v22, v23, v24, v25, v26, v88, v28, v29, v30, v31, v32, v33, v34);\nL_0062:\n\tgoto L_006B;\n\tv186 = 0xB348B0(v181, v43, v21, v22, v23, v24, v25, v26, v88, v28, v29, v30, v31, v32, v33, v34);\nL_006B:\n\tv92 = CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector>::OnCheatingDetected(v171.<Instance>k__BackingField);\nL_0073:\n\treturn v48;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
				//IL_00a8: Expected I4, but got Unknown
				ACTkByte4 aCTkByte = (ACTkByte4)hiddenValue;
				aCTkByte.UnShuffle();
				int num = aCTkByte ^ currentCryptoKey;
				if (ObscuredCheatingDetector.ExistsAndIsRunning && fakeValueActive)
				{
					ObscuredCheatingDetector _003CInstance_003Ek__BackingField = KeepAliveBehaviour<ObscuredCheatingDetector>.Instance;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
					object obj = default(object);
					if ((float)obj > _003CInstance_003Ek__BackingField.vector2Epsilon)
					{
						KeepAliveBehaviour<ObscuredCheatingDetector>.Instance.OnCheatingDetected();
					}
				}
				return num;
			}
			[Token(Token = "0x600029C")]
			[Address(RVA = "0xBE32EC", Offset = "0xBE32EC", Length = "0x94")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = this.currentCryptoKey;\n\tv8 = v8 ^ value;\n\tCodeStage.AntiCheat.Common.ACTkByte4::Shuffle(&v8 @ X8_v1 (System.Int32));\n\tthis.hiddenValue = v8;\n\tv20 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv22 = v20 == 0;\n\tif (v22) goto L_FFFFFFFF;\n\tv23 = this->monitor;\n\tthis.fakeValue = value;\n\tCodeStage.AntiCheat.Common.ACTkByte4::UnShuffle(&v23 @ X8_v6 (CodeStage.AntiCheat.Common.ACTkByte4));\n\tv8 = v23 ^ this.currentCryptoKey;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2)+14]) = v8;\n\tgoto L_0022;\nL_0022:\n\tthis.fakeValueActive = v37;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0012: Unknown result type (might be due to invalid IL or missing references)
				//IL_0017: Expected I4, but got Unknown
				//IL_002a: Expected O, but got I4
				//IL_0065: Expected O, but got I
				//IL_006f: Expected O, but got F4
				//IL_0082: Unknown result type (might be due to invalid IL or missing references)
				//IL_0087: Expected I4, but got Unknown
				int num = currentCryptoKey;
				num ^= value;
				((ACTkByte4*)(&num))->Shuffle();
				hiddenValue = (RawEncryptedVector2)num;
				bool flag;
				if (ObscuredCheatingDetector.ExistsAndIsRunning)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2)+8]");
					ACTkByte4 aCTkByte = (ACTkByte4)0;
					fakeValue = (Vector2)value;
					aCTkByte.UnShuffle();
					num = aCTkByte ^ currentCryptoKey;
					flag = true;
				}
				else
				{
					flag = false;
				}
				fakeValueActive = flag;
			}
		}

		[Token(Token = "0x1700000D")]
		public float y
		{
			[Token(Token = "0x600029D")]
			[Address(RVA = "0xBE3380", Offset = "0xBE3380", Length = "0x134")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = System.Math;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A3549A]) = v38;\nL_0015:\n\tv39 = this->monitor;\n\tCodeStage.AntiCheat.Common.ACTkByte4::UnShuffle(&v39 @ X8_v3 (CodeStage.AntiCheat.Common.ACTkByte4));\n\tv48 = v39 ^ this.currentCryptoKey;\n\tv50 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv52 = v50 == 0;\n\tif (v52) goto L_0073;\n\tv54 = ~this.fakeValueActive;\n\tif (v54) goto L_0073;\n\tgoto L_0037;\n\tv147 = \"il2cpp_codegen_runtime_class_init\"(v110, v43, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0037:\n\tgoto L_003F;\n\tv156 = 0xB348B0(v151, v43, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_003F:\n\tgoto L_0042;\n\tv164 = 0xB348B0(v159, v43, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0042:\n\tv101 = v165.<Instance>k__BackingField;\n\t// 70 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv61 = v28 <= v101.vector2Epsilon;\n\tif (v61) goto L_0073;\n\tgoto L_0062;\n\tv178 = 0xB348B0(v173, v43, v21, v22, v23, v24, v25, v26, v88, v28, v29, v30, v31, v32, v33, v34);\nL_0062:\n\tgoto L_006B;\n\tv186 = 0xB348B0(v181, v43, v21, v22, v23, v24, v25, v26, v88, v28, v29, v30, v31, v32, v33, v34);\nL_006B:\n\tv92 = CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector>::OnCheatingDetected(v171.<Instance>k__BackingField);\nL_0073:\n\treturn v48;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0096: Expected O, but got I
				//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ae: Expected I4, but got Unknown
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2)+8]");
				ACTkByte4 aCTkByte = (ACTkByte4)0;
				aCTkByte.UnShuffle();
				int num = aCTkByte ^ currentCryptoKey;
				if (ObscuredCheatingDetector.ExistsAndIsRunning && fakeValueActive)
				{
					ObscuredCheatingDetector _003CInstance_003Ek__BackingField = KeepAliveBehaviour<ObscuredCheatingDetector>.Instance;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
					object obj = default(object);
					if ((float)obj > _003CInstance_003Ek__BackingField.vector2Epsilon)
					{
						KeepAliveBehaviour<ObscuredCheatingDetector>.Instance.OnCheatingDetected();
					}
				}
				return num;
			}
			[Token(Token = "0x600029E")]
			[Address(RVA = "0xBE34B4", Offset = "0xBE34B4", Length = "0x90")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = this.currentCryptoKey;\n\tv8 = v8 ^ value;\n\tCodeStage.AntiCheat.Common.ACTkByte4::Shuffle(&v8 @ X8_v1 (System.Int32));\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2)+8]) = v8;\n\tv20 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv22 = v20 == 0;\n\tif (v22) goto L_FFFFFFFF;\n\tv24 = this.hiddenValue;\n\tCodeStage.AntiCheat.Common.ACTkByte4::UnShuffle(&v24 @ X8_v6 (CodeStage.AntiCheat.Common.ACTkByte4));\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2)+14]) = value;\n\tv8 = v24 ^ this.currentCryptoKey;\n\tthis.fakeValue = v8;\n\tgoto L_0022;\nL_0022:\n\tthis.fakeValueActive = v37;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0012: Unknown result type (might be due to invalid IL or missing references)
				//IL_0017: Expected I4, but got Unknown
				//IL_0072: Unknown result type (might be due to invalid IL or missing references)
				//IL_0077: Expected I4, but got Unknown
				//IL_0081: Expected O, but got I4
				int num = currentCryptoKey;
				System.Runtime.CompilerServices.Unsafe.As<int, ACTkByte4>(ref num ^ value).Shuffle();
				bool flag;
				if (ObscuredCheatingDetector.ExistsAndIsRunning)
				{
					ACTkByte4 aCTkByte = (ACTkByte4)hiddenValue;
					aCTkByte.UnShuffle();
					num = aCTkByte ^ currentCryptoKey;
					fakeValue = (Vector2)num;
					flag = true;
				}
				else
				{
					flag = false;
				}
				fakeValueActive = flag;
			}
		}

		[Token(Token = "0x1700000E")]
		public float this[int index]
		{
			[Token(Token = "0x600029F")]
			[Address(RVA = "0xBE3544", Offset = "0xBE3544", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, index, methodInfo, v21, v22, v23, v24, v25, returnVal3, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A3549B]) = v36;\nL_0016:\n\tv41 = index == 1;\n\tif (v41) goto L_0035;\n\tv46 = index == 0;\n\tv47 = ~v46;\n\tif (v47) goto L_0042;\n\tgoto L_002D;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v56, index, methodInfo, v21, v22, v23, v24, v25, returnVal3, v27, v28, v29, v30, v31, v32, v33);\nL_002D:\n\treturnVal2 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2::get_x(this);\n\treturn returnVal2;\nL_0035:\n\tgoto L_003D;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v50, index, methodInfo, v21, v22, v23, v24, v25, returnVal3, v27, v28, v29, v30, v31, v32, v33);\nL_003D:\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2::get_y(this);\n\treturn returnVal1;\nL_0042:\n\tv79 = new System.IndexOutOfRangeException();\n\tSystem.IndexOutOfRangeException::.ctor(v79, \"Invalid ObscuredVector2 index!\");\n\tthrow v79;\n\treturn returnVal3;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				switch (index)
				{
				case 0:
					return x;
				case 1:
					return y;
				default:
				{
					IndexOutOfRangeException ex = new IndexOutOfRangeException("Invalid ObscuredVector2 index!");
					throw ex;
				}
				}
			}
			[Token(Token = "0x60002A0")]
			[Address(RVA = "0xBE3618", Offset = "0xBE3618", Length = "0xEC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, index, methodInfo, v25, v26, v27, v28, v29, value, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A3549C]) = v39;\nL_0018:\n\tv44 = index == 1;\n\tif (v44) goto L_0039;\n\tv49 = index == 0;\n\tv50 = ~v49;\n\tif (v50) goto L_0048;\n\tgoto L_0031;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v59, index, methodInfo, v25, v26, v27, v28, v29, value, v30, v31, v32, v33, v34, v35, v36);\nL_0031:\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredVector2::set_x(this, value);\n\treturn;\nL_0039:\n\tgoto L_0043;\n\tv66 = \"il2cpp_codegen_runtime_class_init\"(v53, index, methodInfo, v25, v26, v27, v28, v29, value, v30, v31, v32, v33, v34, v35, v36);\nL_0043:\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredVector2::set_y(this, value);\n\treturn;\nL_0048:\n\tv84 = new System.IndexOutOfRangeException();\n\tSystem.IndexOutOfRangeException::.ctor(v84, \"Invalid ObscuredVector2 index!\");\n\tthrow v84;\n\treturn;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				switch (index)
				{
				case 0:
					x = value;
					break;
				case 1:
					y = value;
					break;
				default:
				{
					IndexOutOfRangeException ex = new IndexOutOfRangeException("Invalid ObscuredVector2 index!");
					throw ex;
				}
				}
			}
		}

		[Token(Token = "0x6000299")]
		[Address(RVA = "0xBE2F68", Offset = "0xBE2F68", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, value, v0, v35, v36, v37, v38, v39, v40);\n\tv43 = 1;\n\t*([1A35497]) = v43;\nL_001C:\n\tgoto L_001E;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v29, v30, v31, v32, v33, v34, value, v0, v35, v36, v37, v38, v39, v40);\nL_001E:\n\tv50 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tthis.currentCryptoKey = v50;\n\tv54 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2::Encrypt(value, v50);\n\tthis.hiddenValue = v54;\n\tv56 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tgoto L_0038;\n\tv61 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2;\n\tv62 = *([v61 @ X0_v9+E0]);\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_FFFFFFFF;\n\tv82 = \"il2cpp_codegen_runtime_class_init\"(v61, methodInfo, v29, v30, v31, v32, v33, v34, v51, v52, v35, v36, v37, v38, v39, v40);\n\tv83 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2;\n\tv73 = *([v66 @ X0_v10+B8]);\n\tv69 = *([v73 @ X8_v7]);\n\tv71 = *([v73 @ X8_v7+4]);\nL_0038:\n\tthis.fakeValue = value;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2)+14]) = value.y;\n\tthis.fakeValueActive = v56;\n\tthis.inited = 1;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private ObscuredVector2(Vector2 value)
		{
			RawEncryptedVector2 rawEncryptedVector = Encrypt(key: currentCryptoKey = RandomUtils.GenerateIntKey(), value: value);
			hiddenValue = rawEncryptedVector;
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			fakeValue = value;
			_ = value.y;
			fakeValueActive = existsAndIsRunning;
			inited = true;
		}

		[Token(Token = "0x600029A")]
		[Address(RVA = "0xBE3090", Offset = "0xBE3090", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, x, y, v35, v36, v37, v38, v39, v40);\n\tv43 = 1;\n\t*([1A35498]) = v43;\nL_001B:\n\tgoto L_001D;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v29, v30, v31, v32, v33, v34, x, y, v35, v36, v37, v38, v39, v40);\nL_001D:\n\tv50 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tthis.currentCryptoKey = v50;\n\tv53 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2::Encrypt(x, y, v50);\n\tthis.hiddenValue = v53;\n\tv55 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv57 = v55 == 0;\n\tif (v57) goto L_0030;\n\tthis.fakeValue = x;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2)+14]) = y;\n\tgoto L_0037;\nL_0030:\n\tgoto L_0036;\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v59, methodInfo, v29, v30, v31, v32, v33, v34, v51, v52, v35, v36, v37, v38, v39, v40);\n\tv79 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2;\nL_0036:\n\tthis.fakeValue = v80.Zero;\nL_0037:\n\tthis.fakeValueActive = v69;\n\tthis.inited = 1;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObscuredVector2(float x, float y)
		{
			//IL_006c: Expected O, but got F4
			RawEncryptedVector2 rawEncryptedVector = Encrypt(x, y, currentCryptoKey = RandomUtils.GenerateIntKey());
			hiddenValue = rawEncryptedVector;
			bool flag;
			if (ObscuredCheatingDetector.ExistsAndIsRunning)
			{
				fakeValue = (Vector2)x;
				flag = true;
			}
			else
			{
				fakeValue = Zero;
				flag = false;
			}
			fakeValueActive = flag;
			inited = true;
		}

		[Token(Token = "0x60002A1")]
		[Address(RVA = "0xBE3024", Offset = "0xBE3024", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, value, v0, v35, v36, v37, v38, v39, v40);\n\tv43 = 1;\n\t*([1A3549D]) = v43;\nL_001C:\n\tgoto L_0028;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v29, v30, v31, v32, v33, v34, value, v0, v35, v36, v37, v38, v39, v40);\nL_0028:\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2::Encrypt(value, value.y, key);\n\treturn returnVal1;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static RawEncryptedVector2 Encrypt(Vector2 value, int key)
		{
			Vector2 vector = default(Vector2);
			return Encrypt(vector.x, value.y, key);
		}

		[Token(Token = "0x60002A2")]
		[Address(RVA = "0xBE3150", Offset = "0xBE3150", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = x ^ key;\n\tCodeStage.AntiCheat.Common.ACTkByte4::Shuffle(&v12 @ X8_v2 (System.Int32));\n\tv12 = y ^ key;\n\tCodeStage.AntiCheat.Common.ACTkByte4::Shuffle(&v12 @ X8_v2 (System.Int32));\n\tv27 = v12 & 0xFFFFFFFF;\n\tv28 = v27 << 0x20;\n\tv29 = v12 & 0xFFFFFFFF;\n\tv30 = v29 | v28;\n\treturn v30;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static RawEncryptedVector2 Encrypt(float x, float y, int key)
		{
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected I4, but got Unknown
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Expected I4, but got Unknown
			//IL_0043: Expected I4, but got I8
			//IL_0063: Expected I4, but got I8
			//IL_0075: Expected O, but got I4
			System.Runtime.CompilerServices.Unsafe.As<int, ACTkByte4>(ref x ^ key).Shuffle();
			int num = y ^ key;
			((ACTkByte4*)(&num))->Shuffle();
			int num2 = (int)(num & 0xFFFFFFFFL);
			int num3 = num2 << 32;
			int num4 = (int)(num & 0xFFFFFFFFL);
			int num5 = num4 | num3;
			return (RawEncryptedVector2)num5;
		}

		[Token(Token = "0x60002A3")]
		[Address(RVA = "0xBE3704", Offset = "0xBE3704", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = value >> 0x20;\n\tCodeStage.AntiCheat.Common.ACTkByte4::UnShuffle(&v14 @ stack_-30_v2 (CodeStage.AntiCheat.Common.ACTkByte4));\n\tv20 = v14 ^ key;\n\tCodeStage.AntiCheat.Common.ACTkByte4::UnShuffle(&v10 @ X20_v1 (System.Int32));\n\treturn v20;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static Vector2 Decrypt(RawEncryptedVector2 value, int key)
		{
			//IL_000e: Expected I4, but got O
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected I4, but got Unknown
			//IL_0037: Expected O, but got I4
			int num = (object)value >> 32;
			ACTkByte4 aCTkByte = default(ACTkByte4);
			aCTkByte.UnShuffle();
			int num2 = aCTkByte ^ key;
			((ACTkByte4*)(&num))->UnShuffle();
			return (Vector2)num2;
		}

		[Token(Token = "0x60002A4")]
		[Address(RVA = "0xBE376C", Offset = "0xBE376C", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv26 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, key, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 1;\n\t*([1A3549E]) = v44;\nL_001F:\n\tgoto L_0024;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, key, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0024:\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredVector2::SetEncrypted(&v56 @ stack_-50_v2 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2), encrypted, key);\n\treturnBuffer.inited = v60;\n\treturnBuffer.currentCryptoKey = v56;\n\treturn &v56 @ stack_-50_v2 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2);\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredVector2 FromEncrypted(RawEncryptedVector2 encrypted, int key)
		{
			//IL_0023: Expected I4, but got O
			//IL_001e: Expected native int or pointer, but got O
			//IL_0030: Expected I4, but got O
			//IL_002b: Expected native int or pointer, but got O
			//IL_0035: Expected O, but got Ref
			ObscuredVector2 obscuredVector = default(ObscuredVector2);
			obscuredVector.SetEncrypted(encrypted, key);
			ObscuredVector2 obscuredVector2 = default(ObscuredVector2);
			object obj = default(object);
			((ObscuredVector2*)(nint)obscuredVector2)->inited = (byte)(int)obj != 0;
			((ObscuredVector2*)(nint)obscuredVector2)->currentCryptoKey = (int)obscuredVector;
			return (ObscuredVector2)(&obscuredVector);
		}

		[Token(Token = "0x60002A5")]
		[Address(RVA = "0xBE3020", Offset = "0xBE3020", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\treturn returnVal1;\n")]
		public static int GenerateKey()
		{
			return RandomUtils.GenerateIntKey();
		}

		[Token(Token = "0x60002A6")]
		[Address(RVA = "0xBE3894", Offset = "0xBE3894", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv32 = Il2CppMethodInfo;\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, v34, v35, v36, v37, v38, v39, v40, vector1, v0, vector2, v2, v41, v42, v43, v44);\n\tv57 = System.Math;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, v34, v35, v36, v37, v38, v39, v40, vector1, v0, vector2, v2, v41, v42, v43, v44);\n\tv49 = 1;\n\t*([1A3549F]) = v49;\nL_0025:\n\tgoto L_002D;\n\tv58 = 0xB348B0(v51, v34, v35, v36, v37, v38, v39, v40, vector1, v0, vector2, v2, v41, v42, v43, v44);\nL_002D:\n\tgoto L_0030;\n\tv66 = 0xB348B0(v61, v34, v35, v36, v37, v38, v39, v40, vector1, v0, vector2, v2, v41, v42, v43, v44);\nL_0030:\n\tv69 = v68.<Instance>k__BackingField;\n\tgoto L_003C;\n\tv79 = \"il2cpp_codegen_runtime_class_init\"(v74, v34, v35, v36, v37, v38, v39, v40, vector1, v0, vector2, v2, v41, v42, v43, v44);\nL_003C:\n\t// 60 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv90 = vector1 >= v69.vector2Epsilon;\n\tif (v90) goto L_FFFFFFFF;\n\tgoto L_004E;\n\tv146 = \"il2cpp_codegen_runtime_class_init\"(v91, v34, v35, v36, v37, v38, v39, v40, vector1, v0, vector2, v2, v41, v42, v43, v44);\nL_004E:\n\t// 78 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv150 = vector1 - v69.vector2Epsilon;\n\tv151 = v150 < 0;\n\tgoto L_0064;\nL_0064:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool CompareVectorsWithTolerance(Vector2 vector1, Vector2 vector2)
		{
			ObscuredCheatingDetector _003CInstance_003Ek__BackingField = KeepAliveBehaviour<ObscuredCheatingDetector>.Instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
			Vector2 vector3 = default(Vector2);
			if (vector3.x < _003CInstance_003Ek__BackingField.vector2Epsilon)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
				float num = vector3.x - _003CInstance_003Ek__BackingField.vector2Epsilon;
				return num < 0f;
			}
			return false;
		}

		[Token(Token = "0x60002A7")]
		[Address(RVA = "0xBE3988", Offset = "0xBE3988", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([key @ X1 (System.Int32&)]) = this.currentCryptoKey;\n\treturn this.hiddenValue;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe RawEncryptedVector2 GetEncrypted(out int key)
		{
			key = default(int);
			ref int reference = ref *(int*)currentCryptoKey;
			return hiddenValue;
		}

		[Token(Token = "0x60002A8")]
		[Address(RVA = "0xBE3800", Offset = "0xBE3800", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, encrypted, key, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A354A0]) = v39;\nL_0016:\n\tthis.hiddenValue = encrypted;\n\tthis.inited = 1;\n\tthis.currentCryptoKey = key;\n\tv42 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tthis.fakeValueActive = 0;\n\tv44 = v42 == 0;\n\tif (v44) goto L_0033;\n\tgoto L_0027;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v47, encrypted, key, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0027:\n\tv54 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2::InternalDecrypt(this);\n\tthis.fakeValue = v54;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2)+14]) = v54.y;\n\tthis.fakeValueActive = 1;\nL_0033:\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetEncrypted(RawEncryptedVector2 encrypted, int key)
		{
			hiddenValue = encrypted;
			inited = true;
			currentCryptoKey = key;
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			fakeValueActive = false;
			if (existsAndIsRunning)
			{
				Vector2 vector = (fakeValue = InternalDecrypt());
				_ = vector.y;
				fakeValueActive = true;
			}
		}

		[Token(Token = "0x60002A9")]
		[Address(RVA = "0xBE3B18", Offset = "0xBE3B18", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A354A1]) = v37;\nL_0017:\n\tgoto L_001F;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001F:\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2::InternalDecrypt(this);\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Vector2 GetDecrypted()
		{
			return InternalDecrypt();
		}

		[Token(Token = "0x60002AA")]
		[Address(RVA = "0xBE3B6C", Offset = "0xBE3B6C", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 1;\n\t*([1A354A2]) = v41;\nL_0019:\n\tgoto L_001C;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_001C:\n\tv49 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2::InternalDecrypt(this);\n\tv53 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tthis.currentCryptoKey = v53;\n\tv57 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2::Encrypt(v49, v53);\n\tthis.hiddenValue = v57;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RandomizeCryptoKey()
		{
			Vector2 value = InternalDecrypt();
			RawEncryptedVector2 rawEncryptedVector = Encrypt(value, currentCryptoKey = RandomUtils.GenerateIntKey());
			hiddenValue = rawEncryptedVector;
		}

		[Token(Token = "0x60002AB")]
		[Address(RVA = "0xBE3998", Offset = "0xBE3998", Length = "0x180")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv52 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A354A3]) = v46;\nL_001C:\n\tv50 = ~this.inited;\n\tif (v50) goto L_0066;\n\tgoto L_0028;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v53, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0028:\n\tv67 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2::Decrypt(this.hiddenValue, this.currentCryptoKey);\n\tv75 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv83 = v75 == 0;\n\tif (v83) goto L_0087;\n\tv92 = ~this.fakeValueActive;\n\tif (v92) goto L_0087;\n\tgoto L_0042;\n\tv171 = \"il2cpp_codegen_runtime_class_init\"(v144, v66, v29, v30, v31, v32, v33, v34, v67, v71, v37, v38, v39, v40, v41, v42);\nL_0042:\n\tv124 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2::CompareVectorsWithTolerance(v67, this.fakeValue);\n\tv174 = v124 == 0;\n\tv127 = ~v174;\n\tif (v127) goto L_0087;\n\tgoto L_0057;\n\tv183 = 0xB348B0(v178, v66, v29, v30, v31, v32, v33, v34, returnVal2, v117, v109, v107, v39, v40, v41, v42);\nL_0057:\n\tgoto L_0060;\n\tv191 = 0xB348B0(v186, v66, v29, v30, v31, v32, v33, v34, returnVal2, v117, v109, v107, v39, v40, v41, v42);\nL_0060:\n\tv125 = CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector>::OnCheatingDetected(v169.<Instance>k__BackingField);\n\tgoto L_0087;\nL_0066:\n\tgoto L_0068;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v59, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0068:\n\tv70 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tthis.currentCryptoKey = v70;\n\tv81 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2::Encrypt(v77.Zero, v70);\n\tthis.hiddenValue = v81;\n\tthis.fakeValueActive = 0;\n\tthis.inited = 1;\n\tthis.fakeValue = v86.Zero;\n\tv115 = v88.Zero;\nL_0087:\n\treturn v115;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 96 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private Vector2 InternalDecrypt()
		{
			Vector2 result;
			if (inited)
			{
				Vector2 vector = Decrypt(hiddenValue, currentCryptoKey);
				bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
				bool flag = !existsAndIsRunning;
				result = vector;
				if (!flag)
				{
					bool flag2 = !fakeValueActive;
					result = vector;
					if (!flag2)
					{
						bool flag3 = CompareVectorsWithTolerance(vector, fakeValue);
						bool flag4 = !flag3;
						bool flag5 = !flag4;
						result = vector;
						if (!flag5)
						{
							KeepAliveBehaviour<ObscuredCheatingDetector>.Instance.OnCheatingDetected();
							result = vector;
						}
					}
				}
			}
			else
			{
				RawEncryptedVector2 rawEncryptedVector = Encrypt(key: currentCryptoKey = RandomUtils.GenerateIntKey(), value: Zero);
				hiddenValue = rawEncryptedVector;
				fakeValueActive = false;
				inited = true;
				fakeValue = Zero;
				result = Zero;
			}
			return result;
		}

		[Token(Token = "0x60002AC")]
		[Address(RVA = "0xBE3BEC", Offset = "0xBE3BEC", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnBuffer.currentCryptoKey = 0;\n\t*([returnBuffer @ X8 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2)+8]) = 0;\n\treturnBuffer.fakeValueActive = 0;\n\treturnBuffer.fakeValue = 0;\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredVector2::.ctor(returnBuffer, value);\n\treturn returnBuffer;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static implicit operator ObscuredVector2(Vector2 value)
		{
			//IL_0009: Expected native int or pointer, but got O
			//IL_001d: Expected native int or pointer, but got O
			//IL_0034: Expected native int or pointer, but got O
			//IL_0041: Expected native int or pointer, but got O
			ObscuredVector2 obscuredVector = default(ObscuredVector2);
			((ObscuredVector2*)(nint)obscuredVector)->currentCryptoKey = 0;
			_ = 0;
			((ObscuredVector2*)(nint)obscuredVector)->fakeValueActive = false;
			((ObscuredVector2*)(nint)obscuredVector)->fakeValue = default(Vector2);
			*(ObscuredVector2*)(nint)obscuredVector = new ObscuredVector2(value);
			return obscuredVector;
		}

		[Token(Token = "0x60002AD")]
		[Address(RVA = "0xBE3C00", Offset = "0xBE3C00", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A354A4]) = v37;\nL_0017:\n\tgoto L_001F;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001F:\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2::InternalDecrypt(value);\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static implicit operator Vector2(ObscuredVector2 value)
		{
			return ((ObscuredVector2*)value)->InternalDecrypt();
		}

		[Token(Token = "0x60002AE")]
		[Address(RVA = "0xBE3C54", Offset = "0xBE3C54", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A354A5]) = v37;\nL_0017:\n\tgoto L_001A;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001A:\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2::InternalDecrypt(value);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static implicit operator Vector3(ObscuredVector2 value)
		{
			return ((ObscuredVector2*)value)->InternalDecrypt();
		}

		[Token(Token = "0x60002AF")]
		[Address(RVA = "0xBE3CB0", Offset = "0xBE3CB0", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A354A6]) = v37;\nL_0017:\n\tgoto L_001A;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001A:\n\tv45 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2::InternalDecrypt(this);\n\tv52 = &v48 @ stack_-28 | 4;\n\tv54 = System.Single::GetHashCode(&v45 @ V0_v1 (UnityEngine.Vector2));\n\tv58 = System.Single::GetHashCode(v52);\n\treturnVal1 = v54 ^ v58;\n\treturn returnVal1;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override int GetHashCode()
		{
			Vector2 vector = InternalDecrypt();
			object obj = default(object);
			int num = (int)((nint)obj | 4);
			int hashCode = ((float*)(&vector))->GetHashCode();
			int hashCode2 = ((float*)num)->GetHashCode();
			return hashCode ^ hashCode2;
		}

		[Token(Token = "0x60002B0")]
		[Address(RVA = "0xBE3D3C", Offset = "0xBE3D3C", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A354A7]) = v37;\nL_0017:\n\tgoto L_001A;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001A:\n\tv45 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2::InternalDecrypt(this);\n\treturnVal1 = 0xBEE74C(&v45 @ V0_v1 (UnityEngine.Vector2), 0, 0, 0, v23, v24, v25, v26, v45, v45.y, v29, v30, v31, v32, v33, v34);\n\treturn returnVal1;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			Vector2 vector = InternalDecrypt();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @BEE74C (inside CodeStage.AntiCheat.Genuine.CodeHash.AndroidWorker+CodeHashGeneratorCallback::OnError +0x238)");
			string result = default(string);
			return result;
		}

		[Token(Token = "0x60002B1")]
		[Address(RVA = "0xBE3DB4", Offset = "0xBE3DB4", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, format, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A354A8]) = v40;\nL_0019:\n\tgoto L_001C;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, format, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_001C:\n\tv48 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2::InternalDecrypt(this);\n\treturnVal1 = 0xBEE74C(&v48 @ V0_v1 (UnityEngine.Vector2), format, 0, 0, v26, v27, v28, v29, v48, v48.y, v32, v33, v34, v35, v36, v37);\n\treturn returnVal1;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string ToString(string format)
		{
			Vector2 vector = InternalDecrypt();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @BEE74C (inside CodeStage.AntiCheat.Genuine.CodeHash.AndroidWorker+CodeHashGeneratorCallback::OnError +0x238)");
			string result = default(string);
			return result;
		}

		[Obsolete("This API is redundant and does not perform any actions. It will be removed in future updates.")]
		[Token(Token = "0x60002B2")]
		[Address(RVA = "0xBE3E30", Offset = "0xBE3E30", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public static void SetNewCryptoKey(int newKey)
		{
		}

		[Obsolete("This API is redundant and does not perform any actions. It will be removed in future updates.")]
		[Token(Token = "0x60002B3")]
		[Address(RVA = "0xBE3E34", Offset = "0xBE3E34", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void ApplyNewCryptoKey()
		{
		}

		[Obsolete("Please use new Encrypt(value, key) API instead.", true)]
		[Token(Token = "0x60002B4")]
		[Address(RVA = "0xBE3E38", Offset = "0xBE3E38", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static RawEncryptedVector2 Encrypt(Vector2 value)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new Decrypt(value, key) API instead.", true)]
		[Token(Token = "0x60002B5")]
		[Address(RVA = "0xBE3E70", Offset = "0xBE3E70", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector2 Decrypt(RawEncryptedVector2 value)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new GetEncrypted(out key) API instead.", true)]
		[Token(Token = "0x60002B6")]
		[Address(RVA = "0xBE3EA8", Offset = "0xBE3EA8", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RawEncryptedVector2 GetEncrypted()
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new SetEncrypted(encrypted, key) API instead.", true)]
		[Token(Token = "0x60002B7")]
		[Address(RVA = "0xBE3EE0", Offset = "0xBE3EE0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetEncrypted(RawEncryptedVector2 encrypted)
		{
		}
	}
}
