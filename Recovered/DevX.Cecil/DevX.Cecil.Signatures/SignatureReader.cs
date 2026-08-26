using DevX.Cecil.Metadata;
using System;
using System.Collections;
using System.IO;
using System.Text;

namespace DevX.Cecil.Signatures
{
	internal sealed class SignatureReader : BaseSignatureVisitor
	{
		private MetadataRoot m_root;

		private ReflectionReader m_reflectReader;

		private byte[] m_blobData;

		private IDictionary m_signatures;

		private IAssemblyResolver AssemblyResolver => m_reflectReader.Module.Assembly.Resolver;

		public SignatureReader(MetadataRoot root, ReflectionReader reflectReader)
		{
			m_root = root;
			m_reflectReader = reflectReader;
			m_blobData = ((m_root.Streams.BlobHeap == null) ? new byte[0] : m_root.Streams.BlobHeap.Data);
			m_signatures = new Hashtable();
		}

		public FieldSig GetFieldSig(uint index)
		{
			FieldSig fieldSig = m_signatures[index] as FieldSig;
			if (fieldSig == null)
			{
				fieldSig = new FieldSig(index);
				fieldSig.Accept(this);
				m_signatures[index] = fieldSig;
			}
			return fieldSig;
		}

		public PropertySig GetPropSig(uint index)
		{
			PropertySig propertySig = m_signatures[index] as PropertySig;
			if (propertySig == null)
			{
				propertySig = new PropertySig(index);
				propertySig.Accept(this);
				m_signatures[index] = propertySig;
			}
			return propertySig;
		}

		public MethodDefSig GetMethodDefSig(uint index)
		{
			MethodDefSig methodDefSig = m_signatures[index] as MethodDefSig;
			if (methodDefSig == null)
			{
				methodDefSig = new MethodDefSig(index);
				methodDefSig.Accept(this);
				m_signatures[index] = methodDefSig;
			}
			return methodDefSig;
		}

		public MethodRefSig GetMethodRefSig(uint index)
		{
			MethodRefSig methodRefSig = m_signatures[index] as MethodRefSig;
			if (methodRefSig == null)
			{
				methodRefSig = new MethodRefSig(index);
				methodRefSig.Accept(this);
				m_signatures[index] = methodRefSig;
			}
			return methodRefSig;
		}

		public TypeSpec GetTypeSpec(uint index)
		{
			TypeSpec typeSpec = m_signatures[index] as TypeSpec;
			if (typeSpec == null)
			{
				typeSpec = ReadTypeSpec(m_blobData, (int)index);
				m_signatures[index] = typeSpec;
			}
			return typeSpec;
		}

		public MethodSpec GetMethodSpec(uint index)
		{
			MethodSpec methodSpec = m_signatures[index] as MethodSpec;
			if (methodSpec == null)
			{
				methodSpec = ReadMethodSpec(m_blobData, (int)index);
				m_signatures[index] = methodSpec;
			}
			return methodSpec;
		}

		public LocalVarSig GetLocalVarSig(uint index)
		{
			LocalVarSig localVarSig = m_signatures[index] as LocalVarSig;
			if (localVarSig == null)
			{
				localVarSig = new LocalVarSig(index);
				localVarSig.Accept(this);
				m_signatures[index] = localVarSig;
			}
			return localVarSig;
		}

		public CustomAttrib GetCustomAttrib(uint index, MethodReference ctor)
		{
			return GetCustomAttrib(index, ctor, resolve: false);
		}

		public CustomAttrib GetCustomAttrib(uint index, MethodReference ctor, bool resolve)
		{
			return ReadCustomAttrib((int)index, ctor, resolve);
		}

		public CustomAttrib GetCustomAttrib(byte[] data, MethodReference ctor)
		{
			return GetCustomAttrib(data, ctor, resolve: false);
		}

		public CustomAttrib GetCustomAttrib(byte[] data, MethodReference ctor, bool resolve)
		{
			BinaryReader br = new BinaryReader(new MemoryStream(data));
			return ReadCustomAttrib(br, data, ctor, resolve);
		}

		public Signature GetMemberRefSig(TokenType tt, uint index)
		{
			Utilities.ReadCompressedInteger(m_blobData, (int)index, out int start);
			int num = m_blobData[start];
			if ((num & 5) == 5 || (num & 0x10) == 16)
			{
				return GetMethodDefSig(index);
			}
			if ((num & 6) != 0)
			{
				return GetFieldSig(index);
			}
			switch (tt)
			{
			case TokenType.TypeRef:
			case TokenType.TypeDef:
			case TokenType.TypeSpec:
				return GetMethodRefSig(index);
			case TokenType.Method:
			case TokenType.ModuleRef:
				return GetMethodDefSig(index);
			default:
				return null;
			}
		}

