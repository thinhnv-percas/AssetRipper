using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Threading;
using Microsoft.VisualStudio.Composition.Reflection;

namespace Microsoft.VisualStudio.Composition;

public abstract class ExportProvider : IDisposableObservable, IDisposable
{
	protected internal enum PartLifecycleState
	{
		NotCreated,
		Creating,
		Created,
		ImmediateImportsSatisfied,
		ImmediateImportsSatisfiedTransitively,
		OnImportsSatisfiedInProgress,
		OnImportsSatisfiedInvoked,
		OnImportsSatisfiedInvokedTransitively,
		Final
	}

	protected internal interface IMetadataDictionary : IDictionary<string, object>, ICollection<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable, IReadOnlyDictionary<string, object>, IReadOnlyCollection<KeyValuePair<string, object>>
	{
	}

	protected struct ExportInfo
	{
		public ExportDefinition Definition { get; private set; }

		public Func<object> ExportedValueGetter { get; private set; }

		public ExportInfo(string contractName, IReadOnlyDictionary<string, object> metadata, Func<object> exportedValueGetter)
			: this(new ExportDefinition(contractName, metadata), exportedValueGetter)
		{
		}

		public ExportInfo(ExportDefinition exportDefinition, Func<object> exportedValueGetter)
		{
			this = default(ExportInfo);
			Requires.NotNull(exportDefinition, "exportDefinition");
			Requires.NotNull(exportedValueGetter, "exportedValueGetter");
			Definition = exportDefinition;
			ExportedValueGetter = exportedValueGetter;
		}

		internal ExportInfo CloseGenericExport(Type[] genericTypeArguments)
		{
			Requires.NotNull(genericTypeArguments, "genericTypeArguments");
			string text = (string)Definition.Metadata["ExportTypeIdentity"];
			string format = text;
			string[] args = genericTypeArguments.Select(ContractNameServices.GetTypeIdentity).ToArray();
			string text2 = string.Format(CultureInfo.InvariantCulture, format, args);
			ImmutableDictionary<string, object> metadata = ImmutableDictionary.CreateRange(Definition.Metadata).SetItem("ExportTypeIdentity", text2);
			return new ExportInfo((Definition.ContractName == text) ? text2 : Definition.ContractName, metadata, ExportedValueGetter);
		}
	}

	protected internal abstract class PartLifecycleTracker : IDisposable
	{
		private readonly object syncObject = new object();

		private readonly string sharingBoundary;

		private bool isDisposed;

		private object value;

		private HashSet<PartLifecycleTracker> deferredInitializationParts;

		private int? executingStepThreadId;

		private Exception fault;

		public object Value
		{
			get
			{
				ThrowIfDisposed();
				return value;
			}
			set
			{
				this.value = value;
			}
		}

		public PartLifecycleState State { get; private set; }

		protected ExportProvider OwningExportProvider { get; private set; }

		protected abstract Type PartType { get; }

		public PartLifecycleTracker(ExportProvider owningExportProvider, string sharingBoundary)
		{
			Requires.NotNull(owningExportProvider, "owningExportProvider");
			OwningExportProvider = owningExportProvider;
			this.sharingBoundary = sharingBoundary;
			deferredInitializationParts = new HashSet<PartLifecycleTracker>();
			State = PartLifecycleState.NotCreated;
		}

		public object GetValueReadyToExpose()
		{
			if (executingStepThreadId != Environment.CurrentManagedThreadId)
			{
				MoveToState(PartLifecycleState.Final);
			}
			if (Value == null)
			{
				ThrowPartNotInstantiableException();
			}
			return Value;
		}

		public object GetValueReadyToRetrieveExportingMembers()
		{
			MoveToState(PartLifecycleState.Created);
			return Value;
		}

		public void Dispose()
		{
			isDisposed = true;
			IDisposable disposable = value as IDisposable;
			value = null;
			disposable?.Dispose();
		}

		protected abstract object CreateValue();

		protected abstract void SatisfyImports();

		protected abstract void InvokeOnImportsSatisfied();

		protected void ReportPartiallyInitializedImport(PartLifecycleTracker importedPart)
		{
			if (importedPart != null)
			{
				lock (syncObject)
				{
					deferredInitializationParts.Add(importedPart);
				}
			}
		}

		protected void ThrowPartNotInstantiableException()
		{
			Type partType = PartType;
			string text = ((partType != null) ? partType.FullName : string.Empty);
			throw new CompositionFailedException(string.Format(CultureInfo.CurrentCulture, Strings.PartIsNotInstantiable, new object[1] { text }));
		}

