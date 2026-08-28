using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

internal class FileManager
{
	internal static string _0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020 = Directory.GetFiles(StartupPath, "DevXUnityUnpackerTools.dll").Length.ToString().Replace("0", "").Replace("1", "5");

	internal static string _0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_000A_0020_0020_000A = Directory.GetFiles(StartupPath, "DevX.Cecil.dll").Length.ToString().Replace("0", "").Replace("1", "5");

	internal static string _0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_000A_0020_0020_0020 = "";

	internal static string _0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_000A_000A_000A = Directory.GetFiles(StartupPath, "DevXUnityUnpackerTools.exe").Length.ToString().Replace("0", "").Replace("1", "5");

	internal static string _0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020;

	internal static char[] _0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A = new char[2]
	{
		'\\',
		'/'
	};

	// Anti-tamper canary, defused. The three terms above count files named
	// DevXUnityUnpackerTools.dll / DevX.Cecil.dll / DevXUnityUnpackerTools.exe next to
	// the exe. In a real install NONE of them exist as plain files — Tools and
	// DevX.Cecil ship as encrypted hash-named sidecars — so every term was
	// "0" -> Replace("0","") -> "" and FakePath was ALWAYS the empty string. Every use
	// of it (GetSth, Exists, File.Create, the YAML "%TAG !u!" header) is only correct
	// under that assumption: they concatenate it onto paths.
	//
	// This repo's merged loader chain (ROADMAP P7a/P7b) drops those DLLs on disk as
	// ordinary files, so the terms become "1" -> Replace("1","5") -> "5" and FakePath
	// silently becomes "55". GetSth() appends it to any path containing a directory
	// separator but returns a bare filename untouched, so
	// GetSth(@"assets\...\global-metadata.dat") == "global-metadata.dat55" never equals
	// GetSth("global-metadata.dat") == "global-metadata.dat" — i.e. every
	// FindItemByName(<filename>) misses and whole features (the IL2CPP pipeline among
	// them) skip themselves with no error. Pinned back to the original runtime value.
	internal static string FakePath => string.Empty;

	// The original expression, kept so the canary state is still observable/loggable.
	internal static string FakePathCanary => _0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020 + _0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_000A_0020_0020_000A + _0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_000A_0020_0020_0020 + _0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_000A_000A_000A;

	internal static string StartupPath => Application.StartupPath;

	internal static string _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020_000A_000A_0020_0020 => Process.GetCurrentProcess().MainModule.FileName;

	internal static bool _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A(string _0020)
	{
		if (CrackSettings.DisableFolderOpen || _0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A._0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020 || MainForm._0020_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A || _0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020._0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A())
		{
			return false;
		}
		try
		{
			_0020 = Path.GetFullPath(_0020);
			Process.Start("explorer.exe", $"/select,\"{_0020}\"");
		}
		catch
		{
		}
		return true;
	}

	internal static string _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A(string _0020)
	{
		if (string.IsNullOrEmpty(_0020))
		{
			return string.Empty;
		}
		int num = _0020.LastIndexOfAny(_0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A);
		if (num < 0)
		{
			num = 0;
		}
		int num2 = _0020.LastIndexOf(".");
		if (num2 > num)
		{
			return _0020.Substring(num2);
		}
		return string.Empty;
	}

	internal static string GetSth(string _0020)
	{
		if (string.IsNullOrEmpty(_0020))
		{
			return string.Empty;
		}
		int num = _0020.LastIndexOfAny(_0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A);
		if (num >= 0)
		{
			return _0020.Substring(num + 1) + FakePath;
		}
		return _0020;
	}

	internal static string _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020(string _0020)
	{
		if (_0020 == null)
		{
			return null;
		}
		if (string.IsNullOrEmpty(_0020))
		{
			return string.Empty;
		}
		int num = _0020.LastIndexOfAny(_0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A);
		if (num >= 0)
		{
			return _0020.Substring(0, num) + FakePath;
		}
		return null;
	}

