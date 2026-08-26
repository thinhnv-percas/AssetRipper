using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Microsoft.VisualStudio.Composition.Reflection;

namespace Microsoft.VisualStudio.Composition;

public abstract class PartDiscovery
{
	private class ProgressFilter : IProgress<DiscoveryProgress>
	{
		private readonly IProgress<DiscoveryProgress> upstreamReceiver;

		private int totalTypes;

		private DiscoveryProgress lastReportedProgress;

		internal ProgressFilter(IProgress<DiscoveryProgress> upstreamReceiver)
		{
			this.upstreamReceiver = upstreamReceiver;
		}

		internal void OnDiscoveredMoreTypes(int count)
		{
			Interlocked.Add(ref totalTypes, count);
		}

		public void Report(DiscoveryProgress value)
		{
			if (upstreamReceiver == null)
			{
				return;
			}
			value = new DiscoveryProgress(value.CompletedSteps, totalTypes, value.Status);
			bool flag = false;
			lock (this)
			{
				if ((double)Math.Abs(value.Completion - lastReportedProgress.Completion) > 0.01 || value.Status != lastReportedProgress.Status)
				{
					lastReportedProgress = value;
					flag = true;
				}
			}
			if (flag)
			{
				upstreamReceiver.Report(lastReportedProgress);
			}
		}
	}

	private class CombinedPartDiscovery : PartDiscovery
	{
		private readonly IReadOnlyList<PartDiscovery> discoveryMechanisms;

		internal CombinedPartDiscovery(IReadOnlyList<PartDiscovery> discoveryMechanisms)
			: base(Resolver.DefaultInstance)
		{
			Requires.NotNull(discoveryMechanisms, "discoveryMechanisms");
			this.discoveryMechanisms = discoveryMechanisms;
		}

		protected override ComposablePartDefinition CreatePart(Type partType, bool typeExplicitlyRequested)
		{
			Requires.NotNull(partType, "partType");
			foreach (PartDiscovery discoveryMechanism in discoveryMechanisms)
			{
				ComposablePartDefinition composablePartDefinition = discoveryMechanism.CreatePart(partType, typeExplicitlyRequested);
				if (composablePartDefinition != null)
				{
					return composablePartDefinition;
				}
			}
			return null;
		}

		public override bool IsExportFactoryType(Type type)
		{
			Requires.NotNull(type, "type");
			return discoveryMechanisms.Any((PartDiscovery discovery) => discovery.IsExportFactoryType(type));
		}

		protected override IEnumerable<Type> GetTypes(Assembly assembly)
		{
			return assembly.GetTypes();
		}
	}

	public Resolver Resolver { get; }

	protected PartDiscovery(Resolver resolver)
	{
		Requires.NotNull(resolver, "resolver");
		Resolver = resolver;
	}

	public static PartDiscovery Combine(params PartDiscovery[] discoveryMechanisms)
	{
		Requires.NotNull(discoveryMechanisms, "discoveryMechanisms");
		if (discoveryMechanisms.Length == 1)
		{
			return discoveryMechanisms[0];
		}
		return new CombinedPartDiscovery(discoveryMechanisms);
	}

	public ComposablePartDefinition CreatePart(Type partType)
	{
		return CreatePart(partType, typeExplicitlyRequested: true);
	}

	public Task<DiscoveredParts> CreatePartsAsync(params Type[] partTypes)
	{
		return CreatePartsAsync(partTypes, CancellationToken.None);
	}

	public async Task<DiscoveredParts> CreatePartsAsync(IEnumerable<Type> partTypes, CancellationToken cancellationToken = default(CancellationToken))
	{
		Requires.NotNull(partTypes, "partTypes");
		Tuple<ITargetBlock<Type>, Task<DiscoveredParts>> tuple = CreateDiscoveryBlockChain(typeExplicitlyRequested: true, null, cancellationToken);
		foreach (Type partType in partTypes)
		{
			await tuple.Item1.SendAsync(partType);
		}
		tuple.Item1.Complete();
		return await tuple.Item2;
	}

