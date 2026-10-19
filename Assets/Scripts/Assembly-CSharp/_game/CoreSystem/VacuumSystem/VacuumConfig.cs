using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.RemoteManagementSystem;
using UnityEngine;

namespace _game.CoreSystem.VacuumSystem
{
	[CreateAssetMenu(menuName = "SandFlow/Boosters/Vacuum Config", fileName = "VacuumConfig")]
	[Token(Token = "0x200012E")]
	public class VacuumConfig : ScriptableObject
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200012F")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40003EA")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40003EB")]
			public static Func<VacuumConfigData, int> _003C_003E9__5_0;

			[Token(Token = "0x40003EC")]
			public static Func<VacuumConfigData, int> _003C_003E9__7_0;

			[Token(Token = "0x6000615")]
			[Address(RVA = "0x3DB2748", Offset = "0x3DB2748", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.VacuumSystem.VacuumConfig+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000616")]
			[Address(RVA = "0x3DB27AC", Offset = "0x3DB27AC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal int _003Cget_BoosterConfig_003Eb__5_0(VacuumConfigData remote)
			{
				return remote.BoosterCapacity;
			}

			internal int _003Cget_KeepPlayingConfig_003Eb__7_0(VacuumConfigData remote)
			{
				return remote.KeepPlayingCapacity;
			}
		}

		[SerializeField]
		[Token(Token = "0x40003E6")]
		[FieldOffset(Offset = "0x18")]
		private VacuumExecuteConfig m_boosterConfig;

		[SerializeField]
		[Token(Token = "0x40003E7")]
		[FieldOffset(Offset = "0x28")]
		private VacuumExecuteConfig m_keepPlayingConfig;

		[SerializeField]
		[Token(Token = "0x40003E8")]
		[FieldOffset(Offset = "0x38")]
		internal VacuumScoringWeights m_scoringWeights;

		[Inject(true)]
		[Token(Token = "0x40003E9")]
		[FieldOffset(Offset = "0x50")]
		private RemoteConfigManager _remoteConfigManager;

		[Token(Token = "0x17000092")]
		public VacuumExecuteConfig BoosterConfig
		{
			[Token(Token = "0x6000610")]
			[Address(RVA = "0x3DB2360", Offset = "0x3DB2360", Length = "0x190")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\nL_0012:\n\tv154 = this.m_boosterConfig;\n\tgoto L_0019;\nL_0019:\n\tv151 = v59.<>9__5_0;\n\tv61 = v59.<>9__5_0 == 0;\nL_FFFFFFFF:\n\tv210 = this.m_boosterConfig;\n\tif (v61) goto L_0042;\n\tv83 = *([B78E0D3]) & 1;\n\tv84 = v83 == 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv126 = v151;\nL_FFFFFFFF:\n\tv210 = v154;\n\tif (v84) goto L_0062;\nL_0021:\n\tv152 = this._remoteConfigManager;\n\tv119 = this._remoteConfigManager == 0;\n\tv120 = ~v119;\n\tif (v120) goto L_006A;\nL_FFFFFFFF:\n\tv210 = v154;\n\tgoto L_0092;\nL_0042:\n\tgoto L_004A;\n\tv257 = *([B78E0D3]) & 1;\n\tv258 = v257 == 0;\n\tv114 = ~v258;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv151 = v143;\nL_FFFFFFFF:\n\tv154 = v154;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv126 = v143;\n\tif (v114) goto L_0021;\nL_0062:\n\t*([B78E0D3]) = 1;\n\tv152 = this._remoteConfigManager;\n\tv156 = this._remoteConfigManager == 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv151 = v126;\nL_FFFFFFFF:\n\tv154 = v210;\n\tif (v156) goto L_0092;\nL_006A:\n\tv164 = Unco.RemoteManagementSystem.RemoteConfigManager::GetJson(v152, 0x17);\n\tv214 = v164 == 0;\nL_FFFFFFFF:\n\tv210 = v154;\n\tif (v214) goto L_0092;\n\tv209 = System.Func`2<_game.CoreSystem.VacuumSystem.VacuumConfigData, System.Int32>::Invoke(v151, v164);\n\tv194 = v209 - 1;\n\tv191 = v194 < 0;\n\tv185 = v209 ^ 1;\n\tv182 = v209 ^ v194;\n\tv179 = v185 & v182;\n\tv176 = v179 < 0;\n\tv262 = v191 == v176;\n\tv173 = ~v262;\n\tv170 = ~v173;\n\tif (v170) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv216 = v154;\n\tgoto L_0085;\nL_FFFFFFFF:\n\tv216 = v209;\nL_0092:\n\treturn v210;\nL_004A:\n\tv143 = new System.Func`2<_game.CoreSystem.VacuumSystem.VacuumConfigData, System.Int32>();\n\tSystem.Func`2<_game.CoreSystem.VacuumSystem.VacuumConfigData, System.Int32>::.ctor(v143, v137.<>9, Il2CppMethodInfo);\n\tv229.<>9__5_0 = v143;\nL_0085:\n\tv205 = v154 & 0xFFFFFFFF00000000;\n\tv211 = v205 | v216;\nL_FFFFFFFF:\n\tv210 = v211;\n")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("VacuumConfig::get_BoosterConfig");
				return default;
			}
		}

		[Token(Token = "0x17000093")]
		public VacuumExecuteConfig KeepPlayingConfig
		{
			[Token(Token = "0x6000611")]
			[Address(RVA = "0x3DB259C", Offset = "0x3DB259C", Length = "0x190")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\nL_0012:\n\tv154 = this.m_keepPlayingConfig;\n\tgoto L_0019;\nL_0019:\n\tv151 = v59.<>9__7_0;\n\tv61 = v59.<>9__7_0 == 0;\nL_FFFFFFFF:\n\tv210 = this.m_keepPlayingConfig;\n\tif (v61) goto L_0042;\n\tv83 = *([B78E0D3]) & 1;\n\tv84 = v83 == 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv126 = v151;\nL_FFFFFFFF:\n\tv210 = v154;\n\tif (v84) goto L_0062;\nL_0021:\n\tv152 = this._remoteConfigManager;\n\tv119 = this._remoteConfigManager == 0;\n\tv120 = ~v119;\n\tif (v120) goto L_006A;\nL_FFFFFFFF:\n\tv210 = v154;\n\tgoto L_0092;\nL_0042:\n\tgoto L_004A;\n\tv257 = *([B78E0D3]) & 1;\n\tv258 = v257 == 0;\n\tv114 = ~v258;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv151 = v143;\nL_FFFFFFFF:\n\tv154 = v154;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv126 = v143;\n\tif (v114) goto L_0021;\nL_0062:\n\t*([B78E0D3]) = 1;\n\tv152 = this._remoteConfigManager;\n\tv156 = this._remoteConfigManager == 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv151 = v126;\nL_FFFFFFFF:\n\tv154 = v210;\n\tif (v156) goto L_0092;\nL_006A:\n\tv164 = Unco.RemoteManagementSystem.RemoteConfigManager::GetJson(v152, 0x17);\n\tv214 = v164 == 0;\nL_FFFFFFFF:\n\tv210 = v154;\n\tif (v214) goto L_0092;\n\tv209 = System.Func`2<_game.CoreSystem.VacuumSystem.VacuumConfigData, System.Int32>::Invoke(v151, v164);\n\tv194 = v209 - 1;\n\tv191 = v194 < 0;\n\tv185 = v209 ^ 1;\n\tv182 = v209 ^ v194;\n\tv179 = v185 & v182;\n\tv176 = v179 < 0;\n\tv262 = v191 == v176;\n\tv173 = ~v262;\n\tv170 = ~v173;\n\tif (v170) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv216 = v154;\n\tgoto L_0085;\nL_FFFFFFFF:\n\tv216 = v209;\nL_0092:\n\treturn v210;\nL_004A:\n\tv143 = new System.Func`2<_game.CoreSystem.VacuumSystem.VacuumConfigData, System.Int32>();\n\tSystem.Func`2<_game.CoreSystem.VacuumSystem.VacuumConfigData, System.Int32>::.ctor(v143, v137.<>9, Il2CppMethodInfo);\n\tv229.<>9__7_0 = v143;\nL_0085:\n\tv205 = v154 & 0xFFFFFFFF00000000;\n\tv211 = v205 | v216;\nL_FFFFFFFF:\n\tv210 = v211;\n")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("VacuumConfig::get_KeepPlayingConfig");
				return default;
			}
		}

		[Token(Token = "0x17000094")]
		public VacuumScoringWeights ScoringWeights
		{
			[Token(Token = "0x6000612")]
			[Address(RVA = "0x3DB272C", Offset = "0x3DB272C", Length = "0x14")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnBuffer.WFront = this.m_scoringWeights;\n\treturnBuffer.ProximityMaxReach = this.m_scoringWeights.ProximityMaxReach;\n\treturn returnBuffer;\n")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("VacuumConfig::get_ScoringWeights");
				return default;
			}
		}

		[Token(Token = "0x6000613")]
		[Address(RVA = "0x3DB24F0", Offset = "0x3DB24F0", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv55 = Unco.RemoteManagementSystem.RemoteConfigManager::GetJson(this._remoteConfigManager, 0x17);\n\tv95 = v55 == 0;\nL_FFFFFFFF:\n\tv98 = config;\n\tif (v95) goto L_0049;\n\tv92 = System.Func`2<_game.CoreSystem.VacuumSystem.VacuumConfigData, System.Int32>::Invoke(capacitySelector, v55);\n\tv84 = v92 - 1;\n\tv81 = v84 < 0;\n\tv75 = v92 ^ 1;\n\tv72 = v92 ^ v84;\n\tv69 = v75 & v72;\n\tv66 = v69 < 0;\n\tv140 = v81 == v66;\n\tv63 = ~v140;\n\tv60 = ~v63;\n\tif (v60) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv97 = config;\n\tgoto L_003C;\nL_FFFFFFFF:\n\tv97 = v92;\nL_001B:\n\tv50 = this._remoteConfigManager == 0;\nL_FFFFFFFF:\n\tv98 = config;\n\tif (v50) goto L_0049;\nL_0049:\n\treturn v98;\nL_003C:\n\tv57 = config & 0xFFFFFFFF00000000;\n\tv99 = v57 | v97;\nL_FFFFFFFF:\n\tv98 = v99;\n")]
		private VacuumExecuteConfig ApplyRemoteOverride(VacuumExecuteConfig config, Func<VacuumConfigData, int> capacitySelector)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VacuumConfig::ApplyRemoteOverride");
			return default;
		}

		[Token(Token = "0x6000614")]
		[Address(RVA = "0x3DB2740", Offset = "0x3DB2740", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n")]
		public VacuumConfig()
		{
		}
	}
}
