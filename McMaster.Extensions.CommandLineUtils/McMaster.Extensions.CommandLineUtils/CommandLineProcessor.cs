using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using McMaster.Extensions.CommandLineUtils.Abstractions;

namespace McMaster.Extensions.CommandLineUtils;

internal sealed class CommandLineProcessor
{
	private enum ParameterType
	{
		CommandOrArgument,
		ShortOption,
		LongOption,
		ArgumentSeparator
	}

	[DebuggerDisplay("{Raw} ({Type})")]
	private sealed class Parameter
	{
		public string Raw { get; }

		public string Name { get; }

		public string Value { get; }

		public ParameterType Type { get; }

		public Parameter(string raw)
		{
			Raw = raw;
			Type = GetType(raw);
			if (Type == ParameterType.LongOption || Type == ParameterType.ShortOption)
			{
				string[] array = Raw.Split(new char[2] { ':', '=' }, 2);
				if (array.Length > 1)
				{
					Value = array[1];
				}
				int startIndex = ((Type == ParameterType.ShortOption) ? 1 : 2);
				Name = array[0].Substring(startIndex);
			}
		}

		private static ParameterType GetType(string raw)
		{
			if (string.IsNullOrEmpty(raw) || raw == "-" || raw[0] != '-')
			{
				return ParameterType.CommandOrArgument;
			}
			if (raw[1] != '-')
			{
				return ParameterType.ShortOption;
			}
			if (raw.Length == 2)
			{
				return ParameterType.ArgumentSeparator;
			}
			return ParameterType.LongOption;
		}
	}

	private sealed class ParameterEnumerator : IEnumerator<Parameter>, IDisposable, IEnumerator
	{
		private readonly IEnumerator<string> _rawArgEnumerator;

		private Parameter _current;

		private IEnumerator<string> _rspEnumerator;

		public Parameter Current => _current;

		object IEnumerator.Current => _current;

		public CommandLineApplication CurrentCommand { get; set; }

		public bool DisableResponseFileLoading { get; set; }

		public ParameterEnumerator(IReadOnlyList<string> rawArguments)
		{
			_rawArgEnumerator = rawArguments.GetEnumerator();
		}

		public bool MoveNext()
		{
			if (_rspEnumerator != null)
			{
				if (_rspEnumerator.MoveNext())
				{
					_current = new Parameter(_rspEnumerator.Current);
					return true;
				}
				_rspEnumerator = null;
			}
			if (_rawArgEnumerator.MoveNext())
			{
				if (CurrentCommand.ResponseFileHandling != ResponseFileHandling.Disabled && !DisableResponseFileLoading)
				{
					string current = _rawArgEnumerator.Current;
					if (current != null && current.Length > 1 && current[0] == '@')
					{
						_rspEnumerator = CreateRspParser(current.Substring(1));
						return MoveNext();
					}
				}
				_current = new Parameter(_rawArgEnumerator.Current);
				return true;
			}
			return false;
		}

		private IEnumerator<string> CreateRspParser(string path)
		{
			string filePath = (Path.IsPathRooted(path) ? path : Path.Combine(CurrentCommand.WorkingDirectory, path));
			try
			{
				return ResponseFileParser.Parse(filePath, CurrentCommand.ResponseFileHandling).GetEnumerator();
			}
			catch (Exception innerException)
			{
				throw new CommandParsingException(CurrentCommand, "Could not parse the response file '" + path + "'", innerException);
			}
		}

		public void Reset()
		{
			_current = null;
			_rspEnumerator = null;
			_rawArgEnumerator.Reset();
		}

		public void Dispose()
		{
			_current = null;
			_rspEnumerator = null;
			_rawArgEnumerator.Dispose();
		}
	}

	private sealed class CommandArgumentEnumerator : IEnumerator<CommandArgument>, IDisposable, IEnumerator
	{
		private readonly IEnumerator<CommandArgument> _enumerator;

		public CommandArgument Current => _enumerator.Current;

		object IEnumerator.Current => Current;

		public CommandArgumentEnumerator(IEnumerator<CommandArgument> enumerator)
		{
			_enumerator = enumerator;
		}

		public void Dispose()
		{
			_enumerator.Dispose();
		}

		public bool MoveNext()
		{
			if (Current == null || !Current.MultipleValues)
			{
				return _enumerator.MoveNext();
			}
			return true;
		}

