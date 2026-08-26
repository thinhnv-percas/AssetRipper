using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using DecompTools.Decompiler.CSharp;
using DecompTools.Decompiler.CSharp.OutputVisitor;

namespace DecompTools.Decompiler;

public class DecompilerSettings : INotifyPropertyChanged
{
	private bool anonymousMethods = true;

	private bool anonymousTypes = true;

	private bool useLambdaSyntax = true;

	private bool expressionTrees = true;

	private bool yieldReturn = true;

	private bool dynamic = true;

	private bool asyncAwait = true;

	private bool awaitInCatchFinally = true;

	private bool decimalConstants = true;

	private bool fixedBuffers = true;

	private bool liftNullables = true;

	private bool nullPropagation = true;

	private bool automaticProperties = true;

	private bool automaticEvents = true;

	private bool usingStatement = true;

	private bool alwaysUseBraces = true;

	private bool forEachStatement = true;

	private bool lockStatement = true;

	private bool switchStatementOnString = true;

	private bool usingDeclarations = true;

	private bool extensionMethods = true;

	private bool queryExpressions = true;

	private bool useImplicitMethodGroupConversion = true;

	private bool alwaysCastTargetsOfExplicitInterfaceImplementationCalls = false;

	private bool useDebugSymbols = true;

	private bool arrayInitializers = true;

	private bool objectCollectionInitializers = true;

	private bool dictionaryInitializers = true;

	private bool extensionMethodsInCollectionInitializers = true;

	private bool stringInterpolation = true;

	private bool showXmlDocumentation = true;

	private bool foldBraces = false;

	private bool expandMemberDefinitions = false;

	private bool decompileMemberBodies = true;

	private bool useExpressionBodyForCalculatedGetterOnlyProperties = true;

	private bool outVariables = true;

	private bool discards = true;

	private bool introduceRefModifiersOnStructs = true;

	private bool introduceReadonlyAndInModifiers = true;

	private bool introduceUnmanagedConstraint = true;

	private bool stackAllocInitializers = true;

	private bool tupleTypes = true;

	private bool tupleConversions = true;

	private bool tupleComparisons = true;

	private bool namedArguments = true;

	private bool nonTrailingNamedArguments = true;

	private bool optionalArguments = true;

	private bool localFunctions = false;

	private bool nullableReferenceTypes = true;

	private bool showDebugInfo;

	private bool assumeArrayLengthFitsIntoInt32 = true;

	private bool introduceIncrementAndDecrement = true;

	private bool makeAssignmentExpressions = true;

	private bool removeDeadCode = false;

	private bool loadInMemory = false;

	private bool throwOnAssemblyResolveErrors = true;

	private bool applyWindowsRuntimeProjections = true;

	private CSharpFormattingOptions csharpFormattingOptions;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private PropertyChangedEventHandler m_PropertyChanged;

	public bool AnonymousMethods
	{
		get
		{
			return anonymousMethods;
		}
		set
		{
			if (anonymousMethods != value)
			{
				anonymousMethods = value;
				OnPropertyChanged("AnonymousMethods");
			}
		}
	}

	public bool AnonymousTypes
	{
		get
		{
			return anonymousTypes;
		}
		set
		{
			if (anonymousTypes != value)
			{
				anonymousTypes = value;
				OnPropertyChanged("AnonymousTypes");
			}
		}
	}

	public bool UseLambdaSyntax
	{
		get
		{
			return useLambdaSyntax;
		}
		set
		{
			if (useLambdaSyntax != value)
			{
				useLambdaSyntax = value;
				OnPropertyChanged("UseLambdaSyntax");
			}
		}
	}

	public bool ExpressionTrees
	{
		get
		{
			return expressionTrees;
		}
		set
		{
			if (expressionTrees != value)
			{
				expressionTrees = value;
				OnPropertyChanged("ExpressionTrees");
			}
		}
	}

	public bool YieldReturn
	{
		get
		{
			return yieldReturn;
		}
		set
		{
			if (yieldReturn != value)
			{
				yieldReturn = value;
				OnPropertyChanged("YieldReturn");
			}
		}
	}

