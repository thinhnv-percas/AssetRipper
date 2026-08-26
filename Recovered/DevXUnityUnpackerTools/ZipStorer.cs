using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Unity.IO.Compression;

public class ZipStorer : IDisposable
{
	public enum Compression : ushort
	{
		Store = 0,
		Deflate = 8
	}

	public struct ZipFileEntry
	{
		public Compression Method;

		public string FilenameInZip;

		public uint FileSize;

		public uint CompressedSize;

		public uint HeaderOffset;

		public uint FileOffset;

		public uint HeaderSize;

		public uint Crc32;

		public DateTime ModifyTime;

		public string Comment;

		public bool EncodeUTF8;

		public override string ToString()
		{
			return FilenameInZip;
		}
	}

	public bool EncodeUTF8;

	public bool ForceDeflating;

	internal List<ZipFileEntry> _0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020 = new List<ZipFileEntry>();

	internal string _0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A;

	internal Stream _0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020;

	internal string _0020_000A_000A_0020_000A_0020_000A_000A_000A_0020_0020_0020_0020_0020_0020 = "";

	internal byte[] _0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A_000A;

	internal ushort _0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A_0020;

	internal FileAccess _0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_000A;

	internal bool _0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020;

	internal static uint[] _0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A;

	internal static Encoding _0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020;

	static ZipStorer()
	{
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A = null;
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020 = Encoding.GetEncoding(437);
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A = new uint[256];
		for (int i = 0; i < _0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A.Length; i++)
		{
			uint num = (uint)i;
			for (int j = 0; j < 8; j++)
			{
				num = (uint)(((num & 1) == 0) ? ((int)(num >> 1)) : (-306674912 ^ (int)(num >> 1)));
			}
			_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A[i] = num;
		}
	}

	public static ZipStorer Create(string _filename, string _comment)
	{
		ZipStorer zipStorer = Create(new FileStream(_filename, FileMode.Create, FileAccess.ReadWrite), _comment);
		zipStorer._0020_000A_000A_0020_000A_0020_000A_000A_000A_0020_0020_0020_0020_0020_0020 = _comment;
		zipStorer._0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A = _filename;
		return zipStorer;
	}

	public static ZipStorer Create(Stream _stream, string _comment, bool _leaveOpen = false)
	{
		return new ZipStorer
		{
			_0020_000A_000A_0020_000A_0020_000A_000A_000A_0020_0020_0020_0020_0020_0020 = _comment,
			_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020 = _stream,
			_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_000A = FileAccess.Write,
			_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020 = _leaveOpen
		};
	}

	public static ZipStorer Open(string _filename, FileAccess _access)
	{
		ZipStorer zipStorer = Open(new FileStream(_filename, FileMode.Open, (_access == FileAccess.Read) ? FileAccess.Read : FileAccess.ReadWrite), _access);
		zipStorer._0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A = _filename;
		return zipStorer;
	}

	public static ZipStorer Open(Stream _stream, FileAccess _access, bool _leaveOpen = false)
	{
		if (!_stream.CanSeek && _access != FileAccess.Read)
		{
			throw new InvalidOperationException("Stream cannot seek");
		}
		ZipStorer zipStorer = new ZipStorer();
		zipStorer._0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020 = _stream;
		zipStorer._0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_000A = _access;
		zipStorer._0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020 = _leaveOpen;
		if (zipStorer._0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020())
		{
			return zipStorer;
		}
		throw new System.IO.InvalidDataException();
	}

	public void AddFile(Compression _method, string _pathname, string _filenameInZip, string _comment)
	{
		if (_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_000A == FileAccess.Read)
		{
			throw new InvalidOperationException("Writing is not alowed");
		}
		using (FileStream source = new FileStream(_pathname, FileMode.Open, FileAccess.Read))
		{
			AddStream(_method, _filenameInZip, source, File.GetLastWriteTime(_pathname), _comment);
		}
	}

