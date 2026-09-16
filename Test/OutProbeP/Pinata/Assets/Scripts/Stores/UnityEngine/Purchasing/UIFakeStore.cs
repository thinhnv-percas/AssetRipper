using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000091")]
	internal class UIFakeStore : FakeStore
	{
		[Token(Token = "0x2000092")]
		protected class DialogRequest
		{
			[Token(Token = "0x4000214")]
			[FieldOffset(Offset = "0x10")]
			public string QueryText;

			[Token(Token = "0x4000215")]
			[FieldOffset(Offset = "0x18")]
			public string OkayButtonText;

			[Token(Token = "0x4000216")]
			[FieldOffset(Offset = "0x20")]
			public string CancelButtonText;

			[Token(Token = "0x4000217")]
			[FieldOffset(Offset = "0x28")]
			public List<string> Options;

			[Token(Token = "0x4000218")]
			[FieldOffset(Offset = "0x30")]
			public Action<bool, int> Callback;

			[Token(Token = "0x6000263")]
			[Address(RVA = "0x15B38B4", Offset = "0x15B38B4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public DialogRequest()
			{
			}
		}

		[Token(Token = "0x2000093")]
		protected class LifecycleNotifier : MonoBehaviour
		{
			[Token(Token = "0x4000219")]
			[FieldOffset(Offset = "0x18")]
			public Action OnDestroyCallback;

			[Token(Token = "0x6000264")]
			[Address(RVA = "0x15B48FC", Offset = "0x15B48FC", Length = "0x14")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.OnDestroyCallback == 0;\n\tif (v2) goto L_0006;\n\tSystem.Action::Invoke(this.OnDestroyCallback);\n\treturn;\nL_0006:\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private void OnDestroy()
			{
				if (OnDestroyCallback != null)
				{
					OnDestroyCallback();
				}
			}

			[Token(Token = "0x6000265")]
			[Address(RVA = "0x15B4910", Offset = "0x15B4910", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public LifecycleNotifier()
			{
			}
		}

		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000095")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400021B")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400021C")]
			public static Func<ProductDefinition, string> _003C_003E9__18_0;

			[Token(Token = "0x6000268")]
			[Address(RVA = "0x15B4874", Offset = "0x15B4874", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1EC3918]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([20298E5]) = v37;\nL_0015:\n\tv41 = new UnityEngine.Purchasing.UIFakeStore+<>c();\n\tSystem.Object::.ctor(v41);\n\tv45.<>9 = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000269")]
			[Address(RVA = "0x15B48D8", Offset = "0x15B48D8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec()
			{
			}

			internal string _003CCreateRetrieveProductsQuestion_003Eb__18_0(ProductDefinition pid)
			{
				return pid.id;
			}
		}

		[Token(Token = "0x400020E")]
		[FieldOffset(Offset = "0xD0")]
		private DialogRequest m_CurrentDialog;

		[Token(Token = "0x400020F")]
		[FieldOffset(Offset = "0xD8")]
		private int m_LastSelectedDropdownIndex;

		[Token(Token = "0x4000210")]
		[FieldOffset(Offset = "0xE0")]
		private GameObject UIFakeStoreCanvasPrefab;

		[Token(Token = "0x4000211")]
		[FieldOffset(Offset = "0xE8")]
		private Canvas m_Canvas;

		[Token(Token = "0x4000212")]
		[FieldOffset(Offset = "0xF0")]
		private GameObject m_EventSystem;

		[Token(Token = "0x4000213")]
		[FieldOffset(Offset = "0xF8")]
		private string m_ParentGameObjectPath;

		[Token(Token = "0x600024D")]
		[Address(RVA = "0x15B37DC", Offset = "0x15B37DC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Purchasing.FakeStore::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public UIFakeStore()
		{
		}

		[Token(Token = "0x600024E")]
		[Address(RVA = "0xD6C7F8", Offset = "0xD6C7F8", Length = "0x57C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv42 = *([1F04218]);\n\tv43 = *([v42 @ X8_v83]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, model, dialogType, callback, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv58 = 0 | 1;\n\t*([2023F5F]) = v58;\nL_0025:\n\tgoto L_0029;\n\tv65 = v60;\n\tv66 = 0x8907BC(v65, model, dialogType, callback, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_0029:\n\tv69 = new Il2CppClass<UnityEngine.Purchasing.UIFakeStore+<>c__DisplayClass14_0`1<T>>();\n\tv74 = UnityEngine.Purchasing.UIFakeStore+<>c__DisplayClass14_0`1<T>::.ctor(v69);\n\tv69.callback = callback;\n\tv81 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v81);\n\tSystem.Collections.Generic.List`1<System.String>::Add(v81, \"Success\");\n\tgoto L_0057;\n\tv301 = *([v291 @ X0_v21+E0]);\n\tv302 = v301 == 0;\n\tv303 = ~v302;\n\tif (v303) goto L_0057;\n\tv305 = \"il2cpp_codegen_runtime_class_init\"(v291, v275, v276, callback, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_0057:\n\tv310 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tgoto L_0068;\n\tv405 = *([v357 @ X8_v31+E0]);\n\tv406 = v405 == 0;\n\tv407 = ~v406;\n\tif (v407) goto L_0068;\n\tv428 = v357;\n\tv410 = \"il2cpp_codegen_runtime_class_init\"(v428, v309, v276, callback, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_0068:\n\tv414 = System.Enum::GetValues(v310);\n\tv501 = System.Array::GetEnumerator(v414);\n\tv557 = v501 == 0;\n\tif (v557) goto L_010A;\nL_0077:\n\tgoto L_009E;\n\tv644 = *([v628 @ X8_v64+B0]);\n\tv645 = 0;\n\tv646 = v644 + 8;\n\tv648 = *([v703 @ X11_v28-8]);\n\tv708 = v648 == v629;\n\tif (v708) goto L_0097;\n\tv668 = v702 + 1;\n\tv715 = v668 < v630;\n\tv666 = ~v715;\n\tv670 = v703 + 0x10;\n\tv650 = ~v666;\n\tif (v650) goto L_FFFFFFFF;\n\tv671 = v551;\n\tv672 = 0;\n\tv673 = 0x8909C4(v671, v629, v672, callback, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tgoto L_009E;\nL_0097:\n\tv716 = *([v703 @ X11_v28]);\n\tv717 = v716 << 4;\n\tv718 = v628 + v717;\n\tv719 = v718 + 0x130;\nL_009E:\n\tv740 = System.Collections.IEnumerator::MoveNext(v501);\n\tv742 = v740 == 0;\n\tif (v742) goto L_FFFFFFFF;\n\tv744 = *([v501 @ X0_v69 (System.Collections.IEnumerator)]);\n\tv747 = *([v744 @ X8_v67 (Il2CppClass<System.Collections.IEnumerator>)+126]) == 0;\n\tif (v747) goto L_00C4;\n\tv817 = *([v744 @ X8_v67 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_00AF:\n\tv822 = *([v817 @ X11_v23-8]) == System.Collections.IEnumerator;\n\tif (v822) goto L_00C7;\n\tv816 = v816 + 1;\n\tv859 = v816 < *([v744 @ X8_v67 (Il2CppClass<System.Collections.IEnumerator>)+126]);\n\tv797 = ~v859;\n\tv817 = v817 + 0x10;\n\tv781 = ~v797;\n\tif (v781) goto L_00AF;\nL_00C4:\n\tv875 = 0x8909C4(v501, System.Collections.IEnumerator, 1, callback, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tgoto L_00CE;\nL_00C7:\n\tv861 = *([v817 @ X11_v23]) + 1;\n\tv862 = v861 << 4;\n\tv863 = v744 + v862;\n\tv875 = v863 + 0x130;\nL_00CE:\n\t*([v875 @ X0_v74])(v880, v501, *([v875 @ X0_v74+8]), v541, callback, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tgoto L_FFFFFFFF;\n\tv921 = v513;\n\tv922 = 0x8907BC(v921, v878, v541, callback, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv597 = v597_asT == 0;\n\tif (v597) goto L_0108;\n\tv962 = \"il2cpp_vm_object_unbox\"(v880, *([v875 @ X0_v74+8]), v541, callback, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv592 = Il2CppClass<T>;\n\tgoto L_00F5;\n\tv996 = v592;\n\tv997 = 0x8907BC(v996, v878, v541, callback, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_00F5:\n\tv590 = Il2CppClass<T>;\n\t*([v592 @ X26_v15 (Il2CppClass<T>)+160])(v1001, &v590 @ stack_-78_v11 (Il2CppClass<T>), *([v592 @ X26_v15 (Il2CppClass<T>)+168]), v541, callback, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tSystem.Collections.Generic.List`1<System.String>::Add(v81, v1001);\n\tgoto L_0077;\n\tgoto L_0127;\n\tthrow System.NullReferenceException;\nL_0108:\n\tv545 = new System.InvalidCastException();\n\tv556 = new System.NullReferenceException();\nL_010A:\n\tv585 = new System.NullReferenceException();\n\tgoto L_011D;\n\tgoto L_011D;\n\tgoto L_011D;\n\tgoto L_011D;\n\tgoto L_011D;\n\tgoto L_011D;\n\tgoto L_011D;\nL_011D:\n\tv643 = v482 != 1;\n\tif (v643) goto L_0200;\n\tv674 = 0x6D2BC0(v585, v482, v585, callback, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv106 = *([v674 @ X0_v65]);\n\tv714 = 0x6D2490(v674, v482, v585, callback, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_0127:\n\t// 295 IsInst v774 @ X0_v30 (System.IDisposable), typeof(System.IDisposable), v769 @ X25_v10 (System.Collections.IEnumerator)\n\tv805 = v774 == 0;\n\tif (v805) goto L_0157;\n\tgoto L_0156;\n\tv886 = *([v827 @ X8_v55+B0]);\n\tv887 = 0;\n\tv888 = v886 + 8;\n\tv890 = *([v935 @ X11_v12-8]);\n\tv940 = v890 == v828;\n\tif (v940) goto L_014F;\n\tv910 = v934 + 1;\n\tv952 = v910 < v829;\n\tv908 = ~v952;\n\tv912 = v935 + 0x10;\n\tv892 = ~v908;\n\tif (v892) goto L_FFFFFFFF;\n\tv913 = v174;\n\tv914 = 0;\n\tv915 = 0x8909C4(v913, v828, v914, callback, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tgoto L_0156;\nL_014F:\n\tv953 = *([v935 @ X11_v12]);\n\tv954 = v953 << 4;\n\tv955 = v827 + v954;\n\tv956 = v955 + 0x130;\nL_0156:\n\tSystem.IDisposable::Dispose(v774);\nL_0157:\n\tv858 = v691 + 1;\n\tv679 = v858 == 0;\n\tv113 = ~v679;\n\tif (v113) goto L_0164;\n\tv916 = v106 == 0;\n\tv689 = ~v916;\n\tif (v689) goto L_01FF;\nL_0164:\n\tv164 = new System.Action`2<System.Boolean, System.Int32>();\n\tSystem.Action`2<System.Boolean, System.Int32>::.ctor(v164, v69, Il2CppMethodInfo);\n\tv128 = dialogType == 1;\n\tif (v128) goto L_018D;\n\tv965 = dialogType == 0;\n\tv966 = ~v965;\n\tif (v966) goto L_01A2;\n\tv219 = model == 0;\n\tif (v219) goto L_FFFFFFFF;\n\t// 389 IsInst v257 @ X0_v52 (UnityEngine.Purchasing.ProductDefinition), typeof(UnityEngine.Purchasing.ProductDefinition), model @ X1 (System.Object)\n\tv1031 = v257 == 0;\n\tv259 = ~v1031;\n\tif (v259) goto L_01C9;\n\tgoto L_019B;\nL_018D:\n\tv995 = model == 0;\n\tif (v995) goto L_FFFFFFFF;\n\t// 404 IsInst v1012 @ X0_v50 (System.Collections.ObjectModel.ReadOnlyCollection`1<UnityEngine.Purchasing.ProductDefinition>), typeof(System.Collections.ObjectModel.ReadOnlyCollection`1<UnityEngine.Purchasing.ProductDefinition>), model @ X1 (System.Object)\n\tv1025 = v1012 == 0;\n\tv1026 = ~v1025;\n\tif (v1026) goto L_01E0;\nL_019B:\n\tthrow System.InvalidCastException;\nL_01A2:\n\tv89 = UnityEngine.Purchasing.FakeStore+DialogType;\n\tv987 = System.Enum::ToString(&v89 @ stack_-90_v6 (Il2CppClass<UnityEngine.Purchasing.FakeStore+DialogType>));\n\tv994 = System.String::Concat(\"Unrecognized DialogType \", v987);\n\tgoto L_01BE;\n\tv1017 = *([v180 @ X8_v46+E0]);\n\tv1018 = v1017 == 0;\n\tv1019 = ~v1018;\n\tif (v1019) goto L_01BE;\n\tv1032 = v180;\n\tv1021 = \"il2cpp_codegen_runtime_class_init\"(v1032, v990, v991, v95, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_01BE:\n\tUnityEngine.Debug::LogError(v994);\n\tv1033 = this == 0;\n\tv166 = ~v1033;\n\tif (v166) goto L_01EC;\n\tthrow System.NullReferenceException;\nL_01C9:\n\tv270 = UnityEngine.Purchasing.UIFakeStore::CreatePurchaseQuestion(this, v254);\n\tv288 = this.UIMode != 2;\n\tif (v288) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_01E0:\n\tv342 = UnityEngine.Purchasing.UIFakeStore::CreateRetrieveProductsQuestion(this, v1027);\nL_01EC:\n\tv404 = UnityEngine.Purchasing.UIFakeStore::StartUI(this, v388, v384, \"Cancel\", v393, v394);\n\treturn v404;\nL_01FF:\n\tv688 = new System.TypeLoadException();\nL_0200:\n\treturnVal2 = 0x6D2380(v585, v482, v477, callback, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\treturn returnVal2;\n// 328 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override bool StartUI<T>(object model, DialogType dialogType, Action<bool, T> callback)
		{
			//IL_0089: Expected I, but got O
			//IL_02a8: Expected I4, but got O
			//IL_00a7: Expected I, but got O
			//IL_00e2: Expected O, but got I
			//IL_0527: Expected I, but got O
			//IL_016d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0172: Expected O, but got Unknown
			//IL_018f: Expected O, but got I
			//IL_019e: Expected O, but got I
			//IL_012e: Expected O, but got I
			//IL_0442: Expected I, but got O
			//IL_044b: Expected O, but got I
			List<string> list = new List<string>();
			list.Add("Success");
			Type typeFromHandle = typeof(T);
			Array values = Enum.GetValues(typeFromHandle);
			IEnumerator enumerator = values.GetEnumerator();
			bool flag = enumerator == null;
			IntPtr intPtr = (IntPtr)null;
			IEnumerator enumerator2 = enumerator;
			if (flag)
			{
				goto IL_025b;
			}
			object obj5 = default(object);
			string item = default(string);
			while (enumerator.MoveNext())
			{
				IntPtr intPtr2 = (IntPtr)enumerator;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v744 @ X8_v67 (Il2CppClass<System.Collections.IEnumerator>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_0147;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v744 @ X8_v67 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v817 @ X11_v23-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IEnumerator))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v744 @ X8_v67 (Il2CppClass<System.Collections.IEnumerator>)+126]");
					bool flag2 = (long)num2 < 0L;
					bool flag3 = !flag2;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag3)
					{
						continue;
					}
					goto IL_0147;
				}
				object obj2 = obj + 1;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr2 + (long)num3;
				object obj4 = (long)(IntPtr)obj3 + 304L;
				int num4 = 0;
				goto IL_05a1;
				IL_0147:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				num4 = 1;
				goto IL_05a1;
				IL_05a1:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v875 @ X0_v74] (should have been resolved before IL gen)");
				T val = (T)((obj5 is T) ? obj5 : null);
				if (val != null)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					IntPtr intPtr3 = (IntPtr)0;
					IntPtr intPtr4 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v592 @ X26_v15 (Il2CppClass<T>)+160] (should have been resolved before IL gen)");
					list.Add(item);
					continue;
				}
				goto IL_0231;
			}
			int num5 = 0;
			enumerator2 = enumerator;
			int num6 = 0;
			goto IL_05b5;
			IL_0534:
			Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			bool result = default(bool);
			return result;
			IL_05b5:
			(enumerator2 as IDisposable)?.Dispose();
			string okayButtonText;
			string queryText;
			List<string> options;
			Action<bool, int> callback2;
			if (num6 + 1 != 0 || num5 == 0)
			{
				Action<bool, int> action = delegate(bool arg, int codeValue)
				{
					object obj7 = codeValue;
					T val2 = (T)((obj7 is T) ? obj7 : null);
					if (val2 != null)
					{
						Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
						object arg2 = default(object);
						callback(arg, (T)arg2);
						return;
					}
					throw new InvalidCastException();
				};
				string text3;
				if (dialogType != DialogType.RetrieveProducts)
				{
					if (dialogType != DialogType.Purchase)
					{
						IntPtr intPtr5 = (IntPtr)typeof(DialogType);
						string text = ((Enum)(long)intPtr5).ToString();
						string message = "Unrecognized DialogType " + text;
						Debug.LogError(message);
						bool flag4 = this == null;
						bool flag5 = !flag4;
						okayButtonText = null;
						queryText = null;
						options = list;
						callback2 = action;
						if (!flag5)
						{
							throw new NullReferenceException();
						}
						goto IL_0687;
					}
					bool flag6 = model == null;
					List<string> list2 = list;
					Action<bool, int> action2 = action;
					ProductDefinition definition;
					if (!flag6)
					{
						ProductDefinition productDefinition = model as ProductDefinition;
						bool flag7 = productDefinition == null;
						bool flag8 = !flag7;
						definition = productDefinition;
						list2 = list;
						action2 = action;
						if (!flag8)
						{
							goto IL_042e;
						}
					}
					else
					{
						definition = null;
					}
					string text2 = CreatePurchaseQuestion(definition);
					if (UIMode == FakeStoreUIMode.DeveloperUser)
					{
						queryText = text2;
						options = list2;
						callback2 = action2;
						text3 = "OK";
					}
					else
					{
						queryText = text2;
						options = list2;
						callback2 = action2;
						text3 = "Buy";
					}
				}
				else
				{
					ReadOnlyCollection<ProductDefinition> definitions;
					if (model != null)
					{
						ReadOnlyCollection<ProductDefinition> readOnlyCollection = model as ReadOnlyCollection<ProductDefinition>;
						bool flag9 = readOnlyCollection == null;
						bool flag10 = !flag9;
						definitions = readOnlyCollection;
						if (!flag10)
						{
							goto IL_042e;
						}
					}
					else
					{
						definitions = null;
					}
					string text4 = CreateRetrieveProductsQuestion(definitions);
					queryText = text4;
					options = list;
					callback2 = action;
					text3 = "OK";
				}
				okayButtonText = text3;
				goto IL_0687;
			}
			TypeLoadException ex = new TypeLoadException();
			NullReferenceException ex2 = null;
			intPtr = (IntPtr)null;
			NullReferenceException ex3 = (NullReferenceException)(object)ex;
			goto IL_0534;
			IL_042e:
			throw new InvalidCastException();
			IL_0687:
			return StartUI(queryText, okayButtonText, "Cancel", options, callback2);
			IL_0231:
			InvalidCastException ex4 = new InvalidCastException();
			intPtr = (IntPtr)0;
			enumerator2 = enumerator;
			NullReferenceException ex5 = new NullReferenceException();
			goto IL_025b;
			IL_025b:
			ex3 = new NullReferenceException();
			bool flag11 = intPtr != (IntPtr)1;
			ex2 = ex3;
			if (flag11)
			{
				goto IL_0534;
			}
			Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
			object obj6 = default(object);
			num5 = (int)obj6;
			Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
			num6 = -1;
			goto IL_05b5;
		}

		[Token(Token = "0x600024F")]
		[Address(RVA = "0x15B37E4", Offset = "0x15B37E4", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv38 = *([1EECA38]);\n\tv39 = *([v38 @ X8_v9]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, queryText, okayButtonText, cancelButtonText, options, callback, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([20298D7]) = v53;\nL_001E:\n\tv55 = this.m_CurrentDialog == 0;\n\tif (v55) goto L_0025;\n\tgoto L_003E;\nL_0025:\n\tv60 = new UnityEngine.Purchasing.UIFakeStore+DialogRequest();\n\tSystem.Object::.ctor(v60);\n\tv60.QueryText = queryText;\n\tv60.OkayButtonText = okayButtonText;\n\tv60.CancelButtonText = cancelButtonText;\n\tv60.Options = options;\n\tv60.Callback = callback;\n\tthis.m_CurrentDialog = v60;\n\tUnityEngine.Purchasing.UIFakeStore::InstantiateDialog(this);\nL_003E:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool StartUI(string queryText, string okayButtonText, string cancelButtonText, List<string> options, Action<bool, int> callback)
		{
			if (m_CurrentDialog != null)
			{
				return false;
			}
			DialogRequest dialogRequest = new DialogRequest();
			dialogRequest.QueryText = queryText;
			dialogRequest.OkayButtonText = okayButtonText;
			dialogRequest.CancelButtonText = cancelButtonText;
			dialogRequest.Options = options;
			dialogRequest.Callback = callback;
			m_CurrentDialog = dialogRequest;
			InstantiateDialog();
			return true;
		}

		[Token(Token = "0x6000250")]
		[Address(RVA = "0x15B38BC", Offset = "0x15B38BC", Length = "0x700")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv30 = *([1ED1EA0]);\n\tv31 = *([v30 @ X8_v93]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20298D8]) = v50;\nL_001D:\n\tv55 = this.m_CurrentDialog == 0;\n\tif (v55) goto L_0056;\n\tgoto L_002F;\n\tv73 = *([v59 @ X0_v10+E0]);\n\tv74 = v73 == 0;\n\tv75 = ~v74;\n\tif (v75) goto L_002F;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v59, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_002F:\n\tv83 = UnityEngine.Object::op_Equality(this.UIFakeStoreCanvasPrefab, 0);\n\tv92 = v83 == 0;\n\tif (v92) goto L_006E;\n\tv143 = UnityEngine.Resources::Load(\"UIFakeStoreCanvas\");\n\tv110 = v143 == 0;\n\tif (v110) goto L_004D;\n\tv396 = *([v143 @ X0_v130 (UnityEngine.Object)]) != UnityEngine.GameObject;\n\tif (v396) goto L_FFFFFFFF;\n\tgoto L_004D;\nL_004D:\n\tthis.UIFakeStoreCanvasPrefab = v143;\n\tv399 = v143 == 0;\n\tv145 = ~v399;\n\tif (v145) goto L_0074;\n\tgoto L_023F;\nL_0056:\n\tv67 = System.Object::ToString(this);\n\tv72 = System.String::Concat(v67, \" requires m_CurrentDialog. Not showing dialog.\");\n\tgoto L_006C;\n\tv93 = *([v87 @ X8_v10+E0]);\n\tv94 = v93 == 0;\n\tv95 = ~v94;\n\tif (v95) goto L_006C;\n\tv109 = v87;\n\tv98 = \"il2cpp_codegen_runtime_class_init\"(v109, v71, v70, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_006C:\n\tUnityEngine.Debug::LogError(v72);\n\tgoto L_023E;\nL_006E:\n\tv142 = this.UIFakeStoreCanvasPrefab;\nL_0074:\n\tv151 = UnityEngine.GameObject::GetComponent(v142);\n\tgoto L_0085;\n\tv535 = *([v400 @ X8_v19+E0]);\n\tv536 = v535 == 0;\n\tv537 = ~v536;\n\tif (v537) goto L_0085;\n\tv544 = v400;\n\tv539 = \"il2cpp_codegen_runtime_class_init\"(v544, v150, v82, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0085:\n\tv263 = UnityEngine.Object::Instantiate(v151);\n\tthis.m_Canvas = v263;\n\tv264 = UnityEngine.Component::get_gameObject(v263);\n\tv574 = UnityEngine.GameObject::AddComponent(v264);\n\tv441 = new System.Action();\n\tSystem.Action::.ctor(v441, this, Il2CppMethodInfo);\n\tv451 = v574 == 0;\n\tif (v451) goto L_0241;\n\tv574.OnDestroyCallback = v441;\n\tv581 = UnityEngine.Object::get_name(this.m_Canvas);\n\tv586 = System.String::Concat(v581, \"/Panel/\");\n\tthis.m_ParentGameObjectPath = v586;\n\tv590 = UnityEngine.Object::FindObjectOfType();\n\tv592 = UnityEngine.Object::op_Equality(v590, 0);\n\tv594 = v592 == 0;\n\tif (v594) goto L_0108;\n\t// 186 NewArr v599 @ X0_v106 (System.Type[]), typeof(System.Type[]), 1\n\tgoto L_00CE;\n\tv618 = *([v465 @ X8_v73+E0]);\n\tv619 = v618 == 0;\n\tv620 = ~v619;\n\tif (v620) goto L_00CE;\n\tv625 = v465;\n\tv622 = \"il2cpp_codegen_runtime_class_init\"(v625, v597, v428, v187, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_00CE:\n\tv442 = System.Type::GetTypeFromHandle(UnityEngine.EventSystems.EventSystem);\n\tv452 = v599 == 0;\n\tif (v452) goto L_0241;\n\tv628 = v442 == 0;\n\tif (v628) goto L_00DB;\n\t// 215 IsInst v630 @ X0_v121, typeof(System.Type), v442 @ X0_v109 (System.Type)\n\tv567 = v630 == 0;\n\tif (v567) goto L_017B;\nL_00DB:\n\tv636 = v599.Length == 0;\n\tif (v636) goto L_0179;\n\tv599[0] = v442;\n\tv443 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v443, \"EventSystem\", v599);\n\tthis.m_EventSystem = v443;\n\tv453 = v443 == 0;\n\tif (v453) goto L_0241;\n\tv655 = UnityEngine.GameObject::AddComponent(v443);\n\tv444 = UnityEngine.GameObject::get_transform(this.m_EventSystem);\n\tv454 = this.m_Canvas == 0;\n\tif (v454) goto L_0241;\n\tv445 = UnityEngine.Component::get_transform(this.m_Canvas);\n\tv455 = v444 == 0;\n\tif (v455) goto L_0241;\n\tUnityEngine.Transform::set_parent(v444, v445);\nL_0108:\n\tv610 = System.String::Concat(this.m_ParentGameObjectPath, \"HeaderText\");\n\tv267 = UnityEngine.GameObject::Find(v610);\n\tv268 = UnityEngine.GameObject::GetComponent(v267);\n\tv307 = this.m_CurrentDialog;\n\tv456 = this.m_CurrentDialog == 0;\n\tif (v456) goto L_0241;\n\tv230 = *([v268 @ X0_v44 (UnityEngine.UI.Text)]);\n\tv427 = *([v230 @ X9_v14 (Il2CppClass<UnityEngine.UI.Text>)+5C8]);\n\tv650 = UnityEngine.UI.Text::set_text(v268, v307.QueryText);\n\tv269 = UnityEngine.Purchasing.UIFakeStore::GetOkayButtonText(this);\n\tv308 = this.m_CurrentDialog;\n\tv457 = this.m_CurrentDialog == 0;\n\tif (v457) goto L_0241;\n\tv231 = *([v269 @ X0_v47 (UnityEngine.UI.Text)]);\n\tv427 = *([v231 @ X9_v15 (Il2CppClass<UnityEngine.UI.Text>)+5C8]);\n\tv657 = UnityEngine.UI.Text::set_text(v269, v308.OkayButtonText);\n\tv270 = UnityEngine.Purchasing.UIFakeStore::GetCancelButtonText(this);\n\tv309 = this.m_CurrentDialog;\n\tv458 = this.m_CurrentDialog == 0;\n\tif (v458) goto L_0241;\n\tv232 = *([v270 @ X0_v50 (UnityEngine.UI.Text)]);\n\tv427 = *([v232 @ X9_v16 (Il2CppClass<UnityEngine.UI.Text>)+5C8]);\n\tv659 = UnityEngine.UI.Text::set_text(v270, v309.CancelButtonText);\n\tv271 = UnityEngine.Purchasing.UIFakeStore::GetDropdown(this);\n\tv272 = UnityEngine.UI.Dropdown::get_options(v271);\n\tSystem.Collections.Generic.List`1<UnityEngine.UI.Dropdown+OptionData>::Clear(v272);\n\tv311 = this.m_CurrentDialog;\n\tv459 = this.m_CurrentDialog == 0;\n\tif (v459) goto L_0241;\n\tv669 = System.Collections.Generic.List`1<System.String>::GetEnumerator(v311.Options);\nL_0156:\n\tv685 = System.Collections.Generic.List`1<System.String>+Enumerator<System.String>::MoveNext(&v173 @ stack_-88_v6 (System.Collections.Generic.List`1<System.String>+Enumerator<System.String>));\n\tv687 = v685 == 0;\n\tif (v687) goto L_0174;\n\tv689 = UnityEngine.Purchasing.UIFakeStore::GetDropdown(this);\n\tv695 = UnityEngine.UI.Dropdown::get_options(v689);\n\tv698 = new UnityEngine.UI.Dropdown+OptionData();\n\tUnityEngine.UI.Dropdown+OptionData::.ctor(v698, v670);\n\tSystem.Collections.Generic.List`1<UnityEngine.UI.Dropdown+OptionData>::Add(v695, v698);\n\tgoto L_0156;\nL_0174:\n\tv446 = System.Collections.Generic.List`1<System.String>+Enumerator<System.String>::Dispose(&v173 @ stack_-88_v6 (System.Collections.Generic.List`1<System.String>+Enumerator<System.String>));\n\tgoto L_0199;\n\tthrow System.NullReferenceException;\n\tv645 = new System.NullReferenceException();\nL_0179:\n\tv564 = new System.IndexOutOfRangeException();\n\tgoto L_0246;\nL_017B:\n\tv565 = new System.ArrayTypeMismatchException();\n\tgoto L_0246;\n\tgoto L_0183;\n\tgoto L_0183;\n\tgoto L_0183;\n\tgoto L_0183;\n\tgoto L_0183;\n\tgoto L_0183;\nL_0183:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0242;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EA6D58]);\n\tX0 = &stack[20];\n\tX1 = *([X8]);\n\tX0 = 0xEF9AAC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = ~TEMP;\n\t// 408 ConditionalJump @b155, TEMP\nL_0199:\n\tv468 = this.m_CurrentDialog;\n\tv460 = this.m_CurrentDialog == 0;\n\tif (v460) goto L_0241;\n\tv469 = v468.Options;\n\tv461 = v468.Options == 0;\n\tif (v461) goto L_0241;\n\tv154 = v469._size < 1;\n\tif (v154) goto L_01AE;\n\tthis.m_LastSelectedDropdownIndex = 0;\nL_01AE:\n\tv274 = UnityEngine.Purchasing.UIFakeStore::GetDropdown(this);\n\tUnityEngine.UI.Dropdown::RefreshShownValue(v274);\n\tv275 = UnityEngine.Purchasing.UIFakeStore::GetOkayButton(this);\n\tv447 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v447, this, Il2CppMethodInfo);\n\tv462 = v275.m_OnClick == 0;\n\tif (v462) goto L_0241;\n\tUnityEngine.Events.UnityEvent::AddListener(v275.m_OnClick, v447);\n\tv276 = UnityEngine.Purchasing.UIFakeStore::GetCancelButton(this);\n\tv448 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v448, this, Il2CppMethodInfo);\n\tv463 = v276.m_OnClick == 0;\n\tif (v463) goto L_0241;\n\tUnityEngine.Events.UnityEvent::AddListener(v276.m_OnClick, v448);\n\tv277 = UnityEngine.Purchasing.UIFakeStore::GetDropdown(this);\n\tv449 = new UnityEngine.Events.UnityAction`1<System.Int32>();\n\tUnityEngine.Events.UnityAction`1<System.Int32>::.ctor(v449, this, Il2CppMethodInfo);\n\tv367 = v277.m_OnValueChanged == 0;\n\tif (v367) goto L_0241;\n\tUnityEngine.Events.UnityEvent`1<System.Int32>::AddListener(v277.m_OnValueChanged, v449);\n\tv213 = this.UIMode == 2;\n\tif (v213) goto L_021A;\n\tv155 = this.UIMode != 1;\n\tif (\n// ... truncated")]
		private unsafe void InstantiateDialog()
		{
			//IL_040c: Expected O, but got I
			//IL_0422: Expected I, but got O
			//IL_048c: Expected I, but got O
			//IL_04f6: Expected I, but got O
			//IL_02f9: Expected I, but got O
			//IL_0563: Expected O, but got I
			//IL_034b: Expected I, but got O
			//IL_0385: Expected I, but got O
			//IL_0637: Expected O, but got I
			//IL_0674: Expected O, but got I
			IntPtr intPtr;
			object obj2;
			if (m_CurrentDialog != null)
			{
				GameObject gameObject;
				if (UIFakeStoreCanvasPrefab == null)
				{
					Object obj = Resources.Load("UIFakeStoreCanvas");
					if ((object)obj != null && (object)obj.GetType() != typeof(GameObject))
					{
						obj = null;
					}
					UIFakeStoreCanvasPrefab = (GameObject)obj;
					bool flag = (object)obj == null;
					bool flag2 = !flag;
					gameObject = (GameObject)obj;
					if (!flag2)
					{
						intPtr = default(IntPtr);
						obj2 = null;
						throw new NullReferenceException();
					}
				}
				else
				{
					gameObject = UIFakeStoreCanvasPrefab;
				}
				Canvas component = gameObject.GetComponent<Canvas>();
				GameObject gameObject2 = (m_Canvas = Object.Instantiate(component)).gameObject;
				LifecycleNotifier lifecycleNotifier = gameObject2.AddComponent<LifecycleNotifier>();
				Action onDestroyCallback = delegate
				{
					m_CurrentDialog = null;
				};
				bool flag3 = (object)lifecycleNotifier == null;
				intPtr = (IntPtr)__ldftn(UIFakeStore._003CInstantiateDialog_003Eb__16_0);
				obj2 = this;
				if (!flag3)
				{
					lifecycleNotifier.OnDestroyCallback = onDestroyCallback;
					string name = m_Canvas.name;
					string parentGameObjectPath = name + "/Panel/";
					m_ParentGameObjectPath = parentGameObjectPath;
					EventSystem eventSystem = Object.FindObjectOfType<EventSystem>();
					if (!(eventSystem == null))
					{
						goto IL_03ae;
					}
					Type[] array = new Type[1];
					Type typeFromHandle = typeof(EventSystem);
					bool flag4 = array == null;
					intPtr = default(IntPtr);
					obj2 = null;
					if (!flag4)
					{
						if ((object)typeFromHandle != null)
						{
							object obj3 = typeFromHandle as Type;
							if (obj3 == null)
							{
								ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
								goto IL_094a;
							}
						}
						if (array.Length == 0)
						{
							IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
							goto IL_094a;
						}
						array[0] = typeFromHandle;
						GameObject gameObject3 = (m_EventSystem = new GameObject("EventSystem", array));
						bool flag5 = (object)gameObject3 == null;
						intPtr = (IntPtr)array;
						obj2 = "EventSystem";
						if (!flag5)
						{
							StandaloneInputModule standaloneInputModule = gameObject3.AddComponent<StandaloneInputModule>();
							Transform transform = m_EventSystem.transform;
							bool flag6 = (object)m_Canvas == null;
							intPtr = (IntPtr)array;
							obj2 = null;
							if (!flag6)
							{
								Transform transform2 = m_Canvas.transform;
								bool flag7 = (object)transform == null;
								intPtr = (IntPtr)array;
								obj2 = transform2;
								if (!flag7)
								{
									transform.parent = transform2;
									goto IL_03ae;
								}
							}
						}
					}
				}
				goto IL_08b0;
			}
			string text = base.ToString();
			string message = text + " requires m_CurrentDialog. Not showing dialog.";
			Debug.LogError(message);
			return;
			IL_08b0:
			NullReferenceException ex3 = (NullReferenceException)(object)new UnityAction<int>(obj2, intPtr);
			goto IL_094a;
			IL_094a:
			throw new TypeLoadException();
			IL_03ae:
			string name2 = m_ParentGameObjectPath + "HeaderText";
			GameObject gameObject4 = GameObject.Find(name2);
			Text component2 = gameObject4.GetComponent<Text>();
			DialogRequest currentDialog = m_CurrentDialog;
			bool flag8 = m_CurrentDialog == null;
			intPtr = default(IntPtr);
			obj2 = 0;
			if (!flag8)
			{
				IntPtr intPtr2 = (IntPtr)component2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ X9_v14 (Il2CppClass<UnityEngine.UI.Text>)+5C8]");
				intPtr = (IntPtr)0;
				component2.text = currentDialog.QueryText;
				Text okayButtonText = GetOkayButtonText();
				DialogRequest currentDialog2 = m_CurrentDialog;
				bool flag9 = m_CurrentDialog == null;
				obj2 = currentDialog.QueryText;
				if (!flag9)
				{
					IntPtr intPtr3 = (IntPtr)okayButtonText;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ X9_v15 (Il2CppClass<UnityEngine.UI.Text>)+5C8]");
					intPtr = (IntPtr)0;
					okayButtonText.text = currentDialog2.OkayButtonText;
					Text cancelButtonText = GetCancelButtonText();
					DialogRequest currentDialog3 = m_CurrentDialog;
					bool flag10 = m_CurrentDialog == null;
					obj2 = currentDialog2.OkayButtonText;
					if (!flag10)
					{
						IntPtr intPtr4 = (IntPtr)cancelButtonText;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ X9_v16 (Il2CppClass<UnityEngine.UI.Text>)+5C8]");
						intPtr = (IntPtr)0;
						cancelButtonText.text = currentDialog3.CancelButtonText;
						Dropdown dropdown = GetDropdown();
						List<Dropdown.OptionData> options = dropdown.options;
						options.Clear();
						DialogRequest currentDialog4 = m_CurrentDialog;
						bool flag11 = m_CurrentDialog == null;
						obj2 = 0;
						if (!flag11)
						{
							List<string>.Enumerator enumerator = currentDialog4.Options.GetEnumerator();
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ X9_v16 (Il2CppClass<UnityEngine.UI.Text>)+5C8]");
							IntPtr intPtr5 = (IntPtr)0;
							List<string>.Enumerator enumerator2 = default(List<string>.Enumerator);
							string text2 = default(string);
							while (enumerator2.MoveNext())
							{
								Dropdown dropdown2 = GetDropdown();
								List<Dropdown.OptionData> options2 = dropdown2.options;
								Dropdown.OptionData item = new Dropdown.OptionData(text2);
								options2.Add(item);
								intPtr5 = (IntPtr)0;
							}
							enumerator2.Dispose();
							DialogRequest currentDialog5 = m_CurrentDialog;
							bool flag12 = m_CurrentDialog == null;
							intPtr = intPtr5;
							obj2 = 0;
							if (!flag12)
							{
								List<string> options3 = currentDialog5.Options;
								bool flag13 = currentDialog5.Options == null;
								intPtr = intPtr5;
								obj2 = 0;
								if (!flag13)
								{
									if (options3.Count >= 1)
									{
										m_LastSelectedDropdownIndex = 0;
									}
									Dropdown dropdown3 = GetDropdown();
									dropdown3.RefreshShownValue();
									Button okayButton = GetOkayButton();
									UnityAction call = delegate
									{
										OkayButtonClicked();
									};
									bool flag14 = okayButton.onClick == null;
									intPtr = (IntPtr)__ldftn(UIFakeStore._003CInstantiateDialog_003Eb__16_1);
									obj2 = this;
									if (!flag14)
									{
										okayButton.onClick.AddListener(call);
										Button cancelButton = GetCancelButton();
										UnityAction call2 = delegate
										{
											CancelButtonClicked();
										};
										bool flag15 = cancelButton.onClick == null;
										intPtr = (IntPtr)__ldftn(UIFakeStore._003CInstantiateDialog_003Eb__16_2);
										obj2 = this;
										if (!flag15)
										{
											cancelButton.onClick.AddListener(call2);
											Dropdown dropdown4 = GetDropdown();
											UnityAction<int> call3 = delegate(int selectedItem)
											{
												m_LastSelectedDropdownIndex = selectedItem;
											};
											bool flag16 = dropdown4.onValueChanged == null;
											intPtr = (IntPtr)__ldftn(UIFakeStore._003CInstantiateDialog_003Eb__16_3);
											obj2 = this;
											if (!flag16)
											{
												dropdown4.onValueChanged.AddListener(call3);
												GameObject obj4;
												if (UIMode != FakeStoreUIMode.DeveloperUser)
												{
													if (UIMode != FakeStoreUIMode.StandardUser)
													{
														return;
													}
													Dropdown dropdown5 = GetDropdown();
													dropdown5.onValueChanged.RemoveAllListeners();
													obj4 = GetDropdownContainerGameObject();
												}
												else
												{
													Button cancelButton2 = GetCancelButton();
													cancelButton2.onClick.RemoveAllListeners();
													obj4 = GetCancelButtonGameObject();
												}
												Object.Destroy(obj4);
												return;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			goto IL_08b0;
		}

		[Token(Token = "0x6000251")]
		[Address(RVA = "0x15B4358", Offset = "0x15B4358", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv18 = *([1F0F3F0]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, definition, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([20298D9]) = v38;\nL_0022:\n\treturnVal1 = System.String::Concat(\"Do you want to Purchase \", definition.<id>k__BackingField, \"?\\n\\n[Environment: FakeStore]\");\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private string CreatePurchaseQuestion(ProductDefinition definition)
		{
			return "Do you want to Purchase " + definition.id + "?\n\n[Environment: FakeStore]";
		}

		[Token(Token = "0x6000252")]
		[Address(RVA = "0x15B43C4", Offset = "0x15B43C4", Length = "0x1C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv28 = *([1EFA768]);\n\tv29 = *([v28 @ X8_v30]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, definitions, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv48 = 0 | 1;\n\t*([20298DA]) = v48;\nL_0020:\n\tv57 = System.Linq.Enumerable::Take(definitions, 2);\n\tgoto L_0032;\n\tv65 = *([v61 @ X8_v5 (Il2CppClass<UnityEngine.Purchasing.UIFakeStore+<>c>)+E0]);\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\tgoto L_0032;\n\tv81 = v61;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v81, v53, v56, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv73 = UnityEngine.Purchasing.UIFakeStore+<>c;\nL_0032:\n\tv91 = v74.<>9__18_0;\n\tv79 = v74.<>9__18_0 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_005A;\n\tgoto L_0048;\n\tv111 = *([v72 @ X8_v6 (Il2CppClass<UnityEngine.Purchasing.UIFakeStore+<>c>)+E0]);\n\tv112 = v111 == 0;\n\tv113 = ~v112;\n\tif (v113) goto L_0048;\n\tv127 = v72;\n\tv117 = \"il2cpp_codegen_runtime_class_init\"(v127, v53, v56, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv119 = UnityEngine.Purchasing.UIFakeStore+<>c;\n\tv115 = *([v119 @ X8_v27+B8]);\nL_0048:\n\tv100 = new System.Func`2<UnityEngine.Purchasing.ProductDefinition, System.String>();\n\tSystem.Func`2<UnityEngine.Purchasing.ProductDefinition, System.String>::.ctor(v100, v114.<>9, Il2CppMethodInfo);\n\tv104.<>9__18_0 = v100;\nL_005A:\n\tv110 = System.Linq.Enumerable::Select(v57, v91);\n\tv126 = System.Linq.Enumerable::ToArray(v110);\n\tv134 = System.String::Join(\", \", v126);\n\tv139 = System.String::Concat(\"Do you want to initialize purchasing for products {\", v134);\n\tv146 = System.Collections.ObjectModel.ReadOnlyCollection`1<UnityEngine.Purchasing.ProductDefinition>::get_Count(definitions);\n\tv159 = v146 < 3;\n\tif (v159) goto L_0091;\n\tv165 = System.String::Concat(v139, \", ...\");\nL_0091:\n\treturnVal2 = System.String::Concat(v170, \"}?\\n\\n[Environment: FakeStore]\");\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 107 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private string CreateRetrieveProductsQuestion(ReadOnlyCollection<ProductDefinition> definitions)
		{
			IEnumerable<ProductDefinition> source = definitions.Take(2);
			Func<ProductDefinition, string> selector = _003C_003Ec._003C_003E9__18_0;
			if (_003C_003Ec._003C_003E9__18_0 == null)
			{
				selector = (_003C_003Ec._003C_003E9__18_0 = (ProductDefinition pid) => pid.id);
			}
			IEnumerable<string> source2 = source.Select(selector);
			string[] value = source2.ToArray();
			string text = string.Join(", ", value);
			string text2 = "Do you want to initialize purchasing for products {" + text;
			int count = definitions.Count;
			bool flag = count < 3;
			string text3 = text2;
			if (!flag)
			{
				string text4 = text2 + ", ...";
				text3 = text4;
			}
			return text3 + "}?\n\n[Environment: FakeStore]";
		}

		[Token(Token = "0x6000253")]
		[Address(RVA = "0x15B4168", Offset = "0x15B4168", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EE2588]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20298DB]) = v38;\nL_0018:\n\tv44 = System.String::Concat(this.m_ParentGameObjectPath, \"Button1\");\n\tv46 = UnityEngine.GameObject::Find(v44);\n\treturnVal1 = UnityEngine.GameObject::GetComponent(v46);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private Button GetOkayButton()
		{
			string name = m_ParentGameObjectPath + "Button1";
			GameObject gameObject = GameObject.Find(name);
			return gameObject.GetComponent<Button>();
		}

		[Token(Token = "0x6000254")]
		[Address(RVA = "0x15B41DC", Offset = "0x15B41DC", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1F04588]);\n\tv19 = *([v18 @ X8_v14]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20298DC]) = v38;\nL_0018:\n\tv44 = System.String::Concat(this.m_ParentGameObjectPath, \"Button2\");\n\tv46 = UnityEngine.GameObject::Find(v44);\n\tgoto L_002C;\n\tv54 = *([v50 @ X8_v7+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_002C;\n\tv65 = v50;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v65, v45, v42, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002C:\n\tv64 = UnityEngine.Object::op_Inequality(v46, 0);\n\tv69 = v64 == 0;\n\tif (v69) goto L_003E;\n\treturnVal1 = UnityEngine.GameObject::GetComponent(v46);\nL_003E:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private Button GetCancelButton()
		{
			string name = m_ParentGameObjectPath + "Button2";
			GameObject gameObject = GameObject.Find(name);
			bool flag = gameObject != null;
			bool flag2 = !flag;
			Button result = null;
			if (!flag2)
			{
				result = gameObject.GetComponent<Button>();
			}
			return result;
		}

		[Token(Token = "0x6000255")]
		[Address(RVA = "0x15B42FC", Offset = "0x15B42FC", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EE5E38]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20298DD]) = v38;\nL_0018:\n\tv44 = System.String::Concat(this.m_ParentGameObjectPath, \"Button2\");\n\treturnVal1 = UnityEngine.GameObject::Find(v44);\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private GameObject GetCancelButtonGameObject()
		{
			string name = m_ParentGameObjectPath + "Button2";
			return GameObject.Find(name);
		}

		[Token(Token = "0x6000256")]
		[Address(RVA = "0x15B3FBC", Offset = "0x15B3FBC", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EBF628]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20298DE]) = v38;\nL_0018:\n\tv44 = System.String::Concat(this.m_ParentGameObjectPath, \"Button1/Text\");\n\tv46 = UnityEngine.GameObject::Find(v44);\n\treturnVal1 = UnityEngine.GameObject::GetComponent(v46);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private Text GetOkayButtonText()
		{
			string name = m_ParentGameObjectPath + "Button1/Text";
			GameObject gameObject = GameObject.Find(name);
			return gameObject.GetComponent<Text>();
		}

		[Token(Token = "0x6000257")]
		[Address(RVA = "0x15B4030", Offset = "0x15B4030", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EC14A8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20298DF]) = v38;\nL_0018:\n\tv44 = System.String::Concat(this.m_ParentGameObjectPath, \"Button2/Text\");\n\tv46 = UnityEngine.GameObject::Find(v44);\n\treturnVal1 = UnityEngine.GameObject::GetComponent(v46);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private Text GetCancelButtonText()
		{
			string name = m_ParentGameObjectPath + "Button2/Text";
			GameObject gameObject = GameObject.Find(name);
			return gameObject.GetComponent<Text>();
		}

		[Token(Token = "0x6000258")]
		[Address(RVA = "0x15B40A4", Offset = "0x15B40A4", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EE43F8]);\n\tv19 = *([v18 @ X8_v14]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20298E0]) = v38;\nL_0018:\n\tv44 = System.String::Concat(this.m_ParentGameObjectPath, \"Panel2/Panel3/Dropdown\");\n\tv46 = UnityEngine.GameObject::Find(v44);\n\tgoto L_002C;\n\tv54 = *([v50 @ X8_v7+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_002C;\n\tv65 = v50;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v65, v45, v42, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002C:\n\tv64 = UnityEngine.Object::op_Inequality(v46, 0);\n\tv69 = v64 == 0;\n\tif (v69) goto L_003E;\n\treturnVal1 = UnityEngine.GameObject::GetComponent(v46);\nL_003E:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private Dropdown GetDropdown()
		{
			string name = m_ParentGameObjectPath + "Panel2/Panel3/Dropdown";
			GameObject gameObject = GameObject.Find(name);
			bool flag = gameObject != null;
			bool flag2 = !flag;
			Dropdown result = null;
			if (!flag2)
			{
				result = gameObject.GetComponent<Dropdown>();
			}
			return result;
		}

		[Token(Token = "0x6000259")]
		[Address(RVA = "0x15B42A0", Offset = "0x15B42A0", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EE3470]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20298E1]) = v38;\nL_0018:\n\tv44 = System.String::Concat(this.m_ParentGameObjectPath, \"Panel2\");\n\treturnVal1 = UnityEngine.GameObject::Find(v44);\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private GameObject GetDropdownContainerGameObject()
		{
			string name = m_ParentGameObjectPath + "Panel2";
			return GameObject.Find(name);
		}

		[Token(Token = "0x600025A")]
		[Address(RVA = "0x15B458C", Offset = "0x15B458C", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EFBE80]);\n\tv21 = *([v20 @ X8_v15]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20298E2]) = v40;\nL_0015:\n\tv42 = this.m_LastSelectedDropdownIndex == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tv46 = this.UIMode - 2;\n\tv48 = v46 == 0;\n\tv53 = ~v48;\n\tgoto L_002B;\nL_002B:\n\tgoto L_0031;\n\tv82 = *([v78 @ X0_v2+E0]);\n\tv83 = v82 == 0;\n\tv84 = ~v83;\n\tgoto L_0031;\n\tv86 = \"il2cpp_codegen_runtime_class_init\"(v78, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0031:\n\tv89 = this.m_LastSelectedDropdownIndex - 1;\n\tv92 = System.Math::Max(0, v89);\n\tv93 = this.m_CurrentDialog;\n\tSystem.Action`2<System.Boolean, System.Int32>::Invoke(v93.Callback, v75, v92);\n\tUnityEngine.Purchasing.UIFakeStore::CloseDialog(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OkayButtonClicked()
		{
			bool arg;
			if (m_LastSelectedDropdownIndex != 0)
			{
				int num = (int)(UIMode - 2);
				bool flag = num == 0;
				bool flag2 = !flag;
				arg = flag2;
			}
			else
			{
				arg = true;
			}
			int val = m_LastSelectedDropdownIndex - 1;
			int arg2 = Math.Max(0, val);
			DialogRequest currentDialog = m_CurrentDialog;
			currentDialog.Callback(arg, arg2);
			CloseDialog();
		}

		[Token(Token = "0x600025B")]
		[Address(RVA = "0x15B47AC", Offset = "0x15B47AC", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1ECD100]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20298E3]) = v38;\nL_001A:\n\tgoto L_0020;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0020;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0020:\n\tv53 = this.m_LastSelectedDropdownIndex - 1;\n\tv56 = System.Math::Max(0, v53);\n\tv57 = this.m_CurrentDialog;\n\tSystem.Action`2<System.Boolean, System.Int32>::Invoke(v57.Callback, 0, v56);\n\tUnityEngine.Purchasing.UIFakeStore::CloseDialog(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CancelButtonClicked()
		{
			int val = m_LastSelectedDropdownIndex - 1;
			int arg = Math.Max(0, val);
			DialogRequest currentDialog = m_CurrentDialog;
			currentDialog.Callback(arg1: false, arg);
			CloseDialog();
		}

		[Token(Token = "0x600025C")]
		[Address(RVA = "0x15B4854", Offset = "0x15B4854", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_LastSelectedDropdownIndex = selectedItem;\n\treturn;\n")]
		private void DropdownValueChanged(int selectedItem)
		{
			m_LastSelectedDropdownIndex = selectedItem;
		}

		[Token(Token = "0x600025D")]
		[Address(RVA = "0x15B4654", Offset = "0x15B4654", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EC8E50]);\n\tv21 = *([v20 @ X8_v9]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20298E4]) = v40;\nL_0015:\n\tthis.m_CurrentDialog = 0;\n\tv42 = UnityEngine.Purchasing.UIFakeStore::GetOkayButton(this);\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v42.m_OnClick);\n\tv79 = UnityEngine.Purchasing.UIFakeStore::GetCancelButton(this);\n\tgoto L_0030;\n\tv105 = *([v71 @ X8_v4+E0]);\n\tv106 = v105 == 0;\n\tv107 = ~v106;\n\tif (v107) goto L_0030;\n\tv113 = v71;\n\tv109 = \"il2cpp_codegen_runtime_class_init\"(v113, v77, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0030:\n\tv112 = UnityEngine.Object::op_Implicit(v79);\n\tv115 = v112 == 0;\n\tif (v115) goto L_003E;\n\tv59 = UnityEngine.Purchasing.UIFakeStore::GetCancelButton(this);\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v59.m_OnClick);\nL_003E:\n\tv122 = UnityEngine.Purchasing.UIFakeStore::GetDropdown(this);\n\tgoto L_004E;\n\tv126 = *([v72 @ X8_v5+E0]);\n\tv127 = v126 == 0;\n\tv128 = ~v127;\n\tif (v128) goto L_004E;\n\tv134 = v72;\n\tv130 = \"il2cpp_codegen_runtime_class_init\"(v134, v117, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_004E:\n\tv133 = UnityEngine.Object::op_Inequality(v122, 0);\n\tv136 = v133 == 0;\n\tif (v136) goto L_005F;\n\tv61 = UnityEngine.Purchasing.UIFakeStore::GetDropdown(this);\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v61.m_OnValueChanged);\nL_005F:\n\tv142 = UnityEngine.Component::get_gameObject(this.m_Canvas);\n\tgoto L_0074;\n\tv147 = *([v96 @ X8_v6+E0]);\n\tv148 = v147 == 0;\n\tv149 = ~v148;\n\tif (v149) goto L_0074;\n\tv152 = v96;\n\tv151 = \"il2cpp_codegen_runtime_class_init\"(v152, v141, v47, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0074:\n\tUnityEngine.Object::Destroy(v142);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CloseDialog()
		{
			m_CurrentDialog = null;
			Button okayButton = GetOkayButton();
			okayButton.onClick.RemoveAllListeners();
			Button cancelButton = GetCancelButton();
			if ((bool)cancelButton)
			{
				Button cancelButton2 = GetCancelButton();
				cancelButton2.onClick.RemoveAllListeners();
			}
			Dropdown dropdown = GetDropdown();
			if (dropdown != null)
			{
				Dropdown dropdown2 = GetDropdown();
				dropdown2.onValueChanged.RemoveAllListeners();
			}
			GameObject gameObject = m_Canvas.gameObject;
			Object.Destroy(gameObject);
		}

		[Token(Token = "0x600025E")]
		[Address(RVA = "0x15B38A4", Offset = "0x15B38A4", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.m_CurrentDialog == 0;\n\tv11 = ~v6;\n\treturn v11;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool IsShowingDialog()
		{
			bool flag = m_CurrentDialog == null;
			return !flag;
		}

		[CompilerGenerated]
		private void _003CInstantiateDialog_003Eb__16_0()
		{
			m_CurrentDialog = null;
		}

		[CompilerGenerated]
		private void _003CInstantiateDialog_003Eb__16_1()
		{
			OkayButtonClicked();
		}

		[CompilerGenerated]
		private void _003CInstantiateDialog_003Eb__16_2()
		{
			CancelButtonClicked();
		}

		[CompilerGenerated]
		private void _003CInstantiateDialog_003Eb__16_3(int selectedItem)
		{
			m_LastSelectedDropdownIndex = selectedItem;
		}
	}
}
