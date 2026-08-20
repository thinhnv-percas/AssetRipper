// Decompiles the functions listed in an Il2Cpp symbol file and writes the results grouped by assembly.
//
// Run by AssetRipper through analyzeHeadless. Arguments:
//   [0] path to the tab separated symbol file: address, group, name, key, signature, decompile
//   [1] directory to write the decompiled output into
//   [2] optional path to the type layout file
//   [3] optional path to the metadata globals file: address, name
//
//@category AssetRipper

import ghidra.app.cmd.function.ApplyFunctionSignatureCmd;
import ghidra.app.decompiler.DecompInterface;
import ghidra.app.decompiler.DecompileResults;
import ghidra.app.script.GhidraScript;
import ghidra.app.util.parser.FunctionSignatureParser;
import ghidra.program.model.address.Address;
import ghidra.program.model.symbol.SymbolTable;
import ghidra.program.model.data.CategoryPath;
import ghidra.program.model.data.DataType;
import ghidra.program.model.data.DataTypeConflictHandler;
import ghidra.program.model.data.DataTypeManager;
import ghidra.program.model.data.FunctionDefinitionDataType;
import ghidra.program.model.data.BooleanDataType;
import ghidra.program.model.data.ByteDataType;
import ghidra.program.model.data.CharDataType;
import ghidra.program.model.data.DoubleDataType;
import ghidra.program.model.data.FloatDataType;
import ghidra.program.model.data.IntegerDataType;
import ghidra.program.model.data.LongLongDataType;
import ghidra.program.model.data.PointerDataType;
import ghidra.program.model.data.ShortDataType;
import ghidra.program.model.data.UnsignedIntegerDataType;
import ghidra.program.model.data.UnsignedLongLongDataType;
import ghidra.program.model.data.UnsignedShortDataType;
import ghidra.program.model.data.StructureDataType;
import ghidra.program.model.listing.Function;
import ghidra.program.model.symbol.SourceType;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

public class ExportIl2CppDecompilation extends GhidraScript {

	private static final int DecompileTimeoutSeconds = 60;

	/// How often progress is reported. Decompiling is slow, so this is far smaller than for naming.
	private static final int DecompileProgressInterval = 250;
	private static final int NamingProgressInterval = 5000;

	/// How many symbols to check when working out the address offset.
	private static final int CalibrationSampleSize = 2000;

	/// Written next to the grouped output so AssetRipper can attach each function to its managed method.
	private static final String IndexFileName = "decompilation_index.txt";

	private static final class Symbol {
		final long address;
		final String group;
		final String name;
		final String key;
		final String signature;
		/// Naming a function is cheap and makes every call to it readable. Decompiling one is the
		/// expensive half of the run, so a symbol may ask to be named and left alone.
		final boolean decompile;

		Symbol(long address, String group, String name, String key, String signature, boolean decompile) {
			this.address = address;
			this.group = group;
			this.name = name;
			this.key = key;
			this.signature = signature;
			this.decompile = decompile;
		}
	}

	@Override
	public void run() throws Exception {
		String[] args = getScriptArgs();
		if (args.length < 2) {
			println("ERROR: expected a symbol file and an output directory");
			return;
		}

		File symbolFile = new File(args[0]);
		File outputDirectory = new File(args[1]);
		if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
			println("ERROR: could not create " + outputDirectory);
			return;
		}

		List<Symbol> symbols = readSymbols(symbolFile);
		println("Read " + symbols.size() + " symbols from " + symbolFile);

		// Must run before any function is created, otherwise it scores its own work.
		calibrateAddressOffset(symbols);

		if (args.length > 2) {
			int structs = defineStructures(new File(args[2]));
			println("Defined " + structs + " type layouts");
		}

		if (args.length > 3) {
			int globals = applyGlobalNames(new File(args[3]));
			println("Named " + globals + " metadata globals");
		}

