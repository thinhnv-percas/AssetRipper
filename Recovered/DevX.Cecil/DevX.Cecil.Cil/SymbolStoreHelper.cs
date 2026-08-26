using System;
using System.Reflection;

namespace DevX.Cecil.Cil
{
	internal sealed class SymbolStoreHelper
	{
		private static ISymbolStoreFactory s_factory;

		private SymbolStoreHelper()
		{
		}

		public static ISymbolReader GetReader(ModuleDefinition module)
		{
			InitFactory();
			return s_factory.CreateReader(module, module.Image.FileInformation.FullName);
		}

		public static ISymbolWriter GetWriter(ModuleDefinition module, string assemblyFileName)
		{
			InitFactory();
			return s_factory.CreateWriter(module, assemblyFileName);
		}

		private static void InitFactory()
		{
			if (s_factory == null)
			{
				string assembly;
				string symbolSupportType = GetSymbolSupportType(out assembly);
				Type type = Type.GetType(symbolSupportType + ", " + assembly, throwOnError: false);
				if (type == null)
				{
					try
					{
						Assembly assembly2 = Assembly.LoadWithPartialName(assembly);
						type = assembly2.GetType(symbolSupportType);
					}
					catch
					{
					}
				}
				if (type == null)
				{
					throw new NotSupportedException();
				}
				s_factory = (ISymbolStoreFactory)Activator.CreateInstance(type);
			}
		}

		private static string GetSymbolSupportType(out string assembly)
		{
			string symbolKind = GetSymbolKind();
			assembly = "DevX.Cecil." + symbolKind;
			return string.Format(assembly + "." + symbolKind + "Factory");
		}

		private static string GetSymbolKind()
		{
			return (!OnMono()) ? "Pdb" : "Mdb";
		}

		private static bool OnMono()
		{
			return Type.GetType("Mono.Runtime") != null;
		}
	}
}
