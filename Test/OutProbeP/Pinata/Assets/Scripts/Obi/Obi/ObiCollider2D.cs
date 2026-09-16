using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[ExecuteInEditMode]
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x7441B0", Offset = "0x7441B0")]
	[Token(Token = "0x2000027")]
	public class ObiCollider2D : ObiColliderBase
	{
		[AttributeAttribute(Type = typeof(SerializeProperty), RVA = "0x745ABC", Offset = "0x745ABC")]
		[SerializeField]
		[Token(Token = "0x400008B")]
		[FieldOffset(Offset = "0x98")]
		private Collider2D sourceCollider;

		[Token(Token = "0x17000031")]
		public Collider2D SourceCollider
		{
			[Token(Token = "0x6000214")]
			[Address(RVA = "0xE41494", Offset = "0xE41494", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.sourceCollider;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return SourceCollider;
			}
			[Token(Token = "0x6000213")]
			[Address(RVA = "0xE41394", Offset = "0xE41394", Length = "0x100")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv24 = *([1EBCF80]);\n\tv25 = *([v24 @ X8_v15]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2024716]) = v43;\nL_001A:\n\tv47 = UnityEngine.Component::get_gameObject(value);\n\tv53 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_0030;\n\tv95 = *([v57 @ X8_v5+E0]);\n\tv96 = v95 == 0;\n\tv97 = ~v96;\n\tif (v97) goto L_0030;\n\tv103 = v57;\n\tv99 = \"il2cpp_codegen_runtime_class_init\"(v103, v52, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0030:\n\tv102 = UnityEngine.Object::op_Inequality(v47, v53);\n\tv80 = v102 == 0;\n\tif (v80) goto L_004E;\n\tgoto L_004B;\n\tv112 = *([v107 @ X0_v13+E0]);\n\tv113 = v112 == 0;\n\tv114 = ~v113;\n\tif (v114) goto L_004B;\n\tv116 = \"il2cpp_codegen_runtime_class_init\"(v107, v74, v65, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_004B:\n\tUnityEngine.Debug::LogError(\"The Collider component must reside in the same GameObject as ObiCollider.\");\n\treturn;\nL_004E:\n\tthis.sourceCollider = value;\n\tObi.ObiColliderBase::RemoveCollider(this);\n\tObi.ObiColliderBase::AddCollider(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				GameObject gameObject = value.gameObject;
				GameObject gameObject2 = base.gameObject;
				if (gameObject != gameObject2)
				{
					Debug.LogError("The Collider component must reside in the same GameObject as ObiCollider.");
					return;
				}
				sourceCollider = value;
				RemoveCollider();
				AddCollider();
			}
		}

		[Token(Token = "0x6000215")]
		[Address(RVA = "0xE4149C", Offset = "0xE4149C", Length = "0x25C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EF8F48]);\n\tv21 = *([v20 @ X8_v39]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2024717]) = v40;\nL_0015:\n\tv42 = this.tracker == 0;\n\tif (v42) goto L_0023;\n\tOni::SetColliderShape(this.oniCollider, 0);\n\tv53 = Obi.ObiShapeTracker::Destroy(this.tracker);\n\tthis.tracker = 0;\nL_0023:\n\tv58 = this.sourceCollider;\n\tv59 = this.sourceCollider == 0;\n\tif (v59) goto L_0064;\n\tv69 = *([v58 @ X20_v2 (UnityEngine.EdgeCollider2D)]) == UnityEngine.CircleCollider2D;\n\tif (v69) goto L_007D;\n\tv119 = *([v58 @ X20_v2 (UnityEngine.EdgeCollider2D)]) == UnityEngine.BoxCollider2D;\n\tif (v119) goto L_0097;\n\tv218 = *([v58 @ X20_v2 (UnityEngine.EdgeCollider2D)]) == UnityEngine.CapsuleCollider2D;\n\tif (v218) goto L_00B1;\n\tv87 = *([v58 @ X20_v2 (UnityEngine.EdgeCollider2D)]) == UnityEngine.EdgeCollider2D;\n\tif (v87) goto L_00DB;\nL_0064:\n\tgoto L_006E;\n\tv128 = *([v106 @ X0_v6+E0]);\n\tv129 = v128 == 0;\n\tv130 = ~v129;\n\tif (v130) goto L_006E;\n\tv132 = \"il2cpp_codegen_runtime_class_init\"(v106, v50, v49, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_006E:\n\tUnityEngine.Debug::LogWarning(\"Collider2D type not supported by Obi.\");\n\tv227 = this.tracker;\n\tv228 = this.tracker == 0;\n\tv229 = ~v228;\n\tif (v229) goto L_00D6;\nL_0079:\n\treturn;\nL_007D:\n\tv127 = new Obi.ObiCircleShapeTracker2D();\n\tv141 = *([v58 @ X20_v2 (UnityEngine.EdgeCollider2D)]) != UnityEngine.CircleCollider2D;\n\tif (v141) goto L_00F4;\n\tObi.ObiShapeTracker::.ctor(v127);\n\tv127.collider = this.sourceCollider;\n\tv127.adaptor.is2D = 1;\n\tgoto L_00C8;\nL_0097:\n\tv199 = new Obi.ObiBoxShapeTracker2D();\n\tv142 = *([v58 @ X20_v2 (UnityEngine.EdgeCollider2D)]) != UnityEngine.BoxCollider2D;\n\tif (v142) goto L_00F4;\n\tObi.ObiShapeTracker::.ctor(v199);\n\tv199.collider = this.sourceCollider;\n\tv199.adaptor.is2D = 1;\n\tgoto L_00C8;\nL_00B1:\n\tv200 = new Obi.ObiCapsuleShapeTracker2D();\n\tv143 = *([v58 @ X20_v2 (UnityEngine.EdgeCollider2D)]) != UnityEngine.CapsuleCollider2D;\n\tif (v143) goto L_00F4;\n\tObi.ObiShapeTracker::.ctor(v200);\n\tv200.collider = this.sourceCollider;\n\tv200.adaptor.is2D = 1;\nL_00C8:\n\tv264 = Oni::CreateShape(v333);\n\tv227.oniShape = v264;\n\tthis.tracker = v227;\n\tv267 = v227 == 0;\n\tif (v267) goto L_0079;\nL_00D6:\n\tOni::SetColliderShape(this.oniCollider, *([v227 @ X21_v6 (Obi.ObiShapeTracker)+58]));\n\treturn;\nL_00DB:\n\tv201 = new Obi.ObiEdgeShapeTracker2D();\n\tv144 = *([v58 @ X20_v2 (UnityEngine.EdgeCollider2D)]) != UnityEngine.EdgeCollider2D;\n\tif (v144) goto L_00F4;\n\tObi.ObiEdgeShapeTracker2D::.ctor(v201, this.sourceCollider);\n\tthis.tracker = v201;\n\tv336 = v201 == 0;\n\tv268 = ~v336;\n\tif (v268) goto L_00D6;\n\tgoto L_0079;\n\tthrow System.NullReferenceException;\nL_00F4:\n\tthrow System.InvalidCastException;\n// 174 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void CreateTracker()
		{
			if (Tracker != null)
			{
				Oni.SetColliderShape(oniCollider, (IntPtr)0);
				Tracker.Destroy();
				tracker = null;
			}
			EdgeCollider2D edgeCollider2D = (EdgeCollider2D)SourceCollider;
			Oni.ShapeType shapeType;
			ObiShapeTracker obiShapeTracker;
			if ((object)SourceCollider != null)
			{
				if ((object)edgeCollider2D.GetType() != typeof(CircleCollider2D))
				{
					if ((object)edgeCollider2D.GetType() != typeof(BoxCollider2D))
					{
						if ((object)edgeCollider2D.GetType() != typeof(CapsuleCollider2D))
						{
							if ((object)edgeCollider2D.GetType() != typeof(EdgeCollider2D))
							{
								goto IL_00d2;
							}
							ObiEdgeShapeTracker2D obiEdgeShapeTracker2D = new ObiEdgeShapeTracker2D((EdgeCollider2D)SourceCollider);
							if ((object)edgeCollider2D.GetType() == typeof(EdgeCollider2D))
							{
								tracker = obiEdgeShapeTracker2D;
								bool flag = obiEdgeShapeTracker2D == null;
								bool flag2 = !flag;
								obiShapeTracker = obiEdgeShapeTracker2D;
								if (!flag2)
								{
									return;
								}
								goto IL_0256;
							}
						}
						else
						{
							ObiCapsuleShapeTracker2D obiCapsuleShapeTracker2D = (ObiCapsuleShapeTracker2D)new ObiShapeTracker();
							if ((object)edgeCollider2D.GetType() == typeof(CapsuleCollider2D))
							{
								obiCapsuleShapeTracker2D.collider = SourceCollider;
								obiCapsuleShapeTracker2D.adaptor.is2D = true;
								obiShapeTracker = obiCapsuleShapeTracker2D;
								shapeType = Oni.ShapeType.Capsule;
								goto IL_030c;
							}
						}
					}
					else
					{
						ObiBoxShapeTracker2D obiBoxShapeTracker2D = (ObiBoxShapeTracker2D)new ObiShapeTracker();
						if ((object)edgeCollider2D.GetType() == typeof(BoxCollider2D))
						{
							obiBoxShapeTracker2D.collider = SourceCollider;
							obiBoxShapeTracker2D.adaptor.is2D = true;
							obiShapeTracker = obiBoxShapeTracker2D;
							shapeType = Oni.ShapeType.Box;
							goto IL_030c;
						}
					}
				}
				else
				{
					ObiCircleShapeTracker2D obiCircleShapeTracker2D = (ObiCircleShapeTracker2D)new ObiShapeTracker();
					if ((object)edgeCollider2D.GetType() == typeof(CircleCollider2D))
					{
						obiCircleShapeTracker2D.collider = SourceCollider;
						obiCircleShapeTracker2D.adaptor.is2D = true;
						obiShapeTracker = obiCircleShapeTracker2D;
						shapeType = default(Oni.ShapeType);
						goto IL_030c;
					}
				}
				throw new InvalidCastException();
			}
			goto IL_00d2;
			IL_0256:
			IntPtr collider = oniCollider;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ X21_v6 (Obi.ObiShapeTracker)+58]");
			Oni.SetColliderShape(collider, (IntPtr)0);
			return;
			IL_030c:
			IntPtr oniShape = Oni.CreateShape(shapeType);
			obiShapeTracker.oniShape = oniShape;
			tracker = obiShapeTracker;
			if (obiShapeTracker == null)
			{
				return;
			}
			goto IL_0256;
			IL_00d2:
			Debug.LogWarning("Collider2D type not supported by Obi.");
			obiShapeTracker = Tracker;
			if (Tracker == null)
			{
				return;
			}
			goto IL_0256;
		}

		[Token(Token = "0x6000216")]
		[Address(RVA = "0xE41740", Offset = "0xE41740", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1EF1798]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, enabled, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2024718]) = v41;\nL_001C:\n\tgoto L_0025;\n\tv49 = *([v45 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0025;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, enabled, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0025:\n\tv59 = UnityEngine.Object::op_Inequality(this.sourceCollider, 0);\n\tv61 = v59 == 0;\n\tif (v61) goto L_0037;\n\tv67 = UnityEngine.Behaviour::get_enabled(this.sourceCollider);\n\t*([enabled @ X1 (System.Boolean&)]) = v67;\nL_0037:\n\treturn this.sourceCollider;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected unsafe override Component GetUnityCollider(ref bool enabled)
		{
			if (SourceCollider != null)
			{
				bool flag = SourceCollider.enabled;
				ref bool reference = ref *(flag ? ((bool*)1) : ((bool*)null));
			}
			return SourceCollider;
		}

		[Token(Token = "0x6000217")]
		[Address(RVA = "0xE417E4", Offset = "0xE417E4", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = this + 0x48;\n\tv18 = 0x103B260(v15, this.sourceCollider, this.phase, 0, v19, v20, v21, v22, this.thickness, v23, v24, v25, v26, v27, v28, v29);\n\tOni::UpdateCollider(this.oniCollider, v15);\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected unsafe override void UpdateAdaptor()
		{
			ref Oni.Collider reference = ref *(Oni.Collider*)((long)(IntPtr)this + 72L);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @103B260 (inside Oni::GetProfilingInfo +0x450)");
			Oni.UpdateCollider(oniCollider, ref reference);
		}

		[Token(Token = "0x6000218")]
		[Address(RVA = "0xE41828", Offset = "0xE41828", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1F0BAF0]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024719]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Equality(this.sourceCollider, 0);\n\tv58 = v56 == 0;\n\tif (v58) goto L_003B;\n\tv63 = UnityEngine.Component::GetComponent(this);\n\tObi.ObiCollider2D::set_SourceCollider(this, v63);\n\treturn;\nL_003B:\n\tObi.ObiColliderBase::AddCollider(this);\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void FindSourceCollider()
		{
			if (SourceCollider == null)
			{
				Collider2D component = GetComponent<Collider2D>();
				SourceCollider = component;
			}
			else
			{
				AddCollider();
			}
		}

		[Token(Token = "0x6000219")]
		[Address(RVA = "0xE418CC", Offset = "0xE418CC", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F04D00]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202471A]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tObi.ObiColliderBase::.ctor(this);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiCollider2D()
		{
		}
	}
}
