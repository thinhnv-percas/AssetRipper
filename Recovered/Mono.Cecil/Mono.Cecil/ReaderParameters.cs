using Mono.Cecil.Cil;
using System.IO;

namespace Mono.Cecil
{
	public sealed class ReaderParameters
	{
		private ReadingMode reading_mode;

		internal IAssemblyResolver assembly_resolver;

		internal IMetadataResolver metadata_resolver;

		internal IMetadataImporterProvider metadata_importer_provider;

		private Stream symbol_stream;

		private ISymbolReaderProvider symbol_reader_provider;

		private bool read_symbols;

		public ReadingMode ReadingMode
		{
			get
			{
				return reading_mode;
			}
			set
			{
				reading_mode = value;
			}
		}

		public IAssemblyResolver AssemblyResolver
		{
			get
			{
				return assembly_resolver;
			}
			set
			{
				assembly_resolver = value;
			}
		}

		public IMetadataResolver MetadataResolver
		{
			get
			{
				return metadata_resolver;
			}
			set
			{
				metadata_resolver = value;
			}
		}

		public IMetadataImporterProvider MetadataImporterProvider
		{
			get
			{
				return metadata_importer_provider;
			}
			set
			{
				metadata_importer_provider = value;
			}
		}

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

		public ISymbolReaderProvider SymbolReaderProvider
		{
			get
			{
				return symbol_reader_provider;
			}
			set
			{
				symbol_reader_provider = value;
			}
		}

		public bool ReadSymbols
		{
			get
			{
				return read_symbols;
			}
			set
			{
				read_symbols = value;
			}
		}

		public ReaderParameters()
			: this(ReadingMode.Deferred)
		{
		}

		public ReaderParameters(ReadingMode readingMode)
		{
			reading_mode = readingMode;
		}
	}
}
