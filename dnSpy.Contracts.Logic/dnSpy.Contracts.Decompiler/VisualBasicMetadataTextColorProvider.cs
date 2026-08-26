using dnlib.DotNet;
using dnSpy.Contracts.Text;

namespace dnSpy.Contracts.Decompiler;

public sealed class VisualBasicMetadataTextColorProvider : MetadataTextColorProvider
{
	public static readonly VisualBasicMetadataTextColorProvider Instance = new VisualBasicMetadataTextColorProvider();

	private static readonly UTF8String stringMicrosoftVisualBasicCompilerServices = new UTF8String("Microsoft.VisualBasic.CompilerServices");

	private static readonly UTF8String stringStandardModuleAttribute = new UTF8String("StandardModuleAttribute");

	private VisualBasicMetadataTextColorProvider()
	{
	}

	public override object GetColor(TypeDef type)
	{
		if (IsModule(type))
		{
			return BoxedTextColor.Module;
		}
		return base.GetColor(type);
	}

	private static bool IsModule(TypeDef type)
	{
		return type != null && type.DeclaringType == null && type.IsSealed && type.IsDefined(stringMicrosoftVisualBasicCompilerServices, stringStandardModuleAttribute);
	}
}