		public void Reset()
		{
			_enumerator.Reset();
		}
	}

	private readonly CommandLineApplication _app;

	private readonly CommandLineApplication _initialCommand;

	private readonly ParameterEnumerator _enumerator;

	private CommandArgumentEnumerator _currentCommandArguments;

	private CommandLineApplication _currentCommand
	{
		get
		{
			return _enumerator.CurrentCommand;
		}
		set
		{
			_enumerator.CurrentCommand = value;
		}
	}

	public CommandLineProcessor(CommandLineApplication command, IReadOnlyList<string> arguments)
	{
		_app = command;
		_initialCommand = command;
		_enumerator = new ParameterEnumerator(arguments ?? new string[0]);
		if (!command.ClusterOptionsWasSetExplicitly)
		{
			foreach (CommandOption item in AllOptions(command))
			{
				if (item.ShortName != null && item.ShortName.Length != 1)
				{
					command.ClusterOptions = false;
					break;
				}
			}
			return;
		}
		if (!command.ClusterOptions)
		{
			return;
		}
		foreach (CommandOption item2 in AllOptions(command))
		{
			if (item2.ShortName != null && item2.ShortName.Length != 1)
			{
				throw new CommandParsingException(command, "The ShortName on CommandOption is too long: '" + item2.ShortName + "'. Short names cannot be more than one character long when ClusterOptions is enabled.");
			}
		}
	}

	internal static IEnumerable<CommandOption> AllOptions(CommandLineApplication command)
	{
		foreach (CommandOption option in command.Options)
		{
			yield return option;
		}
		foreach (CommandLineApplication command2 in command.Commands)
		{
			foreach (CommandOption item in AllOptions(command2))
			{
				yield return item;
			}
		}
	}

	public ParseResult Process()
	{
		_currentCommand = _initialCommand;
		_currentCommandArguments = null;
		do
		{
			if (!_enumerator.MoveNext())
			{
				_enumerator.Reset();
				break;
			}
		}
		while (ProcessNext());
		return new ParseResult
		{
			SelectedCommand = _currentCommand
		};
	}

	private bool ProcessNext()
	{
		switch (_enumerator.Current.Type)
		{
		case ParameterType.ArgumentSeparator:
			if (!ProcessArgumentSeparator())
			{
				return false;
			}
			break;
		case ParameterType.ShortOption:
		case ParameterType.LongOption:
			if (!ProcessOption())
			{
				return false;
			}
			break;
		case ParameterType.CommandOrArgument:
			if (!ProcessCommandOrArgument())
			{
				return false;
			}
			break;
		default:
			HandleUnexpectedArg("command or argument");
			return false;
		}
		return true;
	}

	private bool ProcessCommandOrArgument()
	{
		Parameter current = _enumerator.Current;
		foreach (CommandLineApplication command in _currentCommand.Commands)
		{
			if (command.MatchesName(current.Raw))
			{
				_currentCommand = command;
				_currentCommandArguments = null;
				return true;
			}
		}
		if (_currentCommandArguments == null)
		{
			_currentCommandArguments = new CommandArgumentEnumerator(_currentCommand.Arguments.GetEnumerator());
		}
		if (_currentCommandArguments.MoveNext())
		{
			_currentCommandArguments.Current.Values.Add(current.Raw);
			return true;
		}
		HandleUnexpectedArg("command or argument");
		return false;
	}

