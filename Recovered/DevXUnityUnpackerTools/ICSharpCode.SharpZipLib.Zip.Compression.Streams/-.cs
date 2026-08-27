using APK;
using @as;
using DevXForms;
using DevXUnityUnpackerTools._WPF;
using DSMCaps;
using ICSharpCode.SharpZipLib.Encryption;
using Mono.Cecil;
using Mono.Cecil.Cil;
using SpirV;
using System;
using System.IO;
using System.Security.Cryptography;
using Unity.IO.Compression;
using Wasm;
using Wasm.Instructions;
using Wasm.Interpret;

namespace ICSharpCode.SharpZipLib.Zip.Compression.Streams
{
	internal class _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020 : System.IO.Stream
	{
		internal string _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A;

		internal ICryptoTransform _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020;

		internal byte[] AESAuthCode;

		internal byte[] _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A;

		internal _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A deflater_;

		internal System.IO.Stream baseOutputStream_;

		internal bool _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A;

		internal bool _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A = true;

		internal static RNGCryptoServiceProvider _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020;

		public bool IsStreamOwner
		{
			get
			{
				return _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A;
			}
			set
			{
				_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A = value;
			}
		}

		public bool CanPatchEntries => baseOutputStream_.CanSeek;

		public string Password
		{
			get
			{
				return _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A;
			}
			set
			{
				if (value != null && value.Length == 0)
				{
					_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A = null;
				}
				else
				{
					_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A = value;
				}
			}
		}

		public override bool CanRead => false;

		public override bool CanSeek => false;

		public override bool CanWrite => baseOutputStream_.CanWrite;

		public override long Length => baseOutputStream_.Length;

		public override long Position
		{
			get
			{
				return baseOutputStream_.Position;
			}
			set
			{
				throw new NotSupportedException("Position property not supported");
			}
		}

		public _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020(System.IO.Stream baseOutputStream)
			: this(baseOutputStream, new _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A(), 512)
		{
		}

		public _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020(System.IO.Stream baseOutputStream, _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A deflater)
			: this(baseOutputStream, deflater, 512)
		{
		}

		public _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020(System.IO.Stream baseOutputStream, _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A deflater, int bufferSize)
		{
			if (baseOutputStream == null)
			{
				throw new ArgumentNullException("baseOutputStream");
			}
			if (!baseOutputStream.CanWrite)
			{
				throw new ArgumentException("Must support writing", "baseOutputStream");
			}
			if (deflater == null)
			{
				throw new ArgumentNullException("deflater");
			}
			if (bufferSize < 512)
			{
				throw new ArgumentOutOfRangeException("bufferSize");
			}
			baseOutputStream_ = baseOutputStream;
			_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A = new byte[bufferSize];
			deflater_ = deflater;
		}

		public virtual void Finish()
		{
			deflater_.Finish();
			while (!deflater_.IsFinished)
			{
				int num = deflater_.Deflate(_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A, 0, _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A.Length);
				if (num <= 0)
				{
					break;
				}
				if (_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020 != null)
				{
					EncryptBlock(_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A, 0, num);
				}
				baseOutputStream_.Write(_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A, 0, num);
			}
			if (!deflater_.IsFinished)
			{
				throw new SharpZipBaseException("Can't deflate all input?");
			}
			baseOutputStream_.Flush();
			if (_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020 != null)
			{
				if (_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020 is _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020)
				{
					AESAuthCode = ((_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020)_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020).GetAuthCode();
				}
				_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020.Dispose();
				_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020 = null;
			}
		}

		internal void EncryptBlock(byte[] buffer, int offset, int length)
		{
			_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020.TransformBlock(buffer, 0, length, buffer, 0);
		}

		internal void InitializePassword(string password)
		{
			PkzipClassicManaged pkzipClassicManaged = new PkzipClassicManaged();
			byte[] rgbKey = PkzipClassic.GenerateKeys(ZipConstants.ConvertToArray(password));
			_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020 = pkzipClassicManaged.CreateEncryptor(rgbKey, null);
		}

		internal void InitializeAESPassword(_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020_0020_000A entry, string rawPassword, out byte[] salt, out byte[] pwdVerifier)
		{
			salt = new byte[entry._0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_0020_000A_0020_000A];
			if (_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020 == null)
			{
				_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020 = new RNGCryptoServiceProvider();
			}
			_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020.GetBytes(salt);
			int blockSize = entry.AESKeySize / 8;
			_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020 = new _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020(rawPassword, salt, blockSize, writeMode: true);
			pwdVerifier = ((_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020)_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020).PwdVerifier;
		}

