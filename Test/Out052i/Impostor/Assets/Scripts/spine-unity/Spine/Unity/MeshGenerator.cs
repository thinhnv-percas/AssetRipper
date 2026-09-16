using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity
{
	[Serializable]
	[Token(Token = "0x20000AA")]
	public class MeshGenerator
	{
		[Serializable]
		[Token(Token = "0x20000AB")]
		public struct Settings
		{
			[Token(Token = "0x400040A")]
			[FieldOffset(Offset = "0x0")]
			public bool useClipping;

			[Space]
			[Range(-0.1f, 0f)]
			[Token(Token = "0x400040B")]
			[FieldOffset(Offset = "0x4")]
			public float zSpacing;

			[Header("Vertex Data")]
			[Space]
			[Token(Token = "0x400040C")]
			[FieldOffset(Offset = "0x8")]
			public bool pmaVertexColors;

			[Token(Token = "0x400040D")]
			[FieldOffset(Offset = "0x9")]
			public bool tintBlack;

			[Tooltip("Enable when using Additive blend mode at SkeletonGraphic under a CanvasGroup. When enabled, Additive alpha value is stored at uv2.g instead of color.a to capture CanvasGroup modifying color.a.")]
			[Token(Token = "0x400040E")]
			[FieldOffset(Offset = "0xA")]
			public bool canvasGroupTintBlack;

			[Token(Token = "0x400040F")]
			[FieldOffset(Offset = "0xB")]
			public bool calculateTangents;

			[Token(Token = "0x4000410")]
			[FieldOffset(Offset = "0xC")]
			public bool addNormals;

			[Token(Token = "0x4000411")]
			[FieldOffset(Offset = "0xD")]
			public bool immutableTriangles;

			[Token(Token = "0x170001BB")]
			public static Settings Default
			{
				[Token(Token = "0x600068C")]
				[Address(RVA = "0x156D09C", Offset = "0x156D09C", Length = "0xC")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					//IL_0006: Expected O, but got I4
					return (Settings)1;
				}
			}
		}

		[Token(Token = "0x40003F3")]
		[FieldOffset(Offset = "0x10")]
		public Settings settings;

		[Token(Token = "0x40003F4")]
		private const float BoundsMinDefault = float.PositiveInfinity;

		[Token(Token = "0x40003F5")]
		private const float BoundsMaxDefault = float.NegativeInfinity;

		[NonSerialized]
		[Token(Token = "0x40003F6")]
		[FieldOffset(Offset = "0x20")]
		internal readonly ExposedList<Vector3> vertexBuffer;

		[NonSerialized]
		[Token(Token = "0x40003F7")]
		[FieldOffset(Offset = "0x28")]
		private readonly ExposedList<Vector2> uvBuffer;

		[NonSerialized]
		[Token(Token = "0x40003F8")]
		[FieldOffset(Offset = "0x30")]
		private readonly ExposedList<Color32> colorBuffer;

		[NonSerialized]
		[Token(Token = "0x40003F9")]
		[FieldOffset(Offset = "0x38")]
		private readonly ExposedList<ExposedList<int>> submeshes;

		[NonSerialized]
		[Token(Token = "0x40003FA")]
		[FieldOffset(Offset = "0x40")]
		private Vector2 meshBoundsMin;

		[NonSerialized]
		[Token(Token = "0x40003FB")]
		[FieldOffset(Offset = "0x48")]
		private Vector2 meshBoundsMax;

		[NonSerialized]
		[Token(Token = "0x40003FC")]
		[FieldOffset(Offset = "0x50")]
		private float meshBoundsThickness;

		[NonSerialized]
		[Token(Token = "0x40003FD")]
		[FieldOffset(Offset = "0x54")]
		private int submeshIndex;

		[NonSerialized]
		[Token(Token = "0x40003FE")]
		[FieldOffset(Offset = "0x58")]
		private SkeletonClipping clipper;

		[NonSerialized]
		[Token(Token = "0x40003FF")]
		[FieldOffset(Offset = "0x60")]
		private float[] tempVerts;

		[NonSerialized]
		[Token(Token = "0x4000400")]
		[FieldOffset(Offset = "0x68")]
		private int[] regionTriangles;

		[NonSerialized]
		[Token(Token = "0x4000401")]
		[FieldOffset(Offset = "0x70")]
		private Vector3[] normals;

		[NonSerialized]
		[Token(Token = "0x4000402")]
		[FieldOffset(Offset = "0x78")]
		private Vector4[] tangents;

		[NonSerialized]
		[Token(Token = "0x4000403")]
		[FieldOffset(Offset = "0x80")]
		private Vector2[] tempTanBuffer;

		[NonSerialized]
		[Token(Token = "0x4000404")]
		[FieldOffset(Offset = "0x88")]
		private ExposedList<Vector2> uv2;

		[NonSerialized]
		[Token(Token = "0x4000405")]
		[FieldOffset(Offset = "0x90")]
		private ExposedList<Vector2> uv3;

		[Token(Token = "0x4000406")]
		private static List<Vector3> AttachmentVerts;

		[Token(Token = "0x4000407")]
		private static List<Vector2> AttachmentUVs;

		[Token(Token = "0x4000408")]
		private static List<Color32> AttachmentColors32;

		[Token(Token = "0x4000409")]
		private static List<int> AttachmentIndices;

		[Token(Token = "0x170001B9")]
		public int VertexCount
		{
			[Token(Token = "0x6000674")]
			[Address(RVA = "0x1566EAC", Offset = "0x1566EAC", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.vertexBuffer;\n\treturn v2.Count;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ExposedList<Vector3> exposedList = vertexBuffer;
				return exposedList.Count;
			}
		}

		[Token(Token = "0x170001BA")]
		public unsafe MeshGeneratorBuffers Buffers
		{
			[Token(Token = "0x6000675")]
			[Address(RVA = "0x156D058", Offset = "0x156D058", Length = "0x44")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.vertexBuffer;\n\tv5 = this.uvBuffer;\n\tv9 = this.colorBuffer;\n\treturnBuffer.vertexCount = v2.Count;\n\t*([returnBuffer @ X8 (Spine.Unity.MeshGeneratorBuffers)+4]) = 0;\n\treturnBuffer.vertexBuffer = v2.Items;\n\treturnBuffer.uvBuffer = v5.Items;\n\treturnBuffer.colorBuffer = v9.Items;\n\treturnBuffer.meshGenerator = this;\n\treturn this;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_003a: Expected native int or pointer, but got O
				//IL_0052: Expected native int or pointer, but got O
				//IL_0064: Expected native int or pointer, but got O
				//IL_0076: Expected native int or pointer, but got O
				//IL_0080: Expected native int or pointer, but got O
				ExposedList<Vector3> exposedList = vertexBuffer;
				ExposedList<Vector2> exposedList2 = uvBuffer;
				ExposedList<Color32> exposedList3 = colorBuffer;
				MeshGeneratorBuffers meshGeneratorBuffers = default(MeshGeneratorBuffers);
				((MeshGeneratorBuffers*)(nint)meshGeneratorBuffers)->vertexCount = exposedList.Count;
				_ = 0;
				System.Runtime.CompilerServices.Unsafe.Write(&((MeshGeneratorBuffers*)(nint)meshGeneratorBuffers)->vertexBuffer, exposedList.Items);
				System.Runtime.CompilerServices.Unsafe.Write(&((MeshGeneratorBuffers*)(nint)meshGeneratorBuffers)->uvBuffer, exposedList2.Items);
				System.Runtime.CompilerServices.Unsafe.Write(&((MeshGeneratorBuffers*)(nint)meshGeneratorBuffers)->colorBuffer, exposedList3.Items);
				System.Runtime.CompilerServices.Unsafe.Write(&((MeshGeneratorBuffers*)(nint)meshGeneratorBuffers)->meshGenerator, this);
				return (MeshGeneratorBuffers)this;
			}
		}

		[Token(Token = "0x6000676")]
		[Address(RVA = "0x156453C", Offset = "0x156453C", Length = "0x294")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0059;\n\tv50 = Il2CppMethodInfo;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv75 = Il2CppMethodInfo;\n\tv76 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv81 = Il2CppMethodInfo;\n\tv82 = \"il2cpp_codegen_initialize_runtime_metadata\"(v81, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv86 = Il2CppMethodInfo;\n\tv87 = \"il2cpp_codegen_initialize_runtime_metadata\"(v86, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv92 = Il2CppMethodInfo;\n\tv93 = \"il2cpp_codegen_initialize_runtime_metadata\"(v92, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv97 = Il2CppMethodInfo;\n\tv98 = \"il2cpp_codegen_initialize_runtime_metadata\"(v97, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv103 = Il2CppMethodInfo;\n\tv104 = \"il2cpp_codegen_initialize_runtime_metadata\"(v103, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv108 = Spine.ExposedList`1<UnityEngine.Vector3>;\n\tv109 = \"il2cpp_codegen_initialize_runtime_metadata\"(v108, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv113 = Spine.ExposedList`1<System.Int32>;\n\tv114 = \"il2cpp_codegen_initialize_runtime_metadata\"(v113, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv118 = Spine.ExposedList`1<UnityEngine.Vector2>;\n\tv119 = \"il2cpp_codegen_initialize_runtime_metadata\"(v118, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv126 = Spine.ExposedList`1<Spine.ExposedList`1<System.Int32>>;\n\tv127 = \"il2cpp_codegen_initialize_runtime_metadata\"(v126, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv130 = Spine.ExposedList`1<UnityEngine.Color32>;\n\tv131 = \"il2cpp_codegen_initialize_runtime_metadata\"(v130, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv162 = System.Int32[];\n\tv163 = \"il2cpp_codegen_initialize_runtime_metadata\"(v162, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv167 = System.Single[];\n\tv168 = \"il2cpp_codegen_initialize_runtime_metadata\"(v167, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv203 = Spine.SkeletonClipping;\n\tv204 = \"il2cpp_codegen_initialize_runtime_metadata\"(v203, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv209 = Il2CppFieldInfo;\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v209, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv70 = 1;\n\t*([1A37CBE]) = v70;\nL_0059:\n\t// 89 NotImplemented \"Instruction DUP not yet implemented.\"\n\tthis.settings = v59;\n\tv73 = new Spine.ExposedList`1<UnityEngine.Vector3>();\n\tSpine.ExposedList`1<UnityEngine.Vector3>::.ctor(v73, 4);\n\tthis.vertexBuffer = v73;\n\tv84 = new Spine.ExposedList`1<UnityEngine.Vector2>();\n\tSpine.ExposedList`1<UnityEngine.Vector2>::.ctor(v84, 4);\n\tthis.uvBuffer = v84;\n\tv95 = new Spine.ExposedList`1<UnityEngine.Color32>();\n\tSpine.ExposedList`1<UnityEngine.Color32>::.ctor(v95, 4);\n\tthis.colorBuffer = v95;\n\tv106 = new Spine.ExposedList`1<Spine.ExposedList`1<System.Int32>>();\n\tSpine.ExposedList`1<Spine.ExposedList`1<System.Int32>>::.ctor(v106);\n\tv116 = new Spine.ExposedList`1<System.Int32>();\n\tSpine.ExposedList`1<System.Int32>::.ctor(v116, 6);\n\tSpine.ExposedList`1<Spine.ExposedList`1<System.Int32>>::Add(v106, v116);\n\tthis.submeshes = v106;\n\tv165 = new Spine.SkeletonClipping();\n\tSpine.SkeletonClipping::.ctor(v165);\n\tthis.clipper = v165;\n\t// 150 NewArr v207 @ X0_v18 (System.Single[]), typeof(System.Single[]), 8\n\tthis.tempVerts = v207;\n\t// 154 NewArr v212 @ X0_v20 (System.Int32[]), typeof(System.Int32[]), 6\n\tSystem.Runtime.CompilerServices.RuntimeHelpers::InitializeArray(v212, Il2CppFieldInfo);\n\tthis.regionTriangles = v212;\n\tSystem.Object::.ctor(this);\n\tSpine.ExposedList`1<Spine.ExposedList`1<System.Int32>>::TrimExcess(this.submeshes);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 121 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MeshGenerator()
		{
			//IL_0102: Expected O, but got I4
			//IL_011b: Expected O, but got I4
			//IL_001f: Expected O, but got I4
			//IL_004c: Expected O, but got I4
			base._002Ector();
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
			Settings settings = default(Settings);
			this.settings = settings;
			ExposedList<Vector3> exposedList = new ExposedList<Vector3>((IEnumerable<Vector3>)4);
			vertexBuffer = exposedList;
			ExposedList<Vector2> exposedList2 = new ExposedList<Vector2>((IEnumerable<Vector2>)4);
			uvBuffer = exposedList2;
			ExposedList<Color32> exposedList3 = new ExposedList<Color32>((IEnumerable<Color32>)4);
			colorBuffer = exposedList3;
			ExposedList<ExposedList<int>> exposedList4 = new ExposedList<ExposedList<int>>();
			ExposedList<int> item = new ExposedList<int>((IEnumerable<int>)6);
			exposedList4.Add(item);
			submeshes = exposedList4;
			SkeletonClipping skeletonClipping = new SkeletonClipping();
			clipper = skeletonClipping;
			float[] array = new float[8];
			tempVerts = array;
			regionTriangles = new int[6] { 0, 1, 2, 2, 3, 0 };
			submeshes.TrimExcess();
		}

		[Token(Token = "0x6000677")]
		[Address(RVA = "0x156D0A8", Offset = "0x156D0A8", Length = "0x430")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0032;\n\tv36 = Spine.AtlasRegion;\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v36, skeleton, material, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv57 = Spine.ClippingAttachment;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, skeleton, material, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv266 = Il2CppMethodInfo;\n\tv267 = \"il2cpp_codegen_initialize_runtime_metadata\"(v266, skeleton, material, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv331 = Il2CppMethodInfo;\n\tv332 = \"il2cpp_codegen_initialize_runtime_metadata\"(v331, skeleton, material, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv380 = UnityEngine.Material;\n\tv381 = \"il2cpp_codegen_initialize_runtime_metadata\"(v380, skeleton, material, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv385 = Spine.MeshAttachment;\n\tv386 = \"il2cpp_codegen_initialize_runtime_metadata\"(v385, skeleton, material, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv445 = UnityEngine.Object;\n\tv446 = \"il2cpp_codegen_initialize_runtime_metadata\"(v445, skeleton, material, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv516 = Spine.RegionAttachment;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v516, skeleton, material, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv54 = 1;\n\t*([1A37CBF]) = v54;\nL_0032:\n\tv59 = skeleton.drawOrder;\n\tSpine.Unity.SkeletonRendererInstruction::Clear(instructionOutput);\n\tv250 = instructionOutput.submeshInstructions;\n\tv229 = Spine.ExposedList`1<Spine.Attachment>::Resize(instructionOutput.attachments, v59.Count);\n\tv254 = instructionOutput.attachments;\n\tv261 = v254.Items;\n\tv125 = v59.Count < 1;\n\tif (v125) goto L_FFFFFFFF;\n\tv224 = v59.Items;\nL_0072:\n\tv255 = v224[v326 @ X8_v32 (System.Int32)];\n\tv91 = v255.bone;\n\tv664 = ~v91.active;\n\tif (v664) goto L_00F2;\n\tv86 = v255.attachment;\n\tv712 = v255.attachment == 0;\n\tif (v712) goto L_0093;\n\t// 131 IsInst v370 @ X0_v33, typeof(Spine.Attachment), v255.attachment (Spine.Attachment)\n\tv372 = v370 == 0;\n\tif (v372) goto L_01BE;\nL_0093:\n\tv261[v326 @ X8_v32 (System.Int32)] = v255.attachment;\n\tv722 = v255.attachment == 0;\n\tif (v722) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tv792 = v792_asT != 0;\n\tif (v792) goto L_00FF;\n\tgoto L_FFFFFFFF;\n\tv179 = v179_asT != 0;\n\tif (v179) goto L_0103;\n\tgoto L_FFFFFFFF;\n\tv766 = v766_asT != 0;\n\tif (v766) goto L_010E;\nL_00EF:\n\tv105 = v675 + v105;\n\tv108 = v703 + v108;\n\tv111 = v703 + v111;\nL_00F2:\n\tv326 = v326 + 1;\n\tv612 = v59.Count != v326;\n\tif (v612) goto L_0072;\n\tgoto L_0120;\nL_00FF:\n\tv701 = *([v86 @ X25_v10 (Spine.Attachment)+78]);\n\tgoto L_00EF;\nL_0103:\n\tv256 = *([v86 @ X25_v10 (Spine.Attachment)+70]);\n\tv701 = *([v86 @ X25_v10 (Spine.Attachment)+98]);\n\tv675 = *([v256 @ X8_v48+18]);\n\tv703 = *([v86 @ X25_v10 (Spine.Attachment)+30]) >> 1;\n\tgoto L_00EF;\nL_010E:\n\tv851 = v680 & 0xFFFFFF00;\n\tv820 = v851 | 1;\n\tgoto L_00EF;\nL_0120:\n\tgoto L_0126;\n\tv654 = \"il2cpp_codegen_runtime_class_init\"(v640, v629, v208, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0126:\n\tv232 = UnityEngine.Object::op_Equality(material, 0);\n\tv659 = v701 == 0;\n\tif (v659) goto L_0174;\n\tv435 = v232 == 0;\n\tif (v435) goto L_0174;\n\tgoto L_FFFFFFFF;\n\tv128 = v128_asT == 0;\n\tif (v128) goto L_01C2;\n\tv257 = *([v701 @ X24_v14 (System.Int32)+10]);\n\tv263 = *([v257 @ X8_v26+30]);\n\tv505 = *([v257 @ X8_v26+30]) == 0;\n\tif (v505) goto L_0174;\n\tgoto L_FFFFFFFF;\n\tv468 = v468_asT == 0;\n\tif (v468) goto L_01C4;\nL_0174:\n\tinstructionOutput.rawVertexCount = v111;\n\tv258 = v681 & 1;\n\tinstructionOutput.hasActiveClipping = v258;\n\tv130 = v111 < 1;\n\tif (v130) goto L_01AD;\n\tv233 = Spine.ExposedList`1<Spine.Unity.SubmeshInstruction>::Resize(instructionOutput.submeshInstructions, 1);\n\tv259 = v250.Items;\n\t*([v259 @ X8_v21 (Spine.Unity.SubmeshInstruction[])+28]) = 0;\n\t*([v259 @ X8_v21 (Spine.Unity.SubmeshInstruction[])+2C]) = v59.Count;\n\t*([v259 @ X8_v21 (Spine.Unity.SubmeshInstruction[])+30]) = v263;\n\t*([v259 @ X8_v21 (Spine.Unity.SubmeshInstruction[])+38]) = 0;\n\t*([v259 @ X8_v21 (Spine.Unity.SubmeshInstruction[])+20]) = skeleton;\n\t*([v259 @ X8_v21 (Spine.Unity.SubmeshInstruction[])+3C]) = 0xFFFFFFFF;\n\t*([v259 @ X8_v21 (Spine.Unity.SubmeshInstruction[])+40]) = v105;\n\t*([v259 @ X8_v21 (Spine.Unity.SubmeshInstruction[])+44]) = v108;\n\t*([v259 @ X8_v21 (Spine.Unity.SubmeshInstruction[])+48]) = 0;\n\t*([v259 @ X8_v21 (Spine.Unity.SubmeshInstruction[])+3B]) = 0;\n\t*([v259 @ X8_v21 (Spine.Unity.SubmeshInstruction[])+39]) = 0;\n\t*([v259 @ X8_v21 (Spine.Unity.SubmeshInstruction[])+4C]) = v680;\n\tgoto L_01BB;\nL_01AD:\n\tv711 = Spine.ExposedList`1<Spine.Unity.SubmeshInstruction>::Resize(instructionOutput.submeshInstructions, 0);\nL_01BB:\n\treturn;\n\tv264 = new System.NullReferenceException();\n\tv329 = new System.IndexOutOfRangeException();\nL_01BE:\n\tv378 = new System.ArrayTypeMismatchException();\n\tthrow v378;\nL_01C2:\n\tthrow System.InvalidCastException;\nL_01C4:\n\tthrow System.InvalidCastException;\n// 342 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void GenerateSingleSubmeshInstruction(SkeletonRendererInstruction instructionOutput, Skeleton skeleton, Material material)
		{
			//IL_03e1: Expected O, but got I4
			//IL_0412: Expected O, but got I
			//IL_0427: Expected O, but got I
			//IL_0462: Expected O, but got I
			//IL_02b8: Expected O, but got I
			//IL_030a: Expected I4, but got I8
			ExposedList<Slot> drawOrder = skeleton.DrawOrder;
			instructionOutput.Clear();
			ExposedList<SubmeshInstruction> submeshInstructions = instructionOutput.submeshInstructions;
			ExposedList<Attachment> exposedList = instructionOutput.attachments.Resize(drawOrder.Count);
			ExposedList<Attachment> attachments = instructionOutput.attachments;
			Attachment[] items = attachments.Items;
			int num3;
			int num5;
			int num6;
			if (drawOrder.Count >= 1)
			{
				Slot[] items2 = drawOrder.Items;
				int num = 0;
				int num2 = 0;
				num3 = 0;
				int num4 = 0;
				num5 = 0;
				num6 = 0;
				int num7 = 0;
				do
				{
					Slot slot = items2[num7];
					Bone bone = slot.Bone;
					if (!bone.Active)
					{
						goto IL_057d;
					}
					Attachment attachment = slot.Attachment;
					if (slot.Attachment != null)
					{
						object obj = slot.Attachment as Attachment;
						if (obj == null)
						{
							ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
							throw ex;
						}
					}
					items[num7] = slot.Attachment;
					if (slot.Attachment == null)
					{
						goto IL_0265;
					}
					RegionAttachment regionAttachment = slot.Attachment as RegionAttachment;
					int num10;
					int num11;
					if (regionAttachment == null)
					{
						MeshAttachment meshAttachment = slot.Attachment as MeshAttachment;
						if (meshAttachment == null)
						{
							ClippingAttachment clippingAttachment = slot.Attachment as ClippingAttachment;
							if (clippingAttachment == null)
							{
								goto IL_0265;
							}
							int num8 = (int)(num4 & 0xFFFFFF00L);
							int num9 = num8 | 1;
							num10 = 0;
							num4 = num9;
							num5 = 1;
							num11 = 0;
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ X25_v10 (Spine.Attachment)+70]");
							object obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ X25_v10 (Spine.Attachment)+98]");
							num6 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ X8_v48+18]");
							num10 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ X25_v10 (Spine.Attachment)+30]");
							num11 = (int)((nint)0 >> 1);
						}
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ X25_v10 (Spine.Attachment)+78]");
						num6 = 0;
						num10 = 6;
						num11 = 4;
					}
					goto IL_05b4;
					IL_057d:
					num7++;
					continue;
					IL_05b4:
					num = num10 + num;
					num2 = num11 + num2;
					num3 = num11 + num3;
					goto IL_057d;
					IL_0265:
					num10 = 0;
					num11 = 0;
					goto IL_05b4;
				}
				while (drawOrder.Count != num7);
			}
			else
			{
				int num = 0;
				int num2 = 0;
				num3 = 0;
				int num4 = 0;
				num5 = 0;
				num6 = 0;
			}
			bool flag = material == null;
			bool flag2 = num6 == 0;
			Material material2 = material;
			if (!flag2)
			{
				bool flag3 = !flag;
				material2 = material;
				if (!flag3)
				{
					AtlasRegion atlasRegion = num6 as AtlasRegion;
					if (atlasRegion == null)
					{
						throw new InvalidCastException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v701 @ X24_v14 (System.Int32)+10]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ X8_v26+30]");
					material2 = (Material)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ X8_v26+30]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ X8_v26+30]");
						Material material3 = 0 as Material;
						if ((object)material3 == null)
						{
							throw new InvalidCastException();
						}
					}
				}
			}
			instructionOutput.rawVertexCount = num3;
			int hasActiveClipping = num5 & 1;
			instructionOutput.hasActiveClipping = (byte)hasActiveClipping != 0;
			if (num3 >= 1)
			{
				ExposedList<SubmeshInstruction> exposedList2 = instructionOutput.submeshInstructions.Resize(1);
				SubmeshInstruction[] items3 = submeshInstructions.Items;
				_ = 0;
				_ = drawOrder.Count;
				_ = 0;
				_ = 4294967295L;
				_ = 0;
				_ = 0;
				_ = 0;
			}
			else
			{
				ExposedList<SubmeshInstruction> exposedList3 = instructionOutput.submeshInstructions.Resize(0);
			}
		}

		[Token(Token = "0x6000678")]
		[Address(RVA = "0x156D4D8", Offset = "0x156D4D8", Length = "0x240")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv30 = Spine.AtlasRegion;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv53 = Spine.IHasRendererObject;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv174 = UnityEngine.Material;\n\tv175 = \"il2cpp_codegen_initialize_runtime_metadata\"(v174, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv211 = UnityEngine.Object;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v211, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A37CC0]) = v50;\nL_0023:\n\tv55 = skeleton.drawOrder;\n\tv100 = v55.Count < 1;\n\tif (v100) goto L_FFFFFFFF;\n\tv97 = v55.Items;\nL_004E:\n\tv166 = v97[v87 @ X23_v8 (System.Int32)];\n\tv76 = v166.bone;\n\tv435 = ~v76.active;\n\tif (v435) goto L_00E8;\n\t// 89 IsInst v438 @ X0_v15 (Spine.IHasRendererObject), typeof(Spine.IHasRendererObject), v166.attachment (Spine.Attachment)\n\tv451 = v438 == 0;\n\tif (v451) goto L_00E8;\n\tgoto L_0087;\n\tv461 = *([v457 @ X8_v14+B0]);\n\tv462 = v461 + 8;\n\tv464 = *([v491 @ X10_v15-8]);\n\tv506 = v464 == v458;\n\tif (v506) goto L_0080;\n\tv468 = v492 - 1;\n\tv466 = v491 + 0x10;\n\tv470 = v492 != 1;\n\tif (v470) goto L_FFFFFFFF;\n\tv487 = v171;\n\tv488 = 0;\n\tv489 = 0xB349B4(v487, v458, v488, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_0087;\nL_0080:\n\tv512 = *([v491 @ X10_v15]);\n\tv513 = v512 << 4;\n\tv514 = v457 + v513;\n\tv515 = v514 + 0x138;\nL_0087:\n\tv156 = Spine.IHasRendererObject::get_RendererObject(v438);\n\tgoto L_FFFFFFFF;\n\tv102 = v102_asT == 0;\n\tif (v102) goto L_010A;\n\tv167 = *([v156 @ X0_v18 (System.Object)+10]);\n\tv260 = *([v167 @ X8_v21+30]) == 0;\n\tif (v260) goto L_00D0;\n\tgoto L_FFFFFFFF;\n\tv232 = v232_asT == 0;\n\tif (v232) goto L_010A;\nL_00D0:\n\tgoto L_00D5;\n\tv532 = \"il2cpp_codegen_runtime_class_init\"(v526, v524, v63, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_00D5:\n\tv450 = UnityEngine.Object::op_Inequality(v336, *([v167 @ X8_v21+30]));\n\tv452 = v450 == 0;\n\tif (v452) goto L_00E8;\n\tgoto L_00E2;\n\tv539 = \"il2cpp_codegen_runtime_class_init\"(v536, v440, v439, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_00E2:\n\tv329 = UnityEngine.Object::op_Inequality(v336, 0);\n\tv543 = v329 == 0;\n\tv332 = ~v543;\n\tif (v332) goto L_0106;\nL_00E8:\n\tv87 = v87 + 1;\n\tv324 = v87 - v55.Count;\n\tv321 = v324 < 0;\n\tv315 = v87 ^ v55.Count;\n\tv312 = v87 ^ v324;\n\tv309 = v315 & v312;\n\tv306 = v309 < 0;\n\tv455 = v321 == v306;\n\tv456 = ~v455;\n\tv303 = v87 != v55.Count;\n\tif (v303) goto L_004E;\n\tgoto L_0106;\nL_0106:\n\treturn v292;\n\tv172 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\nL_010A:\n\treturnVal2 = new System.InvalidCastException();\n\treturn returnVal2;\n// 190 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool RequiresMultipleSubmeshesByDrawOrder(Skeleton skeleton)
		{
			//IL_02f1: Expected I4, but got O
			//IL_0120: Expected O, but got I
			//IL_019b: Expected O, but got I
			//IL_0160: Expected O, but got I
			//IL_01f9: Expected O, but got I
			ExposedList<Slot> drawOrder = skeleton.DrawOrder;
			bool result;
			if (drawOrder.Count >= 1)
			{
				Slot[] items = drawOrder.Items;
				result = true;
				int num = 0;
				UnityEngine.Object obj = null;
				while (true)
				{
					Slot slot = items[num];
					Bone bone = slot.Bone;
					if (bone.Active)
					{
						IHasRendererObject hasRendererObject = slot.Attachment as IHasRendererObject;
						if (hasRendererObject != null)
						{
							object rendererObject = hasRendererObject.RendererObject;
							AtlasRegion atlasRegion = rendererObject as AtlasRegion;
							if (atlasRegion == null)
							{
								goto IL_02e3;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ X0_v18 (System.Object)+10]");
							object obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ X8_v21+30]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ X8_v21+30]");
								Material material = 0 as Material;
								if ((object)material == null)
								{
									goto IL_02e3;
								}
							}
							UnityEngine.Object obj3 = obj;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ X8_v21+30]");
							if (obj3 != (UnityEngine.Object)0)
							{
								bool flag = obj != null;
								bool flag2 = !flag;
								bool flag3 = !flag2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ X8_v21+30]");
								obj = (UnityEngine.Object)0;
								if (flag3)
								{
									break;
								}
							}
						}
					}
					num++;
					int num2 = num - drawOrder.Count;
					bool flag4 = num2 < 0;
					int num3 = num ^ drawOrder.Count;
					int num4 = num ^ num2;
					int num5 = num3 & num4;
					bool flag5 = num5 < 0;
					bool flag6 = flag4 == flag5;
					bool flag7 = !flag6;
					bool flag8 = num != drawOrder.Count;
					result = flag7;
					if (!flag8)
					{
						result = flag7;
						break;
					}
					continue;
					IL_02e3:
					InvalidCastException ex = new InvalidCastException();
					return (byte)(int)ex != 0;
				}
			}
			else
			{
				result = false;
			}
			return result;
		}

		[Token(Token = "0x6000679")]
		[Address(RVA = "0x156D718", Offset = "0x156D718", Length = "0x864")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003F;\n\tv42 = Spine.AtlasRegion;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, skeleton, customSlotMaterials, separatorSlots, generateMeshOverride, immutableTriangles, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv61 = Spine.ClippingAttachment;\n\tv62 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, skeleton, customSlotMaterials, separatorSlots, generateMeshOverride, immutableTriangles, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv501 = Il2CppMethodInfo;\n\tv502 = \"il2cpp_codegen_initialize_runtime_metadata\"(v501, skeleton, customSlotMaterials, separatorSlots, generateMeshOverride, immutableTriangles, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv647 = Il2CppMethodInfo;\n\tv648 = \"il2cpp_codegen_initialize_runtime_metadata\"(v647, skeleton, customSlotMaterials, separatorSlots, generateMeshOverride, immutableTriangles, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv739 = Il2CppMethodInfo;\n\tv740 = \"il2cpp_codegen_initialize_runtime_metadata\"(v739, skeleton, customSlotMaterials, separatorSlots, generateMeshOverride, immutableTriangles, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv822 = Il2CppMethodInfo;\n\tv823 = \"il2cpp_codegen_initialize_runtime_metadata\"(v822, skeleton, customSlotMaterials, separatorSlots, generateMeshOverride, immutableTriangles, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv829 = Il2CppMethodInfo;\n\tv830 = \"il2cpp_codegen_initialize_runtime_metadata\"(v829, skeleton, customSlotMaterials, separatorSlots, generateMeshOverride, immutableTriangles, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv934 = Il2CppMethodInfo;\n\tv935 = \"il2cpp_codegen_initialize_runtime_metadata\"(v934, skeleton, customSlotMaterials, separatorSlots, generateMeshOverride, immutableTriangles, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv939 = UnityEngine.Material;\n\tv940 = \"il2cpp_codegen_initialize_runtime_metadata\"(v939, skeleton, customSlotMaterials, separatorSlots, generateMeshOverride, immutableTriangles, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv1095 = Spine.MeshAttachment;\n\tv1096 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1095, skeleton, customSlotMaterials, separatorSlots, generateMeshOverride, immutableTriangles, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv1121 = Spine.RegionAttachment;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1121, skeleton, customSlotMaterials, separatorSlots, generateMeshOverride, immutableTriangles, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv57 = 1;\n\t*([1A37CC1]) = v57;\nL_003F:\n\tv63 = skeleton.drawOrder;\n\tSpine.Unity.SkeletonRendererInstruction::Clear(instructionOutput);\n\tv411 = instructionOutput.submeshInstructions;\n\tv425 = Spine.ExposedList`1<Spine.Attachment>::Resize(instructionOutput.attachments, v63.Count);\n\tv477 = instructionOutput.attachments;\n\tv936 = v477.Items;\n\tv937 = customSlotMaterials == 0;\n\tif (v937) goto L_FFFFFFFF;\n\tv945 = System.Collections.Generic.Dictionary`2<Spine.Slot, UnityEngine.Material>::get_Count(customSlotMaterials);\n\tv1099 = v945 - 1;\n\tv1100 = v1099 < 0;\n\tv1102 = v945 ^ 1;\n\tv1103 = v945 ^ v1099;\n\tv1104 = v1102 & v1103;\n\tv1105 = v1104 < 0;\n\tv1106 = v1100 == v1105;\n\tv1107 = ~v1106;\n\tgoto L_0070;\nL_0070:\n\tv1119 = separatorSlots == 0;\n\tif (v1119) goto L_FFFFFFFF;\n\tv274 = separatorSlots._size;\n\tgoto L_0080;\nL_0080:\n\tv277 = v63.Count < 1;\n\tif (v277) goto L_FFFFFFFF;\nL_00AC:\n\tv472 = v1205[v223 @ X29_v9 (System.Int32)];\n\tv480 = v472.bone;\n\tv1211 = ~v480.active;\n\tif (v1211) goto L_02E8;\n\tv413 = v472.attachment;\n\tv1327 = v472.attachment == 0;\n\tif (v1327) goto L_00CF;\n\t// 191 IsInst v809 @ X0_v42, typeof(Spine.Attachment), v472.attachment (Spine.Attachment)\n\tv811 = v809 == 0;\n\tif (v811) goto L_0367;\nL_00CF:\n\tv936[v223 @ X29_v9 (System.Int32)] = v472.attachment;\n\tv1337 = v472.attachment == 0;\n\tif (v1337) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tv1414 = v1414_asT != 0;\n\tif (v1414) goto L_0130;\n\tgoto L_FFFFFFFF;\n\tv330 = v330_asT != 0;\n\tif (v330) goto L_0135;\n\tgoto L_FFFFFFFF;\n\tv1389 = v1389_asT != 0;\n\tif (v1389) goto L_029B;\n\tgoto L_0149;\nL_0130:\n\tv467 = *([v413 @ X28_v12 (Spine.Attachment)+78]);\n\tgoto L_FFFFFFFF;\nL_0135:\n\tv482 = *([v413 @ X28_v12 (Spine.Attachment)+70]);\n\tv1481 = *([v482 @ X8_v92+18]);\n\tv467 = *([v413 @ X28_v12 (Spine.Attachment)+98]);\n\tv460 = *([v413 @ X28_v12 (Spine.Attachment)+30]) >> 1;\nL_0149:\n\tv280 = v274 < 1;\n\tif (v280) goto L_016E;\nL_0152:\n\tv1553 = System.Collections.Generic.List`1<Spine.Slot>::get_Item(separatorSlots, v1586);\n\tv1642 = v1205[v223 @ X29_v9 (System.Int32)] == v1553;\n\tif (v1642) goto L_FFFFFFFF;\n\tv1586 = v1586 + 1;\n\tv1567 = v274 != v1586;\n\tif (v1567) goto L_0152;\n\tgoto L_016E;\nL_016E:\n\tv1558 = v419 == 0;\n\tif (v1558) goto L_01D2;\n\tv1562 = v235 & generateMeshOverride;\n\tv332 = v1562 == 0;\n\tif (v332) goto L_02B6;\n\tv468 = v1628 + 1;\n\tv430 = Spine.ExposedList`1<Spine.Unity.SubmeshInstruction>::Resize(instructionOutput.submeshInstructions, v468);\n\tv1737 = v1628 * 0x30;\n\tv1738 = v411.Items + v1737;\n\t*([v1738 @ X8_v76+20]) = skeleton;\n\t*([v1738 @ X8_v76+28]) = v1607;\n\t*([v1738 @ X8_v76+2C]) = v223;\n\t*([v1738 @ X8_v76+30]) = v1264;\n\t*([v1738 @ X8_v76+38]) = v235;\n\t*([v1738 @ X8_v76+3C]) = v1605;\n\t*([v1738 @ X8_v76+40]) = v1270;\n\t*([v1738 @ X8_v76+3B]) = 0;\n\t*([v1738 @ X8_v76+39]) = 0;\n\t*([v1738 @ X8_v76+44]) = v1213;\n\t*([v1738 @ X8_v76+48]) = v1273;\n\t*([v1738 @ X8_v76+4C]) = v1595;\n\tv1749 = ~v220;\n\t*([v1738 @ X8_v76+4F]) = 0;\n\t*([v1738 @ X8_v76+4D]) = 0;\n\tv1750 = v1749 >> 0x1F;\n\tv1752 = v1307 == 0;\n\tv1313 = ~v1752;\n\tif (v1313) goto L_02BC;\n\tgoto L_02E8;\nL_01D2:\n\tv1564 = v1118 == 0;\n\tv1565 = ~v1564;\n\tif (v1565) goto L_01F4;\n\tv1634 = System.Collections.Generic.Dictionary`2<Spine.Slot, UnityEngine.Material>::TryGetValue(customSlotMaterials, v1205[v223 @ X29_v9 (System.Int32)], &v1631 @ stack_-70_v15 (System.Object));\n\tv1697 = v1634 == 0;\n\tv1636 = ~v1697;\n\tif (v1636) goto L_022C;\nL_01F4:\n\tgoto L_FFFFFFFF;\n\tv282 = v282_asT == 0;\n\tif (v282) goto L_0366;\n\tv488 = *([v467 @ X27_v12 (System.Int32)+10]);\n\tv922 = *([v488 @ X8_v64+30]) == 0;\n\tif (v922) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tv883 = v883_asT == 0;\n\tif (v883) goto L_036A;\nL_022C:\n\tv1733 = v235 & 1;\n\tv1734 = v1733 == 0;\n\tv1735 = ~v1734;\n\tif (v1735) goto L_024E;\n\tv1766 = v1213 < 1;\n\tif (v1766) goto L_FFFFFFFF;\n\tv1772 = v1264 == *([v488 @ X8_v64+30]);\n\tif (v1772) goto L_FFFFFFFF;\nL_024E:\n\tv469 = v1628 + 1;\n\tv434 = Spine.ExposedList`1<Spine.Unity.SubmeshInstruction>::Resize(instructionOutput.submeshInstructions, v469);\n\tv1819 = v1628 * 0x30;\n\tv1820 = v411.Items + v1819;\n\t*([v1820 @ X8_v52+20]) = skeleton;\n\t*([v1820 @ X8_v52+28]) = v1607;\n\t*([v1820 @ X8_v52+2C]) = v223;\n\t*([v1820 @ X8_v52+30]) = v1264;\n\t*([v1820 @ X8_v52+38]) = v235;\n\t*([v1820 @ X8_v52+3C]) = v1605;\n\t*([v1820 @ X8_v52+40]) = v1270;\n\t*([v1820 @ X8_v52+3B]) = 0;\n\t*([v1820 @ X8_v52+39]) = 0;\n\t*([v1820 @ X8_v52+44]) = v1213;\n\t*([v1820 @ X8_v52+48]) = v1273;\n\t*([v1820 @ X8_v52+4C]) = v1595;\n\tv1806 = ~v220;\n\t*([v1820 @ X8_v52+4F]) = 0;\n\t*([v1820 @ X8_v52+4D]) = 0;\n\tv1832 = v1806 >> 0x1F;\n\tgoto L_02AA;\nL_029B:\n\tv1307 = *([v413 @ X28_v12 (Spine.Attachment)+40]);\n\tgoto L_0149;\nL_02AA:\n\tv1604 = v1802 + v460;\n\tv1811 = v1808 + v159;\n\tv1629 = v460 + v1275;\nL_02B6:\n\tv1314 = v1307 == 0;\n\tif (v1314) goto L_02E8;\nL_02BC:\n\tv1666 = v472.data - v1307;\n\tv1668 = v1666 == 0;\n\tv1673 = ~v1668;\n\tv1677 = v223 - v220;\n\tv1679 = v1677 == 0;\n\tv1323 = v1679 | v1673;\n\tv1292 = v1323 == 0;\n\tv1685 = ~v1292;\n\tv1686 = ~v1685;\n\tif (v1686) goto L_FFFFFFFF;\n\tgoto L_02E0;\nL_02E0:\n\tv1277 = ~v1292;\n\tv1214 = ~v1277;\n\tif (v1214) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_02E8:\n\tv223 = v223 + 1;\n\tv1186 = v223 != v470;\n\tif (v1186) goto L_00AC;\n\tv284 = v1213 < 1;\n\tif (v284) goto L_FFFFFFFF;\n\tv409 = v1628 + 1;\n\tv436 = Spine.ExposedList`1<Spine.Unity.SubmeshInstruction>::Resize(instructionOutput.submeshInstructions, v409);\n\tv1347 = v1628 * 0x30;\n\tv1348 = v411.Items + v1347;\n\t*([v1348 @ X8_v30+20]) = skeleton;\n\t*([v1348 @ X8_v30+38]) = 0;\n\t*([v1348 @ X8_v30+28]) = v1607;\n\t*([v1348 @ X8_v30+2C]) = v470;\n\t*([v1348 @ X8_v30+30]) = v1264;\n\t*([v1348 @ X8_v30+3C]) = v1605;\n// ... truncated")]
		public unsafe static void GenerateSkeletonRendererInstruction(SkeletonRendererInstruction instructionOutput, Skeleton skeleton, Dictionary<Slot, Material> customSlotMaterials, List<Slot> separatorSlots, bool generateMeshOverride, bool immutableTriangles = false)
		{
			//IL_09c0: Expected O, but got I
			//IL_066f: Expected O, but got I4
			//IL_03af: Expected O, but got I
			//IL_06a0: Expected O, but got I
			//IL_08b5: Expected O, but got I
			//IL_04c4: Expected O, but got I
			//IL_07aa: Expected O, but got I
			//IL_0712: Expected O, but got I
			//IL_0c3b: Expected O, but got I
			//IL_06e1: Expected O, but got I
			ExposedList<Slot> drawOrder = skeleton.DrawOrder;
			instructionOutput.Clear();
			ExposedList<SubmeshInstruction> submeshInstructions = instructionOutput.submeshInstructions;
			ExposedList<Attachment> exposedList = instructionOutput.attachments.Resize(drawOrder.Count);
			ExposedList<Attachment> attachments = instructionOutput.attachments;
			Attachment[] items = attachments.Items;
			bool flag5;
			if (customSlotMaterials != null)
			{
				int count = customSlotMaterials.Count;
				int num = count - 1;
				bool flag = num < 0;
				int num2 = count ^ 1;
				int num3 = count ^ num;
				int num4 = num2 & num3;
				bool flag2 = num4 < 0;
				bool flag3 = flag == flag2;
				bool flag4 = !flag3;
				flag5 = flag4;
			}
			else
			{
				flag5 = true;
			}
			int num5 = separatorSlots?.Count ?? 0;
			SkeletonRendererInstruction skeletonRendererInstruction;
			bool immutableTriangles2;
			int rawVertexCount;
			int num50;
			if (drawOrder.Count >= 1)
			{
				int num6 = -1;
				int num7 = -1;
				int num8 = 0;
				object obj = null;
				int num9 = 0;
				int num10 = 0;
				int num11 = 0;
				int num12 = 0;
				int num13 = 0;
				int num14 = 0;
				int num15 = 0;
				Slot[] items2 = drawOrder.Items;
				int num16 = drawOrder.Count;
				int num17 = 0;
				int num18 = default(int);
				int num29 = default(int);
				do
				{
					Slot slot = items2[num8];
					Bone bone = slot.Bone;
					if (!bone.Active)
					{
						goto IL_0abd;
					}
					Attachment attachment = slot.Attachment;
					if (slot.Attachment != null)
					{
						object obj2 = slot.Attachment as Attachment;
						if (obj2 == null)
						{
							goto IL_0a6a;
						}
					}
					items[num8] = slot.Attachment;
					if (slot.Attachment == null)
					{
						goto IL_0346;
					}
					RegionAttachment regionAttachment = slot.Attachment as RegionAttachment;
					int num19;
					int num20;
					int num21;
					int num22;
					int num23;
					if (regionAttachment == null)
					{
						MeshAttachment meshAttachment = slot.Attachment as MeshAttachment;
						if (meshAttachment == null)
						{
							ClippingAttachment clippingAttachment = slot.Attachment as ClippingAttachment;
							if (clippingAttachment == null)
							{
								goto IL_0346;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ X28_v12 (Spine.Attachment)+40]");
							num15 = 0;
							num18 = 1;
							num19 = 0;
							num7 = num8;
							num13 = 1;
							num20 = 1;
							num21 = 0;
							num22 = 0;
							goto IL_0c58;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ X28_v12 (Spine.Attachment)+70]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v482 @ X8_v92+18]");
						num23 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ X28_v12 (Spine.Attachment)+98]");
						num22 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ X28_v12 (Spine.Attachment)+30]");
						num21 = (int)((nint)0 >> 1);
						num20 = 0;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ X28_v12 (Spine.Attachment)+78]");
						num22 = 0;
						num20 = 0;
						num21 = 4;
						num23 = 6;
					}
					num19 = num23;
					goto IL_0c58;
					IL_0bfc:
					int num25;
					int num24 = num25 + num21;
					int num27;
					int num26 = num27 + num19;
					int num28 = num21 + num14;
					num29 = num24;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v488 @ X8_v64+30]");
					obj = 0;
					num11 = num26;
					num12 = num14;
					num14 = num28;
					goto IL_0b2d;
					IL_0346:
					num19 = 0;
					num20 = 1;
					num21 = 0;
					num22 = 0;
					goto IL_0c58;
					IL_0abd:
					num8++;
					continue;
					IL_0c58:
					if (num5 >= 1)
					{
						int num30 = 0;
						while (true)
						{
							Slot slot2 = separatorSlots[num30];
							if (items2[num8] != slot2)
							{
								num30++;
								if (num5 == num30)
								{
									num9 = 0;
									break;
								}
								continue;
							}
							num9 = 1;
							break;
						}
					}
					int num35;
					int num36;
					int num37;
					object obj5;
					int num38;
					int num39;
					int num40;
					int num41;
					int count2;
					int num42;
					if (num20 != 0)
					{
						if (((uint)num9 & (generateMeshOverride ? 1u : 0u)) != 0)
						{
							int num31 = num17 + 1;
							ExposedList<SubmeshInstruction> exposedList2 = instructionOutput.submeshInstructions.Resize(num31);
							int num32 = num17 * 48;
							object obj4 = (nint)submeshInstructions.Items + num32;
							_ = 0;
							_ = 0;
							int num33 = ~num7;
							_ = 0;
							_ = 0;
							int num34 = num33 >> 31;
							bool flag6 = num15 == 0;
							bool flag7 = !flag6;
							num35 = num29;
							num36 = num34;
							num37 = num7;
							obj5 = obj;
							num38 = num8;
							num39 = 0;
							num40 = num14;
							num41 = num14;
							count2 = drawOrder.Count;
							num42 = num31;
							if (flag7)
							{
								goto IL_08a2;
							}
							num18 = num34;
							num6 = num7;
							num10 = num8;
							num11 = 0;
							num12 = num14;
							items2 = drawOrder.Items;
							num16 = drawOrder.Count;
							num17 = num31;
							goto IL_0abd;
						}
						goto IL_0b2d;
					}
					object value;
					if (flag5 || !customSlotMaterials.TryGetValue(items2[num8], out *(Material*)(&value)))
					{
						AtlasRegion atlasRegion = num22 as AtlasRegion;
						if (atlasRegion == null)
						{
							InvalidCastException ex = new InvalidCastException();
							goto IL_0a6a;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ X27_v12 (System.Int32)+10]");
						object obj6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v488 @ X8_v64+30]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v488 @ X8_v64+30]");
							Material material = 0 as Material;
							if ((object)material == null)
							{
								throw new InvalidCastException();
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v488 @ X8_v64+30]");
						value = 0;
					}
					if ((num9 & 1) != 0)
					{
						goto IL_0760;
					}
					bool flag8 = num29 < 1;
					num25 = num29;
					if (!flag8)
					{
						object obj7 = obj;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v488 @ X8_v64+30]");
						if (obj7 != null)
						{
							goto IL_0760;
						}
						num25 = num29;
					}
					num27 = num11;
					goto IL_0bfc;
					IL_08a2:
					object obj8 = (nint)slot.Data - num15;
					bool flag9 = obj8 == null;
					bool flag10 = !flag9;
					int num43 = num8 - num7;
					bool flag11 = num43 == 0;
					bool flag12 = flag11 || flag10;
					bool flag13 = !flag12;
					if (flag13)
					{
						num15 = 0;
					}
					int num44 = (flag13 ? (-1) : num7);
					num29 = num35;
					num18 = num36;
					num6 = num37;
					num7 = num44;
					obj = obj5;
					num10 = num38;
					num11 = num39;
					num12 = num40;
					num14 = num41;
					items2 = drawOrder.Items;
					num16 = count2;
					num17 = num42;
					goto IL_0abd;
					IL_0a6a:
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
					IL_0760:
					int num45 = num17 + 1;
					ExposedList<SubmeshInstruction> exposedList3 = instructionOutput.submeshInstructions.Resize(num45);
					int num46 = num17 * 48;
					object obj9 = (nint)submeshInstructions.Items + num46;
					_ = 0;
					_ = 0;
					int num47 = ~num7;
					_ = 0;
					_ = 0;
					int num48 = num47 >> 31;
					num18 = num48;
					num25 = 0;
					num6 = num7;
					num10 = num8;
					num17 = num45;
					num27 = 0;
					goto IL_0bfc;
					IL_0b2d:
					bool flag14 = num15 == 0;
					num35 = num29;
					num36 = num18;
					num37 = num6;
					obj5 = obj;
					num38 = num10;
					num39 = num11;
					num40 = num12;
					num41 = num14;
					count2 = drawOrder.Count;
					num42 = num17;
					items2 = drawOrder.Items;
					num16 = drawOrder.Count;
					if (!flag14)
					{
						goto IL_08a2;
					}
					goto IL_0abd;
				}
				while (num8 != num16);
				if (num29 >= 1)
				{
					int newSize = num17 + 1;
					ExposedList<SubmeshInstruction> exposedList4 = instructionOutput.submeshInstructions.Resize(newSize);
					int num49 = num17 * 48;
					object obj10 = (nint)submeshInstructions.Items + num49;
					_ = 0;
					_ = 0;
					_ = 0;
					_ = 0;
					_ = 0;
					skeletonRendererInstruction = instructionOutput;
					immutableTriangles2 = immutableTriangles;
				}
				else
				{
					skeletonRendererInstruction = instructionOutput;
					immutableTriangles2 = immutableTriangles;
				}
				rawVertexCount = num14;
				num50 = num13;
			}
			else
			{
				rawVertexCount = 0;
				num50 = 0;
				skeletonRendererInstruction = instructionOutput;
				immutableTriangles2 = immutableTriangles;
			}
			int hasActiveClipping = num50 & 1;
			skeletonRendererInstruction.rawVertexCount = rawVertexCount;
			skeletonRendererInstruction.hasActiveClipping = (byte)hasActiveClipping != 0;
			skeletonRendererInstruction.immutableTriangles = immutableTriangles2;
		}

		[Token(Token = "0x600067A")]
		[Address(RVA = "0x156DF7C", Offset = "0x156DF7C", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv24 = Il2CppMethodInfo;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, customMaterialOverride, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A37CC2]) = v42;\nL_0023:\n\tv56 = workingSubmeshInstructions.Count < 1;\n\tif (v56) goto L_0065;\n\tv70 = workingSubmeshInstructions.Items + 0x30;\nL_003D:\n\tv155 = System.Collections.Generic.Dictionary`2<UnityEngine.Material, UnityEngine.Material>::TryGetValue(customMaterialOverride, *([v70 @ X24_v5]), &v124 @ stack_-38_v6 (System.Object));\n\tv157 = v155 == 0;\n\tif (v157) goto L_004F;\n\t*([v70 @ X24_v5]) = v124;\nL_004F:\n\tv72 = v72 + 1;\n\tv70 = v70 + 0x30;\n\tv137 = v72 < workingSubmeshInstructions.Count;\n\tif (v137) goto L_003D;\nL_0065:\n\treturn;\n\tv111 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static void TryReplaceMaterials(ExposedList<SubmeshInstruction> workingSubmeshInstructions, Dictionary<Material, Material> customMaterialOverride)
		{
			//IL_003b: Expected O, but got I
			//IL_00a6: Expected O, but got I
			if (workingSubmeshInstructions.Count < 1)
			{
				return;
			}
			object obj = (nint)workingSubmeshInstructions.Items + 48;
			int num = 0;
			do
			{
				object value;
				if (customMaterialOverride.TryGetValue((Material)obj, out *(Material*)(&value)))
				{
					obj = value;
				}
				num++;
				obj = (nint)obj + 48;
			}
			while (num < workingSubmeshInstructions.Count);
		}

		[Token(Token = "0x600067B")]
		[Address(RVA = "0x1564FC0", Offset = "0x1564FC0", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv38 = Il2CppMethodInfo;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv68 = Il2CppMethodInfo;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v68, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A37CC3]) = v34;\nL_001D:\n\tSpine.ExposedList`1<UnityEngine.Vector3>::Clear(this.vertexBuffer, 0);\n\tSpine.ExposedList`1<UnityEngine.Color32>::Clear(this.colorBuffer, 0);\n\tSpine.ExposedList`1<UnityEngine.Vector2>::Clear(this.uvBuffer, 0);\n\tSpine.SkeletonClipping::ClipEnd(this.clipper);\n\tv65 = this.submeshes;\n\tthis.meshBoundsThickness = 0f;\n\tthis.meshBoundsMin = *([407F90]);\n\tv65.Count = 1;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Begin()
		{
			//IL_0076: Expected O, but got I
			vertexBuffer.Clear(clearArray: false);
			colorBuffer.Clear(clearArray: false);
			uvBuffer.Clear(clearArray: false);
			clipper.ClipEnd();
			ExposedList<ExposedList<int>> exposedList = submeshes;
			meshBoundsThickness = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [407F90]");
			meshBoundsMin = (Vector2)0;
			exposedList.Count = 1;
		}

		[Token(Token = "0x600067C")]
		[Address(RVA = "0x1565098", Offset = "0x1565098", Length = "0xC00")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0044;\n\tv52 = Il2CppMethodInfo;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, instruction, updateTriangles, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv74 = Il2CppMethodInfo;\n\tv75 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, instruction, updateTriangles, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv1021 = Il2CppMethodInfo;\n\tv1022 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1021, instruction, updateTriangles, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv1113 = Il2CppMethodInfo;\n\tv1114 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1113, instruction, updateTriangles, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv1121 = Spine.ClippingAttachment;\n\tv1122 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1121, instruction, updateTriangles, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv1126 = Il2CppMethodInfo;\n\tv1127 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1126, instruction, updateTriangles, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv1346 = Il2CppMethodInfo;\n\tv1347 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1346, instruction, updateTriangles, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv1359 = Il2CppMethodInfo;\n\tv1360 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1359, instruction, updateTriangles, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv1365 = Spine.ExposedList`1<System.Int32>;\n\tv1366 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1365, instruction, updateTriangles, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv1369 = Spine.MeshAttachment;\n\tv1370 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1369, instruction, updateTriangles, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv1377 = Spine.RegionAttachment;\n\tv1378 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1377, instruction, updateTriangles, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv1387 = System.Single[];\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1387, instruction, updateTriangles, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv70 = 1;\n\t*([1A37CC4]) = v70;\nL_0044:\n\tv896 = this.submeshes;\n\tv76 = v896.Items;\n\tv836 = this.submeshIndex + 1;\n\tv579 = v836 <= v76.Length;\n\tif (v579) goto L_0067;\n\tv1116 = Spine.ExposedList`1<Spine.ExposedList`1<System.Int32>>::Resize(v896, v836);\n\tv896 = this.submeshes;\nL_0067:\n\tv896.Count = v836;\n\tv497 = this.submeshIndex << 3;\n\tv1128 = v896.Items + v497;\n\tv844 = v1128 + 0x20;\n\tv491 = *([v844 @ X23_v6]);\n\tv1130 = *([v844 @ X23_v6]) == 0;\n\tv1131 = ~v1130;\n\tif (v1131) goto L_00A2;\n\tv1351 = new Spine.ExposedList`1<System.Int32>();\n\tSpine.ExposedList`1<System.Int32>::.ctor(v1351);\n\tv1367 = v1351 == 0;\n\tif (v1367) goto L_009A;\n\t// 140 IsInst v1103 @ X0_v61, typeof(Spine.ExposedList`1<System.Int32>), v1351 @ X0_v58 (Spine.ExposedList`1<System.Int32>)\n\tv1105 = v1103 == 0;\n\tif (v1105) goto L_05D7;\nL_009A:\n\t*([v844 @ X23_v6]) = v1351;\nL_00A2:\n\tSpine.ExposedList`1<System.Int32>::Clear(v491, 0);\n\tv985 = instruction.skeleton;\n\tv873 = v985.drawOrder;\n\tv1945 = v873.Items;\n\tv472 = this.meshBoundsMin;\n\tv463 = this.meshBoundsMin.y;\n\tv454 = this.meshBoundsMax;\n\tv445 = this.meshBoundsMax.y;\n\tv1374 = this.settings & 1;\n\tv1375 = v1374 == 0;\n\tif (v1375) goto L_FFFFFFFF;\n\tv1381 = instruction.hasClipping == 0;\n\tv1382 = ~v1381;\n\tif (v1382) goto L_00BD;\n\tgoto L_0102;\nL_00BD:\n\tv986 = instruction.preActiveClippingSlotSource;\n\tv1388 = instruction.preActiveClippingSlotSource & 0x80000000;\n\tv1389 = v1388 == 0;\n\tv1390 = ~v1389;\n\tif (v1390) goto L_FFFFFFFF;\n\tv555 = v1945[v986 @ X8_v74 (System.Int32)];\n\tv1440 = v555.attachment == 0;\n\tif (v1440) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0100;\n\tv1604 = v1604_asT == 0;\n\tif (v1604) goto L_FFFFFFFF;\n\tgoto L_0100;\nL_0100:\n\tv1439 = Spine.SkeletonClipping::ClipStart(this.clipper, v1945[v986 @ X8_v74 (System.Int32)], v1429);\nL_0102:\n\tv839 = instruction.startSlot;\n\tv580 = instruction.startSlot >= instruction.endSlot;\n\tif (v580) goto L_0583;\n\tv1502 = v491 + 0x10;\n\t// 278 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv1510 = this.settings.pmaVertexColors & 0x10100;\nL_0131:\n\tv310 = v517[v839 @ X22_v9 (System.Int32)];\n\tv558 = v310.bone;\n\tv1581 = ~v558.active;\n\tif (v1581) goto L_0570;\n\tv302 = v310.attachment;\n\tv1607 = v310.attachment == 0;\n\tif (v1607) goto L_0570;\n\tv991 = *([v302 @ X28_v9 (Spine.RegionAttachment)]);\n\tv1697 = *([v1466 @ X27_v10 (Il2CppClass<Spine.RegionAttachment>)]);\n\tv1939 = v968.tempVerts;\n\tv1699 = *([v991 @ X8_v32 (Il2CppClass<Spine.RegionAttachment>)+130]) < *([v1697 @ X10_v16+130]);\n\tv1700 = ~v1699;\n\tv1708 = ~v1700;\n\tif (v1708) goto L_0169;\n\tv1712 = *([v1697 @ X10_v16+130]) << 3;\n\tv1713 = *([v991 @ X8_v32 (Il2CppClass<Spine.RegionAttachment>)+C8]) + v1712;\n\tv1719 = *([v1713 @ X11_v36-8]) == v1697;\n\tif (v1719) goto L_01A7;\nL_0169:\n\tgoto L_FFFFFFFF;\n\tv728 = v728_asT != 0;\n\tif (v728) goto L_01C0;\n\tv1770 = v1963 & 1;\n\tv1771 = v1770 == 0;\n\tv1688 = ~v1771;\n\tif (v1688) goto L_0570;\n\tgoto L_FFFFFFFF;\n\tv582 = v582_asT == 0;\n\tif (v582) goto L_0570;\n\tv1759 = Spine.SkeletonClipping::ClipStart(v968.clipper, v517[v839 @ X22_v9 (System.Int32)], v310.attachment);\n\tgoto L_0572;\nL_01A7:\n\tSpine.RegionAttachment::ComputeWorldVertices(v310.attachment, v558, v1939, 0, 2);\n\tv273 = v968.regionTriangles;\n\tv1785 = v310.attachment + 0x58;\n\tv1800 = v310.attachment + 0x60;\n\tv392 = v310.attachment + 0x64;\n\tv424 = v310.attachment + 0x6C;\n\tgoto L_01E0;\nL_01C0:\n\tv584 = v302.height <= v1939.Length;\n\tif (v584) goto L_01D1;\n\t// 454 NewArr v1823 @ X0_v52 (System.Single[]), typeof(System.Single[]), v302.height (System.Single)\n\tv968.tempVerts = v1823;\nL_01D1:\n\tSpine.VertexAttachment::ComputeWorldVertices(v310.attachment, v517[v839 @ X22_v9 (System.Int32)], 0, v302.height, v1939, 0, 2);\n\tv268 = v302.<Path>k__BackingField;\n\tv262 = *([v268 @ X4_v22 (System.String)+18]);\n\tv566 = v302.height >> 1;\n\tv424 = v310.attachment + 0x84;\n\tv392 = v310.attachment + 0x7C;\n\tv1800 = v310.attachment + 0x78;\n\tv1785 = v310.attachment + 0x60;\nL_01E0:\n\tv1803 = v985.a * v310.a;\n\tv1806 = *([v424 @ X10_v17]) * v1803;\n\tv1807 = v1806 * 0x437F0000;\n\tv1940 = *([v1785 @ X12_v11]);\n\tv1447 = v985.r * v310.r;\n\tv376 = v1807 >= 0;\n\tif (v376) goto L_FFFFFFFF;\n\tgoto L_01FA;\nL_01FA:\n\tv229 = *([v1800 @ X8_v33]) * v1447;\n\tv1829 = v850 == 0;\n\tv1830 = ~v1829;\n\tif (v1830) goto L_0221;\n\tv230 = v229 * 0x437F0000;\n\tv1846 = v985.g * v310.g;\n\tv1847 = *([v392 @ X11_v15]) * v1846;\n\tv1849 = v230 >= 0;\n\tif (v1849) goto L_FFFFFFFF;\n\tgoto L_0218;\nL_0218:\n\tv861 = v1847 * v985.r;\n\t// 537 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 538 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 539 NotImplemented \"Instruction BIT not yet implemented.\"\n\tv1888 = v1963 & 1;\n\tv1889 = v1888 == 0;\n\tif (v1889) goto L_028A;\n\tgoto L_02BA;\nL_0221:\n\tv993 = v310.data;\n\tv1853 = v1899 & 0xFF;\n\tv1862 = v1510 - 0x10100;\n\tv1864 = v1862 == 0;\n\tv1869 = v229 * v1853;\n\tv1881 = v985.g * v310.g;\n\tv1882 = v1869 >= 0;\n\tif (v1882) goto L_FFFFFFFF;\n\tgoto L_024A;\nL_024A:\n\tv1916 = v993.blendMode - 1;\n\tv1918 = v1916 == 0;\n\tv1923 = *([v392 @ X11_v15]) * v1881;\n\tv1924 = ~v1918;\n\tv861 = v1923 * v1835;\n\tv1913 = v1864 | v1924;\n\tv1927 = ~v1918;\n\tv1928 = ~v1927;\n\tif (v1928) goto L_FFFFFFFF;\n\tgoto L_025F;\nL_025F:\n\t// 607 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 608 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv1905 = v1913 == 0;\n\t// 618 NotImplemented \"Instruction BIT not yet implemented.\"\n\tv1975 = ~v1905;\n\tv1976 = ~v1975;\n\tif (v1976) goto L_FFFFFFFF;\n\tgoto L_0274;\nL_0274:\n\tv1900 = ~v1905;\n\tv1898 = ~v1900;\n\tif (v1898) goto L_FFFFFFFF;\n\tgoto L_027B;\nL_027B:\n\tv2047 = v1963 & 1;\n\tv2048 = v2047 == 0;\n\tv1911 = ~v2048;\n\tif (v1911) goto L_02BA;\nL_028A:\n\tv1965 = Spine.SkeletonClipping::get_IsClipping(v968.clipper);\n\tv1973 = v1965 == 0;\n\tif (v1973) goto L_FFFFFFFF;\n\tv1946 = v566 << 1;\n\tSpine.SkeletonClippi\n// ... truncated")]
		public unsafe void AddSubmesh(SubmeshInstruction instruction, bool updateTriangles = true)
		{
			//IL_009d: Expected O, but got I
			//IL_00ac: Expected O, but got I
			//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c8: Expected I4, but got Unknown
			//IL_0245: Expected I4, but got I8
			//IL_034a: Expected I, but got O
			//IL_1473: Expected O, but got I
			//IL_1482: Expected O, but got I
			//IL_14a4: Expected O, but got I4
			//IL_14b3: Expected O, but got I
			//IL_043e: Expected I, but got O
			//IL_0446: Expected O, but got I
			//IL_04c3: Expected O, but got I
			//IL_0619: Expected O, but got I
			//IL_062d: Expected O, but got I
			//IL_0641: Expected O, but got I
			//IL_0655: Expected O, but got I
			//IL_0667: Expected I4, but got O
			//IL_164b: Expected I4, but got F4
			//IL_06ec: Expected I4, but got F4
			//IL_0700: Expected O, but got I
			//IL_0714: Expected O, but got I
			//IL_0728: Expected O, but got I
			//IL_073c: Expected O, but got I
			//IL_083e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0843: Expected I4, but got Unknown
			//IL_1a89: Expected I, but got O
			//IL_196b: Unknown result type (might be due to invalid IL or missing references)
			//IL_1970: Expected I4, but got Unknown
			//IL_197d: Expected O, but got F4
			//IL_19d9: Expected I4, but got F4
			//IL_0fc0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0fc5: Expected I4, but got Unknown
			//IL_0ff9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ffe: Expected I4, but got Unknown
			//IL_1056: Expected O, but got I
			//IL_106a: Expected O, but got I
			//IL_107e: Expected O, but got I
			//IL_108d: Expected O, but got I
			//IL_1096: Unknown result type (might be due to invalid IL or missing references)
			//IL_109b: Expected I4, but got Unknown
			//IL_10d3: Expected O, but got I
			//IL_0bd4: Expected I4, but got F4
			//IL_10f1: Expected F4, but got I
			//IL_10f9: Expected F4, but got O
			//IL_1101: Expected O, but got F4
			//IL_0cde: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ce3: Expected I4, but got Unknown
			//IL_0d08: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d0d: Expected I4, but got Unknown
			//IL_0d6f: Expected O, but got I
			//IL_0d7e: Expected O, but got I
			//IL_0d95: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d9a: Expected I4, but got Unknown
			//IL_0bfa: Expected I4, but got F4
			//IL_0df7: Expected F4, but got I
			//IL_0dff: Expected F4, but got O
			//IL_0e2e: Expected O, but got I
			//IL_0e6b: Expected O, but got I
			//IL_0e94: Expected F4, but got O
			//IL_0eba: Expected O, but got I
			//IL_1ca9: Expected I, but got O
			//IL_1acc: Unknown result type (might be due to invalid IL or missing references)
			//IL_1ad1: Expected I4, but got Unknown
			//IL_1ade: Expected I4, but got F4
			//IL_127b: Expected O, but got I
			//IL_12a7: Expected O, but got I
			//IL_12be: Expected I4, but got I8
			//IL_117c: Expected O, but got I
			//IL_0efd: Expected O, but got I
			//IL_1bab: Expected I4, but got F4
			//IL_1bb8: Expected I4, but got F4
			//IL_1be3: Expected O, but got I
			//IL_1bf2: Expected O, but got I
			//IL_1c01: Expected O, but got I
			//IL_1189: Expected O, but got F4
			//IL_0f40: Expected O, but got I
			//IL_1c4f: Expected O, but got I
			//IL_1a1c: Expected O, but got I
			//IL_1a2b: Expected O, but got I
			//IL_1a3d: Expected I4, but got I8
			ExposedList<ExposedList<int>> exposedList = submeshes;
			ExposedList<int>[] items = exposedList.Items;
			int num = submeshIndex + 1;
			if (num > items.Length)
			{
				ExposedList<ExposedList<int>> exposedList2 = exposedList.Resize(num);
				exposedList = submeshes;
			}
			exposedList.Count = num;
			int num2 = submeshIndex << 3;
			object obj = (nint)exposedList.Items + num2;
			object obj2 = (nint)obj + 32;
			ExposedList<int> exposedList3 = (ExposedList<int>)obj2;
			if (obj2 == null)
			{
				ExposedList<int> exposedList4 = new ExposedList<int>();
				if (exposedList4 != null)
				{
					object obj3 = exposedList4 as ExposedList<int>;
					if (obj3 == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						throw ex;
					}
				}
				obj2 = exposedList4;
				exposedList3 = exposedList4;
			}
			exposedList3.Clear(clearArray: false);
			Skeleton skeleton = instruction.skeleton;
			ExposedList<Slot> drawOrder = skeleton.DrawOrder;
			Slot[] items2 = drawOrder.Items;
			Vector2 vector = meshBoundsMin;
			float num3 = meshBoundsMin.y;
			Vector2 vector2 = meshBoundsMax;
			float num4 = meshBoundsMax.y;
			int num5;
			if ((settings & 1) == 0 || !instruction.hasClipping)
			{
				num5 = 1;
			}
			else
			{
				int preActiveClippingSlotSource = instruction.preActiveClippingSlotSource;
				if ((int)(instruction.preActiveClippingSlotSource & 0x80000000L) == 0)
				{
					Slot slot = items2[preActiveClippingSlotSource];
					ClippingAttachment clip;
					if (slot.Attachment == null)
					{
						clip = null;
					}
					else
					{
						ClippingAttachment clippingAttachment = slot.Attachment as ClippingAttachment;
						clip = (ClippingAttachment)((clippingAttachment == null) ? null : slot.Attachment);
					}
					int num6 = clipper.ClipStart(items2[preActiveClippingSlotSource], clip);
				}
				num5 = 0;
			}
			int num7 = instruction.startSlot;
			bool flag = instruction.startSlot >= instruction.endSlot;
			ExposedList<int> exposedList5 = exposedList3;
			MeshGenerator meshGenerator = this;
			SubmeshInstruction submeshInstruction = instruction;
			if (!flag)
			{
				ref int[] reference = ref *(int[]*)((nint)exposedList3 + 16);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
				int num8 = (settings.pmaVertexColors ? 1 : 0) & 0x10100;
				nint num9 = (nint)typeof(RegionAttachment);
				float num10 = num4;
				Vector2 vector3 = vector2;
				float num11 = num3;
				Vector2 vector4 = vector;
				ExposedList<int> exposedList6 = exposedList3;
				Slot[] array = drawOrder.Items;
				bool pmaVertexColors = settings.pmaVertexColors;
				float num12 = 1.3f;
				MeshGenerator meshGenerator2 = this;
				SubmeshInstruction submeshInstruction2 = instruction;
				int num13 = num5;
				object obj10 = default(object);
				object obj14 = default(object);
				bool flag28;
				do
				{
					Slot slot2 = array[num7];
					Bone bone = slot2.Bone;
					bool flag2 = !bone.Active;
					Slot[] array2 = array;
					float[] array3;
					int[] array4;
					object obj6;
					object obj7;
					object obj8;
					object obj9;
					int num17;
					int num19;
					if (!flag2)
					{
						RegionAttachment attachment = (RegionAttachment)slot2.Attachment;
						bool flag3 = slot2.Attachment == null;
						array2 = array;
						if (!flag3)
						{
							nint num14 = (nint)attachment;
							object obj4 = num9;
							array3 = meshGenerator2.tempVerts;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v991 @ X8_v32 (Il2CppClass<Spine.RegionAttachment>)+130]");
							nint num15 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1697 @ X10_v16+130]");
							if (num15 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1697 @ X10_v16+130]");
								int num16 = (int)((nint)0 << 3);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v991 @ X8_v32 (Il2CppClass<Spine.RegionAttachment>)+C8]");
								object obj5 = (nint)0 + (nint)num16;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1713 @ X11_v36-8]");
								if (0 == (nint)obj4)
								{
									((RegionAttachment)slot2.Attachment).ComputeWorldVertices(bone, array3, 0, 2);
									array4 = meshGenerator2.regionTriangles;
									obj6 = (nint)slot2.Attachment + 88;
									obj7 = (nint)slot2.Attachment + 96;
									obj8 = (nint)slot2.Attachment + 100;
									obj9 = (nint)slot2.Attachment + 108;
									num17 = 6;
									int num18 = (int)array3;
									num19 = 4;
									goto IL_1599;
								}
							}
							MeshAttachment meshAttachment = slot2.Attachment as MeshAttachment;
							if (meshAttachment != null)
							{
								if (attachment.Height > (float)array3.Length)
								{
									array3 = (meshGenerator2.tempVerts = new float[attachment.Height]);
								}
								((VertexAttachment)slot2.Attachment).ComputeWorldVertices(array[num7], 0, (int)attachment.Height, array3, 0, 2);
								string path = attachment.Path;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ X4_v22 (System.String)+18]");
								num17 = 0;
								num19 = attachment.Height >> 1;
								obj9 = (nint)slot2.Attachment + 132;
								obj8 = (nint)slot2.Attachment + 124;
								obj7 = (nint)slot2.Attachment + 120;
								obj6 = (nint)slot2.Attachment + 96;
								array4 = (int[])(object)path;
								int num18 = 0;
								goto IL_1599;
							}
							int num20 = num13 & 1;
							bool flag4 = num20 == 0;
							bool flag5 = !flag4;
							array2 = array;
							if (!flag5)
							{
								array2 = array;
								ClippingAttachment clippingAttachment2 = slot2.Attachment as ClippingAttachment;
								bool flag6 = clippingAttachment2 == null;
								array2 = array;
								if (!flag6)
								{
									int num21 = meshGenerator2.clipper.ClipStart(array[num7], (ClippingAttachment)slot2.Attachment);
									array2 = array;
									goto IL_1336;
								}
							}
						}
					}
					goto IL_1315;
					IL_1a79:
					num9 = (nint)typeof(RegionAttachment);
					goto IL_1315;
					IL_090f:
					float[] array5;
					int[] array6;
					if (meshGenerator2.clipper.IsClipping)
					{
						int num18 = num19 << 1;
						clipper.ClipTriangles(array3, num18, array4, num17, array5);
						SkeletonClipping skeletonClipping = clipper;
						ExposedList<float> clippedVertices = skeletonClipping.ClippedVertices;
						ExposedList<int> clippedTriangles = skeletonClipping.ClippedTriangles;
						ExposedList<float> clippedUVs = skeletonClipping.ClippedUVs;
						array3 = clippedVertices.Items;
						num17 = clippedTriangles.Count;
						array6 = clippedTriangles.Items;
						array5 = clippedUVs.Items;
						num19 = clippedVertices.Count >> 1;
					}
					else
					{
						array6 = array4;
					}
					float num23;
					float num22 = num23;
					float num25;
					float num24 = num25;
					float num26;
					float a = num26;
					float num28;
					float num27 = num28;
					array4 = array6;
					float num30;
					float num29 = num30;
					array2 = drawOrder.Items;
					float num31;
					num12 = num31;
					meshGenerator2 = this;
					goto IL_170b;
					IL_1599:
					float num32 = skeleton.A * slot2.A;
					float num33 = (float)obj9 * num32;
					float num34 = num33 * 255f;
					array5 = (float[])obj6;
					float num35 = skeleton.R * slot2.R;
					float num36 = ((!(num34 < 0f)) ? num34 : num34);
					float num37 = (float)obj7 * num35;
					if (!pmaVertexColors)
					{
						num28 = num37 * 255f;
						float num38 = skeleton.G * slot2.G;
						float num39 = (float)obj8 * num38;
						num30 = ((!(num28 < 0f)) ? num28 : num28);
						num31 = num39 * skeleton.R;
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction BIT not yet implemented.\"");
						int num40 = num13 & 1;
						bool flag7 = num40 == 0;
						num23 = num31;
						num25 = num36;
						num26 = 1f;
						if (flag7)
						{
							goto IL_090f;
						}
						num22 = num31;
						num24 = num36;
						a = 1f;
						num27 = num28;
						num29 = num30;
						array2 = array;
						num12 = num31;
					}
					else
					{
						SlotData data = slot2.Data;
						int num41 = num36 & 0xFF;
						int num42 = num8 - 65792;
						bool flag8 = num42 == 0;
						float num43 = num37 * (float)num41;
						float num44 = skeleton.G * slot2.G;
						num30 = ((!(num43 < 0f)) ? num43 : num43);
						int num45 = (int)(data.BlendMode - 1);
						bool flag9 = num45 == 0;
						float num46 = (float)obj8 * num44;
						bool flag10 = !flag9;
						num31 = num46 * (float)obj10;
						bool flag11 = flag8 || flag10;
						num28 = (flag9 ? 0f : 1f);
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
						bool flag12 = !flag11;
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction BIT not yet implemented.\"");
						if (flag12)
						{
							num36 = 0f;
						}
						num26 = (flag12 ? 1f : num28);
						int num47 = num13 & 1;
						bool flag13 = num47 == 0;
						bool flag14 = !flag13;
						num23 = num31;
						num25 = num36;
						num22 = num31;
						num24 = num36;
						a = num26;
						num27 = num28;
						num29 = num30;
						array2 = array;
						num12 = num31;
						if (!flag14)
						{
							goto IL_090f;
						}
					}
					goto IL_170b;
					IL_1a5c:
					if (updateTriangles)
					{
						int[] array7 = exposedList3.Items;
						int num48 = exposedList3.Count + num17;
						if (num48 > array7.Length)
						{
							Array.Resize(ref reference, num48);
							array7 = reference;
							array2 = drawOrder.Items;
						}
						exposedList3.Count = num48;
						if (num17 >= 1)
						{
							int num49 = exposedList3.Count << 32;
							int num50 = 0;
							bool flag15;
							do
							{
								int num51 = num49 >> 30;
								object obj11 = (nint)array7 + num51;
								int num52 = num50 + 1;
								int num53 = array4[num50];
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v907 @ X0_v25 (UnityEngine.Vector3[]&)+8]");
								object obj12 = (nint)num53 + (nint)0;
								num49 = (int)(num49 + 4294967296L);
								flag15 = num17 != num52;
								num50 = num52;
							}
							while (flag15);
							submeshInstruction2 = instruction;
						}
						else
						{
							submeshInstruction2 = instruction;
						}
						num9 = (nint)typeof(RegionAttachment);
						exposedList6 = exposedList3;
						pmaVertexColors = settings.pmaVertexColors;
						num13 = num5;
						goto IL_1315;
					}
					exposedList6 = exposedList3;
					submeshInstruction2 = instruction;
					goto IL_1a79;
					IL_170b:
					float num82;
					if (num17 != 0 && num19 != 0)
					{
						if (((pmaVertexColors ? 1u : 0u) & 0x100u) != 0)
						{
							float num54 = slot2.R2;
							float num55 = slot2.G2;
							num27 = slot2.B2;
							if (pmaVertexColors)
							{
								float num56 = skeleton.A * slot2.A;
								float num57 = (float)obj9 * num56;
								num54 *= num57;
								num55 *= num57;
								num27 *= num57;
							}
							AddAttachmentTintBlack(num54, num55, num27, a, num19);
							array2 = drawOrder.Items;
							meshGenerator2 = this;
						}
						ExposedList<Vector3> exposedList7 = meshGenerator2.vertexBuffer;
						ref Vector3[] reference2 = ref *(Vector3[]*)((nint)meshGenerator2.vertexBuffer + 16);
						Vector3[] array8 = reference2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v907 @ X0_v25 (UnityEngine.Vector3[]&)+8]");
						int num58 = (int)((nint)0 + (nint)num19);
						if (num58 > array8.Length)
						{
							float num59 = (float)array8.Length * 1.3f;
							float num60 = ((num59 != float.PositiveInfinity) ? num59 : -0f);
							float num61 = num60 - (float)num58;
							bool flag16 = num61 < 0f;
							int num62 = num60 ^ num58;
							object obj13 = num60 ^ num61;
							int num63 = (int)(num62 & (nint)obj13);
							bool flag17 = num63 < 0;
							float num64 = ((flag16 == flag17) ? num60 : ((float)num58));
							Array.Resize(ref reference2, (int)num64);
							Array.Resize(ref *(Vector2[]*)((nint)meshGenerator2.uvBuffer + 16), (int)num64);
							Array.Resize(ref *(Color32[]*)((nint)meshGenerator2.colorBuffer + 16), (int)num64);
							exposedList7 = meshGenerator2.vertexBuffer;
							num27 = 1.3f;
							array2 = drawOrder.Items;
							pmaVertexColors = settings.pmaVertexColors;
						}
						ExposedList<Color32> exposedList8 = meshGenerator2.colorBuffer;
						ExposedList<Vector2> exposedList9 = meshGenerator2.uvBuffer;
						exposedList8.Count = num58;
						exposedList9.Count = num58;
						exposedList7.Count = num58;
						Vector2[] items3 = exposedList9.Items;
						num12 = settings.zSpacing * (float)num7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v907 @ X0_v25 (UnityEngine.Vector3[]&)+8]");
						if ((nint)0 != 0)
						{
							if (num19 < 1)
							{
								goto IL_11b5;
							}
							int num65 = num22 & 0xFF;
							int num66 = num65 & 0xFF;
							int num67 = num66 << 8;
							int num68 = num29 & -65281;
							int num69 = num68 | num67;
							int num70 = (int)((nint)obj14 & 0xFF);
							int num71 = num70 & 0xFF;
							int num72 = num71 << 16;
							int num73 = num69 & -16711681;
							int num74 = num73 | num72;
							object obj15 = (nint)array5 + 36;
							object obj16 = (nint)array3 + 36;
							int num75 = num19 << 1;
							int num76 = num24 & 0xFF;
							int num77 = num76 << 24;
							int num78 = num74 & 0xFFFFFF;
							int num79 = num78 | num77;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v907 @ X0_v25 (UnityEngine.Vector3[]&)+8]");
							int num80 = (int)((nint)0 << 32);
							int num81 = 0;
							do
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ X13_v17-4]");
								num27 = 0f;
								num82 = (float)obj16;
								int num83 = num80 >> 32;
								int num84 = num83 * 12;
								object obj17 = (nint)exposedList7.Items + num84;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ X13_v17-4]");
								_ = 0;
								int num85 = num83 << 3;
								object obj18 = (nint)exposedList9.Items + num85;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v411 @ X12_v23-4]");
								_ = 0;
								items3[num83].y = (float)obj15;
								int num86 = num83 << 2;
								object obj19 = (nint)exposedList8.Items + num86;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ X13_v17-4]");
								if (0f < vector4.x)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ X13_v17-4]");
									vector4 = (Vector2)0;
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ X13_v17-4]");
									if (0f > vector3.x)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ X13_v17-4]");
										vector3 = (Vector2)0;
									}
								}
								if (num82 < num11)
								{
									num11 = num82;
								}
								else if (num82 > num10)
								{
									num10 = num82;
								}
								num81 += 2;
								obj15 = (nint)obj15 + 8;
								obj16 = (nint)obj16 + 8;
								num80 = (int)(num80 + 4294967296L);
							}
							while (num75 != num81);
							num13 = num5;
						}
						else
						{
							if (num19 < 1)
							{
								goto IL_11b5;
							}
							int num87 = num22 & 0xFF;
							int num88 = (int)((nint)obj14 & 0xFF);
							int num89 = num87 & 0xFF;
							int num90 = num89 << 8;
							int num91 = num29 & -65281;
							int num92 = num91 | num90;
							int num93 = num88 & 0xFF;
							int num94 = num93 << 16;
							int num95 = num92 & -16711681;
							int num96 = num95 | num94;
							object obj20 = (nint)exposedList8.Items + 32;
							object obj21 = (nint)exposedList7.Items + 40;
							object obj22 = (nint)exposedList9.Items + 36;
							object obj23 = (nint)array3 + 36;
							int num97 = num24 & 0xFF;
							int num98 = num97 << 24;
							int num99 = num96 & 0xFFFFFF;
							int num100 = num99 | num98;
							object obj24 = (nint)array5 + 36;
							int num101 = 0;
							do
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X17_v11-4]");
								num27 = 0f;
								num82 = (float)obj23;
								obj21 = num12;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X17_v11-4]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v912 @ X0_v34-4]");
								_ = 0;
								obj22 = obj24;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X17_v11-4]");
								if (0f < vector4.x)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X17_v11-4]");
									vector4 = (Vector2)0;
								}
								float num102 = num27 - vector3.x;
								bool flag18 = num102 < 0f;
								bool flag19 = num102 == 0f;
								int num103 = num27 ^ vector3;
								int num104 = num27 ^ num102;
								int num105 = num103 & num104;
								bool flag20 = num105 < 0;
								bool flag21 = flag18 == flag20;
								bool flag22 = !flag19;
								if (flag21 && flag22)
								{
									vector3 = (Vector2)num27;
								}
								num101++;
								if (num82 < num11)
								{
									num11 = num82;
								}
								float num106 = num82 - num10;
								bool flag23 = num106 < 0f;
								bool flag24 = num106 == 0f;
								int num107 = num82 ^ num10;
								int num108 = num82 ^ num106;
								int num109 = num107 & num108;
								bool flag25 = num109 < 0;
								obj21 = (nint)obj21 + 12;
								obj22 = (nint)obj22 + 8;
								obj23 = (nint)obj23 + 8;
								bool flag26 = flag23 == flag25;
								bool flag27 = !flag24;
								if (flag26 && flag27)
								{
									num10 = num82;
								}
								obj24 = (nint)obj24 + 8;
							}
							while (num19 != num101);
							num13 = num5;
						}
						goto IL_1a5c;
					}
					exposedList6 = exposedList3;
					goto IL_1a79;
					IL_1315:
					meshGenerator2.clipper.ClipEnd(array[num7]);
					goto IL_1336;
					IL_11b5:
					num82 = settings.zSpacing;
					num13 = num5;
					goto IL_1a5c;
					IL_1336:
					num7++;
					flag28 = num7 < submeshInstruction2.endSlot;
					num4 = num10;
					vector2 = vector3;
					num3 = num11;
					vector = vector4;
					exposedList5 = exposedList6;
					meshGenerator = meshGenerator2;
					submeshInstruction = submeshInstruction2;
					array = array2;
				}
				while (flag28);
			}
			meshGenerator.clipper.ClipEnd();
			meshGenerator.meshBoundsMin = vector;
			meshGenerator.meshBoundsMin.y = num3;
			meshGenerator.meshBoundsMax = vector2;
			meshGenerator.meshBoundsMax.y = num4;
			float num110 = settings.zSpacing * (float)submeshInstruction.endSlot;
			meshGenerator.meshBoundsThickness = num110;
			int[] items4 = exposedList5.Items;
			if (exposedList5.Count < items4.Length)
			{
				int num111 = exposedList5.Count << 2;
				object obj25 = (nint)items4 + num111;
				object obj26 = (nint)obj25 + 32;
				int num112 = items4.Length - exposedList5.Count;
				bool flag29;
				do
				{
					obj26 = 0;
					obj26 = (nint)obj26 + 4;
					int num113 = num112 - 1;
					flag29 = num112 != 1;
					num112 = num113;
				}
				while (flag29);
			}
			int num114 = meshGenerator.submeshIndex + 1;
			meshGenerator.submeshIndex = num114;
		}

		[Token(Token = "0x600067D")]
		[Address(RVA = "0x156E1F4", Offset = "0x156E1F4", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = instruction.submeshInstructions;\n\tv57 = v16.Count < 1;\n\tif (v57) goto L_004B;\n\tv47 = v16.Items + 0x20;\nL_002E:\n\tv123 = *([v47 @ X24_v5]);\n\tv47 = v47 + 0x30;\n\tSpine.Unity.MeshGenerator::AddSubmesh(this, &v123 @ V2_v4, updateTriangles);\n\tv49 = v49 + 1;\n\tv136 = v16.Count != v49;\n\tif (v136) goto L_002E;\nL_004B:\n\treturn;\n\tv31 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void BuildMesh(SkeletonRendererInstruction instruction, bool updateTriangles)
		{
			//IL_0048: Expected O, but got I
			//IL_006d: Expected O, but got I
			//IL_007b: Expected O, but got Ref
			ExposedList<SubmeshInstruction> submeshInstructions = instruction.submeshInstructions;
			if (submeshInstructions.Count >= 1)
			{
				object obj = (nint)submeshInstructions.Items + 32;
				int num = 0;
				do
				{
					object obj2 = obj;
					obj = (nint)obj + 48;
					AddSubmesh((SubmeshInstruction)(&obj2), updateTriangles);
					num++;
				}
				while (submeshInstructions.Count != num);
			}
		}

		[Token(Token = "0x600067E")]
		[Address(RVA = "0x1565C98", Offset = "0x1565C98", Length = "0x1100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_004B;\n\tv52 = Il2CppMethodInfo;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, instruction, updateTriangles, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv75 = Il2CppMethodInfo;\n\tv76 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, instruction, updateTriangles, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv1027 = Il2CppMethodInfo;\n\tv1028 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1027, instruction, updateTriangles, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv1108 = Il2CppMethodInfo;\n\tv1109 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1108, instruction, updateTriangles, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv1137 = Il2CppMethodInfo;\n\tv1138 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1137, instruction, updateTriangles, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv1147 = Il2CppMethodInfo;\n\tv1148 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1147, instruction, updateTriangles, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv1152 = Il2CppMethodInfo;\n\tv1153 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1152, instruction, updateTriangles, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv1234 = Il2CppMethodInfo;\n\tv1235 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1234, instruction, updateTriangles, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv1394 = Spine.ExposedList`1<System.Int32>;\n\tv1395 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1394, instruction, updateTriangles, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv1441 = Spine.ExposedList`1<UnityEngine.Vector2>;\n\tv1442 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1441, instruction, updateTriangles, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv1458 = Spine.MeshAttachment;\n\tv1459 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1458, instruction, updateTriangles, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv1467 = Spine.RegionAttachment;\n\tv1468 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1467, instruction, updateTriangles, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv1476 = System.Single[];\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1476, instruction, updateTriangles, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv70 = 1;\n\t*([1A37CC5]) = v70;\nL_004B:\n\tv871 = this.vertexBuffer;\n\tv893 = this.vertexBuffer + 0x10;\n\tv991 = *([v893 @ X0_v44 (UnityEngine.Vector3[]&)]);\n\tv565 = instruction.rawVertexCount <= v991.Length;\n\tif (v565) goto L_007E;\n\tSystem.Array::Resize(v893, instruction.rawVertexCount);\n\tv894 = this.uvBuffer + 0x10;\n\tSystem.Array::Resize(v894, instruction.rawVertexCount);\n\tv1144 = this.colorBuffer + 0x10;\n\tSystem.Array::Resize(v1144, instruction.rawVertexCount);\n\tv871 = this.vertexBuffer;\nL_007E:\n\tv378 = this.colorBuffer;\n\tv507 = this.uvBuffer;\n\tv378.Count = instruction.rawVertexCount;\n\tv507.Count = instruction.rawVertexCount;\n\tv871.Count = instruction.rawVertexCount;\n\tv1461 = instruction.submeshInstructions;\n\tv1079 = this.meshBoundsMax;\n\tv1078 = this.meshBoundsMax.y;\n\tv1077 = this.meshBoundsMin;\n\tv1076 = this.meshBoundsMin.y;\n\tv1124 = v1461.Count < 1;\n\tif (v1124) goto L_FFFFFFFF;\n\tv1019 = v507.Items;\n\tv413 = this.tempVerts;\n\tv1450 = this.settings.pmaVertexColors & 0x10100;\n\t// 176 NotImplemented \"Instruction DUP not yet implemented.\"\nL_00C3:\n\tv1478 = v489 * 0x30;\n\tv873 = v1461.Items + v1478;\n\tv997 = *([v873 @ X9_v25+20]);\n\tv380 = *([v997 @ X8_v51+28]);\n\tv983 = *([v873 @ X9_v25+28]);\n\tv2127 = this.settings.pmaVertexColors & 0x100;\n\tv2128 = v2127 == 0;\n\tif (v2128) goto L_02A9;\n\tv1001 = v976.uv2;\n\tv2294 = v976.uv2 == 0;\n\tv2295 = ~v2294;\n\tif (v2295) goto L_00F7;\n\tv2451 = new Spine.ExposedList`1<UnityEngine.Vector2>();\n\tSpine.ExposedList`1<UnityEngine.Vector2>::.ctor(v2451);\n\tv976.uv2 = v2451;\n\tv897 = new Spine.ExposedList`1<UnityEngine.Vector2>();\n\tSpine.ExposedList`1<UnityEngine.Vector2>::.ctor(v897);\n\tv1001 = v976.uv2;\n\tv976.uv3 = v897;\nL_00F7:\n\tv898 = v1001 + 0x10;\n\tv874 = *([v898 @ X0_v58 (UnityEngine.Vector2[]&)]);\n\tv567 = instruction.rawVertexCount <= v874.Length;\n\tif (v567) goto L_011C;\n\tSystem.Array::Resize(v898, instruction.rawVertexCount);\n\tv2567 = v976.uv3 + 0x10;\n\tSystem.Array::Resize(v2567, instruction.rawVertexCount);\n\tv1001 = v976.uv2;\nL_011C:\n\tv876 = v976.uv3;\n\tv876.Count = instruction.rawVertexCount;\n\tv1001.Count = instruction.rawVertexCount;\n\tv2315 = v983 >= *([v873 @ X9_v25+2C]);\n\tif (v2315) goto L_02A9;\n\tv2121 = v1001.Items;\n\tv2105 = v876.Items;\nL_0142:\n\tv1983 = v2009 << 3;\n\tv2030 = *([v380 @ X10_v21+10]) + v1983;\n\tv2012 = *([v2030 @ X12_v58+20]);\n\tv2031 = *([v2012 @ X13_v54+18]);\n\tv2769 = *([v2031 @ X12_v59+85]) == 0;\n\tif (v2769) goto L_0292;\n\tv2034 = *([v2012 @ X13_v54+40]);\n\tv1999 = *([v2012 @ X13_v54+38]);\n\tv2784 = *([v2012 @ X13_v54+40]) == 0;\n\tif (v2784) goto L_0292;\n\tv2785 = *([v2034 @ X12_v62]);\n\tv1974 = *([v542 @ X2_v5 (Il2CppClass<Spine.RegionAttachment>)]);\n\tv1968 = *([v2012 @ X13_v54+30]);\n\tv1964 = *([v2012 @ X13_v54+34]);\n\tv2838 = *([v2785 @ X14_v40+130]) < *([v1974 @ X16_v31+130]);\n\tv2839 = ~v2838;\n\tv2044 = ~v2839;\n\tif (v2044) goto L_0171;\n\tv1987 = *([v1974 @ X16_v31+130]) << 3;\n\tv2858 = *([v2785 @ X14_v40+C8]) + v1987;\n\tv2419 = *([v2858 @ X17_v35-8]) == v1974;\n\tif (v2419) goto L_01F0;\nL_0171:\n\tv1972 = *([v455 @ X3_v5 (Il2CppClass<Spine.MeshAttachment>)]);\n\tv2869 = *([v2785 @ X14_v40+130]) < *([v1972 @ X16_v32+130]);\n\tv2820 = ~v2869;\n\tv2796 = ~v2820;\n\tif (v2796) goto L_0292;\n\tv1984 = *([v1972 @ X16_v32+130]) << 3;\n\tv2920 = *([v2785 @ X14_v40+C8]) + v1984;\n\tv2404 = *([v2920 @ X14_v42-8]) != v1972;\n\tif (v2404) goto L_0292;\n\tv2957 = this.settings.pmaVertexColors == 0;\n\tif (v2957) goto L_01AD;\n\tv2366 = *([v2012 @ X13_v54+10]);\n\tv3053 = *([v997 @ X8_v51+6C]) * *([v2012 @ X13_v54+2C]);\n\tv277 = v3053 * *([v2034 @ X12_v62+84]);\n\tv1999 = v1999 * v277;\n\tv1964 = v1964 * v277;\n\tv1968 = v1968 * v277;\n\tv2995 = *([v2366 @ X14_v51+50]) != 1;\n\tif (v2995) goto L_FFFFFFFF;\n\tgoto L_01AD;\nL_01AD:\n\t;\n\tv2042 = *([v2034 @ X12_v62+30]) < 1;\n\tif (v2042) goto L_0292;\nL_01C9:\n\tv1985 = v2200 << 3;\n\tv1978 = v1001.Items + v1985;\n\t*([v1978 @ X14_v48+20]) = v1968;\n\tv2121[v2200 @ X11_v43 (System.Int32)].y = v1964;\n\tv2014 = v2014 + 2;\n\tv2790 = v2200 << 3;\n\tv2787 = v876.Items + v2790;\n\tv2794 = v2200 + 1;\n\t*([v2787 @ X14_v50+20]) = v1999;\n\tv2105[v2200 @ X11_v43 (System.Int32)].y = v277;\n\tv2797 = v2014 < *([v2034 @ X12_v62+30]);\n\tif (v2797) goto L_01C9;\n\tgoto L_0292;\nL_01F0:\n\tv2918 = this.settings.pmaVertexColors == 0;\n\tif (v2918) goto L_021C;\n\tv2367 = *([v2012 @ X13_v54+10]);\n\tv2991 = *([v997 @ X8_v51+6C]) * *([v2012 @ X13_v54+2C]);\n\tv277 = v2991 * *([v2034 @ X12_v62+6C]);\n\tv1999 = v1999 * v277;\n\tv1964 = v1964 * v277;\n\tv1968 = v1968 * v277;\n\tv2938 = *([v2367 @ X14_v58+50]) != 1;\n\tif (v2938) goto L_FFFFFFFF;\n\tgoto L_021C;\nL_021C:\n\tv2159 = v2200 << 3;\n\tv3049 = v1001.Items + v2159;\n\t*([v3049 @ X13_v62+20]) = v1968;\n\tv2121[v2200 @ X11_v43 (System.Int32)].y = v1964;\n\tv2181 = v2200 + 1;\n\tv2160 = v2181 << 3;\n\tv3062 = v1001.Items + v2160;\n\t*([v3062 @ X14_v55+20]) = v1968;\n\tv2121[v2181 @ X13_v63 (System.Int32)].y = v1964;\n\tv2156 = v2200 + 2;\n\tv2161 = v2156 << 3;\n\tv3110 = v1001.Items + v2161;\n\t*([v3110 @ X15_v45+20]) = v1968;\n\tv2121[v2156 @ X14_v56 (System.Int32)].y = v1964;\n\tv2146 = v2200 + 3;\n\tv1986 = v2146 << 3;\n\tv1973 = v1001.Items + v1986;\n\t*([v1973 @ X16_v34+20]) = v1968;\n\tv2121[v2146 @ X15_v46 (System.Int32)].y = v1964;\n\tv2162 = v2200 << 3;\n\tv3229 = v876.Items + v2162;\n\t*([v3229 @ X12_v67+20]) = v1999;\n\tv2105[v2200 @ X11_v43 (System.Int32)].y = v277;\n\tv2163 = v2181 << 3;\n\tv3265 = v876.Items + v2163;\n\t*([v3265 @ X12_v69+20]) = v1999;\n\tv2105[v2181 @ X13_v63 (System.Int32)].y = v277;\n\tv2164 = v2156 << 3;\n\tv3291 = v876.Items + v2164;\n\t*([v3291 @ X12_v71+20]) = v1999;\n\tv2105[v2156 @ X14_v56 (System.Int32)].y = v277;\n\tv2788 = v2146 << 3;\n\tv2792 = v876.Items + v2788;\n\t*([v2792 @ X12_v73+20]) = \n// ... truncated")]
		public unsafe void BuildMeshWithArrays(SkeletonRendererInstruction instruction, bool updateTriangles)
		{
			//IL_1d58: Expected I, but got O
			//IL_1d66: Expected I, but got O
			//IL_01be: Expected I, but got O
			//IL_01d5: Expected I, but got O
			//IL_0209: Expected O, but got I
			//IL_0219: Expected O, but got I
			//IL_022e: Expected O, but got I
			//IL_0243: Expected O, but got I
			//IL_1d33: Expected O, but got I
			//IL_1e29: Expected I, but got O
			//IL_1e37: Expected I, but got O
			//IL_0c3a: Expected O, but got I
			//IL_0c4a: Expected O, but got I
			//IL_0307: Expected I, but got O
			//IL_0315: Expected I, but got O
			//IL_266c: Expected O, but got I
			//IL_03b6: Expected I, but got O
			//IL_03c4: Expected I, but got O
			//IL_1fc1: Expected O, but got I
			//IL_1fd1: Expected O, but got I
			//IL_1fe1: Expected O, but got I
			//IL_1ff5: Unknown result type (might be due to invalid IL or missing references)
			//IL_1ffa: Expected Ref, but got Unknown
			//IL_0cb6: Expected I, but got O
			//IL_0cbe: Expected O, but got I
			//IL_0475: Expected O, but got I
			//IL_0485: Expected O, but got I
			//IL_0d71: Expected O, but got I
			//IL_049a: Expected O, but got I
			//IL_2ed2: Expected I, but got O
			//IL_2ee0: Expected I, but got O
			//IL_0d44: Expected O, but got I
			//IL_205e: Expected I, but got O
			//IL_206c: Expected I, but got O
			//IL_0de0: Expected O, but got I
			//IL_2610: Expected O, but got I
			//IL_0fa3: Expected O, but got I
			//IL_04d5: Expected O, but got I
			//IL_04e5: Expected F4, but got I
			//IL_0ffa: Expected O, but got I
			//IL_1051: Expected O, but got I
			//IL_0523: Expected O, but got I
			//IL_0533: Expected F4, but got I
			//IL_0543: Expected F4, but got I
			//IL_2153: Expected O, but got I
			//IL_215b: Expected O, but got I
			//IL_109a: Expected O, but got I
			//IL_05e0: Expected O, but got I
			//IL_2193: Expected O, but got I
			//IL_21a3: Expected O, but got I
			//IL_05b3: Expected O, but got I
			//IL_21b8: Expected O, but got I
			//IL_0658: Expected O, but got I
			//IL_1757: Unknown result type (might be due to invalid IL or missing references)
			//IL_175c: Expected I4, but got Unknown
			//IL_176c: Expected F4, but got I
			//IL_0e94: Expected F4, but got I
			//IL_0970: Expected O, but got I
			//IL_2f0d: Expected O, but got I
			//IL_11d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_11d5: Expected I4, but got Unknown
			//IL_09bf: Expected O, but got I
			//IL_0899: Expected O, but got I
			//IL_21f3: Expected O, but got I
			//IL_0a0e: Expected O, but got I
			//IL_08be: Expected O, but got I
			//IL_06c6: Expected O, but got I
			//IL_0a5d: Expected O, but got I
			//IL_128e: Expected I4, but got F4
			//IL_1297: Unknown result type (might be due to invalid IL or missing references)
			//IL_129c: Expected I4, but got Unknown
			//IL_1322: Unknown result type (might be due to invalid IL or missing references)
			//IL_1327: Expected I4, but got Unknown
			//IL_1363: Expected O, but got I
			//IL_06eb: Expected O, but got I
			//IL_0a9e: Expected O, but got I
			//IL_138e: Expected O, but got I
			//IL_07ab: Expected O, but got I
			//IL_0adf: Expected O, but got I
			//IL_2290: Expected O, but got I
			//IL_1bfe: Expected F4, but got I
			//IL_1c0b: Expected F4, but got O
			//IL_1c22: Expected I, but got O
			//IL_1c32: Expected O, but got F4
			//IL_1c42: Expected O, but got F4
			//IL_1c50: Expected I, but got O
			//IL_13b9: Expected O, but got I
			//IL_07fa: Expected O, but got I
			//IL_0b20: Expected O, but got I
			//IL_2324: Expected O, but got I
			//IL_18ef: Expected I4, but got F4
			//IL_18f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_18fd: Expected I4, but got Unknown
			//IL_1983: Unknown result type (might be due to invalid IL or missing references)
			//IL_1988: Expected I4, but got Unknown
			//IL_2c93: Unknown result type (might be due to invalid IL or missing references)
			//IL_2c98: Expected O, but got Unknown
			//IL_2ca5: Expected O, but got F4
			//IL_13e4: Expected O, but got I
			//IL_0b61: Expected O, but got I
			//IL_235c: Expected O, but got I
			//IL_1a0d: Expected O, but got I
			//IL_1422: Expected O, but got I
			//IL_1a54: Expected O, but got I
			//IL_147e: Expected O, but got I
			//IL_23a1: Expected I4, but got I8
			//IL_23b0: Expected O, but got I
			//IL_1ac4: Expected O, but got I
			//IL_23cd: Expected O, but got I
			//IL_23f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_23f6: Expected O, but got Unknown
			//IL_2407: Expected I4, but got O
			//IL_1b18: Expected F4, but got I
			//IL_14da: Expected O, but got I
			//IL_1531: Expected O, but got I
			//IL_2986: Unknown result type (might be due to invalid IL or missing references)
			//IL_298b: Expected O, but got Unknown
			//IL_2998: Expected O, but got F4
			//IL_2ad7: Expected O, but got F4
			//IL_2ae4: Expected O, but got F4
			//IL_2bcc: Expected I, but got O
			//IL_2bd4: Expected O, but got F4
			//IL_2bdc: Expected O, but got F4
			//IL_2bea: Expected I, but got O
			ExposedList<Vector3> exposedList = vertexBuffer;
			ref Vector3[] reference = ref *(Vector3[]*)((nint)vertexBuffer + 16);
			Vector3[] array = reference;
			if (instruction.rawVertexCount > array.Length)
			{
				Array.Resize(ref reference, instruction.rawVertexCount);
				Array.Resize(ref *(Vector2[]*)((nint)uvBuffer + 16), instruction.rawVertexCount);
				Array.Resize(ref *(Color32[]*)((nint)colorBuffer + 16), instruction.rawVertexCount);
				exposedList = vertexBuffer;
			}
			ExposedList<Color32> exposedList2 = colorBuffer;
			ExposedList<Vector2> exposedList3 = uvBuffer;
			exposedList2.Count = instruction.rawVertexCount;
			exposedList3.Count = instruction.rawVertexCount;
			exposedList.Count = instruction.rawVertexCount;
			ExposedList<SubmeshInstruction> submeshInstructions = instruction.submeshInstructions;
			Vector2 vector = meshBoundsMax;
			float num = meshBoundsMax.y;
			Vector2 vector2 = meshBoundsMin;
			float num2 = meshBoundsMin.y;
			nint num4;
			nint num6;
			MeshGenerator meshGenerator;
			MeshGenerator meshGenerator3;
			ExposedList<int> exposedList8;
			bool flag35;
			if (submeshInstructions.Count >= 1)
			{
				Vector2[] items = exposedList3.Items;
				float[] array2 = tempVerts;
				int num3 = (settings.pmaVertexColors ? 1 : 0) & 0x10100;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
				num4 = (nint)typeof(MeshAttachment);
				int num5 = 0;
				num6 = (nint)typeof(RegionAttachment);
				int num7 = 0;
				meshGenerator = this;
				float num9 = default(float);
				float num13 = default(float);
				float num14 = default(float);
				float num19 = default(float);
				float num40 = default(float);
				float num41 = default(float);
				float num42 = default(float);
				float num75 = default(float);
				object obj39 = default(object);
				object obj40 = default(object);
				object obj58 = default(object);
				bool flag32;
				while (true)
				{
					int num8 = num5 * 48;
					object obj = (nint)submeshInstructions.Items + num8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v873 @ X9_v25+20]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v997 @ X8_v51+28]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v873 @ X9_v25+28]");
					object obj4 = 0;
					if (((settings.pmaVertexColors ? 1u : 0u) & 0x100u) != 0)
					{
						ExposedList<Vector2> exposedList4 = meshGenerator.uv2;
						if (meshGenerator.uv2 == null)
						{
							ExposedList<Vector2> exposedList5 = new ExposedList<Vector2>();
							meshGenerator.uv2 = exposedList5;
							ExposedList<Vector2> exposedList6 = new ExposedList<Vector2>();
							exposedList4 = meshGenerator.uv2;
							meshGenerator.uv3 = exposedList6;
							num4 = (nint)typeof(MeshAttachment);
							num6 = (nint)typeof(RegionAttachment);
						}
						ref Vector2[] reference2 = ref *(Vector2[]*)((nint)exposedList4 + 16);
						Vector2[] array3 = reference2;
						if (instruction.rawVertexCount > array3.Length)
						{
							Array.Resize(ref reference2, instruction.rawVertexCount);
							Array.Resize(ref *(Vector2[]*)((nint)meshGenerator.uv3 + 16), instruction.rawVertexCount);
							exposedList4 = meshGenerator.uv2;
							num4 = (nint)typeof(MeshAttachment);
							num6 = (nint)typeof(RegionAttachment);
						}
						ExposedList<Vector2> exposedList7 = meshGenerator.uv3;
						exposedList7.Count = instruction.rawVertexCount;
						exposedList4.Count = instruction.rawVertexCount;
						object obj5 = obj4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v873 @ X9_v25+2C]");
						if ((nint)obj5 < 0)
						{
							Vector2[] items2 = exposedList4.Items;
							Vector2[] items3 = exposedList7.Items;
							num9 = 1f;
							object obj6 = obj4;
							int num10 = num7;
							object obj30;
							do
							{
								int num11 = (int)((nint)obj6 << 3);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ X10_v21+10]");
								object obj7 = (nint)0 + (nint)num11;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2030 @ X12_v58+20]");
								object obj8 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2012 @ X13_v54+18]");
								object obj9 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2031 @ X12_v59+85]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2012 @ X13_v54+40]");
									object obj10 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2012 @ X13_v54+38]");
									float num12 = 0f;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2012 @ X13_v54+40]");
									bool flag = (nint)0 == 0;
									num9 = 1f;
									if (!flag)
									{
										object obj11 = obj10;
										object obj12 = num6;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2012 @ X13_v54+30]");
										num13 = 0f;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2012 @ X13_v54+34]");
										num14 = 0f;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2785 @ X14_v40+130]");
										nint num15 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1974 @ X16_v31+130]");
										if (num15 >= 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1974 @ X16_v31+130]");
											int num16 = (int)((nint)0 << 3);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2785 @ X14_v40+C8]");
											object obj13 = (nint)0 + (nint)num16;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2858 @ X17_v35-8]");
											if (0 == (nint)obj12)
											{
												bool flag2 = !settings.pmaVertexColors;
												num9 = 1f;
												if (!flag2)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2012 @ X13_v54+10]");
													object obj14 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v997 @ X8_v51+6C]");
													nint num17 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2012 @ X13_v54+2C]");
													object obj15 = num17 * 0;
													float num18 = (float)obj15;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2034 @ X12_v62+6C]");
													num9 = num18 * 0f;
													num12 *= num9;
													num14 *= num9;
													num13 *= num9;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2367 @ X14_v58+50]");
													if ((nint)0 == 1)
													{
														num19 = 0f;
														num9 = 0f;
													}
													else
													{
														num19 = 0f;
													}
												}
												int num20 = num10 << 3;
												object obj16 = (nint)exposedList4.Items + num20;
												items2[num10].y = num14;
												int num21 = num10 + 1;
												int num22 = num21 << 3;
												object obj17 = (nint)exposedList4.Items + num22;
												items2[num21].y = num14;
												int num23 = num10 + 2;
												int num24 = num23 << 3;
												object obj18 = (nint)exposedList4.Items + num24;
												items2[num23].y = num14;
												int num25 = num10 + 3;
												int num26 = num25 << 3;
												object obj19 = (nint)exposedList4.Items + num26;
												items2[num25].y = num14;
												int num27 = num10 << 3;
												object obj20 = (nint)exposedList7.Items + num27;
												items3[num10].y = num9;
												int num28 = num21 << 3;
												object obj21 = (nint)exposedList7.Items + num28;
												items3[num21].y = num9;
												int num29 = num23 << 3;
												object obj22 = (nint)exposedList7.Items + num29;
												items3[num23].y = num9;
												int num30 = num25 << 3;
												object obj23 = (nint)exposedList7.Items + num30;
												items3[num25].y = num9;
												num10 += 4;
												goto IL_2601;
											}
										}
										object obj24 = num4;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2785 @ X14_v40+130]");
										nint num31 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1972 @ X16_v32+130]");
										bool flag3 = num31 < 0;
										bool flag4 = !flag3;
										bool flag5 = !flag4;
										num9 = 1f;
										if (!flag5)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1972 @ X16_v32+130]");
											int num32 = (int)((nint)0 << 3);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2785 @ X14_v40+C8]");
											object obj25 = (nint)0 + (nint)num32;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2920 @ X14_v42-8]");
											bool flag6 = 0 != (nint)obj24;
											num9 = 1f;
											if (!flag6)
											{
												bool flag7 = !settings.pmaVertexColors;
												num9 = 1f;
												if (!flag7)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2012 @ X13_v54+10]");
													object obj26 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v997 @ X8_v51+6C]");
													nint num33 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2012 @ X13_v54+2C]");
													object obj27 = num33 * 0;
													float num34 = (float)obj27;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2034 @ X12_v62+84]");
													num9 = num34 * 0f;
													num12 *= num9;
													num14 *= num9;
													num13 *= num9;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2366 @ X14_v51+50]");
													if ((nint)0 == 1)
													{
														num19 = 0f;
														num9 = 0f;
													}
													else
													{
														num19 = 0f;
													}
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2034 @ X12_v62+30]");
												if ((nint)0 >= (nint)1)
												{
													int num35 = 0;
													int num38;
													bool flag8;
													do
													{
														int num36 = num10 << 3;
														object obj28 = (nint)exposedList4.Items + num36;
														items2[num10].y = num14;
														num35 += 2;
														int num37 = num10 << 3;
														object obj29 = (nint)exposedList7.Items + num37;
														num38 = num10 + 1;
														items3[num10].y = num9;
														int num39 = num35;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2034 @ X12_v62+30]");
														flag8 = (nint)num39 < (nint)0;
														num10 = num38;
													}
													while (flag8);
													num10 = num38;
												}
											}
										}
									}
								}
								goto IL_2601;
								IL_2601:
								obj6 = (nint)obj6 + 1;
								obj30 = obj6;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v873 @ X9_v25+2C]");
							}
							while (obj30 != null);
						}
					}
					object obj31 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v873 @ X9_v25+2C]");
					if ((nint)obj31 < 0)
					{
						num40 = num40;
						num41 = num41;
						num42 = num42;
						float num43 = num19;
						float num44 = num14;
						float num45 = num13;
						float num46 = num9;
						float[] array4 = array2;
						nint num47 = num4;
						float num48 = num2;
						Vector2 vector3 = vector2;
						float num49 = num;
						Vector2 vector4 = vector;
						nint num50 = num6;
						int num51 = num7;
						MeshGenerator meshGenerator2 = meshGenerator;
						bool flag29;
						do
						{
							int num52 = (int)((nint)obj4 << 3);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ X10_v21+10]");
							object obj32 = (nint)0 + (nint)num52;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1003 @ X8_v60+20]");
							Slot slot = (Slot)0;
							Bone bone = slot.Bone;
							RegionAttachment attachment;
							float num115;
							float num120;
							int num121;
							float num127;
							float num130;
							float num131;
							float num132;
							if (bone.Active)
							{
								attachment = (RegionAttachment)slot.Attachment;
								if (slot.Attachment != null)
								{
									nint num53 = (nint)attachment;
									object obj33 = num50;
									float num54 = settings.zSpacing * (float)obj4;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1005 @ X8_v63 (Il2CppClass<Spine.RegionAttachment>)+130]");
									nint num55 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v386 @ X10_v26+130]");
									if (num55 >= 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v386 @ X10_v26+130]");
										int num56 = (int)((nint)0 << 3);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1005 @ X8_v63 (Il2CppClass<Spine.RegionAttachment>)+C8]");
										object obj34 = (nint)0 + (nint)num56;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2714 @ X11_v36-8]");
										if (0 == (nint)obj33)
										{
											((RegionAttachment)slot.Attachment).ComputeWorldVertices(bone, array4, 0, 2);
											num41 = array4[0];
											num45 = array4[1];
											num40 = array4[2];
											num44 = array4[3];
											num42 = array4[4];
											num46 = array4[5];
											num43 = array4[6];
											int num57 = num51 + 1;
											int num58 = num51 * 12;
											object obj35 = (nint)exposedList.Items + num58;
											_ = array4[0];
											_ = array4[1];
											int num59 = num51 + 2;
											int num60 = num57 * 12;
											object obj36 = (nint)exposedList.Items + num60;
											_ = array4[6];
											_ = array4[7];
											int num61 = num51 + 3;
											int num62 = num59 * 12;
											object obj37 = (nint)exposedList.Items + num62;
											_ = array4[2];
											_ = array4[3];
											int num63 = num61 * 12;
											object obj38 = (nint)exposedList.Items + num63;
											_ = array4[4];
											_ = array4[5];
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v997 @ X8_v51+6C]");
											float num64 = 0f * slot.A;
											float num65 = num64 * attachment.A;
											float num66 = num65 * 255f;
											float num67 = ((!(num66 < 0f)) ? num66 : num66);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v997 @ X8_v51+60]");
											float num68 = 0f * slot.R;
											float num69 = num68 * attachment.R;
											float num73;
											float num74;
											if (!settings.pmaVertexColors)
											{
												float num70 = num69 * 255f;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v997 @ X8_v51+64]");
												float num71 = 0f * slot.G;
												float num72 = num71 * attachment.G;
												num73 = ((!(num70 < 0f)) ? num70 : num70);
												num74 = num72 * num75;
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction BIT not yet implemented.\"");
											}
											else
											{
												SlotData data = slot.Data;
												int num76 = num67 & 0xFF;
												float num77 = num69 * (float)num76;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v997 @ X8_v51+64]");
												float num78 = 0f * slot.G;
												num73 = ((!(num77 < 0f)) ? num77 : num77);
												float num79 = num78 * attachment.G;
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
												num74 = num79 * (float)obj39;
												bool flag9;
												if (data.BlendMode == BlendMode.Additive)
												{
													int num80 = num3 - 65792;
													flag9 = num80 == 0;
												}
												else
												{
													flag9 = true;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction BIT not yet implemented.\"");
												if (!flag9)
												{
													num67 = 0f;
												}
											}
											int num81 = num67 << 24;
											int num82 = num74 & 0xFF;
											int num83 = num82 & 0xFF;
											int num84 = num83 << 16;
											int num85 = num81 & -16711681;
											int num86 = num85 | num84;
											int num87 = (int)((nint)obj40 & 0xFF);
											int num88 = num87 & 0xFF;
											int num89 = num88 << 8;
											int num90 = num86 & -65281;
											int num91 = num90 | num89;
											int num92 = num73 & 0xFF;
											int num93 = num91 & -256;
											int num94 = num93 | num92;
											int num95 = num51 << 2;
											object obj41 = (nint)exposedList2.Items + num95;
											int num96 = num57 << 2;
											object obj42 = (nint)exposedList2.Items + num96;
											int num97 = num59 << 2;
											object obj43 = (nint)exposedList2.Items + num97;
											int num98 = num61 << 2;
											object obj44 = (nint)exposedList2.Items + num98;
											float[] uVs = attachment.UVs;
											int num99 = num51 << 3;
											object obj45 = (nint)exposedList3.Items + num99;
											_ = uVs[0];
											items[num51].y = uVs[1];
											int num100 = num57 << 3;
											object obj46 = (nint)exposedList3.Items + num100;
											_ = uVs[6];
											items[num57].y = uVs[7];
											int num101 = num59 << 3;
											object obj47 = (nint)exposedList3.Items + num101;
											_ = uVs[2];
											items[num59].y = uVs[3];
											int num102 = num61 << 3;
											object obj48 = (nint)exposedList3.Items + num102;
											float num103 = ((!(num41 < vector3.x)) ? vector3.x : num41);
											_ = uVs[4];
											float num104 = num41 - vector4.x;
											bool flag10 = num104 < 0f;
											bool flag11 = num104 == 0f;
											object obj49 = num41 ^ vector4;
											object obj50 = num41 ^ num104;
											int num105 = (int)((nint)obj49 & (nint)obj50);
											bool flag12 = num105 < 0;
											bool flag13 = flag10 == flag12;
											bool flag14 = !flag11;
											float num106 = ((!(flag13 && flag14)) ? vector4.x : num41);
											items[num61].y = uVs[5];
											if (num40 < num103)
											{
												num103 = num40;
											}
											else if (num40 > num106)
											{
												num106 = num40;
											}
											if (num42 < num103)
											{
												num103 = num42;
											}
											else if (num42 > num106)
											{
												num106 = num42;
											}
											if (num43 < num103)
											{
												num103 = num43;
											}
											else if (num43 > num106)
											{
												num106 = num43;
											}
											if (num45 < num48)
											{
												num48 = num45;
											}
											float num107 = num45 - num49;
											bool flag15 = num107 < 0f;
											bool flag16 = num107 == 0f;
											object obj51 = num45 ^ num49;
											object obj52 = num45 ^ num107;
											int num108 = (int)((nint)obj51 & (nint)obj52);
											bool flag17 = num108 < 0;
											bool flag18 = flag15 == flag17;
											bool flag19 = !flag16;
											if (flag18 && flag19)
											{
												num49 = num45;
											}
											if (num44 < num48)
											{
												num48 = num44;
											}
											else if (num44 > num49)
											{
												num49 = num44;
											}
											if (num46 < num48)
											{
												num48 = num46;
											}
											else if (num46 > num49)
											{
												num49 = num46;
											}
											if (array4[7] < num48)
											{
												num48 = array4[7];
											}
											else if (array4[7] > num49)
											{
												num49 = array4[7];
											}
											num51 += 4;
											num47 = (nint)typeof(MeshAttachment);
											vector3 = (Vector2)num103;
											vector4 = (Vector2)num106;
											num50 = (nint)typeof(RegionAttachment);
											goto IL_265d;
										}
									}
									object obj53 = num47;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1005 @ X8_v63 (Il2CppClass<Spine.RegionAttachment>)+130]");
									nint num109 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v385 @ X10_v27+130]");
									if (num109 >= 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v385 @ X10_v27+130]");
										int num110 = (int)((nint)0 << 3);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1005 @ X8_v63 (Il2CppClass<Spine.RegionAttachment>)+C8]");
										object obj54 = (nint)0 + (nint)num110;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2756 @ X8_v65-8]");
										if (0 == (nint)obj53)
										{
											if (attachment.Height > (float)array4.Length)
											{
												array4 = (tempVerts = new float[attachment.Height]);
											}
											((VertexAttachment)slot.Attachment).ComputeWorldVertices(slot, array4);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v997 @ X8_v51+6C]");
											float num111 = 0f * slot.A;
											float num112 = num111;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ X24_v20 (Spine.RegionAttachment)+84]");
											float num113 = num112 * 0f;
											float num114 = num113 * 255f;
											num115 = ((!(num114 < 0f)) ? num114 : num114);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v997 @ X8_v51+60]");
											float num116 = 0f * slot.R;
											float num117 = num116 * (float)attachment.RendererObject;
											float num119;
											if (!settings.pmaVertexColors)
											{
												float num118 = num117 * 255f;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ X24_v20 (Spine.RegionAttachment)+7C]");
												num119 = 0f;
												num120 = ((!(num118 < 0f)) ? num118 : num118);
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction BSL not yet implemented.\"");
												num121 = 1132396544;
												num46 = num75;
											}
											else
											{
												SlotData data2 = slot.Data;
												num46 = slot.G;
												int num122 = num115 & 0xFF;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ X24_v20 (Spine.RegionAttachment)+7C]");
												num119 = 0f;
												float num123 = num117 * (float)num122;
												num120 = ((!(num123 < 0f)) ? num123 : num123);
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
												bool flag20;
												if (data2.BlendMode == BlendMode.Additive)
												{
													int num124 = num3 - 65792;
													flag20 = num124 == 0;
												}
												else
												{
													flag20 = true;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction BSL not yet implemented.\"");
												if (flag20)
												{
													num121 = num122;
												}
												else
												{
													num121 = num122;
													num115 = 0f;
												}
											}
											bool flag21 = num51 == 0;
											bool flag22 = !flag21;
											float num125 = vector3.x;
											float num126 = vector4.x;
											if (!flag22)
											{
												num119 = array4[0];
												num127 = array4[1];
												num125 = ((!(array4[0] < vector3.x)) ? vector3.x : array4[0]);
												float num128 = num119 - vector4.x;
												bool flag23 = num128 < 0f;
												bool flag24 = num128 == 0f;
												object obj55 = num119 ^ vector4;
												object obj56 = num119 ^ num128;
												int num129 = (int)((nint)obj55 & (nint)obj56);
												bool flag25 = num129 < 0;
												bool flag26 = flag23 == flag25;
												bool flag27 = !flag24;
												num126 = ((!(flag26 && flag27)) ? vector4.x : num119);
												if (num127 < num48)
												{
													num48 = num127;
												}
												bool flag28 = num127 > num49;
												num44 = num119;
												num130 = num48;
												num131 = num125;
												num132 = num126;
												if (flag28)
												{
													goto IL_2f7e;
												}
											}
											num44 = num119;
											num127 = num49;
											num130 = num48;
											num131 = num125;
											num132 = num126;
											goto IL_2f7e;
										}
									}
								}
							}
							goto IL_265d;
							IL_265d:
							obj4 = (nint)obj4 + 1;
							object obj57 = obj4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v873 @ X9_v25+2C]");
							flag29 = obj57 != null;
							num19 = num43;
							num14 = num44;
							num13 = num45;
							num9 = num46;
							array2 = array4;
							num4 = num47;
							num2 = num48;
							vector2 = vector3;
							num = num49;
							vector = vector4;
							num6 = num50;
							num7 = num51;
							meshGenerator = meshGenerator2;
							continue;
							IL_2f7e:
							if (!(attachment.Height < float.Epsilon))
							{
								int num133 = num115 << 24;
								int num134 = num46 & 0xFF;
								int num135 = num134 & 0xFF;
								int num136 = num135 << 16;
								int num137 = num133 & -16711681;
								int num138 = num137 | num136;
								int num139 = (int)((nint)obj58 & 0xFF);
								int num140 = num139 & 0xFF;
								int num141 = num140 << 8;
								int num142 = num138 & -65281;
								int num143 = num142 | num141;
								int num144 = num120 & 0xFF;
								int num145 = num143 & -256;
								int num146 = num145 | num144;
								float num147 = num127;
								float num148 = num130;
								float num149 = num131;
								float num150 = num132;
								int num151 = 0;
								int num152 = num51;
								bool flag30;
								do
								{
									int num153 = num151 + 1;
									int num154 = num152 * 12;
									object obj59 = (nint)exposedList.Items + num154;
									_ = array4[num151];
									_ = array4[num153];
									int num155 = num152 << 2;
									object obj60 = (nint)exposedList2.Items + num155;
									int num156 = num153 - 1;
									int num157 = num151 << 2;
									float num158 = attachment.R + (float)num157;
									int num159 = num156 + 1;
									int num160 = num152 << 3;
									object obj61 = (nint)exposedList3.Items + num160;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3442 @ X10_v33 (System.Single)+20]");
									_ = 0;
									int num161 = num153 << 2;
									float num162 = attachment.R + (float)num161;
									ref Vector2 reference3 = ref items[num152];
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3444 @ X11_v31 (System.Single)+20]");
									reference3.y = 0f;
									if (array4[num151] < num149)
									{
										num149 = array4[num151];
									}
									else if (array4[num151] > num150)
									{
										num150 = array4[num151];
									}
									if (array4[num153] < num148)
									{
										num148 = array4[num153];
									}
									else if (array4[num153] > num147)
									{
										num147 = array4[num153];
									}
									int num163 = num159 + 1;
									num51 = num152 + 1;
									flag30 = (float)num163 < attachment.Height;
									num44 = array4[num151];
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3444 @ X11_v31 (System.Single)+20]");
									num121 = 0;
									num46 = array4[num153];
									num127 = num147;
									num130 = num148;
									num131 = num149;
									num132 = num150;
									num151 = num163;
									num152 = num51;
								}
								while (flag30);
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v997 @ X8_v51+60]");
							num42 = 0f;
							num43 = (float)attachment.RendererObject;
							num45 = num121;
							num47 = (nint)typeof(MeshAttachment);
							num48 = num130;
							vector3 = (Vector2)num131;
							num49 = num127;
							vector4 = (Vector2)num132;
							num50 = (nint)typeof(RegionAttachment);
							meshGenerator2 = this;
							goto IL_265d;
						}
						while (flag29);
					}
					num5++;
					bool flag31 = num5 == submeshInstructions.Count;
					flag32 = updateTriangles;
					meshGenerator3 = this;
					if (flag31)
					{
						break;
					}
					submeshInstructions = instruction.submeshInstructions;
					bool flag33 = instruction.submeshInstructions == null;
					bool flag34 = !flag33;
					flag32 = updateTriangles;
					meshGenerator3 = this;
					if (!flag34)
					{
						NullReferenceException ex = new NullReferenceException();
						num4 = num4;
						num2 = num2;
						vector2 = vector2;
						num = num;
						vector = vector;
						num6 = num6;
						meshGenerator = meshGenerator;
						break;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v873 @ X9_v25+2C]");
				exposedList8 = (ExposedList<int>)0;
				flag35 = flag32;
			}
			else
			{
				exposedList8 = null;
				meshGenerator3 = this;
				num4 = (nint)typeof(MeshAttachment);
				num6 = (nint)typeof(RegionAttachment);
				meshGenerator = this;
				flag35 = updateTriangles;
			}
			float num164 = settings.zSpacing * (float)exposedList8;
			meshGenerator.meshBoundsMin = vector2;
			meshGenerator.meshBoundsMin.y = num2;
			meshGenerator.meshBoundsMax = vector;
			meshGenerator.meshBoundsMax.y = num;
			meshGenerator.meshBoundsThickness = num164;
			ExposedList<SubmeshInstruction> submeshInstructions2 = instruction.submeshInstructions;
			ExposedList<ExposedList<int>> exposedList9 = meshGenerator.submeshes;
			exposedList9.Count = submeshInstructions2.Count;
			if (!flag35)
			{
				return;
			}
			ExposedList<int>[] items4 = exposedList9.Items;
			if (submeshInstructions2.Count > items4.Length)
			{
				ExposedList<ExposedList<int>> exposedList10 = exposedList9.Resize(submeshInstructions2.Count);
				bool flag36 = submeshInstructions2.Count < 1;
				num4 = (nint)typeof(MeshAttachment);
				num6 = (nint)typeof(RegionAttachment);
				if (!flag36)
				{
					MeshGenerator meshGenerator4 = meshGenerator;
					int num165 = 0;
					bool flag37;
					do
					{
						ExposedList<ExposedList<int>> exposedList11 = meshGenerator4.submeshes;
						ExposedList<int>[] items5 = exposedList11.Items;
						if (items5[num165] != null)
						{
							items5[num165].Clear(clearArray: false);
						}
						else
						{
							ExposedList<int> exposedList12 = new ExposedList<int>();
							if (exposedList12 != null)
							{
								object obj62 = exposedList12 as ExposedList<int>;
								if (obj62 == null)
								{
									ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
									throw ex2;
								}
							}
							items5[num165] = exposedList12;
						}
						num165++;
						flag37 = submeshInstructions2.Count != num165;
						num4 = (nint)typeof(MeshAttachment);
						num6 = (nint)typeof(RegionAttachment);
						meshGenerator = meshGenerator3;
						meshGenerator4 = meshGenerator3;
					}
					while (flag37);
				}
			}
			ExposedList<SubmeshInstruction> submeshInstructions3 = instruction.submeshInstructions;
			if (submeshInstructions2.Count < 1)
			{
				return;
			}
			int num166 = 0;
			int num167 = 0;
			bool flag41;
			do
			{
				ExposedList<ExposedList<int>> exposedList13 = meshGenerator.submeshes;
				ExposedList<int>[] items6 = exposedList13.Items;
				ExposedList<int> exposedList14 = items6[num167];
				int num168 = num167 * 48;
				object obj63 = (nint)submeshInstructions3.Items + num168;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2560 @ X8_v16+20]");
				MeshGenerator meshGenerator5 = (MeshGenerator)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2560 @ X8_v16+28]");
				object obj64 = 0;
				ref int[] reference4 = ref *(int[]*)(items6[num167] + 16);
				int[] array5 = reference4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2560 @ X8_v16+40]");
				if ((nint)0 > (nint)array5.Length)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2560 @ X8_v16+40]");
					Array.Resize(ref reference4, 0);
					array5 = reference4;
					num4 = (nint)typeof(MeshAttachment);
					num6 = (nint)typeof(RegionAttachment);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2560 @ X8_v16+40]");
					if ((nint)0 < (nint)array5.Length)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2560 @ X8_v16+40]");
						int num169 = 0;
						bool flag38;
						do
						{
							int num170 = num169 + 1;
							array5[num169] = 0;
							flag38 = array5.Length != num170;
							num169 = num170;
						}
						while (flag38);
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2560 @ X8_v16+40]");
				exposedList14.Count = 0;
				ExposedList<Vector2> exposedList15 = meshGenerator5.uvBuffer;
				object obj65 = obj64;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2560 @ X8_v16+2C]");
				if ((nint)obj65 < 0)
				{
					object obj66 = num6;
					object obj67 = num4;
					int num171 = 0;
					int num172 = num166;
					bool flag40;
					do
					{
						int num173 = (int)((nint)obj64 << 3);
						object obj68 = (nint)exposedList15.Items + num173;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2782 @ X14_v6+20]");
						object obj69 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ X14_v7+18]");
						object obj70 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ X15_v6+85]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ X14_v7+40]");
							object obj71 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ X14_v7+40]");
							if ((nint)0 != 0)
							{
								object obj72 = obj71;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ X15_v9+130]");
								nint num174 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ X10_v7+130]");
								if (num174 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ X10_v7+130]");
									int num175 = (int)((nint)0 << 3);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ X15_v9+C8]");
									object obj73 = (nint)0 + (nint)num175;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2977 @ X17_v15-8]");
									if (0 == num6)
									{
										int num176 = num171 + 1;
										array5[num171] = num172;
										int num177 = num171 + 2;
										int num178 = (array5[num176] = num172 + 2);
										int num179 = num171 + 3;
										int num180 = (array5[num177] = num172 + 1);
										int num181 = num171 + 4;
										array5[num179] = num178;
										int num182 = num171 + 5;
										int num183 = num172 + 3;
										array5[num181] = num183;
										num171 += 6;
										array5[num182] = num180;
										num172 += 4;
										goto IL_2efe;
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ X15_v9+130]");
								nint num184 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v521 @ X11_v6+130]");
								if (num184 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v521 @ X11_v6+130]");
									int num185 = (int)((nint)0 << 3);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ X15_v9+C8]");
									object obj74 = (nint)0 + (nint)num185;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3046 @ X15_v11-8]");
									if (0 == num4)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ X14_v9+70]");
										object obj75 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ X16_v8+18]");
										if ((nint)0 >= (nint)1)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ X16_v8+18]");
											int num186 = 0;
											object obj76 = (nint)obj75 + 32;
											int num187 = num171;
											bool flag39;
											do
											{
												obj76 = (nint)obj76 + 4;
												int num188 = num186 - 1;
												num171 = num187 + 1;
												object obj77 = obj76 + num172;
												array5[num187] = (int)obj77;
												flag39 = num186 != 1;
												num186 = num188;
												num187 = num171;
											}
											while (flag39);
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ X14_v9+30]");
										int num189 = (int)((nint)0 >> 1);
										num172 += num189;
									}
								}
							}
						}
						goto IL_2efe;
						IL_2efe:
						obj64 = (nint)obj64 + 1;
						object obj78 = obj64;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2560 @ X8_v16+2C]");
						flag40 = obj78 != null;
						num166 = num172;
					}
					while (flag40);
				}
				num167++;
				flag41 = num167 != submeshInstructions2.Count;
				meshGenerator = meshGenerator3;
			}
			while (flag41);
		}

		[Token(Token = "0x600067F")]
		[Address(RVA = "0x156E290", Offset = "0x156E290", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.vertexBuffer;\n\tv16 = v2.Count < 1;\n\tif (v16) goto L_0038;\n\t// 23 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv29 = v2.Items + 0x28;\nL_0025:\n\tv64 = v64 + 1;\n\tv82 = *([v29 @ X11_v5-8]) * v74;\n\tv80 = *([v29 @ X11_v5]) * scale;\n\t*([v29 @ X11_v5-8]) = v82;\n\t*([v29 @ X11_v5]) = v80;\n\tv29 = v29 + 0xC;\n\tv87 = v2.Count != v64;\n\tif (v87) goto L_0025;\nL_0038:\n\tv109 = this.meshBoundsMin * v110;\n\tv111 = this.meshBoundsThickness * scale;\n\tthis.meshBoundsMin = v109;\n\tthis.meshBoundsThickness = v111;\n\treturn;\n\tv18 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ScaleVertexData(float scale)
		{
			//IL_0101: Expected O, but got F4
			//IL_004f: Expected O, but got I
			//IL_0081: Expected O, but got I
			//IL_009d: Expected O, but got F4
			//IL_00ac: Expected O, but got I
			ExposedList<Vector3> exposedList = vertexBuffer;
			if (exposedList.Count >= 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
				object obj = (nint)exposedList.Items + 40;
				int num = 0;
				object obj3 = default(object);
				do
				{
					num++;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ X11_v5-8]");
					object obj2 = 0 * (nint)obj3;
					float num2 = (float)obj * scale;
					obj = num2;
					obj = (nint)obj + 12;
				}
				while (exposedList.Count != num);
			}
			object obj4 = default(object);
			float num3 = meshBoundsMin.x * (float)obj4;
			float num4 = meshBoundsThickness * scale;
			meshBoundsMin = (Vector2)num3;
			meshBoundsThickness = num4;
		}

		[Token(Token = "0x6000680")]
		[Address(RVA = "0x156E04C", Offset = "0x156E04C", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv40 = Il2CppMethodInfo;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, vertexCount, methodInfo, v43, v44, v45, v46, v47, r2, g2, b2, a, v48, v49, v50, v51);\n\tv59 = Il2CppMethodInfo;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, vertexCount, methodInfo, v43, v44, v45, v46, v47, r2, g2, b2, a, v48, v49, v50, v51);\n\tv188 = Spine.ExposedList`1<UnityEngine.Vector2>;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v188, vertexCount, methodInfo, v43, v44, v45, v46, v47, r2, g2, b2, a, v48, v49, v50, v51);\n\tv55 = 1;\n\t*([1A37CC6]) = v55;\nL_0023:\n\tv56 = this.vertexBuffer;\n\tv181 = this.uv2;\n\tv63 = this.uv2 == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_003F;\n\tv191 = new Spine.ExposedList`1<UnityEngine.Vector2>();\n\tSpine.ExposedList`1<UnityEngine.Vector2>::.ctor(v191);\n\tthis.uv2 = v191;\n\tv164 = new Spine.ExposedList`1<UnityEngine.Vector2>();\n\tSpine.ExposedList`1<UnityEngine.Vector2>::.ctor(v164);\n\tv181 = this.uv2;\n\tthis.uv3 = v164;\nL_003F:\n\tv165 = v181 + 0x10;\n\tv144 = *([v165 @ X0_v6 (UnityEngine.Vector2[]&)]);\n\tv183 = v56.Count + vertexCount;\n\tv92 = v183 <= v144.Length;\n\tif (v92) goto L_005F;\n\tSystem.Array::Resize(v165, v183);\n\tv266 = this.uv3 + 0x10;\n\tSystem.Array::Resize(v266, v183);\n\tv181 = this.uv2;\nL_005F:\n\tv146 = this.uv3;\n\tv146.Count = v183;\n\tv181.Count = v183;\n\tv93 = vertexCount < 1;\n\tif (v93) goto L_00B4;\n\tv177 = v181.Items;\n\tv143 = v146.Items;\n\tv81 = v56.Count << 0x20;\nL_0084:\n\tv76 = v81 >> 0x20;\n\tv72 = v76 << 3;\n\tv68 = v181.Items + v72;\n\t*([v68 @ X14_v5+20]) = r2;\n\tv177[v76 @ X13_v6 (System.Int32)].y = g2;\n\tv272 = v76 << 3;\n\tv273 = v146.Items + v272;\n\tv81 = v81 + 0x100000000;\n\tv275 = v84 - 1;\n\t*([v273 @ X13_v7+20]) = b2;\n\tv143[v76 @ X13_v6 (System.Int32)].y = a;\n\tv276 = v84 != 1;\n\tif (v276) goto L_0084;\nL_00B4:\n\treturn;\n\tv163 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 129 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void AddAttachmentTintBlack(float r2, float g2, float b2, float a, int vertexCount)
		{
			//IL_01b3: Expected O, but got I
			//IL_01f4: Expected O, but got I
			//IL_0206: Expected I4, but got I8
			ExposedList<Vector3> exposedList = vertexBuffer;
			ExposedList<Vector2> exposedList2 = uv2;
			if (uv2 == null)
			{
				ExposedList<Vector2> exposedList3 = new ExposedList<Vector2>();
				uv2 = exposedList3;
				ExposedList<Vector2> exposedList4 = new ExposedList<Vector2>();
				exposedList2 = uv2;
				uv3 = exposedList4;
			}
			ref Vector2[] reference = ref *(Vector2[]*)((nint)exposedList2 + 16);
			Vector2[] array = reference;
			int num = exposedList.Count + vertexCount;
			if (num > array.Length)
			{
				Array.Resize(ref reference, num);
				Array.Resize(ref *(Vector2[]*)((nint)uv3 + 16), num);
				exposedList2 = uv2;
			}
			ExposedList<Vector2> exposedList5 = uv3;
			exposedList5.Count = num;
			exposedList2.Count = num;
			if (vertexCount >= 1)
			{
				Vector2[] items = exposedList2.Items;
				Vector2[] items2 = exposedList5.Items;
				int num2 = exposedList.Count << 32;
				int num3 = vertexCount;
				bool flag;
				do
				{
					int num4 = num2 >> 32;
					int num5 = num4 << 3;
					object obj = (nint)exposedList2.Items + num5;
					items[num4].y = g2;
					int num6 = num4 << 3;
					object obj2 = (nint)exposedList5.Items + num6;
					num2 = (int)(num2 + 4294967296L);
					int num7 = num3 - 1;
					items2[num4].y = a;
					flag = num3 != 1;
					num3 = num7;
				}
				while (flag);
			}
		}

		[Token(Token = "0x6000681")]
		[Address(RVA = "0x1566EC8", Offset = "0x1566EC8", Length = "0x354")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv32 = Il2CppMethodInfo;\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, mesh, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv55 = Il2CppMethodInfo;\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, mesh, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv258 = UnityEngine.Vector3[];\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v258, mesh, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv51 = 1;\n\t*([1A37CC7]) = v51;\nL_001F:\n\tv52 = this.vertexBuffer;\n\tv57 = this.uvBuffer;\n\tv217 = this.colorBuffer;\n\tv211 = v52.Items;\n\tgoto L_0044;\n\tv329 = UnityEngine.Vector3;\n\tv330 = \"il2cpp_codegen_initialize_runtime_metadata\"(v329, mesh, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv332 = 1;\n\t*([1A35519]) = v332;\nL_0044:\n\tv343 = v52.Count >= v211.Length;\n\tif (v343) goto L_0072;\n\tv344 = UnityEngine.Vector3;\n\tv347 = *([v344 @ X8_v31 (Il2CppClass<UnityEngine.Vector3>)+B8]);\n\tv348 = v347.zeroVector;\n\tv444 = *([v347 @ X8_v32 (Il2CppStaticFields<UnityEngine.Vector3>)+8]);\n\tv350 = v52.Count * 0xC;\n\tv351 = v211 + v350;\n\tv381 = v351 + 0x28;\n\tv380 = v211.Length - v52.Count;\nL_005D:\n\t*([v381 @ X8_v35-8]) = v348;\n\t*([v381 @ X8_v35]) = v444;\n\tv381 = v381 + 0xC;\n\tv366 = v380 - 1;\n\tv355 = v380 != 1;\n\tif (v355) goto L_005D;\nL_0072:\n\tUnityEngine.Mesh::set_vertices(mesh, v211);\n\tUnityEngine.Mesh::set_uv(mesh, v57.Items);\n\tUnityEngine.Mesh::set_colors32(mesh, v217.Items);\n\tv414 = this.meshBoundsMin & 0x7FFFFFFF;\n\tv424 = v414 != 0x7F800000;\n\tif (v424) goto L_0091;\n\tv425 = 0;\n\tgoto L_00A0;\nL_0091:\n\t// 145 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv434 = this.meshBoundsMax - this.meshBoundsMin;\n\tv444 = v434 * 0x3F;\n\tv437 = this.meshBoundsMin + v444;\nL_00A0:\n\tUnityEngine.Mesh::set_bounds(mesh, v443);\n\tv450 = ~this.settings.addNormals;\n\tif (v450) goto L_010B;\n\tv199 = this + 0x70;\n\tv471 = this.normals;\n\tv453 = *([v199 @ X23_v7 (UnityEngine.Vector3[]&)]) == 0;\n\tif (v453) goto L_00AF;\n\tv494 = v471.Length;\n\tgoto L_00B7;\nL_00AF:\n\t// 175 NewArr v487 @ X0_v28 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), v211.Length\n\t*([v199 @ X23_v7 (UnityEngine.Vector3[]&)]) = v487;\nL_00B7:\n\tv504 = v494 == v211.Length;\n\tif (v504) goto L_0109;\n\tSystem.Array::Resize(v199, v211.Length);\n\tv471 = this.normals;\n\tv518 = v494 >= v211.Length;\n\tif (v518) goto L_0109;\n\tv551 = v494 * 0xC;\n\tv552 = *([v199 @ X23_v7 (UnityEngine.Vector3[]&)]) + v551;\n\tv66 = v552 + 0x28;\n\tv62 = v211.Length - v494;\nL_00DF:\n\tgoto L_00F1;\n\tv566 = v206;\n\tv567 = \"il2cpp_codegen_initialize_runtime_metadata\"(v566, v117, v110, v35, v36, v37, v38, v39, v189, v184, v88, v91, v85, v45, v46, v47);\n\tv568 = 1;\n\t*([1A37D14]) = v568;\nL_00F1:\n\tv570 = UnityEngine.Vector3;\n\tv513 = v62 - 1;\n\tv539 = *([v570 @ X9_v20 (Il2CppClass<UnityEngine.Vector3>)+B8]);\n\t*([v66 @ X27_v7-8]) = v539.backVector;\n\t*([v66 @ X27_v7]) = *([v539 @ X9_v21 (Il2CppStaticFields<UnityEngine.Vector3>)+5C]);\n\tv66 = v66 + 0xC;\n\tv517 = v62 != 1;\n\tif (v517) goto L_00DF;\n\tv471 = this.normals;\nL_0109:\n\tUnityEngine.Mesh::set_normals(mesh, v471);\nL_010B:\n\tv481 = ~this.settings.tintBlack;\n\tif (v481) goto L_014B;\n\tv548 = this.uv2;\n\tv488 = this.uv2 == 0;\n\tif (v488) goto L_014B;\n\tv231 = this.uv2 + 0x10;\n\tv222 = *([v231 @ X0_v14 (UnityEngine.Vector2[]&)]);\n\tv157 = v211.Length == v222.Length;\n\tif (v157) goto L_0137;\n\tSystem.Array::Resize(v231, v211.Length);\n\tv232 = this.uv3 + 0x10;\n\tSystem.Array::Resize(v232, v211.Length);\n\tv224 = this.uv3;\n\tv548 = this.uv2;\n\tv224.Count = v211.Length;\n\tv548.Count = v211.Length;\nL_0137:\n\tUnityEngine.Mesh::set_uv2(mesh, v548.Items);\n\tv252 = this.uv3;\n\tUnityEngine.Mesh::set_uv3(mesh, v252.Items);\nL_014B:\n\treturn;\n\tv229 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 230 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void FillVertexData(Mesh mesh)
		{
			//IL_0146: Unknown result type (might be due to invalid IL or missing references)
			//IL_014b: Expected I4, but got Unknown
			//IL_0048: Expected I, but got O
			//IL_0051: Expected I, but got O
			//IL_006a: Expected F4, but got I
			//IL_008b: Expected O, but got I
			//IL_009a: Expected O, but got I
			//IL_01e1: Expected O, but got Ref
			//IL_01e9: Expected O, but got F4
			//IL_00c0: Expected O, but got F4
			//IL_00cf: Expected O, but got I
			//IL_0174: Expected O, but got I4
			//IL_017c: Expected O, but got Ref
			//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b2: Expected O, but got Unknown
			//IL_02c1: Expected O, but got I
			//IL_02e3: Expected I, but got O
			//IL_02fa: Expected I, but got O
			//IL_0310: Expected O, but got I
			//IL_031f: Expected O, but got I
			ExposedList<Vector3> exposedList = vertexBuffer;
			ExposedList<Vector2> exposedList2 = uvBuffer;
			ExposedList<Color32> exposedList3 = colorBuffer;
			Vector3[] items = exposedList.Items;
			if (exposedList.Count < items.Length)
			{
				nint num = (nint)typeof(Vector3);
				nint num2 = (nint)Vector3.zero;
				Vector3 zero = Vector3.zero;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ X8_v32 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
				float num3 = 0f;
				int num4 = exposedList.Count * 12;
				object obj = (nint)items + num4;
				object obj2 = (nint)obj + 40;
				int num5 = items.Length - exposedList.Count;
				bool flag;
				do
				{
					obj2 = num3;
					obj2 = (nint)obj2 + 12;
					int num6 = num5 - 1;
					flag = num5 != 1;
					num5 = num6;
				}
				while (flag);
			}
			mesh.vertices = items;
			mesh.uv = exposedList2.Items;
			mesh.colors32 = exposedList3.Items;
			int num7 = meshBoundsMin & 0x7FFFFFFF;
			Bounds bounds;
			if (num7 == 2139095040)
			{
				object obj3 = 0;
				bounds = (Bounds)(&obj3);
				Vector3 zero = meshBoundsMin;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
				float num8 = meshBoundsMax.x - meshBoundsMin.x;
				float num3 = num8 * 8.8E-44f;
				float num9 = meshBoundsMin.x + num3;
				bounds = (Bounds)(&num9);
				Vector3 zero = (Vector3)num9;
			}
			mesh.bounds = bounds;
			if (settings.addNormals)
			{
				ref Vector3[] reference = ref *(Vector3[]*)((nint)this + 112);
				Vector3[] array = reference;
				int num10;
				if (reference != null)
				{
					num10 = array.Length;
				}
				else
				{
					Vector3[] array2 = new Vector3[items.Length];
					reference = ref *(Vector3[]*)array2;
					num10 = 0;
					array = array2;
				}
				if (num10 != items.Length)
				{
					Array.Resize(ref reference, items.Length);
					array = reference;
					if (num10 < items.Length)
					{
						int num11 = num10 * 12;
						object obj4 = reference + num11;
						object obj5 = (nint)obj4 + 40;
						int num12 = items.Length - num10;
						bool flag2;
						do
						{
							nint num13 = (nint)typeof(Vector3);
							int num14 = num12 - 1;
							nint num15 = (nint)Vector3.zero;
							_ = Vector3.back;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v539 @ X9_v21 (Il2CppStaticFields<UnityEngine.Vector3>)+5C]");
							obj5 = 0;
							obj5 = (nint)obj5 + 12;
							flag2 = num12 != 1;
							num12 = num14;
						}
						while (flag2);
						array = reference;
					}
				}
				mesh.normals = array;
			}
			if (!settings.tintBlack)
			{
				return;
			}
			ExposedList<Vector2> exposedList4 = uv2;
			if (uv2 != null)
			{
				ref Vector2[] reference2 = ref *(Vector2[]*)((nint)uv2 + 16);
				Vector2[] array3 = reference2;
				if (items.Length != array3.Length)
				{
					Array.Resize(ref reference2, items.Length);
					Array.Resize(ref *(Vector2[]*)((nint)uv3 + 16), items.Length);
					ExposedList<Vector2> exposedList5 = uv3;
					exposedList4 = uv2;
					exposedList5.Count = items.Length;
					exposedList4.Count = items.Length;
				}
				mesh.uv2 = exposedList4.Items;
				ExposedList<Vector2> exposedList6 = uv3;
				mesh.uv3 = exposedList6.Items;
			}
		}

		[Token(Token = "0x6000682")]
		[Address(RVA = "0x15673EC", Offset = "0x15673EC", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv34 = Spine.Unity.MeshGenerator;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, mesh, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 1;\n\t*([1A37CC8]) = v52;\nL_001B:\n\tv54 = ~this.settings.calculateTangents;\n\tif (v54) goto L_00A7;\n\tv55 = this.vertexBuffer;\n\tv69 = this.submeshes;\n\tv166 = this.uvBuffer;\n\tv162 = v55.Items;\n\tv153 = v69.Items;\n\tv183 = this + 0x78;\n\tv180 = this + 0x80;\n\tgoto L_0038;\n\tv283 = \"il2cpp_codegen_runtime_class_init\"(v280, mesh, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0038:\n\t;\n\tSpine.Unity.MeshGenerator::SolveTangents2DEnsureSize(v183, v180, v55.Count, v162.Length);\n\tv92 = v69.Count < 1;\n\tif (v92) goto L_0080;\nL_005A:\n\tv188 = v153[v184 @ X20_v9 (System.Int32)];\n\tgoto L_006C;\n\tv333 = \"il2cpp_codegen_runtime_class_init\"(v331, v144, v140, v148, v75, v72, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_006C:\n\tSpine.Unity.MeshGenerator::SolveTangents2DTriangles(*([v180 @ X23_v5 (UnityEngine.Vector2[]&)]), v188.Items, v188.Count, v162, v166.Items, v55.Count);\n\tv184 = v184 + 1;\n\tv292 = v69.Count != v184;\n\tif (v292) goto L_005A;\nL_0080:\n\tgoto L_0085;\n\tv317 = \"il2cpp_codegen_runtime_class_init\"(v313, v303, v301, v149, v76, v73, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0085:\n\tSpine.Unity.MeshGenerator::SolveTangents2DBuffer(*([v183 @ X20_v5 (UnityEngine.Vector4[]&)]), *([v180 @ X23_v5 (UnityEngine.Vector2[]&)]), v55.Count);\n\tUnityEngine.Mesh::set_tangents(mesh, *([v183 @ X20_v5 (UnityEngine.Vector4[]&)]));\n\treturn;\nL_00A7:\n\treturn;\n\tv193 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 135 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void FillLateVertexData(Mesh mesh)
		{
			if (!settings.calculateTangents)
			{
				return;
			}
			ExposedList<Vector3> exposedList = vertexBuffer;
			ExposedList<ExposedList<int>> exposedList2 = submeshes;
			ExposedList<Vector2> exposedList3 = uvBuffer;
			Vector3[] items = exposedList.Items;
			ExposedList<int>[] items2 = exposedList2.Items;
			ref Vector4[] reference = ref *(Vector4[]*)((nint)this + 120);
			ref Vector2[] reference2 = ref *(Vector2[]*)((nint)this + 128);
			SolveTangents2DEnsureSize(ref reference, ref reference2, exposedList.Count, items.Length);
			if (exposedList2.Count >= 1)
			{
				int num = 0;
				do
				{
					ExposedList<int> exposedList4 = items2[num];
					SolveTangents2DTriangles(reference2, exposedList4.Items, exposedList4.Count, items, exposedList3.Items, exposedList.Count);
					num++;
				}
				while (exposedList2.Count != num);
			}
			SolveTangents2DBuffer(reference, reference2, exposedList.Count);
			mesh.tangents = reference;
		}

		[Token(Token = "0x6000683")]
		[Address(RVA = "0x156721C", Offset = "0x156721C", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.submeshes;\n\tv74 = v10.Items;\n\tUnityEngine.Mesh::set_subMeshCount(mesh, v10.Count);\n\tv29 = v10.Count < 1;\n\tif (v29) goto L_0049;\nL_002E:\n\tv82 = v74[v26 @ X21_v6 (System.Int32)];\n\tUnityEngine.Mesh::SetTriangles(mesh, v82.Items, v26, 0);\n\tv26 = v26 + 1;\n\tv130 = v10.Count != v26;\n\tif (v130) goto L_002E;\nL_0049:\n\treturn;\n\tv83 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void FillTriangles(Mesh mesh)
		{
			ExposedList<ExposedList<int>> exposedList = submeshes;
			ExposedList<int>[] items = exposedList.Items;
			mesh.subMeshCount = exposedList.Count;
			if (exposedList.Count >= 1)
			{
				int num = 0;
				do
				{
					ExposedList<int> exposedList2 = items[num];
					mesh.SetTriangles(exposedList2.Items, num, calculateBounds: false);
					num++;
				}
				while (exposedList.Count != num);
			}
		}

		[Token(Token = "0x6000684")]
		[Address(RVA = "0x156E66C", Offset = "0x156E66C", Length = "0x248")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\n\tv34 = Il2CppMethodInfo;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, minimumVertexCount, inlcudeTintBlack, includeTangents, includeNormals, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv54 = Il2CppMethodInfo;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, minimumVertexCount, inlcudeTintBlack, includeTangents, includeNormals, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv125 = Il2CppMethodInfo;\n\tv126 = \"il2cpp_codegen_initialize_runtime_metadata\"(v125, minimumVertexCount, inlcudeTintBlack, includeTangents, includeNormals, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv130 = Il2CppMethodInfo;\n\tv131 = \"il2cpp_codegen_initialize_runtime_metadata\"(v130, minimumVertexCount, inlcudeTintBlack, includeTangents, includeNormals, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv214 = Il2CppMethodInfo;\n\tv215 = \"il2cpp_codegen_initialize_runtime_metadata\"(v214, minimumVertexCount, inlcudeTintBlack, includeTangents, includeNormals, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv217 = Il2CppMethodInfo;\n\tv218 = \"il2cpp_codegen_initialize_runtime_metadata\"(v217, minimumVertexCount, inlcudeTintBlack, includeTangents, includeNormals, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv221 = Spine.ExposedList`1<UnityEngine.Vector2>;\n\tv222 = \"il2cpp_codegen_initialize_runtime_metadata\"(v221, minimumVertexCount, inlcudeTintBlack, includeTangents, includeNormals, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv224 = UnityEngine.Vector3[];\n\tv225 = \"il2cpp_codegen_initialize_runtime_metadata\"(v224, minimumVertexCount, inlcudeTintBlack, includeTangents, includeNormals, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv231 = UnityEngine.Vector4[];\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v231, minimumVertexCount, inlcudeTintBlack, includeTangents, includeNormals, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A37CC9]) = v50;\nL_0035:\n\tv56 = this.vertexBuffer + 0x10;\n\tv57 = *([v56 @ X0_v5 (UnityEngine.Vector3[]&)]);\n\tv81 = v57.Length >= minimumVertexCount;\n\tif (v81) goto L_00C2;\n\tSystem.Array::Resize(v56, minimumVertexCount);\n\tv107 = this.uvBuffer + 0x10;\n\tSystem.Array::Resize(v107, minimumVertexCount);\n\tv227 = this.colorBuffer + 0x10;\n\tSystem.Array::Resize(v227, minimumVertexCount);\n\tv233 = inlcudeTintBlack == 0;\n\tif (v233) goto L_0084;\n\tv250 = this.uv2;\n\tv235 = this.uv2 == 0;\n\tv236 = ~v235;\n\tif (v236) goto L_007C;\n\tv247 = new Spine.ExposedList`1<UnityEngine.Vector2>();\n\tSpine.ExposedList`1<UnityEngine.Vector2>::.ctor(v247, minimumVertexCount);\n\tthis.uv2 = v247;\n\tv275 = new Spine.ExposedList`1<UnityEngine.Vector2>();\n\tSpine.ExposedList`1<UnityEngine.Vector2>::.ctor(v275, minimumVertexCount);\n\tv250 = this.uv2;\n\tthis.uv3 = v275;\nL_007C:\n\tv254 = Spine.ExposedList`1<UnityEngine.Vector2>::Resize(v250, minimumVertexCount);\n\tv241 = Spine.ExposedList`1<UnityEngine.Vector2>::Resize(this.uv3, minimumVertexCount);\nL_0084:\n\tv244 = includeNormals == 0;\n\tif (v244) goto L_0090;\n\tv161 = this + 0x70;\n\tv257 = *([v161 @ X22_v8 (UnityEngine.Vector3[]&)]) == 0;\n\tif (v257) goto L_00AB;\n\tSystem.Array::Resize(v161, minimumVertexCount);\nL_0090:\n\tv152 = includeTangents == 0;\n\tif (v152) goto L_00C2;\nL_0092:\n\tv155 = this + 0x78;\n\tv151 = *([v155 @ X20_v4 (UnityEngine.Vector4[]&)]) == 0;\n\tif (v151) goto L_00B6;\n\tSystem.Array::Resize(v155, minimumVertexCount);\n\treturn;\nL_00AB:\n\t// 171 NewArr v149 @ X0_v16 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), minimumVertexCount @ X1 (System.Int32)\n\t*([v161 @ X22_v8 (UnityEngine.Vector3[]&)]) = v149;\n\tv277 = includeTangents == 0;\n\tv153 = ~v277;\n\tif (v153) goto L_0092;\n\tgoto L_00C2;\nL_00B6:\n\t// 182 NewArr v147 @ X0_v12 (UnityEngine.Vector4[]), typeof(UnityEngine.Vector4[]), minimumVertexCount @ X1 (System.Int32)\n\t*([v155 @ X20_v4 (UnityEngine.Vector4[]&)]) = v147;\nL_00C2:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 128 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void EnsureVertexCapacity(int minimumVertexCount, bool inlcudeTintBlack = false, bool includeTangents = false, bool includeNormals = false)
		{
			//IL_00f3: Expected O, but got I4
			//IL_0110: Expected O, but got I4
			ref Vector3[] reference = ref *(Vector3[]*)((nint)vertexBuffer + 16);
			Vector3[] array = reference;
			if (array.Length >= minimumVertexCount)
			{
				return;
			}
			Array.Resize(ref reference, minimumVertexCount);
			Array.Resize(ref *(Vector2[]*)((nint)uvBuffer + 16), minimumVertexCount);
			Array.Resize(ref *(Color32[]*)((nint)colorBuffer + 16), minimumVertexCount);
			if (inlcudeTintBlack)
			{
				ExposedList<Vector2> exposedList = uv2;
				if (uv2 == null)
				{
					ExposedList<Vector2> exposedList2 = new ExposedList<Vector2>((IEnumerable<Vector2>)minimumVertexCount);
					uv2 = exposedList2;
					ExposedList<Vector2> exposedList3 = new ExposedList<Vector2>((IEnumerable<Vector2>)minimumVertexCount);
					exposedList = uv2;
					uv3 = exposedList3;
				}
				ExposedList<Vector2> exposedList4 = exposedList.Resize(minimumVertexCount);
				ExposedList<Vector2> exposedList5 = uv3.Resize(minimumVertexCount);
			}
			if (includeNormals)
			{
				ref Vector3[] reference2 = ref *(Vector3[]*)((nint)this + 112);
				if (reference2 == null)
				{
					Vector3[] array2 = new Vector3[minimumVertexCount];
					reference2 = ref *(Vector3[]*)array2;
					if (!includeTangents)
					{
						return;
					}
					goto IL_01d9;
				}
				Array.Resize(ref reference2, minimumVertexCount);
			}
			if (includeTangents)
			{
				goto IL_01d9;
			}
			return;
			IL_01d9:
			ref Vector4[] reference3 = ref *(Vector4[]*)((nint)this + 120);
			if (reference3 != null)
			{
				Array.Resize(ref reference3, minimumVertexCount);
				return;
			}
			Vector4[] array3 = new Vector4[minimumVertexCount];
			reference3 = ref *(Vector4[]*)array3;
		}

		[Token(Token = "0x6000685")]
		[Address(RVA = "0x156E8B4", Offset = "0x156E8B4", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv38 = Il2CppMethodInfo;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = Il2CppMethodInfo;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv65 = Il2CppMethodInfo;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv92 = Il2CppMethodInfo;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v92, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A37CCA]) = v34;\nL_0022:\n\tSpine.ExposedList`1<UnityEngine.Vector3>::TrimExcess(this.vertexBuffer);\n\tSpine.ExposedList`1<UnityEngine.Vector2>::TrimExcess(this.uvBuffer);\n\tSpine.ExposedList`1<UnityEngine.Color32>::TrimExcess(this.colorBuffer);\n\tv97 = this.uv2 == 0;\n\tif (v97) goto L_0037;\n\tSpine.ExposedList`1<UnityEngine.Vector2>::TrimExcess(this.uv2);\nL_0037:\n\tv100 = this.uv3 == 0;\n\tif (v100) goto L_003B;\n\tSpine.ExposedList`1<UnityEngine.Vector2>::TrimExcess(this.uv3);\nL_003B:\n\tv56 = this.vertexBuffer;\n\tv57 = v56.Items;\n\tv79 = this + 0x70;\n\tv105 = *([v79 @ X0_v10 (UnityEngine.Vector3[]&)]) == 0;\n\tif (v105) goto L_004C;\n\tSystem.Array::Resize(v79, v57.Length);\nL_004C:\n\tv111 = this + 0x78;\n\tv81 = *([v111 @ X19_v2 (UnityEngine.Vector4[]&)]) == 0;\n\tif (v81) goto L_005F;\n\tSystem.Array::Resize(v111, v57.Length);\n\treturn;\nL_005F:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void TrimExcess()
		{
			vertexBuffer.TrimExcess();
			uvBuffer.TrimExcess();
			colorBuffer.TrimExcess();
			if (uv2 != null)
			{
				uv2.TrimExcess();
			}
			if (uv3 != null)
			{
				uv3.TrimExcess();
			}
			ExposedList<Vector3> exposedList = vertexBuffer;
			Vector3[] items = exposedList.Items;
			ref Vector3[] reference = ref *(Vector3[]*)((nint)this + 112);
			if (reference != null)
			{
				Array.Resize(ref reference, items.Length);
			}
			ref Vector4[] reference2 = ref *(Vector4[]*)((nint)this + 120);
			if (reference2 != null)
			{
				Array.Resize(ref reference2, items.Length);
			}
		}

		[Token(Token = "0x6000686")]
		[Address(RVA = "0x156E314", Offset = "0x156E314", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = UnityEngine.Vector2[];\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, tempTanBuffer, vertexCount, vertexBufferLength, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv47 = UnityEngine.Vector4[];\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, tempTanBuffer, vertexCount, vertexBufferLength, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 1;\n\t*([1A37CCB]) = v43;\nL_0019:\n\tv44 = tangentBuffer->klass;\n\tv45 = *([tangentBuffer @ X0 (UnityEngine.Vector4[]&)]) == 0;\n\tif (v45) goto L_002B;\n\tv53 = v44.Length == vertexBufferLength;\n\tif (v53) goto L_002D;\nL_002B:\n\t// 43 NewArr v79 @ X0_v7 (UnityEngine.Vector4[]), typeof(UnityEngine.Vector4[]), vertexBufferLength @ X3 (System.Int32)\n\t*([tangentBuffer @ X0 (UnityEngine.Vector4[]&)]) = v79;\nL_002D:\n\tv91 = tempTanBuffer->klass;\n\tv92 = *([tempTanBuffer @ X1 (UnityEngine.Vector2[]&)]) == 0;\n\tif (v92) goto L_0040;\n\tv112 = vertexCount << 1;\n\tv106 = v112 > v91.Length;\n\tif (v106) goto L_0044;\n\tgoto L_004D;\nL_0040:\n\tv112 = vertexCount << 1;\nL_0044:\n\t// 68 NewArr v125 @ X0_v5 (UnityEngine.Vector2[]), typeof(UnityEngine.Vector2[]), v112 @ X1_v3 (System.Int32)\n\t*([tempTanBuffer @ X1 (UnityEngine.Vector2[]&)]) = v125;\nL_004D:\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe static void SolveTangents2DEnsureSize(ref Vector4[] tangentBuffer, ref Vector2[] tempTanBuffer, int vertexCount, int vertexBufferLength)
		{
			Vector4[] array = tangentBuffer;
			if (tangentBuffer == null || array.Length != vertexBufferLength)
			{
				Vector4[] array2 = new Vector4[vertexBufferLength];
				ref Vector4[] reference = ref *(Vector4[]*)array2;
			}
			Vector2[] array3 = tempTanBuffer;
			int num;
			if (tempTanBuffer != null)
			{
				num = vertexCount << 1;
				if (num <= array3.Length)
				{
					return;
				}
			}
			else
			{
				num = vertexCount << 1;
			}
			Vector2[] array4 = new Vector2[num];
			ref Vector2[] reference2 = ref *(Vector2[]*)array4;
		}

		[Token(Token = "0x6000687")]
		[Address(RVA = "0x156E3CC", Offset = "0x156E3CC", Length = "0x1D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = triangleCount < 1;\n\tif (v13) goto L_0123;\nL_001F:\n\tv154 = v161 + 1;\n\tv56 = v154 + 1;\n\tv385 = v161 + 2;\n\tv391 = uvs + 0x20;\n\tv392 = triangles[v154 @ X11_v5 (System.Int32)] << 3;\n\tv393 = v391 + v392;\n\tv396 = triangles[v161 @ X12_v4 (System.Int32)] << 3;\n\tv44 = uvs + v396;\n\tv149 = triangles[v385 @ X12_v6 (System.Int32)] << 3;\n\tv140 = v391 + v149;\n\tv109 = *([v393 @ X14_v5]) - *([v44 @ X14_v6+20]);\n\tv132 = *([v140 @ X13_v8]) - *([v44 @ X14_v6+20]);\n\tv105 = *([v393 @ X14_v5+4]) - uvs[v144 @ X10_v7 (System.Int32)].y;\n\tv121 = *([v140 @ X13_v8+4]) - uvs[v144 @ X10_v7 (System.Int32)].y;\n\tv399 = v109 * v121;\n\tv400 = v105 * v132;\n\tv401 = v399 - v400;\n\tv125 = 1f / v401;\n\tv17 = v401 != 0;\n\tif (v17) goto L_FFFFFFFF;\n\tgoto L_00B2;\nL_00B2:\n\tv406 = triangles[v161 @ X12_v4 (System.Int32)] * 0xC;\n\tv407 = vertices + v406;\n\tv409 = triangles[v154 @ X11_v5 (System.Int32)] * 0xC;\n\tv410 = vertices + v409;\n\tv74 = triangles[v385 @ X12_v6 (System.Int32)] * 0xC;\n\tv412 = vertices + v74;\n\tv284 = triangles[v385 @ X12_v6 (System.Int32)] << 3;\n\tv413 = tempTanBuffer + v284;\n\tv35 = *([v410 @ X13_v11+20]) - *([v407 @ X13_v10+20]);\n\tv32 = v35 * v414;\n\tv29 = *([v412 @ X13_v12+20]) - *([v407 @ X13_v10+20]);\n\tv415 = v29 * v416;\n\tv417 = v32 - v415;\n\tv20 = v417 * v418;\n\t*([v413 @ X13_v13+20]) = v20;\n\tv285 = triangles[v154 @ X11_v5 (System.Int32)] << 3;\n\tv420 = tempTanBuffer + v285;\n\t*([v420 @ X13_v15+20]) = v20;\n\tv286 = triangles[v161 @ X12_v4 (System.Int32)] << 3;\n\tv422 = tempTanBuffer + v286;\n\t*([v422 @ X13_v17+20]) = v20;\n\tv290 = triangles[v385 @ X12_v6 (System.Int32)] + vertexCount;\n\tv23 = v29 * v424;\n\tv425 = v35 * v426;\n\t// 240 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv427 = v23 - v425;\n\tv41 = v427 * v38;\n\tv287 = v290 << 3;\n\tv428 = tempTanBuffer + v287;\n\t*([v428 @ X12_v10+20]) = v41;\n\tv289 = triangles[v154 @ X11_v5 (System.Int32)] + vertexCount;\n\tv288 = v289 << 3;\n\tv430 = tempTanBuffer + v288;\n\t*([v430 @ X11_v9+20]) = v41;\n\tv281 = triangles[v161 @ X12_v4 (System.Int32)] + vertexCount;\n\tv161 = v56 + 1;\n\tv53 = v281 << 3;\n\tv50 = tempTanBuffer + v53;\n\t*([v50 @ X10_v9+20]) = v41;\n\tv77 = v161 < triangleCount;\n\tif (v77) goto L_001F;\nL_0123:\n\treturn;\n\tv97 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 227 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void SolveTangents2DTriangles(Vector2[] tempTanBuffer, int[] triangles, int triangleCount, Vector3[] vertices, Vector2[] uvs, int vertexCount)
		{
			//IL_0073: Expected O, but got I
			//IL_0098: Expected O, but got I
			//IL_00bd: Expected O, but got I
			//IL_00e2: Expected O, but got I
			//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f7: Expected O, but got Unknown
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_010c: Expected O, but got Unknown
			//IL_01f5: Expected O, but got I
			//IL_021a: Expected O, but got I
			//IL_023f: Expected O, but got I
			//IL_0264: Expected O, but got I
			//IL_0281: Expected O, but got I
			//IL_0290: Expected O, but got I
			//IL_02ad: Expected O, but got I
			//IL_02bc: Expected O, but got I
			//IL_02cb: Expected O, but got I
			//IL_02da: Expected O, but got I
			//IL_0309: Expected O, but got I
			//IL_0338: Expected O, but got I
			//IL_0367: Expected O, but got I
			//IL_0376: Expected O, but got I
			//IL_038f: Expected O, but got I
			//IL_03ba: Expected O, but got I
			//IL_03f6: Expected O, but got I
			//IL_0440: Expected O, but got I
			if (triangleCount >= 1)
			{
				int num = 0;
				int num9 = default(int);
				object obj13 = default(object);
				object obj16 = default(object);
				object obj19 = default(object);
				object obj23 = default(object);
				object obj25 = default(object);
				do
				{
					int num2 = num + 1;
					int num3 = num2 + 1;
					int num4 = num + 2;
					object obj = (nint)uvs + 32;
					int num5 = triangles[num2] << 3;
					object obj2 = (nint)obj + num5;
					int num6 = triangles[num] << 3;
					object obj3 = (nint)uvs + num6;
					int num7 = triangles[num4] << 3;
					object obj4 = (nint)obj + num7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X14_v6+20]");
					object obj5 = obj2 - 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X14_v6+20]");
					object obj6 = obj4 - 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v393 @ X14_v5+4]");
					float num8 = 0f - uvs[num9].y;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ X13_v8+4]");
					float num10 = 0f - uvs[num9].y;
					float num11 = (float)obj5 * num10;
					float num12 = num8 * (float)obj6;
					float num13 = num11 - num12;
					float num14 = 1f / num13;
					float num15 = ((num13 != 0f) ? num14 : 0f);
					int num16 = triangles[num] * 12;
					object obj7 = (nint)vertices + num16;
					int num17 = triangles[num2] * 12;
					object obj8 = (nint)vertices + num17;
					int num18 = triangles[num4] * 12;
					object obj9 = (nint)vertices + num18;
					int num19 = triangles[num4] << 3;
					object obj10 = (nint)tempTanBuffer + num19;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v410 @ X13_v11+20]");
					nint num20 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v407 @ X13_v10+20]");
					object obj11 = num20 - 0;
					object obj12 = (nint)obj11 * (nint)obj13;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ X13_v12+20]");
					nint num21 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v407 @ X13_v10+20]");
					object obj14 = num21 - 0;
					object obj15 = (nint)obj14 * (nint)obj16;
					object obj17 = (nint)obj12 - (nint)obj15;
					object obj18 = (nint)obj17 * (nint)obj19;
					int num22 = triangles[num2] << 3;
					object obj20 = (nint)tempTanBuffer + num22;
					int num23 = triangles[num] << 3;
					object obj21 = (nint)tempTanBuffer + num23;
					int num24 = triangles[num4] + vertexCount;
					object obj22 = (nint)obj14 * (nint)obj23;
					object obj24 = (nint)obj11 * (nint)obj25;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
					object obj26 = (nint)obj22 - (nint)obj24;
					float num25 = (float)obj26 * num15;
					int num26 = num24 << 3;
					object obj27 = (nint)tempTanBuffer + num26;
					int num27 = triangles[num2] + vertexCount;
					int num28 = num27 << 3;
					object obj28 = (nint)tempTanBuffer + num28;
					int num29 = triangles[num] + vertexCount;
					num = num3 + 1;
					int num30 = num29 << 3;
					object obj29 = (nint)tempTanBuffer + num30;
				}
				while (num < triangleCount);
			}
		}

		[Token(Token = "0x6000688")]
		[Address(RVA = "0x156E5A0", Offset = "0x156E5A0", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = vertexCount < 1;\n\tif (v13) goto L_007F;\n\tv100 = tempTanBuffer + 0x24;\n\tv102 = tangents + 0x2C;\nL_0023:\n\tv49 = *([v100 @ X10_v3-4]);\n\tv46 = *([v100 @ X10_v3]);\n\tv210 = *([v100 @ X10_v3-4]) * *([v100 @ X10_v3-4]);\n\tv211 = *([v100 @ X10_v3]) * *([v100 @ X10_v3]);\n\tv212 = v210 + v211;\n\tv213 = UnityEngine.Mathf::Sqrt(v212);\n\tv216 = v213 <= 1E-05d;\n\tif (v216) goto L_003A;\n\tv244 = 1f / v213;\n\tv49 = v49 * v244;\n\tv46 = v46 * v244;\nL_003A:\n\tv28 = vertexCount + v101;\n\tv37 = v28 << 3;\n\tv183 = tempTanBuffer + v37;\n\tv251 = v46 * *([v183 @ X12_v7+20]);\n\tv40 = v49 * tempTanBuffer[v28 @ X13_v5 (System.Int32)].y;\n\tv199 = v251 - v40;\n\tv197 = v199 < 0;\n\tv195 = v199 == 0;\n\tv193 = v251 ^ v40;\n\tv191 = v251 ^ v199;\n\tv189 = v193 & v191;\n\tv187 = v189 < 0;\n\tv253 = v197 == v187;\n\tv34 = ~v195;\n\tv185 = v253 & v34;\n\tv31 = ~v185;\n\tif (v31) goto L_FFFFFFFF;\n\tgoto L_006B;\nL_006B:\n\tv101 = v101 + 1;\n\t*([v102 @ X11_v4-C]) = v49;\n\t*([v102 @ X11_v4-8]) = v46;\n\t*([v102 @ X11_v4-4]) = 0;\n\t*([v102 @ X11_v4]) = v43;\n\tv102 = v102 + 0x10;\n\tv100 = v100 + 8;\n\tv72 = vertexCount != v101;\n\tif (v72) goto L_0023;\nL_007F:\n\treturn;\n\tv174 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void SolveTangents2DBuffer(Vector4[] tangents, Vector2[] tempTanBuffer, int vertexCount)
		{
			//IL_002c: Expected O, but got I
			//IL_003b: Expected O, but got I
			//IL_0059: Expected F4, but got I
			//IL_0061: Expected F4, but got O
			//IL_0120: Expected O, but got I
			//IL_0192: Expected O, but got F4
			//IL_019f: Expected O, but got F4
			//IL_023e: Expected O, but got F4
			//IL_024d: Expected O, but got I
			//IL_025c: Expected O, but got I
			if (vertexCount < 1)
			{
				return;
			}
			object obj = (nint)tempTanBuffer + 36;
			object obj2 = (nint)tangents + 44;
			int num = 0;
			do
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X10_v3-4]");
				float num2 = 0f;
				float num3 = (float)obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X10_v3-4]");
				float num4 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X10_v3-4]");
				float num5 = num4 * 0f;
				float num6 = (float)obj * (float)obj;
				float f = num5 + num6;
				float num7 = Mathf.Sqrt(f);
				if ((double)num7 > 1E-05)
				{
					float num8 = 1f / num7;
					num2 *= num8;
					num3 *= num8;
				}
				int num9 = vertexCount + num;
				int num10 = num9 << 3;
				object obj3 = (nint)tempTanBuffer + num10;
				float num11 = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ X12_v7+20]");
				float num12 = num11 * 0f;
				float num13 = num2 * tempTanBuffer[num9].y;
				float num14 = num12 - num13;
				bool flag = num14 < 0f;
				bool flag2 = num14 == 0f;
				object obj4 = num12 ^ num13;
				object obj5 = num12 ^ num14;
				int num15 = (int)((nint)obj4 & (nint)obj5);
				bool flag3 = num15 < 0;
				bool flag4 = flag == flag3;
				bool flag5 = !flag2;
				float num16 = ((!(flag4 && flag5)) ? (-1f) : 1f);
				num++;
				_ = 0;
				obj2 = num16;
				obj2 = (nint)obj2 + 16;
				obj = (nint)obj + 8;
			}
			while (vertexCount != num);
		}

		[Token(Token = "0x6000689")]
		[Address(RVA = "0x156E9E4", Offset = "0x156E9E4", Length = "0x6FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003D;\n\tv28 = System.Int32[];\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, regionAttachment, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv53 = Il2CppMethodInfo;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, regionAttachment, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv62 = Il2CppMethodInfo;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, regionAttachment, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv66 = Il2CppMethodInfo;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, regionAttachment, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv173 = Il2CppMethodInfo;\n\tv174 = \"il2cpp_codegen_initialize_runtime_metadata\"(v173, regionAttachment, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv255 = Il2CppMethodInfo;\n\tv256 = \"il2cpp_codegen_initialize_runtime_metadata\"(v255, regionAttachment, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv264 = Il2CppMethodInfo;\n\tv265 = \"il2cpp_codegen_initialize_runtime_metadata\"(v264, regionAttachment, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv531 = Il2CppMethodInfo;\n\tv532 = \"il2cpp_codegen_initialize_runtime_metadata\"(v531, regionAttachment, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv605 = Il2CppMethodInfo;\n\tv606 = \"il2cpp_codegen_initialize_runtime_metadata\"(v605, regionAttachment, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv609 = Spine.Unity.MeshGenerator;\n\tv610 = \"il2cpp_codegen_initialize_runtime_metadata\"(v609, regionAttachment, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv613 = UnityEngine.Object;\n\tv614 = \"il2cpp_codegen_initialize_runtime_metadata\"(v613, regionAttachment, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv617 = Il2CppFieldInfo;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v617, regionAttachment, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv47 = 1;\n\t*([1A37CCC]) = v47;\nL_003D:\n\tgoto L_0042;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v48, regionAttachment, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0042:\n\tv60 = UnityEngine.Object::op_Equality(mesh, 0);\n\tv64 = regionAttachment == 0;\n\tif (v64) goto L_02D0;\n\tv69 = v60 == 0;\n\tv70 = ~v69;\n\tif (v70) goto L_02D0;\n\tgoto L_0053;\n\tv257 = \"il2cpp_codegen_runtime_class_init\"(v176, v58, v59, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv259 = Spine.Unity.MeshGenerator;\nL_0053:\n\tv261 = v260.AttachmentVerts;\n\tv267 = v261._version + 1;\n\tv261._size = 0;\n\tv261._version = v267;\n\tv268 = regionAttachment.offset;\n\tv430 = v261._items;\n\tv501 = v261._version + 2;\n\tv261._version = v501;\n\tv593 = v430.Length == 0;\n\tif (v593) goto L_0081;\n\tv261._size = 1;\n\t*([v430 @ X9_v6 (UnityEngine.Vector3[])+20]) = v268[0];\n\t*([v430 @ X9_v6 (UnityEngine.Vector3[])+24]) = v268[1];\n\t*([v430 @ X9_v6 (UnityEngine.Vector3[])+28]) = 0;\n\tgoto L_009C;\nL_0081:\n\t// 129 MakeStruct v623 @ AGG1572B68_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v268[0], v268[1], 0\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::AddWithResize(v261, v623);\nL_009C:\n\tv465 = v502.AttachmentVerts;\n\tv503 = v465._items;\n\tv306 = v465._version + 1;\n\tv465._version = v306;\n\tv631 = v465._size < v503.Length;\n\tv632 = ~v631;\n\tif (v632) goto L_00C1;\n\tv641 = v465._size + 1;\n\tv642 = v465._size * 0xC;\n\tv643 = v503 + v642;\n\tv465._size = v641;\n\t*([v643 @ X8_v99+20]) = v268[2];\n\tv503[v465._size (System.Int32)].y = v268[3];\n\tv503[v465._size (System.Int32)].z = 0;\n\tgoto L_00DC;\nL_00C1:\n\t// 193 MakeStruct v648 @ AGG1572BE8_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v268[2], v268[3], 0\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::AddWithResize(v465, v648);\nL_00DC:\n\tv466 = v504.AttachmentVerts;\n\tv505 = v466._items;\n\tv308 = v466._version + 1;\n\tv466._version = v308;\n\tv656 = v466._size < v505.Length;\n\tv657 = ~v656;\n\tif (v657) goto L_0101;\n\tv666 = v466._size + 1;\n\tv667 = v466._size * 0xC;\n\tv668 = v505 + v667;\n\tv466._size = v666;\n\t*([v668 @ X8_v96+20]) = v268[4];\n\tv505[v466._size (System.Int32)].y = v268[5];\n\tv505[v466._size (System.Int32)].z = 0;\n\tgoto L_011C;\nL_0101:\n\t// 257 MakeStruct v673 @ AGG1572C68_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v268[4], v268[5], 0\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::AddWithResize(v466, v673);\nL_011C:\n\tv467 = v506.AttachmentVerts;\n\tv507 = v467._items;\n\tv310 = v467._version + 1;\n\tv467._version = v310;\n\tv681 = v467._size < v507.Length;\n\tv423 = ~v681;\n\tif (v423) goto L_0141;\n\tv683 = v467._size + 1;\n\tv684 = v467._size * 0xC;\n\tv685 = v507 + v684;\n\tv467._size = v683;\n\t*([v685 @ X8_v93+20]) = v268[6];\n\tv507[v467._size (System.Int32)].y = v268[7];\n\tv507[v467._size (System.Int32)].z = 0;\n\tgoto L_0145;\nL_0141:\n\t// 321 MakeStruct v690 @ AGG1572CE8_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v268[6], v268[7], 0\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::AddWithResize(v467, v690);\nL_0145:\n\tv468 = v508.AttachmentUVs;\n\tv437 = v468._version + 1;\n\tv468._size = 0;\n\tv468._version = v437;\n\tv527 = regionAttachment.uvs;\n\tv438 = v468._items;\n\tv510 = v468._version + 2;\n\tv468._version = v510;\n\tv596 = v438.Length == 0;\n\tif (v596) goto L_017B;\n\tv468._size = 1;\n\t*([v438 @ X9_v15 (UnityEngine.Vector2[])+20]) = v527[2];\n\t*([v438 @ X9_v15 (UnityEngine.Vector2[])+24]) = v527[3];\n\tgoto L_0196;\nL_017B:\n\t// 379 MakeStruct v703 @ AGG1572D68_1_v5 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v527[2], v527[3]\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector2>::AddWithResize(v468, v703);\nL_0196:\n\tv469 = v511.AttachmentUVs;\n\tv512 = v469._items;\n\tv313 = v469._version + 1;\n\tv469._version = v313;\n\tv710 = v469._size < v512.Length;\n\tv711 = ~v710;\n\tif (v711) goto L_01B8;\n\tv719 = v469._size + 1;\n\tv720 = v469._size << 3;\n\tv721 = v512 + v720;\n\tv469._size = v719;\n\t*([v721 @ X8_v87+20]) = v527[4];\n\tv512[v314 @ X10_v17 (System.Int32)].y = v527[5];\n\tgoto L_01D3;\nL_01B8:\n\t// 440 MakeStruct v725 @ AGG1572DDC_1_v5 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v527[4], v527[5]\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector2>::AddWithResize(v469, v725);\nL_01D3:\n\tv470 = v513.AttachmentUVs;\n\tv514 = v470._items;\n\tv315 = v470._version + 1;\n\tv470._version = v315;\n\tv732 = v470._size < v514.Length;\n\tv590 = ~v732;\n\tif (v590) goto L_01F5;\n\tv733 = v470._size + 1;\n\tv734 = v470._size << 3;\n\tv735 = v514 + v734;\n\tv470._size = v733;\n\t*([v735 @ X8_v84+20]) = v527[6];\n\tv514[v316 @ X10_v20 (System.Int32)].y = v527[7];\n\tgoto L_0206;\nL_01F5:\n\t// 501 MakeStruct v739 @ AGG1572E50_1_v5 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v527[6], v527[7]\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector2>::AddWithResize(v470, v739);\nL_0206:\n\tv471 = v515.AttachmentUVs;\n\tv516 = v471._items;\n\tv317 = v471._version + 1;\n\tv471._version = v317;\n\tv744 = v471._size < v516.Length;\n\tv428 = ~v744;\n\tif (v428) goto L_0228;\n\tv745 = v471._size + 1;\n\tv746 = v471._size << 3;\n\tv747 = v516 + v746;\n\tv471._size = v745;\n\t*([v747 @ X8_v81+20]) = v527[0];\n\tv516[v318 @ X10_v23 (System.Int32)].y = v527[1];\n\tgoto L_022C;\nL_0228:\n\t// 552 MakeStruct v751 @ AGG1572EC0_1_v5 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v527[0], v527[1]\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector2>::AddWithResize(v471, v751);\nL_022C:\n\tv517 = v754.AttachmentColors32;\n\tv757 = v517._version + 1;\n\tv517._size = 0;\n\tv517._version = v757;\n\tv758 = System.Collections.Generic.List`1<UnityEngine.Color32>::AddWithResize(0, v461);\n\tv525 = v758 & 0xFFFFFFFF;\nL_0242:\n\tgoto L_0246;\n\tv784 = \"il2cpp_codegen_runtime_class_init\"(v780, v462, v451, v31, v32, v33, v34, v35, v120, v118, v113, v78, v40, v41, v42, v43);\n\tv785 = Spine.Unity.MeshGenerator;\nL_0246:\n\tv786 = v74 == 0;\n\tif (v786) goto L_026B;\n\tv472 = v518.AttachmentColors32;\n\tv519 = v472._items;\n\tv320 = v472._version + 1;\n\tv472._version = v320;\n\tv795 = v472._s\n// ... truncated")]
		public static void FillMeshLocal(Mesh mesh, RegionAttachment regionAttachment)
		{
			//IL_0125: Expected I, but got O
			//IL_0220: Expected O, but got I
			//IL_0378: Expected O, but got I
			//IL_04d0: Expected O, but got I
			//IL_073e: Expected O, but got I
			//IL_0867: Expected O, but got I
			//IL_0990: Expected O, but got I
			//IL_0a5d: Expected O, but got I
			//IL_0a70: Expected I4, but got I8
			//IL_0b45: Expected O, but got I4
			//IL_0b21: Expected O, but got I
			bool flag = mesh == null;
			if (regionAttachment == null || flag)
			{
				return;
			}
			List<Vector3> attachmentVerts = AttachmentVerts;
			int version = attachmentVerts._version + 1;
			attachmentVerts._size = 0;
			attachmentVerts._version = version;
			float[] offset = regionAttachment.Offset;
			Vector3[] items = attachmentVerts._items;
			int version2 = attachmentVerts._version + 2;
			attachmentVerts._version = version2;
			nint num;
			if (items.Length != 0)
			{
				attachmentVerts._size = 1;
				_ = offset[0];
				_ = offset[1];
				_ = 0;
				num = unchecked((nint)null);
			}
			else
			{
				Vector3 item = default(Vector3);
				item.x = offset[0];
				item.y = offset[1];
				item.z = 0f;
				attachmentVerts.Add(item);
				num = 0;
			}
			List<Vector3> attachmentVerts2 = AttachmentVerts;
			Vector3[] items2 = attachmentVerts2._items;
			int version3 = attachmentVerts2._version + 1;
			attachmentVerts2._version = version3;
			if (attachmentVerts2.Count < items2.Length)
			{
				int size = attachmentVerts2.Count + 1;
				int num2 = attachmentVerts2.Count * 12;
				object obj = (nint)items2 + num2;
				attachmentVerts2._size = size;
				_ = offset[2];
				items2[attachmentVerts2.Count].y = offset[3];
				items2[attachmentVerts2.Count].z = 0f;
			}
			else
			{
				Vector3 item2 = default(Vector3);
				item2.x = offset[2];
				item2.y = offset[3];
				item2.z = 0f;
				attachmentVerts2.Add(item2);
				num = 0;
			}
			List<Vector3> attachmentVerts3 = AttachmentVerts;
			Vector3[] items3 = attachmentVerts3._items;
			int version4 = attachmentVerts3._version + 1;
			attachmentVerts3._version = version4;
			if (attachmentVerts3.Count < items3.Length)
			{
				int size2 = attachmentVerts3.Count + 1;
				int num3 = attachmentVerts3.Count * 12;
				object obj2 = (nint)items3 + num3;
				attachmentVerts3._size = size2;
				_ = offset[4];
				items3[attachmentVerts3.Count].y = offset[5];
				items3[attachmentVerts3.Count].z = 0f;
			}
			else
			{
				Vector3 item3 = default(Vector3);
				item3.x = offset[4];
				item3.y = offset[5];
				item3.z = 0f;
				attachmentVerts3.Add(item3);
				num = 0;
			}
			List<Vector3> attachmentVerts4 = AttachmentVerts;
			Vector3[] items4 = attachmentVerts4._items;
			int version5 = attachmentVerts4._version + 1;
			attachmentVerts4._version = version5;
			if (attachmentVerts4.Count < items4.Length)
			{
				int size3 = attachmentVerts4.Count + 1;
				int num4 = attachmentVerts4.Count * 12;
				object obj3 = (nint)items4 + num4;
				attachmentVerts4._size = size3;
				_ = offset[6];
				items4[attachmentVerts4.Count].y = offset[7];
				items4[attachmentVerts4.Count].z = 0f;
			}
			else
			{
				Vector3 item4 = default(Vector3);
				item4.x = offset[6];
				item4.y = offset[7];
				item4.z = 0f;
				attachmentVerts4.Add(item4);
				num = 0;
			}
			List<Vector2> attachmentUVs = AttachmentUVs;
			int version6 = attachmentUVs._version + 1;
			attachmentUVs._size = 0;
			attachmentUVs._version = version6;
			float[] uVs = regionAttachment.UVs;
			Vector2[] items5 = attachmentUVs._items;
			int version7 = attachmentUVs._version + 2;
			attachmentUVs._version = version7;
			if (items5.Length != 0)
			{
				attachmentUVs._size = 1;
				_ = uVs[2];
				_ = uVs[3];
			}
			else
			{
				Vector2 item5 = default(Vector2);
				item5.x = uVs[2];
				item5.y = uVs[3];
				attachmentUVs.Add(item5);
				num = 0;
			}
			List<Vector2> attachmentUVs2 = AttachmentUVs;
			Vector2[] items6 = attachmentUVs2._items;
			int version8 = attachmentUVs2._version + 1;
			attachmentUVs2._version = version8;
			if (attachmentUVs2.Count < items6.Length)
			{
				int size4 = attachmentUVs2.Count + 1;
				int num5 = attachmentUVs2.Count << 3;
				object obj4 = (nint)items6 + num5;
				attachmentUVs2._size = size4;
				_ = uVs[4];
				int num6 = default(int);
				items6[num6].y = uVs[5];
			}
			else
			{
				Vector2 item6 = default(Vector2);
				item6.x = uVs[4];
				item6.y = uVs[5];
				attachmentUVs2.Add(item6);
				num = 0;
			}
			List<Vector2> attachmentUVs3 = AttachmentUVs;
			Vector2[] items7 = attachmentUVs3._items;
			int version9 = attachmentUVs3._version + 1;
			attachmentUVs3._version = version9;
			if (attachmentUVs3.Count < items7.Length)
			{
				int size5 = attachmentUVs3.Count + 1;
				int num7 = attachmentUVs3.Count << 3;
				object obj5 = (nint)items7 + num7;
				attachmentUVs3._size = size5;
				_ = uVs[6];
				int num8 = default(int);
				items7[num8].y = uVs[7];
			}
			else
			{
				Vector2 item7 = default(Vector2);
				item7.x = uVs[6];
				item7.y = uVs[7];
				attachmentUVs3.Add(item7);
				num = 0;
			}
			List<Vector2> attachmentUVs4 = AttachmentUVs;
			Vector2[] items8 = attachmentUVs4._items;
			int version10 = attachmentUVs4._version + 1;
			attachmentUVs4._version = version10;
			if (attachmentUVs4.Count < items8.Length)
			{
				int size6 = attachmentUVs4.Count + 1;
				int num9 = attachmentUVs4.Count << 3;
				object obj6 = (nint)items8 + num9;
				attachmentUVs4._size = size6;
				_ = uVs[0];
				int num10 = default(int);
				items8[num10].y = uVs[1];
			}
			else
			{
				Vector2 item8 = default(Vector2);
				item8.x = uVs[0];
				item8.y = uVs[1];
				attachmentUVs4.Add(item8);
				num = 0;
			}
			List<Color32> attachmentColors = AttachmentColors32;
			int version11 = attachmentColors._version + 1;
			attachmentColors._size = 0;
			attachmentColors._version = version11;
			((List<Color32>)null).Add((Color32)num);
			object obj7 = default(object);
			int num11 = (int)((nint)obj7 & 0xFFFFFFFFL);
			for (int num12 = 4; num12 != 0; num12--)
			{
				List<Color32> attachmentColors2 = AttachmentColors32;
				Color32[] items9 = attachmentColors2._items;
				int version12 = attachmentColors2._version + 1;
				attachmentColors2._version = version12;
				if (attachmentColors2.Count < items9.Length)
				{
					int size7 = attachmentColors2.Count + 1;
					int num13 = attachmentColors2.Count << 2;
					object obj8 = (nint)items9 + num13;
					attachmentColors2._size = size7;
				}
				else
				{
					attachmentColors2.Add((Color32)num11);
				}
			}
			List<int> attachmentIndices = AttachmentIndices;
			int version13 = attachmentIndices._version + 1;
			attachmentIndices._size = 0;
			attachmentIndices._version = version13;
			attachmentIndices.AddRange(new int[6] { 0, 2, 1, 0, 3, 2 });
			mesh.Clear();
			mesh.name = regionAttachment.Name;
			mesh.SetVertices(AttachmentVerts);
			mesh.SetUVs(0, AttachmentUVs);
			mesh.SetColors(AttachmentColors32);
			mesh.SetTriangles(AttachmentIndices, 0);
			mesh.RecalculateBounds();
			List<Vector3> attachmentVerts5 = AttachmentVerts;
			int version14 = attachmentVerts5._version + 1;
			attachmentVerts5._size = 0;
			attachmentVerts5._version = version14;
			List<Vector2> attachmentUVs5 = AttachmentUVs;
			int version15 = attachmentUVs5._version + 1;
			attachmentUVs5._size = 0;
			attachmentUVs5._version = version15;
			List<Color32> attachmentColors3 = AttachmentColors32;
			int version16 = attachmentColors3._version + 1;
			attachmentColors3._size = 0;
			attachmentColors3._version = version16;
			List<int> attachmentIndices2 = AttachmentIndices;
			int version17 = attachmentIndices2._version + 1;
			attachmentIndices2._size = 0;
			attachmentIndices2._version = version17;
		}

		[Token(Token = "0x600068A")]
		[Address(RVA = "0x156F0E0", Offset = "0x156F0E0", Length = "0x700")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003E;\n\tv42 = Il2CppMethodInfo;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, meshAttachment, skeletonData, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv66 = Il2CppMethodInfo;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, meshAttachment, skeletonData, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv75 = Il2CppMethodInfo;\n\tv76 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, meshAttachment, skeletonData, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv79 = Il2CppMethodInfo;\n\tv80 = \"il2cpp_codegen_initialize_runtime_metadata\"(v79, meshAttachment, skeletonData, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv240 = Il2CppMethodInfo;\n\tv241 = \"il2cpp_codegen_initialize_runtime_metadata\"(v240, meshAttachment, skeletonData, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv368 = Il2CppMethodInfo;\n\tv369 = \"il2cpp_codegen_initialize_runtime_metadata\"(v368, meshAttachment, skeletonData, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv373 = Il2CppMethodInfo;\n\tv374 = \"il2cpp_codegen_initialize_runtime_metadata\"(v373, meshAttachment, skeletonData, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv380 = Il2CppMethodInfo;\n\tv381 = \"il2cpp_codegen_initialize_runtime_metadata\"(v380, meshAttachment, skeletonData, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv389 = Spine.Unity.MeshGenerator;\n\tv390 = \"il2cpp_codegen_initialize_runtime_metadata\"(v389, meshAttachment, skeletonData, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv779 = UnityEngine.Object;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v779, meshAttachment, skeletonData, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv60 = 1;\n\t*([1A37CCD]) = v60;\nL_003E:\n\tgoto L_0043;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v61, meshAttachment, skeletonData, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\nL_0043:\n\tv73 = UnityEngine.Object::op_Equality(mesh, 0);\n\tv77 = meshAttachment == 0;\n\tif (v77) goto L_02EE;\n\tv82 = v73 == 0;\n\tv83 = ~v82;\n\tif (v83) goto L_02EE;\n\tv248 = meshAttachment.worldVerticesLength < 0;\n\tv251 = meshAttachment.worldVerticesLength ^ meshAttachment.worldVerticesLength;\n\tv252 = meshAttachment.worldVerticesLength & v251;\n\tv253 = v252 < 0;\n\tv254 = v248 == v253;\n\tv255 = ~v254;\n\tv174 = ~v255;\n\tif (v174) goto L_FFFFFFFF;\n\tv375 = meshAttachment.worldVerticesLength + 1;\n\tgoto L_0062;\nL_0062:\n\tgoto L_0066;\n\tv382 = \"il2cpp_codegen_runtime_class_init\"(v244, v71, v72, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv384 = Spine.Unity.MeshGenerator;\nL_0066:\n\tv386 = v385.AttachmentVerts;\n\tv392 = v375 >> 1;\n\tv395 = v386._version + 1;\n\tv386._size = 0;\n\tv386._version = v395;\n\tv396 = Spine.SpineSkeletonExtensions::IsWeighted(meshAttachment);\n\tv781 = v396 == 0;\n\tif (v781) goto L_0176;\n\tv574 = meshAttachment.worldVerticesLength < 1;\n\tif (v574) goto L_01DD;\n\tv533 = meshAttachment.bones;\n\tv525 = meshAttachment.vertices;\nL_009D:\n\tv508 = v867 + 1;\n\tv774 = v533[v867 @ X19_v11 (System.Int32)] + v508;\n\tv575 = v508 >= v774;\n\tif (v575) goto L_FFFFFFFF;\n\tv964 = v533[v867 @ X19_v11 (System.Int32)] << 1;\n\tv965 = v533[v867 @ X19_v11 (System.Int32)] + v964;\n\tv967 = v738 + v965;\nL_00B3:\n\tv751 = skeletonData.bones;\n\tv752 = v751.Items;\n\tv706 = Spine.BoneMatrix::CalculateSetupWorld(v752[v533[v509 @ X29_v9 (System.Int32)]]);\n\tv912 = v738 + 1;\n\tv951 = v912 + 1;\n\tv972 = v738 + 2;\n\tv1165 = v706.a * v525[v738 @ X22_v13 (System.Int32)];\n\tv1166 = v706.b * v525[v912 @ X9_v43 (System.Int32)];\n\tv976 = v706.c * v525[v738 @ X22_v13 (System.Int32)];\n\tv975 = v706.d * v525[v912 @ X9_v43 (System.Int32)];\n\tv1167 = v1165 + v1166;\n\tv1168 = v976 + v975;\n\tv1169 = v706.x + v1167;\n\tv1170 = v706.y + v1168;\n\tv978 = v1169 * v525[v972 @ X11_v20 (System.Int32)];\n\tv977 = v1170 * v525[v972 @ X11_v20 (System.Int32)];\n\tv998 = v769 - 1;\n\tv496 = v496 + v978;\n\tv503 = v503 + v977;\n\tv738 = v951 + 1;\n\tv985 = v769 != 1;\n\tif (v985) goto L_00B3;\n\tgoto L_0133;\nL_0133:\n\tgoto L_0137;\n\tv1033 = \"il2cpp_codegen_runtime_class_init\"(v999, v695, v72, methodInfo, v45, v46, v47, v48, v454, v446, v441, v437, v415, v411, v433, v429);\n\tv1035 = Spine.Unity.MeshGenerator;\nL_0137:\n\tv707 = v754.AttachmentVerts;\n\tv755 = v707._items;\n\tv541 = v707._version + 1;\n\tv707._version = v541;\n\tv1072 = v707._size < v755.Length;\n\tv1073 = ~v1072;\n\tif (v1073) goto L_015C;\n\tv1095 = v707._size + 1;\n\tv1096 = v707._size * 0xC;\n\tv1097 = v755 + v1096;\n\tv707._size = v1095;\n\t*([v1097 @ X8_v73+20]) = v496;\n\tv755[v707._size (System.Int32)].y = v503;\n\tv755[v707._size (System.Int32)].z = 0;\n\tgoto L_015E;\nL_015C:\n\t// 348 MakeStruct v1104 @ AGG15733FC_1_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v496 @ V8_v12 (System.Single), v503 @ V9_v13 (System.Single), 0\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::AddWithResize(v707, v1104);\nL_015E:\n\tv521 = v521 + 2;\n\tv808 = v521 < meshAttachment.worldVerticesLength;\n\tif (v808) goto L_009D;\n\tgoto L_01DD;\nL_0176:\n\tv578 = meshAttachment.worldVerticesLength < 2;\n\tif (v578) goto L_01DD;\n\tv776 = meshAttachment.vertices;\n\tv740 = v392 << 1;\nL_019A:\n\tv516 = v771 << 2;\n\tv961 = meshAttachment.vertices + v516;\n\tgoto L_01A5;\n\tv1027 = \"il2cpp_codegen_runtime_class_init\"(v960, v696, v72, methodInfo, v45, v46, v47, v48, v455, v447, v442, v52, v53, v54, v55, v56);\n\tv1029 = Spine.Unity.MeshGenerator;\nL_01A5:\n\tv708 = v765.AttachmentVerts;\n\tv757 = v708._items;\n\tv542 = v708._version + 1;\n\tv708._version = v542;\n\tv1062 = v708._size < v757.Length;\n\tv1063 = ~v1062;\n\tif (v1063) goto L_01C9;\n\tv1082 = v708._size + 1;\n\tv1083 = v708._size * 0xC;\n\tv1084 = v757 + v1083;\n\tv708._size = v1082;\n\t*([v1084 @ X8_v61+20]) = v776[v771 @ X20_v13 (System.Int32)];\n\tv757[v708._size (System.Int32)].y = *([v961 @ X8_v55+24]);\n\tv757[v708._size (System.Int32)].z = 0;\n\tgoto L_01CB;\nL_01C9:\n\t// 457 MakeStruct v1091 @ AGG15734D8_1_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v776[v771 @ X20_v13 (System.Int32)], [v961 @ X8_v55+24], 0\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::AddWithResize(v708, v1091);\nL_01CB:\n\tv771 = v771 + 2;\n\tv807 = v740 != v771;\n\tif (v807) goto L_019A;\nL_01DD:\n\tv216 = meshAttachment.uvs;\n\tv839 = 0xBF7EB8(0, v697, 0, methodInfo, v45, v46, v47, v48, meshAttachment.r, meshAttachment.g, meshAttachment.b, meshAttachment.a, v706.x, v706.y, v525[v738 @ X22_v13 (System.Int32)], v525[v912 @ X9_v43 (System.Int32)]);\n\tgoto L_01E9;\n\tv878 = v844;\n\tv879 = \"il2cpp_codegen_runtime_class_init\"(v878, v697, v72, methodInfo, v45, v46, v47, v48, v456, v448, v112, v110, v101, v99, v108, v106);\n\tv880 = Spine.Unity.MeshGenerator;\nL_01E9:\n\tv543 = v571.AttachmentUVs;\n\tv421 = v543._version + 1;\n\tv543._size = 0;\n\tv543._version = v421;\n\tv561 = v571.AttachmentColors32;\n\tv544 = v561._version + 1;\n\tv561._size = 0;\n\tv561._version = v544;\n\tv581 = meshAttachment.worldVerticesLength < 2;\n\tif (v581) goto L_0289;\n\tv742 = v839 & 0xFFFFFFFF;\n\tv523 = v392 << 1;\nL_0226:\n\tv518 = v531 << 2;\n\tv1106 = meshAttachment.uvs + v518;\n\tgoto L_0231;\n\tv1116 = \"il2cpp_codegen_runtime_class_init\"(v1105, v698, v688, methodInfo, v45, v46, v47, v48, v457, v449, v112, v110, v101, v99, v108, v106);\n\tv1118 = Spine.Unity.MeshGenerator;\nL_0231:\n\tv710 = v766.AttachmentUVs;\n\tv759 = v710._items;\n\tv545 = v710._version + 1;\n\tv710._version = v545;\n\tv1129 = v710._size < v759.Length;\n\tv686 = ~v1129;\n\tif (v686) goto L_0253;\n\tv1137 = v710._size + 1;\n\tv1138 = v710._size << 3;\n\tv1139 = v759 + v1138;\n\tv710._size = v1137;\n\t*([v1139 @ X8_v48+20]) = v216[v531 @ X25_v8 (System.Int32)];\n\tv759[v546 @ X10_v19 (System.Int32)].y = *([v1106 @ X8_v34+24]);\n\tgoto L_0257;\nL_0253:\n\t// 595 MakeStruct v1145 @ AGG157360C_1_v7 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v216[v531 @ X25_v8 (System.Int32)], [v1106 @ X8_v34+24]\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector2>::AddWithResize(v710, v1145);\nL_0257:\n\tv711 = v760.AttachmentColors32;\n\tv761 = v711._items;\n\tv547 = v711._version + 1;\n\tv711._version = v\n// ... truncated")]
		public static void FillMeshLocal(Mesh mesh, MeshAttachment meshAttachment, SkeletonData skeletonData)
		{
			//IL_05d5: Expected I, but got O
			//IL_017f: Expected I, but got O
			//IL_0608: Expected I, but got O
			//IL_0637: Expected O, but got I
			//IL_01ba: Expected I, but got O
			//IL_0878: Expected I4, but got I8
			//IL_08b5: Expected O, but got I
			//IL_075a: Expected F4, but got I
			//IL_06d0: Expected O, but got I
			//IL_070e: Expected F4, but got I
			//IL_09b9: Expected F4, but got I
			//IL_0950: Expected O, but got I
			//IL_0989: Expected F4, but got I
			//IL_04fa: Expected O, but got I
			//IL_0a92: Expected O, but got I4
			//IL_0431: Expected I, but got O
			//IL_0a6e: Expected O, but got I
			bool flag = mesh == null;
			if (meshAttachment == null || flag)
			{
				return;
			}
			bool flag2 = meshAttachment.WorldVerticesLength < 0;
			int num = meshAttachment.WorldVerticesLength ^ meshAttachment.WorldVerticesLength;
			int num2 = meshAttachment.WorldVerticesLength & num;
			bool flag3 = num2 < 0;
			int num3 = ((flag2 == flag3) ? meshAttachment.WorldVerticesLength : (meshAttachment.WorldVerticesLength + 1));
			List<Vector3> attachmentVerts = AttachmentVerts;
			int num4 = num3 >> 1;
			int version = attachmentVerts._version + 1;
			attachmentVerts._size = 0;
			attachmentVerts._version = version;
			if (meshAttachment.IsWeighted())
			{
				bool flag4 = meshAttachment.WorldVerticesLength < 1;
				nint num5 = unchecked((nint)null);
				if (!flag4)
				{
					int[] bones = meshAttachment.Bones;
					float[] vertices = meshAttachment.Vertices;
					int num6 = 0;
					num5 = unchecked((nint)null);
					int num7 = 0;
					int num8 = 0;
					int num17 = default(int);
					Vector3 item = default(Vector3);
					do
					{
						int num9 = num8 + 1;
						int num10 = bones[num8] + num9;
						float num14;
						float num15;
						if (num9 < num10)
						{
							int num11 = bones[num8] << 1;
							int num12 = bones[num8] + num11;
							int num13 = num7 + num12;
							num14 = 0f;
							num15 = 0f;
							int num16 = bones[num8];
							bool flag5;
							do
							{
								ExposedList<BoneData> bones2 = skeletonData.Bones;
								BoneData[] items = bones2.Items;
								BoneMatrix boneMatrix = BoneMatrix.CalculateSetupWorld(items[bones[num17]]);
								int num18 = num7 + 1;
								int num19 = num18 + 1;
								int num20 = num7 + 2;
								float num21 = boneMatrix.a * vertices[num7];
								float num22 = boneMatrix.b * vertices[num18];
								float num23 = boneMatrix.c * vertices[num7];
								float num24 = boneMatrix.d * vertices[num18];
								float num25 = num21 + num22;
								float num26 = num23 + num24;
								float num27 = boneMatrix.x + num25;
								float num28 = boneMatrix.y + num26;
								float num29 = num27 * vertices[num20];
								float num30 = num28 * vertices[num20];
								int num31 = num16 - 1;
								num14 += num29;
								num15 += num30;
								num7 = num19 + 1;
								flag5 = num16 != 1;
								num16 = num31;
							}
							while (flag5);
							num5 = unchecked((nint)null);
							num7 = num13;
							num8 = num10;
						}
						else
						{
							num14 = 0f;
							num15 = 0f;
							num8 = num9;
						}
						List<Vector3> attachmentVerts2 = AttachmentVerts;
						Vector3[] items2 = attachmentVerts2._items;
						int version2 = attachmentVerts2._version + 1;
						attachmentVerts2._version = version2;
						if (attachmentVerts2.Count < items2.Length)
						{
							int size = attachmentVerts2.Count + 1;
							int num32 = attachmentVerts2.Count * 12;
							object obj = (nint)items2 + num32;
							attachmentVerts2._size = size;
							items2[attachmentVerts2.Count].y = num15;
							items2[attachmentVerts2.Count].z = 0f;
						}
						else
						{
							item.x = num14;
							item.y = num15;
							item.z = 0f;
							attachmentVerts2.Add(item);
							num5 = 0;
						}
						num6 += 2;
					}
					while (num6 < meshAttachment.WorldVerticesLength);
				}
			}
			else
			{
				bool flag6 = meshAttachment.WorldVerticesLength < 2;
				nint num5 = unchecked((nint)null);
				if (!flag6)
				{
					float[] vertices2 = meshAttachment.Vertices;
					int num33 = num4 << 1;
					nint num34 = unchecked((nint)null);
					int num35 = 0;
					Vector3 item2 = default(Vector3);
					bool flag7;
					do
					{
						int num36 = num35 << 2;
						object obj2 = (nint)meshAttachment.Vertices + num36;
						List<Vector3> attachmentVerts3 = AttachmentVerts;
						Vector3[] items3 = attachmentVerts3._items;
						int version3 = attachmentVerts3._version + 1;
						attachmentVerts3._version = version3;
						if (attachmentVerts3.Count < items3.Length)
						{
							int size2 = attachmentVerts3.Count + 1;
							int num37 = attachmentVerts3.Count * 12;
							object obj3 = (nint)items3 + num37;
							attachmentVerts3._size = size2;
							_ = vertices2[num35];
							ref Vector3 reference = ref items3[attachmentVerts3.Count];
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v961 @ X8_v55+24]");
							reference.y = 0f;
							items3[attachmentVerts3.Count].z = 0f;
						}
						else
						{
							item2.x = vertices2[num35];
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v961 @ X8_v55+24]");
							item2.y = 0f;
							item2.z = 0f;
							attachmentVerts3.Add(item2);
							num34 = 0;
						}
						num35 += 2;
						flag7 = num33 != num35;
						num5 = num34;
					}
					while (flag7);
				}
			}
			float[] uVs = meshAttachment.UVs;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @BF7EB8 (inside CodeStage.AntiCheat.Common.ContainerHolder::.ctor +0x8)");
			List<Vector2> attachmentUVs = AttachmentUVs;
			int version4 = attachmentUVs._version + 1;
			attachmentUVs._size = 0;
			attachmentUVs._version = version4;
			List<Color32> attachmentColors = AttachmentColors32;
			int version5 = attachmentColors._version + 1;
			attachmentColors._size = 0;
			attachmentColors._version = version5;
			bool flag8 = meshAttachment.WorldVerticesLength < 2;
			MeshAttachment meshAttachment2 = meshAttachment;
			if (!flag8)
			{
				object obj4 = default(object);
				int num38 = (int)((nint)obj4 & 0xFFFFFFFFL);
				int num39 = num4 << 1;
				int num40 = 0;
				int num43 = default(int);
				Vector2 item3 = default(Vector2);
				do
				{
					int num41 = num40 << 2;
					object obj5 = (nint)meshAttachment.UVs + num41;
					List<Vector2> attachmentUVs2 = AttachmentUVs;
					Vector2[] items4 = attachmentUVs2._items;
					int version6 = attachmentUVs2._version + 1;
					attachmentUVs2._version = version6;
					if (attachmentUVs2.Count < items4.Length)
					{
						int size3 = attachmentUVs2.Count + 1;
						int num42 = attachmentUVs2.Count << 3;
						object obj6 = (nint)items4 + num42;
						attachmentUVs2._size = size3;
						_ = uVs[num40];
						ref Vector2 reference2 = ref items4[num43];
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1106 @ X8_v34+24]");
						reference2.y = 0f;
					}
					else
					{
						item3.x = uVs[num40];
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1106 @ X8_v34+24]");
						item3.y = 0f;
						attachmentUVs2.Add(item3);
					}
					List<Color32> attachmentColors2 = AttachmentColors32;
					Color32[] items5 = attachmentColors2._items;
					int version7 = attachmentColors2._version + 1;
					attachmentColors2._version = version7;
					if (attachmentColors2.Count < items5.Length)
					{
						int size4 = attachmentColors2.Count + 1;
						int num44 = attachmentColors2.Count << 2;
						object obj7 = (nint)items5 + num44;
						attachmentColors2._size = size4;
					}
					else
					{
						attachmentColors2.Add((Color32)num38);
					}
					num40 += 2;
				}
				while (num39 != num40);
				meshAttachment2 = meshAttachment;
			}
			List<int> attachmentIndices = AttachmentIndices;
			int version8 = attachmentIndices._version + 1;
			attachmentIndices._size = 0;
			attachmentIndices._version = version8;
			attachmentIndices.AddRange(meshAttachment2.Triangles);
			mesh.Clear();
			mesh.name = meshAttachment2.Name;
			mesh.SetVertices(AttachmentVerts);
			mesh.SetUVs(0, AttachmentUVs);
			mesh.SetColors(AttachmentColors32);
			mesh.SetTriangles(AttachmentIndices, 0);
			mesh.RecalculateBounds();
			List<Vector3> attachmentVerts4 = AttachmentVerts;
			int version9 = attachmentVerts4._version + 1;
			attachmentVerts4._size = 0;
			attachmentVerts4._version = version9;
			List<Vector2> attachmentUVs3 = AttachmentUVs;
			int version10 = attachmentUVs3._version + 1;
			attachmentUVs3._size = 0;
			attachmentUVs3._version = version10;
			List<Color32> attachmentColors3 = AttachmentColors32;
			int version11 = attachmentColors3._version + 1;
			attachmentColors3._size = 0;
			attachmentColors3._version = version11;
			List<int> attachmentIndices2 = AttachmentIndices;
			int version12 = attachmentIndices2._version + 1;
			attachmentIndices2._size = 0;
			attachmentIndices2._version = version12;
		}

		[Token(Token = "0x600068B")]
		[Address(RVA = "0x156F7E0", Offset = "0x156F7E0", Length = "0x17C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0042;\n\tv46 = Il2CppMethodInfo;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv71 = Il2CppMethodInfo;\n\tv72 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv76 = Il2CppMethodInfo;\n\tv77 = \"il2cpp_codegen_initialize_runtime_metadata\"(v76, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv83 = Il2CppMethodInfo;\n\tv84 = \"il2cpp_codegen_initialize_runtime_metadata\"(v83, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv88 = System.Collections.Generic.List`1<System.Int32>;\n\tv89 = \"il2cpp_codegen_initialize_runtime_metadata\"(v88, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv95 = System.Collections.Generic.List`1<UnityEngine.Color32>;\n\tv96 = \"il2cpp_codegen_initialize_runtime_metadata\"(v95, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv100 = System.Collections.Generic.List`1<UnityEngine.Vector3>;\n\tv101 = \"il2cpp_codegen_initialize_runtime_metadata\"(v100, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv107 = System.Collections.Generic.List`1<UnityEngine.Vector2>;\n\tv108 = \"il2cpp_codegen_initialize_runtime_metadata\"(v107, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv112 = Spine.Unity.MeshGenerator;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v112, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv67 = 1;\n\t*([1A37CCE]) = v67;\nL_0042:\n\tv69 = new System.Collections.Generic.List`1<UnityEngine.Vector3>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::.ctor(v69);\n\tv79.AttachmentVerts = v69;\n\tv81 = new System.Collections.Generic.List`1<UnityEngine.Vector2>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector2>::.ctor(v81);\n\tv91.AttachmentUVs = v81;\n\tv93 = new System.Collections.Generic.List`1<UnityEngine.Color32>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Color32>::.ctor(v93);\n\tv103.AttachmentColors32 = v93;\n\tv105 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v105);\n\tv120.AttachmentIndices = v105;\n\treturn;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static MeshGenerator()
		{
			List<Vector3> attachmentVerts = new List<Vector3>();
			AttachmentVerts = attachmentVerts;
			List<Vector2> attachmentUVs = new List<Vector2>();
			AttachmentUVs = attachmentUVs;
			List<Color32> attachmentColors = new List<Color32>();
			AttachmentColors32 = attachmentColors;
			List<int> attachmentIndices = new List<int>();
			AttachmentIndices = attachmentIndices;
		}
	}
}
