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
	[Token(Token = "0x2000097")]
	public class ActionElement : AndroidManifestElement
	{
		[CompilerGenerated]
		[Token(Token = "0x200014B")]
		private sealed class _003Cget_ParentStyles_003Ed__2 : IEnumerable<AndroidManifestElementStyles>, IEnumerable, IEnumerator<AndroidManifestElementStyles>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000571")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x4000572")]
			[FieldOffset(Offset = "0x14")]
			private AndroidManifestElementStyles _003C_003E2__current;

			[Token(Token = "0x4000573")]
			[FieldOffset(Offset = "0x18")]
			internal int _003C_003El__initialThreadId;

			[Token(Token = "0x17000281")]
			AndroidManifestElementStyles IEnumerator<AndroidManifestElementStyles>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000A1E")]
				[Address(RVA = "0xB55BEC", Offset = "0xB55BEC", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000282")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000A20")]
				[Address(RVA = "0xB55C58", Offset = "0xB55C58", Length = "0x64")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EFB0D8]);\n\tv19 = *([v18 @ X8_v5]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20227D0]) = v38;\nL_0014:\n\tv40 = this.<>2__current;\n\t// 25 Box returnVal1 @ X0_v3 (System.Object), typeof(EasyMobile.ManifestGenerator.Elements.AndroidManifestElementStyles), &v40 @ X8_v3 (EasyMobile.ManifestGenerator.Elements.AndroidManifestElementStyles)\n\treturn returnVal1;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					AndroidManifestElementStyles androidManifestElementStyles = _003C_003E2__current;
					return androidManifestElementStyles;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A1B")]
			[Address(RVA = "0xB55708", Offset = "0xB55708", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\tv16 = System.Environment::get_CurrentManagedThreadId();\n\tthis.<>l__initialThreadId = v16;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003Cget_ParentStyles_003Ed__2(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A1C")]
			[Address(RVA = "0xB55BAC", Offset = "0xB55BAC", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000A1D")]
			[Address(RVA = "0xB55BB0", Offset = "0xB55BB0", Length = "0x3C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = this.<>1__state == 1;\n\tif (v7) goto L_FFFFFFFF;\n\tv12 = this.<>1__state == 0;\n\tv13 = ~v12;\n\tif (v13) goto L_0018;\n\tthis.<>1__state = 0xFFFF0009FFFFFFFF;\n\tgoto L_0016;\nL_0016:\n\tthis.<>1__state = v24;\nL_0018:\n\treturn v21;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			[Token(Token = "0x6000A1F")]
			[Address(RVA = "0xB55BF4", Offset = "0xB55BF4", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EC0930]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([20227CF]) = v34;\nL_0014:\n\tv38 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw new TypeLoadException();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A21")]
			[Address(RVA = "0xB55CBC", Offset = "0xB55CBC", Length = "0x98")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1ED2750]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20227D1]) = v38;\nL_0014:\n\tv40 = this.<>1__state + 2;\n\tv42 = v40 == 0;\n\tv45 = ~v42;\n\tif (v45) goto L_002E;\n\tv48 = System.Environment::get_CurrentManagedThreadId();\n\tv50 = this.<>l__initialThreadId != v48;\n\tif (v50) goto L_002E;\n\tthis.<>1__state = 0;\n\tgoto L_003C;\nL_002E:\n\tv76 = new EasyMobile.ManifestGenerator.Elements.ActionElement+<get_ParentStyles>d__2();\n\tSystem.Object::.ctor(v76);\n\tv76.<>1__state = 0;\n\tv81 = System.Environment::get_CurrentManagedThreadId();\n\tv76.<>l__initialThreadId = v81;\nL_003C:\n\treturn v93;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			[Token(Token = "0x6000A22")]
			[Address(RVA = "0xB55D54", Offset = "0xB55D54", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = EasyMobile.ManifestGenerator.Elements.ActionElement+<get_ParentStyles>d__2::System.Collections.Generic.IEnumerable<EasyMobile.ManifestGenerator.Elements.AndroidManifestElementStyles>.GetEnumerator(this);\n\treturn returnVal1;\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<AndroidManifestElementStyles>)this).GetEnumerator();
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200014C")]
		private sealed class _003Cget_ChildStyles_003Ed__4 : IEnumerable<AndroidManifestElementStyles>, IEnumerable, IEnumerator<AndroidManifestElementStyles>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000574")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x4000575")]
			[FieldOffset(Offset = "0x14")]
			private AndroidManifestElementStyles _003C_003E2__current;

			[Token(Token = "0x4000576")]
			[FieldOffset(Offset = "0x18")]
			internal int _003C_003El__initialThreadId;

			[Token(Token = "0x17000283")]
			AndroidManifestElementStyles IEnumerator<AndroidManifestElementStyles>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000A26")]
				[Address(RVA = "0xB55A40", Offset = "0xB55A40", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000284")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000A28")]
				[Address(RVA = "0xB55AAC", Offset = "0xB55AAC", Length = "0x64")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1ECD6E0]);\n\tv19 = *([v18 @ X8_v5]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20227CD]) = v38;\nL_0014:\n\tv40 = this.<>2__current;\n\t// 25 Box returnVal1 @ X0_v3 (System.Object), typeof(EasyMobile.ManifestGenerator.Elements.AndroidManifestElementStyles), &v40 @ X8_v3 (EasyMobile.ManifestGenerator.Elements.AndroidManifestElementStyles)\n\treturn returnVal1;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					AndroidManifestElementStyles androidManifestElementStyles = _003C_003E2__current;
					return androidManifestElementStyles;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A23")]
			[Address(RVA = "0xB557B0", Offset = "0xB557B0", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\tv16 = System.Environment::get_CurrentManagedThreadId();\n\tthis.<>l__initialThreadId = v16;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003Cget_ChildStyles_003Ed__4(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A24")]
			[Address(RVA = "0xB55A24", Offset = "0xB55A24", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000A25")]
			[Address(RVA = "0xB55A28", Offset = "0xB55A28", Length = "0x18")]
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
			[Token(Token = "0x6000A27")]
			[Address(RVA = "0xB55A48", Offset = "0xB55A48", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1F0D5E0]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([20227CC]) = v34;\nL_0014:\n\tv38 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw new TypeLoadException();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A29")]
			[Address(RVA = "0xB55B10", Offset = "0xB55B10", Length = "0x98")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EC73A8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20227CE]) = v38;\nL_0014:\n\tv40 = this.<>1__state + 2;\n\tv42 = v40 == 0;\n\tv45 = ~v42;\n\tif (v45) goto L_002E;\n\tv48 = System.Environment::get_CurrentManagedThreadId();\n\tv50 = this.<>l__initialThreadId != v48;\n\tif (v50) goto L_002E;\n\tthis.<>1__state = 0;\n\tgoto L_003C;\nL_002E:\n\tv76 = new EasyMobile.ManifestGenerator.Elements.ActionElement+<get_ChildStyles>d__4();\n\tSystem.Object::.ctor(v76);\n\tv76.<>1__state = 0;\n\tv81 = System.Environment::get_CurrentManagedThreadId();\n\tv76.<>l__initialThreadId = v81;\nL_003C:\n\treturn v93;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			[Token(Token = "0x6000A2A")]
			[Address(RVA = "0xB55BA8", Offset = "0xB55BA8", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = EasyMobile.ManifestGenerator.Elements.ActionElement+<get_ChildStyles>d__4::System.Collections.Generic.IEnumerable<EasyMobile.ManifestGenerator.Elements.AndroidManifestElementStyles>.GetEnumerator(this);\n\treturn returnVal1;\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<AndroidManifestElementStyles>)this).GetEnumerator();
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200014D")]
		private sealed class _003Cget_AllAvailableAttributes_003Ed__6 : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000577")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x4000578")]
			[FieldOffset(Offset = "0x18")]
			private string _003C_003E2__current;

			[Token(Token = "0x4000579")]
			[FieldOffset(Offset = "0x20")]
			internal int _003C_003El__initialThreadId;

			[Token(Token = "0x17000285")]
			string IEnumerator<string>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000A2E")]
				[Address(RVA = "0xB55914", Offset = "0xB55914", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000286")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000A30")]
				[Address(RVA = "0xB55980", Offset = "0xB55980", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A2B")]
			[Address(RVA = "0xB55858", Offset = "0xB55858", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\tv16 = System.Environment::get_CurrentManagedThreadId();\n\tthis.<>l__initialThreadId = v16;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003Cget_AllAvailableAttributes_003Ed__6(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A2C")]
			[Address(RVA = "0xB55890", Offset = "0xB55890", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000A2D")]
			[Address(RVA = "0xB55894", Offset = "0xB55894", Length = "0x80")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F0FAD0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20227C9]) = v38;\nL_0019:\n\tv45 = this.<>1__state == 1;\n\tif (v45) goto L_FFFFFFFF;\n\tv50 = this.<>1__state == 0;\n\tv51 = ~v50;\n\tif (v51) goto L_0032;\n\tthis.<>1__state = 0xFFFFFFFF;\n\tthis.<>2__current = \"android:name\";\n\tgoto L_002C;\nL_002C:\n\tthis.<>1__state = v67;\nL_0032:\n\treturn returnVal1;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
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
						goto IL_009b;
					}
					_003C_003E1__state = -1;
					_003C_003E2__current = "android:name";
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
				goto IL_009b;
				IL_009b:
				return result;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A2F")]
			[Address(RVA = "0xB5591C", Offset = "0xB5591C", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EAAE38]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([20227CA]) = v34;\nL_0014:\n\tv38 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw new TypeLoadException();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A31")]
			[Address(RVA = "0xB55988", Offset = "0xB55988", Length = "0x98")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EA3CA0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20227CB]) = v38;\nL_0014:\n\tv40 = this.<>1__state + 2;\n\tv42 = v40 == 0;\n\tv45 = ~v42;\n\tif (v45) goto L_002E;\n\tv48 = System.Environment::get_CurrentManagedThreadId();\n\tv50 = this.<>l__initialThreadId != v48;\n\tif (v50) goto L_002E;\n\tthis.<>1__state = 0;\n\tgoto L_003C;\nL_002E:\n\tv76 = new EasyMobile.ManifestGenerator.Elements.ActionElement+<get_AllAvailableAttributes>d__6();\n\tSystem.Object::.ctor(v76);\n\tv76.<>1__state = 0;\n\tv81 = System.Environment::get_CurrentManagedThreadId();\n\tv76.<>l__initialThreadId = v81;\nL_003C:\n\treturn v93;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			[Token(Token = "0x6000A32")]
			[Address(RVA = "0xB55A20", Offset = "0xB55A20", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = EasyMobile.ManifestGenerator.Elements.ActionElement+<get_AllAvailableAttributes>d__6::System.Collections.Generic.IEnumerable<System.String>.GetEnumerator(this);\n\treturn returnVal1;\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<string>)this).GetEnumerator();
			}
		}

		[Token(Token = "0x170001C7")]
		public override IEnumerable<AndroidManifestElementStyles> ParentStyles
		{
			[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x735074", Offset = "0x735074")]
			[Token(Token = "0x6000659")]
			[Address(RVA = "0xB55698", Offset = "0xB55698", Length = "0x70")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1F018A8]);\n\tv15 = *([v14 @ X8_v7]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20227C6]) = v35;\nL_0014:\n\tv39 = new EasyMobile.ManifestGenerator.Elements.ActionElement+<get_ParentStyles>d__2();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0xFFFFFFFE;\n\tv44 = System.Environment::get_CurrentManagedThreadId();\n\tv39.<>l__initialThreadId = v44;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				_003Cget_ParentStyles_003Ed__2 _003Cget_ParentStyles_003Ed__3 = new _003Cget_ParentStyles_003Ed__2(-2);
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003Cget_ParentStyles_003Ed__3._003C_003El__initialThreadId = currentManagedThreadId;
				return _003Cget_ParentStyles_003Ed__3;
			}
		}

		[Token(Token = "0x170001C8")]
		public override IEnumerable<AndroidManifestElementStyles> ChildStyles
		{
			[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x7350D8", Offset = "0x7350D8")]
			[Token(Token = "0x600065A")]
			[Address(RVA = "0xB55740", Offset = "0xB55740", Length = "0x70")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EC3460]);\n\tv15 = *([v14 @ X8_v7]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20227C7]) = v35;\nL_0014:\n\tv39 = new EasyMobile.ManifestGenerator.Elements.ActionElement+<get_ChildStyles>d__4();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0xFFFFFFFE;\n\tv44 = System.Environment::get_CurrentManagedThreadId();\n\tv39.<>l__initialThreadId = v44;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				_003Cget_ChildStyles_003Ed__4 _003Cget_ChildStyles_003Ed__5 = new _003Cget_ChildStyles_003Ed__4(-2);
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003Cget_ChildStyles_003Ed__5._003C_003El__initialThreadId = currentManagedThreadId;
				return _003Cget_ChildStyles_003Ed__5;
			}
		}

		[Token(Token = "0x170001C9")]
		public override IEnumerable<string> AllAvailableAttributes
		{
			[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x73513C", Offset = "0x73513C")]
			[Token(Token = "0x600065B")]
			[Address(RVA = "0xB557E8", Offset = "0xB557E8", Length = "0x70")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EDDB50]);\n\tv15 = *([v14 @ X8_v7]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20227C8]) = v35;\nL_0014:\n\tv39 = new EasyMobile.ManifestGenerator.Elements.ActionElement+<get_AllAvailableAttributes>d__6();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0xFFFFFFFE;\n\tv44 = System.Environment::get_CurrentManagedThreadId();\n\tv39.<>l__initialThreadId = v44;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				_003Cget_AllAvailableAttributes_003Ed__6 _003Cget_AllAvailableAttributes_003Ed__7 = new _003Cget_AllAvailableAttributes_003Ed__6(-2);
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003Cget_AllAvailableAttributes_003Ed__7._003C_003El__initialThreadId = currentManagedThreadId;
				return _003Cget_AllAvailableAttributes_003Ed__7;
			}
		}

		[Token(Token = "0x6000658")]
		[Address(RVA = "0xB55580", Offset = "0xB55580", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEasyMobile.ManifestGenerator.Elements.AndroidManifestElement::.ctor(this);\n\tv11 = this->klass;\n\tv16 = this->klass->vtable[5];\n\tv17 = this->klass->vtable[5];\n\t// 16 IndirectJump v16 @ X3_v1, this @ X0 (EasyMobile.ManifestGenerator.Elements.ActionElement), this @ X0 (EasyMobile.ManifestGenerator.Elements.ActionElement), 1, v17 @ X2_v1, v16 @ X3_v1, v19 @ X4, v20 @ X5, v21 @ X6, v22 @ X7, v23 @ V0, v24 @ V1, v25 @ V2, v26 @ V3, v27 @ V4, v28 @ V5, v29 @ V6, v30 @ V7\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ActionElement()
		{
			//IL_000b: Expected I, but got O
			//IL_001b: Expected O, but got I
			//IL_002b: Expected O, but got I
			base._002Ector();
			IntPtr intPtr = (IntPtr)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ X8_v1 (Il2CppClass<EasyMobile.ManifestGenerator.Elements.ActionElement>)+180]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ X8_v1 (Il2CppClass<EasyMobile.ManifestGenerator.Elements.ActionElement>)+188]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v16 @ X3_v1 (should have been resolved before IL gen)");
		}
	}
}
