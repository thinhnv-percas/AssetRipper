using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x744C30", Offset = "0x744C30")]
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	[Token(Token = "0x200005F")]
	public class ObiRod : ObiRopeBase
	{
		[SerializeField]
		[Token(Token = "0x40001B4")]
		[FieldOffset(Offset = "0x98")]
		protected ObiRodBlueprint m_RodBlueprint;

		[SerializeField]
		[Token(Token = "0x40001B5")]
		[FieldOffset(Offset = "0xA0")]
		protected bool _stretchShearConstraintsEnabled;

		[SerializeField]
		[Token(Token = "0x40001B6")]
		[FieldOffset(Offset = "0xA4")]
		protected float _stretchCompliance;

		[SerializeField]
		[Token(Token = "0x40001B7")]
		[FieldOffset(Offset = "0xA8")]
		protected float _shear1Compliance;

		[SerializeField]
		[Token(Token = "0x40001B8")]
		[FieldOffset(Offset = "0xAC")]
		protected float _shear2Compliance;

		[SerializeField]
		[Token(Token = "0x40001B9")]
		[FieldOffset(Offset = "0xB0")]
		protected bool _bendTwistConstraintsEnabled;

		[SerializeField]
		[Token(Token = "0x40001BA")]
		[FieldOffset(Offset = "0xB4")]
		protected float _torsionCompliance;

		[SerializeField]
		[Token(Token = "0x40001BB")]
		[FieldOffset(Offset = "0xB8")]
		protected float _bend1Compliance;

		[SerializeField]
		[Token(Token = "0x40001BC")]
		[FieldOffset(Offset = "0xBC")]
		protected float _bend2Compliance;

		[SerializeField]
		[Token(Token = "0x40001BD")]
		[FieldOffset(Offset = "0xC0")]
		protected bool _chainConstraintsEnabled;

		[SerializeField]
		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x74643C", Offset = "0x74643C")]
		[Token(Token = "0x40001BE")]
		[FieldOffset(Offset = "0xC4")]
		protected float _tightness;

		[Token(Token = "0x17000096")]
		public bool selfCollisions
		{
			[Token(Token = "0x60003F7")]
			[Address(RVA = "0xC33AEC", Offset = "0xC33AEC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_SelfCollisions;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return m_SelfCollisions;
			}
			[Token(Token = "0x60003F8")]
			[Address(RVA = "0xC33AF4", Offset = "0xC33AF4", Length = "0x30")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.m_SelfCollisions == 0;\n\tv11 = ~v6;\n\tv13 = v11 ^ value;\n\tv16 = v13 == 0;\n\tif (v16) goto L_0016;\n\tv17 = this->klass;\n\tthis.m_SelfCollisions = value;\n\tv19 = this->klass->vtable[22];\n\tv20 = this->klass->vtable[22];\n\t// 21 IndirectJump v19 @ X3_v1, this @ X0 (Obi.ObiRod), this @ X0 (Obi.ObiRod), value @ X1 (System.Boolean), v20 @ X2_v1, v19 @ X3_v1, v21 @ X4, v22 @ X5, v23 @ X6, v24 @ X7, v25 @ V0, v26 @ V1, v27 @ V2, v28 @ V3, v29 @ V4, v30 @ V5, v31 @ V6, v32 @ V7\nL_0016:\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ X8_v4 (Il2CppClass<Obi.ObiRod>)+290]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ X8_v4 (Il2CppClass<Obi.ObiRod>)+298]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v19 @ X3_v1 (should have been resolved before IL gen)");
				}
			}
		}

		[Token(Token = "0x17000097")]
		public bool stretchShearConstraintsEnabled
		{
			[Token(Token = "0x60003F9")]
			[Address(RVA = "0xC33B24", Offset = "0xC33B24", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._stretchShearConstraintsEnabled;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return stretchShearConstraintsEnabled;
			}
			[Token(Token = "0x60003FA")]
			[Address(RVA = "0xC33B2C", Offset = "0xC33B2C", Length = "0x30")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this._stretchShearConstraintsEnabled == 0;\n\tv11 = ~v6;\n\tv13 = v11 ^ value;\n\tv16 = v13 == 0;\n\tif (v16) goto L_0018;\n\tthis._stretchShearConstraintsEnabled = value;\n\tObi.ObiActor::PushStretchShearConstraints(this, value, this._stretchCompliance, this._shear1Compliance, this._shear2Compliance);\n\treturn;\nL_0018:\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				bool flag = !stretchShearConstraintsEnabled;
				bool flag2 = !flag;
				if (flag2 ^ value)
				{
					_stretchShearConstraintsEnabled = value;
					PushStretchShearConstraints(value, stretchCompliance, shear1Compliance, shear2Compliance);
				}
			}
		}

		[Token(Token = "0x17000098")]
		public float stretchCompliance
		{
			[Token(Token = "0x60003FB")]
			[Address(RVA = "0xC33B5C", Offset = "0xC33B5C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._stretchCompliance;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return stretchCompliance;
			}
			[Token(Token = "0x60003FC")]
			[Address(RVA = "0xC33B64", Offset = "0xC33B64", Length = "0x14")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._stretchCompliance = value;\n\tObi.ObiActor::PushStretchShearConstraints(this, this._stretchShearConstraintsEnabled, value, this._shear1Compliance, this._shear2Compliance);\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_stretchCompliance = value;
				PushStretchShearConstraints(stretchShearConstraintsEnabled, value, shear1Compliance, shear2Compliance);
			}
		}

		[Token(Token = "0x17000099")]
		public float shear1Compliance
		{
			[Token(Token = "0x60003FD")]
			[Address(RVA = "0xC33B78", Offset = "0xC33B78", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._shear1Compliance;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return shear1Compliance;
			}
			[Token(Token = "0x60003FE")]
			[Address(RVA = "0xC33B80", Offset = "0xC33B80", Length = "0x24")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._shear1Compliance = value;\n\tObi.ObiActor::PushStretchShearConstraints(this, this._stretchShearConstraintsEnabled, this._stretchCompliance, value, this._shear2Compliance);\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_shear1Compliance = value;
				PushStretchShearConstraints(stretchShearConstraintsEnabled, stretchCompliance, value, shear2Compliance);
			}
		}

		[Token(Token = "0x1700009A")]
		public float shear2Compliance
		{
			[Token(Token = "0x60003FF")]
			[Address(RVA = "0xC33BA4", Offset = "0xC33BA4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._shear2Compliance;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return shear2Compliance;
			}
			[Token(Token = "0x6000400")]
			[Address(RVA = "0xC33BAC", Offset = "0xC33BAC", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._shear2Compliance = value;\n\tObi.ObiActor::PushStretchShearConstraints(this, this._stretchShearConstraintsEnabled, this._stretchCompliance, this._shear1Compliance, value);\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_shear2Compliance = value;
				PushStretchShearConstraints(stretchShearConstraintsEnabled, stretchCompliance, shear1Compliance, value);
			}
		}

		[Token(Token = "0x1700009B")]
		public bool bendTwistConstraintsEnabled
		{
			[Token(Token = "0x6000401")]
			[Address(RVA = "0xC33BCC", Offset = "0xC33BCC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._bendTwistConstraintsEnabled;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return bendTwistConstraintsEnabled;
			}
			[Token(Token = "0x6000402")]
			[Address(RVA = "0xC33BD4", Offset = "0xC33BD4", Length = "0x30")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this._bendTwistConstraintsEnabled == 0;\n\tv11 = ~v6;\n\tv13 = v11 ^ value;\n\tv16 = v13 == 0;\n\tif (v16) goto L_0018;\n\tthis._bendTwistConstraintsEnabled = value;\n\tObi.ObiActor::PushBendTwistConstraints(this, value, this._torsionCompliance, this._bend1Compliance, this._bend2Compliance);\n\treturn;\nL_0018:\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				bool flag = !bendTwistConstraintsEnabled;
				bool flag2 = !flag;
				if (flag2 ^ value)
				{
					_bendTwistConstraintsEnabled = value;
					PushBendTwistConstraints(value, torsionCompliance, bend1Compliance, bend2Compliance);
				}
			}
		}

		[Token(Token = "0x1700009C")]
		public float torsionCompliance
		{
			[Token(Token = "0x6000403")]
			[Address(RVA = "0xC33C04", Offset = "0xC33C04", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._torsionCompliance;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return torsionCompliance;
			}
			[Token(Token = "0x6000404")]
			[Address(RVA = "0xC33C0C", Offset = "0xC33C0C", Length = "0x14")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._torsionCompliance = value;\n\tObi.ObiActor::PushBendTwistConstraints(this, this._bendTwistConstraintsEnabled, value, this._bend1Compliance, this._bend2Compliance);\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_torsionCompliance = value;
				PushBendTwistConstraints(bendTwistConstraintsEnabled, value, bend1Compliance, bend2Compliance);
			}
		}

		[Token(Token = "0x1700009D")]
		public float bend1Compliance
		{
			[Token(Token = "0x6000405")]
			[Address(RVA = "0xC33C20", Offset = "0xC33C20", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._bend1Compliance;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return bend1Compliance;
			}
			[Token(Token = "0x6000406")]
			[Address(RVA = "0xC33C28", Offset = "0xC33C28", Length = "0x24")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._bend1Compliance = value;\n\tObi.ObiActor::PushBendTwistConstraints(this, this._bendTwistConstraintsEnabled, this._torsionCompliance, value, this._bend2Compliance);\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_bend1Compliance = value;
				PushBendTwistConstraints(bendTwistConstraintsEnabled, torsionCompliance, value, bend2Compliance);
			}
		}

		[Token(Token = "0x1700009E")]
		public float bend2Compliance
		{
			[Token(Token = "0x6000407")]
			[Address(RVA = "0xC33C4C", Offset = "0xC33C4C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._bend2Compliance;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return bend2Compliance;
			}
			[Token(Token = "0x6000408")]
			[Address(RVA = "0xC33C54", Offset = "0xC33C54", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._bend2Compliance = value;\n\tObi.ObiActor::PushBendTwistConstraints(this, this._bendTwistConstraintsEnabled, this._torsionCompliance, this._bend1Compliance, value);\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_bend2Compliance = value;
				PushBendTwistConstraints(bendTwistConstraintsEnabled, torsionCompliance, bend1Compliance, value);
			}
		}

		[Token(Token = "0x1700009F")]
		public float interParticleDistance
		{
			[Token(Token = "0x6000409")]
			[Address(RVA = "0xC33C74", Offset = "0xC33C74", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.m_RodBlueprint;\n\treturn v0.m_InterParticleDistance;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ObiRodBlueprint obiRodBlueprint = rodBlueprint;
				return obiRodBlueprint.interParticleDistance;
			}
		}

		[Token(Token = "0x170000A0")]
		public override ObiActorBlueprint blueprint
		{
			[Token(Token = "0x600040A")]
			[Address(RVA = "0xC33C94", Offset = "0xC33C94", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_RodBlueprint;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return rodBlueprint;
			}
		}

		[Token(Token = "0x170000A1")]
		public ObiRodBlueprint rodBlueprint
		{
			[Token(Token = "0x600040B")]
			[Address(RVA = "0xC33C9C", Offset = "0xC33C9C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_RodBlueprint;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return rodBlueprint;
			}
			[Token(Token = "0x600040C")]
			[Address(RVA = "0xC33CA4", Offset = "0xC33CA4", Length = "0xB8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1EB6448]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20231A7]) = v41;\nL_001C:\n\tgoto L_0025;\n\tv49 = *([v45 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0025;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0025:\n\tv59 = UnityEngine.Object::op_Inequality(this.m_RodBlueprint, value);\n\tv61 = v59 == 0;\n\tif (v61) goto L_0040;\n\tObi.ObiActor::RemoveFromSolver(this);\n\tObi.ObiActor::ClearState(this);\n\tthis.m_RodBlueprint = value;\n\tObi.ObiActor::AddToSolver(this);\n\treturn;\nL_0040:\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				if (rodBlueprint != value)
				{
					RemoveFromSolver();
					ClearState();
					m_RodBlueprint = value;
					AddToSolver();
				}
			}
		}

		[Token(Token = "0x600040D")]
		[Address(RVA = "0xC33D5C", Offset = "0xC33D5C", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tObi.ObiActor::OnValidate(this);\n\tObi.ObiRod::SetupRuntimeConstraints(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void OnValidate()
		{
			base.OnValidate();
			SetupRuntimeConstraints();
		}

		[Token(Token = "0x600040E")]
		[Address(RVA = "0xC33DFC", Offset = "0xC33DFC", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tObi.ObiActor::LoadBlueprint(this, solver);\n\tObi.ObiRopeBase::RebuildElementsFromConstraints(this);\n\tObi.ObiRod::SetupRuntimeConstraints(this);\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void LoadBlueprint(ObiSolver solver)
		{
			base.LoadBlueprint(solver);
			RebuildElementsFromConstraints();
			SetupRuntimeConstraints();
		}

		[Token(Token = "0x600040F")]
		[Address(RVA = "0xC33D84", Offset = "0xC33D84", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tObi.ObiActor::PushStretchShearConstraints(this, this._stretchShearConstraintsEnabled, this._stretchCompliance, this._shear1Compliance, this._shear2Compliance);\n\tObi.ObiActor::PushBendTwistConstraints(this, this._bendTwistConstraintsEnabled, this._torsionCompliance, this._bend1Compliance, this._bend2Compliance);\n\tObi.ObiActor::PushChainConstraints(this, this._chainConstraintsEnabled, this._tightness);\n\tv30 = Obi.ObiActor::SetSelfCollisions(this, this.m_SelfCollisions);\n\tObi.ObiRopeBase::RecalculateRestLength(this);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SetupRuntimeConstraints()
		{
			PushStretchShearConstraints(stretchShearConstraintsEnabled, stretchCompliance, shear1Compliance, shear2Compliance);
			PushBendTwistConstraints(bendTwistConstraintsEnabled, torsionCompliance, bend1Compliance, bend2Compliance);
			PushChainConstraints(_chainConstraintsEnabled, _tightness);
			base.SetSelfCollisions(m_SelfCollisions);
			RecalculateRestLength();
		}

		[Token(Token = "0x6000410")]
		[Address(RVA = "0xC33EE8", Offset = "0xC33EE8", Length = "0x2C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1EFA0A8]);\n\tv31 = *([v30 @ X8_v31]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20231A8]) = v50;\nL_001C:\n\tv54 = Obi.ObiActor::GetConstraintsByType(this, 7);\n\tv55 = v54 == 0;\n\tif (v55) goto L_0131;\n\tgoto L_FFFFFFFF;\n\tv91 = v91_asT == 0;\n\tif (v91) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tv99 = v99_asT == 0;\n\tif (v99) goto L_0131;\n\tv232 = *([v87 @ X23_v3 (Obi.IObiConstraints)+28]);\n\tv329 = *([v232 @ X20_v6+18]) == 0;\n\tv330 = ~v329;\n\tif (v330) goto L_0050;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0050:\n\tv358 = *([v232 @ X20_v6+10]);\n\tv316 = *([v358 @ X8_v10+20]);\n\tv253 = *([v87 @ X23_v3 (Obi.IObiConstraints)+28]);\n\tv359 = *([v253 @ X21_v5+18]) < 1;\n\tv287 = ~v359;\n\tv284 = *([v253 @ X21_v5+18]) - 1;\n\tv278 = v284 == 0;\n\tv360 = ~v278;\n\tv263 = v287 & v360;\n\tif (v263) goto L_0067;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0067:\n\tv362 = *([v253 @ X21_v5+10]);\n\tv317 = *([v362 @ X8_v12+28]);\n\tv147 = *([v317 @ X8_v13+34]) + *([v316 @ X8_v11+34]);\n\tv299 = new System.Collections.Generic.List`1<Obi.ObiStructuralElement>();\n\tSystem.Collections.Generic.List`1<Obi.ObiStructuralElement>::.ctor(v299, v147);\n\tthis.elements = v299;\n\tv85 = *([v87 @ X23_v3 (Obi.IObiConstraints)+28]);\nL_0089:\n\tv390 = v75 >= v147;\n\tif (v390) goto L_00EC;\n\tv394 = v75 < 0;\n\tv397 = v75 ^ v75;\n\tv398 = v75 & v397;\n\tv399 = v398 < 0;\n\tv401 = v394 == v399;\n\tv402 = ~v401;\n\tv259 = ~v402;\n\tif (v259) goto L_FFFFFFFF;\n\tv408 = v75 + 1;\n\tgoto L_009D;\nL_009D:\n\tv292 = v408 & 0xFFFFFFFE;\n\tv409 = v75 - v292;\n\tv410 = *([v85 @ X21_v8+18]) < v409;\n\tv288 = ~v410;\n\tv285 = *([v85 @ X21_v8+18]) - v409;\n\tv279 = v285 == 0;\n\tv411 = ~v279;\n\tv264 = v288 & v411;\n\tif (v264) goto L_00AF;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_00AF:\n\tv261 = v409 << 3;\n\tv319 = *([v85 @ X21_v8+10]) + v261;\n\tv235 = *([v319 @ X8_v25+20]);\n\tv300 = new Obi.ObiStructuralElement();\n\tObi.ObiStructuralElement::.ctor(v300);\n\tv342 = *([v235 @ X26_v8+40]);\n\tv320 = *([v342 @ X0_v26]);\n\tv248 = v75 & 0xFFFFFFFE;\n\t*([v320 @ X8_v26+180])(v301, v342, v248, *([v320 @ X8_v26+188]), v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv300.particle1 = v301;\n\tv343 = *([v235 @ X26_v8+40]);\n\tv355 = *([v343 @ X0_v28]);\n\tv335 = v75 | 1;\n\t*([v355 @ X8_v27+180])(v418, v343, v335, *([v355 @ X8_v27+188]), v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv300.particle2 = v418;\n\tv344 = *([v235 @ X26_v8+50]);\n\tv321 = *([v344 @ X0_v30]);\n\tv336 = v75 >> 1;\n\t*([v321 @ X8_v28+180])(v419, v344, v336, *([v321 @ X8_v28+188]), v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv300.restLength = v40;\n\tSystem.Collections.Generic.List`1<Obi.ObiStructuralElement>::Add(this.elements, v300);\n\tv85 = *([v87 @ X23_v3 (Obi.IObiConstraints)+28]);\n\tv75 = v75 + 1;\n\tv420 = *([v87 @ X23_v3 (Obi.IObiConstraints)+28]) == 0;\n\tv312 = ~v420;\n\tif (v312) goto L_0089;\n\tgoto L_0133;\nL_00EC:\n\tv98 = *([v85 @ X21_v8+18]) < 3;\n\tif (v98) goto L_0131;\n\tv322 = *([v85 @ X21_v8+10]);\n\tv257 = *([v322 @ X8_v19+30]);\n\tv303 = new Obi.ObiStructuralElement();\n\tObi.ObiStructuralElement::.ctor(v303);\n\tv345 = *([v257 @ X21_v9+40]);\n\tv323 = *([v345 @ X0_v16]);\n\t*([v323 @ X8_v20+180])(v304, v345, 0, *([v323 @ X8_v20+188]), v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv303.particle1 = v304;\n\tv346 = *([v257 @ X21_v9+40]);\n\tv356 = *([v346 @ X0_v18]);\n\t*([v356 @ X8_v21+180])(v416, v346, 1, *([v356 @ X8_v21+188]), v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv303.particle2 = v416;\n\tv347 = *([v257 @ X21_v9+50]);\n\tv222 = *([v347 @ X0_v20]);\n\t*([v222 @ X8_v22+180])(v417, v347, 0, *([v222 @ X8_v22+188]), v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv303.restLength = v40;\n\tSystem.Collections.Generic.List`1<Obi.ObiStructuralElement>::Add(this.elements, v303);\n\treturn;\nL_0131:\n\treturn;\nL_0133:\n\tthrow System.NullReferenceException;\n// 200 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			//IL_0411: Expected O, but got I
			//IL_0421: Expected O, but got I
			//IL_0440: Expected O, but got I
			//IL_054f: Expected I4, but got I8
			//IL_0287: Expected O, but got I
			//IL_0297: Expected O, but got I
			//IL_0479: Expected O, but got I
			//IL_02b6: Expected O, but got I
			//IL_04ad: Expected O, but got I
			//IL_02d5: Expected I4, but got I8
			//IL_0301: Expected O, but got I
			//IL_0343: Expected O, but got I
			//IL_0399: Expected O, but got I
			IObiConstraints constraintsByType = GetConstraintsByType(Oni.ConstraintType.StretchShear);
			if (constraintsByType == null)
			{
				return;
			}
			ObiConstraints<ObiStretchShearConstraintsBatch> obiConstraints = constraintsByType as ObiConstraints<ObiStretchShearConstraintsBatch>;
			if (obiConstraints != null)
			{
				IObiConstraints obiConstraints2 = constraintsByType;
			}
			else
			{
				IObiConstraints obiConstraints2 = null;
			}
			ObiConstraints<ObiStretchShearConstraintsBatch> obiConstraints3 = constraintsByType as ObiConstraints<ObiStretchShearConstraintsBatch>;
			if (obiConstraints3 == null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ X23_v3 (Obi.IObiConstraints)+28]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ X20_v6+18]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				throw new ArgumentOutOfRangeException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ X20_v6+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ X8_v10+20]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ X23_v3 (Obi.IObiConstraints)+28]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ X21_v5+18]");
			bool flag = 0L < 1L;
			bool flag2 = !flag;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ X21_v5+18]");
			object obj5 = -1;
			bool flag3 = obj5 == null;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ X21_v5+10]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v362 @ X8_v12+28]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ X8_v13+34]");
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v316 @ X8_v11+34]");
			int num = (int)((long)intPtr + 0L);
			List<ObiStructuralElement> list = new List<ObiStructuralElement>(num);
			elements = list;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ X23_v3 (Obi.IObiConstraints)+28]");
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
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ X21_v8+18]");
					bool flag7 = 0L < (long)num7;
					bool flag8 = !flag7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ X21_v8+18]");
					int num8 = (int)(-num7);
					bool flag9 = num8 == 0;
					bool flag10 = !flag9;
					if (!(flag8 && flag10))
					{
						throw new ArgumentOutOfRangeException();
					}
					int num9 = num7 << 3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ X21_v8+10]");
					object obj9 = 0L + (long)num9;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ X8_v25+20]");
					object obj10 = 0;
					ObiStructuralElement obiStructuralElement = new ObiStructuralElement();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ X26_v8+40]");
					object obj11 = 0;
					object obj12 = obj11;
					int num10 = (int)(num2 & 0xFFFFFFFEL);
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v320 @ X8_v26+180] (should have been resolved before IL gen)");
					obiStructuralElement.particle1 = particle;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ X26_v8+40]");
					object obj13 = 0;
					object obj14 = obj13;
					int num11 = num2 | 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v355 @ X8_v27+180] (should have been resolved before IL gen)");
					obiStructuralElement.particle2 = particle2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ X26_v8+50]");
					object obj15 = 0;
					object obj16 = obj15;
					int num12 = num2 >> 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v321 @ X8_v28+180] (should have been resolved before IL gen)");
					obiStructuralElement.restLength = num13;
					elements.Add(obiStructuralElement);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ X23_v3 (Obi.IObiConstraints)+28]");
					obj8 = 0;
					num2++;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ X23_v3 (Obi.IObiConstraints)+28]");
					continue;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ X21_v8+18]");
				if (0L >= 3L)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ X21_v8+10]");
					object obj17 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ X8_v19+30]");
					object obj18 = 0;
					ObiStructuralElement obiStructuralElement2 = new ObiStructuralElement();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ X21_v9+40]");
					object obj19 = 0;
					object obj20 = obj19;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v323 @ X8_v20+180] (should have been resolved before IL gen)");
					obiStructuralElement2.particle1 = particle3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ X21_v9+40]");
					object obj21 = 0;
					object obj22 = obj21;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v356 @ X8_v21+180] (should have been resolved before IL gen)");
					obiStructuralElement2.particle2 = particle4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ X21_v9+50]");
					object obj23 = 0;
					object obj24 = obj23;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v222 @ X8_v22+180] (should have been resolved before IL gen)");
					obiStructuralElement2.restLength = num13;
					elements.Add(obiStructuralElement2);
				}
				return;
			}
			while ((IntPtr)0 != (IntPtr)0);
			throw new NullReferenceException();
		}

		[Token(Token = "0x6000411")]
		[Address(RVA = "0xC341B0", Offset = "0xC341B0", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._stretchShearConstraintsEnabled = 1;\n\tthis._bendTwistConstraintsEnabled = 1;\n\tthis._chainConstraintsEnabled = 1;\n\tthis._tightness = 1f;\n\tObi.ObiRopeBase::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiRod()
		{
			_stretchShearConstraintsEnabled = true;
			_bendTwistConstraintsEnabled = true;
			_chainConstraintsEnabled = true;
			_tightness = 1f;
		}
	}
}
