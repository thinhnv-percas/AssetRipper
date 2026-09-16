using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile.ManifestGenerator.Elements
{
	[Serializable]
	[Token(Token = "0x200009A")]
	public class ApplicationElement : AndroidManifestElement
	{
		[CompilerGenerated]
		[Token(Token = "0x2000154")]
		private sealed class _003Cget_ParentStyles_003Ed__2 : IEnumerable<AndroidManifestElementStyles>, IEnumerable, IEnumerator<AndroidManifestElementStyles>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400058C")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x400058D")]
			[FieldOffset(Offset = "0x14")]
			private AndroidManifestElementStyles _003C_003E2__current;

			[Token(Token = "0x400058E")]
			[FieldOffset(Offset = "0x18")]
			internal int _003C_003El__initialThreadId;

			[Token(Token = "0x17000293")]
			AndroidManifestElementStyles IEnumerator<AndroidManifestElementStyles>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000A66")]
				[Address(RVA = "0xB598EC", Offset = "0xB598EC", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000294")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000A68")]
				[Address(RVA = "0xB59958", Offset = "0xB59958", Length = "0x64")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EE2E10]);\n\tv19 = *([v18 @ X8_v5]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022812]) = v38;\nL_0014:\n\tv40 = this.<>2__current;\n\t// 25 Box returnVal1 @ X0_v3 (System.Object), typeof(EasyMobile.ManifestGenerator.Elements.AndroidManifestElementStyles), &v40 @ X8_v3 (EasyMobile.ManifestGenerator.Elements.AndroidManifestElementStyles)\n\treturn returnVal1;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					AndroidManifestElementStyles androidManifestElementStyles = _003C_003E2__current;
					return androidManifestElementStyles;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A63")]
			[Address(RVA = "0xB59134", Offset = "0xB59134", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\tv16 = System.Environment::get_CurrentManagedThreadId();\n\tthis.<>l__initialThreadId = v16;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003Cget_ParentStyles_003Ed__2(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A64")]
			[Address(RVA = "0xB598AC", Offset = "0xB598AC", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000A65")]
			[Address(RVA = "0xB598B0", Offset = "0xB598B0", Length = "0x3C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = this.<>1__state == 1;\n\tif (v7) goto L_FFFFFFFF;\n\tv12 = this.<>1__state == 0;\n\tv13 = ~v12;\n\tif (v13) goto L_0018;\n\tthis.<>1__state = 0xFFFF000AFFFFFFFF;\n\tgoto L_0016;\nL_0016:\n\tthis.<>1__state = v24;\nL_0018:\n\treturn v21;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				//IL_0061: Expected I4, but got I8
				bool result;
				int num;
				int num2;
				if (_003C_003E1__state != 1)
				{
					bool flag = _003C_003E1__state == 0;
					bool flag2 = !flag;
					result = false;
					if (flag2)
					{
						goto IL_008f;
					}
					_003C_003E1__state = -1;
					num = 1;
					num2 = 1;
				}
				else
				{
					num = 0;
					num2 = -1;
				}
				_003C_003E1__state = num2;
				result = (byte)num != 0;
				goto IL_008f;
				IL_008f:
				return result;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A67")]
			[Address(RVA = "0xB598F4", Offset = "0xB598F4", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EC2508]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([2022811]) = v34;\nL_0014:\n\tv38 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw new TypeLoadException();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A69")]
			[Address(RVA = "0xB599BC", Offset = "0xB599BC", Length = "0x98")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EACAC0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022813]) = v38;\nL_0014:\n\tv40 = this.<>1__state + 2;\n\tv42 = v40 == 0;\n\tv45 = ~v42;\n\tif (v45) goto L_002E;\n\tv48 = System.Environment::get_CurrentManagedThreadId();\n\tv50 = this.<>l__initialThreadId != v48;\n\tif (v50) goto L_002E;\n\tthis.<>1__state = 0;\n\tgoto L_003C;\nL_002E:\n\tv76 = new EasyMobile.ManifestGenerator.Elements.ApplicationElement+<get_ParentStyles>d__2();\n\tSystem.Object::.ctor(v76);\n\tv76.<>1__state = 0;\n\tv81 = System.Environment::get_CurrentManagedThreadId();\n\tv76.<>l__initialThreadId = v81;\nL_003C:\n\treturn v93;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			IEnumerator<AndroidManifestElementStyles> IEnumerable<AndroidManifestElementStyles>.GetEnumerator()
			{
				if (_003C_003E1__state + 2 == 0)
				{
					int currentManagedThreadId = Environment.CurrentManagedThreadId;
					if (_003C_003El__initialThreadId == currentManagedThreadId)
					{
						_003C_003E1__state = 0;
						return this;
					}
				}
				_003Cget_ParentStyles_003Ed__2 _003Cget_ParentStyles_003Ed__3 = null;
				_003Cget_ParentStyles_003Ed__3._003C_003E1__state = 0;
				int currentManagedThreadId2 = Environment.CurrentManagedThreadId;
				_003Cget_ParentStyles_003Ed__3._003C_003El__initialThreadId = currentManagedThreadId2;
				return _003Cget_ParentStyles_003Ed__3;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A6A")]
			[Address(RVA = "0xB59A54", Offset = "0xB59A54", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = EasyMobile.ManifestGenerator.Elements.ApplicationElement+<get_ParentStyles>d__2::System.Collections.Generic.IEnumerable<EasyMobile.ManifestGenerator.Elements.AndroidManifestElementStyles>.GetEnumerator(this);\n\treturn returnVal1;\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<AndroidManifestElementStyles>)this).GetEnumerator();
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000155")]
		private sealed class _003Cget_ChildStyles_003Ed__4 : IEnumerable<AndroidManifestElementStyles>, IEnumerable, IEnumerator<AndroidManifestElementStyles>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400058F")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x4000590")]
			[FieldOffset(Offset = "0x14")]
			private AndroidManifestElementStyles _003C_003E2__current;

			[Token(Token = "0x4000591")]
			[FieldOffset(Offset = "0x18")]
			internal int _003C_003El__initialThreadId;

			[Token(Token = "0x17000295")]
			AndroidManifestElementStyles IEnumerator<AndroidManifestElementStyles>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000A6E")]
				[Address(RVA = "0xB59740", Offset = "0xB59740", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000296")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000A70")]
				[Address(RVA = "0xB597AC", Offset = "0xB597AC", Length = "0x64")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EE2AC8]);\n\tv19 = *([v18 @ X8_v5]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202280F]) = v38;\nL_0014:\n\tv40 = this.<>2__current;\n\t// 25 Box returnVal1 @ X0_v3 (System.Object), typeof(EasyMobile.ManifestGenerator.Elements.AndroidManifestElementStyles), &v40 @ X8_v3 (EasyMobile.ManifestGenerator.Elements.AndroidManifestElementStyles)\n\treturn returnVal1;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					AndroidManifestElementStyles androidManifestElementStyles = _003C_003E2__current;
					return androidManifestElementStyles;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A6B")]
			[Address(RVA = "0xB591DC", Offset = "0xB591DC", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\tv16 = System.Environment::get_CurrentManagedThreadId();\n\tthis.<>l__initialThreadId = v16;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003Cget_ChildStyles_003Ed__4(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A6C")]
			[Address(RVA = "0xB596AC", Offset = "0xB596AC", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000A6D")]
			[Address(RVA = "0xB596B0", Offset = "0xB596B0", Length = "0x90")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.<>1__state;\n\tv3 = this.<>1__state < 7;\n\tv4 = ~v3;\n\tv5 = this.<>1__state - 7;\n\tv7 = v5 == 0;\n\tv12 = ~v7;\n\tv13 = v4 & v12;\n\tif (v13) goto L_002E;\n\tv15 = 0x1819000 + 0x7E4;\n\tv19 = *([v15 @ X10_v2 (System.Int32)+v0 @ X9_v1 (System.Int32)*4]) + v15;\n\t// 21 IndirectJump v19 @ X12_v2, this @ X0 (EasyMobile.ManifestGenerator.Elements.ApplicationElement+<get_ChildStyles>d__4), this @ X0 (EasyMobile.ManifestGenerator.Elements.ApplicationElement+<get_ChildStyles>d__4), methodInfo @ X1 (Il2CppMethodInfo), v22 @ X2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tX9 = 0 | 1;\n\tX10 = 0 | 2;\n\tgoto L_0027;\n\tX9 = 0 | 3;\n\tX10 = 0xB;\n\tgoto L_0027;\n\tX9 = 0 | 4;\n\tX10 = 0x12;\n\tgoto L_0027;\n\tX9 = 5;\n\tX10 = 0x11;\n\tgoto L_0027;\n\tX9 = 0 | 6;\n\tX10 = 0 | 0x10;\n\tgoto L_0027;\n\tX9 = 0 | 7;\n\tX10 = 0x17;\nL_0027:\n\tX8 = 0xFFFFFFFF;\n\t*([X0+10]) = X8;\n\t*([X0+14]) = X10;\n\tX8 = 0 | 1;\n\tX11 = X9;\n\t*([X0+10]) = X11;\nL_002E:\n\treturn 0;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				//IL_008f: Expected O, but got I
				int num = _003C_003E1__state;
				bool flag = _003C_003E1__state < 7;
				bool flag2 = !flag;
				int num2 = _003C_003E1__state - 7;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					int num3 = 25268224 + 2020;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ X10_v2 (System.Int32)+v0 @ X9_v1 (System.Int32)*4]");
					object obj = 0L + (long)num3;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v19 @ X12_v2 (should have been resolved before IL gen)");
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A6F")]
			[Address(RVA = "0xB59748", Offset = "0xB59748", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EBA168]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([202280E]) = v34;\nL_0014:\n\tv38 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw new TypeLoadException();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A71")]
			[Address(RVA = "0xB59810", Offset = "0xB59810", Length = "0x98")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1ED4A00]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022810]) = v38;\nL_0014:\n\tv40 = this.<>1__state + 2;\n\tv42 = v40 == 0;\n\tv45 = ~v42;\n\tif (v45) goto L_002E;\n\tv48 = System.Environment::get_CurrentManagedThreadId();\n\tv50 = this.<>l__initialThreadId != v48;\n\tif (v50) goto L_002E;\n\tthis.<>1__state = 0;\n\tgoto L_003C;\nL_002E:\n\tv76 = new EasyMobile.ManifestGenerator.Elements.ApplicationElement+<get_ChildStyles>d__4();\n\tSystem.Object::.ctor(v76);\n\tv76.<>1__state = 0;\n\tv81 = System.Environment::get_CurrentManagedThreadId();\n\tv76.<>l__initialThreadId = v81;\nL_003C:\n\treturn v93;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			IEnumerator<AndroidManifestElementStyles> IEnumerable<AndroidManifestElementStyles>.GetEnumerator()
			{
				if (_003C_003E1__state + 2 == 0)
				{
					int currentManagedThreadId = Environment.CurrentManagedThreadId;
					if (_003C_003El__initialThreadId == currentManagedThreadId)
					{
						_003C_003E1__state = 0;
						return this;
					}
				}
				_003Cget_ChildStyles_003Ed__4 _003Cget_ChildStyles_003Ed__5 = null;
				_003Cget_ChildStyles_003Ed__5._003C_003E1__state = 0;
				int currentManagedThreadId2 = Environment.CurrentManagedThreadId;
				_003Cget_ChildStyles_003Ed__5._003C_003El__initialThreadId = currentManagedThreadId2;
				return _003Cget_ChildStyles_003Ed__5;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A72")]
			[Address(RVA = "0xB598A8", Offset = "0xB598A8", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = EasyMobile.ManifestGenerator.Elements.ApplicationElement+<get_ChildStyles>d__4::System.Collections.Generic.IEnumerable<EasyMobile.ManifestGenerator.Elements.AndroidManifestElementStyles>.GetEnumerator(this);\n\treturn returnVal1;\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<AndroidManifestElementStyles>)this).GetEnumerator();
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000156")]
		private sealed class _003Cget_AllAvailableAttributes_003Ed__6 : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000592")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x4000593")]
			[FieldOffset(Offset = "0x18")]
			private string _003C_003E2__current;

			[Token(Token = "0x4000594")]
			[FieldOffset(Offset = "0x20")]
			internal int _003C_003El__initialThreadId;

			[Token(Token = "0x17000297")]
			string IEnumerator<string>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000A76")]
				[Address(RVA = "0xB5959C", Offset = "0xB5959C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000298")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000A78")]
				[Address(RVA = "0xB59608", Offset = "0xB59608", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A73")]
			[Address(RVA = "0xB59284", Offset = "0xB59284", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\tv16 = System.Environment::get_CurrentManagedThreadId();\n\tthis.<>l__initialThreadId = v16;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003Cget_AllAvailableAttributes_003Ed__6(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A74")]
			[Address(RVA = "0xB592BC", Offset = "0xB592BC", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000A75")]
			[Address(RVA = "0xB592C0", Offset = "0xB592C0", Length = "0x2DC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EC9610]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202280B]) = v38;\nL_0013:\n\tv39 = this.<>1__state;\n\tv41 = this.<>1__state < 0x26;\n\tv42 = ~v41;\n\tv43 = this.<>1__state - 0x26;\n\tv45 = v43 == 0;\n\tv50 = ~v45;\n\tv51 = v42 & v50;\n\tif (v51) goto L_00C9;\n\tv53 = 0x1819000 + 0x748;\n\tv57 = *([v53 @ X9_v2 (System.Int32)+v39 @ X8_v3 (System.Int32)*4]) + v53;\n\t// 41 IndirectJump v57 @ X11_v2, 0, 0, methodInfo @ X1 (Il2CppMethodInfo), v22 @ X2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tX9 = *([1EB8080]);\n\tX8 = 0 | 1;\n\tgoto L_00BD;\n\tX9 = *([1EC20C8]);\n\tX8 = 0 | 3;\n\tgoto L_00BD;\n\tX9 = *([1EE3428]);\n\tX8 = 0 | 4;\n\tgoto L_00BD;\n\tX9 = *([1ECBD20]);\n\tX8 = 5;\n\tgoto L_00BD;\n\tX9 = *([1ECC190]);\n\tX8 = 0 | 6;\n\tgoto L_00BD;\n\tX9 = *([1EF29D8]);\n\tX8 = 0 | 7;\n\tgoto L_00BD;\n\tX9 = *([1F0ADD8]);\n\tX8 = 0 | 8;\n\tgoto L_00BD;\n\tX9 = *([1F0AAA0]);\n\tX8 = 9;\n\tgoto L_00BD;\n\tX9 = *([1EAD528]);\n\tX8 = 0xA;\n\tgoto L_00BD;\n\tX9 = *([1EDA4A0]);\n\tX8 = 0xB;\n\tgoto L_00BD;\n\tX9 = *([1ED8390]);\n\tX8 = 0 | 0xC;\n\tgoto L_00BD;\n\tX9 = *([1EAE028]);\n\tX8 = 0xD;\n\tgoto L_00BD;\n\tX9 = *([1EA6B20]);\n\tX8 = 0 | 0xE;\n\tgoto L_00BD;\n\tX9 = *([1F05658]);\n\tX8 = 0 | 0xF;\n\tgoto L_00BD;\n\tX9 = *([1F08FC0]);\n\tX8 = 0 | 0x10;\n\tgoto L_00BD;\n\tX9 = *([1F0A7B0]);\n\tX8 = 0x11;\n\tgoto L_00BD;\n\tX9 = *([1EF18A0]);\n\tX8 = 0x12;\n\tgoto L_00BD;\n\tX9 = *([1F06168]);\n\tX8 = 0x13;\n\tgoto L_00BD;\n\tX9 = *([1EA4618]);\n\tX8 = 0x14;\n\tgoto L_00BD;\n\tX9 = *([1ECC008]);\n\tX8 = 0x15;\n\tgoto L_00BD;\n\tX9 = *([1EAF158]);\n\tX8 = 0x16;\n\tgoto L_00BD;\n\tX9 = *([1EF1838]);\n\tX8 = 0x17;\n\tgoto L_00BD;\n\tX9 = *([1EB9D40]);\n\tX8 = 0 | 0x18;\n\tgoto L_00BD;\n\tX9 = *([1EF2AB0]);\n\tX8 = 0x19;\n\tgoto L_00BD;\n\tX9 = *([1EEAA10]);\n\tX8 = 0x1A;\n\tgoto L_00BD;\n\tX9 = *([1F02658]);\n\tX8 = 0x1B;\n\tgoto L_00BD;\n\tX9 = *([1EA5A28]);\n\tX8 = 0 | 0x1C;\n\tgoto L_00BD;\n\tX9 = *([1EC9E80]);\n\tX8 = 0x1D;\n\tgoto L_00BD;\n\tX9 = *([1EFF280]);\n\tX8 = 0 | 0x1E;\n\tgoto L_00BD;\n\tX9 = *([1EF9F78]);\n\tX8 = 0 | 0x1F;\n\tgoto L_00BD;\n\tX9 = *([1EF5418]);\n\tX8 = 0 | 0x20;\n\tgoto L_00BD;\n\tX9 = *([1EFBB90]);\n\tX8 = 0x21;\n\tgoto L_00BD;\n\tX9 = *([1EB9DE0]);\n\tX8 = 0x22;\n\tgoto L_00BD;\n\tX9 = *([1F0EF28]);\n\tX8 = 0x23;\n\tgoto L_00BD;\n\tX9 = *([1EA6F98]);\n\tX8 = 0x24;\n\tgoto L_00BD;\n\tX9 = *([1EABA30]);\n\tX8 = 0x25;\n\tgoto L_00BD;\n\tX9 = *([1EDD368]);\n\tX8 = 0x26;\nL_00BD:\n\tX10 = 0xFFFFFFFF;\n\t*([X19+10]) = X10;\n\tX9 = *([X9]);\n\tX0 = 0 | 1;\n\tX10 = X8;\n\t*([X19+18]) = X9;\n\t*([X19+10]) = X10;\nL_00C9:\n\treturn 0;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				//IL_0029: Expected O, but got I
				while (true)
				{
					int num = _003C_003E1__state;
					bool flag = _003C_003E1__state < 38;
					bool flag2 = !flag;
					int num2 = _003C_003E1__state - 38;
					bool flag3 = num2 == 0;
					bool flag4 = !flag3;
					if (flag2 && flag4)
					{
						break;
					}
					int num3 = 25268224 + 1864;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X9_v2 (System.Int32)+v39 @ X8_v3 (System.Int32)*4]");
					object obj = 0L + (long)num3;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v57 @ X11_v2 (should have been resolved before IL gen)");
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A77")]
			[Address(RVA = "0xB595A4", Offset = "0xB595A4", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EFE6C0]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([202280C]) = v34;\nL_0014:\n\tv38 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw new TypeLoadException();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A79")]
			[Address(RVA = "0xB59610", Offset = "0xB59610", Length = "0x98")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EDE9A0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202280D]) = v38;\nL_0014:\n\tv40 = this.<>1__state + 2;\n\tv42 = v40 == 0;\n\tv45 = ~v42;\n\tif (v45) goto L_002E;\n\tv48 = System.Environment::get_CurrentManagedThreadId();\n\tv50 = this.<>l__initialThreadId != v48;\n\tif (v50) goto L_002E;\n\tthis.<>1__state = 0;\n\tgoto L_003C;\nL_002E:\n\tv76 = new EasyMobile.ManifestGenerator.Elements.ApplicationElement+<get_AllAvailableAttributes>d__6();\n\tSystem.Object::.ctor(v76);\n\tv76.<>1__state = 0;\n\tv81 = System.Environment::get_CurrentManagedThreadId();\n\tv76.<>l__initialThreadId = v81;\nL_003C:\n\treturn v93;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			IEnumerator<string> IEnumerable<string>.GetEnumerator()
			{
				if (_003C_003E1__state + 2 == 0)
				{
					int currentManagedThreadId = Environment.CurrentManagedThreadId;
					if (_003C_003El__initialThreadId == currentManagedThreadId)
					{
						_003C_003E1__state = 0;
						return this;
					}
				}
				_003Cget_AllAvailableAttributes_003Ed__6 _003Cget_AllAvailableAttributes_003Ed__7 = null;
				_003Cget_AllAvailableAttributes_003Ed__7._003C_003E1__state = 0;
				int currentManagedThreadId2 = Environment.CurrentManagedThreadId;
				_003Cget_AllAvailableAttributes_003Ed__7._003C_003El__initialThreadId = currentManagedThreadId2;
				return _003Cget_AllAvailableAttributes_003Ed__7;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A7A")]
			[Address(RVA = "0xB596A8", Offset = "0xB596A8", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = EasyMobile.ManifestGenerator.Elements.ApplicationElement+<get_AllAvailableAttributes>d__6::System.Collections.Generic.IEnumerable<System.String>.GetEnumerator(this);\n\treturn returnVal1;\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<string>)this).GetEnumerator();
			}
		}

		[Token(Token = "0x170001D0")]
		public override IEnumerable<AndroidManifestElementStyles> ParentStyles
		{
			[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x7353F8", Offset = "0x7353F8")]
			[Token(Token = "0x6000665")]
			[Address(RVA = "0xB590C4", Offset = "0xB590C4", Length = "0x70")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EB1760]);\n\tv15 = *([v14 @ X8_v7]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022808]) = v35;\nL_0014:\n\tv39 = new EasyMobile.ManifestGenerator.Elements.ApplicationElement+<get_ParentStyles>d__2();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0xFFFFFFFE;\n\tv44 = System.Environment::get_CurrentManagedThreadId();\n\tv39.<>l__initialThreadId = v44;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				_003Cget_ParentStyles_003Ed__2 _003Cget_ParentStyles_003Ed__3 = new _003Cget_ParentStyles_003Ed__2(-2);
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003Cget_ParentStyles_003Ed__3._003C_003El__initialThreadId = currentManagedThreadId;
				return _003Cget_ParentStyles_003Ed__3;
			}
		}

		[Token(Token = "0x170001D1")]
		public override IEnumerable<AndroidManifestElementStyles> ChildStyles
		{
			[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x73545C", Offset = "0x73545C")]
			[Token(Token = "0x6000666")]
			[Address(RVA = "0xB5916C", Offset = "0xB5916C", Length = "0x70")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EEF998]);\n\tv15 = *([v14 @ X8_v7]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022809]) = v35;\nL_0014:\n\tv39 = new EasyMobile.ManifestGenerator.Elements.ApplicationElement+<get_ChildStyles>d__4();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0xFFFFFFFE;\n\tv44 = System.Environment::get_CurrentManagedThreadId();\n\tv39.<>l__initialThreadId = v44;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				_003Cget_ChildStyles_003Ed__4 _003Cget_ChildStyles_003Ed__5 = new _003Cget_ChildStyles_003Ed__4(-2);
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003Cget_ChildStyles_003Ed__5._003C_003El__initialThreadId = currentManagedThreadId;
				return _003Cget_ChildStyles_003Ed__5;
			}
		}

		[Token(Token = "0x170001D2")]
		public override IEnumerable<string> AllAvailableAttributes
		{
			[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x7354C0", Offset = "0x7354C0")]
			[Token(Token = "0x6000667")]
			[Address(RVA = "0xB59214", Offset = "0xB59214", Length = "0x70")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EA8098]);\n\tv15 = *([v14 @ X8_v7]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202280A]) = v35;\nL_0014:\n\tv39 = new EasyMobile.ManifestGenerator.Elements.ApplicationElement+<get_AllAvailableAttributes>d__6();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0xFFFFFFFE;\n\tv44 = System.Environment::get_CurrentManagedThreadId();\n\tv39.<>l__initialThreadId = v44;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				_003Cget_AllAvailableAttributes_003Ed__6 _003Cget_AllAvailableAttributes_003Ed__7 = new _003Cget_AllAvailableAttributes_003Ed__6(-2);
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003Cget_AllAvailableAttributes_003Ed__7._003C_003El__initialThreadId = currentManagedThreadId;
				return _003Cget_AllAvailableAttributes_003Ed__7;
			}
		}

		[Token(Token = "0x6000664")]
		[Address(RVA = "0xB58E6C", Offset = "0xB58E6C", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEasyMobile.ManifestGenerator.Elements.AndroidManifestElement::.ctor(this);\n\tv11 = this->klass;\n\tv16 = this->klass->vtable[5];\n\tv17 = this->klass->vtable[5];\n\t// 16 IndirectJump v16 @ X3_v1, this @ X0 (EasyMobile.ManifestGenerator.Elements.ApplicationElement), this @ X0 (EasyMobile.ManifestGenerator.Elements.ApplicationElement), 4, v17 @ X2_v1, v16 @ X3_v1, v19 @ X4, v20 @ X5, v21 @ X6, v22 @ X7, v23 @ V0, v24 @ V1, v25 @ V2, v26 @ V3, v27 @ V4, v28 @ V5, v29 @ V6, v30 @ V7\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ApplicationElement()
		{
			//IL_000b: Expected I, but got O
			//IL_001b: Expected O, but got I
			//IL_002b: Expected O, but got I
			base._002Ector();
			IntPtr intPtr = (IntPtr)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ X8_v1 (Il2CppClass<EasyMobile.ManifestGenerator.Elements.ApplicationElement>)+180]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ X8_v1 (Il2CppClass<EasyMobile.ManifestGenerator.Elements.ApplicationElement>)+188]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v16 @ X3_v1 (should have been resolved before IL gen)");
		}
	}
}
