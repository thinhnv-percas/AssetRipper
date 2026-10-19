using System;
using System.Globalization;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.ResourceSystem
{
	[Token(Token = "0x2000018")]
	public class ResourceRepository : IResourceRepository
	{
		[Token(Token = "0x400004A")]
		private const string AMOUNT_KEY_PREFIX = "resource_amount_";

		[Token(Token = "0x400004B")]
		private const string INFINITE_KEY_PREFIX = "resource_infinite_";

		[Token(Token = "0x400004C")]
		[FieldOffset(Offset = "0x10")]
		private readonly ResourceConfig _config;

		[Token(Token = "0x6000054")]
		[Address(RVA = "0x81D383C", Offset = "0x81D383C", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tv15 = config == 0;\n\tif (v15) goto L_001A;\n\tthis._config = config;\n\treturn;\nL_001A:\n\tv18 = 0xB28B000 + 0x600;\n\tv52 = new v18();\n\tv54 = 0xB308000 + 0xEB0;\n\tSystem.ArgumentNullException::.ctor(v52, v54);\n\tthrow v52;\n")]
		public ResourceRepository(ResourceConfig config)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ResourceRepository::.ctor");
		}

		[Token(Token = "0x6000055")]
		[Address(RVA = "0x81D38C4", Offset = "0x81D38C4", Length = "0x1EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv95 = Unco.ResourceSystem.ResourceConfig::GetInitialAmount(this._config, resourceType);\n\tv97 = v95;\n\tgoto L_0051;\nL_0051:\n\tv105 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tv163 = System.Double::ToString(&v97 @ stack_-48_v2 (System.Double), v105);\n\tv167 = UnityEngine.PlayerPrefs::GetString(v84, v163);\n\tv170 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tv141 = System.Double::TryParse(v167, 0x1FF, v170, &v127 @ stack_-50_v2 (System.Double));\n\tv144 = ~v141;\n\tif (v144) goto L_0070;\n\treturn v127;\nL_0070:\n\tv111 = resourceType;\n\t// 115 Box v174 @ X0_v22 (System.Object), typeof(Unco.ResourceSystem.ResourceType), &v111 @ stack_-54_v1 (Unco.ResourceSystem.ResourceType)\n\tv142 = System.String::Format(\"[ResourceRepository] Failed to parse amount for {0}, returning 0\", v174);\n\tgoto L_0086;\nL_002C:\n\tgoto L_0038;\nL_0086:\n\tUnityEngine.Debug::LogError(v142);\n\treturn 0;\nL_0038:\n\tv70 = resourceType;\n\t// 59 Box v73 @ X0_v4 (System.Object), typeof(Unco.ResourceSystem.ResourceType), &v70 @ stack_-48_v1 (Unco.ResourceSystem.ResourceType)\n\tv84 = System.String::Format(\"{0}{1}\", \"resource_amount_\", v73);\n")]
		public double Load(ResourceType resourceType)
		{
			object arg = resourceType;
			string key = string.Format("{0}{1}", "resource_amount_", arg);
			double initialAmount = _config.GetInitialAmount(resourceType);
			double num = initialAmount;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			string defaultValue = num.ToString(invariantCulture);
			string s = PlayerPrefs.GetString(key, defaultValue);
			CultureInfo invariantCulture2 = CultureInfo.InvariantCulture;
			if (double.TryParse(s, NumberStyles.Any, invariantCulture2, out var result))
			{
				return result;
			}
			object arg2 = resourceType;
			string message = $"[ResourceRepository] Failed to parse amount for {arg2}, returning 0";
			Debug.LogError(message);
			return 0.0;
		}

		[Token(Token = "0x6000056")]
		[Address(RVA = "0x81D3B58", Offset = "0x81D3B58", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = amount;\n\tgoto L_0024;\nL_0041:\n\tv89 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tv93 = System.Double::ToString(&v20 @ stack_-50_v1 (System.Double), v89);\n\tUnityEngine.PlayerPrefs::SetString(v78, v93);\n\treturn;\nL_0024:\n\tgoto L_0030;\nL_0030:\n\tv67 = resourceType;\n\t// 51 Box v70 @ X0_v4 (System.Object), typeof(Unco.ResourceSystem.ResourceType), &v67 @ stack_-44_v1 (Unco.ResourceSystem.ResourceType)\n\tv78 = System.String::Format(\"{0}{1}\", \"resource_amount_\", v70);\n\tgoto L_0041;\n")]
		public void Save(ResourceType resourceType, double amount)
		{
			double num = amount;
			object arg = resourceType;
			string key = string.Format("{0}{1}", "resource_amount_", arg);
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			string value = num.ToString(invariantCulture);
			PlayerPrefs.SetString(key, value);
		}

		[Token(Token = "0x6000057")]
		[Address(RVA = "0x81D3C68", Offset = "0x81D3C68", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv70 = ~v69;\n\treturnVal1 = v70 >> 0x1F;\n\treturn returnVal1;\nL_0022:\n\tv53 = resourceType;\n\t// 37 Box v56 @ X0_v3 (System.Object), typeof(Unco.ResourceSystem.ResourceType), &v53 @ stack_-44_v1 (Unco.ResourceSystem.ResourceType)\n\tv64 = System.String::Format(\"{0}{1}\", \"resource_infinite_\", v56);\n\tv69 = UnityEngine.PlayerPrefs::GetInt(v64, -1);\n")]
		public bool LoadInfiniteFlag(ResourceType resourceType)
		{
			object arg = resourceType;
			string key = string.Format("{0}{1}", "resource_infinite_", arg);
			int num = PlayerPrefs.GetInt(key, -1);
			int num2 = ~num;
			return (byte)(num2 >> 31) != 0;
		}

		[Token(Token = "0x6000058")]
		[Address(RVA = "0x81D3DCC", Offset = "0x81D3DCC", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv77 = Unco.ResourceSystem.ResourceRepository::Load(this, resourceType);\n\tv84 = v77 == 0x7FF0000000000000;\n\tv92 = ~v84;\n\tif (v92) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv112 = 0xFFFFFFFF80000000;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv112 = v77;\nL_FFFFFFFF:\n\tv111 = -1;\nL_0026:\n\tv59 = resourceType;\n\t// 41 Box v62 @ X0_v3 (System.Object), typeof(Unco.ResourceSystem.ResourceType), &v59 @ stack_-54_v1 (Unco.ResourceSystem.ResourceType)\n\tv113 = System.String::Format(\"{0}{1}\", \"resource_infinite_\", v62);\n\tv73 = ~isInfinite;\n\tif (v73) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv111 = v112;\n\tgoto L_004B;\nL_004B:\n\tUnityEngine.PlayerPrefs::SetInt(v113, v111);\n\treturn;\n")]
		public void SaveInfiniteFlag(ResourceType resourceType, bool isInfinite)
		{
			//IL_00b7: Expected I4, but got F8
			//IL_004a: Expected F8, but got I4
			object arg = resourceType;
			string key = string.Format("{0}{1}", "resource_infinite_", arg);
			int value;
			if (isInfinite)
			{
				double num = Load(resourceType);
				double num2 = ((num != 9.218868437227405E+18) ? num : (-2147483648.0));
				value = (int)num2;
			}
			else
			{
				value = -1;
			}
			PlayerPrefs.SetInt(key, value);
		}

		[Token(Token = "0x6000059")]
		[Address(RVA = "0x81D3AB0", Offset = "0x81D3AB0", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\nL_0022:\n\tv53 = resourceType;\n\t// 37 Box v56 @ X0_v3 (System.Object), typeof(Unco.ResourceSystem.ResourceType), &v53 @ stack_-44_v1 (Unco.ResourceSystem.ResourceType)\n\treturnVal1 = System.String::Format(\"{0}{1}\", \"resource_amount_\", v56);\n\treturn returnVal1;\n")]
		public string GetSaveKey(ResourceType resourceType)
		{
			object arg = resourceType;
			return string.Format("{0}{1}", "resource_amount_", arg);
		}

		[Token(Token = "0x600005A")]
		[Address(RVA = "0x81D3D24", Offset = "0x81D3D24", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\nL_0022:\n\tv53 = resourceType;\n\t// 37 Box v56 @ X0_v3 (System.Object), typeof(Unco.ResourceSystem.ResourceType), &v53 @ stack_-44_v1 (Unco.ResourceSystem.ResourceType)\n\treturnVal1 = System.String::Format(\"{0}{1}\", \"resource_infinite_\", v56);\n\treturn returnVal1;\n")]
		private string GetInfiniteKey(ResourceType resourceType)
		{
			object arg = resourceType;
			return string.Format("{0}{1}", "resource_infinite_", arg);
		}
	}
}