	public Task<DiscoveredParts> CreatePartsAsync(Assembly assembly, CancellationToken cancellationToken = default(CancellationToken))
	{
		Requires.NotNull(assembly, "assembly");
		return CreatePartsAsync(new Assembly[1] { assembly }, null, cancellationToken);
	}

	public abstract bool IsExportFactoryType(Type type);

	public async Task<DiscoveredParts> CreatePartsAsync(IEnumerable<Assembly> assemblies, IProgress<DiscoveryProgress> progress = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		Requires.NotNull(assemblies, "assemblies");
		Tuple<ITargetBlock<Assembly>, Task<DiscoveredParts>> tuple = CreateAssemblyDiscoveryBlockChain(progress, cancellationToken);
		foreach (Assembly assembly in assemblies)
		{
			await tuple.Item1.SendAsync(assembly);
		}
		tuple.Item1.Complete();
		return await tuple.Item2;
	}

	public async Task<DiscoveredParts> CreatePartsAsync(IEnumerable<string> assemblyPaths, IProgress<DiscoveryProgress> progress = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		Requires.NotNull(assemblyPaths, "assemblyPaths");
		List<PartDiscoveryException> exceptions = new List<PartDiscoveryException>();
		Tuple<ITargetBlock<Assembly>, Task<DiscoveredParts>> tuple = CreateAssemblyDiscoveryBlockChain(progress, cancellationToken);
		TransformManyBlock<string, Assembly> assemblyLoader = new TransformManyBlock<string, Assembly>(delegate(string path)
		{
			try
			{
				return new Assembly[1] { Assembly.Load(AssemblyName.GetAssemblyName(path)) };
			}
			catch (Exception inner)
			{
				lock (exceptions)
				{
					exceptions.Add(new PartDiscoveryException(string.Format(CultureInfo.CurrentCulture, Strings.UnableToLoadAssembly, new object[1] { path }), inner)
					{
						AssemblyPath = path
					});
				}
				return Enumerable.Empty<Assembly>();
			}
		}, new ExecutionDataflowBlockOptions
		{
			CancellationToken = cancellationToken,
			MaxDegreeOfParallelism = Environment.ProcessorCount
		});
		assemblyLoader.LinkTo(tuple.Item1, new DataflowLinkOptions
		{
			PropagateCompletion = true
		});
		foreach (string assemblyPath in assemblyPaths)
		{
			await assemblyLoader.SendAsync(assemblyPath);
		}
		assemblyLoader.Complete();
		return (await tuple.Item2).Merge(new DiscoveredParts(Enumerable.Empty<ComposablePartDefinition>(), exceptions));
	}

	internal static void GetAssemblyNamesFromMetadataAttributes<TMetadataAttribute>(MemberInfo member, ISet<AssemblyName> assemblyNames) where TMetadataAttribute : class
	{
		Requires.NotNull(member, "member");
		Requires.NotNull(assemblyNames, "assemblyNames");
		Attribute[] attributes = member.GetAttributes<Attribute>();
		for (int i = 0; i < attributes.Length; i++)
		{
			Type type = attributes[i].GetType();
			if (type.GetTypeInfo().IsAttributeDefined<TMetadataAttribute>(inherit: true))
			{
				assemblyNames.Add(type.GetTypeInfo().Assembly.GetName());
			}
		}
	}

	protected internal static string GetContractName(Type type)
	{
		return ContractNameServices.GetTypeIdentity(type);
	}

	protected internal static Type GetTypeIdentityFromImportingType(Type type, bool importMany)
	{
		Requires.NotNull(type, "type");
		if (importMany)
		{
			type = GetElementTypeFromMany(type);
		}
		if (type.IsAnyLazyType() || type.IsExportFactoryTypeV1() || type.IsExportFactoryTypeV2())
		{
			return type.GetTypeInfo().GenericTypeArguments[0];
		}
		return type;
	}

