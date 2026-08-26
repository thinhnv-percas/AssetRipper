namespace Microsoft.VisualStudio.Composition;

public interface IFaultReportingExportProviderFactory : IExportProviderFactory
{
	ExportProvider CreateExportProvider(ReportFaultCallback faultCallback);
}
