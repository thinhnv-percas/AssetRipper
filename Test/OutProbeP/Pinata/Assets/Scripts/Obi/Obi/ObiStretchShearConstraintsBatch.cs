using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Serializable]
	[Token(Token = "0x2000011")]
	public class ObiStretchShearConstraintsBatch : ObiConstraintsBatch, IStructuralConstraintBatch
	{
		[HideInInspector]
		[Token(Token = "0x4000036")]
		[FieldOffset(Offset = "0x48")]
		public ObiNativeIntList orientationIndices;

		[HideInInspector]
		[Token(Token = "0x4000037")]
		[FieldOffset(Offset = "0x50")]
		public ObiNativeFloatList restLengths;

		[HideInInspector]
		[Token(Token = "0x4000038")]
		[FieldOffset(Offset = "0x58")]
		public ObiNativeQuaternionList restOrientations;

		[HideInInspector]
		[Token(Token = "0x4000039")]
		[FieldOffset(Offset = "0x60")]
		public ObiNativeVector3List stiffnesses;

		[Token(Token = "0x17000021")]
		public override Oni.ConstraintType constraintType
		{
			[Token(Token = "0x600017B")]
			[Address(RVA = "0x102F5C4", Offset = "0x102F5C4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 7;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Oni.ConstraintType.StretchShear;
			}
		}

		[Token(Token = "0x600017C")]
		[Address(RVA = "0x102F5CC", Offset = "0x102F5CC", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EBB6C8]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, source, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2026268]) = v41;\nL_0018:\n\tv45 = new Obi.ObiNativeIntList();\n\tObi.ObiNativeIntList::.ctor(v45, 8, 0x10);\n\tthis.orientationIndices = v45;\n\tv53 = new Obi.ObiNativeFloatList();\n\tObi.ObiNativeFloatList::.ctor(v53, 8, 0x10);\n\tthis.restLengths = v53;\n\tv61 = new Obi.ObiNativeQuaternionList();\n\tObi.ObiNativeQuaternionList::.ctor(v61, 8, 0x10);\n\tthis.restOrientations = v61;\n\tv69 = new Obi.ObiNativeVector3List();\n\tObi.ObiNativeVector3List::.ctor(v69, 8, 0x10);\n\tthis.stiffnesses = v69;\n\tObi.ObiConstraintsBatch::.ctor(this, source);\n\treturn;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiStretchShearConstraintsBatch(ObiStretchShearConstraintsBatch source = null)
		{
			ObiNativeIntList obiNativeIntList = new ObiNativeIntList();
			orientationIndices = obiNativeIntList;
			ObiNativeFloatList obiNativeFloatList = new ObiNativeFloatList();
			restLengths = obiNativeFloatList;
			restOrientations = new ObiNativeQuaternionList();
			stiffnesses = new ObiNativeVector3List();
			base._002Ector(source);
		}

		[Token(Token = "0x600017D")]
		[Address(RVA = "0x102F6C4", Offset = "0x102F6C4", Length = "0x1A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EABD88]);\n\tv21 = *([v20 @ X8_v26]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2026269]) = v40;\nL_0017:\n\tv44 = new Obi.ObiStretchShearConstraintsBatch();\n\tObi.ObiStretchShearConstraintsBatch::.ctor(v44, this);\n\tv48 = this.particleIndices;\n\tObi.ObiNativeList`1<System.Int32>::ResizeUninitialized(v44.particleIndices, v48.m_Count);\n\tv73 = this.orientationIndices;\n\tObi.ObiNativeList`1<System.Int32>::ResizeUninitialized(v44.orientationIndices, v73.m_Count);\n\tv74 = this.restLengths;\n\tObi.ObiNativeList`1<System.Single>::ResizeUninitialized(v44.restLengths, v74.m_Count);\n\tv75 = this.restOrientations;\n\tObi.ObiNativeList`1<UnityEngine.Quaternion>::ResizeUninitialized(v44.restOrientations, v75.m_Count);\n\tv76 = this.stiffnesses;\n\tObi.ObiNativeList`1<UnityEngine.Vector3>::ResizeUninitialized(v44.stiffnesses, v76.m_Count);\n\tObi.ObiNativeList`1<System.Int32>::CopyFrom(v44.particleIndices, this.particleIndices);\n\tObi.ObiNativeList`1<System.Int32>::CopyFrom(v44.orientationIndices, this.orientationIndices);\n\tObi.ObiNativeList`1<System.Single>::CopyFrom(v44.restLengths, this.restLengths);\n\tObi.ObiNativeList`1<UnityEngine.Quaternion>::CopyFrom(v44.restOrientations, this.restOrientations);\n\tObi.ObiNativeList`1<UnityEngine.Vector3>::CopyFrom(v44.stiffnesses, this.stiffnesses);\n\treturn v44;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 105 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override IObiConstraintsBatch Clone()
		{
			ObiStretchShearConstraintsBatch obiStretchShearConstraintsBatch = new ObiStretchShearConstraintsBatch(this);
			ObiNativeIntList obiNativeIntList = particleIndices;
			obiStretchShearConstraintsBatch.particleIndices.ResizeUninitialized(obiNativeIntList.count);
			ObiNativeIntList obiNativeIntList2 = orientationIndices;
			obiStretchShearConstraintsBatch.orientationIndices.ResizeUninitialized(obiNativeIntList2.count);
			ObiNativeFloatList obiNativeFloatList = restLengths;
			obiStretchShearConstraintsBatch.restLengths.ResizeUninitialized(obiNativeFloatList.count);
			ObiNativeQuaternionList obiNativeQuaternionList = restOrientations;
			obiStretchShearConstraintsBatch.restOrientations.ResizeUninitialized(obiNativeQuaternionList.count);
			ObiNativeVector3List obiNativeVector3List = stiffnesses;
			obiStretchShearConstraintsBatch.stiffnesses.ResizeUninitialized(obiNativeVector3List.count);
			obiStretchShearConstraintsBatch.particleIndices.CopyFrom(particleIndices);
			obiStretchShearConstraintsBatch.orientationIndices.CopyFrom(orientationIndices);
			obiStretchShearConstraintsBatch.restLengths.CopyFrom(restLengths);
			obiStretchShearConstraintsBatch.restOrientations.CopyFrom(restOrientations);
			obiStretchShearConstraintsBatch.stiffnesses.CopyFrom(stiffnesses);
			return obiStretchShearConstraintsBatch;
		}

		[Token(Token = "0x600017E")]
		[Address(RVA = "0x102F868", Offset = "0x102F868", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv46 = *([1EAEE98]);\n\tv47 = *([v46 @ X8_v18]);\n\tv48 = \"il2cpp_codegen_initialize_method\"(v47, indices, orientationIndex, methodInfo, v50, v51, v52, v53, restLength, restOrientation, v0, v2, v3, v54, v55, v56);\n\tv59 = 0 | 1;\n\t*([202626A]) = v59;\nL_0026:\n\tObi.ObiConstraintsBatch::RegisterConstraint(this);\n\tv66 = new System.TypeLoadException();\n\tObi.ObiNativeList`1<System.Int32>::Add(this.particleIndices, v66);\n\tv88 = new System.TypeLoadException();\n\tObi.ObiNativeList`1<System.Int32>::Add(this.particleIndices, v88);\n\tObi.ObiNativeList`1<System.Int32>::Add(this.orientationIndices, orientationIndex);\n\tObi.ObiNativeList`1<System.Single>::Add(this.restLengths, restLength);\n\tObi.ObiNativeList`1<UnityEngine.Quaternion>::Add(this.restOrientations, restOrientation);\n\tgoto L_0067;\n\tv182 = *([v178 @ X0_v16+E0]);\n\tv183 = v182 == 0;\n\tv184 = ~v183;\n\tif (v184) goto L_0067;\n\tv186 = \"il2cpp_codegen_runtime_class_init\"(v178, v86, v83, methodInfo, v50, v51, v52, v53, v173, v174, v175, v100, v3, v54, v55, v56);\nL_0067:\n\tv79 = UnityEngine.Vector3::get_zero();\n\tObi.ObiNativeList`1<UnityEngine.Vector3>::Add(this.stiffnesses, v79);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 105 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddConstraint(Vector2Int indices, int orientationIndex, float restLength, Quaternion restOrientation)
		{
			//IL_0014: Expected I4, but got O
			//IL_0031: Expected I4, but got O
			RegisterConstraint();
			TypeLoadException ex = new TypeLoadException();
			particleIndices.Add((int)ex);
			TypeLoadException ex2 = new TypeLoadException();
			particleIndices.Add((int)ex2);
			orientationIndices.Add(orientationIndex);
			restLengths.Add(restLength);
			restOrientations.Add(restOrientation);
			Vector3 zero = Vector3.zero;
			stiffnesses.Add(zero);
		}

		[Token(Token = "0x600017F")]
		[Address(RVA = "0x102F9EC", Offset = "0x102F9EC", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1F0F750]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202626B]) = v38;\nL_0015:\n\tObi.ObiConstraintsBatch::Clear(this);\n\tObi.ObiNativeList`1<System.Int32>::Clear(this.particleIndices);\n\tObi.ObiNativeList`1<System.Int32>::Clear(this.orientationIndices);\n\tObi.ObiNativeList`1<System.Single>::Clear(this.restLengths);\n\tObi.ObiNativeList`1<UnityEngine.Quaternion>::Clear(this.restOrientations);\n\tObi.ObiNativeList`1<UnityEngine.Vector3>::Clear(this.stiffnesses);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Clear()
		{
			base.Clear();
			particleIndices.Clear();
			orientationIndices.Clear();
			restLengths.Clear();
			restOrientations.Clear();
			stiffnesses.Clear();
		}

		[Token(Token = "0x6000180")]
		[Address(RVA = "0x102FAA8", Offset = "0x102FAA8", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.restLengths;\n\tv3 = *([v0 @ X0_v1 (Obi.ObiNativeFloatList)]);\n\tv4 = *([v3 @ X8_v1 (Il2CppClass<Obi.ObiNativeFloatList>)+180]);\n\tv5 = *([v3 @ X8_v1 (Il2CppClass<Obi.ObiNativeFloatList>)+188]);\n\t// 6 IndirectJump v4 @ X3_v1, v0 @ X0_v1 (Obi.ObiNativeFloatList), v0 @ X0_v1 (Obi.ObiNativeFloatList), index @ X1 (System.Int32), v5 @ X2_v1, v4 @ X3_v1, v7 @ X4, v8 @ X5, v9 @ X6, v10 @ X7, returnVal1 @ V0, v12 @ V1, v13 @ V2, v14 @ V3, v15 @ V4, v16 @ V5, v17 @ V6, v18 @ V7\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public float GetRestLength(int index)
		{
			//IL_0017: Expected I, but got O
			//IL_0027: Expected O, but got I
			//IL_0037: Expected O, but got I
			ObiNativeFloatList obiNativeFloatList = restLengths;
			IntPtr intPtr = (IntPtr)obiNativeFloatList;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ X8_v1 (Il2CppClass<Obi.ObiNativeFloatList>)+180]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ X8_v1 (Il2CppClass<Obi.ObiNativeFloatList>)+188]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v4 @ X3_v1 (should have been resolved before IL gen)");
			return 0f;
		}

		[Token(Token = "0x6000181")]
		[Address(RVA = "0x102FAC8", Offset = "0x102FAC8", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.restLengths;\n\tv3 = *([v0 @ X0_v1 (Obi.ObiNativeFloatList)]);\n\tv4 = *([v3 @ X8_v1 (Il2CppClass<Obi.ObiNativeFloatList>)+190]);\n\tv5 = *([v3 @ X8_v1 (Il2CppClass<Obi.ObiNativeFloatList>)+198]);\n\t// 6 IndirectJump v4 @ X3_v1, v0 @ X0_v1 (Obi.ObiNativeFloatList), v0 @ X0_v1 (Obi.ObiNativeFloatList), index @ X1 (System.Int32), v5 @ X2_v1, v4 @ X3_v1, v7 @ X4, v8 @ X5, v9 @ X6, v10 @ X7, restLength @ V0 (System.Single), v12 @ V1, v13 @ V2, v14 @ V3, v15 @ V4, v16 @ V5, v17 @ V6, v18 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetRestLength(int index, float restLength)
		{
			//IL_0017: Expected I, but got O
			//IL_0027: Expected O, but got I
			//IL_0037: Expected O, but got I
			ObiNativeFloatList obiNativeFloatList = restLengths;
			IntPtr intPtr = (IntPtr)obiNativeFloatList;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ X8_v1 (Il2CppClass<Obi.ObiNativeFloatList>)+190]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ X8_v1 (Il2CppClass<Obi.ObiNativeFloatList>)+198]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v4 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000182")]
		[Address(RVA = "0x102FAE8", Offset = "0x102FAE8", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.particleIndices;\n\tv15 = v58 << 1;\n\tv20 = Obi.ObiNativeIntList::get_Item(v12, v15);\n\tv36 = this.particleIndices == 0;\n\tif (v36) goto L_0028;\n\tv40 = v15 | 1;\n\tv44 = Obi.ObiNativeIntList::get_Item(this.particleIndices, v40);\n\tv48 = v44 & 0xFFFFFFFF;\n\tv49 = v48 << 0x20;\n\tv50 = v20 & 0xFFFFFFFF;\n\tv51 = v50 | v49;\n\treturn v51;\n\tthrow System.NullReferenceException;\nL_0028:\n\treturnVal2 = new System.NullReferenceException();\n\t*([returnVal2 @ X0_v4 (System.NullReferenceException)]) = v58;\n\t*([returnVal2 @ X0_v4 (System.NullReferenceException)+4]) = v55;\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ParticlePair GetParticleIndices(int index)
		{
			//IL_00c5: Expected O, but got I4
			//IL_0082: Expected I4, but got I8
			//IL_00a2: Expected I4, but got I8
			//IL_00b4: Expected O, but got I4
			ObiNativeIntList obiNativeIntList = particleIndices;
			int num2 = default(int);
			int num = num2 << 1;
			int num3 = obiNativeIntList.get_Item(num);
			if (particleIndices != null)
			{
				int index2 = num | 1;
				int num4 = particleIndices.get_Item(index2);
				int num5 = (int)(num4 & 0xFFFFFFFFL);
				int num6 = num5 << 32;
				int num7 = (int)(num3 & 0xFFFFFFFFL);
				int num8 = num7 | num6;
				return (ParticlePair)num8;
			}
			NullReferenceException ex = new NullReferenceException();
			return (ParticlePair)num2;
		}

		[Token(Token = "0x6000183")]
		[Address(RVA = "0x102FB60", Offset = "0x102FB60", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1EE1F28]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, index, particles, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202626C]) = v44;\nL_001B:\n\tv48 = index << 1;\n\tv52 = Obi.ObiNativeIntList::get_Item(this.particleIndices, v48);\n\tSystem.Collections.Generic.List`1<System.Int32>::Add(particles, v52);\n\tv82 = v48 | 1;\n\tv85 = Obi.ObiNativeIntList::get_Item(this.particleIndices, v82);\n\tSystem.Collections.Generic.List`1<System.Int32>::Add(particles, v85);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void GetParticlesInvolved(int index, List<int> particles)
		{
			int num = index << 1;
			int item = particleIndices.get_Item(num);
			particles.Add(item);
			int index2 = num | 1;
			int item2 = particleIndices.get_Item(index2);
			particles.Add(item2);
		}

		[Token(Token = "0x6000184")]
		[Address(RVA = "0x102FC18", Offset = "0x102FC18", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv30 = *([1ED32D0]);\n\tv31 = *([v30 @ X8_v12]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, sourceIndex, destIndex, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([202626D]) = v48;\nL_001E:\n\tv53 = sourceIndex << 1;\n\tv54 = destIndex << 1;\n\tObi.ObiNativeList`1<System.Int32>::Swap(this.particleIndices, v53, v54);\n\tv69 = v53 | 1;\n\tv59 = v54 | 1;\n\tObi.ObiNativeList`1<System.Int32>::Swap(this.particleIndices, v69, v59);\n\tObi.ObiNativeList`1<System.Int32>::Swap(this.orientationIndices, sourceIndex, destIndex);\n\tObi.ObiNativeList`1<System.Single>::Swap(this.restLengths, sourceIndex, destIndex);\n\tObi.ObiNativeList`1<UnityEngine.Quaternion>::Swap(this.restOrientations, sourceIndex, destIndex);\n\tObi.ObiNativeList`1<UnityEngine.Vector3>::Swap(this.stiffnesses, sourceIndex, destIndex);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void SwapConstraints(int sourceIndex, int destIndex)
		{
			int num = sourceIndex << 1;
			int num2 = destIndex << 1;
			particleIndices.Swap(num, num2);
			int index = num | 1;
			int index2 = num2 | 1;
			particleIndices.Swap(index, index2);
			orientationIndices.Swap(sourceIndex, destIndex);
			restLengths.Swap(sourceIndex, destIndex);
			restOrientations.Swap(sourceIndex, destIndex);
			stiffnesses.Swap(sourceIndex, destIndex);
		}

		[Token(Token = "0x6000185")]
		[Address(RVA = "0x102FD28", Offset = "0x102FD28", Length = "0x39C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv32 = *([1EBE1C8]);\n\tv33 = *([v32 @ X8_v36]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, constraints, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([202626E]) = v51;\nL_001A:\n\tv261 = this.restLengths;\nL_002C:\n\tv98 = v273 >= v261.m_Count;\n\tif (v98) goto L_016F;\n\tgoto L_005C;\n\tv413 = *([v382 @ X8_v9+B0]);\n\tv414 = 0;\n\tv415 = v413 + 8;\n\tv417 = *([v457 @ X11_v25-8]);\n\tv462 = v417 == v383;\n\tif (v462) goto L_0055;\n\tv437 = v456 + 1;\n\tv467 = v437 < v384;\n\tv435 = ~v467;\n\tv439 = v457 + 0x10;\n\tv419 = ~v435;\n\tif (v419) goto L_FFFFFFFF;\n\tv440 = v24;\n\tv441 = 0;\n\tv442 = 0x8909C4(v440, v383, v441, v67, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tgoto L_005C;\nL_0055:\n\tv468 = *([v457 @ X11_v25]);\n\tv469 = v468 << 4;\n\tv470 = v382 + v469;\n\tv471 = v470 + 0x130;\nL_005C:\n\tv234 = Obi.IObiConstraints::GetActor(constraints);\n\tv262 = this.source;\n\tv78 = v234.solverIndices;\n\tv73 = v273 << 1;\n\tv235 = Obi.ObiNativeIntList::get_Item(v262.particleIndices, v73);\n\tv528 = v235 < v78.Length;\n\tv177 = ~v528;\n\tif (v177) goto L_0196;\n\tv536 = Obi.ObiNativeIntList::set_Item(this.particleIndices, v73, v78[v235 @ X0_v19 (System.Int32)]);\n\tv228 = this.particleIndices;\n\tgoto L_00B1;\n\tv541 = *([v537 @ X8_v16+B0]);\n\tv542 = 0;\n\tv543 = v541 + 8;\n\tv545 = *([v582 @ X11_v20-8]);\n\tv587 = v545 == v538;\n\tif (v587) goto L_00AA;\n\tv565 = v581 + 1;\n\tv592 = v565 < v539;\n\tv563 = ~v592;\n\tv567 = v582 + 0x10;\n\tv547 = ~v563;\n\tif (v547) goto L_FFFFFFFF;\n\tv568 = v24;\n\tv569 = 0;\n\tv570 = 0x8909C4(v568, v538, v569, v68, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tgoto L_00B1;\nL_00AA:\n\tv593 = *([v582 @ X11_v20]);\n\tv594 = v593 << 4;\n\tv595 = v537 + v594;\n\tv596 = v595 + 0x130;\nL_00B1:\n\tv236 = Obi.IObiConstraints::GetActor(constraints);\n\tv265 = this.source;\n\tv79 = v236.solverIndices;\n\tv74 = v73 | 1;\n\tv237 = Obi.ObiNativeIntList::get_Item(v265.particleIndices, v74);\n\tv601 = v237 < v79.Length;\n\tv179 = ~v601;\n\tif (v179) goto L_0196;\n\tv602 = *([v228 @ X23_v8 (Obi.ObiNativeIntList)]);\n\tv609 = Obi.ObiNativeIntList::set_Item(v228, v74, v79[v237 @ X0_v26 (System.Int32)]);\n\tgoto L_0106;\n\tv614 = *([v610 @ X8_v23+B0]);\n\tv615 = 0;\n\tv616 = v614 + 8;\n\tv618 = *([v655 @ X11_v15-8]);\n\tv660 = v618 == v611;\n\tif (v660) goto L_00FF;\n\tv638 = v654 + 1;\n\tv665 = v638 < v612;\n\tv636 = ~v665;\n\tv640 = v655 + 0x10;\n\tv620 = ~v636;\n\tif (v620) goto L_FFFFFFFF;\n\tv641 = v24;\n\tv642 = 0;\n\tv643 = 0x8909C4(v641, v611, v642, v69, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tgoto L_0106;\nL_00FF:\n\tv666 = *([v655 @ X11_v15]);\n\tv667 = v666 << 4;\n\tv668 = v610 + v667;\n\tv669 = v668 + 0x130;\nL_0106:\n\tv238 = Obi.IObiConstraints::GetActor(constraints);\n\tv268 = this.source;\n\tgoto L_FFFFFFFF;\n\tv330 = v330_asT == 0;\n\tif (v330) goto L_0195;\n\tgoto L_FFFFFFFF;\n\tv102 = v102_asT == 0;\n\tif (v102) goto L_0195;\n\tv269 = *([v268 @ X8_v26 (Obi.ObiConstraintsBatch)+48]);\n\tv211 = *([v269 @ X8_v27]);\n\tv229 = v238.solverIndices;\n\t*([v211 @ X9_v28+180])(v239, v269, v273, *([v211 @ X9_v28+188]), *([v602 @ X8_v22 (Il2CppClass<Obi.ObiNativeIntList>)+198]), v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv682 = v239 < v229.Length;\n\tv182 = ~v682;\n\tif (v182) goto L_0196;\n\tv240 = Obi.ObiNativeIntList::set_Item(this.orientationIndices, v273, v229[v239 @ X0_v33]);\n\tv261 = this.restLengths;\n\tv273 = v273 + 1;\n\tv686 = this.restLengths == 0;\n\tv255 = ~v686;\n\tif (v255) goto L_002C;\n\tgoto L_0193;\nL_016F:\n\tv193 = this.particleIndices;\n\tv201 = this.orientationIndices;\n\tv213 = this.restOrientations;\n\tv64 = this.stiffnesses;\n\tOni::SetStretchShearConstraints(this.batch, v193.m_AlignedPtr, v201.m_AlignedPtr, v261.m_AlignedPtr, v213.m_AlignedPtr, v64.m_AlignedPtr, this.m_ConstraintCount);\n\tOni::SetActiveConstraints(this.batch, this.m_ActiveConstraintCount);\n\treturn;\nL_0193:\n\tthrow System.NullReferenceException;\nL_0195:\n\tv381 = new System.InvalidCastException();\nL_0196:\n\tv412 = new System.IndexOutOfRangeException();\n\tthrow v412;\n\treturn;\n// 285 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void OnAddToSolver(IObiConstraints constraints)
		{
			//IL_0127: Expected I, but got O
			//IL_01c7: Expected O, but got I
			ObiNativeFloatList obiNativeFloatList = restLengths;
			int num = 0;
			object obj3 = default(object);
			while (true)
			{
				if (num >= obiNativeFloatList.count)
				{
					ObiNativeIntList obiNativeIntList = particleIndices;
					ObiNativeIntList obiNativeIntList2 = orientationIndices;
					ObiNativeQuaternionList obiNativeQuaternionList = restOrientations;
					ObiNativeVector3List obiNativeVector3List = stiffnesses;
					Oni.SetStretchShearConstraints(oniBatch, obiNativeIntList.m_AlignedPtr, obiNativeIntList2.m_AlignedPtr, obiNativeFloatList.m_AlignedPtr, obiNativeQuaternionList.m_AlignedPtr, obiNativeVector3List.m_AlignedPtr, constraintCount);
					Oni.SetActiveConstraints(oniBatch, activeConstraintCount);
					return;
				}
				ObiActor actor = constraints.GetActor();
				ObiConstraintsBatch obiConstraintsBatch = source;
				int[] solverIndices = actor.solverIndices;
				int num2 = num << 1;
				int num3 = obiConstraintsBatch.particleIndices.get_Item(num2);
				if (num3 < solverIndices.Length)
				{
					particleIndices.set_Item(num2, solverIndices[num3]);
					ObiNativeIntList obiNativeIntList3 = particleIndices;
					ObiActor actor2 = constraints.GetActor();
					ObiConstraintsBatch obiConstraintsBatch2 = source;
					int[] solverIndices2 = actor2.solverIndices;
					int index = num2 | 1;
					int num4 = obiConstraintsBatch2.particleIndices.get_Item(index);
					if (num4 < solverIndices2.Length)
					{
						IntPtr intPtr = (IntPtr)obiNativeIntList3;
						obiNativeIntList3.set_Item(index, solverIndices2[num4]);
						ObiActor actor3 = constraints.GetActor();
						ObiConstraintsBatch obiConstraintsBatch3 = source;
						ObiStretchShearConstraintsBatch obiStretchShearConstraintsBatch = source as ObiStretchShearConstraintsBatch;
						if (obiStretchShearConstraintsBatch != null)
						{
							ObiStretchShearConstraintsBatch obiStretchShearConstraintsBatch2 = source as ObiStretchShearConstraintsBatch;
							if (obiStretchShearConstraintsBatch2 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ X8_v26 (Obi.ObiConstraintsBatch)+48]");
								object obj = 0;
								object obj2 = obj;
								int[] solverIndices3 = actor3.solverIndices;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v211 @ X9_v28+180] (should have been resolved before IL gen)");
								if ((long)(IntPtr)obj3 < (long)solverIndices3.Length)
								{
									orientationIndices.set_Item(num, solverIndices3[obj3]);
									obiNativeFloatList = restLengths;
									num++;
									if (restLengths == null)
									{
										break;
									}
									continue;
								}
								goto IL_031b;
							}
						}
						InvalidCastException ex = new InvalidCastException();
					}
				}
				goto IL_031b;
				IL_031b:
				IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
				throw ex2;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x6000186")]
		[Address(RVA = "0x10301A4", Offset = "0x10301A4", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv32 = *([1EEB270]);\n\tv33 = *([v32 @ X8_v9]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, stretchCompliance, shear1Compliance, shear2Compliance, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([202626F]) = v49;\nL_001A:\n\tv120 = this.stiffnesses;\nL_0028:\n\tv54 = v132 >= v120.m_Count;\n\tif (v54) goto L_004B;\n\tv88 = 0;\n\tv170 = 0x1586898(&v88 @ stack_-50_v4, 0, v121, v37, v38, v39, v40, v41, stretchCompliance, shear1Compliance, shear2Compliance, v42, v43, v44, v45, v46);\n\tv106 = *([v120 @ X21_v5 (Obi.ObiNativeVector3List)]);\n\tv121 = *([v106 @ X8_v7 (Il2CppClass<Obi.ObiNativeVector3List>)+198]);\n\tv102 = Obi.ObiNativeVector3List::set_Item(v120, v132, Vector3_arg);\n\tv120 = this.stiffnesses;\n\tv132 = v132 + 1;\n\tv173 = this.stiffnesses == 0;\n\tv104 = ~v173;\n\tif (v104) goto L_0028;\n\tthrow System.NullReferenceException;\nL_004B:\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetParameters(float stretchCompliance, float shear1Compliance, float shear2Compliance)
		{
			//IL_001c: Expected O, but got I4
			//IL_0033: Expected I, but got O
			//IL_0043: Expected O, but got I
			//IL_005e: Expected F4, but got O
			ObiNativeVector3List obiNativeVector3List = stiffnesses;
			int num = 0;
			Vector3 value = default(Vector3);
			object obj3 = default(object);
			while (num < obiNativeVector3List.count)
			{
				object obj = 0;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
				IntPtr intPtr = (IntPtr)obiNativeVector3List;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ X8_v7 (Il2CppClass<Obi.ObiNativeVector3List>)+198]");
				object obj2 = 0;
				value.x = 0f;
				value.y = (float)obj3;
				value.z = 0f;
				obiNativeVector3List.set_Item(num, value);
				obiNativeVector3List = stiffnesses;
				num++;
				if (stiffnesses == null)
				{
					throw new NullReferenceException();
				}
			}
		}
	}
}
