using System;
using System.Collections.Generic;
using System.Threading;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.Utils;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation;

internal sealed class CecilResolvedAttribute : IAttribute
{
	private readonly ITypeResolveContext context;

	private readonly byte[] blob;

	private readonly IList<ITypeReference> ctorParameterTypes;

	private readonly IType attributeType;

	private IMethod constructor;

	private volatile bool constructorResolved;

	private IList<ResolveResult> positionalArguments;

	private IList<KeyValuePair<IMember, ResolveResult>> namedArguments;

	DomRegion IAttribute.Region => DomRegion.Empty;

	public IType AttributeType => attributeType;

	public IMethod Constructor
	{
		get
		{
			if (!constructorResolved)
			{
				constructor = ResolveConstructor();
				constructorResolved = true;
			}
			return constructor;
		}
	}

	public IList<ResolveResult> PositionalArguments
	{
		get
		{
			IList<ResolveResult> list = LazyInit.VolatileRead(ref positionalArguments);
			if (list != null)
			{
				return list;
			}
			DecodeBlob();
			return positionalArguments;
		}
	}

	public IList<KeyValuePair<IMember, ResolveResult>> NamedArguments
	{
		get
		{
			IList<KeyValuePair<IMember, ResolveResult>> list = LazyInit.VolatileRead(ref namedArguments);
			if (list != null)
			{
				return list;
			}
			DecodeBlob();
			return namedArguments;
		}
	}

	public CecilResolvedAttribute(ITypeResolveContext context, UnresolvedAttributeBlob unresolved)
	{
		this.context = context;
		blob = unresolved.blob;
		ctorParameterTypes = unresolved.ctorParameterTypes;
		attributeType = unresolved.attributeType.Resolve(context);
	}

	public CecilResolvedAttribute(ITypeResolveContext context, IType attributeType)
	{
		this.context = context;
		this.attributeType = attributeType;
		ctorParameterTypes = EmptyList<ITypeReference>.Instance;
	}

	private IMethod ResolveConstructor()
	{
		IList<IType> parameterTypes = ctorParameterTypes.Resolve(context);
		foreach (IMethod constructor in attributeType.GetConstructors((IUnresolvedMethod m) => m.Parameters.Count == parameterTypes.Count))
		{
			bool flag = true;
			for (int num = 0; num < parameterTypes.Count; num++)
			{
				if (!constructor.Parameters[num].Type.Equals(parameterTypes[num]))
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				return constructor;
			}
		}
		return null;
	}

	public override string ToString()
	{
		return "[" + attributeType.ToString() + "(...)]";
	}

	private void DecodeBlob()
	{
		List<ResolveResult> value = new List<ResolveResult>();
		List<KeyValuePair<IMember, ResolveResult>> value2 = new List<KeyValuePair<IMember, ResolveResult>>();
		DecodeBlob(value, value2);
		Interlocked.CompareExchange(ref positionalArguments, value, null);
		Interlocked.CompareExchange(ref namedArguments, value2, null);
	}

	private void DecodeBlob(List<ResolveResult> positionalArguments, List<KeyValuePair<IMember, ResolveResult>> namedArguments)
	{
		if (blob == null)
		{
			return;
		}
		BlobReader blobReader = new BlobReader(blob, context.CurrentAssembly);
		if (blobReader.ReadUInt16() != 1)
		{
			return;
		}
		foreach (IType item2 in ctorParameterTypes.Resolve(context))
		{
			bool flag;
			try
			{
				ResolveResult resolveResult = blobReader.ReadFixedArg(item2);
				positionalArguments.Add(resolveResult);
				flag = resolveResult.IsError;
			}
			catch (Exception)
			{
				flag = true;
			}
			if (flag)
			{
				while (positionalArguments.Count < ctorParameterTypes.Count)
				{
					positionalArguments.Add(ErrorResolveResult.UnknownError);
				}
				return;
			}
		}
		try
		{
			ushort num = blobReader.ReadUInt16();
			for (int i = 0; i < num; i++)
			{
				KeyValuePair<IMember, ResolveResult> item = blobReader.ReadNamedArg(attributeType);
				if (item.Key != null)
				{
					namedArguments.Add(item);
				}
			}
		}
		catch (Exception)
		{
		}
	}
}
