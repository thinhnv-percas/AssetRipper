#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Threading;
using System.Xml;
using DecompTools.Decompiler.CSharp.OutputVisitor;
using DecompTools.Decompiler.CSharp.Resolver;
using DecompTools.Decompiler.CSharp.Syntax;
using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;
using DecompTools.Decompiler.CSharp.Transforms;
using DecompTools.Decompiler.DebugInfo;
using DecompTools.Decompiler.Disassembler;
using DecompTools.Decompiler.Documentation;
using DecompTools.Decompiler.IL;
using DecompTools.Decompiler.IL.ControlFlow;
using DecompTools.Decompiler.IL.Transforms;
using DecompTools.Decompiler.Metadata;
using DecompTools.Decompiler.Semantics;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.CSharp;

public class CSharpDecompiler
{
	private enum EnumValueDisplayMode
	{
		None,
		All,
		FirstOnly
	}

	private readonly IDecompilerTypeSystem typeSystem;

	private readonly MetadataModule module;

	private readonly MetadataReader metadata;

	private readonly DecompilerSettings settings;

	private SyntaxTree syntaxTree;

	private List<IILTransform> ilTransforms = GetILTransforms();

	private List<IAstTransform> astTransforms = GetAstTransforms();

	private static readonly DecompTools.Decompiler.CSharp.Syntax.Attribute obsoleteAttributePattern = new DecompTools.Decompiler.CSharp.Syntax.Attribute
	{
		Type = new TypePattern(typeof(ObsoleteAttribute)),
		Arguments = 
		{
			(Expression)new PrimitiveExpression("Types with embedded references are not supported in this version of your compiler."),
			(Expression)new Choice
			{
				new PrimitiveExpression(true),
				new PrimitiveExpression(false)
			}
		}
	};

	public CancellationToken CancellationToken { get; set; }

	public IDecompilerTypeSystem TypeSystem => typeSystem;

	public IDebugInfoProvider DebugInfoProvider { get; set; }

	public IDocumentationProvider DocumentationProvider { get; set; }

	public IList<IILTransform> ILTransforms => ilTransforms;

	public IList<IAstTransform> AstTransforms => astTransforms;

	internal static List<IILTransform> EarlyILTransforms(bool aggressivelyDuplicateReturnBlocks = false)
	{
		return new List<IILTransform>
		{
			new ControlFlowSimplification
			{
				aggressivelyDuplicateReturnBlocks = aggressivelyDuplicateReturnBlocks
			},
			new SplitVariables(),
			new ILInlining()
		};
	}

	public static List<IILTransform> GetILTransforms()
	{
		List<IILTransform> list = new List<IILTransform>();
		list.Add(new ControlFlowSimplification());
		list.Add(new SplitVariables());
		list.Add(new ILInlining());
		list.Add(new InlineReturnTransform());
		list.Add(new DetectPinnedRegions());
		list.Add(new YieldReturnDecompiler());
		list.Add(new AsyncAwaitDecompiler());
		list.Add(new DetectCatchWhenConditionBlocks());
		list.Add(new DetectExitPoints(canIntroduceExitForReturn: false));
		list.Add(new EarlyExpressionTransforms());
		list.Add(new RemoveDeadVariableInit());
		list.Add(new SplitVariables());
		list.Add(new ControlFlowSimplification());
		list.Add(new DynamicCallSiteTransform());
		list.Add(new SwitchDetection());
		list.Add(new SwitchOnStringTransform());
		list.Add(new SwitchOnNullableTransform());
		list.Add(new SplitVariables());
		list.Add(new BlockILTransform
		{
			PostOrderTransforms = { (IBlockTransform)new LoopDetection() }
		});
		list.Add(new DetectExitPoints(canIntroduceExitForReturn: true));
		list.Add(new BlockILTransform
		{
			PostOrderTransforms = 
			{
				(IBlockTransform)new ConditionDetection(),
				(IBlockTransform)new LockTransform(),
				(IBlockTransform)new UsingTransform(),
				(IBlockTransform)new CachedDelegateInitialization(),
				(IBlockTransform)new StatementTransform(new ILInlining(), new TransformAssignment()),
				(IBlockTransform)new CopyPropagation(),
				(IBlockTransform)new StatementTransform(new ILInlining(), new ExpressionTransforms(), new DynamicIsEventAssignmentTransform(), new TransformAssignment(), new NullCoalescingTransform(), new NullableLiftingStatementTransform(), new NullPropagationStatementTransform(), new TransformArrayInitializers(), new TransformCollectionAndObjectInitializers(), new TransformExpressionTrees(), new NamedArgumentTransform(), new UserDefinedLogicTransform())
			}
		});
		list.Add(new ProxyCallReplacer());
		list.Add(new DelegateConstruction());
		list.Add(new HighLevelLoopTransform());
		list.Add(new ReduceNestingTransform());
		list.Add(new IntroduceDynamicTypeOnLocals());
		list.Add(new AssignVariableNames());
		return list;
	}

	public static List<IAstTransform> GetAstTransforms()
	{
		return new List<IAstTransform>
		{
			new PatternStatementTransform(),
			new ReplaceMethodCallsWithOperators(),
			new IntroduceUnsafeModifier(),
			new AddCheckedBlocks(),
			new DeclareVariables(),
			new ConvertConstructorCallIntoInitializer(),
			new DecimalConstantTransform(),
			new PrettifyAssignments(),
			new IntroduceUsingDeclarations(),
			new IntroduceExtensionMethods(),
			new IntroduceQueryExpressions(),
			new CombineQueryExpressions(),
			new NormalizeBlockStatements(),
			new FlattenSwitchBlocks(),
			new FixNameCollisions(),
			new AddXmlDocumentationTransform()
		};
	}

	public CSharpDecompiler(string fileName, DecompilerSettings settings)
		: this(CreateTypeSystemFromFile(fileName, settings), settings)
	{
	}

	public CSharpDecompiler(string fileName, IAssemblyResolver assemblyResolver, DecompilerSettings settings)
		: this(LoadPEFile(fileName, settings), assemblyResolver, settings)
	{
	}

	public CSharpDecompiler(PEFile module, IAssemblyResolver assemblyResolver, DecompilerSettings settings)
		: this(new DecompilerTypeSystem(module, assemblyResolver, settings), settings)
	{
	}

	public CSharpDecompiler(DecompilerTypeSystem typeSystem, DecompilerSettings settings)
	{
		this.typeSystem = typeSystem ?? throw new ArgumentNullException("typeSystem");
		this.settings = settings;
		module = typeSystem.MainModule;
		metadata = module.PEFile.Metadata;
		if (module.TypeSystemOptions.HasFlag(TypeSystemOptions.Uncached))
		{
			throw new ArgumentException("Cannot use an uncached type system in the decompiler.");
		}
	}

