using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Serializable]
	[Token(Token = "0x200000E")]
	public class ObiPinConstraintsBatch : ObiConstraintsBatch
	{
		[HideInInspector]
		[Token(Token = "0x4000025")]
		[FieldOffset(Offset = "0x48")]
		public ObiNativeIntPtrList pinBodies;

		[HideInInspector]
		[Token(Token = "0x4000026")]
		[FieldOffset(Offset = "0x50")]
		public ObiNativeVector4List offsets;

		[HideInInspector]
		[Token(Token = "0x4000027")]
		[FieldOffset(Offset = "0x58")]
		public ObiNativeQuaternionList restDarbouxVectors;

		[HideInInspector]
		[Token(Token = "0x4000028")]
		[FieldOffset(Offset = "0x60")]
		public ObiNativeFloatList stiffnesses;

		[HideInInspector]
		[Token(Token = "0x4000029")]
		[FieldOffset(Offset = "0x68")]
		public ObiNativeFloatList breakThresholds;

		[Token(Token = "0x400002A")]
		[FieldOffset(Offset = "0x70")]
		public float[] constraintForces;

		[Token(Token = "0x1700001E")]
		public override Oni.ConstraintType constraintType
		{
			[Token(Token = "0x6000161")]
			[Address(RVA = "0xC309AC", Offset = "0xC309AC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 8;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Oni.ConstraintType.Pin;
			}
		}

		[Token(Token = "0x6000162")]
		[Address(RVA = "0xC290A8", Offset = "0xC290A8", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1EADE40]);\n\tv25 = *([v24 @ X8_v10]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, source, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202317D]) = v43;\nL_0019:\n\tv47 = new Obi.ObiNativeIntPtrList();\n\tObi.ObiNativeIntPtrList::.ctor(v47, 8, 0x10);\n\tthis.pinBodies = v47;\n\tv55 = new Obi.ObiNativeVector4List();\n\tObi.ObiNativeVector4List::.ctor(v55, 8, 0x10);\n\tthis.offsets = v55;\n\tv62 = new Obi.ObiNativeQuaternionList();\n\tObi.ObiNativeQuaternionList::.ctor(v62, 8, 0x10);\n\tthis.restDarbouxVectors = v62;\n\tv70 = new Obi.ObiNativeFloatList();\n\tObi.ObiNativeFloatList::.ctor(v70, 8, 0x10);\n\tthis.stiffnesses = v70;\n\tv76 = new Obi.ObiNativeFloatList();\n\tObi.ObiNativeFloatList::.ctor(v76, 8, 0x10);\n\tthis.breakThresholds = v76;\n\tObi.ObiConstraintsBatch::.ctor(this, source);\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiPinConstraintsBatch(ObiPinConstraintsBatch source = null)
		{
			ObiNativeIntPtrList obiNativeIntPtrList = new ObiNativeIntPtrList();
			pinBodies = obiNativeIntPtrList;
			ObiNativeVector4List obiNativeVector4List = new ObiNativeVector4List();
			offsets = obiNativeVector4List;
			restDarbouxVectors = new ObiNativeQuaternionList();
			stiffnesses = new ObiNativeFloatList();
			breakThresholds = new ObiNativeFloatList();
			base._002Ector(source);
		}

		[Token(Token = "0x6000163")]
		[Address(RVA = "0xC309B4", Offset = "0xC309B4", Length = "0x1E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EEB748]);\n\tv21 = *([v20 @ X8_v32]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202317E]) = v40;\nL_0017:\n\tv44 = new Obi.ObiPinConstraintsBatch();\n\tObi.ObiPinConstraintsBatch::.ctor(v44, this);\n\tv48 = this.offsets;\n\tObi.ObiNativeList`1<System.IntPtr>::ResizeUninitialized(v44.pinBodies, v48.m_Count);\n\tv77 = this.particleIndices;\n\tObi.ObiNativeList`1<System.Int32>::ResizeUninitialized(v44.particleIndices, v77.m_Count);\n\tv78 = this.offsets;\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::ResizeUninitialized(v44.offsets, v78.m_Count);\n\tv79 = this.restDarbouxVectors;\n\tObi.ObiNativeList`1<UnityEngine.Quaternion>::ResizeUninitialized(v44.restDarbouxVectors, v79.m_Count);\n\tv80 = this.stiffnesses;\n\tObi.ObiNativeList`1<System.Single>::ResizeUninitialized(v44.stiffnesses, v80.m_Count);\n\tv81 = this.breakThresholds;\n\tObi.ObiNativeList`1<System.Single>::ResizeUninitialized(v44.breakThresholds, v81.m_Count);\n\tv153 = this.pinBodies == 0;\n\tif (v153) goto L_006E;\n\tObi.ObiNativeList`1<System.IntPtr>::CopyFrom(v44.pinBodies, this.pinBodies);\nL_006E:\n\tObi.ObiNativeList`1<System.Int32>::CopyFrom(v44.particleIndices, this.particleIndices);\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::CopyFrom(v44.offsets, this.offsets);\n\tObi.ObiNativeList`1<UnityEngine.Quaternion>::CopyFrom(v44.restDarbouxVectors, this.restDarbouxVectors);\n\tObi.ObiNativeList`1<System.Single>::CopyFrom(v44.stiffnesses, this.stiffnesses);\n\tObi.ObiNativeList`1<System.Single>::CopyFrom(v44.breakThresholds, this.breakThresholds);\n\treturn v44;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 121 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override IObiConstraintsBatch Clone()
		{
			ObiPinConstraintsBatch obiPinConstraintsBatch = new ObiPinConstraintsBatch(this);
			ObiNativeVector4List obiNativeVector4List = offsets;
			obiPinConstraintsBatch.pinBodies.ResizeUninitialized(obiNativeVector4List.count);
			ObiNativeIntList obiNativeIntList = particleIndices;
			obiPinConstraintsBatch.particleIndices.ResizeUninitialized(obiNativeIntList.count);
			ObiNativeVector4List obiNativeVector4List2 = offsets;
			obiPinConstraintsBatch.offsets.ResizeUninitialized(obiNativeVector4List2.count);
			ObiNativeQuaternionList obiNativeQuaternionList = restDarbouxVectors;
			obiPinConstraintsBatch.restDarbouxVectors.ResizeUninitialized(obiNativeQuaternionList.count);
			ObiNativeFloatList obiNativeFloatList = stiffnesses;
			obiPinConstraintsBatch.stiffnesses.ResizeUninitialized(obiNativeFloatList.count);
			ObiNativeFloatList obiNativeFloatList2 = breakThresholds;
			obiPinConstraintsBatch.breakThresholds.ResizeUninitialized(obiNativeFloatList2.count);
			if (pinBodies != null)
			{
				obiPinConstraintsBatch.pinBodies.CopyFrom(pinBodies);
			}
			obiPinConstraintsBatch.particleIndices.CopyFrom(particleIndices);
			obiPinConstraintsBatch.offsets.CopyFrom(offsets);
			obiPinConstraintsBatch.restDarbouxVectors.CopyFrom(restDarbouxVectors);
			obiPinConstraintsBatch.stiffnesses.CopyFrom(stiffnesses);
			obiPinConstraintsBatch.breakThresholds.CopyFrom(breakThresholds);
			return obiPinConstraintsBatch;
		}

		[Token(Token = "0x6000164")]
		[Address(RVA = "0xC291BC", Offset = "0xC291BC", Length = "0x1E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv54 = *([1EDE4D0]);\n\tv55 = *([v54 @ X8_v26]);\n\tv56 = \"il2cpp_codegen_initialize_method\"(v55, index, body, methodInfo, v58, v59, v60, v61, offset, v0, v2, restDarboux, v3, v5, v6, v62);\n\tv65 = 0 | 1;\n\t*([202317F]) = v65;\nL_002C:\n\tObi.ObiConstraintsBatch::RegisterConstraint(this);\n\tObi.ObiNativeList`1<System.Int32>::Add(this.particleIndices, index);\n\tgoto L_0045;\n\tv156 = *([v125 @ X0_v9+E0]);\n\tv157 = v156 == 0;\n\tv158 = ~v157;\n\tif (v158) goto L_0045;\n\tv160 = \"il2cpp_codegen_runtime_class_init\"(v125, v72, v73, methodInfo, v58, v59, v60, v61, offset, v0, v2, restDarboux, v3, v5, v6, v62);\nL_0045:\n\tv140 = UnityEngine.Object::op_Inequality(body, 0);\n\tv165 = v140 == 0;\n\tif (v165) goto L_0056;\n\tv208 = Obi.ObiColliderBase::get_OniCollider(body);\nL_0056:\n\tObi.ObiNativeList`1<System.IntPtr>::Add(this.pinBodies, v138);\n\tgoto L_0069;\n\tv221 = *([v217 @ X0_v15+E0]);\n\tv222 = v221 == 0;\n\tv223 = ~v222;\n\tif (v223) goto L_0069;\n\tv225 = \"il2cpp_codegen_runtime_class_init\"(v217, v138, v92, methodInfo, v58, v59, v60, v61, offset, v0, v2, restDarboux, v3, v5, v6, v62);\nL_0069:\n\tv87 = UnityEngine.Vector4::op_Implicit(offset);\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::Add(this.offsets, v87);\n\tObi.ObiNativeList`1<UnityEngine.Quaternion>::Add(this.restDarbouxVectors, restDarboux);\n\tObi.ObiNativeList`1<System.Single>::Add(this.stiffnesses, 0f);\n\tObi.ObiNativeList`1<System.Single>::Add(this.stiffnesses, 0f);\n\tObi.ObiNativeList`1<System.Single>::Add(this.breakThresholds, Infinityf);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 134 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddConstraint(int index, ObiColliderBase body, Vector3 offset, Quaternion restDarboux)
		{
			RegisterConstraint();
			particleIndices.Add(index);
			bool flag = body != null;
			bool flag2 = !flag;
			IntPtr item = default(IntPtr);
			if (!flag2)
			{
				IntPtr oniCollider = body.OniCollider;
				item = oniCollider;
			}
			pinBodies.Add(item);
			Vector4 item2 = offset;
			offsets.Add(item2);
			restDarbouxVectors.Add(restDarboux);
			stiffnesses.Add(0f);
			stiffnesses.Add(0f);
			breakThresholds.Add(float.PositiveInfinity);
		}

		[Token(Token = "0x6000165")]
		[Address(RVA = "0xC30B9C", Offset = "0xC30B9C", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1ED76B0]);\n\tv19 = *([v18 @ X8_v16]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023180]) = v38;\nL_0015:\n\tObi.ObiConstraintsBatch::Clear(this);\n\tObi.ObiNativeList`1<System.Int32>::Clear(this.particleIndices);\n\tObi.ObiNativeList`1<System.IntPtr>::Clear(this.pinBodies);\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::Clear(this.offsets);\n\tObi.ObiNativeList`1<UnityEngine.Quaternion>::Clear(this.restDarbouxVectors);\n\tObi.ObiNativeList`1<System.Single>::Clear(this.stiffnesses);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Clear()
		{
			base.Clear();
			particleIndices.Clear();
			pinBodies.Clear();
			offsets.Clear();
			restDarbouxVectors.Clear();
			stiffnesses.Clear();
		}

		[Token(Token = "0x6000166")]
		[Address(RVA = "0xC30C60", Offset = "0xC30C60", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv26 = *([1EDF580]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, index, particles, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023181]) = v44;\nL_001E:\n\tv51 = Obi.ObiNativeIntList::get_Item(this.particleIndices, index);\n\tSystem.Collections.Generic.List`1<System.Int32>::Add(particles, v51);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void GetParticlesInvolved(int index, List<int> particles)
		{
			int item = particleIndices.get_Item(index);
			particles.Add(item);
		}

		[Token(Token = "0x6000167")]
		[Address(RVA = "0xC30CEC", Offset = "0xC30CEC", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv26 = *([1F05A88]);\n\tv27 = *([v26 @ X8_v14]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, sourceIndex, destIndex, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023182]) = v44;\nL_001F:\n\tObi.ObiNativeList`1<System.Int32>::Swap(this.particleIndices, sourceIndex, destIndex);\n\tObi.ObiNativeList`1<System.IntPtr>::Swap(this.pinBodies, sourceIndex, destIndex);\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::Swap(this.offsets, sourceIndex, destIndex);\n\tObi.ObiNativeList`1<UnityEngine.Quaternion>::Swap(this.restDarbouxVectors, sourceIndex, destIndex);\n\tv80 = sourceIndex << 1;\n\tv82 = destIndex << 1;\n\tObi.ObiNativeList`1<System.Single>::Swap(this.stiffnesses, v80, v82);\n\tv96 = v82 | 1;\n\tv98 = v80 | 1;\n\tObi.ObiNativeList`1<System.Single>::Swap(this.stiffnesses, v98, v96);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void SwapConstraints(int sourceIndex, int destIndex)
		{
			particleIndices.Swap(sourceIndex, destIndex);
			pinBodies.Swap(sourceIndex, destIndex);
			offsets.Swap(sourceIndex, destIndex);
			restDarbouxVectors.Swap(sourceIndex, destIndex);
			int num = sourceIndex << 1;
			int num2 = destIndex << 1;
			stiffnesses.Swap(num, num2);
			int index = num2 | 1;
			int index2 = num | 1;
			stiffnesses.Swap(index2, index);
		}

		[Token(Token = "0x6000168")]
		[Address(RVA = "0xC30DFC", Offset = "0xC30DFC", Length = "0x1EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv28 = *([1ED7E40]);\n\tv29 = *([v28 @ X8_v23]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, constraints, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2023183]) = v47;\nL_0019:\n\tv130 = this.particleIndices;\n\tv50 = this.source == 0;\n\tif (v50) goto L_009C;\nL_002B:\n\tv153 = v245 >= v130.m_Count;\n\tif (v153) goto L_009C;\n\tgoto L_005A;\n\tv283 = *([v279 @ X8_v11+B0]);\n\tv284 = 0;\n\tv285 = v283 + 8;\n\tv287 = *([v332 @ X11_v11-8]);\n\tv337 = v287 == v280;\n\tif (v337) goto L_0053;\n\tv307 = v331 + 1;\n\tv353 = v307 < v281;\n\tv305 = ~v353;\n\tv309 = v332 + 0x10;\n\tv289 = ~v305;\n\tif (v289) goto L_FFFFFFFF;\n\tv310 = v20;\n\tv311 = 0;\n\tv312 = 0x8909C4(v310, v280, v311, v134, v33, v34, v35, v36, v126, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_005A;\nL_0053:\n\tv354 = *([v332 @ X11_v11]);\n\tv355 = v354 << 4;\n\tv356 = v279 + v355;\n\tv357 = v356 + 0x130;\nL_005A:\n\tv224 = Obi.IObiConstraints::GetActor(constraints);\n\tv240 = this.source;\n\tv137 = v224.solverIndices;\n\tv225 = Obi.ObiNativeIntList::get_Item(v240.particleIndices, v245);\n\tv399 = v225 < v137.Length;\n\tv191 = ~v399;\n\tif (v191) goto L_00BF;\n\tv402 = Obi.ObiNativeIntList::set_Item(v130, v245, v137[v225 @ X0_v15 (System.Int32)]);\n\tv263 = v245 << 1;\n\tv404 = Obi.ObiNativeFloatList::set_Item(this.stiffnesses, v263, 0f);\n\tv214 = v263 | 1;\n\tv222 = Obi.ObiNativeFloatList::set_Item(this.stiffnesses, v214, 0f);\n\tv245 = v245 + 1;\n\tv405 = this.particleIndices == 0;\n\tv228 = ~v405;\n\tif (v228) goto L_002B;\n\tthrow System.NullReferenceException;\nL_009C:\n\tv242 = this.offsets;\n\tv212 = this.restDarbouxVectors;\n\tv200 = this.pinBodies;\n\tv205 = this.stiffnesses;\n\tOni::SetPinConstraints(this.batch, v130.m_AlignedPtr, v242.m_AlignedPtr, v212.m_AlignedPtr, v200.m_AlignedPtr, v205.m_AlignedPtr, this.m_ConstraintCount);\n\tOni::SetActiveConstraints(this.batch, this.m_ActiveConstraintCount);\n\treturn;\nL_00BF:\n\tv403 = new System.IndexOutOfRangeException();\n\tthrow v403;\n\treturn;\n// 137 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void OnAddToSolver(IObiConstraints constraints)
		{
			ObiNativeIntList obiNativeIntList = particleIndices;
			if (source != null)
			{
				int num = 0;
				while (num < obiNativeIntList.count)
				{
					ObiActor actor = constraints.GetActor();
					ObiConstraintsBatch obiConstraintsBatch = source;
					int[] solverIndices = actor.solverIndices;
					int num2 = obiConstraintsBatch.particleIndices.get_Item(num);
					if (num2 < solverIndices.Length)
					{
						obiNativeIntList.set_Item(num, solverIndices[num2]);
						int num3 = num << 1;
						stiffnesses.set_Item(num3, 0f);
						int index = num3 | 1;
						stiffnesses.set_Item(index, 0f);
						num++;
						bool flag = particleIndices == null;
						bool flag2 = !flag;
						obiNativeIntList = particleIndices;
						if (!flag2)
						{
							throw new NullReferenceException();
						}
						continue;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
			}
			ObiNativeVector4List obiNativeVector4List = offsets;
			ObiNativeQuaternionList obiNativeQuaternionList = restDarbouxVectors;
			ObiNativeIntPtrList obiNativeIntPtrList = pinBodies;
			ObiNativeFloatList obiNativeFloatList = stiffnesses;
			Oni.SetPinConstraints(oniBatch, obiNativeIntList.m_AlignedPtr, obiNativeVector4List.m_AlignedPtr, obiNativeQuaternionList.m_AlignedPtr, obiNativeIntPtrList.m_AlignedPtr, obiNativeFloatList.m_AlignedPtr, constraintCount);
			Oni.SetActiveConstraints(oniBatch, activeConstraintCount);
		}

		[Token(Token = "0x6000169")]
		[Address(RVA = "0xC293A0", Offset = "0xC293A0", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EBDEA0]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2023184]) = v42;\nL_0015:\n\tv83 = this.constraintForces;\n\tv81 = this.m_ConstraintCount;\n\tv45 = this.constraintForces == 0;\n\tif (v45) goto L_0027;\n\tv47 = this.m_ConstraintCount << 2;\n\tv52 = v47 == v83.Length;\n\tif (v52) goto L_0030;\nL_0027:\n\tv78 = v81 << 2;\n\t// 41 NewArr v80 @ X0_v21 (System.Single[]), typeof(System.Single[]), v78 @ X1_v11 (System.Int32)\n\tv81 = this.m_ConstraintCount;\n\tthis.constraintForces = v80;\nL_0030:\n\tv99 = Oni::GetBatchConstraintForces(this.batch, v83, v81, 0);\n\tv111 = this.m_ConstraintCount < 1;\n\tif (v111) goto L_007F;\nL_0040:\n\tv181 = this.constraintForces;\n\tv220 = v164 < v181.Length;\n\tv221 = ~v220;\n\tif (v221) goto L_0082;\n\tv247 = Obi.ObiNativeFloatList::get_Item(this.breakThresholds, v180);\n\tv115 = -v181[v164 @ X21_v4 (System.Int32)];\n\tv257 = v32 >= v115;\n\tif (v257) goto L_006A;\n\tv265 = Obi.ObiConstraintsBatch::DeactivateConstraint(this, v180);\nL_006A:\n\tv180 = v180 + 1;\n\tv164 = v164 + 4;\n\tv124 = v180 < this.m_ConstraintCount;\n\tif (v124) goto L_0040;\nL_007F:\n\treturn;\n\tv230 = new System.NullReferenceException();\nL_0082:\n\tv242 = new System.IndexOutOfRangeException();\n\tthrow v242;\n\tthrow System.NullReferenceException;\n// 98 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void BreakConstraints()
		{
			//IL_00d4: Expected O, but got F4
			float[] array = constraintForces;
			int num = constraintCount;
			if (constraintForces != null)
			{
				int num2 = constraintCount << 2;
				if (num2 == array.Length)
				{
					goto IL_0182;
				}
			}
			int num3 = num << 2;
			float[] array2 = new float[num3];
			num = constraintCount;
			constraintForces = array2;
			array = array2;
			goto IL_0182;
			IL_0182:
			int batchConstraintForces = Oni.GetBatchConstraintForces(oniBatch, array, num, 0);
			if (constraintCount < 1)
			{
				return;
			}
			int num4 = 3;
			int num5 = 0;
			object obj2 = default(object);
			while (true)
			{
				float[] array3 = constraintForces;
				if (num4 >= array3.Length)
				{
					break;
				}
				float num6 = breakThresholds.get_Item(num5);
				object obj = 0f - array3[num4];
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
				{
					bool flag = DeactivateConstraint(num5);
				}
				num5++;
				num4 += 4;
				if (num5 >= constraintCount)
				{
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}
	}
}
