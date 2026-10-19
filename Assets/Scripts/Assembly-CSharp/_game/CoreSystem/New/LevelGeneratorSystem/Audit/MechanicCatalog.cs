using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using _game.CoreSystem.LevelCreator;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.LevelGeneratorSystem.Driver;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.LevelData;
using _game.CoreSystem.SandSystem.Components;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Audit
{
	[Token(Token = "0x20003B9")]
	public sealed class MechanicCatalog
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20003BA")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000BB6")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000BB7")]
			public static Func<KeyValuePair<(int x, int y), int>, int> _003C_003E9__6_0;

			[Token(Token = "0x4000BB8")]
			public static Func<IGrouping<int, KeyValuePair<(int x, int y), int>>, int> _003C_003E9__6_1;

			[Token(Token = "0x4000BB9")]
			public static Func<KeyValuePair<(int x, int y), int>, GridCoord> _003C_003E9__6_2;

			[Token(Token = "0x6000F80")]
			[Address(RVA = "0x3C9F1C4", Offset = "0x3C9F1C4", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000F81")]
			[Address(RVA = "0x3C9F228", Offset = "0x3C9F228", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal int _003CFromSnapshot_003Eb__6_0(KeyValuePair<(int x, int y), int> kv)
			{
				int result = default(int);
				return result;
			}

			internal int _003CFromSnapshot_003Eb__6_1(IGrouping<int, KeyValuePair<(int x, int y), int>> g)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("MechanicCatalog._003C_003Ec::_003CFromSnapshot_003Eb__6_1");
				return default;
			}

			internal GridCoord _003CFromSnapshot_003Eb__6_2(KeyValuePair<(int x, int y), int> kv)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("MechanicCatalog._003C_003Ec::_003CFromSnapshot_003Eb__6_2");
				return default;
			}
		}

		[Token(Token = "0x4000BB2")]
		[FieldOffset(Offset = "0x10")]
		public List<GarageInfo> Garages;

		[Token(Token = "0x4000BB3")]
		[FieldOffset(Offset = "0x18")]
		public List<TunnelInfo> Tunnels;

		[Token(Token = "0x4000BB4")]
		[FieldOffset(Offset = "0x20")]
		public List<LinkedGroupInfo> LinkedGroups;

		[Token(Token = "0x4000BB5")]
		[FieldOffset(Offset = "0x28")]
		public int HiddenCubeCount;

		[Token(Token = "0x1700013D")]
		public bool AnyClaimable
		{
			[Token(Token = "0x6000F7C")]
			[Address(RVA = "0x3C9DE8C", Offset = "0x3C9DE8C", Length = "0xD0")]
			get
			{
				List<GarageInfo> garages = Garages;
				if (garages.Count > 0)
				{
					return true;
				}
				List<TunnelInfo> tunnels = Tunnels;
				if (tunnels.Count > 0)
				{
					return true;
				}
				List<LinkedGroupInfo> linkedGroups = LinkedGroups;
				if (linkedGroups.Count > 0)
				{
					return true;
				}
				bool flag = HiddenCubeCount < 0;
				bool flag2 = HiddenCubeCount == 0;
				int num = HiddenCubeCount ^ HiddenCubeCount;
				int num2 = HiddenCubeCount & num;
				bool flag3 = num2 < 0;
				bool flag4 = flag == flag3;
				bool flag5 = !flag2;
				return flag4 && flag5;
			}
		}

		[Token(Token = "0x6000F7D")]
		[Address(RVA = "0x3C9DF5C", Offset = "0x3C9DF5C", Length = "0x1070")]
		public unsafe static MechanicCatalog FromSnapshot(LevelCreatorData data)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MechanicCatalog::FromSnapshot");
			return default;
		}

		[Token(Token = "0x6000F7E")]
		[Address(RVA = "0x3C9F100", Offset = "0x3C9F100", Length = "0xC4")]
		private unsafe static GridCoord TargetOf(GridCoord t, TunnelDirection d)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MechanicCatalog::TargetOf");
			return default;
		}

		[Token(Token = "0x6000F7F")]
		[Address(RVA = "0x3C9EFCC", Offset = "0x3C9EFCC", Length = "0x134")]
		public MechanicCatalog()
		{
			List<GarageInfo> garages = new List<GarageInfo>();
			Garages = garages;
			Tunnels = new List<TunnelInfo>();
			LinkedGroups = new List<LinkedGroupInfo>();
		}
	}
}
