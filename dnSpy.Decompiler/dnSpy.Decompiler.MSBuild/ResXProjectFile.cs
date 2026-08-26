using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Resources;
using dnlib.DotNet;
using dnSpy.Decompiler.Properties;

namespace dnSpy.Decompiler.MSBuild;

internal sealed class ResXProjectFile : ProjectFile
{
	private static readonly Func<string, Func<Type, string>, ResXResourceWriter> delegateResXResourceWriterConstructor;

	private static readonly Func<string, object, Func<Type, string>, ResXDataNode> delegateResXDataNodeConstructor;

	private readonly string filename;

	private readonly EmbeddedResource embeddedResource;

	private readonly Dictionary<IAssembly, IAssembly> newToOldAsm;

	public override string Description => dnSpy_Decompiler_Resources.MSBuild_CreateResXFile;

	public override BuildAction BuildAction => BuildAction.EmbeddedResource;

	public override string Filename => filename;

	public string TypeFullName { get; }

	public bool IsSatelliteFile { get; set; }

	static ResXProjectFile()
	{
		Type[] array = new Type[2]
		{
			typeof(string),
			typeof(Func<Type, string>)
		};
		ConstructorInfo constructor = typeof(ResXResourceWriter).GetConstructor(array);
		if (constructor != null)
		{
			DynamicMethod dynamicMethod = new DynamicMethod("ResXResourceWriter-ctor", typeof(ResXResourceWriter), array);
			ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
			iLGenerator.Emit(OpCodes.Ldarg_0);
			iLGenerator.Emit(OpCodes.Ldarg_1);
			iLGenerator.Emit(OpCodes.Newobj, constructor);
			iLGenerator.Emit(OpCodes.Ret);
			delegateResXResourceWriterConstructor = (Func<string, Func<Type, string>, ResXResourceWriter>)dynamicMethod.CreateDelegate(typeof(Func<string, Func<Type, string>, ResXResourceWriter>));
		}
		array = new Type[3]
		{
			typeof(string),
			typeof(object),
			typeof(Func<Type, string>)
		};
		constructor = typeof(ResXDataNode).GetConstructor(array);
		if (constructor != null)
		{
			DynamicMethod dynamicMethod2 = new DynamicMethod("ResXDataNode-ctor", typeof(ResXDataNode), array);
			ILGenerator iLGenerator2 = dynamicMethod2.GetILGenerator();
			iLGenerator2.Emit(OpCodes.Ldarg_0);
			iLGenerator2.Emit(OpCodes.Ldarg_1);
			iLGenerator2.Emit(OpCodes.Ldarg_2);
			iLGenerator2.Emit(OpCodes.Newobj, constructor);
			iLGenerator2.Emit(OpCodes.Ret);
			delegateResXDataNodeConstructor = (Func<string, object, Func<Type, string>, ResXDataNode>)dynamicMethod2.CreateDelegate(typeof(Func<string, object, Func<Type, string>, ResXDataNode>));
		}
	}

	public ResXProjectFile(ModuleDef module, string filename, string typeFullName, EmbeddedResource er)
	{
		this.filename = filename;
		TypeFullName = typeFullName;
		embeddedResource = er;
		newToOldAsm = new Dictionary<IAssembly, IAssembly>(new AssemblyNameComparer(AssemblyNameComparerFlags.Name | AssemblyNameComparerFlags.PublicKeyToken | AssemblyNameComparerFlags.Culture | AssemblyNameComparerFlags.ContentType));
		foreach (AssemblyRef assemblyRef in module.GetAssemblyRefs())
		{
			newToOldAsm[assemblyRef] = assemblyRef;
		}
	}

	public override void Create(DecompileContext ctx)
	{
		List<ResXDataNode> list = ReadResourceEntries(ctx);
		using ResXResourceWriter resXResourceWriter = delegateResXResourceWriterConstructor?.Invoke(Filename, TypeNameConverter) ?? new ResXResourceWriter(Filename);
		foreach (ResXDataNode item in list)
		{
			ctx.CancellationToken.ThrowIfCancellationRequested();
			resXResourceWriter.AddResource(item);
		}
	}

	private string TypeNameConverter(Type type)
	{
		AssemblyNameInfo assemblyNameInfo = new AssemblyNameInfo(type.Assembly.GetName());
		if (!newToOldAsm.TryGetValue(assemblyNameInfo, out var value))
		{
			return type.AssemblyQualifiedName;
		}
		if (type.IsGenericType)
		{
			return type.AssemblyQualifiedName;
		}
		if (AssemblyNameComparer.CompareAll.Equals(value, assemblyNameInfo))
		{
			return type.AssemblyQualifiedName;
		}
		return $"{type.FullName}, {value.FullName}";
	}

	private List<ResXDataNode> ReadResourceEntries(DecompileContext ctx)
	{
		List<ResXDataNode> list = new List<ResXDataNode>();
		int num = 0;
		try
		{
			using ResourceReader resourceReader = new ResourceReader(embeddedResource.CreateReader().AsStream());
			IDictionaryEnumerator enumerator = resourceReader.GetEnumerator();
			while (enumerator.MoveNext())
			{
				ctx.CancellationToken.ThrowIfCancellationRequested();
				string text = null;
				try
				{
					text = enumerator.Key as string;
					if (text == null)
					{
						continue;
					}
					object obj = enumerator.Value;
					if (obj is Stream && !obj.GetType().IsSerializable)
					{
						Stream stream = (Stream)obj;
						byte[] array = new byte[stream.Length];
						if (stream.Read(array, 0, array.Length) != array.Length)
						{
							throw new IOException("Could not read all bytes");
						}
						obj = new MemoryStream(array);
					}
					list.Add(delegateResXDataNodeConstructor?.Invoke(text, obj, TypeNameConverter) ?? new ResXDataNode(text, obj));
				}
				catch (Exception ex)
				{
					if (num++ < 30)
					{
						ctx.Logger.Error($"Could not add resource '{text}', Message: {ex.Message}");
					}
				}
			}
		}
		catch (Exception ex2)
		{
			ctx.Logger.Error($"Could not read resources from {embeddedResource.Name}, Message: {ex2.Message}");
		}
		return list;
	}
}
