using System.Collections.Generic;
using dnlib.DotNet;

namespace ICSharpCode.Decompiler.ILAst;

internal sealed class AutoPropertyProvider
{
	private readonly List<AutoPropertyInfo> typeInfos;

	private int typeInfosCount;

	public AutoPropertyProvider()
	{
		typeInfos = new List<AutoPropertyInfo>();
	}

	private AutoPropertyInfo AllocAutoPropertyInfo()
	{
		AutoPropertyInfo autoPropertyInfo;
		if (typeInfosCount < typeInfos.Count)
		{
			autoPropertyInfo = typeInfos[typeInfosCount++];
			autoPropertyInfo.Reset();
		}
		else
		{
			typeInfos.Add(autoPropertyInfo = new AutoPropertyInfo());
			typeInfosCount++;
		}
		return autoPropertyInfo;
	}

	private AutoPropertyInfo Find(TypeDef type)
	{
		for (int i = 0; i < typeInfosCount; i++)
		{
			AutoPropertyInfo autoPropertyInfo = typeInfos[i];
			if (autoPropertyInfo.Type == type)
			{
				return autoPropertyInfo;
			}
		}
		return null;
	}

	public AutoPropertyInfo GetOrCreate(TypeDef type)
	{
		AutoPropertyInfo autoPropertyInfo = Find(type);
		if (autoPropertyInfo == null)
		{
			autoPropertyInfo = AllocAutoPropertyInfo();
			autoPropertyInfo.Initialize(type);
		}
		return autoPropertyInfo;
	}

	public void Reset()
	{
		typeInfosCount = 0;
	}
}
