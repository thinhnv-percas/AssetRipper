using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using TMPro;
using Unco.Extensions;
using UnityEngine;

namespace Unco.Objects
{
	[ExecuteAlways]
	[Token(Token = "0x200002A")]
	public class UncoTMP : TextMeshProUGUI
	{
		[CompilerGenerated]
		[Token(Token = "0x200002B")]
		private sealed class _003CWriteTextLetterByLetter_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x40000A0")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x40000A1")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x40000A2")]
			[FieldOffset(Offset = "0x20")]
			public UncoTMP _003C_003E4__this;

			[Token(Token = "0x40000A3")]
			[FieldOffset(Offset = "0x28")]
			private List<string> _003CelementList_003E5__2;

			[Token(Token = "0x40000A4")]
			[FieldOffset(Offset = "0x30")]
			private int _003Cindex_003E5__3;

			[Token(Token = "0x17000015")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60000D0")]
				[Address(RVA = "0x81C68A0", Offset = "0x81C68A0", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000016")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60000D2")]
				[Address(RVA = "0x81C68E8", Offset = "0x81C68E8", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60000CD")]
			[Address(RVA = "0x81C5E54", Offset = "0x81C5E54", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CWriteTextLetterByLetter_003Ed__12(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x60000CE")]
			[Address(RVA = "0x81C6560", Offset = "0x81C6560", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x60000CF")]
			[Address(RVA = "0x81C6564", Offset = "0x81C6564", Length = "0x33C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0033;\n\tv69 = this.<>1__state == 0;\n\tv70 = ~v69;\n\tif (v70) goto L_FFFFFFFF;\n\tthis.<>1__state = -1;\n\tv129 = Unco.Objects.UncoTMP::ParseElements(*([v56 @ X20_v2 (TMPro.TMP_Text)+7D0]));\n\tthis.<elementList>5__2 = v129;\n\tthis.<index>5__3 = 1;\n\tgoto L_0052;\nL_0051:\n\tthis.<>1__state = -1;\n\tv80 = *([v103 @ X21_v4 (System.Collections.Generic.IEnumerable`1<System.String>)+18]) <= this.<index>5__3;\n\tif (v80) goto L_00BF;\n\tv184 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v184, v103);\n\tv316 = this.<index>5__3 - 1;\n\tv320 = System.Collections.Generic.List`1<System.String>::get_Item(v184, v316);\n\tSystem.Collections.Generic.List`1<System.String>::Insert(v184, this.<index>5__3, \"<alpha=#00>\");\n\tv135 = v184.Count - 1;\n\tv334 = this.<index>5__3 + 1;\n\tv344 = v135 >= v334;\n\tif (v344) goto L_00CB;\nL_0095:\n\tv185 = System.String::Join(\"\", v184);\n\tTMPro.TMP_Text::SetText(this.<>4__this, v185);\n\tv376 = this.<index>5__3 + 1;\n\tthis.<index>5__3 = v376;\n\tgoto L_00B2;\nL_FFFFFFFF:\n\tv212 = 0x3E199999;\n\tgoto L_0114;\nL_00BF:\n\tTMPro.TMP_Text::SetText(this.<>4__this, *([v56 @ X20_v2 (TMPro.TMP_Text)+7D0]));\n\tv113 = *([v56 @ X20_v2 (TMPro.TMP_Text)+7D8]);\n\tv111 = *([v56 @ X20_v2 (TMPro.TMP_Text)+7D8]) == 0;\n\tif (v111) goto L_FFFFFFFF;\n\t*([v113 @ X8_v7+18])(v108, *([v113 @ X8_v7+40]), *([v113 @ X8_v7+28]), 0, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_00CB:\n\tgoto L_00DE;\nL_00CC:\n\tv135 = v135 - 1;\n\tv363 = this.<index>5__3 + 1;\n\tv348 = v135 < v363;\n\tif (v348) goto L_0095;\nL_00DE:\n\tv186 = System.Collections.Generic.List`1<System.String>::get_Item(v184, v135);\n\tv393 = v186.Length < 2;\n\tif (v393) goto L_00CC;\n\tSystem.Collections.Generic.List`1<System.String>::RemoveAt(v184, v135);\n\tgoto L_00CC;\nL_00FA:\n\tv436 = System.String::Contains(\".!?\", v320);\n\tv429 = v436 == 0;\n\tv424 = ~v429;\n\tv417 = ~v424;\n\tif (v417) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv212 = 0x3E999999;\n\tgoto L_0114;\nL_FFFFFFFF:\n\tv212 = 0x3CF5C28F;\n\tthis.<>1__state = 1;\nL_FFFFFFFF:\n\treturnVal1 = 1;\nL_0033:\n\tv56 = this.<>4__this;\n\tv61 = this.<>1__state == 1;\n\tif (v61) goto L_0051;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tgoto L_012D;\nL_0052:\n\tv103 = this.<elementList>5__2;\nL_00B2:\n\tv402 = System.String::op_Equality(v320, \",\");\n\tv412 = v402 == 0;\n\tif (v412) goto L_00FA;\nL_0114:\n\tv441 = new UnityEngine.WaitForSecondsRealtime();\n\tUnityEngine.WaitForSecondsRealtime::.ctor(v441, v212);\n\tthis.<>2__current = v441;\nL_012D:\n\treturn returnVal1;\n")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("UncoTMP._003CWriteTextLetterByLetter_003Ed__12::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60000D1")]
			[Address(RVA = "0x81C68A8", Offset = "0x81C68A8", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200002C")]
		private sealed class _003CWriteTextWithAlpha_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x40000A5")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x40000A6")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x40000A7")]
			[FieldOffset(Offset = "0x20")]
			public UncoTMP _003C_003E4__this;

			[Token(Token = "0x40000A8")]
			[FieldOffset(Offset = "0x28")]
			private List<string> _003CelementList_003E5__2;

			[Token(Token = "0x40000A9")]
			[FieldOffset(Offset = "0x30")]
			private int _003Cindex_003E5__3;

			[Token(Token = "0x17000017")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60000D6")]
				[Address(RVA = "0x81C6BB8", Offset = "0x81C6BB8", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000018")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60000D8")]
				[Address(RVA = "0x81C6C00", Offset = "0x81C6C00", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60000D3")]
			[Address(RVA = "0x81C5E28", Offset = "0x81C5E28", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CWriteTextWithAlpha_003Ed__11(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x60000D4")]
			[Address(RVA = "0x81C68F0", Offset = "0x81C68F0", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x60000D5")]
			[Address(RVA = "0x81C68F4", Offset = "0x81C68F4", Length = "0x2C4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv61 = this.<>1__state == 0;\n\tv62 = ~v61;\n\tif (v62) goto L_00BB;\n\tthis.<>1__state = -1;\n\tv129 = Unco.Objects.UncoTMP::ParseElements(*([v48 @ X20_v2 (TMPro.TMP_Text)+7D0]));\n\tthis.<elementList>5__2 = v129;\n\tthis.<index>5__3 = 1;\n\tgoto L_004B;\nL_004A:\n\tthis.<>1__state = -1;\n\tv72 = *([v95 @ X21_v2 (System.Collections.Generic.IEnumerable`1<System.String>)+18]) <= this.<index>5__3;\n\tif (v72) goto L_00A9;\n\tv156 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v156, v95);\n\tv246 = this.<index>5__3 - 1;\n\tv251 = System.Collections.Generic.List`1<System.String>::get_Item(v156, v246);\n\tSystem.Collections.Generic.List`1<System.String>::Insert(v156, this.<index>5__3, \"<alpha=#00>\");\n\tv157 = System.String::Join(\"\", v156);\n\tTMPro.TMP_Text::SetText(this.<>4__this, v157);\n\tv266 = this.<index>5__3 + 1;\n\tthis.<index>5__3 = v266;\n\tgoto L_009C;\nL_FFFFFFFF:\n\tv293 = 0x3E199999;\n\tgoto L_00DD;\nL_00A9:\n\tTMPro.TMP_Text::SetText(this.<>4__this, *([v48 @ X20_v2 (TMPro.TMP_Text)+7D0]));\n\tv105 = *([v48 @ X20_v2 (TMPro.TMP_Text)+7D8]);\n\tv103 = *([v48 @ X20_v2 (TMPro.TMP_Text)+7D8]) == 0;\n\tif (v103) goto L_00BB;\n\t*([v105 @ X8_v6+18])(v100, *([v105 @ X8_v6+40]), *([v105 @ X8_v6+28]), 0, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_00C3:\n\tv309 = System.String::Contains(\".!?\", v251);\n\tv302 = v309 == 0;\n\tv297 = ~v302;\n\tv289 = ~v297;\n\tif (v289) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv293 = 0x3E999999;\n\tgoto L_00DD;\nL_FFFFFFFF:\n\tv293 = 0x3CF5C28F;\n\tthis.<>1__state = 1;\n\treturn 1;\nL_002C:\n\tv48 = this.<>4__this;\n\tv53 = this.<>1__state == 1;\n\tif (v53) goto L_004A;\nL_00BB:\n\treturn 0;\nL_004B:\n\tv95 = this.<elementList>5__2;\nL_009C:\n\tv280 = System.String::op_Equality(v251, \",\");\n\tv284 = v280 == 0;\n\tif (v284) goto L_00C3;\nL_00DD:\n\tv314 = new UnityEngine.WaitForSecondsRealtime();\n\tUnityEngine.WaitForSecondsRealtime::.ctor(v314, v293);\n\tthis.<>2__current = v314;\n")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("UncoTMP._003CWriteTextWithAlpha_003Ed__11::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60000D7")]
			[Address(RVA = "0x81C6BC0", Offset = "0x81C6BC0", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Token(Token = "0x400009B")]
		private const string AlphaOpenBracket = "<alpha=#00>";

		[Token(Token = "0x400009C")]
		private const float WriteTime = 0.03f;

		[Token(Token = "0x400009D")]
		[FieldOffset(Offset = "0x7C8")]
		private Coroutine _typingCoroutine;

		[Token(Token = "0x400009E")]
		[FieldOffset(Offset = "0x7D0")]
		private string _value;

		[Token(Token = "0x400009F")]
		[FieldOffset(Offset = "0x7D8")]
		private Action _finishAction;

		[Token(Token = "0x17000014")]
		public Color Color
		{
			[Token(Token = "0x60000BF")]
			[Address(RVA = "0x81C5B54", Offset = "0x81C5B54", Length = "0x14")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.color;\n")]
			get
			{
				return color;
			}
		}

		[Token(Token = "0x60000C0")]
		[Address(RVA = "0x81C5B68", Offset = "0x81C5B68", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = UnityEngine.UI.Graphic::set_raycastTarget(this, 0);\n\tTMPro.TextMeshProUGUI::OnEnable(this);\n\treturn;\n")]
		protected override void OnEnable()
		{
			base.raycastTarget = false;
			base.OnEnable();
		}

		[Token(Token = "0x60000C1")]
		[Address(RVA = "0x81C34CC", Offset = "0x81C34CC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tTMPro.TMP_Text::SetText(this, value);\n\treturn;\n")]
		public new void SetText(string value)
		{
			base.SetText(value);
		}

		[Token(Token = "0x60000C2")]
		[Address(RVA = "0x81C5BA0", Offset = "0x81C5BA0", Length = "0x164")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tgoto L_0019;\nL_0019:\n\tv56 = UnityEngine.Application::get_isPlaying();\n\tv64 = v56 == 0;\n\tif (v64) goto L_0063;\n\tthis._value = newText;\n\tthis._finishAction = finishAction;\n\tgoto L_0033;\n\tv152 = UnityEngine.MonoBehaviour::StartCoroutine(this, v119);\n\tthis._typingCoroutine = v152;\n\treturn;\nL_0063:\n\tTMPro.TMP_Text::SetText(this, newText);\n\tv85 = finishAction == 0;\n\tif (v85) goto L_007C;\n\tSystem.Action::Invoke(finishAction);\n\treturn;\nL_007C:\n\treturn;\nL_0033:\n\tv119 = new Unco.Objects.UncoTMP+<WriteTextLetterByLetter>d__12();\n\tSystem.Object::.ctor(v119);\n\tv119.<>1__state = 0;\n\tv119.<>4__this = this;\n")]
		public void TypeText(string newText, Action finishAction = null)
		{
			if (Application.isPlaying)
			{
				_value = newText;
				_finishAction = finishAction;
				_003CWriteTextLetterByLetter_003Ed__12 _003CWriteTextLetterByLetter_003Ed__13 = (_003CWriteTextLetterByLetter_003Ed__12)FormatterServices.GetUninitializedObject(typeof(_003CWriteTextLetterByLetter_003Ed__12));
				_003CWriteTextLetterByLetter_003Ed__13._003C_003E1__state = 0;
				_003CWriteTextLetterByLetter_003Ed__13._003C_003E4__this = this;
				Coroutine typingCoroutine = StartCoroutine(_003CWriteTextLetterByLetter_003Ed__13);
				_typingCoroutine = typingCoroutine;
			}
			else
			{
				base.SetText(newText);
				finishAction?.Invoke();
			}
		}

		[Token(Token = "0x60000C3")]
		[Address(RVA = "0x81C5D7C", Offset = "0x81C5D7C", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::StopCoroutine(this, this._typingCoroutine);\n\tTMPro.TMP_Text::SetText(this, this._value);\n\treturn;\n")]
		public void FinishTypeText()
		{
			StopCoroutine(_typingCoroutine);
			base.SetText(_value);
		}

		[IteratorStateMachine(typeof(_003CWriteTextWithAlpha_003Ed__11))]
		[Token(Token = "0x60000C4")]
		[Address(RVA = "0x81C5DB0", Offset = "0x81C5DB0", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\treturn v45;\nL_0017:\n\tv45 = new Unco.Objects.UncoTMP+<WriteTextWithAlpha>d__11();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.<>4__this = this;\n")]
		private IEnumerator WriteTextWithAlpha()
		{
			_003CWriteTextWithAlpha_003Ed__11 _003CWriteTextWithAlpha_003Ed__12 = (_003CWriteTextWithAlpha_003Ed__11)FormatterServices.GetUninitializedObject(typeof(_003CWriteTextWithAlpha_003Ed__11));
			_003CWriteTextWithAlpha_003Ed__12._003C_003E1__state = 0;
			_003CWriteTextWithAlpha_003Ed__12._003C_003E4__this = this;
			return _003CWriteTextWithAlpha_003Ed__12;
		}

		[IteratorStateMachine(typeof(_003CWriteTextLetterByLetter_003Ed__12))]
		[Token(Token = "0x60000C5")]
		[Address(RVA = "0x81C5D04", Offset = "0x81C5D04", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\treturn v45;\nL_0017:\n\tv45 = new Unco.Objects.UncoTMP+<WriteTextLetterByLetter>d__12();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.<>4__this = this;\n")]
		private IEnumerator WriteTextLetterByLetter()
		{
			_003CWriteTextLetterByLetter_003Ed__12 _003CWriteTextLetterByLetter_003Ed__13 = (_003CWriteTextLetterByLetter_003Ed__12)FormatterServices.GetUninitializedObject(typeof(_003CWriteTextLetterByLetter_003Ed__12));
			_003CWriteTextLetterByLetter_003Ed__13._003C_003E1__state = 0;
			_003CWriteTextLetterByLetter_003Ed__13._003C_003E4__this = this;
			return _003CWriteTextLetterByLetter_003Ed__13;
		}

		[Token(Token = "0x60000C6")]
		[Address(RVA = "0x81C5E80", Offset = "0x81C5E80", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\treturnVal1 = f * 5f;\n\treturn returnVal1;\nL_0035:\n\tv114 = System.String::Contains(\".!?\", tempElement);\n\treturnVal3 = f * 10f;\n\tv91 = v114 == 0;\n\tv76 = ~v91;\n\tv73 = ~v76;\n\tif (v73) goto L_FFFFFFFF;\n\tgoto L_0051;\nL_FFFFFFFF:\n\treturnVal3 = f;\nL_001F:\n\tv53 = System.String::op_Equality(tempElement, \",\");\n\tv56 = ~v53;\n\tif (v56) goto L_0035;\nL_0051:\n\treturn returnVal3;\n")]
		private float GetWriteSeconds(string tempElement, float f)
		{
			if (tempElement == ",")
			{
				return f * 5f;
			}
			bool flag = ".!?".Contains(tempElement);
			float result = f * 10f;
			if (!flag)
			{
				result = f;
			}
			return result;
		}

		[Token(Token = "0x60000C7")]
		[Address(RVA = "0x81C5F44", Offset = "0x81C5F44", Length = "0x298")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv81 = value.Length < 1;\n\tif (v81) goto L_00F7;\n\tv157 = 0;\n\tv164 = \"\";\n\tgoto L_0064;\nL_004B:\n\tgoto L_004E;\nL_004E:\n\tv312 = System.Char::ToString(&v98 @ stack_-52_v5 (System.Char));\n\tv319 = System.String::Concat(v164, v312);\n\tv164 = v319;\nL_0064:\n\tv246 = System.String::get_Chars(value, v157);\n\tv98 = v246;\n\tv132 = v246 == 0x3E;\n\tif (v132) goto L_00B1;\n\tv131 = v246 == 0x3C;\n\tif (v131) goto L_004B;\n\tgoto L_0082;\nL_0082:\n\tv297 = Unco.Extensions.StringExtensions::IsNullOrWhiteSpace(v164);\n\tv315 = ~v297;\n\tif (v315) goto L_00DB;\n\tgoto L_008E;\nL_008E:\n\tv149 = System.Char::ToString(&v98 @ stack_-52_v5 (System.Char));\n\tgoto L_00E9;\nL_00B1:\n\tgoto L_00B5;\nL_00B5:\n\tv292 = System.Char::ToString(&v98 @ stack_-52_v5 (System.Char));\n\tv150 = System.String::Concat(v164, v292);\n\tgoto L_00E2;\nL_00DB:\n\tgoto L_004E;\nL_00E2:\n\tSystem.Collections.Generic.List`1<System.String>::Add(v57, v150);\n\tv164 = \"\";\n\tgoto L_0054;\nL_00E9:\n\tSystem.Collections.Generic.List`1<System.String>::Add(v57, v149);\n\tgoto L_0054;\nL_00F7:\n\treturn v57;\nL_002A:\n\tv57 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v57);\nL_0054:\n\tv157 = v157 + 1;\n\tv190 = v157 >= value.Length;\n\tif (v190) goto L_00F7;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static List<string> ParseElements(string value)
		{
			List<string> list = new List<string>();
			if (value.Length >= 1)
			{
				int num = 0;
				string text = "";
				do
				{
					char c = value[num];
					char c2 = c;
					if (c != '>')
					{
						if (c == '<' || !text.IsNullOrWhiteSpace())
						{
							string text2 = c2.ToString();
							string text3 = text + text2;
							text = text3;
						}
						else
						{
							string item = c2.ToString();
							list.Add(item);
						}
					}
					else
					{
						string text4 = c2.ToString();
						string item2 = text + text4;
						list.Add(item2);
						text = "";
					}
					num++;
				}
				while (num < value.Length);
			}
			return list;
		}

		[Token(Token = "0x60000C8")]
		[Address(RVA = "0x81C61DC", Offset = "0x81C61DC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tTMPro.TMP_Text::set_color(this, value);\n\treturn;\n")]
		public void SetColor(Color value)
		{
			base.color = value;
		}

		[Token(Token = "0x60000C9")]
		[Address(RVA = "0x81C61E4", Offset = "0x81C61E4", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\nL_003F:\n\tUnityEngine.Material::SetColor(v61, v75.ID_OutlineColor, rgbColor);\n\tthis.fontSharedMaterial = v61;\n\tv91 = TMPro.TextMeshProUGUI::SetMaterialDirty(v91);\n\treturn;\nL_0028:\n\tv61 = new UnityEngine.Material();\n\tUnityEngine.Material::.ctor(v61, this.fontSharedMaterial);\n\tgoto L_003F;\n")]
		public void SetOutLineColorRGB(Color rgbColor)
		{
			Material material = new Material(fontSharedMaterial);
			material.SetColor(ShaderUtilities.ID_OutlineColor, rgbColor);
			m_sharedMaterial = material;
			UncoTMP uncoTMP = default(UncoTMP);
			uncoTMP.SetMaterialDirty();
		}

		[Token(Token = "0x60000CA")]
		[Address(RVA = "0x81C62E0", Offset = "0x81C62E0", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\nL_003F:\n\tUnityEngine.Material::SetColor(v61, v75.ID_UnderlayColor, rgbColor);\n\tthis.fontSharedMaterial = v61;\n\tv91 = TMPro.TextMeshProUGUI::SetMaterialDirty(v91);\n\treturn;\nL_0028:\n\tv61 = new UnityEngine.Material();\n\tUnityEngine.Material::.ctor(v61, this.fontSharedMaterial);\n\tgoto L_003F;\n")]
		public void SetUnderlayColorRGB(Color rgbColor)
		{
			Material material = new Material(fontSharedMaterial);
			material.SetColor(ShaderUtilities.ID_UnderlayColor, rgbColor);
			m_sharedMaterial = material;
			UncoTMP uncoTMP = default(UncoTMP);
			uncoTMP.SetMaterialDirty();
		}

		[Token(Token = "0x60000CB")]
		[Address(RVA = "0x81C63DC", Offset = "0x81C63DC", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\nL_003F:\n\tUnityEngine.Material::SetColor(v61, v75.ID_OutlineColor, hdrColor);\n\tthis.fontSharedMaterial = v61;\n\tv91 = TMPro.TextMeshProUGUI::SetMaterialDirty(v91);\n\treturn;\nL_0028:\n\tv61 = new UnityEngine.Material();\n\tUnityEngine.Material::.ctor(v61, this.fontSharedMaterial);\n\tgoto L_003F;\n")]
		public void SetOutlineColorHDR(Color hdrColor)
		{
			Material material = new Material(fontSharedMaterial);
			material.SetColor(ShaderUtilities.ID_OutlineColor, hdrColor);
			m_sharedMaterial = material;
			UncoTMP uncoTMP = default(UncoTMP);
			uncoTMP.SetMaterialDirty();
		}

		[Token(Token = "0x60000CC")]
		[Address(RVA = "0x81C64D8", Offset = "0x81C64D8", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_001D;\nL_001D:\n\tTMPro.TextMeshProUGUI::.ctor(this);\n\treturn;\n")]
		public UncoTMP()
		{
		}
	}
}
