using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Wasm.Binary;

namespace Wasm
{
	public struct ResizableLimits
	{
		[CompilerGenerated]
		private uint _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020;

		[CompilerGenerated]
		private uint? _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_000A;

		public bool HasMaximum => Maximum.HasValue;

		public uint Initial
		{
			get;
			private set;
		}

		public uint? Maximum
		{
			get;
			private set;
		}

		public ResizableLimits(uint initial)
		{
			Initial = initial;
			Maximum = null;
		}

		public ResizableLimits(uint initial, uint maximum)
		{
			Initial = initial;
			Maximum = maximum;
		}

		public ResizableLimits(uint initial, uint? maximum)
		{
			Initial = initial;
			Maximum = maximum;
		}

		public void WriteTo(BinaryWasmWriter writer)
		{
			writer.WriteVarUInt1(HasMaximum);
			writer.WriteVarUInt32(Initial);
			if (HasMaximum)
			{
				writer.WriteVarUInt32(Maximum.Value);
			}
		}

		public void Dump(TextWriter writer)
		{
			writer.Write("{initial: ");
			writer.Write(Initial);
			if (HasMaximum)
			{
				writer.Write(", max: ");
				writer.Write(Maximum.Value);
			}
			writer.Write("}");
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			Dump(new StringWriter(stringBuilder));
			return stringBuilder.ToString();
		}
	}
}
