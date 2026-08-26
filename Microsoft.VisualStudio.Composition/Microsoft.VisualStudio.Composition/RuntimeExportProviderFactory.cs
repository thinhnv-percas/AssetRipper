using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.Composition.Reflection;

namespace Microsoft.VisualStudio.Composition;

internal class RuntimeExportProviderFactory : IFaultReportingExportProviderFactory, IExportProviderFactory
{
	private class RuntimeExportProvider : ExportProvider
	{
		private struct ValueForImportSite
		{
			public bool ValueShouldBeSet { get; private set; }

			public object Value { get; private set; }

			internal ValueForImportSite(object value)
			{
				this = default(ValueForImportSite);
				Value = value;
				ValueShouldBeSet = true;
			}
		}

		private struct ExportedValueConstructor
		{
			public Func<object> ValueConstructor { get; private set; }

			public PartLifecycleTracker ExportingPart { get; private set; }

			public ExportedValueConstructor(PartLifecycleTracker exportingPart, Func<object> valueConstructor)
			{
				this = default(ExportedValueConstructor);
				Requires.NotNull(valueConstructor, "valueConstructor");
				ExportingPart = exportingPart;
				ValueConstructor = valueConstructor;
			}
		}

		[DebuggerDisplay("{partDefinition.TypeRef.ResolvedType.FullName,nq} ({State})")]
		private class RuntimePartLifecycleTracker : PartLifecycleTracker
		{
			private readonly RuntimeComposition.RuntimePart partDefinition;

			private readonly IReadOnlyDictionary<string, object> importMetadata;

			protected new RuntimeExportProvider OwningExportProvider => (RuntimeExportProvider)base.OwningExportProvider;

			protected Resolver Resolver => OwningExportProvider.Resolver;

			protected override Type PartType => partDefinition.TypeRef.Resolve();

			public RuntimePartLifecycleTracker(RuntimeExportProvider owningExportProvider, RuntimeComposition.RuntimePart partDefinition, IReadOnlyDictionary<string, object> importMetadata)
				: base(owningExportProvider, partDefinition.SharingBoundary)
			{
				Requires.NotNull(partDefinition, "partDefinition");
				Requires.NotNull(importMetadata, "importMetadata");
				this.partDefinition = partDefinition;
				this.importMetadata = importMetadata;
			}

			internal new void ReportPartiallyInitializedImport(PartLifecycleTracker part)
			{
				base.ReportPartiallyInitializedImport(part);
			}

			protected override object CreateValue()
			{
				if (partDefinition.TypeRef.Equals(ExportProvider.ExportProviderPartDefinition.TypeRef))
				{
					return OwningExportProvider.NonDisposableWrapper.Value;
				}
				if (!partDefinition.IsInstantiable)
				{
					return null;
				}
				TypeRef partConstructedTypeRef = GetPartConstructedTypeRef(partDefinition, importMetadata);
				object[] parameters = partDefinition.ImportingConstructorArguments.Select((RuntimeComposition.RuntimeImport import) => OwningExportProvider.GetValueForImportSite(this, import).Value).ToArray();
				ConstructorInfo constructorInfo = partDefinition.ImportingConstructor;
				if (constructorInfo.ContainsGenericParameters)
				{
					constructorInfo = partConstructedTypeRef.Resolve().GetTypeInfo().DeclaredConstructors.First((ConstructorInfo ctor) => true);
				}
				try
				{
					return constructorInfo.Invoke(parameters);
				}
				catch (TargetInvocationException ex)
				{
					throw PrepareExceptionForFaultedPart(ex);
				}
			}

			protected override void SatisfyImports()
			{
				if (base.Value == null && partDefinition.ImportingMembers.Count > 0)
				{
					ThrowPartNotInstantiableException();
				}
				try
				{
					foreach (RuntimeComposition.RuntimeImport importingMember in partDefinition.ImportingMembers)
					{
						try
						{
							ValueForImportSite valueForImportSite = OwningExportProvider.GetValueForImportSite(this, importingMember);
							if (valueForImportSite.ValueShouldBeSet)
							{
								SetImportingMember(base.Value, importingMember.ImportingMember, valueForImportSite.Value);
							}
						}
						catch (CompositionFailedException innerException)
						{
							throw new CompositionFailedException(string.Format(CultureInfo.CurrentCulture, Strings.ErrorWhileSettingImport, new object[1] { RuntimeComposition.GetDiagnosticLocation(importingMember) }), innerException);
						}
					}
				}
				catch (TargetInvocationException ex)
				{
					throw PrepareExceptionForFaultedPart(ex);
				}
			}