	internal static string _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_0020_000A(string _0020)
	{
		if (string.IsNullOrEmpty(_0020))
		{
			return string.Empty;
		}
		string sth = GetSth(_0020);
		int num = sth.LastIndexOf('.');
		if (num > 0)
		{
			return sth.Substring(0, num);
		}
		return sth;
	}

	internal static string _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_0020_0020(string _0020)
	{
		if (string.IsNullOrEmpty(_0020))
		{
			return string.Empty;
		}
		int num = _0020.LastIndexOfAny(_0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A);
		if (num < 0)
		{
			num = 0;
		}
		if (num + 1 >= _0020.Length)
		{
			return _0020;
		}
		int num2 = _0020.LastIndexOf(".", num);
		if (num2 <= 0)
		{
			return _0020;
		}
		return _0020.Substring(0, num2);
	}

	internal static string _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A(string _0020, string _0020_000A)
	{
		if (string.IsNullOrEmpty(_0020))
		{
			return string.Empty;
		}
		string text = _0020;
		int num = text.LastIndexOfAny(_0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A);
		if (num < 0)
		{
			num = 0;
		}
		int num2 = text.LastIndexOf('.');
		if (num2 >= num)
		{
			text = text.Substring(0, num2);
		}
		return text + _0020_000A;
	}

	internal static bool Exists(string _0020)
	{
		if (string.IsNullOrEmpty(_0020))
		{
			return false;
		}
		try
		{
			if (File.Exists(_0020))
			{
				return true;
			}
			return false;
		}
		catch (Exception _00202)
		{
			ConsoleManager.WriteEx45(_00202);
		}
		return false;
	}

	internal static Stream MakeStream(string _0020, bool _0020_000A = false)
	{
		return _0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020._0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020(_0020 + FakePath, _0020_000A);
	}

	internal static Stream _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A(string _0020)
	{
		if (_0020 == null)
		{
			return null;
		}
		string directoryName = Path.GetDirectoryName(_0020);
		if (!Directory.Exists(directoryName))
		{
			Directory.CreateDirectory(directoryName);
		}
		if (Exists(_0020))
		{
			File.Delete(_0020);
		}
		return File.OpenWrite(_0020);
	}

	internal static Stream _0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020(string _0020)
	{
		if (_0020 == null)
		{
			return null;
		}
		string directoryName = Path.GetDirectoryName(_0020);
		if (!Directory.Exists(directoryName))
		{
			Directory.CreateDirectory(directoryName);
		}
		return File.Open(_0020, FileMode.OpenOrCreate, FileAccess.ReadWrite);
	}

	internal static byte[] _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020(string _0020, int _0020_000A)
	{
		try
		{
			Stream stream = MakeStream(_0020);
			try
			{
				if (stream.Length == 0L)
				{
					return null;
				}
				if (_0020_000A <= 0 || stream.Length < _0020_000A)
				{
					_0020_000A = (int)stream.Length;
				}
				byte[] array = new byte[_0020_000A];
				stream.Read(array, 0, array.Length);
				return array;
			}
			finally
			{
				stream.Close();
			}
		}
		catch (Exception ex)
		{
			ConsoleManager.LogExeption("ReadFilePreBuffer: " + _0020 + "\n" + ex);
			return null;
		}
	}

	internal static string _0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A(string _0020, int _0020_000A)
	{
		try
		{
			byte[] array = _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020(_0020, _0020_000A);
			if (array == null)
			{
				return null;
			}
			if (array.Length == 0)
			{
				return string.Empty;
			}
			return Encoding.UTF8.GetString(array);
		}
		catch (Exception ex)
		{
			ConsoleManager.LogExeption("ReadFilePreText: " + _0020 + "\n" + ex);
			return null;
		}
	}

	internal static bool _0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020(string _0020, int _0020_000A, string _0020_0020)
	{
		try
		{
			string text = _0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A(_0020, _0020_000A);
			if (string.IsNullOrEmpty(text))
			{
				return false;
			}
			if (text.Contains(_0020_0020))
			{
				return true;
			}
			return false;
		}
		catch (Exception ex)
		{
			ConsoleManager.LogExeption("FileContainsText: " + _0020 + "\n" + ex);
			return false;
		}
	}

