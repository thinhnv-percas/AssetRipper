using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Sirenix.OdinInspector;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;

namespace _game.CoreGameKit.BaseLayer.LevelSystem
{
	[Serializable]
	[Token(Token = "0x200066C")]
	public class LevelOrderConfig : ISerializationCallbackReceiver
	{
		[SerializeField]
		[Token(Token = "0x40015F8")]
		[FieldOffset(Offset = "0x10")]
		private LevelOrderEntry[] m_levelEntries;

		[SerializeField]
		[Token(Token = "0x40015F9")]
		[FieldOffset(Offset = "0x18")]
		private LevelOrderEntry[] m_loopedLevelEntries;

		[SerializeField]
		[Token(Token = "0x40015FA")]
		[FieldOffset(Offset = "0x20")]
		internal LevelOrderAlgorithm m_algorithm;

		[SerializeField]
		[Token(Token = "0x40015FB")]
		[FieldOffset(Offset = "0x28")]
		private LevelSoBase m_migrationAnchorLevel;

		[SerializeField]
		[HideInInspector]
		[Token(Token = "0x40015FC")]
		[FieldOffset(Offset = "0x30")]
		private string m_migrationAnchorUniqueId;

		[NonSerialized]
		[Token(Token = "0x40015FD")]
		[FieldOffset(Offset = "0x38")]
		private LevelIndex[] _resolvedLevelIndices;

		[NonSerialized]
		[Token(Token = "0x40015FE")]
		[FieldOffset(Offset = "0x40")]
		private LevelIndex[] _resolvedLoopedLevelIndices;

		[Token(Token = "0x40015FF")]
		private const int c_maxUnresolvedWarnings = 5;

		[Token(Token = "0x6001B1E")]
		[Address(RVA = "0x3D5A520", Offset = "0x3D5A520", Length = "0x8")]
		public LevelOrderConfig()
		{
		}

		[Token(Token = "0x6001B1F")]
		[Address(RVA = "0x3D5A528", Offset = "0x3D5A528", Length = "0x50")]
		public LevelOrderConfig(LevelOrderEntry[] levelEntries, LevelOrderEntry[] loopedLevelEntries)
		{
			m_levelEntries = levelEntries;
			m_loopedLevelEntries = loopedLevelEntries;
		}

		[Token(Token = "0x6001B20")]
		[Address(RVA = "0x3D5A578", Offset = "0x3D5A578", Length = "0x5C")]
		public LevelOrderConfig(LevelOrderEntry[] levelEntries, LevelOrderEntry[] loopedLevelEntries, LevelOrderAlgorithm algorithm)
		{
			m_levelEntries = levelEntries;
			m_loopedLevelEntries = loopedLevelEntries;
			m_algorithm = algorithm;
		}

		[Token(Token = "0x6001B21")]
		[Address(RVA = "0x3D5A5D4", Offset = "0x3D5A5D4", Length = "0xCC")]
		public static LevelOrderConfig FromIndices(int[] uniqueIndices, int[] loopedIndices, IReadOnlyList<ILevel> levels, LevelOrderAlgorithm algorithm = LevelOrderAlgorithm.LinkedList)
		{
			int[] indices = default(int[]);
			LevelOrderEntry[] levelEntries = IndicesToEntries(indices, levels);
			LevelOrderEntry[] loopedLevelEntries = IndicesToEntries(loopedIndices, levels);
			LevelOrderConfig levelOrderConfig = new LevelOrderConfig();
			levelOrderConfig.m_levelEntries = levelEntries;
			levelOrderConfig.m_loopedLevelEntries = loopedLevelEntries;
			levelOrderConfig.m_algorithm = algorithm;
			levelOrderConfig.Resolve(levels);
			return levelOrderConfig;
		}

