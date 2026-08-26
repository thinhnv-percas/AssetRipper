using ICSharpCode.NRefactory.Editor;
using ICSharpCode.NRefactory.TypeSystem;
using System;

namespace ICSharpCode.NRefactory.Documentation
{
	public class DocumentationComment
	{
		private ITextSource xml;

		protected readonly ITypeResolveContext context;

		public ITextSource Xml => xml;

		public DocumentationComment(ITextSource xml, ITypeResolveContext context)
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
			this.xml = new StringTextSource(xml);
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
			return Xml.Text;
		}

		public static implicit operator string(DocumentationComment documentationComment)
		{
			return documentationComment?.ToString();
		}
	}
}
