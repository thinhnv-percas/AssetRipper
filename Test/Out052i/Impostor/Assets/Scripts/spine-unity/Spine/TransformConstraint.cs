using System;
using System.Collections;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine
{
	[Token(Token = "0x2000062")]
	public class TransformConstraint : IUpdatable
	{
		[Token(Token = "0x4000279")]
		[FieldOffset(Offset = "0x10")]
		internal TransformConstraintData data;

		[Token(Token = "0x400027A")]
		[FieldOffset(Offset = "0x18")]
		internal ExposedList<Bone> bones;

		[Token(Token = "0x400027B")]
		[FieldOffset(Offset = "0x20")]
		internal Bone target;

		[Token(Token = "0x400027C")]
		[FieldOffset(Offset = "0x28")]
		internal float rotateMix;

		[Token(Token = "0x400027D")]
		[FieldOffset(Offset = "0x2C")]
		internal float translateMix;

		[Token(Token = "0x400027E")]
		[FieldOffset(Offset = "0x30")]
		internal float scaleMix;

		[Token(Token = "0x400027F")]
		[FieldOffset(Offset = "0x34")]
		internal float shearMix;

		[Token(Token = "0x4000280")]
		[FieldOffset(Offset = "0x38")]
		internal bool active;

		[Token(Token = "0x17000157")]
		public ExposedList<Bone> Bones
		{
			[Token(Token = "0x600043F")]
			[Address(RVA = "0x154FA98", Offset = "0x154FA98", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.bones;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Bones;
			}
		}

		[Token(Token = "0x17000158")]
		public Bone Target
		{
			[Token(Token = "0x6000440")]
			[Address(RVA = "0x154FAA0", Offset = "0x154FAA0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.target;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Target;
			}
			[Token(Token = "0x6000441")]
			[Address(RVA = "0x154FAA8", Offset = "0x154FAA8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.target = value;\n\treturn;\n")]
			set
			{
				Target = value;
			}
		}

		[Token(Token = "0x17000159")]
		public float RotateMix
		{
			[Token(Token = "0x6000442")]
			[Address(RVA = "0x154FAB0", Offset = "0x154FAB0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.rotateMix;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RotateMix;
			}
			[Token(Token = "0x6000443")]
			[Address(RVA = "0x154FAB8", Offset = "0x154FAB8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.rotateMix = value;\n\treturn;\n")]
			set
			{
				RotateMix = value;
			}
		}

		[Token(Token = "0x1700015A")]
		public float TranslateMix
		{
			[Token(Token = "0x6000444")]
			[Address(RVA = "0x154FAC0", Offset = "0x154FAC0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.translateMix;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return TranslateMix;
			}
			[Token(Token = "0x6000445")]
			[Address(RVA = "0x154FAC8", Offset = "0x154FAC8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.translateMix = value;\n\treturn;\n")]
			set
			{
				TranslateMix = value;
			}
		}

		[Token(Token = "0x1700015B")]
		public float ScaleMix
		{
			[Token(Token = "0x6000446")]
			[Address(RVA = "0x154FAD0", Offset = "0x154FAD0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.scaleMix;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ScaleMix;
			}
			[Token(Token = "0x6000447")]
			[Address(RVA = "0x154FAD8", Offset = "0x154FAD8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.scaleMix = value;\n\treturn;\n")]
			set
			{
				ScaleMix = value;
			}
		}

		[Token(Token = "0x1700015C")]
		public float ShearMix
		{
			[Token(Token = "0x6000448")]
			[Address(RVA = "0x154FAE0", Offset = "0x154FAE0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.shearMix;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ShearMix;
			}
			[Token(Token = "0x6000449")]
			[Address(RVA = "0x154FAE8", Offset = "0x154FAE8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.shearMix = value;\n\treturn;\n")]
			set
			{
				ShearMix = value;
			}
		}

		[Token(Token = "0x1700015D")]
		public bool Active
		{
			[Token(Token = "0x600044A")]
			[Address(RVA = "0x154FAF0", Offset = "0x154FAF0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.active;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Active;
			}
		}

		[Token(Token = "0x1700015E")]
		public TransformConstraintData Data
		{
			[Token(Token = "0x600044B")]
			[Address(RVA = "0x154FAF8", Offset = "0x154FAF8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.data;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Data;
			}
		}

		[Token(Token = "0x6000437")]
		[Address(RVA = "0x154E754", Offset = "0x154E754", Length = "0x29C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv28 = Il2CppMethodInfo;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, data, skeleton, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv53 = Il2CppMethodInfo;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, data, skeleton, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv57 = Il2CppMethodInfo;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, data, skeleton, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv120 = Il2CppMethodInfo;\n\tv121 = \"il2cpp_codegen_initialize_runtime_metadata\"(v120, data, skeleton, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv134 = Il2CppMethodInfo;\n\tv135 = \"il2cpp_codegen_initialize_runtime_metadata\"(v134, data, skeleton, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv144 = Il2CppMethodInfo;\n\tv145 = \"il2cpp_codegen_initialize_runtime_metadata\"(v144, data, skeleton, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv156 = Spine.ExposedList`1<Spine.Bone>;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v156, data, skeleton, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A37BBD]) = v46;\nL_002B:\n\tv49 = 0;\n\tSystem.Object::.ctor(this);\n\tv55 = data == 0;\n\tif (v55) goto L_007E;\n\tv59 = skeleton == 0;\n\tif (v59) goto L_008A;\n\tthis.data = data;\n\tthis.rotateMix = data.rotateMix;\n\tv128 = new Spine.ExposedList`1<Spine.Bone>();\n\tSpine.ExposedList`1<Spine.Bone>::.ctor(v128);\n\tthis.bones = v128;\n\tv167 = Spine.ExposedList`1<Spine.BoneData>::GetEnumerator(data.bones);\nL_0050:\n\tv238 = Spine.ExposedList`1<System.Object>+Enumerator<System.Object>::MoveNext(&v49 @ stack_-58_v1 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv244 = v238 == 0;\n\tif (v244) goto L_0065;\n\tv194 = 0;\n\tv257 = Spine.Skeleton::FindBone(skeleton, *([v194 @ X8_v17 (System.Int32)+18]));\n\tSpine.ExposedList`1<Spine.Bone>::Add(this.bones, v257);\n\tgoto L_0050;\nL_0065:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v49 @ stack_-58_v1 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\nL_0066:\n\tv195 = data.target;\n\tv279 = Spine.Skeleton::FindBone(skeleton, v195.name);\n\t*([this @ X0 (Spine.TransformConstraint)+20]) = v279;\n\treturn;\n\tv258 = new System.NullReferenceException();\n\tv188 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_007E:\n\tv132 = new System.ArgumentNullException();\n\tgoto L_0097;\nL_008A:\n\tv138 = new System.ArgumentNullException();\nL_0097:\n\tSystem.ArgumentNullException::.ctor(v220, v221, v218);\n\tthrow v220;\n\tgoto L_00AA;\n\tgoto L_00AA;\nL_00AA:\n\tv260 = Il2CppMethodInfo != 1;\n\tif (v260) goto L_00B9;\n\tv289 = 0x1854E70(v253, Il2CppMethodInfo, v218, 0, v31, v32, v33, v34, v217, v36, v37, v38, v39, v40, v41, v42);\n\tv274 = *([v289 @ X0_v19]);\n\tv327 = 0x1854E80(v289, Il2CppMethodInfo, v218, 0, v31, v32, v33, v34, v217, v36, v37, v38, v39, v40, v41, v42);\n\tv269 = *([v213 @ X23_v1]);\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v49 @ stack_-58_v1 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>), v269);\n\tv272 = v274 == 0;\n\tif (v272) goto L_0066;\n\tv293 = new System.OutOfMemoryException();\nL_00B9:\n\tgoto L_00BB;\n\tX19 = X0;\nL_00BB:\n\tv315 = *([v213 @ X23_v1]);\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v49 @ stack_-58_v1 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>), v315);\n\tif (-2) goto L_00C5;\n\tv332 = 0xBD3CD0(v292, v315, v218, 0, v31, v32, v33, v34, v217, v36, v37, v38, v39, v40, v41, v42);\nL_00C5:\n\tv335 = new System.OutOfMemoryException();\n\tv318 = 0x9DACB4(v335, v315, v218, 0, v31, v32, v33, v34, v217, v36, v37, v38, v39, v40, v41, v42);\n\treturn;\n// 130 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TransformConstraint(TransformConstraintData data, Skeleton skeleton)
		{
			//IL_00c3: Expected O, but got I
			base._002Ector();
			ExposedList<object>.Enumerator enumerator = default(ExposedList<object>.Enumerator);
			ArgumentNullException ex2;
			if (data != null)
			{
				if (skeleton != null)
				{
					this.data = data;
					RotateMix = data.RotateMix;
					ExposedList<Bone> exposedList = new ExposedList<Bone>();
					bones = exposedList;
					ExposedList<BoneData>.Enumerator enumerator2 = data.Bones.GetEnumerator();
					while (enumerator.MoveNext())
					{
						int num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ X8_v17 (System.Int32)+18]");
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

		[Token(Token = "0x6000438")]
		[Address(RVA = "0x154E9F0", Offset = "0x154E9F0", Length = "0x2EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, constraint, skeleton, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv51 = Il2CppMethodInfo;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, constraint, skeleton, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv55 = Il2CppMethodInfo;\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, constraint, skeleton, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv125 = Il2CppMethodInfo;\n\tv126 = \"il2cpp_codegen_initialize_runtime_metadata\"(v125, constraint, skeleton, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv135 = Il2CppMethodInfo;\n\tv136 = \"il2cpp_codegen_initialize_runtime_metadata\"(v135, constraint, skeleton, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv209 = Il2CppMethodInfo;\n\tv210 = \"il2cpp_codegen_initialize_runtime_metadata\"(v209, constraint, skeleton, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv241 = Spine.ExposedList`1<Spine.Bone>;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v241, constraint, skeleton, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 1;\n\t*([1A37BBE]) = v44;\nL_002D:\n\tSystem.Object::.ctor(this);\n\tv53 = constraint == 0;\n\tif (v53) goto L_00B0;\n\tv57 = skeleton == 0;\n\tif (v57) goto L_00B8;\n\tthis.data = constraint.data;\n\tv128 = constraint.bones;\n\tv143 = new Spine.ExposedList`1<Spine.Bone>();\n\tSpine.ExposedList`1<Spine.Bone>::.ctor(v143, v128.Count);\n\tthis.bones = v143;\n\tv252 = Spine.ExposedList`1<Spine.Bone>::GetEnumerator(constraint.bones);\nL_0057:\n\tv292 = Spine.ExposedList`1<System.Object>+Enumerator<System.Object>::MoveNext(&v171 @ stack_-78_v6 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv330 = v292 == 0;\n\tif (v330) goto L_007E;\n\tv331 = skeleton.bones;\n\tv388 = *([v257 @ stack_-68+10]);\n\tv407 = v331.Items;\n\tv284 = *([v388 @ X9_v16+10]);\n\tSpine.ExposedList`1<Spine.Bone>::Add(this.bones, v407[v284 @ X9_v19]);\n\tgoto L_0057;\nL_007E:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v171 @ stack_-78_v6 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\nL_007F:\n\tv200 = skeleton.bones;\n\tv186 = v325._data;\n\tv187 = *([v186 @ X9_v6 (System.Collections.IDictionary)+10]);\n\tv201 = v200.Items;\n\tv322 = *([v187 @ X9_v7+10]);\n\tv434 = *([v187 @ X9_v7+10]) < v201.Length;\n\tv310 = ~v434;\n\tif (v310) goto L_00C7;\n\tthis.target = v201[v322 @ X9_v8];\n\tthis.rotateMix = v325._innerException;\n\treturn;\n\tv420 = new System.NullReferenceException();\n\tv423 = new System.NullReferenceException();\n\tv368 = new System.NullReferenceException();\n\tv373 = new System.NullReferenceException();\n\tv403 = new System.NullReferenceException();\n\tv189 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\nL_00B0:\n\tv133 = new System.ArgumentNullException();\n\tgoto L_00C0;\nL_00B8:\n\tv204 = new System.ArgumentNullException();\nL_00C0:\n\tSystem.ArgumentNullException::.ctor(v325, v234);\n\tthrow v325;\nL_00C7:\n\tv328 = new System.IndexOutOfRangeException();\n\tgoto L_00D7;\n\tgoto L_00D7;\n\tgoto L_00D7;\n\tgoto L_00D7;\n\tgoto L_00D7;\n\tgoto L_00D7;\nL_00D7:\n\tv344 = v318 != 1;\n\tif (v344) goto L_00E5;\n\tv380 = 0x1854E70(v328, v318, v319, methodInfo, v29, v30, v31, v32, v171, v34, v35, v36, v37, v38, v39, v40);\n\tv404 = 0x1854E80(v380, v318, v319, methodInfo, v29, v30, v31, v32, v171, v34, v35, v36, v37, v38, v39, v40);\n\tv318 = *([v320 @ X23_v2 (Il2CppMethodInfo)]);\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v94 @ stack_-60_v5 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv377 = *([v380 @ X0_v21]) == 0;\n\tif (v377) goto L_007F;\n\tv383 = new System.OutOfMemoryException();\nL_00E5:\n\tgoto L_00E9;\n\tX19 = X0;\nL_00E9:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v94 @ stack_-60_v5 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_00F0;\n\tv430 = 0xBD3CD0(v328, *([v320 @ X23_v2 (Il2CppMethodInfo)]), v319, methodInfo, v29, v30, v31, v32, v171, v34, v35, v36, v37, v38, v39, v40);\nL_00F0:\n\tv433 = new System.OutOfMemoryException();\n\tv436 = 0x9DACB4(v433, *([v320 @ X23_v2 (Il2CppMethodInfo)]), v319, methodInfo, v29, v30, v31, v32, v171, v34, v35, v36, v37, v38, v39, v40);\n\treturn;\n// 158 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TransformConstraint(TransformConstraint constraint, Skeleton skeleton)
		{
			//IL_022f: Expected I, but got O
			//IL_0051: Expected O, but got I4
			//IL_00a9: Expected O, but got I
			//IL_0156: Expected O, but got I
			//IL_00d0: Expected O, but got I
			//IL_017d: Expected O, but got I
			//IL_01d1: Expected F4, but got O
			base._002Ector();
			ArgumentNullException ex;
			nint num2;
			nint num;
			if (constraint != null)
			{
				ExposedList<object>.Enumerator enumerator3;
				if (skeleton != null)
				{
					data = constraint.Data;
					bones = new ExposedList<Bone>((IEnumerable<Bone>)constraint.Bones.Count);
					ExposedList<Bone>.Enumerator enumerator = constraint.Bones.GetEnumerator();
					num = 0;
					ExposedList<object>.Enumerator enumerator2 = default(ExposedList<object>.Enumerator);
					while (enumerator2.MoveNext())
					{
						ExposedList<Bone> exposedList = skeleton.Bones;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ stack_-68+10]");
						object obj = 0;
						Bone[] items = exposedList.Items;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v388 @ X9_v16+10]");
						object obj2 = 0;
						Bones.Add(items[obj2]);
						num = 0;
					}
					enumerator2.Dispose();
					enumerator3 = enumerator2;
					num2 = 0;
					nint num3 = 0;
					ex = (ArgumentNullException)(object)constraint;
					object obj5 = default(object);
					while (true)
					{
						ExposedList<Bone> exposedList2 = skeleton.Bones;
						IDictionary dictionary = ((Exception)ex)._data;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ X9_v6 (System.Collections.IDictionary)+10]");
						object obj3 = 0;
						Bone[] items2 = exposedList2.Items;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ X9_v7+10]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ X9_v7+10]");
						if ((nint)0 < (nint)items2.Length)
						{
							Target = items2[obj4];
							RotateMix = (float)ex.InnerException;
							return;
						}
						IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
						if (num2 == 1)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E70 (native __cxa_begin_catch)");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E80 (native __cxa_end_catch)");
							num2 = num3;
							enumerator3.Dispose();
							if (obj5 != null)
							{
								ex2 = (IndexOutOfRangeException)(object)new OutOfMemoryException();
								break;
							}
							continue;
						}
						break;
					}
					enumerator3.Dispose();
					OutOfMemoryException ex3 = new OutOfMemoryException();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @9DACB4");
					return;
				}
				ArgumentNullException ex4 = new ArgumentNullException();
				enumerator3 = default(ExposedList<object>.Enumerator);
				string text = "skeleton cannot be null.";
				ex = ex4;
			}
			else
			{
				ArgumentNullException ex5 = new ArgumentNullException();
				string text = "constraint cannot be null.";
				ex = ex5;
			}
			num2 = 0;
			num = unchecked((nint)null);
			throw ex;
		}

		[Token(Token = "0x6000439")]
		[Address(RVA = "0x154ECDC", Offset = "0x154ECDC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.TransformConstraint::Update(this);\n\treturn;\n")]
		public void Apply()
		{
			Update();
		}

		[Token(Token = "0x600043A")]
		[Address(RVA = "0x154ECE0", Offset = "0x154ECE0", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.data;\n\tv7 = ~v2.local;\n\tif (v7) goto L_000F;\n\tv24 = ~v2.relative;\n\tif (v24) goto L_0017;\n\tSpine.TransformConstraint::ApplyRelativeLocal(this);\n\treturn;\nL_000F:\n\tv25 = ~v2.relative;\n\tif (v25) goto L_001B;\n\tSpine.TransformConstraint::ApplyRelativeWorld(this);\n\treturn;\nL_0017:\n\tSpine.TransformConstraint::ApplyAbsoluteLocal(this);\n\treturn;\nL_001B:\n\tSpine.TransformConstraint::ApplyAbsoluteWorld(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Update()
		{
			TransformConstraintData transformConstraintData = Data;
			if (transformConstraintData.Local)
			{
				if (transformConstraintData.Relative)
				{
					Apply();
				}
				else
				{
					Apply();
				}
			}
			else if (transformConstraintData.Relative)
			{
				Apply();
			}
			else
			{
				Apply();
			}
		}

		[Token(Token = "0x600043B")]
		[Address(RVA = "0x154F57C", Offset = "0x154F57C", Length = "0x51C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv46 = Spine.MathUtils;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv71 = System.Math;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv66 = 1;\n\t*([1A37BBF]) = v66;\nL_0024:\n\tv68 = this.target;\n\tv76 = this.data;\n\tv81 = v68.a * v68.d;\n\tv82 = v68.b * v68.c;\n\tv83 = v81 - v82;\n\tv87 = v83 < 0;\n\tv88 = v83 == 0;\n\tv90 = v83 ^ v83;\n\tv91 = v83 & v90;\n\tv92 = v91 < 0;\n\tv93 = v87 == v92;\n\tv94 = ~v88;\n\tv95 = v93 & v94;\n\tv209 = this.bones;\n\tv428 = v209.Count < 1;\n\tif (v428) goto L_0225;\n\tv436 = 0x407000 + 0x6A0;\n\tv437 = v68.a * v68.a;\n\tv438 = v68.c * v68.c;\n\tv442 = v437 + v438;\n\tv445 = v68.b * v68.b;\n\tv446 = v68.d * v68.d;\n\tv448 = v445 + v446;\n\tv453 = *([v436 @ X9_v6 (System.Int32)+v95 @ TEMPCOND_v4 (System.Boolean)*4]) * v76.offsetRotation;\n\tv454 = *([v436 @ X9_v6 (System.Int32)+v95 @ TEMPCOND_v4 (System.Boolean)*4]) * v76.offsetShearY;\n\tv458 = UnityEngine.Mathf::Sqrt(v442);\n\tv623 = this.rotateMix == 0;\n\tv629 = ~v623;\n\tv630 = UnityEngine.Mathf::Sqrt(v448);\nL_008A:\n\tv343 = v209.Items;\n\tv148 = v343[v171 @ X23_v6 (System.Int32)];\n\tv257 = this.rotateMix == 0;\n\tif (v257) goto L_00F8;\n\tgoto L_00B4;\n\tv684 = \"il2cpp_codegen_runtime_class_init\"(v670, v121, v112, v104, v51, v52, v53, v54, v672, v671, v307, v304, v200, v197, v195, v193);\nL_00B4:\n\tv689 = Spine.MathUtils::Atan2(v68.c, v68.a);\n\tv697 = Spine.MathUtils::Atan2(v148.c, v148.a);\n\tv705 = v689 - v697;\n\tv636 = v453 + v705;\n\tv719 = v636 <= 3.1415927f;\n\tif (v719) goto L_00D7;\n\tgoto L_00DA;\nL_00D7:\n\tv819 = v636 >= -3.1415927f;\n\tif (v819) goto L_00DF;\nL_00DA:\n\tv636 = v636 + v858;\nL_00DF:\n\tgoto L_00E1;\n\tv889 = \"il2cpp_codegen_runtime_class_init\"(v862, v121, v112, v104, v51, v52, v53, v54, v861, v704, v307, v304, v200, v197, v195, v193);\nL_00E1:\n\tv637 = this.rotateMix * v636;\n\tv893 = Spine.MathUtils::Cos(v637);\n\tv904 = Spine.MathUtils::Sin(v637);\n\tv660 = v148.c * v917;\n\tv918 = v148.a * v919;\n\tv920 = v148.a * v917;\n\tv659 = v148.c * v919;\n\tv662 = v918 - v660;\n\tv661 = v659 + v920;\n\tv148.a = v662;\n\tv148.c = v661;\nL_00F8:\n\tv258 = v780 == 0;\n\tif (v258) goto L_0123;\n\tv345 = this.data;\n\tSpine.Bone::LocalToWorld(v68, v345.offsetX, v345.offsetY, &v118 @ stack_-54_v6 (System.Single), &v109 @ stack_-58_v7 (System.Single));\n\tv722 = v118 - v148.worldX;\n\tv678 = v780 * v722;\n\tv723 = v148.worldX + v678;\n\tv148.worldX = v723;\n\tv725 = v109 - v148.worldY;\n\tv726 = v780 * v725;\n\tv677 = v148.worldY + v726;\n\tv148.worldY = v677;\nL_0123:\n\tv216 = this.scaleMix <= 0;\n\tif (v216) goto L_0198;\n\tgoto L_012F;\n\tv727 = \"il2cpp_codegen_runtime_class_init\"(v698, v123, v114, v106, v51, v52, v53, v54, v314, v321, v309, v305, v201, v198, v195, v193);\nL_012F:\n\tv729 = v148.a * v148.a;\n\tv322 = v148.c * v148.c;\n\tv315 = v729 + v322;\n\tv868 = UnityEngine.Mathf::Sqrt(v315);\n\tv260 = v868 == 0;\n\tif (v260) goto L_0151;\n\tgoto L_0143;\n\tv894 = \"il2cpp_codegen_runtime_class_init\"(v864, v123, v114, v106, v51, v52, v53, v54, v315, v322, v309, v305, v201, v198, v195, v193);\nL_0143:\n\tv347 = this.data;\n\tv873 = v458 - v868;\n\tv907 = v873 + v347.offsetScaleX;\n\tv908 = this.scaleMix * v907;\n\tv871 = v868 + v908;\n\tv868 = v871 / v868;\nL_0151:\n\tv879 = v868 * v148.a;\n\tv880 = v868 * v148.c;\n\tv148.a = v879;\n\tv148.c = v880;\n\tgoto L_015B;\n\tv895 = \"il2cpp_codegen_runtime_class_init\"(v881, v123, v114, v106, v51, v52, v53, v54, v879, v880, v309, v305, v201, v198, v195, v193);\nL_015B:\n\tv897 = v148.b * v148.b;\n\tv323 = v148.d * v148.d;\n\tv316 = v897 + v323;\n\tv732 = UnityEngine.Mathf::Sqrt(v316);\n\tv261 = v732 == 0;\n\tif (v261) goto L_0184;\n\tgoto L_016F;\n\tv950 = \"il2cpp_codegen_runtime_class_init\"(v921, v123, v114, v106, v51, v52, v53, v54, v316, v323, v309, v305, v201, v198, v195, v193);\nL_016F:\n\tv348 = this.data;\n\tv929 = v630 - v732;\n\tv965 = v929 + v348.offsetScaleY;\n\tv966 = this.scaleMix * v965;\n\tv927 = v732 + v966;\n\tv732 = v927 / v732;\nL_0184:\n\tv755 = v732 * v148.b;\n\tv757 = v732 * v148.d;\n\tv148.b = v755;\n\tv148.d = v757;\n\tv737 = this.shearMix > 0;\n\tif (v737) goto L_01A5;\n\tgoto L_0204;\nL_0198:\n\tv217 = this.shearMix <= 0;\n\tif (v217) goto L_01CE;\nL_01A5:\n\tgoto L_01AA;\n\tv821 = \"il2cpp_codegen_runtime_class_init\"(v764, v123, v114, v106, v51, v52, v53, v54, v754, v756, v309, v305, v201, v198, v195, v193);\nL_01AA:\n\tv826 = Spine.MathUtils::Atan2(v148.d, v148.b);\n\tv888 = Spine.MathUtils::Atan2(v68.d, v68.b);\n\tv902 = Spine.MathUtils::Atan2(v68.c, v68.a);\n\tv915 = Spine.MathUtils::Atan2(v148.c, v148.a);\n\tv934 = v888 - v902;\n\tv935 = v826 - v915;\n\tv979 = v934 - v935;\n\tv949 = v979 <= 3.1415927f;\n\tif (v949) goto L_01DE;\n\tgoto L_01E1;\nL_01CE:\n\tv703 = ~v346;\n\tif (v703) goto L_0205;\n\tv773 = v343[v171 @ X23_v6 (System.Int32)] == 0;\n\tv341 = ~v773;\n\tif (v341) goto L_0204;\n\tgoto L_0226;\nL_01DE:\n\tv962 = v979 >= -3.1415927f;\n\tif (v962) goto L_01E8;\nL_01E1:\n\tv979 = v979 + v976;\nL_01E8:\n\tgoto L_01EF;\n\tv985 = \"il2cpp_codegen_runtime_class_init\"(v981, v123, v114, v106, v51, v52, v53, v54, v980, v934, v910, v305, v201, v198, v195, v193);\nL_01EF:\n\tgoto L_01F2;\n\tv989 = \"il2cpp_codegen_runtime_class_init\"(v987, v123, v114, v106, v51, v52, v53, v54, v980, v934, v910, v305, v201, v198, v195, v193);\nL_01F2:\n\tv992 = v148.b * v148.b;\n\tv843 = v148.d * v148.d;\n\tv845 = v992 + v843;\n\tv993 = v454 + v979;\n\tv994 = this.shearMix * v993;\n\tv828 = v826 + v994;\n\tv829 = UnityEngine.Mathf::Sqrt(v845);\n\tv997 = Spine.MathUtils::Cos(v828);\n\tv998 = v829 * v997;\n\tv148.b = v998;\n\tv1000 = Spine.MathUtils::Sin(v828);\n\tv844 = v829 * v1000;\n\tv148.d = v844;\nL_0204:\n\tv148.appliedValid = 0;\nL_0205:\n\tv171 = v171 + 1;\n\tv506 = v209.Count != v171;\n\tif (v506) goto L_008A;\nL_0225:\n\treturn;\nL_0226:\n\tv349 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n// 384 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ApplyAbsoluteWorld()
		{
			//IL_007f: Expected I4, but got F4
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Expected I4, but got Unknown
			Bone bone = Target;
			TransformConstraintData transformConstraintData = Data;
			float num = bone.A * bone.D;
			float num2 = bone.B * bone.C;
			float num3 = num - num2;
			bool flag = num3 < 0f;
			bool flag2 = num3 == 0f;
			int num4 = num3 ^ num3;
			int num5 = num3 & num4;
			bool flag3 = num5 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			bool flag6 = flag4 && flag5;
			ExposedList<Bone> exposedList = Bones;
			if (exposedList.Count < 1)
			{
				return;
			}
			int num6 = 4222976 + 1696;
			float num7 = bone.A * bone.A;
			float num8 = bone.C * bone.C;
			float f = num7 + num8;
			float num9 = bone.B * bone.B;
			float num10 = bone.D * bone.D;
			float f2 = num9 + num10;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v436 @ X9_v6 (System.Int32)+v95 @ TEMPCOND_v4 (System.Boolean)*4]");
			float num11 = 0f * transformConstraintData.OffsetRotation;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v436 @ X9_v6 (System.Int32)+v95 @ TEMPCOND_v4 (System.Boolean)*4]");
			float num12 = 0f * transformConstraintData.OffsetShearY;
			float num13 = Mathf.Sqrt(f);
			bool flag7 = RotateMix == 0f;
			bool flag8 = !flag7;
			float num14 = Mathf.Sqrt(f2);
			int num15 = 0;
			float num16 = TranslateMix;
			object obj = default(object);
			object obj2 = default(object);
			while (true)
			{
				Bone[] items = exposedList.Items;
				Bone bone2 = items[num15];
				float num20;
				if (RotateMix != 0f)
				{
					float num17 = MathUtils.Atan2(bone.C, bone.A);
					float num18 = MathUtils.Atan2(bone2.C, bone2.A);
					float num19 = num17 - num18;
					num20 = num11 + num19;
					float num21;
					if (num20 > (float)Math.PI)
					{
						num21 = (float)Math.PI * -2f;
					}
					else
					{
						if (!(num20 < -(float)Math.PI))
						{
							goto IL_0305;
						}
						num21 = (float)Math.PI * 2f;
					}
					num20 += num21;
					goto IL_0305;
				}
				goto IL_08d0;
				IL_08d0:
				bool flag9 = num16 == 0f;
				bool flag10 = flag8;
				if (!flag9)
				{
					TransformConstraintData transformConstraintData2 = Data;
					bone.LocalToWorld(transformConstraintData2.OffsetX, transformConstraintData2.OffsetY, out var worldX, out var worldY);
					float num22 = worldX - bone2.WorldX;
					float num23 = num16 * num22;
					float worldX2 = bone2.WorldX + num23;
					bone2.worldX = worldX2;
					float num24 = worldY - bone2.WorldY;
					float num25 = num16 * num24;
					float worldY2 = bone2.WorldY + num25;
					bone2.worldY = worldY2;
					flag10 = true;
				}
				if (ScaleMix > 0f)
				{
					float num26 = bone2.A * bone2.A;
					float num27 = bone2.C * bone2.C;
					float f3 = num26 + num27;
					float num28 = Mathf.Sqrt(f3);
					if (num28 != 0f)
					{
						TransformConstraintData transformConstraintData3 = Data;
						float num29 = num13 - num28;
						float num30 = num29 + transformConstraintData3.OffsetScaleX;
						float num31 = ScaleMix * num30;
						float num32 = num28 + num31;
						num28 = num32 / num28;
					}
					float a = num28 * bone2.A;
					float c = num28 * bone2.C;
					bone2.a = a;
					bone2.c = c;
					float num33 = bone2.B * bone2.B;
					float num34 = bone2.D * bone2.D;
					float f4 = num33 + num34;
					float num35 = Mathf.Sqrt(f4);
					if (num35 != 0f)
					{
						TransformConstraintData transformConstraintData4 = Data;
						float num36 = num14 - num35;
						float num37 = num36 + transformConstraintData4.OffsetScaleY;
						float num38 = ScaleMix * num37;
						float num39 = num35 + num38;
						num35 = num39 / num35;
					}
					float b = num35 * bone2.B;
					float d = num35 * bone2.D;
					bone2.b = b;
					bone2.d = d;
					if (ShearMix > 0f)
					{
						goto IL_0672;
					}
				}
				else
				{
					if (ShearMix > 0f)
					{
						goto IL_0672;
					}
					if (!flag10)
					{
						goto IL_09e1;
					}
					if (items[num15] == null)
					{
						break;
					}
				}
				goto IL_09ba;
				IL_0672:
				float num40 = MathUtils.Atan2(bone2.D, bone2.B);
				float num41 = MathUtils.Atan2(bone.D, bone.B);
				float num42 = MathUtils.Atan2(bone.C, bone.A);
				float num43 = MathUtils.Atan2(bone2.C, bone2.A);
				float num44 = num41 - num42;
				float num45 = num40 - num43;
				float num46 = num44 - num45;
				float num47;
				if (num46 > (float)Math.PI)
				{
					num47 = (float)Math.PI * -2f;
				}
				else
				{
					if (!(num46 < -(float)Math.PI))
					{
						goto IL_07c9;
					}
					num47 = (float)Math.PI * 2f;
				}
				num46 += num47;
				goto IL_07c9;
				IL_09ba:
				bone2.appliedValid = false;
				goto IL_09e1;
				IL_07c9:
				float num48 = bone2.B * bone2.B;
				float num49 = bone2.D * bone2.D;
				float f5 = num48 + num49;
				float num50 = num12 + num46;
				float num51 = ShearMix * num50;
				float radians = num40 + num51;
				float num52 = Mathf.Sqrt(f5);
				float num53 = MathUtils.Cos(radians);
				float b2 = num52 * num53;
				bone2.b = b2;
				float num54 = MathUtils.Sin(radians);
				float d2 = num52 * num54;
				bone2.d = d2;
				num16 = TranslateMix;
				goto IL_09ba;
				IL_09e1:
				num15++;
				if (exposedList.Count == num15)
				{
					return;
				}
				continue;
				IL_0305:
				float radians2 = RotateMix * num20;
				float num55 = MathUtils.Cos(radians2);
				float num56 = MathUtils.Sin(radians2);
				float num57 = bone2.C * (float)obj;
				float num58 = bone2.A * (float)obj2;
				float num59 = bone2.A * (float)obj;
				float num60 = bone2.C * (float)obj2;
				float a2 = num58 - num57;
				float c2 = num60 + num59;
				bone2.a = a2;
				bone2.c = c2;
				goto IL_08d0;
			}
			NullReferenceException ex = new NullReferenceException();
			throw new IndexOutOfRangeException();
		}

		[Token(Token = "0x600043C")]
		[Address(RVA = "0x154F140", Offset = "0x154F140", Length = "0x43C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv44 = Spine.MathUtils;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60);\n\tv69 = System.Math;\n\tv62 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60);\n\tv64 = 1;\n\t*([1A37BC0]) = v64;\nL_0023:\n\tv66 = this.target;\n\tv74 = this.data;\n\tv79 = v66.a * v66.d;\n\tv80 = v66.b * v66.c;\n\tv81 = v79 - v80;\n\tv85 = v81 < 0;\n\tv86 = v81 == 0;\n\tv88 = v81 ^ v81;\n\tv89 = v81 & v88;\n\tv90 = v89 < 0;\n\tv91 = v85 == v90;\n\tv92 = ~v86;\n\tv93 = v91 & v92;\n\tv204 = this.bones;\n\tv415 = v204.Count < 1;\n\tif (v415) goto L_01D2;\n\tv423 = 0x407000 + 0x6A0;\n\tv425 = v66.a * v66.a;\n\tv426 = v66.c * v66.c;\n\tv431 = v425 + v426;\n\tv434 = v66.b * v66.b;\n\tv192 = v66.d * v66.d;\n\tv436 = v434 + v192;\n\tv439 = UnityEngine.Mathf::Sqrt(v431);\n\tv597 = UnityEngine.Mathf::Sqrt(v436);\n\tv194 = v439 + -1f;\n\tv605 = this.rotateMix == 0;\n\tv610 = *([v423 @ X9_v6 (System.Int32)+v93 @ TEMPCOND_v4 (System.Boolean)*4]) * v74.offsetRotation;\n\tv612 = *([v423 @ X9_v6 (System.Int32)+v93 @ TEMPCOND_v4 (System.Boolean)*4]) * v74.offsetShearY;\n\tv613 = ~v605;\nL_008E:\n\tv330 = v204.Items;\n\tv141 = v330[v161 @ X23_v6 (System.Int32)];\n\tv250 = this.rotateMix == 0;\n\tif (v250) goto L_00F2;\n\tgoto L_00B6;\n\tv662 = \"il2cpp_codegen_runtime_class_init\"(v651, v118, v109, v101, v49, v50, v51, v52, v301, v307, v297, v293, v180, v194, v192, v196);\nL_00B6:\n\tv667 = Spine.MathUtils::Atan2(v66.c, v66.a);\n\tv620 = v610 + v667;\n\tv689 = v620 <= 3.1415927f;\n\tif (v689) goto L_00D3;\n\tgoto L_00D6;\nL_00D3:\n\tv736 = v620 >= -3.1415927f;\n\tif (v736) goto L_00DB;\nL_00D6:\n\tv620 = v620 + v792;\nL_00DB:\n\tgoto L_00DD;\n\tv824 = \"il2cpp_codegen_runtime_class_init\"(v796, v118, v109, v101, v49, v50, v51, v52, v795, v675, v297, v293, v180, v194, v192, v196);\nL_00DD:\n\tv619 = this.rotateMix * v620;\n\tv828 = Spine.MathUtils::Cos(v619);\n\tv844 = Spine.MathUtils::Sin(v619);\n\tv641 = v141.c * v858;\n\tv859 = v141.a * v858;\n\tv860 = v141.a * v861;\n\tv640 = v141.c * v861;\n\tv643 = v860 - v641;\n\tv642 = v640 + v859;\n\tv141.a = v643;\n\tv141.c = v642;\nL_00F2:\n\tv251 = this.translateMix == 0;\n\tif (v251) goto L_011B;\n\tv332 = this.data;\n\tSpine.Bone::LocalToWorld(v66, v332.offsetX, v332.offsetY, &v115 @ stack_-94_v6 (System.Single), &v106 @ stack_-98_v7 (System.Single));\n\tv739 = this.translateMix * v115;\n\tv740 = v141.worldX + v739;\n\tv141.worldX = v740;\n\tv742 = this.translateMix * v106;\n\tv655 = v141.worldY + v742;\n\tv141.worldY = v655;\nL_011B:\n\tv212 = this.scaleMix <= 0;\n\tif (v212) goto L_0153;\n\tgoto L_0123;\n\tv690 = \"il2cpp_codegen_runtime_class_init\"(v668, v120, v111, v103, v49, v50, v51, v52, v304, v310, v298, v294, v180, v194, v192, v196);\nL_0123:\n\tv333 = this.data;\n\tv802 = v194 + v333.offsetScaleX;\n\tv804 = this.scaleMix * v802;\n\tv807 = v804 + 1f;\n\tv717 = v807 * v141.a;\n\tv715 = v807 * v141.c;\n\tv141.a = v717;\n\tv141.c = v715;\n\tv695 = this.shearMix > 0;\n\tif (v695) goto L_0159;\n\tgoto L_01B2;\nL_0153:\n\tv213 = this.shearMix <= 0;\n\tif (v213) goto L_0175;\nL_0159:\n\tgoto L_015E;\n\tv743 = \"il2cpp_codegen_runtime_class_init\"(v721, v120, v111, v103, v49, v50, v51, v52, v714, v716, v299, v295, v181, v194, v192, v196);\nL_015E:\n\tv748 = Spine.MathUtils::Atan2(v66.d, v66.b);\n\tv812 = Spine.MathUtils::Atan2(v66.c, v66.a);\n\tv132 = v748 - v812;\n\tv842 = v132 <= 3.1415927f;\n\tif (v842) goto L_0185;\n\tgoto L_0188;\nL_0175:\n\tv724 = ~v334;\n\tif (v724) goto L_01B3;\n\tv749 = v330[v161 @ X23_v6 (System.Int32)] == 0;\n\tv327 = ~v749;\n\tif (v327) goto L_01B2;\n\tgoto L_01D3;\nL_0185:\n\tv856 = v132 >= -3.1415927f;\n\tif (v856) goto L_0191;\nL_0188:\n\tv132 = v132 + v871;\nL_0191:\n\tgoto L_0196;\n\tv879 = \"il2cpp_codegen_runtime_class_init\"(v874, v120, v111, v103, v49, v50, v51, v52, v305, v311, v299, v295, v181, v194, v192, v196);\nL_0196:\n\tv884 = Spine.MathUtils::Atan2(v141.d, v141.b);\n\tgoto L_01A0;\n\tv887 = \"il2cpp_codegen_runtime_class_init\"(v885, v120, v111, v103, v49, v50, v51, v52, v884, v882, v299, v295, v181, v194, v192, v196);\nL_01A0:\n\tv890 = v141.b * v141.b;\n\tv818 = v141.d * v141.d;\n\tv891 = v132 + -1.5707964f;\n\tv892 = v612 + v891;\n\tv893 = this.shearMix * v892;\n\tv813 = v893 + v884;\n\tv820 = v890 + v818;\n\tv814 = UnityEngine.Mathf::Sqrt(v820);\n\tv896 = Spine.MathUtils::Cos(v813);\n\tv897 = v814 * v896;\n\tv141.b = v897;\n\tv899 = Spine.MathUtils::Sin(v813);\n\tv819 = v814 * v899;\n\tv141.d = v819;\nL_01B2:\n\tv141.appliedValid = 0;\nL_01B3:\n\tv161 = v161 + 1;\n\tv485 = v204.Count != v161;\n\tif (v485) goto L_008E;\nL_01D2:\n\treturn;\nL_01D3:\n\tv336 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n// 336 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ApplyRelativeWorld()
		{
			//IL_007f: Expected I4, but got F4
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Expected I4, but got Unknown
			Bone bone = Target;
			TransformConstraintData transformConstraintData = Data;
			float num = bone.A * bone.D;
			float num2 = bone.B * bone.C;
			float num3 = num - num2;
			bool flag = num3 < 0f;
			bool flag2 = num3 == 0f;
			int num4 = num3 ^ num3;
			int num5 = num3 & num4;
			bool flag3 = num5 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			bool flag6 = flag4 && flag5;
			ExposedList<Bone> exposedList = Bones;
			if (exposedList.Count < 1)
			{
				return;
			}
			int num6 = 4222976 + 1696;
			float num7 = bone.A * bone.A;
			float num8 = bone.C * bone.C;
			float f = num7 + num8;
			float num9 = bone.B * bone.B;
			float num10 = bone.D * bone.D;
			float f2 = num9 + num10;
			float num11 = Mathf.Sqrt(f);
			float num12 = Mathf.Sqrt(f2);
			float num13 = num11 + -1f;
			bool flag7 = RotateMix == 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ X9_v6 (System.Int32)+v93 @ TEMPCOND_v4 (System.Boolean)*4]");
			float num14 = 0f * transformConstraintData.OffsetRotation;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ X9_v6 (System.Int32)+v93 @ TEMPCOND_v4 (System.Boolean)*4]");
			float num15 = 0f * transformConstraintData.OffsetShearY;
			bool flag8 = !flag7;
			int num16 = 0;
			object obj = default(object);
			object obj2 = default(object);
			while (true)
			{
				Bone[] items = exposedList.Items;
				Bone bone2 = items[num16];
				float num18;
				if (RotateMix != 0f)
				{
					float num17 = MathUtils.Atan2(bone.C, bone.A);
					num18 = num14 + num17;
					float num19;
					if (num18 > (float)Math.PI)
					{
						num19 = (float)Math.PI * -2f;
					}
					else
					{
						if (!(num18 < -(float)Math.PI))
						{
							goto IL_02dc;
						}
						num19 = (float)Math.PI * 2f;
					}
					num18 += num19;
					goto IL_02dc;
				}
				goto IL_0747;
				IL_0747:
				bool flag9 = TranslateMix == 0f;
				bool flag10 = flag8;
				if (!flag9)
				{
					TransformConstraintData transformConstraintData2 = Data;
					bone.LocalToWorld(transformConstraintData2.OffsetX, transformConstraintData2.OffsetY, out var worldX, out var worldY);
					float num20 = TranslateMix * worldX;
					float worldX2 = bone2.WorldX + num20;
					bone2.worldX = worldX2;
					float num21 = TranslateMix * worldY;
					float worldY2 = bone2.WorldY + num21;
					bone2.worldY = worldY2;
					flag10 = true;
				}
				if (ScaleMix > 0f)
				{
					TransformConstraintData transformConstraintData3 = Data;
					float num22 = num13 + transformConstraintData3.OffsetScaleX;
					float num23 = ScaleMix * num22;
					float num24 = num23 + 1f;
					float a = num24 * bone2.A;
					float c = num24 * bone2.C;
					bone2.a = a;
					bone2.c = c;
					if (ShearMix > 0f)
					{
						goto IL_051c;
					}
				}
				else
				{
					if (ShearMix > 0f)
					{
						goto IL_051c;
					}
					if (!flag10)
					{
						goto IL_07b0;
					}
					if (items[num16] == null)
					{
						break;
					}
				}
				goto IL_0789;
				IL_051c:
				float num25 = MathUtils.Atan2(bone.D, bone.B);
				float num26 = MathUtils.Atan2(bone.C, bone.A);
				float num27 = num25 - num26;
				float num28;
				if (num27 > (float)Math.PI)
				{
					num28 = (float)Math.PI * -2f;
				}
				else
				{
					if (!(num27 < -(float)Math.PI))
					{
						goto IL_061a;
					}
					num28 = (float)Math.PI * 2f;
				}
				num27 += num28;
				goto IL_061a;
				IL_0789:
				bone2.appliedValid = false;
				goto IL_07b0;
				IL_07b0:
				num16++;
				if (exposedList.Count == num16)
				{
					return;
				}
				continue;
				IL_061a:
				float num29 = MathUtils.Atan2(bone2.D, bone2.B);
				float num30 = bone2.B * bone2.B;
				float num31 = bone2.D * bone2.D;
				float num32 = num27 + -(float)Math.PI / 2f;
				float num33 = num15 + num32;
				float num34 = ShearMix * num33;
				float radians = num34 + num29;
				float f3 = num30 + num31;
				float num35 = Mathf.Sqrt(f3);
				float num36 = MathUtils.Cos(radians);
				float b = num35 * num36;
				bone2.b = b;
				float num37 = MathUtils.Sin(radians);
				float d = num35 * num37;
				bone2.d = d;
				goto IL_0789;
				IL_02dc:
				float radians2 = RotateMix * num18;
				float num38 = MathUtils.Cos(radians2);
				float num39 = MathUtils.Sin(radians2);
				float num40 = bone2.C * (float)obj;
				float num41 = bone2.A * (float)obj;
				float num42 = bone2.A * (float)obj2;
				float num43 = bone2.C * (float)obj2;
				float a2 = num42 - num40;
				float c2 = num43 + num41;
				bone2.a = a2;
				bone2.c = c2;
				goto IL_0747;
			}
			NullReferenceException ex = new NullReferenceException();
			throw new IndexOutOfRangeException();
		}

		[Token(Token = "0x600043D")]
		[Address(RVA = "0x154EED4", Offset = "0x154EED4", Length = "0x26C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv34 = this.target;\n\tv44 = ~v34.appliedValid;\n\tv45 = ~v44;\n\tif (v45) goto L_0022;\n\tSpine.Bone::UpdateAppliedTransform(v34);\nL_0022:\n\tv205 = this.bones;\n\tv113 = v205.Count < 1;\n\tif (v113) goto L_011E;\n\tv110 = v205.Items;\n\t// 57 NotImplemented \"Instruction DUP not yet implemented.\"\nL_004C:\n\tv91 = v110[v106 @ X24_v6 (System.Int32)];\n\tv408 = ~v91.appliedValid;\n\tv409 = ~v408;\n\tif (v409) goto L_0056;\n\tSpine.Bone::UpdateAppliedTransform(v110[v106 @ X24_v6 (System.Int32)]);\nL_0056:\n\tv89 = v91.arotation;\n\tv155 = this.rotateMix == 0;\n\tif (v155) goto L_0085;\n\tv207 = this.data;\n\tv444 = v34.arotation - v91.arotation;\n\tv445 = v444 + v207.offsetRotation;\n\tv446 = v445 / 0xC3B40000;\n\tv448 = v446 + 16384.499999999996d;\n\tv450 = 0x4000 - v448;\n\tv436 = v450 * 0x168;\n\tv413 = v448 != 0x7FF0000000000000;\n\tif (v413) goto L_FFFFFFFF;\n\tgoto L_0081;\nL_0081:\n\tv490 = v445 - v417;\n\tv438 = this.rotateMix * v490;\n\tv89 = v89 + v438;\nL_0085:\n\tv216 = v91.ax;\n\tv156 = this.translateMix == 0;\n\tif (v156) goto L_0099;\n\tv208 = this.data;\n\tv471 = v34.ax - v91.ax;\n\tv472 = v471 + v208.offsetX;\n\tv455 = v3 * v472;\n\tv216 = v216 + v455;\nL_0099:\n\tv76 = v91.ascaleX;\n\tv70 = v91.ascaleY;\n\tv463 = this.scaleMix == 0;\n\tif (v463) goto L_00CD;\n\tv157 = v91.ascaleX == 0;\n\tif (v157) goto L_00BD;\n\tv209 = this.data;\n\tv522 = v34.ascaleX - v91.ascaleX;\n\tv523 = v522 + v209.offsetScaleX;\n\tv524 = this.scaleMix * v523;\n\tv493 = v91.ascaleX + v524;\n\tv76 = v493 / v76;\nL_00BD:\n\tv158 = v70 == 0;\n\tif (v158) goto L_00CD;\n\tv210 = this.data;\n\tv539 = v34.ascaleY - v70;\n\tv540 = v539 + v210.offsetScaleY;\n\tv541 = this.scaleMix * v540;\n\tv476 = v70 + v541;\n\tv70 = v476 / v70;\nL_00CD:\n\tv283 = v91.ashearY;\n\tv159 = this.shearMix == 0;\n\tif (v159) goto L_00FF;\n\tv211 = this.data;\n\tv528 = v34.ashearY - v91.ashearY;\n\tv529 = v528 + v211.offsetShearY;\n\tv530 = v529 / 0xC3B40000;\n\tv532 = v530 + 16384.499999999996d;\n\tv534 = 0x4000 - v532;\n\tv519 = v534 * 0x168;\n\tv500 = v532 != 0x7FF0000000000000;\n\tif (v500) goto L_FFFFFFFF;\n\tgoto L_00F8;\nL_00F8:\n\tv544 = v529 - v499;\n\tv502 = this.shearMix * v544;\n\tv283 = v283 + v502;\nL_00FF:\n\tSpine.Bone::UpdateWorldTransform(v110[v106 @ X24_v6 (System.Int32)], v216, v520, v89, v76, v70, v91.ashearX, v283);\n\tv106 = v106 + 1;\n\tv309 = v205.Count != v106;\n\tif (v309) goto L_004C;\nL_011E:\n\treturn;\n\tv227 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 207 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ApplyAbsoluteLocal()
		{
			Bone bone = Target;
			if (!bone.appliedValid)
			{
				bone.Update();
			}
			ExposedList<Bone> exposedList = Bones;
			if (exposedList.Count < 1)
			{
				return;
			}
			Bone[] items = exposedList.Items;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
			int num = 0;
			object obj = default(object);
			float y = default(float);
			do
			{
				Bone bone2 = items[num];
				if (!bone2.appliedValid)
				{
					items[num].Update();
				}
				float num2 = bone2.AppliedRotation;
				if (RotateMix != 0f)
				{
					TransformConstraintData transformConstraintData = Data;
					float num3 = bone.AppliedRotation - bone2.AppliedRotation;
					float num4 = num3 + transformConstraintData.OffsetRotation;
					float num5 = num4 / -360f;
					double num6 = (double)num5 + 16384.499999999996;
					double num7 = 8.095E-320 - num6;
					double num8 = num7 * 1.78E-321;
					double num9 = ((num6 != 9.218868437227405E+18) ? num8 : 6.19217644E-315);
					double num10 = (double)num4 - num9;
					float num11 = RotateMix * (float)num10;
					num2 += num11;
				}
				float num12 = bone2.AX;
				if (TranslateMix != 0f)
				{
					TransformConstraintData transformConstraintData2 = Data;
					float num13 = bone.AX - bone2.AX;
					float num14 = num13 + transformConstraintData2.OffsetX;
					float num15 = (float)obj * num14;
					num12 += num15;
				}
				float num16 = bone2.AScaleX;
				float num17 = bone2.AScaleY;
				if (ScaleMix != 0f)
				{
					if (bone2.AScaleX != 0f)
					{
						TransformConstraintData transformConstraintData3 = Data;
						float num18 = bone.AScaleX - bone2.AScaleX;
						float num19 = num18 + transformConstraintData3.OffsetScaleX;
						float num20 = ScaleMix * num19;
						float num21 = bone2.AScaleX + num20;
						num16 = num21 / num16;
					}
					if (num17 != 0f)
					{
						TransformConstraintData transformConstraintData4 = Data;
						float num22 = bone.AScaleY - num17;
						float num23 = num22 + transformConstraintData4.OffsetScaleY;
						float num24 = ScaleMix * num23;
						float num25 = num17 + num24;
						num17 = num25 / num17;
					}
				}
				float num26 = bone2.AShearY;
				if (ShearMix != 0f)
				{
					TransformConstraintData transformConstraintData5 = Data;
					float num27 = bone.AShearY - bone2.AShearY;
					float num28 = num27 + transformConstraintData5.OffsetShearY;
					float num29 = num28 / -360f;
					double num30 = (double)num29 + 16384.499999999996;
					double num31 = 8.095E-320 - num30;
					double num32 = num31 * 1.78E-321;
					double num33 = ((num30 != 9.218868437227405E+18) ? num32 : 6.19217644E-315);
					double num34 = (double)num28 - num33;
					float num35 = ShearMix * (float)num34;
					num26 += num35;
				}
				items[num].UpdateWorldTransform(num12, y, num2, num16, num17, bone2.AShearX, num26);
				num++;
			}
			while (exposedList.Count != num);
		}

		[Token(Token = "0x600043E")]
		[Address(RVA = "0x154ED24", Offset = "0x154ED24", Length = "0x1B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = this.target;\n\tv37 = ~v26.appliedValid;\n\tv38 = ~v37;\n\tif (v38) goto L_001F;\n\tSpine.Bone::UpdateAppliedTransform(v26);\nL_001F:\n\tv165 = this.bones;\n\tv75 = v165.Count < 1;\n\tif (v75) goto L_00C0;\n\tv72 = v165.Items;\n\t// 54 NotImplemented \"Instruction DUP not yet implemented.\"\n\t// 56 NotImplemented \"Instruction DUP not yet implemented.\"\nL_0046:\n\tv61 = v72[v70 @ X24_v6 (System.Int32)];\n\tv342 = ~v61.appliedValid;\n\tv343 = ~v342;\n\tif (v343) goto L_0050;\n\tSpine.Bone::UpdateAppliedTransform(v72[v70 @ X24_v6 (System.Int32)]);\nL_0050:\n\tv59 = v61.arotation;\n\tv113 = this.rotateMix == 0;\n\tif (v113) goto L_0064;\n\tv167 = this.data;\n\tv356 = v26.arotation + v167.offsetRotation;\n\tv349 = this.rotateMix * v356;\n\tv59 = v59 + v349;\nL_0064:\n\tv162 = v61.ax;\n\tv114 = this.translateMix == 0;\n\tif (v114) goto L_0078;\n\tv168 = this.data;\n\tv366 = v26.ax + v168.offsetX;\n\tv362 = v7 * v366;\n\tv162 = v162 + v362;\nL_0078:\n\tv54 = v61.ascaleX;\n\tv115 = this.scaleMix == 0;\n\tif (v115) goto L_008D;\n\tv169 = this.data;\n\tv375 = v26.ascaleX + v169.offsetScaleX;\n\tv376 = v5 * v375;\n\tv54 = v54 * v376;\nL_008D:\n\tv238 = v61.ashearY;\n\tv116 = this.shearMix == 0;\n\tif (v116) goto L_00A5;\n\tv170 = this.data;\n\tv385 = v26.ashearY + v170.offsetShearY;\n\tv381 = this.shearMix * v385;\n\tv238 = v238 + v381;\nL_00A5:\n\tSpine.Bone::UpdateWorldTransform(v72[v70 @ X24_v6 (System.Int32)], v162, v383, v59, v54, v382, v61.ashearX, v238);\n\tv70 = v70 + 1;\n\tv251 = v165.Count != v70;\n\tif (v251) goto L_0046;\nL_00C0:\n\treturn;\n\tv186 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 144 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ApplyRelativeLocal()
		{
			Bone bone = Target;
			if (!bone.appliedValid)
			{
				bone.Update();
			}
			ExposedList<Bone> exposedList = Bones;
			if (exposedList.Count < 1)
			{
				return;
			}
			Bone[] items = exposedList.Items;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
			int num = 0;
			object obj = default(object);
			object obj2 = default(object);
			float y = default(float);
			float scaleY = default(float);
			do
			{
				Bone bone2 = items[num];
				if (!bone2.appliedValid)
				{
					items[num].Update();
				}
				float num2 = bone2.AppliedRotation;
				if (RotateMix != 0f)
				{
					TransformConstraintData transformConstraintData = Data;
					float num3 = bone.AppliedRotation + transformConstraintData.OffsetRotation;
					float num4 = RotateMix * num3;
					num2 += num4;
				}
				float num5 = bone2.AX;
				if (TranslateMix != 0f)
				{
					TransformConstraintData transformConstraintData2 = Data;
					float num6 = bone.AX + transformConstraintData2.OffsetX;
					float num7 = (float)obj * num6;
					num5 += num7;
				}
				float num8 = bone2.AScaleX;
				if (ScaleMix != 0f)
				{
					TransformConstraintData transformConstraintData3 = Data;
					float num9 = bone.AScaleX + transformConstraintData3.OffsetScaleX;
					float num10 = (float)obj2 * num9;
					num8 *= num10;
				}
				float num11 = bone2.AShearY;
				if (ShearMix != 0f)
				{
					TransformConstraintData transformConstraintData4 = Data;
					float num12 = bone.AShearY + transformConstraintData4.OffsetShearY;
					float num13 = ShearMix * num12;
					num11 += num13;
				}
				items[num].UpdateWorldTransform(num5, y, num2, num8, scaleY, bone2.AShearX, num11);
				num++;
			}
			while (exposedList.Count != num);
		}

		[Token(Token = "0x600044C")]
		[Address(RVA = "0x154FB00", Offset = "0x154FB00", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.data;\n\treturn v2.name;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			TransformConstraintData transformConstraintData = Data;
			return transformConstraintData.Name;
		}
	}
}
