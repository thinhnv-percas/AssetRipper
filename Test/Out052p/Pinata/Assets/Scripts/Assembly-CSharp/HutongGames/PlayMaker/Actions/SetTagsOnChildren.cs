using System;
using System.Collections;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7567CC", Offset = "0x7567CC")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7567CC", Offset = "0x7567CC")]
	[Token(Token = "0x20001FA")]
	public class SetTagsOnChildren : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B180C", Offset = "0x7B180C")]
		[Token(Token = "0x4001488")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B1858", Offset = "0x7B1858")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B1858", Offset = "0x7B1858")]
		[Token(Token = "0x4001489")]
		[FieldOffset(Offset = "0x58")]
		public FsmString tag;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B18B8", Offset = "0x7B18B8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B18B8", Offset = "0x7B18B8")]
		[Token(Token = "0x400148A")]
		[FieldOffset(Offset = "0x60")]
		public FsmString filterByComponent;

		[Token(Token = "0x400148B")]
		[FieldOffset(Offset = "0x68")]
		private Type componentFilter;

		[Token(Token = "0x6000A5A")]
		[Address(RVA = "0x999D30", Offset = "0x999D30", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.tag = 0;\n\tthis.filterByComponent = 0;\n\tthis.gameObject = 0;\n\treturn;\n")]
		public override void Reset()
		{
			tag = null;
			filterByComponent = null;
			gameObject = null;
		}

		[Token(Token = "0x6000A5B")]
		[Address(RVA = "0x999D3C", Offset = "0x999D3C", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tHutongGames.PlayMaker.Actions.SetTagsOnChildren::SetTag(this, v14);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			SetTag(ownerDefaultTarget);
			Finish();
		}

		[Token(Token = "0x6000A5C")]
		[Address(RVA = "0x999D84", Offset = "0x999D84", Length = "0x41C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv28 = *([1F0C9B0]);\n\tv29 = *([v28 @ X8_v57]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, parent, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2021797]) = v47;\nL_001E:\n\tgoto L_0027;\n\tv54 = *([v50 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0027;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, parent, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0027:\n\tv64 = UnityEngine.Object::op_Equality(parent, 0);\n\tv66 = v64 == 0;\n\tif (v66) goto L_0039;\n\treturn;\nL_0039:\n\tv146 = HutongGames.PlayMaker.FsmString::get_Value(this.filterByComponent);\n\tv241 = System.String::IsNullOrEmpty(v146);\n\tv272 = v241 == 0;\n\tif (v272) goto L_0157;\n\tv220 = UnityEngine.GameObject::get_transform(parent);\n\tv433 = UnityEngine.Transform::GetEnumerator(v220);\n\tv436 = v433 == 0;\n\tif (v436) goto L_0100;\nL_0053:\n\tgoto L_007A;\n\tv545 = *([v541 @ X8_v33+B0]);\n\tv546 = 0;\n\tv547 = v545 + 8;\n\tv549 = *([v589 @ X11_v29-8]);\n\tv594 = v549 == v542;\n\tif (v594) goto L_0073;\n\tv569 = v588 + 1;\n\tv601 = v569 < v543;\n\tv567 = ~v601;\n\tv571 = v589 + 0x10;\n\tv551 = ~v567;\n\tif (v551) goto L_FFFFFFFF;\n\tv572 = v401;\n\tv573 = 0;\n\tv574 = 0x8909C4(v572, v542, v573, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_007A;\nL_0073:\n\tv602 = *([v589 @ X11_v29]);\n\tv603 = v602 << 4;\n\tv604 = v541 + v603;\n\tv605 = v604 + 0x130;\nL_007A:\n\tv626 = System.Collections.IEnumerator::MoveNext(v433);\n\tv628 = v626 == 0;\n\tif (v628) goto L_FFFFFFFF;\n\tv640 = *([v433 @ X0_v41 (System.Collections.IEnumerator)]);\n\tv643 = *([v640 @ X8_v36 (Il2CppClass<System.Collections.IEnumerator>)+126]) == 0;\n\tif (v643) goto L_00A0;\n\tv712 = *([v640 @ X8_v36 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_008B:\n\tv717 = *([v712 @ X11_v24-8]) == System.Collections.IEnumerator;\n\tif (v717) goto L_00A3;\n\tv711 = v711 + 1;\n\tv723 = v711 < *([v640 @ X8_v36 (Il2CppClass<System.Collections.IEnumerator>)+126]);\n\tv669 = ~v723;\n\tv712 = v712 + 0x10;\n\tv653 = ~v669;\n\tif (v653) goto L_008B;\nL_00A0:\n\tv741 = 0x8909C4(v433, System.Collections.IEnumerator, 1, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_00AA;\nL_00A3:\n\tv725 = *([v712 @ X11_v24]) + 1;\n\tv726 = v725 << 4;\n\tv727 = v640 + v726;\n\tv741 = v727 + 0x130;\nL_00AA:\n\t*([v741 @ X0_v60])(v746, v433, *([v741 @ X0_v60+8]), v496, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_FFFFFFFF;\n\tv866 = v866_asT == 0;\n\tif (v866) goto L_00FA;\n\tgoto L_FFFFFFFF;\n\tv509 = v509_asT == 0;\n\tif (v509) goto L_00FB;\n\tv949 = UnityEngine.Component::get_gameObject(v746);\n\tv934 = HutongGames.PlayMaker.FsmString::get_Value(this.tag);\n\tUnityEngine.GameObject::set_tag(v949, v934);\n\tgoto L_0053;\n\tgoto L_011C;\nL_00FA:\n\tv878 = new System.InvalidCastException();\nL_00FB:\n\tv818 = new System.InvalidCastException();\n\tv821 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tv499 = new System.NullReferenceException();\nL_0100:\n\tv394 = new System.NullReferenceException();\n\tgoto L_0112;\n\tgoto L_0112;\n\tgoto L_0112;\n\tgoto L_0112;\n\tgoto L_0112;\n\tgoto L_0112;\n\tgoto L_0112;\n\tgoto L_0112;\nL_0112:\n\tv362 = 0 != 1;\n\tif (v362) goto L_01C3;\n\tv599 = 0x6D2BC0(v394, 0, 0, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv341 = *([v599 @ X0_v54]);\n\tv630 = 0x6D2490(v599, 0, 0, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_011C:\n\t// 284 IsInst v700 @ X0_v44 (System.IDisposable), typeof(System.IDisposable), v433 @ X0_v41 (System.Collections.IEnumerator)\n\tv722 = v700 == 0;\n\tif (v722) goto L_014C;\n\tgoto L_014B;\n\tv822 = *([v748 @ X8_v27+B0]);\n\tv823 = 0;\n\tv824 = v822 + 8;\n\tv826 = *([v911 @ X11_v15-8]);\n\tv916 = v826 == v749;\n\tif (v916) goto L_0144;\n\tv846 = v910 + 1;\n\tv936 = v846 < v750;\n\tv844 = ~v936;\n\tv848 = v911 + 0x10;\n\tv828 = ~v844;\n\tif (v828) goto L_FFFFFFFF;\n\tv849 = v353;\n\tv850 = 0;\n\tv851 = 0x8909C4(v849, v749, v850, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_014B;\nL_0144:\n\tv937 = *([v911 @ X11_v15]);\n\tv938 = v937 << 4;\n\tv939 = v748 + v938;\n\tv940 = v939 + 0x130;\nL_014B:\n\tSystem.IDisposable::Dispose(v700);\nL_014C:\n\tv463 = v339 + 1;\n\tv333 = v463 == 0;\n\tv328 = ~v333;\n\tif (v328) goto L_01BA;\n\tv852 = v341 == 0;\n\tv349 = ~v852;\n\tif (v349) goto L_01C5;\nL_0157:\n\tHutongGames.PlayMaker.Actions.SetTagsOnChildren::UpdateComponentFilter(this);\n\tgoto L_0168;\n\tv425 = *([v420 @ X0_v26+E0]);\n\tv426 = v425 == 0;\n\tv427 = ~v426;\n\tif (v427) goto L_0168;\n\tv429 = \"il2cpp_codegen_runtime_class_init\"(v420, v344, v342, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0168:\n\tv409 = System.Type::op_Inequality(this.componentFilter, 0);\n\tv435 = v409 == 0;\n\tif (v435) goto L_01BA;\n\tv221 = UnityEngine.GameObject::GetComponentsInChildren(parent, this.componentFilter);\n\tv438 = v221.Length < 1;\n\tif (v438) goto L_01BA;\nL_0193:\n\tv410 = UnityEngine.Component::get_gameObject(v221[v208 @ X22_v11 (System.Int32)]);\n\tv411 = HutongGames.PlayMaker.FsmString::get_Value(this.tag);\n\tUnityEngine.GameObject::set_tag(v410, v411);\n\tv208 = v208 + 1;\n\tv437 = v208 < v221.Length;\n\tif (v437) goto L_0193;\nL_01BA:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tv219 = new System.NullReferenceException();\n\tv239 = new System.NullReferenceException();\n\tv270 = new System.IndexOutOfRangeException();\nL_01C2:\n\tv323 = new System.TypeLoadException();\nL_01C3:\n\tv402 = 0x6D2380(v394, v391, v389, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_01C5:\n\tgoto L_01C2;\n\treturn;\n// 298 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SetTag(GameObject parent)
		{
			//IL_02e4: Expected I4, but got O
			//IL_00c6: Expected I, but got O
			//IL_0101: Expected O, but got I
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			//IL_018c: Expected O, but got Unknown
			//IL_01a9: Expected O, but got I
			//IL_01b8: Expected O, but got I
			//IL_014d: Expected O, but got I
			if (parent == null)
			{
				return;
			}
			string value = filterByComponent.Value;
			int num;
			int num2;
			NullReferenceException ex;
			if (string.IsNullOrEmpty(value))
			{
				Transform transform = parent.transform;
				IEnumerator enumerator = transform.GetEnumerator();
				bool flag = enumerator == null;
				num = 0;
				num2 = 0;
				int num3;
				int num4;
				if (flag)
				{
					ex = new NullReferenceException();
					if (0 != 1)
					{
						goto IL_0442;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
					object obj = default(object);
					num3 = (int)obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
					num4 = -1;
				}
				else
				{
					Component component = default(Component);
					while (enumerator.MoveNext())
					{
						IntPtr intPtr = (IntPtr)enumerator;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ X8_v36 (Il2CppClass<System.Collections.IEnumerator>)+126]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							goto IL_0166;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ X8_v36 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
						object obj2 = 0L + 8L;
						int num5 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v712 @ X11_v24-8]");
							if ((IntPtr)0 == (IntPtr)typeof(IEnumerator))
							{
								break;
							}
							num5++;
							int num6 = num5;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ X8_v36 (Il2CppClass<System.Collections.IEnumerator>)+126]");
							bool flag2 = (long)num6 < 0L;
							bool flag3 = !flag2;
							obj2 = (long)(IntPtr)obj2 + 16L;
							if (!flag3)
							{
								continue;
							}
							goto IL_0166;
						}
						object obj3 = obj2 + 1;
						int num7 = (int)((long)(IntPtr)obj3 << 4);
						object obj4 = (long)intPtr + (long)num7;
						object obj5 = (long)(IntPtr)obj4 + 304L;
						int num8 = 0;
						goto IL_04af;
						IL_0166:
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
						num8 = 1;
						goto IL_04af;
						IL_04af:
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v741 @ X0_v60] (should have been resolved before IL gen)");
						Transform transform2 = component as Transform;
						if ((object)transform2 != null)
						{
							Transform transform3 = component as Transform;
							if ((object)transform3 != null)
							{
								GameObject gameObject = component.gameObject;
								string value2 = tag.Value;
								gameObject.tag = value2;
								continue;
							}
						}
						else
						{
							InvalidCastException ex2 = new InvalidCastException();
						}
						InvalidCastException ex3 = new InvalidCastException();
						NullReferenceException ex4 = new NullReferenceException();
						throw new NullReferenceException();
					}
					num4 = 0;
					num3 = 0;
				}
				(enumerator as IDisposable)?.Dispose();
				if (num4 + 1 != 0)
				{
					goto IL_0413;
				}
				if (num3 != 0)
				{
					goto IL_041a;
				}
			}
			UpdateComponentFilter();
			if (componentFilter != null)
			{
				Component[] componentsInChildren = parent.GetComponentsInChildren(componentFilter);
				if (componentsInChildren.Length >= 1)
				{
					int num9 = 0;
					do
					{
						GameObject gameObject2 = componentsInChildren[num9].gameObject;
						string value3 = tag.Value;
						gameObject2.tag = value3;
						num9++;
					}
					while (num9 < componentsInChildren.Length);
				}
			}
			goto IL_0413;
			IL_041a:
			TypeLoadException ex5 = new TypeLoadException();
			num = 0;
			num2 = 0;
			ex = (NullReferenceException)(object)ex5;
			goto IL_0442;
			IL_0413:
			Finish();
			return;
			IL_0442:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			goto IL_041a;
		}

		[Token(Token = "0x6000A5D")]
		[Address(RVA = "0x99A1A0", Offset = "0x99A1A0", Length = "0x1CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EF6200]);\n\tv23 = *([v22 @ X8_v24]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021798]) = v42;\nL_0019:\n\tv46 = HutongGames.PlayMaker.FsmString::get_Value(this.filterByComponent);\n\tgoto L_002A;\n\tv80 = *([v76 @ X8_v4+E0]);\n\tv81 = v80 == 0;\n\tv82 = ~v81;\n\tif (v82) goto L_002A;\n\tv121 = v76;\n\tv84 = \"il2cpp_codegen_runtime_class_init\"(v121, v45, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_002A:\n\tv88 = HutongGames.PlayMaker.ReflectionUtils::GetGlobalType(v46);\n\tthis.componentFilter = v88;\n\tgoto L_003C;\n\tv127 = *([v123 @ X0_v9+E0]);\n\tv128 = v127 == 0;\n\tv129 = ~v128;\n\tif (v129) goto L_003C;\n\tv131 = \"il2cpp_codegen_runtime_class_init\"(v123, v87, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_003C:\n\tv134 = System.Type::op_Equality(v88, 0);\n\tv136 = v134 == 0;\n\tif (v136) goto L_005E;\n\tv139 = HutongGames.PlayMaker.FsmString::get_Value(this.filterByComponent);\n\tv161 = System.String::Concat(\"UnityEngine.\", v139);\n\tgoto L_005A;\n\tv174 = *([v150 @ X8_v20+E0]);\n\tv175 = v174 == 0;\n\tv176 = ~v175;\n\tif (v176) goto L_005A;\n\tv180 = v150;\n\tv178 = \"il2cpp_codegen_runtime_class_init\"(v180, v158, v141, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_005A:\n\tv146 = HutongGames.PlayMaker.ReflectionUtils::GetGlobalType(v161);\n\tthis.componentFilter = v146;\n\tgoto L_0063;\nL_005E:\n\tv72 = this.componentFilter;\nL_0063:\n\tgoto L_006C;\n\tv162 = *([v152 @ X0_v14+E0]);\n\tv163 = v162 == 0;\n\tv164 = ~v163;\n\tgoto L_006C;\n\tv166 = \"il2cpp_codegen_runtime_class_init\"(v152, v143, v140, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_006C:\n\tv106 = System.Type::op_Equality(v72, 0);\n\tv109 = v106 == 0;\n\tif (v109) goto L_009C;\n\tv182 = HutongGames.PlayMaker.FsmString::get_Value(this.filterByComponent);\n\tv188 = System.String::Concat(\"Couldn't get type: \", v182);\n\tgoto L_0093;\n\tv195 = *([v114 @ X8_v15+E0]);\n\tv196 = v195 == 0;\n\tv197 = ~v196;\n\tif (v197) goto L_0093;\n\tv200 = v114;\n\tv199 = \"il2cpp_codegen_runtime_class_init\"(v200, v185, v93, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0093:\n\tUnityEngine.Debug::LogWarning(v188);\n\treturn;\nL_009C:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 98 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UpdateComponentFilter()
		{
			string value = filterByComponent.Value;
			Type type;
			if ((componentFilter = ReflectionUtils.GetGlobalType(value)) == null)
			{
				string value2 = filterByComponent.Value;
				string typeName = "UnityEngine." + value2;
				type = (componentFilter = ReflectionUtils.GetGlobalType(typeName));
			}
			else
			{
				type = componentFilter;
			}
			if (type == null)
			{
				string value3 = filterByComponent.Value;
				string message = "Couldn't get type: " + value3;
				Debug.LogWarning(message);
			}
		}

		[Token(Token = "0x6000A5E")]
		[Address(RVA = "0x99A36C", Offset = "0x99A36C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetTagsOnChildren()
		{
		}
	}
}
