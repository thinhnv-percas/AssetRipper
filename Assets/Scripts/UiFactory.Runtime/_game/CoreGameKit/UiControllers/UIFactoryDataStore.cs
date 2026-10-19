using System;
using System.Collections.Generic;
using System.Linq;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.CoreGameKit.UiControllers.ScriptableObjects;

namespace _game.CoreGameKit.UiControllers
{
	[Token(Token = "0x200000C")]
	public class UIFactoryDataStore : IUiFactoryDataStore
	{
		[Token(Token = "0x400001A")]
		[FieldOffset(Offset = "0x10")]
		private List<UIController> _sceneUiControllers;

		[Token(Token = "0x400001B")]
		[FieldOffset(Offset = "0x18")]
		internal List<UIController> _uiControllerOrder;

		[Token(Token = "0x400001C")]
		[FieldOffset(Offset = "0x20")]
		private List<UIController> _overrideUiControllerOrder;

		[Token(Token = "0x400001D")]
		[FieldOffset(Offset = "0x28")]
		private BaseUIConfig _config;

		[Token(Token = "0x600003D")]
		[Address(RVA = "0x81A4258", Offset = "0x81A4258", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv63 = new System.Collections.Generic.List`1<_game.CoreGameKit.UiControllers.UIController>();\n\tSystem.Collections.Generic.List`1<_game.CoreGameKit.UiControllers.UIController>::.ctor(v63);\n\tthis._uiControllerOrder = v63;\n\tv71 = new System.Collections.Generic.List`1<_game.CoreGameKit.UiControllers.UIController>();\n\tSystem.Collections.Generic.List`1<_game.CoreGameKit.UiControllers.UIController>::.ctor(v71);\n\tthis._overrideUiControllerOrder = v71;\n\tSystem.Object::.ctor(this);\n\tthis._config = config;\n\treturn;\nL_001F:\n\tv53 = new System.Collections.Generic.List`1<_game.CoreGameKit.UiControllers.UIController>();\n\tSystem.Collections.Generic.List`1<_game.CoreGameKit.UiControllers.UIController>::.ctor(v53);\n\tthis._sceneUiControllers = v53;\n")]
		public UIFactoryDataStore(BaseUIConfig config)
		{
			List<UIController> sceneUiControllers = new List<UIController>();
			_sceneUiControllers = sceneUiControllers;
			_uiControllerOrder = new List<UIController>();
			_overrideUiControllerOrder = new List<UIController>();
			_config = config;
		}

		[Token(Token = "0x600003E")]
		[Address(RVA = "0x81A4348", Offset = "0x81A4348", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._sceneUiControllers;\n")]
		public List<UIController> GetSceneUiControllers()
		{
			return _sceneUiControllers;
		}

		[Token(Token = "0x600003F")]
		[Address(RVA = "0x4232DE8", Offset = "0x4232DE8", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv45 = Il2CppClass<T>;\n\tgoto L_0016;\nL_0016:\n\tv56 = System.Type::GetTypeFromHandle(v45);\n\tv65 = _game.CoreGameKit.UiControllers.UIFactoryDataStore::GetUiControllerFromScene(this, v56);\n\tgoto L_0027;\n\treturnVal2 = 0x21C11D0(v65, Il2CppClass<T>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv90 = returnVal2 == 0;\n\tif (v90) goto L_004E;\n\treturn returnVal2;\n\tv27 = 0x220C2B8(methodInfo, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_FFFFFFFF:\n\tv45 = Il2CppClass<T>;\n\tgoto L_0016;\nL_004B:\n\treturn 0;\nL_004E:\n\treturnVal3 = new System.InvalidCastException();\n\treturn returnVal3;\nL_0027:\n\tv79 = v65 == 0;\n\tif (v79) goto L_004B;\n")]
		public T GetUiControllerFromScene<T>() where T : UIController
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UIFactoryDataStore::GetUiControllerFromScene");
			return default;
		}

		[Token(Token = "0x6000040")]
		[Address(RVA = "0x81A2608", Offset = "0x81A2608", Length = "0x198")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv65 = System.Collections.Generic.List`1<_game.CoreGameKit.UiControllers.UIController>::GetEnumerator(this._sceneUiControllers);\n\tv90 = v65._list;\n\tv158 = System.Object::GetType(v65.Current);\n\tgoto L_0050;\nL_0050:\n\tv116 = System.Type::op_Equality(v158, type);\n\tv118 = v116 == 0;\nL_FFFFFFFF:\n\tv66 = 0;\n\tif (v118) goto L_003C;\nL_FFFFFFFF:\n\tv208 = v65.Current;\n\tgoto L_0058;\nL_FFFFFFFF:\n\tv208 = 0;\nL_0063:\n\treturn v208;\nL_0075:\n\tv134 = Il2CppMethodInfo != 1;\nL_FFFFFFFF:\n\tv147 = v105;\n\tif (v134) goto L_0088;\n\tv138 = 0x8BF5BC4(v105, Il2CppMethodInfo, v66, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv153 = 0x8BF5BF4(v138, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v90 @ stack_-58_v4 (System.Collections.Generic.List`1<_game.CoreGameKit.UiControllers.UIController>));\n\tv220 = *([v138 @ X0_v12]) == 0;\n\tv146 = ~v220;\n\tif (v146) goto L_0085;\nL_FFFFFFFF:\n\tv208 = 0;\n\tgoto L_0063;\nL_0085:\n\tv144 = new System.OutOfMemoryException();\nL_FFFFFFFF:\n\tv73 = *([v138 @ X0_v12]);\nL_FFFFFFFF:\n\tv147 = v144;\n\treturn returnVal2;\nL_0020:\n\tv90 = 0;\n\tv52 = this._sceneUiControllers == 0;\nL_FFFFFFFF:\n\tv73 = 0;\n\tif (v52) goto L_0066;\nL_003C:\n\tv123 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v90 @ stack_-58_v4 (System.Collections.Generic.List`1<_game.CoreGameKit.UiControllers.UIController>));\n\tv136 = v123 == 0;\n\tif (v136) goto L_FFFFFFFF;\nL_0058:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v90 @ stack_-58_v4 (System.Collections.Generic.List`1<_game.CoreGameKit.UiControllers.UIController>));\nL_0088:\n\tv150 = 0x396651C(&v73 @ stack_-68_v1 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv155 = 0x8BF0368(v147, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal2 = 0x7C03E68(v155, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0066:\n\tv105 = new System.NullReferenceException();\n\tgoto L_0075;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe UIController GetUiControllerFromScene(Type type)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UIFactoryDataStore::GetUiControllerFromScene");
			return default;
		}

		[Token(Token = "0x6000041")]
		[Address(RVA = "0x4232D64", Offset = "0x4232D64", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv41 = Il2CppClass<T>;\n\tgoto L_0013;\nL_0013:\n\tv52 = System.Type::GetTypeFromHandle(v41);\n\treturnVal1 = _game.CoreGameKit.UiControllers.UIFactoryDataStore::GetUiConfig(this, v52);\n\treturn returnVal1;\n\tv23 = 0x220C2B8(methodInfo, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_FFFFFFFF:\n\tv41 = Il2CppClass<T>;\n\tgoto L_0013;\n")]
		public UIConfig GetUiConfig<T>() where T : UIController
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UIFactoryDataStore::GetUiConfig");
			return default;
		}

		[Token(Token = "0x6000042")]
		[Address(RVA = "0x81A31E0", Offset = "0x81A31E0", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv51.type = type;\n\tv72 = this._config;\n\tv82 = new System.Func`2<_game.CoreGameKit.UiControllers.ScriptableObjects.UIConfig, System.Boolean>();\n\tSystem.Func`2<_game.CoreGameKit.UiControllers.ScriptableObjects.UIConfig, System.Boolean>::.ctor(v82, v51, Il2CppMethodInfo);\n\treturnVal2 = System.Linq.Enumerable::FirstOrDefault(v72.UIConfigList, v82);\n\treturn returnVal2;\nL_0023:\n\tv51 = new _game.CoreGameKit.UiControllers.UIFactoryDataStore+<>c__DisplayClass9_0();\n\tSystem.Object::.ctor(v51);\n")]
		public UIConfig GetUiConfig(Type type)
		{
			BaseUIConfig config = _config;
			Func<UIConfig, bool> predicate = delegate(UIConfig uiConfig)
			{
				string[] source = uiConfig.AssetPath.Split('/');
				object obj = ((IEnumerable<object>)source).Last();
				string text = ((string)obj).ToLowerInvariant();
				string text2 = type.ToString();
				string text3 = text2.ToLowerInvariant();
				string[] source2 = text3.Split('.');
				object obj2 = ((IEnumerable<object>)source2).Last();
				return text == (string)obj2;
			};
			return (UIConfig)config.UIConfigList.FirstOrDefault((Func<object, bool>)predicate);
		}

		[Token(Token = "0x6000043")]
		[Address(RVA = "0x81A29C0", Offset = "0x81A29C0", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv51.controller = controller;\n\tv72 = this._config;\n\tv82 = new System.Func`2<_game.CoreGameKit.UiControllers.ScriptableObjects.UIConfig, System.Boolean>();\n\tSystem.Func`2<_game.CoreGameKit.UiControllers.ScriptableObjects.UIConfig, System.Boolean>::.ctor(v82, v51, Il2CppMethodInfo);\n\treturnVal2 = System.Linq.Enumerable::FirstOrDefault(v72.UIConfigList, v82);\n\treturn returnVal2;\nL_0023:\n\tv51 = new _game.CoreGameKit.UiControllers.UIFactoryDataStore+<>c__DisplayClass10_0();\n\tSystem.Object::.ctor(v51);\n")]
		public UIConfig GetUiConfig(UIController controller)
		{
			BaseUIConfig config = _config;
			Func<UIConfig, bool> predicate = delegate(UIConfig uIConfig)
			{
				string[] source = uIConfig.AssetPath.Split('/');
				object a = ((IEnumerable<object>)source).Last();
				Type type = controller.GetType();
				string text = type.ToString();
				string[] source2 = text.Split(".");
				object b = ((IEnumerable<object>)source2).Last();
				return string.Equals((string)a, (string)b, StringComparison.InvariantCultureIgnoreCase);
			};
			return (UIConfig)config.UIConfigList.FirstOrDefault((Func<object, bool>)predicate);
		}

		[Token(Token = "0x6000044")]
		[Address(RVA = "0x81A32D4", Offset = "0x81A32D4", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tgoto L_0047;\nL_0047:\n\tSystem.Collections.Generic.List`1<_game.CoreGameKit.UiControllers.UIController>::Add(v46, v40);\n\treturn;\nL_0016:\n\tv46 = this._sceneUiControllers;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddToScene(UIController uiController)
		{
			List<UIController> sceneUiControllers = _sceneUiControllers;
			UIController item = default(UIController);
			sceneUiControllers.Add(item);
		}

		[Token(Token = "0x6000045")]
		[Address(RVA = "0x81A3AD4", Offset = "0x81A3AD4", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\nL_0022:\n\tv53 = System.Collections.Generic.List`1<_game.CoreGameKit.UiControllers.UIController>::Contains(this._uiControllerOrder, uiController);\n\tv74 = ~v53;\n\tif (v74) goto L_002D;\n\tv78 = System.Collections.Generic.List`1<_game.CoreGameKit.UiControllers.UIController>::Remove(this._uiControllerOrder, uiController);\nL_002D:\n\tv63 = this._uiControllerOrder;\n\tgoto L_0060;\nL_0060:\n\tSystem.Collections.Generic.List`1<_game.CoreGameKit.UiControllers.UIController>::Add(v63, uiController);\n\treturn;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddControllerToOrder(UIController uiController)
		{
			if (_uiControllerOrder.Contains(uiController))
			{
				bool flag = _uiControllerOrder.Remove(uiController);
			}
			List<UIController> uiControllerOrder = _uiControllerOrder;
			uiControllerOrder.Add(uiController);
		}

		[Token(Token = "0x6000046")]
		[Address(RVA = "0x81A28B0", Offset = "0x81A28B0", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv47.uiController = uiController;\n\tv93 = System.Collections.Generic.List`1<_game.CoreGameKit.UiControllers.UIController>::Remove(this._sceneUiControllers, v47.uiController);\n\tv72 = new System.Predicate`1<_game.CoreGameKit.UiControllers.UIController>();\n\tSystem.Predicate`1<_game.CoreGameKit.UiControllers.UIController>::.ctor(v72, v47, Il2CppMethodInfo);\n\tv102 = System.Collections.Generic.List`1<_game.CoreGameKit.UiControllers.UIController>::RemoveAll(this._uiControllerOrder, v72);\n\treturn;\nL_0024:\n\tv47 = new _game.CoreGameKit.UiControllers.UIFactoryDataStore+<>c__DisplayClass13_0();\n\tSystem.Object::.ctor(v47);\n")]
		public void RemoveFromScene(UIController uiController)
		{
			bool flag = _sceneUiControllers.Remove(uiController);
			Predicate<UIController> match = delegate(UIController controller)
			{
				//IL_0040: Expected O, but got I
				Type type = controller.GetType();
				Type type2 = uiController.GetType();
				int num2 = 192761856 + 1336;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ X8_v2 (System.Int32)+E0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X0_v7+E4]");
				return ((nint)0 != 0) ? (type == type2) : (type == type2);
			};
			int num = _uiControllerOrder.RemoveAll(match);
		}

		[Token(Token = "0x6000047")]
		[Address(RVA = "0x81A3388", Offset = "0x81A3388", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv51.controller = controller;\n\tv76 = new System.Func`2<_game.CoreGameKit.UiControllers.UIController, System.Boolean>();\n\tSystem.Func`2<_game.CoreGameKit.UiControllers.UIController, System.Boolean>::.ctor(v76, v51, Il2CppMethodInfo);\n\treturnVal2 = System.Linq.Enumerable::FirstOrDefault(this._sceneUiControllers, v76);\n\treturn returnVal2;\nL_0023:\n\tv51 = new _game.CoreGameKit.UiControllers.UIFactoryDataStore+<>c__DisplayClass14_0();\n\tSystem.Object::.ctor(v51);\n")]
		public UIController GetSceneElement(UIController controller)
		{
			Func<UIController, bool> predicate = delegate(UIController node)
			{
				//IL_0040: Expected O, but got I
				Type type = node.GetType();
				Type type2 = controller.GetType();
				int num = 192761856 + 1336;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ X8_v2 (System.Int32)+E0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X0_v7+E4]");
				return ((nint)0 != 0) ? (type == type2) : (type == type2);
			};
			return (UIController)_sceneUiControllers.FirstOrDefault((Func<object, bool>)predicate);
		}

		[Token(Token = "0x6000048")]
		[Address(RVA = "0x81A3100", Offset = "0x81A3100", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tv52 = System.Collections.Generic.List`1<_game.CoreGameKit.UiControllers.UIController>::Remove(this._sceneUiControllers, sceneCache);\n\tv59 = this._sceneUiControllers;\n\tgoto L_0053;\nL_0053:\n\tSystem.Collections.Generic.List`1<_game.CoreGameKit.UiControllers.UIController>::Add(v59, sceneCache);\n\treturn;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateOrderInScene(UIController sceneCache)
		{
			bool flag = _sceneUiControllers.Remove(sceneCache);
			List<UIController> sceneUiControllers = _sceneUiControllers;
			sceneUiControllers.Add(sceneCache);
		}

		[Token(Token = "0x6000049")]
		[Address(RVA = "0x81A4370", Offset = "0x81A4370", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._uiControllerOrder;\n")]
		public List<UIController> GetUiOrder()
		{
			return _uiControllerOrder;
		}
	}
}