	public bool Dynamic
	{
		get
		{
			return dynamic;
		}
		set
		{
			if (dynamic != value)
			{
				dynamic = value;
				OnPropertyChanged("Dynamic");
			}
		}
	}

	public bool AsyncAwait
	{
		get
		{
			return asyncAwait;
		}
		set
		{
			if (asyncAwait != value)
			{
				asyncAwait = value;
				OnPropertyChanged("AsyncAwait");
			}
		}
	}

	public bool AwaitInCatchFinally
	{
		get
		{
			return awaitInCatchFinally;
		}
		set
		{
			if (awaitInCatchFinally != value)
			{
				awaitInCatchFinally = value;
				OnPropertyChanged("AwaitInCatchFinally");
			}
		}
	}

	public bool DecimalConstants
	{
		get
		{
			return decimalConstants;
		}
		set
		{
			if (decimalConstants != value)
			{
				decimalConstants = value;
				OnPropertyChanged("DecimalConstants");
			}
		}
	}

	public bool FixedBuffers
	{
		get
		{
			return fixedBuffers;
		}
		set
		{
			if (fixedBuffers != value)
			{
				fixedBuffers = value;
				OnPropertyChanged("FixedBuffers");
			}
		}
	}

	public bool LiftNullables
	{
		get
		{
			return liftNullables;
		}
		set
		{
			if (liftNullables != value)
			{
				liftNullables = value;
				OnPropertyChanged("LiftNullables");
			}
		}
	}

	public bool NullPropagation
	{
		get
		{
			return nullPropagation;
		}
		set
		{
			if (nullPropagation != value)
			{
				nullPropagation = value;
				OnPropertyChanged("NullPropagation");
			}
		}
	}

	public bool AutomaticProperties
	{
		get
		{
			return automaticProperties;
		}
		set
		{
			if (automaticProperties != value)
			{
				automaticProperties = value;
				OnPropertyChanged("AutomaticProperties");
			}
		}
	}

	public bool AutomaticEvents
	{
		get
		{
			return automaticEvents;
		}
		set
		{
			if (automaticEvents != value)
			{
				automaticEvents = value;
				OnPropertyChanged("AutomaticEvents");
			}
		}
	}

	public bool UsingStatement
	{
		get
		{
			return usingStatement;
		}
		set
		{
			if (usingStatement != value)
			{
				usingStatement = value;
				OnPropertyChanged("UsingStatement");
			}
		}
	}

	public bool AlwaysUseBraces
	{
		get
		{
			return alwaysUseBraces;
		}
		set
		{
			if (alwaysUseBraces != value)
			{
				alwaysUseBraces = value;
				OnPropertyChanged("AlwaysUseBraces");
			}
		}
	}

	public bool ForEachStatement
	{
		get
		{
			return forEachStatement;
		}
		set
		{
			if (forEachStatement != value)
			{
				forEachStatement = value;
				OnPropertyChanged("ForEachStatement");
			}
		}
	}

	public bool LockStatement
	{
		get
		{
			return lockStatement;
		}
		set
		{
			if (lockStatement != value)
			{
				lockStatement = value;
				OnPropertyChanged("LockStatement");
			}
		}
	}

	public bool SwitchStatementOnString
	{
		get
		{
			return switchStatementOnString;
		}
		set
		{
			if (switchStatementOnString != value)
			{
				switchStatementOnString = value;
				OnPropertyChanged("SwitchStatementOnString");
			}
		}
	}

	public bool UsingDeclarations
	{
		get
		{
			return usingDeclarations;
		}
		set
		{
			if (usingDeclarations != value)
			{
				usingDeclarations = value;
				OnPropertyChanged("UsingDeclarations");
			}
		}
	}

	public bool ExtensionMethods
	{
		get
		{
			return extensionMethods;
		}
		set
		{
			if (extensionMethods != value)
			{
				extensionMethods = value;
				OnPropertyChanged("ExtensionMethods");
			}
		}
	}

