using @as;
using DevXForms;
using DevXForms.TreeList;
using DSMCaps;
using DSMCaps.M68K;
using ICSharpCode.SharpZipLib.GZip;
using LZ4pn;
using LZ4ps;
using System.Collections.Generic;
using XnaGeometry;

namespace LZ4.Services
{
	internal class _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A : ILZ4Service
	{
		public string CodecName => "Safe 32";

		public int Encode(byte[] input, int inputOffset, int inputLength, byte[] output, int outputOffset, int outputLength)
		{
			return LZ4ps.LZ4Codec.Encode32(input, inputOffset, inputLength, output, outputOffset, outputLength);
		}

		public int Decode(byte[] input, int inputOffset, int inputLength, byte[] output, int outputOffset, int outputLength, bool knownOutputLength)
		{
			return LZ4ps.LZ4Codec.Decode32(input, inputOffset, inputLength, output, outputOffset, outputLength, knownOutputLength);
		}

		public int EncodeHC(byte[] input, int inputOffset, int inputLength, byte[] output, int outputOffset, int outputLength)
		{
			return LZ4ps.LZ4Codec.Encode32HC(input, inputOffset, inputLength, output, outputOffset, outputLength);
		}
	}
	internal class _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020 : ILZ4Service
	{
		public string CodecName => "Safe 64";

		public int Encode(byte[] input, int inputOffset, int inputLength, byte[] output, int outputOffset, int outputLength)
		{
			return LZ4ps.LZ4Codec.Encode64(input, inputOffset, inputLength, output, outputOffset, outputLength);
		}

		public int Decode(byte[] input, int inputOffset, int inputLength, byte[] output, int outputOffset, int outputLength, bool knownOutputLength)
		{
			return LZ4ps.LZ4Codec.Decode64(input, inputOffset, inputLength, output, outputOffset, outputLength, knownOutputLength);
		}

		public int EncodeHC(byte[] input, int inputOffset, int inputLength, byte[] output, int outputOffset, int outputLength)
		{
			return LZ4ps.LZ4Codec.Encode64HC(input, inputOffset, inputLength, output, outputOffset, outputLength);
		}
	}
	internal class _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_000A : ILZ4Service
	{
		public string CodecName => "Unsafe 32";

		public int Encode(byte[] input, int inputOffset, int inputLength, byte[] output, int outputOffset, int outputLength)
		{
			return LZ4pn.LZ4Codec.Encode32(input, inputOffset, inputLength, output, outputOffset, outputLength);
		}

		public int Decode(byte[] input, int inputOffset, int inputLength, byte[] output, int outputOffset, int outputLength, bool knownOutputLength)
		{
			return LZ4pn.LZ4Codec.Decode32(input, inputOffset, inputLength, output, outputOffset, outputLength, knownOutputLength);
		}

		public int EncodeHC(byte[] input, int inputOffset, int inputLength, byte[] output, int outputOffset, int outputLength)
		{
			return LZ4pn.LZ4Codec.Encode32HC(input, inputOffset, inputLength, output, outputOffset, outputLength);
		}
	}
	internal class _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020 : ILZ4Service
	{
		public string CodecName => "Unsafe 64";

		public int Encode(byte[] input, int inputOffset, int inputLength, byte[] output, int outputOffset, int outputLength)
		{
			return LZ4pn.LZ4Codec.Encode64(input, inputOffset, inputLength, output, outputOffset, outputLength);
		}

		public int Decode(byte[] input, int inputOffset, int inputLength, byte[] output, int outputOffset, int outputLength, bool knownOutputLength)
		{
			return LZ4pn.LZ4Codec.Decode64(input, inputOffset, inputLength, output, outputOffset, outputLength, knownOutputLength);
		}

		public int EncodeHC(byte[] input, int inputOffset, int inputLength, byte[] output, int outputOffset, int outputLength)
		{
			return LZ4pn.LZ4Codec.Encode64HC(input, inputOffset, inputLength, output, outputOffset, outputLength);
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A
	{
		internal string _0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020(ref Vector2 _0020, ref Vector2 _0020_000A, ref Vector2 _0020_0020)
		{
			FormatUtils._0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_000A(null);
			return "1167158978";
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_000A_000A_000A_000A
	{
		internal int _0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020(TextFormatting _0020, decimal _0020_000A, _0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020_0020 _0020_0020, string _0020_000A_000A)
		{
			return 2065568719;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020_000A
	{
		// Dead decoy method removed (referenced an unresolved IL generic-parameter leak escaped as unbound generic syntax, e.g. `!0`/`!!0`); see FINDINGS.md §5.
	}
	internal class _0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020_000A_000A
	{
		internal object _0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020()
		{
			((ManyCodeCls)null)._0020_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A((string)null, (TreeNode[])null);
			return null;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A
	{
		internal string _0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020(byte[] _0020)
		{
			int displacement = ((M68KBranchDisplacementOperandValue)null).Displacement;
			return "508179250";
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A
	{
		internal void _0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020()
		{
			byte offset = ((M68KMemoryOperandValue)null).Offset;
		}
	}
}
