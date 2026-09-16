using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x744CF0", Offset = "0x744CF0")]
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x744CF0", Offset = "0x744CF0")]
	[Token(Token = "0x2000062")]
	public class ObiRopeCursor : MonoBehaviour
	{
		[Token(Token = "0x40001CD")]
		[FieldOffset(Offset = "0x18")]
		private ObiRope rope;

		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x7465B4", Offset = "0x7465B4")]
		[HideInInspector]
		[SerializeField]
		[Token(Token = "0x40001CE")]
		[FieldOffset(Offset = "0x20")]
		private float m_CursorMu;

		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x746604", Offset = "0x746604")]
		[HideInInspector]
		[SerializeField]
		[Token(Token = "0x40001CF")]
		[FieldOffset(Offset = "0x24")]
		private float m_SourceMu;

		[Token(Token = "0x40001D0")]
		[FieldOffset(Offset = "0x28")]
		public bool direction;

		[Token(Token = "0x40001D1")]
		[FieldOffset(Offset = "0x30")]
		private ObiStructuralElement m_CursorElement;

		[Token(Token = "0x40001D2")]
		[FieldOffset(Offset = "0x38")]
		private int m_SourceIndex;

		[Token(Token = "0x170000AD")]
		public float cursorMu
		{
			[Token(Token = "0x600043A")]
			[Address(RVA = "0xC3BAB4", Offset = "0xC3BAB4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_CursorMu;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return cursorMu;
			}
			[Token(Token = "0x6000439")]
			[Address(RVA = "0xC3BA24", Offset = "0xC3BA24", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_CursorMu = value;\n\tObi.ObiRopeCursor::UpdateCursor(this);\n\treturn;\n")]
			set
			{
				m_CursorMu = value;
				UpdateCursor();
			}
		}

		[Token(Token = "0x170000AE")]
		public float sourceMu
		{
			[Token(Token = "0x600043C")]
			[Address(RVA = "0xC3BBBC", Offset = "0xC3BBBC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_SourceMu;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return sourceMu;
			}
			[Token(Token = "0x600043B")]
			[Address(RVA = "0xC3BABC", Offset = "0xC3BABC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_SourceMu = value;\n\tObi.ObiRopeCursor::UpdateSource(this);\n\treturn;\n")]
			set
			{
				m_SourceMu = value;
				UpdateSource();
			}
		}

		[Token(Token = "0x170000AF")]
		public ObiStructuralElement cursorElement
		{
			[Token(Token = "0x600043D")]
			[Address(RVA = "0xC3BBC4", Offset = "0xC3BBC4", Length = "0x30")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = this.m_CursorElement;\n\tv11 = this.m_CursorElement == 0;\n\tv12 = ~v11;\n\tif (v12) goto L_0011;\n\tObi.ObiRopeCursor::UpdateCursor(this);\n\treturnVal1 = this.m_CursorElement;\nL_0011:\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ObiStructuralElement result = m_CursorElement;
				if (m_CursorElement == null)
				{
					UpdateCursor();
					result = m_CursorElement;
				}
				return result;
			}
		}

		[Token(Token = "0x170000B0")]
		public int sourceParticleIndex
		{
			[Token(Token = "0x600043E")]
			[Address(RVA = "0xC3BBF4", Offset = "0xC3BBF4", Length = "0x30")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = this.m_SourceIndex;\n\tv11 = this.m_SourceIndex & 0x80000000;\n\tv12 = v11 == 0;\n\tif (v12) goto L_0011;\n\tObi.ObiRopeCursor::UpdateSource(this);\n\treturnVal1 = this.m_SourceIndex;\nL_0011:\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_001e: Expected I4, but got I8
				int sourceIndex = m_SourceIndex;
				if ((int)(m_SourceIndex & 0x80000000L) != 0)
				{
					UpdateSource();
					sourceIndex = m_SourceIndex;
				}
				return sourceIndex;
			}
		}

		[Token(Token = "0x600043F")]
		[Address(RVA = "0xC3BC24", Offset = "0xC3BC24", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1F02C60]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20231D9]) = v40;\nL_0018:\n\tv45 = UnityEngine.Component::GetComponent(this);\n\tthis.rope = v45;\n\tv50 = new Obi.ObiActor+ActorCallback();\n\tObi.ObiActor+ActorCallback::.ctor(v50, this, Il2CppMethodInfo);\n\tObi.ObiRopeBase::add_OnElementsGenerated(v45, v50);\n\tv65 = this.rope;\n\tv68 = v65.elements;\n\tv69 = v65.elements == 0;\n\tif (v69) goto L_004F;\n\tv74 = v68._size < 1;\n\tif (v74) goto L_004F;\n\tObi.ObiRopeCursor::UpdateCursor(this);\n\tObi.ObiRopeCursor::UpdateSource(this);\n\treturn;\nL_004F:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			ObiRope obiRope = (rope = GetComponent<ObiRope>());
			ObiActor.ActorCallback value = Actor_OnElementsGenerated;
			obiRope.OnElementsGenerated += value;
			ObiRope obiRope2 = rope;
			List<ObiStructuralElement> elements = obiRope2.elements;
			if (obiRope2.elements != null && elements.Count >= 1)
			{
				UpdateCursor();
				UpdateSource();
			}
		}

		[Token(Token = "0x6000440")]
		[Address(RVA = "0xC3BD04", Offset = "0xC3BD04", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tObi.ObiRopeCursor::UpdateCursor(this);\n\tObi.ObiRopeCursor::UpdateSource(this);\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Actor_OnElementsGenerated(ObiActor actor)
		{
			UpdateCursor();
			UpdateSource();
		}

		[Token(Token = "0x6000441")]
		[Address(RVA = "0xC3BD28", Offset = "0xC3BD28", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1ED1320]);\n\tv21 = *([v20 @ X8_v8]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20231DA]) = v40;\nL_0018:\n\tv45 = new Obi.ObiActor+ActorCallback();\n\tObi.ObiActor+ActorCallback::.ctor(v45, this, Il2CppMethodInfo);\n\tObi.ObiRopeBase::remove_OnElementsGenerated(this.rope, v45);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDestroy()
		{
			ObiActor.ActorCallback value = Actor_OnElementsGenerated;
			rope.OnElementsGenerated -= value;
		}

		[Token(Token = "0x6000442")]
		[Address(RVA = "0xC3BA2C", Offset = "0xC3BA2C", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EFA320]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20231DB]) = v38;\nL_0016:\n\tv42 = 0;\n\tv44 = UnityEngine.Component::GetComponent(this);\n\tthis.rope = v44;\n\tthis.m_CursorElement = 0;\n\tv47 = ~v44.m_Loaded;\n\tif (v47) goto L_0029;\n\tv51 = Obi.ObiRopeBase::GetElementAt(v44, this.m_CursorMu, &v42 @ stack_-24_v1 (System.Single));\n\tthis.m_CursorElement = v51;\nL_0029:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateCursor()
		{
			float elementMu = 0f;
			ObiRope obiRope = (rope = GetComponent<ObiRope>());
			m_CursorElement = null;
			if (obiRope.isLoaded)
			{
				ObiStructuralElement elementAt = obiRope.GetElementAt(cursorMu, out elementMu);
				m_CursorElement = elementAt;
			}
		}

		[Token(Token = "0x6000443")]
		[Address(RVA = "0xC3BAC4", Offset = "0xC3BAC4", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EB4C38]);\n\tv21 = *([v20 @ X8_v19]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20231DC]) = v40;\nL_0019:\n\tv46 = UnityEngine.Component::GetComponent(this);\n\tthis.rope = v46;\n\tthis.m_SourceIndex = 0xFFFFFFFF;\n\tv50 = ~v46.m_Loaded;\n\tif (v50) goto L_005A;\n\tv55 = Obi.ObiRopeBase::GetElementAt(v46, this.m_SourceMu, &v54 @ stack_-24_v4 (System.Single));\n\tv102 = v55 == 0;\n\tif (v102) goto L_005A;\n\tv120 = this.rope;\n\tgoto L_003B;\n\tv152 = *([v149 @ X0_v10+E0]);\n\tv153 = v152 == 0;\n\tv154 = ~v153;\n\tif (v154) goto L_003B;\n\tv156 = \"il2cpp_codegen_runtime_class_init\"(v149, v53, v24, v25, v26, v27, v28, v29, v52, v31, v32, v33, v34, v35, v36, v37);\nL_003B:\n\tv99 = UnityEngine.Object::op_Inequality(v120.m_Solver, 0);\n\tv101 = v99 == 0;\n\tif (v101) goto L_005A;\n\tv164 = v55 + 0x10;\n\tv90 = v55 + 0x14;\n\tv57 = v54 >= 0.5f;\n\tif (v57) goto L_FFFFFFFF;\n\tgoto L_0053;\nL_0053:\n\tthis.m_SourceIndex = *([v164 @ X8_v12]);\nL_005A:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateSource()
		{
			//IL_00aa: Expected O, but got I
			//IL_00b9: Expected O, but got I
			//IL_011c: Expected I4, but got O
			ObiRope obiRope = (rope = GetComponent<ObiRope>());
			m_SourceIndex = -1;
			if (!obiRope.isLoaded)
			{
				return;
			}
			ObiStructuralElement elementAt = obiRope.GetElementAt(sourceMu, out var elementMu);
			if (elementAt == null)
			{
				return;
			}
			ObiRope obiRope2 = rope;
			if (obiRope2.solver != null)
			{
				object obj = (long)(IntPtr)elementAt + 16L;
				object obj2 = (long)(IntPtr)elementAt + 20L;
				if (!(elementMu < 0.5f))
				{
					obj = obj2;
				}
				m_SourceIndex = (int)obj;
			}
		}

		[Token(Token = "0x6000444")]
		[Address(RVA = "0xC3BDB4", Offset = "0xC3BDB4", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv32 = *([1EB5AF8]);\n\tv33 = *([v32 @ X8_v24]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, index, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([20231DD]) = v51;\nL_001A:\n\tv52 = this.rope;\n\tv154 = v52.m_ActiveParticleCount;\n\tv135 = Obi.ObiSolver::get_particleToActor(v52.m_Solver);\n\tv233 = this.m_SourceIndex;\n\tv236 = this.m_SourceIndex < v135.Length;\n\tv121 = ~v236;\n\tif (v121) goto L_00A7;\n\tv147 = v135[v233 @ X8_v6 (System.Int32)];\n\tv136 = Obi.ObiActor::CopyParticle(v52, v147.indexInActor, v52.m_ActiveParticleCount);\n\tv82 = this.rope;\n\tv137 = Obi.ObiSolver::get_positions(v82.m_Solver);\n\tv149 = this.rope;\n\tv150 = v149.solverIndices;\n\tv288 = v150.Length < index;\n\tv122 = ~v288;\n\tv118 = v150.Length - index;\n\tv110 = v118 == 0;\n\tv289 = ~v122;\n\tv80 = v289 | v110;\n\tif (v80) goto L_00A7;\n\tv294 = Obi.ObiNativeVector4List::get_Item(v137, v150[index @ X1 (System.Int32)]);\n\tgoto L_0076;\n\tv301 = *([v297 @ X0_v16+E0]);\n\tv302 = v301 == 0;\n\tv303 = ~v302;\n\tif (v303) goto L_0076;\n\tv305 = \"il2cpp_codegen_runtime_class_init\"(v297, v291, v293, v84, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_0076:\n\t// 118 MakeStruct v61 @ AGGC3BEE0_0_v4 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), v41 @ V0, v42 @ V1, v43 @ V2, v44 @ V3\n\tv69 = UnityEngine.Vector4::op_Implicit(v61);\n\tObi.ObiActor::TeleportParticle(v82, v52.m_ActiveParticleCount, v69);\n\tv138 = Obi.ObiActor::ActivateParticle(this.rope, v52.m_ActiveParticleCount);\n\tv151 = this.rope;\n\tv152 = v151.solverIndices;\n\tv312 = v52.m_ActiveParticleCount < v152.Length;\n\tv226 = ~v312;\n\tif (v226) goto L_00A7;\n\treturn v152[v154 @ X20_v5 (System.Int32)];\n\tv195 = new System.NullReferenceException();\nL_00A7:\n\tv235 = new System.IndexOutOfRangeException();\n\tthrow v235;\n\treturn returnVal1;\n// 125 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private int AddParticleAt(int index)
		{
			//IL_015c: Expected F4, but got O
			//IL_0169: Expected F4, but got O
			//IL_0176: Expected F4, but got O
			//IL_0183: Expected F4, but got O
			ObiRope obiRope = rope;
			int activeParticleCount = obiRope.activeParticleCount;
			ObiSolver.ParticleInActor[] particleToActor = obiRope.solver.particleToActor;
			int sourceIndex = m_SourceIndex;
			if (m_SourceIndex < particleToActor.Length)
			{
				ObiSolver.ParticleInActor particleInActor = particleToActor[sourceIndex];
				obiRope.CopyParticle(particleInActor.indexInActor, obiRope.activeParticleCount);
				ObiActor obiActor = rope;
				ObiNativeVector4List positions = obiActor.solver.positions;
				ObiRope obiRope2 = rope;
				int[] solverIndices = obiRope2.solverIndices;
				bool flag = solverIndices.Length < index;
				bool flag2 = !flag;
				int num = solverIndices.Length - index;
				bool flag3 = num == 0;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					Vector4 vector = positions.get_Item(solverIndices[index]);
					Vector4 vector2 = default(Vector4);
					object obj = default(object);
					vector2.x = (float)obj;
					object obj2 = default(object);
					vector2.y = (float)obj2;
					object obj3 = default(object);
					vector2.z = (float)obj3;
					object obj4 = default(object);
					vector2.w = (float)obj4;
					Vector3 position = vector2;
					obiActor.TeleportParticle(obiRope.activeParticleCount, position);
					bool flag5 = rope.ActivateParticle(obiRope.activeParticleCount);
					ObiRope obiRope3 = rope;
					int[] solverIndices2 = obiRope3.solverIndices;
					if (obiRope.activeParticleCount < solverIndices2.Length)
					{
						return solverIndices2[activeParticleCount];
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000445")]
		[Address(RVA = "0xC3BF5C", Offset = "0xC3BF5C", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = Obi.ObiActor::DeactivateParticle(this.rope, index);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void RemoveParticleAt(int index)
		{
			bool flag = rope.DeactivateParticle(index);
		}

		[Token(Token = "0x6000446")]
		[Address(RVA = "0xC3BF78", Offset = "0xC3BF78", Length = "0x6C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv36 = *([1F0C058]);\n\tv37 = *([v36 @ X8_v15]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, methodInfo, v40, v41, v42, v43, v44, v45, newLength, v46, v47, v48, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([20231DE]) = v55;\nL_0022:\n\tv61 = Obi.ObiRope::get_blueprint(this.rope);\n\tv112 = Obi.ObiActorBlueprint::get_particleCount(v61);\n\tv114 = this.rope;\n\tv115 = this.rope == 0;\n\tif (v115) goto L_02A3;\n\tv120 = v114.m_RopeBlueprint == 0;\n\tif (v120) goto L_02A3;\n\tv128 = 0xC3FC28(v112, 0, v40, v41, v42, v43, v44, v45, newLength, v46, v47, v48, v49, v50, v51, v52);\n\treturn;\n\tX9 = *([X0+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_003C;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_003C;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_003C:\n\tX8 = X20 - 1;\n\tV0 = X8;\n\tV2 = V9 * V0;\n\tV1 = 0;\n\tV0 = V8;\n\tX0 = 0;\n\tV0 = UnityEngine.Mathf::Clamp(V0, V1, V2, X0);\n\tX8 = *([X19+18]);\n\tif (TEMP) goto L_02A3;\n\tV1 = *([X8+84]);\n\tV8 = V0 - V1;\n\tC = V8 < 0;\n\tC = ~C;\n\tTEMP1 = V8 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = V8 ^ 0;\n\tTEMP3 = V8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~N;\n\tif (TEMPCOND) goto L_01B6;\n\tX20 = *([X19+30]);\n\tif (TEMP) goto L_02A3;\n\tX21 = *([1ED0BB0]);\n\tX23 = *([1EC5AB0]);\n\tV8 = -V8;\nL_005B:\n\tV9 = *([X20+18]);\n\tC = V8 < V9;\n\tC = ~C;\n\tTEMP1 = V8 - V9;\n\tN = TEMP1 < 0;\n\tTEMP2 = V8 ^ V9;\n\tTEMP3 = V8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_02A4;\n\tX8 = *([X19+18]);\n\tif (TEMP) goto L_02A3;\n\tX0 = *([X8+88]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX2 = *([X21]);\n\tX1 = X20;\n\tX0 = System.Collections.Generic.List`1<Obi.ObiActor>::IndexOf /* +4 sharing this address */(X0, X1, X2);\n\tX20 = X0;\n\tTEMP = X20 & 0x80000000;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0114;\n\tX8 = *([X19+18]);\n\tif (TEMP) goto L_02A3;\n\tX0 = *([X8+48]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX24 = *([X19+28]);\n\tX1 = 0;\n\tX0 = Obi.ObiSolver::get_particleToActor(X0, X1);\n\tX8 = *([X19+30]);\n\tif (TEMP) goto L_02A3;\n\tif (TEMP) goto L_0116;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([X8+14]);\n\tX9 = *([X0+18]);\n\tC = X8 < X9;\n\tC = ~C;\n\tTEMP1 = X8 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X9;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_02E9;\n\tTEMPSHIFT = X8 << 3;\n\tX8 = X0 + TEMPSHIFT;\n\tX8 = *([X8+20]);\n\tif (TEMP) goto L_02A3;\n\tX1 = *([X8+18]);\n\tX0 = X19;\n\tObi.ObiRopeCursor::RemoveParticleAt(X0, X1, X2);\n\tX8 = *([X19+18]);\n\tif (TEMP) goto L_02A3;\n\tX0 = *([X8+88]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX2 = *([X23]);\n\tX1 = X20;\n\tSystem.Collections.Generic.List`1::RemoveAt /* +16 sharing this address */(X0, X1, X2);\n\tX8 = *([X19+18]);\n\tif (TEMP) goto L_02A3;\n\tX24 = *([X8+88]);\n\tif (TEMP) goto L_02A3;\n\tX8 = *([X24+18]);\n\tC = X20 < X8;\n\tC = ~C;\n\tTEMP1 = X20 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X20 ^ X8;\n\tTEMP3 = X20 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tif (TEMPCOND) goto L_00FB;\n\tC = X8 < X20;\n\tC = ~C;\n\tTEMP1 = X8 - X20;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X20;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tTEMPCOND = C & TEMPCOND;\n\tif (TEMPCOND) goto L_00C4;\n\tX0 = 0;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException(X0);\nL_00C4:\n\tX8 = *([X24+10]);\n\tTEMPSHIFT = X20 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX9 = *([X8+20]);\n\tif (TEMP) goto L_02A3;\n\tX8 = *([X19+30]);\n\tif (TEMP) goto L_02A3;\n\tX9 = *([X9+10]);\n\tX10 = *([X8+14]);\n\tC = X9 < X10;\n\tC = ~C;\n\tTEMP1 = X9 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X10;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_00FB;\n\tX9 = *([X19+18]);\n\tif (TEMP) goto L_02A3;\n\tX24 = *([X9+88]);\n\tif (TEMP) goto L_02A3;\n\tX9 = *([X24+18]);\n\tC = X9 < X20;\n\tC = ~C;\n\tTEMP1 = X9 - X20;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X20;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tTEMPCOND = C & TEMPCOND;\n\tif (TEMPCOND) goto L_00F2;\n\tX0 = 0;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException(X0);\n\tX8 = *([X19+30]);\n\tif (TEMP) goto L_02A3;\nL_00F2:\n\tX9 = *([X24+10]);\n\tX10 = X20;\n\tTEMPSHIFT = X10 << 3;\n\tX9 = X9 + TEMPSHIFT;\n\tX9 = *([X9+20]);\n\tif (TEMP) goto L_02A3;\n\tX8 = *([X8+10]);\n\t*([X9+10]) = X8;\nL_00FB:\n\tX8 = *([X19+18]);\n\tif (TEMP) goto L_02A3;\n\tX24 = *([X8+88]);\n\tif (TEMP) goto L_02A3;\n\tX8 = *([X24+18]);\n\tC = X8 < X20;\n\tC = ~C;\n\tTEMP1 = X8 - X20;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X20;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tTEMPCOND = C & TEMPCOND;\n\tif (TEMPCOND) goto L_0110;\n\tX0 = 0;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException(X0);\nL_0110:\n\tX8 = *([X24+10]);\n\tTEMPSHIFT = X20 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tgoto L_01AE;\nL_0114:\n\tX20 = *([X19+30]);\n\tgoto L_01B1;\nL_0116:\n\tTEMP = X0 == 0;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([X8+10]);\n\tX9 = *([X0+18]);\n\tC = X8 < X9;\n\tC = ~C;\n\tTEMP1 = X8 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X9;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_02E9;\n\tTEMPSHIFT = X8 << 3;\n\tX8 = X0 + TEMPSHIFT;\n\tX8 = *([X8+20]);\n\tif (TEMP) goto L_02A3;\n\tX1 = *([X8+18]);\n\tX0 = X19;\n\tObi.ObiRopeCursor::RemoveParticleAt(X0, X1, X2);\n\tX8 = *([X19+18]);\n\tif (TEMP) goto L_02A3;\n\tX0 = *([X8+88]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX2 = *([X23]);\n\tX1 = X20;\n\tSystem.Collections.Generic.List`1::RemoveAt /* +16 sharing this address */(X0, X1, X2);\n\tX8 = *([X19+18]);\n\tif (TEMP) goto L_02A3;\n\tX24 = *([X8+88]);\n\tif (TEMP) goto L_02A3;\n\tC = X20 < 1;\n\tC = ~C;\n\tTEMP1 = X20 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X20 ^ 1;\n\tTEMP3 = X20 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX20 = X20 - 1;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_01A7;\n\tX8 = *([X24+18]);\n\tC = X8 < X20;\n\tC = ~C;\n\tTEMP1 = X8 - X20;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X20;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tTEMPCOND = C & TEMPCOND;\n\tif (TEMPCOND) goto L_0157;\n\tX0 = 0;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException(X0);\nL_0157:\n\tX8 = *([X24+10]);\n\tTEMPSHIFT = X20 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX9 = *([X8+20]);\n\tif (TEMP) goto L_02A3;\n\tX8 = *([X19+30]);\n\tif (TEMP) goto L_02A3;\n\tX9 = *([X9+14]);\n\tX10 = *([X8+10]);\n\tX24 = X20;\n\tC = X9 < X10;\n\tC = ~C;\n\tTEMP1 = X9 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X10;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_018E;\n\tX9 = *([X19+18]);\n\tif (TEMP) goto L_02A3;\n\tX25 = *([X9+88]);\n\tif (TEMP) goto L_02A3;\n\tX9 = *([X25+18]);\n\tC = X9 < X20;\n\tC = ~C;\n\tTEMP1 = X9 - X20;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X20;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tTEMPCOND = C & TEMPCOND;\n\tif (TEMPCOND) goto L_0186;\n\tX0 = 0;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException(X0);\n\tX8 = *([X19+30]);\n\tif (TEMP) goto L_02A3;\nL_0186:\n\tX9 = *([X25+10]);\n\tTEMPSHIFT = X24 << 3;\n\tX9 = X9 + TEMPSHIFT;\n\tX9 = *([X9+20]);\n\tif (TEMP) goto L_02A3;\n\tX8 = *([X8+14]);\n\t*([X9+14]) = X8;\nL_018E:\n\tX8 = *([X19+18]);\n\tif (TEMP) goto L_02A3;\n\tX25 = *([X8+88]);\n\tif (TEMP) goto L_02A3;\n\tX8 = *([X25+18]);\n\tC = X8 < X20;\n\tC = ~C;\n\tTEMP1 = X8 - X20;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X20;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tTEMPCOND = C & TEMPCOND;\n\tif (TEMPCOND) goto L_01A3;\n\tX0 = 0;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException(X0);\nL_01A3:\n\tX8 = *([X25+10]);\n\tTEMPSHIFT = X24 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tgoto L_01AE;\nL_01A7:\n\tX8 = *([X24+18]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_01AD;\n\tX0 = 0;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException(X0);\nL_01AD:\n\tX8 = *([X24+10]);\nL_01AE:\n\tX8 = X8 + 0x20;\n\tX20 = *([X8]);\n\t*([X19+30]) = X20;\nL_01B1:\n\tV8 = V8 - V9;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_005B;\n\tgoto L_02A3;\nL_01B6:\n\tX8 = *([X8+98]);\n\tif (TEMP) goto L_02A3;\n\tX9 = *([X19+30]);\n\tif (TEMP) goto L_02A3;\n\tX0 = *([X22]);\n\tV9 = *([X8+110]);\n\tV10 = *([X9+18]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_01C8;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_01C8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_01C8:\n\tV1 = V9 - V10;\n\tV0 = 0;\n\tX0 = 0;\n\tV0 = UnityEngine.Mathf::Max(V0, V1, X0);\n\tV1 = V0;\n\tV0 = V8;\n\tX0 = 0;\n\tV0 = UnityE\n// ... truncated")]
		public void ChangeLength(float newLength)
		{
			ObiActorBlueprint blueprint = rope.blueprint;
			int particleCount = blueprint.particleCount;
			ObiRope obiRope = rope;
			if ((object)rope != null && (object)obiRope.ropeBlueprint != null)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @C3FC28 (inside Obi.ObiRopeMeshRenderer::.cctor +0x74)");
				return;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x6000447")]
		[Address(RVA = "0xC3C638", Offset = "0xC3C638", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.rope;\n\tv17 = UnityEngine.Input::GetKey(0x65);\n\tv36 = v17 == 0;\n\tif (v36) goto L_001A;\n\tv38 = UnityEngine.Time::get_deltaTime();\n\tv69 = v38 * 0.5f;\n\tv42 = v12.restLength_ + v69;\n\tObi.ObiRopeCursor::ChangeLength(this, v42);\nL_001A:\n\tv47 = UnityEngine.Input::GetKey(0x72);\n\tv62 = v47 == 0;\n\tif (v62) goto L_0030;\n\tv72 = UnityEngine.Time::get_deltaTime();\n\tv73 = v72 * -0.25f;\n\tv54 = v12.restLength_ + v73;\n\tObi.ObiRopeCursor::ChangeLength(this, v54);\n\treturn;\nL_0030:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Update()
		{
			ObiRope obiRope = rope;
			if (Input.GetKey(KeyCode.E))
			{
				float deltaTime = Time.deltaTime;
				float num = deltaTime * 0.5f;
				float newLength = obiRope.restLength + num;
				ChangeLength(newLength);
			}
			if (Input.GetKey(KeyCode.R))
			{
				float deltaTime2 = Time.deltaTime;
				float num2 = deltaTime2 * -0.25f;
				float newLength2 = obiRope.restLength + num2;
				ChangeLength(newLength2);
			}
		}

		[Token(Token = "0x6000448")]
		[Address(RVA = "0xC3C6D4", Offset = "0xC3C6D4", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.direction = 1;\n\tthis.m_SourceIndex = 0xFFFFFFFF;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiRopeCursor()
		{
			direction = true;
			m_SourceIndex = -1;
		}
	}
}