	public bool QueryExpressions
	{
		get
		{
			return queryExpressions;
		}
		set
		{
			if (queryExpressions != value)
			{
				queryExpressions = value;
				OnPropertyChanged("QueryExpressions");
			}
		}
	}

	public bool UseImplicitMethodGroupConversion
	{
		get
		{
			return useImplicitMethodGroupConversion;
		}
		set
		{
			if (useImplicitMethodGroupConversion != value)
			{
				useImplicitMethodGroupConversion = value;
				OnPropertyChanged("UseImplicitMethodGroupConversion");
			}
		}
	}

	public bool AlwaysCastTargetsOfExplicitInterfaceImplementationCalls
	{
		get
		{
			return alwaysCastTargetsOfExplicitInterfaceImplementationCalls;
		}
		set
		{
			if (alwaysCastTargetsOfExplicitInterfaceImplementationCalls != value)
			{
				alwaysCastTargetsOfExplicitInterfaceImplementationCalls = value;
				OnPropertyChanged("AlwaysCastTargetsOfExplicitInterfaceImplementationCalls");
			}
		}
	}

	public bool UseDebugSymbols
	{
		get
		{
			return useDebugSymbols;
		}
		set
		{
			if (useDebugSymbols != value)
			{
				useDebugSymbols = value;
				OnPropertyChanged("UseDebugSymbols");
			}
		}
	}

	public bool ArrayInitializers
	{
		get
		{
			return arrayInitializers;
		}
		set
		{
			if (arrayInitializers != value)
			{
				arrayInitializers = value;
				OnPropertyChanged("ArrayInitializers");
			}
		}
	}

	public bool ObjectOrCollectionInitializers
	{
		get
		{
			return objectCollectionInitializers;
		}
		set
		{
			if (objectCollectionInitializers != value)
			{
				objectCollectionInitializers = value;
				OnPropertyChanged("ObjectOrCollectionInitializers");
			}
		}
	}

	public bool DictionaryInitializers
	{
		get
		{
			return dictionaryInitializers;
		}
		set
		{
			if (dictionaryInitializers != value)
			{
				dictionaryInitializers = value;
				OnPropertyChanged("DictionaryInitializers");
			}
		}
	}

	public bool ExtensionMethodsInCollectionInitializers
	{
		get
		{
			return extensionMethodsInCollectionInitializers;
		}
		set
		{
			if (extensionMethodsInCollectionInitializers != value)
			{
				extensionMethodsInCollectionInitializers = value;
				OnPropertyChanged("ExtensionMethodsInCollectionInitializers");
			}
		}
	}

	public bool StringInterpolation
	{
		get
		{
			return stringInterpolation;
		}
		set
		{
			if (stringInterpolation != value)
			{
				stringInterpolation = value;
				OnPropertyChanged("StringInterpolation");
			}
		}
	}

	public bool ShowXmlDocumentation
	{
		get
		{
			return showXmlDocumentation;
		}
		set
		{
			if (showXmlDocumentation != value)
			{
				showXmlDocumentation = value;
				OnPropertyChanged("ShowXmlDocumentation");
			}
		}
	}

	public bool FoldBraces
	{
		get
		{
			return foldBraces;
		}
		set
		{
			if (foldBraces != value)
			{
				foldBraces = value;
				OnPropertyChanged("FoldBraces");
			}
		}
	}

	public bool ExpandMemberDefinitions
	{
		get
		{
			return expandMemberDefinitions;
		}
		set
		{
			if (expandMemberDefinitions != value)
			{
				expandMemberDefinitions = value;
				OnPropertyChanged("ExpandMemberDefinitions");
			}
		}
	}

	public bool DecompileMemberBodies
	{
		get
		{
			return decompileMemberBodies;
		}
		set
		{
			if (decompileMemberBodies != value)
			{
				decompileMemberBodies = value;
				OnPropertyChanged("DecompileMemberBodies");
			}
		}
	}