	protected internal static Type GetElementTypeFromMany(Type type)
	{
		Requires.NotNull(type, "type");
		if (type.IsArray)
		{
			return type.GetElementType();
		}
		return (from iface in new Type[1] { type }.Concat(type.GetTypeInfo().ImplementedInterfaces)
			let ifaceInfo = iface.GetTypeInfo()
			where ifaceInfo.IsGenericType
			let genericTypeDef = ifaceInfo.GetGenericTypeDefinition()
			where genericTypeDef.Equals(typeof(ICollection<>)) || genericTypeDef.Equals(typeof(IEnumerable<>)) || genericTypeDef.Equals(typeof(IList<>))
			select ifaceInfo).First().GenericTypeArguments[0];
	}

	protected static ConstructorInfo GetImportingConstructor<TImportingConstructorAttribute>(Type type, bool publicOnly) where TImportingConstructorAttribute : Attribute
	{
		Requires.NotNull(type, "type");
		IEnumerable<ConstructorInfo> source = type.GetTypeInfo().DeclaredConstructors.Where((ConstructorInfo ctor) => !ctor.IsStatic && (ctor.IsPublic || !publicOnly));
		ConstructorInfo constructorInfo = source.SingleOrDefault((ConstructorInfo ctor) => ctor.IsAttributeDefined<TImportingConstructorAttribute>());
		ConstructorInfo constructorInfo2 = source.SingleOrDefault((ConstructorInfo ctor) => ctor.GetParameters().Length == 0);
		return constructorInfo ?? constructorInfo2;
	}

	protected ImmutableHashSet<IImportSatisfiabilityConstraint> GetMetadataViewConstraints(Type receivingType, bool importMany)
	{
		Requires.NotNull(receivingType, "receivingType");
		ImmutableHashSet<IImportSatisfiabilityConstraint> immutableHashSet = ImmutableHashSet.Create<IImportSatisfiabilityConstraint>();
		Type metadataType = GetMetadataType(importMany ? GetElementTypeFromMany(receivingType) : receivingType);
		if (metadataType != null)
		{
			immutableHashSet = immutableHashSet.Add(ImportMetadataViewConstraint.GetConstraint(TypeRef.Get(metadataType, Resolver), Resolver));
		}
		return immutableHashSet;
	}

	protected internal static ImmutableHashSet<IImportSatisfiabilityConstraint> GetExportTypeIdentityConstraints(Type contractType)
	{
		Requires.NotNull(contractType, "contractType");
		ImmutableHashSet<IImportSatisfiabilityConstraint> immutableHashSet = ImmutableHashSet<IImportSatisfiabilityConstraint>.Empty;
		if (!contractType.IsEquivalentTo(typeof(object)))
		{
			immutableHashSet = immutableHashSet.Add(new ExportTypeIdentityConstraint(contractType));
		}
		return immutableHashSet;
	}

	protected internal static ImmutableDictionary<string, object> GetImportMetadataForGenericTypeImport(Type contractType)
	{
		Requires.NotNull(contractType, "contractType");
		if (contractType.IsConstructedGenericType)
		{
			return ImmutableDictionary.Create<string, object>().Add("System.ComponentModel.Composition.GenericContractName", GetContractName(contractType.GetGenericTypeDefinition())).Add("System.ComponentModel.Composition.GenericParameters", contractType.GenericTypeArguments);
		}
		return ImmutableDictionary<string, object>.Empty;
	}

