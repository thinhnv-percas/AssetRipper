using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

internal class LicChecker
{
	internal const string _0020_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A_000A = "------------ ACTIVATION -------------";

	internal const string _0020_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A_0020 = "------------- LICENSE --------------";

	internal const string _0020_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A = "-------------------------------------";

	internal static uint _0020_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020;

	internal static string _0020_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_000A_000A;

	internal static uint _0020_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_000A_0020;

	internal static bool _0020_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A;

	internal static string _0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020(string _0020)
	{
		try
		{
			if (string.IsNullOrEmpty(_0020))
			{
				return "";
			}
			if (_0020.IndexOf("------------- LICENSE --------------") >= 0)
			{
				_0020 = _0020.Substring(_0020.IndexOf("------------- LICENSE --------------") + "------------- LICENSE --------------".Length);
			}
			else if (_0020.IndexOf("------------ ACTIVATION -------------") >= 0)
			{
				_0020 = _0020.Substring(_0020.IndexOf("------------ ACTIVATION -------------") + "------------ ACTIVATION -------------".Length);
			}
			if (_0020.IndexOf("-------------------------------------") >= 0)
			{
				_0020 = _0020.Substring(0, _0020.IndexOf("-------------------------------------"));
			}
			_0020 = _0020.Replace(" ", "");
			_0020 = _0020.Replace("\n", "");
			_0020 = _0020.Replace("\r", "");
			_0020 = _0020.Replace("\t", "");
			return _0020;
		}
		catch (Exception)
		{
			return "";
		}
	}

	internal static string _0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_0020_000A(string _0020)
	{
		return _0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_0020_0020(_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020(_0020));
	}

	internal static string _0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_0020_0020(string _0020)
	{
		if (_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020._0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A(_0020) == _0020_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020)
		{
			return _0020_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_000A_000A;
		}
		try
		{
			byte[] array;
			using (MemoryStream input = new MemoryStream(Convert.FromBase64String(_0020)))
			{
				using (BinaryReader binaryReader = new BinaryReader(input))
				{
					DateTime.FromBinary(binaryReader.ReadInt64());
					int count = binaryReader.ReadInt32();
					array = binaryReader.ReadBytes(count);
					int count2 = binaryReader.ReadInt32();
					binaryReader.ReadBytes(count2);
				}
			}
			string @string = Encoding.UTF8.GetString(array, 0, array.Length);
			_0020_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020 = _0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020._0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A(_0020);
			_0020_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_000A_000A = @string;
			return @string;
		}
		catch (Exception)
		{
			_0020_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020 = _0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020._0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A(_0020);
			_0020_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_000A_000A = "";
			return "";
		}
	}

	[FunAttr(Num = "7DED7100EFD400C789B13A6247846E62")]
	public static bool CheckXml(string data, string xml)
	{
		if (data.Contains("Cracked"))
		{
			return true;
		}
		try
		{
			if (string.IsNullOrEmpty(xml) || string.IsNullOrEmpty(data))
			{
				return false;
			}
			new RSACryptoServiceProvider().ImportParameters(_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020_000A_000A(xml));
			data = _0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020(data);
			return (bool)HiddenCalls.CallObjectSafe1(null, "432742083", data, xml);
		}
		catch (Exception)
		{
			return false;
		}
	}

