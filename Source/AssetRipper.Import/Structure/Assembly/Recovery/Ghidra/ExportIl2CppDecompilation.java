// Decompiles the functions listed in an Il2Cpp symbol file and writes the results grouped by assembly.
//
// Run by AssetRipper through analyzeHeadless. Arguments:
//   [0] path to the tab separated symbol file: address <TAB> group <TAB> name
//   [1] directory to write the decompiled output into
//
//@category AssetRipper

import ghidra.app.decompiler.DecompInterface;
import ghidra.app.decompiler.DecompileResults;
import ghidra.app.script.GhidraScript;
import ghidra.program.model.address.Address;
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

	private static final class Symbol {
		final long address;
		final String group;
		final String name;

		Symbol(long address, String group, String name) {
			this.address = address;
			this.group = group;
			this.name = name;
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

		int named = applyNames(symbols);
		println("Applied " + named + " function names");

		DecompInterface decompiler = new DecompInterface();
		try {
			if (!decompiler.openProgram(currentProgram)) {
				println("ERROR: could not open the program for decompilation");
				return;
			}

			Map<String, StringBuilder> outputByGroup = new LinkedHashMap<String, StringBuilder>();
			int succeeded = 0;
			int failed = 0;

			for (Symbol symbol : symbols) {
				if (monitor.isCancelled()) {
					break;
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
				succeeded++;
			}

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
			println("RESULT decompiled=" + succeeded + " failed=" + failed);
		} finally {
			decompiler.dispose();
		}
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
				symbols.add(new Symbol(address, parts[1], parts[2]));
			}
		} finally {
			reader.close();
		}
		return symbols;
	}

	/// Il2Cpp reports addresses in the binary's own address space, which does not always match the
	/// base Ghidra loaded the image at.
	private Address resolve(long rawAddress) {
		Address address = toAddr(rawAddress);
		if (address != null && currentProgram.getMemory().contains(address)) {
			return address;
		}

		Address rebased = currentProgram.getImageBase().add(rawAddress);
		if (currentProgram.getMemory().contains(rebased)) {
			return rebased;
		}

		return null;
	}

	private int applyNames(List<Symbol> symbols) {
		int named = 0;
		for (Symbol symbol : symbols) {
			if (monitor.isCancelled()) {
				break;
			}

			Address address = resolve(symbol.address);
			if (address == null) {
				continue;
			}

			try {
				Function function = getFunctionAt(address);
				if (function == null) {
					function = createFunction(address, symbol.name);
				} else {
					function.setName(symbol.name, SourceType.IMPORTED);
				}
				if (function != null) {
					named++;
				}
			} catch (Exception e) {
				// A single bad symbol must not abort the run.
			}
		}
		return named;
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

	private static String sanitize(String name) {
		StringBuilder builder = new StringBuilder(name.length());
		for (int i = 0; i < name.length(); i++) {
			char c = name.charAt(i);
			builder.append(Character.isLetterOrDigit(c) || c == '.' || c == '-' || c == '_' ? c : '_');
		}
		return builder.toString();
	}
}
