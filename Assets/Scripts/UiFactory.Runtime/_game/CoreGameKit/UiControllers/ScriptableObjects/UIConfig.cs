using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.Extensions;
using UnityEngine;

namespace _game.CoreGameKit.UiControllers.ScriptableObjects
{
	[CreateAssetMenu(fileName = "UIConfig", menuName = "UI/UIConfig", order = 0)]
	[Token(Token = "0x2000020")]
	public class UIConfig : ScriptableObject
	{
		[Serializable]
		[Token(Token = "0x2000021")]
		public class SortOrderer
		{
			[Token(Token = "0x4000049")]
			[FieldOffset(Offset = "0x10")]
			public bool OverrideSortOrder;

			[Token(Token = "0x400004A")]
			[FieldOffset(Offset = "0x14")]
			public int SortOrder;

			[Token(Token = "0x60000AE")]
			[Address(RVA = "0x81A616C", Offset = "0x81A616C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public SortOrderer()
			{
			}
		}

		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000022")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400004B")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400004C")]
			public static Comparison<ConfigOrderPair> _003C_003E9__12_0;

			[Token(Token = "0x60000AF")]
			[Address(RVA = "0x81A6174", Offset = "0x81A6174", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreGameKit.UiControllers.ScriptableObjects.UIConfig+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60000B0")]
			[Address(RVA = "0x81A61D8", Offset = "0x81A61D8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal int _003CGetSortedConfigs_003Eb__12_0(ConfigOrderPair pair, ConfigOrderPair orderPair)
			{
				return pair.Order.CompareTo(orderPair.Order);
			}
		}

		[Token(Token = "0x4000042")]
		[FieldOffset(Offset = "0x18")]
		public string AssetPath;

		[Token(Token = "0x4000043")]
		[FieldOffset(Offset = "0x20")]
		public string OptimizedAssetPath;

		[Token(Token = "0x4000044")]
		[FieldOffset(Offset = "0x28")]
		public CanvasLocation CanvasLocation;

		[Token(Token = "0x4000045")]
		[FieldOffset(Offset = "0x2C")]
		public UILocation Location;

		[Token(Token = "0x4000046")]
		[FieldOffset(Offset = "0x30")]
		public SortOrderer sortOrder;

		[Token(Token = "0x4000047")]
		[FieldOffset(Offset = "0x38")]
		public bool UseElephantEvent;

		[Token(Token = "0x4000048")]
		[FieldOffset(Offset = "0x40")]
		internal UIController _uiController;

		[Token(Token = "0x17000007")]
		public string UIControllerType
		{
			[Token(Token = "0x60000A7")]
			[Address(RVA = "0x81A4474", Offset = "0x81A4474", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_001A:\n\tv45 = System.String::Split(this.AssetPath, 0x2F, 0);\n\treturnVal2 = System.Linq.Enumerable::Last(v45);\n\treturn returnVal2;\n")]
			get
			{
				string[] source = AssetPath.Split('/');
				return (string)((IEnumerable<object>)source).Last();
			}
		}

		[Token(Token = "0x60000A8")]
		[Address(RVA = "0x81A605C", Offset = "0x81A605C", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0024:\n\tv58 = Unco.Extensions.StringExtensions::IsNullOrWhiteSpace(this.OptimizedAssetPath);\n\tv63 = v58 == 0;\n\tv70 = ~v63;\n\tv71 = ~v70;\n\tif (v71) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv74 = 0x18;\n\tgoto L_0039;\nL_FFFFFFFF:\n\tv74 = 0x20;\nL_0020:\n\tgoto L_0024;\nL_0039:\n\tv77 = UnityEngine.Resources::Load(*([this @ X0 (_game.CoreGameKit.UiControllers.ScriptableObjects.UIConfig)+v74 @ X8_v5 (System.Int32)]));\n\tthis._uiController = v77;\n\treturn this._uiController;\n")]
		public UIController LoadUIController()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UIConfig::LoadUIController");
			return default;
		}

		[Token(Token = "0x60000A9")]
		[Address(RVA = "0x81A2BCC", Offset = "0x81A2BCC", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._uiController = 0;\n\treturn;\n")]
		public void Unload()
		{
			_uiController = null;
		}

		[Token(Token = "0x60000AA")]
		[Address(RVA = "0x81A3A24", Offset = "0x81A3A24", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv55 = UnityEngine.Object::op_Equality(this._uiController, 0);\n\tv64 = v55 == 0;\n\tif (v64) goto L_0042;\n\treturnVal2 = _game.CoreGameKit.UiControllers.ScriptableObjects.UIConfig::LoadUIController(this);\n\treturn returnVal2;\nL_0042:\n\treturn this._uiController;\n")]
		public UIController GetUIController()
		{
			if (_uiController == null)
			{
				return LoadUIController();
			}
			return _uiController;
		}

		[Token(Token = "0x60000AB")]
		[Address(RVA = "0x81A381C", Offset = "0x81A381C", Length = "0x208")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0032;\n\tSystem.Object::.ctor(v64);\n\tv64.Config = this;\n\tv64.Order = 0;\n\tgoto L_006D;\nL_006D:\n\tSystem.Collections.Generic.List`1<_game.CoreGameKit.UiControllers.ScriptableObjects.ConfigOrderPair>::Add(v54, v64);\n\tgoto L_0079;\n\tgoto L_0087;\nL_0098:\n\tSystem.Collections.Generic.List`1<_game.CoreGameKit.UiControllers.ScriptableObjects.ConfigOrderPair>::Sort(v54, v215);\n\treturn v54;\nL_0032:\n\tv54 = new System.Collections.Generic.List`1<_game.CoreGameKit.UiControllers.ScriptableObjects.ConfigOrderPair>();\n\tSystem.Collections.Generic.List`1<_game.CoreGameKit.UiControllers.ScriptableObjects.ConfigOrderPair>::.ctor(v54);\n\tv64 = new _game.CoreGameKit.UiControllers.ScriptableObjects.ConfigOrderPair();\nL_0079:\n\tv198 = v196.<>9__12_0 == 0;\n\tv199 = ~v198;\n\tv215 = v196.<>9__12_0;\n\tif (v199) goto L_0098;\nL_0087:\n\tv225 = new System.Comparison`1<_game.CoreGameKit.UiControllers.ScriptableObjects.ConfigOrderPair>();\n\tSystem.Comparison`1<_game.CoreGameKit.UiControllers.ScriptableObjects.ConfigOrderPair>::.ctor(v225, v220.<>9, Il2CppMethodInfo);\n\tv230.<>9__12_0 = v225;\n\tv215 = v225;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public List<ConfigOrderPair> GetSortedConfigs()
		{
			List<ConfigOrderPair> list = new List<ConfigOrderPair>();
			ConfigOrderPair configOrderPair = (ConfigOrderPair)FormatterServices.GetUninitializedObject(typeof(ConfigOrderPair));
			configOrderPair.Config = this;
			configOrderPair.Order = 0;
			list.Add(configOrderPair);
			bool flag = _003C_003Ec._003C_003E9__12_0 == null;
			bool flag2 = !flag;
			Comparison<object> comparison = (Comparison<object>)_003C_003Ec._003C_003E9__12_0;
			if (!flag2)
			{
				comparison = (Comparison<object>)(_003C_003Ec._003C_003E9__12_0 = (ConfigOrderPair pair, ConfigOrderPair orderPair) => pair.Order.CompareTo(orderPair.Order));
			}
			list.Sort(comparison);
			return list;
		}

		[Token(Token = "0x60000AC")]
		[Address(RVA = "0x81A6154", Offset = "0x81A6154", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.sortOrder;\n")]
		public SortOrderer GetSortOrder()
		{
			return sortOrder;
		}

		[Token(Token = "0x60000AD")]
		[Address(RVA = "0x81A615C", Offset = "0x81A615C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.UseElephantEvent = 1;\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n")]
		public UIConfig()
		{
			UseElephantEvent = true;
		}
	}
}
