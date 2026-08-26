using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.ComponentModel.Composition.ReflectionModel;
using System.Linq;
using System.Reflection;

namespace Microsoft.VisualStudio.Composition;

public static class NetFxAdapters
{
	private class MefV1ExportProvider : System.ComponentModel.Composition.Hosting.ExportProvider
	{
		private class ComposablePartForExportFactory : ComposablePart, IDisposable
		{
			internal static readonly System.ComponentModel.Composition.Primitives.ExportDefinition ExportFactoryDefinitionSentinel = new System.ComponentModel.Composition.Primitives.ExportDefinition("ExportFactoryValue", ImmutableDictionary<string, object>.Empty);

			private readonly ExportLifetimeContext<object> value;

			public override IEnumerable<System.ComponentModel.Composition.Primitives.ExportDefinition> ExportDefinitions
			{
				get
				{
					throw new NotImplementedException();
				}
			}

			public override IEnumerable<System.ComponentModel.Composition.Primitives.ImportDefinition> ImportDefinitions
			{
				get
				{
					throw new NotImplementedException();
				}
			}

			internal ComposablePartForExportFactory(ExportLifetimeContext<object> value)
			{
				this.value = value;
			}

			public override object GetExportedValue(System.ComponentModel.Composition.Primitives.ExportDefinition definition)
			{
				if (definition == ExportFactoryDefinitionSentinel)
				{
					return value.Value;
				}
				throw new NotImplementedException();
			}

			public override void SetImport(System.ComponentModel.Composition.Primitives.ImportDefinition definition, IEnumerable<System.ComponentModel.Composition.Primitives.Export> exports)
			{
				throw new NotImplementedException();
			}

			public void Dispose()
			{
				value.Dispose();
			}
		}

		private class ComposablePartDefinitionForExportFactory : System.ComponentModel.Composition.Primitives.ComposablePartDefinition
		{
			private static readonly System.ComponentModel.Composition.Primitives.ExportDefinition[] SentinelExportDefinitionArray = new System.ComponentModel.Composition.Primitives.ExportDefinition[1] { ComposablePartForExportFactory.ExportFactoryDefinitionSentinel };

			private readonly ExportFactory<object, IDictionary<string, object>> exportFactory;

			public override IEnumerable<System.ComponentModel.Composition.Primitives.ExportDefinition> ExportDefinitions => SentinelExportDefinitionArray;

			public override IEnumerable<System.ComponentModel.Composition.Primitives.ImportDefinition> ImportDefinitions => Enumerable.Empty<System.ComponentModel.Composition.Primitives.ImportDefinition>();

			internal ComposablePartDefinitionForExportFactory(ExportFactory<object, IDictionary<string, object>> exportFactory)
			{
				Requires.NotNull(exportFactory, "exportFactory");
				this.exportFactory = exportFactory;
			}

			public override ComposablePart CreatePart()
			{
				return new ComposablePartForExportFactory(exportFactory.CreateExport());
			}
		}

		private static readonly Type ExportFactoryV1Type = typeof(ExportFactory<object, IDictionary<string, object>>);

		private static readonly Type IPartCreatorImportDefinition_MightFail = typeof(System.ComponentModel.Composition.Primitives.ImportDefinition).Assembly.GetType("System.ComponentModel.Composition.Primitives.IPartCreatorImportDefinition", throwOnError: false);

		private static readonly PropertyInfo ProductImportDefinition_MightFail = ((IPartCreatorImportDefinition_MightFail != null) ? IPartCreatorImportDefinition_MightFail.GetProperty("ProductImportDefinition", BindingFlags.Instance | BindingFlags.Public) : null);

		private static readonly string ExportFactoryV1TypeIdentity = PartDiscovery.GetContractName(ExportFactoryV1Type);

		private readonly ExportProvider exportProvider;

		internal MefV1ExportProvider(ExportProvider exportProvider)
		{
			Requires.NotNull(exportProvider, "exportProvider");
			this.exportProvider = exportProvider;
		}

		protected override IEnumerable<System.ComponentModel.Composition.Primitives.Export> GetExportsCore(System.ComponentModel.Composition.Primitives.ImportDefinition definition, AtomicComposition atomicComposition)
		{
			ImportDefinition importDefinition = WrapImportDefinition(definition);
			ImmutableList.CreateBuilder<System.ComponentModel.Composition.Primitives.Export>();
			return exportProvider.GetExports(importDefinition).Select(UnwrapExport).ToArray();
		}

