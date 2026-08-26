using System.IO;

namespace DMP4
{
	internal abstract class ElfBase : Il2Cpp
	{
		public bool IsDumped;

		public ulong DumpAddr;

		protected ElfBase(Stream stream)
			: base(stream)
		{
		}

		public void GetDumpAddress()
		{
			DumpAddr = 0uL;
			if (DumpAddr != 0L)
			{
				IsDumped = true;
			}
		}
	}
}
