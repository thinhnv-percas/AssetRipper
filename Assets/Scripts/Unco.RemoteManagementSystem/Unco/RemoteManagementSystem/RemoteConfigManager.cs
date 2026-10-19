using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Newtonsoft.Json;
using Reflex.Attributes;
using Unco.Extensions;
using Unco.RemoteManagementSystem.ScriptableObjects;
using UnityEngine;

namespace Unco.RemoteManagementSystem
{
	[Token(Token = "0x200000F")]
	public class RemoteConfigManager
	{
		[Token(Token = "0x400001D")]
		[FieldOffset(Offset = "0x10")]
		private IRemoteConfig _remoteConfig;

		[Token(Token = "0x400001E")]
		[FieldOffset(Offset = "0x18")]
		private BaseRemoteConfig _baseRemoteConfig;

		[Token(Token = "0x400001F")]
		[FieldOffset(Offset = "0x20")]
		private JsonSerializerSettings _settings;

		[Inject(false)]
		[Token(Token = "0x6000032")]
		[Address(RVA = "0x81CCA50", Offset = "0x81CCA50", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._remoteConfig = remoteConfig;\n\tthis._baseRemoteConfig = baseRemoteConfig;\n\treturn;\n")]
		public void Inject(IRemoteConfig remoteConfig, BaseRemoteConfig baseRemoteConfig)
		{
			_remoteConfig = remoteConfig;
			_baseRemoteConfig = baseRemoteConfig;
		}

		[Token(Token = "0x6000033")]
		[Address(RVA = "0x81CCA84", Offset = "0x81CCA84", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._remoteConfig = remoteConfig;\n\treturn;\n")]
		public void SetRemoteConfig(IRemoteConfig remoteConfig)
		{
			_remoteConfig = remoteConfig;
		}

		[Token(Token = "0x6000034")]
		[Address(RVA = "0x81CCA8C", Offset = "0x81CCA8C", Length = "0x368")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tv54 = Unco.RemoteManagementSystem.ScriptableObjects.BaseRemoteConfig::GetLocalString(this._baseRemoteConfig, key);\n\tgoto L_0030;\n\tv97 = System.String::ToLowerInvariant(v74);\n\tv99 = this._remoteConfig == 0;\n\tif (v99) goto L_0099;\n\tgoto L_006C;\n\tv293 = v54;\n\tgoto L_0097;\nL_0079:\n\tv165 = this._baseRemoteConfig == 0;\n\tif (v165) goto L_009B;\n\tv298 = Unco.RemoteManagementSystem.ScriptableObjects.BaseRemoteConfig::GetCompressionMetadata(this._baseRemoteConfig, key);\n\tv166 = v298 == 0;\n\tif (v166) goto L_009D;\n\tv301 = v298.IsCompressed == 0;\n\tv293 = v286;\n\tif (v301) goto L_0097;\n\tv299 = System.String::IsNullOrEmpty(v286);\n\tv306 = v299 == 0;\n\tv300 = ~v306;\n\tv293 = v286;\n\tif (v300) goto L_0097;\n\tv297 = Unco.RemoteManagementSystem.UncoCompression::Decompress(v286);\n\tv293 = v297;\nL_0099:\n\tv161 = new System.NullReferenceException();\n\tgoto L_011C;\nL_009B:\n\tv161 = new System.NullReferenceException();\n\tgoto L_011C;\nL_009D:\n\tv161 = new System.NullReferenceException();\n\tgoto L_011C;\nL_011C:\n\t// 284 Interrupt\n\tv171 = 0x8BF5BF4(v161, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv173 = 0x8BF0368(v161, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal1 = 0x7C03E68(v173, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal1;\nL_0030:\n\tv62 = Unco.RemoteManagementSystem.RemoteKey;\n\tv74 = System.Enum::ToString(&v62 @ stack_-58_v4 (Il2CppClass<Unco.RemoteManagementSystem.RemoteKey>));\nL_006C:\n\tv286 = Unco.RemoteManagementSystem.IRemoteConfig::Get(this._remoteConfig, v97, v54);\n\tv288 = System.String::op_Equality(v286, \"-\");\n\tv290 = v288 == 0;\n\tif (v290) goto L_0079;\nL_0097:\n\treturn v293;\n")]
		public string GetString(RemoteKey key)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RemoteConfigManager::GetString");
			return default;
		}

		[Token(Token = "0x6000035")]
		[Address(RVA = "0x81CD10C", Offset = "0x81CD10C", Length = "0x260")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\nL_001E:\n\tv53 = Unco.RemoteManagementSystem.ScriptableObjects.BaseRemoteConfig::GetLocalFloat(this._baseRemoteConfig, key);\n\tgoto L_002F;\n\tv97 = System.String::ToLowerInvariant(v74);\n\tv99 = this._remoteConfig == 0;\n\tif (v99) goto L_00B3;\n\tgoto L_006B;\n\tv165 = this._remoteConfig == 0;\n\tif (v165) goto L_00B5;\n\tgoto L_00A5;\nL_00B3:\n\tv162 = new System.NullReferenceException();\n\tgoto L_00DC;\nL_00B5:\n\tv162 = new System.NullReferenceException();\n\tgoto L_00DC;\nL_00DC:\n\t// 220 Interrupt\n\tv174 = 0x8BF5BF4(v162, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv176 = 0x8BF0368(v162, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv177 = 0x7C03E68(v176, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn v53;\nL_002F:\n\tv61 = Unco.RemoteManagementSystem.RemoteKey;\n\tv74 = System.Enum::ToString(&v61 @ stack_-58_v4 (Il2CppClass<Unco.RemoteManagementSystem.RemoteKey>));\nL_006B:\n\tv303 = Unco.RemoteManagementSystem.IRemoteConfig::Get(this._remoteConfig, v97, 0);\n\tv305 = System.String::op_Equality(v303, \"-\");\n\tv307 = v305 == 0;\n\tv308 = ~v307;\n\tv323 = v53;\n\tif (v308) goto L_00B1;\nL_00B1:\n\treturn v323;\nL_00A5:\n\tv328 = Unco.RemoteManagementSystem.IRemoteConfig::GetFloat(this._remoteConfig, v97, v53);\n\tv323 = v53;\n")]
		public float GetFloat(RemoteKey key)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RemoteConfigManager::GetFloat");
			return default;
		}

		[Token(Token = "0x6000036")]
		[Address(RVA = "0x81CD4A0", Offset = "0x81CD4A0", Length = "0x260")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\nL_001E:\n\tv53 = Unco.RemoteManagementSystem.ScriptableObjects.BaseRemoteConfig::GetLocalBool(this._baseRemoteConfig, key);\n\tgoto L_002F;\n\tv96 = System.String::ToLowerInvariant(v73);\n\tv98 = this._remoteConfig == 0;\n\tif (v98) goto L_00B3;\n\tgoto L_006B;\n\tv162 = this._remoteConfig == 0;\n\tif (v162) goto L_00B5;\n\tgoto L_00A5;\nL_00B3:\n\tv159 = new System.NullReferenceException();\n\tgoto L_00DC;\nL_00B5:\n\tv159 = new System.NullReferenceException();\n\tgoto L_00DC;\nL_00DC:\n\t// 220 Interrupt\n\tv171 = 0x8BF5BF4(v159, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv173 = 0x8BF0368(v159, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal1 = 0x7C03E68(v173, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal1;\nL_002F:\n\tv61 = Unco.RemoteManagementSystem.RemoteKey;\n\tv73 = System.Enum::ToString(&v61 @ stack_-58_v4 (Il2CppClass<Unco.RemoteManagementSystem.RemoteKey>));\nL_006B:\n\tv299 = Unco.RemoteManagementSystem.IRemoteConfig::Get(this._remoteConfig, v96, 0);\n\tv301 = System.String::op_Equality(v299, \"-\");\n\tv303 = v301 == 0;\n\tv304 = ~v303;\n\tv325 = v53;\n\tif (v304) goto L_00B1;\nL_00B1:\n\treturn v325;\nL_00A5:\n\tv322 = Unco.RemoteManagementSystem.IRemoteConfig::GetBool(this._remoteConfig, v96, v53);\n\tv325 = v322;\n")]
		public bool GetBool(RemoteKey key)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RemoteConfigManager::GetBool");
			return default;
		}

		[Token(Token = "0x6000037")]
		[Address(RVA = "0x81CD858", Offset = "0x81CD858", Length = "0x260")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\nL_001E:\n\tv53 = Unco.RemoteManagementSystem.ScriptableObjects.BaseRemoteConfig::GetLocalInt(this._baseRemoteConfig, key);\n\tgoto L_002F;\n\tv96 = System.String::ToLowerInvariant(v73);\n\tv98 = this._remoteConfig == 0;\n\tif (v98) goto L_00B3;\n\tgoto L_006B;\n\tv162 = this._remoteConfig == 0;\n\tif (v162) goto L_00B5;\n\tgoto L_00A5;\nL_00B3:\n\tv159 = new System.NullReferenceException();\n\tgoto L_00DC;\nL_00B5:\n\tv159 = new System.NullReferenceException();\n\tgoto L_00DC;\nL_00DC:\n\t// 220 Interrupt\n\tv171 = 0x8BF5BF4(v159, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv173 = 0x8BF0368(v159, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal1 = 0x7C03E68(v173, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal1;\nL_002F:\n\tv61 = Unco.RemoteManagementSystem.RemoteKey;\n\tv73 = System.Enum::ToString(&v61 @ stack_-58_v4 (Il2CppClass<Unco.RemoteManagementSystem.RemoteKey>));\nL_006B:\n\tv299 = Unco.RemoteManagementSystem.IRemoteConfig::Get(this._remoteConfig, v96, 0);\n\tv301 = System.String::op_Equality(v299, \"-\");\n\tv303 = v301 == 0;\n\tv304 = ~v303;\n\tv325 = v53;\n\tif (v304) goto L_00B1;\nL_00B1:\n\treturn v325;\nL_00A5:\n\tv322 = Unco.RemoteManagementSystem.IRemoteConfig::GetInt(this._remoteConfig, v96, v53);\n\tv325 = v322;\n")]
		public int GetInt(RemoteKey key)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RemoteConfigManager::GetInt");
			return default;
		}

		[Token(Token = "0x6000038")]
		[Address(RVA = "0x4C5BD68", Offset = "0x4C5BD68", Length = "0x230")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tgoto L_001C;\n\tv40 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_001C:\n\tv47 = this._baseRemoteConfig == 0;\n\tif (v47) goto L_0087;\n\tv53 = Unco.RemoteManagementSystem.ScriptableObjects.BaseRemoteConfig::GetLocalJson(this._baseRemoteConfig, key);\n\tv60 = Unco.RemoteManagementSystem.RemoteConfigManager::GetRemoteKey(this, key);\n\tv65 = Unco.RemoteManagementSystem.RemoteConfigManager::GetString(this, key);\n\tgoto L_0036;\nL_0036:\n\tv128 = Unco.Extensions.StringExtensions::IsNullOrWhiteSpace(v65);\n\tv135 = v128 == 0;\n\tif (v135) goto L_0048;\n\treturnVal2 = 0;\nL_0048:\n\tv145 = System.String::op_Equality(v65, \"-\");\n\tv188 = v145 == 0;\n\tif (v188) goto L_005D;\n\treturn v53;\nL_005D:\n\tgoto L_0061;\nL_0061:\n\tv242 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tv248 = UnityEngine.JsonUtility::FromJson(v65, v242);\n\tgoto L_0072;\n\treturnVal2 = 0x21C11D0(v248, Il2CppClass<T>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv260 = returnVal2 == 0;\n\tv215 = ~v260;\n\tif (v215) goto L_0042;\n\tv244 = new System.InvalidCastException();\n\tgoto L_00B7;\nL_0086:\n\treturn 0;\nL_0087:\n\tv54 = new System.NullReferenceException();\n\tgoto L_0098;\nL_0098:\n\tv76 = key != 1;\n\tv120 = v54;\n\tif (v76) goto L_00BB;\n\tv85 = 0x8BF5BC4(v54, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv131 = 0xB28E000 + 0x98;\n\tv136 = *([v85 @ X0_v11]);\n\tv138 = \"il2cpp_vm_class_is_assignable_from\"(v131, *([v136 @ X8_v5]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv146 = v138 == 0;\n\tif (v146) goto L_00B0;\n\tv223 = 0x8BF5BF4(v138, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn v7;\nL_00B0:\n\tv225 = 0x8BF5BAC(8, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v225 @ X0_v17]) = *([v85 @ X0_v11]);\n\tv235 = 0xA67A000 + 0x440;\n\tv244 = 0x8BF5C48(v225, v235, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_00B7:\n\t// 183 Interrupt\n\tv111 = 0x8BF5BF4(v244, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv120 = v244;\nL_00BB:\n\tv123 = 0x8BF0368(v120, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal1 = 0xA1B8(v123, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal1;\nL_0072:\n\tv189 = v248 == 0;\n\tif (v189) goto L_0086;\nL_0042:\n\treturn returnVal2;\n")]
		public T GetJson<T>(RemoteKey key)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RemoteConfigManager::GetJson");
			return default;
		}

		[Token(Token = "0x6000039")]
		[Address(RVA = "0x4C5C6D8", Offset = "0x4C5C6D8", Length = "0x1C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tgoto L_001F;\n\tv40 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_001F:\n\tv47 = this._baseRemoteConfig == 0;\n\tif (v47) goto L_0065;\n\tv54 = Unco.RemoteManagementSystem.ScriptableObjects.BaseRemoteConfig::GetLocalJsonWithNewton(this._baseRemoteConfig, key);\n\tv62 = Unco.RemoteManagementSystem.RemoteConfigManager::GetRemoteKey(this, key);\n\tv67 = Unco.RemoteManagementSystem.RemoteConfigManager::GetString(this, key);\n\tgoto L_0039;\nL_0039:\n\tv107 = Unco.Extensions.StringExtensions::IsNullOrWhiteSpace(v67);\n\tv114 = v107 == 0;\n\tif (v114) goto L_004C;\n\tv182 = 0;\nL_004C:\n\tv124 = System.String::op_Equality(v67, \"-\");\n\tv186 = v124 == 0;\n\tv184 = ~v186;\n\tv182 = v54;\n\tif (v184) goto L_0046;\n\tgoto L_005C;\nL_005C:\n\treturnVal4 = Newtonsoft.Json.JsonConvert::DeserializeObject(v67);\n\treturn returnVal4;\nL_0065:\n\tv55 = new System.NullReferenceException();\n\tgoto L_0075;\nL_0075:\n\tv78 = key != 1;\n\tv99 = v55;\n\tif (v78) goto L_0098;\n\tv88 = 0x8BF5BC4(v55, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv110 = 0xB28E000 + 0x98;\n\tv115 = *([v88 @ X0_v9]);\n\tv117 = \"il2cpp_vm_class_is_assignable_from\"(v110, *([v115 @ X8_v4]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv96 = v117 == 0;\n\tif (v96) goto L_008D;\n\tv187 = 0x8BF5BF4(v117, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn v7;\nL_008D:\n\tv189 = 0x8BF5BAC(8, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v189 @ X0_v15]) = *([v88 @ X0_v9]);\n\tv90 = 0xA67A000 + 0x440;\n\tv196 = 0x8BF5C48(v189, v90, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv94 = 0x8BF5BF4(v196, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv99 = v196;\nL_0098:\n\tv102 = 0x8BF0368(v99, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal1 = 0xA1B8(v102, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal1;\nL_0046:\n\treturn v182;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public T GetJsonWithNewton<T>(RemoteKey key)
		{
			if ((object)_baseRemoteConfig != null)
			{
				T localJsonWithNewton = _baseRemoteConfig.GetLocalJsonWithNewton<T>(key);
				string remoteKey = GetRemoteKey(key);
				string text = GetString(key);
				T result;
				if (text.IsNullOrWhiteSpace())
				{
					result = default(T);
				}
				else
				{
					bool flag = text == "-";
					bool flag2 = !flag;
					bool flag3 = !flag2;
					result = localJsonWithNewton;
					if (!flag3)
					{
						return JsonConvert.DeserializeObject<T>(text);
					}
				}
				return result;
			}
			NullReferenceException ex = new NullReferenceException();
			bool flag4 = key != RemoteKey.level_name_order;
			NullReferenceException ex2 = ex;
			if (!flag4)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5BC4");
				int num = 187228160 + 152;
				object obj2 = default(object);
				object obj = obj2;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_class_is_assignable_from", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
				object obj3 = default(object);
				if (obj3 != null)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5BF4");
					T result2 = default(T);
					return result2;
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5BAC");
				object obj4 = obj2;
				RemoteKey remoteKey2 = (RemoteKey)174564416;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5C48");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5BF4");
				NullReferenceException ex3 = default(NullReferenceException);
				ex2 = ex3;
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF0368");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @A1B8");
			T result3 = default(T);
			return result3;
		}

		[Token(Token = "0x600003A")]
		[Address(RVA = "0x81CCF00", Offset = "0x81CCF00", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\treturnVal1 = System.String::ToLowerInvariant(v51);\n\treturn returnVal1;\nL_0018:\n\tv46 = Unco.RemoteManagementSystem.RemoteKey;\n\tv51 = System.Enum::ToString(&v46 @ stack_-48_v1 (Il2CppClass<Unco.RemoteManagementSystem.RemoteKey>));\n")]
		public string GetRemoteKey(RemoteKey remoteKey)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RemoteConfigManager::GetRemoteKey");
			return default;
		}

		[Token(Token = "0x600003B")]
		[Address(RVA = "0x81CDB5C", Offset = "0x81CDB5C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public RemoteConfigManager()
		{
		}
	}
}
