using System;
using System.Collections;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine
{
	[Token(Token = "0x2000046")]
	public class IkConstraint : IUpdatable
	{
		[Token(Token = "0x40001BE")]
		[FieldOffset(Offset = "0x10")]
		internal IkConstraintData data;

		[Token(Token = "0x40001BF")]
		[FieldOffset(Offset = "0x18")]
		internal ExposedList<Bone> bones;

		[Token(Token = "0x40001C0")]
		[FieldOffset(Offset = "0x20")]
		internal Bone target;

		[Token(Token = "0x40001C1")]
		[FieldOffset(Offset = "0x28")]
		internal int bendDirection;

		[Token(Token = "0x40001C2")]
		[FieldOffset(Offset = "0x2C")]
		internal bool compress;

		[Token(Token = "0x40001C3")]
		[FieldOffset(Offset = "0x2D")]
		internal bool stretch;

		[Token(Token = "0x40001C4")]
		[FieldOffset(Offset = "0x30")]
		internal float mix;

		[Token(Token = "0x40001C5")]
		[FieldOffset(Offset = "0x34")]
		internal float softness;

		[Token(Token = "0x40001C6")]
		[FieldOffset(Offset = "0x38")]
		internal bool active;

		[Token(Token = "0x170000D8")]
		public ExposedList<Bone> Bones
		{
			[Token(Token = "0x60002C3")]
			[Address(RVA = "0x1532F08", Offset = "0x1532F08", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.bones;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Bones;
			}
		}

		[Token(Token = "0x170000D9")]
		public Bone Target
		{
			[Token(Token = "0x60002C4")]
			[Address(RVA = "0x1532F10", Offset = "0x1532F10", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.target;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Target;
			}
			[Token(Token = "0x60002C5")]
			[Address(RVA = "0x1532F18", Offset = "0x1532F18", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.target = value;\n\treturn;\n")]
			set
			{
				Target = value;
			}
		}

		[Token(Token = "0x170000DA")]
		public float Mix
		{
			[Token(Token = "0x60002C6")]
			[Address(RVA = "0x1532F20", Offset = "0x1532F20", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mix;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Mix;
			}
			[Token(Token = "0x60002C7")]
			[Address(RVA = "0x1532F28", Offset = "0x1532F28", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mix = value;\n\treturn;\n")]
			set
			{
				Mix = value;
			}
		}

		[Token(Token = "0x170000DB")]
		public float Softness
		{
			[Token(Token = "0x60002C8")]
			[Address(RVA = "0x1532F30", Offset = "0x1532F30", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.softness;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Softness;
			}
			[Token(Token = "0x60002C9")]
			[Address(RVA = "0x1532F38", Offset = "0x1532F38", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.softness = value;\n\treturn;\n")]
			set
			{
				Softness = value;
			}
		}

		[Token(Token = "0x170000DC")]
		public int BendDirection
		{
			[Token(Token = "0x60002CA")]
			[Address(RVA = "0x1532F40", Offset = "0x1532F40", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.bendDirection;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return BendDirection;
			}
			[Token(Token = "0x60002CB")]
			[Address(RVA = "0x1532F48", Offset = "0x1532F48", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.bendDirection = value;\n\treturn;\n")]
			set
			{
				BendDirection = value;
			}
		}

		[Token(Token = "0x170000DD")]
		public bool Compress
		{
			[Token(Token = "0x60002CC")]
			[Address(RVA = "0x1532F50", Offset = "0x1532F50", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.compress;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Compress;
			}
			[Token(Token = "0x60002CD")]
			[Address(RVA = "0x1532F58", Offset = "0x1532F58", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.compress = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				compress = value;
			}
		}

		[Token(Token = "0x170000DE")]
		public bool Stretch
		{
			[Token(Token = "0x60002CE")]
			[Address(RVA = "0x1532F64", Offset = "0x1532F64", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.stretch;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Stretch;
			}
			[Token(Token = "0x60002CF")]
			[Address(RVA = "0x1532F6C", Offset = "0x1532F6C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.stretch = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				stretch = value;
			}
		}

		[Token(Token = "0x170000DF")]
		public bool Active
		{
			[Token(Token = "0x60002D0")]
			[Address(RVA = "0x1532F78", Offset = "0x1532F78", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.active;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Active;
			}
		}

		[Token(Token = "0x170000E0")]
		public IkConstraintData Data
		{
			[Token(Token = "0x60002D1")]
			[Address(RVA = "0x1532F80", Offset = "0x1532F80", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.data;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Data;
			}
		}

		[Token(Token = "0x60002BF")]
		[Address(RVA = "0x1531ADC", Offset = "0x1531ADC", Length = "0x2F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0031;\n\tv32 = Il2CppMethodInfo;\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, data, skeleton, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv57 = Il2CppMethodInfo;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, data, skeleton, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv62 = Il2CppMethodInfo;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, data, skeleton, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv68 = Il2CppMethodInfo;\n\tv69 = \"il2cpp_codegen_initialize_runtime_metadata\"(v68, data, skeleton, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv72 = Il2CppMethodInfo;\n\tv73 = \"il2cpp_codegen_initialize_runtime_metadata\"(v72, data, skeleton, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv135 = Il2CppMethodInfo;\n\tv136 = \"il2cpp_codegen_initialize_runtime_metadata\"(v135, data, skeleton, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv148 = Il2CppMethodInfo;\n\tv149 = \"il2cpp_codegen_initialize_runtime_metadata\"(v148, data, skeleton, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv199 = Spine.ExposedList`1<Spine.Bone>;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v199, data, skeleton, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A37B59]) = v50;\nL_0031:\n\tv52 = 0;\n\tv55 = new Spine.ExposedList`1<Spine.Bone>();\n\tSpine.ExposedList`1<Spine.Bone>::.ctor(v55);\n\tthis.bones = v55;\n\tthis.mix = 1f;\n\tSystem.Object::.ctor(this);\n\tv70 = data == 0;\n\tif (v70) goto L_0094;\n\tv74 = skeleton == 0;\n\tif (v74) goto L_00A0;\n\tthis.data = data;\n\tthis.mix = data.mix;\n\tthis.bendDirection = data.bendDirection;\n\tthis.compress = data.compress;\n\tthis.stretch = data.stretch;\n\tv141 = data.bones;\n\tv154 = new Spine.ExposedList`1<Spine.Bone>();\n\tSpine.ExposedList`1<Spine.Bone>::.ctor(v154, v141.Count);\n\tthis.bones = v154;\n\tv241 = Spine.ExposedList`1<Spine.BoneData>::GetEnumerator(data.bones);\nL_0068:\n\tv258 = Spine.ExposedList`1<System.Object>+Enumerator<System.Object>::MoveNext(&v52 @ stack_-58_v1 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv263 = v258 == 0;\n\tif (v263) goto L_007C;\n\tv184 = 0;\n\tv272 = Spine.Skeleton::FindBone(skeleton, *([v184 @ X8_v20 (System.Int32)+18]));\n\tSpine.ExposedList`1<Spine.Bone>::Add(this.bones, v272);\n\tgoto L_0068;\nL_007C:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v52 @ stack_-58_v1 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\nL_007D:\n\tv185 = data.target;\n\tv294 = Spine.Skeleton::FindBone(skeleton, v185.name);\n\t*([this @ X0 (Spine.IkConstraint)+20]) = v294;\n\treturn;\n\tv273 = new System.NullReferenceException();\n\tv176 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_0094:\n\tv146 = new System.ArgumentNullException();\n\tgoto L_00AD;\nL_00A0:\n\tv193 = new System.ArgumentNullException();\nL_00AD:\n\tSystem.ArgumentNullException::.ctor(v227, v228, v225);\n\tthrow v227;\n\tgoto L_00C0;\n\tgoto L_00C0;\nL_00C0:\n\tv275 = Il2CppMethodInfo != 1;\n\tif (v275) goto L_00CF;\n\tv295 = 0x1854E70(v266, Il2CppMethodInfo, v225, 0, v35, v36, v37, v38, v223, v40, v41, v42, v43, v44, v45, v46);\n\tv289 = *([v295 @ X0_v21]);\n\tv312 = 0x1854E80(v295, Il2CppMethodInfo, v225, 0, v35, v36, v37, v38, v223, v40, v41, v42, v43, v44, v45, v46);\n\tv284 = *([v231 @ X23_v3 (Il2CppClass<Spine.ExposedList`1<Spine.Bone>>)]);\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v52 @ stack_-58_v1 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>), v284);\n\tv287 = v289 == 0;\n\tif (v287) goto L_007D;\n\tv299 = new System.OutOfMemoryException();\nL_00CF:\n\tgoto L_00D1;\n\tX19 = X0;\nL_00D1:\n\tv313 = *([v231 @ X23_v3 (Il2CppClass<Spine.ExposedList`1<Spine.Bone>>)]);\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v52 @ stack_-58_v1 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>), v313);\n\tif (-2) goto L_00DB;\n\tv346 = 0xBD3CD0(v298, v313, v225, 0, v35, v36, v37, v38, v223, v40, v41, v42, v43, v44, v45, v46);\nL_00DB:\n\tv349 = new System.OutOfMemoryException();\n\tv332 = 0x9DACB4(v349, v313, v225, 0, v35, v36, v37, v38, v223, v40, v41, v42, v43, v44, v45, v46);\n\treturn;\n// 142 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IkConstraint(IkConstraintData data, Skeleton skeleton)
		{
			//IL_00ab: Expected O, but got I4
			//IL_0129: Expected O, but got I
			base._002Ector();
			ExposedList<object>.Enumerator enumerator = default(ExposedList<object>.Enumerator);
			ExposedList<Bone> exposedList = new ExposedList<Bone>();
			bones = exposedList;
			Mix = 1f;
			ArgumentNullException ex2;
			if (data != null)
			{
				if (skeleton != null)
				{
					this.data = data;
					Mix = data.Mix;
					BendDirection = data.BendDirection;
					compress = data.Compress;
					stretch = data.Stretch;
					ExposedList<BoneData> exposedList2 = data.Bones;
					ExposedList<Bone> exposedList3 = new ExposedList<Bone>((IEnumerable<Bone>)exposedList2.Count);
					bones = exposedList3;
					ExposedList<BoneData>.Enumerator enumerator2 = data.Bones.GetEnumerator();
					while (enumerator.MoveNext())
					{
						int num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ X8_v20 (System.Int32)+18]");
						Bone item = skeleton.FindBone((string)0);
						Bones.Add(item);
					}
					enumerator.Dispose();
					BoneData boneData = data.Target;
					Bone bone = skeleton.FindBone(boneData.Name);
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

		[Token(Token = "0x60002C0")]
		[Address(RVA = "0x1531EBC", Offset = "0x1531EBC", Length = "0x338")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0033;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, constraint, skeleton, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv55 = Il2CppMethodInfo;\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, constraint, skeleton, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv60 = Il2CppMethodInfo;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, constraint, skeleton, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv66 = Il2CppMethodInfo;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, constraint, skeleton, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv70 = Il2CppMethodInfo;\n\tv71 = \"il2cpp_codegen_initialize_runtime_metadata\"(v70, constraint, skeleton, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv140 = Il2CppMethodInfo;\n\tv141 = \"il2cpp_codegen_initialize_runtime_metadata\"(v140, constraint, skeleton, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv150 = Il2CppMethodInfo;\n\tv151 = \"il2cpp_codegen_initialize_runtime_metadata\"(v150, constraint, skeleton, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv222 = Spine.ExposedList`1<Spine.Bone>;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v222, constraint, skeleton, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv48 = 1;\n\t*([1A37B5A]) = v48;\nL_0033:\n\tv53 = new Spine.ExposedList`1<Spine.Bone>();\n\tSpine.ExposedList`1<Spine.Bone>::.ctor(v53);\n\tthis.bones = v53;\n\tthis.mix = 1f;\n\tSystem.Object::.ctor(this);\n\tv68 = constraint == 0;\n\tif (v68) goto L_00C3;\n\tv72 = skeleton == 0;\n\tif (v72) goto L_00CB;\n\tthis.data = constraint.data;\n\tv143 = constraint.bones;\n\tv156 = new Spine.ExposedList`1<Spine.Bone>();\n\tSpine.ExposedList`1<Spine.Bone>::.ctor(v156, v143.Count);\n\tthis.bones = v156;\n\tv262 = Spine.ExposedList`1<Spine.Bone>::GetEnumerator(constraint.bones);\nL_0064:\n\tv302 = Spine.ExposedList`1<System.Object>+Enumerator<System.Object>::MoveNext(&v188 @ stack_-78_v6 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv340 = v302 == 0;\n\tif (v340) goto L_008B;\n\tv341 = skeleton.bones;\n\tv398 = *([v267 @ stack_-68+10]);\n\tv417 = v341.Items;\n\tv291 = *([v398 @ X9_v14+10]);\n\tSpine.ExposedList`1<Spine.Bone>::Add(this.bones, v417[v291 @ X9_v17]);\n\tgoto L_0064;\nL_008B:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v188 @ stack_-78_v6 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\nL_008C:\n\tv208 = skeleton.bones;\n\tv180 = constraint.target;\n\tv181 = v180.data;\n\tv209 = v208.Items;\n\tv324 = v181.index;\n\tv444 = v181.index < v209.Length;\n\tv320 = ~v444;\n\tif (v320) goto L_00DA;\n\tv333._data = v209[v324 @ X9_v8 (System.Int32)];\n\tv333._helpURL = constraint.mix;\n\tv333._innerException = constraint.bendDirection;\n\t*([v333 @ X19_v3 (System.ArgumentNullException)+2C]) = constraint.compress;\n\t*([v333 @ X19_v3 (System.ArgumentNullException)+2D]) = constraint.stretch;\n\treturn;\n\tv430 = new System.NullReferenceException();\n\tv433 = new System.NullReferenceException();\n\tv378 = new System.NullReferenceException();\n\tv383 = new System.NullReferenceException();\n\tv413 = new System.NullReferenceException();\n\tv197 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\nL_00C3:\n\tv148 = new System.ArgumentNullException();\n\tgoto L_00D3;\nL_00CB:\n\tv217 = new System.ArgumentNullException();\nL_00D3:\n\tSystem.ArgumentNullException::.ctor(v333, v244);\n\tthrow v333;\nL_00DA:\n\tv338 = new System.IndexOutOfRangeException();\n\tgoto L_00EA;\n\tgoto L_00EA;\n\tgoto L_00EA;\n\tgoto L_00EA;\n\tgoto L_00EA;\n\tgoto L_00EA;\nL_00EA:\n\tv354 = v330 != 1;\n\tif (v354) goto L_00F8;\n\tv390 = 0x1854E70(v338, v330, v329, methodInfo, v33, v34, v35, v36, v188, v38, v39, v40, v41, v42, v43, v44);\n\tv414 = 0x1854E80(v390, v330, v329, methodInfo, v33, v34, v35, v36, v188, v38, v39, v40, v41, v42, v43, v44);\n\tv330 = *([v336 @ X23_v4 (Il2CppClass<Spine.ExposedList`1<Spine.Bone>>)]);\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v112 @ stack_-60_v5 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv387 = *([v390 @ X0_v23]) == 0;\n\tif (v387) goto L_008C;\n\tv393 = new System.OutOfMemoryException();\nL_00F8:\n\tgoto L_00FC;\n\tX19 = X0;\nL_00FC:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v112 @ stack_-60_v5 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_0103;\n\tv440 = 0xBD3CD0(v338, *([v336 @ X23_v4 (Il2CppClass<Spine.ExposedList`1<Spine.Bone>>)]), v329, methodInfo, v33, v34, v35, v36, v188, v38, v39, v40, v41, v42, v43, v44);\nL_0103:\n\tv443 = new System.OutOfMemoryException();\n\tv446 = 0x9DACB4(v443, *([v336 @ X23_v4 (Il2CppClass<Spine.ExposedList`1<Spine.Bone>>)]), v329, methodInfo, v33, v34, v35, v36, v188, v38, v39, v40, v41, v42, v43, v44);\n\treturn;\n// 168 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IkConstraint(IkConstraint constraint, Skeleton skeleton)
		{
			//IL_027a: Expected I, but got O
			//IL_0270: Expected I, but got O
			//IL_0074: Expected O, but got I4
			//IL_00cc: Expected O, but got I
			//IL_00f3: Expected O, but got I
			//IL_01ee: Expected O, but got F4
			//IL_0200: Expected O, but got I4
			base._002Ector();
			ExposedList<Bone> exposedList = new ExposedList<Bone>();
			bones = exposedList;
			Mix = 1f;
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
					ExposedList<Bone> exposedList2 = constraint.Bones;
					ExposedList<Bone> exposedList3 = new ExposedList<Bone>((IEnumerable<Bone>)exposedList2.Count);
					bones = exposedList3;
					ExposedList<Bone>.Enumerator enumerator = constraint.Bones.GetEnumerator();
					num = 0;
					ExposedList<object>.Enumerator enumerator2 = default(ExposedList<object>.Enumerator);
					while (enumerator2.MoveNext())
					{
						ExposedList<Bone> exposedList4 = skeleton.Bones;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ stack_-68+10]");
						object obj = 0;
						Bone[] items = exposedList4.Items;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ X9_v14+10]");
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
						ExposedList<Bone> exposedList5 = skeleton.Bones;
						Bone bone = constraint.Target;
						BoneData boneData = bone.Data;
						Bone[] items2 = exposedList5.Items;
						int index = boneData.Index;
						if (boneData.Index < items2.Length)
						{
							((Exception)ex)._data = (IDictionary)items2[index];
							((Exception)ex)._helpURL = (string)constraint.Mix;
							((Exception)ex)._innerException = (Exception)constraint.BendDirection;
							_ = constraint.Compress;
							_ = constraint.Stretch;
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
				num3 = (nint)typeof(ExposedList<Bone>);
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

		[Token(Token = "0x60002C1")]
		[Address(RVA = "0x15321F4", Offset = "0x15321F4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.IkConstraint::Update(this);\n\treturn;\n")]
		public void Apply()
		{
			Update();
		}

		[Token(Token = "0x60002C2")]
		[Address(RVA = "0x15321F8", Offset = "0x15321F8", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.bones;\n\tv6 = this.target;\n\tv11 = v2.Count == 2;\n\tif (v11) goto L_0033;\n\tv18 = v2.Count != 1;\n\tif (v18) goto L_0054;\n\tv65 = v2.Items;\n\tv56 = this.data;\n\tSpine.IkConstraint::Apply(v65[0], v6.worldX, v6.worldY, this.compress, this.stretch, v56.uniform, this.mix);\n\treturn;\nL_0033:\n\tv57 = v2.Items;\n\tSpine.IkConstraint::Apply(v57[0], v57[1], v6.worldX, v6.worldY, this.bendDirection, this.stretch, this.softness, this.mix);\n\treturn;\nL_0054:\n\treturn;\n\tv67 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Update()
		{
			ExposedList<Bone> exposedList = Bones;
			Bone bone = Target;
			if (exposedList.Count != 2)
			{
				if (exposedList.Count == 1)
				{
					Bone[] items = exposedList.Items;
					IkConstraintData ikConstraintData = Data;
					Apply(items[0], bone.WorldX, bone.WorldY, Compress, Stretch, ikConstraintData.Uniform, Mix);
				}
			}
			else
			{
				Bone[] items2 = exposedList.Items;
				Apply(items2[0], items2[1], bone.WorldX, bone.WorldY, BendDirection, Stretch, Softness, Mix);
			}
		}

		[Token(Token = "0x60002D2")]
		[Address(RVA = "0x1532F88", Offset = "0x1532F88", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.data;\n\treturn v2.name;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			IkConstraintData ikConstraintData = Data;
			return ikConstraintData.Name;
		}

		[Token(Token = "0x60002D3")]
		[Address(RVA = "0x15322B0", Offset = "0x15322B0", Length = "0x370")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv56 = System.Math;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, compress, stretch, uniform, methodInfo, v59, v60, v61, targetX, targetY, alpha, v62, v63, v64, v65, v66);\n\tv69 = 1;\n\t*([1A37B5B]) = v69;\nL_0028:\n\tv72 = ~bone.appliedValid;\n\tv73 = ~v72;\n\tif (v73) goto L_002D;\n\tSpine.Bone::UpdateAppliedTransform(bone);\nL_002D:\n\tv160 = bone.parent;\n\tv176 = bone.data;\n\tv318 = v160.b;\n\tv316 = v160.d;\n\tv157 = -bone.ashearX;\n\tv127 = v176.transformMode == 1;\n\tv355 = v157 - bone.arotation;\n\tif (v127) goto L_005D;\n\tv276 = v176.transformMode != 7;\n\tif (v276) goto L_00AA;\n\tv504 = targetX - bone.worldX;\n\tv502 = targetY - bone.worldY;\n\tgoto L_00BF;\nL_005D:\n\tgoto L_005F;\n\tv351 = \"il2cpp_codegen_runtime_class_init\"(v277, compress, stretch, uniform, methodInfo, v59, v60, v61, v157, v154, alpha, v62, v63, v64, v65, v66);\nL_005F:\n\tv99 = bone.skeleton;\n\tgoto L_0075;\n\tv382 = Spine.Bone;\n\tv164 = \"il2cpp_codegen_initialize_runtime_metadata\"(v382, compress, stretch, uniform, methodInfo, v59, v60, v61, v157, v154, alpha, v62, v63, v64, v65, v66);\n\tv413 = 1;\n\t*([1A37B73]) = v413;\n\tv178 = v50.skeleton;\nL_0075:\n\tv386 = v160.a * v160.d;\n\tv388 = v160.a * v160.a;\n\tv390 = v160.c * v160.c;\n\t// 123 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv393 = v388 + v390;\n\tv289 = v99.scaleY;\n\tv395 = v386 / v393;\n\tv418 = -v99.scaleY;\n\tif (v392.yDown) goto L_0092;\n\tgoto L_0092;\nL_0092:\n\tv419 = -v289;\n\tif (v392.yDown) goto L_FFFFFFFF;\n\tgoto L_0099;\nL_0099:\n\tv448 = -v160.c;\n\tv287 = v448 / v418;\n\tv449 = v160.a / v99.scaleX;\n\tv450 = v395 * v449;\n\tv451 = v395 * v287;\n\tv316 = v450 * v289;\n\tv318 = v99.scaleX * v451;\n\tv325 = 0x18550E0(System.Math, compress, stretch, uniform, methodInfo, v59, v60, v61, v160.c, v160.a, v99.scaleX, v289, v287, v77, v75, v66);\n\tv323 = v160.c * 57.295776f;\n\tv355 = v355 + v323;\nL_00AA:\n\tv334 = v160.a * v316;\n\tv335 = v160.c * v318;\n\tv338 = targetY - v160.worldY;\n\tv339 = targetX - v160.worldX;\n\tv353 = v334 - v335;\n\tv341 = v318 * v338;\n\tv342 = v160.a * v338;\n\tv75 = v316 * v339;\n\tv344 = v160.c * v339;\n\tv84 = v75 - v341;\n\tv346 = v342 - v344;\n\tv347 = v84 / v353;\n\tv348 = v346 / v353;\n\tv504 = v347 - bone.ax;\n\tv502 = v348 - bone.ay;\nL_00BF:\n\tgoto L_00C3;\n\tv377 = \"il2cpp_codegen_runtime_class_init\"(v369, compress, stretch, uniform, methodInfo, v59, v60, v61, v365, v364, v353, v84, v82, v77, v75, v66);\nL_00C3:\n\tv165 = 0x18550E0(System.Math, compress, stretch, uniform, methodInfo, v59, v60, v61, v502, v504, v353, v84, bone.ax, bone.ay, v75, v66);\n\tv505 = bone.ascaleX;\n\tv402 = v502 * 57.295776f;\n\tv403 = v355 + v402;\n\tv155 = v403 + 0x43340000;\n\tv80 = bone.ascaleX >= 0;\n\tif (v80) goto L_FFFFFFFF;\n\tgoto L_00E6;\nL_00E6:\n\tv432 = v146 <= 0x43340000;\n\tif (v432) goto L_00F5;\n\tgoto L_00F9;\nL_00F5:\n\tv447 = v146 >= 0xC3340000;\n\tif (v447) goto L_00FA;\nL_00F9:\n\tv146 = v146 + v464;\nL_00FA:\n\tv484 = bone.ascaleY;\n\tv470 = compress == 0;\n\tv471 = ~v470;\n\tif (v471) goto L_0102;\n\tv474 = stretch == 0;\n\tif (v474) goto L_016A;\nL_0102:\n\tv179 = bone.data;\n\tv480 = v179.transformMode | 4;\n\tv536 = v480 != 6;\n\tif (v536) goto L_011B;\n\tv504 = targetX - bone.worldX;\n\tv502 = targetY - bone.worldY;\nL_011B:\n\tv546 = v505 * v179.length;\n\tgoto L_0120;\n\tv549 = \"il2cpp_codegen_runtime_class_init\"(v543, compress, stretch, uniform, methodInfo, v59, v60, v61, v544, v541, v478, v84, v82, v77, v75, v66);\nL_0120:\n\tv550 = v504 * v504;\n\tv551 = v502 * v502;\n\tv552 = v551 + v550;\n\tv511 = UnityEngine.Mathf::Sqrt(v552);\n\tv562 = v511 >= v546;\n\tif (v562) goto L_0140;\n\tv564 = compress == 0;\n\tv565 = ~v564;\n\tif (v565) goto L_0152;\nL_0140:\n\tv578 = v546 <= 0.0001f;\n\tif (v578) goto L_016A;\n\tv580 = v511 <= v546;\n\tif (v580) goto L_016A;\n\tv595 = stretch == 0;\n\tif (v595) goto L_016A;\nL_0152:\n\tv596 = v511 / v546;\n\tv597 = v596 + -1f;\n\tv598 = v597 * v519;\n\tv599 = v598 + 1f;\n\tv505 = v505 * v599;\n\tv512 = v484 * v599;\n\tv494 = uniform == 0;\n\tv482 = ~v494;\n\tv476 = ~v482;\n\tif (v476) goto L_0167;\n\tgoto L_0167;\nL_0167:\n\tgoto L_016A;\nL_016A:\n\tv525 = v146 * v519;\n\tv197 = v525 + bone.arotation;\n\tSpine.Bone::UpdateWorldTransform(bone, bone.ax, bone.ay, v197, v505, v484, bone.ashearX, bone.ashearY);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 261 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Apply(Bone bone, float targetX, float targetY, bool compress, bool stretch, bool uniform, float alpha)
		{
			//IL_0088: Expected O, but got F4
			//IL_060e: Expected O, but got F4
			if (!bone.appliedValid)
			{
				bone.Update();
			}
			Bone parent = bone.Parent;
			BoneData boneData = bone.Data;
			float num = parent.B;
			float num2 = parent.D;
			object obj = 0f - bone.AShearX;
			bool flag = boneData.TransformMode == TransformMode.NoRotationOrReflection;
			float num3 = (float)obj - bone.AppliedRotation;
			float num4;
			float num6;
			float num7;
			float num5 = default(float);
			if (!flag)
			{
				bool flag2 = boneData.TransformMode != TransformMode.OnlyTranslation;
				num4 = num5;
				if (!flag2)
				{
					num6 = targetX - bone.WorldX;
					num7 = targetY - bone.WorldY;
					num4 = num5;
					goto IL_01fd;
				}
			}
			else
			{
				Skeleton skeleton = bone.Skeleton;
				float num8 = parent.A * parent.D;
				float num9 = parent.A * parent.A;
				float num10 = parent.C * parent.C;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
				float num11 = num9 + num10;
				float num12 = skeleton.scaleY;
				float num13 = num8 / num11;
				float num14 = 0f - skeleton.scaleY;
				if (!Bone.yDown)
				{
					num14 = skeleton.scaleY;
				}
				float num15 = 0f - num12;
				if (Bone.yDown)
				{
					num12 = num15;
				}
				object obj2 = 0f - parent.C;
				float num16 = (float)obj2 / num14;
				float num17 = parent.A / skeleton.ScaleX;
				float num18 = num13 * num17;
				float num19 = num13 * num16;
				num2 = num18 * num12;
				num = skeleton.ScaleX * num19;
				Il2CppRuntime.Boundary("SYSTEM_API:atan2", "Method not found @18550E0 (native atan2)");
				float num20 = parent.C * (180f / (float)Math.PI);
				num3 += num20;
				num4 = num5;
			}
			float num21 = parent.A * num2;
			float num22 = parent.C * num;
			float num23 = targetY - parent.WorldY;
			float num24 = targetX - parent.WorldX;
			num5 = num21 - num22;
			float num25 = num * num23;
			float num26 = parent.A * num23;
			float num27 = num2 * num24;
			float num28 = parent.C * num24;
			float num29 = num27 - num25;
			float num30 = num26 - num28;
			float num31 = num29 / num5;
			float num32 = num30 / num5;
			num6 = num31 - bone.AX;
			num7 = num32 - bone.AY;
			goto IL_01fd;
			IL_06ee:
			float num33 = bone.AScaleY;
			float num36;
			if (compress || stretch)
			{
				BoneData boneData2 = bone.Data;
				int num34 = (int)(boneData2.TransformMode | (TransformMode)4);
				if (num34 == 6)
				{
					num6 = targetX - bone.WorldX;
					num7 = targetY - bone.WorldY;
				}
				float num35 = num36 * boneData2.Length;
				float num37 = num6 * num6;
				float num38 = num7 * num7;
				float f = num38 + num37;
				float num39 = Mathf.Sqrt(f);
				if ((num39 < num35 && compress) || (num35 > 0.0001f && num39 > num35 && stretch))
				{
					float num40 = num39 / num35;
					float num41 = num40 + -1f;
					float num42 = num41 * num4;
					float num43 = num42 + 1f;
					num36 *= num43;
					float num44 = num33 * num43;
					if (uniform)
					{
						num33 = num44;
					}
				}
			}
			float num46;
			float num45 = num46 * num4;
			float rotation = num45 + bone.AppliedRotation;
			bone.UpdateWorldTransform(bone.AX, bone.AY, rotation, num36, num33, bone.AShearX, bone.AShearY);
			return;
			IL_01fd:
			Il2CppRuntime.Boundary("SYSTEM_API:atan2", "Method not found @18550E0 (native atan2)");
			num36 = bone.AScaleX;
			float num47 = num7 * (180f / (float)Math.PI);
			float num48 = num3 + num47;
			float num49 = num48 + 180f;
			num46 = ((!(bone.AScaleX < 0f)) ? num48 : num49);
			int num50;
			if (num46 > 180f)
			{
				num50 = -1011613696;
			}
			else
			{
				if (!(num46 < -180f))
				{
					goto IL_06ee;
				}
				num50 = 1135869952;
			}
			num46 += (float)num50;
			goto IL_06ee;
		}

		[Token(Token = "0x60002D4")]
		[Address(RVA = "0x1532620", Offset = "0x1532620", Length = "0x8E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\tv54 = System.Math;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, child, bendDir, stretch, methodInfo, v57, v58, v59, targetX, targetY, softness, alpha, v60, v61, v62, v63);\n\tv66 = 1;\n\t*([1A37B5C]) = v66;\nL_002D:\n\tv76 = alpha != 0;\n\tif (v76) goto L_003C;\n\tv402 = child.x;\n\tv400 = child.y;\n\tv398 = child.rotation;\n\tv396 = child.scaleX;\n\tv394 = child.scaleY;\n\tv392 = child.shearX;\n\tv390 = child.shearY;\n\tgoto L_FFFFFFFF;\nL_003C:\n\tv230 = ~parent.appliedValid;\n\tv231 = ~v230;\n\tif (v231) goto L_0047;\n\tSpine.Bone::UpdateAppliedTransform(parent);\nL_0047:\n\tv503 = ~child.appliedValid;\n\tv504 = ~v503;\n\tif (v504) goto L_0064;\n\tSpine.Bone::UpdateAppliedTransform(child);\nL_0064:\n\tv528 = -parent.ascaleX;\n\tv529 = parent.ascaleX >= 0;\n\tif (v529) goto L_FFFFFFFF;\n\tgoto L_006E;\nL_006E:\n\tv532 = -parent.ascaleY;\n\tv533 = parent.ascaleX >= 0;\n\tif (v533) goto L_FFFFFFFF;\n\tgoto L_0077;\nL_0077:\n\tv537 = parent.ascaleX >= 0;\n\tif (v537) goto L_FFFFFFFF;\n\tgoto L_0086;\nL_0086:\n\tv550 = parent.ascaleY >= 0;\n\tif (v550) goto L_FFFFFFFF;\n\tv228 = -v536;\n\tgoto L_008C;\nL_008C:\n\tv553 = parent.ascaleY >= 0;\n\tif (v553) goto L_FFFFFFFF;\n\tgoto L_009B;\nL_009B:\n\tv572 = -child.ascaleX;\n\tv566 = child.ascaleX >= 0;\n\tif (v566) goto L_FFFFFFFF;\n\tgoto L_00A2;\nL_00A2:\n\tv149 = child.ascaleX >= 0;\n\tif (v149) goto L_FFFFFFFF;\n\tgoto L_00AE;\nL_00AE:\n\tgoto L_00B6;\n\tv575 = v540;\n\tv576 = \"il2cpp_codegen_runtime_class_init\"(v517, child, bendDir, stretch, methodInfo, v57, v58, v59, v572, v512, v515, v516, v569, v532, v508, v509);\n\tv579 = v102;\n\tv580 = v99;\n\tv578 = v575;\nL_00B6:\n\t// 182 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv581 = child.ax * parent.a;\n\tv582 = child.ax * parent.c;\n\tv583 = v686 < 0.0001f;\n\tv165 = ~v583;\n\tv163 = v686 - 0.0001f;\n\tv159 = v163 == 0;\n\tv584 = ~v159;\n\tv116 = v165 & v584;\n\tif (v116) goto L_00D2;\n\tv588 = parent.b * child.ay;\n\tv590 = parent.d * child.ay;\n\tv591 = v581 + v588;\n\tv592 = v582 + v590;\n\tv217 = parent.worldX + v591;\n\tv140 = v592 + parent.worldY;\n\tgoto L_00D6;\nL_00D2:\n\tv217 = v581 + parent.worldX;\n\tv140 = v582 + parent.worldY;\nL_00D6:\n\tv96 = parent.parent;\n\tgoto L_00F0;\n\tv605 = v174;\n\tv606 = v122;\n\tv607 = v119;\n\tv608 = \"il2cpp_codegen_runtime_class_init\"(v601, child, bendDir, stretch, methodInfo, v57, v58, v59, v204, v202, v200, v198, v196, v194, v191, v177);\n\tv610 = v606;\n\tv609 = v607;\n\tv611 = v605;\n\tv612 = v102;\n\tv613 = v99;\nL_00F0:\n\tv226 = child.data;\n\tv614 = v96.a * v96.d;\n\tv615 = v96.b * v96.c;\n\tv616 = v217 - v96.worldX;\n\tv617 = v140 - v96.worldY;\n\tv619 = v614 - v615;\n\tv620 = v96.a * v617;\n\tv621 = v96.c * v616;\n\tv622 = v96.d * v616;\n\tv623 = v96.b * v617;\n\tv624 = 1f / v619;\n\tv625 = v620 - v621;\n\tv626 = v622 - v623;\n\tv627 = v624 * v625;\n\tv628 = v624 * v626;\n\tv629 = v627 - parent.ay;\n\tv630 = v628 - parent.ax;\n\tv631 = v630 * v630;\n\tv632 = v629 * v629;\n\tv633 = v631 + v632;\n\tv992 = UnityEngine.Mathf::Sqrt(v633);\n\tv249 = v992 >= 0.0001f;\n\tif (v249) goto L_013C;\n\tSpine.IkConstraint::Apply(parent, targetX, targetY, 0, stretch, 0, alpha);\n\tv396 = child.ascaleX;\n\tv394 = child.ascaleY;\n\tv392 = child.ashearX;\n\tv390 = child.ashearY;\nL_0134:\n\tSpine.Bone::UpdateWorldTransform(v404, v402, v400, v398, v396, v394, v392, v390);\n\treturn;\nL_013C:\n\tv643 = v572 * v226.length;\n\tv646 = targetX - v96.worldX;\n\tv651 = softness == 0;\n\tv656 = targetY - v96.worldY;\n\tv657 = v96.d * v646;\n\tv1141 = v96.b * v656;\n\tv659 = v96.a * v656;\n\tv660 = v96.c * v646;\n\tv661 = v657 - v1141;\n\tv662 = v659 - v660;\n\tv663 = v624 * v661;\n\tv664 = v624 * v662;\n\tv692 = v663 - parent.ax;\n\tv710 = v664 - parent.ay;\n\tv667 = v692 * v692;\n\tv668 = v710 * v710;\n\tv735 = v667 + v668;\n\tv729 = v712 * v643;\n\tif (v651) goto L_01A4;\n\tv674 = v572 + 1f;\n\tv675 = v712 * v674;\n\tv678 = v675 * 0.5f;\n\tv679 = v678 * softness;\n\tgoto L_016D;\n\tv750 = v175;\n\tv751 = v123;\n\tv752 = v120;\n\tv753 = \"il2cpp_codegen_runtime_class_init\"(v672, child, bendDir, stretch, methodInfo, v57, v58, v59, v678, v677, v663, v661, v658, v634, v192, v178);\n\tv755 = v751;\n\tv754 = v752;\n\tv757 = v671;\n\tv756 = v750;\nL_016D:\n\tv733 = UnityEngine.Mathf::Sqrt(v735);\n\tv787 = v733 - v992;\n\tv722 = v787 - v729;\n\tv788 = v679 + v722;\n\tv683 = v788 <= 0;\n\tif (v683) goto L_FFFFFFFF;\n\tgoto L_0188;\n\tv886 = \"il2cpp_codegen_runtime_class_init\"(v846, child, bendDir, stretch, methodInfo, v57, v58, v59, v722, v677, v663, v661, v658, v717, v192, v178);\nL_0188:\n\tv888 = v679 + v679;\n\tv889 = v788 / v888;\n\tv891 = System.Math::Min(1f, v889);\n\tv969 = v891 + -1f;\n\tv970 = v969 * v969;\n\tv972 = 1f - v970;\n\tv973 = v679 * v972;\n\tv974 = v788 - v973;\n\tv975 = v974 / v733;\n\tv976 = v692 * v975;\n\tv977 = v710 * v975;\n\tv692 = v692 - v976;\n\tv710 = v710 - v977;\n\tv978 = v692 * v692;\n\tv720 = v710 * v710;\n\tv723 = v978 + v720;\n\tgoto L_01A4;\nL_01A4:\n\tv739 = v686 < 0.0001f;\n\tv740 = ~v739;\n\tv741 = v686 - 0.0001f;\n\tv743 = v741 == 0;\n\tv748 = ~v743;\n\tv749 = v740 & v748;\n\tif (v749) goto L_0211;\n\tv759 = v820 * v820;\n\tv823 = v729 * v729;\n\tv761 = v820 + v820;\n\tv762 = v735 - v759;\n\tv821 = v761 * v729;\n\tv764 = v762 - v823;\n\tv765 = v764 / v821;\n\tv770 = v765 < -1f;\n\tif (v770) goto L_01F3;\n\tv795 = v765 - 1f;\n\tv796 = v795 < 0;\n\tv797 = v795 == 0;\n\tv798 = v765 ^ 1f;\n\tv799 = v765 ^ v795;\n\tv800 = v798 & v799;\n\tv801 = v800 < 0;\n\tv802 = v796 == v801;\n\tv803 = ~v802;\n\tv804 = v803 | v797;\n\tv805 = ~v804;\n\tif (v805) goto L_FFFFFFFF;\n\tgoto L_01D7;\nL_01D7:\n\tv809 = v765 <= 1f;\n\tif (v809) goto L_01F3;\n\tv831 = stretch == 0;\n\tif (v831) goto L_01F3;\n\tgoto L_01E3;\n\tv1107 = \"il2cpp_codegen_runtime_class_init\"(v1025, child, bendDir, stretch, methodInfo, v57, v58, v59, v765, v792, v763, v661, v658, v716, v192, v178);\n\tv1108 = v671;\nL_01E3:\n\tv1109 = UnityEngine.Mathf::Sqrt(v735);\n\tv1188 = v820 + v729;\n\tv1189 = v1109 / v1188;\n\tv1191 = v1189 + -1f;\n\tv1192 = v1191 * alpha;\n\tv826 = v1192 + 1f;\n\tv823 = parent.ascaleX * v826;\nL_01F3:\n\tgoto L_01F6;\n\tv851 = \"il2cpp_codegen_runtime_class_init\"(v837, child, bendDir, stretch, methodInfo, v57, v58, v59, v825, v823, v821, v661, v658, v819, v192, v178);\nL_01F6:\n\tv854 = 0x1854F40(System.Math, child, bendDir, stretch, methodInfo, v57, v58, v59, v832, v823, v821, v661, v1141, v820, parent.ax, parent.ay);\n\tv896 = v729 * v832;\n\tv415 = bendDir * v832;\n\tv899 = v992 + v896;\n\tv901 = 0x1854F60(v854, child, bendDir, stretch, methodInfo, v57, v58, v59, v415, bendDir, v896, v661, v1141, v820, parent.ax, parent.ay);\n\tv981 = v729 * v415;\n\tv982 = v710 * v899;\n\tv983 = v692 * v899;\n\tv1142 = v692 * v981;\n\tv985 = v710 * v981;\n\tv986 = v982 - v1142;\n\tv1144 = v983 + v985;\n\tv990 = 0x18550E0(v901, child, bendDir, stretch, methodInfo, v57, v58, v59, v986, v1144, v1144, v1142, v1141, v820, parent.ax, parent.ay);\n\tgoto L_0337;\nL_0211:\n\tv779 = v729 * v729;\n\tv781 = v142 * v643;\n\tv782 = v781 * v781;\n\tgoto L_021D;\n\tv841 = \"il2cpp_codegen_runtime_class_init\"(v776, child, bendDir, stretch, methodInfo, v57, v58, v59, v777, v778, v663, v661, v658, v716, v192, v178);\nL_021D:\n\tv845 = 0x18550E0(System.Math, child, bendDir, stretch, methodInfo, v57, v58, v59, v710, v692, v663, v661, v1141, v820, parent.ax, parent.ay);\n\tv856 = v779 * v735;\n\tv1142 = v779 * v782;\n\tv859 = v992 * v782;\n\tv860 = v992 * v859;\n\tv861 = v782 - v779;\n\tv862 = v860 + v856;\n\tv1141 = v782 * -2f;\n\tv866 = v992 * v1141;\n\tv867 = v862 - v1142;\n\tv868 = v861 * -4f;\n\tv870 = v866 * v866;\n\tv871 = v868 * v867;\n\tv872 = v870 + v871;\n\tv885 = v872 < 0;\n\tif (v885) goto L_0284;\n\tgoto L_0247;\n\tv991 = \"il2cpp_codegen_runtime_class_init\"(v902, child, bendDir, stretch, methodInfo, v57, v58, v59, v882, v870, v871, v858, v864, v855, v192, v178);\n\tv995 = System.Math;\n\tv993 = v671;\n\tv996 = *([v995 @ X0_v48+E0]);\nL_0247:\n\tv1199 = UnityEngine.Mathf::Sqrt(v872);\n\tv929 = -v1199;\n\tv1039 = v866 >= 0;\n\tif (v1039) goto L_0259;\n\tgoto L_0259;\nL_0259:\n\tv1201 = v866 + v1199;\n\tv1202 = v1201 * -0.5f;\n\tv939 = v1202 / v861;\n\tv1204 = v867 / v1202;\n\tgoto L_0262;\n\tv1238 = \"il2cpp_codegen_runtime_class_init\"(v994, child, bendDir, stretch, methodInfo, v57, v58, v59, v1202, v1200, v929, v858, v864, v992, v192, v178);\n\tv1239 = v671;\nL_0262:\n\tv1240 = UnityEngine.Mathf::Abs(v939);\n\tv931 = UnityEngine.Mathf::Abs(v1204);\n\tv909 = v1240 >= v931;\n\tif (v909) goto L_FFFFFFFF;\n\tgoto L_0274;\nL_0274:\n\tv941 = v939 * v939;\n\tv1391 = v941 < v735\n// ... truncated")]
		public static void Apply(Bone parent, Bone child, float targetX, float targetY, int bendDir, bool stretch, float softness, float alpha)
		{
			//IL_0b70: Expected O, but got F4
			//IL_0831: Expected O, but got F4
			//IL_083e: Expected O, but got F4
			float x;
			float y;
			float rotation;
			float scaleX;
			float scaleY;
			float shearX;
			float shearY;
			int num2;
			int num6;
			int num9;
			float num19;
			float num51;
			float num54;
			float scaleX2;
			float num96;
			float num105;
			float aX;
			float num106;
			float num107;
			float num140;
			float num141;
			float num144;
			float num149;
			float num150;
			float num151;
			if (alpha == 0f)
			{
				x = child.X;
				y = child.Y;
				rotation = child.Rotation;
				scaleX = child.ScaleX;
				scaleY = child.ScaleY;
				shearX = child.ShearX;
				shearY = child.ShearY;
				Bone bone = child;
			}
			else
			{
				if (!parent.appliedValid)
				{
					parent.Update();
				}
				if (!child.appliedValid)
				{
					child.Update();
				}
				float num = 0f - parent.AScaleX;
				num2 = ((parent.AScaleX < 0f) ? 1127481344 : 0);
				float num3 = 0f - parent.AScaleY;
				int num4 = ((!(parent.AScaleX < 0f)) ? 1 : (-1));
				float num5 = ((!(parent.AScaleX < 0f)) ? parent.AScaleX : num);
				num6 = ((!(parent.AScaleY < 0f)) ? num4 : (-num4));
				float num7 = ((!(parent.AScaleY < 0f)) ? parent.AScaleY : num3);
				float num8 = 0f - child.AScaleX;
				num9 = ((child.AScaleX < 0f) ? 1127481344 : 0);
				if (!(child.AScaleX < 0f))
				{
					num8 = child.AScaleX;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
				float num10 = child.AX * parent.A;
				float num11 = child.AX * parent.C;
				object obj = default(object);
				bool flag = (float)obj < 0.0001f;
				bool flag2 = !flag;
				float num12 = (float)obj - 0.0001f;
				bool flag3 = num12 == 0f;
				bool flag4 = !flag3;
				float num17;
				float num18;
				if (!(flag2 && flag4))
				{
					float num13 = parent.B * child.AY;
					float num14 = parent.D * child.AY;
					float num15 = num10 + num13;
					float num16 = num11 + num14;
					num17 = parent.WorldX + num15;
					num18 = num16 + parent.WorldY;
					num19 = child.AY;
				}
				else
				{
					num17 = num10 + parent.WorldX;
					num18 = num11 + parent.WorldY;
					num19 = 0f;
				}
				Bone parent2 = parent.Parent;
				BoneData boneData = child.Data;
				float num20 = parent2.A * parent2.D;
				float num21 = parent2.B * parent2.C;
				float num22 = num17 - parent2.WorldX;
				float num23 = num18 - parent2.WorldY;
				float num24 = num20 - num21;
				float num25 = parent2.A * num23;
				float num26 = parent2.C * num22;
				float num27 = parent2.D * num22;
				float num28 = parent2.B * num23;
				float num29 = 1f / num24;
				float num30 = num25 - num26;
				float num31 = num27 - num28;
				float num32 = num29 * num30;
				float num33 = num29 * num31;
				float num34 = num32 - parent.AY;
				float num35 = num33 - parent.AX;
				float num36 = num35 * num35;
				float num37 = num34 * num34;
				float f = num36 + num37;
				float num38 = Mathf.Sqrt(f);
				Bone bone;
				if (!(num38 < 0.0001f))
				{
					float num39 = num8 * boneData.Length;
					float num40 = targetX - parent2.WorldX;
					bool flag5 = softness == 0f;
					float num41 = targetY - parent2.WorldY;
					float num42 = parent2.D * num40;
					float num43 = parent2.B * num41;
					float num44 = parent2.A * num41;
					float num45 = parent2.C * num40;
					float num46 = num42 - num43;
					float num47 = num44 - num45;
					float num48 = num29 * num46;
					float num49 = num29 * num47;
					float num50 = num48 - parent.AX;
					num51 = num49 - parent.AY;
					float num52 = num50 * num50;
					float num53 = num51 * num51;
					num54 = num52 + num53;
					float num55 = num5 * num39;
					float num56 = num38;
					if (!flag5)
					{
						float num57 = num8 + 1f;
						float num58 = num5 * num57;
						float num59 = num58 * 0.5f;
						float num60 = num59 * softness;
						float num61 = Mathf.Sqrt(num54);
						float num62 = num61 - num38;
						float num63 = num62 - num55;
						float num64 = num60 + num63;
						if (num64 > 0f)
						{
							float num65 = num60 + num60;
							float val = num64 / num65;
							float num66 = Math.Min(1f, val);
							float num67 = num66 + -1f;
							float num68 = num67 * num67;
							float num69 = 1f - num68;
							float num70 = num60 * num69;
							float num71 = num64 - num70;
							float num72 = num71 / num61;
							float num73 = num50 * num72;
							float num74 = num51 * num72;
							num50 -= num73;
							num51 -= num74;
							float num75 = num50 * num50;
							float num76 = num51 * num51;
							float num77 = num75 + num76;
							num56 = num38;
							num54 = num77;
						}
						else
						{
							num56 = num38;
						}
					}
					bool flag6 = (float)obj < 0.0001f;
					bool flag7 = !flag6;
					float num78 = (float)obj - 0.0001f;
					bool flag8 = num78 == 0f;
					bool flag9 = !flag8;
					float num101;
					float num104;
					if (!(flag7 && flag9))
					{
						float num79 = num56 * num56;
						float num80 = num55 * num55;
						float num81 = num56 + num56;
						float num82 = num54 - num79;
						float num83 = num81 * num55;
						float num84 = num82 - num80;
						float num85 = num84 / num83;
						bool flag10 = num85 < -1f;
						scaleX2 = parent.AScaleX;
						float num86 = -1f;
						if (!flag10)
						{
							float num87 = num85 - 1f;
							bool flag11 = num87 < 0f;
							bool flag12 = num87 == 0f;
							object obj2 = num85 ^ 1f;
							object obj3 = num85 ^ num87;
							int num88 = (int)((nint)obj2 & (nint)obj3);
							bool flag13 = num88 < 0;
							bool flag14 = flag11 == flag13;
							bool flag15 = !flag14;
							num86 = ((!(flag15 || flag12)) ? 1f : num85);
							bool flag16 = !(num85 > 1f);
							scaleX2 = parent.AScaleX;
							num80 = 1f;
							if (!flag16)
							{
								bool flag17 = !stretch;
								scaleX2 = parent.AScaleX;
								num80 = 1f;
								if (!flag17)
								{
									float num89 = Mathf.Sqrt(num54);
									float num90 = num56 + num55;
									float num91 = num89 / num90;
									float num92 = num91 + -1f;
									float num93 = num92 * alpha;
									float num94 = num93 + 1f;
									num80 = parent.AScaleX * num94;
									scaleX2 = num80;
									num83 = -1f;
									num86 = 1f;
								}
							}
						}
						Il2CppRuntime.Boundary("SYSTEM_API:acos", "Method not found @1854F40 (native acos)");
						float num95 = num55 * num86;
						num96 = (float)bendDir * num86;
						float num97 = num38 + num95;
						Il2CppRuntime.Boundary("SYSTEM_API:sin", "Method not found @1854F60 (native sin)");
						float num98 = num55 * num96;
						float num99 = num51 * num97;
						float num100 = num50 * num97;
						num101 = num50 * num98;
						float num102 = num51 * num98;
						float num103 = num99 - num101;
						num104 = num100 + num102;
						Il2CppRuntime.Boundary("SYSTEM_API:atan2", "Method not found @18550E0 (native atan2)");
						bone = child;
						num105 = num19;
						aX = child.AX;
						num106 = alpha;
						num107 = num103;
						goto IL_0f61;
					}
					float num108 = num55 * num55;
					float num109 = num7 * num39;
					float num110 = num109 * num109;
					Il2CppRuntime.Boundary("SYSTEM_API:atan2", "Method not found @18550E0 (native atan2)");
					float num111 = num108 * num54;
					num101 = num108 * num110;
					float num112 = num38 * num110;
					float num113 = num38 * num112;
					float num114 = num110 - num108;
					float num115 = num113 + num111;
					num43 = num110 * -2f;
					float num116 = num38 * num43;
					float num117 = num115 - num101;
					float num118 = num114 * -4f;
					float num119 = num116 * num116;
					float num120 = num118 * num117;
					float num121 = num119 + num120;
					bool flag18 = num121 < 0f;
					num56 = num38;
					if (!flag18)
					{
						float num122 = Mathf.Sqrt(num121);
						float num123 = 0f - num122;
						if (num116 < 0f)
						{
							num122 = num123;
						}
						float num124 = num116 + num122;
						float num125 = num124 * -0.5f;
						float num126 = num125 / num114;
						float num127 = num117 / num125;
						num56 = num38;
						float num128 = Mathf.Abs(num126);
						float num129 = Mathf.Abs(num127);
						if (!(num128 < num129))
						{
							num126 = num127;
						}
						float num130 = num126 * num126;
						bool flag19 = num130 < num54;
						bool flag20 = !flag19;
						float num131 = num130 - num54;
						bool flag21 = num131 == 0f;
						bool flag22 = !flag20;
						if (flag22 || flag21)
						{
							float f2 = num54 - num130;
							float num132 = Mathf.Sqrt(f2);
							float num133 = num132 * (float)bendDir;
							Il2CppRuntime.Boundary("SYSTEM_API:atan2", "Method not found @18550E0 (native atan2)");
							float num134 = num133 / num7;
							num104 = num126 - num38;
							num107 = num51 - num133;
							float num135 = num104 / num5;
							Il2CppRuntime.Boundary("SYSTEM_API:atan2", "Method not found @18550E0 (native atan2)");
							bone = child;
							aX = child.AX;
							num106 = alpha;
							num101 = num51;
							num96 = num134;
							goto IL_14f7;
						}
					}
					float num136 = num108 - num110;
					float num137 = num56 - num55;
					float num138 = num56 + num55;
					object obj4 = 0f - num55;
					float num139 = num56 * (float)obj4;
					num140 = num139 / num136;
					num141 = num137 * num137;
					float num142 = num138 * num138;
					float num146;
					if (!(num140 < -1f))
					{
						bool flag23 = num140 < 1f;
						bool flag24 = !flag23;
						float num143 = num140 - 1f;
						bool flag25 = num143 == 0f;
						bool flag26 = !flag25;
						if (!(flag24 && flag26))
						{
							Il2CppRuntime.Boundary("SYSTEM_API:acos", "Method not found @1854F40 (native acos)");
							Il2CppRuntime.Boundary("SYSTEM_API:sincos", "Method not found @1855120 (native sincos)");
							object obj5 = default(object);
							num144 = num109 * (float)obj5;
							object obj6 = default(object);
							float num145 = num55 * (float)obj6;
							num146 = num38 + num145;
							float num147 = num146 * num146;
							float num148 = num144 * num144;
							num149 = num148 + num147;
							if (num149 < num141)
							{
								num150 = num140;
								num137 = num146;
								num141 = num149;
								num151 = num144;
							}
							else
							{
								num150 = (float)Math.PI;
								num151 = 0f;
							}
							bool flag27 = num149 > num142;
							bone = (Bone)obj6;
							num104 = num55;
							if (!flag27)
							{
								bone = (Bone)obj6;
								num140 = 0f;
								num144 = 0f;
								num104 = num55;
								num149 = num142;
								num146 = num138;
							}
							goto IL_14d3;
						}
					}
					bone = child;
					num140 = 0f;
					num144 = 0f;
					num150 = (float)Math.PI;
					num104 = (float)Math.PI;
					num149 = num142;
					num146 = num138;
					num151 = 0f;
					goto IL_14d3;
				}
				Apply(parent, targetX, targetY, compress: false, stretch, uniform: false, alpha);
				scaleX = child.AScaleX;
				scaleY = child.AScaleY;
				shearX = child.AShearX;
				shearY = child.AShearY;
				bone = null;
				rotation = 0f;
				y = num19;
				x = child.AX;
			}
			Bone bone2 = child;
			goto IL_1761;
			IL_1526:
			float num153;
			float num152 = num153 * num106;
			float rotation2 = parent.AppliedRotation + num152;
			float aX2;
			float aY;
			parent.UpdateWorldTransform(aX2, aY, rotation2, scaleX2, parent.AScaleY, 0f, 0f);
			shearX = child.AShearX;
			float num155;
			float num154 = num96 + num155;
			float num156 = num154 * (180f / (float)Math.PI);
			float num157 = num156 - child.AShearX;
			float num158 = num157 * (float)num6;
			int num160;
			float num159 = (float)num160 + num158;
			float num161 = num159 - child.AppliedRotation;
			int num162;
			if (num161 > 180f)
			{
				num162 = -1011613696;
			}
			else
			{
				if (!(num161 < -180f))
				{
					goto IL_1620;
				}
				num162 = 1135869952;
			}
			num161 += (float)num162;
			goto IL_1620;
			IL_1620:
			scaleX = child.AScaleX;
			scaleY = child.AScaleY;
			shearY = child.AShearY;
			float num163 = num161 * num106;
			rotation = child.AppliedRotation + num163;
			y = num105;
			x = aX;
			bone2 = child;
			goto IL_1761;
			IL_0f61:
			Il2CppRuntime.Boundary("SYSTEM_API:atan2", "Method not found @18550E0 (native atan2)");
			num155 = (float)num6 * num105;
			float num164 = num107 - num155;
			float num165 = num164 * (180f / (float)Math.PI);
			float num166 = (float)num2 + num165;
			num153 = num166 - parent.AppliedRotation;
			int num167;
			if (num153 > 180f)
			{
				aY = parent.AY;
				aX2 = parent.AX;
				num160 = num9;
				num167 = -1011613696;
			}
			else
			{
				bool flag28 = !(num153 < -180f);
				aY = parent.AY;
				aX2 = parent.AX;
				num160 = num9;
				if (flag28)
				{
					goto IL_1526;
				}
				aY = parent.AY;
				aX2 = parent.AX;
				num160 = num9;
				num167 = 1135869952;
			}
			num153 += (float)num167;
			goto IL_1526;
			IL_14d3:
			float num168 = num149 + num141;
			float num169 = num168 * 0.5f;
			bool flag29 = num54 < num169;
			bool flag30 = !flag29;
			float num170 = num54 - num169;
			bool flag31 = num170 == 0f;
			bool flag32 = !flag30;
			if (!(flag32 || flag31))
			{
				float num171 = num144 * (float)bendDir;
				Il2CppRuntime.Boundary("SYSTEM_API:atan2", "Method not found @18550E0 (native atan2)");
				num96 = num140 * (float)bendDir;
				num107 = num51 - num171;
				aX = child.AX;
				num106 = alpha;
			}
			else
			{
				float num172 = num151 * (float)bendDir;
				Il2CppRuntime.Boundary("SYSTEM_API:atan2", "Method not found @18550E0 (native atan2)");
				num107 = num51 - num172;
				num96 = num150 * (float)bendDir;
				aX = child.AX;
				num106 = alpha;
			}
			goto IL_14f7;
			IL_14f7:
			scaleX2 = parent.AScaleX;
			num105 = num19;
			goto IL_0f61;
			IL_1761:
			bone2.UpdateWorldTransform(x, y, rotation, scaleX, scaleY, shearX, shearY);
		}
	}
}
