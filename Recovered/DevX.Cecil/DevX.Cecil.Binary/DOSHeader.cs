namespace DevX.Cecil.Binary
{
	public sealed class DOSHeader : IBinaryVisitable, IHeader
	{
		public byte[] Start;

		public byte[] End;

		public uint Lfanew;

		internal DOSHeader()
		{
		}

		public void SetDefaultValues()
		{
			byte[] array = new byte[60];
			array[0] = 77;
			array[1] = 90;
			array[2] = 144;
			array[4] = 3;
			array[8] = 4;
			array[12] = byte.MaxValue;
			array[13] = byte.MaxValue;
			array[16] = 184;
			array[24] = 64;
			Start = array;
			Lfanew = 128u;
			End = new byte[64]
			{
				14,
				31,
				186,
				14,
				0,
				180,
				9,
				205,
				33,
				184,
				1,
				76,
				205,
				33,
				84,
				104,
				105,
				115,
				32,
				112,
				114,
				111,
				103,
				114,
				97,
				109,
				32,
				99,
				97,
				110,
				110,
				111,
				116,
				32,
				98,
				101,
				32,
				114,
				117,
				110,
				32,
				105,
				110,
				32,
				68,
				79,
				83,
				32,
				109,
				111,
				100,
				101,
				46,
				13,
				13,
				10,
				36,
				0,
				0,
				0,
				0,
				0,
				0,
				0
			};
		}

		public void Accept(IBinaryVisitor visitor)
		{
			visitor.VisitDOSHeader(this);
		}
	}
}
