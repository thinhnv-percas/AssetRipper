using System;
using System.IO;
using System.IO.Compression;
using System.Runtime.InteropServices;
using SpirV;
using ICSharpCode.SharpZipLib.Zip;
using @as;
using DevXUnityUnpackerTools._WinForm;
using ICSharpCode.SharpZipLib.Tar;


namespace BrotliSharpLib
{
	// Token: 0x0200074D RID: 1869
	public class BrotliStream : Stream
	{
		// Token: 0x06003333 RID: 13107 RVA: 0x002D2D40 File Offset: 0x002D0F40
		public BrotliStream(Stream stream, CompressionMode mode, bool leaveOpen)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			if (CompressionMode.Compress != mode && mode != CompressionMode.Decompress)
			{
				throw new ArgumentOutOfRangeException("mode");
			}
			this._0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020 = stream;
			this._0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A = mode;
			this._0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020 = leaveOpen;
			CompressionMode u0020_u000A_u000A_u0020_u0020_u000A_u0020_u000A_u000A_u000A_u0020_u0020_u000A_u0020_u000A = this._0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A;
			if (u0020_u000A_u000A_u0020_u0020_u000A_u0020_u000A_u000A_u000A_u0020_u0020_u000A_u0020_u000A != CompressionMode.Decompress)
			{
				if (u0020_u000A_u000A_u0020_u0020_u000A_u0020_u000A_u000A_u000A_u0020_u0020_u000A_u0020_u000A != CompressionMode.Compress)
				{
					return;
				}
				if (!this._0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020.CanWrite)
				{
					throw new ArgumentException("Stream does not support write", "stream");
				}
				this._0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020 = Brotli._0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A(null, null, null);
				return;
			}
			else
			{
				if (!this._0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020.CanRead)
				{
					throw new ArgumentException("Stream does not support read", "stream");
				}
				this._0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A = Brotli._0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A();
				Brotli._0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A_0020_0020(ref this._0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A);
				return;
			}
		}

		// Token: 0x06003334 RID: 13108 RVA: 0x00071AD8 File Offset: 0x0006FCD8
		public BrotliStream(Stream stream, CompressionMode mode) : this(stream, mode, false)
		{
		}

		// Token: 0x06003335 RID: 13109 RVA: 0x001DE714 File Offset: 0x001DC914
		~BrotliStream()
		{
			this.Dispose(false);
		}

		// Token: 0x06003336 RID: 13110 RVA: 0x002D2E0C File Offset: 0x002D100C
		public void SetQuality(int quality)
		{
			if (this._0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A != CompressionMode.Compress)
			{
				throw new InvalidOperationException("SetQuality is only valid for compress");
			}
			if (quality < 0 || quality > 11)
			{
				throw new ArgumentOutOfRangeException("quality", string.Concat(new object[]
				{
					"Quality should be a value between ",
					0,
					"-",
					11
				}));
			}
			this._0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A_000A();
			Brotli._0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020(ref this._0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020, Brotli.BrotliEncoderParameter.BROTLI_PARAM_QUALITY, (uint)quality);
		}

		// Token: 0x06003337 RID: 13111 RVA: 0x002D2E84 File Offset: 0x002D1084
		public unsafe void SetCustomDictionary(byte[] dictionary)
		{
			if (dictionary == null)
			{
				throw new ArgumentNullException("dictionary");
			}
			this._0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A_000A();
			if (this._0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(this._0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A);
			}
			this._0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A = Marshal.AllocHGlobal(dictionary.Length);
			Marshal.Copy(dictionary, 0, this._0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A, dictionary.Length);
			if (this._0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A == CompressionMode.Compress)
			{
				Brotli._0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A(ref this._0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020, dictionary.Length, (byte*)((void*)this._0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A));
				return;
			}
			Brotli._0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020(ref this._0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A, dictionary.Length, (byte*)((void*)this._0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A));
		}

		// Token: 0x06003338 RID: 13112 RVA: 0x002D2F28 File Offset: 0x002D1128
		public void SetWindow(int windowSize)
		{
			if (this._0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A != CompressionMode.Compress)
			{
				throw new InvalidOperationException("SetWindow is only valid for compress");
			}
			if (windowSize < 10 || windowSize > 24)
			{
				throw new ArgumentOutOfRangeException("windowSize", string.Concat(new object[]
				{
					"Window size should be a value between ",
					10,
					"-",
					24
				}));
			}
			this._0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A_000A();
			Brotli._0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020(ref this._0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020, Brotli.BrotliEncoderParameter.BROTLI_PARAM_LGWIN, (uint)windowSize);
		}

