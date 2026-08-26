using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace EdiTools
{
	public class EdiDocument
	{
		[CompilerGenerated]
		private EdiOptions _0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_0020_000A;

		[CompilerGenerated]
		private IList<EdiSegment> _0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020;

		public EdiOptions Options
		{
			get;
			private set;
		}

		public IList<EdiSegment> Segments
		{
			get;
			private set;
		}

		public IList<EdiTransactionSet> TransactionSets
		{
			get
			{
				List<EdiTransactionSet> list = new List<EdiTransactionSet>();
				EdiTransactionSet ediTransactionSet = null;
				EdiSegment interchangeHeader = null;
				EdiSegment functionalGroupHeader = null;
				foreach (EdiSegment segment in Segments)
				{
					switch (segment.Id.ToUpper())
					{
					case "ISA":
					case "UNB":
						interchangeHeader = segment;
						break;
					case "GS":
					case "UNG":
						functionalGroupHeader = segment;
						break;
					case "ST":
					case "UNH":
						ediTransactionSet = new EdiTransactionSet(interchangeHeader, functionalGroupHeader);
						list.Add(ediTransactionSet);
						break;
					case "GE":
					case "UNE":
						functionalGroupHeader = null;
						break;
					case "IEA":
					case "UNZ":
						interchangeHeader = null;
						break;
					}
					if (ediTransactionSet != null)
					{
						ediTransactionSet.Segments.Add(segment);
						if (segment.Id.Equals("SE", StringComparison.OrdinalIgnoreCase) || segment.Id.Equals("UNT", StringComparison.OrdinalIgnoreCase))
						{
							ediTransactionSet = null;
						}
					}
				}
				return list;
			}
		}

		public EdiDocument(EdiOptions options = null)
		{
			Options = ((options == null) ? new EdiOptions() : new EdiOptions(options));
			Segments = new List<EdiSegment>();
		}

		private EdiDocument(string edi, EdiOptions options)
		{
			if (options == null)
			{
				options = new EdiOptions();
				Options = options;
			}
			else
			{
				Options = new EdiOptions(options);
				options = new EdiOptions(options);
			}
			if (!options.SegmentTerminator.HasValue)
			{
				options.SegmentTerminator = _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020(edi);
			}
			if (!options.ElementSeparator.HasValue)
			{
				options.ElementSeparator = _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_000A(edi);
			}
			if (!options.ReleaseCharacter.HasValue)
			{
				options.ReleaseCharacter = _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A(edi);
			}
			Segments = new List<EdiSegment>();
			string[] array = _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020(edi, options.SegmentTerminator.Value, options.ReleaseCharacter);
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i];
				if (i == array.Length - 1 && (text == null || text.Trim() == string.Empty))
				{
					break;
				}
				EdiSegment ediSegment = null;
				if (text.StartsWith("UNA", StringComparison.OrdinalIgnoreCase))
				{
					ediSegment = new EdiSegment(text.Substring(0, 3))
					{
						Elements = 
						{
							new EdiElement(text.Substring(3, 5))
						}
					};
					options.ComponentSeparator = text[3];
					options.DecimalIndicator = text[5];
				}
				else
				{
					string[] array2 = _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020(text.TrimStart(), options.ElementSeparator.Value, options.ReleaseCharacter);
					ediSegment = new EdiSegment(array2[0]);
					for (int j = 1; j < array2.Length; j++)
					{
						if (ediSegment.Id.Equals("ISA", StringComparison.OrdinalIgnoreCase))
						{
							switch (j)
							{
							case 16:
								options.ComponentSeparator = array2[j][0];
								ediSegment.Elements.Add(new EdiElement(array2[j]));
								continue;
							case 11:
								if (string.CompareOrdinal(array2[12], "00402") >= 0 && !char.IsLetterOrDigit(array2[j][0]))
								{
									options.RepetitionSeparator = array2[j][0];
									ediSegment.Elements.Add(new EdiElement(array2[j]));
									continue;
								}
								options.RepetitionSeparator = null;
								break;
							}
						}
						ediSegment.Elements.Add((array2[j] != string.Empty) ? _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020(array2[j], options) : null);
					}
				}
				Segments.Add(ediSegment);
			}
		}

		private EdiDocument(XDocument xml)
		{
			Options = new EdiOptions();
			Segments = new List<EdiSegment>();
			_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_0020_0020(xml.Root);
		}

		public static EdiDocument Parse(string edi, EdiOptions options = null)
		{
			return new EdiDocument(edi, options);
		}

		public static EdiDocument Load(string fileName, EdiOptions options = null)
		{
			return new EdiDocument(File.ReadAllText(fileName), options);
		}

		public static EdiDocument Load(TextReader reader, EdiOptions options = null)
		{
			return new EdiDocument(reader.ReadToEnd(), options);
		}

		public static EdiDocument Load(Stream stream, EdiOptions options = null)
		{
			using (StreamReader streamReader = new StreamReader(stream))
			{
				return new EdiDocument(streamReader.ReadToEnd(), options);
			}
		}

		public static EdiDocument ParseXml(string text)
		{
			return new EdiDocument(XDocument.Parse(text));
		}

		public static EdiDocument LoadXml(XDocument xml)
		{
			return new EdiDocument(xml);
		}

		public static EdiDocument LoadXml(string fileName)
		{
			return new EdiDocument(XDocument.Load(fileName));
		}

		public static EdiDocument LoadXml(TextReader reader)
		{
			return new EdiDocument(XDocument.Load(reader));
		}

		public static EdiDocument LoadXml(Stream stream)
		{
			using (StreamReader textReader = new StreamReader(stream))
			{
				return new EdiDocument(XDocument.Load(textReader));
			}
		}

		private char _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_000A(string _0020)
		{
			if (_0020.StartsWith("UNA", StringComparison.OrdinalIgnoreCase))
			{
				return _0020[4];
			}
			Match match = Regex.Match(_0020, "[^A-Z0-9]", RegexOptions.IgnoreCase);
			if (!match.Success)
			{
				throw new Exception("Could not guess the element separator.");
			}
			return match.Value[0];
		}

		private char _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020(string _0020)
		{
			if (_0020.StartsWith("ISA", StringComparison.OrdinalIgnoreCase))
			{
				return _0020[105];
			}
			if (_0020.StartsWith("UNA", StringComparison.OrdinalIgnoreCase))
			{
				return _0020[8];
			}
			Match match = Regex.Match(_0020, "([\\x00-\\x1f~])\\s*$");
			if (!match.Success)
			{
				throw new Exception("Could not guess the segment terminator.");
			}
			return match.Groups[1].Value[0];
		}

		private char? _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A(string _0020)
		{
			if (_0020.StartsWith("UNA", StringComparison.OrdinalIgnoreCase) && _0020[6] != ' ')
			{
				return _0020[6];
			}
			return null;
		}

		private EdiElement _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020(string _0020, EdiOptions _0020_000A)
		{
			EdiElement ediElement = new EdiElement();
			string[] array = _0020_000A.RepetitionSeparator.HasValue ? _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020(_0020, _0020_000A.RepetitionSeparator.Value, _0020_000A.ReleaseCharacter) : new string[1]
			{
				_0020
			};
			foreach (string text in array)
			{
				if (text != string.Empty)
				{
					ediElement.Repetitions.Add(_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A(text, _0020_000A));
				}
			}
			return ediElement;
		}

		private EdiRepetition _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A(string _0020, EdiOptions _0020_000A)
		{
			EdiRepetition ediRepetition = new EdiRepetition();
			string[] array = _0020_000A.ComponentSeparator.HasValue ? _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020(_0020, _0020_000A.ComponentSeparator.Value, _0020_000A.ReleaseCharacter) : new string[1]
			{
				_0020
			};
			foreach (string text in array)
			{
				if (text != string.Empty)
				{
					ediRepetition.Components.Add(new EdiComponent(_0020_000A.ReleaseCharacter.HasValue ? _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_0020_000A(text, _0020_000A.ReleaseCharacter.Value) : text));
				}
				else
				{
					ediRepetition.Components.Add(null);
				}
			}
			return ediRepetition;
		}

		private string[] _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020(string _0020, char _0020_000A, char? _0020_0020)
		{
			if (_0020_0020.HasValue)
			{
				return Regex.Split(_0020, "(?<!" + Regex.Escape(_0020_0020.ToString()) + ")" + Regex.Escape(_0020_000A.ToString()));
			}
			return _0020.Split(_0020_000A);
		}

		private string _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_0020_000A(string _0020, char _0020_000A)
		{
			return Regex.Replace(_0020, Regex.Escape(_0020_000A.ToString()) + "(.)", "$1");
		}

		private void _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_0020_0020(XElement _0020)
		{
			foreach (XElement item in _0020.Elements())
			{
				if (item.Name.LocalName.EndsWith("loop"))
				{
					_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_0020_0020(item);
				}
				else
				{
					_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A(item);
				}
			}
		}

		private void _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A(XElement _0020)
		{
			EdiSegment ediSegment = new EdiSegment(_0020.Name.LocalName.ToUpper());
			foreach (XElement item in _0020.Elements())
			{
				int num = _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020(item.Name.LocalName);
				if (num != -1)
				{
					while (ediSegment.Elements.Count <= num)
					{
						ediSegment.Elements.Add(null);
					}
					if (ediSegment.Elements[num] == null)
					{
						ediSegment.Elements[num] = new EdiElement();
					}
					ediSegment.Elements[num].Repetitions.Add(_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020(item));
				}
			}
			Segments.Add(ediSegment);
		}

		private int _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020(string _0020)
		{
			if (_0020.Length < 2 || !int.TryParse(_0020.Substring(_0020.Length - 2), out int result))
			{
				return -1;
			}
			return result - 1;
		}

		private EdiRepetition _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020(XElement _0020)
		{
			EdiRepetition ediRepetition = new EdiRepetition();
			if (_0020.HasElements)
			{
				foreach (XElement item in _0020.Elements())
				{
					int num = _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020(item.Name.LocalName);
					if (num != -1)
					{
						while (ediRepetition.Components.Count <= num)
						{
							ediRepetition.Components.Add(null);
						}
						if (ediRepetition.Components[num] == null)
						{
							ediRepetition.Components[num] = new EdiComponent(_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020_000A(item));
						}
					}
				}
				return ediRepetition;
			}
			ediRepetition.Value = _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020_000A(_0020);
			return ediRepetition;
		}

		private string _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020_000A(XElement _0020)
		{
			string text = null;
			XAttribute xAttribute = _0020.Attribute("type");
			if (xAttribute != null)
			{
				text = xAttribute.Value;
			}
			if (text != null && !(text == "id") && !(text == "an"))
			{
				if (!(text == "dt"))
				{
					if (!(text == "tm"))
					{
						if (text == "r")
						{
							if (decimal.TryParse(_0020.Value, out decimal result))
							{
								string text2 = EdiValue.Real(result);
								if (Options.DecimalIndicator.HasValue)
								{
									text2 = text2.Replace('.', Options.DecimalIndicator.Value);
								}
								return text2;
							}
							return _0020.Value;
						}
						if (text == null || text.Length != 2 || text[0] != 'n' || !char.IsDigit(text[1]))
						{
							return _0020.Value;
						}
						int decimals = int.Parse(text.Substring(1));
						if (!decimal.TryParse(_0020.Value, out decimal result2))
						{
							return _0020.Value;
						}
						return EdiValue.Numeric(decimals, result2);
					}
					if (!DateTime.TryParse(_0020.Value, out DateTime result3))
					{
						return _0020.Value;
					}
					int num = Regex.Replace(_0020.Value, "[^0-9]", string.Empty).Length;
					if (_0020.Value[1] == ':')
					{
						num++;
					}
					return EdiValue.Time(num, result3);
				}
				if (!DateTime.TryParse(_0020.Value, out DateTime result4))
				{
					return _0020.Value;
				}
				return EdiValue.Date(8, result4);
			}
			return _0020.Value;
		}

		public void Save(string fileName)
		{
			using (StreamWriter writer = new StreamWriter(fileName))
			{
				Save(writer);
			}
		}

		public void Save(Stream stream)
		{
			using (StreamWriter writer = new StreamWriter(stream))
			{
				Save(writer);
			}
		}

		public void Save(TextWriter writer)
		{
			EdiOptions ediOptions = new EdiOptions(Options);
			foreach (EdiSegment segment in Segments)
			{
				if (segment.Id.Equals("ISA", StringComparison.OrdinalIgnoreCase))
				{
					if (segment[11] != null && string.CompareOrdinal(segment[12], "00402") >= 0 && !char.IsLetterOrDigit(segment[11][0]))
					{
						ediOptions.RepetitionSeparator = segment[11][0];
					}
					else
					{
						ediOptions.RepetitionSeparator = null;
					}
					if (segment[16] != null)
					{
						ediOptions.ComponentSeparator = segment[16][0];
					}
				}
				writer.Write(segment.ToString(ediOptions));
				if (ediOptions.AddLineBreaks)
				{
					writer.WriteLine();
				}
			}
			writer.Flush();
		}

		public override string ToString()
		{
			StringWriter stringWriter = new StringWriter();
			Save(stringWriter);
			return stringWriter.ToString();
		}
	}
}
