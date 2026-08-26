using System;
using System.Collections.Generic;
using System.IO;

namespace ICSharpCode.SharpZipLib.Zip
{
	internal class ZipManager
	{
		internal static void _0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A(string _0020, string _0020_000A, string _0020_0020)
		{
			_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A _0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A = null;
			try
			{
				_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A = new _0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A(File.OpenRead(_0020));
				if (!string.IsNullOrEmpty(_0020_000A))
				{
					_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A.Password = _0020_000A;
				}
				foreach (_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020_0020_000A item in _0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A)
				{
					try
					{
						if (item.IsFile)
						{
							string name = item.Name;
							byte[] _0020_00202 = new byte[4096];
							Stream inputStream = _0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A.GetInputStream(item);
							string path = Path.Combine(_0020_0020, name);
							string directoryName = Path.GetDirectoryName(path);
							if (directoryName.Length > 0 && !Directory.Exists(directoryName))
							{
								Directory.CreateDirectory(directoryName);
							}
							try
							{
								if (File.Exists(path))
								{
									File.Delete(path);
								}
							}
							catch
							{
							}
							using (FileStream _0020_000A2 = File.Create(path))
							{
								_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020(inputStream, _0020_000A2, _0020_00202);
							}
						}
					}
					catch (Exception ex)
					{
						(item.Name + "\r\n" + ex.Message).LogErrToConsole();
					}
				}
			}
			finally
			{
				if (_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A != null)
				{
					_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A.IsStreamOwner = true;
					_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A.Close();
				}
			}
		}

		internal static void _0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020(string _0020, string _0020_000A)
		{
			FileStream fileStream = File.Create(_0020_000A);
			_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A _0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A = new _0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A(fileStream);
			_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A.SetLevel(3);
			int _0020_0020 = _0020.Length + ((!_0020.EndsWith("\\")) ? 1 : 0);
			_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020(_0020, _0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A, _0020_0020);
			_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A.IsStreamOwner = true;
			_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A.Flush();
			_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A.Close();
			fileStream.Close();
		}