		// Token: 0x06003339 RID: 13113 RVA: 0x002D2FA4 File Offset: 0x002D11A4
		protected override void Dispose(bool disposing)
		{
			if (!this._0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020)
			{
				this._0020_0020_000A_000A_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_0020_000A(true);
				if (this._0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A == CompressionMode.Compress)
				{
					Brotli._0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_0020(ref this._0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020);
				}
				else
				{
					Brotli._0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A_0020(ref this._0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A);
				}
				if (this._0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(this._0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A);
					this._0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A = IntPtr.Zero;
				}
				this._0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020 = true;
			}
			if (disposing && !this._0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020 && this._0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020 != null)
			{
				this._0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020.Dispose();
				this._0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020 = null;
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600333A RID: 13114 RVA: 0x00071AE3 File Offset: 0x0006FCE3
		public override void Flush()
		{
			this._0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A_000A();
			this._0020_0020_000A_000A_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_0020_000A(false);
		}

		// Token: 0x0600333B RID: 13115 RVA: 0x002D303C File Offset: 0x002D123C
		internal void _0020_0020_000A_000A_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_0020_000A(bool _0020)
		{
			if (this._0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A != CompressionMode.Compress)
			{
				return;
			}
			if (Brotli._0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A(ref this._0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020))
			{
				return;
			}
			Brotli.BrotliEncoderOperation u0020_u000A_u000A = _0020 ? Brotli.BrotliEncoderOperation.BROTLI_OPERATION_FINISH : Brotli.BrotliEncoderOperation.BROTLI_OPERATION_FLUSH;
			byte[] u = new byte[0];
			this._0020_0020_000A_000A_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_0020_0020(u, 0, 0, u0020_u000A_u000A);
		}

		// Token: 0x0600333C RID: 13116 RVA: 0x000552CA File Offset: 0x000534CA
		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600333D RID: 13117 RVA: 0x000552CA File Offset: 0x000534CA
		public override void SetLength(long value)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600333E RID: 13118 RVA: 0x002D307C File Offset: 0x002D127C
		internal void _0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_0020(byte[] _0020, int _0020_000A, int _0020_0020)
		{
			if (_0020 == null)
			{
				throw new ArgumentNullException("array");
			}
			if (_0020_000A < 0)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			if (_0020_0020 < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (_0020.Length - _0020_000A < _0020_0020)
			{
				throw new ArgumentException("Invalid argument offset and count");
			}
		}

		// Token: 0x0600333F RID: 13119 RVA: 0x002D30C8 File Offset: 0x002D12C8
		public unsafe override int Read(byte[] buffer, int offset, int count)
		{
			if (this._0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A != CompressionMode.Decompress)
			{
				throw new InvalidOperationException("Read is only supported in Decompress mode");
			}
			this._0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A_000A();
			this._0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_0020(buffer, offset, count);
			bool flag = false;
			byte[] array = new byte[65535];
			Brotli._0020_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A u0020_u0020_u000A_u000A_u000A_u0020_u000A_u000A_u0020_u0020_u0020_u000A_u000A_u000A_u0020_u000A = 0;
			Brotli._0020_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A u0020_u0020_u000A_u000A_u000A_u0020_u000A_u000A_u0020_u0020_u0020_u000A_u000A_u000A_u0020_u000A2 = count;
			byte[] array2;
			byte* ptr;
			if ((array2 = array) == null || array2.Length == 0)
			{
				ptr = null;
			}
			else
			{
				ptr = &array2[0];
			}
			byte* ptr2;
			if (buffer == null || buffer.Length == 0)
			{
				ptr2 = null;
			}
			else
			{
				ptr2 = &buffer[0];
			}
			byte* ptr3 = ptr;
			byte* ptr4 = ptr2 + offset;
			int num = 0;
			for (;;)
			{
				if (this._0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020 == Brotli.BrotliDecoderResult.BROTLI_DECODER_RESULT_NEEDS_MORE_INPUT)
				{
					int num2 = this._0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020.Read(array, 0, array.Length);
					if (num2 <= 0)
					{
						break;
					}
					u0020_u0020_u000A_u000A_u000A_u0020_u000A_u000A_u0020_u0020_u0020_u000A_u000A_u000A_u0020_u000A = num2;
					ptr3 = ptr;
				}
				else if (this._0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020 != Brotli.BrotliDecoderResult.BROTLI_DECODER_RESULT_NEEDS_MORE_OUTPUT)
				{
					goto Block_6;
				}
				Brotli._0020_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A a = u0020_u0020_u000A_u000A_u000A_u0020_u000A_u000A_u0020_u0020_u0020_u000A_u000A_u000A_u0020_u000A2;
				this._0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020 = Brotli._0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A(ref this._0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A, &u0020_u0020_u000A_u000A_u000A_u0020_u000A_u000A_u0020_u0020_u0020_u000A_u000A_u000A_u0020_u000A, &ptr3, &u0020_u0020_u000A_u000A_u000A_u0020_u000A_u000A_u0020_u0020_u0020_u000A_u000A_u000A_u0020_u000A2, &ptr4, null);
				num += (int)(a - u0020_u0020_u000A_u000A_u000A_u0020_u000A_u000A_u0020_u0020_u0020_u000A_u000A_u000A_u0020_u000A2);
				if (num >= count)
				{
					goto IL_FC;
				}
			}
			flag = true;
			goto IL_FC;
			Block_6:
			flag = true;
			IL_FC:
			if (flag && this._0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020 != Brotli.BrotliDecoderResult.BROTLI_DECODER_RESULT_SUCCESS)
			{
				throw new InvalidDataException("Decompression failed with error code: " + this._0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A.error_code);
			}
			return num;
		}

		// Token: 0x06003340 RID: 13120 RVA: 0x002D3200 File Offset: 0x002D1400
		internal unsafe void _0020_0020_000A_000A_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_0020_0020(byte[] _0020, int _0020_000A, int _0020_0020, Brotli.BrotliEncoderOperation _0020_000A_000A)
		{
			bool flag = _0020_000A_000A == Brotli.BrotliEncoderOperation.BROTLI_OPERATION_FLUSH || _0020_000A_000A == Brotli.BrotliEncoderOperation.BROTLI_OPERATION_FINISH;
			byte[] array = new byte[131070];
			Brotli._0020_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A a = _0020_0020;
			Brotli._0020_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A u0020_u0020_u000A_u000A_u000A_u0020_u000A_u000A_u0020_u0020_u0020_u000A_u000A_u000A_u0020_u000A = array.Length;
			byte[] array2;
			byte* ptr;
			if ((array2 = array) == null || array2.Length == 0)
			{
				ptr = null;
			}
			else
			{
				ptr = &array2[0];
			}
			fixed (byte[] array3 = _0020)
			{
				byte* ptr2;
				if (_0020 == null || array3.Length == 0)
				{
					ptr2 = null;
				}
				else
				{
					ptr2 = &array3[0];
				}
				byte* ptr3 = ptr2 + _0020_000A;
				byte* ptr4 = ptr;
				while ((!flag && a > 0) || flag)
				{
					if (!Brotli._0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020(ref this._0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020, _0020_000A_000A, &a, &ptr3, &u0020_u0020_u000A_u000A_u000A_u0020_u000A_u000A_u0020_u0020_u0020_u000A_u000A_u000A_u0020_u000A, &ptr4, null))
					{
						throw new InvalidDataException("Compression failed");
					}
					bool flag2 = (ulong)u0020_u0020_u000A_u000A_u000A_u0020_u000A_u000A_u0020_u0020_u0020_u000A_u000A_u000A_u0020_u000A != (ulong)((long)array.Length);
					if (flag2)
					{
						int count = (int)(array.Length - u0020_u0020_u000A_u000A_u000A_u0020_u000A_u000A_u0020_u0020_u0020_u000A_u000A_u000A_u0020_u000A);
						this._0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020.Write(array, 0, count);
						u0020_u0020_u000A_u000A_u000A_u0020_u000A_u000A_u0020_u0020_u0020_u000A_u000A_u000A_u0020_u000A = array.Length;
						ptr4 = ptr;
					}
					if (Brotli._0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A(ref this._0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020) || (!flag2 && flag))
					{
						break;
					}
				}
			}
			array2 = null;
		}

		// Token: 0x06003341 RID: 13121 RVA: 0x00071AF2 File Offset: 0x0006FCF2
		public override void Write(byte[] buffer, int offset, int count)
		{
			if (this._0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A != CompressionMode.Compress)
			{
				throw new InvalidOperationException("Write is only supported in Compress mode");
			}
			this._0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A_000A();
			this._0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_0020(buffer, offset, count);
			this._0020_0020_000A_000A_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_0020_0020(buffer, offset, count, Brotli.BrotliEncoderOperation.BROTLI_OPERATION_PROCESS);
		}

		// Token: 0x17000694 RID: 1684
		// (get) Token: 0x06003342 RID: 13122 RVA: 0x00071B21 File Offset: 0x0006FD21
		public override bool CanRead
		{
			get
			{
				return this._0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020 != null && this._0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A == CompressionMode.Decompress && this._0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020.CanRead;
			}
		}

		// Token: 0x17000695 RID: 1685
		// (get) Token: 0x06003343 RID: 13123 RVA: 0x00056743 File Offset: 0x00054943
		public override bool CanSeek
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000696 RID: 1686
		// (get) Token: 0x06003344 RID: 13124 RVA: 0x00071B42 File Offset: 0x0006FD42
		public override bool CanWrite
		{
			get
			{
				return this._0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020 != null && this._0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A == CompressionMode.Compress && this._0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020.CanWrite;
			}
		}

		// Token: 0x17000697 RID: 1687
		// (get) Token: 0x06003345 RID: 13125 RVA: 0x000552CA File Offset: 0x000534CA
		public override long Length
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x17000698 RID: 1688
		// (get) Token: 0x06003346 RID: 13126 RVA: 0x000552CA File Offset: 0x000534CA
		// (set) Token: 0x06003347 RID: 13127 RVA: 0x000552CA File Offset: 0x000534CA
		public override long Position
		{
			get
			{
				throw new NotSupportedException();
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x06003348 RID: 13128 RVA: 0x00071B64 File Offset: 0x0006FD64
		internal void _0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A_000A()
		{
			if (this._0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020 == null)
			{
				throw new ObjectDisposedException(null, "The underlying stream has been disposed");
			}
			if (this._0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020)
			{
				throw new ObjectDisposedException(null);
			}
		}

		// Token: 0x04005BDB RID: 23515
		internal Stream _0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020;

		// Token: 0x04005BDC RID: 23516
		internal CompressionMode _0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A;

		// Token: 0x04005BDD RID: 23517
		internal bool _0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020;

		// Token: 0x04005BDE RID: 23518
		internal bool _0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020;

		// Token: 0x04005BDF RID: 23519
		internal IntPtr _0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A = IntPtr.Zero;

		// Token: 0x04005BE0 RID: 23520
		internal Brotli._0020_0020_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020 _0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020;

		// Token: 0x04005BE1 RID: 23521
		internal Brotli._0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A _0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A;

		// Token: 0x04005BE2 RID: 23522
		internal Brotli.BrotliDecoderResult _0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020 = Brotli.BrotliDecoderResult.BROTLI_DECODER_RESULT_NEEDS_MORE_INPUT;
	}
}

namespace BrotliSharpLib
{
	// Token: 0x02000D5B RID: 3419
	internal class _0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A
	{
		// Token: 0x06004BA0 RID: 19360 RVA: 0x0039488C File Offset: 0x00392A8C
		internal string _0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020(string _0020)
		{
			int num2;
			int num = num2 * 1310746288;
			return "1934212379";
		}
	}
}

namespace BrotliSharpLib
{
	// Token: 0x02000D5C RID: 3420
	internal class _0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A
	{
		// Token: 0x06004BA1 RID: 19361 RVA: 0x003948AC File Offset: 0x00392AAC
		internal void _0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020()
		{
			int num2;
			int num = num2 + 1528037255;
			int num3 = num2 ^ 466688125;
		}
	}
}

namespace BrotliSharpLib
{
	// Token: 0x02000D5D RID: 3421
	internal class _0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A
	{
		// Token: 0x06004BA2 RID: 19362 RVA: 0x003948D8 File Offset: 0x00392AD8
		internal object _0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020(FunctionControlParameterFactory _0020)
		{
			return null;
		}
	}
}

namespace BrotliSharpLib
{
	// Token: 0x02000D5E RID: 3422
	internal class _0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_0020_000A_000A
	{
		// Token: 0x06004BA3 RID: 19363 RVA: 0x003948E8 File Offset: 0x00392AE8
		internal void _0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020(decimal _0020, bool _0020_000A, _0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020_000A_0020_0020 _0020_0020, decimal _0020_000A_000A)
		{
			int num2;
			int num = num2 - 1120327145;
			((MainForm)null)._0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A(null, null);
			int num3 = num2 - 734450970;
			long zipFileIndex = ((_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020_0020_000A)null).ZipFileIndex;
		}
	}
}

namespace BrotliSharpLib
{
	// Token: 0x02000D5F RID: 3423
	internal class _0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A
	{
		// Token: 0x06004BA4 RID: 19364 RVA: 0x0039491C File Offset: 0x00392B1C
		internal int _0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020(string _0020, CultureFormatter _0020_000A, decimal _0020_0020)
		{
			return 1783500012;
		}
	}
}

namespace BrotliSharpLib
{
	// Token: 0x02000D60 RID: 3424
	internal class _0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A
	{
		// Token: 0x06004BA5 RID: 19365 RVA: 0x00394930 File Offset: 0x00392B30
		internal object _0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020(_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020_0020 _0020)
		{
			int num2;
			int num = num2 - 1896236243;
			GameRecoveryLicManager.License = null;
			int num3 = num2 + 1702902306;
			((_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020)null).SetEntryFactory(null);
			int num4 = num2 * 1043651838;
			int num5 = num2 ^ 2105405678;
			int num6 = num2 - 1585656321;
			((ImportSettings)null)._0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_0020_000A_000A_0020_000A_000A(null, null);
			return null;
		}
	}
}
