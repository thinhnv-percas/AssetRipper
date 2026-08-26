using System;

namespace Mono.Cecil
{
	public sealed class ModuleParameters
	{
		private ModuleKind kind;

		private TargetRuntime runtime;

		private TargetArchitecture architecture;

		private IAssemblyResolver assembly_resolver;

		private IMetadataResolver metadata_resolver;

		private IMetadataImporterProvider metadata_importer_provider;

		public ModuleKind Kind
		{
			get
			{
				return kind;
			}
			set
			{
				kind = value;
			}
		}

		public TargetRuntime Runtime
		{
			get
			{
				return runtime;
			}
			set
			{
				runtime = value;
			}
		}

		public TargetArchitecture Architecture
		{
			get
			{
				return architecture;
			}
			set
			{
				architecture = value;
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

		public ModuleParameters()
		{
			kind = ModuleKind.Dll;
			Runtime = GetCurrentRuntime();
			architecture = TargetArchitecture.I386;
		}

		private static TargetRuntime GetCurrentRuntime()
		{
			Version version = AssemblyNameReference.Parse(typeof(object).Assembly.FullName).Version;
			switch (version.Major)
			{
			case 1:
				if (version.Minor != 0)
				{
					return TargetRuntime.Net_1_1;
				}
				return TargetRuntime.Net_1_0;
			case 2:
				return TargetRuntime.Net_2_0;
			case 4:
				return TargetRuntime.Net_4_0;
			default:
				throw new NotSupportedException();
			}
		}
	}
}
