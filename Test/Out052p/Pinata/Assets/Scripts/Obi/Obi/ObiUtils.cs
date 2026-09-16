using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Token(Token = "0x200005C")]
	public static class ObiUtils
	{
		[CompilerGenerated]
		[Token(Token = "0x20000C0")]
		private sealed class _003CBilateralInterleaved_003Ed__22 : IEnumerable<object>, IEnumerable, IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000313")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x4000314")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000315")]
			[FieldOffset(Offset = "0x20")]
			internal int _003C_003El__initialThreadId;

			[Token(Token = "0x4000316")]
			[FieldOffset(Offset = "0x24")]
			private int count;

			[Token(Token = "0x4000317")]
			[FieldOffset(Offset = "0x28")]
			public int _003C_003E3__count;

			[Token(Token = "0x4000318")]
			[FieldOffset(Offset = "0x2C")]
			private int _003Ci_003E5__2;

			[Token(Token = "0x170000DE")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600057B")]
				[Address(RVA = "0x10335DC", Offset = "0x10335DC", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x170000DF")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600057D")]
				[Address(RVA = "0x1033648", Offset = "0x1033648", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000578")]
			[Address(RVA = "0x1032BF8", Offset = "0x1032BF8", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\tv16 = System.Environment::get_CurrentManagedThreadId();\n\tthis.<>l__initialThreadId = v16;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003CBilateralInterleaved_003Ed__22(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000579")]
			[Address(RVA = "0x10334DC", Offset = "0x10334DC", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x600057A")]
			[Address(RVA = "0x10334E0", Offset = "0x10334E0", Length = "0xFC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EDC6F8]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202628C]) = v38;\nL_0013:\n\tv39 = this.<>1__state;\n\tv40 = this.<>1__state - 1;\n\tv41 = v40 < 2;\n\tv42 = ~v41;\n\tif (v42) goto L_0025;\n\tv39 = this.<i>5__2;\n\tthis.<>1__state = 0xFFFFFFFF;\n\tv39 = v39 + 1;\n\tthis.<i>5__2 = v39;\n\tgoto L_0035;\nL_0025:\n\tv53 = this.<>1__state == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_FFFFFFFF;\n\tthis.<>1__state = 0xFFFFFFFF;\n\tthis.<i>5__2 = 0;\nL_0035:\n\tv69 = this.count - v39;\n\tv72 = this.count <= v39;\n\tif (v72) goto L_FFFFFFFF;\n\tv89 = v39 & 1;\n\tv90 = v89 == 0;\n\tv91 = ~v90;\n\tif (v91) goto L_0050;\n\t// 67 Box v141 @ X0_v7 (System.Object), typeof(System.Int32), &v39 @ X8_v3 (System.Int32)\n\tthis.<>2__current = v141;\n\tthis.<>1__state = 2;\n\tgoto L_006D;\n\tgoto L_006D;\nL_0050:\n\tv115 = this.count < 0;\n\tv109 = this.count ^ this.count;\n\tv107 = this.count & v109;\n\tv105 = v107 < 0;\n\tv145 = v115 == v105;\n\tv103 = ~v145;\n\tv100 = ~v103;\n\tif (v100) goto L_FFFFFFFF;\n\tv148 = this.count + 1;\n\tgoto L_005E;\nL_005E:\n\tv97 = v148 & 0xFFFFFFFE;\n\tv39 = this.count - v97;\n\tv39 = v69 - v39;\n\t// 100 Box v151 @ X0_v4 (System.Object), typeof(System.Int32), &v39 @ X8_v3 (System.Int32)\n\tthis.<>2__current = v151;\n\tthis.<>1__state = 1;\nL_006D:\n\treturn returnVal1;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				//IL_020f: Expected I4, but got I8
				int num = _003C_003E1__state;
				int num2 = _003C_003E1__state - 1;
				if (num2 < 2)
				{
					num = _003Ci_003E5__2;
					_003C_003E1__state = -1;
					num = (_003Ci_003E5__2 = num + 1);
				}
				else
				{
					if (_003C_003E1__state != 0)
					{
						goto IL_00e2;
					}
					_003C_003E1__state = -1;
					_003Ci_003E5__2 = 0;
				}
				int num3 = count - num;
				if (count > num)
				{
					if ((num & 1) == 0)
					{
						object obj = num;
						_003C_003E2__current = obj;
						_003C_003E1__state = 2;
						return true;
					}
					bool flag = count < 0;
					int num4 = count ^ count;
					int num5 = count & num4;
					bool flag2 = num5 < 0;
					int num6 = ((flag == flag2) ? count : (count + 1));
					int num7 = (int)(num6 & 0xFFFFFFFEL);
					num = count - num7;
					num = num3 - num;
					object obj2 = num;
					_003C_003E2__current = obj2;
					_003C_003E1__state = 1;
					return true;
				}
				goto IL_00e2;
				IL_00e2:
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600057C")]
			[Address(RVA = "0x10335E4", Offset = "0x10335E4", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1F0E988]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([202628D]) = v34;\nL_0014:\n\tv38 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw new TypeLoadException();
			}

			[DebuggerHidden]
			[Token(Token = "0x600057E")]
			[Address(RVA = "0x1033650", Offset = "0x1033650", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EBF538]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202628E]) = v38;\nL_0014:\n\tv40 = this.<>1__state + 2;\n\tv42 = v40 == 0;\n\tv45 = ~v42;\n\tif (v45) goto L_002F;\n\tv48 = System.Environment::get_CurrentManagedThreadId();\n\tv50 = this.<>l__initialThreadId != v48;\n\tif (v50) goto L_002F;\n\tthis.<>1__state = 0;\n\tgoto L_003B;\nL_002F:\n\tv76 = new Obi.ObiUtils+<BilateralInterleaved>d__22();\n\tSystem.Object::.ctor(v76);\n\tv76.<>1__state = 0;\n\tv82 = System.Environment::get_CurrentManagedThreadId();\n\tv76.<>l__initialThreadId = v82;\nL_003B:\n\tv97.count = this.<>3__count;\n\treturn v97;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
				_003CBilateralInterleaved_003Ed__22 _003CBilateralInterleaved_003Ed__23;
				if (_003C_003E1__state + 2 == 0)
				{
					int currentManagedThreadId = Environment.CurrentManagedThreadId;
					if (_003C_003El__initialThreadId == currentManagedThreadId)
					{
						_003C_003E1__state = 0;
						_003CBilateralInterleaved_003Ed__23 = this;
						goto IL_007f;
					}
				}
				_003CBilateralInterleaved_003Ed__22 _003CBilateralInterleaved_003Ed__24 = null;
				_003CBilateralInterleaved_003Ed__24._003C_003E1__state = 0;
				int currentManagedThreadId2 = Environment.CurrentManagedThreadId;
				_003CBilateralInterleaved_003Ed__24._003C_003El__initialThreadId = currentManagedThreadId2;
				_003CBilateralInterleaved_003Ed__23 = _003CBilateralInterleaved_003Ed__24;
				goto IL_007f;
				IL_007f:
				_003CBilateralInterleaved_003Ed__23.count = _003C_003E3__count;
				return _003CBilateralInterleaved_003Ed__23;
			}

			[DebuggerHidden]
			[Token(Token = "0x600057F")]
			[Address(RVA = "0x1033700", Offset = "0x1033700", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = Obi.ObiUtils+<BilateralInterleaved>d__22::System.Collections.Generic.IEnumerable<System.Object>.GetEnumerator(this);\n\treturn returnVal1;\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<object>)this).GetEnumerator();
			}
		}

		[Token(Token = "0x40001B2")]
		public static readonly Color32[] colorAlphabet;

		[Token(Token = "0x60003D3")]
		[Address(RVA = "0x102DFFC", Offset = "0x102DFFC", Length = "0x2D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = &v21 @ stack_-10_v2;\n\tv26 = bodyWidth * 0.5f;\n\tv27 = bodyLenght * -0.5f;\n\tv31 = bodyLenght * 0.5f;\n\tv32 = &v21 @ stack_-10_v2 - 0x50;\n\t*([v20 @ X29_v1-48]) = 0;\n\t*([v20 @ X29_v1-50]) = 0;\n\tv39 = 0x1586898(v32, 0, v40, v41, v42, v43, v44, v45, v26, 0, v27, headWidth, v46, v47, v48, v49);\n\tv50 = &v21 @ stack_-10_v2 - 0x60;\n\t*([v20 @ X29_v1-58]) = 0;\n\t*([v20 @ X29_v1-60]) = 0;\n\tv55 = 0x1586898(v50, 0, v40, v41, v42, v43, v44, v45, v26, 0, v31, headWidth, v46, v47, v48, v49);\n\t// 43 MakeStruct v63 @ AGG102E090_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v20 @ X29_v1-50], [v20 @ X29_v1-4C], [v20 @ X29_v1-48]\n\t// 44 MakeStruct v64 @ AGG102E090_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v20 @ X29_v1-60], [v20 @ X29_v1-5C], [v20 @ X29_v1-58]\n\tUnityEngine.Gizmos::DrawLine(v63, v64);\n\tv65 = bodyWidth * -0.5f;\n\tv66 = &v21 @ stack_-10_v2 - 0x70;\n\t*([v20 @ X29_v1-68]) = 0;\n\t*([v20 @ X29_v1-70]) = 0;\n\tv71 = 0x1586898(v66, 0, v40, v41, v42, v43, v44, v45, v65, 0, v27, *([v20 @ X29_v1-60]), *([v20 @ X29_v1-5C]), *([v20 @ X29_v1-58]), v48, v49);\n\tv72 = &v21 @ stack_-10_v2 - 0x80;\n\t*([v20 @ X29_v1-78]) = 0;\n\t*([v20 @ X29_v1-80]) = 0;\n\tv77 = 0x1586898(v72, 0, v40, v41, v42, v43, v44, v45, v65, 0, v31, *([v20 @ X29_v1-60]), *([v20 @ X29_v1-5C]), *([v20 @ X29_v1-58]), v48, v49);\n\t// 70 MakeStruct v85 @ AGG102E0EC_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v20 @ X29_v1-70], [v20 @ X29_v1-6C], [v20 @ X29_v1-68]\n\t// 71 MakeStruct v86 @ AGG102E0EC_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v20 @ X29_v1-80], [v20 @ X29_v1-7C], [v20 @ X29_v1-78]\n\tUnityEngine.Gizmos::DrawLine(v85, v86);\n\tv88 = 0;\n\tv94 = 0x1586898(&v88 @ stack_-A0_v1, 0, v40, v41, v42, v43, v44, v45, v65, 0, v27, *([v20 @ X29_v1-80]), *([v20 @ X29_v1-7C]), *([v20 @ X29_v1-78]), v48, v49);\n\tv96 = 0;\n\tv102 = 0x1586898(&v96 @ stack_-B0_v1, 0, v40, v41, v42, v43, v44, v45, v26, 0, v27, *([v20 @ X29_v1-80]), *([v20 @ X29_v1-7C]), *([v20 @ X29_v1-78]), v48, v49);\n\t// 96 MakeStruct v112 @ AGG102E144_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v105 @ stack_-9C, 0\n\t// 97 MakeStruct v113 @ AGG102E144_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v109 @ stack_-AC, 0\n\tUnityEngine.Gizmos::DrawLine(v112, v113);\n\tv115 = 0;\n\tv121 = 0x1586898(&v115 @ stack_-C0_v1, 0, v40, v41, v42, v43, v44, v45, v26, 0, v31, 0, v109, 0, v48, v49);\n\tv123 = 0;\n\tv129 = 0x1586898(&v123 @ stack_-D0_v1, 0, v40, v41, v42, v43, v44, v45, headWidth, 0, v31, 0, v109, 0, v48, v49);\n\t// 122 MakeStruct v139 @ AGG102E19C_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v132 @ stack_-BC, 0\n\t// 123 MakeStruct v140 @ AGG102E19C_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v136 @ stack_-CC, 0\n\tUnityEngine.Gizmos::DrawLine(v139, v140);\n\tv142 = 0;\n\tv148 = 0x1586898(&v142 @ stack_-E0_v1, 0, v40, v41, v42, v43, v44, v45, v65, 0, v31, 0, v136, 0, v48, v49);\n\tv149 = -headWidth;\n\tv151 = 0;\n\tv157 = 0x1586898(&v151 @ stack_-F0_v1, 0, v40, v41, v42, v43, v44, v45, v149, 0, v31, 0, v136, 0, v48, v49);\n\t// 149 MakeStruct v167 @ AGG102E1F8_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v160 @ stack_-DC, 0\n\t// 150 MakeStruct v168 @ AGG102E1F8_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v164 @ stack_-EC, 0\n\tUnityEngine.Gizmos::DrawLine(v167, v168);\n\tv169 = v31 + headLenght;\n\tv171 = 0;\n\tv177 = 0x1586898(&v171 @ stack_-100_v1, 0, v40, v41, v42, v43, v44, v45, 0, 0, v169, 0, v164, 0, v48, v49);\n\tv179 = 0;\n\tv185 = 0x1586898(&v179 @ stack_-110_v1, 0, v40, v41, v42, v43, v44, v45, headWidth, 0, v31, 0, v164, 0, v48, v49);\n\t// 176 MakeStruct v195 @ AGG102E254_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v188 @ stack_-FC, 0\n\t// 177 MakeStruct v196 @ AGG102E254_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v192 @ stack_-10C, 0\n\tUnityEngine.Gizmos::DrawLine(v195, v196);\n\tv198 = 0;\n\tv204 = 0x1586898(&v198 @ stack_-120_v1, 0, v40, v41, v42, v43, v44, v45, 0, 0, v169, 0, v192, 0, v48, v49);\n\tv206 = 0;\n\tv212 = 0x1586898(&v206 @ stack_-130_v1, 0, v40, v41, v42, v43, v44, v45, v149, 0, v31, 0, v192, 0, v48, v49);\n\t// 202 MakeStruct v222 @ AGG102E2AC_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v215 @ stack_-11C, 0\n\t// 203 MakeStruct v223 @ AGG102E2AC_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v219 @ stack_-12C, 0\n\tUnityEngine.Gizmos::DrawLine(v222, v223);\n\treturn;\n// 152 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void DrawArrowGizmo(float bodyLenght, float bodyWidth, float headLenght, float headWidth)
		{
			//IL_0047: Expected O, but got I
			//IL_006c: Expected O, but got I
			//IL_009c: Expected F4, but got I
			//IL_00b1: Expected F4, but got I
			//IL_00c6: Expected F4, but got I
			//IL_00db: Expected F4, but got I
			//IL_00f0: Expected F4, but got I
			//IL_0105: Expected F4, but got I
			//IL_0131: Expected O, but got I
			//IL_015b: Expected O, but got I
			//IL_0186: Expected F4, but got I
			//IL_019b: Expected F4, but got I
			//IL_01b0: Expected F4, but got I
			//IL_01c5: Expected F4, but got I
			//IL_01da: Expected F4, but got I
			//IL_01ef: Expected F4, but got I
			//IL_020a: Expected O, but got I4
			//IL_021d: Expected O, but got I4
			//IL_0247: Expected F4, but got O
			//IL_0270: Expected F4, but got O
			//IL_0294: Expected O, but got I4
			//IL_02ac: Expected O, but got I4
			//IL_02d1: Expected F4, but got O
			//IL_02fa: Expected F4, but got O
			//IL_0323: Expected O, but got I4
			//IL_0336: Expected O, but got F4
			//IL_033f: Expected O, but got I4
			//IL_0369: Expected F4, but got O
			//IL_0392: Expected F4, but got O
			//IL_03c5: Expected O, but got I4
			//IL_03dd: Expected O, but got I4
			//IL_0402: Expected F4, but got O
			//IL_042b: Expected F4, but got O
			//IL_0454: Expected O, but got I4
			//IL_0467: Expected O, but got I4
			//IL_0491: Expected F4, but got O
			//IL_04ba: Expected F4, but got O
			object obj2 = default(object);
			object obj = obj2;
			float num = bodyWidth * 0.5f;
			float num2 = bodyLenght * -0.5f;
			float num3 = bodyLenght * 0.5f;
			object obj3 = (long)(IntPtr)obj2 - 80L;
			_ = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			object obj4 = (long)(IntPtr)obj2 - 96L;
			_ = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ X29_v1-50]");
			Vector3 vector = default(Vector3);
			vector.x = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ X29_v1-4C]");
			vector.y = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ X29_v1-48]");
			vector.z = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ X29_v1-60]");
			Vector3 to = default(Vector3);
			to.x = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ X29_v1-5C]");
			to.y = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ X29_v1-58]");
			to.z = 0f;
			Gizmos.DrawLine(vector, to);
			float num4 = bodyWidth * -0.5f;
			object obj5 = (long)(IntPtr)obj2 - 112L;
			_ = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			object obj6 = (long)(IntPtr)obj2 - 128L;
			_ = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ X29_v1-70]");
			Vector3 vector2 = default(Vector3);
			vector2.x = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ X29_v1-6C]");
			vector2.y = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ X29_v1-68]");
			vector2.z = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ X29_v1-80]");
			Vector3 to2 = default(Vector3);
			to2.x = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ X29_v1-7C]");
			to2.y = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ X29_v1-78]");
			to2.z = 0f;
			Gizmos.DrawLine(vector2, to2);
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			Vector3 vector3 = default(Vector3);
			vector3.x = 0f;
			object obj9 = default(object);
			vector3.y = (float)obj9;
			vector3.z = 0f;
			Vector3 to3 = default(Vector3);
			to3.x = 0f;
			object obj10 = default(object);
			to3.y = (float)obj10;
			to3.z = 0f;
			Gizmos.DrawLine(vector3, to3);
			object obj11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			object obj12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			Vector3 vector4 = default(Vector3);
			vector4.x = 0f;
			object obj13 = default(object);
			vector4.y = (float)obj13;
			vector4.z = 0f;
			Vector3 to4 = default(Vector3);
			to4.x = 0f;
			object obj14 = default(object);
			to4.y = (float)obj14;
			to4.z = 0f;
			Gizmos.DrawLine(vector4, to4);
			object obj15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			object obj16 = 0f - headWidth;
			object obj17 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			Vector3 vector5 = default(Vector3);
			vector5.x = 0f;
			object obj18 = default(object);
			vector5.y = (float)obj18;
			vector5.z = 0f;
			Vector3 to5 = default(Vector3);
			to5.x = 0f;
			object obj19 = default(object);
			to5.y = (float)obj19;
			to5.z = 0f;
			Gizmos.DrawLine(vector5, to5);
			float num5 = num3 + headLenght;
			object obj20 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			object obj21 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			Vector3 vector6 = default(Vector3);
			vector6.x = 0f;
			object obj22 = default(object);
			vector6.y = (float)obj22;
			vector6.z = 0f;
			Vector3 to6 = default(Vector3);
			to6.x = 0f;
			object obj23 = default(object);
			to6.y = (float)obj23;
			to6.z = 0f;
			Gizmos.DrawLine(vector6, to6);
			object obj24 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			object obj25 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			Vector3 vector7 = default(Vector3);
			vector7.x = 0f;
			object obj26 = default(object);
			vector7.y = (float)obj26;
			vector7.z = 0f;
			Vector3 to7 = default(Vector3);
			to7.x = 0f;
			object obj27 = default(object);
			to7.y = (float)obj27;
			to7.z = 0f;
			Gizmos.DrawLine(vector7, to7);
		}

		[Token(Token = "0x60003D4")]
		[Address(RVA = "0x1031E7C", Offset = "0x1031E7C", Length = "0x2F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv29 = &v30 @ stack_-10_v2;\n\t*([v29 @ X29_v1-8]) = color.a;\n\t*([v29 @ X29_v1-4]) = color.g;\n\tgoto L_002C;\n\tv44 = *([1ED58A8]);\n\tv45 = *([v44 @ X8_v14]);\n\tv46 = \"il2cpp_codegen_initialize_method\"(v45, v47, v48, v49, v50, v51, v52, v53, pos, v0, v2, size, color, v3, v5, v6);\n\tv57 = 0 | 1;\n\t*([2026281]) = v57;\nL_002C:\n\tgoto L_0033;\n\tv64 = *([v60 @ X0_v2+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tgoto L_0033;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v60, v47, v48, v49, v50, v51, v52, v53, pos, v0, v2, size, color, v3, v5, v6);\nL_0033:\n\tv72 = UnityEngine.Vector3::get_right();\n\tv78 = UnityEngine.Vector3::op_Multiply(v72, size);\n\tv90 = UnityEngine.Vector3::op_Subtraction(pos, v78);\n\tv97 = UnityEngine.Vector3::get_right();\n\tv104 = UnityEngine.Vector3::op_Multiply(v97, size);\n\tv119 = UnityEngine.Vector3::op_Addition(pos, v104);\n\tgoto L_0086;\n\tv131 = *([v127 @ X0_v10+E0]);\n\tv132 = v131 == 0;\n\tv133 = ~v132;\n\tif (v133) goto L_0086;\n\tv135 = \"il2cpp_codegen_runtime_class_init\"(v127, v47, v48, v49, v50, v51, v52, v53, v119, v120, v121, v107, v108, v109, v5, v6);\nL_0086:\n\tUnityEngine.Debug::DrawLine(v90, v119, color);\n\tv157 = UnityEngine.Vector3::get_up();\n\tv164 = UnityEngine.Vector3::op_Multiply(v157, size);\n\tv176 = UnityEngine.Vector3::op_Subtraction(pos, v164);\n\tv183 = UnityEngine.Vector3::get_up();\n\tv189 = UnityEngine.Vector3::op_Multiply(v183, size);\n\tv201 = UnityEngine.Vector3::op_Addition(pos, v189);\n\tUnityEngine.Debug::DrawLine(v176, v201, color);\n\tv221 = UnityEngine.Vector3::get_forward();\n\tv227 = UnityEngine.Vector3::op_Multiply(v221, size);\n\tv239 = UnityEngine.Vector3::op_Subtraction(pos, v227);\n\tv246 = UnityEngine.Vector3::get_forward();\n\tv252 = UnityEngine.Vector3::op_Multiply(v246, size);\n\tv264 = UnityEngine.Vector3::op_Addition(pos, v252);\n\tUnityEngine.Debug::DrawLine(v239, v264, color);\n\treturn;\n// 234 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void DebugDrawCross(Vector3 pos, float size, Color color)
		{
			object obj2 = default(object);
			object obj = obj2;
			_ = color.a;
			_ = color.g;
			Vector3 right = Vector3.right;
			Vector3 vector = right * size;
			Vector3 start = pos - vector;
			Vector3 right2 = Vector3.right;
			Vector3 vector2 = right2 * size;
			Vector3 end = pos + vector2;
			Debug.DrawLine(start, end, color);
			Vector3 up = Vector3.up;
			Vector3 vector3 = up * size;
			Vector3 start2 = pos - vector3;
			Vector3 up2 = Vector3.up;
			Vector3 vector4 = up2 * size;
			Vector3 end2 = pos + vector4;
			Debug.DrawLine(start2, end2, color);
			Vector3 forward = Vector3.forward;
			Vector3 vector5 = forward * size;
			Vector3 start3 = pos - vector5;
			Vector3 forward2 = Vector3.forward;
			Vector3 vector6 = forward2 * size;
			Vector3 end3 = pos + vector6;
			Debug.DrawLine(start3, end3, color);
		}

		[Token(Token = "0x60003D5")]
		[Address(RVA = "0x9EB158", Offset = "0x9EB158", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\trhs->klass = rhs->klass;\n\tlhs->klass = lhs->klass;\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static void Swap<T>(ref T lhs, ref T rhs)
		{
			ref T reference = ref *(T*)System.Runtime.CompilerServices.Unsafe.As<T, object>(ref rhs);
			ref T reference2 = ref *(T*)System.Runtime.CompilerServices.Unsafe.As<T, object>(ref lhs);
		}

		[Token(Token = "0x60003D6")]
		[Address(RVA = "0x9EA9A0", Offset = "0x9EA9A0", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = index1 & 0x80000000;\n\tv8 = v6 == 0;\n\tv9 = ~v8;\n\tif (v9) goto L_0057;\n\tv10 = source == 0;\n\tif (v10) goto L_0057;\n\tv71 = index2 == 0;\n\tif (v71) goto L_0057;\n\tv24 = source.Length <= index1;\n\tif (v24) goto L_0057;\n\tv25 = source.Length <= index2;\n\tif (v25) goto L_0057;\n\tv116 = source.Length < index1;\n\tv117 = ~v116;\n\tv118 = source.Length - index1;\n\tv120 = v118 == 0;\n\tv125 = ~v117;\n\tv126 = v125 | v120;\n\tif (v126) goto L_0058;\n\tv127 = source + index1;\n\tv128 = v127 + 0x20;\n\tv129 = source.Length < index2;\n\tv130 = ~v129;\n\tv131 = source.Length - index2;\n\tv133 = v131 == 0;\n\tv138 = ~v130;\n\tv139 = v138 | v133;\n\tif (v139) goto L_0058;\n\tv154 = source + index2;\n\tv67 = v154 + 0x20;\n\t*([v128 @ X10_v4]) = *([v67 @ X8_v5]);\n\tv155 = source.Length < index2;\n\tv62 = ~v155;\n\tv57 = source.Length - index2;\n\tv47 = v57 == 0;\n\tv156 = ~v62;\n\tv22 = v156 | v47;\n\tif (v22) goto L_0058;\n\t*([v67 @ X8_v5]) = *([v128 @ X10_v4]);\nL_0057:\n\treturn;\nL_0058:\n\tv140 = new System.IndexOutOfRangeException();\n\tthrow v140;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Swap<T>(this T[] source, int index1, int index2)
		{
			//IL_0012: Expected I4, but got I8
			//IL_0123: Expected O, but got I
			//IL_0132: Expected O, but got I
			//IL_019f: Expected O, but got I
			//IL_01ae: Expected O, but got I
			if ((int)(index1 & 0x80000000L) != 0 || source == null || index2 == 0 || source.Length <= index1 || source.Length <= index2)
			{
				return;
			}
			bool flag = source.Length < index1;
			bool flag2 = !flag;
			int num = source.Length - index1;
			bool flag3 = num == 0;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				object obj = (long)(IntPtr)source + (long)index1;
				object obj2 = (long)(IntPtr)obj + 32L;
				bool flag5 = source.Length < index2;
				bool flag6 = !flag5;
				int num2 = source.Length - index2;
				bool flag7 = num2 == 0;
				bool flag8 = !flag6;
				if (!(flag8 || flag7))
				{
					object obj3 = (long)(IntPtr)source + (long)index2;
					object obj4 = (long)(IntPtr)obj3 + 32L;
					obj2 = obj4;
					bool flag9 = source.Length < index2;
					bool flag10 = !flag9;
					int num3 = source.Length - index2;
					bool flag11 = num3 == 0;
					bool flag12 = !flag10;
					if (!(flag12 || flag11))
					{
						obj4 = obj2;
						return;
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x60003D7")]
		[Address(RVA = "0x9EAA14", Offset = "0x9EAA14", Length = "0x368")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv28 = index1 & 0x80000000;\n\tv29 = v28 == 0;\n\tv30 = ~v29;\n\tif (v30) goto L_00D2;\n\tv31 = list == 0;\n\tif (v31) goto L_00D2;\n\tv105 = index2 == 0;\n\tif (v105) goto L_00D2;\n\tgoto L_0020;\n\tv183 = v98;\n\tv184 = 0x8907BC(v183, index1, index2, methodInfo, v118, v185, v186, v187, v188, v189, v190, v191, v192, v193, v194, v195);\nL_0020:\n\tv197 = list->klass;\n\tv106 = *([v197 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]) == 0;\n\tif (v106) goto L_0043;\n\tv241 = *([v197 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]) + 8;\nL_002C:\n\tv246 = *([v241 @ X11_v36-8]) == Il2CppClass<System.Collections.Generic.ICollection`1<T>>;\n\tif (v246) goto L_0045;\n\tv240 = v240 + 1;\n\tv251 = v240 < *([v197 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]);\n\tv221 = ~v251;\n\tv241 = v241 + 0x10;\n\tv205 = ~v221;\n\tif (v205) goto L_002C;\nL_0043:\n\tgoto L_004B;\nL_0045:\n\t;\nL_004B:\n\tv95 = System.Collections.Generic.ICollection`1<T>::get_Count(list);\n\tv48 = v95 <= index1;\n\tif (v48) goto L_00D2;\n\tgoto L_0062;\n\tv277 = v99;\n\tv278 = 0x8907BC(v277, v44, v41, methodInfo, v118, v185, v186, v187, v188, v189, v190, v191, v192, v193, v194, v195);\nL_0062:\n\tv280 = list->klass;\n\tv107 = *([v280 @ X8_v9 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]) == 0;\n\tif (v107) goto L_0085;\n\tv324 = *([v280 @ X8_v9 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]) + 8;\nL_006E:\n\tv329 = *([v324 @ X11_v31-8]) == Il2CppClass<System.Collections.Generic.ICollection`1<T>>;\n\tif (v329) goto L_0087;\n\tv323 = v323 + 1;\n\tv334 = v323 < *([v280 @ X8_v9 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]);\n\tv304 = ~v334;\n\tv324 = v324 + 0x10;\n\tv288 = ~v304;\n\tif (v288) goto L_006E;\nL_0085:\n\tgoto L_008D;\nL_0087:\n\t;\nL_008D:\n\tv96 = System.Collections.Generic.ICollection`1<T>::get_Count(list);\n\tv49 = v96 <= index2;\n\tif (v49) goto L_00D2;\n\tgoto L_00A4;\n\tv361 = v356;\n\tv362 = 0x8907BC(v361, v45, v42, methodInfo, v118, v185, v186, v187, v188, v189, v190, v191, v192, v193, v194, v195);\nL_00A4:\n\tv364 = list->klass;\n\tv366 = *([v364 @ X8_v14 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]) == 0;\n\tif (v366) goto L_00C7;\n\tv409 = *([v364 @ X8_v14 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]) + 8;\nL_00B0:\n\tv414 = *([v409 @ X11_v26-8]) == Il2CppClass<System.Collections.Generic.IList`1<T>>;\n\tif (v414) goto L_00D4;\n\tv408 = v408 + 1;\n\tv419 = v408 < *([v364 @ X8_v14 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]);\n\tv389 = ~v419;\n\tv409 = v409 + 0x10;\n\tv373 = ~v389;\n\tif (v373) goto L_00B0;\nL_00C7:\n\tgoto L_00DB;\nL_00D2:\n\treturn;\nL_00D4:\n\t;\nL_00DB:\n\tv446 = System.Collections.Generic.IList`1<T>::get_Item(list, index1);\n\tgoto L_00E6;\n\tv454 = v449;\n\tv455 = 0x8907BC(v454, v445, v443, methodInfo, v118, v185, v186, v187, v188, v189, v190, v191, v192, v193, v194, v195);\nL_00E6:\n\tv457 = list->klass;\n\tv459 = *([v457 @ X8_v19 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]) == 0;\n\tif (v459) goto L_0109;\n\tv502 = *([v457 @ X8_v19 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]) + 8;\nL_00F2:\n\tv507 = *([v502 @ X11_v21-8]) == Il2CppClass<System.Collections.Generic.IList`1<T>>;\n\tif (v507) goto L_010B;\n\tv501 = v501 + 1;\n\tv512 = v501 < *([v457 @ X8_v19 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]);\n\tv482 = ~v512;\n\tv502 = v502 + 0x10;\n\tv466 = ~v482;\n\tif (v466) goto L_00F2;\nL_0109:\n\tgoto L_0112;\nL_010B:\n\t;\nL_0112:\n\tv539 = System.Collections.Generic.IList`1<T>::get_Item(list, index2);\n\tgoto L_011D;\n\tv547 = v542;\n\tv548 = 0x8907BC(v547, v538, v536, methodInfo, v118, v185, v186, v187, v188, v189, v190, v191, v192, v193, v194, v195);\nL_011D:\n\tv550 = list->klass;\n\tv552 = *([v550 @ X8_v24 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]) == 0;\n\tif (v552) goto L_0140;\n\tv595 = *([v550 @ X8_v24 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]) + 8;\nL_0129:\n\tv600 = *([v595 @ X11_v16-8]) == Il2CppClass<System.Collections.Generic.IList`1<T>>;\n\tif (v600) goto L_0142;\n\tv594 = v594 + 1;\n\tv605 = v594 < *([v550 @ X8_v24 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]);\n\tv575 = ~v605;\n\tv595 = v595 + 0x10;\n\tv559 = ~v575;\n\tif (v559) goto L_0129;\nL_0140:\n\tgoto L_014B;\nL_0142:\n\tv607 = *([v595 @ X11_v16]) + 1;\n\tv608 = v607 << 4;\n\tv609 = v550 + v608;\n\tv627 = v609 + 0x130;\nL_014B:\n\tv634 = System.Collections.Generic.IList`1<T>::set_Item(list, index1, v539);\n\tgoto L_0155;\n\tv641 = v636;\n\tv642 = 0x8907BC(v641, v632, v633, v630, v118, v185, v186, v187, v188, v189, v190, v191, v192, v193, v194, v195);\nL_0155:\n\tv644 = list->klass;\n\tv167 = *([v644 @ X8_v29 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]) == 0;\n\tif (v167) goto L_0177;\n\tv688 = *([v644 @ X8_v29 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]) + 8;\nL_0161:\n\tv693 = *([v688 @ X11_v11-8]) == Il2CppClass<System.Collections.Generic.IList`1<T>>;\n\tif (v693) goto L_017A;\n\tv687 = v687 + 1;\n\tv698 = v687 < *([v644 @ X8_v29 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]);\n\tv668 = ~v698;\n\tv688 = v688 + 0x10;\n\tv652 = ~v668;\n\tif (v652) goto L_0161;\nL_0177:\n\tv706 = 0x8909C4(list, Il2CppClass<System.Collections.Generic.IList`1<T>>, 1, *([v627 @ X0_v19+8]), v118, v185, v186, v187, v188, v189, v190, v191, v192, v193, v194, v195);\n\tgoto L_017E;\nL_017A:\n\tv700 = *([v688 @ X11_v11]) + 1;\n\tv701 = v700 << 4;\n\tv702 = v644 + v701;\n\tv706 = v702 + 0x130;\nL_017E:\n\tv119 = *([v706 @ X0_v23]);\n\tv121 = *([v706 @ X0_v23+8]);\n\t// 397 IndirectJump v119 @ X4_v1, list @ X0 (System.Collections.Generic.IList`1<T>), list @ X0 (System.Collections.Generic.IList`1<T>), index2 @ X2 (System.Int32), v446 @ X0_v13, v121 @ X3_v2, v119 @ X4_v1, v185 @ X5, v186 @ X6, v187 @ X7, v188 @ V0, v189 @ V1, v190 @ V2, v191 @ V3, v192 @ V4, v193 @ V5, v194 @ V6, v195 @ V7\n\treturn;\n// 268 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Swap<T>(this IList<T> list, int index1, int index2)
		{
			//IL_0012: Expected I4, but got I8
			//IL_0081: Expected I, but got O
			//IL_00bc: Expected O, but got I
			//IL_013b: Expected I, but got O
			//IL_0108: Expected O, but got I
			//IL_0176: Expected O, but got I
			//IL_01f5: Expected I, but got O
			//IL_01c2: Expected O, but got I
			//IL_0230: Expected O, but got I
			//IL_02ab: Expected I, but got O
			//IL_02e6: Expected O, but got I
			//IL_027c: Expected O, but got I
			//IL_0360: Expected I, but got O
			//IL_039b: Expected O, but got I
			//IL_0332: Expected O, but got I
			//IL_044c: Expected I, but got O
			//IL_040e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0413: Expected O, but got Unknown
			//IL_0430: Expected O, but got I
			//IL_043f: Expected O, but got I
			//IL_06b8: Expected O, but got I
			//IL_0487: Expected O, but got I
			//IL_03e7: Expected O, but got I
			//IL_0504: Unknown result type (might be due to invalid IL or missing references)
			//IL_0509: Expected O, but got Unknown
			//IL_0526: Expected O, but got I
			//IL_0535: Expected O, but got I
			//IL_04d3: Expected O, but got I
			if ((int)(index1 & 0x80000000L) != 0 || list == null || index2 == 0)
			{
				return;
			}
			IntPtr intPtr = (IntPtr)list;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
			if ((IntPtr)0 != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				bool flag2;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ X11_v36-8]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
						bool flag = (long)num2 < 0L;
						flag2 = !flag;
						obj = (long)(IntPtr)obj + 16L;
						continue;
					}
					break;
				}
				while (!flag2);
			}
			int count = list.Count;
			if (count <= index1)
			{
				return;
			}
			IntPtr intPtr2 = (IntPtr)list;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ X8_v9 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
			if ((IntPtr)0 != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ X8_v9 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]");
				object obj2 = 0L + 8L;
				int num3 = 0;
				bool flag4;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v324 @ X11_v31-8]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						num3++;
						int num4 = num3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ X8_v9 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
						bool flag3 = (long)num4 < 0L;
						flag4 = !flag3;
						obj2 = (long)(IntPtr)obj2 + 16L;
						continue;
					}
					break;
				}
				while (!flag4);
			}
			int count2 = list.Count;
			if (count2 <= index2)
			{
				return;
			}
			IntPtr intPtr3 = (IntPtr)list;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v364 @ X8_v14 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
			if ((IntPtr)0 != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v364 @ X8_v14 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]");
				object obj3 = 0L + 8L;
				int num5 = 0;
				bool flag6;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v409 @ X11_v26-8]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						num5++;
						int num6 = num5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v364 @ X8_v14 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
						bool flag5 = (long)num6 < 0L;
						flag6 = !flag5;
						obj3 = (long)(IntPtr)obj3 + 16L;
						continue;
					}
					break;
				}
				while (!flag6);
			}
			object obj4 = list.get_Item(index1);
			IntPtr intPtr4 = (IntPtr)list;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ X8_v19 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
			if ((IntPtr)0 != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ X8_v19 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]");
				object obj5 = 0L + 8L;
				int num7 = 0;
				bool flag8;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v502 @ X11_v21-8]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						num7++;
						int num8 = num7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ X8_v19 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
						bool flag7 = (long)num8 < 0L;
						flag8 = !flag7;
						obj5 = (long)(IntPtr)obj5 + 16L;
						continue;
					}
					break;
				}
				while (!flag8);
			}
			object value = list.get_Item(index2);
			IntPtr intPtr5 = (IntPtr)list;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v550 @ X8_v24 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
			if ((IntPtr)0 != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v550 @ X8_v24 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]");
				object obj6 = 0L + 8L;
				int num9 = 0;
				bool flag10;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v595 @ X11_v16-8]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						num9++;
						int num10 = num9;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v550 @ X8_v24 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
						bool flag9 = (long)num10 < 0L;
						flag10 = !flag9;
						obj6 = (long)(IntPtr)obj6 + 16L;
						continue;
					}
					object obj7 = obj6 + 1;
					int num11 = (int)((long)(IntPtr)obj7 << 4);
					object obj8 = (long)intPtr5 + (long)num11;
					object obj9 = (long)(IntPtr)obj8 + 304L;
					break;
				}
				while (!flag10);
			}
			list.set_Item(index1, (T)value);
			IntPtr intPtr6 = (IntPtr)list;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v644 @ X8_v29 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_04ec;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v644 @ X8_v29 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]");
			object obj10 = 0L + 8L;
			int num12 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v688 @ X11_v11-8]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					break;
				}
				num12++;
				int num13 = num12;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v644 @ X8_v29 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
				bool flag11 = (long)num13 < 0L;
				bool flag12 = !flag11;
				obj10 = (long)(IntPtr)obj10 + 16L;
				if (!flag12)
				{
					continue;
				}
				goto IL_04ec;
			}
			object obj11 = obj10 + 1;
			int num14 = (int)((long)(IntPtr)obj11 << 4);
			object obj12 = (long)intPtr6 + (long)num14;
			object obj13 = (long)(IntPtr)obj12 + 304L;
			goto IL_06a0;
			IL_06a0:
			object obj14 = obj13;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v706 @ X0_v23+8]");
			object obj15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v119 @ X4_v1 (should have been resolved before IL gen)");
			return;
			IL_04ec:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_06a0;
		}

		[Token(Token = "0x60003D8")]
		[Address(RVA = "0x9EA7DC", Offset = "0x9EA7DC", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv40 = *([1EB5B10]);\n\tv41 = *([v40 @ X8_v14]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, index, count, positions, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([2021AC9]) = v56;\nL_0028:\n\tv67 = positions < 1;\n\tif (v67) goto L_0072;\n\tv134 = count + index;\nL_002E:\n\tv141 = v138 + count;\n\tv152 = v138 >= v141;\n\tif (v152) goto L_0058;\nL_003F:\n\tgoto L_0046;\n\tv199 = *([v185 @ X0_v6+E0]);\n\tv200 = v199 == 0;\n\tv201 = ~v200;\n\tif (v201) goto L_0046;\n\tv203 = \"il2cpp_codegen_runtime_class_init\"(v185, v173, v175, v171, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_0046:\n\tv176 = v183 - 1;\n\tv178 = Obi.ObiUtils::Swap(source, v183, v176);\n\tv183 = v183 + 1;\n\tv154 = v183 != v134;\n\tif (v154) goto L_003F;\nL_0058:\n\tv135 = v135 + 1;\n\tv138 = v138 - 1;\n\tv134 = v134 - 1;\n\tv73 = v135 != positions;\n\tif (v73) goto L_002E;\nL_0072:\n\treturn;\n// 86 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ShiftLeft<T>(this T[] source, int index, int count, int positions)
		{
			if (positions < 1)
			{
				return;
			}
			int num = count + index;
			int num2 = 0;
			int num3 = index;
			do
			{
				int num4 = num3 + count;
				bool flag = num3 >= num4;
				int num5 = num3;
				if (!flag)
				{
					do
					{
						int index2 = num5 - 1;
						source.Swap(num5, index2);
						num5++;
					}
					while (num5 != num);
				}
				num2++;
				num3--;
				num--;
			}
			while (num2 != positions);
		}

		[Token(Token = "0x60003D9")]
		[Address(RVA = "0x9EA8C8", Offset = "0x9EA8C8", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv38 = *([1EF6AF0]);\n\tv39 = *([v38 @ X8_v13]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, index, count, positions, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2021ACA]) = v54;\nL_0027:\n\tv65 = positions < 1;\n\tif (v65) goto L_0064;\nL_002C:\n\tv134 = v131 + count;\n\tv105 = v134 - 1;\n\tgoto L_004A;\nL_0033:\n\tgoto L_003A;\n\tv167 = *([v163 @ X0_v5+E0]);\n\tv168 = v167 == 0;\n\tv169 = ~v168;\n\tif (v169) goto L_003A;\n\tv171 = \"il2cpp_codegen_runtime_class_init\"(v163, v90, v92, v88, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_003A:\n\tv156 = v105 + 1;\n\tv157 = Obi.ObiUtils::Swap(source, v105, v156);\n\tv105 = v105 - 1;\nL_004A:\n\tv137 = v105 >= v131;\n\tif (v137) goto L_0033;\n\tv128 = v128 + 1;\n\tv131 = v131 + 1;\n\tv70 = v128 != positions;\n\tif (v70) goto L_002C;\nL_0064:\n\treturn;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ShiftRight<T>(this T[] source, int index, int count, int positions)
		{
			if (positions < 1)
			{
				return;
			}
			int num = 0;
			int num2 = index;
			do
			{
				int num3 = num2 + count;
				for (int num4 = num3 - 1; num4 >= num2; num4--)
				{
					int index2 = num4 + 1;
					source.Swap(num4, index2);
				}
				num++;
				num2++;
			}
			while (num != positions);
		}

		[Token(Token = "0x60003DA")]
		[Address(RVA = "0x102ADEC", Offset = "0x102ADEC", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = 0x100E244(bounds, 0, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25);\n\tv27 = System.Single::IsNaN(v18);\n\tv29 = v27 == 0;\n\tv30 = ~v29;\n\tif (v30) goto L_FFFFFFFF;\n\tv33 = 0x100E244(bounds, 0, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25);\n\tv45 = System.Single::IsInfinity(v18);\n\tv68 = v45 == 0;\n\tv40 = ~v68;\n\tif (v40) goto L_FFFFFFFF;\n\tv70 = 0x100E244(bounds, 0, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25);\n\tv46 = System.Single::IsNaN(v19);\n\tv73 = v46 == 0;\n\tv41 = ~v73;\n\tif (v41) goto L_FFFFFFFF;\n\tv75 = 0x100E244(bounds, 0, v12, v13, v14, v15, v16, v17, v19, v19, v20, v21, v22, v23, v24, v25);\n\tv47 = System.Single::IsInfinity(v19);\n\tv78 = v47 == 0;\n\tv42 = ~v78;\n\tif (v42) goto L_FFFFFFFF;\n\tv80 = 0x100E244(bounds, 0, v12, v13, v14, v15, v16, v17, v19, v19, v20, v21, v22, v23, v24, v25);\n\tv44 = System.Single::IsNaN(v20);\n\tv39 = v44 == 0;\n\tif (v39) goto L_003D;\nL_0037:\n\treturnVal1 = v54 & 1;\n\treturn returnVal1;\nL_003D:\n\tv84 = 0x100E244(bounds, 0, v12, v13, v14, v15, v16, v17, v20, v19, v20, v21, v22, v23, v24, v25);\n\tv60 = System.Single::IsInfinity(v20);\n\tv54 = v60 ^ 1;\n\tgoto L_0037;\n\treturn X0;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool AreValid(this Bounds bounds)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @100E244 (inside UnityEngine.BootConfigData::WrapBootConfigData +0x17C)");
			float f = default(float);
			int num;
			if (!float.IsNaN(f))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @100E244 (inside UnityEngine.BootConfigData::WrapBootConfigData +0x17C)");
				if (!float.IsInfinity(f))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @100E244 (inside UnityEngine.BootConfigData::WrapBootConfigData +0x17C)");
					float f2 = default(float);
					if (!float.IsNaN(f2))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @100E244 (inside UnityEngine.BootConfigData::WrapBootConfigData +0x17C)");
						if (!float.IsInfinity(f2))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @100E244 (inside UnityEngine.BootConfigData::WrapBootConfigData +0x17C)");
							float f3 = default(float);
							if (!float.IsNaN(f3))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @100E244 (inside UnityEngine.BootConfigData::WrapBootConfigData +0x17C)");
								bool flag = float.IsInfinity(f3);
								num = (flag ? 1 : 0) ^ 1;
								goto IL_0186;
							}
						}
					}
				}
			}
			num = 0;
			goto IL_0186;
			IL_0186:
			return (byte)(num & 1) != 0;
		}

		[Token(Token = "0x60003DB")]
		[Address(RVA = "0x102AEB0", Offset = "0x102AEB0", Length = "0x5F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv30 = &v31 @ stack_-10_v2;\n\tgoto L_0026;\n\tv44 = *([1EF6BF8]);\n\tv45 = *([v44 @ X8_v14]);\n\tv46 = \"il2cpp_codegen_initialize_method\"(v45, m, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60);\n\tv63 = 0 | 1;\n\t*([2026282]) = v63;\nL_0026:\n\tv70 = 0x10C2040(m, 0, 0, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60);\n\tv77 = 0x100E4C4(b, 0, 0, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60);\n\tgoto L_0041;\n\tv85 = *([v81 @ X0_v6+E0]);\n\tv86 = v85 == 0;\n\tv87 = ~v86;\n\tgoto L_0041;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v81, v72, v66, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60);\nL_0041:\n\t// 65 MakeStruct v98 @ AGG102AF78_0_v1 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), v53 @ V0 (System.Single), v54 @ V1, v55 @ V2, v56 @ V3\n\tv99 = UnityEngine.Vector4::op_Multiply(v98, v53);\n\tv110 = 0x10C2040(m, 0, 0, v48, v49, v50, v51, v52, v99, v99.y, v99.z, v99.w, v53, v58, v59, v60);\n\tv117 = 0x100E564(b, 0, 0, v48, v49, v50, v51, v52, v99, v99.y, v99.z, v99.w, v53, v58, v59, v60);\n\tv125 = UnityEngine.Vector4::op_Multiply(v99, v99);\n\t*([v30 @ X29_v1-28]) = v125.w;\n\t*([v30 @ X29_v1-24]) = v125.z;\n\tv134 = 0x10C2040(m, 1, 0, v48, v49, v50, v51, v52, v125, v125.y, v125.z, v125.w, v99, v58, v59, v60);\n\tv141 = 0x100E4C4(b, 0, 0, v48, v49, v50, v51, v52, v125, v125.y, v125.z, v125.w, v99, v58, v59, v60);\n\tv149 = UnityEngine.Vector4::op_Multiply(v125, v125.y);\n\tv160 = 0x10C2040(m, 1, 0, v48, v49, v50, v51, v52, v149, v149.y, v149.z, v149.w, v125.y, v58, v59, v60);\n\tv167 = 0x100E564(b, 0, 0, v48, v49, v50, v51, v52, v149, v149.y, v149.z, v149.w, v125.y, v58, v59, v60);\n\tv175 = UnityEngine.Vector4::op_Multiply(v149, v149.y);\n\tv186 = 0x10C2040(m, 2, 0, v48, v49, v50, v51, v52, v175, v175.y, v175.z, v175.w, v149.y, v58, v59, v60);\n\tv193 = 0x100E4C4(b, 0, 0, v48, v49, v50, v51, v52, v175, v175.y, v175.z, v175.w, v149.y, v58, v59, v60);\n\tv201 = UnityEngine.Vector4::op_Multiply(v175, v175.z);\n\tv212 = 0x10C2040(m, 2, 0, v48, v49, v50, v51, v52, v201, v201.y, v201.z, v201.w, v175.z, v58, v59, v60);\n\tv219 = 0x100E564(b, 0, 0, v48, v49, v50, v51, v52, v201, v201.y, v201.z, v201.w, v175.z, v58, v59, v60);\n\tv227 = UnityEngine.Vector4::op_Multiply(v201, v201.z);\n\tv241 = 0x10C2040(m, 3, 0, v48, v49, v50, v51, v52, v227, v227.y, v227.z, v227.w, v201.z, v58, v59, v60);\n\tv244 = UnityEngine.Vector4::op_Implicit(v227);\n\tv259 = UnityEngine.Vector4::op_Implicit(v99);\n\t// 240 MakeStruct v271 @ AGG102B188_0_v1 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), v125 @ V0_v4 (UnityEngine.Vector4), v125.y (System.Single), [v30 @ X29_v1-24], [v30 @ X29_v1-28]\n\tv272 = UnityEngine.Vector4::op_Implicit(v271);\n\tgoto L_010C;\n\tv284 = *([v280 @ X0_v39+E0]);\n\tv285 = v284 == 0;\n\tv286 = ~v285;\n\tif (v286) goto L_010C;\n\tv288 = \"il2cpp_codegen_runtime_class_init\"(v280, v231, v233, v48, v49, v50, v51, v52, v272, v273, v274, v265, v220, v58, v59, v60);\nL_010C:\n\tv300 = UnityEngine.Vector3::Min(v259, v272);\n\tv314 = UnityEngine.Vector4::op_Implicit(v149);\n\tv326 = UnityEngine.Vector4::op_Implicit(v175);\n\tv338 = UnityEngine.Vector3::Min(v314, v326);\n\tv350 = UnityEngine.Vector3::op_Addition(v300, v338);\n\tv362 = UnityEngine.Vector4::op_Implicit(v201);\n\tv374 = UnityEngine.Vector4::op_Implicit(v227);\n\tv386 = UnityEngine.Vector3::Min(v362, v374);\n\tv398 = UnityEngine.Vector3::op_Addition(v350, v386);\n\tv409 = UnityEngine.Vector3::op_Addition(v398, v244);\n\tv421 = UnityEngine.Vector4::op_Implicit(v99);\n\t// 400 MakeStruct v432 @ AGG102B320_0_v1 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), v125 @ V0_v4 (UnityEngine.Vector4), v125.y (System.Single), [v30 @ X29_v1-24], [v30 @ X29_v1-28]\n\tv433 = UnityEngine.Vector4::op_Implicit(v432);\n\tv445 = UnityEngine.Vector3::Max(v421, v433);\n\tv457 = UnityEngine.Vector4::op_Implicit(v149);\n\tv469 = UnityEngine.Vector4::op_Implicit(v175);\n\tv481 = UnityEngine.Vector3::Max(v457, v469);\n\tv493 = UnityEngine.Vector3::op_Addition(v445, v481);\n\tv505 = UnityEngine.Vector4::op_Implicit(v201);\n\tv517 = UnityEngine.Vector4::op_Implicit(v227);\n\tv529 = UnityEngine.Vector3::Max(v505, v517);\n\tv541 = UnityEngine.Vector3::op_Addition(v493, v529);\n\tv550 = UnityEngine.Vector3::op_Addition(v541, v244);\n\treturnVal1 = 0x100E76C(&v560 @ stack_-98_v3 (UnityEngine.Vector3), 0, 0, v48, v49, v50, v51, v52, v409, v409.y, v409.z, v550, v550.y, v550.z, v59, v60);\n\t*([returnBuffer @ X8 (UnityEngine.Bounds)+10]) = 0;\n\treturnBuffer.m_Center = v560;\n\treturn returnVal1;\n// 479 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static Bounds Transform(this Bounds b, Matrix4x4 m)
		{
			//IL_0027: Expected F4, but got O
			//IL_0034: Expected F4, but got O
			//IL_0041: Expected F4, but got O
			//IL_01c2: Expected F4, but got I
			//IL_01d7: Expected F4, but got I
			//IL_02e7: Expected F4, but got I
			//IL_02fc: Expected F4, but got I
			//IL_03d9: Expected native int or pointer, but got O
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10C2040 (inside UnityEngine.Matrix4x4::Inverse_Injected +0x438)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @100E4C4 (inside UnityEngine.BootConfigData::WrapBootConfigData +0x3FC)");
			Vector4 vector = default(Vector4);
			float num = default(float);
			vector.x = num;
			object obj3 = default(object);
			vector.y = (float)obj3;
			object obj4 = default(object);
			vector.z = (float)obj4;
			object obj5 = default(object);
			vector.w = (float)obj5;
			Vector4 vector2 = vector * num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10C2040 (inside UnityEngine.Matrix4x4::Inverse_Injected +0x438)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @100E564 (inside UnityEngine.BootConfigData::WrapBootConfigData +0x49C)");
			Vector4 vector3 = vector2 * vector2.x;
			_ = vector3.w;
			_ = vector3.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10C2040 (inside UnityEngine.Matrix4x4::Inverse_Injected +0x438)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @100E4C4 (inside UnityEngine.BootConfigData::WrapBootConfigData +0x3FC)");
			Vector4 vector4 = vector3 * vector3.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10C2040 (inside UnityEngine.Matrix4x4::Inverse_Injected +0x438)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @100E564 (inside UnityEngine.BootConfigData::WrapBootConfigData +0x49C)");
			Vector4 vector5 = vector4 * vector4.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10C2040 (inside UnityEngine.Matrix4x4::Inverse_Injected +0x438)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @100E4C4 (inside UnityEngine.BootConfigData::WrapBootConfigData +0x3FC)");
			Vector4 vector6 = vector5 * vector5.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10C2040 (inside UnityEngine.Matrix4x4::Inverse_Injected +0x438)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @100E564 (inside UnityEngine.BootConfigData::WrapBootConfigData +0x49C)");
			Vector4 vector7 = vector6 * vector6.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10C2040 (inside UnityEngine.Matrix4x4::Inverse_Injected +0x438)");
			Vector3 vector8 = vector7;
			Vector3 lhs = vector2;
			Vector4 vector9 = default(Vector4);
			vector9.x = vector3.x;
			vector9.y = vector3.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X29_v1-24]");
			vector9.z = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X29_v1-28]");
			vector9.w = 0f;
			Vector3 rhs = vector9;
			Vector3 vector10 = Vector3.Min(lhs, rhs);
			Vector3 lhs2 = vector4;
			Vector3 rhs2 = vector5;
			Vector3 vector11 = Vector3.Min(lhs2, rhs2);
			Vector3 vector12 = vector10 + vector11;
			Vector3 lhs3 = vector6;
			Vector3 rhs3 = vector7;
			Vector3 vector13 = Vector3.Min(lhs3, rhs3);
			Vector3 vector14 = vector12 + vector13;
			Vector3 vector15 = vector14 + vector8;
			Vector3 lhs4 = vector2;
			Vector4 vector16 = default(Vector4);
			vector16.x = vector3.x;
			vector16.y = vector3.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X29_v1-24]");
			vector16.z = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X29_v1-28]");
			vector16.w = 0f;
			Vector3 rhs4 = vector16;
			Vector3 vector17 = Vector3.Max(lhs4, rhs4);
			Vector3 lhs5 = vector4;
			Vector3 rhs5 = vector5;
			Vector3 vector18 = Vector3.Max(lhs5, rhs5);
			Vector3 vector19 = vector17 + vector18;
			Vector3 lhs6 = vector6;
			Vector3 rhs6 = vector7;
			Vector3 vector20 = Vector3.Max(lhs6, rhs6);
			Vector3 vector21 = vector19 + vector20;
			Vector3 vector22 = vector21 + vector8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @100E76C (inside UnityEngine.Bounds::op_Inequality +0x4C)");
			_ = 0;
			Bounds bounds = default(Bounds);
			Vector3 center = default(Vector3);
			((Bounds*)(IntPtr)bounds)->m_Center = center;
			Bounds result = default(Bounds);
			return result;
		}

		[Token(Token = "0x60003DC")]
		[Address(RVA = "0x1032170", Offset = "0x1032170", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = a + b;\n\tv7 = a.y + b.y;\n\tv8 = a.z + b.z;\n\t*([result @ X0 (UnityEngine.Vector3&)]) = v6;\n\t*([result @ X0 (UnityEngine.Vector3&)+4]) = v7;\n\t*([result @ X0 (UnityEngine.Vector3&)+8]) = v8;\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static void Add(Vector3 a, Vector3 b, ref Vector3 result)
		{
			//IL_0053: Expected Ref, but got F4
			Vector3 vector = default(Vector3);
			Vector3 vector2 = default(Vector3);
			float num = vector.x + vector2.x;
			float num2 = a.y + b.y;
			float num3 = a.z + b.z;
			ref Vector3 reference = ref *(Vector3*)num;
		}

		[Token(Token = "0x60003DD")]
		[Address(RVA = "0x1032188", Offset = "0x1032188", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = value - from1;\n\tv3 = to1 - from1;\n\tv5 = v0 / v3;\n\tv6 = to2 - from2;\n\tv9 = v5 * v6;\n\treturnVal1 = v9 + from2;\n\treturn returnVal1;\n")]
		public static float Remap(this float value, float from1, float to1, float from2, float to2)
		{
			float num = value - from1;
			float num2 = to1 - from1;
			float num3 = num / num2;
			float num4 = to2 - from2;
			float num5 = num3 * num4;
			return num5 + from2;
		}

		[Token(Token = "0x60003DE")]
		[Address(RVA = "0x10321A4", Offset = "0x10321A4", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EF1C20]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, v25, v26, v27, v28, v29, v30, v31, a, b, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([2026283]) = v41;\nL_001B:\n\tgoto L_0021;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0021;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, v25, v26, v27, v28, v29, v30, v31, a, b, v32, v33, v34, v35, v36, v37);\nL_0021:\n\tv55 = a / b;\n\tv59 = UnityEngine.Mathf::Floor(v55);\n\tv60 = v59 * b;\n\treturnVal1 = a - v60;\n\treturn returnVal1;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float Mod(float a, float b)
		{
			float f = a / b;
			float num = Mathf.Floor(f);
			float num2 = num * b;
			return a - num2;
		}

		[Token(Token = "0x60003DF")]
		[Address(RVA = "0x1032220", Offset = "0x1032220", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\nL_0010:\n\tv67 = 0x10C1E5C(a, v62, 0, v68, v69, v70, v71, v72, v50, v73, v74, v75, v76, v77, v78, v79);\n\tv83 = 0x10C1E5C(other, v62, 0, v68, v69, v70, v71, v72, v50, v73, v74, v75, v76, v77, v78, v79);\n\tv50 = v50 + v50;\n\treturnVal1 = 0x10C1D2C(a, v62, 0, v68, v69, v70, v71, v72, v50, v73, v74, v75, v76, v77, v78, v79);\n\tv62 = v62 + 1;\n\tv25 = v62 != 0x10;\n\tif (v25) goto L_0010;\n\treturnBuffer.m03 = a.m03;\n\treturnBuffer.m02 = a.m02;\n\treturnBuffer.m01 = a.m01;\n\treturnBuffer.m00 = a.m00;\n\treturn returnVal1;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static Matrix4x4 Add(this Matrix4x4 a, Matrix4x4 other)
		{
			//IL_00ac: Expected O, but got I
			//IL_0049: Expected native int or pointer, but got O
			//IL_005b: Expected native int or pointer, but got O
			//IL_006d: Expected native int or pointer, but got O
			//IL_007f: Expected native int or pointer, but got O
			int num = 0;
			object obj = default(object);
			do
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10C1E5C (inside UnityEngine.Matrix4x4::Inverse_Injected +0x254)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10C1E5C (inside UnityEngine.Matrix4x4::Inverse_Injected +0x254)");
				obj = (long)(IntPtr)obj + (long)(IntPtr)obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10C1D2C (inside UnityEngine.Matrix4x4::Inverse_Injected +0x124)");
				num++;
			}
			while (num != 16);
			Matrix4x4 matrix4x = default(Matrix4x4);
			((Matrix4x4*)(IntPtr)matrix4x)->m03 = a.m03;
			((Matrix4x4*)(IntPtr)matrix4x)->m02 = a.m02;
			((Matrix4x4*)(IntPtr)matrix4x)->m01 = a.m01;
			((Matrix4x4*)(IntPtr)matrix4x)->m00 = a.m00;
			Matrix4x4 result = default(Matrix4x4);
			return result;
		}

		[Token(Token = "0x60003E0")]
		[Address(RVA = "0x10322BC", Offset = "0x10322BC", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\nL_000F:\n\tv63 = 0x10C1E5C(a, v58, 0, v64, v65, v66, v67, v68, v56, v69, v70, v71, v72, v73, v74, v75);\n\tv56 = v56 * s;\n\treturnVal1 = 0x10C1D2C(a, v58, 0, v64, v65, v66, v67, v68, v56, v69, v70, v71, v72, v73, v74, v75);\n\tv58 = v58 + 1;\n\tv23 = v58 != 0x10;\n\tif (v23) goto L_000F;\n\treturnBuffer.m03 = a.m03;\n\treturnBuffer.m02 = a.m02;\n\treturnBuffer.m01 = a.m01;\n\treturnBuffer.m00 = a.m00;\n\treturn returnVal1;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static Matrix4x4 ScalarMultiply(this Matrix4x4 a, float s)
		{
			//IL_0023: Expected native int or pointer, but got O
			//IL_0035: Expected native int or pointer, but got O
			//IL_0047: Expected native int or pointer, but got O
			//IL_0059: Expected native int or pointer, but got O
			float num = s;
			int num2 = 0;
			do
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10C1E5C (inside UnityEngine.Matrix4x4::Inverse_Injected +0x254)");
				num *= s;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10C1D2C (inside UnityEngine.Matrix4x4::Inverse_Injected +0x124)");
				num2++;
			}
			while (num2 != 16);
			Matrix4x4 matrix4x = default(Matrix4x4);
			((Matrix4x4*)(IntPtr)matrix4x)->m03 = a.m03;
			((Matrix4x4*)(IntPtr)matrix4x)->m02 = a.m02;
			((Matrix4x4*)(IntPtr)matrix4x)->m01 = a.m01;
			((Matrix4x4*)(IntPtr)matrix4x)->m00 = a.m00;
			Matrix4x4 result = default(Matrix4x4);
			return result;
		}

		[Token(Token = "0x60003E1")]
		[Address(RVA = "0x1032344", Offset = "0x1032344", Length = "0x1F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv32 = &v33 @ stack_-10_v2;\n\t*([v32 @ X29_v1-18]) = *([v32 @ X29_v1+18]);\n\t*([v32 @ X29_v1-14]) = lineStart.z;\n\tgoto L_0031;\n\tv52 = *([1EF97C0]);\n\tv53 = *([v52 @ X8_v16]);\n\tv54 = \"il2cpp_codegen_initialize_method\"(v53, clampToSegment, methodInfo, v56, v57, v58, v59, v60, point, v36, v2, lineStart, v3, v5, v61, v62);\n\tv65 = 0 | 1;\n\t*([2026284]) = v65;\nL_0031:\n\tgoto L_0041;\n\tv72 = *([v68 @ X0_v2+E0]);\n\tv73 = v72 == 0;\n\tv74 = ~v73;\n\tgoto L_0041;\n\tv76 = \"il2cpp_codegen_runtime_class_init\"(v68, clampToSegment, methodInfo, v56, v57, v58, v59, v60, point, v36, v2, lineStart, v3, v5, v61, v62);\nL_0041:\n\t// 65 MakeStruct v89 @ AGG10323F8_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), lineStart @ V3 (UnityEngine.Vector3), lineStart.y (System.Single), [v32 @ X29_v1-14]\n\tv90 = UnityEngine.Vector3::op_Subtraction(point, v89);\n\t*([v32 @ X29_v1-18]) = lineStart.y;\n\t// 81 MakeStruct v104 @ AGG103242C_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v32 @ X29_v1+10], [v32 @ X29_v1+14], [v32 @ X29_v1-18]\n\t// 82 MakeStruct v105 @ AGG103242C_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), lineStart @ V3 (UnityEngine.Vector3), lineStart.y (System.Single), [v32 @ X29_v1-14]\n\tv106 = UnityEngine.Vector3::op_Subtraction(v104, v105);\n\tv121 = UnityEngine.Vector3::Dot(v90, v106);\n\tv132 = UnityEngine.Vector3::Dot(v106, v106);\n\tv148 = v121 / v132;\n\tmu.x = v148;\n\tv134 = clampToSegment & 1;\n\tv135 = v134 == 0;\n\tif (v135) goto L_008A;\n\tgoto L_0081;\n\tv158 = *([v138 @ X0_v14+E0]);\n\tv159 = v158 == 0;\n\tv160 = ~v159;\n\tif (v160) goto L_0081;\n\tv162 = \"il2cpp_codegen_runtime_class_init\"(v138, clampToSegment, methodInfo, v56, v57, v58, v59, v60, v132, v124, v125, v126, v127, v128, v61, v62);\nL_0081:\n\tv143 = UnityEngine.Mathf::Clamp01(v148);\n\tmu.x = v143;\nL_008A:\n\tgoto L_0096;\n\tv164 = *([v152 @ X0_v9+E0]);\n\tv165 = v164 == 0;\n\tv166 = ~v165;\n\tgoto L_0096;\n\tv168 = \"il2cpp_codegen_runtime_class_init\"(v152, clampToSegment, methodInfo, v56, v57, v58, v59, v60, v142, v124, v125, v126, v127, v128, v61, v62);\nL_0096:\n\tv177 = UnityEngine.Vector3::op_Multiply(v106, v148);\n\t// 174 MakeStruct v200 @ AGG1032534_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), lineStart @ V3 (UnityEngine.Vector3), [v32 @ X29_v1-18], [v32 @ X29_v1-14]\n\treturnVal1 = UnityEngine.Vector3::op_Addition(v200, v177);\n\treturn returnVal1;\n// 134 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector3 ProjectPointLine(Vector3 point, Vector3 lineStart, Vector3 lineEnd, out float mu, bool clampToSegment = true)
		{
			//IL_0067: Expected F4, but got I
			//IL_0097: Expected F4, but got I
			//IL_00ac: Expected F4, but got I
			//IL_00c1: Expected F4, but got I
			//IL_00fa: Expected F4, but got I
			//IL_01e3: Expected F4, but got I
			//IL_01f8: Expected F4, but got I
			mu = default(float);
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1+18]");
			_ = 0;
			_ = lineStart.z;
			Vector3 vector = default(Vector3);
			Vector3 vector2 = default(Vector3);
			vector.x = vector2.x;
			vector.y = lineStart.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1-14]");
			vector.z = 0f;
			Vector3 lhs = point - vector;
			_ = lineStart.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1+10]");
			Vector3 vector3 = default(Vector3);
			vector3.x = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1+14]");
			vector3.y = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1-18]");
			vector3.z = 0f;
			Vector3 vector4 = default(Vector3);
			vector4.x = vector2.x;
			vector4.y = lineStart.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1-14]");
			vector4.z = 0f;
			Vector3 vector5 = vector3 - vector4;
			float num = Vector3.Dot(lhs, vector5);
			float num2 = Vector3.Dot(vector5, vector5);
			float num3 = (System.Runtime.CompilerServices.Unsafe.As<float, Vector3>(ref mu).x = num / num2);
			if ((uint)((ulong)(clampToSegment ? 1 : 0) & 1uL) != 0)
			{
				num3 = (System.Runtime.CompilerServices.Unsafe.As<float, Vector3>(ref mu).x = Mathf.Clamp01(num3));
			}
			Vector3 vector6 = vector5 * num3;
			Vector3 vector7 = default(Vector3);
			vector7.x = vector2.x;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1-18]");
			vector7.y = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1-14]");
			vector7.z = 0f;
			return vector7 + vector6;
		}

		[Token(Token = "0x60003E2")]
		[Address(RVA = "0x1032538", Offset = "0x1032538", Length = "0x1E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv30 = &v31 @ stack_-10_v2;\n\tv173 = *([v30 @ X29_v1+20]);\n\tgoto L_0031;\n\tv55 = *([1EB5418]);\n\tv56 = *([v55 @ X8_v16]);\n\tv57 = \"il2cpp_codegen_initialize_method\"(v56, methodInfo, v59, v60, v61, v62, v63, v64, v39, v38, v40, planeNormal, v3, v5, v65, v66);\n\tv69 = 0 | 1;\n\t*([2026285]) = v69;\nL_0031:\n\tpoint.x = *([v30 @ X29_v1+10]);\n\tpoint.y = *([v30 @ X29_v1+14]);\n\tpoint.z = *([v30 @ X29_v1+18]);\n\tv74 = 0x158A710(&v173 @ V2_v10 (System.Single), 0, v59, v60, v61, v62, v63, v64, *([v30 @ X29_v1+28]), *([v30 @ X29_v1+24]), *([v30 @ X29_v1+20]), planeNormal, planeNormal.y, planeNormal.z, v65, v66);\n\tgoto L_004D;\n\tv84 = *([v80 @ X0_v4+E0]);\n\tv85 = v84 == 0;\n\tv86 = ~v85;\n\tgoto L_004D;\n\tv88 = \"il2cpp_codegen_runtime_class_init\"(v80, v71, v59, v60, v61, v62, v63, v64, v39, v38, v40, planeNormal, v3, v5, v65, v66);\nL_004D:\n\t// 77 MakeStruct v99 @ AGG1032610_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v30 @ X29_v1+28], [v30 @ X29_v1+24], [v30 @ X29_v1+20]\n\tv100 = UnityEngine.Vector3::Dot(planeNormal, v99);\n\tgoto L_005F;\n\tv108 = *([v104 @ X0_v7+E0]);\n\tv109 = v108 == 0;\n\tv110 = ~v109;\n\tif (v110) goto L_005F;\n\tv112 = \"il2cpp_codegen_runtime_class_init\"(v104, v71, v59, v60, v61, v62, v63, v64, v100, v92, v93, v94, v95, v96, v65, v66);\nL_005F:\n\tv118 = UnityEngine.Mathf::Approximately(v100, 0f);\n\tv120 = v118 == 0;\n\tif (v120) goto L_006A;\n\tgoto L_00AF;\nL_006A:\n\tgoto L_0079;\n\tv188 = *([v122 @ X0_v12+E0]);\n\tv189 = v188 == 0;\n\tv190 = ~v189;\n\tif (v190) goto L_0079;\n\tv192 = \"il2cpp_codegen_runtime_class_init\"(v122, v71, v59, v60, v61, v62, v63, v64, v116, v115, v93, v94, v95, v96, v65, v66);\nL_0079:\n\tv200 = UnityEngine.Vector3::Dot(planeNormal, planePoint);\n\t// 134 MakeStruct v137 @ AGG10326B4_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v30 @ X29_v1+10], [v30 @ X29_v1+14], [v30 @ X29_v1+18]\n\tv208 = UnityEngine.Vector3::Dot(planeNormal, v137);\n\tv209 = v200 - v208;\n\tv210 = v209 / v100;\n\t// 142 MakeStruct v134 @ AGG10326D0_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v30 @ X29_v1+28], [v30 @ X29_v1+24], [v30 @ X29_v1+20]\n\tv215 = UnityEngine.Vector3::op_Multiply(v134, v210);\n\t// 153 MakeStruct v131 @ AGG10326F0_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v30 @ X29_v1+10], [v30 @ X29_v1+14], [v30 @ X29_v1+18]\n\tv165 = UnityEngine.Vector3::op_Addition(v131, v215);\n\tpoint.x = v165;\n\tpoint.y = v165.y;\n\tpoint.z = v165.z;\nL_00AF:\n\treturn returnVal1;\n// 127 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool LinePlaneIntersection(Vector3 planePoint, Vector3 planeNormal, Vector3 linePoint, Vector3 lineDirection, out Vector3 point)
		{
			//IL_0022: Expected F4, but got I
			//IL_0240: Expected F4, but got I
			//IL_0255: Expected F4, but got I
			//IL_026a: Expected F4, but got I
			//IL_003c: Expected F4, but got I
			//IL_0051: Expected F4, but got I
			//IL_0066: Expected F4, but got I
			//IL_00e4: Expected F4, but got I
			//IL_00f9: Expected F4, but got I
			//IL_010e: Expected F4, but got I
			//IL_0157: Expected F4, but got I
			//IL_016c: Expected F4, but got I
			//IL_0181: Expected F4, but got I
			//IL_01a7: Expected F4, but got I
			//IL_01bc: Expected F4, but got I
			//IL_01d1: Expected F4, but got I
			point = default(Vector3);
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X29_v1+20]");
			float num = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X29_v1+10]");
			point.x = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X29_v1+14]");
			point.y = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X29_v1+18]");
			point.z = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158A710 (inside UnityEngine.Vector3::get_zero +0x15C)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X29_v1+28]");
			Vector3 rhs = default(Vector3);
			rhs.x = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X29_v1+24]");
			rhs.y = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X29_v1+20]");
			rhs.z = 0f;
			float num2 = Vector3.Dot(planeNormal, rhs);
			if (Mathf.Approximately(num2, 0f))
			{
				return false;
			}
			float num3 = Vector3.Dot(planeNormal, planePoint);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X29_v1+10]");
			Vector3 rhs2 = default(Vector3);
			rhs2.x = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X29_v1+14]");
			rhs2.y = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X29_v1+18]");
			rhs2.z = 0f;
			float num4 = Vector3.Dot(planeNormal, rhs2);
			float num5 = num3 - num4;
			float num6 = num5 / num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X29_v1+28]");
			Vector3 vector = default(Vector3);
			vector.x = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X29_v1+24]");
			vector.y = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X29_v1+20]");
			vector.z = 0f;
			Vector3 vector2 = vector * num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X29_v1+10]");
			Vector3 vector3 = default(Vector3);
			vector3.x = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X29_v1+14]");
			vector3.y = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X29_v1+18]");
			vector3.z = 0f;
			Vector3 vector4 = vector3 + vector2;
			point.x = vector4.x;
			point.y = vector4.y;
			point.z = vector4.z;
			return true;
		}

		[Token(Token = "0x60003E3")]
		[Address(RVA = "0x1032720", Offset = "0x1032720", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = 1f / invMass;\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float InvMassToMass(float invMass)
		{
			return 1f / invMass;
		}

		[Token(Token = "0x60003E4")]
		[Address(RVA = "0x103272C", Offset = "0x103272C", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EDA270]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, mass, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2026286]) = v38;\nL_0019:\n\tgoto L_0023;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0023;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, v21, v22, v23, v24, v25, v26, v27, mass, v28, v29, v30, v31, v32, v33, v34);\nL_0023:\n\tv56 = UnityEngine.Mathf::Max(mass, 1E-05f);\n\treturnVal1 = 1f / v56;\n\treturn returnVal1;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float MassToInvMass(float mass)
		{
			float num = Mathf.Max(mass, 1E-05f);
			return 1f / num;
		}

		[Token(Token = "0x60003E5")]
		[Address(RVA = "0x10327B0", Offset = "0x10327B0", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv28 = &v29 @ stack_-10_v2;\n\tgoto L_0024;\n\tv42 = *([1EFE140]);\n\tv43 = *([v42 @ X8_v14]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, v45, v46, v47, v48, v49, v50, v51, p1, v0, v2, p2, v3, v5, v52, v53);\n\tv57 = 0 | 1;\n\t*([2026287]) = v57;\nL_0024:\n\tp1 = *([v28 @ X29_v1+18]);\n\t*([v28 @ X29_v1-4]) = *([v28 @ X29_v1+18]);\n\tgoto L_003E;\n\tv69 = *([v65 @ X0_v2+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tgoto L_003E;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v65, v45, v46, v47, v48, v49, v50, v51, v59, v0, v2, p2, v3, v5, v52, v53);\nL_003E:\n\tp1 = UnityEngine.Vector3::op_Subtraction(p2, p1);\n\t// 75 MakeStruct v98 @ AGG1032888_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v28 @ X29_v1+10], [v28 @ X29_v1+14], [v28 @ X29_v1-4]\n\tp1 = UnityEngine.Vector3::op_Subtraction(v98, p1);\n\tp1 = UnityEngine.Vector3::Cross(p1, p1);\n\tv120 = 0x158AB88(&p1 @ V0 (UnityEngine.Vector3), 0, v46, v47, v48, v49, v50, v51, p1, p1.y, p1.z, p1, p1.y, p1.z, v52, v53);\n\tgoto L_006F;\n\tv128 = *([v124 @ X0_v9 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv129 = v128 == 0;\n\tv130 = ~v129;\n\tif (v130) goto L_006F;\n\tv132 = \"il2cpp_codegen_runtime_class_init\"(v124, v117, v46, v47, v48, v49, v50, v51, v112, v113, v114, v103, v104, v105, v52, v53);\nL_006F:\n\tv148 = UnityEngine.Mathf::Sqrt(p1);\n\tv138 = v148 - v148;\n\tv141 = v148 ^ v148;\n\tv142 = v148 ^ v138;\n\tv143 = v141 & v142;\n\tv144 = v143 < 0;\n\tv145 = ~v144;\n\tif (v145) goto L_0089;\n\tv147 = 0x6D2F50(UnityEngine.Mathf, 0, v46, v47, v48, v49, v50, v51, p1, p1.y, p1.z, p1, p1.y, p1.z, v52, v53);\nL_0089:\n\treturnVal1 = v148 * 0.5f;\n\treturn returnVal1;\n// 103 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float TriangleArea(Vector3 p1, Vector3 p2, Vector3 p3)
		{
			//IL_014b: Expected O, but got I
			//IL_0033: Expected F4, but got I
			//IL_0048: Expected F4, but got I
			//IL_005d: Expected F4, but got I
			//IL_00c6: Expected O, but got F4
			//IL_00d3: Expected O, but got F4
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ X29_v1+18]");
			Vector3 vector = (Vector3)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ X29_v1+18]");
			_ = 0;
			vector = p2 - p1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ X29_v1+10]");
			Vector3 vector2 = default(Vector3);
			vector2.x = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ X29_v1+14]");
			vector2.y = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ X29_v1-4]");
			vector2.z = 0f;
			vector = vector2 - p1;
			vector = Vector3.Cross(p1, p1);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158AB88 (inside UnityEngine.Vector3::Angle +0x184)");
			float num = Mathf.Sqrt(vector.x);
			float num2 = num - num;
			object obj3 = num ^ num;
			object obj4 = num ^ num2;
			int num3 = (int)((long)(IntPtr)obj3 & (long)(IntPtr)obj4);
			if (num3 < 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2F50 (native sqrtf)");
				num = vector.x;
			}
			return num * 0.5f;
		}

		[Token(Token = "0x60003E6")]
		[Address(RVA = "0x1032920", Offset = "0x1032920", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = principalRadii * 4.1887903f;\n\tv6 = principalRadii.y * v5;\n\treturnVal1 = principalRadii.z * v6;\n\treturn returnVal1;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EllipsoidVolume(Vector3 principalRadii)
		{
			Vector3 vector = default(Vector3);
			float num = vector.x * 4.1887903f;
			float num2 = principalRadii.y * num;
			return principalRadii.z * num2;
		}

		[Token(Token = "0x60003E7")]
		[Address(RVA = "0x1032938", Offset = "0x1032938", Length = "0x23C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0033;\n\tv46 = *([1EDFB98]);\n\tv47 = *([v46 @ X8_v14]);\n\tv48 = \"il2cpp_codegen_initialize_method\"(v47, v49, v50, v51, v52, v53, v54, v55, q1, v0, v2, v3, q2, v4, v6, v7);\n\tv59 = 0 | 1;\n\t*([2026288]) = v59;\nL_0033:\n\tgoto L_003F;\n\tv72 = *([v68 @ X0_v2+E0]);\n\tv73 = v72 == 0;\n\tv74 = ~v73;\n\tgoto L_003F;\n\tv76 = \"il2cpp_codegen_runtime_class_init\"(v68, v49, v50, v51, v52, v53, v54, v55, q1, v0, v2, v3, q2, v4, v6, v7);\nL_003F:\n\tq1 = UnityEngine.Quaternion::Inverse(q1);\n\tq1 = UnityEngine.Quaternion::op_Multiply(q1, q2);\n\tv105 = 0;\n\tv116 = 0x158BA74(&v105 @ stack_-A0_v1, 0, v50, v51, v52, v53, v54, v55, q1.w, q1, q1.y, q1.z, q2, q2.y, q2.z, q2.w);\n\tv119 = 0;\n\tv125 = 0x158BA74(&v119 @ stack_-B0_v1, 0, v50, v51, v52, v53, v54, v55, 1f, 0, 0, 0, q2, q2.y, q2.z, q2.w);\n\tgoto L_0081;\n\tv132 = *([v128 @ X0_v10+E0]);\n\tv133 = v132 == 0;\n\tv134 = ~v133;\n\tif (v134) goto L_0081;\n\tv136 = \"il2cpp_codegen_runtime_class_init\"(v128, v123, v50, v51, v52, v53, v54, v55, v117, v120, v121, v122, v89, v90, v91, v92);\n\tv139 = v113;\n\tv145 = v114;\n\tv143 = v111;\n\tv141 = v112;\nL_0081:\n\t// 129 MakeStruct v160 @ AGG1032A90_0_v1 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), 0, v149 @ stack_-9C, 0, v152 @ stack_-94\n\t// 130 MakeStruct v161 @ AGG1032A90_1_v1 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), 0, v155 @ stack_-AC, 0, v158 @ stack_-A4\n\tv162 = UnityEngine.Vector4::op_Addition(v160, v161);\n\tv171 = 0;\n\tv178 = 0x158BA74(&v171 @ stack_-C0_v1, 0, v50, v51, v52, v53, v54, v55, q1.w, q1, q1.y, q1.z, 0, v155, 0, v158);\n\tv181 = 0;\n\tv187 = 0x158BA74(&v181 @ stack_-D0_v1, 0, v50, v51, v52, v53, v54, v55, 1f, 0, 0, 0, 0, v155, 0, v158);\n\t// 166 MakeStruct v201 @ AGG1032AF0_0_v1 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), 0, v190 @ stack_-BC, 0, v193 @ stack_-B4\n\t// 167 MakeStruct v202 @ AGG1032AF0_1_v1 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), 0, v196 @ stack_-CC, 0, v199 @ stack_-C4\n\tv203 = UnityEngine.Vector4::op_Subtraction(v201, v202);\n\tv213 = 0x158C010(&v203 @ V0_v11 (UnityEngine.Vector4), 0, v50, v51, v52, v53, v54, v55, v203, v203.y, v203.z, v203.w, 0, v196, 0, v199);\n\tv217 = 0x158C010(&v162 @ V0_v7 (UnityEngine.Vector4), 0, v50, v51, v52, v53, v54, v55, v203, v203.y, v203.z, v203.w, 0, v196, 0, v199);\n\tv229 = v203 <= v203;\n\tif (v229) goto L_00DF;\n\tq1 = -q1;\n\tv231 = -q1.y;\n\tv232 = -q1.z;\n\tv233 = -q1.w;\n\tv237 = 0x10CB640(&v235 @ stack_-70_v4 (UnityEngine.Quaternion), 0, v50, v51, v52, v53, v54, v55, q1, v231, v232, v233, 0, v196, 0, v199);\nL_00DF:\n\treturn v246;\n// 176 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Quaternion RestDarboux(Quaternion q1, Quaternion q2)
		{
			//IL_0031: Expected O, but got I4
			//IL_0044: Expected O, but got I4
			//IL_018b: Expected F4, but got O
			//IL_01a6: Expected F4, but got O
			//IL_01c1: Expected F4, but got O
			//IL_01dc: Expected F4, but got O
			//IL_01f6: Expected O, but got I4
			//IL_0209: Expected O, but got I4
			//IL_007b: Expected F4, but got O
			//IL_0096: Expected F4, but got O
			//IL_00b1: Expected F4, but got O
			//IL_00cc: Expected F4, but got O
			//IL_0125: Unsupported input type for neg.
			//IL_0125: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Expected O, but got Unknown
			//IL_0138: Expected O, but got F4
			//IL_0146: Expected O, but got F4
			//IL_0154: Expected O, but got F4
			Quaternion quaternion = Quaternion.Inverse(q1);
			quaternion = q1 * q2;
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA74 (inside UnityEngine.Vector3Int::.cctor +0xA8)");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA74 (inside UnityEngine.Vector3Int::.cctor +0xA8)");
			Quaternion result = q1;
			Vector4 vector = default(Vector4);
			vector.x = 0f;
			object obj3 = default(object);
			vector.y = (float)obj3;
			vector.z = 0f;
			object obj4 = default(object);
			vector.w = (float)obj4;
			Vector4 vector2 = default(Vector4);
			vector2.x = 0f;
			object obj5 = default(object);
			vector2.y = (float)obj5;
			vector2.z = 0f;
			object obj6 = default(object);
			vector2.w = (float)obj6;
			Vector4 vector3 = vector + vector2;
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA74 (inside UnityEngine.Vector3Int::.cctor +0xA8)");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA74 (inside UnityEngine.Vector3Int::.cctor +0xA8)");
			Vector4 vector4 = default(Vector4);
			vector4.x = 0f;
			object obj9 = default(object);
			vector4.y = (float)obj9;
			vector4.z = 0f;
			object obj10 = default(object);
			vector4.w = (float)obj10;
			Vector4 vector5 = default(Vector4);
			vector5.x = 0f;
			object obj11 = default(object);
			vector5.y = (float)obj11;
			vector5.z = 0f;
			object obj12 = default(object);
			vector5.w = (float)obj12;
			Vector4 vector6 = vector4 - vector5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158C010 (inside UnityEngine.Vector4::Magnitude +0x1B4)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158C010 (inside UnityEngine.Vector4::Magnitude +0x1B4)");
			if (vector6.x > vector6.x)
			{
				quaternion = (Quaternion)(0 - q1);
				object obj13 = 0f - q1.y;
				object obj14 = 0f - q1.z;
				object obj15 = 0f - q1.w;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CB640 (inside UnityEngine.QualitySettings::get_activeColorSpace +0x34)");
				Quaternion quaternion2 = default(Quaternion);
				result = quaternion2;
			}
			return result;
		}

		[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x74750C", Offset = "0x74750C")]
		[Token(Token = "0x60003E8")]
		[Address(RVA = "0x1032B74", Offset = "0x1032B74", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1F0FE00]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026289]) = v38;\nL_0016:\n\tv42 = new Obi.ObiUtils+<BilateralInterleaved>d__22();\n\tSystem.Object::.ctor(v42);\n\tv42.<>1__state = 0xFFFFFFFE;\n\tv47 = System.Environment::get_CurrentManagedThreadId();\n\tv42.<>l__initialThreadId = v47;\n\tv42.<>3__count = count;\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static IEnumerable BilateralInterleaved(int count)
		{
			_003CBilateralInterleaved_003Ed__22 _003CBilateralInterleaved_003Ed__23 = new _003CBilateralInterleaved_003Ed__22(-2);
			int currentManagedThreadId = Environment.CurrentManagedThreadId;
			_003CBilateralInterleaved_003Ed__23._003C_003El__initialThreadId = currentManagedThreadId;
			_003CBilateralInterleaved_003Ed__23._003C_003E3__count = count;
			return _003CBilateralInterleaved_003Ed__23;
		}

		[Token(Token = "0x60003E9")]
		[Address(RVA = "0x1032C30", Offset = "0x1032C30", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv28 = &v29 @ stack_-10_v2;\n\tgoto L_002D;\n\tv48 = *([1ECA008]);\n\tv49 = *([v48 @ X8_v9]);\n\tv50 = \"il2cpp_codegen_initialize_method\"(v49, v51, v52, v53, v54, v55, v56, v57, v35, v34, v36, p2, v3, v5, v58, v59);\n\tv63 = 0 | 1;\n\t*([202628A]) = v63;\nL_002D:\n\t*([v28 @ X29_v1-4]) = *([v28 @ X29_v1+18]);\n\t*([v28 @ X29_v1-8]) = *([v28 @ X29_v1+14]);\n\tthrow System.TypeLoadException;\n\tv78 = *([v74 @ X0_v4+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tgoto L_0044;\n\tv82 = \"il2cpp_codegen_runtime_class_init\"(v74, v66, v67, v53, v54, v55, v56, v57, v69, v34, v36, p2, v3, v5, v58, v59);\nL_0044:\n\tv90 = p1;\n\tv91 = UnityEngine.Vector3::op_Multiply(v69, v90, 0);\n\tthrow System.TypeLoadException;\n\tv105 = p2;\n\tv106 = UnityEngine.Vector3::op_Multiply(v91, v105, 0);\n\tv116 = v91;\n\tv117 = v106;\n\tv118 = UnityEngine.Vector3::op_Addition(v116, v117, 0);\n\tthrow System.TypeLoadException;\n\tv143 = v118;\n\tv144 = v133;\n\treturnVal1 = UnityEngine.Vector3::op_Addition(v143, v144, 0);\n\treturn returnVal1;\n// 111 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector3 BarycentricInterpolation(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 coords)
		{
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ X29_v1+18]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ X29_v1+14]");
			_ = 0;
			throw new TypeLoadException();
		}

		[Token(Token = "0x60003EA")]
		[Address(RVA = "0x1032DB4", Offset = "0x1032DB4", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthrow System.TypeLoadException;\n\tthrow System.TypeLoadException;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float BarycentricInterpolation(float p1, float p2, float p3, Vector3 coords)
		{
			throw new TypeLoadException();
		}

		[Token(Token = "0x60003EB")]
		[Address(RVA = "0x1032E44", Offset = "0x1032E44", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthrow System.TypeLoadException;\n\tthrow System.TypeLoadException;\n\tthrow System.TypeLoadException;\n\tv61 = coords * coords;\n\tv62 = coords * coords;\n\tv63 = coords * coords;\n\tv71 = v61 + v62;\n\tv72 = v71 + v63;\n\treturnVal1 = 1f / v72;\n\treturn returnVal1;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float BarycentricExtrapolationScale(Vector3 coords)
		{
			throw new TypeLoadException();
		}

		[Token(Token = "0x60003EC")]
		[Address(RVA = "0x1032F0C", Offset = "0x1032F0C", Length = "0x5D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = &v7 @ stack_-10_v2;\n\tgoto L_0015;\n\tv14 = *([1ED13B0]);\n\tv15 = *([v14 @ X8_v65]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202628B]) = v35;\nL_0015:\n\t// 21 NewArr v40 @ X0_v3 (UnityEngine.Color32[]), typeof(UnityEngine.Color32[]), 26\n\tv42 = &v7 @ stack_-10_v2 - 8;\n\t*([v6 @ X29_v1-8]) = 0;\n\tv48 = 0x1010E50(v42, 0xF0, 0xA3, 0xFF, 0xFF, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv51 = v40.Length == 0;\n\tif (v51) goto L_026F;\n\tv139 = &v7 @ stack_-10_v2 - 0x18;\n\t*([v40 @ X0_v3 (UnityEngine.Color32[])+20]) = *([v6 @ X29_v1-8]);\n\t*([v6 @ X29_v1-18]) = 0;\n\tv145 = 0x1010E50(v139, 0, 0x75, 0xDC, 0xFF, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv558 = v40.Length < 1;\n\tv360 = ~v558;\n\tv335 = v40.Length - 1;\n\tv285 = v335 == 0;\n\tv559 = ~v360;\n\tv160 = v559 | v285;\n\tif (v160) goto L_026F;\n\tv599 = &v7 @ stack_-10_v2 - 0x20;\n\t*([v40 @ X0_v3 (UnityEngine.Color32[])+24]) = *([v6 @ X29_v1-18]);\n\t*([v6 @ X29_v1-20]) = 0;\n\tv508 = 0x1010E50(v599, 0x99, 0x3F, 0, 0xFF, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv600 = v40.Length < 2;\n\tv361 = ~v600;\n\tv336 = v40.Length - 2;\n\tv286 = v336 == 0;\n\tv601 = ~v361;\n\tv161 = v601 | v286;\n\tif (v161) goto L_026F;\n\tv603 = &v7 @ stack_-10_v2 - 0x28;\n\t*([v40 @ X0_v3 (UnityEngine.Color32[])+28]) = *([v6 @ X29_v1-20]);\n\t*([v6 @ X29_v1-28]) = 0;\n\tv509 = 0x1010E50(v603, 0x4C, 0, 0x5C, 0xFF, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv604 = v40.Length < 3;\n\tv362 = ~v604;\n\tv337 = v40.Length - 3;\n\tv287 = v337 == 0;\n\tv605 = ~v362;\n\tv162 = v605 | v287;\n\tif (v162) goto L_026F;\n\tv607 = &v7 @ stack_-10_v2 - 0x30;\n\t*([v40 @ X0_v3 (UnityEngine.Color32[])+2C]) = *([v6 @ X29_v1-28]);\n\t*([v6 @ X29_v1-30]) = 0;\n\tv510 = 0x1010E50(v607, 0x19, 0x19, 0x19, 0xFF, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv608 = v40.Length < 4;\n\tv363 = ~v608;\n\tv338 = v40.Length - 4;\n\tv288 = v338 == 0;\n\tv609 = ~v363;\n\tv163 = v609 | v288;\n\tif (v163) goto L_026F;\n\tv611 = &v7 @ stack_-10_v2 - 0x38;\n\t*([v40 @ X0_v3 (UnityEngine.Color32[])+30]) = *([v6 @ X29_v1-30]);\n\t*([v6 @ X29_v1-38]) = 0;\n\tv511 = 0x1010E50(v611, 0, 0x5C, 0x31, 0xFF, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv612 = v40.Length < 5;\n\tv364 = ~v612;\n\tv339 = v40.Length - 5;\n\tv289 = v339 == 0;\n\tv613 = ~v364;\n\tv164 = v613 | v289;\n\tif (v164) goto L_026F;\n\tv615 = &v7 @ stack_-10_v2 - 0x40;\n\t*([v40 @ X0_v3 (UnityEngine.Color32[])+34]) = *([v6 @ X29_v1-38]);\n\t*([v6 @ X29_v1-40]) = 0;\n\tv512 = 0x1010E50(v615, 0x2B, 0xCE, 0x48, 0xFF, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv616 = v40.Length < 6;\n\tv365 = ~v616;\n\tv340 = v40.Length - 6;\n\tv290 = v340 == 0;\n\tv617 = ~v365;\n\tv165 = v617 | v290;\n\tif (v165) goto L_026F;\n\tv619 = &v7 @ stack_-10_v2 - 0x48;\n\t*([v40 @ X0_v3 (UnityEngine.Color32[])+38]) = *([v6 @ X29_v1-40]);\n\t*([v6 @ X29_v1-48]) = 0;\n\tv513 = 0x1010E50(v619, 0xFF, 0xCC, 0x99, 0xFF, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv620 = v40.Length < 7;\n\tv366 = ~v620;\n\tv341 = v40.Length - 7;\n\tv291 = v341 == 0;\n\tv621 = ~v366;\n\tv166 = v621 | v291;\n\tif (v166) goto L_026F;\n\tv623 = &v7 @ stack_-10_v2 - 0x50;\n\t*([v40 @ X0_v3 (UnityEngine.Color32[])+3C]) = *([v6 @ X29_v1-48]);\n\t*([v6 @ X29_v1-50]) = 0;\n\tv514 = 0x1010E50(v623, 0x80, 0x80, 0x80, 0xFF, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv624 = v40.Length < 8;\n\tv367 = ~v624;\n\tv342 = v40.Length - 8;\n\tv292 = v342 == 0;\n\tv625 = ~v367;\n\tv167 = v625 | v292;\n\tif (v167) goto L_026F;\n\tv627 = &v7 @ stack_-10_v2 - 0x58;\n\t*([v40 @ X0_v3 (UnityEngine.Color32[])+40]) = *([v6 @ X29_v1-50]);\n\t*([v6 @ X29_v1-58]) = 0;\n\tv515 = 0x1010E50(v627, 0x94, 0xFF, 0xB5, 0xFF, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv628 = v40.Length < 9;\n\tv368 = ~v628;\n\tv343 = v40.Length - 9;\n\tv293 = v343 == 0;\n\tv629 = ~v368;\n\tv168 = v629 | v293;\n\tif (v168) goto L_026F;\n\tv631 = &v7 @ stack_-10_v2 - 0x60;\n\t*([v40 @ X0_v3 (UnityEngine.Color32[])+44]) = *([v6 @ X29_v1-58]);\n\t*([v6 @ X29_v1-60]) = 0;\n\tv516 = 0x1010E50(v631, 0x8F, 0x7C, 0, 0xFF, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv632 = v40.Length < 0xA;\n\tv369 = ~v632;\n\tv344 = v40.Length - 0xA;\n\tv294 = v344 == 0;\n\tv633 = ~v369;\n\tv169 = v633 | v294;\n\tif (v169) goto L_026F;\n\tv635 = &v7 @ stack_-10_v2 - 0x68;\n\t*([v40 @ X0_v3 (UnityEngine.Color32[])+48]) = *([v6 @ X29_v1-60]);\n\t*([v6 @ X29_v1-68]) = 0;\n\tv517 = 0x1010E50(v635, 0x9D, 0xCC, 0, 0xFF, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv636 = v40.Length < 0xB;\n\tv370 = ~v636;\n\tv345 = v40.Length - 0xB;\n\tv295 = v345 == 0;\n\tv637 = ~v370;\n\tv170 = v637 | v295;\n\tif (v170) goto L_026F;\n\t*([v40 @ X0_v3 (UnityEngine.Color32[])+4C]) = *([v6 @ X29_v1-68]);\n\tv159 = 0;\n\tv518 = 0x1010E50(&v159 @ stack_-80_v3, 0xC2, 0, 0x88, 0xFF, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv640 = v40.Length < 0xC;\n\tv371 = ~v640;\n\tv346 = v40.Length - 0xC;\n\tv296 = v346 == 0;\n\tv641 = ~v371;\n\tv171 = v641 | v296;\n\tif (v171) goto L_026F;\n\t*([v40 @ X0_v3 (UnityEngine.Color32[])+50]) = 0;\n\tv158 = 0;\n\tv519 = 0x1010E50(&v158 @ stack_-88_v3, 0, 0x33, 0x80, 0xFF, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv644 = v40.Length < 0xD;\n\tv372 = ~v644;\n\tv347 = v40.Length - 0xD;\n\tv297 = v347 == 0;\n\tv645 = ~v372;\n\tv172 = v645 | v297;\n\tif (v172) goto L_026F;\n\t*([v40 @ X0_v3 (UnityEngine.Color32[])+54]) = 0;\n\tv157 = 0;\n\tv520 = 0x1010E50(&v157 @ stack_-90_v3, 0xFF, 0xA4, 5, 0xFF, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv648 = v40.Length < 0xE;\n\tv373 = ~v648;\n\tv348 = v40.Length - 0xE;\n\tv298 = v348 == 0;\n\tv649 = ~v373;\n\tv173 = v649 | v298;\n\tif (v173) goto L_026F;\n\t*([v40 @ X0_v3 (UnityEngine.Color32[])+58]) = 0;\n\tv156 = 0;\n\tv521 = 0x1010E50(&v156 @ stack_-98_v3, 0xFF, 0xA8, 0xBB, 0xFF, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv652 = v40.Length < 0xF;\n\tv374 = ~v652;\n\tv349 = v40.Length - 0xF;\n\tv299 = v349 == 0;\n\tv653 = ~v374;\n\tv174 = v653 | v299;\n\tif (v174) goto L_026F;\n\t*([v40 @ X0_v3 (UnityEngine.Color32[])+5C]) = 0;\n\tv155 = 0;\n\tv522 = 0x1010E50(&v155 @ stack_-A0_v3, 0x42, 0x66, 0, 0xFF, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv656 = v40.Length < 0x10;\n\tv375 = ~v656;\n\tv350 = v40.Length - 0x10;\n\tv300 = v350 == 0;\n\tv657 = ~v375;\n\tv175 = v657 | v300;\n\tif (v175) goto L_026F;\n\t*([v40 @ X0_v3 (UnityEngine.Color32[])+60]) = 0;\n\tv154 = 0;\n\tv523 = 0x1010E50(&v154 @ stack_-A8_v3, 0xFF, 0, 0x10, 0xFF, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv660 = v40.Length < 0x11;\n\tv376 = ~v660;\n\tv351 = v40.Length - 0x11;\n\tv301 = v351 == 0;\n\tv661 = ~v376;\n\tv176 = v661 | v301;\n\tif (v176) goto L_026F;\n\t*([v40 @ X0_v3 (UnityEngine.Color32[])+64]) = 0;\n\tv153 = 0;\n\tv524 = 0x1010E50(&v153 @ stack_-B0_v3, 0x5E, 0xF1, 0xF2, 0xFF, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv664 = v40.Length < 0x12;\n\tv377 = ~v664;\n\tv352 = v40.Length - 0x12;\n\tv302 = v352 == 0;\n\tv665 = ~v377;\n\tv177 = v665 | v302;\n\tif (v177) goto L_026F;\n\t*([v40 @ X0_v3 (UnityEngine.Color32[])+68]) = 0;\n\tv152 = 0;\n\tv525 = 0x1010E50(&v152 @ stack_-B8_v3, 0, 0x99, 0x8F, 0xFF, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv668 = v40.Length < 0x13;\n\tv378 = ~v668;\n\tv353 = v40.Length - 0x13;\n\tv303 = v353 == 0;\n\tv669 = ~v378;\n\tv178 = v669 | v303;\n\tif (v178) goto L_026F;\n\t*([v40 @ X0_v3 (UnityEngine.Color32[])+6C]) = 0;\n\tv151 = 0;\n\tv526 = 0x1010E50(&v151 @ stack_-C0_v3, 0xE0, 0xFF, 0x66, 0xFF, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv672 = v40.Length < 0x14;\n\tv379 = ~v672;\n\tv354 = v40.Length - 0x14;\n\tv304 = v354 == 0;\n\tv673 = ~v379;\n\tv179 = v673 | v304;\n\tif (v179) goto L_026F;\n\t*([v40 @ X0_v3 (UnityEngine.Color32[])+70]) = 0;\n\tv150 = 0;\n\tv527 = 0x1010E50(&v150 @ stack_-C8_v3, 0x74, 0xA, 0xFF, 0xFF, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv676 = v40.Length < 0x15;\n\tv380 = ~v676;\n\tv355 = v40.Length - 0x15;\n\tv305 = v355 == 0;\n\tv677 = ~v380;\n\tv180 = v677 | v305;\n\tif (v180) goto L_026F;\n\t*([v40 @ X0_v3 (UnityEngine.Color32[])+74]) = 0;\n\tv149 = 0;\n\tv528 = 0x1010E50(&v149 @ stack_-D0_v3, 0x99, 0, 0, 0xFF, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv680 = v40.Length < 0x16;\n\tv381 = ~v680;\n\tv35\n// ... truncated")]
		static ObiUtils()
		{
			//IL_0d29: Expected O, but got I
			//IL_003b: Expected O, but got I
			//IL_0084: Expected O, but got I4
			//IL_00c8: Expected O, but got I
			//IL_0111: Expected O, but got I4
			//IL_0155: Expected O, but got I
			//IL_019e: Expected O, but got I4
			//IL_01e2: Expected O, but got I
			//IL_022b: Expected O, but got I4
			//IL_026f: Expected O, but got I
			//IL_02b8: Expected O, but got I4
			//IL_02fc: Expected O, but got I
			//IL_0345: Expected O, but got I4
			//IL_0389: Expected O, but got I
			//IL_03d2: Expected O, but got I4
			//IL_0416: Expected O, but got I
			//IL_045f: Expected O, but got I4
			//IL_04a3: Expected O, but got I
			//IL_04ec: Expected O, but got I4
			//IL_0530: Expected O, but got I
			//IL_0579: Expected O, but got I4
			//IL_05bd: Expected O, but got I
			//IL_0606: Expected O, but got I4
			//IL_0651: Expected O, but got I4
			//IL_0687: Expected O, but got I4
			//IL_06cb: Expected O, but got I4
			//IL_0701: Expected O, but got I4
			//IL_0745: Expected O, but got I4
			//IL_077b: Expected O, but got I4
			//IL_07bf: Expected O, but got I4
			//IL_07f5: Expected O, but got I4
			//IL_0839: Expected O, but got I4
			//IL_086f: Expected O, but got I4
			//IL_08b3: Expected O, but got I4
			//IL_08e9: Expected O, but got I4
			//IL_092d: Expected O, but got I4
			//IL_0963: Expected O, but got I4
			//IL_09a7: Expected O, but got I4
			//IL_09dd: Expected O, but got I4
			//IL_0a21: Expected O, but got I4
			//IL_0a57: Expected O, but got I4
			//IL_0a9b: Expected O, but got I4
			//IL_0ad1: Expected O, but got I4
			//IL_0b15: Expected O, but got I4
			//IL_0b4b: Expected O, but got I4
			//IL_0b8f: Expected O, but got I4
			//IL_0bc5: Expected O, but got I4
			//IL_0c09: Expected O, but got I4
			//IL_0c3f: Expected O, but got I4
			//IL_0c83: Expected O, but got I4
			//IL_0cb9: Expected O, but got I4
			object obj2 = default(object);
			object obj = obj2;
			Color32[] array = new Color32[26];
			object obj3 = (long)(IntPtr)obj2 - 8L;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1010E50 (inside UnityEngine.Color::op_Implicit +0x4)");
			if (array.Length != 0)
			{
				object obj4 = (long)(IntPtr)obj2 - 24L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ X29_v1-8]");
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1010E50 (inside UnityEngine.Color::op_Implicit +0x4)");
				bool flag = array.Length < 1;
				bool flag2 = !flag;
				object obj5 = array.Length - 1;
				bool flag3 = obj5 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					object obj6 = (long)(IntPtr)obj2 - 32L;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ X29_v1-18]");
					_ = 0;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1010E50 (inside UnityEngine.Color::op_Implicit +0x4)");
					bool flag5 = array.Length < 2;
					bool flag6 = !flag5;
					object obj7 = array.Length - 2;
					bool flag7 = obj7 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						object obj8 = (long)(IntPtr)obj2 - 40L;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ X29_v1-20]");
						_ = 0;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1010E50 (inside UnityEngine.Color::op_Implicit +0x4)");
						bool flag9 = array.Length < 3;
						bool flag10 = !flag9;
						object obj9 = array.Length - 3;
						bool flag11 = obj9 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							object obj10 = (long)(IntPtr)obj2 - 48L;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ X29_v1-28]");
							_ = 0;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1010E50 (inside UnityEngine.Color::op_Implicit +0x4)");
							bool flag13 = array.Length < 4;
							bool flag14 = !flag13;
							object obj11 = array.Length - 4;
							bool flag15 = obj11 == null;
							bool flag16 = !flag14;
							if (!(flag16 || flag15))
							{
								object obj12 = (long)(IntPtr)obj2 - 56L;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ X29_v1-30]");
								_ = 0;
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1010E50 (inside UnityEngine.Color::op_Implicit +0x4)");
								bool flag17 = array.Length < 5;
								bool flag18 = !flag17;
								object obj13 = array.Length - 5;
								bool flag19 = obj13 == null;
								bool flag20 = !flag18;
								if (!(flag20 || flag19))
								{
									object obj14 = (long)(IntPtr)obj2 - 64L;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ X29_v1-38]");
									_ = 0;
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1010E50 (inside UnityEngine.Color::op_Implicit +0x4)");
									bool flag21 = array.Length < 6;
									bool flag22 = !flag21;
									object obj15 = array.Length - 6;
									bool flag23 = obj15 == null;
									bool flag24 = !flag22;
									if (!(flag24 || flag23))
									{
										object obj16 = (long)(IntPtr)obj2 - 72L;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ X29_v1-40]");
										_ = 0;
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1010E50 (inside UnityEngine.Color::op_Implicit +0x4)");
										bool flag25 = array.Length < 7;
										bool flag26 = !flag25;
										object obj17 = array.Length - 7;
										bool flag27 = obj17 == null;
										bool flag28 = !flag26;
										if (!(flag28 || flag27))
										{
											object obj18 = (long)(IntPtr)obj2 - 80L;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ X29_v1-48]");
											_ = 0;
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1010E50 (inside UnityEngine.Color::op_Implicit +0x4)");
											bool flag29 = array.Length < 8;
											bool flag30 = !flag29;
											object obj19 = array.Length - 8;
											bool flag31 = obj19 == null;
											bool flag32 = !flag30;
											if (!(flag32 || flag31))
											{
												object obj20 = (long)(IntPtr)obj2 - 88L;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ X29_v1-50]");
												_ = 0;
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1010E50 (inside UnityEngine.Color::op_Implicit +0x4)");
												bool flag33 = array.Length < 9;
												bool flag34 = !flag33;
												object obj21 = array.Length - 9;
												bool flag35 = obj21 == null;
												bool flag36 = !flag34;
												if (!(flag36 || flag35))
												{
													object obj22 = (long)(IntPtr)obj2 - 96L;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ X29_v1-58]");
													_ = 0;
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1010E50 (inside UnityEngine.Color::op_Implicit +0x4)");
													bool flag37 = array.Length < 10;
													bool flag38 = !flag37;
													object obj23 = array.Length - 10;
													bool flag39 = obj23 == null;
													bool flag40 = !flag38;
													if (!(flag40 || flag39))
													{
														object obj24 = (long)(IntPtr)obj2 - 104L;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ X29_v1-60]");
														_ = 0;
														_ = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1010E50 (inside UnityEngine.Color::op_Implicit +0x4)");
														bool flag41 = array.Length < 11;
														bool flag42 = !flag41;
														object obj25 = array.Length - 11;
														bool flag43 = obj25 == null;
														bool flag44 = !flag42;
														if (!(flag44 || flag43))
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ X29_v1-68]");
															_ = 0;
															object obj26 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1010E50 (inside UnityEngine.Color::op_Implicit +0x4)");
															bool flag45 = array.Length < 12;
															bool flag46 = !flag45;
															object obj27 = array.Length - 12;
															bool flag47 = obj27 == null;
															bool flag48 = !flag46;
															if (!(flag48 || flag47))
															{
																_ = 0;
																object obj28 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1010E50 (inside UnityEngine.Color::op_Implicit +0x4)");
																bool flag49 = array.Length < 13;
																bool flag50 = !flag49;
																object obj29 = array.Length - 13;
																bool flag51 = obj29 == null;
																bool flag52 = !flag50;
																if (!(flag52 || flag51))
																{
																	_ = 0;
																	object obj30 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1010E50 (inside UnityEngine.Color::op_Implicit +0x4)");
																	bool flag53 = array.Length < 14;
																	bool flag54 = !flag53;
																	object obj31 = array.Length - 14;
																	bool flag55 = obj31 == null;
																	bool flag56 = !flag54;
																	if (!(flag56 || flag55))
																	{
																		_ = 0;
																		object obj32 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1010E50 (inside UnityEngine.Color::op_Implicit +0x4)");
																		bool flag57 = array.Length < 15;
																		bool flag58 = !flag57;
																		object obj33 = array.Length - 15;
																		bool flag59 = obj33 == null;
																		bool flag60 = !flag58;
																		if (!(flag60 || flag59))
																		{
																			_ = 0;
																			object obj34 = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1010E50 (inside UnityEngine.Color::op_Implicit +0x4)");
																			bool flag61 = array.Length < 16;
																			bool flag62 = !flag61;
																			object obj35 = array.Length - 16;
																			bool flag63 = obj35 == null;
																			bool flag64 = !flag62;
																			if (!(flag64 || flag63))
																			{
																				_ = 0;
																				object obj36 = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1010E50 (inside UnityEngine.Color::op_Implicit +0x4)");
																				bool flag65 = array.Length < 17;
																				bool flag66 = !flag65;
																				object obj37 = array.Length - 17;
																				bool flag67 = obj37 == null;
																				bool flag68 = !flag66;
																				if (!(flag68 || flag67))
																				{
																					_ = 0;
																					object obj38 = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1010E50 (inside UnityEngine.Color::op_Implicit +0x4)");
																					bool flag69 = array.Length < 18;
																					bool flag70 = !flag69;
																					object obj39 = array.Length - 18;
																					bool flag71 = obj39 == null;
																					bool flag72 = !flag70;
																					if (!(flag72 || flag71))
																					{
																						_ = 0;
																						object obj40 = 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1010E50 (inside UnityEngine.Color::op_Implicit +0x4)");
																						bool flag73 = array.Length < 19;
																						bool flag74 = !flag73;
																						object obj41 = array.Length - 19;
																						bool flag75 = obj41 == null;
																						bool flag76 = !flag74;
																						if (!(flag76 || flag75))
																						{
																							_ = 0;
																							object obj42 = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1010E50 (inside UnityEngine.Color::op_Implicit +0x4)");
																							bool flag77 = array.Length < 20;
																							bool flag78 = !flag77;
																							object obj43 = array.Length - 20;
																							bool flag79 = obj43 == null;
																							bool flag80 = !flag78;
																							if (!(flag80 || flag79))
																							{
																								_ = 0;
																								object obj44 = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1010E50 (inside UnityEngine.Color::op_Implicit +0x4)");
																								bool flag81 = array.Length < 21;
																								bool flag82 = !flag81;
																								object obj45 = array.Length - 21;
																								bool flag83 = obj45 == null;
																								bool flag84 = !flag82;
																								if (!(flag84 || flag83))
																								{
																									_ = 0;
																									object obj46 = 0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1010E50 (inside UnityEngine.Color::op_Implicit +0x4)");
																									bool flag85 = array.Length < 22;
																									bool flag86 = !flag85;
																									object obj47 = array.Length - 22;
																									bool flag87 = obj47 == null;
																									bool flag88 = !flag86;
																									if (!(flag88 || flag87))
																									{
																										_ = 0;
																										object obj48 = 0;
																										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1010E50 (inside UnityEngine.Color::op_Implicit +0x4)");
																										bool flag89 = array.Length < 23;
																										bool flag90 = !flag89;
																										object obj49 = array.Length - 23;
																										bool flag91 = obj49 == null;
																										bool flag92 = !flag90;
																										if (!(flag92 || flag91))
																										{
																											_ = 0;
																											object obj50 = 0;
																											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1010E50 (inside UnityEngine.Color::op_Implicit +0x4)");
																											bool flag93 = array.Length < 24;
																											bool flag94 = !flag93;
																											object obj51 = array.Length - 24;
																											bool flag95 = obj51 == null;
																											bool flag96 = !flag94;
																											if (!(flag96 || flag95))
																											{
																												_ = 0;
																												object obj52 = 0;
																												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1010E50 (inside UnityEngine.Color::op_Implicit +0x4)");
																												bool flag97 = array.Length < 25;
																												bool flag98 = !flag97;
																												object obj53 = array.Length - 25;
																												bool flag99 = obj53 == null;
																												bool flag100 = !flag98;
																												if (!(flag100 || flag99))
																												{
																													_ = 0;
																													colorAlphabet = array;
																													return;
																												}
																											}
																										}
																									}
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}
	}
}
