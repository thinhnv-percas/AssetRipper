using DevX.Cecil.Binary;
using DevX.Cecil.Cil;

namespace DevX.Cecil
{
	public sealed class MethodDefinition : MethodReference, IAnnotationProvider, ICustomAttributeProvider, IHasSecurity, IMemberDefinition, IMemberReference, IMetadataTokenProvider, IReflectionVisitable
	{
		public const string Cctor = ".cctor";

		public const string Ctor = ".ctor";

		private MethodAttributes m_attributes;

		private MethodImplAttributes m_implAttrs;

		private MethodSemanticsAttributes m_semAttrs;

		private SecurityDeclarationCollection m_secDecls;

		private CustomAttributeCollection m_customAttrs;

		private MethodBody m_body;

		private RVA m_rva;

		private OverrideCollection m_overrides;

		private PInvokeInfo m_pinvoke;

		private readonly ParameterDefinition m_this;

		public MethodAttributes Attributes
		{
			get
			{
				return m_attributes;
			}
			set
			{
				m_attributes = value;
			}
		}

		public MethodImplAttributes ImplAttributes
		{
			get
			{
				return m_implAttrs;
			}
			set
			{
				m_implAttrs = value;
			}
		}

		public MethodSemanticsAttributes SemanticsAttributes
		{
			get
			{
				return m_semAttrs;
			}
			set
			{
				m_semAttrs = value;
			}
		}

		public bool HasSecurityDeclarations => m_secDecls != null && m_secDecls.Count > 0;

		public SecurityDeclarationCollection SecurityDeclarations
		{
			get
			{
				if (m_secDecls == null)
				{
					m_secDecls = new SecurityDeclarationCollection(this);
				}
				return m_secDecls;
			}
		}

		public bool HasCustomAttributes => m_customAttrs != null && m_customAttrs.Count > 0;

		public CustomAttributeCollection CustomAttributes
		{
			get
			{
				if (m_customAttrs == null)
				{
					m_customAttrs = new CustomAttributeCollection(this);
				}
				return m_customAttrs;
			}
		}

		public RVA RVA
		{
			get
			{
				return m_rva;
			}
			set
			{
				m_rva = value;
			}
		}

		public MethodBody Body
		{
			get
			{
				LoadBody();
				return m_body;
			}
			set
			{
				m_body = value;
			}
		}

		public PInvokeInfo PInvokeInfo
		{
			get
			{
				return m_pinvoke;
			}
			set
			{
				m_pinvoke = value;
			}
		}

		public bool HasOverrides => m_overrides != null && m_overrides.Count > 0;

		public OverrideCollection Overrides
		{
			get
			{
				if (m_overrides == null)
				{
					m_overrides = new OverrideCollection(this);
				}
				return m_overrides;
			}
		}

		public ParameterDefinition This => m_this;

		public bool IsCompilerControlled
		{
			get
			{
				return (m_attributes & MethodAttributes.MemberAccessMask) == MethodAttributes.Compilercontrolled;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~MethodAttributes.MemberAccessMask;
					m_attributes |= MethodAttributes.Compilercontrolled;
				}
				else
				{
					m_attributes &= (MethodAttributes.MemberAccessMask | MethodAttributes.Static | MethodAttributes.Final | MethodAttributes.Virtual | MethodAttributes.HideBySig | MethodAttributes.VtableLayoutMask | MethodAttributes.Strict | MethodAttributes.Abstract | MethodAttributes.SpecialName | MethodAttributes.PInvokeImpl | MethodAttributes.UnmanagedExport | MethodAttributes.RTSpecialName | MethodAttributes.HasSecurity | MethodAttributes.RequireSecObject);
				}
			}
		}

