using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SpirV
{
	public class Module
	{
		[StructLayout(LayoutKind.Explicit)]
		private struct _0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020
		{
			[FieldOffset(0)]
			public uint Int;

			[FieldOffset(0)]
			public float Float;
		}

		[StructLayout(LayoutKind.Explicit)]
		private struct _0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020_000A
		{
			[FieldOffset(0)]
			public ulong Long;

			[FieldOffset(0)]
			public double Double;
		}

		[CompilerGenerated]
		private readonly ModuleHeader _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020;

		[CompilerGenerated]
		private readonly IList<ParsedInstruction> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A;

		private static HashSet<string> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_0020 = new HashSet<string>
		{
			"OpSourceContinued",
			"OpSource",
			"OpSourceExtension",
			"OpName",
			"OpMemberName",
			"OpString",
			"OpLine",
			"OpNoLine",
			"OpModuleProcessed"
		};

		private readonly Dictionary<uint, ParsedInstruction> _0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_000A = new Dictionary<uint, ParsedInstruction>();

		public ModuleHeader Header
		{
			get;
		}

		public IList<ParsedInstruction> Instructions
		{
			get;
		}

		public Module(ModuleHeader header, IList<ParsedInstruction> instructions)
		{
			_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020 = header;
			_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A = instructions;
			_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A(Instructions, _0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_000A);
		}

		public static bool IsDebugInstruction(ParsedInstruction instruction)
		{
			return _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_0020.Contains(instruction.Instruction.Name);
		}

		private static void _0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A(IList<ParsedInstruction> _0020, Dictionary<uint, ParsedInstruction> _0020_000A)
		{
			List<ParsedInstruction> list = new List<ParsedInstruction>();
			List<ParsedInstruction> list2 = new List<ParsedInstruction>();
			foreach (ParsedInstruction item in _0020)
			{
				if (IsDebugInstruction(item))
				{
					list.Add(item);
				}
				else if (item.Instruction is OpEntryPoint)
				{
					list2.Add(item);
				}
				else
				{
					if (item.Instruction.Name.StartsWith("OpType", StringComparison.Ordinal))
					{
						_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020(item, _0020_000A);
					}
					item.ResolveResultType(_0020_000A);
					if (item.HasResult)
					{
						_0020_000A[item.ResultId] = item;
					}
					Instruction instruction = item.Instruction;
					OpSpecConstant opSpecConstant;
					OpConstant opConstant;
					if (instruction != null && ((opSpecConstant = (instruction as OpSpecConstant)) != null || (opConstant = (instruction as OpConstant)) != null))
					{
						Type resultType = item.ResultType;
						object value = _0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_000A_000A(item.ResultType as ScalarType, item.Words, 3);
						item.Operands[2].Value = value;
						item.Value = value;
					}
				}
			}
			foreach (ParsedInstruction item2 in list)
			{
				Instruction instruction = item2.Instruction;
				if (instruction != null)
				{
					OpMemberName opMemberName;
					if ((opMemberName = (instruction as OpMemberName)) == null)
					{
						OpName opName;
						if ((opName = (instruction as OpName)) != null)
						{
							_0020_000A[item2.Words[1]].Name = (string)item2.Operands[1].Value;
						}
					}
					else
					{
						((StructType)_0020_000A[item2.Words[1]].ResultType).SetMemberName((uint)item2.Operands[1].Value, (string)item2.Operands[2].Value);
					}
				}
			}
			foreach (ParsedInstruction item3 in _0020)
			{
				item3.ResolveReferences(_0020_000A);
			}
		}

		public static Module ReadFrom(Stream stream)
		{
			_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020 _0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020 = new _0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020(new BinaryReader(stream));
			uint num = _0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020.ReadDWord();
			int major = (int)(num >> 16);
			int minor = (int)((num >> 8) & 0xFF);
			Version version = new Version(major, minor);
			uint num2 = _0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020.ReadDWord();
			int key = (int)(num2 >> 16);
			string generatorVendor = "unknown";
			string generatorName = null;
			if (_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020.Tools.ContainsKey(key))
			{
				_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020.ToolInfo toolInfo = _0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020.Tools[key];
				generatorVendor = toolInfo.Vendor;
				if (toolInfo.Name != null)
				{
					generatorName = toolInfo.Name;
				}
			}
			ModuleHeader header = default(ModuleHeader);
			header.Version = version;
			header.GeneratorName = generatorName;
			header.GeneratorVendor = generatorVendor;
			header.GeneratorVersion = (int)(num2 & 0xFFFF);
			header.Bound = _0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020.ReadDWord();
			header.Reserved = _0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020.ReadDWord();
			List<ParsedInstruction> list = new List<ParsedInstruction>();
			while (!_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020.EndOfStream)
			{
				uint num3 = _0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020.ReadDWord();
				ushort num4 = (ushort)(num3 >> 16);
				int opCode = (int)(num3 & 0xFFFF);
				uint[] array = new uint[num4];
				array[0] = num3;
				for (ushort num5 = 1; num5 < num4; num5 = (ushort)(num5 + 1))
				{
					array[num5] = _0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020.ReadDWord();
				}
				ParsedInstruction item = new ParsedInstruction(opCode, array);
				list.Add(item);
			}
			return new Module(header, list);
		}

		private static void _0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020(ParsedInstruction _0020, IDictionary<uint, ParsedInstruction> _0020_000A)
		{
			Instruction instruction = _0020.Instruction;
			if (instruction == null)
			{
				return;
			}
			OpTypeInt opTypeInt;
			if ((opTypeInt = (instruction as OpTypeInt)) == null)
			{
				OpTypeFloat opTypeFloat;
				if ((opTypeFloat = (instruction as OpTypeFloat)) == null)
				{
					OpTypeVector opTypeVector;
					if ((opTypeVector = (instruction as OpTypeVector)) == null)
					{
						OpTypeMatrix opTypeMatrix;
						if ((opTypeMatrix = (instruction as OpTypeMatrix)) == null)
						{
							OpTypeArray opTypeArray;
							if ((opTypeArray = (instruction as OpTypeArray)) == null)
							{
								OpTypeRuntimeArray opTypeRuntimeArray;
								if ((opTypeRuntimeArray = (instruction as OpTypeRuntimeArray)) == null)
								{
									OpTypeBool opTypeBool;
									if ((opTypeBool = (instruction as OpTypeBool)) == null)
									{
										OpTypeOpaque opTypeOpaque;
										if ((opTypeOpaque = (instruction as OpTypeOpaque)) == null)
										{
											OpTypeVoid opTypeVoid;
											if ((opTypeVoid = (instruction as OpTypeVoid)) == null)
											{
												OpTypeImage opTypeImage;
												if ((opTypeImage = (instruction as OpTypeImage)) == null)
												{
													OpTypeSampler opTypeSampler;
													if ((opTypeSampler = (instruction as OpTypeSampler)) == null)
													{
														OpTypeSampledImage opTypeSampledImage;
														if ((opTypeSampledImage = (instruction as OpTypeSampledImage)) == null)
														{
															OpTypeFunction opTypeFunction;
															if ((opTypeFunction = (instruction as OpTypeFunction)) == null)
															{
																OpTypeForwardPointer opTypeForwardPointer;
																if ((opTypeForwardPointer = (instruction as OpTypeForwardPointer)) == null)
																{
																	OpTypePointer opTypePointer;
																	if ((opTypePointer = (instruction as OpTypePointer)) == null)
																	{
																		OpTypeStruct opTypeStruct;
																		if ((opTypeStruct = (instruction as OpTypeStruct)) != null)
																		{
																			List<Type> list = new List<Type>();
																			for (int i = 2; i < _0020.Words.Count; i++)
																			{
																				list.Add(_0020_000A[_0020.Words[i]].ResultType);
																			}
																			_0020.ResultType = new StructType(list);
																		}
																	}
																	else if (_0020_000A.ContainsKey(_0020.Words[1]))
																	{
																		((PointerType)_0020.ResultType).ResolveForwardReference(_0020_000A[_0020.Words[3]].ResultType);
																	}
																	else
																	{
																		_0020.ResultType = new PointerType((StorageClass)_0020.Words[2], _0020_000A[_0020.Words[3]].ResultType);
																	}
																}
																else
																{
																	_0020.ResultType = new PointerType((StorageClass)_0020.Words[2]);
																}
															}
															else
															{
																List<Type> list2 = new List<Type>();
																for (int j = 3; j < _0020.Words.Count; j++)
																{
																	list2.Add(_0020_000A[_0020.Words[j]].ResultType);
																}
																_0020.ResultType = new FunctionType(_0020_000A[_0020.Words[2]].ResultType, list2);
															}
														}
														else
														{
															_0020.ResultType = new SampledImageType((ImageType)_0020_000A[_0020.Words[2]].ResultType);
														}
													}
													else
													{
														_0020.ResultType = new SamplerType();
													}
												}
												else
												{
													Type resultType = _0020_000A[_0020.Operands[1].GetId()].ResultType;
													Dim singleEnumValue = _0020.Operands[2].GetSingleEnumValue<Dim>();
													uint depth = (uint)_0020.Operands[3].Value;
													bool isArray = (uint)_0020.Operands[4].Value != 0;
													bool isMultisampled = (uint)_0020.Operands[5].Value != 0;
													uint sampleCount = (uint)_0020.Operands[6].Value;
													ImageFormat singleEnumValue2 = _0020.Operands[7].GetSingleEnumValue<ImageFormat>();
													_0020.ResultType = new ImageType(resultType, singleEnumValue, (int)depth, isArray, isMultisampled, (int)sampleCount, singleEnumValue2, (_0020.Operands.Count > 8) ? _0020.Operands[8].GetSingleEnumValue<AccessQualifier>() : AccessQualifier.ReadOnly);
												}
											}
											else
											{
												_0020.ResultType = new VoidType();
											}
										}
										else
										{
											_0020.ResultType = new OpaqueType();
										}
									}
									else
									{
										_0020.ResultType = new BoolType();
									}
								}
								else
								{
									_0020.ResultType = new RuntimeArrayType(_0020_000A[_0020.Words[2]].ResultType);
								}
								return;
							}
							object value = _0020_000A[_0020.Words[3]].Value;
							int elementCount = 0;
							object obj = value;
							if (obj != null)
							{
								object obj2;
								if ((obj2 = obj) is ushort)
								{
									ushort num = (ushort)obj2;
									elementCount = num;
								}
								else if ((obj2 = obj) is uint)
								{
									uint num2 = (uint)obj2;
									elementCount = (int)num2;
								}
								else if ((obj2 = obj) is ulong)
								{
									ulong num3 = (ulong)obj2;
									elementCount = (int)num3;
								}
								else if ((obj2 = obj) is short)
								{
									short num4 = (short)obj2;
									elementCount = num4;
								}
								else if ((obj2 = obj) is int)
								{
									int num5 = (int)obj2;
									elementCount = num5;
								}
								else if ((obj2 = obj) is long)
								{
									long num6 = (long)obj2;
									elementCount = (int)num6;
								}
							}
							_0020.ResultType = new ArrayType(_0020_000A[_0020.Words[2]].ResultType, elementCount);
						}
						else
						{
							_0020.ResultType = new MatrixType((VectorType)_0020_000A[_0020.Words[2]].ResultType, (int)_0020.Words[3]);
						}
					}
					else
					{
						_0020.ResultType = new VectorType((ScalarType)_0020_000A[_0020.Words[2]].ResultType, (int)_0020.Words[3]);
					}
				}
				else
				{
					_0020.ResultType = new FloatingPointType((int)_0020.Words[2]);
				}
			}
			else
			{
				_0020.ResultType = new IntegerType((int)_0020.Words[2], _0020.Words[3] == 1);
			}
		}

		private static object _0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_000A_000A(ScalarType _0020, IList<uint> _0020_000A, int _0020_0020)
		{
			if (_0020 != null)
			{
				IntegerType integerType;
				if ((integerType = (_0020 as IntegerType)) != null)
				{
					IntegerType integerType2 = integerType;
					if (integerType2.Signed)
					{
						if (integerType2.Width == 16)
						{
							return (short)_0020_000A[_0020_0020];
						}
						if (integerType2.Width == 32)
						{
							return (int)_0020_000A[_0020_0020];
						}
						if (integerType2.Width == 64)
						{
							return (long)(_0020_000A[_0020_0020] | ((ulong)_0020_000A[_0020_0020 + 1] << 32));
						}
					}
					else
					{
						if (integerType2.Width == 16)
						{
							return (ushort)_0020_000A[_0020_0020];
						}
						if (integerType2.Width == 32)
						{
							return _0020_000A[_0020_0020];
						}
						if (integerType2.Width == 64)
						{
							return _0020_000A[_0020_0020] | ((ulong)_0020_000A[_0020_0020 + 1] << 32);
						}
					}
					throw new Exception("Cannot construct integer literal.");
				}
				FloatingPointType floatingPointType;
				if ((floatingPointType = (_0020 as FloatingPointType)) != null)
				{
					FloatingPointType floatingPointType2 = floatingPointType;
					if (floatingPointType2.Width == 32)
					{
						_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020 _0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020 = default(_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020);
						_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020.Int = _0020_000A[0];
						return _0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020.Float;
					}
					if (floatingPointType2.Width == 64)
					{
						_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020_000A _0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020_000A = default(_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020_000A);
						_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020_000A.Long = (_0020_000A[_0020_0020] | ((ulong)_0020_000A[_0020_0020 + 1] << 32));
						return _0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020_000A.Double;
					}
					throw new Exception("Cannot construct floating point literal.");
				}
			}
			return null;
		}
	}
}