		public MarshalSig GetMarshalSig(uint index)
		{
			MarshalSig marshalSig = m_signatures[index] as MarshalSig;
			if (marshalSig == null)
			{
				byte[] data = m_root.Streams.BlobHeap.Read(index);
				marshalSig = ReadMarshalSig(data);
				m_signatures[index] = marshalSig;
			}
			return marshalSig;
		}

		public MethodSig GetStandAloneMethodSig(uint index)
		{
			byte[] array = m_root.Streams.BlobHeap.Read(index);
			int start;
			if ((array[0] & 5) > 0)
			{
				MethodRefSig methodRefSig = new MethodRefSig(index);
				ReadMethodRefSig(methodRefSig, array, 0, out start);
				return methodRefSig;
			}
			MethodDefSig methodDefSig = new MethodDefSig(index);
			ReadMethodDefSig(methodDefSig, array, 0, out start);
			return methodDefSig;
		}

		public override void VisitMethodDefSig(MethodDefSig methodDef)
		{
			ReadMethodDefSig(methodDef, m_root.Streams.BlobHeap.Read(methodDef.BlobIndex), 0, out int _);
		}

		public override void VisitMethodRefSig(MethodRefSig methodRef)
		{
			ReadMethodRefSig(methodRef, m_root.Streams.BlobHeap.Read(methodRef.BlobIndex), 0, out int _);
		}

		public override void VisitFieldSig(FieldSig field)
		{
			Utilities.ReadCompressedInteger(m_blobData, (int)field.BlobIndex, out int start);
			field.CallingConvention = m_blobData[start];
			field.Field = ((field.CallingConvention & 6) != 0);
			field.CustomMods = ReadCustomMods(m_blobData, start + 1, out start);
			field.Type = ReadType(m_blobData, start, out start);
		}

		public override void VisitPropertySig(PropertySig property)
		{
			Utilities.ReadCompressedInteger(m_blobData, (int)property.BlobIndex, out int start);
			property.CallingConvention = m_blobData[start];
			property.Property = ((property.CallingConvention & 8) != 0);
			property.ParamCount = Utilities.ReadCompressedInteger(m_blobData, start + 1, out start);
			property.CustomMods = ReadCustomMods(m_blobData, start, out start);
			property.Type = ReadType(m_blobData, start, out start);
			property.Parameters = ReadParameters(property.ParamCount, m_blobData, start, out start);
		}

		public override void VisitLocalVarSig(LocalVarSig localvar)
		{
			Utilities.ReadCompressedInteger(m_blobData, (int)localvar.BlobIndex, out int start);
			localvar.CallingConvention = m_blobData[start];
			localvar.Local = ((localvar.CallingConvention & 7) != 0);
			localvar.Count = Utilities.ReadCompressedInteger(m_blobData, start + 1, out start);
			localvar.LocalVariables = ReadLocalVariables(localvar.Count, m_blobData, start);
		}

		private void ReadMethodDefSig(MethodDefSig methodDef, byte[] data, int pos, out int start)
		{
			methodDef.CallingConvention = data[pos];
			start = pos + 1;
			methodDef.HasThis = ((methodDef.CallingConvention & 0x20) != 0);
			methodDef.ExplicitThis = ((methodDef.CallingConvention & 0x40) != 0);
			if ((methodDef.CallingConvention & 5) != 0)
			{
				methodDef.MethCallConv |= MethodCallingConvention.VarArg;
			}
			else if ((methodDef.CallingConvention & 0x10) != 0)
			{
				methodDef.MethCallConv |= MethodCallingConvention.Generic;
				methodDef.GenericParameterCount = Utilities.ReadCompressedInteger(data, start, out start);
			}
			else
			{
				methodDef.MethCallConv |= MethodCallingConvention.Default;
			}
			methodDef.ParamCount = Utilities.ReadCompressedInteger(data, start, out start);
			methodDef.RetType = ReadRetType(data, start, out start);
			methodDef.Parameters = ReadParameters(methodDef.ParamCount, data, start, out start, out int sentinelpos);
			methodDef.Sentinel = sentinelpos;
		}

