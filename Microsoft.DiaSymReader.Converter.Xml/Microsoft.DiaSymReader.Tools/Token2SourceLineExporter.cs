using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace Microsoft.DiaSymReader.Tools;

internal class Token2SourceLineExporter
{
	private class PdbSource
	{
		internal readonly string name;

		internal Guid doctype;

		internal Guid language;

		internal Guid vendor;

		internal PdbSource(string name, Guid doctype, Guid language, Guid vendor)
		{
			this.name = name;
			this.doctype = doctype;
			this.language = language;
			this.vendor = vendor;
		}
	}

	private class PdbTokenLine
	{
		internal readonly uint token;

		internal readonly uint file_id;

		internal readonly uint line;

		internal readonly uint column;

		internal readonly uint endLine;

		internal readonly uint endColumn;

		internal PdbSource sourceFile;

		internal PdbTokenLine nextLine;

		internal PdbTokenLine(uint token, uint file_id, uint line, uint column, uint endLine, uint endColumn)
		{
			this.token = token;
			this.file_id = file_id;
			this.line = line;
			this.column = column;
			this.endLine = endLine;
			this.endColumn = endColumn;
		}
	}

	private class BitAccess
	{
		private byte[] _buffer;

		private int _offset;

		internal byte[] Buffer => _buffer;

		internal int Position
		{
			get
			{
				return _offset;
			}
			set
			{
				_offset = value;
			}
		}

		internal BitAccess(int capacity)
		{
			_buffer = new byte[capacity];
		}

		internal void FillBuffer(Stream stream, int capacity)
		{
			MinCapacity(capacity);
			stream.Read(_buffer, 0, capacity);
			_offset = 0;
		}

		internal void Append(Stream stream, int count)
		{
			int num = _offset + count;
			if (_buffer.Length < num)
			{
				byte[] array = new byte[num];
				Array.Copy(_buffer, array, _buffer.Length);
				_buffer = array;
			}
			stream.Read(_buffer, _offset, count);
			_offset += count;
		}

		internal void MinCapacity(int capacity)
		{
			if (_buffer.Length < capacity)
			{
				_buffer = new byte[capacity];
			}
			_offset = 0;
		}

		internal void Align(int alignment)
		{
			while (_offset % alignment != 0)
			{
				_offset++;
			}
		}

		internal void ReadInt16(out short value)
		{
			value = (short)((_buffer[_offset] & 0xFF) | (_buffer[_offset + 1] << 8));
			_offset += 2;
		}

		internal void ReadInt8(out sbyte value)
		{
			value = (sbyte)_buffer[_offset];
			_offset++;
		}

		internal void ReadInt32(out int value)
		{
			value = (_buffer[_offset] & 0xFF) | (_buffer[_offset + 1] << 8) | (_buffer[_offset + 2] << 16) | (_buffer[_offset + 3] << 24);
			_offset += 4;
		}

		internal void ReadInt64(out long value)
		{
			value = (long)(((ulong)_buffer[_offset] & 0xFFuL) | ((ulong)_buffer[_offset + 1] << 8) | ((ulong)_buffer[_offset + 2] << 16) | ((ulong)_buffer[_offset + 3] << 24) | ((ulong)_buffer[_offset + 4] << 32) | ((ulong)_buffer[_offset + 5] << 40) | ((ulong)_buffer[_offset + 6] << 48) | ((ulong)_buffer[_offset + 7] << 56));
			_offset += 8;
		}

		internal void ReadUInt16(out ushort value)
		{
			value = (ushort)((_buffer[_offset] & 0xFF) | (_buffer[_offset + 1] << 8));
			_offset += 2;
		}

		internal void ReadUInt8(out byte value)
		{
			value = (byte)(_buffer[_offset] & 0xFF);
			_offset++;
		}

		internal void ReadUInt32(out uint value)
		{
			value = (uint)((_buffer[_offset] & 0xFF) | (_buffer[_offset + 1] << 8) | (_buffer[_offset + 2] << 16) | (_buffer[_offset + 3] << 24));
			_offset += 4;
		}

		internal void ReadUInt64(out ulong value)
		{
			value = ((ulong)_buffer[_offset] & 0xFFuL) | ((ulong)_buffer[_offset + 1] << 8) | ((ulong)_buffer[_offset + 2] << 16) | ((ulong)_buffer[_offset + 3] << 24) | ((ulong)_buffer[_offset + 4] << 32) | ((ulong)_buffer[_offset + 5] << 40) | ((ulong)_buffer[_offset + 6] << 48) | ((ulong)_buffer[_offset + 7] << 56);
			_offset += 8;
		}

		internal void ReadInt32(int[] values)
		{
			for (int i = 0; i < values.Length; i++)
			{
				ReadInt32(out values[i]);
			}
		}

		internal void ReadUInt32(uint[] values)
		{
			for (int i = 0; i < values.Length; i++)
			{
				ReadUInt32(out values[i]);
			}
		}

		internal void ReadBytes(byte[] bytes)
		{
			for (int i = 0; i < bytes.Length; i++)
			{
				bytes[i] = _buffer[_offset++];
			}
		}