	public static bool MemberIsHidden(PEFile module, EntityHandle member, DecompilerSettings settings)
	{
		if (module == null || member.IsNil)
		{
			return false;
		}
		MetadataReader metadata = module.Metadata;
		switch (member.Kind)
		{
		case HandleKind.MethodDefinition:
		{
			MethodDefinitionHandle methodDefinitionHandle = (MethodDefinitionHandle)member;
			MethodDefinition methodDefinition = metadata.GetMethodDefinition(methodDefinitionHandle);
			MethodSemanticsAttributes item = module.MethodSemanticsLookup.GetSemantics(methodDefinitionHandle).Item2;
			if (item != 0 && item != MethodSemanticsAttributes.Other)
			{
				return true;
			}
			if (LocalFunctionDecompiler.IsLocalFunctionMethod(module, methodDefinitionHandle))
			{
				return settings.LocalFunctions;
			}
			if (settings.AnonymousMethods && methodDefinitionHandle.HasGeneratedName(metadata) && methodDefinitionHandle.IsCompilerGenerated(metadata))
			{
				return true;
			}
			if (settings.AsyncAwait && AsyncAwaitDecompiler.IsCompilerGeneratedMainMethod(module, methodDefinitionHandle))
			{
				return true;
			}
			return false;
		}
		case HandleKind.TypeDefinition:
		{
			TypeDefinitionHandle typeDefinitionHandle = (TypeDefinitionHandle)member;
			TypeDefinition typeDefinition = metadata.GetTypeDefinition(typeDefinitionHandle);
			string text = metadata.GetString(typeDefinition.Name);
			if (!typeDefinition.GetDeclaringType().IsNil)
			{
				if (LocalFunctionDecompiler.IsLocalFunctionDisplayClass(module, typeDefinitionHandle))
				{
					return settings.LocalFunctions;
				}
				if (settings.AnonymousMethods && IsClosureType(typeDefinition, metadata))
				{
					return true;
				}
				if (settings.YieldReturn && YieldReturnDecompiler.IsCompilerGeneratorEnumerator(typeDefinitionHandle, metadata))
				{
					return true;
				}
				if (settings.AsyncAwait && AsyncAwaitDecompiler.IsCompilerGeneratedStateMachine(typeDefinitionHandle, metadata))
				{
					return true;
				}
				if (settings.FixedBuffers && text.StartsWith("<", StringComparison.Ordinal) && text.Contains("__FixedBuffer"))
				{
					return true;
				}
			}
			else if (typeDefinition.IsCompilerGenerated(metadata))
			{
				if (settings.ArrayInitializers && text.StartsWith("<PrivateImplementationDetails>", StringComparison.Ordinal))
				{
					return true;
				}
				if (settings.AnonymousTypes && typeDefinition.IsAnonymousType(metadata))
				{
					return true;
				}
				if (settings.Dynamic && typeDefinition.IsDelegate(metadata) && (text.StartsWith("<>A", StringComparison.Ordinal) || text.StartsWith("<>F", StringComparison.Ordinal)))
				{
					return true;
				}
			}
			if (settings.ArrayInitializers && settings.SwitchStatementOnString && text.StartsWith("<PrivateImplementationDetails>", StringComparison.Ordinal))
			{
				return true;
			}
			return false;
		}
		case HandleKind.FieldDefinition:
		{
			FieldDefinitionHandle handle = (FieldDefinitionHandle)member;
			FieldDefinition field = metadata.GetFieldDefinition(handle);
			string text = metadata.GetString(field.Name);
			if (field.IsCompilerGenerated(metadata))
			{
				if (settings.AnonymousMethods && IsAnonymousMethodCacheField(field, metadata))
				{
					return true;
				}
				if (settings.AutomaticProperties && IsAutomaticPropertyBackingField(field, metadata))
				{
					return true;
				}
				if (settings.SwitchStatementOnString && IsSwitchOnStringCache(field, metadata))
				{
					return true;
				}
			}
			if (settings.AutomaticEvents && Enumerable.Any<EventDefinitionHandle>((IEnumerable<EventDefinitionHandle>)metadata.GetTypeDefinition(field.GetDeclaringType()).GetEvents(), (Func<EventDefinitionHandle, bool>)((EventDefinitionHandle ev) => metadata.GetEventDefinition(ev).Name == field.Name)))
			{
				return true;
			}
			if (settings.ArrayInitializers && metadata.GetString(metadata.GetTypeDefinition(field.GetDeclaringType()).Name).StartsWith("<PrivateImplementationDetails>", StringComparison.Ordinal))
			{
				if (text.StartsWith("__StaticArrayInit", StringComparison.Ordinal))
				{
					return true;
				}
				if (text.StartsWith("$$method", StringComparison.Ordinal))
				{
					return true;
				}
				if (field.DecodeSignature(new FullTypeNameSignatureDecoder(metadata), default(Unit)).ToString().StartsWith("__StaticArrayInit", StringComparison.Ordinal))
				{
					return true;
				}
			}
			return false;
		}
		default:
			return false;
		}
	}

	private static bool IsSwitchOnStringCache(FieldDefinition field, MetadataReader metadata)
	{
		return metadata.GetString(field.Name).StartsWith("<>f__switch", StringComparison.Ordinal);
	}

	private static bool IsAutomaticPropertyBackingField(FieldDefinition field, MetadataReader metadata)
	{
		string text = metadata.GetString(field.Name);
		return text.StartsWith("<", StringComparison.Ordinal) && text.EndsWith("BackingField", StringComparison.Ordinal);
	}

	private static bool IsAnonymousMethodCacheField(FieldDefinition field, MetadataReader metadata)
	{
		string text = metadata.GetString(field.Name);
		return text.StartsWith("CS$<>", StringComparison.Ordinal) || text.StartsWith("<>f__am", StringComparison.Ordinal);
	}

	private static bool IsClosureType(TypeDefinition type, MetadataReader metadata)
	{
		string text = metadata.GetString(type.Name);
		if (!type.Name.IsGeneratedName(metadata) || !type.IsCompilerGenerated(metadata))
		{
			return false;
		}
		if (text.Contains("DisplayClass") || text.Contains("AnonStorey"))
		{
			return true;
		}
		return type.BaseType.GetFullTypeName(metadata).ToString() == "System.Object" && !Enumerable.Any<InterfaceImplementationHandle>((IEnumerable<InterfaceImplementationHandle>)type.GetInterfaceImplementations());
	}

	private static PEFile LoadPEFile(string fileName, DecompilerSettings settings)
	{
		settings.LoadInMemory = true;
		return new PEFile(fileName, new FileStream(fileName, FileMode.Open, FileAccess.Read), settings.LoadInMemory ? PEStreamOptions.PrefetchEntireImage : PEStreamOptions.Default, settings.ApplyWindowsRuntimeProjections ? MetadataReaderOptions.Default : MetadataReaderOptions.None);
	}

	private static DecompilerTypeSystem CreateTypeSystemFromFile(string fileName, DecompilerSettings settings)
	{
		settings.LoadInMemory = true;
		PEFile pEFile = LoadPEFile(fileName, settings);
		UniversalAssemblyResolver assemblyResolver = new UniversalAssemblyResolver(fileName, settings.ThrowOnAssemblyResolveErrors, pEFile.Reader.DetectTargetFrameworkId(), settings.LoadInMemory ? PEStreamOptions.PrefetchMetadata : PEStreamOptions.Default, settings.ApplyWindowsRuntimeProjections ? MetadataReaderOptions.Default : MetadataReaderOptions.None);
		return new DecompilerTypeSystem(pEFile, assemblyResolver);
	}

	private TypeSystemAstBuilder CreateAstBuilder(ITypeResolveContext decompilationContext)
	{
		TypeSystemAstBuilder typeSystemAstBuilder = new TypeSystemAstBuilder();
		typeSystemAstBuilder.ShowAttributes = true;
		typeSystemAstBuilder.AlwaysUseShortTypeNames = true;
		typeSystemAstBuilder.AddResolveResultAnnotations = true;
		return typeSystemAstBuilder;
	}

	private IDocumentationProvider CreateDefaultDocumentationProvider()
	{
		try
		{
			return XmlDocLoader.LoadDocumentation(module.PEFile);
		}
		catch (XmlException)
		{
			return null;
		}
	}

	private void RunTransforms(AstNode rootNode, DecompileRun decompileRun, ITypeResolveContext decompilationContext)
	{
		TypeSystemAstBuilder typeSystemAstBuilder = CreateAstBuilder(decompilationContext);
		TransformContext context = new TransformContext(typeSystem, decompileRun, decompilationContext, typeSystemAstBuilder);
		foreach (IAstTransform astTransform in astTransforms)
		{
			CancellationToken.ThrowIfCancellationRequested();
			astTransform.Run(rootNode, context);
		}
		rootNode.AcceptVisitor(new InsertParenthesesVisitor
		{
			InsertParenthesesForReadability = true
		});
	}

	private string SyntaxTreeToString(SyntaxTree syntaxTree)
	{
		StringWriter stringWriter = new StringWriter();
		syntaxTree.AcceptVisitor(new CSharpOutputVisitor(stringWriter, settings.CSharpFormattingOptions));
		return stringWriter.ToString();
	}

	public SyntaxTree DecompileModuleAndAssemblyAttributes()
	{
		SimpleTypeResolveContext decompilationContext = new SimpleTypeResolveContext(typeSystem.MainModule);
		DecompileRun decompileRun = new DecompileRun(settings)
		{
			DocumentationProvider = (DocumentationProvider ?? CreateDefaultDocumentationProvider()),
			CancellationToken = CancellationToken
		};
		syntaxTree = new SyntaxTree();
		RequiredNamespaceCollector.CollectAttributeNamespaces(module, decompileRun.Namespaces);
		DoDecompileModuleAndAssemblyAttributes(decompileRun, decompilationContext, syntaxTree);
		RunTransforms(syntaxTree, decompileRun, decompilationContext);
		return syntaxTree;
	}

	public string DecompileModuleAndAssemblyAttributesToString()
	{
		return SyntaxTreeToString(DecompileModuleAndAssemblyAttributes());
	}

