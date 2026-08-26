using System.Text;

public class Crc64Iso : Crc64
{
	internal static ulong[] _0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A;

	public const ulong Iso3309Polynomial = 15564440312192434176uL;

	public Crc64Iso()
		: base(15564440312192434176uL)
	{
	}

	public Crc64Iso(ulong seed)
		: base(15564440312192434176uL, seed)
	{
	}

	internal static ulong _0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_000A(string P_0)
	{
		if (P_0 == null || string.IsNullOrEmpty(P_0))
		{
			return 0uL;
		}
		return Compute(Encoding.UTF8.GetBytes(P_0));
	}

	public static ulong Compute(byte[] buffer)
	{
		return Compute(0uL, buffer);
	}

	public static ulong Compute(ulong seed, byte[] buffer)
	{
		if (_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A == null)
		{
			_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A = Crc64.CreateTable(15564440312192434176uL);
		}
		return Crc64.CalculateHash(seed, _0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A, buffer, 0, buffer.Length);
	}
}
