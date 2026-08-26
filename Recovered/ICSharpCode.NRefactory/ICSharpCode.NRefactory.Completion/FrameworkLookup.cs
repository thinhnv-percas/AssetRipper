using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.NRefactory.TypeSystem.Implementation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ICSharpCode.NRefactory.Completion
{
	public sealed class FrameworkLookup
	{
		public struct AssemblyLookup
		{
			private readonly string nspace;

			private readonly string fullName;

			private readonly string package;

			public string Namespace => nspace;

			public string FullName => fullName;

			public string Package => package;

			internal AssemblyLookup(string package, string fullName, string nspace)
			{
				if (nspace == null)
				{
					throw new ArgumentNullException("nspace");
				}
				if (fullName == null)
				{
					throw new ArgumentNullException("fullName");
				}
				this.package = package;
				this.fullName = fullName;
				this.nspace = nspace;
			}

			public override string ToString()
			{
				return $"[AssemblyLookup: Namespace={Namespace}, FullName={FullName}, Package={Package}]";
			}

			public override bool Equals(object obj)
			{
				if (obj == null)
				{
					return false;
				}
				if (obj.GetType() != typeof(AssemblyLookup))
				{
					return false;
				}
				AssemblyLookup assemblyLookup = (AssemblyLookup)obj;
				if (Namespace == assemblyLookup.Namespace && FullName == assemblyLookup.FullName)
				{
					return Package == assemblyLookup.Package;
				}
				return false;
			}

			public override int GetHashCode()
			{
				return ((Namespace != null) ? Namespace.GetHashCode() : 0) ^ ((FullName != null) ? FullName.GetHashCode() : 0) ^ ((Package != null) ? Package.GetHashCode() : 0);
			}
		}

		public class FrameworkBuilder : IDisposable
		{
			private struct FrameworkLookupId
			{
				public string PackageName;

				public string AssemblyName;

				public string NameSpace;
			}

			private readonly string fileName;

			private Dictionary<int, List<ushort>> typeLookup = new Dictionary<int, List<ushort>>();

			private Dictionary<int, List<ushort>> extensionMethodLookup = new Dictionary<int, List<ushort>>();

			private List<AssemblyLookup> assemblyLookups = new List<AssemblyLookup>();

			private Dictionary<int, string> methodCheck = new Dictionary<int, string>();

			private Dictionary<int, string> typeCheck = new Dictionary<int, string>();

			private Dictionary<FrameworkLookupId, ushort> frameworkLookupTable = new Dictionary<FrameworkLookupId, ushort>();

			internal FrameworkBuilder(string fileName)
			{
				this.fileName = fileName;
			}

			private static int[] WriteTable(MemoryStream stream, Dictionary<int, List<ushort>> table, out List<KeyValuePair<int, List<ushort>>> list)
			{
				list = new List<KeyValuePair<int, List<ushort>>>(table);
				list.Sort((KeyValuePair<int, List<ushort>> x, KeyValuePair<int, List<ushort>> y) => x.Key.CompareTo(y.Key));
				int[] array = new int[list.Count];
				using (BinaryWriter binaryWriter = new BinaryWriter(stream))
				{
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = (int)stream.Length;
						binaryWriter.Write(list[i].Value.Count);
						foreach (ushort item in list[i].Value)
						{
							binaryWriter.Write(item);
						}
					}
					return array;
				}
			}

			void IDisposable.Dispose()
			{
				MemoryStream memoryStream = new MemoryStream();
				List<KeyValuePair<int, List<ushort>>> list;
				int[] array = WriteTable(memoryStream, typeLookup, out list);
				MemoryStream memoryStream2 = new MemoryStream();
				List<KeyValuePair<int, List<ushort>>> list2;
				int[] array2 = WriteTable(memoryStream2, extensionMethodLookup, out list2);
				MemoryStream memoryStream3 = new MemoryStream();
				int[] array3 = new int[assemblyLookups.Count];
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream3, Encoding.UTF8))
				{
					for (int i = 0; i < assemblyLookups.Count; i++)
					{
						AssemblyLookup assemblyLookup = assemblyLookups[i];
						array3[i] = (int)memoryStream3.Length;
						binaryWriter.Write(assemblyLookup.Package);
						binaryWriter.Write(assemblyLookup.FullName);
						binaryWriter.Write(assemblyLookup.Namespace);
					}
				}
				using (BinaryWriter binaryWriter2 = new BinaryWriter(File.OpenWrite(fileName), Encoding.UTF8))
				{
					binaryWriter2.Write((byte)CurrentVersion.Major);
					binaryWriter2.Write((byte)CurrentVersion.Minor);
					binaryWriter2.Write((byte)CurrentVersion.Build);
					binaryWriter2.Write(list.Count);
					binaryWriter2.Write(list2.Count);
					binaryWriter2.Write(assemblyLookups.Count);
					byte[] array4 = memoryStream.ToArray();
					byte[] array5 = memoryStream2.ToArray();
					int num = 15 + assemblyLookups.Count * 4 + list.Count * 8 + list2.Count * 8;
					for (int j = 0; j < assemblyLookups.Count; j++)
					{
						binaryWriter2.Write(num + array4.Length + array5.Length + array3[j]);
					}
					for (int k = 0; k < list.Count; k++)
					{
						binaryWriter2.Write(list[k].Key);
						binaryWriter2.Write(num + array[k]);
					}
					for (int l = 0; l < list2.Count; l++)
					{
						binaryWriter2.Write(list2[l].Key);
						binaryWriter2.Write(num + array4.Length + array2[l]);
					}
					binaryWriter2.Write(array4);
					binaryWriter2.Write(array5);
					binaryWriter2.Write(memoryStream3.ToArray());
					binaryWriter2.Flush();
				}
			}

			private ushort GetLookup(string packageName, string assemblyName, string ns)
			{
				FrameworkLookupId frameworkLookupId = default(FrameworkLookupId);
				frameworkLookupId.PackageName = packageName;
				frameworkLookupId.AssemblyName = assemblyName;
				frameworkLookupId.NameSpace = ns;
				FrameworkLookupId key = frameworkLookupId;
				if (frameworkLookupTable.TryGetValue(key, out ushort value))
				{
					return value;
				}
				AssemblyLookup item = new AssemblyLookup(packageName, assemblyName, ns);
				assemblyLookups.Add(item);
				int num = assemblyLookups.Count - 1;
				if (num > 65535)
				{
					throw new InvalidOperationException("Assembly lookup list overflow > " + ushort.MaxValue + " assemblies.");
				}
				frameworkLookupTable.Add(key, (ushort)num);
				return (ushort)num;
			}

			private bool AddToTable(string packageName, string assemblyName, Dictionary<int, List<ushort>> table, Dictionary<int, string> checkTable, string id, string ns)
			{
				int stableHashCode = GetStableHashCode(id);
				string value2;
				if (!table.TryGetValue(stableHashCode, out List<ushort> value))
				{
					value = (table[stableHashCode] = new List<ushort>());
				}
				else if (checkTable.TryGetValue(stableHashCode, out value2))
				{
					if (value2 != id)
					{
						throw new InvalidOperationException("Duplicate hash for " + value2 + " and " + id);
					}
				}
				else
				{
					checkTable.Add(stableHashCode, id);
				}
				ushort assemblyLookup = GetLookup(packageName, assemblyName, ns);
				if (!value.Any((ushort a) => a.Equals(assemblyLookup)))
				{
					value.Add(assemblyLookup);
					return true;
				}
				return false;
			}

			public void AddLookup(string packageName, string fullAssemblyName, IUnresolvedTypeDefinition type)
			{
				if (fullAssemblyName == null)
				{
					throw new ArgumentNullException("fullAssemblyName");
				}
				if (type == null)
				{
					throw new ArgumentNullException("type");
				}
				string identifier = GetIdentifier(type.Name, type.TypeParameters.Count);
				if (AddToTable(packageName, fullAssemblyName, typeLookup, typeCheck, identifier, type.Namespace) && (type.IsSealed || type.IsStatic))
				{
					foreach (IUnresolvedMethod method in type.Methods)
					{
						DefaultUnresolvedMethod defaultUnresolvedMethod = method as DefaultUnresolvedMethod;
						if (defaultUnresolvedMethod != null && defaultUnresolvedMethod.IsExtensionMethod)
						{
							AddToTable(packageName, fullAssemblyName, extensionMethodLookup, methodCheck, method.Name, method.DeclaringTypeDefinition.Namespace);
						}
					}
				}
			}
		}

		private const int headerSize = 15;

		public static readonly Version CurrentVersion = new Version(2, 0, 1);

		public static readonly FrameworkLookup Empty = new FrameworkLookup();

		private string fileName;

		private int[] assemblyListTable;

		private int[] typeLookupTable;

		private int[] extLookupTable;

		public IEnumerable<AssemblyLookup> GetExtensionMethodLookups(UnknownMemberResolveResult resolveResult)
		{
			return GetLookup(resolveResult.MemberName, extLookupTable, 15 + assemblyListTable.Length * 4 + typeLookupTable.Length * 8);
		}

		public IEnumerable<AssemblyLookup> GetLookups(UnknownIdentifierResolveResult resolveResult, int typeParameterCount, bool isInsideAttributeType)
		{
			string identifier = GetIdentifier(isInsideAttributeType ? (resolveResult.Identifier + "Attribute") : resolveResult.Identifier, typeParameterCount);
			return GetLookup(identifier, typeLookupTable, 15 + assemblyListTable.Length * 4);
		}

		public IEnumerable<AssemblyLookup> GetLookups(UnknownMemberResolveResult resolveResult, string fullMemberName, int typeParameterCount, bool isInsideAttributeType)
		{
			string identifier = GetIdentifier(isInsideAttributeType ? (resolveResult.MemberName + "Attribute") : resolveResult.MemberName, typeParameterCount);
			foreach (AssemblyLookup item in GetLookup(identifier, typeLookupTable, 15 + assemblyListTable.Length * 4))
			{
				if (fullMemberName.StartsWith(item.Namespace, StringComparison.Ordinal))
				{
					yield return item;
				}
			}
		}

		public static FrameworkBuilder Create(string fileName)
		{
			return new FrameworkBuilder(fileName);
		}

		public static FrameworkLookup Load(string fileName)
		{
			try
			{
				if (!File.Exists(fileName))
				{
					return null;
				}
			}
			catch (Exception)
			{
				return null;
			}
			FrameworkLookup frameworkLookup = new FrameworkLookup();
			frameworkLookup.fileName = fileName;
			using (BinaryReader binaryReader = new BinaryReader(File.OpenRead(fileName), Encoding.UTF8))
			{
				byte major = binaryReader.ReadByte();
				byte minor = binaryReader.ReadByte();
				byte build = binaryReader.ReadByte();
				if (new Version(major, minor, build) != CurrentVersion)
				{
					return null;
				}
				int num = binaryReader.ReadInt32();
				int num2 = binaryReader.ReadInt32();
				int num3 = binaryReader.ReadInt32();
				frameworkLookup.assemblyListTable = new int[num3];
				for (int i = 0; i < num3; i++)
				{
					frameworkLookup.assemblyListTable[i] = binaryReader.ReadInt32();
				}
				frameworkLookup.typeLookupTable = new int[num];
				for (int j = 0; j < num; j++)
				{
					frameworkLookup.typeLookupTable[j] = binaryReader.ReadInt32();
					binaryReader.ReadInt32();
				}
				frameworkLookup.extLookupTable = new int[num2];
				for (int k = 0; k < num2; k++)
				{
					frameworkLookup.extLookupTable[k] = binaryReader.ReadInt32();
					binaryReader.ReadInt32();
				}
				return frameworkLookup;
			}
		}

		private FrameworkLookup()
		{
		}

		private IEnumerable<AssemblyLookup> GetLookup(string identifier, int[] lookupTable, int tableOffset)
		{
			if (lookupTable != null)
			{
				int num = Array.BinarySearch(lookupTable, GetStableHashCode(identifier));
				if (num >= 0)
				{
					using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read), Encoding.UTF8))
					{
						reader.BaseStream.Seek(tableOffset + num * 8 + 4, SeekOrigin.Begin);
						int num2 = reader.ReadInt32();
						reader.BaseStream.Seek(num2, SeekOrigin.Begin);
						int num3 = reader.ReadInt32();
						List<ushort> list = new List<ushort>();
						while (num3-- > 0)
						{
							ushort num5 = reader.ReadUInt16();
							if (num5 < 0 || num5 >= assemblyListTable.Length)
							{
								throw new InvalidDataException("Assembly lookup was " + num5 + " but only " + assemblyListTable.Length + " are known.");
							}
							list.Add(num5);
						}
						foreach (ushort item in list)
						{
							reader.BaseStream.Seek(assemblyListTable[item], SeekOrigin.Begin);
							string package = reader.ReadString();
							string fullName = reader.ReadString();
							string nspace = reader.ReadString();
							yield return new AssemblyLookup(package, fullName, nspace);
						}
					}
				}
			}
		}

		private static int GetStableHashCode(string text)
		{
			int num = 0;
			foreach (char c in text)
			{
				num = (num << 5) - num + c;
			}
			return num;
		}

		private static string GetIdentifier(string identifier, int tc)
		{
			if (tc == 0)
			{
				return identifier;
			}
			return identifier + "`" + tc;
		}
	}
}
