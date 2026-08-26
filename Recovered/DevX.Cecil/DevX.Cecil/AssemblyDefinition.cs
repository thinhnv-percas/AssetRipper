using DevX.Cecil.Metadata;
using System;
using System.Collections;

namespace DevX.Cecil
{
	public class AssemblyDefinition : IAnnotationProvider, ICustomAttributeProvider, IHasSecurity, IMetadataTokenProvider, IReflectionStructureVisitable
	{
		private MetadataToken m_token;

		private AssemblyNameDefinition m_asmName;

		private ModuleDefinitionCollection m_modules;

		private SecurityDeclarationCollection m_secDecls;

		private CustomAttributeCollection m_customAttrs;

		private MethodDefinition m_ep;

		private TargetRuntime m_runtime;

		private AssemblyKind m_kind;

		private ModuleDefinition m_mainModule;

		private StructureReader m_reader;

		private IAssemblyResolver m_resolver;

		private IDictionary m_annotations;

		IDictionary IAnnotationProvider.Annotations
		{
			get
			{
				if (m_annotations == null)
				{
					m_annotations = new Hashtable();
				}
				return m_annotations;
			}
		}

		public MetadataToken MetadataToken
		{
			get
			{
				return m_token;
			}
			set
			{
				m_token = value;
			}
		}

		public AssemblyNameDefinition Name => m_asmName;

		public ModuleDefinitionCollection Modules => m_modules;

		public bool HasSecurityDeclarations => m_secDecls != null && m_secDecls.Count > 0;

		public SecurityDeclarationCollection SecurityDeclarations
		{
			get
			{
				if (m_secDecls == null)
				{
					m_secDecls = new SecurityDeclarationCollection(this);
				}
				return m_secDecls;
			}
		}

		public bool HasCustomAttributes => m_customAttrs != null && m_customAttrs.Count > 0;

		public CustomAttributeCollection CustomAttributes
		{
			get
			{
				if (m_customAttrs == null)
				{
					m_customAttrs = new CustomAttributeCollection(this);
				}
				return m_customAttrs;
			}
		}

		public MethodDefinition EntryPoint
		{
			get
			{
				return m_ep;
			}
			set
			{
				m_ep = value;
			}
		}

		public TargetRuntime Runtime
		{
			get
			{
				return m_runtime;
			}
			set
			{
				m_runtime = value;
			}
		}

		public AssemblyKind Kind
		{
			get
			{
				return m_kind;
			}
			set
			{
				m_kind = value;
			}
		}

		public ModuleDefinition MainModule
		{
			get
			{
				if (m_mainModule == null)
				{
					foreach (ModuleDefinition module in m_modules)
					{
						if (module.Main)
						{
							m_mainModule = module;
							break;
						}
					}
				}
				return m_mainModule;
			}
		}

		internal StructureReader Reader => m_reader;

		public IAssemblyResolver Resolver
		{
			get
			{
				return m_resolver;
			}
			set
			{
				m_resolver = value;
			}
		}

		internal AssemblyDefinition(AssemblyNameDefinition name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			m_asmName = name;
			m_modules = new ModuleDefinitionCollection(this);
			m_resolver = new DefaultAssemblyResolver();
		}

		internal AssemblyDefinition(AssemblyNameDefinition name, StructureReader reader)
			: this(name)
		{
			m_reader = reader;
		}

		public void Accept(IReflectionStructureVisitor visitor)
		{
			visitor.VisitAssemblyDefinition(this);
			m_asmName.Accept(visitor);
			m_modules.Accept(visitor);
			visitor.TerminateAssemblyDefinition(this);
		}

		public override string ToString()
		{
			return m_asmName.FullName;
		}
	}
}