		internal float ReadFloat()
		{
			float result = BitConverter.ToSingle(_buffer, _offset);
			_offset += 4;
			return result;
		}

		internal double ReadDouble()
		{
			double result = BitConverter.ToDouble(_buffer, _offset);
			_offset += 8;
			return result;
		}

		internal decimal ReadDecimal()
		{
			int[] array = new int[4];
			ReadInt32(array);
			return new decimal(array);
		}

		internal void ReadBString(out string value)
		{
			ReadUInt16(out var value2);
			value = Encoding.UTF8.GetString(_buffer, _offset, value2);
			_offset += value2;
		}

		internal void ReadCString(out string value)
		{
			int i;
			for (i = 0; _offset + i < _buffer.Length && _buffer[_offset + i] != 0; i++)
			{
			}
			value = Encoding.UTF8.GetString(_buffer, _offset, i);
			_offset += i + 1;
		}

		internal void SkipCString(out string value)
		{
			int i;
			for (i = 0; _offset + i < _buffer.Length && _buffer[_offset + i] != 0; i++)
			{
			}
			_offset += i + 1;
			value = null;
		}

		internal void ReadGuid(out Guid guid)
		{
			ReadUInt32(out var value);
			ReadUInt16(out var value2);
			ReadUInt16(out var value3);
			ReadUInt8(out var value4);
			ReadUInt8(out var value5);
			ReadUInt8(out var value6);
			ReadUInt8(out var value7);
			ReadUInt8(out var value8);
			ReadUInt8(out var value9);
			ReadUInt8(out var value10);
			ReadUInt8(out var value11);
			guid = new Guid((int)value, (short)value2, (short)value3, value4, value5, value6, value7, value8, value9, value10, value11);
		}

		internal string ReadString()
		{
			int i;
			for (i = 0; _offset + i < _buffer.Length && _buffer[_offset + i] != 0; i += 2)
			{
			}
			string result = Encoding.Unicode.GetString(_buffer, _offset, i);
			_offset += i + 2;
			return result;
		}
	}

	private struct BitSet
	{
		private readonly int _size;

		private readonly uint[] _words;

		internal bool IsEmpty => _size == 0;

		internal BitSet(BitAccess bits)
		{
			bits.ReadInt32(out _size);
			_words = new uint[_size];
			bits.ReadUInt32(_words);
		}

		internal bool IsSet(int index)
		{
			int num = index / 32;
			if (num >= _size)
			{
				return false;
			}
			return (_words[num] & GetBit(index)) != 0;
		}

		private static uint GetBit(int index)
		{
			return (uint)(1 << index % 32);
		}
	}

	private class IntHashTable
	{
		private struct bucket
		{
			internal int key;

			internal int hash_coll;

			internal object val;
		}

		private static readonly int[] s_primes = new int[72]
		{
			3, 7, 11, 17, 23, 29, 37, 47, 59, 71,
			89, 107, 131, 163, 197, 239, 293, 353, 431, 521,
			631, 761, 919, 1103, 1327, 1597, 1931, 2333, 2801, 3371,
			4049, 4861, 5839, 7013, 8419, 10103, 12143, 14591, 17519, 21023,
			25229, 30293, 36353, 43627, 52361, 62851, 75431, 90523, 108631, 130363,
			156437, 187751, 225307, 270371, 324449, 389357, 467237, 560689, 672827, 807403,
			968897, 1162687, 1395263, 1674319, 2009191, 2411033, 2893249, 3471899, 4166287, 4999559,
			5999471, 7199369
		};

		private bucket[] _buckets;

		private int _count;

		private int _occupancy;

		private int _loadsize;

		private readonly int _loadFactorPerc;

		private int _version;

		internal object this[int key]
		{
			get
			{
				if (key < 0)
				{
					throw new ArgumentException("Argument_KeyLessThanZero");
				}
				bucket[] buckets = _buckets;
				uint num = InitHash(key, buckets.Length, out var seed, out var incr);
				int num2 = 0;
				bucket bucket2;
				do
				{
					int num3 = (int)(seed % (uint)buckets.Length);
					bucket2 = buckets[num3];
					if (bucket2.val == null)
					{
						return null;
					}
					if ((bucket2.hash_coll & 0x7FFFFFFF) == num && key == bucket2.key)
					{
						return bucket2.val;
					}
					seed += incr;
				}
				while (bucket2.hash_coll < 0 && ++num2 < buckets.Length);
				return null;
			}
		}

		private static int GetPrime(int minSize)
		{
			if (minSize < 0)
			{
				throw new ArgumentException("Arg_HTCapacityOverflow");
			}
			for (int i = 0; i < s_primes.Length; i++)
			{
				int num = s_primes[i];
				if (num >= minSize)
				{
					return num;
				}
			}
			throw new ArgumentException("Arg_HTCapacityOverflow");
		}

		internal IntHashTable()
			: this(0, 100)
		{
		}

