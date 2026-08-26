using System;
using System.Text;
using dnlib.DotNet;
using dnSpy.Contracts.Decompiler;
using dnSpy.Contracts.Text;
using dnSpy.Decompiler.ILSpy.Core.CSharp;
using dnSpy.Decompiler.ILSpy.Core.Settings;
using dnSpy.Decompiler.VisualBasic;
using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.Ast;
using ICSharpCode.Decompiler.Ast.Transforms;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.VB;
using ICSharpCode.NRefactory.VB.Visitors;

namespace dnSpy.Decompiler.ILSpy.Core.VisualBasic;

internal sealed class VBDecompiler : DecompilerBase
{
	private readonly Predicate<IAstTransform> transformAbortCondition;

	private readonly bool showAllMembers;

	private readonly Func<BuilderCache> createBuilderCache;

	private readonly CSharpVBDecompilerSettings langSettings;

	public override DecompilerSettingsBase Settings => langSettings;

	public override double OrderUI => DecompilerConstants.VISUALBASIC_ILSPY_ORDERUI;

	public override MetadataTextColorProvider MetadataTextColorProvider => VisualBasicMetadataTextColorProvider.Instance;

	public override string ContentTypeString => "VB ILSpy";

	public override string GenericNameUI => DecompilerConstants.GENERIC_NAMEUI_VISUALBASIC;

	public override string UniqueNameUI => "Visual Basic";

	public override Guid GenericGuid => DecompilerConstants.LANGUAGE_VISUALBASIC;

	public override Guid UniqueGuid => DecompilerConstants.LANGUAGE_VISUALBASIC_ILSPY;

	public override string FileExtension => ".vb";

	public override string ProjectFileExtension => ".vbproj";

	public VBDecompiler(CSharpVBDecompilerSettings langSettings)
	{
		this.langSettings = langSettings;
		createBuilderCache = () => new BuilderCache(this.langSettings.Settings.SettingsVersion);
	}

	public override void WriteCommentBegin(IDecompilerOutput output, bool addSpace)
	{
		if (addSpace)
		{
			output.Write("' ", BoxedTextColor.Comment);
		}
		else
		{
			output.Write("'", BoxedTextColor.Comment);
		}
	}

	public override void WriteCommentEnd(IDecompilerOutput output, bool addSpace)
	{
	}

	private DecompilerSettings GetDecompilerSettings()
	{
		DecompilerSettings decompilerSettings = langSettings.Settings.Clone();
		decompilerSettings.TypeAddInternalModifier = true;
		decompilerSettings.MemberAddPrivateModifier = true;
		return decompilerSettings;
	}

	public override void Decompile(AssemblyDef asm, IDecompilerOutput output, DecompilationContext ctx)
	{
		WriteAssembly(asm, output, ctx);
		using (ctx.DisableAssemblyLoad())
		{
			BuilderState state = CreateAstBuilder(ctx, GetDecompilerSettings(), asm.ManifestModule);
			try
			{
				state.AstBuilder.AddAssembly(asm.ManifestModule, onlyAssemblyLevel: true, decompileAsm: true, decompileMod: false);
				RunTransformsAndGenerateCode(ref state, output, ctx);
			}
			finally
			{
				state.Dispose();
			}
		}
	}

	public override void Decompile(ModuleDef mod, IDecompilerOutput output, DecompilationContext ctx)
	{
		WriteModule(mod, output, ctx);
		using (ctx.DisableAssemblyLoad())
		{
			BuilderState state = CreateAstBuilder(ctx, GetDecompilerSettings(), mod);
			try
			{
				state.AstBuilder.AddAssembly(mod, onlyAssemblyLevel: true, decompileAsm: false, decompileMod: true);
				RunTransformsAndGenerateCode(ref state, output, ctx);
			}
			finally
			{
				state.Dispose();
			}
		}
	}

	public override void Decompile(MethodDef method, IDecompilerOutput output, DecompilationContext ctx)
	{
		WriteCommentLineDeclaringType(output, method);
		BuilderState state = CreateAstBuilder(ctx, GetDecompilerSettings(), null, method.DeclaringType, isSingleMember: true);
		try
		{
			state.AstBuilder.AddMethod(method);
			RunTransformsAndGenerateCode(ref state, output, ctx);
		}
		finally
		{
			state.Dispose();
		}
	}

	public override void Decompile(PropertyDef property, IDecompilerOutput output, DecompilationContext ctx)
	{
		WriteCommentLineDeclaringType(output, property);
		BuilderState state = CreateAstBuilder(ctx, GetDecompilerSettings(), null, property.DeclaringType, isSingleMember: true);
		try
		{
			state.AstBuilder.AddProperty(property);
			RunTransformsAndGenerateCode(ref state, output, ctx);
		}
		finally
		{
			state.Dispose();
		}
	}

