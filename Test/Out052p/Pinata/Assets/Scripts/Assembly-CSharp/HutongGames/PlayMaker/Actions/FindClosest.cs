using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75604C", Offset = "0x75604C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75604C", Offset = "0x75604C")]
	[Token(Token = "0x20001E2")]
	public class FindClosest : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B09CC", Offset = "0x7B09CC")]
		[Token(Token = "0x400143A")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B0A18", Offset = "0x7B0A18")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B0A18", Offset = "0x7B0A18")]
		[Token(Token = "0x400143B")]
		[FieldOffset(Offset = "0x58")]
		public FsmString withTag;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B0A78", Offset = "0x7B0A78")]
		[Token(Token = "0x400143C")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool ignoreOwner;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B0AB0", Offset = "0x7B0AB0")]
		[Token(Token = "0x400143D")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool mustBeVisible;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B0AE8", Offset = "0x7B0AE8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B0AE8", Offset = "0x7B0AE8")]
		[Token(Token = "0x400143E")]
		[FieldOffset(Offset = "0x70")]
		public FsmGameObject storeObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B0B38", Offset = "0x7B0B38")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B0B38", Offset = "0x7B0B38")]
		[Token(Token = "0x400143F")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat storeDistance;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B0B88", Offset = "0x7B0B88")]
		[Token(Token = "0x4001440")]
		[FieldOffset(Offset = "0x80")]
		public bool everyFrame;

		[Token(Token = "0x60009F4")]
		[Address(RVA = "0xB75218", Offset = "0xB75218", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EBD4F8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022923]) = v38;\nL_0013:\n\tthis.gameObject = 0;\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"Untagged\");\n\tthis.withTag = v43;\n\tv46 = HutongGames.PlayMaker.FsmBool::op_Implicit(1);\n\tthis.ignoreOwner = v46;\n\tv49 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.everyFrame = 0;\n\tthis.storeObject = 0;\n\tthis.storeDistance = 0;\n\tthis.mustBeVisible = v49;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmString fsmString = "Untagged";
			withTag = fsmString;
			FsmBool fsmBool = true;
			ignoreOwner = fsmBool;
			FsmBool fsmBool2 = false;
			everyFrame = false;
			storeObject = null;
			storeDistance = null;
			mustBeVisible = fsmBool2;
		}

		[Token(Token = "0x60009F5")]
		[Address(RVA = "0xB7529C", Offset = "0xB7529C", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.FindClosest::DoFindClosest(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoFindClosest();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60009F6")]
		[Address(RVA = "0xB75698", Offset = "0xB75698", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.FindClosest::DoFindClosest(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoFindClosest();
		}

		[Token(Token = "0x60009F7")]
		[Address(RVA = "0xB752D8", Offset = "0xB752D8", Length = "0x3C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv46 = *([1ECB148]);\n\tv47 = *([v46 @ X8_v44]);\n\tv48 = \"il2cpp_codegen_initialize_method\"(v47, methodInfo, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv66 = 0 | 1;\n\t*([2022924]) = v66;\nL_0023:\n\tv69 = this.gameObject;\n\tv72 = v69.ownerOption == 0;\n\tif (v72) goto L_0030;\n\tv333 = HutongGames.PlayMaker.FsmGameObject::get_Value(v69.gameObject);\n\tgoto L_0035;\nL_0030:\n\tv240 = this.owner;\nL_0035:\n\tv384 = HutongGames.PlayMaker.FsmString::get_Value(this.withTag);\n\tv388 = System.String::IsNullOrEmpty(v384);\n\tv437 = v388 == 0;\n\tv438 = ~v437;\n\tif (v438) goto L_0052;\n\tv531 = HutongGames.PlayMaker.FsmString::get_Value(this.withTag);\n\tv441 = System.String::op_Equality(v531, \"Untagged\");\n\tv443 = v441 == 0;\n\tif (v443) goto L_0085;\nL_0052:\n\tgoto L_005A;\n\tv532 = *([v447 @ X0_v53+E0]);\n\tv533 = v532 == 0;\n\tv534 = ~v533;\n\tif (v534) goto L_005A;\n\tv536 = \"il2cpp_codegen_runtime_class_init\"(v447, v439, v202, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63);\nL_005A:\n\tv541 = System.Type::GetTypeFromHandle(UnityEngine.GameObject);\n\tgoto L_006B;\n\tv550 = *([v235 @ X8_v36+E0]);\n\tv551 = v550 == 0;\n\tv552 = ~v551;\n\tif (v552) goto L_006B;\n\tv557 = v235;\n\tv554 = \"il2cpp_codegen_runtime_class_init\"(v557, v540, v202, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63);\nL_006B:\n\tv219 = UnityEngine.Object::FindObjectsOfType(v541);\n\tv558 = v219 == 0;\n\tif (v558) goto L_FFFFFFFF;\n\t// 116 IsInst v218 @ X0_v61 (UnityEngine.GameObject[]), typeof(UnityEngine.GameObject[]), v219 @ X0_v59 (UnityEngine.Object[])\n\tv429 = v218 == 0;\n\tif (v429) goto L_0175;\n\tv584 = v218 == 0;\n\tv225 = ~v584;\n\tif (v225) goto L_008B;\n\tgoto L_016E;\n\tgoto L_008B;\n\tgoto L_016E;\nL_0085:\n\tv560 = HutongGames.PlayMaker.FsmString::get_Value(this.withTag);\n\tv220 = UnityEngine.GameObject::FindGameObjectsWithTag(v560);\nL_008B:\n\tv328 = v200.Length;\n\tv583 = v200.Length < 1;\n\tif (v583) goto L_FFFFFFFF;\nL_00A0:\n\tv635 = v141 < v328;\n\tv186 = ~v635;\n\tif (v186) goto L_016F;\n\tv640 = HutongGames.PlayMaker.FsmBool::get_Value(this.ignoreOwner);\n\tv642 = v640 == 0;\n\tif (v642) goto L_00CC;\n\tgoto L_00C3;\n\tv659 = *([v644 @ X0_v47+E0]);\n\tv660 = v659 == 0;\n\tv661 = ~v660;\n\tif (v661) goto L_00C3;\n\tv663 = \"il2cpp_codegen_runtime_class_init\"(v644, v639, v294, v51, v52, v53, v54, v55, v130, v126, v122, v98, v95, v92, v62, v63);\nL_00C3:\n\tv652 = UnityEngine.Object::op_Equality(v200[v141 @ X25_v8 (System.Int32)], this.owner);\n\tv676 = v652 == 0;\n\tv654 = ~v676;\n\tif (v654) goto L_011B;\nL_00CC:\n\tv667 = HutongGames.PlayMaker.FsmBool::get_Value(this.mustBeVisible);\n\tv678 = v667 == 0;\n\tif (v678) goto L_00DA;\n\tv723 = HutongGames.PlayMaker.ActionHelpers::IsVisible(v200[v141 @ X25_v8 (System.Int32)]);\n\tv725 = v723 == 0;\n\tif (v725) goto L_011B;\nL_00DA:\n\tv222 = UnityEngine.GameObject::get_transform(v240);\n\tv131 = UnityEngine.Transform::get_position(v222);\n\tv312 = UnityEngine.GameObject::get_transform(v200[v141 @ X25_v8 (System.Int32)]);\n\tv739 = UnityEngine.Transform::get_position(v312);\n\tgoto L_0105;\n\tv746 = *([v742 @ X0_v39+E0]);\n\tv747 = v746 == 0;\n\tv748 = ~v747;\n\tif (v748) goto L_0105;\n\tv750 = \"il2cpp_codegen_runtime_class_init\"(v742, v738, v204, v51, v52, v53, v54, v55, v739, v740, v741, v98, v95, v92, v62, v63);\nL_0105:\n\tv699 = UnityEngine.Vector3::op_Subtraction(v131, v739);\n\tv722 = 0x158AB88(&v699 @ V0_v15 (UnityEngine.Vector3), 0, v204, v51, v52, v53, v54, v55, v699, v699.y, v699.z, v739, v739.y, v739.z, v62, v63);\n\tv702 = v699 >= v145;\n\tif (v702) goto L_011B;\nL_011B:\n\tv328 = v200.Length;\n\tv141 = v141 + 1;\n\tv612 = v141 < v200.Length;\n\tif (v612) goto L_00A0;\n\tgoto L_0131;\nL_0131:\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.storeObject, v195);\n\tv643 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.storeDistance);\n\tv657 = v643 == 0;\n\tv658 = ~v657;\n\tif (v658) goto L_016C;\n\tv232 = this.storeDistance;\n\tgoto L_0148;\n\tv679 = *([v670 @ X0_v22 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv680 = v679 == 0;\n\tv681 = ~v680;\n\tif (v681) goto L_0148;\n\tv683 = \"il2cpp_codegen_runtime_class_init\"(v670, v212, v205, v51, v52, v53, v54, v55, v262, v128, v124, v99, v96, v93, v62, v63);\nL_0148:\n\tv685 = UnityEngine.Mathf::Sqrt(v145);\n\tv183 = v685 - v685;\n\tv171 = v685 ^ v685;\n\tv167 = v685 ^ v183;\n\tv163 = v171 & v167;\n\tv159 = v163 < 0;\n\tv155 = ~v159;\n\tif (v155) goto L_0158;\n\tv736 = 0x6D2F50(UnityEngine.Mathf, 0, 0, v51, v52, v53, v54, v55, v145, v699.y, v699.z, v599, v598, v597, v62, v63);\nL_0158:\n\tv232.value = v685;\nL_016C:\n\treturn;\nL_016E:\n\tv331 = new System.NullReferenceException();\nL_016F:\n\tv382 = new System.IndexOutOfRangeException();\n\tthrow v382;\nL_0175:\n\tthrow System.InvalidCastException;\n// 255 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoFindClosest()
		{
			//IL_00dc: Expected O, but got I4
			//IL_01cc: Expected O, but got I4
			//IL_04b5: Expected O, but got F4
			//IL_04c2: Expected O, but got F4
			//IL_0286: Expected O, but got I4
			//IL_028f: Expected O, but got I4
			FsmOwnerDefault fsmOwnerDefault = this.gameObject;
			GameObject gameObject;
			if (fsmOwnerDefault.OwnerOption != OwnerDefaultOption.UseOwner)
			{
				GameObject value = fsmOwnerDefault.GameObject.Value;
				gameObject = value;
			}
			else
			{
				gameObject = Owner;
			}
			string value2 = withTag.Value;
			object obj = default(object);
			GameObject[] array2;
			if (!string.IsNullOrEmpty(value2))
			{
				string value3 = withTag.Value;
				bool flag = value3 == "Untagged";
				bool flag2 = !flag;
				obj = 0;
				if (flag2)
				{
					string value4 = withTag.Value;
					GameObject[] array = GameObject.FindGameObjectsWithTag(value4);
					array2 = array;
					obj = 0;
					goto IL_01d1;
				}
			}
			Type typeFromHandle = typeof(GameObject);
			UnityEngine.Object[] array3 = UnityEngine.Object.FindObjectsOfType(typeFromHandle);
			if (array3 != null)
			{
				GameObject[] array4 = array3 as GameObject[];
				if (array4 == null)
				{
					throw new InvalidCastException();
				}
				bool flag3 = array4 == null;
				bool flag4 = !flag3;
				array2 = array4;
				if (!flag4)
				{
					NullReferenceException ex = new NullReferenceException();
					goto IL_0522;
				}
			}
			else
			{
				array2 = null;
			}
			goto IL_01d1;
			IL_0432:
			GameObject value5;
			storeObject.Value = value5;
			float num2;
			if (!storeDistance.IsNone)
			{
				FsmFloat fsmFloat = storeDistance;
				float num = Mathf.Sqrt(num2);
				float num3 = num - num;
				object obj2 = num ^ num;
				object obj3 = num ^ num3;
				int num4 = (int)((long)(IntPtr)obj2 & (long)(IntPtr)obj3);
				if (num4 < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2F50 (native sqrtf)");
					num = num2;
				}
				fsmFloat.Value = num;
			}
			return;
			IL_01d1:
			int num5 = array2.Length;
			UnityEngine.Object obj4;
			if (array2.Length >= 1)
			{
				int num6 = 0;
				num2 = float.PositiveInfinity;
				obj4 = null;
				while (num6 < num5)
				{
					object obj5;
					if (ignoreOwner.Value)
					{
						bool flag5 = array2[num6] == Owner;
						bool flag6 = !flag5;
						bool flag7 = !flag6;
						obj = 0;
						obj5 = 0;
						if (flag7)
						{
							goto IL_0553;
						}
					}
					if (mustBeVisible.Value)
					{
						bool flag8 = ActionHelpers.IsVisible(array2[num6]);
						bool flag9 = !flag8;
						obj5 = obj;
						if (flag9)
						{
							goto IL_0553;
						}
					}
					Transform transform = gameObject.transform;
					Vector3 position = transform.position;
					Transform transform2 = array2[num6].transform;
					Vector3 position2 = transform2.position;
					Vector3 vector = position - position2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158AB88 (inside UnityEngine.Vector3::Angle +0x184)");
					bool flag10 = !(vector.x < num2);
					float z = position2.z;
					float y = position2.y;
					Vector3 vector2 = position2;
					obj5 = obj;
					if (!flag10)
					{
						z = position2.z;
						y = position2.y;
						vector2 = position2;
						num2 = vector.x;
						obj4 = array2[num6];
						obj5 = obj;
					}
					goto IL_0553;
					IL_0553:
					num5 = array2.Length;
					num6++;
					bool flag11 = num6 < array2.Length;
					obj = obj5;
					if (flag11)
					{
						continue;
					}
					goto IL_0412;
				}
				goto IL_0522;
			}
			num2 = float.PositiveInfinity;
			value5 = null;
			goto IL_0432;
			IL_0522:
			IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
			throw ex2;
			IL_0412:
			value5 = (GameObject)obj4;
			goto IL_0432;
		}

		[Token(Token = "0x60009F8")]
		[Address(RVA = "0xB7569C", Offset = "0xB7569C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FindClosest()
		{
		}
	}
}
