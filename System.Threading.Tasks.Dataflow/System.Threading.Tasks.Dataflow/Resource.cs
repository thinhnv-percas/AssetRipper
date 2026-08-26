using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;

namespace System.Threading.Tasks.Dataflow;

[DebuggerNonUserCode]
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
[CompilerGenerated]
internal class Resource
{
	private static ResourceManager resourceMan;

	private static CultureInfo resourceCulture;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager
	{
		get
		{
			if (object.ReferenceEquals(resourceMan, null))
			{
				ResourceManager resourceManager = new ResourceManager("System.Threading.Tasks.Dataflow.Resource", typeof(Resource).GetTypeInfo().Assembly);
				resourceMan = resourceManager;
			}
			return resourceMan;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo Culture
	{
		get
		{
			return resourceCulture;
		}
		set
		{
			resourceCulture = value;
		}
	}

	internal static string Argument_BoundedCapacityNotSupported => ResourceManager.GetString("Argument_BoundedCapacityNotSupported", resourceCulture);

	internal static string Argument_CantConsumeFromANullSource => ResourceManager.GetString("Argument_CantConsumeFromANullSource", resourceCulture);

	internal static string Argument_InvalidMessageHeader => ResourceManager.GetString("Argument_InvalidMessageHeader", resourceCulture);

	internal static string Argument_InvalidMessageId => ResourceManager.GetString("Argument_InvalidMessageId", resourceCulture);

	internal static string Argument_InvalidSourceForFilteredLink => ResourceManager.GetString("Argument_InvalidSourceForFilteredLink", resourceCulture);

	internal static string Argument_NonGreedyNotSupported => ResourceManager.GetString("Argument_NonGreedyNotSupported", resourceCulture);

	internal static string ArgumentOutOfRange_BatchSizeMustBeNoGreaterThanBoundedCapacity => ResourceManager.GetString("ArgumentOutOfRange_BatchSizeMustBeNoGreaterThanBoundedCapacity", resourceCulture);

	internal static string ArgumentOutOfRange_GenericPositive => ResourceManager.GetString("ArgumentOutOfRange_GenericPositive", resourceCulture);

	internal static string ArgumentOutOfRange_NeedNonNegOrNegative1 => ResourceManager.GetString("ArgumentOutOfRange_NeedNonNegOrNegative1", resourceCulture);

	internal static string ConcurrentCollection_SyncRoot_NotSupported => ResourceManager.GetString("ConcurrentCollection_SyncRoot_NotSupported", resourceCulture);

	internal static string event_DataflowBlockCompleted => ResourceManager.GetString("event_DataflowBlockCompleted", resourceCulture);

	internal static string event_DataflowBlockCreated => ResourceManager.GetString("event_DataflowBlockCreated", resourceCulture);

	internal static string event_DataflowBlockLinking => ResourceManager.GetString("event_DataflowBlockLinking", resourceCulture);

	internal static string event_DataflowBlockUnlinking => ResourceManager.GetString("event_DataflowBlockUnlinking", resourceCulture);

	internal static string event_TaskLaunchedForMessageHandling => ResourceManager.GetString("event_TaskLaunchedForMessageHandling", resourceCulture);

	internal static string InvalidOperation_DataNotAvailableForReceive => ResourceManager.GetString("InvalidOperation_DataNotAvailableForReceive", resourceCulture);

	internal static string InvalidOperation_FailedToConsumeReservedMessage => ResourceManager.GetString("InvalidOperation_FailedToConsumeReservedMessage", resourceCulture);

	internal static string InvalidOperation_MessageNotReservedByTarget => ResourceManager.GetString("InvalidOperation_MessageNotReservedByTarget", resourceCulture);

	internal static string NotSupported_MemberNotNeeded => ResourceManager.GetString("NotSupported_MemberNotNeeded", resourceCulture);

	internal Resource()
	{
	}
}