		private void Create()
		{
			bool flag = false;
			lock (syncObject)
			{
				flag = ShouldMoveTo(PartLifecycleState.Creating);
				if (flag)
				{
					UpdateState(PartLifecycleState.Creating);
				}
			}
			Assumes.False(Monitor.IsEntered(syncObject));
			if (!flag)
			{
				return;
			}
			try
			{
				executingStepThreadId = Environment.CurrentManagedThreadId;
				object obj = CreateValue();
				lock (syncObject)
				{
					Assumes.True(State == PartLifecycleState.Creating);
					Value = obj;
					if (obj is IDisposable)
					{
						OwningExportProvider.TrackDisposableValue(this, sharingBoundary);
					}
					Assumes.True(UpdateState(PartLifecycleState.Created));
				}
			}
			catch (Exception exception)
			{
				Fault(exception);
				throw;
			}
		}

		private void SatisfyImmediateImports()
		{
			lock (syncObject)
			{
				if (ShouldMoveTo(PartLifecycleState.ImmediateImportsSatisfied))
				{
					try
					{
						executingStepThreadId = Environment.CurrentManagedThreadId;
						SatisfyImports();
						UpdateState(PartLifecycleState.ImmediateImportsSatisfied);
						return;
					}
					catch (Exception exception)
					{
						Fault(exception);
						throw;
					}
				}
			}
		}

		private void NotifyTransitiveImportsSatisfied()
		{
			try
			{
				bool flag = false;
				lock (syncObject)
				{
					flag = ShouldMoveTo(PartLifecycleState.OnImportsSatisfiedInProgress);
					if (flag)
					{
						Assumes.True(UpdateState(PartLifecycleState.OnImportsSatisfiedInProgress));
					}
				}
				if (flag)
				{
					Assumes.False(Monitor.IsEntered(syncObject));
					executingStepThreadId = Environment.CurrentManagedThreadId;
					InvokeOnImportsSatisfied();
					Assumes.True(UpdateState(PartLifecycleState.OnImportsSatisfiedInvoked));
				}
			}
			catch (Exception exception)
			{
				Fault(exception);
				throw;
			}
		}

		private void MoveNext(PartLifecycleState nextState)
		{
			Assumes.True(nextState <= State + 1, "MoveNext should not be asked to skip a state.");
			switch (nextState)
			{
			case PartLifecycleState.Creating:
				Create();
				break;
			case PartLifecycleState.Created:
				Verify.Operation(executingStepThreadId != Environment.CurrentManagedThreadId, Strings.RecursiveRequestForPartConstruction, PartType);
				WaitForState(PartLifecycleState.Created);
				break;
			case PartLifecycleState.ImmediateImportsSatisfied:
				SatisfyImmediateImports();
				break;
			case PartLifecycleState.ImmediateImportsSatisfiedTransitively:
				MoveToStateTransitively(PartLifecycleState.ImmediateImportsSatisfiedTransitively);
				break;
			case PartLifecycleState.OnImportsSatisfiedInProgress:
				NotifyTransitiveImportsSatisfied();
				break;
			case PartLifecycleState.OnImportsSatisfiedInvoked:
				WaitForState(PartLifecycleState.OnImportsSatisfiedInvoked);
				break;
			case PartLifecycleState.OnImportsSatisfiedInvokedTransitively:
				MoveToStateTransitively(PartLifecycleState.OnImportsSatisfiedInvokedTransitively);
				break;
			case PartLifecycleState.Final:
				UpdateState(PartLifecycleState.Final);
				deferredInitializationParts = null;
				break;
			default:
				throw Assumes.NotReachable();
			}
		}

		private bool ShouldMoveTo(PartLifecycleState nextState)
		{
			lock (syncObject)
			{
				ThrowIfFaulted();
				if (State >= nextState)
				{
					return false;
				}
				if (State < nextState - 1)
				{
					Verify.FailOperation(Strings.UnexpectedSharedPartState, State, nextState - 1);
				}
				return true;
			}
		}

		private void MoveToState(PartLifecycleState requiredState)
		{
			ThrowIfFaulted();
			PartLifecycleState state;
			while ((state = State) < requiredState)
			{
				MoveNext(state + 1);
				ThrowIfFaulted();
			}
		}

		private void MoveToStateTransitively(PartLifecycleState requiredState, HashSet<PartLifecycleTracker> visitedNodes = null)
		{
			try
			{
				bool flag = visitedNodes == null;
				PartLifecycleState requiredState2 = (flag ? (requiredState - 1) : requiredState);
				PartLifecycleState partLifecycleState = (flag ? requiredState : (requiredState + 1));
				if (State >= partLifecycleState)
				{
					return;
				}
				MoveToState(requiredState2);
				visitedNodes = visitedNodes ?? new HashSet<PartLifecycleTracker>();
				if (!visitedNodes.Add(this))
				{
					return;
				}
				HashSet<PartLifecycleTracker> hashSet = deferredInitializationParts;
				if (hashSet != null)
				{
					foreach (PartLifecycleTracker item in hashSet)
					{
						item.MoveToStateTransitively(requiredState2, visitedNodes);
					}
				}
				if (!flag)
				{
					return;
				}
				foreach (PartLifecycleTracker visitedNode in visitedNodes)
				{
					visitedNode.UpdateState(partLifecycleState);
				}
			}
			catch (Exception exception)
			{
				Fault(exception);
				throw;
			}
		}

