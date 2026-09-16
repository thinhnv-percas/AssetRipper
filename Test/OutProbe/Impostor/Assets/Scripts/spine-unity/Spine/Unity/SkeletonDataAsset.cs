using System;
using System.Collections.Generic;
using System.IO;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity
{
	[CreateAssetMenu(fileName = "New SkeletonDataAsset", menuName = "Spine/SkeletonData Asset")]
	[Token(Token = "0x200006B")]
	public class SkeletonDataAsset : ScriptableObject
	{
		[Token(Token = "0x40002A5")]
		[FieldOffset(Offset = "0x18")]
		public AtlasAssetBase[] atlasAssets;

		[Token(Token = "0x40002A6")]
		[FieldOffset(Offset = "0x20")]
		public float scale;

		[Token(Token = "0x40002A7")]
		[FieldOffset(Offset = "0x28")]
		public TextAsset skeletonJSON;

		[Tooltip("Use SkeletonDataModifierAssets to apply changes to the SkeletonData after being loaded, such as apply blend mode Materials to Attachments under slots with special blend modes.")]
		[Token(Token = "0x40002A8")]
		[FieldOffset(Offset = "0x30")]
		public List<SkeletonDataModifierAsset> skeletonDataModifiers;

		[SpineAnimation(null, null, false, false)]
		[Token(Token = "0x40002A9")]
		[FieldOffset(Offset = "0x38")]
		public string[] fromAnimation;

		[SpineAnimation(null, null, false, false)]
		[Token(Token = "0x40002AA")]
		[FieldOffset(Offset = "0x40")]
		public string[] toAnimation;

		[Token(Token = "0x40002AB")]
		[FieldOffset(Offset = "0x48")]
		public float[] duration;

		[Token(Token = "0x40002AC")]
		[FieldOffset(Offset = "0x50")]
		public float defaultMix;

		[Token(Token = "0x40002AD")]
		[FieldOffset(Offset = "0x58")]
		public RuntimeAnimatorController controller;

		[Token(Token = "0x40002AE")]
		[FieldOffset(Offset = "0x60")]
		private SkeletonData skeletonData;

		[Token(Token = "0x40002AF")]
		[FieldOffset(Offset = "0x68")]
		internal AnimationStateData stateData;

		[Token(Token = "0x17000175")]
		public bool IsLoaded
		{
			[Token(Token = "0x6000498")]
			[Address(RVA = "0x15519B8", Offset = "0x15519B8", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.skeletonData == 0;\n\tv11 = ~v6;\n\treturn v11;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				bool flag = skeletonData == null;
				return !flag;
			}
		}

		[Token(Token = "0x6000499")]
		[Address(RVA = "0x15519C8", Offset = "0x15519C8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.skeletonData = 0;\n\tthis.stateData = 0;\n\treturn;\n")]
		private void Reset()
		{
			skeletonData = null;
			stateData = null;
		}

		[Token(Token = "0x600049A")]
		[Address(RVA = "0x15519D8", Offset = "0x15519D8", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv30 = Spine.Unity.AtlasAssetBase[];\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, atlasAsset, initialize, methodInfo, v33, v34, v35, v36, scale, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 1;\n\t*([1A37BD4]) = v46;\nL_001B:\n\t// 27 NewArr v49 @ X0_v3 (Spine.Unity.AtlasAssetBase[]), typeof(Spine.Unity.AtlasAssetBase[]), 1\n\tv52 = atlasAsset == 0;\n\tif (v52) goto L_002B;\n\t// 36 IsInst v57 @ X0_v14, typeof(Spine.Unity.AtlasAssetBase), atlasAsset @ X1 (Spine.Unity.AtlasAssetBase)\n\tv61 = v57 == 0;\n\tif (v61) goto L_003B;\nL_002B:\n\tv49[0] = atlasAsset;\n\treturnVal1 = Spine.Unity.SkeletonDataAsset::CreateRuntimeInstance(skeletonDataFile, v49, initialize, scale);\n\treturn returnVal1;\n\tv53 = new System.NullReferenceException();\n\tv70 = new System.IndexOutOfRangeException();\nL_003B:\n\tv88 = new System.ArrayTypeMismatchException();\n\tthrow v88;\n\treturn returnVal2;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static SkeletonDataAsset CreateRuntimeInstance(TextAsset skeletonDataFile, AtlasAssetBase atlasAsset, bool initialize, float scale = 0.01f)
		{
			AtlasAssetBase[] array = new AtlasAssetBase[1];
			if ((object)atlasAsset != null)
			{
				object obj = atlasAsset as AtlasAssetBase;
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			array[0] = atlasAsset;
			return CreateRuntimeInstance(skeletonDataFile, array, initialize, scale);
		}

		[Token(Token = "0x600049B")]
		[Address(RVA = "0x1551A90", Offset = "0x1551A90", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, atlasAssets, initialize, methodInfo, v33, v34, v35, v36, scale, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 1;\n\t*([1A37BD5]) = v46;\nL_001A:\n\tv48 = UnityEngine.ScriptableObject::CreateInstance();\n\tv48.skeletonData = 0;\n\tv48.stateData = 0;\n\tv48.skeletonJSON = skeletonDataFile;\n\tv48.atlasAssets = atlasAssets;\n\tv48.scale = scale;\n\tv52 = initialize == 0;\n\tif (v52) goto L_0032;\n\tv56 = Spine.Unity.SkeletonDataAsset::GetSkeletonData(v48, 1);\nL_0032:\n\treturn v48;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static SkeletonDataAsset CreateRuntimeInstance(TextAsset skeletonDataFile, AtlasAssetBase[] atlasAssets, bool initialize, float scale = 0.01f)
		{
			SkeletonDataAsset skeletonDataAsset = ScriptableObject.CreateInstance<SkeletonDataAsset>();
			skeletonDataAsset.skeletonData = null;
			skeletonDataAsset.stateData = null;
			skeletonDataAsset.skeletonJSON = skeletonDataFile;
			skeletonDataAsset.atlasAssets = atlasAssets;
			skeletonDataAsset.scale = scale;
			if (initialize)
			{
				SkeletonData skeletonData = skeletonDataAsset.GetSkeletonData(quiet: true);
			}
			return skeletonDataAsset;
		}

		[Token(Token = "0x600049C")]
		[Address(RVA = "0x15519D0", Offset = "0x15519D0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.skeletonData = 0;\n\tthis.stateData = 0;\n\treturn;\n")]
		public void Clear()
		{
			skeletonData = null;
			stateData = null;
		}

		[Token(Token = "0x600049D")]
		[Address(RVA = "0x1551B24", Offset = "0x1551B24", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = this.stateData;\n\tv7 = this.stateData == 0;\n\tv8 = ~v7;\n\tif (v8) goto L_000F;\n\tv11 = Spine.Unity.SkeletonDataAsset::GetSkeletonData(this, 0);\n\treturnVal1 = this.stateData;\nL_000F:\n\treturn returnVal1;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AnimationStateData GetAnimationStateData()
		{
			AnimationStateData result = stateData;
			if (stateData == null)
			{
				SkeletonData skeletonData = GetSkeletonData(quiet: false);
				result = stateData;
			}
			return result;
		}

		[Token(Token = "0x600049E")]
		[Address(RVA = "0x1550ECC", Offset = "0x1550ECC", Length = "0x504")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0033;\n\tv26 = Spine.AtlasAttachmentLoader;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, quiet, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = UnityEngine.Debug;\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, quiet, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv64 = Il2CppMethodInfo;\n\tv65 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, quiet, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv69 = Il2CppMethodInfo;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, quiet, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv78 = Il2CppMethodInfo;\n\tv79 = \"il2cpp_codegen_initialize_runtime_metadata\"(v78, quiet, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv168 = Il2CppMethodInfo;\n\tv169 = \"il2cpp_codegen_initialize_runtime_metadata\"(v168, quiet, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv222 = UnityEngine.Object;\n\tv223 = \"il2cpp_codegen_initialize_runtime_metadata\"(v222, quiet, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv297 = Spine.Unity.RegionlessAttachmentLoader;\n\tv298 = \"il2cpp_codegen_initialize_runtime_metadata\"(v297, quiet, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv383 = \"Skeleton JSON file not set for SkeletonData asset: \";\n\tv384 = \"il2cpp_codegen_initialize_runtime_metadata\"(v383, quiet, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv417 = \".skel\";\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v417, quiet, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv45 = 1;\n\t*([1A37BD6]) = v45;\nL_0033:\n\tv47 = 0;\n\tgoto L_003F;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v46, quiet, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_003F:\n\tv62 = UnityEngine.Object::op_Equality(this.skeletonJSON, 0);\n\tv67 = v62 == 0;\n\tif (v67) goto L_0063;\n\tv72 = quiet == 0;\n\tv73 = ~v72;\n\tif (v73) goto L_0060;\n\tv82 = UnityEngine.Object::get_name(this);\n\tv176 = System.String::Concat(\"Skeleton JSON file not set for SkeletonData asset: \", v82);\n\tgoto L_005E;\n\tv299 = v97;\n\tv300 = \"il2cpp_codegen_runtime_class_init\"(v299, v172, v173, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_005E:\n\tUnityEngine.Debug::LogError(v176, this);\nL_0060:\n\tthis.skeletonData = 0;\n\tthis.stateData = 0;\n\tgoto L_0182;\nL_0063:\n\treturnVal1 = this.skeletonData;\n\tv75 = this.skeletonData == 0;\n\tv76 = ~v75;\n\tif (v76) goto L_0182;\n\tv100 = Spine.Unity.SkeletonDataAsset::GetAtlasArray(this);\n\tv229 = v100.Length == 0;\n\tif (v229) goto L_007B;\n\tv305 = new Spine.AtlasAttachmentLoader();\n\tSpine.AtlasAttachmentLoader::.ctor(v305, v100);\n\tgoto L_0084;\nL_007B:\n\tv309 = new Spine.Unity.RegionlessAttachmentLoader();\n\tSystem.Object::.ctor(v309);\nL_0084:\n\tv275 = UnityEngine.Object::get_name(this.skeletonJSON);\n\tv276 = System.String::ToLower(v275);\n\tv440 = System.String::Contains(v276, \".skel\");\n\tv443 = v440 == 0;\n\tif (v443) goto L_009D;\n\tv448 = UnityEngine.TextAsset::get_bytes(this.skeletonJSON);\n\tv480 = Spine.Unity.SkeletonDataAsset::ReadSkeletonData(v448, v293, this.scale);\n\tgoto L_00A6;\nL_009D:\n\tv445 = this.skeletonJSON == 0;\n\tif (v445) goto L_00DB;\n\tv470 = UnityEngine.TextAsset::get_text(this.skeletonJSON);\n\tv480 = Spine.Unity.SkeletonDataAsset::ReadSkeletonData(v470, v293, this.scale);\nL_00A6:\n\tv482 = v480 == 0;\n\tif (v482) goto L_FFFFFFFF;\n\tv485 = this.skeletonDataModifiers == 0;\n\tif (v485) goto L_00D6;\n\tv501 = System.Collections.Generic.List`1<Spine.Unity.SkeletonDataModifierAsset>::GetEnumerator(this.skeletonDataModifiers);\nL_00B4:\n\tv528 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v47 @ stack_-58_v1 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv507 = v528 == 0;\n\tif (v507) goto L_00D3;\n\tv463 = 0;\n\tgoto L_00C2;\n\tv537 = \"il2cpp_codegen_runtime_class_init\"(v531, v526, v502, v29, v30, v31, v32, v33, v130, v35, v36, v37, v38, v39, v40, v41);\nL_00C2:\n\tv520 = UnityEngine.Object::op_Inequality(0, 0);\n\tv523 = v520 == 0;\n\tif (v523) goto L_00B4;\n\tv525 = *([v463 @ X20_v15 (UnityEngine.Object)]);\n\t*([v525 @ X8_v36 (Il2CppClass<UnityEngine.Object>)+178])(v521, 0, v480, *([v525 @ X8_v36 (Il2CppClass<UnityEngine.Object>)+180]), v29, v30, v31, v32, v33, v130, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_00B4;\nL_00D3:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v47 @ stack_-58_v1 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\nL_00D6:\n\tSpine.Unity.SkeletonDataAsset::InitializeWithData(this, v480);\n\treturnVal1 = this.skeletonData;\n\tgoto L_0182;\n\tv459 = new System.NullReferenceException();\n\tv467 = new System.NullReferenceException();\nL_00DB:\n\tv428 = new System.NullReferenceException();\n\tgoto L_00EB;\n\tgoto L_00EB;\n\tgoto L_00EB;\n\tgoto L_00EB;\n\tgoto L_00EB;\nL_00EB:\n\tv231 = v208 != 1;\n\tif (v231) goto L_01B9;\n\tv496 = 0x1854E70(v428, v208, v206, v29, v30, v31, v32, v33, v198, v35, v36, v37, v38, v39, v40, v41);\n\tv290 = *([v496 @ X0_v35]);\n\tv407 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v290 @ X8_v17]), v206, v29, v30, v31, v32, v33, v198, v35, v36, v37, v38, v39, v40, v41);\n\tv529 = v407 & 1;\n\tv409 = v529 == 0;\n\tif (v409) goto L_0186;\n\tv294 = *([v496 @ X0_v35]);\n\tv490 = 0x1854E80(v407, *([v290 @ X8_v17]), v206, v29, v30, v31, v32, v33, v198, v35, v36, v37, v38, v39, v40, v41);\n\tv536 = v286 == 0;\n\tv492 = ~v536;\n\tif (v492) goto L_FFFFFFFF;\n\t// 259 NewArr v277 @ X0_v44 (System.String[]), typeof(System.String[]), 6\n\tv277[0] = \"Error reading skeleton JSON file for SkeletonData asset: \";\n\tv367 = UnityEngine.Object::get_name(this);\n\tv277[1] = v367;\n\tv277[2] = \"\\n\";\n\tv554 = *([v294 @ X21_v13]);\n\t*([v554 @ X8_v21+188])(v368, v294, *([v554 @ X8_v21+190]), v206, v29, v30, v31, v32, v33, v198, v35, v36, v37, v38, v39, v40, v41);\n\tv277[3] = v368;\n\tv277[4] = \"\\n\";\n\tv562 = *([v294 @ X21_v13]);\n\t*([v562 @ X8_v24+1C8])(v370, v294, *([v562 @ X8_v24+1D0]), v206, v29, v30, v31, v32, v33, v198, v35, v36, v37, v38, v39, v40, v41);\n\tv277[5] = v370;\n\tv568 = System.String::Concat(v277);\n\tgoto L_0178;\n\tv573 = \"il2cpp_codegen_runtime_class_init\"(v571, v567, v266, v29, v30, v31, v32, v33, v258, v35, v36, v37, v38, v39, v40, v41);\nL_0178:\n\tUnityEngine.Debug::LogError(v568, this);\nL_0182:\n\treturn returnVal1;\n\tv295 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\nL_0186:\n\tv415 = 0x1854E90(8, v404, v403, v29, v30, v31, v32, v33, v399, v35, v36, v37, v38, v39, v40, v41);\n\t*([v415 @ X0_v18]) = *([v412 @ X21_v6]);\n\tv208 = 0x185A000 + 0xF88;\n\tv423 = 0x1854EA0(v415, v208, 0, v29, v30, v31, v32, v33, v399, v35, v36, v37, v38, v39, v40, v41);\n\tv425 = 0x1854E80(v423, v208, 0, v29, v30, v31, v32, v33, v399, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_01B9;\n\tgoto L_0194;\n\tgoto L_0194;\n\tgoto L_0194;\n\tgoto L_0194;\nL_0194:\n\tX22 = X0;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_01AD;\n\tX0 = X22;\n\tX0 = 0x1854E70(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = *([X0]);\n\tX0 = 0x1854E80(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([19477F8]);\n\tX0 = &stack[8];\n\tX1 = *([X8]);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(X0, X1);\n\tif (TEMP) goto L_00D6;\n\tX0 = X20;\n\tX0 = OutOfMemoryException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_01AD:\n\tX20 = 0;\n\tgoto L_01B0;\n\tX22 = X0;\nL_01B0:\n\tX8 = 0x1947000;\n\tX8 = *([19477F8]);\n\tX1 = *([X8]);\n\tX0 = &stack[8];\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(X0, X1);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_01BA;\nL_01B9:\n\tv433 = 0xBD3CD0(v202, v208, 0, v29, v30, v31, v32, v33, v399, v35, v36, v37, v38, v39, v40, v41);\nL_01BA:\n\t;\n\tv435 = new System.OutOfMemoryException();\n// ... truncated")]
		public SkeletonData GetSkeletonData(bool quiet)
		{
			//IL_04c3: Expected O, but got I4
			//IL_02b0: Expected I, but got O
			List<object>.Enumerator enumerator = default(List<object>.Enumerator);
			SkeletonData result;
			if (skeletonJSON == null)
			{
				if (!quiet)
				{
					string text = base.name;
					string message = "Skeleton JSON file not set for SkeletonData asset: " + text;
					Debug.LogError(message, this);
				}
				this.skeletonData = null;
				stateData = null;
				result = null;
			}
			else
			{
				result = this.skeletonData;
				if (this.skeletonData == null)
				{
					Atlas[] atlasArray = GetAtlasArray();
					AttachmentLoader attachmentLoader;
					if (atlasArray.Length != 0)
					{
						AtlasAttachmentLoader atlasAttachmentLoader = new AtlasAttachmentLoader(atlasArray);
						attachmentLoader = atlasAttachmentLoader;
					}
					else
					{
						RegionlessAttachmentLoader regionlessAttachmentLoader = new RegionlessAttachmentLoader();
						attachmentLoader = regionlessAttachmentLoader;
					}
					string text2 = skeletonJSON.name;
					string text3 = text2.ToLower();
					SkeletonData skeletonData;
					if (text3.Contains(".skel"))
					{
						byte[] bytes = skeletonJSON.bytes;
						skeletonData = ReadSkeletonData(bytes, attachmentLoader, scale);
						float num = scale;
					}
					else
					{
						if ((object)skeletonJSON == null)
						{
							NullReferenceException ex = new NullReferenceException();
							string text4 = default(string);
							bool flag = (nint)text4 != 1;
							NullReferenceException ex2 = ex;
							if (!flag)
							{
								Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @1854E70 (native __cxa_begin_catch)");
								object obj2 = default(object);
								object obj = obj2;
								Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
								object obj3 = default(object);
								if ((int)((nint)obj3 & 1) != 0)
								{
									object obj4 = obj2;
									Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
									bool flag2 = default(bool);
									if (!flag2)
									{
										string text5 = base.name;
										object obj5 = obj4;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v554 @ X8_v21+188] (should have been resolved before IL gen)");
										object obj6 = obj4;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v562 @ X8_v24+1C8] (should have been resolved before IL gen)");
										object obj7 = default(object);
										object obj8 = default(object);
										string message2 = "Error reading skeleton JSON file for SkeletonData asset: " + text5 + "\n" + (string)obj7 + "\n" + (string)obj8;
										Debug.LogError(message2, this);
									}
									goto IL_0493;
								}
								Il2CppRuntime.Boundary("SYSTEM_API:__cxa_allocate_exception", "Method not found @1854E90 (native __cxa_allocate_exception)");
								object obj10 = default(object);
								object obj9 = obj10;
								text4 = (string)(25534464 + 3976);
								Il2CppRuntime.Boundary("SYSTEM_API:__cxa_throw", "Method not found @1854EA0 (native __cxa_throw)");
								Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
								NullReferenceException ex3 = default(NullReferenceException);
								ex2 = ex3;
							}
							Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BD3CD0");
							OutOfMemoryException ex4 = new OutOfMemoryException();
							Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9DACB4");
							SkeletonData result2 = default(SkeletonData);
							return result2;
						}
						string text6 = skeletonJSON.text;
						skeletonData = ReadSkeletonData(text6, attachmentLoader, scale);
						float num = scale;
					}
					if (skeletonData == null)
					{
						goto IL_0493;
					}
					if (skeletonDataModifiers != null)
					{
						List<SkeletonDataModifierAsset>.Enumerator enumerator2 = skeletonDataModifiers.GetEnumerator();
						while (enumerator.MoveNext())
						{
							UnityEngine.Object obj11 = null;
							if ((UnityEngine.Object)null != (UnityEngine.Object)null)
							{
								nint num2 = (nint)obj11;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v525 @ X8_v36 (Il2CppClass<UnityEngine.Object>)+178] (should have been resolved before IL gen)");
							}
						}
						enumerator.Dispose();
					}
					InitializeWithData(skeletonData);
					result = this.skeletonData;
				}
			}
			goto IL_0533;
			IL_0493:
			result = null;
			goto IL_0533;
			IL_0533:
			return result;
		}

		[Token(Token = "0x600049F")]
		[Address(RVA = "0x1551F8C", Offset = "0x1551F8C", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = Spine.AnimationStateData;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, sd, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A37BD7]) = v40;\nL_0015:\n\tthis.skeletonData = sd;\n\tv42 = new Spine.AnimationStateData();\n\tSpine.AnimationStateData::.ctor(v42, sd);\n\tthis.stateData = v42;\n\tSpine.Unity.SkeletonDataAsset::FillStateData(this);\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void InitializeWithData(SkeletonData sd)
		{
			skeletonData = sd;
			AnimationStateData animationStateData = new AnimationStateData(sd);
			stateData = animationStateData;
			FillStateData();
		}

		[Token(Token = "0x60004A0")]
		[Address(RVA = "0x1551FFC", Offset = "0x1551FFC", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = this.stateData;\n\tv10 = this.stateData == 0;\n\tif (v10) goto L_0072;\n\tv8.defaultMix = this.defaultMix;\n\tv222 = this.fromAnimation;\n\tv47 = v222.Length - 1;\n\tv44 = v222.Length < 1;\n\tif (v44) goto L_0072;\nL_002B:\n\tv33 = v222[v143 @ X9_v5 (System.Int32)];\n\tv225 = v33._stringLength == 0;\n\tif (v225) goto L_0061;\n\tv155 = this.toAnimation;\n\tv115 = v155[v143 @ X9_v5 (System.Int32)];\n\tv237 = v115._stringLength == 0;\n\tif (v237) goto L_0061;\n\tv157 = this.duration;\n\tSpine.AnimationStateData::SetMix(this.stateData, v222[v143 @ X9_v5 (System.Int32)], v155[v143 @ X9_v5 (System.Int32)], v157[v143 @ X9_v5 (System.Int32)]);\nL_0061:\n\tv72 = v47 == v143;\n\tif (v72) goto L_0072;\n\tv222 = this.fromAnimation;\n\tv143 = v143 + 1;\n\tv242 = this.fromAnimation == 0;\n\tv147 = ~v242;\n\tif (v147) goto L_002B;\n\tthrow System.NullReferenceException;\nL_0072:\n\treturn;\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void FillStateData()
		{
			AnimationStateData animationStateData = stateData;
			if (stateData == null)
			{
				return;
			}
			animationStateData.DefaultMix = defaultMix;
			string[] array = fromAnimation;
			int num = array.Length - 1;
			if (array.Length < 1)
			{
				return;
			}
			int num2 = 0;
			while (true)
			{
				string text = array[num2];
				if (text.Length != 0)
				{
					string[] array2 = toAnimation;
					string text2 = array2[num2];
					if (text2.Length != 0)
					{
						float[] array3 = duration;
						stateData.SetMix(array[num2], array2[num2], array3[num2]);
					}
				}
				if (num != num2)
				{
					array = fromAnimation;
					num2++;
					if (fromAnimation == null)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				break;
			}
		}

		[Token(Token = "0x60004A1")]
		[Address(RVA = "0x1551B4C", Offset = "0x1551B4C", Length = "0x19C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv24 = Il2CppMethodInfo;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv48 = Il2CppMethodInfo;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv174 = Il2CppMethodInfo;\n\tv175 = \"il2cpp_codegen_initialize_runtime_metadata\"(v174, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv194 = System.Collections.Generic.List`1<Spine.Atlas>;\n\tv195 = \"il2cpp_codegen_initialize_runtime_metadata\"(v194, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv208 = UnityEngine.Object;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v208, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 1;\n\t*([1A37BD8]) = v44;\nL_0021:\n\tv45 = this.atlasAssets;\n\tv55 = new System.Collections.Generic.List`1<Spine.Atlas>();\n\tSystem.Collections.Generic.List`1<Spine.Atlas>::.ctor(v55, v45.Length);\n\tv192 = this.atlasAssets;\nL_0042:\n\tv57 = v125 >= v192.Length;\n\tif (v57) goto L_009C;\n\tv148 = v192[v125 @ X23_v5 (System.Int32)];\n\tgoto L_005A;\n\tv255 = \"il2cpp_codegen_runtime_class_init\"(v252, v187, v186, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_005A:\n\tv152 = UnityEngine.Object::op_Equality(v192[v125 @ X23_v5 (System.Int32)], 0);\n\tv259 = v152 == 0;\n\tv260 = ~v259;\n\tif (v260) goto L_0089;\n\tv166 = *([v148 @ X21_v7 (UnityEngine.Object)]);\n\t*([v166 @ X8_v12 (Il2CppClass<UnityEngine.Object>)+1C8])(v153, v192[v125 @ X23_v5 (System.Int32)], *([v166 @ X8_v12 (Il2CppClass<UnityEngine.Object>)+1D0]), 0, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv277 = v153 == 0;\n\tif (v277) goto L_0089;\n\tv167 = v55._items;\n\tv69 = v55._version + 1;\n\tv55._version = v69;\n\tv262 = v55._size;\n\tv284 = v55._size < v167.Length;\n\tv272 = ~v284;\n\tif (v272) goto L_0088;\n\tv263 = v55._size + 1;\n\tv55._size = v263;\n\tv167[v262 @ X10_v7 (System.Int32)] = v153;\n\tgoto L_0089;\nL_0088:\n\tSystem.Collections.Generic.List`1<Spine.Atlas>::AddWithResize(v55, v153);\nL_0089:\n\tv192 = this.atlasAssets;\n\tv125 = v125 + 1;\n\tv281 = this.atlasAssets == 0;\n\tv156 = ~v281;\n\tif (v156) goto L_0042;\n\tv172 = new System.NullReferenceException();\nL_009C:\n\treturnVal1 = System.Collections.Generic.List`1<Spine.Atlas>::ToArray(v171);\n\treturn returnVal1;\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\n// 108 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal Atlas[] GetAtlasArray()
		{
			//IL_0094: Expected I, but got O
			AtlasAssetBase[] array = atlasAssets;
			List<Atlas> list = new List<Atlas>(array.Length);
			AtlasAssetBase[] array2 = atlasAssets;
			int num = 0;
			List<Atlas> list2;
			Atlas atlas = default(Atlas);
			while (true)
			{
				bool flag = num >= array2.Length;
				list2 = list;
				if (flag)
				{
					break;
				}
				UnityEngine.Object obj = array2[num];
				if (!(array2[num] == null))
				{
					nint num2 = (nint)obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v166 @ X8_v12 (Il2CppClass<UnityEngine.Object>)+1C8] (should have been resolved before IL gen)");
					if (atlas != null)
					{
						Atlas[] items = list._items;
						int version = list._version + 1;
						list._version = version;
						int count = list.Count;
						if (list.Count < items.Length)
						{
							int size = list.Count + 1;
							list._size = size;
							items[count] = atlas;
						}
						else
						{
							list.Add(atlas);
						}
					}
				}
				array2 = atlasAssets;
				num++;
				bool flag2 = atlasAssets == null;
				bool flag3 = !flag2;
				list2 = list;
				if (!flag3)
				{
					NullReferenceException ex = new NullReferenceException();
					break;
				}
			}
			return list2.ToArray();
		}

		[Token(Token = "0x60004A2")]
		[Address(RVA = "0x1551CE8", Offset = "0x1551CE8", Length = "0x1F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv30 = System.IDisposable;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, attachmentLoader, methodInfo, v33, v34, v35, v36, v37, scale, v38, v39, v40, v41, v42, v43, v44);\n\tv54 = System.IO.MemoryStream;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, attachmentLoader, methodInfo, v33, v34, v35, v36, v37, scale, v38, v39, v40, v41, v42, v43, v44);\n\tv60 = Spine.SkeletonBinary;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, attachmentLoader, methodInfo, v33, v34, v35, v36, v37, scale, v38, v39, v40, v41, v42, v43, v44);\n\tv48 = 1;\n\t*([1A37BD9]) = v48;\nL_0023:\n\tv52 = new System.IO.MemoryStream();\n\tSystem.IO.MemoryStream::.ctor(v52, bytes);\n\tv62 = new Spine.SkeletonBinary();\n\tSpine.SkeletonBinary::.ctor(v62, attachmentLoader);\n\tv66 = v62 == 0;\n\tif (v66) goto L_0073;\n\tv62.<Scale>k__BackingField = scale;\n\tv70 = Spine.SkeletonBinary::ReadSkeletonData(v62, v52);\n\tv127 = v52 == 0;\n\tif (v127) goto L_0064;\nL_003D:\n\tgoto L_0063;\n\tv187 = *([v161 @ X8_v11+B0]);\n\tv188 = v187 + 8;\n\tv190 = *([v238 @ X10_v15-8]);\n\tv244 = v190 == v162;\n\tif (v244) goto L_005C;\n\tv212 = v239 - 1;\n\tv210 = v238 + 0x10;\n\tv192 = v239 != 1;\n\tif (v192) goto L_FFFFFFFF;\n\tv213 = v58;\n\tv214 = 0;\n\tv215 = 0xB349B4(v213, v162, v214, v33, v34, v35, v36, v37, scale, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_0063;\nL_005C:\n\tv294 = *([v238 @ X10_v15]);\n\tv295 = v294 << 4;\n\tv296 = v161 + v295;\n\tv297 = v296 + 0x138;\nL_0063:\n\tSystem.IDisposable::Dispose(v52);\nL_0064:\n\tv184 = v121 == 0;\n\tv117 = ~v184;\n\tif (v117) goto L_0072;\n\treturn v119;\nL_0072:\n\tv115 = new System.OutOfMemoryException();\nL_0073:\n\tthrow v62;\n\tgoto L_0080;\nL_0080:\n\tv131 = v112 != 1;\n\tif (v131) goto L_008C;\n\tv226 = 0x1854E70(v124, v112, v110, v33, v34, v35, v36, v37, scale, v38, v39, v40, v41, v42, v43, v44);\n\tv159 = *([v226 @ X0_v26]);\n\tv153 = 0x1854E80(v226, v112, v110, v33, v34, v35, v36, v37, scale, v38, v39, v40, v41, v42, v43, v44);\n\tv301 = v52 == 0;\n\tv155 = ~v301;\n\tif (v155) goto L_003D;\n\tgoto L_0064;\nL_008C:\n\tgoto L_008E;\n\tX21 = X0;\nL_008E:\n\tv292 = v52 == 0;\n\tif (v292) goto L_00BD;\n\tgoto L_00BA;\n\tv326 = *([v302 @ X8_v6+B0]);\n\tv327 = v326 + 8;\n\tv329 = *([v370 @ X10_v8-8]);\n\tv376 = v329 == v303;\n\tif (v376) goto L_00B3;\n\tv351 = v371 - 1;\n\tv349 = v370 + 0x10;\n\tv331 = v371 != 1;\n\tif (v331) goto L_FFFFFFFF;\n\tv352 = v58;\n\tv353 = 0;\n\tv354 = 0xB349B4(v352, v303, v353, v33, v34, v35, v36, v37, scale, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_00BA;\nL_00B3:\n\tv382 = *([v370 @ X10_v8]);\n\tv383 = v382 << 4;\n\tv384 = v302 + v383;\n\tv385 = v384 + 0x138;\nL_00BA:\n\tSystem.IDisposable::Dispose(v52, Il2CppMethodInfo);\nL_00BD:\n\tif (-2) goto L_00C1;\n\tv356 = 0xBD3CD0(v124, v279, v277, v33, v34, v35, v36, v37, scale, v38, v39, v40, v41, v42, v43, v44);\nL_00C1:\n\tv359 = new System.OutOfMemoryException();\n\treturnVal2 = 0x9DACB4(v359, v279, v277, v33, v34, v35, v36, v37, scale, v38, v39, v40, v41, v42, v43, v44);\n\treturn returnVal2;\n// 114 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static SkeletonData ReadSkeletonData(byte[] bytes, AttachmentLoader attachmentLoader, float scale)
		{
			MemoryStream memoryStream = new MemoryStream(bytes);
			SkeletonBinary skeletonBinary = new SkeletonBinary(attachmentLoader);
			if (skeletonBinary != null)
			{
				skeletonBinary.Scale = scale;
				SkeletonData skeletonData = skeletonBinary.ReadSkeletonData(memoryStream);
				bool flag = memoryStream == null;
				SkeletonData result = skeletonData;
				int num = 0;
				if (!flag)
				{
					((IDisposable)memoryStream).Dispose();
					result = skeletonData;
					num = 0;
				}
				if (num == 0)
				{
					return result;
				}
				OutOfMemoryException ex = new OutOfMemoryException();
			}
			throw skeletonBinary;
		}

		[Token(Token = "0x60004A3")]
		[Address(RVA = "0x1551ED8", Offset = "0x1551ED8", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv30 = Spine.SkeletonJson;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, attachmentLoader, methodInfo, v33, v34, v35, v36, v37, scale, v38, v39, v40, v41, v42, v43, v44);\n\tv52 = System.IO.StringReader;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, attachmentLoader, methodInfo, v33, v34, v35, v36, v37, scale, v38, v39, v40, v41, v42, v43, v44);\n\tv48 = 1;\n\t*([1A37BDA]) = v48;\nL_001E:\n\tv50 = new System.IO.StringReader();\n\tSystem.IO.StringReader::.ctor(v50, text);\n\tv57 = new Spine.SkeletonJson();\n\tSpine.SkeletonJson::.ctor(v57, attachmentLoader);\n\tv61 = v57 == 0;\n\tif (v61) goto L_0039;\n\tv57.<Scale>k__BackingField = scale;\n\treturnVal1 = Spine.SkeletonJson::ReadSkeletonData(v57, v50);\n\treturn returnVal1;\nL_0039:\n\tthrow v57;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static SkeletonData ReadSkeletonData(string text, AttachmentLoader attachmentLoader, float scale)
		{
			StringReader reader = new StringReader(text);
			SkeletonJson skeletonJson = new SkeletonJson(attachmentLoader);
			if (skeletonJson != null)
			{
				skeletonJson.Scale = scale;
				return skeletonJson.ReadSkeletonData(reader);
			}
			throw skeletonJson;
		}

		[Token(Token = "0x60004A4")]
		[Address(RVA = "0x15520D0", Offset = "0x15520D0", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\tv34 = Spine.Unity.AtlasAssetBase[];\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv59 = Il2CppMethodInfo;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv66 = System.Collections.Generic.List`1<Spine.Unity.SkeletonDataModifierAsset>;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv71 = System.Single[];\n\tv72 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv77 = System.String[];\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v77, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv54 = 1;\n\t*([1A37BDB]) = v54;\nL_002D:\n\t// 45 NewArr v57 @ X0_v3 (Spine.Unity.AtlasAssetBase[]), typeof(Spine.Unity.AtlasAssetBase[]), 0\n\tthis.atlasAssets = v57;\n\tthis.scale = 0.01f;\n\tv64 = new System.Collections.Generic.List`1<Spine.Unity.SkeletonDataModifierAsset>();\n\tSystem.Collections.Generic.List`1<Spine.Unity.SkeletonDataModifierAsset>::.ctor(v64);\n\tthis.skeletonDataModifiers = v64;\n\t// 58 NewArr v75 @ X0_v7 (System.String[]), typeof(System.String[]), 0\n\tthis.fromAnimation = v75;\n\t// 62 NewArr v80 @ X0_v9 (System.String[]), typeof(System.String[]), 0\n\tthis.toAnimation = v80;\n\t// 66 NewArr v83 @ X0_v11 (System.Single[]), typeof(System.Single[]), 0\n\tthis.duration = v83;\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SkeletonDataAsset()
		{
			AtlasAssetBase[] array = new AtlasAssetBase[0];
			atlasAssets = array;
			scale = 0.01f;
			List<SkeletonDataModifierAsset> list = new List<SkeletonDataModifierAsset>();
			skeletonDataModifiers = list;
			string[] array2 = new string[0];
			fromAnimation = array2;
			string[] array3 = new string[0];
			toAnimation = array3;
			float[] array4 = new float[0];
			duration = array4;
		}
	}
}
