using System;
using dnlib.DotNet;
using dnlib.PE;
using dnSpy.Contracts.Decompiler;

namespace dnSpy.Contracts.Text;

public static class ITextColorWriterExtensions
{
	public static T WriteLine<T>(this T output) where T : ITextColorWriter
	{
		output.Write(BoxedTextColor.Text, Environment.NewLine);
		return output;
	}

	public static T WriteSpace<T>(this T output) where T : ITextColorWriter
	{
		output.Write(BoxedTextColor.Text, " ");
		return output;
	}

	public static T WriteCommaSpace<T>(this T output) where T : ITextColorWriter
	{
		output.Write(BoxedTextColor.Punctuation, ",");
		output.WriteSpace();
		return output;
	}

	public static T Write<T>(this T output, Version version) where T : ITextColorWriter
	{
		if (version == null)
		{
			object error = BoxedTextColor.Error;
			output.Write(error, "?.?.?.?");
		}
		else
		{
			object number = BoxedTextColor.Number;
			string text = version.Major.ToString();
			output.Write(number, text);
			object number2 = BoxedTextColor.Number;
			output.Write(number2, ".");
			object number3 = BoxedTextColor.Number;
			string text2 = version.Minor.ToString();
			output.Write(number3, text2);
			object number4 = BoxedTextColor.Number;
			output.Write(number4, ".");
			object number5 = BoxedTextColor.Number;
			string text3 = version.Build.ToString();
			output.Write(number5, text3);
			object number6 = BoxedTextColor.Number;
			output.Write(number6, ".");
			object number7 = BoxedTextColor.Number;
			string text4 = version.Revision.ToString();
			output.Write(number7, text4);
		}
		return output;
	}

	public static T Write<T>(this T output, IAssembly asm) where T : ITextColorWriter
	{
		if (asm == null)
		{
			return output;
		}
		bool flag = asm is AssemblyDef { ManifestModule: not null } assemblyDef && (assemblyDef.ManifestModule.Characteristics & Characteristics.Dll) == 0;
		object color = (flag ? BoxedTextColor.AssemblyExe : BoxedTextColor.Assembly);
		string text = asm.Name;
		output.Write(color, text);
		output.WriteCommaSpace();
		object instanceProperty = BoxedTextColor.InstanceProperty;
		output.Write(instanceProperty, "Version");
		object color2 = BoxedTextColor.Operator;
		output.Write(color2, "=");
		output.Write(asm.Version);
		output.WriteCommaSpace();
		object instanceProperty2 = BoxedTextColor.InstanceProperty;
		output.Write(instanceProperty2, "Culture");
		object color3 = BoxedTextColor.Operator;
		output.Write(color3, "=");
		object enumField = BoxedTextColor.EnumField;
		string text2 = (UTF8String.IsNullOrEmpty(asm.Culture) ? "neutral" : asm.Culture.String);
		output.Write(enumField, text2);
		output.WriteCommaSpace();
		PublicKeyToken publicKeyToken = PublicKeyBase.ToPublicKeyToken(asm.PublicKeyOrToken);
		object instanceProperty3 = BoxedTextColor.InstanceProperty;
		output.Write(instanceProperty3, (publicKeyToken == null || publicKeyToken != null) ? "PublicKeyToken" : "PublicKey");
		object color4 = BoxedTextColor.Operator;
		output.Write(color4, "=");
		if (PublicKeyBase.IsNullOrEmpty2(publicKeyToken))
		{
			object keyword = BoxedTextColor.Keyword;
			output.Write(keyword, "null");
		}
		else
		{
			object number = BoxedTextColor.Number;
			string text3 = publicKeyToken.ToString();
			output.Write(number, text3);
		}
		if ((asm.Attributes & AssemblyAttributes.Retargetable) != AssemblyAttributes.None)
		{
			output.WriteCommaSpace();
			object instanceProperty4 = BoxedTextColor.InstanceProperty;
			output.Write(instanceProperty4, "Retargetable");
			object color5 = BoxedTextColor.Operator;
			output.Write(color5, "=");
			object enumField2 = BoxedTextColor.EnumField;
			output.Write(enumField2, "Yes");
		}
		if ((asm.Attributes & AssemblyAttributes.ContentType_Mask) == AssemblyAttributes.ContentType_WindowsRuntime)
		{
			output.WriteCommaSpace();
			object instanceProperty5 = BoxedTextColor.InstanceProperty;
			output.Write(instanceProperty5, "ContentType");
			object color6 = BoxedTextColor.Operator;
			output.Write(color6, "=");
			object enumField3 = BoxedTextColor.EnumField;
			output.Write(enumField3, "WindowsRuntime");
		}
		return output;
	}

	public static T WriteNamespace<T>(this T output, string @namespace) where T : ITextColorWriter
	{
		if (@namespace == null)
		{
			return output;
		}
		if (@namespace.Length == 0)
		{
			object punctuation = BoxedTextColor.Punctuation;
			output.Write(punctuation, "-");
		}
		else
		{
			string[] array = @namespace.Split('.');
			for (int i = 0; i < array.Length; i++)
			{
				if (i > 0)
				{
					object color = BoxedTextColor.Operator;
					output.Write(color, ".");
				}
				object color2 = BoxedTextColor.Namespace;
				string text = IdentifierEscaper.Escape(array[i]);
				output.Write(color2, text);
			}
		}
		return output;
	}

	public static T WriteModule<T>(this T output, string name) where T : ITextColorWriter
	{
		output.Write(BoxedTextColor.AssemblyModule, NameUtilities.CleanName(name));
		return output;
	}

	public static T WriteFilename<T>(this T output, string filename) where T : ITextColorWriter
	{
		if (filename == null)
		{
			return output;
		}
		filename = NameUtilities.CleanName(filename);
		string text = filename.Replace('\\', '/');
		string[] array = text.Split('/');
		int num = 0;
		for (int i = 0; i < array.Length - 1; i++)
		{
			object directoryPart = BoxedTextColor.DirectoryPart;
			string text2 = array[i];
			output.Write(directoryPart, text2);
			num += array[i].Length;
			object text3 = BoxedTextColor.Text;
			string text4 = filename[num].ToString();
			output.Write(text3, text4);
			num++;
		}
		string text5 = array[array.Length - 1];
		int num2 = text5.LastIndexOf('.');
		if (num2 < 0)
		{
			object fileNameNoExtension = BoxedTextColor.FileNameNoExtension;
			output.Write(fileNameNoExtension, text5);
		}
		else
		{
			string text6 = text5.Substring(num2 + 1);
			text5 = text5.Substring(0, num2);
			object fileNameNoExtension2 = BoxedTextColor.FileNameNoExtension;
			output.Write(fileNameNoExtension2, text5);
			object text7 = BoxedTextColor.Text;
			output.Write(text7, ".");
			object fileExtension = BoxedTextColor.FileExtension;
			output.Write(fileExtension, text6);
		}
		return output;
	}
}
