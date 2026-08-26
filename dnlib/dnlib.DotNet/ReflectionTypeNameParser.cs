using System;
using System.Collections.Generic;
using System.Text;

namespace dnlib.DotNet;

internal sealed class ReflectionTypeNameParser : TypeNameParser
{
	public ReflectionTypeNameParser(ModuleDef ownerModule, string typeFullName, IAssemblyRefFinder typeNameParserHelper)
		: base(ownerModule, typeFullName, typeNameParserHelper, default(GenericParamContext))
	{
	}

	public ReflectionTypeNameParser(ModuleDef ownerModule, string typeFullName, IAssemblyRefFinder typeNameParserHelper, GenericParamContext gpContext)
		: base(ownerModule, typeFullName, typeNameParserHelper, gpContext)
	{
	}

	public static AssemblyRef ParseAssemblyRef(string asmFullName)
	{
		return ParseAssemblyRef(asmFullName, default(GenericParamContext));
	}

	public static AssemblyRef ParseAssemblyRef(string asmFullName, GenericParamContext gpContext)
	{
		try
		{
			using ReflectionTypeNameParser reflectionTypeNameParser = new ReflectionTypeNameParser(null, asmFullName, null, gpContext);
			return reflectionTypeNameParser.ReadAssemblyRef();
		}
		catch
		{
			return null;
		}
	}

	internal override TypeSig ParseAsTypeSig()
	{
		try
		{
			TypeSig result = ReadType(readAssemblyReference: true);
			SkipWhite();
			TypeNameParser.Verify(PeekChar() == -1, "Extra input after type name");
			return result;
		}
		catch (TypeNameParserException)
		{
			throw;
		}
		catch (Exception innerException)
		{
			throw new TypeNameParserException("Could not parse type name", innerException);
		}
	}

	private TypeSig ReadType(bool readAssemblyReference)
	{
		RecursionIncrement();
		SkipWhite();
		TypeSig typeSig;
		if (PeekChar() == 33)
		{
			GenericSig currentSig = ReadGenericSig();
			IList<TSpec> tspecs = ReadTSpecs();
			ReadOptionalAssemblyRef();
			typeSig = CreateTypeSig(tspecs, currentSig);
		}
		else
		{
			TypeRef typeRef = ReadTypeRefAndNestedNoAssembly('+');
			IList<TSpec> list = ReadTSpecs();
			TypeRef nonNestedTypeRef = TypeRef.GetNonNestedTypeRef(typeRef);
			AssemblyRef asmRef = (AssemblyRef)(nonNestedTypeRef.ResolutionScope = ((!readAssemblyReference) ? FindAssemblyRef(nonNestedTypeRef) : (ReadOptionalAssemblyRef() ?? FindAssemblyRef(nonNestedTypeRef))));
			typeSig = null;
			if (typeRef == nonNestedTypeRef)
			{
				CorLibTypeSig corLibTypeSig = ownerModule.CorLibTypes.GetCorLibTypeSig(typeRef.Namespace, typeRef.Name, typeRef.DefinitionAssembly);
				if (corLibTypeSig != null)
				{
					typeSig = corLibTypeSig;
				}
			}
			if (typeSig == null)
			{
				TypeDef typeDef = Resolve(asmRef, typeRef);
				ITypeDefOrRef type;
				if (typeDef == null)
				{
					ITypeDefOrRef typeDefOrRef = typeRef;
					type = typeDefOrRef;
				}
				else
				{
					ITypeDefOrRef typeDefOrRef = typeDef;
					type = typeDefOrRef;
				}
				typeSig = ToTypeSig(type);
			}
			if (list.Count != 0)
			{
				typeSig = CreateTypeSig(list, typeSig);
			}
		}
		RecursionDecrement();
		return typeSig;
	}

	private TypeDef Resolve(AssemblyRef asmRef, TypeRef typeRef)
	{
		AssemblyDef assembly = ownerModule.Assembly;
		if (assembly == null)
		{
			return null;
		}
		if (!AssemblyNameComparer.CompareAll.Equals(asmRef, assembly) || asmRef.IsRetargetable != assembly.IsRetargetable)
		{
			return null;
		}
		TypeDef typeDef = typeRef.Resolve();
		return (typeDef != null && typeDef.Module == ownerModule) ? typeDef : null;
	}

