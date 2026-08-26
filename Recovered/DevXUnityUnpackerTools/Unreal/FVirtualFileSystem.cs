namespace Unreal
{
	internal abstract class FVirtualFileSystem
	{
		public abstract bool AttachReader(_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A reader);

		public abstract _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A CreateReader(string name);

		public abstract int NumFiles();

		public abstract string FileName(int i);

		public abstract int GetFileSize(string name);
	}
}
