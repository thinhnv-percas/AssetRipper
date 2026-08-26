using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using ICSharpCode.NRefactory.CSharp;

namespace ICSharpCode.Decompiler;

public class DecompilerSettings : INotifyPropertyChanged, IEquatable<DecompilerSettings>
{
	private DecompilationObject[] decompilationObjects = new DecompilationObject[5]
	{
		DecompilationObject.Methods,
		DecompilationObject.Properties,
		DecompilationObject.Events,
		DecompilationObject.Fields,
		DecompilationObject.NestedTypes
	};

	private static string DecompilationObject_format = "DecompilationObject0".Substring(0, "DecompilationObject0".Length - 1) + "{0}";

	private bool anonymousMethods = true;

	private bool expressionTrees = true;

	private bool yieldReturn = true;

	private bool asyncAwait = true;

	private bool automaticProperties = true;

	private bool automaticEvents = true;

	private bool usingStatement = true;

	private bool forEachStatement = true;

	private bool lockStatement = true;

	private bool switchStatementOnString = true;

	private bool usingDeclarations = true;

	private bool queryExpressions = true;

	private bool fullyQualifyAmbiguousTypeNames = true;

	private bool fullyQualifyAllTypes;

	private bool useDebugSymbols = true;

	private bool objectCollectionInitializers = true;

	private bool showXmlDocumentation = true;

	private bool removeEmptyDefaultConstructors = true;

	private bool introduceIncrementAndDecrement = true;

	private bool makeAssignmentExpressions = true;

	private bool alwaysGenerateExceptionVariableForCatchBlocksUnlessTypeIsObject;

	private bool showTokenAndRvaComments = true;

	private bool sortMembers;

	private bool forceShowAllMembers;

	private bool sortSystemUsingStatementsFirst = true;

	private int maxArrayElements = 10000;

	private bool sortCustomAttributes;

	private bool useSourceCodeOrder = true;

	private bool allowFieldInitializers = true;

	private bool oneCustomAttributePerLine = true;

	private bool typeAddInternalModifier = true;

	private bool memberAddPrivateModifier = true;

	private bool removeNewDelegateClass = true;

	private CSharpFormattingOptions csharpFormattingOptions;

	private volatile int settingsVersion;

	public IEnumerable<DecompilationObject> DecompilationObjects => decompilationObjects.AsEnumerable();

	public DecompilationObject DecompilationObject0
	{
		get
		{
			return decompilationObjects[0];
		}
		set
		{
			SetDecompilationObject(0, value);
		}
	}

	public DecompilationObject DecompilationObject1
	{
		get
		{
			return decompilationObjects[1];
		}
		set
		{
			SetDecompilationObject(1, value);
		}
	}

	public DecompilationObject DecompilationObject2
	{
		get
		{
			return decompilationObjects[2];
		}
		set
		{
			SetDecompilationObject(2, value);
		}
	}

	public DecompilationObject DecompilationObject3
	{
		get
		{
			return decompilationObjects[3];
		}
		set
		{
			SetDecompilationObject(3, value);
		}
	}

	public DecompilationObject DecompilationObject4
	{
		get
		{
			return decompilationObjects[4];
		}
		set
		{
			SetDecompilationObject(4, value);
		}
	}

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

	public bool FullyQualifyAmbiguousTypeNames
	{
		get
		{
			return fullyQualifyAmbiguousTypeNames;
		}
		set
		{
			if (fullyQualifyAmbiguousTypeNames != value)
			{
				fullyQualifyAmbiguousTypeNames = value;
				OnPropertyChanged("FullyQualifyAmbiguousTypeNames");
			}
		}
	}