		private void ReadMethodRefSig(MethodRefSig methodRef, byte[] data, int pos, out int start)
		{
			methodRef.CallingConvention = data[pos];
			start = pos + 1;
			methodRef.HasThis = ((methodRef.CallingConvention & 0x20) != 0);
			methodRef.ExplicitThis = ((methodRef.CallingConvention & 0x40) != 0);
			if ((methodRef.CallingConvention & 1) != 0)
			{
				methodRef.MethCallConv |= MethodCallingConvention.C;
			}
			else if ((methodRef.CallingConvention & 2) != 0)
			{
				methodRef.MethCallConv |= MethodCallingConvention.StdCall;
			}
			else if ((methodRef.CallingConvention & 3) != 0)
			{
				methodRef.MethCallConv |= MethodCallingConvention.ThisCall;
			}
			else if ((methodRef.CallingConvention & 4) != 0)
			{
				methodRef.MethCallConv |= MethodCallingConvention.FastCall;
			}
			else if ((methodRef.CallingConvention & 5) != 0)
			{
				methodRef.MethCallConv |= MethodCallingConvention.VarArg;
			}
			else
			{
				methodRef.MethCallConv |= MethodCallingConvention.Default;
			}
			methodRef.ParamCount = Utilities.ReadCompressedInteger(data, start, out start);
			methodRef.RetType = ReadRetType(data, start, out start);
			methodRef.Parameters = ReadParameters(methodRef.ParamCount, data, start, out start, out int sentinelpos);
			methodRef.Sentinel = sentinelpos;
		}

		private LocalVarSig.LocalVariable[] ReadLocalVariables(int length, byte[] data, int pos)
		{
			int start = pos;
			LocalVarSig.LocalVariable[] array = new LocalVarSig.LocalVariable[length];
			for (int i = 0; i < length; i++)
			{
				array[i] = ReadLocalVariable(data, start, out start);
			}
			return array;
		}

		private LocalVarSig.LocalVariable ReadLocalVariable(byte[] data, int pos, out int start)
		{
			start = pos;
			LocalVarSig.LocalVariable result = default(LocalVarSig.LocalVariable);
			result.ByRef = false;
			while (true)
			{
				result.CustomMods = ReadCustomMods(data, start, out start);
				int pos2 = start;
				switch (Utilities.ReadCompressedInteger(data, start, out start))
				{
				case 69:
					result.Constraint |= Constraint.Pinned;
					break;
				case 16:
					result.ByRef = true;
					if (result.CustomMods == null || result.CustomMods.Length == 0)
					{
						result.CustomMods = ReadCustomMods(data, start, out start);
					}
					break;
				default:
					result.Type = ReadType(data, pos2, out start);
					return result;
				}
			}
		}

		private TypeSpec ReadTypeSpec(byte[] data, int pos)
		{
			int start = pos;
			Utilities.ReadCompressedInteger(data, start, out start);
			TypeSpec typeSpec = new TypeSpec();
			typeSpec.CustomMods = ReadCustomMods(data, start, out start);
			typeSpec.Type = ReadType(data, start, out start);
			return typeSpec;
		}

		private MethodSpec ReadMethodSpec(byte[] data, int pos)
		{
			int start = pos;
			Utilities.ReadCompressedInteger(data, start, out start);
			if (Utilities.ReadCompressedInteger(data, start, out start) != 10)
			{
				throw new ReflectionException("Invalid MethodSpec signature");
			}
			return new MethodSpec(ReadGenericInstSignature(data, start, out start));
		}

		private RetType ReadRetType(byte[] data, int pos, out int start)
		{
			RetType retType = new RetType();
			start = pos;
			retType.CustomMods = ReadCustomMods(data, start, out start);
			int pos2 = start;
			switch (Utilities.ReadCompressedInteger(data, start, out start))
			{
			case 1:
				retType.ByRef = (retType.TypedByRef = false);
				retType.Void = true;
				break;
			case 22:
				retType.ByRef = (retType.Void = false);
				retType.TypedByRef = true;
				break;
			case 16:
				retType.TypedByRef = (retType.Void = false);
				retType.ByRef = true;
				retType.CustomMods = CombineCustomMods(retType.CustomMods, ReadCustomMods(data, start, out start));
				retType.Type = ReadType(data, start, out start);
				break;
			default:
				retType.TypedByRef = (retType.Void = (retType.ByRef = false));
				retType.Type = ReadType(data, pos2, out start);
				break;
			}
			return retType;
		}

		private static CustomMod[] CombineCustomMods(CustomMod[] original, CustomMod[] next)
		{
			if (next == null || next.Length == 0)
			{
				return original;
			}
			CustomMod[] array = new CustomMod[original.Length + next.Length];
			Array.Copy(original, array, original.Length);
			Array.Copy(next, 0, array, original.Length, next.Length);
			return array;
		}

		private Param[] ReadParameters(int length, byte[] data, int pos, out int start)
		{
			Param[] array = new Param[length];
			start = pos;
			for (int i = 0; i < length; i++)
			{
				array[i] = ReadParameter(data, start, out start);
			}
			return array;
		}