		internal static void _0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020(string _0020, _0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A _0020_000A, int _0020_0020)
		{
			string[] files = Directory.GetFiles(_0020);
			foreach (string obj in files)
			{
				FileInfo fileInfo = new FileInfo(obj);
				_0020_000A.PutNextEntry(new _0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020_0020_000A(_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020_0020_000A.CleanName(obj.Substring(_0020_0020)))
				{
					DateTime = fileInfo.LastWriteTime,
					Size = fileInfo.Length
				});
				byte[] _0020_00202 = new byte[4096];
				using (FileStream _00202 = File.Open(obj, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				{
					_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020(_00202, _0020_000A, _0020_00202);
				}
				_0020_000A.CloseEntry();
			}
			files = Directory.GetDirectories(_0020);
			for (int i = 0; i < files.Length; i++)
			{
				_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020(files[i], _0020_000A, _0020_0020);
			}
		}

		internal static void _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020(Stream _0020, Stream _0020_000A, byte[] _0020_0020)
		{
			int num;
			do
			{
				num = _0020.Read(_0020_0020, 0, _0020_0020.Length);
				_0020_000A.Write(_0020_0020, 0, num);
			}
			while (num > 0);
		}

		internal static byte[] _0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020_000A_000A(List<(string Name, byte[] Content)> files, string _0020 = null)
		{
			if (files == null || files.Count == 0)
			{
				return null;
			}
			try
			{
				MemoryStream memoryStream = new MemoryStream();
				_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A _0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A = new _0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A(memoryStream);
				if (!string.IsNullOrEmpty(_0020))
				{
					_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A.Password = _0020;
				}
				_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A.SetLevel(9);
				foreach (var file in files)
				{
					byte[] array = null;
					string item = file.Name;
					array = file.Content;
					if (array != null)
					{
						_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020_0020_000A _0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020_0020_000A = new _0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020_0020_000A(item);
						_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A.PutNextEntry(_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020_0020_000A);
						_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020_0020_000A.Size = array.Length;
						_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A.Write(array, 0, array.Length);
					}
				}
				_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A.Finish();
				_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A.Close();
				return memoryStream.ToArray();
			}
			catch (Exception)
			{
				return null;
			}
		}

		internal static IEnumerable<(string Name, byte[] Content)> ParseZip(Stream _0020, string _0020_000A = null)
		{
			using (_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A _0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A = new _0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A(_0020))
			{
				if (!string.IsNullOrEmpty(_0020_000A))
				{
					_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A.Password = _0020_000A;
				}
				while (true)
				{
					_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020_0020_000A nextEntry = _0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A.GetNextEntry();
					if (nextEntry == null)
					{
						break;
					}
					if (!nextEntry.IsDirectory)
					{
						long size = nextEntry.Size;
						byte[] array = new byte[size];
						_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A.Read(array, 0, (int)size);
						yield return (nextEntry.Name, array);
					}
				}
			}
		}

		internal static List<string> _0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A(Stream _0020, string _0020_000A = null)
		{
			List<string> list = new List<string>();
			using (_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A _0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A = new _0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A(_0020))
			{
				if (!string.IsNullOrEmpty(_0020_000A))
				{
					_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A.Password = _0020_000A;
				}
				while (true)
				{
					_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020_0020_000A nextEntry = _0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A.GetNextEntry();
					if (nextEntry == null)
					{
						break;
					}
					if (!nextEntry.IsDirectory)
					{
						list.Add(nextEntry.Name);
					}
				}
				return list;
			}
		}

		internal static MemoryStream _0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020(_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020_0020_000A _0020, string _0020_000A)
		{
			using (Stream _0020_000A2 = FileManager.MakeStream(_0020_000A))
			{
				return _0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020(_0020, _0020_000A2);
			}
		}

		internal static MemoryStream _0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020(_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020_0020_000A _0020, Stream _0020_000A, string _0020_0020 = null)
		{
			new List<_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020_0020_000A>();
			using (_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A _0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A = new _0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A(_0020_000A))
			{
				if (!string.IsNullOrEmpty(_0020_0020))
				{
					_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A.Password = _0020_0020;
				}
				int num = 0;
				while (true)
				{
					_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020_0020_000A nextEntry = _0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A.GetNextEntry();
					if (nextEntry == null)
					{
						break;
					}
					if (!nextEntry.IsDirectory && nextEntry.Name == _0020.Name)
					{
						long size = nextEntry.Size;
						size = ((size < 10240) ? size : 10240);
						if (size <= 0)
						{
							size = 1024L;
						}
						byte[] buffer = new byte[size];
						int num2 = _0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A.Read(buffer, 0, (int)size);
						MemoryStream memoryStream = new MemoryStream();
						num++;
						while (num2 > 0)
						{
							memoryStream.Write(buffer, 0, num2);
							num2 = _0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A.Read(buffer, 0, (int)size);
						}
						return memoryStream;
					}
				}
			}
			return null;
		}

		internal static bool _0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A(List<_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020_0020_000A> _0020, string _0020_000A, string _0020_0020)
		{
			using (Stream _0020_000A2 = FileManager.MakeStream(_0020_000A))
			{
				return _0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A(_0020, _0020_000A2, _0020_0020);
			}
		}

		internal static bool _0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A(List<_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020_0020_000A> _0020, Stream _0020_000A, string _0020_0020, string _0020_000A_000A = null)
		{
			new List<_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020_0020_000A>();
			using (_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A _0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A = new _0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A(_0020_000A))
			{
				if (!string.IsNullOrEmpty(_0020_000A_000A))
				{
					_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A.Password = _0020_000A_000A;
				}
				int num = 0;
				while (true)
				{
					_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020_0020_000A nextEntry = _0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A.GetNextEntry();
					if (nextEntry == null)
					{
						break;
					}
					if (!nextEntry.IsDirectory)
					{
						foreach (_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020_0020_000A item in _0020)
						{
							if (nextEntry.Name == item.Name)
							{
								long size = nextEntry.Size;
								size = ((size < 10240) ? size : 10240);
								if (size <= 0)
								{
									size = 1024L;
								}
								byte[] buffer = new byte[size];
								int num2 = _0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A.Read(buffer, 0, (int)size);
								string path = Path.Combine(_0020_0020, item.Name);
								if (!Directory.Exists(Path.GetDirectoryName(path)))
								{
									Directory.CreateDirectory(Path.GetDirectoryName(path));
								}
								using (FileStream fileStream = File.Create(Path.Combine(_0020_0020, item.Name)))
								{
									num++;
									while (num2 > 0)
									{
										fileStream.Write(buffer, 0, num2);
										num2 = _0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A.Read(buffer, 0, (int)size);
									}
								}
								break;
							}
						}
					}
				}
			}
			return false;
		}

		internal static bool _0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_000A_0020(_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020_0020_000A _0020, string _0020_000A, string _0020_0020)
		{
			using (Stream _0020_000A2 = FileManager.MakeStream(_0020_000A))
			{
				return _0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_000A_0020(_0020, _0020_000A2, _0020_0020);
			}
		}

		internal static bool _0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_000A_0020(_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020_0020_000A _0020, Stream _0020_000A, string _0020_0020, string _0020_000A_000A = null)
		{
			new List<_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020_0020_000A>();
			using (_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A _0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A = new _0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A(_0020_000A))
			{
				if (!string.IsNullOrEmpty(_0020_000A_000A))
				{
					_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A.Password = _0020_000A_000A;
				}
				int num = 0;
				while (true)
				{
					_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020_0020_000A nextEntry = _0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A.GetNextEntry();
					if (nextEntry == null)
					{
						break;
					}
					if (!nextEntry.IsDirectory && nextEntry.Name == _0020.Name)
					{
						long size = nextEntry.Size;
						size = ((size < 10240) ? size : 10240);
						if (size <= 0)
						{
							size = 1024L;
						}
						byte[] buffer = new byte[size];
						int num2 = _0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A.Read(buffer, 0, (int)size);
						using (FileStream fileStream = File.Create(_0020_0020))
						{
							num++;
							while (num2 > 0)
							{
								fileStream.Write(buffer, 0, num2);
								num2 = _0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A.Read(buffer, 0, (int)size);
							}
						}
						return true;
					}
				}
			}
			return false;
		}
	}
}