		internal IntHashTable(int capacity, int loadFactorPerc)
		{
			if (capacity < 0)
			{
				throw new ArgumentOutOfRangeException("capacity", "ArgumentOutOfRange_NeedNonNegNum");
			}
			if (loadFactorPerc < 10 || loadFactorPerc > 100)
			{
				throw new ArgumentOutOfRangeException("loadFactorPerc", "ArgumentOutOfRange_IntHashTableLoadFactor");
			}
			_loadFactorPerc = loadFactorPerc * 72 / 100;
			int prime = GetPrime(capacity / _loadFactorPerc);
			_buckets = new bucket[prime];
			_loadsize = _loadFactorPerc * prime / 100;
			if (_loadsize >= prime)
			{
				_loadsize = prime - 1;
			}
		}

		private static uint InitHash(int key, int hashsize, out uint seed, out uint incr)
		{
			uint result = (seed = (uint)(key & 0x7FFFFFFF));
			incr = 1 + ((seed >> 5) + 1) % (uint)(hashsize - 1);
			return result;
		}

		internal void Add(int key, object value)
		{
			Insert(key, value, add: true);
		}

		private void expand()
		{
			rehash(GetPrime(1 + _buckets.Length * 2));
		}

		private void rehash()
		{
			rehash(_buckets.Length);
		}

		private void rehash(int newsize)
		{
			_occupancy = 0;
			bucket[] array = new bucket[newsize];
			for (int i = 0; i < _buckets.Length; i++)
			{
				bucket bucket2 = _buckets[i];
				if (bucket2.val != null)
				{
					putEntry(array, bucket2.key, bucket2.val, bucket2.hash_coll & 0x7FFFFFFF);
				}
			}
			_version++;
			_buckets = array;
			_loadsize = _loadFactorPerc * newsize / 100;
			if (_loadsize >= newsize)
			{
				_loadsize = newsize - 1;
			}
		}

		private void Insert(int key, object nvalue, bool add)
		{
			if (key < 0)
			{
				throw new ArgumentException("Argument_KeyLessThanZero");
			}
			if (nvalue == null)
			{
				throw new ArgumentNullException("nvalue", "ArgumentNull_Value");
			}
			if (_count >= _loadsize)
			{
				expand();
			}
			else if (_occupancy > _loadsize && _count > 100)
			{
				rehash();
			}
			uint num = InitHash(key, _buckets.Length, out var seed, out var incr);
			int num2 = 0;
			int num3 = -1;
			do
			{
				int num4 = (int)(seed % (uint)_buckets.Length);
				if (_buckets[num4].val == null)
				{
					if (num3 != -1)
					{
						num4 = num3;
					}
					_buckets[num4].val = nvalue;
					_buckets[num4].key = key;
					_buckets[num4].hash_coll |= (int)num;
					_count++;
					_version++;
					return;
				}
				if ((_buckets[num4].hash_coll & 0x7FFFFFFF) == num && key == _buckets[num4].key)
				{
					if (add)
					{
						throw new ArgumentException("Argument_AddingDuplicate__" + _buckets[num4].key);
					}
					_buckets[num4].val = nvalue;
					_version++;
					return;
				}
				if (num3 == -1 && _buckets[num4].hash_coll >= 0)
				{
					_buckets[num4].hash_coll |= int.MinValue;
					_occupancy++;
				}
				seed += incr;
			}
			while (++num2 < _buckets.Length);
			if (num3 != -1)
			{
				_buckets[num3].val = nvalue;
				_buckets[num3].key = key;
				_buckets[num3].hash_coll |= (int)num;
				_count++;
				_version++;
				return;
			}
			throw new InvalidOperationException("InvalidOperation_HashInsertFailed");
		}

		private void putEntry(bucket[] newBuckets, int key, object nvalue, int hashcode)
		{
			uint num = (uint)hashcode;
			uint num2 = 1 + ((num >> 5) + 1) % (uint)(newBuckets.Length - 1);
			int num3;
			while (true)
			{
				num3 = (int)(num % (uint)newBuckets.Length);
				if (newBuckets[num3].val == null)
				{
					break;
				}
				if (newBuckets[num3].hash_coll >= 0)
				{
					newBuckets[num3].hash_coll |= int.MinValue;
					_occupancy++;
				}
				num += num2;
			}
			newBuckets[num3].val = nvalue;
			newBuckets[num3].key = key;
			newBuckets[num3].hash_coll |= hashcode;
		}
	}

	private struct DbiSecCon
	{
		internal readonly short section;

		internal readonly short pad1;

		internal readonly int offset;

		internal readonly int size;

		internal readonly uint flags;

		internal readonly short module;

		internal readonly short pad2;

		internal readonly uint dataCrc;

		internal readonly uint relocCrc;

		internal DbiSecCon(BitAccess bits)
		{
			bits.ReadInt16(out section);
			bits.ReadInt16(out pad1);
			bits.ReadInt32(out offset);
			bits.ReadInt32(out size);
			bits.ReadUInt32(out flags);
			bits.ReadInt16(out module);
			bits.ReadInt16(out pad2);
			bits.ReadUInt32(out dataCrc);
			bits.ReadUInt32(out relocCrc);
		}
	}

