using System;
using System.Collections;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7560EC", Offset = "0x7560EC")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7560EC", Offset = "0x7560EC")]
	[Token(Token = "0x20001E4")]
	public class GetChild : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B0CA8", Offset = "0x7B0CA8")]
		[Token(Token = "0x4001444")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B0CF4", Offset = "0x7B0CF4")]
		[Token(Token = "0x4001445")]
		[FieldOffset(Offset = "0x58")]
		public FsmString childName;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B0D2C", Offset = "0x7B0D2C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B0D2C", Offset = "0x7B0D2C")]
		[Token(Token = "0x4001446")]
		[FieldOffset(Offset = "0x60")]
		public FsmString withTag;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B0D7C", Offset = "0x7B0D7C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B0D7C", Offset = "0x7B0D7C")]
		[Token(Token = "0x4001447")]
		[FieldOffset(Offset = "0x68")]
		public FsmGameObject storeResult;

		[Token(Token = "0x60009FE")]
		[Address(RVA = "0xB83A88", Offset = "0xB83A88", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EB2B98]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20229D7]) = v38;\nL_0013:\n\tthis.gameObject = 0;\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.childName = v43;\n\tv48 = HutongGames.PlayMaker.FsmString::op_Implicit(\"Untagged\");\n\tthis.withTag = v48;\n\tthis.storeResult = 0;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmString fsmString = "";
			childName = fsmString;
			FsmString fsmString2 = "Untagged";
			withTag = fsmString2;
			storeResult = null;
		}

		[Token(Token = "0x60009FF")]
		[Address(RVA = "0xB83AFC", Offset = "0xB83AFC", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv58 = HutongGames.PlayMaker.FsmString::get_Value(this.childName);\n\tv90 = HutongGames.PlayMaker.FsmString::get_Value(this.withTag);\n\tv66 = HutongGames.PlayMaker.Actions.GetChild::DoGetChildByName(v21, v58, v90);\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.storeResult, v66);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tv39 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			string value = childName.Value;
			string value2 = withTag.Value;
			GameObject value3 = DoGetChildByName(ownerDefaultTarget, value, value2);
			storeResult.Value = value3;
			Finish();
		}

		[Token(Token = "0x6000A00")]
		[Address(RVA = "0xB83BA0", Offset = "0xB83BA0", Length = "0x488")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv34 = *([1ED1D70]);\n\tv35 = *([v34 @ X8_v45]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, name, tag, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([20229D8]) = v52;\nL_001B:\n\tv53 = &v54 @ stack_-70;\n\tgoto L_002C;\n\tv62 = *([v58 @ X0_v2+E0]);\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tgoto L_002C;\n\tv66 = \"il2cpp_codegen_runtime_class_init\"(v58, name, tag, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_002C:\n\tv72 = UnityEngine.Object::op_Equality(root, 0);\n\tv75 = v72 == 0;\n\tv76 = ~v75;\n\tif (v76) goto L_01C1;\n\tv179 = UnityEngine.GameObject::get_transform(root);\n\tv308 = UnityEngine.Transform::GetEnumerator(v179);\nL_0046:\n\tgoto L_006D;\n\tv461 = *([v429 @ X8_v21+B0]);\n\tv462 = 0;\n\tv463 = v461 + 8;\n\tv465 = *([v502 @ X11_v28-8]);\n\tv507 = v465 == v430;\n\tif (v507) goto L_0066;\n\tv485 = v501 + 1;\n\tv522 = v485 < v431;\n\tv483 = ~v522;\n\tv487 = v502 + 0x10;\n\tv467 = ~v483;\n\tif (v467) goto L_FFFFFFFF;\n\tv488 = v221;\n\tv489 = 0;\n\tv490 = 0x8909C4(v488, v430, v489, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_006D;\nL_0066:\n\tv523 = *([v502 @ X11_v28]);\n\tv524 = v523 << 4;\n\tv525 = v429 + v524;\n\tv526 = v525 + 0x130;\nL_006D:\n\tv547 = System.Collections.IEnumerator::MoveNext(v308);\n\tv549 = v547 == 0;\n\tif (v549) goto L_0116;\n\tv552 = *([v308 @ X0_v40 (System.Collections.IEnumerator)]);\n\tv555 = *([v552 @ X8_v25 (Il2CppClass<System.Collections.IEnumerator>)+126]) == 0;\n\tif (v555) goto L_0093;\n\tv641 = *([v552 @ X8_v25 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_007E:\n\tv646 = *([v641 @ X11_v23-8]) == System.Collections.IEnumerator;\n\tif (v646) goto L_0096;\n\tv640 = v640 + 1;\n\tv652 = v640 < *([v552 @ X8_v25 (Il2CppClass<System.Collections.IEnumerator>)+126]);\n\tv588 = ~v652;\n\tv641 = v641 + 0x10;\n\tv572 = ~v588;\n\tif (v572) goto L_007E;\nL_0093:\n\tv670 = 0x8909C4(v308, System.Collections.IEnumerator, 1, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_009D;\nL_0096:\n\tv654 = *([v641 @ X11_v23]) + 1;\n\tv655 = v654 << 4;\n\tv656 = v552 + v655;\n\tv670 = v656 + 0x130;\nL_009D:\n\t*([v670 @ X0_v45])(v675, v308, *([v670 @ X0_v45+8]), v213, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv676 = v675 == 0;\n\tif (v676) goto L_00C1;\n\tgoto L_FFFFFFFF;\n\tv719 = v719_asT == 0;\n\tif (v719) goto L_012C;\nL_00C1:\n\tv732 = System.String::IsNullOrEmpty(name);\n\tv782 = v732 == 0;\n\tif (v782) goto L_00D3;\n\tv366 = System.String::IsNullOrEmpty(tag);\n\tv818 = v366 == 0;\n\tif (v818) goto L_00F1;\n\tv822 = v675 == 0;\n\tv368 = ~v822;\n\tif (v368) goto L_00FB;\n\tgoto L_0133;\nL_00D3:\n\tv821 = UnityEngine.Object::get_name(v675);\n\tv824 = System.String::op_Equality(v821, name);\n\tv836 = v824 == 0;\n\tif (v836) goto L_00FB;\n\tv850 = System.String::IsNullOrEmpty(tag);\n\tv858 = v850 == 0;\n\tv859 = ~v858;\n\tif (v859) goto L_011A;\n\tv454 = UnityEngine.Component::get_tag(v675);\n\tv456 = v454 == 0;\n\tif (v456) goto L_0136;\n\tv833 = System.String::Equals(v454, tag);\n\tv837 = v833 == 0;\n\tif (v837) goto L_00FB;\n\tgoto L_0124;\nL_00F1:\n\tv843 = UnityEngine.Component::get_tag(v675);\n\tv832 = System.String::op_Equality(v843, tag);\n\tv856 = v832 == 0;\n\tv835 = ~v856;\n\tif (v835) goto L_011F;\nL_00FB:\n\tv840 = UnityEngine.Component::get_gameObject(v675);\n\tv847 = HutongGames.PlayMaker.Actions.GetChild::DoGetChildByName(v840, name, tag);\n\tgoto L_010D;\n\tv860 = *([v851 @ X0_v58+E0]);\n\tv861 = v860 == 0;\n\tv862 = ~v861;\n\tif (v862) goto L_010D;\n\tv864 = \"il2cpp_codegen_runtime_class_init\"(v851, v845, v846, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_010D:\n\tv422 = UnityEngine.Object::op_Inequality(v847, 0);\n\tv424 = v422 == 0;\n\tif (v424) goto L_0046;\n\tgoto L_0129;\nL_0116:\n\t*([v53 @ X23_v1]) = 0xC1;\n\tgoto L_0161;\nL_011A:\n\tv873 = UnityEngine.Component::get_gameObject(v675);\n\tgoto L_0129;\nL_011F:\n\tv869 = UnityEngine.Component::get_gameObject(v675);\n\tgoto L_0129;\nL_0124:\n\tv878 = UnityEngine.Component::get_gameObject(v675);\nL_0129:\n\t*([v53 @ X23_v1]) = 0xC3;\n\tgoto L_0161;\nL_012C:\n\tthrow System.InvalidCastException;\n\tthrow System.NullReferenceException;\n\tv306 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_0133:\n\tthrow System.NullReferenceException;\n\tv402 = new System.NullReferenceException();\nL_0136:\n\tv460 = new System.NullReferenceException();\n\tgoto L_0156;\n\tgoto L_0156;\n\tgoto L_0156;\n\tgoto L_0156;\n\tgoto L_0156;\n\tgoto L_0156;\n\tgoto L_0156;\n\tgoto L_0156;\n\tgoto L_0156;\n\tgoto L_0156;\n\tgoto L_0156;\n\tgoto L_0156;\n\tgoto L_0156;\n\tgoto L_0156;\n\tgoto L_0156;\n\tgoto L_0156;\n\tgoto L_0156;\n\tgoto L_0156;\n\tgoto L_0156;\n\tgoto L_0156;\n\tgoto L_0156;\n\tgoto L_0156;\nL_0156:\n\tv521 = 0 != 1;\n\tif (v521) goto L_01C2;\n\tv550 = 0x6D2BC0(v460, 0, 0, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv157 = *([v550 @ X0_v26]);\n\tv561 = 0x6D2490(v550, 0, 0, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0161:\n\t// 353 IsInst v629 @ X0_v10 (System.IDisposable), typeof(System.IDisposable), v618 @ X19_v4 (System.Collections.IEnumerator)\n\tv651 = v629 == 0;\n\tif (v651) goto L_0191;\n\tgoto L_0190;\n\tv733 = *([v677 @ X8_v9+B0]);\n\tv734 = 0;\n\tv735 = v733 + 8;\n\tv737 = *([v794 @ X11_v8-8]);\n\tv799 = v737 == v678;\n\tif (v799) goto L_0189;\n\tv757 = v793 + 1;\n\tv808 = v757 < v679;\n\tv755 = ~v808;\n\tv759 = v794 + 0x10;\n\tv739 = ~v755;\n\tif (v739) goto L_FFFFFFFF;\n\tv760 = v153;\n\tv761 = 0;\n\tv762 = 0x8909C4(v760, v678, v761, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_0190;\nL_0189:\n\tv809 = *([v794 @ X11_v8]);\n\tv810 = v809 << 4;\n\tv811 = v677 + v810;\n\tv812 = v811 + 0x130;\nL_0190:\n\tSystem.IDisposable::Dispose(v629);\nL_0191:\n\tv150 = v155 + 1;\n\tv113 = v150 == 0;\n\tif (v113) goto L_01B0;\n\tv115 = *([v53 @ X23_v1+v155 @ X21_v4 (System.Int32)*4]) == 0xC3;\n\tif (v115) goto L_01C1;\n\tv151 = v157 == 0;\n\tif (v151) goto L_01C1;\n\tv116 = *([v53 @ X23_v1+v155 @ X21_v4 (System.Int32)*4]) == 0xC1;\n\tif (v116) goto L_01C1;\n\tgoto L_01C6;\nL_01B0:\n\tv764 = v157 == 0;\n\tv149 = ~v764;\n\tif (v149) goto L_01C6;\nL_01C1:\n\treturn v161;\nL_01C2:\n\tv551 = 0x6D2380(v460, 0, 0, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_01C6:\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 262 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static GameObject DoGetChildByName(GameObject root, string name, string tag)
		{
			//IL_03ae: Expected O, but got I4
			//IL_006c: Expected I, but got O
			//IL_00a7: Expected O, but got I
			//IL_012d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0132: Expected O, but got Unknown
			//IL_014f: Expected O, but got I
			//IL_015e: Expected O, but got I
			//IL_00f3: Expected O, but got I
			//IL_05f4: Expected O, but got I4
			//IL_046d: Expected I4, but got O
			object obj2 = default(object);
			object obj = obj2;
			bool flag = root == null;
			bool flag2 = !flag;
			bool flag3 = !flag2;
			GameObject result = null;
			if (!flag3)
			{
				Transform transform = root.transform;
				IEnumerator enumerator = transform.GetEnumerator();
				UnityEngine.Object obj7 = default(UnityEngine.Object);
				object obj8 = default(object);
				while (true)
				{
					int num4;
					if (enumerator.MoveNext())
					{
						IntPtr intPtr = (IntPtr)enumerator;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v552 @ X8_v25 (Il2CppClass<System.Collections.IEnumerator>)+126]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							goto IL_010c;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v552 @ X8_v25 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
						object obj3 = 0L + 8L;
						int num = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v641 @ X11_v23-8]");
							if ((IntPtr)0 == (IntPtr)typeof(IEnumerator))
							{
								break;
							}
							num++;
							int num2 = num;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v552 @ X8_v25 (Il2CppClass<System.Collections.IEnumerator>)+126]");
							bool flag4 = (long)num2 < 0L;
							bool flag5 = !flag4;
							obj3 = (long)(IntPtr)obj3 + 16L;
							if (!flag5)
							{
								continue;
							}
							goto IL_010c;
						}
						object obj4 = obj3 + 1;
						int num3 = (int)((long)(IntPtr)obj4 << 4);
						object obj5 = (long)intPtr + (long)num3;
						object obj6 = (long)(IntPtr)obj5 + 304L;
						num4 = 0;
						goto IL_05bf;
					}
					obj = 193;
					IEnumerator enumerator2 = enumerator;
					int num5 = 0;
					int num6 = 0;
					result = null;
					goto IL_0613;
					IL_0341:
					GameObject root2 = ((Component)obj7).gameObject;
					GameObject gameObject = DoGetChildByName(root2, name, tag);
					if (gameObject != null)
					{
						result = gameObject;
						goto IL_05eb;
					}
					continue;
					IL_05eb:
					obj = 195;
					enumerator2 = enumerator;
					num5 = 0;
					num6 = 0;
					goto IL_0613;
					IL_054b:
					return (GameObject)(object)new TypeLoadException();
					IL_0613:
					(enumerator2 as IDisposable)?.Dispose();
					if (num5 + 1 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X23_v1+v155 @ X21_v4 (System.Int32)*4]");
						if ((IntPtr)0 == (IntPtr)195)
						{
							break;
						}
						bool flag6 = num6 == 0;
						result = null;
						if (flag6)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X23_v1+v155 @ X21_v4 (System.Int32)*4]");
						bool flag7 = (IntPtr)0 == (IntPtr)193;
						result = null;
						if (flag7)
						{
							break;
						}
					}
					else if (num6 == 0)
					{
						result = null;
						break;
					}
					goto IL_054b;
					IL_010c:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
					num4 = 1;
					goto IL_05bf;
					IL_05bf:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v670 @ X0_v45] (should have been resolved before IL gen)");
					if ((object)obj7 != null)
					{
						Transform transform2 = obj7 as Transform;
						if ((object)transform2 == null)
						{
							throw new InvalidCastException();
						}
					}
					if (string.IsNullOrEmpty(name))
					{
						if (string.IsNullOrEmpty(tag))
						{
							if ((object)obj7 == null)
							{
								throw new NullReferenceException();
							}
						}
						else
						{
							string tag2 = ((Component)obj7).tag;
							if (tag2 == tag)
							{
								GameObject gameObject2 = ((Component)obj7).gameObject;
								result = gameObject2;
								goto IL_05eb;
							}
						}
					}
					else
					{
						string text = obj7.name;
						if (text == name)
						{
							if (!string.IsNullOrEmpty(tag))
							{
								string tag3 = ((Component)obj7).tag;
								bool flag8 = tag3 == null;
								enumerator2 = enumerator;
								if (flag8)
								{
									NullReferenceException ex = new NullReferenceException();
									if (0 == 1)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
										num6 = (int)obj8;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
										num5 = -1;
										result = null;
										goto IL_0613;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
									goto IL_054b;
								}
								if (!tag3.Equals(tag))
								{
									goto IL_0341;
								}
								GameObject gameObject3 = ((Component)obj7).gameObject;
								result = gameObject3;
							}
							else
							{
								GameObject gameObject4 = ((Component)obj7).gameObject;
								result = gameObject4;
							}
							goto IL_05eb;
						}
					}
					goto IL_0341;
				}
			}
			return result;
		}

		[Token(Token = "0x6000A01")]
		[Address(RVA = "0xB84028", Offset = "0xB84028", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EC9350]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20229D9]) = v38;\nL_0017:\n\tv42 = HutongGames.PlayMaker.FsmString::get_Value(this.childName);\n\tv50 = System.String::IsNullOrEmpty(v42);\n\tv52 = v50 == 0;\n\tif (v52) goto L_FFFFFFFF;\n\tv89 = HutongGames.PlayMaker.FsmString::get_Value(this.withTag);\n\tv100 = System.String::IsNullOrEmpty(v89);\n\tv94 = v100 == 0;\n\tv91 = ~v94;\n\tv90 = ~v91;\n\tif (v90) goto L_FFFFFFFF;\n\tgoto L_0033;\nL_0033:\n\tgoto L_003A;\nL_003A:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ErrorCheck()
		{
			string value = childName.Value;
			if (string.IsNullOrEmpty(value))
			{
				string value2 = withTag.Value;
				if (string.IsNullOrEmpty(value2))
				{
					return "Specify Child Name, Tag, or both.";
				}
				return null;
			}
			return null;
		}

		[Token(Token = "0x6000A02")]
		[Address(RVA = "0xB840BC", Offset = "0xB840BC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetChild()
		{
		}
	}
}
