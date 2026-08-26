using dnSpy.Contracts.MVVM;
using ICSharpCode.Decompiler;

namespace dnSpy.Decompiler.ILSpy.Settings;

internal sealed class DecompilationObjectVM : ViewModelBase
{
	public DecompilationObject Object { get; }

	public string Text { get; }

	public DecompilationObjectVM(DecompilationObject decompilationObject, string text)
	{
		Object = decompilationObject;
		Text = text;
	}
}
