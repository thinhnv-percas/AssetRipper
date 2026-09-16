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
	[Token(Token = "0x2000028")]
	public struct ObscuredVector3Int : IObscuredType
	{
		[Serializable]
		[Token(Token = "0x2000029")]
		public struct RawEncryptedVector3Int
		{
			[Token(Token = "0x40000CB")]
			[FieldOffset(Offset = "0x0")]
			public int x;

			[Token(Token = "0x40000CC")]
			[FieldOffset(Offset = "0x4")]
			public int y;

			[Token(Token = "0x40000CD")]
			[FieldOffset(Offset = "0x8")]
			public int z;
		}

		[Token(Token = "0x40000C5")]
		private static readonly Vector3Int Zero;

		[SerializeField]
		[Token(Token = "0x40000C6")]
		[FieldOffset(Offset = "0x0")]
		private int currentCryptoKey;

		[SerializeField]
		[Token(Token = "0x40000C7")]
		[FieldOffset(Offset = "0x4")]
		private RawEncryptedVector3Int hiddenValue;

		[SerializeField]
		[Token(Token = "0x40000C8")]
		[FieldOffset(Offset = "0x10")]
		private bool inited;

		[SerializeField]
		[Token(Token = "0x40000C9")]
		[FieldOffset(Offset = "0x14")]
		private Vector3Int fakeValue;

		[SerializeField]
		[Token(Token = "0x40000CA")]
		[FieldOffset(Offset = "0x20")]
		private bool fakeValueActive;

		[Token(Token = "0x17000016")]
		public int x
		{
			[Token(Token = "0x600030B")]
			[Address(RVA = "0xBE6DE4", Offset = "0xBE6DE4", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = System.Math;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A354E1]) = v34;\nL_0016:\n\tv38 = this.currentCryptoKey ^ this.hiddenValue;\n\tv39 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv43 = v39 == 0;\n\tif (v43) goto L_0050;\n\tv45 = ~this.fakeValueActive;\n\tif (v45) goto L_0050;\n\tgoto L_002B;\n\tv111 = \"il2cpp_codegen_runtime_class_init\"(v91, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_002B:\n\tv63 = v38 == this.fakeValue;\n\tif (v63) goto L_0050;\n\tgoto L_0041;\n\tv121 = 0xB348B0(v116, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0041:\n\tgoto L_004A;\n\tv129 = 0xB348B0(v124, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_004A:\n\tv75 = CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector>::OnCheatingDetected(v109.<Instance>k__BackingField);\nL_0050:\n\treturn v38;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			[Token(Token = "0x600030C")]
			[Address(RVA = "0xBE6EB8", Offset = "0xBE6EB8", Length = "0x58")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.currentCryptoKey ^ value;\n\tthis.hiddenValue = v11;\n\tv13 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv15 = v13 == 0;\n\tif (v15) goto L_FFFFFFFF;\n\tthis.fakeValue = value;\n\t// 16 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv18 = v19 ^ *([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int)+8]);\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int)+18]) = v18;\n\tgoto L_0016;\nL_0016:\n\tthis.fakeValueActive = v23;\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0019: Expected O, but got I4
				//IL_0049: Expected O, but got I4
				int num = currentCryptoKey ^ value;
				hiddenValue = (RawEncryptedVector3Int)num;
				bool flag;
				if (ObscuredCheatingDetector.ExistsAndIsRunning)
				{
					fakeValue = (Vector3Int)value;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
					object obj = default(object);
					nint num2 = (nint)obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int)+8]");
					int num3 = (int)(num2 ^ 0);
					flag = true;
				}
				else
				{
					flag = false;
				}
				fakeValueActive = flag;
			}
		}

		[Token(Token = "0x17000017")]
		public int y
		{
			[Token(Token = "0x600030D")]
			[Address(RVA = "0xBE6F10", Offset = "0xBE6F10", Length = "0xD8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = System.Math;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A354E2]) = v34;\nL_0016:\n\tv38 = this.currentCryptoKey ^ *([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int)+8]);\n\tv39 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv43 = v39 == 0;\n\tif (v43) goto L_0050;\n\tv45 = ~this.fakeValueActive;\n\tif (v45) goto L_0050;\n\tgoto L_002B;\n\tv111 = \"il2cpp_codegen_runtime_class_init\"(v91, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_002B:\n\tv63 = v38 == *([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int)+18]);\n\tif (v63) goto L_0050;\n\tgoto L_0041;\n\tv121 = 0xB348B0(v116, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0041:\n\tgoto L_004A;\n\tv129 = 0xB348B0(v124, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_004A:\n\tv75 = CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector>::OnCheatingDetected(v109.<Instance>k__BackingField);\nL_0050:\n\treturn v38;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				int num = currentCryptoKey;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int)+8]");
				int num2 = (int)((nint)num ^ (nint)0);
				if (ObscuredCheatingDetector.ExistsAndIsRunning && fakeValueActive)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int)+18]");
					if ((nint)num2 != 0)
					{
						KeepAliveBehaviour<ObscuredCheatingDetector>.Instance.OnCheatingDetected();
					}
				}
				return num2;
			}
			[Token(Token = "0x600030E")]
			[Address(RVA = "0xBE6FE8", Offset = "0xBE6FE8", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.currentCryptoKey ^ value;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int)+8]) = v11;\n\tv13 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv15 = v13 == 0;\n\tif (v15) goto L_FFFFFFFF;\n\tv19 = this.currentCryptoKey ^ this.hiddenValue;\n\tv20 = *([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int)+C]) ^ this.currentCryptoKey;\n\tthis.fakeValue = v19;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int)+18]) = value;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int)+1C]) = v20;\n\tgoto L_0019;\nL_0019:\n\tthis.fakeValueActive = v27;\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0046: Unknown result type (might be due to invalid IL or missing references)
				//IL_004b: Expected I4, but got Unknown
				//IL_006c: Expected O, but got I4
				int num = currentCryptoKey ^ value;
				bool flag;
				if (ObscuredCheatingDetector.ExistsAndIsRunning)
				{
					int num2 = currentCryptoKey ^ hiddenValue;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int)+C]");
					int num3 = (int)((nint)0 ^ (nint)currentCryptoKey);
					fakeValue = (Vector3Int)num2;
					flag = true;
				}
				else
				{
					flag = false;
				}
				fakeValueActive = flag;
			}
		}

		[Token(Token = "0x17000018")]
		public int z
		{
			[Token(Token = "0x600030F")]
			[Address(RVA = "0xBE7044", Offset = "0xBE7044", Length = "0xD8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = System.Math;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A354E3]) = v34;\nL_0016:\n\tv38 = this.currentCryptoKey ^ *([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int)+C]);\n\tv39 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv43 = v39 == 0;\n\tif (v43) goto L_0050;\n\tv45 = ~this.fakeValueActive;\n\tif (v45) goto L_0050;\n\tgoto L_002B;\n\tv111 = \"il2cpp_codegen_runtime_class_init\"(v91, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_002B:\n\tv63 = v38 == *([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int)+1C]);\n\tif (v63) goto L_0050;\n\tgoto L_0041;\n\tv121 = 0xB348B0(v116, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0041:\n\tgoto L_004A;\n\tv129 = 0xB348B0(v124, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_004A:\n\tv75 = CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector>::OnCheatingDetected(v109.<Instance>k__BackingField);\nL_0050:\n\treturn v38;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				int num = currentCryptoKey;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int)+C]");
				int num2 = (int)((nint)num ^ (nint)0);
				if (ObscuredCheatingDetector.ExistsAndIsRunning && fakeValueActive)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int)+1C]");
					if ((nint)num2 != 0)
					{
						KeepAliveBehaviour<ObscuredCheatingDetector>.Instance.OnCheatingDetected();
					}
				}
				return num2;
			}
			[Token(Token = "0x6000310")]
			[Address(RVA = "0xBE711C", Offset = "0xBE711C", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.currentCryptoKey ^ value;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int)+C]) = v11;\n\tv13 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv15 = v13 == 0;\n\tif (v15) goto L_FFFFFFFF;\n\t// 15 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int)+1C]) = value;\n\tv19 = v20 ^ this.currentCryptoKey;\n\tthis.fakeValue = v19;\n\tgoto L_0017;\nL_0017:\n\tthis.fakeValueActive = v25;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0063: Expected O, but got I4
				int num = currentCryptoKey ^ value;
				bool flag;
				if (ObscuredCheatingDetector.ExistsAndIsRunning)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
					object obj = default(object);
					int num2 = (int)((nint)obj ^ currentCryptoKey);
					fakeValue = (Vector3Int)num2;
					flag = true;
				}
				else
				{
					flag = false;
				}
				fakeValueActive = flag;
			}
		}

		[Token(Token = "0x17000019")]
		public int this[int index]
		{
			[Token(Token = "0x6000311")]
			[Address(RVA = "0xBE7178", Offset = "0xBE7178", Length = "0x104")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, index, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A354E4]) = v36;\nL_0016:\n\tv41 = index == 2;\n\tif (v41) goto L_003F;\n\tv50 = index == 1;\n\tif (v50) goto L_004F;\n\tv61 = index == 0;\n\tv62 = ~v61;\n\tif (v62) goto L_005C;\n\tgoto L_0037;\n\tv94 = \"il2cpp_codegen_runtime_class_init\"(v79, index, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0037:\n\treturnVal3 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::get_x(this);\n\treturn returnVal3;\nL_003F:\n\tgoto L_0047;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v57, index, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0047:\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::get_z(this);\n\treturn returnVal1;\nL_004F:\n\tgoto L_0057;\n\tv86 = \"il2cpp_codegen_runtime_class_init\"(v65, index, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0057:\n\treturnVal2 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::get_y(this);\n\treturn returnVal2;\nL_005C:\n\tv102 = new System.IndexOutOfRangeException();\n\tSystem.IndexOutOfRangeException::.ctor(v102, \"Invalid ObscuredVector3Int index!\");\n\tthrow v102;\n\treturn returnVal4;\n// 80 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				switch (index)
				{
				case 0:
					return x;
				case 2:
					return z;
				case 1:
					return y;
				default:
				{
					IndexOutOfRangeException ex = new IndexOutOfRangeException("Invalid ObscuredVector3Int index!");
					throw ex;
				}
				}
			}
			[Token(Token = "0x6000312")]
			[Address(RVA = "0xBE727C", Offset = "0xBE727C", Length = "0x124")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, index, value, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A354E5]) = v39;\nL_0018:\n\tv44 = index == 2;\n\tif (v44) goto L_0043;\n\tv53 = index == 1;\n\tif (v53) goto L_0055;\n\tv64 = index == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_0064;\n\tgoto L_003B;\n\tv99 = \"il2cpp_codegen_runtime_class_init\"(v83, index, value, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_003B:\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::set_x(this, value);\n\treturn;\nL_0043:\n\tgoto L_004D;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v60, index, value, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_004D:\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::set_z(this, value);\n\treturn;\nL_0055:\n\tgoto L_005F;\n\tv90 = \"il2cpp_codegen_runtime_class_init\"(v68, index, value, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_005F:\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::set_y(this, value);\n\treturn;\nL_0064:\n\tv108 = new System.IndexOutOfRangeException();\n\tSystem.IndexOutOfRangeException::.ctor(v108, \"Invalid ObscuredVector3Int index!\");\n\tthrow v108;\n\treturn;\n// 88 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				switch (index)
				{
				case 0:
					x = value;
					break;
				case 2:
					z = value;
					break;
				case 1:
					y = value;
					break;
				default:
				{
					IndexOutOfRangeException ex = new IndexOutOfRangeException("Invalid ObscuredVector3Int index!");
					throw ex;
				}
				}
			}
		}

		[Token(Token = "0x6000309")]
		[Address(RVA = "0xBE6BB0", Offset = "0xBE6BB0", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 1;\n\t*([1A354DF]) = v43;\nL_001B:\n\tgoto L_001D;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v44, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_001D:\n\tv50 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tthis.currentCryptoKey = v50;\n\tv52 = methodInfo & 0xFFFFFFFF;\n\tv54 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::Encrypt(value, v52);\n\tthis.hiddenValue = v54;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int)+C]) = v52;\n\tv56 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tgoto L_0038;\n\tv61 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int;\n\tv62 = *([v61 @ X0_v10+E0]);\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_FFFFFFFF;\n\tv82 = \"il2cpp_codegen_runtime_class_init\"(v61, v52, v51, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv83 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int;\n\tv73 = *([v66 @ X0_v11+B8]);\n\tv69 = *([v73 @ X8_v7]);\n\tv71 = *([v73 @ X8_v7+8]);\nL_0038:\n\tthis.fakeValue = value;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int)+1C]) = methodInfo;\n\tthis.fakeValueActive = v56;\n\tthis.inited = 1;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private ObscuredVector3Int(Vector3Int value)
		{
			//IL_002b: Expected I4, but got I8
			int num = RandomUtils.GenerateIntKey();
			currentCryptoKey = num;
			IntPtr intPtr = default(IntPtr);
			int key = (int)((nint)intPtr & 0xFFFFFFFFL);
			RawEncryptedVector3Int rawEncryptedVector3Int = Encrypt(value, key);
			hiddenValue = rawEncryptedVector3Int;
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			fakeValue = value;
			fakeValueActive = existsAndIsRunning;
			inited = true;
		}

		[Token(Token = "0x600030A")]
		[Address(RVA = "0xBE6CF0", Offset = "0xBE6CF0", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv30 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, x, y, z, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 1;\n\t*([1A354E0]) = v46;\nL_001D:\n\tgoto L_001F;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v47, x, y, z, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_001F:\n\tv53 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tv54 = v53 ^ x;\n\tv55 = v53 ^ y;\n\tthis.currentCryptoKey = v53;\n\tv56 = v53 ^ z;\n\tv57 = v55 & 0xFFFFFFFF;\n\tv58 = v57 << 0x20;\n\tv59 = v54 & 0xFFFFFFFF;\n\tv60 = v59 | v58;\n\tthis.hiddenValue = v60;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int)+C]) = v56;\n\tv62 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv64 = v62 == 0;\n\tif (v64) goto L_FFFFFFFF;\n\tthis.fakeValue = x;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int)+18]) = y;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int)+1C]) = z;\n\tgoto L_0041;\n\tgoto L_003B;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v66, x, y, z, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv88 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int;\nL_003B:\n\tv89 = *([v75 @ X0_v9 (Il2CppClass<CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int>)+B8]);\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int)+1C]) = *([v89 @ X9_v3 (Il2CppStaticFields<CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int>)+8]);\n\tthis.fakeValue = v89.Zero;\nL_0041:\n\tthis.fakeValueActive = v77;\n\tthis.inited = 1;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObscuredVector3Int(int x, int y, int z)
		{
			//IL_0051: Expected I4, but got I8
			//IL_0071: Expected I4, but got I8
			//IL_0088: Expected O, but got I4
			//IL_00e8: Expected I, but got O
			//IL_0111: Expected I, but got O
			//IL_00c2: Expected O, but got I4
			int num = RandomUtils.GenerateIntKey();
			int num2 = num ^ x;
			int num3 = num ^ y;
			currentCryptoKey = num;
			int num4 = num ^ z;
			int num5 = (int)(num3 & 0xFFFFFFFFL);
			int num6 = num5 << 32;
			int num7 = (int)(num2 & 0xFFFFFFFFL);
			int num8 = num7 | num6;
			hiddenValue = (RawEncryptedVector3Int)num8;
			bool flag;
			if (ObscuredCheatingDetector.ExistsAndIsRunning)
			{
				fakeValue = (Vector3Int)x;
				flag = true;
			}
			else
			{
				nint num9 = (nint)typeof(ObscuredVector3Int);
				nint num10 = (nint)Zero;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ X9_v3 (Il2CppStaticFields<CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int>)+8]");
				_ = 0;
				fakeValue = Zero;
				flag = false;
			}
			fakeValueActive = flag;
			inited = true;
		}

		[Token(Token = "0x6000313")]
		[Address(RVA = "0xBE6C7C", Offset = "0xBE6C7C", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, key, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 1;\n\t*([1A354E6]) = v43;\nL_001B:\n\tgoto L_001D;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v44, key, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_001D:\n\tv50 = value >> 0x20;\n\tv51 = value ^ methodInfo;\n\tv52 = v50 ^ methodInfo;\n\tv58 = v52 & 0xFFFFFFFF;\n\tv59 = v58 << 0x20;\n\tv60 = v51 & 0xFFFFFFFF;\n\treturnVal1 = v60 | v59;\n\treturn returnVal1;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static RawEncryptedVector3Int Encrypt(Vector3Int value, int key)
		{
			//IL_0013: Expected I4, but got O
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Expected I4, but got Unknown
			//IL_0041: Expected I4, but got I8
			//IL_0061: Expected I4, but got I8
			//IL_006e: Expected O, but got I4
			int num = (object)value >> 32;
			IntPtr intPtr = default(IntPtr);
			int num2 = (int)(value ^ (nint)intPtr);
			int num3 = (int)(num ^ (nint)intPtr);
			int num4 = (int)(num3 & 0xFFFFFFFFL);
			int num5 = num4 << 32;
			int num6 = (int)(num2 & 0xFFFFFFFFL);
			return (RawEncryptedVector3Int)(num6 | num5);
		}

		[Token(Token = "0x6000314")]
		[Address(RVA = "0xBE6DD0", Offset = "0xBE6DD0", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = key ^ x;\n\tv3 = key ^ y;\n\tv7 = v3 & 0xFFFFFFFF;\n\tv8 = v7 << 0x20;\n\tv9 = v0 & 0xFFFFFFFF;\n\treturnVal1 = v9 | v8;\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static RawEncryptedVector3Int Encrypt(int x, int y, int z, int key)
		{
			//IL_002c: Expected I4, but got I8
			//IL_004c: Expected I4, but got I8
			//IL_0059: Expected O, but got I4
			int num = key ^ x;
			int num2 = key ^ y;
			int num3 = (int)(num2 & 0xFFFFFFFFL);
			int num4 = num3 << 32;
			int num5 = (int)(num & 0xFFFFFFFFL);
			return (RawEncryptedVector3Int)(num5 | num4);
		}

		[Token(Token = "0x6000315")]
		[Address(RVA = "0xBE73A0", Offset = "0xBE73A0", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = value >> 0x20;\n\tv2 = value ^ methodInfo;\n\tv4 = v0 ^ methodInfo;\n\tv7 = v4 & 0xFFFFFFFF;\n\tv8 = v7 << 0x20;\n\tv9 = v2 & 0xFFFFFFFF;\n\treturnVal1 = v9 | v8;\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector3Int Decrypt(RawEncryptedVector3Int value, int key)
		{
			//IL_000e: Expected I4, but got O
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Expected I4, but got Unknown
			//IL_003c: Expected I4, but got I8
			//IL_005c: Expected I4, but got I8
			//IL_0069: Expected O, but got I4
			int num = (object)value >> 32;
			IntPtr intPtr = default(IntPtr);
			int num2 = (int)(value ^ (nint)intPtr);
			int num3 = (int)(num ^ (nint)intPtr);
			int num4 = (int)(num3 & 0xFFFFFFFFL);
			int num5 = num4 << 32;
			int num6 = (int)(num2 & 0xFFFFFFFFL);
			return (Vector3Int)(num6 | num5);
		}

		[Token(Token = "0x6000316")]
		[Address(RVA = "0xBE73B8", Offset = "0xBE73B8", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv30 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, key, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 1;\n\t*([1A354E7]) = v47;\nL_0021:\n\tgoto L_0023;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, key, methodInfo, v32, v33, v34, v35, v36, v49, v38, v39, v40, v41, v42, v43, v44);\nL_0023:\n\tv58 = key & 0xFFFFFFFF;\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::SetEncrypted(&v60 @ stack_-70_v2 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int), encrypted, v58);\n\treturnBuffer.fakeValueActive = 0;\n\treturnBuffer.currentCryptoKey = v60;\n\treturnBuffer.inited = 0;\n\treturn &v60 @ stack_-70_v2 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int);\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredVector3Int FromEncrypted(RawEncryptedVector3Int encrypted, int key)
		{
			//IL_0017: Expected I4, but got I8
			//IL_0031: Expected native int or pointer, but got O
			//IL_0043: Expected I4, but got O
			//IL_003e: Expected native int or pointer, but got O
			//IL_004c: Expected native int or pointer, but got O
			//IL_0056: Expected O, but got Ref
			int key2 = (int)(key & 0xFFFFFFFFL);
			ObscuredVector3Int obscuredVector3Int = default(ObscuredVector3Int);
			obscuredVector3Int.SetEncrypted(encrypted, key2);
			ObscuredVector3Int obscuredVector3Int2 = default(ObscuredVector3Int);
			((ObscuredVector3Int*)(nint)obscuredVector3Int2)->fakeValueActive = false;
			((ObscuredVector3Int*)(nint)obscuredVector3Int2)->currentCryptoKey = (int)obscuredVector3Int;
			((ObscuredVector3Int*)(nint)obscuredVector3Int2)->inited = false;
			return (ObscuredVector3Int)(&obscuredVector3Int);
		}

		[Token(Token = "0x6000317")]
		[Address(RVA = "0xBE6C78", Offset = "0xBE6C78", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\treturn returnVal1;\n")]
		public static int GenerateKey()
		{
			return RandomUtils.GenerateIntKey();
		}

		[Token(Token = "0x6000318")]
		[Address(RVA = "0xBE74FC", Offset = "0xBE74FC", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([key @ X1 (System.Int32&)]) = this.currentCryptoKey;\n\treturn this.hiddenValue;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe RawEncryptedVector3Int GetEncrypted(out int key)
		{
			key = default(int);
			ref int reference = ref *(int*)currentCryptoKey;
			return hiddenValue;
		}

		[Token(Token = "0x6000319")]
		[Address(RVA = "0xBE745C", Offset = "0xBE745C", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, encrypted, key, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A354E8]) = v42;\nL_0018:\n\tthis.hiddenValue = encrypted;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int)+C]) = key;\n\tthis.inited = 1;\n\tthis.currentCryptoKey = methodInfo;\n\tv45 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tthis.fakeValueActive = 0;\n\tv47 = v45 == 0;\n\tif (v47) goto L_0036;\n\tgoto L_002A;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v50, encrypted, key, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_002A:\n\tv55 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::InternalDecrypt(this);\n\tthis.fakeValue = v55;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int)+1C]) = encrypted;\n\tthis.fakeValueActive = 1;\nL_0036:\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetEncrypted(RawEncryptedVector3Int encrypted, int key)
		{
			hiddenValue = encrypted;
			inited = true;
			IntPtr intPtr = default(IntPtr);
			currentCryptoKey = (int)(nint)intPtr;
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			fakeValueActive = false;
			if (existsAndIsRunning)
			{
				Vector3Int vector3Int = InternalDecrypt();
				fakeValue = vector3Int;
				fakeValueActive = true;
			}
		}

		[Token(Token = "0x600031A")]
		[Address(RVA = "0xBE769C", Offset = "0xBE769C", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A354E9]) = v37;\nL_0017:\n\tgoto L_001A;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001A:\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::InternalDecrypt(this);\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Vector3Int GetDecrypted()
		{
			return InternalDecrypt();
		}

		[Token(Token = "0x600031B")]
		[Address(RVA = "0xBE76F8", Offset = "0xBE76F8", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A354EA]) = v37;\nL_0017:\n\tgoto L_001A;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001A:\n\tv45 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::InternalDecrypt(this);\n\tv48 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tthis.currentCryptoKey = v48;\n\tv50 = methodInfo & 0xFFFFFFFF;\n\tv52 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::Encrypt(v45, v50);\n\tthis.hiddenValue = v52;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int)+C]) = v50;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RandomizeCryptoKey()
		{
			//IL_003a: Expected I4, but got I8
			Vector3Int value = InternalDecrypt();
			int num = RandomUtils.GenerateIntKey();
			currentCryptoKey = num;
			IntPtr intPtr = default(IntPtr);
			int key = (int)((nint)intPtr & 0xFFFFFFFFL);
			RawEncryptedVector3Int rawEncryptedVector3Int = Encrypt(value, key);
			hiddenValue = rawEncryptedVector3Int;
		}

		[Token(Token = "0x600031C")]
		[Address(RVA = "0xBE7514", Offset = "0xBE7514", Length = "0x188")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = Il2CppMethodInfo;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv46 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A354EB]) = v40;\nL_0019:\n\tv44 = ~this.inited;\n\tif (v44) goto L_0077;\n\tgoto L_0024;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0024:\n\tv60 = this.hiddenValue >> 0x20;\n\tv61 = this.currentCryptoKey ^ this.hiddenValue;\n\tv62 = this.currentCryptoKey ^ v60;\n\tv63 = this.currentCryptoKey ^ *([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int)+C]);\n\tv66 = v62 & 0xFFFFFFFF;\n\tv67 = v66 << 0x20;\n\tv68 = v61 & 0xFFFFFFFF;\n\tv145 = v68 | v67;\n\tv70 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv75 = v70 == 0;\n\tif (v75) goto L_0098;\n\tv83 = ~this.fakeValueActive;\n\tif (v83) goto L_0098;\n\tv167 = v61 != this.fakeValue;\n\tif (v167) goto L_0060;\n\tv193 = this.fakeValue >> 0x20;\n\tv99 = v62 != v193;\n\tif (v99) goto L_0060;\n\tv119 = v63 == *([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int)+1C]);\n\tif (v119) goto L_0098;\nL_0060:\n\tgoto L_0068;\n\tv213 = 0xB348B0(v207, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0068:\n\tgoto L_0071;\n\tv221 = 0xB348B0(v216, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0071:\n\tv138 = CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector>::OnCheatingDetected(v191.<Instance>k__BackingField);\n\tgoto L_0098;\nL_0077:\n\tgoto L_0079;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v54, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0079:\n\tv73 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tthis.currentCryptoKey = v73;\n\tv76 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int;\n\tv78 = *([v76 @ X8_v6 (Il2CppClass<CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int>)+B8]);\n\tv81 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::Encrypt(v78.Zero, *([v78 @ X8_v7 (Il2CppStaticFields<CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int>)+8]));\n\tthis.hiddenValue = v81;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int)+C]) = *([v78 @ X8_v7 (Il2CppStaticFields<CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int>)+8]);\n\tv155 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int;\n\tv156 = *([v155 @ X8_v8 (Il2CppClass<CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int>)+B8]);\n\tthis.inited = 1;\n\tthis.fakeValueActive = 0;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int)+1C]) = *([v156 @ X9_v2 (Il2CppStaticFields<CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int>)+8]);\n\tthis.fakeValue = v156.Zero;\nL_0098:\n\treturn v145;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 100 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private Vector3Int InternalDecrypt()
		{
			//IL_0184: Expected I, but got O
			//IL_018d: Expected I, but got O
			//IL_01d1: Expected I, but got O
			//IL_01da: Expected I, but got O
			//IL_0211: Expected I4, but got O
			//IL_001a: Expected I4, but got O
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Expected I4, but got Unknown
			//IL_0063: Expected I4, but got I8
			//IL_0083: Expected I4, but got I8
			//IL_0236: Expected O, but got I4
			//IL_0102: Expected I4, but got O
			int num9;
			if (inited)
			{
				int num = (object)hiddenValue >> 32;
				int num2 = currentCryptoKey ^ hiddenValue;
				int num3 = currentCryptoKey ^ num;
				int num4 = currentCryptoKey;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int)+C]");
				int num5 = (int)((nint)num4 ^ (nint)0);
				int num6 = (int)(num3 & 0xFFFFFFFFL);
				int num7 = num6 << 32;
				int num8 = (int)(num2 & 0xFFFFFFFFL);
				num9 = num8 | num7;
				if (ObscuredCheatingDetector.ExistsAndIsRunning && fakeValueActive)
				{
					if (num2 == (nint)fakeValue)
					{
						int num10 = (object)fakeValue >> 32;
						if (num3 == num10)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int)+1C]");
							if ((nint)num5 == 0)
							{
								goto IL_0231;
							}
						}
					}
					KeepAliveBehaviour<ObscuredCheatingDetector>.Instance.OnCheatingDetected();
				}
			}
			else
			{
				int num11 = RandomUtils.GenerateIntKey();
				currentCryptoKey = num11;
				nint num12 = (nint)typeof(ObscuredVector3Int);
				nint num13 = (nint)Zero;
				Vector3Int zero = Zero;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ X8_v7 (Il2CppStaticFields<CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int>)+8]");
				RawEncryptedVector3Int rawEncryptedVector3Int = Encrypt(zero, 0);
				hiddenValue = rawEncryptedVector3Int;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ X8_v7 (Il2CppStaticFields<CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int>)+8]");
				_ = 0;
				nint num14 = (nint)typeof(ObscuredVector3Int);
				nint num15 = (nint)Zero;
				inited = true;
				fakeValueActive = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ X9_v2 (Il2CppStaticFields<CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int>)+8]");
				_ = 0;
				fakeValue = Zero;
				num9 = (int)Zero;
			}
			goto IL_0231;
			IL_0231:
			return (Vector3Int)num9;
		}

		[Token(Token = "0x600031D")]
		[Address(RVA = "0xBE7778", Offset = "0xBE7778", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnBuffer.fakeValueActive = 0;\n\treturnBuffer.currentCryptoKey = 0;\n\treturnBuffer.inited = 0;\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::.ctor(returnBuffer, value);\n\treturn returnBuffer;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static implicit operator ObscuredVector3Int(Vector3Int value)
		{
			//IL_000a: Expected native int or pointer, but got O
			//IL_0018: Expected native int or pointer, but got O
			//IL_0026: Expected native int or pointer, but got O
			//IL_0033: Expected native int or pointer, but got O
			ObscuredVector3Int obscuredVector3Int = default(ObscuredVector3Int);
			((ObscuredVector3Int*)(nint)obscuredVector3Int)->fakeValueActive = false;
			((ObscuredVector3Int*)(nint)obscuredVector3Int)->currentCryptoKey = 0;
			((ObscuredVector3Int*)(nint)obscuredVector3Int)->inited = false;
			*(ObscuredVector3Int*)(nint)obscuredVector3Int = new ObscuredVector3Int(value);
			return obscuredVector3Int;
		}

		[Token(Token = "0x600031E")]
		[Address(RVA = "0xBE7798", Offset = "0xBE7798", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A354EC]) = v37;\nL_0017:\n\tgoto L_001A;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001A:\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::InternalDecrypt(value);\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static implicit operator Vector3Int(ObscuredVector3Int value)
		{
			return ((ObscuredVector3Int*)value)->InternalDecrypt();
		}

		[Token(Token = "0x600031F")]
		[Address(RVA = "0xBE77F4", Offset = "0xBE77F4", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A354ED]) = v37;\nL_0017:\n\tgoto L_001A;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001A:\n\tv45 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::InternalDecrypt(value);\n\treturn v45;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static implicit operator Vector3(ObscuredVector3Int value)
		{
			return ((ObscuredVector3Int*)value)->InternalDecrypt();
		}

		[Token(Token = "0x6000320")]
		[Address(RVA = "0xBE785C", Offset = "0xBE785C", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, b, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 1;\n\t*([1A354EE]) = v44;\nL_001B:\n\tgoto L_001E;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v45, b, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_001E:\n\tv52 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::InternalDecrypt(a);\n\tv56 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::InternalDecrypt(b);\n\tv57 = v56 & 0xFFFFFFFF00000000;\n\tv58 = v57 + v52;\n\tv59 = v56 + v52;\n\tv60 = v58 & 0xFFFFFFFF00000000;\n\tv63 = v60 | v59;\n\tv65 = 0;\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::.ctor(&v65 @ stack_-60_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int), v63);\n\treturnBuffer.fakeValueActive = 0;\n\treturnBuffer.currentCryptoKey = 0;\n\treturnBuffer.inited = 0;\n\treturn &v65 @ stack_-60_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int);\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredVector3Int operator +(ObscuredVector3Int a, ObscuredVector3Int b)
		{
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Expected I4, but got Unknown
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Expected O, but got Unknown
			//IL_0063: Expected I4, but got I8
			//IL_0072: Expected O, but got I
			//IL_0092: Expected native int or pointer, but got O
			//IL_00a0: Expected native int or pointer, but got O
			//IL_00ae: Expected native int or pointer, but got O
			//IL_00b8: Expected O, but got Ref
			Vector3Int vector3Int = ((ObscuredVector3Int*)a)->InternalDecrypt();
			Vector3Int vector3Int2 = ((ObscuredVector3Int*)b)->InternalDecrypt();
			int num = (int)(vector3Int2 & -4294967296L);
			object obj = num + vector3Int;
			object obj2 = vector3Int2 + vector3Int;
			int num2 = (int)((nint)obj & -4294967296L);
			Vector3Int value = (Vector3Int)(num2 | (nint)obj2);
			ObscuredVector3Int obscuredVector3Int = default(ObscuredVector3Int);
			obscuredVector3Int = new ObscuredVector3Int(value);
			ObscuredVector3Int obscuredVector3Int2 = default(ObscuredVector3Int);
			((ObscuredVector3Int*)(nint)obscuredVector3Int2)->fakeValueActive = false;
			((ObscuredVector3Int*)(nint)obscuredVector3Int2)->currentCryptoKey = 0;
			((ObscuredVector3Int*)(nint)obscuredVector3Int2)->inited = false;
			return (ObscuredVector3Int)(&obscuredVector3Int);
		}

		[Token(Token = "0x6000321")]
		[Address(RVA = "0xBE7918", Offset = "0xBE7918", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv30 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, b, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 1;\n\t*([1A354EF]) = v47;\nL_001D:\n\tgoto L_0020;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v48, b, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0020:\n\tv55 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::InternalDecrypt(methodInfo);\n\tv56 = v55 & 0xFFFFFFFF00000000;\n\tv57 = v56 + a;\n\tv58 = v55 + a;\n\tv59 = v57 & 0xFFFFFFFF00000000;\n\tv62 = v59 | v58;\n\tv64 = 0;\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::.ctor(&v64 @ stack_-70_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int), v62);\n\treturnBuffer.fakeValueActive = 0;\n\treturnBuffer.currentCryptoKey = 0;\n\treturnBuffer.inited = 0;\n\treturn &v64 @ stack_-70_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int);\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredVector3Int operator +(Vector3Int a, ObscuredVector3Int b)
		{
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected I4, but got Unknown
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0051: Expected I4, but got I8
			//IL_0060: Expected O, but got I
			//IL_0085: Expected native int or pointer, but got O
			//IL_0093: Expected native int or pointer, but got O
			//IL_00a1: Expected native int or pointer, but got O
			//IL_00ab: Expected O, but got Ref
			IntPtr intPtr = default(IntPtr);
			Vector3Int vector3Int = ((ObscuredVector3Int*)intPtr)->InternalDecrypt();
			int num = (int)(vector3Int & -4294967296L);
			object obj = num + a;
			object obj2 = vector3Int + a;
			int num2 = (int)((nint)obj & -4294967296L);
			Vector3Int value = (Vector3Int)(num2 | (nint)obj2);
			ObscuredVector3Int obscuredVector3Int = default(ObscuredVector3Int);
			obscuredVector3Int = new ObscuredVector3Int(value);
			ObscuredVector3Int obscuredVector3Int2 = default(ObscuredVector3Int);
			((ObscuredVector3Int*)(nint)obscuredVector3Int2)->fakeValueActive = false;
			((ObscuredVector3Int*)(nint)obscuredVector3Int2)->currentCryptoKey = 0;
			((ObscuredVector3Int*)(nint)obscuredVector3Int2)->inited = false;
			return (ObscuredVector3Int)(&obscuredVector3Int);
		}

		[Token(Token = "0x6000322")]
		[Address(RVA = "0xBE79D0", Offset = "0xBE79D0", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv30 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, b, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 1;\n\t*([1A354F0]) = v47;\nL_001D:\n\tgoto L_0020;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v48, b, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0020:\n\tv55 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::InternalDecrypt(a);\n\tv56 = b & 0xFFFFFFFF00000000;\n\tv57 = v55 + v56;\n\tv58 = v55 + b;\n\tv59 = v57 & 0xFFFFFFFF00000000;\n\tv62 = v59 | v58;\n\tv64 = 0;\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::.ctor(&v64 @ stack_-70_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int), v62);\n\treturnBuffer.fakeValueActive = 0;\n\treturnBuffer.currentCryptoKey = 0;\n\treturnBuffer.inited = 0;\n\treturn &v64 @ stack_-70_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int);\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredVector3Int operator +(ObscuredVector3Int a, Vector3Int b)
		{
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected I4, but got Unknown
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0051: Expected I4, but got I8
			//IL_0060: Expected O, but got I
			//IL_0085: Expected native int or pointer, but got O
			//IL_0093: Expected native int or pointer, but got O
			//IL_00a1: Expected native int or pointer, but got O
			//IL_00ab: Expected O, but got Ref
			Vector3Int vector3Int = ((ObscuredVector3Int*)a)->InternalDecrypt();
			int num = (int)(b & -4294967296L);
			object obj = vector3Int + num;
			object obj2 = vector3Int + b;
			int num2 = (int)((nint)obj & -4294967296L);
			Vector3Int value = (Vector3Int)(num2 | (nint)obj2);
			ObscuredVector3Int obscuredVector3Int = default(ObscuredVector3Int);
			obscuredVector3Int = new ObscuredVector3Int(value);
			ObscuredVector3Int obscuredVector3Int2 = default(ObscuredVector3Int);
			((ObscuredVector3Int*)(nint)obscuredVector3Int2)->fakeValueActive = false;
			((ObscuredVector3Int*)(nint)obscuredVector3Int2)->currentCryptoKey = 0;
			((ObscuredVector3Int*)(nint)obscuredVector3Int2)->inited = false;
			return (ObscuredVector3Int)(&obscuredVector3Int);
		}

		[Token(Token = "0x6000323")]
		[Address(RVA = "0xBE7A88", Offset = "0xBE7A88", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, b, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 1;\n\t*([1A354F1]) = v44;\nL_001B:\n\tgoto L_001E;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v45, b, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_001E:\n\tv52 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::InternalDecrypt(a);\n\tv56 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::InternalDecrypt(b);\n\tv57 = v56 & 0xFFFFFFFF00000000;\n\tv58 = v52 - v57;\n\tv59 = v52 - v56;\n\tv60 = v58 & 0xFFFFFFFF00000000;\n\tv63 = v60 | v59;\n\tv65 = 0;\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::.ctor(&v65 @ stack_-60_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int), v63);\n\treturnBuffer.fakeValueActive = 0;\n\treturnBuffer.currentCryptoKey = 0;\n\treturnBuffer.inited = 0;\n\treturn &v65 @ stack_-60_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int);\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredVector3Int operator -(ObscuredVector3Int a, ObscuredVector3Int b)
		{
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Expected I4, but got Unknown
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Expected O, but got Unknown
			//IL_0063: Expected I4, but got I8
			//IL_0072: Expected O, but got I
			//IL_0092: Expected native int or pointer, but got O
			//IL_00a0: Expected native int or pointer, but got O
			//IL_00ae: Expected native int or pointer, but got O
			//IL_00b8: Expected O, but got Ref
			Vector3Int vector3Int = ((ObscuredVector3Int*)a)->InternalDecrypt();
			Vector3Int vector3Int2 = ((ObscuredVector3Int*)b)->InternalDecrypt();
			int num = (int)(vector3Int2 & -4294967296L);
			object obj = vector3Int - num;
			object obj2 = vector3Int - vector3Int2;
			int num2 = (int)((nint)obj & -4294967296L);
			Vector3Int value = (Vector3Int)(num2 | (nint)obj2);
			ObscuredVector3Int obscuredVector3Int = default(ObscuredVector3Int);
			obscuredVector3Int = new ObscuredVector3Int(value);
			ObscuredVector3Int obscuredVector3Int2 = default(ObscuredVector3Int);
			((ObscuredVector3Int*)(nint)obscuredVector3Int2)->fakeValueActive = false;
			((ObscuredVector3Int*)(nint)obscuredVector3Int2)->currentCryptoKey = 0;
			((ObscuredVector3Int*)(nint)obscuredVector3Int2)->inited = false;
			return (ObscuredVector3Int)(&obscuredVector3Int);
		}

		[Token(Token = "0x6000324")]
		[Address(RVA = "0xBE7B44", Offset = "0xBE7B44", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv30 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, b, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 1;\n\t*([1A354F2]) = v47;\nL_001D:\n\tgoto L_0020;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v48, b, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0020:\n\tv55 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::InternalDecrypt(methodInfo);\n\tv56 = v55 & 0xFFFFFFFF00000000;\n\tv57 = a - v56;\n\tv58 = a - v55;\n\tv59 = v57 & 0xFFFFFFFF00000000;\n\tv62 = v59 | v58;\n\tv64 = 0;\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::.ctor(&v64 @ stack_-70_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int), v62);\n\treturnBuffer.fakeValueActive = 0;\n\treturnBuffer.currentCryptoKey = 0;\n\treturnBuffer.inited = 0;\n\treturn &v64 @ stack_-70_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int);\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredVector3Int operator -(Vector3Int a, ObscuredVector3Int b)
		{
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected I4, but got Unknown
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0051: Expected I4, but got I8
			//IL_0060: Expected O, but got I
			//IL_0085: Expected native int or pointer, but got O
			//IL_0093: Expected native int or pointer, but got O
			//IL_00a1: Expected native int or pointer, but got O
			//IL_00ab: Expected O, but got Ref
			IntPtr intPtr = default(IntPtr);
			Vector3Int vector3Int = ((ObscuredVector3Int*)intPtr)->InternalDecrypt();
			int num = (int)(vector3Int & -4294967296L);
			object obj = a - num;
			object obj2 = a - vector3Int;
			int num2 = (int)((nint)obj & -4294967296L);
			Vector3Int value = (Vector3Int)(num2 | (nint)obj2);
			ObscuredVector3Int obscuredVector3Int = default(ObscuredVector3Int);
			obscuredVector3Int = new ObscuredVector3Int(value);
			ObscuredVector3Int obscuredVector3Int2 = default(ObscuredVector3Int);
			((ObscuredVector3Int*)(nint)obscuredVector3Int2)->fakeValueActive = false;
			((ObscuredVector3Int*)(nint)obscuredVector3Int2)->currentCryptoKey = 0;
			((ObscuredVector3Int*)(nint)obscuredVector3Int2)->inited = false;
			return (ObscuredVector3Int)(&obscuredVector3Int);
		}

		[Token(Token = "0x6000325")]
		[Address(RVA = "0xBE7BFC", Offset = "0xBE7BFC", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv30 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, b, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 1;\n\t*([1A354F3]) = v47;\nL_001D:\n\tgoto L_0020;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v48, b, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0020:\n\tv55 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::InternalDecrypt(a);\n\tv56 = b & 0xFFFFFFFF00000000;\n\tv57 = v55 - v56;\n\tv58 = v55 - b;\n\tv59 = v57 & 0xFFFFFFFF00000000;\n\tv62 = v59 | v58;\n\tv64 = 0;\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::.ctor(&v64 @ stack_-70_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int), v62);\n\treturnBuffer.fakeValueActive = 0;\n\treturnBuffer.currentCryptoKey = 0;\n\treturnBuffer.inited = 0;\n\treturn &v64 @ stack_-70_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int);\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredVector3Int operator -(ObscuredVector3Int a, Vector3Int b)
		{
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected I4, but got Unknown
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0051: Expected I4, but got I8
			//IL_0060: Expected O, but got I
			//IL_0085: Expected native int or pointer, but got O
			//IL_0093: Expected native int or pointer, but got O
			//IL_00a1: Expected native int or pointer, but got O
			//IL_00ab: Expected O, but got Ref
			Vector3Int vector3Int = ((ObscuredVector3Int*)a)->InternalDecrypt();
			int num = (int)(b & -4294967296L);
			object obj = vector3Int - num;
			object obj2 = vector3Int - b;
			int num2 = (int)((nint)obj & -4294967296L);
			Vector3Int value = (Vector3Int)(num2 | (nint)obj2);
			ObscuredVector3Int obscuredVector3Int = default(ObscuredVector3Int);
			obscuredVector3Int = new ObscuredVector3Int(value);
			ObscuredVector3Int obscuredVector3Int2 = default(ObscuredVector3Int);
			((ObscuredVector3Int*)(nint)obscuredVector3Int2)->fakeValueActive = false;
			((ObscuredVector3Int*)(nint)obscuredVector3Int2)->currentCryptoKey = 0;
			((ObscuredVector3Int*)(nint)obscuredVector3Int2)->inited = false;
			return (ObscuredVector3Int)(&obscuredVector3Int);
		}

		[Token(Token = "0x6000326")]
		[Address(RVA = "0xBE7CB4", Offset = "0xBE7CB4", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, d, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 1;\n\t*([1A354F4]) = v44;\nL_001B:\n\tgoto L_001E;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v45, d, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_001E:\n\tv52 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::InternalDecrypt(a);\n\tv53 = v52 >> 0x20;\n\tv54 = v52 * d;\n\tv55 = v53 * d;\n\tv56 = v55 & 0xFFFFFFFF;\n\tv57 = v56 << 0x20;\n\tv58 = v54 & 0xFFFFFFFF;\n\tv59 = v58 | v57;\n\tv63 = 0;\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::.ctor(&v63 @ stack_-60_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int), v59);\n\treturnBuffer.fakeValueActive = 0;\n\treturnBuffer.currentCryptoKey = 0;\n\treturnBuffer.inited = 0;\n\treturn &v63 @ stack_-60_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int);\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredVector3Int operator *(ObscuredVector3Int a, int d)
		{
			//IL_0020: Expected I4, but got O
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Expected O, but got Unknown
			//IL_004c: Expected I4, but got I8
			//IL_006d: Expected I4, but got I8
			//IL_0092: Expected O, but got I4
			//IL_00a0: Expected native int or pointer, but got O
			//IL_00ae: Expected native int or pointer, but got O
			//IL_00bc: Expected native int or pointer, but got O
			//IL_00c6: Expected O, but got Ref
			Vector3Int vector3Int = ((ObscuredVector3Int*)a)->InternalDecrypt();
			int num = (object)vector3Int >> 32;
			object obj = vector3Int * d;
			int num2 = num * d;
			int num3 = (int)(num2 & 0xFFFFFFFFL);
			int num4 = num3 << 32;
			int num5 = (int)((nint)obj & 0xFFFFFFFFL);
			int num6 = num5 | num4;
			ObscuredVector3Int obscuredVector3Int = default(ObscuredVector3Int);
			obscuredVector3Int = new ObscuredVector3Int((Vector3Int)num6);
			ObscuredVector3Int obscuredVector3Int2 = default(ObscuredVector3Int);
			((ObscuredVector3Int*)(nint)obscuredVector3Int2)->fakeValueActive = false;
			((ObscuredVector3Int*)(nint)obscuredVector3Int2)->currentCryptoKey = 0;
			((ObscuredVector3Int*)(nint)obscuredVector3Int2)->inited = false;
			return (ObscuredVector3Int)(&obscuredVector3Int);
		}

		[Token(Token = "0x6000327")]
		[Address(RVA = "0xBE7D60", Offset = "0xBE7D60", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, rhs, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A354F5]) = v40;\nL_0019:\n\tgoto L_001C;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, rhs, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_001C:\n\tv48 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::InternalDecrypt(lhs);\n\tv52 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::InternalDecrypt(rhs);\n\tv62 = v48 != v52;\n\tif (v62) goto L_FFFFFFFF;\n\tv63 = v52 >> 0x20;\n\tv64 = v48 >> 0x20;\n\tv67 = v64 - v63;\n\tv69 = v67 == 0;\n\tv77 = rhs - rhs;\n\tv79 = v77 == 0;\n\treturnVal1 = v79 & v69;\n\tgoto L_004B;\nL_004B:\n\treturn returnVal1;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static bool operator ==(ObscuredVector3Int lhs, ObscuredVector3Int rhs)
		{
			//IL_0051: Expected I4, but got O
			//IL_005f: Expected I4, but got O
			Vector3Int vector3Int = ((ObscuredVector3Int*)lhs)->InternalDecrypt();
			Vector3Int vector3Int2 = ((ObscuredVector3Int*)rhs)->InternalDecrypt();
			if ((object)vector3Int == (object)vector3Int2)
			{
				int num = (object)vector3Int2 >> 32;
				int num2 = (object)vector3Int >> 32;
				int num3 = num2 - num;
				bool flag = num3 == 0;
				object obj = rhs - rhs;
				bool flag2 = obj == null;
				return flag2 && flag;
			}
			return false;
		}

		[Token(Token = "0x6000328")]
		[Address(RVA = "0xBE7E00", Offset = "0xBE7E00", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, rhs, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 1;\n\t*([1A354F6]) = v43;\nL_001B:\n\tgoto L_001E;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v44, rhs, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_001E:\n\tv51 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::InternalDecrypt(methodInfo);\n\tv61 = lhs != v51;\n\tif (v61) goto L_FFFFFFFF;\n\tv62 = v51 >> 0x20;\n\tv63 = lhs >> 0x20;\n\tv66 = v63 - v62;\n\tv68 = v66 == 0;\n\tv76 = rhs - rhs;\n\tv78 = v76 == 0;\n\treturnVal1 = v78 & v68;\n\tgoto L_004A;\nL_004A:\n\treturn returnVal1;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static bool operator ==(Vector3Int lhs, ObscuredVector3Int rhs)
		{
			//IL_003f: Expected I4, but got O
			//IL_004d: Expected I4, but got O
			IntPtr intPtr = default(IntPtr);
			Vector3Int vector3Int = ((ObscuredVector3Int*)intPtr)->InternalDecrypt();
			if ((object)lhs == (object)vector3Int)
			{
				int num = (object)vector3Int >> 32;
				int num2 = (object)lhs >> 32;
				int num3 = num2 - num;
				bool flag = num3 == 0;
				object obj = rhs - rhs;
				bool flag2 = obj == null;
				return flag2 && flag;
			}
			return false;
		}

		[Token(Token = "0x6000329")]
		[Address(RVA = "0xBE7E94", Offset = "0xBE7E94", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, rhs, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 1;\n\t*([1A354F7]) = v43;\nL_001B:\n\tgoto L_001E;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v44, rhs, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_001E:\n\tv51 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::InternalDecrypt(lhs);\n\tv61 = v51 != rhs;\n\tif (v61) goto L_FFFFFFFF;\n\tv62 = rhs >> 0x20;\n\tv63 = v51 >> 0x20;\n\tv66 = v63 - v62;\n\tv68 = v66 == 0;\n\tv76 = rhs - methodInfo;\n\tv78 = v76 == 0;\n\treturnVal1 = v78 & v68;\n\tgoto L_004A;\nL_004A:\n\treturn returnVal1;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static bool operator ==(ObscuredVector3Int lhs, Vector3Int rhs)
		{
			//IL_003f: Expected I4, but got O
			//IL_004d: Expected I4, but got O
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Expected O, but got Unknown
			Vector3Int vector3Int = ((ObscuredVector3Int*)lhs)->InternalDecrypt();
			if ((object)vector3Int == (object)rhs)
			{
				int num = (object)rhs >> 32;
				int num2 = (object)vector3Int >> 32;
				int num3 = num2 - num;
				bool flag = num3 == 0;
				IntPtr intPtr = default(IntPtr);
				object obj = rhs - (nint)intPtr;
				bool flag2 = obj == null;
				return flag2 && flag;
			}
			return false;
		}

		[Token(Token = "0x600032A")]
		[Address(RVA = "0xBE7F28", Offset = "0xBE7F28", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, rhs, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A354F8]) = v40;\nL_0019:\n\tgoto L_001C;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, rhs, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_001C:\n\tv48 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::InternalDecrypt(lhs);\n\tv52 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::InternalDecrypt(rhs);\n\tv62 = v48 != v52;\n\tif (v62) goto L_FFFFFFFF;\n\tv63 = v52 >> 0x20;\n\tv64 = v48 >> 0x20;\n\tv67 = v64 - v63;\n\tv69 = v67 == 0;\n\tv74 = ~v69;\n\tv78 = rhs - rhs;\n\tv80 = v78 == 0;\n\tv85 = ~v80;\n\treturnVal1 = v85 | v74;\n\tgoto L_004D;\nL_004D:\n\treturn returnVal1;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static bool operator !=(ObscuredVector3Int lhs, ObscuredVector3Int rhs)
		{
			//IL_0051: Expected I4, but got O
			//IL_005f: Expected I4, but got O
			Vector3Int vector3Int = ((ObscuredVector3Int*)lhs)->InternalDecrypt();
			Vector3Int vector3Int2 = ((ObscuredVector3Int*)rhs)->InternalDecrypt();
			if ((object)vector3Int == (object)vector3Int2)
			{
				int num = (object)vector3Int2 >> 32;
				int num2 = (object)vector3Int >> 32;
				int num3 = num2 - num;
				bool flag = num3 == 0;
				bool flag2 = !flag;
				object obj = rhs - rhs;
				bool flag3 = obj == null;
				bool flag4 = !flag3;
				return flag4 || flag2;
			}
			return true;
		}

		[Token(Token = "0x600032B")]
		[Address(RVA = "0xBE7FC8", Offset = "0xBE7FC8", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, rhs, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 1;\n\t*([1A354F9]) = v43;\nL_001B:\n\tgoto L_001E;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v44, rhs, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_001E:\n\tv51 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::InternalDecrypt(methodInfo);\n\tv61 = lhs != v51;\n\tif (v61) goto L_FFFFFFFF;\n\tv62 = v51 >> 0x20;\n\tv63 = lhs >> 0x20;\n\tv66 = v63 - v62;\n\tv68 = v66 == 0;\n\tv73 = ~v68;\n\tv77 = rhs - rhs;\n\tv79 = v77 == 0;\n\tv84 = ~v79;\n\treturnVal1 = v84 | v73;\n\tgoto L_004C;\nL_004C:\n\treturn returnVal1;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static bool operator !=(Vector3Int lhs, ObscuredVector3Int rhs)
		{
			//IL_003f: Expected I4, but got O
			//IL_004d: Expected I4, but got O
			IntPtr intPtr = default(IntPtr);
			Vector3Int vector3Int = ((ObscuredVector3Int*)intPtr)->InternalDecrypt();
			if ((object)lhs == (object)vector3Int)
			{
				int num = (object)vector3Int >> 32;
				int num2 = (object)lhs >> 32;
				int num3 = num2 - num;
				bool flag = num3 == 0;
				bool flag2 = !flag;
				object obj = rhs - rhs;
				bool flag3 = obj == null;
				bool flag4 = !flag3;
				return flag4 || flag2;
			}
			return true;
		}

		[Token(Token = "0x600032C")]
		[Address(RVA = "0xBE805C", Offset = "0xBE805C", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, rhs, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 1;\n\t*([1A354FA]) = v43;\nL_001B:\n\tgoto L_001E;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v44, rhs, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_001E:\n\tv51 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::InternalDecrypt(lhs);\n\tv61 = v51 != rhs;\n\tif (v61) goto L_FFFFFFFF;\n\tv62 = rhs >> 0x20;\n\tv63 = v51 >> 0x20;\n\tv66 = v63 - v62;\n\tv68 = v66 == 0;\n\tv73 = ~v68;\n\tv77 = rhs - methodInfo;\n\tv79 = v77 == 0;\n\tv84 = ~v79;\n\treturnVal1 = v84 | v73;\n\tgoto L_004C;\nL_004C:\n\treturn returnVal1;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static bool operator !=(ObscuredVector3Int lhs, Vector3Int rhs)
		{
			//IL_003f: Expected I4, but got O
			//IL_004d: Expected I4, but got O
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Expected O, but got Unknown
			Vector3Int vector3Int = ((ObscuredVector3Int*)lhs)->InternalDecrypt();
			if ((object)vector3Int == (object)rhs)
			{
				int num = (object)rhs >> 32;
				int num2 = (object)vector3Int >> 32;
				int num3 = num2 - num;
				bool flag = num3 == 0;
				bool flag2 = !flag;
				IntPtr intPtr = default(IntPtr);
				object obj = rhs - (nint)intPtr;
				bool flag3 = obj == null;
				bool flag4 = !flag3;
				return flag4 || flag2;
			}
			return true;
		}

		[Token(Token = "0x600032D")]
		[Address(RVA = "0xBE80F0", Offset = "0xBE80F0", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, other, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A354FB]) = v40;\nL_0019:\n\tgoto L_001C;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, other, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_001C:\n\tv48 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::InternalDecrypt(this);\n\tv53 = *([1A35521]) == 0;\n\tif (v53) goto L_002B;\n\tv54 = other == 0;\n\tv55 = ~v54;\n\tif (v55) goto L_003B;\n\tgoto L_FFFFFFFF;\nL_002B:\n\t*([1A35521]) = 1;\n\tv61 = other == 0;\n\tif (v61) goto L_FFFFFFFF;\nL_003B:\n\tv77 = *([other @ X1 (System.Object)]) != UnityEngine.Vector3Int;\n\tif (v77) goto L_FFFFFFFF;\n\tv108 = \"il2cpp_vm_object_unbox\"(other, other, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv80 = v48 != *([v108 @ X0_v11]);\n\tif (v80) goto L_FFFFFFFF;\n\tv148 = *([v108 @ X0_v11]) >> 0x20;\n\tv116 = v48 >> 0x20;\n\tv151 = v116 - v148;\n\tv153 = v151 == 0;\n\tv131 = *([v108 @ X0_v11+8]) - other;\n\tv127 = v131 == 0;\n\treturnVal1 = v153 & v127;\n\tgoto L_006B;\nL_006B:\n\treturn returnVal1;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override bool Equals(object other)
		{
			//IL_00ea: Expected I4, but got O
			//IL_00f8: Expected I4, but got O
			//IL_012a: Expected O, but got I
			Vector3Int vector3Int = InternalDecrypt();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1A35521]");
			if ((nint)0 != 0)
			{
				if (other != null)
				{
					goto IL_0084;
				}
			}
			else
			{
				_ = 1;
				if (other != null)
				{
					goto IL_0084;
				}
			}
			goto IL_014b;
			IL_014b:
			return false;
			IL_0084:
			if ((object)other.GetType() == typeof(Vector3Int))
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				object obj = default(object);
				if ((object)vector3Int == obj)
				{
					int num = obj >> 32;
					int num2 = (object)vector3Int >> 32;
					int num3 = num2 - num;
					bool flag = num3 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ X0_v11+8]");
					object obj2 = -(nint)other;
					bool flag2 = obj2 == null;
					return flag && flag2;
				}
			}
			goto IL_014b;
		}

		[Token(Token = "0x600032E")]
		[Address(RVA = "0xBE81DC", Offset = "0xBE81DC", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A354FC]) = v37;\nL_0017:\n\tgoto L_001A;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001A:\n\tv45 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::InternalDecrypt(this);\n\tv48 = v45 >> 0x20;\n\tv52 = System.Int32::GetHashCode(&v48 @ X8_v4 (System.Int32));\n\tv57 = System.Int32::GetHashCode(&methodInfo @ X1 (Il2CppMethodInfo));\n\tv62 = System.Int32::GetHashCode(&v45 @ X0_v5 (UnityEngine.Vector3Int));\n\tv48 = v52 >> 0x1C;\n\tv48 = v48 ^ v52;\n\tv48 = v48 ^ v57;\n\tv48 = v48 ^ v57;\n\treturnVal1 = v48 ^ v62;\n\treturn returnVal1;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override int GetHashCode()
		{
			//IL_001d: Expected I4, but got O
			Vector3Int vector3Int = InternalDecrypt();
			int hashCode = ((object)vector3Int >> 32).GetHashCode();
			IntPtr intPtr = default(IntPtr);
			int hashCode2 = ((int*)(&intPtr))->GetHashCode();
			int hashCode3 = ((int*)(&vector3Int))->GetHashCode();
			int num = hashCode >> 28;
			num ^= hashCode;
			num ^= hashCode2;
			num ^= hashCode2;
			return num ^ hashCode3;
		}

		[Token(Token = "0x600032F")]
		[Address(RVA = "0xBE8294", Offset = "0xBE8294", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A354FD]) = v37;\nL_0017:\n\tgoto L_001A;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001A:\n\tv45 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::InternalDecrypt(this);\n\treturnVal1 = 0xBEEC1C(&v45 @ X0_v5 (UnityEngine.Vector3Int), 0, 0, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\treturn returnVal1;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			Vector3Int vector3Int = InternalDecrypt();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BEEC1C (inside CodeStage.AntiCheat.Genuine.CodeHash.AndroidWorker+CodeHashGeneratorCallback::OnError +0x708)");
			string result = default(string);
			return result;
		}

		[Token(Token = "0x6000330")]
		[Address(RVA = "0xBE8310", Offset = "0xBE8310", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, format, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A354FE]) = v40;\nL_0019:\n\tgoto L_001C;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, format, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_001C:\n\tv48 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int::InternalDecrypt(this);\n\treturnVal1 = 0xBEEC1C(&v48 @ X0_v5 (UnityEngine.Vector3Int), format, 0, 0, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\treturn returnVal1;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string ToString(string format)
		{
			Vector3Int vector3Int = InternalDecrypt();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BEEC1C (inside CodeStage.AntiCheat.Genuine.CodeHash.AndroidWorker+CodeHashGeneratorCallback::OnError +0x708)");
			string result = default(string);
			return result;
		}

		[Obsolete("This API is redundant and does not perform any actions. It will be removed in future updates.")]
		[Token(Token = "0x6000331")]
		[Address(RVA = "0xBE8398", Offset = "0xBE8398", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public static void SetNewCryptoKey(int newKey)
		{
		}

		[Obsolete("This API is redundant and does not perform any actions. It will be removed in future updates.")]
		[Token(Token = "0x6000332")]
		[Address(RVA = "0xBE839C", Offset = "0xBE839C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void ApplyNewCryptoKey()
		{
		}

		[Obsolete("Please use new Encrypt(value, key) API instead.", true)]
		[Token(Token = "0x6000333")]
		[Address(RVA = "0xBE83A0", Offset = "0xBE83A0", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static RawEncryptedVector3Int Encrypt(Vector3Int value)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new Decrypt(value, key) API instead.", true)]
		[Token(Token = "0x6000334")]
		[Address(RVA = "0xBE83D8", Offset = "0xBE83D8", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector3Int Decrypt(RawEncryptedVector3Int value)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new GetEncrypted(out key) API instead.", true)]
		[Token(Token = "0x6000335")]
		[Address(RVA = "0xBE8410", Offset = "0xBE8410", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RawEncryptedVector3Int GetEncrypted()
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new SetEncrypted(encrypted, key) API instead.", true)]
		[Token(Token = "0x6000336")]
		[Address(RVA = "0xBE8448", Offset = "0xBE8448", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetEncrypted(RawEncryptedVector3Int encrypted)
		{
		}

		[Token(Token = "0x6000337")]
		[Address(RVA = "0xBE844C", Offset = "0xBE844C", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv12 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int;\n\tv13 = \"il2cpp_codegen_initialize_runtime_metadata\"(v12, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\n\tv32 = 1;\n\t*([1A354FF]) = v32;\nL_0015:\n\tgoto L_001D;\n\tv40 = UnityEngine.Vector3Int;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\n\tv44 = 1;\n\t*([1A35523]) = v44;\nL_001D:\n\tv47 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int;\n\tv50 = UnityEngine.Vector3Int;\n\tv51 = *([v47 @ X9_v1 (Il2CppClass<CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int>)+B8]);\n\tv52 = *([v50 @ X8_v7 (Il2CppClass<UnityEngine.Vector3Int>)+B8]);\n\tv51.Zero = v52.s_Zero;\n\t*([v51 @ X9_v2 (Il2CppStaticFields<CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3Int>)+8]) = *([v52 @ X8_v8 (Il2CppStaticFields<UnityEngine.Vector3Int>)+8]);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static ObscuredVector3Int()
		{
			//IL_0018: Expected I, but got O
			//IL_0026: Expected I, but got O
			//IL_002f: Expected I, but got O
			//IL_0038: Expected I, but got O
			nint num = (nint)typeof(ObscuredVector3Int);
			nint num2 = (nint)typeof(Vector3Int);
			nint num3 = (nint)Zero;
			nint num4 = (nint)Vector3Int.s_Zero;
			Zero = Vector3Int.s_Zero;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X8_v8 (Il2CppStaticFields<UnityEngine.Vector3Int>)+8]");
			_ = 0;
		}
	}
}