	private void DoDecompileModuleAndAssemblyAttributes(DecompileRun decompileRun, ITypeResolveContext decompilationContext, SyntaxTree syntaxTree)
	{
		try
		{
			foreach (IAttribute assemblyAttribute in typeSystem.MainModule.GetAssemblyAttributes())
			{
				TypeSystemAstBuilder typeSystemAstBuilder = CreateAstBuilder(decompilationContext);
				AttributeSection attributeSection = new AttributeSection(typeSystemAstBuilder.ConvertAttribute(assemblyAttribute));
				attributeSection.AttributeTarget = "assembly";
				syntaxTree.AddChild(attributeSection, SyntaxTree.MemberRole);
			}
			foreach (IAttribute moduleAttribute in typeSystem.MainModule.GetModuleAttributes())
			{
				TypeSystemAstBuilder typeSystemAstBuilder2 = CreateAstBuilder(decompilationContext);
				AttributeSection attributeSection2 = new AttributeSection(typeSystemAstBuilder2.ConvertAttribute(moduleAttribute));
				attributeSection2.AttributeTarget = "module";
				syntaxTree.AddChild(attributeSection2, SyntaxTree.MemberRole);
			}
		}
		catch (Exception ex) when (!(ex is OperationCanceledException) && !(ex is DecompilerException))
		{
			throw new DecompilerException(module, null, ex, "Error decompiling module and assembly attributes of " + module.AssemblyName);
		}
	}

	private void DoDecompileTypes(IEnumerable<TypeDefinitionHandle> types, DecompileRun decompileRun, ITypeResolveContext decompilationContext, SyntaxTree syntaxTree)
	{
		string text = null;
		AstNode astNode = null;
		foreach (TypeDefinitionHandle type in types)
		{
			ITypeDefinition definition = module.GetDefinition(type);
			if ((!(definition.Name == "<Module>") || definition.Members.Count != 0) && !MemberIsHidden(module.PEFile, type, settings))
			{
				if (string.IsNullOrEmpty(definition.Namespace))
				{
					astNode = syntaxTree;
				}
				else if (text != definition.Namespace)
				{
					astNode = new NamespaceDeclaration(definition.Namespace);
					syntaxTree.AddChild(astNode, SyntaxTree.MemberRole);
				}
				text = definition.Namespace;
				EntityDeclaration child = DoDecompile(definition, decompileRun, decompilationContext.WithCurrentTypeDefinition(definition));
				astNode.AddChild(child, SyntaxTree.MemberRole);
			}
		}
	}

	public SyntaxTree DecompileWholeModuleAsSingleFile()
	{
		return DecompileWholeModuleAsSingleFile(sortTypes: false);
	}

	public SyntaxTree DecompileWholeModuleAsSingleFile(bool sortTypes)
	{
		SimpleTypeResolveContext decompilationContext = new SimpleTypeResolveContext(typeSystem.MainModule);
		DecompileRun decompileRun = new DecompileRun(settings)
		{
			DocumentationProvider = (DocumentationProvider ?? CreateDefaultDocumentationProvider()),
			CancellationToken = CancellationToken
		};
		syntaxTree = new SyntaxTree();
		RequiredNamespaceCollector.CollectNamespaces(module, decompileRun.Namespaces);
		DoDecompileModuleAndAssemblyAttributes(decompileRun, decompilationContext, syntaxTree);
		IEnumerable<TypeDefinitionHandle> enumerable = metadata.GetTopLevelTypeDefinitions();
		if (sortTypes)
		{
			enumerable = (IEnumerable<TypeDefinitionHandle>)Enumerable.OrderBy<TypeDefinitionHandle, (string, string)>(enumerable, (Func<TypeDefinitionHandle, (string, string)>)delegate(TypeDefinitionHandle td)
			{
				TypeDefinition typeDefinition = module.metadata.GetTypeDefinition(td);
				return (module.metadata.GetString(typeDefinition.Namespace), module.metadata.GetString(typeDefinition.Name));
			});
		}
		DoDecompileTypes(enumerable, decompileRun, decompilationContext, syntaxTree);
		RunTransforms(syntaxTree, decompileRun, decompilationContext);
		return syntaxTree;
	}

	public ILTransformContext CreateILTransformContext(ILFunction function)
	{
		DecompileRun decompileRun = new DecompileRun(settings)
		{
			DocumentationProvider = (DocumentationProvider ?? CreateDefaultDocumentationProvider()),
			CancellationToken = CancellationToken
		};
		RequiredNamespaceCollector.CollectNamespaces(function.Method, module, decompileRun.Namespaces);
		return new ILTransformContext(function, typeSystem, DebugInfoProvider, settings)
		{
			CancellationToken = CancellationToken,
			DecompileRun = decompileRun
		};
	}

	public static CodeMappingInfo GetCodeMappingInfo(PEFile module, EntityHandle member)
	{
		TypeDefinitionHandle typeDefinitionHandle = member.GetDeclaringType(module.Metadata);
		if (typeDefinitionHandle.IsNil && member.Kind == HandleKind.TypeDefinition)
		{
			typeDefinitionHandle = (TypeDefinitionHandle)member;
		}
		CodeMappingInfo codeMappingInfo = new CodeMappingInfo(module, typeDefinitionHandle);
		foreach (MethodDefinitionHandle method in module.Metadata.GetTypeDefinition(typeDefinitionHandle).GetMethods())
		{
			MethodDefinitionHandle parent = method;
			MethodDefinitionHandle item = method;
			Queue<MethodDefinitionHandle> queue = new Queue<MethodDefinitionHandle>();
			HashSet<MethodDefinitionHandle> val = new HashSet<MethodDefinitionHandle>();
			HashSet<TypeDefinitionHandle> processedNestedTypes = new HashSet<TypeDefinitionHandle>();
			queue.Enqueue(item);
			while (queue.Count > 0)
			{
				item = queue.Dequeue();
				if (val.Add(item))
				{
					try
					{
						ReadCodeMappingInfo(module, codeMappingInfo, parent, item, queue, processedNestedTypes);
					}
					catch (BadImageFormatException)
					{
					}
				}
			}
		}
		return codeMappingInfo;
	}

	private static void ReadCodeMappingInfo(PEFile module, CodeMappingInfo info, MethodDefinitionHandle parent, MethodDefinitionHandle part, Queue<MethodDefinitionHandle> connectedMethods, HashSet<TypeDefinitionHandle> processedNestedTypes)
	{
		MethodDefinition methodDefinition = module.Metadata.GetMethodDefinition(part);
		if (!methodDefinition.HasBody())
		{
			info.AddMapping(parent, part);
			return;
		}
		TypeDefinitionHandle declaringType = methodDefinition.GetDeclaringType();
		BlobReader blob = module.Reader.GetMethodBody(methodDefinition.RelativeVirtualAddress).GetILReader();
		while (blob.RemainingBytes > 0)
		{
			ILOpCode iLOpCode = blob.DecodeOpCode();
			switch (iLOpCode)
			{
			case ILOpCode.Stfld:
			{
				EntityHandle entityHandle = MetadataTokenHelpers.EntityHandleOrNil(blob.ReadInt32());
				if (entityHandle.IsNil)
				{
					break;
				}
				HandleKind kind = entityHandle.Kind;
				TypeDefinitionHandle typeDefinitionHandle;
				if (kind != HandleKind.FieldDefinition)
				{
					if (kind != HandleKind.MemberReference)
					{
						break;
					}
					MemberReference memberReference = module.Metadata.GetMemberReference((MemberReferenceHandle)entityHandle);
					if (memberReference.GetKind() != MemberReferenceKind.Field)
					{
						break;
					}
					HandleKind kind2 = memberReference.Parent.Kind;
					if (kind2 == HandleKind.TypeReference)
					{
						break;
					}
					if (kind2 != HandleKind.TypeDefinition)
					{
						if (kind2 != HandleKind.TypeSpecification)
						{
							break;
						}
						TypeSpecification typeSpecification = module.Metadata.GetTypeSpecification((TypeSpecificationHandle)memberReference.Parent);
						if (typeSpecification.Signature.IsNil)
						{
							break;
						}
						BlobReader blobReader = module.Metadata.GetBlobReader(typeSpecification.Signature);
						if (blobReader.ReadByte() != 21)
						{
							break;
						}
						int num = blobReader.ReadCompressedInteger();
						if (num < 17 || num > 18)
						{
							break;
						}
						EntityHandle entityHandle2 = blobReader.ReadTypeHandle();
						if (entityHandle2.Kind != HandleKind.TypeDefinition)
						{
							break;
						}
						typeDefinitionHandle = (TypeDefinitionHandle)entityHandle2;
					}
					else
					{
						typeDefinitionHandle = (TypeDefinitionHandle)memberReference.Parent;
					}
				}
				else
				{
					typeDefinitionHandle = module.Metadata.GetFieldDefinition((FieldDefinitionHandle)entityHandle).GetDeclaringType();
				}
				if (typeDefinitionHandle.IsNil)
				{
					break;
				}
				TypeDefinition typeDefinition = module.Metadata.GetTypeDefinition(typeDefinitionHandle);
				if (typeDefinition.GetDeclaringType() != declaringType || !processedNestedTypes.Add(typeDefinitionHandle) || (!YieldReturnDecompiler.IsCompilerGeneratorEnumerator(typeDefinitionHandle, module.Metadata) && !AsyncAwaitDecompiler.IsCompilerGeneratedStateMachine(typeDefinitionHandle, module.Metadata)))
				{
					break;
				}
				foreach (MethodDefinitionHandle method in typeDefinition.GetMethods())
				{
					if (module.MethodSemanticsLookup.GetSemantics(method).Item2 == (MethodSemanticsAttributes)0 && !module.Metadata.GetMethodDefinition(method).GetCustomAttributes().HasKnownAttribute(module.Metadata, KnownAttribute.DebuggerHidden))
					{
						connectedMethods.Enqueue(method);
					}
				}
				break;
			}
			case ILOpCode.Ldftn:
			{
				EntityHandle entityHandle = MetadataTokenHelpers.EntityHandleOrNil(blob.ReadInt32());
				if (!entityHandle.IsNil && entityHandle.Kind == HandleKind.MethodDefinition && ((MethodDefinitionHandle)entityHandle).IsCompilerGeneratedOrIsInCompilerGeneratedClass(module.Metadata))
				{
					connectedMethods.Enqueue((MethodDefinitionHandle)entityHandle);
				}
				break;
			}
			default:
				blob.SkipOperand(iLOpCode);
				break;
			}
		}
		info.AddMapping(parent, part);
	}

