using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Profiling;
using UnityEngine;

namespace Obi
{
	[ExecuteInEditMode]
	[Token(Token = "0x200002D")]
	public abstract class ObiRigidbodyBase : MonoBehaviour
	{
		[Token(Token = "0x20000AE")]
		private delegate void RigidbodyUpdateCallback();

		[Token(Token = "0x40000AC")]
		private static ProfilerMarker m_UpdateRigidbodiesPerfMarker;

		[Token(Token = "0x40000AD")]
		private static ProfilerMarker m_UpdateRigidbodyVelocitiesPerfMarker;

		[Token(Token = "0x40000AE")]
		[FieldOffset(Offset = "0x18")]
		public bool kinematicForParticles;

		[Token(Token = "0x40000AF")]
		[FieldOffset(Offset = "0x20")]
		private IntPtr oniRigidbody;

		[Token(Token = "0x40000B0")]
		[FieldOffset(Offset = "0x28")]
		protected Oni.Rigidbody adaptor;

		[Token(Token = "0x40000B1")]
		[FieldOffset(Offset = "0x6C")]
		protected internal Oni.RigidbodyVelocities oniVelocities;

		[Token(Token = "0x40000B2")]
		[FieldOffset(Offset = "0x84")]
		protected internal Vector3 velocity;

		[Token(Token = "0x40000B3")]
		[FieldOffset(Offset = "0x90")]
		protected internal Vector3 angularVelocity;

		[CompilerGenerated]
		[Token(Token = "0x40000B4")]
		private static RigidbodyUpdateCallback m_OnUpdateRigidbodies;

		[CompilerGenerated]
		[Token(Token = "0x40000B5")]
		private static RigidbodyUpdateCallback m_OnUpdateVelocities;

