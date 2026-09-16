using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using HutongGames.Utility;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Serializable]
	[Token(Token = "0x2000075")]
	public class FsmVariables
	{
		[SerializeField]
		[Token(Token = "0x40002FA")]
		[FieldOffset(Offset = "0x10")]
		private FsmFloat[] floatVariables;

		[SerializeField]
		[Token(Token = "0x40002FB")]
		[FieldOffset(Offset = "0x18")]
		private FsmInt[] intVariables;

		[SerializeField]
		[Token(Token = "0x40002FC")]
		[FieldOffset(Offset = "0x20")]
		private FsmBool[] boolVariables;

		[SerializeField]
		[Token(Token = "0x40002FD")]
		[FieldOffset(Offset = "0x28")]
		private FsmString[] stringVariables;

		[SerializeField]
		[Token(Token = "0x40002FE")]
		[FieldOffset(Offset = "0x30")]
		private FsmVector2[] vector2Variables;

		[SerializeField]
		[Token(Token = "0x40002FF")]
		[FieldOffset(Offset = "0x38")]
		private FsmVector3[] vector3Variables;

		[SerializeField]
		[Token(Token = "0x4000300")]
		[FieldOffset(Offset = "0x40")]
		private FsmColor[] colorVariables;

		[SerializeField]
		[Token(Token = "0x4000301")]
		[FieldOffset(Offset = "0x48")]
		private FsmRect[] rectVariables;

		[SerializeField]
		[Token(Token = "0x4000302")]
		[FieldOffset(Offset = "0x50")]
		private FsmQuaternion[] quaternionVariables;

		[SerializeField]
		[Token(Token = "0x4000303")]
		[FieldOffset(Offset = "0x58")]
		private FsmGameObject[] gameObjectVariables;

		[SerializeField]
		[Token(Token = "0x4000304")]
		[FieldOffset(Offset = "0x60")]
		private FsmObject[] objectVariables;

		[SerializeField]
		[Token(Token = "0x4000305")]
		[FieldOffset(Offset = "0x68")]
		private FsmMaterial[] materialVariables;

		[SerializeField]
		[Token(Token = "0x4000306")]
		[FieldOffset(Offset = "0x70")]
		private FsmTexture[] textureVariables;

		[SerializeField]
		[Token(Token = "0x4000307")]
		[FieldOffset(Offset = "0x78")]
		private FsmArray[] arrayVariables;

		[SerializeField]
		[Token(Token = "0x4000308")]
		[FieldOffset(Offset = "0x80")]
		private FsmEnum[] enumVariables;

		[SerializeField]
		[Token(Token = "0x4000309")]
		[FieldOffset(Offset = "0x88")]
		private string[] categories;

		[SerializeField]
		[Token(Token = "0x400030A")]
		[FieldOffset(Offset = "0x90")]
		private int[] variableCategoryIDs;

		[Token(Token = "0x170001B8")]
		public static PlayMakerGlobals GlobalsComponent
		{
			[Token(Token = "0x60005FA")]
			[Address(RVA = "0xE4A0A4", Offset = "0xE4A0A4", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = PlayMakerGlobals::get_Instance();\n\treturn returnVal1;\n")]
			get
			{
				return PlayMakerGlobals.Instance;
			}
		}

		[Token(Token = "0x170001B9")]
		public static FsmVariables GlobalVariables
		{
			[Token(Token = "0x60005FB")]
			[Address(RVA = "0xE4A0FC", Offset = "0xE4A0FC", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = PlayMakerGlobals::get_Instance();\n\treturn v6.variables;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				PlayMakerGlobals instance = PlayMakerGlobals.Instance;
				return instance.Variables;
			}
		}

		[Token(Token = "0x170001BA")]
		[field: Token(Token = "0x40002F9")]
		public static bool GlobalVariablesSynced
		{
			[Token(Token = "0x60005FC")]
			[Address(RVA = "0xE4A11C", Offset = "0xE4A11C", Length = "0x50")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = *([1EBED08]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2024779]) = v35;\nL_001A:\n\treturn v41.<GlobalVariablesSynced>k__BackingField;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60005FD")]
			[Address(RVA = "0xE4A16C", Offset = "0xE4A16C", Length = "0x58")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EA8428]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202477A]) = v38;\nL_0018:\n\tv43.<GlobalVariablesSynced>k__BackingField = value;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set;
		}

		[Token(Token = "0x170001BB")]
		public string[] Categories
		{
			[Token(Token = "0x60005FE")]
			[Address(RVA = "0xE4A1C4", Offset = "0xE4A1C4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.categories;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Categories;
			}
			[Token(Token = "0x60005FF")]
			[Address(RVA = "0xE4A1CC", Offset = "0xE4A1CC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.categories = value;\n\treturn;\n")]
			set
			{
				Categories = value;
			}
		}

		[Token(Token = "0x170001BC")]
		public int[] CategoryIDs
		{
			[Token(Token = "0x6000600")]
			[Address(RVA = "0xE4A1D4", Offset = "0xE4A1D4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.variableCategoryIDs;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return CategoryIDs;
			}
			[Token(Token = "0x6000601")]
			[Address(RVA = "0xE4A1DC", Offset = "0xE4A1DC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.variableCategoryIDs = value;\n\treturn;\n")]
			set
			{
				CategoryIDs = value;
			}
		}

		[Token(Token = "0x170001BD")]
		public FsmFloat[] FloatVariables
		{
			[Token(Token = "0x600060E")]
			[Address(RVA = "0xE4A3DC", Offset = "0xE4A3DC", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EEF428]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024782]) = v38;\nL_0013:\n\treturnVal1 = this.floatVariables;\n\tv40 = this.floatVariables == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_002B;\n\tgoto L_0025;\n\tv59 = *([v44 @ X0_v4 (Il2CppClass<HutongGames.Utility.Arrays`1<HutongGames.PlayMaker.FsmFloat>>)+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0025;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv63 = HutongGames.Utility.Arrays`1<HutongGames.PlayMaker.FsmFloat>;\nL_0025:\n\treturnVal1 = v54.Empty;\nL_002B:\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				FsmFloat[] empty = floatVariables;
				if (floatVariables == null)
				{
					empty = Arrays<FsmFloat>.Empty;
				}
				return empty;
			}
			[Token(Token = "0x600060F")]
			[Address(RVA = "0xE4EAAC", Offset = "0xE4EAAC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.floatVariables = value;\n\treturn;\n")]
			set
			{
				FloatVariables = value;
			}
		}

		[Token(Token = "0x170001BE")]
		public FsmInt[] IntVariables
		{
			[Token(Token = "0x6000610")]
			[Address(RVA = "0xE4A450", Offset = "0xE4A450", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F0C030]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024783]) = v38;\nL_0013:\n\treturnVal1 = this.intVariables;\n\tv40 = this.intVariables == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_002B;\n\tgoto L_0025;\n\tv59 = *([v44 @ X0_v4 (Il2CppClass<HutongGames.Utility.Arrays`1<HutongGames.PlayMaker.FsmInt>>)+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0025;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv63 = HutongGames.Utility.Arrays`1<HutongGames.PlayMaker.FsmInt>;\nL_0025:\n\treturnVal1 = v54.Empty;\nL_002B:\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				FsmInt[] empty = intVariables;
				if (intVariables == null)
				{
					empty = Arrays<FsmInt>.Empty;
				}
				return empty;
			}
			[Token(Token = "0x6000611")]
			[Address(RVA = "0xE4EAB4", Offset = "0xE4EAB4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.intVariables = value;\n\treturn;\n")]
			set
			{
				IntVariables = value;
			}
		}

		[Token(Token = "0x170001BF")]
		public FsmBool[] BoolVariables
		{
			[Token(Token = "0x6000612")]
			[Address(RVA = "0xE4A4C4", Offset = "0xE4A4C4", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EE82B8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024784]) = v38;\nL_0013:\n\treturnVal1 = this.boolVariables;\n\tv40 = this.boolVariables == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_002B;\n\tgoto L_0025;\n\tv59 = *([v44 @ X0_v4 (Il2CppClass<HutongGames.Utility.Arrays`1<HutongGames.PlayMaker.FsmBool>>)+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0025;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv63 = HutongGames.Utility.Arrays`1<HutongGames.PlayMaker.FsmBool>;\nL_0025:\n\treturnVal1 = v54.Empty;\nL_002B:\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				FsmBool[] empty = boolVariables;
				if (boolVariables == null)
				{
					empty = Arrays<FsmBool>.Empty;
				}
				return empty;
			}
			[Token(Token = "0x6000613")]
			[Address(RVA = "0xE4EABC", Offset = "0xE4EABC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.boolVariables = value;\n\treturn;\n")]
			set
			{
				BoolVariables = value;
			}
		}

		[Token(Token = "0x170001C0")]
		public FsmString[] StringVariables
		{
			[Token(Token = "0x6000614")]
			[Address(RVA = "0xE4A538", Offset = "0xE4A538", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F0E9E8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024785]) = v38;\nL_0013:\n\treturnVal1 = this.stringVariables;\n\tv40 = this.stringVariables == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_002B;\n\tgoto L_0025;\n\tv59 = *([v44 @ X0_v4 (Il2CppClass<HutongGames.Utility.Arrays`1<HutongGames.PlayMaker.FsmString>>)+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0025;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv63 = HutongGames.Utility.Arrays`1<HutongGames.PlayMaker.FsmString>;\nL_0025:\n\treturnVal1 = v54.Empty;\nL_002B:\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				FsmString[] empty = stringVariables;
				if (stringVariables == null)
				{
					empty = Arrays<FsmString>.Empty;
				}
				return empty;
			}
			[Token(Token = "0x6000615")]
			[Address(RVA = "0xE4EAC4", Offset = "0xE4EAC4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.stringVariables = value;\n\treturn;\n")]
			set
			{
				StringVariables = value;
			}
		}

		[Token(Token = "0x170001C1")]
		public FsmVector2[] Vector2Variables
		{
			[Token(Token = "0x6000616")]
			[Address(RVA = "0xE4A5AC", Offset = "0xE4A5AC", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EA5E80]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024786]) = v38;\nL_0013:\n\treturnVal1 = this.vector2Variables;\n\tv40 = this.vector2Variables == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_002B;\n\tgoto L_0025;\n\tv59 = *([v44 @ X0_v4 (Il2CppClass<HutongGames.Utility.Arrays`1<HutongGames.PlayMaker.FsmVector2>>)+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0025;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv63 = HutongGames.Utility.Arrays`1<HutongGames.PlayMaker.FsmVector2>;\nL_0025:\n\treturnVal1 = v54.Empty;\nL_002B:\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				FsmVector2[] empty = vector2Variables;
				if (vector2Variables == null)
				{
					empty = Arrays<FsmVector2>.Empty;
				}
				return empty;
			}
			[Token(Token = "0x6000617")]
			[Address(RVA = "0xE4EACC", Offset = "0xE4EACC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.vector2Variables = value;\n\treturn;\n")]
			set
			{
				Vector2Variables = value;
			}
		}

		[Token(Token = "0x170001C2")]
		public FsmVector3[] Vector3Variables
		{
			[Token(Token = "0x6000618")]
			[Address(RVA = "0xE4A620", Offset = "0xE4A620", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EDE8C0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024787]) = v38;\nL_0013:\n\treturnVal1 = this.vector3Variables;\n\tv40 = this.vector3Variables == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_002B;\n\tgoto L_0025;\n\tv59 = *([v44 @ X0_v4 (Il2CppClass<HutongGames.Utility.Arrays`1<HutongGames.PlayMaker.FsmVector3>>)+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0025;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv63 = HutongGames.Utility.Arrays`1<HutongGames.PlayMaker.FsmVector3>;\nL_0025:\n\treturnVal1 = v54.Empty;\nL_002B:\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				FsmVector3[] empty = vector3Variables;
				if (vector3Variables == null)
				{
					empty = Arrays<FsmVector3>.Empty;
				}
				return empty;
			}
			[Token(Token = "0x6000619")]
			[Address(RVA = "0xE4EAD4", Offset = "0xE4EAD4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.vector3Variables = value;\n\treturn;\n")]
			set
			{
				Vector3Variables = value;
			}
		}

		[Token(Token = "0x170001C3")]
		public FsmRect[] RectVariables
		{
			[Token(Token = "0x600061A")]
			[Address(RVA = "0xE4A694", Offset = "0xE4A694", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EF8400]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024788]) = v38;\nL_0013:\n\treturnVal1 = this.rectVariables;\n\tv40 = this.rectVariables == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_002B;\n\tgoto L_0025;\n\tv59 = *([v44 @ X0_v4 (Il2CppClass<HutongGames.Utility.Arrays`1<HutongGames.PlayMaker.FsmRect>>)+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0025;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv63 = HutongGames.Utility.Arrays`1<HutongGames.PlayMaker.FsmRect>;\nL_0025:\n\treturnVal1 = v54.Empty;\nL_002B:\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				FsmRect[] empty = rectVariables;
				if (rectVariables == null)
				{
					empty = Arrays<FsmRect>.Empty;
				}
				return empty;
			}
			[Token(Token = "0x600061B")]
			[Address(RVA = "0xE4EADC", Offset = "0xE4EADC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.rectVariables = value;\n\treturn;\n")]
			set
			{
				RectVariables = value;
			}
		}

		[Token(Token = "0x170001C4")]
		public FsmQuaternion[] QuaternionVariables
		{
			[Token(Token = "0x600061C")]
			[Address(RVA = "0xE4A708", Offset = "0xE4A708", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EB1738]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024789]) = v38;\nL_0013:\n\treturnVal1 = this.quaternionVariables;\n\tv40 = this.quaternionVariables == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_002B;\n\tgoto L_0025;\n\tv59 = *([v44 @ X0_v4 (Il2CppClass<HutongGames.Utility.Arrays`1<HutongGames.PlayMaker.FsmQuaternion>>)+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0025;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv63 = HutongGames.Utility.Arrays`1<HutongGames.PlayMaker.FsmQuaternion>;\nL_0025:\n\treturnVal1 = v54.Empty;\nL_002B:\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				FsmQuaternion[] empty = quaternionVariables;
				if (quaternionVariables == null)
				{
					empty = Arrays<FsmQuaternion>.Empty;
				}
				return empty;
			}
			[Token(Token = "0x600061D")]
			[Address(RVA = "0xE4EAE4", Offset = "0xE4EAE4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.quaternionVariables = value;\n\treturn;\n")]
			set
			{
				QuaternionVariables = value;
			}
		}

		[Token(Token = "0x170001C5")]
		public FsmColor[] ColorVariables
		{
			[Token(Token = "0x600061E")]
			[Address(RVA = "0xE4A94C", Offset = "0xE4A94C", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EFF568]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202478A]) = v38;\nL_0013:\n\treturnVal1 = this.colorVariables;\n\tv40 = this.colorVariables == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_002B;\n\tgoto L_0025;\n\tv59 = *([v44 @ X0_v4 (Il2CppClass<HutongGames.Utility.Arrays`1<HutongGames.PlayMaker.FsmColor>>)+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0025;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv63 = HutongGames.Utility.Arrays`1<HutongGames.PlayMaker.FsmColor>;\nL_0025:\n\treturnVal1 = v54.Empty;\nL_002B:\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				FsmColor[] empty = colorVariables;
				if (colorVariables == null)
				{
					empty = Arrays<FsmColor>.Empty;
				}
				return empty;
			}
			[Token(Token = "0x600061F")]
			[Address(RVA = "0xE4EAEC", Offset = "0xE4EAEC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.colorVariables = value;\n\treturn;\n")]
			set
			{
				ColorVariables = value;
			}
		}

		[Token(Token = "0x170001C6")]
		public FsmGameObject[] GameObjectVariables
		{
			[Token(Token = "0x6000620")]
			[Address(RVA = "0xE4A77C", Offset = "0xE4A77C", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F0F618]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202478B]) = v38;\nL_0013:\n\treturnVal1 = this.gameObjectVariables;\n\tv40 = this.gameObjectVariables == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_002B;\n\tgoto L_0025;\n\tv59 = *([v44 @ X0_v4 (Il2CppClass<HutongGames.Utility.Arrays`1<HutongGames.PlayMaker.FsmGameObject>>)+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0025;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv63 = HutongGames.Utility.Arrays`1<HutongGames.PlayMaker.FsmGameObject>;\nL_0025:\n\treturnVal1 = v54.Empty;\nL_002B:\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				FsmGameObject[] empty = gameObjectVariables;
				if (gameObjectVariables == null)
				{
					empty = Arrays<FsmGameObject>.Empty;
				}
				return empty;
			}
			[Token(Token = "0x6000621")]
			[Address(RVA = "0xE4EAF4", Offset = "0xE4EAF4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObjectVariables = value;\n\treturn;\n")]
			set
			{
				GameObjectVariables = value;
			}
		}

		[Token(Token = "0x170001C7")]
		public FsmArray[] ArrayVariables
		{
			[Token(Token = "0x6000622")]
			[Address(RVA = "0xE4A9C0", Offset = "0xE4A9C0", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EBDBF8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202478C]) = v38;\nL_0013:\n\treturnVal1 = this.arrayVariables;\n\tv40 = this.arrayVariables == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_002B;\n\tgoto L_0025;\n\tv59 = *([v44 @ X0_v4 (Il2CppClass<HutongGames.Utility.Arrays`1<HutongGames.PlayMaker.FsmArray>>)+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0025;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv63 = HutongGames.Utility.Arrays`1<HutongGames.PlayMaker.FsmArray>;\nL_0025:\n\treturnVal1 = v54.Empty;\nL_002B:\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				FsmArray[] empty = arrayVariables;
				if (arrayVariables == null)
				{
					empty = Arrays<FsmArray>.Empty;
				}
				return empty;
			}
			[Token(Token = "0x6000623")]
			[Address(RVA = "0xE4EAFC", Offset = "0xE4EAFC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.arrayVariables = value;\n\treturn;\n")]
			set
			{
				ArrayVariables = value;
			}
		}

		[Token(Token = "0x170001C8")]
		public FsmEnum[] EnumVariables
		{
			[Token(Token = "0x6000624")]
			[Address(RVA = "0xE4AA34", Offset = "0xE4AA34", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F08868]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202478D]) = v38;\nL_0013:\n\treturnVal1 = this.enumVariables;\n\tv40 = this.enumVariables == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_002B;\n\tgoto L_0025;\n\tv59 = *([v44 @ X0_v4 (Il2CppClass<HutongGames.Utility.Arrays`1<HutongGames.PlayMaker.FsmEnum>>)+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0025;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv63 = HutongGames.Utility.Arrays`1<HutongGames.PlayMaker.FsmEnum>;\nL_0025:\n\treturnVal1 = v54.Empty;\nL_002B:\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				FsmEnum[] empty = enumVariables;
				if (enumVariables == null)
				{
					empty = Arrays<FsmEnum>.Empty;
				}
				return empty;
			}
			[Token(Token = "0x6000625")]
			[Address(RVA = "0xE4EB04", Offset = "0xE4EB04", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.enumVariables = value;\n\treturn;\n")]
			set
			{
				EnumVariables = value;
			}
		}

		[Token(Token = "0x170001C9")]
		public FsmObject[] ObjectVariables
		{
			[Token(Token = "0x6000626")]
			[Address(RVA = "0xE4A7F0", Offset = "0xE4A7F0", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EB23D0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202478E]) = v38;\nL_0013:\n\treturnVal1 = this.objectVariables;\n\tv40 = this.objectVariables == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_002B;\n\tgoto L_0025;\n\tv59 = *([v44 @ X0_v4 (Il2CppClass<HutongGames.Utility.Arrays`1<HutongGames.PlayMaker.FsmObject>>)+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0025;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv63 = HutongGames.Utility.Arrays`1<HutongGames.PlayMaker.FsmObject>;\nL_0025:\n\treturnVal1 = v54.Empty;\nL_002B:\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				FsmObject[] empty = objectVariables;
				if (objectVariables == null)
				{
					empty = Arrays<FsmObject>.Empty;
				}
				return empty;
			}
			[Token(Token = "0x6000627")]
			[Address(RVA = "0xE4EB0C", Offset = "0xE4EB0C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.objectVariables = value;\n\treturn;\n")]
			set
			{
				ObjectVariables = value;
			}
		}

		[Token(Token = "0x170001CA")]
		public FsmMaterial[] MaterialVariables
		{
			[Token(Token = "0x6000628")]
			[Address(RVA = "0xE4A864", Offset = "0xE4A864", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EDA778]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202478F]) = v38;\nL_0013:\n\treturnVal1 = this.materialVariables;\n\tv40 = this.materialVariables == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_002B;\n\tgoto L_0025;\n\tv59 = *([v44 @ X0_v4 (Il2CppClass<HutongGames.Utility.Arrays`1<HutongGames.PlayMaker.FsmMaterial>>)+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0025;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv63 = HutongGames.Utility.Arrays`1<HutongGames.PlayMaker.FsmMaterial>;\nL_0025:\n\treturnVal1 = v54.Empty;\nL_002B:\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				FsmMaterial[] empty = materialVariables;
				if (materialVariables == null)
				{
					empty = Arrays<FsmMaterial>.Empty;
				}
				return empty;
			}
			[Token(Token = "0x6000629")]
			[Address(RVA = "0xE4EB14", Offset = "0xE4EB14", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.materialVariables = value;\n\treturn;\n")]
			set
			{
				MaterialVariables = value;
			}
		}

		[Token(Token = "0x170001CB")]
		public FsmTexture[] TextureVariables
		{
			[Token(Token = "0x600062A")]
			[Address(RVA = "0xE4A8D8", Offset = "0xE4A8D8", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EE5108]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024790]) = v38;\nL_0013:\n\treturnVal1 = this.textureVariables;\n\tv40 = this.textureVariables == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_002B;\n\tgoto L_0025;\n\tv59 = *([v44 @ X0_v4 (Il2CppClass<HutongGames.Utility.Arrays`1<HutongGames.PlayMaker.FsmTexture>>)+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0025;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv63 = HutongGames.Utility.Arrays`1<HutongGames.PlayMaker.FsmTexture>;\nL_0025:\n\treturnVal1 = v54.Empty;\nL_002B:\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				FsmTexture[] empty = textureVariables;
				if (textureVariables == null)
				{
					empty = Arrays<FsmTexture>.Empty;
				}
				return empty;
			}
			[Token(Token = "0x600062B")]
			[Address(RVA = "0xE4EB1C", Offset = "0xE4EB1C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.textureVariables = value;\n\treturn;\n")]
			set
			{
				TextureVariables = value;
			}
		}

		[Token(Token = "0x6000602")]
		[Address(RVA = "0xE4A1E4", Offset = "0xE4A1E4", Length = "0x1F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EDD8C0]);\n\tv21 = *([v20 @ X8_v11]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202477B]) = v40;\nL_0017:\n\tv44 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.NamedVariable>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.NamedVariable>::.ctor(v44);\n\tv50 = HutongGames.PlayMaker.FsmVariables::get_FloatVariables(this);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.NamedVariable>::AddRange(v44, v50);\n\tv60 = HutongGames.PlayMaker.FsmVariables::get_IntVariables(this);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.NamedVariable>::AddRange(v44, v60);\n\tv83 = HutongGames.PlayMaker.FsmVariables::get_BoolVariables(this);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.NamedVariable>::AddRange(v44, v83);\n\tv88 = HutongGames.PlayMaker.FsmVariables::get_StringVariables(this);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.NamedVariable>::AddRange(v44, v88);\n\tv93 = HutongGames.PlayMaker.FsmVariables::get_Vector2Variables(this);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.NamedVariable>::AddRange(v44, v93);\n\tv98 = HutongGames.PlayMaker.FsmVariables::get_Vector3Variables(this);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.NamedVariable>::AddRange(v44, v98);\n\tv103 = HutongGames.PlayMaker.FsmVariables::get_RectVariables(this);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.NamedVariable>::AddRange(v44, v103);\n\tv108 = HutongGames.PlayMaker.FsmVariables::get_QuaternionVariables(this);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.NamedVariable>::AddRange(v44, v108);\n\tv113 = HutongGames.PlayMaker.FsmVariables::get_GameObjectVariables(this);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.NamedVariable>::AddRange(v44, v113);\n\tv118 = HutongGames.PlayMaker.FsmVariables::get_ObjectVariables(this);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.NamedVariable>::AddRange(v44, v118);\n\tv123 = HutongGames.PlayMaker.FsmVariables::get_MaterialVariables(this);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.NamedVariable>::AddRange(v44, v123);\n\tv128 = HutongGames.PlayMaker.FsmVariables::get_TextureVariables(this);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.NamedVariable>::AddRange(v44, v128);\n\tv133 = HutongGames.PlayMaker.FsmVariables::get_ColorVariables(this);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.NamedVariable>::AddRange(v44, v133);\n\tv138 = HutongGames.PlayMaker.FsmVariables::get_ArrayVariables(this);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.NamedVariable>::AddRange(v44, v138);\n\tv143 = HutongGames.PlayMaker.FsmVariables::get_EnumVariables(this);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.NamedVariable>::AddRange(v44, v143);\n\treturnVal2 = System.Collections.Generic.List`1<HutongGames.PlayMaker.NamedVariable>::ToArray(v44);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 96 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public NamedVariable[] GetAllNamedVariables()
		{
			List<NamedVariable> list = new List<NamedVariable>();
			FsmFloat[] collection = FloatVariables;
			list.AddRange(collection);
			FsmInt[] collection2 = IntVariables;
			list.AddRange(collection2);
			FsmBool[] collection3 = BoolVariables;
			list.AddRange(collection3);
			FsmString[] collection4 = StringVariables;
			list.AddRange(collection4);
			FsmVector2[] collection5 = Vector2Variables;
			list.AddRange(collection5);
			FsmVector3[] collection6 = Vector3Variables;
			list.AddRange(collection6);
			FsmRect[] collection7 = RectVariables;
			list.AddRange(collection7);
			FsmQuaternion[] collection8 = QuaternionVariables;
			list.AddRange(collection8);
			FsmGameObject[] collection9 = GameObjectVariables;
			list.AddRange(collection9);
			FsmObject[] collection10 = ObjectVariables;
			list.AddRange(collection10);
			FsmMaterial[] collection11 = MaterialVariables;
			list.AddRange(collection11);
			FsmTexture[] collection12 = TextureVariables;
			list.AddRange(collection12);
			FsmColor[] collection13 = ColorVariables;
			list.AddRange(collection13);
			FsmArray[] collection14 = ArrayVariables;
			list.AddRange(collection14);
			FsmEnum[] collection15 = EnumVariables;
			list.AddRange(collection15);
			return list.ToArray();
		}

		[Token(Token = "0x6000603")]
		[Address(RVA = "0xE4AAA8", Offset = "0xE4AAA8", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EE13F0]);\n\tv19 = *([v18 @ X8_v14]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202477C]) = v38;\nL_0014:\n\tv40 = HutongGames.PlayMaker.FsmVariables::GetAllNamedVariables(this);\n\tv46 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.NamedVariable>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.NamedVariable>::.ctor(v46, v40);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.NamedVariable>::Sort(v46);\n\treturnVal2 = System.Collections.Generic.List`1<HutongGames.PlayMaker.NamedVariable>::ToArray(v46);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public NamedVariable[] GetAllNamedVariablesSorted()
		{
			//IL_0038: Expected I4, but got O
			NamedVariable[] allNamedVariables = GetAllNamedVariables();
			List<NamedVariable> list = new List<NamedVariable>((int)allNamedVariables);
			list.Sort();
			return list.ToArray();
		}

		[Token(Token = "0x6000604")]
		[Address(RVA = "0xE4AB50", Offset = "0xE4AB50", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv21 = *([1F09B68]);\n\tv22 = *([v21 @ X8_v14]);\n\tv23 = \"il2cpp_codegen_initialize_method\"(v22, type, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202477D]) = v40;\nL_0015:\n\tv41 = type + 1;\n\tv42 = v41 < 0xF;\n\tv43 = ~v42;\n\tv44 = v41 - 0xF;\n\tv46 = v44 == 0;\n\tv51 = ~v46;\n\tv52 = v43 & v51;\n\tif (v52) goto L_0066;\n\tv54 = 0x181C000 + 0x714;\n\tv56 = *([v54 @ X9_v2 (System.Int32)+v41 @ X8_v3 (System.Int32)*4]) + v54;\n\t// 38 IndirectJump v56 @ X8_v11, v38 @ X0_v1 (HutongGames.PlayMaker.FsmVariables), v38 @ X0_v1 (HutongGames.PlayMaker.FsmVariables), type @ X1 (HutongGames.PlayMaker.VariableType), methodInfo @ X2 (Il2CppMethodInfo), v25 @ X3, v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\n\tX0 = X19;\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX21 = stack[0];\n\t// 45 ShiftStack 48\n\tX0 = HutongGames.PlayMaker.FsmVariables::GetAllNamedVariables(X0, X1);\n\treturn X0;\n\tX0 = X19;\n\tX0 = HutongGames.PlayMaker.FsmVariables::get_FloatVariables(X0, X1);\n\tgoto L_005C;\n\tX0 = X19;\n\tX0 = HutongGames.PlayMaker.FsmVariables::get_IntVariables(X0, X1);\n\tgoto L_005C;\n\tX0 = X19;\n\tX0 = HutongGames.PlayMaker.FsmVariables::get_BoolVariables(X0, X1);\n\tgoto L_005C;\n\tX0 = X19;\n\tX0 = HutongGames.PlayMaker.FsmVariables::get_GameObjectVariables(X0, X1);\n\tgoto L_005C;\n\tX0 = X19;\n\tX0 = HutongGames.PlayMaker.FsmVariables::get_StringVariables(X0, X1);\n\tgoto L_005C;\n\tX0 = X19;\n\tX0 = HutongGames.PlayMaker.FsmVariables::get_Vector2Variables(X0, X1);\n\tgoto L_005C;\n\tX0 = X19;\n\tX0 = HutongGames.PlayMaker.FsmVariables::get_Vector3Variables(X0, X1);\n\tgoto L_005C;\n\tX0 = X19;\n\tX0 = HutongGames.PlayMaker.FsmVariables::get_ColorVariables(X0, X1);\n\tgoto L_005C;\n\tX0 = X19;\n\tX0 = HutongGames.PlayMaker.FsmVariables::get_RectVariables(X0, X1);\n\tgoto L_005C;\n\tX0 = X19;\n\tX0 = HutongGames.PlayMaker.FsmVariables::get_MaterialVariables(X0, X1);\n\tgoto L_005C;\n\tX0 = X19;\n\tX0 = HutongGames.PlayMaker.FsmVariables::get_TextureVariables(X0, X1);\n\tgoto L_005C;\n\tX0 = X19;\n\tX0 = HutongGames.PlayMaker.FsmVariables::get_QuaternionVariables(X0, X1);\n\tgoto L_005C;\n\tX0 = X19;\n\tX0 = HutongGames.PlayMaker.FsmVariables::get_ObjectVariables(X0, X1);\n\tgoto L_005C;\n\tX0 = X19;\n\tX0 = HutongGames.PlayMaker.FsmVariables::get_ArrayVariables(X0, X1);\n\tgoto L_005C;\n\tX0 = X19;\n\tX0 = HutongGames.PlayMaker.FsmVariables::get_EnumVariables(X0, X1);\nL_005C:\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX21 = stack[0];\n\t// 97 ShiftStack 48\n\treturn X0;\nL_0066:\n\tv60 = new System.ArgumentOutOfRangeException();\n\tSystem.ArgumentOutOfRangeException::.ctor(v60, \"type\");\n\tthrow v60;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public NamedVariable[] GetNamedVariables(VariableType type)
		{
			//IL_0029: Expected O, but got I
			int num = (int)(type + 1);
			bool flag = num < 15;
			bool flag2 = !flag;
			int num2 = num - 15;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = 25280512 + 1812;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X9_v2 (System.Int32)+v41 @ X8_v3 (System.Int32)*4]");
				object obj = 0L + (long)num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v56 @ X8_v11 (should have been resolved before IL gen)");
			}
			ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("type");
			throw ex;
		}

		[Token(Token = "0x6000605")]
		[Address(RVA = "0xE4ACC0", Offset = "0xE4ACC0", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EC3E48]);\n\tv23 = *([v22 @ X8_v14]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, type, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202477E]) = v41;\nL_0017:\n\tv44 = HutongGames.PlayMaker.FsmVariables::GetNamedVariables(this, type);\n\tv50 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.NamedVariable>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.NamedVariable>::.ctor(v50, v44);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.NamedVariable>::Sort(v50);\n\treturnVal2 = System.Collections.Generic.List`1<HutongGames.PlayMaker.NamedVariable>::ToArray(v50);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public NamedVariable[] GetNamedVariablesSorted(VariableType type)
		{
			//IL_003c: Expected I4, but got O
			NamedVariable[] namedVariables = GetNamedVariables(type);
			List<NamedVariable> list = new List<NamedVariable>((int)namedVariables);
			list.Sort();
			return list.ToArray();
		}

		[Token(Token = "0x6000606")]
		[Address(RVA = "0xE4AD78", Offset = "0xE4AD78", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = HutongGames.PlayMaker.FsmVariables::GetAllNamedVariables(this);\n\tv133 = v14.Length;\n\tv29 = v14.Length < 1;\n\tif (v29) goto L_FFFFFFFF;\nL_001A:\n\tv136 = v39 < v133;\n\tv65 = ~v136;\n\tif (v65) goto L_0049;\n\tv151 = v14[v39 @ X21_v6 (System.Int32)];\n\tv120 = System.String::op_Equality(v151.name, variableName);\n\tv190 = v120 == 0;\n\tv118 = ~v190;\n\tif (v118) goto L_FFFFFFFF;\n\tv133 = v14.Length;\n\tv39 = v39 + 1;\n\tv98 = v39 < v14.Length;\n\tif (v98) goto L_001A;\n\tgoto L_0048;\nL_0048:\n\treturn returnVal2;\nL_0049:\n\tv182 = new System.IndexOutOfRangeException();\n\tthrow v182;\n\tv73 = new System.NullReferenceException();\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool Contains(string variableName)
		{
			NamedVariable[] allNamedVariables = GetAllNamedVariables();
			int num = allNamedVariables.Length;
			if (allNamedVariables.Length >= 1)
			{
				int num2 = 0;
				do
				{
					if (num2 < num)
					{
						NamedVariable namedVariable = allNamedVariables[num2];
						if (!(namedVariable.Name == variableName))
						{
							num = allNamedVariables.Length;
							num2++;
							continue;
						}
						return true;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				while (num2 < allNamedVariables.Length);
			}
			return false;
		}

		[Token(Token = "0x6000607")]
		[Address(RVA = "0xE4AE18", Offset = "0xE4AE18", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = HutongGames.PlayMaker.FsmVariables::GetAllNamedVariables(this);\n\tv24 = v10.Length < 1;\n\tif (v24) goto L_FFFFFFFF;\nL_0017:\n\tv118 = v37 < v10.Length;\n\tv64 = ~v118;\n\tif (v64) goto L_0043;\n\tv132 = v10[v37 @ X9_v5 (System.Int32)] == variable;\n\tif (v132) goto L_FFFFFFFF;\n\tv37 = v37 + 1;\n\tv92 = v37 < v10.Length;\n\tif (v92) goto L_0017;\n\tgoto L_0042;\nL_0042:\n\treturn returnVal2;\nL_0043:\n\tv165 = new System.IndexOutOfRangeException();\n\tthrow v165;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool Contains(NamedVariable variable)
		{
			NamedVariable[] allNamedVariables = GetAllNamedVariables();
			if (allNamedVariables.Length >= 1)
			{
				int num = 0;
				do
				{
					if (num < allNamedVariables.Length)
					{
						if (allNamedVariables[num] != variable)
						{
							num++;
							continue;
						}
						return true;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				while (num < allNamedVariables.Length);
			}
			return false;
		}

		[Token(Token = "0x6000608")]
		[Address(RVA = "0xE4AE90", Offset = "0xE4AE90", Length = "0x464")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv24 = *([1EF94A0]);\n\tv25 = *([v24 @ X8_v67]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, ofType, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202477F]) = v43;\nL_001F:\n\tgoto L_0027;\n\tv53 = *([v47 @ X0_v2+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_0027;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v47, ofType, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0027:\n\tv62 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmFloat);\n\tv67 = v62 == ofType;\n\tif (v67) goto L_01A5;\n\tgoto L_0041;\n\tv81 = *([v73 @ X0_v9+E0]);\n\tv82 = v81 == 0;\n\tv83 = ~v82;\n\tif (v83) goto L_0041;\n\tv85 = \"il2cpp_codegen_runtime_class_init\"(v73, v61, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0041:\n\tv90 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmInt);\n\tv95 = v90 == ofType;\n\tif (v95) goto L_01A8;\n\tgoto L_005B;\n\tv312 = *([v307 @ X0_v15+E0]);\n\tv313 = v312 == 0;\n\tv314 = ~v313;\n\tif (v314) goto L_005B;\n\tv316 = \"il2cpp_codegen_runtime_class_init\"(v307, v89, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_005B:\n\tv318 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmBool);\n\tv172 = v318 == ofType;\n\tif (v172) goto L_01AB;\n\tgoto L_0075;\n\tv326 = *([v321 @ X0_v21+E0]);\n\tv327 = v326 == 0;\n\tv328 = ~v327;\n\tif (v328) goto L_0075;\n\tv330 = \"il2cpp_codegen_runtime_class_init\"(v321, v229, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0075:\n\tv332 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmString);\n\tv173 = v332 == ofType;\n\tif (v173) goto L_01AE;\n\tgoto L_008F;\n\tv340 = *([v335 @ X0_v27+E0]);\n\tv341 = v340 == 0;\n\tv342 = ~v341;\n\tif (v342) goto L_008F;\n\tv344 = \"il2cpp_codegen_runtime_class_init\"(v335, v230, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_008F:\n\tv346 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmVector2);\n\tv174 = v346 == ofType;\n\tif (v174) goto L_01B1;\n\tgoto L_00A9;\n\tv354 = *([v349 @ X0_v33+E0]);\n\tv355 = v354 == 0;\n\tv356 = ~v355;\n\tif (v356) goto L_00A9;\n\tv358 = \"il2cpp_codegen_runtime_class_init\"(v349, v231, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_00A9:\n\tv360 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmVector3);\n\tv175 = v360 == ofType;\n\tif (v175) goto L_01B4;\n\tgoto L_00C3;\n\tv368 = *([v363 @ X0_v39+E0]);\n\tv369 = v368 == 0;\n\tv370 = ~v369;\n\tif (v370) goto L_00C3;\n\tv372 = \"il2cpp_codegen_runtime_class_init\"(v363, v232, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_00C3:\n\tv374 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmRect);\n\tv176 = v374 == ofType;\n\tif (v176) goto L_01B7;\n\tgoto L_00DD;\n\tv382 = *([v377 @ X0_v45+E0]);\n\tv383 = v382 == 0;\n\tv384 = ~v383;\n\tif (v384) goto L_00DD;\n\tv386 = \"il2cpp_codegen_runtime_class_init\"(v377, v233, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_00DD:\n\tv388 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmQuaternion);\n\tv177 = v388 == ofType;\n\tif (v177) goto L_01BA;\n\tgoto L_00F7;\n\tv396 = *([v391 @ X0_v51+E0]);\n\tv397 = v396 == 0;\n\tv398 = ~v397;\n\tif (v398) goto L_00F7;\n\tv400 = \"il2cpp_codegen_runtime_class_init\"(v391, v234, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_00F7:\n\tv402 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmObject);\n\tv178 = v402 == ofType;\n\tif (v178) goto L_01BD;\n\tgoto L_0111;\n\tv410 = *([v405 @ X0_v57+E0]);\n\tv411 = v410 == 0;\n\tv412 = ~v411;\n\tif (v412) goto L_0111;\n\tv414 = \"il2cpp_codegen_runtime_class_init\"(v405, v235, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0111:\n\tv416 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmMaterial);\n\tv179 = v416 == ofType;\n\tif (v179) goto L_01C0;\n\tgoto L_012B;\n\tv424 = *([v419 @ X0_v63+E0]);\n\tv425 = v424 == 0;\n\tv426 = ~v425;\n\tif (v426) goto L_012B;\n\tv428 = \"il2cpp_codegen_runtime_class_init\"(v419, v236, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_012B:\n\tv430 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmTexture);\n\tv180 = v430 == ofType;\n\tif (v180) goto L_01C3;\n\tgoto L_0145;\n\tv438 = *([v433 @ X0_v69+E0]);\n\tv439 = v438 == 0;\n\tv440 = ~v439;\n\tif (v440) goto L_0145;\n\tv442 = \"il2cpp_codegen_runtime_class_init\"(v433, v237, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0145:\n\tv444 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmColor);\n\tv181 = v444 == ofType;\n\tif (v181) goto L_01C6;\n\tgoto L_015F;\n\tv452 = *([v447 @ X0_v75+E0]);\n\tv453 = v452 == 0;\n\tv454 = ~v453;\n\tif (v454) goto L_015F;\n\tv456 = \"il2cpp_codegen_runtime_class_init\"(v447, v238, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_015F:\n\tv458 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmGameObject);\n\tv182 = v458 == ofType;\n\tif (v182) goto L_01C9;\n\tgoto L_0179;\n\tv466 = *([v461 @ X0_v81+E0]);\n\tv467 = v466 == 0;\n\tv468 = ~v467;\n\tif (v468) goto L_0179;\n\tv470 = \"il2cpp_codegen_runtime_class_init\"(v461, v239, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0179:\n\tv472 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmArray);\n\tv183 = v472 == ofType;\n\tif (v183) goto L_01CC;\n\tgoto L_0193;\n\tv480 = *([v475 @ X0_v87+E0]);\n\tv481 = v480 == 0;\n\tv482 = ~v481;\n\tif (v482) goto L_0193;\n\tv484 = \"il2cpp_codegen_runtime_class_init\"(v475, v240, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0193:\n\tv486 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmEnum);\n\tv171 = v486 == ofType;\n\tif (v171) goto L_01CF;\n\t// 418 NewArr returnVal1 @ X0_v6 (HutongGames.PlayMaker.NamedVariable[]), typeof(HutongGames.PlayMaker.NamedVariable[]), 0\n\tgoto L_01D7;\nL_01A5:\n\tv80 = HutongGames.PlayMaker.FsmVariables::get_FloatVariables(this);\n\tgoto L_01D7;\nL_01A8:\n\tv244 = HutongGames.PlayMaker.FsmVariables::get_IntVariables(this);\n\tgoto L_01D7;\nL_01AB:\n\tv245 = HutongGames.PlayMaker.FsmVariables::get_BoolVariables(this);\n\tgoto L_01D7;\nL_01AE:\n\tv246 = HutongGames.PlayMaker.FsmVariables::get_StringVariables(this);\n\tgoto L_01D7;\nL_01B1:\n\tv247 = HutongGames.PlayMaker.FsmVariables::get_Vector2Variables(this);\n\tgoto L_01D7;\nL_01B4:\n\tv248 = HutongGames.PlayMaker.FsmVariables::get_Vector3Variables(this);\n\tgoto L_01D7;\nL_01B7:\n\tv249 = HutongGames.PlayMaker.FsmVariables::get_RectVariables(this);\n\tgoto L_01D7;\nL_01BA:\n\tv250 = HutongGames.PlayMaker.FsmVariables::get_QuaternionVariables(this);\n\tgoto L_01D7;\nL_01BD:\n\tv251 = HutongGames.PlayMaker.FsmVariables::get_ObjectVariables(this);\n\tgoto L_01D7;\nL_01C0:\n\tv252 = HutongGames.PlayMaker.FsmVariables::get_MaterialVariables(this);\n\tgoto L_01D7;\nL_01C3:\n\tv253 = HutongGames.PlayMaker.FsmVariables::get_TextureVariables(this);\n\tgoto L_01D7;\nL_01C6:\n\tv254 = HutongGames.PlayMaker.FsmVariables::get_ColorVariables(this);\n\tgoto L_01D7;\nL_01C9:\n\tv255 = HutongGames.PlayMaker.FsmVariables::get_GameObjectVariables(this);\n\tgoto L_01D7;\nL_01CC:\n\tv256 = HutongGames.PlayMaker.FsmVariables::get_ArrayVariables(this);\n\tgoto L_01D7;\nL_01CF:\n\tv242 = HutongGames.PlayMaker.FsmVariables::get_EnumVariables(this);\nL_01D7:\n\treturn returnVal1;\n// 299 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public NamedVariable[] GetNames(Type ofType)
		{
			Type typeFromHandle = typeof(FsmFloat);
			if ((object)typeFromHandle != ofType)
			{
				Type typeFromHandle2 = typeof(FsmInt);
				if ((object)typeFromHandle2 != ofType)
				{
					Type typeFromHandle3 = typeof(FsmBool);
					if ((object)typeFromHandle3 != ofType)
					{
						Type typeFromHandle4 = typeof(FsmString);
						if ((object)typeFromHandle4 != ofType)
						{
							Type typeFromHandle5 = typeof(FsmVector2);
							if ((object)typeFromHandle5 != ofType)
							{
								Type typeFromHandle6 = typeof(FsmVector3);
								if ((object)typeFromHandle6 != ofType)
								{
									Type typeFromHandle7 = typeof(FsmRect);
									if ((object)typeFromHandle7 != ofType)
									{
										Type typeFromHandle8 = typeof(FsmQuaternion);
										if ((object)typeFromHandle8 != ofType)
										{
											Type typeFromHandle9 = typeof(FsmObject);
											if ((object)typeFromHandle9 != ofType)
											{
												Type typeFromHandle10 = typeof(FsmMaterial);
												if ((object)typeFromHandle10 != ofType)
												{
													Type typeFromHandle11 = typeof(FsmTexture);
													if ((object)typeFromHandle11 != ofType)
													{
														Type typeFromHandle12 = typeof(FsmColor);
														if ((object)typeFromHandle12 != ofType)
														{
															Type typeFromHandle13 = typeof(FsmGameObject);
															if ((object)typeFromHandle13 != ofType)
															{
																Type typeFromHandle14 = typeof(FsmArray);
																if ((object)typeFromHandle14 != ofType)
																{
																	Type typeFromHandle15 = typeof(FsmEnum);
																	if ((object)typeFromHandle15 != ofType)
																	{
																		return new NamedVariable[0];
																	}
																	return EnumVariables;
																}
																return ArrayVariables;
															}
															return GameObjectVariables;
														}
														return ColorVariables;
													}
													return TextureVariables;
												}
												return MaterialVariables;
											}
											return ObjectVariables;
										}
										return QuaternionVariables;
									}
									return RectVariables;
								}
								return Vector3Variables;
							}
							return Vector2Variables;
						}
						return StringVariables;
					}
					return BoolVariables;
				}
				return IntVariables;
			}
			return FloatVariables;
		}

		[Token(Token = "0x6000609")]
		[Address(RVA = "0xE4B2F4", Offset = "0xE4B2F4", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1ED2950]);\n\tv21 = *([v20 @ X8_v15]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2024780]) = v40;\nL_0018:\n\t// 24 NewArr v45 @ X0_v3 (System.String[]), typeof(System.String[]), 1\n\tv51 = \"\" == 0;\n\tif (v51) goto L_0027;\n\t// 35 IsInst v55 @ X0_v14, typeof(System.String), \"\"\nL_0027:\n\tv62 = v45.Length == 0;\n\tif (v62) goto L_003D;\n\tv45[0] = \"\";\n\tthis.categories = v45;\n\t// 48 NewArr v74 @ X0_v12 (System.Int32[]), typeof(System.Int32[]), 0\n\tthis.variableCategoryIDs = v74;\n\tSystem.Object::.ctor(this);\n\treturn;\n\tv52 = new System.NullReferenceException();\nL_003D:\n\tv68 = new System.IndexOutOfRangeException();\n\tgoto L_0042;\n\tv75 = new System.ArrayTypeMismatchException();\nL_0042:\n\tthrow v85;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmVariables()
		{
			string[] array = new string[1];
			if ("" != null)
			{
				object obj = "" as string;
			}
			if (array.Length != 0)
			{
				array[0] = "";
				Categories = array;
				int[] categoryIDs = new int[0];
				CategoryIDs = categoryIDs;
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600060A")]
		[Address(RVA = "0xE4B3C8", Offset = "0xE4B3C8", Length = "0xCE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv36 = *([1EF4708]);\n\tv37 = *([v36 @ X8_v194]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, source, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([2024781]) = v55;\nL_0020:\n\t// 32 NewArr v60 @ X0_v3 (System.String[]), typeof(System.String[]), 1\n\tv66 = \"\" == 0;\n\tif (v66) goto L_002F;\n\t// 43 IsInst v135 @ X0_v172, typeof(System.String), \"\"\nL_002F:\n\tv142 = v60.Length == 0;\n\tif (v142) goto L_05B0;\n\tv60[0] = \"\";\n\tthis.categories = v60;\n\t// 56 NewArr v148 @ X0_v15 (System.Int32[]), typeof(System.Int32[]), 0\n\tthis.variableCategoryIDs = v148;\n\tSystem.Object::.ctor(this);\n\tv1045 = source == 0;\n\tif (v1045) goto L_05AF;\n\tv1046 = source.floatVariables;\n\tv1047 = source.floatVariables == 0;\n\tif (v1047) goto L_008D;\n\t// 70 NewArr v1109 @ X0_v165 (HutongGames.PlayMaker.FsmFloat[]), typeof(HutongGames.PlayMaker.FsmFloat[]), v1046.Length\n\tthis.floatVariables = v1109;\n\tv813 = source.floatVariables;\nL_0058:\n\tv150 = v608 >= v813.Length;\n\tif (v150) goto L_008D;\n\tv1672 = v608 < v813.Length;\n\tv571 = ~v1672;\n\tif (v571) goto L_05B0;\n\tv213 = this.floatVariables;\n\tv1479 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v1479, v813[v608 @ X25_v69 (System.Int32)]);\n\tv1799 = v1479 == 0;\n\tif (v1799) goto L_007A;\n\t// 118 IsInst v985 @ X0_v171, typeof(HutongGames.PlayMaker.FsmFloat), v1479 @ X0_v168 (HutongGames.PlayMaker.FsmFloat)\nL_007A:\n\tv1834 = v608 < v213.Length;\n\tv572 = ~v1834;\n\tif (v572) goto L_05B0;\n\tv213[v608 @ X25_v69 (System.Int32)] = v1479;\n\tv813 = source.floatVariables;\n\tv608 = v608 + 1;\n\tv1869 = source.floatVariables == 0;\n\tv1511 = ~v1869;\n\tif (v1511) goto L_0058;\n\tgoto L_05A1;\nL_008D:\n\tv1140 = source.intVariables;\n\tv1141 = source.intVariables == 0;\n\tif (v1141) goto L_00DB;\n\t// 148 NewArr v1148 @ X0_v157 (HutongGames.PlayMaker.FsmInt[]), typeof(HutongGames.PlayMaker.FsmInt[]), v1140.Length\n\tthis.intVariables = v1148;\n\tv815 = source.intVariables;\nL_00A6:\n\tv151 = v609 >= v815.Length;\n\tif (v151) goto L_00DB;\n\tv1704 = v609 < v815.Length;\n\tv573 = ~v1704;\n\tif (v573) goto L_05B0;\n\tv215 = this.intVariables;\n\tv1480 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v1480, v815[v609 @ X25_v66 (System.Int32)]);\n\tv1835 = v1480 == 0;\n\tif (v1835) goto L_00C8;\n\t// 196 IsInst v986 @ X0_v163, typeof(HutongGames.PlayMaker.FsmInt), v1480 @ X0_v160 (HutongGames.PlayMaker.FsmInt)\nL_00C8:\n\tv1872 = v609 < v215.Length;\n\tv574 = ~v1872;\n\tif (v574) goto L_05B0;\n\tv215[v609 @ X25_v66 (System.Int32)] = v1480;\n\tv815 = source.intVariables;\n\tv609 = v609 + 1;\n\tv1908 = source.intVariables == 0;\n\tv1514 = ~v1908;\n\tif (v1514) goto L_00A6;\n\tgoto L_05A1;\nL_00DB:\n\tv1179 = source.boolVariables;\n\tv1180 = source.boolVariables == 0;\n\tif (v1180) goto L_0129;\n\t// 226 NewArr v1481 @ X0_v149 (HutongGames.PlayMaker.FsmBool[]), typeof(HutongGames.PlayMaker.FsmBool[]), v1179.Length\n\tthis.boolVariables = v1481;\n\tv817 = source.boolVariables;\nL_00F4:\n\tv152 = v610 >= v817.Length;\n\tif (v152) goto L_0129;\n\tv1736 = v610 < v817.Length;\n\tv575 = ~v1736;\n\tif (v575) goto L_05B0;\n\tv217 = this.boolVariables;\n\tv1482 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v1482, v817[v610 @ X25_v63 (System.Int32)]);\n\tv1873 = v1482 == 0;\n\tif (v1873) goto L_0116;\n\t// 274 IsInst v987 @ X0_v155, typeof(HutongGames.PlayMaker.FsmBool), v1482 @ X0_v152 (HutongGames.PlayMaker.FsmBool)\nL_0116:\n\tv1911 = v610 < v217.Length;\n\tv576 = ~v1911;\n\tif (v576) goto L_05B0;\n\tv217[v610 @ X25_v63 (System.Int32)] = v1482;\n\tv817 = source.boolVariables;\n\tv610 = v610 + 1;\n\tv1947 = source.boolVariables == 0;\n\tv1517 = ~v1947;\n\tif (v1517) goto L_00F4;\n\tgoto L_05A1;\nL_0129:\n\tv1640 = source.gameObjectVariables;\n\tv1641 = source.gameObjectVariables == 0;\n\tif (v1641) goto L_0177;\n\t// 304 NewArr v1483 @ X0_v141 (HutongGames.PlayMaker.FsmGameObject[]), typeof(HutongGames.PlayMaker.FsmGameObject[]), v1640.Length\n\tthis.gameObjectVariables = v1483;\n\tv819 = source.gameObjectVariables;\nL_0142:\n\tv153 = v611 >= v819.Length;\n\tif (v153) goto L_0177;\n\tv1768 = v611 < v819.Length;\n\tv577 = ~v1768;\n\tif (v577) goto L_05B0;\n\tv219 = this.gameObjectVariables;\n\tv1484 = new HutongGames.PlayMaker.FsmGameObject();\n\tHutongGames.PlayMaker.FsmGameObject::.ctor(v1484, v819[v611 @ X25_v60 (System.Int32)]);\n\tv1912 = v1484 == 0;\n\tif (v1912) goto L_0164;\n\t// 352 IsInst v988 @ X0_v147, typeof(HutongGames.PlayMaker.FsmGameObject), v1484 @ X0_v144 (HutongGames.PlayMaker.FsmGameObject)\nL_0164:\n\tv1950 = v611 < v219.Length;\n\tv578 = ~v1950;\n\tif (v578) goto L_05B0;\n\tv219[v611 @ X25_v60 (System.Int32)] = v1484;\n\tv819 = source.gameObjectVariables;\n\tv611 = v611 + 1;\n\tv1986 = source.gameObjectVariables == 0;\n\tv1520 = ~v1986;\n\tif (v1520) goto L_0142;\n\tgoto L_05A1;\nL_0177:\n\tv1670 = source.colorVariables;\n\tv1671 = source.colorVariables == 0;\n\tif (v1671) goto L_01C5;\n\t// 382 NewArr v1485 @ X0_v133 (HutongGames.PlayMaker.FsmColor[]), typeof(HutongGames.PlayMaker.FsmColor[]), v1670.Length\n\tthis.colorVariables = v1485;\n\tv821 = source.colorVariables;\nL_0190:\n\tv154 = v612 >= v821.Length;\n\tif (v154) goto L_01C5;\n\tv1801 = v612 < v821.Length;\n\tv579 = ~v1801;\n\tif (v579) goto L_05B0;\n\tv221 = this.colorVariables;\n\tv1486 = new HutongGames.PlayMaker.FsmColor();\n\tHutongGames.PlayMaker.FsmColor::.ctor(v1486, v821[v612 @ X25_v57 (System.Int32)]);\n\tv1951 = v1486 == 0;\n\tif (v1951) goto L_01B2;\n\t// 430 IsInst v989 @ X0_v139, typeof(HutongGames.PlayMaker.FsmColor), v1486 @ X0_v136 (HutongGames.PlayMaker.FsmColor)\nL_01B2:\n\tv1989 = v612 < v221.Length;\n\tv580 = ~v1989;\n\tif (v580) goto L_05B0;\n\tv221[v612 @ X25_v57 (System.Int32)] = v1486;\n\tv821 = source.colorVariables;\n\tv612 = v612 + 1;\n\tv2026 = source.colorVariables == 0;\n\tv1523 = ~v2026;\n\tif (v1523) goto L_0190;\n\tgoto L_05A1;\nL_01C5:\n\tv1701 = source.vector2Variables;\n\tv1702 = source.vector2Variables == 0;\n\tif (v1702) goto L_0218;\n\t// 460 NewArr v1487 @ X0_v125 (HutongGames.PlayMaker.FsmVector2[]), typeof(HutongGames.PlayMaker.FsmVector2[]), v1701.Length\n\tthis.vector2Variables = v1487;\n\tv823 = source.vector2Variables;\nL_01DE:\n\tv155 = v613 >= v823.Length;\n\tif (v155) goto L_0218;\n\tv1837 = v613 < v823.Length;\n\tv581 = ~v1837;\n\tif (v581) goto L_05B0;\n\tv223 = this.vector2Variables;\n\tv717 = v823[v613 @ X25_v54 (System.Int32)];\n\tv1507 = new HutongGames.PlayMaker.FsmVector2();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v1507, v823[v613 @ X25_v54 (System.Int32)]);\n\tv1952 = v823[v613 @ X25_v54 (System.Int32)] == 0;\n\tif (v1952) goto L_01FC;\n\tv1507.value = *([v717 @ X22_v51 (HutongGames.PlayMaker.NamedVariable)+38]);\n\tv1507.value.y = *([v717 @ X22_v51 (HutongGames.PlayMaker.NamedVariable)+3C]);\nL_01FC:\n\tv2027 = v1507 == 0;\n\tif (v2027) goto L_0205;\n\t// 513 IsInst v990 @ X0_v131, typeof(HutongGames.PlayMaker.FsmVector2), v1507 @ X0_v128 (HutongGames.PlayMaker.FsmVector2)\nL_0205:\n\tv2064 = v613 < v223.Length;\n\tv582 = ~v2064;\n\tif (v582) goto L_05B0;\n\tv223[v613 @ X25_v54 (System.Int32)] = v1507;\n\tv823 = source.vector2Variables;\n\tv613 = v613 + 1;\n\tv2098 = source.vector2Variables == 0;\n\tv1525 = ~v2098;\n\tif (v1525) goto L_01DE;\n\tgoto L_05A1;\nL_0218:\n\tv1733 = source.vector3Variables;\n\tv1734 = source.vector3Variables == 0;\n\tif (v1734) goto L_026D;\n\t// 543 NewArr v1488 @ X0_v117 (HutongGames.PlayMaker.FsmVector3[]), typeof(HutongGames.PlayMaker.FsmVector3[]), v1733.Length\n\tthis.vector3Variables = v1488;\n\tv825 = source.vector3Variables;\nL_0231:\n\tv156 = v614 >= v825.Length;\n\tif (v156) goto L_026D;\n\tv1876 = v614 < v825.Length;\n\tv583 = ~v1876;\n\tif (v583) goto L_05B0;\n\tv225 = this.vector3Variables;\n\tv719 = v825[v614 @ X25_v51 (System.Int32)];\n\tv1508 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v1508, v825[v614 @ X25_v51 (System.Int32)]);\n\tv1992 = v825[v614 @ X25_v51 (System.Int32)] == 0;\n\tif (v1992) goto L_0251;\n\tv1508.value = *([v719 @ X22_v49 (HutongGames.PlayMaker.NamedVariable)+38]);\n\tv1508.value.y = *([v719 @ X22_v49 (HutongGames.PlayMaker.NamedVariable)+3C]);\n\tv1508.value.z = *([v719 @ X22_v49 (HutongGames.PlayMaker.NamedVariable)+40]);\nL_0251:\n\tv2065 = v1508 == 0;\n\tif (v2065) goto L_025A;\n\t// 598 IsInst v991 @ X0_v123, typeof(HutongGames.PlayMake\n// ... truncated")]
		public FsmVariables(FsmVariables source)
		{
			//IL_08db: Expected O, but got I
			//IL_08f5: Expected F4, but got I
			//IL_0ab3: Expected O, but got I
			//IL_0acd: Expected F4, but got I
			//IL_0ae7: Expected F4, but got I
			base._002Ector();
			string[] array = new string[1];
			if ("" != null)
			{
				object obj = "" as string;
			}
			if (array.Length != 0)
			{
				array[0] = "";
				Categories = array;
				int[] categoryIDs = new int[0];
				CategoryIDs = categoryIDs;
				if (source == null)
				{
					return;
				}
				FsmFloat[] array2 = source.floatVariables;
				if (source.floatVariables != null)
				{
					FsmFloat[] array3 = new FsmFloat[array2.Length];
					FloatVariables = array3;
					FsmFloat[] array4 = source.floatVariables;
					int num = 0;
					while (num < array4.Length)
					{
						if (num < array4.Length)
						{
							FsmFloat[] array5 = floatVariables;
							FsmFloat fsmFloat = new FsmFloat(array4[num]);
							if (fsmFloat != null)
							{
								object obj2 = fsmFloat as FsmFloat;
							}
							if (num < array5.Length)
							{
								array5[num] = fsmFloat;
								array4 = source.floatVariables;
								num++;
								if (source.floatVariables != null)
								{
									continue;
								}
								goto IL_1b0a;
							}
						}
						goto IL_1b11;
					}
				}
				FsmInt[] array6 = source.intVariables;
				if (source.intVariables != null)
				{
					FsmInt[] array7 = new FsmInt[array6.Length];
					IntVariables = array7;
					FsmInt[] array8 = source.intVariables;
					int num2 = 0;
					while (num2 < array8.Length)
					{
						if (num2 < array8.Length)
						{
							FsmInt[] array9 = intVariables;
							FsmInt fsmInt = new FsmInt(array8[num2]);
							if (fsmInt != null)
							{
								object obj3 = fsmInt as FsmInt;
							}
							if (num2 < array9.Length)
							{
								array9[num2] = fsmInt;
								array8 = source.intVariables;
								num2++;
								if (source.intVariables != null)
								{
									continue;
								}
								goto IL_1b0a;
							}
						}
						goto IL_1b11;
					}
				}
				FsmBool[] array10 = source.boolVariables;
				if (source.boolVariables != null)
				{
					FsmBool[] array11 = new FsmBool[array10.Length];
					BoolVariables = array11;
					FsmBool[] array12 = source.boolVariables;
					int num3 = 0;
					while (num3 < array12.Length)
					{
						if (num3 < array12.Length)
						{
							FsmBool[] array13 = boolVariables;
							FsmBool fsmBool = new FsmBool(array12[num3]);
							if (fsmBool != null)
							{
								object obj4 = fsmBool as FsmBool;
							}
							if (num3 < array13.Length)
							{
								array13[num3] = fsmBool;
								array12 = source.boolVariables;
								num3++;
								if (source.boolVariables != null)
								{
									continue;
								}
								goto IL_1b0a;
							}
						}
						goto IL_1b11;
					}
				}
				FsmGameObject[] array14 = source.gameObjectVariables;
				if (source.gameObjectVariables != null)
				{
					FsmGameObject[] array15 = new FsmGameObject[array14.Length];
					GameObjectVariables = array15;
					FsmGameObject[] array16 = source.gameObjectVariables;
					int num4 = 0;
					while (num4 < array16.Length)
					{
						if (num4 < array16.Length)
						{
							FsmGameObject[] array17 = gameObjectVariables;
							FsmGameObject fsmGameObject = new FsmGameObject(array16[num4]);
							if (fsmGameObject != null)
							{
								object obj5 = fsmGameObject as FsmGameObject;
							}
							if (num4 < array17.Length)
							{
								array17[num4] = fsmGameObject;
								array16 = source.gameObjectVariables;
								num4++;
								if (source.gameObjectVariables != null)
								{
									continue;
								}
								goto IL_1b0a;
							}
						}
						goto IL_1b11;
					}
				}
				FsmColor[] array18 = source.colorVariables;
				if (source.colorVariables != null)
				{
					FsmColor[] array19 = new FsmColor[array18.Length];
					ColorVariables = array19;
					FsmColor[] array20 = source.colorVariables;
					int num5 = 0;
					while (num5 < array20.Length)
					{
						if (num5 < array20.Length)
						{
							FsmColor[] array21 = colorVariables;
							FsmColor fsmColor = new FsmColor(array20[num5]);
							if (fsmColor != null)
							{
								object obj6 = fsmColor as FsmColor;
							}
							if (num5 < array21.Length)
							{
								array21[num5] = fsmColor;
								array20 = source.colorVariables;
								num5++;
								if (source.colorVariables != null)
								{
									continue;
								}
								goto IL_1b0a;
							}
						}
						goto IL_1b11;
					}
				}
				FsmVector2[] array22 = source.vector2Variables;
				if (source.vector2Variables != null)
				{
					FsmVector2[] array23 = new FsmVector2[array22.Length];
					Vector2Variables = array23;
					FsmVector2[] array24 = source.vector2Variables;
					int num6 = 0;
					while (num6 < array24.Length)
					{
						if (num6 < array24.Length)
						{
							FsmVector2[] array25 = vector2Variables;
							NamedVariable namedVariable = array24[num6];
							FsmVector2 fsmVector = (FsmVector2)new NamedVariable(array24[num6]);
							if (array24[num6] != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v717 @ X22_v51 (HutongGames.PlayMaker.NamedVariable)+38]");
								fsmVector.value = (Vector2)0;
								ref Vector2 value = ref fsmVector.value;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v717 @ X22_v51 (HutongGames.PlayMaker.NamedVariable)+3C]");
								value.y = 0f;
							}
							if (fsmVector != null)
							{
								object obj7 = fsmVector as FsmVector2;
							}
							if (num6 < array25.Length)
							{
								array25[num6] = fsmVector;
								array24 = source.vector2Variables;
								num6++;
								if (source.vector2Variables != null)
								{
									continue;
								}
								goto IL_1b0a;
							}
						}
						goto IL_1b11;
					}
				}
				FsmVector3[] array26 = source.vector3Variables;
				if (source.vector3Variables != null)
				{
					FsmVector3[] array27 = new FsmVector3[array26.Length];
					Vector3Variables = array27;
					FsmVector3[] array28 = source.vector3Variables;
					int num7 = 0;
					while (num7 < array28.Length)
					{
						if (num7 < array28.Length)
						{
							FsmVector3[] array29 = vector3Variables;
							NamedVariable namedVariable2 = array28[num7];
							FsmVector3 fsmVector2 = (FsmVector3)new NamedVariable(array28[num7]);
							if (array28[num7] != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v719 @ X22_v49 (HutongGames.PlayMaker.NamedVariable)+38]");
								fsmVector2.value = (Vector3)0;
								ref Vector3 value2 = ref fsmVector2.value;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v719 @ X22_v49 (HutongGames.PlayMaker.NamedVariable)+3C]");
								value2.y = 0f;
								ref Vector3 value3 = ref fsmVector2.value;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v719 @ X22_v49 (HutongGames.PlayMaker.NamedVariable)+40]");
								value3.z = 0f;
							}
							if (fsmVector2 != null)
							{
								object obj8 = fsmVector2 as FsmVector3;
							}
							if (num7 < array29.Length)
							{
								array29[num7] = fsmVector2;
								array28 = source.vector3Variables;
								num7++;
								if (source.vector3Variables != null)
								{
									continue;
								}
								goto IL_1b0a;
							}
						}
						goto IL_1b11;
					}
				}
				FsmRect[] array30 = source.rectVariables;
				if (source.rectVariables != null)
				{
					FsmRect[] array31 = new FsmRect[array30.Length];
					RectVariables = array31;
					FsmRect[] array32 = source.rectVariables;
					int num8 = 0;
					while (num8 < array32.Length)
					{
						if (num8 < array32.Length)
						{
							FsmRect[] array33 = rectVariables;
							FsmRect fsmRect = new FsmRect(array32[num8]);
							if (fsmRect != null)
							{
								object obj9 = fsmRect as FsmRect;
							}
							if (num8 < array33.Length)
							{
								array33[num8] = fsmRect;
								array32 = source.rectVariables;
								num8++;
								if (source.rectVariables != null)
								{
									continue;
								}
								goto IL_1b0a;
							}
						}
						goto IL_1b11;
					}
				}
				FsmQuaternion[] array34 = source.quaternionVariables;
				if (source.quaternionVariables != null)
				{
					FsmQuaternion[] array35 = new FsmQuaternion[array34.Length];
					QuaternionVariables = array35;
					FsmQuaternion[] array36 = source.quaternionVariables;
					int num9 = 0;
					while (num9 < array36.Length)
					{
						if (num9 < array36.Length)
						{
							FsmQuaternion[] array37 = quaternionVariables;
							FsmQuaternion fsmQuaternion = new FsmQuaternion(array36[num9]);
							if (fsmQuaternion != null)
							{
								object obj10 = fsmQuaternion as FsmQuaternion;
							}
							if (num9 < array37.Length)
							{
								array37[num9] = fsmQuaternion;
								array36 = source.quaternionVariables;
								num9++;
								if (source.quaternionVariables != null)
								{
									continue;
								}
								goto IL_1b0a;
							}
						}
						goto IL_1b11;
					}
				}
				FsmObject[] array38 = source.objectVariables;
				if (source.objectVariables != null)
				{
					FsmObject[] array39 = new FsmObject[array38.Length];
					ObjectVariables = array39;
					FsmObject[] array40 = source.objectVariables;
					int num10 = 0;
					while (num10 < array40.Length)
					{
						if (num10 < array40.Length)
						{
							FsmObject[] array41 = objectVariables;
							FsmObject fsmObject = new FsmObject(array40[num10]);
							if (fsmObject != null)
							{
								object obj11 = fsmObject as FsmObject;
							}
							if (num10 < array41.Length)
							{
								array41[num10] = fsmObject;
								array40 = source.objectVariables;
								num10++;
								if (source.objectVariables != null)
								{
									continue;
								}
								goto IL_1b0a;
							}
						}
						goto IL_1b11;
					}
				}
				FsmMaterial[] array42 = source.materialVariables;
				if (source.materialVariables != null)
				{
					FsmMaterial[] array43 = new FsmMaterial[array42.Length];
					MaterialVariables = array43;
					FsmMaterial[] array44 = source.materialVariables;
					int num11 = 0;
					while (num11 < array44.Length)
					{
						if (num11 < array44.Length)
						{
							FsmMaterial[] array45 = materialVariables;
							FsmMaterial fsmMaterial = new FsmMaterial(array44[num11]);
							if (fsmMaterial != null)
							{
								object obj12 = fsmMaterial as FsmMaterial;
							}
							if (num11 < array45.Length)
							{
								array45[num11] = fsmMaterial;
								array44 = source.materialVariables;
								num11++;
								if (source.materialVariables != null)
								{
									continue;
								}
								goto IL_1b0a;
							}
						}
						goto IL_1b11;
					}
				}
				FsmTexture[] array46 = source.textureVariables;
				if (source.textureVariables != null)
				{
					FsmTexture[] array47 = new FsmTexture[array46.Length];
					TextureVariables = array47;
					FsmTexture[] array48 = source.textureVariables;
					int num12 = 0;
					while (num12 < array48.Length)
					{
						if (num12 < array48.Length)
						{
							FsmTexture[] array49 = textureVariables;
							FsmTexture fsmTexture = new FsmTexture(array48[num12]);
							if (fsmTexture != null)
							{
								object obj13 = fsmTexture as FsmTexture;
							}
							if (num12 < array49.Length)
							{
								array49[num12] = fsmTexture;
								array48 = source.textureVariables;
								num12++;
								if (source.textureVariables != null)
								{
									continue;
								}
								goto IL_1b0a;
							}
						}
						goto IL_1b11;
					}
				}
				FsmString[] array50 = source.stringVariables;
				if (source.stringVariables != null)
				{
					FsmString[] array51 = new FsmString[array50.Length];
					StringVariables = array51;
					FsmString[] array52 = source.stringVariables;
					int num13 = 0;
					while (num13 < array52.Length)
					{
						if (num13 < array52.Length)
						{
							FsmString[] array53 = stringVariables;
							FsmString fsmString = new FsmString(array52[num13]);
							if (fsmString != null)
							{
								object obj14 = fsmString as FsmString;
							}
							if (num13 < array53.Length)
							{
								array53[num13] = fsmString;
								array52 = source.stringVariables;
								num13++;
								if (source.stringVariables != null)
								{
									continue;
								}
								goto IL_1b0a;
							}
						}
						goto IL_1b11;
					}
				}
				FsmArray[] array54 = source.arrayVariables;
				if (source.arrayVariables != null)
				{
					FsmArray[] array55 = new FsmArray[array54.Length];
					ArrayVariables = array55;
					FsmArray[] array56 = source.arrayVariables;
					int num14 = 0;
					while (num14 < array56.Length)
					{
						if (num14 < array56.Length)
						{
							FsmArray[] array57 = arrayVariables;
							FsmArray fsmArray = new FsmArray(array56[num14]);
							if (fsmArray != null)
							{
								object obj15 = fsmArray as FsmArray;
							}
							if (num14 < array57.Length)
							{
								array57[num14] = fsmArray;
								array56 = source.arrayVariables;
								num14++;
								if (source.arrayVariables != null)
								{
									continue;
								}
								goto IL_1b0a;
							}
						}
						goto IL_1b11;
					}
				}
				FsmEnum[] array58 = source.enumVariables;
				if (source.enumVariables != null)
				{
					FsmEnum[] array59 = new FsmEnum[array58.Length];
					EnumVariables = array59;
					FsmEnum[] array60 = source.enumVariables;
					int num15 = 0;
					while (num15 < array60.Length)
					{
						if (num15 < array60.Length)
						{
							FsmEnum[] array61 = enumVariables;
							FsmEnum fsmEnum = new FsmEnum(array60[num15]);
							if (fsmEnum != null)
							{
								object obj16 = fsmEnum as FsmEnum;
							}
							if (num15 < array61.Length)
							{
								array61[num15] = fsmEnum;
								array60 = source.enumVariables;
								num15++;
								if (source.enumVariables != null)
								{
									continue;
								}
								goto IL_1b0a;
							}
						}
						goto IL_1b11;
					}
				}
				string[] array62 = source.Categories;
				if (source.Categories != null)
				{
					string[] array63 = new string[array62.Length];
					Categories = array63;
					array62 = source.Categories;
					int num16 = 0;
					while (num16 < array62.Length)
					{
						if (num16 < array62.Length)
						{
							string[] array64 = Categories;
							if (array62[num16] != null)
							{
								object obj17 = array62[num16] as string;
							}
							if (num16 < array64.Length)
							{
								array64[num16] = array62[num16];
								array62 = source.Categories;
								num16++;
								if (source.Categories != null)
								{
									continue;
								}
								goto IL_1b0a;
							}
						}
						goto IL_1b11;
					}
				}
				int[] categoryIDs2 = source.CategoryIDs;
				if (source.CategoryIDs != null)
				{
					int[] categoryIDs3 = new int[categoryIDs2.Length];
					CategoryIDs = categoryIDs3;
					int[] categoryIDs4 = source.CategoryIDs;
					int num17 = 0;
					while (num17 < categoryIDs4.Length)
					{
						if (num17 < categoryIDs4.Length)
						{
							int[] categoryIDs5 = CategoryIDs;
							if (num17 < categoryIDs5.Length)
							{
								int num18 = num17 + 1;
								categoryIDs5[num17] = categoryIDs4[num17];
								categoryIDs4 = source.CategoryIDs;
								bool flag = source.CategoryIDs == null;
								bool flag2 = !flag;
								num17 = num18;
								if (flag2)
								{
									continue;
								}
								goto IL_1b0a;
							}
						}
						goto IL_1b11;
					}
					array62 = source.Categories;
				}
				if (array62 == null)
				{
					return;
				}
				string[] array65 = new string[array62.Length];
				Categories = array65;
				string[] array66 = source.Categories;
				int num19 = 0;
				while (true)
				{
					if (num19 < array66.Length)
					{
						if (num19 >= array66.Length)
						{
							break;
						}
						string[] array67 = Categories;
						if (array66[num19] != null)
						{
							object obj18 = array66[num19] as string;
						}
						if (num19 >= array67.Length)
						{
							break;
						}
						array67[num19] = array66[num19];
						array66 = source.Categories;
						num19++;
						if (source.Categories != null)
						{
							continue;
						}
						goto IL_1b0a;
					}
					return;
				}
			}
			goto IL_1b11;
			IL_1b0a:
			throw new NullReferenceException();
			IL_1b11:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600060B")]
		[Address(RVA = "0xE4C114", Offset = "0xE4C114", Length = "0x10A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1439 = HutongGames.PlayMaker.FsmVariables::get_FloatVariables(source);\nL_001D:\n\tv27 = v1162 >= v1439.Length;\n\tif (v27) goto L_009A;\n\tv1189 = HutongGames.PlayMaker.FsmVariables::get_FloatVariables(this);\nL_002F:\n\tv28 = v1132 >= v1189.Length;\n\tif (v28) goto L_0093;\n\tv1035 = this.floatVariables;\n\tv1898 = v1132 < v1035.Length;\n\tv873 = ~v1898;\n\tif (v873) goto L_0857;\n\tv1036 = v1035[v1132 @ X22_v63 (System.Int32)];\n\tv1904 = ~v1036.showInInspector;\n\tif (v1904) goto L_008C;\n\tv950 = source.floatVariables;\n\tv1937 = v1162 < v950.Length;\n\tv874 = ~v1937;\n\tif (v874) goto L_0857;\n\tv951 = v950[v1162 @ X21_v7 (System.Int32)];\n\tv1190 = System.String::op_Equality(v951.name, v1036.name);\n\tv1932 = v1190 == 0;\n\tif (v1932) goto L_008C;\n\tv1037 = this.floatVariables;\n\tv1985 = v1132 < v1037.Length;\n\tv875 = ~v1985;\n\tif (v875) goto L_0857;\n\tv952 = source.floatVariables;\n\tv2018 = v1162 < v952.Length;\n\tv876 = ~v2018;\n\tif (v876) goto L_0857;\n\tv300 = v1037[v1132 @ X22_v63 (System.Int32)];\n\tv75 = HutongGames.PlayMaker.FsmFloat::get_Value(v952[v1162 @ X21_v7 (System.Int32)]);\n\tv300.value = v75;\nL_008C:\n\tv1132 = v1132 + 1;\n\tv1189 = HutongGames.PlayMaker.FsmVariables::get_FloatVariables(this);\n\tv1938 = v1189 == 0;\n\tv1265 = ~v1938;\n\tif (v1265) goto L_002F;\n\tgoto L_0856;\nL_0093:\n\tv1162 = v1162 + 1;\n\tv1439 = HutongGames.PlayMaker.FsmVariables::get_FloatVariables(source);\n\tv1899 = v1439 == 0;\n\tv1266 = ~v1899;\n\tif (v1266) goto L_001D;\n\tgoto L_0856;\nL_009A:\n\tv1838 = HutongGames.PlayMaker.FsmVariables::get_IntVariables(source);\nL_00A8:\n\tv29 = v1164 >= v1838.Length;\n\tif (v29) goto L_0125;\n\tv1196 = HutongGames.PlayMaker.FsmVariables::get_IntVariables(this);\nL_00BA:\n\tv30 = v1135 >= v1196.Length;\n\tif (v30) goto L_011E;\n\tv1042 = this.intVariables;\n\tv1939 = v1135 < v1042.Length;\n\tv880 = ~v1939;\n\tif (v880) goto L_0857;\n\tv1043 = v1042[v1135 @ X22_v60 (System.Int32)];\n\tv1947 = ~v1043.showInInspector;\n\tif (v1947) goto L_0117;\n\tv958 = source.intVariables;\n\tv1981 = v1164 < v958.Length;\n\tv881 = ~v1981;\n\tif (v881) goto L_0857;\n\tv959 = v958[v1164 @ X21_v9 (System.Int32)];\n\tv1197 = System.String::op_Equality(v959.name, v1043.name);\n\tv1976 = v1197 == 0;\n\tif (v1976) goto L_0117;\n\tv1044 = this.intVariables;\n\tv2032 = v1135 < v1044.Length;\n\tv882 = ~v2032;\n\tif (v882) goto L_0857;\n\tv960 = source.intVariables;\n\tv2065 = v1164 < v960.Length;\n\tv883 = ~v2065;\n\tif (v883) goto L_0857;\n\tv305 = v1044[v1135 @ X22_v60 (System.Int32)];\n\tv1198 = HutongGames.PlayMaker.FsmInt::get_Value(v960[v1164 @ X21_v9 (System.Int32)]);\n\tv305.value = v1198;\nL_0117:\n\tv1135 = v1135 + 1;\n\tv1196 = HutongGames.PlayMaker.FsmVariables::get_IntVariables(this);\n\tv1982 = v1196 == 0;\n\tv1276 = ~v1982;\n\tif (v1276) goto L_00BA;\n\tgoto L_0856;\nL_011E:\n\tv1164 = v1164 + 1;\n\tv1838 = HutongGames.PlayMaker.FsmVariables::get_IntVariables(source);\n\tv1940 = v1838 == 0;\n\tv1277 = ~v1940;\n\tif (v1277) goto L_00A8;\n\tgoto L_0856;\nL_0125:\n\tv1927 = HutongGames.PlayMaker.FsmVariables::get_BoolVariables(source);\nL_0133:\n\tv31 = v1166 >= v1927.Length;\n\tif (v31) goto L_01B1;\n\tv1203 = HutongGames.PlayMaker.FsmVariables::get_BoolVariables(this);\nL_0145:\n\tv32 = v1138 >= v1203.Length;\n\tif (v32) goto L_01AA;\n\tv1049 = this.boolVariables;\n\tv1983 = v1138 < v1049.Length;\n\tv887 = ~v1983;\n\tif (v887) goto L_0857;\n\tv1050 = v1049[v1138 @ X22_v57 (System.Int32)];\n\tv1992 = ~v1050.showInInspector;\n\tif (v1992) goto L_01A3;\n\tv966 = source.boolVariables;\n\tv2028 = v1166 < v966.Length;\n\tv888 = ~v2028;\n\tif (v888) goto L_0857;\n\tv967 = v966[v1166 @ X21_v11 (System.Int32)];\n\tv1204 = System.String::op_Equality(v967.name, v1050.name);\n\tv2023 = v1204 == 0;\n\tif (v2023) goto L_01A3;\n\tv1051 = this.boolVariables;\n\tv2080 = v1138 < v1051.Length;\n\tv889 = ~v2080;\n\tif (v889) goto L_0857;\n\tv968 = source.boolVariables;\n\tv2113 = v1166 < v968.Length;\n\tv890 = ~v2113;\n\tif (v890) goto L_0857;\n\tv310 = v1051[v1138 @ X22_v57 (System.Int32)];\n\tv1205 = HutongGames.PlayMaker.FsmBool::get_Value(v968[v1166 @ X21_v11 (System.Int32)]);\n\tv310.value = v1205;\nL_01A3:\n\tv1138 = v1138 + 1;\n\tv1203 = HutongGames.PlayMaker.FsmVariables::get_BoolVariables(this);\n\tv2029 = v1203 == 0;\n\tv1287 = ~v2029;\n\tif (v1287) goto L_0145;\n\tgoto L_0856;\nL_01AA:\n\tv1166 = v1166 + 1;\n\tv1927 = HutongGames.PlayMaker.FsmVariables::get_BoolVariables(source);\n\tv1984 = v1927 == 0;\n\tv1288 = ~v1984;\n\tif (v1288) goto L_0133;\n\tgoto L_0856;\nL_01B1:\n\tv1970 = HutongGames.PlayMaker.FsmVariables::get_GameObjectVariables(source);\nL_01BF:\n\tv33 = v1140 >= v1970.Length;\n\tif (v33) goto L_023F;\n\tv1210 = HutongGames.PlayMaker.FsmVariables::get_GameObjectVariables(this);\nL_01D1:\n\tv34 = v1115 >= v1210.Length;\n\tif (v34) goto L_0238;\n\tv1056 = this.gameObjectVariables;\n\tv2030 = v1115 < v1056.Length;\n\tv894 = ~v2030;\n\tif (v894) goto L_0857;\n\tv1057 = v1056[v1115 @ X23_v42 (System.Int32)];\n\tv2039 = ~v1057.showInInspector;\n\tif (v2039) goto L_0231;\n\tv974 = source.gameObjectVariables;\n\tv2076 = v1140 < v974.Length;\n\tv895 = ~v2076;\n\tif (v895) goto L_0857;\n\tv975 = v974[v1140 @ X22_v10 (System.Int32)];\n\tv1211 = System.String::op_Equality(v975.name, v1057.name);\n\tv2071 = v1211 == 0;\n\tif (v2071) goto L_0231;\n\tv1058 = this.gameObjectVariables;\n\tv2129 = v1115 < v1058.Length;\n\tv896 = ~v2129;\n\tif (v896) goto L_0857;\n\tv976 = source.gameObjectVariables;\n\tv2162 = v1140 < v976.Length;\n\tv897 = ~v2162;\n\tif (v897) goto L_0857;\n\tv1212 = HutongGames.PlayMaker.FsmGameObject::get_Value(v976[v1140 @ X22_v10 (System.Int32)]);\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(v1058[v1115 @ X23_v42 (System.Int32)], v1212);\nL_0231:\n\tv1115 = v1115 + 1;\n\tv1210 = HutongGames.PlayMaker.FsmVariables::get_GameObjectVariables(this);\n\tv2077 = v1210 == 0;\n\tv1298 = ~v2077;\n\tif (v1298) goto L_01D1;\n\tgoto L_0856;\nL_0238:\n\tv1140 = v1140 + 1;\n\tv1970 = HutongGames.PlayMaker.FsmVariables::get_GameObjectVariables(source);\n\tv2031 = v1970 == 0;\n\tv1299 = ~v2031;\n\tif (v1299) goto L_01BF;\n\tgoto L_0856;\nL_023F:\n\tv2015 = HutongGames.PlayMaker.FsmVariables::get_ColorVariables(source);\nL_024D:\n\tv35 = v1173 >= v2015.Length;\n\tif (v35) goto L_02CD;\n\tv1217 = HutongGames.PlayMaker.FsmVariables::get_ColorVariables(this);\nL_025F:\n\tv36 = v1143 >= v1217.Length;\n\tif (v36) goto L_02C6;\n\tv1063 = this.colorVariables;\n\tv2078 = v1143 < v1063.Length;\n\tv901 = ~v2078;\n\tif (v901) goto L_0857;\n\tv1064 = v1063[v1143 @ X22_v53 (System.Int32)];\n\tv2087 = ~v1064.showInInspector;\n\tif (v2087) goto L_02BF;\n\tv982 = source.colorVariables;\n\tv2125 = v1173 < v982.Length;\n\tv902 = ~v2125;\n\tif (v902) goto L_0857;\n\tv983 = v982[v1173 @ X21_v14 (System.Int32)];\n\tv1218 = System.String::op_Equality(v983.name, v1064.name);\n\tv2120 = v1218 == 0;\n\tif (v2120) goto L_02BF;\n\tv1065 = this.colorVariables;\n\tv2178 = v1143 < v1065.Length;\n\tv903 = ~v2178;\n\tif (v903) goto L_0857;\n\tv984 = source.colorVariables;\n\tv2211 = v1173 < v984.Length;\n\tv904 = ~v2211;\n\tif (v904) goto L_0857;\n\tv985 = v984[v1173 @ X21_v14 (System.Int32)];\n\tv1066 = v1065[v1143 @ X22_v53 (System.Int32)];\n\tv1066.value.r = v985.value;\n\tv1066.value.g = v985.value.g;\n\tv1066.value.a = v985.value.a;\nL_02BF:\n\tv1143 = v1143 + 1;\n\tv1217 = HutongGames.PlayMaker.FsmVariables::get_ColorVariables(this);\n\tv2126 = v1217 == 0;\n\tv1310 = ~v2126;\n\tif (v1310) goto L_025F;\n\tgoto L_0856;\nL_02C6:\n\tv1173 = v1173 + 1;\n\tv2015 = HutongGames.PlayMaker.FsmVariables::get_ColorVariables(source);\n\tv2079 = v2015 == 0;\n\tv1311 = ~v2079;\n\tif (v1311) goto L_024D;\n\tgoto L_0856;\nL_02CD:\n\tv2062 = HutongGames.PlayMaker.FsmVariables::get_Vector2Variables(source);\nL_02DB:\n\tv37 = v1175 >= v2062.Length;\n\tif (v37) goto L_0359;\n\tv1223 = HutongGames.PlayMaker.FsmVariables::get_Vector2Variables(this);\nL_02ED:\n\tv38 = v1146 >= v1223.Length;\n\tif (v38) goto L_0352;\n\tv1070 = this.vector2Variables;\n\tv2127 = v1146 < v1070.Length;\n\tv908 = ~v2127;\n\tif (v908) goto L_0857;\n\tv1071 = v1070[v1146 @ X22_v50 (System.Int32)];\n\tv2136 = ~v1071.showInInspector;\n\tif (v2136) goto L_034B;\n\tv990 = source.vector2Variables;\n\tv2173 = v1175 < v990.Length;\n\tv909 = ~v2173;\n\tif (v909) goto L_0857;\n\tv991 = v990[v1175 @ X21_v16 (System.Int32)];\n\tv1224 = System.String::op_Equality(v991.name, v1071.name);\n\tv2168 = v1224 == 0;\n\tif (v2168) goto L_034B;\n\tv1072 = this.vector2Variables;\n\tv2226 = v1146 < v1072.Length;\n\tv910 = ~v22\n// ... truncated")]
		public void OverrideVariableValues(FsmVariables source)
		{
			FsmFloat[] array = source.FloatVariables;
			int num = 0;
			while (true)
			{
				if (num < array.Length)
				{
					FsmFloat[] array2 = FloatVariables;
					int num2 = 0;
					while (num2 < array2.Length)
					{
						FsmFloat[] array3 = floatVariables;
						if (num2 >= array3.Length)
						{
							goto end_IL_23c4;
						}
						FsmFloat fsmFloat = array3[num2];
						if (fsmFloat.ShowInInspector)
						{
							FsmFloat[] array4 = source.floatVariables;
							if (num >= array4.Length)
							{
								goto end_IL_23c4;
							}
							FsmFloat fsmFloat2 = array4[num];
							if (fsmFloat2.Name == fsmFloat.Name)
							{
								FsmFloat[] array5 = floatVariables;
								if (num2 >= array5.Length)
								{
									goto end_IL_23c4;
								}
								FsmFloat[] array6 = source.floatVariables;
								if (num >= array6.Length)
								{
									goto end_IL_23c4;
								}
								FsmFloat fsmFloat3 = array5[num2];
								float value = array6[num].Value;
								fsmFloat3.Value = value;
							}
						}
						num2++;
						array2 = FloatVariables;
						if (array2 != null)
						{
							continue;
						}
						goto IL_2339;
					}
					num++;
					array = source.FloatVariables;
					if (array != null)
					{
						continue;
					}
					goto IL_2339;
				}
				FsmInt[] array7 = source.IntVariables;
				int num3 = 0;
				while (num3 < array7.Length)
				{
					FsmInt[] array8 = IntVariables;
					int num4 = 0;
					while (num4 < array8.Length)
					{
						FsmInt[] array9 = intVariables;
						if (num4 >= array9.Length)
						{
							goto end_IL_23c4;
						}
						FsmInt fsmInt = array9[num4];
						if (fsmInt.ShowInInspector)
						{
							FsmInt[] array10 = source.intVariables;
							if (num3 >= array10.Length)
							{
								goto end_IL_23c4;
							}
							FsmInt fsmInt2 = array10[num3];
							if (fsmInt2.Name == fsmInt.Name)
							{
								FsmInt[] array11 = intVariables;
								if (num4 >= array11.Length)
								{
									goto end_IL_23c4;
								}
								FsmInt[] array12 = source.intVariables;
								if (num3 >= array12.Length)
								{
									goto end_IL_23c4;
								}
								FsmInt fsmInt3 = array11[num4];
								int value2 = array12[num3].Value;
								fsmInt3.Value = value2;
							}
						}
						num4++;
						array8 = IntVariables;
						if (array8 != null)
						{
							continue;
						}
						goto IL_2339;
					}
					num3++;
					array7 = source.IntVariables;
					if (array7 != null)
					{
						continue;
					}
					goto IL_2339;
				}
				FsmBool[] array13 = source.BoolVariables;
				int num5 = 0;
				while (num5 < array13.Length)
				{
					FsmBool[] array14 = BoolVariables;
					int num6 = 0;
					while (num6 < array14.Length)
					{
						FsmBool[] array15 = boolVariables;
						if (num6 >= array15.Length)
						{
							goto end_IL_23c4;
						}
						FsmBool fsmBool = array15[num6];
						if (fsmBool.ShowInInspector)
						{
							FsmBool[] array16 = source.boolVariables;
							if (num5 >= array16.Length)
							{
								goto end_IL_23c4;
							}
							FsmBool fsmBool2 = array16[num5];
							if (fsmBool2.Name == fsmBool.Name)
							{
								FsmBool[] array17 = boolVariables;
								if (num6 >= array17.Length)
								{
									goto end_IL_23c4;
								}
								FsmBool[] array18 = source.boolVariables;
								if (num5 >= array18.Length)
								{
									goto end_IL_23c4;
								}
								FsmBool fsmBool3 = array17[num6];
								bool value3 = array18[num5].Value;
								fsmBool3.value = value3;
							}
						}
						num6++;
						array14 = BoolVariables;
						if (array14 != null)
						{
							continue;
						}
						goto IL_2339;
					}
					num5++;
					array13 = source.BoolVariables;
					if (array13 != null)
					{
						continue;
					}
					goto IL_2339;
				}
				FsmGameObject[] array19 = source.GameObjectVariables;
				int num7 = 0;
				while (num7 < array19.Length)
				{
					FsmGameObject[] array20 = GameObjectVariables;
					int num8 = 0;
					while (num8 < array20.Length)
					{
						FsmGameObject[] array21 = gameObjectVariables;
						if (num8 >= array21.Length)
						{
							goto end_IL_23c4;
						}
						FsmGameObject fsmGameObject = array21[num8];
						if (fsmGameObject.ShowInInspector)
						{
							FsmGameObject[] array22 = source.gameObjectVariables;
							if (num7 >= array22.Length)
							{
								goto end_IL_23c4;
							}
							FsmGameObject fsmGameObject2 = array22[num7];
							if (fsmGameObject2.Name == fsmGameObject.Name)
							{
								FsmGameObject[] array23 = gameObjectVariables;
								if (num8 >= array23.Length)
								{
									goto end_IL_23c4;
								}
								FsmGameObject[] array24 = source.gameObjectVariables;
								if (num7 >= array24.Length)
								{
									goto end_IL_23c4;
								}
								GameObject value4 = array24[num7].Value;
								array23[num8].Value = value4;
							}
						}
						num8++;
						array20 = GameObjectVariables;
						if (array20 != null)
						{
							continue;
						}
						goto IL_2339;
					}
					num7++;
					array19 = source.GameObjectVariables;
					if (array19 != null)
					{
						continue;
					}
					goto IL_2339;
				}
				FsmColor[] array25 = source.ColorVariables;
				int num9 = 0;
				while (num9 < array25.Length)
				{
					FsmColor[] array26 = ColorVariables;
					int num10 = 0;
					while (num10 < array26.Length)
					{
						FsmColor[] array27 = colorVariables;
						if (num10 >= array27.Length)
						{
							goto end_IL_23c4;
						}
						FsmColor fsmColor = array27[num10];
						if (fsmColor.ShowInInspector)
						{
							FsmColor[] array28 = source.colorVariables;
							if (num9 >= array28.Length)
							{
								goto end_IL_23c4;
							}
							FsmColor fsmColor2 = array28[num9];
							if (fsmColor2.Name == fsmColor.Name)
							{
								FsmColor[] array29 = colorVariables;
								if (num10 >= array29.Length)
								{
									goto end_IL_23c4;
								}
								FsmColor[] array30 = source.colorVariables;
								if (num9 >= array30.Length)
								{
									goto end_IL_23c4;
								}
								FsmColor fsmColor3 = array30[num9];
								FsmColor fsmColor4 = array29[num10];
								fsmColor4.value.r = fsmColor3.value.r;
								fsmColor4.value.g = fsmColor3.value.g;
								fsmColor4.value.a = fsmColor3.value.a;
							}
						}
						num10++;
						array26 = ColorVariables;
						if (array26 != null)
						{
							continue;
						}
						goto IL_2339;
					}
					num9++;
					array25 = source.ColorVariables;
					if (array25 != null)
					{
						continue;
					}
					goto IL_2339;
				}
				FsmVector2[] array31 = source.Vector2Variables;
				int num11 = 0;
				while (num11 < array31.Length)
				{
					FsmVector2[] array32 = Vector2Variables;
					int num12 = 0;
					while (num12 < array32.Length)
					{
						FsmVector2[] array33 = vector2Variables;
						if (num12 >= array33.Length)
						{
							goto end_IL_23c4;
						}
						FsmVector2 fsmVector = array33[num12];
						if (fsmVector.ShowInInspector)
						{
							FsmVector2[] array34 = source.vector2Variables;
							if (num11 >= array34.Length)
							{
								goto end_IL_23c4;
							}
							FsmVector2 fsmVector2 = array34[num11];
							if (fsmVector2.Name == fsmVector.Name)
							{
								FsmVector2[] array35 = vector2Variables;
								if (num12 >= array35.Length)
								{
									goto end_IL_23c4;
								}
								FsmVector2[] array36 = source.vector2Variables;
								if (num11 >= array36.Length)
								{
									goto end_IL_23c4;
								}
								FsmVector2 fsmVector3 = array36[num11];
								FsmVector2 fsmVector4 = array35[num12];
								fsmVector4.value = fsmVector3.value;
								fsmVector4.value.y = fsmVector3.value.y;
							}
						}
						num12++;
						array32 = Vector2Variables;
						if (array32 != null)
						{
							continue;
						}
						goto IL_2339;
					}
					num11++;
					array31 = source.Vector2Variables;
					if (array31 != null)
					{
						continue;
					}
					goto IL_2339;
				}
				FsmVector3[] array37 = source.Vector3Variables;
				int num13 = 0;
				while (num13 < array37.Length)
				{
					FsmVector3[] array38 = Vector3Variables;
					int num14 = 0;
					while (num14 < array38.Length)
					{
						FsmVector3[] array39 = vector3Variables;
						if (num14 >= array39.Length)
						{
							goto end_IL_23c4;
						}
						FsmVector3 fsmVector5 = array39[num14];
						if (fsmVector5.ShowInInspector)
						{
							FsmVector3[] array40 = source.vector3Variables;
							if (num13 >= array40.Length)
							{
								goto end_IL_23c4;
							}
							FsmVector3 fsmVector6 = array40[num13];
							if (fsmVector6.Name == fsmVector5.Name)
							{
								FsmVector3[] array41 = vector3Variables;
								if (num14 >= array41.Length)
								{
									goto end_IL_23c4;
								}
								FsmVector3[] array42 = source.vector3Variables;
								if (num13 >= array42.Length)
								{
									goto end_IL_23c4;
								}
								FsmVector3 fsmVector7 = array41[num14];
								Vector3 vector = (fsmVector7.value = array42[num13].Value);
								fsmVector7.value.y = vector.y;
								fsmVector7.value.z = vector.z;
							}
						}
						num14++;
						array38 = Vector3Variables;
						if (array38 != null)
						{
							continue;
						}
						goto IL_2339;
					}
					num13++;
					array37 = source.Vector3Variables;
					if (array37 != null)
					{
						continue;
					}
					goto IL_2339;
				}
				FsmRect[] array43 = source.RectVariables;
				int num15 = 0;
				while (num15 < array43.Length)
				{
					FsmRect[] array44 = RectVariables;
					int num16 = 0;
					while (num16 < array44.Length)
					{
						FsmRect[] array45 = rectVariables;
						if (num16 >= array45.Length)
						{
							goto end_IL_23c4;
						}
						FsmRect fsmRect = array45[num16];
						if (fsmRect.ShowInInspector)
						{
							FsmRect[] array46 = source.rectVariables;
							if (num15 >= array46.Length)
							{
								goto end_IL_23c4;
							}
							FsmRect fsmRect2 = array46[num15];
							if (fsmRect2.Name == fsmRect.Name)
							{
								FsmRect[] array47 = rectVariables;
								if (num16 >= array47.Length)
								{
									goto end_IL_23c4;
								}
								FsmRect[] array48 = source.rectVariables;
								if (num15 >= array48.Length)
								{
									goto end_IL_23c4;
								}
								FsmRect fsmRect3 = array48[num15];
								FsmRect fsmRect4 = array47[num16];
								fsmRect4.value.x = fsmRect3.value.x;
								fsmRect4.value.y = fsmRect3.value.y;
								fsmRect4.value.height = fsmRect3.value.height;
							}
						}
						num16++;
						array44 = RectVariables;
						if (array44 != null)
						{
							continue;
						}
						goto IL_2339;
					}
					num15++;
					array43 = source.RectVariables;
					if (array43 != null)
					{
						continue;
					}
					goto IL_2339;
				}
				FsmQuaternion[] array49 = source.QuaternionVariables;
				int num17 = 0;
				while (num17 < array49.Length)
				{
					FsmQuaternion[] array50 = QuaternionVariables;
					int num18 = 0;
					while (num18 < array50.Length)
					{
						FsmQuaternion[] array51 = quaternionVariables;
						if (num18 >= array51.Length)
						{
							goto end_IL_23c4;
						}
						FsmQuaternion fsmQuaternion = array51[num18];
						if (fsmQuaternion.ShowInInspector)
						{
							FsmQuaternion[] array52 = source.quaternionVariables;
							if (num17 >= array52.Length)
							{
								goto end_IL_23c4;
							}
							FsmQuaternion fsmQuaternion2 = array52[num17];
							if (fsmQuaternion2.Name == fsmQuaternion.Name)
							{
								FsmQuaternion[] array53 = quaternionVariables;
								if (num18 >= array53.Length)
								{
									goto end_IL_23c4;
								}
								FsmQuaternion[] array54 = source.quaternionVariables;
								if (num17 >= array54.Length)
								{
									goto end_IL_23c4;
								}
								FsmQuaternion fsmQuaternion3 = array54[num17];
								FsmQuaternion fsmQuaternion4 = array53[num18];
								fsmQuaternion4.value.x = fsmQuaternion3.value.x;
								fsmQuaternion4.value.y = fsmQuaternion3.value.y;
								fsmQuaternion4.value.w = fsmQuaternion3.value.w;
							}
						}
						num18++;
						array50 = QuaternionVariables;
						if (array50 != null)
						{
							continue;
						}
						goto IL_2339;
					}
					num17++;
					array49 = source.QuaternionVariables;
					if (array49 != null)
					{
						continue;
					}
					goto IL_2339;
				}
				FsmObject[] array55 = source.ObjectVariables;
				int num19 = 0;
				while (num19 < array55.Length)
				{
					FsmObject[] array56 = ObjectVariables;
					int num20 = 0;
					while (num20 < array56.Length)
					{
						FsmObject[] array57 = objectVariables;
						if (num20 >= array57.Length)
						{
							goto end_IL_23c4;
						}
						FsmObject fsmObject = array57[num20];
						if (fsmObject.ShowInInspector)
						{
							FsmObject[] array58 = source.objectVariables;
							if (num19 >= array58.Length)
							{
								goto end_IL_23c4;
							}
							FsmObject fsmObject2 = array58[num19];
							if (fsmObject2.Name == fsmObject.Name)
							{
								FsmObject[] array59 = objectVariables;
								if (num20 >= array59.Length)
								{
									goto end_IL_23c4;
								}
								FsmObject[] array60 = source.objectVariables;
								if (num19 >= array60.Length)
								{
									goto end_IL_23c4;
								}
								FsmObject fsmObject3 = array59[num20];
								UnityEngine.Object value5 = array60[num19].Value;
								fsmObject3.Value = value5;
							}
						}
						num20++;
						array56 = ObjectVariables;
						if (array56 != null)
						{
							continue;
						}
						goto IL_2339;
					}
					num19++;
					array55 = source.ObjectVariables;
					if (array55 != null)
					{
						continue;
					}
					goto IL_2339;
				}
				FsmMaterial[] array61 = source.MaterialVariables;
				int num21 = 0;
				while (true)
				{
					if (num21 < array61.Length)
					{
						FsmMaterial[] array62 = MaterialVariables;
						int num22 = 0;
						while (num22 < array62.Length)
						{
							FsmMaterial[] array63 = materialVariables;
							if (num22 >= array63.Length)
							{
								goto end_IL_23c4;
							}
							FsmMaterial fsmMaterial = array63[num22];
							if (fsmMaterial.ShowInInspector)
							{
								FsmMaterial[] array64 = source.materialVariables;
								if (num21 >= array64.Length)
								{
									goto end_IL_23c4;
								}
								FsmMaterial fsmMaterial2 = array64[num21];
								if (fsmMaterial2.Name == fsmMaterial.Name)
								{
									FsmMaterial[] array65 = materialVariables;
									if (num22 >= array65.Length)
									{
										goto end_IL_23c4;
									}
									FsmMaterial[] array66 = source.materialVariables;
									if (num21 >= array66.Length)
									{
										goto IL_2355;
									}
									Material value6 = array66[num21].Value;
									array65[num22].Value = value6;
								}
							}
							num22++;
							array62 = MaterialVariables;
							if (array62 != null)
							{
								continue;
							}
							goto IL_2332;
						}
						num21++;
						array61 = source.MaterialVariables;
						if (array61 != null)
						{
							continue;
						}
						goto IL_2332;
					}
					FsmTexture[] array67 = source.TextureVariables;
					int num23 = 0;
					while (true)
					{
						if (num23 < array67.Length)
						{
							FsmTexture[] array68 = TextureVariables;
							int num24 = 0;
							while (num24 < array68.Length)
							{
								FsmTexture[] array69 = textureVariables;
								if (num24 >= array69.Length)
								{
									goto end_IL_289a;
								}
								FsmTexture fsmTexture = array69[num24];
								if (fsmTexture.ShowInInspector)
								{
									FsmTexture[] array70 = source.textureVariables;
									if (num23 >= array70.Length)
									{
										goto end_IL_289a;
									}
									FsmTexture fsmTexture2 = array70[num23];
									if (fsmTexture2.Name == fsmTexture.Name)
									{
										FsmTexture[] array71 = textureVariables;
										if (num24 >= array71.Length)
										{
											goto end_IL_289a;
										}
										FsmTexture[] array72 = source.textureVariables;
										if (num23 >= array72.Length)
										{
											goto end_IL_289a;
										}
										Texture value7 = array72[num23].Value;
										array71[num24].Value = value7;
									}
								}
								num24++;
								array68 = TextureVariables;
								if (array68 != null)
								{
									continue;
								}
								goto IL_2332;
							}
							num23++;
							array67 = source.TextureVariables;
							if (array67 != null)
							{
								continue;
							}
							goto IL_2332;
						}
						FsmString[] array73 = source.StringVariables;
						int num25 = 0;
						while (true)
						{
							if (num25 < array73.Length)
							{
								FsmString[] array74 = StringVariables;
								int num26 = 0;
								while (num26 < array74.Length)
								{
									FsmString[] array75 = stringVariables;
									if (num26 >= array75.Length)
									{
										goto end_IL_291c;
									}
									FsmString fsmString = array75[num26];
									if (fsmString.ShowInInspector)
									{
										FsmString[] array76 = source.stringVariables;
										if (num25 >= array76.Length)
										{
											goto end_IL_291c;
										}
										FsmString fsmString2 = array76[num25];
										if (fsmString2.Name == fsmString.Name)
										{
											FsmString[] array77 = stringVariables;
											if (num26 >= array77.Length)
											{
												goto end_IL_291c;
											}
											FsmString[] array78 = source.stringVariables;
											if (num25 >= array78.Length)
											{
												goto end_IL_291c;
											}
											FsmString fsmString3 = array77[num26];
											string value8 = array78[num25].Value;
											fsmString3.Value = value8;
										}
									}
									num26++;
									array74 = StringVariables;
									if (array74 != null)
									{
										continue;
									}
									goto IL_2332;
								}
								num25++;
								array73 = source.StringVariables;
								if (array73 != null)
								{
									continue;
								}
								goto IL_2332;
							}
							FsmArray[] array79 = source.ArrayVariables;
							int num27 = 0;
							while (true)
							{
								if (num27 < array79.Length)
								{
									FsmArray[] array80 = ArrayVariables;
									int num28 = 0;
									while (num28 < array80.Length)
									{
										FsmArray[] array81 = arrayVariables;
										if (num28 >= array81.Length)
										{
											goto end_IL_295e;
										}
										FsmArray fsmArray = array81[num28];
										if (fsmArray.ShowInInspector)
										{
											FsmArray[] array82 = source.arrayVariables;
											if (num27 >= array82.Length)
											{
												goto end_IL_295e;
											}
											FsmArray fsmArray2 = array82[num27];
											if (fsmArray2.Name == fsmArray.Name)
											{
												FsmArray[] array83 = arrayVariables;
												if (num28 >= array83.Length)
												{
													goto end_IL_295e;
												}
												FsmArray[] array84 = source.arrayVariables;
												if (num27 >= array84.Length)
												{
													goto end_IL_295e;
												}
												array83[num28].CopyValues(array84[num27]);
											}
										}
										num28++;
										array80 = ArrayVariables;
										if (array80 != null)
										{
											continue;
										}
										goto IL_2332;
									}
									num27++;
									array79 = source.ArrayVariables;
									if (array79 != null)
									{
										continue;
									}
									goto IL_2332;
								}
								FsmEnum[] array85 = source.EnumVariables;
								int num29 = 0;
								while (true)
								{
									if (num29 >= array85.Length)
									{
										return;
									}
									FsmEnum[] array86 = EnumVariables;
									int num30 = 0;
									while (num30 < array86.Length)
									{
										FsmEnum[] array87 = enumVariables;
										if (num30 >= array87.Length)
										{
											goto end_IL_29a0;
										}
										FsmEnum fsmEnum = array87[num30];
										if (fsmEnum.ShowInInspector)
										{
											FsmEnum[] array88 = source.enumVariables;
											if (num29 >= array88.Length)
											{
												goto end_IL_29a0;
											}
											FsmEnum fsmEnum2 = array88[num29];
											if (fsmEnum2.Name == fsmEnum.Name)
											{
												FsmEnum[] array89 = enumVariables;
												if (num30 >= array89.Length)
												{
													goto end_IL_29a0;
												}
												FsmEnum[] array90 = source.enumVariables;
												if (num29 >= array90.Length)
												{
													goto end_IL_29a0;
												}
												Enum value9 = array90[num29].Value;
												array89[num30].Value = value9;
											}
										}
										num30++;
										array86 = EnumVariables;
										if (array86 != null)
										{
											continue;
										}
										goto IL_2332;
									}
									num29++;
									array85 = source.EnumVariables;
									if (array85 != null)
									{
										continue;
									}
									goto IL_2332;
									continue;
									end_IL_29a0:
									break;
								}
								break;
								continue;
								end_IL_295e:
								break;
							}
							break;
							continue;
							end_IL_291c:
							break;
						}
						break;
						continue;
						end_IL_289a:
						break;
					}
					goto IL_2355;
					IL_2355:
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
					IL_2332:
					throw new NullReferenceException();
				}
				IL_2339:
				NullReferenceException ex2 = new NullReferenceException();
				break;
				continue;
				end_IL_23c4:
				break;
			}
			IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
			throw ex3;
		}

		[Token(Token = "0x600060C")]
		[Address(RVA = "0xE4D29C", Offset = "0xE4D29C", Length = "0x814")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = source == 0;\n\tif (v18) goto L_040A;\n\tv780 = HutongGames.PlayMaker.FsmVariables::get_FloatVariables(source);\nL_0012:\n\tv266 = v750 + 1;\n\tv166 = v266 >= v780.Length;\n\tif (v166) goto L_0050;\n\tv705 = this.floatVariables;\n\tv935 = v266 < v705.Length;\n\tv628 = ~v935;\n\tif (v628) goto L_040B;\n\tv672 = source.floatVariables;\n\tv750 = v750 + 1;\n\tv989 = v750 < v672.Length;\n\tv629 = ~v989;\n\tif (v629) goto L_040B;\n\tv214 = v705[v266 @ X9_v4];\n\tv192 = HutongGames.PlayMaker.FsmFloat::get_Value(v672[v266 @ X9_v4]);\n\tv214.value = v192;\n\tv780 = HutongGames.PlayMaker.FsmVariables::get_FloatVariables(source);\n\tv1055 = v780 == 0;\n\tv836 = ~v1055;\n\tif (v836) goto L_0012;\n\tgoto L_0402;\nL_0050:\n\tv784 = HutongGames.PlayMaker.FsmVariables::get_IntVariables(source);\nL_005E:\n\tv167 = v752 >= v784.Length;\n\tif (v167) goto L_0092;\n\tv708 = this.intVariables;\n\tv1039 = v752 < v708.Length;\n\tv631 = ~v1039;\n\tif (v631) goto L_040B;\n\tv269 = source.intVariables;\n\tv1042 = v752 < v269.Length;\n\tv632 = ~v1042;\n\tif (v632) goto L_040B;\n\tv216 = v708[v752 @ X21_v9 (System.Int32)];\n\tv785 = HutongGames.PlayMaker.FsmInt::get_Value(v269[v752 @ X21_v9 (System.Int32)]);\n\tv216.value = v785;\n\tv752 = v752 + 1;\n\tv784 = HutongGames.PlayMaker.FsmVariables::get_IntVariables(source);\n\tv1073 = v784 == 0;\n\tv841 = ~v1073;\n\tif (v841) goto L_005E;\n\tgoto L_0402;\nL_0092:\n\tv788 = HutongGames.PlayMaker.FsmVariables::get_BoolVariables(source);\nL_00A0:\n\tv168 = v754 >= v788.Length;\n\tif (v168) goto L_00D5;\n\tv711 = this.boolVariables;\n\tv1057 = v754 < v711.Length;\n\tv634 = ~v1057;\n\tif (v634) goto L_040B;\n\tv272 = source.boolVariables;\n\tv1060 = v754 < v272.Length;\n\tv635 = ~v1060;\n\tif (v635) goto L_040B;\n\tv218 = v711[v754 @ X21_v11 (System.Int32)];\n\tv789 = HutongGames.PlayMaker.FsmBool::get_Value(v272[v754 @ X21_v11 (System.Int32)]);\n\tv754 = v754 + 1;\n\tv218.value = v789;\n\tv788 = HutongGames.PlayMaker.FsmVariables::get_BoolVariables(source);\n\tv1091 = v788 == 0;\n\tv846 = ~v1091;\n\tif (v846) goto L_00A0;\n\tgoto L_0402;\nL_00D5:\n\tv792 = HutongGames.PlayMaker.FsmVariables::get_GameObjectVariables(source);\nL_00E3:\n\tv169 = v219 >= v792.Length;\n\tif (v169) goto L_011A;\n\tv715 = this.gameObjectVariables;\n\tv1075 = v219 < v715.Length;\n\tv637 = ~v1075;\n\tif (v637) goto L_040B;\n\tv275 = source.gameObjectVariables;\n\tv1078 = v219 < v275.Length;\n\tv638 = ~v1078;\n\tif (v638) goto L_040B;\n\tv793 = HutongGames.PlayMaker.FsmGameObject::get_Value(v275[v219 @ X22_v10 (System.Int32)]);\n\tv220 = v219 + 1;\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(v715[v219 @ X22_v10 (System.Int32)], v793);\n\tv792 = HutongGames.PlayMaker.FsmVariables::get_GameObjectVariables(source);\n\tv1113 = v792 == 0;\n\tv851 = ~v1113;\n\tif (v851) goto L_00E3;\n\tgoto L_0402;\nL_011A:\n\tv796 = HutongGames.PlayMaker.FsmVariables::get_ColorVariables(source);\nL_0128:\n\tv170 = v758 >= v796.Length;\n\tif (v170) goto L_015F;\n\tv718 = this.colorVariables;\n\tv1094 = v758 < v718.Length;\n\tv640 = ~v1094;\n\tif (v640) goto L_040B;\n\tv278 = source.colorVariables;\n\tv1097 = v758 < v278.Length;\n\tv641 = ~v1097;\n\tif (v641) goto L_040B;\n\tv279 = v278[v758 @ X21_v14 (System.Int32)];\n\tv719 = v718[v758 @ X21_v14 (System.Int32)];\n\tv758 = v758 + 1;\n\tv719.value.r = v279.value;\n\tv719.value.g = v279.value.g;\n\tv719.value.a = v279.value.a;\n\tv796 = HutongGames.PlayMaker.FsmVariables::get_ColorVariables(source);\n\tv1118 = v796 == 0;\n\tv857 = ~v1118;\n\tif (v857) goto L_0128;\n\tgoto L_0402;\nL_015F:\n\tv799 = HutongGames.PlayMaker.FsmVariables::get_Vector2Variables(source);\nL_016D:\n\tv171 = v760 >= v799.Length;\n\tif (v171) goto L_01A2;\n\tv721 = this.vector2Variables;\n\tv1115 = v760 < v721.Length;\n\tv643 = ~v1115;\n\tif (v643) goto L_040B;\n\tv282 = source.vector2Variables;\n\tv1119 = v760 < v282.Length;\n\tv644 = ~v1119;\n\tif (v644) goto L_040B;\n\tv283 = v282[v760 @ X21_v16 (System.Int32)];\n\tv722 = v721[v760 @ X21_v16 (System.Int32)];\n\tv760 = v760 + 1;\n\tv722.value = v283.value;\n\tv722.value.y = v283.value.y;\n\tv799 = HutongGames.PlayMaker.FsmVariables::get_Vector2Variables(source);\n\tv1138 = v799 == 0;\n\tv863 = ~v1138;\n\tif (v863) goto L_016D;\n\tgoto L_0402;\nL_01A2:\n\tv802 = HutongGames.PlayMaker.FsmVariables::get_Vector3Variables(source);\nL_01B0:\n\tv172 = v762 >= v802.Length;\n\tif (v172) goto L_01E7;\n\tv724 = this.vector3Variables;\n\tv1135 = v762 < v724.Length;\n\tv646 = ~v1135;\n\tif (v646) goto L_040B;\n\tv286 = source.vector3Variables;\n\tv1139 = v762 < v286.Length;\n\tv647 = ~v1139;\n\tif (v647) goto L_040B;\n\tv222 = v724[v762 @ X21_v18 (System.Int32)];\n\tv193 = HutongGames.PlayMaker.FsmVector3::get_Value(v286[v762 @ X21_v18 (System.Int32)]);\n\tv762 = v762 + 1;\n\tv222.value = v193;\n\tv222.value.y = v193.y;\n\tv222.value.z = v193.z;\n\tv802 = HutongGames.PlayMaker.FsmVariables::get_Vector3Variables(source);\n\tv1169 = v802 == 0;\n\tv868 = ~v1169;\n\tif (v868) goto L_01B0;\n\tgoto L_0402;\nL_01E7:\n\tv806 = HutongGames.PlayMaker.FsmVariables::get_RectVariables(source);\nL_01F5:\n\tv173 = v764 >= v806.Length;\n\tif (v173) goto L_022C;\n\tv727 = this.rectVariables;\n\tv1153 = v764 < v727.Length;\n\tv649 = ~v1153;\n\tif (v649) goto L_040B;\n\tv289 = source.rectVariables;\n\tv1156 = v764 < v289.Length;\n\tv650 = ~v1156;\n\tif (v650) goto L_040B;\n\tv290 = v289[v764 @ X21_v20 (System.Int32)];\n\tv728 = v727[v764 @ X21_v20 (System.Int32)];\n\tv764 = v764 + 1;\n\tv728.value.m_XMin = v290.value;\n\tv728.value.m_YMin = v290.value.m_YMin;\n\tv728.value.m_Height = v290.value.m_Height;\n\tv806 = HutongGames.PlayMaker.FsmVariables::get_RectVariables(source);\n\tv1176 = v806 == 0;\n\tv874 = ~v1176;\n\tif (v874) goto L_01F5;\n\tgoto L_0402;\nL_022C:\n\tv809 = HutongGames.PlayMaker.FsmVariables::get_QuaternionVariables(source);\nL_023A:\n\tv174 = v766 >= v809.Length;\n\tif (v174) goto L_0271;\n\tv730 = this.quaternionVariables;\n\tv1173 = v766 < v730.Length;\n\tv652 = ~v1173;\n\tif (v652) goto L_040B;\n\tv293 = source.quaternionVariables;\n\tv1177 = v766 < v293.Length;\n\tv653 = ~v1177;\n\tif (v653) goto L_040B;\n\tv294 = v293[v766 @ X21_v22 (System.Int32)];\n\tv731 = v730[v766 @ X21_v22 (System.Int32)];\n\tv766 = v766 + 1;\n\tv731.value.x = v294.value;\n\tv731.value.y = v294.value.y;\n\tv731.value.w = v294.value.w;\n\tv809 = HutongGames.PlayMaker.FsmVariables::get_QuaternionVariables(source);\n\tv1196 = v809 == 0;\n\tv880 = ~v1196;\n\tif (v880) goto L_023A;\n\tgoto L_0402;\nL_0271:\n\tv812 = HutongGames.PlayMaker.FsmVariables::get_ObjectVariables(source);\nL_027F:\n\tv175 = v768 >= v812.Length;\n\tif (v175) goto L_02B3;\n\tv733 = this.objectVariables;\n\tv1193 = v768 < v733.Length;\n\tv655 = ~v1193;\n\tif (v655) goto L_040B;\n\tv297 = source.objectVariables;\n\tv1197 = v768 < v297.Length;\n\tv656 = ~v1197;\n\tif (v656) goto L_040B;\n\tv224 = v733[v768 @ X21_v24 (System.Int32)];\n\tv813 = HutongGames.PlayMaker.FsmObject::get_Value(v297[v768 @ X21_v24 (System.Int32)]);\n\tv224.value = v813;\n\tv768 = v768 + 1;\n\tv812 = HutongGames.PlayMaker.FsmVariables::get_ObjectVariables(source);\n\tv1227 = v812 == 0;\n\tv885 = ~v1227;\n\tif (v885) goto L_027F;\n\tgoto L_0402;\nL_02B3:\n\tv816 = HutongGames.PlayMaker.FsmVariables::get_MaterialVariables(source);\nL_02C1:\n\tv176 = v225 >= v816.Length;\n\tif (v176) goto L_02F8;\n\tv736 = this.materialVariables;\n\tv1211 = v225 < v736.Length;\n\tv658 = ~v1211;\n\tif (v658) goto L_040B;\n\tv300 = source.materialVariables;\n\tv1214 = v225 < v300.Length;\n\tv659 = ~v1214;\n\tif (v659) goto L_040B;\n\tv817 = HutongGames.PlayMaker.FsmMaterial::get_Value(v300[v225 @ X22_v14 (System.Int32)]);\n\tv226 = v225 + 1;\n\tHutongGames.PlayMaker.FsmMaterial::set_Value(v736[v225 @ X22_v14 (System.Int32)], v817);\n\tv816 = HutongGames.PlayMaker.FsmVariables::get_MaterialVariables(source);\n\tv1248 = v816 == 0;\n\tv890 = ~v1248;\n\tif (v890) goto L_02C1;\n\tgoto L_0402;\nL_02F8:\n\tv820 = HutongGames.PlayMaker.FsmVariables::get_TextureVariables(source);\nL_0306:\n\tv177 = v227 >= v820.Length;\n\tif (v177) goto L_033D;\n\tv739 = this.textureVariables;\n\tv1230 = v227 < v739.Length;\n\tv661 = ~v1230;\n\tif (v661) goto L_040B;\n\tv303 = source.textureVariables;\n\tv1233 = v227 < v303.Length;\n\tv662 = ~v1233;\n\tif (v662) goto L_040B;\n\tv821 = HutongGames.PlayMaker.FsmTexture::get_Value(v303[v227 @ X22_v16 (System.Int32)]);\n\tv228 = v227 + 1;\n\tHutongGames.PlayMaker.FsmTexture::set_Value(v739[v227 @ X22_v16 (System.Int32)], v821);\n\tv820 = HutongGames.PlayMaker.FsmVariables::get_TextureVariables(source);\n\tv1268 \n// ... truncated")]
		public void ApplyVariableValues(FsmVariables source)
		{
			//IL_003d: Expected O, but got I8
			//IL_11a4: Expected O, but got I
			//IL_009b: Expected O, but got I
			if (source == null)
			{
				return;
			}
			FsmFloat[] array = source.FloatVariables;
			object obj = 4294967295L;
			while (true)
			{
				object obj2 = (long)(IntPtr)obj + 1L;
				if ((long)(IntPtr)obj2 < (long)array.Length)
				{
					FsmFloat[] array2 = floatVariables;
					if ((long)(IntPtr)obj2 >= (long)array2.Length)
					{
						break;
					}
					FsmFloat[] array3 = source.floatVariables;
					obj = (long)(IntPtr)obj + 1L;
					if ((long)(IntPtr)obj >= (long)array3.Length)
					{
						break;
					}
					FsmFloat fsmFloat = array2[obj2];
					float value = array3[obj2].Value;
					fsmFloat.Value = value;
					array = source.FloatVariables;
					if (array != null)
					{
						continue;
					}
					goto IL_1180;
				}
				FsmInt[] array4 = source.IntVariables;
				int num = 0;
				while (true)
				{
					if (num < array4.Length)
					{
						FsmInt[] array5 = intVariables;
						if (num >= array5.Length)
						{
							break;
						}
						FsmInt[] array6 = source.intVariables;
						if (num >= array6.Length)
						{
							break;
						}
						FsmInt fsmInt = array5[num];
						int value2 = array6[num].Value;
						fsmInt.Value = value2;
						num++;
						array4 = source.IntVariables;
						if (array4 != null)
						{
							continue;
						}
						goto IL_1180;
					}
					FsmBool[] array7 = source.BoolVariables;
					int num2 = 0;
					while (true)
					{
						if (num2 < array7.Length)
						{
							FsmBool[] array8 = boolVariables;
							if (num2 >= array8.Length)
							{
								break;
							}
							FsmBool[] array9 = source.boolVariables;
							if (num2 >= array9.Length)
							{
								break;
							}
							FsmBool fsmBool = array8[num2];
							bool value3 = array9[num2].Value;
							num2++;
							fsmBool.value = value3;
							array7 = source.BoolVariables;
							if (array7 != null)
							{
								continue;
							}
							goto IL_1180;
						}
						FsmGameObject[] array10 = source.GameObjectVariables;
						int num3 = 0;
						while (true)
						{
							if (num3 < array10.Length)
							{
								FsmGameObject[] array11 = gameObjectVariables;
								if (num3 >= array11.Length)
								{
									break;
								}
								FsmGameObject[] array12 = source.gameObjectVariables;
								if (num3 >= array12.Length)
								{
									break;
								}
								GameObject value4 = array12[num3].Value;
								int num4 = num3 + 1;
								array11[num3].Value = value4;
								array10 = source.GameObjectVariables;
								bool flag = array10 == null;
								bool flag2 = !flag;
								num3 = num4;
								if (flag2)
								{
									continue;
								}
								goto IL_1180;
							}
							FsmColor[] array13 = source.ColorVariables;
							int num5 = 0;
							while (true)
							{
								if (num5 < array13.Length)
								{
									FsmColor[] array14 = colorVariables;
									if (num5 >= array14.Length)
									{
										break;
									}
									FsmColor[] array15 = source.colorVariables;
									if (num5 >= array15.Length)
									{
										break;
									}
									FsmColor fsmColor = array15[num5];
									FsmColor fsmColor2 = array14[num5];
									num5++;
									fsmColor2.value.r = fsmColor.value.r;
									fsmColor2.value.g = fsmColor.value.g;
									fsmColor2.value.a = fsmColor.value.a;
									array13 = source.ColorVariables;
									if (array13 != null)
									{
										continue;
									}
									goto IL_1180;
								}
								FsmVector2[] array16 = source.Vector2Variables;
								int num6 = 0;
								while (true)
								{
									if (num6 < array16.Length)
									{
										FsmVector2[] array17 = vector2Variables;
										if (num6 >= array17.Length)
										{
											break;
										}
										FsmVector2[] array18 = source.vector2Variables;
										if (num6 >= array18.Length)
										{
											break;
										}
										FsmVector2 fsmVector = array18[num6];
										FsmVector2 fsmVector2 = array17[num6];
										num6++;
										fsmVector2.value = fsmVector.value;
										fsmVector2.value.y = fsmVector.value.y;
										array16 = source.Vector2Variables;
										if (array16 != null)
										{
											continue;
										}
										goto IL_1180;
									}
									FsmVector3[] array19 = source.Vector3Variables;
									int num7 = 0;
									while (true)
									{
										if (num7 < array19.Length)
										{
											FsmVector3[] array20 = vector3Variables;
											if (num7 >= array20.Length)
											{
												break;
											}
											FsmVector3[] array21 = source.vector3Variables;
											if (num7 >= array21.Length)
											{
												break;
											}
											FsmVector3 fsmVector3 = array20[num7];
											Vector3 value5 = array21[num7].Value;
											num7++;
											fsmVector3.value = value5;
											fsmVector3.value.y = value5.y;
											fsmVector3.value.z = value5.z;
											array19 = source.Vector3Variables;
											if (array19 != null)
											{
												continue;
											}
											goto IL_1180;
										}
										FsmRect[] array22 = source.RectVariables;
										int num8 = 0;
										while (true)
										{
											if (num8 < array22.Length)
											{
												FsmRect[] array23 = rectVariables;
												if (num8 >= array23.Length)
												{
													break;
												}
												FsmRect[] array24 = source.rectVariables;
												if (num8 >= array24.Length)
												{
													break;
												}
												FsmRect fsmRect = array24[num8];
												FsmRect fsmRect2 = array23[num8];
												num8++;
												fsmRect2.value.x = fsmRect.value.x;
												fsmRect2.value.y = fsmRect.value.y;
												fsmRect2.value.height = fsmRect.value.height;
												array22 = source.RectVariables;
												if (array22 != null)
												{
													continue;
												}
												goto IL_1180;
											}
											FsmQuaternion[] array25 = source.QuaternionVariables;
											int num9 = 0;
											while (true)
											{
												if (num9 < array25.Length)
												{
													FsmQuaternion[] array26 = quaternionVariables;
													if (num9 >= array26.Length)
													{
														break;
													}
													FsmQuaternion[] array27 = source.quaternionVariables;
													if (num9 >= array27.Length)
													{
														break;
													}
													FsmQuaternion fsmQuaternion = array27[num9];
													FsmQuaternion fsmQuaternion2 = array26[num9];
													num9++;
													fsmQuaternion2.value.x = fsmQuaternion.value.x;
													fsmQuaternion2.value.y = fsmQuaternion.value.y;
													fsmQuaternion2.value.w = fsmQuaternion.value.w;
													array25 = source.QuaternionVariables;
													if (array25 != null)
													{
														continue;
													}
													goto IL_1180;
												}
												FsmObject[] array28 = source.ObjectVariables;
												int num10 = 0;
												while (true)
												{
													if (num10 < array28.Length)
													{
														FsmObject[] array29 = objectVariables;
														if (num10 >= array29.Length)
														{
															break;
														}
														FsmObject[] array30 = source.objectVariables;
														if (num10 >= array30.Length)
														{
															break;
														}
														FsmObject fsmObject = array29[num10];
														UnityEngine.Object value6 = array30[num10].Value;
														fsmObject.Value = value6;
														num10++;
														array28 = source.ObjectVariables;
														if (array28 != null)
														{
															continue;
														}
														goto IL_1180;
													}
													FsmMaterial[] array31 = source.MaterialVariables;
													int num11 = 0;
													while (true)
													{
														if (num11 < array31.Length)
														{
															FsmMaterial[] array32 = materialVariables;
															if (num11 >= array32.Length)
															{
																break;
															}
															FsmMaterial[] array33 = source.materialVariables;
															if (num11 >= array33.Length)
															{
																break;
															}
															Material value7 = array33[num11].Value;
															int num12 = num11 + 1;
															array32[num11].Value = value7;
															array31 = source.MaterialVariables;
															bool flag3 = array31 == null;
															bool flag4 = !flag3;
															num11 = num12;
															if (flag4)
															{
																continue;
															}
															goto IL_1180;
														}
														FsmTexture[] array34 = source.TextureVariables;
														int num13 = 0;
														while (true)
														{
															if (num13 < array34.Length)
															{
																FsmTexture[] array35 = textureVariables;
																if (num13 >= array35.Length)
																{
																	break;
																}
																FsmTexture[] array36 = source.textureVariables;
																if (num13 >= array36.Length)
																{
																	break;
																}
																Texture value8 = array36[num13].Value;
																int num14 = num13 + 1;
																array35[num13].Value = value8;
																array34 = source.TextureVariables;
																bool flag5 = array34 == null;
																bool flag6 = !flag5;
																num13 = num14;
																if (flag6)
																{
																	continue;
																}
																goto IL_1180;
															}
															FsmString[] array37 = source.StringVariables;
															int num15 = 0;
															while (true)
															{
																if (num15 < array37.Length)
																{
																	FsmString[] array38 = stringVariables;
																	if (num15 >= array38.Length)
																	{
																		break;
																	}
																	FsmString[] array39 = source.stringVariables;
																	if (num15 >= array39.Length)
																	{
																		break;
																	}
																	FsmString fsmString = array38[num15];
																	string value9 = array39[num15].Value;
																	fsmString.Value = value9;
																	num15++;
																	array37 = source.StringVariables;
																	if (array37 != null)
																	{
																		continue;
																	}
																	goto IL_1180;
																}
																FsmEnum[] array40 = source.EnumVariables;
																int num16 = 0;
																while (true)
																{
																	if (num16 < array40.Length)
																	{
																		FsmEnum[] array41 = enumVariables;
																		if (num16 >= array41.Length)
																		{
																			break;
																		}
																		FsmEnum[] array42 = source.enumVariables;
																		if (num16 >= array42.Length)
																		{
																			break;
																		}
																		Enum value10 = array42[num16].Value;
																		int num17 = num16 + 1;
																		array41[num16].Value = value10;
																		array40 = source.EnumVariables;
																		bool flag7 = array40 == null;
																		bool flag8 = !flag7;
																		num16 = num17;
																		if (flag8)
																		{
																			continue;
																		}
																		goto IL_1180;
																	}
																	FsmArray[] array43 = source.ArrayVariables;
																	int num18 = 0;
																	while (true)
																	{
																		if (num18 < array43.Length)
																		{
																			FsmArray[] array44 = arrayVariables;
																			if (num18 >= array44.Length)
																			{
																				break;
																			}
																			FsmArray[] array45 = source.arrayVariables;
																			if (num18 >= array45.Length)
																			{
																				break;
																			}
																			int num19 = num18 + 1;
																			array44[num18].CopyValues(array45[num18]);
																			array43 = source.ArrayVariables;
																			bool flag9 = array43 == null;
																			bool flag10 = !flag9;
																			num18 = num19;
																			if (flag10)
																			{
																				continue;
																			}
																			goto IL_1180;
																		}
																		return;
																	}
																	break;
																}
																break;
															}
															break;
														}
														break;
													}
													break;
												}
												break;
											}
											break;
										}
										break;
									}
									break;
								}
								break;
							}
							break;
						}
						break;
					}
					break;
				}
				break;
				IL_1180:
				throw new NullReferenceException();
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x600060D")]
		[Address(RVA = "0xE4DAB0", Offset = "0xE4DAB0", Length = "0x974")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = source == 0;\n\tif (v20) goto L_046C;\n\tv769 = HutongGames.PlayMaker.FsmVariables::get_FloatVariables(source);\nL_001C:\n\tv155 = v739 >= v769.Length;\n\tif (v155) goto L_0056;\n\tv690 = source.floatVariables;\n\tv891 = v739 < v690.Length;\n\tv637 = ~v891;\n\tif (v637) goto L_046E;\n\tv691 = v690[v739 @ X22_v5 (System.Int32)];\n\tv770 = HutongGames.PlayMaker.FsmVariables::FindFsmFloat(this, v691.name);\n\tv1115 = v770 == 0;\n\tif (v1115) goto L_004F;\n\tv692 = source.floatVariables;\n\tv1125 = v739 < v692.Length;\n\tv1012 = ~v1125;\n\tif (v1012) goto L_046E;\n\tv1116 = HutongGames.PlayMaker.FsmFloat::get_Value(v692[v739 @ X22_v5 (System.Int32)]);\n\tv770.value = v1116;\nL_004F:\n\tv739 = v739 + 1;\n\tv769 = HutongGames.PlayMaker.FsmVariables::get_FloatVariables(source);\n\tv1126 = v769 == 0;\n\tv820 = ~v1126;\n\tif (v820) goto L_001C;\n\tgoto L_0463;\nL_0056:\n\tv1111 = HutongGames.PlayMaker.FsmVariables::get_IntVariables(source);\nL_0065:\n\tv156 = v741 >= v1111.Length;\n\tif (v156) goto L_009F;\n\tv773 = HutongGames.PlayMaker.FsmVariables::get_IntVariables(source);\n\tv1127 = v741 < v773.Length;\n\tv639 = ~v1127;\n\tif (v639) goto L_046E;\n\tv695 = v773[v741 @ X22_v9 (System.Int32)];\n\tv1190 = HutongGames.PlayMaker.FsmVariables::FindFsmInt(this, v695.name);\n\tv1191 = v1190 == 0;\n\tif (v1191) goto L_0099;\n\tv1059 = HutongGames.PlayMaker.FsmVariables::get_IntVariables(source);\n\tv1216 = v741 < v1059.Length;\n\tv1013 = ~v1216;\n\tif (v1013) goto L_046E;\n\tv1195 = HutongGames.PlayMaker.FsmInt::get_Value(v1059[v741 @ X22_v9 (System.Int32)]);\n\tv1190.value = v1195;\nL_0099:\n\tv741 = v741 + 1;\n\tv1111 = HutongGames.PlayMaker.FsmVariables::get_IntVariables(source);\n\tv1200 = v1111 == 0;\n\tv823 = ~v1200;\n\tif (v823) goto L_0065;\n\tgoto L_0463;\nL_009F:\n\tv1185 = HutongGames.PlayMaker.FsmVariables::get_BoolVariables(source);\nL_00AE:\n\tv157 = v743 >= v1185.Length;\n\tif (v157) goto L_00E9;\n\tv776 = HutongGames.PlayMaker.FsmVariables::get_BoolVariables(source);\n\tv1198 = v743 < v776.Length;\n\tv642 = ~v1198;\n\tif (v642) goto L_046E;\n\tv698 = v776[v743 @ X22_v11 (System.Int32)];\n\tv1218 = HutongGames.PlayMaker.FsmVariables::FindFsmBool(this, v698.name);\n\tv1219 = v1218 == 0;\n\tif (v1219) goto L_00E3;\n\tv1060 = HutongGames.PlayMaker.FsmVariables::get_BoolVariables(source);\n\tv1245 = v743 < v1060.Length;\n\tv1014 = ~v1245;\n\tif (v1014) goto L_046E;\n\tv1224 = HutongGames.PlayMaker.FsmBool::get_Value(v1060[v743 @ X22_v11 (System.Int32)]);\n\tv1218.value = v1224;\nL_00E3:\n\tv743 = v743 + 1;\n\tv1185 = HutongGames.PlayMaker.FsmVariables::get_BoolVariables(source);\n\tv1229 = v1185 == 0;\n\tv826 = ~v1229;\n\tif (v826) goto L_00AE;\n\tgoto L_0463;\nL_00E9:\n\tv1212 = HutongGames.PlayMaker.FsmVariables::get_GameObjectVariables(source);\nL_00F8:\n\tv158 = v745 >= v1212.Length;\n\tif (v158) goto L_0133;\n\tv779 = HutongGames.PlayMaker.FsmVariables::get_BoolVariables(source);\n\tv1227 = v745 < v779.Length;\n\tv645 = ~v1227;\n\tif (v645) goto L_046E;\n\tv701 = v779[v745 @ X22_v13 (System.Int32)];\n\tv1247 = HutongGames.PlayMaker.FsmVariables::FindFsmBool(this, v701.name);\n\tv1248 = v1247 == 0;\n\tif (v1248) goto L_012D;\n\tv1061 = HutongGames.PlayMaker.FsmVariables::get_BoolVariables(source);\n\tv1274 = v745 < v1061.Length;\n\tv1015 = ~v1274;\n\tif (v1015) goto L_046E;\n\tv1253 = HutongGames.PlayMaker.FsmBool::get_Value(v1061[v745 @ X22_v13 (System.Int32)]);\n\tv1247.value = v1253;\nL_012D:\n\tv745 = v745 + 1;\n\tv1212 = HutongGames.PlayMaker.FsmVariables::get_GameObjectVariables(source);\n\tv1258 = v1212 == 0;\n\tv829 = ~v1258;\n\tif (v829) goto L_00F8;\n\tgoto L_0463;\nL_0133:\n\tv1241 = HutongGames.PlayMaker.FsmVariables::get_ColorVariables(source);\nL_0142:\n\tv159 = v747 >= v1241.Length;\n\tif (v159) goto L_017D;\n\tv782 = HutongGames.PlayMaker.FsmVariables::get_BoolVariables(source);\n\tv1256 = v747 < v782.Length;\n\tv648 = ~v1256;\n\tif (v648) goto L_046E;\n\tv704 = v782[v747 @ X22_v15 (System.Int32)];\n\tv1276 = HutongGames.PlayMaker.FsmVariables::FindFsmBool(this, v704.name);\n\tv1277 = v1276 == 0;\n\tif (v1277) goto L_0177;\n\tv1062 = HutongGames.PlayMaker.FsmVariables::get_BoolVariables(source);\n\tv1303 = v747 < v1062.Length;\n\tv1016 = ~v1303;\n\tif (v1016) goto L_046E;\n\tv1282 = HutongGames.PlayMaker.FsmBool::get_Value(v1062[v747 @ X22_v15 (System.Int32)]);\n\tv1276.value = v1282;\nL_0177:\n\tv747 = v747 + 1;\n\tv1241 = HutongGames.PlayMaker.FsmVariables::get_ColorVariables(source);\n\tv1287 = v1241 == 0;\n\tv832 = ~v1287;\n\tif (v832) goto L_0142;\n\tgoto L_0463;\nL_017D:\n\tv1270 = HutongGames.PlayMaker.FsmVariables::get_Vector2Variables(source);\nL_018C:\n\tv160 = v749 >= v1270.Length;\n\tif (v160) goto L_01C7;\n\tv785 = HutongGames.PlayMaker.FsmVariables::get_BoolVariables(source);\n\tv1285 = v749 < v785.Length;\n\tv651 = ~v1285;\n\tif (v651) goto L_046E;\n\tv707 = v785[v749 @ X22_v17 (System.Int32)];\n\tv1305 = HutongGames.PlayMaker.FsmVariables::FindFsmBool(this, v707.name);\n\tv1306 = v1305 == 0;\n\tif (v1306) goto L_01C1;\n\tv1063 = HutongGames.PlayMaker.FsmVariables::get_BoolVariables(source);\n\tv1332 = v749 < v1063.Length;\n\tv1017 = ~v1332;\n\tif (v1017) goto L_046E;\n\tv1311 = HutongGames.PlayMaker.FsmBool::get_Value(v1063[v749 @ X22_v17 (System.Int32)]);\n\tv1305.value = v1311;\nL_01C1:\n\tv749 = v749 + 1;\n\tv1270 = HutongGames.PlayMaker.FsmVariables::get_Vector2Variables(source);\n\tv1316 = v1270 == 0;\n\tv835 = ~v1316;\n\tif (v835) goto L_018C;\n\tgoto L_0463;\nL_01C7:\n\tv1299 = HutongGames.PlayMaker.FsmVariables::get_Vector3Variables(source);\nL_01D6:\n\tv161 = v751 >= v1299.Length;\n\tif (v161) goto L_0211;\n\tv788 = HutongGames.PlayMaker.FsmVariables::get_BoolVariables(source);\n\tv1314 = v751 < v788.Length;\n\tv654 = ~v1314;\n\tif (v654) goto L_046E;\n\tv710 = v788[v751 @ X22_v19 (System.Int32)];\n\tv1334 = HutongGames.PlayMaker.FsmVariables::FindFsmBool(this, v710.name);\n\tv1335 = v1334 == 0;\n\tif (v1335) goto L_020B;\n\tv1064 = HutongGames.PlayMaker.FsmVariables::get_BoolVariables(source);\n\tv1361 = v751 < v1064.Length;\n\tv1018 = ~v1361;\n\tif (v1018) goto L_046E;\n\tv1340 = HutongGames.PlayMaker.FsmBool::get_Value(v1064[v751 @ X22_v19 (System.Int32)]);\n\tv1334.value = v1340;\nL_020B:\n\tv751 = v751 + 1;\n\tv1299 = HutongGames.PlayMaker.FsmVariables::get_Vector3Variables(source);\n\tv1345 = v1299 == 0;\n\tv838 = ~v1345;\n\tif (v838) goto L_01D6;\n\tgoto L_0463;\nL_0211:\n\tv1328 = HutongGames.PlayMaker.FsmVariables::get_RectVariables(source);\nL_0220:\n\tv162 = v753 >= v1328.Length;\n\tif (v162) goto L_025D;\n\tv791 = HutongGames.PlayMaker.FsmVariables::get_RectVariables(source);\n\tv1343 = v753 < v791.Length;\n\tv657 = ~v1343;\n\tif (v657) goto L_046E;\n\tv713 = v791[v753 @ X22_v21 (System.Int32)];\n\tv1363 = HutongGames.PlayMaker.FsmVariables::FindFsmRect(this, v713.name);\n\tv1364 = v1363 == 0;\n\tif (v1364) goto L_0257;\n\tv792 = HutongGames.PlayMaker.FsmVariables::get_RectVariables(source);\n\tv1390 = v753 < v792.Length;\n\tv658 = ~v1390;\n\tif (v658) goto L_046E;\n\tv714 = v792[v753 @ X22_v21 (System.Int32)];\n\tv1363.value.m_XMin = v714.value;\n\tv1363.value.m_YMin = v714.value.m_YMin;\n\tv1363.value.m_Height = v714.value.m_Height;\nL_0257:\n\tv753 = v753 + 1;\n\tv1328 = HutongGames.PlayMaker.FsmVariables::get_RectVariables(source);\n\tv1374 = v1328 == 0;\n\tv842 = ~v1374;\n\tif (v842) goto L_0220;\n\tgoto L_0463;\nL_025D:\n\tv1357 = HutongGames.PlayMaker.FsmVariables::get_QuaternionVariables(source);\nL_026C:\n\tv163 = v755 >= v1357.Length;\n\tif (v163) goto L_02A9;\n\tv795 = HutongGames.PlayMaker.FsmVariables::get_QuaternionVariables(source);\n\tv1372 = v755 < v795.Length;\n\tv661 = ~v1372;\n\tif (v661) goto L_046E;\n\tv717 = v795[v755 @ X22_v23 (System.Int32)];\n\tv1392 = HutongGames.PlayMaker.FsmVariables::FindFsmQuaternion(this, v717.name);\n\tv1394 = v1392 == 0;\n\tif (v1394) goto L_02A3;\n\tv796 = HutongGames.PlayMaker.FsmVariables::get_QuaternionVariables(source);\n\tv1420 = v755 < v796.Length;\n\tv662 = ~v1420;\n\tif (v662) goto L_046E;\n\tv718 = v796[v755 @ X22_v23 (System.Int32)];\n\tv1392.value.x = v718.value;\n\tv1392.value.y = v718.value.y;\n\tv1392.value.w = v718.value.w;\nL_02A3:\n\tv755 = v755 + 1;\n\tv1357 = HutongGames.PlayMaker.FsmVariables::get_QuaternionVariables(source);\n\tv1404 = v1357 == 0;\n\tv846 = ~v1404;\n\tif (v846) goto L_026C;\n\tgoto L_0463;\nL_02A9:\n\tv1386 = HutongGames.PlayMaker.FsmVariables::get_ObjectVariables(source);\nL_02B8:\n\tv164 = v757 >= v1386.Length;\n\tif (v164) goto L_02F2;\n\tv799 = HutongGames.P\n// ... truncated")]
		public void ApplyVariableValuesCareful(FsmVariables source)
		{
			if (source == null)
			{
				return;
			}
			FsmFloat[] array = source.FloatVariables;
			int num = 0;
			while (true)
			{
				if (num < array.Length)
				{
					FsmFloat[] array2 = source.floatVariables;
					if (num >= array2.Length)
					{
						break;
					}
					FsmFloat fsmFloat = array2[num];
					FsmFloat fsmFloat2 = FindFsmFloat(fsmFloat.Name);
					if (fsmFloat2 != null)
					{
						FsmFloat[] array3 = source.floatVariables;
						if (num >= array3.Length)
						{
							break;
						}
						float value = array3[num].Value;
						fsmFloat2.Value = value;
					}
					num++;
					array = source.FloatVariables;
					if (array != null)
					{
						continue;
					}
					goto IL_114e;
				}
				FsmInt[] array4 = source.IntVariables;
				int num2 = 0;
				while (true)
				{
					if (num2 < array4.Length)
					{
						FsmInt[] array5 = source.IntVariables;
						if (num2 >= array5.Length)
						{
							break;
						}
						FsmInt fsmInt = array5[num2];
						FsmInt fsmInt2 = FindFsmInt(fsmInt.Name);
						if (fsmInt2 != null)
						{
							FsmInt[] array6 = source.IntVariables;
							if (num2 >= array6.Length)
							{
								break;
							}
							int value2 = array6[num2].Value;
							fsmInt2.Value = value2;
						}
						num2++;
						array4 = source.IntVariables;
						if (array4 != null)
						{
							continue;
						}
						goto IL_114e;
					}
					FsmBool[] array7 = source.BoolVariables;
					int num3 = 0;
					while (true)
					{
						if (num3 < array7.Length)
						{
							FsmBool[] array8 = source.BoolVariables;
							if (num3 >= array8.Length)
							{
								break;
							}
							FsmBool fsmBool = array8[num3];
							FsmBool fsmBool2 = FindFsmBool(fsmBool.Name);
							if (fsmBool2 != null)
							{
								FsmBool[] array9 = source.BoolVariables;
								if (num3 >= array9.Length)
								{
									break;
								}
								bool value3 = array9[num3].Value;
								fsmBool2.value = value3;
							}
							num3++;
							array7 = source.BoolVariables;
							if (array7 != null)
							{
								continue;
							}
							goto IL_114e;
						}
						FsmGameObject[] array10 = source.GameObjectVariables;
						int num4 = 0;
						while (true)
						{
							if (num4 < array10.Length)
							{
								FsmBool[] array11 = source.BoolVariables;
								if (num4 >= array11.Length)
								{
									break;
								}
								FsmBool fsmBool3 = array11[num4];
								FsmBool fsmBool4 = FindFsmBool(fsmBool3.Name);
								if (fsmBool4 != null)
								{
									FsmBool[] array12 = source.BoolVariables;
									if (num4 >= array12.Length)
									{
										break;
									}
									bool value4 = array12[num4].Value;
									fsmBool4.value = value4;
								}
								num4++;
								array10 = source.GameObjectVariables;
								if (array10 != null)
								{
									continue;
								}
								goto IL_114e;
							}
							FsmColor[] array13 = source.ColorVariables;
							int num5 = 0;
							while (true)
							{
								if (num5 < array13.Length)
								{
									FsmBool[] array14 = source.BoolVariables;
									if (num5 >= array14.Length)
									{
										break;
									}
									FsmBool fsmBool5 = array14[num5];
									FsmBool fsmBool6 = FindFsmBool(fsmBool5.Name);
									if (fsmBool6 != null)
									{
										FsmBool[] array15 = source.BoolVariables;
										if (num5 >= array15.Length)
										{
											break;
										}
										bool value5 = array15[num5].Value;
										fsmBool6.value = value5;
									}
									num5++;
									array13 = source.ColorVariables;
									if (array13 != null)
									{
										continue;
									}
									goto IL_114e;
								}
								FsmVector2[] array16 = source.Vector2Variables;
								int num6 = 0;
								while (true)
								{
									if (num6 < array16.Length)
									{
										FsmBool[] array17 = source.BoolVariables;
										if (num6 >= array17.Length)
										{
											break;
										}
										FsmBool fsmBool7 = array17[num6];
										FsmBool fsmBool8 = FindFsmBool(fsmBool7.Name);
										if (fsmBool8 != null)
										{
											FsmBool[] array18 = source.BoolVariables;
											if (num6 >= array18.Length)
											{
												break;
											}
											bool value6 = array18[num6].Value;
											fsmBool8.value = value6;
										}
										num6++;
										array16 = source.Vector2Variables;
										if (array16 != null)
										{
											continue;
										}
										goto IL_114e;
									}
									FsmVector3[] array19 = source.Vector3Variables;
									int num7 = 0;
									while (true)
									{
										if (num7 < array19.Length)
										{
											FsmBool[] array20 = source.BoolVariables;
											if (num7 >= array20.Length)
											{
												break;
											}
											FsmBool fsmBool9 = array20[num7];
											FsmBool fsmBool10 = FindFsmBool(fsmBool9.Name);
											if (fsmBool10 != null)
											{
												FsmBool[] array21 = source.BoolVariables;
												if (num7 >= array21.Length)
												{
													break;
												}
												bool value7 = array21[num7].Value;
												fsmBool10.value = value7;
											}
											num7++;
											array19 = source.Vector3Variables;
											if (array19 != null)
											{
												continue;
											}
											goto IL_114e;
										}
										FsmRect[] array22 = source.RectVariables;
										int num8 = 0;
										while (true)
										{
											if (num8 < array22.Length)
											{
												FsmRect[] array23 = source.RectVariables;
												if (num8 >= array23.Length)
												{
													break;
												}
												FsmRect fsmRect = array23[num8];
												FsmRect fsmRect2 = FindFsmRect(fsmRect.Name);
												if (fsmRect2 != null)
												{
													FsmRect[] array24 = source.RectVariables;
													if (num8 >= array24.Length)
													{
														break;
													}
													FsmRect fsmRect3 = array24[num8];
													fsmRect2.value.x = fsmRect3.value.x;
													fsmRect2.value.y = fsmRect3.value.y;
													fsmRect2.value.height = fsmRect3.value.height;
												}
												num8++;
												array22 = source.RectVariables;
												if (array22 != null)
												{
													continue;
												}
												goto IL_114e;
											}
											FsmQuaternion[] array25 = source.QuaternionVariables;
											int num9 = 0;
											while (true)
											{
												if (num9 < array25.Length)
												{
													FsmQuaternion[] array26 = source.QuaternionVariables;
													if (num9 >= array26.Length)
													{
														break;
													}
													FsmQuaternion fsmQuaternion = array26[num9];
													FsmQuaternion fsmQuaternion2 = FindFsmQuaternion(fsmQuaternion.Name);
													if (fsmQuaternion2 != null)
													{
														FsmQuaternion[] array27 = source.QuaternionVariables;
														if (num9 >= array27.Length)
														{
															break;
														}
														FsmQuaternion fsmQuaternion3 = array27[num9];
														fsmQuaternion2.value.x = fsmQuaternion3.value.x;
														fsmQuaternion2.value.y = fsmQuaternion3.value.y;
														fsmQuaternion2.value.w = fsmQuaternion3.value.w;
													}
													num9++;
													array25 = source.QuaternionVariables;
													if (array25 != null)
													{
														continue;
													}
													goto IL_114e;
												}
												FsmObject[] array28 = source.ObjectVariables;
												int num10 = 0;
												while (true)
												{
													if (num10 < array28.Length)
													{
														FsmObject[] array29 = source.ObjectVariables;
														if (num10 >= array29.Length)
														{
															break;
														}
														FsmObject fsmObject = array29[num10];
														FsmObject fsmObject2 = FindFsmObject(fsmObject.Name);
														if (fsmObject2 != null)
														{
															FsmObject[] array30 = source.ObjectVariables;
															if (num10 >= array30.Length)
															{
																break;
															}
															UnityEngine.Object value8 = array30[num10].Value;
															fsmObject2.Value = value8;
														}
														num10++;
														array28 = source.ObjectVariables;
														if (array28 != null)
														{
															continue;
														}
														goto IL_114e;
													}
													FsmMaterial[] array31 = source.MaterialVariables;
													int num11 = 0;
													while (true)
													{
														if (num11 < array31.Length)
														{
															FsmMaterial[] array32 = source.MaterialVariables;
															if (num11 >= array32.Length)
															{
																break;
															}
															FsmMaterial fsmMaterial = array32[num11];
															FsmMaterial fsmMaterial2 = FindFsmMaterial(fsmMaterial.Name);
															if (fsmMaterial2 != null)
															{
																FsmMaterial[] array33 = source.MaterialVariables;
																if (num11 >= array33.Length)
																{
																	break;
																}
																Material value9 = array33[num11].Value;
																fsmMaterial2.Value = value9;
															}
															num11++;
															array31 = source.MaterialVariables;
															if (array31 != null)
															{
																continue;
															}
															goto IL_114e;
														}
														FsmTexture[] array34 = source.TextureVariables;
														int num12 = 0;
														while (true)
														{
															if (num12 < array34.Length)
															{
																FsmTexture[] array35 = source.TextureVariables;
																if (num12 >= array35.Length)
																{
																	break;
																}
																FsmTexture fsmTexture = array35[num12];
																FsmTexture fsmTexture2 = FindFsmTexture(fsmTexture.Name);
																if (fsmTexture2 != null)
																{
																	FsmTexture[] array36 = source.TextureVariables;
																	if (num12 >= array36.Length)
																	{
																		break;
																	}
																	Texture value10 = array36[num12].Value;
																	fsmTexture2.Value = value10;
																}
																num12++;
																array34 = source.TextureVariables;
																if (array34 != null)
																{
																	continue;
																}
																goto IL_114e;
															}
															FsmString[] array37 = source.StringVariables;
															int num13 = 0;
															while (true)
															{
																if (num13 < array37.Length)
																{
																	FsmString[] array38 = source.StringVariables;
																	if (num13 >= array38.Length)
																	{
																		break;
																	}
																	FsmString fsmString = array38[num13];
																	FsmString fsmString2 = FindFsmString(fsmString.Name);
																	if (fsmString2 != null)
																	{
																		FsmString[] array39 = source.StringVariables;
																		if (num13 >= array39.Length)
																		{
																			break;
																		}
																		string value11 = array39[num13].Value;
																		fsmString2.Value = value11;
																	}
																	num13++;
																	array37 = source.StringVariables;
																	if (array37 != null)
																	{
																		continue;
																	}
																	goto IL_114e;
																}
																FsmEnum[] array40 = source.EnumVariables;
																int num14 = 0;
																while (true)
																{
																	if (num14 < array40.Length)
																	{
																		FsmEnum[] array41 = source.EnumVariables;
																		if (num14 >= array41.Length)
																		{
																			break;
																		}
																		FsmEnum fsmEnum = array41[num14];
																		FsmEnum fsmEnum2 = FindFsmEnum(fsmEnum.Name);
																		if (fsmEnum2 != null)
																		{
																			FsmEnum[] array42 = source.EnumVariables;
																			if (num14 >= array42.Length)
																			{
																				break;
																			}
																			Enum value12 = array42[num14].Value;
																			fsmEnum2.Value = value12;
																		}
																		num14++;
																		array40 = source.EnumVariables;
																		if (array40 != null)
																		{
																			continue;
																		}
																		goto IL_114e;
																	}
																	FsmArray[] array43 = source.ArrayVariables;
																	int num15 = 0;
																	while (true)
																	{
																		if (num15 >= array43.Length)
																		{
																			return;
																		}
																		FsmArray[] array44 = source.ArrayVariables;
																		if (num15 >= array44.Length)
																		{
																			break;
																		}
																		FsmArray fsmArray = array44[num15];
																		FsmArray fsmArray2 = FindFsmArray(fsmArray.Name);
																		if (fsmArray2 != null)
																		{
																			FsmArray[] array45 = source.arrayVariables;
																			if (num15 >= array45.Length)
																			{
																				break;
																			}
																			fsmArray2.CopyValues(array45[num15]);
																		}
																		num15++;
																		array43 = source.ArrayVariables;
																		if (array43 != null)
																		{
																			continue;
																		}
																		goto IL_114e;
																	}
																	break;
																}
																break;
															}
															break;
														}
														break;
													}
													break;
												}
												break;
											}
											break;
										}
										break;
									}
									break;
								}
								break;
							}
							break;
						}
						break;
					}
					break;
				}
				break;
				IL_114e:
				throw new NullReferenceException();
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x600062C")]
		[Address(RVA = "0xE495BC", Offset = "0xE495BC", Length = "0xAE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = HutongGames.PlayMaker.FsmVariables::get_FloatVariables(this);\n\tv686 = v20.Length;\n\tv34 = v20.Length < 1;\n\tif (v34) goto L_0043;\nL_001D:\n\tv689 = v676 < v686;\n\tv690 = ~v689;\n\tif (v690) goto L_06C8;\n\tv654 = v20[v676 @ X23_v60 (System.Int32)];\n\tv670 = System.String::op_Equality(v654.name, v69);\n\tv1410 = v670 == 0;\n\tv668 = ~v1410;\n\tif (v668) goto L_06C7;\n\tv686 = v20.Length;\n\tv676 = v676 + 1;\n\tv657 = v676 < v20.Length;\n\tif (v657) goto L_001D;\nL_0043:\n\tv575 = HutongGames.PlayMaker.FsmVariables::get_IntVariables(this);\n\tv1149 = v575.Length;\n\tv1268 = v575.Length < 1;\n\tif (v1268) goto L_007B;\nL_0055:\n\tv1419 = v865 < v1149;\n\tv1119 = ~v1419;\n\tif (v1119) goto L_06C8;\n\tv1272 = v575[v865 @ X23_v57 (System.Int32)];\n\tv1407 = System.String::op_Equality(v1272.name, v69);\n\tv1598 = v1407 == 0;\n\tv1405 = ~v1598;\n\tif (v1405) goto L_06C7;\n\tv1149 = v575.Length;\n\tv865 = v865 + 1;\n\tv1394 = v865 < v575.Length;\n\tif (v1394) goto L_0055;\nL_007B:\n\tv576 = HutongGames.PlayMaker.FsmVariables::get_BoolVariables(this);\n\tv1150 = v576.Length;\n\tv1580 = v576.Length < 1;\n\tif (v1580) goto L_00B3;\nL_008D:\n\tv1607 = v866 < v1150;\n\tv1120 = ~v1607;\n\tif (v1120) goto L_06C8;\n\tv1273 = v576[v866 @ X23_v54 (System.Int32)];\n\tv1539 = System.String::op_Equality(v1273.name, v69);\n\tv1639 = v1539 == 0;\n\tv1506 = ~v1639;\n\tif (v1506) goto L_06C7;\n\tv1150 = v576.Length;\n\tv866 = v866 + 1;\n\tv1584 = v866 < v576.Length;\n\tif (v1584) goto L_008D;\nL_00B3:\n\tv577 = HutongGames.PlayMaker.FsmVariables::get_Vector2Variables(this);\n\tv1151 = v577.Length;\n\tv1621 = v577.Length < 1;\n\tif (v1621) goto L_00EB;\nL_00C5:\n\tv1648 = v867 < v1151;\n\tv1121 = ~v1648;\n\tif (v1121) goto L_06C8;\n\tv1274 = v577[v867 @ X23_v51 (System.Int32)];\n\tv1540 = System.String::op_Equality(v1274.name, v69);\n\tv1680 = v1540 == 0;\n\tv1507 = ~v1680;\n\tif (v1507) goto L_06C7;\n\tv1151 = v577.Length;\n\tv867 = v867 + 1;\n\tv1625 = v867 < v577.Length;\n\tif (v1625) goto L_00C5;\nL_00EB:\n\tv578 = HutongGames.PlayMaker.FsmVariables::get_Vector3Variables(this);\n\tv1152 = v578.Length;\n\tv1662 = v578.Length < 1;\n\tif (v1662) goto L_0123;\nL_00FD:\n\tv1689 = v868 < v1152;\n\tv1122 = ~v1689;\n\tif (v1122) goto L_06C8;\n\tv1275 = v578[v868 @ X23_v48 (System.Int32)];\n\tv1541 = System.String::op_Equality(v1275.name, v69);\n\tv1721 = v1541 == 0;\n\tv1508 = ~v1721;\n\tif (v1508) goto L_06C7;\n\tv1152 = v578.Length;\n\tv868 = v868 + 1;\n\tv1666 = v868 < v578.Length;\n\tif (v1666) goto L_00FD;\nL_0123:\n\tv579 = HutongGames.PlayMaker.FsmVariables::get_StringVariables(this);\n\tv1153 = v579.Length;\n\tv1703 = v579.Length < 1;\n\tif (v1703) goto L_015B;\nL_0135:\n\tv1730 = v869 < v1153;\n\tv1123 = ~v1730;\n\tif (v1123) goto L_06C8;\n\tv1276 = v579[v869 @ X23_v45 (System.Int32)];\n\tv1542 = System.String::op_Equality(v1276.name, v69);\n\tv1762 = v1542 == 0;\n\tv1509 = ~v1762;\n\tif (v1509) goto L_06C7;\n\tv1153 = v579.Length;\n\tv869 = v869 + 1;\n\tv1707 = v869 < v579.Length;\n\tif (v1707) goto L_0135;\nL_015B:\n\tv580 = HutongGames.PlayMaker.FsmVariables::get_RectVariables(this);\n\tv1154 = v580.Length;\n\tv1744 = v580.Length < 1;\n\tif (v1744) goto L_0193;\nL_016D:\n\tv1771 = v870 < v1154;\n\tv1124 = ~v1771;\n\tif (v1124) goto L_06C8;\n\tv1277 = v580[v870 @ X23_v42 (System.Int32)];\n\tv1543 = System.String::op_Equality(v1277.name, v69);\n\tv1803 = v1543 == 0;\n\tv1510 = ~v1803;\n\tif (v1510) goto L_06C7;\n\tv1154 = v580.Length;\n\tv870 = v870 + 1;\n\tv1748 = v870 < v580.Length;\n\tif (v1748) goto L_016D;\nL_0193:\n\tv581 = HutongGames.PlayMaker.FsmVariables::get_ColorVariables(this);\n\tv1155 = v581.Length;\n\tv1785 = v581.Length < 1;\n\tif (v1785) goto L_01CB;\nL_01A5:\n\tv1812 = v871 < v1155;\n\tv1125 = ~v1812;\n\tif (v1125) goto L_06C8;\n\tv1278 = v581[v871 @ X23_v39 (System.Int32)];\n\tv1544 = System.String::op_Equality(v1278.name, v69);\n\tv1844 = v1544 == 0;\n\tv1511 = ~v1844;\n\tif (v1511) goto L_06C7;\n\tv1155 = v581.Length;\n\tv871 = v871 + 1;\n\tv1789 = v871 < v581.Length;\n\tif (v1789) goto L_01A5;\nL_01CB:\n\tv582 = HutongGames.PlayMaker.FsmVariables::get_MaterialVariables(this);\n\tv1156 = v582.Length;\n\tv1826 = v582.Length < 1;\n\tif (v1826) goto L_0203;\nL_01DD:\n\tv1853 = v872 < v1156;\n\tv1126 = ~v1853;\n\tif (v1126) goto L_06C8;\n\tv1279 = v582[v872 @ X23_v36 (System.Int32)];\n\tv1545 = System.String::op_Equality(v1279.name, v69);\n\tv1885 = v1545 == 0;\n\tv1512 = ~v1885;\n\tif (v1512) goto L_06C7;\n\tv1156 = v582.Length;\n\tv872 = v872 + 1;\n\tv1830 = v872 < v582.Length;\n\tif (v1830) goto L_01DD;\nL_0203:\n\tv583 = HutongGames.PlayMaker.FsmVariables::get_TextureVariables(this);\n\tv1157 = v583.Length;\n\tv1867 = v583.Length < 1;\n\tif (v1867) goto L_023B;\nL_0215:\n\tv1894 = v873 < v1157;\n\tv1127 = ~v1894;\n\tif (v1127) goto L_06C8;\n\tv1280 = v583[v873 @ X23_v33 (System.Int32)];\n\tv1546 = System.String::op_Equality(v1280.name, v69);\n\tv1926 = v1546 == 0;\n\tv1513 = ~v1926;\n\tif (v1513) goto L_06C7;\n\tv1157 = v583.Length;\n\tv873 = v873 + 1;\n\tv1871 = v873 < v583.Length;\n\tif (v1871) goto L_0215;\nL_023B:\n\tv584 = HutongGames.PlayMaker.FsmVariables::get_ObjectVariables(this);\n\tv1158 = v584.Length;\n\tv1908 = v584.Length < 1;\n\tif (v1908) goto L_0273;\nL_024D:\n\tv1935 = v874 < v1158;\n\tv1128 = ~v1935;\n\tif (v1128) goto L_06C8;\n\tv1281 = v584[v874 @ X23_v30 (System.Int32)];\n\tv1547 = System.String::op_Equality(v1281.name, v69);\n\tv1967 = v1547 == 0;\n\tv1514 = ~v1967;\n\tif (v1514) goto L_06C7;\n\tv1158 = v584.Length;\n\tv874 = v874 + 1;\n\tv1912 = v874 < v584.Length;\n\tif (v1912) goto L_024D;\nL_0273:\n\tv585 = HutongGames.PlayMaker.FsmVariables::get_GameObjectVariables(this);\n\tv1159 = v585.Length;\n\tv1949 = v585.Length < 1;\n\tif (v1949) goto L_02AB;\nL_0285:\n\tv1976 = v875 < v1159;\n\tv1129 = ~v1976;\n\tif (v1129) goto L_06C8;\n\tv1282 = v585[v875 @ X23_v27 (System.Int32)];\n\tv1548 = System.String::op_Equality(v1282.name, v69);\n\tv2008 = v1548 == 0;\n\tv1515 = ~v2008;\n\tif (v1515) goto L_06C7;\n\tv1159 = v585.Length;\n\tv875 = v875 + 1;\n\tv1953 = v875 < v585.Length;\n\tif (v1953) goto L_0285;\nL_02AB:\n\tv586 = HutongGames.PlayMaker.FsmVariables::get_QuaternionVariables(this);\n\tv1160 = v586.Length;\n\tv1990 = v586.Length < 1;\n\tif (v1990) goto L_02E3;\nL_02BD:\n\tv2017 = v876 < v1160;\n\tv1130 = ~v2017;\n\tif (v1130) goto L_06C8;\n\tv1283 = v586[v876 @ X23_v24 (System.Int32)];\n\tv1549 = System.String::op_Equality(v1283.name, v69);\n\tv2049 = v1549 == 0;\n\tv1516 = ~v2049;\n\tif (v1516) goto L_06C7;\n\tv1160 = v586.Length;\n\tv876 = v876 + 1;\n\tv1994 = v876 < v586.Length;\n\tif (v1994) goto L_02BD;\nL_02E3:\n\tv587 = HutongGames.PlayMaker.FsmVariables::get_EnumVariables(this);\n\tv1161 = v587.Length;\n\tv2031 = v587.Length < 1;\n\tif (v2031) goto L_031B;\nL_02F5:\n\tv2058 = v877 < v1161;\n\tv1131 = ~v2058;\n\tif (v1131) goto L_06C8;\n\tv1284 = v587[v877 @ X23_v21 (System.Int32)];\n\tv1550 = System.String::op_Equality(v1284.name, v69);\n\tv2090 = v1550 == 0;\n\tv1517 = ~v2090;\n\tif (v1517) goto L_06C7;\n\tv1161 = v587.Length;\n\tv877 = v877 + 1;\n\tv2035 = v877 < v587.Length;\n\tif (v2035) goto L_02F5;\nL_031B:\n\tv588 = HutongGames.PlayMaker.FsmVariables::get_ArrayVariables(this);\n\tv1162 = v588.Length;\n\tv2072 = v588.Length < 1;\n\tif (v2072) goto L_0352;\nL_032D:\n\tv2099 = v1209 < v1162;\n\tv1132 = ~v2099;\n\tif (v1132) goto L_06C8;\n\tv1285 = v588[v1209 @ X22_v82 (System.Int32)];\n\tv1551 = System.String::op_Equality(v1285.name, v69);\n\tv2116 = v1551 == 0;\n\tv1518 = ~v2116;\n\tif (v1518) goto L_06C7;\n\tv1162 = v588.Length;\n\tv1209 = v1209 + 1;\n\tv2075 = v1209 < v588.Length;\n\tif (v2075) goto L_032D;\nL_0352:\n\tv2088 = HutongGames.PlayMaker.FsmVariables::get_GlobalVariables();\n\tv2100 = v2088 == 0;\n\tif (v2100) goto L_FFFFFFFF;\n\tv589 = HutongGames.PlayMaker.FsmVariables::get_GlobalVariables();\n\tv590 = HutongGames.PlayMaker.FsmVariables::get_FloatVariables(v589);\n\tv1163 = v590.Length;\n\tv2130 = v590.Length < 1;\n\tif (v2130) goto L_038F;\nL_036A:\n\tv2153 = v1210 < v1163;\n\tv1133 = ~v2153;\n\tif (v1133) goto L_06C8;\n\tv1286 = v590[v1210 @ X22_v79 (System.Int32)];\n\tv1552 = System.String::op_Equality(v1286.name, v69);\n\tv2156 = v1552 == 0;\n\tv1519 = ~v2156;\n\tif (v1519) goto L_06C7;\n\tv1163 = v590.Length;\n\tv1210 = v1210 + 1;\n\tv2132 = v1210 < v590.Length;\n\tif (v2132) goto L_036A;\nL_038F:\n\tv591 = HutongGames.PlayMaker.FsmVariables::get_GlobalVariables();\n\tv592 = HutongGames.PlayMaker.FsmVariables::get_IntVariables(v591);\n\tv1164 = v592.Length;\n\tv2168 = v592.Length < 1;\n\tif (v2168) goto L_03C9;\nL_03A4:\n\tv2193 = v1211 \n// ... truncated")]
		public NamedVariable GetVariable(string name)
		{
			//IL_0c8e: Expected I4, but got O
			//IL_0daf: Expected I4, but got O
			//IL_0eaa: Expected I4, but got O
			//IL_0fa5: Expected I4, but got O
			//IL_10a0: Expected I4, but got O
			//IL_119b: Expected I4, but got O
			//IL_1296: Expected I4, but got O
			//IL_1391: Expected I4, but got O
			//IL_148c: Expected I4, but got O
			//IL_1587: Expected I4, but got O
			//IL_1682: Expected I4, but got O
			//IL_177d: Expected I4, but got O
			//IL_1878: Expected I4, but got O
			//IL_1973: Expected I4, but got O
			//IL_1a6e: Expected I4, but got O
			FsmFloat[] array = FloatVariables;
			int num = array.Length;
			if (array.Length < 1)
			{
				goto IL_00e1;
			}
			int num2 = 0;
			string text = default(string);
			NamedVariable result;
			while (num2 < num)
			{
				FsmFloat fsmFloat = array[num2];
				bool flag = fsmFloat.Name == text;
				bool flag2 = !flag;
				bool flag3 = !flag2;
				result = array[num2];
				if (!flag3)
				{
					num = array.Length;
					num2++;
					if (num2 < array.Length)
					{
						continue;
					}
					goto IL_00e1;
				}
				goto IL_1c3a;
			}
			goto IL_1c2c;
			IL_1a2b:
			FsmVariables globalVariables = GlobalVariables;
			FsmEnum[] array2 = globalVariables.EnumVariables;
			int num3 = array2.Length;
			bool flag4 = array2.Length < 1;
			bool flag5 = (byte)(int)array2 != 0;
			if (flag4)
			{
				goto IL_1b26;
			}
			int num4 = 0;
			while (num4 < num3)
			{
				FsmEnum fsmEnum = array2[num4];
				flag5 = fsmEnum.Name == text;
				bool flag6 = !flag5;
				bool flag7 = !flag6;
				result = array2[num4];
				if (!flag7)
				{
					num3 = array2.Length;
					num4++;
					if (num4 < array2.Length)
					{
						continue;
					}
					goto IL_1b26;
				}
				goto IL_1c3a;
			}
			goto IL_1c2c;
			IL_134e:
			FsmVariables globalVariables2 = GlobalVariables;
			FsmRect[] array3 = globalVariables2.RectVariables;
			int num5 = array3.Length;
			bool flag8 = array3.Length < 1;
			bool flag9 = (byte)(int)array3 != 0;
			if (flag8)
			{
				goto IL_1449;
			}
			int num6 = 0;
			while (num6 < num5)
			{
				FsmRect fsmRect = array3[num6];
				flag9 = fsmRect.Name == text;
				bool flag10 = !flag9;
				bool flag11 = !flag10;
				result = array3[num6];
				if (!flag11)
				{
					num5 = array3.Length;
					num6++;
					if (num6 < array3.Length)
					{
						continue;
					}
					goto IL_1449;
				}
				goto IL_1c3a;
			}
			goto IL_1c2c;
			IL_1c3a:
			return result;
			IL_1835:
			FsmVariables globalVariables3 = GlobalVariables;
			FsmGameObject[] array4 = globalVariables3.GameObjectVariables;
			int num7 = array4.Length;
			bool flag12 = array4.Length < 1;
			bool flag13 = (byte)(int)array4 != 0;
			if (flag12)
			{
				goto IL_1930;
			}
			int num8 = 0;
			while (num8 < num7)
			{
				FsmGameObject fsmGameObject = array4[num8];
				flag13 = fsmGameObject.Name == text;
				bool flag14 = !flag13;
				bool flag15 = !flag14;
				result = array4[num8];
				if (!flag15)
				{
					num7 = array4.Length;
					num8++;
					if (num8 < array4.Length)
					{
						continue;
					}
					goto IL_1930;
				}
				goto IL_1c3a;
			}
			goto IL_1c2c;
			IL_00e1:
			FsmInt[] array5 = IntVariables;
			int num9 = array5.Length;
			if (array5.Length < 1)
			{
				goto IL_01c4;
			}
			int num10 = 0;
			while (num10 < num9)
			{
				FsmInt fsmInt = array5[num10];
				bool flag16 = fsmInt.Name == text;
				bool flag17 = !flag16;
				bool flag18 = !flag17;
				result = array5[num10];
				if (!flag18)
				{
					num9 = array5.Length;
					num10++;
					if (num10 < array5.Length)
					{
						continue;
					}
					goto IL_01c4;
				}
				goto IL_1c3a;
			}
			goto IL_1c2c;
			IL_062e:
			FsmColor[] array6 = ColorVariables;
			int num11 = array6.Length;
			if (array6.Length < 1)
			{
				goto IL_0710;
			}
			int num12 = 0;
			while (num12 < num11)
			{
				FsmColor fsmColor = array6[num12];
				bool flag19 = fsmColor.Name == text;
				bool flag20 = !flag19;
				bool flag21 = !flag20;
				result = array6[num12];
				if (!flag21)
				{
					num11 = array6.Length;
					num12++;
					if (num12 < array6.Length)
					{
						continue;
					}
					goto IL_0710;
				}
				goto IL_1c3a;
			}
			goto IL_1c2c;
			IL_09b6:
			FsmGameObject[] array7 = GameObjectVariables;
			int num13 = array7.Length;
			if (array7.Length < 1)
			{
				goto IL_0a98;
			}
			int num14 = 0;
			while (num14 < num13)
			{
				FsmGameObject fsmGameObject2 = array7[num14];
				bool flag22 = fsmGameObject2.Name == text;
				bool flag23 = !flag22;
				bool flag24 = !flag23;
				result = array7[num14];
				if (!flag24)
				{
					num13 = array7.Length;
					num14++;
					if (num14 < array7.Length)
					{
						continue;
					}
					goto IL_0a98;
				}
				goto IL_1c3a;
			}
			goto IL_1c2c;
			IL_105d:
			FsmVariables globalVariables4 = GlobalVariables;
			FsmVector2[] array8 = globalVariables4.Vector2Variables;
			int num15 = array8.Length;
			bool flag25 = array8.Length < 1;
			bool flag26 = (byte)(int)array8 != 0;
			if (flag25)
			{
				goto IL_1158;
			}
			int num16 = 0;
			while (num16 < num15)
			{
				FsmVector2 fsmVector = array8[num16];
				flag26 = fsmVector.Name == text;
				bool flag27 = !flag26;
				bool flag28 = !flag27;
				result = array8[num16];
				if (!flag28)
				{
					num15 = array8.Length;
					num16++;
					if (num16 < array8.Length)
					{
						continue;
					}
					goto IL_1158;
				}
				goto IL_1c3a;
			}
			goto IL_1c2c;
			IL_1158:
			FsmVariables globalVariables5 = GlobalVariables;
			FsmVector3[] array9 = globalVariables5.Vector3Variables;
			int num17 = array9.Length;
			bool flag29 = array9.Length < 1;
			bool flag30 = (byte)(int)array9 != 0;
			if (flag29)
			{
				goto IL_1253;
			}
			int num18 = 0;
			while (num18 < num17)
			{
				FsmVector3 fsmVector2 = array9[num18];
				flag30 = fsmVector2.Name == text;
				bool flag31 = !flag30;
				bool flag32 = !flag31;
				result = array9[num18];
				if (!flag32)
				{
					num17 = array9.Length;
					num18++;
					if (num18 < array9.Length)
					{
						continue;
					}
					goto IL_1253;
				}
				goto IL_1c3a;
			}
			goto IL_1c2c;
			IL_01c4:
			FsmBool[] array10 = BoolVariables;
			int num19 = array10.Length;
			if (array10.Length < 1)
			{
				goto IL_02a6;
			}
			int num20 = 0;
			while (num20 < num19)
			{
				FsmBool fsmBool = array10[num20];
				bool flag33 = fsmBool.Name == text;
				bool flag34 = !flag33;
				bool flag35 = !flag34;
				result = array10[num20];
				if (!flag35)
				{
					num19 = array10.Length;
					num20++;
					if (num20 < array10.Length)
					{
						continue;
					}
					goto IL_02a6;
				}
				goto IL_1c3a;
			}
			goto IL_1c2c;
			IL_173a:
			FsmVariables globalVariables6 = GlobalVariables;
			FsmObject[] array11 = globalVariables6.ObjectVariables;
			int num21 = array11.Length;
			bool flag36 = array11.Length < 1;
			bool flag37 = (byte)(int)array11 != 0;
			if (flag36)
			{
				goto IL_1835;
			}
			int num22 = 0;
			while (num22 < num21)
			{
				FsmObject fsmObject = array11[num22];
				flag37 = fsmObject.Name == text;
				bool flag38 = !flag37;
				bool flag39 = !flag38;
				result = array11[num22];
				if (!flag39)
				{
					num21 = array11.Length;
					num22++;
					if (num22 < array11.Length)
					{
						continue;
					}
					goto IL_1835;
				}
				goto IL_1c3a;
			}
			goto IL_1c2c;
			IL_0c5c:
			FsmArray[] array12 = ArrayVariables;
			int num23 = array12.Length;
			bool flag40 = array12.Length < 1;
			bool flag41 = (byte)(int)array12 != 0;
			if (flag40)
			{
				goto IL_0d46;
			}
			int num24 = 0;
			while (num24 < num23)
			{
				FsmArray fsmArray = array12[num24];
				flag41 = fsmArray.Name == text;
				bool flag42 = !flag41;
				bool flag43 = !flag42;
				result = array12[num24];
				if (!flag43)
				{
					num23 = array12.Length;
					num24++;
					if (num24 < array12.Length)
					{
						continue;
					}
					goto IL_0d46;
				}
				goto IL_1c3a;
			}
			goto IL_1c2c;
			IL_163f:
			FsmVariables globalVariables7 = GlobalVariables;
			FsmTexture[] array13 = globalVariables7.TextureVariables;
			int num25 = array13.Length;
			bool flag44 = array13.Length < 1;
			bool flag45 = (byte)(int)array13 != 0;
			if (flag44)
			{
				goto IL_173a;
			}
			int num26 = 0;
			while (num26 < num25)
			{
				FsmTexture fsmTexture = array13[num26];
				flag45 = fsmTexture.Name == text;
				bool flag46 = !flag45;
				bool flag47 = !flag46;
				result = array13[num26];
				if (!flag47)
				{
					num25 = array13.Length;
					num26++;
					if (num26 < array13.Length)
					{
						continue;
					}
					goto IL_173a;
				}
				goto IL_1c3a;
			}
			goto IL_1c2c;
			IL_0a98:
			FsmQuaternion[] array14 = QuaternionVariables;
			int num27 = array14.Length;
			if (array14.Length < 1)
			{
				goto IL_0b7a;
			}
			int num28 = 0;
			while (num28 < num27)
			{
				FsmQuaternion fsmQuaternion = array14[num28];
				bool flag48 = fsmQuaternion.Name == text;
				bool flag49 = !flag48;
				bool flag50 = !flag49;
				result = array14[num28];
				if (!flag50)
				{
					num27 = array14.Length;
					num28++;
					if (num28 < array14.Length)
					{
						continue;
					}
					goto IL_0b7a;
				}
				goto IL_1c3a;
			}
			goto IL_1c2c;
			IL_02a6:
			FsmVector2[] array15 = Vector2Variables;
			int num29 = array15.Length;
			if (array15.Length < 1)
			{
				goto IL_0388;
			}
			int num30 = 0;
			while (num30 < num29)
			{
				FsmVector2 fsmVector3 = array15[num30];
				bool flag51 = fsmVector3.Name == text;
				bool flag52 = !flag51;
				bool flag53 = !flag52;
				result = array15[num30];
				if (!flag53)
				{
					num29 = array15.Length;
					num30++;
					if (num30 < array15.Length)
					{
						continue;
					}
					goto IL_0388;
				}
				goto IL_1c3a;
			}
			goto IL_1c2c;
			IL_0e67:
			FsmVariables globalVariables8 = GlobalVariables;
			FsmInt[] array16 = globalVariables8.IntVariables;
			int num31 = array16.Length;
			bool flag54 = array16.Length < 1;
			bool flag55 = (byte)(int)array16 != 0;
			if (flag54)
			{
				goto IL_0f62;
			}
			int num32 = 0;
			while (num32 < num31)
			{
				FsmInt fsmInt2 = array16[num32];
				flag55 = fsmInt2.Name == text;
				bool flag56 = !flag55;
				bool flag57 = !flag56;
				result = array16[num32];
				if (!flag57)
				{
					num31 = array16.Length;
					num32++;
					if (num32 < array16.Length)
					{
						continue;
					}
					goto IL_0f62;
				}
				goto IL_1c3a;
			}
			goto IL_1c2c;
			IL_0710:
			FsmMaterial[] array17 = MaterialVariables;
			int num33 = array17.Length;
			if (array17.Length < 1)
			{
				goto IL_07f2;
			}
			int num34 = 0;
			while (num34 < num33)
			{
				FsmMaterial fsmMaterial = array17[num34];
				bool flag58 = fsmMaterial.Name == text;
				bool flag59 = !flag58;
				bool flag60 = !flag59;
				result = array17[num34];
				if (!flag60)
				{
					num33 = array17.Length;
					num34++;
					if (num34 < array17.Length)
					{
						continue;
					}
					goto IL_07f2;
				}
				goto IL_1c3a;
			}
			goto IL_1c2c;
			IL_1253:
			FsmVariables globalVariables9 = GlobalVariables;
			FsmString[] array18 = globalVariables9.StringVariables;
			int num35 = array18.Length;
			bool flag61 = array18.Length < 1;
			bool flag62 = (byte)(int)array18 != 0;
			if (flag61)
			{
				goto IL_134e;
			}
			int num36 = 0;
			while (num36 < num35)
			{
				FsmString fsmString = array18[num36];
				flag62 = fsmString.Name == text;
				bool flag63 = !flag62;
				bool flag64 = !flag63;
				result = array18[num36];
				if (!flag64)
				{
					num35 = array18.Length;
					num36++;
					if (num36 < array18.Length)
					{
						continue;
					}
					goto IL_134e;
				}
				goto IL_1c3a;
			}
			goto IL_1c2c;
			IL_0f62:
			FsmVariables globalVariables10 = GlobalVariables;
			FsmBool[] array19 = globalVariables10.BoolVariables;
			int num37 = array19.Length;
			bool flag65 = array19.Length < 1;
			bool flag66 = (byte)(int)array19 != 0;
			if (flag65)
			{
				goto IL_105d;
			}
			int num38 = 0;
			while (num38 < num37)
			{
				FsmBool fsmBool2 = array19[num38];
				flag66 = fsmBool2.Name == text;
				bool flag67 = !flag66;
				bool flag68 = !flag67;
				result = array19[num38];
				if (!flag68)
				{
					num37 = array19.Length;
					num38++;
					if (num38 < array19.Length)
					{
						continue;
					}
					goto IL_105d;
				}
				goto IL_1c3a;
			}
			goto IL_1c2c;
			IL_0388:
			FsmVector3[] array20 = Vector3Variables;
			int num39 = array20.Length;
			if (array20.Length < 1)
			{
				goto IL_046a;
			}
			int num40 = 0;
			while (num40 < num39)
			{
				FsmVector3 fsmVector4 = array20[num40];
				bool flag69 = fsmVector4.Name == text;
				bool flag70 = !flag69;
				bool flag71 = !flag70;
				result = array20[num40];
				if (!flag71)
				{
					num39 = array20.Length;
					num40++;
					if (num40 < array20.Length)
					{
						continue;
					}
					goto IL_046a;
				}
				goto IL_1c3a;
			}
			goto IL_1c2c;
			IL_0b7a:
			FsmEnum[] array21 = EnumVariables;
			int num41 = array21.Length;
			if (array21.Length < 1)
			{
				goto IL_0c5c;
			}
			int num42 = 0;
			while (num42 < num41)
			{
				FsmEnum fsmEnum2 = array21[num42];
				bool flag72 = fsmEnum2.Name == text;
				bool flag73 = !flag72;
				bool flag74 = !flag73;
				result = array21[num42];
				if (!flag74)
				{
					num41 = array21.Length;
					num42++;
					if (num42 < array21.Length)
					{
						continue;
					}
					goto IL_0c5c;
				}
				goto IL_1c3a;
			}
			goto IL_1c2c;
			IL_08d4:
			FsmObject[] array22 = ObjectVariables;
			int num43 = array22.Length;
			if (array22.Length < 1)
			{
				goto IL_09b6;
			}
			int num44 = 0;
			while (num44 < num43)
			{
				FsmObject fsmObject2 = array22[num44];
				bool flag75 = fsmObject2.Name == text;
				bool flag76 = !flag75;
				bool flag77 = !flag76;
				result = array22[num44];
				if (!flag77)
				{
					num43 = array22.Length;
					num44++;
					if (num44 < array22.Length)
					{
						continue;
					}
					goto IL_09b6;
				}
				goto IL_1c3a;
			}
			goto IL_1c2c;
			IL_0d46:
			FsmVariables globalVariables11 = GlobalVariables;
			if (globalVariables11 == null)
			{
				goto IL_1c22;
			}
			FsmVariables globalVariables12 = GlobalVariables;
			FsmFloat[] array23 = globalVariables12.FloatVariables;
			int num45 = array23.Length;
			bool flag78 = array23.Length < 1;
			bool flag79 = (byte)(int)array23 != 0;
			if (flag78)
			{
				goto IL_0e67;
			}
			int num46 = 0;
			while (num46 < num45)
			{
				FsmFloat fsmFloat2 = array23[num46];
				flag79 = fsmFloat2.Name == text;
				bool flag80 = !flag79;
				bool flag81 = !flag80;
				result = array23[num46];
				if (!flag81)
				{
					num45 = array23.Length;
					num46++;
					if (num46 < array23.Length)
					{
						continue;
					}
					goto IL_0e67;
				}
				goto IL_1c3a;
			}
			goto IL_1c2c;
			IL_1544:
			FsmVariables globalVariables13 = GlobalVariables;
			FsmMaterial[] array24 = globalVariables13.MaterialVariables;
			int num47 = array24.Length;
			bool flag82 = array24.Length < 1;
			bool flag83 = (byte)(int)array24 != 0;
			if (flag82)
			{
				goto IL_163f;
			}
			int num48 = 0;
			while (num48 < num47)
			{
				FsmMaterial fsmMaterial2 = array24[num48];
				flag83 = fsmMaterial2.Name == text;
				bool flag84 = !flag83;
				bool flag85 = !flag84;
				result = array24[num48];
				if (!flag85)
				{
					num47 = array24.Length;
					num48++;
					if (num48 < array24.Length)
					{
						continue;
					}
					goto IL_163f;
				}
				goto IL_1c3a;
			}
			goto IL_1c2c;
			IL_046a:
			FsmString[] array25 = StringVariables;
			int num49 = array25.Length;
			if (array25.Length < 1)
			{
				goto IL_054c;
			}
			int num50 = 0;
			while (num50 < num49)
			{
				FsmString fsmString2 = array25[num50];
				bool flag86 = fsmString2.Name == text;
				bool flag87 = !flag86;
				bool flag88 = !flag87;
				result = array25[num50];
				if (!flag88)
				{
					num49 = array25.Length;
					num50++;
					if (num50 < array25.Length)
					{
						continue;
					}
					goto IL_054c;
				}
				goto IL_1c3a;
			}
			goto IL_1c2c;
			IL_1449:
			FsmVariables globalVariables14 = GlobalVariables;
			FsmColor[] array26 = globalVariables14.ColorVariables;
			int num51 = array26.Length;
			bool flag89 = array26.Length < 1;
			bool flag90 = (byte)(int)array26 != 0;
			if (flag89)
			{
				goto IL_1544;
			}
			int num52 = 0;
			while (num52 < num51)
			{
				FsmColor fsmColor2 = array26[num52];
				flag90 = fsmColor2.Name == text;
				bool flag91 = !flag90;
				bool flag92 = !flag91;
				result = array26[num52];
				if (!flag92)
				{
					num51 = array26.Length;
					num52++;
					if (num52 < array26.Length)
					{
						continue;
					}
					goto IL_1544;
				}
				goto IL_1c3a;
			}
			goto IL_1c2c;
			IL_1930:
			FsmVariables globalVariables15 = GlobalVariables;
			FsmQuaternion[] array27 = globalVariables15.QuaternionVariables;
			int num53 = array27.Length;
			bool flag93 = array27.Length < 1;
			bool flag94 = (byte)(int)array27 != 0;
			if (flag93)
			{
				goto IL_1a2b;
			}
			int num54 = 0;
			while (num54 < num53)
			{
				FsmQuaternion fsmQuaternion2 = array27[num54];
				flag94 = fsmQuaternion2.Name == text;
				bool flag95 = !flag94;
				bool flag96 = !flag95;
				result = array27[num54];
				if (!flag96)
				{
					num53 = array27.Length;
					num54++;
					if (num54 < array27.Length)
					{
						continue;
					}
					goto IL_1a2b;
				}
				goto IL_1c3a;
			}
			goto IL_1c2c;
			IL_1c22:
			result = null;
			goto IL_1c3a;
			IL_1b26:
			FsmVariables globalVariables16 = GlobalVariables;
			FsmArray[] array28 = globalVariables16.ArrayVariables;
			int num55 = array28.Length;
			if (array28.Length < 1)
			{
				goto IL_1c22;
			}
			int num56 = 0;
			while (num56 < num55)
			{
				FsmArray fsmArray2 = array28[num56];
				bool flag97 = fsmArray2.Name == text;
				bool flag98 = !flag97;
				bool flag99 = !flag98;
				result = array28[num56];
				if (!flag99)
				{
					num55 = array28.Length;
					num56++;
					if (num56 < array28.Length)
					{
						continue;
					}
					result = null;
				}
				goto IL_1c3a;
			}
			goto IL_1c2c;
			IL_054c:
			FsmRect[] array29 = RectVariables;
			int num57 = array29.Length;
			if (array29.Length < 1)
			{
				goto IL_062e;
			}
			int num58 = 0;
			while (num58 < num57)
			{
				FsmRect fsmRect2 = array29[num58];
				bool flag100 = fsmRect2.Name == text;
				bool flag101 = !flag100;
				bool flag102 = !flag101;
				result = array29[num58];
				if (!flag102)
				{
					num57 = array29.Length;
					num58++;
					if (num58 < array29.Length)
					{
						continue;
					}
					goto IL_062e;
				}
				goto IL_1c3a;
			}
			goto IL_1c2c;
			IL_07f2:
			FsmTexture[] array30 = TextureVariables;
			int num59 = array30.Length;
			if (array30.Length < 1)
			{
				goto IL_08d4;
			}
			int num60 = 0;
			while (num60 < num59)
			{
				FsmTexture fsmTexture2 = array30[num60];
				bool flag103 = fsmTexture2.Name == text;
				bool flag104 = !flag103;
				bool flag105 = !flag104;
				result = array30[num60];
				if (!flag105)
				{
					num59 = array30.Length;
					num60++;
					if (num60 < array30.Length)
					{
						continue;
					}
					goto IL_08d4;
				}
				goto IL_1c3a;
			}
			goto IL_1c2c;
			IL_1c2c:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x600062D")]
		[Address(RVA = "0xE4EB24", Offset = "0xE4EB24", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = *([1EBAEC8]);\n\tv27 = *([v26 @ X8_v21]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, name, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2024791]) = v45;\nL_0018:\n\tv47 = HutongGames.PlayMaker.FsmVariables::get_FloatVariables(this);\n\tv197 = v47.Length;\n\tv61 = v47.Length < 1;\n\tif (v61) goto L_004F;\nL_002A:\n\tv211 = v160 < v197;\n\tv187 = ~v211;\n\tif (v187) goto L_00A6;\n\tv148 = v47[v160 @ X23_v12 (System.Int32)];\n\tv144 = System.String::op_Equality(v148.name, v67);\n\tv322 = v144 == 0;\n\tv146 = ~v322;\n\tif (v146) goto L_00A3;\n\tv197 = v47.Length;\n\tv160 = v160 + 1;\n\tv134 = v160 < v47.Length;\n\tif (v134) goto L_002A;\nL_004F:\n\tv149 = HutongGames.PlayMaker.FsmVariables::get_GlobalVariables();\n\tv212 = v149 == 0;\n\tif (v212) goto L_008F;\n\tv116 = HutongGames.PlayMaker.FsmVariables::get_GlobalVariables();\n\tv117 = HutongGames.PlayMaker.FsmVariables::get_FloatVariables(v116);\n\tv198 = v117.Length;\n\tv228 = v117.Length < 1;\n\tif (v228) goto L_008F;\nL_0067:\n\tv341 = v161 < v198;\n\tv188 = ~v341;\n\tif (v188) goto L_00A6;\n\tv262 = v117[v161 @ X23_v9 (System.Int32)];\n\tv255 = System.String::op_Equality(v262.name, v67);\n\tv344 = v255 == 0;\n\tv257 = ~v344;\n\tif (v257) goto L_00A3;\n\tv198 = v117.Length;\n\tv161 = v161 + 1;\n\tv227 = v161 < v117.Length;\n\tif (v227) goto L_0067;\nL_008F:\n\tv266 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v266, v67);\n\tv271 = HutongGames.PlayMaker.FsmVariables::GetVariable(this, v67);\n\tv266.obj = v271;\nL_00A3:\n\treturn v329;\n\tv128 = new System.NullReferenceException();\nL_00A6:\n\tv202 = new System.IndexOutOfRangeException();\n\tthrow v202;\n\treturn returnVal1;\n// 120 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmFloat GetFsmFloat(string name)
		{
			//IL_0028: Expected I4, but got O
			FsmFloat[] array = FloatVariables;
			int num = array.Length;
			bool flag = array.Length < 1;
			bool flag2 = (byte)(int)array != 0;
			if (flag)
			{
				goto IL_00df;
			}
			int num2 = 0;
			string text = default(string);
			FsmFloat result;
			while (num2 < num)
			{
				FsmFloat fsmFloat = array[num2];
				flag2 = fsmFloat.Name == text;
				bool flag3 = !flag2;
				bool flag4 = !flag3;
				result = array[num2];
				if (!flag4)
				{
					num = array.Length;
					num2++;
					if (num2 < array.Length)
					{
						continue;
					}
					goto IL_00df;
				}
				goto IL_0254;
			}
			goto IL_0237;
			IL_00df:
			FsmVariables globalVariables = GlobalVariables;
			if (globalVariables != null)
			{
				FsmVariables globalVariables2 = GlobalVariables;
				FsmFloat[] array2 = globalVariables2.FloatVariables;
				int num3 = array2.Length;
				if (array2.Length >= 1)
				{
					int num4 = 0;
					while (num4 < num3)
					{
						FsmFloat fsmFloat2 = array2[num4];
						bool flag5 = fsmFloat2.Name == text;
						bool flag6 = !flag5;
						bool flag7 = !flag6;
						result = array2[num4];
						if (!flag7)
						{
							num3 = array2.Length;
							num4++;
							if (num4 < array2.Length)
							{
								continue;
							}
							goto IL_01f7;
						}
						goto IL_0254;
					}
					goto IL_0237;
				}
			}
			goto IL_01f7;
			IL_0237:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_01f7:
			FsmFloat fsmFloat3 = new FsmFloat(text);
			NamedVariable variable = GetVariable(text);
			fsmFloat3.obj = variable;
			result = fsmFloat3;
			goto IL_0254;
			IL_0254:
			return result;
		}

		[Token(Token = "0x600062E")]
		[Address(RVA = "0xE4EC88", Offset = "0xE4EC88", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = *([1EAE4A8]);\n\tv27 = *([v26 @ X8_v21]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, name, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2024792]) = v45;\nL_0018:\n\tv47 = HutongGames.PlayMaker.FsmVariables::get_ObjectVariables(this);\n\tv197 = v47.Length;\n\tv61 = v47.Length < 1;\n\tif (v61) goto L_004F;\nL_002A:\n\tv211 = v160 < v197;\n\tv187 = ~v211;\n\tif (v187) goto L_00A6;\n\tv148 = v47[v160 @ X23_v12 (System.Int32)];\n\tv144 = System.String::op_Equality(v148.name, v67);\n\tv322 = v144 == 0;\n\tv146 = ~v322;\n\tif (v146) goto L_00A3;\n\tv197 = v47.Length;\n\tv160 = v160 + 1;\n\tv134 = v160 < v47.Length;\n\tif (v134) goto L_002A;\nL_004F:\n\tv149 = HutongGames.PlayMaker.FsmVariables::get_GlobalVariables();\n\tv212 = v149 == 0;\n\tif (v212) goto L_008F;\n\tv116 = HutongGames.PlayMaker.FsmVariables::get_GlobalVariables();\n\tv117 = HutongGames.PlayMaker.FsmVariables::get_ObjectVariables(v116);\n\tv198 = v117.Length;\n\tv228 = v117.Length < 1;\n\tif (v228) goto L_008F;\nL_0067:\n\tv341 = v161 < v198;\n\tv188 = ~v341;\n\tif (v188) goto L_00A6;\n\tv262 = v117[v161 @ X23_v9 (System.Int32)];\n\tv255 = System.String::op_Equality(v262.name, v67);\n\tv344 = v255 == 0;\n\tv257 = ~v344;\n\tif (v257) goto L_00A3;\n\tv198 = v117.Length;\n\tv161 = v161 + 1;\n\tv227 = v161 < v117.Length;\n\tif (v227) goto L_0067;\nL_008F:\n\tv266 = new HutongGames.PlayMaker.FsmObject();\n\tHutongGames.PlayMaker.FsmObject::.ctor(v266, v67);\n\tv271 = HutongGames.PlayMaker.FsmVariables::GetVariable(this, v67);\n\tv266.obj = v271;\nL_00A3:\n\treturn v329;\n\tv128 = new System.NullReferenceException();\nL_00A6:\n\tv202 = new System.IndexOutOfRangeException();\n\tthrow v202;\n\treturn returnVal1;\n// 120 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmObject GetFsmObject(string name)
		{
			//IL_0028: Expected I4, but got O
			FsmObject[] array = ObjectVariables;
			int num = array.Length;
			bool flag = array.Length < 1;
			bool flag2 = (byte)(int)array != 0;
			if (flag)
			{
				goto IL_00df;
			}
			int num2 = 0;
			string text = default(string);
			FsmObject result;
			while (num2 < num)
			{
				FsmObject fsmObject = array[num2];
				flag2 = fsmObject.Name == text;
				bool flag3 = !flag2;
				bool flag4 = !flag3;
				result = array[num2];
				if (!flag4)
				{
					num = array.Length;
					num2++;
					if (num2 < array.Length)
					{
						continue;
					}
					goto IL_00df;
				}
				goto IL_0254;
			}
			goto IL_0237;
			IL_00df:
			FsmVariables globalVariables = GlobalVariables;
			if (globalVariables != null)
			{
				FsmVariables globalVariables2 = GlobalVariables;
				FsmObject[] array2 = globalVariables2.ObjectVariables;
				int num3 = array2.Length;
				if (array2.Length >= 1)
				{
					int num4 = 0;
					while (num4 < num3)
					{
						FsmObject fsmObject2 = array2[num4];
						bool flag5 = fsmObject2.Name == text;
						bool flag6 = !flag5;
						bool flag7 = !flag6;
						result = array2[num4];
						if (!flag7)
						{
							num3 = array2.Length;
							num4++;
							if (num4 < array2.Length)
							{
								continue;
							}
							goto IL_01f7;
						}
						goto IL_0254;
					}
					goto IL_0237;
				}
			}
			goto IL_01f7;
			IL_0237:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_01f7:
			FsmObject fsmObject3 = new FsmObject(text);
			NamedVariable variable = GetVariable(text);
			fsmObject3.obj = variable;
			result = fsmObject3;
			goto IL_0254;
			IL_0254:
			return result;
		}

		[Token(Token = "0x600062F")]
		[Address(RVA = "0xE4EDE8", Offset = "0xE4EDE8", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = *([1EF8600]);\n\tv27 = *([v26 @ X8_v21]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, name, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2024793]) = v45;\nL_0018:\n\tv47 = HutongGames.PlayMaker.FsmVariables::get_MaterialVariables(this);\n\tv197 = v47.Length;\n\tv61 = v47.Length < 1;\n\tif (v61) goto L_004F;\nL_002A:\n\tv211 = v160 < v197;\n\tv187 = ~v211;\n\tif (v187) goto L_00A6;\n\tv148 = v47[v160 @ X23_v12 (System.Int32)];\n\tv144 = System.String::op_Equality(v148.name, v67);\n\tv322 = v144 == 0;\n\tv146 = ~v322;\n\tif (v146) goto L_00A3;\n\tv197 = v47.Length;\n\tv160 = v160 + 1;\n\tv134 = v160 < v47.Length;\n\tif (v134) goto L_002A;\nL_004F:\n\tv149 = HutongGames.PlayMaker.FsmVariables::get_GlobalVariables();\n\tv212 = v149 == 0;\n\tif (v212) goto L_008F;\n\tv116 = HutongGames.PlayMaker.FsmVariables::get_GlobalVariables();\n\tv117 = HutongGames.PlayMaker.FsmVariables::get_MaterialVariables(v116);\n\tv198 = v117.Length;\n\tv228 = v117.Length < 1;\n\tif (v228) goto L_008F;\nL_0067:\n\tv341 = v161 < v198;\n\tv188 = ~v341;\n\tif (v188) goto L_00A6;\n\tv262 = v117[v161 @ X23_v9 (System.Int32)];\n\tv255 = System.String::op_Equality(v262.name, v67);\n\tv344 = v255 == 0;\n\tv257 = ~v344;\n\tif (v257) goto L_00A3;\n\tv198 = v117.Length;\n\tv161 = v161 + 1;\n\tv227 = v161 < v117.Length;\n\tif (v227) goto L_0067;\nL_008F:\n\tv266 = new HutongGames.PlayMaker.FsmMaterial();\n\tHutongGames.PlayMaker.FsmMaterial::.ctor(v266, v67);\n\tv271 = HutongGames.PlayMaker.FsmVariables::GetVariable(this, v67);\n\tv266.obj = v271;\nL_00A3:\n\treturn v329;\n\tv128 = new System.NullReferenceException();\nL_00A6:\n\tv202 = new System.IndexOutOfRangeException();\n\tthrow v202;\n\treturn returnVal1;\n// 120 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmMaterial GetFsmMaterial(string name)
		{
			//IL_0028: Expected I4, but got O
			FsmMaterial[] array = MaterialVariables;
			int num = array.Length;
			bool flag = array.Length < 1;
			bool flag2 = (byte)(int)array != 0;
			if (flag)
			{
				goto IL_00df;
			}
			int num2 = 0;
			string text = default(string);
			FsmMaterial result;
			while (num2 < num)
			{
				FsmMaterial fsmMaterial = array[num2];
				flag2 = fsmMaterial.Name == text;
				bool flag3 = !flag2;
				bool flag4 = !flag3;
				result = array[num2];
				if (!flag4)
				{
					num = array.Length;
					num2++;
					if (num2 < array.Length)
					{
						continue;
					}
					goto IL_00df;
				}
				goto IL_0254;
			}
			goto IL_0237;
			IL_00df:
			FsmVariables globalVariables = GlobalVariables;
			if (globalVariables != null)
			{
				FsmVariables globalVariables2 = GlobalVariables;
				FsmMaterial[] array2 = globalVariables2.MaterialVariables;
				int num3 = array2.Length;
				if (array2.Length >= 1)
				{
					int num4 = 0;
					while (num4 < num3)
					{
						FsmMaterial fsmMaterial2 = array2[num4];
						bool flag5 = fsmMaterial2.Name == text;
						bool flag6 = !flag5;
						bool flag7 = !flag6;
						result = array2[num4];
						if (!flag7)
						{
							num3 = array2.Length;
							num4++;
							if (num4 < array2.Length)
							{
								continue;
							}
							goto IL_01f7;
						}
						goto IL_0254;
					}
					goto IL_0237;
				}
			}
			goto IL_01f7;
			IL_0237:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_01f7:
			FsmMaterial fsmMaterial3 = new FsmMaterial(text);
			NamedVariable variable = GetVariable(text);
			fsmMaterial3.obj = variable;
			result = fsmMaterial3;
			goto IL_0254;
			IL_0254:
			return result;
		}

		[Token(Token = "0x6000630")]
		[Address(RVA = "0xE4EF48", Offset = "0xE4EF48", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = *([1EDC0A0]);\n\tv27 = *([v26 @ X8_v21]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, name, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2024794]) = v45;\nL_0018:\n\tv47 = HutongGames.PlayMaker.FsmVariables::get_TextureVariables(this);\n\tv197 = v47.Length;\n\tv61 = v47.Length < 1;\n\tif (v61) goto L_004F;\nL_002A:\n\tv211 = v160 < v197;\n\tv187 = ~v211;\n\tif (v187) goto L_00A6;\n\tv148 = v47[v160 @ X23_v12 (System.Int32)];\n\tv144 = System.String::op_Equality(v148.name, v67);\n\tv322 = v144 == 0;\n\tv146 = ~v322;\n\tif (v146) goto L_00A3;\n\tv197 = v47.Length;\n\tv160 = v160 + 1;\n\tv134 = v160 < v47.Length;\n\tif (v134) goto L_002A;\nL_004F:\n\tv149 = HutongGames.PlayMaker.FsmVariables::get_GlobalVariables();\n\tv212 = v149 == 0;\n\tif (v212) goto L_008F;\n\tv116 = HutongGames.PlayMaker.FsmVariables::get_GlobalVariables();\n\tv117 = HutongGames.PlayMaker.FsmVariables::get_TextureVariables(v116);\n\tv198 = v117.Length;\n\tv228 = v117.Length < 1;\n\tif (v228) goto L_008F;\nL_0067:\n\tv341 = v161 < v198;\n\tv188 = ~v341;\n\tif (v188) goto L_00A6;\n\tv262 = v117[v161 @ X23_v9 (System.Int32)];\n\tv255 = System.String::op_Equality(v262.name, v67);\n\tv344 = v255 == 0;\n\tv257 = ~v344;\n\tif (v257) goto L_00A3;\n\tv198 = v117.Length;\n\tv161 = v161 + 1;\n\tv227 = v161 < v117.Length;\n\tif (v227) goto L_0067;\nL_008F:\n\tv266 = new HutongGames.PlayMaker.FsmTexture();\n\tHutongGames.PlayMaker.FsmTexture::.ctor(v266, v67);\n\tv271 = HutongGames.PlayMaker.FsmVariables::GetVariable(this, v67);\n\tv266.obj = v271;\nL_00A3:\n\treturn v329;\n\tv128 = new System.NullReferenceException();\nL_00A6:\n\tv202 = new System.IndexOutOfRangeException();\n\tthrow v202;\n\treturn returnVal1;\n// 120 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmTexture GetFsmTexture(string name)
		{
			//IL_0028: Expected I4, but got O
			FsmTexture[] array = TextureVariables;
			int num = array.Length;
			bool flag = array.Length < 1;
			bool flag2 = (byte)(int)array != 0;
			if (flag)
			{
				goto IL_00df;
			}
			int num2 = 0;
			string text = default(string);
			FsmTexture result;
			while (num2 < num)
			{
				FsmTexture fsmTexture = array[num2];
				flag2 = fsmTexture.Name == text;
				bool flag3 = !flag2;
				bool flag4 = !flag3;
				result = array[num2];
				if (!flag4)
				{
					num = array.Length;
					num2++;
					if (num2 < array.Length)
					{
						continue;
					}
					goto IL_00df;
				}
				goto IL_0254;
			}
			goto IL_0237;
			IL_00df:
			FsmVariables globalVariables = GlobalVariables;
			if (globalVariables != null)
			{
				FsmVariables globalVariables2 = GlobalVariables;
				FsmTexture[] array2 = globalVariables2.TextureVariables;
				int num3 = array2.Length;
				if (array2.Length >= 1)
				{
					int num4 = 0;
					while (num4 < num3)
					{
						FsmTexture fsmTexture2 = array2[num4];
						bool flag5 = fsmTexture2.Name == text;
						bool flag6 = !flag5;
						bool flag7 = !flag6;
						result = array2[num4];
						if (!flag7)
						{
							num3 = array2.Length;
							num4++;
							if (num4 < array2.Length)
							{
								continue;
							}
							goto IL_01f7;
						}
						goto IL_0254;
					}
					goto IL_0237;
				}
			}
			goto IL_01f7;
			IL_0237:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_01f7:
			FsmTexture fsmTexture3 = new FsmTexture(text);
			NamedVariable variable = GetVariable(text);
			fsmTexture3.obj = variable;
			result = fsmTexture3;
			goto IL_0254;
			IL_0254:
			return result;
		}

		[Token(Token = "0x6000631")]
		[Address(RVA = "0xE4F0A8", Offset = "0xE4F0A8", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = *([1ECD9A0]);\n\tv27 = *([v26 @ X8_v21]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, name, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2024795]) = v45;\nL_0018:\n\tv47 = HutongGames.PlayMaker.FsmVariables::get_IntVariables(this);\n\tv197 = v47.Length;\n\tv61 = v47.Length < 1;\n\tif (v61) goto L_004F;\nL_002A:\n\tv211 = v160 < v197;\n\tv187 = ~v211;\n\tif (v187) goto L_00A6;\n\tv148 = v47[v160 @ X23_v12 (System.Int32)];\n\tv144 = System.String::op_Equality(v148.name, v67);\n\tv322 = v144 == 0;\n\tv146 = ~v322;\n\tif (v146) goto L_00A3;\n\tv197 = v47.Length;\n\tv160 = v160 + 1;\n\tv134 = v160 < v47.Length;\n\tif (v134) goto L_002A;\nL_004F:\n\tv149 = HutongGames.PlayMaker.FsmVariables::get_GlobalVariables();\n\tv212 = v149 == 0;\n\tif (v212) goto L_008F;\n\tv116 = HutongGames.PlayMaker.FsmVariables::get_GlobalVariables();\n\tv117 = HutongGames.PlayMaker.FsmVariables::get_IntVariables(v116);\n\tv198 = v117.Length;\n\tv228 = v117.Length < 1;\n\tif (v228) goto L_008F;\nL_0067:\n\tv341 = v161 < v198;\n\tv188 = ~v341;\n\tif (v188) goto L_00A6;\n\tv262 = v117[v161 @ X23_v9 (System.Int32)];\n\tv255 = System.String::op_Equality(v262.name, v67);\n\tv344 = v255 == 0;\n\tv257 = ~v344;\n\tif (v257) goto L_00A3;\n\tv198 = v117.Length;\n\tv161 = v161 + 1;\n\tv227 = v161 < v117.Length;\n\tif (v227) goto L_0067;\nL_008F:\n\tv266 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v266, v67);\n\tv271 = HutongGames.PlayMaker.FsmVariables::GetVariable(this, v67);\n\tv266.obj = v271;\nL_00A3:\n\treturn v329;\n\tv128 = new System.NullReferenceException();\nL_00A6:\n\tv202 = new System.IndexOutOfRangeException();\n\tthrow v202;\n\treturn returnVal1;\n// 120 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmInt GetFsmInt(string name)
		{
			//IL_0028: Expected I4, but got O
			FsmInt[] array = IntVariables;
			int num = array.Length;
			bool flag = array.Length < 1;
			bool flag2 = (byte)(int)array != 0;
			if (flag)
			{
				goto IL_00df;
			}
			int num2 = 0;
			string text = default(string);
			FsmInt result;
			while (num2 < num)
			{
				FsmInt fsmInt = array[num2];
				flag2 = fsmInt.Name == text;
				bool flag3 = !flag2;
				bool flag4 = !flag3;
				result = array[num2];
				if (!flag4)
				{
					num = array.Length;
					num2++;
					if (num2 < array.Length)
					{
						continue;
					}
					goto IL_00df;
				}
				goto IL_0254;
			}
			goto IL_0237;
			IL_00df:
			FsmVariables globalVariables = GlobalVariables;
			if (globalVariables != null)
			{
				FsmVariables globalVariables2 = GlobalVariables;
				FsmInt[] array2 = globalVariables2.IntVariables;
				int num3 = array2.Length;
				if (array2.Length >= 1)
				{
					int num4 = 0;
					while (num4 < num3)
					{
						FsmInt fsmInt2 = array2[num4];
						bool flag5 = fsmInt2.Name == text;
						bool flag6 = !flag5;
						bool flag7 = !flag6;
						result = array2[num4];
						if (!flag7)
						{
							num3 = array2.Length;
							num4++;
							if (num4 < array2.Length)
							{
								continue;
							}
							goto IL_01f7;
						}
						goto IL_0254;
					}
					goto IL_0237;
				}
			}
			goto IL_01f7;
			IL_0237:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_01f7:
			FsmInt fsmInt3 = new FsmInt(text);
			NamedVariable variable = GetVariable(text);
			fsmInt3.obj = variable;
			result = fsmInt3;
			goto IL_0254;
			IL_0254:
			return result;
		}

		[Token(Token = "0x6000632")]
		[Address(RVA = "0xE4F208", Offset = "0xE4F208", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = *([1EBBC08]);\n\tv27 = *([v26 @ X8_v21]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, name, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2024796]) = v45;\nL_0018:\n\tv47 = HutongGames.PlayMaker.FsmVariables::get_BoolVariables(this);\n\tv197 = v47.Length;\n\tv61 = v47.Length < 1;\n\tif (v61) goto L_004F;\nL_002A:\n\tv211 = v160 < v197;\n\tv187 = ~v211;\n\tif (v187) goto L_00A6;\n\tv148 = v47[v160 @ X23_v12 (System.Int32)];\n\tv144 = System.String::op_Equality(v148.name, v67);\n\tv322 = v144 == 0;\n\tv146 = ~v322;\n\tif (v146) goto L_00A3;\n\tv197 = v47.Length;\n\tv160 = v160 + 1;\n\tv134 = v160 < v47.Length;\n\tif (v134) goto L_002A;\nL_004F:\n\tv149 = HutongGames.PlayMaker.FsmVariables::get_GlobalVariables();\n\tv212 = v149 == 0;\n\tif (v212) goto L_008F;\n\tv116 = HutongGames.PlayMaker.FsmVariables::get_GlobalVariables();\n\tv117 = HutongGames.PlayMaker.FsmVariables::get_BoolVariables(v116);\n\tv198 = v117.Length;\n\tv228 = v117.Length < 1;\n\tif (v228) goto L_008F;\nL_0067:\n\tv341 = v161 < v198;\n\tv188 = ~v341;\n\tif (v188) goto L_00A6;\n\tv262 = v117[v161 @ X23_v9 (System.Int32)];\n\tv255 = System.String::op_Equality(v262.name, v67);\n\tv344 = v255 == 0;\n\tv257 = ~v344;\n\tif (v257) goto L_00A3;\n\tv198 = v117.Length;\n\tv161 = v161 + 1;\n\tv227 = v161 < v117.Length;\n\tif (v227) goto L_0067;\nL_008F:\n\tv266 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v266, v67);\n\tv271 = HutongGames.PlayMaker.FsmVariables::GetVariable(this, v67);\n\tv266.obj = v271;\nL_00A3:\n\treturn v329;\n\tv128 = new System.NullReferenceException();\nL_00A6:\n\tv202 = new System.IndexOutOfRangeException();\n\tthrow v202;\n\treturn returnVal1;\n// 120 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmBool GetFsmBool(string name)
		{
			//IL_0028: Expected I4, but got O
			FsmBool[] array = BoolVariables;
			int num = array.Length;
			bool flag = array.Length < 1;
			bool flag2 = (byte)(int)array != 0;
			if (flag)
			{
				goto IL_00df;
			}
			int num2 = 0;
			string text = default(string);
			FsmBool result;
			while (num2 < num)
			{
				FsmBool fsmBool = array[num2];
				flag2 = fsmBool.Name == text;
				bool flag3 = !flag2;
				bool flag4 = !flag3;
				result = array[num2];
				if (!flag4)
				{
					num = array.Length;
					num2++;
					if (num2 < array.Length)
					{
						continue;
					}
					goto IL_00df;
				}
				goto IL_0254;
			}
			goto IL_0237;
			IL_00df:
			FsmVariables globalVariables = GlobalVariables;
			if (globalVariables != null)
			{
				FsmVariables globalVariables2 = GlobalVariables;
				FsmBool[] array2 = globalVariables2.BoolVariables;
				int num3 = array2.Length;
				if (array2.Length >= 1)
				{
					int num4 = 0;
					while (num4 < num3)
					{
						FsmBool fsmBool2 = array2[num4];
						bool flag5 = fsmBool2.Name == text;
						bool flag6 = !flag5;
						bool flag7 = !flag6;
						result = array2[num4];
						if (!flag7)
						{
							num3 = array2.Length;
							num4++;
							if (num4 < array2.Length)
							{
								continue;
							}
							goto IL_01f7;
						}
						goto IL_0254;
					}
					goto IL_0237;
				}
			}
			goto IL_01f7;
			IL_0237:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_01f7:
			FsmBool fsmBool3 = new FsmBool(text);
			NamedVariable variable = GetVariable(text);
			fsmBool3.obj = variable;
			result = fsmBool3;
			goto IL_0254;
			IL_0254:
			return result;
		}

		[Token(Token = "0x6000633")]
		[Address(RVA = "0xE4F368", Offset = "0xE4F368", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = *([1ED7488]);\n\tv27 = *([v26 @ X8_v21]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, name, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2024797]) = v45;\nL_0018:\n\tv47 = HutongGames.PlayMaker.FsmVariables::get_StringVariables(this);\n\tv197 = v47.Length;\n\tv61 = v47.Length < 1;\n\tif (v61) goto L_004F;\nL_002A:\n\tv211 = v160 < v197;\n\tv187 = ~v211;\n\tif (v187) goto L_00A6;\n\tv148 = v47[v160 @ X23_v12 (System.Int32)];\n\tv144 = System.String::op_Equality(v148.name, v67);\n\tv322 = v144 == 0;\n\tv146 = ~v322;\n\tif (v146) goto L_00A3;\n\tv197 = v47.Length;\n\tv160 = v160 + 1;\n\tv134 = v160 < v47.Length;\n\tif (v134) goto L_002A;\nL_004F:\n\tv149 = HutongGames.PlayMaker.FsmVariables::get_GlobalVariables();\n\tv212 = v149 == 0;\n\tif (v212) goto L_008F;\n\tv116 = HutongGames.PlayMaker.FsmVariables::get_GlobalVariables();\n\tv117 = HutongGames.PlayMaker.FsmVariables::get_StringVariables(v116);\n\tv198 = v117.Length;\n\tv228 = v117.Length < 1;\n\tif (v228) goto L_008F;\nL_0067:\n\tv341 = v161 < v198;\n\tv188 = ~v341;\n\tif (v188) goto L_00A6;\n\tv262 = v117[v161 @ X23_v9 (System.Int32)];\n\tv255 = System.String::op_Equality(v262.name, v67);\n\tv344 = v255 == 0;\n\tv257 = ~v344;\n\tif (v257) goto L_00A3;\n\tv198 = v117.Length;\n\tv161 = v161 + 1;\n\tv227 = v161 < v117.Length;\n\tif (v227) goto L_0067;\nL_008F:\n\tv266 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v266, v67);\n\tv271 = HutongGames.PlayMaker.FsmVariables::GetVariable(this, v67);\n\tv266.obj = v271;\nL_00A3:\n\treturn v329;\n\tv128 = new System.NullReferenceException();\nL_00A6:\n\tv202 = new System.IndexOutOfRangeException();\n\tthrow v202;\n\treturn returnVal1;\n// 120 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmString GetFsmString(string name)
		{
			//IL_0028: Expected I4, but got O
			FsmString[] array = StringVariables;
			int num = array.Length;
			bool flag = array.Length < 1;
			bool flag2 = (byte)(int)array != 0;
			if (flag)
			{
				goto IL_00df;
			}
			int num2 = 0;
			string text = default(string);
			FsmString result;
			while (num2 < num)
			{
				FsmString fsmString = array[num2];
				flag2 = fsmString.Name == text;
				bool flag3 = !flag2;
				bool flag4 = !flag3;
				result = array[num2];
				if (!flag4)
				{
					num = array.Length;
					num2++;
					if (num2 < array.Length)
					{
						continue;
					}
					goto IL_00df;
				}
				goto IL_0254;
			}
			goto IL_0237;
			IL_00df:
			FsmVariables globalVariables = GlobalVariables;
			if (globalVariables != null)
			{
				FsmVariables globalVariables2 = GlobalVariables;
				FsmString[] array2 = globalVariables2.StringVariables;
				int num3 = array2.Length;
				if (array2.Length >= 1)
				{
					int num4 = 0;
					while (num4 < num3)
					{
						FsmString fsmString2 = array2[num4];
						bool flag5 = fsmString2.Name == text;
						bool flag6 = !flag5;
						bool flag7 = !flag6;
						result = array2[num4];
						if (!flag7)
						{
							num3 = array2.Length;
							num4++;
							if (num4 < array2.Length)
							{
								continue;
							}
							goto IL_01f7;
						}
						goto IL_0254;
					}
					goto IL_0237;
				}
			}
			goto IL_01f7;
			IL_0237:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_01f7:
			FsmString fsmString3 = new FsmString(text);
			NamedVariable variable = GetVariable(text);
			fsmString3.obj = variable;
			result = fsmString3;
			goto IL_0254;
			IL_0254:
			return result;
		}

		[Token(Token = "0x6000634")]
		[Address(RVA = "0xE4F4C8", Offset = "0xE4F4C8", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EE35C0]);\n\tv25 = *([v24 @ X8_v21]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, name, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2024798]) = v43;\nL_0017:\n\tv45 = HutongGames.PlayMaker.FsmVariables::get_Vector2Variables(this);\n\tv195 = v45.Length;\n\tv59 = v45.Length < 1;\n\tif (v59) goto L_004E;\nL_0029:\n\tv209 = v158 < v195;\n\tv185 = ~v209;\n\tif (v185) goto L_009D;\n\tv146 = v45[v158 @ X22_v12 (System.Int32)];\n\tv142 = System.String::op_Equality(v146.name, v65);\n\tv314 = v142 == 0;\n\tv144 = ~v314;\n\tif (v144) goto L_009A;\n\tv195 = v45.Length;\n\tv158 = v158 + 1;\n\tv132 = v158 < v45.Length;\n\tif (v132) goto L_0029;\nL_004E:\n\tv147 = HutongGames.PlayMaker.FsmVariables::get_GlobalVariables();\n\tv210 = v147 == 0;\n\tif (v210) goto L_008E;\n\tv111 = HutongGames.PlayMaker.FsmVariables::get_GlobalVariables();\n\tv112 = HutongGames.PlayMaker.FsmVariables::get_Vector2Variables(v111);\n\tv196 = v112.Length;\n\tv226 = v112.Length < 1;\n\tif (v226) goto L_008E;\nL_0066:\n\tv332 = v159 < v196;\n\tv186 = ~v332;\n\tif (v186) goto L_009D;\n\tv260 = v112[v159 @ X22_v9 (System.Int32)];\n\tv252 = System.String::op_Equality(v260.name, v65);\n\tv335 = v252 == 0;\n\tv254 = ~v335;\n\tif (v254) goto L_009A;\n\tv196 = v112.Length;\n\tv159 = v159 + 1;\n\tv225 = v159 < v112.Length;\n\tif (v225) goto L_0066;\nL_008E:\n\tv264 = new HutongGames.PlayMaker.FsmVector2();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v264, v65);\nL_009A:\n\treturn v318;\n\tv126 = new System.NullReferenceException();\nL_009D:\n\tv200 = new System.IndexOutOfRangeException();\n\tthrow v200;\n\treturn returnVal1;\n// 113 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmVector2 GetFsmVector2(string name)
		{
			//IL_0028: Expected I4, but got O
			FsmVector2[] array = Vector2Variables;
			int num = array.Length;
			bool flag = array.Length < 1;
			bool flag2 = (byte)(int)array != 0;
			if (flag)
			{
				goto IL_00e0;
			}
			int num2 = 0;
			string text = default(string);
			FsmVector2 result;
			while (num2 < num)
			{
				FsmVector2 fsmVector = array[num2];
				flag2 = fsmVector.Name == text;
				bool flag3 = !flag2;
				bool flag4 = !flag3;
				result = array[num2];
				if (!flag4)
				{
					num = array.Length;
					num2++;
					if (num2 < array.Length)
					{
						continue;
					}
					goto IL_00e0;
				}
				goto IL_0214;
			}
			goto IL_0219;
			IL_00e0:
			FsmVariables globalVariables = GlobalVariables;
			if (globalVariables != null)
			{
				FsmVariables globalVariables2 = GlobalVariables;
				FsmVector2[] array2 = globalVariables2.Vector2Variables;
				int num3 = array2.Length;
				if (array2.Length >= 1)
				{
					int num4 = 0;
					while (num4 < num3)
					{
						FsmVector2 fsmVector2 = array2[num4];
						bool flag5 = fsmVector2.Name == text;
						bool flag6 = !flag5;
						bool flag7 = !flag6;
						result = array2[num4];
						if (!flag7)
						{
							num3 = array2.Length;
							num4++;
							if (num4 < array2.Length)
							{
								continue;
							}
							goto IL_01f9;
						}
						goto IL_0214;
					}
					goto IL_0219;
				}
			}
			goto IL_01f9;
			IL_0219:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_01f9:
			FsmVector2 fsmVector3 = (FsmVector2)new NamedVariable(text);
			result = fsmVector3;
			goto IL_0214;
			IL_0214:
			return result;
		}

		[Token(Token = "0x6000635")]
		[Address(RVA = "0xE4F60C", Offset = "0xE4F60C", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = *([1EEF938]);\n\tv27 = *([v26 @ X8_v21]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, name, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2024799]) = v45;\nL_0018:\n\tv47 = HutongGames.PlayMaker.FsmVariables::get_Vector3Variables(this);\n\tv197 = v47.Length;\n\tv61 = v47.Length < 1;\n\tif (v61) goto L_004F;\nL_002A:\n\tv211 = v160 < v197;\n\tv187 = ~v211;\n\tif (v187) goto L_00A5;\n\tv148 = v47[v160 @ X23_v12 (System.Int32)];\n\tv144 = System.String::op_Equality(v148.name, v67);\n\tv321 = v144 == 0;\n\tv146 = ~v321;\n\tif (v146) goto L_00A2;\n\tv197 = v47.Length;\n\tv160 = v160 + 1;\n\tv134 = v160 < v47.Length;\n\tif (v134) goto L_002A;\nL_004F:\n\tv149 = HutongGames.PlayMaker.FsmVariables::get_GlobalVariables();\n\tv212 = v149 == 0;\n\tif (v212) goto L_008F;\n\tv116 = HutongGames.PlayMaker.FsmVariables::get_GlobalVariables();\n\tv117 = HutongGames.PlayMaker.FsmVariables::get_Vector3Variables(v116);\n\tv198 = v117.Length;\n\tv228 = v117.Length < 1;\n\tif (v228) goto L_008F;\nL_0067:\n\tv340 = v161 < v198;\n\tv188 = ~v340;\n\tif (v188) goto L_00A5;\n\tv262 = v117[v161 @ X23_v9 (System.Int32)];\n\tv255 = System.String::op_Equality(v262.name, v67);\n\tv343 = v255 == 0;\n\tv257 = ~v343;\n\tif (v257) goto L_00A2;\n\tv198 = v117.Length;\n\tv161 = v161 + 1;\n\tv227 = v161 < v117.Length;\n\tif (v227) goto L_0067;\nL_008F:\n\tv266 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v266, v67);\n\tv270 = HutongGames.PlayMaker.FsmVariables::GetVariable(this, v67);\n\tv266.obj = v270;\nL_00A2:\n\treturn v328;\n\tv128 = new System.NullReferenceException();\nL_00A5:\n\tv202 = new System.IndexOutOfRangeException();\n\tthrow v202;\n\treturn returnVal1;\n// 119 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmVector3 GetFsmVector3(string name)
		{
			//IL_0028: Expected I4, but got O
			FsmVector3[] array = Vector3Variables;
			int num = array.Length;
			bool flag = array.Length < 1;
			bool flag2 = (byte)(int)array != 0;
			if (flag)
			{
				goto IL_00e0;
			}
			int num2 = 0;
			string text = default(string);
			FsmVector3 result;
			while (num2 < num)
			{
				FsmVector3 fsmVector = array[num2];
				flag2 = fsmVector.Name == text;
				bool flag3 = !flag2;
				bool flag4 = !flag3;
				result = array[num2];
				if (!flag4)
				{
					num = array.Length;
					num2++;
					if (num2 < array.Length)
					{
						continue;
					}
					goto IL_00e0;
				}
				goto IL_0256;
			}
			goto IL_0239;
			IL_00e0:
			FsmVariables globalVariables = GlobalVariables;
			if (globalVariables != null)
			{
				FsmVariables globalVariables2 = GlobalVariables;
				FsmVector3[] array2 = globalVariables2.Vector3Variables;
				int num3 = array2.Length;
				if (array2.Length >= 1)
				{
					int num4 = 0;
					while (num4 < num3)
					{
						FsmVector3 fsmVector2 = array2[num4];
						bool flag5 = fsmVector2.Name == text;
						bool flag6 = !flag5;
						bool flag7 = !flag6;
						result = array2[num4];
						if (!flag7)
						{
							num3 = array2.Length;
							num4++;
							if (num4 < array2.Length)
							{
								continue;
							}
							goto IL_01f9;
						}
						goto IL_0256;
					}
					goto IL_0239;
				}
			}
			goto IL_01f9;
			IL_0239:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_01f9:
			FsmVector3 fsmVector3 = (FsmVector3)new NamedVariable(text);
			NamedVariable variable = GetVariable(text);
			fsmVector3.obj = variable;
			result = fsmVector3;
			goto IL_0256;
			IL_0256:
			return result;
		}

		[Token(Token = "0x6000636")]
		[Address(RVA = "0xE4F76C", Offset = "0xE4F76C", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EC82C8]);\n\tv25 = *([v24 @ X8_v21]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, name, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202479A]) = v43;\nL_0017:\n\tv45 = HutongGames.PlayMaker.FsmVariables::get_RectVariables(this);\n\tv195 = v45.Length;\n\tv59 = v45.Length < 1;\n\tif (v59) goto L_004E;\nL_0029:\n\tv209 = v158 < v195;\n\tv185 = ~v209;\n\tif (v185) goto L_009E;\n\tv146 = v45[v158 @ X22_v12 (System.Int32)];\n\tv142 = System.String::op_Equality(v146.name, v65);\n\tv315 = v142 == 0;\n\tv144 = ~v315;\n\tif (v144) goto L_009B;\n\tv195 = v45.Length;\n\tv158 = v158 + 1;\n\tv132 = v158 < v45.Length;\n\tif (v132) goto L_0029;\nL_004E:\n\tv147 = HutongGames.PlayMaker.FsmVariables::get_GlobalVariables();\n\tv210 = v147 == 0;\n\tif (v210) goto L_008E;\n\tv111 = HutongGames.PlayMaker.FsmVariables::get_GlobalVariables();\n\tv112 = HutongGames.PlayMaker.FsmVariables::get_RectVariables(v111);\n\tv196 = v112.Length;\n\tv226 = v112.Length < 1;\n\tif (v226) goto L_008E;\nL_0066:\n\tv333 = v159 < v196;\n\tv186 = ~v333;\n\tif (v186) goto L_009E;\n\tv260 = v112[v159 @ X22_v9 (System.Int32)];\n\tv252 = System.String::op_Equality(v260.name, v65);\n\tv336 = v252 == 0;\n\tv254 = ~v336;\n\tif (v254) goto L_009B;\n\tv196 = v112.Length;\n\tv159 = v159 + 1;\n\tv225 = v159 < v112.Length;\n\tif (v225) goto L_0066;\nL_008E:\n\tv264 = new HutongGames.PlayMaker.FsmRect();\n\tHutongGames.PlayMaker.FsmRect::.ctor(v264, v65);\nL_009B:\n\treturn v319;\n\tv126 = new System.NullReferenceException();\nL_009E:\n\tv200 = new System.IndexOutOfRangeException();\n\tthrow v200;\n\treturn returnVal1;\n// 114 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmRect GetFsmRect(string name)
		{
			//IL_0028: Expected I4, but got O
			FsmRect[] array = RectVariables;
			int num = array.Length;
			bool flag = array.Length < 1;
			bool flag2 = (byte)(int)array != 0;
			if (flag)
			{
				goto IL_00df;
			}
			int num2 = 0;
			string text = default(string);
			FsmRect result;
			while (num2 < num)
			{
				FsmRect fsmRect = array[num2];
				flag2 = fsmRect.Name == text;
				bool flag3 = !flag2;
				bool flag4 = !flag3;
				result = array[num2];
				if (!flag4)
				{
					num = array.Length;
					num2++;
					if (num2 < array.Length)
					{
						continue;
					}
					goto IL_00df;
				}
				goto IL_0212;
			}
			goto IL_0217;
			IL_00df:
			FsmVariables globalVariables = GlobalVariables;
			if (globalVariables != null)
			{
				FsmVariables globalVariables2 = GlobalVariables;
				FsmRect[] array2 = globalVariables2.RectVariables;
				int num3 = array2.Length;
				if (array2.Length >= 1)
				{
					int num4 = 0;
					while (num4 < num3)
					{
						FsmRect fsmRect2 = array2[num4];
						bool flag5 = fsmRect2.Name == text;
						bool flag6 = !flag5;
						bool flag7 = !flag6;
						result = array2[num4];
						if (!flag7)
						{
							num3 = array2.Length;
							num4++;
							if (num4 < array2.Length)
							{
								continue;
							}
							goto IL_01f7;
						}
						goto IL_0212;
					}
					goto IL_0217;
				}
			}
			goto IL_01f7;
			IL_0217:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_01f7:
			FsmRect fsmRect3 = new FsmRect(text);
			result = fsmRect3;
			goto IL_0212;
			IL_0212:
			return result;
		}

		[Token(Token = "0x6000637")]
		[Address(RVA = "0xE4F8B0", Offset = "0xE4F8B0", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EA6320]);\n\tv25 = *([v24 @ X8_v21]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, name, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202479B]) = v43;\nL_0017:\n\tv45 = HutongGames.PlayMaker.FsmVariables::get_QuaternionVariables(this);\n\tv195 = v45.Length;\n\tv59 = v45.Length < 1;\n\tif (v59) goto L_004E;\nL_0029:\n\tv209 = v158 < v195;\n\tv185 = ~v209;\n\tif (v185) goto L_009E;\n\tv146 = v45[v158 @ X22_v12 (System.Int32)];\n\tv142 = System.String::op_Equality(v146.name, v65);\n\tv315 = v142 == 0;\n\tv144 = ~v315;\n\tif (v144) goto L_009B;\n\tv195 = v45.Length;\n\tv158 = v158 + 1;\n\tv132 = v158 < v45.Length;\n\tif (v132) goto L_0029;\nL_004E:\n\tv147 = HutongGames.PlayMaker.FsmVariables::get_GlobalVariables();\n\tv210 = v147 == 0;\n\tif (v210) goto L_008E;\n\tv111 = HutongGames.PlayMaker.FsmVariables::get_GlobalVariables();\n\tv112 = HutongGames.PlayMaker.FsmVariables::get_QuaternionVariables(v111);\n\tv196 = v112.Length;\n\tv226 = v112.Length < 1;\n\tif (v226) goto L_008E;\nL_0066:\n\tv333 = v159 < v196;\n\tv186 = ~v333;\n\tif (v186) goto L_009E;\n\tv260 = v112[v159 @ X22_v9 (System.Int32)];\n\tv252 = System.String::op_Equality(v260.name, v65);\n\tv336 = v252 == 0;\n\tv254 = ~v336;\n\tif (v254) goto L_009B;\n\tv196 = v112.Length;\n\tv159 = v159 + 1;\n\tv225 = v159 < v112.Length;\n\tif (v225) goto L_0066;\nL_008E:\n\tv264 = new HutongGames.PlayMaker.FsmQuaternion();\n\tHutongGames.PlayMaker.FsmQuaternion::.ctor(v264, v65);\nL_009B:\n\treturn v319;\n\tv126 = new System.NullReferenceException();\nL_009E:\n\tv200 = new System.IndexOutOfRangeException();\n\tthrow v200;\n\treturn returnVal1;\n// 114 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmQuaternion GetFsmQuaternion(string name)
		{
			//IL_0028: Expected I4, but got O
			FsmQuaternion[] array = QuaternionVariables;
			int num = array.Length;
			bool flag = array.Length < 1;
			bool flag2 = (byte)(int)array != 0;
			if (flag)
			{
				goto IL_00df;
			}
			int num2 = 0;
			string text = default(string);
			FsmQuaternion result;
			while (num2 < num)
			{
				FsmQuaternion fsmQuaternion = array[num2];
				flag2 = fsmQuaternion.Name == text;
				bool flag3 = !flag2;
				bool flag4 = !flag3;
				result = array[num2];
				if (!flag4)
				{
					num = array.Length;
					num2++;
					if (num2 < array.Length)
					{
						continue;
					}
					goto IL_00df;
				}
				goto IL_0212;
			}
			goto IL_0217;
			IL_00df:
			FsmVariables globalVariables = GlobalVariables;
			if (globalVariables != null)
			{
				FsmVariables globalVariables2 = GlobalVariables;
				FsmQuaternion[] array2 = globalVariables2.QuaternionVariables;
				int num3 = array2.Length;
				if (array2.Length >= 1)
				{
					int num4 = 0;
					while (num4 < num3)
					{
						FsmQuaternion fsmQuaternion2 = array2[num4];
						bool flag5 = fsmQuaternion2.Name == text;
						bool flag6 = !flag5;
						bool flag7 = !flag6;
						result = array2[num4];
						if (!flag7)
						{
							num3 = array2.Length;
							num4++;
							if (num4 < array2.Length)
							{
								continue;
							}
							goto IL_01f7;
						}
						goto IL_0212;
					}
					goto IL_0217;
				}
			}
			goto IL_01f7;
			IL_0217:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_01f7:
			FsmQuaternion fsmQuaternion3 = new FsmQuaternion(text);
			result = fsmQuaternion3;
			goto IL_0212;
			IL_0212:
			return result;
		}

		[Token(Token = "0x6000638")]
		[Address(RVA = "0xE4F9F4", Offset = "0xE4F9F4", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EE4D48]);\n\tv25 = *([v24 @ X8_v21]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, name, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202479C]) = v43;\nL_0017:\n\tv45 = HutongGames.PlayMaker.FsmVariables::get_ColorVariables(this);\n\tv195 = v45.Length;\n\tv59 = v45.Length < 1;\n\tif (v59) goto L_004E;\nL_0029:\n\tv209 = v158 < v195;\n\tv185 = ~v209;\n\tif (v185) goto L_009E;\n\tv146 = v45[v158 @ X22_v12 (System.Int32)];\n\tv142 = System.String::op_Equality(v146.name, v65);\n\tv315 = v142 == 0;\n\tv144 = ~v315;\n\tif (v144) goto L_009B;\n\tv195 = v45.Length;\n\tv158 = v158 + 1;\n\tv132 = v158 < v45.Length;\n\tif (v132) goto L_0029;\nL_004E:\n\tv147 = HutongGames.PlayMaker.FsmVariables::get_GlobalVariables();\n\tv210 = v147 == 0;\n\tif (v210) goto L_008E;\n\tv111 = HutongGames.PlayMaker.FsmVariables::get_GlobalVariables();\n\tv112 = HutongGames.PlayMaker.FsmVariables::get_ColorVariables(v111);\n\tv196 = v112.Length;\n\tv226 = v112.Length < 1;\n\tif (v226) goto L_008E;\nL_0066:\n\tv333 = v159 < v196;\n\tv186 = ~v333;\n\tif (v186) goto L_009E;\n\tv260 = v112[v159 @ X22_v9 (System.Int32)];\n\tv252 = System.String::op_Equality(v260.name, v65);\n\tv336 = v252 == 0;\n\tv254 = ~v336;\n\tif (v254) goto L_009B;\n\tv196 = v112.Length;\n\tv159 = v159 + 1;\n\tv225 = v159 < v112.Length;\n\tif (v225) goto L_0066;\nL_008E:\n\tv264 = new HutongGames.PlayMaker.FsmColor();\n\tHutongGames.PlayMaker.FsmColor::.ctor(v264, v65);\nL_009B:\n\treturn v319;\n\tv126 = new System.NullReferenceException();\nL_009E:\n\tv200 = new System.IndexOutOfRangeException();\n\tthrow v200;\n\treturn returnVal1;\n// 114 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmColor GetFsmColor(string name)
		{
			//IL_0028: Expected I4, but got O
			FsmColor[] array = ColorVariables;
			int num = array.Length;
			bool flag = array.Length < 1;
			bool flag2 = (byte)(int)array != 0;
			if (flag)
			{
				goto IL_00df;
			}
			int num2 = 0;
			string text = default(string);
			FsmColor result;
			while (num2 < num)
			{
				FsmColor fsmColor = array[num2];
				flag2 = fsmColor.Name == text;
				bool flag3 = !flag2;
				bool flag4 = !flag3;
				result = array[num2];
				if (!flag4)
				{
					num = array.Length;
					num2++;
					if (num2 < array.Length)
					{
						continue;
					}
					goto IL_00df;
				}
				goto IL_0212;
			}
			goto IL_0217;
			IL_00df:
			FsmVariables globalVariables = GlobalVariables;
			if (globalVariables != null)
			{
				FsmVariables globalVariables2 = GlobalVariables;
				FsmColor[] array2 = globalVariables2.ColorVariables;
				int num3 = array2.Length;
				if (array2.Length >= 1)
				{
					int num4 = 0;
					while (num4 < num3)
					{
						FsmColor fsmColor2 = array2[num4];
						bool flag5 = fsmColor2.Name == text;
						bool flag6 = !flag5;
						bool flag7 = !flag6;
						result = array2[num4];
						if (!flag7)
						{
							num3 = array2.Length;
							num4++;
							if (num4 < array2.Length)
							{
								continue;
							}
							goto IL_01f7;
						}
						goto IL_0212;
					}
					goto IL_0217;
				}
			}
			goto IL_01f7;
			IL_0217:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_01f7:
			FsmColor fsmColor3 = new FsmColor(text);
			result = fsmColor3;
			goto IL_0212;
			IL_0212:
			return result;
		}

		[Token(Token = "0x6000639")]
		[Address(RVA = "0xE4FB38", Offset = "0xE4FB38", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = *([1EA5B78]);\n\tv27 = *([v26 @ X8_v21]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, name, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([202479D]) = v45;\nL_0018:\n\tv47 = HutongGames.PlayMaker.FsmVariables::get_GameObjectVariables(this);\n\tv197 = v47.Length;\n\tv61 = v47.Length < 1;\n\tif (v61) goto L_004F;\nL_002A:\n\tv211 = v160 < v197;\n\tv187 = ~v211;\n\tif (v187) goto L_00A6;\n\tv148 = v47[v160 @ X23_v12 (System.Int32)];\n\tv144 = System.String::op_Equality(v148.name, v67);\n\tv322 = v144 == 0;\n\tv146 = ~v322;\n\tif (v146) goto L_00A3;\n\tv197 = v47.Length;\n\tv160 = v160 + 1;\n\tv134 = v160 < v47.Length;\n\tif (v134) goto L_002A;\nL_004F:\n\tv149 = HutongGames.PlayMaker.FsmVariables::get_GlobalVariables();\n\tv212 = v149 == 0;\n\tif (v212) goto L_008F;\n\tv116 = HutongGames.PlayMaker.FsmVariables::get_GlobalVariables();\n\tv117 = HutongGames.PlayMaker.FsmVariables::get_GameObjectVariables(v116);\n\tv198 = v117.Length;\n\tv228 = v117.Length < 1;\n\tif (v228) goto L_008F;\nL_0067:\n\tv341 = v161 < v198;\n\tv188 = ~v341;\n\tif (v188) goto L_00A6;\n\tv262 = v117[v161 @ X23_v9 (System.Int32)];\n\tv255 = System.String::op_Equality(v262.name, v67);\n\tv344 = v255 == 0;\n\tv257 = ~v344;\n\tif (v257) goto L_00A3;\n\tv198 = v117.Length;\n\tv161 = v161 + 1;\n\tv227 = v161 < v117.Length;\n\tif (v227) goto L_0067;\nL_008F:\n\tv266 = new HutongGames.PlayMaker.FsmGameObject();\n\tHutongGames.PlayMaker.FsmGameObject::.ctor(v266, v67);\n\tv271 = HutongGames.PlayMaker.FsmVariables::GetVariable(this, v67);\n\tv266.obj = v271;\nL_00A3:\n\treturn v329;\n\tv128 = new System.NullReferenceException();\nL_00A6:\n\tv202 = new System.IndexOutOfRangeException();\n\tthrow v202;\n\treturn returnVal1;\n// 120 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmGameObject GetFsmGameObject(string name)
		{
			//IL_0028: Expected I4, but got O
			FsmGameObject[] array = GameObjectVariables;
			int num = array.Length;
			bool flag = array.Length < 1;
			bool flag2 = (byte)(int)array != 0;
			if (flag)
			{
				goto IL_00df;
			}
			int num2 = 0;
			string text = default(string);
			FsmGameObject result;
			while (num2 < num)
			{
				FsmGameObject fsmGameObject = array[num2];
				flag2 = fsmGameObject.Name == text;
				bool flag3 = !flag2;
				bool flag4 = !flag3;
				result = array[num2];
				if (!flag4)
				{
					num = array.Length;
					num2++;
					if (num2 < array.Length)
					{
						continue;
					}
					goto IL_00df;
				}
				goto IL_0254;
			}
			goto IL_0237;
			IL_00df:
			FsmVariables globalVariables = GlobalVariables;
			if (globalVariables != null)
			{
				FsmVariables globalVariables2 = GlobalVariables;
				FsmGameObject[] array2 = globalVariables2.GameObjectVariables;
				int num3 = array2.Length;
				if (array2.Length >= 1)
				{
					int num4 = 0;
					while (num4 < num3)
					{
						FsmGameObject fsmGameObject2 = array2[num4];
						bool flag5 = fsmGameObject2.Name == text;
						bool flag6 = !flag5;
						bool flag7 = !flag6;
						result = array2[num4];
						if (!flag7)
						{
							num3 = array2.Length;
							num4++;
							if (num4 < array2.Length)
							{
								continue;
							}
							goto IL_01f7;
						}
						goto IL_0254;
					}
					goto IL_0237;
				}
			}
			goto IL_01f7;
			IL_0237:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_01f7:
			FsmGameObject fsmGameObject3 = new FsmGameObject(text);
			NamedVariable variable = GetVariable(text);
			fsmGameObject3.obj = variable;
			result = fsmGameObject3;
			goto IL_0254;
			IL_0254:
			return result;
		}

		[Token(Token = "0x600063A")]
		[Address(RVA = "0xE4FC98", Offset = "0xE4FC98", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1F0E628]);\n\tv25 = *([v24 @ X8_v21]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, name, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202479E]) = v43;\nL_0017:\n\tv45 = HutongGames.PlayMaker.FsmVariables::get_ArrayVariables(this);\n\tv195 = v45.Length;\n\tv59 = v45.Length < 1;\n\tif (v59) goto L_004E;\nL_0029:\n\tv209 = v158 < v195;\n\tv185 = ~v209;\n\tif (v185) goto L_009E;\n\tv146 = v45[v158 @ X22_v12 (System.Int32)];\n\tv142 = System.String::op_Equality(v146.name, v65);\n\tv315 = v142 == 0;\n\tv144 = ~v315;\n\tif (v144) goto L_009B;\n\tv195 = v45.Length;\n\tv158 = v158 + 1;\n\tv132 = v158 < v45.Length;\n\tif (v132) goto L_0029;\nL_004E:\n\tv147 = HutongGames.PlayMaker.FsmVariables::get_GlobalVariables();\n\tv210 = v147 == 0;\n\tif (v210) goto L_008E;\n\tv111 = HutongGames.PlayMaker.FsmVariables::get_GlobalVariables();\n\tv112 = HutongGames.PlayMaker.FsmVariables::get_ArrayVariables(v111);\n\tv196 = v112.Length;\n\tv226 = v112.Length < 1;\n\tif (v226) goto L_008E;\nL_0066:\n\tv333 = v159 < v196;\n\tv186 = ~v333;\n\tif (v186) goto L_009E;\n\tv260 = v112[v159 @ X22_v9 (System.Int32)];\n\tv252 = System.String::op_Equality(v260.name, v65);\n\tv336 = v252 == 0;\n\tv254 = ~v336;\n\tif (v254) goto L_009B;\n\tv196 = v112.Length;\n\tv159 = v159 + 1;\n\tv225 = v159 < v112.Length;\n\tif (v225) goto L_0066;\nL_008E:\n\tv264 = new HutongGames.PlayMaker.FsmArray();\n\tHutongGames.PlayMaker.FsmArray::.ctor(v264, v65);\nL_009B:\n\treturn v319;\n\tv126 = new System.NullReferenceException();\nL_009E:\n\tv200 = new System.IndexOutOfRangeException();\n\tthrow v200;\n\treturn returnVal1;\n// 114 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmArray GetFsmArray(string name)
		{
			//IL_0028: Expected I4, but got O
			FsmArray[] array = ArrayVariables;
			int num = array.Length;
			bool flag = array.Length < 1;
			bool flag2 = (byte)(int)array != 0;
			if (flag)
			{
				goto IL_00df;
			}
			int num2 = 0;
			string text = default(string);
			FsmArray result;
			while (num2 < num)
			{
				FsmArray fsmArray = array[num2];
				flag2 = fsmArray.Name == text;
				bool flag3 = !flag2;
				bool flag4 = !flag3;
				result = array[num2];
				if (!flag4)
				{
					num = array.Length;
					num2++;
					if (num2 < array.Length)
					{
						continue;
					}
					goto IL_00df;
				}
				goto IL_0212;
			}
			goto IL_0217;
			IL_00df:
			FsmVariables globalVariables = GlobalVariables;
			if (globalVariables != null)
			{
				FsmVariables globalVariables2 = GlobalVariables;
				FsmArray[] array2 = globalVariables2.ArrayVariables;
				int num3 = array2.Length;
				if (array2.Length >= 1)
				{
					int num4 = 0;
					while (num4 < num3)
					{
						FsmArray fsmArray2 = array2[num4];
						bool flag5 = fsmArray2.Name == text;
						bool flag6 = !flag5;
						bool flag7 = !flag6;
						result = array2[num4];
						if (!flag7)
						{
							num3 = array2.Length;
							num4++;
							if (num4 < array2.Length)
							{
								continue;
							}
							goto IL_01f7;
						}
						goto IL_0212;
					}
					goto IL_0217;
				}
			}
			goto IL_01f7;
			IL_0217:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_01f7:
			FsmArray fsmArray3 = new FsmArray(text);
			result = fsmArray3;
			goto IL_0212;
			IL_0212:
			return result;
		}

		[Token(Token = "0x600063B")]
		[Address(RVA = "0xE4FDDC", Offset = "0xE4FDDC", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = *([1EEF148]);\n\tv27 = *([v26 @ X8_v21]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, name, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([202479F]) = v45;\nL_0018:\n\tv47 = HutongGames.PlayMaker.FsmVariables::get_EnumVariables(this);\n\tv197 = v47.Length;\n\tv61 = v47.Length < 1;\n\tif (v61) goto L_004F;\nL_002A:\n\tv211 = v160 < v197;\n\tv187 = ~v211;\n\tif (v187) goto L_00A6;\n\tv148 = v47[v160 @ X23_v12 (System.Int32)];\n\tv144 = System.String::op_Equality(v148.name, v67);\n\tv322 = v144 == 0;\n\tv146 = ~v322;\n\tif (v146) goto L_00A3;\n\tv197 = v47.Length;\n\tv160 = v160 + 1;\n\tv134 = v160 < v47.Length;\n\tif (v134) goto L_002A;\nL_004F:\n\tv149 = HutongGames.PlayMaker.FsmVariables::get_GlobalVariables();\n\tv212 = v149 == 0;\n\tif (v212) goto L_008F;\n\tv116 = HutongGames.PlayMaker.FsmVariables::get_GlobalVariables();\n\tv117 = HutongGames.PlayMaker.FsmVariables::get_EnumVariables(v116);\n\tv198 = v117.Length;\n\tv228 = v117.Length < 1;\n\tif (v228) goto L_008F;\nL_0067:\n\tv341 = v161 < v198;\n\tv188 = ~v341;\n\tif (v188) goto L_00A6;\n\tv262 = v117[v161 @ X23_v9 (System.Int32)];\n\tv255 = System.String::op_Equality(v262.name, v67);\n\tv344 = v255 == 0;\n\tv257 = ~v344;\n\tif (v257) goto L_00A3;\n\tv198 = v117.Length;\n\tv161 = v161 + 1;\n\tv227 = v161 < v117.Length;\n\tif (v227) goto L_0067;\nL_008F:\n\tv266 = new HutongGames.PlayMaker.FsmEnum();\n\tHutongGames.PlayMaker.FsmEnum::.ctor(v266, v67);\n\tv271 = HutongGames.PlayMaker.FsmVariables::GetVariable(this, v67);\n\tv266.obj = v271;\nL_00A3:\n\treturn v329;\n\tv128 = new System.NullReferenceException();\nL_00A6:\n\tv202 = new System.IndexOutOfRangeException();\n\tthrow v202;\n\treturn returnVal1;\n// 120 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmEnum GetFsmEnum(string name)
		{
			//IL_0028: Expected I4, but got O
			FsmEnum[] array = EnumVariables;
			int num = array.Length;
			bool flag = array.Length < 1;
			bool flag2 = (byte)(int)array != 0;
			if (flag)
			{
				goto IL_00df;
			}
			int num2 = 0;
			string text = default(string);
			FsmEnum result;
			while (num2 < num)
			{
				FsmEnum fsmEnum = array[num2];
				flag2 = fsmEnum.Name == text;
				bool flag3 = !flag2;
				bool flag4 = !flag3;
				result = array[num2];
				if (!flag4)
				{
					num = array.Length;
					num2++;
					if (num2 < array.Length)
					{
						continue;
					}
					goto IL_00df;
				}
				goto IL_0254;
			}
			goto IL_0237;
			IL_00df:
			FsmVariables globalVariables = GlobalVariables;
			if (globalVariables != null)
			{
				FsmVariables globalVariables2 = GlobalVariables;
				FsmEnum[] array2 = globalVariables2.EnumVariables;
				int num3 = array2.Length;
				if (array2.Length >= 1)
				{
					int num4 = 0;
					while (num4 < num3)
					{
						FsmEnum fsmEnum2 = array2[num4];
						bool flag5 = fsmEnum2.Name == text;
						bool flag6 = !flag5;
						bool flag7 = !flag6;
						result = array2[num4];
						if (!flag7)
						{
							num3 = array2.Length;
							num4++;
							if (num4 < array2.Length)
							{
								continue;
							}
							goto IL_01f7;
						}
						goto IL_0254;
					}
					goto IL_0237;
				}
			}
			goto IL_01f7;
			IL_0237:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_01f7:
			FsmEnum fsmEnum3 = new FsmEnum(text);
			NamedVariable variable = GetVariable(text);
			fsmEnum3.obj = variable;
			result = fsmEnum3;
			goto IL_0254;
			IL_0254:
			return result;
		}

		[Token(Token = "0x600063C")]
		[Address(RVA = "0xE4EC84", Offset = "0xE4EC84", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void LogMissingVariable(string name)
		{
		}

		[Token(Token = "0x600063D")]
		[Address(RVA = "0xE4FF3C", Offset = "0xE4FF3C", Length = "0x57C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = HutongGames.PlayMaker.FsmVariables::get_FloatVariables(this);\n\tv386 = v20.Length;\n\tv34 = v20.Length < 1;\n\tif (v34) goto L_0043;\nL_001D:\n\tv389 = v376 < v386;\n\tv390 = ~v389;\n\tif (v390) goto L_035F;\n\tv354 = v20[v376 @ X23_v60 (System.Int32)];\n\tv370 = System.String::op_Equality(v354.name, v54);\n\tv795 = v370 == 0;\n\tv368 = ~v795;\n\tif (v368) goto L_035E;\n\tv386 = v20.Length;\n\tv376 = v376 + 1;\n\tv357 = v376 < v20.Length;\n\tif (v357) goto L_001D;\nL_0043:\n\tv320 = HutongGames.PlayMaker.FsmVariables::get_IntVariables(this);\n\tv654 = v320.Length;\n\tv713 = v320.Length < 1;\n\tif (v713) goto L_007B;\nL_0055:\n\tv804 = v505 < v654;\n\tv639 = ~v804;\n\tif (v639) goto L_035F;\n\tv717 = v320[v505 @ X23_v57 (System.Int32)];\n\tv792 = System.String::op_Equality(v717.name, v54);\n\tv916 = v792 == 0;\n\tv790 = ~v916;\n\tif (v790) goto L_035E;\n\tv654 = v320.Length;\n\tv505 = v505 + 1;\n\tv779 = v505 < v320.Length;\n\tif (v779) goto L_0055;\nL_007B:\n\tv321 = HutongGames.PlayMaker.FsmVariables::get_BoolVariables(this);\n\tv655 = v321.Length;\n\tv898 = v321.Length < 1;\n\tif (v898) goto L_00B3;\nL_008D:\n\tv925 = v506 < v655;\n\tv640 = ~v925;\n\tif (v640) goto L_035F;\n\tv718 = v321[v506 @ X23_v54 (System.Int32)];\n\tv873 = System.String::op_Equality(v718.name, v54);\n\tv957 = v873 == 0;\n\tv857 = ~v957;\n\tif (v857) goto L_035E;\n\tv655 = v321.Length;\n\tv506 = v506 + 1;\n\tv902 = v506 < v321.Length;\n\tif (v902) goto L_008D;\nL_00B3:\n\tv322 = HutongGames.PlayMaker.FsmVariables::get_Vector2Variables(this);\n\tv656 = v322.Length;\n\tv939 = v322.Length < 1;\n\tif (v939) goto L_00EB;\nL_00C5:\n\tv966 = v507 < v656;\n\tv641 = ~v966;\n\tif (v641) goto L_035F;\n\tv719 = v322[v507 @ X23_v51 (System.Int32)];\n\tv874 = System.String::op_Equality(v719.name, v54);\n\tv998 = v874 == 0;\n\tv858 = ~v998;\n\tif (v858) goto L_035E;\n\tv656 = v322.Length;\n\tv507 = v507 + 1;\n\tv943 = v507 < v322.Length;\n\tif (v943) goto L_00C5;\nL_00EB:\n\tv323 = HutongGames.PlayMaker.FsmVariables::get_Vector3Variables(this);\n\tv657 = v323.Length;\n\tv980 = v323.Length < 1;\n\tif (v980) goto L_0123;\nL_00FD:\n\tv1007 = v508 < v657;\n\tv642 = ~v1007;\n\tif (v642) goto L_035F;\n\tv720 = v323[v508 @ X23_v48 (System.Int32)];\n\tv875 = System.String::op_Equality(v720.name, v54);\n\tv1039 = v875 == 0;\n\tv859 = ~v1039;\n\tif (v859) goto L_035E;\n\tv657 = v323.Length;\n\tv508 = v508 + 1;\n\tv984 = v508 < v323.Length;\n\tif (v984) goto L_00FD;\nL_0123:\n\tv324 = HutongGames.PlayMaker.FsmVariables::get_StringVariables(this);\n\tv658 = v324.Length;\n\tv1021 = v324.Length < 1;\n\tif (v1021) goto L_015B;\nL_0135:\n\tv1048 = v509 < v658;\n\tv643 = ~v1048;\n\tif (v643) goto L_035F;\n\tv721 = v324[v509 @ X23_v45 (System.Int32)];\n\tv876 = System.String::op_Equality(v721.name, v54);\n\tv1080 = v876 == 0;\n\tv860 = ~v1080;\n\tif (v860) goto L_035E;\n\tv658 = v324.Length;\n\tv509 = v509 + 1;\n\tv1025 = v509 < v324.Length;\n\tif (v1025) goto L_0135;\nL_015B:\n\tv325 = HutongGames.PlayMaker.FsmVariables::get_RectVariables(this);\n\tv659 = v325.Length;\n\tv1062 = v325.Length < 1;\n\tif (v1062) goto L_0193;\nL_016D:\n\tv1089 = v510 < v659;\n\tv644 = ~v1089;\n\tif (v644) goto L_035F;\n\tv722 = v325[v510 @ X23_v42 (System.Int32)];\n\tv877 = System.String::op_Equality(v722.name, v54);\n\tv1121 = v877 == 0;\n\tv861 = ~v1121;\n\tif (v861) goto L_035E;\n\tv659 = v325.Length;\n\tv510 = v510 + 1;\n\tv1066 = v510 < v325.Length;\n\tif (v1066) goto L_016D;\nL_0193:\n\tv326 = HutongGames.PlayMaker.FsmVariables::get_ColorVariables(this);\n\tv660 = v326.Length;\n\tv1103 = v326.Length < 1;\n\tif (v1103) goto L_01CB;\nL_01A5:\n\tv1130 = v511 < v660;\n\tv645 = ~v1130;\n\tif (v645) goto L_035F;\n\tv723 = v326[v511 @ X23_v39 (System.Int32)];\n\tv878 = System.String::op_Equality(v723.name, v54);\n\tv1162 = v878 == 0;\n\tv862 = ~v1162;\n\tif (v862) goto L_035E;\n\tv660 = v326.Length;\n\tv511 = v511 + 1;\n\tv1107 = v511 < v326.Length;\n\tif (v1107) goto L_01A5;\nL_01CB:\n\tv327 = HutongGames.PlayMaker.FsmVariables::get_MaterialVariables(this);\n\tv661 = v327.Length;\n\tv1144 = v327.Length < 1;\n\tif (v1144) goto L_0203;\nL_01DD:\n\tv1171 = v512 < v661;\n\tv646 = ~v1171;\n\tif (v646) goto L_035F;\n\tv724 = v327[v512 @ X23_v36 (System.Int32)];\n\tv879 = System.String::op_Equality(v724.name, v54);\n\tv1203 = v879 == 0;\n\tv863 = ~v1203;\n\tif (v863) goto L_035E;\n\tv661 = v327.Length;\n\tv512 = v512 + 1;\n\tv1148 = v512 < v327.Length;\n\tif (v1148) goto L_01DD;\nL_0203:\n\tv328 = HutongGames.PlayMaker.FsmVariables::get_TextureVariables(this);\n\tv662 = v328.Length;\n\tv1185 = v328.Length < 1;\n\tif (v1185) goto L_023B;\nL_0215:\n\tv1212 = v513 < v662;\n\tv647 = ~v1212;\n\tif (v647) goto L_035F;\n\tv725 = v328[v513 @ X23_v33 (System.Int32)];\n\tv880 = System.String::op_Equality(v725.name, v54);\n\tv1244 = v880 == 0;\n\tv864 = ~v1244;\n\tif (v864) goto L_035E;\n\tv662 = v328.Length;\n\tv513 = v513 + 1;\n\tv1189 = v513 < v328.Length;\n\tif (v1189) goto L_0215;\nL_023B:\n\tv329 = HutongGames.PlayMaker.FsmVariables::get_ObjectVariables(this);\n\tv663 = v329.Length;\n\tv1226 = v329.Length < 1;\n\tif (v1226) goto L_0273;\nL_024D:\n\tv1253 = v514 < v663;\n\tv648 = ~v1253;\n\tif (v648) goto L_035F;\n\tv726 = v329[v514 @ X23_v30 (System.Int32)];\n\tv881 = System.String::op_Equality(v726.name, v54);\n\tv1285 = v881 == 0;\n\tv865 = ~v1285;\n\tif (v865) goto L_035E;\n\tv663 = v329.Length;\n\tv514 = v514 + 1;\n\tv1230 = v514 < v329.Length;\n\tif (v1230) goto L_024D;\nL_0273:\n\tv330 = HutongGames.PlayMaker.FsmVariables::get_GameObjectVariables(this);\n\tv664 = v330.Length;\n\tv1267 = v330.Length < 1;\n\tif (v1267) goto L_02AB;\nL_0285:\n\tv1294 = v515 < v664;\n\tv649 = ~v1294;\n\tif (v649) goto L_035F;\n\tv727 = v330[v515 @ X23_v27 (System.Int32)];\n\tv882 = System.String::op_Equality(v727.name, v54);\n\tv1326 = v882 == 0;\n\tv866 = ~v1326;\n\tif (v866) goto L_035E;\n\tv664 = v330.Length;\n\tv515 = v515 + 1;\n\tv1271 = v515 < v330.Length;\n\tif (v1271) goto L_0285;\nL_02AB:\n\tv331 = HutongGames.PlayMaker.FsmVariables::get_QuaternionVariables(this);\n\tv665 = v331.Length;\n\tv1308 = v331.Length < 1;\n\tif (v1308) goto L_02E3;\nL_02BD:\n\tv1335 = v516 < v665;\n\tv650 = ~v1335;\n\tif (v650) goto L_035F;\n\tv728 = v331[v516 @ X23_v24 (System.Int32)];\n\tv883 = System.String::op_Equality(v728.name, v54);\n\tv1367 = v883 == 0;\n\tv867 = ~v1367;\n\tif (v867) goto L_035E;\n\tv665 = v331.Length;\n\tv516 = v516 + 1;\n\tv1312 = v516 < v331.Length;\n\tif (v1312) goto L_02BD;\nL_02E3:\n\tv332 = HutongGames.PlayMaker.FsmVariables::get_EnumVariables(this);\n\tv666 = v332.Length;\n\tv1349 = v332.Length < 1;\n\tif (v1349) goto L_031B;\nL_02F5:\n\tv1376 = v517 < v666;\n\tv651 = ~v1376;\n\tif (v651) goto L_035F;\n\tv729 = v332[v517 @ X23_v21 (System.Int32)];\n\tv884 = System.String::op_Equality(v729.name, v54);\n\tv1384 = v884 == 0;\n\tv868 = ~v1384;\n\tif (v868) goto L_035E;\n\tv666 = v332.Length;\n\tv517 = v517 + 1;\n\tv1353 = v517 < v332.Length;\n\tif (v1353) goto L_02F5;\nL_031B:\n\tv333 = HutongGames.PlayMaker.FsmVariables::get_ArrayVariables(this);\n\tv667 = v333.Length;\n\tv837 = v333.Length < 1;\n\tif (v837) goto L_FFFFFFFF;\nL_032D:\n\tv1393 = v684 < v667;\n\tv652 = ~v1393;\n\tif (v652) goto L_035F;\n\tv730 = v333[v684 @ X22_v21 (System.Int32)];\n\tv885 = System.String::op_Equality(v730.name, v54);\n\tv1398 = v885 == 0;\n\tv869 = ~v1398;\n\tif (v869) goto L_035E;\n\tv667 = v333.Length;\n\tv684 = v684 + 1;\n\tv838 = v684 < v333.Length;\n\tif (v838) goto L_032D;\n\tgoto L_035E;\nL_035E:\n\treturn v833;\nL_035F:\n\tv701 = new System.IndexOutOfRangeException();\n\tthrow v701;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 624 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public NamedVariable FindVariable(string name)
		{
			FsmFloat[] array = FloatVariables;
			int num = array.Length;
			if (array.Length < 1)
			{
				goto IL_00e1;
			}
			int num2 = 0;
			string text = default(string);
			NamedVariable result;
			while (num2 < num)
			{
				FsmFloat fsmFloat = array[num2];
				bool flag = fsmFloat.Name == text;
				bool flag2 = !flag;
				bool flag3 = !flag2;
				result = array[num2];
				if (!flag3)
				{
					num = array.Length;
					num2++;
					if (num2 < array.Length)
					{
						continue;
					}
					goto IL_00e1;
				}
				goto IL_0d5f;
			}
			goto IL_0d51;
			IL_0a98:
			FsmQuaternion[] array2 = QuaternionVariables;
			int num3 = array2.Length;
			if (array2.Length < 1)
			{
				goto IL_0b7a;
			}
			int num4 = 0;
			while (num4 < num3)
			{
				FsmQuaternion fsmQuaternion = array2[num4];
				bool flag4 = fsmQuaternion.Name == text;
				bool flag5 = !flag4;
				bool flag6 = !flag5;
				result = array2[num4];
				if (!flag6)
				{
					num3 = array2.Length;
					num4++;
					if (num4 < array2.Length)
					{
						continue;
					}
					goto IL_0b7a;
				}
				goto IL_0d5f;
			}
			goto IL_0d51;
			IL_09b6:
			FsmGameObject[] array3 = GameObjectVariables;
			int num5 = array3.Length;
			if (array3.Length < 1)
			{
				goto IL_0a98;
			}
			int num6 = 0;
			while (num6 < num5)
			{
				FsmGameObject fsmGameObject = array3[num6];
				bool flag7 = fsmGameObject.Name == text;
				bool flag8 = !flag7;
				bool flag9 = !flag8;
				result = array3[num6];
				if (!flag9)
				{
					num5 = array3.Length;
					num6++;
					if (num6 < array3.Length)
					{
						continue;
					}
					goto IL_0a98;
				}
				goto IL_0d5f;
			}
			goto IL_0d51;
			IL_0b7a:
			FsmEnum[] array4 = EnumVariables;
			int num7 = array4.Length;
			if (array4.Length < 1)
			{
				goto IL_0c5c;
			}
			int num8 = 0;
			while (num8 < num7)
			{
				FsmEnum fsmEnum = array4[num8];
				bool flag10 = fsmEnum.Name == text;
				bool flag11 = !flag10;
				bool flag12 = !flag11;
				result = array4[num8];
				if (!flag12)
				{
					num7 = array4.Length;
					num8++;
					if (num8 < array4.Length)
					{
						continue;
					}
					goto IL_0c5c;
				}
				goto IL_0d5f;
			}
			goto IL_0d51;
			IL_07f2:
			FsmTexture[] array5 = TextureVariables;
			int num9 = array5.Length;
			if (array5.Length < 1)
			{
				goto IL_08d4;
			}
			int num10 = 0;
			while (num10 < num9)
			{
				FsmTexture fsmTexture = array5[num10];
				bool flag13 = fsmTexture.Name == text;
				bool flag14 = !flag13;
				bool flag15 = !flag14;
				result = array5[num10];
				if (!flag15)
				{
					num9 = array5.Length;
					num10++;
					if (num10 < array5.Length)
					{
						continue;
					}
					goto IL_08d4;
				}
				goto IL_0d5f;
			}
			goto IL_0d51;
			IL_00e1:
			FsmInt[] array6 = IntVariables;
			int num11 = array6.Length;
			if (array6.Length < 1)
			{
				goto IL_01c4;
			}
			int num12 = 0;
			while (num12 < num11)
			{
				FsmInt fsmInt = array6[num12];
				bool flag16 = fsmInt.Name == text;
				bool flag17 = !flag16;
				bool flag18 = !flag17;
				result = array6[num12];
				if (!flag18)
				{
					num11 = array6.Length;
					num12++;
					if (num12 < array6.Length)
					{
						continue;
					}
					goto IL_01c4;
				}
				goto IL_0d5f;
			}
			goto IL_0d51;
			IL_0d5f:
			return result;
			IL_0388:
			FsmVector3[] array7 = Vector3Variables;
			int num13 = array7.Length;
			if (array7.Length < 1)
			{
				goto IL_046a;
			}
			int num14 = 0;
			while (num14 < num13)
			{
				FsmVector3 fsmVector = array7[num14];
				bool flag19 = fsmVector.Name == text;
				bool flag20 = !flag19;
				bool flag21 = !flag20;
				result = array7[num14];
				if (!flag21)
				{
					num13 = array7.Length;
					num14++;
					if (num14 < array7.Length)
					{
						continue;
					}
					goto IL_046a;
				}
				goto IL_0d5f;
			}
			goto IL_0d51;
			IL_054c:
			FsmRect[] array8 = RectVariables;
			int num15 = array8.Length;
			if (array8.Length < 1)
			{
				goto IL_062e;
			}
			int num16 = 0;
			while (num16 < num15)
			{
				FsmRect fsmRect = array8[num16];
				bool flag22 = fsmRect.Name == text;
				bool flag23 = !flag22;
				bool flag24 = !flag23;
				result = array8[num16];
				if (!flag24)
				{
					num15 = array8.Length;
					num16++;
					if (num16 < array8.Length)
					{
						continue;
					}
					goto IL_062e;
				}
				goto IL_0d5f;
			}
			goto IL_0d51;
			IL_08d4:
			FsmObject[] array9 = ObjectVariables;
			int num17 = array9.Length;
			if (array9.Length < 1)
			{
				goto IL_09b6;
			}
			int num18 = 0;
			while (num18 < num17)
			{
				FsmObject fsmObject = array9[num18];
				bool flag25 = fsmObject.Name == text;
				bool flag26 = !flag25;
				bool flag27 = !flag26;
				result = array9[num18];
				if (!flag27)
				{
					num17 = array9.Length;
					num18++;
					if (num18 < array9.Length)
					{
						continue;
					}
					goto IL_09b6;
				}
				goto IL_0d5f;
			}
			goto IL_0d51;
			IL_01c4:
			FsmBool[] array10 = BoolVariables;
			int num19 = array10.Length;
			if (array10.Length < 1)
			{
				goto IL_02a6;
			}
			int num20 = 0;
			while (num20 < num19)
			{
				FsmBool fsmBool = array10[num20];
				bool flag28 = fsmBool.Name == text;
				bool flag29 = !flag28;
				bool flag30 = !flag29;
				result = array10[num20];
				if (!flag30)
				{
					num19 = array10.Length;
					num20++;
					if (num20 < array10.Length)
					{
						continue;
					}
					goto IL_02a6;
				}
				goto IL_0d5f;
			}
			goto IL_0d51;
			IL_046a:
			FsmString[] array11 = StringVariables;
			int num21 = array11.Length;
			if (array11.Length < 1)
			{
				goto IL_054c;
			}
			int num22 = 0;
			while (num22 < num21)
			{
				FsmString fsmString = array11[num22];
				bool flag31 = fsmString.Name == text;
				bool flag32 = !flag31;
				bool flag33 = !flag32;
				result = array11[num22];
				if (!flag33)
				{
					num21 = array11.Length;
					num22++;
					if (num22 < array11.Length)
					{
						continue;
					}
					goto IL_054c;
				}
				goto IL_0d5f;
			}
			goto IL_0d51;
			IL_0c5c:
			FsmArray[] array12 = ArrayVariables;
			int num23 = array12.Length;
			if (array12.Length >= 1)
			{
				int num24 = 0;
				while (num24 < num23)
				{
					FsmArray fsmArray = array12[num24];
					bool flag34 = fsmArray.Name == text;
					bool flag35 = !flag34;
					bool flag36 = !flag35;
					result = array12[num24];
					if (!flag36)
					{
						num23 = array12.Length;
						num24++;
						if (num24 < array12.Length)
						{
							continue;
						}
						result = null;
					}
					goto IL_0d5f;
				}
				goto IL_0d51;
			}
			result = null;
			goto IL_0d5f;
			IL_0d51:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_062e:
			FsmColor[] array13 = ColorVariables;
			int num25 = array13.Length;
			if (array13.Length < 1)
			{
				goto IL_0710;
			}
			int num26 = 0;
			while (num26 < num25)
			{
				FsmColor fsmColor = array13[num26];
				bool flag37 = fsmColor.Name == text;
				bool flag38 = !flag37;
				bool flag39 = !flag38;
				result = array13[num26];
				if (!flag39)
				{
					num25 = array13.Length;
					num26++;
					if (num26 < array13.Length)
					{
						continue;
					}
					goto IL_0710;
				}
				goto IL_0d5f;
			}
			goto IL_0d51;
			IL_02a6:
			FsmVector2[] array14 = Vector2Variables;
			int num27 = array14.Length;
			if (array14.Length < 1)
			{
				goto IL_0388;
			}
			int num28 = 0;
			while (num28 < num27)
			{
				FsmVector2 fsmVector2 = array14[num28];
				bool flag40 = fsmVector2.Name == text;
				bool flag41 = !flag40;
				bool flag42 = !flag41;
				result = array14[num28];
				if (!flag42)
				{
					num27 = array14.Length;
					num28++;
					if (num28 < array14.Length)
					{
						continue;
					}
					goto IL_0388;
				}
				goto IL_0d5f;
			}
			goto IL_0d51;
			IL_0710:
			FsmMaterial[] array15 = MaterialVariables;
			int num29 = array15.Length;
			if (array15.Length < 1)
			{
				goto IL_07f2;
			}
			int num30 = 0;
			while (num30 < num29)
			{
				FsmMaterial fsmMaterial = array15[num30];
				bool flag43 = fsmMaterial.Name == text;
				bool flag44 = !flag43;
				bool flag45 = !flag44;
				result = array15[num30];
				if (!flag45)
				{
					num29 = array15.Length;
					num30++;
					if (num30 < array15.Length)
					{
						continue;
					}
					goto IL_07f2;
				}
				goto IL_0d5f;
			}
			goto IL_0d51;
		}

		[Token(Token = "0x600063E")]
		[Address(RVA = "0xE504B8", Offset = "0xE504B8", Length = "0x674")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv25 = *([1F06FC0]);\n\tv26 = *([v25 @ X8_v14]);\n\tv27 = \"il2cpp_codegen_initialize_method\"(v26, type, name, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20247A0]) = v43;\nL_0017:\n\tv44 = type + 1;\n\tv45 = v44 < 0xF;\n\tv46 = ~v45;\n\tv47 = v44 - 0xF;\n\tv49 = v47 == 0;\n\tv54 = ~v49;\n\tv55 = v46 & v54;\n\tif (v55) goto L_03A3;\n\tv57 = 0x181C000 + 0x754;\n\tv60 = *([v57 @ X9_v2 (System.Int32)+v44 @ X8_v3 (System.Int32)*4]) + v57;\n\t// 41 IndirectJump v60 @ X8_v11, v41 @ X0_v1 (HutongGames.PlayMaker.FsmVariables), v41 @ X0_v1 (HutongGames.PlayMaker.FsmVariables), type @ X1 (HutongGames.PlayMaker.VariableType), name @ X2 (System.String), methodInfo @ X3 (Il2CppMethodInfo), v29 @ X4, v30 @ X5, v31 @ X6, v32 @ X7, v33 @ V0, v34 @ V1, v35 @ V2, v36 @ V3, v37 @ V4, v38 @ V5, v39 @ V6, v40 @ V7\n\tX0 = X21;\n\tX0 = HutongGames.PlayMaker.FsmVariables::get_FloatVariables(X0, X1);\n\tX21 = X0;\n\tif (TEMP) goto L_039F;\n\tX8 = *([X21+18]);\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_0390;\n\tX22 = 0;\nL_003D:\n\tC = X22 < X8;\n\tC = ~C;\n\tTEMP1 = X22 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X8;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_039A;\n\tTEMPSHIFT = X22 << 3;\n\tX8 = X21 + TEMPSHIFT;\n\tX20 = *([X8+20]);\n\tif (TEMP) goto L_039E;\n\tX0 = *([X20+18]);\n\tX1 = X19;\n\tX2 = 0;\n\tX0 = System.String::op_Equality(X0, X1, X2);\n\tTEMP = X0 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0391;\n\tX8 = *([X21+18]);\n\tX22 = X22 + 1;\n\tX20 = 0;\n\tC = X22 < X8;\n\tC = ~C;\n\tTEMP1 = X22 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X8;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_003D;\n\tgoto L_0391;\n\tX0 = X21;\n\tX0 = HutongGames.PlayMaker.FsmVariables::get_IntVariables(X0, X1);\n\tX21 = X0;\n\tif (TEMP) goto L_039F;\n\tX8 = *([X21+18]);\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_0390;\n\tX22 = 0;\nL_0077:\n\tC = X22 < X8;\n\tC = ~C;\n\tTEMP1 = X22 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X8;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_039A;\n\tTEMPSHIFT = X22 << 3;\n\tX8 = X21 + TEMPSHIFT;\n\tX20 = *([X8+20]);\n\tif (TEMP) goto L_039E;\n\tX0 = *([X20+18]);\n\tX1 = X19;\n\tX2 = 0;\n\tX0 = System.String::op_Equality(X0, X1, X2);\n\tTEMP = X0 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0391;\n\tX8 = *([X21+18]);\n\tX22 = X22 + 1;\n\tX20 = 0;\n\tC = X22 < X8;\n\tC = ~C;\n\tTEMP1 = X22 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X8;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_0077;\n\tgoto L_0391;\n\tX0 = X21;\n\tX0 = HutongGames.PlayMaker.FsmVariables::get_BoolVariables(X0, X1);\n\tX21 = X0;\n\tif (TEMP) goto L_039F;\n\tX8 = *([X21+18]);\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_0390;\n\tX22 = 0;\nL_00B1:\n\tC = X22 < X8;\n\tC = ~C;\n\tTEMP1 = X22 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X8;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_039A;\n\tTEMPSHIFT = X22 << 3;\n\tX8 = X21 + TEMPSHIFT;\n\tX20 = *([X8+20]);\n\tif (TEMP) goto L_039E;\n\tX0 = *([X20+18]);\n\tX1 = X19;\n\tX2 = 0;\n\tX0 = System.String::op_Equality(X0, X1, X2);\n\tTEMP = X0 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0391;\n\tX8 = *([X21+18]);\n\tX22 = X22 + 1;\n\tX20 = 0;\n\tC = X22 < X8;\n\tC = ~C;\n\tTEMP1 = X22 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X8;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_00B1;\n\tgoto L_0391;\n\tX0 = X21;\n\tX0 = HutongGames.PlayMaker.FsmVariables::get_GameObjectVariables(X0, X1);\n\tX21 = X0;\n\tif (TEMP) goto L_039F;\n\tX8 = *([X21+18]);\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_0390;\n\tX22 = 0;\nL_00EB:\n\tC = X22 < X8;\n\tC = ~C;\n\tTEMP1 = X22 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X8;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_039A;\n\tTEMPSHIFT = X22 << 3;\n\tX8 = X21 + TEMPSHIFT;\n\tX20 = *([X8+20]);\n\tif (TEMP) goto L_039E;\n\tX0 = *([X20+18]);\n\tX1 = X19;\n\tX2 = 0;\n\tX0 = System.String::op_Equality(X0, X1, X2);\n\tTEMP = X0 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0391;\n\tX8 = *([X21+18]);\n\tX22 = X22 + 1;\n\tX20 = 0;\n\tC = X22 < X8;\n\tC = ~C;\n\tTEMP1 = X22 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X8;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_00EB;\n\tgoto L_0391;\n\tX0 = X21;\n\tX0 = HutongGames.PlayMaker.FsmVariables::get_StringVariables(X0, X1);\n\tX21 = X0;\n\tif (TEMP) goto L_039F;\n\tX8 = *([X21+18]);\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_0390;\n\tX22 = 0;\nL_0125:\n\tC = X22 < X8;\n\tC = ~C;\n\tTEMP1 = X22 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X8;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_039A;\n\tTEMPSHIFT = X22 << 3;\n\tX8 = X21 + TEMPSHIFT;\n\tX20 = *([X8+20]);\n\tif (TEMP) goto L_039E;\n\tX0 = *([X20+18]);\n\tX1 = X19;\n\tX2 = 0;\n\tX0 = System.String::op_Equality(X0, X1, X2);\n\tTEMP = X0 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0391;\n\tX8 = *([X21+18]);\n\tX22 = X22 + 1;\n\tX20 = 0;\n\tC = X22 < X8;\n\tC = ~C;\n\tTEMP1 = X22 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X8;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_0125;\n\tgoto L_0391;\n\tX0 = X21;\n\tX0 = HutongGames.PlayMaker.FsmVariables::get_Vector2Variables(X0, X1);\n\tX21 = X0;\n\tif (TEMP) goto L_039F;\n\tX8 = *([X21+18]);\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_0390;\n\tX22 = 0;\nL_015F:\n\tC = X22 < X8;\n\tC = ~C;\n\tTEMP1 = X22 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X8;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_039A;\n\tTEMPSHIFT = X22 << 3;\n\tX8 = X21 + TEMPSHIFT;\n\tX20 = *([X8+20]);\n\tif (TEMP) goto L_039E;\n\tX0 = *([X20+18]);\n\tX1 = X19;\n\tX2 = 0;\n\tX0 = System.String::op_Equality(X0, X1, X2);\n\tTEMP = X0 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0391;\n\tX8 = *([X21+18]);\n\tX22 = X22 + 1;\n\tX20 = 0;\n\tC = X22 < X8;\n\tC = ~C;\n\tTEMP1 = X22 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X8;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_015F;\n\tgoto L_0391;\n\tX0 = X21;\n\tX0 = HutongGames.PlayMaker.FsmVariables::get_Vector3Variables(X0, X1);\n\tX21 = X0;\n\tif (TEMP) goto L_039F;\n\tX8 = *([X21+18]);\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_0390;\n\tX22 = 0;\nL_0199:\n\tC = X22 < X8;\n\tC = ~C;\n\tTEMP1 = X22 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X8;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_039A;\n\tTEMPSHIFT = X22 << 3;\n\tX8 = X21 + TEMPSHIFT;\n\tX20 = *([X8+20]);\n\tif (TEMP) goto L_039E;\n\tX0 = *([X20+18]);\n\tX1 = X19;\n\tX2 = 0;\n\tX0 = System.String::op_Equality(X0, X1, X2);\n\tTEMP = X0 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0391;\n\tX8 = *([X21+18]);\n\tX22 = X22 + 1;\n\tX20 = 0;\n\tC = X22 < X8;\n\tC = ~C;\n\tTEMP1 = X22 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X8;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_0199;\n\tgoto L_0391;\n\tX0 = X21;\n\tX0 = HutongGames.PlayMaker.FsmVariables::get_ColorVariables(X0, X1);\n\tX21 = X0;\n\tif (TEMP) goto L_039F;\n\tX8 = *([X21+18]);\n\tC = X8 < 1;\n\t\n// ... truncated")]
		public NamedVariable FindVariable(VariableType type, string name)
		{
			//IL_0029: Expected O, but got I
			int num = (int)(type + 1);
			bool flag = num < 15;
			bool flag2 = !flag;
			int num2 = num - 15;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = 25280512 + 1876;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ X9_v2 (System.Int32)+v44 @ X8_v3 (System.Int32)*4]");
				object obj = 0L + (long)num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v60 @ X8_v11 (should have been resolved before IL gen)");
			}
			ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("type");
			throw ex;
		}

		[Token(Token = "0x600063F")]
		[Address(RVA = "0xE4E424", Offset = "0xE4E424", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = HutongGames.PlayMaker.FsmVariables::get_FloatVariables(this);\n\tv140 = v16.Length;\n\tv31 = v16.Length < 1;\n\tif (v31) goto L_FFFFFFFF;\nL_001B:\n\tv143 = v43 < v140;\n\tv69 = ~v143;\n\tif (v69) goto L_004A;\n\tv98 = v16[v43 @ X22_v6 (System.Int32)];\n\tv126 = System.String::op_Equality(v98.name, name);\n\tv198 = v126 == 0;\n\tv124 = ~v198;\n\tif (v124) goto L_0049;\n\tv140 = v16.Length;\n\tv43 = v43 + 1;\n\tv104 = v43 < v16.Length;\n\tif (v104) goto L_001B;\nL_0049:\n\treturn v146;\nL_004A:\n\tv191 = new System.IndexOutOfRangeException();\n\tthrow v191;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmFloat FindFsmFloat(string name)
		{
			FsmFloat[] array = FloatVariables;
			int num = array.Length;
			if (array.Length < 1)
			{
				goto IL_00e1;
			}
			int num2 = 0;
			FsmFloat result;
			while (true)
			{
				if (num2 < num)
				{
					FsmFloat fsmFloat = array[num2];
					bool flag = fsmFloat.Name == name;
					bool flag2 = !flag;
					bool flag3 = !flag2;
					result = array[num2];
					if (flag3)
					{
						break;
					}
					num = array.Length;
					num2++;
					if (num2 < array.Length)
					{
						continue;
					}
					goto IL_00e1;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			goto IL_00f9;
			IL_00e1:
			result = null;
			goto IL_00f9;
			IL_00f9:
			return result;
		}

		[Token(Token = "0x6000640")]
		[Address(RVA = "0xE4E71C", Offset = "0xE4E71C", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = HutongGames.PlayMaker.FsmVariables::get_ObjectVariables(this);\n\tv140 = v16.Length;\n\tv31 = v16.Length < 1;\n\tif (v31) goto L_FFFFFFFF;\nL_001B:\n\tv143 = v43 < v140;\n\tv69 = ~v143;\n\tif (v69) goto L_004A;\n\tv98 = v16[v43 @ X22_v6 (System.Int32)];\n\tv126 = System.String::op_Equality(v98.name, name);\n\tv198 = v126 == 0;\n\tv124 = ~v198;\n\tif (v124) goto L_0049;\n\tv140 = v16.Length;\n\tv43 = v43 + 1;\n\tv104 = v43 < v16.Length;\n\tif (v104) goto L_001B;\nL_0049:\n\treturn v146;\nL_004A:\n\tv191 = new System.IndexOutOfRangeException();\n\tthrow v191;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmObject FindFsmObject(string name)
		{
			FsmObject[] array = ObjectVariables;
			int num = array.Length;
			if (array.Length < 1)
			{
				goto IL_00e1;
			}
			int num2 = 0;
			FsmObject result;
			while (true)
			{
				if (num2 < num)
				{
					FsmObject fsmObject = array[num2];
					bool flag = fsmObject.Name == name;
					bool flag2 = !flag;
					bool flag3 = !flag2;
					result = array[num2];
					if (flag3)
					{
						break;
					}
					num = array.Length;
					num2++;
					if (num2 < array.Length)
					{
						continue;
					}
					goto IL_00e1;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			goto IL_00f9;
			IL_00e1:
			result = null;
			goto IL_00f9;
			IL_00f9:
			return result;
		}

		[Token(Token = "0x6000641")]
		[Address(RVA = "0xE4E7B4", Offset = "0xE4E7B4", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = HutongGames.PlayMaker.FsmVariables::get_MaterialVariables(this);\n\tv140 = v16.Length;\n\tv31 = v16.Length < 1;\n\tif (v31) goto L_FFFFFFFF;\nL_001B:\n\tv143 = v43 < v140;\n\tv69 = ~v143;\n\tif (v69) goto L_004A;\n\tv98 = v16[v43 @ X22_v6 (System.Int32)];\n\tv126 = System.String::op_Equality(v98.name, name);\n\tv198 = v126 == 0;\n\tv124 = ~v198;\n\tif (v124) goto L_0049;\n\tv140 = v16.Length;\n\tv43 = v43 + 1;\n\tv104 = v43 < v16.Length;\n\tif (v104) goto L_001B;\nL_0049:\n\treturn v146;\nL_004A:\n\tv191 = new System.IndexOutOfRangeException();\n\tthrow v191;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmMaterial FindFsmMaterial(string name)
		{
			FsmMaterial[] array = MaterialVariables;
			int num = array.Length;
			if (array.Length < 1)
			{
				goto IL_00e1;
			}
			int num2 = 0;
			FsmMaterial result;
			while (true)
			{
				if (num2 < num)
				{
					FsmMaterial fsmMaterial = array[num2];
					bool flag = fsmMaterial.Name == name;
					bool flag2 = !flag;
					bool flag3 = !flag2;
					result = array[num2];
					if (flag3)
					{
						break;
					}
					num = array.Length;
					num2++;
					if (num2 < array.Length)
					{
						continue;
					}
					goto IL_00e1;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			goto IL_00f9;
			IL_00e1:
			result = null;
			goto IL_00f9;
			IL_00f9:
			return result;
		}

		[Token(Token = "0x6000642")]
		[Address(RVA = "0xE4E84C", Offset = "0xE4E84C", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = HutongGames.PlayMaker.FsmVariables::get_TextureVariables(this);\n\tv140 = v16.Length;\n\tv31 = v16.Length < 1;\n\tif (v31) goto L_FFFFFFFF;\nL_001B:\n\tv143 = v43 < v140;\n\tv69 = ~v143;\n\tif (v69) goto L_004A;\n\tv98 = v16[v43 @ X22_v6 (System.Int32)];\n\tv126 = System.String::op_Equality(v98.name, name);\n\tv198 = v126 == 0;\n\tv124 = ~v198;\n\tif (v124) goto L_0049;\n\tv140 = v16.Length;\n\tv43 = v43 + 1;\n\tv104 = v43 < v16.Length;\n\tif (v104) goto L_001B;\nL_0049:\n\treturn v146;\nL_004A:\n\tv191 = new System.IndexOutOfRangeException();\n\tthrow v191;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmTexture FindFsmTexture(string name)
		{
			FsmTexture[] array = TextureVariables;
			int num = array.Length;
			if (array.Length < 1)
			{
				goto IL_00e1;
			}
			int num2 = 0;
			FsmTexture result;
			while (true)
			{
				if (num2 < num)
				{
					FsmTexture fsmTexture = array[num2];
					bool flag = fsmTexture.Name == name;
					bool flag2 = !flag;
					bool flag3 = !flag2;
					result = array[num2];
					if (flag3)
					{
						break;
					}
					num = array.Length;
					num2++;
					if (num2 < array.Length)
					{
						continue;
					}
					goto IL_00e1;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			goto IL_00f9;
			IL_00e1:
			result = null;
			goto IL_00f9;
			IL_00f9:
			return result;
		}

		[Token(Token = "0x6000643")]
		[Address(RVA = "0xE4E4BC", Offset = "0xE4E4BC", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = HutongGames.PlayMaker.FsmVariables::get_IntVariables(this);\n\tv140 = v16.Length;\n\tv31 = v16.Length < 1;\n\tif (v31) goto L_FFFFFFFF;\nL_001B:\n\tv143 = v43 < v140;\n\tv69 = ~v143;\n\tif (v69) goto L_004A;\n\tv98 = v16[v43 @ X22_v6 (System.Int32)];\n\tv126 = System.String::op_Equality(v98.name, name);\n\tv198 = v126 == 0;\n\tv124 = ~v198;\n\tif (v124) goto L_0049;\n\tv140 = v16.Length;\n\tv43 = v43 + 1;\n\tv104 = v43 < v16.Length;\n\tif (v104) goto L_001B;\nL_0049:\n\treturn v146;\nL_004A:\n\tv191 = new System.IndexOutOfRangeException();\n\tthrow v191;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmInt FindFsmInt(string name)
		{
			FsmInt[] array = IntVariables;
			int num = array.Length;
			if (array.Length < 1)
			{
				goto IL_00e1;
			}
			int num2 = 0;
			FsmInt result;
			while (true)
			{
				if (num2 < num)
				{
					FsmInt fsmInt = array[num2];
					bool flag = fsmInt.Name == name;
					bool flag2 = !flag;
					bool flag3 = !flag2;
					result = array[num2];
					if (flag3)
					{
						break;
					}
					num = array.Length;
					num2++;
					if (num2 < array.Length)
					{
						continue;
					}
					goto IL_00e1;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			goto IL_00f9;
			IL_00e1:
			result = null;
			goto IL_00f9;
			IL_00f9:
			return result;
		}

		[Token(Token = "0x6000644")]
		[Address(RVA = "0xE4E554", Offset = "0xE4E554", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = HutongGames.PlayMaker.FsmVariables::get_BoolVariables(this);\n\tv140 = v16.Length;\n\tv31 = v16.Length < 1;\n\tif (v31) goto L_FFFFFFFF;\nL_001B:\n\tv143 = v43 < v140;\n\tv69 = ~v143;\n\tif (v69) goto L_004A;\n\tv98 = v16[v43 @ X22_v6 (System.Int32)];\n\tv126 = System.String::op_Equality(v98.name, name);\n\tv198 = v126 == 0;\n\tv124 = ~v198;\n\tif (v124) goto L_0049;\n\tv140 = v16.Length;\n\tv43 = v43 + 1;\n\tv104 = v43 < v16.Length;\n\tif (v104) goto L_001B;\nL_0049:\n\treturn v146;\nL_004A:\n\tv191 = new System.IndexOutOfRangeException();\n\tthrow v191;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmBool FindFsmBool(string name)
		{
			FsmBool[] array = BoolVariables;
			int num = array.Length;
			if (array.Length < 1)
			{
				goto IL_00e1;
			}
			int num2 = 0;
			FsmBool result;
			while (true)
			{
				if (num2 < num)
				{
					FsmBool fsmBool = array[num2];
					bool flag = fsmBool.Name == name;
					bool flag2 = !flag;
					bool flag3 = !flag2;
					result = array[num2];
					if (flag3)
					{
						break;
					}
					num = array.Length;
					num2++;
					if (num2 < array.Length)
					{
						continue;
					}
					goto IL_00e1;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			goto IL_00f9;
			IL_00e1:
			result = null;
			goto IL_00f9;
			IL_00f9:
			return result;
		}

		[Token(Token = "0x6000645")]
		[Address(RVA = "0xE4E8E4", Offset = "0xE4E8E4", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = HutongGames.PlayMaker.FsmVariables::get_StringVariables(this);\n\tv140 = v16.Length;\n\tv31 = v16.Length < 1;\n\tif (v31) goto L_FFFFFFFF;\nL_001B:\n\tv143 = v43 < v140;\n\tv69 = ~v143;\n\tif (v69) goto L_004A;\n\tv98 = v16[v43 @ X22_v6 (System.Int32)];\n\tv126 = System.String::op_Equality(v98.name, name);\n\tv198 = v126 == 0;\n\tv124 = ~v198;\n\tif (v124) goto L_0049;\n\tv140 = v16.Length;\n\tv43 = v43 + 1;\n\tv104 = v43 < v16.Length;\n\tif (v104) goto L_001B;\nL_0049:\n\treturn v146;\nL_004A:\n\tv191 = new System.IndexOutOfRangeException();\n\tthrow v191;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmString FindFsmString(string name)
		{
			FsmString[] array = StringVariables;
			int num = array.Length;
			if (array.Length < 1)
			{
				goto IL_00e1;
			}
			int num2 = 0;
			FsmString result;
			while (true)
			{
				if (num2 < num)
				{
					FsmString fsmString = array[num2];
					bool flag = fsmString.Name == name;
					bool flag2 = !flag;
					bool flag3 = !flag2;
					result = array[num2];
					if (flag3)
					{
						break;
					}
					num = array.Length;
					num2++;
					if (num2 < array.Length)
					{
						continue;
					}
					goto IL_00e1;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			goto IL_00f9;
			IL_00e1:
			result = null;
			goto IL_00f9;
			IL_00f9:
			return result;
		}

		[Token(Token = "0x6000646")]
		[Address(RVA = "0xE50B2C", Offset = "0xE50B2C", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = HutongGames.PlayMaker.FsmVariables::get_Vector2Variables(this);\n\tv140 = v16.Length;\n\tv31 = v16.Length < 1;\n\tif (v31) goto L_FFFFFFFF;\nL_001B:\n\tv143 = v43 < v140;\n\tv69 = ~v143;\n\tif (v69) goto L_004A;\n\tv98 = v16[v43 @ X22_v6 (System.Int32)];\n\tv126 = System.String::op_Equality(v98.name, name);\n\tv198 = v126 == 0;\n\tv124 = ~v198;\n\tif (v124) goto L_0049;\n\tv140 = v16.Length;\n\tv43 = v43 + 1;\n\tv104 = v43 < v16.Length;\n\tif (v104) goto L_001B;\nL_0049:\n\treturn v146;\nL_004A:\n\tv191 = new System.IndexOutOfRangeException();\n\tthrow v191;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmVector2 FindFsmVector2(string name)
		{
			FsmVector2[] array = Vector2Variables;
			int num = array.Length;
			if (array.Length < 1)
			{
				goto IL_00e1;
			}
			int num2 = 0;
			FsmVector2 result;
			while (true)
			{
				if (num2 < num)
				{
					FsmVector2 fsmVector = array[num2];
					bool flag = fsmVector.Name == name;
					bool flag2 = !flag;
					bool flag3 = !flag2;
					result = array[num2];
					if (flag3)
					{
						break;
					}
					num = array.Length;
					num2++;
					if (num2 < array.Length)
					{
						continue;
					}
					goto IL_00e1;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			goto IL_00f9;
			IL_00e1:
			result = null;
			goto IL_00f9;
			IL_00f9:
			return result;
		}

		[Token(Token = "0x6000647")]
		[Address(RVA = "0xE50BC4", Offset = "0xE50BC4", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = HutongGames.PlayMaker.FsmVariables::get_Vector3Variables(this);\n\tv140 = v16.Length;\n\tv31 = v16.Length < 1;\n\tif (v31) goto L_FFFFFFFF;\nL_001B:\n\tv143 = v43 < v140;\n\tv69 = ~v143;\n\tif (v69) goto L_004A;\n\tv98 = v16[v43 @ X22_v6 (System.Int32)];\n\tv126 = System.String::op_Equality(v98.name, name);\n\tv198 = v126 == 0;\n\tv124 = ~v198;\n\tif (v124) goto L_0049;\n\tv140 = v16.Length;\n\tv43 = v43 + 1;\n\tv104 = v43 < v16.Length;\n\tif (v104) goto L_001B;\nL_0049:\n\treturn v146;\nL_004A:\n\tv191 = new System.IndexOutOfRangeException();\n\tthrow v191;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmVector3 FindFsmVector3(string name)
		{
			FsmVector3[] array = Vector3Variables;
			int num = array.Length;
			if (array.Length < 1)
			{
				goto IL_00e1;
			}
			int num2 = 0;
			FsmVector3 result;
			while (true)
			{
				if (num2 < num)
				{
					FsmVector3 fsmVector = array[num2];
					bool flag = fsmVector.Name == name;
					bool flag2 = !flag;
					bool flag3 = !flag2;
					result = array[num2];
					if (flag3)
					{
						break;
					}
					num = array.Length;
					num2++;
					if (num2 < array.Length)
					{
						continue;
					}
					goto IL_00e1;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			goto IL_00f9;
			IL_00e1:
			result = null;
			goto IL_00f9;
			IL_00f9:
			return result;
		}

		[Token(Token = "0x6000648")]
		[Address(RVA = "0xE4E5EC", Offset = "0xE4E5EC", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = HutongGames.PlayMaker.FsmVariables::get_RectVariables(this);\n\tv140 = v16.Length;\n\tv31 = v16.Length < 1;\n\tif (v31) goto L_FFFFFFFF;\nL_001B:\n\tv143 = v43 < v140;\n\tv69 = ~v143;\n\tif (v69) goto L_004A;\n\tv98 = v16[v43 @ X22_v6 (System.Int32)];\n\tv126 = System.String::op_Equality(v98.name, name);\n\tv198 = v126 == 0;\n\tv124 = ~v198;\n\tif (v124) goto L_0049;\n\tv140 = v16.Length;\n\tv43 = v43 + 1;\n\tv104 = v43 < v16.Length;\n\tif (v104) goto L_001B;\nL_0049:\n\treturn v146;\nL_004A:\n\tv191 = new System.IndexOutOfRangeException();\n\tthrow v191;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmRect FindFsmRect(string name)
		{
			FsmRect[] array = RectVariables;
			int num = array.Length;
			if (array.Length < 1)
			{
				goto IL_00e1;
			}
			int num2 = 0;
			FsmRect result;
			while (true)
			{
				if (num2 < num)
				{
					FsmRect fsmRect = array[num2];
					bool flag = fsmRect.Name == name;
					bool flag2 = !flag;
					bool flag3 = !flag2;
					result = array[num2];
					if (flag3)
					{
						break;
					}
					num = array.Length;
					num2++;
					if (num2 < array.Length)
					{
						continue;
					}
					goto IL_00e1;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			goto IL_00f9;
			IL_00e1:
			result = null;
			goto IL_00f9;
			IL_00f9:
			return result;
		}

		[Token(Token = "0x6000649")]
		[Address(RVA = "0xE4E684", Offset = "0xE4E684", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = HutongGames.PlayMaker.FsmVariables::get_QuaternionVariables(this);\n\tv140 = v16.Length;\n\tv31 = v16.Length < 1;\n\tif (v31) goto L_FFFFFFFF;\nL_001B:\n\tv143 = v43 < v140;\n\tv69 = ~v143;\n\tif (v69) goto L_004A;\n\tv98 = v16[v43 @ X22_v6 (System.Int32)];\n\tv126 = System.String::op_Equality(v98.name, name);\n\tv198 = v126 == 0;\n\tv124 = ~v198;\n\tif (v124) goto L_0049;\n\tv140 = v16.Length;\n\tv43 = v43 + 1;\n\tv104 = v43 < v16.Length;\n\tif (v104) goto L_001B;\nL_0049:\n\treturn v146;\nL_004A:\n\tv191 = new System.IndexOutOfRangeException();\n\tthrow v191;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmQuaternion FindFsmQuaternion(string name)
		{
			FsmQuaternion[] array = QuaternionVariables;
			int num = array.Length;
			if (array.Length < 1)
			{
				goto IL_00e1;
			}
			int num2 = 0;
			FsmQuaternion result;
			while (true)
			{
				if (num2 < num)
				{
					FsmQuaternion fsmQuaternion = array[num2];
					bool flag = fsmQuaternion.Name == name;
					bool flag2 = !flag;
					bool flag3 = !flag2;
					result = array[num2];
					if (flag3)
					{
						break;
					}
					num = array.Length;
					num2++;
					if (num2 < array.Length)
					{
						continue;
					}
					goto IL_00e1;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			goto IL_00f9;
			IL_00e1:
			result = null;
			goto IL_00f9;
			IL_00f9:
			return result;
		}

		[Token(Token = "0x600064A")]
		[Address(RVA = "0xE50C5C", Offset = "0xE50C5C", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = HutongGames.PlayMaker.FsmVariables::get_ColorVariables(this);\n\tv140 = v16.Length;\n\tv31 = v16.Length < 1;\n\tif (v31) goto L_FFFFFFFF;\nL_001B:\n\tv143 = v43 < v140;\n\tv69 = ~v143;\n\tif (v69) goto L_004A;\n\tv98 = v16[v43 @ X22_v6 (System.Int32)];\n\tv126 = System.String::op_Equality(v98.name, name);\n\tv198 = v126 == 0;\n\tv124 = ~v198;\n\tif (v124) goto L_0049;\n\tv140 = v16.Length;\n\tv43 = v43 + 1;\n\tv104 = v43 < v16.Length;\n\tif (v104) goto L_001B;\nL_0049:\n\treturn v146;\nL_004A:\n\tv191 = new System.IndexOutOfRangeException();\n\tthrow v191;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmColor FindFsmColor(string name)
		{
			FsmColor[] array = ColorVariables;
			int num = array.Length;
			if (array.Length < 1)
			{
				goto IL_00e1;
			}
			int num2 = 0;
			FsmColor result;
			while (true)
			{
				if (num2 < num)
				{
					FsmColor fsmColor = array[num2];
					bool flag = fsmColor.Name == name;
					bool flag2 = !flag;
					bool flag3 = !flag2;
					result = array[num2];
					if (flag3)
					{
						break;
					}
					num = array.Length;
					num2++;
					if (num2 < array.Length)
					{
						continue;
					}
					goto IL_00e1;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			goto IL_00f9;
			IL_00e1:
			result = null;
			goto IL_00f9;
			IL_00f9:
			return result;
		}

		[Token(Token = "0x600064B")]
		[Address(RVA = "0xE50CF4", Offset = "0xE50CF4", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = HutongGames.PlayMaker.FsmVariables::get_GameObjectVariables(this);\n\tv140 = v16.Length;\n\tv31 = v16.Length < 1;\n\tif (v31) goto L_FFFFFFFF;\nL_001B:\n\tv143 = v43 < v140;\n\tv69 = ~v143;\n\tif (v69) goto L_004A;\n\tv98 = v16[v43 @ X22_v6 (System.Int32)];\n\tv126 = System.String::op_Equality(v98.name, name);\n\tv198 = v126 == 0;\n\tv124 = ~v198;\n\tif (v124) goto L_0049;\n\tv140 = v16.Length;\n\tv43 = v43 + 1;\n\tv104 = v43 < v16.Length;\n\tif (v104) goto L_001B;\nL_0049:\n\treturn v146;\nL_004A:\n\tv191 = new System.IndexOutOfRangeException();\n\tthrow v191;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmGameObject FindFsmGameObject(string name)
		{
			FsmGameObject[] array = GameObjectVariables;
			int num = array.Length;
			if (array.Length < 1)
			{
				goto IL_00e1;
			}
			int num2 = 0;
			FsmGameObject result;
			while (true)
			{
				if (num2 < num)
				{
					FsmGameObject fsmGameObject = array[num2];
					bool flag = fsmGameObject.Name == name;
					bool flag2 = !flag;
					bool flag3 = !flag2;
					result = array[num2];
					if (flag3)
					{
						break;
					}
					num = array.Length;
					num2++;
					if (num2 < array.Length)
					{
						continue;
					}
					goto IL_00e1;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			goto IL_00f9;
			IL_00e1:
			result = null;
			goto IL_00f9;
			IL_00f9:
			return result;
		}

		[Token(Token = "0x600064C")]
		[Address(RVA = "0xE4E97C", Offset = "0xE4E97C", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = HutongGames.PlayMaker.FsmVariables::get_EnumVariables(this);\n\tv140 = v16.Length;\n\tv31 = v16.Length < 1;\n\tif (v31) goto L_FFFFFFFF;\nL_001B:\n\tv143 = v43 < v140;\n\tv69 = ~v143;\n\tif (v69) goto L_004A;\n\tv98 = v16[v43 @ X22_v6 (System.Int32)];\n\tv126 = System.String::op_Equality(v98.name, name);\n\tv198 = v126 == 0;\n\tv124 = ~v198;\n\tif (v124) goto L_0049;\n\tv140 = v16.Length;\n\tv43 = v43 + 1;\n\tv104 = v43 < v16.Length;\n\tif (v104) goto L_001B;\nL_0049:\n\treturn v146;\nL_004A:\n\tv191 = new System.IndexOutOfRangeException();\n\tthrow v191;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmEnum FindFsmEnum(string name)
		{
			FsmEnum[] array = EnumVariables;
			int num = array.Length;
			if (array.Length < 1)
			{
				goto IL_00e1;
			}
			int num2 = 0;
			FsmEnum result;
			while (true)
			{
				if (num2 < num)
				{
					FsmEnum fsmEnum = array[num2];
					bool flag = fsmEnum.Name == name;
					bool flag2 = !flag;
					bool flag3 = !flag2;
					result = array[num2];
					if (flag3)
					{
						break;
					}
					num = array.Length;
					num2++;
					if (num2 < array.Length)
					{
						continue;
					}
					goto IL_00e1;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			goto IL_00f9;
			IL_00e1:
			result = null;
			goto IL_00f9;
			IL_00f9:
			return result;
		}

		[Token(Token = "0x600064D")]
		[Address(RVA = "0xE4EA14", Offset = "0xE4EA14", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = HutongGames.PlayMaker.FsmVariables::get_ArrayVariables(this);\n\tv140 = v16.Length;\n\tv31 = v16.Length < 1;\n\tif (v31) goto L_FFFFFFFF;\nL_001B:\n\tv143 = v43 < v140;\n\tv69 = ~v143;\n\tif (v69) goto L_004A;\n\tv98 = v16[v43 @ X22_v6 (System.Int32)];\n\tv126 = System.String::op_Equality(v98.name, name);\n\tv198 = v126 == 0;\n\tv124 = ~v198;\n\tif (v124) goto L_0049;\n\tv140 = v16.Length;\n\tv43 = v43 + 1;\n\tv104 = v43 < v16.Length;\n\tif (v104) goto L_001B;\nL_0049:\n\treturn v146;\nL_004A:\n\tv191 = new System.IndexOutOfRangeException();\n\tthrow v191;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmArray FindFsmArray(string name)
		{
			FsmArray[] array = ArrayVariables;
			int num = array.Length;
			if (array.Length < 1)
			{
				goto IL_00e1;
			}
			int num2 = 0;
			FsmArray result;
			while (true)
			{
				if (num2 < num)
				{
					FsmArray fsmArray = array[num2];
					bool flag = fsmArray.Name == name;
					bool flag2 = !flag;
					bool flag3 = !flag2;
					result = array[num2];
					if (flag3)
					{
						break;
					}
					num = array.Length;
					num2++;
					if (num2 < array.Length)
					{
						continue;
					}
					goto IL_00e1;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			goto IL_00f9;
			IL_00e1:
			result = null;
			goto IL_00f9;
			IL_00f9:
			return result;
		}
	}
}
