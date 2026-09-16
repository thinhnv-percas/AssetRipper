using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x744C90", Offset = "0x744C90")]
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	[Token(Token = "0x2000060")]
	public class ObiRope : ObiRopeBase
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20000C1")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000319")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400031A")]
			public static Comparison<ObiStructuralElement> _003C_003E9__40_0;

			[Token(Token = "0x6000580")]
			[Address(RVA = "0xC381AC", Offset = "0xC381AC", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1EB37B0]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([20231BA]) = v37;\nL_0015:\n\tv41 = new Obi.ObiRope+<>c();\n\tSystem.Object::.ctor(v41);\n\tv45.<>9 = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000581")]
			[Address(RVA = "0xC38210", Offset = "0xC38210", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec()
			{
			}

			internal int _003CApplyTearing_003Eb__40_0(ObiStructuralElement x, ObiStructuralElement y)
			{
				//IL_000f: Expected O, but got I
				object obj = (long)(IntPtr)x + 28L;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BCCD50 (inside System.Single::IsNaN +0x138)");
				int result = default(int);
				return result;
			}
		}

		[SerializeField]
		[Token(Token = "0x40001BF")]
		[FieldOffset(Offset = "0x98")]
		protected ObiRopeBlueprint m_RopeBlueprint;

		[Token(Token = "0x40001C0")]
		[FieldOffset(Offset = "0xA0")]
		public bool tearingEnabled;

		[Token(Token = "0x40001C1")]
		[FieldOffset(Offset = "0xA4")]
		public float tearResistanceMultiplier;

		[Token(Token = "0x40001C2")]
		[FieldOffset(Offset = "0xA8")]
		public int tearRate;

		[SerializeField]
		[Token(Token = "0x40001C3")]
		[FieldOffset(Offset = "0xAC")]
		protected bool _distanceConstraintsEnabled;

		[SerializeField]
		[Token(Token = "0x40001C4")]
		[FieldOffset(Offset = "0xB0")]
		protected float _stretchCompliance;

		[SerializeField]
		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x7464AC", Offset = "0x7464AC")]
		[Token(Token = "0x40001C5")]
		[FieldOffset(Offset = "0xB4")]
		protected float _maxCompression;

		[SerializeField]
		[Token(Token = "0x40001C6")]
		[FieldOffset(Offset = "0xB8")]
		protected bool _bendConstraintsEnabled;

		[SerializeField]
		[Token(Token = "0x40001C7")]
		[FieldOffset(Offset = "0xBC")]
		protected float _bendCompliance;

		[SerializeField]
		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x74650C", Offset = "0x74650C")]
		[Token(Token = "0x40001C8")]
		[FieldOffset(Offset = "0xC0")]
		protected float _maxBending;

		[Token(Token = "0x170000A2")]
		public bool selfCollisions
		{
			[Token(Token = "0x6000412")]
			[Address(RVA = "0xC36BD8", Offset = "0xC36BD8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_SelfCollisions;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return m_SelfCollisions;
			}
			[Token(Token = "0x6000413")]
			[Address(RVA = "0xC36BE0", Offset = "0xC36BE0", Length = "0x30")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.m_SelfCollisions == 0;\n\tv11 = ~v6;\n\tv13 = v11 ^ value;\n\tv16 = v13 == 0;\n\tif (v16) goto L_0016;\n\tv17 = this->klass;\n\tthis.m_SelfCollisions = value;\n\tv19 = this->klass->vtable[22];\n\tv20 = this->klass->vtable[22];\n\t// 21 IndirectJump v19 @ X3_v1, this @ X0 (Obi.ObiRope), this @ X0 (Obi.ObiRope), value @ X1 (System.Boolean), v20 @ X2_v1, v19 @ X3_v1, v21 @ X4, v22 @ X5, v23 @ X6, v24 @ X7, v25 @ V0, v26 @ V1, v27 @ V2, v28 @ V3, v29 @ V4, v30 @ V5, v31 @ V6, v32 @ V7\nL_0016:\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_004b: Expected I, but got O
				//IL_0065: Expected O, but got I
				//IL_0075: Expected O, but got I
				bool flag = !m_SelfCollisions;
				bool flag2 = !flag;
				if (flag2 ^ value)
				{
					IntPtr intPtr = (IntPtr)this;
					m_SelfCollisions = value;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ X8_v4 (Il2CppClass<Obi.ObiRope>)+290]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ X8_v4 (Il2CppClass<Obi.ObiRope>)+298]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v19 @ X3_v1 (should have been resolved before IL gen)");
				}
			}
		}

		[Token(Token = "0x170000A3")]
		public bool distanceConstraintsEnabled
		{
			[Token(Token = "0x6000414")]
			[Address(RVA = "0xC36C10", Offset = "0xC36C10", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._distanceConstraintsEnabled;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return distanceConstraintsEnabled;
			}
			[Token(Token = "0x6000415")]
			[Address(RVA = "0xC36C18", Offset = "0xC36C18", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this._distanceConstraintsEnabled == 0;\n\tv11 = ~v6;\n\tv13 = v11 ^ value;\n\tv16 = v13 == 0;\n\tif (v16) goto L_0017;\n\tthis._distanceConstraintsEnabled = value;\n\tObi.ObiActor::PushDistanceConstraints(this, value, this._stretchCompliance, this._maxCompression);\n\treturn;\nL_0017:\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				bool flag = !distanceConstraintsEnabled;
				bool flag2 = !flag;
				if (flag2 ^ value)
				{
					_distanceConstraintsEnabled = value;
					PushDistanceConstraints(value, stretchCompliance, maxCompression);
				}
			}
		}

		[Token(Token = "0x170000A4")]
		public float stretchCompliance
		{
			[Token(Token = "0x6000416")]
			[Address(RVA = "0xC36C44", Offset = "0xC36C44", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._stretchCompliance;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return stretchCompliance;
			}
			[Token(Token = "0x6000417")]
			[Address(RVA = "0xC36C4C", Offset = "0xC36C4C", Length = "0x14")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._stretchCompliance = value;\n\tObi.ObiActor::PushDistanceConstraints(this, this._distanceConstraintsEnabled, value, this._maxCompression);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_stretchCompliance = value;
				PushDistanceConstraints(distanceConstraintsEnabled, value, maxCompression);
			}
		}

		[Token(Token = "0x170000A5")]
		public float maxCompression
		{
			[Token(Token = "0x6000418")]
			[Address(RVA = "0xC36C60", Offset = "0xC36C60", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._maxCompression;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return maxCompression;
			}
			[Token(Token = "0x6000419")]
			[Address(RVA = "0xC36C68", Offset = "0xC36C68", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._maxCompression = value;\n\tObi.ObiActor::PushDistanceConstraints(this, this._distanceConstraintsEnabled, this._stretchCompliance, value);\n\treturn;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_maxCompression = value;
				PushDistanceConstraints(distanceConstraintsEnabled, stretchCompliance, value);
			}
		}

		[Token(Token = "0x170000A6")]
		public bool bendConstraintsEnabled
		{
			[Token(Token = "0x600041A")]
			[Address(RVA = "0xC36C88", Offset = "0xC36C88", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._bendConstraintsEnabled;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return bendConstraintsEnabled;
			}
			[Token(Token = "0x600041B")]
			[Address(RVA = "0xC36C90", Offset = "0xC36C90", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this._bendConstraintsEnabled == 0;\n\tv11 = ~v6;\n\tv13 = v11 ^ value;\n\tv16 = v13 == 0;\n\tif (v16) goto L_0017;\n\tthis._bendConstraintsEnabled = value;\n\tObi.ObiActor::PushBendConstraints(this, value, this._bendCompliance, this._maxBending);\n\treturn;\nL_0017:\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				bool flag = !bendConstraintsEnabled;
				bool flag2 = !flag;
				if (flag2 ^ value)
				{
					_bendConstraintsEnabled = value;
					PushBendConstraints(value, bendCompliance, maxBending);
				}
			}
		}

		[Token(Token = "0x170000A7")]
		public float bendCompliance
		{
			[Token(Token = "0x600041C")]
			[Address(RVA = "0xC36CBC", Offset = "0xC36CBC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._bendCompliance;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return bendCompliance;
			}
			[Token(Token = "0x600041D")]
			[Address(RVA = "0xC36CC4", Offset = "0xC36CC4", Length = "0x14")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._bendCompliance = value;\n\tObi.ObiActor::PushBendConstraints(this, this._bendConstraintsEnabled, value, this._maxBending);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_bendCompliance = value;
				PushBendConstraints(bendConstraintsEnabled, value, maxBending);
			}
		}

		[Token(Token = "0x170000A8")]
		public float maxBending
		{
			[Token(Token = "0x600041E")]
			[Address(RVA = "0xC36CD8", Offset = "0xC36CD8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._maxBending;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return maxBending;
			}
			[Token(Token = "0x600041F")]
			[Address(RVA = "0xC36CE0", Offset = "0xC36CE0", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._maxBending = value;\n\tObi.ObiActor::PushBendConstraints(this, this._bendConstraintsEnabled, this._bendCompliance, value);\n\treturn;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_maxBending = value;
				PushBendConstraints(bendConstraintsEnabled, bendCompliance, value);
			}
		}

		[Token(Token = "0x170000A9")]
		public override ObiActorBlueprint blueprint
		{
			[Token(Token = "0x6000420")]
			[Address(RVA = "0xC36D00", Offset = "0xC36D00", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_RopeBlueprint;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ropeBlueprint;
			}
		}

		[Token(Token = "0x170000AA")]
		public ObiRopeBlueprint ropeBlueprint
		{
			[Token(Token = "0x6000421")]
			[Address(RVA = "0xC36D08", Offset = "0xC36D08", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_RopeBlueprint;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ropeBlueprint;
			}
			[Token(Token = "0x6000422")]
			[Address(RVA = "0xC36D10", Offset = "0xC36D10", Length = "0xB8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1EA54C0]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20231B5]) = v41;\nL_001C:\n\tgoto L_0025;\n\tv49 = *([v45 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0025;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0025:\n\tv59 = UnityEngine.Object::op_Inequality(this.m_RopeBlueprint, value);\n\tv61 = v59 == 0;\n\tif (v61) goto L_0040;\n\tObi.ObiActor::RemoveFromSolver(this);\n\tObi.ObiActor::ClearState(this);\n\tthis.m_RopeBlueprint = value;\n\tObi.ObiActor::AddToSolver(this);\n\treturn;\nL_0040:\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				if (ropeBlueprint != value)
				{
					RemoveFromSolver();
					ClearState();
					m_RopeBlueprint = value;
					AddToSolver();
				}
			}
		}

		[Token(Token = "0x6000423")]
		[Address(RVA = "0xC36DC8", Offset = "0xC36DC8", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tObi.ObiActor::OnValidate(this);\n\tObi.ObiRope::SetupRuntimeConstraints(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void OnValidate()
		{
			base.OnValidate();
			SetupRuntimeConstraints();
		}

		[Token(Token = "0x6000424")]
		[Address(RVA = "0xC36E4C", Offset = "0xC36E4C", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tObi.ObiActor::LoadBlueprint(this, solver);\n\tObi.ObiRopeBase::RebuildElementsFromConstraints(this);\n\tObi.ObiRope::SetupRuntimeConstraints(this);\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void LoadBlueprint(ObiSolver solver)
		{
			base.LoadBlueprint(solver);
			RebuildElementsFromConstraints();
			SetupRuntimeConstraints();
		}

		[Token(Token = "0x6000425")]
		[Address(RVA = "0xC36DF0", Offset = "0xC36DF0", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tObi.ObiActor::PushDistanceConstraints(this, this._distanceConstraintsEnabled, this._stretchCompliance, this._maxCompression);\n\tObi.ObiActor::PushBendConstraints(this, this._bendConstraintsEnabled, this._bendCompliance, this._maxBending);\n\tv24 = Obi.ObiActor::SetSelfCollisions(this, this.m_SelfCollisions);\n\tObi.ObiRopeBase::RecalculateRestLength(this);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SetupRuntimeConstraints()
		{
			PushDistanceConstraints(distanceConstraintsEnabled, stretchCompliance, maxCompression);
			PushBendConstraints(bendConstraintsEnabled, bendCompliance, maxBending);
			base.SetSelfCollisions(m_SelfCollisions);
			RecalculateRestLength();
		}

		[Token(Token = "0x6000426")]
		[Address(RVA = "0xC36E7C", Offset = "0xC36E7C", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tObi.ObiActor::EndStep(this);\n\tv13 = UnityEngine.Behaviour::get_isActiveAndEnabled(this);\n\tv15 = v13 == 0;\n\tif (v15) goto L_0019;\n\tObi.ObiRope::ApplyTearing(this);\n\treturn;\nL_0019:\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void EndStep()
		{
			base.EndStep();
			if (base.isActiveAndEnabled)
			{
				ApplyTearing();
			}
		}

		[Token(Token = "0x6000427")]
		[Address(RVA = "0xC36EC0", Offset = "0xC36EC0", Length = "0x504")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv34 = *([1EE5960]);\n\tv35 = *([v34 @ X8_v76]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([20231B6]) = v54;\nL_001C:\n\tv56 = ~this.tearingEnabled;\n\tif (v56) goto L_005F;\n\tv60 = new System.Collections.Generic.List`1<Obi.ObiStructuralElement>();\n\tSystem.Collections.Generic.List`1<Obi.ObiStructuralElement>::.ctor(v60);\n\tv189 = Obi.ObiActor::GetConstraintsByType(this, 4);\n\tv194 = v189 == 0;\n\tif (v194) goto L_005F;\n\tgoto L_FFFFFFFF;\n\tv137 = v137_asT != 0;\n\tv95 = v95_asT == 0;\n\tif (v95) goto L_FFFFFFFF;\n\tgoto L_0051;\nL_0051:\n\tif (v137) goto L_FFFFFFFF;\nL_005F:\n\treturn;\nL_006B:\n\tv472 = Obi.ObiConstraints`1<Obi.ObiDistanceConstraintsBatch>::GetBatchInterfaces(v91);\n\tgoto L_009D;\n\tv565 = *([v559 @ X8_v18+B0]);\n\tv566 = 0;\n\tv567 = v565 + 8;\n\tv569 = *([v606 @ X11_v23-8]);\n\tv611 = v569 == v563;\n\tif (v611) goto L_0095;\n\tv589 = v605 + 1;\n\tv616 = v589 < v561;\n\tv587 = ~v616;\n\tv591 = v606 + 0x10;\n\tv571 = ~v587;\n\tif (v571) goto L_FFFFFFFF;\n\tv592 = v486;\n\tv593 = 0;\n\tv594 = 0x8909C4(v592, v563, v593, v326, v324, v41, v42, v43, v322, v318, v46, v47, v48, v49, v50, v51);\n\tgoto L_009D;\nL_0095:\n\tv617 = *([v606 @ X11_v23]);\n\tv618 = v617 << 4;\n\tv619 = v559 + v618;\n\tv620 = v619 + 0x130;\nL_009D:\n\tv627 = System.Collections.Generic.IList`1<Obi.IObiConstraintsBatch>::get_Item(v472, v341);\n\t// 161 IsInst v630 @ X0_v20, typeof(Obi.IStructuralConstraintBatch), v627 @ X0_v19 (Obi.IObiConstraintsBatch)\n\t// 164 IsInst v536 @ X0_v21, typeof(Obi.IObiConstraintsBatch), v630 @ X0_v20\n\t// 170 IsInst v633 @ X0_v23, typeof(Obi.IObiConstraintsBatch), v630 @ X0_v20\n\tv635 = *([v633 @ X0_v23]);\n\tv637 = *([v635 @ X8_v23+126]) == 0;\n\tif (v637) goto L_00CE;\n\tv680 = *([v635 @ X8_v23+B0]) + 8;\nL_00B8:\n\tv685 = *([v680 @ X11_v18-8]) == Obi.IObiConstraintsBatch;\n\tif (v685) goto L_00D1;\n\tv679 = v679 + 1;\n\tv690 = v679 < *([v635 @ X8_v23+126]);\n\tv660 = ~v690;\n\tv680 = v680 + 0x10;\n\tv644 = ~v660;\n\tif (v644) goto L_00B8;\nL_00CE:\n\tv697 = 0x8909C4(v633, Obi.IObiConstraintsBatch, 1, 0, 0, v41, v42, v43, v67, this.tearResistanceMultiplier, v46, v47, v48, v49, v50, v51);\n\tgoto L_00D8;\nL_00D1:\n\tv692 = *([v680 @ X11_v18]) + 1;\n\tv693 = v692 << 4;\n\tv694 = v635 + v693;\n\tv697 = v694 + 0x130;\nL_00D8:\n\t*([v697 @ X0_v24])(v702, v633, *([v697 @ X0_v24+8]), v422, 0, 0, v41, v42, v43, v67, this.tearResistanceMultiplier, v46, v47, v48, v49, v50, v51);\n\t// 222 NewArr v707 @ X0_v28 (System.Single[]), typeof(System.Single[]), v702 @ X0_v26\n\t// 226 IsInst v537 @ X0_v30, typeof(Obi.IObiConstraintsBatch), v630 @ X0_v20\n\t// 232 IsInst v711 @ X0_v32, typeof(Obi.IObiConstraintsBatch), v630 @ X0_v20\n\tv712 = *([v711 @ X0_v32]);\n\tv714 = *([v712 @ X8_v29+126]) == 0;\n\tif (v714) goto L_010C;\n\tv757 = *([v712 @ X8_v29+B0]) + 8;\nL_00F6:\n\tv762 = *([v757 @ X11_v13-8]) == Obi.IObiConstraintsBatch;\n\tif (v762) goto L_010F;\n\tv756 = v756 + 1;\n\tv767 = v756 < *([v712 @ X8_v29+126]);\n\tv737 = ~v767;\n\tv757 = v757 + 0x10;\n\tv721 = ~v737;\n\tif (v721) goto L_00F6;\nL_010C:\n\tv774 = 0x8909C4(v711, Obi.IObiConstraintsBatch, 6, 0, 0, v41, v42, v43, v67, this.tearResistanceMultiplier, v46, v47, v48, v49, v50, v51);\n\tgoto L_0116;\nL_010F:\n\tv769 = *([v757 @ X11_v13]) + 6;\n\tv770 = v769 << 4;\n\tv771 = v712 + v770;\n\tv774 = v771 + 0x130;\nL_0116:\n\t*([v774 @ X0_v33])(v430, v711, *([v774 @ X0_v33+8]), v422, 0, 0, v41, v42, v43, v67, this.tearResistanceMultiplier, v46, v47, v48, v49, v50, v51);\n\tv779 = Oni::GetBatchConstraintForces(v430, v707, v707.Length, 0);\n\tv557 = v707.Length;\n\tv791 = v707.Length < 1;\n\tif (v791) goto L_01A2;\nL_012D:\n\tv328 = this.elements;\n\tv826 = v328._size < v333;\n\tv827 = ~v826;\n\tv828 = v328._size - v333;\n\tv830 = v828 == 0;\n\tv835 = ~v830;\n\tv349 = v827 & v835;\n\tif (v349) goto L_0140;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\n\tv557 = v707.Length;\nL_0140:\n\tv840 = v338 < v557;\n\tv405 = ~v840;\n\tif (v405) goto L_0248;\n\tv846 = v328._items;\n\tv439 = v846[v333 @ X25_v12 (System.Int32)];\n\tv345 = v338 << 2;\n\tv859 = v707 + v345;\n\tv418 = v859 + 0x20;\n\tv439.constraintForce = *([v418 @ X9_v28]);\n\tv557 = v707.Length;\n\tv860 = v338 < v707.Length;\n\tv553 = ~v860;\n\tif (v553) goto L_0248;\n\tv67 = -*([v418 @ X9_v28]);\n\tv350 = this.tearResistanceMultiplier >= v67;\n\tif (v350) goto L_018B;\n\tv329 = this.elements;\n\tv917 = v329._size < v333;\n\tv407 = ~v917;\n\tv400 = v329._size - v333;\n\tv386 = v400 == 0;\n\tv918 = ~v386;\n\tv351 = v407 & v918;\n\tif (v351) goto L_0182;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0182:\n\tv965 = v329._items;\n\tSystem.Collections.Generic.List`1<Obi.ObiStructuralElement>::Add(v60, v965[v333 @ X25_v12 (System.Int32)]);\n\tv557 = v707.Length;\nL_018B:\n\tv338 = v338 + 1;\n\tv333 = v333 + 2;\n\tv799 = v338 < v557;\n\tif (v799) goto L_012D;\nL_01A2:\n\tv87 = v341 + 1;\n\tv352 = v341 < 1;\n\tif (v352) goto L_006B;\n\tv105 = v60._size < 1;\n\tif (v105) goto L_005F;\n\tgoto L_01C3;\n\tv848 = *([v842 @ X0_v38 (Il2CppClass<Obi.ObiRope+<>c>)+E0]);\n\tv849 = v848 == 0;\n\tv850 = ~v849;\n\tif (v850) goto L_01C3;\n\tv861 = \"il2cpp_codegen_runtime_class_init\"(v842, v185, v181, v71, v69, v41, v42, v43, v67, v65, v46, v47, v48, v49, v50, v51);\n\tv852 = Obi.ObiRope+<>c;\nL_01C3:\n\tv92 = v855.<>9__40_0;\n\tv857 = v855.<>9__40_0 == 0;\n\tv858 = ~v857;\n\tif (v858) goto L_01E8;\n\tgoto L_01D6;\n\tv882 = *([v851 @ X0_v39 (Il2CppClass<Obi.ObiRope+<>c>)+E0]);\n\tv883 = v882 == 0;\n\tv884 = ~v883;\n\tif (v884) goto L_01D6;\n\tv887 = \"il2cpp_codegen_runtime_class_init\"(v851, v185, v181, v71, v69, v41, v42, v43, v67, v65, v46, v47, v48, v49, v50, v51);\n\tv919 = Obi.ObiRope+<>c;\n\tv889 = *([v919 @ X8_v56+B8]);\nL_01D6:\n\tv874 = new System.Comparison`1<Obi.ObiStructuralElement>();\n\tSystem.Comparison`1<Obi.ObiStructuralElement>::.ctor(v874, v888.<>9, Il2CppMethodInfo);\n\tv877.<>9__40_0 = v874;\nL_01E8:\n\tSystem.Collections.Generic.List`1<Obi.ObiStructuralElement>::Sort(v60, v92);\n\tv946 = v60._size;\n\tv106 = v60._size < 1;\n\tif (v106) goto L_005F;\nL_01F8:\n\tv948 = v946 < v921;\n\tv949 = ~v948;\n\tv950 = v946 - v921;\n\tv952 = v950 == 0;\n\tv957 = ~v952;\n\tv958 = v949 & v957;\n\tif (v958) goto L_0206;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0206:\n\tv962 = v60._items;\n\tv192 = Obi.ObiRope::Tear(this, v962[v921 @ X22_v11 (System.Int32)]);\n\tv923 = v923 + v192;\n\tv977 = v923 >= this.tearRate;\n\tif (v977) goto L_0232;\n\tv946 = v60._size;\n\tv921 = v921 + 1;\n\tv926 = v921 < v60._size;\n\tif (v926) goto L_01F8;\nL_0232:\n\tv107 = v923 < 1;\n\tif (v107) goto L_005F;\n\tv295 = this->klass;\n\t// 581 IndirectJump [v295 @ X8_v47 (Il2CppClass<Obi.ObiRope>)+330], this @ X0 (Obi.ObiRope), this @ X0 (Obi.ObiRope), [v295 @ X8_v47 (Il2CppClass<Obi.ObiRope>)+338], [v295 @ X8_v47 (Il2CppClass<Obi.ObiRope>)+330], v72 @ X3_v7, 0, v41 @ X5, v42 @ X6, v43 @ X7, v67 @ V0_v6, this.tearResistanceMultiplier (System.Single), v46 @ V2, v47 @ V3, v48 @ V4, v49 @ V5, v50 @ V6, v51 @ V7\n\tv545 = new System.NullReferenceException();\nL_0248:\n\tv558 = new System.IndexOutOfRangeException();\n\tthrow v558;\n\treturn;\n// 400 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void ApplyTearing()
		{
			//IL_0109: Expected O, but got I
			//IL_0194: Unknown result type (might be due to invalid IL or missing references)
			//IL_0199: Expected O, but got Unknown
			//IL_01b6: Expected O, but got I
			//IL_01c5: Expected O, but got I
			//IL_0223: Expected O, but got I
			//IL_0155: Expected O, but got I
			//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b3: Expected O, but got Unknown
			//IL_02d0: Expected O, but got I
			//IL_02df: Expected O, but got I
			//IL_026f: Expected O, but got I
			//IL_07f0: Expected O, but got I4
			//IL_03f8: Expected O, but got I
			//IL_0407: Expected O, but got I
			//IL_0414: Expected F4, but got O
			//IL_0822: Expected O, but got I
			//IL_044b: Unsupported input type for neg.
			//IL_044b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0450: Expected O, but got Unknown
			//IL_0655: Expected I, but got O
			if (!tearingEnabled)
			{
				return;
			}
			List<ObiStructuralElement> list = new List<ObiStructuralElement>();
			IObiConstraints constraintsByType = GetConstraintsByType(Oni.ConstraintType.Distance);
			if (constraintsByType == null)
			{
				return;
			}
			ObiConstraints<ObiDistanceConstraintsBatch> obiConstraints = constraintsByType as ObiConstraints<ObiDistanceConstraintsBatch>;
			bool flag = obiConstraints != null;
			ObiConstraints<ObiDistanceConstraintsBatch> obiConstraints2 = constraintsByType as ObiConstraints<ObiDistanceConstraintsBatch>;
			IObiConstraints obiConstraints3 = ((obiConstraints2 == null) ? null : constraintsByType);
			if (!flag)
			{
				return;
			}
			int num = 0;
			IntPtr batch = default(IntPtr);
			object obj13 = default(object);
			while (true)
			{
				IList<IObiConstraintsBatch> batchInterfaces = ((ObiConstraints<ObiDistanceConstraintsBatch>)obiConstraints3).GetBatchInterfaces();
				IObiConstraintsBatch obiConstraintsBatch = batchInterfaces.get_Item(num);
				object obj = obiConstraintsBatch as IStructuralConstraintBatch;
				object obj2 = obj as IObiConstraintsBatch;
				object obj3 = obj as IObiConstraintsBatch;
				object obj4 = obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v635 @ X8_v23+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_016e;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v635 @ X8_v23+B0]");
				object obj5 = 0L + 8L;
				int num2 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v680 @ X11_v18-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IObiConstraintsBatch))
					{
						break;
					}
					num2++;
					int num3 = num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v635 @ X8_v23+126]");
					bool flag2 = (long)num3 < 0L;
					bool flag3 = !flag2;
					obj5 = (long)(IntPtr)obj5 + 16L;
					if (!flag3)
					{
						continue;
					}
					goto IL_016e;
				}
				object obj6 = obj5 + 1;
				int num4 = (int)((long)(IntPtr)obj6 << 4);
				object obj7 = (long)(IntPtr)obj4 + (long)num4;
				object obj8 = (long)(IntPtr)obj7 + 304L;
				int num5 = 0;
				goto IL_06f0;
				IL_0288:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				num5 = 6;
				goto IL_0743;
				IL_0743:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v774 @ X0_v33] (should have been resolved before IL gen)");
				float[] array;
				int batchConstraintForces = Oni.GetBatchConstraintForces(batch, array, array.Length, 0);
				int num6 = array.Length;
				if (array.Length >= 1)
				{
					int num7 = num;
					int num8 = 0;
					while (true)
					{
						List<ObiStructuralElement> list2 = elements;
						bool flag4 = list2.Count < num7;
						bool flag5 = !flag4;
						int num9 = list2.Count - num7;
						bool flag6 = num9 == 0;
						bool flag7 = !flag6;
						if (!(flag5 && flag7))
						{
							throw new ArgumentOutOfRangeException();
						}
						if (num8 >= num6)
						{
							break;
						}
						ObiStructuralElement[] items = list2._items;
						ObiStructuralElement obiStructuralElement = items[num7];
						int num10 = num8 << 2;
						object obj9 = (long)(IntPtr)array + (long)num10;
						object obj10 = (long)(IntPtr)obj9 + 32L;
						obiStructuralElement.constraintForce = (float)obj10;
						num6 = array.Length;
						if (num8 >= array.Length)
						{
							break;
						}
						object obj11 = 0 - obj10;
						if (tearResistanceMultiplier < (float)obj11)
						{
							List<ObiStructuralElement> list3 = elements;
							bool flag8 = list3.Count < num7;
							bool flag9 = !flag8;
							int num11 = list3.Count - num7;
							bool flag10 = num11 == 0;
							bool flag11 = !flag10;
							if (!(flag9 && flag11))
							{
								throw new ArgumentOutOfRangeException();
							}
							ObiStructuralElement[] items2 = list3._items;
							list.Add(items2[num7]);
							num6 = array.Length;
						}
						num8++;
						num7 += 2;
						if (num8 < num6)
						{
							continue;
						}
						goto IL_0524;
					}
					break;
				}
				goto IL_0524;
				IL_0524:
				int num12 = num + 1;
				bool flag12 = num < 1;
				num = num12;
				if (flag12)
				{
					continue;
				}
				if (list.Count < 1)
				{
					return;
				}
				Comparison<ObiStructuralElement> comparison = _003C_003Ec._003C_003E9__40_0;
				bool flag13 = _003C_003Ec._003C_003E9__40_0 == null;
				bool flag14 = !flag13;
				object obj12 = 0;
				if (!flag14)
				{
					Comparison<ObiStructuralElement> comparison2 = (_003C_003Ec._003C_003E9__40_0 = delegate(ObiStructuralElement x, ObiStructuralElement y)
					{
						//IL_000f: Expected O, but got I
						object obj21 = (long)(IntPtr)x + 28L;
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BCCD50 (inside System.Single::IsNaN +0x138)");
						int result = default(int);
						return result;
					});
					obj12 = 0;
					comparison = comparison2;
				}
				list.Sort(comparison);
				int count = list.Count;
				if (list.Count < 1)
				{
					return;
				}
				int num13 = 0;
				int num14 = 0;
				do
				{
					bool flag15 = count < num13;
					bool flag16 = !flag15;
					int num15 = count - num13;
					bool flag17 = num15 == 0;
					bool flag18 = !flag17;
					if (!(flag16 && flag18))
					{
						throw new ArgumentOutOfRangeException();
					}
					ObiStructuralElement[] items3 = list._items;
					bool flag19 = Tear(items3[num13]);
					num14 += (flag19 ? 1 : 0);
					if (num14 >= tearRate)
					{
						break;
					}
					count = list.Count;
					num13++;
				}
				while (num13 < list.Count);
				if (num14 < 1)
				{
					return;
				}
				IntPtr intPtr = (IntPtr)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v295 @ X8_v47 (Il2CppClass<Obi.ObiRope>)+330] (should have been resolved before IL gen)");
				break;
				IL_016e:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				num5 = 1;
				goto IL_06f0;
				IL_06f0:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v697 @ X0_v24] (should have been resolved before IL gen)");
				array = new float[obj13];
				object obj14 = obj as IObiConstraintsBatch;
				object obj15 = obj as IObiConstraintsBatch;
				object obj16 = obj15;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v712 @ X8_v29+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_0288;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v712 @ X8_v29+B0]");
				object obj17 = 0L + 8L;
				int num16 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v757 @ X11_v13-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IObiConstraintsBatch))
					{
						break;
					}
					num16++;
					int num17 = num16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v712 @ X8_v29+126]");
					bool flag20 = (long)num17 < 0L;
					bool flag21 = !flag20;
					obj17 = (long)(IntPtr)obj17 + 16L;
					if (!flag21)
					{
						continue;
					}
					goto IL_0288;
				}
				object obj18 = obj17 + 6;
				int num18 = (int)((long)(IntPtr)obj18 << 4);
				object obj19 = (long)(IntPtr)obj16 + (long)num18;
				object obj20 = (long)(IntPtr)obj19 + 304L;
				goto IL_0743;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000428")]
		[Address(RVA = "0xC374E8", Offset = "0xC374E8", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = Obi.ObiSolver::get_invMasses(this.m_Solver);\n\tv112 = Obi.ObiNativeFloatList::get_Item(v19, splitIndex);\n\tv22 = v21 + v21;\n\tv114 = Obi.ObiNativeFloatList::set_Item(v19, splitIndex, v22);\n\tv43 = Obi.ObiSolver::get_particleToActor(this.m_Solver);\n\tv151 = v43.Length < splitIndex;\n\tv88 = ~v151;\n\tv85 = v43.Length - splitIndex;\n\tv79 = v85 == 0;\n\tv152 = ~v88;\n\tv64 = v152 | v79;\n\tif (v64) goto L_005F;\n\tv95 = v43[splitIndex @ X1 (System.Int32)];\n\tv190 = Obi.ObiActor::CopyParticle(this, v95.indexInActor, this.m_ActiveParticleCount);\n\tv104 = Obi.ObiActor::ActivateParticle(this, this.m_ActiveParticleCount);\n\tv96 = this.solverIndices;\n\tv140 = this.m_ActiveParticleCount - 1;\n\tv193 = v140 < v96.Length;\n\tv136 = ~v193;\n\tif (v136) goto L_005F;\n\treturn v96[v140 @ X9_v8 (System.Int32)];\n\tthrow System.NullReferenceException;\n\tv106 = new System.NullReferenceException();\nL_005F:\n\tv147 = new System.IndexOutOfRangeException();\n\tthrow v147;\n\treturn returnVal1;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private int SplitParticle(int splitIndex)
		{
			ObiNativeFloatList invMasses = solver.invMasses;
			float num = invMasses.get_Item(splitIndex);
			object obj = default(object);
			float value = (float)obj + (float)obj;
			invMasses.set_Item(splitIndex, value);
			ObiSolver.ParticleInActor[] particleToActor = solver.particleToActor;
			bool flag = particleToActor.Length < splitIndex;
			bool flag2 = !flag;
			int num2 = particleToActor.Length - splitIndex;
			bool flag3 = num2 == 0;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				ObiSolver.ParticleInActor particleInActor = particleToActor[splitIndex];
				base.CopyParticle(particleInActor.indexInActor, activeParticleCount);
				bool flag5 = ActivateParticle(activeParticleCount);
				int[] array = solverIndices;
				int num3 = activeParticleCount - 1;
				if (num3 < array.Length)
				{
					return array[num3];
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000429")]
		[Address(RVA = "0xC373C4", Offset = "0xC373C4", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv24 = *([1EF7AD0]);\n\tv25 = *([v24 @ X8_v18]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, element, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20231B7]) = v43;\nL_001B:\n\tv48 = Obi.ObiActorBlueprint::get_particleCount(this.m_RopeBlueprint);\n\tv55 = this.m_ActiveParticleCount >= v48;\n\tif (v55) goto L_FFFFFFFF;\n\tv94 = Obi.ObiSolver::get_invMasses(this.m_Solver);\n\tv180 = Obi.ObiNativeFloatList::get_Item(v94, element.particle1);\n\tv75 = v33 == 0;\n\tif (v75) goto L_FFFFFFFF;\n\tv143 = System.Collections.Generic.List`1<Obi.ObiStructuralElement>::IndexOf(this.elements, element);\n\tv114 = v143 <= 0;\n\tif (v114) goto L_007B;\n\tv153 = this.elements;\n\tv109 = v143 - 1;\n\tv255 = v153._size < v109;\n\tv139 = ~v255;\n\tv136 = v153._size - v109;\n\tv130 = v136 == 0;\n\tv256 = ~v130;\n\tv115 = v139 & v256;\n\tif (v115) goto L_0067;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0067:\n\tv261 = v153._items;\n\tv151 = v261[v109 @ X22_v6 (System.Int32)];\n\tv211 = v151.particle2;\n\tv170 = v151.particle2 == element.particle1;\n\tif (v170) goto L_007D;\n\tgoto L_0087;\nL_007B:\n\tv211 = element.particle1;\nL_007D:\n\tv259 = Obi.ObiRope::SplitParticle(this, v211);\n\telement.particle1 = v259;\nL_0087:\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 101 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool Tear(ObiStructuralElement element)
		{
			int num = ropeBlueprint.particleCount;
			if (activeParticleCount < num)
			{
				ObiNativeFloatList invMasses = solver.invMasses;
				float num2 = invMasses.get_Item(element.particle1);
				object obj = default(object);
				if (obj != null)
				{
					int num3 = elements.IndexOf(element);
					int splitIndex;
					if (num3 > 0)
					{
						List<ObiStructuralElement> list = elements;
						int num4 = num3 - 1;
						bool flag = list.Count < num4;
						bool flag2 = !flag;
						int num5 = list.Count - num4;
						bool flag3 = num5 == 0;
						bool flag4 = !flag3;
						if (!(flag2 && flag4))
						{
							throw new ArgumentOutOfRangeException();
						}
						ObiStructuralElement[] items = list._items;
						ObiStructuralElement obiStructuralElement = items[num4];
						splitIndex = obiStructuralElement.particle2;
						if (obiStructuralElement.particle2 != element.particle1)
						{
							goto IL_0192;
						}
					}
					else
					{
						splitIndex = element.particle1;
					}
					int particle = SplitParticle(splitIndex);
					element.particle1 = particle;
					return true;
				}
			}
			goto IL_0192;
			IL_0192:
			return false;
		}

		[Token(Token = "0x600042A")]
		[Address(RVA = "0xC375EC", Offset = "0xC375EC", Length = "0x2E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv32 = *([1EDB498]);\n\tv33 = *([v32 @ X8_v32]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([20231B8]) = v52;\nL_001D:\n\tv56 = Obi.ObiActor::GetConstraintsByType(this, 4);\n\tv57 = v56 == 0;\n\tif (v57) goto L_0138;\n\tgoto L_FFFFFFFF;\n\tv95 = v95_asT == 0;\n\tif (v95) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tv103 = v103_asT == 0;\n\tif (v103) goto L_0138;\n\tv240 = *([v91 @ X23_v3 (Obi.IObiConstraints)+28]);\n\tv338 = *([v240 @ X20_v6+18]) == 0;\n\tv339 = ~v338;\n\tif (v339) goto L_0051;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0051:\n\tv367 = *([v240 @ X20_v6+10]);\n\tv325 = *([v367 @ X8_v10+20]);\n\tv262 = *([v91 @ X23_v3 (Obi.IObiConstraints)+28]);\n\tv368 = *([v262 @ X21_v5+18]) < 1;\n\tv296 = ~v368;\n\tv293 = *([v262 @ X21_v5+18]) - 1;\n\tv287 = v293 == 0;\n\tv369 = ~v287;\n\tv272 = v296 & v369;\n\tif (v272) goto L_0068;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0068:\n\tv371 = *([v262 @ X21_v5+10]);\n\tv326 = *([v371 @ X8_v12+28]);\n\tv151 = *([v326 @ X8_v13+34]) + *([v325 @ X8_v11+34]);\n\tv308 = new System.Collections.Generic.List`1<Obi.ObiStructuralElement>();\n\tSystem.Collections.Generic.List`1<Obi.ObiStructuralElement>::.ctor(v308, v151);\n\tthis.elements = v308;\n\tv89 = *([v91 @ X23_v3 (Obi.IObiConstraints)+28]);\nL_008B:\n\tv399 = v79 >= v151;\n\tif (v399) goto L_00EF;\n\tv403 = v79 < 0;\n\tv406 = v79 ^ v79;\n\tv407 = v79 & v406;\n\tv408 = v407 < 0;\n\tv410 = v403 == v408;\n\tv411 = ~v410;\n\tv268 = ~v411;\n\tif (v268) goto L_FFFFFFFF;\n\tv417 = v79 + 1;\n\tgoto L_009F;\nL_009F:\n\tv301 = v417 & 0xFFFFFFFE;\n\tv418 = v79 - v301;\n\tv419 = *([v89 @ X21_v8+18]) < v418;\n\tv297 = ~v419;\n\tv294 = *([v89 @ X21_v8+18]) - v418;\n\tv288 = v294 == 0;\n\tv420 = ~v288;\n\tv273 = v297 & v420;\n\tif (v273) goto L_00B1;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_00B1:\n\tv270 = v418 << 3;\n\tv328 = *([v89 @ X21_v8+10]) + v270;\n\tv243 = *([v328 @ X8_v26+20]);\n\tv309 = new Obi.ObiStructuralElement();\n\tObi.ObiStructuralElement::.ctor(v309);\n\tv351 = *([v243 @ X27_v8+40]);\n\tv329 = *([v351 @ X0_v26]);\n\tv257 = v79 & 0xFFFFFFFE;\n\t*([v329 @ X8_v27+180])(v310, v351, v257, *([v329 @ X8_v27+188]), v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv309.particle1 = v310;\n\tv352 = *([v243 @ X27_v8+40]);\n\tv364 = *([v352 @ X0_v28]);\n\tv344 = v79 | 1;\n\t*([v364 @ X8_v28+180])(v428, v352, v344, *([v364 @ X8_v28+188]), v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv309.particle2 = v428;\n\tv353 = *([v243 @ X27_v8+48]);\n\tv330 = *([v353 @ X0_v30]);\n\tv345 = v79 >> 1;\n\t*([v330 @ X8_v29+180])(v429, v353, v345, *([v330 @ X8_v29+188]), v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv309.restLength = v42;\n\tv309.tearResistance = 1f;\n\tSystem.Collections.Generic.List`1<Obi.ObiStructuralElement>::Add(this.elements, v309);\n\tv89 = *([v91 @ X23_v3 (Obi.IObiConstraints)+28]);\n\tv79 = v79 + 1;\n\tv430 = *([v91 @ X23_v3 (Obi.IObiConstraints)+28]) == 0;\n\tv321 = ~v430;\n\tif (v321) goto L_008B;\n\tgoto L_013A;\nL_00EF:\n\tv102 = *([v89 @ X21_v8+18]) < 3;\n\tif (v102) goto L_0138;\n\tv331 = *([v89 @ X21_v8+10]);\n\tv266 = *([v331 @ X8_v19+30]);\n\tv312 = new Obi.ObiStructuralElement();\n\tObi.ObiStructuralElement::.ctor(v312);\n\tv354 = *([v266 @ X21_v9+40]);\n\tv332 = *([v354 @ X0_v16]);\n\t*([v332 @ X8_v20+180])(v313, v354, 0, *([v332 @ X8_v20+188]), v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv312.particle1 = v313;\n\tv355 = *([v266 @ X21_v9+40]);\n\tv365 = *([v355 @ X0_v18]);\n\t*([v365 @ X8_v21+180])(v425, v355, 1, *([v365 @ X8_v21+188]), v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv312.particle2 = v425;\n\tv356 = *([v266 @ X21_v9+48]);\n\tv426 = *([v356 @ X0_v20]);\n\t*([v426 @ X8_v22+180])(v427, v356, 0, *([v426 @ X8_v22+188]), v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv312.restLength = v42;\n\tv312.tearResistance = 1f;\n\tSystem.Collections.Generic.List`1<Obi.ObiStructuralElement>::Add(this.elements, v312);\n\treturn;\nL_0138:\n\treturn;\nL_013A:\n\tthrow System.NullReferenceException;\n// 205 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void RebuildElementsFromConstraintsInternal()
		{
			//IL_005b: Expected O, but got I
			//IL_00ab: Expected O, but got I
			//IL_00bb: Expected O, but got I
			//IL_00d0: Expected O, but got I
			//IL_010d: Expected O, but got I
			//IL_015d: Expected O, but got I
			//IL_016d: Expected O, but got I
			//IL_01bc: Expected O, but got I
			//IL_041f: Expected O, but got I
			//IL_042f: Expected O, but got I
			//IL_044e: Expected O, but got I
			//IL_056b: Expected I4, but got I8
			//IL_0287: Expected O, but got I
			//IL_0297: Expected O, but got I
			//IL_0487: Expected O, but got I
			//IL_02b6: Expected O, but got I
			//IL_04bb: Expected O, but got I
			//IL_02d5: Expected I4, but got I8
			//IL_0301: Expected O, but got I
			//IL_0343: Expected O, but got I
			//IL_03a7: Expected O, but got I
			IObiConstraints constraintsByType = GetConstraintsByType(Oni.ConstraintType.Distance);
			if (constraintsByType == null)
			{
				return;
			}
			ObiConstraints<ObiDistanceConstraintsBatch> obiConstraints = constraintsByType as ObiConstraints<ObiDistanceConstraintsBatch>;
			if (obiConstraints != null)
			{
				IObiConstraints obiConstraints2 = constraintsByType;
			}
			else
			{
				IObiConstraints obiConstraints2 = null;
			}
			ObiConstraints<ObiDistanceConstraintsBatch> obiConstraints3 = constraintsByType as ObiConstraints<ObiDistanceConstraintsBatch>;
			if (obiConstraints3 == null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ X23_v3 (Obi.IObiConstraints)+28]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ X20_v6+18]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				throw new ArgumentOutOfRangeException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ X20_v6+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ X8_v10+20]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ X23_v3 (Obi.IObiConstraints)+28]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ X21_v5+18]");
			bool flag = 0L < 1L;
			bool flag2 = !flag;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ X21_v5+18]");
			object obj5 = -1;
			bool flag3 = obj5 == null;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ X21_v5+10]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v371 @ X8_v12+28]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ X8_v13+34]");
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v325 @ X8_v11+34]");
			int num = (int)((long)intPtr + 0L);
			List<ObiStructuralElement> list = new List<ObiStructuralElement>(num);
			elements = list;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ X23_v3 (Obi.IObiConstraints)+28]");
			object obj8 = 0;
			int num2 = 0;
			int particle = default(int);
			int particle2 = default(int);
			float num13 = default(float);
			int particle3 = default(int);
			int particle4 = default(int);
			do
			{
				if (num2 < num)
				{
					bool flag5 = num2 < 0;
					int num3 = num2 ^ num2;
					int num4 = num2 & num3;
					bool flag6 = num4 < 0;
					int num5 = ((flag5 == flag6) ? num2 : (num2 + 1));
					int num6 = (int)(num5 & 0xFFFFFFFEL);
					int num7 = num2 - num6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ X21_v8+18]");
					bool flag7 = 0L < (long)num7;
					bool flag8 = !flag7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ X21_v8+18]");
					int num8 = (int)(-num7);
					bool flag9 = num8 == 0;
					bool flag10 = !flag9;
					if (!(flag8 && flag10))
					{
						throw new ArgumentOutOfRangeException();
					}
					int num9 = num7 << 3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ X21_v8+10]");
					object obj9 = 0L + (long)num9;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ X8_v26+20]");
					object obj10 = 0;
					ObiStructuralElement obiStructuralElement = new ObiStructuralElement();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ X27_v8+40]");
					object obj11 = 0;
					object obj12 = obj11;
					int num10 = (int)(num2 & 0xFFFFFFFEL);
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v329 @ X8_v27+180] (should have been resolved before IL gen)");
					obiStructuralElement.particle1 = particle;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ X27_v8+40]");
					object obj13 = 0;
					object obj14 = obj13;
					int num11 = num2 | 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v364 @ X8_v28+180] (should have been resolved before IL gen)");
					obiStructuralElement.particle2 = particle2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ X27_v8+48]");
					object obj15 = 0;
					object obj16 = obj15;
					int num12 = num2 >> 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v330 @ X8_v29+180] (should have been resolved before IL gen)");
					obiStructuralElement.restLength = num13;
					obiStructuralElement.tearResistance = 1f;
					elements.Add(obiStructuralElement);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ X23_v3 (Obi.IObiConstraints)+28]");
					obj8 = 0;
					num2++;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ X23_v3 (Obi.IObiConstraints)+28]");
					continue;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ X21_v8+18]");
				if (0L >= 3L)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ X21_v8+10]");
					object obj17 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v331 @ X8_v19+30]");
					object obj18 = 0;
					ObiStructuralElement obiStructuralElement2 = new ObiStructuralElement();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ X21_v9+40]");
					object obj19 = 0;
					object obj20 = obj19;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v332 @ X8_v20+180] (should have been resolved before IL gen)");
					obiStructuralElement2.particle1 = particle3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ X21_v9+40]");
					object obj21 = 0;
					object obj22 = obj21;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v365 @ X8_v21+180] (should have been resolved before IL gen)");
					obiStructuralElement2.particle2 = particle4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ X21_v9+48]");
					object obj23 = 0;
					object obj24 = obj23;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v426 @ X8_v22+180] (should have been resolved before IL gen)");
					obiStructuralElement2.restLength = num13;
					obiStructuralElement2.tearResistance = 1f;
					elements.Add(obiStructuralElement2);
				}
				return;
			}
			while ((IntPtr)0 != (IntPtr)0);
			throw new NullReferenceException();
		}

		[Token(Token = "0x600042B")]
		[Address(RVA = "0xC378D0", Offset = "0xC378D0", Length = "0x8C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv38 = *([1ECC8A8]);\n\tv39 = *([v38 @ X8_v119]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv58 = 0 | 1;\n\t*([20231B9]) = v58;\nL_0020:\n\tv62 = Obi.ObiActor::GetConstraintsByType(this, 4);\n\tv63 = v62 == 0;\n\tif (v63) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_004B;\n\tv116 = v116_asT == 0;\n\tif (v116) goto L_FFFFFFFF;\n\tgoto L_004B;\nL_004B:\n\tv139 = Obi.ObiActor::GetConstraintsByType(this, 3);\n\tv140 = v139 == 0;\n\tif (v140) goto L_005F;\n\tgoto L_FFFFFFFF;\nL_005F:\n\tv169 = v121 == 0;\n\tv170 = ~v169;\n\tif (v170) goto L_007C;\n\tgoto L_03A4;\n\tv184 = v184_asT == 0;\n\tif (v184) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_007C:\n\tObi.ObiConstraints`1<Obi.ObiDistanceConstraintsBatch>::DeactivateAllConstraints(v121);\n\tObi.ObiConstraints`1<Obi.ObiBendConstraintsBatch>::DeactivateAllConstraints(v185);\n\tv682 = this.elements;\n\tv564 = this.m_RopeBlueprint;\n\tv565 = v564.path;\n\tv365 = v121.batches;\n\tv912 = v682._size - v565.m_Closed;\n\tv913 = v912 - 1;\nL_00A3:\n\tv938 = v358 >= v912;\n\tif (v938) goto L_0257;\n\tv942 = v358 < 0;\n\tv945 = v358 ^ v358;\n\tv946 = v358 & v945;\n\tv947 = v946 < 0;\n\tv949 = v942 == v947;\n\tv950 = ~v949;\n\tv395 = ~v950;\n\tif (v395) goto L_FFFFFFFF;\n\tv964 = v358 + 1;\n\tgoto L_00B7;\nL_00B7:\n\tv566 = v964 & 0xFFFFFFFE;\n\tv720 = v358 - v566;\n\tv965 = v365._size < v720;\n\tv541 = ~v965;\n\tv523 = v365._size - v720;\n\tv487 = v523 == 0;\n\tv966 = ~v487;\n\tv334 = v541 & v966;\n\tif (v334) goto L_00C7;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_00C7:\n\tv972 = v365._items;\n\tv362 = v972[v720 @ X20_v14 (System.Int32)];\n\tv721 = this.elements;\n\tv998 = v358 < v721._size;\n\tv542 = ~v998;\n\tv335 = ~v542;\n\tif (v335) goto L_00E0;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_00E0:\n\tv1002 = v721._items;\n\tv684 = v1002[v358 @ X28_v4 (System.Int32)];\n\tv288 = v362.m_ActiveConstraintCount << 1;\n\tv595 = Obi.ObiNativeIntList::set_Item(v362.particleIndices, v288, v684.particle1);\n\tv722 = this.elements;\n\tv317 = v362.particleIndices;\n\tv1011 = v358 < v722._size;\n\tv543 = ~v1011;\n\tv336 = ~v543;\n\tif (v336) goto L_0102;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0102:\n\tv1016 = v722._items;\n\tv686 = v1016[v358 @ X28_v4 (System.Int32)];\n\tv568 = *([v317 @ X25_v6 (Obi.ObiNativeIntList)]);\n\tv378 = v288 | 1;\n\tv597 = Obi.ObiNativeIntList::set_Item(v317, v378, v686.particle2);\n\tv723 = this.elements;\n\tv289 = *([v362 @ X22_v15 (Obi.ObiConstraintsBatch)+48]);\n\tv1031 = v358 < v723._size;\n\tv544 = ~v1031;\n\tv337 = ~v544;\n\tif (v337) goto L_0123;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0123:\n\tv1035 = v723._items;\n\tv688 = v1035[v358 @ X28_v4 (System.Int32)];\n\tv788 = *([v289 @ X24_v6]);\n\t*([v788 @ X9_v35+190])(v1043, v289, v362.m_ActiveConstraintCount, *([v788 @ X9_v35+198]), *([v568 @ X9_v34 (Il2CppClass<Obi.ObiNativeIntList>)+198]), v44, v45, v46, v47, v688.restLength, v246, v50, v51, v52, v53, v54, v55);\n\tv797 = *([v362 @ X22_v15 (Obi.ObiConstraintsBatch)+48]);\n\tv689 = *([v797 @ X0_v79]);\n\tv290 = *([v362 @ X22_v15 (Obi.ObiConstraintsBatch)+50]);\n\t*([v689 @ X8_v72+180])(v1045, v797, v362.m_ActiveConstraintCount, *([v689 @ X8_v72+188]), *([v568 @ X9_v34 (Il2CppClass<Obi.ObiNativeIntList>)+198]), v44, v45, v46, v47, v688.restLength, v246, v50, v51, v52, v53, v54, v55);\n\tv241 = this._maxCompression * v688.restLength;\n\tv236 = 0;\n\tv599 = 0x1588A6C(&v236 @ stack_-78_v7, 0, *([v689 @ X8_v72+188]), *([v568 @ X9_v34 (Il2CppClass<Obi.ObiNativeIntList>)+198]), v44, v45, v46, v47, this._stretchCompliance, v241, v50, v51, v52, v53, v54, v55);\n\tv1052 = *([v290 @ X24_v7]);\n\t*([v1052 @ X8_v73+190])(v1056, v290, v362.m_ActiveConstraintCount, *([v1052 @ X8_v73+198]), *([v568 @ X9_v34 (Il2CppClass<Obi.ObiNativeIntList>)+198]), v44, v45, v46, v47, 0, v1021, v50, v51, v52, v53, v54, v55);\n\tv600 = Obi.ObiConstraintsBatch::ActivateConstraint(v972[v720 @ X20_v14 (System.Int32)], v362.m_ActiveConstraintCount);\n\tv338 = v358 >= v913;\n\tif (v338) goto L_0245;\n\tv724 = v185.batches;\n\tv1066 = v358 * 0x55555556;\n\tv571 = v1066 >> 0x3F;\n\tv1067 = v1066 >> 0x20;\n\tv1068 = v1067 + v571;\n\tv402 = v1068 << 1;\n\tv691 = v1068 + v402;\n\tv219 = v358 - v691;\n\tv1069 = v724._size < v219;\n\tv546 = ~v1069;\n\tv528 = v724._size - v219;\n\tv492 = v528 == 0;\n\tv1070 = ~v492;\n\tv339 = v546 & v1070;\n\tif (v339) goto L_0178;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0178:\n\tv325 = this.elements;\n\tv1085 = v724._items;\n\tv1089 = v358 < v325._size;\n\tv547 = ~v1089;\n\tv340 = ~v547;\n\tif (v340) goto L_018E;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_018E:\n\tv1093 = v325._items;\n\tv692 = v1093[v358 @ X28_v4 (System.Int32)];\n\tv291 = this.elements;\n\tv726 = v358 + 1;\n\tv1097 = v726 < v291._size;\n\tv548 = ~v1097;\n\tv341 = ~v548;\n\tif (v341) goto L_01A8;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_01A8:\n\tv573 = v726 << 0x20;\n\tv404 = v573 >> 0x1D;\n\tv1103 = v291._items + v404;\n\tv693 = *([v1103 @ X8_v89+20]);\n\tv342 = v692.particle2 != *([v693 @ X8_v90+10]);\n\tif (v342) goto L_0246;\n\tv327 = v1085[v219 @ X21_v13 (System.Int32)];\n\tv292 = this.elements;\n\tv1114 = v358 < v292._size;\n\tv550 = ~v1114;\n\tv343 = ~v550;\n\tif (v343) goto L_01D0;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_01D0:\n\tv1116 = v292._items;\n\tv695 = v1116[v358 @ X28_v4 (System.Int32)];\n\tv406 = v327.m_ActiveConstraintCount << 1;\n\tv293 = v327.m_ActiveConstraintCount + v406;\n\tv605 = Obi.ObiNativeIntList::set_Item(v327.particleIndices, v293, v695.particle1);\n\tv221 = this.elements;\n\tv1126 = v726 < v221._size;\n\tv551 = ~v1126;\n\tv344 = ~v551;\n\tif (v344) goto L_01F5;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_01F5:\n\tv1128 = v221._items;\n\tv697 = v1128[v726 @ X20_v18 (System.Int32)];\n\tv329 = v1085[v219 @ X21_v13 (System.Int32)];\n\tv382 = v293 + 1;\n\tv607 = Obi.ObiNativeIntList::set_Item(v327.particleIndices, v382, v697.particle2);\n\tv222 = this.elements;\n\tv320 = v329.particleIndices;\n\tv1132 = v358 < v222._size;\n\tv552 = ~v1132;\n\tv345 = ~v552;\n\tif (v345) goto L_0217;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0217:\n\tv1134 = v222._items;\n\tv699 = v1134[v358 @ X28_v4 (System.Int32)];\n\tv789 = *([v320 @ X25_v10 (Obi.ObiNativeIntList)]);\n\tv767 = v293 + 2;\n\tv1137 = Obi.ObiNativeIntList::set_Item(v320, v767, v699.particle2);\n\tv798 = *([v329 @ X23_v13 (Obi.ObiConstraintsBatch)+48]);\n\tv700 = *([v798 @ X0_v100]);\n\t*([v700 @ X8_v107+190])(v1140, v798, v327.m_ActiveConstraintCount, *([v700 @ X8_v107+198]), *([v789 @ X9_v45 (Il2CppClass<Obi.ObiNativeIntList>)+198]), v44, v45, v46, v47, 0, v1021, v50, v51, v52, v53, v54, v55);\n\tv294 = *([v329 @ X23_v13 (Obi.ObiConstraintsBatch)+50]);\n\tv236 = 0;\n\tv609 = 0x1588A6C(&v236 @ stack_-78_v7, 0, *([v700 @ X8_v107+198]), *([v789 @ X9_v45 (Il2CppClass<Obi.ObiNativeIntList>)+198]), v44, v45, v46, v47, this._maxBending, this._bendCompliance, v50, v51, v52, v53, v54, v55);\n\tv1079 = *([v294 @ X24_v12]);\n\t*([v1079 @ X8_v108+190])(v1145, v294, v327.m_ActiveConstraintCount, *([v1079 @ X8_v108+198]), *([v789 @ X9_v45 (Il2CppClass<Obi.ObiNativeIntList>)+198]), v44, v45, v46, v47, 0, v1021, v50, v51, v52, v53, v54, v55);\n\tv1077 = Obi.ObiConstraintsBatch::ActivateConstraint(v1085[v219 @ X21_v13 (System.Int32)], v327.m_ActiveConstraintCount);\n\tgoto L_0246;\nL_0245:\n\tv726 = v358 + 1;\nL_0246:\n\tv365 = v121.batches;\n\tv1080 = v121.batches == 0;\n\tv659 = ~v1080;\n\tif (v659) goto L_00A3;\n\tgoto L_03A4;\nL_0257:\n\tv347 = v365._size < 3;\n\tif (v347) goto L_02A7;\n\tv727 = this.elements;\n\tv703 = v365._items;\n\tv224 = v703[2];\n\tv967 = v727._size == 0;\n\tv968 = ~v967;\n\tif (v968) goto L_0266;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0266:\n\tv994 = v727._items;\n\tv579 = v727._size - 1;\n\tv728 = v994[v579 @ X9_v25 (System.Int32)];\n\tv1004 = Obi.ObiNativeIntList::set_Item(v224.particleIndices, 0, v728.particle1);\n\tv800 = v224.particleIndices;\n\tv824 = *([v800 @ X0_v56 (Obi.ObiNativeIntList)]);\n\tv1006 = Obi.ObiNativeIntList::set_Item(v800, 1, v728.particle2);\n\tv801 = *([v224 @ X21_v11 (Obi.ObiConstraintsBatch)+48]);\n\tv825 = *([v801 @ X0_v58]);\n\t*([v825 @ X8_v51+190])(v1009, v801, 0, *([v825 @ X8_v51+198]), *([v824 @ X8_v50 (Il2CppClass<Obi.ObiNativeI\n// ... truncated")]
		public override void RebuildConstraintsFromElements()
		{
			//IL_10e1: Expected I4, but got I8
			//IL_0ab9: Expected I, but got O
			//IL_0ae0: Expected O, but got I
			//IL_0b07: Expected O, but got I
			//IL_0b24: Expected O, but got I
			//IL_0b4d: Expected O, but got I4
			//IL_033c: Expected I, but got O
			//IL_037f: Expected O, but got I
			//IL_0d7b: Expected I, but got O
			//IL_0da2: Expected O, but got I
			//IL_0dc9: Expected O, but got I
			//IL_0dd2: Expected O, but got I4
			//IL_0406: Expected O, but got I
			//IL_0423: Expected O, but got I
			//IL_044c: Expected O, but got I4
			//IL_0fd5: Expected I, but got O
			//IL_0ffc: Expected O, but got I
			//IL_1023: Expected O, but got I
			//IL_102c: Expected O, but got I4
			//IL_06a0: Expected O, but got I
			//IL_06b0: Expected O, but got I
			//IL_08ef: Expected I, but got O
			//IL_0923: Expected O, but got I
			//IL_094a: Expected O, but got I
			//IL_0953: Expected O, but got I4
			IObiConstraints constraintsByType = GetConstraintsByType(Oni.ConstraintType.Distance);
			ObiConstraints<ObiDistanceConstraintsBatch> obiConstraints;
			if (constraintsByType == null)
			{
				obiConstraints = null;
			}
			else
			{
				ObiConstraints<ObiDistanceConstraintsBatch> obiConstraints2 = constraintsByType as ObiConstraints<ObiDistanceConstraintsBatch>;
				obiConstraints = (ObiConstraints<ObiDistanceConstraintsBatch>)((obiConstraints2 == null) ? null : constraintsByType);
			}
			IObiConstraints constraintsByType2 = GetConstraintsByType(Oni.ConstraintType.Bending);
			ObiConstraints<ObiBendConstraintsBatch> obiConstraints3;
			if (constraintsByType2 == null)
			{
				bool flag = obiConstraints == null;
				bool flag2 = !flag;
				obiConstraints3 = null;
				if (!flag2)
				{
					goto IL_1153;
				}
			}
			else
			{
				ObiConstraints<ObiBendConstraintsBatch> obiConstraints4 = constraintsByType2 as ObiConstraints<ObiBendConstraintsBatch>;
				IObiConstraints obiConstraints5 = ((obiConstraints4 == null) ? null : constraintsByType2);
				obiConstraints3 = (ObiConstraints<ObiBendConstraintsBatch>)obiConstraints5;
			}
			obiConstraints.DeactivateAllConstraints();
			obiConstraints3.DeactivateAllConstraints();
			List<ObiStructuralElement> list = elements;
			ObiRopeBlueprint obiRopeBlueprint = ropeBlueprint;
			ObiPath obiPath = obiRopeBlueprint.path;
			List<ObiDistanceConstraintsBatch> batches = obiConstraints.batches;
			int num = list.Count - (obiPath.Closed ? 1 : 0);
			int num2 = num - 1;
			int num3 = 0;
			object obj11 = default(object);
			bool flag17;
			do
			{
				if (num3 < num)
				{
					bool flag3 = num3 < 0;
					int num4 = num3 ^ num3;
					int num5 = num3 & num4;
					bool flag4 = num5 < 0;
					int num6 = ((flag3 == flag4) ? num3 : (num3 + 1));
					int num7 = (int)(num6 & 0xFFFFFFFEL);
					int num8 = num3 - num7;
					bool flag5 = batches.Count < num8;
					bool flag6 = !flag5;
					int num9 = batches.Count - num8;
					bool flag7 = num9 == 0;
					bool flag8 = !flag7;
					if (!(flag6 && flag8))
					{
						throw new ArgumentOutOfRangeException();
					}
					ObiDistanceConstraintsBatch[] items = batches._items;
					ObiConstraintsBatch obiConstraintsBatch = items[num8];
					List<ObiStructuralElement> list2 = elements;
					if (num3 >= list2.Count)
					{
						throw new ArgumentOutOfRangeException();
					}
					ObiStructuralElement[] items2 = list2._items;
					ObiStructuralElement obiStructuralElement = items2[num3];
					int num10 = obiConstraintsBatch.activeConstraintCount << 1;
					obiConstraintsBatch.particleIndices.set_Item(num10, obiStructuralElement.particle1);
					List<ObiStructuralElement> list3 = elements;
					ObiNativeIntList particleIndices = obiConstraintsBatch.particleIndices;
					if (num3 >= list3.Count)
					{
						throw new ArgumentOutOfRangeException();
					}
					ObiStructuralElement[] items3 = list3._items;
					ObiStructuralElement obiStructuralElement2 = items3[num3];
					IntPtr intPtr = (IntPtr)particleIndices;
					int index = num10 | 1;
					particleIndices.set_Item(index, obiStructuralElement2.particle2);
					List<ObiStructuralElement> list4 = elements;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v362 @ X22_v15 (Obi.ObiConstraintsBatch)+48]");
					object obj = 0;
					if (num3 >= list4.Count)
					{
						throw new ArgumentOutOfRangeException();
					}
					ObiStructuralElement[] items4 = list4._items;
					ObiStructuralElement obiStructuralElement3 = items4[num3];
					object obj2 = obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v788 @ X9_v35+190] (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v362 @ X22_v15 (Obi.ObiConstraintsBatch)+48]");
					object obj3 = 0;
					object obj4 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v362 @ X22_v15 (Obi.ObiConstraintsBatch)+50]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v689 @ X8_v72+180] (should have been resolved before IL gen)");
					float num11 = maxCompression * obiStructuralElement3.restLength;
					object obj6 = 0;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
					object obj7 = obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1052 @ X8_v73+190] (should have been resolved before IL gen)");
					bool flag9 = items[num8].ActivateConstraint(obiConstraintsBatch.activeConstraintCount);
					int num20;
					if (num3 < num2)
					{
						List<ObiBendConstraintsBatch> batches2 = obiConstraints3.batches;
						int num12 = num3 * 1431655766;
						int num13 = num12 >> 63;
						int num14 = num12 >> 32;
						int num15 = num14 + num13;
						int num16 = num15 << 1;
						int num17 = num15 + num16;
						int num18 = num3 - num17;
						bool flag10 = batches2.Count < num18;
						bool flag11 = !flag10;
						int num19 = batches2.Count - num18;
						bool flag12 = num19 == 0;
						bool flag13 = !flag12;
						if (!(flag11 && flag13))
						{
							throw new ArgumentOutOfRangeException();
						}
						List<ObiStructuralElement> list5 = elements;
						ObiBendConstraintsBatch[] items5 = batches2._items;
						if (num3 >= list5.Count)
						{
							throw new ArgumentOutOfRangeException();
						}
						ObiStructuralElement[] items6 = list5._items;
						ObiStructuralElement obiStructuralElement4 = items6[num3];
						List<ObiStructuralElement> list6 = elements;
						num20 = num3 + 1;
						if (num20 >= list6.Count)
						{
							throw new ArgumentOutOfRangeException();
						}
						int num21 = num20 << 32;
						int num22 = num21 >> 29;
						object obj8 = (long)(IntPtr)list6._items + (long)num22;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1103 @ X8_v89+20]");
						object obj9 = 0;
						int particle = obiStructuralElement4.particle2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v693 @ X8_v90+10]");
						bool flag14 = (IntPtr)particle != (IntPtr)0;
						object obj10 = obj11;
						if (!flag14)
						{
							ObiConstraintsBatch obiConstraintsBatch2 = items5[num18];
							List<ObiStructuralElement> list7 = elements;
							if (num3 >= list7.Count)
							{
								throw new ArgumentOutOfRangeException();
							}
							ObiStructuralElement[] items7 = list7._items;
							ObiStructuralElement obiStructuralElement5 = items7[num3];
							int num23 = obiConstraintsBatch2.activeConstraintCount << 1;
							int num24 = obiConstraintsBatch2.activeConstraintCount + num23;
							obiConstraintsBatch2.particleIndices.set_Item(num24, obiStructuralElement5.particle1);
							List<ObiStructuralElement> list8 = elements;
							if (num20 >= list8.Count)
							{
								throw new ArgumentOutOfRangeException();
							}
							ObiStructuralElement[] items8 = list8._items;
							ObiStructuralElement obiStructuralElement6 = items8[num20];
							ObiConstraintsBatch obiConstraintsBatch3 = items5[num18];
							int index2 = num24 + 1;
							obiConstraintsBatch2.particleIndices.set_Item(index2, obiStructuralElement6.particle2);
							List<ObiStructuralElement> list9 = elements;
							ObiNativeIntList particleIndices2 = obiConstraintsBatch3.particleIndices;
							if (num3 >= list9.Count)
							{
								throw new ArgumentOutOfRangeException();
							}
							ObiStructuralElement[] items9 = list9._items;
							ObiStructuralElement obiStructuralElement7 = items9[num3];
							IntPtr intPtr2 = (IntPtr)particleIndices2;
							int index3 = num24 + 2;
							particleIndices2.set_Item(index3, obiStructuralElement7.particle2);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ X23_v13 (Obi.ObiConstraintsBatch)+48]");
							object obj12 = 0;
							object obj13 = obj12;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v700 @ X8_v107+190] (should have been resolved before IL gen)");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ X23_v13 (Obi.ObiConstraintsBatch)+50]");
							object obj14 = 0;
							obj6 = 0;
							Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
							object obj15 = obj14;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1079 @ X8_v108+190] (should have been resolved before IL gen)");
							bool flag15 = items5[num18].ActivateConstraint(obiConstraintsBatch2.activeConstraintCount);
							obj10 = obj11;
						}
					}
					else
					{
						num20 = num3 + 1;
						object obj10 = obj11;
					}
					batches = obiConstraints.batches;
					bool flag16 = obiConstraints.batches == null;
					flag17 = !flag16;
					num3 = num20;
					continue;
				}
				if (batches.Count >= 3)
				{
					List<ObiStructuralElement> list10 = elements;
					ObiDistanceConstraintsBatch[] items10 = batches._items;
					ObiConstraintsBatch obiConstraintsBatch4 = items10[2];
					if (list10.Count == 0)
					{
						throw new ArgumentOutOfRangeException();
					}
					ObiStructuralElement[] items11 = list10._items;
					int num25 = list10.Count - 1;
					ObiStructuralElement obiStructuralElement8 = items11[num25];
					obiConstraintsBatch4.particleIndices.set_Item(0, obiStructuralElement8.particle1);
					ObiNativeIntList particleIndices3 = obiConstraintsBatch4.particleIndices;
					IntPtr intPtr3 = (IntPtr)particleIndices3;
					particleIndices3.set_Item(1, obiStructuralElement8.particle2);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ X21_v11 (Obi.ObiConstraintsBatch)+48]");
					object obj16 = 0;
					object obj17 = obj16;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v825 @ X8_v51+190] (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ X21_v11 (Obi.ObiConstraintsBatch)+48]");
					object obj18 = 0;
					object obj19 = obj18;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ X21_v11 (Obi.ObiConstraintsBatch)+50]");
					object obj20 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v705 @ X8_v52+180] (should have been resolved before IL gen)");
					float num26 = maxCompression * obiStructuralElement8.restLength;
					object obj6 = 0;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
					object obj21 = obj20;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v963 @ X8_v53+190] (should have been resolved before IL gen)");
					bool flag18 = obiConstraintsBatch4.ActivateConstraint(0);
					object obj10 = obj11;
				}
				List<ObiBendConstraintsBatch> batches3 = obiConstraints3.batches;
				if (batches3.Count < 5)
				{
					return;
				}
				List<ObiStructuralElement> list11 = elements;
				if (list11.Count >= 3)
				{
					ObiBendConstraintsBatch[] items12 = batches3._items;
					ObiConstraintsBatch obiConstraintsBatch5 = items12[3];
					bool flag19 = list11.Count < 1;
					bool flag20 = !flag19;
					int num27 = list11.Count - 1;
					bool flag21 = num27 == 0;
					bool flag22 = !flag21;
					if (!(flag20 && flag22))
					{
						throw new ArgumentOutOfRangeException();
					}
					ObiStructuralElement[] items13 = list11._items;
					int num28 = list11.Count - 2;
					ObiStructuralElement obiStructuralElement9 = items13[num28];
					obiConstraintsBatch5.particleIndices.set_Item(0, obiStructuralElement9.particle1);
					List<ObiStructuralElement> list12 = elements;
					if (list12.Count == 0)
					{
						throw new ArgumentOutOfRangeException();
					}
					ObiStructuralElement[] items14 = list12._items;
					ObiStructuralElement obiStructuralElement10 = items14[0];
					obiConstraintsBatch5.particleIndices.set_Item(1, obiStructuralElement10.particle1);
					ObiNativeIntList particleIndices4 = obiConstraintsBatch5.particleIndices;
					IntPtr intPtr4 = (IntPtr)particleIndices4;
					particleIndices4.set_Item(2, obiStructuralElement9.particle2);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ X21_v7 (Obi.ObiConstraintsBatch)+48]");
					object obj22 = 0;
					object obj23 = obj22;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v711 @ X8_v31+190] (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ X21_v7 (Obi.ObiConstraintsBatch)+50]");
					object obj24 = 0;
					object obj6 = 0;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
					object obj25 = obj24;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v712 @ X8_v32+190] (should have been resolved before IL gen)");
					bool flag23 = obiConstraintsBatch5.ActivateConstraint(0);
					List<ObiBendConstraintsBatch> batches4 = obiConstraints3.batches;
					bool flag24 = batches4.Count < 4;
					bool flag25 = !flag24;
					int num29 = batches4.Count - 4;
					bool flag26 = num29 == 0;
					bool flag27 = !flag26;
					if (!(flag25 && flag27))
					{
						throw new ArgumentOutOfRangeException();
					}
					ObiBendConstraintsBatch[] items15 = batches4._items;
					ObiConstraintsBatch obiConstraintsBatch6 = items15[4];
					obiConstraintsBatch6.particleIndices.set_Item(0, obiStructuralElement9.particle2);
					List<ObiStructuralElement> list13 = elements;
					if (list13.Count == 0)
					{
						throw new ArgumentOutOfRangeException();
					}
					ObiStructuralElement[] items16 = list13._items;
					ObiStructuralElement obiStructuralElement11 = items16[0];
					obiConstraintsBatch6.particleIndices.set_Item(1, obiStructuralElement11.particle2);
					List<ObiStructuralElement> list14 = elements;
					ObiNativeIntList particleIndices5 = obiConstraintsBatch6.particleIndices;
					if (list14.Count == 0)
					{
						throw new ArgumentOutOfRangeException();
					}
					ObiStructuralElement[] items17 = list14._items;
					ObiStructuralElement obiStructuralElement12 = items17[0];
					IntPtr intPtr5 = (IntPtr)particleIndices5;
					particleIndices5.set_Item(2, obiStructuralElement12.particle1);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v733 @ X20_v11 (Obi.ObiConstraintsBatch)+48]");
					object obj26 = 0;
					object obj27 = obj26;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v718 @ X8_v44+190] (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v733 @ X20_v11 (Obi.ObiConstraintsBatch)+50]");
					object obj28 = 0;
					object obj29 = 0;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
					object obj30 = obj28;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v992 @ X8_v45+190] (should have been resolved before IL gen)");
					bool flag28 = obiConstraintsBatch6.ActivateConstraint(0);
				}
				return;
			}
			while (flag17);
			goto IL_1153;
			IL_1153:
			throw new NullReferenceException();
		}

		[Token(Token = "0x600042C")]
		[Address(RVA = "0xC38190", Offset = "0xC38190", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.tearResistanceMultiplier = 1000f;\n\tthis._distanceConstraintsEnabled = 1;\n\tthis._bendConstraintsEnabled = 1;\n\tObi.ObiRopeBase::.ctor(this);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiRope()
		{
			tearResistanceMultiplier = 1000f;
			_distanceConstraintsEnabled = true;
			_bendConstraintsEnabled = true;
		}
	}
}
