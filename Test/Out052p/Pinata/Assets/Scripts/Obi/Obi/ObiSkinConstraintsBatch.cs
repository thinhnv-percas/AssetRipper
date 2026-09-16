using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Serializable]
	[Token(Token = "0x2000010")]
	public class ObiSkinConstraintsBatch : ObiConstraintsBatch
	{
		[HideInInspector]
		[Token(Token = "0x4000032")]
		[FieldOffset(Offset = "0x48")]
		public ObiNativeVector4List skinPoints;

		[HideInInspector]
		[Token(Token = "0x4000033")]
		[FieldOffset(Offset = "0x50")]
		public ObiNativeVector4List skinNormals;

		[HideInInspector]
		[Token(Token = "0x4000034")]
		[FieldOffset(Offset = "0x58")]
		public ObiNativeFloatList skinRadiiBackstop;

		[HideInInspector]
		[Token(Token = "0x4000035")]
		[FieldOffset(Offset = "0x60")]
		public ObiNativeFloatList skinCompliance;

		[Token(Token = "0x17000020")]
		public override Oni.ConstraintType constraintType
		{
			[Token(Token = "0x6000173")]
			[Address(RVA = "0x10237FC", Offset = "0x10237FC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0xC;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Oni.ConstraintType.Skin;
			}
		}

		[Token(Token = "0x6000174")]
		[Address(RVA = "0x1023804", Offset = "0x1023804", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1F09E48]);\n\tv25 = *([v24 @ X8_v4]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, source, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2026203]) = v43;\nL_0019:\n\tv47 = new Obi.ObiNativeVector4List();\n\tObi.ObiNativeVector4List::.ctor(v47, 8, 0x10);\n\tthis.skinPoints = v47;\n\tv53 = new Obi.ObiNativeVector4List();\n\tObi.ObiNativeVector4List::.ctor(v53, 8, 0x10);\n\tthis.skinNormals = v53;\n\tv61 = new Obi.ObiNativeFloatList();\n\tObi.ObiNativeFloatList::.ctor(v61, 8, 0x10);\n\tthis.skinRadiiBackstop = v61;\n\tv67 = new Obi.ObiNativeFloatList();\n\tObi.ObiNativeFloatList::.ctor(v67, 8, 0x10);\n\tthis.skinCompliance = v67;\n\tObi.ObiConstraintsBatch::.ctor(this, source);\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiSkinConstraintsBatch(ObiSkinConstraintsBatch source = null)
		{
			ObiNativeVector4List obiNativeVector4List = new ObiNativeVector4List();
			skinPoints = obiNativeVector4List;
			ObiNativeVector4List obiNativeVector4List2 = new ObiNativeVector4List();
			skinNormals = obiNativeVector4List2;
			skinRadiiBackstop = new ObiNativeFloatList();
			skinCompliance = new ObiNativeFloatList();
			base._002Ector(source);
		}

		[Token(Token = "0x6000175")]
		[Address(RVA = "0x10238EC", Offset = "0x10238EC", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EAF620]);\n\tv21 = *([v20 @ X8_v18]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2026204]) = v40;\nL_0017:\n\tv44 = new Obi.ObiSkinConstraintsBatch();\n\tObi.ObiSkinConstraintsBatch::.ctor(v44, this);\n\tv48 = this.particleIndices;\n\tObi.ObiNativeList`1<System.Int32>::ResizeUninitialized(v44.particleIndices, v48.m_Count);\n\tv74 = this.skinPoints;\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::ResizeUninitialized(v44.skinPoints, v74.m_Count);\n\tv75 = this.skinNormals;\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::ResizeUninitialized(v44.skinNormals, v75.m_Count);\n\tv76 = this.skinRadiiBackstop;\n\tObi.ObiNativeList`1<System.Single>::ResizeUninitialized(v44.skinRadiiBackstop, v76.m_Count);\n\tv77 = this.skinCompliance;\n\tObi.ObiNativeList`1<System.Single>::ResizeUninitialized(v44.skinCompliance, v77.m_Count);\n\tObi.ObiNativeList`1<System.Int32>::CopyFrom(v44.particleIndices, this.particleIndices);\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::CopyFrom(v44.skinPoints, this.skinPoints);\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::CopyFrom(v44.skinNormals, this.skinNormals);\n\tObi.ObiNativeList`1<System.Single>::CopyFrom(v44.skinRadiiBackstop, this.skinRadiiBackstop);\n\tObi.ObiNativeList`1<System.Single>::CopyFrom(v44.skinCompliance, this.skinCompliance);\n\treturn v44;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 101 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override IObiConstraintsBatch Clone()
		{
			ObiSkinConstraintsBatch obiSkinConstraintsBatch = new ObiSkinConstraintsBatch(this);
			ObiNativeIntList obiNativeIntList = particleIndices;
			obiSkinConstraintsBatch.particleIndices.ResizeUninitialized(obiNativeIntList.count);
			ObiNativeVector4List obiNativeVector4List = skinPoints;
			obiSkinConstraintsBatch.skinPoints.ResizeUninitialized(obiNativeVector4List.count);
			ObiNativeVector4List obiNativeVector4List2 = skinNormals;
			obiSkinConstraintsBatch.skinNormals.ResizeUninitialized(obiNativeVector4List2.count);
			ObiNativeFloatList obiNativeFloatList = skinRadiiBackstop;
			obiSkinConstraintsBatch.skinRadiiBackstop.ResizeUninitialized(obiNativeFloatList.count);
			ObiNativeFloatList obiNativeFloatList2 = skinCompliance;
			obiSkinConstraintsBatch.skinCompliance.ResizeUninitialized(obiNativeFloatList2.count);
			obiSkinConstraintsBatch.particleIndices.CopyFrom(particleIndices);
			obiSkinConstraintsBatch.skinPoints.CopyFrom(skinPoints);
			obiSkinConstraintsBatch.skinNormals.CopyFrom(skinNormals);
			obiSkinConstraintsBatch.skinRadiiBackstop.CopyFrom(skinRadiiBackstop);
			obiSkinConstraintsBatch.skinCompliance.CopyFrom(skinCompliance);
			return obiSkinConstraintsBatch;
		}

		[Token(Token = "0x6000176")]
		[Address(RVA = "0x1023A80", Offset = "0x1023A80", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv34 = &v35 @ stack_-10_v2;\n\t*([v34 @ X29_v1-14]) = normal.w;\n\t*([v34 @ X29_v1-18]) = *([v34 @ X29_v1+18]);\n\tgoto L_0034;\n\tv59 = *([1EED860]);\n\tv60 = *([v59 @ X8_v8]);\n\tv61 = \"il2cpp_codegen_initialize_method\"(v60, index, methodInfo, v63, v64, v65, v66, v67, v46, v0, v2, v3, normal, v4, v6, v7);\n\tv70 = 0 | 1;\n\t*([2026205]) = v70;\nL_0034:\n\tObi.ObiConstraintsBatch::RegisterConstraint(this);\n\tObi.ObiNativeList`1<System.Int32>::Add(this.particleIndices, index);\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::Add(this.skinPoints, point);\n\t// 81 MakeStruct v81 @ AGG1023B78_1_v2 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), normal @ V4 (UnityEngine.Vector4), normal.y (System.Single), normal.z (System.Single), [v34 @ X29_v1-14]\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::Add(this.skinNormals, v81);\n\tObi.ObiNativeList`1<System.Single>::Add(this.skinRadiiBackstop, *([v34 @ X29_v1+10]));\n\tObi.ObiNativeList`1<System.Single>::Add(this.skinRadiiBackstop, *([v34 @ X29_v1-18]));\n\tObi.ObiNativeList`1<System.Single>::Add(this.skinRadiiBackstop, *([v34 @ X29_v1+20]));\n\tObi.ObiNativeList`1<System.Single>::Add(this.skinCompliance, *([v34 @ X29_v1+28]));\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 105 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddConstraint(int index, Vector4 point, Vector4 normal, float radius, float collisionRadius, float backstop, float stiffness)
		{
			//IL_0097: Expected F4, but got I
			//IL_00c2: Expected F4, but got I
			//IL_00de: Expected F4, but got I
			//IL_00fa: Expected F4, but got I
			//IL_0116: Expected F4, but got I
			object obj2 = default(object);
			object obj = obj2;
			_ = normal.w;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1+18]");
			_ = 0;
			RegisterConstraint();
			particleIndices.Add(index);
			skinPoints.Add(point);
			Vector4 item = default(Vector4);
			Vector4 vector = default(Vector4);
			item.x = vector.x;
			item.y = normal.y;
			item.z = normal.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1-14]");
			item.w = 0f;
			skinNormals.Add(item);
			ObiNativeFloatList obiNativeFloatList = skinRadiiBackstop;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1+10]");
			obiNativeFloatList.Add(0f);
			ObiNativeFloatList obiNativeFloatList2 = skinRadiiBackstop;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1-18]");
			obiNativeFloatList2.Add(0f);
			ObiNativeFloatList obiNativeFloatList3 = skinRadiiBackstop;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1+20]");
			obiNativeFloatList3.Add(0f);
			ObiNativeFloatList obiNativeFloatList4 = skinCompliance;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1+28]");
			obiNativeFloatList4.Add(0f);
		}

		[Token(Token = "0x6000177")]
		[Address(RVA = "0x1023BF8", Offset = "0x1023BF8", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EBD548]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026206]) = v38;\nL_0015:\n\tObi.ObiConstraintsBatch::Clear(this);\n\tObi.ObiNativeList`1<System.Int32>::Clear(this.particleIndices);\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::Clear(this.skinPoints);\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::Clear(this.skinNormals);\n\tObi.ObiNativeList`1<System.Single>::Clear(this.skinRadiiBackstop);\n\tObi.ObiNativeList`1<System.Single>::Clear(this.skinCompliance);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Clear()
		{
			base.Clear();
			particleIndices.Clear();
			skinPoints.Clear();
			skinNormals.Clear();
			skinRadiiBackstop.Clear();
			skinCompliance.Clear();
		}

		[Token(Token = "0x6000178")]
		[Address(RVA = "0x1023CAC", Offset = "0x1023CAC", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv26 = *([1F08D18]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, index, particles, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2026207]) = v44;\nL_001E:\n\tv51 = Obi.ObiNativeIntList::get_Item(this.particleIndices, index);\n\tSystem.Collections.Generic.List`1<System.Int32>::Add(particles, v51);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void GetParticlesInvolved(int index, List<int> particles)
		{
			int item = particleIndices.get_Item(index);
			particles.Add(item);
		}

		[Token(Token = "0x6000179")]
		[Address(RVA = "0x1023D38", Offset = "0x1023D38", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv30 = *([1EAE480]);\n\tv31 = *([v30 @ X8_v8]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, sourceIndex, destIndex, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2026208]) = v48;\nL_0021:\n\tObi.ObiNativeList`1<System.Int32>::Swap(this.particleIndices, sourceIndex, destIndex);\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::Swap(this.skinPoints, sourceIndex, destIndex);\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::Swap(this.skinNormals, sourceIndex, destIndex);\n\tv128 = sourceIndex << 1;\n\tv98 = sourceIndex + v128;\n\tv60 = destIndex << 1;\n\tv57 = destIndex + v60;\n\tObi.ObiNativeList`1<System.Single>::Swap(this.skinRadiiBackstop, v98, v57);\n\tv79 = v98 + 1;\n\tv73 = v57 + 1;\n\tObi.ObiNativeList`1<System.Single>::Swap(this.skinRadiiBackstop, v79, v73);\n\tv80 = v98 + 2;\n\tv74 = v57 + 2;\n\tObi.ObiNativeList`1<System.Single>::Swap(this.skinRadiiBackstop, v80, v74);\n\tObi.ObiNativeList`1<System.Single>::Swap(this.skinCompliance, sourceIndex, destIndex);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void SwapConstraints(int sourceIndex, int destIndex)
		{
			particleIndices.Swap(sourceIndex, destIndex);
			skinPoints.Swap(sourceIndex, destIndex);
			skinNormals.Swap(sourceIndex, destIndex);
			int num = sourceIndex << 1;
			int num2 = sourceIndex + num;
			int num3 = destIndex << 1;
			int num4 = destIndex + num3;
			skinRadiiBackstop.Swap(num2, num4);
			int index = num2 + 1;
			int index2 = num4 + 1;
			skinRadiiBackstop.Swap(index, index2);
			int index3 = num2 + 2;
			int index4 = num4 + 2;
			skinRadiiBackstop.Swap(index3, index4);
			skinCompliance.Swap(sourceIndex, destIndex);
		}

		[Token(Token = "0x600017A")]
		[Address(RVA = "0x1023E58", Offset = "0x1023E58", Length = "0x1A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1EB2920]);\n\tv29 = *([v28 @ X8_v19]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, constraints, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2026209]) = v47;\nL_0018:\n\tv187 = this.skinCompliance;\nL_0028:\n\tv81 = v190 >= v187.m_Count;\n\tif (v81) goto L_0087;\n\tgoto L_0058;\n\tv238 = *([v234 @ X8_v8+B0]);\n\tv239 = 0;\n\tv240 = v238 + 8;\n\tv242 = *([v279 @ X11_v10-8]);\n\tv284 = v242 == v235;\n\tif (v284) goto L_0051;\n\tv262 = v278 + 1;\n\tv289 = v262 < v236;\n\tv260 = ~v289;\n\tv264 = v279 + 0x10;\n\tv244 = ~v260;\n\tif (v244) goto L_FFFFFFFF;\n\tv265 = v20;\n\tv266 = 0;\n\tv267 = 0x8909C4(v265, v235, v266, v61, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_0058;\nL_0051:\n\tv290 = *([v279 @ X11_v10]);\n\tv291 = v290 << 4;\n\tv292 = v234 + v291;\n\tv293 = v292 + 0x130;\nL_0058:\n\tv167 = Obi.IObiConstraints::GetActor(constraints);\n\tv184 = this.source;\n\tv64 = v167.solverIndices;\n\tv168 = Obi.ObiNativeIntList::get_Item(v184.particleIndices, v190);\n\tv349 = v168 < v64.Length;\n\tv127 = ~v349;\n\tif (v127) goto L_00A8;\n\tv165 = Obi.ObiNativeIntList::set_Item(this.particleIndices, v190, v64[v168 @ X0_v14 (System.Int32)]);\n\tv190 = v190 + 1;\n\tv354 = this.skinCompliance == 0;\n\tv171 = ~v354;\n\tif (v171) goto L_0028;\n\tthrow System.NullReferenceException;\nL_0087:\n\tv150 = this.particleIndices;\n\tv137 = this.skinPoints;\n\tv143 = this.skinNormals;\n\tv57 = this.skinRadiiBackstop;\n\tOni::SetSkinConstraints(this.batch, v150.m_AlignedPtr, v137.m_AlignedPtr, v143.m_AlignedPtr, v57.m_AlignedPtr, v187.m_AlignedPtr, this.m_ConstraintCount);\n\tOni::SetActiveConstraints(this.batch, this.m_ActiveConstraintCount);\n\treturn;\nL_00A8:\n\tv350 = new System.IndexOutOfRangeException();\n\tthrow v350;\n\treturn;\n// 120 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void OnAddToSolver(IObiConstraints constraints)
		{
			ObiNativeFloatList obiNativeFloatList = skinCompliance;
			int num = 0;
			bool flag2;
			do
			{
				if (num >= obiNativeFloatList.count)
				{
					ObiNativeIntList obiNativeIntList = particleIndices;
					ObiNativeVector4List obiNativeVector4List = skinPoints;
					ObiNativeVector4List obiNativeVector4List2 = skinNormals;
					ObiNativeFloatList obiNativeFloatList2 = skinRadiiBackstop;
					Oni.SetSkinConstraints(oniBatch, obiNativeIntList.m_AlignedPtr, obiNativeVector4List.m_AlignedPtr, obiNativeVector4List2.m_AlignedPtr, obiNativeFloatList2.m_AlignedPtr, obiNativeFloatList.m_AlignedPtr, constraintCount);
					Oni.SetActiveConstraints(oniBatch, activeConstraintCount);
					return;
				}
				ObiActor actor = constraints.GetActor();
				ObiConstraintsBatch obiConstraintsBatch = source;
				int[] solverIndices = actor.solverIndices;
				int num2 = obiConstraintsBatch.particleIndices.get_Item(num);
				if (num2 < solverIndices.Length)
				{
					particleIndices.set_Item(num, solverIndices[num2]);
					num++;
					bool flag = skinCompliance == null;
					flag2 = !flag;
					obiNativeFloatList = skinCompliance;
					continue;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			while (flag2);
			throw new NullReferenceException();
		}
	}
}
