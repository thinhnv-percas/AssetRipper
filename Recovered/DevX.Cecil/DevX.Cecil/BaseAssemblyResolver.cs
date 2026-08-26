using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Text;

namespace DevX.Cecil
{
	public abstract class BaseAssemblyResolver : IAssemblyResolver
	{
		private ArrayList m_directories;

		private string[] m_monoGacPaths;

		private static readonly string[] _extentions = new string[2]
		{
			".dll",
			".exe"
		};

		private string[] MonoGacPaths
		{
			get
			{
				if (m_monoGacPaths == null)
				{
					m_monoGacPaths = GetDefaultMonoGacPaths();
				}
				return m_monoGacPaths;
			}
		}

		public BaseAssemblyResolver()
		{
			m_directories = new ArrayList();
			m_directories.Add(".");
			m_directories.Add("bin");
		}

		public void AddSearchDirectory(string directory)
		{
			m_directories.Add(directory);
		}

		public void RemoveSearchDirectory(string directory)
		{
			m_directories.Remove(directory);
		}

		public string[] GetSearchDirectories()
		{
			return (string[])m_directories.ToArray(typeof(string));
		}

		public virtual AssemblyDefinition Resolve(string fullName)
		{
			return Resolve(AssemblyNameReference.Parse(fullName));
		}

		public virtual AssemblyDefinition Resolve(AssemblyNameReference name)
		{
			string directoryName = Path.GetDirectoryName(typeof(object).Module.FullyQualifiedName);
			AssemblyDefinition assemblyDefinition = SearchDirectory(name, m_directories);
			if (assemblyDefinition != null)
			{
				return assemblyDefinition;
			}
			if (IsZero(name.Version))
			{
				assemblyDefinition = SearchDirectory(name, new string[1]
				{
					directoryName
				});
				if (assemblyDefinition != null)
				{
					return assemblyDefinition;
				}
			}
			if (name.Name == "mscorlib")
			{
				assemblyDefinition = GetCorlib(name);
				if (assemblyDefinition != null)
				{
					return assemblyDefinition;
				}
			}
			assemblyDefinition = GetAssemblyInGac(name);
			if (assemblyDefinition != null)
			{
				return assemblyDefinition;
			}
			assemblyDefinition = SearchDirectory(name, new string[1]
			{
				directoryName
			});
			if (assemblyDefinition != null)
			{
				return assemblyDefinition;
			}
			throw new FileNotFoundException("Could not resolve: " + name);
		}

		private static AssemblyDefinition SearchDirectory(AssemblyNameReference name, IEnumerable directories)
		{
			foreach (string directory in directories)
			{
				string[] extentions = _extentions;
				foreach (string str in extentions)
				{
					string text = Path.Combine(directory, name.Name + str);
					if (File.Exists(text))
					{
						return AssemblyFactory.GetAssembly(text);
					}
				}
			}
			return null;
		}

		private static bool IsZero(Version version)
		{
			return version.Major == 0 && version.Minor == 0 && version.Build == 0 && version.Revision == 0;
		}

		private static AssemblyDefinition GetCorlib(AssemblyNameReference reference)
		{
			AssemblyName name = typeof(object).Assembly.GetName();
			if (name.Version == reference.Version || IsZero(reference.Version))
			{
				return AssemblyFactory.GetAssembly(typeof(object).Module.FullyQualifiedName);
			}
			string fullName = Directory.GetParent(Directory.GetParent(typeof(object).Module.FullyQualifiedName).FullName).FullName;
			string text = null;
			if (OnMono())
			{
				if (reference.Version.Major == 1)
				{
					text = "1.0";
				}
				else if (reference.Version.Major == 2)
				{
					text = ((reference.Version.Minor != 1) ? "2.0" : "2.1");
				}
				else if (reference.Version.Major == 4)
				{
					text = "4.0";
				}
			}
			else
			{
				switch (reference.Version.ToString())
				{
				case "1.0.3300.0":
					text = "v1.0.3705";
					break;
				case "1.0.5000.0":
					text = "v1.1.4322";
					break;
				case "2.0.0.0":
					text = "v2.0.50727";
					break;
				case "4.0.0.0":
					text = "v4.0.21006";
					break;
				}
			}
			if (text == null)
			{
				throw new NotSupportedException("Version not supported: " + reference.Version);
			}
			fullName = Path.Combine(fullName, text);
			if (File.Exists(Path.Combine(fullName, "mscorlib.dll")))
			{
				return AssemblyFactory.GetAssembly(Path.Combine(fullName, "mscorlib.dll"));
			}
			return null;
		}

		public static bool OnMono()
		{
			return typeof(object).Assembly.GetType("System.MonoType", throwOnError: false) != null;
		}

		private static string[] GetDefaultMonoGacPaths()
		{
			ArrayList arrayList = new ArrayList();
			string currentGacPath = GetCurrentGacPath();
			if (currentGacPath != null)
			{
				arrayList.Add(currentGacPath);
			}
			string environmentVariable = Environment.GetEnvironmentVariable("MONO_GAC_PREFIX");
			if (environmentVariable != null && environmentVariable.Length > 0)
			{
				string[] array = environmentVariable.Split(Path.PathSeparator);
				string[] array2 = array;
				foreach (string text in array2)
				{
					if (text != null && text.Length > 0)
					{
						string text2 = Path.Combine(Path.Combine(Path.Combine(text, "lib"), "mono"), "gac");
						if (Directory.Exists(text2) && !arrayList.Contains(text2))
						{
							arrayList.Add(text2);
						}
					}
				}
			}
			return (string[])arrayList.ToArray(typeof(string));
		}

		private AssemblyDefinition GetAssemblyInGac(AssemblyNameReference reference)
		{
			if (reference.PublicKeyToken == null || reference.PublicKeyToken.Length == 0)
			{
				return null;
			}
			if (OnMono())
			{
				string[] monoGacPaths = MonoGacPaths;
				foreach (string gac in monoGacPaths)
				{
					string assemblyFile = GetAssemblyFile(reference, gac);
					if (File.Exists(assemblyFile))
					{
						return AssemblyFactory.GetAssembly(assemblyFile);
					}
				}
			}
			else
			{
				string currentGacPath = GetCurrentGacPath();
				if (currentGacPath == null)
				{
					return null;
				}
				string[] array = new string[3]
				{
					"GAC_MSIL",
					"GAC_32",
					"GAC"
				};
				for (int j = 0; j < array.Length; j++)
				{
					string text = Path.Combine(Directory.GetParent(currentGacPath).FullName, array[j]);
					string assemblyFile2 = GetAssemblyFile(reference, text);
					if (Directory.Exists(text) && File.Exists(assemblyFile2))
					{
						return AssemblyFactory.GetAssembly(assemblyFile2);
					}
				}
			}
			return null;
		}

		private static string GetAssemblyFile(AssemblyNameReference reference, string gac)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(reference.Version);
			stringBuilder.Append("__");
			for (int i = 0; i < reference.PublicKeyToken.Length; i++)
			{
				stringBuilder.Append(reference.PublicKeyToken[i].ToString("x2"));
			}
			return Path.Combine(Path.Combine(Path.Combine(gac, reference.Name), stringBuilder.ToString()), reference.Name + ".dll");
		}

		private static string GetCurrentGacPath()
		{
			string fullyQualifiedName = typeof(Uri).Module.FullyQualifiedName;
			if (!File.Exists(fullyQualifiedName))
			{
				return null;
			}
			return Directory.GetParent(Directory.GetParent(Path.GetDirectoryName(fullyQualifiedName)).FullName).FullName;
		}
	}
}
