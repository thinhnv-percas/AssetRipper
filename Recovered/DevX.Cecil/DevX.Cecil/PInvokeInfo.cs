namespace DevX.Cecil
{
	public sealed class PInvokeInfo : IReflectionVisitable
	{
		private MethodDefinition m_meth;

		private PInvokeAttributes m_attributes;

		private string m_entryPoint;

		private ModuleReference m_module;

		public MethodDefinition Method => m_meth;

		public PInvokeAttributes Attributes
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

		public string EntryPoint
		{
			get
			{
				return m_entryPoint;
			}
			set
			{
				m_entryPoint = value;
			}
		}

		public ModuleReference Module
		{
			get
			{
				return m_module;
			}
			set
			{
				m_module = value;
			}
		}

		public bool IsNoMangle
		{
			get
			{
				return (m_attributes & PInvokeAttributes.NoMangle) != PInvokeAttributes.CharSetNotSpec;
			}
			set
			{
				if (value)
				{
					m_attributes |= PInvokeAttributes.NoMangle;
				}
				else
				{
					m_attributes &= ~PInvokeAttributes.NoMangle;
				}
			}
		}

		public bool IsCharSetNotSpec
		{
			get
			{
				return (m_attributes & PInvokeAttributes.CharSetMask) == PInvokeAttributes.CharSetNotSpec;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~PInvokeAttributes.CharSetMask;
					m_attributes |= PInvokeAttributes.CharSetNotSpec;
				}
				else
				{
					m_attributes &= (PInvokeAttributes)65535;
				}
			}
		}

		public bool IsCharSetAnsi
		{
			get
			{
				return (m_attributes & PInvokeAttributes.CharSetMask) == PInvokeAttributes.CharSetAnsi;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~PInvokeAttributes.CharSetMask;
					m_attributes |= PInvokeAttributes.CharSetAnsi;
				}
				else
				{
					m_attributes &= ~PInvokeAttributes.CharSetAnsi;
				}
			}
		}

		public bool IsCharSetUnicode
		{
			get
			{
				return (m_attributes & PInvokeAttributes.CharSetMask) == PInvokeAttributes.CharSetUnicode;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~PInvokeAttributes.CharSetMask;
					m_attributes |= PInvokeAttributes.CharSetUnicode;
				}
				else
				{
					m_attributes &= ~PInvokeAttributes.CharSetUnicode;
				}
			}
		}

		public bool IsCharSetAuto
		{
			get
			{
				return (m_attributes & PInvokeAttributes.CharSetMask) == PInvokeAttributes.CharSetMask;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~PInvokeAttributes.CharSetMask;
					m_attributes |= PInvokeAttributes.CharSetMask;
				}
				else
				{
					m_attributes &= ~PInvokeAttributes.CharSetMask;
				}
			}
		}

		public bool SupportsLastError
		{
			get
			{
				return (m_attributes & PInvokeAttributes.CharSetMask) == PInvokeAttributes.SupportsLastError;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~PInvokeAttributes.CharSetMask;
					m_attributes |= PInvokeAttributes.SupportsLastError;
				}
				else
				{
					m_attributes &= (PInvokeAttributes)65535;
				}
			}
		}

		public bool IsCallConvWinapi
		{
			get
			{
				return (m_attributes & PInvokeAttributes.CallConvMask) == PInvokeAttributes.CallConvWinapi;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~PInvokeAttributes.CallConvMask;
					m_attributes |= PInvokeAttributes.CallConvWinapi;
				}
				else
				{
					m_attributes &= ~PInvokeAttributes.CallConvWinapi;
				}
			}
		}

		public bool IsCallConvCdecl
		{
			get
			{
				return (m_attributes & PInvokeAttributes.CallConvMask) == PInvokeAttributes.CallConvCdecl;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~PInvokeAttributes.CallConvMask;
					m_attributes |= PInvokeAttributes.CallConvCdecl;
				}
				else
				{
					m_attributes &= ~PInvokeAttributes.CallConvCdecl;
				}
			}
		}

		public bool IsCallConvStdCall
		{
			get
			{
				return (m_attributes & PInvokeAttributes.CallConvMask) == PInvokeAttributes.CallConvStdCall;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~PInvokeAttributes.CallConvMask;
					m_attributes |= PInvokeAttributes.CallConvStdCall;
				}
				else
				{
					m_attributes &= ~(PInvokeAttributes.CallConvWinapi | PInvokeAttributes.CallConvCdecl);
				}
			}
		}

		public bool IsCallConvThiscall
		{
			get
			{
				return (m_attributes & PInvokeAttributes.CallConvMask) == PInvokeAttributes.CallConvThiscall;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~PInvokeAttributes.CallConvMask;
					m_attributes |= PInvokeAttributes.CallConvThiscall;
				}
				else
				{
					m_attributes &= ~PInvokeAttributes.CallConvThiscall;
				}
			}
		}

		public bool IsCallConvFastcall
		{
			get
			{
				return (m_attributes & PInvokeAttributes.CallConvMask) == PInvokeAttributes.CallConvFastcall;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~PInvokeAttributes.CallConvMask;
					m_attributes |= PInvokeAttributes.CallConvFastcall;
				}
				else
				{
					m_attributes &= ~(PInvokeAttributes.CallConvWinapi | PInvokeAttributes.CallConvThiscall);
				}
			}
		}

		public PInvokeInfo(MethodDefinition meth)
		{
			m_meth = meth;
		}

		public PInvokeInfo(MethodDefinition meth, PInvokeAttributes attrs, string entryPoint, ModuleReference mod)
			: this(meth)
		{
			m_attributes = attrs;
			m_entryPoint = entryPoint;
			m_module = mod;
		}

		public void Accept(IReflectionVisitor visitor)
		{
			visitor.VisitPInvokeInfo(this);
		}
	}
}
