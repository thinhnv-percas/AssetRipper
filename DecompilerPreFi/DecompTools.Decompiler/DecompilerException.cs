using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;
using System.Text;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler;

public class DecompilerException : Exception, ISerializable
{
	public string AssemblyName => Module.AssemblyName;

	public string FileName => Module.PEFile.FileName;

	public IEntity DecompiledEntity { get; }

	public IModule Module { get; }

	public override string StackTrace => GetStackTrace(this);

	public DecompilerException(MetadataModule module, IEntity decompiledEntity, Exception innerException, string message = null)
		: base((message ?? ("Error decompiling " + decompiledEntity?.FullName)) + Environment.NewLine, innerException)
	{
		Module = module;
		DecompiledEntity = decompiledEntity;
	}

	protected DecompilerException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	public override string ToString()
	{
		return ToString(this);
	}

	private string ToString(Exception exception)
	{
		if (exception == null)
		{
			throw new ArgumentNullException("exception");
		}
		string typeName = GetTypeName(exception);
		string text = GetStackTrace(exception);
		while (exception.InnerException != null)
		{
			exception = exception.InnerException;
			text = GetStackTrace(exception) + Environment.NewLine + "-- continuing with outer exception (" + typeName + ") --" + Environment.NewLine + text;
			typeName = GetTypeName(exception);
		}
		return Message + " ---> " + typeName + ": " + exception.Message + Environment.NewLine + text;
	}

	private static string GetTypeName(Exception exception)
	{
		string fullName = exception.GetType().FullName;
		if (exception is ExternalException || exception is IOException)
		{
			return fullName + " (" + Marshal.GetHRForException(exception).ToString("x8") + ")";
		}
		return fullName;
	}

	private static string GetStackTrace(Exception exception)
	{
		StackTrace stackTrace = new StackTrace(exception, fNeedFileInfo: true);
		StringBuilder stringBuilder = new StringBuilder();
		checked
		{
			for (int i = 0; i < stackTrace.FrameCount; i++)
			{
				StackFrame frame = stackTrace.GetFrame(i);
				MethodBase method = frame.GetMethod();
				if (method == null)
				{
					continue;
				}
				if (stringBuilder.Length > 0)
				{
					stringBuilder.AppendLine();
				}
				stringBuilder.Append("   at ");
				Type declaringType = method.DeclaringType;
				if (declaringType != null)
				{
					stringBuilder.Append(declaringType.FullName.Replace('+', '.'));
					stringBuilder.Append('.');
				}
				stringBuilder.Append(method.Name);
				if (method is MethodInfo && ((MethodInfo)method).IsGenericMethod)
				{
					Type[] genericArguments = ((MethodInfo)method).GetGenericArguments();
					stringBuilder.Append('[');
					for (int j = 0; j < genericArguments.Length; j++)
					{
						if (j > 0)
						{
							stringBuilder.Append(',');
						}
						stringBuilder.Append(genericArguments[j].Name);
					}
					stringBuilder.Append(']');
				}
				stringBuilder.Append('(');
				ParameterInfo[] parameters = method.GetParameters();
				for (int k = 0; k < parameters.Length; k++)
				{
					if (k > 0)
					{
						stringBuilder.Append(", ");
					}
					if (parameters[k].ParameterType != null)
					{
						stringBuilder.Append(parameters[k].ParameterType.Name);
					}
					else
					{
						stringBuilder.Append('?');
					}
					if (!string.IsNullOrEmpty(parameters[k].Name))
					{
						stringBuilder.Append(' ');
						stringBuilder.Append(parameters[k].Name);
					}
				}
				stringBuilder.Append(')');
				if (frame.GetILOffset() < 0)
				{
					continue;
				}
				string text = null;
				try
				{
					string fileName = frame.GetFileName();
					if (fileName != null)
					{
						text = Path.GetFileName(fileName);
					}
				}
				catch (SecurityException)
				{
				}
				catch (ArgumentException)
				{
				}
				stringBuilder.Append(" in ");
				if (text != null)
				{
					stringBuilder.Append(text);
					stringBuilder.Append(":line ");
					stringBuilder.Append(frame.GetFileLineNumber());
				}
				else
				{
					stringBuilder.Append("offset ");
					stringBuilder.Append(frame.GetILOffset());
				}
			}
			return stringBuilder.ToString();
		}
	}
}
