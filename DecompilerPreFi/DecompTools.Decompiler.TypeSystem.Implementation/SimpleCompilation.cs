using System;
using System.Collections.Generic;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.TypeSystem.Implementation;

public class SimpleCompilation : ICompilation
{
	private readonly CacheManager cacheManager = new CacheManager();

	private IModule mainModule;

	private KnownTypeCache knownTypeCache;

	private IReadOnlyList<IModule> assemblies;

	private IReadOnlyList<IModule> referencedAssemblies;

	private bool initialized;

	private INamespace rootNamespace;

	public IModule MainModule
	{
		get
		{
			if (!initialized)
			{
				throw new InvalidOperationException("Compilation isn't initialized yet");
			}
			return mainModule;
		}
	}

	public IReadOnlyList<IModule> Modules
	{
		get
		{
			if (!initialized)
			{
				throw new InvalidOperationException("Compilation isn't initialized yet");
			}
			return assemblies;
		}
	}

	public IReadOnlyList<IModule> ReferencedModules
	{
		get
		{
			if (!initialized)
			{
				throw new InvalidOperationException("Compilation isn't initialized yet");
			}
			return referencedAssemblies;
		}
	}

	public INamespace RootNamespace
	{
		get
		{
			INamespace obj = LazyInit.VolatileRead(ref rootNamespace);
			if (obj != null)
			{
				return obj;
			}
			if (!initialized)
			{
				throw new InvalidOperationException("Compilation isn't initialized yet");
			}
			return LazyInit.GetOrSet(ref rootNamespace, CreateRootNamespace());
		}
	}

	public CacheManager CacheManager => cacheManager;

	public StringComparer NameComparer => StringComparer.Ordinal;

	public SimpleCompilation(IModuleReference mainAssembly, params IModuleReference[] assemblyReferences)
	{
		Init(mainAssembly, assemblyReferences);
	}

	public SimpleCompilation(IModuleReference mainAssembly, IEnumerable<IModuleReference> assemblyReferences)
	{
		Init(mainAssembly, assemblyReferences);
	}

	protected SimpleCompilation()
	{
	}

	protected void Init(IModuleReference mainAssembly, IEnumerable<IModuleReference> assemblyReferences)
	{
		if (mainAssembly == null)
		{
			throw new ArgumentNullException("mainAssembly");
		}
		if (assemblyReferences == null)
		{
			throw new ArgumentNullException("assemblyReferences");
		}
		SimpleTypeResolveContext context = new SimpleTypeResolveContext(this);
		mainModule = mainAssembly.Resolve(context);
		List<IModule> list = new List<IModule>();
		list.Add(mainModule);
		List<IModule> list2 = new List<IModule>();
		foreach (IModuleReference assemblyReference in assemblyReferences)
		{
			IModule module;
			try
			{
				module = assemblyReference.Resolve(context);
			}
			catch (InvalidOperationException)
			{
				throw new InvalidOperationException("Tried to initialize compilation with an invalid assembly reference. (Forgot to load the assembly reference ? - see CecilLoader)");
			}
			if (module != null && !list.Contains(module))
			{
				list.Add(module);
			}
			if (module != null && !list2.Contains(module))
			{
				list2.Add(module);
			}
		}
		assemblies = list.AsReadOnly();
		referencedAssemblies = list2.AsReadOnly();
		knownTypeCache = new KnownTypeCache(this);
		initialized = true;
	}

	protected virtual INamespace CreateRootNamespace()
	{
		checked
		{
			INamespace[] array = new INamespace[referencedAssemblies.Count + 1];
			array[0] = mainModule.RootNamespace;
			for (int i = 0; i < referencedAssemblies.Count; i++)
			{
				array[i + 1] = referencedAssemblies[i].RootNamespace;
			}
			return new MergedNamespace(this, array);
		}
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
		return "[" + GetType().Name + " " + mainModule.AssemblyName + "]";
	}
}