			protected override void InvokeOnImportsSatisfied()
			{
				if (partDefinition.OnImportsSatisfied != null)
				{
					try
					{
						partDefinition.OnImportsSatisfied.Invoke(base.Value, ExportProvider.EmptyObjectArray);
					}
					catch (TargetInvocationException ex)
					{
						throw PrepareExceptionForFaultedPart(ex);
					}
				}
			}

			private Exception PrepareExceptionForFaultedPart(TargetInvocationException ex)
			{
				return new CompositionFailedException(string.Format(CultureInfo.CurrentCulture, Strings.ExceptionThrownByPartUnderInitialization, new object[1] { PartType.FullName }), ex.InnerException);
			}
		}

		private const BindingFlags DeclaredOnlyLookup = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

		private static readonly RuntimeComposition.RuntimeImport MetadataViewProviderImport = new RuntimeComposition.RuntimeImport(default(MemberRef), TypeRef.Get(typeof(IMetadataViewProvider), Resolver.DefaultInstance), ImportCardinality.ExactlyOne, ImmutableList<RuntimeComposition.RuntimeExport>.Empty, isNonSharedInstanceRequired: false, isExportFactory: false, ImmutableDictionary<string, object>.Empty, ImmutableHashSet<string>.Empty);

		private readonly RuntimeComposition composition;

		private readonly ReportFaultCallback faultCallback;

		internal RuntimeExportProvider(RuntimeComposition composition, ReportFaultCallback faultCallback)
			: this(composition)
		{
			this.faultCallback = faultCallback;
		}

		internal RuntimeExportProvider(RuntimeComposition composition)
			: base(Requires.NotNull(composition, "composition").Resolver)
		{
			this.composition = composition;
		}

		internal RuntimeExportProvider(RuntimeComposition composition, ExportProvider parent, ImmutableHashSet<string> freshSharingBoundaries)
			: base(parent, freshSharingBoundaries)
		{
			Requires.NotNull(composition, "composition");
			this.composition = composition;
		}

		protected override IEnumerable<ExportInfo> GetExportsCore(ImportDefinition importDefinition)
		{
			return from export in composition.GetExports(importDefinition.ContractName)
				let part = composition.GetPart(export)
				let isValueFactoryRequired = export.Member == null || !export.Member.IsStatic()
				select CreateExport(importDefinition, export.Metadata, part.TypeRef, GetPartConstructedTypeRef(part, importDefinition.Metadata), part.SharingBoundary, !part.IsShared || PartCreationPolicyConstraint.IsNonSharedInstanceRequired(importDefinition), export.Member);
		}

		protected internal override PartLifecycleTracker CreatePartLifecycleTracker(TypeRef partType, IReadOnlyDictionary<string, object> importMetadata)
		{
			return new RuntimePartLifecycleTracker(this, composition.GetPart(partType), importMetadata);
		}

		internal override IMetadataViewProvider GetMetadataViewProvider(Type metadataView)
		{
			if (composition.MetadataViewsAndProviders.TryGetValue(TypeRef.Get(metadataView, base.Resolver), out var value))
			{
				return (IMetadataViewProvider)GetExportedValue(MetadataViewProviderImport, value, null).ValueConstructor();
			}
			return base.GetMetadataViewProvider(metadataView);
		}

		private void ThrowIfExportedValueIsNotAssignableToImport(RuntimeComposition.RuntimeImport import, RuntimeComposition.RuntimeExport export, object exportedValue)
		{
			Requires.NotNull(import, "import");
			Requires.NotNull(export, "export");
			if (exportedValue != null && !import.ImportingSiteTypeWithoutCollection.GetTypeInfo().IsAssignableFrom(exportedValue.GetType()))
			{
				throw new CompositionFailedException(string.Format(CultureInfo.CurrentCulture, Strings.ExportedValueNotAssignableToImport, new object[2]
				{
					RuntimeComposition.GetDiagnosticLocation(export),
					RuntimeComposition.GetDiagnosticLocation(import)
				}));
			}
		}

