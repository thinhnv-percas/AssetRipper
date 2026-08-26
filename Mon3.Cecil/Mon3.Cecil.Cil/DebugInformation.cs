using System.Threading;
using Mon3.Collections.Generic;

namespace Mon3.Cecil.Cil;

public abstract class DebugInformation : ICustomDebugInformationProvider, IMetadataTokenProvider
{
	internal MetadataToken token;

	internal Collection<CustomDebugInformation> custom_infos;

	public MetadataToken MetadataToken
	{
		get
		{
			return token;
		}
		set
		{
			token = value;
		}
	}

	public bool HasCustomDebugInformations => !custom_infos.IsNullOrEmpty();

	public Collection<CustomDebugInformation> CustomDebugInformations
	{
		get
		{
			if (custom_infos == null)
			{
				Interlocked.CompareExchange(ref custom_infos, new Collection<CustomDebugInformation>(), null);
			}
			return custom_infos;
		}
	}

	internal DebugInformation()
	{
	}
}
