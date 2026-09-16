using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile.MiniJSON;
using UnityEngine;

namespace EasyMobile.Internal.Privacy
{
	[Serializable]
	[Token(Token = "0x20000DA")]
	internal class ConsentDialogContentSerializer
	{
		[Serializable]
		[Token(Token = "0x20001BB")]
		internal class SplitContent
		{
			[Token(Token = "0x40006B0")]
			public const string PlainTextType = "plain_text";

			[Token(Token = "0x40006B1")]
			public const string ToggleType = "toggle";

			[Token(Token = "0x40006B2")]
			public const string ButtonType = "button";

			[Token(Token = "0x40006B3")]
			[FieldOffset(Offset = "0x10")]
			public string type;

			[Token(Token = "0x40006B4")]
			[FieldOffset(Offset = "0x18")]
			public string content;

			[Token(Token = "0x6000D04")]
			[Address(RVA = "0xC09668", Offset = "0xC09668", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.type = type;\n\tthis.content = content;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public SplitContent(string type = "", string content = "")
			{
				this.type = type;
				this.content = content;
			}

			[Token(Token = "0x6000D05")]
			[Address(RVA = "0xC096A8", Offset = "0xC096A8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.JsonUtility::ToJson(this);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public override string ToString()
			{
				return JsonUtility.ToJson(this);
			}

			[Token(Token = "0x6000D06")]
			[Address(RVA = "0xC096B0", Offset = "0xC096B0", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EF9F60]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023012]) = v38;\nL_0014:\n\tv40 = ~this.type;\n\tif (v40) goto L_0026;\n\treturnVal2 = System.String::Equals(this.type, \"plain_text\");\n\treturn returnVal2;\nL_0026:\n\treturn this.type;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public bool IsPlainText()
			{
				//IL_0030: Expected I4, but got O
				//IL_0025: Expected I4, but got O
				if ((int)(~type) == 0)
				{
					return type.Equals("plain_text");
				}
				return (byte)(int)type != 0;
			}

			[Token(Token = "0x6000D07")]
			[Address(RVA = "0xC09714", Offset = "0xC09714", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EAE630]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023013]) = v38;\nL_0014:\n\tv40 = ~this.type;\n\tif (v40) goto L_0026;\n\treturnVal2 = System.String::Equals(this.type, \"toggle\");\n\treturn returnVal2;\nL_0026:\n\treturn this.type;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public bool IsToggle()
			{
				//IL_0030: Expected I4, but got O
				//IL_0025: Expected I4, but got O
				if ((int)(~type) == 0)
				{
					return type.Equals("toggle");
				}
				return (byte)(int)type != 0;
			}

			[Token(Token = "0x6000D08")]
			[Address(RVA = "0xC09778", Offset = "0xC09778", Length = "0x1064")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EDFDB0]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023014]) = v38;\nL_0014:\n\tv40 = ~this.type;\n\tif (v40) goto L_0026;\n\treturnVal2 = System.String::Equals(this.type, \"button\");\n\treturn returnVal2;\nL_0026:\n\treturn this.type;\n\tSystem.Globalization.NumberFormatInfo::.ctor(X0, X1);\n\treturn X0;\n\tX0 = *([X8]);\n\tX0 = 0xBF6004(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n\tX1 = *([X8]);\n\tX0 = 0xC09008(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n\tX0 = *([X8]);\n\tX0 = 0xC03008(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n\tX9 = *([X9+8E8]);\n\tX0 = 0xC08004(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n\treturn X0;\n// 1043 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public bool IsButton()
			{
				//IL_0030: Expected I4, but got O
				//IL_0025: Expected I4, but got O
				if ((int)(~type) == 0)
				{
					return type.Equals("button");
				}
				return (byte)(int)type != 0;
			}
		}

		[Token(Token = "0x1700022B")]
		[field: Token(Token = "0x40003CC")]
		[field: FieldOffset(Offset = "0x10")]
		internal string SerializedContent
		{
			[Token(Token = "0x60007B7")]
			[Address(RVA = "0xC09220", Offset = "0xC09220", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<SerializedContent>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60007B8")]
			[Address(RVA = "0xC09228", Offset = "0xC09228", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<SerializedContent>k__BackingField = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x60007B9")]
		[Address(RVA = "0xC09230", Offset = "0xC09230", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EEE4D8]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, consentDialog, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023010]) = v41;\nL_0017:\n\tSystem.Object::.ctor(this);\n\tv44 = consentDialog == 0;\n\tif (v44) goto L_0027;\n\tv46 = EasyMobile.Internal.Privacy.ConsentDialogContentSerializer::GenerateSplitedContents(this, consentDialog);\n\tthis.<SerializedContent>k__BackingField = v46;\n\treturn;\nL_0027:\n\tv50 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v50, \"Tried to pass a null consent dialog into ConsentDialogNativeAdapter's constructor.\");\n\tthrow v50;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal ConsentDialogContentSerializer(ConsentDialog consentDialog)
		{
			if (consentDialog != null)
			{
				SerializedContent = GenerateSplitedContents(consentDialog);
				return;
			}
			throw new ArgumentNullException("Tried to pass a null consent dialog into ConsentDialogNativeAdapter's constructor.");
		}

		[Token(Token = "0x60007BA")]
		[Address(RVA = "0xC092D8", Offset = "0xC092D8", Length = "0x390")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv34 = *([1EE3CF0]);\n\tv35 = *([v34 @ X8_v44]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, consentDialog, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv54 = 0 | 1;\n\t*([2023011]) = v54;\nL_0021:\n\tv61 = new System.Collections.Generic.List`1<EasyMobile.Internal.Privacy.ConsentDialogContentSerializer+SplitContent>();\n\tSystem.Collections.Generic.List`1<EasyMobile.Internal.Privacy.ConsentDialogContentSerializer+SplitContent>::.ctor(v61);\n\tv69 = EasyMobile.ConsentDialog::GetSplittedContents(consentDialog);\n\tv181 = System.Collections.Generic.List`1<System.String>::GetEnumerator(v69);\nL_0043:\n\tv301 = System.Collections.Generic.List`1<System.String>+Enumerator<System.String>::MoveNext(&v131 @ stack_-98_v5 (System.Collections.Generic.List`1<System.String>+Enumerator<System.String>));\n\tv303 = v301 == 0;\n\tif (v303) goto L_00D6;\n\tv280 = System.String::IsNullOrEmpty(v216);\n\tv366 = v280 == 0;\n\tv287 = ~v366;\n\tif (v287) goto L_0043;\n\tgoto L_005B;\n\tv383 = *([v368 @ X0_v27+E0]);\n\tv384 = v383 == 0;\n\tv385 = ~v384;\n\tif (v385) goto L_005B;\n\tv387 = \"il2cpp_codegen_runtime_class_init\"(v368, v273, v104, v38, v39, v40, v41, v42, v128, v44, v45, v46, v47, v48, v49, v50);\nL_005B:\n\tv392 = EasyMobile.ConsentDialog::IsButtonPattern(v216);\n\tv396 = v392 == 0;\n\tif (v396) goto L_008C;\n\tgoto L_006C;\n\tv401 = *([v394 @ X0_v31+E0]);\n\tv402 = v401 == 0;\n\tv403 = ~v402;\n\tif (v403) goto L_006C;\n\tv405 = \"il2cpp_codegen_runtime_class_init\"(v394, v391, v104, v38, v39, v40, v41, v42, v128, v44, v45, v46, v47, v48, v49, v50);\nL_006C:\n\tv409 = EasyMobile.ConsentDialog::SearchForIdInButtonPattern(v216);\n\tv281 = EasyMobile.ConsentDialog::FindButtonWithId(consentDialog, v409);\n\tv288 = v281 == 0;\n\tif (v288) goto L_0043;\n\tv430 = EasyMobile.ConsentDialog+Button::ToString(v281);\n\tv432 = new EasyMobile.Internal.Privacy.ConsentDialogContentSerializer+SplitContent();\n\tSystem.Object::.ctor(v432);\n\tv432.type = \"button\";\n\tv432.content = v430;\n\tSystem.Collections.Generic.List`1<EasyMobile.Internal.Privacy.ConsentDialogContentSerializer+SplitContent>::Add(v61, v432);\n\tgoto L_0043;\nL_008C:\n\tgoto L_0094;\n\tv410 = *([v394 @ X0_v31+E0]);\n\tv411 = v410 == 0;\n\tv412 = ~v411;\n\tif (v412) goto L_0094;\n\tv414 = \"il2cpp_codegen_runtime_class_init\"(v394, v391, v104, v38, v39, v40, v41, v42, v128, v44, v45, v46, v47, v48, v49, v50);\nL_0094:\n\tv418 = EasyMobile.ConsentDialog::IsTogglePattern(v216);\n\tv421 = v418 == 0;\n\tif (v421) goto L_00C3;\n\tgoto L_00A4;\n\tv433 = *([v422 @ X0_v51+E0]);\n\tv434 = v433 == 0;\n\tv435 = ~v434;\n\tif (v435) goto L_00A4;\n\tv437 = \"il2cpp_codegen_runtime_class_init\"(v422, v417, v104, v38, v39, v40, v41, v42, v128, v44, v45, v46, v47, v48, v49, v50);\nL_00A4:\n\tv441 = EasyMobile.ConsentDialog::SearchForIdInTogglePattern(v216);\n\tv283 = EasyMobile.ConsentDialog::FindToggleWithId(consentDialog, v441);\n\tv290 = v283 == 0;\n\tif (v290) goto L_0043;\n\tv463 = EasyMobile.ConsentDialog+Toggle::ToString(v283);\n\tv465 = new EasyMobile.Internal.Privacy.ConsentDialogContentSerializer+SplitContent();\n\tSystem.Object::.ctor(v465);\n\tv465.type = \"toggle\";\n\tv465.content = v463;\n\tv291 = v61 == 0;\n\tif (v291) goto L_00E0;\n\tSystem.Collections.Generic.List`1<EasyMobile.Internal.Privacy.ConsentDialogContentSerializer+SplitContent>::Add(v61, v465);\n\tgoto L_0043;\nL_00C3:\n\tv427 = new EasyMobile.Internal.Privacy.ConsentDialogContentSerializer+SplitContent();\n\tSystem.Object::.ctor(v427);\n\tv427.type = \"plain_text\";\n\tv427.content = v216;\n\tSystem.Collections.Generic.List`1<EasyMobile.Internal.Privacy.ConsentDialogContentSerializer+SplitContent>::Add(v61, v427);\n\tgoto L_0043;\nL_00D6:\n\tv136 = System.Collections.Generic.List`1<System.String>+Enumerator<System.String>::Dispose(&v131 @ stack_-98_v5 (System.Collections.Generic.List`1<System.String>+Enumerator<System.String>));\n\tv367 = v61 == 0;\n\tv139 = ~v367;\n\tif (v139) goto L_010F;\n\tgoto L_0121;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\nL_00E0:\n\tv207 = new System.NullReferenceException();\n\tgoto L_00FC;\n\tgoto L_00FC;\n\tgoto L_00FC;\n\tgoto L_00FC;\n\tgoto L_00FC;\n\tgoto L_00FC;\n\tgoto L_00FC;\n\tgoto L_00FC;\n\tgoto L_00FC;\n\tgoto L_00FC;\n\tgoto L_00FC;\n\tgoto L_00FC;\n\tgoto L_00FC;\n\tgoto L_00FC;\n\tgoto L_00FC;\n\tgoto L_00FC;\n\tgoto L_00FC;\n\tgoto L_00FC;\nL_00FC:\n\tv72 = v205 != 1;\n\tif (v72) goto L_0122;\n\tv472 = 0x6D2BC0(v207, v205, v105, v38, v39, v40, v41, v42, v131, v44, v45, v46, v47, v48, v49, v50);\n\tv473 = 0x6D2490(v472, v205, v105, v38, v39, v40, v41, v42, v131, v44, v45, v46, v47, v48, v49, v50);\n\tv137 = System.Collections.Generic.List`1<System.String>+Enumerator<System.String>::Dispose(&v131 @ stack_-98_v5 (System.Collections.Generic.List`1<System.String>+Enumerator<System.String>));\n\tv476 = *([v472 @ X0_v35]) == 0;\n\tv248 = ~v476;\n\tif (v248) goto L_0126;\nL_010F:\n\tv382 = System.Collections.Generic.List`1<EasyMobile.Internal.Privacy.ConsentDialogContentSerializer+SplitContent>::ToArray(v61);\n\treturnVal2 = EasyMobile.MiniJSON.Json::Serialize(v382);\n\treturn returnVal2;\nL_0121:\n\tv207 = new System.NullReferenceException();\nL_0122:\n\tv214 = 0x6D2380(v207, Il2CppMethodInfo, v105, v38, v39, v40, v41, v42, v131, v44, v45, v46, v47, v48, v49, v50);\nL_0126:\n\treturnVal1 = new System.TypeLoadException();\n\treturn returnVal1;\n// 178 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private string GenerateSplitedContents(ConsentDialog consentDialog)
		{
			List<SplitContent> list = new List<SplitContent>();
			List<string> splittedContents = consentDialog.GetSplittedContents();
			List<string>.Enumerator enumerator = splittedContents.GetEnumerator();
			List<string>.Enumerator enumerator2 = default(List<string>.Enumerator);
			string text = default(string);
			IntPtr intPtr = default(IntPtr);
			object obj = default(object);
			while (true)
			{
				if (enumerator2.MoveNext())
				{
					if (string.IsNullOrEmpty(text))
					{
						continue;
					}
					if (ConsentDialog.IsButtonPattern(text))
					{
						string id = ConsentDialog.SearchForIdInButtonPattern(text);
						ConsentDialog.Button button = consentDialog.FindButtonWithId(id);
						if (button != null)
						{
							string content = button.ToString();
							SplitContent splitContent = null;
							splitContent.type = "button";
							splitContent.content = content;
							list.Add(splitContent);
						}
						continue;
					}
					if (!ConsentDialog.IsTogglePattern(text))
					{
						SplitContent splitContent2 = null;
						splitContent2.type = "plain_text";
						splitContent2.content = text;
						list.Add(splitContent2);
						continue;
					}
					string id2 = ConsentDialog.SearchForIdInTogglePattern(text);
					ConsentDialog.Toggle toggle = consentDialog.FindToggleWithId(id2);
					if (toggle == null)
					{
						continue;
					}
					string content2 = toggle.ToString();
					SplitContent item = new SplitContent("toggle", content2);
					if (list != null)
					{
						list.Add(item);
						continue;
					}
					NullReferenceException ex = new NullReferenceException();
					if (intPtr == (IntPtr)1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
						enumerator2.Dispose();
						if (obj != null)
						{
							break;
						}
						goto IL_02d4;
					}
				}
				else
				{
					enumerator2.Dispose();
					if (list != null)
					{
						goto IL_02d4;
					}
					NullReferenceException ex = new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
				break;
				IL_02d4:
				SplitContent[] obj2 = list.ToArray();
				return Json.Serialize(obj2);
			}
			return (string)(object)new TypeLoadException();
		}

		[Token(Token = "0x60007BB")]
		[Address(RVA = "0xC096A0", Offset = "0xC096A0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.JsonUtility::ToJson(this);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			return JsonUtility.ToJson(this);
		}
	}
}