	public string DecompileWholeModuleAsString()
	{
		return SyntaxTreeToString(DecompileWholeModuleAsSingleFile());
	}

	public SyntaxTree DecompileTypes(IEnumerable<TypeDefinitionHandle> types)
	{
		if (types == null)
		{
			throw new ArgumentNullException("types");
		}
		SimpleTypeResolveContext decompilationContext = new SimpleTypeResolveContext(typeSystem.MainModule);
		DecompileRun decompileRun = new DecompileRun(settings)
		{
			DocumentationProvider = (DocumentationProvider ?? CreateDefaultDocumentationProvider()),
			CancellationToken = CancellationToken
		};
		syntaxTree = new SyntaxTree();
		foreach (TypeDefinitionHandle type in types)
		{
			if (type.IsNil)
			{
				throw new ArgumentException("types contains null element");
			}
			RequiredNamespaceCollector.CollectNamespaces(type, module, decompileRun.Namespaces);
		}
		DoDecompileTypes(types, decompileRun, decompilationContext, syntaxTree);
		RunTransforms(syntaxTree, decompileRun, decompilationContext);
		return syntaxTree;
	}

	public string DecompileTypesAsString(IEnumerable<TypeDefinitionHandle> types)
	{
		return SyntaxTreeToString(DecompileTypes(types));
	}

	public SyntaxTree DecompileType(FullTypeName fullTypeName)
	{
		ITypeDefinition definition = typeSystem.FindType(fullTypeName.TopLevelTypeName).GetDefinition();
		if (definition == null)
		{
			throw new InvalidOperationException($"Could not find type definition {fullTypeName} in type system.");
		}
		if (definition.ParentModule != typeSystem.MainModule)
		{
			throw new NotSupportedException("Decompiling types that are not part of the main module is not supported.");
		}
		SimpleTypeResolveContext decompilationContext = new SimpleTypeResolveContext(typeSystem.MainModule);
		DecompileRun decompileRun = new DecompileRun(settings)
		{
			DocumentationProvider = (DocumentationProvider ?? CreateDefaultDocumentationProvider()),
			CancellationToken = CancellationToken
		};
		syntaxTree = new SyntaxTree();
		RequiredNamespaceCollector.CollectNamespaces(definition.MetadataToken, module, decompileRun.Namespaces);
		DoDecompileTypes(new TypeDefinitionHandle[1] { (TypeDefinitionHandle)definition.MetadataToken }, decompileRun, decompilationContext, syntaxTree);
		RunTransforms(syntaxTree, decompileRun, decompilationContext);
		return syntaxTree;
	}

	public string DecompileTypeAsString(FullTypeName fullTypeName)
	{
		return SyntaxTreeToString(DecompileType(fullTypeName));
	}

	public SyntaxTree Decompile(params EntityHandle[] definitions)
	{
		return Decompile((IEnumerable<EntityHandle>)definitions);
	}

	public SyntaxTree Decompile(IEnumerable<EntityHandle> definitions)
	{
		if (definitions == null)
		{
			throw new ArgumentNullException("definitions");
		}
		syntaxTree = new SyntaxTree();
		DecompileRun decompileRun = new DecompileRun(settings)
		{
			DocumentationProvider = (DocumentationProvider ?? CreateDefaultDocumentationProvider()),
			CancellationToken = CancellationToken
		};
		foreach (EntityHandle definition6 in definitions)
		{
			if (definition6.IsNil)
			{
				throw new ArgumentException("definitions contains null element");
			}
			RequiredNamespaceCollector.CollectNamespaces(definition6, module, decompileRun.Namespaces);
		}
		bool flag = true;
		ITypeDefinition typeDefinition = null;
		foreach (EntityHandle definition7 in definitions)
		{
			switch (definition7.Kind)
			{
			case HandleKind.TypeDefinition:
			{
				ITypeDefinition definition4 = module.GetDefinition((TypeDefinitionHandle)definition7);
				syntaxTree.Members.Add(DoDecompile(definition4, decompileRun, new SimpleTypeResolveContext(definition4)));
				if (flag)
				{
					typeDefinition = definition4.DeclaringTypeDefinition;
				}
				else if (typeDefinition != null)
				{
					typeDefinition = FindCommonDeclaringTypeDefinition(typeDefinition, definition4.DeclaringTypeDefinition);
				}
				break;
			}
			case HandleKind.MethodDefinition:
			{
				IMethod definition3 = module.GetDefinition((MethodDefinitionHandle)definition7);
				syntaxTree.Members.Add(DoDecompile(definition3, decompileRun, new SimpleTypeResolveContext(definition3)));
				if (flag)
				{
					typeDefinition = definition3.DeclaringTypeDefinition;
				}
				else if (typeDefinition != null)
				{
					typeDefinition = FindCommonDeclaringTypeDefinition(typeDefinition, definition3.DeclaringTypeDefinition);
				}
				break;
			}
			case HandleKind.FieldDefinition:
			{
				IField definition2 = module.GetDefinition((FieldDefinitionHandle)definition7);
				syntaxTree.Members.Add(DoDecompile(definition2, decompileRun, new SimpleTypeResolveContext(definition2)));
				typeDefinition = definition2.DeclaringTypeDefinition;
				break;
			}
			case HandleKind.PropertyDefinition:
			{
				IProperty definition5 = module.GetDefinition((PropertyDefinitionHandle)definition7);
				syntaxTree.Members.Add(DoDecompile(definition5, decompileRun, new SimpleTypeResolveContext(definition5)));
				if (flag)
				{
					typeDefinition = definition5.DeclaringTypeDefinition;
				}
				else if (typeDefinition != null)
				{
					typeDefinition = FindCommonDeclaringTypeDefinition(typeDefinition, definition5.DeclaringTypeDefinition);
				}
				break;
			}
			case HandleKind.EventDefinition:
			{
				IEvent definition = module.GetDefinition((EventDefinitionHandle)definition7);
				syntaxTree.Members.Add(DoDecompile(definition, decompileRun, new SimpleTypeResolveContext(definition)));
				if (flag)
				{
					typeDefinition = definition.DeclaringTypeDefinition;
				}
				else if (typeDefinition != null)
				{
					typeDefinition = FindCommonDeclaringTypeDefinition(typeDefinition, definition.DeclaringTypeDefinition);
				}
				break;
			}
			default:
				throw new NotSupportedException(definition7.Kind.ToString());
			}
			flag = false;
		}
		RunTransforms(syntaxTree, decompileRun, (typeDefinition != null) ? new SimpleTypeResolveContext(typeDefinition) : new SimpleTypeResolveContext(typeSystem.MainModule));
		return syntaxTree;
	}

