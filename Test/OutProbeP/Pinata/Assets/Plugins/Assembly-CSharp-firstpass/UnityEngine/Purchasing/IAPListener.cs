using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.Events;

namespace UnityEngine.Purchasing
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x7DCDC0", Offset = "0x7DCDC0")]
	[AttributeAttribute(Type = typeof(HelpURLAttribute), RVA = "0x7DCDC0", Offset = "0x7DCDC0")]
	[Token(Token = "0x2000008")]
	public class IAPListener : MonoBehaviour
	{
		[Serializable]
		[Token(Token = "0x200000C")]
		public class OnPurchaseCompletedEvent : UnityEvent<Product>
		{
			[Token(Token = "0x600003F")]
			[Address(RVA = "0x160D6B4", Offset = "0x160D6B4", Length = "0x50")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EE7F30]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A20C]) = v38;\nL_001C:\n\tUnityEngine.Events.UnityEvent`1<UnityEngine.Purchasing.Product>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public OnPurchaseCompletedEvent()
			{
			}
		}

		[Serializable]
		[Token(Token = "0x200000D")]
		public class OnPurchaseFailedEvent : UnityEvent<Product, PurchaseFailureReason>
		{
			[Token(Token = "0x6000040")]
			[Address(RVA = "0x160D704", Offset = "0x160D704", Length = "0x50")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EB3D98]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A20D]) = v38;\nL_001C:\n\tUnityEngine.Events.UnityEvent`2<UnityEngine.Purchasing.Product, UnityEngine.Purchasing.PurchaseFailureReason>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public OnPurchaseFailedEvent()
			{
			}
		}

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7DCFB8", Offset = "0x7DCFB8")]
		[Token(Token = "0x400002A")]
		[FieldOffset(Offset = "0x18")]
		public bool consumePurchase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7DCFF0", Offset = "0x7DCFF0")]
		[Token(Token = "0x400002B")]
		[FieldOffset(Offset = "0x19")]
		public bool dontDestroyOnLoad;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7DD028", Offset = "0x7DD028")]
		[Token(Token = "0x400002C")]
		[FieldOffset(Offset = "0x20")]
		public OnPurchaseCompletedEvent onPurchaseComplete;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7DD060", Offset = "0x7DD060")]
		[Token(Token = "0x400002D")]
		[FieldOffset(Offset = "0x28")]
		public OnPurchaseFailedEvent onPurchaseFailed;

		[Token(Token = "0x6000038")]
		[Address(RVA = "0x160D5E0", Offset = "0x160D5E0", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EC9580]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A209]) = v38;\nL_0014:\n\tv40 = ~v36.dontDestroyOnLoad;\n\tif (v40) goto L_002A;\n\tv43 = UnityEngine.Component::get_gameObject(v36);\n\tgoto L_0029;\n\tv64 = *([v54 @ X8_v7+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_0029;\n\tv75 = v54;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v75, v42, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0029:\n\tUnityEngine.Object::DontDestroyOnLoad(v43);\nL_002A:\n\tv57 = UnityEngine.Purchasing.CodelessIAPStoreListener::get_Instance();\n\tUnityEngine.Purchasing.CodelessIAPStoreListener::AddListener(v57, v36);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnEnable()
		{
			bool flag = !dontDestroyOnLoad;
			GameObject gameObject = (GameObject)(object)this;
			if (!flag)
			{
				gameObject = base.gameObject;
				Object.DontDestroyOnLoad(gameObject);
			}
			CodelessIAPStoreListener instance = CodelessIAPStoreListener.Instance;
			instance.AddListener(this);
		}

		[Token(Token = "0x6000039")]
		[Address(RVA = "0x160D678", Offset = "0x160D678", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = UnityEngine.Purchasing.CodelessIAPStoreListener::get_Instance();\n\tUnityEngine.Purchasing.CodelessIAPStoreListener::RemoveListener(v10, this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDisable()
		{
			CodelessIAPStoreListener instance = CodelessIAPStoreListener.Instance;
			instance.RemoveListener(this);
		}

		[Token(Token = "0x600003A")]
		[Address(RVA = "0x160C4F4", Offset = "0x160C4F4", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EFE5B0]);\n\tv23 = *([v22 @ X8_v18]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, e, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A20A]) = v41;\nL_0017:\n\tv43 = e.<purchasedProduct>k__BackingField;\n\tv48 = v43.<definition>k__BackingField;\n\tv72 = System.String::Format(\"IAPListener.ProcessPurchase(PurchaseEventArgs {0} - {1})\", e, v48.<id>k__BackingField);\n\tgoto L_0034;\n\tv99 = *([v64 @ X8_v11+E0]);\n\tv100 = v99 == 0;\n\tv101 = ~v100;\n\tif (v101) goto L_0034;\n\tv106 = v64;\n\tv103 = \"il2cpp_codegen_runtime_class_init\"(v106, v70, v58, v54, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0034:\n\tUnityEngine.Debug::Log(v72);\n\tUnityEngine.Events.UnityEvent`1<UnityEngine.Purchasing.Product>::Invoke(this.onPurchaseComplete, e.<purchasedProduct>k__BackingField);\n\tv94 = this.consumePurchase ^ 1;\n\treturnVal2 = v94 & 0xFF;\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e)
		{
			Product purchasedProduct = e.purchasedProduct;
			ProductDefinition definition = purchasedProduct.definition;
			string message = $"IAPListener.ProcessPurchase(PurchaseEventArgs {e} - {definition.id})";
			Debug.Log(message);
			onPurchaseComplete.Invoke(e.purchasedProduct);
			int num = (consumePurchase ? 1 : 0) ^ 1;
			return (PurchaseProcessingResult)(num & 0xFF);
		}

		[Token(Token = "0x600003B")]
		[Address(RVA = "0x160C87C", Offset = "0x160C87C", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1EF8F78]);\n\tv27 = *([v26 @ X8_v15]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, product, reason, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202A20B]) = v44;\nL_001C:\n\t// 28 Box v50 @ X0_v3 (System.Object), typeof(UnityEngine.Purchasing.PurchaseFailureReason), &reason @ X2 (UnityEngine.Purchasing.PurchaseFailureReason)\n\tv58 = System.String::Format(\"IAPListener.OnPurchaseFailed(Product {0}, PurchaseFailureReason {1})\", product, v50);\n\tgoto L_0035;\n\tv66 = *([v62 @ X8_v10+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tgoto L_0035;\n\tv75 = v62;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v75, v54, v53, v55, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0035:\n\tUnityEngine.Debug::Log(v58);\n\tUnityEngine.Events.UnityEvent`2<UnityEngine.Purchasing.Product, UnityEngine.Purchasing.PurchaseFailureReason>::Invoke(this.onPurchaseFailed, product, reason);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
		{
			object arg = reason;
			string message = $"IAPListener.OnPurchaseFailed(Product {product}, PurchaseFailureReason {arg})";
			Debug.Log(message);
			onPurchaseFailed.Invoke(product, reason);
		}

		[Token(Token = "0x600003C")]
		[Address(RVA = "0x160D6A4", Offset = "0x160D6A4", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.consumePurchase = 0x101;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IAPListener()
		{
			consumePurchase = true;
			dontDestroyOnLoad = true;
		}
	}
}