		private Param[] ReadParameters(int length, byte[] data, int pos, out int start, out int sentinelpos)
		{
			Param[] array = new Param[length];
			start = pos;
			sentinelpos = -1;
			for (int i = 0; i < length; i++)
			{
				int pos2 = start;
				int num = Utilities.ReadCompressedInteger(data, start, out start);
				if (num == 65)
				{
					sentinelpos = i;
					pos2 = start;
				}
				array[i] = ReadParameter(data, pos2, out start);
			}
			return array;
		}

		private Param ReadParameter(byte[] data, int pos, out int start)
		{
			Param param = new Param();
			start = pos;
			param.CustomMods = ReadCustomMods(data, start, out start);
			int pos2 = start;
			switch (Utilities.ReadCompressedInteger(data, start, out start))
			{
			case 22:
				param.TypedByRef = true;
				param.ByRef = false;
				break;
			case 16:
				param.TypedByRef = false;
				param.ByRef = true;
				if (param.CustomMods == null || param.CustomMods.Length == 0)
				{
					param.CustomMods = ReadCustomMods(data, start, out start);
				}
				param.Type = ReadType(data, start, out start);
				break;
			default:
				param.TypedByRef = false;
				param.ByRef = false;
				param.Type = ReadType(data, pos2, out start);
				break;
			}
			return param;
		}

		private SigType ReadType(byte[] data, int pos, out int start)
		{
			start = pos;
			ElementType elementType = (ElementType)Utilities.ReadCompressedInteger(data, start, out start);
			switch (elementType)
			{
			case ElementType.ValueType:
			{
				VALUETYPE vALUETYPE = new VALUETYPE();
				vALUETYPE.Type = Utilities.GetMetadataToken(CodedIndex.TypeDefOrRef, (uint)Utilities.ReadCompressedInteger(data, start, out start));
				return vALUETYPE;
			}
			case ElementType.Class:
			{
				CLASS cLASS = new CLASS();
				cLASS.Type = Utilities.GetMetadataToken(CodedIndex.TypeDefOrRef, (uint)Utilities.ReadCompressedInteger(data, start, out start));
				return cLASS;
			}
			case ElementType.Ptr:
			{
				PTR pTR = new PTR();
				int num = start;
				int num2 = Utilities.ReadCompressedInteger(data, start, out start);
				pTR.Void = (num2 == 1);
				if (pTR.Void)
				{
					return pTR;
				}
				start = num;
				pTR.CustomMods = ReadCustomMods(data, start, out start);
				pTR.PtrType = ReadType(data, start, out start);
				return pTR;
			}
			case ElementType.FnPtr:
			{
				FNPTR fNPTR = new FNPTR();
				if ((data[start] & 5) != 0)
				{
					MethodRefSig methodRefSig = new MethodRefSig((uint)start);
					ReadMethodRefSig(methodRefSig, data, start, out start);
					fNPTR.Method = methodRefSig;
				}
				else
				{
					MethodDefSig methodDefSig = new MethodDefSig((uint)start);
					ReadMethodDefSig(methodDefSig, data, start, out start);
					fNPTR.Method = methodDefSig;
				}
				return fNPTR;
			}
			case ElementType.Array:
			{
				ARRAY aRRAY = new ARRAY();
				aRRAY.CustomMods = ReadCustomMods(data, start, out start);
				ArrayShape arrayShape = new ArrayShape();
				aRRAY.Type = ReadType(data, start, out start);
				arrayShape.Rank = Utilities.ReadCompressedInteger(data, start, out start);
				arrayShape.NumSizes = Utilities.ReadCompressedInteger(data, start, out start);
				arrayShape.Sizes = new int[arrayShape.NumSizes];
				for (int i = 0; i < arrayShape.NumSizes; i++)
				{
					arrayShape.Sizes[i] = Utilities.ReadCompressedInteger(data, start, out start);
				}
				arrayShape.NumLoBounds = Utilities.ReadCompressedInteger(data, start, out start);
				arrayShape.LoBounds = new int[arrayShape.NumLoBounds];
				for (int j = 0; j < arrayShape.NumLoBounds; j++)
				{
					arrayShape.LoBounds[j] = Utilities.ReadCompressedInteger(data, start, out start);
				}
				aRRAY.Shape = arrayShape;
				return aRRAY;
			}
			case ElementType.SzArray:
			{
				SZARRAY sZARRAY = new SZARRAY();
				sZARRAY.CustomMods = ReadCustomMods(data, start, out start);
				sZARRAY.Type = ReadType(data, start, out start);
				return sZARRAY;
			}
			case ElementType.Var:
				return new VAR(Utilities.ReadCompressedInteger(data, start, out start));
			case ElementType.MVar:
				return new MVAR(Utilities.ReadCompressedInteger(data, start, out start));
			case ElementType.GenericInst:
			{
				GENERICINST gENERICINST = new GENERICINST();
				gENERICINST.ValueType = (Utilities.ReadCompressedInteger(data, start, out start) == 17);
				gENERICINST.Type = Utilities.GetMetadataToken(CodedIndex.TypeDefOrRef, (uint)Utilities.ReadCompressedInteger(data, start, out start));
				gENERICINST.Signature = ReadGenericInstSignature(data, start, out start);
				return gENERICINST;
			}
			default:
				return new SigType(elementType);
			}
		}

