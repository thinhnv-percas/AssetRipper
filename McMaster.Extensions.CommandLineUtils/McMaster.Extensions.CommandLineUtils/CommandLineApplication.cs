using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils.Abstractions;
using McMaster.Extensions.CommandLineUtils.Conventions;
using McMaster.Extensions.CommandLineUtils.HelpText;
using McMaster.Extensions.CommandLineUtils.Internal;
using McMaster.Extensions.CommandLineUtils.Validation;

namespace McMaster.Extensions.CommandLineUtils;

public class CommandLineApplication : IServiceProvider, IDisposable
{
	private sealed class Builder : IConventionBuilder
	{
		private readonly CommandLineApplication _app;

		public Builder(CommandLineApplication app)
		{
			_app = app;
		}

		IConventionBuilder IConventionBuilder.AddConvention(IConvention convention)
		{
			convention.Apply(_app._conventionContext);
			foreach (CommandLineApplication command in _app.Commands)
			{
				command.Conventions.AddConvention(convention);
			}
			_app._conventions.Add(convention);
			return _app.Conventions;
		}
	}

	private sealed class ServiceProvider : IServiceProvider
	{
		private readonly CommandLineApplication _parent;

		public ServiceProvider(CommandLineApplication parent)
		{
			_parent = parent;
		}

		public object GetService(Type serviceType)
		{
			if (typeof(object) == serviceType)
			{
				return null;
			}
			if (serviceType == typeof(CommandLineApplication))
			{
				return _parent;
			}
			if (serviceType == _parent.GetType())
			{
				return _parent;
			}
			if (serviceType == typeof(IEnumerable<CommandOption>))
			{
				return _parent.GetOptions();
			}
			if (serviceType == typeof(IEnumerable<CommandArgument>))
			{
				return _parent.Arguments;
			}
			if (serviceType == typeof(CommandLineContext))
			{
				return _parent._context;
			}
			if (serviceType == typeof(IServiceProvider))
			{
				return this;
			}
			if (_parent.Parent is IModelAccessor modelAccessor && serviceType == modelAccessor.GetModelType())
			{
				return modelAccessor.GetModel();
			}
			if (_parent.AdditionalServices != null)
			{
				object service = _parent.AdditionalServices.GetService(serviceType);
				if (service != null)
				{
					return service;
				}
			}
			if (serviceType == typeof(IConsole))
			{
				return _parent._context.Console;
			}
			return null;
		}
	}

	private const int HelpExitCode = 0;

	internal const int ValidationErrorExitCode = 1;

	private List<Action<ParseResult>> _onParsingComplete;

	internal readonly Dictionary<string, PropertyInfo> _shortOptions = new Dictionary<string, PropertyInfo>();

	internal readonly Dictionary<string, PropertyInfo> _longOptions = new Dictionary<string, PropertyInfo>();

	private readonly HashSet<string> _names = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

	private string _primaryCommandName;

	internal CommandLineContext _context;

	private IHelpTextGenerator _helpTextGenerator;

	private CommandOption _optionHelp;

	private readonly Lazy<IServiceProvider> _services;

	private readonly ConventionContext _conventionContext;

	private readonly List<IConvention> _conventions = new List<IConvention>();

	private bool? _clusterOptions;

	private IConventionBuilder _builder;

	private bool _settingContext;

	private Func<ValidationResult, int> _validationErrorHandler;

	public CommandLineApplication Parent { get; set; }

	public IHelpTextGenerator HelpTextGenerator
	{
		get
		{
			return _helpTextGenerator;
		}
		set
		{
			_helpTextGenerator = value ?? throw new ArgumentNullException("value");
		}
	}

	public string Name
	{
		get
		{
			return _primaryCommandName;
		}
		set
		{
			Parent?.AssertCommandNameIsUnique(value, this);
			_primaryCommandName = value;
		}
	}

	public string FullName { get; set; }

	public string Description { get; set; }

	public bool ShowInHelpText { get; set; } = true;

	public string ExtendedHelpText { get; set; }

	public List<CommandOption> Options { get; private set; }

	public bool UsePagerForHelpText { get; set; } = true;