		[Token(Token = "0x6001B22")]
		[Address(RVA = "0x3D57D2C", Offset = "0x3D57D2C", Length = "0xF8")]
		public void Resolve(IReadOnlyList<ILevel> levels)
		{
			Dictionary<string, int> byName;
			Dictionary<string, int> byId;
			if (levels != null)
			{
				Dictionary<string, int> dictionary = BuildIdMap(levels);
				Dictionary<string, int> dictionary2 = BuildNameMap(levels);
				byName = dictionary2;
				byId = dictionary;
			}
			else
			{
				byName = null;
				byId = null;
			}
			int warningsLeft = 5;
			LevelIndex[] resolvedLevelIndices = ResolveOne(m_levelEntries, levels, byId, byName, ref warningsLeft, "unique");
			_resolvedLevelIndices = resolvedLevelIndices;
			LevelIndex[] resolvedLoopedLevelIndices = ResolveOne(m_loopedLevelEntries, levels, byId, byName, ref warningsLeft, "loop");
			_resolvedLoopedLevelIndices = resolvedLoopedLevelIndices;
		}

		[Token(Token = "0x6001B23")]
		[Address(RVA = "0x3D5B5B0", Offset = "0x3D5B5B0", Length = "0x76C")]
		private unsafe static LevelIndex[] ResolveOne(LevelOrderEntry[] entries, IReadOnlyList<ILevel> levels, Dictionary<string, int> byId, Dictionary<string, int> byName, ref int warningsLeft, string sectionLabel)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelOrderConfig::ResolveOne");
			return default;
		}

