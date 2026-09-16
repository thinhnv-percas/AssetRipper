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
	[Token(Token = "0x20000AB")]
	public class ServiceElement : AndroidManifestElement
	{
		[CompilerGenerated]
		[Token(Token = "0x2000183")]
		private sealed class _003Cget_ParentStyles_003Ed__2 : IEnumerable<AndroidManifestElementStyles>, IEnumerable, IEnumerator<AndroidManifestElementStyles>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000619")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x400061A")]
			[FieldOffset(Offset = "0x14")]
			private AndroidManifestElementStyles _003C_003E2__current;

			[Token(Token = "0x400061B")]
			[FieldOffset(Offset = "0x18")]
			internal int _003C_003El__initialThreadId;

			[Token(Token = "0x170002EF")]
			AndroidManifestElementStyles IEnumerator<AndroidManifestElementStyles>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000BD9")]
				[Address(RVA = "0xFC7274", Offset = "0xFC7274", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x170002F0")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000BDB")]
				[Address(RVA = "0xFC72E0", Offset = "0xFC72E0", Length = "0x64")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1F049E8]);\n\tv19 = *([v18 @ X8_v5]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20255D7]) = v38;\nL_0014:\n\tv40 = this.<>2__current;\n\t// 25 Box returnVal1 @ X0_v3 (System.Object), typeof(EasyMobile.ManifestGenerator.Elements.AndroidManifestElementStyles), &v40 @ X8_v3 (EasyMobile.ManifestGenerator.Elements.AndroidManifestElementStyles)\n\treturn returnVal1;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					AndroidManifestElementStyles androidManifestElementStyles = _003C_003E2__current;
					return androidManifestElementStyles;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000BD6")]
			[Address(RVA = "0xFC6CBC", Offset = "0xFC6CBC", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\tv16 = System.Environment::get_CurrentManagedThreadId();\n\tthis.<>l__initialThreadId = v16;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003Cget_ParentStyles_003Ed__2(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000BD7")]
			[Address(RVA = "0xFC7234", Offset = "0xFC7234", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000BD8")]
			[Address(RVA = "0xFC7238", Offset = "0xFC7238", Length = "0x3C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = this.<>1__state == 1;\n\tif (v7) goto L_FFFFFFFF;\n\tv12 = this.<>1__state == 0;\n\tv13 = ~v12;\n\tif (v13) goto L_0018;\n\tthis.<>1__state = 0xFFFF0004FFFFFFFF;\n\tgoto L_0016;\nL_0016:\n\tthis.<>1__state = v24;\nL_0018:\n\treturn v21;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			[Token(Token = "0x6000BDA")]
			[Address(RVA = "0xFC727C", Offset = "0xFC727C", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1ECBB58]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([20255D6]) = v34;\nL_0014:\n\tv38 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw new TypeLoadException();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000BDC")]
			[Address(RVA = "0xFC7344", Offset = "0xFC7344", Length = "0x98")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EE3010]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20255D8]) = v38;\nL_0014:\n\tv40 = this.<>1__state + 2;\n\tv42 = v40 == 0;\n\tv45 = ~v42;\n\tif (v45) goto L_002E;\n\tv48 = System.Environment::get_CurrentManagedThreadId();\n\tv50 = this.<>l__initialThreadId != v48;\n\tif (v50) goto L_002E;\n\tthis.<>1__state = 0;\n\tgoto L_003C;\nL_002E:\n\tv76 = new EasyMobile.ManifestGenerator.Elements.ServiceElement+<get_ParentStyles>d__2();\n\tSystem.Object::.ctor(v76);\n\tv76.<>1__state = 0;\n\tv81 = System.Environment::get_CurrentManagedThreadId();\n\tv76.<>l__initialThreadId = v81;\nL_003C:\n\treturn v93;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			[Token(Token = "0x6000BDD")]
			[Address(RVA = "0xFC73DC", Offset = "0xFC73DC", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = EasyMobile.ManifestGenerator.Elements.ServiceElement+<get_ParentStyles>d__2::System.Collections.Generic.IEnumerable<EasyMobile.ManifestGenerator.Elements.AndroidManifestElementStyles>.GetEnumerator(this);\n\treturn returnVal1;\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<AndroidManifestElementStyles>)this).GetEnumerator();
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000184")]
		private sealed class _003Cget_ChildStyles_003Ed__4 : IEnumerable<AndroidManifestElementStyles>, IEnumerable, IEnumerator<AndroidManifestElementStyles>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400061C")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x400061D")]
			[FieldOffset(Offset = "0x14")]
			private AndroidManifestElementStyles _003C_003E2__current;

			[Token(Token = "0x400061E")]
			[FieldOffset(Offset = "0x18")]
			internal int _003C_003El__initialThreadId;

			[Token(Token = "0x170002F1")]
			AndroidManifestElementStyles IEnumerator<AndroidManifestElementStyles>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000BE1")]
				[Address(RVA = "0xFC70C8", Offset = "0xFC70C8", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x170002F2")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000BE3")]
				[Address(RVA = "0xFC7134", Offset = "0xFC7134", Length = "0x64")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EE1EE8]);\n\tv19 = *([v18 @ X8_v5]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20255D4]) = v38;\nL_0014:\n\tv40 = this.<>2__current;\n\t// 25 Box returnVal1 @ X0_v3 (System.Object), typeof(EasyMobile.ManifestGenerator.Elements.AndroidManifestElementStyles), &v40 @ X8_v3 (EasyMobile.ManifestGenerator.Elements.AndroidManifestElementStyles)\n\treturn returnVal1;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					AndroidManifestElementStyles androidManifestElementStyles = _003C_003E2__current;
					return androidManifestElementStyles;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000BDE")]
			[Address(RVA = "0xFC6D64", Offset = "0xFC6D64", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\tv16 = System.Environment::get_CurrentManagedThreadId();\n\tthis.<>l__initialThreadId = v16;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003Cget_ChildStyles_003Ed__4(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000BDF")]
			[Address(RVA = "0xFC7074", Offset = "0xFC7074", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000BE0")]
			[Address(RVA = "0xFC7078", Offset = "0xFC7078", Length = "0x50")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = this.<>1__state == 2;\n\tif (v7) goto L_FFFFFFFF;\n\tv16 = this.<>1__state == 1;\n\tif (v16) goto L_FFFFFFFF;\n\tv22 = this.<>1__state == 0;\n\tv23 = ~v22;\n\tif (v23) goto L_0026;\n\tgoto L_0021;\n\tgoto L_0024;\nL_0021:\n\tthis.<>1__state = 0xFFFFFFFF;\n\tthis.<>2__current = v59;\nL_0024:\n\tthis.<>1__state = v42;\nL_0026:\n\treturn v56;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				bool result;
				int num;
				int num2;
				if (_003C_003E1__state != 2)
				{
					AndroidManifestElementStyles androidManifestElementStyles;
					if (_003C_003E1__state != 1)
					{
						bool flag = _003C_003E1__state == 0;
						bool flag2 = !flag;
						result = false;
						if (flag2)
						{
							goto IL_00b6;
						}
						androidManifestElementStyles = AndroidManifestElementStyles.IntentFilter;
						num = 1;
					}
					else
					{
						androidManifestElementStyles = AndroidManifestElementStyles.MetaData;
						num = 2;
					}
					_003C_003E1__state = -1;
					_003C_003E2__current = androidManifestElementStyles;
					num2 = 1;
				}
				else
				{
					num2 = 0;
					num = -1;
				}
				_003C_003E1__state = num;
				result = (byte)num2 != 0;
				goto IL_00b6;
				IL_00b6:
				return result;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000BE2")]
			[Address(RVA = "0xFC70D0", Offset = "0xFC70D0", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EB7890]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([20255D3]) = v34;\nL_0014:\n\tv38 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw new TypeLoadException();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000BE4")]
			[Address(RVA = "0xFC7198", Offset = "0xFC7198", Length = "0x98")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1ED4318]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20255D5]) = v38;\nL_0014:\n\tv40 = this.<>1__state + 2;\n\tv42 = v40 == 0;\n\tv45 = ~v42;\n\tif (v45) goto L_002E;\n\tv48 = System.Environment::get_CurrentManagedThreadId();\n\tv50 = this.<>l__initialThreadId != v48;\n\tif (v50) goto L_002E;\n\tthis.<>1__state = 0;\n\tgoto L_003C;\nL_002E:\n\tv76 = new EasyMobile.ManifestGenerator.Elements.ServiceElement+<get_ChildStyles>d__4();\n\tSystem.Object::.ctor(v76);\n\tv76.<>1__state = 0;\n\tv81 = System.Environment::get_CurrentManagedThreadId();\n\tv76.<>l__initialThreadId = v81;\nL_003C:\n\treturn v93;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			[Token(Token = "0x6000BE5")]
			[Address(RVA = "0xFC7230", Offset = "0xFC7230", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = EasyMobile.ManifestGenerator.Elements.ServiceElement+<get_ChildStyles>d__4::System.Collections.Generic.IEnumerable<EasyMobile.ManifestGenerator.Elements.AndroidManifestElementStyles>.GetEnumerator(this);\n\treturn returnVal1;\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<AndroidManifestElementStyles>)this).GetEnumerator();
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000185")]
		private sealed class _003Cget_AllAvailableAttributes_003Ed__6 : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400061F")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x4000620")]
			[FieldOffset(Offset = "0x18")]
			private string _003C_003E2__current;

			[Token(Token = "0x4000621")]
			[FieldOffset(Offset = "0x20")]
			internal int _003C_003El__initialThreadId;

			[Token(Token = "0x170002F3")]
			string IEnumerator<string>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000BE9")]
				[Address(RVA = "0xFC6F64", Offset = "0xFC6F64", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x170002F4")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000BEB")]
				[Address(RVA = "0xFC6FD0", Offset = "0xFC6FD0", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000BE6")]
			[Address(RVA = "0xFC6E0C", Offset = "0xFC6E0C", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\tv16 = System.Environment::get_CurrentManagedThreadId();\n\tthis.<>l__initialThreadId = v16;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003Cget_AllAvailableAttributes_003Ed__6(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000BE7")]
			[Address(RVA = "0xFC6E44", Offset = "0xFC6E44", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000BE8")]
			[Address(RVA = "0xFC6E48", Offset = "0xFC6E48", Length = "0x11C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EF4E58]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20255D0]) = v38;\nL_0013:\n\tv39 = this.<>1__state;\n\tv41 = this.<>1__state < 0xA;\n\tv42 = ~v41;\n\tv43 = this.<>1__state - 0xA;\n\tv45 = v43 == 0;\n\tv50 = ~v45;\n\tv51 = v42 & v50;\n\tif (v51) goto L_0059;\n\tv53 = 0x181D000 + 0xC64;\n\tv57 = *([v53 @ X9_v2 (System.Int32)+v39 @ X8_v3 (System.Int32)*4]) + v53;\n\t// 41 IndirectJump v57 @ X11_v2, 0, 0, methodInfo @ X1 (Il2CppMethodInfo), v22 @ X2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tX9 = *([1F0ADD8]);\n\tX8 = 0 | 1;\n\tgoto L_004D;\n\tX9 = *([1EAD528]);\n\tX8 = 0 | 3;\n\tgoto L_004D;\n\tX9 = *([1EACC58]);\n\tX8 = 0 | 4;\n\tgoto L_004D;\n\tX9 = *([1F08FC0]);\n\tX8 = 5;\n\tgoto L_004D;\n\tX9 = *([1EB66D0]);\n\tX8 = 0 | 6;\n\tgoto L_004D;\n\tX9 = *([1EA4618]);\n\tX8 = 0 | 7;\n\tgoto L_004D;\n\tX9 = *([1EF1838]);\n\tX8 = 0 | 8;\n\tgoto L_004D;\n\tX9 = *([1EF2AB0]);\n\tX8 = 9;\n\tgoto L_004D;\n\tX9 = *([1F02658]);\n\tX8 = 0xA;\nL_004D:\n\tX10 = 0xFFFFFFFF;\n\t*([X19+10]) = X10;\n\tX9 = *([X9]);\n\tX0 = 0 | 1;\n\tX10 = X8;\n\t*([X19+18]) = X9;\n\t*([X19+10]) = X10;\nL_0059:\n\treturn 0;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				//IL_0029: Expected O, but got I
				while (true)
				{
					int num = _003C_003E1__state;
					bool flag = _003C_003E1__state < 10;
					bool flag2 = !flag;
					int num2 = _003C_003E1__state - 10;
					bool flag3 = num2 == 0;
					bool flag4 = !flag3;
					if (flag2 && flag4)
					{
						break;
					}
					int num3 = 25284608 + 3172;
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
			[Token(Token = "0x6000BEA")]
			[Address(RVA = "0xFC6F6C", Offset = "0xFC6F6C", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EDF728]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([20255D1]) = v34;\nL_0014:\n\tv38 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw new TypeLoadException();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000BEC")]
			[Address(RVA = "0xFC6FD8", Offset = "0xFC6FD8", Length = "0x98")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1F08138]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20255D2]) = v38;\nL_0014:\n\tv40 = this.<>1__state + 2;\n\tv42 = v40 == 0;\n\tv45 = ~v42;\n\tif (v45) goto L_002E;\n\tv48 = System.Environment::get_CurrentManagedThreadId();\n\tv50 = this.<>l__initialThreadId != v48;\n\tif (v50) goto L_002E;\n\tthis.<>1__state = 0;\n\tgoto L_003C;\nL_002E:\n\tv76 = new EasyMobile.ManifestGenerator.Elements.ServiceElement+<get_AllAvailableAttributes>d__6();\n\tSystem.Object::.ctor(v76);\n\tv76.<>1__state = 0;\n\tv81 = System.Environment::get_CurrentManagedThreadId();\n\tv76.<>l__initialThreadId = v81;\nL_003C:\n\treturn v93;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			[Token(Token = "0x6000BED")]
			[Address(RVA = "0xFC7070", Offset = "0xFC7070", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = EasyMobile.ManifestGenerator.Elements.ServiceElement+<get_AllAvailableAttributes>d__6::System.Collections.Generic.IEnumerable<System.String>.GetEnumerator(this);\n\treturn returnVal1;\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<string>)this).GetEnumerator();
			}
		}

		[Token(Token = "0x17000206")]
		public override IEnumerable<AndroidManifestElementStyles> ParentStyles
		{
			[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x737620", Offset = "0x737620")]
			[Token(Token = "0x60006B9")]
			[Address(RVA = "0xFC6C4C", Offset = "0xFC6C4C", Length = "0x70")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1ED6538]);\n\tv15 = *([v14 @ X8_v7]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20255CD]) = v35;\nL_0014:\n\tv39 = new EasyMobile.ManifestGenerator.Elements.ServiceElement+<get_ParentStyles>d__2();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0xFFFFFFFE;\n\tv44 = System.Environment::get_CurrentManagedThreadId();\n\tv39.<>l__initialThreadId = v44;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				_003Cget_ParentStyles_003Ed__2 _003Cget_ParentStyles_003Ed__3 = new _003Cget_ParentStyles_003Ed__2(-2);
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003Cget_ParentStyles_003Ed__3._003C_003El__initialThreadId = currentManagedThreadId;
				return _003Cget_ParentStyles_003Ed__3;
			}
		}

		[Token(Token = "0x17000207")]
		public override IEnumerable<AndroidManifestElementStyles> ChildStyles
		{
			[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x737684", Offset = "0x737684")]
			[Token(Token = "0x60006BA")]
			[Address(RVA = "0xFC6CF4", Offset = "0xFC6CF4", Length = "0x70")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EDA360]);\n\tv15 = *([v14 @ X8_v7]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20255CE]) = v35;\nL_0014:\n\tv39 = new EasyMobile.ManifestGenerator.Elements.ServiceElement+<get_ChildStyles>d__4();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0xFFFFFFFE;\n\tv44 = System.Environment::get_CurrentManagedThreadId();\n\tv39.<>l__initialThreadId = v44;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				_003Cget_ChildStyles_003Ed__4 _003Cget_ChildStyles_003Ed__5 = new _003Cget_ChildStyles_003Ed__4(-2);
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003Cget_ChildStyles_003Ed__5._003C_003El__initialThreadId = currentManagedThreadId;
				return _003Cget_ChildStyles_003Ed__5;
			}
		}

		[Token(Token = "0x17000208")]
		public override IEnumerable<string> AllAvailableAttributes
		{
			[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x7376E8", Offset = "0x7376E8")]
			[Token(Token = "0x60006BB")]
			[Address(RVA = "0xFC6D9C", Offset = "0xFC6D9C", Length = "0x70")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1ED6E58]);\n\tv15 = *([v14 @ X8_v7]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20255CF]) = v35;\nL_0014:\n\tv39 = new EasyMobile.ManifestGenerator.Elements.ServiceElement+<get_AllAvailableAttributes>d__6();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0xFFFFFFFE;\n\tv44 = System.Environment::get_CurrentManagedThreadId();\n\tv39.<>l__initialThreadId = v44;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				_003Cget_AllAvailableAttributes_003Ed__6 _003Cget_AllAvailableAttributes_003Ed__7 = new _003Cget_AllAvailableAttributes_003Ed__6(-2);
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003Cget_AllAvailableAttributes_003Ed__7._003C_003El__initialThreadId = currentManagedThreadId;
				return _003Cget_AllAvailableAttributes_003Ed__7;
			}
		}

		[Token(Token = "0x60006B8")]
		[Address(RVA = "0xFC6C18", Offset = "0xFC6C18", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEasyMobile.ManifestGenerator.Elements.AndroidManifestElement::.ctor(this);\n\tv11 = this->klass;\n\tv16 = this->klass->vtable[5];\n\tv17 = this->klass->vtable[5];\n\t// 17 IndirectJump v16 @ X3_v1, this @ X0 (EasyMobile.ManifestGenerator.Elements.ServiceElement), this @ X0 (EasyMobile.ManifestGenerator.Elements.ServiceElement), 18, v17 @ X2_v1, v16 @ X3_v1, v19 @ X4, v20 @ X5, v21 @ X6, v22 @ X7, v23 @ V0, v24 @ V1, v25 @ V2, v26 @ V3, v27 @ V4, v28 @ V5, v29 @ V6, v30 @ V7\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ServiceElement()
		{
			//IL_000b: Expected I, but got O
			//IL_001b: Expected O, but got I
			//IL_002b: Expected O, but got I
			base._002Ector();
			IntPtr intPtr = (IntPtr)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ X8_v1 (Il2CppClass<EasyMobile.ManifestGenerator.Elements.ServiceElement>)+180]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ X8_v1 (Il2CppClass<EasyMobile.ManifestGenerator.Elements.ServiceElement>)+188]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v16 @ X3_v1 (should have been resolved before IL gen)");
		}
	}
}