		private bool UpdateState(PartLifecycleState newState)
		{
			lock (syncObject)
			{
				if (State < newState)
				{
					State = newState;
					executingStepThreadId = null;
					Monitor.PulseAll(syncObject);
					return true;
				}
				return false;
			}
		}

		private void WaitForState(PartLifecycleState state)
		{
			lock (syncObject)
			{
				while (State < state)
				{
					while (!Monitor.Wait(syncObject, TimeSpan.FromSeconds(3.0)))
					{
					}
				}
			}
		}

		private void ThrowIfFaulted()
		{
			if (fault != null)
			{
				ExceptionDispatchInfo.Capture(fault).Throw();
			}
		}

		private void ThrowIfDisposed()
		{
			if (isDisposed)
			{
				throw new ObjectDisposedException(GetType().FullName);
			}
		}

		private void Fault(Exception exception)
		{
			lock (syncObject)
			{
				if (fault != exception && exception != null)
				{
					fault = exception;
				}
				UpdateState(PartLifecycleState.Final);
			}
		}
	}

	private class ExportProviderAsExport : DelegatingExportProvider
	{
		internal ExportProviderAsExport(ExportProvider inner)
			: base(inner)
		{
		}

		protected override void Dispose(bool disposing)
		{
			throw new InvalidOperationException(Strings.CannotDirectlyDisposeAnImport);
		}
	}

	internal static readonly ExportDefinition ExportProviderExportDefinition = new ExportDefinition(ContractNameServices.GetTypeIdentity(typeof(ExportProvider)), PartCreationPolicyConstraint.GetExportMetadata(CreationPolicy.Shared).AddRange(ExportTypeIdentityConstraint.GetExportMetadata(typeof(ExportProvider))));

	internal static readonly ComposablePartDefinition ExportProviderPartDefinition = new ComposablePartDefinition(TypeRef.Get(typeof(ExportProviderAsExport), Resolver.DefaultInstance), ImmutableDictionary<string, object>.Empty.Add("VsMEFDgmlCategories", new string[1] { "VsMEFBuiltIn" }), new ExportDefinition[1] { ExportProviderExportDefinition }, ImmutableDictionary<MemberRef, IReadOnlyCollection<ExportDefinition>>.Empty, ImmutableList<ImportDefinitionBinding>.Empty, string.Empty, default(MethodRef), default(ConstructorRef), null, CreationPolicy.Shared, isSharingBoundaryInferred: true);

	protected static readonly Lazy<object> NotInstantiablePartLazy = new Lazy<object>(() => CannotInstantiatePartWithNoImportingConstructor());

	protected static readonly Type[] EmptyTypeArray = new Type[0];

	protected static readonly object[] EmptyObjectArray = EmptyTypeArray;

	protected static readonly ImmutableDictionary<string, object> EmptyMetadata = ImmutableDictionary.Create<string, object>();

	private static readonly Dictionary<Type, IReadOnlyDictionary<string, object>> GetMetadataViewDefaultsCache = new Dictionary<Type, IReadOnlyDictionary<string, object>>();

	private static readonly ImmutableDictionary<string, Dictionary<TypeRef, PartLifecycleTracker>> SharedInstantiatedPartsTemplate = ImmutableDictionary.Create<string, Dictionary<TypeRef, PartLifecycleTracker>>().Add(string.Empty, new Dictionary<TypeRef, PartLifecycleTracker>());

	private static readonly ImmutableDictionary<string, HashSet<IDisposable>> DisposableInstantiatedSharedPartsTemplate = ImmutableDictionary.Create<string, HashSet<IDisposable>>().Add(string.Empty, new HashSet<IDisposable>());

	private readonly Lazy<ImmutableArray<Lazy<IMetadataViewProvider, IReadOnlyDictionary<string, object>>>> metadataViewProviders;

	private readonly ImmutableDictionary<string, Dictionary<TypeRef, PartLifecycleTracker>> sharedInstantiatedParts;

	private readonly ImmutableDictionary<string, ExportProvider> sharingBoundaryExportProviderOwners;

	private readonly ImmutableDictionary<string, HashSet<IDisposable>> disposableInstantiatedSharedParts;

	private readonly HashSet<IDisposable> disposableNonSharedParts = new HashSet<IDisposable>();

	private readonly ImmutableHashSet<string> freshSharingBoundaries = ImmutableHashSet.Create<string>();

	private Dictionary<Type, IMetadataViewProvider> typeAndSelectedMetadataViewProviderCache = new Dictionary<Type, IMetadataViewProvider>();

	private bool isDisposed;

	bool IDisposableObservable.IsDisposed => isDisposed;

	protected Lazy<object> NonDisposableWrapper { get; private set; }

	protected ImmutableList<Export> NonDisposableWrapperExportAsListOfOne { get; private set; }

	protected internal Resolver Resolver { get; }