	private ITypeDefinition FindCommonDeclaringTypeDefinition(ITypeDefinition a, ITypeDefinition b)
	{
		if (a == null || b == null)
		{
			return null;
		}
		IEnumerable<ITypeDefinition> declaringTypeDefinitions = a.GetDeclaringTypeDefinitions();
		HashSet<ITypeDefinition> val = new HashSet<ITypeDefinition>(b.GetDeclaringTypeDefinitions());
		return Enumerable.FirstOrDefault<ITypeDefinition>(declaringTypeDefinitions, (Func<ITypeDefinition, bool>)val.Contains);
	}

	public string DecompileAsString(params EntityHandle[] definitions)
	{
		return SyntaxTreeToString(Decompile(definitions));
	}

	public string DecompileAsString(IEnumerable<EntityHandle> definitions)
	{
		return SyntaxTreeToString(Decompile(definitions));
	}

	private IEnumerable<EntityDeclaration> AddInterfaceImplHelpers(EntityDeclaration memberDecl, IMethod method, TypeSystemAstBuilder astBuilder)
	{
		if (!memberDecl.GetChildByRole(EntityDeclaration.PrivateImplementationTypeRole).IsNull)
		{
			yield break;
		}
		DecompTools.Decompiler.TypeSystem.GenericContext genericContext = new DecompTools.Decompiler.TypeSystem.GenericContext(method);
		MethodDefinitionHandle methodHandle = (MethodDefinitionHandle)method.MetadataToken;
		foreach (MethodImplementationHandle h in methodHandle.GetMethodImplementations(metadata))
		{
			MethodImplementation mi = metadata.GetMethodImplementation(h);
			IMethod m = module.ResolveMethod(mi.MethodDeclaration, genericContext);
			if (m != null && m.DeclaringType.Kind == TypeKind.Interface)
			{
				MethodDeclaration methodDecl = new MethodDeclaration();
				methodDecl.ReturnType = memberDecl.ReturnType.Clone();
				methodDecl.PrivateImplementationType = astBuilder.ConvertType(m.DeclaringType);
				methodDecl.Name = m.Name;
				methodDecl.TypeParameters.AddRange(Enumerable.Select<TypeParameterDeclaration, TypeParameterDeclaration>((IEnumerable<TypeParameterDeclaration>)memberDecl.GetChildrenByRole(Roles.TypeParameter), (Func<TypeParameterDeclaration, TypeParameterDeclaration>)((TypeParameterDeclaration n) => (TypeParameterDeclaration)n.Clone())));
				methodDecl.Parameters.AddRange(Enumerable.Select<ParameterDeclaration, ParameterDeclaration>((IEnumerable<ParameterDeclaration>)memberDecl.GetChildrenByRole(Roles.Parameter), (Func<ParameterDeclaration, ParameterDeclaration>)((ParameterDeclaration n) => n.Clone())));
				methodDecl.Constraints.AddRange(Enumerable.Select<Constraint, Constraint>((IEnumerable<Constraint>)memberDecl.GetChildrenByRole(Roles.Constraint), (Func<Constraint, Constraint>)((Constraint n) => (Constraint)n.Clone())));
				methodDecl.Body = new BlockStatement();
				methodDecl.Body.AddChild(new Comment("ILSpy generated this explicit interface implementation from .override directive in " + memberDecl.Name), Roles.Comment);
				InvocationExpression forwardingCall = new InvocationExpression(new MemberReferenceExpression(new ThisReferenceExpression(), memberDecl.Name, Enumerable.Select<TypeParameterDeclaration, SimpleType>((IEnumerable<TypeParameterDeclaration>)methodDecl.TypeParameters, (Func<TypeParameterDeclaration, SimpleType>)((TypeParameterDeclaration tp) => new SimpleType(tp.Name)))), Enumerable.Select<ParameterDeclaration, Expression>((IEnumerable<ParameterDeclaration>)methodDecl.Parameters, (Func<ParameterDeclaration, Expression>)((ParameterDeclaration p) => ForwardParameter(p))));
				if (m.ReturnType.IsKnownType(KnownTypeCode.Void))
				{
					methodDecl.Body.Add(new ExpressionStatement(forwardingCall));
				}
				else
				{
					methodDecl.Body.Add(new ReturnStatement(forwardingCall));
				}
				yield return methodDecl;
			}
		}
	}

	private Expression ForwardParameter(ParameterDeclaration p)
	{
		return p.ParameterModifier switch
		{
			DecompTools.Decompiler.CSharp.Syntax.ParameterModifier.Ref => new DirectionExpression(FieldDirection.Ref, new IdentifierExpression(p.Name)), 
			DecompTools.Decompiler.CSharp.Syntax.ParameterModifier.Out => new DirectionExpression(FieldDirection.Out, new IdentifierExpression(p.Name)), 
			_ => new IdentifierExpression(p.Name), 
		};
	}

	private void SetNewModifier(EntityDeclaration member)
	{
		IEntity entity = (IEntity)member.GetSymbol();
		MemberLookup lookup = new MemberLookup(entity.DeclaringTypeDefinition, entity.ParentModule);
		List<IType> baseTypes = Enumerable.ToList<IType>(Enumerable.Where<IType>(entity.DeclaringType.GetNonInterfaceBaseTypes(), (Func<IType, bool>)((IType t) => entity.DeclaringType != t)));
		bool hideBasedOnSignature = !(entity is ITypeDefinition) && entity.SymbolKind != SymbolKind.Field && entity.SymbolKind != SymbolKind.Property && entity.SymbolKind != SymbolKind.Event;
		if (HidesMemberOrTypeOfBaseType())
		{
			member.Modifiers |= Modifiers.New;
		}
		bool HidesMemberOrTypeOfBaseType()
		{
			ParameterListComparer parameterListComparer = ParameterListComparer.WithOptions(includeModifiers: true);
			foreach (IType item in baseTypes)
			{
				if (!hideBasedOnSignature)
				{
					if (Enumerable.Any<IType>(item.GetNestedTypes((ITypeDefinition t) => t.Name == entity.Name && lookup.IsAccessible(t, allowProtectedAccess: true), GetMemberOptions.ReturnMemberDefinitions | GetMemberOptions.IgnoreInheritedMembers)))
					{
						return true;
					}
					if (Enumerable.Any<IMember>(item.GetMembers((IMember m) => m.Name == entity.Name && m.SymbolKind != SymbolKind.Indexer && lookup.IsAccessible(m, allowProtectedAccess: true), GetMemberOptions.ReturnMemberDefinitions | GetMemberOptions.IgnoreInheritedMembers)))
					{
						return true;
					}
				}
				else if (entity.SymbolKind == SymbolKind.Indexer)
				{
					if (Enumerable.Any<IProperty>(item.GetProperties((IProperty p) => p.SymbolKind == SymbolKind.Indexer && lookup.IsAccessible(p, allowProtectedAccess: true)), (Func<IProperty, bool>)((IProperty p) => parameterListComparer.Equals(((IProperty)entity).Parameters, p.Parameters))))
					{
						return true;
					}
				}
				else if (entity.SymbolKind == SymbolKind.Method && Enumerable.Any<IMember>(item.GetMembers((IMember m) => m.SymbolKind != SymbolKind.Indexer && m.Name == entity.Name && lookup.IsAccessible(m, allowProtectedAccess: true)), (Func<IMember, bool>)((IMember m) => m.SymbolKind != SymbolKind.Method || (((IMethod)entity).TypeParameters.Count == ((IMethod)m).TypeParameters.Count && parameterListComparer.Equals(((IMethod)entity).Parameters, ((IMethod)m).Parameters)))))
				{
					return true;
				}
			}
			return false;
		}
	}

	private void FixParameterNames(EntityDeclaration entity)
	{
		int num = 0;
		foreach (ParameterDeclaration item in entity.GetChildrenByRole(Roles.Parameter))
		{
			if (string.IsNullOrEmpty(item.Name) && !item.Type.IsArgList())
			{
				item.Name = "P_" + num;
			}
			num = checked(num + 1);
		}
	}

