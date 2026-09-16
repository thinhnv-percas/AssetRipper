using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Serializable]
	[Token(Token = "0x2000013")]
	public class ObiVolumeConstraintsBatch : ObiConstraintsBatch
	{
		[HideInInspector]
		[Token(Token = "0x400003C")]
		[FieldOffset(Offset = "0x48")]
		public ObiNativeIntList firstTriangle;

		[HideInInspector]
		[Token(Token = "0x400003D")]
		[FieldOffset(Offset = "0x50")]
		public ObiNativeFloatList restVolumes;

		[HideInInspector]
		[Token(Token = "0x400003E")]
		[FieldOffset(Offset = "0x58")]
		public ObiNativeVector2List pressureStiffness;

		[Token(Token = "0x17000023")]
		public override Oni.ConstraintType constraintType
		{
			[Token(Token = "0x6000190")]
			[Address(RVA = "0x103387C", Offset = "0x103387C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Oni.ConstraintType.Volume;
			}
		}

		[Token(Token = "0x6000191")]
		[Address(RVA = "0x1033884", Offset = "0x1033884", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EB4A60]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, source, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202628F]) = v41;\nL_0018:\n\tv45 = new Obi.ObiNativeIntList();\n\tObi.ObiNativeIntList::.ctor(v45, 8, 0x10);\n\tthis.firstTriangle = v45;\n\tv53 = new Obi.ObiNativeFloatList();\n\tObi.ObiNativeFloatList::.ctor(v53, 8, 0x10);\n\tthis.restVolumes = v53;\n\tv61 = new Obi.ObiNativeVector2List();\n\tObi.ObiNativeVector2List::.ctor(v61, 8, 0x10);\n\tthis.pressureStiffness = v61;\n\tObi.ObiConstraintsBatch::.ctor(this, source);\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiVolumeConstraintsBatch(ObiVolumeConstraintsBatch source = null)
		{
			ObiNativeIntList obiNativeIntList = new ObiNativeIntList();
			firstTriangle = obiNativeIntList;
			ObiNativeFloatList obiNativeFloatList = new ObiNativeFloatList();
			restVolumes = obiNativeFloatList;
			pressureStiffness = new ObiNativeVector2List();
			base._002Ector(source);
		}

		[Token(Token = "0x6000192")]
		[Address(RVA = "0x1033954", Offset = "0x1033954", Length = "0x164")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EE4540]);\n\tv21 = *([v20 @ X8_v21]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2026290]) = v40;\nL_0017:\n\tv44 = new Obi.ObiVolumeConstraintsBatch();\n\tObi.ObiVolumeConstraintsBatch::.ctor(v44, this);\n\tv48 = this.particleIndices;\n\tObi.ObiNativeList`1<System.Int32>::ResizeUninitialized(v44.particleIndices, v48.m_Count);\n\tv69 = this.firstTriangle;\n\tObi.ObiNativeList`1<System.Int32>::ResizeUninitialized(v44.firstTriangle, v69.m_Count);\n\tv70 = this.restVolumes;\n\tObi.ObiNativeList`1<System.Single>::ResizeUninitialized(v44.restVolumes, v70.m_Count);\n\tv71 = this.pressureStiffness;\n\tObi.ObiNativeList`1<UnityEngine.Vector2>::ResizeUninitialized(v44.pressureStiffness, v71.m_Count);\n\tObi.ObiNativeList`1<System.Int32>::CopyFrom(v44.particleIndices, this.particleIndices);\n\tObi.ObiNativeList`1<System.Int32>::CopyFrom(v44.firstTriangle, this.firstTriangle);\n\tObi.ObiNativeList`1<System.Single>::CopyFrom(v44.restVolumes, this.restVolumes);\n\tObi.ObiNativeList`1<UnityEngine.Vector2>::CopyFrom(v44.pressureStiffness, this.pressureStiffness);\n\treturn v44;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override IObiConstraintsBatch Clone()
		{
			ObiVolumeConstraintsBatch obiVolumeConstraintsBatch = new ObiVolumeConstraintsBatch(this);
			ObiNativeIntList obiNativeIntList = particleIndices;
			obiVolumeConstraintsBatch.particleIndices.ResizeUninitialized(obiNativeIntList.count);
			ObiNativeIntList obiNativeIntList2 = firstTriangle;
			obiVolumeConstraintsBatch.firstTriangle.ResizeUninitialized(obiNativeIntList2.count);
			ObiNativeFloatList obiNativeFloatList = restVolumes;
			obiVolumeConstraintsBatch.restVolumes.ResizeUninitialized(obiNativeFloatList.count);
			ObiNativeVector2List obiNativeVector2List = pressureStiffness;
			obiVolumeConstraintsBatch.pressureStiffness.ResizeUninitialized(obiNativeVector2List.count);
			obiVolumeConstraintsBatch.particleIndices.CopyFrom(particleIndices);
			obiVolumeConstraintsBatch.firstTriangle.CopyFrom(firstTriangle);
			obiVolumeConstraintsBatch.restVolumes.CopyFrom(restVolumes);
			obiVolumeConstraintsBatch.pressureStiffness.CopyFrom(pressureStiffness);
			return obiVolumeConstraintsBatch;
		}

		[Token(Token = "0x6000193")]
		[Address(RVA = "0x1033AB8", Offset = "0x1033AB8", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EBC3F8]);\n\tv27 = *([v26 @ X8_v17]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, triangles, methodInfo, v30, v31, v32, v33, v34, restVolume, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2026291]) = v44;\nL_0019:\n\tObi.ObiConstraintsBatch::RegisterConstraint(this);\n\tv47 = this.particleIndices;\n\tv81 = v47.m_Count * 0x55555556;\n\tv64 = v81 >> 0x3F;\n\tv83 = v81 >> 0x20;\n\tv84 = v83 + v64;\n\tObi.ObiNativeList`1<System.Int32>::Add(this.firstTriangle, v84);\n\tObi.ObiNativeList`1<System.Int32>::AddRange(this.particleIndices, triangles);\n\tObi.ObiNativeList`1<System.Single>::Add(this.restVolumes, restVolume);\n\tv53 = 0;\n\tv69 = Obi.ObiNativeList`1<System.Int32>::AddRange(&v53 @ stack_-38_v3, 0);\n\t// 74 MakeStruct v107 @ AGG1033BB4_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 0, v139 @ stack_-34\n\tObi.ObiNativeList`1<UnityEngine.Vector2>::Add(this.pressureStiffness, v107);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddConstraint(int[] triangles, float restVolume)
		{
			//IL_0081: Expected O, but got I4
			//IL_00ab: Expected F4, but got O
			RegisterConstraint();
			ObiNativeIntList obiNativeIntList = particleIndices;
			int num = obiNativeIntList.count * 1431655766;
			int num2 = num >> 63;
			int num3 = num >> 32;
			int item = num3 + num2;
			firstTriangle.Add(item);
			particleIndices.AddRange(triangles);
			restVolumes.Add(restVolume);
			object obj = 0;
			((ObiNativeList<int>)obj).AddRange((IEnumerable<int>)null);
			Vector2 item2 = default(Vector2);
			item2.x = 0f;
			object obj2 = default(object);
			item2.y = (float)obj2;
			pressureStiffness.Add(item2);
		}

		[Token(Token = "0x6000194")]
		[Address(RVA = "0x1033BD8", Offset = "0x1033BD8", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1ECA7C8]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026292]) = v38;\nL_0015:\n\tObi.ObiConstraintsBatch::Clear(this);\n\tObi.ObiNativeList`1<System.Int32>::Clear(this.particleIndices);\n\tObi.ObiNativeList`1<System.Int32>::Clear(this.firstTriangle);\n\tObi.ObiNativeList`1<System.Single>::Clear(this.restVolumes);\n\tObi.ObiNativeList`1<UnityEngine.Vector2>::Clear(this.pressureStiffness);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Clear()
		{
			base.Clear();
			particleIndices.Clear();
			firstTriangle.Clear();
			restVolumes.Clear();
			pressureStiffness.Clear();
		}

		[Token(Token = "0x6000195")]
		[Address(RVA = "0x1033C7C", Offset = "0x1033C7C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void GetParticlesInvolved(int index, List<int> particles)
		{
		}

		[Token(Token = "0x6000196")]
		[Address(RVA = "0x1033C80", Offset = "0x1033C80", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv26 = *([1EAE110]);\n\tv27 = *([v26 @ X8_v12]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, sourceIndex, destIndex, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2026293]) = v44;\nL_001F:\n\tObi.ObiNativeList`1<System.Int32>::Swap(this.firstTriangle, sourceIndex, destIndex);\n\tObi.ObiNativeList`1<System.Single>::Swap(this.restVolumes, sourceIndex, destIndex);\n\tObi.ObiNativeList`1<UnityEngine.Vector2>::Swap(this.pressureStiffness, sourceIndex, destIndex);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void SwapConstraints(int sourceIndex, int destIndex)
		{
			firstTriangle.Swap(sourceIndex, destIndex);
			restVolumes.Swap(sourceIndex, destIndex);
			pressureStiffness.Swap(sourceIndex, destIndex);
		}

		[Token(Token = "0x6000197")]
		[Address(RVA = "0x1033D30", Offset = "0x1033D30", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1EB7EB0]);\n\tv29 = *([v28 @ X8_v19]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, constraints, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2026294]) = v47;\nL_0018:\n\tv187 = this.particleIndices;\nL_0028:\n\tv80 = v159 >= v187.m_Count;\n\tif (v80) goto L_0084;\n\tgoto L_0057;\n\tv234 = *([v230 @ X8_v9+B0]);\n\tv235 = 0;\n\tv236 = v234 + 8;\n\tv238 = *([v275 @ X11_v9-8]);\n\tv280 = v238 == v231;\n\tif (v280) goto L_0050;\n\tv258 = v274 + 1;\n\tv291 = v258 < v232;\n\tv256 = ~v291;\n\tv260 = v275 + 0x10;\n\tv240 = ~v256;\n\tif (v240) goto L_FFFFFFFF;\n\tv261 = v20;\n\tv262 = 0;\n\tv263 = 0x8909C4(v261, v231, v262, v60, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_0057;\nL_0050:\n\tv292 = *([v275 @ X11_v9]);\n\tv293 = v292 << 4;\n\tv294 = v230 + v293;\n\tv295 = v294 + 0x130;\nL_0057:\n\tv166 = Obi.IObiConstraints::GetActor(constraints);\n\tv181 = this.source;\n\tv63 = v166.solverIndices;\n\tv167 = Obi.ObiNativeIntList::get_Item(v181.particleIndices, v159);\n\tv344 = v167 < v63.Length;\n\tv126 = ~v344;\n\tif (v126) goto L_00A1;\n\tv164 = Obi.ObiNativeIntList::set_Item(v187, v159, v63[v167 @ X0_v14 (System.Int32)]);\n\tv159 = v159 + 1;\n\tv347 = this.particleIndices == 0;\n\tv170 = ~v347;\n\tif (v170) goto L_0028;\n\tthrow System.NullReferenceException;\nL_0084:\n\tv183 = this.firstTriangle;\n\tv149 = this.restVolumes;\n\tv136 = this.pressureStiffness;\n\tOni::SetVolumeConstraints(this.batch, v187.m_AlignedPtr, v183.m_AlignedPtr, v149.m_AlignedPtr, v136.m_AlignedPtr, this.m_ConstraintCount);\n\tOni::SetActiveConstraints(this.batch, this.m_ActiveConstraintCount);\n\treturn;\nL_00A1:\n\tv348 = new System.IndexOutOfRangeException();\n\tthrow v348;\n\treturn;\n// 114 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void OnAddToSolver(IObiConstraints constraints)
		{
			ObiNativeIntList obiNativeIntList = particleIndices;
			int num = 0;
			bool flag2;
			do
			{
				if (num >= obiNativeIntList.count)
				{
					ObiNativeIntList obiNativeIntList2 = firstTriangle;
					ObiNativeFloatList obiNativeFloatList = restVolumes;
					ObiNativeVector2List obiNativeVector2List = pressureStiffness;
					Oni.SetVolumeConstraints(oniBatch, obiNativeIntList.m_AlignedPtr, obiNativeIntList2.m_AlignedPtr, obiNativeFloatList.m_AlignedPtr, obiNativeVector2List.m_AlignedPtr, constraintCount);
					Oni.SetActiveConstraints(oniBatch, activeConstraintCount);
					return;
				}
				ObiActor actor = constraints.GetActor();
				ObiConstraintsBatch obiConstraintsBatch = source;
				int[] solverIndices = actor.solverIndices;
				int num2 = obiConstraintsBatch.particleIndices.get_Item(num);
				if (num2 < solverIndices.Length)
				{
					obiNativeIntList.set_Item(num, solverIndices[num2]);
					num++;
					bool flag = particleIndices == null;
					flag2 = !flag;
					obiNativeIntList = particleIndices;
					continue;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			while (flag2);
			throw new NullReferenceException();
		}

		[Token(Token = "0x6000198")]
		[Address(RVA = "0x1033F98", Offset = "0x1033F98", Length = "0x740")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1EE1200]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, compliance, pressure, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2026295]) = v44;\nL_001B:\n\tv46 = 0;\n\tv50 = 0x1588A6C(&v46 @ stack_-38_v1, 0, v30, v31, v32, v33, v34, v35, pressure, compliance, v36, v37, v38, v39, v40, v41);\n\tv116 = this.pressureStiffness;\nL_002B:\n\tv55 = v119 >= v116.m_Count;\n\tif (v55) goto L_0042;\n\tv147 = Obi.ObiNativeVector2List::set_Item(v116, v119, Vector2_arg);\n\tv116 = this.pressureStiffness;\n\tv119 = v119 + 1;\n\tv148 = this.pressureStiffness == 0;\n\tv95 = ~v148;\n\tif (v95) goto L_002B;\n\tthrow System.NullReferenceException;\nL_0042:\n\treturn;\n\t// 67 ShiftStack -80\n\tstack[0] = V13;\n\tstack[8] = V12;\n\tstack[10] = V11;\n\tstack[18] = V10;\n\tstack[20] = V9;\n\tstack[28] = V8;\n\tstack[30] = X20;\n\tstack[38] = X19;\n\tstack[40] = X29;\n\tstack[48] = X30;\n\tX29 = &stack[40];\n\tX8 = *([2026296]);\n\tX19 = X0;\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_005C;\n\tX8 = *([1EBB968]);\n\tX0 = *([X8]);\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([2026296]) = X8;\nL_005C:\n\tX8 = 0x1EE1000;\n\tX8 = *([1EE1550]);\n\tV8 = *([X19+C]);\n\tV13 = *([X19+10]);\n\tV12 = *([X19+14]);\n\tV10 = *([X19+18]);\n\tV11 = *([X19+4]);\n\tV9 = *([X19+8]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_006E;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_006E;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_006E:\n\tV2 = V10;\n\tV3 = V11;\n\tV4 = V9;\n\tV5 = V8;\n\tX29 = stack[40];\n\tX30 = stack[48];\n\tX20 = stack[30];\n\tX19 = stack[38];\n\tV9 = stack[20];\n\tV8 = stack[28];\n\tV11 = stack[10];\n\tV10 = stack[18];\n\tV0 = V13;\n\tV1 = V12;\n\tX0 = 0;\n\tV13 = stack[0];\n\tV12 = stack[8];\n\t// 127 ShiftStack 80\n\t// 128 MakeStruct AGG10340E4_0, typeof(UnityEngine.Vector3), V0, V1, V2\n\t// 129 MakeStruct AGG10340E4_1, typeof(UnityEngine.Vector3), V3, V4, V5\n\tV0 = UnityEngine.Vector3::op_Addition(AGG10340E4_0, AGG10340E4_1, X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\treturn;\n\t// 134 ShiftStack -80\n\tstack[0] = V13;\n\tstack[8] = V12;\n\tstack[10] = V11;\n\tstack[18] = V10;\n\tstack[20] = V9;\n\tstack[28] = V8;\n\tstack[30] = X20;\n\tstack[38] = X19;\n\tstack[40] = X29;\n\tstack[48] = X30;\n\tX29 = &stack[40];\n\tX8 = *([2026297]);\n\tX19 = X0;\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_009F;\n\tX8 = *([1EDBB78]);\n\tX0 = *([X8]);\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([2026297]) = X8;\nL_009F:\n\tX8 = 0x1EE1000;\n\tX8 = *([1EE1550]);\n\tV13 = *([X19+10]);\n\tV12 = *([X19+14]);\n\tV11 = *([X19+18]);\n\tV9 = *([X19+1C]);\n\tV10 = *([X19+20]);\n\tV8 = *([X19+24]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_00B1;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00B1;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00B1:\n\tV2 = V11;\n\tV3 = V9;\n\tV4 = V10;\n\tV5 = V8;\n\tX29 = stack[40];\n\tX30 = stack[48];\n\tX20 = stack[30];\n\tX19 = stack[38];\n\tV9 = stack[20];\n\tV8 = stack[28];\n\tV11 = stack[10];\n\tV10 = stack[18];\n\tV0 = V13;\n\tV1 = V12;\n\tX0 = 0;\n\tV13 = stack[0];\n\tV12 = stack[8];\n\t// 194 ShiftStack 80\n\t// 195 MakeStruct AGG1034184_0, typeof(UnityEngine.Vector3), V0, V1, V2\n\t// 196 MakeStruct AGG1034184_1, typeof(UnityEngine.Vector3), V3, V4, V5\n\tV0 = UnityEngine.Vector3::op_Addition(AGG1034184_0, AGG1034184_1, X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\treturn;\n\tV7 = stack[4];\n\tV6 = stack[8];\n\tV16 = stack[0];\n\t*([X0]) = 0;\n\t*([X0+4]) = V0;\n\t*([X0+8]) = V1;\n\t*([X0+C]) = V2;\n\t*([X0+10]) = V3;\n\t*([X0+14]) = V4;\n\t*([X0+18]) = V5;\n\t*([X0+1C]) = V16;\n\t*([X0+20]) = V7;\n\t*([X0+24]) = V6;\n\treturn;\n\t// 215 ShiftStack -128\n\tstack[10] = V13;\n\tstack[18] = V12;\n\tstack[20] = V11;\n\tstack[28] = V10;\n\tstack[30] = V9;\n\tstack[38] = V8;\n\tstack[40] = X23;\n\tstack[50] = X22;\n\tstack[58] = X21;\n\tstack[60] = X20;\n\tstack[68] = X19;\n\tstack[70] = X29;\n\tstack[78] = X30;\n\tX29 = &stack[70];\n\tX8 = *([2026298]);\n\tV8 = V2;\n\tV9 = V1;\n\tV10 = V0;\n\tX19 = X0;\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00F6;\n\tX8 = *([1EC0560]);\n\tX0 = *([X8]);\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([2026298]) = X8;\nL_00F6:\n\tstack[8] = 0;\n\tX23 = *([1EE1550]);\n\tstack[0] = 0;\n\tV13 = *([X19+10]);\n\tV11 = *([X19+14]);\n\tV12 = *([X19+18]);\n\tX0 = *([X23]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0107;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0107;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0107:\n\tV0 = V10;\n\tV1 = V9;\n\tV2 = V8;\n\tV3 = V13;\n\tV4 = V11;\n\tV5 = V12;\n\tX0 = 0;\n\t// 270 MakeStruct AGG1034250_0, typeof(UnityEngine.Vector3), V0, V1, V2\n\t// 271 MakeStruct AGG1034250_1, typeof(UnityEngine.Vector3), V3, V4, V5\n\tV0 = UnityEngine.Vector3::op_Subtraction(AGG1034250_0, AGG1034250_1, X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV8 = V0;\n\tV9 = V1;\n\tV10 = V2;\n\tstack[0] = V8;\n\tstack[4] = V9;\n\tstack[8] = V10;\n\tX8 = *([X19]);\n\tif (TEMP) goto L_013D;\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX20 = V8;\n\tX21 = V9;\n\tX22 = V10;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_016A;\n\tX0 = *([X23]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0134;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0134;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0134:\n\tV0 = V8;\n\tV1 = V9;\n\tV2 = V10;\n\tX0 = 0;\n\t// 312 MakeStruct AGG10342AC_0, typeof(UnityEngine.Vector3), V0, V1, V2\n\tV0 = UnityEngine.Vector3::op_UnaryNegation(AGG10342AC_0, X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tgoto L_0167;\nL_013D:\n\tX0 = &stack[0];\n\tX1 = 0;\n\tX0 = 0x158A710(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X23]);\n\tV8 = V0;\n\tV9 = V1;\n\tV10 = V2;\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_014D;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_014D;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_014D:\n\tV0 = V8;\n\tV1 = V9;\n\tV2 = V10;\n\tX0 = 0;\n\t// 337 MakeStruct AGG10342F4_0, typeof(UnityEngine.Vector3), V0, V1, V2\n\tV0 = UnityEngine.Vector3::op_UnaryNegation(AGG10342F4_0, X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tX0 = X19 + 0x1C;\n\tX1 = 0;\n\tV8 = V0;\n\tV9 = V1;\n\tV10 = V2;\n\tX0 = 0x158AD58(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV3 = V0;\n\tV0 = V8;\n\tV1 = V9;\n\tV2 = V10;\n\tX0 = 0;\n\t// 352 MakeStruct AGG1034324_0, typeof(UnityEngine.Vector3), V0, V1, V2\n\tV0 = UnityEngine.Vector3::op_Multiply(AGG1034324_0, V3, X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tX20 = stack[0];\n\tX21 = stack[4];\n\tX22 = stack[8];\nL_0167:\n\t*([X19+1C]) = V0;\n\t*([X19+20]) = V1;\n\t*([X19+24]) = V2;\nL_016A:\n\t*([X19+4]) = X20;\n\t*([X19+8]) = X21;\n\t*([X19+C]) = X22;\n\tX29 = stack[70];\n\tX30 = stack[78];\n\tX20 = stack[60];\n\tX19 = stack[68];\n\tX22 = stack[50];\n\tX21 = stack[58];\n\tX23 = stack[40];\n\tV9 = stack[30];\n\tV8 = stack[38];\n\tV11 = stack[20];\n\tV10 = stack[28];\n\tV13 = stack[10];\n\tV12 = stack[18];\n\t// 378 ShiftStack 128\n\treturn;\n\t// 380 ShiftStack -128\n\tstack[10] = V13;\n\tstack[18] = V12;\n\tstack[20] = V11;\n\tstack[28] = V10;\n\tstack[30] = V9;\n\tstack[38] = V8;\n\tstack[40] = X23;\n\tstack[50] = X22;\n\tstack[58] = X21;\n\tstack[60] = X20;\n\tstack[68] = X19;\n\tstack[70] = X29;\n\tstack[78] = X30;\n\tX29 = &stack[70];\n\tX8 = *([2026299]);\n\tV8 = V2;\n\tV9 = V1;\n\tV10 = V0;\n\tX19 = X0;\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_019B;\n\tX8 = *([1EEA9B0]);\n\tX0 = *([X8]);\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([2026299]) = X8;\nL_019B:\n\tstack[8] = 0;\n\tX23 = *([1EE1550]);\n\tstack[0] = 0;\n\tV13 = *([X19+10]);\n\tV11 = *([X19+14]);\n\tV12 = *([X19+18]);\n\tX0 = *([X23]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_01AC;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_01AC;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_01AC:\n\tV0 = V10;\n\tV1 = V9;\n\tV2 = V8;\n\tV3 = V13;\n\tV4 = V11;\n\tV5 = V12;\n\tX0 = 0;\n\t// 435 MakeStruct AGG1034408_0, typeof(UnityEngine.Vector3), V0, V1, V2\n\t// 436 MakeStruct AGG1034408_1, typeof(UnityEng\n// ... truncated")]
		public void SetParameters(float compliance, float pressure)
		{
			//IL_0091: Expected O, but got I4
			//IL_002e: Expected F4, but got O
			object obj = 0;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
			ObiNativeVector2List obiNativeVector2List = pressureStiffness;
			int num = 0;
			Vector2 value = default(Vector2);
			object obj2 = default(object);
			while (num < obiNativeVector2List.count)
			{
				value.x = 0f;
				value.y = (float)obj2;
				obiNativeVector2List.set_Item(num, value);
				obiNativeVector2List = pressureStiffness;
				num++;
				if (pressureStiffness == null)
				{
					throw new NullReferenceException();
				}
			}
		}
	}
}
