using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.U2D;

namespace Spine.Unity
{
	[CreateAssetMenu(fileName = "New Spine SpriteAtlas Asset", menuName = "Spine/Spine SpriteAtlas Asset")]
	[Token(Token = "0x2000073")]
	public class SpineSpriteAtlasAsset : AtlasAssetBase
	{
		[Serializable]
		[Token(Token = "0x2000074")]
		protected class SavedRegionInfo
		{
			[Token(Token = "0x40002C1")]
			[FieldOffset(Offset = "0x10")]
			public float x;

			[Token(Token = "0x40002C2")]
			[FieldOffset(Offset = "0x14")]
			public float y;

			[Token(Token = "0x40002C3")]
			[FieldOffset(Offset = "0x18")]
			public float width;

			[Token(Token = "0x40002C4")]
			[FieldOffset(Offset = "0x1C")]
			public float height;

			[Token(Token = "0x40002C5")]
			[FieldOffset(Offset = "0x20")]
			public SpritePackingRotation packingRotation;

			[Token(Token = "0x60004C6")]
			[Address(RVA = "0x15541E4", Offset = "0x15541E4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public SavedRegionInfo()
			{
			}
		}

		[Token(Token = "0x40002BC")]
		[FieldOffset(Offset = "0x18")]
		public SpriteAtlas spriteAtlasFile;

		[Token(Token = "0x40002BD")]
		[FieldOffset(Offset = "0x20")]
		public Material[] materials;

		[Token(Token = "0x40002BE")]
		[FieldOffset(Offset = "0x28")]
		protected Atlas atlas;

		[Token(Token = "0x40002BF")]
		[FieldOffset(Offset = "0x30")]
		public bool updateRegionsInPlayMode;

		[SerializeField]
		[Token(Token = "0x40002C0")]
		[FieldOffset(Offset = "0x38")]
		protected SavedRegionInfo[] savedRegions;

		[Token(Token = "0x1700017A")]
		public override bool IsLoaded
		{
			[Token(Token = "0x60004B9")]
			[Address(RVA = "0x1553534", Offset = "0x1553534", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.atlas == 0;\n\tv11 = ~v6;\n\treturn v11;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				bool flag = atlas == null;
				return !flag;
			}
		}

		[Token(Token = "0x1700017B")]
		public override IEnumerable<Material> Materials
		{
			[Token(Token = "0x60004BA")]
			[Address(RVA = "0x1553544", Offset = "0x1553544", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.materials;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return materials;
			}
		}

		[Token(Token = "0x1700017C")]
		public override int MaterialCount
		{
			[Token(Token = "0x60004BB")]
			[Address(RVA = "0x155354C", Offset = "0x155354C", Length = "0x18")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.materials;\n\tv2 = this.materials == 0;\n\tif (v2) goto L_0006;\n\treturn v0.Length;\nL_0006:\n\treturn 0;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Material[] array = materials;
				if (materials != null)
				{
					return array.Length;
				}
				return 0;
			}
		}

		[Token(Token = "0x1700017D")]
		public override Material PrimaryMaterial
		{
			[Token(Token = "0x60004BC")]
			[Address(RVA = "0x1553564", Offset = "0x1553564", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.materials;\n\treturn v2[0];\n\tv7 = new System.NullReferenceException();\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Material[] array = materials;
				return array[0];
			}
		}

		[Token(Token = "0x60004BD")]
		[Address(RVA = "0x155358C", Offset = "0x155358C", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, materials, initialize, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 1;\n\t*([1A37BE3]) = v43;\nL_0018:\n\tv45 = UnityEngine.ScriptableObject::CreateInstance();\n\tv51 = Spine.Unity.SpineSpriteAtlasAsset::Clear(v45);\n\tv45.spriteAtlasFile = spriteAtlasFile;\n\tv45.materials = materials;\n\tv53 = initialize == 0;\n\tif (v53) goto L_0032;\n\tv59 = Spine.Unity.SpineSpriteAtlasAsset::GetAtlas(v45);\nL_0032:\n\treturn v45;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static SpineSpriteAtlasAsset CreateRuntimeInstance(SpriteAtlas spriteAtlasFile, Material[] materials, bool initialize)
		{
			SpineSpriteAtlasAsset spineSpriteAtlasAsset = ScriptableObject.CreateInstance<SpineSpriteAtlasAsset>();
			spineSpriteAtlasAsset.Clear();
			spineSpriteAtlasAsset.spriteAtlasFile = spriteAtlasFile;
			spineSpriteAtlasAsset.materials = materials;
			if (initialize)
			{
				Atlas atlas = spineSpriteAtlasAsset.GetAtlas();
			}
			return spineSpriteAtlasAsset;
		}

		[Token(Token = "0x60004BE")]
		[Address(RVA = "0x1553618", Offset = "0x1553618", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this->klass;\n\tv2 = this->klass->vtable[8];\n\tv3 = this->klass->vtable[8];\n\t// 3 IndirectJump v2 @ X2_v1, this @ X0 (Spine.Unity.SpineSpriteAtlasAsset), this @ X0 (Spine.Unity.SpineSpriteAtlasAsset), v3 @ X1_v1, v2 @ X2_v1, v4 @ X3, v5 @ X4, v6 @ X5, v7 @ X6, v8 @ X7, v9 @ V0, v10 @ V1, v11 @ V2, v12 @ V3, v13 @ V4, v14 @ V5, v15 @ V6, v16 @ V7\n\treturn;\n")]
		private void Reset()
		{
			//IL_0005: Expected I, but got O
			//IL_0015: Expected O, but got I
			//IL_0025: Expected O, but got I
			nint num = (nint)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1 (Il2CppClass<Spine.Unity.SpineSpriteAtlasAsset>)+1B8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1 (Il2CppClass<Spine.Unity.SpineSpriteAtlasAsset>)+1C0]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v2 @ X2_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60004BF")]
		[Address(RVA = "0x1553624", Offset = "0x1553624", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.atlas = 0;\n\treturn;\n")]
		public override void Clear()
		{
			atlas = null;
		}

		[Token(Token = "0x60004C0")]
		[Address(RVA = "0x155362C", Offset = "0x155362C", Length = "0x2C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv18 = UnityEngine.Debug;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = UnityEngine.Object;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv56 = \"SpriteAtlas file not set for SpineSpriteAtlasAsset: \";\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv61 = \"Materials not set for SpineSpriteAtlasAsset: \";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37BE4]) = v38;\nL_0021:\n\tgoto L_0028;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0028:\n\tv54 = UnityEngine.Object::op_Equality(this.spriteAtlasFile, 0);\n\tv59 = v54 == 0;\n\tif (v59) goto L_0033;\n\tv78 = UnityEngine.Object::get_name(this);\n\tgoto L_004B;\nL_0033:\n\tv67 = this.materials;\n\tv68 = this.materials == 0;\n\tif (v68) goto L_0044;\n\tv71 = v67.Length == 0;\n\tif (v71) goto L_0044;\n\treturnVal1 = this.atlas;\n\tv88 = this.atlas == 0;\n\tv89 = ~v88;\n\tif (v89) goto L_0063;\n\treturnVal1 = Spine.Unity.SpineSpriteAtlasAsset::LoadAtlas(this, this.spriteAtlasFile);\n\tthis.atlas = returnVal1;\n\tgoto L_0063;\nL_0044:\n\tv78 = UnityEngine.Object::get_name(this);\nL_004B:\n\tv86 = System.String::Concat(v80, v78);\n\tgoto L_0057;\n\tv117 = v92;\n\tv118 = \"il2cpp_codegen_runtime_class_init\"(v117, v83, v85, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0057:\n\tUnityEngine.Debug::LogError(v86, this);\n\tv123 = Spine.Unity.SpineSpriteAtlasAsset::Clear(this);\nL_0063:\n\treturn returnVal1;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX20 = X0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0105;\n\tX0 = X20;\n\tX0 = 0x1854E70(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tX0 = *([19352D8]);\n\tX0 = 0xAD94AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X20]);\n\tX1 = *([X8]);\n\tX0 = 0xAD9AE8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_00FB;\n\tX20 = *([X20]);\n\tX0 = 0x1854E80(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([19358B0]);\n\tX0 = 0xAD94AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 6;\n\tX0 = 0xAD9510(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_00FA;\n\tX21 = X0;\n\tX0 = *([1947968]);\n\tX0 = 0xAD94AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X21+18]);\n\tif (TEMP) goto L_00F9;\n\t*([X21+20]) = X0;\n\tX0 = X19;\n\tX1 = 0;\n\tX0 = UnityEngine.Object::get_name(X0, X1);\n\tX8 = *([X21+18]);\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_00F9;\n\t*([X21+28]) = X0;\n\tX0 = *([19358B8]);\n\tX0 = 0xAD94AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X21+18]);\n\tC = X8 < 2;\n\tC = ~C;\n\tTEMP1 = X8 - 2;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 2;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_00F9;\n\t*([X21+30]) = X0;\n\tif (TEMP) goto L_00FA;\n\tX8 = *([X20]);\n\tX0 = X20;\n\tX9 = *([X8+188]);\n\tX1 = *([X8+190]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X21+18]);\n\tC = X8 < 3;\n\tC = ~C;\n\tTEMP1 = X8 - 3;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 3;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_00F9;\n\t*([X21+38]) = X0;\n\tX0 = *([19358B8]);\n\tX0 = 0xAD94AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X21+18]);\n\tC = X8 < 4;\n\tC = ~C;\n\tTEMP1 = X8 - 4;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 4;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_00F9;\n\t*([X21+40]) = X0;\n\tX8 = *([X20]);\n\tX0 = X20;\n\tX9 = *([X8+1C8]);\n\tX1 = *([X8+1D0]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X21+18]);\n\tC = X8 < 5;\n\tC = ~C;\n\tTEMP1 = X8 - 5;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 5;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_00F9;\n\t*([X21+48]) = X0;\n\tX0 = X21;\n\tX1 = 0;\n\tX0 = System.String::Concat(X0, X1);\n\tX20 = X0;\n\tX0 = *([1935278]);\n\tX0 = 0xAD94AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00F4;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00F4:\n\tX0 = X20;\n\tX1 = X19;\n\tX2 = 0;\n\tUnityEngine.Debug::LogError(X0, X1, X2);\n\tgoto L_FFFFFFFF;\nL_00F9:\n\tX0 = IndexOutOfRangeException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00FA:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00FB:\n\tX0 = 8;\n\tX0 = 0x1854E90(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X20]);\n\t*([X0]) = X8;\n\tX1 = X1 + 0xF88;\n\tX2 = 0;\n\tX0 = 0x1854EA0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tX0 = 0x1854E80(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0105:\n\tX0 = X20;\n\tX0 = 0xBD3CD0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = 0x9DACB4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n// 80 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override Atlas GetAtlas()
		{
			string text;
			string text2;
			Atlas result;
			if (spriteAtlasFile == null)
			{
				text = base.name;
				text2 = "SpriteAtlas file not set for SpineSpriteAtlasAsset: ";
			}
			else
			{
				Material[] array = materials;
				if (materials != null && array.Length != 0)
				{
					result = atlas;
					if (atlas == null)
					{
						result = (atlas = LoadAtlas(spriteAtlasFile));
					}
					goto IL_012d;
				}
				text = base.name;
				text2 = "Materials not set for SpineSpriteAtlasAsset: ";
			}
			string message = text2 + text;
			Debug.LogError(message, this);
			Clear();
			result = null;
			goto IL_012d;
			IL_012d:
			return result;
		}

		[Token(Token = "0x60004C1")]
		[Address(RVA = "0x1553D24", Offset = "0x1553D24", Length = "0x404")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv38 = System.IDisposable;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, sprites, usedAtlas, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv60 = System.Collections.Generic.IEnumerator`1<Spine.AtlasRegion>;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, sprites, usedAtlas, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv181 = System.Collections.IEnumerator;\n\tv182 = \"il2cpp_codegen_initialize_runtime_metadata\"(v181, sprites, usedAtlas, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv342 = System.Math;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v342, sprites, usedAtlas, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv56 = 1;\n\t*([1A37BE5]) = v56;\nL_0025:\n\tv57 = this.savedRegions;\n\tv58 = this.savedRegions == 0;\n\tif (v58) goto L_01AA;\n\tv114 = v57.Length != sprites.Length;\n\tif (v114) goto L_01AA;\n\tv377 = Spine.Atlas::GetEnumerator(usedAtlas);\nL_004D:\n\tgoto L_0073;\n\tv478 = *([v472 @ X8_v21+B0]);\n\tv479 = v478 + 8;\n\tv481 = *([v511 @ X10_v43-8]);\n\tv526 = v481 == v473;\n\tif (v526) goto L_006C;\n\tv503 = v521 - 1;\n\tv483 = v511 + 0x10;\n\tv485 = v521 != 1;\n\tif (v485) goto L_FFFFFFFF;\n\tv504 = v256;\n\tv505 = 0;\n\tv506 = 0xB349B4(v504, v473, v505, methodInfo, v41, v42, v43, v44, v201, v199, v197, v189, v187, v185, v191, v52);\n\tgoto L_0073;\nL_006C:\n\tv558 = *([v511 @ X10_v43]);\n\tv559 = v558 << 4;\n\tv560 = v472 + v559;\n\tv561 = v560 + 0x138;\nL_0073:\n\tv581 = System.Collections.IEnumerator::MoveNext(v377);\n\tv583 = v581 == 0;\n\tif (v583) goto L_FFFFFFFF;\n\tgoto L_00A1;\n\tv688 = *([v638 @ X8_v24+B0]);\n\tv689 = v688 + 8;\n\tv691 = *([v755 @ X10_v38-8]);\n\tv770 = v691 == v639;\n\tif (v770) goto L_009A;\n\tv713 = v765 - 1;\n\tv693 = v755 + 0x10;\n\tv695 = v765 != 1;\n\tif (v695) goto L_FFFFFFFF;\n\tv714 = v256;\n\tv715 = 0;\n\tv716 = 0xB349B4(v714, v639, v715, methodInfo, v41, v42, v43, v44, v201, v199, v197, v189, v187, v185, v191, v52);\n\tgoto L_00A1;\nL_009A:\n\tv797 = *([v755 @ X10_v38]);\n\tv798 = v797 << 4;\n\tv799 = v638 + v798;\n\tv800 = v799 + 0x138;\nL_00A1:\n\tv818 = System.Collections.Generic.IEnumerator`1<Spine.AtlasRegion>::get_Current(v377);\n\tv819 = this.savedRegions;\n\tv847 = v819[v260 @ X22_v9 (System.Int32)];\n\tv901 = v818.page;\n\tv906 = v847.packingRotation == 0;\n\tv444 = ~v906;\n\tv911 = v847.packingRotation != 0;\n\tif (v911) goto L_FFFFFFFF;\n\tgoto L_00CB;\nL_00CB:\n\tv818.degrees = v432;\n\tv818.rotate = v444;\n\tv70 = v847.x / v901.width;\n\tv931 = v847.packingRotation != 0;\n\tif (v931) goto L_FFFFFFFF;\n\tgoto L_00E6;\nL_00E6:\n\tv818.u = v70;\n\tv935 = v847.packingRotation != 0;\n\tif (v935) goto L_FFFFFFFF;\n\tgoto L_00F7;\nL_00F7:\n\tv949 = v847.x + v934;\n\tv64 = v847.y + v938;\n\tv951 = v847.x != 0x7F800000;\n\tif (v951) goto L_FFFFFFFF;\n\tgoto L_010A;\nL_010A:\n\tv68 = v949 / v901.width;\n\tv965 = v847.y != 0x7F800000;\n\tif (v965) goto L_FFFFFFFF;\n\tgoto L_0112;\nL_0112:\n\tv80 = v847.y / v901.height;\n\tv78 = v64 / v901.height;\n\tv818.v = v80;\n\tv818.u2 = v68;\n\tv818.v2 = v78;\n\tv818.x = v954;\n\tv818.y = v968;\n\tgoto L_012C;\n\tv974 = \"il2cpp_codegen_runtime_class_init\"(v971, v227, v211, methodInfo, v41, v42, v43, v44, v969, v970, v919, v424, v423, v422, v425, v52);\n\tv976 = *([v468 @ X21_v13 (Spine.AtlasRegion)+34]);\n\tv975 = *([v468 @ X21_v13 (Spine.AtlasRegion)+3C]);\nL_012C:\n\tv987 = v847.width != 0x7F800000;\n\tif (v987) goto L_FFFFFFFF;\n\tgoto L_013C;\nL_013C:\n\tv1001 = v990 >= 0;\n\tif (v1001) goto L_FFFFFFFF;\n\tv441 = -v990;\n\tgoto L_014B;\nL_014B:\n\tv1013 = v847.height != 0x7F800000;\n\tif (v1013) goto L_FFFFFFFF;\n\tgoto L_015A;\nL_015A:\n\tv818.originalWidth = v990;\n\tv818.originalHeight = v462;\n\tv434 = v462 >= 0;\n\tif (v434) goto L_FFFFFFFF;\n\tv470 = -v462;\n\tgoto L_0162;\nL_0162:\n\tv818.v = v78;\n\tv818.v2 = v80;\n\tv818.offsetX = 0f;\n\tv818.width = v441;\n\tv818.height = v470;\n\tv260 = v260 + 1;\n\tgoto L_004D;\nL_016A:\n\tv603 = v161 == 0;\n\tif (v603) goto L_0199;\n\tgoto L_0198;\n\tv717 = *([v643 @ X8_v7+B0]);\n\tv718 = v717 + 8;\n\tv720 = *([v776 @ X10_v10-8]);\n\tv791 = v720 == v646;\n\tif (v791) goto L_0191;\n\tv742 = v786 - 1;\n\tv722 = v776 + 0x10;\n\tv724 = v786 != 1;\n\tif (v724) goto L_FFFFFFFF;\n\tv743 = v161;\n\tv744 = 0;\n\tv745 = 0xB349B4(v743, v646, v744, methodInfo, v41, v42, v43, v44, v80, v78, v76, v68, v66, v64, v70, v52);\n\tgoto L_0198;\nL_0191:\n\tv822 = *([v776 @ X10_v10]);\n\tv823 = v822 << 4;\n\tv824 = v643 + v823;\n\tv825 = v824 + 0x138;\nL_0198:\n\tSystem.IDisposable::Dispose(v161);\nL_0199:\n\tv666 = v157 == 0;\n\tv155 = ~v666;\n\tif (v155) goto L_01B3;\nL_01AA:\n\treturn;\n\tv912 = new System.NullReferenceException();\n\tv869 = new System.NullReferenceException();\n\tv875 = new System.NullReferenceException();\n\tv893 = new System.NullReferenceException();\n\tv249 = new System.IndexOutOfRangeException();\n\tv261 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_01B3:\n\tv407 = new System.OutOfMemoryException();\n\tgoto L_01C6;\n\tgoto L_01C6;\n\tgoto L_01C6;\n\tgoto L_01C6;\n\tgoto L_01C6;\n\tgoto L_01C6;\n\tgoto L_01C6;\n\tgoto L_01C6;\nL_01C6:\n\tv421 = v306 != 1;\n\tif (v421) goto L_01CE;\n\tv477 = 0x1854E70(v407, v306, v290, methodInfo, v41, v42, v43, v44, v280, v278, v276, v268, v266, v264, v270, v52);\n\tv157 = *([v477 @ X0_v28]);\n\tv508 = 0x1854E80(v477, v306, v290, methodInfo, v41, v42, v43, v44, v280, v278, v276, v268, v266, v264, v270, v52);\n\tgoto L_016A;\nL_01CE:\n\tgoto L_01D0;\n\tX21 = X0;\nL_01D0:\n\tv509 = v336 == 0;\n\tif (v509) goto L_0201;\n\tgoto L_01FE;\n\tv604 = *([v532 @ X8_v13+B0]);\n\tv605 = v604 + 8;\n\tv607 = *([v668 @ X10_v20-8]);\n\tv683 = v607 == v535;\n\tif (v683) goto L_01F7;\n\tv629 = v678 - 1;\n\tv609 = v668 + 0x10;\n\tv611 = v678 != 1;\n\tif (v611) goto L_FFFFFFFF;\n\tv630 = v336;\n\tv631 = 0;\n\tv632 = 0xB349B4(v630, v535, v631, methodInfo, v41, v42, v43, v44, v280, v278, v276, v268, v266, v264, v270, v52);\n\tgoto L_01FE;\nL_01F7:\n\tv747 = *([v668 @ X10_v20]);\n\tv748 = v747 << 4;\n\tv749 = v532 + v748;\n\tv750 = v749 + 0x138;\nL_01FE:\n\tSystem.IDisposable::Dispose(v336);\nL_0201:\n\tgoto L_0205;\n\tv634 = 0xBD3CD0(v407, 0, 0, methodInfo, v41, v42, v43, v44, v280, v278, v276, v268, v266, v264, v270, v52);\nL_0205:\n\tv637 = new System.OutOfMemoryException();\n\tv328 = 0x9DACB4(v637, 0, 0, methodInfo, v41, v42, v43, v44, v280, v278, v276, v268, v266, v264, v270, v52);\n\treturn;\n// 327 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void AssignRegionsFromSavedRegions(Sprite[] sprites, Atlas usedAtlas)
		{
			//IL_026f: Expected I4, but got O
			//IL_0171: Expected I4, but got F4
			//IL_0191: Expected I4, but got F4
			//IL_01b1: Expected I4, but got F4
			//IL_01ec: Expected I4, but got F4
			SavedRegionInfo[] array = savedRegions;
			if (savedRegions == null || array.Length != sprites.Length)
			{
				return;
			}
			IEnumerator<AtlasRegion> enumerator = usedAtlas.GetEnumerator();
			int num = 0;
			while (enumerator.MoveNext())
			{
				AtlasRegion current = enumerator.Current;
				SavedRegionInfo[] array2 = savedRegions;
				SavedRegionInfo savedRegionInfo = array2[num];
				AtlasPage page = current.page;
				bool flag = savedRegionInfo.packingRotation == SpritePackingRotation.None;
				bool rotate = !flag;
				int degrees = ((savedRegionInfo.packingRotation != SpritePackingRotation.None) ? 90 : 0);
				current.degrees = degrees;
				current.rotate = rotate;
				float u = savedRegionInfo.x / (float)page.width;
				float num2 = ((savedRegionInfo.packingRotation != SpritePackingRotation.None) ? savedRegionInfo.height : savedRegionInfo.width);
				current.u = u;
				float num3 = ((savedRegionInfo.packingRotation != SpritePackingRotation.None) ? savedRegionInfo.width : savedRegionInfo.height);
				float num4 = savedRegionInfo.x + num2;
				float num5 = savedRegionInfo.y + num3;
				int x = ((savedRegionInfo.x != float.PositiveInfinity) ? ((int)savedRegionInfo.x) : int.MinValue);
				float u2 = num4 / (float)page.width;
				int y = ((savedRegionInfo.y != float.PositiveInfinity) ? ((int)savedRegionInfo.y) : int.MinValue);
				float num6 = savedRegionInfo.y / (float)page.height;
				float num7 = num5 / (float)page.height;
				current.v = num6;
				current.u2 = u2;
				current.v2 = num7;
				current.x = x;
				current.y = y;
				int num8 = ((savedRegionInfo.width != float.PositiveInfinity) ? ((int)savedRegionInfo.width) : int.MinValue);
				int width = ((num8 >= 0) ? num8 : (-num8));
				int num9 = ((savedRegionInfo.height != float.PositiveInfinity) ? ((int)savedRegionInfo.height) : int.MinValue);
				current.originalWidth = num8;
				current.originalHeight = num9;
				int height = ((num9 >= 0) ? num9 : (-num9));
				current.v = num7;
				current.v2 = num6;
				current.offsetX = 0f;
				current.width = width;
				current.height = height;
				num++;
			}
			int num10 = 0;
			IEnumerator<AtlasRegion> enumerator2 = enumerator;
			int num11 = default(int);
			object obj = default(object);
			IEnumerator<AtlasRegion> enumerator3 = default(IEnumerator<AtlasRegion>);
			while (true)
			{
				enumerator2?.Dispose();
				if (num10 == 0)
				{
					return;
				}
				OutOfMemoryException ex = new OutOfMemoryException();
				if (num11 == 1)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @1854E70 (native __cxa_begin_catch)");
					num10 = (int)obj;
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
					enumerator2 = enumerator3;
					continue;
				}
				break;
			}
			enumerator3?.Dispose();
			OutOfMemoryException ex2 = new OutOfMemoryException();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9DACB4");
		}

		[Token(Token = "0x60004C2")]
		[Address(RVA = "0x15538EC", Offset = "0x15538EC", Length = "0x438")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0045;\n\tv44 = Spine.AtlasPage;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, spriteAtlas, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv67 = Spine.AtlasRegion;\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, spriteAtlas, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv72 = Spine.Atlas;\n\tv73 = \"il2cpp_codegen_initialize_runtime_metadata\"(v72, spriteAtlas, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv77 = Il2CppMethodInfo;\n\tv78 = \"il2cpp_codegen_initialize_runtime_metadata\"(v77, spriteAtlas, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv82 = Il2CppMethodInfo;\n\tv83 = \"il2cpp_codegen_initialize_runtime_metadata\"(v82, spriteAtlas, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv86 = Il2CppMethodInfo;\n\tv87 = \"il2cpp_codegen_initialize_runtime_metadata\"(v86, spriteAtlas, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv252 = Il2CppMethodInfo;\n\tv253 = \"il2cpp_codegen_initialize_runtime_metadata\"(v252, spriteAtlas, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv301 = System.Collections.Generic.List`1<Spine.AtlasRegion>;\n\tv302 = \"il2cpp_codegen_initialize_runtime_metadata\"(v301, spriteAtlas, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv305 = System.Collections.Generic.List`1<Spine.AtlasPage>;\n\tv306 = \"il2cpp_codegen_initialize_runtime_metadata\"(v305, spriteAtlas, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv380 = UnityEngine.Sprite[];\n\tv381 = \"il2cpp_codegen_initialize_runtime_metadata\"(v380, spriteAtlas, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv386 = \"(Clone)\";\n\tv387 = \"il2cpp_codegen_initialize_runtime_metadata\"(v386, spriteAtlas, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv392 = \"\";\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v392, spriteAtlas, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv63 = 1;\n\t*([1A37BE6]) = v63;\nL_0045:\n\tv65 = new System.Collections.Generic.List`1<Spine.AtlasPage>();\n\tSystem.Collections.Generic.List`1<Spine.AtlasPage>::.ctor(v65);\n\tv75 = new System.Collections.Generic.List`1<Spine.AtlasRegion>();\n\tSystem.Collections.Generic.List`1<Spine.AtlasRegion>::.ctor(v75);\n\tv92 = UnityEngine.U2D.SpriteAtlas::get_spriteCount(spriteAtlas);\n\t// 88 NewArr v256 @ X0_v13 (UnityEngine.Sprite[]), typeof(UnityEngine.Sprite[]), v92 @ X0_v11 (System.Int32)\n\tv203 = UnityEngine.U2D.SpriteAtlas::GetSprites(spriteAtlas, v256);\n\tv384 = v256.Length == 0;\n\tif (v384) goto L_00B5;\n\tv204 = Spine.Unity.SpineSpriteAtlasAsset::AccessPackedTexture(v256);\n\tv232 = this.materials;\n\tUnityEngine.Material::set_mainTexture(v232[0], v204);\n\tv443 = new Spine.AtlasPage();\n\tSpine.AtlasPage::.ctor(v443);\n\tv205 = UnityEngine.Object::get_name(spriteAtlas);\n\tv443.name = v205;\n\tv450 = UnityEngine.Texture::get_width(v204);\n\tv443.width = v450;\n\tv206 = UnityEngine.Texture::get_height(v204);\n\tv443.height = v206;\n\tv443.vWrap = 1;\n\tv443.format = *([407CD0]);\n\tv443.rendererObject = v232[0];\n\tv234 = v65._items;\n\tv166 = v65._version + 1;\n\tv65._version = v166;\n\tv167 = v65._size;\n\tv457 = v65._size < v234.Length;\n\tv154 = ~v457;\n\tif (v154) goto L_00C2;\n\tv458 = v65._size + 1;\n\tv65._size = v458;\n\tv234[v167 @ X10_v6 (System.Int32)] = v443;\n\tgoto L_00C5;\nL_00B5:\n\treturnVal2 = new Spine.Atlas();\n\tSpine.Atlas::.ctor(returnVal2, v65, v75);\n\tgoto L_016B;\nL_00C2:\n\tSystem.Collections.Generic.List`1<Spine.AtlasPage>::AddWithResize(v65, v443);\nL_00C5:\n\tv207 = Spine.Unity.SpineSpriteAtlasAsset::AccessPackedSprites(spriteAtlas);\n\tv479 = v207.Length < 1;\n\tif (v479) goto L_0152;\nL_00EF:\n\tv208 = new Spine.AtlasRegion();\n\tSpine.AtlasRegion::.ctor(v208);\n\tv209 = UnityEngine.Object::get_name(v207[v192 @ X27_v8 (System.Int32)]);\n\tv210 = System.String::Replace(v209, \"(Clone)\", \"\");\n\tv208.page = v443;\n\tv208.name = v210;\n\tv211 = UnityEngine.Sprite::get_packingRotation(v207[v192 @ X27_v8 (System.Int32)]);\n\tv141 = v211 == 0;\n\tv106 = ~v141;\n\tv96 = v211 != 0;\n\tif (v96) goto L_FFFFFFFF;\n\tgoto L_0116;\nL_0116:\n\tv208.u2 = 0f;\n\tv208.degrees = v530;\n\tv208.rotate = v106;\n\tv208.width = v443.width;\n\tv208.index = v192;\n\tv208.height = v443.height;\n\tv208.originalWidth = v443.width;\n\tv208.originalHeight = v443.height;\n\tv237 = v75._items;\n\tv169 = v75._version + 1;\n\tv75._version = v169;\n\tv497 = v75._size;\n\tv532 = v75._size < v237.Length;\n\tv533 = ~v532;\n\tif (v533) goto L_0140;\n\tv541 = v75._size + 1;\n\tv75._size = v541;\n\tv237[v497 @ X10_v11 (System.Int32)] = v208;\n\tgoto L_0142;\nL_0140:\n\tSystem.Collections.Generic.List`1<Spine.AtlasRegion>::AddWithResize(v75, v208);\nL_0142:\n\tv192 = v192 + 1;\n\tv485 = v192 < v207.Length;\n\tif (v485) goto L_00EF;\nL_0152:\n\treturnVal2 = new Spine.Atlas();\n\tSpine.Atlas::.ctor(returnVal2, v65, v75);\n\tSpine.Unity.SpineSpriteAtlasAsset::AssignRegionsFromSavedRegions(this, v207, returnVal2);\nL_016B:\n\treturn returnVal2;\n\tv250 = new System.NullReferenceException();\n\treturnVal1 = new System.IndexOutOfRangeException();\n\treturn returnVal1;\n// 257 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private Atlas LoadAtlas(SpriteAtlas spriteAtlas)
		{
			List<AtlasPage> list = new List<AtlasPage>();
			List<AtlasRegion> list2 = new List<AtlasRegion>();
			int spriteCount = spriteAtlas.spriteCount;
			Sprite[] array = new Sprite[spriteCount];
			int sprites = spriteAtlas.GetSprites(array);
			Atlas atlas;
			if (array.Length != 0)
			{
				Texture2D texture2D = AccessPackedTexture(array);
				Material[] array2 = materials;
				array2[0].mainTexture = texture2D;
				AtlasPage atlasPage = new AtlasPage();
				string text = spriteAtlas.name;
				atlasPage.name = text;
				int width = texture2D.width;
				atlasPage.width = width;
				int height = texture2D.height;
				atlasPage.height = height;
				atlasPage.vWrap = TextureWrap.ClampToEdge;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [407CD0]");
				atlasPage.format = Format.Alpha;
				atlasPage.rendererObject = array2[0];
				AtlasPage[] items = list._items;
				int version = list._version + 1;
				list._version = version;
				int count = list.Count;
				if (list.Count < items.Length)
				{
					int size = list.Count + 1;
					list._size = size;
					items[count] = atlasPage;
				}
				else
				{
					list.Add(atlasPage);
				}
				Sprite[] array3 = AccessPackedSprites(spriteAtlas);
				if (array3.Length >= 1)
				{
					int num = 0;
					do
					{
						AtlasRegion atlasRegion = new AtlasRegion();
						string text2 = array3[num].name;
						string text3 = text2.Replace("(Clone)", "");
						atlasRegion.page = atlasPage;
						atlasRegion.name = text3;
						SpritePackingRotation packingRotation = array3[num].packingRotation;
						bool flag = packingRotation == SpritePackingRotation.None;
						bool rotate = !flag;
						int degrees = ((packingRotation != SpritePackingRotation.None) ? 90 : 0);
						atlasRegion.u2 = 0f;
						atlasRegion.degrees = degrees;
						atlasRegion.rotate = rotate;
						atlasRegion.width = atlasPage.width;
						atlasRegion.index = num;
						atlasRegion.height = atlasPage.height;
						atlasRegion.originalWidth = atlasPage.width;
						atlasRegion.originalHeight = atlasPage.height;
						AtlasRegion[] items2 = list2._items;
						int version2 = list2._version + 1;
						list2._version = version2;
						int count2 = list2.Count;
						if (list2.Count < items2.Length)
						{
							int size2 = list2.Count + 1;
							list2._size = size2;
							items2[count2] = atlasRegion;
						}
						else
						{
							list2.Add(atlasRegion);
						}
						num++;
					}
					while (num < array3.Length);
				}
				atlas = new Atlas(list, list2);
				AssignRegionsFromSavedRegions(array3, atlas);
			}
			else
			{
				atlas = new Atlas(list, list2);
			}
			return atlas;
		}

		[Token(Token = "0x60004C3")]
		[Address(RVA = "0x1554128", Offset = "0x1554128", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal2 = UnityEngine.Sprite::get_texture(sprites[0]);\n\treturn returnVal2;\n\tv12 = new System.NullReferenceException();\n\treturnVal1 = new System.IndexOutOfRangeException();\n\treturn returnVal1;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Texture2D AccessPackedTexture(Sprite[] sprites)
		{
			return sprites[0].texture;
		}

		[Token(Token = "0x60004C4")]
		[Address(RVA = "0x1554154", Offset = "0x1554154", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = UnityEngine.Sprite[];\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A37BE7]) = v33;\nL_0016:\n\tv39 = UnityEngine.U2D.SpriteAtlas::get_spriteCount(spriteAtlas);\n\t// 26 NewArr returnVal2 @ X0_v10 (UnityEngine.Sprite[]), typeof(UnityEngine.Sprite[]), v39 @ X0_v5 (System.Int32)\n\tv45 = UnityEngine.U2D.SpriteAtlas::GetSprites(spriteAtlas, returnVal2);\n\tv60 = returnVal2.Length != 0;\n\tif (v60) goto L_0036;\n\tgoto L_0036;\nL_0036:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Sprite[] AccessPackedSprites(SpriteAtlas spriteAtlas)
		{
			int spriteCount = spriteAtlas.spriteCount;
			Sprite[] array = new Sprite[spriteCount];
			int sprites = spriteAtlas.GetSprites(array);
			if (array.Length == 0)
			{
				array = null;
			}
			return array;
		}

		[Token(Token = "0x60004C5")]
		[Address(RVA = "0x15541DC", Offset = "0x15541DC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SpineSpriteAtlasAsset()
		{
		}
	}
}
