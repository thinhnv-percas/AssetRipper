using DevX.Cecil.Binary;
using DevX.Cecil.Metadata;
using System;
using System.Text;

namespace DevX.Cecil.Signatures
{
	internal sealed class SignatureWriter : BaseSignatureVisitor
	{
		private MetadataWriter m_mdWriter;

		private MemoryBinaryWriter m_sigWriter;

		public SignatureWriter(MetadataWriter mdWriter)
		{
			m_mdWriter = mdWriter;
			m_sigWriter = new MemoryBinaryWriter();
		}

		private uint GetPointer()
		{
			return m_mdWriter.AddBlob(m_sigWriter.ToArray());
		}

		public uint AddMethodDefSig(MethodDefSig methSig)
		{
			return AddSignature(methSig);
		}

		public uint AddMethodRefSig(MethodRefSig methSig)
		{
			return AddSignature(methSig);
		}

		public uint AddPropertySig(PropertySig ps)
		{
			return AddSignature(ps);
		}

		public uint AddFieldSig(FieldSig fSig)
		{
			return AddSignature(fSig);
		}

		public uint AddLocalVarSig(LocalVarSig lvs)
		{
			return AddSignature(lvs);
		}

		private uint AddSignature(Signature s)
		{
			m_sigWriter.Empty();
			s.Accept(this);
			return GetPointer();
		}

		public uint AddTypeSpec(TypeSpec ts)
		{
			m_sigWriter.Empty();
			Write(ts);
			return GetPointer();
		}

		public uint AddMethodSpec(MethodSpec ms)
		{
			m_sigWriter.Empty();
			Write(ms);
			return GetPointer();
		}

		public uint AddMarshalSig(MarshalSig ms)
		{
			m_sigWriter.Empty();
			Write(ms);
			return GetPointer();
		}

		public uint AddCustomAttribute(CustomAttrib ca, MethodReference ctor)
		{
			CompressCustomAttribute(ca, ctor, m_sigWriter);
			return GetPointer();
		}

		public byte[] CompressCustomAttribute(CustomAttrib ca, MethodReference ctor)
		{
			MemoryBinaryWriter memoryBinaryWriter = new MemoryBinaryWriter();
			CompressCustomAttribute(ca, ctor, memoryBinaryWriter);
			return memoryBinaryWriter.ToArray();
		}

		public byte[] CompressFieldSig(FieldSig field)
		{
			m_sigWriter.Empty();
			VisitFieldSig(field);
			return m_sigWriter.ToArray();
		}

		public byte[] CompressLocalVar(LocalVarSig.LocalVariable var)
		{
			m_sigWriter.Empty();
			Write(var);
			return m_sigWriter.ToArray();
		}

		private void CompressCustomAttribute(CustomAttrib ca, MethodReference ctor, MemoryBinaryWriter writer)
		{
			m_sigWriter.Empty();
			Write(ca, ctor, writer);
		}

		public override void VisitMethodDefSig(MethodDefSig methodDef)
		{
			m_sigWriter.Write(methodDef.CallingConvention);
			if (methodDef.GenericParameterCount > 0)
			{
				Write(methodDef.GenericParameterCount);
			}
			Write(methodDef.ParamCount);
			Write(methodDef.RetType);
			Write(methodDef.Parameters, methodDef.Sentinel);
		}

		public override void VisitMethodRefSig(MethodRefSig methodRef)
		{
			m_sigWriter.Write(methodRef.CallingConvention);
			Write(methodRef.ParamCount);
			Write(methodRef.RetType);
			Write(methodRef.Parameters, methodRef.Sentinel);
		}

		public override void VisitFieldSig(FieldSig field)
		{
			m_sigWriter.Write(field.CallingConvention);
			Write(field.CustomMods);
			Write(field.Type);
		}

		public override void VisitPropertySig(PropertySig property)
		{
			m_sigWriter.Write(property.CallingConvention);
			Write(property.ParamCount);
			Write(property.CustomMods);
			Write(property.Type);
			Write(property.Parameters);
		}

		public override void VisitLocalVarSig(LocalVarSig localvar)
		{
			m_sigWriter.Write(localvar.CallingConvention);
			Write(localvar.Count);
			Write(localvar.LocalVariables);
		}

