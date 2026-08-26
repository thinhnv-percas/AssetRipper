namespace dnlib.DotNet.Writer;

public sealed class DummyModuleWriterListener : IModuleWriterListener
{
	public static readonly DummyModuleWriterListener Instance = new DummyModuleWriterListener();

	public void OnWriterEvent(ModuleWriterBase writer, ModuleWriterEvent evt)
	{
	}
}
