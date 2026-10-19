using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using _game.CoreGameKit.UiControllers.ScriptableObjects;

namespace _game.CoreGameKit.UiControllers
{
	[Token(Token = "0x2000011")]
	public class UiManager : IUiManager
	{
		[Token(Token = "0x4000022")]
		[FieldOffset(Offset = "0x10")]
		private readonly IUiFactoryDataStore _dataStore;

		[Token(Token = "0x4000023")]
		[FieldOffset(Offset = "0x18")]
		private readonly CameraUiFactory _cameraUi;

		[Token(Token = "0x4000024")]
		[FieldOffset(Offset = "0x20")]
		private readonly OverlayUiFactory _overlayUi;

		[Token(Token = "0x4000025")]
		[FieldOffset(Offset = "0x28")]
		private readonly IUiAnalytics _analytics;

		[Token(Token = "0x4000026")]
		private static List<GraphicRaycaster> _raycasters;

		[Token(Token = "0x4000027")]
		private static List<RaycastResult> s_raycastAppendResults;

		[Token(Token = "0x6000052")]
		[Address(RVA = "0x81A46D0", Offset = "0x81A46D0", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis._dataStore = dataStore;\n\tthis._cameraUi = cameraUi;\n\tthis._overlayUi = overlayUi;\n\tthis._analytics = analytics;\n\tv58 = this._cameraUi;\n\tv58._analytics = analytics;\n\tv66 = this._overlayUi;\n\tv66._analytics = analytics;\n\treturn;\n")]
		public UiManager(IUiFactoryDataStore dataStore, CameraUiFactory cameraUi, OverlayUiFactory overlayUi, IUiAnalytics analytics)
		{
			_dataStore = dataStore;
			_cameraUi = cameraUi;
			_overlayUi = overlayUi;
			_analytics = analytics;
			CameraUiFactory cameraUi2 = _cameraUi;
			cameraUi2._analytics = analytics;
			OverlayUiFactory overlayUi2 = _overlayUi;
			overlayUi2._analytics = analytics;
		}

		[Token(Token = "0x6000053")]
		[Address(RVA = "0x81A4784", Offset = "0x81A4784", Length = "0x3A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0047;\nL_004A:\n\tv70 = UnityEngine.EventSystems.EventSystem::get_current();\n\tv76 = new UnityEngine.EventSystems.PointerEventData();\n\tUnityEngine.EventSystems.PointerEventData::.ctor(v76, v70);\n\tv160 = 0xB295000 + 0xE30;\n\tv76.<position>k__BackingField.x = mousePosition;\n\tv76.<position>k__BackingField.y = mousePosition.y;\n\tgoto L_0068;\nL_0068:\n\tv172 = UnityEngine.Component::GetComponentsInChildren(this._cameraUi);\n\tSystem.Collections.Generic.List`1<UnityEngine.UI.GraphicRaycaster>::AddRange(v154._raycasters, v172);\n\tv174 = UnityEngine.Component::GetComponentsInChildren(this._overlayUi);\n\tSystem.Collections.Generic.List`1<UnityEngine.UI.GraphicRaycaster>::AddRange(v189._raycasters, v174);\n\tv441 = System.Collections.Generic.List`1<UnityEngine.UI.GraphicRaycaster>::GetEnumerator(v190._raycasters);\n\tv218 = v441._list;\n\tgoto L_00A8;\nL_00A8:\n\tv295 = v441.Current == 0;\n\tif (v295) goto L_010A;\n\tv497 = UnityEngine.UI.GraphicRaycaster::Raycast(v441.Current, v76, v494.s_raycastAppendResults);\n\tv490 = v498.s_raycastAppendResults;\n\tv296 = v498.s_raycastAppendResults == 0;\n\tif (v296) goto L_010C;\n\tv457 = v490.Count == 0;\n\tif (v457) goto L_009C;\n\tgoto L_00C7;\nL_00C7:\n\t;\n\tSystem.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>::Clear(v490);\n\tv472 = v490.Count < 1;\n\tif (v472) goto L_00DC;\nL_00DC:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v218 @ stack_-70_v6 (System.Collections.Generic.List`1<UnityEngine.UI.GraphicRaycaster>));\n\tv197 = v462;\nL_00DD:\n\tv177 = *([v160 @ X22_v6 (System.Int32)]);\n\tgoto L_00E4;\n\tv410 = *([v191 @ X8_v10+1C]) + 1;\n\t*([v191 @ X8_v10+18]) = 0;\n\t*([v191 @ X8_v10+1C]) = v410;\n\tv379 = *([v191 @ X8_v10+18]) < 1;\n\tif (v379) goto L_0109;\n\tSystem.Array::Clear(*([v191 @ X8_v10+10]), 0, *([v191 @ X8_v10+18]));\nL_0109:\n\treturn v197;\nL_010A:\n\tv292 = new System.NullReferenceException();\n\tgoto L_0110;\nL_010C:\n\tv293 = new System.NullReferenceException();\n\tv328 = 0;\n\tgoto L_0110;\nL_0110:\n\t// 272 Interrupt\n\tgoto L_0114;\nL_0114:\n\tgoto L_0124;\n\tv327 = 0x8BF5BC4(v292, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv344 = 0x8BF5BF4(v327, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v218 @ stack_-70_v6 (System.Collections.Generic.List`1<UnityEngine.UI.GraphicRaycaster>));\n\tv335 = *([v327 @ X0_v16]) == 0;\n\tv160 = v160;\n\tv197 = 1;\n\tif (v335) goto L_00DD;\n\tv333 = new System.OutOfMemoryException();\n\tv328 = *([v327 @ X0_v16]);\n\tv336 = v333;\n\treturn returnVal1;\nL_0047:\n\tgoto L_004A;\nL_009C:\n\tv462 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v218 @ stack_-70_v6 (System.Collections.Generic.List`1<UnityEngine.UI.GraphicRaycaster>));\n\tv468 = v462 == 0;\n\tif (v468) goto L_00DC;\nL_00E4:\n\tv444 = *([v177 @ X0_v27+B8]);\n\tv191 = *([v444 @ X8_v9]);\nL_0124:\n\tv322 = Il2CppMethodInfo != 1;\n\tv336 = v292;\n\tif (v322) goto L_0134;\nL_0134:\n\tv339 = 0x396655C(&v328 @ stack_-88_v2 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv346 = 0x8BF0368(v336, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal1 = 0x7C03E68(v346, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe bool IsOverUI(Vector2 mousePosition)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UiManager::IsOverUI");
			return default;
		}

		[Token(Token = "0x6000054")]
		[Address(RVA = "0x4234E28", Offset = "0x4234E28", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv45 = Il2CppClass<T>;\n\tgoto L_0016;\nL_0016:\n\tv56 = System.Type::GetTypeFromHandle(v45);\n\tv65 = _game.CoreGameKit.UiControllers.UiManager::Show(this, v56);\n\tgoto L_0027;\n\treturnVal2 = 0x21C11D0(v65, Il2CppClass<T>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv90 = returnVal2 == 0;\n\tif (v90) goto L_004E;\n\treturn returnVal2;\n\tv27 = 0x220C2B8(methodInfo, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_FFFFFFFF:\n\tv45 = Il2CppClass<T>;\n\tgoto L_0016;\nL_004B:\n\treturn 0;\nL_004E:\n\treturnVal3 = new System.InvalidCastException();\n\treturn returnVal3;\nL_0027:\n\tv79 = v65 == 0;\n\tif (v79) goto L_004B;\n")]
		public T Show<T>() where T : UIController
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UiManager::Show");
			return default;
		}

		[Token(Token = "0x6000055")]
		[Address(RVA = "0x81A4B28", Offset = "0x81A4B28", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv52 = *([v47 @ X0_v2 (_game.CoreGameKit.UiControllers.IUiFactory)]);\n\tv107 = *([v52 @ X8_v5 (Il2CppClass<_game.CoreGameKit.UiControllers.IUiFactory>)+12E]);\n\tv54 = *([v52 @ X8_v5 (Il2CppClass<_game.CoreGameKit.UiControllers.IUiFactory>)+12E]) == 0;\n\tif (v54) goto L_004B;\n\tv106 = *([v52 @ X8_v5 (Il2CppClass<_game.CoreGameKit.UiControllers.IUiFactory>)+B0]) + 8;\n\tv106 = v106 + 0x10;\n\tv92 = v107 - 1;\n\tv62 = v107 != 1;\n\tv107 = v92;\n\tif (v62) goto L_0029;\nL_004B:\n\tinterfaceTailCallResult = _game.CoreGameKit.UiControllers.IUiFactory::Show(v47, type);\nL_004B:\n\treturn interfaceTailCallResult;\nL_004D:\n\tv151 = *([v106 @ X10_v4]) + 1;\n\tv131 = v151 << 4;\n\tv169 = v52 + v131;\n\tv160 = v169 + 0x138;\n\tv137 = *([v160 @ X8_v8]);\n\tv139 = *([v160 @ X8_v8+8]);\n\t// 91 IndirectJump v137 @ X3_v2, v47 @ X0_v2 (_game.CoreGameKit.UiControllers.IUiFactory), v47 @ X0_v2 (_game.CoreGameKit.UiControllers.IUiFactory), type @ X1 (System.Type), v139 @ X2_v3, v137 @ X3_v2, v29 @ X4, v30 @ X5, v31 @ X6, v32 @ X7, v33 @ V0, v34 @ V1, v35 @ V2, v36 @ V3, v37 @ V4, v38 @ V5, v39 @ V6, v40 @ V7\nL_0018:\n\tv47 = _game.CoreGameKit.UiControllers.UiManager::GetFactory(v41, type);\nL_0029:\n\tv112 = *([v106 @ X10_v4-8]) == _game.CoreGameKit.UiControllers.IUiFactory;\n\tif (v112) goto L_004D;\n")]
		public UIController Show(Type type)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UiManager::Show");
			return default;
		}

		[Token(Token = "0x6000056")]
		[Address(RVA = "0x81A4CE4", Offset = "0x81A4CE4", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tgoto L_0053;\nL_0019:\n\tv48 = _game.CoreGameKit.UiControllers.UiManager::GetFactory(v42, type);\nL_0053:\n\tinterfaceTailCallResult = _game.CoreGameKit.UiControllers.IUiFactory::Show(0, type, customInstancer);\nL_0053:\n\treturn interfaceTailCallResult;\n")]
		public UIController Show(Type type, Instancer customInstancer)
		{
			IUiFactory factory = GetFactory(type);
			return ((IUiFactory)null).Show(type, customInstancer);
		}

		[Token(Token = "0x6000057")]
		[Address(RVA = "0x4234B7C", Offset = "0x4234B7C", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv45 = Il2CppClass<T>;\n\tgoto L_0016;\nL_0016:\n\tv56 = System.Type::GetTypeFromHandle(v45);\n\tv65 = _game.CoreGameKit.UiControllers.UiManager::Get(this, v56);\n\tgoto L_0027;\n\treturnVal2 = 0x21C11D0(v65, Il2CppClass<T>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv90 = returnVal2 == 0;\n\tif (v90) goto L_004E;\n\treturn returnVal2;\n\tv27 = 0x220C2B8(methodInfo, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_FFFFFFFF:\n\tv45 = Il2CppClass<T>;\n\tgoto L_0016;\nL_004B:\n\treturn 0;\nL_004E:\n\treturnVal3 = new System.InvalidCastException();\n\treturn returnVal3;\nL_0027:\n\tv79 = v65 == 0;\n\tif (v79) goto L_004B;\n")]
		public T Get<T>() where T : UIController
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UiManager::Get");
			return default;
		}

		[Token(Token = "0x6000058")]
		[Address(RVA = "0x81A4DB4", Offset = "0x81A4DB4", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv52 = *([v47 @ X0_v2 (_game.CoreGameKit.UiControllers.IUiFactory)]);\n\tv107 = *([v52 @ X8_v5 (Il2CppClass<_game.CoreGameKit.UiControllers.IUiFactory>)+12E]);\n\tv54 = *([v52 @ X8_v5 (Il2CppClass<_game.CoreGameKit.UiControllers.IUiFactory>)+12E]) == 0;\n\tif (v54) goto L_004B;\n\tv106 = *([v52 @ X8_v5 (Il2CppClass<_game.CoreGameKit.UiControllers.IUiFactory>)+B0]) + 8;\n\tv106 = v106 + 0x10;\n\tv92 = v107 - 1;\n\tv62 = v107 != 1;\n\tv107 = v92;\n\tif (v62) goto L_0029;\nL_004B:\n\tinterfaceTailCallResult = _game.CoreGameKit.UiControllers.IUiFactory::Get(v47, type);\nL_004B:\n\treturn interfaceTailCallResult;\nL_004D:\n\tv151 = *([v106 @ X10_v4]) + 3;\n\tv131 = v151 << 4;\n\tv169 = v52 + v131;\n\tv160 = v169 + 0x138;\n\tv137 = *([v160 @ X8_v8]);\n\tv139 = *([v160 @ X8_v8+8]);\n\t// 91 IndirectJump v137 @ X3_v2, v47 @ X0_v2 (_game.CoreGameKit.UiControllers.IUiFactory), v47 @ X0_v2 (_game.CoreGameKit.UiControllers.IUiFactory), type @ X1 (System.Type), v139 @ X2_v3, v137 @ X3_v2, v29 @ X4, v30 @ X5, v31 @ X6, v32 @ X7, v33 @ V0, v34 @ V1, v35 @ V2, v36 @ V3, v37 @ V4, v38 @ V5, v39 @ V6, v40 @ V7\nL_0018:\n\tv47 = _game.CoreGameKit.UiControllers.UiManager::GetFactory(v41, type);\nL_0029:\n\tv112 = *([v106 @ X10_v4-8]) == _game.CoreGameKit.UiControllers.IUiFactory;\n\tif (v112) goto L_004D;\n")]
		public UIController Get(Type type)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UiManager::Get");
			return default;
		}

		[Token(Token = "0x6000059")]
		[Address(RVA = "0x42349F0", Offset = "0x42349F0", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv41 = Il2CppClass<T>;\n\tgoto L_0013;\nL_0013:\n\tv52 = System.Type::GetTypeFromHandle(v41);\n\treturnVal1 = _game.CoreGameKit.UiControllers.UiManager::Exist(this, v52);\n\treturn returnVal1;\n\tv23 = 0x220C2B8(methodInfo, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_FFFFFFFF:\n\tv41 = Il2CppClass<T>;\n\tgoto L_0013;\n")]
		public bool Exist<T>() where T : UIController
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UiManager::Exist");
			return default;
		}

		[Token(Token = "0x600005A")]
		[Address(RVA = "0x81A4E8C", Offset = "0x81A4E8C", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv52 = *([v47 @ X0_v2 (_game.CoreGameKit.UiControllers.IUiFactory)]);\n\tv107 = *([v52 @ X8_v5 (Il2CppClass<_game.CoreGameKit.UiControllers.IUiFactory>)+12E]);\n\tv54 = *([v52 @ X8_v5 (Il2CppClass<_game.CoreGameKit.UiControllers.IUiFactory>)+12E]) == 0;\n\tif (v54) goto L_004B;\n\tv106 = *([v52 @ X8_v5 (Il2CppClass<_game.CoreGameKit.UiControllers.IUiFactory>)+B0]) + 8;\n\tv106 = v106 + 0x10;\n\tv92 = v107 - 1;\n\tv62 = v107 != 1;\n\tv107 = v92;\n\tif (v62) goto L_0029;\nL_004B:\n\tinterfaceTailCallResult = _game.CoreGameKit.UiControllers.IUiFactory::Exist(v47, type);\nL_004B:\n\treturn interfaceTailCallResult;\nL_004D:\n\tv151 = *([v106 @ X10_v4]) + 4;\n\tv131 = v151 << 4;\n\tv169 = v52 + v131;\n\tv160 = v169 + 0x138;\n\tv137 = *([v160 @ X8_v8]);\n\tv139 = *([v160 @ X8_v8+8]);\n\t// 91 IndirectJump v137 @ X3_v2, v47 @ X0_v2 (_game.CoreGameKit.UiControllers.IUiFactory), v47 @ X0_v2 (_game.CoreGameKit.UiControllers.IUiFactory), type @ X1 (System.Type), v139 @ X2_v3, v137 @ X3_v2, v29 @ X4, v30 @ X5, v31 @ X6, v32 @ X7, v33 @ V0, v34 @ V1, v35 @ V2, v36 @ V3, v37 @ V4, v38 @ V5, v39 @ V6, v40 @ V7\nL_0018:\n\tv47 = _game.CoreGameKit.UiControllers.UiManager::GetFactory(v41, type);\nL_0029:\n\tv112 = *([v106 @ X10_v4-8]) == _game.CoreGameKit.UiControllers.IUiFactory;\n\tif (v112) goto L_004D;\n")]
		public bool Exist(Type type)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UiManager::Exist");
			return default;
		}

		[Token(Token = "0x600005B")]
		[Address(RVA = "0x4234A74", Offset = "0x4234A74", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv41 = Il2CppClass<T>;\n\tgoto L_0013;\nL_0013:\n\tv52 = System.Type::GetTypeFromHandle(v41);\n\t_game.CoreGameKit.UiControllers.UiManager::ForceHideIfExist(this, v52);\n\treturn;\n\tv23 = 0x220C2B8(methodInfo, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_FFFFFFFF:\n\tv41 = Il2CppClass<T>;\n\tgoto L_0013;\n")]
		public void ForceHideIfExist<T>()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UiManager::ForceHideIfExist");
		}

		[Token(Token = "0x600005C")]
		[Address(RVA = "0x81A4F64", Offset = "0x81A4F64", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv52 = *([v47 @ X0_v2 (_game.CoreGameKit.UiControllers.IUiFactory)]);\n\tv107 = *([v52 @ X8_v5 (Il2CppClass<_game.CoreGameKit.UiControllers.IUiFactory>)+12E]);\n\tv54 = *([v52 @ X8_v5 (Il2CppClass<_game.CoreGameKit.UiControllers.IUiFactory>)+12E]) == 0;\n\tif (v54) goto L_004B;\n\tv106 = *([v52 @ X8_v5 (Il2CppClass<_game.CoreGameKit.UiControllers.IUiFactory>)+B0]) + 8;\n\tv106 = v106 + 0x10;\n\tv92 = v107 - 1;\n\tv62 = v107 != 1;\n\tv107 = v92;\n\tif (v62) goto L_0029;\nL_004B:\n\t_game.CoreGameKit.UiControllers.IUiFactory::ForceHideIfExist(v47, type);\nL_004B:\n\treturn;\nL_004D:\n\tv151 = *([v106 @ X10_v4]) + 5;\n\tv131 = v151 << 4;\n\tv169 = v52 + v131;\n\tv160 = v169 + 0x138;\n\tv137 = *([v160 @ X8_v8]);\n\tv139 = *([v160 @ X8_v8+8]);\n\t// 91 IndirectJump v137 @ X3_v2, v47 @ X0_v2 (_game.CoreGameKit.UiControllers.IUiFactory), v47 @ X0_v2 (_game.CoreGameKit.UiControllers.IUiFactory), type @ X1 (System.Type), v139 @ X2_v3, v137 @ X3_v2, v29 @ X4, v30 @ X5, v31 @ X6, v32 @ X7, v33 @ V0, v34 @ V1, v35 @ V2, v36 @ V3, v37 @ V4, v38 @ V5, v39 @ V6, v40 @ V7\nL_0018:\n\tv47 = _game.CoreGameKit.UiControllers.UiManager::GetFactory(v41, type);\nL_0029:\n\tv112 = *([v106 @ X10_v4-8]) == _game.CoreGameKit.UiControllers.IUiFactory;\n\tif (v112) goto L_004D;\n")]
		public void ForceHideIfExist(Type type)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UiManager::ForceHideIfExist");
		}

		[Token(Token = "0x600005D")]
		[Address(RVA = "0x4234D10", Offset = "0x4234D10", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv41 = Il2CppClass<T>;\n\tgoto L_0013;\nL_0013:\n\tv52 = System.Type::GetTypeFromHandle(v41);\n\t_game.CoreGameKit.UiControllers.UiManager::Hide(this, v52);\n\treturn;\n\tv23 = 0x220C2B8(methodInfo, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_FFFFFFFF:\n\tv41 = Il2CppClass<T>;\n\tgoto L_0013;\n")]
		public void Hide<T>() where T : UIController
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UiManager::Hide");
		}

		[Token(Token = "0x600005E")]
		[Address(RVA = "0x81A503C", Offset = "0x81A503C", Length = "0x210")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = *([B799F42]) & 1;\n\tv21 = v20 == 0;\n\tif (v21) goto L_001F;\n\tv24 = *([B799F41]) & 1;\n\tv25 = v24 == 0;\n\tif (v25) goto L_002A;\nL_0016:\n\tv70 = _game.CoreGameKit.UiControllers.UiManager::GetFactory(this, type);\n\tv63 = v70 == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_0033;\n\tgoto L_00D2;\nL_001F:\n\t*([B799F42]) = 1;\n\tv61 = *([B799F41]) & 1;\n\tv62 = v61 == 0;\n\tv45 = ~v62;\n\tif (v45) goto L_0016;\nL_002A:\n\t*([B799F41]) = 1;\n\tv70 = _game.CoreGameKit.UiControllers.UiManager::GetFactory(this, type);\nL_0033:\n\tv78 = *([v70 @ X0_v3 (_game.CoreGameKit.UiControllers.IUiFactory)]);\n\tv196 = *([v78 @ X8_v4 (Il2CppClass<_game.CoreGameKit.UiControllers.IUiFactory>)+12E]);\n\tv80 = *([v78 @ X8_v4 (Il2CppClass<_game.CoreGameKit.UiControllers.IUiFactory>)+12E]) == 0;\n\tif (v80) goto L_0057;\n\tv195 = *([v78 @ X8_v4 (Il2CppClass<_game.CoreGameKit.UiControllers.IUiFactory>)+B0]) + 8;\n\tv195 = v195 + 0x10;\n\tv181 = v196 - 1;\n\tv161 = v196 != 1;\n\tv196 = v181;\n\tif (v161) goto L_003E;\nL_0057:\n\t;\n\tv211 = _game.CoreGameKit.UiControllers.IUiFactory::Exist(v70, type);\n\tv212 = v211 == 0;\n\tv213 = ~v212;\n\tif (v213) goto L_006E;\n\tgoto L_00D1;\nL_005F:\n\tv274 = *([v195 @ X10_v13]) + 4;\n\tv275 = v274 << 4;\n\tv276 = v78 + v275;\n\tv277 = v276 + 0x138;\n\t*([v277 @ X8_v21])(v281, v70, type, *([v277 @ X8_v21+8]), v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv282 = v281 == 0;\n\tif (v282) goto L_00D1;\nL_006E:\n\tgoto L_0076;\n\tgoto L_00A6;\nL_00B1:\n\tv297 = UnityEngine.Object::op_Inequality(v377, 0);\n\tv299 = ~v297;\n\tif (v299) goto L_00D1;\n\tv258 = *([v377 @ X0_v10 (UnityEngine.Object)]);\n\tv222 = *([v258 @ X8_v14 (Il2CppClass<UnityEngine.Object>)+178]);\n\tv250 = *([v258 @ X8_v14 (Il2CppClass<UnityEngine.Object>)+180]);\n\t// 193 IndirectJump v222 @ X2_v8, v377 @ X0_v10 (UnityEngine.Object), v377 @ X0_v10 (UnityEngine.Object), v250 @ X1_v11, v222 @ X2_v8, v30 @ X3, v31 @ X4, v32 @ X5, v33 @ X6, v34 @ X7, v35 @ V0, v36 @ V1, v37 @ V2, v38 @ V3, v39 @ V4, v40 @ V5, v41 @ V6, v42 @ V7\nL_00D1:\n\treturn;\nL_00D2:\n\tthrow System.NullReferenceException;\nL_003E:\n\tv201 = *([v195 @ X10_v13-8]) == _game.CoreGameKit.UiControllers.IUiFactory;\n\tif (v201) goto L_005F;\nL_0076:\n\tv141 = _game.CoreGameKit.UiControllers.UiManager::GetFactory(this, type);\nL_00A6:\n\tv377 = _game.CoreGameKit.UiControllers.IUiFactory::Get(0, type);\n\tgoto L_00B1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Hide(Type type)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UiManager::Hide");
		}

		[Token(Token = "0x600005F")]
		[Address(RVA = "0x4234D94", Offset = "0x4234D94", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv46 = Il2CppClass<T>;\n\tgoto L_0016;\nL_0016:\n\tv57 = System.Type::GetTypeFromHandle(v46);\n\t_game.CoreGameKit.UiControllers.UiManager::Hide(this, v57, onComplete);\n\treturn;\n\tv29 = 0x220C2B8(methodInfo, onComplete, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_FFFFFFFF:\n\tv46 = Il2CppClass<T>;\n\tgoto L_0016;\n")]
		public void Hide<T>(Action onComplete) where T : UIController
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UiManager::Hide");
		}

		[Token(Token = "0x6000060")]
		[Address(RVA = "0x81A524C", Offset = "0x81A524C", Length = "0x248")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = *([B799F43]) & 1;\n\tv27 = v26 == 0;\n\tif (v27) goto L_0022;\n\tv30 = *([B799F41]) & 1;\n\tv31 = v30 == 0;\n\tif (v31) goto L_002D;\nL_0019:\n\tv75 = _game.CoreGameKit.UiControllers.UiManager::GetFactory(this, type);\n\tv68 = v75 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_0036;\n\tgoto L_00ED;\nL_0022:\n\t*([B799F43]) = 1;\n\tv66 = *([B799F41]) & 1;\n\tv67 = v66 == 0;\n\tv50 = ~v67;\n\tif (v50) goto L_0019;\nL_002D:\n\t*([B799F41]) = 1;\n\tv75 = _game.CoreGameKit.UiControllers.UiManager::GetFactory(this, type);\nL_0036:\n\tv83 = *([v75 @ X0_v3 (_game.CoreGameKit.UiControllers.IUiFactory)]);\n\tv201 = *([v83 @ X8_v4 (Il2CppClass<_game.CoreGameKit.UiControllers.IUiFactory>)+12E]);\n\tv85 = *([v83 @ X8_v4 (Il2CppClass<_game.CoreGameKit.UiControllers.IUiFactory>)+12E]) == 0;\n\tif (v85) goto L_005A;\n\tv200 = *([v83 @ X8_v4 (Il2CppClass<_game.CoreGameKit.UiControllers.IUiFactory>)+B0]) + 8;\n\tv200 = v200 + 0x10;\n\tv186 = v201 - 1;\n\tv166 = v201 != 1;\n\tv201 = v186;\n\tif (v166) goto L_0041;\nL_005A:\n\t;\n\tv216 = _game.CoreGameKit.UiControllers.IUiFactory::Exist(v75, type);\n\tv217 = v216 & 1;\n\tv218 = v217 == 0;\n\tif (v218) goto L_00A2;\nL_0065:\n\tgoto L_006D;\n\tgoto L_00B9;\nL_0096:\n\tv313 = *([v200 @ X10_v15]) + 4;\n\tv314 = v313 << 4;\n\tv315 = v83 + v314;\n\tv316 = v315 + 0x138;\n\t*([v316 @ X8_v23])(v320, v75, type, *([v316 @ X8_v23+8]), methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv321 = v320 & 1;\n\tv322 = v321 == 0;\n\tv323 = ~v322;\n\tif (v323) goto L_0065;\nL_00A2:\n\tv352 = onComplete == 0;\n\tif (v352) goto L_00EC;\nL_00B0:\n\tSystem.Action::Invoke(onComplete);\nL_00B0:\n\treturn;\nL_00C4:\n\tv448 = UnityEngine.Object::op_Inequality(v440, 0);\n\tv450 = ~v448;\n\tif (v450) goto L_00E0;\n\tv289 = *([v440 @ X0_v13 (UnityEngine.Object)]);\n\tv223 = *([v289 @ X8_v16 (Il2CppClass<UnityEngine.Object>)+188]);\n\tv237 = *([v289 @ X8_v16 (Il2CppClass<UnityEngine.Object>)+190]);\n\t// 215 IndirectJump v223 @ X3_v1, v440 @ X0_v13 (UnityEngine.Object), v440 @ X0_v13 (UnityEngine.Object), onComplete @ X2 (System.Action), v237 @ X2_v12, v223 @ X3_v1, v36 @ X4, v37 @ X5, v38 @ X6, v39 @ X7, v40 @ V0, v41 @ V1, v42 @ V2, v43 @ V3, v44 @ V4, v45 @ V5, v46 @ V6, v47 @ V7\nL_00E0:\n\tv458 = onComplete == 0;\n\tv365 = ~v458;\n\tif (v365) goto L_00B0;\nL_00EC:\n\treturn;\nL_00ED:\n\tthrow System.NullReferenceException;\nL_0041:\n\tv206 = *([v200 @ X10_v15-8]) == _game.CoreGameKit.UiControllers.IUiFactory;\n\tif (v206) goto L_0096;\nL_006D:\n\tv146 = _game.CoreGameKit.UiControllers.UiManager::GetFactory(this, type);\nL_00B9:\n\tv440 = _game.CoreGameKit.UiControllers.IUiFactory::Get(0, type);\n\tgoto L_00C4;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Hide(Type type, Action onComplete)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UiManager::Hide");
		}

		[Token(Token = "0x6000061")]
		[Address(RVA = "0x81A4C00", Offset = "0x81A4C00", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv48 = *([v43 @ X21_v2 (_game.CoreGameKit.UiControllers.IUiFactoryDataStore)]);\n\tv143 = *([v48 @ X8_v6 (Il2CppClass<_game.CoreGameKit.UiControllers.IUiFactoryDataStore>)+12E]);\n\tv50 = *([v48 @ X8_v6 (Il2CppClass<_game.CoreGameKit.UiControllers.IUiFactoryDataStore>)+12E]) == 0;\n\tif (v50) goto L_0040;\n\tv98 = *([v48 @ X8_v6 (Il2CppClass<_game.CoreGameKit.UiControllers.IUiFactoryDataStore>)+B0]) + 8;\n\tv98 = v98 + 0x10;\n\tv130 = v143 - 1;\n\tv120 = v143 != 1;\nL_FFFFFFFF:\n\tv143 = v130;\n\tif (v120) goto L_0026;\nL_0040:\n\tv211 = _game.CoreGameKit.UiControllers.IUiFactoryDataStore::GetUiConfig(v43, type);\nL_004F:\n\tv155 = *([v211 @ X0_v4+28]) != 1;\n\tif (v155) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv188 = 0x18;\n\tgoto L_005D;\nL_FFFFFFFF:\n\tv188 = 0x20;\nL_005F:\n\tv56 = *([v98 @ X10_v6]) << 4;\n\tv198 = v48 + v56;\n\tv199 = v198 + 0x138;\n\t*([v199 @ X0_v10])(v211, v43, type, *([v199 @ X0_v10+8]), v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv201 = v211 == 0;\n\tv112 = ~v201;\n\tif (v112) goto L_004F;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\nL_0015:\n\tv43 = this._dataStore;\nL_0026:\n\tv82 = *([v98 @ X10_v6-8]) == _game.CoreGameKit.UiControllers.IUiFactoryDataStore;\n\tif (v82) goto L_005F;\nL_005D:\n\treturn *([this @ X0 (_game.CoreGameKit.UiControllers.UiManager)+v188 @ X8_v10 (System.Int32)]);\n")]
		private IUiFactory GetFactory(Type type)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UiManager::GetFactory");
			return default;
		}

		[Token(Token = "0x6000062")]
		[Address(RVA = "0x81A5494", Offset = "0x81A5494", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = canvasLocation != 1;\n\tif (v12) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv15 = 0x18;\n\tgoto L_0012;\nL_FFFFFFFF:\n\tv15 = 0x20;\nL_0012:\n\treturn *([this @ X0 (_game.CoreGameKit.UiControllers.UiManager)+v15 @ X8_v2 (System.Int32)]);\n")]
		public IUiFactory GetFactory(CanvasLocation canvasLocation)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UiManager::GetFactory");
			return default;
		}

		[Token(Token = "0x6000063")]
		[Address(RVA = "0x4234C64", Offset = "0x4234C64", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_000E;\n\tv18 = 0x220C2B8(methodInfo, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_000E:\n\tv34 = this._dataStore;\n\tv37 = Il2CppMethodInfo;\n\tv40 = *([v34 @ X19_v2 (_game.CoreGameKit.UiControllers.IUiFactoryDataStore)]);\n\tv94 = *([v40 @ X8_v3 (Il2CppClass<_game.CoreGameKit.UiControllers.IUiFactoryDataStore>)+12E]);\n\tv42 = *([v40 @ X8_v3 (Il2CppClass<_game.CoreGameKit.UiControllers.IUiFactoryDataStore>)+12E]) == 0;\n\tif (v42) goto L_0034;\n\tv93 = *([v40 @ X8_v3 (Il2CppClass<_game.CoreGameKit.UiControllers.IUiFactoryDataStore>)+B0]) + 8;\n\tv93 = v93 + 0x10;\n\tv80 = v94 - 1;\n\tv50 = v94 != 1;\n\tv94 = v80;\n\tif (v50) goto L_0020;\nL_0034:\n\tv82 = 0x220C5E0(v34, Il2CppClass<_game.CoreGameKit.UiControllers.IUiFactoryDataStore>, *([v37 @ X20_v2 (Il2CppMethodInfo)+50]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0046;\nL_0020:\n\tv99 = *([v93 @ X10_v5-8]) == Il2CppClass<_game.CoreGameKit.UiControllers.IUiFactoryDataStore>;\n\tif (v99) goto L_0046;\nL_0046:\n\tv34 = _game.CoreGameKit.UiControllers.IUiFactoryDataStore::GetUiConfig(v34);\nL_0046:\n\treturn v34;\n")]
		public UIConfig GetUiConfig<T>() where T : UIController
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UiManager::GetUiConfig");
			return default;
		}

		[Token(Token = "0x6000064")]
		[Address(RVA = "0x81A54AC", Offset = "0x81A54AC", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv74 = new System.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>();\n\tSystem.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>::.ctor(v74);\n\tv80.s_raycastAppendResults = v74;\n\treturn;\nL_002C:\n\tv57 = new System.Collections.Generic.List`1<UnityEngine.UI.GraphicRaycaster>();\n\tSystem.Collections.Generic.List`1<UnityEngine.UI.GraphicRaycaster>::.ctor(v57);\n\tv67._raycasters = v57;\n")]
		static UiManager()
		{
			List<GraphicRaycaster> raycasters = new List<GraphicRaycaster>();
			_raycasters = raycasters;
			List<RaycastResult> list = new List<RaycastResult>();
			s_raycastAppendResults = list;
		}
	}
}
