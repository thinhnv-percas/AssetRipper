using EdiTools;
using ICSharpCode.SharpZipLib.Checksum;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using SevenZip.Compression.LZMA;
using SpirV;
using System;
using System.IO;
using System.Text;
using System.Xml.Linq;
using Wasm;
using Wasm.Binary;
using Wasm.Interpret;
using WFTools3D;

namespace ICSharpCode.SharpZipLib.GZip
{
	internal sealed class _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020
	{
		public const int GZIP_MAGIC = 8075;

		public const int FTEXT = 1;

		public const int FHCRC = 2;

		public const int FEXTRA = 4;

		public const int FNAME = 8;

		public const int FCOMMENT = 16;

		internal _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020()
		{
		}
	}
	internal class _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A : _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A
	{
		internal Crc32 crc;

		internal bool _0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A_000A;

		internal bool _0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A_0020;

		public _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A(Stream baseInputStream)
			: this(baseInputStream, 4096)
		{
		}

		public _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A(Stream baseInputStream, int size)
			: base(baseInputStream, new _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A(noHeader: true), size)
		{
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			int num;
			do
			{
				if (!_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A_000A)
				{
					try
					{
						if (!_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A())
						{
							return 0;
						}
					}
					catch (Exception ex) when (_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A_0020 && (ex is GZipException || ex is EndOfStreamException))
					{
						return 0;
					}
				}
				num = base.Read(buffer, offset, count);
				if (num > 0)
				{
					crc.Update(buffer, offset, num);
				}
				if (inf.IsFinished)
				{
					_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020();
				}
			}
			while (num <= 0);
			return num;
		}

		internal bool _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A()
		{
			this.crc = new Crc32();
			if (inputBuffer.Available <= 0)
			{
				inputBuffer.Fill();
				if (inputBuffer.Available <= 0)
				{
					return false;
				}
			}
			Crc32 crc = new Crc32();
			int num = inputBuffer.ReadLeByte();
			if (num < 0)
			{
				throw new EndOfStreamException("EOS reading GZIP header");
			}
			crc.Update(num);
			if (num != 31)
			{
				throw new GZipException("Error GZIP header, first magic byte doesn't match");
			}
			num = inputBuffer.ReadLeByte();
			if (num < 0)
			{
				throw new EndOfStreamException("EOS reading GZIP header");
			}
			if (num != 139)
			{
				throw new GZipException("Error GZIP header,  second magic byte doesn't match");
			}
			crc.Update(num);
			int num2 = inputBuffer.ReadLeByte();
			if (num2 < 0)
			{
				throw new EndOfStreamException("EOS reading GZIP header");
			}
			if (num2 != 8)
			{
				throw new GZipException("Error GZIP header, data not in deflate format");
			}
			crc.Update(num2);
			int num3 = inputBuffer.ReadLeByte();
			if (num3 < 0)
			{
				throw new EndOfStreamException("EOS reading GZIP header");
			}
			crc.Update(num3);
			if ((num3 & 0xE0) != 0)
			{
				throw new GZipException("Reserved flag bits in GZIP header != 0");
			}
			for (int i = 0; i < 6; i++)
			{
				int num4 = inputBuffer.ReadLeByte();
				if (num4 < 0)
				{
					throw new EndOfStreamException("EOS reading GZIP header");
				}
				crc.Update(num4);
			}
			if ((num3 & 4) != 0)
			{
				int num5 = inputBuffer.ReadLeByte();
				int num6 = inputBuffer.ReadLeByte();
				if (num5 < 0 || num6 < 0)
				{
					throw new EndOfStreamException("EOS reading GZIP header");
				}
				crc.Update(num5);
				crc.Update(num6);
				int num7 = (num6 << 8) | num5;
				for (int j = 0; j < num7; j++)
				{
					int num8 = inputBuffer.ReadLeByte();
					if (num8 < 0)
					{
						throw new EndOfStreamException("EOS reading GZIP header");
					}
					crc.Update(num8);
				}
			}
			if ((num3 & 8) != 0)
			{
				int num9;
				while ((num9 = inputBuffer.ReadLeByte()) > 0)
				{
					crc.Update(num9);
				}
				if (num9 < 0)
				{
					throw new EndOfStreamException("EOS reading GZIP header");
				}
				crc.Update(num9);
			}
			if ((num3 & 0x10) != 0)
			{
				int num10;
				while ((num10 = inputBuffer.ReadLeByte()) > 0)
				{
					crc.Update(num10);
				}
				if (num10 < 0)
				{
					throw new EndOfStreamException("EOS reading GZIP header");
				}
				crc.Update(num10);
			}
			if ((num3 & 2) != 0)
			{
				int num11 = inputBuffer.ReadLeByte();
				if (num11 < 0)
				{
					throw new EndOfStreamException("EOS reading GZIP header");
				}
				int num12 = inputBuffer.ReadLeByte();
				if (num12 < 0)
				{
					throw new EndOfStreamException("EOS reading GZIP header");
				}
				if (((num11 << 8) | num12) != ((int)crc.Value & 0xFFFF))
				{
					throw new GZipException("Header CRC value mismatch");
				}
			}
			_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A_000A = true;
			return true;
		}