	internal static bool _0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A(string _0020, Stream _0020_000A, int? _0020_0020 = default(int?), int _0020_000A_000A = -1)
	{
		if (_0020 == null || _0020_000A == null)
		{
			return false;
		}
		using (FileStream fileStream = File.Create(FakePath + _0020))
		{
			byte[] array = new byte[10240];
			if (_0020_0020.HasValue)
			{
				if (_0020_000A.CanSeek)
				{
					_0020_000A.Seek(_0020_0020.Value, SeekOrigin.Begin);
				}
			}
			else
			{
				_0020_0020 = (int)_0020_000A.Position;
			}
			if (_0020_000A_000A < 0)
			{
				_0020_000A_000A = (int)_0020_000A.Length - (_0020_0020.HasValue ? _0020_0020.Value : 0);
			}
			int num;
			for (int i = 0; _0020_0020 == -1 || i < _0020_000A_000A; i += num)
			{
				num = _0020_000A_000A - i;
				if (num == 0)
				{
					break;
				}
				if (num > array.Length)
				{
					num = array.Length;
				}
				int num2 = _0020_000A.Read(array, 0, num);
				if (num2 <= 0)
				{
					break;
				}
				fileStream.Write(array, 0, num2);
			}
			fileStream.Flush();
			fileStream.Close();
		}
		return true;
	}

	internal static void Copy(Stream _0020, Stream _0020_000A, byte[] _0020_0020 = null)
	{
		if (_0020_0020 == null)
		{
			_0020_0020 = new byte[4096];
		}
		int num;
		do
		{
			num = _0020.Read(_0020_0020, 0, _0020_0020.Length);
			_0020_000A.Write(_0020_0020, 0, num);
		}
		while (num > 0);
	}

	internal static string _0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020(string _0020, string _0020_000A = null, string _0020_0020 = null, string _0020_000A_000A = null)
	{
		if (string.IsNullOrEmpty(_0020))
		{
			return null;
		}
		string text = null;
		try
		{
			text = _0020 + FakePath;
			if (!Directory.Exists(text) && Directory.CreateDirectory(text) == null)
			{
				return null;
			}
		}
		catch
		{
		}
		try
		{
			if (!string.IsNullOrEmpty(_0020_000A))
			{
				text = Path.Combine(text, _0020_000A.TrimStart('/', '\\'));
				if (!Directory.Exists(text) && Directory.CreateDirectory(text) == null)
				{
					return null;
				}
			}
		}
		catch
		{
		}
		try
		{
			if (!string.IsNullOrEmpty(_0020_0020))
			{
				text = Path.Combine(text, _0020_0020.TrimStart('/', '\\'));
				if (!Directory.Exists(text) && Directory.CreateDirectory(text) == null)
				{
					return null;
				}
			}
		}
		catch
		{
		}
		try
		{
			if (string.IsNullOrEmpty(_0020_000A_000A))
			{
				return text;
			}
			text = Path.Combine(text, _0020_000A_000A.TrimStart('/', '\\'));
			if (Directory.Exists(text))
			{
				return text;
			}
			if (Directory.CreateDirectory(text) == null)
			{
				return null;
			}
			return text;
		}
		catch
		{
			return text;
		}
	}

	internal static string FormatPath(string _0020, params string[] child_path)
	{
		if (string.IsNullOrEmpty(_0020))
		{
			return null;
		}
		string text = _0020;
		foreach (string text2 in child_path)
		{
			if (!string.IsNullOrEmpty(text2))
			{
				text = Path.Combine(text, text2.TrimStart('/', '\\'));
			}
		}
		return text;
	}

	internal static string _0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020(string _0020)
	{
		if (string.IsNullOrEmpty(_0020))
		{
			return "empty";
		}
		string text = "";
		char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
		char[] array = _0020.ToCharArray();
		foreach (char c in array)
		{
			char c2 = c;
			if (c == '\\')
			{
				c2 = '_';
			}
			if (c == '/')
			{
				c2 = '_';
			}
			if (c == ';')
			{
				c2 = '_';
			}
			if (c == ':')
			{
				c2 = '_';
			}
			char[] array2 = invalidFileNameChars;
			foreach (char c3 in array2)
			{
				if (c == c3)
				{
					c2 = '_';
				}
			}
			text += c2.ToString();
		}
		return text;
	}

