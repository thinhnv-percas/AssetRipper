using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[ExecuteInEditMode]
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x74413C", Offset = "0x74413C")]
	[Token(Token = "0x2000026")]
	public class ObiCollider : ObiColliderBase
	{
		[AttributeAttribute(Type = typeof(SerializeProperty), RVA = "0x745988", Offset = "0x745988")]
		[SerializeField]
		[Token(Token = "0x4000087")]
		[FieldOffset(Offset = "0x98")]
		private Collider sourceCollider;

		[AttributeAttribute(Type = typeof(SerializeProperty), RVA = "0x7459D4", Offset = "0x7459D4")]
		[SerializeField]
		[Token(Token = "0x4000088")]
		[FieldOffset(Offset = "0xA0")]
		private bool accurateContacts;

		[AttributeAttribute(Type = typeof(SerializeProperty), RVA = "0x745A20", Offset = "0x745A20")]
		[SerializeField]
		[Token(Token = "0x4000089")]
		[FieldOffset(Offset = "0xA1")]
		private bool useDistanceFields;

		[Indent]
		[AttributeAttribute(Type = typeof(VisibleIf), RVA = "0x745A6C", Offset = "0x745A6C")]
		[Token(Token = "0x400008A")]
		[FieldOffset(Offset = "0xA8")]
		public ObiDistanceField distanceField;

		[Token(Token = "0x1700002E")]
		public Collider SourceCollider
		{
			[Token(Token = "0x6000209")]
			[Address(RVA = "0xE40C00", Offset = "0xE40C00", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.sourceCollider;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return SourceCollider;
			}
			[Token(Token = "0x6000208")]
			[Address(RVA = "0xE40774", Offset = "0xE40774", Length = "0x12C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1ECC768]);\n\tv25 = *([v24 @ X8_v17]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2024711]) = v43;\nL_001C:\n\tgoto L_0025;\n\tv50 = *([v46 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0025;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0025:\n\tv60 = UnityEngine.Object::op_Inequality(value, 0);\n\tv62 = v60 == 0;\n\tif (v62) goto L_005F;\n\tv84 = UnityEngine.Component::get_gameObject(value);\n\tv96 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_0041;\n\tv122 = *([v78 @ X8_v6+E0]);\n\tv123 = v122 == 0;\n\tv124 = ~v123;\n\tif (v124) goto L_0041;\n\tv129 = v78;\n\tv126 = \"il2cpp_codegen_runtime_class_init\"(v129, v95, v59, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0041:\n\tv74 = UnityEngine.Object::op_Inequality(v84, v96);\n\tv76 = v74 == 0;\n\tif (v76) goto L_005F;\n\tgoto L_005C;\n\tv137 = *([v133 @ X0_v18+E0]);\n\tv138 = v137 == 0;\n\tv139 = ~v138;\n\tif (v139) goto L_005C;\n\tv141 = \"il2cpp_codegen_runtime_class_init\"(v133, v72, v70, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_005C:\n\tUnityEngine.Debug::LogError(\"The Collider component must reside in the same GameObject as ObiCollider.\");\n\treturn;\nL_005F:\n\tthis.sourceCollider = value;\n\tObi.ObiColliderBase::RemoveCollider(this);\n\tObi.ObiColliderBase::AddCollider(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				if (value != null)
				{
					GameObject gameObject = value.gameObject;
					GameObject gameObject2 = base.gameObject;
					if (gameObject != gameObject2)
					{
						Debug.LogError("The Collider component must reside in the same GameObject as ObiCollider.");
						return;
					}
				}
				sourceCollider = value;
				RemoveCollider();
				AddCollider();
			}
		}

		[Token(Token = "0x1700002F")]
		public bool AccurateContacts
		{
			[Token(Token = "0x600020B")]
			[Address(RVA = "0xE40C34", Offset = "0xE40C34", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.accurateContacts;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AccurateContacts;
			}
			[Token(Token = "0x600020A")]
			[Address(RVA = "0xE40C08", Offset = "0xE40C08", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.accurateContacts == 0;\n\tv11 = ~v6;\n\tv13 = v11 ^ value;\n\tv16 = v13 == 0;\n\tif (v16) goto L_0016;\n\tv17 = this->klass;\n\tthis.accurateContacts = value;\n\tv19 = this->klass->vtable[4];\n\tv20 = this->klass->vtable[4];\n\t// 21 IndirectJump v19 @ X2_v1, this @ X0 (Obi.ObiCollider), this @ X0 (Obi.ObiCollider), v20 @ X1_v1, v19 @ X2_v1, v21 @ X3, v22 @ X4, v23 @ X5, v24 @ X6, v25 @ X7, v26 @ V0, v27 @ V1, v28 @ V2, v29 @ V3, v30 @ V4, v31 @ V5, v32 @ V6, v33 @ V7\nL_0016:\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_004b: Expected I, but got O
				//IL_0065: Expected O, but got I
				//IL_0075: Expected O, but got I
				bool flag = !AccurateContacts;
				bool flag2 = !flag;
				if (flag2 ^ value)
				{
					IntPtr intPtr = (IntPtr)this;
					accurateContacts = value;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ X8_v4 (Il2CppClass<Obi.ObiCollider>)+170]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ X8_v4 (Il2CppClass<Obi.ObiCollider>)+178]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v19 @ X2_v1 (should have been resolved before IL gen)");
				}
			}
		}

		[Token(Token = "0x17000030")]
		public bool UseDistanceFields
		{
			[Token(Token = "0x600020D")]
			[Address(RVA = "0xE40C68", Offset = "0xE40C68", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.useDistanceFields;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return UseDistanceFields;
			}
			[Token(Token = "0x600020C")]
			[Address(RVA = "0xE40C3C", Offset = "0xE40C3C", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.useDistanceFields == 0;\n\tv11 = ~v6;\n\tv13 = v11 ^ value;\n\tv16 = v13 == 0;\n\tif (v16) goto L_0016;\n\tv17 = this->klass;\n\tthis.useDistanceFields = value;\n\tv19 = this->klass->vtable[4];\n\tv20 = this->klass->vtable[4];\n\t// 21 IndirectJump v19 @ X2_v1, this @ X0 (Obi.ObiCollider), this @ X0 (Obi.ObiCollider), v20 @ X1_v1, v19 @ X2_v1, v21 @ X3, v22 @ X4, v23 @ X5, v24 @ X6, v25 @ X7, v26 @ V0, v27 @ V1, v28 @ V2, v29 @ V3, v30 @ V4, v31 @ V5, v32 @ V6, v33 @ V7\nL_0016:\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_004b: Expected I, but got O
				//IL_0065: Expected O, but got I
				//IL_0075: Expected O, but got I
				bool flag = !UseDistanceFields;
				bool flag2 = !flag;
				if (flag2 ^ value)
				{
					IntPtr intPtr = (IntPtr)this;
					useDistanceFields = value;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ X8_v4 (Il2CppClass<Obi.ObiCollider>)+170]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ X8_v4 (Il2CppClass<Obi.ObiCollider>)+178]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v19 @ X2_v1 (should have been resolved before IL gen)");
				}
			}
		}

		[Token(Token = "0x600020E")]
		[Address(RVA = "0xE40C70", Offset = "0xE40C70", Length = "0x454")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EE7AA0]);\n\tv23 = *([v22 @ X8_v56]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2024712]) = v42;\nL_0016:\n\tv44 = v40.tracker == 0;\n\tif (v44) goto L_0025;\n\tOni::SetColliderShape(v40.oniCollider, 0);\n\tv62 = v40.tracker;\n\tv59 = *([v62 @ X0_v35 (Obi.ObiShapeTracker)]);\n\tv54 = Obi.ObiShapeTracker::Destroy(v62);\n\tv40.tracker = 0;\nL_0025:\n\tv61 = ~v40.useDistanceFields;\n\tif (v61) goto L_0046;\n\tv67 = new Obi.ObiDistanceFieldShapeTracker();\n\tObi.ObiShapeTracker::.ctor(v67);\n\tv67.distanceField = v40.distanceField;\n\tv67.adaptor.is2D = 0;\n\tv280 = Oni::CreateShape(6);\n\tv67.oniShape = v280;\n\tv67.fieldDataHasChanged = 1;\n\tv40.tracker = v67;\n\tv330 = v67 == 0;\n\tif (v330) goto L_011F;\nL_0044:\n\tOni::SetColliderShape(v40.oniCollider, v476.oniShape);\n\treturn;\nL_0046:\n\tv68 = v40.sourceCollider;\n\tv69 = v40.sourceCollider == 0;\n\tif (v69) goto L_0109;\n\tgoto L_FFFFFFFF;\n\tv288 = v288_asT != 0;\n\tif (v288) goto L_014D;\n\tgoto L_FFFFFFFF;\n\tv341 = v341_asT != 0;\n\tif (v341) goto L_0179;\n\tgoto L_FFFFFFFF;\n\tv508 = v508_asT != 0;\n\tif (v508) goto L_0123;\n\tgoto L_FFFFFFFF;\n\tv554 = v554_asT != 0;\n\tif (v554) goto L_0123;\n\tgoto L_FFFFFFFF;\n\tv402 = v402_asT != 0;\n\tif (v402) goto L_01A9;\n\tgoto L_FFFFFFFF;\n\tv113 = v113_asT != 0;\n\tif (v113) goto L_01E3;\nL_0109:\n\tgoto L_0113;\n\tv318 = *([v143 @ X0_v4+E0]);\n\tv319 = v318 == 0;\n\tv320 = ~v319;\n\tif (v320) goto L_0113;\n\tv322 = \"il2cpp_codegen_runtime_class_init\"(v143, v52, v51, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0113:\n\tUnityEngine.Debug::LogWarning(\"Collider type not supported by Obi.\");\n\tv373 = v40.tracker == 0;\n\tv374 = ~v373;\n\tif (v374) goto L_0044;\nL_011F:\n\treturn;\nL_0123:\n\tv261 = new Obi.ObiCapsuleShapeTracker();\n\tv267 = *([v68 @ X20_v4 (UnityEngine.SphereCollider)]);\n\tv256 = *([v562 @ X21_v12]);\n\tv597 = *([v267 @ X8_v22 (Il2CppClass<UnityEngine.SphereCollider>)+128]) < *([v256 @ X1_v6+128]);\n\tv228 = ~v597;\n\tv156 = ~v228;\n\tif (v156) goto L_020D;\n\tv149 = *([v256 @ X1_v6+128]) << 3;\n\tv616 = *([v267 @ X8_v22 (Il2CppClass<UnityEngine.SphereCollider>)+C8]) + v149;\n\tv157 = *([v616 @ X8_v24-8]) != v256;\n\tif (v157) goto L_020D;\n\tObi.ObiShapeTracker::.ctor(v261);\n\tv261.collider = v40.sourceCollider;\n\tv261.adaptor.is2D = 0;\n\tgoto L_01A0;\nL_014D:\n\tv262 = new Obi.ObiSphereShapeTracker();\n\tgoto L_FFFFFFFF;\n\tv159 = v159_asT == 0;\n\tif (v159) goto L_020D;\n\tObi.ObiSphereShapeTracker::.ctor(v262, v40.sourceCollider);\n\tv40.tracker = v262;\n\tv612 = v262 == 0;\n\tv489 = ~v612;\n\tif (v489) goto L_0044;\n\tgoto L_011F;\nL_0179:\n\tv263 = new Obi.ObiBoxShapeTracker();\n\tgoto L_FFFFFFFF;\n\tv161 = v161_asT == 0;\n\tif (v161) goto L_020D;\n\tObi.ObiShapeTracker::.ctor(v263);\n\tv263.collider = v40.sourceCollider;\n\tv263.adaptor.is2D = 0;\nL_01A0:\n\tv487 = Oni::CreateShape(v628);\n\tv477.oniShape = v487;\n\tv40.tracker = v477;\n\tv631 = v477 == 0;\n\tv490 = ~v631;\n\tif (v490) goto L_0044;\n\tgoto L_011F;\nL_01A9:\n\tv447 = 0xE483A4(v54, *([v59 @ X8_v53 (Il2CppClass<Obi.ObiShapeTracker>)+178]), 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\treturn;\n\tX0 = *([1EC9000]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X20]);\n\tX1 = *([X21]);\n\tX21 = X0;\n\tX10 = *([X8+128]);\n\tX9 = *([X1+128]);\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_020D;\n\tX8 = *([X8+C8]);\n\tTEMPSHIFT = X9 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8-8]);\n\tC = X8 < X1;\n\tC = ~C;\n\tTEMP1 = X8 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_020D;\n\tC = X22 < 0;\n\tC = ~C;\n\tTEMP1 = X22 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ 0;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tX2 = TEMPCOND;\n\tX0 = X21;\n\tX1 = X20;\n\tX3 = 0;\n\tObi.ObiTerrainShapeTracker::.ctor(X0, X1, X2, X3);\n\t*([X19+40]) = X21;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0044;\n\tgoto L_011F;\nL_01E3:\n\tv264 = new Obi.ObiMeshShapeTracker();\n\tgoto L_FFFFFFFF;\n\tv163 = v163_asT == 0;\n\tif (v163) goto L_020D;\n\tObi.ObiMeshShapeTracker::.ctor(v264, v40.sourceCollider);\n\tv40.tracker = v264;\n\tv635 = v264 == 0;\n\tv491 = ~v635;\n\tif (v491) goto L_0044;\n\tgoto L_011F;\n\tthrow System.NullReferenceException;\nL_020D:\n\tthrow System.InvalidCastException;\n// 366 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void CreateTracker()
		{
			//IL_002c: Expected I, but got O
			//IL_02b1: Expected I, but got O
			//IL_0326: Expected O, but got I
			if (Tracker != null)
			{
				Oni.SetColliderShape(oniCollider, (IntPtr)0);
				ObiShapeTracker obiShapeTracker = Tracker;
				IntPtr intPtr = (IntPtr)obiShapeTracker;
				obiShapeTracker.Destroy();
				tracker = null;
			}
			ObiDistanceFieldShapeTracker obiDistanceFieldShapeTracker2;
			if (UseDistanceFields)
			{
				ObiDistanceFieldShapeTracker obiDistanceFieldShapeTracker = (ObiDistanceFieldShapeTracker)new ObiShapeTracker();
				obiDistanceFieldShapeTracker.distanceField = distanceField;
				obiDistanceFieldShapeTracker.adaptor.is2D = false;
				IntPtr oniShape = Oni.CreateShape(Oni.ShapeType.SignedDistanceField);
				obiDistanceFieldShapeTracker.oniShape = oniShape;
				obiDistanceFieldShapeTracker.fieldDataHasChanged = true;
				tracker = obiDistanceFieldShapeTracker;
				bool flag = obiDistanceFieldShapeTracker == null;
				obiDistanceFieldShapeTracker2 = obiDistanceFieldShapeTracker;
				if (!flag)
				{
					goto IL_00ca;
				}
				return;
			}
			SphereCollider sphereCollider = (SphereCollider)SourceCollider;
			ObiShapeTracker obiShapeTracker2;
			Oni.ShapeType shapeType;
			if ((object)SourceCollider != null)
			{
				SphereCollider sphereCollider2 = SourceCollider as SphereCollider;
				if ((object)sphereCollider2 == null)
				{
					BoxCollider boxCollider = SourceCollider as BoxCollider;
					if ((object)boxCollider == null)
					{
						CapsuleCollider capsuleCollider = SourceCollider as CapsuleCollider;
						bool flag2 = (object)capsuleCollider != null;
						object typeFromHandle = typeof(CapsuleCollider);
						if (!flag2)
						{
							CharacterController characterController = SourceCollider as CharacterController;
							bool flag3 = (object)characterController != null;
							typeFromHandle = typeof(CharacterController);
							if (!flag3)
							{
								TerrainCollider terrainCollider = SourceCollider as TerrainCollider;
								if ((object)terrainCollider == null)
								{
									MeshCollider meshCollider = SourceCollider as MeshCollider;
									if ((object)meshCollider == null)
									{
										goto IL_0261;
									}
									ObiMeshShapeTracker obiMeshShapeTracker = new ObiMeshShapeTracker((MeshCollider)SourceCollider);
									MeshCollider meshCollider2 = SourceCollider as MeshCollider;
									if ((object)meshCollider2 != null)
									{
										tracker = obiMeshShapeTracker;
										bool flag4 = obiMeshShapeTracker == null;
										bool flag5 = !flag4;
										obiDistanceFieldShapeTracker2 = (ObiDistanceFieldShapeTracker)(object)obiMeshShapeTracker;
										if (!flag5)
										{
											return;
										}
										goto IL_00ca;
									}
									goto IL_050e;
								}
								Il2CppRuntime.Boundary("UNKNOWN", "Method not found @E483A4 (inside Obi.ObiNativeVector2List::set_Item +0x1C)");
								return;
							}
						}
						ObiCapsuleShapeTracker obiCapsuleShapeTracker = (ObiCapsuleShapeTracker)new ObiShapeTracker();
						IntPtr intPtr2 = (IntPtr)sphereCollider;
						object obj = typeFromHandle;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ X8_v22 (Il2CppClass<UnityEngine.SphereCollider>)+128]");
						IntPtr intPtr3 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ X1_v6+128]");
						if ((long)intPtr3 >= 0L)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ X1_v6+128]");
							int num = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ X8_v22 (Il2CppClass<UnityEngine.SphereCollider>)+C8]");
							object obj2 = 0L + (long)num;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v616 @ X8_v24-8]");
							if ((IntPtr)0 == (IntPtr)obj)
							{
								obiCapsuleShapeTracker.collider = SourceCollider;
								obiCapsuleShapeTracker.adaptor.is2D = false;
								obiShapeTracker2 = obiCapsuleShapeTracker;
								shapeType = Oni.ShapeType.Capsule;
								goto IL_0538;
							}
						}
					}
					else
					{
						ObiBoxShapeTracker obiBoxShapeTracker = (ObiBoxShapeTracker)new ObiShapeTracker();
						BoxCollider boxCollider2 = SourceCollider as BoxCollider;
						if ((object)boxCollider2 != null)
						{
							obiBoxShapeTracker.collider = SourceCollider;
							obiBoxShapeTracker.adaptor.is2D = false;
							obiShapeTracker2 = obiBoxShapeTracker;
							shapeType = Oni.ShapeType.Box;
							goto IL_0538;
						}
					}
				}
				else
				{
					ObiSphereShapeTracker obiSphereShapeTracker = new ObiSphereShapeTracker((SphereCollider)SourceCollider);
					SphereCollider sphereCollider3 = SourceCollider as SphereCollider;
					if ((object)sphereCollider3 != null)
					{
						tracker = obiSphereShapeTracker;
						bool flag6 = obiSphereShapeTracker == null;
						bool flag7 = !flag6;
						obiDistanceFieldShapeTracker2 = (ObiDistanceFieldShapeTracker)(object)obiSphereShapeTracker;
						if (!flag7)
						{
							return;
						}
						goto IL_00ca;
					}
				}
				goto IL_050e;
			}
			goto IL_0261;
			IL_00ca:
			Oni.SetColliderShape(oniCollider, obiDistanceFieldShapeTracker2.OniShape);
			return;
			IL_0538:
			IntPtr oniShape2 = Oni.CreateShape(shapeType);
			obiShapeTracker2.oniShape = oniShape2;
			tracker = obiShapeTracker2;
			bool flag8 = obiShapeTracker2 == null;
			bool flag9 = !flag8;
			obiDistanceFieldShapeTracker2 = (ObiDistanceFieldShapeTracker)obiShapeTracker2;
			if (!flag9)
			{
				return;
			}
			goto IL_00ca;
			IL_050e:
			throw new InvalidCastException();
			IL_0261:
			Debug.LogWarning("Collider type not supported by Obi.");
			bool flag10 = Tracker == null;
			bool flag11 = !flag10;
			obiDistanceFieldShapeTracker2 = (ObiDistanceFieldShapeTracker)Tracker;
			if (!flag11)
			{
				return;
			}
			goto IL_00ca;
		}

		[Token(Token = "0x600020F")]
		[Address(RVA = "0xE41150", Offset = "0xE41150", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1EFD3C0]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, enabled, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2024713]) = v41;\nL_001C:\n\tgoto L_0025;\n\tv49 = *([v45 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0025;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, enabled, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0025:\n\tv59 = UnityEngine.Object::op_Inequality(this.sourceCollider, 0);\n\tv61 = v59 == 0;\n\tif (v61) goto L_0037;\n\tv67 = UnityEngine.Collider::get_enabled(this.sourceCollider);\n\t*([enabled @ X1 (System.Boolean&)]) = v67;\nL_0037:\n\treturn this.sourceCollider;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected unsafe override Component GetUnityCollider(ref bool enabled)
		{
			if (SourceCollider != null)
			{
				bool flag = SourceCollider.enabled;
				ref bool reference = ref *(flag ? ((bool*)1) : ((bool*)null));
			}
			return SourceCollider;
		}

		[Token(Token = "0x6000210")]
		[Address(RVA = "0xE411F4", Offset = "0xE411F4", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = this + 0x48;\n\tv18 = 0x103AFF4(v15, this.sourceCollider, this.phase, 0, v19, v20, v21, v22, this.thickness, v23, v24, v25, v26, v27, v28, v29);\n\tOni::UpdateCollider(this.oniCollider, v15);\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected unsafe override void UpdateAdaptor()
		{
			ref Oni.Collider reference = ref *(Oni.Collider*)((long)(IntPtr)this + 72L);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @103AFF4 (inside Oni::GetProfilingInfo +0x1E4)");
			Oni.UpdateCollider(oniCollider, ref reference);
		}

		[Token(Token = "0x6000211")]
		[Address(RVA = "0xE41238", Offset = "0xE41238", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1ED99D8]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024714]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Equality(this.sourceCollider, 0);\n\tv58 = v56 == 0;\n\tif (v58) goto L_003B;\n\tv63 = UnityEngine.Component::GetComponent(this);\n\tObi.ObiCollider::set_SourceCollider(this, v63);\n\treturn;\nL_003B:\n\tObi.ObiColliderBase::AddCollider(this);\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void FindSourceCollider()
		{
			if (SourceCollider == null)
			{
				Collider component = GetComponent<Collider>();
				SourceCollider = component;
			}
			else
			{
				AddCollider();
			}
		}

		[Token(Token = "0x6000212")]
		[Address(RVA = "0xE412DC", Offset = "0xE412DC", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F0AF80]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024715]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tObi.ObiColliderBase::.ctor(this);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiCollider()
		{
		}
	}
}