	public bool UseExpressionBodyForCalculatedGetterOnlyProperties
	{
		get
		{
			return useExpressionBodyForCalculatedGetterOnlyProperties;
		}
		set
		{
			if (useExpressionBodyForCalculatedGetterOnlyProperties != value)
			{
				useExpressionBodyForCalculatedGetterOnlyProperties = value;
				OnPropertyChanged("UseExpressionBodyForCalculatedGetterOnlyProperties");
			}
		}
	}

	public bool OutVariables
	{
		get
		{
			return outVariables;
		}
		set
		{
			if (outVariables != value)
			{
				outVariables = value;
				OnPropertyChanged("OutVariables");
			}
		}
	}

	public bool Discards
	{
		get
		{
			return discards;
		}
		set
		{
			if (discards != value)
			{
				discards = value;
				OnPropertyChanged("Discards");
			}
		}
	}

	public bool IntroduceRefModifiersOnStructs
	{
		get
		{
			return introduceRefModifiersOnStructs;
		}
		set
		{
			if (introduceRefModifiersOnStructs != value)
			{
				introduceRefModifiersOnStructs = value;
				OnPropertyChanged("IntroduceRefModifiersOnStructs");
			}
		}
	}

	public bool IntroduceReadonlyAndInModifiers
	{
		get
		{
			return introduceReadonlyAndInModifiers;
		}
		set
		{
			if (introduceReadonlyAndInModifiers != value)
			{
				introduceReadonlyAndInModifiers = value;
				OnPropertyChanged("IntroduceReadonlyAndInModifiers");
			}
		}
	}

	public bool IntroduceUnmanagedConstraint
	{
		get
		{
			return introduceUnmanagedConstraint;
		}
		set
		{
			if (introduceUnmanagedConstraint != value)
			{
				introduceUnmanagedConstraint = value;
				OnPropertyChanged("IntroduceUnmanagedConstraint");
			}
		}
	}

	public bool StackAllocInitializers
	{
		get
		{
			return stackAllocInitializers;
		}
		set
		{
			if (stackAllocInitializers != value)
			{
				stackAllocInitializers = value;
				OnPropertyChanged("StackAllocInitializers");
			}
		}
	}

	public bool TupleTypes
	{
		get
		{
			return tupleTypes;
		}
		set
		{
			if (tupleTypes != value)
			{
				tupleTypes = value;
				OnPropertyChanged("TupleTypes");
			}
		}
	}

	public bool TupleConversions
	{
		get
		{
			return tupleConversions;
		}
		set
		{
			if (tupleConversions != value)
			{
				tupleConversions = value;
				OnPropertyChanged("TupleConversions");
			}
		}
	}

	public bool TupleComparisons
	{
		get
		{
			return tupleComparisons;
		}
		set
		{
			if (tupleComparisons != value)
			{
				tupleComparisons = value;
				OnPropertyChanged("TupleComparisons");
			}
		}
	}

	public bool NamedArguments
	{
		get
		{
			return namedArguments;
		}
		set
		{
			if (namedArguments != value)
			{
				namedArguments = value;
				OnPropertyChanged("NamedArguments");
			}
		}
	}

	public bool NonTrailingNamedArguments
	{
		get
		{
			return nonTrailingNamedArguments;
		}
		set
		{
			if (nonTrailingNamedArguments != value)
			{
				nonTrailingNamedArguments = value;
				OnPropertyChanged("NonTrailingNamedArguments");
			}
		}
	}

	public bool OptionalArguments
	{
		get
		{
			return optionalArguments;
		}
		set
		{
			if (optionalArguments != value)
			{
				optionalArguments = value;
				OnPropertyChanged("OptionalArguments");
			}
		}
	}

	public bool LocalFunctions
	{
		get
		{
			return localFunctions;
		}
		set
		{
			if (localFunctions != value)
			{
				throw new NotImplementedException("C# 7.0 local functions are not implemented!");
			}
		}
	}

