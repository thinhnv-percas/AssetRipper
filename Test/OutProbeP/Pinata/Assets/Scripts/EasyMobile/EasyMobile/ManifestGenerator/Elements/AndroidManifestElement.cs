using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile.ManifestGenerator.Elements
{
	[Serializable]
	[Token(Token = "0x200009B")]
	public class AndroidManifestElement
	{
		[CompilerGenerated]
		[Token(Token = "0x2000157")]
		private sealed class _003Cget_ParentStyles_003Ed__13 : IEnumerable<AndroidManifestElementStyles>, IEnumerable, IEnumerator<AndroidManifestElementStyles>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000595")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x4000596")]
			[FieldOffset(Offset = "0x14")]
			private AndroidManifestElementStyles _003C_003E2__current;

			[Token(Token = "0x4000597")]
			[FieldOffset(Offset = "0x18")]
			internal int _003C_003El__initialThreadId;

			[Token(Token = "0x17000299")]
			AndroidManifestElementStyles IEnumerator<AndroidManifestElementStyles>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000A7E")]
				[Address(RVA = "0xB58820", Offset = "0xB58820", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x1700029A")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000A80")]
				[Address(RVA = "0xB5888C", Offset = "0xB5888C", Length = "0x64")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EBE8E0]);\n\tv19 = *([v18 @ X8_v5]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20227FF]) = v38;\nL_0014:\n\tv40 = this.<>2__current;\n\t// 25 Box returnVal1 @ X0_v3 (System.Object), typeof(EasyMobile.ManifestGenerator.Elements.AndroidManifestElementStyles), &v40 @ X8_v3 (EasyMobile.ManifestGenerator.Elements.AndroidManifestElementStyles)\n\treturn returnVal1;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					AndroidManifestElementStyles androidManifestElementStyles = _003C_003E2__current;
					return androidManifestElementStyles;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A7B")]
			[Address(RVA = "0xB56EF0", Offset = "0xB56EF0", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\tv16 = System.Environment::get_CurrentManagedThreadId();\n\tthis.<>l__initialThreadId = v16;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003Cget_ParentStyles_003Ed__13(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A7C")]
			[Address(RVA = "0xB58804", Offset = "0xB58804", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000A7D")]
			[Address(RVA = "0xB58808", Offset = "0xB58808", Length = "0x18")]
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
			[Token(Token = "0x6000A7F")]
			[Address(RVA = "0xB58828", Offset = "0xB58828", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1ED5B10]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([20227FE]) = v34;\nL_0014:\n\tv38 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw new TypeLoadException();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A81")]
			[Address(RVA = "0xB588F0", Offset = "0xB588F0", Length = "0x98")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EFC260]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022800]) = v38;\nL_0014:\n\tv40 = this.<>1__state + 2;\n\tv42 = v40 == 0;\n\tv45 = ~v42;\n\tif (v45) goto L_002E;\n\tv48 = System.Environment::get_CurrentManagedThreadId();\n\tv50 = this.<>l__initialThreadId != v48;\n\tif (v50) goto L_002E;\n\tthis.<>1__state = 0;\n\tgoto L_003C;\nL_002E:\n\tv76 = new EasyMobile.ManifestGenerator.Elements.AndroidManifestElement+<get_ParentStyles>d__13();\n\tSystem.Object::.ctor(v76);\n\tv76.<>1__state = 0;\n\tv81 = System.Environment::get_CurrentManagedThreadId();\n\tv76.<>l__initialThreadId = v81;\nL_003C:\n\treturn v93;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
				_003Cget_ParentStyles_003Ed__13 _003Cget_ParentStyles_003Ed__14 = null;
				_003Cget_ParentStyles_003Ed__14._003C_003E1__state = 0;
				int currentManagedThreadId2 = Environment.CurrentManagedThreadId;
				_003Cget_ParentStyles_003Ed__14._003C_003El__initialThreadId = currentManagedThreadId2;
				return _003Cget_ParentStyles_003Ed__14;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A82")]
			[Address(RVA = "0xB58988", Offset = "0xB58988", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = EasyMobile.ManifestGenerator.Elements.AndroidManifestElement+<get_ParentStyles>d__13::System.Collections.Generic.IEnumerable<EasyMobile.ManifestGenerator.Elements.AndroidManifestElementStyles>.GetEnumerator(this);\n\treturn returnVal1;\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<AndroidManifestElementStyles>)this).GetEnumerator();
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000158")]
		private sealed class _003Cget_ChildStyles_003Ed__15 : IEnumerable<AndroidManifestElementStyles>, IEnumerable, IEnumerator<AndroidManifestElementStyles>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000598")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x4000599")]
			[FieldOffset(Offset = "0x14")]
			private AndroidManifestElementStyles _003C_003E2__current;

			[Token(Token = "0x400059A")]
			[FieldOffset(Offset = "0x18")]
			internal int _003C_003El__initialThreadId;

			[Token(Token = "0x1700029B")]
			AndroidManifestElementStyles IEnumerator<AndroidManifestElementStyles>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000A86")]
				[Address(RVA = "0xB58698", Offset = "0xB58698", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x1700029C")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000A88")]
				[Address(RVA = "0xB58704", Offset = "0xB58704", Length = "0x64")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EAD490]);\n\tv19 = *([v18 @ X8_v5]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20227FC]) = v38;\nL_0014:\n\tv40 = this.<>2__current;\n\t// 25 Box returnVal1 @ X0_v3 (System.Object), typeof(EasyMobile.ManifestGenerator.Elements.AndroidManifestElementStyles), &v40 @ X8_v3 (EasyMobile.ManifestGenerator.Elements.AndroidManifestElementStyles)\n\treturn returnVal1;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					AndroidManifestElementStyles androidManifestElementStyles = _003C_003E2__current;
					return androidManifestElementStyles;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A83")]
			[Address(RVA = "0xB56F98", Offset = "0xB56F98", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\tv16 = System.Environment::get_CurrentManagedThreadId();\n\tthis.<>l__initialThreadId = v16;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003Cget_ChildStyles_003Ed__15(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A84")]
			[Address(RVA = "0xB5867C", Offset = "0xB5867C", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000A85")]
			[Address(RVA = "0xB58680", Offset = "0xB58680", Length = "0x18")]
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
			[Token(Token = "0x6000A87")]
			[Address(RVA = "0xB586A0", Offset = "0xB586A0", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EC5E80]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([20227FB]) = v34;\nL_0014:\n\tv38 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw new TypeLoadException();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A89")]
			[Address(RVA = "0xB58768", Offset = "0xB58768", Length = "0x98")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EE5A60]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20227FD]) = v38;\nL_0014:\n\tv40 = this.<>1__state + 2;\n\tv42 = v40 == 0;\n\tv45 = ~v42;\n\tif (v45) goto L_002E;\n\tv48 = System.Environment::get_CurrentManagedThreadId();\n\tv50 = this.<>l__initialThreadId != v48;\n\tif (v50) goto L_002E;\n\tthis.<>1__state = 0;\n\tgoto L_003C;\nL_002E:\n\tv76 = new EasyMobile.ManifestGenerator.Elements.AndroidManifestElement+<get_ChildStyles>d__15();\n\tSystem.Object::.ctor(v76);\n\tv76.<>1__state = 0;\n\tv81 = System.Environment::get_CurrentManagedThreadId();\n\tv76.<>l__initialThreadId = v81;\nL_003C:\n\treturn v93;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
				_003Cget_ChildStyles_003Ed__15 _003Cget_ChildStyles_003Ed__16 = null;
				_003Cget_ChildStyles_003Ed__16._003C_003E1__state = 0;
				int currentManagedThreadId2 = Environment.CurrentManagedThreadId;
				_003Cget_ChildStyles_003Ed__16._003C_003El__initialThreadId = currentManagedThreadId2;
				return _003Cget_ChildStyles_003Ed__16;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A8A")]
			[Address(RVA = "0xB58800", Offset = "0xB58800", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = EasyMobile.ManifestGenerator.Elements.AndroidManifestElement+<get_ChildStyles>d__15::System.Collections.Generic.IEnumerable<EasyMobile.ManifestGenerator.Elements.AndroidManifestElementStyles>.GetEnumerator(this);\n\treturn returnVal1;\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<AndroidManifestElementStyles>)this).GetEnumerator();
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000159")]
		private sealed class _003Cget_AllAvailableAttributes_003Ed__17 : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400059B")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x400059C")]
			[FieldOffset(Offset = "0x18")]
			private string _003C_003E2__current;

			[Token(Token = "0x400059D")]
			[FieldOffset(Offset = "0x20")]
			internal int _003C_003El__initialThreadId;

			[Token(Token = "0x1700029D")]
			string IEnumerator<string>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000A8E")]
				[Address(RVA = "0xB5856C", Offset = "0xB5856C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x1700029E")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000A90")]
				[Address(RVA = "0xB585D8", Offset = "0xB585D8", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A8B")]
			[Address(RVA = "0xB57040", Offset = "0xB57040", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\tv16 = System.Environment::get_CurrentManagedThreadId();\n\tthis.<>l__initialThreadId = v16;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003Cget_AllAvailableAttributes_003Ed__17(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A8C")]
			[Address(RVA = "0xB58550", Offset = "0xB58550", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000A8D")]
			[Address(RVA = "0xB58554", Offset = "0xB58554", Length = "0x18")]
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
			[Token(Token = "0x6000A8F")]
			[Address(RVA = "0xB58574", Offset = "0xB58574", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EF5360]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([20227F9]) = v34;\nL_0014:\n\tv38 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw new TypeLoadException();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A91")]
			[Address(RVA = "0xB585E0", Offset = "0xB585E0", Length = "0x98")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1F008A0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20227FA]) = v38;\nL_0014:\n\tv40 = this.<>1__state + 2;\n\tv42 = v40 == 0;\n\tv45 = ~v42;\n\tif (v45) goto L_002E;\n\tv48 = System.Environment::get_CurrentManagedThreadId();\n\tv50 = this.<>l__initialThreadId != v48;\n\tif (v50) goto L_002E;\n\tthis.<>1__state = 0;\n\tgoto L_003C;\nL_002E:\n\tv76 = new EasyMobile.ManifestGenerator.Elements.AndroidManifestElement+<get_AllAvailableAttributes>d__17();\n\tSystem.Object::.ctor(v76);\n\tv76.<>1__state = 0;\n\tv81 = System.Environment::get_CurrentManagedThreadId();\n\tv76.<>l__initialThreadId = v81;\nL_003C:\n\treturn v93;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
				_003Cget_AllAvailableAttributes_003Ed__17 _003Cget_AllAvailableAttributes_003Ed__18 = null;
				_003Cget_AllAvailableAttributes_003Ed__18._003C_003E1__state = 0;
				int currentManagedThreadId2 = Environment.CurrentManagedThreadId;
				_003Cget_AllAvailableAttributes_003Ed__18._003C_003El__initialThreadId = currentManagedThreadId2;
				return _003Cget_AllAvailableAttributes_003Ed__18;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A92")]
			[Address(RVA = "0xB58678", Offset = "0xB58678", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = EasyMobile.ManifestGenerator.Elements.AndroidManifestElement+<get_AllAvailableAttributes>d__17::System.Collections.Generic.IEnumerable<System.String>.GetEnumerator(this);\n\treturn returnVal1;\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<string>)this).GetEnumerator();
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200015A")]
		private sealed class _003Cget_RemainedAttributes_003Ed__19 : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400059E")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x400059F")]
			[FieldOffset(Offset = "0x18")]
			private string _003C_003E2__current;

			[Token(Token = "0x40005A0")]
			[FieldOffset(Offset = "0x20")]
			internal int _003C_003El__initialThreadId;

			[Token(Token = "0x40005A1")]
			[FieldOffset(Offset = "0x28")]
			public AndroidManifestElement _003C_003E4__this;

			[Token(Token = "0x40005A2")]
			[FieldOffset(Offset = "0x30")]
			private IEnumerator<string> _003C_003E7__wrap1;

			[Token(Token = "0x1700029F")]
			string IEnumerator<string>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000A97")]
				[Address(RVA = "0xB58D44", Offset = "0xB58D44", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x170002A0")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000A99")]
				[Address(RVA = "0xB58DB0", Offset = "0xB58DB0", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A93")]
			[Address(RVA = "0xB570FC", Offset = "0xB570FC", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\tv16 = System.Environment::get_CurrentManagedThreadId();\n\tthis.<>l__initialThreadId = v16;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003Cget_RemainedAttributes_003Ed__19(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A94")]
			[Address(RVA = "0xB5898C", Offset = "0xB5898C", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.<>1__state == 1;\n\tif (v6) goto L_0012;\n\tv11 = this.<>1__state + 3;\n\tv13 = v11 == 0;\n\tv16 = ~v13;\n\tif (v16) goto L_0014;\nL_0012:\n\tEasyMobile.ManifestGenerator.Elements.AndroidManifestElement+<get_RemainedAttributes>d__19::<>m__Finally1(this);\n\treturn;\nL_0014:\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IDisposable.Dispose()
			{
				if (_003C_003E1__state == 1 || _003C_003E1__state + 3 == 0)
				{
					_003C_003Em__Finally1();
				}
			}

			[Token(Token = "0x6000A95")]
			[Address(RVA = "0xB58A68", Offset = "0xB58A68", Length = "0x2DC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv28 = *([1EDF3B0]);\n\tv29 = *([v28 @ X8_v32]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2022801]) = v48;\nL_0019:\n\tv50 = this.<>4__this;\n\tv51 = this.<>1__state == 0;\n\tif (v51) goto L_002A;\n\tv61 = this.<>1__state != 1;\n\tif (v61) goto L_FFFFFFFF;\n\tv151 = this + 0x30;\n\tgoto L_006B;\nL_002A:\n\tthis.<>1__state = 0xFFFFFFFF;\n\tv125 = EasyMobile.ManifestGenerator.Elements.AndroidManifestElement::get_AllAvailableAttributes(v50);\n\tv127 = v125 == 0;\n\tif (v127) goto L_00EF;\n\tgoto L_0062;\n\tv389 = *([v306 @ X8_v26+B0]);\n\tv390 = 0;\n\tv391 = v389 + 8;\n\tv393 = *([v426 @ X11_v26-8]);\n\tv441 = v393 == v309;\n\tif (v441) goto L_005B;\n\tv397 = v427 + 1;\n\tv511 = v397 < v308;\n\tv415 = ~v511;\n\tv395 = v426 + 0x10;\n\tv399 = ~v415;\n\tif (v399) goto L_FFFFFFFF;\n\tv416 = v126;\n\tv417 = 0;\n\tv418 = 0x8909C4(v416, v309, v417, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_0062;\nL_005B:\n\tv512 = *([v426 @ X11_v26]);\n\tv513 = v512 << 4;\n\tv514 = v306 + v513;\n\tv515 = v514 + 0x130;\nL_0062:\n\tv222 = System.Collections.Generic.IEnumerable`1<System.String>::GetEnumerator(v125);\n\tv151 = this + 0x30;\n\tthis.<>7__wrap1 = v222;\nL_006B:\n\tthis.<>1__state = 0xFFFFFFFD;\nL_0075:\n\tgoto L_009C;\n\tv456 = *([v419 @ X8_v11+B0]);\n\tv457 = 0;\n\tv458 = v456 + 8;\n\tv460 = *([v523 @ X11_v17-8]);\n\tv538 = v460 == v420;\n\tif (v538) goto L_0095;\n\tv464 = v524 + 1;\n\tv572 = v464 < v421;\n\tv482 = ~v572;\n\tv462 = v523 + 0x10;\n\tv466 = ~v482;\n\tif (v466) goto L_FFFFFFFF;\n\tv483 = v251;\n\tv484 = 0;\n\tv485 = 0x8909C4(v483, v420, v484, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_009C;\nL_0095:\n\tv573 = *([v523 @ X11_v17]);\n\tv574 = v573 << 4;\n\tv575 = v419 + v574;\n\tv576 = v575 + 0x130;\nL_009C:\n\tv505 = System.Collections.IEnumerator::MoveNext(*([v151 @ X22_v3]));\n\tv291 = v505 == 0;\n\tif (v291) goto L_00E1;\n\tgoto L_00CE;\n\tv609 = *([v603 @ X8_v14+B0]);\n\tv610 = 0;\n\tv611 = v609 + 8;\n\tv613 = *([v640 @ X11_v12-8]);\n\tv655 = v613 == v604;\n\tif (v655) goto L_00C7;\n\tv617 = v641 + 1;\n\tv660 = v617 < v605;\n\tv635 = ~v660;\n\tv615 = v640 + 0x10;\n\tv619 = ~v635;\n\tif (v619) goto L_FFFFFFFF;\n\tv636 = v492;\n\tv637 = 0;\n\tv638 = 0x8909C4(v636, v604, v637, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_00CE;\nL_00C7:\n\tv661 = *([v640 @ X11_v12]);\n\tv662 = v661 << 4;\n\tv663 = v603 + v662;\n\tv664 = v663 + 0x130;\nL_00CE:\n\tv563 = System.Collections.Generic.IEnumerator`1<System.String>::get_Current(*([v151 @ X22_v3]));\n\tv342 = System.Collections.Generic.List`1<System.String>::Contains(v50.addedAttributesKey, v563);\n\tv669 = v342 == 0;\n\tv290 = ~v669;\n\tif (v290) goto L_0075;\n\tthis.<>2__current = v563;\n\tthis.<>1__state = 1;\n\tgoto L_0129;\nL_00E1:\n\tEasyMobile.ManifestGenerator.Elements.AndroidManifestElement+<get_RemainedAttributes>d__19::<>m__Finally1(this);\n\t*([v151 @ X22_v3]) = 0;\n\tgoto L_0129;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tv568 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\nL_00EF:\n\tv323 = new System.NullReferenceException();\n\tgoto L_0102;\n\tgoto L_0102;\n\tgoto L_0102;\n\tgoto L_0102;\n\tgoto L_0102;\n\tgoto L_0102;\n\tgoto L_0102;\n\tgoto L_0102;\n\tgoto L_0102;\nL_0102:\n\tv455 = v88 != 1;\n\tif (v455) goto L_012A;\n\tv520 = 0x6D2BC0(v323, v88, v78, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv569 = 0x6D2490(v520, v88, v78, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv587 = this.<>1__state == 1;\n\tif (v587) goto L_011A;\n\tv590 = this.<>1__state + 3;\n\tv592 = v590 == 0;\n\tv595 = ~v592;\n\tif (v595) goto L_011B;\nL_011A:\n\tEasyMobile.ManifestGenerator.Elements.AndroidManifestElement+<get_RemainedAttributes>d__19::<>m__Finally1(this);\nL_011B:\n\tv608 = *([v520 @ X0_v41]) == 0;\n\tv115 = ~v608;\n\tif (v115) goto L_012E;\nL_0129:\n\treturn returnVal1;\nL_012A:\n\tv521 = 0x6D2380(v323, v88, v78, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_012E:\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 173 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				//IL_0033: Expected O, but got I
				//IL_025e: Expected O, but got I
				//IL_020c: Expected I4, but got O
				//IL_00f3: Expected O, but got I4
				AndroidManifestElement androidManifestElement = _003C_003E4__this;
				object obj;
				if (_003C_003E1__state != 0)
				{
					if (_003C_003E1__state != 1)
					{
						goto IL_01dc;
					}
					obj = (long)(IntPtr)this + 48L;
				}
				else
				{
					_003C_003E1__state = -1;
					IEnumerable<string> allAvailableAttributes = androidManifestElement.AllAvailableAttributes;
					if (allAvailableAttributes == null)
					{
						NullReferenceException ex = new NullReferenceException();
						object obj2 = default(object);
						if ((IntPtr)obj2 == (IntPtr)1)
						{
							Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
							Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
							if (_003C_003E1__state == 1 || _003C_003E1__state + 3 == 0)
							{
								_003C_003Em__Finally1();
							}
							object obj3 = default(object);
							if (obj3 == null)
							{
								goto IL_01dc;
							}
						}
						else
						{
							Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
						}
						TypeLoadException ex2 = new TypeLoadException();
						return (byte)(int)ex2 != 0;
					}
					IEnumerator<string> enumerator = allAvailableAttributes.GetEnumerator();
					obj = (long)(IntPtr)this + 48L;
					_003C_003E7__wrap1 = enumerator;
				}
				_003C_003E1__state = -3;
				while (((IEnumerator)obj).MoveNext())
				{
					string current = ((IEnumerator<string>)obj).Current;
					if (androidManifestElement.AddedAttributesKey.Contains(current))
					{
						continue;
					}
					_003C_003E2__current = current;
					_003C_003E1__state = 1;
					return true;
				}
				_003C_003Em__Finally1();
				obj = 0;
				return false;
				IL_01dc:
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[Token(Token = "0x6000A96")]
			[Address(RVA = "0xB589A8", Offset = "0xB589A8", Length = "0xC0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EBE878]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022802]) = v38;\nL_0015:\n\tthis.<>1__state = 0xFFFFFFFF;\n\tv41 = this.<>7__wrap1 == 0;\n\tif (v41) goto L_0043;\n\tgoto L_0050;\n\tv52 = *([v43 @ X8_v4+B0]);\n\tv53 = 0;\n\tv54 = v52 + 8;\n\tv56 = *([v151 @ X11_v5-8]);\n\tv157 = v56 == v46;\n\tif (v157) goto L_0044;\n\tv89 = v152 + 1;\n\tv162 = v89 < v45;\n\tv83 = ~v162;\n\tv86 = v151 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_FFFFFFFF;\n\tv90 = v39;\n\tv91 = 0;\n\tv92 = 0x8909C4(v90, v46, v91, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0050;\nL_0043:\n\treturn;\nL_0044:\n\tv163 = *([v151 @ X11_v5]);\n\tv164 = v163 << 4;\n\tv165 = v43 + v164;\n\tv166 = v165 + 0x130;\nL_0050:\n\tSystem.IDisposable::Dispose(this.<>7__wrap1);\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private void _003C_003Em__Finally1()
			{
				_003C_003E1__state = -1;
				if (_003C_003E7__wrap1 != null)
				{
					_003C_003E7__wrap1.Dispose();
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A98")]
			[Address(RVA = "0xB58D4C", Offset = "0xB58D4C", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1ECAEA8]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([2022803]) = v34;\nL_0014:\n\tv38 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw new TypeLoadException();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A9A")]
			[Address(RVA = "0xB58DB8", Offset = "0xB58DB8", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EFC238]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022804]) = v38;\nL_0014:\n\tv40 = this.<>1__state + 2;\n\tv42 = v40 == 0;\n\tv45 = ~v42;\n\tif (v45) goto L_002E;\n\tv48 = System.Environment::get_CurrentManagedThreadId();\n\tv50 = this.<>l__initialThreadId != v48;\n\tif (v50) goto L_002E;\n\tthis.<>1__state = 0;\n\tgoto L_0041;\nL_002E:\n\tv76 = new EasyMobile.ManifestGenerator.Elements.AndroidManifestElement+<get_RemainedAttributes>d__19();\n\tSystem.Object::.ctor(v76);\n\tv76.<>1__state = 0;\n\tv81 = System.Environment::get_CurrentManagedThreadId();\n\tv76.<>l__initialThreadId = v81;\n\tv76.<>4__this = this.<>4__this;\nL_0041:\n\treturn v95;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
				_003Cget_RemainedAttributes_003Ed__19 _003Cget_RemainedAttributes_003Ed__20 = null;
				_003Cget_RemainedAttributes_003Ed__20._003C_003E1__state = 0;
				int currentManagedThreadId2 = Environment.CurrentManagedThreadId;
				_003Cget_RemainedAttributes_003Ed__20._003C_003El__initialThreadId = currentManagedThreadId2;
				_003Cget_RemainedAttributes_003Ed__20._003C_003E4__this = _003C_003E4__this;
				return _003Cget_RemainedAttributes_003Ed__20;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000A9B")]
			[Address(RVA = "0xB58E68", Offset = "0xB58E68", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = EasyMobile.ManifestGenerator.Elements.AndroidManifestElement+<get_RemainedAttributes>d__19::System.Collections.Generic.IEnumerable<System.String>.GetEnumerator(this);\n\treturn returnVal1;\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<string>)this).GetEnumerator();
			}
		}

		[SerializeField]
		[Token(Token = "0x400037F")]
		[FieldOffset(Offset = "0x10")]
		private List<string> addedAttributesKey;

		[SerializeField]
		[Token(Token = "0x4000380")]
		[FieldOffset(Offset = "0x18")]
		private List<string> addedAttributesValue;

		[SerializeField]
		[Token(Token = "0x4000381")]
		[FieldOffset(Offset = "0x20")]
		private List<string> addedAttributesPrefix;

		[SerializeField]
		[Token(Token = "0x4000382")]
		[FieldOffset(Offset = "0x28")]
		private List<int> childElementsId;

		[SerializeField]
		[Token(Token = "0x4000383")]
		[FieldOffset(Offset = "0x30")]
		private int id;

		[SerializeField]
		[Token(Token = "0x4000384")]
		[FieldOffset(Offset = "0x34")]
		private AndroidManifestElementStyles style;

		[Token(Token = "0x170001D3")]
		public virtual AndroidManifestElementStyles Style
		{
			[Token(Token = "0x6000668")]
			[Address(RVA = "0xB56E60", Offset = "0xB56E60", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.style;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Style;
			}
			[Token(Token = "0x6000669")]
			[Address(RVA = "0xB56E68", Offset = "0xB56E68", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.style = value;\n\treturn;\n")]
			protected internal set
			{
				style = value;
			}
		}

		[Token(Token = "0x170001D4")]
		public int Id
		{
			[Token(Token = "0x600066A")]
			[Address(RVA = "0xB56E70", Offset = "0xB56E70", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.id;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Id;
			}
			[Token(Token = "0x600066B")]
			[Address(RVA = "0xB56E78", Offset = "0xB56E78", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.id = value;\n\treturn;\n")]
			set
			{
				Id = value;
			}
		}

		[Token(Token = "0x170001D5")]
		public virtual IEnumerable<AndroidManifestElementStyles> ParentStyles
		{
			[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x735524", Offset = "0x735524")]
			[Token(Token = "0x600066C")]
			[Address(RVA = "0xB56E80", Offset = "0xB56E80", Length = "0x70")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EF4C10]);\n\tv15 = *([v14 @ X8_v7]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20227EA]) = v35;\nL_0014:\n\tv39 = new EasyMobile.ManifestGenerator.Elements.AndroidManifestElement+<get_ParentStyles>d__13();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0xFFFFFFFE;\n\tv44 = System.Environment::get_CurrentManagedThreadId();\n\tv39.<>l__initialThreadId = v44;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				_003Cget_ParentStyles_003Ed__13 _003Cget_ParentStyles_003Ed__14 = new _003Cget_ParentStyles_003Ed__13(-2);
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003Cget_ParentStyles_003Ed__14._003C_003El__initialThreadId = currentManagedThreadId;
				return _003Cget_ParentStyles_003Ed__14;
			}
		}

		[Token(Token = "0x170001D6")]
		public virtual IEnumerable<AndroidManifestElementStyles> ChildStyles
		{
			[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x735588", Offset = "0x735588")]
			[Token(Token = "0x600066D")]
			[Address(RVA = "0xB56F28", Offset = "0xB56F28", Length = "0x70")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EEA2E0]);\n\tv15 = *([v14 @ X8_v7]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20227EB]) = v35;\nL_0014:\n\tv39 = new EasyMobile.ManifestGenerator.Elements.AndroidManifestElement+<get_ChildStyles>d__15();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0xFFFFFFFE;\n\tv44 = System.Environment::get_CurrentManagedThreadId();\n\tv39.<>l__initialThreadId = v44;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				_003Cget_ChildStyles_003Ed__15 _003Cget_ChildStyles_003Ed__16 = new _003Cget_ChildStyles_003Ed__15(-2);
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003Cget_ChildStyles_003Ed__16._003C_003El__initialThreadId = currentManagedThreadId;
				return _003Cget_ChildStyles_003Ed__16;
			}
		}

		[Token(Token = "0x170001D7")]
		public virtual IEnumerable<string> AllAvailableAttributes
		{
			[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x7355EC", Offset = "0x7355EC")]
			[Token(Token = "0x600066E")]
			[Address(RVA = "0xB56FD0", Offset = "0xB56FD0", Length = "0x70")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EE73D0]);\n\tv15 = *([v14 @ X8_v7]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20227EC]) = v35;\nL_0014:\n\tv39 = new EasyMobile.ManifestGenerator.Elements.AndroidManifestElement+<get_AllAvailableAttributes>d__17();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0xFFFFFFFE;\n\tv44 = System.Environment::get_CurrentManagedThreadId();\n\tv39.<>l__initialThreadId = v44;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				_003Cget_AllAvailableAttributes_003Ed__17 _003Cget_AllAvailableAttributes_003Ed__18 = new _003Cget_AllAvailableAttributes_003Ed__17(-2);
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003Cget_AllAvailableAttributes_003Ed__18._003C_003El__initialThreadId = currentManagedThreadId;
				return _003Cget_AllAvailableAttributes_003Ed__18;
			}
		}

		[Token(Token = "0x170001D8")]
		public virtual IEnumerable<string> RemainedAttributes
		{
			[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x735650", Offset = "0x735650")]
			[Token(Token = "0x600066F")]
			[Address(RVA = "0xB57078", Offset = "0xB57078", Length = "0x84")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EF01B8]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20227ED]) = v38;\nL_0016:\n\tv42 = new EasyMobile.ManifestGenerator.Elements.AndroidManifestElement+<get_RemainedAttributes>d__19();\n\tSystem.Object::.ctor(v42);\n\tv42.<>1__state = 0xFFFFFFFE;\n\tv47 = System.Environment::get_CurrentManagedThreadId();\n\tv42.<>l__initialThreadId = v47;\n\tv42.<>4__this = this;\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				_003Cget_RemainedAttributes_003Ed__19 _003Cget_RemainedAttributes_003Ed__20 = new _003Cget_RemainedAttributes_003Ed__19(-2);
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003Cget_RemainedAttributes_003Ed__20._003C_003El__initialThreadId = currentManagedThreadId;
				_003Cget_RemainedAttributes_003Ed__20._003C_003E4__this = this;
				return _003Cget_RemainedAttributes_003Ed__20;
			}
		}

		[Token(Token = "0x170001D9")]
		public List<string> AddedAttributesKey
		{
			[Token(Token = "0x6000670")]
			[Address(RVA = "0xB57134", Offset = "0xB57134", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.addedAttributesKey;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AddedAttributesKey;
			}
		}

		[Token(Token = "0x170001DA")]
		public List<string> AddedAttributesValue
		{
			[Token(Token = "0x6000671")]
			[Address(RVA = "0xB5713C", Offset = "0xB5713C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.addedAttributesValue;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AddedAttributesValue;
			}
		}

		[Token(Token = "0x170001DB")]
		public List<string> AddedAttributesPrefix
		{
			[Token(Token = "0x6000672")]
			[Address(RVA = "0xB57144", Offset = "0xB57144", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.addedAttributesPrefix;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AddedAttributesPrefix;
			}
		}

		[Token(Token = "0x170001DC")]
		public int AttributesCount
		{
			[Token(Token = "0x6000673")]
			[Address(RVA = "0xB5714C", Offset = "0xB5714C", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EF3140]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20227EE]) = v38;\nL_0013:\n\tv39 = this.addedAttributesKey;\n\tv41 = this.addedAttributesValue;\n\tv54 = v39._size - v41._size;\n\tv56 = v54 == 0;\n\tv61 = ~v56;\n\tv62 = ~v61;\n\tif (v62) goto L_FFFFFFFF;\n\tgoto L_0030;\nL_0030:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				List<string> list = AddedAttributesKey;
				List<string> list2 = AddedAttributesValue;
				if (list.Count - list2.Count != 0)
				{
					return 0;
				}
				return list.Count;
			}
		}

		[Token(Token = "0x170001DD")]
		public List<int> ChildElementsId
		{
			[Token(Token = "0x6000674")]
			[Address(RVA = "0xB571B4", Offset = "0xB571B4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.childElementsId;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ChildElementsId;
			}
		}

		[Token(Token = "0x170001DE")]
		public bool CanAddChildElement
		{
			[Token(Token = "0x6000675")]
			[Address(RVA = "0xB571BC", Offset = "0xB571BC", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1ED8170]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20227EF]) = v38;\nL_0017:\n\tv43 = EasyMobile.ManifestGenerator.Elements.AndroidManifestElement::get_ChildStyles(this);\n\treturnVal1 = System.Linq.Enumerable::Any(v43);\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				IEnumerable<AndroidManifestElementStyles> childStyles = ChildStyles;
				return childStyles.Any();
			}
		}

		[Token(Token = "0x6000676")]
		[Address(RVA = "0xB555B0", Offset = "0xB555B0", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EE2B00]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20227F0]) = v42;\nL_0018:\n\tv46 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v46);\n\tthis.addedAttributesKey = v46;\n\tv52 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v52);\n\tthis.addedAttributesValue = v52;\n\tv56 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v56);\n\tthis.addedAttributesPrefix = v56;\n\tv62 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v62);\n\tthis.childElementsId = v62;\n\tSystem.Object::.ctor(this);\n\tv73 = System.Object::GetHashCode(this);\n\tthis.id = v73;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AndroidManifestElement()
		{
			List<string> list = new List<string>();
			addedAttributesKey = list;
			List<string> list2 = new List<string>();
			addedAttributesValue = list2;
			List<string> list3 = new List<string>();
			addedAttributesPrefix = list3;
			List<int> list4 = new List<int>();
			childElementsId = list4;
			int hashCode = base.GetHashCode();
			Id = hashCode;
		}

		[Token(Token = "0x6000677")]
		[Address(RVA = "0xB57218", Offset = "0xB57218", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EB0AC0]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, key, value, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20227F1]) = v44;\nL_0019:\n\tv47 = EasyMobile.ManifestGenerator.Elements.AndroidManifestElement::IsAvailableAttribute(this, key);\n\tv49 = v47 == 0;\n\tif (v49) goto L_FFFFFFFF;\n\tSystem.Collections.Generic.List`1<System.String>::Add(this.addedAttributesKey, key);\n\tSystem.Collections.Generic.List`1<System.String>::Add(this.addedAttributesValue, value);\n\tv107 = EasyMobile.ManifestGenerator.Elements.AndroidManifestElementStyleExtension::IsAndroidAttribute(key);\n\tv79 = v107 == 0;\n\tv70 = ~v79;\n\tv67 = ~v70;\n\tif (v67) goto L_FFFFFFFF;\n\tgoto L_0041;\nL_0041:\n\tSystem.Collections.Generic.List`1<System.String>::Add(this.addedAttributesPrefix, v86);\n\tgoto L_004C;\nL_004C:\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool AddAttribute(string key, string value)
		{
			if (IsAvailableAttribute(key))
			{
				AddedAttributesKey.Add(key);
				AddedAttributesValue.Add(value);
				string item = ((!key.IsAndroidAttribute()) ? null : "http://schemas.android.com/apk/res/android");
				AddedAttributesPrefix.Add(item);
				return true;
			}
			return false;
		}

		[Token(Token = "0x6000678")]
		[Address(RVA = "0xB5765C", Offset = "0xB5765C", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EBAF98]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, element, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20227F2]) = v41;\nL_001B:\n\tv47 = EasyMobile.ManifestGenerator.Elements.AndroidManifestElement::get_Style(element);\n\tv50 = EasyMobile.ManifestGenerator.Elements.AndroidManifestElement::IsAvailableInnerElement(this, v47);\n\tv53 = v50 == 0;\n\tif (v53) goto L_FFFFFFFF;\n\tSystem.Collections.Generic.List`1<System.Int32>::Add(this.childElementsId, element.id);\n\tgoto L_0033;\nL_0033:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool AddInnerElement(AndroidManifestElement element)
		{
			AndroidManifestElementStyles androidManifestElementStyles = element.Style;
			if (IsAvailableInnerElement(androidManifestElementStyles))
			{
				ChildElementsId.Add(element.Id);
				return true;
			}
			return false;
		}

		[Token(Token = "0x6000679")]
		[Address(RVA = "0xB57A74", Offset = "0xB57A74", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = EasyMobile.ManifestGenerator.Elements.AndroidManifestElementStyleExtension::CreateElementClass(style);\n\treturnVal1 = EasyMobile.ManifestGenerator.Elements.AndroidManifestElement::AddInnerElement(this, v12);\n\treturn returnVal1;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool AddInnerElement(AndroidManifestElementStyles style)
		{
			AndroidManifestElement element = style.CreateElementClass();
			return AddInnerElement(element);
		}

		[Token(Token = "0x600067A")]
		[Address(RVA = "0xB57E84", Offset = "0xB57E84", Length = "0x2E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv36 = *([1EA48E0]);\n\tv37 = *([v36 @ X8_v39]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, xmlDocument, elementsFactory, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([20227F3]) = v54;\nL_001E:\n\tv57 = 0;\n\tv62 = EasyMobile.ManifestGenerator.Elements.AndroidManifestElement::ToString(this);\n\tv67 = System.Xml.XmlDocument::CreateElement(xmlDocument, v62);\n\tv206 = EasyMobile.ManifestGenerator.Elements.AndroidManifestElement::get_AttributesCount(this);\n\tv269 = v206 < 1;\n\tif (v269) goto L_00D5;\nL_003A:\n\tv91 = this.addedAttributesPrefix;\n\tv411 = v91._size < v104;\n\tv171 = ~v411;\n\tv163 = v91._size - v104;\n\tv147 = v163 == 0;\n\tv412 = ~v147;\n\tv107 = v171 & v412;\n\tif (v107) goto L_004C;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_004C:\n\tv458 = v91._items;\n\tv181 = System.String::IsNullOrEmpty(v458[v104 @ X25_v8 (System.Int32)]);\n\tv92 = this.addedAttributesKey;\n\tv477 = v92._size < v104;\n\tv172 = ~v477;\n\tv164 = v92._size - v104;\n\tv148 = v164 == 0;\n\tv478 = ~v148;\n\tv108 = v172 & v478;\n\tif (v108) goto L_0066;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0066:\n\tv482 = v92._items;\n\tv484 = v181 == 0;\n\tif (v484) goto L_008C;\n\tv87 = this.addedAttributesValue;\n\tv488 = v87._size < v104;\n\tv173 = ~v488;\n\tv165 = v87._size - v104;\n\tv149 = v165 == 0;\n\tv489 = ~v149;\n\tv109 = v173 & v489;\n\tif (v109) goto L_0081;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0081:\n\tv495 = v87._items;\n\tv504 = System.Xml.XmlElement::SetAttribute(v67, v482[v104 @ X25_v8 (System.Int32)], v495[v104 @ X25_v8 (System.Int32)]);\n\tgoto L_00C2;\nL_008C:\n\tv88 = this.addedAttributesPrefix;\n\tv490 = v88._size < v104;\n\tv174 = ~v490;\n\tv166 = v88._size - v104;\n\tv150 = v166 == 0;\n\tv491 = ~v150;\n\tv110 = v174 & v491;\n\tif (v110) goto L_009E;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_009E:\n\tv72 = this.addedAttributesValue;\n\tv505 = v88._items;\n\tv506 = v72._size < v104;\n\tv175 = ~v506;\n\tv167 = v72._size - v104;\n\tv151 = v167 == 0;\n\tv507 = ~v151;\n\tv111 = v175 & v507;\n\tif (v111) goto L_00B6;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_00B6:\n\tv531 = v72._items;\n\tv525 = System.Xml.XmlElement::SetAttribute(v67, v482[v104 @ X25_v8 (System.Int32)], v505[v104 @ X25_v8 (System.Int32)], v531[v104 @ X25_v8 (System.Int32)]);\nL_00C2:\n\tv104 = v104 + 1;\n\tv335 = EasyMobile.ManifestGenerator.Elements.AndroidManifestElement::get_AttributesCount(this);\n\tv315 = v104 < v335;\n\tif (v315) goto L_003A;\nL_00D5:\n\tv345 = EasyMobile.ManifestGenerator.Elements.AndroidManifestElement::GetChildElements(this, elementsFactory);\n\tv346 = v345 == 0;\n\tif (v346) goto L_0133;\n\tv230 = v345._size < 1;\n\tif (v230) goto L_0133;\n\tv417 = System.Collections.Generic.List`1<EasyMobile.ManifestGenerator.Elements.AndroidManifestElement>::GetEnumerator(v345);\nL_00EE:\n\tv473 = System.Collections.Generic.List`1<EasyMobile.ManifestGenerator.Elements.AndroidManifestElement>+Enumerator<EasyMobile.ManifestGenerator.Elements.AndroidManifestElement>::MoveNext(&v57 @ stack_-78_v1 (System.Collections.Generic.List`1<EasyMobile.ManifestGenerator.Elements.AndroidManifestElement>+Enumerator<EasyMobile.ManifestGenerator.Elements.AndroidManifestElement>));\n\tv389 = v473 == 0;\n\tif (v389) goto L_0105;\n\tv294 = EasyMobile.ManifestGenerator.Elements.AndroidManifestElement::ToXmlElement(0, xmlDocument, elementsFactory);\n\tv296 = v67 == 0;\n\tif (v296) goto L_010B;\n\tv469 = System.Xml.XmlNode::AppendChild(v67, v294);\n\tgoto L_00EE;\nL_0105:\n\tv386 = System.Collections.Generic.List`1<EasyMobile.ManifestGenerator.Elements.AndroidManifestElement>+Enumerator<EasyMobile.ManifestGenerator.Elements.AndroidManifestElement>::Dispose(&v57 @ stack_-78_v1 (System.Collections.Generic.List`1<EasyMobile.ManifestGenerator.Elements.AndroidManifestElement>+Enumerator<EasyMobile.ManifestGenerator.Elements.AndroidManifestElement>));\n\tgoto L_0133;\n\tv204 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_010B:\n\tv301 = new System.NullReferenceException();\n\tgoto L_0119;\n\tgoto L_0119;\n\tgoto L_0119;\n\tgoto L_0119;\nL_0119:\n\tv366 = v279 != 1;\n\tif (v366) goto L_0134;\n\tv454 = 0x6D2BC0(v301, v279, v291, v272, v270, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv461 = 0x6D2490(v454, v279, v291, v272, v270, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv385 = System.Collections.Generic.List`1<EasyMobile.ManifestGenerator.Elements.AndroidManifestElement>+Enumerator<EasyMobile.ManifestGenerator.Elements.AndroidManifestElement>::Dispose(&v57 @ stack_-78_v1 (System.Collections.Generic.List`1<EasyMobile.ManifestGenerator.Elements.AndroidManifestElement>+Enumerator<EasyMobile.ManifestGenerator.Elements.AndroidManifestElement>));\n\tv480 = *([v454 @ X0_v13]) == 0;\n\tv388 = ~v480;\n\tif (v388) goto L_0138;\nL_0133:\n\treturn v396;\nL_0134:\n\tv455 = 0x6D2380(v301, v279, v291, v272, v270, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0138:\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 207 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public XmlElement ToXmlElement(XmlDocument xmlDocument, List<AndroidManifestElement> elementsFactory)
		{
			List<AndroidManifestElement>.Enumerator enumerator = default(List<AndroidManifestElement>.Enumerator);
			string name = ToString();
			XmlElement xmlElement = xmlDocument.CreateElement(name);
			int attributesCount = AttributesCount;
			if (attributesCount >= 1)
			{
				int num = 0;
				int attributesCount2;
				do
				{
					List<string> list = AddedAttributesPrefix;
					bool flag = list.Count < num;
					bool flag2 = !flag;
					int num2 = list.Count - num;
					bool flag3 = num2 == 0;
					bool flag4 = !flag3;
					if (!(flag2 && flag4))
					{
						throw new ArgumentOutOfRangeException();
					}
					string[] items = list._items;
					bool flag5 = string.IsNullOrEmpty(items[num]);
					List<string> list2 = AddedAttributesKey;
					bool flag6 = list2.Count < num;
					bool flag7 = !flag6;
					int num3 = list2.Count - num;
					bool flag8 = num3 == 0;
					bool flag9 = !flag8;
					if (!(flag7 && flag9))
					{
						throw new ArgumentOutOfRangeException();
					}
					string[] items2 = list2._items;
					if (flag5)
					{
						List<string> list3 = AddedAttributesValue;
						bool flag10 = list3.Count < num;
						bool flag11 = !flag10;
						int num4 = list3.Count - num;
						bool flag12 = num4 == 0;
						bool flag13 = !flag12;
						if (!(flag11 && flag13))
						{
							throw new ArgumentOutOfRangeException();
						}
						string[] items3 = list3._items;
						xmlElement.SetAttribute(items2[num], items3[num]);
					}
					else
					{
						List<string> list4 = AddedAttributesPrefix;
						bool flag14 = list4.Count < num;
						bool flag15 = !flag14;
						int num5 = list4.Count - num;
						bool flag16 = num5 == 0;
						bool flag17 = !flag16;
						if (!(flag15 && flag17))
						{
							throw new ArgumentOutOfRangeException();
						}
						List<string> list5 = AddedAttributesValue;
						string[] items4 = list4._items;
						bool flag18 = list5.Count < num;
						bool flag19 = !flag18;
						int num6 = list5.Count - num;
						bool flag20 = num6 == 0;
						bool flag21 = !flag20;
						if (!(flag19 && flag21))
						{
							throw new ArgumentOutOfRangeException();
						}
						string[] items5 = list5._items;
						string text = xmlElement.SetAttribute(items2[num], items4[num], items5[num]);
					}
					num++;
					attributesCount2 = AttributesCount;
				}
				while (num < attributesCount2);
			}
			List<AndroidManifestElement> childElements = GetChildElements(elementsFactory);
			bool flag22 = childElements == null;
			XmlElement result = xmlElement;
			if (!flag22)
			{
				bool flag23 = childElements.Count < 1;
				result = xmlElement;
				if (!flag23)
				{
					List<AndroidManifestElement>.Enumerator enumerator2 = childElements.GetEnumerator();
					XmlElement xmlElement2 = default(XmlElement);
					object obj = default(object);
					XmlElement xmlElement3 = default(XmlElement);
					while (true)
					{
						if (enumerator.MoveNext())
						{
							XmlElement newChild = ((AndroidManifestElement)null).ToXmlElement(xmlDocument, elementsFactory);
							if (xmlElement != null)
							{
								XmlNode xmlNode = xmlElement.AppendChild(newChild);
								continue;
							}
							NullReferenceException ex = new NullReferenceException();
							if ((IntPtr)xmlElement2 == (IntPtr)1)
							{
								Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
								Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
								enumerator.Dispose();
								bool flag24 = obj == null;
								bool flag25 = !flag24;
								result = xmlElement3;
								if (!flag25)
								{
									break;
								}
							}
							else
							{
								Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
							}
							return (XmlElement)(object)new TypeLoadException();
						}
						enumerator.Dispose();
						result = xmlElement;
						break;
					}
				}
			}
			return result;
		}

		[Token(Token = "0x600067B")]
		[Address(RVA = "0xB5816C", Offset = "0xB5816C", Length = "0x228")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv36 = *([1ED4770]);\n\tv37 = *([v36 @ X8_v26]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, elementsFactory, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([20227F4]) = v55;\nL_0020:\n\tv60 = this.childElementsId == 0;\n\tif (v60) goto L_FFFFFFFF;\n\tv64 = new System.Collections.Generic.List`1<EasyMobile.ManifestGenerator.Elements.AndroidManifestElement>();\n\tSystem.Collections.Generic.List`1<EasyMobile.ManifestGenerator.Elements.AndroidManifestElement>::.ctor(v64);\n\tv173 = this.childElementsId == 0;\n\tif (v173) goto L_007B;\n\tv216 = System.Collections.Generic.List`1<System.Int32>::GetEnumerator(this.childElementsId);\nL_0045:\n\tv256 = System.Collections.Generic.List`1<System.Int32>+Enumerator<System.Int32>::MoveNext(&v140 @ stack_-98_v3 (System.Collections.Generic.List`1<System.Int32>+Enumerator<System.Int32>));\n\tv149 = v256 == 0;\n\tif (v149) goto L_0073;\n\tv262 = new EasyMobile.ManifestGenerator.Elements.AndroidManifestElement+<>c__DisplayClass37_0();\n\tSystem.Object::.ctor(v262);\n\tv262.childElementId = v231;\n\tv277 = new System.Predicate`1<EasyMobile.ManifestGenerator.Elements.AndroidManifestElement>();\n\tSystem.Predicate`1<EasyMobile.ManifestGenerator.Elements.AndroidManifestElement>::.ctor(v277, v262, Il2CppMethodInfo);\n\tv247 = System.Collections.Generic.List`1<EasyMobile.ManifestGenerator.Elements.AndroidManifestElement>::Find(elementsFactory, v277);\n\tv250 = v247 == 0;\n\tif (v250) goto L_0045;\n\tSystem.Collections.Generic.List`1<EasyMobile.ManifestGenerator.Elements.AndroidManifestElement>::Add(v64, v247);\n\tgoto L_0045;\n\tgoto L_00A7;\nL_0073:\n\tv146 = System.Collections.Generic.List`1<System.Int32>+Enumerator<System.Int32>::Dispose(&v140 @ stack_-98_v3 (System.Collections.Generic.List`1<System.Int32>+Enumerator<System.Int32>));\n\tgoto L_00A7;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tv223 = new System.NullReferenceException();\nL_007B:\n\tv229 = new System.NullReferenceException();\n\tgoto L_008C;\n\tgoto L_008C;\n\tgoto L_008C;\n\tgoto L_008C;\n\tgoto L_008C;\n\tgoto L_008C;\n\tgoto L_008C;\nL_008C:\n\tv71 = v220 != 1;\n\tif (v71) goto L_00A8;\n\tv259 = System.Predicate`1<EasyMobile.ManifestGenerator.Elements.AndroidManifestElement>::.ctor(v229, v220, v105);\n\tv265 = System.Predicate`1<EasyMobile.ManifestGenerator.Elements.AndroidManifestElement>::.ctor(v259, v220, v105);\n\tv145 = System.Collections.Generic.List`1<System.Int32>+Enumerator<System.Int32>::Dispose(&v111 @ stack_-80_v3 (System.Collections.Generic.List`1<System.Int32>+Enumerator<System.Int32>));\n\tv274 = *([v259 @ X0_v13 (System.Predicate`1<EasyMobile.ManifestGenerator.Elements.AndroidManifestElement>)]) == 0;\n\tv148 = ~v274;\n\tif (v148) goto L_00AC;\nL_00A7:\n\treturn v158;\nL_00A8:\n\tv260 = System.Predicate`1<EasyMobile.ManifestGenerator.Elements.AndroidManifestElement>::.ctor(v229, v220, v105);\nL_00AC:\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 122 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual List<AndroidManifestElement> GetChildElements(List<AndroidManifestElement> elementsFactory)
		{
			//IL_00f1: Expected O, but got I
			List<AndroidManifestElement> result;
			if (ChildElementsId != null)
			{
				List<AndroidManifestElement> list = new List<AndroidManifestElement>();
				bool flag = ChildElementsId == null;
				List<int>.Enumerator enumerator2 = default(List<int>.Enumerator);
				List<int>.Enumerator enumerator = enumerator2;
				if (flag)
				{
					IntPtr intPtr = default(IntPtr);
					IntPtr method = default(IntPtr);
					NullReferenceException ex = (NullReferenceException)(object)new Predicate<AndroidManifestElement>((long)intPtr, method);
					if (intPtr == (IntPtr)1)
					{
						enumerator.Dispose();
						Predicate<AndroidManifestElement> predicate = default(Predicate<AndroidManifestElement>);
						bool flag2 = predicate == null;
						bool flag3 = !flag2;
						result = list;
						if (!flag3)
						{
							goto IL_0159;
						}
					}
					return (List<AndroidManifestElement>)(object)new TypeLoadException();
				}
				List<int>.Enumerator enumerator3 = ChildElementsId.GetEnumerator();
				int num = default(int);
				while (enumerator2.MoveNext())
				{
					int childElementId = num;
					Predicate<AndroidManifestElement> match = delegate(AndroidManifestElement e)
					{
						int num2 = e.Id - childElementId;
						return num2 == 0;
					};
					AndroidManifestElement androidManifestElement = elementsFactory.Find(match);
					if (androidManifestElement != null)
					{
						list.Add(androidManifestElement);
					}
				}
				enumerator2.Dispose();
				result = list;
			}
			else
			{
				result = null;
			}
			goto IL_0159;
			IL_0159:
			return result;
		}

		[Token(Token = "0x600067C")]
		[Address(RVA = "0xB5839C", Offset = "0xB5839C", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1ECE698]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, style, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20227F5]) = v41;\nL_0019:\n\tv46 = EasyMobile.ManifestGenerator.Elements.AndroidManifestElement::get_ChildStyles(this);\n\tv50 = System.Linq.Enumerable::ToList(v46);\n\treturnVal1 = System.Collections.Generic.List`1<EasyMobile.ManifestGenerator.Elements.AndroidManifestElementStyles>::Contains(v50, style);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool IsChildStyle(AndroidManifestElementStyles style)
		{
			IEnumerable<AndroidManifestElementStyles> childStyles = ChildStyles;
			List<AndroidManifestElementStyles> list = childStyles.ToList();
			return list.Contains(style);
		}

		[Token(Token = "0x600067D")]
		[Address(RVA = "0xB58420", Offset = "0xB58420", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EC13E0]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, style, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20227F6]) = v41;\nL_0019:\n\tv46 = EasyMobile.ManifestGenerator.Elements.AndroidManifestElement::get_ParentStyles(this);\n\tv50 = System.Linq.Enumerable::ToList(v46);\n\treturnVal1 = System.Collections.Generic.List`1<EasyMobile.ManifestGenerator.Elements.AndroidManifestElementStyles>::Contains(v50, style);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool IsParentStyle(AndroidManifestElementStyles style)
		{
			IEnumerable<AndroidManifestElementStyles> parentStyles = ParentStyles;
			List<AndroidManifestElementStyles> list = parentStyles.ToList();
			return list.Contains(style);
		}

		[Token(Token = "0x600067E")]
		[Address(RVA = "0xB584A4", Offset = "0xB584A4", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = EasyMobile.ManifestGenerator.Elements.AndroidManifestElement::get_Style(this);\n\treturnVal1 = EasyMobile.ManifestGenerator.Elements.AndroidManifestElementStyleExtension::ToAndroidManifestFormat(v10);\n\treturn returnVal1;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			AndroidManifestElementStyles elementStyle = Style;
			return elementStyle.ToAndroidManifestFormat();
		}

		[Token(Token = "0x600067F")]
		[Address(RVA = "0xB572F0", Offset = "0xB572F0", Length = "0x30C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1F0AC38]);\n\tv27 = *([v26 @ X8_v34]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, key, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([20227F7]) = v45;\nL_0017:\n\tv46 = &v47 @ stack_-50;\n\tv53 = EasyMobile.ManifestGenerator.Elements.AndroidManifestElement::get_AllAvailableAttributes(this);\n\tv54 = v53 == 0;\n\tif (v54) goto L_FFFFFFFF;\n\tv59 = EasyMobile.ManifestGenerator.Elements.AndroidManifestElement::get_AllAvailableAttributes(this);\n\tv61 = v59 == 0;\n\tif (v61) goto L_00D5;\n\tgoto L_0055;\n\tv225 = *([v123 @ X8_v16+B0]);\n\tv226 = 0;\n\tv227 = v225 + 8;\n\tv229 = *([v314 @ X11_v31-8]);\n\tv320 = v229 == v126;\n\tif (v320) goto L_004E;\n\tv251 = v315 + 1;\n\tv335 = v251 < v125;\n\tv247 = ~v335;\n\tv249 = v314 + 0x10;\n\tv231 = ~v247;\n\tif (v231) goto L_FFFFFFFF;\n\tv252 = v60;\n\tv253 = 0;\n\tv254 = 0x8909C4(v252, v126, v253, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_0055;\nL_004E:\n\tv336 = *([v314 @ X11_v31]);\n\tv337 = v336 << 4;\n\tv338 = v123 + v337;\n\tv339 = v338 + 0x130;\nL_0055:\n\tv360 = System.Collections.Generic.IEnumerable`1<System.String>::GetEnumerator(v59);\nL_0061:\n\tgoto L_0088;\n\tv419 = *([v410 @ X8_v21+B0]);\n\tv420 = 0;\n\tv421 = v419 + 8;\n\tv423 = *([v543 @ X11_v26-8]);\n\tv549 = v423 == v411;\n\tif (v549) goto L_0081;\n\tv445 = v544 + 1;\n\tv586 = v445 < v412;\n\tv441 = ~v586;\n\tv443 = v543 + 0x10;\n\tv425 = ~v441;\n\tif (v425) goto L_FFFFFFFF;\n\tv446 = v167;\n\tv447 = 0;\n\tv448 = 0x8909C4(v446, v411, v447, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_0088;\nL_0081:\n\tv587 = *([v543 @ X11_v26]);\n\tv588 = v587 << 4;\n\tv589 = v410 + v588;\n\tv590 = v589 + 0x130;\nL_0088:\n\tv490 = System.Collections.IEnumerator::MoveNext(v360);\n\tv596 = v490 == 0;\n\tif (v596) goto L_00CD;\n\tgoto L_00B7;\n\tv632 = *([v618 @ X8_v25+B0]);\n\tv633 = 0;\n\tv634 = v632 + 8;\n\tv636 = *([v672 @ X11_v21-8]);\n\tv678 = v636 == v619;\n\tif (v678) goto L_00B0;\n\tv658 = v673 + 1;\n\tv683 = v658 < v620;\n\tv654 = ~v683;\n\tv656 = v672 + 0x10;\n\tv638 = ~v654;\n\tif (v638) goto L_FFFFFFFF;\n\tv659 = v167;\n\tv660 = 0;\n\tv661 = 0x8909C4(v659, v619, v660, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_00B7;\nL_00B0:\n\tv684 = *([v672 @ X11_v21]);\n\tv685 = v684 << 4;\n\tv686 = v618 + v685;\n\tv687 = v686 + 0x130;\nL_00B7:\n\tv452 = System.Collections.Generic.IEnumerator`1<System.String>::get_Current(v360);\n\tv398 = System.String::Equals(v452, key);\n\tv400 = v398 == 0;\n\tif (v400) goto L_0061;\n\t*([v46 @ X22_v1]) = 0x40;\n\tv692 = v360 == 0;\n\tv492 = ~v692;\n\tif (v492) goto L_00F2;\n\tgoto L_011A;\nL_00CD:\n\t*([v46 @ X22_v1]) = 0x3E;\n\tv622 = v360 == 0;\n\tv493 = ~v622;\n\tif (v493) goto L_00F2;\n\tgoto L_011A;\n\tv415 = new System.NullReferenceException();\n\tv163 = new System.NullReferenceException();\nL_00D5:\n\tv172 = new System.NullReferenceException();\n\tgoto L_00E3;\n\tgoto L_00E3;\n\tgoto L_00E3;\n\tgoto L_00E3;\nL_00E3:\n\tv334 = v158 != 1;\n\tif (v334) goto L_0148;\n\tv363 = 0x6D2BC0(v172, v158, v134, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv495 = *([v363 @ X0_v23]);\n\tv405 = 0x6D2490(v363, v158, v134, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv418 = v360 == 0;\n\tif (v418) goto L_011A;\nL_00F2:\n\tgoto L_0119;\n\tv554 = *([v505 @ X8_v11+B0]);\n\tv555 = 0;\n\tv556 = v554 + 8;\n\tv558 = *([v607 @ X11_v10-8]);\n\tv613 = v558 == v508;\n\tif (v613) goto L_0112;\n\tv580 = v608 + 1;\n\tv623 = v580 < v507;\n\tv576 = ~v623;\n\tv578 = v607 + 0x10;\n\tv560 = ~v576;\n\tif (v560) goto L_FFFFFFFF;\n\tv581 = v494;\n\tv582 = 0;\n\tv583 = 0x8909C4(v581, v508, v582, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_0119;\nL_0112:\n\tv624 = *([v607 @ X11_v10]);\n\tv625 = v624 << 4;\n\tv626 = v505 + v625;\n\tv627 = v626 + 0x130;\nL_0119:\n\tSystem.IDisposable::Dispose(v494);\nL_011A:\n\tv208 = v66 + 1;\n\tv88 = v208 == 0;\n\tif (v88) goto L_0139;\n\tv191 = *([v46 @ X22_v1+v66 @ X23_v4 (System.Int32)*4]) == 0x40;\n\tif (v191) goto L_0147;\n\tv209 = v116 == 0;\n\tif (v209) goto L_0147;\n\tv192 = *([v46 @ X22_v1+v66 @ X23_v4 (System.Int32)*4]) == 0x3E;\n\tif (v192) goto L_0147;\n\tgoto L_014C;\nL_0139:\n\tv585 = v116 == 0;\n\tv112 = ~v585;\n\tif (v112) goto L_014C;\nL_0147:\n\treturn v214;\nL_0148:\n\tv364 = 0x6D2380(v172, v158, v134, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_014C:\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 187 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected bool IsAvailableAttribute(string key)
		{
			//IL_02e0: Expected I4, but got O
			//IL_01a0: Expected I4, but got O
			//IL_01e6: Expected I4, but got O
			//IL_00f0: Expected O, but got I4
			//IL_007c: Expected O, but got I4
			object obj2 = default(object);
			object obj = obj2;
			IEnumerable<string> allAvailableAttributes = AllAvailableAttributes;
			if (allAvailableAttributes == null)
			{
				goto IL_02b0;
			}
			IEnumerable<string> allAvailableAttributes2 = AllAvailableAttributes;
			bool flag = allAvailableAttributes2 == null;
			IEnumerator<string> enumerator2 = default(IEnumerator<string>);
			IEnumerator<string> enumerator = enumerator2;
			int num;
			int num2;
			int num3;
			int num4;
			int num5;
			int num6;
			if (flag)
			{
				NullReferenceException ex = new NullReferenceException();
				object obj3 = default(object);
				if ((IntPtr)obj3 != (IntPtr)1)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
					goto IL_02d2;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj4 = default(object);
				num = (int)obj4;
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				bool flag2 = enumerator2 == null;
				num2 = -1;
				num3 = 0;
				num4 = -1;
				num5 = (int)obj4;
				num6 = 0;
				if (flag2)
				{
					goto IL_035d;
				}
			}
			else
			{
				enumerator2 = allAvailableAttributes2.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					string current = enumerator2.Current;
					if (!current.Equals(key))
					{
						continue;
					}
					goto IL_0073;
				}
				obj = 62;
				bool flag3 = enumerator2 == null;
				bool flag4 = !flag3;
				num2 = 0;
				enumerator = enumerator2;
				num = 0;
				num3 = 0;
				if (!flag4)
				{
					num4 = 0;
					num5 = 0;
					num6 = 0;
					goto IL_035d;
				}
			}
			goto IL_0388;
			IL_0388:
			enumerator.Dispose();
			num4 = num2;
			num5 = num;
			num6 = num3;
			goto IL_035d;
			IL_02d2:
			TypeLoadException ex2 = new TypeLoadException();
			return (byte)(int)ex2 != 0;
			IL_02b0:
			bool result = false;
			goto IL_03ae;
			IL_03ae:
			return result;
			IL_035d:
			if (num4 + 1 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X22_v1+v66 @ X23_v4 (System.Int32)*4]");
				bool flag5 = (IntPtr)0 == (IntPtr)64;
				result = (byte)num6 != 0;
				if (!flag5)
				{
					bool flag6 = num5 == 0;
					result = false;
					if (!flag6)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X22_v1+v66 @ X23_v4 (System.Int32)*4]");
						bool flag7 = (IntPtr)0 == (IntPtr)62;
						result = false;
						if (!flag7)
						{
							goto IL_02d2;
						}
					}
				}
				goto IL_03ae;
			}
			if (num5 == 0)
			{
				goto IL_02b0;
			}
			goto IL_02d2;
			IL_0073:
			obj = 64;
			bool flag8 = enumerator2 == null;
			bool flag9 = !flag8;
			num2 = 0;
			enumerator = enumerator2;
			num = 0;
			num3 = 1;
			if (!flag9)
			{
				num4 = 0;
				num5 = 0;
				num6 = 1;
				goto IL_035d;
			}
			goto IL_0388;
		}

		[Token(Token = "0x6000680")]
		[Address(RVA = "0xB576FC", Offset = "0xB576FC", Length = "0x378")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = &v17 @ X29;\n\tgoto L_001B;\n\tv31 = *([1EDE648]);\n\tv32 = *([v31 @ X8_v37]);\n\tv33 = \"il2cpp_codegen_initialize_method\"(v32, style, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20227F8]) = v50;\nL_001B:\n\tv51 = &v52 @ stack_-70;\n\t*([v17 @ X29-44]) = 0;\n\tv58 = EasyMobile.ManifestGenerator.Elements.AndroidManifestElement::get_ChildStyles(this);\n\tv59 = v58 == 0;\n\tif (v59) goto L_FFFFFFFF;\n\tv64 = EasyMobile.ManifestGenerator.Elements.AndroidManifestElement::get_ChildStyles(this);\n\tv66 = v64 == 0;\n\tif (v66) goto L_00F0;\n\tgoto L_005A;\n\tv250 = *([v134 @ X8_v16+B0]);\n\tv251 = 0;\n\tv252 = v250 + 8;\n\tv254 = *([v345 @ X11_v31-8]);\n\tv351 = v254 == v137;\n\tif (v351) goto L_0053;\n\tv276 = v346 + 1;\n\tv366 = v276 < v136;\n\tv272 = ~v366;\n\tv274 = v345 + 0x10;\n\tv256 = ~v272;\n\tif (v256) goto L_FFFFFFFF;\n\tv277 = v65;\n\tv278 = 0;\n\tv279 = 0x8909C4(v277, v137, v278, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_005A;\nL_0053:\n\tv367 = *([v345 @ X11_v31]);\n\tv368 = v367 << 4;\n\tv369 = v134 + v368;\n\tv370 = v369 + 0x130;\nL_005A:\n\tv391 = System.Collections.Generic.IEnumerable`1<EasyMobile.ManifestGenerator.Elements.AndroidManifestElementStyles>::GetEnumerator(v64);\nL_0068:\n\tgoto L_008F;\n\tv455 = *([v446 @ X8_v21+B0]);\n\tv456 = 0;\n\tv457 = v455 + 8;\n\tv459 = *([v586 @ X11_v26-8]);\n\tv592 = v459 == v447;\n\tif (v592) goto L_0088;\n\tv481 = v587 + 1;\n\tv629 = v481 < v448;\n\tv477 = ~v629;\n\tv479 = v586 + 0x10;\n\tv461 = ~v477;\n\tif (v461) goto L_FFFFFFFF;\n\tv482 = v184;\n\tv483 = 0;\n\tv484 = 0x8909C4(v482, v447, v483, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_008F;\nL_0088:\n\tv630 = *([v586 @ X11_v26]);\n\tv631 = v630 << 4;\n\tv632 = v446 + v631;\n\tv633 = v632 + 0x130;\nL_008F:\n\tv533 = System.Collections.IEnumerator::MoveNext(v391);\n\tv639 = v533 == 0;\n\tif (v639) goto L_00E7;\n\tgoto L_00BE;\n\tv675 = *([v661 @ X8_v25+B0]);\n\tv676 = 0;\n\tv677 = v675 + 8;\n\tv679 = *([v715 @ X11_v21-8]);\n\tv721 = v679 == v662;\n\tif (v721) goto L_00B7;\n\tv701 = v716 + 1;\n\tv726 = v701 < v663;\n\tv697 = ~v726;\n\tv699 = v715 + 0x10;\n\tv681 = ~v697;\n\tif (v681) goto L_FFFFFFFF;\n\tv702 = v184;\n\tv703 = 0;\n\tv704 = 0x8909C4(v702, v662, v703, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_00BE;\nL_00B7:\n\tv727 = *([v715 @ X11_v21]);\n\tv728 = v727 << 4;\n\tv729 = v661 + v728;\n\tv730 = v729 + 0x130;\nL_00BE:\n\tv736 = System.Collections.Generic.IEnumerator`1<EasyMobile.ManifestGenerator.Elements.AndroidManifestElementStyles>::get_Current(v391);\n\t*([v17 @ X29-48]) = style;\n\t*([v17 @ X29-44]) = v736;\n\tv737 = &v17 @ X29 - 0x48;\n\t// 196 Box v739 @ X0_v41, typeof(EasyMobile.ManifestGenerator.Elements.AndroidManifestElementStyles), v737 @ X1_v20\n\tv486 = &v17 @ X29 - 0x44;\n\t// 200 Box v489 @ X0_v43, typeof(EasyMobile.ManifestGenerator.Elements.AndroidManifestElementStyles), v486 @ X1_v21\n\tv741 = *([v489 @ X0_v43]);\n\t*([v741 @ X8_v29+130])(v743, v489, v739, *([v741 @ X8_v29+138]), v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv432 = \"il2cpp_vm_object_unbox\"(v489, v739, *([v741 @ X8_v29+138]), v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([v17 @ X29-44]) = *([v432 @ X0_v47]);\n\tv745 = v743 & 1;\n\tv434 = v745 == 0;\n\tif (v434) goto L_0068;\n\t*([v51 @ X23_v1]) = 0x4E;\n\tv746 = v391 == 0;\n\tv535 = ~v746;\n\tif (v535) goto L_0110;\n\tgoto L_0138;\nL_00E7:\n\t*([v51 @ X23_v1]) = 0x4C;\n\tv665 = v391 == 0;\n\tv536 = ~v665;\n\tif (v536) goto L_0110;\n\tgoto L_0138;\n\tthrow System.NullReferenceException;\n\tv180 = new System.NullReferenceException();\nL_00F0:\n\tv189 = new System.NullReferenceException();\n\tgoto L_0101;\n\tgoto L_0101;\n\tgoto L_0101;\n\tgoto L_0101;\n\tgoto L_0101;\n\tgoto L_0101;\n\tgoto L_0101;\nL_0101:\n\tv365 = v175 != 1;\n\tif (v365) goto L_0169;\n\tv395 = 0x6D2BC0(v189, v175, v151, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv538 = *([v395 @ X0_v23]);\n\tv441 = 0x6D2490(v395, v175, v151, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv454 = v391 == 0;\n\tif (v454) goto L_0138;\nL_0110:\n\tgoto L_0137;\n\tv597 = *([v548 @ X8_v11+B0]);\n\tv598 = 0;\n\tv599 = v597 + 8;\n\tv601 = *([v650 @ X11_v10-8]);\n\tv656 = v601 == v551;\n\tif (v656) goto L_0130;\n\tv623 = v651 + 1;\n\tv666 = v623 < v550;\n\tv619 = ~v666;\n\tv621 = v650 + 0x10;\n\tv603 = ~v619;\n\tif (v603) goto L_FFFFFFFF;\n\tv624 = v537;\n\tv625 = 0;\n\tv626 = 0x8909C4(v624, v551, v625, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_0137;\nL_0130:\n\tv667 = *([v650 @ X11_v10]);\n\tv668 = v667 << 4;\n\tv669 = v548 + v668;\n\tv670 = v669 + 0x130;\nL_0137:\n\tSystem.IDisposable::Dispose(v537);\nL_0138:\n\tv228 = v77 + 1;\n\tv99 = v228 == 0;\n\tif (v99) goto L_0157;\n\tv211 = *([v51 @ X23_v1+v77 @ X22_v4 (System.Int32)*4]) == 0x4E;\n\tif (v211) goto L_0168;\n\tv229 = v127 == 0;\n\tif (v229) goto L_0168;\n\tv212 = *([v51 @ X23_v1+v77 @ X22_v4 (System.Int32)*4]) == 0x4C;\n\tif (v212) goto L_0168;\n\tgoto L_016D;\nL_0157:\n\tv628 = v127 == 0;\n\tv123 = ~v628;\n\tif (v123) goto L_016D;\nL_0168:\n\treturn v234;\nL_0169:\n\tv396 = 0x6D2380(v189, v175, v151, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_016D:\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 205 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected bool IsAvailableInnerElement(AndroidManifestElementStyles style)
		{
			//IL_030c: Expected I4, but got O
			//IL_01cc: Expected I4, but got O
			//IL_0212: Expected I4, but got O
			//IL_011c: Expected O, but got I4
			//IL_03a3: Expected O, but got I
			//IL_03ac: Expected I4, but got O
			//IL_03bf: Expected O, but got I
			//IL_03c8: Expected I4, but got O
			//IL_00a8: Expected O, but got I4
			object obj = obj;
			object obj3 = default(object);
			object obj2 = obj3;
			_ = 0;
			IEnumerable<AndroidManifestElementStyles> childStyles = ChildStyles;
			if (childStyles == null)
			{
				goto IL_02dc;
			}
			IEnumerable<AndroidManifestElementStyles> childStyles2 = ChildStyles;
			bool flag = childStyles2 == null;
			IEnumerator<AndroidManifestElementStyles> enumerator2 = default(IEnumerator<AndroidManifestElementStyles>);
			IEnumerator<AndroidManifestElementStyles> enumerator = enumerator2;
			int num;
			int num2;
			int num3;
			int num4;
			int num5;
			int num6;
			if (flag)
			{
				NullReferenceException ex = new NullReferenceException();
				object obj4 = default(object);
				if ((IntPtr)obj4 != (IntPtr)1)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
					goto IL_02fe;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj5 = default(object);
				num = (int)obj5;
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				bool flag2 = enumerator2 == null;
				num2 = -1;
				num3 = 0;
				num4 = -1;
				num5 = (int)obj5;
				num6 = 0;
				if (flag2)
				{
					goto IL_03d1;
				}
			}
			else
			{
				enumerator2 = childStyles2.GetEnumerator();
				object obj11 = default(object);
				while (enumerator2.MoveNext())
				{
					AndroidManifestElementStyles current = enumerator2.Current;
					object obj6 = (long)(IntPtr)obj - 72L;
					object obj7 = (AndroidManifestElementStyles)obj6;
					object obj8 = (long)(IntPtr)obj - 68L;
					object obj9 = (AndroidManifestElementStyles)obj8;
					object obj10 = obj9;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v741 @ X8_v29+130] (should have been resolved before IL gen)");
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					if ((int)((long)(IntPtr)obj11 & 1L) == 0)
					{
						continue;
					}
					goto IL_009f;
				}
				obj2 = 76;
				bool flag3 = enumerator2 == null;
				bool flag4 = !flag3;
				num2 = 0;
				enumerator = enumerator2;
				num = 0;
				num3 = 0;
				if (!flag4)
				{
					num4 = 0;
					num5 = 0;
					num6 = 0;
					goto IL_03d1;
				}
			}
			goto IL_03fc;
			IL_03fc:
			enumerator.Dispose();
			num4 = num2;
			num5 = num;
			num6 = num3;
			goto IL_03d1;
			IL_02fe:
			TypeLoadException ex2 = new TypeLoadException();
			return (byte)(int)ex2 != 0;
			IL_02dc:
			bool result = false;
			goto IL_0422;
			IL_0422:
			return result;
			IL_03d1:
			if (num4 + 1 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X23_v1+v77 @ X22_v4 (System.Int32)*4]");
				bool flag5 = (IntPtr)0 == (IntPtr)78;
				result = (byte)num6 != 0;
				if (!flag5)
				{
					bool flag6 = num5 == 0;
					result = false;
					if (!flag6)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X23_v1+v77 @ X22_v4 (System.Int32)*4]");
						bool flag7 = (IntPtr)0 == (IntPtr)76;
						result = false;
						if (!flag7)
						{
							goto IL_02fe;
						}
					}
				}
				goto IL_0422;
			}
			if (num5 == 0)
			{
				goto IL_02dc;
			}
			goto IL_02fe;
			IL_009f:
			obj2 = 78;
			bool flag8 = enumerator2 == null;
			bool flag9 = !flag8;
			num2 = 0;
			enumerator = enumerator2;
			num = 0;
			num3 = 1;
			if (!flag9)
			{
				num4 = 0;
				num5 = 0;
				num6 = 1;
				goto IL_03d1;
			}
			goto IL_03fc;
		}
	}
}