		public bool IsPrivate
		{
			get
			{
				return (m_attributes & MethodAttributes.MemberAccessMask) == MethodAttributes.Private;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~MethodAttributes.MemberAccessMask;
					m_attributes |= MethodAttributes.Private;
				}
				else
				{
					m_attributes &= ~MethodAttributes.Private;
				}
			}
		}

		public bool IsFamilyAndAssembly
		{
			get
			{
				return (m_attributes & MethodAttributes.MemberAccessMask) == MethodAttributes.FamANDAssem;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~MethodAttributes.MemberAccessMask;
					m_attributes |= MethodAttributes.FamANDAssem;
				}
				else
				{
					m_attributes &= ~MethodAttributes.FamANDAssem;
				}
			}
		}

		public bool IsAssembly
		{
			get
			{
				return (m_attributes & MethodAttributes.MemberAccessMask) == MethodAttributes.Assem;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~MethodAttributes.MemberAccessMask;
					m_attributes |= MethodAttributes.Assem;
				}
				else
				{
					m_attributes &= ~(MethodAttributes.Private | MethodAttributes.FamANDAssem);
				}
			}
		}

		public bool IsFamily
		{
			get
			{
				return (m_attributes & MethodAttributes.MemberAccessMask) == MethodAttributes.Family;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~MethodAttributes.MemberAccessMask;
					m_attributes |= MethodAttributes.Family;
				}
				else
				{
					m_attributes &= ~MethodAttributes.Family;
				}
			}
		}

		public bool IsFamilyOrAssembly
		{
			get
			{
				return (m_attributes & MethodAttributes.MemberAccessMask) == MethodAttributes.FamORAssem;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~MethodAttributes.MemberAccessMask;
					m_attributes |= MethodAttributes.FamORAssem;
				}
				else
				{
					m_attributes &= ~(MethodAttributes.Private | MethodAttributes.Family);
				}
			}
		}

		public bool IsPublic
		{
			get
			{
				return (m_attributes & MethodAttributes.MemberAccessMask) == MethodAttributes.Public;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~MethodAttributes.MemberAccessMask;
					m_attributes |= MethodAttributes.Public;
				}
				else
				{
					m_attributes &= ~(MethodAttributes.FamANDAssem | MethodAttributes.Family);
				}
			}
		}

		public bool IsStatic
		{
			get
			{
				return (m_attributes & MethodAttributes.Static) != MethodAttributes.Compilercontrolled;
			}
			set
			{
				if (value)
				{
					m_attributes |= MethodAttributes.Static;
				}
				else
				{
					m_attributes &= ~MethodAttributes.Static;
				}
			}
		}

		public bool IsFinal
		{
			get
			{
				return (m_attributes & MethodAttributes.Final) != MethodAttributes.Compilercontrolled;
			}
			set
			{
				if (value)
				{
					m_attributes |= MethodAttributes.Final;
				}
				else
				{
					m_attributes &= ~MethodAttributes.Final;
				}
			}
		}

		public bool IsVirtual
		{
			get
			{
				return (m_attributes & MethodAttributes.Virtual) != MethodAttributes.Compilercontrolled;
			}
			set
			{
				if (value)
				{
					m_attributes |= MethodAttributes.Virtual;
				}
				else
				{
					m_attributes &= ~MethodAttributes.Virtual;
				}
			}
		}

		public bool IsHideBySig
		{
			get
			{
				return (m_attributes & MethodAttributes.HideBySig) != MethodAttributes.Compilercontrolled;
			}
			set
			{
				if (value)
				{
					m_attributes |= MethodAttributes.HideBySig;
				}
				else
				{
					m_attributes &= ~MethodAttributes.HideBySig;
				}
			}
		}

		public bool IsReuseSlot
		{
			get
			{
				return (m_attributes & MethodAttributes.VtableLayoutMask) == MethodAttributes.Compilercontrolled;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~MethodAttributes.VtableLayoutMask;
					m_attributes |= MethodAttributes.Compilercontrolled;
				}
				else
				{
					m_attributes &= (MethodAttributes.MemberAccessMask | MethodAttributes.Static | MethodAttributes.Final | MethodAttributes.Virtual | MethodAttributes.HideBySig | MethodAttributes.VtableLayoutMask | MethodAttributes.Strict | MethodAttributes.Abstract | MethodAttributes.SpecialName | MethodAttributes.PInvokeImpl | MethodAttributes.UnmanagedExport | MethodAttributes.RTSpecialName | MethodAttributes.HasSecurity | MethodAttributes.RequireSecObject);
				}
			}
		}

		public bool IsNewSlot
		{
			get
			{
				return (m_attributes & MethodAttributes.VtableLayoutMask) == MethodAttributes.VtableLayoutMask;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~MethodAttributes.VtableLayoutMask;
					m_attributes |= MethodAttributes.VtableLayoutMask;
				}
				else
				{
					m_attributes &= ~MethodAttributes.VtableLayoutMask;
				}
			}
		}

		public bool IsStrict
		{
			get
			{
				return (m_attributes & MethodAttributes.Strict) != MethodAttributes.Compilercontrolled;
			}
			set
			{
				if (value)
				{
					m_attributes |= MethodAttributes.Strict;
				}
				else
				{
					m_attributes &= ~MethodAttributes.Strict;
				}
			}
		}

		public bool IsAbstract
		{
			get
			{
				return (m_attributes & MethodAttributes.Abstract) != MethodAttributes.Compilercontrolled;
			}
			set
			{
				if (value)
				{
					m_attributes |= MethodAttributes.Abstract;
				}
				else
				{
					m_attributes &= ~MethodAttributes.Abstract;
				}
			}
		}

		public bool IsSpecialName
		{
			get
			{
				return (m_attributes & MethodAttributes.SpecialName) != MethodAttributes.Compilercontrolled;
			}
			set
			{
				if (value)
				{
					m_attributes |= MethodAttributes.SpecialName;
				}
				else
				{
					m_attributes &= ~MethodAttributes.SpecialName;
				}
			}
		}

		public bool IsPInvokeImpl
		{
			get
			{
				return (m_attributes & MethodAttributes.PInvokeImpl) != MethodAttributes.Compilercontrolled;
			}
			set
			{
				if (value)
				{
					m_attributes |= MethodAttributes.PInvokeImpl;
				}
				else
				{
					m_attributes &= ~MethodAttributes.PInvokeImpl;
				}
			}
		}

		public bool IsUnmanagedExport
		{
			get
			{
				return (m_attributes & MethodAttributes.UnmanagedExport) != MethodAttributes.Compilercontrolled;
			}
			set
			{
				if (value)
				{
					m_attributes |= MethodAttributes.UnmanagedExport;
				}
				else
				{
					m_attributes &= ~MethodAttributes.UnmanagedExport;
				}
			}
		}

		public bool IsRuntimeSpecialName
		{
			get
			{
				return (m_attributes & MethodAttributes.RTSpecialName) != MethodAttributes.Compilercontrolled;
			}
			set
			{
				if (value)
				{
					m_attributes |= MethodAttributes.RTSpecialName;
				}
				else
				{
					m_attributes &= ~MethodAttributes.RTSpecialName;
				}
			}
		}

		public bool HasSecurity
		{
			get
			{
				return (m_attributes & MethodAttributes.HasSecurity) != MethodAttributes.Compilercontrolled;
			}
			set
			{
				if (value)
				{
					m_attributes |= MethodAttributes.HasSecurity;
				}
				else
				{
					m_attributes &= ~MethodAttributes.HasSecurity;
				}
			}
		}

		public bool IsIL
		{
			get
			{
				return (m_implAttrs & MethodImplAttributes.CodeTypeMask) == MethodImplAttributes.IL;
			}
			set
			{
				if (value)
				{
					m_implAttrs &= ~MethodImplAttributes.CodeTypeMask;
					m_implAttrs |= MethodImplAttributes.IL;
				}
				else
				{
					m_implAttrs &= MethodImplAttributes.MaxMethodImplVal;
				}
			}
		}

		public bool IsNative
		{
			get
			{
				return (m_implAttrs & MethodImplAttributes.CodeTypeMask) == MethodImplAttributes.Native;
			}
			set
			{
				if (value)
				{
					m_implAttrs &= ~MethodImplAttributes.CodeTypeMask;
					m_implAttrs |= MethodImplAttributes.Native;
				}
				else
				{
					m_implAttrs &= ~MethodImplAttributes.Native;
				}
			}
		}

		public bool IsRuntime
		{
			get
			{
				return (m_implAttrs & MethodImplAttributes.CodeTypeMask) == MethodImplAttributes.CodeTypeMask;
			}
			set
			{
				if (value)
				{
					m_implAttrs &= ~MethodImplAttributes.CodeTypeMask;
					m_implAttrs |= MethodImplAttributes.CodeTypeMask;
				}
				else
				{
					m_implAttrs &= ~MethodImplAttributes.CodeTypeMask;
				}
			}
		}

		public bool IsUnmanaged
		{
			get
			{
				return (m_implAttrs & MethodImplAttributes.ManagedMask) == MethodImplAttributes.ManagedMask;
			}
			set
			{
				if (value)
				{
					m_implAttrs &= ~MethodImplAttributes.ManagedMask;
					m_implAttrs |= MethodImplAttributes.ManagedMask;
				}
				else
				{
					m_implAttrs &= ~MethodImplAttributes.ManagedMask;
				}
			}
		}

		public bool IsManaged
		{
			get
			{
				return (m_implAttrs & MethodImplAttributes.ManagedMask) == MethodImplAttributes.IL;
			}
			set
			{
				if (value)
				{
					m_implAttrs &= ~MethodImplAttributes.ManagedMask;
					m_implAttrs |= MethodImplAttributes.IL;
				}
				else
				{
					m_implAttrs &= MethodImplAttributes.MaxMethodImplVal;
				}
			}
		}

		public bool IsForwardRef
		{
			get
			{
				return (m_implAttrs & MethodImplAttributes.ForwardRef) != MethodImplAttributes.IL;
			}
			set
			{
				if (value)
				{
					m_implAttrs |= MethodImplAttributes.ForwardRef;
				}
				else
				{
					m_implAttrs &= ~MethodImplAttributes.ForwardRef;
				}
			}
		}

		public bool IsPreserveSig
		{
			get
			{
				return (m_implAttrs & MethodImplAttributes.PreserveSig) != MethodImplAttributes.IL;
			}
			set
			{
				if (value)
				{
					m_implAttrs |= MethodImplAttributes.PreserveSig;
				}
				else
				{
					m_implAttrs &= ~MethodImplAttributes.PreserveSig;
				}
			}
		}

		public bool IsInternalCall
		{
			get
			{
				return (m_implAttrs & MethodImplAttributes.InternalCall) != MethodImplAttributes.IL;
			}
			set
			{
				if (value)
				{
					m_implAttrs |= MethodImplAttributes.InternalCall;
				}
				else
				{
					m_implAttrs &= ~MethodImplAttributes.InternalCall;
				}
			}
		}

		public bool IsSynchronized
		{
			get
			{
				return (m_implAttrs & MethodImplAttributes.Synchronized) != MethodImplAttributes.IL;
			}
			set
			{
				if (value)
				{
					m_implAttrs |= MethodImplAttributes.Synchronized;
				}
				else
				{
					m_implAttrs &= ~MethodImplAttributes.Synchronized;
				}
			}
		}

		public bool NoInlining
		{
			get
			{
				return (m_implAttrs & MethodImplAttributes.NoInlining) != MethodImplAttributes.IL;
			}
			set
			{
				if (value)
				{
					m_implAttrs |= MethodImplAttributes.NoInlining;
				}
				else
				{
					m_implAttrs &= ~MethodImplAttributes.NoInlining;
				}
			}
		}

		public bool IsSetter
		{
			get
			{
				return (m_semAttrs & MethodSemanticsAttributes.Setter) != (MethodSemanticsAttributes)0;
			}
			set
			{
				if (value)
				{
					m_semAttrs |= MethodSemanticsAttributes.Setter;
				}
				else
				{
					m_semAttrs &= ~MethodSemanticsAttributes.Setter;
				}
			}
		}

		public bool IsGetter
		{
			get
			{
				return (m_semAttrs & MethodSemanticsAttributes.Getter) != (MethodSemanticsAttributes)0;
			}
			set
			{
				if (value)
				{
					m_semAttrs |= MethodSemanticsAttributes.Getter;
				}
				else
				{
					m_semAttrs &= ~MethodSemanticsAttributes.Getter;
				}
			}
		}

		public bool IsOther
		{
			get
			{
				return (m_semAttrs & MethodSemanticsAttributes.Other) != (MethodSemanticsAttributes)0;
			}
			set
			{
				if (value)
				{
					m_semAttrs |= MethodSemanticsAttributes.Other;
				}
				else
				{
					m_semAttrs &= ~MethodSemanticsAttributes.Other;
				}
			}
		}

		public bool IsAddOn
		{
			get
			{
				return (m_semAttrs & MethodSemanticsAttributes.AddOn) != (MethodSemanticsAttributes)0;
			}
			set
			{
				if (value)
				{
					m_semAttrs |= MethodSemanticsAttributes.AddOn;
				}
				else
				{
					m_semAttrs &= ~MethodSemanticsAttributes.AddOn;
				}
			}
		}

		public bool IsRemoveOn
		{
			get
			{
				return (m_semAttrs & MethodSemanticsAttributes.RemoveOn) != (MethodSemanticsAttributes)0;
			}
			set
			{
				if (value)
				{
					m_semAttrs |= MethodSemanticsAttributes.RemoveOn;
				}
				else
				{
					m_semAttrs &= ~MethodSemanticsAttributes.RemoveOn;
				}
			}
		}

		public bool IsFire
		{
			get
			{
				return (m_semAttrs & MethodSemanticsAttributes.Fire) != (MethodSemanticsAttributes)0;
			}
			set
			{
				if (value)
				{
					m_semAttrs |= MethodSemanticsAttributes.Fire;
				}
				else
				{
					m_semAttrs &= ~MethodSemanticsAttributes.Fire;
				}
			}
		}

		public bool IsConstructor => IsRuntimeSpecialName && IsSpecialName && (Name == ".cctor" || Name == ".ctor");

		public bool HasBody => (m_attributes & MethodAttributes.Abstract) == MethodAttributes.Compilercontrolled && (m_attributes & MethodAttributes.PInvokeImpl) == MethodAttributes.Compilercontrolled && (m_implAttrs & MethodImplAttributes.InternalCall) == MethodImplAttributes.IL && (m_implAttrs & MethodImplAttributes.Native) == MethodImplAttributes.IL && (m_implAttrs & MethodImplAttributes.ManagedMask) == MethodImplAttributes.IL && (m_implAttrs & MethodImplAttributes.CodeTypeMask) == MethodImplAttributes.IL;

		public new TypeDefinition DeclaringType
		{
			get
			{
				return (TypeDefinition)base.DeclaringType;
			}
			set
			{
				base.DeclaringType = value;
			}
		}

		public MethodDefinition(string name, RVA rva, MethodAttributes attrs, MethodImplAttributes implAttrs, bool hasThis, bool explicitThis, MethodCallingConvention callConv)
			: base(name, hasThis, explicitThis, callConv)
		{
			m_rva = rva;
			m_attributes = attrs;
			m_implAttrs = implAttrs;
			if (!IsStatic)
			{
				m_this = new ParameterDefinition("this", 0, ParameterAttributes.None, null);
			}
		}

		internal MethodDefinition(string name, MethodAttributes attrs)
			: base(name)
		{
			m_attributes = attrs;
			HasThis = !IsStatic;
			if (!IsStatic)
			{
				m_this = new ParameterDefinition("this", 0, ParameterAttributes.None, null);
			}
		}

		public MethodDefinition(string name, MethodAttributes attrs, TypeReference returnType)
			: this(name, attrs)
		{
			ReturnType.ReturnType = returnType;
		}

		internal void LoadBody()
		{
			if (m_body == null && HasBody)
			{
				m_body = new MethodBody(this);
				ModuleDefinition moduleDefinition = (DeclaringType == null) ? null : DeclaringType.Module;
				if (moduleDefinition != null && m_rva != RVA.Zero)
				{
					moduleDefinition.Controller.Reader.Code.VisitMethodBody(m_body);
				}
			}
		}

		public override MethodDefinition Resolve()
		{
			return this;
		}

		public MethodDefinition Clone()
		{
			return Clone(this, new ImportContext(NullReferenceImporter.Instance, this));
		}

		internal static MethodDefinition Clone(MethodDefinition meth, ImportContext context)
		{
			MethodDefinition methodDefinition = new MethodDefinition(meth.Name, RVA.Zero, meth.Attributes, meth.ImplAttributes, meth.HasThis, meth.ExplicitThis, meth.CallingConvention);
			MethodReference method = context.GenericContext.Method;
			context.GenericContext.Method = methodDefinition;
			GenericParameter.CloneInto(meth, methodDefinition, context);
			methodDefinition.ReturnType.ReturnType = context.Import(meth.ReturnType.ReturnType);
			if (meth.ReturnType.Parameter != null)
			{
				methodDefinition.ReturnType.Parameter = ParameterDefinition.Clone(meth.ReturnType.Parameter, context);
				methodDefinition.ReturnType.Parameter.Method = methodDefinition;
			}
			if (meth.PInvokeInfo != null)
			{
				methodDefinition.PInvokeInfo = meth.PInvokeInfo;
			}
			if (meth.HasParameters)
			{
				foreach (ParameterDefinition parameter in meth.Parameters)
				{
					methodDefinition.Parameters.Add(ParameterDefinition.Clone(parameter, context));
				}
			}
			if (meth.HasOverrides)
			{
				foreach (MethodReference @override in meth.Overrides)
				{
					methodDefinition.Overrides.Add(context.Import(@override));
				}
			}
			if (meth.HasCustomAttributes)
			{
				foreach (CustomAttribute customAttribute in meth.CustomAttributes)
				{
					methodDefinition.CustomAttributes.Add(CustomAttribute.Clone(customAttribute, context));
				}
			}
			if (meth.HasSecurityDeclarations)
			{
				foreach (SecurityDeclaration securityDeclaration in meth.SecurityDeclarations)
				{
					methodDefinition.SecurityDeclarations.Add(SecurityDeclaration.Clone(securityDeclaration));
				}
			}
			if (meth.Body != null)
			{
				methodDefinition.Body = MethodBody.Clone(meth.Body, methodDefinition, context);
			}
			context.GenericContext.Method = method;
			return methodDefinition;
		}

		public override void Accept(IReflectionVisitor visitor)
		{
			visitor.VisitMethodDefinition(this);
			GenericParameters.Accept(visitor);
			Parameters.Accept(visitor);
			if (PInvokeInfo != null)
			{
				PInvokeInfo.Accept(visitor);
			}
			SecurityDeclarations.Accept(visitor);
			Overrides.Accept(visitor);
			CustomAttributes.Accept(visitor);
		}
	}
}