		private ValueForImportSite GetValueForImportSite(RuntimePartLifecycleTracker importingPartTracker, RuntimeComposition.RuntimeImport import)
		{
			Requires.NotNull(import, "import");
			Func<Func<object>, object, object> lazyFactory = import.LazyFactory;
			IReadOnlyCollection<RuntimeComposition.RuntimeExport> satisfyingExports = import.SatisfyingExports;
			if (import.Cardinality == ImportCardinality.ZeroOrMore)
			{
				if (import.ImportingSiteType.IsArray || (import.ImportingSiteType.GetTypeInfo().IsGenericType && import.ImportingSiteType.GetGenericTypeDefinition().IsEquivalentTo(typeof(IEnumerable<>))))
				{
					Array array = Array.CreateInstance(import.ImportingSiteTypeWithoutCollection, satisfyingExports.Count);
					using (Rental<int[]> rental = ArrayRental<int>.Get(1))
					{
						int num = 0;
						foreach (RuntimeComposition.RuntimeExport item in satisfyingExports)
						{
							rental.Value[0] = num++;
							object valueForImportElement = GetValueForImportElement(importingPartTracker, import, item, lazyFactory);
							ThrowIfExportedValueIsNotAssignableToImport(import, item, valueForImportElement);
							array.SetValue(valueForImportElement, rental.Value);
						}
					}
					return new ValueForImportSite(array);
				}
				object obj = null;
				MemberInfo importingMember = import.ImportingMember;
				if (importingMember != null)
				{
					obj = GetImportingMember(importingPartTracker.Value, importingMember);
				}
				bool flag = obj != null;
				if (!flag)
				{
					if (!PartDiscovery.IsImportManyCollectionTypeCreateable(import.ImportingSiteType, import.ImportingSiteTypeWithoutCollection))
					{
						throw new CompositionFailedException(Strings.UnableToInstantiateCustomImportCollectionType);
					}
					using (Rental<Type[]> rental2 = ArrayRental<Type>.Get(1))
					{
						rental2.Value[0] = import.ImportingSiteTypeWithoutCollection;
						Type type = typeof(List<>).MakeGenericType(rental2.Value);
						obj = ((!import.ImportingSiteType.GetTypeInfo().IsAssignableFrom(type.GetTypeInfo())) ? Activator.CreateInstance(import.ImportingSiteType) : Activator.CreateInstance(type));
					}
					SetImportingMember(importingPartTracker.Value, importingMember, obj);
				}
				ICollection<object> collectionWrapper = CollectionServices.GetCollectionWrapper(import.ImportingSiteTypeWithoutCollection, obj);
				if (flag)
				{
					collectionWrapper.Clear();
				}
				foreach (RuntimeComposition.RuntimeExport item2 in satisfyingExports)
				{
					object valueForImportElement2 = GetValueForImportElement(importingPartTracker, import, item2, lazyFactory);
					ThrowIfExportedValueIsNotAssignableToImport(import, item2, valueForImportElement2);
					collectionWrapper.Add(valueForImportElement2);
				}
				return default(ValueForImportSite);
			}
			RuntimeComposition.RuntimeExport runtimeExport = satisfyingExports.FirstOrDefault();
			if (runtimeExport == null)
			{
				return new ValueForImportSite(null);
			}
			object valueForImportElement3 = GetValueForImportElement(importingPartTracker, import, runtimeExport, lazyFactory);
			ThrowIfExportedValueIsNotAssignableToImport(import, runtimeExport, valueForImportElement3);
			return new ValueForImportSite(valueForImportElement3);
		}

