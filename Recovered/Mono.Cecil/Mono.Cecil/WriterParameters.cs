using Mono.Cecil.Cil;
using System.IO;

namespace Mono.Cecil
{
	public sealed class WriterParameters
	{
		private Stream symbol_stream;

		private ISymbolWriterProvider symbol_writer_provider;

		private bool write_symbols;

		public Stream SymbolStream
		{
			get
			{
				return symbol_stream;
			}
			set
			{
				symbol_stream = value;
			}
		}

		public ISymbolWriterProvider SymbolWriterProvider
		{
			get
			{
				return symbol_writer_provider;
			}
			set
			{
				symbol_writer_provider = value;
			}
		}

		public bool WriteSymbols
		{
			get
			{
				return write_symbols;
			}
			set
			{
				write_symbols = value;
			}
		}
	}
}
