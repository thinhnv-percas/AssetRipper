using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Serializable]
	[Token(Token = "0x2000069")]
	public class ProductCatalog
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200006A")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000169")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400016A")]
			public static Func<ProductCatalogItem, bool> _003C_003E9__8_0;

			[Token(Token = "0x600018A")]
			[Address(RVA = "0xC6B5D8", Offset = "0xC6B5D8", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1EADD20]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2023394]) = v37;\nL_0015:\n\tv41 = new UnityEngine.Purchasing.ProductCatalog+<>c();\n\tSystem.Object::.ctor(v41);\n\tv45.<>9 = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x600018B")]
			[Address(RVA = "0xC6B63C", Offset = "0xC6B63C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec()
			{
			}

			internal bool _003Cget_allValidProducts_003Eb__8_0(ProductCatalogItem x)
			{
				if (string.IsNullOrEmpty(x.id))
				{
					return false;
				}
				string text = x.id.Trim();
				bool flag = text.Length == 0;
				return !flag;
			}
		}

		[Token(Token = "0x4000166")]
		private static IProductCatalogImpl instance;

		[Token(Token = "0x4000167")]
		[FieldOffset(Offset = "0x10")]
		public bool enableCodelessAutoInitialization;

		[SerializeField]
		[Token(Token = "0x4000168")]
		[FieldOffset(Offset = "0x18")]
		public List<ProductCatalogItem> products;

		[Token(Token = "0x17000033")]
		public ICollection<ProductCatalogItem> allProducts
		{
			[Token(Token = "0x6000181")]
			[Address(RVA = "0xC6B1CC", Offset = "0xC6B1CC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.products;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return products;
			}
		}

		[Token(Token = "0x17000034")]
		public ICollection<ProductCatalogItem> allValidProducts
		{
			[Token(Token = "0x6000182")]
			[Address(RVA = "0xC6B1D4", Offset = "0xC6B1D4", Length = "0x100")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1EA43F0]);\n\tv23 = *([v22 @ X8_v22]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202338D]) = v42;\nL_001C:\n\tgoto L_0024;\n\tv50 = *([v46 @ X0_v2 (Il2CppClass<UnityEngine.Purchasing.ProductCatalog+<>c>)+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0024;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v46, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = UnityEngine.Purchasing.ProductCatalog+<>c;\nL_0024:\n\tv82 = v57.<>9__8_0;\n\tv59 = v57.<>9__8_0 == 0;\n\tv60 = ~v59;\n\tif (v60) goto L_0049;\n\tgoto L_0037;\n\tv90 = *([v53 @ X0_v3 (Il2CppClass<UnityEngine.Purchasing.ProductCatalog+<>c>)+E0]);\n\tv91 = v90 == 0;\n\tv92 = ~v91;\n\tif (v92) goto L_0037;\n\tv95 = \"il2cpp_codegen_runtime_class_init\"(v53, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv114 = UnityEngine.Purchasing.ProductCatalog+<>c;\n\tv97 = *([v114 @ X8_v18+B8]);\nL_0037:\n\tv77 = new System.Func`2<UnityEngine.Purchasing.ProductCatalogItem, System.Boolean>();\n\tSystem.Func`2<UnityEngine.Purchasing.ProductCatalogItem, System.Boolean>::.ctor(v77, v96.<>9, Il2CppMethodInfo);\n\tv81.<>9__8_0 = v77;\nL_0049:\n\tv89 = System.Linq.Enumerable::Where(this.products, v82);\n\treturnVal1 = System.Linq.Enumerable::ToList(v89);\n\treturn returnVal1;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Func<ProductCatalogItem, bool> predicate = _003C_003Ec._003C_003E9__8_0;
				if (_003C_003Ec._003C_003E9__8_0 == null)
				{
					predicate = (_003C_003Ec._003C_003E9__8_0 = delegate(ProductCatalogItem x)
					{
						if (string.IsNullOrEmpty(x.id))
						{
							return false;
						}
						string text = x.id.Trim();
						bool flag = text.Length == 0;
						return !flag;
					});
				}
				IEnumerable<ProductCatalogItem> source = products.Where(predicate);
				return source.ToList();
			}
		}

		[Token(Token = "0x6000183")]
		[Address(RVA = "0xC6B2D4", Offset = "0xC6B2D4", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EE74C0]);\n\tv19 = *([v18 @ X8_v17]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([202338E]) = v39;\nL_0018:\n\tv45 = v43.instance == 0;\n\tv46 = ~v45;\n\tif (v46) goto L_0037;\n\tv50 = new UnityEngine.Purchasing.ProductCatalogImpl();\n\tSystem.Object::.ctor(v50);\n\tgoto L_0030;\n\tv72 = *([1EAE120]);\n\tv73 = *([v72 @ X8_v14]);\n\tv74 = \"il2cpp_codegen_initialize_method\"(v73, v54, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv76 = 0 | 1;\n\t*([202338F]) = v76;\nL_0030:\n\tv60.instance = v50;\nL_0037:\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void Initialize()
		{
			if (instance == null)
			{
				ProductCatalogImpl productCatalogImpl = new ProductCatalogImpl();
				instance = productCatalogImpl;
			}
		}

		[Token(Token = "0x6000184")]
		[Address(RVA = "0xC6B384", Offset = "0xC6B384", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EAE120]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202338F]) = v38;\nL_0017:\n\tv42.instance = productCatalogImpl;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Initialize(IProductCatalogImpl productCatalogImpl)
		{
			instance = productCatalogImpl;
		}

		[Token(Token = "0x6000185")]
		[Address(RVA = "0xC6B3D8", Offset = "0xC6B3D8", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EFF108]);\n\tv19 = *([v18 @ X8_v18]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023390]) = v38;\nL_0015:\n\tv41 = 0;\n\tv43 = this.products == 0;\n\tif (v43) goto L_003B;\n\tv48 = System.Collections.Generic.List`1<UnityEngine.Purchasing.ProductCatalogItem>::GetEnumerator(this.products);\nL_0022:\n\tv69 = System.Collections.Generic.List`1<UnityEngine.Purchasing.ProductCatalogItem>+Enumerator<UnityEngine.Purchasing.ProductCatalogItem>::MoveNext(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<UnityEngine.Purchasing.ProductCatalogItem>+Enumerator<UnityEngine.Purchasing.ProductCatalogItem>));\n\tv81 = v69 == 0;\n\tif (v81) goto L_FFFFFFFF;\n\tv58 = 0;\n\tv64 = System.String::IsNullOrEmpty(*([v58 @ X8_v15 (System.Int32)+10]));\n\tv116 = v64 == 0;\n\tv66 = ~v116;\n\tif (v66) goto L_0022;\n\tgoto L_0037;\nL_0037:\n\tv112 = System.Collections.Generic.List`1<UnityEngine.Purchasing.ProductCatalogItem>+Enumerator<UnityEngine.Purchasing.ProductCatalogItem>::Dispose(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<UnityEngine.Purchasing.ProductCatalogItem>+Enumerator<UnityEngine.Purchasing.ProductCatalogItem>));\n\tgoto L_005B;\n\tv52 = new System.NullReferenceException();\nL_003B:\n\tv59 = new System.NullReferenceException();\n\tgoto L_0047;\n\tgoto L_0047;\nL_0047:\n\tv79 = Il2CppMethodInfo != 1;\n\tif (v79) goto L_005C;\n\tv82 = System.Collections.Generic.List`1<UnityEngine.Purchasing.ProductCatalogItem>+Enumerator<UnityEngine.Purchasing.ProductCatalogItem>::MoveNext(v59);\n\tv86 = System.Collections.Generic.List`1<UnityEngine.Purchasing.ProductCatalogItem>+Enumerator<UnityEngine.Purchasing.ProductCatalogItem>::MoveNext(v82);\n\tv90 = System.Collections.Generic.List`1<UnityEngine.Purchasing.ProductCatalogItem>+Enumerator<UnityEngine.Purchasing.ProductCatalogItem>::Dispose(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<UnityEngine.Purchasing.ProductCatalogItem>+Enumerator<UnityEngine.Purchasing.ProductCatalogItem>));\n\tv117 = ~v82.m_value;\n\tv92 = ~v117;\n\tif (v92) goto L_0060;\nL_005B:\n\treturn v163;\nL_005C:\n\tv83 = System.Collections.Generic.List`1<UnityEngine.Purchasing.ProductCatalogItem>+Enumerator<UnityEngine.Purchasing.ProductCatalogItem>::MoveNext(v59);\nL_0060:\n\treturnVal1 = new System.TypeLoadException();\n\treturn returnVal1;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe bool IsEmpty()
		{
			//IL_012b: Expected I4, but got O
			//IL_0038: Expected O, but got I
			List<ProductCatalogItem>.Enumerator enumerator = default(List<ProductCatalogItem>.Enumerator);
			int result;
			if (products != null)
			{
				List<ProductCatalogItem>.Enumerator enumerator2 = products.GetEnumerator();
				while (true)
				{
					if (enumerator.MoveNext())
					{
						int num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ X8_v15 (System.Int32)+10]");
						if (!string.IsNullOrEmpty((string)0))
						{
							result = 0;
							break;
						}
						continue;
					}
					result = 1;
					break;
				}
				enumerator.Dispose();
				goto IL_018c;
			}
			NullReferenceException ex = new NullReferenceException();
			if ((IntPtr)0 == (IntPtr)1)
			{
				bool flag = ((List<ProductCatalogItem>.Enumerator*)ex)->MoveNext();
				bool flag2 = (flag ? ((List<ProductCatalogItem>.Enumerator*)1) : ((List<ProductCatalogItem>.Enumerator*)null))->MoveNext();
				enumerator.Dispose();
				if (!((bool*)(flag ? 1 : 0))->m_value)
				{
					result = 1;
					goto IL_018c;
				}
			}
			else
			{
				bool flag3 = ((List<ProductCatalogItem>.Enumerator*)ex)->MoveNext();
			}
			TypeLoadException ex2 = new TypeLoadException();
			return (byte)(int)ex2 != 0;
			IL_018c:
			return (byte)result != 0;
		}

		[Token(Token = "0x6000186")]
		[Address(RVA = "0xC6B4F4", Offset = "0xC6B4F4", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EDFC18]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023391]) = v38;\nL_001C:\n\treturnVal1 = UnityEngine.JsonUtility::FromJson(catalogJSON);\n\treturn returnVal1;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ProductCatalog Deserialize(string catalogJSON)
		{
			return JsonUtility.FromJson<ProductCatalog>(catalogJSON);
		}

		[Token(Token = "0x6000187")]
		[Address(RVA = "0xC6B544", Offset = "0xC6B544", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = UnityEngine.TextAsset::get_text(asset);\n\treturnVal2 = UnityEngine.Purchasing.ProductCatalog::Deserialize(v9);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ProductCatalog FromTextAsset(TextAsset asset)
		{
			string text = asset.text;
			return Deserialize(text);
		}

		[Token(Token = "0x6000188")]
		[Address(RVA = "0xC60360", Offset = "0xC60360", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv14 = *([1ECAED8]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023392]) = v35;\nL_0011:\n\tUnityEngine.Purchasing.ProductCatalog::Initialize();\n\tgoto L_004A;\n\tv50 = *([v43 @ X8_v7+B0]);\n\tv51 = 0;\n\tv52 = v50 + 8;\n\tv54 = *([v101 @ X11_v5-8]);\n\tv107 = v54 == v46;\n\tif (v107) goto L_003F;\n\tv87 = v102 + 1;\n\tv158 = v87 < v45;\n\tv81 = ~v158;\n\tv84 = v101 + 0x10;\n\tv57 = ~v81;\n\tif (v57) goto L_FFFFFFFF;\n\tv88 = v40;\n\tv89 = 0;\n\tv90 = 0x8909C4(v88, v46, v89, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tgoto L_004A;\nL_003F:\n\tv159 = *([v101 @ X11_v5]);\n\tv160 = v159 << 4;\n\tv161 = v43 + v160;\n\tv162 = v161 + 0x130;\nL_004A:\n\tinterfaceTailCallResult = UnityEngine.Purchasing.IProductCatalogImpl::LoadDefaultCatalog(v39.instance);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ProductCatalog LoadDefaultCatalog()
		{
			Initialize();
			return instance.LoadDefaultCatalog();
		}

		[Token(Token = "0x6000189")]
		[Address(RVA = "0xC6B564", Offset = "0xC6B564", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1ED1908]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023393]) = v38;\nL_0013:\n\tthis.enableCodelessAutoInitialization = 0;\n\tv42 = new System.Collections.Generic.List`1<UnityEngine.Purchasing.ProductCatalogItem>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Purchasing.ProductCatalogItem>::.ctor(v42);\n\tthis.products = v42;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ProductCatalog()
		{
			enableCodelessAutoInitialization = false;
			List<ProductCatalogItem> list = new List<ProductCatalogItem>();
			products = list;
		}
	}
}
