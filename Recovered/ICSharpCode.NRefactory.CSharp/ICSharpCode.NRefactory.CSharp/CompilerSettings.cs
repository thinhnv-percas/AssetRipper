using ICSharpCode.NRefactory.MonoCSharp;
using ICSharpCode.NRefactory.TypeSystem.Implementation;
using System;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.CSharp
{
	[Serializable]
	public class CompilerSettings : AbstractFreezable
	{
		private bool allowUnsafeBlocks = true;

		private bool checkForOverflow;

		private Version languageVersion = new Version(6, 0);

		private IList<string> conditionalSymbols = new List<string>();

		private bool treatWarningsAsErrors;

		private IList<int> specificWarningsAsErrors = new List<int>();

		private int warningLevel = 4;

		private IList<int> disabledWarnings = new List<int>();

		public bool AllowUnsafeBlocks
		{
			get
			{
				return allowUnsafeBlocks;
			}
			set
			{
				FreezableHelper.ThrowIfFrozen(this);
				allowUnsafeBlocks = value;
			}
		}

		public bool CheckForOverflow
		{
			get
			{
				return checkForOverflow;
			}
			set
			{
				checkForOverflow = value;
			}
		}

		public Version LanguageVersion
		{
			get
			{
				return languageVersion;
			}
			set
			{
				FreezableHelper.ThrowIfFrozen(this);
				if (value == null)
				{
					throw new ArgumentNullException();
				}
				languageVersion = value;
			}
		}

		public IList<string> ConditionalSymbols => conditionalSymbols;

		public bool TreatWarningsAsErrors
		{
			get
			{
				return treatWarningsAsErrors;
			}
			set
			{
				FreezableHelper.ThrowIfFrozen(this);
				treatWarningsAsErrors = value;
			}
		}

		public IList<int> SpecificWarningsAsErrors => specificWarningsAsErrors;

		public int WarningLevel
		{
			get
			{
				return warningLevel;
			}
			set
			{
				FreezableHelper.ThrowIfFrozen(this);
				warningLevel = value;
			}
		}

		public IList<int> DisabledWarnings => disabledWarnings;

		protected override void FreezeInternal()
		{
			conditionalSymbols = FreezableHelper.FreezeList(conditionalSymbols);
			specificWarningsAsErrors = FreezableHelper.FreezeList(specificWarningsAsErrors);
			disabledWarnings = FreezableHelper.FreezeList(disabledWarnings);
			base.FreezeInternal();
		}

		internal ICSharpCode.NRefactory.MonoCSharp.CompilerSettings ToMono()
		{
			ICSharpCode.NRefactory.MonoCSharp.CompilerSettings compilerSettings = new ICSharpCode.NRefactory.MonoCSharp.CompilerSettings();
			compilerSettings.Unsafe = allowUnsafeBlocks;
			compilerSettings.Checked = checkForOverflow;
			compilerSettings.Version = (LanguageVersion)languageVersion.Major;
			compilerSettings.WarningsAreErrors = treatWarningsAsErrors;
			compilerSettings.WarningLevel = warningLevel;
			foreach (int disabledWarning in disabledWarnings)
			{
				compilerSettings.SetIgnoreWarning(disabledWarning);
			}
			foreach (int specificWarningsAsError in specificWarningsAsErrors)
			{
				compilerSettings.AddWarningAsError(specificWarningsAsError);
			}
			foreach (string conditionalSymbol in conditionalSymbols)
			{
				compilerSettings.AddConditionalSymbol(conditionalSymbol);
			}
			return compilerSettings;
		}
	}
}