	public void AddStream(Compression _method, string _filenameInZip, Stream _source, DateTime _modTime, string _comment)
	{
		if (_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_000A == FileAccess.Read)
		{
			throw new InvalidOperationException("Writing is not alowed");
		}
		ZipFileEntry item = default(ZipFileEntry);
		item.Method = _method;
		item.EncodeUTF8 = EncodeUTF8;
		item.FilenameInZip = _0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_000A_0020_000A(_filenameInZip);
		item.Comment = (_comment ?? "");
		item.Crc32 = 0u;
		item.HeaderOffset = (uint)_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Position;
		item.ModifyTime = _modTime;
		_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_0020(ref item);
		item.FileOffset = (uint)_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Position;
		_0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A(ref item, _source);
		_source.Close();
		_0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_0020(ref item);
		_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020.Add(item);
	}

	public void Close()
	{
		if (_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_000A != FileAccess.Read)
		{
			uint _0020_000A = (uint)_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Position;
			uint num = 0u;
			if (_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A_000A != null)
			{
				_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Write(_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A_000A, 0, _0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A_000A.Length);
			}
			for (int i = 0; i < _0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020.Count; i++)
			{
				long position = _0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Position;
				_0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A(_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020[i]);
				num = (uint)((int)num + (int)(_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Position - position));
			}
			if (_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A_000A != null)
			{
				_0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020((uint)((int)num + _0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A_000A.Length), _0020_000A);
			}
			else
			{
				_0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020(num, _0020_000A);
			}
		}
		if (_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020 != null && !_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020)
		{
			_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Flush();
			_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Dispose();
			_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020 = null;
		}
	}

	public List<ZipFileEntry> ReadCentralDir()
	{
		if (_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A_000A == null)
		{
			throw new InvalidOperationException("Central directory currently does not exist");
		}
		List<ZipFileEntry> list = new List<ZipFileEntry>();
		ushort num2;
		ushort num3;
		ushort num4;
		for (int i = 0; i < _0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A_000A.Length && BitConverter.ToUInt32(_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A_000A, i) == 33639248; i += 46 + num2 + num3 + num4)
		{
			bool num = (BitConverter.ToUInt16(_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A_000A, i + 8) & 0x800) != 0;
			ushort method = BitConverter.ToUInt16(_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A_000A, i + 10);
			uint _0020 = BitConverter.ToUInt32(_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A_000A, i + 12);
			uint crc = BitConverter.ToUInt32(_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A_000A, i + 16);
			uint compressedSize = BitConverter.ToUInt32(_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A_000A, i + 20);
			uint fileSize = BitConverter.ToUInt32(_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A_000A, i + 24);
			num2 = BitConverter.ToUInt16(_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A_000A, i + 28);
			num3 = BitConverter.ToUInt16(_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A_000A, i + 30);
			num4 = BitConverter.ToUInt16(_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A_000A, i + 32);
			uint num5 = BitConverter.ToUInt32(_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A_000A, i + 42);
			uint headerSize = (uint)(46 + num2 + num3 + num4);
			Encoding encoding = num ? Encoding.UTF8 : _0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020;
			ZipFileEntry item = default(ZipFileEntry);
			item.Method = (Compression)method;
			item.FilenameInZip = encoding.GetString(_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A_000A, i + 46, num2);
			item.FileOffset = _0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020(num5);
			item.FileSize = fileSize;
			item.CompressedSize = compressedSize;
			item.HeaderOffset = num5;
			item.HeaderSize = headerSize;
			item.Crc32 = crc;
			item.ModifyTime = (_0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A(_0020) ?? DateTime.Now);
			if (num4 > 0)
			{
				item.Comment = encoding.GetString(_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A_000A, i + 46 + num2 + num3, num4);
			}
			list.Add(item);
		}
		return list;
	}

