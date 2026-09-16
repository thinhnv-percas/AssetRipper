using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Serializable]
	[Token(Token = "0x200000A")]
	public class ObiChainConstraintsBatch : ObiConstraintsBatch
	{
		[HideInInspector]
		[Token(Token = "0x4000018")]
		[FieldOffset(Offset = "0x48")]
		public ObiNativeIntList firstParticle;

		[HideInInspector]
		[Token(Token = "0x4000019")]
		[FieldOffset(Offset = "0x50")]
		public ObiNativeIntList numParticles;

		[HideInInspector]
		[Token(Token = "0x400001A")]
		[FieldOffset(Offset = "0x58")]
		public ObiNativeVector2List lengths;

		[Token(Token = "0x17000012")]
		public override Oni.ConstraintType constraintType
		{
			[Token(Token = "0x600011E")]
			[Address(RVA = "0xE3FEF8", Offset = "0xE3FEF8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 2;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Oni.ConstraintType.Chain;
			}
		}

		[Token(Token = "0x600011F")]
		[Address(RVA = "0xE3FF00", Offset = "0xE3FF00", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1EB6800]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, source, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202470A]) = v43;\nL_0019:\n\tv47 = new Obi.ObiNativeIntList();\n\tObi.ObiNativeIntList::.ctor(v47, 8, 0x10);\n\tthis.firstParticle = v47;\n\tv52 = new Obi.ObiNativeIntList();\n\tObi.ObiNativeIntList::.ctor(v52, 8, 0x10);\n\tthis.numParticles = v52;\n\tv59 = new Obi.ObiNativeVector2List();\n\tObi.ObiNativeVector2List::.ctor(v59, 8, 0x10);\n\tthis.lengths = v59;\n\tObi.ObiConstraintsBatch::.ctor(this, source);\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiChainConstraintsBatch(ObiChainConstraintsBatch source = null)
		{
			ObiNativeIntList obiNativeIntList = new ObiNativeIntList();
			firstParticle = obiNativeIntList;
			ObiNativeIntList obiNativeIntList2 = new ObiNativeIntList();
			numParticles = obiNativeIntList2;
			lengths = new ObiNativeVector2List();
			base._002Ector(source);
		}

		[Token(Token = "0x6000120")]
		[Address(RVA = "0xE40054", Offset = "0xE40054", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1ED7738]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202470B]) = v40;\nL_0017:\n\tv44 = new Obi.ObiChainConstraintsBatch();\n\tObi.ObiChainConstraintsBatch::.ctor(v44, this);\n\tv48 = this.particleIndices;\n\tObi.ObiNativeList`1<System.Int32>::ResizeUninitialized(v44.particleIndices, v48.m_Count);\n\tv69 = this.firstParticle;\n\tObi.ObiNativeList`1<System.Int32>::ResizeUninitialized(v44.firstParticle, v69.m_Count);\n\tv70 = this.numParticles;\n\tObi.ObiNativeList`1<System.Int32>::ResizeUninitialized(v44.numParticles, v70.m_Count);\n\tv71 = this.lengths;\n\tObi.ObiNativeList`1<UnityEngine.Vector2>::ResizeUninitialized(v44.lengths, v71.m_Count);\n\tObi.ObiNativeList`1<System.Int32>::CopyFrom(v44.particleIndices, this.particleIndices);\n\tObi.ObiNativeList`1<System.Int32>::CopyFrom(v44.firstParticle, this.firstParticle);\n\tObi.ObiNativeList`1<System.Int32>::CopyFrom(v44.numParticles, this.numParticles);\n\tObi.ObiNativeList`1<UnityEngine.Vector2>::CopyFrom(v44.lengths, this.lengths);\n\treturn v44;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override IObiConstraintsBatch Clone()
		{
			ObiChainConstraintsBatch obiChainConstraintsBatch = new ObiChainConstraintsBatch(this);
			ObiNativeIntList obiNativeIntList = particleIndices;
			obiChainConstraintsBatch.particleIndices.ResizeUninitialized(obiNativeIntList.count);
			ObiNativeIntList obiNativeIntList2 = firstParticle;
			obiChainConstraintsBatch.firstParticle.ResizeUninitialized(obiNativeIntList2.count);
			ObiNativeIntList obiNativeIntList3 = numParticles;
			obiChainConstraintsBatch.numParticles.ResizeUninitialized(obiNativeIntList3.count);
			ObiNativeVector2List obiNativeVector2List = lengths;
			obiChainConstraintsBatch.lengths.ResizeUninitialized(obiNativeVector2List.count);
			obiChainConstraintsBatch.particleIndices.CopyFrom(particleIndices);
			obiChainConstraintsBatch.firstParticle.CopyFrom(firstParticle);
			obiChainConstraintsBatch.numParticles.CopyFrom(numParticles);
			obiChainConstraintsBatch.lengths.CopyFrom(lengths);
			return obiChainConstraintsBatch;
		}

		[Token(Token = "0x6000121")]
		[Address(RVA = "0xE401A8", Offset = "0xE401A8", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = *([1EE7518]);\n\tv27 = *([v26 @ X8_v12]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, indices, methodInfo, v30, v31, v32, v33, v34, restLength, stretchStiffness, compressionStiffness, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202470C]) = v44;\nL_0018:\n\tObi.ObiConstraintsBatch::RegisterConstraint(this);\n\tv46 = this.particleIndices;\n\tObi.ObiNativeList`1<System.Int32>::Add(this.firstParticle, v46.m_Count);\n\tObi.ObiNativeList`1<System.Int32>::Add(this.numParticles, indices.Length);\n\tObi.ObiNativeList`1<System.Int32>::AddRange(this.particleIndices, indices);\n\tv52 = 0;\n\tv64 = Obi.ObiNativeList`1<System.Int32>::AddRange(&v52 @ stack_-38_v3, 0);\n\t// 67 MakeStruct v96 @ AGGE40284_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 0, v125 @ stack_-34\n\tObi.ObiNativeList`1<UnityEngine.Vector2>::Add(this.lengths, v96);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddConstraint(int[] indices, float restLength, float stretchStiffness, float compressionStiffness)
		{
			//IL_004c: Expected O, but got I4
			//IL_0076: Expected F4, but got O
			RegisterConstraint();
			ObiNativeIntList obiNativeIntList = particleIndices;
			firstParticle.Add(obiNativeIntList.count);
			numParticles.Add(indices.Length);
			particleIndices.AddRange(indices);
			object obj = 0;
			((ObiNativeList<int>)obj).AddRange((IEnumerable<int>)null);
			Vector2 item = default(Vector2);
			item.x = 0f;
			object obj2 = default(object);
			item.y = (float)obj2;
			lengths.Add(item);
		}

		[Token(Token = "0x6000122")]
		[Address(RVA = "0xE402A8", Offset = "0xE402A8", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EF4AA8]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202470D]) = v38;\nL_0014:\n\tObi.ObiConstraintsBatch::Clear(this);\n\tObi.ObiNativeList`1<System.Int32>::Clear(this.particleIndices);\n\tObi.ObiNativeList`1<System.Int32>::Clear(this.firstParticle);\n\tObi.ObiNativeList`1<System.Int32>::Clear(this.numParticles);\n\tObi.ObiNativeList`1<UnityEngine.Vector2>::Clear(this.lengths);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Clear()
		{
			base.Clear();
			particleIndices.Clear();
			firstParticle.Clear();
			numParticles.Clear();
			lengths.Clear();
		}

		[Token(Token = "0x6000123")]
		[Address(RVA = "0xE40340", Offset = "0xE40340", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void GetParticlesInvolved(int index, List<int> particles)
		{
		}

		[Token(Token = "0x6000124")]
		[Address(RVA = "0xE40344", Offset = "0xE40344", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv26 = *([1EEB460]);\n\tv27 = *([v26 @ X8_v7]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, sourceIndex, destIndex, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202470E]) = v44;\nL_001F:\n\tObi.ObiNativeList`1<System.Int32>::Swap(this.firstParticle, sourceIndex, destIndex);\n\tObi.ObiNativeList`1<System.Int32>::Swap(this.numParticles, sourceIndex, destIndex);\n\tObi.ObiNativeList`1<UnityEngine.Vector2>::Swap(this.lengths, sourceIndex, destIndex);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void SwapConstraints(int sourceIndex, int destIndex)
		{
			firstParticle.Swap(sourceIndex, destIndex);
			numParticles.Swap(sourceIndex, destIndex);
			lengths.Swap(sourceIndex, destIndex);
		}

		[Token(Token = "0x6000125")]
		[Address(RVA = "0xE403EC", Offset = "0xE403EC", Length = "0x198")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1EE6BB8]);\n\tv29 = *([v28 @ X8_v19]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, constraints, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([202470F]) = v47;\nL_0018:\n\tv187 = this.particleIndices;\nL_0028:\n\tv80 = v159 >= v187.m_Count;\n\tif (v80) goto L_0084;\n\tgoto L_0057;\n\tv234 = *([v230 @ X8_v9+B0]);\n\tv235 = 0;\n\tv236 = v234 + 8;\n\tv238 = *([v275 @ X11_v9-8]);\n\tv280 = v238 == v231;\n\tif (v280) goto L_0050;\n\tv258 = v274 + 1;\n\tv292 = v258 < v232;\n\tv256 = ~v292;\n\tv260 = v275 + 0x10;\n\tv240 = ~v256;\n\tif (v240) goto L_FFFFFFFF;\n\tv261 = v20;\n\tv262 = 0;\n\tv263 = 0x8909C4(v261, v231, v262, v60, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_0057;\nL_0050:\n\tv293 = *([v275 @ X11_v9]);\n\tv294 = v293 << 4;\n\tv295 = v230 + v294;\n\tv296 = v295 + 0x130;\nL_0057:\n\tv166 = Obi.IObiConstraints::GetActor(constraints);\n\tv181 = this.source;\n\tv63 = v166.solverIndices;\n\tv167 = Obi.ObiNativeIntList::get_Item(v181.particleIndices, v159);\n\tv347 = v167 < v63.Length;\n\tv126 = ~v347;\n\tif (v126) goto L_00A3;\n\tv164 = Obi.ObiNativeIntList::set_Item(v187, v159, v63[v167 @ X0_v14 (System.Int32)]);\n\tv159 = v159 + 1;\n\tv350 = this.particleIndices == 0;\n\tv170 = ~v350;\n\tif (v170) goto L_0028;\n\tthrow System.NullReferenceException;\nL_0084:\n\tv183 = this.lengths;\n\tv149 = this.firstParticle;\n\tv136 = this.numParticles;\n\tOni::SetChainConstraints(this.batch, v187.m_AlignedPtr, v183.m_AlignedPtr, v149.m_AlignedPtr, v136.m_AlignedPtr, this.m_ConstraintCount);\n\tOni::SetActiveConstraints(this.batch, this.m_ActiveConstraintCount);\n\treturn;\nL_00A3:\n\tv351 = new System.IndexOutOfRangeException();\n\tthrow v351;\n\treturn;\n// 116 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void OnAddToSolver(IObiConstraints constraints)
		{
			ObiNativeIntList obiNativeIntList = particleIndices;
			int num = 0;
			bool flag2;
			do
			{
				if (num >= obiNativeIntList.count)
				{
					ObiNativeVector2List obiNativeVector2List = lengths;
					ObiNativeIntList obiNativeIntList2 = firstParticle;
					ObiNativeIntList obiNativeIntList3 = numParticles;
					Oni.SetChainConstraints(oniBatch, obiNativeIntList.m_AlignedPtr, obiNativeVector2List.m_AlignedPtr, obiNativeIntList2.m_AlignedPtr, obiNativeIntList3.m_AlignedPtr, constraintCount);
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

		[Token(Token = "0x6000126")]
		[Address(RVA = "0xE33DD8", Offset = "0xE33DD8", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv31 = this.m_ConstraintCount < 1;\n\tif (v31) goto L_004E;\nL_0021:\n\tv147 = Obi.ObiNativeVector2List::get_Item(this.lengths, v98);\n\tv159 = this.lengths;\n\tv161 = *([v159 @ X0_v8 (Obi.ObiNativeVector2List)]);\n\tv165 = Obi.ObiNativeVector2List::get_Item(v159, v98);\n\tv166 = v89 * tightness;\n\tv39 = 0;\n\tv169 = 0x1588A6C(&v39 @ stack_-28_v3 (System.Single), 0, *([v161 @ X8_v6 (Il2CppClass<Obi.ObiNativeVector2List>)+188]), v148, v149, v150, v151, v152, v166, v89, v153, v154, v155, v156, v157, v158);\n\tv58 = Obi.ObiNativeVector2List::set_Item(this.lengths, v98, Vector2_arg);\n\tv98 = v98 + 1;\n\tv62 = v98 < this.m_ConstraintCount;\n\tif (v62) goto L_0021;\nL_004E:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetParameters(float tightness)
		{
			//IL_0057: Expected I, but got O
			//IL_00a5: Expected F4, but got O
			if (constraintCount >= 1)
			{
				int num = 0;
				object obj = default(object);
				Vector2 value = default(Vector2);
				object obj2 = default(object);
				bool flag;
				do
				{
					Vector2 vector = lengths.get_Item(num);
					ObiNativeVector2List obiNativeVector2List = lengths;
					IntPtr intPtr = (IntPtr)obiNativeVector2List;
					Vector2 vector2 = obiNativeVector2List.get_Item(num);
					float num2 = (float)obj * tightness;
					float num3 = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
					value.x = 0f;
					value.y = (float)obj2;
					lengths.set_Item(num, value);
					num++;
					flag = num < constraintCount;
					obj = obj2;
				}
				while (flag);
			}
		}
	}
}
