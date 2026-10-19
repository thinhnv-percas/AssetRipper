using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Systems.RemoteManagementSystem.ScriptableObjects;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.Extensions;
using UnityEngine;

namespace Unco.RemoteManagementSystem.ScriptableObjects
{
	[CreateAssetMenu(fileName = "BaseRemoteConfig", menuName = "UFC/RemoteDataSystem/BaseRemoteConfig", order = 0)]
	[Token(Token = "0x2000015")]
	public class BaseRemoteConfig : ScriptableObject
	{
		[Token(Token = "0x4000047")]
		[FieldOffset(Offset = "0x18")]
		public List<RemoteConfig> RemoteConfigList;

		[SerializeField]
		[Token(Token = "0x4000048")]
		[FieldOffset(Offset = "0x20")]
		private List<CompressionMetadataEntry> m_compressionMetadataList;

		[Token(Token = "0x600004F")]
		[Address(RVA = "0x81CCDF4", Offset = "0x81CCDF4", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv47.key = key;\n\tv60 = this.RemoteConfigList;\n\tv61 = this.RemoteConfigList == 0;\n\tif (v61) goto L_0055;\n\tv81 = v60.Count == 0;\n\tif (v81) goto L_0055;\n\tv94 = new System.Predicate`1<Systems.RemoteManagementSystem.ScriptableObjects.RemoteConfig>();\n\tSystem.Predicate`1<Systems.RemoteManagementSystem.ScriptableObjects.RemoteConfig>::.ctor(v94, v47, Il2CppMethodInfo);\n\tv69 = System.Collections.Generic.List`1<Systems.RemoteManagementSystem.ScriptableObjects.RemoteConfig>::Find(this.RemoteConfigList, v94);\n\treturnVal3 = Systems.RemoteManagementSystem.ScriptableObjects.RemoteConfig::GetValue(v69);\n\treturn returnVal3;\nL_0055:\n\treturn 0;\nL_0024:\n\tv47 = new Unco.RemoteManagementSystem.ScriptableObjects.BaseRemoteConfig+<>c__DisplayClass2_0();\n\tSystem.Object::.ctor(v47);\n")]
		public string GetLocalString(RemoteKey key)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseRemoteConfig::GetLocalString");
			return default;
		}

		[Token(Token = "0x6000050")]
		[Address(RVA = "0x81CFD10", Offset = "0x81CFD10", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv47.key = key;\n\tv60 = this.RemoteConfigList;\n\tv61 = this.RemoteConfigList == 0;\n\tif (v61) goto L_0055;\n\tv81 = v60.Count == 0;\n\tif (v81) goto L_0055;\n\tv94 = new System.Predicate`1<Systems.RemoteManagementSystem.ScriptableObjects.RemoteConfig>();\n\tSystem.Predicate`1<Systems.RemoteManagementSystem.ScriptableObjects.RemoteConfig>::.ctor(v94, v47, Il2CppMethodInfo);\n\tv69 = System.Collections.Generic.List`1<Systems.RemoteManagementSystem.ScriptableObjects.RemoteConfig>::Find(this.RemoteConfigList, v94);\n\treturn v69.Value;\nL_0055:\n\treturn 0;\nL_0024:\n\tv47 = new Unco.RemoteManagementSystem.ScriptableObjects.BaseRemoteConfig+<>c__DisplayClass3_0();\n\tSystem.Object::.ctor(v47);\n")]
		public string GetLocalString_IgnoreDevCheck(RemoteKey key)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseRemoteConfig::GetLocalString_IgnoreDevCheck");
			return default;
		}

		[Token(Token = "0x6000051")]
		[Address(RVA = "0x81CD36C", Offset = "0x81CD36C", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_0024:\n\tv61 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tv68 = System.Single::TryParse(v52, 0x1FF, v61, &v64 @ stack_-34_v2 (System.Single));\n\treturn v64;\nL_001B:\n\tv52 = Unco.RemoteManagementSystem.ScriptableObjects.BaseRemoteConfig::GetLocalString(v46, v43);\n\tgoto L_0024;\n")]
		public float GetLocalFloat(RemoteKey key)
		{
			RemoteKey key2 = default(RemoteKey);
			string localString = GetLocalString(key2);
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			bool flag = float.TryParse(localString, NumberStyles.Any, invariantCulture, out var result);
			return result;
		}

		[Token(Token = "0x6000052")]
		[Address(RVA = "0x81CD700", Offset = "0x81CD700", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = Unco.RemoteManagementSystem.ScriptableObjects.BaseRemoteConfig::GetLocalString(this, key);\n\tgoto L_0013;\nL_0013:\n\treturnVal1 = System.Boolean::Parse(v12);\n\treturn returnVal1;\n")]
		public bool GetLocalBool(RemoteKey key)
		{
			string localString = GetLocalString(key);
			return bool.Parse(localString);
		}

		[Token(Token = "0x6000053")]
		[Address(RVA = "0x81CDAB8", Offset = "0x81CDAB8", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = Unco.RemoteManagementSystem.ScriptableObjects.BaseRemoteConfig::GetLocalString(this, key);\n\treturnVal1 = System.Int32::Parse(v10);\n\treturn returnVal1;\n")]
		public int GetLocalInt(RemoteKey key)
		{
			string localString = GetLocalString(key);
			return int.Parse(localString);
		}

		[Token(Token = "0x6000054")]
		[Address(RVA = "0x472EC28", Offset = "0x472EC28", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tgoto L_001E;\n\tv62 = 0x220C2B8(methodInfo, v40, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0028:\n\tv65 = Unco.Extensions.StringExtensions::IsNullOrWhiteSpace(v53);\n\tv70 = v65 == 0;\n\treturnVal1 = 0;\n\tif (v70) goto L_0043;\nL_0035:\n\treturn returnVal1;\nL_0043:\n\treturnVal1 = UnityEngine.JsonUtility::FromJson(v53);\n\tgoto L_0035;\nL_001E:\n\tv53 = Unco.RemoteManagementSystem.ScriptableObjects.BaseRemoteConfig::GetLocalString(v44, v40);\n\tgoto L_0028;\n")]
		public T GetLocalJson<T>(RemoteKey key)
		{
			RemoteKey key2 = default(RemoteKey);
			string localString = GetLocalString(key2);
			bool flag = localString.IsNullOrWhiteSpace();
			bool flag2 = !flag;
			T result = default(T);
			if (!flag2)
			{
				return result;
			}
			return JsonUtility.FromJson<T>(localString);
		}

		[Token(Token = "0x6000055")]
		[Address(RVA = "0x472F234", Offset = "0x472F234", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n")]
		public T GetLocalJsonWithNewton<T>(RemoteKey key)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseRemoteConfig::GetLocalJsonWithNewton");
			return default;
		}

		[Token(Token = "0x6000056")]
		[Address(RVA = "0x81CCF80", Offset = "0x81CCF80", Length = "0x18C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv51.key = key;\n\tv66 = this.m_compressionMetadataList == 0;\n\tif (v66) goto L_005A;\n\tv78 = new System.Func`2<Unco.RemoteManagementSystem.ScriptableObjects.CompressionMetadataEntry, System.Boolean>();\n\tSystem.Func`2<Unco.RemoteManagementSystem.ScriptableObjects.CompressionMetadataEntry, System.Boolean>::.ctor(v78, v51, Il2CppMethodInfo);\n\tv137 = System.Linq.Enumerable::FirstOrDefault(this.m_compressionMetadataList, v78);\n\tv141 = v137 == 0;\n\tif (v141) goto L_0067;\n\tv115 = *([v137 @ X0_v16 (System.Object)+18]) == 0;\n\tif (v115) goto L_0067;\n\treturn *([v137 @ X0_v16 (System.Object)+18]);\nL_005A:\n\tv82 = new System.Collections.Generic.List`1<Unco.RemoteManagementSystem.ScriptableObjects.CompressionMetadataEntry>();\n\tSystem.Collections.Generic.List`1<Unco.RemoteManagementSystem.ScriptableObjects.CompressionMetadataEntry>::.ctor(v82);\n\tthis.m_compressionMetadataList = v82;\nL_0067:\n\tv152 = new Unco.RemoteManagementSystem.ScriptableObjects.CompressionMetadata();\n\tSystem.Object::.ctor(v152);\n\tv152.IsCompressed = 0;\n\tv152.Algorithm = 2;\n\treturn v152;\nL_002C:\n\tv51 = new Unco.RemoteManagementSystem.ScriptableObjects.BaseRemoteConfig+<>c__DisplayClass9_0();\n\tSystem.Object::.ctor(v51);\n")]
		public CompressionMetadata GetCompressionMetadata(RemoteKey key)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseRemoteConfig::GetCompressionMetadata");
			return default;
		}

		[Token(Token = "0x6000057")]
		[Address(RVA = "0x81CFE30", Offset = "0x81CFE30", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv72 = new System.Collections.Generic.List`1<Unco.RemoteManagementSystem.ScriptableObjects.CompressionMetadataEntry>();\n\tSystem.Collections.Generic.List`1<Unco.RemoteManagementSystem.ScriptableObjects.CompressionMetadataEntry>::.ctor(v72);\n\tthis.m_compressionMetadataList = v72;\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\nL_0028:\n\tv56 = new System.Collections.Generic.List`1<Systems.RemoteManagementSystem.ScriptableObjects.RemoteConfig>();\n\tSystem.Collections.Generic.List`1<Systems.RemoteManagementSystem.ScriptableObjects.RemoteConfig>::.ctor(v56);\n\tthis.RemoteConfigList = v56;\n")]
		public BaseRemoteConfig()
		{
			List<RemoteConfig> remoteConfigList = new List<RemoteConfig>();
			RemoteConfigList = remoteConfigList;
			List<CompressionMetadataEntry> compressionMetadataList = new List<CompressionMetadataEntry>();
			m_compressionMetadataList = compressionMetadataList;
		}
	}
}
