using System.Collections.Generic;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.BoosterSystem.VacuumBooster.Runtime
{
	[Token(Token = "0x2000455")]
	public class VacuumSession
	{
		[Token(Token = "0x2000456")]
		public struct Reservation
		{
			[Token(Token = "0x4000E07")]
			[FieldOffset(Offset = "0x0")]
			public int moldEntityIndex;

			[Token(Token = "0x4000E08")]
			[FieldOffset(Offset = "0x4")]
			public int moldEntityGeneration;

			[Token(Token = "0x4000E09")]
			[FieldOffset(Offset = "0x8")]
			public GameColor color;

			[Token(Token = "0x4000E0A")]
			[FieldOffset(Offset = "0xC")]
			public int reservedParticles;
		}

		[Token(Token = "0x4000DFC")]
		[FieldOffset(Offset = "0x10")]
		public int TotalReservedParticles;

		[Token(Token = "0x4000DFD")]
		[FieldOffset(Offset = "0x18")]
		public int[] ReservedByColor;

		[Token(Token = "0x4000DFE")]
		[FieldOffset(Offset = "0x20")]
		public List<Reservation> Reservations;

		[Token(Token = "0x4000DFF")]
		[FieldOffset(Offset = "0x28")]
		public int MouthArrivedCount;

		[Token(Token = "0x4000E00")]
		[FieldOffset(Offset = "0x2C")]
		public int BulbArrivedCount;

		[Token(Token = "0x4000E01")]
		[FieldOffset(Offset = "0x30")]
		public int CurrentReservationIndex;

		[Token(Token = "0x4000E02")]
		[FieldOffset(Offset = "0x34")]
		public int CurrentMoldExitedCount;

		[Token(Token = "0x4000E03")]
		[FieldOffset(Offset = "0x38")]
		public int CurrentMoldTotalParticles;

		[Token(Token = "0x4000E04")]
		[FieldOffset(Offset = "0x3C")]
		public bool IsDripping;

		[Token(Token = "0x4000E05")]
		[FieldOffset(Offset = "0x40")]
		public int DripSpawnedCount;

		[Token(Token = "0x4000E06")]
		[FieldOffset(Offset = "0x44")]
		public float DripTimer;

		[Token(Token = "0x6001243")]
		[Address(RVA = "0x3CCD844", Offset = "0x3CCD844", Length = "0xC4")]
		public VacuumSession()
		{
			int[] reservedByColor = new int[13];
			ReservedByColor = reservedByColor;
			Reservations = new List<Reservation>();
		}

		[Token(Token = "0x6001244")]
		[Address(RVA = "0x3CCA910", Offset = "0x3CCA910", Length = "0x90")]
		public void Reset()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VacuumSession::Reset");
		}
	}
}