	private AssemblyRef ReadOptionalAssemblyRef()
	{
		SkipWhite();
		if (PeekChar() == 44)
		{
			ReadChar();
			return ReadAssemblyRef();
		}
		return null;
	}

	private IList<TSpec> ReadTSpecs()
	{
		List<TSpec> list = new List<TSpec>();
		while (true)
		{
			SkipWhite();
			switch (PeekChar())
			{
			case 91:
			{
				ReadChar();
				SkipWhite();
				int num = PeekChar();
				switch (num)
				{
				case 93:
					TypeNameParser.Verify(ReadChar() == 93, "Expected ']'");
					list.Add(SZArraySpec.Instance);
					break;
				default:
					if (!char.IsDigit((char)num))
					{
						GenericInstSpec genericInstSpec = new GenericInstSpec();
						while (true)
						{
							SkipWhite();
							num = PeekChar();
							bool flag = num == 91;
							if (num == 93)
							{
								break;
							}
							TypeNameParser.Verify(!flag || ReadChar() == 91, "Expected '['");
							genericInstSpec.args.Add(ReadType(flag));
							SkipWhite();
							TypeNameParser.Verify(!flag || ReadChar() == 93, "Expected ']'");
							SkipWhite();
							if (PeekChar() != 44)
							{
								break;
							}
							ReadChar();
						}
						TypeNameParser.Verify(ReadChar() == 93, "Expected ']'");
						list.Add(genericInstSpec);
						break;
					}
					goto case 42;
				case 42:
				case 44:
				case 45:
				{
					ArraySpec arraySpec = new ArraySpec();
					arraySpec.rank = 0u;
					while (true)
					{
						SkipWhite();
						int num2 = PeekChar();
						switch (num2)
						{
						case 42:
							ReadChar();
							break;
						default:
							if (num2 == 93)
							{
								break;
							}
							if (num2 == 45 || char.IsDigit((char)num2))
							{
								int num3 = ReadInt32();
								SkipWhite();
								TypeNameParser.Verify(ReadChar() == 46, "Expected '.'");
								TypeNameParser.Verify(ReadChar() == 46, "Expected '.'");
								uint? num4;
								if (PeekChar() == 46)
								{
									ReadChar();
									num4 = null;
								}
								else
								{
									SkipWhite();
									if (PeekChar() == 45)
									{
										int num5 = ReadInt32();
										TypeNameParser.Verify(num5 >= num3, "upper < lower");
										num4 = (uint)(num5 - num3 + 1);
										TypeNameParser.Verify(num4.Value != 0 && num4.Value <= 536870911, "Invalid size");
									}
									else
									{
										uint num6 = ReadUInt32();
										long num7 = num6 - num3 + 1;
										TypeNameParser.Verify(num7 > 0 && num7 <= 536870911, "Invalid size");
										num4 = (uint)num7;
									}
								}
								if (arraySpec.lowerBounds.Count == arraySpec.rank)
								{
									arraySpec.lowerBounds.Add(num3);
								}
								if (num4.HasValue && arraySpec.sizes.Count == arraySpec.rank)
								{
									arraySpec.sizes.Add(num4.Value);
								}
							}
							else
							{
								TypeNameParser.Verify(b: false, "Unknown char");
							}
							break;
						case 44:
							break;
						}
						arraySpec.rank++;
						SkipWhite();
						if (PeekChar() != 44)
						{
							break;
						}
						ReadChar();
					}
					TypeNameParser.Verify(ReadChar() == 93, "Expected ']'");
					list.Add(arraySpec);
					break;
				}
				}
				break;
			}
			case 38:
				ReadChar();
				list.Add(ByRefSpec.Instance);
				break;
			case 42:
				ReadChar();
				list.Add(PtrSpec.Instance);
				break;
			default:
				return list;
			}
		}
	}

