using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Audit
{
	[Token(Token = "0x20003BB")]
	public sealed class MechanicAuditRow
	{
		[Token(Token = "0x4000BBA")]
		[FieldOffset(Offset = "0x10")]
		public string Kind;

		[Token(Token = "0x4000BBB")]
		[FieldOffset(Offset = "0x18")]
		public int CellIndex;

		[Token(Token = "0x4000BBC")]
		[FieldOffset(Offset = "0x20")]
		public string RemovalEffect;

		[Token(Token = "0x4000BBD")]
		[FieldOffset(Offset = "0x28")]
		public int EstimateTap;

		[Token(Token = "0x4000BBE")]
		[FieldOffset(Offset = "0x2C")]
		public int ActualArrivalTap;

		[Token(Token = "0x4000BBF")]
		[FieldOffset(Offset = "0x30")]
		public string ActualDetail;

		[Token(Token = "0x4000BC0")]
		[FieldOffset(Offset = "0x38")]
		public bool GrossMismatch;

		[Token(Token = "0x4000BC1")]
		[FieldOffset(Offset = "0x40")]
		public string Note;

		[Token(Token = "0x6000F85")]
		[Address(RVA = "0x3C9F388", Offset = "0x3C9F388", Length = "0xA4")]
		public MechanicAuditRow()
		{
			Kind = "";
			CellIndex = -1;
			RemovalEffect = "";
			EstimateTap = -1;
			ActualArrivalTap = -1;
			ActualDetail = "";
			Note = "";
		}
	}
}