	private EntityDeclaration DoDecompile(ITypeDefinition typeDef, DecompileRun decompileRun, ITypeResolveContext decompilationContext)
	{
		Debug.Assert(decompilationContext.CurrentTypeDefinition == typeDef);
		try
		{
			TypeSystemAstBuilder typeSystemAstBuilder = CreateAstBuilder(decompilationContext);
			EntityDeclaration entityDeclaration = typeSystemAstBuilder.ConvertEntity(typeDef);
			if (!(entityDeclaration is TypeDeclaration typeDeclaration))
			{
				return entityDeclaration;
			}
			foreach (ITypeDefinition nestedType in typeDef.NestedTypes)
			{
				if (!nestedType.MetadataToken.IsNil && !MemberIsHidden(module.PEFile, nestedType.MetadataToken, settings))
				{
					EntityDeclaration entityDeclaration2 = DoDecompile(nestedType, decompileRun, decompilationContext.WithCurrentTypeDefinition(nestedType));
					SetNewModifier(entityDeclaration2);
					typeDeclaration.Members.Add(entityDeclaration2);
				}
			}
			foreach (IField field2 in typeDef.Fields)
			{
				if (!field2.MetadataToken.IsNil && !MemberIsHidden(module.PEFile, field2.MetadataToken, settings) && (typeDef.Kind != TypeKind.Enum || field2.IsConst))
				{
					EntityDeclaration element = DoDecompile(field2, decompileRun, decompilationContext.WithCurrentMember(field2));
					typeDeclaration.Members.Add(element);
				}
			}
			foreach (IProperty property in typeDef.Properties)
			{
				if (!property.MetadataToken.IsNil && !MemberIsHidden(module.PEFile, property.MetadataToken, settings))
				{
					EntityDeclaration element2 = DoDecompile(property, decompileRun, decompilationContext.WithCurrentMember(property));
					typeDeclaration.Members.Add(element2);
				}
			}
			foreach (IEvent @event in typeDef.Events)
			{
				if (!@event.MetadataToken.IsNil && !MemberIsHidden(module.PEFile, @event.MetadataToken, settings))
				{
					EntityDeclaration element3 = DoDecompile(@event, decompileRun, decompilationContext.WithCurrentMember(@event));
					typeDeclaration.Members.Add(element3);
				}
			}
			foreach (IMethod method in typeDef.Methods)
			{
				if (!method.MetadataToken.IsNil && !MemberIsHidden(module.PEFile, method.MetadataToken, settings))
				{
					EntityDeclaration entityDeclaration3 = DoDecompile(method, decompileRun, decompilationContext.WithCurrentMember(method));
					typeDeclaration.Members.Add(entityDeclaration3);
					typeDeclaration.Members.AddRange(AddInterfaceImplHelpers(entityDeclaration3, method, typeSystemAstBuilder));
				}
			}
			if (Enumerable.Any<IndexerDeclaration>(Enumerable.OfType<IndexerDeclaration>((IEnumerable)typeDeclaration.Members), (Func<IndexerDeclaration, bool>)((IndexerDeclaration idx) => idx.PrivateImplementationType.IsNull)))
			{
				RemoveAttribute(typeDeclaration, KnownAttribute.DefaultMember);
			}
			if (settings.IntroduceRefModifiersOnStructs && FindAttribute(typeDeclaration, KnownAttribute.Obsolete, out var attribute) && obsoleteAttributePattern.IsMatch(attribute))
			{
				if (attribute.Parent is AttributeSection attributeSection && attributeSection.Attributes.Count == 1)
				{
					attributeSection.Remove();
				}
				else
				{
					attribute.Remove();
				}
			}
			if (typeDeclaration.ClassType == ClassType.Enum)
			{
				switch (DetectBestEnumValueDisplayMode(typeDef, module.PEFile))
				{
				case EnumValueDisplayMode.FirstOnly:
					foreach (EnumMemberDeclaration item in Enumerable.Skip<EnumMemberDeclaration>(Enumerable.OfType<EnumMemberDeclaration>((IEnumerable)typeDeclaration.Members), 1))
					{
						item.Initializer = null;
					}
					break;
				case EnumValueDisplayMode.None:
					foreach (EnumMemberDeclaration item2 in Enumerable.OfType<EnumMemberDeclaration>((IEnumerable)typeDeclaration.Members))
					{
						item2.Initializer = null;
						if (item2.GetSymbol() is IField field && field.GetConstantValue() == null)
						{
							typeDeclaration.InsertChildBefore(item2, new Comment(" error: enumerator has no value"), Roles.Comment);
						}
					}
					break;
				default:
					throw new ArgumentOutOfRangeException();
				case EnumValueDisplayMode.All:
					break;
				}
			}
			return typeDeclaration;
		}
		catch (Exception ex) when (!(ex is OperationCanceledException) && !(ex is DecompilerException))
		{
			throw new DecompilerException(module, typeDef, ex);
		}
	}

	private EnumValueDisplayMode DetectBestEnumValueDisplayMode(ITypeDefinition typeDef, PEFile module)
	{
		if (typeDef.HasAttribute(KnownAttribute.Flags))
		{
			return EnumValueDisplayMode.All;
		}
		bool flag = true;
		long num = 0L;
		long num2 = 0L;
		foreach (IField field in typeDef.Fields)
		{
			if (MemberIsHidden(module, field.MetadataToken, settings))
			{
				continue;
			}
			object constantValue = field.GetConstantValue();
			if (constantValue != null)
			{
				long num3 = (long)CSharpPrimitiveCast.Cast(TypeCode.Int64, constantValue, checkForOverflow: false);
				if (flag)
				{
					num = num3;
					flag = false;
				}
				else if (checked(num2 + 1) != num3)
				{
					return EnumValueDisplayMode.All;
				}
				num2 = num3;
			}
		}
		return (num != 0L) ? EnumValueDisplayMode.FirstOnly : EnumValueDisplayMode.None;
	}

	private MethodDeclaration GenerateConvHelper(string name, KnownTypeCode source, KnownTypeCode target, TypeSystemAstBuilder typeSystemAstBuilder, Expression intermediate32, Expression intermediate64)
	{
		MethodDeclaration methodDeclaration = new MethodDeclaration();
		methodDeclaration.Name = name;
		methodDeclaration.Modifiers = Modifiers.Private | Modifiers.Static;
		methodDeclaration.Parameters.Add(new ParameterDeclaration(typeSystemAstBuilder.ConvertType(typeSystem.FindType(source)), "input"));
		methodDeclaration.ReturnType = typeSystemAstBuilder.ConvertType(typeSystem.FindType(target));
		methodDeclaration.Body = new BlockStatement
		{
			new IfElseStatement
			{
				Condition = new BinaryOperatorExpression
				{
					Left = new MemberReferenceExpression(new TypeReferenceExpression(typeSystemAstBuilder.ConvertType(typeSystem.FindType(KnownTypeCode.IntPtr))), "Size"),
					Operator = BinaryOperatorType.Equality,
					Right = new PrimitiveExpression(4)
				},
				TrueStatement = new BlockStatement
				{
					new ReturnStatement(new CastExpression(methodDeclaration.ReturnType.Clone(), intermediate32))
				},
				FalseStatement = new BlockStatement
				{
					new ReturnStatement(new CastExpression(methodDeclaration.ReturnType.Clone(), intermediate64))
				}
			}
		};
		return methodDeclaration;
	}

	private EntityDeclaration DoDecompile(IMethod method, DecompileRun decompileRun, ITypeResolveContext decompilationContext)
	{
		Debug.Assert(decompilationContext.CurrentMember == method);
		TypeSystemAstBuilder typeSystemAstBuilder = CreateAstBuilder(decompilationContext);
		EntityDeclaration entityDeclaration = typeSystemAstBuilder.ConvertEntity(method);
		int num = method.Name.LastIndexOf('.');
		if (method.IsExplicitInterfaceImplementation && num >= 0)
		{
			entityDeclaration.Name = method.Name.Substring(checked(num + 1));
		}
		FixParameterNames(entityDeclaration);
		MethodDefinition methodDefinition = metadata.GetMethodDefinition((MethodDefinitionHandle)method.MetadataToken);
		if (!settings.LocalFunctions && LocalFunctionDecompiler.IsLocalFunctionMethod(method.ParentModule.PEFile, (MethodDefinitionHandle)method.MetadataToken))
		{
			entityDeclaration.Modifiers &= ~(Modifiers.Internal | Modifiers.Static);
			entityDeclaration.Modifiers |= (Modifiers)(1 | (method.IsStatic ? 128 : 0));
		}
		if (methodDefinition.HasBody())
		{
			DecompileBody(method, entityDeclaration, decompileRun, decompilationContext);
		}
		else if (!method.IsAbstract && method.DeclaringType.Kind != TypeKind.Interface)
		{
			entityDeclaration.Modifiers |= Modifiers.Extern;
		}
		if (method.SymbolKind == SymbolKind.Method && !method.IsExplicitInterfaceImplementation && methodDefinition.HasFlag(MethodAttributes.Virtual) == methodDefinition.HasFlag(MethodAttributes.VtableLayoutMask))
		{
			SetNewModifier(entityDeclaration);
		}
		return entityDeclaration;
	}

