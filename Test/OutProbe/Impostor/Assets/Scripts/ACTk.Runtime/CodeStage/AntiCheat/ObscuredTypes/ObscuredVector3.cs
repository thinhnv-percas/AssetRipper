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
	[Token(Token = "0x2000026")]
	public struct ObscuredVector3 : IObscuredType
	{
		[Serializable]
		[Token(Token = "0x2000027")]
		public struct RawEncryptedVector3
		{
			[Token(Token = "0x40000C2")]
			[FieldOffset(Offset = "0x0")]
			public int x;

			[Token(Token = "0x40000C3")]
			[FieldOffset(Offset = "0x4")]
			public int y;

			[Token(Token = "0x40000C4")]
			[FieldOffset(Offset = "0x8")]
			public int z;
		}

		[Token(Token = "0x40000BC")]
		private static readonly Vector3 Zero;

		[SerializeField]
		[Token(Token = "0x40000BD")]
		[FieldOffset(Offset = "0x0")]
		private int currentCryptoKey;

		[SerializeField]
		[Token(Token = "0x40000BE")]
		[FieldOffset(Offset = "0x4")]
		private RawEncryptedVector3 hiddenValue;

		[SerializeField]
		[Token(Token = "0x40000BF")]
		[FieldOffset(Offset = "0x10")]
		private bool inited;

		[SerializeField]
		[Token(Token = "0x40000C0")]
		[FieldOffset(Offset = "0x14")]
		private Vector3 fakeValue;

		[SerializeField]
		[Token(Token = "0x40000C1")]
		[FieldOffset(Offset = "0x20")]
		private bool fakeValueActive;

		[Token(Token = "0x17000012")]
		public unsafe float x
		{
			[Token(Token = "0x60002D9")]
			[Address(RVA = "0xBE4EE8", Offset = "0xBE4EE8", Length = "0x130")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = System.Math;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A354BD]) = v38;\nL_0016:\n\tv40 = this.hiddenValue;\n\tCodeStage.AntiCheat.Common.ACTkByte4::UnShuffle(&v40 @ X8_v3 (CodeStage.AntiCheat.Common.ACTkByte4));\n\tv48 = v40 ^ this.currentCryptoKey;\n\tv50 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv52 = v50 == 0;\n\tif (v52) goto L_0073;\n\tv54 = ~this.fakeValueActive;\n\tif (v54) goto L_0073;\n\tgoto L_0037;\n\tv147 = \"il2cpp_codegen_runtime_class_init\"(v110, v43, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0037:\n\tgoto L_003F;\n\tv156 = 0xB348B0(v151, v43, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_003F:\n\tgoto L_0042;\n\tv164 = 0xB348B0(v159, v43, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0042:\n\tv101 = v165.<Instance>k__BackingField;\n\t// 70 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv61 = v28 <= v101.vector3Epsilon;\n\tif (v61) goto L_0073;\n\tgoto L_0062;\n\tv178 = 0xB348B0(v173, v43, v21, v22, v23, v24, v25, v26, v88, v28, v29, v30, v31, v32, v33, v34);\nL_0062:\n\tgoto L_006B;\n\tv186 = 0xB348B0(v181, v43, v21, v22, v23, v24, v25, v26, v88, v28, v29, v30, v31, v32, v33, v34);\nL_006B:\n\tv92 = CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector>::OnCheatingDetected(v171.<Instance>k__BackingField);\nL_0073:\n\treturn v48;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
					if ((float)obj > _003CInstance_003Ek__BackingField.vector3Epsilon)
					{
						KeepAliveBehaviour<ObscuredCheatingDetector>.Instance.OnCheatingDetected();
					}
				}
				return num;
			}
			[Token(Token = "0x60002DA")]
			[Address(RVA = "0xBE5018", Offset = "0xBE5018", Length = "0xB8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.currentCryptoKey;\n\tv10 = v10 ^ value;\n\tCodeStage.AntiCheat.Common.ACTkByte4::Shuffle(&v10 @ X8_v1 (System.Int32));\n\tthis.hiddenValue = v10;\n\tv22 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv24 = v22 == 0;\n\tif (v24) goto L_FFFFFFFF;\n\tv25 = this->monitor;\n\tthis.fakeValue = value;\n\tCodeStage.AntiCheat.Common.ACTkByte4::UnShuffle(&v25 @ X8_v6 (CodeStage.AntiCheat.Common.ACTkByte4));\n\tv32 = this->monitor+0x4;\n\tv10 = v25 ^ this.currentCryptoKey;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3)+18]) = v10;\n\tCodeStage.AntiCheat.Common.ACTkByte4::UnShuffle(&v32 @ X9_v3 (CodeStage.AntiCheat.Common.ACTkByte4));\n\tv10 = v32 ^ this.currentCryptoKey;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3)+1C]) = v10;\n\tgoto L_002C;\nL_002C:\n\tthis.fakeValueActive = v47;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0012: Unknown result type (might be due to invalid IL or missing references)
				//IL_0017: Expected I4, but got Unknown
				//IL_002a: Expected O, but got I4
				//IL_0065: Expected O, but got I
				//IL_006f: Expected O, but got F4
				//IL_0088: Expected O, but got I
				//IL_0092: Unknown result type (might be due to invalid IL or missing references)
				//IL_0097: Expected I4, but got Unknown
				//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
				//IL_00b9: Expected I4, but got Unknown
				int num = currentCryptoKey;
				num ^= value;
				((ACTkByte4*)(&num))->Shuffle();
				hiddenValue = (RawEncryptedVector3)num;
				bool flag;
				if (ObscuredCheatingDetector.ExistsAndIsRunning)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3)+8]");
					ACTkByte4 aCTkByte = (ACTkByte4)0;
					fakeValue = (Vector3)value;
					aCTkByte.UnShuffle();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3)+C]");
					ACTkByte4 aCTkByte2 = (ACTkByte4)0;
					num = aCTkByte ^ currentCryptoKey;
					aCTkByte2.UnShuffle();
					num = aCTkByte2 ^ currentCryptoKey;
					flag = true;
				}
				else
				{
					flag = false;
				}
				fakeValueActive = flag;
			}
		}

		[Token(Token = "0x17000013")]
		public float y
		{
			[Token(Token = "0x60002DB")]
			[Address(RVA = "0xBE50D0", Offset = "0xBE50D0", Length = "0x134")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = System.Math;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A354BE]) = v38;\nL_0015:\n\tv39 = this->monitor;\n\tCodeStage.AntiCheat.Common.ACTkByte4::UnShuffle(&v39 @ X8_v3 (CodeStage.AntiCheat.Common.ACTkByte4));\n\tv48 = v39 ^ this.currentCryptoKey;\n\tv50 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv52 = v50 == 0;\n\tif (v52) goto L_0073;\n\tv54 = ~this.fakeValueActive;\n\tif (v54) goto L_0073;\n\tgoto L_0037;\n\tv147 = \"il2cpp_codegen_runtime_class_init\"(v110, v43, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0037:\n\tgoto L_003F;\n\tv156 = 0xB348B0(v151, v43, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_003F:\n\tgoto L_0042;\n\tv164 = 0xB348B0(v159, v43, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0042:\n\tv101 = v165.<Instance>k__BackingField;\n\t// 70 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv61 = v28 <= v101.vector3Epsilon;\n\tif (v61) goto L_0073;\n\tgoto L_0062;\n\tv178 = 0xB348B0(v173, v43, v21, v22, v23, v24, v25, v26, v88, v28, v29, v30, v31, v32, v33, v34);\nL_0062:\n\tgoto L_006B;\n\tv186 = 0xB348B0(v181, v43, v21, v22, v23, v24, v25, v26, v88, v28, v29, v30, v31, v32, v33, v34);\nL_006B:\n\tv92 = CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector>::OnCheatingDetected(v171.<Instance>k__BackingField);\nL_0073:\n\treturn v48;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0096: Expected O, but got I
				//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ae: Expected I4, but got Unknown
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3)+8]");
				ACTkByte4 aCTkByte = (ACTkByte4)0;
				aCTkByte.UnShuffle();
				int num = aCTkByte ^ currentCryptoKey;
				if (ObscuredCheatingDetector.ExistsAndIsRunning && fakeValueActive)
				{
					ObscuredCheatingDetector _003CInstance_003Ek__BackingField = KeepAliveBehaviour<ObscuredCheatingDetector>.Instance;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
					object obj = default(object);
					if ((float)obj > _003CInstance_003Ek__BackingField.vector3Epsilon)
					{
						KeepAliveBehaviour<ObscuredCheatingDetector>.Instance.OnCheatingDetected();
					}
				}
				return num;
			}
			[Token(Token = "0x60002DC")]
			[Address(RVA = "0xBE5204", Offset = "0xBE5204", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.currentCryptoKey;\n\tv10 = v10 ^ value;\n\tCodeStage.AntiCheat.Common.ACTkByte4::Shuffle(&v10 @ X8_v1 (System.Int32));\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3)+8]) = v10;\n\tv22 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv24 = v22 == 0;\n\tif (v24) goto L_FFFFFFFF;\n\tv26 = this.hiddenValue;\n\tCodeStage.AntiCheat.Common.ACTkByte4::UnShuffle(&v26 @ X8_v6 (CodeStage.AntiCheat.Common.ACTkByte4));\n\tv32 = this->monitor+0x4;\n\tv10 = v26 ^ this.currentCryptoKey;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3)+18]) = value;\n\tthis.fakeValue = v10;\n\tCodeStage.AntiCheat.Common.ACTkByte4::UnShuffle(&v32 @ X9_v3 (CodeStage.AntiCheat.Common.ACTkByte4));\n\tv10 = v32 ^ this.currentCryptoKey;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3)+1C]) = v10;\n\tgoto L_002C;\nL_002C:\n\tthis.fakeValueActive = v47;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0012: Unknown result type (might be due to invalid IL or missing references)
				//IL_0017: Expected I4, but got Unknown
				//IL_0073: Expected O, but got I
				//IL_007d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0082: Expected I4, but got Unknown
				//IL_0091: Expected O, but got I4
				//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ae: Expected I4, but got Unknown
				int num = currentCryptoKey;
				System.Runtime.CompilerServices.Unsafe.As<int, ACTkByte4>(ref num ^ value).Shuffle();
				bool flag;
				if (ObscuredCheatingDetector.ExistsAndIsRunning)
				{
					ACTkByte4 aCTkByte = (ACTkByte4)hiddenValue;
					aCTkByte.UnShuffle();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3)+C]");
					ACTkByte4 aCTkByte2 = (ACTkByte4)0;
					num = aCTkByte ^ currentCryptoKey;
					fakeValue = (Vector3)num;
					aCTkByte2.UnShuffle();
					num = aCTkByte2 ^ currentCryptoKey;
					flag = true;
				}
				else
				{
					flag = false;
				}
				fakeValueActive = flag;
			}
		}

		[Token(Token = "0x17000014")]
		public float z
		{
			[Token(Token = "0x60002DD")]
			[Address(RVA = "0xBE52B8", Offset = "0xBE52B8", Length = "0x134")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = System.Math;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A354BF]) = v38;\nL_0015:\n\tv39 = this->monitor+0x4;\n\tCodeStage.AntiCheat.Common.ACTkByte4::UnShuffle(&v39 @ X8_v3 (CodeStage.AntiCheat.Common.ACTkByte4));\n\tv48 = v39 ^ this.currentCryptoKey;\n\tv50 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv52 = v50 == 0;\n\tif (v52) goto L_0073;\n\tv54 = ~this.fakeValueActive;\n\tif (v54) goto L_0073;\n\tgoto L_0037;\n\tv147 = \"il2cpp_codegen_runtime_class_init\"(v110, v43, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0037:\n\tgoto L_003F;\n\tv156 = 0xB348B0(v151, v43, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_003F:\n\tgoto L_0042;\n\tv164 = 0xB348B0(v159, v43, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0042:\n\tv101 = v165.<Instance>k__BackingField;\n\t// 70 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv61 = v28 <= v101.vector3Epsilon;\n\tif (v61) goto L_0073;\n\tgoto L_0062;\n\tv178 = 0xB348B0(v173, v43, v21, v22, v23, v24, v25, v26, v88, v28, v29, v30, v31, v32, v33, v34);\nL_0062:\n\tgoto L_006B;\n\tv186 = 0xB348B0(v181, v43, v21, v22, v23, v24, v25, v26, v88, v28, v29, v30, v31, v32, v33, v34);\nL_006B:\n\tv92 = CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector>::OnCheatingDetected(v171.<Instance>k__BackingField);\nL_0073:\n\treturn v48;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0096: Expected O, but got I
				//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ae: Expected I4, but got Unknown
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3)+C]");
				ACTkByte4 aCTkByte = (ACTkByte4)0;
				aCTkByte.UnShuffle();
				int num = aCTkByte ^ currentCryptoKey;
				if (ObscuredCheatingDetector.ExistsAndIsRunning && fakeValueActive)
				{
					ObscuredCheatingDetector _003CInstance_003Ek__BackingField = KeepAliveBehaviour<ObscuredCheatingDetector>.Instance;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
					object obj = default(object);
					if ((float)obj > _003CInstance_003Ek__BackingField.vector3Epsilon)
					{
						KeepAliveBehaviour<ObscuredCheatingDetector>.Instance.OnCheatingDetected();
					}
				}
				return num;
			}
			[Token(Token = "0x60002DE")]
			[Address(RVA = "0xBE53EC", Offset = "0xBE53EC", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.currentCryptoKey;\n\tv10 = v10 ^ value;\n\tCodeStage.AntiCheat.Common.ACTkByte4::Shuffle(&v10 @ X8_v1 (System.Int32));\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3)+C]) = v10;\n\tv22 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv24 = v22 == 0;\n\tif (v24) goto L_FFFFFFFF;\n\tv26 = this.hiddenValue;\n\tCodeStage.AntiCheat.Common.ACTkByte4::UnShuffle(&v26 @ X8_v6 (CodeStage.AntiCheat.Common.ACTkByte4));\n\tv32 = this->monitor;\n\tv10 = v26 ^ this.currentCryptoKey;\n\tthis.fakeValue = v10;\n\tCodeStage.AntiCheat.Common.ACTkByte4::UnShuffle(&v32 @ X9_v3 (CodeStage.AntiCheat.Common.ACTkByte4));\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3)+1C]) = value;\n\tv10 = v32 ^ this.currentCryptoKey;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3)+18]) = v10;\n\tgoto L_002C;\nL_002C:\n\tthis.fakeValueActive = v47;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0012: Unknown result type (might be due to invalid IL or missing references)
				//IL_0017: Expected I4, but got Unknown
				//IL_0073: Expected O, but got I
				//IL_007d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0082: Expected I4, but got Unknown
				//IL_008c: Expected O, but got I4
				//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ae: Expected I4, but got Unknown
				int num = currentCryptoKey;
				System.Runtime.CompilerServices.Unsafe.As<int, ACTkByte4>(ref num ^ value).Shuffle();
				bool flag;
				if (ObscuredCheatingDetector.ExistsAndIsRunning)
				{
					ACTkByte4 aCTkByte = (ACTkByte4)hiddenValue;
					aCTkByte.UnShuffle();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3)+8]");
					ACTkByte4 aCTkByte2 = (ACTkByte4)0;
					num = aCTkByte ^ currentCryptoKey;
					fakeValue = (Vector3)num;
					aCTkByte2.UnShuffle();
					num = aCTkByte2 ^ currentCryptoKey;
					flag = true;
				}
				else
				{
					flag = false;
				}
				fakeValueActive = flag;
			}
		}

		[Token(Token = "0x17000015")]
		public float this[int index]
		{
			[Token(Token = "0x60002DF")]
			[Address(RVA = "0xBE54A0", Offset = "0xBE54A0", Length = "0x104")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, index, methodInfo, v21, v22, v23, v24, v25, returnVal4, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A354C0]) = v36;\nL_0016:\n\tv41 = index == 2;\n\tif (v41) goto L_003F;\n\tv50 = index == 1;\n\tif (v50) goto L_004F;\n\tv61 = index == 0;\n\tv62 = ~v61;\n\tif (v62) goto L_005C;\n\tgoto L_0037;\n\tv94 = \"il2cpp_codegen_runtime_class_init\"(v79, index, methodInfo, v21, v22, v23, v24, v25, returnVal4, v27, v28, v29, v30, v31, v32, v33);\nL_0037:\n\treturnVal3 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::get_x(this);\n\treturn returnVal3;\nL_003F:\n\tgoto L_0047;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v57, index, methodInfo, v21, v22, v23, v24, v25, returnVal4, v27, v28, v29, v30, v31, v32, v33);\nL_0047:\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::get_z(this);\n\treturn returnVal1;\nL_004F:\n\tgoto L_0057;\n\tv86 = \"il2cpp_codegen_runtime_class_init\"(v65, index, methodInfo, v21, v22, v23, v24, v25, returnVal4, v27, v28, v29, v30, v31, v32, v33);\nL_0057:\n\treturnVal2 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::get_y(this);\n\treturn returnVal2;\nL_005C:\n\tv102 = new System.IndexOutOfRangeException();\n\tSystem.IndexOutOfRangeException::.ctor(v102, \"Invalid ObscuredVector3 index!\");\n\tthrow v102;\n\treturn returnVal4;\n// 80 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
					IndexOutOfRangeException ex = new IndexOutOfRangeException("Invalid ObscuredVector3 index!");
					throw ex;
				}
				}
			}
			[Token(Token = "0x60002E0")]
			[Address(RVA = "0xBE55A4", Offset = "0xBE55A4", Length = "0x124")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, index, methodInfo, v25, v26, v27, v28, v29, value, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A354C1]) = v39;\nL_0018:\n\tv44 = index == 2;\n\tif (v44) goto L_0043;\n\tv53 = index == 1;\n\tif (v53) goto L_0055;\n\tv64 = index == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_0064;\n\tgoto L_003B;\n\tv99 = \"il2cpp_codegen_runtime_class_init\"(v83, index, methodInfo, v25, v26, v27, v28, v29, value, v30, v31, v32, v33, v34, v35, v36);\nL_003B:\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::set_x(this, value);\n\treturn;\nL_0043:\n\tgoto L_004D;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v60, index, methodInfo, v25, v26, v27, v28, v29, value, v30, v31, v32, v33, v34, v35, v36);\nL_004D:\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::set_z(this, value);\n\treturn;\nL_0055:\n\tgoto L_005F;\n\tv90 = \"il2cpp_codegen_runtime_class_init\"(v68, index, methodInfo, v25, v26, v27, v28, v29, value, v30, v31, v32, v33, v34, v35, v36);\nL_005F:\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::set_y(this, value);\n\treturn;\nL_0064:\n\tv108 = new System.IndexOutOfRangeException();\n\tSystem.IndexOutOfRangeException::.ctor(v108, \"Invalid ObscuredVector3 index!\");\n\tthrow v108;\n\treturn;\n// 88 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
					IndexOutOfRangeException ex = new IndexOutOfRangeException("Invalid ObscuredVector3 index!");
					throw ex;
				}
				}
			}
		}

		[Token(Token = "0x60002D7")]
		[Address(RVA = "0xBE4C20", Offset = "0xBE4C20", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, value, v0, v2, v39, v40, v41, v42, v43);\n\tv46 = 1;\n\t*([1A354BB]) = v46;\nL_001F:\n\tgoto L_0021;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v33, v34, v35, v36, v37, v38, value, v0, v2, v39, v40, v41, v42, v43);\nL_0021:\n\tv53 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tthis.currentCryptoKey = v53;\n\tv58 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::Encrypt(value, v53);\n\tthis.hiddenValue = v58;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3)+C]) = methodInfo;\n\tv60 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tgoto L_003E;\n\tv65 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3;\n\tv66 = *([v65 @ X0_v9+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tif (v68) goto L_FFFFFFFF;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v65, methodInfo, v33, v34, v35, v36, v37, v38, v54, v55, v56, v39, v40, v41, v42, v43);\n\tv90 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3;\n\tv79 = *([v70 @ X0_v10+B8]);\n\tv73 = *([v79 @ X8_v7]);\n\tv75 = *([v79 @ X8_v7+4]);\n\tv77 = *([v79 @ X8_v7+8]);\nL_003E:\n\tthis.fakeValue = value;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3)+18]) = value.y;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3)+1C]) = value.z;\n\tthis.fakeValueActive = v60;\n\tthis.inited = 1;\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private ObscuredVector3(Vector3 value)
		{
			RawEncryptedVector3 rawEncryptedVector = Encrypt(key: currentCryptoKey = RandomUtils.GenerateIntKey(), value: value);
			hiddenValue = rawEncryptedVector;
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			fakeValue = value;
			_ = value.y;
			_ = value.z;
			fakeValueActive = existsAndIsRunning;
			inited = true;
		}

		[Token(Token = "0x60002D8")]
		[Address(RVA = "0xBE4D7C", Offset = "0xBE4D7C", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv30 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, x, y, z, v39, v40, v41, v42, v43);\n\tv46 = 1;\n\t*([1A354BC]) = v46;\nL_001D:\n\tgoto L_001F;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v33, v34, v35, v36, v37, v38, x, y, z, v39, v40, v41, v42, v43);\nL_001F:\n\tv53 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tthis.currentCryptoKey = v53;\n\tv57 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::Encrypt(x, y, z, v53);\n\tthis.hiddenValue = v57;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3)+C]) = methodInfo;\n\tv59 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv61 = v59 == 0;\n\tif (v61) goto L_FFFFFFFF;\n\tthis.fakeValue = x;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3)+18]) = y;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3)+1C]) = z;\n\tgoto L_003E;\n\tgoto L_0038;\n\tv86 = \"il2cpp_codegen_runtime_class_init\"(v63, methodInfo, v33, v34, v35, v36, v37, v38, v54, v55, v56, v39, v40, v41, v42, v43);\n\tv87 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3;\nL_0038:\n\tv88 = *([v74 @ X0_v10 (Il2CppClass<CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3>)+B8]);\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3)+1C]) = *([v88 @ X9_v2 (Il2CppStaticFields<CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3>)+8]);\n\tthis.fakeValue = v88.Zero;\nL_003E:\n\tthis.fakeValueActive = v76;\n\tthis.inited = 1;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObscuredVector3(float x, float y, float z)
		{
			//IL_009b: Expected I, but got O
			//IL_00c4: Expected I, but got O
			//IL_0075: Expected O, but got F4
			RawEncryptedVector3 rawEncryptedVector = Encrypt(x, y, z, currentCryptoKey = RandomUtils.GenerateIntKey());
			hiddenValue = rawEncryptedVector;
			bool flag;
			if (ObscuredCheatingDetector.ExistsAndIsRunning)
			{
				fakeValue = (Vector3)x;
				flag = true;
			}
			else
			{
				nint num = (nint)typeof(ObscuredVector3);
				nint num2 = (nint)Zero;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ X9_v2 (Il2CppStaticFields<CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3>)+8]");
				_ = 0;
				fakeValue = Zero;
				flag = false;
			}
			fakeValueActive = flag;
			inited = true;
		}

		[Token(Token = "0x60002E1")]
		[Address(RVA = "0xBE4CF8", Offset = "0xBE4CF8", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, value, v0, v2, v39, v40, v41, v42, v43);\n\tv46 = 1;\n\t*([1A354C2]) = v46;\nL_001F:\n\tgoto L_0025;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v33, v34, v35, v36, v37, v38, value, v0, v2, v39, v40, v41, v42, v43);\nL_0025:\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::Encrypt(value, value.y, value.z, key);\n\treturn returnVal1;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static RawEncryptedVector3 Encrypt(Vector3 value, int key)
		{
			Vector3 vector = default(Vector3);
			return Encrypt(vector.x, value.y, value.z, key);
		}

		[Token(Token = "0x60002E2")]
		[Address(RVA = "0xBE4E5C", Offset = "0xBE4E5C", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = x ^ key;\n\tCodeStage.AntiCheat.Common.ACTkByte4::Shuffle(&v16 @ X8_v2 (System.Int32));\n\tv16 = y ^ key;\n\tCodeStage.AntiCheat.Common.ACTkByte4::Shuffle(&v16 @ X8_v2 (System.Int32));\n\tv16 = z ^ key;\n\tCodeStage.AntiCheat.Common.ACTkByte4::Shuffle(&v16 @ X8_v2 (System.Int32));\n\tv36 = v16 & 0xFFFFFFFF;\n\tv37 = v36 << 0x20;\n\tv38 = v16 & 0xFFFFFFFF;\n\tv39 = v38 | v37;\n\treturn v39;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static RawEncryptedVector3 Encrypt(float x, float y, float z, int key)
		{
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected I4, but got Unknown
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Expected I4, but got Unknown
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Expected I4, but got Unknown
			//IL_0059: Expected I4, but got I8
			//IL_0079: Expected I4, but got I8
			//IL_008b: Expected O, but got I4
			System.Runtime.CompilerServices.Unsafe.As<int, ACTkByte4>(ref x ^ key).Shuffle();
			System.Runtime.CompilerServices.Unsafe.As<int, ACTkByte4>(ref y ^ key).Shuffle();
			int num = z ^ key;
			((ACTkByte4*)(&num))->Shuffle();
			int num2 = (int)(num & 0xFFFFFFFFL);
			int num3 = num2 << 32;
			int num4 = (int)(num & 0xFFFFFFFFL);
			int num5 = num4 | num3;
			return (RawEncryptedVector3)num5;
		}

		[Token(Token = "0x60002E3")]
		[Address(RVA = "0xBE56C8", Offset = "0xBE56C8", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = value >> 0x20;\n\tCodeStage.AntiCheat.Common.ACTkByte4::UnShuffle(&v18 @ stack_-48_v2 (CodeStage.AntiCheat.Common.ACTkByte4));\n\tv26 = v18 ^ methodInfo;\n\tCodeStage.AntiCheat.Common.ACTkByte4::UnShuffle(&v14 @ X21_v1 (System.Int32));\n\tCodeStage.AntiCheat.Common.ACTkByte4::UnShuffle(&key @ X1 (System.Int32));\n\treturn v26;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static Vector3 Decrypt(RawEncryptedVector3 value, int key)
		{
			//IL_000e: Expected I4, but got O
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Expected I4, but got Unknown
			//IL_0041: Expected O, but got I4
			int num = (object)value >> 32;
			ACTkByte4 aCTkByte = default(ACTkByte4);
			aCTkByte.UnShuffle();
			IntPtr intPtr = default(IntPtr);
			int num2 = (int)(aCTkByte ^ (nint)intPtr);
			((ACTkByte4*)(&num))->UnShuffle();
			int num3 = default(int);
			((ACTkByte4*)(&num3))->UnShuffle();
			return (Vector3)num2;
		}

		[Token(Token = "0x60002E4")]
		[Address(RVA = "0xBE5754", Offset = "0xBE5754", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv30 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, key, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 1;\n\t*([1A354C3]) = v47;\nL_0021:\n\tgoto L_0023;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, key, methodInfo, v32, v33, v34, v35, v36, v49, v38, v39, v40, v41, v42, v43, v44);\nL_0023:\n\tv58 = key & 0xFFFFFFFF;\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::SetEncrypted(&v60 @ stack_-70_v2 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3), encrypted, v58);\n\treturnBuffer.fakeValueActive = 0;\n\treturnBuffer.currentCryptoKey = v60;\n\treturnBuffer.inited = 0;\n\treturn &v60 @ stack_-70_v2 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3);\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredVector3 FromEncrypted(RawEncryptedVector3 encrypted, int key)
		{
			//IL_0017: Expected I4, but got I8
			//IL_0031: Expected native int or pointer, but got O
			//IL_0043: Expected I4, but got O
			//IL_003e: Expected native int or pointer, but got O
			//IL_004c: Expected native int or pointer, but got O
			//IL_0056: Expected O, but got Ref
			int key2 = (int)(key & 0xFFFFFFFFL);
			ObscuredVector3 obscuredVector = default(ObscuredVector3);
			obscuredVector.SetEncrypted(encrypted, key2);
			ObscuredVector3 obscuredVector2 = default(ObscuredVector3);
			((ObscuredVector3*)(nint)obscuredVector2)->fakeValueActive = false;
			((ObscuredVector3*)(nint)obscuredVector2)->currentCryptoKey = (int)obscuredVector;
			((ObscuredVector3*)(nint)obscuredVector2)->inited = false;
			return (ObscuredVector3)(&obscuredVector);
		}

		[Token(Token = "0x60002E5")]
		[Address(RVA = "0xBE4CF4", Offset = "0xBE4CF4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\treturn returnVal1;\n")]
		public static int GenerateKey()
		{
			return RandomUtils.GenerateIntKey();
		}

		[Token(Token = "0x60002E6")]
		[Address(RVA = "0xBE5898", Offset = "0xBE5898", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv40 = Il2CppMethodInfo;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, v42, v43, v44, v45, v46, v47, v48, vector1, v0, v2, vector2, v3, v5, v49, v50);\n\tv63 = System.Math;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, v42, v43, v44, v45, v46, v47, v48, vector1, v0, v2, vector2, v3, v5, v49, v50);\n\tv55 = 1;\n\t*([1A354C4]) = v55;\nL_002B:\n\tgoto L_0033;\n\tv64 = 0xB348B0(v57, v42, v43, v44, v45, v46, v47, v48, vector1, v0, v2, vector2, v3, v5, v49, v50);\nL_0033:\n\tgoto L_0036;\n\tv72 = 0xB348B0(v67, v42, v43, v44, v45, v46, v47, v48, vector1, v0, v2, vector2, v3, v5, v49, v50);\nL_0036:\n\tv75 = v74.<Instance>k__BackingField;\n\tgoto L_0042;\n\tv85 = \"il2cpp_codegen_runtime_class_init\"(v80, v42, v43, v44, v45, v46, v47, v48, vector1, v0, v2, vector2, v3, v5, v49, v50);\nL_0042:\n\t// 66 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv96 = vector1 >= v75.vector3Epsilon;\n\tif (v96) goto L_FFFFFFFF;\n\tgoto L_0054;\n\tv179 = \"il2cpp_codegen_runtime_class_init\"(v97, v42, v43, v44, v45, v46, v47, v48, vector1, v0, v2, vector2, v3, v5, v49, v50);\nL_0054:\n\t// 84 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv102 = vector1 >= v75.vector3Epsilon;\n\tif (v102) goto L_FFFFFFFF;\n\tgoto L_0066;\n\tv194 = \"il2cpp_codegen_runtime_class_init\"(v192, v42, v43, v44, v45, v46, v47, v48, vector1, v0, v2, vector2, v3, v5, v49, v50);\nL_0066:\n\t// 102 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv187 = vector1 - v75.vector3Epsilon;\n\tv186 = v187 < 0;\n\tgoto L_007E;\nL_007E:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 98 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool CompareVectorsWithTolerance(Vector3 vector1, Vector3 vector2)
		{
			ObscuredCheatingDetector _003CInstance_003Ek__BackingField = KeepAliveBehaviour<ObscuredCheatingDetector>.Instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
			Vector3 vector3 = default(Vector3);
			if (vector3.x < _003CInstance_003Ek__BackingField.vector3Epsilon)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
				if (vector3.x < _003CInstance_003Ek__BackingField.vector3Epsilon)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
					float num = vector3.x - _003CInstance_003Ek__BackingField.vector3Epsilon;
					return num < 0f;
				}
			}
			return false;
		}

		[Token(Token = "0x60002E7")]
		[Address(RVA = "0xBE59B8", Offset = "0xBE59B8", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([key @ X1 (System.Int32&)]) = this.currentCryptoKey;\n\treturn this.hiddenValue;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe RawEncryptedVector3 GetEncrypted(out int key)
		{
			key = default(int);
			ref int reference = ref *(int*)currentCryptoKey;
			return hiddenValue;
		}

		[Token(Token = "0x60002E8")]
		[Address(RVA = "0xBE57F8", Offset = "0xBE57F8", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, encrypted, key, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A354C5]) = v42;\nL_0018:\n\tthis.hiddenValue = encrypted;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3)+C]) = key;\n\tthis.inited = 1;\n\tthis.currentCryptoKey = methodInfo;\n\tv45 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tthis.fakeValueActive = 0;\n\tv47 = v45 == 0;\n\tif (v47) goto L_0039;\n\tgoto L_002A;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v50, encrypted, key, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_002A:\n\tv59 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::InternalDecrypt(this);\n\tthis.fakeValue = v59;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3)+18]) = v59.y;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3)+1C]) = v59.z;\n\tthis.fakeValueActive = 1;\nL_0039:\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetEncrypted(RawEncryptedVector3 encrypted, int key)
		{
			hiddenValue = encrypted;
			inited = true;
			IntPtr intPtr = default(IntPtr);
			currentCryptoKey = (int)(nint)intPtr;
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			fakeValueActive = false;
			if (existsAndIsRunning)
			{
				Vector3 vector = (fakeValue = InternalDecrypt());
				_ = vector.y;
				_ = vector.z;
				fakeValueActive = true;
			}
		}

		[Token(Token = "0x60002E9")]
		[Address(RVA = "0xBE5B88", Offset = "0xBE5B88", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A354C6]) = v37;\nL_0017:\n\tgoto L_001F;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001F:\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::InternalDecrypt(this);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Vector3 GetDecrypted()
		{
			return InternalDecrypt();
		}

		[Token(Token = "0x60002EA")]
		[Address(RVA = "0xBE5BDC", Offset = "0xBE5BDC", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv24 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 1;\n\t*([1A354C7]) = v43;\nL_001A:\n\tgoto L_001D;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_001D:\n\tv51 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::InternalDecrypt(this);\n\tv57 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tthis.currentCryptoKey = v57;\n\tv62 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::Encrypt(v51, v57);\n\tthis.hiddenValue = v62;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3)+C]) = methodInfo;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RandomizeCryptoKey()
		{
			Vector3 value = InternalDecrypt();
			RawEncryptedVector3 rawEncryptedVector = Encrypt(value, currentCryptoKey = RandomUtils.GenerateIntKey());
			hiddenValue = rawEncryptedVector;
		}

		[Token(Token = "0x60002EB")]
		[Address(RVA = "0xBE59D0", Offset = "0xBE59D0", Length = "0x1B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv32 = Il2CppMethodInfo;\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv58 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv52 = 1;\n\t*([1A354C8]) = v52;\nL_001F:\n\tv56 = ~this.inited;\n\tif (v56) goto L_0070;\n\tgoto L_002D;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v59, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_002D:\n\tv75 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::Decrypt(this.hiddenValue, *([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3)+C]));\n\tv85 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv94 = v85 == 0;\n\tif (v94) goto L_009A;\n\tv105 = ~this.fakeValueActive;\n\tif (v105) goto L_009A;\n\tgoto L_004C;\n\tv206 = \"il2cpp_codegen_runtime_class_init\"(v172, v73, v74, v36, v37, v38, v39, v40, v75, v79, v80, v44, v45, v46, v47, v48);\nL_004C:\n\tv148 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::CompareVectorsWithTolerance(v75, this.fakeValue);\n\tv209 = v148 == 0;\n\tv151 = ~v209;\n\tif (v151) goto L_009A;\n\tgoto L_0061;\n\tv218 = 0xB348B0(v213, v73, v74, v36, v37, v38, v39, v40, returnVal2, v139, v137, v126, v124, v122, v47, v48);\nL_0061:\n\tgoto L_006A;\n\tv226 = 0xB348B0(v221, v73, v74, v36, v37, v38, v39, v40, returnVal2, v139, v137, v126, v124, v122, v47, v48);\nL_006A:\n\tv149 = CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector>::OnCheatingDetected(v204.<Instance>k__BackingField);\n\tgoto L_009A;\nL_0070:\n\tgoto L_0072;\n\tv76 = \"il2cpp_codegen_runtime_class_init\"(v66, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_0072:\n\tv78 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tthis.currentCryptoKey = v78;\n\tv92 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::Encrypt(v87.Zero, v78);\n\tthis.hiddenValue = v92;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3)+C]) = methodInfo;\n\tv95 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3;\n\tv97 = *([v95 @ X8_v8 (Il2CppClass<CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3>)+B8]);\n\tthis.inited = 1;\n\tthis.fakeValueActive = 0;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3)+1C]) = *([v97 @ X9_v2 (Il2CppStaticFields<CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3>)+8]);\n\tthis.fakeValue = v97.Zero;\n\tv135 = v100.Zero;\nL_009A:\n\treturn v135;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 111 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private Vector3 InternalDecrypt()
		{
			//IL_0130: Expected I, but got O
			//IL_0139: Expected I, but got O
			Vector3 result;
			if (inited)
			{
				RawEncryptedVector3 value = hiddenValue;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3)+C]");
				Vector3 vector = Decrypt(value, 0);
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
				RawEncryptedVector3 rawEncryptedVector = Encrypt(key: currentCryptoKey = RandomUtils.GenerateIntKey(), value: Zero);
				hiddenValue = rawEncryptedVector;
				nint num = (nint)typeof(ObscuredVector3);
				nint num2 = (nint)Zero;
				inited = true;
				fakeValueActive = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ X9_v2 (Il2CppStaticFields<CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3>)+8]");
				_ = 0;
				fakeValue = Zero;
				result = Zero;
			}
			return result;
		}

		[Token(Token = "0x60002EC")]
		[Address(RVA = "0xBE5C70", Offset = "0xBE5C70", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnBuffer.fakeValueActive = 0;\n\treturnBuffer.currentCryptoKey = 0;\n\treturnBuffer.inited = 0;\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::.ctor(returnBuffer, value);\n\treturn returnBuffer;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static implicit operator ObscuredVector3(Vector3 value)
		{
			//IL_0009: Expected native int or pointer, but got O
			//IL_0017: Expected native int or pointer, but got O
			//IL_0025: Expected native int or pointer, but got O
			//IL_0032: Expected native int or pointer, but got O
			ObscuredVector3 obscuredVector = default(ObscuredVector3);
			((ObscuredVector3*)(nint)obscuredVector)->fakeValueActive = false;
			((ObscuredVector3*)(nint)obscuredVector)->currentCryptoKey = 0;
			((ObscuredVector3*)(nint)obscuredVector)->inited = false;
			*(ObscuredVector3*)(nint)obscuredVector = new ObscuredVector3(value);
			return obscuredVector;
		}

		[Token(Token = "0x60002ED")]
		[Address(RVA = "0xBE5C84", Offset = "0xBE5C84", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A354C9]) = v37;\nL_0017:\n\tgoto L_001F;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001F:\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::InternalDecrypt(value);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static implicit operator Vector3(ObscuredVector3 value)
		{
			return ((ObscuredVector3*)value)->InternalDecrypt();
		}

		[Token(Token = "0x60002EE")]
		[Address(RVA = "0xBE5CD8", Offset = "0xBE5CD8", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv32 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3;\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, b, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 1;\n\t*([1A354CA]) = v50;\nL_001E:\n\tgoto L_0021;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v51, b, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0021:\n\tv58 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::InternalDecrypt(a);\n\tv65 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::InternalDecrypt(b);\n\tv68 = v58 + v65;\n\tv69 = v58.y + v65.y;\n\tv70 = v58.z + v65.z;\n\tv73 = 0;\n\t// 51 MakeStruct v76 @ AGGBE9D6C_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v68 @ V0_v3 (System.Single), v69 @ V1_v3 (System.Single), v70 @ V2_v3 (System.Single)\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::.ctor(&v73 @ stack_-80_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3), v76);\n\treturnBuffer.fakeValueActive = 0;\n\treturnBuffer.currentCryptoKey = 0;\n\treturnBuffer.inited = 0;\n\treturn &v73 @ stack_-80_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3);\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredVector3 operator +(ObscuredVector3 a, ObscuredVector3 b)
		{
			//IL_00b6: Expected native int or pointer, but got O
			//IL_00c4: Expected native int or pointer, but got O
			//IL_00d2: Expected native int or pointer, but got O
			//IL_00dc: Expected O, but got Ref
			Vector3 vector = ((ObscuredVector3*)a)->InternalDecrypt();
			Vector3 vector2 = ((ObscuredVector3*)b)->InternalDecrypt();
			float num = vector.x + vector2.x;
			float num2 = vector.y + vector2.y;
			float num3 = vector.z + vector2.z;
			ObscuredVector3 obscuredVector = default(ObscuredVector3);
			Vector3 value = default(Vector3);
			value.x = num;
			value.y = num2;
			value.z = num3;
			obscuredVector = new ObscuredVector3(value);
			ObscuredVector3 obscuredVector2 = default(ObscuredVector3);
			((ObscuredVector3*)(nint)obscuredVector2)->fakeValueActive = false;
			((ObscuredVector3*)(nint)obscuredVector2)->currentCryptoKey = 0;
			((ObscuredVector3*)(nint)obscuredVector2)->inited = false;
			return (ObscuredVector3)(&obscuredVector);
		}

		[Token(Token = "0x60002EF")]
		[Address(RVA = "0xBE5D9C", Offset = "0xBE5D9C", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv34 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, a, v0, v2, v43, v44, v45, v46, v47);\n\tv50 = 1;\n\t*([1A354CB]) = v50;\nL_0021:\n\tgoto L_0024;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v51, methodInfo, v37, v38, v39, v40, v41, v42, a, v0, v2, v43, v44, v45, v46, v47);\nL_0024:\n\tv58 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::InternalDecrypt(b);\n\tv61 = a + v58;\n\tv62 = a.y + v58.y;\n\tv63 = a.z + v58.z;\n\tv66 = 0;\n\t// 47 MakeStruct v69 @ AGGBE9E24_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v61 @ V0_v2 (System.Single), v62 @ V1_v3 (System.Single), v63 @ V2_v3 (System.Single)\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::.ctor(&v66 @ stack_-70_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3), v69);\n\treturnBuffer.fakeValueActive = 0;\n\treturnBuffer.currentCryptoKey = 0;\n\treturnBuffer.inited = 0;\n\treturn &v66 @ stack_-70_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3);\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredVector3 operator +(Vector3 a, ObscuredVector3 b)
		{
			//IL_00a9: Expected native int or pointer, but got O
			//IL_00b7: Expected native int or pointer, but got O
			//IL_00c5: Expected native int or pointer, but got O
			//IL_00cf: Expected O, but got Ref
			Vector3 vector = ((ObscuredVector3*)b)->InternalDecrypt();
			Vector3 vector2 = default(Vector3);
			float num = vector2.x + vector.x;
			float num2 = a.y + vector.y;
			float num3 = a.z + vector.z;
			ObscuredVector3 obscuredVector = default(ObscuredVector3);
			Vector3 value = default(Vector3);
			value.x = num;
			value.y = num2;
			value.z = num3;
			obscuredVector = new ObscuredVector3(value);
			ObscuredVector3 obscuredVector2 = default(ObscuredVector3);
			((ObscuredVector3*)(nint)obscuredVector2)->fakeValueActive = false;
			((ObscuredVector3*)(nint)obscuredVector2)->currentCryptoKey = 0;
			((ObscuredVector3*)(nint)obscuredVector2)->inited = false;
			return (ObscuredVector3)(&obscuredVector);
		}

		[Token(Token = "0x60002F0")]
		[Address(RVA = "0xBE5E54", Offset = "0xBE5E54", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv34 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, b, v0, v2, v43, v44, v45, v46, v47);\n\tv50 = 1;\n\t*([1A354CC]) = v50;\nL_0021:\n\tgoto L_0024;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v51, methodInfo, v37, v38, v39, v40, v41, v42, b, v0, v2, v43, v44, v45, v46, v47);\nL_0024:\n\tv58 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::InternalDecrypt(a);\n\tv61 = b + v58;\n\tv62 = b.y + v58.y;\n\tv63 = b.z + v58.z;\n\tv66 = 0;\n\t// 47 MakeStruct v69 @ AGGBE9EDC_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v61 @ V0_v2 (System.Single), v62 @ V1_v3 (System.Single), v63 @ V2_v3 (System.Single)\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::.ctor(&v66 @ stack_-70_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3), v69);\n\treturnBuffer.fakeValueActive = 0;\n\treturnBuffer.currentCryptoKey = 0;\n\treturnBuffer.inited = 0;\n\treturn &v66 @ stack_-70_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3);\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredVector3 operator +(ObscuredVector3 a, Vector3 b)
		{
			//IL_00a9: Expected native int or pointer, but got O
			//IL_00b7: Expected native int or pointer, but got O
			//IL_00c5: Expected native int or pointer, but got O
			//IL_00cf: Expected O, but got Ref
			Vector3 vector = ((ObscuredVector3*)a)->InternalDecrypt();
			Vector3 vector2 = default(Vector3);
			float num = vector2.x + vector.x;
			float num2 = b.y + vector.y;
			float num3 = b.z + vector.z;
			ObscuredVector3 obscuredVector = default(ObscuredVector3);
			Vector3 value = default(Vector3);
			value.x = num;
			value.y = num2;
			value.z = num3;
			obscuredVector = new ObscuredVector3(value);
			ObscuredVector3 obscuredVector2 = default(ObscuredVector3);
			((ObscuredVector3*)(nint)obscuredVector2)->fakeValueActive = false;
			((ObscuredVector3*)(nint)obscuredVector2)->currentCryptoKey = 0;
			((ObscuredVector3*)(nint)obscuredVector2)->inited = false;
			return (ObscuredVector3)(&obscuredVector);
		}

		[Token(Token = "0x60002F1")]
		[Address(RVA = "0xBE5F0C", Offset = "0xBE5F0C", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv32 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3;\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, b, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 1;\n\t*([1A354CD]) = v50;\nL_001E:\n\tgoto L_0021;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v51, b, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0021:\n\tv58 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::InternalDecrypt(a);\n\tv65 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::InternalDecrypt(b);\n\tv68 = v58 - v65;\n\tv69 = v58.y - v65.y;\n\tv70 = v58.z - v65.z;\n\tv73 = 0;\n\t// 51 MakeStruct v76 @ AGGBE9FA0_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v68 @ V0_v3 (System.Single), v69 @ V1_v3 (System.Single), v70 @ V2_v3 (System.Single)\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::.ctor(&v73 @ stack_-80_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3), v76);\n\treturnBuffer.fakeValueActive = 0;\n\treturnBuffer.currentCryptoKey = 0;\n\treturnBuffer.inited = 0;\n\treturn &v73 @ stack_-80_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3);\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredVector3 operator -(ObscuredVector3 a, ObscuredVector3 b)
		{
			//IL_00b6: Expected native int or pointer, but got O
			//IL_00c4: Expected native int or pointer, but got O
			//IL_00d2: Expected native int or pointer, but got O
			//IL_00dc: Expected O, but got Ref
			Vector3 vector = ((ObscuredVector3*)a)->InternalDecrypt();
			Vector3 vector2 = ((ObscuredVector3*)b)->InternalDecrypt();
			float num = vector.x - vector2.x;
			float num2 = vector.y - vector2.y;
			float num3 = vector.z - vector2.z;
			ObscuredVector3 obscuredVector = default(ObscuredVector3);
			Vector3 value = default(Vector3);
			value.x = num;
			value.y = num2;
			value.z = num3;
			obscuredVector = new ObscuredVector3(value);
			ObscuredVector3 obscuredVector2 = default(ObscuredVector3);
			((ObscuredVector3*)(nint)obscuredVector2)->fakeValueActive = false;
			((ObscuredVector3*)(nint)obscuredVector2)->currentCryptoKey = 0;
			((ObscuredVector3*)(nint)obscuredVector2)->inited = false;
			return (ObscuredVector3)(&obscuredVector);
		}

		[Token(Token = "0x60002F2")]
		[Address(RVA = "0xBE5FD0", Offset = "0xBE5FD0", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv34 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, a, v0, v2, v43, v44, v45, v46, v47);\n\tv50 = 1;\n\t*([1A354CE]) = v50;\nL_0021:\n\tgoto L_0024;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v51, methodInfo, v37, v38, v39, v40, v41, v42, a, v0, v2, v43, v44, v45, v46, v47);\nL_0024:\n\tv58 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::InternalDecrypt(b);\n\tv61 = a - v58;\n\tv62 = a.y - v58.y;\n\tv63 = a.z - v58.z;\n\tv66 = 0;\n\t// 47 MakeStruct v69 @ AGGBEA058_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v61 @ V0_v2 (System.Single), v62 @ V1_v3 (System.Single), v63 @ V2_v3 (System.Single)\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::.ctor(&v66 @ stack_-70_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3), v69);\n\treturnBuffer.fakeValueActive = 0;\n\treturnBuffer.currentCryptoKey = 0;\n\treturnBuffer.inited = 0;\n\treturn &v66 @ stack_-70_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3);\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredVector3 operator -(Vector3 a, ObscuredVector3 b)
		{
			//IL_00a9: Expected native int or pointer, but got O
			//IL_00b7: Expected native int or pointer, but got O
			//IL_00c5: Expected native int or pointer, but got O
			//IL_00cf: Expected O, but got Ref
			Vector3 vector = ((ObscuredVector3*)b)->InternalDecrypt();
			Vector3 vector2 = default(Vector3);
			float num = vector2.x - vector.x;
			float num2 = a.y - vector.y;
			float num3 = a.z - vector.z;
			ObscuredVector3 obscuredVector = default(ObscuredVector3);
			Vector3 value = default(Vector3);
			value.x = num;
			value.y = num2;
			value.z = num3;
			obscuredVector = new ObscuredVector3(value);
			ObscuredVector3 obscuredVector2 = default(ObscuredVector3);
			((ObscuredVector3*)(nint)obscuredVector2)->fakeValueActive = false;
			((ObscuredVector3*)(nint)obscuredVector2)->currentCryptoKey = 0;
			((ObscuredVector3*)(nint)obscuredVector2)->inited = false;
			return (ObscuredVector3)(&obscuredVector);
		}

		[Token(Token = "0x60002F3")]
		[Address(RVA = "0xBE6088", Offset = "0xBE6088", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv34 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, b, v0, v2, v43, v44, v45, v46, v47);\n\tv50 = 1;\n\t*([1A354CF]) = v50;\nL_0021:\n\tgoto L_0024;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v51, methodInfo, v37, v38, v39, v40, v41, v42, b, v0, v2, v43, v44, v45, v46, v47);\nL_0024:\n\tv58 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::InternalDecrypt(a);\n\tv61 = v58 - b;\n\tv62 = v58.y - b.y;\n\tv63 = v58.z - b.z;\n\tv66 = 0;\n\t// 47 MakeStruct v69 @ AGGBEA110_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v61 @ V0_v2 (System.Single), v62 @ V1_v3 (System.Single), v63 @ V2_v3 (System.Single)\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::.ctor(&v66 @ stack_-70_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3), v69);\n\treturnBuffer.fakeValueActive = 0;\n\treturnBuffer.currentCryptoKey = 0;\n\treturnBuffer.inited = 0;\n\treturn &v66 @ stack_-70_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3);\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredVector3 operator -(ObscuredVector3 a, Vector3 b)
		{
			//IL_00a9: Expected native int or pointer, but got O
			//IL_00b7: Expected native int or pointer, but got O
			//IL_00c5: Expected native int or pointer, but got O
			//IL_00cf: Expected O, but got Ref
			Vector3 vector = ((ObscuredVector3*)a)->InternalDecrypt();
			Vector3 vector2 = default(Vector3);
			float num = vector.x - vector2.x;
			float num2 = vector.y - b.y;
			float num3 = vector.z - b.z;
			ObscuredVector3 obscuredVector = default(ObscuredVector3);
			Vector3 value = default(Vector3);
			value.x = num;
			value.y = num2;
			value.z = num3;
			obscuredVector = new ObscuredVector3(value);
			ObscuredVector3 obscuredVector2 = default(ObscuredVector3);
			((ObscuredVector3*)(nint)obscuredVector2)->fakeValueActive = false;
			((ObscuredVector3*)(nint)obscuredVector2)->currentCryptoKey = 0;
			((ObscuredVector3*)(nint)obscuredVector2)->inited = false;
			return (ObscuredVector3)(&obscuredVector);
		}

		[Token(Token = "0x60002F4")]
		[Address(RVA = "0xBE6140", Offset = "0xBE6140", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 1;\n\t*([1A354D0]) = v41;\nL_0019:\n\tgoto L_001C;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_001C:\n\tv49 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::InternalDecrypt(a);\n\tv52 = -v49;\n\tv53 = -v49.y;\n\tv54 = -v49.z;\n\tv57 = 0;\n\t// 39 MakeStruct v60 @ AGGBEA1B4_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v52 @ V0_v2, v53 @ V1_v2, v54 @ V2_v2\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::.ctor(&v57 @ stack_-60_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3), v60);\n\treturnBuffer.fakeValueActive = 0;\n\treturnBuffer.currentCryptoKey = 0;\n\treturnBuffer.inited = 0;\n\treturn &v57 @ stack_-60_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3);\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredVector3 operator -(ObscuredVector3 a)
		{
			//IL_0016: Unsupported input type for neg.
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Expected O, but got Unknown
			//IL_0029: Expected O, but got F4
			//IL_0037: Expected O, but got F4
			//IL_004e: Expected F4, but got O
			//IL_005b: Expected F4, but got O
			//IL_0068: Expected F4, but got O
			//IL_0083: Expected native int or pointer, but got O
			//IL_0091: Expected native int or pointer, but got O
			//IL_009f: Expected native int or pointer, but got O
			//IL_00a9: Expected O, but got Ref
			Vector3 vector = ((ObscuredVector3*)a)->InternalDecrypt();
			object obj = 0 - vector;
			object obj2 = 0f - vector.y;
			object obj3 = 0f - vector.z;
			ObscuredVector3 obscuredVector = default(ObscuredVector3);
			Vector3 value = default(Vector3);
			value.x = (float)obj;
			value.y = (float)obj2;
			value.z = (float)obj3;
			obscuredVector = new ObscuredVector3(value);
			ObscuredVector3 obscuredVector2 = default(ObscuredVector3);
			((ObscuredVector3*)(nint)obscuredVector2)->fakeValueActive = false;
			((ObscuredVector3*)(nint)obscuredVector2)->currentCryptoKey = 0;
			((ObscuredVector3*)(nint)obscuredVector2)->inited = false;
			return (ObscuredVector3)(&obscuredVector);
		}

		[Token(Token = "0x60002F5")]
		[Address(RVA = "0xBE61DC", Offset = "0xBE61DC", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, d, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 1;\n\t*([1A354D1]) = v44;\nL_001B:\n\tgoto L_001E;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v29, v30, v31, v32, v33, v34, d, v35, v36, v37, v38, v39, v40, v41);\nL_001E:\n\tv52 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::InternalDecrypt(a);\n\tv55 = v52 * d;\n\tv56 = v52.y * d;\n\tv57 = v52.z * d;\n\tv60 = 0;\n\t// 41 MakeStruct v63 @ AGGBEA258_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v55 @ V0_v2 (System.Single), v56 @ V1_v2 (System.Single), v57 @ V2_v2 (System.Single)\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::.ctor(&v60 @ stack_-60_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3), v63);\n\treturnBuffer.fakeValueActive = 0;\n\treturnBuffer.currentCryptoKey = 0;\n\treturnBuffer.inited = 0;\n\treturn &v60 @ stack_-60_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3);\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredVector3 operator *(ObscuredVector3 a, float d)
		{
			//IL_009a: Expected native int or pointer, but got O
			//IL_00a8: Expected native int or pointer, but got O
			//IL_00b6: Expected native int or pointer, but got O
			//IL_00c0: Expected O, but got Ref
			Vector3 vector = ((ObscuredVector3*)a)->InternalDecrypt();
			float num = vector.x * d;
			float num2 = vector.y * d;
			float num3 = vector.z * d;
			ObscuredVector3 obscuredVector = default(ObscuredVector3);
			Vector3 value = default(Vector3);
			value.x = num;
			value.y = num2;
			value.z = num3;
			obscuredVector = new ObscuredVector3(value);
			ObscuredVector3 obscuredVector2 = default(ObscuredVector3);
			((ObscuredVector3*)(nint)obscuredVector2)->fakeValueActive = false;
			((ObscuredVector3*)(nint)obscuredVector2)->currentCryptoKey = 0;
			((ObscuredVector3*)(nint)obscuredVector2)->inited = false;
			return (ObscuredVector3)(&obscuredVector);
		}

		[Token(Token = "0x60002F6")]
		[Address(RVA = "0xBE6284", Offset = "0xBE6284", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, d, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 1;\n\t*([1A354D2]) = v44;\nL_001B:\n\tgoto L_001E;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v29, v30, v31, v32, v33, v34, d, v35, v36, v37, v38, v39, v40, v41);\nL_001E:\n\tv52 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::InternalDecrypt(a);\n\tv55 = v52 * d;\n\tv56 = v52.y * d;\n\tv57 = v52.z * d;\n\tv60 = 0;\n\t// 41 MakeStruct v63 @ AGGBEA300_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v55 @ V0_v2 (System.Single), v56 @ V1_v2 (System.Single), v57 @ V2_v2 (System.Single)\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::.ctor(&v60 @ stack_-60_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3), v63);\n\treturnBuffer.fakeValueActive = 0;\n\treturnBuffer.currentCryptoKey = 0;\n\treturnBuffer.inited = 0;\n\treturn &v60 @ stack_-60_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3);\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredVector3 operator *(float d, ObscuredVector3 a)
		{
			//IL_009a: Expected native int or pointer, but got O
			//IL_00a8: Expected native int or pointer, but got O
			//IL_00b6: Expected native int or pointer, but got O
			//IL_00c0: Expected O, but got Ref
			Vector3 vector = ((ObscuredVector3*)a)->InternalDecrypt();
			float num = vector.x * d;
			float num2 = vector.y * d;
			float num3 = vector.z * d;
			ObscuredVector3 obscuredVector = default(ObscuredVector3);
			Vector3 value = default(Vector3);
			value.x = num;
			value.y = num2;
			value.z = num3;
			obscuredVector = new ObscuredVector3(value);
			ObscuredVector3 obscuredVector2 = default(ObscuredVector3);
			((ObscuredVector3*)(nint)obscuredVector2)->fakeValueActive = false;
			((ObscuredVector3*)(nint)obscuredVector2)->currentCryptoKey = 0;
			((ObscuredVector3*)(nint)obscuredVector2)->inited = false;
			return (ObscuredVector3)(&obscuredVector);
		}

		[Token(Token = "0x60002F7")]
		[Address(RVA = "0xBE632C", Offset = "0xBE632C", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, d, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 1;\n\t*([1A354D3]) = v44;\nL_001B:\n\tgoto L_001E;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v29, v30, v31, v32, v33, v34, d, v35, v36, v37, v38, v39, v40, v41);\nL_001E:\n\tv52 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::InternalDecrypt(a);\n\tv55 = v52 / d;\n\tv56 = v52.y / d;\n\tv57 = v52.z / d;\n\tv60 = 0;\n\t// 41 MakeStruct v63 @ AGGBEA3A8_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v55 @ V0_v2 (System.Single), v56 @ V1_v2 (System.Single), v57 @ V2_v2 (System.Single)\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::.ctor(&v60 @ stack_-60_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3), v63);\n\treturnBuffer.fakeValueActive = 0;\n\treturnBuffer.currentCryptoKey = 0;\n\treturnBuffer.inited = 0;\n\treturn &v60 @ stack_-60_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3);\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredVector3 operator /(ObscuredVector3 a, float d)
		{
			//IL_009a: Expected native int or pointer, but got O
			//IL_00a8: Expected native int or pointer, but got O
			//IL_00b6: Expected native int or pointer, but got O
			//IL_00c0: Expected O, but got Ref
			Vector3 vector = ((ObscuredVector3*)a)->InternalDecrypt();
			float num = vector.x / d;
			float num2 = vector.y / d;
			float num3 = vector.z / d;
			ObscuredVector3 obscuredVector = default(ObscuredVector3);
			Vector3 value = default(Vector3);
			value.x = num;
			value.y = num2;
			value.z = num3;
			obscuredVector = new ObscuredVector3(value);
			ObscuredVector3 obscuredVector2 = default(ObscuredVector3);
			((ObscuredVector3*)(nint)obscuredVector2)->fakeValueActive = false;
			((ObscuredVector3*)(nint)obscuredVector2)->currentCryptoKey = 0;
			((ObscuredVector3*)(nint)obscuredVector2)->inited = false;
			return (ObscuredVector3)(&obscuredVector);
		}

		[Token(Token = "0x60002F8")]
		[Address(RVA = "0xBE63D4", Offset = "0xBE63D4", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv28 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, rhs, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 1;\n\t*([1A354D4]) = v46;\nL_001C:\n\tgoto L_001F;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v47, rhs, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_001F:\n\tv54 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::InternalDecrypt(lhs);\n\tv61 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::InternalDecrypt(rhs);\n\tv65 = v54 - v61;\n\tv66 = v54.y - v61.y;\n\tv68 = v54.z - v61.z;\n\tv69 = v65 * v65;\n\tv70 = v66 * v66;\n\tv71 = v69 + v70;\n\tv72 = v68 * v68;\n\tv80 = v72 + v71;\n\tv83 = v80 - 9.9999994E-11f;\n\tv84 = v83 < 0;\n\treturn v84;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static bool operator ==(ObscuredVector3 lhs, ObscuredVector3 rhs)
		{
			Vector3 vector = ((ObscuredVector3*)lhs)->InternalDecrypt();
			Vector3 vector2 = ((ObscuredVector3*)rhs)->InternalDecrypt();
			float num = vector.x - vector2.x;
			float num2 = vector.y - vector2.y;
			float num3 = vector.z - vector2.z;
			float num4 = num * num;
			float num5 = num2 * num2;
			float num6 = num4 + num5;
			float num7 = num3 * num3;
			float num8 = num7 + num6;
			float num9 = num8 - 9.9999994E-11f;
			return num9 < 0f;
		}

		[Token(Token = "0x60002F9")]
		[Address(RVA = "0xBE648C", Offset = "0xBE648C", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, lhs, v0, v2, v39, v40, v41, v42, v43);\n\tv46 = 1;\n\t*([1A354D5]) = v46;\nL_001F:\n\tgoto L_0022;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v33, v34, v35, v36, v37, v38, lhs, v0, v2, v39, v40, v41, v42, v43);\nL_0022:\n\tv54 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::InternalDecrypt(rhs);\n\tv58 = lhs - v54;\n\tv59 = lhs.y - v54.y;\n\tv61 = lhs.z - v54.z;\n\tv62 = v58 * v58;\n\tv63 = v59 * v59;\n\tv64 = v62 + v63;\n\tv65 = v61 * v61;\n\tv72 = v65 + v64;\n\tv75 = v72 - 9.9999994E-11f;\n\tv76 = v75 < 0;\n\treturn v76;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static bool operator ==(Vector3 lhs, ObscuredVector3 rhs)
		{
			Vector3 vector = ((ObscuredVector3*)rhs)->InternalDecrypt();
			Vector3 vector2 = default(Vector3);
			float num = vector2.x - vector.x;
			float num2 = lhs.y - vector.y;
			float num3 = lhs.z - vector.z;
			float num4 = num * num;
			float num5 = num2 * num2;
			float num6 = num4 + num5;
			float num7 = num3 * num3;
			float num8 = num7 + num6;
			float num9 = num8 - 9.9999994E-11f;
			return num9 < 0f;
		}

		[Token(Token = "0x60002FA")]
		[Address(RVA = "0xBE6530", Offset = "0xBE6530", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, rhs, v0, v2, v39, v40, v41, v42, v43);\n\tv46 = 1;\n\t*([1A354D6]) = v46;\nL_001F:\n\tgoto L_0022;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v33, v34, v35, v36, v37, v38, rhs, v0, v2, v39, v40, v41, v42, v43);\nL_0022:\n\tv54 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::InternalDecrypt(lhs);\n\tv58 = v54 - rhs;\n\tv59 = v54.y - rhs.y;\n\tv61 = v54.z - rhs.z;\n\tv62 = v58 * v58;\n\tv63 = v59 * v59;\n\tv64 = v62 + v63;\n\tv65 = v61 * v61;\n\tv72 = v65 + v64;\n\tv75 = v72 - 9.9999994E-11f;\n\tv76 = v75 < 0;\n\treturn v76;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static bool operator ==(ObscuredVector3 lhs, Vector3 rhs)
		{
			Vector3 vector = ((ObscuredVector3*)lhs)->InternalDecrypt();
			Vector3 vector2 = default(Vector3);
			float num = vector.x - vector2.x;
			float num2 = vector.y - rhs.y;
			float num3 = vector.z - rhs.z;
			float num4 = num * num;
			float num5 = num2 * num2;
			float num6 = num4 + num5;
			float num7 = num3 * num3;
			float num8 = num7 + num6;
			float num9 = num8 - 9.9999994E-11f;
			return num9 < 0f;
		}

		[Token(Token = "0x60002FB")]
		[Address(RVA = "0xBE65D4", Offset = "0xBE65D4", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv28 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, rhs, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 1;\n\t*([1A354D7]) = v46;\nL_001C:\n\tgoto L_001F;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v47, rhs, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_001F:\n\tv54 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::InternalDecrypt(lhs);\n\tv61 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::InternalDecrypt(rhs);\n\tv65 = v54 - v61;\n\tv66 = v54.y - v61.y;\n\tv68 = v54.z - v61.z;\n\tv69 = v65 * v65;\n\tv70 = v66 * v66;\n\tv71 = v69 + v70;\n\tv72 = v68 * v68;\n\tv80 = v72 + v71;\n\tv83 = v80 - 9.9999994E-11f;\n\tv84 = v83 < 0;\n\tv90 = ~v84;\n\treturn v90;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static bool operator !=(ObscuredVector3 lhs, ObscuredVector3 rhs)
		{
			Vector3 vector = ((ObscuredVector3*)lhs)->InternalDecrypt();
			Vector3 vector2 = ((ObscuredVector3*)rhs)->InternalDecrypt();
			float num = vector.x - vector2.x;
			float num2 = vector.y - vector2.y;
			float num3 = vector.z - vector2.z;
			float num4 = num * num;
			float num5 = num2 * num2;
			float num6 = num4 + num5;
			float num7 = num3 * num3;
			float num8 = num7 + num6;
			float num9 = num8 - 9.9999994E-11f;
			bool flag = num9 < 0f;
			return !flag;
		}

		[Token(Token = "0x60002FC")]
		[Address(RVA = "0xBE668C", Offset = "0xBE668C", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, lhs, v0, v2, v39, v40, v41, v42, v43);\n\tv46 = 1;\n\t*([1A354D8]) = v46;\nL_001F:\n\tgoto L_0022;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v33, v34, v35, v36, v37, v38, lhs, v0, v2, v39, v40, v41, v42, v43);\nL_0022:\n\tv54 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::InternalDecrypt(rhs);\n\tv58 = lhs - v54;\n\tv59 = lhs.y - v54.y;\n\tv61 = lhs.z - v54.z;\n\tv62 = v58 * v58;\n\tv63 = v59 * v59;\n\tv64 = v62 + v63;\n\tv65 = v61 * v61;\n\tv72 = v65 + v64;\n\tv75 = v72 - 9.9999994E-11f;\n\tv76 = v75 < 0;\n\tv82 = ~v76;\n\treturn v82;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static bool operator !=(Vector3 lhs, ObscuredVector3 rhs)
		{
			Vector3 vector = ((ObscuredVector3*)rhs)->InternalDecrypt();
			Vector3 vector2 = default(Vector3);
			float num = vector2.x - vector.x;
			float num2 = lhs.y - vector.y;
			float num3 = lhs.z - vector.z;
			float num4 = num * num;
			float num5 = num2 * num2;
			float num6 = num4 + num5;
			float num7 = num3 * num3;
			float num8 = num7 + num6;
			float num9 = num8 - 9.9999994E-11f;
			bool flag = num9 < 0f;
			return !flag;
		}

		[Token(Token = "0x60002FD")]
		[Address(RVA = "0xBE6730", Offset = "0xBE6730", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, rhs, v0, v2, v39, v40, v41, v42, v43);\n\tv46 = 1;\n\t*([1A354D9]) = v46;\nL_001F:\n\tgoto L_0022;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v33, v34, v35, v36, v37, v38, rhs, v0, v2, v39, v40, v41, v42, v43);\nL_0022:\n\tv54 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::InternalDecrypt(lhs);\n\tv58 = v54 - rhs;\n\tv59 = v54.y - rhs.y;\n\tv61 = v54.z - rhs.z;\n\tv62 = v58 * v58;\n\tv63 = v59 * v59;\n\tv64 = v62 + v63;\n\tv65 = v61 * v61;\n\tv72 = v65 + v64;\n\tv75 = v72 - 9.9999994E-11f;\n\tv76 = v75 < 0;\n\tv82 = ~v76;\n\treturn v82;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static bool operator !=(ObscuredVector3 lhs, Vector3 rhs)
		{
			Vector3 vector = ((ObscuredVector3*)lhs)->InternalDecrypt();
			Vector3 vector2 = default(Vector3);
			float num = vector.x - vector2.x;
			float num2 = vector.y - rhs.y;
			float num3 = vector.z - rhs.z;
			float num4 = num * num;
			float num5 = num2 * num2;
			float num6 = num4 + num5;
			float num7 = num3 * num3;
			float num8 = num7 + num6;
			float num9 = num8 - 9.9999994E-11f;
			bool flag = num9 < 0f;
			return !flag;
		}

		[Token(Token = "0x60002FE")]
		[Address(RVA = "0xBE67D4", Offset = "0xBE67D4", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv28 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, other, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 1;\n\t*([1A354DA]) = v46;\nL_001C:\n\tgoto L_001F;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v47, other, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_001F:\n\tv54 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::InternalDecrypt(this);\n\tv62 = *([1A3551F]) == 0;\n\tif (v62) goto L_0031;\n\tv63 = other == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_003C;\n\tgoto L_FFFFFFFF;\nL_0031:\n\t*([1A3551F]) = 1;\n\tv70 = other == 0;\n\tif (v70) goto L_FFFFFFFF;\nL_003C:\n\tv81 = *([other @ X1 (System.Object)]) == UnityEngine.Vector3;\n\tif (v81) goto L_004E;\nL_004C:\n\treturn returnVal1;\nL_004E:\n\tv128 = \"il2cpp_vm_object_unbox\"(other, other, methodInfo, v31, v32, v33, v34, v35, v54, v54.y, v54.z, v39, v40, v41, v42, v43);\n\tv88 = v54 != *([v128 @ X0_v10]);\n\tif (v88) goto L_FFFFFFFF;\n\tv89 = v54.y != *([v128 @ X0_v10+4]);\n\tif (v89) goto L_FFFFFFFF;\n\tv147 = v54.z - *([v128 @ X0_v10+8]);\n\tv143 = v147 == 0;\n\tgoto L_004C;\n\treturn X0;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override bool Equals(object other)
		{
			Vector3 vector = InternalDecrypt();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1A3551F]");
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
			goto IL_00ab;
			IL_00ab:
			return false;
			IL_0084:
			if ((object)other.GetType() == typeof(Vector3))
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				object obj = default(object);
				if (vector.x == (float)obj)
				{
					float num = vector.y;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ X0_v10+4]");
					if (num == 0f)
					{
						float num2 = vector.z;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ X0_v10+8]");
						float num3 = num2 - 0f;
						return num3 == 0f;
					}
				}
			}
			goto IL_00ab;
		}

		[Token(Token = "0x60002FF")]
		[Address(RVA = "0xBE68CC", Offset = "0xBE68CC", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A354DB]) = v37;\nL_0017:\n\tgoto L_001A;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001A:\n\tv45 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::InternalDecrypt(this);\n\tv53 = &v45 @ V0_v1 (UnityEngine.Vector3) | 4;\n\tv54 = &v45 @ V0_v1 (UnityEngine.Vector3) + 8;\n\tv56 = System.Single::GetHashCode(&v45 @ V0_v1 (UnityEngine.Vector3));\n\tv60 = System.Single::GetHashCode(v53);\n\tv64 = System.Single::GetHashCode(v54);\n\tv65 = v56 ^ v60;\n\treturnVal1 = v65 ^ v64;\n\treturn returnVal1;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override int GetHashCode()
		{
			//IL_0056: Expected Ref, but got F4
			Vector3 vector = InternalDecrypt();
			int num = (int)((nint)vector | 4);
			float num2 = (float)(ref vector) + 1.1E-44f;
			int hashCode = ((float*)(&vector))->GetHashCode();
			int hashCode2 = ((float*)num)->GetHashCode();
			int hashCode3 = ((float*)num2)->GetHashCode();
			int num3 = hashCode ^ hashCode2;
			return num3 ^ hashCode3;
		}

		[Token(Token = "0x6000300")]
		[Address(RVA = "0xBE6974", Offset = "0xBE6974", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A354DC]) = v37;\nL_0017:\n\tgoto L_001A;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001A:\n\tv45 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::InternalDecrypt(this);\n\treturnVal1 = 0xBEEA54(&v45 @ V0_v1 (UnityEngine.Vector3), 0, 0, 0, v23, v24, v25, v26, v45, v45.y, v45.z, v30, v31, v32, v33, v34);\n\treturn returnVal1;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			Vector3 vector = InternalDecrypt();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BEEA54 (inside CodeStage.AntiCheat.Genuine.CodeHash.AndroidWorker+CodeHashGeneratorCallback::OnError +0x540)");
			string result = default(string);
			return result;
		}

		[Token(Token = "0x6000301")]
		[Address(RVA = "0xBE69F0", Offset = "0xBE69F0", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, format, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A354DD]) = v40;\nL_0019:\n\tgoto L_001C;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, format, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_001C:\n\tv48 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3::InternalDecrypt(this);\n\treturnVal1 = 0xBEEA54(&v48 @ V0_v1 (UnityEngine.Vector3), format, 0, 0, v26, v27, v28, v29, v48, v48.y, v48.z, v33, v34, v35, v36, v37);\n\treturn returnVal1;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string ToString(string format)
		{
			Vector3 vector = InternalDecrypt();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BEEA54 (inside CodeStage.AntiCheat.Genuine.CodeHash.AndroidWorker+CodeHashGeneratorCallback::OnError +0x540)");
			string result = default(string);
			return result;
		}

		[Obsolete("This API is redundant and does not perform any actions. It will be removed in future updates.")]
		[Token(Token = "0x6000302")]
		[Address(RVA = "0xBE6A78", Offset = "0xBE6A78", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public static void SetNewCryptoKey(int newKey)
		{
		}

		[Obsolete("This API is redundant and does not perform any actions. It will be removed in future updates.")]
		[Token(Token = "0x6000303")]
		[Address(RVA = "0xBE6A7C", Offset = "0xBE6A7C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void ApplyNewCryptoKey()
		{
		}

		[Obsolete("Please use new Encrypt(value, key) API instead.", true)]
		[Token(Token = "0x6000304")]
		[Address(RVA = "0xBE6A80", Offset = "0xBE6A80", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static RawEncryptedVector3 Encrypt(Vector3 value)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new Decrypt(value, key) API instead.", true)]
		[Token(Token = "0x6000305")]
		[Address(RVA = "0xBE6AB8", Offset = "0xBE6AB8", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector3 Decrypt(RawEncryptedVector3 value)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new GetEncrypted(out key) API instead.", true)]
		[Token(Token = "0x6000306")]
		[Address(RVA = "0xBE6AF0", Offset = "0xBE6AF0", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RawEncryptedVector3 GetEncrypted()
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new SetEncrypted(encrypted, key) API instead.", true)]
		[Token(Token = "0x6000307")]
		[Address(RVA = "0xBE6B28", Offset = "0xBE6B28", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetEncrypted(RawEncryptedVector3 encrypted)
		{
		}

		[Token(Token = "0x6000308")]
		[Address(RVA = "0xBE6B2C", Offset = "0xBE6B2C", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv12 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3;\n\tv13 = \"il2cpp_codegen_initialize_runtime_metadata\"(v12, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\n\tv32 = 1;\n\t*([1A354DE]) = v32;\nL_0015:\n\tgoto L_001D;\n\tv40 = UnityEngine.Vector3;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\n\tv44 = 1;\n\t*([1A35519]) = v44;\nL_001D:\n\tv47 = CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3;\n\tv50 = UnityEngine.Vector3;\n\tv51 = *([v47 @ X9_v1 (Il2CppClass<CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3>)+B8]);\n\tv52 = *([v50 @ X8_v7 (Il2CppClass<UnityEngine.Vector3>)+B8]);\n\tv51.Zero = v52.zeroVector;\n\t*([v51 @ X9_v2 (Il2CppStaticFields<CodeStage.AntiCheat.ObscuredTypes.ObscuredVector3>)+8]) = *([v52 @ X8_v8 (Il2CppStaticFields<UnityEngine.Vector3>)+8]);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static ObscuredVector3()
		{
			//IL_0018: Expected I, but got O
			//IL_0026: Expected I, but got O
			//IL_002f: Expected I, but got O
			//IL_0038: Expected I, but got O
			nint num = (nint)typeof(ObscuredVector3);
			nint num2 = (nint)typeof(Vector3);
			nint num3 = (nint)Zero;
			nint num4 = (nint)Vector3.zero;
			Zero = Vector3.zero;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X8_v8 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			_ = 0;
		}
	}
}
