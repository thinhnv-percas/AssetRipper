using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Cpp2ILInjected;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;

namespace _game.CoreGameKit.BaseLayer.LevelSystem
{
	[Token(Token = "0x200066A")]
	public class LevelList : ILevelList
	{
		[Token(Token = "0x200066B")]
		private struct GuidEntry
		{
			[Token(Token = "0x40015F6")]
			[FieldOffset(Offset = "0x0")]
			public int UniquePosition;

			[Token(Token = "0x40015F7")]
			[FieldOffset(Offset = "0x4")]
			public int LoopPosition;
		}

		[Token(Token = "0x40015F0")]
		[FieldOffset(Offset = "0x10")]
		private readonly IReadOnlyList<ILevel> _levels;

		[Token(Token = "0x40015F1")]
		[FieldOffset(Offset = "0x18")]
		private readonly LevelOrderConfig _levelOrderConfig;

		[Token(Token = "0x40015F2")]
		[FieldOffset(Offset = "0x20")]
		private readonly Dictionary<string, GuidEntry> _guidToEntry;

		[Token(Token = "0x40015F3")]
		[FieldOffset(Offset = "0x28")]
		private readonly string _orderSignature;

		[Token(Token = "0x40015F4")]
		[FieldOffset(Offset = "0x30")]
		internal LevelNavigationResolver _navigationResolver;

		[Token(Token = "0x40015F5")]
		[FieldOffset(Offset = "0x38")]
		internal Func<LevelNavigationResolver> _navigationResolverProvider;

		[Token(Token = "0x1700029B")]
		public IEnumerable<ILevel> Internal_LevelList
		{
			[Token(Token = "0x6001B12")]
			[Address(RVA = "0x3D59DC8", Offset = "0x3D59DC8", Length = "0x8")]
			get
			{
				return _levels;
			}
		}

		[Token(Token = "0x6001B05")]
		[Address(RVA = "0x3D57C18", Offset = "0x3D57C18", Length = "0x8")]
		public void SetNavigationResolver(LevelNavigationResolver resolver)
		{
			_navigationResolver = resolver;
		}

		[Token(Token = "0x6001B06")]
		[Address(RVA = "0x3D57C20", Offset = "0x3D57C20", Length = "0x8")]
		public void SetNavigationResolverProvider(Func<LevelNavigationResolver> provider)
		{
			_navigationResolverProvider = provider;
		}

		[Token(Token = "0x6001B07")]
		[Address(RVA = "0x3D57C28", Offset = "0x3D57C28", Length = "0x64")]
		private LevelNavigationResolver ResolveNavigationResolver()
		{
			if (_navigationResolver != null)
			{
				return _navigationResolver;
			}
			if (_navigationResolverProvider != null)
			{
				LevelNavigationResolver levelNavigationResolver = _navigationResolverProvider();
				if (levelNavigationResolver != null)
				{
					_navigationResolver = levelNavigationResolver;
				}
			}
			return _navigationResolver;
		}

		[Token(Token = "0x6001B08")]
		[Address(RVA = "0x3D57C8C", Offset = "0x3D57C8C", Length = "0xA0")]
		public LevelList(IReadOnlyList<ILevel> levels, LevelOrderConfig levelOrderConfig)
		{
			_levels = levels;
			_levelOrderConfig = levelOrderConfig;
			if (_levelOrderConfig != null)
			{
				_levelOrderConfig.Resolve(_levels);
			}
			Dictionary<string, GuidEntry> guidToEntry = BuildGuidIndex();
			_guidToEntry = guidToEntry;
			string orderSignature = ComputeOrderSignature();
			_orderSignature = orderSignature;
			WarnIfLoopHasDuplicates();
		}

		[Token(Token = "0x6001B09")]
		[Address(RVA = "0x3D58C20", Offset = "0x3D58C20", Length = "0x34C")]
		private void WarnIfLoopHasDuplicates()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelList::WarnIfLoopHasDuplicates");
		}

