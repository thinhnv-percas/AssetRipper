using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile;
using Morpeh;
using Morpeh.Globals;
using UnityEngine;

namespace GBG.Pinata.ECS.InAppPurchase.Systems
{
	[CreateAssetMenu]
	[Token(Token = "0x2000047")]
	public class IAPPurchaseSystem : UpdateSystem
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200008B")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000181")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000182")]
			public static Action _003C_003E9__2_0;

			[Token(Token = "0x4000183")]
			public static Action _003C_003E9__2_1;

			[Token(Token = "0x60000F6")]
			[Address(RVA = "0xCC081C", Offset = "0xCC081C", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1ED5728]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([202373B]) = v37;\nL_0015:\n\tv41 = new GBG.Pinata.ECS.InAppPurchase.Systems.IAPPurchaseSystem+<>c();\n\tSystem.Object::.ctor(v41);\n\tv45.<>9 = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60000F7")]
			[Address(RVA = "0xCC0880", Offset = "0xCC0880", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec()
			{
			}

			internal void _003COnAwake_003Eb__2_0()
			{
				Debug.Log("IAPurchasing Initialized Success");
			}

			internal void _003COnAwake_003Eb__2_1()
			{
				Debug.LogError("IAPurchasing Initialized Failed");
			}
		}

		[Token(Token = "0x40000D4")]
		[FieldOffset(Offset = "0x28")]
		public GlobalEvent RestoreClick;

		[Token(Token = "0x40000D5")]
		[FieldOffset(Offset = "0x30")]
		public GlobalEventString PurchaseClick;

		[Token(Token = "0x6000079")]
		[Address(RVA = "0xCC0174", Offset = "0xCC0174", Length = "0x258")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1F02B48]);\n\tv25 = *([v24 @ X8_v49]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023734]) = v44;\nL_001C:\n\tgoto L_0023;\n\tv51 = *([v47 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0023;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0023:\n\tv59 = EasyMobile.InAppPurchasing::IsInitialized();\n\tv61 = v59 == 0;\n\tv62 = ~v61;\n\tif (v62) goto L_003A;\n\tgoto L_0033;\n\tv79 = *([v63 @ X0_v39+E0]);\n\tv80 = v79 == 0;\n\tv81 = ~v80;\n\tif (v81) goto L_0033;\n\tv83 = \"il2cpp_codegen_runtime_class_init\"(v63, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0033:\n\tEasyMobile.InAppPurchasing::InitializePurchasing();\nL_003A:\n\tgoto L_0042;\n\tv84 = *([v75 @ X0_v7 (Il2CppClass<GBG.Pinata.ECS.InAppPurchase.Systems.IAPPurchaseSystem+<>c>)+E0]);\n\tv85 = v84 == 0;\n\tv86 = ~v85;\n\tif (v86) goto L_0042;\n\tv95 = \"il2cpp_codegen_runtime_class_init\"(v75, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv88 = GBG.Pinata.ECS.InAppPurchase.Systems.IAPPurchaseSystem+<>c;\nL_0042:\n\tv116 = v91.<>9__2_0;\n\tv93 = v91.<>9__2_0 == 0;\n\tv94 = ~v93;\n\tif (v94) goto L_0064;\n\tgoto L_0055;\n\tv122 = *([v87 @ X0_v8 (Il2CppClass<GBG.Pinata.ECS.InAppPurchase.Systems.IAPPurchaseSystem+<>c>)+E0]);\n\tv123 = v122 == 0;\n\tv124 = ~v123;\n\tif (v124) goto L_0055;\n\tv126 = \"il2cpp_codegen_runtime_class_init\"(v87, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv147 = GBG.Pinata.ECS.InAppPurchase.Systems.IAPPurchaseSystem+<>c;\n\tv128 = *([v147 @ X8_v41+B8]);\nL_0055:\n\tv111 = new System.Action();\n\tSystem.Action::.ctor(v111, v127.<>9, Il2CppMethodInfo);\n\tv115.<>9__2_0 = v111;\nL_0064:\n\tgoto L_006C;\n\tv132 = *([v118 @ X0_v10+E0]);\n\tv133 = v132 == 0;\n\tv134 = ~v133;\n\tgoto L_006C;\n\tv136 = \"il2cpp_codegen_runtime_class_init\"(v118, v105, v101, v103, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_006C:\n\tEasyMobile.InAppPurchasing::add_InitializeSucceeded(v116);\n\tgoto L_0079;\n\tv149 = *([v143 @ X0_v13 (Il2CppClass<GBG.Pinata.ECS.InAppPurchase.Systems.IAPPurchaseSystem+<>c>)+E0]);\n\tv150 = v149 == 0;\n\tv151 = ~v150;\n\tif (v151) goto L_0079;\n\tv160 = \"il2cpp_codegen_runtime_class_init\"(v143, v140, v101, v103, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv153 = GBG.Pinata.ECS.InAppPurchase.Systems.IAPPurchaseSystem+<>c;\nL_0079:\n\tv180 = v156.<>9__2_1;\n\tv158 = v156.<>9__2_1 == 0;\n\tv159 = ~v158;\n\tif (v159) goto L_009B;\n\tgoto L_008C;\n\tv186 = *([v152 @ X0_v14 (Il2CppClass<GBG.Pinata.ECS.InAppPurchase.Systems.IAPPurchaseSystem+<>c>)+E0]);\n\tv187 = v186 == 0;\n\tv188 = ~v187;\n\tif (v188) goto L_008C;\n\tv190 = \"il2cpp_codegen_runtime_class_init\"(v152, v140, v101, v103, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv211 = GBG.Pinata.ECS.InAppPurchase.Systems.IAPPurchaseSystem+<>c;\n\tv192 = *([v211 @ X8_v30+B8]);\nL_008C:\n\tv175 = new System.Action();\n\tSystem.Action::.ctor(v175, v191.<>9, Il2CppMethodInfo);\n\tv179.<>9__2_1 = v175;\nL_009B:\n\tgoto L_00A3;\n\tv196 = *([v182 @ X0_v16+E0]);\n\tv197 = v196 == 0;\n\tv198 = ~v197;\n\tgoto L_00A3;\n\tv200 = \"il2cpp_codegen_runtime_class_init\"(v182, v170, v166, v168, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_00A3:\n\tEasyMobile.InAppPurchasing::add_InitializeFailed(v180);\n\tv210 = new System.Action`1<EasyMobile.IAPProduct>();\n\tSystem.Action`1<EasyMobile.IAPProduct>::.ctor(v210, this, Il2CppMethodInfo);\n\tEasyMobile.InAppPurchasing::add_PurchaseCompleted(v210);\n\tv224 = new System.Action`1<EasyMobile.IAPProduct>();\n\tSystem.Action`1<EasyMobile.IAPProduct>::.ctor(v224, this, Il2CppMethodInfo);\n\tEasyMobile.InAppPurchasing::add_PurchaseFailed(v224);\n\treturn;\n// 113 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnAwake()
		{
			if (!InAppPurchasing.IsInitialized())
			{
				InAppPurchasing.InitializePurchasing();
			}
			Action value = _003C_003Ec._003C_003E9__2_0;
			if (_003C_003Ec._003C_003E9__2_0 == null)
			{
				value = (_003C_003Ec._003C_003E9__2_0 = delegate
				{
					Debug.Log("IAPurchasing Initialized Success");
				});
			}
			InAppPurchasing.InitializeSucceeded += value;
			Action value2 = _003C_003Ec._003C_003E9__2_1;
			if (_003C_003Ec._003C_003E9__2_1 == null)
			{
				value2 = (_003C_003Ec._003C_003E9__2_1 = delegate
				{
					Debug.LogError("IAPurchasing Initialized Failed");
				});
			}
			InAppPurchasing.InitializeFailed += value2;
			Action<IAPProduct> value3 = PurchaseCompletedHandler;
			InAppPurchasing.PurchaseCompleted += value3;
			Action<IAPProduct> value4 = PurchaseFailedHandler;
			InAppPurchasing.PurchaseFailed += value4;
		}

		[Token(Token = "0x600007A")]
		[Address(RVA = "0xCC03CC", Offset = "0xCC03CC", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EF7468]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, deltaTime, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023735]) = v38;\nL_0019:\n\tv44 = Morpeh.Globals.BaseGlobalEvent`1<System.String>::get_IsPublished(this.PurchaseClick);\n\tv64 = v44 == 0;\n\tif (v64) goto L_0036;\n\tv50 = Morpeh.Globals.BaseGlobalEvent`1<System.String>::get_BatchedChanges(this.PurchaseClick);\n\tv95 = v50._size == 0;\n\tv69 = ~v95;\n\tif (v69) goto L_002D;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_002D:\n\tv70 = v50._items;\n\tGBG.Pinata.ECS.InAppPurchase.Systems.IAPPurchaseSystem::Purchase(v67, v70[0]);\nL_0036:\n\tv77 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::get_IsPublished(this.RestoreClick);\n\tv79 = v77 == 0;\n\tif (v79) goto L_0046;\n\tGBG.Pinata.ECS.InAppPurchase.Systems.IAPPurchaseSystem::Restore(v77);\n\treturn;\nL_0046:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate(float deltaTime)
		{
			//IL_00e8: Expected O, but got I4
			if (PurchaseClick.IsPublished)
			{
				List<string> batchedChanges = PurchaseClick.BatchedChanges;
				bool flag = batchedChanges.Count == 0;
				bool flag2 = !flag;
				IAPPurchaseSystem iAPPurchaseSystem = (IAPPurchaseSystem)(object)batchedChanges;
				if (!flag2)
				{
					throw new ArgumentOutOfRangeException();
				}
				string[] items = batchedChanges._items;
				iAPPurchaseSystem.Purchase(items[0]);
			}
			bool isPublished = RestoreClick.IsPublished;
			if (isPublished)
			{
				((IAPPurchaseSystem)isPublished).Restore();
			}
		}

		[Token(Token = "0x600007B")]
		[Address(RVA = "0xCC05C0", Offset = "0xCC05C0", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1F0B1B8]);\n\tv23 = *([v22 @ X8_v20]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2023736]) = v42;\nL_001B:\n\tgoto L_0025;\n\tv49 = *([v45 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0025;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0025:\n\tUnityEngine.Debug::Log(\"IAPPurchaseSystem disposed\");\n\tv63 = new System.Action`1<EasyMobile.IAPProduct>();\n\tSystem.Action`1<EasyMobile.IAPProduct>::.ctor(v63, this, Il2CppMethodInfo);\n\tgoto L_0041;\n\tv78 = *([v74 @ X0_v7+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_0041;\n\tv82 = \"il2cpp_codegen_runtime_class_init\"(v74, v68, v70, v71, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0041:\n\tEasyMobile.InAppPurchasing::remove_PurchaseCompleted(v63);\n\tv88 = new System.Action`1<EasyMobile.IAPProduct>();\n\tSystem.Action`1<EasyMobile.IAPProduct>::.ctor(v88, this, Il2CppMethodInfo);\n\tEasyMobile.InAppPurchasing::remove_PurchaseFailed(v88);\n\tMorpeh.UpdateSystem::Dispose(this);\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Dispose()
		{
			Debug.Log("IAPPurchaseSystem disposed");
			Action<IAPProduct> value = PurchaseCompletedHandler;
			InAppPurchasing.PurchaseCompleted -= value;
			Action<IAPProduct> value2 = PurchaseFailedHandler;
			InAppPurchasing.PurchaseFailed -= value2;
			base.Dispose();
		}

		[Token(Token = "0x600007C")]
		[Address(RVA = "0xCC0490", Offset = "0xCC0490", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ED4C30]);\n\tv19 = *([v18 @ X8_v16]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, product, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2023737]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, product, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0021:\n\tEasyMobile.InAppPurchasing::Purchase(product);\n\tgoto L_0037;\n\tv60 = *([v56 @ X0_v5+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tif (v62) goto L_0037;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v56, v53, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0037:\n\tUnityEngine.Debug::Log(\"Purchasing..\");\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Purchase(string product)
		{
			InAppPurchasing.Purchase(product);
			Debug.Log("Purchasing..");
		}

		[Token(Token = "0x600007D")]
		[Address(RVA = "0xCC052C", Offset = "0xCC052C", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB2378]);\n\tv15 = *([v14 @ X8_v16]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023738]) = v35;\nL_0017:\n\tgoto L_001E;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001E;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001E:\n\tEasyMobile.InAppPurchasing::RestorePurchases();\n\tgoto L_0033;\n\tv56 = *([v52 @ X0_v5+E0]);\n\tv57 = v56 == 0;\n\tv58 = ~v57;\n\tif (v58) goto L_0033;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v52, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0033:\n\tUnityEngine.Debug::Log(\"Restoring..\");\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Restore()
		{
			InAppPurchasing.RestorePurchases();
			Debug.Log("Restoring..");
		}

		[Token(Token = "0x600007E")]
		[Address(RVA = "0xCC06D4", Offset = "0xCC06D4", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1EDCC00]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, product, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2023739]) = v38;\nL_001D:\n\tv48 = System.String::Concat(\"The purchase of product \", product._name, \" successful!\");\n\tgoto L_0033;\n\tv58 = *([v54 @ X8_v7+E0]);\n\tv59 = v58 == 0;\n\tv60 = ~v59;\n\tif (v60) goto L_0033;\n\tv83 = v54;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v83, v42, v47, v45, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0033:\n\tUnityEngine.Debug::Log(v48);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void PurchaseCompletedHandler(IAPProduct product)
		{
			string message = "The purchase of product " + product.Name + " successful!";
			Debug.Log(message);
		}

		[Token(Token = "0x600007F")]
		[Address(RVA = "0xCC0774", Offset = "0xCC0774", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1F0E6A0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, product, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([202373A]) = v38;\nL_001D:\n\tv48 = System.String::Concat(\"The purchase of product \", product._name, \" has failed!\");\n\tgoto L_0033;\n\tv58 = *([v54 @ X8_v7+E0]);\n\tv59 = v58 == 0;\n\tv60 = ~v59;\n\tif (v60) goto L_0033;\n\tv83 = v54;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v83, v42, v47, v45, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0033:\n\tUnityEngine.Debug::Log(v48);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void PurchaseFailedHandler(IAPProduct product)
		{
			string message = "The purchase of product " + product.Name + " has failed!";
			Debug.Log(message);
		}

		[Token(Token = "0x6000080")]
		[Address(RVA = "0xCC0814", Offset = "0xCC0814", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.UpdateSystem::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IAPPurchaseSystem()
		{
		}
	}
}