		private void Write(LocalVarSig.LocalVariable[] vars)
		{
			foreach (LocalVarSig.LocalVariable var in vars)
			{
				Write(var);
			}
		}

		private void Write(LocalVarSig.LocalVariable var)
		{
			Write(var.CustomMods);
			if ((var.Constraint & Constraint.Pinned) != 0)
			{
				Write(ElementType.Pinned);
			}
			if (var.ByRef)
			{
				Write(ElementType.ByRef);
			}
			Write(var.Type);
		}

		private void Write(RetType retType)
		{
			Write(retType.CustomMods);
			if (retType.Void)
			{
				Write(ElementType.Void);
			}
			else if (retType.TypedByRef)
			{
				Write(ElementType.TypedByRef);
			}
			else if (retType.ByRef)
			{
				Write(ElementType.ByRef);
				Write(retType.Type);
			}
			else
			{
				Write(retType.Type);
			}
		}

		private void Write(Param[] parameters, int sentinel)
		{
			for (int i = 0; i < parameters.Length; i++)
			{
				if (i == sentinel)
				{
					Write(ElementType.Sentinel);
				}
				Write(parameters[i]);
			}
		}

		private void Write(Param[] parameters)
		{
			foreach (Param p in parameters)
			{
				Write(p);
			}
		}

		private void Write(ElementType et)
		{
			Write((int)et);
		}

		private void Write(SigType t)
		{
			Write((int)t.ElementType);
			switch (t.ElementType)
			{
			case ElementType.ByRef:
			case ElementType.TypedByRef:
			case (ElementType)23:
			case ElementType.I:
			case ElementType.U:
			case (ElementType)26:
			case ElementType.Object:
				break;
			case ElementType.ValueType:
				Write((int)Utilities.CompressMetadataToken(CodedIndex.TypeDefOrRef, ((VALUETYPE)t).Type));
				break;
			case ElementType.Class:
				Write((int)Utilities.CompressMetadataToken(CodedIndex.TypeDefOrRef, ((CLASS)t).Type));
				break;
			case ElementType.Ptr:
			{
				PTR pTR = (PTR)t;
				if (pTR.Void)
				{
					Write(ElementType.Void);
					break;
				}
				Write(pTR.CustomMods);
				Write(pTR.PtrType);
				break;
			}
			case ElementType.FnPtr:
			{
				FNPTR fNPTR = (FNPTR)t;
				if (fNPTR.Method is MethodRefSig)
				{
					(fNPTR.Method as MethodRefSig).Accept(this);
				}
				else
				{
					(fNPTR.Method as MethodDefSig).Accept(this);
				}
				break;
			}
			case ElementType.Array:
			{
				ARRAY aRRAY = (ARRAY)t;
				Write(aRRAY.CustomMods);
				ArrayShape shape = aRRAY.Shape;
				Write(aRRAY.Type);
				Write(shape.Rank);
				Write(shape.NumSizes);
				int[] sizes = shape.Sizes;
				foreach (int i2 in sizes)
				{
					Write(i2);
				}
				Write(shape.NumLoBounds);
				int[] loBounds = shape.LoBounds;
				foreach (int i3 in loBounds)
				{
					Write(i3);
				}
				break;
			}
			case ElementType.SzArray:
			{
				SZARRAY sZARRAY = (SZARRAY)t;
				Write(sZARRAY.CustomMods);
				Write(sZARRAY.Type);
				break;
			}
			case ElementType.Var:
				Write(((VAR)t).Index);
				break;
			case ElementType.MVar:
				Write(((MVAR)t).Index);
				break;
			case ElementType.GenericInst:
			{
				GENERICINST gENERICINST = t as GENERICINST;
				Write((!gENERICINST.ValueType) ? ElementType.Class : ElementType.ValueType);
				Write((int)Utilities.CompressMetadataToken(CodedIndex.TypeDefOrRef, gENERICINST.Type));
				Write(gENERICINST.Signature);
				break;
			}
			}
		}

		private void Write(TypeSpec ts)
		{
			Write(ts.CustomMods);
			Write(ts.Type);
		}