		int named = applyNames(symbols);
		println("Applied " + named + " function names");
		reportProgress("naming", symbols.size(), symbols.size());

		DecompInterface decompiler = new DecompInterface();
		try {
			if (!decompiler.openProgram(currentProgram)) {
				println("ERROR: could not open the program for decompilation");
				return;
			}

			Map<String, StringBuilder> outputByGroup = new LinkedHashMap<String, StringBuilder>();
			BufferedWriter index = new BufferedWriter(new FileWriter(new File(outputDirectory, IndexFileName)));
			index.write("# key\tescaped decompiled code\n");
			int succeeded = 0;
			int failed = 0;
			int processed = 0;
			int skipped = 0;
			int wanted = 0;
			for (Symbol symbol : symbols) {
				if (symbol.decompile) {
					wanted++;
				}
			}

			for (Symbol symbol : symbols) {
				if (monitor.isCancelled()) {
					break;
				}

				if (!symbol.decompile) {
					skipped++;
					continue;
				}

				processed++;
				if (processed % DecompileProgressInterval == 0) {
					reportProgress("decompiling", processed, wanted);
				}

				Address address = resolve(symbol.address);
				if (address == null) {
					failed++;
					continue;
				}

				Function function = getFunctionAt(address);
				if (function == null) {
					failed++;
					continue;
				}

				String code = decompile(decompiler, function);
				if (code == null) {
					failed++;
					continue;
				}

				StringBuilder builder = outputByGroup.get(symbol.group);
				if (builder == null) {
					builder = new StringBuilder();
					outputByGroup.put(symbol.group, builder);
				}
				builder.append("// ").append(symbol.name).append('\n');
				builder.append("// 0x").append(Long.toHexString(symbol.address)).append('\n');
				builder.append(code).append('\n');

				if (symbol.key.length() > 0) {
					index.write(symbol.key);
					index.write('\t');
					index.write(escape(code));
					index.write('\n');
				}

				succeeded++;
			}

			index.close();

			for (Map.Entry<String, StringBuilder> entry : outputByGroup.entrySet()) {
				File file = new File(outputDirectory, sanitize(entry.getKey()) + ".c");
				BufferedWriter writer = new BufferedWriter(new FileWriter(file));
				try {
					writer.write(entry.getValue().toString());
				} finally {
					writer.close();
				}
			}

			// AssetRipper parses this line to report the outcome.
			println("RESULT decompiled=" + succeeded + " failed=" + failed + " named-only=" + skipped);
		} finally {
			decompiler.dispose();
		}
	}

	/// Labels the globals that compiled Il2Cpp code loads its types, strings and methods out of.
	///
	/// The decompiler prints a data reference by the address it sits at, so a body is full of
	/// PTR_DAT_0459b1c0 where the metadata says UnityEngine.Object. A primary label at that address is
	/// all it takes for the name to appear instead.
	private int applyGlobalNames(File file) throws Exception {
		if (!file.isFile()) {
			return 0;
		}

		SymbolTable symbolTable = currentProgram.getSymbolTable();
		int named = 0;

		BufferedReader reader = new BufferedReader(new FileReader(file));
		try {
			String line;
			while ((line = reader.readLine()) != null) {
				if (line.length() == 0 || line.charAt(0) == '#') {
					continue;
				}

				String[] parts = line.split("\t");
				if (parts.length < 2) {
					continue;
				}

				long value;
				try {
					value = Long.parseUnsignedLong(parts[0].startsWith("0x") ? parts[0].substring(2) : parts[0], 16);
				} catch (NumberFormatException e) {
					continue;
				}

				Address address = resolve(value);
				if (address == null) {
					continue;
				}

				try {
					symbolTable.createLabel(address, parts[1], SourceType.IMPORTED).setPrimary();
					named++;
				} catch (Exception e) {
					// A name the program will not accept is not worth abandoning the rest for.
				}
			}
		} finally {
			reader.close();
		}

		return named;
	}

	private List<Symbol> readSymbols(File file) throws Exception {
		List<Symbol> symbols = new ArrayList<Symbol>();
		BufferedReader reader = new BufferedReader(new FileReader(file));
		try {
			String line;
			while ((line = reader.readLine()) != null) {
				if (line.length() == 0 || line.charAt(0) == '#') {
					continue;
				}
				String[] parts = line.split("\t");
				if (parts.length < 3) {
					continue;
				}
				long address;
				try {
					address = Long.parseUnsignedLong(parts[0].startsWith("0x") ? parts[0].substring(2) : parts[0], 16);
				} catch (NumberFormatException e) {
					continue;
				}
				String key = parts.length > 3 ? parts[3] : "";
				String signature = parts.length > 4 ? parts[4] : "";
				boolean decompile = parts.length <= 5 || !parts[5].equals("0");
				symbols.add(new Symbol(address, parts[1], parts[2], key, signature, decompile));
			}
		} finally {
			reader.close();
		}
		return symbols;
	}

	/// Il2Cpp reports addresses in the binary's own address space, which does not always match the
	/// base Ghidra loaded the image at. Determined once by calibration.
	private long addressOffset;

	private Address resolve(long rawAddress) {
		try {
			Address address = toAddr(rawAddress + addressOffset);
			return address != null && currentProgram.getMemory().contains(address) ? address : null;
		} catch (Exception e) {
			return null;
		}
	}

	/// Only functions the analyzer found on its own are evidence. Functions this script created on a
	/// previous run would otherwise vouch for whichever offset produced them.
	private boolean isAnalyzerDiscoveredFunction(Address address) {
		Function function = getFunctionAt(address);
		return function != null
			&& function.getSymbol() != null
			&& function.getSymbol().getSource() != SourceType.IMPORTED;
	}

	/// Works out whether Il2Cpp's addresses need the image base added to them.
	///
	/// A PE is normally loaded at the base its header asks for, so its addresses already match. An ELF
	/// shared object is loaded at an arbitrary base, so its addresses are short by exactly that much.
	/// Guessing wrong is silent and total: every address still lands inside the image, just on the
	/// wrong function. Rather than special casing the format, both interpretations are scored against
	/// the functions the analyzer already found. Every Il2Cpp address must be the start of a function,
	/// so the correct interpretation matches nearly all of them and the wrong one hardly any.
	private void calibrateAddressOffset(List<Symbol> symbols) {
		long imageBase = currentProgram.getImageBase().getOffset();
		if (imageBase == 0 || symbols.isEmpty()) {
			addressOffset = 0;
			return;
		}

		long[] candidates = { 0L, imageBase };
		long bestOffset = 0;
		int bestStarts = -1;
		int bestInMemory = -1;

		int step = Math.max(1, symbols.size() / CalibrationSampleSize);
		for (long candidate : candidates) {
			int starts = 0;
			int inMemory = 0;
			for (int i = 0; i < symbols.size(); i += step) {
				Address address;
				try {
					address = toAddr(symbols.get(i).address + candidate);
				} catch (Exception e) {
					continue;
				}
				if (address == null || !currentProgram.getMemory().contains(address)) {
					continue;
				}
				inMemory++;
				if (isAnalyzerDiscoveredFunction(address)) {
					starts++;
				}
			}

			if (starts > bestStarts || (starts == bestStarts && inMemory > bestInMemory)) {
				bestStarts = starts;
				bestInMemory = inMemory;
				bestOffset = candidate;
			}
		}

		addressOffset = bestOffset;
		println("Address offset 0x" + Long.toHexString(addressOffset)
			+ " (" + bestStarts + " of the sampled addresses are function starts)");
	}

	/// Registers a struct for each Il2Cpp type so that field accesses decompile as named members
	/// instead of arithmetic on the instance pointer.
	///
	/// Built in two passes: every struct is created at its final size first, so that a field in one
	/// type can refer to another type without the two having to be declared in dependency order.
	private int defineStructures(File layoutFile) {
		if (!layoutFile.isFile()) {
			return 0;
		}

		DataTypeManager manager = currentProgram.getDataTypeManager();
		CategoryPath category = new CategoryPath("/Il2Cpp");
		Map<String, StructureDataType> structures = new LinkedHashMap<String, StructureDataType>();
		Map<String, List<String[]>> fieldsByStruct = new LinkedHashMap<String, List<String[]>>();
		String current = null;

		BufferedReader reader = null;
		try {
			reader = new BufferedReader(new FileReader(layoutFile));
			String line;
			while ((line = reader.readLine()) != null) {
				if (line.length() == 0 || line.charAt(0) == '#') {
					continue;
				}
				String[] parts = line.split("\t", -1);
				if (parts[0].equals("T") && parts.length >= 3) {
					int size = Integer.parseInt(parts[2]);
					if (size <= 0) {
						current = null;
						continue;
					}
					current = parts[1];
					structures.put(current, new StructureDataType(category, current, size, manager));
					fieldsByStruct.put(current, new ArrayList<String[]>());
				} else if (parts[0].equals("F") && parts.length >= 4 && current != null) {
					List<String[]> rows = fieldsByStruct.get(current);
					if (rows != null) {
						rows.add(new String[] { current, parts[1], parts[2], parts[3] });
					}
				}
			}
		} catch (Exception e) {
			println("WARNING: could not read the type layouts: " + e);
			return 0;
		} finally {
			try { if (reader != null) reader.close(); } catch (Exception ignored) { }
		}

		// Each struct is filled and then registered before the next one is started, because a later
		// struct may embed it and Ghidra resolves that by name against what is already registered.
		// Editing after registering would not work either: the manager keeps its own copy.
		int defined = 0;
		for (Map.Entry<String, StructureDataType> entry : structures.entrySet()) {
			StructureDataType structure = entry.getValue();

			List<String[]> rows = fieldsByStruct.get(entry.getKey());
			if (rows != null) {
				for (String[] row : rows) {
					try {
						int offset = Integer.parseInt(row[1]);
						DataType fieldType = resolveFieldType(manager, row[3]);
						if (fieldType == null || fieldType.getLength() <= 0 || offset + fieldType.getLength() > structure.getLength()) {
							continue;
						}
						structure.replaceAtOffset(offset, fieldType, fieldType.getLength(), row[2], null);
					} catch (Exception e) {
						// One bad field must not lose the whole type.
					}
				}
			}

			if (manager.addDataType(structure, DataTypeConflictHandler.REPLACE_HANDLER) != null) {
				defined++;
			}
		}

		return defined;
	}

	/// Maps the type names AssetRipper emits onto Ghidra's built in types.
	///
	/// The program's own type manager does not contain the built ins, so they have to be named
	/// directly rather than looked up.
	private DataType resolveFieldType(DataTypeManager manager, String cType) {
		if (cType == null || cType.length() == 0) {
			return null;
		}
		if (cType.endsWith("*")) {
			return new PointerDataType(manager);
		}
		if (cType.equals("bool")) return BooleanDataType.dataType;
		if (cType.equals("char")) return CharDataType.dataType;
		if (cType.equals("byte")) return ByteDataType.dataType;
		if (cType.equals("short")) return ShortDataType.dataType;
		if (cType.equals("ushort")) return UnsignedShortDataType.dataType;
		if (cType.equals("int")) return IntegerDataType.dataType;
		if (cType.equals("uint")) return UnsignedIntegerDataType.dataType;
		if (cType.equals("longlong")) return LongLongDataType.dataType;
		if (cType.equals("ulonglong")) return UnsignedLongLongDataType.dataType;
		if (cType.equals("float")) return FloatDataType.dataType;
		if (cType.equals("double")) return DoubleDataType.dataType;

		// A field may be another Il2Cpp struct. AssetRipper orders the layouts so that one is always
		// registered before anything embedding it.
		return manager.getDataType(new CategoryPath("/Il2Cpp"), cType);
	}

	/// AssetRipper parses these lines to show progress while the run is in flight.
	private void reportProgress(String phase, int done, int total) {
		println("PROGRESS phase=" + phase + " done=" + done + " total=" + total);
	}

	private FunctionSignatureParser signatureParser;

	private int applyNames(List<Symbol> symbols) {
		int named = 0;
		int typed = 0;
		int processed = 0;
		for (Symbol symbol : symbols) {
			if (monitor.isCancelled()) {
				break;
			}

			processed++;
			if (processed % NamingProgressInterval == 0) {
				reportProgress("naming", processed, symbols.size());
			}

			Address address = resolve(symbol.address);
			if (address == null) {
				continue;
			}

			try {
				Function function = getFunctionAt(address);
				if (function == null) {
					function = createFunction(address, symbol.name);
					// createFunction does not take a source, and calibration must be able to tell this
					// script's work apart from the analyzer's on a project that is processed twice.
					if (function != null && function.getSymbol() != null) {
						function.getSymbol().setSource(SourceType.IMPORTED);
					}
				} else {
					function.setName(symbol.name, SourceType.IMPORTED);
				}
				if (function != null) {
					named++;
					if (applySignature(address, symbol)) {
						typed++;
					}
				}
			} catch (Exception e) {
				// A single bad symbol must not abort the run.
			}
		}

		if (typed > 0) {
			println("Applied " + typed + " function signatures");
		}
		return named;
	}

	/// Gives Ghidra the real return and parameter types instead of letting it guess them from the
	/// machine code. AssetRipper leaves the signature empty when it could not map a type safely.
	private boolean applySignature(Address address, Symbol symbol) {
		if (symbol.signature.length() == 0) {
			return false;
		}

		try {
			if (signatureParser == null) {
				signatureParser = new FunctionSignatureParser(currentProgram.getDataTypeManager(), null);
			}

			FunctionDefinitionDataType definition = signatureParser.parse(null, symbol.signature);
			if (definition == null) {
				return false;
			}

			ApplyFunctionSignatureCmd command = new ApplyFunctionSignatureCmd(address, definition, SourceType.IMPORTED);
			return command.applyTo(currentProgram, monitor);
		} catch (Exception e) {
			// An unparseable prototype just means Ghidra keeps its own guess.
			return false;
		}
	}

	private String decompile(DecompInterface decompiler, Function function) {
		try {
			DecompileResults results = decompiler.decompileFunction(function, DecompileTimeoutSeconds, monitor);
			if (results == null || !results.decompileCompleted() || results.getDecompiledFunction() == null) {
				return null;
			}
			return results.getDecompiledFunction().getC();
		} catch (Exception e) {
			return null;
		}
	}

	/// Keeps each index record on a single line.
	private static String escape(String value) {
		StringBuilder builder = new StringBuilder(value.length() + 16);
		for (int i = 0; i < value.length(); i++) {
			char c = value.charAt(i);
			if (c == '\\') {
				builder.append("\\\\");
			} else if (c == '\n') {
				builder.append("\\n");
			} else if (c == '\r') {
				// Normalized away so the record never splits.
			} else if (c == '\t') {
				builder.append("\\t");
			} else {
				builder.append(c);
			}
		}
		return builder.toString();
	}

	private static String sanitize(String name) {
		StringBuilder builder = new StringBuilder(name.length());
		for (int i = 0; i < name.length(); i++) {
			char c = name.charAt(i);
			builder.append(Character.isLetterOrDigit(c) || c == '.' || c == '-' || c == '_' ? c : '_');
		}
		return builder.toString();
	}
}