	public bool FullyQualifyAllTypes
	{
		get
		{
			return fullyQualifyAllTypes;
		}
		set
		{
			if (fullyQualifyAllTypes != value)
			{
				fullyQualifyAllTypes = value;
				OnPropertyChanged("FullyQualifyAllTypes");
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

	public bool RemoveEmptyDefaultConstructors
	{
		get
		{
			return removeEmptyDefaultConstructors;
		}
		set
		{
			if (removeEmptyDefaultConstructors != value)
			{
				removeEmptyDefaultConstructors = value;
				OnPropertyChanged("RemoveEmptyDefaultConstructors");
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

	public bool AlwaysGenerateExceptionVariableForCatchBlocksUnlessTypeIsObject
	{
		get
		{
			return alwaysGenerateExceptionVariableForCatchBlocksUnlessTypeIsObject;
		}
		set
		{
			if (alwaysGenerateExceptionVariableForCatchBlocksUnlessTypeIsObject != value)
			{
				alwaysGenerateExceptionVariableForCatchBlocksUnlessTypeIsObject = value;
				OnPropertyChanged("AlwaysGenerateExceptionVariableForCatchBlocksUnlessTypeIsObject");
			}
		}
	}

	public bool ShowTokenAndRvaComments
	{
		get
		{
			return showTokenAndRvaComments;
		}
		set
		{
			if (showTokenAndRvaComments != value)
			{
				showTokenAndRvaComments = value;
				OnPropertyChanged("ShowTokenAndRvaComments");
			}
		}
	}

	public bool SortMembers
	{
		get
		{
			return sortMembers;
		}
		set
		{
			if (sortMembers != value)
			{
				sortMembers = value;
				OnPropertyChanged("SortMembers");
			}
		}
	}

	public bool ForceShowAllMembers
	{
		get
		{
			return forceShowAllMembers;
		}
		set
		{
			if (forceShowAllMembers != value)
			{
				forceShowAllMembers = value;
				OnPropertyChanged("ForceShowAllMembers");
			}
		}
	}

	public bool SortSystemUsingStatementsFirst
	{
		get
		{
			return sortSystemUsingStatementsFirst;
		}
		set
		{
			if (sortSystemUsingStatementsFirst != value)
			{
				sortSystemUsingStatementsFirst = value;
				OnPropertyChanged("SortSystemUsingStatementsFirst");
			}
		}
	}

	public int MaxArrayElements
	{
		get
		{
			return maxArrayElements;
		}
		set
		{
			if (maxArrayElements != value)
			{
				maxArrayElements = value;
				OnPropertyChanged("MaxArrayElements");
			}
		}
	}

	public bool SortCustomAttributes
	{
		get
		{
			return sortCustomAttributes;
		}
		set
		{
			if (sortCustomAttributes != value)
			{
				sortCustomAttributes = value;
				OnPropertyChanged("SortCustomAttributes");
			}
		}
	}

	public bool UseSourceCodeOrder
	{
		get
		{
			return useSourceCodeOrder;
		}
		set
		{
			if (useSourceCodeOrder != value)
			{
				useSourceCodeOrder = value;
				OnPropertyChanged("UseSourceCodeOrder");
			}
		}
	}

	public bool AllowFieldInitializers
	{
		get
		{
			return allowFieldInitializers;
		}
		set
		{
			if (allowFieldInitializers != value)
			{
				allowFieldInitializers = value;
				OnPropertyChanged("AllowFieldInitializers");
			}
		}
	}

	public bool OneCustomAttributePerLine
	{
		get
		{
			return oneCustomAttributePerLine;
		}
		set
		{
			if (oneCustomAttributePerLine != value)
			{
				oneCustomAttributePerLine = value;
				OnPropertyChanged("OneCustomAttributePerLine");
			}
		}
	}

	public bool TypeAddInternalModifier
	{
		get
		{
			return typeAddInternalModifier;
		}
		set
		{
			if (typeAddInternalModifier != value)
			{
				typeAddInternalModifier = value;
				OnPropertyChanged("TypeAddInternalModifier");
			}
		}
	}

	public bool MemberAddPrivateModifier
	{
		get
		{
			return memberAddPrivateModifier;
		}
		set
		{
			if (memberAddPrivateModifier != value)
			{
				memberAddPrivateModifier = value;
				OnPropertyChanged("MemberAddPrivateModifier");
			}
		}
	}

	public bool RemoveNewDelegateClass
	{
		get
		{
			return removeNewDelegateClass;
		}
		set
		{
			if (removeNewDelegateClass != value)
			{
				removeNewDelegateClass = value;
				OnPropertyChanged("RemoveNewDelegateClass");
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

	public int SettingsVersion => settingsVersion;

	public event PropertyChangedEventHandler PropertyChanged;

	public event EventHandler SettingsVersionChanged;

	protected virtual void OnModified()
	{
	}

	private void SetDecompilationObject(int index, DecompilationObject newValue)
	{
		if (decompilationObjects[index] != newValue)
		{
			int num = Array.IndexOf(decompilationObjects, newValue);
			if (num >= 0)
			{
				decompilationObjects[num] = decompilationObjects[index];
				decompilationObjects[index] = newValue;
				OnPropertyChanged(string.Format(DecompilationObject_format, num));
			}
			OnPropertyChanged(string.Format(DecompilationObject_format, index));
		}
	}

	protected virtual void OnPropertyChanged(string propertyName)
	{
		Interlocked.Increment(ref settingsVersion);
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		OnModified();
		SettingsVersionChanged?.Invoke(this, EventArgs.Empty);
	}

	public DecompilerSettings Clone()
	{
		return CopyTo(new DecompilerSettings());
	}

	public bool Equals(DecompilerSettings other)
	{
		if (other == null)
		{
			return false;
		}
		if (AnonymousMethods != other.AnonymousMethods)
		{
			return false;
		}
		if (ExpressionTrees != other.ExpressionTrees)
		{
			return false;
		}
		if (YieldReturn != other.YieldReturn)
		{
			return false;
		}
		if (AsyncAwait != other.AsyncAwait)
		{
			return false;
		}
		if (AutomaticProperties != other.AutomaticProperties)
		{
			return false;
		}
		if (AutomaticEvents != other.AutomaticEvents)
		{
			return false;
		}
		if (UsingStatement != other.UsingStatement)
		{
			return false;
		}
		if (ForEachStatement != other.ForEachStatement)
		{
			return false;
		}
		if (LockStatement != other.LockStatement)
		{
			return false;
		}
		if (SwitchStatementOnString != other.SwitchStatementOnString)
		{
			return false;
		}
		if (UsingDeclarations != other.UsingDeclarations)
		{
			return false;
		}
		if (QueryExpressions != other.QueryExpressions)
		{
			return false;
		}
		if (FullyQualifyAmbiguousTypeNames != other.FullyQualifyAmbiguousTypeNames)
		{
			return false;
		}
		if (FullyQualifyAllTypes != other.FullyQualifyAllTypes)
		{
			return false;
		}
		if (UseDebugSymbols != other.UseDebugSymbols)
		{
			return false;
		}
		if (ObjectOrCollectionInitializers != other.ObjectOrCollectionInitializers)
		{
			return false;
		}
		if (ShowXmlDocumentation != other.ShowXmlDocumentation)
		{
			return false;
		}
		if (RemoveEmptyDefaultConstructors != other.RemoveEmptyDefaultConstructors)
		{
			return false;
		}
		if (IntroduceIncrementAndDecrement != other.IntroduceIncrementAndDecrement)
		{
			return false;
		}
		if (MakeAssignmentExpressions != other.MakeAssignmentExpressions)
		{
			return false;
		}
		if (AlwaysGenerateExceptionVariableForCatchBlocksUnlessTypeIsObject != other.AlwaysGenerateExceptionVariableForCatchBlocksUnlessTypeIsObject)
		{
			return false;
		}
		if (ShowTokenAndRvaComments != other.ShowTokenAndRvaComments)
		{
			return false;
		}
		if (DecompilationObject0 != other.DecompilationObject0)
		{
			return false;
		}
		if (DecompilationObject1 != other.DecompilationObject1)
		{
			return false;
		}
		if (DecompilationObject2 != other.DecompilationObject2)
		{
			return false;
		}
		if (DecompilationObject3 != other.DecompilationObject3)
		{
			return false;
		}
		if (DecompilationObject4 != other.DecompilationObject4)
		{
			return false;
		}
		if (SortMembers != other.SortMembers)
		{
			return false;
		}
		if (ForceShowAllMembers != other.ForceShowAllMembers)
		{
			return false;
		}
		if (SortSystemUsingStatementsFirst != other.SortSystemUsingStatementsFirst)
		{
			return false;
		}
		if (MaxArrayElements != other.MaxArrayElements)
		{
			return false;
		}
		if (SortCustomAttributes != other.SortCustomAttributes)
		{
			return false;
		}
		if (UseSourceCodeOrder != other.UseSourceCodeOrder)
		{
			return false;
		}
		if (AllowFieldInitializers != other.AllowFieldInitializers)
		{
			return false;
		}
		if (OneCustomAttributePerLine != other.OneCustomAttributePerLine)
		{
			return false;
		}
		if (TypeAddInternalModifier != other.TypeAddInternalModifier)
		{
			return false;
		}
		if (MemberAddPrivateModifier != other.MemberAddPrivateModifier)
		{
			return false;
		}
		if (RemoveNewDelegateClass != other.RemoveNewDelegateClass)
		{
			return false;
		}
		return true;
	}

	public override bool Equals(object obj)
	{
		return Equals(obj as DecompilerSettings);
	}

	public override int GetHashCode()
	{
		uint num = 0u;
		num ^= (uint)((!AnonymousMethods) ? int.MinValue : 0);
		num ^= (uint)((!ExpressionTrees) ? 1073741824 : 0);
		num ^= (uint)((!YieldReturn) ? 536870912 : 0);
		num ^= (uint)((!AsyncAwait) ? 268435456 : 0);
		num ^= (uint)((!AutomaticProperties) ? 134217728 : 0);
		num ^= (uint)((!AutomaticEvents) ? 67108864 : 0);
		num ^= (uint)((!UsingStatement) ? 33554432 : 0);
		num ^= (uint)((!ForEachStatement) ? 16777216 : 0);
		num ^= (uint)((!LockStatement) ? 8388608 : 0);
		num ^= (uint)((!SwitchStatementOnString) ? 4194304 : 0);
		num ^= (uint)((!UsingDeclarations) ? 2097152 : 0);
		num ^= (uint)((!QueryExpressions) ? 1048576 : 0);
		num ^= (uint)((!FullyQualifyAmbiguousTypeNames) ? 524288 : 0);
		num ^= (uint)((!UseDebugSymbols) ? 262144 : 0);
		num ^= (uint)((!ObjectOrCollectionInitializers) ? 131072 : 0);
		num ^= (uint)((!ShowXmlDocumentation) ? 65536 : 0);
		num ^= (uint)((!IntroduceIncrementAndDecrement) ? 32768 : 0);
		num ^= (uint)((!MakeAssignmentExpressions) ? 16384 : 0);
		num ^= (uint)((!AlwaysGenerateExceptionVariableForCatchBlocksUnlessTypeIsObject) ? 8192 : 0);
		num ^= (uint)((!RemoveEmptyDefaultConstructors) ? 4096 : 0);
		num ^= (uint)((!ShowTokenAndRvaComments) ? 2048 : 0);
		num ^= (uint)((!SortMembers) ? 1024 : 0);
		num ^= (uint)((!ForceShowAllMembers) ? 512 : 0);
		num ^= (uint)((!SortSystemUsingStatementsFirst) ? 256 : 0);
		num ^= (uint)((!FullyQualifyAllTypes) ? 128 : 0);
		num ^= (uint)((!SortCustomAttributes) ? 64 : 0);
		num ^= (uint)((!UseSourceCodeOrder) ? 32 : 0);
		num ^= (uint)((!AllowFieldInitializers) ? 16 : 0);
		num ^= (uint)((!OneCustomAttributePerLine) ? 8 : 0);
		num ^= (uint)((!TypeAddInternalModifier) ? 4 : 0);
		num ^= (uint)((!MemberAddPrivateModifier) ? 2 : 0);
		num ^= ((!RemoveNewDelegateClass) ? 1u : 0u);
		for (int i = 0; i < decompilationObjects.Length; i++)
		{
			num ^= (uint)((int)decompilationObjects[i] << i * 8);
		}
		return (int)num ^ MaxArrayElements;
	}

	public DecompilerSettings CopyTo(DecompilerSettings other)
	{
		other.DecompilationObject0 = DecompilationObject0;
		other.DecompilationObject1 = DecompilationObject1;
		other.DecompilationObject2 = DecompilationObject2;
		other.DecompilationObject3 = DecompilationObject3;
		other.DecompilationObject4 = DecompilationObject4;
		other.AnonymousMethods = AnonymousMethods;
		other.ExpressionTrees = ExpressionTrees;
		other.YieldReturn = YieldReturn;
		other.AsyncAwait = AsyncAwait;
		other.AutomaticProperties = AutomaticProperties;
		other.AutomaticEvents = AutomaticEvents;
		other.UsingStatement = UsingStatement;
		other.ForEachStatement = ForEachStatement;
		other.LockStatement = LockStatement;
		other.SwitchStatementOnString = SwitchStatementOnString;
		other.UsingDeclarations = UsingDeclarations;
		other.QueryExpressions = QueryExpressions;
		other.FullyQualifyAmbiguousTypeNames = FullyQualifyAmbiguousTypeNames;
		other.FullyQualifyAllTypes = FullyQualifyAllTypes;
		other.UseDebugSymbols = UseDebugSymbols;
		other.ObjectOrCollectionInitializers = ObjectOrCollectionInitializers;
		other.ShowXmlDocumentation = ShowXmlDocumentation;
		other.RemoveEmptyDefaultConstructors = RemoveEmptyDefaultConstructors;
		other.IntroduceIncrementAndDecrement = IntroduceIncrementAndDecrement;
		other.MakeAssignmentExpressions = MakeAssignmentExpressions;
		other.AlwaysGenerateExceptionVariableForCatchBlocksUnlessTypeIsObject = AlwaysGenerateExceptionVariableForCatchBlocksUnlessTypeIsObject;
		other.ShowTokenAndRvaComments = ShowTokenAndRvaComments;
		other.SortMembers = SortMembers;
		other.ForceShowAllMembers = ForceShowAllMembers;
		other.SortSystemUsingStatementsFirst = SortSystemUsingStatementsFirst;
		other.MaxArrayElements = MaxArrayElements;
		other.SortCustomAttributes = SortCustomAttributes;
		other.UseSourceCodeOrder = UseSourceCodeOrder;
		other.AllowFieldInitializers = AllowFieldInitializers;
		other.OneCustomAttributePerLine = OneCustomAttributePerLine;
		other.TypeAddInternalModifier = TypeAddInternalModifier;
		other.MemberAddPrivateModifier = MemberAddPrivateModifier;
		other.RemoveNewDelegateClass = RemoveNewDelegateClass;
		return other;
	}
}