	private bool ProcessOption()
	{
		CommandOption commandOption = null;
		Parameter current = _enumerator.Current;
		string text = current.Value;
		string text2 = current.Name;
		if (current.Type == ParameterType.ShortOption)
		{
			if (_currentCommand.ClusterOptions)
			{
				for (int i = 0; i < current.Name.Length; i++)
				{
					string text3 = current.Name.Substring(i, 1);
					commandOption = FindOption(text3, (CommandOption o) => o.ShortName);
					if (commandOption == null)
					{
						commandOption = FindOption(text3, (CommandOption o) => o.SymbolName);
					}
					if (commandOption == null)
					{
						HandleUnexpectedArg("option", "-" + text3);
						return false;
					}
					if (_currentCommand.OptionHelp == commandOption)
					{
						_currentCommand.ShowHelp();
						commandOption.TryParse(null);
						return false;
					}
					if (_currentCommand.OptionVersion == commandOption)
					{
						_currentCommand.ShowVersion();
						commandOption.TryParse(null);
						return false;
					}
					text2 = text3;
					bool flag = i == current.Name.Length - 1;
					if (commandOption.OptionType == CommandOptionType.NoValue)
					{
						if (!flag)
						{
							commandOption.TryParse(null);
						}
					}
					else if (commandOption.OptionType == CommandOptionType.SingleOrNoValue)
					{
						if (!flag)
						{
							commandOption.TryParse(null);
						}
					}
					else if (!flag)
					{
						if (text != null)
						{
							_currentCommand.ShowHint();
							throw new CommandParsingException(_currentCommand, "Option '" + text3 + "', which requires a value, must be the last option in a cluster");
						}
						text = current.Name.Substring(i + 1);
						break;
					}
				}
			}
			else
			{
				commandOption = FindOption(text2, (CommandOption o) => o.ShortName);
				if (commandOption == null)
				{
					commandOption = FindOption(text2, (CommandOption o) => o.SymbolName);
				}
			}
		}
		else
		{
			commandOption = FindOption(text2, (CommandOption o) => o.LongName);
		}
		if (commandOption == null)
		{
			HandleUnexpectedArg("option");
			return false;
		}
		if (_currentCommand.OptionHelp == commandOption)
		{
			_currentCommand.ShowHelp();
			commandOption.TryParse(null);
			return false;
		}
		if (_currentCommand.OptionVersion == commandOption)
		{
			_currentCommand.ShowVersion();
			commandOption.TryParse(null);
			return false;
		}
		if (text != null)
		{
			if (!commandOption.TryParse(text))
			{
				_currentCommand.ShowHint();
				throw new CommandParsingException(_currentCommand, "Unexpected value '" + text + "' for option '" + text2 + "'");
			}
		}
		else if (commandOption.OptionType == CommandOptionType.NoValue || commandOption.OptionType == CommandOptionType.SingleOrNoValue)
		{
			commandOption.TryParse(null);
		}
		else
		{
			if (!_enumerator.MoveNext())
			{
				_currentCommand.ShowHint();
				throw new CommandParsingException(_currentCommand, "Missing value for option '" + text2 + "'");
			}
			Parameter current2 = _enumerator.Current;
			if (!commandOption.TryParse(current2.Raw))
			{
				_currentCommand.ShowHint();
				throw new CommandParsingException(_currentCommand, "Unexpected value '" + current2.Raw + "' for option '" + text2 + "'");
			}
		}
		return true;
	}

	private CommandOption FindOption(string name, Func<CommandOption, string> by)
	{
		List<CommandOption> list = (from o in _currentCommand.GetOptions()
			where string.Equals(name, @by(o), _currentCommand.OptionsComparison)
			select o).ToList();
		if (list.Count == 0)
		{
			return null;
		}
		if (list.Count == 1)
		{
			return list.First();
		}
		CommandOption commandOption = list.SingleOrDefault((CommandOption o) => o == _currentCommand.OptionHelp);
		if (commandOption != null)
		{
			return commandOption;
		}
		throw new InvalidOperationException("Multiple options with name \"" + name + "\" found. This is usually due to nested options.");
	}

	private bool ProcessArgumentSeparator()
	{
		if (!_currentCommand.AllowArgumentSeparator)
		{
			HandleUnexpectedArg("option");
		}
		_enumerator.DisableResponseFileLoading = true;
		if (_enumerator.MoveNext())
		{
			AddRemainingArgumentValues();
		}
		return false;
	}

	private void HandleUnexpectedArg(string argTypeName, string argValue = null)
	{
		if (_currentCommand.ThrowOnUnexpectedArgument)
		{
			_currentCommand.ShowHint();
			string text = argValue ?? _enumerator.Current?.Raw;
			IEnumerable<string> nearestMatches = Enumerable.Empty<string>();
			if (_currentCommand.MakeSuggestionsInErrorMessage && !string.IsNullOrEmpty(text))
			{
				nearestMatches = SuggestionCreator.GetTopSuggestions(_currentCommand, text);
			}
			throw new UnrecognizedCommandParsingException(_currentCommand, nearestMatches, "Unrecognized " + argTypeName + " '" + text + "'");
		}
		AddRemainingArgumentValues();
	}

	private void AddRemainingArgumentValues()
	{
		do
		{
			_currentCommand.RemainingArguments.Add(_enumerator.Current.Raw);
		}
		while (_enumerator.MoveNext());
	}
}