	private ExportProvider(Resolver resolver, ImmutableDictionary<string, Dictionary<TypeRef, PartLifecycleTracker>> sharedInstantiatedParts, ImmutableDictionary<string, HashSet<IDisposable>> disposableInstantiatedSharedParts, ImmutableHashSet<string> freshSharingBoundaries, ImmutableDictionary<string, ExportProvider> sharingBoundaryExportProviderOwners, Lazy<ImmutableArray<Lazy<IMetadataViewProvider, IReadOnlyDictionary<string, object>>>> inheritedMetadataViewProviders)
	{
		Requires.NotNull(resolver, "resolver");
		Requires.NotNull(sharedInstantiatedParts, "sharedInstantiatedParts");
		Requires.NotNull(disposableInstantiatedSharedParts, "disposableInstantiatedSharedParts");
		Requires.NotNull(freshSharingBoundaries, "freshSharingBoundaries");
		Requires.NotNull(sharingBoundaryExportProviderOwners, "sharingBoundaryExportProviderOwners");
		Resolver = resolver;
		this.sharedInstantiatedParts = sharedInstantiatedParts;
		this.disposableInstantiatedSharedParts = disposableInstantiatedSharedParts;
		this.freshSharingBoundaries = freshSharingBoundaries;
		this.sharingBoundaryExportProviderOwners = sharingBoundaryExportProviderOwners;
		foreach (string freshSharingBoundary in freshSharingBoundaries)
		{
			this.sharedInstantiatedParts = this.sharedInstantiatedParts.SetItem(freshSharingBoundary, new Dictionary<TypeRef, PartLifecycleTracker>());
			this.disposableInstantiatedSharedParts = this.disposableInstantiatedSharedParts.SetItem(freshSharingBoundary, new HashSet<IDisposable>());
		}
		this.sharingBoundaryExportProviderOwners = this.sharingBoundaryExportProviderOwners.SetItems(this.freshSharingBoundaries.Select((string boundary) => new KeyValuePair<string, ExportProvider>(boundary, this)));
		ExportProviderAsExport value = (this as ExportProviderAsExport) ?? new ExportProviderAsExport(this);
		NonDisposableWrapper = LazyServices.FromValue((object)value);
		NonDisposableWrapperExportAsListOfOne = ImmutableList.Create(new Export(ExportProviderExportDefinition, NonDisposableWrapper));
		metadataViewProviders = inheritedMetadataViewProviders ?? new Lazy<ImmutableArray<Lazy<IMetadataViewProvider, IReadOnlyDictionary<string, object>>>>(GetMetadataViewProviderExtensions);
	}

	protected ExportProvider(Resolver resolver)
		: this(resolver, SharedInstantiatedPartsTemplate, DisposableInstantiatedSharedPartsTemplate, ImmutableHashSet.Create<string>().Add(string.Empty), ImmutableDictionary.Create<string, ExportProvider>(), null)
	{
	}

	protected ExportProvider(ExportProvider parent, ImmutableHashSet<string> freshSharingBoundaries)
		: this(Requires.NotNull(parent, "parent").Resolver, parent.sharedInstantiatedParts, parent.disposableInstantiatedSharedParts, freshSharingBoundaries, parent.sharingBoundaryExportProviderOwners, parent.metadataViewProviders)
	{
		Resolver = parent.Resolver;
	}

	public Lazy<T> GetExport<T>()
	{
		return GetExport<T>(null);
	}

	public Lazy<T> GetExport<T>(string contractName)
	{
		return GetExport<T, IDictionary<string, object>>(contractName);
	}

	public Lazy<T, TMetadataView> GetExport<T, TMetadataView>()
	{
		return GetExport<T, TMetadataView>(null);
	}

	public Lazy<T, TMetadataView> GetExport<T, TMetadataView>(string contractName)
	{
		return GetExports<T, TMetadataView>(contractName, ImportCardinality.ExactlyOne).Single();
	}

	public T GetExportedValue<T>()
	{
		return GetExport<T>().Value;
	}

	public T GetExportedValue<T>(string contractName)
	{
		return GetExport<T>(contractName).Value;
	}

	public IEnumerable<Lazy<T>> GetExports<T>()
	{
		return GetExports<T>(null);
	}

	public IEnumerable<Lazy<T>> GetExports<T>(string contractName)
	{
		return GetExports<T, IDictionary<string, object>>(contractName);
	}

	public IEnumerable<Lazy<T, TMetadataView>> GetExports<T, TMetadataView>()
	{
		return GetExports<T, TMetadataView>(null);
	}

	public IEnumerable<Lazy<T, TMetadataView>> GetExports<T, TMetadataView>(string contractName)
	{
		return GetExports<T, TMetadataView>(contractName, ImportCardinality.ZeroOrMore);
	}

	public IEnumerable<T> GetExportedValues<T>()
	{
		return from l in GetExports<T>()
			select l.Value;
	}

	public IEnumerable<T> GetExportedValues<T>(string contractName)
	{
		return from l in GetExports<T>(contractName)
			select l.Value;
	}