	public bool ExtractFile(ZipFileEntry _zfe, string _filename)
	{
		string path = FileManager._0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020(_filename);
		if (!Directory.Exists(path))
		{
			Directory.CreateDirectory(path);
		}
		if (Directory.Exists(_filename))
		{
			return true;
		}
		bool flag;
		using (FileStream stream = new FileStream(_filename, FileMode.Create, FileAccess.Write))
		{
			flag = ExtractFile(_zfe, stream);
		}
		if (flag)
		{
			File.SetCreationTime(_filename, _zfe.ModifyTime);
			File.SetLastWriteTime(_filename, _zfe.ModifyTime);
		}
		return flag;
	}

	public bool ExtractFile(ZipFileEntry _zfe, Stream _stream)
	{
		if (!_stream.CanWrite)
		{
			throw new InvalidOperationException("Stream cannot be written");
		}
		byte[] array = new byte[4];
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Seek(_zfe.HeaderOffset, SeekOrigin.Begin);
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Read(array, 0, 4);
		if (BitConverter.ToUInt32(array, 0) != 67324752)
		{
			return false;
		}
		Stream stream;
		if (_zfe.Method == Compression.Store)
		{
			stream = _0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020;
		}
		else
		{
			if (_zfe.Method != Compression.Deflate)
			{
				return false;
			}
			stream = new DeflateStream(_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020, CompressionMode.Decompress, leaveOpen: true);
		}
		byte[] array2 = new byte[16384];
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Seek(_zfe.FileOffset, SeekOrigin.Begin);
		int num2;
		for (uint num = _zfe.FileSize; num != 0; num = (uint)((int)num - num2))
		{
			num2 = stream.Read(array2, 0, (int)Math.Min(num, array2.Length));
			_stream.Write(array2, 0, num2);
		}
		_stream.Flush();
		if (_zfe.Method == Compression.Deflate)
		{
			stream.Dispose();
		}
		return true;
	}

	public bool ExtractFile(ZipFileEntry _zfe, out byte[] _file)
	{
		using (MemoryStream memoryStream = new MemoryStream())
		{
			if (ExtractFile(_zfe, memoryStream))
			{
				_file = memoryStream.ToArray();
				return true;
			}
			_file = null;
			return false;
		}
	}

	public static bool RemoveEntries(ref ZipStorer _zip, List<ZipFileEntry> _zfes)
	{
		if (!(_zip._0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020 is FileStream))
		{
			throw new InvalidOperationException("RemoveEntries is allowed just over streams of type FileStream");
		}
		List<ZipFileEntry> list = _zip.ReadCentralDir();
		string tempFileName = Path.GetTempFileName();
		string tempFileName2 = Path.GetTempFileName();
		try
		{
			ZipStorer zipStorer = Create(tempFileName, string.Empty);
			foreach (ZipFileEntry item in list)
			{
				if (!_zfes.Contains(item) && _zip.ExtractFile(item, tempFileName2))
				{
					zipStorer.AddFile(item.Method, tempFileName2, item.FilenameInZip, item.Comment);
				}
			}
			_zip.Close();
			zipStorer.Close();
			File.Delete(_zip._0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A);
			File.Move(tempFileName, _zip._0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A);
			_zip = Open(_zip._0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A, _zip._0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_000A);
		}
		catch
		{
			return false;
		}
		finally
		{
			if (File.Exists(tempFileName))
			{
				File.Delete(tempFileName);
			}
			if (File.Exists(tempFileName2))
			{
				File.Delete(tempFileName2);
			}
		}
		return true;
	}

	internal uint _0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020(uint _0020)
	{
		byte[] array = new byte[2];
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Seek(_0020 + 26, SeekOrigin.Begin);
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Read(array, 0, 2);
		ushort num = BitConverter.ToUInt16(array, 0);
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Read(array, 0, 2);
		ushort num2 = BitConverter.ToUInt16(array, 0);
		return (uint)(30 + num + num2 + _0020);
	}