		private void Write(MethodSpec ms)
		{
			Write(10);
			Write(ms.Signature);
		}

		private void Write(GenericInstSignature gis)
		{
			Write(gis.Arity);
			for (int i = 0; i < gis.Arity; i++)
			{
				Write(gis.Types[i]);
			}
		}

		private void Write(GenericArg arg)
		{
			Write(arg.CustomMods);
			Write(arg.Type);
		}

		private void Write(Param p)
		{
			Write(p.CustomMods);
			if (p.TypedByRef)
			{
				Write(ElementType.TypedByRef);
			}
			else if (p.ByRef)
			{
				Write(ElementType.ByRef);
				Write(p.Type);
			}
			else
			{
				Write(p.Type);
			}
		}

		private void Write(CustomMod[] customMods)
		{
			foreach (CustomMod cm in customMods)
			{
				Write(cm);
			}
		}

		private void Write(CustomMod cm)
		{
			switch (cm.CMOD)
			{
			case CustomMod.CMODType.OPT:
				Write(ElementType.CModOpt);
				break;
			case CustomMod.CMODType.REQD:
				Write(ElementType.CModReqD);
				break;
			}
			Write((int)Utilities.CompressMetadataToken(CodedIndex.TypeDefOrRef, cm.TypeDefOrRef));
		}

		private void Write(MarshalSig ms)
		{
			Write((int)ms.NativeInstrinsic);
			switch (ms.NativeInstrinsic)
			{
			case NativeType.ARRAY:
			{
				MarshalSig.Array array = (MarshalSig.Array)ms.Spec;
				Write((int)array.ArrayElemType);
				if (array.ParamNum != -1)
				{
					Write(array.ParamNum);
				}
				if (array.NumElem != -1)
				{
					Write(array.NumElem);
				}
				if (array.ElemMult != -1)
				{
					Write(array.ElemMult);
				}
				break;
			}
			case NativeType.CUSTOMMARSHALER:
			{
				MarshalSig.CustomMarshaler customMarshaler = (MarshalSig.CustomMarshaler)ms.Spec;
				Write(customMarshaler.Guid);
				Write(customMarshaler.UnmanagedType);
				Write(customMarshaler.ManagedType);
				Write(customMarshaler.Cookie);
				break;
			}
			case NativeType.FIXEDARRAY:
			{
				MarshalSig.FixedArray fixedArray = (MarshalSig.FixedArray)ms.Spec;
				Write(fixedArray.NumElem);
				if (fixedArray.ArrayElemType != NativeType.NONE)
				{
					Write((int)fixedArray.ArrayElemType);
				}
				break;
			}
			case NativeType.SAFEARRAY:
				Write((int)((MarshalSig.SafeArray)ms.Spec).ArrayElemType);
				break;
			case NativeType.FIXEDSYSSTRING:
				Write(((MarshalSig.FixedSysString)ms.Spec).Size);
				break;
			}
		}

		private void Write(CustomAttrib ca, MethodReference ctor, MemoryBinaryWriter writer)
		{
			if (ca != null && ca.Prolog == 1)
			{
				writer.Write(ca.Prolog);
				for (int i = 0; i < ctor.Parameters.Count; i++)
				{
					Write(ca.FixedArgs[i], writer);
				}
				writer.Write(ca.NumNamed);
				for (int j = 0; j < ca.NumNamed; j++)
				{
					Write(ca.NamedArgs[j], writer);
				}
			}
		}

		private void Write(CustomAttrib.FixedArg fa, MemoryBinaryWriter writer)
		{
			if (fa.SzArray)
			{
				writer.Write(fa.NumElem);
			}
			CustomAttrib.Elem[] elems = fa.Elems;
			foreach (CustomAttrib.Elem elem in elems)
			{
				Write(elem, writer);
			}
		}

		private static string GetEnumFullName(TypeReference type)
		{
			string text = type.FullName;
			if (type.IsNested)
			{
				text = text.Replace('/', '+');
			}
			if (type is TypeDefinition)
			{
				return text;
			}
			return text + ", " + type.Module.Assembly.Name.FullName;
		}