		[Token(Token = "0x1700003D")]
		public IntPtr OniRigidbody
		{
			[Token(Token = "0x6000256")]
			[Address(RVA = "0xC32AB4", Offset = "0xC32AB4", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EB2598]);\n\tv19 = *([v18 @ X8_v4]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20231A0]) = v38;\nL_0016:\n\tv42 = System.IntPtr::op_Equality(this.oniRigidbody, 0);\n\tv44 = v42 == 0;\n\tif (v44) goto L_001E;\n\treturnVal1 = Oni::CreateRigidbody();\n\tthis.oniRigidbody = returnVal1;\n\tgoto L_0024;\nL_001E:\n\treturnVal1 = this.oniRigidbody;\nL_0024:\n\treturn returnVal1;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return (!(oniRigidbody == (IntPtr)0)) ? oniRigidbody : (oniRigidbody = Oni.CreateRigidbody());
			}
		}

		[Token(Token = "0x1400000A")]
		private static event RigidbodyUpdateCallback OnUpdateRigidbodies
		{
			[CompilerGenerated]
			[Token(Token = "0x6000252")]
			[Address(RVA = "0xC33120", Offset = "0xC33120", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1F091A8]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202319C]) = v44;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<Obi.ObiRigidbodyBase>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = Obi.ObiRigidbodyBase;\nL_002A:\n\tv107 = System.Delegate::Combine(v102, value);\n\tv108 = v107 == 0;\n\tif (v108) goto L_003F;\n\tv120 = *([v107 @ X0_v6 (System.Delegate)]) != Obi.ObiRigidbodyBase+RigidbodyUpdateCallback;\n\tif (v120) goto L_0061;\nL_003F:\n\tgoto L_0049;\n\tv138 = *([v132 @ X0_v7 (Il2CppClass<Obi.ObiRigidbodyBase>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0049;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v132, v130, v106, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = Obi.ObiRigidbodyBase;\nL_0049:\n\tv144 = v141.m_UpdateRigidbodiesPerfMarker + 0x10;\n\tv97 = 0x874190(v144, v107, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = v102 != v97;\n\tif (v67) goto L_002A;\n\treturn;\nL_0061:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0058: Unknown result type (might be due to invalid IL or missing references)
				//IL_005d: Expected O, but got Unknown
				Delegate obj = ObiRigidbodyBase.m_OnUpdateRigidbodies;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Combine(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(RigidbodyUpdateCallback))
					{
						break;
					}
					object obj3 = m_UpdateRigidbodiesPerfMarker + 16;
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
			[Token(Token = "0x6000253")]
			[Address(RVA = "0xC33210", Offset = "0xC33210", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EB0A30]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202319D]) = v44;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<Obi.ObiRigidbodyBase>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = Obi.ObiRigidbodyBase;\nL_002A:\n\tv107 = System.Delegate::Remove(v102, value);\n\tv108 = v107 == 0;\n\tif (v108) goto L_003F;\n\tv120 = *([v107 @ X0_v6 (System.Delegate)]) != Obi.ObiRigidbodyBase+RigidbodyUpdateCallback;\n\tif (v120) goto L_0061;\nL_003F:\n\tgoto L_0049;\n\tv138 = *([v132 @ X0_v7 (Il2CppClass<Obi.ObiRigidbodyBase>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0049;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v132, v130, v106, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = Obi.ObiRigidbodyBase;\nL_0049:\n\tv144 = v141.m_UpdateRigidbodiesPerfMarker + 0x10;\n\tv97 = 0x874190(v144, v107, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = v102 != v97;\n\tif (v67) goto L_002A;\n\treturn;\nL_0061:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0058: Unknown result type (might be due to invalid IL or missing references)
				//IL_005d: Expected O, but got Unknown
				Delegate obj = ObiRigidbodyBase.m_OnUpdateRigidbodies;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Remove(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(RigidbodyUpdateCallback))
					{
						break;
					}
					object obj3 = m_UpdateRigidbodiesPerfMarker + 16;
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

		[Token(Token = "0x1400000B")]
		private static event RigidbodyUpdateCallback OnUpdateVelocities
		{
			[CompilerGenerated]
			[Token(Token = "0x6000254")]
			[Address(RVA = "0xC33300", Offset = "0xC33300", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EA8EE0]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202319E]) = v44;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<Obi.ObiRigidbodyBase>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = Obi.ObiRigidbodyBase;\nL_002A:\n\tv107 = System.Delegate::Combine(v102, value);\n\tv108 = v107 == 0;\n\tif (v108) goto L_003F;\n\tv120 = *([v107 @ X0_v6 (System.Delegate)]) != Obi.ObiRigidbodyBase+RigidbodyUpdateCallback;\n\tif (v120) goto L_0061;\nL_003F:\n\tgoto L_0049;\n\tv138 = *([v132 @ X0_v7 (Il2CppClass<Obi.ObiRigidbodyBase>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0049;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v132, v130, v106, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = Obi.ObiRigidbodyBase;\nL_0049:\n\tv144 = v141.m_UpdateRigidbodiesPerfMarker + 0x18;\n\tv97 = 0x874190(v144, v107, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = v102 != v97;\n\tif (v67) goto L_002A;\n\treturn;\nL_0061:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0058: Unknown result type (might be due to invalid IL or missing references)
				//IL_005d: Expected O, but got Unknown
				Delegate obj = ObiRigidbodyBase.m_OnUpdateVelocities;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Combine(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(RigidbodyUpdateCallback))
					{
						break;
					}
					object obj3 = m_UpdateRigidbodiesPerfMarker + 24;
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
			[Token(Token = "0x6000255")]
			[Address(RVA = "0xC333F0", Offset = "0xC333F0", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1F060A8]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202319F]) = v44;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<Obi.ObiRigidbodyBase>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = Obi.ObiRigidbodyBase;\nL_002A:\n\tv107 = System.Delegate::Remove(v102, value);\n\tv108 = v107 == 0;\n\tif (v108) goto L_003F;\n\tv120 = *([v107 @ X0_v6 (System.Delegate)]) != Obi.ObiRigidbodyBase+RigidbodyUpdateCallback;\n\tif (v120) goto L_0061;\nL_003F:\n\tgoto L_0049;\n\tv138 = *([v132 @ X0_v7 (Il2CppClass<Obi.ObiRigidbodyBase>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0049;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v132, v130, v106, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = Obi.ObiRigidbodyBase;\nL_0049:\n\tv144 = v141.m_UpdateRigidbodiesPerfMarker + 0x18;\n\tv97 = 0x874190(v144, v107, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = v102 != v97;\n\tif (v67) goto L_002A;\n\treturn;\nL_0061:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0058: Unknown result type (might be due to invalid IL or missing references)
				//IL_005d: Expected O, but got Unknown
				Delegate obj = ObiRigidbodyBase.m_OnUpdateVelocities;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Remove(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(RigidbodyUpdateCallback))
					{
						break;
					}
					object obj3 = m_UpdateRigidbodiesPerfMarker + 24;
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

		[Token(Token = "0x6000257")]
		[Address(RVA = "0xC3296C", Offset = "0xC3296C", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EFC010]);\n\tv21 = *([v20 @ X8_v15]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20231A1]) = v40;\nL_0014:\n\t;\n\tv45 = Obi.ObiRigidbodyBase::UpdateIfNeeded(this);\n\tv49 = new Obi.ObiRigidbodyBase+RigidbodyUpdateCallback();\n\tv52 = this->klass;\n\tv53 = this->klass->vtable[5];\n\tv49.m_target = this;\n\tv49.method = this->klass->vtable[5];\n\tv49.method_ptr = v53.m_value;\n\tgoto L_0033;\n\tv63 = *([v57 @ X0_v8+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_0033;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v57, v44, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0033:\n\tObi.ObiRigidbodyBase::add_OnUpdateRigidbodies(v49);\n\tv72 = new Obi.ObiRigidbodyBase+RigidbodyUpdateCallback();\n\tv89 = this->klass;\n\tv84 = this->klass->vtable[6];\n\tv72.m_target = this;\n\tv72.method = this->klass->vtable[6];\n\tv72.method_ptr = v84.m_value;\n\tObi.ObiRigidbodyBase::add_OnUpdateVelocities(v72);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe virtual void Awake()
		{
			//IL_000a: Expected I, but got O
			//IL_0068: Expected I, but got O
			UpdateIfNeeded();
			RigidbodyUpdateCallback rigidbodyUpdateCallback = null;
			IntPtr intPtr = (IntPtr)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X8_v4 (Il2CppClass<Obi.ObiRigidbodyBase>)+188]");
			IntPtr intPtr2 = (IntPtr)0;
			((Delegate)rigidbodyUpdateCallback).m_target = this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X8_v4 (Il2CppClass<Obi.ObiRigidbodyBase>)+188]");
			((Delegate)rigidbodyUpdateCallback).method = (IntPtr)0;
			((Delegate)rigidbodyUpdateCallback).method_ptr = (IntPtr)((IntPtr*)intPtr2)->m_value;
			OnUpdateRigidbodies += rigidbodyUpdateCallback;
			RigidbodyUpdateCallback rigidbodyUpdateCallback2 = null;
			IntPtr intPtr3 = (IntPtr)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ X8_v10 (Il2CppClass<Obi.ObiRigidbodyBase>)+198]");
			IntPtr intPtr4 = (IntPtr)0;
			((Delegate)rigidbodyUpdateCallback2).m_target = this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ X8_v10 (Il2CppClass<Obi.ObiRigidbodyBase>)+198]");
			((Delegate)rigidbodyUpdateCallback2).method = (IntPtr)0;
			((Delegate)rigidbodyUpdateCallback2).method_ptr = (IntPtr)((IntPtr*)intPtr4)->m_value;
			OnUpdateVelocities += rigidbodyUpdateCallback2;
		}

		[Token(Token = "0x6000258")]
		[Address(RVA = "0xC334F0", Offset = "0xC334F0", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EE7A58]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20231A2]) = v40;\nL_0017:\n\tv44 = new Obi.ObiRigidbodyBase+RigidbodyUpdateCallback();\n\tv47 = this->klass;\n\tv48 = this->klass->vtable[5];\n\tv44.m_target = this;\n\tv44.method = this->klass->vtable[5];\n\tv44.method_ptr = v48.m_value;\n\tgoto L_002E;\n\tv58 = *([v52 @ X0_v6+E0]);\n\tv59 = v58 == 0;\n\tv60 = ~v59;\n\tif (v60) goto L_002E;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v52, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002E:\n\tObi.ObiRigidbodyBase::remove_OnUpdateRigidbodies(v44);\n\tv67 = new Obi.ObiRigidbodyBase+RigidbodyUpdateCallback();\n\tv88 = this->klass;\n\tv83 = this->klass->vtable[6];\n\tv67.m_target = this;\n\tv67.method = this->klass->vtable[6];\n\tv67.method_ptr = v83.m_value;\n\tObi.ObiRigidbodyBase::remove_OnUpdateVelocities(v67);\n\tOni::DestroyRigidbody(this.oniRigidbody);\n\tthis.oniRigidbody = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void OnDestroy()
		{
			//IL_000a: Expected I, but got O
			//IL_0068: Expected I, but got O
			RigidbodyUpdateCallback rigidbodyUpdateCallback = null;
			IntPtr intPtr = (IntPtr)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X8_v3 (Il2CppClass<Obi.ObiRigidbodyBase>)+188]");
			IntPtr intPtr2 = (IntPtr)0;
			((Delegate)rigidbodyUpdateCallback).m_target = this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X8_v3 (Il2CppClass<Obi.ObiRigidbodyBase>)+188]");
			((Delegate)rigidbodyUpdateCallback).method = (IntPtr)0;
			((Delegate)rigidbodyUpdateCallback).method_ptr = (IntPtr)((IntPtr*)intPtr2)->m_value;
			OnUpdateRigidbodies -= rigidbodyUpdateCallback;
			RigidbodyUpdateCallback rigidbodyUpdateCallback2 = null;
			IntPtr intPtr3 = (IntPtr)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ X8_v9 (Il2CppClass<Obi.ObiRigidbodyBase>)+198]");
			IntPtr intPtr4 = (IntPtr)0;
			((Delegate)rigidbodyUpdateCallback2).m_target = this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ X8_v9 (Il2CppClass<Obi.ObiRigidbodyBase>)+198]");
			((Delegate)rigidbodyUpdateCallback2).method = (IntPtr)0;
			((Delegate)rigidbodyUpdateCallback2).method_ptr = (IntPtr)((IntPtr*)intPtr4)->m_value;
			OnUpdateVelocities -= rigidbodyUpdateCallback2;
			Oni.DestroyRigidbody(oniRigidbody);
			oniRigidbody = (IntPtr)0;
		}

		[Token(Token = "0x6000259")]
		[Address(RVA = "0xC335C4", Offset = "0xC335C4", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EBF1F8]);\n\tv17 = *([v16 @ X8_v19]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([20231A3]) = v37;\nL_0018:\n\tgoto L_0023;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<Obi.ObiRigidbodyBase>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0023;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv48 = Obi.ObiRigidbodyBase;\nL_0023:\n\tUnity.Profiling.ProfilerMarker::Internal_Begin(v51.m_UpdateRigidbodiesPerfMarker);\n\tgoto L_0030;\n\tv60 = *([v56 @ X0_v5 (Il2CppClass<Obi.ObiRigidbodyBase>)+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tgoto L_0030;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v56, v52, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv64 = Obi.ObiRigidbodyBase;\nL_0030:\n\tv82 = v67.OnUpdateRigidbodies;\n\tv69 = v67.OnUpdateRigidbodies == 0;\n\tif (v69) goto L_004A;\n\tv72 = *([v63 @ X0_v6 (Il2CppClass<Obi.ObiRigidbodyBase>)+12F]) & 2;\n\tv73 = v72 == 0;\n\tif (v73) goto L_0042;\n\tv90 = *([v63 @ X0_v6 (Il2CppClass<Obi.ObiRigidbodyBase>)+E0]) == 0;\n\tv91 = ~v90;\n\tif (v91) goto L_0042;\n\tv82 = v146.OnUpdateRigidbodies;\n\tv94 = v146.OnUpdateRigidbodies == 0;\n\tif (v94) goto L_004D;\nL_0042:\n\tObi.ObiRigidbodyBase+RigidbodyUpdateCallback::Invoke(v82);\nL_004A:\n\tUnity.Profiling.ProfilerMarker::Internal_End(v51.m_UpdateRigidbodiesPerfMarker);\n\treturn;\nL_004D:\n\tv148 = new System.NullReferenceException();\n\tgoto L_0059;\nL_0059:\n\tgoto L_0069;\n\tv150 = 0x6D2BC0(v148, 0, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv153 = 0x6D2490(v150, 0, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tUnity.Profiling.ProfilerMarker::Internal_End(v51.m_UpdateRigidbodiesPerfMarker);\n\tv157 = *([v150 @ X0_v18]) == 0;\n\tv138 = ~v157;\n\tif (v138) goto L_006D;\n\treturn;\nL_0069:\n\tv151 = 0x6D2380(v148, 0, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_006D:\n\tthrow System.TypeLoadException;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void UpdateAllRigidbodies()
		{
			//IL_013a: Expected I, but got O
			//IL_0148: Expected I, but got O
			//IL_00a7: Expected I, but got O
			ProfilerMarker.Internal_Begin((IntPtr)m_UpdateRigidbodiesPerfMarker);
			IntPtr intPtr = (IntPtr)typeof(ObiRigidbodyBase);
			RigidbodyUpdateCallback onUpdateRigidbodies = ObiRigidbodyBase.OnUpdateRigidbodies;
			if (ObiRigidbodyBase.OnUpdateRigidbodies != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ X0_v6 (Il2CppClass<Obi.ObiRigidbodyBase>)+12F]");
				if (0u != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ X0_v6 (Il2CppClass<Obi.ObiRigidbodyBase>)+E0]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						onUpdateRigidbodies = ObiRigidbodyBase.OnUpdateRigidbodies;
						if (ObiRigidbodyBase.OnUpdateRigidbodies == null)
						{
							NullReferenceException ex = new NullReferenceException();
							Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
							throw new TypeLoadException();
						}
					}
				}
				onUpdateRigidbodies();
			}
			ProfilerMarker.Internal_End((IntPtr)m_UpdateRigidbodiesPerfMarker);
		}

		[Token(Token = "0x600025A")]
		[Address(RVA = "0xC33900", Offset = "0xC33900", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1ED7D60]);\n\tv17 = *([v16 @ X8_v19]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([20231A4]) = v37;\nL_0018:\n\tgoto L_0023;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<Obi.ObiRigidbodyBase>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0023;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv48 = Obi.ObiRigidbodyBase;\nL_0023:\n\tUnity.Profiling.ProfilerMarker::Internal_Begin(v51.m_UpdateRigidbodyVelocitiesPerfMarker);\n\tgoto L_0030;\n\tv60 = *([v56 @ X0_v5 (Il2CppClass<Obi.ObiRigidbodyBase>)+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tgoto L_0030;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v56, v52, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv64 = Obi.ObiRigidbodyBase;\nL_0030:\n\tv82 = v67.OnUpdateVelocities;\n\tv69 = v67.OnUpdateVelocities == 0;\n\tif (v69) goto L_004A;\n\tv72 = *([v63 @ X0_v6 (Il2CppClass<Obi.ObiRigidbodyBase>)+12F]) & 2;\n\tv73 = v72 == 0;\n\tif (v73) goto L_0042;\n\tv90 = *([v63 @ X0_v6 (Il2CppClass<Obi.ObiRigidbodyBase>)+E0]) == 0;\n\tv91 = ~v90;\n\tif (v91) goto L_0042;\n\tv82 = v146.OnUpdateVelocities;\n\tv94 = v146.OnUpdateVelocities == 0;\n\tif (v94) goto L_004D;\nL_0042:\n\tObi.ObiRigidbodyBase+RigidbodyUpdateCallback::Invoke(v82);\nL_004A:\n\tUnity.Profiling.ProfilerMarker::Internal_End(v51.m_UpdateRigidbodyVelocitiesPerfMarker);\n\treturn;\nL_004D:\n\tv148 = new System.NullReferenceException();\n\tgoto L_0059;\nL_0059:\n\tgoto L_0069;\n\tv150 = 0x6D2BC0(v148, 0, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv153 = 0x6D2490(v150, 0, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tUnity.Profiling.ProfilerMarker::Internal_End(v51.m_UpdateRigidbodyVelocitiesPerfMarker);\n\tv157 = *([v150 @ X0_v18]) == 0;\n\tv138 = ~v157;\n\tif (v138) goto L_006D;\n\treturn;\nL_0069:\n\tv151 = 0x6D2380(v148, 0, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_006D:\n\tthrow System.TypeLoadException;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void UpdateAllVelocities()
		{
			//IL_013a: Expected I, but got O
			//IL_0148: Expected I, but got O
			//IL_00a7: Expected I, but got O
			ProfilerMarker.Internal_Begin((IntPtr)m_UpdateRigidbodyVelocitiesPerfMarker);
			IntPtr intPtr = (IntPtr)typeof(ObiRigidbodyBase);
			RigidbodyUpdateCallback onUpdateVelocities = ObiRigidbodyBase.OnUpdateVelocities;
			if (ObiRigidbodyBase.OnUpdateVelocities != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ X0_v6 (Il2CppClass<Obi.ObiRigidbodyBase>)+12F]");
				if (0u != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ X0_v6 (Il2CppClass<Obi.ObiRigidbodyBase>)+E0]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						onUpdateVelocities = ObiRigidbodyBase.OnUpdateVelocities;
						if (ObiRigidbodyBase.OnUpdateVelocities == null)
						{
							NullReferenceException ex = new NullReferenceException();
							Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
							throw new TypeLoadException();
						}
					}
				}
				onUpdateVelocities();
			}
			ProfilerMarker.Internal_End((IntPtr)m_UpdateRigidbodyVelocitiesPerfMarker);
		}

		[Token(Token = "0x600025B")]
		public abstract void UpdateIfNeeded();

		[Token(Token = "0x600025C")]
		public abstract void UpdateVelocities();

		[Token(Token = "0x600025D")]
		[Address(RVA = "0xC32D50", Offset = "0xC32D50", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EF0AD0]);\n\tv19 = *([v18 @ X8_v4]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20231A5]) = v38;\nL_0013:\n\tthis.oniRigidbody = 0;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal ObiRigidbodyBase()
		{
			oniRigidbody = (IntPtr)0;
		}

		[Token(Token = "0x600025E")]
		[Address(RVA = "0xC33A20", Offset = "0xC33A20", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1EC7670]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20231A6]) = v35;\nL_0016:\n\tv41 = Unity.Profiling.ProfilerMarker::Internal_Create(\"UpdateRigidbodies\", 0);\n\tv47.m_UpdateRigidbodiesPerfMarker = v41;\n\tv51 = Unity.Profiling.ProfilerMarker::Internal_Create(\"UpdateRigidbodyVelocities\", 0);\n\tv53.m_UpdateRigidbodyVelocitiesPerfMarker = v51;\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static ObiRigidbodyBase()
		{
			//IL_002a: Expected O, but got I
			//IL_004f: Expected O, but got I
			IntPtr intPtr = ProfilerMarker.Internal_Create("UpdateRigidbodies", default(Unity.Profiling.MarkerFlags));
			m_UpdateRigidbodiesPerfMarker = (ProfilerMarker)(long)intPtr;
			IntPtr intPtr2 = ProfilerMarker.Internal_Create("UpdateRigidbodyVelocities", default(Unity.Profiling.MarkerFlags));
			m_UpdateRigidbodyVelocitiesPerfMarker = (ProfilerMarker)(long)intPtr2;
		}
	}
}
