using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.SaveSystem.Runtime.DataSyncronization;

namespace Unco.SaveSystem.Core.DataSyncronization
{
	[Token(Token = "0x200001C")]
	public static class DataSyncer
	{
		[Token(Token = "0x4000023")]
		private static readonly IDataSyncer _localToRemoteSyncer;

		[Token(Token = "0x4000024")]
		private static readonly IDataSyncer _remoteToLocalSyncer;

		[Token(Token = "0x60000C5")]
		[Address(RVA = "0x3F40300", Offset = "0x3F40300", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0015;\nL_0015:\n\tv183 = v49._localToRemoteSyncer;\n\tv70 = *([v183 @ X20_v3 (Unco.SaveSystem.Runtime.DataSyncronization.IDataSyncer)]);\n\tv144 = *([v70 @ X8_v13 (Il2CppClass<Unco.SaveSystem.Runtime.DataSyncronization.IDataSyncer>)+12E]);\n\tv72 = *([v70 @ X8_v13 (Il2CppClass<Unco.SaveSystem.Runtime.DataSyncronization.IDataSyncer>)+12E]) == 0;\n\tif (v72) goto L_003C;\n\tv141 = *([v70 @ X8_v13 (Il2CppClass<Unco.SaveSystem.Runtime.DataSyncronization.IDataSyncer>)+B0]) + 8;\n\tv141 = v141 + 0x10;\n\tv117 = v144 - 1;\n\tv87 = v144 != 1;\n\tv144 = v117;\n\tif (v87) goto L_0026;\nL_003C:\n\tgoto L_0062;\nL_0053:\n\t;\n\tv183 = v148;\nL_0026:\n\tv133 = *([v141 @ X10_v6-8]) == Unco.SaveSystem.Runtime.DataSyncronization.IDataSyncer;\n\tif (v133) goto L_0053;\nL_0062:\n\tUnco.SaveSystem.Runtime.DataSyncronization.IDataSyncer::SyncInt(v183, key);\nL_0062:\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LocalToRemoteInt(string key)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DataSyncer::LocalToRemoteInt");
		}

		[Token(Token = "0x60000C6")]
		[Address(RVA = "0x3F403F8", Offset = "0x3F403F8", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0015;\nL_0015:\n\tv182 = v49._localToRemoteSyncer;\n\tv70 = *([v182 @ X20_v3 (Unco.SaveSystem.Runtime.DataSyncronization.IDataSyncer)]);\n\tv144 = *([v70 @ X8_v13 (Il2CppClass<Unco.SaveSystem.Runtime.DataSyncronization.IDataSyncer>)+12E]);\n\tv72 = *([v70 @ X8_v13 (Il2CppClass<Unco.SaveSystem.Runtime.DataSyncronization.IDataSyncer>)+12E]) == 0;\n\tif (v72) goto L_003C;\n\tv141 = *([v70 @ X8_v13 (Il2CppClass<Unco.SaveSystem.Runtime.DataSyncronization.IDataSyncer>)+B0]) + 8;\n\tv141 = v141 + 0x10;\n\tv117 = v144 - 1;\n\tv87 = v144 != 1;\n\tv144 = v117;\n\tif (v87) goto L_0026;\nL_003C:\n\tgoto L_0061;\nL_0053:\n\t;\n\tv182 = v148;\nL_0026:\n\tv133 = *([v141 @ X10_v6-8]) == Unco.SaveSystem.Runtime.DataSyncronization.IDataSyncer;\n\tif (v133) goto L_0053;\nL_0061:\n\tUnco.SaveSystem.Runtime.DataSyncronization.IDataSyncer::SyncFloat(v182, key);\nL_0061:\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LocalToRemoteFloat(string key)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DataSyncer::LocalToRemoteFloat");
		}

		[Token(Token = "0x60000C7")]
		[Address(RVA = "0x3F404EC", Offset = "0x3F404EC", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0015;\nL_0015:\n\tv183 = v49._localToRemoteSyncer;\n\tv70 = *([v183 @ X20_v3 (Unco.SaveSystem.Runtime.DataSyncronization.IDataSyncer)]);\n\tv144 = *([v70 @ X8_v13 (Il2CppClass<Unco.SaveSystem.Runtime.DataSyncronization.IDataSyncer>)+12E]);\n\tv72 = *([v70 @ X8_v13 (Il2CppClass<Unco.SaveSystem.Runtime.DataSyncronization.IDataSyncer>)+12E]) == 0;\n\tif (v72) goto L_003C;\n\tv141 = *([v70 @ X8_v13 (Il2CppClass<Unco.SaveSystem.Runtime.DataSyncronization.IDataSyncer>)+B0]) + 8;\n\tv141 = v141 + 0x10;\n\tv117 = v144 - 1;\n\tv87 = v144 != 1;\n\tv144 = v117;\n\tif (v87) goto L_0026;\nL_003C:\n\tgoto L_0062;\nL_0053:\n\t;\n\tv183 = v148;\nL_0026:\n\tv133 = *([v141 @ X10_v6-8]) == Unco.SaveSystem.Runtime.DataSyncronization.IDataSyncer;\n\tif (v133) goto L_0053;\nL_0062:\n\tUnco.SaveSystem.Runtime.DataSyncronization.IDataSyncer::SyncString(v183, key);\nL_0062:\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LocalToRemoteString(string key)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DataSyncer::LocalToRemoteString");
		}

		[Token(Token = "0x60000C8")]
		[Address(RVA = "0x3F405E4", Offset = "0x3F405E4", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0015;\nL_0015:\n\tv182 = v49._remoteToLocalSyncer;\n\tv70 = *([v182 @ X20_v3 (Unco.SaveSystem.Runtime.DataSyncronization.IDataSyncer)]);\n\tv144 = *([v70 @ X8_v13 (Il2CppClass<Unco.SaveSystem.Runtime.DataSyncronization.IDataSyncer>)+12E]);\n\tv72 = *([v70 @ X8_v13 (Il2CppClass<Unco.SaveSystem.Runtime.DataSyncronization.IDataSyncer>)+12E]) == 0;\n\tif (v72) goto L_003C;\n\tv141 = *([v70 @ X8_v13 (Il2CppClass<Unco.SaveSystem.Runtime.DataSyncronization.IDataSyncer>)+B0]) + 8;\n\tv141 = v141 + 0x10;\n\tv117 = v144 - 1;\n\tv87 = v144 != 1;\n\tv144 = v117;\n\tif (v87) goto L_0026;\nL_003C:\n\tgoto L_0061;\nL_0053:\n\t;\n\tv182 = v148;\nL_0026:\n\tv133 = *([v141 @ X10_v6-8]) == Unco.SaveSystem.Runtime.DataSyncronization.IDataSyncer;\n\tif (v133) goto L_0053;\nL_0061:\n\tUnco.SaveSystem.Runtime.DataSyncronization.IDataSyncer::SyncFloat(v182, key);\nL_0061:\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void RemoteToLocalFloat(string key)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DataSyncer::RemoteToLocalFloat");
		}

		[Token(Token = "0x60000C9")]
		[Address(RVA = "0x3F406D8", Offset = "0x3F406D8", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0015;\nL_0015:\n\tv183 = v49._remoteToLocalSyncer;\n\tv70 = *([v183 @ X20_v3 (Unco.SaveSystem.Runtime.DataSyncronization.IDataSyncer)]);\n\tv144 = *([v70 @ X8_v13 (Il2CppClass<Unco.SaveSystem.Runtime.DataSyncronization.IDataSyncer>)+12E]);\n\tv72 = *([v70 @ X8_v13 (Il2CppClass<Unco.SaveSystem.Runtime.DataSyncronization.IDataSyncer>)+12E]) == 0;\n\tif (v72) goto L_003C;\n\tv141 = *([v70 @ X8_v13 (Il2CppClass<Unco.SaveSystem.Runtime.DataSyncronization.IDataSyncer>)+B0]) + 8;\n\tv141 = v141 + 0x10;\n\tv117 = v144 - 1;\n\tv87 = v144 != 1;\n\tv144 = v117;\n\tif (v87) goto L_0026;\nL_003C:\n\tgoto L_0062;\nL_0053:\n\t;\n\tv183 = v148;\nL_0026:\n\tv133 = *([v141 @ X10_v6-8]) == Unco.SaveSystem.Runtime.DataSyncronization.IDataSyncer;\n\tif (v133) goto L_0053;\nL_0062:\n\tUnco.SaveSystem.Runtime.DataSyncronization.IDataSyncer::SyncString(v183, key);\nL_0062:\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void RemoteToLocalString(string key)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DataSyncer::RemoteToLocalString");
		}

		[Token(Token = "0x60000CA")]
		[Address(RVA = "0x3F407D0", Offset = "0x3F407D0", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0015;\nL_0015:\n\tv183 = v49._remoteToLocalSyncer;\n\tv70 = *([v183 @ X20_v3 (Unco.SaveSystem.Runtime.DataSyncronization.IDataSyncer)]);\n\tv144 = *([v70 @ X8_v13 (Il2CppClass<Unco.SaveSystem.Runtime.DataSyncronization.IDataSyncer>)+12E]);\n\tv72 = *([v70 @ X8_v13 (Il2CppClass<Unco.SaveSystem.Runtime.DataSyncronization.IDataSyncer>)+12E]) == 0;\n\tif (v72) goto L_003C;\n\tv141 = *([v70 @ X8_v13 (Il2CppClass<Unco.SaveSystem.Runtime.DataSyncronization.IDataSyncer>)+B0]) + 8;\n\tv141 = v141 + 0x10;\n\tv117 = v144 - 1;\n\tv87 = v144 != 1;\n\tv144 = v117;\n\tif (v87) goto L_0026;\nL_003C:\n\tgoto L_0062;\nL_0053:\n\t;\n\tv183 = v148;\nL_0026:\n\tv133 = *([v141 @ X10_v6-8]) == Unco.SaveSystem.Runtime.DataSyncronization.IDataSyncer;\n\tif (v133) goto L_0053;\nL_0062:\n\tUnco.SaveSystem.Runtime.DataSyncronization.IDataSyncer::SyncInt(v183, key);\nL_0062:\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void RemoteToLocalInt(string key)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DataSyncer::RemoteToLocalInt");
		}

		[Token(Token = "0x60000CB")]
		[Address(RVA = "0x3F408C8", Offset = "0x3F408C8", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv62 = new Unco.SaveSystem.Core.DataSyncronization.RemoteToLocalSyncer();\n\tSystem.Object::.ctor(v62);\n\tv66._remoteToLocalSyncer = v62;\n\treturn;\nL_0020:\n\tv49 = new Unco.SaveSystem.Core.DataSyncronization.LocalToRemoteSyncer();\n\tSystem.Object::.ctor(v49);\n\tv58._localToRemoteSyncer = v49;\n")]
		static DataSyncer()
		{
			LocalToRemoteSyncer localToRemoteSyncer = new LocalToRemoteSyncer();
			_localToRemoteSyncer = localToRemoteSyncer;
			RemoteToLocalSyncer remoteToLocalSyncer = new RemoteToLocalSyncer();
			_remoteToLocalSyncer = remoteToLocalSyncer;
		}
	}
}
