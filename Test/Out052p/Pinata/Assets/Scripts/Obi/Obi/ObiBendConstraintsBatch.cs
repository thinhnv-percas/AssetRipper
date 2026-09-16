using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Serializable]
	[Token(Token = "0x2000008")]
	public class ObiBendConstraintsBatch : ObiConstraintsBatch
	{
		[HideInInspector]
		[Token(Token = "0x4000014")]
		[FieldOffset(Offset = "0x48")]
		public ObiNativeFloatList restBends;

		[HideInInspector]
		[Token(Token = "0x4000015")]
		[FieldOffset(Offset = "0x50")]
		public ObiNativeVector2List bendingStiffnesses;

		[Token(Token = "0x17000010")]
		public override Oni.ConstraintType constraintType
		{
			[Token(Token = "0x600010C")]
			[Address(RVA = "0xE3DD80", Offset = "0xE3DD80", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 3;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Oni.ConstraintType.Bending;
			}
		}

		[Token(Token = "0x600010D")]
		[Address(RVA = "0xE3DD88", Offset = "0xE3DD88", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EE5438]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, source, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20246F5]) = v41;\nL_0018:\n\tv45 = new Obi.ObiNativeFloatList();\n\tObi.ObiNativeFloatList::.ctor(v45, 8, 0x10);\n\tthis.restBends = v45;\n\tv52 = new Obi.ObiNativeVector2List();\n\tObi.ObiNativeVector2List::.ctor(v52, 8, 0x10);\n\tthis.bendingStiffnesses = v52;\n\tObi.ObiConstraintsBatch::.ctor(this, source);\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiBendConstraintsBatch(ObiBendConstraintsBatch source = null)
		{
			ObiNativeFloatList obiNativeFloatList = new ObiNativeFloatList();
			restBends = obiNativeFloatList;
			ObiNativeVector2List obiNativeVector2List = new ObiNativeVector2List();
			bendingStiffnesses = obiNativeVector2List;
			base._002Ector(source);
		}

		[Token(Token = "0x600010E")]
		[Address(RVA = "0xE3DEE4", Offset = "0xE3DEE4", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EAD4D0]);\n\tv19 = *([v18 @ X8_v24]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20246F6]) = v38;\nL_0016:\n\tv42 = new Obi.ObiBendConstraintsBatch();\n\tObi.ObiBendConstraintsBatch::.ctor(v42, this);\n\tv46 = this.particleIndices;\n\tObi.ObiNativeList`1<System.Int32>::ResizeUninitialized(v42.particleIndices, v46.m_Count);\n\tv61 = this.restBends;\n\tObi.ObiNativeList`1<System.Single>::ResizeUninitialized(v42.restBends, v61.m_Count);\n\tv62 = this.bendingStiffnesses;\n\tObi.ObiNativeList`1<UnityEngine.Vector2>::ResizeUninitialized(v42.bendingStiffnesses, v62.m_Count);\n\tObi.ObiNativeList`1<System.Int32>::CopyFrom(v42.particleIndices, this.particleIndices);\n\tObi.ObiNativeList`1<System.Single>::CopyFrom(v42.restBends, this.restBends);\n\tObi.ObiNativeList`1<UnityEngine.Vector2>::CopyFrom(v42.bendingStiffnesses, this.bendingStiffnesses);\n\treturn v42;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 75 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override IObiConstraintsBatch Clone()
		{
			ObiBendConstraintsBatch obiBendConstraintsBatch = new ObiBendConstraintsBatch(this);
			ObiNativeIntList obiNativeIntList = particleIndices;
			obiBendConstraintsBatch.particleIndices.ResizeUninitialized(obiNativeIntList.count);
			ObiNativeFloatList obiNativeFloatList = restBends;
			obiBendConstraintsBatch.restBends.ResizeUninitialized(obiNativeFloatList.count);
			ObiNativeVector2List obiNativeVector2List = bendingStiffnesses;
			obiBendConstraintsBatch.bendingStiffnesses.ResizeUninitialized(obiNativeVector2List.count);
			obiBendConstraintsBatch.particleIndices.CopyFrom(particleIndices);
			obiBendConstraintsBatch.restBends.CopyFrom(restBends);
			obiBendConstraintsBatch.bendingStiffnesses.CopyFrom(bendingStiffnesses);
			return obiBendConstraintsBatch;
		}

		[Token(Token = "0x600010F")]
		[Address(RVA = "0xE3E010", Offset = "0xE3E010", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv28 = *([1F0AE50]);\n\tv29 = *([v28 @ X8_v16]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, indices, methodInfo, v31, v32, v33, v34, v35, restBend, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([20246F7]) = v45;\nL_0019:\n\tObi.ObiConstraintsBatch::RegisterConstraint(this);\n\tv51 = 0x158B508(&indices @ X1 (UnityEngine.Vector3Int), 0, 0, v31, v32, v33, v34, v35, restBend, v36, v37, v38, v39, v40, v41, v42);\n\tObi.ObiNativeList`1<System.Int32>::Add(this.particleIndices, v51);\n\tv72 = 0x158B508(&indices @ X1 (UnityEngine.Vector3Int), 1, 0, v31, v32, v33, v34, v35, restBend, v36, v37, v38, v39, v40, v41, v42);\n\tObi.ObiNativeList`1<System.Int32>::Add(this.particleIndices, v72);\n\tv73 = 0x158B508(&indices @ X1 (UnityEngine.Vector3Int), 2, 0, v31, v32, v33, v34, v35, restBend, v36, v37, v38, v39, v40, v41, v42);\n\tObi.ObiNativeList`1<System.Int32>::Add(this.particleIndices, v73);\n\tObi.ObiNativeList`1<System.Single>::Add(this.restBends, restBend);\n\tgoto L_0053;\n\tv141 = *([v137 @ X0_v17+E0]);\n\tv142 = v141 == 0;\n\tv143 = ~v142;\n\tif (v143) goto L_0053;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v137, v70, v66, v31, v32, v33, v34, v35, v134, v36, v37, v38, v39, v40, v41, v42);\nL_0053:\n\tv61 = UnityEngine.Vector2::get_zero();\n\tObi.ObiNativeList`1<UnityEngine.Vector2>::Add(this.bendingStiffnesses, v61);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddConstraint(Vector3Int indices, float restBend)
		{
			RegisterConstraint();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B508 (inside UnityEngine.Vector3::.cctor +0x10C)");
			int item = default(int);
			particleIndices.Add(item);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B508 (inside UnityEngine.Vector3::.cctor +0x10C)");
			int item2 = default(int);
			particleIndices.Add(item2);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B508 (inside UnityEngine.Vector3::.cctor +0x10C)");
			int item3 = default(int);
			particleIndices.Add(item3);
			restBends.Add(restBend);
			Vector2 zero = Vector2.zero;
			bendingStiffnesses.Add(zero);
		}

		[Token(Token = "0x6000110")]
		[Address(RVA = "0xE3E164", Offset = "0xE3E164", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EAC9E0]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20246F8]) = v38;\nL_0014:\n\tObi.ObiConstraintsBatch::Clear(this);\n\tObi.ObiNativeList`1<System.Int32>::Clear(this.particleIndices);\n\tObi.ObiNativeList`1<System.Single>::Clear(this.restBends);\n\tObi.ObiNativeList`1<UnityEngine.Vector2>::Clear(this.bendingStiffnesses);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Clear()
		{
			base.Clear();
			particleIndices.Clear();
			restBends.Clear();
			bendingStiffnesses.Clear();
		}

		[Token(Token = "0x6000111")]
		[Address(RVA = "0xE3E1F4", Offset = "0xE3E1F4", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1F0B630]);\n\tv27 = *([v26 @ X8_v10]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, index, particles, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20246F9]) = v44;\nL_001B:\n\tv48 = index << 1;\n\tv49 = index + v48;\n\tv53 = Obi.ObiNativeIntList::get_Item(this.particleIndices, v49);\n\tSystem.Collections.Generic.List`1<System.Int32>::Add(particles, v53);\n\tv91 = v49 + 1;\n\tv93 = Obi.ObiNativeIntList::get_Item(this.particleIndices, v91);\n\tSystem.Collections.Generic.List`1<System.Int32>::Add(particles, v93);\n\tv119 = v49 + 2;\n\tv121 = Obi.ObiNativeIntList::get_Item(this.particleIndices, v119);\n\tSystem.Collections.Generic.List`1<System.Int32>::Add(particles, v121);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void GetParticlesInvolved(int index, List<int> particles)
		{
			int num = index << 1;
			int num2 = index + num;
			int item = particleIndices.get_Item(num2);
			particles.Add(item);
			int index2 = num2 + 1;
			int item2 = particleIndices.get_Item(index2);
			particles.Add(item2);
			int index3 = num2 + 2;
			int item3 = particleIndices.get_Item(index3);
			particles.Add(item3);
		}

		[Token(Token = "0x6000112")]
		[Address(RVA = "0xE3E2D4", Offset = "0xE3E2D4", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv30 = *([1EF0B28]);\n\tv31 = *([v30 @ X8_v10]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, sourceIndex, destIndex, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([20246FA]) = v48;\nL_001E:\n\tv53 = sourceIndex << 1;\n\tv54 = sourceIndex + v53;\n\tv55 = destIndex << 1;\n\tv56 = destIndex + v55;\n\tObi.ObiNativeList`1<System.Int32>::Swap(this.particleIndices, v54, v56);\n\tv69 = v54 + 1;\n\tv61 = v56 + 1;\n\tObi.ObiNativeList`1<System.Int32>::Swap(this.particleIndices, v69, v61);\n\tv70 = v54 + 2;\n\tv62 = v56 + 2;\n\tObi.ObiNativeList`1<System.Int32>::Swap(this.particleIndices, v70, v62);\n\tObi.ObiNativeList`1<System.Single>::Swap(this.restBends, sourceIndex, destIndex);\n\tObi.ObiNativeList`1<UnityEngine.Vector2>::Swap(this.bendingStiffnesses, sourceIndex, destIndex);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			restBends.Swap(sourceIndex, destIndex);
			bendingStiffnesses.Swap(sourceIndex, destIndex);
		}

		[Token(Token = "0x6000113")]
		[Address(RVA = "0xE3E3C4", Offset = "0xE3E3C4", Length = "0x32C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv32 = *([1ECC6A0]);\n\tv33 = *([v32 @ X8_v35]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, constraints, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([20246FB]) = v51;\nL_001A:\n\tv243 = this.restBends;\nL_002A:\n\tv94 = v213 >= v243.m_Count;\n\tif (v94) goto L_0134;\n\tgoto L_005A;\n\tv338 = *([v331 @ X8_v8+B0]);\n\tv339 = 0;\n\tv340 = v338 + 8;\n\tv342 = *([v385 @ X11_v21-8]);\n\tv390 = v342 == v332;\n\tif (v390) goto L_0053;\n\tv362 = v384 + 1;\n\tv440 = v362 < v333;\n\tv360 = ~v440;\n\tv364 = v385 + 0x10;\n\tv344 = ~v360;\n\tif (v344) goto L_FFFFFFFF;\n\tv365 = v24;\n\tv366 = 0;\n\tv367 = 0x8909C4(v365, v332, v366, v67, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tgoto L_005A;\nL_0053:\n\tv441 = *([v385 @ X11_v21]);\n\tv442 = v441 << 4;\n\tv443 = v331 + v442;\n\tv444 = v443 + 0x130;\nL_005A:\n\tv218 = Obi.IObiConstraints::GetActor(constraints);\n\tv244 = this.source;\n\tv73 = v218.solverIndices;\n\tv79 = v213 << 1;\n\tv256 = v213 + v79;\n\tv219 = Obi.ObiNativeIntList::get_Item(v244.particleIndices, v256);\n\tv449 = v219 < v73.Length;\n\tv165 = ~v449;\n\tif (v165) goto L_0153;\n\tv457 = Obi.ObiNativeIntList::set_Item(this.particleIndices, v256, v73[v219 @ X0_v16 (System.Int32)]);\n\tgoto L_00B0;\n\tv462 = *([v458 @ X8_v15+B0]);\n\tv463 = 0;\n\tv464 = v462 + 8;\n\tv466 = *([v503 @ X11_v16-8]);\n\tv508 = v466 == v459;\n\tif (v508) goto L_00A9;\n\tv486 = v502 + 1;\n\tv513 = v486 < v460;\n\tv484 = ~v513;\n\tv488 = v503 + 0x10;\n\tv468 = ~v484;\n\tif (v468) goto L_FFFFFFFF;\n\tv489 = v24;\n\tv490 = 0;\n\tv491 = 0x8909C4(v489, v459, v490, v68, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tgoto L_00B0;\nL_00A9:\n\tv514 = *([v503 @ X11_v16]);\n\tv515 = v514 << 4;\n\tv516 = v458 + v515;\n\tv517 = v516 + 0x130;\nL_00B0:\n\tv220 = Obi.IObiConstraints::GetActor(constraints);\n\tv247 = this.source;\n\tv65 = v220.solverIndices;\n\tv74 = v256 + 1;\n\tv221 = Obi.ObiNativeIntList::get_Item(v247.particleIndices, v74);\n\tv522 = v221 < v65.Length;\n\tv167 = ~v522;\n\tif (v167) goto L_0153;\n\tv530 = Obi.ObiNativeIntList::set_Item(this.particleIndices, v74, v65[v221 @ X0_v23 (System.Int32)]);\n\tgoto L_0105;\n\tv535 = *([v531 @ X8_v22+B0]);\n\tv536 = 0;\n\tv537 = v535 + 8;\n\tv539 = *([v576 @ X11_v11-8]);\n\tv581 = v539 == v532;\n\tif (v581) goto L_00FE;\n\tv559 = v575 + 1;\n\tv586 = v559 < v533;\n\tv557 = ~v586;\n\tv561 = v576 + 0x10;\n\tv541 = ~v557;\n\tif (v541) goto L_FFFFFFFF;\n\tv562 = v24;\n\tv563 = 0;\n\tv564 = 0x8909C4(v562, v532, v563, v69, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tgoto L_0105;\nL_00FE:\n\tv587 = *([v576 @ X11_v11]);\n\tv588 = v587 << 4;\n\tv589 = v531 + v588;\n\tv590 = v589 + 0x130;\nL_0105:\n\tv222 = Obi.IObiConstraints::GetActor(constraints);\n\tv250 = this.source;\n\tv75 = v222.solverIndices;\n\tv257 = v256 + 2;\n\tv223 = Obi.ObiNativeIntList::get_Item(v250.particleIndices, v257);\n\tv595 = v223 < v75.Length;\n\tv169 = ~v595;\n\tif (v169) goto L_0153;\n\tv224 = Obi.ObiNativeIntList::set_Item(this.particleIndices, v257, v75[v223 @ X0_v30 (System.Int32)]);\n\tv243 = this.restBends;\n\tv213 = v213 + 1;\n\tv599 = this.restBends == 0;\n\tv239 = ~v599;\n\tif (v239) goto L_002A;\n\tgoto L_0152;\nL_0134:\n\tv196 = this.particleIndices;\n\tv179 = this.bendingStiffnesses;\n\tOni::SetBendingConstraints(this.batch, v196.m_AlignedPtr, v243.m_AlignedPtr, v179.m_AlignedPtr, this.m_ConstraintCount);\n\tOni::SetActiveConstraints(this.batch, this.m_ActiveConstraintCount);\n\treturn;\nL_0152:\n\tv303 = new System.NullReferenceException();\nL_0153:\n\tv330 = new System.IndexOutOfRangeException();\n\tthrow v330;\n\treturn;\n// 229 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void OnAddToSolver(IObiConstraints constraints)
		{
			ObiNativeFloatList obiNativeFloatList = restBends;
			int num = 0;
			while (true)
			{
				if (num >= obiNativeFloatList.count)
				{
					ObiNativeIntList obiNativeIntList = particleIndices;
					ObiNativeVector2List obiNativeVector2List = bendingStiffnesses;
					Oni.SetBendingConstraints(oniBatch, obiNativeIntList.m_AlignedPtr, obiNativeFloatList.m_AlignedPtr, obiNativeVector2List.m_AlignedPtr, constraintCount);
					Oni.SetActiveConstraints(oniBatch, activeConstraintCount);
					return;
				}
				ObiActor actor = constraints.GetActor();
				ObiConstraintsBatch obiConstraintsBatch = source;
				int[] solverIndices = actor.solverIndices;
				int num2 = num << 1;
				int num3 = num + num2;
				int num4 = obiConstraintsBatch.particleIndices.get_Item(num3);
				if (num4 >= solverIndices.Length)
				{
					break;
				}
				particleIndices.set_Item(num3, solverIndices[num4]);
				ObiActor actor2 = constraints.GetActor();
				ObiConstraintsBatch obiConstraintsBatch2 = source;
				int[] solverIndices2 = actor2.solverIndices;
				int index = num3 + 1;
				int num5 = obiConstraintsBatch2.particleIndices.get_Item(index);
				if (num5 >= solverIndices2.Length)
				{
					break;
				}
				particleIndices.set_Item(index, solverIndices2[num5]);
				ObiActor actor3 = constraints.GetActor();
				ObiConstraintsBatch obiConstraintsBatch3 = source;
				int[] solverIndices3 = actor3.solverIndices;
				int index2 = num3 + 2;
				int num6 = obiConstraintsBatch3.particleIndices.get_Item(index2);
				if (num6 >= solverIndices3.Length)
				{
					break;
				}
				particleIndices.set_Item(index2, solverIndices3[num6]);
				obiNativeFloatList = restBends;
				num++;
				if (restBends == null)
				{
					NullReferenceException ex = new NullReferenceException();
					break;
				}
			}
			IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
			throw ex2;
		}

		[Token(Token = "0x6000114")]
		[Address(RVA = "0xE330D0", Offset = "0xE330D0", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1EFF178]);\n\tv29 = *([v28 @ X8_v9]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, compliance, maxBending, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20246FC]) = v46;\nL_0018:\n\tv122 = this.bendingStiffnesses;\nL_0026:\n\tv51 = v118 >= v122.m_Count;\n\tif (v51) goto L_0045;\n\tv83 = 0;\n\tv156 = 0x1588A6C(&v83 @ stack_-28_v4, 0, v112, v33, v34, v35, v36, v37, maxBending, compliance, v38, v39, v40, v41, v42, v43);\n\tv98 = *([v122 @ X20_v6 (Obi.ObiNativeVector2List)]);\n\tv112 = *([v98 @ X8_v7 (Il2CppClass<Obi.ObiNativeVector2List>)+198]);\n\tv94 = Obi.ObiNativeVector2List::set_Item(v122, v118, Vector2_arg);\n\tv122 = this.bendingStiffnesses;\n\tv118 = v118 + 1;\n\tv159 = this.bendingStiffnesses == 0;\n\tv96 = ~v159;\n\tif (v96) goto L_0026;\n\tthrow System.NullReferenceException;\nL_0045:\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetParameters(float compliance, float maxBending)
		{
			//IL_001c: Expected O, but got I4
			//IL_002e: Expected I, but got O
			//IL_003e: Expected O, but got I
			//IL_0059: Expected F4, but got O
			ObiNativeVector2List obiNativeVector2List = bendingStiffnesses;
			int num = 0;
			Vector2 value = default(Vector2);
			object obj3 = default(object);
			while (num < obiNativeVector2List.count)
			{
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
				IntPtr intPtr = (IntPtr)obiNativeVector2List;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ X8_v7 (Il2CppClass<Obi.ObiNativeVector2List>)+198]");
				object obj2 = 0;
				value.x = 0f;
				value.y = (float)obj3;
				obiNativeVector2List.set_Item(num, value);
				obiNativeVector2List = bendingStiffnesses;
				num++;
				if (bendingStiffnesses == null)
				{
					throw new NullReferenceException();
				}
			}
		}
	}
}