	public override void Decompile(FieldDef field, IDecompilerOutput output, DecompilationContext ctx)
	{
		WriteCommentLineDeclaringType(output, field);
		BuilderState state = CreateAstBuilder(ctx, GetDecompilerSettings(), null, field.DeclaringType, isSingleMember: true);
		try
		{
			state.AstBuilder.AddField(field);
			RunTransformsAndGenerateCode(ref state, output, ctx);
		}
		finally
		{
			state.Dispose();
		}
	}

	public override void Decompile(EventDef ev, IDecompilerOutput output, DecompilationContext ctx)
	{
		WriteCommentLineDeclaringType(output, ev);
		BuilderState state = CreateAstBuilder(ctx, GetDecompilerSettings(), null, ev.DeclaringType, isSingleMember: true);
		try
		{
			state.AstBuilder.AddEvent(ev);
			RunTransformsAndGenerateCode(ref state, output, ctx);
		}
		finally
		{
			state.Dispose();
		}
	}

	public override void Decompile(TypeDef type, IDecompilerOutput output, DecompilationContext ctx)
	{
		BuilderState state = CreateAstBuilder(ctx, GetDecompilerSettings(), null, type);
		try
		{
			state.AstBuilder.AddType(type);
			RunTransformsAndGenerateCode(ref state, output, ctx);
		}
		finally
		{
			state.Dispose();
		}
	}

	public override bool ShowMember(IMemberRef member)
	{
		return CSharpDecompiler.ShowMember(member, showAllMembers, GetDecompilerSettings());
	}

	private void RunTransformsAndGenerateCode(ref BuilderState state, IDecompilerOutput output, DecompilationContext ctx, IAstTransform additionalTransform = null)
	{
		AstBuilder astBuilder = state.AstBuilder;
		astBuilder.RunTransformations(transformAbortCondition);
		additionalTransform?.Run(astBuilder.SyntaxTree);
		CSharpDecompiler.AddXmlDocumentation(ref state, GetDecompilerSettings(), astBuilder);
		SyntaxTree syntaxTree = astBuilder.SyntaxTree;
		syntaxTree.AcceptVisitor(new InsertParenthesesVisitor
		{
			InsertParenthesesForReadability = true
		});
		ICSharpCode.NRefactory.VB.AstNode astNode = syntaxTree.AcceptVisitor(new CSharpToVBConverterVisitor(state.AstBuilder.Context.CurrentModule, new ILSpyEnvironmentProvider(state.State.XmlDoc_StringBuilder)), null);
		VBTextOutputFormatter formatter = new VBTextOutputFormatter(output, astBuilder.Context);
		VBFormattingOptions formattingPolicy = new VBFormattingOptions();
		astNode.AcceptVisitor(new OutputVisitor(formatter, formattingPolicy), null);
	}

	private BuilderState CreateAstBuilder(DecompilationContext ctx, DecompilerSettings settings, ModuleDef currentModule = null, TypeDef currentType = null, bool isSingleMember = false)
	{
		if (currentModule == null)
		{
			currentModule = currentType.Module;
		}
		settings = settings.Clone();
		if (isSingleMember)
		{
			settings.UsingDeclarations = false;
		}
		settings.IntroduceIncrementAndDecrement = false;
		settings.MakeAssignmentExpressions = false;
		settings.QueryExpressions = false;
		settings.AlwaysGenerateExceptionVariableForCatchBlocksUnlessTypeIsObject = true;
		BuilderCache orCreate = ctx.GetOrCreate(createBuilderCache);
		BuilderState result = new BuilderState(ctx, orCreate, MetadataTextColorProvider);
		result.AstBuilder.Context.CurrentModule = currentModule;
		result.AstBuilder.Context.CancellationToken = ctx.CancellationToken;
		result.AstBuilder.Context.CurrentType = currentType;
		result.AstBuilder.Context.Settings = settings;
		return result;
	}