	public IEnumerable<string> Names
	{
		get
		{
			if (!string.IsNullOrEmpty(Name))
			{
				yield return Name;
			}
			foreach (string name in _names)
			{
				yield return name;
			}
		}
	}

	public CommandOption OptionHelp
	{
		get
		{
			if (_optionHelp != null)
			{
				return _optionHelp;
			}
			CommandLineApplication parent = Parent;
			if (parent != null && parent.OptionHelp?.Inherited == true)
			{
				return Parent.OptionHelp;
			}
			return null;
		}
		internal set
		{
			_optionHelp = value;
		}
	}

	public CommandOption OptionVersion { get; internal set; }

	public List<CommandArgument> Arguments { get; private set; }

	public List<string> RemainingArguments { get; private set; }

	public bool ThrowOnUnexpectedArgument { get; set; }

	public bool IsShowingInformation { get; protected set; }

	public Func<int> Invoke { get; set; }

	public Func<string> LongVersionGetter { get; set; }

	public Func<string> ShortVersionGetter { get; set; }

	public List<CommandLineApplication> Commands { get; private set; }

	public bool AllowArgumentSeparator { get; set; }

	public ResponseFileHandling ResponseFileHandling { get; set; }

	public StringComparison OptionsComparison { get; set; }

	public bool ClusterOptions
	{
		get
		{
			return _clusterOptions ?? true;
		}
		set
		{
			_clusterOptions = value;
		}
	}

	internal bool ClusterOptionsWasSetExplicitly => _clusterOptions.HasValue;

	public ValueParserProvider ValueParsers { get; private set; }

	public string WorkingDirectory => _context.WorkingDirectory;

	public TextWriter Out { get; set; }

	public TextWriter Error { get; set; }

	public bool MakeSuggestionsInErrorMessage { get; set; } = true;

	public IConventionBuilder Conventions
	{
		get
		{
			if (_builder == null)
			{
				_builder = new Builder(this);
			}
			return _builder;
		}
	}

	internal IServiceProvider AdditionalServices { get; set; }

	public Func<ValidationResult, int> ValidationErrorHandler
	{
		get
		{
			return _validationErrorHandler;
		}
		set
		{
			_validationErrorHandler = value ?? throw new ArgumentNullException("value");
		}
	}

	public ICollection<ICommandValidator> Validators { get; } = new List<ICommandValidator>();

	public CommandLineApplication(bool throwOnUnexpectedArg = true)
		: this(null, DefaultHelpTextGenerator.Singleton, new DefaultCommandLineContext(), throwOnUnexpectedArg)
	{
	}

	public CommandLineApplication(IConsole console)
		: this(null, DefaultHelpTextGenerator.Singleton, new DefaultCommandLineContext(console), throwOnUnexpectedArg: true)
	{
	}

	public CommandLineApplication(IConsole console, string workingDirectory, bool throwOnUnexpectedArg)
		: this(null, DefaultHelpTextGenerator.Singleton, new DefaultCommandLineContext(console, workingDirectory), throwOnUnexpectedArg)
	{
	}

	public CommandLineApplication(IHelpTextGenerator helpTextGenerator, IConsole console, string workingDirectory, bool throwOnUnexpectedArg)
		: this(null, helpTextGenerator, new DefaultCommandLineContext(console, workingDirectory), throwOnUnexpectedArg)
	{
	}

	internal CommandLineApplication(CommandLineApplication parent, string name, bool throwOnUnexpectedArg)
		: this(parent, parent._helpTextGenerator, parent._context, throwOnUnexpectedArg)
	{
		if (name != null)
		{
			Name = name;
		}
	}

