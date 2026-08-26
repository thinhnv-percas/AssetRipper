using System.IO;

namespace Microsoft.VisualStudio.Composition;

internal interface IDescriptiveToString
{
	void ToString(TextWriter writer);
}
