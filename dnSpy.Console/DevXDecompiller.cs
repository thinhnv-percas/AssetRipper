using System.Collections.Generic;
using dnSpy_Console;

public class DevXDecompiller
{
	public static void Decompile(string file_in, string out_dir, string asm_paths, string options)
	{
		List<string> list = new List<string>();
		list.Add(file_in);
		list.Add("-o");
		list.Add(out_dir);
		list.Add("--no-sln");
		list.Add("--no-tokens");
		if (!string.IsNullOrEmpty(asm_paths))
		{
			list.Add("--asm-path");
			list.Add(asm_paths);
		}
		new DnSpyDecompiler().Run(new string[3] { file_in, "-o", out_dir });
	}

	public static void Run(string[] args)
	{
		new DnSpyDecompiler().Run(args);
	}
}
