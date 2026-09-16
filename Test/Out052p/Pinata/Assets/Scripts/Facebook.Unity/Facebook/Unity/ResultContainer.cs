using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Facebook.MiniJSON;

namespace Facebook.Unity
{
	[Token(Token = "0x2000034")]
	internal class ResultContainer
	{
		[Token(Token = "0x400005E")]
		private const string CanvasResponseKey = "response";

		[CompilerGenerated]
		[Token(Token = "0x400005F")]
		[FieldOffset(Offset = "0x10")]
		private string _003CRawResult_003Ek__BackingField;

		[Token(Token = "0x1700004B")]
		public string RawResult
		{
			[CompilerGenerated]
			[Token(Token = "0x600011E")]
			[Address(RVA = "0xD346FC", Offset = "0xD346FC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<RawResult>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RawResult;
			}
			[CompilerGenerated]
			[Token(Token = "0x600011F")]
			[Address(RVA = "0xD34704", Offset = "0xD34704", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<RawResult>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CRawResult_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700004C")]
		public IDictionary<string, object> ResultDictionary
		{
			[CompilerGenerated]
			[Token(Token = "0x6000120")]
			[Address(RVA = "0xD3470C", Offset = "0xD3470C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<ResultDictionary>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ResultDictionary;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000121")]
			[Address(RVA = "0xD34714", Offset = "0xD34714", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<ResultDictionary>k__BackingField = value;\n\treturn;\n")]
			set
			{
				ResultDictionary = value;
			}
		}

		[Token(Token = "0x600011C")]
		[Address(RVA = "0xD1FB34", Offset = "0xD1FB34", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tv16 = Facebook.Unity.Utilities::ToJson(dictionary);\n\tthis.<RawResult>k__BackingField = v16;\n\tthis.<ResultDictionary>k__BackingField = dictionary;\n\tv17 = Facebook.Unity.Constants::get_CurrentPlatform();\n\tv27 = v17 != 3;\n\tif (v27) goto L_0022;\n\tv29 = Facebook.Unity.ResultContainer::GetWebFormattedResponseDictionary(v17, this.<ResultDictionary>k__BackingField);\n\tthis.<ResultDictionary>k__BackingField = v29;\nL_0022:\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ResultContainer(IDictionary<string, object> dictionary)
		{
			//IL_0064: Expected O, but got I4
			base._002Ector();
			string text = dictionary.ToJson();
			RawResult = text;
			ResultDictionary = dictionary;
			FacebookUnityPlatform currentPlatform = Constants.CurrentPlatform;
			if (currentPlatform == FacebookUnityPlatform.WebGL)
			{
				IDictionary<string, object> webFormattedResponseDictionary = ((ResultContainer)currentPlatform).GetWebFormattedResponseDictionary(ResultDictionary);
				ResultDictionary = webFormattedResponseDictionary;
			}
		}

		[Token(Token = "0x600011D")]
		[Address(RVA = "0xD21850", Offset = "0xD21850", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EF1F00]);\n\tv23 = *([v22 @ X8_v24]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, result, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023C99]) = v41;\nL_0017:\n\tSystem.Object::.ctor(this);\n\tthis.<RawResult>k__BackingField = result;\n\tv46 = System.String::IsNullOrEmpty(result);\n\tv48 = v46 == 0;\n\tif (v48) goto L_002C;\n\tv52 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v52);\n\tthis.<ResultDictionary>k__BackingField = v52;\n\tgoto L_007C;\nL_002C:\n\tv55 = Facebook.MiniJSON.Json;\n\tv57 = *([v55 @ X0_v6 (Il2CppClass<Facebook.MiniJSON.Json>)+12F]) & 2;\n\tv58 = v57 == 0;\n\tif (v58) goto L_0034;\n\tv64 = *([v55 @ X0_v6 (Il2CppClass<Facebook.MiniJSON.Json>)+E0]) == 0;\n\tif (v64) goto L_0060;\nL_0034:\n\tv67 = result == 0;\n\tif (v67) goto L_FFFFFFFF;\nL_0037:\n\tv184 = Facebook.MiniJSON.Json+Parser::Parse(result);\n\tv113 = v184 == 0;\n\tif (v113) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tv164 = v164_asT == 0;\n\tif (v164) goto L_FFFFFFFF;\n\tgoto L_005E;\nL_005E:\n\tgoto L_0064;\nL_0060:\n\tv163 = result == 0;\n\tv71 = ~v163;\n\tif (v71) goto L_0037;\nL_0064:\n\tthis.<ResultDictionary>k__BackingField = v157;\n\tv151 = Facebook.Unity.Constants::get_CurrentPlatform();\n\tv124 = v151 != 3;\n\tif (v124) goto L_007C;\n\tv153 = this.<ResultDictionary>k__BackingField == 0;\n\tif (v153) goto L_007C;\n\tv150 = Facebook.Unity.ResultContainer::GetWebFormattedResponseDictionary(v151, this.<ResultDictionary>k__BackingField);\n\tthis.<ResultDictionary>k__BackingField = v150;\nL_007C:\n\treturn;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ResultContainer(string result)
		{
			//IL_0031: Expected I, but got O
			//IL_0184: Expected O, but got I4
			base._002Ector();
			RawResult = result;
			if (string.IsNullOrEmpty(result))
			{
				ResultDictionary = new Dictionary<string, object>();
				return;
			}
			IntPtr intPtr = (IntPtr)typeof(Json);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X0_v6 (Il2CppClass<Facebook.MiniJSON.Json>)+12F]");
			if (0u != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X0_v6 (Il2CppClass<Facebook.MiniJSON.Json>)+E0]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					if (result != null)
					{
						goto IL_00b4;
					}
					goto IL_014c;
				}
			}
			bool flag = result == null;
			object typeFromHandle = typeof(Json);
			if (!flag)
			{
				goto IL_00b4;
			}
			goto IL_014c;
			IL_00b4:
			typeFromHandle = Json.Parser.Parse(result);
			if (typeFromHandle == null)
			{
				goto IL_014c;
			}
			object resultDictionary = ((!(typeFromHandle is Dictionary<string, object>)) ? null : typeFromHandle);
			goto IL_01d7;
			IL_01d7:
			ResultDictionary = (IDictionary<string, object>)resultDictionary;
			FacebookUnityPlatform currentPlatform = Constants.CurrentPlatform;
			if (currentPlatform == FacebookUnityPlatform.WebGL && ResultDictionary != null)
			{
				ResultDictionary = ((ResultContainer)currentPlatform).GetWebFormattedResponseDictionary(ResultDictionary);
			}
			return;
			IL_014c:
			resultDictionary = null;
			goto IL_01d7;
		}

		[Token(Token = "0x6000122")]
		[Address(RVA = "0xD3456C", Offset = "0xD3456C", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1EEBFE8]);\n\tv23 = *([v22 @ X8_v18]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, resultDictionary, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 0 | 1;\n\t*([2023C9A]) = v42;\nL_001E:\n\tv48 = 0;\n\tv53 = Facebook.Unity.Utilities::TryGetValue(resultDictionary, \"response\", &v48 @ stack_-38_v1 (System.Collections.Generic.IDictionary`2<System.String, System.Object>));\n\tv55 = v53 == 0;\n\tif (v55) goto L_0099;\n\tv128 = resultDictionary->klass;\n\tv134 = *([v128 @ X8_v7 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]) == 0;\n\tif (v134) goto L_004C;\n\tv251 = *([v128 @ X8_v7 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]) + 8;\nL_0037:\n\tv256 = *([v251 @ X11_v14-8]) == System.Collections.Generic.IDictionary`2<System.String, System.Object>;\n\tif (v256) goto L_004F;\n\tv250 = v250 + 1;\n\tv261 = v250 < *([v128 @ X8_v7 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]);\n\tv232 = ~v261;\n\tv251 = v251 + 0x10;\n\tv216 = ~v232;\n\tif (v216) goto L_0037;\nL_004C:\n\tv268 = Facebook.Unity.Utilities::TryGetValue(resultDictionary, System.Collections.Generic.IDictionary`2<System.String, System.Object>, 6);\n\tgoto L_0058;\nL_004F:\n\tv263 = *([v251 @ X11_v14]) + 6;\n\tv264 = v263 << 4;\n\tv265 = v128 + v264;\n\tv268 = v265 + 0x130;\nL_0058:\n\tv268.m_value(v173, resultDictionary, \"callback_id\", &v61 @ stack_-40_v4, *([v268 @ X0_v9 (System.Boolean)+8]), v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv271 = v173 & 1;\n\tv272 = v271 == 0;\n\tif (v272) goto L_FFFFFFFF;\n\tv177 = 0;\n\tv296 = *([v177 @ X19_v7 (System.Collections.Generic.IDictionary`2<System.String, System.Object>)]);\n\tv292 = *([v296 @ X8_v11 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]) == 0;\n\tif (v292) goto L_0083;\n\tv340 = *([v296 @ X8_v11 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]) + 8;\nL_006E:\n\tv345 = *([v340 @ X11_v9-8]) == System.Collections.Generic.IDictionary`2<System.String, System.Object>;\n\tif (v345) goto L_0086;\n\tv339 = v339 + 1;\n\tv350 = v339 < *([v296 @ X8_v11 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]);\n\tv321 = ~v350;\n\tv340 = v340 + 0x10;\n\tv305 = ~v321;\n\tif (v305) goto L_006E;\nL_0083:\n\tv357 = 0x8909C4(0, System.Collections.Generic.IDictionary`2<System.String, System.Object>, 1, *([v268 @ X0_v9 (System.Boolean)+8]), v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_008F;\nL_0086:\n\tv352 = *([v340 @ X11_v9]) + 1;\n\tv353 = v352 << 4;\n\tv354 = v296 + v353;\n\tv357 = v354 + 0x130;\nL_008F:\n\t*([v357 @ X0_v13])(v291, 0, \"callback_id\", v61, *([v357 @ X0_v13+8]), v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0099:\n\treturn v114;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 102 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe IDictionary<string, object> GetWebFormattedResponseDictionary(IDictionary<string, object> resultDictionary)
		{
			//IL_000d: Expected I, but got O
			//IL_0048: Expected O, but got I
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dc: Expected O, but got Unknown
			//IL_00f9: Expected O, but got I
			//IL_011f: Expected I, but got O
			//IL_0094: Expected O, but got I
			//IL_015a: Expected O, but got I
			//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dc: Expected O, but got Unknown
			//IL_01f9: Expected O, but got I
			//IL_0208: Expected O, but got I
			//IL_01a6: Expected O, but got I
			IDictionary<string, object> value = null;
			bool flag = resultDictionary.TryGetValue<IDictionary<string, object>>("response", out value);
			bool flag2 = !flag;
			IDictionary<string, object> result = resultDictionary;
			if (flag2)
			{
				goto IL_024d;
			}
			IntPtr intPtr = (IntPtr)resultDictionary;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ X8_v7 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ X8_v7 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ X11_v14-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IDictionary<string, object>))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ X8_v7 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
				bool flag3 = (long)num2 < 0L;
				bool flag4 = !flag3;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag4)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj2 = obj + 6;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			bool flag5 = (byte)((ulong)(long)(IntPtr)obj3 + 304uL) != 0;
			goto IL_027c;
			IL_027c:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v268.m_value (System.Boolean) (should have been resolved before IL gen)");
			object obj4 = default(object);
			if ((uint)((ulong)(long)(IntPtr)obj4 & 1uL) != 0)
			{
				IDictionary<string, object> dictionary = null;
				IntPtr intPtr2 = (IntPtr)dictionary;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ X8_v11 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_01bf;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ X8_v11 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]");
				object obj5 = 0L + 8L;
				int num4 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ X11_v9-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IDictionary<string, object>))
					{
						break;
					}
					num4++;
					int num5 = num4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ X8_v11 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
					bool flag6 = (long)num5 < 0L;
					bool flag7 = !flag6;
					obj5 = (long)(IntPtr)obj5 + 16L;
					if (!flag7)
					{
						continue;
					}
					goto IL_01bf;
				}
				object obj6 = obj5 + 1;
				int num6 = (int)((long)(IntPtr)obj6 << 4);
				object obj7 = (long)intPtr2 + (long)num6;
				object obj8 = (long)(IntPtr)obj7 + 304L;
				goto IL_02dc;
			}
			goto IL_02eb;
			IL_02dc:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v357 @ X0_v13] (should have been resolved before IL gen)");
			goto IL_02eb;
			IL_024d:
			return result;
			IL_01bf:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_02dc;
			IL_02eb:
			result = null;
			goto IL_024d;
			IL_00ad:
			flag5 = resultDictionary.TryGetValue<IDictionary<string, object>>((string)(object)typeof(IDictionary<string, object>), out *(IDictionary<string, object>*)6);
			goto IL_027c;
		}
	}
}
