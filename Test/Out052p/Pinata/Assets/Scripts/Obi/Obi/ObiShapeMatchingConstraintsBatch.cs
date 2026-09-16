using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Serializable]
	[Token(Token = "0x200000F")]
	public class ObiShapeMatchingConstraintsBatch : ObiConstraintsBatch
	{
		[Token(Token = "0x400002B")]
		[FieldOffset(Offset = "0x48")]
		public ObiNativeIntList firstIndex;

		[Token(Token = "0x400002C")]
		[FieldOffset(Offset = "0x50")]
		public ObiNativeIntList numIndices;

		[Token(Token = "0x400002D")]
		[FieldOffset(Offset = "0x58")]
		public ObiNativeIntList explicitGroup;

		[Token(Token = "0x400002E")]
		[FieldOffset(Offset = "0x60")]
		public ObiNativeFloatList materialParameters;

		[Token(Token = "0x400002F")]
		[FieldOffset(Offset = "0x68")]
		public ObiNativeVector4List restComs;

		[Token(Token = "0x4000030")]
		[FieldOffset(Offset = "0x70")]
		public ObiNativeVector4List coms;

		[Token(Token = "0x4000031")]
		[FieldOffset(Offset = "0x78")]
		public ObiNativeQuaternionList orientations;

		[Token(Token = "0x1700001F")]
		public override Oni.ConstraintType constraintType
		{
			[Token(Token = "0x600016A")]
			[Address(RVA = "0x10228F4", Offset = "0x10228F4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 5;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Oni.ConstraintType.ShapeMatching;
			}
		}

		[Token(Token = "0x600016B")]
		[Address(RVA = "0x10228FC", Offset = "0x10228FC", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1EE92F0]);\n\tv25 = *([v24 @ X8_v8]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, source, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20261F9]) = v43;\nL_0019:\n\tv47 = new Obi.ObiNativeIntList();\n\tObi.ObiNativeIntList::.ctor(v47, 8, 0x10);\n\tthis.firstIndex = v47;\n\tv53 = new Obi.ObiNativeIntList();\n\tObi.ObiNativeIntList::.ctor(v53, 8, 0x10);\n\tthis.numIndices = v53;\n\tv59 = new Obi.ObiNativeIntList();\n\tObi.ObiNativeIntList::.ctor(v59, 8, 0x10);\n\tthis.explicitGroup = v59;\n\tv67 = new Obi.ObiNativeFloatList();\n\tObi.ObiNativeFloatList::.ctor(v67, 8, 0x10);\n\tthis.materialParameters = v67;\n\tv75 = new Obi.ObiNativeVector4List();\n\tObi.ObiNativeVector4List::.ctor(v75, 8, 0x10);\n\tthis.restComs = v75;\n\tv81 = new Obi.ObiNativeVector4List();\n\tObi.ObiNativeVector4List::.ctor(v81, 8, 0x10);\n\tthis.coms = v81;\n\tv89 = new Obi.ObiNativeQuaternionList();\n\tObi.ObiNativeQuaternionList::.ctor(v89, 8, 0x10);\n\tthis.orientations = v89;\n\tObi.ObiConstraintsBatch::.ctor(this, source);\n\treturn;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiShapeMatchingConstraintsBatch(ObiShapeMatchingConstraintsBatch source = null)
		{
			ObiNativeIntList obiNativeIntList = new ObiNativeIntList();
			firstIndex = obiNativeIntList;
			ObiNativeIntList obiNativeIntList2 = new ObiNativeIntList();
			numIndices = obiNativeIntList2;
			explicitGroup = new ObiNativeIntList();
			materialParameters = new ObiNativeFloatList();
			restComs = new ObiNativeVector4List();
			coms = new ObiNativeVector4List();
			orientations = new ObiNativeQuaternionList();
			base._002Ector(source);
		}

		[Token(Token = "0x600016C")]
		[Address(RVA = "0x1022A54", Offset = "0x1022A54", Length = "0x1D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1ECB370]);\n\tv21 = *([v20 @ X8_v20]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20261FA]) = v40;\nL_0017:\n\tv44 = new Obi.ObiShapeMatchingConstraintsBatch();\n\tObi.ObiShapeMatchingConstraintsBatch::.ctor(v44, this);\n\tv48 = this.particleIndices;\n\tObi.ObiNativeList`1<System.Int32>::ResizeUninitialized(v44.particleIndices, v48.m_Count);\n\tv73 = this.firstIndex;\n\tObi.ObiNativeList`1<System.Int32>::ResizeUninitialized(v44.firstIndex, v73.m_Count);\n\tv74 = this.numIndices;\n\tObi.ObiNativeList`1<System.Int32>::ResizeUninitialized(v44.numIndices, v74.m_Count);\n\tv75 = this.explicitGroup;\n\tObi.ObiNativeList`1<System.Int32>::ResizeUninitialized(v44.explicitGroup, v75.m_Count);\n\tv76 = this.materialParameters;\n\tObi.ObiNativeList`1<System.Single>::ResizeUninitialized(v44.materialParameters, v76.m_Count);\n\tObi.ObiNativeList`1<System.Int32>::CopyFrom(v44.particleIndices, this.particleIndices);\n\tObi.ObiNativeList`1<System.Int32>::CopyFrom(v44.firstIndex, this.firstIndex);\n\tObi.ObiNativeList`1<System.Int32>::CopyFrom(v44.numIndices, this.numIndices);\n\tObi.ObiNativeList`1<System.Int32>::CopyFrom(v44.explicitGroup, this.explicitGroup);\n\tObi.ObiNativeList`1<System.Single>::CopyFrom(v44.materialParameters, this.materialParameters);\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::ResizeUninitialized(v44.restComs, this.m_ConstraintCount);\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::ResizeUninitialized(v44.coms, this.m_ConstraintCount);\n\tObi.ObiNativeList`1<UnityEngine.Quaternion>::ResizeUninitialized(v44.orientations, this.m_ConstraintCount);\n\treturn v44;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 116 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override IObiConstraintsBatch Clone()
		{
			ObiShapeMatchingConstraintsBatch obiShapeMatchingConstraintsBatch = new ObiShapeMatchingConstraintsBatch(this);
			ObiNativeIntList obiNativeIntList = particleIndices;
			obiShapeMatchingConstraintsBatch.particleIndices.ResizeUninitialized(obiNativeIntList.count);
			ObiNativeIntList obiNativeIntList2 = firstIndex;
			obiShapeMatchingConstraintsBatch.firstIndex.ResizeUninitialized(obiNativeIntList2.count);
			ObiNativeIntList obiNativeIntList3 = numIndices;
			obiShapeMatchingConstraintsBatch.numIndices.ResizeUninitialized(obiNativeIntList3.count);
			ObiNativeIntList obiNativeIntList4 = explicitGroup;
			obiShapeMatchingConstraintsBatch.explicitGroup.ResizeUninitialized(obiNativeIntList4.count);
			ObiNativeFloatList obiNativeFloatList = materialParameters;
			obiShapeMatchingConstraintsBatch.materialParameters.ResizeUninitialized(obiNativeFloatList.count);
			obiShapeMatchingConstraintsBatch.particleIndices.CopyFrom(particleIndices);
			obiShapeMatchingConstraintsBatch.firstIndex.CopyFrom(firstIndex);
			obiShapeMatchingConstraintsBatch.numIndices.CopyFrom(numIndices);
			obiShapeMatchingConstraintsBatch.explicitGroup.CopyFrom(explicitGroup);
			obiShapeMatchingConstraintsBatch.materialParameters.CopyFrom(materialParameters);
			obiShapeMatchingConstraintsBatch.restComs.ResizeUninitialized(constraintCount);
			obiShapeMatchingConstraintsBatch.coms.ResizeUninitialized(constraintCount);
			obiShapeMatchingConstraintsBatch.orientations.ResizeUninitialized(constraintCount);
			return obiShapeMatchingConstraintsBatch;
		}

		[Token(Token = "0x600016D")]
		[Address(RVA = "0x1022C24", Offset = "0x1022C24", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1F0FBA8]);\n\tv27 = *([v26 @ X8_v16]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, indices, isExplicit, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20261FB]) = v44;\nL_0019:\n\tObi.ObiConstraintsBatch::RegisterConstraint(this);\n\tv47 = this.particleIndices;\n\tObi.ObiNativeList`1<System.Int32>::Add(this.firstIndex, v47.m_Count);\n\tObi.ObiNativeList`1<System.Int32>::Add(this.numIndices, indices.Length);\n\tObi.ObiNativeList`1<System.Int32>::Add(this.explicitGroup, isExplicit);\n\tObi.ObiNativeList`1<System.Int32>::AddRange(this.particleIndices, indices);\n\t// 64 NewArr v58 @ X0_v12 (System.Single[]), typeof(System.Single[]), 5\n\tSystem.Runtime.CompilerServices.RuntimeHelpers::InitializeArray(v58, Il2CppFieldInfo);\n\tObi.ObiNativeList`1<System.Single>::AddRange(this.materialParameters, v58);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddConstraint(int[] indices, bool isExplicit)
		{
			RegisterConstraint();
			ObiNativeIntList obiNativeIntList = particleIndices;
			firstIndex.Add(obiNativeIntList.count);
			numIndices.Add(indices.Length);
			explicitGroup.Add(isExplicit ? 1 : 0);
			particleIndices.AddRange(indices);
			float[] enumerable = new float[5] { 1f, 1f, 1f, 1f, 1f };
			materialParameters.AddRange(enumerable);
		}

		[Token(Token = "0x600016E")]
		[Address(RVA = "0x1022D3C", Offset = "0x1022D3C", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1F0F360]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20261FC]) = v38;\nL_0015:\n\tObi.ObiConstraintsBatch::Clear(this);\n\tObi.ObiNativeList`1<System.Int32>::Clear(this.firstIndex);\n\tObi.ObiNativeList`1<System.Int32>::Clear(this.numIndices);\n\tObi.ObiNativeList`1<System.Int32>::Clear(this.explicitGroup);\n\tObi.ObiNativeList`1<System.Int32>::Clear(this.particleIndices);\n\tObi.ObiNativeList`1<System.Single>::Clear(this.materialParameters);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Clear()
		{
			base.Clear();
			firstIndex.Clear();
			numIndices.Clear();
			explicitGroup.Clear();
			particleIndices.Clear();
			materialParameters.Clear();
		}

		[Token(Token = "0x600016F")]
		[Address(RVA = "0x1022DE8", Offset = "0x1022DE8", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv28 = *([1F0BAE8]);\n\tv29 = *([v28 @ X8_v12]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, index, particles, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20261FD]) = v46;\nL_001F:\n\tv53 = Obi.ObiNativeIntList::get_Item(this.firstIndex, index);\n\tv111 = Obi.ObiNativeIntList::get_Item(this.numIndices, index);\n\tv101 = v111 + v53;\n\tv121 = v53 >= v101;\n\tif (v121) goto L_005B;\nL_003F:\n\tv140 = Obi.ObiNativeIntList::get_Item(this.particleIndices, v105);\n\tSystem.Collections.Generic.List`1<System.Int32>::Add(particles, v140);\n\tv105 = v105 + 1;\n\tv152 = v105 < v101;\n\tif (v152) goto L_003F;\nL_005B:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void GetParticlesInvolved(int index, List<int> particles)
		{
			int num = firstIndex.get_Item(index);
			int num2 = numIndices.get_Item(index);
			int num3 = num2 + num;
			if (num < num3)
			{
				int num4 = num;
				do
				{
					int item = particleIndices.get_Item(num4);
					particles.Add(item);
					num4++;
				}
				while (num4 < num3);
			}
		}

		[Token(Token = "0x6000170")]
		[Address(RVA = "0x1022ED0", Offset = "0x1022ED0", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv32 = *([1EFF828]);\n\tv33 = *([v32 @ X8_v7]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, sourceIndex, destIndex, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20261FE]) = v50;\nL_0022:\n\tObi.ObiNativeList`1<System.Int32>::Swap(this.firstIndex, sourceIndex, destIndex);\n\tObi.ObiNativeList`1<System.Int32>::Swap(this.numIndices, sourceIndex, destIndex);\n\tObi.ObiNativeList`1<System.Int32>::Swap(this.explicitGroup, sourceIndex, destIndex);\n\tv183 = sourceIndex << 2;\n\tv137 = sourceIndex + v183;\n\tv98 = destIndex << 2;\n\tv95 = destIndex + v98;\nL_003C:\n\tv119 = v137 + v100;\n\tv113 = v95 + v100;\n\tObi.ObiNativeList`1<System.Single>::Swap(this.materialParameters, v119, v113);\n\tv101 = v100 + 1;\n\tv61 = v100 < 4;\n\tif (v61) goto L_003C;\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::Swap(this.restComs, sourceIndex, destIndex);\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::Swap(this.coms, sourceIndex, destIndex);\n\tObi.ObiNativeList`1<UnityEngine.Quaternion>::Swap(this.orientations, sourceIndex, destIndex);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void SwapConstraints(int sourceIndex, int destIndex)
		{
			firstIndex.Swap(sourceIndex, destIndex);
			numIndices.Swap(sourceIndex, destIndex);
			explicitGroup.Swap(sourceIndex, destIndex);
			int num = sourceIndex << 2;
			int num2 = sourceIndex + num;
			int num3 = destIndex << 2;
			int num4 = destIndex + num3;
			int num5 = 0;
			bool flag;
			do
			{
				int index = num2 + num5;
				int index2 = num4 + num5;
				materialParameters.Swap(index, index2);
				int num6 = num5 + 1;
				flag = num5 < 4;
				num5 = num6;
			}
			while (flag);
			restComs.Swap(sourceIndex, destIndex);
			coms.Swap(sourceIndex, destIndex);
			orientations.Swap(sourceIndex, destIndex);
		}

		[Token(Token = "0x6000171")]
		[Address(RVA = "0x1023010", Offset = "0x1023010", Length = "0x328")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv28 = *([1ED0BA8]);\n\tv29 = *([v28 @ X8_v33]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, constraints, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20261FF]) = v47;\nL_001D:\n\tv209 = this.particleIndices;\nL_002D:\n\tv243 = v404 >= v209.m_Count;\n\tif (v243) goto L_0088;\n\tgoto L_005C;\n\tv497 = *([v492 @ X8_v23+B0]);\n\tv498 = 0;\n\tv499 = v497 + 8;\n\tv501 = *([v549 @ X11_v23-8]);\n\tv554 = v501 == v493;\n\tif (v554) goto L_0055;\n\tv521 = v548 + 1;\n\tv559 = v521 < v494;\n\tv519 = ~v559;\n\tv523 = v549 + 0x10;\n\tv503 = ~v519;\n\tif (v503) goto L_FFFFFFFF;\n\tv524 = v20;\n\tv525 = 0;\n\tv526 = 0x8909C4(v524, v493, v525, v214, v33, v34, v35, v36, v48, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_005C;\nL_0055:\n\tv560 = *([v549 @ X11_v23]);\n\tv561 = v560 << 4;\n\tv562 = v492 + v561;\n\tv563 = v562 + 0x130;\nL_005C:\n\tv367 = Obi.IObiConstraints::GetActor(constraints);\n\tv395 = this.source;\n\tv220 = v367.solverIndices;\n\tv368 = Obi.ObiNativeIntList::get_Item(v395.particleIndices, v404);\n\tv635 = v368 < v220.Length;\n\tv316 = ~v635;\n\tif (v316) goto L_0158;\n\tv397 = *([v209 @ X22_v6 (Obi.ObiNativeIntList)]);\n\tv369 = Obi.ObiNativeIntList::set_Item(v209, v404, v220[v368 @ X0_v33 (System.Int32)]);\n\tv209 = this.particleIndices;\n\tv404 = v404 + 1;\n\tv641 = this.particleIndices == 0;\n\tv380 = ~v641;\n\tif (v380) goto L_002D;\n\tgoto L_00F2;\nL_0088:\n\tv408 = this.orientations;\nL_0096:\n\tv245 = v211 >= v408.m_Count;\n\tif (v245) goto L_00F3;\n\tgoto L_00C5;\n\tv571 = *([v567 @ X8_v17+B0]);\n\tv572 = 0;\n\tv573 = v571 + 8;\n\tv575 = *([v612 @ X11_v17-8]);\n\tv617 = v575 == v568;\n\tif (v617) goto L_00BE;\n\tv595 = v611 + 1;\n\tv623 = v595 < v569;\n\tv593 = ~v623;\n\tv597 = v612 + 0x10;\n\tv577 = ~v593;\n\tif (v577) goto L_FFFFFFFF;\n\tv598 = v20;\n\tv599 = 0;\n\tv600 = 0x8909C4(v598, v568, v599, v214, v33, v34, v35, v36, v121, v125, v113, v117, v41, v42, v43, v44);\n\tgoto L_00C5;\nL_00BE:\n\tv624 = *([v612 @ X11_v17]);\n\tv625 = v624 << 4;\n\tv626 = v567 + v625;\n\tv627 = v626 + 0x130;\nL_00C5:\n\tv478 = Obi.IObiConstraints::GetActor(constraints);\n\tv638 = Obi.ObiActor::get_actorLocalToSolverMatrix(v478);\n\tv203 = v638.m00;\n\tv645 = 0x10C1A04(&v203 @ stack_-C0_v5 (System.Single), 0, 0, *([v397 @ X8_v29 (Il2CppClass<Obi.ObiNativeIntList>)+198]), v33, v34, v35, v36, v638.m03, v638.m02, v638.m01, v638.m00, v41, v42, v43, v44);\n\tv365 = Obi.ObiNativeQuaternionList::set_Item(v408, v211, Quaternion_arg);\n\tv211 = v211 + 1;\n\tv650 = this.orientations == 0;\n\tv375 = ~v650;\n\tif (v375) goto L_0096;\nL_00F2:\n\tthrow System.NullReferenceException;\nL_00F3:\n\tv399 = this.particleIndices;\n\tv348 = this.firstIndex;\n\tv328 = this.numIndices;\n\tv337 = this.explicitGroup;\n\tv92 = this.materialParameters;\n\tv85 = this.restComs;\n\tv81 = this.coms;\n\tOni::SetShapeMatchingConstraints(this.batch, v399.m_AlignedPtr, v348.m_AlignedPtr, v328.m_AlignedPtr, v337.m_AlignedPtr, v92.m_AlignedPtr, v85.m_AlignedPtr, v81.m_AlignedPtr, v408.m_AlignedPtr, this.m_ConstraintCount);\n\tOni::SetActiveConstraints(this.batch, this.m_ActiveConstraintCount);\n\tv651 = constraints->klass;\n\tv654 = *([v651 @ X8_v7 (Il2CppClass<Obi.IObiConstraints>)+126]) == 0;\n\tif (v654) goto L_013C;\n\tv766 = *([v651 @ X8_v7 (Il2CppClass<Obi.IObiConstraints>)+B0]) + 8;\nL_0127:\n\tv771 = *([v766 @ X11_v8-8]) == *([v363 @ X23_v2 (Il2CppClass<Obi.IObiConstraints>)]);\n\tif (v771) goto L_013F;\n\tv765 = v765 + 1;\n\tv776 = v765 < *([v651 @ X8_v7 (Il2CppClass<Obi.IObiConstraints>)+126]);\n\tv677 = ~v776;\n\tv766 = v766 + 0x10;\n\tv661 = ~v677;\n\tif (v661) goto L_0127;\nL_013C:\n\t;\n\tgoto L_0145;\nL_013F:\n\t;\nL_0145:\n\tv373 = Obi.IObiConstraints::GetActor(constraints);\n\tv401 = *([v373 @ X0_v9+48]);\n\tOni::CalculateRestShapeMatching(*([v401 @ X8_v10+A8]), this.batch);\n\treturn;\nL_0158:\n\tv642 = new System.IndexOutOfRangeException();\n\tthrow v642;\n\treturn;\n// 239 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void OnAddToSolver(IObiConstraints constraints)
		{
			//IL_0433: Expected I, but got O
			//IL_01d1: Expected I, but got O
			//IL_0080: Expected I, but got O
			//IL_00eb: Expected I, but got O
			//IL_02ce: Expected I, but got O
			//IL_0309: Expected O, but got I
			//IL_038d: Expected O, but got I
			//IL_0355: Expected O, but got I
			ObiNativeIntList obiNativeIntList = particleIndices;
			int num = 0;
			Quaternion value = default(Quaternion);
			while (true)
			{
				if (num >= obiNativeIntList.count)
				{
					ObiNativeQuaternionList obiNativeQuaternionList = orientations;
					int num2 = 0;
					bool flag5;
					do
					{
						bool flag = num2 >= obiNativeQuaternionList.count;
						IntPtr intPtr = (IntPtr)typeof(IObiConstraints);
						if (flag)
						{
							ObiNativeIntList obiNativeIntList2 = particleIndices;
							ObiNativeIntList obiNativeIntList3 = firstIndex;
							ObiNativeIntList obiNativeIntList4 = numIndices;
							ObiNativeIntList obiNativeIntList5 = explicitGroup;
							ObiNativeFloatList obiNativeFloatList = materialParameters;
							ObiNativeVector4List obiNativeVector4List = restComs;
							ObiNativeVector4List obiNativeVector4List2 = coms;
							Oni.SetShapeMatchingConstraints(oniBatch, obiNativeIntList2.m_AlignedPtr, obiNativeIntList3.m_AlignedPtr, obiNativeIntList4.m_AlignedPtr, obiNativeIntList5.m_AlignedPtr, obiNativeFloatList.m_AlignedPtr, obiNativeVector4List.m_AlignedPtr, obiNativeVector4List2.m_AlignedPtr, obiNativeQuaternionList.m_AlignedPtr, constraintCount);
							Oni.SetActiveConstraints(oniBatch, activeConstraintCount);
							IntPtr intPtr2 = (IntPtr)constraints;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v651 @ X8_v7 (Il2CppClass<Obi.IObiConstraints>)+126]");
							if ((IntPtr)0 != (IntPtr)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v651 @ X8_v7 (Il2CppClass<Obi.IObiConstraints>)+B0]");
								object obj = 0L + 8L;
								int num3 = 0;
								bool flag3;
								do
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v766 @ X11_v8-8]");
									if ((IntPtr)0 != intPtr)
									{
										num3++;
										int num4 = num3;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v651 @ X8_v7 (Il2CppClass<Obi.IObiConstraints>)+126]");
										bool flag2 = (long)num4 < 0L;
										flag3 = !flag2;
										obj = (long)(IntPtr)obj + 16L;
										continue;
									}
									break;
								}
								while (!flag3);
							}
							object actor = constraints.GetActor();
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ X0_v9+48]");
							object obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ X8_v10+A8]");
							Oni.CalculateRestShapeMatching((IntPtr)0, oniBatch);
							return;
						}
						ObiActor actor2 = constraints.GetActor();
						Matrix4x4 actorLocalToSolverMatrix = actor2.actorLocalToSolverMatrix;
						float m = actorLocalToSolverMatrix.m00;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10C1A04 (inside UnityEngine.Matrix4x4::GetLossyScale_Injected +0x50)");
						value.x = actorLocalToSolverMatrix.m03;
						value.y = actorLocalToSolverMatrix.m02;
						value.z = actorLocalToSolverMatrix.m01;
						value.w = actorLocalToSolverMatrix.m00;
						obiNativeQuaternionList.set_Item(num2, value);
						num2++;
						bool flag4 = orientations == null;
						flag5 = !flag4;
						intPtr = (IntPtr)typeof(IObiConstraints);
						obiNativeQuaternionList = orientations;
					}
					while (flag5);
					break;
				}
				ObiActor actor3 = constraints.GetActor();
				ObiConstraintsBatch obiConstraintsBatch = source;
				int[] solverIndices = actor3.solverIndices;
				int num5 = obiConstraintsBatch.particleIndices.get_Item(num);
				if (num5 < solverIndices.Length)
				{
					IntPtr intPtr3 = (IntPtr)obiNativeIntList;
					obiNativeIntList.set_Item(num, solverIndices[num5]);
					obiNativeIntList = particleIndices;
					num++;
					if (particleIndices == null)
					{
						IntPtr intPtr = (IntPtr)typeof(IObiConstraints);
						break;
					}
					continue;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x6000172")]
		[Address(RVA = "0x1023588", Offset = "0x1023588", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv42 = *([1EBFAC0]);\n\tv43 = *([v42 @ X8_v17]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, methodInfo, v46, v47, v48, v49, v50, v51, stiffness, yield, creep, recovery, maxDeformation, v52, v53, v54);\n\tv57 = 0 | 1;\n\t*([2026200]) = v57;\nL_001F:\n\tv129 = this.explicitGroup;\nL_0025:\n\tv126 = v126 + 1;\n\tv63 = v126 >= v129.m_Count;\n\tif (v63) goto L_0072;\n\tv200 = v130 - 4;\n\tv204 = Obi.ObiNativeFloatList::set_Item(this.materialParameters, v200, stiffness);\n\tv216 = v130 - 3;\n\tv229 = Obi.ObiNativeFloatList::set_Item(this.materialParameters, v216, yield);\n\tv217 = v130 - 2;\n\tv230 = Obi.ObiNativeFloatList::set_Item(this.materialParameters, v217, creep);\n\tv218 = v130 - 1;\n\tv231 = Obi.ObiNativeFloatList::set_Item(this.materialParameters, v218, recovery);\n\tv90 = v130 + 5;\n\tv103 = Obi.ObiNativeFloatList::set_Item(this.materialParameters, v130, maxDeformation);\n\tv129 = this.explicitGroup;\n\tv233 = this.explicitGroup == 0;\n\tv105 = ~v233;\n\tif (v105) goto L_0025;\n\tthrow System.NullReferenceException;\nL_0072:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetParameters(float stiffness, float yield, float creep, float recovery, float maxDeformation)
		{
			ObiNativeIntList obiNativeIntList = explicitGroup;
			int num = -1;
			int num2 = 4;
			while (true)
			{
				num++;
				if (num < obiNativeIntList.count)
				{
					int index = num2 - 4;
					materialParameters.set_Item(index, stiffness);
					int index2 = num2 - 3;
					materialParameters.set_Item(index2, yield);
					int index3 = num2 - 2;
					materialParameters.set_Item(index3, creep);
					int index4 = num2 - 1;
					materialParameters.set_Item(index4, recovery);
					int num3 = num2 + 5;
					materialParameters.set_Item(num2, maxDeformation);
					obiNativeIntList = explicitGroup;
					bool flag = explicitGroup == null;
					bool flag2 = !flag;
					num2 = num3;
					if (!flag2)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				break;
			}
		}
	}
}
