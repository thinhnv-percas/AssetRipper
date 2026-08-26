using ICSharpCode.Decompiler.Ast;
using Mono.Cecil;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace ICSharpCode.Decompiler
{
	[ComVisible(true)]
	[Guid("058FD7C8-4C7A-49A5-BCAD-2A5A82B94395")]
	public class DecompilerTools : IDecompilerTools
	{
		public bool Run(string compiledFile, string expectedOutputFile, string class_name)
		{
			try
			{
				if (!File.Exists(compiledFile))
				{
					Console.Error.WriteLine("ERROR: File not exist!");
					return false;
				}
				AssemblyDefinition assemblyDefinition = AssemblyDefinition.ReadAssembly(File.OpenRead(compiledFile));
				AstBuilder astBuilder = new AstBuilder(new DecompilerContext(assemblyDefinition.MainModule));
				if (string.IsNullOrEmpty(class_name))
				{
					astBuilder.AddAssembly(assemblyDefinition);
				}
				else
				{
					bool flag = false;
					foreach (TypeDefinition type in assemblyDefinition.MainModule.Types)
					{
						if ((string.IsNullOrEmpty(type.Namespace) ? type.Name : (type.Namespace + "." + type.Name)) == class_name)
						{
							astBuilder.AddType(type);
							flag = true;
						}
					}
					if (!flag)
					{
						Console.Error.WriteLine("ERROR: Class not found!");
						return false;
					}
				}
				new RemoveCompilerAttribute().Run(astBuilder.SyntaxTree);
				StringWriter stringWriter = new StringWriter();
				astBuilder.GenerateCode(new PlainTextOutput(stringWriter));
				if (!string.IsNullOrEmpty(expectedOutputFile))
				{
					File.WriteAllText(expectedOutputFile, stringWriter.ToString());
				}
				else
				{
					Console.WriteLine(expectedOutputFile, stringWriter.ToString());
				}
				return true;
			}
			catch (Exception arg)
			{
				Console.Error.WriteLine(("ERROR: " + arg) ?? "");
				return false;
			}
		}
	}
}