		private GenericInstSignature ReadGenericInstSignature(byte[] data, int pos, out int start)
		{
			start = pos;
			GenericInstSignature genericInstSignature = new GenericInstSignature();
			genericInstSignature.Arity = Utilities.ReadCompressedInteger(data, start, out start);
			genericInstSignature.Types = new GenericArg[genericInstSignature.Arity];
			for (int i = 0; i < genericInstSignature.Arity; i++)
			{
				genericInstSignature.Types[i] = ReadGenericArg(data, start, out start);
			}
			return genericInstSignature;
		}

		private GenericArg ReadGenericArg(byte[] data, int pos, out int start)
		{
			start = pos;
			CustomMod[] customMods = ReadCustomMods(data, start, out start);
			GenericArg genericArg = new GenericArg(ReadType(data, start, out start));
			genericArg.CustomMods = customMods;
			return genericArg;
		}

		private CustomMod[] ReadCustomMods(byte[] data, int pos, out int start)
		{
			ArrayList arrayList = null;
			start = pos;
			while (true)
			{
				int num = start;
				if (num >= data.Length - 1)
				{
					break;
				}
				ElementType elementType = (ElementType)Utilities.ReadCompressedInteger(data, start, out start);
				start = num;
				if (elementType != ElementType.CModOpt && elementType != ElementType.CModReqD)
				{
					break;
				}
				if (arrayList == null)
				{
					arrayList = new ArrayList(2);
				}
				arrayList.Add(ReadCustomMod(data, start, out start));
			}
			return (arrayList != null) ? (arrayList.ToArray(typeof(CustomMod)) as CustomMod[]) : CustomMod.EmptyCustomMod;
		}

		private CustomMod ReadCustomMod(byte[] data, int pos, out int start)
		{
			CustomMod customMod = new CustomMod();
			start = pos;
			switch (Utilities.ReadCompressedInteger(data, start, out start))
			{
			case 32:
				customMod.CMOD = CustomMod.CMODType.OPT;
				break;
			case 31:
				customMod.CMOD = CustomMod.CMODType.REQD;
				break;
			default:
				customMod.CMOD = CustomMod.CMODType.None;
				break;
			}
			customMod.TypeDefOrRef = Utilities.GetMetadataToken(CodedIndex.TypeDefOrRef, (uint)Utilities.ReadCompressedInteger(data, start, out start));
			return customMod;
		}

		private CustomAttrib ReadCustomAttrib(int pos, MethodReference ctor, bool resolve)
		{
			int start;
			int num = Utilities.ReadCompressedInteger(m_blobData, pos, out start);
			byte[] array = new byte[num];
			Buffer.BlockCopy(m_blobData, start, array, 0, num);
			try
			{
				return ReadCustomAttrib(new BinaryReader(new MemoryStream(array)), array, ctor, resolve);
				IL_0040:
				CustomAttrib result;
				return result;
			}
			catch
			{
				CustomAttrib customAttrib = new CustomAttrib(ctor);
				customAttrib.Read = false;
				return customAttrib;
				IL_005c:
				CustomAttrib result;
				return result;
			}
		}

