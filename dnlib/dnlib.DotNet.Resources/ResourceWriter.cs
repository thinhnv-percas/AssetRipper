using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace dnlib.DotNet.Resources;

public sealed class ResourceWriter
{
	private ModuleDef module;

	private BinaryWriter writer;

	private ResourceElementSet resources;

	private ResourceDataFactory typeCreator;

	private Dictionary<UserResourceData, UserResourceType> dataToNewType = new Dictionary<UserResourceData, UserResourceType>();

	private ResourceWriter(ModuleDef module, Stream stream, ResourceElementSet resources)
	{
		this.module = module;
		typeCreator = new ResourceDataFactory(module);
		writer = new BinaryWriter(stream);
		this.resources = resources;
	}

	public static void Write(ModuleDef module, Stream stream, ResourceElementSet resources)
	{
		new ResourceWriter(module, stream, resources).Write();
	}

	private void Write()
	{
		InitializeUserTypes();
		writer.Write(3203386062u);
		writer.Write(1);
		WriteReaderType();
		writer.Write(2);
		writer.Write(resources.Count);
		writer.Write(typeCreator.Count);
		foreach (UserResourceType sortedType in typeCreator.GetSortedTypes())
		{
			writer.Write(sortedType.Name);
		}
		int num = 8 - ((int)writer.BaseStream.Position & 7);
		if (num != 8)
		{
			for (int i = 0; i < num; i++)
			{
				writer.Write((byte)88);
			}
		}
		MemoryStream memoryStream = new MemoryStream();
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream, Encoding.Unicode);
		MemoryStream memoryStream2 = new MemoryStream();
		BinaryWriter binaryWriter2 = new BinaryWriter(memoryStream2);
		int[] array = new int[resources.Count];
		int[] array2 = new int[resources.Count];
		BinaryFormatter formatter = new BinaryFormatter(null, new StreamingContext(StreamingContextStates.File | StreamingContextStates.Persistence));
		int num2 = 0;
		foreach (ResourceElement resourceElement in resources.ResourceElements)
		{
			array2[num2] = (int)binaryWriter.BaseStream.Position;
			array[num2] = (int)Hash(resourceElement.Name);
			num2++;
			binaryWriter.Write(resourceElement.Name);
			binaryWriter.Write((int)binaryWriter2.BaseStream.Position);
			WriteData(binaryWriter2, resourceElement, formatter);
		}
		Array.Sort(array, array2);
		int[] array3 = array;
		foreach (int value in array3)
		{
			writer.Write(value);
		}
		int[] array4 = array2;
		foreach (int value2 in array4)
		{
			writer.Write(value2);
		}
		writer.Write((int)writer.BaseStream.Position + (int)memoryStream.Length + 4);
		writer.Write(memoryStream.ToArray());
		writer.Write(memoryStream2.ToArray());
	}

	private void WriteData(BinaryWriter writer, ResourceElement info, IFormatter formatter)
	{
		ResourceTypeCode resourceType = GetResourceType(info.ResourceData);
		WriteUInt32(writer, (uint)resourceType);
		info.ResourceData.WriteData(writer, formatter);
	}

	private static void WriteUInt32(BinaryWriter writer, uint value)
	{
		while (value >= 128)
		{
			writer.Write((byte)(value | 0x80));
			value >>= 7;
		}
		writer.Write((byte)value);
	}

	private ResourceTypeCode GetResourceType(IResourceData data)
	{
		if (data is BuiltInResourceData)
		{
			return data.Code;
		}
		UserResourceData key = (UserResourceData)data;
		return dataToNewType[key].Code;
	}

	private static uint Hash(string key)
	{
		uint num = 5381u;
		foreach (char c in key)
		{
			num = ((num << 5) + num) ^ c;
		}
		return num;
	}

	private void InitializeUserTypes()
	{
		foreach (ResourceElement resourceElement in resources.ResourceElements)
		{
			if (resourceElement.ResourceData is UserResourceData userResourceData)
			{
				UserResourceType value = typeCreator.CreateUserResourceType(userResourceData.TypeName);
				dataToNewType[userResourceData] = value;
			}
		}
	}

	private void WriteReaderType()
	{
		MemoryStream memoryStream = new MemoryStream();
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		string mscorlibFullname = GetMscorlibFullname();
		binaryWriter.Write("System.Resources.ResourceReader, " + mscorlibFullname);
		binaryWriter.Write("System.Resources.RuntimeResourceSet");
		writer.Write((int)memoryStream.Position);
		writer.Write(memoryStream.ToArray());
	}

	private string GetMscorlibFullname()
	{
		if (module.CorLibTypes.AssemblyRef.Name == "mscorlib")
		{
			return module.CorLibTypes.AssemblyRef.FullName;
		}
		return "mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
	}
}
