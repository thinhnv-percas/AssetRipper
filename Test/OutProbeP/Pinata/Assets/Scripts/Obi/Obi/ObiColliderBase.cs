using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Profiling;
using UnityEngine;

namespace Obi
{
	[Token(Token = "0x2000028")]
	public abstract class ObiColliderBase : MonoBehaviour
	{
		[Token(Token = "0x20000AC")]
		private delegate void ColliderUpdateCallback();

		[Token(Token = "0x400008C")]
		private static ProfilerMarker m_UpdateCollidersPerfMarker;

		[Token(Token = "0x400008D")]
		public static Dictionary<int, Component> idToCollider;

		[AttributeAttribute(Type = typeof(SerializeProperty), RVA = "0x745B08", Offset = "0x745B08")]
		[SerializeField]
		[Token(Token = "0x400008E")]
		[FieldOffset(Offset = "0x18")]
		private ObiCollisionMaterial material;

		[AttributeAttribute(Type = typeof(SerializeProperty), RVA = "0x745B54", Offset = "0x745B54")]
		[SerializeField]
		[Token(Token = "0x400008F")]
		[FieldOffset(Offset = "0x20")]
		private int phase;

		[AttributeAttribute(Type = typeof(SerializeProperty), RVA = "0x745BA0", Offset = "0x745BA0")]
		[SerializeField]
		[Token(Token = "0x4000090")]
		[FieldOffset(Offset = "0x24")]
		private float thickness;

		[Token(Token = "0x4000091")]
		[FieldOffset(Offset = "0x28")]
		protected internal IntPtr oniCollider;

		[Token(Token = "0x4000092")]
		[FieldOffset(Offset = "0x30")]
		protected ObiRigidbodyBase obiRigidbody;

		[Token(Token = "0x4000093")]
		[FieldOffset(Offset = "0x38")]
		protected bool wasUnityColliderEnabled;

		[Token(Token = "0x4000094")]
		[FieldOffset(Offset = "0x39")]
		protected bool dirty;

		[Token(Token = "0x4000095")]
		[FieldOffset(Offset = "0x40")]
		protected internal ObiShapeTracker tracker;

		[Token(Token = "0x4000096")]
		[FieldOffset(Offset = "0x48")]
		protected Oni.Collider adaptor;

		[CompilerGenerated]
		[Token(Token = "0x4000097")]
		private static ColliderUpdateCallback m_OnUpdateColliders;

		[CompilerGenerated]
		[Token(Token = "0x4000098")]
		private static ColliderUpdateCallback m_OnResetColliderTransforms;

