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
	[AttributeAttribute(Type = typeof(DefaultMemberAttribute), RVA = "0x72DCE0", Offset = "0x72DCE0")]
	[Token(Token = "0x2000003")]
	public class JSONNode
	{
		[CompilerGenerated]
		[Token(Token = "0x2000017")]
		private sealed class _003Cget_Childs_003Ed__17 : IEnumerable<JSONNode>, IEnumerable, IEnumerator<JSONNode>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400008A")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x400008B")]
			[FieldOffset(Offset = "0x18")]
			private JSONNode _003C_003E2__current;

			[Token(Token = "0x400008C")]
			[FieldOffset(Offset = "0x20")]
			internal int _003C_003El__initialThreadId;

			[Token(Token = "0x1700003C")]
			JSONNode IEnumerator<JSONNode>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000131")]
				[Address(RVA = "0x1574BD4", Offset = "0x1574BD4", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x1700003D")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000133")]
				[Address(RVA = "0x1574C40", Offset = "0x1574C40", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x600012E")]
			[Address(RVA = "0x1573CA4", Offset = "0x1573CA4", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\tv16 = System.Environment::get_CurrentManagedThreadId();\n\tthis.<>l__initialThreadId = v16;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003Cget_Childs_003Ed__17(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x600012F")]
			[Address(RVA = "0x1574BB8", Offset = "0x1574BB8", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000130")]
			[Address(RVA = "0x1574BBC", Offset = "0x1574BBC", Length = "0x18")]
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
			[Token(Token = "0x6000132")]
			[Address(RVA = "0x1574BDC", Offset = "0x1574BDC", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EFAE18]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([2029137]) = v34;\nL_0014:\n\tv38 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw new TypeLoadException();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000134")]
			[Address(RVA = "0x1574C48", Offset = "0x1574C48", Length = "0x98")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EE4108]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029138]) = v38;\nL_0014:\n\tv40 = this.<>1__state + 2;\n\tv42 = v40 == 0;\n\tv45 = ~v42;\n\tif (v45) goto L_002E;\n\tv48 = System.Environment::get_CurrentManagedThreadId();\n\tv50 = this.<>l__initialThreadId != v48;\n\tif (v50) goto L_002E;\n\tthis.<>1__state = 0;\n\tgoto L_003C;\nL_002E:\n\tv76 = new com.adjust.sdk.JSONNode+<get_Childs>d__17();\n\tSystem.Object::.ctor(v76);\n\tv76.<>1__state = 0;\n\tv81 = System.Environment::get_CurrentManagedThreadId();\n\tv76.<>l__initialThreadId = v81;\nL_003C:\n\treturn v93;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
				_003Cget_Childs_003Ed__17 _003Cget_Childs_003Ed__18 = null;
				_003Cget_Childs_003Ed__18._003C_003E1__state = 0;
				int currentManagedThreadId2 = Environment.CurrentManagedThreadId;
				_003Cget_Childs_003Ed__18._003C_003El__initialThreadId = currentManagedThreadId2;
				return _003Cget_Childs_003Ed__18;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000135")]
			[Address(RVA = "0x1574CE0", Offset = "0x1574CE0", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = com.adjust.sdk.JSONNode+<get_Childs>d__17::System.Collections.Generic.IEnumerable<com.adjust.sdk.JSONNode>.GetEnumerator(this);\n\treturn returnVal1;\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<JSONNode>)this).GetEnumerator();
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000018")]
		private sealed class _003Cget_DeepChilds_003Ed__19 : IEnumerable<JSONNode>, IEnumerable, IEnumerator<JSONNode>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400008D")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x400008E")]
			[FieldOffset(Offset = "0x18")]
			private JSONNode _003C_003E2__current;

			[Token(Token = "0x400008F")]
			[FieldOffset(Offset = "0x20")]
			internal int _003C_003El__initialThreadId;

			[Token(Token = "0x4000090")]
			[FieldOffset(Offset = "0x28")]
			public JSONNode _003C_003E4__this;

			[Token(Token = "0x4000091")]
			[FieldOffset(Offset = "0x30")]
			private IEnumerator<JSONNode> _003C_003E7__wrap1;

			[Token(Token = "0x4000092")]
			[FieldOffset(Offset = "0x38")]
			private IEnumerator<JSONNode> _003C_003E7__wrap2;

			[Token(Token = "0x1700003E")]
			JSONNode IEnumerator<JSONNode>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600013B")]
				[Address(RVA = "0x1575300", Offset = "0x1575300", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x1700003F")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600013D")]
				[Address(RVA = "0x157536C", Offset = "0x157536C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000136")]
			[Address(RVA = "0x1573D60", Offset = "0x1573D60", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\tv16 = System.Environment::get_CurrentManagedThreadId();\n\tthis.<>l__initialThreadId = v16;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003Cget_DeepChilds_003Ed__19(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000137")]
			[Address(RVA = "0x1574CE4", Offset = "0x1574CE4", Length = "0x78")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.<>1__state & 0xFFFFFFFE;\n\tv12 = v11 + 4;\n\tv14 = v12 == 0;\n\tv17 = ~v14;\n\tif (v17) goto L_0029;\n\tv18 = this.<>1__state + 4;\n\tv20 = v18 == 0;\n\tif (v20) goto L_002C;\n\tv37 = this.<>1__state == 1;\n\tif (v37) goto L_002C;\n\tgoto L_0032;\nL_0029:\n\tv32 = this.<>1__state != 1;\n\tif (v32) goto L_0038;\nL_002C:\n\tcom.adjust.sdk.JSONNode+<get_DeepChilds>d__19::<>m__Finally2(this);\nL_0032:\n\tcom.adjust.sdk.JSONNode+<get_DeepChilds>d__19::<>m__Finally1(this);\n\treturn;\nL_0038:\n\treturn;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0047;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_0032;\nL_0047:\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IDisposable.Dispose()
			{
				//IL_0014: Expected I4, but got I8
				int num = (int)(_003C_003E1__state & 0xFFFFFFFEL);
				if (num + 4 == 0)
				{
					if (_003C_003E1__state + 4 != 0 && _003C_003E1__state != 1)
					{
						goto IL_00c8;
					}
				}
				else if (_003C_003E1__state != 1)
				{
					return;
				}
				_003C_003Em__Finally2();
				goto IL_00c8;
				IL_00c8:
				_003C_003Em__Finally1();
			}

			[Token(Token = "0x6000138")]
			[Address(RVA = "0x1574EDC", Offset = "0x1574EDC", Length = "0x424")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EBFA80]);\n\tv21 = *([v20 @ X8_v45]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2029139]) = v40;\nL_0015:\n\tv42 = this.<>1__state == 0;\n\tif (v42) goto L_0028;\n\tv52 = this.<>1__state != 1;\n\tif (v52) goto L_FFFFFFFF;\n\tv128 = this + 0x38;\n\tgoto L_00DC;\nL_0028:\n\tthis.<>1__state = 0xFFFFFFFF;\n\tv110 = com.adjust.sdk.JSONNode::get_Childs(this.<>4__this);\n\tv112 = v110 == 0;\n\tif (v112) goto L_006C;\n\tgoto L_005F;\n\tv276 = *([v226 @ X8_v38+B0]);\n\tv277 = 0;\n\tv278 = v276 + 8;\n\tv280 = *([v411 @ X11_v45-8]);\n\tv426 = v280 == v229;\n\tif (v426) goto L_0058;\n\tv284 = v412 + 1;\n\tv511 = v284 < v228;\n\tv310 = ~v511;\n\tv282 = v411 + 0x10;\n\tv286 = ~v310;\n\tif (v286) goto L_FFFFFFFF;\n\tv312 = v111;\n\tv313 = 0;\n\tv314 = 0x8909C4(v312, v229, v313, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_005F;\nL_0058:\n\tv512 = *([v411 @ X11_v45]);\n\tv513 = v512 << 4;\n\tv514 = v226 + v513;\n\tv515 = v514 + 0x130;\nL_005F:\n\tv397 = System.Collections.Generic.IEnumerable`1<com.adjust.sdk.JSONNode>::GetEnumerator(v110);\n\tv180 = this + 0x30;\n\tthis.<>7__wrap1 = v397;\n\tthis.<>1__state = 0xFFFFFFFD;\n\tv521 = v397 == 0;\n\tv400 = ~v521;\n\tif (v400) goto L_0147;\n\tgoto L_018D;\n\tthrow System.NullReferenceException;\nL_006C:\n\tv457 = new System.NullReferenceException();\n\tgoto L_01A3;\n\tgoto L_01A3;\n\tgoto L_0189;\n\tgoto L_01A3;\nL_007B:\n\tgoto L_00A2;\n\tv770 = *([v765 @ X8_v25+B0]);\n\tv771 = 0;\n\tv772 = v770 + 8;\n\tv774 = *([v801 @ X11_v33-8]);\n\tv816 = v774 == v768;\n\tif (v816) goto L_009B;\n\tv778 = v802 + 1;\n\tv821 = v778 < v767;\n\tv796 = ~v821;\n\tv776 = v801 + 0x10;\n\tv780 = ~v796;\n\tif (v780) goto L_FFFFFFFF;\n\tv797 = v560;\n\tv798 = 0;\n\tv799 = 0x8909C4(v797, v768, v798, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_00A2;\nL_009B:\n\tv822 = *([v801 @ X11_v33]);\n\tv823 = v822 << 4;\n\tv824 = v765 + v823;\n\tv825 = v824 + 0x130;\nL_00A2:\n\tv623 = System.Collections.Generic.IEnumerator`1<com.adjust.sdk.JSONNode>::get_Current(*([v180 @ X21_v12]));\n\tv667 = com.adjust.sdk.JSONNode::get_DeepChilds(v623);\n\tv668 = v667 == 0;\n\tif (v668) goto L_0194;\n\tgoto L_00D6;\n\tv834 = *([v830 @ X8_v28+B0]);\n\tv835 = 0;\n\tv836 = v834 + 8;\n\tv838 = *([v865 @ X11_v28-8]);\n\tv880 = v838 == v833;\n\tif (v880) goto L_00CF;\n\tv842 = v866 + 1;\n\tv885 = v842 < v832;\n\tv860 = ~v885;\n\tv840 = v865 + 0x10;\n\tv844 = ~v860;\n\tif (v844) goto L_FFFFFFFF;\n\tv861 = v669;\n\tv862 = 0;\n\tv863 = 0x8909C4(v861, v833, v862, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_00D6;\nL_00CF:\n\tv886 = *([v865 @ X11_v28]);\n\tv887 = v886 << 4;\n\tv888 = v830 + v887;\n\tv889 = v888 + 0x130;\nL_00D6:\n\tv149 = System.Collections.Generic.IEnumerable`1<com.adjust.sdk.JSONNode>::GetEnumerator(v667);\n\tv128 = this + 0x38;\n\tthis.<>7__wrap2 = v149;\nL_00DC:\n\tthis.<>1__state = 0xFFFFFFFC;\n\tgoto L_010C;\n\tv315 = *([v240 @ X8_v7+B0]);\n\tv316 = 0;\n\tv317 = v315 + 8;\n\tv319 = *([v466 @ X11_v13-8]);\n\tv481 = v319 == v243;\n\tif (v481) goto L_0105;\n\tv323 = v467 + 1;\n\tv527 = v323 < v242;\n\tv341 = ~v527;\n\tv321 = v466 + 0x10;\n\tv325 = ~v341;\n\tif (v325) goto L_FFFFFFFF;\n\tv342 = v154;\n\tv343 = 0;\n\tv344 = 0x8909C4(v342, v243, v343, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_010C;\nL_0105:\n\tv528 = *([v466 @ X11_v13]);\n\tv529 = v528 << 4;\n\tv530 = v240 + v529;\n\tv531 = v530 + 0x130;\nL_010C:\n\tv504 = System.Collections.IEnumerator::MoveNext(v154);\n\tv536 = v504 == 0;\n\tif (v536) goto L_013A;\n\tgoto L_017F;\n\tv692 = *([v661 @ X8_v10+B0]);\n\tv693 = 0;\n\tv694 = v692 + 8;\n\tv696 = *([v734 @ X11_v8-8]);\n\tv749 = v696 == v664;\n\tif (v749) goto L_0178;\n\tv700 = v735 + 1;\n\tv755 = v700 < v663;\n\tv718 = ~v755;\n\tv698 = v734 + 0x10;\n\tv702 = ~v718;\n\tif (v702) goto L_FFFFFFFF;\n\tv719 = v218;\n\tv720 = 0;\n\tv721 = 0x8909C4(v719, v664, v720, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_017F;\nL_013A:\n\tcom.adjust.sdk.JSONNode+<get_DeepChilds>d__19::<>m__Finally2(this);\n\tv180 = this + 0x30;\n\tv219 = this.<>7__wrap1;\n\tthis.<>7__wrap2 = 0;\nL_0147:\n\tgoto L_016E;\n\tv630 = *([v583 @ X8_v22+B0]);\n\tv631 = 0;\n\tv632 = v630 + 8;\n\tv634 = *([v672 @ X11_v38-8]);\n\tv687 = v634 == v586;\n\tif (v687) goto L_0167;\n\tv638 = v673 + 1;\n\tv722 = v638 < v585;\n\tv656 = ~v722;\n\tv636 = v672 + 0x10;\n\tv640 = ~v656;\n\tif (v640) goto L_FFFFFFFF;\n\tv657 = v219;\n\tv658 = 0;\n\tv659 = 0x8909C4(v657, v586, v658, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_016E;\nL_0167:\n\tv723 = *([v672 @ X11_v38]);\n\tv724 = v723 << 4;\n\tv725 = v583 + v724;\n\tv726 = v725 + 0x130;\nL_016E:\n\tv555 = System.Collections.IEnumerator::MoveNext(v219);\n\tv731 = v555 == 0;\n\tv213 = ~v731;\n\tif (v213) goto L_007B;\n\tcom.adjust.sdk.JSONNode+<get_DeepChilds>d__19::<>m__Finally1(this);\n\t*([v180 @ X21_v12]) = 0;\n\tgoto L_0189;\nL_0178:\n\tv756 = *([v734 @ X11_v8]);\n\tv757 = v756 << 4;\n\tv758 = v661 + v757;\n\tv759 = v758 + 0x130;\nL_017F:\n\tv763 = System.Collections.Generic.IEnumerator`1<com.adjust.sdk.JSONNode>::get_Current(*([v128 @ X21_v3]));\n\tthis.<>2__current = v763;\n\tthis.<>1__state = 1;\nL_0189:\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\nL_018D:\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tv562 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_0194:\n\tv457 = new System.NullReferenceException();\n\tgoto L_01A3;\n\tgoto L_01A3;\n\tgoto L_01A3;\n\tgoto L_01A3;\n\tgoto L_01A3;\nL_01A3:\n\tv81 = v256 != 1;\n\tif (v81) goto L_01B0;\n\tv522 = 0x6D2BC0(v457, v256, v251, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv588 = 0x6D2490(v522, v256, v251, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tcom.adjust.sdk.JSONNode+<get_DeepChilds>d__19::System.IDisposable.Dispose(this);\n\tv101 = *([v522 @ X0_v23]) == 0;\n\tif (v101) goto L_FFFFFFFF;\n\tv526 = new System.TypeLoadException();\nL_01B0:\n\treturnVal2 = 0x6D2380(v457, v256, v251, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\treturn returnVal2;\n// 231 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				//IL_0033: Expected O, but got I
				//IL_0234: Expected O, but got I
				//IL_0102: Expected O, but got I
				//IL_01cb: Expected I, but got O
				//IL_012c: Expected O, but got I4
				//IL_00d3: Expected I, but got O
				//IL_02a9: Expected O, but got I
				object obj;
				IEnumerator enumerator;
				if (_003C_003E1__state != 0)
				{
					if (_003C_003E1__state != 1)
					{
						goto IL_0096;
					}
					obj = (long)(IntPtr)this + 56L;
					enumerator = _003C_003E7__wrap2;
					goto IL_020b;
				}
				_003C_003E1__state = -1;
				IEnumerable<JSONNode> childs = _003C_003E4__this.Childs;
				if (childs == null)
				{
					NullReferenceException ex = new NullReferenceException();
					goto IL_014e;
				}
				IEnumerator<JSONNode> enumerator2 = childs.GetEnumerator();
				object obj2 = (long)(IntPtr)this + 48L;
				_003C_003E7__wrap1 = enumerator2;
				_003C_003E1__state = -3;
				bool flag = enumerator2 == null;
				bool flag2 = !flag;
				IEnumerator<JSONNode> enumerator3 = enumerator2;
				if (flag2)
				{
					goto IL_031a;
				}
				throw new NullReferenceException();
				IL_020b:
				_003C_003E1__state = -4;
				if (!enumerator.MoveNext())
				{
					_003C_003Em__Finally2();
					obj2 = (long)(IntPtr)this + 48L;
					enumerator3 = _003C_003E7__wrap1;
					_003C_003E7__wrap2 = null;
					goto IL_031a;
				}
				JSONNode current = ((IEnumerator<JSONNode>)obj).Current;
				_003C_003E2__current = current;
				_003C_003E1__state = 1;
				return true;
				IL_031a:
				if (!enumerator3.MoveNext())
				{
					_003C_003Em__Finally1();
					obj2 = 0;
					return false;
				}
				JSONNode current2 = ((IEnumerator<JSONNode>)obj2).Current;
				IEnumerable<JSONNode> deepChilds = current2.DeepChilds;
				bool flag3 = deepChilds == null;
				int num = 0;
				IntPtr intPtr = (IntPtr)null;
				if (flag3)
				{
					NullReferenceException ex = new NullReferenceException();
					goto IL_014e;
				}
				IEnumerator<JSONNode> enumerator4 = deepChilds.GetEnumerator();
				obj = (long)(IntPtr)this + 56L;
				_003C_003E7__wrap2 = enumerator4;
				enumerator = enumerator4;
				goto IL_020b;
				IL_0096:
				return false;
				IL_014e:
				if (intPtr == (IntPtr)1)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
					((IDisposable)this).Dispose();
					object obj3 = default(object);
					if (obj3 == null)
					{
						goto IL_0096;
					}
					TypeLoadException ex2 = new TypeLoadException();
					num = 0;
					intPtr = (IntPtr)null;
					NullReferenceException ex = (NullReferenceException)(object)ex2;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
				bool result = default(bool);
				return result;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[Token(Token = "0x6000139")]
			[Address(RVA = "0x1574E1C", Offset = "0x1574E1C", Length = "0xC0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EBFAF8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202913A]) = v38;\nL_0015:\n\tthis.<>1__state = 0xFFFFFFFF;\n\tv41 = this.<>7__wrap1 == 0;\n\tif (v41) goto L_0043;\n\tgoto L_0050;\n\tv52 = *([v43 @ X8_v4+B0]);\n\tv53 = 0;\n\tv54 = v52 + 8;\n\tv56 = *([v151 @ X11_v5-8]);\n\tv157 = v56 == v46;\n\tif (v157) goto L_0044;\n\tv89 = v152 + 1;\n\tv162 = v89 < v45;\n\tv83 = ~v162;\n\tv86 = v151 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_FFFFFFFF;\n\tv90 = v39;\n\tv91 = 0;\n\tv92 = 0x8909C4(v90, v46, v91, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0050;\nL_0043:\n\treturn;\nL_0044:\n\tv163 = *([v151 @ X11_v5]);\n\tv164 = v163 << 4;\n\tv165 = v43 + v164;\n\tv166 = v165 + 0x130;\nL_0050:\n\tSystem.IDisposable::Dispose(this.<>7__wrap1);\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private void _003C_003Em__Finally1()
			{
				_003C_003E1__state = -1;
				if (_003C_003E7__wrap1 != null)
				{
					_003C_003E7__wrap1.Dispose();
				}
			}

			[Token(Token = "0x600013A")]
			[Address(RVA = "0x1574D5C", Offset = "0x1574D5C", Length = "0xC0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1ED7A80]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202913B]) = v38;\nL_0015:\n\tthis.<>1__state = 0xFFFFFFFD;\n\tv41 = this.<>7__wrap2 == 0;\n\tif (v41) goto L_0043;\n\tgoto L_0050;\n\tv52 = *([v43 @ X8_v4+B0]);\n\tv53 = 0;\n\tv54 = v52 + 8;\n\tv56 = *([v151 @ X11_v5-8]);\n\tv157 = v56 == v46;\n\tif (v157) goto L_0044;\n\tv89 = v152 + 1;\n\tv162 = v89 < v45;\n\tv83 = ~v162;\n\tv86 = v151 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_FFFFFFFF;\n\tv90 = v39;\n\tv91 = 0;\n\tv92 = 0x8909C4(v90, v46, v91, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0050;\nL_0043:\n\treturn;\nL_0044:\n\tv163 = *([v151 @ X11_v5]);\n\tv164 = v163 << 4;\n\tv165 = v43 + v164;\n\tv166 = v165 + 0x130;\nL_0050:\n\tSystem.IDisposable::Dispose(this.<>7__wrap2);\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private void _003C_003Em__Finally2()
			{
				_003C_003E1__state = -3;
				if (_003C_003E7__wrap2 != null)
				{
					_003C_003E7__wrap2.Dispose();
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x600013C")]
			[Address(RVA = "0x1575308", Offset = "0x1575308", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1ECDE78]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([202913C]) = v34;\nL_0014:\n\tv38 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw new TypeLoadException();
			}

			[DebuggerHidden]
			[Token(Token = "0x600013E")]
			[Address(RVA = "0x1575374", Offset = "0x1575374", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EE73A0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202913D]) = v38;\nL_0014:\n\tv40 = this.<>1__state + 2;\n\tv42 = v40 == 0;\n\tv45 = ~v42;\n\tif (v45) goto L_002E;\n\tv48 = System.Environment::get_CurrentManagedThreadId();\n\tv50 = this.<>l__initialThreadId != v48;\n\tif (v50) goto L_002E;\n\tthis.<>1__state = 0;\n\tgoto L_0041;\nL_002E:\n\tv76 = new com.adjust.sdk.JSONNode+<get_DeepChilds>d__19();\n\tSystem.Object::.ctor(v76);\n\tv76.<>1__state = 0;\n\tv81 = System.Environment::get_CurrentManagedThreadId();\n\tv76.<>l__initialThreadId = v81;\n\tv76.<>4__this = this.<>4__this;\nL_0041:\n\treturn v95;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
				_003Cget_DeepChilds_003Ed__19 _003Cget_DeepChilds_003Ed__20 = null;
				_003Cget_DeepChilds_003Ed__20._003C_003E1__state = 0;
				int currentManagedThreadId2 = Environment.CurrentManagedThreadId;
				_003Cget_DeepChilds_003Ed__20._003C_003El__initialThreadId = currentManagedThreadId2;
				_003Cget_DeepChilds_003Ed__20._003C_003E4__this = _003C_003E4__this;
				return _003Cget_DeepChilds_003Ed__20;
			}

			[DebuggerHidden]
			[Token(Token = "0x600013F")]
			[Address(RVA = "0x1575424", Offset = "0x1575424", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = com.adjust.sdk.JSONNode+<get_DeepChilds>d__19::System.Collections.Generic.IEnumerable<com.adjust.sdk.JSONNode>.GetEnumerator(this);\n\treturn returnVal1;\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<JSONNode>)this).GetEnumerator();
			}
		}

		[Token(Token = "0x17000001")]
		public virtual JSONNode Item
		{
			[Token(Token = "0x6000002")]
			[Address(RVA = "0x1573B48", Offset = "0x1573B48", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000003")]
			[Address(RVA = "0x1573B50", Offset = "0x1573B50", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			set
			{
			}
		}

		[Token(Token = "0x17000002")]
		public virtual JSONNode Item
		{
			[Token(Token = "0x6000004")]
			[Address(RVA = "0x1573B54", Offset = "0x1573B54", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000005")]
			[Address(RVA = "0x1573B5C", Offset = "0x1573B5C", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			set
			{
			}
		}

		[Token(Token = "0x17000003")]
		public virtual string Value
		{
			[Token(Token = "0x6000006")]
			[Address(RVA = "0x1573B60", Offset = "0x1573B60", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EAAAA8]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202911E]) = v35;\nL_0018:\n\treturn \"\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return "";
			}
			[Token(Token = "0x6000007")]
			[Address(RVA = "0x1573BA8", Offset = "0x1573BA8", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			set
			{
			}
		}

		[Token(Token = "0x17000004")]
		public virtual int Count
		{
			[Token(Token = "0x6000008")]
			[Address(RVA = "0x1573BAC", Offset = "0x1573BAC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x17000005")]
		public virtual IEnumerable<JSONNode> Childs
		{
			[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x72E030", Offset = "0x72E030")]
			[Token(Token = "0x600000D")]
			[Address(RVA = "0x1573C34", Offset = "0x1573C34", Length = "0x70")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EF01A8]);\n\tv15 = *([v14 @ X8_v7]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029120]) = v35;\nL_0014:\n\tv39 = new com.adjust.sdk.JSONNode+<get_Childs>d__17();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0xFFFFFFFE;\n\tv44 = System.Environment::get_CurrentManagedThreadId();\n\tv39.<>l__initialThreadId = v44;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				_003Cget_Childs_003Ed__17 _003Cget_Childs_003Ed__18 = new _003Cget_Childs_003Ed__17(-2);
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003Cget_Childs_003Ed__18._003C_003El__initialThreadId = currentManagedThreadId;
				return _003Cget_Childs_003Ed__18;
			}
		}

		[Token(Token = "0x17000006")]
		public IEnumerable<JSONNode> DeepChilds
		{
			[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x72E094", Offset = "0x72E094")]
			[Token(Token = "0x600000E")]
			[Address(RVA = "0x1573CDC", Offset = "0x1573CDC", Length = "0x84")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EF1868]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029121]) = v38;\nL_0016:\n\tv42 = new com.adjust.sdk.JSONNode+<get_DeepChilds>d__19();\n\tSystem.Object::.ctor(v42);\n\tv42.<>1__state = 0xFFFFFFFE;\n\tv47 = System.Environment::get_CurrentManagedThreadId();\n\tv42.<>l__initialThreadId = v47;\n\tv42.<>4__this = this;\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				_003Cget_DeepChilds_003Ed__19 _003Cget_DeepChilds_003Ed__20 = new _003Cget_DeepChilds_003Ed__19(-2);
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003Cget_DeepChilds_003Ed__20._003C_003El__initialThreadId = currentManagedThreadId;
				_003Cget_DeepChilds_003Ed__20._003C_003E4__this = this;
				return _003Cget_DeepChilds_003Ed__20;
			}
		}

		[Token(Token = "0x17000007")]
		public unsafe virtual int AsInt
		{
			[Token(Token = "0x6000011")]
			[Address(RVA = "0x1573E28", Offset = "0x1573E28", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = &v5 @ stack_-10_v2;\n\t*([v4 @ X29_v1-4]) = 0;\n\tv10 = com.adjust.sdk.JSONNode::get_Value(this);\n\tv25 = &v5 @ stack_-10_v2 - 4;\n\tv27 = System.Int32::TryParse(v10, v25);\n\tv33 = v27 == 0;\n\tv36 = ~v33;\n\tv37 = ~v36;\n\tif (v37) goto L_FFFFFFFF;\n\tgoto L_001C;\nL_001C:\n\treturn returnVal1;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				object obj2 = default(object);
				object obj = obj2;
				_ = 0;
				string value = Value;
				if (int.TryParse(value, out *(int*)((long)(IntPtr)obj2 - 4L)))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ X29_v1-4]");
					return 0;
				}
				return 0;
			}
			[Token(Token = "0x6000012")]
			[Address(RVA = "0x1573E68", Offset = "0x1573E68", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = &v7 @ stack_-10_v2;\n\t*([v6 @ X29_v1-4]) = value;\n\tv11 = &v7 @ stack_-10_v2 - 4;\n\tv13 = 0xDC3560(v11, 0, methodInfo, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27);\n\tv33 = com.adjust.sdk.JSONNode::set_Value(this, v13);\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_001c: Expected O, but got I
				object obj2 = default(object);
				object obj = obj2;
				object obj3 = (long)(IntPtr)obj2 - 4L;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
				string value2 = default(string);
				Value = value2;
			}
		}

		[Token(Token = "0x17000008")]
		public unsafe virtual float AsFloat
		{
			[Token(Token = "0x6000013")]
			[Address(RVA = "0x1573EA8", Offset = "0x1573EA8", Length = "0x44")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = &v5 @ stack_-10_v2;\n\t*([v4 @ X29_v1-4]) = 0;\n\tv10 = com.adjust.sdk.JSONNode::get_Value(this);\n\tv25 = &v5 @ stack_-10_v2 - 4;\n\tv27 = System.Single::TryParse(v10, v25);\n\treturnVal1 = *([v4 @ X29_v1-4]);\n\tv33 = v27 == 0;\n\tv37 = ~v33;\n\tv38 = ~v37;\n\tif (v38) goto L_FFFFFFFF;\n\tgoto L_001D;\nL_001D:\n\treturn returnVal1;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0048: Expected F4, but got I
				object obj2 = default(object);
				object obj = obj2;
				_ = 0;
				string value = Value;
				bool flag = float.TryParse(value, out *(float*)((long)(IntPtr)obj2 - 4L));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ X29_v1-4]");
				float result = 0f;
				if (!flag)
				{
					result = 0f;
				}
				return result;
			}
			[Token(Token = "0x6000014")]
			[Address(RVA = "0x1573EEC", Offset = "0x1573EEC", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = &v7 @ stack_-10_v2;\n\tv10 = &v7 @ stack_-10_v2 - 4;\n\t*([v6 @ X29_v1-4]) = value;\n\tv13 = 0xBCCEC8(v10, 0, v14, v15, v16, v17, v18, v19, value, v20, v21, v22, v23, v24, v25, v26);\n\tv32 = com.adjust.sdk.JSONNode::set_Value(this, v13);\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0017: Expected O, but got I
				object obj2 = default(object);
				object obj = obj2;
				object obj3 = (long)(IntPtr)obj2 - 4L;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BCCEC8 (inside System.Single::IsNaN +0x2B0)");
				string value2 = default(string);
				Value = value2;
			}
		}

		[Token(Token = "0x17000009")]
		public virtual double AsDouble
		{
			[Token(Token = "0x6000015")]
			[Address(RVA = "0x1573F2C", Offset = "0x1573F2C", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EF4270]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029124]) = v38;\nL_0018:\n\tv44 = com.adjust.sdk.JSONNode::get_Value(this);\n\tgoto L_002A;\n\tv52 = *([v48 @ X8_v6+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_002A;\n\tv64 = v48;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v64, v43, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002A:\n\tv63 = System.Double::TryParse(v44, &v60 @ stack_-28_v2 (System.Double));\n\tv72 = v63 == 0;\n\tv76 = ~v72;\n\tv77 = ~v76;\n\tif (v77) goto L_FFFFFFFF;\n\tgoto L_003E;\nL_003E:\n\treturn returnVal1;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				string value = Value;
				if (double.TryParse(value, out var result))
				{
					return result;
				}
				return 0.0;
			}
			[Token(Token = "0x6000016")]
			[Address(RVA = "0x1573FD0", Offset = "0x1573FD0", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = 0xA662F8(&value @ V0 (System.Double), 0, v15, v16, v17, v18, v19, v20, value, v21, v22, v23, v24, v25, v26, v27);\n\tv33 = com.adjust.sdk.JSONNode::set_Value(this, v14);\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @A662F8 (inside System.Double::IsNaN +0x414)");
				string value2 = default(string);
				Value = value2;
			}
		}

		[Token(Token = "0x1700000A")]
		public virtual bool AsBool
		{
			[Token(Token = "0x6000017")]
			[Address(RVA = "0x1574010", Offset = "0x1574010", Length = "0xC8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EE59A0]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029125]) = v38;\nL_0018:\n\tv44 = com.adjust.sdk.JSONNode::get_Value(this);\n\tgoto L_002A;\n\tv52 = *([v48 @ X8_v6+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_002A;\n\tv64 = v48;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v64, v43, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002A:\n\tv63 = System.Boolean::TryParse(v44, &v60 @ stack_-24_v2 (System.Boolean));\n\tv66 = v63 == 0;\n\tif (v66) goto L_003F;\n\tv72 = v60 == 0;\n\tv77 = ~v72;\n\tgoto L_0047;\nL_003F:\n\tv83 = com.adjust.sdk.JSONNode::get_Value(this);\n\tv85 = System.String::IsNullOrEmpty(v83);\n\tv108 = v85 ^ 1;\nL_0047:\n\treturnVal1 = v108 & 1;\n\treturn returnVal1;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				string value = Value;
				int num;
				if (bool.TryParse(value, out var result))
				{
					bool flag = !result;
					bool flag2 = !flag;
					num = (flag2 ? 1 : 0);
				}
				else
				{
					string value2 = Value;
					bool flag3 = string.IsNullOrEmpty(value2);
					num = (flag3 ? 1 : 0) ^ 1;
				}
				return (byte)(num & 1) != 0;
			}
			[Token(Token = "0x6000018")]
			[Address(RVA = "0x15740D8", Offset = "0x15740D8", Length = "0x80")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1F082B8]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029126]) = v41;\nL_001B:\n\tv47 = this->klass;\n\tv50 = value == 0;\n\tv54 = ~v50;\n\tv55 = ~v54;\n\tif (v55) goto L_FFFFFFFF;\n\tgoto L_0029;\nL_0029:\n\tv61 = *([v60 @ X8_v5 (System.String)]);\n\tv62 = this->klass->vtable[10];\n\tv63 = this->klass->vtable[10];\n\t// 50 IndirectJump v62 @ X3_v1, this @ X0 (com.adjust.sdk.JSONNode), this @ X0 (com.adjust.sdk.JSONNode), v61 @ X1_v1 (Il2CppClass<System.String>), v63 @ X2_v1, v62 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_000a: Expected I, but got O
				//IL_0061: Expected I, but got O
				//IL_0071: Expected O, but got I
				//IL_0081: Expected O, but got I
				IntPtr intPtr = (IntPtr)this;
				string text = ((!value) ? "false" : "true");
				IntPtr intPtr2 = (IntPtr)text;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X10_v1 (Il2CppClass<com.adjust.sdk.JSONNode>)+1D0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X10_v1 (Il2CppClass<com.adjust.sdk.JSONNode>)+1D8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v62 @ X3_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x1700000B")]
		public virtual JSONArray AsArray
		{
			[Token(Token = "0x6000019")]
			[Address(RVA = "0x1574158", Offset = "0x1574158", Length = "0x80")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F08B58]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029127]) = v38;\nL_0013:\n\tv39 = this == 0;\n\tif (v39) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_003F;\n\tv92 = v92_asT == 0;\n\tif (v92) goto L_FFFFFFFF;\n\tgoto L_003F;\nL_003F:\n\treturn returnVal1;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if ((object)this == null)
				{
					return null;
				}
				JSONArray jSONArray = this as JSONArray;
				if ((object)jSONArray != null)
				{
					return (JSONArray)this;
				}
				return null;
			}
		}

		[Token(Token = "0x1700000C")]
		public virtual JSONClass AsObject
		{
			[Token(Token = "0x600001A")]
			[Address(RVA = "0x15741D8", Offset = "0x15741D8", Length = "0x80")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F0A0B8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029128]) = v38;\nL_0013:\n\tv39 = this == 0;\n\tif (v39) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_003F;\n\tv92 = v92_asT == 0;\n\tif (v92) goto L_FFFFFFFF;\n\tgoto L_003F;\nL_003F:\n\treturn returnVal1;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if ((object)this == null)
				{
					return null;
				}
				JSONClass jSONClass = this as JSONClass;
				if ((object)jSONClass != null)
				{
					return (JSONClass)this;
				}
				return null;
			}
		}

		[Token(Token = "0x6000001")]
		[Address(RVA = "0x1573B44", Offset = "0x1573B44", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void Add(string aKey, JSONNode aItem)
		{
		}

		[Token(Token = "0x6000009")]
		[Address(RVA = "0x1573BB4", Offset = "0x1573BB4", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EA7B30]);\n\tv23 = *([v22 @ X8_v5]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, aItem, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202911F]) = v41;\nL_0016:\n\tv43 = this->klass;\n\tv47 = this->klass->vtable[4];\n\tv48 = this->klass->vtable[4];\n\t// 35 IndirectJump v47 @ X4_v1, this @ X0 (com.adjust.sdk.JSONNode), this @ X0 (com.adjust.sdk.JSONNode), \"\", aItem @ X1 (com.adjust.sdk.JSONNode), v48 @ X3_v1, v47 @ X4_v1, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void Add(JSONNode aItem)
		{
			//IL_000a: Expected I, but got O
			//IL_001a: Expected O, but got I
			//IL_002a: Expected O, but got I
			IntPtr intPtr = (IntPtr)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ X8_v3 (Il2CppClass<com.adjust.sdk.JSONNode>)+170]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ X8_v3 (Il2CppClass<com.adjust.sdk.JSONNode>)+178]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v47 @ X4_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x600000A")]
		[Address(RVA = "0x1573C1C", Offset = "0x1573C1C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual JSONNode Remove(string aKey)
		{
			return null;
		}

		[Token(Token = "0x600000B")]
		[Address(RVA = "0x1573C24", Offset = "0x1573C24", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual JSONNode Remove(int aIndex)
		{
			return null;
		}

		[Token(Token = "0x600000C")]
		[Address(RVA = "0x1573C2C", Offset = "0x1573C2C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn aNode;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual JSONNode Remove(JSONNode aNode)
		{
			return aNode;
		}

		[Token(Token = "0x600000F")]
		[Address(RVA = "0x1573D98", Offset = "0x1573D98", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EF5700]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029122]) = v35;\nL_0018:\n\treturn \"JSONNode\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			return "JSONNode";
		}

		[Token(Token = "0x6000010")]
		[Address(RVA = "0x1573DE0", Offset = "0x1573DE0", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EFB9E0]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, aPrefix, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029123]) = v35;\nL_0018:\n\treturn \"JSONNode\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual string ToString(string aPrefix)
		{
			return "JSONNode";
		}

		[Token(Token = "0x600001B")]
		[Address(RVA = "0x1574258", Offset = "0x1574258", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EC97C0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029129]) = v38;\nL_0016:\n\tv42 = new com.adjust.sdk.JSONData();\n\tSystem.Object::.ctor(v42);\n\tv42.m_Data = s;\n\treturn v42;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static implicit operator JSONNode(string s)
		{
			JSONData jSONData = null;
			jSONData.Value = s;
			return jSONData;
		}

		[Token(Token = "0x600001C")]
		[Address(RVA = "0x15742BC", Offset = "0x15742BC", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = com.adjust.sdk.JSONNode::op_Equality(d, 0);\n\tv14 = v11 == 0;\n\tif (v14) goto L_0013;\n\treturn 0;\nL_0013:\n\tv24 = d->klass;\n\tv21 = d->klass->vtable[9];\n\tv34 = d->klass->vtable[9];\n\t// 27 IndirectJump v21 @ X2_v1, d @ X0 (com.adjust.sdk.JSONNode), d @ X0 (com.adjust.sdk.JSONNode), v34 @ X1_v2, v21 @ X2_v1, v37 @ X3, v38 @ X4, v39 @ X5, v40 @ X6, v41 @ X7, v42 @ V0, v43 @ V1, v44 @ V2, v45 @ V3, v46 @ V4, v47 @ V5, v48 @ V6, v49 @ V7\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static implicit operator string(JSONNode d)
		{
			//IL_0035: Expected I, but got O
			//IL_0045: Expected O, but got I
			//IL_0055: Expected O, but got I
			if (d == null)
			{
				return null;
			}
			IntPtr intPtr = (IntPtr)d;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X8_v1 (Il2CppClass<com.adjust.sdk.JSONNode>)+1C0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X8_v1 (Il2CppClass<com.adjust.sdk.JSONNode>)+1C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v21 @ X2_v1 (should have been resolved before IL gen)");
			return null;
		}

		[Token(Token = "0x600001D")]
		[Address(RVA = "0x156D0B0", Offset = "0x156D0B0", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EBF860]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, b, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202912A]) = v41;\nL_0015:\n\tv42 = b == 0;\n\tif (v42) goto L_0028;\nL_0019:\n\tv98 = a - b;\n\tv100 = v98 == 0;\nL_0027:\n\treturn returnVal1;\nL_0028:\n\tv93 = a == 0;\n\tif (v93) goto L_0019;\n\tgoto L_FFFFFFFF;\n\tv49 = v49_asT == 0;\n\tif (v49) goto L_0019;\n\tgoto L_0027;\n\treturn X0;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool operator ==(JSONNode a, object b)
		{
			//IL_0014: Expected O, but got I
			if (b == null && (object)a != null)
			{
				JSONLazyCreator jSONLazyCreator = a as JSONLazyCreator;
				if ((object)jSONLazyCreator != null)
				{
					return true;
				}
			}
			object obj = (long)(IntPtr)a - (long)(IntPtr)b;
			return obj == null;
		}

		[Token(Token = "0x600001E")]
		[Address(RVA = "0x156DCA4", Offset = "0x156DCA4", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = com.adjust.sdk.JSONNode::op_Equality(a, b);\n\tv10 = ~v6;\n\treturn v10;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool operator !=(JSONNode a, object b)
		{
			bool flag = a == b;
			return !flag;
		}

		[Token(Token = "0x600001F")]
		[Address(RVA = "0x157430C", Offset = "0x157430C", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = this - obj;\n\tv6 = v4 == 0;\n\treturn v6;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override bool Equals(object obj)
		{
			//IL_000c: Expected O, but got I
			object obj2 = (long)(IntPtr)this - (long)(IntPtr)obj;
			return obj2 == null;
		}

		[Token(Token = "0x6000020")]
		[Address(RVA = "0x15735AC", Offset = "0x15735AC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = System.Object::GetHashCode(this);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		[Token(Token = "0x6000021")]
		[Address(RVA = "0x1571FD8", Offset = "0x1571FD8", Length = "0x180")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv34 = *([1EC7480]);\n\tv35 = *([v34 @ X8_v15]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([202912B]) = v54;\nL_002C:\n\tv71 = aText.m_stringLength < 1;\n\tif (v71) goto L_009C;\n\tv88 = 0x1835000 + 0x920;\nL_0040:\n\tv163 = System.String::get_Chars(aText, v159);\n\tv211 = v163 & 0xFFFF;\n\tv123 = v211 - 8;\n\tv212 = v123 < 5;\n\tv201 = ~v212;\n\tv198 = v123 - 5;\n\tv192 = v198 == 0;\n\tv213 = ~v192;\n\tv176 = v201 & v213;\n\tif (v176) goto L_0059;\n\tv208 = *([v88 @ X24_v4 (System.Int32)+v123 @ X9_v5 (System.Int32)*4]) + v88;\n\t// 82 IndirectJump v208 @ X8_v12, v163 @ X0_v8 (System.Char), v163 @ X0_v8 (System.Char), v159 @ X20_v5 (System.Int32), 0, v39 @ X3, v40 @ X4, v41 @ X5, v42 @ X6, v43 @ X7, v44 @ V0, v45 @ V1, v46 @ V2, v47 @ V3, v48 @ V4, v49 @ V5, v50 @ V6, v51 @ V7\n\tX1 = *([X25]);\n\tgoto L_007E;\nL_0059:\n\tv219 = v211 == 0x22;\n\tif (v219) goto L_FFFFFFFF;\n\tv233 = v211 != 0x5C;\n\tif (v233) goto L_006E;\n\tgoto L_007E;\nL_006E:\n\taText = 0xF91044(&v163 @ X0_v8 (System.Char), 0, 0, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_007E;\n\tX1 = *([X26]);\n\tgoto L_007E;\n\tX1 = *([X27]);\n\tgoto L_007E;\n\tX1 = *([X28]);\n\tgoto L_007E;\n\tX1 = *([X22]);\n\tgoto L_007E;\nL_007E:\n\taText = System.String::Concat(v147, v92);\n\tv159 = v159 + 1;\n\tv103 = v159 < aText.m_stringLength;\n\tif (v103) goto L_0040;\nL_009C:\n\treturn v104;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 115 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static string Escape(string aText)
		{
			//IL_006b: Expected O, but got I
			bool flag = aText.Length < 1;
			string result = "";
			if (!flag)
			{
				int num = 25382912 + 2336;
				string text = "";
				int num2 = 0;
				bool flag6;
				do
				{
					char c = aText.get_Chars(num2);
					int num3 = c & 0xFFFF;
					int num4 = num3 - 8;
					bool flag2 = num4 < 5;
					bool flag3 = !flag2;
					int num5 = num4 - 5;
					bool flag4 = num5 == 0;
					bool flag5 = !flag4;
					if (!(flag3 && flag5))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ X24_v4 (System.Int32)+v123 @ X9_v5 (System.Int32)*4]");
						object obj = 0L + (long)num;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v208 @ X8_v12 (should have been resolved before IL gen)");
					}
					string text2;
					switch (num3)
					{
					case 92:
						text2 = "\\\\";
						break;
					default:
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @F91044 (inside System.Char::GetLatin1UnicodeCategory +0x228)");
						text2 = aText;
						break;
					case 34:
						text2 = "\\\"";
						break;
					}
					string text3 = text + text2;
					num2++;
					flag6 = num2 < aText.Length;
					result = aText;
					text = aText;
				}
				while (flag6);
			}
			return result;
		}

		[Token(Token = "0x6000022")]
		[Address(RVA = "0x156FDC8", Offset = "0x156FDC8", Length = "0x694")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv34 = *([1ED4C90]);\n\tv35 = *([v34 @ X8_v75]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([202912C]) = v54;\nL_0020:\n\tv60 = new System.Collections.Generic.Stack`1<com.adjust.sdk.JSONNode>();\n\tSystem.Collections.Generic.Stack`1<com.adjust.sdk.JSONNode>::.ctor(v60);\n\tv77 = aJSON.m_stringLength < 1;\n\tif (v77) goto L_FFFFFFFF;\nL_0043:\n\tv236 = System.String::get_Chars(aJSON, v720);\n\tv436 = v236 & 0xFFFF;\n\tv437 = v436 < 0x2C;\n\tv438 = ~v437;\n\tv439 = v436 - 0x2C;\n\tv441 = v439 == 0;\n\tv446 = ~v441;\n\tv447 = v438 & v446;\n\tif (v447) goto L_0081;\n\tv540 = v436 < 0x20;\n\tv541 = ~v540;\n\tv542 = v436 - 0x20;\n\tv544 = v542 == 0;\n\tv549 = ~v544;\n\tv550 = v541 & v549;\n\tif (v550) goto L_00BC;\n\tv564 = v236 & 0xFFFF;\n\tv576 = v564 > 0xC;\n\tif (v576) goto L_017B;\n\tv612 = v564 == 9;\n\tif (v612) goto L_018C;\n\tv672 = v564 == 0xA;\n\tif (v672) goto L_02C1;\n\tgoto L_01F7;\nL_0081:\n\tv551 = v436 < 0x5D;\n\tv552 = ~v551;\n\tv553 = v436 - 0x5D;\n\tv555 = v553 == 0;\n\tv560 = ~v555;\n\tv561 = v552 & v560;\n\tif (v561) goto L_010F;\n\tv249 = v236 & 0xFFFF;\n\tv597 = v249 > 0x5B;\n\tif (v597) goto L_0196;\n\tv641 = v249 == 0x3A;\n\tif (v641) goto L_0204;\n\tv144 = v249 != 0x5B;\n\tif (v144) goto L_01F7;\n\tv824 = v324 & 1;\n\tv825 = v824 == 0;\n\tv810 = ~v825;\n\tif (v810) goto L_020A;\n\tv60 = *([v327 @ X25_v10 (Il2CppClass<com.adjust.sdk.JSONArray>)]);\n\tv231 = new *([v327 @ X25_v10 (Il2CppClass<com.adjust.sdk.JSONArray>)])();\n\tcom.adjust.sdk.JSONArray::.ctor(v231);\n\tv986 = *([v327 @ X25_v10 (Il2CppClass<com.adjust.sdk.JSONArray>)]) == 0;\n\tv240 = ~v986;\n\tif (v240) goto L_0136;\n\tgoto L_02EE;\nL_00BC:\n\tv577 = v236 & 0xFFFF;\n\tv582 = v577 == 0x22;\n\tif (v582) goto L_0202;\n\tv635 = v577 != 0x2C;\n\tif (v635) goto L_01F7;\n\tv796 = v324 & 1;\n\tv797 = v796 == 0;\n\tv798 = ~v797;\n\tif (v798) goto L_020A;\n\tv820 = System.String::op_Inequality(v718, *([v328 @ X26_v10 (System.String)]));\n\tv834 = v820 == 0;\n\tif (v834) goto L_02BD;\n\tv869 = v719 == 0;\n\tif (v869) goto L_00FF;\n\tv929 = *([v719 @ X21_v10 (com.adjust.sdk.JSONNode)]);\n\tv930 = *([v327 @ X25_v10 (Il2CppClass<com.adjust.sdk.JSONArray>)]);\n\tv931 = *([v929 @ X9_v31 (Il2CppClass<com.adjust.sdk.JSONNode>)+128]) < *([v930 @ X8_v70+128]);\n\tv932 = ~v931;\n\tv885 = ~v932;\n\tif (v885) goto L_00FF;\n\tv873 = *([v930 @ X8_v70+128]) << 3;\n\tv1023 = *([v929 @ X9_v31 (Il2CppClass<com.adjust.sdk.JSONNode>)+C8]) + v873;\n\tv895 = *([v1023 @ X9_v33-8]) == v930;\n\tif (v895) goto L_02B6;\nL_00FF:\n\tv907 = System.String::op_Inequality(v325, *([v328 @ X26_v10 (System.String)]));\n\tv910 = v907 == 0;\n\tif (v910) goto L_02BD;\n\tv232 = com.adjust.sdk.JSONNode::op_Implicit(v718);\n\tv913 = *([v719 @ X21_v10 (com.adjust.sdk.JSONNode)]);\n\tv1091 = *([v913 @ X8_v69 (Il2CppClass<com.adjust.sdk.JSONNode>)+178]);\n\tv60 = com.adjust.sdk.JSONNode::Add(v719, v325, v232);\n\tgoto L_02BD;\nL_010F:\n\tv598 = v236 & 0xFFFF;\n\tv603 = v598 == 0x7D;\n\tif (v603) goto L_01A7;\n\tv146 = v598 != 0x7B;\n\tif (v146) goto L_01F7;\n\tv807 = v324 & 1;\n\tv808 = v807 == 0;\n\tv809 = ~v808;\n\tif (v809) goto L_020A;\n\tv233 = new com.adjust.sdk.JSONClass();\n\tcom.adjust.sdk.JSONClass::.ctor(v233);\nL_0136:\n\tSystem.Collections.Generic.Stack`1<com.adjust.sdk.JSONNode>::Push(v60, v125);\n\tv234 = com.adjust.sdk.JSONNode::op_Equality(v719, 0);\n\tv1086 = v234 == 0;\n\tv1087 = ~v1086;\n\tif (v1087) goto L_0273;\n\tv1146 = System.String::Trim(v325);\n\tv1139 = v719 == 0;\n\tif (v1139) goto L_0166;\n\tv1164 = *([v719 @ X21_v10 (com.adjust.sdk.JSONNode)]);\n\tv1165 = *([v327 @ X25_v10 (Il2CppClass<com.adjust.sdk.JSONArray>)]);\n\tv1166 = *([v1164 @ X9_v21 (Il2CppClass<com.adjust.sdk.JSONNode>)+128]) < *([v1165 @ X8_v47+128]);\n\tv1167 = ~v1166;\n\tv1124 = ~v1167;\n\tif (v1124) goto L_0166;\n\tv1116 = *([v1165 @ X8_v47+128]) << 3;\n\tv1181 = *([v1164 @ X9_v21 (Il2CppClass<com.adjust.sdk.JSONNode>)+C8]) + v1116;\n\tv1129 = *([v1181 @ X9_v23-8]) == v1165;\n\tif (v1129) goto L_026C;\nL_0166:\n\tv1137 = System.String::op_Inequality(v1146, *([v328 @ X26_v10 (System.String)]));\n\tv1140 = v1137 == 0;\n\tif (v1140) goto L_0273;\n\tv235 = System.Collections.Generic.Stack`1<com.adjust.sdk.JSONNode>::Peek(v60);\n\tv1142 = *([v719 @ X21_v10 (com.adjust.sdk.JSONNode)]);\n\tv1091 = *([v1142 @ X8_v46 (Il2CppClass<com.adjust.sdk.JSONNode>)+178]);\n\tv60 = com.adjust.sdk.JSONNode::Add(v719, v1146, v235);\n\tgoto L_0273;\nL_017B:\n\tv621 = v564 == 0xD;\n\tif (v621) goto L_02C1;\n\tv678 = v564 != 0x20;\n\tif (v678) goto L_01F7;\nL_018C:\n\tv695 = v324 & 1;\n\tv696 = v695 == 0;\n\tv697 = ~v696;\n\tif (v697) goto L_020A;\n\tgoto L_02C1;\nL_0196:\n\tv650 = v249 == 0x5C;\n\tif (v650) goto L_0218;\n\tv656 = v249 != 0x5D;\n\tif (v656) goto L_01F7;\nL_01A7:\n\tv665 = v324 & 1;\n\tv666 = v665 == 0;\n\tv667 = ~v666;\n\tif (v667) goto L_020A;\n\tv303 = v60._size == 0;\n\tif (v303) goto L_02F2;\n\tv867 = System.Collections.Generic.Stack`1<com.adjust.sdk.JSONNode>::Pop(v60);\n\tv237 = System.String::op_Inequality(v718, *([v328 @ X26_v10 (System.String)]));\n\tv1021 = v237 == 0;\n\tif (v1021) goto L_027E;\n\tv1090 = System.String::Trim(v325);\n\tv1073 = v719 == 0;\n\tif (v1073) goto L_01E4;\n\tv1147 = *([v719 @ X21_v10 (com.adjust.sdk.JSONNode)]);\n\tv1148 = *([v327 @ X25_v10 (Il2CppClass<com.adjust.sdk.JSONArray>)]);\n\tv1149 = *([v1147 @ X9_v13 (Il2CppClass<com.adjust.sdk.JSONNode>)+128]) < *([v1148 @ X8_v39+128]);\n\tv1150 = ~v1149;\n\tv1051 = ~v1150;\n\tif (v1051) goto L_01E4;\n\tv1042 = *([v1148 @ X8_v39+128]) << 3;\n\tv1161 = *([v1147 @ X9_v13 (Il2CppClass<com.adjust.sdk.JSONNode>)+C8]) + v1042;\n\tv1061 = *([v1161 @ X9_v15-8]) == v1148;\n\tif (v1061) goto L_0276;\nL_01E4:\n\tv1071 = System.String::op_Inequality(v1090, *([v328 @ X26_v10 (System.String)]));\n\tv1074 = v1071 == 0;\n\tif (v1074) goto L_027E;\n\tv238 = com.adjust.sdk.JSONNode::op_Implicit(v718);\n\tv1077 = *([v719 @ X21_v10 (com.adjust.sdk.JSONNode)]);\n\tv1091 = *([v1077 @ X8_v38 (Il2CppClass<com.adjust.sdk.JSONNode>)+178]);\n\tv60 = com.adjust.sdk.JSONNode::Add(v719, v1090, v238);\n\tgoto L_027E;\nL_01F7:\n\tv802 = System.String::get_Chars(aJSON, v720);\n\tv823 = 0xF91044(&v802 @ X0_v30 (System.Char), 0, 0, v1091, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv782 = System.String::Concat(v718, v823);\n\tgoto L_02C1;\nL_0202:\n\tv324 = v324 ^ 1;\n\tgoto L_02C1;\nL_0204:\n\tv804 = v324 & 1;\n\tv787 = v804 == 0;\n\tif (v787) goto L_FFFFFFFF;\nL_020A:\n\tv814 = System.String::get_Chars(aJSON, v720);\n\tv832 = 0xF91044(&v814 @ X0_v24 (System.Char), 0, 0, v1091, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv783 = System.String::Concat(v718, v832);\n\tgoto L_02C1;\nL_0218:\n\tv486 = v720 + 1;\n\tv806 = v324 & 1;\n\tv525 = v806 == 0;\n\tif (v525) goto L_FFFFFFFF;\n\tv522 = System.String::get_Chars(aJSON, v486);\n\tv837 = v522 & 0xFFFF;\n\tv838 = v837 < 0x66;\n\tv839 = ~v838;\n\tv840 = v837 - 0x66;\n\tv842 = v840 == 0;\n\tv847 = ~v842;\n\tv848 = v839 & v847;\n\tif (v848) goto L_024D;\n\tv919 = v837 == 0x62;\n\tif (v919) goto L_FFFFFFFF;\n\tv996 = v837 != 0x66;\n\tif (v996) goto L_0264;\n\tgoto L_FFFFFFFF;\n\tgoto L_02C1;\n\tgoto L_FFFFFFFF;\nL_024D:\n\tv924 = v837 - 0x6E;\n\tv925 = v924 < 7;\n\tv516 = ~v925;\n\tv513 = v924 - 7;\n\tv507 = v513 == 0;\n\tv926 = ~v507;\n\tv492 = v516 & v926;\n\tif (v492) goto L_0264;\n\tv463 = 0x1835000 + 0x900;\n\tv530 = *([v463 @ X9_v27 (System.Int32)+v924 @ X8_v57 (System.Int32)*4]) + v463;\n\t// 606 IndirectJump v530 @ X8_v59, v522 @ X0_v76 (System.Char), v522 @ X0_v76 (System.Char), v486 @ X25_v11 (System.Int32), 0, v1091 @ X3_v12, v40 @ X4, v41 @ X5, v42 @ X6, v43 @ X7, v44 @ V0, v45 @ V1, v46 @ V2, v47 @ V3, v48 @ V4, v49 @ V5, v50 @ V6, v51 @ V7\n\tX8 = *([1EB41C8]);\n\tgoto L_FFFFFFFF;\nL_0264:\n\tv1013 = 0xF91044(&v522 @ X0_v76 (System.Char), 0, 0, v1091, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_0298;\n\tgoto L_FFFFFFFF;\nL_026C:\n\tv1187 = System.Collections.Generic.Stack`1<com.adjust.sdk.JSONNode>::Peek(v60);\n\tv60 = com.adjust.sdk.JSONNode::Add(v719, v1187);\nL_0273:\n\tv958 = *([v328 @ X26_v10 (System.String)]);\n\tgoto L_028D;\nL_0276:\n\tv1178 = com.adjust.sdk.JSONNode::op_Implicit(v718);\n\tv60 = com.adjust.sdk.JSONNode::Add(v719, v1178);\nL_027E:\n\tv958 = *([v328 @ X26_v10 (System.String)]);\n\tv961 = v60._size < 1;\n\tif (v961) goto L_FFFFFFFF;\nL_028D:\n\tv980 = System.Collections.Generic.Stack`1<com.adjust.sdk.JSON\n// ... truncated")]
		public static JSONNode Parse(string aJSON)
		{
			//IL_005f: Expected I, but got O
			//IL_0d53: Expected I, but got O
			//IL_0d77: Expected I, but got O
			//IL_0dc1: Expected O, but got I
			//IL_0dd2: Expected O, but got I
			//IL_0bab: Expected O, but got I
			//IL_0d31: Expected I, but got O
			//IL_023f: Expected O, but got I
			//IL_0814: Expected I, but got O
			//IL_081c: Expected O, but got I
			//IL_0d3e: Expected I, but got O
			//IL_0357: Expected I, but got O
			//IL_035f: Expected O, but got I
			//IL_08f5: Expected I, but got O
			//IL_0905: Expected O, but got I
			//IL_0889: Expected O, but got I
			//IL_0575: Expected I, but got O
			//IL_057d: Expected O, but got I
			//IL_0438: Expected I, but got O
			//IL_0448: Expected O, but got I
			//IL_03cc: Expected O, but got I
			//IL_0656: Expected I, but got O
			//IL_0666: Expected O, but got I
			//IL_05ea: Expected O, but got I
			Stack<JSONNode> stack = new Stack<JSONNode>();
			JSONNode jSONNode;
			if (aJSON.Length >= 1)
			{
				string text = "";
				jSONNode = null;
				int num = 0;
				int num2 = 0;
				string text2 = "";
				IntPtr intPtr = (IntPtr)typeof(JSONArray);
				string text3 = "";
				object obj3 = default(object);
				string text8 = default(string);
				string text12 = default(string);
				string text13 = default(string);
				string text15 = default(string);
				while (true)
				{
					char c = aJSON.get_Chars(num);
					int num3 = c & 0xFFFF;
					bool flag = num3 < 44;
					bool flag2 = !flag;
					int num4 = num3 - 44;
					bool flag3 = num4 == 0;
					bool flag4 = !flag3;
					string text4;
					if (!(flag2 && flag4))
					{
						bool flag5 = num3 < 32;
						bool flag6 = !flag5;
						int num5 = num3 - 32;
						bool flag7 = num5 == 0;
						bool flag8 = !flag7;
						if (!(flag6 && flag8))
						{
							int num6 = c & 0xFFFF;
							if (num6 <= 12)
							{
								if (num6 == 9)
								{
									goto IL_06c1;
								}
								bool flag9 = num6 == 10;
								text4 = text;
								if (!flag9)
								{
									goto IL_091b;
								}
							}
							else
							{
								bool flag10 = num6 == 13;
								text4 = text;
								if (!flag10)
								{
									if (num6 == 32)
									{
										goto IL_06c1;
									}
									goto IL_091b;
								}
							}
						}
						else
						{
							int num7 = c & 0xFFFF;
							if (num7 != 34)
							{
								if (num7 != 44)
								{
									goto IL_091b;
								}
								if ((num2 & 1) != 0)
								{
									goto IL_09a4;
								}
								if (text != text3)
								{
									if ((object)jSONNode != null)
									{
										IntPtr intPtr2 = (IntPtr)jSONNode;
										object obj = (long)intPtr;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v929 @ X9_v31 (Il2CppClass<com.adjust.sdk.JSONNode>)+128]");
										IntPtr intPtr3 = (IntPtr)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v930 @ X8_v70+128]");
										if ((long)intPtr3 >= 0L)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v930 @ X8_v70+128]");
											int num8 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v929 @ X9_v31 (Il2CppClass<com.adjust.sdk.JSONNode>)+C8]");
											object obj2 = 0L + (long)num8;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1023 @ X9_v33-8]");
											if ((IntPtr)0 == (IntPtr)obj)
											{
												JSONNode aItem = text;
												jSONNode.Add(aItem);
												goto IL_0d29;
											}
										}
									}
									if (text2 != text3)
									{
										JSONNode aItem2 = text;
										IntPtr intPtr4 = (IntPtr)jSONNode;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v913 @ X8_v69 (Il2CppClass<com.adjust.sdk.JSONNode>)+178]");
										obj3 = 0;
										jSONNode.Add(text2, aItem2);
									}
								}
								goto IL_0d29;
							}
							num2 ^= 1;
							text4 = text;
						}
						goto IL_0cf2;
					}
					bool flag11 = num3 < 93;
					bool flag12 = !flag11;
					int num9 = num3 - 93;
					bool flag13 = num9 == 0;
					bool flag14 = !flag13;
					int num11;
					string text6;
					JSONNode item;
					if (!(flag12 && flag14))
					{
						int num10 = c & 0xFFFF;
						if (num10 > 91)
						{
							if (num10 != 92)
							{
								if (num10 == 93)
								{
									goto IL_074a;
								}
								goto IL_091b;
							}
							num11 = num + 1;
							if ((num2 & 1) != 0)
							{
								char c2 = aJSON.get_Chars(num11);
								int num12 = c2 & 0xFFFF;
								bool flag15 = num12 < 102;
								bool flag16 = !flag15;
								int num13 = num12 - 102;
								bool flag17 = num13 == 0;
								bool flag18 = !flag17;
								if (!(flag16 && flag18))
								{
									string text5;
									if (num12 != 98)
									{
										if (num12 != 102)
										{
											goto IL_0bb5;
										}
										text5 = "\f";
									}
									else
									{
										text5 = "\b";
									}
									text6 = text5;
									goto IL_0d92;
								}
								int num14 = num12 - 110;
								bool flag19 = num14 < 7;
								bool flag20 = !flag19;
								int num15 = num14 - 7;
								bool flag21 = num15 == 0;
								bool flag22 = !flag21;
								if (!(flag20 && flag22))
								{
									int num16 = 25382912 + 2304;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v463 @ X9_v27 (System.Int32)+v924 @ X8_v57 (System.Int32)*4]");
									object obj4 = 0L + (long)num16;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v530 @ X8_v59 (should have been resolved before IL gen)");
								}
								goto IL_0bb5;
							}
							num2 = 0;
							goto IL_0dd7;
						}
						if (num10 != 58)
						{
							if (num10 != 91)
							{
								goto IL_091b;
							}
							if ((num2 & 1) == 0)
							{
								stack = (Stack<JSONNode>)(long)intPtr;
								JSONArray jSONArray = new JSONArray();
								bool flag23 = intPtr == (IntPtr)0;
								bool flag24 = !flag23;
								item = jSONArray;
								if (!flag24)
								{
									throw new NullReferenceException();
								}
								goto IL_04fb;
							}
						}
						else if ((num2 & 1) == 0)
						{
							text4 = text3;
							num2 = 0;
							text2 = text;
							goto IL_0cf2;
						}
					}
					else
					{
						int num17 = c & 0xFFFF;
						if (num17 == 125)
						{
							goto IL_074a;
						}
						if (num17 != 123)
						{
							goto IL_091b;
						}
						if ((num2 & 1) == 0)
						{
							JSONClass jSONClass = new JSONClass();
							item = jSONClass;
							goto IL_04fb;
						}
					}
					goto IL_09a4;
					IL_091b:
					char c3 = aJSON.get_Chars(num);
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @F91044 (inside System.Char::GetLatin1UnicodeCategory +0x228)");
					string text7 = text + text8;
					text4 = text7;
					goto IL_0cf2;
					IL_04fb:
					stack.Push(item);
					if (!(jSONNode == null))
					{
						string text9 = text2.Trim();
						if ((object)jSONNode != null)
						{
							IntPtr intPtr5 = (IntPtr)jSONNode;
							object obj5 = (long)intPtr;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1164 @ X9_v21 (Il2CppClass<com.adjust.sdk.JSONNode>)+128]");
							IntPtr intPtr6 = (IntPtr)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1165 @ X8_v47+128]");
							if ((long)intPtr6 >= 0L)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1165 @ X8_v47+128]");
								int num18 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1164 @ X9_v21 (Il2CppClass<com.adjust.sdk.JSONNode>)+C8]");
								object obj6 = 0L + (long)num18;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1181 @ X9_v23-8]");
								if ((IntPtr)0 == (IntPtr)obj5)
								{
									JSONNode aItem3 = stack.Peek();
									jSONNode.Add(aItem3);
									goto IL_0d36;
								}
							}
						}
						if (text9 != text3)
						{
							JSONNode aItem4 = stack.Peek();
							IntPtr intPtr7 = (IntPtr)jSONNode;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1142 @ X8_v46 (Il2CppClass<com.adjust.sdk.JSONNode>)+178]");
							obj3 = 0;
							jSONNode.Add(text9, aItem4);
						}
					}
					goto IL_0d36;
					IL_0d92:
					string text10 = text + text6;
					text = text10;
					num2 = 1;
					goto IL_0dd7;
					IL_0d4b:
					IntPtr intPtr8 = (IntPtr)text3;
					bool flag25 = stack.Count < 1;
					object obj7 = obj3;
					IntPtr intPtr9 = (IntPtr)text3;
					if (!flag25)
					{
						goto IL_0c1d;
					}
					goto IL_0db9;
					IL_0c1d:
					JSONNode jSONNode2 = stack.Peek();
					obj3 = obj7;
					jSONNode = jSONNode2;
					intPtr9 = intPtr8;
					goto IL_0db9;
					IL_09a4:
					char c4 = aJSON.get_Chars(num);
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @F91044 (inside System.Char::GetLatin1UnicodeCategory +0x228)");
					string text11 = text + text12;
					text4 = text11;
					num2 = 1;
					goto IL_0cf2;
					IL_06c1:
					if ((num2 & 1) != 0)
					{
						goto IL_09a4;
					}
					text4 = text;
					num2 = 0;
					goto IL_0cf2;
					IL_0db9:
					text4 = (string)(long)intPtr9;
					num2 = 0;
					text2 = (string)(long)intPtr9;
					goto IL_0cf2;
					IL_0d29:
					intPtr9 = (IntPtr)text3;
					goto IL_0db9;
					IL_0bb5:
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @F91044 (inside System.Char::GetLatin1UnicodeCategory +0x228)");
					text6 = text13;
					goto IL_0d92;
					IL_074a:
					if ((num2 & 1) != 0)
					{
						goto IL_09a4;
					}
					if (stack.Count != 0)
					{
						JSONNode jSONNode3 = stack.Pop();
						if (text != text3)
						{
							string text14 = text2.Trim();
							if ((object)jSONNode != null)
							{
								IntPtr intPtr10 = (IntPtr)jSONNode;
								object obj8 = (long)intPtr;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1147 @ X9_v13 (Il2CppClass<com.adjust.sdk.JSONNode>)+128]");
								IntPtr intPtr11 = (IntPtr)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1148 @ X8_v39+128]");
								if ((long)intPtr11 >= 0L)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1148 @ X8_v39+128]");
									int num19 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1147 @ X9_v13 (Il2CppClass<com.adjust.sdk.JSONNode>)+C8]");
									object obj9 = 0L + (long)num19;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1161 @ X9_v15-8]");
									if ((IntPtr)0 == (IntPtr)obj8)
									{
										JSONNode aItem5 = text;
										jSONNode.Add(aItem5);
										goto IL_0d4b;
									}
								}
							}
							if (text14 != text3)
							{
								JSONNode aItem6 = text;
								IntPtr intPtr12 = (IntPtr)jSONNode;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1077 @ X8_v38 (Il2CppClass<com.adjust.sdk.JSONNode>)+178]");
								obj3 = 0;
								jSONNode.Add(text14, aItem6);
							}
						}
						goto IL_0d4b;
					}
					Exception ex = new Exception();
					text15 = "JSON Parse: Too many closing brackets";
					goto IL_0df5;
					IL_0cf2:
					num++;
					bool flag26 = num < aJSON.Length;
					text = text4;
					if (flag26)
					{
						continue;
					}
					if ((num2 & 1) == 0)
					{
						break;
					}
					ex = new Exception(text15);
					text15 = "JSON Parse: Quotation marks seems to be messed up.";
					goto IL_0df5;
					IL_0dd7:
					text4 = text;
					num = num11;
					text3 = "";
					goto IL_0cf2;
					IL_0df5:
					throw ex;
					IL_0d36:
					intPtr8 = (IntPtr)text3;
					obj7 = obj3;
					goto IL_0c1d;
				}
			}
			else
			{
				jSONNode = null;
			}
			return jSONNode;
		}

		[Token(Token = "0x6000023")]
		[Address(RVA = "0x1574318", Offset = "0x1574318", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void Serialize(BinaryWriter aWriter)
		{
		}

		[Token(Token = "0x6000024")]
		[Address(RVA = "0x157431C", Offset = "0x157431C", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EFADB8]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, aData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202912D]) = v41;\nL_0018:\n\tv45 = new System.IO.BinaryWriter();\n\tSystem.IO.BinaryWriter::.ctor(v45, aData);\n\tv49 = this->klass;\n\tv55 = this->klass->vtable[28];\n\tv56 = this->klass->vtable[28];\n\t// 40 IndirectJump v55 @ X3_v1, this @ X0 (com.adjust.sdk.JSONNode), this @ X0 (com.adjust.sdk.JSONNode), v45 @ X0_v3 (System.IO.BinaryWriter), v56 @ X2_v2, v55 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SaveToStream(Stream aData)
		{
			//IL_0018: Expected I, but got O
			//IL_0028: Expected O, but got I
			//IL_0038: Expected O, but got I
			BinaryWriter binaryWriter = new BinaryWriter(aData);
			IntPtr intPtr = (IntPtr)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ X8_v5 (Il2CppClass<com.adjust.sdk.JSONNode>)+2F0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ X8_v5 (Il2CppClass<com.adjust.sdk.JSONNode>)+2F8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v55 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000025")]
		[Address(RVA = "0x157439C", Offset = "0x157439C", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EE0628]);\n\tv14 = *([v13 @ X8_v10]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, aData, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([202912E]) = v34;\nL_0014:\n\tv38 = new System.Exception();\n\tSystem.Exception::.ctor(v38, \"Can't use compressed functions. You need include the SharpZipLib and uncomment the define at the top of SimpleJSON\");\n\tthrow System.TypeLoadException;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SaveToCompressedStream(Stream aData)
		{
			Exception ex = new Exception("Can't use compressed functions. You need include the SharpZipLib and uncomment the define at the top of SimpleJSON");
			throw new TypeLoadException();
		}

		[Token(Token = "0x6000026")]
		[Address(RVA = "0x157440C", Offset = "0x157440C", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1F0E140]);\n\tv14 = *([v13 @ X8_v10]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, aFileName, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([202912F]) = v34;\nL_0014:\n\tv38 = new System.Exception();\n\tSystem.Exception::.ctor(v38, \"Can't use compressed functions. You need include the SharpZipLib and uncomment the define at the top of SimpleJSON\");\n\tthrow System.TypeLoadException;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SaveToCompressedFile(string aFileName)
		{
			Exception ex = new Exception("Can't use compressed functions. You need include the SharpZipLib and uncomment the define at the top of SimpleJSON");
			throw new TypeLoadException();
		}

		[Token(Token = "0x6000027")]
		[Address(RVA = "0x157447C", Offset = "0x157447C", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1F0D3B8]);\n\tv14 = *([v13 @ X8_v10]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([2029130]) = v34;\nL_0014:\n\tv38 = new System.Exception();\n\tSystem.Exception::.ctor(v38, \"Can't use compressed functions. You need include the SharpZipLib and uncomment the define at the top of SimpleJSON\");\n\treturnVal1 = new System.TypeLoadException();\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string SaveToCompressedBase64()
		{
			Exception ex = new Exception("Can't use compressed functions. You need include the SharpZipLib and uncomment the define at the top of SimpleJSON");
			return (string)(object)new TypeLoadException();
		}

		[Token(Token = "0x6000028")]
		[Address(RVA = "0x15744EC", Offset = "0x15744EC", Length = "0x394")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([2029131]);\n\tgoto L_0019;\n\tv25 = *([1EC39D8]);\n\tv26 = *([v25 @ X8_v19]);\n\tv27 = \"il2cpp_codegen_initialize_method\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2029131]) = v45;\nL_0019:\n\tv47 = aReader->klass;\n\tv50 = aReader->klass->vtable[10];\n\tv51 = System.IO.BinaryReader::ReadByte(aReader);\n\tv18 = v51 & 0xFF;\n\tv53 = v18 - 1;\n\tv54 = v53 < 6;\n\tv55 = ~v54;\n\tv56 = v53 - 6;\n\tv58 = v56 == 0;\n\tv63 = ~v58;\n\tv64 = v55 & v63;\n\tif (v64) goto L_010F;\n\tv18 = 0x1835000 + 0x938;\n\tv18 = *([v18 @ X8_v1 (System.Int32)+v53 @ X9_v5 (System.Int32)*4]) + v18;\n\t// 48 IndirectJump v18 @ X8_v1 (System.Int32), v51 @ X0_v14 (System.Byte), v51 @ X0_v14 (System.Byte), v50 @ X1_v6, v29 @ X2, v30 @ X3, v31 @ X4, v32 @ X5, v33 @ X6, v34 @ X7, v35 @ V0, v36 @ V1, v37 @ V2, v38 @ V3, v39 @ V4, v40 @ V5, v41 @ V6, v42 @ V7\n\tX8 = *([X20]);\n\tX0 = X20;\n\tX9 = *([X8+220]);\n\tX1 = *([X8+228]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EB8980]);\n\tX21 = X0;\n\tX8 = *([X8]);\n\tX0 = X8;\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tcom.adjust.sdk.JSONArray::.ctor(X0, X1);\n\tC = X21 < 1;\n\tC = ~C;\n\tTEMP1 = X21 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X21 ^ 1;\n\tTEMP3 = X21 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_00FD;\n\tX22 = 0;\nL_004B:\n\tX0 = X20;\n\tX0 = com.adjust.sdk.JSONNode::Deserialize(X0, X1);\n\tX1 = X0;\n\tif (TEMP) goto L_0108;\n\tX8 = *([X19]);\n\tX0 = X19;\n\tX9 = *([X8+1F0]);\n\tX2 = *([X8+1F8]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX22 = X22 + 1;\n\tC = X22 < X21;\n\tC = ~C;\n\tTEMP1 = X22 - X21;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X21;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_004B;\n\tgoto L_00FD;\n\tX8 = *([X20]);\n\tX0 = X20;\n\tX9 = *([X8+220]);\n\tX1 = *([X8+228]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EB21E0]);\n\tX21 = X0;\n\tX8 = *([X8]);\n\tX0 = X8;\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tcom.adjust.sdk.JSONClass::.ctor(X0, X1);\n\tC = X21 < 1;\n\tC = ~C;\n\tTEMP1 = X21 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X21 ^ 1;\n\tTEMP3 = X21 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_00FD;\n\tX23 = 0;\nL_007D:\n\tX8 = *([X20]);\n\tX0 = X20;\n\tX9 = *([X8+290]);\n\tX1 = *([X8+298]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX22 = X0;\n\tX0 = X20;\n\tX0 = com.adjust.sdk.JSONNode::Deserialize(X0, X1);\n\tX2 = X0;\n\tif (TEMP) goto L_0108;\n\tX8 = *([X19]);\n\tX0 = X19;\n\tX1 = X22;\n\tX9 = *([X8+170]);\n\tX3 = *([X8+178]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX23 = X23 + 1;\n\tC = X23 < X21;\n\tC = ~C;\n\tTEMP1 = X23 - X21;\n\tN = TEMP1 < 0;\n\tTEMP2 = X23 ^ X21;\n\tTEMP3 = X23 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_007D;\n\tgoto L_00FD;\n\tX8 = *([X20]);\n\tX0 = X20;\n\tX9 = *([X8+290]);\n\tX1 = *([X8+298]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EDEAC8]);\n\tX20 = X0;\n\tX8 = *([X8]);\n\tX0 = X8;\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX19 = X0;\n\tSystem.Object::.ctor(X0, X1);\n\t*([X19+10]) = X20;\n\tgoto L_00FD;\n\tX8 = *([X20]);\n\tX0 = X20;\n\tX9 = *([X8+220]);\n\tX1 = *([X8+228]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EDEAC8]);\n\tX20 = X0;\n\tX8 = *([X8]);\n\tX0 = X8;\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX19 = X0;\n\tSystem.Object::.ctor(X0, X1);\n\tX8 = *([X19]);\n\tX0 = X19;\n\tX1 = X20;\n\tX9 = *([X8+260]);\n\tX2 = *([X8+268]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_00FD;\n\tX8 = *([X20]);\n\tX0 = X20;\n\tX9 = *([X8+270]);\n\tX1 = *([X8+278]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EDEAC8]);\n\tV8 = V0;\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX19 = X0;\n\tSystem.Object::.ctor(X0, X1);\n\tX8 = *([X19]);\n\tX0 = X19;\n\tV0 = V8;\n\tX9 = *([X8+2A0]);\n\tX1 = *([X8+2A8]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_00FD;\n\tX8 = *([X20]);\n\tX0 = X20;\n\tX9 = *([X8+1C0]);\n\tX1 = *([X8+1C8]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EDEAC8]);\n\tX20 = X0;\n\tX8 = *([X8]);\n\tX0 = X8;\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX19 = X0;\n\tSystem.Object::.ctor(X0, X1);\n\tX8 = *([X19]);\n\tX1 = X20 & 1;\n\tX0 = X19;\n\tX9 = *([X8+2C0]);\n\tX2 = *([X8+2C8]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_00FD;\n\tX8 = *([X20]);\n\tX0 = X20;\n\tX9 = *([X8+260]);\n\tX1 = *([X8+268]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EDEAC8]);\n\tV8 = V0;\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX19 = X0;\n\tSystem.Object::.ctor(X0, X1);\n\tX8 = *([X19]);\n\tX0 = X19;\n\tV0 = V8;\n\tX9 = *([X8+280]);\n\tX1 = *([X8+288]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00FD:\n\tX0 = X19;\n\tX29 = stack[40];\n\tX30 = stack[48];\n\tX20 = stack[30];\n\tX19 = stack[38];\n\tX22 = stack[20];\n\tX21 = stack[28];\n\tX23 = stack[18];\n\tV8 = stack[10];\n\t// 262 ShiftStack 80\n\treturn X0;\nL_0108:\n\t;\n\tthrow System.NullReferenceException;\nL_010F:\n\t// 271 Box v99 @ X0_v4 (System.Object), typeof(com.adjust.sdk.JSONBinaryTag), &v18 @ X8_v1 (System.Int32)\n\tv130 = System.String::Concat(\"Error deserializing JSON. Unknown tag: \", v99);\n\tv135 = new System.Exception();\n\tSystem.Exception::.ctor(v135, v130);\n\tthrow v135;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static JSONNode Deserialize(BinaryReader aReader)
		{
			//IL_001d: Expected I, but got O
			//IL_002d: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [2029131]");
			int num = 0;
			IntPtr intPtr = (IntPtr)aReader;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X8_v12 (Il2CppClass<System.IO.BinaryReader>)+1D8]");
			object obj = 0;
			byte b = aReader.ReadByte();
			num = b & 0xFF;
			int num2 = num - 1;
			bool flag = num2 < 6;
			bool flag2 = !flag;
			int num3 = num2 - 6;
			bool flag3 = num3 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				num = 25382912 + 2360;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ X8_v1 (System.Int32)+v53 @ X9_v5 (System.Int32)*4]");
				num = (int)(0L + (long)num);
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v18 @ X8_v1 (System.Int32) (should have been resolved before IL gen)");
			}
			object obj2 = (JSONBinaryTag)num;
			string message = "Error deserializing JSON. Unknown tag: " + obj2;
			Exception ex = new Exception(message);
			throw ex;
		}

		[Token(Token = "0x6000029")]
		[Address(RVA = "0x1574880", Offset = "0x1574880", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1ECD400]);\n\tv14 = *([v13 @ X8_v10]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([2029132]) = v34;\nL_0014:\n\tv38 = new System.Exception();\n\tSystem.Exception::.ctor(v38, \"Can't use compressed functions. You need include the SharpZipLib and uncomment the define at the top of SimpleJSON\");\n\treturnVal1 = new System.TypeLoadException();\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static JSONNode LoadFromCompressedFile(string aFileName)
		{
			Exception ex = new Exception("Can't use compressed functions. You need include the SharpZipLib and uncomment the define at the top of SimpleJSON");
			return (JSONNode)(object)new TypeLoadException();
		}

		[Token(Token = "0x600002A")]
		[Address(RVA = "0x15748F0", Offset = "0x15748F0", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EC4130]);\n\tv14 = *([v13 @ X8_v10]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([2029133]) = v34;\nL_0014:\n\tv38 = new System.Exception();\n\tSystem.Exception::.ctor(v38, \"Can't use compressed functions. You need include the SharpZipLib and uncomment the define at the top of SimpleJSON\");\n\treturnVal1 = new System.TypeLoadException();\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static JSONNode LoadFromCompressedStream(Stream aData)
		{
			Exception ex = new Exception("Can't use compressed functions. You need include the SharpZipLib and uncomment the define at the top of SimpleJSON");
			return (JSONNode)(object)new TypeLoadException();
		}

		[Token(Token = "0x600002B")]
		[Address(RVA = "0x1574960", Offset = "0x1574960", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1F08100]);\n\tv14 = *([v13 @ X8_v10]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([2029134]) = v34;\nL_0014:\n\tv38 = new System.Exception();\n\tSystem.Exception::.ctor(v38, \"Can't use compressed functions. You need include the SharpZipLib and uncomment the define at the top of SimpleJSON\");\n\treturnVal1 = new System.TypeLoadException();\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static JSONNode LoadFromCompressedBase64(string aBase64)
		{
			Exception ex = new Exception("Can't use compressed functions. You need include the SharpZipLib and uncomment the define at the top of SimpleJSON");
			return (JSONNode)(object)new TypeLoadException();
		}

		[Token(Token = "0x600002C")]
		[Address(RVA = "0x15749D0", Offset = "0x15749D0", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EF0518]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029135]) = v42;\nL_0018:\n\tv46 = new System.IO.BinaryReader();\n\tSystem.IO.BinaryReader::.ctor(v46, aData);\n\tv51 = com.adjust.sdk.JSONNode::Deserialize(v46);\n\tv55 = v46 == 0;\n\tif (v55) goto L_0052;\nL_002A:\n\tgoto L_0051;\n\tv160 = *([v115 @ X8_v7+B0]);\n\tv161 = 0;\n\tv162 = v160 + 8;\n\tv164 = *([v210 @ X11_v7-8]);\n\tv216 = v164 == v118;\n\tif (v216) goto L_004A;\n\tv186 = v211 + 1;\n\tv243 = v186 < v117;\n\tv182 = ~v243;\n\tv184 = v210 + 0x10;\n\tv166 = ~v182;\n\tif (v166) goto L_FFFFFFFF;\n\tv187 = v49;\n\tv188 = 0;\n\tv189 = 0x8909C4(v187, v118, v188, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0051;\nL_004A:\n\tv244 = *([v210 @ X11_v7]);\n\tv245 = v244 << 4;\n\tv246 = v115 + v245;\n\tv247 = v246 + 0x130;\nL_0051:\n\tSystem.IDisposable::Dispose(v46);\nL_0052:\n\tv154 = v144 + 1;\n\tv156 = v154 == 0;\n\tv159 = ~v156;\n\tif (v159) goto L_0064;\n\tv190 = v143 == 0;\n\tv191 = ~v190;\n\tif (v191) goto L_0068;\nL_0064:\n\treturn v152;\nL_0068:\n\tv222 = new System.TypeLoadException();\n\tgoto L_007D;\n\tv252 = 0x6D2BC0(v222, 0, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv98 = *([v252 @ X0_v11]);\n\tv107 = 0x6D2490(v252, 0, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv253 = v46 == 0;\n\tv109 = ~v253;\n\tif (v109) goto L_002A;\n\tgoto L_0052;\nL_007D:\n\treturnVal2 = 0x6D2380(v222, 0, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\treturn returnVal2;\n// 75 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static JSONNode LoadFromStream(Stream aData)
		{
			BinaryReader binaryReader = new BinaryReader(aData);
			JSONNode jSONNode = Deserialize(binaryReader);
			bool flag = binaryReader == null;
			int num = 0;
			int num2 = 0;
			JSONNode jSONNode2 = jSONNode;
			int num3 = 0;
			int num4 = 0;
			JSONNode result = jSONNode;
			if (!flag)
			{
				((IDisposable)binaryReader).Dispose();
				num3 = num;
				num4 = num2;
				result = jSONNode2;
			}
			if (num4 + 1 != 0 || num3 == 0)
			{
				return result;
			}
			TypeLoadException ex = new TypeLoadException();
			Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			JSONNode result2 = default(JSONNode);
			return result2;
		}

		[Token(Token = "0x600002D")]
		[Address(RVA = "0x1574B00", Offset = "0x1574B00", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EE72B0]);\n\tv19 = *([v18 @ X8_v14]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029136]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0021:\n\tv54 = System.Convert::FromBase64String(aBase64);\n\tv60 = new System.IO.MemoryStream();\n\tSystem.IO.MemoryStream::.ctor(v60, v54);\n\tv70 = System.IO.MemoryStream::set_Position(v60, 0);\n\treturnVal1 = com.adjust.sdk.JSONNode::LoadFromStream(v60);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static JSONNode LoadFromBase64(string aBase64)
		{
			//IL_0038: Expected I8, but got I4
			byte[] buffer = Convert.FromBase64String(aBase64);
			MemoryStream memoryStream = new MemoryStream(buffer);
			memoryStream.Position = 0L;
			return LoadFromStream(memoryStream);
		}

		[Token(Token = "0x600002E")]
		[Address(RVA = "0x1570E64", Offset = "0x1570E64", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public JSONNode()
		{
		}
	}
}
