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
	[Token(Token = "0x200001A")]
	public struct ObscuredQuaternion : IObscuredType
	{
		[Serializable]
		[Token(Token = "0x200001B")]
		public struct RawEncryptedQuaternion
		{
			[Token(Token = "0x4000088")]
			[FieldOffset(Offset = "0x0")]
			public int x;

			[Token(Token = "0x4000089")]
			[FieldOffset(Offset = "0x4")]
			public int y;

			[Token(Token = "0x400008A")]
			[FieldOffset(Offset = "0x8")]
			public int z;

			[Token(Token = "0x400008B")]
			[FieldOffset(Offset = "0xC")]
			public int w;
		}

		[Token(Token = "0x4000082")]
		private static readonly Quaternion Identity = Quaternion.identity;

		[SerializeField]
		[Token(Token = "0x4000083")]
		[FieldOffset(Offset = "0x0")]
		private int currentCryptoKey;

		[SerializeField]
		[Token(Token = "0x4000084")]
		[FieldOffset(Offset = "0x4")]
		private RawEncryptedQuaternion hiddenValue;

		[SerializeField]
		[Token(Token = "0x4000085")]
		[FieldOffset(Offset = "0x14")]
		private bool inited;

		[SerializeField]
		[Token(Token = "0x4000086")]
		[FieldOffset(Offset = "0x18")]
		private Quaternion fakeValue;

		[SerializeField]
		[Token(Token = "0x4000087")]
		[FieldOffset(Offset = "0x28")]
		private bool fakeValueActive;

		[Token(Token = "0x60001AD")]
		[Address(RVA = "0xBDF56C", Offset = "0xBDF56C", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv34 = CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, value, v0, v2, v3, v43, v44, v45, v46);\n\tv49 = 1;\n\t*([1A35475]) = v49;\nL_0022:\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v50, methodInfo, v37, v38, v39, v40, v41, v42, value, v0, v2, v3, v43, v44, v45, v46);\nL_0024:\n\tv56 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tthis.currentCryptoKey = v56;\n\tv62 = CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion::Encrypt(value, v56);\n\tthis.hiddenValue = v62;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion)+C]) = methodInfo;\n\tv64 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tgoto L_0043;\n\tv69 = CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion;\n\tv70 = *([v69 @ X0_v9+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_FFFFFFFF;\n\tv96 = \"il2cpp_codegen_runtime_class_init\"(v69, methodInfo, v37, v38, v39, v40, v41, v42, v57, v58, v59, v60, v43, v44, v45, v46);\n\tv97 = CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion;\n\tv85 = *([v74 @ X0_v10+B8]);\n\tv77 = *([v85 @ X8_v7]);\n\tv79 = *([v85 @ X8_v7+4]);\n\tv81 = *([v85 @ X8_v7+8]);\n\tv83 = *([v85 @ X8_v7+C]);\nL_0043:\n\tthis.fakeValue = value;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion)+1C]) = value.y;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion)+20]) = value.z;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion)+24]) = value.w;\n\tthis.fakeValueActive = v64;\n\tthis.inited = 1;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private ObscuredQuaternion(Quaternion value)
		{
			RawEncryptedQuaternion rawEncryptedQuaternion = Encrypt(key: currentCryptoKey = RandomUtils.GenerateIntKey(), value: value);
			hiddenValue = rawEncryptedQuaternion;
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			fakeValue = value;
			_ = value.y;
			_ = value.z;
			_ = value.w;
			fakeValueActive = existsAndIsRunning;
			inited = true;
		}

		[Token(Token = "0x60001AE")]
		[Address(RVA = "0xBDF6D0", Offset = "0xBDF6D0", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv34 = CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, x, y, z, w, v43, v44, v45, v46);\n\tv49 = 1;\n\t*([1A35476]) = v49;\nL_001F:\n\tgoto L_0021;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v50, methodInfo, v37, v38, v39, v40, v41, v42, x, y, z, w, v43, v44, v45, v46);\nL_0021:\n\tv56 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tthis.currentCryptoKey = v56;\n\tv61 = CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion::Encrypt(x, y, z, w, v56);\n\tthis.hiddenValue = v61;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion)+C]) = methodInfo;\n\tv63 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv65 = v63 == 0;\n\tif (v65) goto L_0039;\n\tthis.fakeValue = x;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion)+1C]) = y;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion)+20]) = z;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion)+24]) = w;\n\tgoto L_0040;\nL_0039:\n\tgoto L_003F;\n\tv90 = \"il2cpp_codegen_runtime_class_init\"(v67, methodInfo, v37, v38, v39, v40, v41, v42, v57, v58, v59, v60, v43, v44, v45, v46);\n\tv91 = CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion;\nL_003F:\n\tthis.fakeValue = v72.Identity;\nL_0040:\n\tthis.fakeValueActive = v79;\n\tthis.inited = 1;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObscuredQuaternion(float x, float y, float z, float w)
		{
			//IL_0079: Expected O, but got F4
			RawEncryptedQuaternion rawEncryptedQuaternion = Encrypt(x, y, z, w, currentCryptoKey = RandomUtils.GenerateIntKey());
			hiddenValue = rawEncryptedQuaternion;
			bool flag;
			if (ObscuredCheatingDetector.ExistsAndIsRunning)
			{
				fakeValue = (Quaternion)x;
				flag = true;
			}
			else
			{
				fakeValue = Identity;
				flag = false;
			}
			fakeValueActive = flag;
			inited = true;
		}

		[Token(Token = "0x60001AF")]
		[Address(RVA = "0xBDF64C", Offset = "0xBDF64C", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv34 = CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, value, v0, v2, v3, v43, v44, v45, v46);\n\tv49 = 1;\n\t*([1A35477]) = v49;\nL_0022:\n\tgoto L_0032;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v50, methodInfo, v37, v38, v39, v40, v41, v42, value, v0, v2, v3, v43, v44, v45, v46);\nL_0032:\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion::Encrypt(value, value.y, value.z, value.w, key);\n\treturn returnVal1;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static RawEncryptedQuaternion Encrypt(Quaternion value, int key)
		{
			Quaternion quaternion = default(Quaternion);
			return Encrypt(quaternion.x, value.y, value.z, value.w, key);
		}

		[Token(Token = "0x60001B0")]
		[Address(RVA = "0xBDF7B0", Offset = "0xBDF7B0", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = x ^ key;\n\tCodeStage.AntiCheat.Common.ACTkByte4::Shuffle(&v20 @ X8_v2 (System.Int32));\n\tv20 = y ^ key;\n\tCodeStage.AntiCheat.Common.ACTkByte4::Shuffle(&v20 @ X8_v2 (System.Int32));\n\tv20 = z ^ key;\n\tCodeStage.AntiCheat.Common.ACTkByte4::Shuffle(&v20 @ X8_v2 (System.Int32));\n\tv20 = w ^ key;\n\tCodeStage.AntiCheat.Common.ACTkByte4::Shuffle(&v20 @ X8_v2 (System.Int32));\n\tv49 = v20 & 0xFFFFFFFF;\n\tv50 = v49 << 0x20;\n\tv51 = v20 & 0xFFFFFFFF;\n\tv52 = v51 | v50;\n\treturn v52;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static RawEncryptedQuaternion Encrypt(float x, float y, float z, float w, int key)
		{
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected I4, but got Unknown
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Expected I4, but got Unknown
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Expected I4, but got Unknown
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Expected I4, but got Unknown
			//IL_0074: Expected I4, but got I8
			//IL_0094: Expected I4, but got I8
			//IL_00a6: Expected O, but got I4
			System.Runtime.CompilerServices.Unsafe.As<int, ACTkByte4>(ref x ^ key).Shuffle();
			System.Runtime.CompilerServices.Unsafe.As<int, ACTkByte4>(ref y ^ key).Shuffle();
			System.Runtime.CompilerServices.Unsafe.As<int, ACTkByte4>(ref z ^ key).Shuffle();
			int num = w ^ key;
			((ACTkByte4*)(&num))->Shuffle();
			int num2 = (int)(num & 0xFFFFFFFFL);
			int num3 = num2 << 32;
			int num4 = (int)(num & 0xFFFFFFFFL);
			int num5 = num4 | num3;
			return (RawEncryptedQuaternion)num5;
		}

		[Token(Token = "0x60001B1")]
		[Address(RVA = "0xBDF874", Offset = "0xBDF874", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = value >> 0x20;\n\tCodeStage.AntiCheat.Common.ACTkByte4::UnShuffle(&v20 @ stack_-38_v2 (CodeStage.AntiCheat.Common.ACTkByte4));\n\tv28 = v20 ^ methodInfo;\n\tCodeStage.AntiCheat.Common.ACTkByte4::UnShuffle(&v16 @ X21_v1 (System.Int32));\n\tv16 = key >> 0x20;\n\tCodeStage.AntiCheat.Common.ACTkByte4::UnShuffle(&key @ X1 (System.Int32));\n\tCodeStage.AntiCheat.Common.ACTkByte4::UnShuffle(&v16 @ X21_v1 (System.Int32));\n\treturn v28;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static Quaternion Decrypt(RawEncryptedQuaternion value, int key)
		{
			//IL_000e: Expected I4, but got O
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Expected I4, but got Unknown
			//IL_005d: Expected O, but got I4
			int num = (object)value >> 32;
			ACTkByte4 aCTkByte = default(ACTkByte4);
			aCTkByte.UnShuffle();
			IntPtr intPtr = default(IntPtr);
			int num2 = (int)(aCTkByte ^ (nint)intPtr);
			((ACTkByte4*)(&num))->UnShuffle();
			num = key >> 32;
			int num3 = default(int);
			((ACTkByte4*)(&num3))->UnShuffle();
			((ACTkByte4*)(&num))->UnShuffle();
			return (Quaternion)num2;
		}

		[Token(Token = "0x60001B2")]
		[Address(RVA = "0xBDF924", Offset = "0xBDF924", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv30 = CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, key, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 1;\n\t*([1A35478]) = v47;\nL_0021:\n\tgoto L_0027;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, key, methodInfo, v32, v33, v34, v35, v36, v49, v38, v39, v40, v41, v42, v43, v44);\nL_0027:\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion::SetEncrypted(&v59 @ stack_-70_v2 (CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion), encrypted, key);\n\t*([returnBuffer @ X8 (CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion)+1C]) = 0;\n\treturnBuffer.currentCryptoKey = v59;\n\t*([returnBuffer @ X8 (CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion)+10]) = 0;\n\treturn &v59 @ stack_-70_v2 (CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion);\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ObscuredQuaternion FromEncrypted(RawEncryptedQuaternion encrypted, int key)
		{
			//IL_0029: Expected I4, but got O
			//IL_0024: Expected native int or pointer, but got O
			//IL_0034: Expected O, but got Ref
			ObscuredQuaternion obscuredQuaternion = default(ObscuredQuaternion);
			obscuredQuaternion.SetEncrypted(encrypted, key);
			_ = 0;
			ObscuredQuaternion obscuredQuaternion2 = default(ObscuredQuaternion);
			((ObscuredQuaternion*)(nint)obscuredQuaternion2)->currentCryptoKey = (int)obscuredQuaternion;
			_ = 0;
			return (ObscuredQuaternion)(&obscuredQuaternion);
		}

		[Token(Token = "0x60001B3")]
		[Address(RVA = "0xBDF648", Offset = "0xBDF648", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\treturn returnVal1;\n")]
		public static int GenerateKey()
		{
			return RandomUtils.GenerateIntKey();
		}

		[Token(Token = "0x60001B4")]
		[Address(RVA = "0xBDFA68", Offset = "0xBDFA68", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0030;\n\tv46 = Il2CppMethodInfo;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, v48, v49, v50, v51, v52, v53, v54, q1, v0, v2, v3, q2, v4, v6, v7);\n\tv67 = System.Math;\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, v48, v49, v50, v51, v52, v53, v54, q1, v0, v2, v3, q2, v4, v6, v7);\n\tv59 = 1;\n\t*([1A35479]) = v59;\nL_0030:\n\tgoto L_0038;\n\tv68 = 0xB348B0(v61, v48, v49, v50, v51, v52, v53, v54, q1, v0, v2, v3, q2, v4, v6, v7);\nL_0038:\n\tgoto L_003B;\n\tv76 = 0xB348B0(v71, v48, v49, v50, v51, v52, v53, v54, q1, v0, v2, v3, q2, v4, v6, v7);\nL_003B:\n\tv79 = v78.<Instance>k__BackingField;\n\tgoto L_0047;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v84, v48, v49, v50, v51, v52, v53, v54, q1, v0, v2, v3, q2, v4, v6, v7);\nL_0047:\n\t// 71 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv100 = q1 >= v79.quaternionEpsilon;\n\tif (v100) goto L_FFFFFFFF;\n\tgoto L_0059;\n\tv199 = \"il2cpp_codegen_runtime_class_init\"(v101, v48, v49, v50, v51, v52, v53, v54, q1, v0, v2, v3, q2, v4, v6, v7);\nL_0059:\n\t// 89 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv106 = q1 >= v79.quaternionEpsilon;\n\tif (v106) goto L_FFFFFFFF;\n\tgoto L_006B;\n\tv215 = \"il2cpp_codegen_runtime_class_init\"(v213, v48, v49, v50, v51, v52, v53, v54, q1, v0, v2, v3, q2, v4, v6, v7);\nL_006B:\n\t// 107 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv107 = q1 >= v79.quaternionEpsilon;\n\tif (v107) goto L_FFFFFFFF;\n\tgoto L_007E;\n\tv219 = \"il2cpp_codegen_runtime_class_init\"(v217, v48, v49, v50, v51, v52, v53, v54, q1, v0, v2, v3, q2, v4, v6, v7);\nL_007E:\n\t// 126 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv208 = q2.w - v79.quaternionEpsilon;\n\tv207 = v208 < 0;\n\tgoto L_0097;\nL_0097:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 118 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool CompareQuaternionsWithTolerance(Quaternion q1, Quaternion q2)
		{
			ObscuredCheatingDetector _003CInstance_003Ek__BackingField = KeepAliveBehaviour<ObscuredCheatingDetector>.Instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
			Quaternion quaternion = default(Quaternion);
			if (quaternion.x < _003CInstance_003Ek__BackingField.quaternionEpsilon)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
				if (quaternion.x < _003CInstance_003Ek__BackingField.quaternionEpsilon)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
					if (quaternion.x < _003CInstance_003Ek__BackingField.quaternionEpsilon)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
						float num = q2.w - _003CInstance_003Ek__BackingField.quaternionEpsilon;
						return num < 0f;
					}
				}
			}
			return false;
		}

		[Token(Token = "0x60001B5")]
		[Address(RVA = "0xBDFBB0", Offset = "0xBDFBB0", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([key @ X1 (System.Int32&)]) = this.currentCryptoKey;\n\treturn this.hiddenValue;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe RawEncryptedQuaternion GetEncrypted(out int key)
		{
			key = default(int);
			ref int reference = ref *(int*)currentCryptoKey;
			return hiddenValue;
		}

		[Token(Token = "0x60001B6")]
		[Address(RVA = "0xBDF9C8", Offset = "0xBDF9C8", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, encrypted, key, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3547A]) = v42;\nL_0018:\n\tthis.hiddenValue = encrypted;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion)+C]) = key;\n\tthis.inited = 1;\n\tthis.currentCryptoKey = methodInfo;\n\tv45 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tthis.fakeValueActive = 0;\n\tv47 = v45 == 0;\n\tif (v47) goto L_003B;\n\tgoto L_002A;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v50, encrypted, key, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_002A:\n\tv61 = CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion::InternalDecrypt(this);\n\tthis.fakeValue = v61;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion)+1C]) = v61.y;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion)+20]) = v61.z;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion)+24]) = v61.w;\n\tthis.fakeValueActive = 1;\nL_003B:\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetEncrypted(RawEncryptedQuaternion encrypted, int key)
		{
			hiddenValue = encrypted;
			inited = true;
			IntPtr intPtr = default(IntPtr);
			currentCryptoKey = (int)(nint)intPtr;
			bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
			fakeValueActive = false;
			if (existsAndIsRunning)
			{
				Quaternion quaternion = (fakeValue = InternalDecrypt());
				_ = quaternion.y;
				_ = quaternion.z;
				_ = quaternion.w;
				fakeValueActive = true;
			}
		}

		[Token(Token = "0x60001B7")]
		[Address(RVA = "0xBDFD90", Offset = "0xBDFD90", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A3547B]) = v37;\nL_0017:\n\tgoto L_001F;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001F:\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion::InternalDecrypt(this);\n\treturn returnVal1;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Quaternion GetDecrypted()
		{
			return InternalDecrypt();
		}

		[Token(Token = "0x60001B8")]
		[Address(RVA = "0xBDFDE4", Offset = "0xBDFDE4", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 1;\n\t*([1A3547C]) = v45;\nL_001B:\n\tgoto L_001E;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v46, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_001E:\n\tv53 = CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion::InternalDecrypt(this);\n\tv61 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tthis.currentCryptoKey = v61;\n\tv67 = CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion::Encrypt(v53, v61);\n\tthis.hiddenValue = v67;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion)+C]) = methodInfo;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RandomizeCryptoKey()
		{
			Quaternion value = InternalDecrypt();
			RawEncryptedQuaternion rawEncryptedQuaternion = Encrypt(value, currentCryptoKey = RandomUtils.GenerateIntKey());
			hiddenValue = rawEncryptedQuaternion;
		}

		[Token(Token = "0x60001B9")]
		[Address(RVA = "0xBDFBC8", Offset = "0xBDFBC8", Length = "0x1C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv36 = Il2CppMethodInfo;\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v36, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv62 = CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv56 = 1;\n\t*([1A3547D]) = v56;\nL_0021:\n\tv60 = ~this.inited;\n\tif (v60) goto L_0077;\n\tgoto L_002F;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v63, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_002F:\n\tv79 = CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion::Decrypt(this.hiddenValue, *([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion)+C]));\n\tv91 = CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector::get_ExistsAndIsRunning();\n\tv101 = v91 == 0;\n\tif (v101) goto L_00A4;\n\tv112 = ~this.fakeValueActive;\n\tif (v112) goto L_00A4;\n\tgoto L_0053;\n\tv221 = \"il2cpp_codegen_runtime_class_init\"(v185, v77, v78, v40, v41, v42, v43, v44, v79, v83, v84, v85, v49, v50, v51, v52);\nL_0053:\n\tv158 = CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion::CompareQuaternionsWithTolerance(v79, this.fakeValue);\n\tv224 = v158 == 0;\n\tv161 = ~v224;\n\tif (v161) goto L_00A4;\n\tgoto L_0068;\n\tv233 = 0xB348B0(v228, v77, v78, v40, v41, v42, v43, v44, returnVal2, v149, v147, v145, v131, v129, v127, v125);\nL_0068:\n\tgoto L_0071;\n\tv241 = 0xB348B0(v236, v77, v78, v40, v41, v42, v43, v44, returnVal2, v149, v147, v145, v131, v129, v127, v125);\nL_0071:\n\tv159 = CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector>::OnCheatingDetected(v219.<Instance>k__BackingField);\n\tgoto L_00A4;\nL_0077:\n\tgoto L_0079;\n\tv80 = \"il2cpp_codegen_runtime_class_init\"(v70, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_0079:\n\tv82 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\tthis.currentCryptoKey = v82;\n\tv99 = CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion::Encrypt(v93.Identity, v82);\n\tthis.hiddenValue = v99;\n\t*([this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion)+C]) = methodInfo;\n\tthis.fakeValueActive = 0;\n\tthis.inited = 1;\n\tthis.fakeValue = v103.Identity;\n\tv143 = v106.Identity;\nL_00A4:\n\treturn v143;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 124 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private Quaternion InternalDecrypt()
		{
			Quaternion result;
			if (inited)
			{
				RawEncryptedQuaternion value = hiddenValue;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion)+C]");
				Quaternion quaternion = Decrypt(value, 0);
				bool existsAndIsRunning = ObscuredCheatingDetector.ExistsAndIsRunning;
				bool flag = !existsAndIsRunning;
				result = quaternion;
				if (!flag)
				{
					bool flag2 = !fakeValueActive;
					result = quaternion;
					if (!flag2)
					{
						bool flag3 = CompareQuaternionsWithTolerance(quaternion, fakeValue);
						bool flag4 = !flag3;
						bool flag5 = !flag4;
						result = quaternion;
						if (!flag5)
						{
							KeepAliveBehaviour<ObscuredCheatingDetector>.Instance.OnCheatingDetected();
							result = quaternion;
						}
					}
				}
			}
			else
			{
				RawEncryptedQuaternion rawEncryptedQuaternion = Encrypt(key: currentCryptoKey = RandomUtils.GenerateIntKey(), value: Identity);
				hiddenValue = rawEncryptedQuaternion;
				fakeValueActive = false;
				inited = true;
				fakeValue = Identity;
				result = Identity;
			}
			return result;
		}

		[Token(Token = "0x60001BA")]
		[Address(RVA = "0xBDFE80", Offset = "0xBDFE80", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([returnBuffer @ X8 (CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion)+1C]) = 0;\n\treturnBuffer.currentCryptoKey = 0;\n\t*([returnBuffer @ X8 (CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion)+10]) = 0;\n\tCodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion::.ctor(returnBuffer, value);\n\treturn returnBuffer;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static implicit operator ObscuredQuaternion(Quaternion value)
		{
			//IL_000f: Expected native int or pointer, but got O
			//IL_0022: Expected native int or pointer, but got O
			_ = 0;
			ObscuredQuaternion obscuredQuaternion = default(ObscuredQuaternion);
			((ObscuredQuaternion*)(nint)obscuredQuaternion)->currentCryptoKey = 0;
			_ = 0;
			*(ObscuredQuaternion*)(nint)obscuredQuaternion = new ObscuredQuaternion(value);
			return obscuredQuaternion;
		}

		[Token(Token = "0x60001BB")]
		[Address(RVA = "0xBDFE94", Offset = "0xBDFE94", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A3547E]) = v37;\nL_0017:\n\tgoto L_001F;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001F:\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion::InternalDecrypt(value);\n\treturn returnVal1;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static implicit operator Quaternion(ObscuredQuaternion value)
		{
			return ((ObscuredQuaternion*)value)->InternalDecrypt();
		}

		[Token(Token = "0x60001BC")]
		[Address(RVA = "0xBDFEE8", Offset = "0xBDFEE8", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A3547F]) = v39;\nL_0018:\n\tgoto L_001B;\n\tv44 = \"il2cpp_codegen_runtime_class_init\"(v40, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_001B:\n\tv47 = CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion::InternalDecrypt(this);\n\tv56 = &v47 @ V0_v1 (UnityEngine.Quaternion) | 4;\n\tv57 = &v47 @ V0_v1 (UnityEngine.Quaternion) + 8;\n\tv58 = &v47 @ V0_v1 (UnityEngine.Quaternion) + 0xC;\n\tv61 = System.Single::GetHashCode(&v47 @ V0_v1 (UnityEngine.Quaternion));\n\tv65 = System.Single::GetHashCode(v56);\n\tv69 = System.Single::GetHashCode(v57);\n\tv73 = System.Single::GetHashCode(v58);\n\tv74 = v61 ^ v65;\n\tv75 = v74 ^ v69;\n\treturnVal1 = v75 ^ v73;\n\treturn returnVal1;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override int GetHashCode()
		{
			//IL_0066: Expected Ref, but got F4
			//IL_0078: Expected Ref, but got F4
			Quaternion quaternion = InternalDecrypt();
			int num = (int)((nint)quaternion | 4);
			float num2 = (float)(ref quaternion) + 1.1E-44f;
			float num3 = (float)(ref quaternion) + 1.7E-44f;
			int hashCode = ((float*)(&quaternion))->GetHashCode();
			int hashCode2 = ((float*)num)->GetHashCode();
			int hashCode3 = ((float*)num2)->GetHashCode();
			int hashCode4 = ((float*)num3)->GetHashCode();
			int num4 = hashCode ^ hashCode2;
			int num5 = num4 ^ hashCode3;
			return num5 ^ hashCode4;
		}

		[Token(Token = "0x60001BD")]
		[Address(RVA = "0xBDFFB0", Offset = "0xBDFFB0", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35480]) = v37;\nL_0017:\n\tgoto L_001A;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001A:\n\tv45 = CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion::InternalDecrypt(this);\n\treturnVal1 = 0xBEE544(&v45 @ V0_v1 (UnityEngine.Quaternion), 0, 0, 0, v23, v24, v25, v26, v45, v45.y, v45.z, v45.w, v31, v32, v33, v34);\n\treturn returnVal1;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			Quaternion quaternion = InternalDecrypt();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BEE544 (inside CodeStage.AntiCheat.Genuine.CodeHash.AndroidWorker+CodeHashGeneratorCallback::OnError +0x30)");
			string result = default(string);
			return result;
		}

		[Token(Token = "0x60001BE")]
		[Address(RVA = "0xBE002C", Offset = "0xBE002C", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, format, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A35481]) = v40;\nL_0019:\n\tgoto L_001C;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, format, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_001C:\n\tv48 = CodeStage.AntiCheat.ObscuredTypes.ObscuredQuaternion::InternalDecrypt(this);\n\treturnVal1 = 0xBEE544(&v48 @ V0_v1 (UnityEngine.Quaternion), format, 0, 0, v26, v27, v28, v29, v48, v48.y, v48.z, v48.w, v34, v35, v36, v37);\n\treturn returnVal1;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string ToString(string format)
		{
			Quaternion quaternion = InternalDecrypt();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BEE544 (inside CodeStage.AntiCheat.Genuine.CodeHash.AndroidWorker+CodeHashGeneratorCallback::OnError +0x30)");
			string result = default(string);
			return result;
		}

		[Obsolete("This API is redundant and does not perform any actions. It will be removed in future updates.")]
		[Token(Token = "0x60001BF")]
		[Address(RVA = "0xBE00B4", Offset = "0xBE00B4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public static void SetNewCryptoKey(int newKey)
		{
		}

		[Obsolete("This API is redundant and does not perform any actions. It will be removed in future updates.")]
		[Token(Token = "0x60001C0")]
		[Address(RVA = "0xBE00B8", Offset = "0xBE00B8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void ApplyNewCryptoKey()
		{
		}

		[Obsolete("Please use new Encrypt(value, key) API instead.", true)]
		[Token(Token = "0x60001C1")]
		[Address(RVA = "0xBE00BC", Offset = "0xBE00BC", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static RawEncryptedQuaternion Encrypt(Quaternion value)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new Decrypt(value, key) API instead.", true)]
		[Token(Token = "0x60001C2")]
		[Address(RVA = "0xBE00F4", Offset = "0xBE00F4", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Quaternion Decrypt(RawEncryptedQuaternion value)
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new GetEncrypted(out key) API instead.", true)]
		[Token(Token = "0x60001C3")]
		[Address(RVA = "0xBE012C", Offset = "0xBE012C", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.Exception();\n\tSystem.Exception::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RawEncryptedQuaternion GetEncrypted()
		{
			Exception ex = new Exception();
			throw ex;
		}

		[Obsolete("Please use new SetEncrypted(encrypted, key) API instead.", true)]
		[Token(Token = "0x60001C4")]
		[Address(RVA = "0xBE0164", Offset = "0xBE0164", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetEncrypted(RawEncryptedQuaternion encrypted)
		{
		}
	}
}