		private static ImportDefinition WrapImportDefinition(System.ComponentModel.Composition.Primitives.ImportDefinition definition)
		{
			Requires.NotNull(definition, "definition");
			ContractBasedImportDefinition contractBasedImportDefinition = definition as ContractBasedImportDefinition;
			ImmutableHashSet<IImportSatisfiabilityConstraint> immutableHashSet = ImmutableHashSet<IImportSatisfiabilityConstraint>.Empty.Add(new ImportConstraint(definition));
			if (contractBasedImportDefinition != null)
			{
				immutableHashSet = immutableHashSet.Union(PartCreationPolicyConstraint.GetRequiredCreationPolicyConstraints(WrapCreationPolicy(contractBasedImportDefinition.RequiredCreationPolicy)));
			}
			ImportCardinality cardinality = ImportCardinality.ZeroOrMore;
			IReadOnlyDictionary<string, object> readOnlyDictionary = (IReadOnlyDictionary<string, object>)definition.Metadata;
			System.ComponentModel.Composition.Primitives.ImportDefinition exportFactoryProductImportDefinitionIfApplicable = GetExportFactoryProductImportDefinitionIfApplicable(definition);
			if (exportFactoryProductImportDefinitionIfApplicable != null)
			{
				ImportDefinition value = WrapImportDefinition(exportFactoryProductImportDefinitionIfApplicable);
				readOnlyDictionary = readOnlyDictionary.ToImmutableDictionary().Add("Microsoft.VisualStudio.Composition.ProductImportDefinition", value).Add("Microsoft.VisualStudio.Composition.ExportFactoryType", ExportFactoryV1Type);
			}
			return new ImportDefinition(definition.ContractName, cardinality, readOnlyDictionary, immutableHashSet);
		}

		private static System.ComponentModel.Composition.Primitives.ImportDefinition GetExportFactoryProductImportDefinitionIfApplicable(System.ComponentModel.Composition.Primitives.ImportDefinition definition)
		{
			if (IPartCreatorImportDefinition_MightFail != null && ProductImportDefinition_MightFail != null)
			{
				if (IPartCreatorImportDefinition_MightFail.IsInstanceOfType(definition))
				{
					return (System.ComponentModel.Composition.Primitives.ImportDefinition)ProductImportDefinition_MightFail.GetValue(definition);
				}
			}
			else
			{
				try
				{
					if (ReflectionModelServices.IsExportFactoryImportDefinition(definition))
					{
						return ReflectionModelServices.GetExportFactoryProductImportDefinition(definition);
					}
				}
				catch (ArgumentException)
				{
				}
			}
			return null;
		}

		private static IDictionary<string, object> GetMefV1ExportDefinitionMetadataFromV3(IReadOnlyDictionary<string, object> exportDefinitionMetadata)
		{
			Requires.NotNull(exportDefinitionMetadata, "exportDefinitionMetadata");
			ImmutableDictionary<string, object> immutableDictionary = exportDefinitionMetadata.ToImmutableDictionary();
			if (immutableDictionary.TryGetValue<CreationPolicy>("System.ComponentModel.Composition.CreationPolicy", out var value))
			{
				immutableDictionary = immutableDictionary.SetItem("System.ComponentModel.Composition.CreationPolicy", UnwrapCreationPolicy(value));
			}
			if (immutableDictionary.TryGetValue<ExportDefinition>("ProductDefinition", out var value2))
			{
				immutableDictionary = immutableDictionary.SetItem("ProductDefinition", new System.ComponentModel.Composition.Primitives.ExportDefinition(value2.ContractName, GetMefV1ExportDefinitionMetadataFromV3(value2.Metadata)));
			}
			return immutableDictionary;
		}

		private static System.ComponentModel.Composition.CreationPolicy UnwrapCreationPolicy(CreationPolicy creationPolicy)
		{
			return creationPolicy switch
			{
				CreationPolicy.Any => System.ComponentModel.Composition.CreationPolicy.Any, 
				CreationPolicy.Shared => System.ComponentModel.Composition.CreationPolicy.Shared, 
				CreationPolicy.NonShared => System.ComponentModel.Composition.CreationPolicy.NonShared, 
				_ => throw new ArgumentException(), 
			};
		}

