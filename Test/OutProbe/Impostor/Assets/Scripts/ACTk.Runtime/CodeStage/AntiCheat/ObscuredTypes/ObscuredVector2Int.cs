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
	[Token(Token = "0x2000024")]
	public struct ObscuredVector2Int : IObscuredType
	{
		[Serializable]
		[Token(Token = "0x2000025")]
		public struct RawEncryptedVector2Int
		{
			[Token(Token = "0x40000BA")]
			[FieldOffset(Offset = "0x0")]
			public int x;

			[Token(Token = "0x40000BB")]
			[FieldOffset(Offset = "0x4")]
			public int y;
		}

		[Token(Token = "0x40000B4")]
		private static readonly Vector2Int Zero = Vector2Int.s_Zero;

		[SerializeField]
		[Token(Token = "0x40000B5")]
		[FieldOffset(Offset = "0x0")]
		private int currentCryptoKey;

		[SerializeField]
		[Token(Token = "0x40000B6")]
		[FieldOffset(Offset = "0x4")]
		private RawEncryptedVector2Int hiddenValue;

		[SerializeField]
		[Token(Token = "0x40000B7")]
		[FieldOffset(Offset = "0xC")]
		private bool inited;

		[SerializeField]
		[Token(Token = "0x40000B8")]
		[FieldOffset(Offset = "0x10")]
		private Vector2Int fakeValue;

		[SerializeField]
		[Token(Token = "0x40000B9")]
		[FieldOffset(Offset = "0x18")]
		private bool fakeValueActive;

		[Token(Token = "0x1700000F")]
		public int x
		{
			[Token(Token = "0x60002BB")]
			[Address(RVA = "0xBE415C", Offset = "0xBE415C", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = System.Math;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A354AC]) = v34;\nL_0016:\n\tv38 = this.currentCryptoKey ^ this.hiddenValue;\n\tv39 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv43 = v39 == 0;\n\tif (v43) goto L_0050;\n\tv45 = ~this.fakeValueActive;\n\tif (v45) goto L_0050;\n\tgoto L_002B;\n\tv111 = \"il2cpp_codegen_runtime_class_init\"(v91, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_002B:\n\tv63 = v38 == this.fakeValue;\n\tif (v63) goto L_0050;\n\tgoto L_0041;\n\tv121 = 0xB348B0(v116, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0041:\n\tgoto L_004A;\n\tv129 = 0xB348B0(v124, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_004A:\n\tv75 = CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector>::OnCheatingDetected(v109.<Instance>k__BackingField);\nL_0050:\n\treturn v38;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0068: Unknown result type (might be due to invalid IL or missing references)
				//IL_006d: Expected I4, but got Unknown
				int num = currentCryptoKey ^ hiddenValue;
				if (ObscuredCheatingDetector.ExistsAndIsRunning && fakeValueActive && num != (nint)fakeValue)
				{
					KeepAliveBehaviour<ObscuredCheatingDetector>.Instance.OnCheatingDetected();
				}
				return num;
			}
			[Token(Token = "0x60002BC")]
			[Address(RVA = "0xBE4230", Offset = "0xBE4230", Length = "0x54")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.currentCryptoKey ^ value;\n\tthis.hiddenValue = v11;\n\tv13 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv15 = v13 == 0;\n\tif (v15) goto L_FFFFFFFF;\n\tv18 = this.currentCryptoKey ^ *([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int)+8]);\n\tthis.fakeValue = value;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int)+14]) = v18;\n\tgoto L_0016;\nL_0016:\n\tthis.fakeValueActive = v23;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0019: Expected O, but got I4
				//IL_0060: Expected O, but got I4
				int num = currentCryptoKey ^ value;
				hiddenValue = (RawEncryptedVector2Int)num;
				bool flag;
				if (ObscuredCheatingDetector.ExistsAndIsRunning)
				{
					int num2 = currentCryptoKey;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int)+8]");
					int num3 = (int)((nint)num2 ^ (nint)0);
					fakeValue = (Vector2Int)value;
					flag = true;
				}
				else
				{
					flag = false;
				}
				fakeValueActive = flag;
			}
		}

		[Token(Token = "0x17000010")]
		public int y
		{
			[Token(Token = "0x60002BD")]
			[Address(RVA = "0xBE4284", Offset = "0xBE4284", Length = "0xD8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = System.Math;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A354AD]) = v34;\nL_0016:\n\tv38 = this.currentCryptoKey ^ *([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int)+8]);\n\tv39 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv43 = v39 == 0;\n\tif (v43) goto L_0050;\n\tv45 = ~this.fakeValueActive;\n\tif (v45) goto L_0050;\n\tgoto L_002B;\n\tv111 = \"il2cpp_codegen_runtime_class_init\"(v91, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_002B:\n\tv63 = v38 == *([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int)+14]);\n\tif (v63) goto L_0050;\n\tgoto L_0041;\n\tv121 = 0xB348B0(v116, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0041:\n\tgoto L_004A;\n\tv129 = 0xB348B0(v124, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_004A:\n\tv75 = CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector>::OnCheatingDetected(v109.<Instance>k__BackingField);\nL_0050:\n\treturn v38;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				int num = currentCryptoKey;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int)+8]");
				int num2 = (int)((nint)num ^ (nint)0);
				if (ObscuredCheatingDetector.ExistsAndIsRunning && fakeValueActive)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int)+14]");
					if ((nint)num2 != 0)
					{
						KeepAliveBehaviour<ObscuredCheatingDetector>.Instance.OnCheatingDetected();
					}
				}
				return num2;
			}
			[Token(Token = "0x60002BE")]
			[Address(RVA = "0xBE435C", Offset = "0xBE435C", Length = "0x50")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.currentCryptoKey ^ value;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int)+8]) = v11;\n\tv13 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv15 = v13 == 0;\n\tif (v15) goto L_FFFFFFFF;\n\tv18 = this.currentCryptoKey ^ this.hiddenValue;\n\tthis.fakeValue = v18;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int)+14]) = value;\n\tgoto L_0016;\nL_0016:\n\tthis.fakeValueActive = v23;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0046: Unknown result type (might be due to invalid IL or missing references)
				//IL_004b: Expected I4, but got Unknown
				//IL_0055: Expected O, but got I4
				int num = currentCryptoKey ^ value;
				bool flag;
				if (ObscuredCheatingDetector.ExistsAndIsRunning)
				{
					int num2 = currentCryptoKey ^ hiddenValue;
					fakeValue = (Vector2Int)num2;
					flag = true;
				}
				else
				{
					flag = false;
				}
				fakeValueActive = flag;
			}
		}

		[Token(Token = "0x17000011")]
		public int this[int index]
		{
			[Token(Token = "0x60002BF")]
			[Address(RVA = "0xBE43AC", Offset = "0xBE43AC", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, index, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A354AE]) = v36;\nL_0016:\n\tv41 = index == 1;\n\tif (v41) goto L_0035;\n\tv46 = index == 0;\n\tv47 = ~v46;\n\tif (v47) goto L_0042;\n\tgoto L_002D;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v56, index, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_002D:\n\treturnVal2 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int::get_x(this);\n\treturn returnVal2;\nL_0035:\n\tgoto L_003D;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v50, index, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_003D:\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int::get_y(this);\n\treturn returnVal1;\nL_0042:\n\tv79 = new System.IndexOutOfRangeException();\n\tSystem.IndexOutOfRangeException::.ctor(v79, \"Invalid ObscuredVector2Int index!\");\n\tthrow v79;\n\treturn returnVal3;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
					IndexOutOfRangeException ex = new IndexOutOfRangeException("Invalid ObscuredVector2Int index!");
					throw ex;
				}
				}
			}
			[Token(Token = "0x60002C0")]
			[Address(RVA = "0xBE4480", Offset = "0xBE4480", Length = "0x12C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, index, value, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A354AF]) = v39;\nL_0018:\n\tv44 = index == 1;\n\tif (v44) goto L_003D;\n\tv49 = index == 0;\n\tv50 = ~v49;\n\tif (v50) goto L_005A;\n\tgoto L_002B;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v59, index, value, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_002B:\n\tv76 = this.currentCryptoKey ^ value;\n\tthis.hiddenValue = v76;\n\tv77 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv82 = v77 == 0;\n\tif (v82) goto L_FFFFFFFF;\n\tv96 = this.currentCryptoKey ^ *([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int)+8]);\n\tthis.fakeValue = value;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int)+14]) = v96;\n\tgoto L_FFFFFFFF;\nL_003D:\n\tgoto L_0041;\n\tv66 = \"il2cpp_codegen_runtime_class_init\"(v53, index, value, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0041:\n\tv70 = this.currentCryptoKey ^ value;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int)+8]) = v70;\n\tv71 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv80 = v71 == 0;\n\tif (v80) goto L_FFFFFFFF;\n\tv89 = this.currentCryptoKey ^ this.hiddenValue;\n\tthis.fakeValue = v89;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int)+14]) = value;\n\tgoto L_004F;\nL_004F:\n\tthis.fakeValueActive = v109;\n\treturn;\nL_005A:\n\tv78 = new System.IndexOutOfRangeException();\n\tSystem.IndexOutOfRangeException::.ctor(v78, \"Invalid ObscuredVector2Int index!\");\n\tthrow v78;\n\treturn;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ec: Expected I4, but got Unknown
				//IL_00f6: Expected O, but got I4
				//IL_004b: Expected O, but got I4
				//IL_0092: Expected O, but got I4
				if (index != 1)
				{
					if (index != 0)
					{
						IndexOutOfRangeException ex = new IndexOutOfRangeException("Invalid ObscuredVector2Int index!");
						throw ex;
					}
					int num = currentCryptoKey ^ value;
					hiddenValue = (RawEncryptedVector2Int)num;
					if (!ObscuredCheatingDetector.ExistsAndIsRunning)
					{
						goto IL_0100;
					}
					int num2 = currentCryptoKey;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int)+8]");
					int num3 = (int)((nint)num2 ^ (nint)0);
					fakeValue = (Vector2Int)value;
				}
				else
				{
					int num4 = currentCryptoKey ^ value;
					if (!ObscuredCheatingDetector.ExistsAndIsRunning)
					{
						goto IL_0100;
					}
					int num5 = currentCryptoKey ^ hiddenValue;
					fakeValue = (Vector2Int)num5;
				}
				bool flag = true;
				goto IL_0157;
				IL_0100:
				flag = false;
				goto IL_0157;
				IL_0157:
				fakeValueActive = flag;
			}
		}

		[Token(Token = "0x60002B9")]
		[Address(RVA = "0xBE3F60", Offset = "0xBE3F60", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, value, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A354AA]) = v40;\nL_0019:\n\tgoto L_001B;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, value, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_001B:\n\tv47 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tthis.currentCryptoKey = v47;\n\tv50 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int::Encrypt(value, v47);\n\tthis.hiddenValue = v50;\n\tv52 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tgoto L_0033;\n\tv57 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int;\n\tv58 = *([v57 @ X0_v10+E0]);\n\tv59 = v58 == 0;\n\tv60 = ~v59;\n\tif (v60) goto L_FFFFFFFF;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v57, v48, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv76 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int;\n\tv67 = *([v62 @ X0_v11+B8]);\n\tv65 = *([v67 @ X8_v7]);\nL_0033:\n\tthis.fakeValue = value;\n\tthis.fakeValueActive = v52;\n\tthis.inited = 1;\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private ObscuredVector2Int(Vector2Int value)
		{
			RawEncryptedVector2Int rawEncryptedVector2Int = Encrypt(value, currentCryptoKey = RandomUtils.GenerateIntKey());
			hiddenValue = rawEncryptedVector2Int;
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			fakeValue = value;
			fakeValueActive = existsAndIsRunning;
			inited = true;
		}

		[Token(Token = "0x60002BA")]
		[Address(RVA = "0xBE4084", Offset = "0xBE4084", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, x, y, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 1;\n\t*([1A354AB]) = v43;\nL_001B:\n\tgoto L_001D;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v44, x, y, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_001D:\n\tv50 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tv51 = v50 ^ x;\n\tv52 = v50 ^ y;\n\tthis.currentCryptoKey = v50;\n\tv53 = v52 & 0xFFFFFFFF;\n\tv54 = v53 << 0x20;\n\tv55 = v51 & 0xFFFFFFFF;\n\tv56 = v55 | v54;\n\tthis.hiddenValue = v56;\n\tv58 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv60 = v58 == 0;\n\tif (v60) goto L_0037;\n\tv62 = y & 0xFFFFFFFF;\n\tv63 = v62 << 0x20;\n\tv64 = x & 0xFFFFFFFF;\n\tv65 = v64 | v63;\n\tthis.fakeValue = v65;\n\tgoto L_003E;\nL_0037:\n\tgoto L_003D;\n\tv85 = \"il2cpp_codegen_runtime_class_init\"(v67, x, y, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv86 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int;\nL_003D:\n\tthis.fakeValue = v87.Zero;\nL_003E:\n\tthis.fakeValueActive = v76;\n\tthis.inited = 1;\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObscuredVector2Int(int x, int y)
		{
			//IL_0044: Expected I4, but got I8
			//IL_0064: Expected I4, but got I8
			//IL_007b: Expected O, but got I4
			//IL_00b8: Expected I4, but got I8
			//IL_00d8: Expected I4, but got I8
			//IL_00ef: Expected O, but got I4
			int num = RandomUtils.GenerateIntKey();
			int num2 = num ^ x;
			int num3 = num ^ y;
			currentCryptoKey = num;
			int num4 = (int)(num3 & 0xFFFFFFFFL);
			int num5 = num4 << 32;
			int num6 = (int)(num2 & 0xFFFFFFFFL);
			int num7 = num6 | num5;
			hiddenValue = (RawEncryptedVector2Int)num7;
			bool flag;
			if (ObscuredCheatingDetector.ExistsAndIsRunning)
			{
				int num8 = (int)(y & 0xFFFFFFFFL);
				int num9 = num8 << 32;
				int num10 = (int)(x & 0xFFFFFFFFL);
				int num11 = num10 | num9;
				fakeValue = (Vector2Int)num11;
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

		[Token(Token = "0x60002C1")]
		[Address(RVA = "0xBE4018", Offset = "0xBE4018", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, key, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A354B0]) = v40;\nL_0019:\n\tgoto L_001B;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, key, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_001B:\n\tv47 = value >> 0x20;\n\tv48 = value ^ key;\n\tv49 = v47 ^ key;\n\tv54 = v49 & 0xFFFFFFFF;\n\tv55 = v54 << 0x20;\n\tv56 = v48 & 0xFFFFFFFF;\n\treturnVal1 = v56 | v55;\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static RawEncryptedVector2Int Encrypt(Vector2Int value, int key)
		{
			//IL_0013: Expected I4, but got O
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Expected I4, but got Unknown
			//IL_003f: Expected I4, but got I8
			//IL_005f: Expected I4, but got I8
			//IL_006c: Expected O, but got I4
			int num = (object)value >> 32;
			int num2 = value ^ key;
			int num3 = num ^ key;
			int num4 = (int)(num3 & 0xFFFFFFFFL);
			int num5 = num4 << 32;
			int num6 = (int)(num2 & 0xFFFFFFFFL);
			return (RawEncryptedVector2Int)(num6 | num5);
		}

		[Token(Token = "0x60002C2")]
		[Address(RVA = "0xBE414C", Offset = "0xBE414C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = key ^ x;\n\tv3 = key ^ y;\n\tv5 = v3 & 0xFFFFFFFF;\n\tv6 = v5 << 0x20;\n\tv7 = v0 & 0xFFFFFFFF;\n\treturnVal1 = v7 | v6;\n\treturn returnVal1;\n")]
		public static RawEncryptedVector2Int Encrypt(int x, int y, int key)
		{
			//IL_002c: Expected I4, but got I8
			//IL_004c: Expected I4, but got I8
			//IL_0059: Expected O, but got I4
			int num = key ^ x;
			int num2 = key ^ y;
			int num3 = (int)(num2 & 0xFFFFFFFFL);
			int num4 = num3 << 32;
			int num5 = (int)(num & 0xFFFFFFFFL);
			return (RawEncryptedVector2Int)(num5 | num4);
		}

		[Token(Token = "0x60002C3")]
		[Address(RVA = "0xBE45AC", Offset = "0xBE45AC", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = value >> 0x20;\n\tv2 = value ^ key;\n\tv4 = v0 ^ key;\n\tv5 = v4 & 0xFFFFFFFF;\n\tv6 = v5 << 0x20;\n\tv7 = v2 & 0xFFFFFFFF;\n\treturnVal1 = v7 | v6;\n\treturn returnVal1;\n")]
		public static Vector2Int Decrypt(RawEncryptedVector2Int value, int key)
		{
			//IL_000e: Expected I4, but got O
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Expected I4, but got Unknown
			//IL_003a: Expected I4, but got I8
			//IL_005a: Expected I4, but got I8
			//IL_0067: Expected O, but got I4
			int num = (object)value >> 32;
			int num2 = value ^ key;
			int num3 = num ^ key;
			int num4 = (int)(num3 & 0xFFFFFFFFL);
			int num5 = num4 << 32;
			int num6 = (int)(num2 & 0xFFFFFFFFL);
			return (Vector2Int)(num6 | num5);
		}

		[Token(Token = "0x60002C4")]
		[Address(RVA = "0xBE45C0", Offset = "0xBE45C0", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv26 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, key, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 1;\n\t*([1A354B1]) = v44;\nL_001F:\n\tgoto L_0024;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, key, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0024:\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int::SetEncrypted(&v56 @ stack_-50_v2 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int), encrypted, key);\n\treturnBuffer.inited = v60;\n\treturnBuffer.currentCryptoKey = v56;\n\treturn &v56 @ stack_-50_v2 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int);\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredVector2Int FromEncrypted(RawEncryptedVector2Int encrypted, int key)
		{
			//IL_0023: Expected I4, but got O
			//IL_001e: Expected native int or pointer, but got O
			//IL_0030: Expected I4, but got O
			//IL_002b: Expected native int or pointer, but got O
			//IL_0035: Expected O, but got Ref
			ObscuredVector2Int obscuredVector2Int = default(ObscuredVector2Int);
			obscuredVector2Int.SetEncrypted(encrypted, key);
			ObscuredVector2Int obscuredVector2Int2 = default(ObscuredVector2Int);
			object obj = default(object);
			((ObscuredVector2Int*)(nint)obscuredVector2Int2)->inited = (byte)(int)obj != 0;
			((ObscuredVector2Int*)(nint)obscuredVector2Int2)->currentCryptoKey = (int)obscuredVector2Int;
			return (ObscuredVector2Int)(&obscuredVector2Int);
		}

		[Token(Token = "0x60002C5")]
		[Address(RVA = "0xBE4014", Offset = "0xBE4014", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\treturn returnVal1;\n")]
		public static int GenerateKey()
		{
			return RandomUtils.GenerateIntKey();
		}

		[Token(Token = "0x60002C6")]
		[Address(RVA = "0xBE46E8", Offset = "0xBE46E8", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([key @ X1 (System.Int32&)]) = this.currentCryptoKey;\n\treturn this.hiddenValue;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe RawEncryptedVector2Int GetEncrypted(out int key)
		{
			key = default(int);
			ref int reference = ref *(int*)currentCryptoKey;
			return hiddenValue;
		}

		[Token(Token = "0x60002C7")]
		[Address(RVA = "0xBE4654", Offset = "0xBE4654", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, encrypted, key, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A354B2]) = v39;\nL_0016:\n\tthis.hiddenValue = encrypted;\n\tthis.inited = 1;\n\tthis.currentCryptoKey = key;\n\tv42 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tthis.fakeValueActive = 0;\n\tv44 = v42 == 0;\n\tif (v44) goto L_0031;\n\tgoto L_0027;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v47, encrypted, key, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0027:\n\tv52 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int::InternalDecrypt(this);\n\tthis.fakeValue = v52;\n\tthis.fakeValueActive = 1;\nL_0031:\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetEncrypted(RawEncryptedVector2Int encrypted, int key)
		{
			hiddenValue = encrypted;
			inited = true;
			currentCryptoKey = key;
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			fakeValueActive = false;
			if (existsAndIsRunning)
			{
				Vector2Int vector2Int = InternalDecrypt();
				fakeValue = vector2Int;
				fakeValueActive = true;
			}
		}

		[Token(Token = "0x60002C8")]
		[Address(RVA = "0xBE4854", Offset = "0xBE4854", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A354B3]) = v37;\nL_0017:\n\tgoto L_001F;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001F:\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int::InternalDecrypt(this);\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Vector2Int GetDecrypted()
		{
			return InternalDecrypt();
		}

		[Token(Token = "0x60002C9")]
		[Address(RVA = "0xBE48A8", Offset = "0xBE48A8", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A354B4]) = v37;\nL_0017:\n\tgoto L_001A;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001A:\n\tv45 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int::InternalDecrypt(this);\n\tv47 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tthis.currentCryptoKey = v47;\n\tv50 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int::Encrypt(v45, v47);\n\tthis.hiddenValue = v50;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RandomizeCryptoKey()
		{
			Vector2Int value = InternalDecrypt();
			RawEncryptedVector2Int rawEncryptedVector2Int = Encrypt(value, currentCryptoKey = RandomUtils.GenerateIntKey());
			hiddenValue = rawEncryptedVector2Int;
		}

		[Token(Token = "0x60002CA")]
		[Address(RVA = "0xBE46F8", Offset = "0xBE46F8", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv44 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A354B5]) = v38;\nL_0018:\n\tv42 = ~this.inited;\n\tif (v42) goto L_0068;\n\tgoto L_0022;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0022:\n\tv57 = this.hiddenValue >> 0x20;\n\tv58 = this.currentCryptoKey ^ this.hiddenValue;\n\tv59 = this.currentCryptoKey ^ v57;\n\tv62 = v59 & 0xFFFFFFFF;\n\tv63 = v62 << 0x20;\n\tv64 = v58 & 0xFFFFFFFF;\n\tv133 = v64 | v63;\n\tv66 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv71 = v66 == 0;\n\tif (v71) goto L_0082;\n\tv78 = ~this.fakeValueActive;\n\tif (v78) goto L_0082;\n\tv90 = v58 != this.fakeValue;\n\tif (v90) goto L_0051;\n\tv109 = v59 == *([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int)+14]);\n\tif (v109) goto L_0082;\nL_0051:\n\tgoto L_0059;\n\tv185 = 0xB348B0(v180, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0059:\n\tgoto L_0062;\n\tv193 = 0xB348B0(v188, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0062:\n\tv126 = CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector>::OnCheatingDetected(v173.<Instance>k__BackingField);\n\tgoto L_0082;\nL_0068:\n\tgoto L_006A;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v51, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_006A:\n\tv69 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tthis.currentCryptoKey = v69;\n\tv76 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int::Encrypt(v74.Zero, v69);\n\tthis.hiddenValue = v76;\n\tthis.fakeValueActive = 0;\n\tthis.inited = 1;\n\tthis.fakeValue = v142.Zero;\nL_0082:\n\treturn v133;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 88 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private Vector2Int InternalDecrypt()
		{
			//IL_017b: Expected I4, but got O
			//IL_001a: Expected I4, but got O
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Expected I4, but got Unknown
			//IL_004c: Expected I4, but got I8
			//IL_006c: Expected I4, but got I8
			//IL_01a0: Expected O, but got I4
			int num7;
			if (inited)
			{
				int num = (object)hiddenValue >> 32;
				int num2 = currentCryptoKey ^ hiddenValue;
				int num3 = currentCryptoKey ^ num;
				int num4 = (int)(num3 & 0xFFFFFFFFL);
				int num5 = num4 << 32;
				int num6 = (int)(num2 & 0xFFFFFFFFL);
				num7 = num6 | num5;
				if (ObscuredCheatingDetector.ExistsAndIsRunning && fakeValueActive)
				{
					if (num2 == (nint)fakeValue)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int)+14]");
						if ((nint)num3 == 0)
						{
							goto IL_019b;
						}
					}
					KeepAliveBehaviour<ObscuredCheatingDetector>.Instance.OnCheatingDetected();
				}
			}
			else
			{
				RawEncryptedVector2Int rawEncryptedVector2Int = Encrypt(key: currentCryptoKey = RandomUtils.GenerateIntKey(), value: Zero);
				hiddenValue = rawEncryptedVector2Int;
				fakeValueActive = false;
				inited = true;
				fakeValue = Zero;
				num7 = (int)Zero;
			}
			goto IL_019b;
			IL_019b:
			return (Vector2Int)num7;
		}

		[Token(Token = "0x60002CB")]
		[Address(RVA = "0xBE491C", Offset = "0xBE491C", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnBuffer.currentCryptoKey = 0;\n\t*([returnBuffer @ X8 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int)+8]) = 0;\n\treturnBuffer.fakeValueActive = 0;\n\treturnBuffer.fakeValue = 0;\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int::.ctor(returnBuffer, value);\n\treturn returnBuffer;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static implicit operator ObscuredVector2Int(Vector2Int value)
		{
			//IL_0009: Expected native int or pointer, but got O
			//IL_001d: Expected native int or pointer, but got O
			//IL_0034: Expected native int or pointer, but got O
			//IL_0041: Expected native int or pointer, but got O
			ObscuredVector2Int obscuredVector2Int = default(ObscuredVector2Int);
			((ObscuredVector2Int*)(nint)obscuredVector2Int)->currentCryptoKey = 0;
			_ = 0;
			((ObscuredVector2Int*)(nint)obscuredVector2Int)->fakeValueActive = false;
			((ObscuredVector2Int*)(nint)obscuredVector2Int)->fakeValue = default(Vector2Int);
			*(ObscuredVector2Int*)(nint)obscuredVector2Int = new ObscuredVector2Int(value);
			return obscuredVector2Int;
		}

		[Token(Token = "0x60002CC")]
		[Address(RVA = "0xBE4934", Offset = "0xBE4934", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A354B6]) = v37;\nL_0017:\n\tgoto L_001F;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001F:\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int::InternalDecrypt(value);\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static implicit operator Vector2Int(ObscuredVector2Int value)
		{
			return ((ObscuredVector2Int*)value)->InternalDecrypt();
		}

		[Token(Token = "0x60002CD")]
		[Address(RVA = "0xBE4988", Offset = "0xBE4988", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A354B7]) = v37;\nL_0017:\n\tgoto L_001A;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001A:\n\tv45 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int::InternalDecrypt(value);\n\treturn v45;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static implicit operator Vector2(ObscuredVector2Int value)
		{
			return ((ObscuredVector2Int*)value)->InternalDecrypt();
		}

		[Token(Token = "0x60002CE")]
		[Address(RVA = "0xBE49EC", Offset = "0xBE49EC", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A354B8]) = v37;\nL_0017:\n\tgoto L_001A;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001A:\n\tv45 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int::InternalDecrypt(this);\n\tv46 = v45 >> 0x20;\n\tv50 = System.Int32::GetHashCode(&v45 @ X0_v5 (UnityEngine.Vector2Int));\n\tv55 = System.Int32::GetHashCode(&v46 @ X20_v2 (System.Int32));\n\treturnVal1 = v50 ^ v55;\n\treturn returnVal1;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override int GetHashCode()
		{
			//IL_001d: Expected I4, but got O
			Vector2Int vector2Int = InternalDecrypt();
			int num = (object)vector2Int >> 32;
			int hashCode = ((int*)(&vector2Int))->GetHashCode();
			int hashCode2 = num.GetHashCode();
			return hashCode ^ hashCode2;
		}

		[Token(Token = "0x60002CF")]
		[Address(RVA = "0xBE4A78", Offset = "0xBE4A78", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A354B9]) = v37;\nL_0017:\n\tgoto L_001A;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001A:\n\tv45 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector2Int::InternalDecrypt(this);\n\treturnVal1 = 0xBEE8D4(&v45 @ X0_v5 (UnityEngine.Vector2Int), 0, 0, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\treturn returnVal1;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			Vector2Int vector2Int = InternalDecrypt();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BEE8D4 (inside CodeStage.AntiCheat.Genuine.CodeHash.AndroidWorker+CodeHashGeneratorCallback::OnError +0x3C0)");
			string result = default(string);
			return result;
		}

		[Obsolete("This API is redundant and does not perform any actions. It will be removed in future updates.")]
		[Token(Token = "0x60002D0")]
		[Address(RVA = "0xBE4AF0", Offset = "0xBE4AF0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public static void SetNewCryptoKey(int newKey)
		{
		}

		[Obsolete("This API is redundant and does not perform any actions. It will be removed in future updates.")]
		[Token(Token = "0x60002D1")]
		[Address(RVA = "0xBE4AF4", Offset = "0xBE4AF4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void ApplyNewCryptoKey()
		{
		}

		[Obsolete("Please use new Encrypt(value, key) API instead.", true)]
		[Token(Token = "0x60002D2")]
		[Address(RVA = "0xBE4AF8", Offset = "0xBE4AF8", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static RawEncryptedVector2Int Encrypt(Vector2Int value)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new Decrypt(value, key) API instead.", true)]
		[Token(Token = "0x60002D3")]
		[Address(RVA = "0xBE4B30", Offset = "0xBE4B30", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector2Int Decrypt(RawEncryptedVector2Int value)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new GetEncrypted(out key) API instead.", true)]
		[Token(Token = "0x60002D4")]
		[Address(RVA = "0xBE4B68", Offset = "0xBE4B68", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RawEncryptedVector2Int GetEncrypted()
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new SetEncrypted(encrypted, key) API instead.", true)]
		[Token(Token = "0x60002D5")]
		[Address(RVA = "0xBE4BA0", Offset = "0xBE4BA0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetEncrypted(RawEncryptedVector2Int encrypted)
		{
		}
	}
}