		private CustomAttrib ReadCustomAttrib(BinaryReader br, byte[] data, MethodReference ctor, bool resolve)
		{
			CustomAttrib customAttrib = new CustomAttrib(ctor);
			if (data.Length == 0)
			{
				customAttrib.FixedArgs = CustomAttrib.FixedArg.Empty;
				customAttrib.NamedArgs = CustomAttrib.NamedArg.Empty;
				return customAttrib;
			}
			bool read = true;
			customAttrib.Prolog = br.ReadUInt16();
			if (customAttrib.Prolog != 1)
			{
				throw new MetadataFormatException("Non standard prolog for custom attribute");
			}
			if (ctor.HasParameters)
			{
				customAttrib.FixedArgs = new CustomAttrib.FixedArg[ctor.Parameters.Count];
				for (int i = 0; i < customAttrib.FixedArgs.Length; i++)
				{
					if (!read)
					{
						break;
					}
					customAttrib.FixedArgs[i] = ReadFixedArg(data, br, ctor.Parameters[i].ParameterType, ref read, resolve);
				}
			}
			else
			{
				customAttrib.FixedArgs = CustomAttrib.FixedArg.Empty;
			}
			if (br.BaseStream.Position == br.BaseStream.Length)
			{
				read = false;
			}
			if (!read)
			{
				customAttrib.Read = read;
				return customAttrib;
			}
			customAttrib.NumNamed = br.ReadUInt16();
			if (customAttrib.NumNamed > 0)
			{
				customAttrib.NamedArgs = new CustomAttrib.NamedArg[customAttrib.NumNamed];
				for (int j = 0; j < customAttrib.NumNamed; j++)
				{
					if (!read)
					{
						break;
					}
					customAttrib.NamedArgs[j] = ReadNamedArg(data, br, ref read, resolve);
				}
			}
			else
			{
				customAttrib.NamedArgs = CustomAttrib.NamedArg.Empty;
			}
			customAttrib.Read = read;
			return customAttrib;
		}

		private CustomAttrib.FixedArg ReadFixedArg(byte[] data, BinaryReader br, TypeReference param, ref bool read, bool resolve)
		{
			CustomAttrib.FixedArg result = default(CustomAttrib.FixedArg);
			if (param is ArrayType)
			{
				param = ((ArrayType)param).ElementType;
				result.SzArray = true;
				result.NumElem = br.ReadUInt32();
				if (result.NumElem == 0 || result.NumElem == uint.MaxValue)
				{
					result.Elems = new CustomAttrib.Elem[0];
					result.NumElem = 0u;
					return result;
				}
				result.Elems = new CustomAttrib.Elem[result.NumElem];
				for (int i = 0; i < result.NumElem; i++)
				{
					result.Elems[i] = ReadElem(data, br, param, ref read, resolve);
				}
			}
			else
			{
				result.Elems = new CustomAttrib.Elem[1]
				{
					ReadElem(data, br, param, ref read, resolve)
				};
			}
			return result;
		}

		private TypeReference CreateEnumTypeReference(string enumName)
		{
			string text = null;
			int num = enumName.IndexOf(',');
			if (num != -1)
			{
				text = enumName.Substring(num + 1);
				enumName = enumName.Substring(0, num);
			}
			enumName = enumName.Replace('+', '/');
			AssemblyNameReference scope;
			if (text == null)
			{
				if (m_reflectReader.Module.Types.Contains(enumName))
				{
					return m_reflectReader.Module.Types[enumName];
				}
				scope = m_reflectReader.Corlib;
			}
			else
			{
				scope = AssemblyNameReference.Parse(text);
			}
			string[] array = enumName.Split('/');
			string text2 = array[0];
			string ns = null;
			int num2 = text2.LastIndexOf('.');
			if (num2 != -1)
			{
				ns = text2.Substring(0, num2);
			}
			string name = text2.Substring(num2 + 1);
			TypeReference typeReference = new TypeReference(name, ns, scope);
			for (int i = 1; i < array.Length; i++)
			{
				TypeReference typeReference2 = new TypeReference(array[i], null, scope);
				typeReference2.Module = m_reflectReader.Module;
				typeReference2.DeclaringType = typeReference;
				typeReference = typeReference2;
			}
			typeReference.Module = m_reflectReader.Module;
			typeReference.IsValueType = true;
			return typeReference;
		}

		private TypeReference ReadTypeReference(byte[] data, BinaryReader br, out ElementType elemType)
		{
			bool flag = false;
			elemType = (ElementType)br.ReadByte();
			if (elemType == ElementType.SzArray)
			{
				elemType = (ElementType)br.ReadByte();
				flag = true;
			}
			TypeReference typeReference = (elemType != ElementType.Enum) ? TypeReferenceFromElemType(elemType) : CreateEnumTypeReference(ReadUTF8String(data, br));
			if (flag)
			{
				typeReference = new ArrayType(typeReference);
			}
			return typeReference;
		}

