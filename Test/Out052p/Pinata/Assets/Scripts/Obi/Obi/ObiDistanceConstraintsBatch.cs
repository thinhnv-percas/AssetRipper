using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Serializable]
	[Token(Token = "0x200000D")]
	public class ObiDistanceConstraintsBatch : ObiConstraintsBatch, IStructuralConstraintBatch
	{
		[HideInInspector]
		[Token(Token = "0x4000023")]
		[FieldOffset(Offset = "0x48")]
		public ObiNativeFloatList restLengths;

		[HideInInspector]
		[Token(Token = "0x4000024")]
		[FieldOffset(Offset = "0x50")]
		public ObiNativeVector2List stiffnesses;

		[Token(Token = "0x1700001D")]
		public override Oni.ConstraintType constraintType
		{
			[Token(Token = "0x6000154")]
			[Address(RVA = "0xE432EC", Offset = "0xE432EC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 4;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Oni.ConstraintType.Distance;
			}
		}

		[Token(Token = "0x6000155")]
		[Address(RVA = "0xE432F4", Offset = "0xE432F4", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EC2A30]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, source, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2024736]) = v41;\nL_0018:\n\tv45 = new Obi.ObiNativeFloatList();\n\tObi.ObiNativeFloatList::.ctor(v45, 8, 0x10);\n\tthis.restLengths = v45;\n\tv52 = new Obi.ObiNativeVector2List();\n\tObi.ObiNativeVector2List::.ctor(v52, 8, 0x10);\n\tthis.stiffnesses = v52;\n\tObi.ObiConstraintsBatch::.ctor(this, source);\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiDistanceConstraintsBatch(ObiDistanceConstraintsBatch source = null)
		{
			ObiNativeFloatList obiNativeFloatList = new ObiNativeFloatList();
			restLengths = obiNativeFloatList;
			ObiNativeVector2List obiNativeVector2List = new ObiNativeVector2List();
			stiffnesses = obiNativeVector2List;
			base._002Ector(source);
		}

		[Token(Token = "0x6000156")]
		[Address(RVA = "0xE43390", Offset = "0xE43390", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = *([1ECA378]);\n\tv27 = *([v26 @ X8_v16]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, indices, methodInfo, v30, v31, v32, v33, v34, restLength, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2024737]) = v44;\nL_0018:\n\tObi.ObiConstraintsBatch::RegisterConstraint(this);\n\tv50 = new System.TypeLoadException();\n\tObi.ObiNativeList`1<System.Int32>::Add(this.particleIndices, v50);\n\tv69 = new System.TypeLoadException();\n\tObi.ObiNativeList`1<System.Int32>::Add(this.particleIndices, v69);\n\tObi.ObiNativeList`1<System.Single>::Add(this.restLengths, restLength);\n\tgoto L_0047;\n\tv131 = *([v127 @ X0_v14+E0]);\n\tv132 = v131 == 0;\n\tv133 = ~v132;\n\tif (v133) goto L_0047;\n\tv135 = \"il2cpp_codegen_runtime_class_init\"(v127, v67, v64, v30, v31, v32, v33, v34, v124, v35, v36, v37, v38, v39, v40, v41);\nL_0047:\n\tv60 = UnityEngine.Vector2::get_zero();\n\tObi.ObiNativeList`1<UnityEngine.Vector2>::Add(this.stiffnesses, v60);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddConstraint(Vector2Int indices, float restLength)
		{
			//IL_0014: Expected I4, but got O
			//IL_0031: Expected I4, but got O
			RegisterConstraint();
			TypeLoadException ex = new TypeLoadException();
			particleIndices.Add((int)ex);
			TypeLoadException ex2 = new TypeLoadException();
			particleIndices.Add((int)ex2);
			restLengths.Add(restLength);
			Vector2 zero = Vector2.zero;
			stiffnesses.Add(zero);
		}

		[Token(Token = "0x6000157")]
		[Address(RVA = "0xE434B8", Offset = "0xE434B8", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EE8648]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024738]) = v38;\nL_0014:\n\tObi.ObiConstraintsBatch::Clear(this);\n\tObi.ObiNativeList`1<System.Int32>::Clear(this.particleIndices);\n\tObi.ObiNativeList`1<System.Single>::Clear(this.restLengths);\n\tObi.ObiNativeList`1<UnityEngine.Vector2>::Clear(this.stiffnesses);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Clear()
		{
			base.Clear();
			particleIndices.Clear();
			restLengths.Clear();
			stiffnesses.Clear();
		}

		[Token(Token = "0x6000158")]
		[Address(RVA = "0xE43548", Offset = "0xE43548", Length = "0x20")]
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

		[Token(Token = "0x6000159")]
		[Address(RVA = "0xE43568", Offset = "0xE43568", Length = "0x20")]
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

		[Token(Token = "0x600015A")]
		[Address(RVA = "0xE43588", Offset = "0xE43588", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = index << 1;\n\tv20 = Obi.ObiNativeIntList::get_Item(this.particleIndices, v15);\n\tv40 = v15 | 1;\n\tv44 = Obi.ObiNativeIntList::get_Item(this.particleIndices, v40);\n\tv47 = 0;\n\tv50 = 0x102FB58(&v47 @ stack_-28_v1 (Obi.ParticlePair), v20, v44, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\treturn 0;\n\tthrow System.NullReferenceException;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ParticlePair GetParticleIndices(int index)
		{
			int num = index << 1;
			int num2 = particleIndices.get_Item(num);
			int index2 = num | 1;
			int num3 = particleIndices.get_Item(index2);
			ParticlePair particlePair = default(ParticlePair);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @102FB58 (inside Obi.ObiStretchShearConstraintsBatch::GetParticleIndices +0x70)");
			return default(ParticlePair);
		}

		[Token(Token = "0x600015B")]
		[Address(RVA = "0xE43610", Offset = "0xE43610", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1EE8DF8]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, index, particles, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2024739]) = v44;\nL_001B:\n\tv48 = index << 1;\n\tv52 = Obi.ObiNativeIntList::get_Item(this.particleIndices, v48);\n\tSystem.Collections.Generic.List`1<System.Int32>::Add(particles, v52);\n\tv82 = v48 | 1;\n\tv85 = Obi.ObiNativeIntList::get_Item(this.particleIndices, v82);\n\tSystem.Collections.Generic.List`1<System.Int32>::Add(particles, v85);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void GetParticlesInvolved(int index, List<int> particles)
		{
			int num = index << 1;
			int item = particleIndices.get_Item(num);
			particles.Add(item);
			int index2 = num | 1;
			int item2 = particleIndices.get_Item(index2);
			particles.Add(item2);
		}

		[Token(Token = "0x600015C")]
		[Address(RVA = "0xE436C8", Offset = "0xE436C8", Length = "0x198")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1EF5D50]);\n\tv31 = *([v30 @ X8_v20]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, batch, constraintIndex, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([202473A]) = v48;\nL_0019:\n\tv49 = batch == 0;\n\tif (v49) goto L_0043;\n\tgoto L_FFFFFFFF;\n\tv84 = v84_asT != 0;\n\tif (v84) goto L_0045;\nL_0043:\n\treturn;\nL_0045:\n\tObi.ObiConstraintsBatch::RegisterConstraint(this);\n\tv172 = constraintIndex << 1;\n\tv176 = Obi.ObiNativeIntList::get_Item(batch.particleIndices, v172);\n\tObi.ObiNativeList`1<System.Int32>::Add(this.particleIndices, v176);\n\tv222 = v172 | 1;\n\tv213 = Obi.ObiNativeIntList::get_Item(batch.particleIndices, v222);\n\tObi.ObiNativeList`1<System.Int32>::Add(this.particleIndices, v213);\n\tv195 = *([batch @ X1 (Obi.ObiConstraintsBatch)+48]);\n\tv219 = *([v195 @ X0_v14]);\n\t*([v219 @ X8_v11+180])(v214, v195, constraintIndex, *([v219 @ X8_v11+188]), methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tObi.ObiNativeList`1<System.Single>::Add(this.restLengths, v38);\n\tv196 = *([batch @ X1 (Obi.ObiConstraintsBatch)+50]);\n\tv220 = *([v196 @ X0_v17]);\n\t*([v220 @ X8_v14+180])(v215, v196, constraintIndex, *([v220 @ X8_v14+188]), methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\t// 134 MakeStruct v116 @ AGGE43830_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v38 @ V0 (System.Single), v39 @ V1\n\tObi.ObiNativeList`1<UnityEngine.Vector2>::Add(this.stiffnesses, v116);\n\tv121 = this.m_ConstraintCount - 1;\n\tv147 = Obi.ObiConstraintsBatch::ActivateConstraint(this, v121);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 120 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void CopyConstraint(ObiConstraintsBatch batch, int constraintIndex)
		{
			//IL_00c8: Expected O, but got I
			//IL_0103: Expected O, but got I
			//IL_0139: Expected F4, but got O
			if (batch != null)
			{
				ObiDistanceConstraintsBatch obiDistanceConstraintsBatch = batch as ObiDistanceConstraintsBatch;
				if (obiDistanceConstraintsBatch != null)
				{
					RegisterConstraint();
					int num = constraintIndex << 1;
					int item = batch.particleIndices.get_Item(num);
					particleIndices.Add(item);
					int index = num | 1;
					int item2 = batch.particleIndices.get_Item(index);
					particleIndices.Add(item2);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [batch @ X1 (Obi.ObiConstraintsBatch)+48]");
					object obj = 0;
					object obj2 = obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v219 @ X8_v11+180] (should have been resolved before IL gen)");
					float num2 = default(float);
					restLengths.Add(num2);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [batch @ X1 (Obi.ObiConstraintsBatch)+50]");
					object obj3 = 0;
					object obj4 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v220 @ X8_v14+180] (should have been resolved before IL gen)");
					Vector2 item3 = default(Vector2);
					item3.x = num2;
					object obj5 = default(object);
					item3.y = (float)obj5;
					stiffnesses.Add(item3);
					int constraintIndex2 = constraintCount - 1;
					bool flag = ActivateConstraint(constraintIndex2);
				}
			}
		}

		[Token(Token = "0x600015D")]
		[Address(RVA = "0xE43860", Offset = "0xE43860", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv30 = *([1EA6268]);\n\tv31 = *([v30 @ X8_v10]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, sourceIndex, destIndex, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([202473B]) = v48;\nL_001E:\n\tv53 = sourceIndex << 1;\n\tv54 = destIndex << 1;\n\tObi.ObiNativeList`1<System.Int32>::Swap(this.particleIndices, v53, v54);\n\tv65 = v53 | 1;\n\tv59 = v54 | 1;\n\tObi.ObiNativeList`1<System.Int32>::Swap(this.particleIndices, v65, v59);\n\tObi.ObiNativeList`1<System.Single>::Swap(this.restLengths, sourceIndex, destIndex);\n\tObi.ObiNativeList`1<UnityEngine.Vector2>::Swap(this.stiffnesses, sourceIndex, destIndex);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void SwapConstraints(int sourceIndex, int destIndex)
		{
			int num = sourceIndex << 1;
			int num2 = destIndex << 1;
			particleIndices.Swap(num, num2);
			int index = num | 1;
			int index2 = num2 | 1;
			particleIndices.Swap(index, index2);
			restLengths.Swap(sourceIndex, destIndex);
			stiffnesses.Swap(sourceIndex, destIndex);
		}

		[Token(Token = "0x600015E")]
		[Address(RVA = "0xE43938", Offset = "0xE43938", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EAD870]);\n\tv19 = *([v18 @ X8_v24]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202473C]) = v38;\nL_0016:\n\tv42 = new Obi.ObiDistanceConstraintsBatch();\n\tObi.ObiDistanceConstraintsBatch::.ctor(v42, this);\n\tv46 = this.particleIndices;\n\tObi.ObiNativeList`1<System.Int32>::ResizeUninitialized(v42.particleIndices, v46.m_Count);\n\tv61 = this.restLengths;\n\tObi.ObiNativeList`1<System.Single>::ResizeUninitialized(v42.restLengths, v61.m_Count);\n\tv62 = this.stiffnesses;\n\tObi.ObiNativeList`1<UnityEngine.Vector2>::ResizeUninitialized(v42.stiffnesses, v62.m_Count);\n\tObi.ObiNativeList`1<System.Int32>::CopyFrom(v42.particleIndices, this.particleIndices);\n\tObi.ObiNativeList`1<System.Single>::CopyFrom(v42.restLengths, this.restLengths);\n\tObi.ObiNativeList`1<UnityEngine.Vector2>::CopyFrom(v42.stiffnesses, this.stiffnesses);\n\treturn v42;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 75 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override IObiConstraintsBatch Clone()
		{
			ObiDistanceConstraintsBatch obiDistanceConstraintsBatch = new ObiDistanceConstraintsBatch(this);
			ObiNativeIntList obiNativeIntList = particleIndices;
			obiDistanceConstraintsBatch.particleIndices.ResizeUninitialized(obiNativeIntList.count);
			ObiNativeFloatList obiNativeFloatList = restLengths;
			obiDistanceConstraintsBatch.restLengths.ResizeUninitialized(obiNativeFloatList.count);
			ObiNativeVector2List obiNativeVector2List = stiffnesses;
			obiDistanceConstraintsBatch.stiffnesses.ResizeUninitialized(obiNativeVector2List.count);
			obiDistanceConstraintsBatch.particleIndices.CopyFrom(particleIndices);
			obiDistanceConstraintsBatch.restLengths.CopyFrom(restLengths);
			obiDistanceConstraintsBatch.stiffnesses.CopyFrom(stiffnesses);
			return obiDistanceConstraintsBatch;
		}

		[Token(Token = "0x600015F")]
		[Address(RVA = "0xE43A64", Offset = "0xE43A64", Length = "0x2BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1ED6CF0]);\n\tv31 = *([v30 @ X8_v29]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, constraints, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([202473D]) = v49;\nL_0019:\n\tv219 = this.restLengths;\nL_0029:\n\tv100 = v229 >= v219.m_Count;\n\tif (v100) goto L_00F6;\n\tgoto L_0059;\n\tv319 = *([v312 @ X8_v8+B0]);\n\tv320 = 0;\n\tv321 = v319 + 8;\n\tv323 = *([v366 @ X11_v15-8]);\n\tv371 = v323 == v313;\n\tif (v371) goto L_0052;\n\tv343 = v365 + 1;\n\tv422 = v343 < v314;\n\tv341 = ~v422;\n\tv345 = v366 + 0x10;\n\tv325 = ~v341;\n\tif (v325) goto L_FFFFFFFF;\n\tv346 = v22;\n\tv347 = 0;\n\tv348 = 0x8909C4(v346, v313, v347, v73, v35, v36, v37, v38, v65, v69, v41, v42, v43, v44, v45, v46);\n\tgoto L_0059;\nL_0052:\n\tv423 = *([v366 @ X11_v15]);\n\tv424 = v423 << 4;\n\tv425 = v312 + v424;\n\tv426 = v425 + 0x130;\nL_0059:\n\tv198 = Obi.IObiConstraints::GetActor(constraints);\n\tv220 = this.source;\n\tv83 = v198.solverIndices;\n\tv78 = v229 << 1;\n\tv199 = Obi.ObiNativeIntList::get_Item(v220.particleIndices, v78);\n\tv431 = v199 < v83.Length;\n\tv156 = ~v431;\n\tif (v156) goto L_0114;\n\tv439 = Obi.ObiNativeIntList::set_Item(this.particleIndices, v78, v83[v199 @ X0_v16 (System.Int32)]);\n\tv194 = this.particleIndices;\n\tgoto L_00AE;\n\tv444 = *([v440 @ X8_v15+B0]);\n\tv445 = 0;\n\tv446 = v444 + 8;\n\tv448 = *([v485 @ X11_v10-8]);\n\tv490 = v448 == v441;\n\tif (v490) goto L_00A7;\n\tv468 = v484 + 1;\n\tv495 = v468 < v442;\n\tv466 = ~v495;\n\tv470 = v485 + 0x10;\n\tv450 = ~v466;\n\tif (v450) goto L_FFFFFFFF;\n\tv471 = v22;\n\tv472 = 0;\n\tv473 = 0x8909C4(v471, v441, v472, v74, v35, v36, v37, v38, v65, v69, v41, v42, v43, v44, v45, v46);\n\tgoto L_00AE;\nL_00A7:\n\tv496 = *([v485 @ X11_v10]);\n\tv497 = v496 << 4;\n\tv498 = v440 + v497;\n\tv499 = v498 + 0x130;\nL_00AE:\n\tv200 = Obi.IObiConstraints::GetActor(constraints);\n\tv223 = this.source;\n\tv84 = v200.solverIndices;\n\tv79 = v78 | 1;\n\tv201 = Obi.ObiNativeIntList::get_Item(v223.particleIndices, v79);\n\tv504 = v201 < v84.Length;\n\tv158 = ~v504;\n\tif (v158) goto L_0114;\n\tv278 = *([v194 @ X23_v7 (Obi.ObiNativeIntList)]);\n\tv507 = Obi.ObiNativeIntList::set_Item(v194, v79, v84[v201 @ X0_v23 (System.Int32)]);\n\tv272 = this.restLengths;\n\tv226 = *([v272 @ X0_v26 (Obi.ObiNativeFloatList)]);\n\tv509 = Obi.ObiNativeFloatList::get_Item(v272, v229);\n\tv62 = 0;\n\tv202 = 0x1588A6C(&v62 @ stack_-48_v5, 0, *([v226 @ X8_v22 (Il2CppClass<Obi.ObiNativeFloatList>)+188]), *([v278 @ X8_v21 (Il2CppClass<Obi.ObiNativeIntList>)+198]), v35, v36, v37, v38, 0, 0, v41, v42, v43, v44, v45, v46);\n\tv203 = Obi.ObiNativeVector2List::set_Item(this.stiffnesses, v229, Vector2_arg);\n\tv219 = this.restLengths;\n\tv229 = v229 + 1;\n\tv514 = this.restLengths == 0;\n\tv215 = ~v514;\n\tif (v215) goto L_0029;\n\tgoto L_0113;\nL_00F6:\n\tv181 = this.particleIndices;\n\tv166 = this.stiffnesses;\n\tOni::SetDistanceConstraints(this.batch, v181.m_AlignedPtr, v219.m_AlignedPtr, v166.m_AlignedPtr, this.m_ConstraintCount);\n\tOni::SetActiveConstraints(this.batch, this.m_ActiveConstraintCount);\n\treturn;\nL_0113:\n\tv282 = new System.NullReferenceException();\nL_0114:\n\tv311 = new System.IndexOutOfRangeException();\n\tthrow v311;\n\treturn;\n// 189 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void OnAddToSolver(IObiConstraints constraints)
		{
			//IL_0127: Expected I, but got O
			//IL_0158: Expected I, but got O
			//IL_0172: Expected O, but got I4
			//IL_019c: Expected F4, but got O
			ObiNativeFloatList obiNativeFloatList = restLengths;
			int num = 0;
			Vector2 value = default(Vector2);
			object obj2 = default(object);
			while (true)
			{
				if (num >= obiNativeFloatList.count)
				{
					ObiNativeIntList obiNativeIntList = particleIndices;
					ObiNativeVector2List obiNativeVector2List = stiffnesses;
					Oni.SetDistanceConstraints(oniBatch, obiNativeIntList.m_AlignedPtr, obiNativeFloatList.m_AlignedPtr, obiNativeVector2List.m_AlignedPtr, constraintCount);
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
				ObiNativeIntList obiNativeIntList2 = particleIndices;
				ObiActor actor2 = constraints.GetActor();
				ObiConstraintsBatch obiConstraintsBatch2 = source;
				int[] solverIndices2 = actor2.solverIndices;
				int index = num2 | 1;
				int num4 = obiConstraintsBatch2.particleIndices.get_Item(index);
				if (num4 >= solverIndices2.Length)
				{
					break;
				}
				IntPtr intPtr = (IntPtr)obiNativeIntList2;
				obiNativeIntList2.set_Item(index, solverIndices2[num4]);
				ObiNativeFloatList obiNativeFloatList2 = restLengths;
				IntPtr intPtr2 = (IntPtr)obiNativeFloatList2;
				float num5 = obiNativeFloatList2.get_Item(num);
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
				value.x = 0f;
				value.y = (float)obj2;
				stiffnesses.set_Item(num, value);
				obiNativeFloatList = restLengths;
				num++;
				if (restLengths == null)
				{
					NullReferenceException ex = new NullReferenceException();
					break;
				}
			}
			IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
			throw ex2;
		}

		[Token(Token = "0x6000160")]
		[Address(RVA = "0xE32BCC", Offset = "0xE32BCC", Length = "0x180")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv34 = *([1EBE7D8]);\n\tv35 = *([v34 @ X8_v25]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, compliance, slack, stretchingScale, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([202473E]) = v51;\nL_001B:\n\tv152 = this.stiffnesses;\nL_002B:\n\tv163 = v133 >= v152.m_Count;\n\tif (v163) goto L_00A7;\n\tv190 = this.source;\n\tgoto L_FFFFFFFF;\n\tv303 = v303_asT == 0;\n\tif (v303) goto L_00A8;\n\tgoto L_FFFFFFFF;\n\tv80 = v80_asT == 0;\n\tif (v80) goto L_00A8;\n\tv191 = *([v190 @ X0_v8 (Obi.ObiConstraintsBatch)+48]);\n\tv129 = *([v191 @ X0_v10]);\n\t*([v129 @ X8_v18+180])(v121, v191, v133, *([v129 @ X8_v18+188]), v39, v40, v41, v42, v43, v67, v63, stretchingScale, v44, v45, v46, v47, v48);\n\tv167 = v67 * stretchingScale;\n\tv319 = Obi.ObiNativeFloatList::set_Item(this.restLengths, v133, v167);\n\tv192 = this.restLengths;\n\tv130 = *([v192 @ X0_v14 (Obi.ObiNativeFloatList)]);\n\tv321 = Obi.ObiNativeFloatList::get_Item(v192, v133);\n\tv64 = v167 * slack;\n\tv58 = 0;\n\tv122 = 0x1588A6C(&v58 @ stack_-48_v5 (System.Single), 0, *([v130 @ X8_v20 (Il2CppClass<Obi.ObiNativeFloatList>)+188]), v39, v40, v41, v42, v43, compliance, v64, stretchingScale, v44, v45, v46, v47, v48);\n\tv120 = Obi.ObiNativeVector2List::set_Item(this.stiffnesses, v133, Vector2_arg);\n\tv152 = this.stiffnesses;\n\tv133 = v133 + 1;\n\tv326 = this.stiffnesses == 0;\n\tv124 = ~v326;\n\tif (v124) goto L_002B;\n\tthrow System.NullReferenceException;\nL_00A7:\n\treturn;\nL_00A8:\n\tthrow System.InvalidCastException;\n// 134 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetParameters(float compliance, float slack, float stretchingScale)
		{
			//IL_00a4: Expected O, but got I
			//IL_00f9: Expected I, but got O
			ObiNativeVector2List obiNativeVector2List = stiffnesses;
			float num = slack;
			float num2 = compliance;
			int num3 = 0;
			Vector2 value = default(Vector2);
			float num8 = default(float);
			while (true)
			{
				if (num3 >= obiNativeVector2List.count)
				{
					return;
				}
				ObiConstraintsBatch obiConstraintsBatch = source;
				ObiDistanceConstraintsBatch obiDistanceConstraintsBatch = source as ObiDistanceConstraintsBatch;
				if (obiDistanceConstraintsBatch != null)
				{
					ObiDistanceConstraintsBatch obiDistanceConstraintsBatch2 = source as ObiDistanceConstraintsBatch;
					if (obiDistanceConstraintsBatch2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ X0_v8 (Obi.ObiConstraintsBatch)+48]");
						object obj = 0;
						object obj2 = obj;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v129 @ X8_v18+180] (should have been resolved before IL gen)");
						float num4 = num2 * stretchingScale;
						restLengths.set_Item(num3, num4);
						ObiNativeFloatList obiNativeFloatList = restLengths;
						IntPtr intPtr = (IntPtr)obiNativeFloatList;
						float num5 = obiNativeFloatList.get_Item(num3);
						float num6 = num4 * slack;
						float num7 = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
						value.x = 0f;
						value.y = num8;
						stiffnesses.set_Item(num3, value);
						obiNativeVector2List = stiffnesses;
						num3++;
						bool flag = stiffnesses == null;
						bool flag2 = !flag;
						num = num8;
						num2 = 0f;
						if (!flag2)
						{
							break;
						}
						continue;
					}
				}
				throw new InvalidCastException();
			}
			throw new NullReferenceException();
		}
	}
}