	private class DbiModuleInfo
	{
		internal readonly int opened;

		internal readonly ushort flags;

		internal readonly short stream;

		internal readonly int cbSyms;

		internal readonly int cbOldLines;

		internal readonly int cbLines;

		internal readonly short files;

		internal readonly short pad1;

		internal readonly uint offsets;

		internal readonly int niSource;

		internal readonly int niCompiler;

		internal readonly string moduleName;

		internal readonly string objectName;

		internal DbiModuleInfo(BitAccess bits, bool readStrings)
		{
			bits.ReadInt32(out opened);
			new DbiSecCon(bits);
			bits.ReadUInt16(out flags);
			bits.ReadInt16(out stream);
			bits.ReadInt32(out cbSyms);
			bits.ReadInt32(out cbOldLines);
			bits.ReadInt32(out cbLines);
			bits.ReadInt16(out files);
			bits.ReadInt16(out pad1);
			bits.ReadUInt32(out offsets);
			bits.ReadInt32(out niSource);
			bits.ReadInt32(out niCompiler);
			if (readStrings)
			{
				bits.ReadCString(out moduleName);
				bits.ReadCString(out objectName);
			}
			else
			{
				bits.SkipCString(out moduleName);
				bits.SkipCString(out objectName);
			}
			bits.Align(4);
		}
	}

	private struct DbiHeader
	{
		internal readonly int sig;

		internal readonly int ver;

		internal readonly int age;

		internal readonly short gssymStream;

		internal readonly ushort vers;

		internal readonly short pssymStream;

		internal readonly ushort pdbver;

		internal readonly short symrecStream;

		internal readonly ushort pdbver2;

		internal readonly int gpmodiSize;

		internal readonly int secconSize;

		internal readonly int secmapSize;

		internal readonly int filinfSize;

		internal readonly int tsmapSize;

		internal readonly int mfcIndex;

		internal readonly int dbghdrSize;

		internal readonly int ecinfoSize;

		internal readonly ushort flags;

		internal readonly ushort machine;

		internal readonly int reserved;

		internal DbiHeader(BitAccess bits)
		{
			bits.ReadInt32(out sig);
			bits.ReadInt32(out ver);
			bits.ReadInt32(out age);
			bits.ReadInt16(out gssymStream);
			bits.ReadUInt16(out vers);
			bits.ReadInt16(out pssymStream);
			bits.ReadUInt16(out pdbver);
			bits.ReadInt16(out symrecStream);
			bits.ReadUInt16(out pdbver2);
			bits.ReadInt32(out gpmodiSize);
			bits.ReadInt32(out secconSize);
			bits.ReadInt32(out secmapSize);
			bits.ReadInt32(out filinfSize);
			bits.ReadInt32(out tsmapSize);
			bits.ReadInt32(out mfcIndex);
			bits.ReadInt32(out dbghdrSize);
			bits.ReadInt32(out ecinfoSize);
			bits.ReadUInt16(out flags);
			bits.ReadUInt16(out machine);
			bits.ReadInt32(out reserved);
		}
	}

	private struct DbiDbgHdr
	{
		internal readonly ushort snFPO;

		internal readonly ushort snException;

		internal readonly ushort snFixup;

		internal readonly ushort snOmapToSrc;

		internal readonly ushort snOmapFromSrc;

		internal readonly ushort snSectionHdr;

		internal readonly ushort snTokenRidMap;

		internal readonly ushort snXdata;

		internal readonly ushort snPdata;

		internal readonly ushort snNewFPO;

		internal readonly ushort snSectionHdrOrig;

		internal DbiDbgHdr(BitAccess bits)
		{
			bits.ReadUInt16(out snFPO);
			bits.ReadUInt16(out snException);
			bits.ReadUInt16(out snFixup);
			bits.ReadUInt16(out snOmapToSrc);
			bits.ReadUInt16(out snOmapFromSrc);
			bits.ReadUInt16(out snSectionHdr);
			bits.ReadUInt16(out snTokenRidMap);
			bits.ReadUInt16(out snXdata);
			bits.ReadUInt16(out snPdata);
			bits.ReadUInt16(out snNewFPO);
			bits.ReadUInt16(out snSectionHdrOrig);
		}
	}

	private class PdbFileHeader
	{
		internal readonly byte[] magic;

		internal readonly int pageSize;

		internal readonly int freePageMap;

		internal readonly int pagesUsed;

		internal readonly int directorySize;

		internal readonly int zero;

		internal readonly int[] directoryRoot;

		internal PdbFileHeader(Stream reader, BitAccess bits)
		{
			bits.MinCapacity(56);
			reader.Seek(0L, SeekOrigin.Begin);
			bits.FillBuffer(reader, 52);
			magic = new byte[32];
			bits.ReadBytes(magic);
			bits.ReadInt32(out pageSize);
			bits.ReadInt32(out freePageMap);
			bits.ReadInt32(out pagesUsed);
			bits.ReadInt32(out directorySize);
			bits.ReadInt32(out zero);
			int num = ((directorySize + pageSize - 1) / pageSize * 4 + pageSize - 1) / pageSize;
			directoryRoot = new int[num];
			bits.FillBuffer(reader, num * 4);
			bits.ReadInt32(directoryRoot);
		}
	}