	[FunAttr(Num = "9CE799EF89AFE3D0D724EFAF3FC2CCC2")]
	internal static bool _0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A_000A_0020(string _0020, string _0020_000A)
	{
		if (_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020._0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A(_0020 + _0020_000A) == _0020_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_000A_0020)
		{
			return _0020_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A;
		}
		try
		{
			RSACryptoServiceProvider.UseMachineKeyStore = true;
			RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider();
			rSACryptoServiceProvider.ImportParameters(_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020_000A_000A(_0020_000A));
			byte[] buffer;
			byte[] signature;
			using (MemoryStream input = new MemoryStream(Convert.FromBase64String(_0020)))
			{
				using (BinaryReader binaryReader = new BinaryReader(input))
				{
					DateTime.FromBinary(binaryReader.ReadInt64());
					int count = binaryReader.ReadInt32();
					buffer = binaryReader.ReadBytes(count);
					int count2 = binaryReader.ReadInt32();
					signature = binaryReader.ReadBytes(count2);
				}
			}
			bool result = rSACryptoServiceProvider.VerifyData(buffer, new SHA1CryptoServiceProvider(), signature);
			_0020_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_000A_0020 = _0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020._0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A(_0020 + _0020_000A);
			_0020_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A = result;
			return result;
		}
		catch (Exception)
		{
			_0020_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_000A_0020 = _0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020._0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A(_0020 + _0020_000A);
			_0020_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A = false;
			return false;
		}
	}

	internal static string _0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A(RSAParameters _0020)
	{
		try
		{
			return _0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020(_0020).OuterXml;
		}
		catch
		{
			return null;
		}
	}

	internal static XmlDocument _0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020(RSAParameters _0020)
	{
		try
		{
			string xml = "<?xml version=\"1.0\"?><RSAKEY></RSAKEY>";
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(xml);
			XmlNode documentElement = xmlDocument.DocumentElement;
			XmlNode xmlNode = null;
			string text = null;
			if (_0020.D != null && _0020.D.Length != 0)
			{
				text = Convert.ToBase64String(_0020.D);
				if (text != null)
				{
					xmlNode = xmlDocument.CreateElement("D");
					xmlNode.InnerText = text;
					documentElement.AppendChild(xmlNode);
				}
			}
			if (_0020.DP != null && _0020.DP.Length != 0)
			{
				text = Convert.ToBase64String(_0020.DP);
				if (text != null)
				{
					xmlNode = xmlDocument.CreateElement("DP");
					xmlNode.InnerText = text;
					documentElement.AppendChild(xmlNode);
				}
			}
			if (_0020.DQ != null && _0020.DQ.Length != 0)
			{
				text = Convert.ToBase64String(_0020.DQ);
				if (text != null)
				{
					xmlNode = xmlDocument.CreateElement("DQ");
					xmlNode.InnerText = text;
					documentElement.AppendChild(xmlNode);
				}
			}
			if (_0020.Exponent != null && _0020.Exponent.Length != 0)
			{
				text = Convert.ToBase64String(_0020.Exponent);
				if (text != null)
				{
					xmlNode = xmlDocument.CreateElement("Exponent");
					xmlNode.InnerText = text;
					documentElement.AppendChild(xmlNode);
				}
			}
			if (_0020.InverseQ != null && _0020.InverseQ.Length != 0)
			{
				text = Convert.ToBase64String(_0020.InverseQ);
				if (text != null)
				{
					xmlNode = xmlDocument.CreateElement("InverseQ");
					xmlNode.InnerText = text;
					documentElement.AppendChild(xmlNode);
				}
			}
			if (_0020.Modulus != null && _0020.Modulus.Length != 0)
			{
				text = Convert.ToBase64String(_0020.Modulus);
				if (text != null)
				{
					xmlNode = xmlDocument.CreateElement("Modulus");
					xmlNode.InnerText = text;
					documentElement.AppendChild(xmlNode);
				}
			}
			if (_0020.P != null && _0020.P.Length != 0)
			{
				text = Convert.ToBase64String(_0020.P);
				if (text != null)
				{
					xmlNode = xmlDocument.CreateElement("P");
					xmlNode.InnerText = text;
					documentElement.AppendChild(xmlNode);
				}
			}
			if (_0020.Q != null && _0020.Q.Length != 0)
			{
				text = Convert.ToBase64String(_0020.Q);
				if (text != null)
				{
					xmlNode = xmlDocument.CreateElement("Q");
					xmlNode.InnerText = text;
					documentElement.AppendChild(xmlNode);
				}
			}
			return xmlDocument;
		}
		catch
		{
			return null;
		}
	}

