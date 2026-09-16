using System;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x200001B")]
public abstract class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
{
	[Token(Token = "0x4000057")]
	private static object syncRoot;

	[Token(Token = "0x4000058")]
	protected static T instance;

	[Token(Token = "0x1700000D")]
	public static T Instance
	{
		[Token(Token = "0x6000095")]
		[Address(RVA = "0x115D7F4", Offset = "0x115D7F4", Length = "0x648")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv22 = UnityEngine.GameObject;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv50 = UnityEngine.Object;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv61 = System.Type;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A35F75]) = v42;\nL_0020:\n\tgoto L_0028;\n\tv52 = 0xB348B0(v44, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0028:\n\tgoto L_002D;\n\tv62 = 0xB348B0(v55, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002D:\n\tgoto L_0034;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v63, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0034:\n\tgoto L_003C;\n\tv74 = 0xB348B0(v69, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_003C:\n\tgoto L_0044;\n\tv82 = 0xB348B0(v77, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0044:\n\tSystem.Threading.Monitor::Enter(v84.syncRoot, &v88 @ stack_-34_v2 (System.Boolean));\n\tgoto L_0052;\n\tv96 = 0xB348B0(v91, v87, v90, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0052:\n\tgoto L_0057;\n\tv104 = 0xB348B0(v99, v87, v90, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0057:\n\tgoto L_005E;\n\tv109 = \"il2cpp_codegen_runtime_class_init\"(v105, v87, v90, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_005E:\n\tgoto L_FFFFFFFF;\n\tv116 = 0xB348B0(v111, v87, v90, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0068;\n\tv124 = 0xB348B0(v119, v87, v90, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0068:\n\tv126 = *([v125 @ X0_v20 (Il2CppClass<SingletonMono`1<T>>)+B8]);\n\tv128 = 0xAD94E8(v125, &v88 @ stack_-34_v2 (System.Boolean), 0, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0076;\n\tv135 = \"il2cpp_codegen_runtime_class_init\"(v131, v87, v90, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0076:\n\tv140 = UnityEngine.Object::op_Equality(*([v126 @ X8_v18 (Il2CppStaticFields<SingletonMono`1<T>>)+8]), 0);\n\tv142 = v140 == 0;\n\tif (v142) goto L_FFFFFFFF;\n\tgoto L_0089;\n\tv182 = 0xB348B0(v143, v138, v139, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0089:\n\tgoto L_008E;\n\tv241 = v186;\n\tv242 = \"il2cpp_codegen_runtime_class_init\"(v241, v138, v139, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_008E:\n\tv246 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tgoto L_0098;\n\tv269 = \"il2cpp_codegen_runtime_class_init\"(v254, v245, v139, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0098:\n\tv273 = UnityEngine.Object::FindObjectOfType(v246);\n\tgoto L_00A7;\n\tv366 = 0xB348B0(v311, v272, v139, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_00A7:\n\tgoto L_00AC;\n\tv434 = 0xB348B0(v369, v272, v139, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_00AC:\n\tgoto L_00AE;\n\tv471 = \"il2cpp_codegen_runtime_class_init\"(v435, v272, v139, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_00AE:\n\tv473 = 0xAD94E8(Il2CppClass<SingletonMono`1<T>>, 0, 0, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_00BC;\n\tv526 = 0xB348B0(v505, v272, v139, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_00BC:\n\tgoto L_00C1;\n\tv534 = v529;\n\tv535 = 0xB348B0(v534, v529, v139, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv537 = v535;\nL_00C1:\n\t// 193 IsInst v540 @ X0_v92, typeof(T), v273 @ X0_v81 (UnityEngine.Object)\n\tgoto L_00D0;\n\tv550 = 0xB348B0(v543, v536, v139, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_00D0:\n\tgoto L_00D4;\n\tv559 = v553;\n\tv560 = 0xB348B0(v559, v536, v139, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv561 = v560;\nL_00D4:\n\tv563 = v540 == 0;\n\tif (v563) goto L_FFFFFFFF;\n\t// 216 IsInst v570 @ X0_v185 (System.Int32), typeof(T), v540 @ X0_v92\n\tv585 = v570 == 0;\n\tv578 = ~v585;\n\tif (v578) goto L_00E6;\n\tthrow System.InvalidCastException;\nL_00E6:\n\tgoto L_FFFFFFFF;\n\tv595 = 0xB348B0(v589, v586, v139, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_00F0;\n\tv603 = 0xB348B0(v598, v586, v139, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_00F0:\n\tv605 = *([v604 @ X0_v100 (Il2CppClass<SingletonMono`1<T>>)+B8]);\n\t*([v605 @ X8_v57 (Il2CppStaticFields<SingletonMono`1<T>>)+8]) = v149;\n\tgoto L_00FF;\n\tv611 = 0xB348B0(v606, v586, v139, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_00FF:\n\tgoto L_0106;\n\tv619 = 0xB348B0(v614, v586, v139, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0106:\n\tgoto L_FFFFFFFF;\n\tv626 = 0xB348B0(v621, v586, v139, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0113;\n\tv634 = v629;\n\tv635 = 0xB348B0(v634, v629, v139, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv637 = v635;\nL_0113:\n\t// 275 IsInst v640 @ X0_v109, typeof(T), v273 @ X0_v81 (UnityEngine.Object)\n\tgoto L_0122;\n\tv646 = 0xB348B0(v641, v636, v139, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0122:\n\tgoto L_0126;\n\tv653 = v649;\n\tv654 = 0xB348B0(v653, v636, v139, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv655 = v654;\nL_0126:\n\tv657 = v640 == 0;\n\tif (v657) goto L_0132;\n\t// 298 IsInst v302 @ X0_v172, typeof(T), v640 @ X0_v109\n\tv304 = v302 == 0;\n\tif (v304) goto L_0217;\nL_0132:\n\tgoto L_FFFFFFFF;\n\tv667 = 0xB348B0(v662, v659, v139, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_013C;\n\tv675 = 0xB348B0(v670, v659, v139, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_013C:\n\tv179 = *([v676 @ X0_v117 (Il2CppClass<SingletonMono`1<T>>)+B8]);\n\tv677 = 0xAD94E8(v676, v659, 0, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv173 = UnityEngine.Object::op_Equality(*([v179 @ X8_v70 (Il2CppStaticFields<SingletonMono`1<T>>)+8]), 0);\n\tv176 = v173 == 0;\n\tif (v176) goto L_FFFFFFFF;\n\tv360 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v360);\n\tv362 = v360 == 0;\n\tif (v362) goto L_0218;\n\tgoto L_0159;\n\tv687 = 0xB348B0(v682, v358, v167, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0159:\n\tv691 = UnityEngine.GameObject::AddComponent(v360);\n\tgoto L_0168;\n\tv698 = UnityEngine.GameObject::AddComponent(v693, v426);\nL_0168:\n\tgoto L_016D;\n\tv706 = UnityEngine.GameObject::AddComponent(v701, v426);\nL_016D:\n\tgoto L_016F;\n\tv711 = \"il2cpp_codegen_runtime_class_init\"(v707, v426, v167, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_016F:\n\tv713 = UnityEngine.GameObject::AddComponent(Il2CppClass<SingletonMono`1<T>>);\n\tgoto L_FFFFFFFF;\n\tv719 = UnityEngine.GameObject::AddComponent(v714, v426);\n\tgoto L_017F;\n\tv727 = UnityEngine.GameObject::AddComponent(v722, v426);\nL_017F:\n\tv729 = *([v728 @ X0_v136 (Il2CppClass<SingletonMono`1<T>>)+B8]);\n\t*([v729 @ X8_v82 (Il2CppStaticFields<SingletonMono`1<T>>)+8]) = v691;\n\tgoto L_018E;\n\tv735 = UnityEngine.GameObject::AddComponent(v730, v426);\nL_018E:\n\tgoto L_0195;\n\tv743 = UnityEngine.GameObject::AddComponent(v738, v426);\nL_0195:\n\tgoto L_FFFFFFFF;\n\tv750 = UnityEngine.GameObject::AddComponent(v745, v426);\n\tgoto L_019F;\n\tv758 = UnityEngine.GameObject::AddComponent(v753, v426);\nL_019F:\n\tv432 = *([v759 @ X0_v144 (Il2CppClass<SingletonMono`1<T>>)+B8]);\n\tv428 = UnityEngine.GameObject::AddComponent(v759);\n\tv761 = UnityEngine.Component::get_gameObject(*([v432 @ X8_v89 (Il2CppStaticFields<SingletonMono`1<T>>)+8]));\n\tgoto L_FFFFFFFF;\n\tv767 = UnityEngine.GameObject::AddComponent(v762, v463);\n\tgoto L_01B7;\n\tv775 = UnityEngine.GameObject::AddComponent(v770, v463);\nL_01B7:\n\tv469 = *([v776 @ X0_v151 (Il2CppClass<SingletonMono`1<T>>)+B8]);\n\tv465 = UnityEngine.GameObject::AddComponent(v776);\n\tv500 = System.Object::GetType(*([v469 @ X8_v93 (Il2CppStaticFields<SingletonMono`1<T>>)+8]));\n\n// ... truncated")]
		get
		{
			//IL_0077: Expected O, but got I
			//IL_0093: Expected O, but got I4
			//IL_03a5: Expected I, but got O
			//IL_047c: Expected O, but got I
			//IL_0105: Expected I4, but got O
			//IL_01f4: Expected O, but got I
			//IL_0215: Expected O, but got I4
			//IL_027c: Expected O, but got I
			//IL_02d8: Expected O, but got I
			//IL_02f2: Expected O, but got I
			//IL_031f: Expected O, but got I
			//IL_0339: Expected O, but got I
			//IL_0367: Expected O, but got I4
			//IL_0393: Expected O, but got I4
			//IL_04e9: Expected I, but got O
			bool lockTaken = default(bool);
			Monitor.Enter(syncRoot, ref lockTaken);
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ X0_v20 (Il2CppClass<SingletonMono`1<T>>)+B8]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94E8");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ X8_v18 (Il2CppStaticFields<SingletonMono`1<T>>)+8]");
			bool flag = (UnityEngine.Object)0 == null;
			bool flag2 = !flag;
			object obj = 0;
			string text = null;
			InvalidCastException ex = default(InvalidCastException);
			nint num16;
			int num17;
			if (!flag2)
			{
				Type typeFromHandle = typeof(T);
				UnityEngine.Object obj2 = UnityEngine.Object.FindObjectOfType(typeFromHandle);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94E8");
				object obj3 = obj2 as T;
				if (obj3 != null)
				{
					int num3 = (int)(obj3 as T);
					bool flag3 = num3 == 0;
					bool flag4 = !flag3;
					int num4 = num3;
					if (!flag4)
					{
						throw new InvalidCastException();
					}
				}
				else
				{
					int num4 = 0;
				}
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v604 @ X0_v100 (Il2CppClass<SingletonMono`1<T>>)+B8]");
				nint num6 = 0;
				nint num7 = 0;
				object obj4 = obj2 as T;
				if (obj4 != null)
				{
					object obj5 = obj4 as T;
					bool flag5 = obj5 == null;
					num7 = 0;
					if (flag5)
					{
						ex = new InvalidCastException();
						goto IL_04a4;
					}
				}
				nint num8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v676 @ X0_v117 (Il2CppClass<SingletonMono`1<T>>)+B8]");
				nint num9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94E8");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ X8_v70 (Il2CppStaticFields<SingletonMono`1<T>>)+8]");
				bool flag6 = (UnityEngine.Object)0 == null;
				bool flag7 = !flag6;
				obj = 0;
				text = null;
				if (!flag7)
				{
					GameObject gameObject = new GameObject();
					if ((object)gameObject == null)
					{
						goto IL_04a4;
					}
					T val = gameObject.AddComponent<T>();
					T val2 = ((GameObject)0).AddComponent<T>();
					nint num10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v728 @ X0_v136 (Il2CppClass<SingletonMono`1<T>>)+B8]");
					nint num11 = 0;
					nint num12 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v759 @ X0_v144 (Il2CppClass<SingletonMono`1<T>>)+B8]");
					nint num13 = 0;
					T val3 = ((GameObject)num12).AddComponent<T>();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v432 @ X8_v89 (Il2CppStaticFields<SingletonMono`1<T>>)+8]");
					GameObject gameObject2 = ((Component)0).gameObject;
					nint num14 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v776 @ X0_v151 (Il2CppClass<SingletonMono`1<T>>)+B8]");
					nint num15 = 0;
					T val4 = ((GameObject)num14).AddComponent<T>();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v469 @ X8_v93 (Il2CppStaticFields<SingletonMono`1<T>>)+8]");
					Type type = 0.GetType();
					string text2 = type.Name;
					bool flag8 = (object)gameObject2 == null;
					obj = 0;
					text = text2;
					if (flag8)
					{
						NullReferenceException ex2 = new NullReferenceException();
						if ((nint)text2 == 1)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E70 (native __cxa_begin_catch)");
							object obj6 = default(object);
							num16 = (nint)obj6;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E80 (native __cxa_end_catch)");
							num17 = 0;
							goto IL_05b8;
						}
						if (lockTaken)
						{
							Monitor.Exit(syncRoot);
							text = null;
						}
						OutOfMemoryException ex3 = new OutOfMemoryException();
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @9DACB4");
						T result = default(T);
						return result;
					}
					gameObject2.name = text2;
					obj = 0;
					text = text2;
				}
			}
			num16 = unchecked((nint)null);
			num17 = 3;
			goto IL_05b8;
			IL_05b8:
			if (lockTaken)
			{
				Monitor.Exit(syncRoot);
				text = null;
			}
			T result2;
			if (num16 == 0)
			{
				if (num17 != 3)
				{
					bool flag9 = num17 == 0;
					bool flag10 = !flag9;
					result2 = (T)syncRoot;
					if (flag10)
					{
						goto IL_048b;
					}
				}
				nint num18 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v511 @ X0_v40 (Il2CppClass<SingletonMono`1<T>>)+B8]");
				nint num19 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ X8_v30 (Il2CppStaticFields<SingletonMono`1<T>>)+8]");
				result2 = (T)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94E8");
				goto IL_048b;
			}
			throw new OutOfMemoryException();
			IL_048b:
			return result2;
			IL_04a4:
			throw ex;
		}
	}

	[Token(Token = "0x1700000E")]
	public static bool IsNull
	{
		[Token(Token = "0x6000096")]
		[Address(RVA = "0x115DE3C", Offset = "0x115DE3C", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = UnityEngine.Object;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A35F76]) = v33;\nL_0015:\n\tgoto L_001D;\n\tv39 = 0xB348B0(v34, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001D:\n\tgoto L_0022;\n\tv47 = 0xB348B0(v42, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0022:\n\tgoto L_0029;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v48, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0029:\n\tgoto L_FFFFFFFF;\n\tv59 = 0xB348B0(v54, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tgoto L_0035;\n\tv69 = 0xB348B0(v63, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0035:\n\tv71 = *([v70 @ X0_v10 (Il2CppClass<SingletonMono`1<T>>)+B8]);\n\tv73 = 0xAD94E8(v70, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tgoto L_0045;\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v74, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0045:\n\treturnVal1 = UnityEngine.Object::op_Equality(*([v71 @ X8_v10 (Il2CppStaticFields<SingletonMono`1<T>>)+8]), 0);\n\treturn returnVal1;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			//IL_0050: Expected O, but got I
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ X0_v10 (Il2CppClass<SingletonMono`1<T>>)+B8]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94E8");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X8_v10 (Il2CppStaticFields<SingletonMono`1<T>>)+8]");
			return (UnityEngine.Object)0 == null;
		}
	}

	[Token(Token = "0x6000097")]
	[Address(RVA = "0x115DEF8", Offset = "0x115DEF8", Length = "0x2AC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = UnityEngine.Object;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A35F77]) = v40;\nL_001B:\n\tgoto L_0020;\n\tv48 = 0xB348B0(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0020:\n\tgoto L_FFFFFFFF;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v49, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_002D;\n\tv64 = 0xB348B0(v58, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002D:\n\tv66 = *([v65 @ X0_v6 (Il2CppClass<SingletonMono`1<T>>)+B8]);\n\tv68 = 0xAD94E8(v65, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_0039;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v69, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0039:\n\tv78 = UnityEngine.Object::op_Inequality(*([v66 @ X8_v10 (Il2CppStaticFields<SingletonMono`1<T>>)+8]), 0);\n\tv80 = v78 == 0;\n\tif (v80) goto L_0074;\n\tgoto L_0049;\n\tv132 = 0xB348B0(v83, v76, v77, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0049:\n\tgoto L_FFFFFFFF;\n\tv142 = \"il2cpp_codegen_runtime_class_init\"(v133, v76, v77, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_0054;\n\tv154 = 0xB348B0(v146, v76, v77, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0054:\n\tv122 = *([v155 @ X0_v57 (Il2CppClass<SingletonMono`1<T>>)+B8]);\n\tv157 = 0xAD94E8(v155, 0, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv175 = UnityEngine.Object::GetInstanceID(*([v122 @ X8_v43 (Il2CppStaticFields<SingletonMono`1<T>>)+8]));\n\tv118 = UnityEngine.Object::GetInstanceID(this);\n\tv89 = v175 != v118;\n\tif (v89) goto L_00E0;\nL_0074:\n\tgoto L_0079;\n\tv137 = 0xB348B0(v127, v115, v77, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0079:\n\tgoto L_007B;\n\tv151 = \"il2cpp_codegen_runtime_class_init\"(v138, v115, v77, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_007B:\n\tv153 = 0xAD94E8(Il2CppClass<SingletonMono`1<T>>, v115, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_0088;\n\tv166 = v160;\n\tv167 = 0xB348B0(v166, v160, v77, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv169 = v167;\nL_0088:\n\t// 136 IsInst v172 @ X0_v22, typeof(T), this @ X0 (SingletonMono`1<T>)\n\tgoto L_0095;\n\tv220 = v183;\n\tv221 = 0xB348B0(v220, v168, v77, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv222 = v221;\nL_0095:\n\tv224 = v172 == 0;\n\tif (v224) goto L_FFFFFFFF;\n\t// 153 IsInst v228 @ X0_v44 (System.Int32), typeof(T), v172 @ X0_v22\n\tv279 = v228 == 0;\n\tv234 = ~v279;\n\tif (v234) goto L_FFFFFFFF;\n\tthrow System.InvalidCastException;\n\tgoto L_00AD;\n\tv294 = 0xB348B0(v285, v280, v77, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv305 = Il2CppClass<SingletonMono`1>;\n\tv297 = Il2CppRgctx<SingletonMono`1>;\nL_00AD:\n\tv298 = *([v295 @ X0_v26 (Il2CppClass<SingletonMono`1<T>>)+B8]);\n\t*([v298 @ X9_v3 (Il2CppStaticFields<SingletonMono`1<T>>)+8]) = v216;\n\tgoto L_00BD;\n\tv306 = 0xB348B0(v299, v280, v77, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv318 = Il2CppClass<SingletonMono`1>;\n\tv309 = Il2CppRgctx<SingletonMono`1>;\nL_00BD:\n\tgoto L_00C2;\n\tv319 = v310;\n\tv320 = 0xB348B0(v319, v310, v77, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv322 = v320;\nL_00C2:\n\t// 194 IsInst v325 @ X0_v31, typeof(T), this @ X0 (SingletonMono`1<T>)\n\tgoto L_00CF;\n\tv332 = v328;\n\tv333 = 0xB348B0(v332, v321, v77, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv335 = v333;\nL_00CF:\n\tv336 = v325 == 0;\n\tif (v336) goto L_00DD;\n\t// 211 IsInst v206 @ X0_v35, typeof(T), v325 @ X0_v31\n\tv208 = v206 == 0;\n\tif (v208) goto L_00F7;\nL_00DD:\n\treturn;\nL_00E0:\n\tv292 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_00F2;\n\tv315 = v275;\n\tv316 = \"il2cpp_codegen_runtime_class_init\"(v315, v291, v77, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00F2:\n\tUnityEngine.Object::Destroy(v292);\n\treturn;\n\tthrow System.NullReferenceException;\nL_00F7:\n\tthrow System.InvalidCastException;\n// 165 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Awake()
	{
		//IL_0046: Expected O, but got I
		//IL_00b1: Expected O, but got I
		//IL_010e: Expected I4, but got O
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ X0_v6 (Il2CppClass<SingletonMono`1<T>>)+B8]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94E8");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ X8_v10 (Il2CppStaticFields<SingletonMono`1<T>>)+8]");
		bool flag = (UnityEngine.Object)0 != null;
		bool flag2 = !flag;
		UnityEngine.Object obj = null;
		if (!flag2)
		{
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ X0_v57 (Il2CppClass<SingletonMono`1<T>>)+B8]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94E8");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ X8_v43 (Il2CppStaticFields<SingletonMono`1<T>>)+8]");
			int instanceID = ((UnityEngine.Object)0).GetInstanceID();
			int instanceID2 = GetInstanceID();
			bool flag3 = instanceID != instanceID2;
			obj = null;
			if (flag3)
			{
				GameObject obj2 = base.gameObject;
				UnityEngine.Object.Destroy(obj2);
				return;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94E8");
		object obj3 = this as T;
		if (obj3 != null)
		{
			int num5 = (int)(obj3 as T);
			bool flag4 = num5 == 0;
			bool flag5 = !flag4;
			int num6 = num5;
			if (!flag5)
			{
				throw new InvalidCastException();
			}
		}
		else
		{
			int num6 = 0;
		}
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ X0_v26 (Il2CppClass<SingletonMono`1<T>>)+B8]");
		nint num8 = 0;
		object obj4 = this as T;
		if (obj4 != null)
		{
			object obj5 = obj4 as T;
			if (obj5 == null)
			{
				throw new InvalidCastException();
			}
		}
	}

	[Token(Token = "0x6000098")]
	[Address(RVA = "0x115E1A4", Offset = "0x115E1A4", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	protected internal SingletonMono()
	{
	}

	[Token(Token = "0x6000099")]
	[Address(RVA = "0x115E1AC", Offset = "0x115E1AC", Length = "0xAC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = System.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35F78]) = v37;\nL_0014:\n\tv39 = new System.Object();\n\tSystem.Object::.ctor(v39);\n\tgoto L_0025;\n\tv47 = 0xB348B0(v42, v40, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0025:\n\tgoto L_0028;\n\tv55 = 0xB348B0(v50, v40, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0028:\n\tv57.syncRoot = v39;\n\tgoto L_0031;\n\tv63 = 0xB348B0(v58, v40, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0031:\n\tv66 = Il2CppClass<SingletonMono`1<T>>;\n\tv68 = *([v66 @ X0_v10 (Il2CppClass<SingletonMono`1<T>>)+135]) & 1;\n\tv69 = v68 == 0;\n\tv70 = ~v69;\n\tif (v70) goto L_0043;\n\tv75 = 0xB348B0(Il2CppClass<SingletonMono`1<T>>, 0, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\treturn;\nL_0043:\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	static SingletonMono()
	{
		object obj = new object();
		syncRoot = obj;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ X0_v10 (Il2CppClass<SingletonMono`1<T>>)+135]");
		if ((int)((nint)0 & (nint)1) == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @B348B0");
		}
	}
}
