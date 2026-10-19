using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.LevelGeneratorSystem.Driver;
using _game.CoreSystem.New.LevelGeneratorSystem.Pathing;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Audit
{
	[Token(Token = "0x20003BD")]
	public static class MechanicReplayAudit
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20003BE")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000BC4")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000BC5")]
			public static Func<MechanicAuditRow, bool> _003C_003E9__0_0;

			[Token(Token = "0x6000F8C")]
			[Address(RVA = "0x3CA190C", Offset = "0x3CA190C", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000F8D")]
			[Address(RVA = "0x3CA1970", Offset = "0x3CA1970", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal bool _003CRun_003Eb__0_0(MechanicAuditRow r)
			{
				return r.GrossMismatch;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x20003BF")]
		private sealed class _003C_003Ec__DisplayClass0_0
		{
			[Token(Token = "0x4000BC6")]
			[FieldOffset(Offset = "0x10")]
			public IReadOnlyList<BoardSnapshot> boards;

			[Token(Token = "0x4000BC7")]
			[FieldOffset(Offset = "0x18")]
			public int[] cumulativeBroken;

			[Token(Token = "0x4000BC8")]
			[FieldOffset(Offset = "0x20")]
			public List<HashSet<GridCoord>> broken;

			[Token(Token = "0x6000F8F")]
			[Address(RVA = "0x3CA0CAC", Offset = "0x3CA0CAC", Length = "0x8")]
			public _003C_003Ec__DisplayClass0_0()
			{
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x20003C0")]
		private sealed class _003C_003Ec__DisplayClass0_1
		{
			[Token(Token = "0x4000BC9")]
			[FieldOffset(Offset = "0x10")]
			public GarageInfo g;

			[Token(Token = "0x4000BCA")]
			[FieldOffset(Offset = "0x18")]
			public _003C_003Ec__DisplayClass0_0 CS_0024_003C_003E8__locals1;

			[Token(Token = "0x6000F90")]
			[Address(RVA = "0x3CA1290", Offset = "0x3CA1290", Length = "0x8")]
			public _003C_003Ec__DisplayClass0_1()
			{
			}

			internal bool _003CRun_003Eb__1(int i)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("MechanicReplayAudit._003C_003Ec__DisplayClass0_1::_003CRun_003Eb__1");
				return default;
			}

			internal bool _003CRun_003Eb__2(int i)
			{
				_003C_003Ec__DisplayClass0_0 _003C_003Ec__DisplayClass0_5 = CS_0024_003C_003E8__locals1;
				int[] array = _003C_003Ec__DisplayClass0_5.cumulativeBroken;
				GarageInfo garageInfo = g;
				int num = array[i] - garageInfo.Counter;
				bool flag = num < 0;
				int num2 = array[i] ^ garageInfo.Counter;
				int num3 = array[i] ^ num;
				int num4 = num2 & num3;
				bool flag2 = num4 < 0;
				return flag == flag2;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x20003C2")]
		private sealed class _003C_003Ec__DisplayClass0_3
		{
			[Token(Token = "0x4000BCD")]
			[FieldOffset(Offset = "0x10")]
			public TunnelInfo t;

			[Token(Token = "0x4000BCE")]
			[FieldOffset(Offset = "0x18")]
			public _003C_003Ec__DisplayClass0_0 CS_0024_003C_003E8__locals3;

			[Token(Token = "0x6000F95")]
			[Address(RVA = "0x3CA18FC", Offset = "0x3CA18FC", Length = "0x8")]
			public _003C_003Ec__DisplayClass0_3()
			{
			}

			internal bool _003CRun_003Eb__4(int i)
			{
				_003C_003Ec__DisplayClass0_0 _003C_003Ec__DisplayClass0_5 = CS_0024_003C_003E8__locals3;
				int index = default(int);
				HashSet<GridCoord> hashSet = _003C_003Ec__DisplayClass0_5.broken[index];
				TunnelInfo tunnelInfo = t;
				return hashSet.Contains(tunnelInfo.Target);
			}

			internal bool _003CRun_003Eb__5(int i)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("MechanicReplayAudit._003C_003Ec__DisplayClass0_3::_003CRun_003Eb__5");
				return default;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x20003C3")]
		private sealed class _003C_003Ec__DisplayClass0_4
		{
			[Token(Token = "0x4000BCF")]
			[FieldOffset(Offset = "0x10")]
			public LinkedGroupInfo lg;

			[Token(Token = "0x4000BD0")]
			[FieldOffset(Offset = "0x18")]
			public _003C_003Ec__DisplayClass0_0 CS_0024_003C_003E8__locals4;

			[Token(Token = "0x6000F98")]
			[Address(RVA = "0x3CA1904", Offset = "0x3CA1904", Length = "0x8")]
			public _003C_003Ec__DisplayClass0_4()
			{
			}

			internal bool _003CRun_003Eb__6(int i)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("MechanicReplayAudit._003C_003Ec__DisplayClass0_4::_003CRun_003Eb__6");
				return default;
			}
		}

		[Token(Token = "0x6000F87")]
		[Address(RVA = "0x3C9F520", Offset = "0x3C9F520", Length = "0x178C")]
		public unsafe static MechanicAuditResult Run(MechanicCatalog catalog, IReadOnlyList<MechanicClaim> claims, IReadOnlyList<BoardSnapshot> boards, VisualIndexMap map)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MechanicReplayAudit::Run");
			return default;
		}

		[Token(Token = "0x6000F88")]
		[Address(RVA = "0x3CA0CB4", Offset = "0x3CA0CB4", Length = "0x5DC")]
		private static List<HashSet<GridCoord>> BuildBrokenSets(IReadOnlyList<BoardSnapshot> boards, int tapCount)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MechanicReplayAudit::BuildBrokenSets");
			return default;
		}

		[Token(Token = "0x6000F89")]
		[Address(RVA = "0x3CA1724", Offset = "0x3CA1724", Length = "0x68")]
		private static int FirstIndex(int tapCount, Func<int, bool> pred)
		{
			//IL_007c: Expected O, but got I4
			if (tapCount < 1)
			{
				goto IL_0058;
			}
			int num = 0;
			while (true)
			{
				object obj = pred(num);
				if ((int)((nint)obj & 1) != 0)
				{
					break;
				}
				num++;
				if (tapCount != num)
				{
					continue;
				}
				goto IL_0058;
			}
			goto IL_0066;
			IL_0066:
			return num;
			IL_0058:
			num = -1;
			goto IL_0066;
		}

		[Token(Token = "0x6000F8A")]
		[Address(RVA = "0x3CA1298", Offset = "0x3CA1298", Length = "0x48C")]
		private static MechanicClaim MatchClaim(IReadOnlyList<MechanicClaim> claims, HashSet<MechanicClaim> consumed, string kind, VisualIndexMap map, List<GridCoord> cells, GridCoord? extra)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MechanicReplayAudit::MatchClaim");
			return default;
		}

		[Token(Token = "0x6000F8B")]
		[Address(RVA = "0x3CA178C", Offset = "0x3CA178C", Length = "0x170")]
		private static MechanicAuditRow BuildRow(string kind, GridCoord anchor, VisualIndexMap map, MechanicClaim claim, int arrival, string detail)
		{
			MechanicAuditRow mechanicAuditRow = new MechanicAuditRow();
			mechanicAuditRow.Kind = kind;
			bool flag = map._byCoord.TryGetValue(anchor, out var value);
			bool flag2 = !flag;
			mechanicAuditRow.ActualDetail = detail;
			int cellIndex = (flag2 ? (-1) : value);
			mechanicAuditRow.CellIndex = cellIndex;
			mechanicAuditRow.ActualArrivalTap = arrival;
			if (claim != null)
			{
				mechanicAuditRow.RemovalEffect = claim.RemovalEffect;
				mechanicAuditRow.EstimateTap = claim.ArrivalTapEstimate;
				int grossMismatch = arrival >> 31;
				mechanicAuditRow.GrossMismatch = (byte)grossMismatch != 0;
			}
			else
			{
				mechanicAuditRow.Note = "no claim";
			}
			return mechanicAuditRow;
		}
	}
}