	internal static bool IsWindowsFormsInitializeComponentMethod(IMethod method)
	{
		return method.ReturnType.Kind == TypeKind.Void && method.Name == "InitializeComponent" && Enumerable.Any<IType>(method.DeclaringTypeDefinition.GetNonInterfaceBaseTypes(), (Func<IType, bool>)((IType t) => t.FullName == "System.Windows.Forms.Control"));
	}

	private void DecompileBody(IMethod method, EntityDeclaration entityDecl, DecompileRun decompileRun, ITypeResolveContext decompilationContext)
	{
		try
		{
			ILReader iLReader = new ILReader(typeSystem.MainModule)
			{
				UseDebugSymbols = settings.UseDebugSymbols,
				DebugInfo = DebugInfoProvider
			};
			MethodDefinition methodDefinition = metadata.GetMethodDefinition((MethodDefinitionHandle)method.MetadataToken);
			BlockStatement blockStatement = BlockStatement.Null;
			MethodBodyBlock methodBody;
			try
			{
				methodBody = module.PEFile.Reader.GetMethodBody(methodDefinition.RelativeVirtualAddress);
			}
			catch (BadImageFormatException ex)
			{
				blockStatement = new BlockStatement();
				blockStatement.AddChild(new Comment("Invalid MethodBodyBlock: " + ex.Message), Roles.Comment);
				entityDecl.AddChild(blockStatement, Roles.Body);
				return;
			}
			ILFunction iLFunction = iLReader.ReadIL((MethodDefinitionHandle)method.MetadataToken, methodBody, default(DecompTools.Decompiler.TypeSystem.GenericContext), CancellationToken);
			iLFunction.CheckInvariant(ILPhase.Normal);
			if (entityDecl != null)
			{
				int num = 0;
				Dictionary<int?, ILVariable> dictionary = Enumerable.ToDictionary<ILVariable, int?>(Enumerable.Where<ILVariable>((IEnumerable<ILVariable>)iLFunction.Variables, (Func<ILVariable, bool>)((ILVariable v) => v.Kind == VariableKind.Parameter)), (Func<ILVariable, int?>)((ILVariable v) => v.Index));
				foreach (ParameterDeclaration item in entityDecl.GetChildrenByRole(Roles.Parameter))
				{
					if (dictionary.TryGetValue(num, out var value))
					{
						item.AddAnnotation(new ILVariableResolveResult(value, method.Parameters[num].Type));
					}
					num = checked(num + 1);
				}
			}
			DecompilerSettings decompilerSettings = settings.Clone();
			if (IsWindowsFormsInitializeComponentMethod(method))
			{
				decompilerSettings.UseImplicitMethodGroupConversion = false;
				decompilerSettings.UsingDeclarations = false;
				decompilerSettings.AlwaysCastTargetsOfExplicitInterfaceImplementationCalls = true;
				decompilerSettings.NamedArguments = false;
			}
			ILTransformContext context = new ILTransformContext(iLFunction, typeSystem, DebugInfoProvider, decompilerSettings)
			{
				CancellationToken = CancellationToken,
				DecompileRun = decompileRun
			};
			foreach (IILTransform ilTransform in ilTransforms)
			{
				CancellationToken.ThrowIfCancellationRequested();
				ilTransform.Run(iLFunction, context);
				iLFunction.CheckInvariant(ILPhase.Normal);
				if (!decompilerSettings.DecompileMemberBodies && ilTransform is AsyncAwaitDecompiler)
				{
					break;
				}
			}
			if (decompilerSettings.DecompileMemberBodies)
			{
				AddDefinesForConditionalAttributes(iLFunction, decompileRun);
				StatementBuilder statementBuilder = new StatementBuilder(typeSystem, decompilationContext, iLFunction, decompilerSettings, CancellationToken);
				blockStatement = statementBuilder.ConvertAsBlock(iLFunction.Body);
				Comment prevSibling = null;
				foreach (string warning in iLFunction.Warnings)
				{
					blockStatement.InsertChildAfter(prevSibling, prevSibling = new Comment(warning), Roles.Comment);
				}
				entityDecl.AddChild(blockStatement, Roles.Body);
			}
			entityDecl.AddAnnotation(iLFunction);
			if (iLFunction.IsIterator)
			{
				if (decompilerSettings.DecompileMemberBodies && !Enumerable.Any<AstNode>(blockStatement.Descendants, (Func<AstNode, bool>)((AstNode d) => d is YieldReturnStatement || d is YieldBreakStatement)))
				{
					blockStatement.Add(new YieldBreakStatement());
				}
				RemoveAttribute(entityDecl, KnownAttribute.IteratorStateMachine);
				if (iLFunction.StateMachineCompiledWithMono)
				{
					RemoveAttribute(entityDecl, KnownAttribute.DebuggerHidden);
				}
			}
			if (iLFunction.IsAsync)
			{
				entityDecl.Modifiers |= Modifiers.Async;
				RemoveAttribute(entityDecl, KnownAttribute.AsyncStateMachine);
				RemoveAttribute(entityDecl, KnownAttribute.DebuggerStepThrough);
			}
		}
		catch (Exception ex2) when (!(ex2 is OperationCanceledException) && !(ex2 is DecompilerException))
		{
			Console.WriteLine("innerException: " + ex2);
		}
	}

	private bool RemoveAttribute(EntityDeclaration entityDecl, KnownAttribute attributeType)
	{
		bool result = false;
		foreach (AttributeSection attribute in entityDecl.Attributes)
		{
			foreach (DecompTools.Decompiler.CSharp.Syntax.Attribute attribute2 in attribute.Attributes)
			{
				ISymbol symbol = attribute2.Type.GetSymbol();
				if (symbol is ITypeDefinition typeDefinition && typeDefinition.FullTypeName == attributeType.GetTypeName())
				{
					attribute2.Remove();
					result = true;
				}
			}
			if (attribute.Attributes.Count == 0)
			{
				attribute.Remove();
			}
		}
		return result;
	}

	private bool FindAttribute(EntityDeclaration entityDecl, KnownAttribute attributeType, out DecompTools.Decompiler.CSharp.Syntax.Attribute attribute)
	{
		attribute = null;
		foreach (AttributeSection attribute2 in entityDecl.Attributes)
		{
			foreach (DecompTools.Decompiler.CSharp.Syntax.Attribute attribute3 in attribute2.Attributes)
			{
				ISymbol symbol = attribute3.Type.GetSymbol();
				if (symbol is ITypeDefinition typeDefinition && typeDefinition.FullTypeName == attributeType.GetTypeName())
				{
					attribute = attribute3;
					return true;
				}
			}
		}
		return false;
	}

	private void AddDefinesForConditionalAttributes(ILFunction function, DecompileRun decompileRun)
	{
		foreach (CallInstruction item in Enumerable.OfType<CallInstruction>((IEnumerable)function.Descendants))
		{
			if (item.Method.GetAttribute(KnownAttribute.Conditional, inherit: true)?.FixedArguments.FirstOrDefault().Value is string text && decompileRun.DefinedSymbols.Add(text))
			{
				syntaxTree.InsertChildAfter(null, new PreProcessorDirective(PreProcessorDirectiveType.Define, text), Roles.PreProcessorDirective);
			}
		}
	}