		private TypeReference TypeReferenceFromElemType(ElementType elemType)
		{
			switch (elemType)
			{
			case ElementType.Object:
			case ElementType.Boxed:
				return m_reflectReader.SearchCoreType("System.Object");
			case ElementType.String:
				return m_reflectReader.SearchCoreType("System.String");
			case ElementType.Type:
				return m_reflectReader.SearchCoreType("System.Type");
			case ElementType.Boolean:
				return m_reflectReader.SearchCoreType("System.Boolean");
			case ElementType.Char:
				return m_reflectReader.SearchCoreType("System.Char");
			case ElementType.R4:
				return m_reflectReader.SearchCoreType("System.Single");
			case ElementType.R8:
				return m_reflectReader.SearchCoreType("System.Double");
			case ElementType.I1:
				return m_reflectReader.SearchCoreType("System.SByte");
			case ElementType.I2:
				return m_reflectReader.SearchCoreType("System.Int16");
			case ElementType.I4:
				return m_reflectReader.SearchCoreType("System.Int32");
			case ElementType.I8:
				return m_reflectReader.SearchCoreType("System.Int64");
			case ElementType.U1:
				return m_reflectReader.SearchCoreType("System.Byte");
			case ElementType.U2:
				return m_reflectReader.SearchCoreType("System.UInt16");
			case ElementType.U4:
				return m_reflectReader.SearchCoreType("System.UInt32");
			case ElementType.U8:
				return m_reflectReader.SearchCoreType("System.UInt64");
			default:
				throw new MetadataFormatException("Non valid type in CustomAttrib.Elem: 0x{0}", ((byte)elemType).ToString("x2"));
			}
		}

		internal CustomAttrib.NamedArg ReadNamedArg(byte[] data, BinaryReader br, ref bool read, bool resolve)
		{
			CustomAttrib.NamedArg result = default(CustomAttrib.NamedArg);
			byte b = br.ReadByte();
			switch (b)
			{
			case 83:
				result.Field = true;
				result.Property = false;
				break;
			case 84:
				result.Field = false;
				result.Property = true;
				break;
			default:
				throw new MetadataFormatException("Wrong kind of namedarg found: 0x" + b.ToString("x2"));
			}
			TypeReference param = ReadTypeReference(data, br, out result.FieldOrPropType);
			result.FieldOrPropName = ReadUTF8String(data, br);
			result.FixedArg = ReadFixedArg(data, br, param, ref read, resolve);
			return result;
		}

		private CustomAttrib.Elem ReadElem(byte[] data, BinaryReader br, TypeReference elemType, ref bool read, bool resolve)
		{
			CustomAttrib.Elem elem = default(CustomAttrib.Elem);
			string fullName = elemType.FullName;
			if (fullName == "System.Object")
			{
				elemType = ReadTypeReference(data, br, out elem.FieldOrPropType);
				if (elemType is ArrayType)
				{
					read = false;
					return elem;
				}
				if (elemType.FullName == "System.Object")
				{
					throw new MetadataFormatException("Non valid type in CustomAttrib.Elem after boxed prefix: 0x{0}", ((byte)elem.FieldOrPropType).ToString("x2"));
				}
				elem = ReadElem(data, br, elemType, ref read, resolve);
				elem.String = (elem.Simple = (elem.Type = false));
				elem.BoxedValueType = true;
				return elem;
			}
			elem.ElemType = elemType;
			if (fullName == "System.Type" || fullName == "System.String")
			{
				switch (elemType.FullName)
				{
				case "System.String":
					elem.String = true;
					elem.BoxedValueType = (elem.Simple = (elem.Type = false));
					break;
				case "System.Type":
					elem.Type = true;
					elem.BoxedValueType = (elem.Simple = (elem.String = false));
					break;
				}
				if (data[br.BaseStream.Position] == byte.MaxValue)
				{
					elem.Value = null;
					br.BaseStream.Position++;
				}
				else
				{
					elem.Value = ReadUTF8String(data, br);
				}
				return elem;
			}
			elem.String = (elem.Type = (elem.BoxedValueType = false));
			if (!ReadSimpleValue(br, ref elem, elem.ElemType))
			{
				if (!resolve)
				{
					read = false;
					return elem;
				}
				TypeReference enumUnderlyingType = GetEnumUnderlyingType(elem.ElemType, resolve);
				if (enumUnderlyingType == null || !ReadSimpleValue(br, ref elem, enumUnderlyingType))
				{
					read = false;
				}
			}
			return elem;
		}

		private TypeReference GetEnumUnderlyingType(TypeReference enumType, bool resolve)
		{
			TypeDefinition typeDefinition = enumType as TypeDefinition;
			if (typeDefinition == null && resolve && AssemblyResolver != null)
			{
				if (enumType.Scope is ModuleDefinition)
				{
					throw new NotSupportedException();
				}
				AssemblyDefinition assemblyDefinition = AssemblyResolver.Resolve(((AssemblyNameReference)enumType.Scope).FullName);
				if (assemblyDefinition != null)
				{
					typeDefinition = assemblyDefinition.MainModule.Types[enumType.FullName];
				}
			}
			if (typeDefinition != null && typeDefinition.IsEnum)
			{
				return typeDefinition.Fields.GetField("value__").FieldType;
			}
			return null;
		}