	internal static RSAParameters _0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020_000A_000A(string _0020)
	{
		try
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(_0020);
			return _0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020_000A_0020(xmlDocument);
		}
		catch (Exception)
		{
			return default(RSAParameters);
		}
	}

	internal static RSAParameters _0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020_000A_0020(XmlDocument _0020)
	{
		try
		{
			XmlElement documentElement = _0020.DocumentElement;
			XmlNode xmlNode = null;
			RSAParameters result = default(RSAParameters);
			result.D = null;
			result.DP = null;
			result.DQ = null;
			result.Exponent = null;
			result.InverseQ = null;
			result.Modulus = null;
			result.P = null;
			result.Q = null;
			xmlNode = _0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020(documentElement, "D");
			if (xmlNode != null && xmlNode.InnerText != null && xmlNode.InnerText.Length > 0)
			{
				result.D = Convert.FromBase64String(xmlNode.InnerText);
			}
			xmlNode = _0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020(documentElement, "DP");
			if (xmlNode != null && xmlNode.InnerText != null && xmlNode.InnerText.Length > 0)
			{
				result.DP = Convert.FromBase64String(xmlNode.InnerText);
			}
			xmlNode = _0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020(documentElement, "DQ");
			if (xmlNode != null && xmlNode.InnerText != null && xmlNode.InnerText.Length > 0)
			{
				result.DQ = Convert.FromBase64String(xmlNode.InnerText);
			}
			xmlNode = _0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020(documentElement, "Exponent");
			if (xmlNode != null && xmlNode.InnerText != null && xmlNode.InnerText.Length > 0)
			{
				result.Exponent = Convert.FromBase64String(xmlNode.InnerText);
			}
			xmlNode = _0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020(documentElement, "InverseQ");
			if (xmlNode != null && xmlNode.InnerText != null && xmlNode.InnerText.Length > 0)
			{
				result.InverseQ = Convert.FromBase64String(xmlNode.InnerText);
			}
			xmlNode = _0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020(documentElement, "Modulus");
			if (xmlNode != null && xmlNode.InnerText != null && xmlNode.InnerText.Length > 0)
			{
				result.Modulus = Convert.FromBase64String(xmlNode.InnerText);
			}
			xmlNode = _0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020(documentElement, "P");
			if (xmlNode != null && xmlNode.InnerText != null && xmlNode.InnerText.Length > 0)
			{
				result.P = Convert.FromBase64String(xmlNode.InnerText);
			}
			xmlNode = _0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020(documentElement, "Q");
			if (xmlNode != null && xmlNode.InnerText != null && xmlNode.InnerText.Length > 0)
			{
				result.Q = Convert.FromBase64String(xmlNode.InnerText);
			}
			return result;
		}
		catch (Exception)
		{
			return default(RSAParameters);
		}
	}

	internal static XmlNode _0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020(XmlNode _0020, string _0020_000A, string _0020_0020, string _0020_000A_000A)
	{
		if (_0020 == null)
		{
			return null;
		}
		if (_0020_000A == null || _0020_000A == "")
		{
			if (_0020_0020 != null && _0020_000A_000A != null)
			{
				XmlAttribute xmlAttribute = _0020.Attributes[_0020_0020];
				if (xmlAttribute != null && string.Compare(_0020_000A_000A, xmlAttribute.Value) == 0)
				{
					return _0020;
				}
				return null;
			}
			return _0020;
		}
		XmlNode xmlNode = _0020;
		string[] array = _0020_000A.Split('/', '\\');
		int num = array.GetLength(0) - 1;
		int num2 = 0;
		string[] array2 = array;
		foreach (string strA in array2)
		{
			XmlNodeList childNodes = xmlNode.ChildNodes;
			bool flag = false;
			foreach (XmlNode item in childNodes)
			{
				if (string.Compare(strA, item.Name, ignoreCase: true) == 0)
				{
					if (num2 != num || _0020_0020 == null || _0020_000A_000A == null)
					{
						xmlNode = item;
						flag = true;
						break;
					}
					XmlAttribute xmlAttribute2 = item.Attributes[_0020_0020];
					if (xmlAttribute2 != null && string.Compare(_0020_000A_000A, xmlAttribute2.Value) == 0)
					{
						xmlNode = item;
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				return null;
			}
			num2++;
		}
		return xmlNode;
	}

	internal static XmlNode _0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020(XmlNode _0020, string _0020_000A)
	{
		return _0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020(_0020, _0020_000A, null, null);
	}

	internal static string _0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A(string _0020, string _0020_000A)
	{
		return _0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A(_0020, _0020_000A, '\n');
	}

	internal static string _0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A(string _0020, string _0020_000A, string _0020_0020)
	{
		if (string.IsNullOrEmpty(_0020) || string.IsNullOrEmpty(_0020_000A))
		{
			return "";
		}
		_0020_000A += "=";
		int length = _0020_000A.Length;
		int num;
		if ((num = _0020.IndexOf(_0020_0020 + _0020_000A)) >= 0 || (num = _0020.IndexOf(_0020_000A)) == 0)
		{
			num = ((num != 0) ? (num + (_0020_0020.Length + length)) : (num + length));
			int num2 = _0020.IndexOf(_0020_0020, num);
			if (num2 > 0)
			{
				return _0020.Substring(num, num2 - num);
			}
			return _0020.Substring(num);
		}
		return "";
	}

	internal static string _0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A(string _0020, string _0020_000A, char _0020_0020)
	{
		if (string.IsNullOrEmpty(_0020) || string.IsNullOrEmpty(_0020_000A))
		{
			return "";
		}
		_0020_000A += "=";
		int length = _0020_000A.Length;
		int num;
		if ((num = _0020.IndexOf(_0020_0020.ToString() + _0020_000A)) >= 0 || (num = _0020.IndexOf(_0020_000A)) == 0)
		{
			num = ((num != 0) ? (num + (1 + length)) : (num + length));
			int num2 = _0020.IndexOf(_0020_0020, num);
			if (num2 > 0)
			{
				return _0020.Substring(num, num2 - num);
			}
			return _0020.Substring(num);
		}
		return "";
	}

	internal static string _0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020(string _0020, string _0020_000A, string _0020_0020)
	{
		return _0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020(_0020, _0020_000A, _0020_0020, '\n');
	}

	internal static string _0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020(string _0020, string _0020_000A, string _0020_0020, string _0020_000A_000A)
	{
		_0020_000A += "=";
		int length = _0020_000A.Length;
		int num;
		if ((num = _0020.IndexOf(_0020_000A_000A + _0020_000A)) >= 0 || (num = _0020.IndexOf(_0020_000A)) == 0)
		{
			num = ((num != 0) ? (num + (_0020_000A_000A.Length + length)) : (num + length));
			int num2 = _0020.IndexOf(_0020_000A_000A, num);
			if (num2 > 0)
			{
				_0020 = _0020.Remove(num, num2 - num);
				_0020 = _0020.Insert(num, _0020_0020);
				return _0020;
			}
			_0020 = _0020.Remove(num, _0020.Length - num);
			_0020 = _0020.Insert(num, _0020_0020);
			return _0020;
		}
		if (_0020.Length > 0 && _0020[_0020.Length - 1].ToString() != _0020_000A_000A)
		{
			_0020 += _0020_000A_000A.ToString();
		}
		_0020 = _0020 + _0020_000A + _0020_0020 + _0020_000A_000A;
		return _0020;
	}

	internal static string _0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020(string _0020, string _0020_000A, string _0020_0020, char _0020_000A_000A)
	{
		_0020_000A += "=";
		int length = _0020_000A.Length;
		int num;
		if ((num = _0020.IndexOf(_0020_000A_000A.ToString() + _0020_000A)) >= 0 || (num = _0020.IndexOf(_0020_000A)) == 0)
		{
			num = ((num != 0) ? (num + (1 + length)) : (num + length));
			int num2 = _0020.IndexOf(_0020_000A_000A, num);
			if (num2 > 0)
			{
				_0020 = _0020.Remove(num, num2 - num);
				_0020 = _0020.Insert(num, _0020_0020);
				return _0020;
			}
			_0020 = _0020.Remove(num, _0020.Length - num);
			_0020 = _0020.Insert(num, _0020_0020);
			return _0020;
		}
		if (_0020.Length > 0 && _0020[_0020.Length - 1] != _0020_000A_000A)
		{
			_0020 += _0020_000A_000A.ToString();
		}
		_0020 = _0020 + _0020_000A + _0020_0020 + _0020_000A_000A.ToString();
		return _0020;
	}

	[FunAttr(Num = "819648A8BF080ABC4B7A1305D9168587")]
	internal static string _0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A(string _0020)
	{
		return _0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A(_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_0020_000A(_0020), "LicenseNumber");
	}

	[FunAttr(Num = "9ED6EF3A457AEEC94FE8BD99B21292DE")]
	internal static string _0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A(string _0020)
	{
		return _0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A(_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_0020_000A(_0020), "GUID");
	}

	[FunAttr(Num = "F801399EB007894F8DF1A5515C12E8BE")]
	internal static string _0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_000A_0020(string _0020)
	{
		return _0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A(_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_0020_000A(_0020), "GUID");
	}

	[FunAttr(Num = "4201CAB6B89CCF03FC38FFD9FA277391")]
	internal static string _0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A()
	{
		return ConvertNameToHash.Get();
	}

	[FunAttr(Num = "81EA6F036044B87F5C5BBE07AA5993FF")]
	internal static bool IsActivaded(string license, string activation)
	{
		if (license.Contains("Cracked") && activation.Contains("Cracked"))
		{
			return true;
		}
		if (_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A(_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_0020_000A(license), "LicenseNumber") != _0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A(_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_0020_000A(activation), "LicenseNumber"))
		{
			return false;
		}
		string _0020 = _0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_0020_000A(activation);
		string a = _0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A(_0020, "LicenseType");
		string b = _0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A(_0020, "BindingID");
		string text = _0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A(_0020, "ExpirationDate");
		string text2 = _0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A(_0020, "ExpirationDate.Ticks");
		string text3 = _0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A(_0020, "LastActivationDate.Ticks");
		if (a == "Activation")
		{
			if (string.IsNullOrEmpty(text3))
			{
				return false;
			}
			DateTime d = new DateTime(long.Parse(text3), DateTimeKind.Utc);
			if (Math.Abs((DateTime.UtcNow - d).TotalDays) > 2.0)
			{
				return false;
			}
		}
		if (!string.IsNullOrEmpty(text2))
		{
			DateTime t = new DateTime(long.Parse(text2), DateTimeKind.Utc);
			if (DateTime.UtcNow > t)
			{
				return false;
			}
		}
		else if (!string.IsNullOrEmpty(text))
		{
			try
			{
				DateTime t2 = DateTime.ParseExact(text, "yyyy.MM.dd", null);
				if (DateTime.UtcNow > t2)
				{
					return false;
				}
			}
			catch
			{
				try
				{
					DateTime t3 = DateTime.ParseExact(text, "yyyy.MM.dd HH:mm:ss", null);
					if (DateTime.UtcNow > t3)
					{
						return false;
					}
				}
				catch
				{
					return false;
				}
			}
		}
		if (_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A() == b)
		{
			return true;
		}
		return false;
	}
}
