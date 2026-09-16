using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Serializable]
	[Token(Token = "0x2000007")]
	public class ObiAerodynamicConstraintsBatch : ObiConstraintsBatch
	{
		[HideInInspector]
		[Token(Token = "0x4000013")]
		[FieldOffset(Offset = "0x48")]
		public ObiNativeFloatList aerodynamicCoeffs;

		[Token(Token = "0x1700000F")]
		public override Oni.ConstraintType constraintType
		{
			[Token(Token = "0x6000103")]
			[Address(RVA = "0xE3CFD0", Offset = "0xE3CFD0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0xD;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Oni.ConstraintType.Aerodynamics;
			}
		}

		[Token(Token = "0x6000104")]
		[Address(RVA = "0xE3CFD8", Offset = "0xE3CFD8", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([20246EB]) & 1;\n\tv19 = v18 == 0;\n\tv20 = ~v19;\n\tif (v20) goto L_0019;\n\tv23 = 0xE4839C(this, source, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\treturn;\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([20246EB]) = X8;\nL_0019:\n\tv41 = new Obi.ObiNativeFloatList();\n\tObi.ObiNativeFloatList::.ctor(v41, 8, 0x10);\n\tthis.aerodynamicCoeffs = v41;\n\tObi.ObiConstraintsBatch::.ctor(this, source);\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiAerodynamicConstraintsBatch(ObiAerodynamicConstraintsBatch source = null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [20246EB]");
			if (0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E4839C (inside Obi.ObiNativeVector2List::set_Item +0x14)");
				return;
			}
			aerodynamicCoeffs = new ObiNativeFloatList();
			base._002Ector(source);
		}

		[Token(Token = "0x6000105")]
		[Address(RVA = "0xE3D218", Offset = "0xE3D218", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1F10AB8]);\n\tv19 = *([v18 @ X8_v19]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20246EC]) = v38;\nL_0016:\n\tv42 = new Obi.ObiAerodynamicConstraintsBatch();\n\tObi.ObiAerodynamicConstraintsBatch::.ctor(v42, this);\n\tv46 = this.particleIndices;\n\tObi.ObiNativeList`1<System.Int32>::ResizeUninitialized(v42.particleIndices, v46.m_Count);\n\tv57 = this.aerodynamicCoeffs;\n\tObi.ObiNativeList`1<System.Single>::ResizeUninitialized(v42.aerodynamicCoeffs, v57.m_Count);\n\tObi.ObiNativeList`1<System.Int32>::CopyFrom(v42.particleIndices, this.particleIndices);\n\tObi.ObiNativeList`1<System.Single>::CopyFrom(v42.aerodynamicCoeffs, this.aerodynamicCoeffs);\n\treturn v42;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override IObiConstraintsBatch Clone()
		{
			ObiAerodynamicConstraintsBatch obiAerodynamicConstraintsBatch = new ObiAerodynamicConstraintsBatch(this);
			ObiNativeIntList obiNativeIntList = particleIndices;
			obiAerodynamicConstraintsBatch.particleIndices.ResizeUninitialized(obiNativeIntList.count);
			ObiNativeFloatList obiNativeFloatList = aerodynamicCoeffs;
			obiAerodynamicConstraintsBatch.aerodynamicCoeffs.ResizeUninitialized(obiNativeFloatList.count);
			obiAerodynamicConstraintsBatch.particleIndices.CopyFrom(particleIndices);
			obiAerodynamicConstraintsBatch.aerodynamicCoeffs.CopyFrom(aerodynamicCoeffs);
			return obiAerodynamicConstraintsBatch;
		}

		[Token(Token = "0x6000106")]
		[Address(RVA = "0xE3D304", Offset = "0xE3D304", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv34 = *([1EEA8F8]);\n\tv35 = *([v34 @ X8_v8]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, index, methodInfo, v38, v39, v40, v41, v42, area, drag, lift, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20246ED]) = v50;\nL_001C:\n\tObi.ObiConstraintsBatch::RegisterConstraint(this);\n\tObi.ObiNativeList`1<System.Int32>::Add(this.particleIndices, index);\n\tObi.ObiNativeList`1<System.Single>::Add(this.aerodynamicCoeffs, area);\n\tObi.ObiNativeList`1<System.Single>::Add(this.aerodynamicCoeffs, drag);\n\tObi.ObiNativeList`1<System.Single>::Add(this.aerodynamicCoeffs, lift);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddConstraint(int index, float area, float drag, float lift)
		{
			RegisterConstraint();
			particleIndices.Add(index);
			aerodynamicCoeffs.Add(area);
			aerodynamicCoeffs.Add(drag);
			aerodynamicCoeffs.Add(lift);
		}

		[Token(Token = "0x6000107")]
		[Address(RVA = "0xE3D454", Offset = "0xE3D454", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv26 = *([1EED5F0]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, index, particles, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20246EE]) = v44;\nL_001E:\n\tv51 = Obi.ObiNativeIntList::get_Item(this.particleIndices, index);\n\tSystem.Collections.Generic.List`1<System.Int32>::Add(particles, v51);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void GetParticlesInvolved(int index, List<int> particles)
		{
			int item = particleIndices.get_Item(index);
			particles.Add(item);
		}

		[Token(Token = "0x6000108")]
		[Address(RVA = "0xE3D4E0", Offset = "0xE3D4E0", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EE5B48]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20246EF]) = v38;\nL_0014:\n\tObi.ObiConstraintsBatch::Clear(this);\n\tObi.ObiNativeList`1<System.Int32>::Clear(this.particleIndices);\n\tObi.ObiNativeList`1<System.Single>::Clear(this.aerodynamicCoeffs);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Clear()
		{
			base.Clear();
			particleIndices.Clear();
			aerodynamicCoeffs.Clear();
		}

		[Token(Token = "0x6000109")]
		[Address(RVA = "0xE3D5C4", Offset = "0xE3D5C4", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv26 = *([1EF8DE8]);\n\tv27 = *([v26 @ X8_v8]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, sourceIndex, destIndex, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20246F0]) = v44;\nL_001F:\n\tObi.ObiNativeList`1<System.Int32>::Swap(this.particleIndices, sourceIndex, destIndex);\n\tv81 = sourceIndex << 1;\n\tv73 = sourceIndex + v81;\n\tv54 = destIndex << 1;\n\tv75 = destIndex + v54;\n\tObi.ObiNativeList`1<System.Single>::Swap(this.aerodynamicCoeffs, v73, v75);\n\tv63 = v73 + 1;\n\tv60 = v75 + 1;\n\tObi.ObiNativeList`1<System.Single>::Swap(this.aerodynamicCoeffs, v63, v60);\n\tv88 = v75 + 2;\n\tv90 = v73 + 2;\n\tObi.ObiNativeList`1<System.Single>::Swap(this.aerodynamicCoeffs, v90, v88);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void SwapConstraints(int sourceIndex, int destIndex)
		{
			particleIndices.Swap(sourceIndex, destIndex);
			int num = sourceIndex << 1;
			int num2 = sourceIndex + num;
			int num3 = destIndex << 1;
			int num4 = destIndex + num3;
			aerodynamicCoeffs.Swap(num2, num4);
			int index = num2 + 1;
			int index2 = num4 + 1;
			aerodynamicCoeffs.Swap(index, index2);
			int index3 = num4 + 2;
			int index4 = num2 + 2;
			aerodynamicCoeffs.Swap(index4, index3);
		}

		[Token(Token = "0x600010A")]
		[Address(RVA = "0xE3D68C", Offset = "0xE3D68C", Length = "0x180")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1ED87D8]);\n\tv29 = *([v28 @ X8_v19]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, constraints, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20246F1]) = v47;\nL_0018:\n\tv183 = this.particleIndices;\nL_0028:\n\tv80 = v157 >= v183.m_Count;\n\tif (v80) goto L_0084;\n\tgoto L_0057;\n\tv235 = *([v226 @ X8_v9+B0]);\n\tv236 = 0;\n\tv237 = v235 + 8;\n\tv239 = *([v287 @ X11_v9-8]);\n\tv292 = v239 == v227;\n\tif (v292) goto L_0050;\n\tv259 = v286 + 1;\n\tv297 = v259 < v228;\n\tv257 = ~v297;\n\tv261 = v287 + 0x10;\n\tv241 = ~v257;\n\tif (v241) goto L_FFFFFFFF;\n\tv262 = v20;\n\tv263 = 0;\n\tv264 = 0x8909C4(v262, v227, v263, v60, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_0057;\nL_0050:\n\tv298 = *([v287 @ X11_v9]);\n\tv299 = v298 << 4;\n\tv300 = v226 + v299;\n\tv301 = v300 + 0x130;\nL_0057:\n\tv164 = Obi.IObiConstraints::GetActor(constraints);\n\tv177 = this.source;\n\tv63 = v164.solverIndices;\n\tv165 = Obi.ObiNativeIntList::get_Item(v177.particleIndices, v157);\n\tv339 = v165 < v63.Length;\n\tv126 = ~v339;\n\tif (v126) goto L_009B;\n\tv162 = Obi.ObiNativeIntList::set_Item(v183, v157, v63[v165 @ X0_v14 (System.Int32)]);\n\tv157 = v157 + 1;\n\tv342 = this.particleIndices == 0;\n\tv168 = ~v342;\n\tif (v168) goto L_0028;\n\tthrow System.NullReferenceException;\nL_0084:\n\tv179 = this.aerodynamicCoeffs;\n\tOni::SetAerodynamicConstraints(this.batch, v183.m_AlignedPtr, v179.m_AlignedPtr, this.m_ConstraintCount);\n\tOni::SetActiveConstraints(this.batch, this.m_ActiveConstraintCount);\n\treturn;\nL_009B:\n\tv343 = new System.IndexOutOfRangeException();\n\tthrow v343;\n\treturn;\n// 110 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void OnAddToSolver(IObiConstraints constraints)
		{
			ObiNativeIntList obiNativeIntList = particleIndices;
			int num = 0;
			bool flag2;
			do
			{
				if (num >= obiNativeIntList.count)
				{
					ObiNativeFloatList obiNativeFloatList = aerodynamicCoeffs;
					Oni.SetAerodynamicConstraints(oniBatch, obiNativeIntList.m_AlignedPtr, obiNativeFloatList.m_AlignedPtr, constraintCount);
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

		[Token(Token = "0x600010B")]
		[Address(RVA = "0xE33804", Offset = "0xE33804", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1EA9D48]);\n\tv31 = *([v30 @ X8_v14]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, drag, lift, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([20246F2]) = v48;\nL_0019:\n\tv120 = this.particleIndices;\nL_001F:\n\tv117 = v117 + 1;\n\tv54 = v117 >= v120.m_Count;\n\tif (v54) goto L_004E;\n\tv185 = v121 - 1;\n\tv189 = Obi.ObiNativeFloatList::set_Item(this.aerodynamicCoeffs, v185, drag);\n\tv81 = v121 + 3;\n\tv94 = Obi.ObiNativeFloatList::set_Item(this.aerodynamicCoeffs, v121, lift);\n\tv120 = this.particleIndices;\n\tv194 = this.particleIndices == 0;\n\tv96 = ~v194;\n\tif (v96) goto L_001F;\n\tthrow System.NullReferenceException;\nL_004E:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetParameters(float drag, float lift)
		{
			ObiNativeIntList obiNativeIntList = particleIndices;
			int num = -1;
			int num2 = 2;
			while (true)
			{
				num++;
				if (num < obiNativeIntList.count)
				{
					int index = num2 - 1;
					aerodynamicCoeffs.set_Item(index, drag);
					int num3 = num2 + 3;
					aerodynamicCoeffs.set_Item(num2, lift);
					obiNativeIntList = particleIndices;
					bool flag = particleIndices == null;
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