		[Token(Token = "0x17000032")]
		public ObiCollisionMaterial CollisionMaterial
		{
			[Token(Token = "0x600021B")]
			[Address(RVA = "0xE419DC", Offset = "0xE419DC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.material;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return CollisionMaterial;
			}
			[Token(Token = "0x600021A")]
			[Address(RVA = "0xE41930", Offset = "0xE41930", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.material = value;\n\tObi.ObiColliderBase::UpdateMaterial(this);\n\treturn;\n")]
			set
			{
				material = value;
				UpdateMaterial();
			}
		}

		[Token(Token = "0x17000033")]
		public int Phase
		{
			[Token(Token = "0x600021D")]
			[Address(RVA = "0xE41A00", Offset = "0xE41A00", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.phase;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Phase;
			}
			[Token(Token = "0x600021C")]
			[Address(RVA = "0xE419E4", Offset = "0xE419E4", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = this.phase == value;\n\tif (v7) goto L_000E;\n\tthis.phase = value;\n\tthis.dirty = 1;\nL_000E:\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				if (Phase != value)
				{
					phase = value;
					dirty = true;
				}
			}
		}

		[Token(Token = "0x17000034")]
		public float Thickness
		{
			[Token(Token = "0x600021F")]
			[Address(RVA = "0xE41A24", Offset = "0xE41A24", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.thickness;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Thickness;
			}
			[Token(Token = "0x600021E")]
			[Address(RVA = "0xE41A08", Offset = "0xE41A08", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = this.thickness == value;\n\tif (v7) goto L_000E;\n\tthis.thickness = value;\n\tthis.dirty = 1;\nL_000E:\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				if (Thickness != value)
				{
					thickness = value;
					dirty = true;
				}
			}
		}

		[Token(Token = "0x17000035")]
		public ObiShapeTracker Tracker
		{
			[Token(Token = "0x6000220")]
			[Address(RVA = "0xE41A2C", Offset = "0xE41A2C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.tracker;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Tracker;
			}
		}

		[Token(Token = "0x17000036")]
		public IntPtr OniCollider
		{
			[Token(Token = "0x6000221")]
			[Address(RVA = "0xE41A34", Offset = "0xE41A34", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EDCA28]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202471B]) = v38;\nL_0016:\n\tv42 = System.IntPtr::op_Equality(this.oniCollider, 0);\n\tv44 = v42 == 0;\n\tif (v44) goto L_0025;\n\tv49 = Obi.ObiColliderBase::FindSourceCollider(this);\nL_0025:\n\treturn this.oniCollider;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (oniCollider == (IntPtr)0)
				{
					FindSourceCollider();
				}
				return oniCollider;
			}
		}

		[Token(Token = "0x14000008")]
		private static event ColliderUpdateCallback OnUpdateColliders
		{
			[CompilerGenerated]
			[Token(Token = "0x6000222")]
			[Address(RVA = "0xE41A9C", Offset = "0xE41A9C", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1ECA718]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202471C]) = v44;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<Obi.ObiColliderBase>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = Obi.ObiColliderBase;\nL_002A:\n\tv107 = System.Delegate::Combine(v102, value);\n\tv108 = v107 == 0;\n\tif (v108) goto L_003F;\n\tv120 = *([v107 @ X0_v6 (System.Delegate)]) != Obi.ObiColliderBase+ColliderUpdateCallback;\n\tif (v120) goto L_0061;\nL_003F:\n\tgoto L_0049;\n\tv138 = *([v132 @ X0_v7 (Il2CppClass<Obi.ObiColliderBase>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0049;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v132, v130, v106, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = Obi.ObiColliderBase;\nL_0049:\n\tv144 = v141.m_UpdateCollidersPerfMarker + 0x10;\n\tv97 = 0x874190(v144, v107, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = v102 != v97;\n\tif (v67) goto L_002A;\n\treturn;\nL_0061:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0058: Unknown result type (might be due to invalid IL or missing references)
				//IL_005d: Expected O, but got Unknown
				Delegate obj = ObiColliderBase.m_OnUpdateColliders;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Combine(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(ColliderUpdateCallback))
					{
						break;
					}
					object obj3 = m_UpdateCollidersPerfMarker + 16;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x6000223")]
			[Address(RVA = "0xE41B8C", Offset = "0xE41B8C", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EAC2E0]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202471D]) = v44;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<Obi.ObiColliderBase>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = Obi.ObiColliderBase;\nL_002A:\n\tv107 = System.Delegate::Remove(v102, value);\n\tv108 = v107 == 0;\n\tif (v108) goto L_003F;\n\tv120 = *([v107 @ X0_v6 (System.Delegate)]) != Obi.ObiColliderBase+ColliderUpdateCallback;\n\tif (v120) goto L_0061;\nL_003F:\n\tgoto L_0049;\n\tv138 = *([v132 @ X0_v7 (Il2CppClass<Obi.ObiColliderBase>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0049;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v132, v130, v106, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = Obi.ObiColliderBase;\nL_0049:\n\tv144 = v141.m_UpdateCollidersPerfMarker + 0x10;\n\tv97 = 0x874190(v144, v107, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = v102 != v97;\n\tif (v67) goto L_002A;\n\treturn;\nL_0061:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0058: Unknown result type (might be due to invalid IL or missing references)
				//IL_005d: Expected O, but got Unknown
				Delegate obj = ObiColliderBase.m_OnUpdateColliders;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Remove(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(ColliderUpdateCallback))
					{
						break;
					}
					object obj3 = m_UpdateCollidersPerfMarker + 16;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x14000009")]
		private static event ColliderUpdateCallback OnResetColliderTransforms
		{
			[CompilerGenerated]
			[Token(Token = "0x6000224")]
			[Address(RVA = "0xE41C7C", Offset = "0xE41C7C", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EC4B98]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202471E]) = v44;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<Obi.ObiColliderBase>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = Obi.ObiColliderBase;\nL_002A:\n\tv107 = System.Delegate::Combine(v102, value);\n\tv108 = v107 == 0;\n\tif (v108) goto L_003F;\n\tv120 = *([v107 @ X0_v6 (System.Delegate)]) != Obi.ObiColliderBase+ColliderUpdateCallback;\n\tif (v120) goto L_0061;\nL_003F:\n\tgoto L_0049;\n\tv138 = *([v132 @ X0_v7 (Il2CppClass<Obi.ObiColliderBase>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0049;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v132, v130, v106, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = Obi.ObiColliderBase;\nL_0049:\n\tv144 = v141.m_UpdateCollidersPerfMarker + 0x18;\n\tv97 = 0x874190(v144, v107, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = v102 != v97;\n\tif (v67) goto L_002A;\n\treturn;\nL_0061:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0058: Unknown result type (might be due to invalid IL or missing references)
				//IL_005d: Expected O, but got Unknown
				Delegate obj = ObiColliderBase.m_OnResetColliderTransforms;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Combine(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(ColliderUpdateCallback))
					{
						break;
					}
					object obj3 = m_UpdateCollidersPerfMarker + 24;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x6000225")]
			[Address(RVA = "0xE41D6C", Offset = "0xE41D6C", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1F0C3A8]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202471F]) = v44;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<Obi.ObiColliderBase>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = Obi.ObiColliderBase;\nL_002A:\n\tv107 = System.Delegate::Remove(v102, value);\n\tv108 = v107 == 0;\n\tif (v108) goto L_003F;\n\tv120 = *([v107 @ X0_v6 (System.Delegate)]) != Obi.ObiColliderBase+ColliderUpdateCallback;\n\tif (v120) goto L_0061;\nL_003F:\n\tgoto L_0049;\n\tv138 = *([v132 @ X0_v7 (Il2CppClass<Obi.ObiColliderBase>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0049;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v132, v130, v106, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = Obi.ObiColliderBase;\nL_0049:\n\tv144 = v141.m_UpdateCollidersPerfMarker + 0x18;\n\tv97 = 0x874190(v144, v107, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = v102 != v97;\n\tif (v67) goto L_002A;\n\treturn;\nL_0061:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0058: Unknown result type (might be due to invalid IL or missing references)
				//IL_005d: Expected O, but got Unknown
				Delegate obj = ObiColliderBase.m_OnResetColliderTransforms;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Remove(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(ColliderUpdateCallback))
					{
						break;
					}
					object obj3 = m_UpdateCollidersPerfMarker + 24;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x6000226")]
		[Address(RVA = "0xE41E5C", Offset = "0xE41E5C", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EB4408]);\n\tv17 = *([v16 @ X8_v19]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2024720]) = v37;\nL_0018:\n\tgoto L_0023;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<Obi.ObiColliderBase>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0023;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv48 = Obi.ObiColliderBase;\nL_0023:\n\tUnity.Profiling.ProfilerMarker::Internal_Begin(v51.m_UpdateCollidersPerfMarker);\n\tgoto L_0030;\n\tv60 = *([v56 @ X0_v5 (Il2CppClass<Obi.ObiColliderBase>)+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tgoto L_0030;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v56, v52, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv64 = Obi.ObiColliderBase;\nL_0030:\n\tv82 = v67.OnUpdateColliders;\n\tv69 = v67.OnUpdateColliders == 0;\n\tif (v69) goto L_004A;\n\tv72 = *([v63 @ X0_v6 (Il2CppClass<Obi.ObiColliderBase>)+12F]) & 2;\n\tv73 = v72 == 0;\n\tif (v73) goto L_0042;\n\tv90 = *([v63 @ X0_v6 (Il2CppClass<Obi.ObiColliderBase>)+E0]) == 0;\n\tv91 = ~v90;\n\tif (v91) goto L_0042;\n\tv82 = v146.OnUpdateColliders;\n\tv94 = v146.OnUpdateColliders == 0;\n\tif (v94) goto L_004D;\nL_0042:\n\tObi.ObiColliderBase+ColliderUpdateCallback::Invoke(v82);\nL_004A:\n\tUnity.Profiling.ProfilerMarker::Internal_End(v51.m_UpdateCollidersPerfMarker);\n\treturn;\nL_004D:\n\tv148 = new System.NullReferenceException();\n\tgoto L_0059;\nL_0059:\n\tgoto L_0069;\n\tv150 = 0x6D2BC0(v148, 0, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv153 = 0x6D2490(v150, 0, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tUnity.Profiling.ProfilerMarker::Internal_End(v51.m_UpdateCollidersPerfMarker);\n\tv157 = *([v150 @ X0_v18]) == 0;\n\tv138 = ~v157;\n\tif (v138) goto L_006D;\n\treturn;\nL_0069:\n\tv151 = 0x6D2380(v148, 0, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_006D:\n\tthrow System.TypeLoadException;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void UpdateColliders()
		{
			//IL_013a: Expected I, but got O
			//IL_0148: Expected I, but got O
			//IL_00a7: Expected I, but got O
			ProfilerMarker.Internal_Begin((IntPtr)m_UpdateCollidersPerfMarker);
			IntPtr intPtr = (IntPtr)typeof(ObiColliderBase);
			ColliderUpdateCallback onUpdateColliders = ObiColliderBase.OnUpdateColliders;
			if (ObiColliderBase.OnUpdateColliders != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ X0_v6 (Il2CppClass<Obi.ObiColliderBase>)+12F]");
				if (0u != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ X0_v6 (Il2CppClass<Obi.ObiColliderBase>)+E0]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						onUpdateColliders = ObiColliderBase.OnUpdateColliders;
						if (ObiColliderBase.OnUpdateColliders == null)
						{
							NullReferenceException ex = new NullReferenceException();
							Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
							throw new TypeLoadException();
						}
					}
				}
				onUpdateColliders();
			}
			ProfilerMarker.Internal_End((IntPtr)m_UpdateCollidersPerfMarker);
		}

		[Token(Token = "0x6000227")]
		[Address(RVA = "0xE42198", Offset = "0xE42198", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F05BE0]);\n\tv15 = *([v14 @ X8_v14]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2024721]) = v35;\nL_0017:\n\tgoto L_0020;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Obi.ObiColliderBase>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0020;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = Obi.ObiColliderBase;\nL_0020:\n\tv51 = v49.OnResetColliderTransforms == 0;\n\tif (v51) goto L_003B;\n\tgoto L_0035;\n\tv59 = *([v45 @ X0_v3 (Il2CppClass<Obi.ObiColliderBase>)+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0035;\n\tv82 = Obi.ObiColliderBase;\n\tv83 = *([v82 @ X8_v8 (Il2CppClass<Obi.ObiColliderBase>)+B8]);\n\tv68 = v83.OnResetColliderTransforms;\nL_0035:\n\tObi.ObiColliderBase+ColliderUpdateCallback::Invoke(v49.OnResetColliderTransforms);\n\treturn;\nL_003B:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ResetColliderTransforms()
		{
			if (ObiColliderBase.OnResetColliderTransforms != null)
			{
				ObiColliderBase.OnResetColliderTransforms();
			}
		}

		[Token(Token = "0x6000228")]
		protected abstract void CreateTracker();

		[Token(Token = "0x6000229")]
		protected abstract Component GetUnityCollider(ref bool enabled);

		[Token(Token = "0x600022A")]
		protected abstract void UpdateAdaptor();

		[Token(Token = "0x600022B")]
		protected abstract void FindSourceCollider();

		[Token(Token = "0x600022C")]
		[Address(RVA = "0xE42240", Offset = "0xE42240", Length = "0x1F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EB9060]);\n\tv23 = *([v22 @ X8_v33]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2024722]) = v42;\nL_0015:\n\tthis.obiRigidbody = 0;\n\tv47 = UnityEngine.Component::GetComponentInParent(this);\n\tv53 = UnityEngine.Component::GetComponentInParent(this);\n\tgoto L_0032;\n\tv61 = *([v57 @ X8_v7+E0]);\n\tv62 = v61 == 0;\n\tv63 = ~v62;\n\tgoto L_0032;\n\tv72 = v57;\n\tv66 = \"il2cpp_codegen_runtime_class_init\"(v72, v52, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0032:\n\tv71 = UnityEngine.Object::op_Inequality(v47, 0);\n\tv74 = v71 == 0;\n\tif (v74) goto L_005C;\n\tv84 = UnityEngine.Component::GetComponent(v47);\n\tthis.obiRigidbody = v84;\n\tgoto L_004C;\n\tv111 = *([v105 @ X0_v39+E0]);\n\tv112 = v111 == 0;\n\tv113 = ~v112;\n\tif (v113) goto L_004C;\n\tv115 = \"il2cpp_codegen_runtime_class_init\"(v105, v83, v70, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_004C:\n\tv121 = UnityEngine.Object::op_Equality(v84, 0);\n\tv147 = v121 == 0;\n\tif (v147) goto L_0091;\n\tv221 = UnityEngine.Component::get_gameObject(v47);\n\tgoto L_008B;\nL_005C:\n\tgoto L_0065;\n\tv97 = *([v76 @ X0_v22+E0]);\n\tv98 = v97 == 0;\n\tv99 = ~v98;\n\tif (v99) goto L_0065;\n\tv101 = \"il2cpp_codegen_runtime_class_init\"(v76, v69, v70, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0065:\n\tv90 = UnityEngine.Object::op_Inequality(v53, 0);\n\tv110 = v90 == 0;\n\tif (v110) goto L_009A;\n\tv152 = UnityEngine.Component::GetComponent(v53);\n\tthis.obiRigidbody = v152;\n\tgoto L_007F;\n\tv210 = *([v190 @ X0_v29+E0]);\n\tv211 = v210 == 0;\n\tv212 = ~v211;\n\tif (v212) goto L_007F;\n\tv214 = \"il2cpp_codegen_runtime_class_init\"(v190, v151, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_007F:\n\tv179 = UnityEngine.Object::op_Equality(v152, 0);\n\tv182 = v179 == 0;\n\tif (v182) goto L_0091;\n\tv221 = UnityEngine.Component::get_gameObject(v53);\nL_008B:\n\tv199 = UnityEngine.GameObject::AddComponent /* +64 sharing this address */(v221, *([v202 @ X8_v9 (Il2CppMethodInfo)]));\n\tthis.obiRigidbody = v199;\n\tv225 = v199 == 0;\n\tv201 = ~v225;\n\tif (v201) goto L_0096;\n\tthrow System.NullReferenceException;\nL_0091:\n\tv199 = this.obiRigidbody;\nL_0096:\n\tv205 = Obi.ObiRigidbodyBase::get_OniRigidbody(v199);\n\tgoto L_00A4;\nL_009A:\n\tv133 = this.oniCollider;\nL_00A4:\n\tOni::SetColliderRigidbody(v133, v129);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 102 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void CreateRigidbody()
		{
			obiRigidbody = null;
			Rigidbody componentInParent = GetComponentInParent<Rigidbody>();
			Rigidbody2D componentInParent2 = GetComponentInParent<Rigidbody2D>();
			IntPtr collider;
			IntPtr rigidbody;
			if (componentInParent != null)
			{
				if (!((obiRigidbody = componentInParent.GetComponent<ObiRigidbody>()) == null))
				{
					goto IL_012e;
				}
				GameObject gameObject = componentInParent.gameObject;
				IntPtr intPtr = (IntPtr)0;
			}
			else
			{
				if (!(componentInParent2 != null))
				{
					collider = oniCollider;
					rigidbody = default(IntPtr);
					goto IL_01db;
				}
				if (!((obiRigidbody = componentInParent2.GetComponent<ObiRigidbody2D>()) == null))
				{
					goto IL_012e;
				}
				GameObject gameObject = componentInParent2.gameObject;
				IntPtr intPtr = (IntPtr)0;
			}
			Il2CppRuntime.Boundary("MANAGED", "Method not found @ACCA10 (UnityEngine.GameObject::AddComponent, and 64 more at this address)");
			ObiRigidbodyBase obiRigidbodyBase = default(ObiRigidbodyBase);
			obiRigidbody = obiRigidbodyBase;
			if ((object)obiRigidbodyBase == null)
			{
				throw new NullReferenceException();
			}
			goto IL_013d;
			IL_012e:
			obiRigidbodyBase = obiRigidbody;
			goto IL_013d;
			IL_013d:
			IntPtr oniRigidbody = obiRigidbodyBase.OniRigidbody;
			rigidbody = oniRigidbody;
			collider = oniCollider;
			goto IL_01db;
			IL_01db:
			Oni.SetColliderRigidbody(collider, rigidbody);
		}

		[Token(Token = "0x600022D")]
		[Address(RVA = "0xE41938", Offset = "0xE41938", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EFECA0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024723]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Inequality(this.material, 0);\n\tv59 = v56 == 0;\n\tif (v59) goto L_FFFFFFFF;\n\tv60 = this.material;\n\tv70 = v60.oniCollisionMaterial;\n\tgoto L_0036;\nL_0036:\n\tOni::SetColliderMaterial(v71, v70);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UpdateMaterial()
		{
			IntPtr intPtr;
			IntPtr collider;
			if (CollisionMaterial != null)
			{
				ObiCollisionMaterial collisionMaterial = CollisionMaterial;
				intPtr = collisionMaterial.OniCollisionMaterial;
				collider = oniCollider;
			}
			else
			{
				intPtr = default(IntPtr);
				collider = oniCollider;
			}
			Oni.SetColliderMaterial(collider, intPtr);
		}

		[Token(Token = "0x600022E")]
		[Address(RVA = "0xE42434", Offset = "0xE42434", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tObi.ObiColliderBase::CreateRigidbody(this);\n\treturn;\n")]
		private void OnTransformParentChanged()
		{
			CreateRigidbody();
		}

		[Token(Token = "0x600022F")]
		[Address(RVA = "0xE40A58", Offset = "0xE40A58", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1EC9F20]);\n\tv21 = *([v20 @ X8_v24]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2024724]) = v40;\nL_0016:\n\tv43 = this + 0x38;\n\tv47 = Obi.ObiColliderBase::GetUnityCollider(this, v43);\n\tgoto L_002C;\n\tv55 = *([v51 @ X8_v6+E0]);\n\tv56 = v55 == 0;\n\tv57 = ~v56;\n\tgoto L_002C;\n\tv66 = v51;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v66, v43, v46, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002C:\n\tv65 = UnityEngine.Object::op_Inequality(v47, 0);\n\tv68 = v65 == 0;\n\tif (v68) goto L_0088;\n\tv72 = System.IntPtr::op_Equality(this.oniCollider, 0);\n\tv77 = v72 == 0;\n\tif (v77) goto L_0088;\n\tgoto L_004A;\n\tv119 = *([v115 @ X0_v10 (Il2CppClass<Obi.ObiColliderBase>)+E0]);\n\tv120 = v119 == 0;\n\tv121 = ~v120;\n\t// 65 ConditionalJump @b30, v121 @ TEMP_v19\n\tv127 = \"il2cpp_codegen_runtime_class_init\"(v115, v70, v71, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv123 = Obi.ObiColliderBase;\nL_004A:\n\tv132 = UnityEngine.Object::GetInstanceID(v47);\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Component>::set_Item(v128.idToCollider, v132, v47);\n\tv140 = Oni::CreateCollider();\n\tthis.oniCollider = v140;\n\tv145 = Obi.ObiColliderBase::CreateTracker(this);\n\tv149 = Obi.ObiColliderBase::UpdateAdaptor(this);\n\tObi.ObiColliderBase::UpdateMaterial(this);\n\tObi.ObiColliderBase::CreateRigidbody(this);\n\tv155 = new Obi.ObiColliderBase+ColliderUpdateCallback();\n\tv158 = Il2CppMethodInfo;\n\tv155.m_target = this;\n\tv155.method = Il2CppMethodInfo;\n\tv155.method_ptr = *([v158 @ X8_v17 (Il2CppMethodInfo)]);\n\tObi.ObiColliderBase::add_OnUpdateColliders(v155);\n\tv99 = new Obi.ObiColliderBase+ColliderUpdateCallback();\n\tv107 = Il2CppMethodInfo;\n\tv99.m_target = this;\n\tv99.method = Il2CppMethodInfo;\n\tv99.method_ptr = *([v107 @ X8_v20 (Il2CppMethodInfo)]);\n\tObi.ObiColliderBase::add_OnResetColliderTransforms(v99);\n\treturn;\nL_0088:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 88 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal unsafe void AddCollider()
		{
			Component unityCollider = GetUnityCollider(ref *(bool*)((long)(IntPtr)this + 56L));
			if (unityCollider != null && oniCollider == (IntPtr)0)
			{
				int instanceID = unityCollider.GetInstanceID();
				idToCollider.set_Item(instanceID, unityCollider);
				IntPtr intPtr = Oni.CreateCollider();
				oniCollider = intPtr;
				CreateTracker();
				UpdateAdaptor();
				UpdateMaterial();
				CreateRigidbody();
				ColliderUpdateCallback colliderUpdateCallback = null;
				IntPtr method_ptr = (IntPtr)0;
				((Delegate)colliderUpdateCallback).m_target = this;
				((Delegate)colliderUpdateCallback).method = (IntPtr)__ldftn(ObiColliderBase.UpdateIfNeeded);
				((Delegate)colliderUpdateCallback).method_ptr = method_ptr;
				OnUpdateColliders += colliderUpdateCallback;
				ColliderUpdateCallback colliderUpdateCallback2 = null;
				IntPtr method_ptr2 = (IntPtr)0;
				((Delegate)colliderUpdateCallback2).m_target = this;
				((Delegate)colliderUpdateCallback2).method = (IntPtr)__ldftn(ObiColliderBase.ResetTransformChangeFlag);
				((Delegate)colliderUpdateCallback2).method_ptr = method_ptr2;
				OnResetColliderTransforms += colliderUpdateCallback2;
			}
		}

		[Token(Token = "0x6000230")]
		[Address(RVA = "0xE408A0", Offset = "0xE408A0", Length = "0x1B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EC76C8]);\n\tv21 = *([v20 @ X8_v30]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2024725]) = v40;\nL_0017:\n\tv44 = System.IntPtr::op_Inequality(this.oniCollider, 0);\n\tv46 = v44 == 0;\n\tif (v46) goto L_008C;\n\tv49 = this + 0x38;\n\tv53 = Obi.ObiColliderBase::GetUnityCollider(this, v49);\n\tgoto L_0033;\n\tv87 = *([v57 @ X8_v7+E0]);\n\tv88 = v87 == 0;\n\tv89 = ~v88;\n\tif (v89) goto L_0033;\n\tv114 = v57;\n\tv92 = \"il2cpp_codegen_runtime_class_init\"(v114, v49, v52, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0033:\n\tv97 = UnityEngine.Object::op_Inequality(v53, 0);\n\tv116 = v97 == 0;\n\tif (v116) goto L_0056;\n\tgoto L_004A;\n\tv137 = *([v119 @ X0_v23 (Il2CppClass<Obi.ObiColliderBase>)+E0]);\n\tv138 = v137 == 0;\n\tv139 = ~v138;\n\t// 65 ConditionalJump @b33, v139 @ TEMP_v26\n\tv155 = \"il2cpp_codegen_runtime_class_init\"(v119, v95, v96, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv141 = Obi.ObiColliderBase;\nL_004A:\n\tv159 = UnityEngine.Object::GetInstanceID(v53);\n\tv129 = System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Component>::Remove(v156.idToCollider, v159);\nL_0056:\n\tv136 = new Obi.ObiColliderBase+ColliderUpdateCallback();\n\tv147 = Il2CppMethodInfo;\n\tv136.m_target = this;\n\tv136.method = Il2CppMethodInfo;\n\tv136.method_ptr = *([v147 @ X8_v11 (Il2CppMethodInfo)]);\n\tgoto L_006C;\n\tv162 = *([v151 @ X0_v13+E0]);\n\tv163 = v162 == 0;\n\tv164 = ~v163;\n\tif (v164) goto L_006C;\n\tv166 = \"il2cpp_codegen_runtime_class_init\"(v151, v126, v64, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_006C:\n\tObi.ObiColliderBase::remove_OnUpdateColliders(v136);\n\tv171 = new Obi.ObiColliderBase+ColliderUpdateCallback();\n\tv79 = Il2CppMethodInfo;\n\tv171.m_target = this;\n\tv171.method = Il2CppMethodInfo;\n\tv171.method_ptr = *([v79 @ X8_v18 (Il2CppMethodInfo)]);\n\tObi.ObiColliderBase::remove_OnResetColliderTransforms(v171);\n\tOni::RemoveCollider(this.oniCollider);\n\tOni::DestroyCollider(this.oniCollider);\n\tthis.oniCollider = 0;\n\tv76 = this.tracker == 0;\n\tif (v76) goto L_008C;\n\tv73 = Obi.ObiShapeTracker::Destroy(this.tracker);\n\tthis.tracker = 0;\nL_008C:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 86 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal unsafe void RemoveCollider()
		{
			if (oniCollider != (IntPtr)0)
			{
				Component unityCollider = GetUnityCollider(ref *(bool*)((long)(IntPtr)this + 56L));
				if (unityCollider != null)
				{
					int instanceID = unityCollider.GetInstanceID();
					bool flag = idToCollider.Remove(instanceID);
				}
				ColliderUpdateCallback colliderUpdateCallback = null;
				IntPtr method_ptr = (IntPtr)0;
				((Delegate)colliderUpdateCallback).m_target = this;
				((Delegate)colliderUpdateCallback).method = (IntPtr)__ldftn(ObiColliderBase.UpdateIfNeeded);
				((Delegate)colliderUpdateCallback).method_ptr = method_ptr;
				OnUpdateColliders -= colliderUpdateCallback;
				ColliderUpdateCallback colliderUpdateCallback2 = null;
				IntPtr method_ptr2 = (IntPtr)0;
				((Delegate)colliderUpdateCallback2).m_target = this;
				((Delegate)colliderUpdateCallback2).method = (IntPtr)__ldftn(ObiColliderBase.ResetTransformChangeFlag);
				((Delegate)colliderUpdateCallback2).method_ptr = method_ptr2;
				OnResetColliderTransforms -= colliderUpdateCallback2;
				Oni.RemoveCollider(oniCollider);
				Oni.DestroyCollider(oniCollider);
				oniCollider = (IntPtr)0;
				if (Tracker != null)
				{
					Tracker.Destroy();
					tracker = null;
				}
			}
		}

		[Token(Token = "0x6000231")]
		[Address(RVA = "0xE42448", Offset = "0xE42448", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ECE5E0]);\n\tv19 = *([v18 @ X8_v20]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024726]) = v38;\nL_0019:\n\tv46 = Obi.ObiColliderBase::GetUnityCollider(this, &v42 @ stack_-24_v2 (System.Boolean));\n\tgoto L_002B;\n\tv54 = *([v50 @ X8_v6+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_002B;\n\tv65 = v50;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v65, v41, v45, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002B:\n\tv64 = UnityEngine.Object::op_Inequality(v46, 0);\n\tv67 = v64 == 0;\n\tif (v67) goto L_006D;\n\tv69 = this.tracker == 0;\n\tif (v69) goto L_003C;\n\tv77 = Obi.ObiShapeTracker::UpdateIfNeeded(this.tracker);\n\tv79 = v77 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_0055;\nL_003C:\n\tv88 = UnityEngine.Component::get_transform(this);\n\tv120 = UnityEngine.Transform::get_hasChanged(v88);\n\tv182 = v120 == 0;\n\tv123 = ~v182;\n\tif (v123) goto L_0055;\n\tv183 = ~this.dirty;\n\tv122 = ~v183;\n\tif (v122) goto L_0055;\n\tv104 = v42 == this.wasUnityColliderEnabled;\n\tif (v104) goto L_0078;\nL_0055:\n\tthis.dirty = 0;\n\tthis.wasUnityColliderEnabled = v42;\n\tOni::RemoveCollider(this.oniCollider);\n\tv147 = Obi.ObiColliderBase::UpdateAdaptor(this);\n\tv160 = v42 + 7;\n\tv152 = v160 & 7;\n\tv161 = v152 == 0;\n\tv150 = ~v161;\n\tif (v150) goto L_0078;\n\tOni::AddCollider(this.oniCollider);\n\tgoto L_0078;\nL_006D:\n\tv73 = System.IntPtr::op_Inequality(this.oniCollider, 0);\n\tv90 = v73 == 0;\n\tif (v90) goto L_0078;\n\tObi.ObiColliderBase::RemoveCollider(this);\nL_0078:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateIfNeeded()
		{
			//IL_0142: Expected O, but got I4
			bool flag = default(bool);
			Component unityCollider = GetUnityCollider(ref flag);
			if (unityCollider != null)
			{
				if (Tracker == null || !Tracker.UpdateIfNeeded())
				{
					Transform transform = base.transform;
					if (!transform.hasChanged && !dirty && flag == wasUnityColliderEnabled)
					{
						return;
					}
				}
				dirty = false;
				wasUnityColliderEnabled = flag;
				Oni.RemoveCollider(oniCollider);
				UpdateAdaptor();
				object obj = (flag ? 1 : 0) + 7;
				if ((int)((long)(IntPtr)obj & 7L) == 0)
				{
					Oni.AddCollider(oniCollider);
				}
			}
			else if (oniCollider != (IntPtr)0)
			{
				RemoveCollider();
			}
		}

		[Token(Token = "0x6000232")]
		[Address(RVA = "0xE42598", Offset = "0xE42598", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = UnityEngine.Component::get_transform(this);\n\tUnityEngine.Transform::set_hasChanged(v7, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ResetTransformChangeFlag()
		{
			Transform transform = base.transform;
			transform.hasChanged = false;
		}

		[Token(Token = "0x6000233")]
		[Address(RVA = "0xE425C0", Offset = "0xE425C0", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this->klass;\n\tv2 = this->klass->vtable[7];\n\tv3 = this->klass->vtable[7];\n\t// 3 IndirectJump v2 @ X2_v1, this @ X0 (Obi.ObiColliderBase), this @ X0 (Obi.ObiColliderBase), v3 @ X1_v1, v2 @ X2_v1, v4 @ X3, v5 @ X4, v6 @ X5, v7 @ X6, v8 @ X7, v9 @ V0, v10 @ V1, v11 @ V2, v12 @ V3, v13 @ V4, v14 @ V5, v15 @ V6, v16 @ V7\n\treturn;\n")]
		private void Awake()
		{
			//IL_0005: Expected I, but got O
			//IL_0015: Expected O, but got I
			//IL_0025: Expected O, but got I
			IntPtr intPtr = (IntPtr)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1 (Il2CppClass<Obi.ObiColliderBase>)+1A0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1 (Il2CppClass<Obi.ObiColliderBase>)+1A8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v2 @ X2_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000234")]
		[Address(RVA = "0xE425CC", Offset = "0xE425CC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tObi.ObiColliderBase::RemoveCollider(this);\n\treturn;\n")]
		private void OnDestroy()
		{
			RemoveCollider();
		}

		[Token(Token = "0x6000235")]
		[Address(RVA = "0xE425D0", Offset = "0xE425D0", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tOni::AddCollider(this.oniCollider);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnEnable()
		{
			Oni.AddCollider(oniCollider);
		}

		[Token(Token = "0x6000236")]
		[Address(RVA = "0xE425DC", Offset = "0xE425DC", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tOni::RemoveCollider(this.oniCollider);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDisable()
		{
			Oni.RemoveCollider(oniCollider);
		}

		[Token(Token = "0x6000237")]
		[Address(RVA = "0xE41340", Offset = "0xE41340", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EE1FD0]);\n\tv19 = *([v18 @ X8_v5]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024727]) = v38;\nL_0014:\n\tthis.oniCollider = 0;\n\tthis.wasUnityColliderEnabled = 1;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal ObiColliderBase()
		{
			oniCollider = (IntPtr)0;
			wasUnityColliderEnabled = true;
		}

		[Token(Token = "0x6000238")]
		[Address(RVA = "0xE425E8", Offset = "0xE425E8", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv16 = *([1F02780]);\n\tv17 = *([v16 @ X8_v14]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2024728]) = v37;\nL_0017:\n\tv43 = Unity.Profiling.ProfilerMarker::Internal_Create(\"UpdateColliders\", 0);\n\tv47.m_UpdateCollidersPerfMarker = v43;\n\tv51 = new System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Component>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Component>::.ctor(v51);\n\tv57.idToCollider = v51;\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static ObiColliderBase()
		{
			//IL_0034: Expected O, but got I
			IntPtr intPtr = ProfilerMarker.Internal_Create("UpdateColliders", default(Unity.Profiling.MarkerFlags));
			m_UpdateCollidersPerfMarker = (ProfilerMarker)(long)intPtr;
			Dictionary<int, Component> dictionary = new Dictionary<int, Component>();
			idToCollider = dictionary;
		}
	}
}
