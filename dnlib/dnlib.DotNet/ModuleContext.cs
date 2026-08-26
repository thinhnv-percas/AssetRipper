using System.Threading;

namespace dnlib.DotNet;

public class ModuleContext
{
	private IAssemblyResolver assemblyResolver;

	private IResolver resolver;

	public IAssemblyResolver AssemblyResolver
	{
		get
		{
			if (assemblyResolver == null)
			{
				Interlocked.CompareExchange(ref assemblyResolver, NullResolver.Instance, null);
			}
			return assemblyResolver;
		}
		set
		{
			assemblyResolver = value;
		}
	}

	public IResolver Resolver
	{
		get
		{
			if (resolver == null)
			{
				Interlocked.CompareExchange(ref resolver, NullResolver.Instance, null);
			}
			return resolver;
		}
		set
		{
			resolver = value;
		}
	}

	public ModuleContext()
	{
	}

	public ModuleContext(IAssemblyResolver assemblyResolver)
		: this(assemblyResolver, new Resolver(assemblyResolver))
	{
	}

	public ModuleContext(IResolver resolver)
		: this(null, resolver)
	{
	}

	public ModuleContext(IAssemblyResolver assemblyResolver, IResolver resolver)
	{
		this.assemblyResolver = assemblyResolver;
		this.resolver = resolver;
		if (resolver == null && assemblyResolver != null)
		{
			this.resolver = new Resolver(assemblyResolver);
		}
	}
}
