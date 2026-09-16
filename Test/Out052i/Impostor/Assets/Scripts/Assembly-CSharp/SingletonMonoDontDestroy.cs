using System;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x200001C")]
public class SingletonMonoDontDestroy<T> : MonoBehaviour where T : MonoBehaviour
{
	[Token(Token = "0x4000059")]
	private static T _instance;

	[Token(Token = "0x400005A")]
	private static object _lock;

	[Token(Token = "0x400005B")]
	[FieldOffset(Offset = "0x0")]
	protected string className;

	[Token(Token = "0x400005C")]
	private static bool applicationIsQuitting;

	[Token(Token = "0x1700000F")]
	public static T Instance
	{
		[Token(Token = "0x600009B")]
		[Address(RVA = "0x115CEF4", Offset = "0x115CEF4", Length = "0x7D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv24 = Il2CppMethodInfo;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = UnityEngine.Object;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv63 = Il2CppMethodInfo;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv71 = System.Type;\n\tv72 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv81 = \"Managers/\";\n\tv82 = \"il2cpp_codegen_initialize_runtime_metadata\"(v81, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv92 = \"(singleton) \";\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v92, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 1;\n\t*([1A35F73]) = v44;\nL_002A:\n\tgoto L_0032;\n\tv54 = 0xB348B0(v46, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0032:\n\tgoto L_0037;\n\tv65 = 0xB348B0(v57, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0037:\n\tgoto L_003E;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v66, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_003E:\n\tgoto L_FFFFFFFF;\n\tv83 = 0xB348B0(v75, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_0048;\n\tv93 = 0xB348B0(v86, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0048:\n\tv95 = *([v94 @ X0_v10 (Il2CppClass<SingletonMonoDontDestroy`1<T>>)+B8]);\n\tSystem.Threading.Monitor::Enter(*([v95 @ X8_v10 (Il2CppStaticFields<SingletonMonoDontDestroy`1<T>>)+8]), &v99 @ stack_-44_v2 (System.Boolean));\n\tgoto L_005C;\n\tv107 = 0xB348B0(v102, v98, v101, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_005C:\n\tgoto L_0061;\n\tv115 = 0xB348B0(v110, v98, v101, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0061:\n\tgoto L_0068;\n\tv120 = \"il2cpp_codegen_runtime_class_init\"(v116, v98, v101, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0068:\n\tgoto L_FFFFFFFF;\n\tv127 = 0xB348B0(v122, v98, v101, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_0072;\n\tv135 = 0xB348B0(v130, v98, v101, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0072:\n\tv137 = *([v136 @ X0_v20 (Il2CppClass<SingletonMonoDontDestroy`1<T>>)+B8]);\n\tv139 = *([v137 @ X8_v18 (Il2CppStaticFields<SingletonMonoDontDestroy`1<T>>)+10]) == 0;\n\tif (v139) goto L_007E;\n\tgoto L_0277;\nL_007E:\n\tgoto L_0086;\n\tv244 = 0xB348B0(v194, v98, v101, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0086:\n\tgoto L_008B;\n\tv297 = 0xB348B0(v247, v98, v101, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_008B:\n\tgoto L_0092;\n\tv308 = \"il2cpp_codegen_runtime_class_init\"(v298, v98, v101, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0092:\n\tgoto L_009A;\n\tv326 = 0xB348B0(v310, v98, v101, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_009A:\n\tgoto L_00A4;\n\tv394 = 0xB348B0(v329, v98, v101, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_00A4:\n\tgoto L_00AA;\n\tv432 = v398;\n\tv433 = \"il2cpp_codegen_runtime_class_init\"(v432, v98, v101, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_00AA:\n\tv437 = UnityEngine.Object::op_Equality(v397._instance, 0);\n\tv469 = v437 == 0;\n\tif (v469) goto L_0233;\n\tgoto L_00BD;\n\tv560 = 0xB348B0(v498, v436, v383, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_00BD:\n\tgoto L_00C2;\n\tv575 = v563;\n\tv576 = \"il2cpp_codegen_runtime_class_init\"(v575, v436, v383, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_00C2:\n\tv580 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tgoto L_00CC;\n\tv601 = \"il2cpp_codegen_runtime_class_init\"(v588, v579, v383, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_00CC:\n\tv605 = UnityEngine.Object::FindObjectOfType(v580);\n\tgoto L_00DB;\n\tv632 = 0xB348B0(v615, v604, v383, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_00DB:\n\tgoto L_00E0;\n\tv645 = 0xB348B0(v635, v604, v383, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_00E0:\n\tgoto L_00E7;\n\tv650 = \"il2cpp_codegen_runtime_class_init\"(v646, v604, v383, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_00E7:\n\tgoto L_00EF;\n\tv657 = 0xB348B0(v652, v604, v383, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_00EF:\n\tgoto L_00F3;\n\tv665 = v660;\n\tv666 = 0xB348B0(v665, v604, v383, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv667 = v666;\nL_00F3:\n\tv669 = v605 == 0;\n\tif (v669) goto L_FFFFFFFF;\n\t// 247 IsInst v672 @ X0_v215 (T), typeof(T), v605 @ X0_v85 (UnityEngine.Object)\n\tv682 = v672 == 0;\n\tv680 = ~v682;\n\tif (v680) goto L_0105;\n\tthrow System.InvalidCastException;\nL_0105:\n\tgoto L_010D;\n\tv693 = 0xB348B0(v687, v684, v383, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_010D:\n\tgoto L_0110;\n\tv701 = 0xB348B0(v696, v684, v383, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0110:\n\tv703._instance = v683;\n\tgoto L_011E;\n\tv709 = 0xB348B0(v704, v684, v383, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_011E:\n\tgoto L_0125;\n\tv717 = 0xB348B0(v712, v684, v383, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0125:\n\tgoto L_012D;\n\tv724 = 0xB348B0(v719, v684, v383, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_012D:\n\tgoto L_0131;\n\tv731 = v727;\n\tv732 = 0xB348B0(v731, v684, v383, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv733 = v732;\nL_0131:\n\tv735 = v605 == 0;\n\tif (v735) goto L_013D;\n\t// 309 IsInst v423 @ X0_v205, typeof(T), v605 @ X0_v85 (UnityEngine.Object)\n\tv425 = v423 == 0;\n\tif (v425) goto L_028F;\nL_013D:\n\tgoto L_0142;\n\tv745 = 0xB348B0(v740, v737, v383, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0142:\n\tv750 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tv387 = UnityEngine.Object::FindObjectsOfType(v750);\n\tv142 = v387.Length >= 2;\n\tif (v142) goto L_0255;\n\tgoto L_0162;\n\tv761 = 0xB348B0(v751, v385, v383, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0162:\n\tgoto L_0167;\n\tv777 = 0xB348B0(v764, v385, v383, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0167:\n\tgoto L_016E;\n\tv787 = \"il2cpp_codegen_runtime_class_init\"(v778, v385, v383, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_016E:\n\tgoto L_0176;\n\tv801 = 0xB348B0(v789, v385, v383, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0176:\n\tgoto L_017E;\n\tv814 = 0xB348B0(v804, v385, v383, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_017E:\n\tgoto L_0184;\n\tv818 = v537;\n\tv819 = \"il2cpp_codegen_runtime_class_init\"(v818, v385, v383, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0184:\n\tv531 = UnityEngine.Object::op_Equality(v521._instance, 0);\n\tv534 = v531 == 0;\n\tif (v534) goto L_0233;\n\tgoto L_0195;\n\tv828 = 0xB348B0(v823, v528, v457, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0195:\n\tgoto L_019A;\n\tv832 = v466;\n\tv833 = \"il2cpp_codegen_runtime_class_init\"(v832, v528, v457, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_019A:\n\tv461 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tv838 = System.Reflection.MemberInfo::get_Name(v461);\n\tv844 = System.String::Concat(\"Managers/\", v838);\n\tv848 = UnityEngine.Resources::Load(v844);\n\tgoto L_01B5;\n\tv852 = \"il2cpp_codegen_runtime_class_init\"(v849, v847, v843, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_01B5:\n\tv188 = UnityEngine.Object::op_Equality(v848, 0);\n\tv856 = v188 == 0;\n\tv190 = ~v856;\n\tif (v190) goto L_FFFFFFFF;\n\tgoto L_01C4;\n\tv861 = \"il2cpp_codegen_runtime_class_init\"(v857, v186, v184, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_01C4:\n\tv491 = UnityEngine.Object::Instantiate(\n// ... truncated")]
		get
		{
			//IL_0044: Expected O, but got I
			//IL_009d: Expected I, but got O
			//IL_041b: Expected O, but got I
			//IL_0405: Expected I, but got O
			//IL_04d4: Expected I, but got O
			//IL_0501: Expected O, but got I
			//IL_0506: Expected I, but got O
			//IL_02ff: Expected O, but got I
			//IL_0314: Expected O, but got I
			//IL_0377: Expected I, but got O
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ X0_v10 (Il2CppClass<SingletonMonoDontDestroy`1<T>>)+B8]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ X8_v10 (Il2CppStaticFields<SingletonMonoDontDestroy`1<T>>)+8]");
			bool lockTaken = default(bool);
			Monitor.Enter(0, ref lockTaken);
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ X0_v20 (Il2CppClass<SingletonMonoDontDestroy`1<T>>)+B8]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ X8_v18 (Il2CppStaticFields<SingletonMonoDontDestroy`1<T>>)+10]");
			if ((nint)0 != 0)
			{
				goto IL_0098;
			}
			nint num5;
			if (_instance == null)
			{
				Type typeFromHandle = typeof(T);
				UnityEngine.Object obj = UnityEngine.Object.FindObjectOfType(typeFromHandle);
				T instance;
				if ((object)obj != null)
				{
					T val = obj as T;
					bool flag = (object)val == null;
					bool flag2 = !flag;
					instance = val;
					if (!flag2)
					{
						throw new InvalidCastException();
					}
				}
				else
				{
					instance = null;
				}
				_instance = instance;
				if ((object)obj != null)
				{
					object obj2 = obj as T;
					if (obj2 == null)
					{
						InvalidCastException ex = new InvalidCastException();
						NullReferenceException ex2 = new NullReferenceException();
						num5 = 0;
						NullReferenceException ex3 = new NullReferenceException();
						goto IL_0491;
					}
				}
				Type typeFromHandle2 = typeof(T);
				UnityEngine.Object[] array = UnityEngine.Object.FindObjectsOfType(typeFromHandle2);
				if (array.Length < 2 && _instance == null)
				{
					Type typeFromHandle3 = typeof(T);
					string text = typeFromHandle3.Name;
					string path = "Managers/" + text;
					GameObject gameObject = Resources.Load<GameObject>(path);
					if (gameObject == null)
					{
						goto IL_0098;
					}
					GameObject gameObject2 = UnityEngine.Object.Instantiate(gameObject);
					GameObject gameObject3 = (GameObject)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v871 @ X0_v154 (UnityEngine.GameObject)+C0]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @C76B74 (UnityEngine.GameObject::GetComponent, and 1 more at this address)");
					T instance2 = default(T);
					_instance = instance2;
					Type typeFromHandle4 = typeof(T);
					bool flag3 = (object)typeFromHandle4 == null;
					num5 = unchecked((nint)null);
					if (flag3)
					{
						goto IL_0491;
					}
					string text2 = typeFromHandle4.Name;
					string text3 = "(singleton) " + text2;
					gameObject2.name = text3;
					UnityEngine.Object.DontDestroyOnLoad(gameObject2);
				}
			}
			T result = _instance;
			nint num6 = unchecked((nint)null);
			goto IL_0547;
			IL_0491:
			NullReferenceException original = new NullReferenceException();
			if (num5 == 1)
			{
				GameObject gameObject4 = UnityEngine.Object.Instantiate((GameObject)(object)original);
				num6 = (nint)gameObject4;
				GameObject gameObject5 = UnityEngine.Object.Instantiate(gameObject4);
				goto IL_059f;
			}
			if (lockTaken)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ X8_v10 (Il2CppStaticFields<SingletonMonoDontDestroy`1<T>>)+8]");
				Monitor.Exit(0);
				num5 = unchecked((nint)null);
			}
			OutOfMemoryException original2 = new OutOfMemoryException();
			return (T)(object)UnityEngine.Object.Instantiate((GameObject)(object)original2);
			IL_0547:
			if (lockTaken)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ X8_v10 (Il2CppStaticFields<SingletonMonoDontDestroy`1<T>>)+8]");
				Monitor.Exit(0);
			}
			if (num6 == 0)
			{
				return result;
			}
			OutOfMemoryException ex4 = new OutOfMemoryException();
			throw new NullReferenceException();
			IL_0098:
			num6 = unchecked((nint)null);
			goto IL_059f;
			IL_059f:
			result = null;
			goto IL_0547;
		}
	}

	[Token(Token = "0x600009A")]
	[Address(RVA = "0x115CEEC", Offset = "0x115CEEC", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.className;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public string GetClassName()
	{
		return className;
	}

	[Token(Token = "0x600009C")]
	[Address(RVA = "0x115D6C4", Offset = "0x115D6C4", Length = "0x58")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\n\tv13 = 0xB348B0(v8, methodInfo, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27);\nL_0010:\n\tgoto L_FFFFFFFF;\n\tv32 = \"il2cpp_codegen_runtime_class_init\"(v28, methodInfo, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27);\n\tgoto L_001B;\n\tv41 = 0xB348B0(v36, methodInfo, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27);\nL_001B:\n\tv43 = *([v42 @ X0_v5 (Il2CppClass<SingletonMonoDontDestroy`1<T>>)+B8]);\n\t*([v43 @ X8_v8 (Il2CppStaticFields<SingletonMonoDontDestroy`1<T>>)+10]) = 1;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public virtual void OnDestroy()
	{
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X0_v5 (Il2CppClass<SingletonMonoDontDestroy`1<T>>)+B8]");
		nint num2 = 0;
		_ = 1;
	}

	[Token(Token = "0x600009D")]
	[Address(RVA = "0x115D71C", Offset = "0x115D71C", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public SingletonMonoDontDestroy()
	{
	}

	[Token(Token = "0x600009E")]
	[Address(RVA = "0x115D724", Offset = "0x115D724", Length = "0xD0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = System.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35F74]) = v37;\nL_0014:\n\tv39 = new System.Object();\n\tSystem.Object::.ctor(v39);\n\tgoto L_FFFFFFFF;\n\tv47 = 0xB348B0(v42, v40, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tgoto L_0027;\n\tv55 = 0xB348B0(v50, v40, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0027:\n\tv57 = *([v56 @ X0_v7 (Il2CppClass<SingletonMonoDontDestroy`1<T>>)+B8]);\n\t*([v57 @ X8_v6 (Il2CppStaticFields<SingletonMonoDontDestroy`1<T>>)+8]) = v39;\n\tgoto L_0036;\n\tv63 = 0xB348B0(v58, v40, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0036:\n\tgoto L_003D;\n\tv71 = 0xB348B0(v66, v40, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_003D:\n\tgoto L_FFFFFFFF;\n\tv78 = 0xB348B0(v73, v40, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tgoto L_0047;\n\tv86 = 0xB348B0(v81, v40, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0047:\n\tv88 = *([v87 @ X0_v15 (Il2CppClass<SingletonMonoDontDestroy`1<T>>)+B8]);\n\t*([v88 @ X8_v13 (Il2CppStaticFields<SingletonMonoDontDestroy`1<T>>)+10]) = 0;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	static SingletonMonoDontDestroy()
	{
		object obj = new object();
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X0_v7 (Il2CppClass<SingletonMonoDontDestroy`1<T>>)+B8]");
		nint num2 = 0;
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ X0_v15 (Il2CppClass<SingletonMonoDontDestroy`1<T>>)+B8]");
		nint num4 = 0;
		_ = 0;
	}
}