	internal CommandLineApplication(CommandLineApplication parent, IHelpTextGenerator helpTextGenerator, CommandLineContext context, bool throwOnUnexpectedArg)
	{
		_context = context ?? throw new ArgumentNullException("context");
		Parent = parent;
		ThrowOnUnexpectedArgument = throwOnUnexpectedArg;
		Options = new List<CommandOption>();
		Arguments = new List<CommandArgument>();
		Commands = new List<CommandLineApplication>();
		RemainingArguments = new List<string>();
		HelpTextGenerator = helpTextGenerator;
		Invoke = () => 0;
		ValidationErrorHandler = DefaultValidationErrorHandler;
		SetContext(context);
		_services = new Lazy<IServiceProvider>(() => new ServiceProvider(this));
		ValueParsers = parent?.ValueParsers ?? new ValueParserProvider();
		_clusterOptions = parent?._clusterOptions;
		_conventionContext = CreateConventionContext();
		if (Parent == null)
		{
			return;
		}
		foreach (IConvention convention in Parent._conventions)
		{
			Conventions.AddConvention(convention);
		}
	}

	public IEnumerable<CommandOption> GetOptions()
	{
		IEnumerable<CommandOption> enumerable = Options.AsEnumerable();
		CommandLineApplication commandLineApplication = this;
		while (commandLineApplication.Parent != null)
		{
			commandLineApplication = commandLineApplication.Parent;
			enumerable = enumerable.Concat(commandLineApplication.Options.Where((CommandOption o) => o.Inherited));
		}
		return enumerable;
	}

