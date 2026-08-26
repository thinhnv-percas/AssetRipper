using System;

namespace ICSharpCode.Decompiler
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			if (!new DecompilerTools().Run((args.Length < 1) ? null : args[0].Replace("\"", ""), (args.Length < 2) ? null : args[1].Replace("\"", ""), (args.Length < 3) ? null : args[2].Replace("\"", "")))
			{
				Console.WriteLine("ERROR");
			}
		}
	}
}