		internal void _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020()
		{
			byte[] array = new byte[8];
			long num = inf.TotalOut & uint.MaxValue;
			inputBuffer.Available += inf.RemainingInput;
			inf.Reset();
			int num3;
			for (int num2 = 8; num2 > 0; num2 -= num3)
			{
				num3 = inputBuffer.ReadClearTextBuffer(array, 8 - num2, num2);
				if (num3 <= 0)
				{
					throw new EndOfStreamException("EOS reading GZIP footer");
				}
			}
			int num4 = (array[0] & 0xFF) | ((array[1] & 0xFF) << 8) | ((array[2] & 0xFF) << 16) | (array[3] << 24);
			if (num4 != (int)crc.Value)
			{
				throw new GZipException("GZIP crc sum mismatch, theirs \"" + num4 + "\" and ours \"" + (int)crc.Value);
			}
			uint num5 = (uint)((array[4] & 0xFF) | ((array[5] & 0xFF) << 8) | ((array[6] & 0xFF) << 16) | (array[7] << 24));
			if (num != num5)
			{
				throw new GZipException("Number of bytes mismatch in footer");
			}
			_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A_000A = false;
			_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A_0020 = true;
		}
	}
	internal class _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020 : _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020
	{
		internal enum OutputState
		{
			Header,
			Footer,
			Finished,
			Closed
		}

		public bool Unitypacked;

		public string OriginalFileName;

		internal Crc32 crc = new Crc32();

		internal OutputState _0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_0020_0020;

		public _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020(Stream baseOutputStream)
			: this(baseOutputStream, 4096)
		{
		}

		public _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020(Stream baseOutputStream, int size)
			: base(baseOutputStream, new _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A(-1, noZlibHeaderOrFooter: true), size)
		{
		}

		public void SetLevel(int level)
		{
			if (level < 1)
			{
				throw new ArgumentOutOfRangeException("level");
			}
			deflater_.SetLevel(level);
		}

		public int GetLevel()
		{
			return deflater_.GetLevel();
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			if (_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_0020_0020 == OutputState.Header)
			{
				_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A_000A();
			}
			if (_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_0020_0020 != OutputState.Footer)
			{
				throw new InvalidOperationException("Write not permitted in current state");
			}
			crc.Update(buffer, offset, count);
			base.Write(buffer, offset, count);
		}

		public override void Close()
		{
			try
			{
				Finish();
			}
			finally
			{
				if (_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_0020_0020 != OutputState.Closed)
				{
					_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_0020_0020 = OutputState.Closed;
					if (base.IsStreamOwner)
					{
						baseOutputStream_.Close();
					}
				}
			}
		}

