using ICSharpCode.NRefactory.Editor;
using ICSharpCode.NRefactory.TypeSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Xml;

namespace ICSharpCode.NRefactory.Documentation
{
	[Serializable]
	public class XmlDocumentationProvider : IDocumentationProvider, IDeserializationCallback
	{
		private sealed class XmlDocumentationCache
		{
			private readonly KeyValuePair<string, string>[] entries;

			private int pos;

			public XmlDocumentationCache(int size = 50)
			{
				if (size <= 0)
				{
					throw new ArgumentOutOfRangeException("size", size, "Value must be positive");
				}
				entries = new KeyValuePair<string, string>[size];
			}

			internal bool TryGet(string key, out string value)
			{
				KeyValuePair<string, string>[] array = entries;
				for (int i = 0; i < array.Length; i++)
				{
					KeyValuePair<string, string> keyValuePair = array[i];
					if (keyValuePair.Key == key)
					{
						value = keyValuePair.Value;
						return true;
					}
				}
				value = null;
				return false;
			}

			internal void Add(string key, string value)
			{
				entries[pos++] = new KeyValuePair<string, string>(key, value);
				if (pos == entries.Length)
				{
					pos = 0;
				}
			}
		}

		[Serializable]
		private struct IndexEntry : IComparable<IndexEntry>
		{
			internal readonly int HashCode;

			internal readonly int PositionInFile;

			internal IndexEntry(int hashCode, int positionInFile)
			{
				HashCode = hashCode;
				PositionInFile = positionInFile;
			}

			public int CompareTo(IndexEntry other)
			{
				return HashCode.CompareTo(other.HashCode);
			}
		}

		private sealed class LinePositionMapper
		{
			private readonly FileStream fs;

			private readonly Decoder decoder;

			private int currentLine = 1;

			private byte[] input = new byte[1];

			private char[] output = new char[1];

			public LinePositionMapper(FileStream fs, Encoding encoding)
			{
				decoder = encoding.GetDecoder();
				this.fs = fs;
			}

			public int GetPositionForLine(int line)
			{
				while (line > currentLine)
				{
					int num = fs.ReadByte();
					if (num < 0)
					{
						throw new EndOfStreamException();
					}
					input[0] = (byte)num;
					decoder.Convert(input, 0, 1, output, 0, 1, flush: false, out int _, out int charsUsed, out bool _);
					if (charsUsed == 1 && output[0] == '\n')
					{
						currentLine++;
					}
				}
				return checked((int)fs.Position);
			}
		}

		[NonSerialized]
		private XmlDocumentationCache cache = new XmlDocumentationCache();

		private readonly string fileName;

		private readonly Encoding encoding;

		private volatile IndexEntry[] index;

		public XmlDocumentationProvider(string fileName)
		{
			if (fileName == null)
			{
				throw new ArgumentNullException("fileName");
			}
			using (FileStream input = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read | FileShare.Delete))
			{
				using (XmlTextReader xmlTextReader = new XmlTextReader(input))
				{
					xmlTextReader.XmlResolver = null;
					xmlTextReader.MoveToContent();
					if (string.IsNullOrEmpty(xmlTextReader.GetAttribute("redirect")))
					{
						this.fileName = fileName;
						encoding = xmlTextReader.Encoding;
						ReadXmlDoc(xmlTextReader);
					}
					else
					{
						string redirectionTarget = GetRedirectionTarget(fileName, xmlTextReader.GetAttribute("redirect"));
						if (redirectionTarget == null)
						{
							throw new XmlException("XmlDoc " + fileName + " is redirecting to " + xmlTextReader.GetAttribute("redirect") + ", but that file was not found.");
						}
						using (FileStream input2 = new FileStream(redirectionTarget, FileMode.Open, FileAccess.Read, FileShare.Read | FileShare.Delete))
						{
							using (XmlTextReader xmlTextReader2 = new XmlTextReader(input2))
							{
								xmlTextReader2.XmlResolver = null;
								xmlTextReader2.MoveToContent();
								this.fileName = redirectionTarget;
								encoding = xmlTextReader2.Encoding;
								ReadXmlDoc(xmlTextReader2);
							}
						}
					}
				}
			}
		}

		private static string GetRedirectionTarget(string xmlFileName, string target)
		{
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
			folderPath = AppendDirectorySeparator(folderPath);
			string runtimeDirectory = RuntimeEnvironment.GetRuntimeDirectory();
			runtimeDirectory = AppendDirectorySeparator(runtimeDirectory);
			string text = target.Replace("%PROGRAMFILESDIR%", folderPath).Replace("%CORSYSDIR%", runtimeDirectory);
			if (!Path.IsPathRooted(text))
			{
				text = Path.Combine(Path.GetDirectoryName(xmlFileName), text);
			}
			return LookupLocalizedXmlDoc(text);
		}

		private static string AppendDirectorySeparator(string dir)
		{
			if (dir.EndsWith("\\", StringComparison.Ordinal) || dir.EndsWith("/", StringComparison.Ordinal))
			{
				return dir;
			}
			return dir + Path.DirectorySeparatorChar.ToString();
		}

