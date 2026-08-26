using DevX.Cecil.Binary;
using DevX.Cecil.Cil;
using DevX.Cecil.Metadata;
using System;
using System.Reflection;
using System.Text;

namespace DevX.Cecil
{
	public sealed class ModuleDefinition : ModuleReference, ICustomAttributeProvider, IMetadataScope, IMetadataTokenProvider, IReflectionStructureVisitable, IReflectionVisitable
	{
		private Guid m_mvid;

		private bool m_main;

		private bool m_manifestOnly;

		private AssemblyNameReferenceCollection m_asmRefs;

		private ModuleReferenceCollection m_modRefs;

		private ResourceCollection m_res;

		private TypeDefinitionCollection m_types;

		private TypeReferenceCollection m_refs;

		private ExternTypeCollection m_externs;

		private MemberReferenceCollection m_members;

		private CustomAttributeCollection m_customAttrs;

		private AssemblyDefinition m_asm;

		private Image m_image;

		private ImageReader m_imgReader;

		private ReflectionController m_controller;

		private MetadataResolver m_resolver;

		private SecurityDeclarationReader m_secReader;

		public Guid Mvid
		{
			get
			{
				return m_mvid;
			}
			set
			{
				m_mvid = value;
			}
		}

		public bool Main
		{
			get
			{
				return m_main;
			}
			set
			{
				m_main = value;
			}
		}

		public AssemblyNameReferenceCollection AssemblyReferences => m_asmRefs;

		public ModuleReferenceCollection ModuleReferences => m_modRefs;

		public ResourceCollection Resources => m_res;

		public TypeDefinitionCollection Types => m_types;

		public TypeReferenceCollection TypeReferences => m_refs;

		public MemberReferenceCollection MemberReferences => m_members;

		public ExternTypeCollection ExternTypes
		{
			get
			{
				if (m_externs == null)
				{
					m_externs = new ExternTypeCollection(this);
				}
				return m_externs;
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

		public AssemblyDefinition Assembly => m_asm;

		internal ReflectionController Controller => m_controller;

		internal MetadataResolver Resolver => m_resolver;

		internal ImageReader ImageReader => m_imgReader;

		public Image Image
		{
			get
			{
				return m_image;
			}
			set
			{
				m_image = value;
				m_secReader = null;
			}
		}

		public ModuleDefinition(string name, AssemblyDefinition asm)
			: this(name, asm, null, main: false)
		{
		}

		public ModuleDefinition(string name, AssemblyDefinition asm, bool main)
			: this(name, asm, null, main)
		{
		}

		internal ModuleDefinition(string name, AssemblyDefinition asm, StructureReader reader, bool main)
			: base(name)
		{
			if (asm == null)
			{
				throw new ArgumentNullException("asm");
			}
			if (name == null || name.Length == 0)
			{
				throw new ArgumentNullException("name");
			}
			m_asm = asm;
			m_main = main;
			m_mvid = Guid.NewGuid();
			if (reader != null)
			{
				m_image = reader.Image;
				m_imgReader = reader.ImageReader;
				m_manifestOnly = reader.ManifestOnly;
			}
			else
			{
				m_image = Image.CreateImage();
			}
			m_modRefs = new ModuleReferenceCollection(this);
			m_asmRefs = new AssemblyNameReferenceCollection(this);
			m_res = new ResourceCollection(this);
			m_types = new TypeDefinitionCollection(this);
			m_refs = new TypeReferenceCollection(this);
			m_members = new MemberReferenceCollection(this);
			m_controller = new ReflectionController(this);
			m_resolver = new MetadataResolver(asm);
		}

		public IMetadataTokenProvider LookupByToken(MetadataToken token)
		{
			return m_controller.Reader.LookupByToken(token);
		}

		public IMetadataTokenProvider LookupByToken(TokenType table, int rid)
		{
			return LookupByToken(new MetadataToken(table, (uint)rid));
		}

		private void CheckContext(TypeDefinition context)
		{
			if (context.Module != this)
			{
				throw new ArgumentException("The context parameter does not belongs to this module");
			}
			CheckGenericParameterProvider(context);
		}

		private void CheckContext(MethodDefinition context)
		{
			CheckGenericParameterProvider(context);
		}

		private static void CheckGenericParameterProvider(IGenericParameterProvider context)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}
			if (context.GenericParameters.Count == 0)
			{
				throw new ArgumentException("The context parameter is not a generic type");
			}
		}

		private ImportContext GetContext()
		{
			return new ImportContext(m_controller.Importer);
		}

		private static ImportContext GetContext(IImporter importer)
		{
			return new ImportContext(importer);
		}

		private ImportContext GetContext(TypeDefinition context)
		{
			return new ImportContext(m_controller.Importer, context);
		}

		private ImportContext GetContext(MethodDefinition context)
		{
			return new ImportContext(m_controller.Importer, context);
		}

		private static ImportContext GetContext(IImporter importer, TypeDefinition context)
		{
			return new ImportContext(importer, context);
		}