	internal void _0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_0020(ref ZipFileEntry _0020)
	{
		long position = _0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Position;
		byte[] bytes = (_0020.EncodeUTF8 ? Encoding.UTF8 : _0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020).GetBytes(_0020.FilenameInZip);
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Write(new byte[6]
		{
			80,
			75,
			3,
			4,
			20,
			0
		}, 0, 6);
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Write(BitConverter.GetBytes((ushort)(_0020.EncodeUTF8 ? 2048 : 0)), 0, 2);
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Write(BitConverter.GetBytes((ushort)_0020.Method), 0, 2);
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Write(BitConverter.GetBytes(_0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020(_0020.ModifyTime)), 0, 4);
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Write(new byte[12], 0, 12);
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Write(BitConverter.GetBytes((ushort)bytes.Length), 0, 2);
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Write(BitConverter.GetBytes((ushort)0), 0, 2);
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Write(bytes, 0, bytes.Length);
		_0020.HeaderSize = (uint)(_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Position - position);
	}

	internal void _0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A(ZipFileEntry _0020)
	{
		Encoding obj = _0020.EncodeUTF8 ? Encoding.UTF8 : _0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020;
		byte[] bytes = obj.GetBytes(_0020.FilenameInZip);
		byte[] bytes2 = obj.GetBytes(_0020.Comment);
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Write(new byte[8]
		{
			80,
			75,
			1,
			2,
			23,
			11,
			20,
			0
		}, 0, 8);
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Write(BitConverter.GetBytes((ushort)(_0020.EncodeUTF8 ? 2048 : 0)), 0, 2);
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Write(BitConverter.GetBytes((ushort)_0020.Method), 0, 2);
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Write(BitConverter.GetBytes(_0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020(_0020.ModifyTime)), 0, 4);
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Write(BitConverter.GetBytes(_0020.Crc32), 0, 4);
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Write(BitConverter.GetBytes(_0020.CompressedSize), 0, 4);
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Write(BitConverter.GetBytes(_0020.FileSize), 0, 4);
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Write(BitConverter.GetBytes((ushort)bytes.Length), 0, 2);
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Write(BitConverter.GetBytes((ushort)0), 0, 2);
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Write(BitConverter.GetBytes((ushort)bytes2.Length), 0, 2);
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Write(BitConverter.GetBytes((ushort)0), 0, 2);
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Write(BitConverter.GetBytes((ushort)0), 0, 2);
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Write(BitConverter.GetBytes((ushort)0), 0, 2);
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Write(BitConverter.GetBytes((ushort)33024), 0, 2);
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Write(BitConverter.GetBytes(_0020.HeaderOffset), 0, 4);
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Write(bytes, 0, bytes.Length);
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Write(bytes2, 0, bytes2.Length);
	}

	internal void _0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020(uint _0020, uint _0020_000A)
	{
		byte[] bytes = (EncodeUTF8 ? Encoding.UTF8 : _0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020).GetBytes(_0020_000A_000A_0020_000A_0020_000A_000A_000A_0020_0020_0020_0020_0020_0020);
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Write(new byte[8]
		{
			80,
			75,
			5,
			6,
			0,
			0,
			0,
			0
		}, 0, 8);
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Write(BitConverter.GetBytes((ushort)_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020.Count + _0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A_0020), 0, 2);
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Write(BitConverter.GetBytes((ushort)_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020.Count + _0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A_0020), 0, 2);
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Write(BitConverter.GetBytes(_0020), 0, 4);
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Write(BitConverter.GetBytes(_0020_000A), 0, 4);
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Write(BitConverter.GetBytes((ushort)bytes.Length), 0, 2);
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Write(bytes, 0, bytes.Length);
	}