		private object GetValueForImportElement(RuntimePartLifecycleTracker importingPartTracker, RuntimeComposition.RuntimeImport import, RuntimeComposition.RuntimeExport export, Func<Func<object>, object, object> lazyFactory)
		{
			if (import.IsExportFactory)
			{
				return CreateExportFactory(importingPartTracker, import, export);
			}
			if (import.IsLazy)
			{
				Requires.NotNull(lazyFactory, "lazyFactory");
			}
			if (composition.GetPart(export).TypeRef.Equals(import.DeclaringTypeRef))
			{
				object part = importingPartTracker.Value;
				if (!import.IsLazy)
				{
					return part;
				}
				return lazyFactory(() => part, GetStrongTypedMetadata(export.Metadata, import.MetadataType ?? LazyServices.DefaultMetadataViewType));
			}
			ExportedValueConstructor exportedValue = GetExportedValue(import, export, importingPartTracker);
			if (!import.IsLazy)
			{
				return exportedValue.ValueConstructor();
			}
			return lazyFactory(exportedValue.ValueConstructor, GetStrongTypedMetadata(export.Metadata, import.MetadataType ?? LazyServices.DefaultMetadataViewType));
		}

		private object CreateExportFactory(RuntimePartLifecycleTracker importingPartTracker, RuntimeComposition.RuntimeImport import, RuntimeComposition.RuntimeExport export)
		{
			Requires.NotNull(importingPartTracker, "importingPartTracker");
			Requires.NotNull(import, "import");
			Requires.NotNull(export, "export");
			Type importingSiteElementType = import.ImportingSiteElementType;
			ImmutableHashSet<string> sharingBoundaries = import.ExportFactorySharingBoundaries.ToImmutableHashSet();
			bool newSharingScope = sharingBoundaries.Count > 0;
			Func<KeyValuePair<object, IDisposable>> valueFactory = delegate
			{
				RuntimeExportProvider runtimeExportProvider = (newSharingScope ? new RuntimeExportProvider(composition, this, sharingBoundaries) : this);
				ExportedValueConstructor exportedValue = runtimeExportProvider.GetExportedValue(import, export, importingPartTracker);
				exportedValue.ExportingPart.GetValueReadyToExpose();
				object key = exportedValue.ValueConstructor();
				IDisposable disposable;
				if (!newSharingScope)
				{
					IDisposable exportingPart = exportedValue.ExportingPart;
					disposable = exportingPart;
				}
				else
				{
					IDisposable exportingPart = runtimeExportProvider;
					disposable = exportingPart;
				}
				IDisposable value = disposable;
				return new KeyValuePair<object, IDisposable>(key, value);
			};
			Type importingSiteTypeWithoutCollection = import.ImportingSiteTypeWithoutCollection;
			IReadOnlyDictionary<string, object> metadata = export.Metadata;
			return CreateExportFactory(importingSiteElementType, sharingBoundaries, valueFactory, importingSiteTypeWithoutCollection, metadata);
		}

		private ExportedValueConstructor GetExportedValue(RuntimeComposition.RuntimeImport import, RuntimeComposition.RuntimeExport export, RuntimePartLifecycleTracker importingPartTracker)
		{
			Requires.NotNull(import, "import");
			Requires.NotNull(export, "export");
			RuntimeComposition.RuntimePart part = composition.GetPart(export);
			if (part.TypeRef.Equals(ExportProvider.ExportProviderPartDefinition.TypeRef))
			{
				return new ExportedValueConstructor(null, () => base.NonDisposableWrapper.Value);
			}
			TypeRef partConstructedTypeRef = GetPartConstructedTypeRef(part, import.Metadata);
			return GetExportedValueHelper(import, export, part, part.TypeRef, partConstructedTypeRef, importingPartTracker);
		}