	protected static Array AddElement(Array priorArray, object value, Type elementType)
	{
		Array array;
		if (priorArray != null)
		{
			Type elementType2 = priorArray.GetType().GetElementType();
			array = Array.CreateInstance((elementType2 == typeof(object) && value != null) ? value.GetType() : elementType2, priorArray.Length + 1);
			Array.Copy(priorArray, array, priorArray.Length);
		}
		else
		{
			array = Array.CreateInstance(elementType ?? ((value != null) ? value.GetType() : typeof(object)), 1);
		}
		array.SetValue(value, array.Length - 1);
		return array;
	}

	protected abstract IEnumerable<Type> GetTypes(Assembly assembly);

	protected abstract ComposablePartDefinition CreatePart(Type partType, bool typeExplicitlyRequested);

	internal static bool IsImportManyCollectionTypeCreateable(ImportDefinitionBinding import)
	{
		Requires.NotNull(import, "import");
		return IsImportManyCollectionTypeCreateable(import.ImportingSiteType, import.ImportingSiteTypeWithoutCollection);
	}

	internal static bool IsImportManyCollectionTypeCreateable(Type collectionType, Type elementType)
	{
		Requires.NotNull(collectionType, "collectionType");
		Requires.NotNull(elementType, "elementType");
		Type type = typeof(ICollection<>).MakeGenericType(elementType);
		Type o = typeof(IEnumerable<>).MakeGenericType(elementType);
		Type o2 = typeof(IList<>).MakeGenericType(elementType);
		if (collectionType.IsArray || collectionType.Equals(o) || collectionType.Equals(o2) || collectionType.Equals(type))
		{
			return true;
		}
		Verify.Operation(type.GetTypeInfo().IsAssignableFrom(collectionType.GetTypeInfo()), Strings.CollectionTypeMustDeriveFromICollectionOfT);
		ConstructorInfo constructorInfo = collectionType.GetTypeInfo().DeclaredConstructors.FirstOrDefault((ConstructorInfo ctor) => !ctor.IsStatic && ctor.GetParameters().Length == 0);
		if (constructorInfo != null && constructorInfo.IsPublic)
		{
			return true;
		}
		return false;
	}

	private static Type GetMetadataType(Type receivingType)
	{
		Requires.NotNull(receivingType, "receivingType");
		if (receivingType.IsAnyLazyType() || receivingType.IsExportFactoryType())
		{
			Type[] genericTypeArguments = receivingType.GetTypeInfo().GenericTypeArguments;
			if (genericTypeArguments.Length == 2)
			{
				return genericTypeArguments[1];
			}
		}
		return null;
	}

	private Tuple<ITargetBlock<Type>, Task<DiscoveredParts>> CreateDiscoveryBlockChain(bool typeExplicitlyRequested, IProgress<DiscoveryProgress> progress, CancellationToken cancellationToken)
	{
		string status = Strings.ScanningMEFAssemblies;
		int typesScanned = 0;
		TransformBlock<Type, object> transformBlock = new TransformBlock<Type, object>(delegate(Type type)
		{
			try
			{
				return CreatePart(type, typeExplicitlyRequested);
			}
			catch (Exception inner)
			{
				return new PartDiscoveryException(string.Format(CultureInfo.CurrentCulture, Strings.FailureWhileScanningType, new object[1] { type.FullName }), inner)
				{
					AssemblyPath = type.GetTypeInfo().Assembly.Location,
					ScannedType = type
				};
			}
		}, new ExecutionDataflowBlockOptions
		{
			MaxDegreeOfParallelism = (Debugger.IsAttached ? 1 : Environment.ProcessorCount),
			CancellationToken = cancellationToken,
			MaxMessagesPerTask = 10,
			BoundedCapacity = 100
		});
		ImmutableHashSet<ComposablePartDefinition>.Builder parts = ImmutableHashSet.CreateBuilder<ComposablePartDefinition>();
		ImmutableList<PartDiscoveryException>.Builder errors = ImmutableList.CreateBuilder<PartDiscoveryException>();
		ActionBlock<object> aggregatingBlock = new ActionBlock<object>(delegate(object partOrException)
		{
			ComposablePartDefinition composablePartDefinition = partOrException as ComposablePartDefinition;
			PartDiscoveryException ex = partOrException as PartDiscoveryException;
			if (composablePartDefinition != null)
			{
				parts.Add(composablePartDefinition);
			}
			else if (ex != null)
			{
				errors.Add(ex);
			}
			progress.ReportNullSafe(new DiscoveryProgress(++typesScanned, 0, status));
		});
		transformBlock.LinkTo(aggregatingBlock, new DataflowLinkOptions
		{
			PropagateCompletion = true
		});
		TaskCompletionSource<DiscoveredParts> tcs = new TaskCompletionSource<DiscoveredParts>();
		Task.Run(async delegate
		{
			try
			{
				await aggregatingBlock.Completion;
				tcs.SetResult(new DiscoveredParts(parts.ToImmutable(), errors.ToImmutable()));
			}
			catch (Exception exception)
			{
				tcs.SetException(exception);
			}
		});
		return Tuple.Create((ITargetBlock<Type>)transformBlock, tcs.Task);
	}