		public static string LookupLocalizedXmlDoc(string fileName)
		{
			string text = Path.ChangeExtension(fileName, ".xml");
			string twoLetterISOLanguageName = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
			string localizedName = GetLocalizedName(text, twoLetterISOLanguageName);
			if (File.Exists(localizedName))
			{
				return localizedName;
			}
			if (File.Exists(text))
			{
				return text;
			}
			if (twoLetterISOLanguageName != "en")
			{
				string localizedName2 = GetLocalizedName(text, "en");
				if (File.Exists(localizedName2))
				{
					return localizedName2;
				}
			}
			return null;
		}

		private static string GetLocalizedName(string fileName, string language)
		{
			return Path.Combine(Path.Combine(Path.GetDirectoryName(fileName), language), Path.GetFileName(fileName));
		}

		private void ReadXmlDoc(XmlTextReader reader)
		{
			using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read | FileShare.Delete))
			{
				LinePositionMapper linePosMapper = new LinePositionMapper(fs, encoding);
				List<IndexEntry> list = new List<IndexEntry>();
				while (reader.Read())
				{
					if (reader.IsStartElement())
					{
						string localName = reader.LocalName;
						if (localName == "members")
						{
							ReadMembersSection(reader, linePosMapper, list);
						}
					}
				}
				list.Sort();
				index = list.ToArray();
			}
		}

		private static void ReadMembersSection(XmlTextReader reader, LinePositionMapper linePosMapper, List<IndexEntry> indexList)
		{
			while (reader.Read())
			{
				switch (reader.NodeType)
				{
				case XmlNodeType.EndElement:
					if (reader.LocalName == "members")
					{
						return;
					}
					break;
				case XmlNodeType.Element:
					if (reader.LocalName == "member")
					{
						int positionInFile = linePosMapper.GetPositionForLine(reader.LineNumber) + Math.Max(reader.LinePosition - 2, 0);
						string attribute = reader.GetAttribute("name");
						if (attribute != null)
						{
							indexList.Add(new IndexEntry(GetHashCode(attribute), positionInFile));
						}
						reader.Skip();
					}
					break;
				}
			}
		}

		private static int GetHashCode(string key)
		{
			int num = 0;
			foreach (char c in key)
			{
				num = (num << 5) - num + c;
			}
			return num;
		}

		public string GetDocumentation(string key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			return GetDocumentation(key, allowReload: true);
		}

		private string GetDocumentation(string key, bool allowReload)
		{
			int hashCode = GetHashCode(key);
			IndexEntry[] array = index;
			int num = Array.BinarySearch(array, new IndexEntry(hashCode, 0));
			if (num < 0)
			{
				return null;
			}
			while (--num >= 0 && array[num].HashCode == hashCode)
			{
			}
			XmlDocumentationCache xmlDocumentationCache = cache;
			lock (xmlDocumentationCache)
			{
				if (!xmlDocumentationCache.TryGet(key, out string value))
				{
					try
					{
						while (++num < array.Length && array[num].HashCode == hashCode)
						{
							value = LoadDocumentation(key, array[num].PositionInFile);
							if (value != null)
							{
								break;
							}
						}
						xmlDocumentationCache.Add(key, value);
					}
					catch (IOException)
					{
						return allowReload ? ReloadAndGetDocumentation(key) : null;
					}
					catch (XmlException)
					{
						return allowReload ? ReloadAndGetDocumentation(key) : null;
					}
				}
				return value;
			}
		}

		private string ReloadAndGetDocumentation(string key)
		{
			try
			{
				using (FileStream input = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read | FileShare.Delete))
				{
					using (XmlTextReader xmlTextReader = new XmlTextReader(input))
					{
						xmlTextReader.XmlResolver = null;
						xmlTextReader.MoveToContent();
						ReadXmlDoc(xmlTextReader);
					}
				}
			}
			catch (IOException)
			{
				index = new IndexEntry[0];
				return null;
			}
			catch (XmlException)
			{
				index = new IndexEntry[0];
				return null;
			}
			return GetDocumentation(key, allowReload: false);
		}

		public DocumentationComment GetDocumentation(IEntity entity)
		{
			string documentation = GetDocumentation(entity.GetIdString());
			if (documentation != null)
			{
				return new DocumentationComment(new StringTextSource(documentation), new SimpleTypeResolveContext(entity));
			}
			return null;
		}

		private string LoadDocumentation(string key, int positionInFile)
		{
			using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read | FileShare.Delete))
			{
				fileStream.Position = positionInFile;
				XmlParserContext context = new XmlParserContext(null, null, null, XmlSpace.None)
				{
					Encoding = encoding
				};
				using (XmlTextReader xmlTextReader = new XmlTextReader(fileStream, XmlNodeType.Element, context))
				{
					xmlTextReader.XmlResolver = null;
					while (xmlTextReader.Read())
					{
						if (xmlTextReader.NodeType == XmlNodeType.Element)
						{
							if (xmlTextReader.GetAttribute("name") == key)
							{
								return xmlTextReader.ReadInnerXml();
							}
							return null;
						}
					}
					return null;
				}
			}
		}

		public virtual void OnDeserialization(object sender)
		{
			cache = new XmlDocumentationCache();
		}
	}
}
