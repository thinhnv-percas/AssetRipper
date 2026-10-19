using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unity.Mathematics;
using _game.CoreSystem.FrameSystem.MeshGen;
using _game.CoreSystem.LevelCreator;

namespace _game.CoreSystem.FrameSystem
{
	[Token(Token = "0x20004DD")]
	public class FrameController
	{
		[Token(Token = "0x400103F")]
		[FieldOffset(Offset = "0x10")]
		internal FrameData m_frameData;

		[Token(Token = "0x4001040")]
		[FieldOffset(Offset = "0x30")]
		private LevelCreatorData _pendingCreationData;

		[Token(Token = "0x4001041")]
		[FieldOffset(Offset = "0x38")]
		private FramePresetConfig _pendingPresetConfig;

		[Token(Token = "0x4001042")]
		[FieldOffset(Offset = "0x40")]
		internal WallSegment[] _cachedLoopsWallsRef;

		[Token(Token = "0x4001043")]
		[FieldOffset(Offset = "0x48")]
		internal List<List<float2>> _cachedLoops;

		[Token(Token = "0x4001044")]
		[FieldOffset(Offset = "0x50")]
		internal HashSet<long> _cachedOuterBoundaryKeys;

		[Token(Token = "0x170001C5")]
		public FrameData FrameData
		{
			[Token(Token = "0x6001478")]
			[Address(RVA = "0x3CF5988", Offset = "0x3CF5988", Length = "0xC")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("FrameController::get_FrameData");
				return default;
			}
			[Token(Token = "0x6001479")]
			[Address(RVA = "0x3CF5994", Offset = "0x3CF5994", Length = "0x58")]
			set
			{
				global::AssetRipperInjected.RecoveryStub.Missing("FrameController::set_FrameData");
			}
		}

		[Token(Token = "0x170001C6")]
		public List<WallSegment> WallsList
		{
			[Token(Token = "0x600147D")]
			[Address(RVA = "0x3CF5AF8", Offset = "0x3CF5AF8", Length = "0x130")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("FrameController::get_WallsList");
				return default;
			}
		}

		[Token(Token = "0x600147A")]
		[Address(RVA = "0x3CF5A30", Offset = "0x3CF5A30", Length = "0x78")]
		public bool TryGetCachedLoops(WallSegment[] walls, out List<List<float2>> loops, out HashSet<long> outerBoundaryKeys)
		{
			loops = null;
			outerBoundaryKeys = null;
			bool result;
			HashSet<long> hashSet;
			if (_cachedLoops == null || _cachedLoopsWallsRef != walls)
			{
				loops = null;
				result = false;
				hashSet = null;
			}
			else
			{
				loops = _cachedLoops;
				hashSet = _cachedOuterBoundaryKeys;
				result = true;
			}
			outerBoundaryKeys = hashSet;
			return result;
		}

		[Token(Token = "0x600147B")]
		[Address(RVA = "0x3CF5AA8", Offset = "0x3CF5AA8", Length = "0x50")]
		public void CacheLoops(WallSegment[] walls, List<List<float2>> loops, HashSet<long> outerBoundaryKeys)
		{
			_cachedLoopsWallsRef = walls;
			_cachedLoops = loops;
			_cachedOuterBoundaryKeys = outerBoundaryKeys;
		}

		[Token(Token = "0x600147C")]
		[Address(RVA = "0x3CF59EC", Offset = "0x3CF59EC", Length = "0x44")]
		public void InvalidateLoopCache()
		{
			_cachedLoopsWallsRef = null;
			_cachedLoops = null;
			_cachedOuterBoundaryKeys = null;
		}

		[Inject(false)]
		[Token(Token = "0x600147E")]
		[Address(RVA = "0x3CF5C28", Offset = "0x3CF5C28", Length = "0x3C")]
		private void Construct(LevelCreatorData creationData, FramePresetConfig presetConfig)
		{
			_pendingCreationData = creationData;
			_pendingPresetConfig = presetConfig;
			BuildFrameData();
		}

		[Token(Token = "0x600147F")]
		[Address(RVA = "0x3CF5C64", Offset = "0x3CF5C64", Length = "0xD8")]
		private void BuildFrameData()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FrameController::BuildFrameData");
		}

		[Token(Token = "0x6001480")]
		[Address(RVA = "0x3CF6240", Offset = "0x3CF6240", Length = "0xA8")]
		public void SetWalls(List<WallSegment> walls)
		{
			WallSegment[] walls2 = walls.ToArray();
			m_frameData.walls = walls2;
			_cachedLoopsWallsRef = null;
			_cachedLoops = null;
			_cachedOuterBoundaryKeys = null;
			EnsureRegionTypes();
		}

		[Token(Token = "0x6001481")]
		[Address(RVA = "0x3CF62E8", Offset = "0x3CF62E8", Length = "0x588")]
		public void EnsureRegionTypes()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FrameController::EnsureRegionTypes");
		}

		[Token(Token = "0x6001482")]
		[Address(RVA = "0x3CF6870", Offset = "0x3CF6870", Length = "0x8")]
		public FrameController()
		{
		}
	}
}