	internal void _0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A(ref ZipFileEntry _0020, Stream _0020_000A)
	{
		byte[] array = new byte[16384];
		uint num = 0u;
		long position = _0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Position;
		long position2 = _0020_000A.CanSeek ? _0020_000A.Position : 0;
		Stream stream = (_0020.Method != 0) ? new DeflateStream(_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020, CompressionMode.Compress, leaveOpen: true) : _0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020;
		_0020.Crc32 = uint.MaxValue;
		int num2;
		do
		{
			num2 = _0020_000A.Read(array, 0, array.Length);
			num = (uint)((int)num + num2);
			if (num2 > 0)
			{
				stream.Write(array, 0, num2);
				for (uint num3 = 0u; num3 < num2; num3++)
				{
					_0020.Crc32 = (_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A[(_0020.Crc32 ^ array[num3]) & 0xFF] ^ (_0020.Crc32 >> 8));
				}
			}
		}
		while (num2 > 0);
		stream.Flush();
		if (_0020.Method == Compression.Deflate)
		{
			stream.Dispose();
		}
		_0020.Crc32 ^= uint.MaxValue;
		_0020.FileSize = num;
		_0020.CompressedSize = (uint)(_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Position - position);
		if (_0020.Method == Compression.Deflate && !ForceDeflating && _0020_000A.CanSeek && _0020.CompressedSize > _0020.FileSize)
		{
			_0020.Method = Compression.Store;
			_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Position = position;
			_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.SetLength(position);
			_0020_000A.Position = position2;
			_0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A(ref _0020, _0020_000A);
		}
	}

	internal uint _0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020(DateTime _0020)
	{
		return (uint)((_0020.Second / 2) | (_0020.Minute << 5) | (_0020.Hour << 11) | (_0020.Day << 16) | (_0020.Month << 21) | (_0020.Year - 1980 << 25));
	}

	internal DateTime? _0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A(uint _0020)
	{
		int year = (int)((_0020 >> 25) + 1980);
		int num = (int)((_0020 >> 21) & 0xF);
		int num2 = (int)((_0020 >> 16) & 0x1F);
		int hour = (int)((_0020 >> 11) & 0x1F);
		int minute = (int)((_0020 >> 5) & 0x3F);
		int second = (int)((_0020 & 0x1F) * 2);
		if (num == 0 || num2 == 0)
		{
			return null;
		}
		return new DateTime(year, num, num2, hour, minute, second);
	}

	internal void _0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_0020(ref ZipFileEntry _0020)
	{
		long position = _0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Position;
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Position = _0020.HeaderOffset + 8;
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Write(BitConverter.GetBytes((ushort)_0020.Method), 0, 2);
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Position = _0020.HeaderOffset + 14;
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Write(BitConverter.GetBytes(_0020.Crc32), 0, 4);
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Write(BitConverter.GetBytes(_0020.CompressedSize), 0, 4);
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Write(BitConverter.GetBytes(_0020.FileSize), 0, 4);
		_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Position = position;
	}

	internal string _0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_000A_0020_000A(string _0020)
	{
		string text = _0020.Replace('\\', '/');
		int num = text.IndexOf(':');
		if (num >= 0)
		{
			text = text.Remove(0, num + 1);
		}
		return text.Trim('/');
	}

	internal bool _0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020()
	{
		if (_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Length < 22)
		{
			return false;
		}
		try
		{
			_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Seek(-17L, SeekOrigin.End);
			BinaryReader binaryReader = new BinaryReader(_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020);
			do
			{
				_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Seek(-5L, SeekOrigin.Current);
				if (binaryReader.ReadUInt32() == 101010256)
				{
					_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Seek(6L, SeekOrigin.Current);
					ushort num = binaryReader.ReadUInt16();
					int num2 = binaryReader.ReadInt32();
					uint num3 = binaryReader.ReadUInt32();
					ushort num4 = binaryReader.ReadUInt16();
					if (_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Position + num4 != _0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Length)
					{
						return false;
					}
					_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A_0020 = num;
					_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A_000A = new byte[num2];
					_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Seek(num3, SeekOrigin.Begin);
					_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Read(_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A_000A, 0, num2);
					_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Seek(num3, SeekOrigin.Begin);
					return true;
				}
			}
			while (_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020.Position > 0);
		}
		catch
		{
		}
		return false;
	}

	public void Dispose()
	{
		Close();
	}
}
