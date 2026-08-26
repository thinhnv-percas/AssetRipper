using System;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.Documentation;

public class DocumentationComment
{
	private string xml;

	protected readonly ITypeResolveContext context;

	public string Xml => xml;

	public DocumentationComment(string xml, ITypeResolveContext context)
	{
		if (xml == null)
		{
			throw new ArgumentNullException("xml");
		}
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		this.xml = xml;
		this.context = context;
	}

	public virtual IEntity ResolveCref(string cref)
	{
		try
		{
			return IdStringProvider.FindEntity(cref, context);
		}
		catch (ReflectionNameParseException)
		{
			return null;
		}
	}

	public override string ToString()
	{
		return Xml;
	}

	public static implicit operator string(DocumentationComment documentationComment)
	{
		return documentationComment?.ToString();
	}
}