		private ExportedValueConstructor GetExportedValueHelper(RuntimeComposition.RuntimeImport import, RuntimeComposition.RuntimeExport export, RuntimeComposition.RuntimePart exportingRuntimePart, TypeRef originalPartTypeRef, TypeRef constructedPartTypeRef, RuntimePartLifecycleTracker importingPartTracker)
		{
			Requires.NotNull(import, "import");
			Requires.NotNull(export, "export");
			Requires.NotNull(exportingRuntimePart, "exportingRuntimePart");
			Requires.NotNull(originalPartTypeRef, "originalPartTypeRef");
			Requires.NotNull(constructedPartTypeRef, "constructedPartTypeRef");
			PartLifecycleTracker partLifecycle = GetOrCreateValue(originalPartTypeRef, constructedPartTypeRef, exportingRuntimePart.SharingBoundary, import.Metadata, !exportingRuntimePart.IsShared || import.IsNonSharedInstanceRequired);
			ReportFaultCallback faultCallback = this.faultCallback;
			Func<object> valueConstructor = delegate
			{
				try
				{
					bool flag = ExportProvider.IsFullyInitializedExportRequiredWhenSettingImport(importingPartTracker, import.IsLazy, !import.ImportingParameterRef.IsEmpty);
					if (!flag && importingPartTracker != null && !import.IsExportFactory)
					{
						importingPartTracker.ReportPartiallyInitializedImport(partLifecycle);
					}
					if (!export.MemberRef.IsEmpty)
					{
						return ExportProvider.GetValueFromMember(export.Member.IsStatic() ? null : (flag ? partLifecycle.GetValueReadyToExpose() : partLifecycle.GetValueReadyToRetrieveExportingMembers()), export.Member, import.ImportingSiteElementType, export.ExportedValueTypeRef.Resolve());
					}
					return flag ? partLifecycle.GetValueReadyToExpose() : partLifecycle.GetValueReadyToRetrieveExportingMembers();
				}
				catch (Exception e)
				{
					faultCallback?.Invoke(e, import, export);
					throw;
				}
			};
			return new ExportedValueConstructor(partLifecycle, valueConstructor);
		}

		private static TypeRef GetPartConstructedTypeRef(RuntimeComposition.RuntimePart part, IReadOnlyDictionary<string, object> importMetadata)
		{
			Requires.NotNull(part, "part");
			Requires.NotNull(importMetadata, "importMetadata");
			if (part.TypeRef.IsGenericTypeDefinition && LazyMetadataWrapper.TryUnwrap(importMetadata).TryGetValue("System.ComponentModel.Composition.GenericParameters", out var value))
			{
				IEnumerable<TypeRef> enumerable;
				if (!(value is LazyMetadataWrapper.TypeArraySubstitution))
				{
					enumerable = ((Type[])value).Select((Type t) => TypeRef.Get(t, part.TypeRef.Resolver));
				}
				else
				{
					IEnumerable<TypeRef> typeRefArray = ((LazyMetadataWrapper.TypeArraySubstitution)value).TypeRefArray;
					enumerable = typeRefArray;
				}
				IEnumerable<TypeRef> items = enumerable;
				return part.TypeRef.MakeGenericTypeRef(items.ToImmutableArray());
			}
			return part.TypeRef;
		}

		private static void SetImportingMember(object part, MemberInfo member, object value)
		{
			Requires.NotNull(part, "part");
			Requires.NotNull(member, "member");
			if (member.DeclaringType.GetTypeInfo().ContainsGenericParameters)
			{
				member = ReflectionHelpers.CloseGenericType(member.DeclaringType, part.GetType()).GetTypeInfo().GetMember(member.Name, MemberTypes.Field | MemberTypes.Property, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)[0];
			}
			PropertyInfo propertyInfo = member as PropertyInfo;
			if (propertyInfo != null)
			{
				propertyInfo.SetValue(part, value);
				return;
			}
			FieldInfo fieldInfo = member as FieldInfo;
			if (fieldInfo != null)
			{
				fieldInfo.SetValue(part, value);
				return;
			}
			throw new NotSupportedException();
		}

		private static object GetImportingMember(object part, MemberInfo member)
		{
			Requires.NotNull(part, "part");
			Requires.NotNull(member, "member");
			PropertyInfo propertyInfo = member as PropertyInfo;
			if (propertyInfo != null)
			{
				return propertyInfo.GetValue(part);
			}
			FieldInfo fieldInfo = member as FieldInfo;
			if (fieldInfo != null)
			{
				return fieldInfo.GetValue(part);
			}
			throw new NotSupportedException();
		}
	}

	private readonly RuntimeComposition composition;

	internal RuntimeExportProviderFactory(RuntimeComposition composition)
	{
		Requires.NotNull(composition, "composition");
		this.composition = composition;
	}

	public ExportProvider CreateExportProvider()
	{
		return new RuntimeExportProvider(composition);
	}

	public ExportProvider CreateExportProvider(ReportFaultCallback faultCallback)
	{
		Requires.NotNull(faultCallback, "faultCallback");
		return new RuntimeExportProvider(composition, faultCallback);
	}
}
