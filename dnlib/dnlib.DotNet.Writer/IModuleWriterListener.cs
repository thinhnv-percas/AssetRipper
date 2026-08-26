namespace dnlib.DotNet.Writer;

public interface IModuleWriterListener
{
	void OnWriterEvent(ModuleWriterBase writer, ModuleWriterEvent evt);
}
