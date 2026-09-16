using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace com.adjust.sdk
{
	[AttributeAttribute(Type = typeof(DefaultMemberAttribute), RVA = "0x72DD18", Offset = "0x72DD18")]
	[Token(Token = "0x2000004")]
	public class JSONArray : JSONNode, IEnumerable
	{
		[CompilerGenerated]
		[Token(Token = "0x2000019")]
		private sealed class _003Cget_Childs_003Ed__13 : IEnumerable<JSONNode>, IEnumerable, IEnumerator<JSONNode>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000093")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x4000094")]
			[FieldOffset(Offset = "0x18")]
			private JSONNode _003C_003E2__current;

			[Token(Token = "0x4000095")]
			[FieldOffset(Offset = "0x20")]
			internal int _003C_003El__initialThreadId;

			[Token(Token = "0x4000096")]
			[FieldOffset(Offset = "0x28")]
			public JSONArray _003C_003E4__this;

			[Token(Token = "0x4000097")]
			[FieldOffset(Offset = "0x30")]
			private List<JSONNode>.Enumerator _003C_003E7__wrap1;

			[Token(Token = "0x17000040")]
			JSONNode IEnumerator<JSONNode>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000144")]
				[Address(RVA = "0x1571278", Offset = "0x1571278", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000041")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000146")]
				[Address(RVA = "0x15712E4", Offset = "0x15712E4", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000140")]
			[Address(RVA = "0x1570904", Offset = "0x1570904", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\tv16 = System.Environment::get_CurrentManagedThreadId();\n\tthis.<>l__initialThreadId = v16;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003Cget_Childs_003Ed__13(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000141")]
			[Address(RVA = "0x15710AC", Offset = "0x15710AC", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.<>1__state == 1;\n\tif (v6) goto L_0012;\n\tv11 = this.<>1__state + 3;\n\tv13 = v11 == 0;\n\tv16 = ~v13;\n\tif (v16) goto L_0014;\nL_0012:\n\tcom.adjust.sdk.JSONArray+<get_Childs>d__13::<>m__Finally1(this);\n\treturn;\nL_0014:\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IDisposable.Dispose()
			{
				if (_003C_003E1__state == 1 || _003C_003E1__state + 3 == 0)
				{
					_003C_003Em__Finally1();
				}
			}

			[Token(Token = "0x6000142")]
			[Address(RVA = "0x1571120", Offset = "0x1571120", Length = "0x158")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1ED1670]);\n\tv19 = *([v18 @ X8_v21]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20290EE]) = v38;\nL_0014:\n\tv40 = this.<>1__state == 0;\n\tif (v40) goto L_0025;\n\tv50 = this.<>1__state != 1;\n\tif (v50) goto L_FFFFFFFF;\n\tv120 = this + 0x30;\n\tthis.<>1__state = 0xFFFFFFFD;\n\tgoto L_003D;\nL_0025:\n\tv51 = this.<>4__this;\n\tthis.<>1__state = 0xFFFFFFFF;\n\tv86 = v51.m_List == 0;\n\tif (v86) goto L_004F;\n\tv116 = System.Collections.Generic.List`1<com.adjust.sdk.JSONNode>::GetEnumerator(v51.m_List);\n\tv120 = this + 0x30;\n\t*([this @ X0 (com.adjust.sdk.JSONArray+<get_Childs>d__13)+40]) = v196;\n\tthis.<>1__state = 0xFFFFFFFD;\n\tthis.<>7__wrap1 = v92;\nL_003D:\n\tv126 = System.Collections.Generic.List`1<com.adjust.sdk.JSONNode>+Enumerator<com.adjust.sdk.JSONNode>::MoveNext(v120);\n\tv144 = v126 == 0;\n\tif (v144) goto L_0047;\n\tthis.<>1__state = 1;\n\tthis.<>2__current = *([this @ X0 (com.adjust.sdk.JSONArray+<get_Childs>d__13)+40]);\n\tgoto L_007E;\nL_0047:\n\tcom.adjust.sdk.JSONArray+<get_Childs>d__13::<>m__Finally1(this);\n\t*([v120 @ X20_v4 (System.Collections.Generic.List`1<com.adjust.sdk.JSONNode>+Enumerator<com.adjust.sdk.JSONNode>)+8]) = 0;\n\tv120.list = 0;\n\t*([v120 @ X20_v4 (System.Collections.Generic.List`1<com.adjust.sdk.JSONNode>+Enumerator<com.adjust.sdk.JSONNode>)]) = 0;\n\tgoto L_007E;\n\tv88 = new System.NullReferenceException();\nL_004F:\n\tv157 = new System.NullReferenceException();\n\tgoto L_005C;\n\tgoto L_005C;\n\tgoto L_005C;\nL_005C:\n\tv207 = methodInfo != 1;\n\tif (v207) goto L_007F;\n\tv208 = 0x6D2BC0(v157, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv210 = 0x6D2490(v208, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv216 = this.<>1__state == 1;\n\tif (v216) goto L_0074;\n\tv218 = this.<>1__state + 3;\n\tv220 = v218 == 0;\n\tv223 = ~v220;\n\tif (v223) goto L_0075;\nL_0074:\n\tcom.adjust.sdk.JSONArray+<get_Childs>d__13::<>m__Finally1(this);\nL_0075:\n\tv232 = *([v208 @ X0_v17]) == 0;\n\tv79 = ~v232;\n\tif (v79) goto L_0083;\nL_007E:\n\treturn returnVal1;\nL_007F:\n\tv209 = 0x6D2380(v157, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0083:\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private unsafe bool MoveNext()
			{
				//IL_009d: Expected O, but got I
				//IL_0033: Expected O, but got I
				//IL_021f: Expected I4, but got O
				//IL_00f8: Expected native int or pointer, but got O
				//IL_0106: Expected O, but got I4
				//IL_00d9: Expected O, but got I
				List<JSONNode>.Enumerator enumerator;
				if (_003C_003E1__state != 0)
				{
					if (_003C_003E1__state != 1)
					{
						goto IL_01ef;
					}
					enumerator = (List<JSONNode>.Enumerator)((long)(IntPtr)this + 48L);
					_003C_003E1__state = -3;
				}
				else
				{
					JSONArray jSONArray = _003C_003E4__this;
					_003C_003E1__state = -1;
					if (jSONArray.m_List == null)
					{
						NullReferenceException ex = new NullReferenceException();
						IntPtr intPtr = default(IntPtr);
						if (intPtr == (IntPtr)1)
						{
							Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
							Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
							if (_003C_003E1__state == 1 || _003C_003E1__state + 3 == 0)
							{
								_003C_003Em__Finally1();
							}
							object obj = default(object);
							if (obj == null)
							{
								goto IL_01ef;
							}
						}
						else
						{
							Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
						}
						TypeLoadException ex2 = new TypeLoadException();
						return (byte)(int)ex2 != 0;
					}
					List<JSONNode>.Enumerator enumerator2 = jSONArray.m_List.GetEnumerator();
					enumerator = (List<JSONNode>.Enumerator)((long)(IntPtr)this + 48L);
					_003C_003E1__state = -3;
					List<JSONNode>.Enumerator enumerator3 = default(List<JSONNode>.Enumerator);
					_003C_003E7__wrap1 = enumerator3;
				}
				if (((List<JSONNode>.Enumerator*)enumerator)->MoveNext())
				{
					_003C_003E1__state = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (com.adjust.sdk.JSONArray+<get_Childs>d__13)+40]");
					_003C_003E2__current = (JSONNode)0;
					return true;
				}
				_003C_003Em__Finally1();
				_ = 0;
				System.Runtime.CompilerServices.Unsafe.Write(&((List<JSONNode>.Enumerator*)(IntPtr)enumerator)->list, null);
				enumerator = (List<JSONNode>.Enumerator)0;
				return false;
				IL_01ef:
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[Token(Token = "0x6000143")]
			[Address(RVA = "0x15710C8", Offset = "0x15710C8", Length = "0x58")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1F000B0]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20290EF]) = v38;\nL_0014:\n\tthis.<>1__state = 0xFFFFFFFF;\n\tv44 = this + 0x30;\n\tv48 = System.Collections.Generic.List`1<com.adjust.sdk.JSONNode>+Enumerator<com.adjust.sdk.JSONNode>::Dispose(v44);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private unsafe void _003C_003Em__Finally1()
			{
				//IL_001c: Expected O, but got I
				_003C_003E1__state = -1;
				List<JSONNode>.Enumerator enumerator = (List<JSONNode>.Enumerator)((long)(IntPtr)this + 48L);
				((List<JSONNode>.Enumerator*)enumerator)->Dispose();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000145")]
			[Address(RVA = "0x1571280", Offset = "0x1571280", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1F0B2E0]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([20290F0]) = v34;\nL_0014:\n\tv38 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw new TypeLoadException();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000147")]
			[Address(RVA = "0x15712EC", Offset = "0x15712EC", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EC7F88]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20290F1]) = v38;\nL_0014:\n\tv40 = this.<>1__state + 2;\n\tv42 = v40 == 0;\n\tv45 = ~v42;\n\tif (v45) goto L_002E;\n\tv48 = System.Environment::get_CurrentManagedThreadId();\n\tv50 = this.<>l__initialThreadId != v48;\n\tif (v50) goto L_002E;\n\tthis.<>1__state = 0;\n\tgoto L_0041;\nL_002E:\n\tv76 = new com.adjust.sdk.JSONArray+<get_Childs>d__13();\n\tSystem.Object::.ctor(v76);\n\tv76.<>1__state = 0;\n\tv81 = System.Environment::get_CurrentManagedThreadId();\n\tv76.<>l__initialThreadId = v81;\n\tv76.<>4__this = this.<>4__this;\nL_0041:\n\treturn v95;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			IEnumerator<JSONNode> IEnumerable<JSONNode>.GetEnumerator()
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
				_003Cget_Childs_003Ed__13 _003Cget_Childs_003Ed__14 = null;
				_003Cget_Childs_003Ed__14._003C_003E1__state = 0;
				int currentManagedThreadId2 = Environment.CurrentManagedThreadId;
				_003Cget_Childs_003Ed__14._003C_003El__initialThreadId = currentManagedThreadId2;
				_003Cget_Childs_003Ed__14._003C_003E4__this = _003C_003E4__this;
				return _003Cget_Childs_003Ed__14;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000148")]
			[Address(RVA = "0x157139C", Offset = "0x157139C", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = com.adjust.sdk.JSONArray+<get_Childs>d__13::System.Collections.Generic.IEnumerable<com.adjust.sdk.JSONNode>.GetEnumerator(this);\n\treturn returnVal1;\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<JSONNode>)this).GetEnumerator();
			}
		}

		[Token(Token = "0x4000009")]
		[FieldOffset(Offset = "0x10")]
		private List<JSONNode> m_List;

		[Token(Token = "0x1700000D")]
		public override JSONNode Item
		{
			[Token(Token = "0x600002F")]
			[Address(RVA = "0x157045C", Offset = "0x157045C", Length = "0xAC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1F0A058]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, aIndex, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20290DD]) = v41;\nL_0015:\n\tv42 = aIndex & 0x80000000;\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tif (v44) goto L_0037;\n\tv45 = this.m_List;\n\tv82 = v45._size < aIndex;\n\tv72 = ~v82;\n\tv69 = v45._size - aIndex;\n\tv63 = v69 == 0;\n\tv48 = v45._size <= aIndex;\n\tif (v48) goto L_0037;\n\tv89 = ~v63;\n\tv90 = v72 & v89;\n\tif (v90) goto L_002F;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_002F:\n\tv93 = v45._items;\n\tgoto L_0044;\nL_0037:\n\tv81 = new com.adjust.sdk.JSONLazyCreator();\n\tSystem.Object::.ctor(v81);\n\tv81.m_Node = this;\n\tv81.m_Key = 0;\nL_0044:\n\treturn v137;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0108: Expected I4, but got I8
				if ((int)(aIndex & 0x80000000L) == 0)
				{
					List<JSONNode> list = m_List;
					bool flag = list.Count < aIndex;
					bool flag2 = !flag;
					int num = list.Count - aIndex;
					bool flag3 = num == 0;
					if (list.Count > aIndex)
					{
						bool flag4 = !flag3;
						if (!(flag2 && flag4))
						{
							throw new ArgumentOutOfRangeException();
						}
						JSONNode[] items = list._items;
						return items[aIndex];
					}
				}
				JSONLazyCreator jSONLazyCreator = null;
				jSONLazyCreator.m_Node = this;
				jSONLazyCreator.m_Key = null;
				return jSONLazyCreator;
			}
			[Token(Token = "0x6000030")]
			[Address(RVA = "0x1570534", Offset = "0x1570534", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EDD668]);\n\tv27 = *([v26 @ X8_v11]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, aIndex, value, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20290DE]) = v44;\nL_0017:\n\tv45 = this.m_List;\n\tv46 = aIndex & 0x80000000;\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tif (v48) goto L_0047;\n\tv63 = v45._size <= aIndex;\n\tif (v63) goto L_0047;\n\tSystem.Collections.Generic.List`1<com.adjust.sdk.JSONNode>::set_Item(this.m_List, aIndex, value);\n\treturn;\nL_0047:\n\tSystem.Collections.Generic.List`1<com.adjust.sdk.JSONNode>::Add(this.m_List, value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0069: Expected I4, but got I8
				List<JSONNode> list = m_List;
				if ((int)(aIndex & 0x80000000L) == 0 && list.Count > aIndex)
				{
					m_List.set_Item(aIndex, value);
				}
				else
				{
					m_List.Add(value);
				}
			}
		}

		[Token(Token = "0x1700000E")]
		public override JSONNode Item
		{
			[Token(Token = "0x6000031")]
			[Address(RVA = "0x15705D8", Offset = "0x15705D8", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1F04A30]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, aKey, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20290DF]) = v38;\nL_0016:\n\tv42 = new com.adjust.sdk.JSONLazyCreator();\n\tSystem.Object::.ctor(v42);\n\tv42.m_Node = this;\n\tv42.m_Key = 0;\n\treturn v42;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				JSONLazyCreator jSONLazyCreator = null;
				jSONLazyCreator.m_Node = this;
				jSONLazyCreator.m_Key = null;
				return jSONLazyCreator;
			}
			[Token(Token = "0x6000032")]
			[Address(RVA = "0x157063C", Offset = "0x157063C", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv22 = *([1EF1100]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, aKey, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20290E0]) = v41;\nL_0022:\n\tSystem.Collections.Generic.List`1<com.adjust.sdk.JSONNode>::Add(this.m_List, value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				m_List.Add(value);
			}
		}

		[Token(Token = "0x1700000F")]
		public override int Count
		{
			[Token(Token = "0x6000033")]
			[Address(RVA = "0x15706A4", Offset = "0x15706A4", Length = "0x54")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F03180]);\n\tv19 = *([v18 @ X8_v5]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20290E1]) = v38;\nL_0013:\n\tv39 = this.m_List;\n\treturn v39._size;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				List<JSONNode> list = m_List;
				return list.Count;
			}
		}

		[Token(Token = "0x17000010")]
		public override IEnumerable<JSONNode> Childs
		{
			[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x72E0F8", Offset = "0x72E0F8")]
			[Token(Token = "0x6000037")]
			[Address(RVA = "0x1570880", Offset = "0x1570880", Length = "0x84")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EAF150]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20290E5]) = v38;\nL_0016:\n\tv42 = new com.adjust.sdk.JSONArray+<get_Childs>d__13();\n\tSystem.Object::.ctor(v42);\n\tv42.<>1__state = 0xFFFFFFFE;\n\tv47 = System.Environment::get_CurrentManagedThreadId();\n\tv42.<>l__initialThreadId = v47;\n\tv42.<>4__this = this;\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				_003Cget_Childs_003Ed__13 _003Cget_Childs_003Ed__14 = new _003Cget_Childs_003Ed__13(-2);
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003Cget_Childs_003Ed__14._003C_003El__initialThreadId = currentManagedThreadId;
				_003Cget_Childs_003Ed__14._003C_003E4__this = this;
				return _003Cget_Childs_003Ed__14;
			}
		}

		[Token(Token = "0x6000034")]
		[Address(RVA = "0x15706F8", Offset = "0x15706F8", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv22 = *([1EA94B8]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, aKey, aItem, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20290E2]) = v41;\nL_0022:\n\tSystem.Collections.Generic.List`1<com.adjust.sdk.JSONNode>::Add(this.m_List, aItem);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Add(string aKey, JSONNode aItem)
		{
			m_List.Add(aItem);
		}

		[Token(Token = "0x6000035")]
		[Address(RVA = "0x1570760", Offset = "0x1570760", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EACE48]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, aIndex, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20290E3]) = v41;\nL_0015:\n\tv42 = aIndex & 0x80000000;\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tif (v44) goto L_FFFFFFFF;\n\tv45 = this.m_List;\n\tv79 = v45._size < aIndex;\n\tv72 = ~v79;\n\tv69 = v45._size - aIndex;\n\tv63 = v69 == 0;\n\tv48 = v45._size <= aIndex;\n\tif (v48) goto L_FFFFFFFF;\n\tv119 = ~v63;\n\tv94 = v72 & v119;\n\tif (v94) goto L_0034;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\n\tv104 = this.m_List;\nL_0034:\n\tv158 = v45._items;\n\tSystem.Collections.Generic.List`1<com.adjust.sdk.JSONNode>::RemoveAt(v104, aIndex);\n\tgoto L_0045;\nL_0045:\n\treturn v107;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override JSONNode Remove(int aIndex)
		{
			//IL_0106: Expected I4, but got I8
			if ((int)(aIndex & 0x80000000L) == 0)
			{
				List<JSONNode> list = m_List;
				bool flag = list.Count < aIndex;
				bool flag2 = !flag;
				int num = list.Count - aIndex;
				bool flag3 = num == 0;
				if (list.Count > aIndex)
				{
					bool flag4 = !flag3;
					bool flag5 = flag2 && flag4;
					List<JSONNode> list2 = list;
					if (!flag5)
					{
						throw new ArgumentOutOfRangeException();
					}
					JSONNode[] items = list._items;
					list2.RemoveAt(aIndex);
					return items[aIndex];
				}
			}
			return null;
		}

		[Token(Token = "0x6000036")]
		[Address(RVA = "0x1570810", Offset = "0x1570810", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1EC3F68]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, aNode, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20290E4]) = v41;\nL_001C:\n\tv48 = System.Collections.Generic.List`1<com.adjust.sdk.JSONNode>::Remove(this.m_List, aNode);\n\treturn aNode;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override JSONNode Remove(JSONNode aNode)
		{
			bool flag = m_List.Remove(aNode);
			return aNode;
		}

		[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x72E15C", Offset = "0x72E15C")]
		[Token(Token = "0x6000038")]
		[Address(RVA = "0x157093C", Offset = "0x157093C", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EDCE48]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20290E6]) = v38;\nL_0016:\n\tv42 = new com.adjust.sdk.JSONArray+<GetEnumerator>d__14();\n\tSystem.Object::.ctor(v42);\n\tv42.<>1__state = 0;\n\tv42.<>4__this = this;\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IEnumerator GetEnumerator()
		{
			_003CGetEnumerator_003Ed__14 _003CGetEnumerator_003Ed__15 = null;
			_003CGetEnumerator_003Ed__15._003C_003E1__state = 0;
			_003CGetEnumerator_003Ed__15._003C_003E4__this = this;
			return _003CGetEnumerator_003Ed__15;
		}

		[Token(Token = "0x6000039")]
		[Address(RVA = "0x15709DC", Offset = "0x15709DC", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1F03E20]);\n\tv25 = *([v24 @ X8_v21]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20290E7]) = v44;\nL_0018:\n\tv47 = 0;\n\tv49 = this.m_List == 0;\n\tif (v49) goto L_005E;\n\tv57 = System.Collections.Generic.List`1<com.adjust.sdk.JSONNode>::GetEnumerator(this.m_List);\nL_002A:\n\tv147 = System.Collections.Generic.List`1<com.adjust.sdk.JSONNode>+Enumerator<com.adjust.sdk.JSONNode>::MoveNext(&v47 @ stack_-58_v1 (System.Collections.Generic.List`1<com.adjust.sdk.JSONNode>+Enumerator<com.adjust.sdk.JSONNode>));\n\tv150 = v147 == 0;\n\tif (v150) goto L_0058;\n\tv132 = 0;\n\tv114 = v216.m_stringLength >= 3;\n\tif (v114) goto L_0045;\n\tgoto L_0049;\n\tgoto L_005D;\nL_0045:\n\tv194 = System.String::Concat(v216, \", \");\nL_0049:\n\tv142 = *([v132 @ X21_v6 (System.Int32)]);\n\t*([v142 @ X8_v18+160])(v232, 0, *([v142 @ X8_v18+168]), v59, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv137 = System.String::Concat(v144, v232);\n\tgoto L_002A;\nL_0058:\n\tv166 = System.Collections.Generic.List`1<com.adjust.sdk.JSONNode>+Enumerator<com.adjust.sdk.JSONNode>::Dispose(&v47 @ stack_-58_v1 (System.Collections.Generic.List`1<com.adjust.sdk.JSONNode>+Enumerator<com.adjust.sdk.JSONNode>));\n\tgoto L_0081;\n\tthrow System.NullReferenceException;\nL_005D:\n\tv99 = new System.NullReferenceException();\nL_005E:\n\tv108 = new System.NullReferenceException();\n\tgoto L_0065;\n\tX19 = 0;\n\tgoto L_006F;\n\tgoto L_006F;\n\tgoto L_0065;\nL_0065:\n\tgoto L_006F;\nL_006F:\n\tv160 = Il2CppMethodInfo != 1;\n\tif (v160) goto L_008B;\n\tv167 = 0x6D2BC0(v108, Il2CppMethodInfo, v59, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv174 = 0x6D2490(v167, Il2CppMethodInfo, v59, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv178 = System.Collections.Generic.List`1<com.adjust.sdk.JSONNode>+Enumerator<com.adjust.sdk.JSONNode>::Dispose(&v47 @ stack_-58_v1 (System.Collections.Generic.List`1<com.adjust.sdk.JSONNode>+Enumerator<com.adjust.sdk.JSONNode>));\n\tv241 = *([v167 @ X0_v12]) == 0;\n\tv180 = ~v241;\n\tif (v180) goto L_008F;\nL_0081:\n\treturnVal2 = System.String::Concat(v216, \" ]\");\n\treturn returnVal2;\nL_008B:\n\tv168 = 0x6D2380(v108, Il2CppMethodInfo, v59, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_008F:\n\treturnVal1 = new System.TypeLoadException();\n\treturn returnVal1;\n// 98 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			//IL_01da: Expected O, but got I4
			//IL_0026: Expected O, but got I4
			//IL_0086: Expected O, but got I4
			//IL_009b: Expected O, but got I4
			//IL_00bf: Expected O, but got I4
			List<JSONNode>.Enumerator enumerator = default(List<JSONNode>.Enumerator);
			bool flag = m_List == null;
			string text = (string)33722368;
			string text2;
			if (!flag)
			{
				List<JSONNode>.Enumerator enumerator2 = m_List.GetEnumerator();
				text2 = "[ ";
				text = (string)33722368;
				string text6 = default(string);
				while (enumerator.MoveNext())
				{
					int num = 0;
					string text3;
					object obj;
					if (text2.Length < 3)
					{
						text3 = text2;
					}
					else
					{
						string text4 = text2 + ", ";
						obj = 0;
						text3 = text4;
					}
					object obj2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v142 @ X8_v18+160] (should have been resolved before IL gen)");
					string text5 = text3 + text6;
					obj = 0;
					text2 = text5;
					text = text3;
				}
				enumerator.Dispose();
				goto IL_017d;
			}
			NullReferenceException ex = new NullReferenceException();
			if ((IntPtr)0 == (IntPtr)1)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj3 = default(object);
				bool flag2 = obj3 == null;
				bool flag3 = !flag2;
				text2 = text;
				if (!flag3)
				{
					goto IL_017d;
				}
			}
			else
			{
				Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			}
			return (string)(object)new TypeLoadException();
			IL_017d:
			return text2 + " ]";
		}

		[Token(Token = "0x600003A")]
		[Address(RVA = "0x1570B84", Offset = "0x1570B84", Length = "0x1FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv32 = *([1ECCA78]);\n\tv33 = *([v32 @ X8_v21]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, aPrefix, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([20290E8]) = v51;\nL_001C:\n\tv54 = 0;\n\tv56 = this.m_List == 0;\n\tif (v56) goto L_006E;\n\tv64 = System.Collections.Generic.List`1<com.adjust.sdk.JSONNode>::GetEnumerator(this.m_List);\nL_0032:\n\tv169 = System.Collections.Generic.List`1<com.adjust.sdk.JSONNode>+Enumerator<com.adjust.sdk.JSONNode>::MoveNext(&v54 @ stack_-68_v1 (System.Collections.Generic.List`1<com.adjust.sdk.JSONNode>+Enumerator<com.adjust.sdk.JSONNode>));\n\tv172 = v169 == 0;\n\tif (v172) goto L_0068;\n\tv153 = 0;\n\tv135 = v218.m_stringLength < 4;\n\tif (v135) goto L_0050;\n\tv214 = System.String::Concat(v218, \", \");\nL_0050:\n\tv223 = System.String::Concat(v218, \"\\n\", aPrefix, \"   \");\n\tv227 = System.String::Concat(aPrefix, \"   \");\n\tv164 = *([v153 @ X22_v6 (System.Int32)]);\n\t*([v164 @ X8_v18+240])(v305, 0, v227, *([v164 @ X8_v18+248]), \"   \", 0, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv158 = System.String::Concat(v223, v305);\n\tgoto L_0032;\nL_0068:\n\tv188 = System.Collections.Generic.List`1<com.adjust.sdk.JSONNode>+Enumerator<com.adjust.sdk.JSONNode>::Dispose(&v54 @ stack_-68_v1 (System.Collections.Generic.List`1<com.adjust.sdk.JSONNode>+Enumerator<com.adjust.sdk.JSONNode>));\n\tgoto L_0095;\n\tthrow System.NullReferenceException;\n\tv114 = new System.NullReferenceException();\nL_006E:\n\tv123 = new System.NullReferenceException();\n\tgoto L_0076;\n\tX20 = 0;\n\tgoto L_0081;\n\tgoto L_0081;\n\tgoto L_0076;\n\tgoto L_0076;\nL_0076:\n\tgoto L_0081;\n\tgoto L_0081;\nL_0081:\n\tv182 = v108 != 1;\n\tif (v182) goto L_00A2;\n\tv189 = 0x6D2BC0(v123, v108, v69, v65, v67, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv197 = 0x6D2490(v189, v108, v69, v65, v67, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv201 = System.Collections.Generic.List`1<com.adjust.sdk.JSONNode>+Enumerator<com.adjust.sdk.JSONNode>::Dispose(&v54 @ stack_-68_v1 (System.Collections.Generic.List`1<com.adjust.sdk.JSONNode>+Enumerator<com.adjust.sdk.JSONNode>));\n\tv275 = *([v189 @ X0_v12]) == 0;\n\tv203 = ~v275;\n\tif (v203) goto L_00A6;\nL_0095:\n\treturnVal2 = System.String::Concat(v218, *([v244 @ X23_v1 (System.String)]), aPrefix, \"]\");\n\treturn returnVal2;\nL_00A2:\n\tv190 = 0x6D2380(v123, v108, v69, v65, v67, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_00A6:\n\treturnVal1 = new System.TypeLoadException();\n\treturn returnVal1;\n// 119 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString(string aPrefix)
		{
			//IL_0074: Expected O, but got I4
			List<JSONNode>.Enumerator enumerator = default(List<JSONNode>.Enumerator);
			bool flag = m_List == null;
			string text = "\n";
			string text2;
			if (!flag)
			{
				List<JSONNode>.Enumerator enumerator2 = m_List.GetEnumerator();
				text2 = "[ ";
				string text7 = default(string);
				while (enumerator.MoveNext())
				{
					int num = 0;
					if (text2.Length >= 4)
					{
						string text3 = text2 + ", ";
						text2 = text3;
					}
					string text4 = text2 + "\n" + aPrefix + "   ";
					string text5 = aPrefix + "   ";
					object obj = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v164 @ X8_v18+240] (should have been resolved before IL gen)");
					string text6 = text4 + text7;
					text2 = text6;
				}
				enumerator.Dispose();
				text = "\n";
				goto IL_0142;
			}
			NullReferenceException ex = new NullReferenceException();
			string text8 = default(string);
			if ((IntPtr)text8 == (IntPtr)1)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj2 = default(object);
				bool flag2 = obj2 == null;
				bool flag3 = !flag2;
				string text9 = default(string);
				text2 = text9;
				if (!flag3)
				{
					goto IL_0142;
				}
			}
			else
			{
				Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			}
			return (string)(object)new TypeLoadException();
			IL_0142:
			return text2 + text + aPrefix + "]";
		}

		[Token(Token = "0x600003B")]
		[Address(RVA = "0x1570D80", Offset = "0x1570D80", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv24 = *([1F01B80]);\n\tv25 = *([v24 @ X8_v15]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, aWriter, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20290E9]) = v43;\nL_001D:\n\tv50 = System.IO.BinaryWriter::Write(aWriter, 1);\n\tv51 = this.m_List;\n\tv98 = System.IO.BinaryWriter::Write(aWriter, v51._size);\n\tv120 = this.m_List;\nL_0035:\n\tv140 = v134 >= v120._size;\n\tif (v140) goto L_005E;\n\tv185 = v120._size < v134;\n\tv81 = ~v185;\n\tv78 = v120._size - v134;\n\tv72 = v78 == 0;\n\tv186 = ~v72;\n\tv57 = v81 & v186;\n\tif (v57) goto L_0045;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0045:\n\tv189 = v120._items;\n\tv97 = com.adjust.sdk.JSONNode::Serialize(v189[v134 @ X21_v7 (System.Int32)], aWriter);\n\tv120 = this.m_List;\n\tv134 = v134 + 1;\n\tv190 = this.m_List == 0;\n\tv100 = ~v190;\n\tif (v100) goto L_0035;\n\tthrow System.NullReferenceException;\nL_005E:\n\treturn;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Serialize(BinaryWriter aWriter)
		{
			aWriter.Write((byte)1);
			List<JSONNode> list = m_List;
			aWriter.Write(list.Count);
			List<JSONNode> list2 = m_List;
			int num = 0;
			do
			{
				if (num < list2.Count)
				{
					bool flag = list2.Count < num;
					bool flag2 = !flag;
					int num2 = list2.Count - num;
					bool flag3 = num2 == 0;
					bool flag4 = !flag3;
					if (!(flag2 && flag4))
					{
						throw new ArgumentOutOfRangeException();
					}
					JSONNode[] items = list2._items;
					items[num].Serialize(aWriter);
					list2 = m_List;
					num++;
					continue;
				}
				return;
			}
			while (m_List != null);
			throw new NullReferenceException();
		}

		[Token(Token = "0x600003C")]
		[Address(RVA = "0x156FA44", Offset = "0x156FA44", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1F02648]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20290EA]) = v38;\nL_0016:\n\tv42 = new System.Collections.Generic.List`1<com.adjust.sdk.JSONNode>();\n\tSystem.Collections.Generic.List`1<com.adjust.sdk.JSONNode>::.ctor(v42);\n\tthis.m_List = v42;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public JSONArray()
		{
			List<JSONNode> list = new List<JSONNode>();
			m_List = list;
		}
	}
}