		public override void Finish()
		{
			if (_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_0020_0020 == OutputState.Header)
			{
				_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A_000A();
			}
			if (_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_0020_0020 == OutputState.Footer)
			{
				_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_0020_0020 = OutputState.Finished;
				base.Finish();
				uint num = (uint)(deflater_.TotalIn & uint.MaxValue);
				uint num2 = (uint)(crc.Value & uint.MaxValue);
				byte[] array = new byte[8]
				{
					(byte)num2,
					(byte)(num2 >> 8),
					(byte)(num2 >> 16),
					(byte)(num2 >> 24),
					(byte)num,
					(byte)(num >> 8),
					(byte)(num >> 16),
					(byte)(num >> 24)
				};
				baseOutputStream_.Write(array, 0, array.Length);
			}
		}

		internal void _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A_000A()
		{
			if (_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_0020_0020 != 0)
			{
				return;
			}
			_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_0020_0020 = OutputState.Footer;
			int num = (int)((DateTime.Now.Ticks - new DateTime(1970, 1, 1).Ticks) / 10000000);
			if (Unitypacked)
			{
				byte[] obj = new byte[10]
				{
					31,
					139,
					8,
					0,
					0,
					0,
					0,
					0,
					0,
					89
				};
				obj[3] = (byte)(0 | ((!string.IsNullOrEmpty(OriginalFileName)) ? 8 : 0));
				obj[4] = (byte)num;
				obj[5] = (byte)(num >> 8);
				obj[6] = (byte)(num >> 16);
				obj[7] = (byte)(num >> 24);
				byte[] array = obj;
				baseOutputStream_.Write(array, 0, array.Length);
				if (!string.IsNullOrEmpty(OriginalFileName))
				{
					byte[] bytes = Encoding.UTF8.GetBytes(OriginalFileName);
					baseOutputStream_.Write(bytes, 0, bytes.Length);
					baseOutputStream_.WriteByte(0);
				}
			}
			else
			{
				byte[] obj2 = new byte[10]
				{
					31,
					139,
					8,
					0,
					0,
					0,
					0,
					0,
					0,
					255
				};
				obj2[3] = (byte)(0 | ((!string.IsNullOrEmpty(OriginalFileName)) ? 8 : 0));
				obj2[4] = (byte)num;
				obj2[5] = (byte)(num >> 8);
				obj2[6] = (byte)(num >> 16);
				obj2[7] = (byte)(num >> 24);
				byte[] array2 = obj2;
				baseOutputStream_.Write(array2, 0, array2.Length);
				if (!string.IsNullOrEmpty(OriginalFileName))
				{
					byte[] bytes2 = Encoding.UTF8.GetBytes(OriginalFileName);
					baseOutputStream_.Write(bytes2, 0, bytes2.Length);
					baseOutputStream_.WriteByte(0);
				}
			}
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A
	{
		internal object _0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020(ParsedInstruction _0020)
		{
			((EdiMapping)null)._0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A((XElement)null);
			bool flag = (_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A)null != (object)null;
			return null;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A
	{
		internal object _0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020()
		{
			((BinaryWasmWriter)null).WriteSection((Section)null);
			((SevenZip.Compression.LZMA.Encoder)null)._0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_0020_000A_0020_0020_0020_0020();
			OperatorImpls.Float32Add(null, null);
			return null;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020_000A
	{
		internal unsafe int _0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020(float _0020, bool _0020_000A, bool _0020_0020, OpCaptureEventProfilingInfo _0020_000A_000A)
		{
			((MainForm)null)._0020_0020_000A_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_000A_000A((object)null, (EventArgs)null);
			Version version = ((ModuleHeader*)(byte*)null)->Version;
			WFUtils.GetPrimaryScreen();
			((ConnectSettingsForm)null)._0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020((object)null, (EventArgs)null);
			_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A._0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_000A_0020(null);
			((_0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020)null)._0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020((string)null);
			ManyCodeCls manyCodeCl = ((ManyCodeCls)null)._0020_0020_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020_000A_000A;
			return 1382154749;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A
	{
		internal void _0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_0020_0020(StringBuilder _0020, IntPtr _0020_000A)
		{
			Loader.InitConsole();
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_0020_000A
	{
		internal void _0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020()
		{
			_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020._0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_000A();
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A
	{
		internal object _0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020(bool _0020, string _0020_000A, _0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_000A _0020_0020, short _0020_000A_000A)
		{
			return null;
		}
	}
}
