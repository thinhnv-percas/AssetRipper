using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Facebook.Unity
{
	[Token(Token = "0x2000024")]
	internal class AppRequestResult : ResultBase, IAppRequestResult, IResult
	{
		[CompilerGenerated]
		[Token(Token = "0x400004F")]
		[FieldOffset(Offset = "0x48")]
		private string _003CRequestID_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000050")]
		[FieldOffset(Offset = "0x50")]
		private IEnumerable<string> _003CTo_003Ek__BackingField;

		[Token(Token = "0x17000039")]
		public string RequestID
		{
			[CompilerGenerated]
			[Token(Token = "0x60000F1")]
			[Address(RVA = "0xD1C78C", Offset = "0xD1C78C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<RequestID>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RequestID;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000F2")]
			[Address(RVA = "0xD1C794", Offset = "0xD1C794", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<RequestID>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CRequestID_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700003A")]
		public IEnumerable<string> To
		{
			[CompilerGenerated]
			[Token(Token = "0x60000F3")]
			[Address(RVA = "0xD1C79C", Offset = "0xD1C79C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<To>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return To;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000F4")]
			[Address(RVA = "0xD1C7A4", Offset = "0xD1C7A4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<To>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CTo_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x60000F0")]
		[Address(RVA = "0xD1C388", Offset = "0xD1C388", Length = "0x404")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv30 = *([1EBAE48]);\n\tv31 = *([v30 @ X8_v49]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, resultContainer, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([2023B58]) = v49;\nL_001E:\n\tFacebook.Unity.ResultBase::.ctor(this, resultContainer);\n\tv59 = Facebook.Unity.ResultBase::get_ResultDictionary(this);\n\tv60 = v59 == 0;\n\tif (v60) goto L_0187;\n\tv65 = Facebook.Unity.ResultBase::get_ResultDictionary(this);\n\tv74 = Facebook.Unity.Utilities::TryGetValue(v65, \"request\", &v71 @ stack_-48_v3 (System.String));\n\tv170 = v74 == 0;\n\tif (v170) goto L_003C;\n\tthis.<RequestID>k__BackingField = v71;\nL_003C:\n\tv236 = Facebook.Unity.ResultBase::get_ResultDictionary(this);\n\tv240 = Facebook.Unity.Utilities::TryGetValue(v236, \"to\", &v79 @ stack_-58_v3 (System.String));\n\tv242 = v240 == 0;\n\tif (v242) goto L_0060;\n\t// 75 NewArr v247 @ X0_v64 (System.Char[]), typeof(System.Char[]), 1\n\tv256 = v247.Length == 0;\n\tif (v256) goto L_012A;\n\tv247[0] = 0x2C;\n\tv144 = System.String::Split(v79, v247);\n\tthis.<To>k__BackingField = v144;\n\tgoto L_0187;\nL_0060:\n\tv251 = Facebook.Unity.ResultBase::get_ResultDictionary(this);\n\tv145 = Facebook.Unity.Utilities::TryGetValue(v251, \"to\", &v125 @ stack_-60_v8 (System.Collections.Generic.IEnumerable`1<System.Object>));\n\tv149 = v145 == 0;\n\tif (v149) goto L_0187;\n\tv281 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v281);\n\tgoto L_00A3;\n\tv363 = *([v334 @ X8_v22+B0]);\n\tv364 = 0;\n\tv365 = v363 + 8;\n\tv367 = *([v403 @ X11_v30-8]);\n\tv409 = v367 == v337;\n\tif (v409) goto L_009C;\n\tv389 = v404 + 1;\n\tv414 = v389 < v336;\n\tv385 = ~v414;\n\tv387 = v403 + 0x10;\n\tv369 = ~v385;\n\tif (v369) goto L_FFFFFFFF;\n\tv390 = v299;\n\tv391 = 0;\n\tv392 = 0x8909C4(v390, v337, v391, v127, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_00A3;\nL_009C:\n\tv415 = *([v403 @ X11_v30]);\n\tv416 = v415 << 4;\n\tv417 = v334 + v416;\n\tv418 = v417 + 0x130;\nL_00A3:\n\tv439 = System.Collections.Generic.IEnumerable`1<System.Object>::GetEnumerator(v125);\n\tv440 = v439 == 0;\n\tif (v440) goto L_012E;\nL_00B3:\n\tgoto L_00DA;\n\tv517 = *([v513 @ X8_v33+B0]);\n\tv518 = 0;\n\tv519 = v517 + 8;\n\tv521 = *([v558 @ X11_v25-8]);\n\tv564 = v521 == v514;\n\tif (v564) goto L_00D3;\n\tv543 = v559 + 1;\n\tv570 = v543 < v515;\n\tv539 = ~v570;\n\tv541 = v558 + 0x10;\n\tv523 = ~v539;\n\tif (v523) goto L_FFFFFFFF;\n\tv544 = v158;\n\tv545 = 0;\n\tv546 = 0x8909C4(v544, v514, v545, v127, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_00DA;\nL_00D3:\n\tv571 = *([v558 @ X11_v25]);\n\tv572 = v571 << 4;\n\tv573 = v513 + v572;\n\tv574 = v573 + 0x130;\nL_00DA:\n\tv595 = System.Collections.IEnumerator::MoveNext(v439);\n\tv597 = v595 == 0;\n\tif (v597) goto L_0123;\n\tgoto L_0109;\n\tv610 = *([v600 @ X8_v36+B0]);\n\tv611 = 0;\n\tv612 = v610 + 8;\n\tv614 = *([v704 @ X11_v20-8]);\n\tv710 = v614 == v601;\n\tif (v710) goto L_0102;\n\tv636 = v705 + 1;\n\tv746 = v636 < v602;\n\tv632 = ~v746;\n\tv634 = v704 + 0x10;\n\tv616 = ~v632;\n\tif (v616) goto L_FFFFFFFF;\n\tv637 = v158;\n\tv638 = 0;\n\tv639 = 0x8909C4(v637, v601, v638, v127, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_0109;\nL_0102:\n\tv747 = *([v704 @ X11_v20]);\n\tv748 = v747 << 4;\n\tv749 = v600 + v748;\n\tv750 = v749 + 0x130;\nL_0109:\n\tv508 = System.Collections.Generic.IEnumerator`1<System.Object>::get_Current(v439);\n\tv511 = v508 == 0;\n\tif (v511) goto L_00B3;\n\tv452 = *([v508 @ X0_v50 (System.String)]) != System.String;\n\tif (v452) goto L_00B3;\n\tSystem.Collections.Generic.List`1<System.String>::Add(v281, v508);\n\tgoto L_00B3;\nL_0123:\n\tv606 = v439 == 0;\n\tv607 = ~v606;\n\tif (v607) goto L_014A;\n\tgoto L_0172;\n\tv268 = new System.NullReferenceException();\n\tv277 = new System.NullReferenceException();\nL_012A:\n\tv292 = new System.IndexOutOfRangeException();\n\tgoto L_018B;\n\tv475 = new System.NullReferenceException();\nL_012E:\n\tv360 = new System.NullReferenceException();\n\tgoto L_013C;\n\tgoto L_013C;\n\tgoto L_013C;\n\tgoto L_013C;\nL_013C:\n\tv345 = 0 != 1;\n\tif (v345) goto L_018C;\n\tv569 = Facebook.Unity.Utilities::TryGetValue(v360, 0, 0);\n\tv644 = v569.m_value;\n\tv599 = Facebook.Unity.Utilities::TryGetValue(v569, 0, 0);\n\tv609 = v439 == 0;\n\tif (v609) goto L_0172;\nL_014A:\n\tgoto L_0171;\n\tv715 = *([v664 @ X8_v27+B0]);\n\tv716 = 0;\n\tv717 = v715 + 8;\n\tv719 = *([v765 @ X11_v11-8]);\n\tv771 = v719 == v667;\n\tif (v771) goto L_016A;\n\tv741 = v766 + 1;\n\tv777 = v741 < v666;\n\tv737 = ~v777;\n\tv739 = v765 + 0x10;\n\tv721 = ~v737;\n\tif (v721) goto L_FFFFFFFF;\n\tv742 = v158;\n\tv743 = 0;\n\tv744 = 0x8909C4(v742, v667, v743, v127, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_0171;\nL_016A:\n\tv778 = *([v765 @ X11_v11]);\n\tv779 = v778 << 4;\n\tv780 = v664 + v779;\n\tv781 = v780 + 0x130;\nL_0171:\n\tSystem.IDisposable::Dispose(v439);\nL_0172:\n\tv693 = v85 + 1;\n\tv107 = v693 == 0;\n\tv92 = ~v107;\n\tif (v92) goto L_017C;\n\tv745 = ~v87;\n\tv326 = ~v745;\n\tif (v326) goto L_FFFFFFFF;\nL_017C:\n\tthis.<To>k__BackingField = v281;\nL_0187:\n\treturn;\nL_018B:\n\tv332 = new System.TypeLoadException();\nL_018C:\n\tv219 = Facebook.Unity.Utilities::TryGetValue(v359, v215, v213);\n\treturn;\n// 235 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe AppRequestResult(ResultContainer resultContainer)
		{
			//IL_020b: Expected O, but got I4
			base._002Ector(resultContainer);
			IDictionary<string, object> resultDictionary = base.ResultDictionary;
			if (resultDictionary == null)
			{
				return;
			}
			if (base.ResultDictionary.TryGetValue<string>("request", out var value))
			{
				RequestID = value;
			}
			IDictionary<string, object> resultDictionary2 = base.ResultDictionary;
			if (resultDictionary2.TryGetValue<string>("to", out var value2))
			{
				char[] array = new char[1];
				if (array.Length != 0)
				{
					array[0] = ',';
					To = value2.Split(array);
					return;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				goto IL_03d6;
			}
			if (!base.ResultDictionary.TryGetValue<IEnumerable<object>>("to", out var value3))
			{
				return;
			}
			List<string> list = new List<string>();
			IEnumerator enumerator = value3.GetEnumerator();
			bool flag = enumerator == null;
			ref IEnumerable<object> value4 = ref *(IEnumerable<object>*)null;
			string key = null;
			IDictionary<string, object> dictionary;
			bool flag4;
			int num;
			int num2;
			bool flag7;
			if (flag)
			{
				NullReferenceException ex2 = new NullReferenceException();
				bool flag2 = 0 != 1;
				dictionary = (IDictionary<string, object>)ex2;
				if (flag2)
				{
					goto IL_028e;
				}
				bool flag3 = ((IDictionary<string, object>)ex2).TryGetValue<IEnumerable<object>>(null, out *(IEnumerable<object>*)null);
				flag4 = ((bool*)(flag3 ? 1 : 0))->m_value;
				bool flag5 = ((IDictionary<string, object>)flag3).TryGetValue<IEnumerable<object>>(null, out *(IEnumerable<object>*)null);
				bool flag6 = enumerator == null;
				num = -1;
				num2 = -1;
				flag7 = ((bool*)(flag3 ? 1 : 0))->m_value;
				if (flag6)
				{
					goto IL_03a0;
				}
			}
			else
			{
				while (enumerator.MoveNext())
				{
					string current = (string)((IEnumerator<object>)enumerator).Current;
					if (current != null && (object)current.GetType() == typeof(string))
					{
						list.Add(current);
					}
				}
				bool flag8 = enumerator != null;
				num = 0;
				flag4 = false;
				if (!flag8)
				{
					num2 = 0;
					flag7 = false;
					goto IL_03a0;
				}
			}
			((IDisposable)enumerator).Dispose();
			num2 = num;
			flag7 = flag4;
			goto IL_03a0;
			IL_03a0:
			if (num2 + 1 != 0 || !flag7)
			{
				To = list;
				return;
			}
			goto IL_03d6;
			IL_03d6:
			TypeLoadException ex3 = new TypeLoadException();
			value4 = ref *(IEnumerable<object>*)null;
			key = null;
			dictionary = (IDictionary<string, object>)ex3;
			goto IL_028e;
			IL_028e:
			bool flag9 = dictionary.TryGetValue<IEnumerable<object>>(key, out value4);
		}

		[Token(Token = "0x60000F5")]
		[Address(RVA = "0xD1C7AC", Offset = "0xD1C7AC", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EC2520]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023B59]) = v44;\nL_0017:\n\tv46 = Facebook.Unity.ResultBase::ToString(this);\n\tv50 = System.Object::GetType(this);\n\tv55 = System.Reflection.MemberInfo::get_Name(v50);\n\tv61 = new System.Collections.Generic.Dictionary`2<System.String, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::.ctor(v61);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v61, \"RequestID\", this.<RequestID>k__BackingField);\n\tv104 = this.<To>k__BackingField == 0;\n\tif (v104) goto L_FFFFFFFF;\n\tv116 = Facebook.Unity.Utilities::ToCommaSeparateList(this.<To>k__BackingField);\n\tgoto L_0045;\nL_0045:\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v61, \"To\", v119);\n\treturnVal2 = Facebook.Unity.Utilities::FormatToString(v46, v55, v61);\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			string baseString = base.ToString();
			Type type = GetType();
			string name = type.Name;
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary.Add("RequestID", RequestID);
			string value;
			if (To != null)
			{
				string text = To.ToCommaSeparateList();
				value = text;
			}
			else
			{
				value = null;
			}
			dictionary.Add("To", value);
			return Utilities.FormatToString(baseString, name, dictionary);
		}
	}
}