		internal void Deflate()
		{
			while (!deflater_.IsNeedingInput)
			{
				int num = deflater_.Deflate(_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A, 0, _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A.Length);
				if (num <= 0)
				{
					break;
				}
				if (_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020 != null)
				{
					EncryptBlock(_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A, 0, num);
				}
				baseOutputStream_.Write(_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A, 0, num);
			}
			if (!deflater_.IsNeedingInput)
			{
				throw new SharpZipBaseException("DeflaterOutputStream can't deflate all input?");
			}
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException("DeflaterOutputStream Seek not supported");
		}

		public override void SetLength(long value)
		{
			throw new NotSupportedException("DeflaterOutputStream SetLength not supported");
		}

		public override int ReadByte()
		{
			throw new NotSupportedException("DeflaterOutputStream ReadByte not supported");
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException("DeflaterOutputStream Read not supported");
		}

		public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			throw new NotSupportedException("DeflaterOutputStream BeginRead not currently supported");
		}

		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			throw new NotSupportedException("BeginWrite is not supported");
		}

		public override void Flush()
		{
			deflater_.Flush();
			Deflate();
			baseOutputStream_.Flush();
		}

		public override void Close()
		{
			if (!_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A)
			{
				_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A = true;
				try
				{
					Finish();
					if (_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020 != null)
					{
						_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A();
						_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020.Dispose();
						_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020 = null;
					}
				}
				finally
				{
					if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A)
					{
						baseOutputStream_.Close();
					}
				}
			}
		}

		internal void _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A()
		{
			if (_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020 is _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020)
			{
				AESAuthCode = ((_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020)_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020).GetAuthCode();
			}
		}

		public override void WriteByte(byte value)
		{
			Write(new byte[1]
			{
				value
			}, 0, 1);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			deflater_.SetInput(buffer, offset, count);
			Deflate();
		}
	}
	internal class _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020
	{
		internal int _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_000A;

		internal byte[] _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020;

		internal int _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A;

		internal byte[] _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020;

		internal byte[] _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A;

		internal int _0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020;

		internal ICryptoTransform _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020;

		internal System.IO.Stream _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020;

		public int RawLength => _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_000A;

		public byte[] RawData => _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020;

		public int ClearTextLength => _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A;

		public byte[] ClearText => _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020;

		public int Available
		{
			get
			{
				return _0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020;
			}
			set
			{
				_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020 = value;
			}
		}

		public ICryptoTransform CryptoTransform
		{
			set
			{
				_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020 = value;
				if (_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020 != null)
				{
					if (_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020 == _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020)
					{
						if (_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A == null)
						{
							_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A = new byte[_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020.Length];
						}
						_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020 = _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A;
					}
					_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A = _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_000A;
					if (_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020 > 0)
					{
						_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020.TransformBlock(_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020, _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_000A - _0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020, _0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020, _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020, _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_000A - _0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020);
					}
				}
				else
				{
					_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020 = _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020;
					_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A = _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_000A;
				}
			}
		}

		public _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020(System.IO.Stream stream)
			: this(stream, 4096)
		{
		}

		public _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020(System.IO.Stream stream, int bufferSize)
		{
			_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020 = stream;
			if (bufferSize < 1024)
			{
				bufferSize = 1024;
			}
			_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020 = new byte[bufferSize];
			_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020 = _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020;
		}

		public void SetInflaterInput(_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A inflater)
		{
			if (_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020 > 0)
			{
				inflater.SetInput(_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020, _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A - _0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020, _0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020);
				_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020 = 0;
			}
		}

		public void Fill()
		{
			_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_000A = 0;
			int num2;
			for (int num = _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020.Length; num > 0; num -= num2)
			{
				num2 = _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020.Read(_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020, _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_000A, num);
				if (num2 <= 0)
				{
					break;
				}
				_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_000A += num2;
			}
			if (_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020 != null)
			{
				_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A = _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020.TransformBlock(_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020, 0, _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_000A, _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020, 0);
			}
			else
			{
				_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A = _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_000A;
			}
			_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020 = _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A;
		}

		public int ReadRawBuffer(byte[] buffer)
		{
			return ReadRawBuffer(buffer, 0, buffer.Length);
		}

		public int ReadRawBuffer(byte[] outBuffer, int offset, int length)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			int num = offset;
			int num2 = length;
			while (num2 > 0)
			{
				if (_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020 <= 0)
				{
					Fill();
					if (_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020 <= 0)
					{
						return 0;
					}
				}
				int num3 = Math.Min(num2, _0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020);
				Array.Copy(_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020, _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_000A - _0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020, outBuffer, num, num3);
				num += num3;
				num2 -= num3;
				_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020 -= num3;
			}
			return length;
		}

		public int ReadClearTextBuffer(byte[] outBuffer, int offset, int length)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			int num = offset;
			int num2 = length;
			while (num2 > 0)
			{
				if (_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020 <= 0)
				{
					Fill();
					if (_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020 <= 0)
					{
						return 0;
					}
				}
				int num3 = Math.Min(num2, _0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020);
				Array.Copy(_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020, _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A - _0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020, outBuffer, num, num3);
				num += num3;
				num2 -= num3;
				_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020 -= num3;
			}
			return length;
		}

		public int ReadLeByte()
		{
			if (_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020 <= 0)
			{
				Fill();
				if (_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020 <= 0)
				{
					throw new ZipException("EOF in header");
				}
			}
			byte result = _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020[_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_000A - _0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020];
			_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020--;
			return result;
		}

		public int ReadLeShort()
		{
			return ReadLeByte() | (ReadLeByte() << 8);
		}

		public int ReadLeInt()
		{
			return ReadLeShort() | (ReadLeShort() << 16);
		}

		public long ReadLeLong()
		{
			return (uint)ReadLeInt() | ((long)ReadLeInt() << 32);
		}
	}
	internal class _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A : System.IO.Stream
	{
		internal _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A inf;

		internal _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020 inputBuffer;

		internal System.IO.Stream _0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A;

		internal long csize;

		internal bool _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020;

		internal bool _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_0020_0020_000A_000A = true;

		public bool IsStreamOwner
		{
			get
			{
				return _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_0020_0020_000A_000A;
			}
			set
			{
				_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_0020_0020_000A_000A = value;
			}
		}

		public virtual int Available
		{
			get
			{
				if (!inf.IsFinished)
				{
					return 1;
				}
				return 0;
			}
		}

		public override bool CanRead => _0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A.CanRead;

		public override bool CanSeek => false;

		public override bool CanWrite => false;

		public override long Length
		{
			get
			{
				throw new NotSupportedException("InflaterInputStream Length is not supported");
			}
		}

		public override long Position
		{
			get
			{
				return _0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A.Position;
			}
			set
			{
				throw new NotSupportedException("InflaterInputStream Position not supported");
			}
		}

		public _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A(System.IO.Stream baseInputStream)
			: this(baseInputStream, new _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A(), 4096)
		{
		}

		public _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A(System.IO.Stream baseInputStream, _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A inf)
			: this(baseInputStream, inf, 4096)
		{
		}

		public _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A(System.IO.Stream baseInputStream, _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A inflater, int bufferSize)
		{
			if (baseInputStream == null)
			{
				throw new ArgumentNullException("baseInputStream");
			}
			if (inflater == null)
			{
				throw new ArgumentNullException("inflater");
			}
			if (bufferSize <= 0)
			{
				throw new ArgumentOutOfRangeException("bufferSize");
			}
			_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A = baseInputStream;
			inf = inflater;
			inputBuffer = new _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020(baseInputStream, bufferSize);
		}

		public long Skip(long count)
		{
			if (count <= 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A.CanSeek)
			{
				_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A.Seek(count, SeekOrigin.Current);
				return count;
			}
			int num = 2048;
			if (count < num)
			{
				num = (int)count;
			}
			byte[] buffer = new byte[num];
			int num2 = 1;
			long num3 = count;
			while (num3 > 0 && num2 > 0)
			{
				if (num3 < num)
				{
					num = (int)num3;
				}
				num2 = _0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A.Read(buffer, 0, num);
				num3 -= num2;
			}
			return count - num3;
		}

		internal void StopDecrypting()
		{
			inputBuffer.CryptoTransform = null;
		}

		internal void Fill()
		{
			if (inputBuffer.Available <= 0)
			{
				inputBuffer.Fill();
				if (inputBuffer.Available <= 0)
				{
					throw new SharpZipBaseException("Unexpected EOF");
				}
			}
			inputBuffer.SetInflaterInput(inf);
		}

		public override void Flush()
		{
			_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A.Flush();
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException("Seek not supported");
		}

		public override void SetLength(long value)
		{
			throw new NotSupportedException("InflaterInputStream SetLength not supported");
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException("InflaterInputStream Write not supported");
		}

		public override void WriteByte(byte value)
		{
			throw new NotSupportedException("InflaterInputStream WriteByte not supported");
		}

		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			throw new NotSupportedException("InflaterInputStream BeginWrite not supported");
		}

		public override void Close()
		{
			if (!_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020)
			{
				_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020 = true;
				if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_0020_0020_000A_000A)
				{
					_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A.Close();
				}
			}
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			if (inf.IsNeedingDictionary)
			{
				throw new SharpZipBaseException("Need a dictionary");
			}
			int num = count;
			while (true)
			{
				int num2 = inf.Inflate(buffer, offset, num);
				offset += num2;
				num -= num2;
				if (num == 0 || inf.IsFinished)
				{
					break;
				}
				if (inf.IsNeedingInput)
				{
					Fill();
				}
				else if (num2 == 0)
				{
					throw new ZipException("Dont know what to do");
				}
			}
			return count - num;
		}
	}
	internal class _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020
	{
		internal const int _0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020 = 32768;

		internal const int _0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A = 32767;

		internal byte[] _0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020 = new byte[32768];

		internal int _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A;

		internal int _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020;

		public void Write(int value)
		{
			if (_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020++ == 32768)
			{
				throw new InvalidOperationException("Window full");
			}
			_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020[_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A++] = (byte)value;
			_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A &= 32767;
		}

		internal void _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A(int _0020, int _0020_000A, int _0020_0020)
		{
			while (_0020_000A-- > 0)
			{
				_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020[_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A++] = _0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020[_0020++];
				_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A &= 32767;
				_0020 &= 0x7FFF;
			}
		}

		public void Repeat(int length, int distance)
		{
			if ((_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020 += length) > 32768)
			{
				throw new InvalidOperationException("Window full");
			}
			int num = (_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A - distance) & 0x7FFF;
			int num2 = 32768 - length;
			if (num <= num2 && _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A < num2)
			{
				if (length <= distance)
				{
					Array.Copy(_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020, num, _0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020, _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A, length);
					_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A += length;
					return;
				}
				while (length-- > 0)
				{
					_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020[_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A++] = _0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020[num++];
				}
			}
			else
			{
				_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A(num, length, distance);
			}
		}

		public int CopyStored(_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020 input, int length)
		{
			length = Math.Min(Math.Min(length, 32768 - _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020), input.AvailableBytes);
			int num = 32768 - _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A;
			int num2;
			if (length > num)
			{
				num2 = input.CopyBytes(_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020, _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A, num);
				if (num2 == num)
				{
					num2 += input.CopyBytes(_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020, 0, length - num);
				}
			}
			else
			{
				num2 = input.CopyBytes(_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020, _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A, length);
			}
			_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A = ((_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A + num2) & 0x7FFF);
			_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020 += num2;
			return num2;
		}

		public void CopyDict(byte[] dictionary, int offset, int length)
		{
			if (dictionary == null)
			{
				throw new ArgumentNullException("dictionary");
			}
			if (_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020 > 0)
			{
				throw new InvalidOperationException();
			}
			if (length > 32768)
			{
				offset += length - 32768;
				length = 32768;
			}
			Array.Copy(dictionary, offset, _0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020, 0, length);
			_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A = (length & 0x7FFF);
		}

		public int GetFreeSpace()
		{
			return 32768 - _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020;
		}

		public int GetAvailable()
		{
			return _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020;
		}

		public int CopyOutput(byte[] output, int offset, int len)
		{
			int num = _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A;
			if (len > _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020)
			{
				len = _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020;
			}
			else
			{
				num = ((_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A - _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020 + len) & 0x7FFF);
			}
			int num2 = len;
			int num3 = len - num;
			if (num3 > 0)
			{
				Array.Copy(_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020, 32768 - num3, output, offset, num3);
				offset += num3;
				len = num;
			}
			Array.Copy(_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020, num - len, output, offset, len);
			_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020 -= num2;
			if (_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020 < 0)
			{
				throw new InvalidOperationException();
			}
			return num2;
		}

		public void Reset()
		{
			_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020 = (_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A = 0);
		}
	}
	internal class _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020
	{
		internal byte[] _0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020;

		internal int _0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A;

		internal int _0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020;

		internal uint _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A;

		internal int _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020;

		public int AvailableBits => _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020;

		public int AvailableBytes => _0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020 - _0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A + (_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020 >> 3);

		public bool IsNeedingInput => _0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A == _0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020;

		public int PeekBits(int bitCount)
		{
			if (_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020 < bitCount)
			{
				if (_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A == _0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020)
				{
					return -1;
				}
				_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A |= (uint)(((_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020[_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A++] & 0xFF) | ((_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020[_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A++] & 0xFF) << 8)) << _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020);
				_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020 += 16;
			}
			return (int)(_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A & ((1 << bitCount) - 1));
		}

		public void DropBits(int bitCount)
		{
			_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A >>= bitCount;
			_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020 -= bitCount;
		}

		public int GetBits(int bitCount)
		{
			int num = PeekBits(bitCount);
			if (num >= 0)
			{
				DropBits(bitCount);
			}
			return num;
		}

		public void SkipToByteBoundary()
		{
			_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A >>= (_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020 & 7);
			_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020 &= -8;
		}

		public int CopyBytes(byte[] output, int offset, int length)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			if ((_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020 & 7) != 0)
			{
				throw new InvalidOperationException("Bit buffer is not byte aligned!");
			}
			int num = 0;
			while (_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020 > 0 && length > 0)
			{
				output[offset++] = (byte)_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A;
				_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A >>= 8;
				_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020 -= 8;
				length--;
				num++;
			}
			if (length == 0)
			{
				return num;
			}
			int num3 = _0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020 - _0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A;
			if (length > num3)
			{
				length = num3;
			}
			Array.Copy(_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020, _0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A, output, offset, length);
			_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A += length;
			if (((_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A - _0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020) & 1) != 0)
			{
				_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A = (uint)(_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020[_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A++] & 0xFF);
				_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020 = 8;
			}
			return num + length;
		}

		public void Reset()
		{
			_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A = 0u;
			_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A = (_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020 = (_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020 = 0));
		}

		public void SetInput(byte[] buffer, int offset, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset", "Cannot be negative");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", "Cannot be negative");
			}
			if (_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A < _0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020)
			{
				throw new InvalidOperationException("Old input was not completely processed");
			}
			int num = offset + count;
			if (offset > num || num > buffer.Length)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if ((count & 1) != 0)
			{
				_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A |= (uint)((buffer[offset++] & 0xFF) << _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020);
				_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020 += 8;
			}
			_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020 = buffer;
			_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A = offset;
			_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020 = num;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A
	{
		internal unsafe int _0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020(float _0020, bool _0020_000A)
		{
			((_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020)null)._0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020((System.IO.Stream)null);
			bool isInteractive = ((_3DView)null).IsInteractive;
			((_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_0020_000A_0020)null)._0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_0020_000A((Mono.Cecil.Cil.Instruction)null, (MemberReference)null);
			string text = ((_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020*)(byte*)null)->_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020;
			((_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020)null)._0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020((_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_0020)null);
			((ManyCodeCls)null)._0020_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020();
			return 207819784;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A
	{
		internal int _0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020(_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020 _0020, int _0020_000A)
		{
			return 994957096;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A
	{
		internal void _0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020(Wasm.Instructions.Instruction _0020, InterpreterContext _0020_000A)
		{
			OperatorImpls.Int64Load8S(null, null);
			OperatorImpls.Float32Neg(null, null);
			_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020 I_0 = ((_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A)null)._0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A
	{
		internal string _0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020(string _0020, object[] _0020_000A, ref bool _0020_0020, ref object _0020_000A_000A)
		{
			return "464266334";
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A
	{
		internal void _0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020(ImportedMemory _0020, OpTranspose _0020_000A, int _0020_0020, float _0020_000A_000A)
		{
			((PropertyDialog)null).SelectPage((object)null);
			((_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A)null).AddData((byte[])null);
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_000A
	{
		// Dead decoy method removed (referenced an unresolved IL generic-parameter leak, e.g. `!0`/`!!0` escaped as unbound generic syntax `<>`/`<,>`).
	}
}