	private AssemblyRef ReadAssemblyRef()
	{
		AssemblyRefUser assemblyRefUser = new AssemblyRefUser();
		if (ownerModule != null)
		{
			ownerModule.UpdateRowId(assemblyRefUser);
		}
		assemblyRefUser.Name = ReadAssemblyNameId();
		SkipWhite();
		if (PeekChar() != 44)
		{
			return assemblyRefUser;
		}
		ReadChar();
		while (true)
		{
			SkipWhite();
			int num = PeekChar();
			if (num == -1 || num == 93)
			{
				break;
			}
			if (num == 44)
			{
				ReadChar();
				continue;
			}
			string text = ReadId();
			SkipWhite();
			if (PeekChar() != 61)
			{
				continue;
			}
			ReadChar();
			string text2 = ReadId();
			switch (text.ToUpperInvariant())
			{
			case "VERSION":
				assemblyRefUser.Version = Utils.ParseVersion(text2);
				break;
			case "CONTENTTYPE":
				if (text2.Equals("WindowsRuntime", StringComparison.OrdinalIgnoreCase))
				{
					assemblyRefUser.ContentType = AssemblyAttributes.ContentType_WindowsRuntime;
				}
				else
				{
					assemblyRefUser.ContentType = AssemblyAttributes.None;
				}
				break;
			case "RETARGETABLE":
				if (text2.Equals("Yes", StringComparison.OrdinalIgnoreCase))
				{
					assemblyRefUser.IsRetargetable = true;
				}
				else
				{
					assemblyRefUser.IsRetargetable = false;
				}
				break;
			case "PUBLICKEY":
				if (text2.Equals("null", StringComparison.OrdinalIgnoreCase) || text2.Equals("neutral", StringComparison.OrdinalIgnoreCase))
				{
					assemblyRefUser.PublicKeyOrToken = new PublicKey();
				}
				else
				{
					assemblyRefUser.PublicKeyOrToken = PublicKeyBase.CreatePublicKey(Utils.ParseBytes(text2));
				}
				break;
			case "PUBLICKEYTOKEN":
				if (text2.Equals("null", StringComparison.OrdinalIgnoreCase) || text2.Equals("neutral", StringComparison.OrdinalIgnoreCase))
				{
					assemblyRefUser.PublicKeyOrToken = new PublicKeyToken();
				}
				else
				{
					assemblyRefUser.PublicKeyOrToken = PublicKeyBase.CreatePublicKeyToken(Utils.ParseBytes(text2));
				}
				break;
			case "CULTURE":
			case "LANGUAGE":
				if (text2.Equals("neutral", StringComparison.OrdinalIgnoreCase))
				{
					assemblyRefUser.Culture = UTF8String.Empty;
				}
				else
				{
					assemblyRefUser.Culture = text2;
				}
				break;
			}
		}
		return assemblyRefUser;
	}

	private string ReadAssemblyNameId()
	{
		SkipWhite();
		StringBuilder stringBuilder = new StringBuilder();
		int asmNameChar;
		while ((asmNameChar = GetAsmNameChar()) != -1)
		{
			stringBuilder.Append((char)asmNameChar);
		}
		string text = stringBuilder.ToString().Trim();
		TypeNameParser.Verify(text.Length > 0, "Expected an assembly name");
		return text;
	}

	private int GetAsmNameChar()
	{
		int num = PeekChar();
		if (num == -1)
		{
			return -1;
		}
		switch (num)
		{
		case 92:
			ReadChar();
			return ReadChar();
		case 44:
		case 93:
			return -1;
		default:
			return ReadChar();
		}
	}

	internal override int GetIdChar(bool ignoreWhiteSpace)
	{
		int num = PeekChar();
		if (num == -1)
		{
			return -1;
		}
		if (ignoreWhiteSpace && char.IsWhiteSpace((char)num))
		{
			return -1;
		}
		switch (num)
		{
		case 92:
			ReadChar();
			return ReadChar();
		case 38:
		case 42:
		case 43:
		case 44:
		case 61:
		case 91:
		case 93:
			return -1;
		default:
			return ReadChar();
		}
	}
}
