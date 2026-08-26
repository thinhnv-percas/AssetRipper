using System.Text;

public class Crc64Iso : Crc64
{
	internal static ulong[] table;

	public const ulong Iso3309Polynomial = 15564440312192434176uL;

	public Crc64Iso()
		: base(15564440312192434176uL)
	{
	}

	public Crc64Iso(ulong seed)
		: base(15564440312192434176uL, seed)
	{
	}

	internal static ulong Compute(string s)
	{
		if (s == null || string.IsNullOrEmpty(s))
		{
			return 0uL;
		}
		return Compute(Encoding.UTF8.GetBytes(s));
	}

	public static ulong Compute(byte[] buffer)
	{
		return Compute(0uL, buffer);
	}

	public static ulong Compute(ulong seed, byte[] buffer)
	{
		if (table == null)
		{
			table = Crc64.CreateTable(15564440312192434176uL);
		}
		return Crc64.CalculateHash(seed, table, buffer, 0, buffer.Length);
	}
}