		private void Write(CustomAttrib.NamedArg na, MemoryBinaryWriter writer)
		{
			if (na.Field)
			{
				writer.Write((byte)83);
			}
			else
			{
				if (!na.Property)
				{
					throw new MetadataFormatException("Unknown kind of namedarg");
				}
				writer.Write((byte)84);
			}
			if (na.FieldOrPropType == ElementType.Class)
			{
				na.FieldOrPropType = ElementType.Enum;
			}
			if (na.FixedArg.SzArray)
			{
				writer.Write((byte)29);
			}
			if (na.FieldOrPropType == ElementType.Object)
			{
				writer.Write((byte)81);
			}
			else
			{
				writer.Write((byte)na.FieldOrPropType);
			}
			if (na.FieldOrPropType == ElementType.Enum)
			{
				Write(GetEnumFullName(na.FixedArg.Elems[0].ElemType));
			}
			Write(na.FieldOrPropName);
			Write(na.FixedArg, writer);
		}

		private static ElementType GetElementTypeFromTypeCode(TypeCode tc)
		{
			switch (tc)
			{
			case TypeCode.Byte:
				return ElementType.U1;
			case TypeCode.SByte:
				return ElementType.I1;
			case TypeCode.Int16:
				return ElementType.I2;
			case TypeCode.UInt16:
				return ElementType.U2;
			case TypeCode.Int32:
				return ElementType.I4;
			case TypeCode.UInt32:
				return ElementType.U4;
			case TypeCode.Int64:
				return ElementType.I8;
			case TypeCode.UInt64:
				return ElementType.U8;
			default:
				throw new ArgumentException("tc");
			}
		}

		private void Write(CustomAttrib.Elem elem, MemoryBinaryWriter writer)
		{
			if (elem.String)
			{
				elem.FieldOrPropType = ElementType.String;
			}
			else if (elem.Type)
			{
				elem.FieldOrPropType = ElementType.Type;
			}
			if (elem.FieldOrPropType == ElementType.Class)
			{
				elem.FieldOrPropType = GetElementTypeFromTypeCode(Type.GetTypeCode(elem.Value.GetType()));
			}
			if (elem.BoxedValueType)
			{
				Write(elem.FieldOrPropType);
			}
			switch (elem.FieldOrPropType)
			{
			case ElementType.Boolean:
				writer.Write((byte)(((bool)elem.Value) ? 1 : 0));
				break;
			case ElementType.Char:
				writer.Write((ushort)(char)elem.Value);
				break;
			case ElementType.R4:
				writer.Write((float)elem.Value);
				break;
			case ElementType.R8:
				writer.Write((double)elem.Value);
				break;
			case ElementType.I1:
				writer.Write((sbyte)elem.Value);
				break;
			case ElementType.I2:
				writer.Write((short)elem.Value);
				break;
			case ElementType.I4:
				writer.Write((int)elem.Value);
				break;
			case ElementType.I8:
				writer.Write((long)elem.Value);
				break;
			case ElementType.U1:
				writer.Write((byte)elem.Value);
				break;
			case ElementType.U2:
				writer.Write((ushort)elem.Value);
				break;
			case ElementType.U4:
				writer.Write((uint)elem.Value);
				break;
			case ElementType.U8:
				writer.Write((ulong)elem.Value);
				break;
			case ElementType.String:
			case ElementType.Type:
			{
				string text = elem.Value as string;
				if (text == null)
				{
					writer.Write(byte.MaxValue);
				}
				else if (text.Length == 0)
				{
					writer.Write((byte)0);
				}
				else
				{
					Write(text);
				}
				break;
			}
			case ElementType.Object:
				if (elem.Value != null)
				{
					throw new NotSupportedException("Unknown state");
				}
				writer.Write(byte.MaxValue);
				break;
			default:
				throw new NotImplementedException("WriteElem " + elem.FieldOrPropType.ToString());
			}
		}

		private void Write(string s)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			Write(bytes.Length);
			m_sigWriter.Write(bytes);
		}

		private void Write(int i)
		{
			Utilities.WriteCompressedInteger(m_sigWriter, i);
		}
	}
}