	private class PdbReader
	{
		internal readonly int pageSize;

		internal readonly Stream reader;

		internal PdbReader(Stream reader, int pageSize)
		{
			this.pageSize = pageSize;
			this.reader = reader;
		}

		internal void Seek(int page, int offset)
		{
			reader.Seek(page * pageSize + offset, SeekOrigin.Begin);
		}

		internal void Read(byte[] bytes, int offset, int count)
		{
			reader.Read(bytes, offset, count);
		}

		internal int PagesFromSize(int size)
		{
			return (size + pageSize - 1) / pageSize;
		}
	}

	private class DataStream
	{
		internal readonly int contentSize;

		internal readonly int[] pages;

		internal int Length => contentSize;

		internal DataStream()
		{
		}

		internal DataStream(int contentSize, BitAccess bits, int count)
		{
			this.contentSize = contentSize;
			if (count > 0)
			{
				pages = new int[count];
				bits.ReadInt32(pages);
			}
		}

		internal void Read(PdbReader reader, BitAccess bits)
		{
			bits.MinCapacity(contentSize);
			Read(reader, 0, bits.Buffer, 0, contentSize);
		}

		internal void Read(PdbReader reader, int position, byte[] bytes, int offset, int data)
		{
			if (position + data > contentSize)
			{
				throw new Exception($"DataStream can't read off end of stream. (pos={position},siz={data})");
			}
			if (position == contentSize)
			{
				return;
			}
			int num = data;
			int num2 = position / reader.pageSize;
			int num3 = position % reader.pageSize;
			if (num3 != 0)
			{
				int num4 = reader.pageSize - num3;
				if (num4 > num)
				{
					num4 = num;
				}
				reader.Seek(pages[num2], num3);
				reader.Read(bytes, offset, num4);
				offset += num4;
				num -= num4;
				num2++;
			}
			while (num > 0)
			{
				int num5 = reader.pageSize;
				if (num5 > num)
				{
					num5 = num;
				}
				reader.Seek(pages[num2], 0);
				reader.Read(bytes, offset, num5);
				offset += num5;
				num -= num5;
				num2++;
			}
		}
	}

	private class MsfDirectory
	{
		internal readonly DataStream[] streams;

		internal MsfDirectory(PdbReader reader, PdbFileHeader head, BitAccess bits)
		{
			int num = reader.PagesFromSize(head.directorySize);
			bits.MinCapacity(head.directorySize);
			int num2 = head.directoryRoot.Length;
			int num3 = head.pageSize / 4;
			int num4 = num;
			for (int i = 0; i < num2; i++)
			{
				int num5 = ((num4 <= num3) ? num4 : num3);
				reader.Seek(head.directoryRoot[i], 0);
				bits.Append(reader.reader, num5 * 4);
				num4 -= num5;
			}
			bits.Position = 0;
			DataStream dataStream = new DataStream(head.directorySize, bits, num);
			bits.MinCapacity(head.directorySize);
			dataStream.Read(reader, bits);
			bits.ReadInt32(out var value);
			int[] array = new int[value];
			bits.ReadInt32(array);
			streams = new DataStream[value];
			for (int j = 0; j < value; j++)
			{
				if (array[j] <= 0)
				{
					streams[j] = new DataStream();
				}
				else
				{
					streams[j] = new DataStream(array[j], bits, reader.PagesFromSize(array[j]));
				}
			}
		}
	}

	private struct CV_FileCheckSum
	{
		internal uint name;

		internal byte len;

		internal byte type;
	}

