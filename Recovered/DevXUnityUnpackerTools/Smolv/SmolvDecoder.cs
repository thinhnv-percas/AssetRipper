using System;
using System.IO;
using System.Text;

namespace Smolv
{
	public class SmolvDecoder
	{
		public const uint SpirVHeaderMagic = 119734787u;

		public const uint SmolHeaderMagic = 1397575500u;

		internal const int _0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_000A = 24;

		public static int GetDecodedBufferSize(byte[] data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			if (!_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_000A_0020(data))
			{
				return 0;
			}
			return BitConverter.ToInt32(data, 20);
		}

		public static int GetDecodedBufferSize(Stream stream)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			if (!stream.CanSeek)
			{
				throw new ArgumentException("stream");
			}
			if (stream.Position + 24 > stream.Length)
			{
				return 0;
			}
			long position = stream.Position;
			stream.Position += 20L;
			int result = stream.ReadByte() | (stream.ReadByte() << 8) | (stream.ReadByte() << 16) | (stream.ReadByte() << 24);
			stream.Position = position;
			return result;
		}

		public static byte[] Decode(byte[] data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			int decodedBufferSize = GetDecodedBufferSize(data);
			if (decodedBufferSize == 0)
			{
				return null;
			}
			byte[] array = new byte[decodedBufferSize];
			if (Decode(data, array))
			{
				return array;
			}
			return null;
		}

