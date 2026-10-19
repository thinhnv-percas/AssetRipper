using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.ContainerSystem.Runtime;
using Unco.Extensions;
using UnityEngine;
using UnityEngine.EventSystems;
using _game.CoreGameKit.UiControllers.ScriptableObjects;

namespace _game.CoreGameKit.UiControllers
{
	[Token(Token = "0x2000009")]
	public class UIFactory : MonoBehaviour, IDisposable, IUiFactory
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200000A")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000017")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000018")]
			public static Func<RaycastResult, bool> _003C_003E9__32_0;

			[Token(Token = "0x6000038")]
			[Address(RVA = "0x81A416C", Offset = "0x81A416C", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreGameKit.UiControllers.UIFactory+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000039")]
			[Address(RVA = "0x81A41D0", Offset = "0x81A41D0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal bool _003CCheckUIObject_003Eb__32_0(RaycastResult result)
			{
				Canvas componentInParent = result.gameObject.GetComponentInParent<Canvas>();
				RenderMode renderMode = componentInParent.renderMode;
				int num = (int)(renderMode - 2);
				bool flag = num == 0;
				return !flag;
			}
		}

		[Inject(false)]
		[Token(Token = "0x4000011")]
		[FieldOffset(Offset = "0x20")]
		private Instancer _instancer;

		[Inject(false)]
		[Token(Token = "0x4000012")]
		[FieldOffset(Offset = "0x28")]
		internal UIFactoryDataStore _dataStore;

		[Token(Token = "0x4000013")]
		[FieldOffset(Offset = "0x30")]
		internal IUiAnalytics _analytics;

		[SerializeField]
		[Token(Token = "0x4000014")]
		[FieldOffset(Offset = "0x38")]
		private Canvas _canvas;

		[SerializeField]
		[Token(Token = "0x4000015")]
		[FieldOffset(Offset = "0x40")]
		private RectTransform _rectTransform;

		[Token(Token = "0x4000016")]
		[FieldOffset(Offset = "0x48")]
		public List<LocationData> LocationDataList;

		[Token(Token = "0x17000001")]
		public Canvas Canvas
		{
			[Token(Token = "0x600001A")]
			[Address(RVA = "0x81A2174", Offset = "0x81A2174", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Canvas;\n")]
			get
			{
				return _canvas;
			}
		}

		[Token(Token = "0x17000002")]
		public RectTransform RectTransform
		{
			[Token(Token = "0x600001B")]
			[Address(RVA = "0x81A217C", Offset = "0x81A217C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.RectTransform;\n")]
			get
			{
				return _rectTransform;
			}
		}

		[Token(Token = "0x17000003")]
		public static bool IsPointerOverUIObject
		{
			[Token(Token = "0x6000030")]
			[Address(RVA = "0x81A3BE0", Offset = "0x81A3BE0", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreGameKit.UiControllers.UIFactory::CheckUIObject();\n\treturn returnVal1;\n")]
			get
			{
				return CheckUIObject();
			}
		}

		[Token(Token = "0x600001C")]
		[Address(RVA = "0x81A2184", Offset = "0x81A2184", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._analytics = analytics;\n\treturn;\n")]
		public void SetAnalytics(IUiAnalytics analytics)
		{
			_analytics = analytics;
		}

		[Token(Token = "0x600001D")]
		[Address(RVA = "0x81A218C", Offset = "0x81A218C", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = *([B799F15]) & 1;\n\tv21 = v20 == 0;\n\tif (v21) goto L_0030;\n\tv24 = UnityEngine.Component::get_gameObject(this);\n\tv53 = v24;\n\tgoto L_0018;\nL_0018:\n\tv59 = UnityEngine.Object::op_Implicit(v53);\n\tv69 = ~v59;\n\tif (v69) goto L_0049;\n\tv82 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_002A;\nL_002A:\n\tUnityEngine.Object::Destroy(v82);\n\treturn;\nL_0030:\n\t*([B799F15]) = 1;\n\tv49 = UnityEngine.Component::get_gameObject(this);\n\tv53 = v49;\n\tgoto L_0018;\nL_0049:\n\treturn;\n")]
		public void Dispose()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B799F15]");
			UnityEngine.Object obj;
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				GameObject gameObject = base.gameObject;
				obj = gameObject;
			}
			else
			{
				_ = 1;
				GameObject gameObject2 = base.gameObject;
				obj = gameObject2;
			}
			if ((bool)obj)
			{
				GameObject obj2 = base.gameObject;
				UnityEngine.Object.Destroy(obj2);
			}
		}

		[Token(Token = "0x600001E")]
		[Address(RVA = "0x81A2280", Offset = "0x81A2280", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreGameKit.UiControllers.UIFactory::Show(this, type, 0);\n\treturn returnVal1;\n")]
		public UIController Show(Type type)
		{
			return Show(type, null);
		}

		[Token(Token = "0x600001F")]
		[Address(RVA = "0x81A2288", Offset = "0x81A2288", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = 0xB799000;\n\tv24 = *([B799F16]) & 1;\n\tv25 = v24 == 0;\n\tif (v25) goto L_003D;\n\tv27 = _game.CoreGameKit.UiControllers.UIFactory::CreateUiController(this, type, customInstancer);\n\tv103 = v27;\n\tgoto L_001C;\nL_001C:\n\tv73 = UnityEngine.Object::op_Equality(v103, 0);\n\tv86 = ~v73;\n\tv87 = ~v86;\n\tv145 = v103;\n\tif (v87) goto L_0054;\n\tv145 = v103;\nL_002C:\n\treturnVal1 = _game.CoreGameKit.UiControllers.UIController::Show(v145);\n\treturn returnVal1;\nL_003D:\n\t*([v20 @ X20_v1+F16]) = 1;\n\tv94 = _game.CoreGameKit.UiControllers.UIFactory::CreateUiController(this, type, customInstancer);\n\tv103 = v94;\n\tgoto L_001C;\nL_0054:\n\tv120 = System.String::Format(\"[UI] {0} Ui controller is not found\", type);\n\tgoto L_005A;\nL_005A:\n\tUnityEngine.Debug::LogError(v120);\n\tv178 = v103 == 0;\n\tv138 = ~v178;\n\tv146 = v103;\n\tif (v138) goto L_002C;\nL_005E:\n\tv172 = new System.NullReferenceException();\n\tUnityEngine.Debug::LogError(v172);\n\tv179 = v146 == 0;\n\tv139 = ~v179;\n\tv145 = v146;\n\tif (v139) goto L_002C;\n\tv146 = v103;\n\tgoto L_005E;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public UIController Show(Type type, Instancer customInstancer)
		{
			//IL_0009: Expected O, but got I4
			object obj = 192516096;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B799F16]");
			UIController uIController2;
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				UIController uIController = CreateUiController(type, customInstancer);
				uIController2 = uIController;
			}
			else
			{
				_ = 1;
				UIController uIController3 = CreateUiController(type, customInstancer);
				uIController2 = uIController3;
			}
			bool flag = uIController2 == null;
			bool flag2 = !flag;
			bool flag3 = !flag2;
			UIController uIController4 = uIController2;
			if (!flag3)
			{
				uIController4 = uIController2;
			}
			else
			{
				string message = $"[UI] {type} Ui controller is not found";
				Debug.LogError(message);
				bool flag4 = (object)uIController2 == null;
				bool flag5 = !flag4;
				UIController uIController5 = uIController2;
				if (!flag5)
				{
					while (true)
					{
						NullReferenceException message2 = new NullReferenceException();
						Debug.LogError(message2);
						bool flag6 = (object)uIController5 == null;
						bool flag7 = !flag6;
						uIController4 = uIController5;
						if (flag7)
						{
							break;
						}
						uIController5 = uIController2;
					}
				}
			}
			return uIController4.Show();
		}

		[Token(Token = "0x6000020")]
		[Address(RVA = "0x81A25F0", Offset = "0x81A25F0", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreGameKit.UiControllers.UIFactoryDataStore::GetUiControllerFromScene(this._dataStore, type);\n\treturn returnVal1;\n")]
		public UIController Get(Type type)
		{
			return _dataStore.GetUiControllerFromScene(type);
		}

		[Token(Token = "0x6000021")]
		[Address(RVA = "0x81A27A0", Offset = "0x81A27A0", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001B:\n\tv50 = _game.CoreGameKit.UiControllers.UIFactoryDataStore::GetUiControllerFromScene(this._dataStore, v40);\n\tgoto L_0029;\nL_0029:\n\treturnVal2 = UnityEngine.Object::op_Inequality(v50, 0);\n\treturn returnVal2;\n")]
		public bool Exist(Type type)
		{
			Type type2 = default(Type);
			UIController uiControllerFromScene = _dataStore.GetUiControllerFromScene(type2);
			return uiControllerFromScene != null;
		}

		[Token(Token = "0x6000022")]
		[Address(RVA = "0x81A2840", Offset = "0x81A2840", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv61 = _game.CoreGameKit.UiControllers.UIController::Show(v53);\n\treturn;\nL_001C:\n\tv53 = _game.CoreGameKit.UiControllers.UIFactory::InstantiateConfig(v46, v43, 0);\n")]
		private void GetCanvasButton(UIConfig config)
		{
			UIConfig config2 = default(UIConfig);
			UIController uIController = InstantiateConfig<UIController>(config2);
			UIController uIController2 = uIController.Show();
		}

		[Token(Token = "0x6000023")]
		[Address(RVA = "0x4232AA0", Offset = "0x4232AA0", Length = "0x174")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\nL_0025:\n\tv58 = UnityEngine.Object::get_name(uiController);\n\tv157 = System.String::Concat(v58, \" Show\");\n\tgoto L_0033;\n\tv160 = _game.CoreGameKit.UiControllers.UIFactoryDataStore::GetUiConfig(this._dataStore, uiController);\n\tv161 = this._analytics == 0;\n\tif (v161) goto L_0077;\n\tv72 = System.Object::GetType(uiController);\n\tgoto L_0073;\nL_0033:\n\tUnityEngine.Debug::Log(v157);\nL_0077:\n\t_game.CoreGameKit.UiControllers.UIFactory::AddUiConfigToOrder(this, v160);\n\t_game.CoreGameKit.UiControllers.UIFactory::ReorderActiveUis(this);\n\treturn;\nL_0073:\n\t_game.CoreGameKit.UiControllers.IUiAnalytics::TrackUiShow(this._analytics, v72, v160.UseElephantEvent);\n")]
		public void Internal_Show<T>(T uiController) where T : UIController
		{
			string text = uiController.name;
			string message = text + " Show";
			Debug.Log(message);
			UIConfig uiConfig = _dataStore.GetUiConfig(uiController);
			if (_analytics != null)
			{
				Type type = uiController.GetType();
				_analytics.TrackUiShow(type, uiConfig.UseElephantEvent);
			}
			AddUiConfigToOrder(uiConfig);
			ReorderActiveUis();
		}

		[Token(Token = "0x6000024")]
		[Address(RVA = "0x81A1C00", Offset = "0x81A1C00", Length = "0x218")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tgoto L_001C;\nL_001C:\n\tv59 = UnityEngine.Object::op_Equality(uiController, 0);\n\tv67 = ~v59;\n\tif (v67) goto L_0057;\n\tv94 = System.Object::GetType(uiController);\n\tv129 = System.String::Format(\"[UI] {0} UI controller not found\", v94);\n\tgoto L_003A;\nL_003A:\n\tUnityEngine.Debug::LogError(v129);\n\treturn;\nL_0057:\n\tv87 = ~shouldRemove;\n\tif (v87) goto L_005F;\n\t_game.CoreGameKit.UiControllers.UIFactoryDataStore::RemoveFromScene(this._dataStore, uiController);\nL_005F:\n\tv121 = this._analytics == 0;\n\tif (v121) goto L_00C0;\n\tv103 = _game.CoreGameKit.UiControllers.UIFactoryDataStore::GetUiConfig(this._dataStore, uiController);\n\tv104 = System.Object::GetType(uiController);\n\tgoto L_00B2;\nL_00C0:\n\t_game.CoreGameKit.UiControllers.UIFactory::HideUiController(this, uiController, 0, onComplete);\n\treturn;\nL_00B2:\n\t_game.CoreGameKit.UiControllers.IUiAnalytics::TrackUiHide(this._analytics, v104, v103.UseElephantEvent);\n")]
		public void Hide(UIController uiController, bool shouldRemove = true, Action onComplete = null)
		{
			if (uiController == null)
			{
				Type type = uiController.GetType();
				string message = $"[UI] {type} UI controller not found";
				Debug.LogError(message);
				return;
			}
			if (shouldRemove)
			{
				_dataStore.RemoveFromScene(uiController);
			}
			if (_analytics != null)
			{
				UIConfig uiConfig = _dataStore.GetUiConfig(uiController);
				Type type2 = uiController.GetType();
				_analytics.TrackUiHide(type2, uiConfig.UseElephantEvent);
			}
			Hide(uiController, shouldRemove: false, onComplete);
		}

		[Token(Token = "0x6000025")]
		[Address(RVA = "0x81A1BE8", Offset = "0x81A1BE8", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreGameKit.UiControllers.UIFactoryDataStore::RemoveFromScene(this._dataStore, uiController);\n\treturn;\n")]
		public void RemoveFromScene(UIController uiController)
		{
			_dataStore.RemoveFromScene(uiController);
		}

		[Token(Token = "0x6000026")]
		[Address(RVA = "0x81A1F58", Offset = "0x81A1F58", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv53 = UnityEngine.Object::op_Equality(uiController, 0);\n\tv61 = ~v53;\n\tif (v61) goto L_0052;\n\tv88 = System.Object::GetType(uiController);\n\tv101 = System.String::Format(\"[UI] {0} UI controller not found\", v88);\n\tgoto L_0034;\nL_0034:\n\tUnityEngine.Debug::LogError(v101);\n\treturn;\nL_0052:\n\t_game.CoreGameKit.UiControllers.UIFactoryDataStore::RemoveFromScene(this._dataStore, uiController);\n\t_game.CoreGameKit.UiControllers.UIFactory::HideUiController(this, uiController, 1, 0);\n\treturn;\n")]
		public void ForceHide(UIController uiController)
		{
			if (uiController == null)
			{
				Type type = uiController.GetType();
				string message = $"[UI] {type} UI controller not found";
				Debug.LogError(message);
			}
			else
			{
				_dataStore.RemoveFromScene(uiController);
				Hide(uiController);
			}
		}

		[Token(Token = "0x6000027")]
		[Address(RVA = "0x81A2AB4", Offset = "0x81A2AB4", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0020:\n\tv55 = _game.CoreGameKit.UiControllers.UIFactoryDataStore::GetUiConfig(this._dataStore, uiController);\n\tv55._uiController = 0;\n\tv108 = _game.CoreGameKit.UiControllers.UIController::Destroy(uiController);\n\t_game.CoreGameKit.UiControllers.UIFactory::ReorderActiveUis(this);\n\tv110 = onComplete == 0;\n\tif (v110) goto L_003C;\n\tSystem.Action::Invoke(onComplete);\nL_004E:\n\tUnityEngine.Debug::Log(v80);\n\treturn;\nL_003C:\n\tv124 = UnityEngine.Object::get_name(uiController);\n\tv80 = System.String::Concat(v124, \" Hide\");\n\tgoto L_004E;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void HideUiController(UIController uiController, bool force, Action onComplete = null)
		{
			UIConfig uiConfig = _dataStore.GetUiConfig(uiController);
			uiConfig._uiController = null;
			uiController.Destroy();
			ReorderActiveUis();
			onComplete?.Invoke();
			string text = uiController.name;
			string message = text + " Hide";
			Debug.Log(message);
		}

		[Token(Token = "0x6000028")]
		[Address(RVA = "0x81A2BD8", Offset = "0x81A2BD8", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = _game.CoreGameKit.UiControllers.UIController::Destroy(uiController);\n\t_game.CoreGameKit.UiControllers.UIFactory::ReorderActiveUis(this);\n\tv37 = onComplete == 0;\n\tif (v37) goto L_0022;\n\tSystem.Action::Invoke(onComplete);\n\treturn;\nL_0022:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DestroyUiController(UIController uiController, Action onComplete)
		{
			uiController.Destroy();
			ReorderActiveUis();
			onComplete?.Invoke();
		}

		[Token(Token = "0x6000029")]
		[Address(RVA = "0x81A2C38", Offset = "0x81A2C38", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreGameKit.UiControllers.UIController::Destroy(v5);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Destroy(UIController uiController)
		{
			UIController uIController = default(UIController);
			uIController.Destroy();
		}

		[Token(Token = "0x600002A")]
		[Address(RVA = "0x81A23C8", Offset = "0x81A23C8", Length = "0x228")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\nL_002D:\n\tv57 = _game.CoreGameKit.UiControllers.UIFactoryDataStore::GetUiControllerFromScene(this._dataStore, type);\n\tgoto L_0035;\nL_0035:\n\tv105 = UnityEngine.Object::op_Implicit(v57);\n\tv162 = ~v105;\n\tif (v162) goto L_0055;\n\t_game.CoreGameKit.UiControllers.UIFactoryDataStore::UpdateOrderInScene(this._dataStore, v57);\n\treturn v57;\nL_0055:\n\tv175 = _game.CoreGameKit.UiControllers.UIFactoryDataStore::GetUiConfig(this._dataStore, type);\n\tgoto L_005D;\nL_005D:\n\tv181 = UnityEngine.Object::op_Implicit(v175);\n\tv184 = v181 == 0;\n\tif (v184) goto L_0098;\n\tv73 = _game.CoreGameKit.UiControllers.UIFactory::InstantiateConfig(this, v175, customInstancer);\n\tv210 = UnityEngine.Component::GetComponent(v73);\n\tv74 = UnityEngine.SortingLayer::NameToID(\"Ui\");\n\tUnityEngine.Canvas::set_sortingLayerID(v210, v74);\n\t_game.CoreGameKit.UiControllers.UIFactoryDataStore::AddToScene(this._dataStore, v73);\n\treturn v73;\nL_0098:\n\tv214 = System.String::Format(\"[UI] {0} Ui config not found\", type);\n\tgoto L_00A5;\nL_00A5:\n\tUnityEngine.Debug::LogError(v214);\n\treturn 0;\n")]
		private UIController CreateUiController(Type type, Instancer customInstancer = null)
		{
			UIController uiControllerFromScene = _dataStore.GetUiControllerFromScene(type);
			if ((bool)uiControllerFromScene)
			{
				_dataStore.UpdateOrderInScene(uiControllerFromScene);
				return uiControllerFromScene;
			}
			UIConfig uiConfig = _dataStore.GetUiConfig(type);
			if ((bool)uiConfig)
			{
				UIController uIController = InstantiateConfig<UIController>(uiConfig, customInstancer);
				Canvas component = uIController.GetComponent<Canvas>();
				int sortingLayerID = SortingLayer.NameToID("Ui");
				component.sortingLayerID = sortingLayerID;
				_dataStore.AddToScene(uIController);
				return uIController;
			}
			string message = $"[UI] {type} Ui config not found";
			Debug.LogError(message);
			return null;
		}

		[Token(Token = "0x600002B")]
		[Address(RVA = "0x4232940", Offset = "0x4232940", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tgoto L_0018;\nL_0018:\n\tv49 = customInstancer == 0;\n\tv50 = ~v49;\n\tv60 = customInstancer;\n\tif (v50) goto L_0022;\nL_001B:\n\tv60 = this._instancer;\nL_0022:\n\tv68 = _game.CoreGameKit.UiControllers.UIFactory::GetLocation(this, config.Location);\n\tv102 = _game.CoreGameKit.UiControllers.ScriptableObjects.UIConfig::LoadUIController(config);\n\tv103 = Unco.ContainerSystem.Runtime.Instancer::Instantiate(v60, v102, v68.Root, 1);\n\tv104 = UnityEngine.Component::get_gameObject(v103);\n\tv105 = UnityEngine.Component::get_gameObject(v68.Root);\n\tv177 = UnityEngine.GameObject::get_layer(v105);\n\tUnco.Extensions.TransformExtensions::SetLayerRecursive(v104, v177);\n\tv103._baseFactory = this;\n\t_game.CoreGameKit.UiControllers.UIFactory::CheckOverrideOrder(config, v103);\n\tgoto L_0060;\n\treturn returnVal2;\n\tv52 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv116 = customInstancer == 0;\n\tv54 = ~v116;\n\tv60 = customInstancer;\n\tif (v54) goto L_0022;\n\tgoto L_001B;\nL_0076:\n\treturnVal1 = new System.InvalidCastException();\n\treturn returnVal1;\nL_0060:\n\treturnVal2 = 0x21C11D0(v103, Il2CppClass<T>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv135 = returnVal2 == 0;\n\tif (v135) goto L_0076;\n")]
		private T InstantiateConfig<T>(UIConfig config, Instancer customInstancer = null) where T : UIController
		{
			bool flag = customInstancer == null;
			bool flag2 = !flag;
			Instancer instancer = customInstancer;
			if (!flag2)
			{
				instancer = _instancer;
			}
			LocationData location = GetLocation(config.Location);
			UIController prefab = config.LoadUIController();
			UIController uIController = instancer.Instantiate(prefab, location.Root);
			GameObject go = uIController.gameObject;
			GameObject gameObject = location.Root.gameObject;
			int layer = gameObject.layer;
			go.SetLayerRecursive(layer);
			uIController._baseFactory = this;
			CheckOverrideOrder(config, uIController);
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
			T val = default(T);
			if ((object)val != null)
			{
				return val;
			}
			return (T)(object)new InvalidCastException();
		}

		[Token(Token = "0x600002C")]
		[Address(RVA = "0x81A2C5C", Offset = "0x81A2C5C", Length = "0x4A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\n\tv63 = v58._uiControllerOrder;\n\tv288 = v63.Count < 1;\n\tif (v288) goto L_008A;\n\tv378 = 0;\n\tv155 = 0;\n\tgoto L_0061;\nL_0051:\n\tv155 = v155 + 1;\n\tv380 = v155 >= v63.Count;\n\tif (v380) goto L_008A;\nL_0061:\n\tv405 = System.Collections.Generic.List`1<_game.CoreGameKit.UiControllers.UIController>::get_Item(v63, v155);\n\tv413 = _game.CoreGameKit.UiControllers.UIFactoryDataStore::GetSceneElement(this._dataStore, v405);\n\tgoto L_006F;\nL_006F:\n\tv428 = UnityEngine.Object::op_Inequality(v413, 0);\n\tv435 = ~v428;\n\tif (v435) goto L_0051;\n\tgoto L_007E;\nL_007E:\n\tv235 = UnityEngine.Component::GetComponent(v413);\n\tv440 = v378 + 1;\n\tUnityEngine.Canvas::set_sortingOrder(v235, v378);\n\tv378 = v440;\n\tgoto L_0051;\nL_008A:\n\tv236 = _game.CoreGameKit.UiControllers.UIFactory::GetLocation(this, 0);\n\tv348 = UnityEngine.Transform::get_childCount(v236.Root);\n\tv320 = v348 < 1;\n\tif (v320) goto L_01BE;\n\tv154 = 0;\n\tgoto L_00B9;\nL_00A7:\n\tv154 = v154 + 1;\n\tv349 = UnityEngine.Transform::get_childCount(v236.Root);\n\tv321 = v154 >= v349;\n\tif (v321) goto L_01BE;\nL_00B9:\n\tv237 = UnityEngine.Transform::GetChild(v236.Root, v154);\n\tv448 = UnityEngine.Component::TryGetComponent(v237, &v84 @ stack_-68_v5 (UnityEngine.Canvas));\n\tv450 = ~v448;\n\tif (v450) goto L_00A7;\n\tv454 = UnityEngine.Component::TryGetComponent(v237, &v81 @ stack_-70_v5 (_game.CoreGameKit.UiControllers.UIController));\n\tv506 = ~v454;\n\tif (v506) goto L_00A7;\n\tv239 = System.Object::GetType(v81);\n\tv520 = _game.CoreGameKit.UiControllers.UIFactoryDataStore::GetUiControllerFromScene(this._dataStore, v239);\n\tgoto L_00DB;\nL_00DB:\n\tv500 = UnityEngine.Object::op_Inequality(v520, 0);\n\tv507 = ~v500;\n\tif (v507) goto L_00A7;\n\tgoto L_00EC;\nL_00EC:\n\tv534 = UnityEngine.Component::GetComponentInChildren(v237);\n\tgoto L_00F5;\nL_00F5:\n\tv502 = UnityEngine.Object::op_Inequality(v534, 0);\n\tv509 = ~v502;\n\tif (v509) goto L_00A7;\n\tgoto L_0102;\nL_0102:\n\tv504 = UnityEngine.Transform::get_childCount(v236.Root);\n\tv473 = v504 < 1;\n\tif (v473) goto L_00A7;\n\tv144 = 0;\n\tgoto L_012F;\nL_0114:\n\tv645 = UnityEngine.GameObject::AddComponent(v232);\n\tv72 = v645;\nL_0119:\n\tv72.Distancer = v534;\nL_011D:\n\tv144 = v144 + 1;\n\tv505 = UnityEngine.Transform::get_childCount(v236.Root);\n\tv474 = v144 >= v505;\n\tif (v474) goto L_00A7;\nL_012F:\n\tv555 = UnityEngine.Transform::GetChild(v236.Root, v144);\n\tgoto L_0138;\nL_0138:\n\tv561 = UnityEngine.Object::op_Equality(v555, v237);\n\tv564 = v561 == 0;\n\tv565 = ~v564;\n\tif (v565) goto L_011D;\n\tgoto L_014C;\nL_014C:\n\tv605 = UnityEngine.Component::TryGetComponent(v555, &v66 @ stack_-78_v6 (UnityEngine.Canvas));\n\tv609 = ~v605;\n\tif (v609) goto L_011D;\n\tv616 = UnityEngine.Canvas::get_sortingOrder(v66);\n\tv617 = UnityEngine.Canvas::get_sortingOrder(v84);\n\tv164 = v616 <= v617;\n\tif (v164) goto L_017C;\nL_016B:\n\tv629 = UnityEngine.Component::GetComponent(v555);\n\tgoto L_0174;\nL_0174:\n\tv636 = UnityEngine.Object::op_Equality(v629, 0);\n\tv638 = ~v636;\n\tv72 = v629;\n\tif (v638) goto L_0119;\n\tgoto L_01AC;\nL_017C:\n\tv632 = UnityEngine.Canvas::get_sortingOrder(v66);\n\tv606 = UnityEngine.Canvas::get_sortingOrder(v84);\n\tv577 = v632 != v606;\n\tif (v577) goto L_011D;\n\tv657 = UnityEngine.Transform::GetSiblingIndex(v555);\n\tv607 = UnityEngine.Transform::GetSiblingIndex(v237);\n\tv578 = v657 <= v607;\n\tif (v578) goto L_011D;\n\tgoto L_016B;\nL_01AC:\n\tv232 = UnityEngine.Component::get_gameObject(v555);\n\tv658 = v232 == 0;\n\tv247 = ~v658;\n\tif (v247) goto L_0114;\n\tthrow System.NullReferenceException;\nL_01BE:\n\treturn;\nL_0035:\n\tv58 = this._dataStore;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ReorderActiveUis()
		{
			UIFactoryDataStore dataStore = _dataStore;
			List<UIController> uiControllerOrder = dataStore._uiControllerOrder;
			if (uiControllerOrder.Count >= 1)
			{
				int num = 0;
				int num2 = 0;
				do
				{
					UIController controller = uiControllerOrder[num2];
					UIController sceneElement = _dataStore.GetSceneElement(controller);
					if (sceneElement != null)
					{
						Canvas component = sceneElement.GetComponent<Canvas>();
						int num3 = num + 1;
						component.sortingOrder = num;
						num = num3;
					}
					num2++;
				}
				while (num2 < uiControllerOrder.Count);
			}
			LocationData location = GetLocation(default(UILocation));
			int childCount = location.Root.childCount;
			if (childCount < 1)
			{
				return;
			}
			int num4 = 0;
			int childCount4;
			do
			{
				Transform child = location.Root.GetChild(num4);
				if (child.TryGetComponent<Canvas>(out var component2) && child.TryGetComponent<UIController>(out var component3))
				{
					Type type = component3.GetType();
					UIController uiControllerFromScene = _dataStore.GetUiControllerFromScene(type);
					if (uiControllerFromScene != null)
					{
						DistancerUiObject componentInChildren = child.GetComponentInChildren<DistancerUiObject>();
						if (componentInChildren != null)
						{
							int childCount2 = location.Root.childCount;
							if (childCount2 >= 1)
							{
								int num5 = 0;
								int childCount3;
								do
								{
									Transform child2 = location.Root.GetChild(num5);
									if (!(child2 == child) && child2.TryGetComponent<Canvas>(out var component4))
									{
										int sortingOrder = component4.sortingOrder;
										int sortingOrder2 = component2.sortingOrder;
										if (sortingOrder > sortingOrder2)
										{
											goto IL_041d;
										}
										int sortingOrder3 = component4.sortingOrder;
										int sortingOrder4 = component2.sortingOrder;
										if (sortingOrder3 == sortingOrder4)
										{
											int siblingIndex = child2.GetSiblingIndex();
											int siblingIndex2 = child.GetSiblingIndex();
											if (siblingIndex > siblingIndex2)
											{
												goto IL_041d;
											}
										}
									}
									goto IL_031d;
									IL_041d:
									DistancableUiObject component5 = child2.GetComponent<DistancableUiObject>();
									bool flag = component5 == null;
									bool flag2 = !flag;
									DistancableUiObject distancableUiObject = component5;
									if (!flag2)
									{
										GameObject gameObject = child2.gameObject;
										if ((object)gameObject == null)
										{
											throw new NullReferenceException();
										}
										DistancableUiObject distancableUiObject2 = gameObject.AddComponent<DistancableUiObject>();
										distancableUiObject = distancableUiObject2;
									}
									distancableUiObject.m_distancer = componentInChildren;
									goto IL_031d;
									IL_031d:
									num5++;
									childCount3 = location.Root.childCount;
								}
								while (num5 < childCount3);
							}
						}
					}
				}
				num4++;
				childCount4 = location.Root.childCount;
			}
			while (num4 < childCount4);
		}

		[Token(Token = "0x600002D")]
		[Address(RVA = "0x81A3560", Offset = "0x81A3560", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001B:\n\tv55 = config.sortOrder;\n\tv48 = UnityEngine.Component::GetComponent(newController);\n\tUnityEngine.Canvas::set_overrideSorting(v48, v55.OverrideSortOrder);\n\tv68 = v55.OverrideSortOrder != 1;\n\tif (v68) goto L_0047;\n\tUnityEngine.Canvas::set_sortingOrder(v48, v55.SortOrder);\n\treturn;\nL_0047:\n\treturn;\n")]
		private static void CheckOverrideOrder(UIConfig config, UIController newController)
		{
			UIConfig.SortOrderer sortOrder = config.sortOrder;
			Canvas component = newController.GetComponent<Canvas>();
			component.overrideSorting = sortOrder.OverrideSortOrder;
			if (sortOrder.OverrideSortOrder)
			{
				component.sortingOrder = sortOrder.SortOrder;
			}
		}

		[Token(Token = "0x600002E")]
		[Address(RVA = "0x81A3474", Offset = "0x81A3474", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv53.location = location;\n\tv71 = new System.Predicate`1<_game.CoreGameKit.UiControllers.LocationData>();\n\tSystem.Predicate`1<_game.CoreGameKit.UiControllers.LocationData>::.ctor(v71, v53, Il2CppMethodInfo);\n\treturnVal2 = System.Collections.Generic.List`1<_game.CoreGameKit.UiControllers.LocationData>::Find(this.LocationDataList, v71);\n\treturn returnVal2;\nL_0024:\n\tv53 = new _game.CoreGameKit.UiControllers.UIFactory+<>c__DisplayClass28_0();\n\tSystem.Object::.ctor(v53);\n")]
		public LocationData GetLocation(UILocation location)
		{
			Predicate<LocationData> match = delegate(LocationData data)
			{
				int num = data.UILocation - location;
				return num == 0;
			};
			return LocationDataList.Find(match);
		}

		[Token(Token = "0x600002F")]
		[Address(RVA = "0x81A3618", Offset = "0x81A3618", Length = "0x204")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv56 = v96.sortOrder;\n\tv57 = v96.sortOrder == 0;\n\tif (v57) goto L_008C;\n\tv116 = v56.OverrideSortOrder == 0;\n\tv117 = ~v116;\n\tif (v117) goto L_0085;\n\tv100 = _game.CoreGameKit.UiControllers.ScriptableObjects.UIConfig::GetSortedConfigs(v96);\n\tv103 = v100 == 0;\n\tif (v103) goto L_008C;\n\tv246 = System.Collections.Generic.List`1<_game.CoreGameKit.UiControllers.ScriptableObjects.ConfigOrderPair>::GetEnumerator(v100);\n\tv82 = v246.Current;\n\tv74 = v246._list;\n\tv275 = v246.Current == 0;\n\tif (v275) goto L_0088;\n\tv259 = v82.Config;\n\tgoto L_0062;\nL_0067:\n\tv295 = UnityEngine.Object::op_Equality(v259._uiController, 0);\n\tv297 = v295 == 0;\n\tif (v297) goto L_006F;\n\tv299 = _game.CoreGameKit.UiControllers.ScriptableObjects.UIConfig::LoadUIController(v259);\n\tv261 = v299;\n\tgoto L_0070;\nL_006F:\n\tv261 = v259._uiController;\n\t_game.CoreGameKit.UiControllers.UIFactoryDataStore::AddControllerToOrder(this._dataStore, v261);\n\tgoto L_004A;\nL_0079:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v74 @ stack_-70_v3 (System.Collections.Generic.List`1<_game.CoreGameKit.UiControllers.ScriptableObjects.ConfigOrderPair>));\nL_0085:\n\treturn;\nL_0086:\n\tv290 = new System.NullReferenceException();\n\tv96 = Il2CppMethodInfo;\n\tgoto L_008B;\nL_0088:\n\tv278 = new System.NullReferenceException();\n\tv96 = v261;\n\tgoto L_008B;\nL_008B:\n\t// 139 Interrupt\n\tv95 = 0;\nL_009B:\n\tv123 = v96 != 1;\n\tv232 = v111;\n\tif (v123) goto L_00AD;\n\tv236 = 0x8BF5BC4(v111, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv247 = 0x8BF5BF4(v236, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v74 @ stack_-70_v3 (System.Collections.Generic.List`1<_game.CoreGameKit.UiControllers.ScriptableObjects.ConfigOrderPair>));\n\tv175 = *([v236 @ X0_v11]) == 0;\n\tif (v175) goto L_0085;\n\tv238 = new System.OutOfMemoryException();\n\tv95 = *([v236 @ X0_v11]);\n\tv232 = v238;\n\treturn;\nL_0022:\n\tv52 = v96 == 0;\n\tif (v52) goto L_008C;\nL_008C:\n\tv111 = new System.NullReferenceException();\n\tgoto L_009B;\nL_0062:\n\tgoto L_0067;\nL_0070:\n\tv265 = this._dataStore == 0;\n\tif (v265) goto L_0086;\nL_004A:\n\tv271 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v74 @ stack_-70_v3 (System.Collections.Generic.List`1<_game.CoreGameKit.UiControllers.ScriptableObjects.ConfigOrderPair>));\n\tv174 = v271 == 0;\n\tif (v174) goto L_0079;\nL_00AD:\n\tv241 = 0x39664DC(&v95 @ stack_-88 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv249 = 0x8BF0368(v232, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv225 = 0x7C03E68(v249, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n")]
		private unsafe void AddUiConfigToOrder(UIConfig config)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UIFactory::AddUiConfigToOrder");
		}

		[Token(Token = "0x6000031")]
		[Address(RVA = "0x81A3BE4", Offset = "0x81A3BE4", Length = "0x274")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\nL_0012:\n\tv49 = 0xB292000 + 0x5A0;\n\tgoto L_0018;\nL_0018:\n\tv56 = UnityEngine.EventSystems.EventSystem::get_current();\n\tv66 = *([v49 @ X21_v13 (System.Int32)]);\n\tv68 = *([v66 @ X0_v70+E4]) == 0;\n\tv129 = v56;\n\tif (v68) goto L_0061;\n\tv86 = UnityEngine.Object::op_Equality(v129, 0);\n\tv98 = v86 == 0;\n\tif (v98) goto L_0069;\nL_002F:\n\treturn 1;\nL_0061:\n\tv102 = UnityEngine.Object::op_Equality(v56, 0);\n\tv135 = v102 == 0;\n\tv111 = ~v135;\n\tv129 = v56;\n\tif (v111) goto L_002F;\nL_0069:\n\tv133 = new UnityEngine.EventSystems.PointerEventData();\n\tUnityEngine.EventSystems.PointerEventData::.ctor(v133, v129);\n\tv189 = UnityEngine.Input::get_mousePosition();\n\tv149 = UnityEngine.Input::get_mousePosition();\n\tv133.<position>k__BackingField.x = v189;\n\tv133.<position>k__BackingField.y = v149.y;\n\tv206 = new System.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>();\n\tSystem.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>::.ctor(v206);\n\tUnityEngine.EventSystems.EventSystem::RaycastAll(v129, v133, v206);\n\tgoto L_0092;\nL_0092:\n\tv243 = v222.<>9__32_0;\n\tv224 = v222.<>9__32_0 == 0;\n\tv225 = ~v224;\n\tif (v225) goto L_00C5;\n\tgoto L_00A1;\nL_00A1:\n\tgoto L_00A9;\nL_00C5:\n\treturnVal3 = System.Linq.Enumerable::Any(v206, v243);\n\treturn returnVal3;\nL_00A9:\n\tv261 = new System.Func`2<UnityEngine.EventSystems.RaycastResult, System.Boolean>();\n\tSystem.Func`2<UnityEngine.EventSystems.RaycastResult, System.Boolean>::.ctor(v261, v256.<>9, Il2CppMethodInfo);\n\tv266.<>9__32_0 = v261;\n\tv243 = v261;\n")]
		private static bool CheckUIObject()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UIFactory::CheckUIObject");
			return default;
		}

		[Token(Token = "0x6000032")]
		[Address(RVA = "0x4232C14", Offset = "0x4232C14", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv28 = 0x220C2B8(methodInfo, o, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0020:\n\tv57 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tv63 = _game.CoreGameKit.UiControllers.UIFactory::TryGet(this, v57, &v60 @ stack_-48_v2 (_game.CoreGameKit.UiControllers.UIController));\n\tgoto L_0033;\n\tv81 = 0x21C11D0(v60, Il2CppClass<T>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv99 = v81 == 0;\n\tif (v99) goto L_006C;\n\t*([o @ X1 (T&)]) = v81;\nL_FFFFFFFF:\n\tv91 = Il2CppClass<T>;\n\tgoto L_0046;\n\tv124 = 0x21C11D0(v60, v91, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv150 = v124 == 0;\n\tv87 = ~v150;\n\tif (v87) goto L_0069;\n\tthrow System.InvalidCastException;\nL_0053:\n\t*([o @ X1 (T&)]) = 0;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv91 = Il2CppClass<T>;\n\tgoto L_0046;\nL_006C:\n\treturnVal1 = new System.InvalidCastException();\n\treturn returnVal1;\nL_001C:\n\tgoto L_0020;\nL_0033:\n\tv78 = v60 == 0;\n\tif (v78) goto L_0053;\nL_0046:\n\tv121 = v60 == 0;\n\tif (v121) goto L_0069;\nL_0069:\n\treturn v63;\n")]
		public bool TryGet<T>(out T o) where T : UIController
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UIFactory::TryGet");
			o = default;
			return default;
		}

		[Token(Token = "0x6000033")]
		[Address(RVA = "0x81A3E58", Offset = "0x81A3E58", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([o @ X2 (_game.CoreGameKit.UiControllers.UIController&)]) = 0;\n\tgoto L_0020;\nL_0020:\n\tv52 = _game.CoreGameKit.UiControllers.UIFactoryDataStore::GetUiControllerFromScene(this._dataStore, type);\n\tgoto L_0027;\nL_0027:\n\treturnVal2 = UnityEngine.Object::op_Inequality(v52, 0);\n\tv96 = ~returnVal2;\n\tv97 = ~v96;\n\tif (v97) goto L_0040;\n\treturn returnVal2;\nL_0040:\n\tv111 = _game.CoreGameKit.UiControllers.UIFactory::Show(this, type, 0);\n\t*([o @ X2 (_game.CoreGameKit.UiControllers.UIController&)]) = v111;\n\treturn returnVal2;\n")]
		public bool TryGet(Type type, out UIController o)
		{
			o = null;
			o = null;
			UIController uiControllerFromScene = _dataStore.GetUiControllerFromScene(type);
			bool flag = uiControllerFromScene != null;
			if (!flag)
			{
				return flag;
			}
			UIController uIController = Show(type, null);
			o = uIController;
			return flag;
		}

		[Token(Token = "0x6000034")]
		[Address(RVA = "0x42328BC", Offset = "0x42328BC", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv41 = Il2CppClass<T>;\n\tgoto L_0013;\nL_0013:\n\tv52 = System.Type::GetTypeFromHandle(v41);\n\t_game.CoreGameKit.UiControllers.UIFactory::ForceHideIfExist(this, v52);\n\treturn;\n\tv23 = 0x220C2B8(methodInfo, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_FFFFFFFF:\n\tv41 = Il2CppClass<T>;\n\tgoto L_0013;\n")]
		public void ForceHideIfExist<T>() where T : UIController
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UIFactory::ForceHideIfExist");
		}

		[Token(Token = "0x6000035")]
		[Address(RVA = "0x81A3F44", Offset = "0x81A3F44", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001B:\n\tv48 = _game.CoreGameKit.UiControllers.UIFactoryDataStore::GetUiControllerFromScene(this._dataStore, type);\n\tgoto L_0022;\nL_0022:\n\tv68 = UnityEngine.Object::op_Inequality(v48, 0);\n\tv103 = ~v68;\n\tif (v103) goto L_0047;\n\tv57 = _game.CoreGameKit.UiControllers.UIFactory::Show(this, type, 0);\n\tv57 = _game.CoreGameKit.UiControllers.UIController::ForceHide(v57);\n\treturn;\nL_0047:\n\treturn;\n")]
		public void ForceHideIfExist(Type type)
		{
			UIController uiControllerFromScene = _dataStore.GetUiControllerFromScene(type);
			if (uiControllerFromScene != null)
			{
				UIController uIController = Show(type, null);
				uIController.ForceHide();
			}
		}

		[Token(Token = "0x6000036")]
		[Address(RVA = "0x81A4010", Offset = "0x81A4010", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tgoto L_002F;\nL_002F:\n\tv72 = normalized.y * v59;\n\tv74 = normalized * v56;\n\t// 54 MakeStruct v80 @ AGG81A40BC_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v74 @ V0_v3 (System.Single), v72 @ V1_v2 (System.Single)\n\tv81 = UnityEngine.RectTransformUtility::ScreenPointToLocalPointInRectangle(this.RectTransform, v80, v63, &v76 @ stack_-58_v2 (UnityEngine.Vector2));\n\treturn v76;\nL_001F:\n\tv56 = UnityEngine.Screen::get_width();\n\tv59 = UnityEngine.Screen::get_height();\n\tv63 = UnityEngine.Camera::get_main();\n")]
		public Vector2 GetScreenLocalPosition(Vector2 normalized)
		{
			int width = Screen.width;
			int height = Screen.height;
			Camera main = Camera.main;
			float y = normalized.y * (float)height;
			float x = normalized.x * (float)width;
			Vector2 screenPoint = default(Vector2);
			screenPoint.x = x;
			screenPoint.y = y;
			bool flag = RectTransformUtility.ScreenPointToLocalPointInRectangle(RectTransform, screenPoint, main, out var localPoint);
			return localPoint;
		}

		[Token(Token = "0x6000037")]
		[Address(RVA = "0x81A40E0", Offset = "0x81A40E0", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.List`1<_game.CoreGameKit.UiControllers.LocationData>();\n\tSystem.Collections.Generic.List`1<_game.CoreGameKit.UiControllers.LocationData>::.ctor(v48);\n\tthis.LocationDataList = v48;\n")]
		public UIFactory()
		{
			List<LocationData> locationDataList = new List<LocationData>();
			LocationDataList = locationDataList;
		}
	}
}
