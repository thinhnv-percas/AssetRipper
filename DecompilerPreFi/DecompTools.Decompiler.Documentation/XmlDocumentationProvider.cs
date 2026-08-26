#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Xml;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.Documentation;

[Serializable]
public class XmlDocumentationProvider : IDeserializationCallback, IDocumentationProvider
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
			entries[checked(pos++)] = new KeyValuePair<string, string>(key, value);
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
			int hashCode = HashCode;
			return hashCode.CompareTo(other.HashCode);
		}
	}

	private sealed class LinePositionMapper
	{
		private readonly FileStream fs;

		private readonly Decoder decoder;

		private int currentLine = 1;

		private char prevChar = '\0';

		private byte[] input = new byte[1];

		private char[] output = new char[1];

		public LinePositionMapper(FileStream fs, Encoding encoding)
		{
			decoder = encoding.GetDecoder();
			this.fs = fs;
		}

		public int GetPositionForLine(int line)
		{
			Debug.Assert(line >= currentLine);
			checked
			{
				while (line > currentLine)
				{
					int num = fs.ReadByte();
					if (num < 0)
					{
						throw new EndOfStreamException();
					}
					input[0] = (byte)num;
					decoder.Convert(input, 0, 1, output, 0, 1, flush: false, out var bytesUsed, out var charsUsed, out var _);
					Debug.Assert(bytesUsed == 1);
					if (charsUsed == 1)
					{
						if ((prevChar != '\r' && output[0] == '\n') || output[0] == '\r')
						{
							currentLine++;
						}
						prevChar = output[0];
					}
				}
				return (int)fs.Position;
			}
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
		using FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read | FileShare.Delete);
		using XmlTextReader xmlTextReader = new XmlTextReader((Stream)fileStream);
		xmlTextReader.XmlResolver = null;
		xmlTextReader.MoveToContent();
		if (string.IsNullOrEmpty(xmlTextReader.GetAttribute("redirect")))
		{
			this.fileName = fileName;
			encoding = xmlTextReader.Encoding;
			ReadXmlDoc(xmlTextReader);
			return;
		}
		string redirectionTarget = GetRedirectionTarget(fileName, xmlTextReader.GetAttribute("redirect"));
		if (redirectionTarget != null)
		{
			Debug.WriteLine("XmlDoc " + fileName + " is redirecting to " + redirectionTarget);
			using FileStream fileStream2 = new FileStream(redirectionTarget, FileMode.Open, FileAccess.Read, FileShare.Read | FileShare.Delete);
			using XmlTextReader xmlTextReader2 = new XmlTextReader((Stream)fileStream2);
			xmlTextReader2.XmlResolver = null;
			xmlTextReader2.MoveToContent();
			this.fileName = redirectionTarget;
			encoding = xmlTextReader2.Encoding;
			ReadXmlDoc(xmlTextReader2);
			return;
		}
		throw new XmlException("XmlDoc " + fileName + " is redirecting to " + xmlTextReader.GetAttribute("redirect") + ", but that file was not found.");
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
		char directorySeparatorChar = Path.DirectorySeparatorChar;
		return dir + directorySeparatorChar;
	}

	public static string LookupLocalizedXmlDoc(string fileName)
	{
		string text = Path.ChangeExtension(fileName, ".xml");
		string twoLetterISOLanguageName = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
		string localizedName = GetLocalizedName(text, twoLetterISOLanguageName);
		Debug.WriteLine("Try find XMLDoc @" + localizedName);
		if (File.Exists(localizedName))
		{
			return localizedName;
		}
		Debug.WriteLine("Try find XMLDoc @" + text);
		if (File.Exists(text))
		{
			return text;
		}
		if (twoLetterISOLanguageName != "en")
		{
			string localizedName2 = GetLocalizedName(text, "en");
			Debug.WriteLine("Try find XMLDoc @" + localizedName2);
			if (File.Exists(localizedName2))
			{
				return localizedName2;
			}
		}
		return null;
	}

	private static string GetLocalizedName(string fileName, string language)
	{
		string directoryName = Path.GetDirectoryName(fileName);
		directoryName = Path.Combine(directoryName, language);
		return Path.Combine(directoryName, Path.GetFileName(fileName));
	}

	private void ReadXmlDoc(XmlTextReader reader)
	{
		using FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read | FileShare.Delete);
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
					int positionInFile = checked(linePosMapper.GetPositionForLine(reader.LineNumber) + Math.Max(reader.LinePosition - 2, 0));
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

	public string GetDocumentation(IEntity entity)
	{
		if (entity == null)
		{
			throw new ArgumentNullException("entity");
		}
		return GetDocumentation(entity.GetIdString());
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
		checked
		{
			while (--num >= 0 && array[num].HashCode == hashCode)
			{
			}
			XmlDocumentationCache xmlDocumentationCache = cache;
			lock (xmlDocumentationCache)
			{
				if (!xmlDocumentationCache.TryGet(key, out var value))
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
	}

	private string ReloadAndGetDocumentation(string key)
	{
		try
		{
			using FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read | FileShare.Delete);
			using XmlTextReader xmlTextReader = new XmlTextReader((Stream)fileStream);
			xmlTextReader.XmlResolver = null;
			xmlTextReader.MoveToContent();
			ReadXmlDoc(xmlTextReader);
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

	private string LoadDocumentation(string key, int positionInFile)
	{
		using FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read | FileShare.Delete);
		fileStream.Position = positionInFile;
		XmlParserContext xmlParserContext = new XmlParserContext(null, null, null, XmlSpace.None)
		{
			Encoding = encoding
		};
		using XmlTextReader xmlTextReader = new XmlTextReader((Stream)fileStream, XmlNodeType.Element, xmlParserContext);
		xmlTextReader.XmlResolver = null;
		while (xmlTextReader.Read())
		{
			if (xmlTextReader.NodeType == XmlNodeType.Element)
			{
				string attribute = xmlTextReader.GetAttribute("name");
				if (attribute == key)
				{
					return xmlTextReader.ReadInnerXml();
				}
				return null;
			}
		}
		return null;
	}

	public virtual void OnDeserialization(object sender)
	{
		cache = new XmlDocumentationCache();
	}
}
