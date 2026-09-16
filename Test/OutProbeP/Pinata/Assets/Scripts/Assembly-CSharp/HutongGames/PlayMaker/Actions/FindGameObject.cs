using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75609C", Offset = "0x75609C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75609C", Offset = "0x75609C")]
	[Token(Token = "0x20001E3")]
	public class FindGameObject : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B0BC0", Offset = "0x7B0BC0")]
		[Token(Token = "0x4001441")]
		[FieldOffset(Offset = "0x50")]
		public FsmString objectName;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B0BF8", Offset = "0x7B0BF8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B0BF8", Offset = "0x7B0BF8")]
		[Token(Token = "0x4001442")]
		[FieldOffset(Offset = "0x58")]
		public FsmString withTag;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B0C48", Offset = "0x7B0C48")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B0C48", Offset = "0x7B0C48")]
		[Token(Token = "0x4001443")]
		[FieldOffset(Offset = "0x60")]
		public FsmGameObject store;

		[Token(Token = "0x60009F9")]
		[Address(RVA = "0xB756A4", Offset = "0xB756A4", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1ECC0B8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022925]) = v38;\nL_0017:\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.objectName = v43;\n\tv48 = HutongGames.PlayMaker.FsmString::op_Implicit(\"Untagged\");\n\tthis.withTag = v48;\n\tthis.store = 0;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmString fsmString = "";
			objectName = fsmString;
			FsmString fsmString2 = "Untagged";
			withTag = fsmString2;
			store = null;
		}

		[Token(Token = "0x60009FA")]
		[Address(RVA = "0xB75714", Offset = "0xB75714", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.FindGameObject::Find(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			Find();
			Finish();
		}

		[Token(Token = "0x60009FB")]
		[Address(RVA = "0xB7573C", Offset = "0xB7573C", Length = "0x1A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv24 = *([1ED81D0]);\n\tv25 = *([v24 @ X8_v17]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022926]) = v44;\nL_001A:\n\tv48 = HutongGames.PlayMaker.FsmString::get_Value(this.withTag);\n\tv153 = System.String::op_Inequality(v48, \"Untagged\");\n\tv184 = v153 == 0;\n\tif (v184) goto L_0039;\n\tv189 = HutongGames.PlayMaker.FsmString::get_Value(this.objectName);\n\tv237 = System.String::IsNullOrEmpty(v189);\n\tv241 = v237 == 0;\n\tif (v241) goto L_0051;\n\tv247 = this.store;\n\tv259 = HutongGames.PlayMaker.FsmString::get_Value(this.withTag);\n\tv244 = UnityEngine.GameObject::FindGameObjectWithTag(v259);\n\tgoto L_FFFFFFFF;\nL_0039:\n\tv247 = this.store;\n\tv192 = HutongGames.PlayMaker.FsmString::get_Value(this.objectName);\n\tv244 = UnityEngine.GameObject::Find(v192);\nL_004B:\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(v226, v224);\n\treturn;\nL_0051:\n\tv261 = HutongGames.PlayMaker.FsmString::get_Value(this.withTag);\n\tv129 = UnityEngine.GameObject::FindGameObjectsWithTag(v261);\n\tv180 = v129.Length;\n\tv281 = v129.Length < 1;\n\tif (v281) goto L_0094;\nL_0065:\n\tv306 = v65 < v180;\n\tv110 = ~v306;\n\tif (v110) goto L_00A0;\n\tv254 = UnityEngine.Object::get_name(v129[v65 @ X23_v8 (System.Int32)]);\n\tv310 = HutongGames.PlayMaker.FsmString::get_Value(this.objectName);\n\tv294 = System.String::op_Equality(v254, v310);\n\tv313 = v294 == 0;\n\tv296 = ~v313;\n\tif (v296) goto L_0099;\n\tv180 = v129.Length;\n\tv65 = v65 + 1;\n\tv284 = v65 < v129.Length;\n\tif (v284) goto L_0065;\nL_0094:\n\tv226 = this.store;\n\tgoto L_004B;\nL_0099:\n\tv226 = this.store;\n\tgoto L_004B;\n\tv151 = new System.NullReferenceException();\nL_00A0:\n\tv182 = new System.IndexOutOfRangeException();\n\tthrow v182;\n\treturn;\n// 116 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Find()
		{
			string value = withTag.Value;
			FsmGameObject fsmGameObject;
			GameObject value5;
			FsmGameObject fsmGameObject2;
			GameObject gameObject;
			if (value != "Untagged")
			{
				string value2 = objectName.Value;
				if (!string.IsNullOrEmpty(value2))
				{
					string value3 = withTag.Value;
					GameObject[] array = GameObject.FindGameObjectsWithTag(value3);
					int num = array.Length;
					if (array.Length < 1)
					{
						goto IL_01ec;
					}
					int num2 = 0;
					while (true)
					{
						if (num2 < num)
						{
							string text = array[num2].name;
							string value4 = objectName.Value;
							if (text == value4)
							{
								break;
							}
							num = array.Length;
							num2++;
							if (num2 < array.Length)
							{
								continue;
							}
							goto IL_01ec;
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex;
					}
					fsmGameObject = store;
					value5 = array[num2];
					goto IL_025f;
				}
				fsmGameObject2 = store;
				string value6 = withTag.Value;
				gameObject = GameObject.FindGameObjectWithTag(value6);
			}
			else
			{
				fsmGameObject2 = store;
				string value7 = objectName.Value;
				gameObject = GameObject.Find(value7);
			}
			value5 = gameObject;
			fsmGameObject = fsmGameObject2;
			goto IL_025f;
			IL_025f:
			fsmGameObject.Value = value5;
			return;
			IL_01ec:
			fsmGameObject = store;
			value5 = null;
			goto IL_025f;
		}

		[Token(Token = "0x60009FC")]
		[Address(RVA = "0xB758E0", Offset = "0xB758E0", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EFDCB8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022927]) = v38;\nL_0017:\n\tv42 = HutongGames.PlayMaker.FsmString::get_Value(this.objectName);\n\tv50 = System.String::IsNullOrEmpty(v42);\n\tv52 = v50 == 0;\n\tif (v52) goto L_FFFFFFFF;\n\tv89 = HutongGames.PlayMaker.FsmString::get_Value(this.withTag);\n\tv100 = System.String::IsNullOrEmpty(v89);\n\tv94 = v100 == 0;\n\tv91 = ~v94;\n\tv90 = ~v91;\n\tif (v90) goto L_FFFFFFFF;\n\tgoto L_0033;\nL_0033:\n\tgoto L_003A;\nL_003A:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ErrorCheck()
		{
			string value = objectName.Value;
			if (string.IsNullOrEmpty(value))
			{
				string value2 = withTag.Value;
				if (string.IsNullOrEmpty(value2))
				{
					return "Specify Name, Tag, or both.";
				}
				return null;
			}
			return null;
		}

		[Token(Token = "0x60009FD")]
		[Address(RVA = "0xB75974", Offset = "0xB75974", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FindGameObject()
		{
		}
	}
}
