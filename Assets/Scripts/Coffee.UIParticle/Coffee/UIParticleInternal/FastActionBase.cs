using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Coffee.UIParticleInternal
{
	[Token(Token = "0x200000B")]
	internal class FastActionBase<T>
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200000C")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400000C")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x6000029")]
			[Address(RVA = "0x4F94B88", Offset = "0x4F94B88", Length = "0x15C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1+<>c>;\n\tv15 = *([v12 @ X0_v1 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1+<>c>)+135]) & 1;\n\tv16 = v15 == 0;\n\tif (v16) goto L_0046;\n\tv18 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>+<>c<T>>;\n\tv21 = *([v18 @ X0_v37 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>+<>c<T>>)+135]) & 1;\n\tv22 = v21 == 0;\nL_FFFFFFFF:\n\tv43 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>+<>c<T>>;\nL_FFFFFFFF:\n\tv48 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>+<>c<T>>;\n\tif (v22) goto L_004F;\nL_0014:\n\tv45 = new v43();\nL_FFFFFFFF:\n\tv71 = v45;\n\tgoto L_0020;\nL_0020:\n\tSystem.Object::.ctor(v71);\n\tv79 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1+<>c>;\n\tv82 = *([v79 @ X0_v10 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1+<>c>)+135]) & 1;\n\tv83 = v82 == 0;\n\tif (v83) goto L_0059;\n\tv85 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>+<>c<T>>;\n\tv88 = *([v85 @ X0_v30 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>+<>c<T>>)+135]) & 1;\n\tv89 = v88 == 0;\nL_FFFFFFFF:\n\tv105 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>+<>c<T>>;\n\tif (v89) goto L_0062;\nL_002F:\n\tv97.<>9 = v71;\n\tv98 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1+<>c>;\n\tv101 = *([v98 @ X0_v29 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1+<>c>)+135]) & 1;\n\tv102 = v101 == 0;\nL_FFFFFFFF:\n\tv125 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1+<>c>;\n\tif (v102) goto L_006C;\nL_0037:\n\tv118 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>+<>c<T>>;\n\tv121 = *([v118 @ X0_v27 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>+<>c<T>>)+135]) & 1;\n\tv122 = v121 == 0;\nL_FFFFFFFF:\n\tv146 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>+<>c<T>>;\n\tif (v122) goto L_0075;\nL_0045:\n\treturn;\nL_0046:\n\tv23 = 0x220C238(Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1+<>c>, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv50 = *([v23 @ X0_v6+C0]);\n\tv43 = *([v50 @ X8_v6]);\n\tv52 = *([v43 @ X0_v34 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>+<>c<T>>)+135]) & 1;\n\tv53 = v52 == 0;\n\tv40 = ~v53;\nL_FFFFFFFF:\n\tv48 = v43;\n\tif (v40) goto L_0014;\nL_004F:\n\tv49 = 0x220C238(v48, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv61 = new v49();\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv71 = v61;\n\tgoto L_0020;\nL_0059:\n\tv90 = 0x220C238(Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1+<>c>, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv107 = *([v90 @ X0_v21+C0]);\n\tv105 = *([v107 @ X8_v21+10]);\n\tv109 = *([v105 @ X0_v18 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>+<>c<T>>)+135]) & 1;\n\tv110 = v109 == 0;\n\tv92 = ~v110;\n\tif (v92) goto L_002F;\nL_0062:\n\tv106 = 0x220C238(v105, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv127 = *([v106 @ X0_v19+B8]);\n\t*([v127 @ X8_v18]) = v71;\n\tv116 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1+<>c>;\n\tv129 = *([v116 @ X0_v20 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1+<>c>)+135]) & 1;\n\tv130 = v129 == 0;\n\tv112 = ~v130;\nL_FFFFFFFF:\n\tv125 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1+<>c>;\n\tif (v112) goto L_0037;\nL_006C:\n\tv126 = 0x220C238(v125, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv148 = *([v126 @ X0_v16+C0]);\n\tv146 = *([v148 @ X8_v14+10]);\n\tv150 = *([v146 @ X0_v11 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>+<>c<T>>)+135]) & 1;\n\tv151 = v150 == 0;\n\tv132 = ~v151;\n\tif (v132) goto L_0045;\nL_0075:\n\tv147 = 0x220C238(v146, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\n")]
			static _003C_003Ec()
			{
				//IL_01af: Expected O, but got I
				//IL_01b7: Expected I, but got O
				//IL_0247: Expected O, but got I
				//IL_0325: Expected O, but got I
				//IL_02b4: Expected O, but got I
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X0_v1 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1+<>c>)+135]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ X0_v37 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>+<>c<T>>)+135]");
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
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ X0_v34 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>+<>c<T>>)+135]");
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
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ X0_v29 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1+<>c>)+135]");
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
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ X0_v11 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>+<>c<T>>)+135]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					return;
				}
				goto IL_0373;
				IL_0150:
				nint num11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X0_v27 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>+<>c<T>>)+135]");
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
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ X0_v10 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1+<>c>)+135]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					nint num14 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ X0_v30 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>+<>c<T>>)+135]");
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
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ X0_v18 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>+<>c<T>>)+135]");
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
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ X0_v20 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1+<>c>)+135]");
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

			[Token(Token = "0x600002A")]
			[Address(RVA = "0x4F94CE4", Offset = "0x4F94CE4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal LinkedListNode<T> _003C_002Ecctor_003Eb__7_0()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("FastActionBase._003C_003Ec::_003C_002Ecctor_003Eb__7_0");
				return default;
			}

			internal bool _003C_002Ecctor_003Eb__7_1(LinkedListNode<T> _)
			{
				return true;
			}

			internal void _003C_002Ecctor_003Eb__7_2(LinkedListNode<T> x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("FastActionBase._003C_003Ec::_003C_002Ecctor_003Eb__7_2");
			}
		}

		[Token(Token = "0x400000A")]
		private static readonly InternalObjectPool<LinkedListNode<T>> s_NodePool;

		[Token(Token = "0x400000B")]
		[FieldOffset(Offset = "0x0")]
		private readonly LinkedList<T> _delegates;

		[Token(Token = "0x6000023")]
		[Address(RVA = "0x52A1AA8", Offset = "0x52A1AA8", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = rhs == 0;\n\tif (v14) goto L_002D;\n\tv23 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>>;\n\tv26 = *([v23 @ X0_v1 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>>)+135]) & 1;\n\tv27 = v26 == 0;\n\tif (v27) goto L_002E;\n\tgoto L_001A;\nL_001A:\n\tv85 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>>;\n\tv88 = *([v85 @ X0_v19 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>>)+135]) & 1;\n\tv89 = v88 == 0;\n\tv105 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>>;\n\tif (v89) goto L_003D;\nL_0021:\n\tv114 = v101.s_NodePool;\n\tv103 = v101.s_NodePool == 0;\n\tv104 = ~v103;\n\tif (v104) goto L_0045;\n\tgoto L_005D;\nL_002D:\n\treturn;\nL_002E:\n\tv36 = 0x220C238(Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>>, rhs, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv94 = *([v36 @ X0_v15+E4]) == 0;\n\tv82 = ~v94;\n\tif (v82) goto L_001A;\n\tv96 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>>;\n\tv112 = *([v96 @ X0_v14 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>>)+135]) & 1;\n\tv113 = v112 == 0;\n\tv100 = ~v113;\n\tv105 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>>;\n\tif (v100) goto L_0021;\nL_003D:\n\tv108 = 0x220C238(v105, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv117 = *([v108 @ X0_v10+B8]);\n\tv114 = *([v117 @ X8_v12]);\nL_0045:\n\tv123 = Coffee.UIParticleInternal.InternalObjectPool`1<System.Collections.Generic.LinkedListNode`1<T>>::Rent(v114);\n\tv123.item = rhs;\n\tSystem.Collections.Generic.LinkedList`1<T>::AddLast(this._delegates, v123);\n\treturn;\nL_005D:\n\tthrow System.NullReferenceException;\n")]
		public void Add(T rhs)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FastActionBase::Add");
		}

		[Token(Token = "0x6000024")]
		[Address(RVA = "0x52A1BA8", Offset = "0x52A1BA8", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = rhs == 0;\n\tif (v10) goto L_003D;\n\tv33 = System.Collections.Generic.LinkedList`1<T>::Find(this._delegates, rhs);\n\tv19 = v33;\n\tv37 = v33 == 0;\n\tif (v37) goto L_003D;\n\tSystem.Collections.Generic.LinkedList`1<T>::Remove(this._delegates, v33);\n\tv88 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>>;\n\tv91 = *([v88 @ X0_v7 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>>)+135]) & 1;\n\tv92 = v91 == 0;\n\tif (v92) goto L_003E;\n\tgoto L_0029;\nL_0029:\n\tv103 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>>;\n\tv106 = *([v103 @ X0_v19 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>>)+135]) & 1;\n\tv107 = v106 == 0;\n\tv120 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>>;\n\tif (v107) goto L_004D;\nL_0030:\n\tv32 = v50.s_NodePool;\nL_0037:\n\tCoffee.UIParticleInternal.InternalObjectPool`1<System.Collections.Generic.LinkedListNode`1<T>>::Return(v32, &v19 @ stack_-28_v3 (System.Collections.Generic.LinkedListNode`1<System.Object>));\nL_003D:\n\treturn;\nL_003E:\n\tv95 = 0x220C238(Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>>, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv112 = *([v95 @ X0_v14+E4]) == 0;\n\tv100 = ~v112;\n\tif (v100) goto L_0029;\n\tv116 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>>;\n\tv126 = *([v116 @ X0_v13 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>>)+135]) & 1;\n\tv127 = v126 == 0;\n\tv118 = ~v127;\n\tv120 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>>;\n\tif (v118) goto L_0030;\nL_004D:\n\tv122 = 0x220C238(v120, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv49 = *([v122 @ X0_v9+B8]);\n\tv32 = *([v49 @ X8_v12]);\n\tv130 = *([v49 @ X8_v12]) == 0;\n\tv57 = ~v130;\n\tif (v57) goto L_0037;\n\tthrow System.NullReferenceException;\n")]
		public unsafe void Remove(T rhs)
		{
			//IL_01a6: Expected O, but got I
			if (rhs == null)
			{
				return;
			}
			LinkedListNode<object> linkedListNode = (LinkedListNode<object>)(object)_delegates.Find(rhs);
			LinkedListNode<object> instance = linkedListNode;
			if (linkedListNode == null)
			{
				return;
			}
			_delegates.Remove((LinkedListNode<T>)(object)linkedListNode);
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ X0_v7 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>>)+135]");
			nint num4;
			if ((int)((nint)0 & (nint)1) == 0)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ X0_v14+E4]");
				if ((nint)0 == 0)
				{
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ X0_v13 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>>)+135]");
					int num3 = (int)((nint)0 & (nint)1);
					bool flag = num3 == 0;
					bool flag2 = !flag;
					num4 = 0;
					if (flag2)
					{
						goto IL_00dd;
					}
					goto IL_0187;
				}
			}
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X0_v19 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>>)+135]");
			int num6 = (int)((nint)0 & (nint)1);
			bool flag3 = num6 == 0;
			num4 = 0;
			if (!flag3)
			{
				goto IL_00dd;
			}
			goto IL_0187;
			IL_00dd:
			InternalObjectPool<LinkedListNode<T>> internalObjectPool = s_NodePool;
			goto IL_00eb;
			IL_0187:
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ X0_v9+B8]");
			object obj = 0;
			internalObjectPool = (InternalObjectPool<LinkedListNode<T>>)obj;
			if (obj == null)
			{
				throw new NullReferenceException();
			}
			goto IL_00eb;
			IL_00eb:
			internalObjectPool.Return(ref *(LinkedListNode<T>*)(&instance));
		}

		[Token(Token = "0x6000025")]
		[Address(RVA = "0x52A1CA4", Offset = "0x52A1CA4", Length = "0x1CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = this._delegates;\n\tv20 = this._delegates == 0;\n\tif (v20) goto L_0085;\n\tv105 = v18.First;\n\tv22 = v18.First == 0;\n\tif (v22) goto L_0084;\n\tv41 = callback == 0;\n\tif (v41) goto L_0050;\n\tgoto L_0084;\nL_0084:\n\treturn;\nL_0085:\n\tv23 = new System.NullReferenceException();\n\tv69 = 0x8BF0368(v23, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0092:\n\t// 146 Interrupt\n\tgoto L_0096;\nL_0096:\n\tv126 = 0x8BF5BF4(v125, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv128 = 0x8BF0368(v125, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv84 = 0xA1B8(v128, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_001C:\n\tSystem.Action`1<T>::Invoke(callback, v105.item);\n\tv114 = 0x8BF5BAC(8, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v114 @ X0_v9]) = *([v3 @ X23]);\n\tv120 = 0xA67A000 + 0x440;\n\tv125 = 0x8BF5C48(v114, v120, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv47 = System.Collections.Generic.LinkedListNode`1<T>::get_Next(v105);\n\tv123 = v47 == 0;\n\tv57 = ~v123;\n\tv105 = v47;\n\tif (v57) goto L_001C;\nL_0050:\n\tv125 = new System.NullReferenceException();\n\tgoto L_0092;\n")]
		protected internal void Invoke(Action<T> callback)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FastActionBase::Invoke");
		}

		[Token(Token = "0x6000026")]
		[Address(RVA = "0x52A1E70", Offset = "0x52A1E70", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Collections.Generic.LinkedList`1<T>::Clear(this._delegates);\n\treturn;\n")]
		public void Clear()
		{
			_delegates.Clear();
		}

		[Token(Token = "0x6000027")]
		[Address(RVA = "0x52A1E94", Offset = "0x52A1E94", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tv42 = new Il2CppClass<System.Collections.Generic.LinkedList`1<T>>();\n\tSystem.Collections.Generic.LinkedList`1<T>::.ctor(v42);\n\tthis._delegates = v42;\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public FastActionBase()
		{
			LinkedList<T> delegates = new LinkedList<T>();
			_delegates = delegates;
		}

		[Token(Token = "0x6000028")]
		[Address(RVA = "0x52A1F08", Offset = "0x52A1F08", Length = "0x524")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1>;\n\tv23 = *([v20 @ X0_v1 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1>)+135]) & 1;\n\tv24 = v23 == 0;\n\tif (v24) goto L_004B;\n\tv26 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>+<>c<T>>;\n\tv29 = *([v26 @ X0_v134 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>+<>c<T>>)+135]) & 1;\n\tv30 = v29 == 0;\nL_FFFFFFFF:\n\tv57 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>+<>c<T>>;\n\tif (v30) goto L_0054;\nL_001A:\n\tgoto L_001B;\nL_001B:\n\tv68 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1>;\n\tv71 = *([v68 @ X0_v132 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1>)+135]) & 1;\n\tv72 = v71 == 0;\nL_FFFFFFFF:\n\tv92 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1>;\n\tif (v72) goto L_0061;\nL_0022:\n\tv85 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>+<>c<T>>;\n\tv88 = *([v85 @ X0_v130 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>+<>c<T>>)+135]) & 1;\n\tv89 = v88 == 0;\nL_FFFFFFFF:\n\tv112 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>+<>c<T>>;\n\tif (v89) goto L_006A;\nL_0029:\n\tv201 = v103.<>9;\n\tv105 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1>;\n\tv108 = *([v105 @ X0_v128 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1>)+135]) & 1;\n\tv109 = v108 == 0;\nL_FFFFFFFF:\n\tv209 = v103.<>9;\nL_FFFFFFFF:\n\tv135 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1>;\n\tif (v109) goto L_0074;\nL_0031:\n\tv127 = Il2CppClass<System.Func`1<System.Collections.Generic.LinkedListNode`1<T>>>;\n\tv130 = *([v127 @ X0_v126 (Il2CppClass<System.Func`1<System.Collections.Generic.LinkedListNode`1<T>>>)+135]) & 1;\n\tv131 = v130 == 0;\nL_FFFFFFFF:\n\tv146 = Il2CppClass<System.Func`1<System.Collections.Generic.LinkedListNode`1<T>>>;\nL_FFFFFFFF:\n\tv209 = v201;\nL_FFFFFFFF:\n\tv152 = Il2CppClass<System.Func`1<System.Collections.Generic.LinkedListNode`1<T>>>;\n\tif (v131) goto L_007D;\nL_0037:\n\tv148 = new v146();\n\tv159 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1>;\n\tv178 = *([v159 @ X0_v124 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1>)+135]);\n\tv162 = *([v159 @ X0_v124 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1>)+135]) & 1;\n\tv163 = v162 == 0;\n\tv164 = ~v163;\nL_FFFFFFFF:\n\tv200 = v148;\nL_FFFFFFFF:\n\tv175 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1>;\nL_FFFFFFFF:\n\tv208 = v148;\nL_FFFFFFFF:\n\tv209 = v201;\nL_FFFFFFFF:\n\tv204 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1>;\n\tif (v164) goto L_0088;\nL_0040:\n\tv177 = 0x220C238(v175, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv191 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1>;\n\tv194 = *([v177 @ X0_v120+C0]);\n\tv198 = *([v194 @ X8_v147+B0]);\n\tv196 = *([v191 @ X0_v121 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1>)+135]) & 1;\n\tv197 = v196 == 0;\nL_FFFFFFFF:\n\tv204 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1>;\n\tif (v197) goto L_008C;\nL_FFFFFFFF:\n\tv206 = *([v194 @ X8_v147+B0]);\nL_FFFFFFFF:\n\tv208 = v200;\nL_FFFFFFFF:\n\tv209 = v201;\n\tgoto L_0092;\nL_004B:\n\tv31 = 0x220C238(Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1>, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv59 = *([v31 @ X0_v117+C0]);\n\tv57 = *([v59 @ X8_v142+A8]);\n\tv61 = *([v57 @ X0_v115 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>+<>c<T>>)+135]) & 1;\n\tv62 = v61 == 0;\n\tv48 = ~v62;\n\tif (v48) goto L_001A;\nL_0054:\n\tv58 = 0x220C238(v57, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv77 = *([v58 @ X0_v116+E4]) == 0;\n\tv64 = ~v77;\n\tif (v64) goto L_001B;\n\tv83 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1>;\n\tv95 = *([v83 @ X0_v114 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1>)+135]) & 1;\n\tv96 = v95 == 0;\n\tv79 = ~v96;\nL_FFFFFFFF:\n\tv92 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1>;\n\tif (v79) goto L_0022;\nL_0061:\n\tv93 = 0x220C238(v92, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv114 = *([v93 @ X0_v110+C0]);\n\tv112 = *([v114 @ X8_v134+A8]);\n\tv116 = *([v112 @ X0_v106 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>+<>c<T>>)+135]) & 1;\n\tv117 = v116 == 0;\n\tv98 = ~v117;\n\tif (v98) goto L_0029;\nL_006A:\n\tv113 = 0x220C238(v112, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv137 = *([v113 @ X0_v107+B8]);\n\tv201 = *([v137 @ X8_v130]);\n\tv125 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1>;\n\tv139 = *([v125 @ X0_v108 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1>)+135]) & 1;\n\tv140 = v139 == 0;\n\tv121 = ~v140;\nL_FFFFFFFF:\n\tv209 = *([v137 @ X8_v130]);\nL_FFFFFFFF:\n\tv135 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1>;\n\tif (v121) goto L_0031;\nL_0074:\n\tv136 = 0x220C238(v135, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv154 = *([v136 @ X0_v104+C0]);\n\tv146 = *([v154 @ X8_v126+B8]);\n\tv156 = *([v146 @ X0_v122 (Il2CppClass<System.Func`1<System.Collections.Generic.LinkedListNode`1<T>>>)+135]) & 1;\n\tv157 = v156 == 0;\n\tv143 = ~v157;\nL_FFFFFFFF:\n\tv201 = v209;\nL_FFFFFFFF:\n\tv152 = v146;\n\tif (v143) goto L_0037;\nL_007D:\n\tv153 = 0x220C238(v152, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv165 = new v153();\n\tv176 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1>;\n\tv178 = *([v176 @ X0_v102 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1>)+135]);\n\tv189 = *([v176 @ X0_v102 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1>)+135]) & 1;\n\tv172 = v189 == 0;\nL_FFFFFFFF:\n\tv200 = v165;\nL_FFFFFFFF:\n\tv201 = v209;\nL_FFFFFFFF:\n\tv175 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1>;\nL_FFFFFFFF:\n\tv208 = v165;\nL_FFFFFFFF:\n\tv204 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1>;\n\tif (v172) goto L_0040;\nL_0088:\n\tv186 = v178 & 1;\n\tv187 = v186 == 0;\n\tv188 = ~v187;\nL_FFFFFFFF:\n\tv198 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv200 = v208;\nL_FFFFFFFF:\n\tv201 = v209;\nL_FFFFFFFF:\n\tv206 = Il2CppMethodInfo;\n\tif (v188) goto L_0092;\nL_008C:\n\tv205 = 0x220C238(v204, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\tv206 = v198;\nL_FFFFFFFF:\n\tv208 = v200;\nL_FFFFFFFF:\n\tv209 = v201;\nL_0092:\n\tSystem.Func`1<System.Collections.Generic.LinkedListNode`1<T>>::.ctor(v208, v209, v206);\n\tv218 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1>;\n\tv221 = *([v218 @ X0_v4 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1>)+135]) & 1;\n\tv222 = v221 == 0;\n\tif (v222) goto L_00C3;\n\tv224 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>+<>c<T>>;\n\tv227 = *([v224 @ X0_v95 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>+<>c<T>>)+135]) & 1;\n\tv228 = v227 == 0;\nL_FFFFFFFF:\n\tv245 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1<T>+<>c<T>>;\n\tif (v228) goto L_00CC;\nL_00A1:\n\tv332 = v236.<>9;\n\tv238 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1>;\n\tv241 = *([v238 @ X0_v94 (Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1>)+135]) & 1;\n\tv242 = v241 == 0;\nL_FFFFFFFF:\n\tv340 = v236.<>9;\nL_FFFFFFFF:\n\tv268 = Il2CppClass<Coffee.UIParticleInternal.FastActionBase`1>;\n\tif (v242) goto L_00D6;\nL_00A9:\n\tv260 = Il2CppClass<System.Predicate`1<System.Colle\n// ... truncated")]
		unsafe static FastActionBase()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FastActionBase::.cctor");
		}
	}
}
