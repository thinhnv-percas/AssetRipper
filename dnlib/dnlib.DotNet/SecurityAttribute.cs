using System.Collections.Generic;

namespace dnlib.DotNet;

public sealed class SecurityAttribute : ICustomAttribute
{
	private ITypeDefOrRef attrType;

	private readonly IList<CANamedArgument> namedArguments;

	public ITypeDefOrRef AttributeType
	{
		get
		{
			return attrType;
		}
		set
		{
			attrType = value;
		}
	}

	public string TypeFullName
	{
		get
		{
			ITypeDefOrRef typeDefOrRef = attrType;
			return (typeDefOrRef == null) ? string.Empty : typeDefOrRef.FullName;
		}
	}

	public IList<CANamedArgument> NamedArguments => namedArguments;

	public bool HasNamedArguments => namedArguments.Count > 0;

	public IEnumerable<CANamedArgument> Fields
	{
		get
		{
			IList<CANamedArgument> namedArguments = this.namedArguments;
			int count = namedArguments.Count;
			for (int i = 0; i < count; i++)
			{
				CANamedArgument namedArg = namedArguments[i];
				if (namedArg.IsField)
				{
					yield return namedArg;
				}
			}
		}
	}

	public IEnumerable<CANamedArgument> Properties
	{
		get
		{
			IList<CANamedArgument> namedArguments = this.namedArguments;
			int count = namedArguments.Count;
			for (int i = 0; i < count; i++)
			{
				CANamedArgument namedArg = namedArguments[i];
				if (namedArg.IsProperty)
				{
					yield return namedArg;
				}
			}
		}
	}

	public static SecurityAttribute CreateFromXml(ModuleDef module, string xml)
	{
		TypeRef typeRef = module.CorLibTypes.GetTypeRef("System.Security.Permissions", "PermissionSetAttribute");
		UTF8String value = new UTF8String(xml);
		CANamedArgument item = new CANamedArgument(isField: false, module.CorLibTypes.String, "XML", new CAArgument(module.CorLibTypes.String, value));
		List<CANamedArgument> list = new List<CANamedArgument> { item };
		return new SecurityAttribute(typeRef, list);
	}

	public SecurityAttribute()
		: this(null, null)
	{
	}

	public SecurityAttribute(ITypeDefOrRef attrType)
		: this(attrType, null)
	{
	}

	public SecurityAttribute(ITypeDefOrRef attrType, IList<CANamedArgument> namedArguments)
	{
		this.attrType = attrType;
		this.namedArguments = namedArguments ?? new List<CANamedArgument>();
	}

	public override string ToString()
	{
		return TypeFullName;
	}
}
