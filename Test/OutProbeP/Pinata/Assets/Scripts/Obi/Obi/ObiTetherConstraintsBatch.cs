using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Serializable]
	[Token(Token = "0x2000012")]
	public class ObiTetherConstraintsBatch : ObiConstraintsBatch
	{
		[HideInInspector]
		[Token(Token = "0x400003A")]
		[FieldOffset(Offset = "0x48")]
		public ObiNativeVector2List maxLengthsScales;

		[HideInInspector]
		[Token(Token = "0x400003B")]
		[FieldOffset(Offset = "0x50")]
		public ObiNativeFloatList stiffnesses;

		[Token(Token = "0x17000022")]
		public override Oni.ConstraintType constraintType
		{
			[Token(Token = "0x6000187")]
			[Address(RVA = "0x10307DC", Offset = "0x10307DC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return default(Oni.ConstraintType);
			}
		}

		[Token(Token = "0x6000188")]
		[Address(RVA = "0x10307E4", Offset = "0x10307E4", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EAAC98]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, source, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2026272]) = v41;\nL_0018:\n\tv45 = new Obi.ObiNativeVector2List();\n\tObi.ObiNativeVector2List::.ctor(v45, 8, 0x10);\n\tthis.maxLengthsScales = v45;\n\tv53 = new Obi.ObiNativeFloatList();\n\tObi.ObiNativeFloatList::.ctor(v53, 8, 0x10);\n\tthis.stiffnesses = v53;\n\tObi.ObiConstraintsBatch::.ctor(this, source);\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiTetherConstraintsBatch(ObiTetherConstraintsBatch source = null)
		{
			ObiNativeVector2List obiNativeVector2List = new ObiNativeVector2List();
			maxLengthsScales = obiNativeVector2List;
			ObiNativeFloatList obiNativeFloatList = new ObiNativeFloatList();
			stiffnesses = obiNativeFloatList;
			base._002Ector(source);
		}

		[Token(Token = "0x6000189")]
		[Address(RVA = "0x103088C", Offset = "0x103088C", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EFE000]);\n\tv19 = *([v18 @ X8_v24]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026273]) = v38;\nL_0016:\n\tv42 = new Obi.ObiTetherConstraintsBatch();\n\tObi.ObiTetherConstraintsBatch::.ctor(v42, this);\n\tv46 = this.particleIndices;\n\tObi.ObiNativeList`1<System.Int32>::ResizeUninitialized(v42.particleIndices, v46.m_Count);\n\tv61 = this.maxLengthsScales;\n\tObi.ObiNativeList`1<UnityEngine.Vector2>::ResizeUninitialized(v42.maxLengthsScales, v61.m_Count);\n\tv62 = this.stiffnesses;\n\tObi.ObiNativeList`1<System.Single>::ResizeUninitialized(v42.stiffnesses, v62.m_Count);\n\tObi.ObiNativeList`1<System.Int32>::CopyFrom(v42.particleIndices, this.particleIndices);\n\tObi.ObiNativeList`1<UnityEngine.Vector2>::CopyFrom(v42.maxLengthsScales, this.maxLengthsScales);\n\tObi.ObiNativeList`1<System.Single>::CopyFrom(v42.stiffnesses, this.stiffnesses);\n\treturn v42;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 75 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override IObiConstraintsBatch Clone()
		{
			ObiTetherConstraintsBatch obiTetherConstraintsBatch = new ObiTetherConstraintsBatch(this);
			ObiNativeIntList obiNativeIntList = particleIndices;
			obiTetherConstraintsBatch.particleIndices.ResizeUninitialized(obiNativeIntList.count);
			ObiNativeVector2List obiNativeVector2List = maxLengthsScales;
			obiTetherConstraintsBatch.maxLengthsScales.ResizeUninitialized(obiNativeVector2List.count);
			ObiNativeFloatList obiNativeFloatList = stiffnesses;
			obiTetherConstraintsBatch.stiffnesses.ResizeUninitialized(obiNativeFloatList.count);
			obiTetherConstraintsBatch.particleIndices.CopyFrom(particleIndices);
			obiTetherConstraintsBatch.maxLengthsScales.CopyFrom(maxLengthsScales);
			obiTetherConstraintsBatch.stiffnesses.CopyFrom(stiffnesses);
			return obiTetherConstraintsBatch;
		}

		[Token(Token = "0x600018A")]
		[Address(RVA = "0x10309B8", Offset = "0x10309B8", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = &v15 @ stack_-10_v2;\n\t*([v14 @ X29_v1-18]) = indices;\n\tgoto L_001B;\n\tv29 = *([1EFFE18]);\n\tv30 = *([v29 @ X8_v10]);\n\tv31 = \"il2cpp_codegen_initialize_method\"(v30, indices, methodInfo, v33, v34, v35, v36, v37, maxLength, scale, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2026274]) = v46;\nL_001B:\n\tObi.ObiConstraintsBatch::RegisterConstraint(this);\n\tv53 = new System.TypeLoadException();\n\tObi.ObiNativeList`1<System.Int32>::Add(this.particleIndices, v53);\n\tv75 = new System.TypeLoadException();\n\tObi.ObiNativeList`1<System.Int32>::Add(this.particleIndices, v75);\n\tv62 = 0;\n\tv76 = Obi.ObiNativeList`1<System.Int32>::Add(&v62 @ stack_-48_v3, 0);\n\t// 67 MakeStruct v88 @ AGG1030A9C_1_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 0, v135 @ stack_-44\n\tObi.ObiNativeList`1<UnityEngine.Vector2>::Add(this.maxLengthsScales, v88);\n\tObi.ObiNativeList`1<System.Single>::Add(this.stiffnesses, 0f);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddConstraint(Vector2Int indices, float maxLength, float scale)
		{
			//IL_0021: Expected I4, but got O
			//IL_003e: Expected I4, but got O
			//IL_0047: Expected O, but got I4
			//IL_0075: Expected F4, but got O
			object obj2 = default(object);
			object obj = obj2;
			RegisterConstraint();
			TypeLoadException ex = new TypeLoadException();
			particleIndices.Add((int)ex);
			TypeLoadException ex2 = new TypeLoadException();
			particleIndices.Add((int)ex2);
			object obj3 = 0;
			((ObiNativeList<int>)obj3).Add(0);
			Vector2 item = default(Vector2);
			item.x = 0f;
			object obj4 = default(object);
			item.y = (float)obj4;
			maxLengthsScales.Add(item);
			stiffnesses.Add(0f);
		}

		[Token(Token = "0x600018B")]
		[Address(RVA = "0x1030ADC", Offset = "0x1030ADC", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EDA648]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026275]) = v38;\nL_0015:\n\tObi.ObiConstraintsBatch::Clear(this);\n\tObi.ObiNativeList`1<System.Int32>::Clear(this.particleIndices);\n\tObi.ObiNativeList`1<UnityEngine.Vector2>::Clear(this.maxLengthsScales);\n\tObi.ObiNativeList`1<System.Single>::Clear(this.stiffnesses);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Clear()
		{
			base.Clear();
			particleIndices.Clear();
			maxLengthsScales.Clear();
			stiffnesses.Clear();
		}

		[Token(Token = "0x600018C")]
		[Address(RVA = "0x1030B70", Offset = "0x1030B70", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1ED4938]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, index, particles, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2026276]) = v44;\nL_001B:\n\tv48 = index << 1;\n\tv52 = Obi.ObiNativeIntList::get_Item(this.particleIndices, v48);\n\tSystem.Collections.Generic.List`1<System.Int32>::Add(particles, v52);\n\tv82 = v48 | 1;\n\tv85 = Obi.ObiNativeIntList::get_Item(this.particleIndices, v82);\n\tSystem.Collections.Generic.List`1<System.Int32>::Add(particles, v85);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void GetParticlesInvolved(int index, List<int> particles)
		{
			int num = index << 1;
			int item = particleIndices.get_Item(num);
			particles.Add(item);
			int index2 = num | 1;
			int item2 = particleIndices.get_Item(index2);
			particles.Add(item2);
		}

		[Token(Token = "0x600018D")]
		[Address(RVA = "0x1030C28", Offset = "0x1030C28", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv30 = *([1EE1390]);\n\tv31 = *([v30 @ X8_v10]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, sourceIndex, destIndex, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2026277]) = v48;\nL_001E:\n\tv53 = sourceIndex << 1;\n\tv54 = destIndex << 1;\n\tObi.ObiNativeList`1<System.Int32>::Swap(this.particleIndices, v53, v54);\n\tv65 = v53 | 1;\n\tv59 = v54 | 1;\n\tObi.ObiNativeList`1<System.Int32>::Swap(this.particleIndices, v65, v59);\n\tObi.ObiNativeList`1<UnityEngine.Vector2>::Swap(this.maxLengthsScales, sourceIndex, destIndex);\n\tObi.ObiNativeList`1<System.Single>::Swap(this.stiffnesses, sourceIndex, destIndex);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void SwapConstraints(int sourceIndex, int destIndex)
		{
			int num = sourceIndex << 1;
			int num2 = destIndex << 1;
			particleIndices.Swap(num, num2);
			int index = num | 1;
			int index2 = num2 | 1;
			particleIndices.Swap(index, index2);
			maxLengthsScales.Swap(sourceIndex, destIndex);
			stiffnesses.Swap(sourceIndex, destIndex);
		}

		[Token(Token = "0x600018E")]
		[Address(RVA = "0x1030D00", Offset = "0x1030D00", Length = "0x260")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1ED2D18]);\n\tv31 = *([v30 @ X8_v27]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, constraints, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([2026278]) = v49;\nL_0019:\n\tv200 = this.stiffnesses;\nL_0029:\n\tv82 = v176 >= v200.m_Count;\n\tif (v82) goto L_00DD;\n\tgoto L_0059;\n\tv288 = *([v281 @ X8_v8+B0]);\n\tv289 = 0;\n\tv290 = v288 + 8;\n\tv292 = *([v334 @ X11_v15-8]);\n\tv339 = v292 == v282;\n\tif (v339) goto L_0052;\n\tv312 = v333 + 1;\n\tv385 = v312 < v283;\n\tv310 = ~v385;\n\tv314 = v334 + 0x10;\n\tv294 = ~v310;\n\tif (v294) goto L_FFFFFFFF;\n\tv315 = v22;\n\tv316 = 0;\n\tv317 = 0x8909C4(v315, v282, v316, v61, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_0059;\nL_0052:\n\tv386 = *([v334 @ X11_v15]);\n\tv387 = v386 << 4;\n\tv388 = v281 + v387;\n\tv389 = v388 + 0x130;\nL_0059:\n\tv181 = Obi.IObiConstraints::GetActor(constraints);\n\tv201 = this.source;\n\tv66 = v181.solverIndices;\n\tv210 = v176 << 1;\n\tv182 = Obi.ObiNativeIntList::get_Item(v201.particleIndices, v210);\n\tv394 = v182 < v66.Length;\n\tv138 = ~v394;\n\tif (v138) goto L_00F9;\n\tv402 = Obi.ObiNativeIntList::set_Item(this.particleIndices, v210, v66[v182 @ X0_v16 (System.Int32)]);\n\tgoto L_00AE;\n\tv407 = *([v403 @ X8_v15+B0]);\n\tv408 = 0;\n\tv409 = v407 + 8;\n\tv411 = *([v448 @ X11_v10-8]);\n\tv453 = v411 == v404;\n\tif (v453) goto L_00A7;\n\tv431 = v447 + 1;\n\tv458 = v431 < v405;\n\tv429 = ~v458;\n\tv433 = v448 + 0x10;\n\tv413 = ~v429;\n\tif (v413) goto L_FFFFFFFF;\n\tv434 = v22;\n\tv435 = 0;\n\tv436 = 0x8909C4(v434, v404, v435, v62, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_00AE;\nL_00A7:\n\tv459 = *([v448 @ X11_v10]);\n\tv460 = v459 << 4;\n\tv461 = v403 + v460;\n\tv462 = v461 + 0x130;\nL_00AE:\n\tv183 = Obi.IObiConstraints::GetActor(constraints);\n\tv204 = this.source;\n\tv67 = v183.solverIndices;\n\tv211 = v210 | 1;\n\tv184 = Obi.ObiNativeIntList::get_Item(v204.particleIndices, v211);\n\tv467 = v184 < v67.Length;\n\tv140 = ~v467;\n\tif (v140) goto L_00F9;\n\tv185 = Obi.ObiNativeIntList::set_Item(this.particleIndices, v211, v67[v184 @ X0_v23 (System.Int32)]);\n\tv200 = this.stiffnesses;\n\tv176 = v176 + 1;\n\tv471 = this.stiffnesses == 0;\n\tv196 = ~v471;\n\tif (v196) goto L_0029;\n\tgoto L_00F8;\nL_00DD:\n\tv162 = this.particleIndices;\n\tv148 = this.maxLengthsScales;\n\tOni::SetTetherConstraints(this.batch, v162.m_AlignedPtr, v148.m_AlignedPtr, v200.m_AlignedPtr, this.m_ConstraintCount);\n\tOni::SetActiveConstraints(this.batch, this.m_ActiveConstraintCount);\n\treturn;\nL_00F8:\n\tv254 = new System.NullReferenceException();\nL_00F9:\n\tv280 = new System.IndexOutOfRangeException();\n\tthrow v280;\n\treturn;\n// 170 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void OnAddToSolver(IObiConstraints constraints)
		{
			ObiNativeFloatList obiNativeFloatList = stiffnesses;
			int num = 0;
			while (true)
			{
				if (num >= obiNativeFloatList.count)
				{
					ObiNativeIntList obiNativeIntList = particleIndices;
					ObiNativeVector2List obiNativeVector2List = maxLengthsScales;
					Oni.SetTetherConstraints(oniBatch, obiNativeIntList.m_AlignedPtr, obiNativeVector2List.m_AlignedPtr, obiNativeFloatList.m_AlignedPtr, constraintCount);
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
				obiNativeFloatList = stiffnesses;
				num++;
				if (stiffnesses == null)
				{
					NullReferenceException ex = new NullReferenceException();
					break;
				}
			}
			IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
			throw ex2;
		}

		[Token(Token = "0x600018F")]
		[Address(RVA = "0x1031028", Offset = "0x1031028", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1ECDF60]);\n\tv29 = *([v28 @ X8_v11]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, compliance, scale, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2026279]) = v46;\nL_0018:\n\tv127 = this.stiffnesses;\nL_0026:\n\tv51 = v110 >= v127.m_Count;\n\tif (v51) goto L_0053;\n\tv101 = Obi.ObiNativeFloatList::set_Item(v127, v110, compliance);\n\tv85 = this.maxLengthsScales;\n\tv159 = *([v85 @ X21_v5 (Obi.ObiNativeVector2List)]);\n\tv164 = Obi.ObiNativeVector2List::get_Item(v85, v110);\n\tv78 = 0;\n\tv168 = 0x1588A6C(&v78 @ stack_-28_v4, 0, *([v159 @ X8_v8 (Il2CppClass<Obi.ObiNativeVector2List>)+188]), v33, v34, v35, v36, v37, compliance, scale, v38, v39, v40, v41, v42, v43);\n\tv171 = Obi.ObiNativeVector2List::set_Item(v85, v110, Vector2_arg);\n\tv127 = this.stiffnesses;\n\tv110 = v110 + 1;\n\tv172 = this.stiffnesses == 0;\n\tv103 = ~v172;\n\tif (v103) goto L_0026;\n\tthrow System.NullReferenceException;\nL_0053:\n\treturn;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetParameters(float compliance, float scale)
		{
			//IL_003b: Expected I, but got O
			//IL_0055: Expected O, but got I4
			ObiNativeFloatList obiNativeFloatList = stiffnesses;
			int num = 0;
			Vector2 value = default(Vector2);
			float y = default(float);
			while (num < obiNativeFloatList.count)
			{
				obiNativeFloatList.set_Item(num, compliance);
				ObiNativeVector2List obiNativeVector2List = maxLengthsScales;
				IntPtr intPtr = (IntPtr)obiNativeVector2List;
				Vector2 vector = obiNativeVector2List.get_Item(num);
				object obj = 0;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
				value.x = 0f;
				value.y = y;
				obiNativeVector2List.set_Item(num, value);
				obiNativeFloatList = stiffnesses;
				num++;
				if (stiffnesses == null)
				{
					throw new NullReferenceException();
				}
			}
		}
	}
}
