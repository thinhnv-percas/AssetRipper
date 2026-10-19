using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Coffee.UIParticleInternal
{
	[Token(Token = "0x2000018")]
	internal class ObjectRepository<T> where T : UnityEngine.Object
	{
		[Token(Token = "0x2000019")]
		private class Entry
		{
			[Token(Token = "0x400001D")]
			[FieldOffset(Offset = "0x0")]
			public Hash128 hash;

			[Token(Token = "0x400001E")]
			[FieldOffset(Offset = "0x0")]
			public int reference;

			[Token(Token = "0x400001F")]
			[FieldOffset(Offset = "0x0")]
			public T storedObject;

			[Token(Token = "0x6000068")]
			[Address(RVA = "0x75DCF48", Offset = "0x75DCF48", Length = "0xCC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = 0xB794000;\n\tv22 = *([B794FC2]) & 1;\n\tv23 = v22 == 0;\n\tif (v23) goto L_002A;\n\tthis.reference = 0;\n\tv51 = this.storedObject;\n\tgoto L_0019;\nL_0019:\n\tv71 = UnityEngine.Object::op_Implicit(v51);\n\tv63 = onRelease == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_0038;\nL_001D:\n\tthis.storedObject = 0;\n\treturn;\nL_002A:\n\t*([v18 @ X21_v1+FC2]) = 1;\n\tthis.reference = 0;\n\tv51 = this.storedObject;\n\tgoto L_0019;\nL_0038:\n\tv74 = ~v71;\n\tif (v74) goto L_001D;\n\tSystem.Action`1<T>::Invoke(onRelease, this.storedObject);\n\tthis.storedObject = 0;\n\treturn;\n")]
			public void Release(Action<T> onRelease)
			{
				//IL_0009: Expected O, but got I4
				object obj = 192495616;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B794FC2]");
				UnityEngine.Object obj2;
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					reference = 0;
					obj2 = storedObject;
				}
				else
				{
					_ = 1;
					reference = 0;
					obj2 = storedObject;
				}
				bool flag = obj2;
				if (onRelease == null || !flag)
				{
					storedObject = null;
					return;
				}
				onRelease(storedObject);
				storedObject = null;
			}

			[Token(Token = "0x6000069")]
			[Address(RVA = "0x75DD014", Offset = "0x75DD014", Length = "0xA8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\treturnVal1 = System.String::Format(\"h{0} (refs#{1}), {2}\", v52, v58, this.storedObject);\n\treturn returnVal1;\nL_0016:\n\tv44 = this + 0x10;\n\tv46 = UnityEngine.Hash128::GetHashCode(v44);\n\tv47 = v46;\n\tv49 = 0xB7D5000 + 0x538;\n\tv52 = \"il2cpp_vm_object_box\"(*([v49 @ X22_v2 (System.Int32)+50]), &v47 @ stack_-34_v1 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv55 = this.reference;\n\tv58 = \"il2cpp_vm_object_box\"(*([v49 @ X22_v2 (System.Int32)+48]), &v55 @ stack_-38_v1 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n")]
			public unsafe override string ToString()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ObjectRepository.Entry::ToString");
				return default;
			}

			[Token(Token = "0x600006A")]
			[Address(RVA = "0x75DD0BC", Offset = "0x75DD0BC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public Entry()
			{
			}
		}

		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200001A")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000020")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000021")]
			public static Action<T> _003C_003E9__5_0;

			[Token(Token = "0x600006B")]
			[Address(RVA = "0x4F95788", Offset = "0x4F95788", Length = "0x15C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1+<>c>;\n\tv15 = *([v12 @ X0_v1 (Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1+<>c>)+135]) & 1;\n\tv16 = v15 == 0;\n\tif (v16) goto L_0046;\n\tv18 = Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>;\n\tv21 = *([v18 @ X0_v37 (Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>)+135]) & 1;\n\tv22 = v21 == 0;\nL_FFFFFFFF:\n\tv43 = Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>;\nL_FFFFFFFF:\n\tv48 = Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>;\n\tif (v22) goto L_004F;\nL_0014:\n\tv45 = new v43();\nL_FFFFFFFF:\n\tv71 = v45;\n\tgoto L_0020;\nL_0020:\n\tSystem.Object::.ctor(v71);\n\tv79 = Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1+<>c>;\n\tv82 = *([v79 @ X0_v10 (Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1+<>c>)+135]) & 1;\n\tv83 = v82 == 0;\n\tif (v83) goto L_0059;\n\tv85 = Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>;\n\tv88 = *([v85 @ X0_v30 (Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>)+135]) & 1;\n\tv89 = v88 == 0;\nL_FFFFFFFF:\n\tv105 = Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>;\n\tif (v89) goto L_0062;\nL_002F:\n\tv97.<>9 = v71;\n\tv98 = Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1+<>c>;\n\tv101 = *([v98 @ X0_v29 (Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1+<>c>)+135]) & 1;\n\tv102 = v101 == 0;\nL_FFFFFFFF:\n\tv125 = Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1+<>c>;\n\tif (v102) goto L_006C;\nL_0037:\n\tv118 = Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>;\n\tv121 = *([v118 @ X0_v27 (Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>)+135]) & 1;\n\tv122 = v121 == 0;\nL_FFFFFFFF:\n\tv146 = Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>;\n\tif (v122) goto L_0075;\nL_0045:\n\treturn;\nL_0046:\n\tv23 = 0x220C238(Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1+<>c>, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv50 = *([v23 @ X0_v6+C0]);\n\tv43 = *([v50 @ X8_v6]);\n\tv52 = *([v43 @ X0_v34 (Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>)+135]) & 1;\n\tv53 = v52 == 0;\n\tv40 = ~v53;\nL_FFFFFFFF:\n\tv48 = v43;\n\tif (v40) goto L_0014;\nL_004F:\n\tv49 = 0x220C238(v48, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv61 = new v49();\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv71 = v61;\n\tgoto L_0020;\nL_0059:\n\tv90 = 0x220C238(Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1+<>c>, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv107 = *([v90 @ X0_v21+C0]);\n\tv105 = *([v107 @ X8_v21+10]);\n\tv109 = *([v105 @ X0_v18 (Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>)+135]) & 1;\n\tv110 = v109 == 0;\n\tv92 = ~v110;\n\tif (v92) goto L_002F;\nL_0062:\n\tv106 = 0x220C238(v105, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv127 = *([v106 @ X0_v19+B8]);\n\t*([v127 @ X8_v18]) = v71;\n\tv116 = Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1+<>c>;\n\tv129 = *([v116 @ X0_v20 (Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1+<>c>)+135]) & 1;\n\tv130 = v129 == 0;\n\tv112 = ~v130;\nL_FFFFFFFF:\n\tv125 = Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1+<>c>;\n\tif (v112) goto L_0037;\nL_006C:\n\tv126 = 0x220C238(v125, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv148 = *([v126 @ X0_v16+C0]);\n\tv146 = *([v148 @ X8_v14+10]);\n\tv150 = *([v146 @ X0_v11 (Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>)+135]) & 1;\n\tv151 = v150 == 0;\n\tv132 = ~v151;\n\tif (v132) goto L_0045;\nL_0075:\n\tv147 = 0x220C238(v146, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\n")]
			static _003C_003Ec()
			{
				//IL_01af: Expected O, but got I
				//IL_01b7: Expected I, but got O
				//IL_0247: Expected O, but got I
				//IL_0325: Expected O, but got I
				//IL_02b4: Expected O, but got I
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X0_v1 (Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1+<>c>)+135]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ X0_v37 (Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>)+135]");
					int num3 = (int)((nint)0 & (nint)1);
					bool flag = num3 == 0;
					nint num4 = 0;
					nint num5 = 0;
					if (!flag)
					{
						goto IL_007e;
					}
				}
				else
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X0_v6+C0]");
					object obj = 0;
					nint num4 = (nint)obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ X0_v34 (Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>)+135]");
					int num6 = (int)((nint)0 & (nint)1);
					bool flag2 = num6 == 0;
					bool flag3 = !flag2;
					nint num5 = num4;
					if (flag3)
					{
						goto IL_007e;
					}
				}
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				_003C_003Ec _003C_003Ec2 = null;
				_003C_003Ec _003C_003Ec3 = _003C_003Ec2;
				goto IL_0090;
				IL_0108:
				_003C_003E9 = _003C_003Ec3;
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ X0_v29 (Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1+<>c>)+135]");
				int num8 = (int)((nint)0 & (nint)1);
				bool flag4 = num8 == 0;
				nint num9 = 0;
				if (!flag4)
				{
					goto IL_0150;
				}
				goto IL_0306;
				IL_0306:
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ X0_v16+C0]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ X8_v14+10]");
				nint num10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ X0_v11 (Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>)+135]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					return;
				}
				goto IL_0373;
				IL_0150:
				nint num11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X0_v27 (Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>)+135]");
				int num12 = (int)((nint)0 & (nint)1);
				bool flag5 = num12 == 0;
				num10 = 0;
				if (!flag5)
				{
					return;
				}
				goto IL_0373;
				IL_007e:
				_003C_003Ec _003C_003Ec4 = null;
				_003C_003Ec3 = _003C_003Ec4;
				goto IL_0090;
				IL_0090:
				nint num13 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ X0_v10 (Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1+<>c>)+135]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					nint num14 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ X0_v30 (Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>)+135]");
					int num15 = (int)((nint)0 & (nint)1);
					bool flag6 = num15 == 0;
					nint num16 = 0;
					if (!flag6)
					{
						goto IL_0108;
					}
				}
				else
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ X0_v21+C0]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ X8_v21+10]");
					nint num16 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ X0_v18 (Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>)+135]");
					if ((uint)((nuint)0u & (nuint)1u) != 0)
					{
						goto IL_0108;
					}
				}
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ X0_v19+B8]");
				object obj4 = 0;
				obj4 = _003C_003Ec3;
				nint num17 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ X0_v20 (Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1+<>c>)+135]");
				int num18 = (int)((nint)0 & (nint)1);
				bool flag7 = num18 == 0;
				bool flag8 = !flag7;
				num9 = 0;
				if (flag8)
				{
					goto IL_0150;
				}
				goto IL_0306;
				IL_0373:
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			}

			[Token(Token = "0x600006C")]
			[Address(RVA = "0x4F958E4", Offset = "0x4F958E4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal void _003C_002Ector_003Eb__5_0(T x)
			{
				UnityEngine.Object.Destroy(x);
			}
		}

		[Token(Token = "0x4000018")]
		[FieldOffset(Offset = "0x0")]
		private readonly Dictionary<Hash128, Entry> _cache;

		[Token(Token = "0x4000019")]
		[FieldOffset(Offset = "0x0")]
		private readonly Dictionary<int, Hash128> _objectKey;

		[Token(Token = "0x400001A")]
		[FieldOffset(Offset = "0x0")]
		private readonly string _name;

		[Token(Token = "0x400001B")]
		[FieldOffset(Offset = "0x0")]
		private readonly Action<T> _onRelease;

		[Token(Token = "0x400001C")]
		[FieldOffset(Offset = "0x0")]
		private readonly Stack<Entry> _pool;

		[Token(Token = "0x17000003")]
		public int count
		{
			[Token(Token = "0x600005F")]
			[Address(RVA = "0x5E94554", Offset = "0x5E94554", Length = "0x24")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = System.Collections.Generic.Dictionary`2<UnityEngine.Hash128, Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>>::get_Count(this._cache);\n\treturn returnVal1;\n")]
			get
			{
				return _cache.Count;
			}
		}

		[Token(Token = "0x600005E")]
		[Address(RVA = "0x5E93F68", Offset = "0x5E93F68", Length = "0x5EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\nL_002C:\n\tv66 = new Il2CppClass<System.Collections.Generic.Dictionary`2<UnityEngine.Hash128, Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>>>();\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.Hash128, Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>>::.ctor(v66, 8);\n\tthis._cache = v66;\n\tv79 = new System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Hash128>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Hash128>::.ctor(v79, 8);\n\tthis._objectKey = v79;\n\tgoto L_004D;\nL_004D:\n\tv97 = new Il2CppClass<System.Collections.Generic.Stack`1<Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>>>();\n\tSystem.Collections.Generic.Stack`1<Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>>::.ctor(v97, 8);\n\tthis._pool = v97;\n\tSystem.Object::.ctor(this);\n\tgoto L_006A;\nL_006A:\n\tv123 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tv130 = System.Reflection.MemberInfo::get_Name(v123);\n\tv133 = System.String::Concat(v130, \"Repository\");\n\tthis._name = v133;\n\tv210 = onRelease == 0;\n\tv211 = ~v210;\nL_FFFFFFFF:\n\tv264 = onRelease;\n\tif (v211) goto L_00EC;\n\tv241 = Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>;\n\tv244 = *([v241 @ X0_v73 (Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>)+135]) & 1;\n\tv245 = v244 == 0;\n\tif (v245) goto L_0097;\n\tgoto L_008B;\nL_008B:\n\tv290 = Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>;\n\tv293 = *([v290 @ X0_v107 (Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>)+135]) & 1;\n\tv294 = v293 == 0;\nL_FFFFFFFF:\n\tv254 = Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>;\nL_FFFFFFFF:\n\tv308 = Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>;\n\tif (v294) goto L_00A6;\nL_0091:\n\tv262 = *([v254 @ X0_v105 (Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>)+B8]);\n\tv264 = *([v262 @ X8_v133 (Il2CppStaticFields<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>)+8]);\n\tv307 = *([v262 @ X8_v133 (Il2CppStaticFields<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>)+8]) == 0;\n\tv258 = ~v307;\n\tif (v258) goto L_00EC;\n\tgoto L_00AE;\nL_0097:\n\tv274 = 0x220C238(Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>, v133, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv299 = *([v274 @ X0_v104+E4]) == 0;\n\tv285 = ~v299;\n\tif (v285) goto L_008B;\n\tv302 = Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>;\n\tv314 = *([v302 @ X0_v103 (Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>)+135]) & 1;\n\tv315 = v314 == 0;\n\tv304 = ~v315;\nL_FFFFFFFF:\n\tv254 = Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>;\nL_FFFFFFFF:\n\tv308 = Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>;\n\tif (v304) goto L_0091;\nL_00A6:\n\tv255 = 0x220C238(v308, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv263 = *([v255 @ X0_v100+B8]);\n\tv264 = *([v263 @ X8_v125+8]);\n\tv317 = *([v263 @ X8_v125+8]) == 0;\n\tv259 = ~v317;\n\tif (v259) goto L_00EC;\nL_00AE:\n\tv324 = Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>;\n\tv327 = *([v324 @ X0_v75 (Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>)+135]) & 1;\n\tv328 = v327 == 0;\n\tif (v328) goto L_01C2;\n\tgoto L_00B9;\nL_00B9:\n\tv351 = Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>;\n\tv354 = *([v351 @ X0_v98 (Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>)+135]) & 1;\n\tv355 = v354 == 0;\nL_FFFFFFFF:\n\tv380 = Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>;\n\tif (v355) goto L_01D1;\nL_00C0:\n\tv248 = v371.<>9;\nL_FFFFFFFF:\n\tv401 = Il2CppClass<System.Action`1<T>>;\n\tgoto L_00C9;\nL_00C9:\n\tv404 = new v401();\n\tSystem.Action`1<T>::.ctor(v404, v248, Il2CppMethodInfo);\nL_FFFFFFFF:\n\tv433 = Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>;\n\tgoto L_00DD;\nL_FFFFFFFF:\n\tv264 = v404;\nL_00EC:\n\tthis._onRelease = v264;\n\tgoto L_00FB;\nL_00FB:\n\tv160 = new Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>>();\n\tCoffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>::.ctor(v160);\n\tSystem.Collections.Generic.Stack`1<Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>>::Push(this._pool, v160);\n\tgoto L_0114;\nL_0114:\n\tv161 = new Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>>();\n\tCoffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>::.ctor(v161);\n\tSystem.Collections.Generic.Stack`1<Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>>::Push(this._pool, v161);\n\tgoto L_012D;\nL_012D:\n\tv162 = new Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>>();\n\tCoffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>::.ctor(v162);\n\tSystem.Collections.Generic.Stack`1<Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>>::Push(this._pool, v162);\n\tgoto L_0146;\nL_0146:\n\tv163 = new Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>>();\n\tCoffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>::.ctor(v163);\n\tSystem.Collections.Generic.Stack`1<Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>>::Push(this._pool, v163);\n\tgoto L_015F;\nL_015F:\n\tv164 = new Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>>();\n\tCoffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>::.ctor(v164);\n\tSystem.Collections.Generic.Stack`1<Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>>::Push(this._pool, v164);\n\tgoto L_0178;\nL_0178:\n\tv165 = new Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>>();\n\tCoffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>::.ctor(v165);\n\tSystem.Collections.Generic.Stack`1<Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>>::Push(this._pool, v165);\n\tgoto L_0191;\nL_0191:\n\tv166 = new Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>>();\n\tCoffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>::.ctor(v166);\n\tSystem.Collections.Generic.Stack`1<Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>>::Push(this._pool, v166);\n\tgoto L_01AA;\nL_01AA:\n\tv167 = new Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>>();\n\tCoffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>::.ctor(v167);\n\tSystem.Collections.Generic.Stack`1<Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>>::Push(this._pool, v167);\n\treturn;\nL_01C2:\n\tv335 = 0x220C238(Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv360 = *([v335 @ X0_v82+E4]) == 0;\n\tv346 = ~v360;\n\tif (v346) goto L_00B9;\n\tv366 = Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>;\n\tv386 = *([v366 @ X0_v81 (Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>)+135]) & 1;\n\tv387 = v386 == 0;\n\tv368 = ~v387;\nL_FFFFFFFF:\n\tv380 = Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>;\n\tif (v368) goto L_00C0;\nL_01D1:\n\tv383 = 0x220C238(v380, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv390 = *([v383 @ X0_v77+B8]);\n\tv248 = *([v390 @ X9_v5]);\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv401 = Il2CppClass<System.Action`1<T>>;\n\tgoto L_00C9;\nL_002A:\n\tgoto L_002C;\nL_00DD:\n\tv247 = *([v433 @ X0_v86 (Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>)+B8]);\n\t*([v247 @ X9_v11 (Il2CppStaticFields<Coffee.UIParticleInternal.ObjectRepository`1<T>+<>c<T>>)+8]) = v404;\n\tgoto L_FFFFFFFF;\n")]
		public ObjectRepository(Action<T> onRelease = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ObjectRepository::.ctor");
		}

		[Token(Token = "0x6000060")]
		[Address(RVA = "0x5E94578", Offset = "0x5E94578", Length = "0x1C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv57 = System.Collections.Generic.Dictionary`2<UnityEngine.Hash128, Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>>::GetEnumerator(this._cache);\n\tv143 = v57._dictionary;\n\tgoto L_003B;\n\tv273 = *([v57 @ X0_v21 (System.Collections.Generic.Dictionary`2<UnityEngine.Hash128, Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>>+Enumerator<UnityEngine.Hash128, Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>>)+20]) == 0;\n\tif (v273) goto L_003B;\n\tCoffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>::Release(*([v57 @ X0_v21 (System.Collections.Generic.Dictionary`2<UnityEngine.Hash128, Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>>+Enumerator<UnityEngine.Hash128, Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>>)+20]), this._onRelease);\n\tSystem.Collections.Generic.Stack`1<Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>>::Push(this._pool, *([v57 @ X0_v21 (System.Collections.Generic.Dictionary`2<UnityEngine.Hash128, Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>>+Enumerator<UnityEngine.Hash128, Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>>)+20]));\n\tgoto L_003B;\nL_0055:\n\tv276 = &v277 @ stack_-38_v7 (Il2CppMethodInfo);\n\tv278 = *([v276 @ X8_v21]);\n\tv279 = *([v278 @ X8_v22+20]);\n\tv280 = *([v279 @ X8_v23+C0]);\n\tv149 = *([v280 @ X8_v24+C0]);\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.Hash128, System.Object>+Enumerator<UnityEngine.Hash128, System.Object>::Dispose(&v143 @ stack_-70_v6 (System.Collections.Generic.Dictionary`2<UnityEngine.Hash128, Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>>));\n\tv90 = &v277 @ stack_-38_v7 (Il2CppMethodInfo);\n\tv94 = &v47 @ stack_-70_v1 (System.Int32);\n\tv98 = 0;\n\tv98 = 0;\n\tgoto L_0094;\nL_005F:\n\tv157 = this._cache == 0;\n\tv88 = &v277 @ stack_-38_v7 (Il2CppMethodInfo);\n\tv92 = &v47 @ stack_-70_v1 (System.Int32);\n\tv98 = 0;\n\tv147 = this._onRelease;\n\tif (v157) goto L_0075;\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.Hash128, Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>>::Clear(this._cache);\n\tv158 = this._objectKey == 0;\n\tv88 = v90;\n\tv92 = v94;\n\tv147 = v149;\n\tif (v158) goto L_0075;\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Hash128>::Clear(this._objectKey);\n\treturn;\nL_0083:\n\tv200 = v147 != 1;\n\tv269 = v171;\n\tif (v200) goto L_0097;\n\tv204 = 0x8BF5BC4(v171, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv284 = 0x8BF5BF4(v204, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv298 = *([v88 @ stack_-78_v2]);\n\tv299 = *([v298 @ X8_v6+20]);\n\tv300 = *([v299 @ X8_v7+C0]);\n\tv149 = *([v300 @ X8_v8+C0]);\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.Hash128, System.Object>+Enumerator<UnityEngine.Hash128, System.Object>::Dispose(v92);\n\tv305 = *([v204 @ X0_v12]) == 0;\n\tv90 = v88;\n\tv94 = v92;\n\tv98 = *([v204 @ X0_v12]);\n\tv98 = *([v204 @ X0_v12]);\n\tif (v305) goto L_005F;\nL_0094:\n\tv260 = new System.OutOfMemoryException();\n\tv269 = v260;\n\treturn;\nL_0019:\n\tv47 = 0;\n\tv49 = this._cache == 0;\n\tv88 = v90;\n\tv92 = v94;\n\tv147 = Il2CppMethodInfo;\n\tif (v49) goto L_0075;\nL_003B:\n\tv189 = System.Collections.Generic.Dictionary`2<UnityEngine.Hash128, System.Object>+Enumerator<UnityEngine.Hash128, System.Object>::MoveNext(&v143 @ stack_-70_v6 (System.Collections.Generic.Dictionary`2<UnityEngine.Hash128, Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>>));\n\tv202 = v189 == 0;\n\tif (v202) goto L_0055;\nL_0075:\n\tv171 = new System.NullReferenceException();\n\tgoto L_0083;\nL_0097:\n\tv272 = 0x338BE14(&v98 @ stack_-88_v5 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv286 = 0x8BF0368(v269, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv302 = 0xA1B8(v286, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void Clear()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ObjectRepository::Clear");
		}

		[Token(Token = "0x6000061")]
		[Address(RVA = "0x5E94738", Offset = "0x5E94738", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\nL_0025:\n\treturnVal2 = System.Collections.Generic.Dictionary`2<UnityEngine.Hash128, Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>>::TryGetValue(this._cache, v47, &v63 @ stack_-48_v3 (Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>));\n\tv74 = ~returnVal2;\n\tif (v74) goto L_0041;\n\tgoto L_0037;\nL_0037:\n\treturnVal2 = UnityEngine.Object::op_Equality(v63.storedObject, obj);\nL_0041:\n\treturn returnVal2;\n")]
		public bool Valid(Hash128 hash, T obj)
		{
			Hash128 key = default(Hash128);
			bool flag = _cache.TryGetValue(key, out var value);
			if (flag)
			{
				flag = value.storedObject == obj;
			}
			return flag;
		}

		[Token(Token = "0x6000062")]
		[Address(RVA = "0x5E94800", Offset = "0x5E94800", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv33 = Coffee.UIParticleInternal.ObjectRepository`1<T>::GetFromCache(this, hash, obj);\n\tv35 = v33 == 0;\n\tif (v35) goto L_0027;\n\treturn;\nL_0027:\n\tv80 = System.Func`1<T>::Invoke(onCreate);\n\tCoffee.UIParticleInternal.ObjectRepository`1<T>::Add(this, hash, obj, v80);\n\treturn;\n")]
		public void Get(Hash128 hash, ref T obj, Func<T> onCreate)
		{
			if (!GetFromCache(hash, ref obj))
			{
				T newObject = onCreate();
				Add(hash, ref obj, newObject);
			}
		}

		[Token(Token = "0x6000063")]
		[Address(RVA = "0x40CBCB4", Offset = "0x40CBCB4", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv39 = *([v25 @ X7+38]) == 0;\n\tv40 = ~v39;\n\tif (v40) goto L_001B;\n\tv42 = 0x220C2B8(v25, hash, hash.u64_1, obj, onCreate, source, methodInfo, v25, v43, v44, v45, v46, v47, v48, v49, v50);\nL_001B:\n\tv52 = *([v25 @ X7+20]);\n\tv53 = *([v52 @ X8_v2+C0]);\n\tv59 = Coffee.UIParticleInternal.ObjectRepository`1::GetFromCache /* +1 sharing this address */(this, hash, obj, *([v53 @ X8_v3+F0]));\n\tv60 = v59 & 1;\n\tv61 = v60 == 0;\n\tif (v61) goto L_0039;\n\treturn;\nL_0039:\n\tv114 = System.Func`2<TS, T>::Invoke(onCreate, source);\n\tv115 = *([v25 @ X7+20]);\n\tv88 = *([v115 @ X8_v5+C0]);\n\tCoffee.UIParticleInternal.ObjectRepository`1::Add /* +1 sharing this address */(this, hash, obj, v114, *([v88 @ X8_v6+108]));\n\treturn;\n")]
		public void Get<TS>(Hash128 hash, ref T obj, Func<TS, T> onCreate, TS source)
		{
			//IL_0054: Expected O, but got I
			//IL_0064: Expected O, but got I
			//IL_00c1: Expected O, but got I
			//IL_00d1: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X7+38]");
			if ((nint)0 == 0)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C2B8");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X7+20]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X8_v2+C0]");
			object obj3 = 0;
			Il2CppRuntime.Boundary("MANAGED", "Method not found @5E948A0 (Coffee.UIParticleInternal.ObjectRepository`1::GetFromCache, and 1 more at this address)");
			object obj4 = default(object);
			if ((int)((nint)obj4 & 1) == 0)
			{
				object obj5 = onCreate(source);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X7+20]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ X8_v5+C0]");
				object obj7 = 0;
				Il2CppRuntime.Boundary("MANAGED", "Method not found @5E94A44 (Coffee.UIParticleInternal.ObjectRepository`1::Add, and 1 more at this address)");
			}
		}

		[Token(Token = "0x6000064")]
		[Address(RVA = "0x5E948A0", Offset = "0x5E948A0", Length = "0x1A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\nL_0025:\n\treturnVal2 = System.Collections.Generic.Dictionary`2<UnityEngine.Hash128, Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>>::TryGetValue(this._cache, v47, &v63 @ stack_-48_v3 (Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>));\n\tv98 = ~returnVal2;\n\tif (v98) goto L_0062;\n\tgoto L_0034;\nL_0034:\n\tv156 = UnityEngine.Object::op_Implicit(v63.storedObject);\n\tv160 = v156 == 0;\n\tif (v160) goto L_0055;\n\tgoto L_0042;\nL_0042:\n\tv177 = UnityEngine.Object::op_Inequality(v63.storedObject, *([obj @ X3 (T&)]));\n\tv182 = ~v177;\n\tv183 = ~v182;\n\tif (v183) goto L_0072;\n\tgoto L_0087;\nL_0055:\n\tv102 = v63 + 0x28;\n\tCoffee.UIParticleInternal.ObjectRepository`1<T>::Release(this, v102);\n\treturnVal2 = 0;\nL_0072:\n\tCoffee.UIParticleInternal.ObjectRepository`1<T>::Release(this, obj);\n\tv195 = v63.reference + 1;\n\tv63.reference = v195;\n\t*([obj @ X3 (T&)]) = v63.storedObject;\nL_0087:\n\treturn 1;\nL_0062:\n\treturn returnVal2;\n")]
		private unsafe bool GetFromCache(Hash128 hash, ref T obj)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ObjectRepository::GetFromCache");
			return default;
		}

		[Token(Token = "0x6000065")]
		[Address(RVA = "0x5E94A44", Offset = "0x5E94A44", Length = "0x1C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\nL_001D:\n\tgoto L_0020;\nL_0020:\n\tv64 = UnityEngine.Object::op_Implicit(newObject);\n\tv73 = v64 == 0;\n\tv74 = ~v73;\n\tif (v74) goto L_003A;\n\tgoto L_008D;\nL_003A:\n\tv85 = this._pool;\n\tv93 = v85.Count <= 0;\n\tif (v93) goto L_005A;\n\tv167 = System.Collections.Generic.Stack`1<Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>>::Pop(v85);\n\tv207 = v167 == 0;\n\tv172 = ~v207;\n\tv184 = v167;\n\tif (v172) goto L_0066;\n\tgoto L_009E;\nL_005A:\n\tgoto L_005C;\nL_005C:\n\tv168 = new Il2CppClass<Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>>();\n\tCoffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>::.ctor(v168);\n\tv184 = v168;\nL_0066:\n\tv184.storedObject = newObject;\n\tv184.hash.u64_0 = hash;\n\tv184.hash.u64_1 = hash.u64_1;\n\tv184.reference = 1;\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.Hash128, Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>>::set_Item(this._cache, hash, v184);\n\tv170 = UnityEngine.Object::GetInstanceID(newObject);\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Hash128>::set_Item(this._objectKey, v170, hash);\nL_008D:\n\tCoffee.UIParticleInternal.ObjectRepository`1<T>::Release(this, obj);\n\t*([obj @ X3 (T&)]) = newObject;\n\treturn;\nL_009E:\n\tthrow System.NullReferenceException;\n")]
		private void Add(Hash128 hash, ref T obj, T newObject)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ObjectRepository::Add");
		}

		[Token(Token = "0x6000066")]
		[Address(RVA = "0x5E94C04", Offset = "0x5E94C04", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv55 = UnityEngine.Object::GetInstanceID(*([obj @ X1 (T&)]));\n\tv153 = System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Hash128>::TryGetValue(this._objectKey, v55, &v91 @ stack_-40_v4 (UnityEngine.Hash128));\n\tv165 = ~v153;\n\tif (v165) goto L_0064;\n\tv161 = System.Collections.Generic.Dictionary`2<UnityEngine.Hash128, Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>>::TryGetValue(this._cache, v91, &v154 @ stack_-48_v5 (Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>));\n\tv184 = ~v161;\n\tif (v184) goto L_0064;\n\tv192 = v154.reference - 1;\n\tv154.reference = v192;\n\tv168 = v192 < 1;\n\tv178 = v154;\n\tif (v168) goto L_0063;\n\tgoto L_0059;\n\tv178 = v154;\nL_0064:\n\t*([obj @ X1 (T&)]) = 0;\nL_001D:\n\tv49 = *([obj @ X1 (T&)]) == 0;\n\tif (v49) goto L_006C;\nL_0063:\n\tCoffee.UIParticleInternal.ObjectRepository`1<T>::Remove(this, v178);\nL_0059:\n\tv182 = UnityEngine.Object::op_Implicit(v154.storedObject);\n\tv210 = v182 == 0;\n\tv185 = ~v210;\n\tif (v185) goto L_0064;\nL_006C:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Release(ref T obj)
		{
			if ((object)obj == null)
			{
				return;
			}
			int instanceID = obj.GetInstanceID();
			if (_objectKey.TryGetValue(instanceID, out var value) && _cache.TryGetValue(value, out var value2))
			{
				bool flag = --value2.reference < 1;
				Entry entry = value2;
				if (!flag)
				{
					if ((bool)value2.storedObject)
					{
						goto IL_00d4;
					}
					entry = value2;
				}
				Remove(entry);
			}
			goto IL_00d4;
			IL_00d4:
			obj = null;
		}

		[Token(Token = "0x6000067")]
		[Address(RVA = "0x5E94D3C", Offset = "0x5E94D3C", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv58 = System.Collections.Generic.Dictionary`2<UnityEngine.Hash128, Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>>::Remove(this._cache, entry.hash);\n\tv67 = UnityEngine.Object::GetInstanceID(entry.storedObject);\n\tv102 = System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Hash128>::Remove(this._objectKey, v67);\n\tSystem.Collections.Generic.Stack`1<Coffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>>::Push(this._pool, entry);\n\tentry.reference = 0;\n\tCoffee.UIParticleInternal.ObjectRepository`1<T>+Entry<T>::Release(entry, this._onRelease);\n\treturn;\nL_004D:\n\treturn;\nL_0016:\n\tv44 = entry == 0;\n\tif (v44) goto L_004D;\n")]
		private void Remove(Entry entry)
		{
			if (entry != null)
			{
				bool flag = _cache.Remove(entry.hash);
				int instanceID = entry.storedObject.GetInstanceID();
				bool flag2 = _objectKey.Remove(instanceID);
				_pool.Push(entry);
				entry.reference = 0;
				entry.Release(_onRelease);
			}
		}
	}
}
