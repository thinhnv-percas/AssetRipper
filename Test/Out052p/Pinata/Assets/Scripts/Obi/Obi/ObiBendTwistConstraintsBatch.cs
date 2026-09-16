using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Serializable]
	[Token(Token = "0x2000009")]
	public class ObiBendTwistConstraintsBatch : ObiConstraintsBatch
	{
		[HideInInspector]
		[Token(Token = "0x4000016")]
		[FieldOffset(Offset = "0x48")]
		public ObiNativeQuaternionList restDarbouxVectors;

		[HideInInspector]
		[Token(Token = "0x4000017")]
		[FieldOffset(Offset = "0x50")]
		public ObiNativeVector3List stiffnesses;

		[Token(Token = "0x17000011")]
		public override Oni.ConstraintType constraintType
		{
			[Token(Token = "0x6000115")]
			[Address(RVA = "0xE3E6F0", Offset = "0xE3E6F0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 6;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Oni.ConstraintType.BendTwist;
			}
		}

		[Token(Token = "0x6000116")]
		[Address(RVA = "0xE3E6F8", Offset = "0xE3E6F8", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EB2F30]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, source, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20246FD]) = v41;\nL_0018:\n\tv45 = new Obi.ObiNativeQuaternionList();\n\tObi.ObiNativeQuaternionList::.ctor(v45, 8, 0x10);\n\tthis.restDarbouxVectors = v45;\n\tv52 = new Obi.ObiNativeVector3List();\n\tObi.ObiNativeVector3List::.ctor(v52, 8, 0x10);\n\tthis.stiffnesses = v52;\n\tObi.ObiConstraintsBatch::.ctor(this, source);\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiBendTwistConstraintsBatch(ObiBendTwistConstraintsBatch source = null)
		{
			ObiNativeQuaternionList obiNativeQuaternionList = new ObiNativeQuaternionList();
			restDarbouxVectors = obiNativeQuaternionList;
			ObiNativeVector3List obiNativeVector3List = new ObiNativeVector3List();
			stiffnesses = obiNativeVector3List;
			base._002Ector(source);
		}

		[Token(Token = "0x6000117")]
		[Address(RVA = "0xE3E858", Offset = "0xE3E858", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EF9A68]);\n\tv19 = *([v18 @ X8_v24]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20246FE]) = v38;\nL_0016:\n\tv42 = new Obi.ObiBendTwistConstraintsBatch();\n\tObi.ObiBendTwistConstraintsBatch::.ctor(v42, this);\n\tv46 = this.particleIndices;\n\tObi.ObiNativeList`1<System.Int32>::ResizeUninitialized(v42.particleIndices, v46.m_Count);\n\tv61 = this.restDarbouxVectors;\n\tObi.ObiNativeList`1<UnityEngine.Quaternion>::ResizeUninitialized(v42.restDarbouxVectors, v61.m_Count);\n\tv62 = this.stiffnesses;\n\tObi.ObiNativeList`1<UnityEngine.Vector3>::ResizeUninitialized(v42.stiffnesses, v62.m_Count);\n\tObi.ObiNativeList`1<System.Int32>::CopyFrom(v42.particleIndices, this.particleIndices);\n\tObi.ObiNativeList`1<UnityEngine.Quaternion>::CopyFrom(v42.restDarbouxVectors, this.restDarbouxVectors);\n\tObi.ObiNativeList`1<UnityEngine.Vector3>::CopyFrom(v42.stiffnesses, this.stiffnesses);\n\treturn v42;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 75 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override IObiConstraintsBatch Clone()
		{
			ObiBendTwistConstraintsBatch obiBendTwistConstraintsBatch = new ObiBendTwistConstraintsBatch(this);
			ObiNativeIntList obiNativeIntList = particleIndices;
			obiBendTwistConstraintsBatch.particleIndices.ResizeUninitialized(obiNativeIntList.count);
			ObiNativeQuaternionList obiNativeQuaternionList = restDarbouxVectors;
			obiBendTwistConstraintsBatch.restDarbouxVectors.ResizeUninitialized(obiNativeQuaternionList.count);
			ObiNativeVector3List obiNativeVector3List = stiffnesses;
			obiBendTwistConstraintsBatch.stiffnesses.ResizeUninitialized(obiNativeVector3List.count);
			obiBendTwistConstraintsBatch.particleIndices.CopyFrom(particleIndices);
			obiBendTwistConstraintsBatch.restDarbouxVectors.CopyFrom(restDarbouxVectors);
			obiBendTwistConstraintsBatch.stiffnesses.CopyFrom(stiffnesses);
			return obiBendTwistConstraintsBatch;
		}

		[Token(Token = "0x6000118")]
		[Address(RVA = "0xE3E984", Offset = "0xE3E984", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = &v23 @ stack_-10_v2;\n\t*([v22 @ X29_v1-18]) = indices;\n\tgoto L_0021;\n\tv37 = *([1F01300]);\n\tv38 = *([v37 @ X8_v16]);\n\tv39 = \"il2cpp_codegen_initialize_method\"(v38, indices, methodInfo, v41, v42, v43, v44, v45, restDarboux, v0, v2, v3, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([20246FF]) = v52;\nL_0021:\n\tObi.ObiConstraintsBatch::RegisterConstraint(this);\n\tv58 = new System.TypeLoadException();\n\tObi.ObiNativeList`1<System.Int32>::Add(this.particleIndices, v58);\n\tv78 = new System.TypeLoadException();\n\tObi.ObiNativeList`1<System.Int32>::Add(this.particleIndices, v78);\n\tObi.ObiNativeList`1<UnityEngine.Quaternion>::Add(this.restDarbouxVectors, restDarboux);\n\tgoto L_0054;\n\tv160 = *([v156 @ X0_v14+E0]);\n\tv161 = v160 == 0;\n\tv162 = ~v161;\n\tif (v162) goto L_0054;\n\tv164 = \"il2cpp_codegen_runtime_class_init\"(v156, v76, v73, v41, v42, v43, v44, v45, v151, v152, v153, v90, v46, v47, v48, v49);\nL_0054:\n\tv69 = UnityEngine.Vector3::get_zero();\n\tObi.ObiNativeList`1<UnityEngine.Vector3>::Add(this.stiffnesses, v69);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddConstraint(Vector2Int indices, Quaternion restDarboux)
		{
			//IL_0021: Expected I4, but got O
			//IL_003e: Expected I4, but got O
			object obj2 = default(object);
			object obj = obj2;
			RegisterConstraint();
			TypeLoadException ex = new TypeLoadException();
			particleIndices.Add((int)ex);
			TypeLoadException ex2 = new TypeLoadException();
			particleIndices.Add((int)ex2);
			restDarbouxVectors.Add(restDarboux);
			Vector3 zero = Vector3.zero;
			stiffnesses.Add(zero);
		}

		[Token(Token = "0x6000119")]
		[Address(RVA = "0xE3EAC4", Offset = "0xE3EAC4", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EC51B0]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024700]) = v38;\nL_0014:\n\tObi.ObiConstraintsBatch::Clear(this);\n\tObi.ObiNativeList`1<System.Int32>::Clear(this.particleIndices);\n\tObi.ObiNativeList`1<UnityEngine.Quaternion>::Clear(this.restDarbouxVectors);\n\tObi.ObiNativeList`1<UnityEngine.Vector3>::Clear(this.stiffnesses);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Clear()
		{
			base.Clear();
			particleIndices.Clear();
			restDarbouxVectors.Clear();
			stiffnesses.Clear();
		}

		[Token(Token = "0x600011A")]
		[Address(RVA = "0xE3EB54", Offset = "0xE3EB54", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1ED6890]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, index, particles, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2024701]) = v44;\nL_001B:\n\tv48 = index << 1;\n\tv52 = Obi.ObiNativeIntList::get_Item(this.particleIndices, v48);\n\tSystem.Collections.Generic.List`1<System.Int32>::Add(particles, v52);\n\tv82 = v48 | 1;\n\tv85 = Obi.ObiNativeIntList::get_Item(this.particleIndices, v82);\n\tSystem.Collections.Generic.List`1<System.Int32>::Add(particles, v85);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void GetParticlesInvolved(int index, List<int> particles)
		{
			int num = index << 1;
			int item = particleIndices.get_Item(num);
			particles.Add(item);
			int index2 = num | 1;
			int item2 = particleIndices.get_Item(index2);
			particles.Add(item2);
		}

		[Token(Token = "0x600011B")]
		[Address(RVA = "0xE3EC0C", Offset = "0xE3EC0C", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv30 = *([1EF9AA8]);\n\tv31 = *([v30 @ X8_v10]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, sourceIndex, destIndex, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2024702]) = v48;\nL_001E:\n\tv53 = sourceIndex << 1;\n\tv54 = sourceIndex + v53;\n\tv55 = destIndex << 1;\n\tv56 = destIndex + v55;\n\tObi.ObiNativeList`1<System.Int32>::Swap(this.particleIndices, v54, v56);\n\tv69 = v54 + 1;\n\tv61 = v56 + 1;\n\tObi.ObiNativeList`1<System.Int32>::Swap(this.particleIndices, v69, v61);\n\tv70 = v54 + 2;\n\tv62 = v56 + 2;\n\tObi.ObiNativeList`1<System.Int32>::Swap(this.particleIndices, v70, v62);\n\tObi.ObiNativeList`1<UnityEngine.Quaternion>::Swap(this.restDarbouxVectors, sourceIndex, destIndex);\n\tObi.ObiNativeList`1<UnityEngine.Vector3>::Swap(this.stiffnesses, sourceIndex, destIndex);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void SwapConstraints(int sourceIndex, int destIndex)
		{
			int num = sourceIndex << 1;
			int num2 = sourceIndex + num;
			int num3 = destIndex << 1;
			int num4 = destIndex + num3;
			particleIndices.Swap(num2, num4);
			int index = num2 + 1;
			int index2 = num4 + 1;
			particleIndices.Swap(index, index2);
			int index3 = num2 + 2;
			int index4 = num4 + 2;
			particleIndices.Swap(index3, index4);
			restDarbouxVectors.Swap(sourceIndex, destIndex);
			stiffnesses.Swap(sourceIndex, destIndex);
		}

		[Token(Token = "0x600011C")]
		[Address(RVA = "0xE3ECFC", Offset = "0xE3ECFC", Length = "0x268")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1EC68A8]);\n\tv31 = *([v30 @ X8_v27]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, constraints, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([2024703]) = v49;\nL_0019:\n\tv200 = this.restDarbouxVectors;\nL_0029:\n\tv82 = v176 >= v200.m_Count;\n\tif (v82) goto L_00DD;\n\tgoto L_0059;\n\tv288 = *([v281 @ X8_v8+B0]);\n\tv289 = 0;\n\tv290 = v288 + 8;\n\tv292 = *([v335 @ X11_v15-8]);\n\tv340 = v292 == v282;\n\tif (v340) goto L_0052;\n\tv312 = v334 + 1;\n\tv388 = v312 < v283;\n\tv310 = ~v388;\n\tv314 = v335 + 0x10;\n\tv294 = ~v310;\n\tif (v294) goto L_FFFFFFFF;\n\tv315 = v22;\n\tv316 = 0;\n\tv317 = 0x8909C4(v315, v282, v316, v61, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_0059;\nL_0052:\n\tv389 = *([v335 @ X11_v15]);\n\tv390 = v389 << 4;\n\tv391 = v281 + v390;\n\tv392 = v391 + 0x130;\nL_0059:\n\tv181 = Obi.IObiConstraints::GetActor(constraints);\n\tv201 = this.source;\n\tv66 = v181.solverIndices;\n\tv210 = v176 << 1;\n\tv182 = Obi.ObiNativeIntList::get_Item(v201.particleIndices, v210);\n\tv397 = v182 < v66.Length;\n\tv138 = ~v397;\n\tif (v138) goto L_00FB;\n\tv405 = Obi.ObiNativeIntList::set_Item(this.particleIndices, v210, v66[v182 @ X0_v16 (System.Int32)]);\n\tgoto L_00AE;\n\tv410 = *([v406 @ X8_v15+B0]);\n\tv411 = 0;\n\tv412 = v410 + 8;\n\tv414 = *([v451 @ X11_v10-8]);\n\tv456 = v414 == v407;\n\tif (v456) goto L_00A7;\n\tv434 = v450 + 1;\n\tv461 = v434 < v408;\n\tv432 = ~v461;\n\tv436 = v451 + 0x10;\n\tv416 = ~v432;\n\tif (v416) goto L_FFFFFFFF;\n\tv437 = v22;\n\tv438 = 0;\n\tv439 = 0x8909C4(v437, v407, v438, v62, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_00AE;\nL_00A7:\n\tv462 = *([v451 @ X11_v10]);\n\tv463 = v462 << 4;\n\tv464 = v406 + v463;\n\tv465 = v464 + 0x130;\nL_00AE:\n\tv183 = Obi.IObiConstraints::GetActor(constraints);\n\tv204 = this.source;\n\tv67 = v183.solverIndices;\n\tv211 = v210 | 1;\n\tv184 = Obi.ObiNativeIntList::get_Item(v204.particleIndices, v211);\n\tv470 = v184 < v67.Length;\n\tv140 = ~v470;\n\tif (v140) goto L_00FB;\n\tv185 = Obi.ObiNativeIntList::set_Item(this.particleIndices, v211, v67[v184 @ X0_v23 (System.Int32)]);\n\tv200 = this.restDarbouxVectors;\n\tv176 = v176 + 1;\n\tv474 = this.restDarbouxVectors == 0;\n\tv196 = ~v474;\n\tif (v196) goto L_0029;\n\tgoto L_00FA;\nL_00DD:\n\tv162 = this.particleIndices;\n\tv148 = this.stiffnesses;\n\tOni::SetBendTwistConstraints(this.batch, v162.m_AlignedPtr, v200.m_AlignedPtr, v148.m_AlignedPtr, this.m_ConstraintCount);\n\tOni::SetActiveConstraints(this.batch, this.m_ActiveConstraintCount);\n\treturn;\nL_00FA:\n\tv254 = new System.NullReferenceException();\nL_00FB:\n\tv280 = new System.IndexOutOfRangeException();\n\tthrow v280;\n\treturn;\n// 172 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void OnAddToSolver(IObiConstraints constraints)
		{
			ObiNativeQuaternionList obiNativeQuaternionList = restDarbouxVectors;
			int num = 0;
			while (true)
			{
				if (num >= obiNativeQuaternionList.count)
				{
					ObiNativeIntList obiNativeIntList = particleIndices;
					ObiNativeVector3List obiNativeVector3List = stiffnesses;
					Oni.SetBendTwistConstraints(oniBatch, obiNativeIntList.m_AlignedPtr, obiNativeQuaternionList.m_AlignedPtr, obiNativeVector3List.m_AlignedPtr, constraintCount);
					Oni.SetActiveConstraints(oniBatch, activeConstraintCount);
					return;
				}
				ObiActor actor = constraints.GetActor();
				ObiConstraintsBatch obiConstraintsBatch = source;
				int[] solverIndices = actor.solverIndices;
				int num2 = num << 1;
				int num3 = obiConstraintsBatch.particleIndices.get_Item(num2);
				if (num3 >= solverIndices.Length)
				{
					break;
				}
				particleIndices.set_Item(num2, solverIndices[num3]);
				ObiActor actor2 = constraints.GetActor();
				ObiConstraintsBatch obiConstraintsBatch2 = source;
				int[] solverIndices2 = actor2.solverIndices;
				int index = num2 | 1;
				int num4 = obiConstraintsBatch2.particleIndices.get_Item(index);
				if (num4 >= solverIndices2.Length)
				{
					break;
				}
				particleIndices.set_Item(index, solverIndices2[num4]);
				obiNativeQuaternionList = restDarbouxVectors;
				num++;
				if (restDarbouxVectors == null)
				{
					NullReferenceException ex = new NullReferenceException();
					break;
				}
			}
			IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
			throw ex2;
		}

		[Token(Token = "0x600011D")]
		[Address(RVA = "0xE335A0", Offset = "0xE335A0", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv32 = *([1EE06A0]);\n\tv33 = *([v32 @ X8_v9]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, torsionCompliance, bend1Compliance, bend2Compliance, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([2024704]) = v49;\nL_001A:\n\tv120 = this.stiffnesses;\nL_0028:\n\tv54 = v132 >= v120.m_Count;\n\tif (v54) goto L_004B;\n\tv88 = 0;\n\tv170 = 0x1586898(&v88 @ stack_-50_v4, 0, v121, v37, v38, v39, v40, v41, torsionCompliance, bend1Compliance, bend2Compliance, v42, v43, v44, v45, v46);\n\tv106 = *([v120 @ X21_v5 (Obi.ObiNativeVector3List)]);\n\tv121 = *([v106 @ X8_v7 (Il2CppClass<Obi.ObiNativeVector3List>)+198]);\n\tv102 = Obi.ObiNativeVector3List::set_Item(v120, v132, Vector3_arg);\n\tv120 = this.stiffnesses;\n\tv132 = v132 + 1;\n\tv173 = this.stiffnesses == 0;\n\tv104 = ~v173;\n\tif (v104) goto L_0028;\n\tthrow System.NullReferenceException;\nL_004B:\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetParameters(float torsionCompliance, float bend1Compliance, float bend2Compliance)
		{
			//IL_001c: Expected O, but got I4
			//IL_002e: Expected I, but got O
			//IL_003e: Expected O, but got I
			//IL_0059: Expected F4, but got O
			ObiNativeVector3List obiNativeVector3List = stiffnesses;
			int num = 0;
			Vector3 value = default(Vector3);
			object obj3 = default(object);
			while (num < obiNativeVector3List.count)
			{
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
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