	public bool NullableReferenceTypes
	{
		get
		{
			return nullableReferenceTypes;
		}
		set
		{
			if (nullableReferenceTypes != value)
			{
				nullableReferenceTypes = value;
				OnPropertyChanged("NullableReferenceTypes");
			}
		}
	}

	public bool ShowDebugInfo
	{
		get
		{
			return showDebugInfo;
		}
		set
		{
			if (showDebugInfo != value)
			{
				showDebugInfo = value;
				OnPropertyChanged("ShowDebugInfo");
			}
		}
	}

	public bool AssumeArrayLengthFitsIntoInt32
	{
		get
		{
			return assumeArrayLengthFitsIntoInt32;
		}
		set
		{
			if (assumeArrayLengthFitsIntoInt32 != value)
			{
				assumeArrayLengthFitsIntoInt32 = value;
				OnPropertyChanged("AssumeArrayLengthFitsIntoInt32");
			}
		}
	}

	public bool IntroduceIncrementAndDecrement
	{
		get
		{
			return introduceIncrementAndDecrement;
		}
		set
		{
			if (introduceIncrementAndDecrement != value)
			{
				introduceIncrementAndDecrement = value;
				OnPropertyChanged("IntroduceIncrementAndDecrement");
			}
		}
	}

	public bool MakeAssignmentExpressions
	{
		get
		{
			return makeAssignmentExpressions;
		}
		set
		{
			if (makeAssignmentExpressions != value)
			{
				makeAssignmentExpressions = value;
				OnPropertyChanged("MakeAssignmentExpressions");
			}
		}
	}

	public bool RemoveDeadCode
	{
		get
		{
			return removeDeadCode;
		}
		set
		{
			if (removeDeadCode != value)
			{
				removeDeadCode = value;
				OnPropertyChanged("RemoveDeadCode");
			}
		}
	}

	public bool LoadInMemory
	{
		get
		{
			return loadInMemory;
		}
		set
		{
			if (loadInMemory != value)
			{
				loadInMemory = value;
				OnPropertyChanged("LoadInMemory");
			}
		}
	}

	public bool ThrowOnAssemblyResolveErrors
	{
		get
		{
			return throwOnAssemblyResolveErrors;
		}
		set
		{
			if (throwOnAssemblyResolveErrors != value)
			{
				throwOnAssemblyResolveErrors = value;
				OnPropertyChanged("ThrowOnAssemblyResolveErrors");
			}
		}
	}

	public bool ApplyWindowsRuntimeProjections
	{
		get
		{
			return applyWindowsRuntimeProjections;
		}
		set
		{
			if (applyWindowsRuntimeProjections != value)
			{
				applyWindowsRuntimeProjections = value;
				OnPropertyChanged("ApplyWindowsRuntimeProjections");
			}
		}
	}