		private bool ReadSimpleValue(BinaryReader br, ref CustomAttrib.Elem elem, TypeReference type)
		{
			switch (type.FullName)
			{
			case "System.Boolean":
				elem.Value = (br.ReadByte() == 1);
				break;
			case "System.Char":
				elem.Value = (char)br.ReadUInt16();
				break;
			case "System.Single":
				elem.Value = br.ReadSingle();
				break;
			case "System.Double":
				elem.Value = br.ReadDouble();
				break;
			case "System.Byte":
				elem.Value = br.ReadByte();
				break;
			case "System.Int16":
				elem.Value = br.ReadInt16();
				break;
			case "System.Int32":
				elem.Value = br.ReadInt32();
				break;
			case "System.Int64":
				elem.Value = br.ReadInt64();
				break;
			case "System.SByte":
				elem.Value = br.ReadSByte();
				break;
			case "System.UInt16":
				elem.Value = br.ReadUInt16();
				break;
			case "System.UInt32":
				elem.Value = br.ReadUInt32();
				break;
			case "System.UInt64":
				elem.Value = br.ReadUInt64();
				break;
			default:
				return false;
			}
			elem.Simple = true;
			return true;
		}

		private MarshalSig ReadMarshalSig(byte[] data)
		{
			int start;
			MarshalSig marshalSig = new MarshalSig((NativeType)Utilities.ReadCompressedInteger(data, 0, out start));
			switch (marshalSig.NativeInstrinsic)
			{
			case NativeType.ARRAY:
			{
				MarshalSig.Array array = new MarshalSig.Array();
				array.ArrayElemType = (NativeType)Utilities.ReadCompressedInteger(data, start, out start);
				if (start < data.Length)
				{
					array.ParamNum = Utilities.ReadCompressedInteger(data, start, out start);
				}
				if (start < data.Length)
				{
					array.NumElem = Utilities.ReadCompressedInteger(data, start, out start);
				}
				if (start < data.Length)
				{
					array.ElemMult = Utilities.ReadCompressedInteger(data, start, out start);
				}
				marshalSig.Spec = array;
				break;
			}
			case NativeType.CUSTOMMARSHALER:
			{
				MarshalSig.CustomMarshaler customMarshaler = new MarshalSig.CustomMarshaler();
				customMarshaler.Guid = ReadUTF8String(data, start, out start);
				customMarshaler.UnmanagedType = ReadUTF8String(data, start, out start);
				customMarshaler.ManagedType = ReadUTF8String(data, start, out start);
				customMarshaler.Cookie = ReadUTF8String(data, start, out start);
				marshalSig.Spec = customMarshaler;
				break;
			}
			case NativeType.FIXEDARRAY:
			{
				MarshalSig.FixedArray fixedArray = new MarshalSig.FixedArray();
				fixedArray.NumElem = Utilities.ReadCompressedInteger(data, start, out start);
				if (start < data.Length)
				{
					fixedArray.ArrayElemType = (NativeType)Utilities.ReadCompressedInteger(data, start, out start);
				}
				marshalSig.Spec = fixedArray;
				break;
			}
			case NativeType.SAFEARRAY:
			{
				MarshalSig.SafeArray safeArray = new MarshalSig.SafeArray();
				if (start < data.Length)
				{
					safeArray.ArrayElemType = (VariantType)Utilities.ReadCompressedInteger(data, start, out start);
				}
				marshalSig.Spec = safeArray;
				break;
			}
			case NativeType.FIXEDSYSSTRING:
			{
				MarshalSig.FixedSysString fixedSysString = new MarshalSig.FixedSysString();
				if (start < data.Length)
				{
					fixedSysString.Size = Utilities.ReadCompressedInteger(data, start, out start);
				}
				marshalSig.Spec = fixedSysString;
				break;
			}
			}
			return marshalSig;
		}

		internal static string ReadUTF8String(byte[] data, BinaryReader br)
		{
			int start = (int)br.BaseStream.Position;
			string result = ReadUTF8String(data, start, out start);
			br.BaseStream.Position = start;
			return result;
		}

		internal static string ReadUTF8String(byte[] data, int pos, out int start)
		{
			int num = Utilities.ReadCompressedInteger(data, pos, out start);
			pos = start;
			start += num;
			return Encoding.UTF8.GetString(data, pos, num);
		}
	}
}
