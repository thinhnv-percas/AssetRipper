using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace com.adjust.sdk
{
	[AttributeAttribute(Type = typeof(DefaultMemberAttribute), RVA = "0x72DD50", Offset = "0x72DD50")]
	[Token(Token = "0x2000005")]
	public class JSONClass : JSONNode, IEnumerable
	{
		[CompilerGenerated]
		[Token(Token = "0x200001C")]
		private sealed class _003Cget_Childs_003Ed__14 : IEnumerable<JSONNode>, IEnumerable, IEnumerator<JSONNode>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400009D")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x400009E")]
			[FieldOffset(Offset = "0x18")]
			private JSONNode _003C_003E2__current;

			[Token(Token = "0x400009F")]
			[FieldOffset(Offset = "0x20")]
			internal int _003C_003El__initialThreadId;

			[Token(Token = "0x40000A0")]
			[FieldOffset(Offset = "0x28")]
			public JSONClass _003C_003E4__this;

			[Token(Token = "0x40000A1")]
			[FieldOffset(Offset = "0x30")]
			private Dictionary<string, JSONNode>.Enumerator _003C_003E7__wrap1;

			[Token(Token = "0x17000044")]
			JSONNode IEnumerator<JSONNode>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000156")]
				[Address(RVA = "0x1572C28", Offset = "0x1572C28", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000045")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000158")]
				[Address(RVA = "0x1572C94", Offset = "0x1572C94", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000152")]
			[Address(RVA = "0x1571BCC", Offset = "0x1571BCC", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\tv16 = System.Environment::get_CurrentManagedThreadId();\n\tthis.<>l__initialThreadId = v16;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003Cget_Childs_003Ed__14(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000153")]
			[Address(RVA = "0x1572A50", Offset = "0x1572A50", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.<>1__state == 1;\n\tif (v6) goto L_0012;\n\tv11 = this.<>1__state + 3;\n\tv13 = v11 == 0;\n\tv16 = ~v13;\n\tif (v16) goto L_0014;\nL_0012:\n\tcom.adjust.sdk.JSONClass+<get_Childs>d__14::<>m__Finally1(this);\n\treturn;\nL_0014:\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IDisposable.Dispose()
			{
				if (_003C_003E1__state == 1 || _003C_003E1__state + 3 == 0)
				{
					_003C_003Em__Finally1();
				}
			}

			[Token(Token = "0x6000154")]
			[Address(RVA = "0x1572AC4", Offset = "0x1572AC4", Length = "0x164")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EBE5B8]);\n\tv19 = *([v18 @ X8_v21]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029105]) = v38;\nL_0014:\n\tv40 = this.<>1__state == 0;\n\tif (v40) goto L_0025;\n\tv50 = this.<>1__state != 1;\n\tif (v50) goto L_FFFFFFFF;\n\tv120 = this + 0x30;\n\tthis.<>1__state = 0xFFFFFFFD;\n\tgoto L_003F;\nL_0025:\n\tv51 = this.<>4__this;\n\tthis.<>1__state = 0xFFFFFFFF;\n\tv86 = v51.m_Dict == 0;\n\tif (v86) goto L_0052;\n\tv116 = System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>::GetEnumerator(v51.m_Dict);\n\tv120 = this + 0x30;\n\t*([this @ X0 (com.adjust.sdk.JSONClass+<get_Childs>d__14)+50]) = v197;\n\t*([this @ X0 (com.adjust.sdk.JSONClass+<get_Childs>d__14)+40]) = v199;\n\tthis.<>1__state = 0xFFFFFFFD;\n\tthis.<>7__wrap1 = v92;\nL_003F:\n\tv126 = System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>+Enumerator<System.String, com.adjust.sdk.JSONNode>::MoveNext(v120);\n\tv145 = v126 == 0;\n\tif (v145) goto L_0049;\n\tthis.<>1__state = 1;\n\tthis.<>2__current = *([this @ X0 (com.adjust.sdk.JSONClass+<get_Childs>d__14)+48]);\n\tgoto L_0081;\nL_0049:\n\tcom.adjust.sdk.JSONClass+<get_Childs>d__14::<>m__Finally1(this);\n\t*([v120 @ X20_v4 (System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>+Enumerator<System.String, com.adjust.sdk.JSONNode>)+20]) = 0;\n\t*([v120 @ X20_v4 (System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>+Enumerator<System.String, com.adjust.sdk.JSONNode>)]) = 0;\n\tv120.dictionary = 0;\n\tgoto L_0081;\n\tv88 = new System.NullReferenceException();\nL_0052:\n\tv158 = new System.NullReferenceException();\n\tgoto L_005F;\n\tgoto L_005F;\n\tgoto L_005F;\nL_005F:\n\tv210 = methodInfo != 1;\n\tif (v210) goto L_0082;\n\tv211 = 0x6D2BC0(v158, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv213 = 0x6D2490(v211, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv219 = this.<>1__state == 1;\n\tif (v219) goto L_0077;\n\tv221 = this.<>1__state + 3;\n\tv223 = v221 == 0;\n\tv226 = ~v223;\n\tif (v226) goto L_0078;\nL_0077:\n\tcom.adjust.sdk.JSONClass+<get_Childs>d__14::<>m__Finally1(this);\nL_0078:\n\tv235 = *([v211 @ X0_v17]) == 0;\n\tv79 = ~v235;\n\tif (v79) goto L_0086;\nL_0081:\n\treturn returnVal1;\nL_0082:\n\tv212 = 0x6D2380(v158, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0086:\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private unsafe bool MoveNext()
			{
				//IL_009d: Expected O, but got I
				//IL_0033: Expected O, but got I
				//IL_0224: Expected I4, but got O
				//IL_0101: Expected O, but got I4
				//IL_0106: Expected native int or pointer, but got O
				//IL_00de: Expected O, but got I
				Dictionary<string, JSONNode>.Enumerator enumerator;
				if (_003C_003E1__state != 0)
				{
					if (_003C_003E1__state != 1)
					{
						goto IL_01f4;
					}
					enumerator = (Dictionary<string, JSONNode>.Enumerator)((long)(IntPtr)this + 48L);
					_003C_003E1__state = -3;
				}
				else
				{
					JSONClass jSONClass = _003C_003E4__this;
					_003C_003E1__state = -1;
					if (jSONClass.m_Dict == null)
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
								goto IL_01f4;
							}
						}
						else
						{
							Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
						}
						TypeLoadException ex2 = new TypeLoadException();
						return (byte)(int)ex2 != 0;
					}
					Dictionary<string, JSONNode>.Enumerator enumerator2 = jSONClass.m_Dict.GetEnumerator();
					enumerator = (Dictionary<string, JSONNode>.Enumerator)((long)(IntPtr)this + 48L);
					_003C_003E1__state = -3;
					Dictionary<string, JSONNode>.Enumerator enumerator3 = default(Dictionary<string, JSONNode>.Enumerator);
					_003C_003E7__wrap1 = enumerator3;
				}
				if (((Dictionary<string, JSONNode>.Enumerator*)enumerator)->MoveNext())
				{
					_003C_003E1__state = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (com.adjust.sdk.JSONClass+<get_Childs>d__14)+48]");
					_003C_003E2__current = (JSONNode)0;
					return true;
				}
				_003C_003Em__Finally1();
				_ = 0;
				enumerator = (Dictionary<string, JSONNode>.Enumerator)0;
				System.Runtime.CompilerServices.Unsafe.Write(&((Dictionary<string, JSONNode>.Enumerator*)(IntPtr)enumerator)->dictionary, null);
				return false;
				IL_01f4:
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[Token(Token = "0x6000155")]
			[Address(RVA = "0x1572A6C", Offset = "0x1572A6C", Length = "0x58")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EF4A48]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029106]) = v38;\nL_0014:\n\tthis.<>1__state = 0xFFFFFFFF;\n\tv44 = this + 0x30;\n\tv48 = System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>+Enumerator<System.String, com.adjust.sdk.JSONNode>::Dispose(v44);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private unsafe void _003C_003Em__Finally1()
			{
				//IL_001c: Expected O, but got I
				_003C_003E1__state = -1;
				Dictionary<string, JSONNode>.Enumerator enumerator = (Dictionary<string, JSONNode>.Enumerator)((long)(IntPtr)this + 48L);
				((Dictionary<string, JSONNode>.Enumerator*)enumerator)->Dispose();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000157")]
			[Address(RVA = "0x1572C30", Offset = "0x1572C30", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1F01930]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([2029107]) = v34;\nL_0014:\n\tv38 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw new TypeLoadException();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000159")]
			[Address(RVA = "0x1572C9C", Offset = "0x1572C9C", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1F0CE30]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029108]) = v38;\nL_0014:\n\tv40 = this.<>1__state + 2;\n\tv42 = v40 == 0;\n\tv45 = ~v42;\n\tif (v45) goto L_002E;\n\tv48 = System.Environment::get_CurrentManagedThreadId();\n\tv50 = this.<>l__initialThreadId != v48;\n\tif (v50) goto L_002E;\n\tthis.<>1__state = 0;\n\tgoto L_0041;\nL_002E:\n\tv76 = new com.adjust.sdk.JSONClass+<get_Childs>d__14();\n\tSystem.Object::.ctor(v76);\n\tv76.<>1__state = 0;\n\tv81 = System.Environment::get_CurrentManagedThreadId();\n\tv76.<>l__initialThreadId = v81;\n\tv76.<>4__this = this.<>4__this;\nL_0041:\n\treturn v95;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
				_003Cget_Childs_003Ed__14 _003Cget_Childs_003Ed__15 = null;
				_003Cget_Childs_003Ed__15._003C_003E1__state = 0;
				int currentManagedThreadId2 = Environment.CurrentManagedThreadId;
				_003Cget_Childs_003Ed__15._003C_003El__initialThreadId = currentManagedThreadId2;
				_003Cget_Childs_003Ed__15._003C_003E4__this = _003C_003E4__this;
				return _003Cget_Childs_003Ed__15;
			}

			[DebuggerHidden]
			[Token(Token = "0x600015A")]
			[Address(RVA = "0x1572D4C", Offset = "0x1572D4C", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = com.adjust.sdk.JSONClass+<get_Childs>d__14::System.Collections.Generic.IEnumerable<com.adjust.sdk.JSONNode>.GetEnumerator(this);\n\treturn returnVal1;\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<JSONNode>)this).GetEnumerator();
			}
		}

		[Token(Token = "0x400000A")]
		[FieldOffset(Offset = "0x10")]
		private Dictionary<string, JSONNode> m_Dict;

		[Token(Token = "0x17000011")]
		public override JSONNode Item
		{
			[Token(Token = "0x600003D")]
			[Address(RVA = "0x15713A0", Offset = "0x15713A0", Length = "0xBC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1EB5588]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, aKey, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20290F2]) = v41;\nL_001C:\n\tv48 = System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>::ContainsKey(this.m_Dict, aKey);\n\tv58 = v48 == 0;\n\tif (v58) goto L_0032;\n\treturnVal2 = System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>::get_Item(this.m_Dict, aKey);\n\treturn returnVal2;\nL_0032:\n\tv62 = new com.adjust.sdk.JSONLazyCreator();\n\tSystem.Object::.ctor(v62);\n\tv62.m_Node = this;\n\tv62.m_Key = aKey;\n\treturn v62;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (m_Dict.ContainsKey(aKey))
				{
					return m_Dict.get_Item(aKey);
				}
				JSONLazyCreator jSONLazyCreator = null;
				jSONLazyCreator.m_Node = this;
				jSONLazyCreator.m_Key = aKey;
				return jSONLazyCreator;
			}
			[Token(Token = "0x600003E")]
			[Address(RVA = "0x1571494", Offset = "0x1571494", Length = "0xC4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv26 = *([1EB84A8]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, aKey, value, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20290F3]) = v44;\nL_001E:\n\tv51 = System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>::ContainsKey(this.m_Dict, aKey);\n\tv63 = v51 == 0;\n\tif (v63) goto L_0041;\n\tSystem.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>::set_Item(this.m_Dict, aKey, value);\n\treturn;\nL_0041:\n\tSystem.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>::Add(this.m_Dict, aKey, value);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				if (m_Dict.ContainsKey(aKey))
				{
					m_Dict.set_Item(aKey, value);
				}
				else
				{
					m_Dict.Add(aKey, value);
				}
			}
		}

		[Token(Token = "0x17000012")]
		public override JSONNode Item
		{
			[Token(Token = "0x600003F")]
			[Address(RVA = "0x1571558", Offset = "0x1571558", Length = "0x98")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EB9C68]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, aIndex, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20290F4]) = v41;\nL_0015:\n\tv42 = aIndex & 0x80000000;\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tif (v44) goto L_FFFFFFFF;\n\tv77 = System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>::get_Count(this.m_Dict);\n\tv48 = v77 <= aIndex;\n\tif (v48) goto L_FFFFFFFF;\n\tv131 = System.Linq.Enumerable::ElementAt(this.m_Dict, aIndex);\n\tgoto L_003C;\nL_003C:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_006f: Expected I4, but got I8
				//IL_004e: Expected O, but got I4
				if ((int)(aIndex & 0x80000000L) == 0)
				{
					int count = m_Dict.Count;
					if (count > aIndex)
					{
						KeyValuePair<string, JSONNode> keyValuePair = m_Dict.ElementAt(aIndex);
						return (JSONNode)aIndex;
					}
				}
				return null;
			}
			[Token(Token = "0x6000040")]
			[Address(RVA = "0x15715F0", Offset = "0x15715F0", Length = "0xC8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EF1DF8]);\n\tv27 = *([v26 @ X8_v12]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, aIndex, value, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20290F5]) = v44;\nL_0017:\n\tv45 = aIndex & 0x80000000;\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tif (v47) goto L_004E;\n\tv80 = System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>::get_Count(this.m_Dict);\n\tv51 = v80 <= aIndex;\n\tif (v51) goto L_004E;\n\tv147 = System.Linq.Enumerable::ElementAt(this.m_Dict, aIndex);\n\tSystem.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>::set_Item(this.m_Dict, v147, value);\n\treturn;\nL_004E:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0072: Expected I4, but got I8
				if ((int)(aIndex & 0x80000000L) == 0)
				{
					int count = m_Dict.Count;
					if (count > aIndex)
					{
						KeyValuePair<string, JSONNode> key = m_Dict.ElementAt(aIndex);
						m_Dict.set_Item((string)key, value);
					}
				}
			}
		}

		[Token(Token = "0x17000013")]
		public override int Count
		{
			[Token(Token = "0x6000041")]
			[Address(RVA = "0x15716B8", Offset = "0x15716B8", Length = "0x58")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = *([1EE15F8]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20290F6]) = v38;\nL_001E:\n\treturnVal1 = System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>::get_Count(this.m_Dict);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return m_Dict.Count;
			}
		}

		[Token(Token = "0x17000014")]
		public override IEnumerable<JSONNode> Childs
		{
			[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x72E1C0", Offset = "0x72E1C0")]
			[Token(Token = "0x6000046")]
			[Address(RVA = "0x1571B48", Offset = "0x1571B48", Length = "0x84")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EB3118]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20290FB]) = v38;\nL_0016:\n\tv42 = new com.adjust.sdk.JSONClass+<get_Childs>d__14();\n\tSystem.Object::.ctor(v42);\n\tv42.<>1__state = 0xFFFFFFFE;\n\tv47 = System.Environment::get_CurrentManagedThreadId();\n\tv42.<>l__initialThreadId = v47;\n\tv42.<>4__this = this;\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				_003Cget_Childs_003Ed__14 _003Cget_Childs_003Ed__15 = new _003Cget_Childs_003Ed__14(-2);
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003Cget_Childs_003Ed__15._003C_003El__initialThreadId = currentManagedThreadId;
				_003Cget_Childs_003Ed__15._003C_003E4__this = this;
				return _003Cget_Childs_003Ed__15;
			}
		}

		[Token(Token = "0x6000042")]
		[Address(RVA = "0x1571710", Offset = "0x1571710", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1ED8A40]);\n\tv27 = *([v26 @ X8_v18]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, aKey, aItem, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20290F7]) = v44;\nL_001B:\n\tv49 = System.String::IsNullOrEmpty(v144);\n\tv52 = v49 == 0;\n\tif (v52) goto L_0042;\n\tgoto L_002D;\n\tv60 = *([v55 @ X0_v13+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tif (v62) goto L_002D;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v55, v46, aItem, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_002D:\n\tv68 = System.Guid::NewGuid();\n\tv83 = 0xC12510(&v68 @ X0_v16 (System.Guid), 0, aItem, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_0057;\nL_0042:\n\tv49 = System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>::ContainsKey(this.m_Dict, v144);\n\tv94 = v49 == 0;\n\tif (v94) goto L_FFFFFFFF;\n\tSystem.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>::set_Item(this.m_Dict, v144, aItem);\n\tgoto L_005F;\nL_0057:\n\tSystem.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>::Add(v147, v83, aItem);\nL_005F:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Add(string aKey, JSONNode aItem)
		{
			string text = default(string);
			Dictionary<string, JSONNode> dict;
			if (string.IsNullOrEmpty(text))
			{
				Guid guid = Guid.NewGuid();
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @C12510 (inside System.Guid::StringToLong +0x320)");
				dict = m_Dict;
			}
			else
			{
				if (m_Dict.ContainsKey(text))
				{
					m_Dict.set_Item(text, aItem);
					return;
				}
				dict = m_Dict;
			}
			string key = default(string);
			dict.Add(key, aItem);
		}

		[Token(Token = "0x6000043")]
		[Address(RVA = "0x1571840", Offset = "0x1571840", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1EC06A0]);\n\tv23 = *([v22 @ X8_v13]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, aKey, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20290F8]) = v41;\nL_001C:\n\tv48 = System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>::ContainsKey(this.m_Dict, aKey);\n\tv58 = v48 == 0;\n\tif (v58) goto L_FFFFFFFF;\n\tv64 = System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>::get_Item(this.m_Dict, aKey);\n\tv84 = System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>::Remove(this.m_Dict, aKey);\n\tgoto L_003B;\nL_003B:\n\treturn v86;\n\tthrow System.NullReferenceException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override JSONNode Remove(string aKey)
		{
			if (m_Dict.ContainsKey(aKey))
			{
				JSONNode result = m_Dict.get_Item(aKey);
				bool flag = m_Dict.Remove(aKey);
				return result;
			}
			return null;
		}

		[Token(Token = "0x6000044")]
		[Address(RVA = "0x1571904", Offset = "0x1571904", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EDA010]);\n\tv23 = *([v22 @ X8_v14]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, aIndex, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20290F9]) = v41;\nL_0015:\n\tv42 = aIndex & 0x80000000;\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tif (v44) goto L_FFFFFFFF;\n\tv77 = System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>::get_Count(this.m_Dict);\n\tv48 = v77 <= aIndex;\n\tif (v48) goto L_FFFFFFFF;\n\tv158 = System.Linq.Enumerable::ElementAt(this.m_Dict, aIndex);\n\tv122 = System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>::Remove(this.m_Dict, v158);\n\tgoto L_0046;\nL_0046:\n\treturn v124;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override JSONNode Remove(int aIndex)
		{
			//IL_0087: Expected I4, but got I8
			//IL_0066: Expected O, but got I4
			if ((int)(aIndex & 0x80000000L) == 0)
			{
				int count = m_Dict.Count;
				if (count > aIndex)
				{
					KeyValuePair<string, JSONNode> key = m_Dict.ElementAt(aIndex);
					bool flag = m_Dict.Remove((string)key);
					return (JSONNode)aIndex;
				}
			}
			return null;
		}

		[Token(Token = "0x6000045")]
		[Address(RVA = "0x15719C0", Offset = "0x15719C0", Length = "0x180")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1EB8838]);\n\tv25 = *([v24 @ X8_v22]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, aNode, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20290FA]) = v43;\nL_0019:\n\tv47 = new com.adjust.sdk.JSONClass+<>c__DisplayClass12_0();\n\tSystem.Object::.ctor(v47);\n\tv47.aNode = aNode;\n\tv55 = new System.Func`2<System.Collections.Generic.KeyValuePair`2<System.String, com.adjust.sdk.JSONNode>, System.Boolean>();\n\tSystem.Func`2<System.Collections.Generic.KeyValuePair`2<System.String, com.adjust.sdk.JSONNode>, System.Boolean>::.ctor(v55, v47, Il2CppMethodInfo);\n\tv87 = System.Linq.Enumerable::Where(this.m_Dict, v55);\n\tv90 = System.Linq.Enumerable::First(v87);\n\tv78 = this.m_Dict == 0;\n\tif (v78) goto L_004C;\n\tv123 = System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>::Remove(this.m_Dict, v90);\n\treturnVal2 = v47.aNode;\nL_0049:\n\treturn returnVal2;\n\tv57 = new System.NullReferenceException();\nL_004C:\n\tv82 = new System.NullReferenceException();\n\tgoto L_005A;\n\tgoto L_005A;\n\tgoto L_005A;\nL_005A:\n\tv101 = 0 != 1;\n\tif (v101) goto L_0076;\n\tv103 = System.Func`2<System.Collections.Generic.KeyValuePair`2<System.String, com.adjust.sdk.JSONNode>, System.Boolean>::.ctor(v82, 0, v104);\n\tv126 = *([v103 @ X0_v12 (System.Func`2<System.Collections.Generic.KeyValuePair`2<System.String, com.adjust.sdk.JSONNode>, System.Boolean>)]);\n\tv129 = \"il2cpp_vm_class_is_assignable_from\"(System.Object, *([v126 @ X8_v8 (Il2CppClass<System.Func`2<System.Collections.Generic.KeyValuePair`2<System.String, com.adjust.sdk.JSONNode>, System.Boolean>>)]), v104, v67, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv132 = v129 & 1;\n\tv113 = v132 == 0;\n\tif (v113) goto L_006C;\n\tv168 = System.Func`2<System.Collections.Generic.KeyValuePair`2<System.String, com.adjust.sdk.JSONNode>, System.Boolean>::.ctor(v129, *([v126 @ X8_v8 (Il2CppClass<System.Func`2<System.Collections.Generic.KeyValuePair`2<System.String, com.adjust.sdk.JSONNode>, System.Boolean>>)]), v104);\n\tgoto L_0049;\nL_006C:\n\tv170 = System.Func`2<System.Collections.Generic.KeyValuePair`2<System.String, com.adjust.sdk.JSONNode>, System.Boolean>::.ctor(8, *([v126 @ X8_v8 (Il2CppClass<System.Func`2<System.Collections.Generic.KeyValuePair`2<System.String, com.adjust.sdk.JSONNode>, System.Boolean>>)]), v104);\n\t*([v170 @ X0_v16 (System.Func`2<System.Collections.Generic.KeyValuePair`2<System.String, com.adjust.sdk.JSONNode>, System.Boolean>)]) = *([v103 @ X0_v12 (System.Func`2<System.Collections.Generic.KeyValuePair`2<System.String, com.adjust.sdk.JSONNode>, System.Boolean>)]);\n\tv109 = 0x1E8A000 + 0x870;\n\tv194 = System.Func`2<System.Collections.Generic.KeyValuePair`2<System.String, com.adjust.sdk.JSONNode>, System.Boolean>::.ctor(v170, v109, 0);\n\tv111 = System.Func`2<System.Collections.Generic.KeyValuePair`2<System.String, com.adjust.sdk.JSONNode>, System.Boolean>::.ctor(v194, v109, 0);\nL_0076:\n\tv119 = System.Func`2<System.Collections.Generic.KeyValuePair`2<System.String, com.adjust.sdk.JSONNode>, System.Boolean>::.ctor(v114, v108, 0);\n\treturnVal1 = System.Func`2<System.Collections.Generic.KeyValuePair`2<System.String, com.adjust.sdk.JSONNode>, System.Boolean>::.ctor(v119, v108, 0);\n\treturn returnVal1;\n// 80 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override JSONNode Remove(JSONNode aNode)
		{
			//IL_00de: Expected I, but got O
			//IL_013f: Expected O, but got I4
			Func<KeyValuePair<string, JSONNode>, bool> predicate = delegate
			{
				//IL_0014: Expected O, but got I
				IntPtr intPtr2 = default(IntPtr);
				return (JSONNode)(long)intPtr2 == aNode;
			};
			IEnumerable<KeyValuePair<string, JSONNode>> source = m_Dict.Where(predicate);
			KeyValuePair<string, JSONNode> key = source.First();
			bool flag = m_Dict == null;
			string text = null;
			if (!flag)
			{
				bool flag2 = m_Dict.Remove((string)key);
				return aNode;
			}
			IntPtr method = default(IntPtr);
			NullReferenceException ex = (NullReferenceException)(object)new Func<KeyValuePair<string, JSONNode>, bool>(null, method);
			bool flag3 = 0 != 1;
			NullReferenceException ex2 = ex;
			if (!flag3)
			{
				Func<KeyValuePair<string, JSONNode>, bool> func = default(Func<KeyValuePair<string, JSONNode>, bool>);
				IntPtr intPtr = (IntPtr)func;
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
				Func<KeyValuePair<string, JSONNode>, bool> func2 = default(Func<KeyValuePair<string, JSONNode>, bool>);
				if ((uint)((ulong)(long)(IntPtr)func2 & 1uL) != 0)
				{
					return null;
				}
				Func<KeyValuePair<string, JSONNode>, bool> func3 = func;
				object obj = 32022528 + 2160;
				text = (string)obj;
				Func<KeyValuePair<string, JSONNode>, bool> func4 = default(Func<KeyValuePair<string, JSONNode>, bool>);
				ex2 = (NullReferenceException)(object)func4;
			}
			JSONNode result = default(JSONNode);
			return result;
		}

		[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x72E224", Offset = "0x72E224")]
		[Token(Token = "0x6000047")]
		[Address(RVA = "0x156FAE0", Offset = "0x156FAE0", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1F09E88]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20290FC]) = v38;\nL_0016:\n\tv42 = new com.adjust.sdk.JSONClass+<GetEnumerator>d__15();\n\tSystem.Object::.ctor(v42);\n\tv42.<>1__state = 0;\n\tv42.<>4__this = this;\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IEnumerator GetEnumerator()
		{
			_003CGetEnumerator_003Ed__15 _003CGetEnumerator_003Ed__16 = null;
			_003CGetEnumerator_003Ed__16._003C_003E1__state = 0;
			_003CGetEnumerator_003Ed__16._003C_003E4__this = this;
			return _003CGetEnumerator_003Ed__16;
		}

		[Token(Token = "0x6000048")]
		[Address(RVA = "0x1571C30", Offset = "0x1571C30", Length = "0x3A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv32 = *([1EFC9B8]);\n\tv33 = *([v32 @ X8_v50]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([20290FD]) = v52;\nL_001F:\n\tv58 = this.m_Dict == 0;\n\tif (v58) goto L_0108;\n\tv67 = System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>::GetEnumerator(this.m_Dict);\nL_003C:\n\tv188 = System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>+Enumerator<System.String, com.adjust.sdk.JSONNode>::MoveNext(&v66 @ stack_-B8_v3 (System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>+Enumerator<System.String, com.adjust.sdk.JSONNode>));\n\tv200 = v188 == 0;\n\tif (v200) goto L_00D7;\n\tv237 = v183.m_stringLength >= 3;\n\tif (v237) goto L_0055;\n\tgoto L_0059;\nL_0055:\n\tv247 = System.String::Concat(v183, \", \");\nL_0059:\n\t// 89 NewArr v263 @ X0_v62 (System.String[]), typeof(System.String[]), 5\n\tv382 = v492 == 0;\n\tif (v382) goto L_0065;\n\t// 98 IsInst v418 @ X0_v83, typeof(System.String), v492 @ X19_v13 (System.String)\n\tv420 = v418 == 0;\n\tif (v420) goto L_00F4;\nL_0065:\n\tv412 = v263.Length;\n\tv373 = v263.Length == 0;\n\tif (v373) goto L_00DE;\n\tv263[0] = v492;\n\tv426 = \"\\\"\" == 0;\n\tif (v426) goto L_0072;\n\t// 110 IsInst v500 @ X0_v81, typeof(System.String), \"\"\"\n\tv501 = v500 == 0;\n\tif (v501) goto L_00F8;\n\tv412 = v263.Length;\nL_0072:\n\tv503 = v412 < 1;\n\tv401 = ~v503;\n\tv399 = v412 - 1;\n\tv395 = v399 == 0;\n\tv504 = ~v401;\n\tv385 = v504 | v395;\n\tif (v385) goto L_00E2;\n\tv263[1] = \"\\\"\";\n\tv513 = com.adjust.sdk.JSONNode::Escape(v141);\n\tv567 = v513 == 0;\n\tif (v567) goto L_008B;\n\t// 136 IsInst v595 @ X0_v80, typeof(System.String), v513 @ X0_v67 (System.String)\n\tv596 = v595 == 0;\n\tif (v596) goto L_00FC;\nL_008B:\n\tv586 = v263.Length;\n\tv598 = v263.Length < 2;\n\tv445 = ~v598;\n\tv443 = v263.Length - 2;\n\tv439 = v443 == 0;\n\tv599 = ~v445;\n\tv429 = v599 | v439;\n\tif (v429) goto L_00E6;\n\tv263[2] = v513;\n\tv624 = \"\\\":\" == 0;\n\tif (v624) goto L_00A2;\n\t// 158 IsInst v636 @ X0_v78, typeof(System.String), \"\":\"\n\tv637 = v636 == 0;\n\tif (v637) goto L_0100;\n\tv586 = v263.Length;\nL_00A2:\n\tv639 = v586 < 3;\n\tv532 = ~v639;\n\tv530 = v586 - 3;\n\tv526 = v530 == 0;\n\tv640 = ~v532;\n\tv516 = v640 | v526;\n\tif (v516) goto L_00EC;\n\tv263[3] = \"\\\":\";\n\tv664 = *([v227 @ stack_-78]);\n\t*([v664 @ X8_v38+160])(v667, v227, *([v664 @ X8_v38+168]), v148, v37, v38, v39, v40, v41, v141, v66, v44, v45, v46, v47, v48, v49);\n\tv668 = v667 == 0;\n\tif (v668) goto L_00C1;\n\t// 189 IsInst v673 @ X0_v77, typeof(System.String), v667 @ X0_v72\n\tv674 = v673 == 0;\n\tif (v674) goto L_0104;\nL_00C1:\n\tv679 = v263.Length < 4;\n\tv166 = ~v679;\n\tv164 = v263.Length - 4;\n\tv160 = v164 == 0;\n\tv680 = ~v166;\n\tv150 = v680 | v160;\n\tif (v150) goto L_00F0;\n\tv263[4] = v667;\n\tv176 = System.String::Concat(v263);\n\tgoto L_003C;\nL_00D7:\n\tv208 = System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>+Enumerator<System.String, com.adjust.sdk.JSONNode>::Dispose(&v66 @ stack_-B8_v3 (System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>+Enumerator<System.String, com.adjust.sdk.JSONNode>));\n\tgoto L_0135;\n\tthrow System.NullReferenceException;\n\tv271 = new System.NullReferenceException();\nL_00DE:\n\tv378 = new System.IndexOutOfRangeException();\n\tthrow v378;\nL_00E2:\n\tv414 = new System.IndexOutOfRangeException();\n\tthrow v414;\nL_00E6:\n\tv458 = new System.IndexOutOfRangeException();\n\tthrow v458;\n\tv546 = new System.NullReferenceException();\nL_00EC:\n\tv588 = new System.IndexOutOfRangeException();\n\tthrow v588;\nL_00F0:\n\tv630 = new System.IndexOutOfRangeException();\n\tthrow v630;\nL_00F4:\n\tv497 = new System.ArrayTypeMismatchException();\n\tthrow v497;\nL_00F8:\n\tv566 = new System.ArrayTypeMismatchException();\n\tthrow v566;\nL_00FC:\n\tv622 = new System.ArrayTypeMismatchException();\n\tthrow v622;\nL_0100:\n\tv660 = new System.ArrayTypeMismatchException();\n\tthrow v660;\nL_0104:\n\tv676 = new System.ArrayTypeMismatchException();\n\tthrow v676;\nL_0108:\n\tv138 = new System.NullReferenceException();\n\tgoto L_0123;\n\tX19 = 0;\n\tgoto L_0123;\n\tgoto L_0123;\n\tgoto L_0123;\n\tgoto L_0123;\n\tgoto L_0123;\n\tgoto L_0123;\n\tX19 = X20;\n\tgoto L_0123;\n\tgoto L_0123;\n\tgoto L_0123;\n\tgoto L_0123;\n\tgoto L_0123;\n\tgoto L_0123;\n\tgoto L_0123;\n\tgoto L_0123;\nL_0123:\n\tv198 = v123 != 1;\n\tif (v198) goto L_0143;\n\tv201 = 0x6D2BC0(v138, v123, v148, v37, v38, v39, v40, v41, 0, v117, v44, v45, v46, v47, v48, v49);\n\tv210 = 0x6D2490(v201, v123, v148, v37, v38, v39, v40, v41, 0, v117, v44, v45, v46, v47, v48, v49);\n\tv214 = System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>+Enumerator<System.String, com.adjust.sdk.JSONNode>::Dispose(&v105 @ stack_-90_v3 (System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>+Enumerator<System.String, com.adjust.sdk.JSONNode>));\n\tv308 = *([v201 @ X0_v12]) == 0;\n\tv216 = ~v308;\n\tif (v216) goto L_0147;\nL_0135:\n\treturnVal2 = System.String::Concat(v299, \"}\");\n\treturn returnVal2;\nL_0143:\n\tv202 = 0x6D2380(v138, v123, v148, v37, v38, v39, v40, v41, 0, v117, v44, v45, v46, v47, v48, v49);\nL_0147:\n\treturnVal1 = new System.TypeLoadException();\n\treturn returnVal1;\n// 187 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			//IL_00cf: Expected O, but got I4
			//IL_0568: Expected O, but got I
			//IL_01ca: Expected O, but got I4
			//IL_01f6: Expected O, but got I4
			//IL_0153: Expected O, but got I4
			//IL_05c6: Expected O, but got I
			//IL_0290: Expected O, but got I4
			//IL_0332: Expected O, but got I4
			//IL_043e: Expected I, but got O
			bool flag = m_Dict == null;
			Dictionary<string, JSONNode>.Enumerator enumerator = default(Dictionary<string, JSONNode>.Enumerator);
			string text6;
			IntPtr intPtr = default(IntPtr);
			if (!flag)
			{
				Dictionary<string, JSONNode>.Enumerator enumerator2 = m_Dict.GetEnumerator();
				string text = "{";
				Dictionary<string, JSONNode>.Enumerator enumerator3 = default(Dictionary<string, JSONNode>.Enumerator);
				string aText = default(string);
				object obj11 = default(object);
				object obj12 = default(object);
				while (enumerator3.MoveNext())
				{
					string text2;
					if (text.Length < 3)
					{
						text2 = text;
					}
					else
					{
						string text3 = text + ", ";
						int num = 0;
						text2 = text3;
					}
					string[] array = new string[5];
					if (text2 != null)
					{
						object obj = text2 as string;
						if (obj == null)
						{
							ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
							throw ex;
						}
					}
					object obj2 = array.Length;
					if (array.Length != 0)
					{
						array[0] = text2;
						if ("\"" != null)
						{
							object obj3 = "\"" as string;
							if (obj3 == null)
							{
								ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
								throw ex2;
							}
							obj2 = array.Length;
						}
						bool flag2 = (long)(IntPtr)obj2 < 1L;
						bool flag3 = !flag2;
						object obj4 = (long)(IntPtr)obj2 - 1L;
						bool flag4 = obj4 == null;
						bool flag5 = !flag3;
						if (!(flag5 || flag4))
						{
							array[1] = "\"";
							string text4 = JSONNode.Escape(aText);
							if (text4 != null)
							{
								object obj5 = text4 as string;
								if (obj5 == null)
								{
									ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
									throw ex3;
								}
							}
							object obj6 = array.Length;
							bool flag6 = array.Length < 2;
							bool flag7 = !flag6;
							object obj7 = array.Length - 2;
							bool flag8 = obj7 == null;
							bool flag9 = !flag7;
							if (!(flag9 || flag8))
							{
								array[2] = text4;
								if ("\":" != null)
								{
									object obj8 = "\":" as string;
									if (obj8 == null)
									{
										ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
										throw ex4;
									}
									obj6 = array.Length;
								}
								bool flag10 = (long)(IntPtr)obj6 < 3L;
								bool flag11 = !flag10;
								object obj9 = (long)(IntPtr)obj6 - 3L;
								bool flag12 = obj9 == null;
								bool flag13 = !flag11;
								if (!(flag13 || flag12))
								{
									array[3] = "\":";
									object obj10 = obj11;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v664 @ X8_v38+160] (should have been resolved before IL gen)");
									if (obj12 != null)
									{
										object obj13 = obj12 as string;
										if (obj13 == null)
										{
											ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
											int num = 0;
											intPtr = (IntPtr)null;
											throw ex5;
										}
									}
									bool flag14 = array.Length < 4;
									bool flag15 = !flag14;
									object obj14 = array.Length - 4;
									bool flag16 = obj14 == null;
									bool flag17 = !flag15;
									if (!(flag17 || flag16))
									{
										array[4] = (string)obj12;
										string text5 = string.Concat(array);
										text = text5;
										continue;
									}
									IndexOutOfRangeException ex6 = new IndexOutOfRangeException();
									throw ex6;
								}
								IndexOutOfRangeException ex7 = new IndexOutOfRangeException();
								throw ex7;
							}
							IndexOutOfRangeException ex8 = new IndexOutOfRangeException();
							throw ex8;
						}
						IndexOutOfRangeException ex9 = new IndexOutOfRangeException();
						throw ex9;
					}
					IndexOutOfRangeException ex10 = new IndexOutOfRangeException();
					throw ex10;
				}
				enumerator3.Dispose();
				text6 = text;
				goto IL_04ca;
			}
			NullReferenceException ex11 = new NullReferenceException();
			if (intPtr == (IntPtr)1)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj15 = default(object);
				bool flag18 = obj15 == null;
				bool flag19 = !flag18;
				text6 = this;
				if (!flag19)
				{
					goto IL_04ca;
				}
			}
			else
			{
				Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			}
			return (string)(object)new TypeLoadException();
			IL_04ca:
			return text6 + "}";
		}

		[Token(Token = "0x6000049")]
		[Address(RVA = "0x1572158", Offset = "0x1572158", Length = "0x408")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv36 = *([1EBCC88]);\n\tv37 = *([v36 @ X8_v57]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, aPrefix, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([20290FE]) = v55;\nL_0021:\n\tv61 = this.m_Dict == 0;\n\tif (v61) goto L_0118;\n\tv70 = System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>::GetEnumerator(this.m_Dict);\nL_003D:\n\tv198 = System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>+Enumerator<System.String, com.adjust.sdk.JSONNode>::MoveNext(&v69 @ stack_-B8_v3 (System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>+Enumerator<System.String, com.adjust.sdk.JSONNode>));\n\tv210 = v198 == 0;\n\tif (v210) goto L_00E7;\n\tv248 = v262.m_stringLength < 4;\n\tif (v248) goto L_0060;\n\tv259 = System.String::Concat(v262, \", \");\nL_0060:\n\tv271 = System.String::Concat(v262, \"\\n\", v128, \"   \");\n\t// 100 NewArr v290 @ X0_v64 (System.String[]), typeof(System.String[]), 5\n\tv417 = v271 == 0;\n\tif (v417) goto L_0070;\n\t// 109 IsInst v455 @ X0_v87, typeof(System.String), v271 @ X0_v62 (System.String)\n\tv457 = v455 == 0;\n\tif (v457) goto L_0104;\nL_0070:\n\tv449 = v290.Length;\n\tv408 = v290.Length == 0;\n\tif (v408) goto L_00EE;\n\tv290[0] = v271;\n\tv463 = \"\\\"\" == 0;\n\tif (v463) goto L_007D;\n\t// 121 IsInst v543 @ X0_v85, typeof(System.String), \"\"\"\n\tv544 = v543 == 0;\n\tif (v544) goto L_0108;\n\tv449 = v290.Length;\nL_007D:\n\tv546 = v449 < 1;\n\tv438 = ~v546;\n\tv436 = v449 - 1;\n\tv432 = v436 == 0;\n\tv547 = ~v438;\n\tv422 = v547 | v432;\n\tif (v422) goto L_00F2;\n\tv290[1] = \"\\\"\";\n\tv556 = com.adjust.sdk.JSONNode::Escape(v148);\n\tv613 = v556 == 0;\n\tif (v613) goto L_0096;\n\t// 147 IsInst v623 @ X0_v84, typeof(System.String), v556 @ X0_v69 (System.String)\n\tv624 = v623 == 0;\n\tif (v624) goto L_010C;\nL_0096:\n\tv588 = v290.Length;\n\tv626 = v290.Length < 2;\n\tv484 = ~v626;\n\tv482 = v290.Length - 2;\n\tv478 = v482 == 0;\n\tv627 = ~v484;\n\tv468 = v627 | v478;\n\tif (v468) goto L_00F6;\n\tv290[2] = v556;\n\tv678 = \"\\\" : \" == 0;\n\tif (v678) goto L_00AD;\n\t// 169 IsInst v690 @ X0_v82, typeof(System.String), \"\" : \"\n\tv691 = v690 == 0;\n\tif (v691) goto L_0110;\n\tv588 = v290.Length;\nL_00AD:\n\tv693 = v588 < 3;\n\tv577 = ~v693;\n\tv575 = v588 - 3;\n\tv571 = v575 == 0;\n\tv694 = ~v577;\n\tv561 = v694 | v571;\n\tif (v561) goto L_00FA;\n\tv290[3] = \"\\\" : \";\n\tv646 = System.String::Concat(v128, \"   \");\n\tv730 = *([v237 @ stack_-78]);\n\t*([v730 @ X8_v43+240])(v732, v237, v646, *([v730 @ X8_v43+248]), \"   \", 0, v42, v43, v44, v148, v69, v47, v48, v49, v50, v51, v52);\n\tv733 = v732 == 0;\n\tif (v733) goto L_00D1;\n\t// 205 IsInst v726 @ X0_v81, typeof(System.String), v732 @ X0_v76\n\tv727 = v726 == 0;\n\tif (v727) goto L_0114;\nL_00D1:\n\tv736 = v290.Length < 4;\n\tv177 = ~v736;\n\tv175 = v290.Length - 4;\n\tv171 = v175 == 0;\n\tv737 = ~v177;\n\tv161 = v737 | v171;\n\tif (v161) goto L_0100;\n\tv290[4] = v732;\n\tv187 = System.String::Concat(v290);\n\tgoto L_003D;\nL_00E7:\n\tv218 = System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>+Enumerator<System.String, com.adjust.sdk.JSONNode>::Dispose(&v69 @ stack_-B8_v3 (System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>+Enumerator<System.String, com.adjust.sdk.JSONNode>));\n\tgoto L_014E;\n\tthrow System.NullReferenceException;\n\tv297 = new System.NullReferenceException();\nL_00EE:\n\tv413 = new System.IndexOutOfRangeException();\n\tthrow v413;\nL_00F2:\n\tv451 = new System.IndexOutOfRangeException();\n\tthrow v451;\nL_00F6:\n\tv497 = new System.IndexOutOfRangeException();\n\tthrow v497;\nL_00FA:\n\tv590 = new System.IndexOutOfRangeException();\n\tthrow v590;\n\tv654 = new System.NullReferenceException();\nL_0100:\n\tv684 = new System.IndexOutOfRangeException();\n\tthrow v684;\nL_0104:\n\tv540 = new System.ArrayTypeMismatchException();\n\tthrow v540;\nL_0108:\n\tv612 = new System.ArrayTypeMismatchException();\n\tthrow v612;\nL_010C:\n\tv676 = new System.ArrayTypeMismatchException();\n\tthrow v676;\nL_0110:\n\tv716 = new System.ArrayTypeMismatchException();\n\tthrow v716;\nL_0114:\n\tv729 = new System.ArrayTypeMismatchException();\n\tthrow v729;\nL_0118:\n\tv145 = new System.NullReferenceException();\n\tgoto L_0138;\n\tX20 = 0;\n\tgoto L_0138;\n\tgoto L_0138;\n\tgoto L_0138;\n\tgoto L_0138;\n\tgoto L_0138;\n\tgoto L_0138;\n\tX20 = X22;\n\tgoto L_0138;\n\tgoto L_0138;\n\tgoto L_0138;\n\tgoto L_0138;\n\tgoto L_0138;\n\tgoto L_0138;\n\tgoto L_0138;\n\tgoto L_0138;\n\tgoto L_0138;\n\tX20 = X22;\n\tgoto L_0138;\n\tX20 = X22;\n\tgoto L_0138;\nL_0138:\n\tv208 = v128 != 1;\n\tif (v208) goto L_015D;\n\tv211 = 0x6D2BC0(v145, v128, v75, v71, v73, v42, v43, v44, 0, v122, v47, v48, v49, v50, v51, v52);\n\tv220 = 0x6D2490(v211, v128, v75, v71, v73, v42, v43, v44, 0, v122, v47, v48, v49, v50, v51, v52);\n\tv224 = System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>+Enumerator<System.String, com.adjust.sdk.JSONNode>::Dispose(&v108 @ stack_-90_v3 (System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>+Enumerator<System.String, com.adjust.sdk.JSONNode>));\n\tv340 = *([v211 @ X0_v12]) == 0;\n\tv226 = ~v340;\n\tif (v226) goto L_0161;\nL_014E:\n\treturnVal2 = System.String::Concat(v327, \"\\n\", v128, \"}\");\n\treturn returnVal2;\nL_015D:\n\tv212 = 0x6D2380(v145, v128, v75, v71, v73, v42, v43, v44, 0, v122, v47, v48, v49, v50, v51, v52);\nL_0161:\n\treturnVal1 = new System.TypeLoadException();\n\treturn returnVal1;\n// 207 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString(string aPrefix)
		{
			//IL_00c8: Expected O, but got I4
			//IL_00b0: Expected O, but got I4
			//IL_05ed: Expected O, but got I
			//IL_0146: Expected O, but got I4
			//IL_01e7: Expected O, but got I4
			//IL_0213: Expected O, but got I4
			//IL_015e: Expected O, but got I4
			//IL_01cf: Expected O, but got I4
			//IL_064b: Expected O, but got I
			//IL_02a7: Expected O, but got I4
			//IL_02bf: Expected O, but got I4
			//IL_0385: Expected O, but got I4
			//IL_03be: Expected O, but got I4
			//IL_034b: Expected O, but got I4
			//IL_049a: Expected I, but got O
			bool flag = m_Dict == null;
			Dictionary<string, JSONNode>.Enumerator enumerator = default(Dictionary<string, JSONNode>.Enumerator);
			string text4 = default(string);
			string text9;
			if (!flag)
			{
				Dictionary<string, JSONNode>.Enumerator enumerator2 = m_Dict.GetEnumerator();
				string text = "{ ";
				Dictionary<string, JSONNode>.Enumerator enumerator3 = default(Dictionary<string, JSONNode>.Enumerator);
				string aText = default(string);
				object obj12 = default(object);
				object obj13 = default(object);
				while (enumerator3.MoveNext())
				{
					if (text.Length >= 4)
					{
						string text2 = text + ", ";
						text = text2;
					}
					string text3 = text + "\n" + text4 + "   ";
					string[] array = new string[5];
					if (text3 != null)
					{
						object obj = text3 as string;
						bool flag2 = obj == null;
						string text5 = "   ";
						object obj2 = 0;
						if (flag2)
						{
							ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
							throw ex;
						}
					}
					object obj3 = array.Length;
					if (array.Length != 0)
					{
						array[0] = text3;
						if ("\"" != null)
						{
							object obj4 = "\"" as string;
							bool flag3 = obj4 == null;
							string text5 = "   ";
							object obj2 = 0;
							if (flag3)
							{
								ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
								throw ex2;
							}
							obj3 = array.Length;
						}
						bool flag4 = (long)(IntPtr)obj3 < 1L;
						bool flag5 = !flag4;
						object obj5 = (long)(IntPtr)obj3 - 1L;
						bool flag6 = obj5 == null;
						bool flag7 = !flag5;
						if (!(flag7 || flag6))
						{
							array[1] = "\"";
							string text6 = JSONNode.Escape(aText);
							if (text6 != null)
							{
								object obj6 = text6 as string;
								bool flag8 = obj6 == null;
								string text5 = "   ";
								object obj2 = 0;
								if (flag8)
								{
									ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
									throw ex3;
								}
							}
							object obj7 = array.Length;
							bool flag9 = array.Length < 2;
							bool flag10 = !flag9;
							object obj8 = array.Length - 2;
							bool flag11 = obj8 == null;
							bool flag12 = !flag10;
							if (!(flag12 || flag11))
							{
								array[2] = text6;
								if ("\" : " != null)
								{
									object obj9 = "\" : " as string;
									bool flag13 = obj9 == null;
									string text5 = "   ";
									object obj2 = 0;
									if (flag13)
									{
										ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
										throw ex4;
									}
									obj7 = array.Length;
								}
								bool flag14 = (long)(IntPtr)obj7 < 3L;
								bool flag15 = !flag14;
								object obj10 = (long)(IntPtr)obj7 - 3L;
								bool flag16 = obj10 == null;
								bool flag17 = !flag15;
								if (!(flag17 || flag16))
								{
									array[3] = "\" : ";
									string text7 = text4 + "   ";
									object obj11 = obj12;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v730 @ X8_v43+240] (should have been resolved before IL gen)");
									string text5;
									object obj2;
									if (obj13 != null)
									{
										object obj14 = obj13 as string;
										bool flag18 = obj14 == null;
										text5 = "   ";
										obj2 = 0;
										if (flag18)
										{
											ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
											IntPtr intPtr = (IntPtr)null;
											text4 = null;
											throw ex5;
										}
									}
									bool flag19 = array.Length < 4;
									bool flag20 = !flag19;
									object obj15 = array.Length - 4;
									bool flag21 = obj15 == null;
									bool flag22 = !flag20;
									bool flag23 = flag22 || flag21;
									text5 = "   ";
									obj2 = 0;
									if (!flag23)
									{
										array[4] = (string)obj13;
										string text8 = string.Concat(array);
										text = text8;
										continue;
									}
									IndexOutOfRangeException ex6 = new IndexOutOfRangeException();
									throw ex6;
								}
								IndexOutOfRangeException ex7 = new IndexOutOfRangeException();
								throw ex7;
							}
							IndexOutOfRangeException ex8 = new IndexOutOfRangeException();
							throw ex8;
						}
						IndexOutOfRangeException ex9 = new IndexOutOfRangeException();
						throw ex9;
					}
					IndexOutOfRangeException ex10 = new IndexOutOfRangeException();
					throw ex10;
				}
				enumerator3.Dispose();
				text9 = text;
				goto IL_052b;
			}
			NullReferenceException ex11 = new NullReferenceException();
			if ((IntPtr)text4 == (IntPtr)1)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj16 = default(object);
				bool flag24 = obj16 == null;
				bool flag25 = !flag24;
				text9 = this;
				if (!flag25)
				{
					goto IL_052b;
				}
			}
			else
			{
				Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			}
			return (string)(object)new TypeLoadException();
			IL_052b:
			return text9 + "\n" + text4 + "}";
		}

		[Token(Token = "0x600004A")]
		[Address(RVA = "0x1572560", Offset = "0x1572560", Length = "0x1C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EB2F40]);\n\tv27 = *([v26 @ X8_v25]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, aWriter, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([20290FF]) = v45;\nL_0019:\n\tv48 = 0;\n\tv49 = aWriter == 0;\n\tif (v49) goto L_0065;\n\tv50 = aWriter->klass;\n\tv84 = aWriter->klass->vtable[8];\n\tv55 = System.IO.BinaryWriter::Write(aWriter, 2);\n\tv57 = this.m_Dict == 0;\n\tif (v57) goto L_0065;\n\tv81 = System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>::get_Count(this.m_Dict);\n\tv98 = aWriter->klass;\n\tv84 = aWriter->klass->vtable[16];\n\tv103 = System.IO.BinaryWriter::Write(aWriter, v81);\n\tv95 = this.m_Dict == 0;\n\tif (v95) goto L_0065;\n\tv93 = System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>::get_Keys(this.m_Dict);\n\tv96 = v93 == 0;\n\tif (v96) goto L_0065;\n\tv121 = System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>+KeyCollection<System.String, com.adjust.sdk.JSONNode>::GetEnumerator(v93);\nL_0043:\n\tv156 = System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>+KeyCollection<System.String, com.adjust.sdk.JSONNode>+Enumerator<System.String, com.adjust.sdk.JSONNode>::MoveNext(&v48 @ stack_-58_v1 (System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>+KeyCollection<System.String, com.adjust.sdk.JSONNode>+Enumerator<System.String, com.adjust.sdk.JSONNode>));\n\tv203 = v156 == 0;\n\tif (v203) goto L_0060;\n\tv223 = System.IO.BinaryWriter::Write(aWriter, 0);\n\tv230 = System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>::get_Item(this.m_Dict, 0);\n\tv148 = com.adjust.sdk.JSONNode::Serialize(v230, aWriter);\n\tgoto L_0043;\nL_0060:\n\tv216 = System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>+KeyCollection<System.String, com.adjust.sdk.JSONNode>+Enumerator<System.String, com.adjust.sdk.JSONNode>::Dispose(&v48 @ stack_-58_v1 (System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>+KeyCollection<System.String, com.adjust.sdk.JSONNode>+Enumerator<System.String, com.adjust.sdk.JSONNode>));\n\tgoto L_0089;\n\tv231 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_0065:\n\tv101 = new System.NullReferenceException();\n\tgoto L_0074;\n\tgoto L_0074;\n\tgoto L_0074;\n\tgoto L_0074;\n\tgoto L_0074;\nL_0074:\n\tv114 = v67 != 1;\n\tif (v114) goto L_008A;\n\tv115 = 0x6D2BC0(v101, v67, v84, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv123 = 0x6D2490(v115, v67, v84, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv127 = System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>+KeyCollection<System.String, com.adjust.sdk.JSONNode>+Enumerator<System.String, com.adjust.sdk.JSONNode>::Dispose(&v48 @ stack_-58_v1 (System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>+KeyCollection<System.String, com.adjust.sdk.JSONNode>+Enumerator<System.String, com.adjust.sdk.JSONNode>));\n\tv157 = *([v115 @ X0_v8]) == 0;\n\tv129 = ~v157;\n\tif (v129) goto L_008E;\nL_0089:\n\treturn;\nL_008A:\n\tv116 = 0x6D2380(v101, v67, v84, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_008E:\n\tthrow System.TypeLoadException;\n// 92 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Serialize(BinaryWriter aWriter)
		{
			//IL_000d: Expected I, but got O
			//IL_0045: Expected O, but got I4
			//IL_006a: Expected I, but got O
			//IL_00a0: Expected O, but got I4
			//IL_00d2: Expected O, but got I
			Dictionary<string, JSONNode>.KeyCollection.Enumerator enumerator = default(Dictionary<string, JSONNode>.KeyCollection.Enumerator);
			BinaryWriter binaryWriter = default(BinaryWriter);
			if (aWriter != null)
			{
				IntPtr intPtr = (IntPtr)aWriter;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X8_v9 (Il2CppClass<System.IO.BinaryWriter>)+1B8]");
				IntPtr intPtr2 = (IntPtr)0;
				aWriter.Write((byte)2);
				bool flag = m_Dict == null;
				binaryWriter = (BinaryWriter)2;
				if (!flag)
				{
					int count = m_Dict.Count;
					IntPtr intPtr3 = (IntPtr)aWriter;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ X8_v12 (Il2CppClass<System.IO.BinaryWriter>)+238]");
					intPtr2 = (IntPtr)0;
					aWriter.Write(count);
					bool flag2 = m_Dict == null;
					binaryWriter = (BinaryWriter)count;
					if (!flag2)
					{
						Dictionary<string, JSONNode>.KeyCollection keys = m_Dict.Keys;
						bool flag3 = keys == null;
						binaryWriter = (BinaryWriter)0;
						if (!flag3)
						{
							Dictionary<string, JSONNode>.KeyCollection.Enumerator enumerator2 = keys.GetEnumerator();
							while (enumerator.MoveNext())
							{
								aWriter.Write((string)null);
								JSONNode jSONNode = m_Dict.get_Item((string)null);
								jSONNode.Serialize(aWriter);
							}
							enumerator.Dispose();
							return;
						}
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			if ((IntPtr)binaryWriter == (IntPtr)1)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj = default(object);
				if (obj == null)
				{
					return;
				}
			}
			else
			{
				Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x600004B")]
		[Address(RVA = "0x1572724", Offset = "0x1572724", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1ED01F8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029100]) = v38;\nL_0016:\n\tv42 = new System.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, com.adjust.sdk.JSONNode>::.ctor(v42);\n\tthis.m_Dict = v42;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public JSONClass()
		{
			Dictionary<string, JSONNode> dict = new Dictionary<string, JSONNode>();
			m_Dict = dict;
		}
	}
}