		private static CreationPolicy WrapCreationPolicy(System.ComponentModel.Composition.CreationPolicy creationPolicy)
		{
			return creationPolicy switch
			{
				System.ComponentModel.Composition.CreationPolicy.Any => CreationPolicy.Any, 
				System.ComponentModel.Composition.CreationPolicy.Shared => CreationPolicy.Shared, 
				System.ComponentModel.Composition.CreationPolicy.NonShared => CreationPolicy.NonShared, 
				_ => throw new ArgumentException(), 
			};
		}

		private static System.ComponentModel.Composition.Primitives.Export UnwrapExport(Export export)
		{
			IDictionary<string, object> mefV1ExportDefinitionMetadataFromV = GetMefV1ExportDefinitionMetadataFromV3(export.Metadata);
			if (export.Definition.ContractName == ExportFactoryV1TypeIdentity)
			{
				return new System.ComponentModel.Composition.Primitives.Export("System.ComponentModel.Composition.Contracts.ExportFactory", mefV1ExportDefinitionMetadataFromV, () => new ComposablePartDefinitionForExportFactory((ExportFactory<object, IDictionary<string, object>>)export.Value));
			}
			return new System.ComponentModel.Composition.Primitives.Export(export.Definition.ContractName, mefV1ExportDefinitionMetadataFromV, () => UnwrapExportedValue(export.Value));
		}

		private static object UnwrapExportedValue(object value)
		{
			if (value is ExportedDelegate)
			{
				Delegate obj = ((ExportedDelegate)value).CreateDelegate(typeof(Delegate));
				return new System.ComponentModel.Composition.Primitives.ExportedDelegate(obj.Target, obj.Method);
			}
			return value;
		}
	}

	private class ImportConstraint : IImportSatisfiabilityConstraint, IEquatable<IImportSatisfiabilityConstraint>
	{
		private readonly System.ComponentModel.Composition.Primitives.ImportDefinition definition;

		internal ImportConstraint(System.ComponentModel.Composition.Primitives.ImportDefinition definition)
		{
			Requires.NotNull(definition, "definition");
			this.definition = definition;
		}

		public bool IsSatisfiedBy(ExportDefinition exportDefinition)
		{
			System.ComponentModel.Composition.Primitives.ExportDefinition exportDefinition2 = new System.ComponentModel.Composition.Primitives.ExportDefinition(exportDefinition.ContractName, (IDictionary<string, object>)exportDefinition.Metadata);
			return definition.IsConstraintSatisfiedBy(exportDefinition2);
		}

		public bool Equals(IImportSatisfiabilityConstraint obj)
		{
			if (!(obj is ImportConstraint importConstraint))
			{
				return false;
			}
			return definition.Equals(importConstraint.definition);
		}
	}

	[Export(typeof(ICompositionService))]
	[PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
	[PartMetadata("VsMEFDgmlCategories", new string[] { "VsMEFBuiltIn" })]
	private class CompositionService : ICompositionService, IDisposable
	{
		private CompositionContainer container;

		[ImportingConstructor]
		private CompositionService([Import] ExportProvider exportProvider)
		{
			Requires.NotNull(exportProvider, "exportProvider");
			container = new CompositionContainer(CompositionOptions.IsThreadSafe, exportProvider.AsExportProvider());
		}

		public void SatisfyImportsOnce(ComposablePart part)
		{
			container.SatisfyImportsOnce(part);
		}

		public void Dispose()
		{
			container.Dispose();
		}
	}

	private static readonly ComposablePartDefinition CompositionServicePart;

	static NetFxAdapters()
	{
		CompositionServicePart = new AttributedPartDiscoveryV1(Resolver.DefaultInstance).CreatePart(typeof(CompositionService));
	}

	public static System.ComponentModel.Composition.Hosting.ExportProvider AsExportProvider(this ExportProvider exportProvider)
	{
		Requires.NotNull(exportProvider, "exportProvider");
		return new MefV1ExportProvider(exportProvider);
	}

	public static ComposableCatalog WithCompositionService(this ComposableCatalog catalog)
	{
		Requires.NotNull(catalog, "catalog");
		return catalog.AddPart(CompositionServicePart);
	}

	[Obsolete("Desktop support is automatically included when run on the .NET Framework.")]
	public static ComposableCatalog WithDesktopSupport(this ComposableCatalog catalog)
	{
		Requires.NotNull(catalog, "catalog");
		return catalog;
	}
}
