using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Reflex.Attributes;
using Sirenix.Utilities;
using Unco.Utils;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Interface;

namespace _game.CoreGameKit.CoreSerivces.FeatureUnlock
{
	[Token(Token = "0x2000615")]
	public class FeatureUnlockService : IFeatureUnlockService
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000616")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400150A")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400150B")]
			public static Func<Pair<string, int>, int> _003C_003E9__5_0;

			[Token(Token = "0x6001A1C")]
			[Address(RVA = "0x3D50C5C", Offset = "0x3D50C5C", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001A1D")]
			[Address(RVA = "0x3D50CC0", Offset = "0x3D50CC0", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal int _003CInject_003Eb__5_0(Pair<string, int> x)
			{
				int result = default(int);
				return result;
			}
		}

		[Token(Token = "0x4001505")]
		[FieldOffset(Offset = "0x10")]
		private FeatureUnlockDatabase _database;

		[Token(Token = "0x4001506")]
		[FieldOffset(Offset = "0x18")]
		private ILevelProgressService _levelProgressService;

		[Token(Token = "0x4001507")]
		[FieldOffset(Offset = "0x20")]
		private ILevelList _levelList;

		[Token(Token = "0x4001508")]
		[FieldOffset(Offset = "0x28")]
		private List<Pair<string, int>> _featureUnlockLevelPairsCache;

		[Token(Token = "0x4001509")]
		[FieldOffset(Offset = "0x30")]
		private List<Pair<string, int>> _visibleFeatureCache;

		[Inject(false)]
		[Token(Token = "0x6001A17")]
		[Address(RVA = "0x3D50198", Offset = "0x3D50198", Length = "0x518")]
		private void Inject(ILevelList levelList, FeatureUnlockDatabase database, ILevelProgressService progressService)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FeatureUnlockService::Inject");
		}

		[Token(Token = "0x6001A18")]
		[Address(RVA = "0x3D506B0", Offset = "0x3D506B0", Length = "0x254")]
		public FeatureUnlockData GetNextUnlockFeature(out float progress, out float startProgress)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FeatureUnlockService::GetNextUnlockFeature");
			progress = default;
			startProgress = default;
			return default;
		}

		[Token(Token = "0x6001A19")]
		[Address(RVA = "0x3D5090C", Offset = "0x3D5090C", Length = "0x314")]
		private int GetEffectiveUniquePosition()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FeatureUnlockService::GetEffectiveUniquePosition");
			return default;
		}

		[Token(Token = "0x6001A1A")]
		[Address(RVA = "0x3D4E4E0", Offset = "0x3D4E4E0", Length = "0x8")]
		public FeatureUnlockService()
		{
		}
	}
}
