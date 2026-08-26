using System;
using System.Collections.Generic;
using ICSharpCode.NRefactory.Utils;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation;

public class SimpleCompilation : ICompilation
{
	private readonly ISolutionSnapshot solutionSnapshot;

	private readonly ITypeResolveContext context;

	private readonly CacheManager cacheManager = new CacheManager();

	private readonly KnownTypeCache knownTypeCache;

	private readonly IAssembly mainAssembly;

	private readonly IList<IAssembly> assemblies;

	private readonly IList<IAssembly> referencedAssemblies;

	private INamespace rootNamespace;

	public IAssembly MainAssembly
	{
		get
		{
			if (mainAssembly == null)
			{
				throw new InvalidOperationException("Compilation isn't initialized yet");
			}
			return mainAssembly;
		}
	}

	public IList<IAssembly> Assemblies
	{
		get
		{
			if (assemblies == null)
			{
				throw new InvalidOperationException("Compilation isn't initialized yet");
			}
			return assemblies;
		}
	}

	public IList<IAssembly> ReferencedAssemblies
	{
		get
		{
			if (referencedAssemblies == null)
			{
				throw new InvalidOperationException("Compilation isn't initialized yet");
			}
			return referencedAssemblies;
		}
	}

	public ITypeResolveContext TypeResolveContext => context;

	public INamespace RootNamespace
	{
		get
		{
			INamespace obj = LazyInit.VolatileRead(ref rootNamespace);
			if (obj != null)
			{
				return obj;
			}
			if (referencedAssemblies == null)
			{
				throw new InvalidOperationException("Compilation isn't initialized yet");
			}
			return LazyInit.GetOrSet(ref rootNamespace, CreateRootNamespace());
		}
	}

	public CacheManager CacheManager => cacheManager;

	public StringComparer NameComparer => StringComparer.Ordinal;

	public ISolutionSnapshot SolutionSnapshot => solutionSnapshot;

	public SimpleCompilation(IUnresolvedAssembly mainAssembly, params IAssemblyReference[] assemblyReferences)
		: this((ISolutionSnapshot)new DefaultSolutionSnapshot(), mainAssembly, (IEnumerable<IAssemblyReference>)assemblyReferences)
	{
	}

	public SimpleCompilation(IUnresolvedAssembly mainAssembly, IEnumerable<IAssemblyReference> assemblyReferences)
		: this(new DefaultSolutionSnapshot(), mainAssembly, assemblyReferences)
	{
	}

	public SimpleCompilation(ISolutionSnapshot solutionSnapshot, IUnresolvedAssembly mainAssembly, params IAssemblyReference[] assemblyReferences)
		: this(solutionSnapshot, mainAssembly, (IEnumerable<IAssemblyReference>)assemblyReferences)
	{
	}

	public SimpleCompilation(ISolutionSnapshot solutionSnapshot, IUnresolvedAssembly mainAssembly, IEnumerable<IAssemblyReference> assemblyReferences)
	{
		if (solutionSnapshot == null)
		{
			throw new ArgumentNullException("solutionSnapshot");
		}
		if (mainAssembly == null)
		{
			throw new ArgumentNullException("mainAssembly");
		}
		if (assemblyReferences == null)
		{
			throw new ArgumentNullException("assemblyReferences");
		}
		this.solutionSnapshot = solutionSnapshot;
		context = new SimpleTypeResolveContext(this);
		this.mainAssembly = mainAssembly.Resolve(context);
		List<IAssembly> list = new List<IAssembly> { this.mainAssembly };
		List<IAssembly> list2 = new List<IAssembly>();
		foreach (IAssemblyReference assemblyReference in assemblyReferences)
		{
			IAssembly assembly;
			try
			{
				assembly = assemblyReference.Resolve(context);
			}
			catch (InvalidOperationException)
			{
				throw new InvalidOperationException("Tried to initialize compilation with an invalid assembly reference. (Forgot to load the assembly reference ? - see CecilLoader)");
			}
			if (assembly != null && !list.Contains(assembly))
			{
				list.Add(assembly);
			}
			if (assembly != null && !list2.Contains(assembly))
			{
				list2.Add(assembly);
			}
		}
		assemblies = list.AsReadOnly();
		referencedAssemblies = list2.AsReadOnly();
		knownTypeCache = new KnownTypeCache(this);
	}

	protected virtual INamespace CreateRootNamespace()
	{
		INamespace[] array = new INamespace[referencedAssemblies.Count + 1];
		array[0] = mainAssembly.RootNamespace;
		for (int i = 0; i < referencedAssemblies.Count; i++)
		{
			array[i + 1] = referencedAssemblies[i].RootNamespace;
		}
		return new MergedNamespace(this, array);
	}

	public virtual INamespace GetNamespaceForExternAlias(string alias)
	{
		if (string.IsNullOrEmpty(alias))
		{
			return RootNamespace;
		}
		return null;
	}

	public IType FindType(KnownTypeCode typeCode)
	{
		return knownTypeCache.FindType(typeCode);
	}

	public override string ToString()
	{
		return "[SimpleCompilation " + mainAssembly.AssemblyName + "]";
	}
}
