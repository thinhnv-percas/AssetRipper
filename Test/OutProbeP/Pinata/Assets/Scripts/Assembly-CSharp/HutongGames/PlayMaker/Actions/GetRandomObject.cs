using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75640C", Offset = "0x75640C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75640C", Offset = "0x75640C")]
	[Token(Token = "0x20001EE")]
	public class GetRandomObject : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B1360", Offset = "0x7B1360")]
		[Token(Token = "0x4001463")]
		[FieldOffset(Offset = "0x50")]
		public FsmString withTag;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B1374", Offset = "0x7B1374")]
		[Token(Token = "0x4001464")]
		[FieldOffset(Offset = "0x58")]
		public FsmGameObject storeResult;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B13B0", Offset = "0x7B13B0")]
		[Token(Token = "0x4001465")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x6000A28")]
		[Address(RVA = "0xA330A8", Offset = "0xA330A8", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EAF9B0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E01]) = v38;\nL_0017:\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"Untagged\");\n\tthis.withTag = v43;\n\tthis.storeResult = 0;\n\tthis.everyFrame = 0;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmString fsmString = "Untagged";
			withTag = fsmString;
			storeResult = null;
			everyFrame = false;
		}

		[Token(Token = "0x6000A29")]
		[Address(RVA = "0xA33104", Offset = "0xA33104", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetRandomObject::DoGetRandomObject(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetRandomObject();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000A2A")]
		[Address(RVA = "0xA332E4", Offset = "0xA332E4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetRandomObject::DoGetRandomObject(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetRandomObject();
		}

		[Token(Token = "0x6000A2B")]
		[Address(RVA = "0xA33140", Offset = "0xA33140", Length = "0x1A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EED878]);\n\tv23 = *([v22 @ X8_v26]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021E02]) = v42;\nL_0019:\n\tv46 = HutongGames.PlayMaker.FsmString::get_Value(this.withTag);\n\tv99 = System.String::op_Inequality(v46, \"Untagged\");\n\tv138 = v99 == 0;\n\tif (v138) goto L_0037;\n\tv181 = HutongGames.PlayMaker.FsmString::get_Value(this.withTag);\n\tv193 = UnityEngine.GameObject::FindGameObjectsWithTag(v181);\n\tv244 = v193 == 0;\n\tv245 = ~v244;\n\tif (v245) goto L_0061;\n\tgoto L_008B;\nL_0037:\n\tgoto L_003F;\n\tv182 = *([v144 @ X0_v22+E0]);\n\tv183 = v182 == 0;\n\tv184 = ~v183;\n\tif (v184) goto L_003F;\n\tv186 = \"il2cpp_codegen_runtime_class_init\"(v144, v83, v80, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_003F:\n\tv191 = System.Type::GetTypeFromHandle(UnityEngine.GameObject);\n\tgoto L_0050;\n\tv246 = *([v197 @ X8_v20+E0]);\n\tv247 = v246 == 0;\n\tv248 = ~v247;\n\tif (v248) goto L_0050;\n\tv262 = v197;\n\tv250 = \"il2cpp_codegen_runtime_class_init\"(v262, v190, v80, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0050:\n\tv254 = UnityEngine.Object::FindObjectsOfType(v191);\n\tv263 = v254 == 0;\n\tif (v263) goto L_FFFFFFFF;\n\t// 89 IsInst v169 @ X0_v30 (UnityEngine.GameObject[]), typeof(UnityEngine.GameObject[]), v254 @ X0_v28 (UnityEngine.Object[])\n\tv171 = v169 == 0;\n\tif (v171) goto L_0093;\nL_0061:\n\tv129 = v135.Length == 0;\n\tif (v129) goto L_FFFFFFFF;\n\tv127 = UnityEngine.Random::Range(0, v135.Length);\n\tv272 = v127 < v135.Length;\n\tv115 = ~v272;\n\tif (v115) goto L_008D;\n\tgoto L_0084;\nL_0084:\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(v232, v230);\n\treturn;\n\tgoto L_0061;\nL_008B:\n\tv85 = new System.NullReferenceException();\n\tv97 = new System.NullReferenceException();\nL_008D:\n\tv136 = new System.IndexOutOfRangeException();\n\tthrow v136;\nL_0093:\n\tthrow System.InvalidCastException;\n// 98 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetRandomObject()
		{
			string value = withTag.Value;
			GameObject[] array2;
			if (value != "Untagged")
			{
				string value2 = withTag.Value;
				GameObject[] array = GameObject.FindGameObjectsWithTag(value2);
				bool flag = array == null;
				bool flag2 = !flag;
				array2 = array;
				if (!flag2)
				{
					NullReferenceException ex = new NullReferenceException();
					NullReferenceException ex2 = new NullReferenceException();
					goto IL_01cd;
				}
			}
			else
			{
				Type typeFromHandle = typeof(GameObject);
				UnityEngine.Object[] array3 = UnityEngine.Object.FindObjectsOfType(typeFromHandle);
				if (array3 != null)
				{
					GameObject[] array4 = array3 as GameObject[];
					if (array4 == null)
					{
						throw new InvalidCastException();
					}
					array2 = array4;
				}
				else
				{
					array2 = null;
				}
			}
			GameObject value3;
			FsmGameObject fsmGameObject;
			if (array2.Length != 0)
			{
				int num = UnityEngine.Random.Range(0, array2.Length);
				if (num >= array2.Length)
				{
					goto IL_01cd;
				}
				value3 = array2[num];
				fsmGameObject = storeResult;
			}
			else
			{
				value3 = null;
				fsmGameObject = storeResult;
			}
			fsmGameObject.Value = value3;
			return;
			IL_01cd:
			IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
			throw ex3;
		}

		[Token(Token = "0x6000A2C")]
		[Address(RVA = "0xA332E8", Offset = "0xA332E8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetRandomObject()
		{
		}
	}
}
