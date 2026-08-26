using ICSharpCode.NRefactory.CSharp;
using System;
using System.ComponentModel;

namespace ICSharpCode.Decompiler
{
	public class DecompilerSettings : INotifyPropertyChanged
	{
		private bool anonymousMethods = true;

		private bool expressionTrees = true;

		private bool compillerTypeGenerated_Clear;

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

		private bool useDebugSymbols = true;

		private bool objectCollectionInitializers = true;

		private bool showXmlDocumentation = true;

		private bool foldBraces;

		private bool introduceIncrementAndDecrement = true;

		private bool makeAssignmentExpressions = true;

		private bool alwaysGenerateExceptionVariableForCatchBlocks;

		private CSharpFormattingOptions csharpFormattingOptions;

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

		public bool CompillerTypeGenerated_Clear
		{
			get
			{
				return compillerTypeGenerated_Clear;
			}
			set
			{
				if (compillerTypeGenerated_Clear != value)
				{
					compillerTypeGenerated_Clear = value;
					OnPropertyChanged("CompillerTypeGenerated_Clear");
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
					OnPropertyChanged("ObjectCollectionInitializers");
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

		public bool AlwaysGenerateExceptionVariableForCatchBlocks
		{
			get
			{
				return alwaysGenerateExceptionVariableForCatchBlocks;
			}
			set
			{
				if (alwaysGenerateExceptionVariableForCatchBlocks != value)
				{
					alwaysGenerateExceptionVariableForCatchBlocks = value;
					OnPropertyChanged("AlwaysGenerateExceptionVariableForCatchBlocks");
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

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public DecompilerSettings Clone()
		{
			DecompilerSettings decompilerSettings = (DecompilerSettings)MemberwiseClone();
			if (csharpFormattingOptions != null)
			{
				decompilerSettings.csharpFormattingOptions = csharpFormattingOptions.Clone();
			}
			decompilerSettings.PropertyChanged = null;
			return decompilerSettings;
		}
	}
}