		public static bool Decode(byte[] data, byte[] output)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			if (output == null)
			{
				throw new ArgumentNullException("output");
			}
			if (GetDecodedBufferSize(data) > output.Length)
			{
				return false;
			}
			using (MemoryStream outputStream = new MemoryStream(output))
			{
				return Decode(data, outputStream);
			}
		}

		public static bool Decode(byte[] data, Stream outputStream)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			using (MemoryStream inputStream = new MemoryStream(data))
			{
				return Decode(inputStream, data.Length, outputStream);
			}
		}

		public static bool Decode(Stream inputStream, int inputSize, Stream outputStream)
		{
			if (inputStream == null)
			{
				throw new ArgumentNullException("inputStream");
			}
			if (outputStream == null)
			{
				throw new ArgumentNullException("outputStream");
			}
			if (inputStream.Length < 24)
			{
				return false;
			}
			using (BinaryReader binaryReader = new BinaryReader(new CustomStream(inputStream), Encoding.UTF8))
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(new CustomStream(outputStream), Encoding.UTF8))
				{
					long num = binaryReader.BaseStream.Position + inputSize;
					long position = binaryWriter.BaseStream.Position;
					binaryWriter.Write(119734787u);
					binaryReader.BaseStream.Position += 4L;
					uint value = binaryReader.ReadUInt32();
					binaryWriter.Write(value);
					uint value2 = binaryReader.ReadUInt32();
					binaryWriter.Write(value2);
					int value3 = binaryReader.ReadInt32();
					binaryWriter.Write(value3);
					uint value4 = binaryReader.ReadUInt32();
					binaryWriter.Write(value4);
					int num2 = binaryReader.ReadInt32();
					int num3 = 0;
					int num4 = 0;
					while (binaryReader.BaseStream.Position < num)
					{
						if (!_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A(binaryReader, out uint num5, out SpvOp spvOp))
						{
							return false;
						}
						bool flag = spvOp == SpvOp.VectorShuffleCompact;
						if (flag)
						{
							spvOp = SpvOp.VectorShuffle;
						}
						binaryWriter.Write((uint)((int)(num5 << 16) | (int)spvOp));
						uint num6 = 1u;
						if (spvOp.OpHasType())
						{
							if (!_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_0020(binaryReader, out uint value5))
							{
								return false;
							}
							binaryWriter.Write(value5);
							num6++;
						}
						if (spvOp.OpHasResult())
						{
							if (!_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_0020(binaryReader, out uint _0020))
							{
								return false;
							}
							int num7 = num3 + _0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A_000A(_0020);
							binaryWriter.Write(num7);
							num3 = num7;
							num6++;
						}
						if (spvOp == SpvOp.Decorate || spvOp == SpvOp.MemberDecorate)
						{
							if (!_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_0020(binaryReader, out uint num8))
							{
								return false;
							}
							int num9 = num4 + (int)num8;
							binaryWriter.Write(num9);
							num4 = num9;
							num6++;
						}
						int num10 = spvOp.OpDeltaFromResult();
						bool flag2 = false;
						if (num10 < 0)
						{
							flag2 = true;
							num10 = -num10;
						}
						int num11 = 0;
						while (num11 < num10 && num6 < num5)
						{
							if (!_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_0020(binaryReader, out uint num12))
							{
								return false;
							}
							int num13 = flag2 ? _0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A_000A(num12) : ((int)num12);
							binaryWriter.Write(num3 - num13);
							num11++;
							num6++;
						}
						if (flag && num5 <= 9)
						{
							uint num14 = binaryReader.ReadByte();
							if (num5 > 5)
							{
								binaryWriter.Write(num14 >> 6);
							}
							if (num5 > 6)
							{
								binaryWriter.Write((num14 >> 4) & 3);
							}
							if (num5 > 7)
							{
								binaryWriter.Write((num14 >> 2) & 3);
							}
							if (num5 > 8)
							{
								binaryWriter.Write(num14 & 3);
							}
						}
						else if (spvOp.OpVarRest())
						{
							for (; num6 < num5; num6++)
							{
								if (!_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_0020(binaryReader, out uint value6))
								{
									return false;
								}
								binaryWriter.Write(value6);
							}
						}
						else
						{
							for (; num6 < num5; num6++)
							{
								if (binaryReader.BaseStream.Position + 4 > binaryReader.BaseStream.Length)
								{
									return false;
								}
								uint value7 = binaryReader.ReadUInt32();
								binaryWriter.Write(value7);
							}
						}
					}
					if (binaryWriter.BaseStream.Position != position + num2)
					{
						return false;
					}
					return true;
				}
			}
		}

		internal static bool _0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_000A_0020(byte[] _0020)
		{
			if (!_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A(_0020, 1397575500u))
			{
				return false;
			}
			return true;
		}

		internal static bool _0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A(byte[] _0020, uint _0020_000A)
		{
			if (_0020 == null)
			{
				return false;
			}
			if (_0020.Length < 24)
			{
				return false;
			}
			if (BitConverter.ToUInt32(_0020, 0) != _0020_000A)
			{
				return false;
			}
			uint num = BitConverter.ToUInt32(_0020, 4);
			if (num < 65536 || num > 66304)
			{
				return false;
			}
			return true;
		}

		internal static bool _0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_0020(BinaryReader _0020, out uint _0020_000A)
		{
			uint num = 0u;
			int num2 = 0;
			while (_0020.BaseStream.Position < _0020.BaseStream.Length)
			{
				byte b = _0020.ReadByte();
				num = (uint)((int)num | ((b & 0x7F) << num2));
				num2 += 7;
				if ((b & 0x80) == 0)
				{
					break;
				}
			}
			_0020_000A = num;
			return true;
		}

		internal static bool _0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A(BinaryReader _0020, out uint _0020_000A, out SpvOp _0020_0020)
		{
			_0020_000A = 0u;
			_0020_0020 = SpvOp.Nop;
			if (!_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_0020(_0020, out uint num))
			{
				return false;
			}
			_0020_000A = ((num >> 20 << 4) | ((num >> 4) & 0xF));
			_0020_0020 = (SpvOp)(((num >> 4) & 0xFFF0) | (num & 0xF));
			_0020_0020 = _0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020(_0020_0020);
			_0020_000A = _0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_0020_000A(_0020_0020, _0020_000A);
			return true;
		}

		internal static SpvOp _0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020(SpvOp _0020)
		{
			switch (_0020)
			{
			case SpvOp.Decorate:
				return SpvOp.Nop;
			case SpvOp.Nop:
				return SpvOp.Decorate;
			case SpvOp.Load:
				return SpvOp.Undef;
			case SpvOp.Undef:
				return SpvOp.Load;
			case SpvOp.Store:
				return SpvOp.SourceContinued;
			case SpvOp.SourceContinued:
				return SpvOp.Store;
			case SpvOp.AccessChain:
				return SpvOp.Source;
			case SpvOp.Source:
				return SpvOp.AccessChain;
			case SpvOp.VectorShuffle:
				return SpvOp.SourceExtension;
			case SpvOp.SourceExtension:
				return SpvOp.VectorShuffle;
			case SpvOp.MemberDecorate:
				return SpvOp.String;
			case SpvOp.String:
				return SpvOp.MemberDecorate;
			case SpvOp.Label:
				return SpvOp.Line;
			case SpvOp.Line:
				return SpvOp.Label;
			case SpvOp.Variable:
				return (SpvOp)9;
			case (SpvOp)9:
				return SpvOp.Variable;
			case SpvOp.FMul:
				return SpvOp.Extension;
			case SpvOp.Extension:
				return SpvOp.FMul;
			case SpvOp.FAdd:
				return SpvOp.ExtInstImport;
			case SpvOp.ExtInstImport:
				return SpvOp.FAdd;
			case SpvOp.TypePointer:
				return SpvOp.MemoryModel;
			case SpvOp.MemoryModel:
				return SpvOp.TypePointer;
			case SpvOp.FNegate:
				return SpvOp.EntryPoint;
			case SpvOp.EntryPoint:
				return SpvOp.FNegate;
			default:
				return _0020;
			}
		}

		internal static uint _0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_0020_000A(SpvOp _0020, uint _0020_000A)
		{
			_0020_000A++;
			switch (_0020)
			{
			case SpvOp.VectorShuffle:
				_0020_000A += 4;
				break;
			case SpvOp.VectorShuffleCompact:
				_0020_000A += 4;
				break;
			case SpvOp.Decorate:
				_0020_000A += 2;
				break;
			case SpvOp.Load:
				_0020_000A += 3;
				break;
			case SpvOp.AccessChain:
				_0020_000A += 3;
				break;
			}
			return _0020_000A;
		}

		internal static int _0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_0020_0020(int _0020)
		{
			switch (_0020)
			{
			case 0:
			case 2:
			case 3:
			case 4:
			case 5:
				return 0;
			default:
				if (_0020 >= 29 && _0020 <= 37)
				{
					return 1;
				}
				return -1;
			}
		}

		internal static int _0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A_000A(uint _0020)
		{
			if ((_0020 & 1) == 0)
			{
				return (int)(_0020 >> 1);
			}
			return (int)(~(_0020 >> 1));
		}
	}
}