		[Token(Token = "0x6001B0A")]
		[Address(RVA = "0x3D57E24", Offset = "0x3D57E24", Length = "0x58C")]
		private Dictionary<string, GuidEntry> BuildGuidIndex()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelList::BuildGuidIndex");
			return default;
		}

		[Token(Token = "0x6001B0B")]
		[Address(RVA = "0x3D583B0", Offset = "0x3D583B0", Length = "0x870")]
		private unsafe string ComputeOrderSignature()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelList::ComputeOrderSignature");
			return default;
		}

		[Token(Token = "0x6001B0C")]
		[Address(RVA = "0x3D5913C", Offset = "0x3D5913C", Length = "0x3A4")]
		public ILevel GetLevel(int levelIndex)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelList::GetLevel");
			return default;
		}

		[Token(Token = "0x6001B0D")]
		[Address(RVA = "0x3D596E8", Offset = "0x3D596E8", Length = "0xD8")]
		public ILevel GetLevelByGuid(string guid)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelList::GetLevelByGuid");
			return default;
		}

		[Token(Token = "0x6001B0E")]
		[Address(RVA = "0x3D599B8", Offset = "0x3D599B8", Length = "0x220")]
		public ILevel GetLevelFromDatabaseByGuid(string guid)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelList::GetLevelFromDatabaseByGuid");
			return default;
		}

		[Token(Token = "0x6001B0F")]
		[Address(RVA = "0x3D59BD8", Offset = "0x3D59BD8", Length = "0xFC")]
		public int GetIndexByGuid(string guid)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelList::GetIndexByGuid");
			return default;
		}

		[Token(Token = "0x6001B10")]
		[Address(RVA = "0x3D59CD4", Offset = "0x3D59CD4", Length = "0xB8")]
		public IEnumerable<ILevel> GetLevelRange(int startIndex, int count)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelList::GetLevelRange");
			return default;
		}

		[Token(Token = "0x6001B11")]
		[Address(RVA = "0x3D59D8C", Offset = "0x3D59D8C", Length = "0x3C")]
		public bool IsLoopLevel(int levelIndex)
		{
			//IL_0023: Expected O, but got I4
			LevelIndex[] levelIndices = _levelOrderConfig.GetLevelIndices();
			object obj = levelIndices.Length - levelIndex;
			bool flag = (nint)obj < 0;
			bool flag2 = obj == null;
			int num = levelIndices.Length ^ levelIndex;
			int num2 = (int)(levelIndices.Length ^ (nint)obj);
			int num3 = num & num2;
			bool flag3 = num3 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag4;
			return flag5 || flag2;
		}

		[Token(Token = "0x6001B13")]
		[Address(RVA = "0x3D59DD0", Offset = "0x3D59DD0", Length = "0xD8")]
		public bool TryGetGuidInfo(string guid, out bool isLoop, out int positionInArray)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelList::TryGetGuidInfo");
			isLoop = default;
			positionInArray = default;
			return default;
		}

		[Token(Token = "0x6001B14")]
		[Address(RVA = "0x3D59EA8", Offset = "0x3D59EA8", Length = "0xC0")]
		public bool TryGetUniquePosition(string guid, out int position)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelList::TryGetUniquePosition");
			position = default;
			return default;
		}

		[Token(Token = "0x6001B15")]
		[Address(RVA = "0x3D59F68", Offset = "0x3D59F68", Length = "0xC0")]
		public bool TryGetLoopPosition(string guid, out int position)
		{
			//IL_0066: Expected I4, but got I8
			//IL_009b: Expected I4, but got O
			position = default(int);
			GuidEntry value = default(GuidEntry);
			object obj = default(object);
			if (string.IsNullOrEmpty(guid) || !_guidToEntry.TryGetValue(guid, out value) || (int)((nint)obj & 0x80000000L) != 0)
			{
				position = -1;
				return false;
			}
			position = (int)obj;
			return true;
		}

		[Token(Token = "0x6001B16")]
		[Address(RVA = "0x3D5A028", Offset = "0x3D5A028", Length = "0x28")]
		public int GetUniqueLength()
		{
			LevelIndex[] levelIndices = _levelOrderConfig.GetLevelIndices();
			return levelIndices.Length;
		}

		[Token(Token = "0x6001B17")]
		[Address(RVA = "0x3D5A050", Offset = "0x3D5A050", Length = "0x28")]
		public int GetLoopLength()
		{
			LevelIndex[] loopedLevelIndices = _levelOrderConfig.GetLoopedLevelIndices();
			return loopedLevelIndices.Length;
		}

		[Token(Token = "0x6001B18")]
		[Address(RVA = "0x3D597C0", Offset = "0x3D597C0", Length = "0xF0")]
		public ILevel GetUniqueAt(int position)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelList::GetUniqueAt");
			return default;
		}

		[Token(Token = "0x6001B19")]
		[Address(RVA = "0x3D598B0", Offset = "0x3D598B0", Length = "0x108")]
		public ILevel GetLoopAt(int position)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelList::GetLoopAt");
			return default;
		}

		[Token(Token = "0x6001B1A")]
		[Address(RVA = "0x3D5A078", Offset = "0x3D5A078", Length = "0x8")]
		public string GetOrderSignature()
		{
			return _orderSignature;
		}

		[Token(Token = "0x6001B1B")]
		[Address(RVA = "0x3D5A080", Offset = "0x3D5A080", Length = "0x3C")]
		public string GetMigrationAnchorUniqueId()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelList::GetMigrationAnchorUniqueId");
			return default;
		}

		[Token(Token = "0x6001B1C")]
		[Address(RVA = "0x3D5A1BC", Offset = "0x3D5A1BC", Length = "0x1C")]
		public LevelOrderAlgorithm GetAlgorithm()
		{
			LevelOrderConfig levelOrderConfig = _levelOrderConfig;
			return levelOrderConfig.m_algorithm;
		}
	}
}
