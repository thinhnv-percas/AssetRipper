using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DMP4
{
	internal abstract class Il2Cpp : _0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A
	{
		internal Il2CppMetadataRegistration pMetadataRegistration;

		internal Il2CppCodeRegistration pCodeRegistration;

		internal ulong[] methodPointers;

		public ulong[] genericMethodPointers;

		public ulong[] invokerPointers;

		public ulong[] customAttributeGenerators;

		public ulong[] reversePInvokeWrappers;

		public ulong[] unresolvedVirtualCallPointers;

		internal ulong[] fieldOffsets;

		public Il2CppTypeDefinitionSizes[] typeDefinitionsSizes;

		public Il2CppType[] types;

		internal Dictionary<ulong, Il2CppType> typeDic = new Dictionary<ulong, Il2CppType>();

		public ulong[] metadataUsages;

		internal Il2CppGenericMethodFunctionsDefinitions[] genericMethodTable;

		public ulong[] genericInstPointers;

		public Il2CppGenericInst[] genericInsts;

		public Il2CppMethodSpec[] methodSpecs;

		public Dictionary<int, List<Il2CppMethodSpec>> methodDefinitionMethodSpecs = new Dictionary<int, List<Il2CppMethodSpec>>();

		public Dictionary<Il2CppMethodSpec, ulong> methodSpecGenericMethodPointers = new Dictionary<Il2CppMethodSpec, ulong>();

		internal bool fieldOffsetsArePointers;

		internal long maxMetadataUsages;

		public Dictionary<string, Il2CppCodeGenModule> codeGenModules;

		public Dictionary<string, _0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_000A_0020> image_codeGenModules;

		public abstract ulong MapVATR(ulong addr);

		public abstract bool IsInMapVATR(ulong addr);

		public abstract ulong MapRTVA(ulong addr);

		public abstract bool Search();

		public abstract bool PlusSearch(int methodCount, int typeDefinitionsCount, int imageCount);

		public abstract bool SymbolSearch();

		internal Il2Cpp(Stream stream)
			: base(stream)
		{
		}

		internal void SetProperties(double version, long maxMetadataUsages)
		{
			Version = version;
			this.maxMetadataUsages = maxMetadataUsages;
		}

		internal bool AutoCorrect_codeRegistration_test(ulong codeRegistration)
		{
			pCodeRegistration = MapVATR<Il2CppCodeRegistration>(codeRegistration);
			bool flag = pCodeRegistration.codeGenModulesCount > 0 && pCodeRegistration.codeGenModulesCount < 1000;
			bool flag2 = pCodeRegistration.interopDataCount == 0L || (pCodeRegistration.interopDataCount != 0 && pCodeRegistration.interopDataCount < 100000 && pCodeRegistration.interopData > 100000);
			bool flag3 = pCodeRegistration.genericMethodPointersCount == 0L || (pCodeRegistration.genericMethodPointersCount > 0 && pCodeRegistration.genericMethodPointersCount < 100000 && pCodeRegistration.genericMethodPointers > 100000);
			bool flag4 = pCodeRegistration.reversePInvokeWrapperCount == 0L || (pCodeRegistration.reversePInvokeWrapperCount > 0 && pCodeRegistration.reversePInvokeWrapperCount < 100000 && pCodeRegistration.reversePInvokeWrappers > 100000);
			bool flag5 = pCodeRegistration.customAttributeCount == 0L || (pCodeRegistration.customAttributeCount > 0 && pCodeRegistration.customAttributeCount < 100000 && pCodeRegistration.customAttributeGenerators > 100000);
			if ((flag && flag2) & flag3 & flag4 & flag5)
			{
				ConsoleManager._0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A("AutoCorrect_codeRegistration_test - true, codeRegistration=" + codeRegistration);
				return true;
			}
			ConsoleManager._0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A("AutoCorrect_codeRegistration_test - false, codeRegistration=" + codeRegistration + $", f1={flag}, f3={flag2}, f4={flag3}, f5={flag4}, f6={flag5}");
			return false;
		}

		internal bool AutoCorrect_codeRegistration(ulong codeRegistration, ulong metadataRegistration, out ulong codeRegistration_result)
		{
			codeRegistration_result = codeRegistration;
			if (Version < 24.2)
			{
				return true;
			}
			int num = 0;
			if (AutoCorrect_codeRegistration_test(codeRegistration))
			{
				codeRegistration_result = codeRegistration;
				return true;
			}
			ulong num2 = codeRegistration - base.PointerSize;
			ulong num3 = codeRegistration + base.PointerSize;
			do
			{
				if (AutoCorrect_codeRegistration_test(num2))
				{
					codeRegistration_result = num2;
					return true;
				}
				num2 -= base.PointerSize;
				if (AutoCorrect_codeRegistration_test(num3))
				{
					codeRegistration_result = num3;
					return true;
				}
				num3 += base.PointerSize;
				num++;
			}
			while (num < 10);
			ConsoleManager._0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A("AutoCorrect_codeRegistration - false");
			return false;
		}

		internal bool AutoPlusInit(ulong codeRegistration, ulong metadataRegistration)
		{
			if (codeRegistration != 0L && metadataRegistration != 0L)
			{
				ulong codeRegistration_result2;
				if (Version == 24.2)
				{
					if (AutoCorrect_codeRegistration(codeRegistration, metadataRegistration, out ulong codeRegistration_result))
					{
						pCodeRegistration = MapVATR<Il2CppCodeRegistration>(codeRegistration_result);
						ConsoleManager.WriteInfo($"1. Correct CodeRegistration: {codeRegistration - codeRegistration_result} bytes ({(codeRegistration - codeRegistration_result) / base.PointerSize}) ");
						if (codeRegistration - codeRegistration_result == base.PointerSize * 3)
						{
							Version = 24.4;
							ConsoleManager.WriteInfo($"1. Change il2cpp version to: {Version}");
						}
						else if (codeRegistration - codeRegistration_result == base.PointerSize * 2)
						{
							pMetadataRegistration = MapVATR<Il2CppMetadataRegistration>(metadataRegistration);
							genericMethodTable = MapVATR<Il2CppGenericMethodFunctionsDefinitions>(pMetadataRegistration.genericMethodTable, pMetadataRegistration.genericMethodTableCount);
							int num = genericMethodTable.Max((Il2CppGenericMethodFunctionsDefinitions x) => x.indices.methodIndex) + 1;
							if (pCodeRegistration.reversePInvokeWrapperCount == num)
							{
								Version = 24.3;
								ConsoleManager.WriteInfo($"1. Change il2cpp version to: {Version}");
							}
						}
						codeRegistration = codeRegistration_result;
					}
					pCodeRegistration = MapVATR<Il2CppCodeRegistration>(codeRegistration);
				}
				else if (AutoCorrect_codeRegistration(codeRegistration, metadataRegistration, out codeRegistration_result2) && codeRegistration != codeRegistration_result2)
				{
					pCodeRegistration = MapVATR<Il2CppCodeRegistration>(codeRegistration_result2);
					ConsoleManager.WriteInfo($"1. Correct CodeRegistration: {codeRegistration - codeRegistration_result2} bytes ({(codeRegistration - codeRegistration_result2) / base.PointerSize}) ");
					codeRegistration = codeRegistration_result2;
				}
				ConsoleManager._0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A("CodeRegistration : 0x{0:x} (file: 0x{1:x})", codeRegistration, MapVATR(codeRegistration));
				ConsoleManager._0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A("MetadataRegistration : 0x{0:x} (file: 0x{1:x})", metadataRegistration, MapVATR(metadataRegistration));
				Init(codeRegistration, metadataRegistration);
				return true;
			}
			ConsoleManager._0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A("CodeRegistration : {0:x}", codeRegistration);
			ConsoleManager._0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A("MetadataRegistration : {0:x}", metadataRegistration);
			return false;
		}

		public virtual void Init(ulong codeRegistration, ulong metadataRegistration)
		{
			int num = 0;
			try
			{
				pCodeRegistration = MapVATR<Il2CppCodeRegistration>(codeRegistration);
				if (Version == 27.0 && pCodeRegistration.reversePInvokeWrapperCount > 196608)
				{
					Version = 27.1;
					codeRegistration -= base.PointerSize;
					ConsoleManager.WriteInfo($"2. Change il2cpp version to: {Version}");
					ConsoleManager._0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A("CodeRegistration : {0:x}", codeRegistration);
					pCodeRegistration = MapVATR<Il2CppCodeRegistration>(codeRegistration);
				}
				if (Version == 24.2)
				{
					if (pCodeRegistration.reversePInvokeWrapperCount > 196608)
					{
						Version = 24.4;
						codeRegistration -= base.PointerSize * 3;
						ConsoleManager.WriteInfo($"2. Change il2cpp version to: {Version}");
						ConsoleManager._0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A("CodeRegistration : {0:x}", codeRegistration);
						pCodeRegistration = MapVATR<Il2CppCodeRegistration>(codeRegistration);
					}
					else if (pCodeRegistration.codeGenModules == 0L)
					{
						Version = 24.3;
						ConsoleManager.WriteInfo($"2. Change il2cpp version to: {Version}");
						pCodeRegistration = MapVATR<Il2CppCodeRegistration>(codeRegistration);
					}
				}
				ConsoleManager._0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A("1 " + _0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_000A._0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A_000A(pCodeRegistration));
				pMetadataRegistration = MapVATR<Il2CppMetadataRegistration>(metadataRegistration);
				ConsoleManager._0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A("2 " + _0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_000A._0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A_000A(pMetadataRegistration));
				num = 2;
				genericMethodPointers = MapVATR<ulong>(pCodeRegistration.genericMethodPointers, pCodeRegistration.genericMethodPointersCount);
				num = 3;
				invokerPointers = MapVATR<ulong>(pCodeRegistration.invokerPointers, pCodeRegistration.invokerPointersCount);
				if (Version < 27.0 && pCodeRegistration.customAttributeCount > 0)
				{
					customAttributeGenerators = MapVATR<ulong>(pCodeRegistration.customAttributeGenerators, pCodeRegistration.customAttributeCount);
				}
				num = 4;
				ConsoleManager._0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A("maxMetadataUsages=" + maxMetadataUsages);
				ConsoleManager._0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A("pMetadataRegistration.metadataUsagesCount=" + pMetadataRegistration.metadataUsagesCount);
				maxMetadataUsages = Math.Max((long)pMetadataRegistration.metadataUsagesCount, maxMetadataUsages);
				ConsoleManager._0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A("pMetadataRegistration.metadataUsages=" + MapVATR(pMetadataRegistration.metadataUsages) + ", to=" + ((long)MapVATR(pMetadataRegistration.metadataUsages) + maxMetadataUsages * 4));
				metadataUsages = MapVATR<ulong>(pMetadataRegistration.metadataUsages, maxMetadataUsages);
				num = 5;
				if (Version >= 22.0)
				{
					if (pCodeRegistration.reversePInvokeWrapperCount != 0L)
					{
						reversePInvokeWrappers = MapVATR<ulong>(pCodeRegistration.reversePInvokeWrappers, pCodeRegistration.reversePInvokeWrapperCount);
					}
					if (pCodeRegistration.unresolvedVirtualCallCount != 0L)
					{
						unresolvedVirtualCallPointers = MapVATR<ulong>(pCodeRegistration.unresolvedVirtualCallPointers, pCodeRegistration.unresolvedVirtualCallCount);
					}
				}
				num = 6;
				genericInstPointers = MapVATR<ulong>(pMetadataRegistration.genericInsts, pMetadataRegistration.genericInstsCount);
				num = 7;
				genericInsts = Array.ConvertAll(genericInstPointers, this.MapVATR<Il2CppGenericInst>);
				num = 8;
				fieldOffsetsArePointers = (Version > 21.0);
				if (Version == 21.0)
				{
					uint[] array = MapVATR<uint>(pMetadataRegistration.fieldOffsets, 6L);
					fieldOffsetsArePointers = (array[0] == 0 && array[1] == 0 && array[2] == 0 && array[3] == 0 && array[4] == 0 && array[5] != 0);
				}
				if (fieldOffsetsArePointers)
				{
					fieldOffsets = MapVATR<ulong>(pMetadataRegistration.fieldOffsets, pMetadataRegistration.fieldOffsetsCount);
				}
				else
				{
					fieldOffsets = Array.ConvertAll(MapVATR<uint>(pMetadataRegistration.fieldOffsets, pMetadataRegistration.fieldOffsetsCount), (Converter<uint, ulong>)((uint x) => x));
				}
				if (pMetadataRegistration.typeDefinitionsSizes != 0)
				{
					ConsoleManager._0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_000A_0020("pMetadataRegistration.typeDefinitionsSizes=" + pMetadataRegistration.typeDefinitionsSizes);
					ConsoleManager._0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_000A_0020("pMetadataRegistration.typeDefinitionsSizesCount=" + pMetadataRegistration.typeDefinitionsSizesCount);
					ulong[] array2 = MapVATR<ulong>(pMetadataRegistration.typeDefinitionsSizes, pMetadataRegistration.typeDefinitionsSizesCount);
					typeDefinitionsSizes = new Il2CppTypeDefinitionSizes[array2.Length];
					try
					{
						for (int i = 0; i < array2.Length; i++)
						{
							if (array2[i] == 0)
							{
								typeDefinitionsSizes[i] = new Il2CppTypeDefinitionSizes();
							}
							else
							{
								typeDefinitionsSizes[i] = MapVATR<Il2CppTypeDefinitionSizes>(array2[i]);
							}
						}
					}
					catch (Exception arg)
					{
						ConsoleManager._0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A(string.Concat(arg));
					}
				}
				else
				{
					ConsoleManager._0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A("pMetadataRegistration.typeDefinitionsSizes=" + pMetadataRegistration.typeDefinitionsSizes);
					ConsoleManager._0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A("pMetadataRegistration.typeDefinitionsSizesCount=" + pMetadataRegistration.typeDefinitionsSizesCount);
				}
				num = 9;
				ulong[] array3 = MapVATR<ulong>(pMetadataRegistration.types, pMetadataRegistration.typesCount);
				types = new Il2CppType[pMetadataRegistration.typesCount];
				for (int j = 0; j < pMetadataRegistration.typesCount; j++)
				{
					types[j] = MapVATR<Il2CppType>(array3[j]);
					types[j].Init();
					typeDic.Add(array3[j], types[j]);
				}
				num = 10;
				if (pCodeRegistration.codeGenModulesCount > 0)
				{
					num = 101;
					ulong[] array4 = MapVATR<ulong>(pCodeRegistration.codeGenModules, pCodeRegistration.codeGenModulesCount);
					num = 102;
					codeGenModules = new Dictionary<string, Il2CppCodeGenModule>(array4.Length, StringComparer.Ordinal);
					image_codeGenModules = new Dictionary<string, _0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_000A_0020>();
					int num2 = 0;
					ulong[] array5 = array4;
					foreach (ulong addr in array5)
					{
						num = 103;
						Il2CppCodeGenModule il2CppCodeGenModule = MapVATR<Il2CppCodeGenModule>(addr);
						num = 104;
						string text = ReadStringToNull(MapVATR(il2CppCodeGenModule.moduleName));
						codeGenModules.Add(text, il2CppCodeGenModule);
						ConsoleManager._0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A(text + ": " + _0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_000A._0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A_000A(il2CppCodeGenModule));
						_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_000A_0020 _0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_000A_0020 = new _0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_000A_0020();
						_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_000A_0020._0020_000A_0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A = pMetadataRegistration;
						_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_000A_0020._0020_000A_0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020 = pCodeRegistration;
						image_codeGenModules[text] = _0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_000A_0020;
						_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_000A_0020.moduleName = text;
						_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_000A_0020.methodPointerIndexStart = num2;
						try
						{
							_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_000A_0020.methodPointerCount = (int)il2CppCodeGenModule.methodPointerCount;
							num2 += (int)il2CppCodeGenModule.methodPointerCount;
							_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_000A_0020.methodPointers = MapVATR<ulong>(il2CppCodeGenModule.methodPointers, il2CppCodeGenModule.methodPointerCount);
						}
						catch (Exception arg2)
						{
							ConsoleManager._0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A(string.Concat(arg2));
							_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_000A_0020.methodPointers = new ulong[il2CppCodeGenModule.methodPointerCount];
						}
						try
						{
							_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_000A_0020.methodPointerCount = (int)il2CppCodeGenModule.methodPointerCount;
							_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_000A_0020.invokerIndices = MapVATR<ulong>(il2CppCodeGenModule.invokerIndices, il2CppCodeGenModule.methodPointerCount);
						}
						catch (Exception arg3)
						{
							ConsoleManager._0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A(string.Concat(arg3));
							_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_000A_0020.invokerIndices = new ulong[il2CppCodeGenModule.methodPointerCount];
						}
						try
						{
							_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_000A_0020.adjustorThunkCount = (int)il2CppCodeGenModule.adjustorThunkCount;
							_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_000A_0020.adjustorThunks_Dictionary = new Dictionary<uint, Il2CppTokenAdjustorThunkPair>();
							if (il2CppCodeGenModule.adjustorThunkCount > 0)
							{
								_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_000A_0020.adjustorThunks = MapVATR<Il2CppTokenAdjustorThunkPair>(il2CppCodeGenModule.adjustorThunks, il2CppCodeGenModule.adjustorThunkCount);
								Il2CppTokenAdjustorThunkPair[] adjustorThunks = _0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_000A_0020.adjustorThunks;
								foreach (Il2CppTokenAdjustorThunkPair il2CppTokenAdjustorThunkPair in adjustorThunks)
								{
									_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_000A_0020.adjustorThunks_Dictionary[il2CppTokenAdjustorThunkPair.token] = il2CppTokenAdjustorThunkPair;
								}
							}
						}
						catch (Exception arg4)
						{
							ConsoleManager._0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A(string.Concat(arg4));
						}
						Dictionary<uint, Il2CppRGCTXDefinition[]> dictionary = new Dictionary<uint, Il2CppRGCTXDefinition[]>();
						_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_000A_0020.rgctxsCount = (int)il2CppCodeGenModule.rgctxsCount;
						_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_000A_0020.rgctxsDictionary = dictionary;
						if (il2CppCodeGenModule.rgctxsCount > 0)
						{
							Il2CppRGCTXDefinition[] sourceArray = MapVATR<Il2CppRGCTXDefinition>(il2CppCodeGenModule.rgctxs, il2CppCodeGenModule.rgctxsCount);
							Il2CppTokenRangePair[] array6 = MapVATR<Il2CppTokenRangePair>(il2CppCodeGenModule.rgctxRanges, il2CppCodeGenModule.rgctxRangesCount);
							foreach (Il2CppTokenRangePair il2CppTokenRangePair in array6)
							{
								Il2CppRGCTXDefinition[] array7 = new Il2CppRGCTXDefinition[il2CppTokenRangePair.range.length];
								Array.Copy(sourceArray, il2CppTokenRangePair.range.start, array7, 0, il2CppTokenRangePair.range.length);
								dictionary.Add(il2CppTokenRangePair.token, array7);
							}
						}
					}
				}
				else
				{
					methodPointers = MapVATR<ulong>(pCodeRegistration.methodPointers, pCodeRegistration.methodPointersCount);
				}
				num = 11;
				genericMethodTable = MapVATR<Il2CppGenericMethodFunctionsDefinitions>(pMetadataRegistration.genericMethodTable, pMetadataRegistration.genericMethodTableCount);
				num = 12;
				methodSpecs = MapVATR<Il2CppMethodSpec>(pMetadataRegistration.methodSpecs, pMetadataRegistration.methodSpecsCount);
				num = 13;
				Il2CppGenericMethodFunctionsDefinitions[] array8 = genericMethodTable;
				foreach (Il2CppGenericMethodFunctionsDefinitions il2CppGenericMethodFunctionsDefinitions in array8)
				{
					num = 131;
					if (il2CppGenericMethodFunctionsDefinitions.genericMethodIndex < 0)
					{
						ConsoleManager._0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A($"table.genericMethodIndex({il2CppGenericMethodFunctionsDefinitions.genericMethodIndex}) <0 ");
					}
					else
					{
						if (il2CppGenericMethodFunctionsDefinitions.genericMethodIndex >= methodSpecs.Length)
						{
							ConsoleManager._0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A($"table.genericMethodIndex({il2CppGenericMethodFunctionsDefinitions.genericMethodIndex}) >= methodSpecs.Length ({methodSpecs.Length})");
						}
						num = 132;
						Il2CppMethodSpec il2CppMethodSpec = methodSpecs[il2CppGenericMethodFunctionsDefinitions.genericMethodIndex];
						num = 133;
						int methodDefinitionIndex = il2CppMethodSpec.methodDefinitionIndex;
						num = 134;
						if (!methodDefinitionMethodSpecs.TryGetValue(methodDefinitionIndex, out List<Il2CppMethodSpec> value))
						{
							num = 135;
							value = new List<Il2CppMethodSpec>();
							methodDefinitionMethodSpecs.Add(methodDefinitionIndex, value);
							num = 136;
						}
						num = 137;
						value.Add(il2CppMethodSpec);
						num = 138;
						if (il2CppGenericMethodFunctionsDefinitions.indices.methodIndex >= genericMethodPointers.Length)
						{
							ConsoleManager._0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A($"table.indices.methodIndex({il2CppGenericMethodFunctionsDefinitions.indices.methodIndex}) >= genericMethodPointers.Length ({genericMethodPointers.Length})");
						}
						methodSpecGenericMethodPointers.Add(il2CppMethodSpec, genericMethodPointers[il2CppGenericMethodFunctionsDefinitions.indices.methodIndex]);
					}
				}
				num = 14;
			}
			catch (Exception ex)
			{
				ConsoleManager._0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A(("l=" + num + "\n" + ex) ?? "");
				throw ex;
			}
		}

		public T MapVATR<T>(ulong addr) where T : new()
		{
			return ReadClass_by_db<T>(MapVATR(addr));
		}

		public T[] MapVATR<T>(ulong addr, long count) where T : new()
		{
			return ReadClassArray_by_db<T>(MapVATR(addr), count);
		}

		internal int GetFieldOffsetFromIndex(int typeIndex, int fieldIndexInType, int fieldIndex, bool isValueType, bool isStatic)
		{
			try
			{
				int num = -1;
				if (fieldOffsetsArePointers)
				{
					ulong num2 = fieldOffsets[typeIndex];
					if (num2 != 0)
					{
						ulong num3 = (ulong)((long)MapVATR(num2) + 4L * (long)fieldIndexInType);
						if (num3 >= base.Length)
						{
							return -1;
						}
						base.Position = num3;
						num = ReadInt32();
					}
				}
				else
				{
					num = (int)fieldOffsets[fieldIndex];
				}
				if (num > 0 && isValueType && !isStatic)
				{
					num = ((!Is32Bit) ? (num - 16) : (num - 8));
				}
				return num;
			}
			catch (Exception ex)
			{
				ConsoleManager._0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A(("typeIndex=" + typeIndex + ", fieldIndexInType=" + fieldIndexInType + ", " + ex) ?? "");
				return -1;
			}
		}

		internal Il2CppType GetIl2CppType(ulong pointer)
		{
			return typeDic[pointer];
		}

		internal ulong GetAdjustorThunk(string imageName, Il2CppMethodDefinition methodDef)
		{
			return 0uL;
		}

		internal static uint GetTokenType(uint token)
		{
			return (uint)((int)token & -16777216);
		}

		internal static uint GetTokenRowId(uint token)
		{
			return token & 0xFFFFFF;
		}

		internal ulong GetMethodPointer(string imageName, Il2CppMethodDefinition methodDef)
		{
			_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_000A_0020 value;
			if (image_codeGenModules != null && image_codeGenModules.TryGetValue(imageName, out value) && value.methodPointerCount > 0)
			{
				uint tokenRowId = GetTokenRowId(methodDef.token);
				if (tokenRowId == 0)
				{
					return 0uL;
				}
				return value.methodPointers[tokenRowId - 1];
			}
			int methodIndex = methodDef.methodIndex;
			if (methodIndex >= 0 && methodPointers != null)
			{
				return methodPointers[methodIndex];
			}
			return 0uL;
		}

		internal ulong GetMethodInvoker(string imageName, Il2CppMethodDefinition methodDef)
		{
			_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_000A_0020 value;
			if (image_codeGenModules != null && image_codeGenModules.TryGetValue(imageName, out value) && value.methodPointerCount > 0)
			{
				uint tokenRowId = GetTokenRowId(methodDef.token);
				if (tokenRowId == 0)
				{
					return 0uL;
				}
				int num = (int)value.invokerIndices[tokenRowId - 1];
				if (num < 0 || num >= invokerPointers.Length)
				{
					return 0uL;
				}
				return invokerPointers[num];
			}
			return 0uL;
		}

		internal Dictionary<ulong, ulong> GetSortedAllPointersWithIndexToNextPointer()
		{
			List<ulong> list = new List<ulong>();
			if (Version >= 24.2 && image_codeGenModules != null && image_codeGenModules.Count > 0)
			{
				foreach (KeyValuePair<string, _0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_000A_0020> image_codeGenModule in image_codeGenModules)
				{
					list.AddRange(image_codeGenModule.Value.methodPointers);
				}
			}
			else if (methodPointers != null)
			{
				list.AddRange(methodPointers);
			}
			if (customAttributeGenerators != null)
			{
				list.AddRange(customAttributeGenerators);
			}
			if (invokerPointers != null)
			{
				list.AddRange(invokerPointers);
			}
			if (genericMethodPointers != null)
			{
				list.AddRange(genericMethodPointers);
			}
			list.Sort();
			list = list.Distinct().ToList();
			Dictionary<ulong, ulong> dictionary = new Dictionary<ulong, ulong>(list.Count);
			for (int i = 0; i < list.Count - 1; i++)
			{
				dictionary.Add(list[i], list[i + 1]);
			}
			if (list.Count > 1)
			{
				dictionary.Add(list[list.Count - 1], list[list.Count - 1] + 40);
			}
			return dictionary;
		}

		public virtual ulong GetRVA(ulong pointer)
		{
			return pointer;
		}
	}
}