		public TypeReference Import(Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			return m_controller.Helper.ImportSystemType(type, GetContext());
		}

		public TypeReference Import(Type type, TypeDefinition context)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			CheckContext(context);
			return m_controller.Helper.ImportSystemType(type, GetContext(context));
		}

		public TypeReference Import(Type type, MethodDefinition context)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			CheckContext(context);
			return m_controller.Helper.ImportSystemType(type, GetContext(context));
		}

		public MethodReference Import(MethodBase meth)
		{
			if (meth == null)
			{
				throw new ArgumentNullException("meth");
			}
			if (meth is ConstructorInfo)
			{
				return m_controller.Helper.ImportConstructorInfo(meth as ConstructorInfo, GetContext());
			}
			return m_controller.Helper.ImportMethodInfo(meth as MethodInfo, GetContext());
		}

		public MethodReference Import(MethodBase meth, TypeDefinition context)
		{
			if (meth == null)
			{
				throw new ArgumentNullException("meth");
			}
			CheckContext(context);
			ImportContext context2 = GetContext(context);
			if (meth is ConstructorInfo)
			{
				return m_controller.Helper.ImportConstructorInfo(meth as ConstructorInfo, context2);
			}
			return m_controller.Helper.ImportMethodInfo(meth as MethodInfo, context2);
		}

		public FieldReference Import(FieldInfo field)
		{
			if (field == null)
			{
				throw new ArgumentNullException("field");
			}
			return m_controller.Helper.ImportFieldInfo(field, GetContext());
		}

		public FieldReference Import(FieldInfo field, TypeDefinition context)
		{
			if (field == null)
			{
				throw new ArgumentNullException("field");
			}
			CheckContext(context);
			return m_controller.Helper.ImportFieldInfo(field, GetContext(context));
		}

		public FieldReference Import(FieldInfo field, MethodDefinition context)
		{
			if (field == null)
			{
				throw new ArgumentNullException("field");
			}
			CheckContext(context);
			return m_controller.Helper.ImportFieldInfo(field, GetContext(context));
		}

		public TypeReference Import(TypeReference type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			return m_controller.Importer.ImportTypeReference(type, GetContext());
		}

		public TypeReference Import(TypeReference type, TypeDefinition context)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			CheckContext(context);
			return m_controller.Importer.ImportTypeReference(type, GetContext(context));
		}

		public TypeReference Import(TypeReference type, MethodDefinition context)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			CheckContext(context);
			return m_controller.Importer.ImportTypeReference(type, GetContext(context));
		}

		public MethodReference Import(MethodReference meth)
		{
			if (meth == null)
			{
				throw new ArgumentNullException("meth");
			}
			return m_controller.Importer.ImportMethodReference(meth, GetContext());
		}

		public MethodReference Import(MethodReference meth, TypeDefinition context)
		{
			if (meth == null)
			{
				throw new ArgumentNullException("meth");
			}
			CheckContext(context);
			return m_controller.Importer.ImportMethodReference(meth, GetContext(context));
		}

		public MethodReference Import(MethodReference meth, MethodDefinition context)
		{
			if (meth == null)
			{
				throw new ArgumentNullException("meth");
			}
			CheckContext(context);
			return m_controller.Importer.ImportMethodReference(meth, GetContext(context));
		}

		public FieldReference Import(FieldReference field)
		{
			if (field == null)
			{
				throw new ArgumentNullException("field");
			}
			return m_controller.Importer.ImportFieldReference(field, GetContext());
		}

		public FieldReference Import(FieldReference field, TypeDefinition context)
		{
			if (field == null)
			{
				throw new ArgumentNullException("field");
			}
			CheckContext(context);
			return m_controller.Importer.ImportFieldReference(field, GetContext(context));
		}

		public FieldReference Import(FieldReference field, MethodDefinition context)
		{
			if (field == null)
			{
				throw new ArgumentNullException("field");
			}
			CheckContext(context);
			return m_controller.Importer.ImportFieldReference(field, GetContext(context));
		}

		private static FieldDefinition ImportFieldDefinition(FieldDefinition field, ImportContext context)
		{
			return FieldDefinition.Clone(field, context);
		}

		private static MethodDefinition ImportMethodDefinition(MethodDefinition meth, ImportContext context)
		{
			return MethodDefinition.Clone(meth, context);
		}

		private static TypeDefinition ImportTypeDefinition(TypeDefinition type, ImportContext context)
		{
			return TypeDefinition.Clone(type, context);
		}

		public TypeDefinition Inject(TypeDefinition type)
		{
			return Inject(type, m_controller.Importer);
		}

		public TypeDefinition Inject(TypeDefinition type, IImporter importer)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (importer == null)
			{
				throw new ArgumentNullException("importer");
			}
			TypeDefinition typeDefinition = ImportTypeDefinition(type, GetContext(importer));
			Types.Add(typeDefinition);
			return typeDefinition;
		}

		public TypeDefinition Inject(TypeDefinition type, TypeDefinition context)
		{
			return Inject(type, context, m_controller.Importer);
		}

		public TypeDefinition Inject(TypeDefinition type, TypeDefinition context, IImporter importer)
		{
			Check(type, context, importer);
			TypeDefinition typeDefinition = ImportTypeDefinition(type, GetContext(importer, context));
			context.NestedTypes.Add(typeDefinition);
			return typeDefinition;
		}

		public MethodDefinition Inject(MethodDefinition meth, TypeDefinition context)
		{
			return Inject(meth, context, m_controller.Importer);
		}

		private void Check(IMemberDefinition definition, TypeDefinition context, IImporter importer)
		{
			if (definition == null)
			{
				throw new ArgumentNullException("definition");
			}
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}
			if (importer == null)
			{
				throw new ArgumentNullException("importer");
			}
			if (context.Module != this)
			{
				throw new ArgumentException("The context parameter does not belongs to this module");
			}
		}

		public MethodDefinition Inject(MethodDefinition meth, TypeDefinition context, IImporter importer)
		{
			Check(meth, context, importer);
			MethodDefinition methodDefinition = ImportMethodDefinition(meth, GetContext(importer, context));
			context.Methods.Add(methodDefinition);
			return methodDefinition;
		}

		public FieldDefinition Inject(FieldDefinition field, TypeDefinition context)
		{
			return Inject(field, context, m_controller.Importer);
		}

		public FieldDefinition Inject(FieldDefinition field, TypeDefinition context, IImporter importer)
		{
			Check(field, context, importer);
			FieldDefinition fieldDefinition = ImportFieldDefinition(field, GetContext(importer, context));
			context.Fields.Add(fieldDefinition);
			return fieldDefinition;
		}

		public void FullLoad()
		{
			if (m_manifestOnly)
			{
				m_controller.Reader.VisitModuleDefinition(this);
			}
			foreach (TypeDefinition type in Types)
			{
				foreach (MethodDefinition method in type.Methods)
				{
					method.LoadBody();
				}
				foreach (MethodDefinition constructor in type.Constructors)
				{
					constructor.LoadBody();
				}
			}
			if (m_controller.Reader.SymbolReader != null)
			{
				m_controller.Reader.SymbolReader.Dispose();
				m_controller.Reader.SymbolReader = null;
			}
		}

		public void LoadSymbols()
		{
			m_controller.Reader.SymbolReader = SymbolStoreHelper.GetReader(this);
		}

		public void LoadSymbols(ISymbolReader reader)
		{
			m_controller.Reader.SymbolReader = reader;
		}

		public void SaveSymbols()
		{
			m_controller.Writer.SaveSymbols = true;
		}

		public void SaveSymbols(ISymbolWriter writer)
		{
			SaveSymbols();
			m_controller.Writer.SymbolWriter = writer;
		}

		public void SaveSymbols(string outputDirectory)
		{
			SaveSymbols();
			m_controller.Writer.OutputFile = outputDirectory;
		}

		public void SaveSymbols(string outputDirectory, ISymbolWriter writer)
		{
			SaveSymbols(outputDirectory);
			m_controller.Writer.SymbolWriter = writer;
		}

		public byte[] GetAsByteArray(CustomAttribute ca)
		{
			if (!ca.Resolved)
			{
				if (ca.Blob != null)
				{
					return ca.Blob;
				}
				return new byte[0];
			}
			return m_controller.Writer.SignatureWriter.CompressCustomAttribute(ReflectionWriter.GetCustomAttributeSig(ca), ca.Constructor);
		}

		public byte[] GetAsByteArray(SecurityDeclaration dec)
		{
			if (!dec.Resolved)
			{
				return dec.Blob;
			}
			if (dec.PermissionSet != null)
			{
				return Encoding.Unicode.GetBytes(dec.PermissionSet.ToXml().ToString());
			}
			return new byte[0];
		}

		public CustomAttribute FromByteArray(MethodReference ctor, byte[] data)
		{
			return m_controller.Reader.GetCustomAttribute(ctor, data);
		}

		public SecurityDeclaration FromByteArray(SecurityAction action, byte[] declaration)
		{
			if (m_secReader == null)
			{
				m_secReader = new SecurityDeclarationReader(Image.MetadataRoot, m_controller.Reader);
			}
			return m_secReader.FromByteArray(action, declaration);
		}

		public override void Accept(IReflectionStructureVisitor visitor)
		{
			visitor.VisitModuleDefinition(this);
			AssemblyReferences.Accept(visitor);
			ModuleReferences.Accept(visitor);
			Resources.Accept(visitor);
		}

		public void Accept(IReflectionVisitor visitor)
		{
			visitor.VisitModuleDefinition(this);
			Types.Accept(visitor);
			TypeReferences.Accept(visitor);
		}

		public override string ToString()
		{
			string arg = (!m_main) ? "Mvid=" : "(main), Mvid=";
			return arg + m_mvid;
		}
	}
}
