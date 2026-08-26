using System;
using System.Globalization;
using System.Text;

namespace DecompTools.Decompiler.Metadata;

public class AssemblyNameReference : IAssemblyReference
{
	private string fullName;

	public string Name { get; private set; }

	public string FullName
	{
		get
		{
			if (fullName != null)
			{
				return fullName;
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(Name);
			stringBuilder.Append(", ");
			stringBuilder.Append("Version=");
			stringBuilder.Append((Version ?? UniversalAssemblyResolver.ZeroVersion).ToString(4));
			stringBuilder.Append(", ");
			stringBuilder.Append("Culture=");
			stringBuilder.Append(string.IsNullOrEmpty(Culture) ? "neutral" : Culture);
			stringBuilder.Append(", ");
			stringBuilder.Append("PublicKeyToken=");
			byte[] publicKeyToken = PublicKeyToken;
			if (publicKeyToken != null && publicKeyToken.Length != 0)
			{
				for (int i = 0; i < publicKeyToken.Length; i = checked(i + 1))
				{
					stringBuilder.Append(publicKeyToken[i].ToString("x2"));
				}
			}
			else
			{
				stringBuilder.Append("null");
			}
			if (IsRetargetable)
			{
				stringBuilder.Append(", ");
				stringBuilder.Append("Retargetable=Yes");
			}
			return fullName = stringBuilder.ToString();
		}
	}

	public Version Version { get; private set; }

	public string Culture { get; private set; }

	public byte[] PublicKeyToken { get; private set; }

	public bool IsWindowsRuntime { get; private set; }

	public bool IsRetargetable { get; private set; }

	public static AssemblyNameReference Parse(string fullName)
	{
		if (fullName == null)
		{
			throw new ArgumentNullException("fullName");
		}
		if (fullName.Length == 0)
		{
			throw new ArgumentException("Name can not be empty");
		}
		AssemblyNameReference assemblyNameReference = new AssemblyNameReference();
		string[] array = fullName.Split(new char[1] { ',' });
		checked
		{
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i].Trim();
				if (i == 0)
				{
					assemblyNameReference.Name = text;
					continue;
				}
				string[] array2 = text.Split(new char[1] { '=' });
				if (array2.Length != 2)
				{
					throw new ArgumentException("Malformed name");
				}
				switch (array2[0].ToLowerInvariant())
				{
				case "version":
					assemblyNameReference.Version = new Version(array2[1]);
					break;
				case "culture":
					assemblyNameReference.Culture = ((array2[1] == "neutral") ? "" : array2[1]);
					break;
				case "publickeytoken":
				{
					string text2 = array2[1];
					if (!(text2 == "null"))
					{
						assemblyNameReference.PublicKeyToken = new byte[unchecked(text2.Length / 2)];
						for (int j = 0; j < assemblyNameReference.PublicKeyToken.Length; j++)
						{
							assemblyNameReference.PublicKeyToken[j] = byte.Parse(text2.Substring(j * 2, 2), NumberStyles.HexNumber);
						}
					}
					break;
				}
				}
			}
			return assemblyNameReference;
		}
	}

	public override string ToString()
	{
		return FullName;
	}
}
