using System;
using System.Reflection.Metadata;

namespace DecompTools.Decompiler.Disassembler;

public struct OpCodeInfo : IEquatable<OpCodeInfo>
{
	public readonly ILOpCode Code;

	public readonly string Name;

	private string encodedName;

	public string Link => "http://msdn.microsoft.com/library/system.reflection.emit.opcodes." + EncodedName.ToLowerInvariant() + ".aspx";

	public string EncodedName
	{
		get
		{
			if (encodedName != null)
			{
				return encodedName;
			}
			switch (Name)
			{
			case "constrained.":
				encodedName = "Constrained";
				return encodedName;
			case "no.":
				encodedName = "No";
				return encodedName;
			case "readonly.":
				encodedName = "Reaonly";
				return encodedName;
			case "tail.":
				encodedName = "Tailcall";
				return encodedName;
			case "unaligned.":
				encodedName = "Unaligned";
				return encodedName;
			case "volatile.":
				encodedName = "Volatile";
				return encodedName;
			default:
			{
				string text = "";
				bool flag = true;
				string name = Name;
				for (int i = 0; i < name.Length; i++)
				{
					char c = name[i];
					if (c == '.')
					{
						text += "_";
						flag = true;
					}
					else if (flag)
					{
						text += char.ToUpperInvariant(c);
						flag = false;
					}
					else
					{
						text += c;
					}
				}
				encodedName = text;
				return encodedName;
			}
			}
		}
	}

	public OpCodeInfo(ILOpCode code, string name)
	{
		Code = code;
		Name = name ?? "";
		encodedName = null;
	}

	public bool Equals(OpCodeInfo other)
	{
		return other.Code == Code && other.Name == Name;
	}

	public static bool operator ==(OpCodeInfo lhs, OpCodeInfo rhs)
	{
		return lhs.Equals(rhs);
	}

	public static bool operator !=(OpCodeInfo lhs, OpCodeInfo rhs)
	{
		return !(lhs == rhs);
	}

	public override bool Equals(object obj)
	{
		if (obj is OpCodeInfo other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return 982451629 * Code.GetHashCode() + 982451653 * Name.GetHashCode();
	}
}
