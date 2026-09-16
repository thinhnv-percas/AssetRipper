using System;
using System.Collections;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine
{
	[Token(Token = "0x200004E")]
	public class PathConstraint : IUpdatable
	{
		[Token(Token = "0x40001D7")]
		private const int NONE = -1;

		[Token(Token = "0x40001D8")]
		private const int BEFORE = -2;

		[Token(Token = "0x40001D9")]
		private const int AFTER = -3;

		[Token(Token = "0x40001DA")]
		private const float Epsilon = 1E-05f;

		[Token(Token = "0x40001DB")]
		[FieldOffset(Offset = "0x10")]
		internal PathConstraintData data;

		[Token(Token = "0x40001DC")]
		[FieldOffset(Offset = "0x18")]
		internal ExposedList<Bone> bones;

		[Token(Token = "0x40001DD")]
		[FieldOffset(Offset = "0x20")]
		internal Slot target;

		[Token(Token = "0x40001DE")]
		[FieldOffset(Offset = "0x28")]
		internal float position;

		[Token(Token = "0x40001DF")]
		[FieldOffset(Offset = "0x2C")]
		internal float spacing;

		[Token(Token = "0x40001E0")]
		[FieldOffset(Offset = "0x30")]
		internal float rotateMix;

		[Token(Token = "0x40001E1")]
		[FieldOffset(Offset = "0x34")]
		internal float translateMix;

		[Token(Token = "0x40001E2")]
		[FieldOffset(Offset = "0x38")]
		internal bool active;

		[Token(Token = "0x40001E3")]
		[FieldOffset(Offset = "0x40")]
		internal ExposedList<float> spaces;

		[Token(Token = "0x40001E4")]
		[FieldOffset(Offset = "0x48")]
		internal ExposedList<float> positions;

		[Token(Token = "0x40001E5")]
		[FieldOffset(Offset = "0x50")]
		internal ExposedList<float> world;

		[Token(Token = "0x40001E6")]
		[FieldOffset(Offset = "0x58")]
		internal ExposedList<float> curves;

		[Token(Token = "0x40001E7")]
		[FieldOffset(Offset = "0x60")]
		internal ExposedList<float> lengths;

		[Token(Token = "0x40001E8")]
		[FieldOffset(Offset = "0x68")]
		internal float[] segments;

		[Token(Token = "0x170000EB")]
		public float Position
		{
			[Token(Token = "0x6000303")]
			[Address(RVA = "0x1535854", Offset = "0x1535854", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.position;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Position;
			}
			[Token(Token = "0x6000304")]
			[Address(RVA = "0x153585C", Offset = "0x153585C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.position = value;\n\treturn;\n")]
			set
			{
				Position = value;
			}
		}

		[Token(Token = "0x170000EC")]
		public float Spacing
		{
			[Token(Token = "0x6000305")]
			[Address(RVA = "0x1535864", Offset = "0x1535864", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.spacing;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Spacing;
			}
			[Token(Token = "0x6000306")]
			[Address(RVA = "0x153586C", Offset = "0x153586C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.spacing = value;\n\treturn;\n")]
			set
			{
				Spacing = value;
			}
		}

		[Token(Token = "0x170000ED")]
		public float RotateMix
		{
			[Token(Token = "0x6000307")]
			[Address(RVA = "0x1535874", Offset = "0x1535874", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.rotateMix;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RotateMix;
			}
			[Token(Token = "0x6000308")]
			[Address(RVA = "0x153587C", Offset = "0x153587C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.rotateMix = value;\n\treturn;\n")]
			set
			{
				RotateMix = value;
			}
		}

		[Token(Token = "0x170000EE")]
		public float TranslateMix
		{
			[Token(Token = "0x6000309")]
			[Address(RVA = "0x1535884", Offset = "0x1535884", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.translateMix;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return TranslateMix;
			}
			[Token(Token = "0x600030A")]
			[Address(RVA = "0x153588C", Offset = "0x153588C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.translateMix = value;\n\treturn;\n")]
			set
			{
				TranslateMix = value;
			}
		}

		[Token(Token = "0x170000EF")]
		public ExposedList<Bone> Bones
		{
			[Token(Token = "0x600030B")]
			[Address(RVA = "0x1535894", Offset = "0x1535894", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.bones;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Bones;
			}
		}

		[Token(Token = "0x170000F0")]
		public Slot Target
		{
			[Token(Token = "0x600030C")]
			[Address(RVA = "0x153589C", Offset = "0x153589C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.target;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Target;
			}
			[Token(Token = "0x600030D")]
			[Address(RVA = "0x15358A4", Offset = "0x15358A4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.target = value;\n\treturn;\n")]
			set
			{
				Target = value;
			}
		}

		[Token(Token = "0x170000F1")]
		public bool Active
		{
			[Token(Token = "0x600030E")]
			[Address(RVA = "0x15358AC", Offset = "0x15358AC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.active;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Active;
			}
		}

		[Token(Token = "0x170000F2")]
		public PathConstraintData Data
		{
			[Token(Token = "0x600030F")]
			[Address(RVA = "0x15358B4", Offset = "0x15358B4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.data;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Data;
			}
		}

		[Token(Token = "0x60002FB")]
		[Address(RVA = "0x1533634", Offset = "0x1533634", Length = "0x368")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0039;\n\tv34 = Il2CppMethodInfo;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, data, skeleton, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv59 = Il2CppMethodInfo;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, data, skeleton, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv64 = Il2CppMethodInfo;\n\tv65 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, data, skeleton, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv69 = Il2CppMethodInfo;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, data, skeleton, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv74 = Il2CppMethodInfo;\n\tv75 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, data, skeleton, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv79 = Il2CppMethodInfo;\n\tv80 = \"il2cpp_codegen_initialize_runtime_metadata\"(v79, data, skeleton, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv84 = Il2CppMethodInfo;\n\tv85 = \"il2cpp_codegen_initialize_runtime_metadata\"(v84, data, skeleton, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv89 = Spine.ExposedList`1<Spine.Bone>;\n\tv90 = \"il2cpp_codegen_initialize_runtime_metadata\"(v89, data, skeleton, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv94 = Spine.ExposedList`1<System.Single>;\n\tv95 = \"il2cpp_codegen_initialize_runtime_metadata\"(v94, data, skeleton, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv99 = System.Single[];\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v99, data, skeleton, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv52 = 1;\n\t*([1A37B6B]) = v52;\nL_0039:\n\tv54 = 0;\n\tv57 = new Spine.ExposedList`1<System.Single>();\n\tSpine.ExposedList`1<System.Single>::.ctor(v57);\n\tthis.spaces = v57;\n\tv67 = new Spine.ExposedList`1<System.Single>();\n\tSpine.ExposedList`1<System.Single>::.ctor(v67);\n\tthis.positions = v67;\n\tv77 = new Spine.ExposedList`1<System.Single>();\n\tSpine.ExposedList`1<System.Single>::.ctor(v77);\n\tthis.world = v77;\n\tv87 = new Spine.ExposedList`1<System.Single>();\n\tSpine.ExposedList`1<System.Single>::.ctor(v87);\n\tthis.curves = v87;\n\tv97 = new Spine.ExposedList`1<System.Single>();\n\tSpine.ExposedList`1<System.Single>::.ctor(v97);\n\tthis.lengths = v97;\n\t// 91 NewArr v104 @ X0_v13 (System.Single[]), typeof(System.Single[]), 10\n\tthis.segments = v104;\n\tSystem.Object::.ctor(this);\n\tv107 = data == 0;\n\tif (v107) goto L_00B2;\n\tv108 = skeleton == 0;\n\tif (v108) goto L_00BE;\n\tthis.data = data;\n\tv169 = data.bones;\n\tv181 = new Spine.ExposedList`1<Spine.Bone>();\n\tSpine.ExposedList`1<Spine.Bone>::.ctor(v181, v169.Count);\n\tthis.bones = v181;\n\tv266 = Spine.ExposedList`1<Spine.BoneData>::GetEnumerator(data.bones);\nL_0084:\n\tv283 = Spine.ExposedList`1<System.Object>+Enumerator<System.Object>::MoveNext(&v54 @ stack_-58_v1 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv288 = v283 == 0;\n\tif (v288) goto L_0098;\n\tv209 = 0;\n\tv297 = Spine.Skeleton::FindBone(skeleton, *([v209 @ X8_v16 (System.Int32)+18]));\n\tSpine.ExposedList`1<Spine.Bone>::Add(this.bones, v297);\n\tgoto L_0084;\nL_0098:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v54 @ stack_-58_v1 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\nL_0099:\n\tv210 = data.target;\n\tv319 = Spine.Skeleton::FindSlot(skeleton, *([v210 @ X8_v10+18]));\n\t*([this @ X0 (Spine.PathConstraint)+20]) = v319;\n\tdata.position = data.position;\n\treturn;\n\tv298 = new System.NullReferenceException();\n\tv201 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_00B2:\n\tv174 = new System.ArgumentNullException();\n\tgoto L_00CB;\nL_00BE:\n\tv220 = new System.ArgumentNullException();\nL_00CB:\n\tSystem.ArgumentNullException::.ctor(v251, v252, v249);\n\tthrow v251;\n\tgoto L_00DE;\n\tgoto L_00DE;\nL_00DE:\n\tv300 = Il2CppMethodInfo != 1;\n\tif (v300) goto L_00ED;\n\tv320 = 0x1854E70(v291, Il2CppMethodInfo, v249, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv314 = *([v320 @ X0_v31]);\n\tv338 = 0x1854E80(v320, Il2CppMethodInfo, v249, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv309 = *([v254 @ X23_v3 (Il2CppClass<System.Single[]>)]);\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v54 @ stack_-58_v1 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>), v309);\n\tv312 = v314 == 0;\n\tif (v312) goto L_0099;\n\tv324 = new System.OutOfMemoryException();\nL_00ED:\n\tgoto L_00EF;\n\tX19 = X0;\nL_00EF:\n\tv339 = *([v254 @ X23_v3 (Il2CppClass<System.Single[]>)]);\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v54 @ stack_-58_v1 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>), v339);\n\tif (-2) goto L_00F9;\n\tv373 = 0xBD3CD0(v323, v339, v249, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_00F9:\n\tv376 = new System.OutOfMemoryException();\n\tv358 = 0x9DACB4(v376, v339, v249, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\treturn;\n// 158 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PathConstraint(PathConstraintData data, Skeleton skeleton)
		{
			//IL_00e1: Expected O, but got I4
			//IL_019b: Expected O, but got I
			//IL_01b5: Expected O, but got I
			//IL_015f: Expected O, but got I
			base._002Ector();
			ExposedList<object>.Enumerator enumerator = default(ExposedList<object>.Enumerator);
			ExposedList<float> exposedList = new ExposedList<float>();
			spaces = exposedList;
			ExposedList<float> exposedList2 = new ExposedList<float>();
			positions = exposedList2;
			ExposedList<float> exposedList3 = new ExposedList<float>();
			world = exposedList3;
			ExposedList<float> exposedList4 = new ExposedList<float>();
			curves = exposedList4;
			ExposedList<float> exposedList5 = new ExposedList<float>();
			lengths = exposedList5;
			float[] array = new float[10];
			segments = array;
			ArgumentNullException ex2;
			if (data != null)
			{
				if (skeleton != null)
				{
					this.data = data;
					ExposedList<BoneData> exposedList6 = data.Bones;
					ExposedList<Bone> exposedList7 = new ExposedList<Bone>((IEnumerable<Bone>)exposedList6.Count);
					bones = exposedList7;
					ExposedList<BoneData>.Enumerator enumerator2 = data.Bones.GetEnumerator();
					while (enumerator.MoveNext())
					{
						int num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ X8_v16 (System.Int32)+18]");
						Bone item = skeleton.FindBone((string)0);
						Bones.Add(item);
					}
					enumerator.Dispose();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [data @ X1 (Spine.PathConstraintData)+28]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ X8_v10+18]");
					Slot slot = skeleton.FindSlot((string)0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [data @ X1 (Spine.PathConstraintData)+40]");
					_ = 0;
					return;
				}
				ArgumentNullException ex = new ArgumentNullException();
				string text = "skeleton cannot be null.";
				ex2 = ex;
				string text2 = "skeleton";
			}
			else
			{
				ArgumentNullException ex3 = new ArgumentNullException();
				string text = "data cannot be null.";
				ex2 = ex3;
				string text2 = "data";
			}
			throw ex2;
		}

		[Token(Token = "0x60002FC")]
		[Address(RVA = "0x1533A8C", Offset = "0x1533A8C", Length = "0x3B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003C;\n\tv34 = Il2CppMethodInfo;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, constraint, skeleton, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv59 = Il2CppMethodInfo;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, constraint, skeleton, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv64 = Il2CppMethodInfo;\n\tv65 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, constraint, skeleton, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv69 = Il2CppMethodInfo;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, constraint, skeleton, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv74 = Il2CppMethodInfo;\n\tv75 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, constraint, skeleton, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv79 = Il2CppMethodInfo;\n\tv80 = \"il2cpp_codegen_initialize_runtime_metadata\"(v79, constraint, skeleton, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv84 = Il2CppMethodInfo;\n\tv85 = \"il2cpp_codegen_initialize_runtime_metadata\"(v84, constraint, skeleton, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv89 = Spine.ExposedList`1<Spine.Bone>;\n\tv90 = \"il2cpp_codegen_initialize_runtime_metadata\"(v89, constraint, skeleton, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv94 = Spine.ExposedList`1<System.Single>;\n\tv95 = \"il2cpp_codegen_initialize_runtime_metadata\"(v94, constraint, skeleton, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv99 = System.Single[];\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v99, constraint, skeleton, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv52 = 1;\n\t*([1A37B6C]) = v52;\nL_003C:\n\tv57 = new Spine.ExposedList`1<System.Single>();\n\tSpine.ExposedList`1<System.Single>::.ctor(v57);\n\tthis.spaces = v57;\n\tv67 = new Spine.ExposedList`1<System.Single>();\n\tSpine.ExposedList`1<System.Single>::.ctor(v67);\n\tthis.positions = v67;\n\tv77 = new Spine.ExposedList`1<System.Single>();\n\tSpine.ExposedList`1<System.Single>::.ctor(v77);\n\tthis.world = v77;\n\tv87 = new Spine.ExposedList`1<System.Single>();\n\tSpine.ExposedList`1<System.Single>::.ctor(v87);\n\tthis.curves = v87;\n\tv97 = new Spine.ExposedList`1<System.Single>();\n\tSpine.ExposedList`1<System.Single>::.ctor(v97);\n\tthis.lengths = v97;\n\t// 91 NewArr v104 @ X0_v13 (System.Single[]), typeof(System.Single[]), 10\n\tthis.segments = v104;\n\tSystem.Object::.ctor(this);\n\tv107 = constraint == 0;\n\tif (v107) goto L_00E3;\n\tv108 = skeleton == 0;\n\tif (v108) goto L_00EB;\n\tthis.data = constraint.data;\n\tv176 = constraint.bones;\n\tv188 = new Spine.ExposedList`1<Spine.Bone>();\n\tSpine.ExposedList`1<Spine.Bone>::.ctor(v188, v176.Count);\n\tthis.bones = v188;\n\tv292 = Spine.ExposedList`1<Spine.Bone>::GetEnumerator(constraint.bones);\nL_0089:\n\tv332 = Spine.ExposedList`1<System.Object>+Enumerator<System.Object>::MoveNext(&v216 @ stack_-78_v6 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv370 = v332 == 0;\n\tif (v370) goto L_00B0;\n\tv371 = skeleton.bones;\n\tv428 = *([v297 @ stack_-68+10]);\n\tv447 = v371.Items;\n\tv322 = *([v428 @ X9_v16+10]);\n\tSpine.ExposedList`1<Spine.Bone>::Add(this.bones, v447[v322 @ X9_v19]);\n\tgoto L_0089;\nL_00B0:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v216 @ stack_-78_v6 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\nL_00B1:\n\tv240 = skeleton.slots;\n\tv223 = constraint.target;\n\tv224 = v223.data;\n\tv241 = v240.Items;\n\tv359 = v224.index;\n\tv474 = v224.index < v241.Length;\n\tv350 = ~v474;\n\tif (v350) goto L_00FA;\n\tv363._data = v241[v359 @ X9_v8 (System.Int32)];\n\tv363._innerException = constraint.position;\n\treturn;\n\tv460 = new System.NullReferenceException();\n\tv463 = new System.NullReferenceException();\n\tv408 = new System.NullReferenceException();\n\tv413 = new System.NullReferenceException();\n\tv443 = new System.NullReferenceException();\n\tv229 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\nL_00E3:\n\tv181 = new System.ArgumentNullException();\n\tgoto L_00F3;\nL_00EB:\n\tv249 = new System.ArgumentNullException();\nL_00F3:\n\tSystem.ArgumentNullException::.ctor(v363, v274);\n\tthrow v363;\nL_00FA:\n\tv368 = new System.IndexOutOfRangeException();\n\tgoto L_010A;\n\tgoto L_010A;\n\tgoto L_010A;\n\tgoto L_010A;\n\tgoto L_010A;\n\tgoto L_010A;\nL_010A:\n\tv384 = v360 != 1;\n\tif (v384) goto L_0118;\n\tv420 = 0x1854E70(v368, v360, v357, methodInfo, v37, v38, v39, v40, v216, v42, v43, v44, v45, v46, v47, v48);\n\tv444 = 0x1854E80(v420, v360, v357, methodInfo, v37, v38, v39, v40, v216, v42, v43, v44, v45, v46, v47, v48);\n\tv360 = *([v365 @ X23_v4 (Il2CppClass<System.Single[]>)]);\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v145 @ stack_-60_v5 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv417 = *([v420 @ X0_v33]) == 0;\n\tif (v417) goto L_00B1;\n\tv423 = new System.OutOfMemoryException();\nL_0118:\n\tgoto L_011C;\n\tX19 = X0;\nL_011C:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v145 @ stack_-60_v5 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_0123;\n\tv470 = 0xBD3CD0(v368, *([v365 @ X23_v4 (Il2CppClass<System.Single[]>)]), v357, methodInfo, v37, v38, v39, v40, v216, v42, v43, v44, v45, v46, v47, v48);\nL_0123:\n\tv473 = new System.OutOfMemoryException();\n\tv476 = 0x9DACB4(v473, *([v365 @ X23_v4 (Il2CppClass<System.Single[]>)]), v357, methodInfo, v37, v38, v39, v40, v216, v42, v43, v44, v45, v46, v47, v48);\n\treturn;\n// 186 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PathConstraint(PathConstraint constraint, Skeleton skeleton)
		{
			//IL_02c6: Expected I, but got O
			//IL_02bc: Expected I, but got O
			//IL_00e6: Expected O, but got I4
			//IL_013e: Expected O, but got I
			//IL_0165: Expected O, but got I
			//IL_0260: Expected O, but got F4
			base._002Ector();
			ExposedList<float> exposedList = new ExposedList<float>();
			spaces = exposedList;
			ExposedList<float> exposedList2 = new ExposedList<float>();
			positions = exposedList2;
			ExposedList<float> exposedList3 = new ExposedList<float>();
			world = exposedList3;
			ExposedList<float> exposedList4 = new ExposedList<float>();
			curves = exposedList4;
			ExposedList<float> exposedList5 = new ExposedList<float>();
			lengths = exposedList5;
			float[] array = new float[10];
			segments = array;
			ArgumentNullException ex;
			nint num;
			nint num2;
			if (constraint != null)
			{
				ExposedList<object>.Enumerator enumerator3;
				nint num3;
				if (skeleton != null)
				{
					data = constraint.Data;
					ExposedList<Bone> exposedList6 = constraint.Bones;
					ExposedList<Bone> exposedList7 = new ExposedList<Bone>((IEnumerable<Bone>)exposedList6.Count);
					bones = exposedList7;
					ExposedList<Bone>.Enumerator enumerator = constraint.Bones.GetEnumerator();
					num = 0;
					ExposedList<object>.Enumerator enumerator2 = default(ExposedList<object>.Enumerator);
					while (enumerator2.MoveNext())
					{
						ExposedList<Bone> exposedList8 = skeleton.Bones;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ stack_-68+10]");
						object obj = 0;
						Bone[] items = exposedList8.Items;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v428 @ X9_v16+10]");
						object obj2 = 0;
						Bones.Add(items[obj2]);
						num = 0;
					}
					enumerator2.Dispose();
					enumerator3 = enumerator2;
					num2 = 0;
					ex = (ArgumentNullException)(object)this;
					num3 = 0;
					object obj3 = default(object);
					while (true)
					{
						ExposedList<Slot> slots = skeleton.Slots;
						Slot slot = constraint.Target;
						SlotData slotData = slot.Data;
						Slot[] items2 = slots.Items;
						int index = slotData.Index;
						if (slotData.Index < items2.Length)
						{
							((Exception)ex)._data = (IDictionary)items2[index];
							((Exception)ex)._innerException = (Exception)constraint.Position;
							return;
						}
						IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
						if (num2 == 1)
						{
							Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @1854E70 (native __cxa_begin_catch)");
							Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
							num2 = num3;
							enumerator3.Dispose();
							if (obj3 != null)
							{
								OutOfMemoryException ex3 = new OutOfMemoryException();
								ex2 = (IndexOutOfRangeException)(object)ex3;
								break;
							}
							continue;
						}
						break;
					}
					enumerator3.Dispose();
					OutOfMemoryException ex4 = new OutOfMemoryException();
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9DACB4");
					return;
				}
				ArgumentNullException ex5 = new ArgumentNullException();
				enumerator3 = default(ExposedList<object>.Enumerator);
				string text = "skeleton cannot be null.";
				ex = ex5;
				num3 = (nint)typeof(float[]);
			}
			else
			{
				ArgumentNullException ex6 = new ArgumentNullException();
				string text = "constraint cannot be null.";
				ex = ex6;
			}
			num = unchecked((nint)null);
			num2 = 0;
			throw ex;
		}

		[Token(Token = "0x60002FD")]
		[Address(RVA = "0x1533E3C", Offset = "0x1533E3C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.PathConstraint::Update(this);\n\treturn;\n")]
		public void Apply()
		{
			Update();
		}

		[Token(Token = "0x60002FE")]
		[Address(RVA = "0x1533E40", Offset = "0x1533E40", Length = "0x794")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv48 = Il2CppMethodInfo;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv72 = Spine.MathUtils;\n\tv73 = \"il2cpp_codegen_initialize_runtime_metadata\"(v72, methodInfo, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv485 = System.Math;\n\tv486 = \"il2cpp_codegen_initialize_runtime_metadata\"(v485, methodInfo, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv630 = Spine.PathAttachment;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v630, methodInfo, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv68 = 1;\n\t*([1A37B6D]) = v68;\nL_002A:\n\tv69 = this.target;\n\tv75 = v69.attachment == 0;\n\tif (v75) goto L_03FA;\n\tgoto L_FFFFFFFF;\n\tv249 = v249_asT == 0;\n\tif (v249) goto L_FFFFFFFF;\n\tgoto L_0054;\nL_0054:\n\tv603 = v245 == 0;\n\tif (v603) goto L_03FA;\n\tv711 = this.rotateMix > 0;\n\tif (v711) goto L_0072;\n\tv560 = this.translateMix <= 0;\n\tif (v560) goto L_03FA;\nL_0072:\n\tv229 = this.data;\n\tv469 = this.bones;\n\tv354 = v229.rotateMode == 0;\n\tv274 = ~v354;\n\tv248 = ~v274;\n\tif (v248) goto L_FFFFFFFF;\n\tv223 = v469.Count + 1;\n\tgoto L_008F;\nL_008F:\n\tv210 = v469.Items;\n\tv437 = Spine.ExposedList`1<System.Single>::Resize(this.spaces, v223);\n\tv723 = v229.rotateMode == 2;\n\tif (v723) goto L_00E4;\n\tv737 = v229.spacingMode != 2;\n\tif (v737) goto L_00E4;\n\tv262 = v223 < 2;\n\tif (v262) goto L_FFFFFFFF;\n\tv406 = v223 - 1;\n\tv418 = v437.Items + 0x24;\nL_00CC:\n\t*([v418 @ X10_v16+v470 @ X8_v46 (System.Int32)*4]) = this.spacing;\n\tv470 = v470 + 1;\n\tv754 = v406 != v470;\n\tif (v754) goto L_00CC;\n\tgoto L_020E;\nL_00E4:\n\tv264 = v229.rotateMode != 2;\n\tif (v264) goto L_FFFFFFFF;\n\tv439 = Spine.ExposedList`1<System.Single>::Resize(this.lengths, v469.Count);\n\tgoto L_00EF;\nL_00EF:\n\tv116 = v223 - 1;\n\tv265 = v116 < 1;\n\tif (v265) goto L_020E;\n\tv694 = Spine.ExposedList`1<System.Single>::Resize(v439, v207);\n\treturn;\n\tX8 = 0;\n\tstack[40] = X11;\nL_0107:\n\tX9 = *([X26+18]);\n\tC = X8 < X9;\n\tC = ~C;\n\tTEMP1 = X8 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X9;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_FFFFFFFF;\n\tX24 = X8;\n\tTEMPSHIFT = X24 << 3;\n\tX8 = X26 + TEMPSHIFT;\n\tX8 = *([X8+20]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX9 = *([X8+10]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tV10 = *([X9+28]);\n\tC = V10 < V9;\n\tC = ~C;\n\tTEMP1 = V10 - V9;\n\tN = TEMP1 < 0;\n\tTEMP2 = V10 ^ V9;\n\tTEMP3 = V10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~N;\n\tif (TEMPCOND) goto L_0158;\n\tC = X25 < 2;\n\tC = ~C;\n\tTEMP1 = X25 - 2;\n\tN = TEMP1 < 0;\n\tTEMP2 = X25 ^ 2;\n\tTEMP3 = X25 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0145;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([X21+10]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX9 = *([X8+18]);\n\tC = X24 < X9;\n\tC = ~C;\n\tTEMP1 = X24 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X24 ^ X9;\n\tTEMP3 = X24 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_FFFFFFFF;\n\tTEMPSHIFT = X24 << 2;\n\tX8 = X8 + TEMPSHIFT;\n\t*([X8+20]) = 0;\nL_0145:\n\tTEMP = X20 == 0;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX9 = *([X20+10]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX10 = *([X9+18]);\n\tX8 = X24 + 1;\n\tC = X8 < X10;\n\tC = ~C;\n\tTEMP1 = X8 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X10;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_FFFFFFFF;\n\tV0 = 0;\n\tgoto L_01A4;\nL_0158:\n\tC = X28 < 2;\n\tC = ~C;\n\tTEMP1 = X28 - 2;\n\tN = TEMP1 < 0;\n\tTEMP2 = X28 ^ 2;\n\tTEMP3 = X28 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_01A7;\n\tC = X25 < 2;\n\tC = ~C;\n\tTEMP1 = X25 - 2;\n\tN = TEMP1 < 0;\n\tTEMP2 = X25 ^ 2;\n\tTEMP3 = X25 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0192;\n\tX0 = *([1935000]);\n\tV11 = *([X8+6C]);\n\tV14 = *([X8+78]);\n\tX9 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0179;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX12 = *([19355D8]);\n\tX11 = stack[40];\nL_0179:\n\tTEMP = X21 == 0;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([X21+10]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX9 = *([X8+18]);\n\tC = X24 < X9;\n\tC = ~C;\n\tTEMP1 = X24 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X24 ^ X9;\n\tTEMP3 = X24 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_FFFFFFFF;\n\tV0 = V10 * V14;\n\tV1 = V10 * V11;\n\tV1 = V1 * V1;\n\tV0 = V0 * V0;\n\tV0 = V1 + V0;\n\tV0 = UnityEngine.Mathf::Sqrt(V0);\n\tTEMPSHIFT = X24 << 2;\n\tX8 = X8 + TEMPSHIFT;\n\t*([X8+20]) = V0;\nL_0192:\n\tTEMP = X20 == 0;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX9 = *([X20+10]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX10 = *([X9+18]);\n\tX8 = X24 + 1;\n\tV0 = V8;\n\tC = X8 < X10;\n\tC = ~C;\n\tTEMP1 = X8 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X10;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_FFFFFFFF;\nL_01A4:\n\tTEMPSHIFT = X8 << 2;\n\tX9 = X9 + TEMPSHIFT;\n\tgoto L_01FB;\nL_01A7:\n\tX0 = *([X12]);\n\tV11 = *([X8+6C]);\n\tV14 = *([X8+78]);\n\tX9 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_01B2;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX12 = *([19355D8]);\n\tX11 = stack[40];\nL_01B2:\n\tV0 = V10 * V14;\n\tV1 = V10 * V11;\n\tV1 = V1 * V1;\n\tV0 = V0 * V0;\n\tV0 = V1 + V0;\n\tC = X25 < 2;\n\tC = ~C;\n\tTEMP1 = X25 - 2;\n\tN = TEMP1 < 0;\n\tTEMP2 = X25 ^ 2;\n\tTEMP3 = X25 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tV0 = UnityEngine.Mathf::Sqrt(V0);\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_01D6;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([X21+10]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX9 = *([X8+18]);\n\tC = X24 < X9;\n\tC = ~C;\n\tTEMP1 = X24 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X24 ^ X9;\n\tTEMP3 = X24 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_FFFFFFFF;\n\tTEMPSHIFT = X24 << 2;\n\tX8 = X8 + TEMPSHIFT;\n\t*([X8+20]) = V0;\nL_01D6:\n\tTEMP = X20 == 0;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX9 = *([X20+10]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX10 = *([X9+18]);\n\tX8 = X24 + 1;\n\tC = X8 < X10;\n\tC = ~C;\n\tTEMP1 = X8 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X10;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_FFFFFFFF;\n\tV1 = V8 + V10;\n\tC = X11 < 0;\n\tC = ~C;\n\tTEMP1 = X11 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = X11 ^ 0;\n\tTEMP3 = X11 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCSEL = ~Z;\n\tif (TEMPCSEL) goto L_01F5;\n\tV1 = V1;\n\tgoto L_01F6;\nL_01F5:\n\tV1 = V8;\nL_01F6:\n\t;\n\tV0 = V1 * V0;\n\tTEMPSHIFT = X8 << 2;\n\tX9 = X9 + TEMPSHIFT;\n\tV0 = V0 / V10;\nL_01FB:\n\tC = X8 < X29;\n\tC = ~C;\n\tTEMP1 = X8 - X29;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X29;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\t*([X9+20]) = V0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_0107;\nL_020E:\n\tv807 = v229.rotateMode == 0;\n\tv814 = v229.spacingMode - 2;\n\tv816 = v814 == 0;\n\tv378 = v229.positionMode - 1;\n\tv346 = v378 == 0;\n\tv440 = Spine.PathConstraint::ComputeWorldPositions(this, v245, v223, v807, v346, v816);\n\tv173 = v440[0];\n\tv167 = v440[1];\n\tv267 = v229.offsetRotation != 0;\n\tif (v267) goto L_0256;\n\tv914 = v229.rotateMode - 1;\n\tv916 = v914 == 0;\n\tgoto L_0281;\nL_0256:\n\tv472 = this.target;\n\tv473 = v472.bone;\n\tv946 = 0x407000 + 0x6A0;\n\tv954 = v473.a * v473.d;\n\tv955 = v473.b * v473.c;\n\tv956 = v954 - v955;\n\tv941 = v956 < 0;\n\tv939 = v956 == 0;\n\tv935 = v956 ^ v956;\n\tv933 = v956 & v935;\n\tv931 = v933 < 0;\n\tv958 = v941 == v931;\n\tv927 = ~v939;\n\tv929 = v958 & v927;\n\tv924 = v229.offsetRotation * *([v946 @ X9_v25 (System.Int32)+v929 @ TEMPCOND_v33 (System.Boolean)*4]);\nL_0281:\n\tv268 = v469.Count < 1;\n\tif (v268) goto L_03FA;\nL_02A6:\n\tv230 = v210[v906 @ X8_v13 (System.Int32)];\n\tv907 = v224 - 2;\n\tv985 = v173 - v230.worldX;\n\tv986 = v167 - v230.worldY;\n\tv147 = v1040 * v985;\n\tv152 = v1040 * v986;\n\tv181 = v230.worldX + v147;\n\tv157 = v230.worldY + v152;\n\tv230.worldX = v181;\n\tv230.worldY = v157;\n\tv431 = v224 - 1;\n\tv198 = v440[v907 @ X8_v15 (System.Int32)] - v173;\n\tv186 = v440[v431 @ X9_v16 (System.Int32)] - v167;\n\tv270 = v229.rotateMode != 2;\n\tif (v270) goto L_0320;\n\tv477 = v219.Items;\n\tv1001 = v477[v906 @ X8_v13 (System.Int32)] < 1E-05f;\n\tif (v1001) goto L_0320;\n\tgoto L_0305;\n\tv1093 = \"il2cpp_codegen_runtime_class_init\"(v1072, v208, v203, v84, v78, v81, v55, v56, v167, v173, v181, v157, v147, v152, v63, v64);\nL_0305:\n\tv1094 = v198 * v198;\n\tv1095 = v186 * v186;\n\tv1096 = v1094 + v1095;\n\n// ... truncated")]
		public void Update()
		{
			//IL_01e2: Expected O, but got I
			//IL_03da: Expected I4, but got F4
			//IL_03e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e7: Expected I4, but got Unknown
			Slot slot = Target;
			if (slot.Attachment == null)
			{
				return;
			}
			PathAttachment pathAttachment = slot.Attachment as PathAttachment;
			PathAttachment pathAttachment2 = (PathAttachment)((pathAttachment == null) ? null : slot.Attachment);
			if (pathAttachment2 == null || (!(RotateMix > 0f) && !(TranslateMix > 0f)))
			{
				return;
			}
			PathConstraintData pathConstraintData = Data;
			ExposedList<Bone> exposedList = Bones;
			int num = ((pathConstraintData.RotateMode == RotateMode.Tangent) ? exposedList.Count : (exposedList.Count + 1));
			Bone[] items = exposedList.Items;
			ExposedList<float> exposedList2 = spaces.Resize(num);
			ExposedList<float> exposedList3;
			if (pathConstraintData.RotateMode != RotateMode.ChainScale && pathConstraintData.SpacingMode == SpacingMode.Percent)
			{
				if (num >= 2)
				{
					int num2 = num - 1;
					object obj = (nint)exposedList2.Items + 36;
					int num3 = 0;
					do
					{
						_ = Spacing;
						num3++;
					}
					while (num2 != num3);
				}
				exposedList3 = null;
			}
			else
			{
				ExposedList<float> exposedList4;
				int newSize;
				if (pathConstraintData.RotateMode == RotateMode.ChainScale)
				{
					exposedList4 = lengths.Resize(exposedList.Count);
					newSize = exposedList.Count;
					exposedList3 = exposedList4;
				}
				else
				{
					newSize = num;
					exposedList3 = null;
					exposedList4 = exposedList2;
				}
				int num4 = num - 1;
				if (num4 >= 1)
				{
					ExposedList<float> exposedList5 = exposedList4.Resize(newSize);
					return;
				}
			}
			bool tangents = pathConstraintData.RotateMode == RotateMode.Tangent;
			int num5 = (int)(pathConstraintData.SpacingMode - 2);
			bool percentSpacing = num5 == 0;
			int num6 = (int)(pathConstraintData.PositionMode - 1);
			bool percentPosition = num6 == 0;
			float[] array = ComputeWorldPositions(pathAttachment2, num, tangents, percentPosition, percentSpacing);
			float num7 = array[0];
			float num8 = array[1];
			float num10;
			bool flag2;
			if (pathConstraintData.OffsetRotation == 0f)
			{
				int num9 = (int)(pathConstraintData.RotateMode - 1);
				bool flag = num9 == 0;
				num10 = pathConstraintData.OffsetRotation;
				flag2 = flag;
			}
			else
			{
				Slot slot2 = Target;
				Bone bone = slot2.Bone;
				int num11 = 4222976 + 1696;
				float num12 = bone.A * bone.D;
				float num13 = bone.B * bone.C;
				float num14 = num12 - num13;
				bool flag3 = num14 < 0f;
				bool flag4 = num14 == 0f;
				int num15 = num14 ^ num14;
				int num16 = num14 & num15;
				bool flag5 = num16 < 0;
				bool flag6 = flag3 == flag5;
				bool flag7 = !flag4;
				bool flag8 = flag6 && flag7;
				float num17 = pathConstraintData.OffsetRotation;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v946 @ X9_v25 (System.Int32)+v929 @ TEMPCOND_v33 (System.Boolean)*4]");
				float num18 = num17 * 0f;
				num10 = num18;
				flag2 = false;
			}
			if (exposedList.Count < 1)
			{
				return;
			}
			int num19 = 5;
			float num20 = TranslateMix;
			int num21 = 0;
			bool flag10;
			object obj2 = default(object);
			object obj3 = default(object);
			do
			{
				Bone bone2 = items[num21];
				int num22 = num19 - 2;
				float num23 = num7 - bone2.WorldX;
				float num24 = num8 - bone2.WorldY;
				float num25 = num20 * num23;
				float num26 = num20 * num24;
				float worldX = bone2.WorldX + num25;
				float worldY = bone2.WorldY + num26;
				bone2.worldX = worldX;
				bone2.worldY = worldY;
				int num27 = num19 - 1;
				float num28 = array[num22] - num7;
				float num29 = array[num27] - num8;
				if (pathConstraintData.RotateMode == RotateMode.ChainScale)
				{
					float[] items2 = exposedList3.Items;
					if (!(items2[num21] < 1E-05f))
					{
						float num30 = num28 * num28;
						float num31 = num29 * num29;
						float f = num30 + num31;
						float num32 = Mathf.Sqrt(f);
						float num33 = num32 / items2[num21];
						float num34 = num33 + -1f;
						float num35 = RotateMix * num34;
						float num36 = num35 + 1f;
						float a = num36 * bone2.A;
						float c = num36 * bone2.C;
						bone2.a = a;
						bone2.c = c;
					}
				}
				bool flag9 = !(RotateMix > 0f);
				float num37 = array[num27];
				float num38 = array[num22];
				float num41;
				if (!flag9)
				{
					if (pathConstraintData.RotateMode != RotateMode.Tangent)
					{
						float[] items3 = exposedList2.Items;
						int num39 = num21 + 1;
						if (!(items3[num39] < 1E-05f))
						{
							float num40 = MathUtils.Atan2(num29, num28);
							num41 = num40;
							goto IL_0735;
						}
					}
					num41 = array[num19];
					goto IL_0735;
				}
				goto IL_0b80;
				IL_0b80:
				num21++;
				num19 += 3;
				bone2.appliedValid = false;
				flag10 = exposedList.Count != num21;
				num8 = num37;
				num7 = num38;
				continue;
				IL_0937:
				float num42;
				float radians = RotateMix * num42;
				float num43 = MathUtils.Cos(radians);
				float num44 = MathUtils.Sin(radians);
				float num45 = bone2.A * (float)obj2;
				float num46 = bone2.C * (float)obj3;
				float num47 = bone2.A * (float)obj3;
				float num48 = bone2.C * (float)obj2;
				float a2 = num45 - num46;
				float c2 = num48 + num47;
				bone2.a = a2;
				bone2.c = c2;
				goto IL_0b80;
				IL_0735:
				float num49 = MathUtils.Atan2(bone2.C, bone2.A);
				num42 = num41 - num49;
				if (flag2)
				{
					float num50 = MathUtils.Cos(num42);
					float num51 = MathUtils.Sin(num42);
					BoneData boneData = bone2.Data;
					float num52 = bone2.A * num50;
					float num53 = bone2.C * num51;
					float num54 = bone2.A * num51;
					float num55 = bone2.C * num50;
					float num56 = num52 - num53;
					float num57 = num55 + num54;
					float num58 = num56 * boneData.Length;
					float num59 = num57 * boneData.Length;
					float num60 = num58 - num28;
					float num61 = num59 - num29;
					float num62 = RotateMix * num60;
					float num63 = RotateMix * num61;
					num38 = array[num22] + num62;
					num37 = array[num27] + num63;
					num20 = TranslateMix;
				}
				else
				{
					num42 = num10 + num42;
					num37 = array[num27];
					num38 = array[num22];
				}
				float num64;
				if (num42 > (float)Math.PI)
				{
					num64 = (float)Math.PI * -2f;
				}
				else
				{
					if (!(num42 < -(float)Math.PI))
					{
						goto IL_0937;
					}
					num64 = (float)Math.PI * 2f;
				}
				num42 += num64;
				goto IL_0937;
			}
			while (flag10);
		}

		[Token(Token = "0x60002FF")]
		[Address(RVA = "0x15345D4", Offset = "0x15345D4", Length = "0xD98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv58 = Il2CppMethodInfo;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, path, spacesCount, tangents, percentPosition, percentSpacing, methodInfo, v61, v62, v63, v64, v65, v66, v67, v68, v69);\n\tv77 = System.Math;\n\tv71 = \"il2cpp_codegen_initialize_runtime_metadata\"(v77, path, spacesCount, tangents, percentPosition, percentSpacing, methodInfo, v61, v62, v63, v64, v65, v66, v67, v68, v69);\n\tv73 = 1;\n\t*([1A37B6E]) = v73;\nL_0029:\n\tv74 = this.spaces;\n\tv1602 = this.position;\n\tv594 = v74.Items;\n\tv574 = spacesCount << 1;\n\tv680 = spacesCount + v574;\n\tv563 = v680 + 2;\n\tv616 = Spine.ExposedList`1<System.Single>::Resize(this.positions, v563);\n\tv670 = path.worldVerticesLength;\n\tv1065 = path.worldVerticesLength * 0x2AAAAAAB;\n\tv523 = v1065 >> 0x3F;\n\tv681 = v1065 >> 0x20;\n\tv515 = v681 + v523;\n\tv1066 = ~path.constantSpeed;\n\tif (v1066) goto L_009B;\n\tv1067 = ~path.closed;\n\tif (v1067) goto L_0285;\n\tv554 = path.worldVerticesLength + 2;\n\tv618 = Spine.ExposedList`1<System.Single>::Resize(this.world, v554);\n\tv675 = v618.Items;\n\tv513 = path.worldVerticesLength - 2;\n\tSpine.VertexAttachment::ComputeWorldVertices(path, this.target, 2, v513, v618.Items, 0, 2);\n\tSpine.VertexAttachment::ComputeWorldVertices(path, this.target, 0, 2, v618.Items, v513, 2);\n\tv675[v670 @ X20_v5 (System.Int32)] = v675[0];\n\tv1574 = path.worldVerticesLength + 1;\n\tv675[v1574 @ X9_v58 (System.Int32)] = v675[1];\n\tgoto L_0299;\nL_009B:\n\tv696 = path.lengths;\n\tv434 = path.closed == 0;\n\tv342 = ~v434;\n\tv327 = ~v342;\n\tif (v327) goto L_FFFFFFFF;\n\tv319 = 0xFFFFFFFE + 1;\n\tgoto L_00B0;\nL_00B0:\n\tv311 = v319 + v515;\n\tv348 = v1602 * v696[v311 @ X13_v4 (System.Int32)];\n\tv1100 = v493 == 0;\n\tv1103 = ~v1100;\n\tv325 = ~v1103;\n\tif (v325) goto L_00D6;\n\tgoto L_00D6;\nL_00D6:\n\tv333 = spacesCount < 2;\n\tif (v333) goto L_0103;\n\tv1664 = v489 == 0;\n\tif (v1664) goto L_0103;\n\tv1561 = v594 + 0x24;\n\tv1170 = spacesCount - 1;\nL_00E2:\n\tv1130 = v1636 + 1;\n\tv1666 = v696[v311 @ X13_v4 (System.Int32)] * *([v1561 @ X10_v9+v1636 @ X8_v34 (System.Int32)*4]);\n\t*([v1561 @ X10_v9+v1636 @ X8_v34 (System.Int32)*4]) = v1666;\n\tv1665 = v1170 != v1130;\n\tif (v1665) goto L_00E2;\nL_0103:\n\tv1611 = Spine.ExposedList`1<System.Single>::Resize(this.world, 8);\n\tv335 = spacesCount < 1;\n\tif (v335) goto L_068E;\n\tv1720 = path.worldVerticesLength - 6;\n\tv1721 = path.worldVerticesLength - 4;\n\tv659 = v1611.Items;\n\tv1725 = v319 + v515;\nL_0132:\n\tv1602 = v1602 + v594[v612 @ X28_v8 (System.Int32)];\n\tv1630 = ~path.closed;\n\tif (v1630) goto L_01BC;\n\tv1832 = 0x1854EF0(v1611, v1590, v1599, v1553, v493, v489, v502, v61, v1602, v696[v311 @ X13_v4 (System.Int32)], v659[1], v659[2], v659[3], v659[4], v659[5], v659[6]);\n\tv1845 = v696[v311 @ X13_v4 (System.Int32)] + v1602;\n\tv1856 = v1602 >= 0;\n\tif (v1856) goto L_FFFFFFFF;\n\tgoto L_0156;\nL_0156:\n\tv1619 = v517 * 6;\n\tv1601 = 2 + v1619;\nL_0166:\n\tv1187 = v355 <= v696[v517 @ X26_v9 (System.Int32)];\n\tif (v1187) goto L_0176;\n\tv517 = v517 + 1;\n\tv2080 = v517 < v696.Length;\n\tv1514 = ~v2080;\n\tv1601 = v1601 + 6;\n\tv1186 = ~v1514;\n\tif (v1186) goto L_0166;\n\tgoto L_068F;\nL_0176:\n\tv1620 = v517 == 0;\n\tif (v1620) goto L_0188;\n\tv1578 = v517 - 1;\n\tv355 = v355 - v696[v1578 @ X9_v14 (System.Int32)];\n\tv248 = v696[v517 @ X26_v9 (System.Int32)] - v696[v1578 @ X9_v14 (System.Int32)];\nL_0188:\n\tv227 = v355 / v248;\n\tv2154 = v672 == v517;\n\tif (v2154) goto L_0252;\n\tv2211 = ~path.closed;\n\tif (v2211) goto L_01FD;\n\tv2213 = v1725 != v517;\n\tif (v2213) goto L_01FD;\n\tSpine.VertexAttachment::ComputeWorldVertices(path, this.target, v1721, 4, v659, 0, 2);\n\tSpine.VertexAttachment::ComputeWorldVertices(path, this.target, 0, 4, v659, 4, 2);\n\tgoto L_0252;\nL_01BC:\n\tv1842 = v1602 >= 0;\n\tif (v1842) goto L_01DF;\n\tv1857 = v672 + 2;\n\tv1859 = v1857 == 0;\n\tif (v1859) goto L_01D1;\n\tSpine.VertexAttachment::ComputeWorldVertices(path, this.target, 2, 4, v659, 0, 2);\nL_01D1:\n\tSpine.PathConstraint::AddBeforePosition(v1602, v659, 0, v616.Items, v677);\n\tgoto L_0271;\nL_01DF:\n\tv1873 = v1602 <= v696[v311 @ X13_v4 (System.Int32)];\n\tif (v1873) goto L_FFFFFFFF;\n\tv1915 = v672 + 3;\n\tv1917 = v1915 == 0;\n\tif (v1917) goto L_01F0;\n\tSpine.VertexAttachment::ComputeWorldVertices(path, this.target, v1720, 4, v659, 0, 2);\nL_01F0:\n\tv1967 = v1602 - v696[v311 @ X13_v4 (System.Int32)];\n\tSpine.PathConstraint::AddAfterPosition(v1967, v659, 0, v616.Items, v677);\n\tgoto L_0271;\nL_01FD:\n\tSpine.VertexAttachment::ComputeWorldVertices(path, this.target, v1601, 8, v659, 0, 2);\nL_0252:\n\tv2347 = tangents == 0;\n\tif (v2347) goto L_0256;\n\tgoto L_0270;\nL_0256:\n\tv2350 = v612 == 0;\n\tif (v2350) goto L_FFFFFFFF;\n\tv2359 = v594[v612 @ X28_v8 (System.Int32)] - 1E-05f;\n\tv2358 = v2359 < 0;\n\tgoto L_0270;\nL_0270:\n\tSpine.PathConstraint::AddCurvePosition(v227, v659[0], v659[1], v659[2], v659[3], v659[4], v659[5], v659[6], v659[7], v616.Items, v677, v2017);\nL_0271:\n\tv612 = v612 + 1;\n\tv677 = v677 + 3;\n\tv790 = v612 != spacesCount;\n\tif (v790) goto L_0132;\n\tgoto L_068E;\n\tgoto L_0156;\nL_0285:\n\tv554 = path.worldVerticesLength - 4;\n\tv623 = Spine.ExposedList`1<System.Single>::Resize(this.world, v554);\n\tv675 = v623.Items;\n\tv515 = v515 - 1;\n\tSpine.VertexAttachment::ComputeWorldVertices(path, this.target, 2, v554, v623.Items, 0, 2);\nL_0299:\n\tv615 = Spine.ExposedList`1<System.Single>::Resize(this.curves, v515);\n\tv605 = v615.Items;\n\tv226 = v675[0];\n\tv601 = v675[1];\n\tv1707 = v515 < 1;\n\tif (v1707) goto L_FFFFFFFF;\n\tv1735 = v515 << 1;\n\tv1736 = v515 + v1735;\n\tv555 = v1736 << 1;\nL_02DA:\n\tv1579 = v518 - 3;\n\tv1564 = v518 - 2;\n\tv1132 = v518 - 1;\n\tv301 = v518 + 1;\n\tv1972 = v518 - 4;\n\tgoto L_0343;\n\tv2023 = v1175;\n\tv2024 = v1604;\n\tv2025 = v1980;\n\tv2026 = v1138;\n\tv2027 = \"il2cpp_codegen_runtime_class_init\"(v1971, v569, v591, v497, v491, v487, v500, v61, v356, v249, v241, v149, v156, v143, v137, v131);\n\tv2029 = 0.75f;\n\tv2032 = v2026;\n\tv2030 = 3f;\n\tv2031 = 0.1875f;\n\tv2028 = v2025;\n\tv2034 = v2024;\n\tv2033 = v2023;\nL_0343:\n\tv2081 = v675[v1972 @ X8_v78 (System.Int32)] + v675[v1972 @ X8_v78 (System.Int32)];\n\tv2082 = v226 - v2081;\n\tv2083 = v675[v1972 @ X8_v78 (System.Int32)] - v675[v1564 @ X10_v31 (System.Int32)];\n\tv2084 = v2082 + v675[v1564 @ X10_v31 (System.Int32)];\n\tv2085 = v675[v1579 @ X9_v52 (System.Int32)] + v675[v1579 @ X9_v52 (System.Int32)];\n\tv2086 = v675[v1579 @ X9_v52 (System.Int32)] - v675[v1132 @ X12_v17 (System.Int32)];\n\tv2087 = v2083 * 3f;\n\tv2088 = v601 - v2085;\n\tv2089 = v2086 * 3f;\n\tv2090 = v2087 - v226;\n\tv2091 = v2088 + v675[v1132 @ X12_v17 (System.Int32)];\n\tv2092 = v2089 - v601;\n\tv2094 = v675[v1972 @ X8_v78 (System.Int32)] - v226;\n\tv2095 = v675[v1579 @ X9_v52 (System.Int32)] - v601;\n\tv2096 = v2091 * 0.1875f;\n\tv2097 = v2090 + v675[v518 @ X26_v23 (System.Int32)];\n\tv2098 = v2092 + v675[v301 @ X11_v19 (System.Int32)];\n\tv2099 = v2094 * 0.75f;\n\tv2100 = v2095 * 0.75f;\n\tv2101 = v2084 * 0.1875f;\n\tv2102 = v2097 * 0x3DC00000;\n\tv2103 = v2098 * 0x3DC00000;\n\tv2104 = v2096 + v2096;\n\tv2105 = v2101 + v2101;\n\tv2106 = v2099 + v2101;\n\tv2107 = v2100 + v2096;\n\tv2108 = v2104 + v2103;\n\tv2109 = v2102 * 0.16666667f;\n\tv2110 = v2103 * 0.16666667f;\n\tv2111 = v2105 + v2102;\n\tv2112 = v2106 + v2109;\n\tv2113 = v2107 + v2110;\n\tv2114 = v2102 + v2111;\n\tv2115 = v2103 + v2108;\n\tv2116 = v2111 + v2112;\n\tv2117 = v2112 * v2112;\n\tv2118 = v2108 + v2113;\n\tv2119 = v2113 * v2113;\n\tv2120 = v2102 + v2114;\n\tv2121 = v2103 + v2115;\n\tv2122 = v2117 + v2119;\n\tv2123 = v2116 * v2116;\n\tv2124 = v2114 + v2116;\n\tv2125 = v2118 * v2118;\n\tv1113 = v2115 + v2118;\n\tv2126 = UnityEngine.Mathf::Sqrt(v2122);\n\tv2159 = v2123 + v2125;\n\tv1111 = v2124 * v2124;\n\tv1109 = v1113 * v1113;\n\tv2160 = v2120 + v2124;\n\tv2161 = v2121 + v1113;\n\tv2162 = v305 + v2126;\n\tv2163 = UnityEngine.Mathf::Sqrt(v2159);\n\tv1117 = v1111 + v1109;\n\tv2248 = v2160 * v2160;\n\tv1115 = v2161 * v2161;\n\tv2249 = v2162 + v2163;\n\tv2250 = UnityEngine.Mathf::Sqrt(v1117);\n\tv1144 = v2248 + v1115;\n\tv1207 = v2249 + v2250;\n\tv1149 = UnityEngine.Mathf::Sqrt(v1144);\n\tv305 = v1207 + v1149;\n\tv1752 = v555 == v518;\n\tv605[v699 @ X19_v11 (System.Int32)] = v305;\n\tif (v1752) goto L_FFFFFFFF;\n\tv1557 = v518 + 6;\n\tv1580 = v1557 - 4;\n\tv699 = v699 + 1;\n\tv2268 = v1580 < v675.Length;\n\tv1530 = ~v2268;\n\tv1192 = ~v1530;\n\tif (v1192) goto L_02DA;\n\tgoto L_068F;\n\tgoto L_03B8;\nL_03B8:\n\tv1764 = v493 == 0;\n\t\n// ... truncated")]
		private float[] ComputeWorldPositions(PathAttachment path, int spacesCount, bool tangents, bool percentPosition, bool percentSpacing)
		{
			//IL_024c: Expected O, but got I8
			//IL_023a: Expected O, but got I8
			//IL_02e8: Expected O, but got I
			//IL_0460: Expected O, but got F4
			//IL_1229: Expected O, but got I
			//IL_1168: Expected O, but got I
			//IL_074a: Expected I, but got O
			//IL_084f: Expected I, but got O
			//IL_06ff: Expected I4, but got O
			//IL_07ec: Expected I4, but got O
			//IL_089c: Expected I4, but got O
			//IL_065b: Expected I4, but got O
			ExposedList<float> exposedList = spaces;
			float num = Position;
			float[] items = exposedList.Items;
			int num2 = spacesCount << 1;
			int num3 = spacesCount + num2;
			int newSize = num3 + 2;
			ExposedList<float> exposedList2 = positions.Resize(newSize);
			int worldVerticesLength = path.WorldVerticesLength;
			int num4 = path.WorldVerticesLength * 715827883;
			int num5 = num4 >> 63;
			int num6 = num4 >> 32;
			int num7 = num6 + num5;
			float[] items4;
			bool flag8 = default(bool);
			bool flag6 = default(bool);
			if (path.ConstantSpeed)
			{
				int num8;
				float[] items2;
				if (path.Closed)
				{
					num8 = path.WorldVerticesLength + 2;
					ExposedList<float> exposedList3 = world.Resize(num8);
					items2 = exposedList3.Items;
					int num9 = path.WorldVerticesLength - 2;
					path.ComputeWorldVertices(Target, 2, num9, exposedList3.Items, 0);
					path.ComputeWorldVertices(Target, 0, 2, exposedList3.Items, num9);
					items2[worldVerticesLength] = items2[0];
					int num10 = path.WorldVerticesLength + 1;
					items2[num10] = items2[1];
				}
				else
				{
					num8 = path.WorldVerticesLength - 4;
					ExposedList<float> exposedList4 = world.Resize(num8);
					items2 = exposedList4.Items;
					num7--;
					path.ComputeWorldVertices(Target, 2, num8, exposedList4.Items, 0);
				}
				ExposedList<float> exposedList5 = curves.Resize(num7);
				float[] items3 = exposedList5.Items;
				float num11 = items2[0];
				float num12 = items2[1];
				float num16;
				float num24;
				float y;
				float cx;
				float x;
				float cy;
				float cx2;
				int num84;
				if (num7 >= 1)
				{
					int num13 = num7 << 1;
					int num14 = num7 + num13;
					int num15 = num14 << 1;
					num16 = 0f;
					int num17 = 6;
					int num18 = 0;
					int num20;
					int num21;
					int num22;
					int num23;
					while (true)
					{
						int num19 = num17 - 3;
						num20 = num17 - 2;
						num21 = num17 - 1;
						num22 = num17 + 1;
						num23 = num17 - 4;
						num24 = items2[num19];
						float num25 = items2[num23] + items2[num23];
						float num26 = num11 - num25;
						float num27 = items2[num23] - items2[num20];
						float num28 = num26 + items2[num20];
						float num29 = items2[num19] + items2[num19];
						float num30 = items2[num19] - items2[num21];
						float num31 = num27 * 3f;
						float num32 = num12 - num29;
						float num33 = num30 * 3f;
						float num34 = num31 - num11;
						float num35 = num32 + items2[num21];
						float num36 = num33 - num12;
						float num37 = items2[num23] - num11;
						float num38 = items2[num19] - num12;
						float num39 = num35 * 0.1875f;
						float num40 = num34 + items2[num17];
						float num41 = num36 + items2[num22];
						float num42 = num37 * 0.75f;
						float num43 = num38 * 0.75f;
						float num44 = num28 * 0.1875f;
						float num45 = num40 * (3f / 32f);
						float num46 = num41 * (3f / 32f);
						float num47 = num39 + num39;
						float num48 = num44 + num44;
						float num49 = num42 + num44;
						float num50 = num43 + num39;
						float num51 = num47 + num46;
						float num52 = num45 * (1f / 6f);
						float num53 = num46 * (1f / 6f);
						float num54 = num48 + num45;
						float num55 = num49 + num52;
						float num56 = num50 + num53;
						float num57 = num45 + num54;
						float num58 = num46 + num51;
						float num59 = num54 + num55;
						float num60 = num55 * num55;
						float num61 = num51 + num56;
						float num62 = num56 * num56;
						float num63 = num45 + num57;
						float num64 = num46 + num58;
						float f = num60 + num62;
						float num65 = num59 * num59;
						float num66 = num57 + num59;
						float num67 = num61 * num61;
						float num68 = num58 + num61;
						float num69 = Mathf.Sqrt(f);
						float f2 = num65 + num67;
						float num70 = num66 * num66;
						float num71 = num68 * num68;
						float num72 = num63 + num66;
						float num73 = num64 + num68;
						float num74 = num16 + num69;
						float num75 = Mathf.Sqrt(f2);
						float f3 = num70 + num71;
						float num76 = num72 * num72;
						float num77 = num73 * num73;
						float num78 = num74 + num75;
						float num79 = Mathf.Sqrt(f3);
						float f4 = num76 + num77;
						float num80 = num78 + num79;
						float num81 = Mathf.Sqrt(f4);
						num16 = num80 + num81;
						bool flag = num15 == num17;
						items3[num18] = num16;
						if (flag)
						{
							break;
						}
						int num82 = num17 + 6;
						int num83 = num82 - 4;
						num18++;
						bool flag2 = num83 < items2.Length;
						bool flag3 = !flag2;
						bool flag4 = !flag3;
						num11 = items2[num17];
						num17 = num82;
						num12 = items2[num22];
						if (flag4)
						{
							continue;
						}
						goto IL_1dc5;
					}
					y = items2[num22];
					num11 = items2[num17];
					cx = items2[num23];
					x = items2[num17];
					cy = items2[num21];
					cx2 = items2[num20];
					num12 = items2[num22];
					exposedList5 = (ExposedList<float>)(object)typeof(Math);
					num84 = spacesCount;
				}
				else
				{
					y = 0f;
					num24 = 0f;
					cx = 0f;
					x = 0f;
					cy = 0f;
					cx2 = 0f;
					num16 = 0f;
					num84 = spacesCount;
				}
				bool flag5 = !flag6;
				bool flag7 = !flag5;
				float num85 = num16;
				if (!flag7)
				{
					float[] array = path.Lengths;
					int num86 = num7 - 1;
					num85 = num16 / array[num86];
				}
				if (num84 > 1 && flag8)
				{
					object obj = (nint)items + 36;
					int num87 = num84 - 1;
					int num88 = 0;
					bool flag9;
					do
					{
						int num89 = num88 + 1;
						float num90 = num16;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1566 @ X10_v27+v1644 @ X8_v73 (System.Int32)*4]");
						float num91 = num90 * 0f;
						flag9 = num87 != num89;
						num88 = num89;
					}
					while (flag9);
				}
				bool flag10 = num84 < 1;
				items4 = exposedList2.Items;
				if (flag10)
				{
					goto IL_1dc0;
				}
				int num92 = num8 - 4;
				float num93 = num * num85;
				float[] array2 = segments;
				object obj2 = (nint)segments + 36;
				float num94 = num16;
				int num95 = 0;
				int num96 = 0;
				float num97 = 0f;
				int newSize2 = num7;
				int num98 = 0;
				int num99 = 0;
				int num100 = -1;
				while (true)
				{
					num93 += items[num96];
					float num102;
					float num103;
					if (path.Closed)
					{
						ExposedList<float> exposedList6 = exposedList5.Resize(newSize2);
						float num101 = num94 + num93;
						num102 = ((!(num93 < 0f)) ? num93 : num101);
						num103 = items[num96];
						num95 = 0;
						goto IL_1307;
					}
					float[] array3;
					if (num93 < 0f)
					{
						AddBeforePosition(num93, items2, 0, exposedList2.Items, num99);
						newSize2 = 0;
						array3 = items2;
					}
					else
					{
						if (!(num93 > num94))
						{
							bool flag11 = items3 == null;
							bool flag12 = !flag11;
							num103 = items[num96];
							num102 = num93;
							items4 = exposedList2.Items;
							if (!flag12)
							{
								throw new NullReferenceException();
							}
							goto IL_1307;
						}
						float p = num93 - num94;
						AddAfterPosition(p, items2, num92, exposedList2.Items, num99);
						newSize2 = num92;
						array3 = items2;
					}
					goto IL_1d17;
					IL_1307:
					bool flag13 = num95 < items3.Length;
					bool flag14 = !flag13;
					int num104 = num95 - items3.Length;
					bool flag15 = num104 == 0;
					bool flag16 = !flag15;
					int num105 = ((!(flag14 && flag16)) ? items3.Length : num95);
					int num106 = num95 << 1;
					int num107 = num95 + num106;
					int num108 = num107 << 1;
					while (num102 > items3[num95])
					{
						num95++;
						num108 += 6;
						if (num105 == num95)
						{
							goto end_IL_1275;
						}
					}
					bool flag17 = num95 == 0;
					float num109 = items3[num95];
					if (!flag17)
					{
						int num110 = num95 - 1;
						num102 -= items3[num110];
						num109 = items3[num95] - items3[num110];
					}
					float num111 = num102 / num109;
					bool flag18 = num100 == num95;
					float num112 = num24;
					if (!flag18)
					{
						int num113 = num108 + 1;
						int num114 = num108 + 2;
						int num115 = num108 + 3;
						int num116 = num108 + 4;
						int num117 = num108 + 5;
						int num118 = num108 + 6;
						int num119 = num108 + 7;
						float num120 = items2[num115] + items2[num115];
						float num121 = items2[num113] - num120;
						float num122 = items2[num114] + items2[num114];
						float num123 = items2[num114] - items2[num116];
						float num124 = items2[num115] - items2[num117];
						float num125 = num121 + items2[num117];
						float num126 = items2[num108] - num122;
						float num127 = num123 * 3f;
						float num128 = num124 * 3f;
						float num129 = num126 + items2[num116];
						float num130 = num127 - items2[num108];
						float num131 = num128 - items2[num113];
						float num132 = items2[num114] - items2[num108];
						float num133 = num129 * 0.03f;
						float num134 = num125 * 0.03f;
						float num135 = items2[num115] - items2[num113];
						float num136 = num130 + items2[num118];
						float num137 = num131 + items2[num119];
						float num138 = num136 * 0.006f;
						float num139 = num137 * 0.006f;
						float num140 = num132 * 0.3f;
						float num141 = num135 * 0.3f;
						float num142 = num133 + num133;
						float num143 = num140 + num133;
						float num144 = num138 * (1f / 6f);
						float num145 = num141 + num134;
						float num146 = num139 * (1f / 6f);
						float num147 = num143 + num144;
						float num148 = num145 + num146;
						float num149 = num147 * num147;
						float num150 = num148 * num148;
						float f5 = num149 + num150;
						float num151 = (array2[0] = Mathf.Sqrt(f5));
						float num152 = num134 + num134;
						float num153 = num138 + num142;
						float num154 = num139 + num152;
						float num155 = num147 + num153;
						float num156 = num148 + num154;
						int num157 = 0;
						do
						{
							float num158 = num155 * num155;
							float num159 = num156 * num156;
							float f6 = num159 + num158;
							float num160 = Mathf.Sqrt(f6);
							num151 += num160;
							num153 = num138 + num153;
							num154 = num139 + num154;
							num157++;
							num155 += num153;
							num156 += num154;
						}
						while (num157 != 7);
						float num161 = num155 * num155;
						float num162 = num156 * num156;
						float f7 = num162 + num161;
						float num163 = Mathf.Sqrt(f7);
						float num164 = (array2[8] = num151 + num163);
						float num165 = num138 + num153;
						float num166 = num139 + num154;
						float num167 = num155 + num165;
						float num168 = num156 + num166;
						float num169 = num167 * num167;
						float num170 = num168 * num168;
						float f8 = num170 + num169;
						float num171 = Mathf.Sqrt(f8);
						float num172 = (array2[9] = num164 + num171);
						num112 = items2[num115];
						y = items2[num119];
						num11 = items2[num108];
						cx = items2[num114];
						x = items2[num118];
						cy = items2[num117];
						cx2 = items2[num116];
						num94 = num16;
						num97 = num172;
						num12 = items2[num113];
						num98 = 0;
						num100 = num95;
					}
					bool flag19 = num98 < array2.Length;
					bool flag20 = !flag19;
					int num173 = num98 - array2.Length;
					bool flag21 = num173 == 0;
					bool flag22 = !flag21;
					int num174 = ((!(flag20 && flag22)) ? array2.Length : num98);
					float num175 = num111 * num97;
					while (num175 > array2[num98])
					{
						num98++;
						if (num174 == num98)
						{
							goto end_IL_1275;
						}
					}
					float num180;
					if (num98 != 0)
					{
						int num176 = num98 - 1;
						float num177 = num175 - array2[num176];
						float num178 = array2[num98] - array2[num176];
						float num179 = num177 / num178;
						num180 = num179 + (float)num98;
					}
					else
					{
						num180 = num175 / array2[num98];
					}
					bool tangents2;
					if (tangents)
					{
						tangents2 = true;
					}
					else if (num96 != 0)
					{
						float num181 = num103 - 1E-05f;
						bool flag23 = num181 < 0f;
						tangents2 = flag23;
					}
					else
					{
						tangents2 = false;
					}
					float p2 = num180 * 0.1f;
					AddCurvePosition(p2, num11, num12, cx, num112, cx2, cy, x, y, exposedList2.Items, num99, tangents2);
					num24 = num112;
					newSize2 = num99;
					array3 = exposedList2.Items;
					goto IL_1d17;
					IL_1d17:
					num96++;
					num99 += 3;
					bool flag24 = num96 != num84;
					exposedList5 = (ExposedList<float>)(object)array3;
					if (flag24)
					{
						continue;
					}
					goto IL_1d5a;
					continue;
					end_IL_1275:
					break;
				}
			}
			else
			{
				float[] array4 = path.Lengths;
				object obj3 = ((!path.Closed) ? ((object)4294967294L) : ((object)(4294967294L + 1)));
				int num182 = (int)((nint)obj3 + num7);
				float num183 = num * array4[num182];
				if (flag6)
				{
					num = num183;
				}
				if (spacesCount >= 2 && flag8)
				{
					object obj4 = (nint)items + 36;
					int num184 = spacesCount - 1;
					int num185 = 0;
					bool flag25;
					do
					{
						int num186 = num185 + 1;
						float num187 = array4[num182];
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1561 @ X10_v9+v1636 @ X8_v34 (System.Int32)*4]");
						float num188 = num187 * 0f;
						flag25 = num184 != num186;
						num185 = num186;
					}
					while (flag25);
				}
				ExposedList<float> exposedList7 = world.Resize(8);
				bool flag26 = spacesCount < 1;
				items4 = exposedList2.Items;
				if (flag26)
				{
					goto IL_1dc0;
				}
				int start = path.WorldVerticesLength - 6;
				int start2 = path.WorldVerticesLength - 4;
				float[] items5 = exposedList7.Items;
				int num189 = (int)((nint)obj3 + num7);
				bool flag27 = tangents;
				int num190 = 0;
				int num191 = 8;
				nint num192 = 0;
				int num193 = 0;
				int num194 = -1;
				int num195 = 0;
				while (true)
				{
					num += items[num193];
					float num197;
					if (path.Closed)
					{
						object obj5 = num % array4[num182];
						float num196 = array4[num182] + num;
						if (num < 0f)
						{
							num197 = num196;
							num190 = 0;
						}
						else
						{
							num197 = num;
							num190 = 0;
						}
						goto IL_04c6;
					}
					int num199;
					float[] array5;
					if (num < 0f)
					{
						if (num194 + 2 != 0)
						{
							path.ComputeWorldVertices(Target, 2, 4, items5, 0);
							flag8 = false;
							flag6 = (byte)(int)items5 != 0;
							nint num198 = 2;
						}
						AddBeforePosition(num, items5, 0, exposedList2.Items, num195);
						num199 = num195;
						num191 = 0;
						num192 = (nint)exposedList2.Items;
						array5 = items5;
						num194 = -2;
					}
					else
					{
						if (!(num > array4[num182]))
						{
							num197 = num;
							goto IL_04c6;
						}
						if (num194 + 3 != 0)
						{
							path.ComputeWorldVertices(Target, start, 4, items5, 0);
							flag8 = false;
							flag6 = (byte)(int)items5 != 0;
							nint num198 = 2;
						}
						float p3 = num - array4[num182];
						AddAfterPosition(p3, items5, 0, exposedList2.Items, num195);
						num199 = num195;
						num191 = 0;
						num192 = (nint)exposedList2.Items;
						array5 = items5;
						num194 = -3;
					}
					goto IL_0948;
					IL_0948:
					num193++;
					num195 += 3;
					bool flag28 = num193 != spacesCount;
					flag27 = (byte)num199 != 0;
					exposedList7 = (ExposedList<float>)(object)array5;
					if (flag28)
					{
						continue;
					}
					goto IL_0993;
					IL_04c6:
					int num200 = num190 * 6;
					int num201 = 2 + num200;
					while (num197 > array4[num190])
					{
						num190++;
						bool flag29 = num190 < array4.Length;
						bool flag30 = !flag29;
						num201 += 6;
						if (flag30)
						{
							goto end_IL_0414;
						}
					}
					bool flag31 = num190 == 0;
					float num202 = array4[num190];
					if (!flag31)
					{
						int num203 = num190 - 1;
						num197 -= array4[num203];
						num202 = array4[num190] - array4[num203];
					}
					float p4 = num197 / num202;
					bool flag32 = num194 == num190;
					num199 = (flag27 ? 1 : 0);
					if (!flag32)
					{
						if (path.Closed && num189 == num190)
						{
							path.ComputeWorldVertices(Target, start2, 4, items5, 0);
							path.ComputeWorldVertices(Target, 0, 4, items5, 4);
							flag8 = true;
							flag6 = (byte)(int)items5 != 0;
							num199 = 4;
							nint num198 = 2;
							num194 = num182;
						}
						else
						{
							path.ComputeWorldVertices(Target, num201, 8, items5, 0);
							flag8 = false;
							flag6 = (byte)(int)items5 != 0;
							num199 = 8;
							nint num198 = 2;
							num194 = num190;
						}
					}
					bool flag33;
					if (tangents)
					{
						flag33 = true;
					}
					else if (num193 != 0)
					{
						float num204 = items[num193] - 1E-05f;
						bool flag34 = num204 < 0f;
						flag33 = flag34;
					}
					else
					{
						flag33 = false;
					}
					AddCurvePosition(p4, items5[0], items5[1], items5[2], items5[3], items5[4], items5[5], items5[6], items5[7], exposedList2.Items, num195, flag33);
					num191 = num195;
					num192 = (flag33 ? 1 : 0);
					array5 = exposedList2.Items;
					goto IL_0948;
					continue;
					end_IL_0414:
					break;
				}
			}
			goto IL_1dc5;
			IL_1dc5:
			return (float[])(object)new IndexOutOfRangeException();
			IL_1dc0:
			return items4;
			IL_1d5a:
			items4 = exposedList2.Items;
			goto IL_1dc0;
			IL_0993:
			items4 = exposedList2.Items;
			goto IL_1dc0;
		}

		[Token(Token = "0x6000300")]
		[Address(RVA = "0x153536C", Offset = "0x153536C", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv38 = Spine.MathUtils;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, i, output, o, methodInfo, v41, v42, v43, p, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 1;\n\t*([1A37B6F]) = v53;\nL_002B:\n\tv150 = i + 1;\n\tv201 = i + 2;\n\tv95 = i + 3;\n\tv257 = temp[v201 @ X8_v5 (System.Int32)] - temp[i @ X1 (System.Int32)];\n\tgoto L_0061;\n\tv260 = \"il2cpp_codegen_runtime_class_init\"(v255, i, output, o, methodInfo, v41, v42, v43, v256, v44, v45, v46, v47, v48, v49, v50);\nL_0061:\n\tv261 = temp[v95 @ X10_v3 (System.Int32)] - temp[v150 @ X9_v3 (System.Int32)];\n\tv262 = Spine.MathUtils::Atan2(v261, v257);\n\tv81 = Spine.MathUtils::Cos(v262);\n\tv265 = v81 * p;\n\tv266 = temp[i @ X1 (System.Int32)] + v265;\n\toutput[o @ X3 (System.Int32)] = v266;\n\tv160 = Spine.MathUtils::Sin(v262);\n\tv165 = o + 1;\n\tv270 = v160 * p;\n\tv166 = o + 2;\n\tv161 = temp[v150 @ X9_v3 (System.Int32)] + v270;\n\toutput[v165 @ X9_v6 (System.Int32)] = v161;\n\toutput[v166 @ X9_v7 (System.Int32)] = v262;\n\treturn;\n\tv141 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 143 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void AddBeforePosition(float p, float[] temp, int i, float[] output, int o)
		{
			int num = i + 1;
			int num2 = i + 2;
			int num3 = i + 3;
			float x = temp[num2] - temp[i];
			float y = temp[num3] - temp[num];
			float num4 = MathUtils.Atan2(y, x);
			float num5 = MathUtils.Cos(num4);
			float num6 = num5 * p;
			float num7 = temp[i] + num6;
			output[o] = num7;
			float num8 = MathUtils.Sin(num4);
			int num9 = o + 1;
			float num10 = num8 * p;
			int num11 = o + 2;
			float num12 = temp[num] + num10;
			output[num9] = num12;
			output[num11] = num4;
		}

		[Token(Token = "0x6000301")]
		[Address(RVA = "0x15354BC", Offset = "0x15354BC", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv38 = Spine.MathUtils;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, i, output, o, methodInfo, v41, v42, v43, p, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 1;\n\t*([1A37B70]) = v53;\nL_001F:\n\tv56 = i + 2;\n\tv146 = i + 3;\n\tv90 = i + 1;\n\tv253 = temp[v56 @ X8_v4 (System.Int32)] - temp[i @ X1 (System.Int32)];\n\tgoto L_0061;\n\tv256 = \"il2cpp_codegen_runtime_class_init\"(v249, i, output, o, methodInfo, v41, v42, v43, v252, v44, v45, v46, v47, v48, v49, v50);\nL_0061:\n\tv257 = temp[v146 @ X9_v3 (System.Int32)] - temp[v90 @ X10_v3 (System.Int32)];\n\tv258 = Spine.MathUtils::Atan2(v257, v253);\n\tv80 = Spine.MathUtils::Cos(v258);\n\tv261 = v80 * p;\n\tv262 = temp[v56 @ X8_v4 (System.Int32)] + v261;\n\toutput[o @ X3 (System.Int32)] = v262;\n\tv156 = Spine.MathUtils::Sin(v258);\n\tv162 = o + 1;\n\tv266 = v156 * p;\n\tv163 = o + 2;\n\tv157 = temp[v146 @ X9_v3 (System.Int32)] + v266;\n\toutput[v162 @ X9_v6 (System.Int32)] = v157;\n\toutput[v163 @ X9_v7 (System.Int32)] = v258;\n\treturn;\n\tv137 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 143 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void AddAfterPosition(float p, float[] temp, int i, float[] output, int o)
		{
			int num = i + 2;
			int num2 = i + 3;
			int num3 = i + 1;
			float x = temp[num] - temp[i];
			float y = temp[num2] - temp[num3];
			float num4 = MathUtils.Atan2(y, x);
			float num5 = MathUtils.Cos(num4);
			float num6 = num5 * p;
			float num7 = temp[num] + num6;
			output[o] = num7;
			float num8 = MathUtils.Sin(num4);
			int num9 = o + 1;
			float num10 = num8 * p;
			int num11 = o + 2;
			float num12 = temp[num2] + num10;
			output[num9] = num12;
			output[num11] = num4;
		}

		[Token(Token = "0x6000302")]
		[Address(RVA = "0x153560C", Offset = "0x153560C", Length = "0x248")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv54 = System.Math;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, o, tangents, methodInfo, v57, v58, v59, v60, p, x1, y1, cx1, cy1, cx2, cy2, x2);\n\tv63 = 1;\n\t*([1A37B71]) = v63;\nL_002B:\n\tv71 = p < 1E-05f;\n\tif (v71) goto L_0050;\n\tv79 = p & 0x7FFFFFFF;\n\tv81 = v79 < 0x7F800001;\n\tv82 = ~v81;\n\tv90 = ~v82;\n\tif (v90) goto L_009B;\nL_0050:\n\tv204 = o + 1;\n\toutput[o @ X1 (System.Int32)] = x1;\n\toutput[v204 @ X10_v7 (System.Int32)] = y1;\n\tgoto L_0068;\n\tv406 = \"il2cpp_codegen_runtime_class_init\"(v310, o, tangents, methodInfo, v57, v58, v59, v60, v65, x1, y1, cx1, cy1, cx2, cy2, x2);\n\tv408 = *([v32 @ X19_v1 (System.Single[])+18]);\nL_0068:\n\tv446 = o + 2;\nL_0073:\n\tv485 = cy1 - y1;\n\tv483 = cx1 - x1;\nL_0077:\n\tv441 = 0x18550E0(v488, o, tangents, methodInfo, v57, v58, v59, v60, v485, v483, v424, v425, v418, v420, v419, v421);\n\toutput[v446 @ X20_v3 (System.Int32)] = v485;\nL_008A:\n\treturn;\nL_009B:\n\tv300 = 1f - p;\n\tv239 = v300 * p;\n\tv236 = v300 * v300;\n\tv302 = v239 * 3f;\n\tv247 = v300 * v236;\n\tv244 = v300 * v302;\n\tv233 = p * p;\n\tv241 = v302 * p;\n\tv303 = v247 * x1;\n\tv304 = v244 * cx1;\n\tv250 = v233 * p;\n\tv305 = v303 + v304;\n\tv306 = v241 * cx2;\n\tv283 = o + 1;\n\tv224 = v250 * v421;\n\tv420 = v305 + v306;\n\tv419 = v420 + v224;\n\toutput[o @ X1 (System.Int32)] = v419;\n\tv401 = v247 * y1;\n\tv425 = v244 * cy1;\n\tv424 = v241 * cy2;\n\tv402 = v401 + v425;\n\tv248 = v402 + v424;\n\tv403 = v250 * y2;\n\tv293 = v248 + v403;\n\toutput[v283 @ X10_v11 (System.Int32)] = v293;\n\tv405 = tangents == 0;\n\tif (v405) goto L_008A;\n\tgoto L_00D9;\n\tv465 = v227;\n\tv466 = v232;\n\tv467 = v235;\n\tv468 = v238;\n\tv469 = \"il2cpp_codegen_runtime_class_init\"(v411, o, tangents, methodInfo, v57, v58, v59, v60, v403, v248, v242, v245, v225, v230, v227, v232);\n\tv472 = v467;\n\tv473 = v468;\n\tv470 = v465;\n\tv471 = v466;\n\tv474 = *([v32 @ X19_v1 (System.Single[])+18]);\nL_00D9:\n\tv446 = o + 2;\n\tv459 = p < 0.001f;\n\tif (v459) goto L_0073;\n\tv491 = v239 * cy1;\n\tv492 = v239 * cx1;\n\tv493 = v236 * y1;\n\tv425 = v236 * x1;\n\tv494 = v491 + v491;\n\tv418 = v492 + v492;\n\tv424 = v233 * cy2;\n\tv420 = v233 * cx2;\n\tv495 = v493 + v494;\n\tv496 = v425 + v418;\n\tv497 = v495 + v424;\n\tv498 = v496 + v420;\n\tv485 = v293 - v497;\n\tv483 = v419 - v498;\n\tgoto L_0077;\n\tv182 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 172 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void AddCurvePosition(float p, float x1, float y1, float cx1, float cy1, float cx2, float cy2, float x2, float y2, float[] output, int o, bool tangents)
		{
			//IL_0089: Expected I, but got O
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Expected I4, but got Unknown
			//IL_026c: Expected I, but got O
			int num28;
			float num38;
			nint num27;
			float num29;
			float num19;
			float num18;
			float num22;
			float num21;
			float num39;
			if (!(p < 1E-05f))
			{
				int num = p & 0x7FFFFFFF;
				if (num < 2139095041)
				{
					float num2 = 1f - p;
					float num3 = num2 * p;
					float num4 = num2 * num2;
					float num5 = num3 * 3f;
					float num6 = num2 * num4;
					float num7 = num2 * num5;
					float num8 = p * p;
					float num9 = num5 * p;
					float num10 = num6 * x1;
					float num11 = num7 * cx1;
					float num12 = num8 * p;
					float num13 = num10 + num11;
					float num14 = num9 * cx2;
					int num15 = o + 1;
					float num17 = default(float);
					float num16 = num12 * num17;
					num18 = num13 + num14;
					num19 = (output[o] = num18 + num16);
					float num20 = num6 * y1;
					num21 = num7 * cy1;
					num22 = num9 * cy2;
					float num23 = num20 + num21;
					float num24 = num23 + num22;
					float num25 = num12 * y2;
					float num26 = (output[num15] = num24 + num25);
					if (tangents)
					{
						num27 = (nint)typeof(Math);
						num28 = o + 2;
						bool flag = p < 0.001f;
						num29 = y2;
						num17 = num8;
						if (flag)
						{
							goto IL_008e;
						}
						float num30 = num3 * cy1;
						float num31 = num3 * cx1;
						float num32 = num4 * y1;
						num21 = num4 * x1;
						float num33 = num30 + num30;
						num29 = num31 + num31;
						num22 = num8 * cy2;
						num18 = num8 * cx2;
						float num34 = num32 + num33;
						float num35 = num21 + num29;
						float num36 = num34 + num22;
						float num37 = num35 + num18;
						num38 = num26 - num36;
						num39 = num19 - num37;
						num17 = num8;
						goto IL_03e8;
					}
					return;
				}
			}
			int num40 = o + 1;
			output[o] = x1;
			output[num40] = y1;
			num27 = (nint)typeof(Math);
			num28 = o + 2;
			num29 = cy1;
			num19 = cy2;
			num18 = cx2;
			num22 = y1;
			num21 = cx1;
			goto IL_008e;
			IL_03e8:
			Il2CppRuntime.Boundary("SYSTEM_API:atan2", "Method not found @18550E0 (native atan2)");
			output[num28] = num38;
			return;
			IL_008e:
			num38 = cy1 - y1;
			num39 = cx1 - x1;
			goto IL_03e8;
		}
	}
}
