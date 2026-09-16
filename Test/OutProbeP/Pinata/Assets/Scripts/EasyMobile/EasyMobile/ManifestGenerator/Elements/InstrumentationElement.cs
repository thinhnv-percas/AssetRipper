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
	[Token(Token = "0x20000A1")]
	public class InstrumentationElement : AndroidManifestElement
	{
		[CompilerGenerated]
		[Token(Token = "0x2000165")]
		private sealed class _003Cget_ParentStyles_003Ed__2 : IEnumerable<AndroidManifestElementStyles>, IEnumerable, IEnumerator<AndroidManifestElementStyles>, IEnumerator, IDisposable
		{
			[Token(Token = "0x40005BF")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x40005C0")]
			[FieldOffset(Offset = "0x14")]
			private AndroidManifestElementStyles _003C_003E2__current;

			[Token(Token = "0x40005C1")]
			[FieldOffset(Offset = "0x18")]
			internal int _003C_003El__initialThreadId;

			[Token(Token = "0x170002B3")]
			AndroidManifestElementStyles IEnumerator<AndroidManifestElementStyles>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000AE9")]
				[Address(RVA = "0xB5B4D0", Offset = "0xB5B4D0", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x170002B4")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000AEB")]
				[Address(RVA = "0xB5B53C", Offset = "0xB5B53C", Length = "0x64")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EA3BA0]);\n\tv19 = *([v18 @ X8_v5]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022842]) = v38;\nL_0014:\n\tv40 = this.<>2__current;\n\t// 25 Box returnVal1 @ X0_v3 (System.Object), typeof(EasyMobile.ManifestGenerator.Elements.AndroidManifestElementStyles), &v40 @ X8_v3 (EasyMobile.ManifestGenerator.Elements.AndroidManifestElementStyles)\n\treturn returnVal1;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					AndroidManifestElementStyles androidManifestElementStyles = _003C_003E2__current;
					return androidManifestElementStyles;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000AE6")]
			[Address(RVA = "0xB5AF80", Offset = "0xB5AF80", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\tv16 = System.Environment::get_CurrentManagedThreadId();\n\tthis.<>l__initialThreadId = v16;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003Cget_ParentStyles_003Ed__2(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000AE7")]
			[Address(RVA = "0xB5B490", Offset = "0xB5B490", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000AE8")]
			[Address(RVA = "0xB5B494", Offset = "0xB5B494", Length = "0x3C")]
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
			[Token(Token = "0x6000AEA")]
			[Address(RVA = "0xB5B4D8", Offset = "0xB5B4D8", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EC6100]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([2022841]) = v34;\nL_0014:\n\tv38 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw new TypeLoadException();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000AEC")]
			[Address(RVA = "0xB5B5A0", Offset = "0xB5B5A0", Length = "0x98")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1F06110]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022843]) = v38;\nL_0014:\n\tv40 = this.<>1__state + 2;\n\tv42 = v40 == 0;\n\tv45 = ~v42;\n\tif (v45) goto L_002E;\n\tv48 = System.Environment::get_CurrentManagedThreadId();\n\tv50 = this.<>l__initialThreadId != v48;\n\tif (v50) goto L_002E;\n\tthis.<>1__state = 0;\n\tgoto L_003C;\nL_002E:\n\tv76 = new EasyMobile.ManifestGenerator.Elements.InstrumentationElement+<get_ParentStyles>d__2();\n\tSystem.Object::.ctor(v76);\n\tv76.<>1__state = 0;\n\tv81 = System.Environment::get_CurrentManagedThreadId();\n\tv76.<>l__initialThreadId = v81;\nL_003C:\n\treturn v93;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			[Token(Token = "0x6000AED")]
			[Address(RVA = "0xB5B638", Offset = "0xB5B638", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = EasyMobile.ManifestGenerator.Elements.InstrumentationElement+<get_ParentStyles>d__2::System.Collections.Generic.IEnumerable<EasyMobile.ManifestGenerator.Elements.AndroidManifestElementStyles>.GetEnumerator(this);\n\treturn returnVal1;\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<AndroidManifestElementStyles>)this).GetEnumerator();
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000166")]
		private sealed class _003Cget_ChildStyles_003Ed__4 : IEnumerable<AndroidManifestElementStyles>, IEnumerable, IEnumerator<AndroidManifestElementStyles>, IEnumerator, IDisposable
		{
			[Token(Token = "0x40005C2")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x40005C3")]
			[FieldOffset(Offset = "0x14")]
			private AndroidManifestElementStyles _003C_003E2__current;

			[Token(Token = "0x40005C4")]
			[FieldOffset(Offset = "0x18")]
			internal int _003C_003El__initialThreadId;

			[Token(Token = "0x170002B5")]
			AndroidManifestElementStyles IEnumerator<AndroidManifestElementStyles>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000AF1")]
				[Address(RVA = "0xB5B324", Offset = "0xB5B324", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x170002B6")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000AF3")]
				[Address(RVA = "0xB5B390", Offset = "0xB5B390", Length = "0x64")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EF37B0]);\n\tv19 = *([v18 @ X8_v5]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202283F]) = v38;\nL_0014:\n\tv40 = this.<>2__current;\n\t// 25 Box returnVal1 @ X0_v3 (System.Object), typeof(EasyMobile.ManifestGenerator.Elements.AndroidManifestElementStyles), &v40 @ X8_v3 (EasyMobile.ManifestGenerator.Elements.AndroidManifestElementStyles)\n\treturn returnVal1;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					AndroidManifestElementStyles androidManifestElementStyles = _003C_003E2__current;
					return androidManifestElementStyles;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000AEE")]
			[Address(RVA = "0xB5B028", Offset = "0xB5B028", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\tv16 = System.Environment::get_CurrentManagedThreadId();\n\tthis.<>l__initialThreadId = v16;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003Cget_ChildStyles_003Ed__4(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000AEF")]
			[Address(RVA = "0xB5B308", Offset = "0xB5B308", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000AF0")]
			[Address(RVA = "0xB5B30C", Offset = "0xB5B30C", Length = "0x18")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.<>1__state == 0;\n\tv3 = ~v2;\n\tif (v3) goto L_0007;\n\tthis.<>1__state = 0xFFFFFFFF;\nL_0007:\n\treturn 0;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				if (_003C_003E1__state == 0)
				{
					_003C_003E1__state = -1;
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000AF2")]
			[Address(RVA = "0xB5B32C", Offset = "0xB5B32C", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1ECA180]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([202283E]) = v34;\nL_0014:\n\tv38 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw new TypeLoadException();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000AF4")]
			[Address(RVA = "0xB5B3F4", Offset = "0xB5B3F4", Length = "0x98")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EACF40]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022840]) = v38;\nL_0014:\n\tv40 = this.<>1__state + 2;\n\tv42 = v40 == 0;\n\tv45 = ~v42;\n\tif (v45) goto L_002E;\n\tv48 = System.Environment::get_CurrentManagedThreadId();\n\tv50 = this.<>l__initialThreadId != v48;\n\tif (v50) goto L_002E;\n\tthis.<>1__state = 0;\n\tgoto L_003C;\nL_002E:\n\tv76 = new EasyMobile.ManifestGenerator.Elements.InstrumentationElement+<get_ChildStyles>d__4();\n\tSystem.Object::.ctor(v76);\n\tv76.<>1__state = 0;\n\tv81 = System.Environment::get_CurrentManagedThreadId();\n\tv76.<>l__initialThreadId = v81;\nL_003C:\n\treturn v93;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			[Token(Token = "0x6000AF5")]
			[Address(RVA = "0xB5B48C", Offset = "0xB5B48C", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = EasyMobile.ManifestGenerator.Elements.InstrumentationElement+<get_ChildStyles>d__4::System.Collections.Generic.IEnumerable<EasyMobile.ManifestGenerator.Elements.AndroidManifestElementStyles>.GetEnumerator(this);\n\treturn returnVal1;\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<AndroidManifestElementStyles>)this).GetEnumerator();
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000167")]
		private sealed class _003Cget_AllAvailableAttributes_003Ed__6 : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
		{
			[Token(Token = "0x40005C5")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x40005C6")]
			[FieldOffset(Offset = "0x18")]
			private string _003C_003E2__current;

			[Token(Token = "0x40005C7")]
			[FieldOffset(Offset = "0x20")]
			internal int _003C_003El__initialThreadId;

			[Token(Token = "0x170002B7")]
			string IEnumerator<string>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000AF9")]
				[Address(RVA = "0xB5B1F8", Offset = "0xB5B1F8", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x170002B8")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000AFB")]
				[Address(RVA = "0xB5B264", Offset = "0xB5B264", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000AF6")]
			[Address(RVA = "0xB5B0D0", Offset = "0xB5B0D0", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\tv16 = System.Environment::get_CurrentManagedThreadId();\n\tthis.<>l__initialThreadId = v16;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003Cget_AllAvailableAttributes_003Ed__6(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000AF7")]
			[Address(RVA = "0xB5B108", Offset = "0xB5B108", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000AF8")]
			[Address(RVA = "0xB5B10C", Offset = "0xB5B10C", Length = "0xEC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EA8648]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202283B]) = v38;\nL_0013:\n\tv39 = this.<>1__state;\n\tv41 = this.<>1__state < 7;\n\tv42 = ~v41;\n\tv43 = this.<>1__state - 7;\n\tv45 = v43 == 0;\n\tv50 = ~v45;\n\tv51 = v42 & v50;\n\tif (v51) goto L_004D;\n\tv53 = 0x1819000 + 0x82C;\n\tv57 = *([v53 @ X9_v2 (System.Int32)+v39 @ X8_v3 (System.Int32)*4]) + v53;\n\t// 41 IndirectJump v57 @ X11_v2, 0, 0, methodInfo @ X1 (Il2CppMethodInfo), v22 @ X2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tX9 = *([1EF8478]);\n\tX8 = 0 | 1;\n\tgoto L_0041;\n\tX9 = *([1F08FC0]);\n\tX8 = 0 | 3;\n\tgoto L_0041;\n\tX9 = *([1EA4618]);\n\tX8 = 0 | 4;\n\tgoto L_0041;\n\tX9 = *([1EF1838]);\n\tX8 = 5;\n\tgoto L_0041;\n\tX9 = *([1EF4518]);\n\tX8 = 0 | 6;\n\tgoto L_0041;\n\tX9 = *([1ED7108]);\n\tX8 = 0 | 7;\nL_0041:\n\tX10 = 0xFFFFFFFF;\n\t*([X19+10]) = X10;\n\tX9 = *([X9]);\n\tX0 = 0 | 1;\n\tX10 = X8;\n\t*([X19+18]) = X9;\n\t*([X19+10]) = X10;\nL_004D:\n\treturn 0;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				//IL_0029: Expected O, but got I
				while (true)
				{
					int num = _003C_003E1__state;
					bool flag = _003C_003E1__state < 7;
					bool flag2 = !flag;
					int num2 = _003C_003E1__state - 7;
					bool flag3 = num2 == 0;
					bool flag4 = !flag3;
					if (flag2 && flag4)
					{
						break;
					}
					int num3 = 25268224 + 2092;
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
			[Token(Token = "0x6000AFA")]
			[Address(RVA = "0xB5B200", Offset = "0xB5B200", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1F0C1D8]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([202283C]) = v34;\nL_0014:\n\tv38 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw new TypeLoadException();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000AFC")]
			[Address(RVA = "0xB5B26C", Offset = "0xB5B26C", Length = "0x98")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EF8C70]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202283D]) = v38;\nL_0014:\n\tv40 = this.<>1__state + 2;\n\tv42 = v40 == 0;\n\tv45 = ~v42;\n\tif (v45) goto L_002E;\n\tv48 = System.Environment::get_CurrentManagedThreadId();\n\tv50 = this.<>l__initialThreadId != v48;\n\tif (v50) goto L_002E;\n\tthis.<>1__state = 0;\n\tgoto L_003C;\nL_002E:\n\tv76 = new EasyMobile.ManifestGenerator.Elements.InstrumentationElement+<get_AllAvailableAttributes>d__6();\n\tSystem.Object::.ctor(v76);\n\tv76.<>1__state = 0;\n\tv81 = System.Environment::get_CurrentManagedThreadId();\n\tv76.<>l__initialThreadId = v81;\nL_003C:\n\treturn v93;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			[Token(Token = "0x6000AFD")]
			[Address(RVA = "0xB5B304", Offset = "0xB5B304", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = EasyMobile.ManifestGenerator.Elements.InstrumentationElement+<get_AllAvailableAttributes>d__6::System.Collections.Generic.IEnumerable<System.String>.GetEnumerator(this);\n\treturn returnVal1;\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<string>)this).GetEnumerator();
			}
		}

		[Token(Token = "0x170001E8")]
		public override IEnumerable<AndroidManifestElementStyles> ParentStyles
		{
			[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x735A68", Offset = "0x735A68")]
			[Token(Token = "0x6000691")]
			[Address(RVA = "0xB5AF10", Offset = "0xB5AF10", Length = "0x70")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EBA5F0]);\n\tv15 = *([v14 @ X8_v7]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022838]) = v35;\nL_0014:\n\tv39 = new EasyMobile.ManifestGenerator.Elements.InstrumentationElement+<get_ParentStyles>d__2();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0xFFFFFFFE;\n\tv44 = System.Environment::get_CurrentManagedThreadId();\n\tv39.<>l__initialThreadId = v44;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				_003Cget_ParentStyles_003Ed__2 _003Cget_ParentStyles_003Ed__3 = new _003Cget_ParentStyles_003Ed__2(-2);
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003Cget_ParentStyles_003Ed__3._003C_003El__initialThreadId = currentManagedThreadId;
				return _003Cget_ParentStyles_003Ed__3;
			}
		}

		[Token(Token = "0x170001E9")]
		public override IEnumerable<AndroidManifestElementStyles> ChildStyles
		{
			[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x735ACC", Offset = "0x735ACC")]
			[Token(Token = "0x6000692")]
			[Address(RVA = "0xB5AFB8", Offset = "0xB5AFB8", Length = "0x70")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EE67E0]);\n\tv15 = *([v14 @ X8_v7]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022839]) = v35;\nL_0014:\n\tv39 = new EasyMobile.ManifestGenerator.Elements.InstrumentationElement+<get_ChildStyles>d__4();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0xFFFFFFFE;\n\tv44 = System.Environment::get_CurrentManagedThreadId();\n\tv39.<>l__initialThreadId = v44;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				_003Cget_ChildStyles_003Ed__4 _003Cget_ChildStyles_003Ed__5 = new _003Cget_ChildStyles_003Ed__4(-2);
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003Cget_ChildStyles_003Ed__5._003C_003El__initialThreadId = currentManagedThreadId;
				return _003Cget_ChildStyles_003Ed__5;
			}
		}

		[Token(Token = "0x170001EA")]
		public override IEnumerable<string> AllAvailableAttributes
		{
			[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x735B30", Offset = "0x735B30")]
			[Token(Token = "0x6000693")]
			[Address(RVA = "0xB5B060", Offset = "0xB5B060", Length = "0x70")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EF87E0]);\n\tv15 = *([v14 @ X8_v7]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202283A]) = v35;\nL_0014:\n\tv39 = new EasyMobile.ManifestGenerator.Elements.InstrumentationElement+<get_AllAvailableAttributes>d__6();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0xFFFFFFFE;\n\tv44 = System.Environment::get_CurrentManagedThreadId();\n\tv39.<>l__initialThreadId = v44;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				_003Cget_AllAvailableAttributes_003Ed__6 _003Cget_AllAvailableAttributes_003Ed__7 = new _003Cget_AllAvailableAttributes_003Ed__6(-2);
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003Cget_AllAvailableAttributes_003Ed__7._003C_003El__initialThreadId = currentManagedThreadId;
				return _003Cget_AllAvailableAttributes_003Ed__7;
			}
		}

		[Token(Token = "0x6000690")]
		[Address(RVA = "0xB58F2C", Offset = "0xB58F2C", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEasyMobile.ManifestGenerator.Elements.AndroidManifestElement::.ctor(this);\n\tv11 = this->klass;\n\tv16 = this->klass->vtable[5];\n\tv17 = this->klass->vtable[5];\n\t// 16 IndirectJump v16 @ X3_v1, this @ X0 (EasyMobile.ManifestGenerator.Elements.InstrumentationElement), this @ X0 (EasyMobile.ManifestGenerator.Elements.InstrumentationElement), 8, v17 @ X2_v1, v16 @ X3_v1, v19 @ X4, v20 @ X5, v21 @ X6, v22 @ X7, v23 @ V0, v24 @ V1, v25 @ V2, v26 @ V3, v27 @ V4, v28 @ V5, v29 @ V6, v30 @ V7\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public InstrumentationElement()
		{
			//IL_000b: Expected I, but got O
			//IL_001b: Expected O, but got I
			//IL_002b: Expected O, but got I
			base._002Ector();
			IntPtr intPtr = (IntPtr)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ X8_v1 (Il2CppClass<EasyMobile.ManifestGenerator.Elements.InstrumentationElement>)+180]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ X8_v1 (Il2CppClass<EasyMobile.ManifestGenerator.Elements.InstrumentationElement>)+188]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v16 @ X3_v1 (should have been resolved before IL gen)");
		}
	}
}
