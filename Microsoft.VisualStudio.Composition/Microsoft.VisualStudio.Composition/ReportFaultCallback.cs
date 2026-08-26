using System;

namespace Microsoft.VisualStudio.Composition;

public delegate void ReportFaultCallback(Exception e, RuntimeComposition.RuntimeImport import, RuntimeComposition.RuntimeExport export);