	public void AddName(string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			throw new ArgumentException("Value cannot be null or empty.", "name");
		}
		Parent?.AssertCommandNameIsUnique(name, this);
		_names.Add(name);
	}

	public void AddSubcommand(CommandLineApplication subcommand)
	{
		if (subcommand == null)
		{
			throw new ArgumentNullException("subcommand");
		}
		foreach (string name in subcommand.Names)
		{
			AssertCommandNameIsUnique(name, null);
		}
		Commands.Add(subcommand);
	}

	private void AssertCommandNameIsUnique(string name, CommandLineApplication skip)
	{
		if (string.IsNullOrEmpty(name))
		{
			return;
		}
		foreach (CommandLineApplication command in Commands)
		{
			if (command != skip && command.MatchesName(name))
			{
				throw new InvalidOperationException(Strings.DuplicateSubcommandName(name));
			}
		}
	}

	public CommandLineApplication Command(string name, Action<CommandLineApplication> configuration, bool throwOnUnexpectedArg = true)
	{
		CommandLineApplication commandLineApplication = new CommandLineApplication(this, name, throwOnUnexpectedArg);
		AddSubcommand(commandLineApplication);
		configuration?.Invoke(commandLineApplication);
		return commandLineApplication;
	}

	public CommandLineApplication<TModel> Command<TModel>(string name, Action<CommandLineApplication<TModel>> configuration, bool throwOnUnexpectedArg = true) where TModel : class
	{
		CommandLineApplication<TModel> commandLineApplication = new CommandLineApplication<TModel>(this, name, throwOnUnexpectedArg);
		AddSubcommand(commandLineApplication);
		configuration?.Invoke(commandLineApplication);
		return commandLineApplication;
	}

	public CommandOption Option(string template, string description, CommandOptionType optionType)
	{
		return Option(template, description, optionType, delegate
		{
		}, inherited: false);
	}

	public CommandOption Option(string template, string description, CommandOptionType optionType, bool inherited)
	{
		return Option(template, description, optionType, delegate
		{
		}, inherited);
	}

	public CommandOption Option(string template, string description, CommandOptionType optionType, Action<CommandOption> configuration)
	{
		return Option(template, description, optionType, configuration, inherited: false);
	}

	public CommandOption Option(string template, string description, CommandOptionType optionType, Action<CommandOption> configuration, bool inherited)
	{
		CommandOption commandOption = new CommandOption(template, optionType)
		{
			Description = description,
			Inherited = inherited
		};
		Options.Add(commandOption);
		configuration(commandOption);
		return commandOption;
	}

	public CommandOption<T> Option<T>(string template, string description, CommandOptionType optionType, Action<CommandOption> configuration, bool inherited)
	{
		CommandOption<T> commandOption = new CommandOption<T>(ValueParsers.GetParser<T>() ?? throw new InvalidOperationException(Strings.CannotDetermineParserType(typeof(T))), template, optionType)
		{
			Description = description,
			Inherited = inherited
		};
		Options.Add(commandOption);
		configuration(commandOption);
		return commandOption;
	}

	public CommandArgument Argument(string name, string description, bool multipleValues = false)
	{
		return Argument(name, description, delegate
		{
		}, multipleValues);
	}

	public CommandArgument Argument(string name, string description, Action<CommandArgument> configuration, bool multipleValues = false)
	{
		CommandArgument commandArgument = new CommandArgument
		{
			Name = name,
			Description = description,
			MultipleValues = multipleValues
		};
		AddArgument(commandArgument);
		configuration(commandArgument);
		return commandArgument;
	}

	public CommandArgument<T> Argument<T>(string name, string description, Action<CommandArgument> configuration, bool multipleValues = false)
	{
		CommandArgument<T> commandArgument = new CommandArgument<T>(ValueParsers.GetParser<T>() ?? throw new InvalidOperationException(Strings.CannotDetermineParserType(typeof(T))))
		{
			Name = name,
			Description = description,
			MultipleValues = multipleValues
		};
		AddArgument(commandArgument);
		configuration(commandArgument);
		return commandArgument;
	}

	private void AddArgument(CommandArgument argument)
	{
		CommandArgument commandArgument = Arguments.LastOrDefault();
		if (commandArgument != null && commandArgument.MultipleValues)
		{
			throw new InvalidOperationException(Strings.OnlyLastArgumentCanAllowMultipleValues(commandArgument.Name));
		}
		Arguments.Add(argument);
	}

	public void OnExecute(Func<int> invoke)
	{
		Invoke = invoke;
	}

	public void OnExecute(Func<Task<int>> invoke)
	{
		Invoke = () => invoke().GetAwaiter().GetResult();
	}

	public void OnParsingComplete(Action<ParseResult> action)
	{
		if (action == null)
		{
			throw new ArgumentNullException("action");
		}
		_onParsingComplete = _onParsingComplete ?? new List<Action<ParseResult>>();
		_onParsingComplete.Add(action);
	}

	public ParseResult Parse(params string[] args)
	{
		args = args ?? new string[0];
		ParseResult parseResult = new CommandLineProcessor(this, args).Process();
		parseResult.SelectedCommand.HandleParseResult(parseResult);
		return parseResult;
	}

	protected virtual void HandleParseResult(ParseResult parseResult)
	{
		Parent?.HandleParseResult(parseResult);
		try
		{
			foreach (CommandOption option in Options)
			{
				if (option is IInternalCommandParamOfT internalCommandParamOfT)
				{
					internalCommandParamOfT.Parse(ValueParsers.ParseCulture);
				}
			}
			foreach (CommandArgument argument in Arguments)
			{
				if (argument is IInternalCommandParamOfT internalCommandParamOfT2)
				{
					internalCommandParamOfT2.Parse(ValueParsers.ParseCulture);
				}
			}
			if (_onParsingComplete == null)
			{
				return;
			}
			foreach (Action<ParseResult> item in _onParsingComplete)
			{
				item?.Invoke(parseResult);
			}
		}
		catch (FormatException ex)
		{
			throw new CommandParsingException(this, ex.Message, ex);
		}
	}

	public int Execute(params string[] args)
	{
		CommandLineApplication selectedCommand = Parse(args).SelectedCommand;
		if (selectedCommand.IsShowingInformation)
		{
			return 0;
		}
		ValidationResult validationResult = selectedCommand.GetValidationResult();
		if (validationResult != ValidationResult.Success)
		{
			return selectedCommand.ValidationErrorHandler(validationResult);
		}
		return selectedCommand.Invoke();
	}

	public CommandOption HelpOption(string template)
	{
		return HelpOption(template, inherited: false);
	}

	public CommandOption HelpOption(string template, bool inherited)
	{
		OptionHelp = Option(template, "Show help information", CommandOptionType.NoValue, inherited);
		return OptionHelp;
	}

	public CommandOption VersionOption(string template, string shortFormVersion, string longFormVersion = null)
	{
		if (longFormVersion == null)
		{
			return VersionOption(template, () => shortFormVersion);
		}
		return VersionOption(template, () => shortFormVersion, () => longFormVersion);
	}

	public CommandOption VersionOption(string template, Func<string> shortFormVersionGetter, Func<string> longFormVersionGetter = null)
	{
		OptionVersion = Option(template, "Show version information", CommandOptionType.NoValue);
		ShortVersionGetter = shortFormVersionGetter;
		LongVersionGetter = longFormVersionGetter ?? shortFormVersionGetter;
		return OptionVersion;
	}

	public virtual void ShowHint()
	{
		if (OptionHelp != null)
		{
			string text = ((!string.IsNullOrEmpty(OptionHelp.LongName)) ? ("--" + OptionHelp.LongName) : ((!string.IsNullOrEmpty(OptionHelp.ShortName)) ? ("-" + OptionHelp.LongName) : ("-" + OptionHelp.SymbolName)));
			Out.WriteLine("Specify " + text + " for a list of available options and commands.");
		}
	}

	public void ShowHelp()
	{
		ShowHelp(UsePagerForHelpText);
	}

	public void ShowHelp(bool usePager)
	{
		for (CommandLineApplication commandLineApplication = this; commandLineApplication != null; commandLineApplication = commandLineApplication.Parent)
		{
			commandLineApplication.IsShowingInformation = true;
		}
		if (usePager && Out == _context.Console.Out)
		{
			using (Pager pager = new Pager(_context.Console))
			{
				_helpTextGenerator.Generate(this, pager.Writer);
				return;
			}
		}
		_helpTextGenerator.Generate(this, Out);
	}

	[Obsolete("This method has been marked as obsolete and will be removed in a future version.The recommended replacement is ShowHelp()")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void ShowHelp(string commandName = null)
	{
		if (commandName == null)
		{
			ShowHelp();
		}
		CommandLineApplication commandLineApplication;
		if (commandName == null || string.Equals(Name, commandName, StringComparison.OrdinalIgnoreCase))
		{
			commandLineApplication = this;
		}
		else
		{
			commandLineApplication = Commands.SingleOrDefault((CommandLineApplication cmd) => string.Equals(cmd.Name, commandName, StringComparison.OrdinalIgnoreCase));
			if (commandLineApplication == null)
			{
				commandLineApplication = this;
			}
		}
		commandLineApplication.ShowHelp();
	}

	public virtual string GetHelpText()
	{
		StringBuilder stringBuilder = new StringBuilder();
		_helpTextGenerator.Generate(this, new StringWriter(stringBuilder));
		return stringBuilder.ToString();
	}

	[Obsolete("This method has been marked as obsolete and will be removed in a future version.The recommended replacement is GetHelpText()")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual string GetHelpText(string commandName = null)
	{
		CommandLineApplication commandLineApplication;
		if (commandName == null || string.Equals(Name, commandName, StringComparison.OrdinalIgnoreCase))
		{
			commandLineApplication = this;
		}
		else
		{
			commandLineApplication = Commands.SingleOrDefault((CommandLineApplication cmd) => string.Equals(cmd.Name, commandName, StringComparison.OrdinalIgnoreCase));
			if (commandLineApplication == null)
			{
				commandLineApplication = this;
			}
		}
		return commandLineApplication.GetHelpText();
	}

	public void ShowVersion()
	{
		for (CommandLineApplication commandLineApplication = this; commandLineApplication != null; commandLineApplication = commandLineApplication.Parent)
		{
			commandLineApplication.IsShowingInformation = true;
		}
		Out.Write(GetVersionText());
	}

	public virtual string GetVersionText()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (!string.IsNullOrEmpty(FullName))
		{
			stringBuilder.AppendLine(FullName);
		}
		stringBuilder.AppendLine(LongVersionGetter());
		return stringBuilder.ToString();
	}

	public virtual string GetFullNameAndVersion()
	{
		List<string> source = new List<string>
		{
			FullName,
			ShortVersionGetter?.Invoke()
		};
		return string.Join(" ", source.Where((string i) => !string.IsNullOrEmpty(i)));
	}

	public void ShowRootCommandFullNameAndVersion()
	{
		CommandLineApplication commandLineApplication = this;
		while (commandLineApplication.Parent != null)
		{
			commandLineApplication = commandLineApplication.Parent;
		}
		Out.WriteLine(commandLineApplication.GetFullNameAndVersion());
		Out.WriteLine();
	}

	internal bool MatchesName(string name)
	{
		if (string.Equals(name, Name, StringComparison.OrdinalIgnoreCase))
		{
			return true;
		}
		return _names.Contains(name);
	}

	private protected virtual ConventionContext CreateConventionContext()
	{
		return new ConventionContext(this, null);
	}

	internal void SetContext(CommandLineContext context)
	{
		if (_settingContext)
		{
			return;
		}
		_settingContext = true;
		_context = context;
		Out = context.Console.Out;
		Error = context.Console.Error;
		foreach (CommandLineApplication command in Commands)
		{
			command.SetContext(context);
		}
		_settingContext = false;
	}

	public virtual void Dispose()
	{
		foreach (CommandLineApplication command in Commands)
		{
			IDisposable current;
			if ((current = command) != null)
			{
				current.Dispose();
			}
		}
	}

	object IServiceProvider.GetService(Type serviceType)
	{
		return _services.Value.GetService(serviceType);
	}

	public static int Execute<TApp>(CommandLineContext context) where TApp : class
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (context.Arguments == null)
		{
			throw new ArgumentNullException("context.Arguments");
		}
		if (context.WorkingDirectory == null)
		{
			throw new ArgumentNullException("context.WorkingDirectory");
		}
		if (context.Console == null)
		{
			throw new ArgumentNullException("context.Console");
		}
		try
		{
			using CommandLineApplication<TApp> commandLineApplication = new CommandLineApplication<TApp>();
			commandLineApplication.SetContext(context);
			commandLineApplication.Conventions.UseDefaultConventions();
			return commandLineApplication.Execute(context.Arguments);
		}
		catch (CommandParsingException ex)
		{
			context.Console.Error.WriteLine(ex.Message);
			if (ex is UnrecognizedCommandParsingException ex2 && ex2.NearestMatches.Any())
			{
				context.Console.Error.WriteLine();
				context.Console.Error.WriteLine("Did you mean this?");
				context.Console.Error.WriteLine("    " + ex2.NearestMatches.First());
			}
			return 1;
		}
	}

	public static int Execute<TApp>(params string[] args) where TApp : class
	{
		return Execute<TApp>(PhysicalConsole.Singleton, args);
	}

	public static int Execute<TApp>(IConsole console, params string[] args) where TApp : class
	{
		args = args ?? new string[0];
		return Execute<TApp>(new DefaultCommandLineContext(console, Directory.GetCurrentDirectory(), args));
	}

	public static Task<int> ExecuteAsync<TApp>(params string[] args) where TApp : class
	{
		return ExecuteAsync<TApp>(PhysicalConsole.Singleton, args);
	}

	public static Task<int> ExecuteAsync<TApp>(IConsole console, params string[] args) where TApp : class
	{
		args = args ?? new string[0];
		return ExecuteAsync<TApp>(new DefaultCommandLineContext(console, Directory.GetCurrentDirectory(), args));
	}

	public static Task<int> ExecuteAsync<TApp>(CommandLineContext context) where TApp : class
	{
		return Task.FromResult(Execute<TApp>(context));
	}

	public ValidationResult GetValidationResult()
	{
		if (Parent != null)
		{
			ValidationResult validationResult = Parent.GetValidationResult();
			if (validationResult != ValidationResult.Success)
			{
				return validationResult;
			}
		}
		CommandLineValidationContextFactory commandLineValidationContextFactory = new CommandLineValidationContextFactory(this);
		ValidationContext context = commandLineValidationContextFactory.Create(this);
		foreach (ICommandValidator validator in Validators)
		{
			ValidationResult validationResult2 = validator.GetValidationResult(this, context);
			if (validationResult2 != ValidationResult.Success)
			{
				return validationResult2;
			}
		}
		foreach (CommandArgument argument in Arguments)
		{
			ValidationContext validationContext = commandLineValidationContextFactory.Create(argument);
			if (!string.IsNullOrEmpty(argument.Name))
			{
				validationContext.DisplayName = argument.Name;
				validationContext.MemberName = argument.Name;
			}
			foreach (IArgumentValidator validator2 in argument.Validators)
			{
				ValidationResult validationResult3 = validator2.GetValidationResult(argument, validationContext);
				if (validationResult3 != ValidationResult.Success)
				{
					return validationResult3;
				}
			}
		}
		foreach (CommandOption option in GetOptions())
		{
			ValidationContext validationContext2 = commandLineValidationContextFactory.Create(option);
			string text = null;
			if (option.LongName != null)
			{
				text = "--" + option.LongName;
			}
			if (text == null && option.ShortName != null)
			{
				text = "-" + option.ShortName;
			}
			if (text == null && option.SymbolName != null)
			{
				text = "-" + option.SymbolName;
			}
			if (text == null && option.ValueName != null)
			{
				text = option.ValueName;
			}
			if (!string.IsNullOrEmpty(text))
			{
				validationContext2.DisplayName = text;
				validationContext2.MemberName = text;
			}
			foreach (IOptionValidator validator3 in option.Validators)
			{
				ValidationResult validationResult4 = validator3.GetValidationResult(option, validationContext2);
				if (validationResult4 != ValidationResult.Success)
				{
					return validationResult4;
				}
			}
		}
		return ValidationResult.Success;
	}

	private int DefaultValidationErrorHandler(ValidationResult result)
	{
		_context.Console.ForegroundColor = ConsoleColor.Red;
		_context.Console.Error.WriteLine(result.ErrorMessage);
		_context.Console.ResetColor();
		ShowHint();
		return 1;
	}
}
public class CommandLineApplication<TModel> : CommandLineApplication, IModelAccessor where TModel : class
{
	private Lazy<TModel> _lazy;