	private enum SYM
	{
		S_END = 6,
		S_OEM = 1028,
		S_REGISTER_ST = 4097,
		S_CONSTANT_ST = 4098,
		S_UDT_ST = 4099,
		S_COBOLUDT_ST = 4100,
		S_MANYREG_ST = 4101,
		S_BPREL32_ST = 4102,
		S_LDATA32_ST = 4103,
		S_GDATA32_ST = 4104,
		S_PUB32_ST = 4105,
		S_LPROC32_ST = 4106,
		S_GPROC32_ST = 4107,
		S_VFTABLE32 = 4108,
		S_REGREL32_ST = 4109,
		S_LTHREAD32_ST = 4110,
		S_GTHREAD32_ST = 4111,
		S_LPROCMIPS_ST = 4112,
		S_GPROCMIPS_ST = 4113,
		S_FRAMEPROC = 4114,
		S_COMPILE2_ST = 4115,
		S_MANYREG2_ST = 4116,
		S_LPROCIA64_ST = 4117,
		S_GPROCIA64_ST = 4118,
		S_LOCALSLOT_ST = 4119,
		S_PARAMSLOT_ST = 4120,
		S_ANNOTATION = 4121,
		S_GMANPROC_ST = 4122,
		S_LMANPROC_ST = 4123,
		S_RESERVED1 = 4124,
		S_RESERVED2 = 4125,
		S_RESERVED3 = 4126,
		S_RESERVED4 = 4127,
		S_LMANDATA_ST = 4128,
		S_GMANDATA_ST = 4129,
		S_MANFRAMEREL_ST = 4130,
		S_MANREGISTER_ST = 4131,
		S_MANSLOT_ST = 4132,
		S_MANMANYREG_ST = 4133,
		S_MANREGREL_ST = 4134,
		S_MANMANYREG2_ST = 4135,
		S_MANTYPREF = 4136,
		S_UNAMESPACE_ST = 4137,
		S_ST_MAX = 4352,
		S_OBJNAME = 4353,
		S_THUNK32 = 4354,
		S_BLOCK32 = 4355,
		S_WITH32 = 4356,
		S_LABEL32 = 4357,
		S_REGISTER = 4358,
		S_CONSTANT = 4359,
		S_UDT = 4360,
		S_COBOLUDT = 4361,
		S_MANYREG = 4362,
		S_BPREL32 = 4363,
		S_LDATA32 = 4364,
		S_GDATA32 = 4365,
		S_PUB32 = 4366,
		S_LPROC32 = 4367,
		S_GPROC32 = 4368,
		S_REGREL32 = 4369,
		S_LTHREAD32 = 4370,
		S_GTHREAD32 = 4371,
		S_LPROCMIPS = 4372,
		S_GPROCMIPS = 4373,
		S_COMPILE2 = 4374,
		S_MANYREG2 = 4375,
		S_LPROCIA64 = 4376,
		S_GPROCIA64 = 4377,
		S_LOCALSLOT = 4378,
		S_SLOT = S_LOCALSLOT,
		S_PARAMSLOT = 4379,
		S_LMANDATA = 4380,
		S_GMANDATA = 4381,
		S_MANFRAMEREL = 4382,
		S_MANREGISTER = 4383,
		S_MANSLOT = 4384,
		S_MANMANYREG = 4385,
		S_MANREGREL = 4386,
		S_MANMANYREG2 = 4387,
		S_UNAMESPACE = 4388,
		S_PROCREF = 4389,
		S_DATAREF = 4390,
		S_LPROCREF = 4391,
		S_ANNOTATIONREF = 4392,
		S_TOKENREF = 4393,
		S_GMANPROC = 4394,
		S_LMANPROC = 4395,
		S_TRAMPOLINE = 4396,
		S_MANCONSTANT = 4397,
		S_ATTR_FRAMEREL = 4398,
		S_ATTR_REGISTER = 4399,
		S_ATTR_REGREL = 4400,
		S_ATTR_MANYREG = 4401,
		S_SEPCODE = 4402,
		S_LOCAL = 4403,
		S_DEFRANGE = 4404,
		S_DEFRANGE2 = 4405,
		S_SECTION = 4406,
		S_COFFGROUP = 4407,
		S_EXPORT = 4408,
		S_CALLSITEINFO = 4409,
		S_FRAMECOOKIE = 4410,
		S_DISCARDED = 4411,
		S_RECTYPE_MAX = 4412,
		S_RECTYPE_LAST = S_DISCARDED
	}

	private enum DEBUG_S_SUBSECTION
	{
		SYMBOLS = 241,
		LINES,
		STRINGTABLE,
		FILECHKSMS,
		FRAMEDATA
	}

	private struct OemSymbol
	{
		internal Guid idOem;

		internal uint typind;
	}

	private static XmlWriterSettings s_xmlWriterSettings = new XmlWriterSettings
	{
		Encoding = Encoding.UTF8,
		Indent = true,
		IndentChars = "  ",
		NewLineChars = "\r\n"
	};

	private static readonly Guid s_msilMetaData = new Guid(-957726775, 22963, 18902, 188, 37, 9, 2, 187, 171, 180, 96);

	private static readonly Guid s_symDocumentTypeGuid = new Guid("{5a869d0b-6611-11d3-bd2a-0000f80849bd}");

	private Token2SourceLineExporter()
	{
	}

	public static string TokenToSourceMap2Xml(Stream read, bool maskToken = false)
	{
		StringBuilder stringBuilder = new StringBuilder();
		using (XmlWriter xmlWriter = XmlWriter.Create(stringBuilder, s_xmlWriterSettings))
		{
			xmlWriter.WriteStartElement("token-map");
			List<PdbTokenLine> list = new List<PdbTokenLine>(LoadTokenToSourceMapping(read).Values);
			list.Sort(delegate(PdbTokenLine x, PdbTokenLine y)
			{
				uint line2 = x.line;
				int num = line2.CompareTo(y.line);
				if (num != 0)
				{
					return num;
				}
				line2 = x.column;
				num = line2.CompareTo(y.column);
				if (num != 0)
				{
					return num;
				}
				line2 = x.endLine;
				num = line2.CompareTo(y.endLine);
				if (num != 0)
				{
					return num;
				}
				line2 = x.endColumn;
				num = line2.CompareTo(y.endColumn);
				if (num != 0)
				{
					return num;
				}
				line2 = x.token;
				return line2.CompareTo(y.token);
			});
			foreach (PdbTokenLine item in list)
			{
				xmlWriter.WriteStartElement("token-location");
				xmlWriter.WriteAttributeString("token", Token2String(item.token, maskToken));
				xmlWriter.WriteAttributeString("file", item.sourceFile.name);
				uint line = item.line;
				xmlWriter.WriteAttributeString("start-line", line.ToString());
				line = item.column;
				xmlWriter.WriteAttributeString("start-column", line.ToString());
				line = item.endLine;
				xmlWriter.WriteAttributeString("end-line", line.ToString());
				line = item.endColumn;
				xmlWriter.WriteAttributeString("end-column", line.ToString());
				xmlWriter.WriteEndElement();
			}
			xmlWriter.WriteEndElement();
		}
		return stringBuilder.ToString();
	}