	public virtual IEnumerable<Export> GetExports(ImportDefinition importDefinition)
	{
		Requires.NotNull(importDefinition, "importDefinition");
		if (importDefinition.ContractName == ExportProviderExportDefinition.ContractName)
		{
			return NonDisposableWrapperExportAsListOfOne;
		}
		bool num = importDefinition.ContractName == "System.ComponentModel.Composition.Contracts.ExportFactory";
		ImportDefinition importDefinition2 = null;
		if (num)
		{
			importDefinition2 = importDefinition;
			importDefinition = (ImportDefinition)importDefinition.Metadata["Microsoft.VisualStudio.Composition.ProductImportDefinition"];
		}
		IEnumerable<ExportInfo> enumerable = GetExportsCore(importDefinition);
		if (ComposableCatalog.TryGetOpenGenericExport(importDefinition, out var contractName, out var genericTypeArguments))
		{
			ImportDefinition importDefinition3 = new ImportDefinition(contractName, importDefinition.Cardinality, importDefinition.Metadata, importDefinition.ExportConstraints);
			IEnumerable<ExportInfo> second = from export in GetExportsCore(importDefinition3)
				select export.CloseGenericExport(genericTypeArguments);
			enumerable = enumerable.Concat(second);
		}
		IEnumerable<ExportInfo> source = enumerable.Where((ExportInfo export) => importDefinition.ExportConstraints.All((IImportSatisfiabilityConstraint c) => c.IsSatisfiedBy(export.Definition)));
		IEnumerable<Export> source2;
		if (num)
		{
			Type exportFactoryType = (Type)importDefinition2.Metadata["Microsoft.VisualStudio.Composition.ExportFactoryType"];
			source2 = source.Select((ExportInfo ei) => CreateExportFactoryExport(ei, exportFactoryType));
		}
		else
		{
			source2 = source.Select((ExportInfo fe) => new Export(fe.Definition, fe.ExportedValueGetter));
		}
		Export[] array = source2.ToArray();
		if (importDefinition.Cardinality == ImportCardinality.ExactlyOne && array.Length != 1)
		{
			throw new CompositionFailedException(string.Format(CultureInfo.CurrentCulture, Strings.UnexpectedNumberOfExportsFound, new object[3] { 1, importDefinition.ContractName, array.Length }));
		}
		return array;
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!disposing)
		{
			return;
		}
		isDisposed = true;
		List<IDisposable> list;
		lock (disposableNonSharedParts)
		{
			list = new List<IDisposable>(disposableNonSharedParts);
			disposableNonSharedParts.Clear();
		}
		foreach (string freshSharingBoundary in freshSharingBoundaries)
		{
			HashSet<IDisposable> hashSet = disposableInstantiatedSharedParts[freshSharingBoundary];
			lock (hashSet)
			{
				list.AddRange(hashSet);
				hashSet.Clear();
			}
		}
		List<Exception> list2 = null;
		foreach (IDisposable item2 in list)
		{
			try
			{
				item2.Dispose();
			}
			catch (Exception item)
			{
				if (list2 == null)
				{
					list2 = new List<Exception>();
				}
				list2.Add(item);
			}
		}
		if (list2 != null)
		{
			throw new AggregateException(Strings.ContainerDisposalEncounteredExceptions, list2);
		}
	}

	protected static object CannotInstantiatePartWithNoImportingConstructor()
	{
		throw new CompositionFailedException(Strings.NoImportingConstructor);
	}

	protected static bool IsFullyInitializedExportRequiredWhenSettingImport(PartLifecycleTracker importingPartTracker, bool isLazy, bool isImportingConstructorArgument)
	{
		return isLazy | isImportingConstructorArgument;
	}

	protected abstract IEnumerable<ExportInfo> GetExportsCore(ImportDefinition importDefinition);

	protected ExportInfo CreateExport(ImportDefinition importDefinition, IReadOnlyDictionary<string, object> exportMetadata, TypeRef originalPartTypeRef, TypeRef constructedPartTypeRef, string partSharingBoundary, bool nonSharedInstanceRequired, MemberInfo exportingMember)
	{
		Requires.NotNull(importDefinition, "importDefinition");
		Requires.NotNull(exportMetadata, "metadata");
		Requires.NotNull(originalPartTypeRef, "originalPartTypeRef");
		Requires.NotNull(constructedPartTypeRef, "constructedPartTypeRef");
		return new ExportInfo(exportedValueGetter: (!(exportingMember == null)) ? ((Func<object>)(() => GetValueFromMember(GetOrCreateValue(originalPartTypeRef, constructedPartTypeRef, partSharingBoundary, importDefinition.Metadata, nonSharedInstanceRequired).GetValueReadyToRetrieveExportingMembers(), exportingMember))) : ((Func<object>)(() => GetOrCreateValue(originalPartTypeRef, constructedPartTypeRef, partSharingBoundary, importDefinition.Metadata, nonSharedInstanceRequired).GetValueReadyToExpose())), contractName: importDefinition.ContractName, metadata: exportMetadata);
	}

	protected object CreateExportFactory(Type importingSiteElementType, IReadOnlyCollection<string> sharingBoundaries, Func<KeyValuePair<object, IDisposable>> valueFactory, Type exportFactoryType, IReadOnlyDictionary<string, object> exportMetadata)
	{
		Requires.NotNull(importingSiteElementType, "importingSiteElementType");
		Requires.NotNull(sharingBoundaries, "sharingBoundaries");
		Requires.NotNull(valueFactory, "valueFactory");
		Requires.NotNull(exportFactoryType, "exportFactoryType");
		Requires.NotNull(exportMetadata, "exportMetadata");
		Type tupleType;
		using (Rental<Type[]> rental = ArrayRental<Type>.Get(2))
		{
			rental.Value[0] = importingSiteElementType;
			rental.Value[1] = typeof(Action);
			tupleType = typeof(Tuple<, >).MakeGenericType(rental.Value);
		}
		Func<object> func = delegate
		{
			KeyValuePair<object, IDisposable> keyValuePair = valueFactory();
			using Rental<object[]> rental3 = ArrayRental<object>.Get(2);
			rental3.Value[0] = keyValuePair.Key;
			rental3.Value[1] = ((keyValuePair.Value != null) ? new Action(keyValuePair.Value.Dispose) : null);
			return Activator.CreateInstance(tupleType, rental3.Value);
		};
		using Rental<object[]> rental2 = ArrayRental<object>.Get(exportFactoryType.GenericTypeArguments.Length);
		rental2.Value[0] = func.As(tupleType);
		if (rental2.Value.Length > 1)
		{
			rental2.Value[1] = GetStrongTypedMetadata(exportMetadata, exportFactoryType.GenericTypeArguments[1]);
		}
		return exportFactoryType.GetTypeInfo().GetConstructors()[0].Invoke(rental2.Value);
	}

	private Export CreateExportFactoryExport(ExportInfo exportInfo, Type exportFactoryType)
	{
		Requires.NotNull(exportFactoryType, "exportFactoryType");
		Func<object> exportedValueGetter = () => CreateExportFactory(typeof(object), ImmutableHashSet<string>.Empty, delegate
		{
			object obj = exportInfo.ExportedValueGetter();
			return new KeyValuePair<object, IDisposable>(obj, obj as IDisposable);
		}, exportFactoryType, exportInfo.Definition.Metadata);
		string typeIdentity = ContractNameServices.GetTypeIdentity(exportFactoryType);
		ImmutableDictionary<string, object> metadata = exportInfo.Definition.Metadata.ToImmutableDictionary().SetItem("ExportTypeIdentity", typeIdentity).SetItem("System.ComponentModel.Composition.CreationPolicy", CreationPolicy.NonShared)
			.SetItem("ProductDefinition", exportInfo.Definition);
		return new Export(typeIdentity, metadata, exportedValueGetter);
	}

	protected object GetStrongTypedMetadata(IReadOnlyDictionary<string, object> metadata, Type metadataType)
	{
		Requires.NotNull(metadata, "metadata");
		Requires.NotNull(metadataType, "metadataType");
		return GetMetadataViewProvider(metadataType).CreateProxy(metadata, GetMetadataViewDefaults(metadataType), metadataType);
	}

	protected static object GetValueFromMember(object exportingPart, MemberInfo exportingMember, Type importingSiteElementType = null, Type exportedValueType = null)
	{
		Requires.NotNull(exportingMember, "exportingMember");
		if (exportingMember == null)
		{
			return exportingPart;
		}
		FieldInfo fieldInfo = exportingMember as FieldInfo;
		if (fieldInfo != null)
		{
			return fieldInfo.GetValue(exportingPart);
		}
		PropertyInfo propertyInfo = exportingMember as PropertyInfo;
		if (propertyInfo != null)
		{
			return propertyInfo.GetValue(exportingPart);
		}
		MethodInfo methodInfo = exportingMember as MethodInfo;
		if (methodInfo != null)
		{
			if (methodInfo.IsSpecialName && methodInfo.GetParameters().Length == 0 && methodInfo.Name.StartsWith("get_"))
			{
				return methodInfo.Invoke(exportingPart, EmptyObjectArray);
			}
			object target = (methodInfo.IsStatic ? null : exportingPart);
			if (importingSiteElementType != null)
			{
				Type delegateType = (typeof(Delegate).GetTypeInfo().IsAssignableFrom(importingSiteElementType.GetTypeInfo()) ? importingSiteElementType : (exportedValueType ?? ReflectionHelpers.GetContractTypeForDelegate(methodInfo)));
				return methodInfo.CreateDelegate(delegateType, target);
			}
			return new ExportedDelegate(target, methodInfo);
		}
		throw new NotSupportedException();
	}

	protected PartLifecycleTracker GetOrCreateValue(TypeRef originalPartTypeRef, TypeRef constructedPartTypeRef, string partSharingBoundary, IReadOnlyDictionary<string, object> importMetadata, bool nonSharedInstanceRequired)
	{
		if (!nonSharedInstanceRequired)
		{
			return GetOrCreateShareableValue(originalPartTypeRef, constructedPartTypeRef, partSharingBoundary, importMetadata);
		}
		return CreateNewValue(originalPartTypeRef, constructedPartTypeRef, partSharingBoundary, importMetadata);
	}

	protected PartLifecycleTracker GetOrCreateShareableValue(TypeRef originalPartTypeRef, TypeRef constructedPartTypeRef, string partSharingBoundary, IReadOnlyDictionary<string, object> importMetadata)
	{
		Requires.NotNull(originalPartTypeRef, "originalPartTypeRef");
		Requires.NotNull(constructedPartTypeRef, "constructedPartTypeRef");
		if (TryGetSharedInstanceFactory(partSharingBoundary, constructedPartTypeRef, out var value))
		{
			return value;
		}
		PartLifecycleTracker value2 = CreateNewValue(originalPartTypeRef, constructedPartTypeRef, partSharingBoundary, importMetadata);
		return GetOrAddSharedInstanceFactory(partSharingBoundary, constructedPartTypeRef, value2);
	}

	protected PartLifecycleTracker CreateNewValue(TypeRef originalPartTypeRef, TypeRef constructedPartTypeRef, string partSharingBoundary, IReadOnlyDictionary<string, object> importMetadata)
	{
		return ((partSharingBoundary != null) ? sharingBoundaryExportProviderOwners[partSharingBoundary] : this).CreatePartLifecycleTracker(originalPartTypeRef, importMetadata);
	}

	protected internal abstract PartLifecycleTracker CreatePartLifecycleTracker(TypeRef partType, IReadOnlyDictionary<string, object> importMetadata);

	private bool TryGetSharedInstanceFactory(string partSharingBoundary, TypeRef partTypeRef, out PartLifecycleTracker value)
	{
		Dictionary<TypeRef, PartLifecycleTracker> dictionary = AcquireSharingBoundaryInstances(partSharingBoundary);
		lock (dictionary)
		{
			return dictionary.TryGetValue(partTypeRef, out value);
		}
	}

	private PartLifecycleTracker GetOrAddSharedInstanceFactory(string partSharingBoundary, TypeRef partTypeRef, PartLifecycleTracker value)
	{
		Requires.NotNull(partTypeRef, "partTypeRef");
		Requires.NotNull(value, "value");
		Dictionary<TypeRef, PartLifecycleTracker> dictionary = AcquireSharingBoundaryInstances(partSharingBoundary);
		lock (dictionary)
		{
			if (dictionary.TryGetValue(partTypeRef, out var value2))
			{
				return value2;
			}
			dictionary.Add(partTypeRef, value);
			return value;
		}
	}

	protected void TrackDisposableValue(IDisposable instantiatedPart, string sharingBoundary)
	{
		Requires.NotNull(instantiatedPart, "instantiatedPart");
		if (sharingBoundary == null)
		{
			lock (disposableNonSharedParts)
			{
				disposableNonSharedParts.Add(instantiatedPart);
				return;
			}
		}
		HashSet<IDisposable> hashSet = disposableInstantiatedSharedParts[sharingBoundary];
		lock (hashSet)
		{
			hashSet.Add(instantiatedPart);
		}
	}

	protected MethodInfo GetMethodWithArity(Type declaringType, string methodName, int arity)
	{
		return declaringType.GetTypeInfo().GetDeclaredMethods(methodName).Single((MethodInfo m) => m.GetGenericArguments().Length == arity);
	}

	protected static IReadOnlyDictionary<string, object> GetMetadataViewDefaults(Type metadataView)
	{
		Requires.NotNull(metadataView, "metadataView");
		IReadOnlyDictionary<string, object> value;
		lock (GetMetadataViewDefaultsCache)
		{
			GetMetadataViewDefaultsCache.TryGetValue(metadataView, out value);
		}
		if (value == null)
		{
			if (metadataView.GetTypeInfo().IsInterface && !metadataView.Equals(typeof(IDictionary<string, object>)))
			{
				ImmutableDictionary<string, object>.Builder builder = ImmutableDictionary.CreateBuilder<string, object>();
				foreach (PropertyInfo item in metadataView.EnumProperties().WherePublicInstance())
				{
					if (!builder.ContainsKey(item.Name))
					{
						DefaultValueAttribute firstAttribute = item.GetFirstAttribute<DefaultValueAttribute>();
						if (firstAttribute != null)
						{
							builder.Add(item.Name, firstAttribute.Value);
						}
					}
				}
				value = builder.ToImmutable();
			}
			else
			{
				value = ImmutableDictionary<string, object>.Empty;
			}
			lock (GetMetadataViewDefaultsCache)
			{
				GetMetadataViewDefaultsCache[metadataView] = value;
			}
		}
		return value;
	}

	protected internal static int GetOrderMetadata(IReadOnlyDictionary<string, object> metadata)
	{
		Requires.NotNull(metadata, "metadata");
		object valueOrDefault = metadata.GetValueOrDefault("OrderPrecedence");
		if (!(valueOrDefault is int))
		{
			return 0;
		}
		return (int)valueOrDefault;
	}

	private static T CastValueTo<T>(object value)
	{
		if (value is ExportedDelegate && typeof(Delegate).GetTypeInfo().IsAssignableFrom(typeof(T)))
		{
			return (T)(object)((ExportedDelegate)value).CreateDelegate(typeof(T));
		}
		return (T)value;
	}

	private bool TryGetProvisionalSharedExport(IReadOnlyDictionary<TypeRef, object> provisionalSharedObjects, TypeRef partTypeRef, out object value)
	{
		Requires.NotNull(provisionalSharedObjects, "provisionalSharedObjects");
		Requires.NotNull(partTypeRef, "partTypeRef");
		lock (provisionalSharedObjects)
		{
			return provisionalSharedObjects.TryGetValue(partTypeRef, out value);
		}
	}

	private IEnumerable<Lazy<T, TMetadataView>> GetExports<T, TMetadataView>(string contractName, ImportCardinality cardinality)
	{
		Verify.NotDisposed(this);
		contractName = (string.IsNullOrEmpty(contractName) ? ContractNameServices.GetTypeIdentity(typeof(T)) : contractName);
		IMetadataViewProvider metadataViewProvider = GetMetadataViewProvider(typeof(TMetadataView));
		ImmutableHashSet<IImportSatisfiabilityConstraint> immutableHashSet = ImmutableHashSet<IImportSatisfiabilityConstraint>.Empty.Union(PartDiscovery.GetExportTypeIdentityConstraints(typeof(T)));
		if (typeof(TMetadataView) != typeof(IDictionary<string, object>))
		{
			immutableHashSet = immutableHashSet.Add(ImportMetadataViewConstraint.GetConstraint(TypeRef.Get(typeof(TMetadataView), Resolver), Resolver));
		}
		ImmutableDictionary<string, object> importMetadataForGenericTypeImport = PartDiscovery.GetImportMetadataForGenericTypeImport(typeof(T));
		ImportDefinition importDefinition = new ImportDefinition(contractName, cardinality, importMetadataForGenericTypeImport, immutableHashSet);
		return (from result in GetExports(importDefinition)
			select new Lazy<T, TMetadataView>(() => CastValueTo<T>(result.Value), (TMetadataView)metadataViewProvider.CreateProxy(result.Metadata, GetMetadataViewDefaults(typeof(TMetadataView)), typeof(TMetadataView)))).ToArray();
	}

	private ImmutableArray<Lazy<IMetadataViewProvider, IReadOnlyDictionary<string, object>>> GetMetadataViewProviderExtensions()
	{
		ImportDefinition importDefinition = new ImportDefinition(ContractNameServices.GetTypeIdentity(typeof(IMetadataViewProvider)), ImportCardinality.ZeroOrMore, ImmutableDictionary<string, object>.Empty, ImmutableHashSet<IImportSatisfiabilityConstraint>.Empty);
		return ImmutableArray.CreateRange(from export in GetExports(importDefinition)
			orderby GetOrderMetadata(export.Metadata) descending
			select new Lazy<IMetadataViewProvider, IReadOnlyDictionary<string, object>>(() => (IMetadataViewProvider)export.Value, export.Metadata));
	}

	internal virtual IMetadataViewProvider GetMetadataViewProvider(Type metadataView)
	{
		Requires.NotNull(metadataView, "metadataView");
		IMetadataViewProvider value;
		lock (typeAndSelectedMetadataViewProviderCache)
		{
			typeAndSelectedMetadataViewProviderCache.TryGetValue(metadataView, out value);
		}
		if (value == null)
		{
			foreach (Lazy<IMetadataViewProvider, IReadOnlyDictionary<string, object>> item in metadataViewProviders.Value)
			{
				if (item.Value.IsMetadataViewSupported(metadataView))
				{
					value = item.Value;
					break;
				}
			}
			if (value == null)
			{
				throw new NotSupportedException(Strings.TypeOfMetadataViewUnsupported);
			}
			lock (typeAndSelectedMetadataViewProviderCache)
			{
				typeAndSelectedMetadataViewProviderCache[metadataView] = value;
			}
		}
		return value;
	}

	private Dictionary<TypeRef, PartLifecycleTracker> AcquireSharingBoundaryInstances(string sharingBoundaryName)
	{
		Requires.NotNull(sharingBoundaryName, "sharingBoundaryName");
		return sharedInstantiatedParts.GetValueOrDefault(sharingBoundaryName) ?? throw new CompositionFailedException(Strings.PartBelongsToAnotherSharingBoundary);
	}
}