	internal static string _0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A(string _0020, string _0020_000A, string _0020_0020)
	{
		_0020_000A = _0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020(_0020_000A);
		if (string.IsNullOrEmpty(_0020_0020))
		{
			_0020_0020 = _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A(_0020_000A);
			_0020_000A = _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_0020_000A(_0020_000A);
		}
		else
		{
			_0020_000A = _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_0020_000A(_0020_000A);
		}
		string text = Path.Combine(_0020, _0020_000A) + _0020_0020;
		int num = 0;
		while (File.Exists(text))
		{
			num++;
			text = Path.Combine(_0020, _0020_000A) + "_d" + num + _0020_0020;
		}
		return text;
	}

	internal static void Write(string _0020, byte[] _0020_000A)
	{
		if (_0020_000A != null)
		{
			using (Stream stream = _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A(_0020))
			{
				stream.Write(_0020_000A, 0, _0020_000A.Length);
			}
		}
	}

	internal static void Write(string _0020, string _0020_000A)
	{
		if (_0020_000A != null)
		{
			Write(_0020, Encoding.UTF8.GetBytes(_0020_000A));
		}
	}

	internal static void _0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020(string _0020)
	{
		try
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(_0020);
			FileInfo[] files = directoryInfo.GetFiles();
			foreach (FileInfo fileInfo in files)
			{
				try
				{
					fileInfo.Delete();
				}
				catch
				{
				}
			}
			DirectoryInfo[] directories = directoryInfo.GetDirectories();
			foreach (DirectoryInfo directoryInfo2 in directories)
			{
				_0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020(directoryInfo2.FullName);
				try
				{
					directoryInfo2.Delete(recursive: true);
				}
				catch
				{
				}
			}
			directoryInfo.Delete(recursive: true);
		}
		catch
		{
		}
	}

	internal static void _0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A(string _0020, string _0020_000A)
	{
		if (string.IsNullOrEmpty(_0020) || string.IsNullOrEmpty(_0020_000A))
		{
			return;
		}
		_0020 = Path.GetFullPath(_0020);
		if (!Directory.Exists(_0020))
		{
			return;
		}
		if (!Directory.Exists(_0020_000A))
		{
			Directory.CreateDirectory(_0020_000A);
		}
		string[] files = Directory.GetFiles(_0020, "*.*", SearchOption.AllDirectories);
		foreach (string text in files)
		{
			byte[] _0020_000A2 = File.ReadAllBytes(text);
			string _00202 = FormatPath(_0020_000A, text.Substring(_0020.Length).TrimStart('/', '\\'));
			string path = _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020(_00202);
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			Write(_00202, _0020_000A2);
		}
	}

	internal static long _0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020(byte[] _0020, Stream _0020_000A, long _0020_0020 = 0L)
	{
		if (_0020_0020 >= _0020_000A.Length)
		{
			return -1L;
		}
		_0020_000A.Position = _0020_0020;
		int num = _0020.Length * 100;
		byte[] _0020_000A_000A = new byte[num];
		for (long num2 = _0020_0020; num2 < _0020_000A.Length; num2 += num - _0020.Length)
		{
			int num3 = FormatUtils._0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020(_0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A(_0020_000A, num2, num, _0020_000A_000A), _0020);
			if (num3 >= 0)
			{
				return num2 + num3;
			}
		}
		return -1L;
	}

	internal static byte[] _0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A(Stream _0020, long _0020_000A, long _0020_0020, byte[] _0020_000A_000A)
	{
		if (_0020_000A_000A == null || _0020_000A_000A.Length < _0020_0020)
		{
			_0020_000A_000A = new byte[_0020_0020];
		}
		long position = _0020.Position;
		_0020.Position = _0020_000A;
		_0020.Read(_0020_000A_000A, 0, (int)_0020_0020);
		_0020.Position = position;
		return _0020_000A_000A;
	}
}