	private Tuple<ITargetBlock<Assembly>, Task<DiscoveredParts>> CreateAssemblyDiscoveryBlockChain(IProgress<DiscoveryProgress> progress, CancellationToken cancellationToken)
	{
		ProgressFilter progressFilter = new ProgressFilter(progress);
		Tuple<ITargetBlock<Type>, Task<DiscoveredParts>> tuple = CreateDiscoveryBlockChain(typeExplicitlyRequested: false, progressFilter, cancellationToken);
		List<PartDiscoveryException> exceptions = new List<PartDiscoveryException>();
		TransformManyBlock<Assembly, Type> transformManyBlock = new TransformManyBlock<Assembly, Type>(delegate(Assembly a)
		{
			IReadOnlyCollection<Type> readOnlyCollection;
			try
			{
				readOnlyCollection = GetTypes(a).ToList();
			}
			catch (ReflectionTypeLoadException ex)
			{
				PartDiscoveryException item = new PartDiscoveryException(string.Format(CultureInfo.CurrentCulture, Strings.ReflectionTypeLoadExceptionWhileEnumeratingTypes, new object[1] { a.Location }), ex)
				{
					AssemblyPath = a.Location
				};
				lock (exceptions)
				{
					exceptions.Add(item);
				}
				readOnlyCollection = ex.Types.Where((Type t) => t != null).ToList();
			}
			catch (Exception inner)
			{
				PartDiscoveryException item2 = new PartDiscoveryException(string.Format(CultureInfo.CurrentCulture, Strings.UnableToEnumerateTypes, new object[1] { a.Location }), inner)
				{
					AssemblyPath = a.Location
				};
				lock (exceptions)
				{
					exceptions.Add(item2);
				}
				return Enumerable.Empty<Type>();
			}
			progressFilter.OnDiscoveredMoreTypes(readOnlyCollection.Count);
			return readOnlyCollection;
		}, new ExecutionDataflowBlockOptions
		{
			MaxDegreeOfParallelism = (Debugger.IsAttached ? 1 : Environment.ProcessorCount),
			CancellationToken = cancellationToken
		});
		transformManyBlock.LinkTo(tuple.Item1, new DataflowLinkOptions
		{
			PropagateCompletion = true
		});
		TaskCompletionSource<DiscoveredParts> tcs = new TaskCompletionSource<DiscoveredParts>();
		Task.Run(async delegate
		{
			try
			{
				DiscoveredParts discoveredParts = await tuple.Item2;
				tcs.SetResult(discoveredParts.Merge(new DiscoveredParts(Enumerable.Empty<ComposablePartDefinition>(), exceptions)));
			}
			catch (Exception exception)
			{
				tcs.SetException(exception);
			}
		});
		return Tuple.Create((ITargetBlock<Assembly>)transformManyBlock, tcs.Task);
	}
}
