using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine.Unity
{
	[Token(Token = "0x20000BC")]
	public class SpineAttachment : SpineAttributeBase
	{
		[Token(Token = "0x20000BD")]
		public struct Hierarchy
		{
			[Token(Token = "0x4000438")]
			[FieldOffset(Offset = "0x0")]
			public string skin;

			[Token(Token = "0x4000439")]
			[FieldOffset(Offset = "0x8")]
			public string slot;

			[Token(Token = "0x400043A")]
			[FieldOffset(Offset = "0x10")]
			public string name;

			[Token(Token = "0x60006B7")]
			[Address(RVA = "0x1570D14", Offset = "0x1570D14", Length = "0x188")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = System.Char[];\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, fullPath, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv46 = \"\";\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, fullPath, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A37CE7]) = v41;\nL_001A:\n\t// 26 NewArr v44 @ X0_v3 (System.Char[]), typeof(System.Char[]), 1\n\tv44[0] = 0x2F;\n\tv94 = System.String::Split(fullPath, v44, 1);\n\tv122 = v94.Length == 0;\n\tif (v122) goto L_006F;\n\tv128 = v94.Length <= 1;\n\tif (v128) goto L_0087;\n\tv185 = v94.Length == 2;\n\tthis.skin = v94[0];\n\tthis.slot = v94[1];\n\tthis.name = \"\";\n\tif (v185) goto L_0079;\nL_005C:\n\tv121 = System.String::Concat(v121, *([v94 @ X0_v27 (System.String[])+v123 @ X20_v9 (System.Int32)*8]));\n\tthis.name = v121;\n\tv211 = v123 - 3;\n\tv123 = v123 + 1;\n\tv193 = v211 < v94.Length;\n\tif (v193) goto L_005C;\n\tgoto L_0079;\nL_006F:\n\tthis.skin = \"\";\n\tthis.slot = \"\";\n\tthis.name = \"\";\nL_0079:\n\treturn;\n\tv93 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\nL_0087:\n\tv168 = System.String::Concat(\"Cannot generate Attachment Hierarchy from string! Not enough components! [\", v152, \"]\");\n\tv179 = new System.Exception();\n\tSystem.Exception::.ctor(v179, v168);\n\tthrow v179;\n\treturn;\n// 115 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public Hierarchy(string fullPath)
			{
				//IL_00f7: Expected O, but got I
				string[] array = fullPath.Split(new char[1] { '/' }, StringSplitOptions.RemoveEmptyEntries);
				if (array.Length != 0)
				{
					if (array.Length <= 1)
					{
						string text = default(string);
						string message = "Cannot generate Attachment Hierarchy from string! Not enough components! [" + text + "]";
						Exception ex = new Exception(message);
						throw ex;
					}
					bool flag = array.Length == 2;
					skin = array[0];
					slot = array[1];
					name = "";
					if (!flag)
					{
						string text2 = "";
						int num = 6;
						int num2;
						do
						{
							string text3 = text2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ X0_v27 (System.String[])+v123 @ X20_v9 (System.Int32)*8]");
							text2 = (name = text3 + (string)0);
							num2 = num - 3;
							num++;
						}
						while (num2 < array.Length);
					}
				}
				else
				{
					skin = "";
					slot = "";
					name = "";
				}
			}
		}

		[Token(Token = "0x4000433")]
		[FieldOffset(Offset = "0x22")]
		public bool returnAttachmentPath;

		[Token(Token = "0x4000434")]
		[FieldOffset(Offset = "0x23")]
		public bool currentSkinOnly;

		[Token(Token = "0x4000435")]
		[FieldOffset(Offset = "0x24")]
		public bool placeholdersOnly;

		[Token(Token = "0x4000436")]
		[FieldOffset(Offset = "0x28")]
		public string skinField;

		[Token(Token = "0x4000437")]
		[FieldOffset(Offset = "0x30")]
		public string slotField;

		[Token(Token = "0x60006B3")]
		[Address(RVA = "0x1570C40", Offset = "0x1570C40", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv50 = \"\";\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, currentSkinOnly, returnAttachmentPath, placeholdersOnly, slotField, dataField, skinField, includeNone, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv62 = 1;\n\t*([1A37CE6]) = v62;\nL_002A:\n\tthis.skinField = \"\";\n\tthis.slotField = \"\";\n\tSpine.Unity.SpineAttributeBase::.ctor(this);\n\tthis.currentSkinOnly = currentSkinOnly;\n\tthis.returnAttachmentPath = returnAttachmentPath;\n\tthis.placeholdersOnly = placeholdersOnly;\n\tthis.dataField = dataField;\n\tthis.skinField = skinField;\n\tthis.slotField = slotField;\n\tthis.includeNone = includeNone;\n\tthis.fallbackToTextField = fallbackToTextField;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SpineAttachment(bool currentSkinOnly = true, bool returnAttachmentPath = false, bool placeholdersOnly = false, string slotField = "", string dataField = "", string skinField = "", bool includeNone = true, bool fallbackToTextField = false)
		{
			this.skinField = "";
			this.slotField = "";
			this.currentSkinOnly = currentSkinOnly;
			this.returnAttachmentPath = returnAttachmentPath;
			this.placeholdersOnly = placeholdersOnly;
			base.dataField = dataField;
			this.skinField = skinField;
			this.slotField = slotField;
			base.includeNone = includeNone;
			base.fallbackToTextField = fallbackToTextField;
		}

		[Token(Token = "0x60006B4")]
		[Address(RVA = "0x1570D00", Offset = "0x1570D00", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnBuffer.skin = 0;\n\treturnBuffer.slot = 0;\n\treturnBuffer.name = 0;\n\tSpine.Unity.SpineAttachment+Hierarchy::.ctor(returnBuffer, fullPath);\n\treturn returnBuffer;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static Hierarchy GetHierarchy(string fullPath)
		{
			//IL_0005: Expected native int or pointer, but got O
			//IL_000f: Expected native int or pointer, but got O
			//IL_0019: Expected native int or pointer, but got O
			//IL_0026: Expected native int or pointer, but got O
			Hierarchy hierarchy = default(Hierarchy);
			System.Runtime.CompilerServices.Unsafe.Write(&((Hierarchy*)(nint)hierarchy)->skin, null);
			System.Runtime.CompilerServices.Unsafe.Write(&((Hierarchy*)(nint)hierarchy)->slot, null);
			System.Runtime.CompilerServices.Unsafe.Write(&((Hierarchy*)(nint)hierarchy)->name, null);
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)hierarchy, new Hierarchy(fullPath));
			return hierarchy;
		}

		[Token(Token = "0x60006B5")]
		[Address(RVA = "0x1570E9C", Offset = "0x1570E9C", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = 0;\n\tSpine.Unity.SpineAttachment+Hierarchy::.ctor(&v16 @ stack_-48_v1 (Spine.Unity.SpineAttachment+Hierarchy), attachmentPath);\n\tv24 = System.String::IsNullOrEmpty(0);\n\tv26 = v24 == 0;\n\tif (v26) goto L_0023;\n\treturn 0;\nL_0023:\n\tv63 = Spine.SkeletonData::FindSkin(skeletonData, 0);\n\tv67 = Spine.SkeletonData::FindSlotIndex(skeletonData, 0);\n\treturnVal3 = Spine.Skin::GetAttachment(v63, v67, 0);\n\treturn returnVal3;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Attachment GetAttachment(string attachmentPath, SkeletonData skeletonData)
		{
			Hierarchy hierarchy = default(Hierarchy);
			hierarchy = new Hierarchy(attachmentPath);
			if (string.IsNullOrEmpty(null))
			{
				return null;
			}
			Skin skin = skeletonData.FindSkin(null);
			int slotIndex = skeletonData.FindSlotIndex(null);
			return skin.GetAttachment(slotIndex, null);
		}

		[Token(Token = "0x60006B6")]
		[Address(RVA = "0x1570F44", Offset = "0x1570F44", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = Spine.Unity.SkeletonDataAsset::GetSkeletonData(skeletonDataAsset, 1);\n\treturnVal2 = Spine.Unity.SpineAttachment::GetAttachment(attachmentPath, v12);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Attachment GetAttachment(string attachmentPath, SkeletonDataAsset skeletonDataAsset)
		{
			SkeletonData skeletonData = skeletonDataAsset.GetSkeletonData(quiet: true);
			return GetAttachment(attachmentPath, skeletonData);
		}
	}
}