	protected override void FormatTypeName(IDecompilerOutput output, TypeDef type)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		TypeToString(output, ConvertTypeOptions.IncludeTypeParameterDefinitions | ConvertTypeOptions.DoNotUsePrimitiveTypeNames | ConvertTypeOptions.DoNotIncludeEnclosingType, type);
	}

	protected override void TypeToString(IDecompilerOutput output, ITypeDefOrRef type, bool includeNamespace, IHasCustomAttribute typeAttributes = null)
	{
		ConvertTypeOptions convertTypeOptions = ConvertTypeOptions.IncludeTypeParameterDefinitions;
		if (includeNamespace)
		{
			convertTypeOptions |= ConvertTypeOptions.IncludeNamespace;
		}
		TypeToString(output, convertTypeOptions, type, typeAttributes);
	}

	private void TypeToString(IDecompilerOutput output, ConvertTypeOptions options, ITypeDefOrRef type, IHasCustomAttribute typeAttributes = null)
	{
		ILSpyEnvironmentProvider provider = new ILSpyEnvironmentProvider();
		CSharpToVBConverterVisitor visitor = new CSharpToVBConverterVisitor(type.Module, provider);
		AstType astType = AstBuilder.ConvertType(type, new StringBuilder(), typeAttributes, options);
		if (type.TryGetByRefSig() != null)
		{
			output.Write("ByRef", BoxedTextColor.Keyword);
			output.Write(" ", BoxedTextColor.Text);
			if (astType is ComposedType && ((ComposedType)astType).PointerRank > 0)
			{
				((ComposedType)astType).PointerRank--;
			}
		}
		ICSharpCode.NRefactory.VB.AstNode astNode = astType.AcceptVisitor(visitor, null);
		DecompilerContext context = new DecompilerContext(GetDecompilerSettings().SettingsVersion, type.Module, MetadataTextColorProvider);
		astNode.AcceptVisitor(new OutputVisitor(new VBTextOutputFormatter(output, context), new VBFormattingOptions()), null);
	}

	public override bool CanDecompile(DecompilationType decompilationType)
	{
		if ((uint)decompilationType <= 2u)
		{
			return true;
		}
		return base.CanDecompile(decompilationType);
	}

	public override void Decompile(DecompilationType decompilationType, object data)
	{
		switch (decompilationType)
		{
		case DecompilationType.PartialType:
			DecompilePartial((DecompilePartialType)data);
			break;
		case DecompilationType.AssemblyInfo:
			DecompileAssemblyInfo((DecompileAssemblyInfo)data);
			break;
		case DecompilationType.TypeMethods:
			DecompileTypeMethods((DecompileTypeMethods)data);
			break;
		default:
			base.Decompile(decompilationType, data);
			break;
		}
	}

	private void DecompilePartial(DecompilePartialType info)
	{
		BuilderState state = CreateAstBuilder(info.Context, CSharpDecompiler.CreateDecompilerSettings(GetDecompilerSettings(), info.UseUsingDeclarations), null, info.Type);
		try
		{
			state.AstBuilder.AddType(info.Type);
			RunTransformsAndGenerateCode(ref state, info.Output, info.Context, new DecompilePartialTransform(info.Type, info.Definitions, info.ShowDefinitions, info.AddPartialKeyword, info.InterfacesToRemove));
		}
		finally
		{
			state.Dispose();
		}
	}

	private void DecompileAssemblyInfo(DecompileAssemblyInfo info)
	{
		BuilderState state = CreateAstBuilder(info.Context, GetDecompilerSettings(), info.Module);
		try
		{
			state.AstBuilder.AddAssembly(info.Module, onlyAssemblyLevel: true, info.Module.IsManifestModule, decompileMod: true);
			RunTransformsAndGenerateCode(ref state, info.Output, info.Context, info.KeepAllAttributes ? null : new AssemblyInfoTransform());
		}
		finally
		{
			state.Dispose();
		}
	}

	private void DecompileTypeMethods(DecompileTypeMethods info)
	{
		BuilderState state = CreateAstBuilder(info.Context, CSharpDecompiler.CreateDecompilerSettings_DecompileTypeMethods(GetDecompilerSettings(), !info.DecompileHidden, info.ShowAll), null, info.Type);
		try
		{
			state.AstBuilder.GetDecompiledBodyKind = (AstBuilder builder, MethodDef method) => CSharpDecompiler.GetDecompiledBodyKind(info, builder, method);
			state.AstBuilder.AddType(info.Type);
			RunTransformsAndGenerateCode(ref state, info.Output, info.Context, new DecompileTypeMethodsTransform(info.Types, info.Methods, !info.DecompileHidden, info.ShowAll));
		}
		finally
		{
			state.Dispose();
		}
	}

	public override void WriteToolTip(ITextColorWriter output, IMemberRef member, IHasCustomAttribute typeAttributes)
	{
		new VisualBasicFormatter(output, FormatterOptions.Default | FormatterOptions.ShowParameterLiteralValues, null).WriteToolTip(member);
	}

	public override void WriteToolTip(ITextColorWriter output, ISourceVariable variable)
	{
		new VisualBasicFormatter(output, FormatterOptions.Default | FormatterOptions.ShowParameterLiteralValues, null).WriteToolTip(variable);
	}

	public override void WriteNamespaceToolTip(ITextColorWriter output, string @namespace)
	{
		new VisualBasicFormatter(output, FormatterOptions.Default | FormatterOptions.ShowParameterLiteralValues, null).WriteNamespaceToolTip(@namespace);
	}

	public override void Write(ITextColorWriter output, IMemberRef member, FormatterOptions flags)
	{
		new VisualBasicFormatter(output, flags, null).Write(member);
	}
}
