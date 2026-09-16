using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x744A20", Offset = "0x744A20")]
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x744A20", Offset = "0x744A20")]
	[Token(Token = "0x2000055")]
	public class ObiParticleAttachment : MonoBehaviour
	{
		[Token(Token = "0x20000BC")]
		public enum AttachmentType
		{
			[Token(Token = "0x400030D")]
			Static = 0,
			[Token(Token = "0x400030E")]
			Dynamic = 1
		}

		[SerializeField]
		[HideInInspector]
		[Token(Token = "0x400017C")]
		[FieldOffset(Offset = "0x18")]
		private ObiActor m_Actor;

		[SerializeField]
		[HideInInspector]
		[Token(Token = "0x400017D")]
		[FieldOffset(Offset = "0x20")]
		private Transform m_Target;

		[SerializeField]
		[HideInInspector]
		[Token(Token = "0x400017E")]
		[FieldOffset(Offset = "0x28")]
		private ObiParticleGroup m_ParticleGroup;

		[SerializeField]
		[HideInInspector]
		[Token(Token = "0x400017F")]
		[FieldOffset(Offset = "0x30")]
		private AttachmentType m_AttachmentType;

		[SerializeField]
		[HideInInspector]
		[Token(Token = "0x4000180")]
		[FieldOffset(Offset = "0x34")]
		private bool m_ConstrainOrientation;

		[SerializeField]
		[HideInInspector]
		[Token(Token = "0x4000181")]
		[FieldOffset(Offset = "0x38")]
		private float m_Compliance;

		[Delayed]
		[SerializeField]
		[HideInInspector]
		[Token(Token = "0x4000182")]
		[FieldOffset(Offset = "0x3C")]
		private float m_BreakThreshold;

		[SerializeField]
		[HideInInspector]
		[Token(Token = "0x4000183")]
		[FieldOffset(Offset = "0x40")]
		private int[] m_SolverIndices;

		[SerializeField]
		[HideInInspector]
		[Token(Token = "0x4000184")]
		[FieldOffset(Offset = "0x48")]
		private Vector3[] m_PositionOffsets;

		[SerializeField]
		[HideInInspector]
		[Token(Token = "0x4000185")]
		[FieldOffset(Offset = "0x50")]
		private Quaternion[] m_OrientationOffsets;

		[Token(Token = "0x4000186")]
		[FieldOffset(Offset = "0x58")]
		private ObiPinConstraintsBatch pinBatch;

		[Token(Token = "0x1700008A")]
		public ObiActor actor
		{
			[Token(Token = "0x600038E")]
			[Address(RVA = "0xC273AC", Offset = "0xC273AC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_Actor;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return actor;
			}
		}

		[Token(Token = "0x1700008B")]
		public Transform target
		{
			[Token(Token = "0x600038F")]
			[Address(RVA = "0xC273B4", Offset = "0xC273B4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_Target;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return target;
			}
			[Token(Token = "0x6000390")]
			[Address(RVA = "0xC273BC", Offset = "0xC273BC", Length = "0xAC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1ECDA10]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023135]) = v41;\nL_001C:\n\tgoto L_0025;\n\tv49 = *([v45 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0025;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0025:\n\tv59 = UnityEngine.Object::op_Inequality(value, this.m_Target);\n\tv61 = v59 == 0;\n\tif (v61) goto L_003D;\n\tObi.ObiParticleAttachment::Disable(this, this.m_Target);\n\tObi.ObiParticleAttachment::Bind(this);\n\tthis.m_Target = value;\n\tObi.ObiParticleAttachment::UpdateEnabledState(this);\n\treturn;\nL_003D:\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0041: Expected I4, but got O
				if (value != target)
				{
					Disable((AttachmentType)target);
					Bind();
					m_Target = value;
					UpdateEnabledState();
				}
			}
		}

		[Token(Token = "0x1700008C")]
		public ObiParticleGroup particleGroup
		{
			[Token(Token = "0x6000391")]
			[Address(RVA = "0xC27E60", Offset = "0xC27E60", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_ParticleGroup;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return particleGroup;
			}
			[Token(Token = "0x6000392")]
			[Address(RVA = "0xC27E68", Offset = "0xC27E68", Length = "0xAC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1F08FE0]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023136]) = v41;\nL_001C:\n\tgoto L_0025;\n\tv49 = *([v45 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0025;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0025:\n\tv59 = UnityEngine.Object::op_Inequality(value, this.m_ParticleGroup);\n\tv61 = v59 == 0;\n\tif (v61) goto L_003D;\n\tObi.ObiParticleAttachment::Disable(this, this.m_ParticleGroup);\n\tObi.ObiParticleAttachment::Bind(this);\n\tthis.m_ParticleGroup = value;\n\tObi.ObiParticleAttachment::UpdateEnabledState(this);\n\treturn;\nL_003D:\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0041: Expected I4, but got O
				if (value != particleGroup)
				{
					Disable((AttachmentType)particleGroup);
					Bind();
					m_ParticleGroup = value;
					UpdateEnabledState();
				}
			}
		}

		[Token(Token = "0x1700008D")]
		public bool isBound
		{
			[Token(Token = "0x6000393")]
			[Address(RVA = "0xC27F14", Offset = "0xC27F14", Length = "0x94")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EABC10]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023137]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Inequality(this.m_Target, 0);\n\tv58 = v56 == 0;\n\tif (v58) goto L_FFFFFFFF;\n\tv60 = this.m_SolverIndices == 0;\n\tif (v60) goto L_FFFFFFFF;\n\tv69 = this.m_PositionOffsets == 0;\n\tv74 = ~v69;\n\tgoto L_003D;\nL_003D:\n\treturn returnVal1;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (target != null && m_SolverIndices != null)
				{
					bool flag = m_PositionOffsets == null;
					return !flag;
				}
				return false;
			}
		}

		[Token(Token = "0x1700008E")]
		public AttachmentType attachmentType
		{
			[Token(Token = "0x6000394")]
			[Address(RVA = "0xC27FA8", Offset = "0xC27FA8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_AttachmentType;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return attachmentType;
			}
			[Token(Token = "0x6000395")]
			[Address(RVA = "0xC27FB0", Offset = "0xC27FB0", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = this.m_AttachmentType != value;\n\tif (v24) goto L_001B;\n\treturn;\nL_001B:\n\tObi.ObiParticleAttachment::Disable(this, value);\n\tthis.m_AttachmentType = value;\n\tObi.ObiParticleAttachment::UpdateEnabledState(this);\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				if (attachmentType != value)
				{
					Disable(value);
					m_AttachmentType = value;
					UpdateEnabledState();
				}
			}
		}

		[Token(Token = "0x1700008F")]
		public bool constrainOrientation
		{
			[Token(Token = "0x6000396")]
			[Address(RVA = "0xC27FF8", Offset = "0xC27FF8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_ConstrainOrientation;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return constrainOrientation;
			}
			[Token(Token = "0x6000397")]
			[Address(RVA = "0xC28000", Offset = "0xC28000", Length = "0x54")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = this.m_ConstrainOrientation == 0;\n\tv24 = ~v19;\n\tv26 = v24 ^ value;\n\tv28 = v26 == 0;\n\tif (v28) goto L_0029;\n\tObi.ObiParticleAttachment::Disable(this, value);\n\tthis.m_ConstrainOrientation = value;\n\tObi.ObiParticleAttachment::UpdateEnabledState(this);\n\treturn;\nL_0029:\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				bool flag = !constrainOrientation;
				bool flag2 = !flag;
				if (flag2 ^ value)
				{
					Disable(value ? AttachmentType.Dynamic : AttachmentType.Static);
					m_ConstrainOrientation = value;
					UpdateEnabledState();
				}
			}
		}

		[Token(Token = "0x17000090")]
		public float compliance
		{
			[Token(Token = "0x6000398")]
			[Address(RVA = "0xC28054", Offset = "0xC28054", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_Compliance;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return compliance;
			}
			[Token(Token = "0x6000399")]
			[Address(RVA = "0xC2805C", Offset = "0xC2805C", Length = "0xFC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv26 = *([1F08E88]);\n\tv27 = *([v26 @ X8_v20]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, value, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2023138]) = v45;\nL_001E:\n\tgoto L_0027;\n\tv53 = *([v49 @ X0_v2+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_0027;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v49, methodInfo, v30, v31, v32, v33, v34, v35, value, v36, v37, v38, v39, v40, v41, v42);\nL_0027:\n\tv63 = UnityEngine.Mathf::Approximately(value, this.m_Compliance);\n\tv65 = v63 == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_0069;\n\tthis.m_Compliance = value;\n\tv77 = this.m_AttachmentType != 1;\n\tif (v77) goto L_0069;\n\tv135 = this.pinBatch == 0;\n\tif (v135) goto L_0069;\n\tv193 = this.m_SolverIndices;\nL_0042:\n\tv194 = v194 + 1;\n\tv94 = v194 >= v193.Length;\n\tif (v94) goto L_0069;\n\tv181 = this.pinBatch;\n\tv160 = v90 + 2;\n\tv175 = Obi.ObiNativeFloatList::set_Item(v181.stiffnesses, v90, this.m_Compliance);\n\tv193 = this.m_SolverIndices;\n\tv200 = this.m_SolverIndices == 0;\n\tv177 = ~v200;\n\tif (v177) goto L_0042;\n\tthrow System.NullReferenceException;\nL_0069:\n\treturn;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_00b0: Expected O, but got I8
				//IL_0141: Expected O, but got I
				if (Mathf.Approximately(value, compliance))
				{
					return;
				}
				m_Compliance = value;
				if (attachmentType != AttachmentType.Dynamic || pinBatch == null)
				{
					return;
				}
				int[] solverIndices = m_SolverIndices;
				int num = 0;
				object obj = 4294967295L;
				bool flag2;
				do
				{
					obj = (long)(IntPtr)obj + 1L;
					if ((long)(IntPtr)obj < (long)solverIndices.Length)
					{
						ObiPinConstraintsBatch obiPinConstraintsBatch = pinBatch;
						int num2 = num + 2;
						obiPinConstraintsBatch.stiffnesses.set_Item(num, compliance);
						solverIndices = m_SolverIndices;
						bool flag = m_SolverIndices == null;
						flag2 = !flag;
						num = num2;
						continue;
					}
					return;
				}
				while (flag2);
				throw new NullReferenceException();
			}
		}

		[Token(Token = "0x17000091")]
		public float breakThreshold
		{
			[Token(Token = "0x600039A")]
			[Address(RVA = "0xC28158", Offset = "0xC28158", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_BreakThreshold;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return breakThreshold;
			}
			[Token(Token = "0x600039B")]
			[Address(RVA = "0xC28160", Offset = "0xC28160", Length = "0xEC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv24 = *([1EA9070]);\n\tv25 = *([v24 @ X8_v20]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, value, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2023139]) = v43;\nL_001D:\n\tgoto L_0026;\n\tv51 = *([v47 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0026;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, value, v34, v35, v36, v37, v38, v39, v40);\nL_0026:\n\tv61 = UnityEngine.Mathf::Approximately(value, this.m_BreakThreshold);\n\tv63 = v61 == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_0065;\n\tthis.m_BreakThreshold = value;\n\tv75 = this.m_AttachmentType != 1;\n\tif (v75) goto L_0065;\n\tv130 = this.pinBatch == 0;\n\tif (v130) goto L_0065;\n\tv185 = this.m_SolverIndices;\nL_0049:\n\tv89 = v138 >= v185.Length;\n\tif (v89) goto L_0065;\n\tv172 = this.pinBatch;\n\tv166 = Obi.ObiNativeFloatList::set_Item(v172.breakThresholds, v138, this.m_BreakThreshold);\n\tv185 = this.m_SolverIndices;\n\tv138 = v138 + 1;\n\tv191 = this.m_SolverIndices == 0;\n\tv168 = ~v191;\n\tif (v168) goto L_0049;\n\tthrow System.NullReferenceException;\nL_0065:\n\treturn;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				if (Mathf.Approximately(value, breakThreshold))
				{
					return;
				}
				m_BreakThreshold = value;
				if (attachmentType != AttachmentType.Dynamic || pinBatch == null)
				{
					return;
				}
				int[] solverIndices = m_SolverIndices;
				int num = 0;
				do
				{
					if (num < solverIndices.Length)
					{
						ObiPinConstraintsBatch obiPinConstraintsBatch = pinBatch;
						obiPinConstraintsBatch.breakThresholds.set_Item(num, breakThreshold);
						solverIndices = m_SolverIndices;
						num++;
						continue;
					}
					return;
				}
				while (m_SolverIndices != null);
				throw new NullReferenceException();
			}
		}

		[Token(Token = "0x600039C")]
		[Address(RVA = "0xC2824C", Offset = "0xC2824C", Length = "0x16C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EAAF10]);\n\tv21 = *([v20 @ X8_v21]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202313A]) = v40;\nL_0018:\n\tv45 = UnityEngine.Component::GetComponent(this);\n\tthis.m_Actor = v45;\n\tv50 = new Obi.ObiActor+ActorBlueprintCallback();\n\tObi.ObiActor+ActorBlueprintCallback::.ctor(v50, this, Il2CppMethodInfo);\n\tObi.ObiActor::add_OnBlueprintLoaded(v45, v50);\n\tv72 = new Obi.ObiActor+ActorStepCallback();\n\tObi.ObiActor+ActorStepCallback::.ctor(v72, this, Il2CppMethodInfo);\n\tObi.ObiActor::add_OnSubstep(this.m_Actor, v72);\n\tv79 = this.m_Actor;\n\tgoto L_0051;\n\tv138 = *([v135 @ X0_v14+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0051;\n\tv142 = \"il2cpp_codegen_runtime_class_init\"(v135, v70, v63, v67, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0051:\n\tv119 = UnityEngine.Object::op_Inequality(v79.m_Solver, 0);\n\tv121 = v119 == 0;\n\tif (v121) goto L_006F;\n\tv96 = this.m_Actor;\n\tv146 = Obi.ObiActor::get_blueprint(v96);\n\tObi.ObiParticleAttachment::Bind(this);\n\tObi.ObiParticleAttachment::UpdateEnabledState(this);\n\tObi.ObiParticleAttachment::UpdateAttachment(this);\n\treturn;\nL_006F:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			ObiActor obiActor = (m_Actor = GetComponent<ObiActor>());
			ObiActor.ActorBlueprintCallback value = Actor_OnBlueprintLoaded;
			obiActor.OnBlueprintLoaded += value;
			ObiActor.ActorStepCallback value2 = Actor_OnSolverStep;
			actor.OnSubstep += value2;
			ObiActor obiActor2 = actor;
			if (obiActor2.solver != null)
			{
				ObiActor obiActor3 = actor;
				ObiActorBlueprint blueprint = obiActor3.blueprint;
				Bind();
				UpdateEnabledState();
				UpdateAttachment();
			}
		}

		[Token(Token = "0x600039D")]
		[Address(RVA = "0xC283E4", Offset = "0xC283E4", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1ED6E50]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202313B]) = v40;\nL_0018:\n\tv45 = new Obi.ObiActor+ActorBlueprintCallback();\n\tObi.ObiActor+ActorBlueprintCallback::.ctor(v45, this, Il2CppMethodInfo);\n\tObi.ObiActor::remove_OnBlueprintLoaded(this.m_Actor, v45);\n\tv65 = new Obi.ObiActor+ActorStepCallback();\n\tObi.ObiActor+ActorStepCallback::.ctor(v65, this, Il2CppMethodInfo);\n\tObi.ObiActor::remove_OnSubstep(this.m_Actor, v65);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDestroy()
		{
			ObiActor.ActorBlueprintCallback value = Actor_OnBlueprintLoaded;
			actor.OnBlueprintLoaded -= value;
			ObiActor.ActorStepCallback value2 = Actor_OnSolverStep;
			actor.OnSubstep -= value2;
		}

		[Token(Token = "0x600039E")]
		[Address(RVA = "0xC284B8", Offset = "0xC284B8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tObi.ObiParticleAttachment::Enable(this, this.m_AttachmentType);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnEnable()
		{
			Enable(attachmentType);
		}

		[Token(Token = "0x600039F")]
		[Address(RVA = "0xC28970", Offset = "0xC28970", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tObi.ObiParticleAttachment::Disable(this, methodInfo);\n\treturn;\n")]
		private void OnDisable()
		{
			IntPtr intPtr = default(IntPtr);
			Disable((AttachmentType)(long)intPtr);
		}

		[Token(Token = "0x60003A0")]
		[Address(RVA = "0xC28974", Offset = "0xC28974", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1F0B648]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202313C]) = v38;\nL_0017:\n\tv43 = UnityEngine.Component::GetComponent(this);\n\tthis.m_Actor = v43;\n\tObi.ObiParticleAttachment::Disable(this, Il2CppMethodInfo);\n\tObi.ObiParticleAttachment::Disable(this, Il2CppMethodInfo);\n\tObi.ObiParticleAttachment::UpdateEnabledState(this);\n\tObi.ObiParticleAttachment::UpdateAttachment(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnValidate()
		{
			ObiActor component = GetComponent<ObiActor>();
			m_Actor = component;
			Disable(AttachmentType.Static);
			Disable(AttachmentType.Static);
			UpdateEnabledState();
			UpdateAttachment();
		}

		[Token(Token = "0x60003A1")]
		[Address(RVA = "0xC28FF0", Offset = "0xC28FF0", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EF1520]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202313D]) = v38;\nL_0017:\n\tv43 = UnityEngine.Component::GetComponent(this);\n\treturnVal1 = Obi.ObiActor::get_usesOrientedParticles(v43);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool ActorUsesOrientedParticles()
		{
			ObiActor component = GetComponent<ObiActor>();
			return component.usesOrientedParticles;
		}

		[Token(Token = "0x60003A2")]
		[Address(RVA = "0xC283B8", Offset = "0xC283B8", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tObi.ObiParticleAttachment::Bind(this);\n\tObi.ObiParticleAttachment::UpdateEnabledState(this);\n\tObi.ObiParticleAttachment::UpdateAttachment(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Actor_OnBlueprintLoaded(ObiActor act, ObiActorBlueprint blueprint)
		{
			Bind();
			UpdateEnabledState();
			UpdateAttachment();
		}

		[Token(Token = "0x60003A3")]
		[Address(RVA = "0xC29050", Offset = "0xC29050", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tObi.ObiParticleAttachment::UpdateAttachment(this);\n\treturn;\n")]
		private void Actor_OnSolverStep(ObiActor act, float stepTime)
		{
			UpdateAttachment();
		}

		[Token(Token = "0x60003A4")]
		[Address(RVA = "0xC2775C", Offset = "0xC2775C", Length = "0x6C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = &v39 @ stack_-10_v2;\n\tgoto L_0026;\n\tv48 = *([1ED4328]);\n\tv49 = *([v48 @ X8_v95]);\n\tv50 = \"il2cpp_codegen_initialize_method\"(v49, methodInfo, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65);\n\tv68 = 0 | 1;\n\t*([202313E]) = v68;\nL_0026:\n\t*([v38 @ X29_v1-B0]) = 0;\n\t*([v38 @ X29_v1-A0]) = 0;\n\t*([v38 @ X29_v1-D0]) = 0;\n\t*([v38 @ X29_v1-C0]) = 0;\n\tv77 = this.m_ParticleGroup;\n\tgoto L_003C;\n\tv81 = *([v72 @ X0_v2+E0]);\n\tv82 = v81 == 0;\n\tv83 = ~v82;\n\tgoto L_003C;\n\tv85 = \"il2cpp_codegen_runtime_class_init\"(v72, methodInfo, v52, v53, v54, v55, v56, v57, v71, v59, v60, v61, v62, v63, v64, v65);\nL_003C:\n\tv91 = UnityEngine.Object::op_Inequality(this.m_ParticleGroup, 0);\n\tv93 = v91 == 0;\n\tif (v93) goto L_00D0;\n\tv94 = this.m_Actor;\n\tgoto L_0051;\n\tv759 = *([v111 @ X0_v18+E0]);\n\tv760 = v759 == 0;\n\tv761 = ~v760;\n\tif (v761) goto L_0051;\n\tv763 = \"il2cpp_codegen_runtime_class_init\"(v111, v89, v90, v53, v54, v55, v56, v57, v71, v59, v60, v61, v62, v63, v64, v65);\nL_0051:\n\tv106 = UnityEngine.Object::op_Inequality(v94.m_Solver, 0);\n\tv108 = v106 == 0;\n\tif (v108) goto L_00D0;\n\tgoto L_0063;\n\tv1298 = *([v1081 @ X0_v22+E0]);\n\tv1299 = v1298 == 0;\n\tv1300 = ~v1299;\n\tif (v1300) goto L_0063;\n\tv1302 = \"il2cpp_codegen_runtime_class_init\"(v1081, v104, v102, v53, v54, v55, v56, v57, v71, v59, v60, v61, v62, v63, v64, v65);\nL_0063:\n\tv1305 = UnityEngine.Object::op_Inequality(this.m_Target, 0);\n\tv1328 = v1305 == 0;\n\tif (v1328) goto L_00EF;\n\tv1335 = &v1346 @ stack_-160_v8 (System.Single);\n\tv526 = UnityEngine.Transform::get_worldToLocalMatrix(this.m_Target);\n\tv1346 = *([v1335 @ X8_v82]);\n\tv551 = this.m_Actor;\n\tv893 = UnityEngine.Component::get_transform(v551.m_Solver);\n\tv1428 = &v431 @ stack_-1A0;\n\tv1430 = UnityEngine.Transform::get_localToWorldMatrix(v893);\n\tv431 = *([v1428 @ X8_v84]);\n\tgoto L_00BA;\n\tv1446 = *([v1436 @ X0_v111+E0]);\n\tv1447 = v1446 == 0;\n\tv1448 = ~v1447;\n\tif (v1448) goto L_00BA;\n\tv1450 = \"il2cpp_codegen_runtime_class_init\"(v1436, v1429, v509, v53, v54, v55, v56, v57, v71, v59, v60, v61, v62, v63, v64, v65);\nL_00BA:\n\tv1416 = UnityEngine.Matrix4x4::op_Multiply(&v1346 @ stack_-160_v8 (System.Single), &v431 @ stack_-1A0);\n\tgoto L_0114;\nL_00D0:\n\tthis.m_PositionOffsets = 0;\n\tthis.m_OrientationOffsets = 0;\n\tthis.m_SolverIndices = 0;\nL_00E8:\n\treturn;\nL_00EF:\n\tgoto L_00F7;\n\tv1336 = *([v1331 @ X0_v101+E0]);\n\tv1337 = v1336 == 0;\n\tv1338 = ~v1337;\n\tif (v1338) goto L_00F7;\n\tv1340 = \"il2cpp_codegen_runtime_class_init\"(v1331, v885, v509, v53, v54, v55, v56, v57, v71, v59, v60, v61, v62, v63, v64, v65);\nL_00F7:\n\tv1345 = UnityEngine.Matrix4x4::get_identity();\nL_0114:\n\t*([v38 @ X29_v1-B0]) = v678;\n\t*([v38 @ X29_v1-A0]) = v1394;\n\t*([v38 @ X29_v1-D0]) = v369;\n\t*([v38 @ X29_v1-C0]) = v672;\n\tv1421 = Obi.ObiParticleGroup::get_Count(this.m_ParticleGroup);\n\t// 289 NewArr v1427 @ X0_v30 (System.Int32[]), typeof(System.Int32[]), v1421 @ X0_v28 (System.Int32)\n\tthis.m_SolverIndices = v1427;\n\tv1433 = Obi.ObiParticleGroup::get_Count(this.m_ParticleGroup);\n\t// 300 NewArr v1445 @ X0_v34 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), v1433 @ X0_v32 (System.Int32)\n\tthis.m_PositionOffsets = v1445;\n\tv1462 = Obi.ObiParticleGroup::get_Count(this.m_ParticleGroup);\n\t// 309 NewArr v527 @ X0_v38 (UnityEngine.Quaternion[]), typeof(UnityEngine.Quaternion[]), v1462 @ X0_v36 (System.Int32)\n\tv552 = this.m_Actor;\n\tthis.m_OrientationOffsets = v527;\n\tv1471 = Obi.ObiActor::get_blueprint(v552);\n\tv1473 = Obi.ObiParticleGroup::get_Count(this.m_ParticleGroup);\n\tv1484 = v1473 < 1;\n\tif (v1484) goto L_01F7;\nL_0151:\n\tv180 = *([v77 @ X20_v2 (UnityEngine.Object)+18]);\n\tv1505 = *([v180 @ X25_v12+18]) < v506;\n\tv276 = ~v1505;\n\tv267 = *([v180 @ X25_v12+18]) - v506;\n\tv249 = v267 == 0;\n\tv1506 = ~v249;\n\tv207 = v276 & v1506;\n\tif (v207) goto L_0163;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0163:\n\tv554 = this.m_Actor;\n\tv555 = v554.solverIndices;\n\tv192 = v506 << 2;\n\tv1513 = *([v180 @ X25_v12+10]) + v192;\n\tv499 = *([v1513 @ X9_v16+20]);\n\tv208 = *([v1513 @ X9_v16+20]) >= v555.Length;\n\tif (v208) goto L_0278;\n\tv285 = this.m_SolverIndices;\n\tv285[v506 @ X21_v16 (System.Int32)] = v555[v499 @ X9_v17];\n\tv556 = this.m_Actor;\n\tv530 = Obi.ObiSolver::get_positions(v556.m_Solver);\n\tv557 = this.m_SolverIndices;\n\tv501 = *([v530 @ X0_v90 (Obi.ObiNativeVector4List)]);\n\tv719 = *([v501 @ X9_v23 (Il2CppClass<Obi.ObiNativeVector4List>)+188]);\n\tv1570 = Obi.ObiNativeVector4List::get_Item(v530, v557[v506 @ X21_v16 (System.Int32)]);\n\tgoto L_01CB;\n\tv1575 = *([v1571 @ X0_v92+E0]);\n\tv1576 = v1575 == 0;\n\tv1577 = ~v1576;\n\tif (v1577) goto L_01CB;\n\tv1579 = \"il2cpp_codegen_runtime_class_init\"(v1571, v1568, v512, v53, v54, v55, v56, v57, v375, v381, v363, v369, v62, v63, v64, v65);\nL_01CB:\n\t// 459 MakeStruct v157 @ AGGC27B30_0_v9 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), v1394 @ V0_v8 (System.Single), v381 @ V1_v13 (System.Single), v363 @ V2_v13 (System.Single), v369 @ V3_v13 (System.Single)\n\tv376 = UnityEngine.Vector4::op_Implicit(v157);\n\tv678 = v376.y;\n\tv672 = v376.z;\n\tv1588 = &v39 @ stack_-10_v2 - 0xD0;\n\tv531 = 0x10C27FC(v1588, 0, *([v501 @ X9_v23 (Il2CppClass<Obi.ObiNativeVector4List>)+188]), v53, v54, v55, v56, v57, v376, v376.y, v376.z, v369, v62, v63, v64, v65);\n\tv1500 = v506 * 0xC;\n\tv1501 = this.m_PositionOffsets + v1500;\n\t*([v1501 @ X8_v74+20]) = v376;\n\t*([v1501 @ X8_v74+24]) = v376.y;\n\t*([v1501 @ X8_v74+28]) = v376.z;\n\tv506 = v506 + 1;\n\tv1498 = Obi.ObiParticleGroup::get_Count(this.m_ParticleGroup);\n\tv1487 = v506 < v1498;\n\tif (v1487) goto L_0151;\nL_01F7:\n\tv725 = Obi.ObiActor::get_usesOrientedParticles(this.m_Actor);\n\tv730 = v725 == 0;\n\tif (v730) goto L_00E8;\n\tv1509 = &v39 @ stack_-10_v2 - 0xD0;\n\tv1510 = 0x10C1A04(v1509, 0, v719, v53, v54, v55, v56, v57, v676, v678, v672, v369, v62, v63, v64, v65);\n\tv726 = Obi.ObiParticleGroup::get_Count(this.m_ParticleGroup);\n\tv601 = v726 < 1;\n\tif (v601) goto L_00E8;\nL_0213:\n\tv559 = this.m_Actor;\n\tv200 = this.m_OrientationOffsets;\n\tv533 = Obi.ObiSolver::get_orientations(v559.m_Solver);\n\tv560 = this.m_SolverIndices;\n\tv1549 = Obi.ObiNativeQuaternionList::get_Item(v533, v560[v507 @ X21_v13 (System.Int32)]);\n\tgoto L_024B;\n\tv1557 = *([v1550 @ X0_v54+E0]);\n\tv1558 = v1557 == 0;\n\tv1559 = ~v1558;\n\tif (v1559) goto L_024B;\n\tv1561 = \"il2cpp_codegen_runtime_class_init\"(v1550, v523, v514, v53, v54, v55, v56, v57, v377, v383, v365, v371, v140, v137, v134, v131);\nL_024B:\n\t// 587 MakeStruct v129 @ AGGC27C54_0_v8 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v676 @ V0_v10 (UnityEngine.Quaternion), v678 @ V1_v9 (System.Single), v672 @ V2_v9 (System.Single), v369 @ V3_v13 (System.Single)\n\t// 588 MakeStruct v125 @ AGGC27C54_1_v8 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v377 @ V0_v11 (UnityEngine.Quaternion), v383 @ V1_v10 (System.Single), v365 @ V2_v10 (System.Single), v371 @ V3_v10 (System.Single)\n\tv377 = UnityEngine.Quaternion::op_Multiply(v129, v125);\n\tv383 = v377.y;\n\tv365 = v377.z;\n\tv371 = v377.w;\n\tv593 = v507 << 4;\n\tv736 = this.m_OrientationOffsets + v593;\n\t*([v736 @ X8_v36+20]) = v377;\n\tv200[v507 @ X21_v13 (System.Int32)].y = v377.y;\n\tv200[v507 @ X21_v13 (System.Int32)].z = v377.z;\n\tv200[v507 @ X21_v13 (System.Int32)].w = v377.w;\n\tv716 = v507 + 1;\n\tv727 = Obi.ObiParticleGroup::get_Count(this.m_ParticleGroup);\n\tv602 = v716 < v727;\n\tif (v602) goto L_0213;\n\tgoto L_00E8;\nL_0278:\n\t// 632 NewArr v897 @ X0_v63 (System.String[]), typeof(System.String[]), 5\n\tv1527 = \"The particle group '\" == 0;\n\tif (v1527) goto L_028C;\n\t// 643 IsInst v1312 @ X0_v88, typeof(System.String), \"The particle group '\"\n\tv1317 = v1312 == 0;\n\tif (v1317) goto L_0311;\nL_028C:\n\tv897[0] = \"The particle group '\";\n\tv1536 = UnityEngine.Object::get_name(this.m_ParticleGroup);\n\tv1537 = v1536 == 0;\n\tif (v1537) goto L_02A4;\n\t// 660 IsInst v1313 @ X0_v87, typeof(System.String), v1536 @ X0_v67 (System.String)\n\tv1318 = v1313 == 0;\n\tif (v1318) goto L_0311;\nL_02A4:\n\tv897[1] = v1536;\n\tv1546 = \"' references a particle that does not exist in the actor '\" == 0;\n\tif (v1546) goto L_02BD;\n\t// 684 IsInst v1314 @ X0_v85, typeof(System.String), \"' references a particle that does not exist in the actor '\"\n\tv1319 = v1314 == 0;\n\tif (v1319\n// ... truncated")]
		private unsafe void Bind()
		{
			//IL_01d0: Expected O, but got I4
			//IL_00b8: Expected O, but got F4
			//IL_00cf: Expected F4, but got O
			//IL_0124: Expected O, but got Ref
			//IL_0124: Expected O, but got Ref
			//IL_0165: Expected O, but got I4
			//IL_029a: Expected O, but got F4
			//IL_05a3: Expected O, but got I
			//IL_0a61: Expected O, but got I
			//IL_0381: Expected O, but got I
			//IL_0391: Expected O, but got I
			//IL_0728: Expected O, but got I
			//IL_041b: Expected I, but got O
			//IL_042b: Expected O, but got I
			//IL_04b4: Expected O, but got I
			//IL_04e6: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			UnityEngine.Object obj3 = particleGroup;
			if (particleGroup != null)
			{
				ObiActor obiActor = actor;
				if (obiActor.solver != null)
				{
					float num2;
					float m;
					float num3;
					float num4;
					if (target != null)
					{
						float num = default(float);
						object obj4 = num;
						Matrix4x4 worldToLocalMatrix = target.worldToLocalMatrix;
						num = (float)obj4;
						ObiActor obiActor2 = actor;
						Transform transform = obiActor2.solver.transform;
						object obj6 = default(object);
						object obj5 = obj6;
						Matrix4x4 localToWorldMatrix = transform.localToWorldMatrix;
						obj6 = obj5;
						Matrix4x4 matrix4x = (Matrix4x4)(&num) * (Matrix4x4)(&obj6);
						num2 = matrix4x.m01;
						m = matrix4x.m00;
						num3 = matrix4x.m03;
						num4 = matrix4x.m02;
						object obj7 = 0;
					}
					else
					{
						Matrix4x4 identity = Matrix4x4.identity;
						num2 = identity.m01;
						m = identity.m00;
						num3 = identity.m03;
						num4 = identity.m02;
						object obj7 = 0;
					}
					int count = particleGroup.Count;
					int[] solverIndices = new int[count];
					m_SolverIndices = solverIndices;
					int count2 = particleGroup.Count;
					Vector3[] positionOffsets = new Vector3[count2];
					m_PositionOffsets = positionOffsets;
					int count3 = particleGroup.Count;
					Quaternion[] orientationOffsets = new Quaternion[count3];
					ObiActor obiActor3 = actor;
					m_OrientationOffsets = orientationOffsets;
					ObiActorBlueprint blueprint = obiActor3.blueprint;
					int count4 = particleGroup.Count;
					bool flag = count4 < 1;
					Quaternion quaternion = (Quaternion)num3;
					if (!flag)
					{
						float z = num2;
						float y = num4;
						int num5 = 0;
						Vector4 vector2 = default(Vector4);
						bool flag6;
						do
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ X20_v2 (UnityEngine.Object)+18]");
							object obj8 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ X25_v12+18]");
							bool flag2 = 0L < (long)num5;
							bool flag3 = !flag2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ X25_v12+18]");
							int num6 = (int)(-num5);
							bool flag4 = num6 == 0;
							bool flag5 = !flag4;
							if (!(flag3 && flag5))
							{
								throw new ArgumentOutOfRangeException();
							}
							ObiActor obiActor4 = actor;
							int[] solverIndices2 = obiActor4.solverIndices;
							int num7 = num5 << 2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ X25_v12+10]");
							object obj9 = 0L + (long)num7;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1513 @ X9_v16+20]");
							object obj10 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1513 @ X9_v16+20]");
							if (0L < (long)solverIndices2.Length)
							{
								int[] solverIndices3 = m_SolverIndices;
								solverIndices3[num5] = solverIndices2[obj10];
								ObiActor obiActor5 = actor;
								ObiNativeVector4List positions = obiActor5.solver.positions;
								int[] solverIndices4 = m_SolverIndices;
								IntPtr intPtr = (IntPtr)positions;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v501 @ X9_v23 (Il2CppClass<Obi.ObiNativeVector4List>)+188]");
								object obj7 = 0;
								Vector4 vector = positions.get_Item(solverIndices4[num5]);
								vector2.x = num3;
								vector2.y = y;
								vector2.z = z;
								vector2.w = m;
								Vector3 vector3 = vector2;
								num4 = vector3.y;
								num2 = vector3.z;
								object obj11 = (long)(IntPtr)obj2 - 208L;
								Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10C27FC (inside UnityEngine.Matrix4x4::op_Multiply +0x1A8)");
								int num8 = num5 * 12;
								object obj12 = (long)(IntPtr)m_PositionOffsets + (long)num8;
								_ = vector3.y;
								_ = vector3.z;
								num5++;
								int count5 = particleGroup.Count;
								flag6 = num5 < count5;
								quaternion = (Quaternion)vector3;
								z = vector3.z;
								num3 = vector3.x;
								y = vector3.y;
								continue;
							}
							string[] array = new string[5];
							if ("The particle group '" != null)
							{
								object obj13 = "The particle group '" as string;
								if (obj13 == null)
								{
									goto IL_0a03;
								}
							}
							array[0] = "The particle group '";
							string text = particleGroup.name;
							if (text != null)
							{
								object obj14 = text as string;
								if (obj14 == null)
								{
									goto IL_0a03;
								}
							}
							array[1] = text;
							if ("' references a particle that does not exist in the actor '" != null)
							{
								object obj15 = "' references a particle that does not exist in the actor '" as string;
								if (obj15 == null)
								{
									goto IL_0a03;
								}
							}
							array[2] = "' references a particle that does not exist in the actor '";
							string text2 = actor.name;
							if (text2 != null)
							{
								object obj16 = text2 as string;
								if (obj16 == null)
								{
									goto IL_0a03;
								}
							}
							array[3] = text2;
							if ("'." != null)
							{
								object obj17 = "'." as string;
								if (obj17 == null)
								{
									goto IL_0a03;
								}
							}
							array[4] = "'.";
							string message = string.Concat(array);
							Debug.LogError(message);
							m_PositionOffsets = null;
							m_OrientationOffsets = null;
							m_SolverIndices = null;
							return;
							IL_0a03:
							while (true)
							{
								ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
								TypeLoadException ex2 = new TypeLoadException();
							}
						}
						while (flag6);
					}
					if (!actor.usesOrientedParticles)
					{
						return;
					}
					object obj18 = (long)(IntPtr)obj2 - 208L;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10C1A04 (inside UnityEngine.Matrix4x4::GetLossyScale_Injected +0x50)");
					int count6 = particleGroup.Count;
					if (count6 >= 1)
					{
						float z2 = num2;
						float w = m;
						Quaternion quaternion2 = quaternion;
						float y2 = num4;
						int num9 = 0;
						Quaternion quaternion4 = default(Quaternion);
						Quaternion quaternion5 = default(Quaternion);
						bool flag7;
						do
						{
							ObiActor obiActor6 = actor;
							Quaternion[] orientationOffsets2 = m_OrientationOffsets;
							ObiNativeQuaternionList orientations = obiActor6.solver.orientations;
							int[] solverIndices5 = m_SolverIndices;
							Quaternion quaternion3 = orientations.get_Item(solverIndices5[num9]);
							quaternion4.x = quaternion.x;
							quaternion4.y = num4;
							quaternion4.z = num2;
							quaternion4.w = m;
							quaternion5.x = quaternion2.x;
							quaternion5.y = y2;
							quaternion5.z = z2;
							quaternion5.w = w;
							quaternion2 = quaternion4 * quaternion5;
							y2 = quaternion2.y;
							z2 = quaternion2.z;
							w = quaternion2.w;
							int num10 = num9 << 4;
							object obj19 = (long)(IntPtr)m_OrientationOffsets + (long)num10;
							orientationOffsets2[num9].y = quaternion2.y;
							orientationOffsets2[num9].z = quaternion2.z;
							orientationOffsets2[num9].w = quaternion2.w;
							int num11 = num9 + 1;
							int count7 = particleGroup.Count;
							flag7 = num11 < count7;
							num9 = num11;
						}
						while (flag7);
					}
					return;
				}
			}
			m_PositionOffsets = null;
			m_OrientationOffsets = null;
			m_SolverIndices = null;
		}

		[Token(Token = "0x60003A5")]
		[Address(RVA = "0xC27E20", Offset = "0xC27E20", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = UnityEngine.Behaviour::get_enabled(this);\n\tv13 = v11 == 0;\n\tif (v13) goto L_0018;\n\tObi.ObiParticleAttachment::Enable(this, this.m_AttachmentType);\n\treturn;\nL_0018:\n\tObi.ObiParticleAttachment::Disable(this, 0);\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UpdateEnabledState()
		{
			if (base.enabled)
			{
				Enable(attachmentType);
			}
			else
			{
				Disable(default(AttachmentType));
			}
		}

		[Token(Token = "0x60003A6")]
		[Address(RVA = "0xC284C0", Offset = "0xC284C0", Length = "0x4B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv32 = *([1EF4D08]);\n\tv33 = *([v32 @ X8_v64]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, type, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([202313F]) = v51;\nL_001A:\n\tv52 = this.m_Actor;\n\tv58 = Obi.ObiActor::get_blueprint(v52);\n\tv61 = Obi.ObiParticleAttachment::get_isBound(this);\n\tv318 = v61 == 0;\n\tif (v318) goto L_01FC;\n\tgoto L_0037;\n\tv507 = *([v401 @ X0_v12+E0]);\n\tv508 = v507 == 0;\n\tv509 = ~v508;\n\tif (v509) goto L_0037;\n\tv511 = \"il2cpp_codegen_runtime_class_init\"(v401, v57, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_0037:\n\tv474 = UnityEngine.Object::op_Inequality(v58, 0);\n\tv480 = v474 == 0;\n\tif (v480) goto L_01FC;\n\tv579 = this.m_Actor;\n\tgoto L_004C;\n\tv669 = *([v581 @ X0_v19+E0]);\n\tv670 = v669 == 0;\n\tv671 = ~v670;\n\tif (v671) goto L_004C;\n\tv673 = \"il2cpp_codegen_runtime_class_init\"(v581, v467, v459, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_004C:\n\tv475 = UnityEngine.Object::op_Inequality(v579.m_Solver, 0);\n\tv481 = v475 == 0;\n\tif (v481) goto L_01FC;\n\tv180 = type == 1;\n\tif (v180) goto L_0095;\n\tv678 = type == 0;\n\tv482 = ~v678;\n\tif (v482) goto L_01FC;\n\tv692 = this.m_SolverIndices;\nL_006B:\n\tv84 = v296 >= v692.Length;\n\tif (v84) goto L_00AE;\n\tv270 = Obi.ObiSolver::get_invMasses(v52.m_Solver);\n\tv302 = this.m_SolverIndices;\n\tv742 = v296 < v302.Length;\n\tv215 = ~v742;\n\tif (v215) goto L_020D;\n\tv630 = Obi.ObiNativeFloatList::set_Item(v270, v302[v296 @ X21_v13 (System.Int32)], 0f);\n\tv692 = this.m_SolverIndices;\n\tv296 = v296 + 1;\n\tv761 = this.m_SolverIndices == 0;\n\tv642 = ~v761;\n\tif (v642) goto L_006B;\n\tgoto L_01F0;\nL_0095:\n\tv679 = Obi.ObiActor::GetConstraintsByType(this.m_Actor, 8);\n\tv681 = v679 == 0;\n\tif (v681) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0113;\nL_00AE:\n\tv631 = Obi.ObiActor::get_usesOrientedParticles(this.m_Actor);\n\tv741 = v631 == 0;\n\tif (v741) goto L_00E8;\n\tv744 = ~this.m_ConstrainOrientation;\n\tif (v744) goto L_00E8;\n\tv773 = this.m_SolverIndices;\nL_00C3:\n\tv86 = v297 >= v773.Length;\n\tif (v86) goto L_00E8;\n\tv273 = Obi.ObiSolver::get_invRotationalMasses(v52.m_Solver);\n\tv305 = this.m_SolverIndices;\n\tv791 = v297 < v305.Length;\n\tv218 = ~v791;\n\tif (v218) goto L_020D;\n\tv633 = Obi.ObiNativeFloatList::set_Item(v273, v305[v297 @ X21_v17 (System.Int32)], 0f);\n\tv773 = this.m_SolverIndices;\n\tv297 = v297 + 1;\n\tv824 = this.m_SolverIndices == 0;\n\tv645 = ~v824;\n\tif (v645) goto L_00C3;\n\tgoto L_01F0;\nL_00E8:\n\tv274 = this.m_Actor;\n\tv571 = *([v274 @ X0_v54 (Obi.ObiActor)]);\n\tv550 = *([v571 @ X8_v47 (Il2CppClass<Obi.ObiActor>)+2A0]);\n\tv559 = *([v571 @ X8_v47 (Il2CppClass<Obi.ObiActor>)+2A8]);\n\t// 249 IndirectJump v550 @ X2_v23, v274 @ X0_v54 (Obi.ObiActor), v274 @ X0_v54 (Obi.ObiActor), v559 @ X1_v27, v550 @ X2_v23, v36 @ X3, v37 @ X4, v38 @ X5, v39 @ X6, v40 @ X7, v115 @ V0_v16 (System.Single), v42 @ V1, v43 @ V2, v44 @ V3, v45 @ V4 (System.Single), v46 @ V5 (System.Single), v47 @ V6 (System.Single), v48 @ V7\n\tv735 = v735_asT == 0;\n\tif (v735) goto L_FFFFFFFF;\n\tgoto L_0113;\nL_0113:\n\tv476 = UnityEngine.Component::GetComponent(this.m_Target);\n\tv483 = v314 == 0;\n\tif (v483) goto L_01FC;\n\tgoto L_0124;\n\tv752 = *([v748 @ X0_v27+E0]);\n\tv753 = v752 == 0;\n\tv754 = ~v753;\n\tif (v754) goto L_0124;\n\tv756 = \"il2cpp_codegen_runtime_class_init\"(v748, v468, v236, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_0124:\n\tv477 = UnityEngine.Object::op_Inequality(v476, 0);\n\tv484 = v477 == 0;\n\tif (v484) goto L_01FC;\n\tv634 = new Obi.ObiPinConstraintsBatch();\n\tObi.ObiPinConstraintsBatch::.ctor(v634, 0);\n\tv397 = this.m_PositionOffsets;\n\tthis.pinBatch = v634;\n\tv345 = v397.Length;\n\tv790 = v397.Length < 1;\n\tif (v790) goto L_018B;\nL_0142:\n\tv821 = v387 < v345;\n\tv376 = ~v821;\n\tif (v376) goto L_020D;\n\tv346 = this.m_OrientationOffsets;\n\tv825 = v387 < v346.Length;\n\tv377 = ~v825;\n\tif (v377) goto L_020D;\n\tv829 = v387 * 0xC;\n\tv830 = v397 + v829;\n\tv598 = v387 << 4;\n\tv625 = v346 + v598;\n\t// 363 MakeStruct v585 @ AGGC287E4_3_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v830 @ X8_v35+20], v397[v387 @ X9_v17 (System.Int32)].y (System.Single), v397[v387 @ X9_v17 (System.Int32)].z (System.Single)\n\t// 364 MakeStruct v584 @ AGGC287E4_4_v7 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), [v625 @ X9_v18+20], v346[v387 @ X9_v17 (System.Int32)].y (System.Single), v346[v387 @ X9_v17 (System.Int32)].z (System.Single), v346[v387 @ X9_v17 (System.Int32)].w (System.Single)\n\tObi.ObiPinConstraintsBatch::AddConstraint(v383, 0, v476, v585, v584);\n\tv664 = this.pinBatch;\n\tv626 = v664.m_ActiveConstraintCount + 1;\n\tv664.m_ActiveConstraintCount = v626;\n\tv397 = this.m_PositionOffsets;\n\tv345 = v397.Length;\n\tv242 = this.pinBatch;\n\tv387 = v387 + 1;\n\tv793 = v387 < v397.Length;\n\tif (v793) goto L_0142;\nL_018B:\n\tv812 = Obi.ObiConstraints`1<Obi.ObiPinConstraintsBatch>::AddBatch(v314, v242);\n\tObi.ObiConstraintsBatch::AddToSolver(this.pinBatch, v314);\n\tv308 = this.m_SolverIndices;\nL_019A:\n\tv276 = this.pinBatch;\n\tv833 = v315 < v308.Length;\n\tv222 = ~v833;\n\tv90 = v315 >= v308.Length;\n\tif (v90) goto L_020A;\n\tif (v222) goto L_020D;\n\tv636 = Obi.ObiNativeIntList::set_Item(v276.particleIndices, v315, v308[v315 @ X20_v10 (System.Int32)]);\n\tv309 = this.pinBatch;\n\tv252 = v300 - 1;\n\tv637 = Obi.ObiNativeFloatList::set_Item(v309.stiffnesses, v252, this.m_Compliance);\n\tv310 = this.pinBatch;\n\tv187 = this.m_ConstrainOrientation == 0;\n\tv91 = ~v187;\n\tv96 = ~v91;\n\tif (v96) goto L_FFFFFFFF;\n\tgoto L_01DC;\nL_01DC:\n\tv638 = Obi.ObiNativeFloatList::set_Item(v310.stiffnesses, v300, v120);\n\tv311 = this.pinBatch;\n\tv628 = Obi.ObiNativeFloatList::set_Item(v311.breakThresholds, v315, this.m_BreakThreshold);\n\tv308 = this.m_SolverIndices;\n\tv315 = v315 + 1;\n\tv300 = v300 + 2;\n\tv845 = this.m_SolverIndices == 0;\n\tv639 = ~v845;\n\tif (v639) goto L_019A;\nL_01F0:\n\tthrow System.NullReferenceException;\nL_01FC:\n\treturn;\nL_020A:\n\tObi.ObiConstraintsBatch::SetEnabled(this.pinBatch, 1);\n\treturn;\n\tv316 = new System.NullReferenceException();\nL_020D:\n\tv399 = new System.IndexOutOfRangeException();\n\tthrow v399;\n\treturn;\n// 369 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Enable(AttachmentType type)
		{
			//IL_0335: Expected I, but got O
			//IL_0345: Expected O, but got I
			//IL_0355: Expected O, but got I
			//IL_04c0: Expected O, but got I
			//IL_04dc: Expected O, but got I
			//IL_04f1: Expected F4, but got I
			//IL_053c: Expected F4, but got I
			ObiActor obiActor = actor;
			UnityEngine.Object blueprint = obiActor.blueprint;
			if (!isBound || !(blueprint != null))
			{
				return;
			}
			ObiActor obiActor2 = actor;
			if (!(obiActor2.solver != null))
			{
				return;
			}
			IObiConstraints constraintsByType = default(IObiConstraints);
			ObiConstraints<ObiPinConstraintsBatch> obiConstraints;
			if (type != AttachmentType.Dynamic)
			{
				if (type != AttachmentType.Static)
				{
					return;
				}
				int[] solverIndices = m_SolverIndices;
				int num = 0;
				while (num < solverIndices.Length)
				{
					ObiNativeFloatList invMasses = obiActor.solver.invMasses;
					int[] solverIndices2 = m_SolverIndices;
					if (num < solverIndices2.Length)
					{
						invMasses.set_Item(solverIndices2[num], 0f);
						solverIndices = m_SolverIndices;
						num++;
						bool flag = m_SolverIndices == null;
						bool flag2 = !flag;
						float num2 = 0f;
						if (flag2)
						{
							continue;
						}
						goto IL_07e0;
					}
					goto IL_07f8;
				}
				if (actor.usesOrientedParticles && constrainOrientation)
				{
					int[] solverIndices3 = m_SolverIndices;
					int num3 = 0;
					while (num3 < solverIndices3.Length)
					{
						ObiNativeFloatList invRotationalMasses = obiActor.solver.invRotationalMasses;
						int[] solverIndices4 = m_SolverIndices;
						if (num3 < solverIndices4.Length)
						{
							invRotationalMasses.set_Item(solverIndices4[num3], 0f);
							solverIndices3 = m_SolverIndices;
							num3++;
							bool flag3 = m_SolverIndices == null;
							bool flag4 = !flag3;
							float num2 = 0f;
							if (flag4)
							{
								continue;
							}
							goto IL_07e0;
						}
						goto IL_07f8;
					}
				}
				ObiActor obiActor3 = actor;
				IntPtr intPtr = (IntPtr)obiActor3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v571 @ X8_v47 (Il2CppClass<Obi.ObiActor>)+2A0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v571 @ X8_v47 (Il2CppClass<Obi.ObiActor>)+2A8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v550 @ X2_v23 (should have been resolved before IL gen)");
			}
			else
			{
				constraintsByType = actor.GetConstraintsByType(Oni.ConstraintType.Pin);
				if (constraintsByType == null)
				{
					obiConstraints = null;
					goto IL_03a0;
				}
			}
			ObiConstraints<ObiPinConstraintsBatch> obiConstraints2 = constraintsByType as ObiConstraints<ObiPinConstraintsBatch>;
			obiConstraints = (ObiConstraints<ObiPinConstraintsBatch>)((obiConstraints2 == null) ? null : constraintsByType);
			goto IL_03a0;
			IL_062f:
			ObiPinConstraintsBatch batch;
			bool flag5 = obiConstraints.AddBatch(batch);
			pinBatch.AddToSolver(obiConstraints);
			int[] solverIndices5 = m_SolverIndices;
			int num4 = 1;
			int num5 = 0;
			while (true)
			{
				ObiConstraintsBatch obiConstraintsBatch = pinBatch;
				bool flag6 = num5 < solverIndices5.Length;
				bool flag7 = !flag6;
				if (num5 < solverIndices5.Length)
				{
					if (flag7)
					{
						break;
					}
					obiConstraintsBatch.particleIndices.set_Item(num5, solverIndices5[num5]);
					ObiPinConstraintsBatch obiPinConstraintsBatch = pinBatch;
					int index = num4 - 1;
					obiPinConstraintsBatch.stiffnesses.set_Item(index, compliance);
					ObiPinConstraintsBatch obiPinConstraintsBatch2 = pinBatch;
					float value = ((!constrainOrientation) ? 10000f : 0f);
					obiPinConstraintsBatch2.stiffnesses.set_Item(num4, value);
					ObiPinConstraintsBatch obiPinConstraintsBatch3 = pinBatch;
					obiPinConstraintsBatch3.breakThresholds.set_Item(num5, breakThreshold);
					solverIndices5 = m_SolverIndices;
					num5++;
					num4 += 2;
					if (m_SolverIndices != null)
					{
						continue;
					}
					goto IL_07e0;
				}
				pinBatch.SetEnabled(enabled: true);
				return;
			}
			goto IL_07f8;
			IL_03a0:
			ObiColliderBase component = target.GetComponent<ObiColliderBase>();
			if (obiConstraints == null || !(component != null))
			{
				return;
			}
			ObiPinConstraintsBatch obiPinConstraintsBatch4 = new ObiPinConstraintsBatch();
			Vector3[] positionOffsets = m_PositionOffsets;
			pinBatch = obiPinConstraintsBatch4;
			int num6 = positionOffsets.Length;
			bool flag8 = positionOffsets.Length < 1;
			batch = obiPinConstraintsBatch4;
			if (flag8)
			{
				goto IL_062f;
			}
			ObiPinConstraintsBatch obiPinConstraintsBatch5 = obiPinConstraintsBatch4;
			int num7 = 0;
			Vector3 offset = default(Vector3);
			Quaternion restDarboux = default(Quaternion);
			while (num7 < num6)
			{
				Quaternion[] orientationOffsets = m_OrientationOffsets;
				if (num7 >= orientationOffsets.Length)
				{
					break;
				}
				int num8 = num7 * 12;
				object obj3 = (long)(IntPtr)positionOffsets + (long)num8;
				int num9 = num7 << 4;
				object obj4 = (long)(IntPtr)orientationOffsets + (long)num9;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v830 @ X8_v35+20]");
				offset.x = 0f;
				offset.y = positionOffsets[num7].y;
				offset.z = positionOffsets[num7].z;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v625 @ X9_v18+20]");
				restDarboux.x = 0f;
				restDarboux.y = orientationOffsets[num7].y;
				restDarboux.z = orientationOffsets[num7].z;
				restDarboux.w = orientationOffsets[num7].w;
				obiPinConstraintsBatch5.AddConstraint(0, component, offset, restDarboux);
				ObiPinConstraintsBatch obiPinConstraintsBatch6 = pinBatch;
				int activeConstraintCount = obiPinConstraintsBatch6.activeConstraintCount + 1;
				obiPinConstraintsBatch6.activeConstraintCount = activeConstraintCount;
				positionOffsets = m_PositionOffsets;
				num6 = positionOffsets.Length;
				batch = pinBatch;
				num7++;
				bool flag9 = num7 < positionOffsets.Length;
				obiPinConstraintsBatch5 = pinBatch;
				if (flag9)
				{
					continue;
				}
				goto IL_062f;
			}
			goto IL_07f8;
			IL_07e0:
			throw new NullReferenceException();
			IL_07f8:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x60003A7")]
		[Address(RVA = "0xC27468", Offset = "0xC27468", Length = "0x2F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EE3120]);\n\tv23 = *([v22 @ X8_v38]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, type, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2023140]) = v42;\nL_0015:\n\tv43 = this.m_Actor;\n\tv49 = Obi.ObiActor::get_blueprint(v43);\n\tv52 = Obi.ObiParticleAttachment::get_isBound(this);\n\tv223 = v52 == 0;\n\tif (v223) goto L_00D3;\n\tgoto L_0032;\n\tv327 = *([v226 @ X0_v9+E0]);\n\tv328 = v327 == 0;\n\tv329 = ~v328;\n\tif (v329) goto L_0032;\n\tv331 = \"il2cpp_codegen_runtime_class_init\"(v226, v48, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0032:\n\tv262 = UnityEngine.Object::op_Inequality(v49, 0);\n\tv267 = v262 == 0;\n\tif (v267) goto L_00D3;\n\tv335 = this.m_Actor;\n\tgoto L_0047;\n\tv434 = *([v337 @ X0_v19+E0]);\n\tv435 = v434 == 0;\n\tv436 = ~v435;\n\tif (v436) goto L_0047;\n\tv438 = \"il2cpp_codegen_runtime_class_init\"(v337, v257, v253, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0047:\n\tv263 = UnityEngine.Object::op_Inequality(v335.m_Solver, 0);\n\tv268 = v263 == 0;\n\tif (v268) goto L_00D3;\n\tv130 = this.m_AttachmentType == 1;\n\tif (v130) goto L_00A4;\n\tv447 = this.m_AttachmentType == 0;\n\tv269 = ~v447;\n\tif (v269) goto L_00D3;\n\tv459 = this.m_SolverIndices;\nL_0067:\n\tv59 = v172 >= v459.Length;\n\tif (v59) goto L_00D8;\n\tv196 = Obi.ObiSolver::get_invMasses(v43.m_Solver);\n\tv212 = this.m_SolverIndices;\n\tv472 = v172 < v212.Length;\n\tv384 = ~v472;\n\tif (v384) goto L_014E;\n\tv187 = *([v49 @ X0_v5 (UnityEngine.Object)+78]);\n\tv488 = v172 < *([v187 @ X9_v18+18]);\n\tv156 = ~v488;\n\tif (v156) goto L_014E;\n\tv346 = v172 << 2;\n\tv402 = v187 + v346;\n\tv67 = *([v402 @ X9_v19+20]);\n\tv392 = v172 + 1;\n\tv408 = Obi.ObiNativeFloatList::set_Item(v196, v212[v172 @ X22_v11 (System.Int32)], *([v402 @ X9_v19+20]));\n\tv459 = this.m_SolverIndices;\n\tv493 = this.m_SolverIndices == 0;\n\tv418 = ~v493;\n\tif (v418) goto L_0067;\n\tgoto L_014D;\nL_00A4:\n\tv261 = Obi.ObiActor::GetConstraintsByType(this.m_Actor, 8);\n\tv266 = v261 == 0;\n\tif (v266) goto L_00D3;\n\tgoto L_FFFFFFFF;\n\tv134 = v134_asT != 0;\n\tv56 = v56_asT == 0;\n\tif (v56) goto L_FFFFFFFF;\n\tgoto L_00CB;\nL_00CB:\n\tif (v134) goto L_0131;\nL_00D3:\n\treturn;\nL_00D8:\n\tv409 = Obi.ObiActor::get_usesOrientedParticles(this.m_Actor);\n\tv471 = v409 == 0;\n\tif (v471) goto L_0122;\n\tv486 = this.m_SolverIndices;\nL_00EA:\n\tv61 = v174 >= v486.Length;\n\tif (v61) goto L_0122;\n\tv199 = Obi.ObiSolver::get_invRotationalMasses(v43.m_Solver);\n\tv215 = this.m_SolverIndices;\n\tv496 = v174 < v215.Length;\n\tv386 = ~v496;\n\tif (v386) goto L_014E;\n\tv190 = *([v49 @ X0_v5 (UnityEngine.Object)+80]);\n\tv497 = v174 < *([v190 @ X9_v15+18]);\n\tv159 = ~v497;\n\tif (v159) goto L_014E;\n\tv347 = v174 << 2;\n\tv405 = v190 + v347;\n\tv393 = v174 + 1;\n\tv411 = Obi.ObiNativeFloatList::set_Item(v199, v215[v174 @ X22_v15 (System.Int32)], *([v405 @ X9_v16+20]));\n\tv486 = this.m_SolverIndices;\n\tv501 = this.m_SolverIndices == 0;\n\tv424 = ~v501;\n\tif (v424) goto L_00EA;\n\tgoto L_014D;\nL_0122:\n\tv200 = this.m_Actor;\n\tv319 = *([v200 @ X0_v33 (Obi.ObiActor)]);\n\tv299 = *([v319 @ X8_v22 (Il2CppClass<Obi.ObiActor>)+2A0]);\n\tv308 = *([v319 @ X8_v22 (Il2CppClass<Obi.ObiActor>)+2A8]);\n\t// 303 IndirectJump v299 @ X2_v14, v200 @ X0_v33 (Obi.ObiActor), v200 @ X0_v33 (Obi.ObiActor), v308 @ X1_v16, v299 @ X2_v14, v27 @ X3, v28 @ X4, v29 @ X5, v30 @ X6, v31 @ X7, v67 @ V0_v6 (System.Single), v33 @ V1, v34 @ V2, v35 @ V3, v36 @ V4, v37 @ V5, v38 @ V6, v39 @ V7\nL_0131:\n\tv270 = this.pinBatch == 0;\n\tif (v270) goto L_00D3;\n\tObi.ObiConstraintsBatch::SetEnabled(this.pinBatch, 0);\n\tObi.ObiConstraintsBatch::RemoveFromSolver(this.pinBatch, v220);\n\tv312 = Obi.ObiConstraints`1<Obi.ObiPinConstraintsBatch>::RemoveBatch(v220, this.pinBatch);\n\treturn;\nL_014D:\n\tv433 = new System.NullReferenceException();\nL_014E:\n\tv444 = new System.IndexOutOfRangeException();\n\tthrow v444;\n\tthrow System.NullReferenceException;\n// 234 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Disable(AttachmentType type)
		{
			//IL_0451: Expected I, but got O
			//IL_0461: Expected O, but got I
			//IL_0471: Expected O, but got I
			//IL_016e: Expected O, but got I
			//IL_01be: Expected O, but got I
			//IL_01ce: Expected F4, but got I
			//IL_01fe: Expected F4, but got I
			//IL_0379: Expected O, but got I
			//IL_03c9: Expected O, but got I
			//IL_03f9: Expected F4, but got I
			ObiActor obiActor = actor;
			UnityEngine.Object blueprint = obiActor.blueprint;
			if (!isBound || !(blueprint != null))
			{
				return;
			}
			ObiActor obiActor2 = actor;
			if (!(obiActor2.solver != null))
			{
				return;
			}
			IObiConstraints obiConstraints3 = default(IObiConstraints);
			if (attachmentType != AttachmentType.Dynamic)
			{
				if (attachmentType != AttachmentType.Static)
				{
					return;
				}
				int[] solverIndices = m_SolverIndices;
				int num = 0;
				while (true)
				{
					if (num < solverIndices.Length)
					{
						ObiNativeFloatList invMasses = obiActor.solver.invMasses;
						int[] solverIndices2 = m_SolverIndices;
						if (num < solverIndices2.Length)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ X0_v5 (UnityEngine.Object)+78]");
							object obj = 0;
							int num2 = num;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ X9_v18+18]");
							if ((long)num2 < 0L)
							{
								int num3 = num << 2;
								object obj2 = (long)(IntPtr)obj + (long)num3;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ X9_v19+20]");
								float num4 = 0f;
								int num5 = num + 1;
								int index = solverIndices2[num];
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ X9_v19+20]");
								invMasses.set_Item(index, 0f);
								solverIndices = m_SolverIndices;
								bool flag = m_SolverIndices == null;
								bool flag2 = !flag;
								num = num5;
								if (flag2)
								{
									continue;
								}
								goto IL_04d7;
							}
						}
						goto IL_04e5;
					}
					if (!actor.usesOrientedParticles)
					{
						break;
					}
					int[] solverIndices3 = m_SolverIndices;
					int num6 = 0;
					while (num6 < solverIndices3.Length)
					{
						ObiNativeFloatList invRotationalMasses = obiActor.solver.invRotationalMasses;
						int[] solverIndices4 = m_SolverIndices;
						if (num6 < solverIndices4.Length)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ X0_v5 (UnityEngine.Object)+80]");
							object obj3 = 0;
							int num7 = num6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ X9_v15+18]");
							if ((long)num7 < 0L)
							{
								int num8 = num6 << 2;
								object obj4 = (long)(IntPtr)obj3 + (long)num8;
								int num9 = num6 + 1;
								int index2 = solverIndices4[num6];
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v405 @ X9_v16+20]");
								invRotationalMasses.set_Item(index2, 0f);
								solverIndices3 = m_SolverIndices;
								bool flag3 = m_SolverIndices == null;
								bool flag4 = !flag3;
								num6 = num9;
								if (flag4)
								{
									continue;
								}
								goto IL_04d7;
							}
						}
						goto IL_04e5;
					}
					break;
					IL_04e5:
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
					IL_04d7:
					NullReferenceException ex2 = new NullReferenceException();
					goto IL_04e5;
				}
				ObiActor obiActor3 = actor;
				IntPtr intPtr = (IntPtr)obiActor3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ X8_v22 (Il2CppClass<Obi.ObiActor>)+2A0]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ X8_v22 (Il2CppClass<Obi.ObiActor>)+2A8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v299 @ X2_v14 (should have been resolved before IL gen)");
			}
			else
			{
				IObiConstraints constraintsByType = actor.GetConstraintsByType(Oni.ConstraintType.Pin);
				if (constraintsByType == null)
				{
					return;
				}
				ObiConstraints<ObiPinConstraintsBatch> obiConstraints = constraintsByType as ObiConstraints<ObiPinConstraintsBatch>;
				bool flag5 = obiConstraints != null;
				ObiConstraints<ObiPinConstraintsBatch> obiConstraints2 = constraintsByType as ObiConstraints<ObiPinConstraintsBatch>;
				obiConstraints3 = ((obiConstraints2 == null) ? null : constraintsByType);
				if (!flag5)
				{
					return;
				}
			}
			if (pinBatch != null)
			{
				pinBatch.SetEnabled(enabled: false);
				pinBatch.RemoveFromSolver(obiConstraints3);
				bool flag6 = ((ObiConstraints<ObiPinConstraintsBatch>)obiConstraints3).RemoveBatch((IObiConstraintsBatch)pinBatch);
			}
		}

		[Token(Token = "0x60003A8")]
		[Address(RVA = "0xC289E8", Offset = "0xC289E8", Length = "0x608")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv40 = &v41 @ stack_-10_v2;\n\tgoto L_0027;\n\tv50 = *([1ED7FC0]);\n\tv51 = *([v50 @ X8_v59]);\n\tv52 = \"il2cpp_codegen_initialize_method\"(v51, methodInfo, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv70 = 0 | 1;\n\t*([2023141]) = v70;\nL_0027:\n\t*([v40 @ X29_v1-B0]) = 0;\n\t*([v40 @ X29_v1-A0]) = 0;\n\t*([v40 @ X29_v1-D0]) = 0;\n\t*([v40 @ X29_v1-C0]) = 0;\n\tv74 = UnityEngine.Behaviour::get_enabled(this);\n\tv76 = v74 == 0;\n\tif (v76) goto L_028A;\n\tv77 = this.m_Actor;\n\tv572 = Obi.ObiActor::get_blueprint(v77);\n\tv522 = Obi.ObiParticleAttachment::get_isBound(this);\n\tv531 = v522 == 0;\n\tif (v531) goto L_028A;\n\tgoto L_004C;\n\tv874 = *([v870 @ X0_v11+E0]);\n\tv875 = v874 == 0;\n\tv876 = ~v875;\n\tif (v876) goto L_004C;\n\tv878 = \"il2cpp_codegen_runtime_class_init\"(v870, v505, v54, v55, v56, v57, v58, v59, v71, v61, v62, v63, v64, v65, v66, v67);\nL_004C:\n\tv523 = UnityEngine.Object::op_Inequality(v572, 0);\n\tv532 = v523 == 0;\n\tif (v532) goto L_028A;\n\tv882 = this.m_Actor;\n\tgoto L_0061;\n\tv1040 = *([v884 @ X0_v18+E0]);\n\tv1041 = v1040 == 0;\n\tv1042 = ~v1041;\n\tif (v1042) goto L_0061;\n\tv1044 = \"il2cpp_codegen_runtime_class_init\"(v884, v506, v487, v55, v56, v57, v58, v59, v71, v61, v62, v63, v64, v65, v66, v67);\nL_0061:\n\tv524 = UnityEngine.Object::op_Inequality(v882.m_Solver, 0);\n\tv533 = v524 == 0;\n\tif (v533) goto L_028A;\n\tv534 = this.m_AttachmentType == 0;\n\tif (v534) goto L_00A4;\n\tv416 = this.m_AttachmentType != 1;\n\tif (v416) goto L_028A;\n\tv525 = Obi.ObiActor::GetConstraintsByType(this.m_Actor, 8);\n\tv535 = v525 == 0;\n\tif (v535) goto L_028A;\n\tgoto L_FFFFFFFF;\n\tv418 = v418_asT == 0;\n\tif (v418) goto L_028A;\n\tv536 = this.pinBatch == 0;\n\tif (v536) goto L_028A;\n\tObi.ObiPinConstraintsBatch::BreakConstraints(this.pinBatch);\n\tgoto L_028A;\nL_00A4:\n\tv741 = UnityEngine.Component::get_transform(v77.m_Solver);\n\tv756 = &v399 @ stack_-120;\n\tv1050 = UnityEngine.Transform::get_worldToLocalMatrix(v741);\n\tv399 = *([v756 @ X8_v12]);\n\tv1057 = &v335 @ stack_-160;\n\tv1059 = UnityEngine.Transform::get_localToWorldMatrix(this.m_Target);\n\tv335 = *([v1057 @ X8_v13]);\n\tgoto L_00F0;\n\tv1066 = *([v1062 @ X0_v27+E0]);\n\tv1067 = v1066 == 0;\n\tv1068 = ~v1067;\n\tif (v1068) goto L_00F0;\n\tv1070 = \"il2cpp_codegen_runtime_class_init\"(v1062, v1058, v488, v55, v56, v57, v58, v59, v71, v61, v62, v63, v64, v65, v66, v67);\nL_00F0:\n\tv1003 = UnityEngine.Matrix4x4::op_Multiply(&v399 @ stack_-120, &v335 @ stack_-160);\n\t*([v40 @ X29_v1-B0]) = v1003.m02;\n\t*([v40 @ X29_v1-A0]) = v1003.m03;\n\t*([v40 @ X29_v1-D0]) = v1003.m00;\n\t*([v40 @ X29_v1-C0]) = v1003.m01;\n\tv547 = this.m_SolverIndices;\nL_0112:\n\t;\n\tv419 = v153 >= v547.Length;\n\tif (v419) goto L_01B2;\n\tv1099 = v153 < v547.Length;\n\tv719 = ~v1099;\n\tif (v719) goto L_028B;\n\tv743 = Obi.ObiSolver::get_invMasses(v77.m_Solver);\n\tv1111 = Obi.ObiNativeFloatList::set_Item(v743, v547[v153 @ X26_v6 (System.Int32)], 0f);\n\tv1113 = Obi.ObiSolver::get_velocities(v77.m_Solver);\n\tgoto L_0147;\n\tv1119 = *([v1114 @ X8_v41+E0]);\n\tv1120 = v1119 == 0;\n\tv1121 = ~v1120;\n\tif (v1121) goto L_0147;\n\tv1127 = v1114;\n\tv1123 = \"il2cpp_codegen_runtime_class_init\"(v1127, v982, v969, v55, v56, v57, v58, v59, v1108, v271, v259, v263, v64, v65, v66, v67);\nL_0147:\n\tv1126 = UnityEngine.Vector3::get_zero();\n\tgoto L_015C;\n\tv1136 = *([v1130 @ X0_v74+E0]);\n\tv1137 = v1136 == 0;\n\tv1138 = ~v1137;\n\tif (v1138) goto L_015C;\n\tv1140 = \"il2cpp_codegen_runtime_class_init\"(v1130, v982, v969, v55, v56, v57, v58, v59, v1126, v1128, v1129, v263, v64, v65, v66, v67);\nL_015C:\n\tVector4_arg = UnityEngine.Vector4::op_Implicit(v1126);\n\tv1157 = *([v1113 @ X0_v71 (Obi.ObiNativeVector4List)]);\n\tv1160 = Obi.ObiNativeVector4List::set_Item(v1113, v547[v153 @ X26_v6 (System.Int32)], Vector4_arg);\n\tv1163 = Obi.ObiSolver::get_startPositions(v77.m_Solver);\n\tv1005 = Obi.ObiSolver::get_positions(v77.m_Solver);\n\tv1030 = this.m_PositionOffsets;\n\tv1173 = v153 < v1030.Length;\n\tv966 = ~v1173;\n\tif (v966) goto L_028B;\n\tv1178 = v153 * 0xC;\n\tv1031 = v1030 + v1178;\n\tv1182 = &v41 @ stack_-10_v2 - 0xD0;\n\tv1183 = 0x10C27FC(v1182, 0, *([v1157 @ X8_v44 (Il2CppClass<Obi.ObiNativeVector4List>)+198]), v55, v56, v57, v58, v59, *([v1031 @ X8_v46+20]), v1030[v153 @ X26_v6 (System.Int32)].y, v1030[v153 @ X26_v6 (System.Int32)].z, Vector4_arg.w, v64, v65, v66, v67);\n\t// 391 MakeStruct v902 @ AGGC28D30_0_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v1031 @ X8_v46+20], v1030[v153 @ X26_v6 (System.Int32)].y (System.Single), v1030[v153 @ X26_v6 (System.Int32)].z (System.Single)\n\tVector4_arg = UnityEngine.Vector4::op_Implicit(v902);\n\tv271 = Vector4_arg.y;\n\tv259 = Vector4_arg.z;\n\tv263 = Vector4_arg.w;\n\tv1007 = Obi.ObiNativeVector4List::set_Item(v1005, v547[v153 @ X26_v6 (System.Int32)], Vector4_arg);\n\tv1209 = *([v1163 @ X0_v80 (Obi.ObiNativeVector4List)]);\n\tv490 = *([v1209 @ X8_v48 (Il2CppClass<Obi.ObiNativeVector4List>)+198]);\n\tv913 = v153 + 1;\n\tv1008 = Obi.ObiNativeVector4List::set_Item(v1163, v547[v153 @ X26_v6 (System.Int32)], Vector4_arg);\n\tv547 = this.m_SolverIndices;\n\tv1211 = this.m_SolverIndices == 0;\n\tv1021 = ~v1211;\n\tif (v1021) goto L_0112;\n\tgoto L_0273;\nL_01B2:\n\tv527 = Obi.ObiActor::get_usesOrientedParticles(this.m_Actor);\n\tv537 = v527 == 0;\n\tif (v537) goto L_028A;\n\tv538 = ~this.m_ConstrainOrientation;\n\tif (v538) goto L_028A;\n\tv1118 = &v41 @ stack_-10_v2 - 0xD0;\n\tv1009 = 0x10C1A04(v1118, 0, v490, v55, v56, v57, v58, v59, v267, v271, v259, v263, v64, v65, v66, v67);\n\tv549 = this.m_SolverIndices;\nL_01C6:\n\t;\n\tv420 = v154 >= v549.Length;\n\tif (v420) goto L_028A;\n\tv1156 = v154 < v549.Length;\n\tv720 = ~v1156;\n\tif (v720) goto L_028B;\n\tv745 = Obi.ObiSolver::get_invRotationalMasses(v77.m_Solver);\n\tv1170 = Obi.ObiNativeFloatList::set_Item(v745, v549[v154 @ X26_v9 (System.Int32)], 0f);\n\tv1172 = Obi.ObiSolver::get_angularVelocities(v77.m_Solver);\n\tgoto L_01FB;\n\tv1184 = *([v1174 @ X8_v27+E0]);\n\tv1185 = v1184 == 0;\n\tv1186 = ~v1185;\n\tif (v1186) goto L_01FB;\n\tv1192 = v1174;\n\tv1188 = \"il2cpp_codegen_runtime_class_init\"(v1192, v988, v973, v55, v56, v57, v58, v59, v1167, v272, v260, v264, v98, v95, v92, v89);\nL_01FB:\n\tv1191 = UnityEngine.Vector3::get_zero();\n\tgoto L_0210;\n\tv1199 = *([v1195 @ X0_v47+E0]);\n\tv1200 = v1199 == 0;\n\tv1201 = ~v1200;\n\tif (v1201) goto L_0210;\n\tv1203 = \"il2cpp_codegen_runtime_class_init\"(v1195, v988, v973, v55, v56, v57, v58, v59, v1191, v1193, v1194, v264, v98, v95, v92, v89);\nL_0210:\n\tVector4_arg = UnityEngine.Vector4::op_Implicit(v1191);\n\tv1215 = Obi.ObiNativeVector4List::set_Item(v1172, v549[v154 @ X26_v9 (System.Int32)], Vector4_arg);\n\tv1218 = Obi.ObiSolver::get_startOrientations(v77.m_Solver);\n\tv1011 = Obi.ObiSolver::get_orientations(v77.m_Solver);\n\tv1036 = this.m_OrientationOffsets;\n\tv1220 = v154 < v1036.Length;\n\tv965 = ~v1220;\n\tif (v965) goto L_028B;\n\tv950 = v154 << 4;\n\tv1222 = v1036 + v950;\n\tgoto L_024B;\n\tv1229 = *([v1221 @ X0_v56+E0]);\n\tv1230 = v1229 == 0;\n\tv1231 = ~v1230;\n\tif (v1231) goto L_024B;\n\tv1233 = \"il2cpp_codegen_runtime_class_init\"(v1221, v989, v974, v55, v56, v57, v58, v59, v938, v947, v920, v929, v98, v95, v92, v89);\nL_024B:\n\t// 587 MakeStruct v888 @ AGGC28F34_0_v6 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v267 @ V0_v8 (System.Single), v271 @ V1_v7 (System.Single), v259 @ V2_v7 (System.Single), v263 @ V3_v7 (System.Single)\n\t// 588 MakeStruct v887 @ AGGC28F34_1_v6 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), [v1222 @ X8_v32+20], v1036[v154 @ X26_v9 (System.Int32)].y (System.Single), v1036[v154 @ X26_v9 (System.Int32)].z (System.Single), v1036[v154 @ X26_v9 (System.Int32)].w (System.Single)\n\tQuaternion_arg = UnityEngine.Quaternion::op_Multiply(v888, v887);\n\tv1013 = Obi.ObiNativeQuaternionList::set_Item(v1011, v549[v154 @ X26_v9 (System.Int32)], Quaternion_arg);\n\tv912 = v154 + 1;\n\tv1002 = Obi.ObiNativeQuaternionList::set_Item(v1218, v549[v154 @ X26_v9 (System.Int32)], Quaternion_arg);\n\tv549 = this.m_SolverIndices;\n\tv1242 = this.m_SolverIndices == 0;\n\tv1014 = ~v1242;\n\tif (v1014) goto L_01C6;\nL_0273:\n\tthrow System.NullReferenceException;\nL_028A:\n\treturn;\nL_028B:\n\tv1105 = new System.IndexOutOfRangeException();\n\tthrow v1105;\n\tthrow System.NullReferenceException;\n// 473 bookkeeping instructions omitted: flag registers, add\n// ... truncated")]
		private unsafe void UpdateAttachment()
		{
			//IL_01ff: Expected O, but got Ref
			//IL_01ff: Expected O, but got Ref
			//IL_0280: Expected O, but got I4
			//IL_0565: Expected O, but got I
			//IL_031f: Expected I, but got O
			//IL_03b8: Expected O, but got I
			//IL_03ca: Expected O, but got I
			//IL_03ee: Expected F4, but got I
			//IL_0489: Expected I, but got O
			//IL_0499: Expected O, but got I
			//IL_06bb: Expected O, but got I
			//IL_070a: Expected F4, but got I
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			if (!base.enabled)
			{
				return;
			}
			ObiActor obiActor = actor;
			UnityEngine.Object blueprint = obiActor.blueprint;
			if (!isBound || !(blueprint != null))
			{
				return;
			}
			ObiActor obiActor2 = actor;
			if (!(obiActor2.solver != null))
			{
				return;
			}
			if (attachmentType != AttachmentType.Static)
			{
				if (attachmentType != AttachmentType.Dynamic)
				{
					return;
				}
				IObiConstraints constraintsByType = actor.GetConstraintsByType(Oni.ConstraintType.Pin);
				if (constraintsByType != null)
				{
					ObiConstraints<ObiPinConstraintsBatch> obiConstraints = constraintsByType as ObiConstraints<ObiPinConstraintsBatch>;
					if (obiConstraints != null && pinBatch != null)
					{
						pinBatch.BreakConstraints();
					}
				}
				return;
			}
			Transform transform = obiActor.solver.transform;
			object obj4 = default(object);
			object obj3 = obj4;
			Matrix4x4 worldToLocalMatrix = transform.worldToLocalMatrix;
			obj4 = obj3;
			object obj6 = default(object);
			object obj5 = obj6;
			Matrix4x4 localToWorldMatrix = target.localToWorldMatrix;
			obj6 = obj5;
			Matrix4x4 matrix4x = (Matrix4x4)(&obj4) * (Matrix4x4)(&obj6);
			_ = matrix4x.m02;
			_ = matrix4x.m03;
			_ = matrix4x.m00;
			_ = matrix4x.m01;
			int[] solverIndices = m_SolverIndices;
			int num = 0;
			float z = matrix4x.m01;
			float w = matrix4x.m00;
			float x = matrix4x.m03;
			float y = matrix4x.m02;
			object obj7 = 0;
			Vector3 vector = default(Vector3);
			Quaternion quaternion = default(Quaternion);
			Quaternion quaternion2 = default(Quaternion);
			while (true)
			{
				if (num < solverIndices.Length)
				{
					if (num >= solverIndices.Length)
					{
						break;
					}
					ObiNativeFloatList invMasses = obiActor.solver.invMasses;
					invMasses.set_Item(solverIndices[num], 0f);
					ObiNativeVector4List velocities = obiActor.solver.velocities;
					Vector3 zero = Vector3.zero;
					Vector4 value = zero;
					IntPtr intPtr = (IntPtr)velocities;
					velocities.set_Item(solverIndices[num], value);
					ObiNativeVector4List startPositions = obiActor.solver.startPositions;
					ObiNativeVector4List positions = obiActor.solver.positions;
					Vector3[] positionOffsets = m_PositionOffsets;
					if (num >= positionOffsets.Length)
					{
						break;
					}
					int num2 = num * 12;
					object obj8 = (long)(IntPtr)positionOffsets + (long)num2;
					object obj9 = (long)(IntPtr)obj2 - 208L;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10C27FC (inside UnityEngine.Matrix4x4::op_Multiply +0x1A8)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1031 @ X8_v46+20]");
					vector.x = 0f;
					vector.y = positionOffsets[num].y;
					vector.z = positionOffsets[num].z;
					Vector4 value2 = vector;
					y = value2.y;
					z = value2.z;
					w = value2.w;
					positions.set_Item(solverIndices[num], value2);
					IntPtr intPtr2 = (IntPtr)startPositions;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1209 @ X8_v48 (Il2CppClass<Obi.ObiNativeVector4List>)+198]");
					obj7 = 0;
					int num3 = num + 1;
					startPositions.set_Item(solverIndices[num], value2);
					solverIndices = m_SolverIndices;
					bool flag = m_SolverIndices == null;
					bool flag2 = !flag;
					num = num3;
					x = value2.x;
					if (flag2)
					{
						continue;
					}
					goto IL_07f4;
				}
				if (!actor.usesOrientedParticles || !constrainOrientation)
				{
					return;
				}
				object obj10 = (long)(IntPtr)obj2 - 208L;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10C1A04 (inside UnityEngine.Matrix4x4::GetLossyScale_Injected +0x50)");
				int[] solverIndices2 = m_SolverIndices;
				int num4 = 0;
				while (true)
				{
					if (num4 < solverIndices2.Length)
					{
						if (num4 >= solverIndices2.Length)
						{
							break;
						}
						ObiNativeFloatList invRotationalMasses = obiActor.solver.invRotationalMasses;
						invRotationalMasses.set_Item(solverIndices2[num4], 0f);
						ObiNativeVector4List angularVelocities = obiActor.solver.angularVelocities;
						Vector3 zero2 = Vector3.zero;
						Vector4 value3 = zero2;
						angularVelocities.set_Item(solverIndices2[num4], value3);
						ObiNativeQuaternionList startOrientations = obiActor.solver.startOrientations;
						ObiNativeQuaternionList orientations = obiActor.solver.orientations;
						Quaternion[] orientationOffsets = m_OrientationOffsets;
						if (num4 >= orientationOffsets.Length)
						{
							break;
						}
						int num5 = num4 << 4;
						object obj11 = (long)(IntPtr)orientationOffsets + (long)num5;
						quaternion.x = x;
						quaternion.y = y;
						quaternion.z = z;
						quaternion.w = w;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1222 @ X8_v32+20]");
						quaternion2.x = 0f;
						quaternion2.y = orientationOffsets[num4].y;
						quaternion2.z = orientationOffsets[num4].z;
						quaternion2.w = orientationOffsets[num4].w;
						Quaternion value4 = quaternion * quaternion2;
						orientations.set_Item(solverIndices2[num4], value4);
						int num6 = num4 + 1;
						startOrientations.set_Item(solverIndices2[num4], value4);
						solverIndices2 = m_SolverIndices;
						bool flag3 = m_SolverIndices == null;
						bool flag4 = !flag3;
						num4 = num6;
						if (flag4)
						{
							continue;
						}
						goto IL_07f4;
					}
					return;
				}
				break;
				IL_07f4:
				throw new NullReferenceException();
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x60003A9")]
		[Address(RVA = "0xC294D0", Offset = "0xC294D0", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_BreakThreshold = Infinityf;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiParticleAttachment()
		{
			m_BreakThreshold = float.PositiveInfinity;
		}
	}
}