	public CSharpFormattingOptions CSharpFormattingOptions
	{
		get
		{
			if (csharpFormattingOptions == null)
			{
				csharpFormattingOptions = FormattingOptionsFactory.CreateAllman();
				csharpFormattingOptions.IndentSwitchBody = false;
				csharpFormattingOptions.ArrayInitializerWrapping = Wrapping.WrapAlways;
			}
			return csharpFormattingOptions;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException();
			}
			if (csharpFormattingOptions != value)
			{
				csharpFormattingOptions = value;
				OnPropertyChanged("CSharpFormattingOptions");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		[CompilerGenerated]
		add
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			PropertyChangedEventHandler val = this.m_PropertyChanged;
			PropertyChangedEventHandler val2;
			do
			{
				val2 = val;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine((Delegate?)(object)val2, (Delegate?)(object)value);
				val = Interlocked.CompareExchange(ref this.m_PropertyChanged, value2, val2);
			}
			while (val != val2);
		}
		[CompilerGenerated]
		remove
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			PropertyChangedEventHandler val = this.m_PropertyChanged;
			PropertyChangedEventHandler val2;
			do
			{
				val2 = val;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove((Delegate?)(object)val2, (Delegate?)(object)value);
				val = Interlocked.CompareExchange(ref this.m_PropertyChanged, value2, val2);
			}
			while (val != val2);
		}
	}

	public DecompilerSettings()
	{
	}

	public DecompilerSettings(LanguageVersion languageVersion)
	{
		if (languageVersion < LanguageVersion.CSharp2)
		{
			anonymousMethods = false;
			liftNullables = false;
			yieldReturn = false;
			useImplicitMethodGroupConversion = false;
		}
		if (languageVersion < LanguageVersion.CSharp3)
		{
			anonymousTypes = false;
			useLambdaSyntax = false;
			objectCollectionInitializers = false;
			automaticProperties = false;
			extensionMethods = false;
			queryExpressions = false;
			expressionTrees = false;
		}
		if (languageVersion < LanguageVersion.CSharp4)
		{
			dynamic = false;
			namedArguments = false;
			optionalArguments = false;
		}
		if (languageVersion < LanguageVersion.CSharp5)
		{
			asyncAwait = false;
		}
		if (languageVersion < LanguageVersion.CSharp6)
		{
			awaitInCatchFinally = false;
			useExpressionBodyForCalculatedGetterOnlyProperties = false;
			nullPropagation = false;
			stringInterpolation = false;
			dictionaryInitializers = false;
			extensionMethodsInCollectionInitializers = false;
		}
		if (languageVersion < LanguageVersion.CSharp7)
		{
			outVariables = false;
			tupleTypes = false;
			tupleConversions = false;
			discards = false;
			localFunctions = false;
		}
		if (languageVersion < LanguageVersion.CSharp7_2)
		{
			introduceReadonlyAndInModifiers = false;
			introduceRefModifiersOnStructs = false;
			nonTrailingNamedArguments = false;
		}
		if (languageVersion < LanguageVersion.CSharp7_3)
		{
			introduceUnmanagedConstraint = false;
			stackAllocInitializers = false;
			tupleComparisons = false;
		}
		if (languageVersion < LanguageVersion.CSharp8_0)
		{
			nullableReferenceTypes = false;
		}
	}

	public LanguageVersion GetMinimumRequiredVersion()
	{
		if (introduceUnmanagedConstraint || tupleComparisons || stackAllocInitializers)
		{
			return LanguageVersion.CSharp7_3;
		}
		if (introduceRefModifiersOnStructs || introduceReadonlyAndInModifiers || nonTrailingNamedArguments)
		{
			return LanguageVersion.CSharp7_2;
		}
		if (outVariables || tupleTypes || tupleConversions || discards || localFunctions)
		{
			return LanguageVersion.CSharp7;
		}
		if (awaitInCatchFinally || useExpressionBodyForCalculatedGetterOnlyProperties || nullPropagation || stringInterpolation || dictionaryInitializers || extensionMethodsInCollectionInitializers)
		{
			return LanguageVersion.CSharp6;
		}
		if (asyncAwait)
		{
			return LanguageVersion.CSharp5;
		}
		if (dynamic || namedArguments || optionalArguments)
		{
			return LanguageVersion.CSharp4;
		}
		if (anonymousTypes || objectCollectionInitializers || automaticProperties || queryExpressions || expressionTrees)
		{
			return LanguageVersion.CSharp3;
		}
		if (anonymousMethods || liftNullables || yieldReturn || useImplicitMethodGroupConversion)
		{
			return LanguageVersion.CSharp2;
		}
		return LanguageVersion.CSharp1;
	}

	protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		if (this.m_PropertyChanged != null)
		{
			this.m_PropertyChanged.Invoke((object)this, new PropertyChangedEventArgs(propertyName));
		}
	}

	public DecompilerSettings Clone()
	{
		DecompilerSettings decompilerSettings = (DecompilerSettings)MemberwiseClone();
		if (csharpFormattingOptions != null)
		{
			decompilerSettings.csharpFormattingOptions = csharpFormattingOptions.Clone();
		}
		decompilerSettings.m_PropertyChanged = null;
		return decompilerSettings;
	}
}