	private static string Token2String(uint token, bool maskToken)
	{
		string text = token.ToString("X8");
		if (maskToken)
		{
			text = text.Substring(0, 2) + "xxxxxx";
		}
		return "0x" + text;
	}

	private static Dictionary<uint, PdbTokenLine> LoadTokenToSourceMapping(Stream read)
	{
		Dictionary<uint, PdbTokenLine> dictionary = new Dictionary<uint, PdbTokenLine>();
		BitAccess bits = new BitAccess(524288);
		PdbFileHeader pdbFileHeader = new PdbFileHeader(read, bits);
		PdbReader reader = new PdbReader(read, pdbFileHeader.pageSize);
		MsfDirectory msfDirectory = new MsfDirectory(reader, pdbFileHeader, bits);
		DbiModuleInfo[] modules = null;
		msfDirectory.streams[1].Read(reader, bits);
		Dictionary<string, int> dictionary2 = LoadNameIndex(bits);
		if (!dictionary2.TryGetValue("/NAMES", out var value))
		{
			throw new Exception("No `name' stream");
		}
		msfDirectory.streams[value].Read(reader, bits);
		IntHashTable names = LoadNameStream(bits);
		msfDirectory.streams[3].Read(reader, bits);
		LoadDbiStream(bits, out modules, out var _, readStrings: true);
		if (modules != null)
		{
			foreach (DbiModuleInfo dbiModuleInfo in modules)
			{
				if (dbiModuleInfo.stream > 0)
				{
					msfDirectory.streams[dbiModuleInfo.stream].Read(reader, bits);
					if (dbiModuleInfo.moduleName == "TokenSourceLineInfo")
					{
						LoadTokenToSourceInfo(bits, dbiModuleInfo, names, msfDirectory, dictionary2, reader, dictionary);
					}
				}
			}
		}
		return dictionary;
	}

