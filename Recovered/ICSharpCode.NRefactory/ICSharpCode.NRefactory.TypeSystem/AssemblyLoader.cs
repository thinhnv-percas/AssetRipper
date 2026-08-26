using ICSharpCode.NRefactory.Documentation;
using ICSharpCode.NRefactory.TypeSystem.Implementation;
using System;
using System.Reflection;
using System.Threading;

namespace ICSharpCode.NRefactory.TypeSystem
{
	public abstract class AssemblyLoader
	{
		[CLSCompliant(false)]
		protected InterningProvider interningProvider = new SimpleInterningProvider();

		public bool IncludeInternalMembers
		{
			get;
			set;
		}

		public CancellationToken CancellationToken
		{
			get;
			set;
		}

		public IDocumentationProvider DocumentationProvider
		{
			get;
			set;
		}

		public InterningProvider InterningProvider
		{
			get
			{
				return interningProvider;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException();
				}
				interningProvider = value;
			}
		}

		public static AssemblyLoader Create()
		{
			return Create(AssemblyLoaderBackend.Auto);
		}

		public static AssemblyLoader Create(AssemblyLoaderBackend backend)
		{
			switch (backend)
			{
			case AssemblyLoaderBackend.Auto:
			case AssemblyLoaderBackend.Cecil:
				return (AssemblyLoader)Assembly.Load("ICSharpCode.NRefactory.Cecil").CreateInstance("ICSharpCode.NRefactory.TypeSystem.CecilLoader");
			case AssemblyLoaderBackend.IKVM:
				return (AssemblyLoader)Assembly.Load("ICSharpCode.NRefactory.IKVM").CreateInstance("ICSharpCode.NRefactory.TypeSystem.IkvmLoader");
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		public abstract IUnresolvedAssembly LoadAssemblyFile(string fileName);
	}
}