	private Func<TModel> _modelFactory = DefaultModelFactory;

	public TModel Model => _lazy.Value;

	public Func<TModel> ModelFactory
	{
		get
		{
			return _modelFactory;
		}
		set
		{
			_modelFactory = value ?? throw new ArgumentNullException("value");
		}
	}

	public CommandLineApplication(bool throwOnUnexpectedArg = true)
		: base(throwOnUnexpectedArg)
	{
		Initialize();
	}

	public CommandLineApplication(IConsole console)
		: base(console)
	{
		Initialize();
	}

	public CommandLineApplication(IConsole console, string workingDirectory, bool throwOnUnexpectedArg)
		: base(console, workingDirectory, throwOnUnexpectedArg)
	{
		Initialize();
	}

	public CommandLineApplication(IHelpTextGenerator helpTextGenerator, IConsole console, string workingDirectory, bool throwOnUnexpectedArg)
		: base(helpTextGenerator, console, workingDirectory, throwOnUnexpectedArg)
	{
		Initialize();
	}

	internal CommandLineApplication(CommandLineApplication parent, string name, bool throwOnUnexpectedArg)
		: base(parent, name, throwOnUnexpectedArg)
	{
		Initialize();
	}

	private void Initialize()
	{
		_lazy = new Lazy<TModel>(CreateModel);
	}

	private static TModel DefaultModelFactory()
	{
		try
		{
			return Activator.CreateInstance<TModel>();
		}
		catch (MissingMethodException innerException)
		{
			throw new MissingParameterlessConstructorException(typeof(TModel), innerException);
		}
	}

	Type IModelAccessor.GetModelType()
	{
		return typeof(TModel);
	}

	object IModelAccessor.GetModel()
	{
		return Model;
	}

	protected virtual TModel CreateModel()
	{
		return ModelFactory();
	}

	protected override void HandleParseResult(ParseResult parseResult)
	{
		((IModelAccessor)this).GetModel();
		base.HandleParseResult(parseResult);
	}

	private protected override ConventionContext CreateConventionContext()
	{
		return new ConventionContext(this, typeof(TModel));
	}

	public override void Dispose()
	{
		if (Model is IDisposable disposable)
		{
			disposable.Dispose();
		}
		base.Dispose();
	}
}