	private static Dictionary<string, int> LoadNameIndex(BitAccess bits)
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		bits.ReadInt32(out var _);
		bits.ReadInt32(out var _);
		bits.ReadInt32(out var _);
		bits.ReadGuid(out var _);
		bits.ReadInt32(out var value4);
		int position = bits.Position;
		int position2 = bits.Position + value4;
		bits.Position = position2;
		bits.ReadInt32(out var value5);
		bits.ReadInt32(out var value6);
		BitSet bitSet = new BitSet(bits);
		if (!new BitSet(bits).IsEmpty)
		{
			throw new Exception("Unsupported PDB deleted bitset is not empty.");
		}
		int num = 0;
		for (int i = 0; i < value6; i++)
		{
			if (bitSet.IsSet(i))
			{
				bits.ReadInt32(out var value7);
				bits.ReadInt32(out var value8);
				int position3 = bits.Position;
				bits.Position = position + value7;
				bits.ReadCString(out var value9);
				bits.Position = position3;
				dictionary.Add(value9.ToUpperInvariant(), value8);
				num++;
			}
		}
		if (num != value5)
		{
			throw new Exception($"Count mismatch. ({num} != {value5})");
		}
		return dictionary;
	}

	private static void LoadTokenToSourceInfo(BitAccess bits, DbiModuleInfo module, IntHashTable names, MsfDirectory dir, Dictionary<string, int> nameIndex, PdbReader reader, Dictionary<uint, PdbTokenLine> tokenToSourceMapping)
	{
		bits.Position = 0;
		bits.ReadInt32(out var value);
		if (value != 4)
		{
			throw new Exception($"Invalid signature. (sig={value})");
		}
		bits.Position = 4;
		OemSymbol oemSymbol = default(OemSymbol);
		while (bits.Position < module.cbSyms)
		{
			bits.ReadUInt16(out var value2);
			int position = bits.Position;
			int position2 = bits.Position + value2;
			bits.Position = position;
			bits.ReadUInt16(out var value3);
			switch ((SYM)value3)
			{
			case SYM.S_OEM:
				bits.ReadGuid(out oemSymbol.idOem);
				bits.ReadUInt32(out oemSymbol.typind);
				if (oemSymbol.idOem == s_msilMetaData)
				{
					if (bits.ReadString() == "TSLI")
					{
						bits.ReadUInt32(out var value4);
						bits.ReadUInt32(out var value5);
						bits.ReadUInt32(out var value6);
						bits.ReadUInt32(out var value7);
						bits.ReadUInt32(out var value8);
						bits.ReadUInt32(out var value9);
						if (!tokenToSourceMapping.TryGetValue(value4, out var value10))
						{
							tokenToSourceMapping.Add(value4, new PdbTokenLine(value4, value5, value6, value7, value8, value9));
						}
						else
						{
							while (value10.nextLine != null)
							{
								value10 = value10.nextLine;
							}
							value10.nextLine = new PdbTokenLine(value4, value5, value6, value7, value8, value9);
						}
					}
					bits.Position = position2;
					break;
				}
				throw new Exception($"OEM section: guid={oemSymbol.idOem} ti={oemSymbol.typind}");
			case SYM.S_END:
				bits.Position = position2;
				break;
			default:
				bits.Position = position2;
				break;
			}
		}
		bits.Position = module.cbSyms + module.cbOldLines;
		int limit = module.cbSyms + module.cbOldLines + module.cbLines;
		IntHashTable intHashTable = ReadSourceFileInfo(bits, (uint)limit, names, dir, nameIndex, reader);
		foreach (PdbTokenLine value11 in tokenToSourceMapping.Values)
		{
			value11.sourceFile = (PdbSource)intHashTable[(int)value11.file_id];
		}
	}

	private static IntHashTable ReadSourceFileInfo(BitAccess bits, uint limit, IntHashTable names, MsfDirectory dir, Dictionary<string, int> nameIndex, PdbReader reader)
	{
		IntHashTable intHashTable = new IntHashTable();
		_ = bits.Position;
		CV_FileCheckSum cV_FileCheckSum = default(CV_FileCheckSum);
		while (bits.Position < limit)
		{
			bits.ReadInt32(out var value);
			bits.ReadInt32(out var value2);
			int position = bits.Position;
			int num = bits.Position + value2;
			DEBUG_S_SUBSECTION dEBUG_S_SUBSECTION = (DEBUG_S_SUBSECTION)value;
			if (dEBUG_S_SUBSECTION == DEBUG_S_SUBSECTION.FILECHKSMS)
			{
				while (bits.Position < num)
				{
					int key = bits.Position - position;
					bits.ReadUInt32(out cV_FileCheckSum.name);
					bits.ReadUInt8(out cV_FileCheckSum.len);
					bits.ReadUInt8(out cV_FileCheckSum.type);
					PdbSource value3 = new PdbSource((string)names[(int)cV_FileCheckSum.name], s_symDocumentTypeGuid, Guid.Empty, Guid.Empty);
					intHashTable.Add(key, value3);
					bits.Position += cV_FileCheckSum.len;
					bits.Align(4);
				}
				bits.Position = num;
			}
			else
			{
				bits.Position = num;
			}
		}
		return intHashTable;
	}

	private static IntHashTable LoadNameStream(BitAccess bits)
	{
		IntHashTable intHashTable = new IntHashTable();
		bits.ReadUInt32(out var value);
		bits.ReadInt32(out var value2);
		bits.ReadInt32(out var value3);
		if (value != 4026462206u || value2 != 1)
		{
			throw new Exception($"Unsupported Name Stream version. (sig={value:x8}, ver={value2})");
		}
		int position = bits.Position;
		int position2 = bits.Position + value3;
		bits.Position = position2;
		bits.ReadInt32(out var value4);
		position2 = bits.Position;
		for (int i = 0; i < value4; i++)
		{
			bits.ReadInt32(out var value5);
			if (value5 != 0)
			{
				int position3 = bits.Position;
				bits.Position = position + value5;
				bits.ReadCString(out var value6);
				bits.Position = position3;
				intHashTable.Add(value5, value6);
			}
		}
		bits.Position = position2;
		return intHashTable;
	}

	private static void LoadDbiStream(BitAccess bits, out DbiModuleInfo[] modules, out DbiDbgHdr header, bool readStrings)
	{
		DbiHeader dbiHeader = new DbiHeader(bits);
		header = default(DbiDbgHdr);
		List<DbiModuleInfo> list = new List<DbiModuleInfo>();
		int num = bits.Position + dbiHeader.gpmodiSize;
		while (bits.Position < num)
		{
			DbiModuleInfo item = new DbiModuleInfo(bits, readStrings);
			list.Add(item);
		}
		if (bits.Position != num)
		{
			throw new Exception($"Error reading DBI stream, pos={bits.Position} != {num}");
		}
		if (list.Count > 0)
		{
			modules = list.ToArray();
		}
		else
		{
			modules = null;
		}
		bits.Position += dbiHeader.secconSize;
		bits.Position += dbiHeader.secmapSize;
		bits.Position += dbiHeader.filinfSize;
		bits.Position += dbiHeader.tsmapSize;
		bits.Position += dbiHeader.ecinfoSize;
		num = bits.Position + dbiHeader.dbghdrSize;
		if (dbiHeader.dbghdrSize > 0)
		{
			header = new DbiDbgHdr(bits);
		}
		bits.Position = num;
	}
}