		[Token(Token = "0x6001B24")]
		[Address(RVA = "0x3D5AD10", Offset = "0x3D5AD10", Length = "0x4B8")]
		private static Dictionary<string, int> BuildIdMap(IReadOnlyList<ILevel> levels)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelOrderConfig::BuildIdMap");
			return default;
		}

		[Token(Token = "0x6001B25")]
		[Address(RVA = "0x3D5B1C8", Offset = "0x3D5B1C8", Length = "0x3E8")]
		private static Dictionary<string, int> BuildNameMap(IReadOnlyList<ILevel> levels)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelOrderConfig::BuildNameMap");
			return default;
		}

		[Token(Token = "0x6001B26")]
		[Address(RVA = "0x3D5BED4", Offset = "0x3D5BED4", Length = "0xBC")]
		private static bool IsAliveLevel(ILevel lvl)
		{
			if (lvl == null || (lvl is UnityEngine.Object && (UnityEngine.Object)lvl == null))
			{
				return false;
			}
			return true;
		}

		[Token(Token = "0x6001B27")]
		[Address(RVA = "0x3D59580", Offset = "0x3D59580", Length = "0x168")]
		public ILevel GetLevel(IReadOnlyList<ILevel> levels, int levelIndex)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelOrderConfig::GetLevel");
			return default;
		}

		[Token(Token = "0x6001B28")]
		[Address(RVA = "0x3D5BF90", Offset = "0x3D5BF90", Length = "0xBC")]
		public LevelOrderConfigSerializable ToSerializable()
		{
			LevelOrderConfigSerializable levelOrderConfigSerializable = new LevelOrderConfigSerializable();
			string[] levelEntries = EntriesToLevelNameArray(m_levelEntries);
			levelOrderConfigSerializable.m_levelEntries = levelEntries;
			string[] loopedLevelEntries = EntriesToLevelNameArray(m_loopedLevelEntries);
			levelOrderConfigSerializable.m_loopedLevelEntries = loopedLevelEntries;
			levelOrderConfigSerializable.m_algorithm = (int)m_algorithm;
			string migrationAnchorUniqueId = GetMigrationAnchorUniqueId();
			levelOrderConfigSerializable.m_migrationAnchorUniqueId = migrationAnchorUniqueId;
			return levelOrderConfigSerializable;
		}

		[Token(Token = "0x6001B29")]
		[Address(RVA = "0x3D5C298", Offset = "0x3D5C298", Length = "0xD4")]
		public static LevelOrderConfig FromSerializable(LevelOrderConfigSerializable dto)
		{
			//IL_00b4: Expected O, but got I
			//IL_00c4: Expected O, but got I
			LevelOrderConfig levelOrderConfig = new LevelOrderConfig();
			if (dto != null)
			{
				LevelOrderEntry[] levelEntries = LevelNameArrayToEntries(dto.m_levelEntries);
				levelOrderConfig.m_levelEntries = levelEntries;
				LevelOrderEntry[] loopedLevelEntries = LevelNameArrayToEntries(dto.m_loopedLevelEntries);
				levelOrderConfig.m_loopedLevelEntries = loopedLevelEntries;
				levelOrderConfig.m_algorithm = (LevelOrderAlgorithm)dto.m_algorithm;
				string migrationAnchorUniqueId = dto.m_migrationAnchorUniqueId;
				if (dto.m_migrationAnchorUniqueId == null)
				{
					int num = 192761856 + 1336;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ X8_v7 (System.Int32)+90]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ X8_v8+B8]");
					object obj2 = 0;
					migrationAnchorUniqueId = (string)obj2;
				}
				levelOrderConfig.m_migrationAnchorUniqueId = migrationAnchorUniqueId;
			}
			return levelOrderConfig;
		}

		[Token(Token = "0x6001B2A")]
		[Address(RVA = "0x3D5C054", Offset = "0x3D5C054", Length = "0x244")]
		private unsafe static string[] EntriesToLevelNameArray(LevelOrderEntry[] entries)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelOrderConfig::EntriesToLevelNameArray");
			return default;
		}

		[Token(Token = "0x6001B2B")]
		[Address(RVA = "0x3D5C36C", Offset = "0x3D5C36C", Length = "0x240")]
		private static LevelOrderEntry[] LevelNameArrayToEntries(string[] levelNames)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelOrderConfig::LevelNameArrayToEntries");
			return default;
		}

		[Token(Token = "0x6001B2C")]
		[Address(RVA = "0x3D5C5AC", Offset = "0x3D5C5AC", Length = "0xDC")]
		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
			SyncCachedFields(m_levelEntries);
			SyncCachedFields(m_loopedLevelEntries);
			if (m_migrationAnchorLevel != null)
			{
				LevelSoBase migrationAnchorLevel = m_migrationAnchorLevel;
				if (!string.IsNullOrEmpty(migrationAnchorLevel.UniqueId))
				{
					LevelSoBase migrationAnchorLevel2 = m_migrationAnchorLevel;
					m_migrationAnchorUniqueId = migrationAnchorLevel2.UniqueId;
				}
			}
		}

		[Token(Token = "0x6001B2D")]
		[Address(RVA = "0x3D5C7C8", Offset = "0x3D5C7C8", Length = "0x4")]
		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
		}

		[Token(Token = "0x6001B2E")]
		[Address(RVA = "0x3D5C688", Offset = "0x3D5C688", Length = "0x140")]
		private static void SyncCachedFields(LevelOrderEntry[] entries)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelOrderConfig::SyncCachedFields");
		}

		[Token(Token = "0x6001B2F")]
		[Address(RVA = "0x3D5A6A0", Offset = "0x3D5A6A0", Length = "0x670")]
		private unsafe static LevelOrderEntry[] IndicesToEntries(int[] indices, IReadOnlyList<ILevel> levels)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelOrderConfig::IndicesToEntries");
			return default;
		}

		[Token(Token = "0x6001B30")]
		[Address(RVA = "0x3D5C7CC", Offset = "0x3D5C7CC", Length = "0xE8")]
		public LevelOrderEntry[] GetLevelEntries()
		{
			//IL_0009: Expected O, but got I4
			object obj = 192466944;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DD84]");
			LevelOrderEntry[] levelEntries;
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				levelEntries = m_levelEntries;
				if (m_levelEntries != null)
				{
					goto IL_0061;
				}
			}
			else
			{
				_ = 1;
				levelEntries = m_levelEntries;
				if (m_levelEntries != null)
				{
					goto IL_0061;
				}
			}
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X0_v17 (Il2CppClass<System.EmptyArray`1<_game.CoreGameKit.BaseLayer.LevelSystem.LevelOrderEntry>>)+135]");
			int num2 = (int)((nint)0 & (nint)1);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (flag)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ X0_v6+E4]");
				if ((nint)0 != 0)
				{
				}
			}
			return Array.Empty<LevelOrderEntry>();
			IL_0061:
			return levelEntries;
		}

		[Token(Token = "0x6001B31")]
		[Address(RVA = "0x3D5C8B4", Offset = "0x3D5C8B4", Length = "0xE8")]
		public LevelOrderEntry[] GetLoopedLevelEntries()
		{
			//IL_0009: Expected O, but got I4
			object obj = 192466944;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DD85]");
			LevelOrderEntry[] loopedLevelEntries;
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				loopedLevelEntries = m_loopedLevelEntries;
				if (m_loopedLevelEntries != null)
				{
					goto IL_0061;
				}
			}
			else
			{
				_ = 1;
				loopedLevelEntries = m_loopedLevelEntries;
				if (m_loopedLevelEntries != null)
				{
					goto IL_0061;
				}
			}
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X0_v17 (Il2CppClass<System.EmptyArray`1<_game.CoreGameKit.BaseLayer.LevelSystem.LevelOrderEntry>>)+135]");
			int num2 = (int)((nint)0 & (nint)1);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (flag)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ X0_v6+E4]");
				if ((nint)0 != 0)
				{
				}
			}
			return Array.Empty<LevelOrderEntry>();
			IL_0061:
			return loopedLevelEntries;
		}

		[Token(Token = "0x6001B32")]
		[Address(RVA = "0x3D59054", Offset = "0x3D59054", Length = "0xE8")]
		public LevelIndex[] GetLevelIndices()
		{
			//IL_0009: Expected O, but got I4
			object obj = 192466944;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DD86]");
			LevelIndex[] resolvedLevelIndices;
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				resolvedLevelIndices = _resolvedLevelIndices;
				if (_resolvedLevelIndices != null)
				{
					goto IL_0061;
				}
			}
			else
			{
				_ = 1;
				resolvedLevelIndices = _resolvedLevelIndices;
				if (_resolvedLevelIndices != null)
				{
					goto IL_0061;
				}
			}
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X0_v17 (Il2CppClass<System.EmptyArray`1<_game.CoreGameKit.BaseLayer.LevelSystem.LevelIndex>>)+135]");
			int num2 = (int)((nint)0 & (nint)1);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (flag)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ X0_v6+E4]");
				if ((nint)0 != 0)
				{
				}
			}
			return Array.Empty<LevelIndex>();
			IL_0061:
			return resolvedLevelIndices;
		}

		[Token(Token = "0x6001B33")]
		[Address(RVA = "0x3D58F6C", Offset = "0x3D58F6C", Length = "0xE8")]
		public LevelIndex[] GetLoopedLevelIndices()
		{
			//IL_0009: Expected O, but got I4
			object obj = 192466944;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DD87]");
			LevelIndex[] resolvedLoopedLevelIndices;
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				resolvedLoopedLevelIndices = _resolvedLoopedLevelIndices;
				if (_resolvedLoopedLevelIndices != null)
				{
					goto IL_0061;
				}
			}
			else
			{
				_ = 1;
				resolvedLoopedLevelIndices = _resolvedLoopedLevelIndices;
				if (_resolvedLoopedLevelIndices != null)
				{
					goto IL_0061;
				}
			}
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X0_v17 (Il2CppClass<System.EmptyArray`1<_game.CoreGameKit.BaseLayer.LevelSystem.LevelIndex>>)+135]");
			int num2 = (int)((nint)0 & (nint)1);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (flag)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ X0_v6+E4]");
				if ((nint)0 != 0)
				{
				}
			}
			return Array.Empty<LevelIndex>();
			IL_0061:
			return resolvedLoopedLevelIndices;
		}

		[Token(Token = "0x6001B34")]
		[Address(RVA = "0x3D5C99C", Offset = "0x3D5C99C", Length = "0x8")]
		public LevelOrderAlgorithm GetAlgorithm()
		{
			return m_algorithm;
		}

		[Token(Token = "0x6001B35")]
		[Address(RVA = "0x3D5A0BC", Offset = "0x3D5A0BC", Length = "0x100")]
		public string GetMigrationAnchorUniqueId()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelOrderConfig::GetMigrationAnchorUniqueId");
			return default;
		}

		[Token(Token = "0x6001B36")]
		[Address(RVA = "0x3D5C9A4", Offset = "0x3D5C9A4", Length = "0x2BC")]
		private IEnumerable<ValueDropdownItem<LevelSoBase>> Editor_GetUniqueAnchorCandidates()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelOrderConfig::Editor_GetUniqueAnchorCandidates");
			return default;
		}
	}
}
