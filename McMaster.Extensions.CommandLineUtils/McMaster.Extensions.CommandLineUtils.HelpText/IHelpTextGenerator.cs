using System.IO;

namespace McMaster.Extensions.CommandLineUtils.HelpText;

public interface IHelpTextGenerator
{
	void Generate(CommandLineApplication application, TextWriter output);
}