	private EntityDeclaration DoDecompile(IField field, DecompileRun decompileRun, ITypeResolveContext decompilationContext)
	{
		Debug.Assert(decompilationContext.CurrentMember == field);
		try
		{
			TypeSystemAstBuilder typeSystemAstBuilder = CreateAstBuilder(decompilationContext);
			if (decompilationContext.CurrentTypeDefinition.Kind == TypeKind.Enum && field.IsConst)
			{
				EnumMemberDeclaration enumMemberDeclaration = new EnumMemberDeclaration
				{
					Name = field.Name
				};
				object constantValue = field.GetConstantValue();
				if (constantValue != null)
				{
					long num = (long)CSharpPrimitiveCast.Cast(TypeCode.Int64, constantValue, checkForOverflow: false);
					enumMemberDeclaration.Initializer = typeSystemAstBuilder.ConvertConstantValue(decompilationContext.CurrentTypeDefinition.EnumUnderlyingType, constantValue);
					if (enumMemberDeclaration.Initializer is PrimitiveExpression primitiveExpression && num >= 0 && (decompilationContext.CurrentTypeDefinition.HasAttribute(KnownAttribute.Flags) || (num > 9 && ((num & (num - 1)) == 0L || (num & (num + 1)) == 0))))
					{
						primitiveExpression.SetValue(num, $"0x{num:X}");
					}
				}
				enumMemberDeclaration.Attributes.AddRange(Enumerable.Select<IAttribute, AttributeSection>(field.GetAttributes(), (Func<IAttribute, AttributeSection>)((IAttribute a) => new AttributeSection(typeSystemAstBuilder.ConvertAttribute(a)))));
				enumMemberDeclaration.AddAnnotation(new MemberResolveResult(null, field));
				return enumMemberDeclaration;
			}
			bool flag = (field.Name == "PI" || field.Name == "E") && (field.DeclaringType.FullName == "System.Math" || field.DeclaringType.FullName == "System.MathF");
			typeSystemAstBuilder.UseSpecialConstants = !(field.DeclaringType.Equals(field.ReturnType) | flag);
			EntityDeclaration entityDeclaration = typeSystemAstBuilder.ConvertEntity(field);
			SetNewModifier(entityDeclaration);
			if (settings.FixedBuffers && IsFixedField(field, out var type, out var elementCount))
			{
				FixedFieldDeclaration fixedFieldDeclaration = new FixedFieldDeclaration();
				entityDeclaration.Attributes.MoveTo(fixedFieldDeclaration.Attributes);
				fixedFieldDeclaration.Modifiers = entityDeclaration.Modifiers;
				fixedFieldDeclaration.ReturnType = typeSystemAstBuilder.ConvertType(type);
				fixedFieldDeclaration.Variables.Add(new FixedVariableInitializer(field.Name, new PrimitiveExpression(elementCount)));
				Enumerable.Single<FixedVariableInitializer>((IEnumerable<FixedVariableInitializer>)fixedFieldDeclaration.Variables).CopyAnnotationsFrom(Enumerable.Single<VariableInitializer>((IEnumerable<VariableInitializer>)((FieldDeclaration)entityDeclaration).Variables));
				fixedFieldDeclaration.CopyAnnotationsFrom(entityDeclaration);
				RemoveAttribute(fixedFieldDeclaration, KnownAttribute.FixedBuffer);
				return fixedFieldDeclaration;
			}
			FieldDefinition fieldDefinition = metadata.GetFieldDefinition((FieldDefinitionHandle)field.MetadataToken);
			if (fieldDefinition.HasFlag(FieldAttributes.HasFieldRVA))
			{
				string content;
				try
				{
					BlobReader initialValue = fieldDefinition.GetInitialValue(module.PEFile.Reader, TypeSystem);
					content = $" Not supported: data({BitConverter.ToString(initialValue.ReadBytes(initialValue.RemainingBytes)).Replace('-', ' ')}) ";
				}
				catch (BadImageFormatException ex)
				{
					content = ex.Message;
				}
				Enumerable.Single<VariableInitializer>((IEnumerable<VariableInitializer>)((FieldDeclaration)entityDeclaration).Variables).AddChild(new Comment(content, CommentType.MultiLine), Roles.Comment);
			}
			return entityDeclaration;
		}
		catch (Exception ex2) when (!(ex2 is OperationCanceledException) && !(ex2 is DecompilerException))
		{
			throw new DecompilerException(module, field, ex2);
		}
	}

	internal static bool IsFixedField(IField field, out IType type, out int elementCount)
	{
		type = null;
		elementCount = 0;
		IAttribute attribute = field.GetAttribute(KnownAttribute.FixedBuffer);
		if (attribute != null && attribute.FixedArguments.Length == 2 && attribute.FixedArguments[0].Value is IType type2 && attribute.FixedArguments[1].Value is int num)
		{
			type = type2;
			elementCount = num;
			return true;
		}
		return false;
	}

	private EntityDeclaration DoDecompile(IProperty property, DecompileRun decompileRun, ITypeResolveContext decompilationContext)
	{
		Debug.Assert(decompilationContext.CurrentMember == property);
		try
		{
			TypeSystemAstBuilder typeSystemAstBuilder = CreateAstBuilder(decompilationContext);
			EntityDeclaration entityDeclaration = typeSystemAstBuilder.ConvertEntity(property);
			if (property.IsExplicitInterfaceImplementation && !property.IsIndexer)
			{
				int num = property.Name.LastIndexOf('.');
				entityDeclaration.Name = property.Name.Substring(checked(num + 1));
			}
			FixParameterNames(entityDeclaration);
			Accessor getter;
			Accessor setter;
			if (entityDeclaration is PropertyDeclaration)
			{
				getter = ((PropertyDeclaration)entityDeclaration).Getter;
				setter = ((PropertyDeclaration)entityDeclaration).Setter;
			}
			else
			{
				getter = ((IndexerDeclaration)entityDeclaration).Getter;
				setter = ((IndexerDeclaration)entityDeclaration).Setter;
			}
			if (property.CanGet && property.Getter.HasBody)
			{
				DecompileBody(property.Getter, getter, decompileRun, decompilationContext);
			}
			if (property.CanSet && property.Setter.HasBody)
			{
				DecompileBody(property.Setter, setter, decompileRun, decompilationContext);
			}
			MethodDefinitionHandle handle = (MethodDefinitionHandle)(property.Getter ?? property.Setter).MetadataToken;
			MethodDefinition methodDefinition = metadata.GetMethodDefinition(handle);
			if (!handle.GetMethodImplementations(metadata).Any() && methodDefinition.HasFlag(MethodAttributes.Virtual) == methodDefinition.HasFlag(MethodAttributes.VtableLayoutMask))
			{
				SetNewModifier(entityDeclaration);
			}
			return entityDeclaration;
		}
		catch (Exception ex) when (!(ex is OperationCanceledException) && !(ex is DecompilerException))
		{
			throw new DecompilerException(module, property, ex);
		}
	}

	private EntityDeclaration DoDecompile(IEvent ev, DecompileRun decompileRun, ITypeResolveContext decompilationContext)
	{
		Debug.Assert(decompilationContext.CurrentMember == ev);
		try
		{
			TypeSystemAstBuilder typeSystemAstBuilder = CreateAstBuilder(decompilationContext);
			typeSystemAstBuilder.UseCustomEvents = ev.DeclaringTypeDefinition.Kind != TypeKind.Interface;
			EntityDeclaration entityDeclaration = typeSystemAstBuilder.ConvertEntity(ev);
			int num = ev.Name.LastIndexOf('.');
			if (ev.IsExplicitInterfaceImplementation)
			{
				entityDeclaration.Name = ev.Name.Substring(checked(num + 1));
			}
			if (ev.CanAdd && ev.AddAccessor.HasBody)
			{
				DecompileBody(ev.AddAccessor, ((CustomEventDeclaration)entityDeclaration).AddAccessor, decompileRun, decompilationContext);
			}
			if (ev.CanRemove && ev.RemoveAccessor.HasBody)
			{
				DecompileBody(ev.RemoveAccessor, ((CustomEventDeclaration)entityDeclaration).RemoveAccessor, decompileRun, decompilationContext);
			}
			MethodDefinition methodDefinition = metadata.GetMethodDefinition((MethodDefinitionHandle)(ev.AddAccessor ?? ev.RemoveAccessor).MetadataToken);
			if (methodDefinition.HasFlag(MethodAttributes.Virtual) == methodDefinition.HasFlag(MethodAttributes.VtableLayoutMask))
			{
				SetNewModifier(entityDeclaration);
			}
			return entityDeclaration;
		}
		catch (Exception ex) when (!(ex is OperationCanceledException) && !(ex is DecompilerException))
		{
			throw new DecompilerException(module, ev, ex);
		}
	}

	public Dictionary<ILFunction, List<DecompTools.Decompiler.DebugInfo.SequencePoint>> CreateSequencePoints(SyntaxTree syntaxTree)
	{
		SequencePointBuilder sequencePointBuilder = new SequencePointBuilder();
		syntaxTree.AcceptVisitor(sequencePointBuilder);
		return sequencePointBuilder.GetSequencePoints();
	}
}
