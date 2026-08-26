#!/usr/bin/env python3
"""
Repair the recurring patterns that make decompiled C# fail to compile.

Two modes:

  textual   -- pattern fixes that need no compiler feedback
  errors    -- fixes driven by a captured build log (accessibility, static
               classes used as parameter types, ...)

Usage:
    python fixdecompiled.py textual <dir> [...]
    python fixdecompiled.py errors  <dir> <build-log>
    python fixdecompiled.py all     <dir> <build-log>

Everything here comes from patterns actually hit while rebuilding the
DevXUnityUnpacker assemblies; see BUILD.md for what each one is.
"""
import os, re, sys, glob


def cs_files(root):
    for g in glob.glob(os.path.join(root, '**', '*.cs'), recursive=True):
        if os.sep + 'obj' + os.sep in g or os.sep + 'bin' + os.sep in g:
            continue
        yield g


def read(f):
    return open(f, encoding='utf-8-sig').read()


def write(f, t):
    open(f, 'w', encoding='utf-8-sig', newline='').write(t)


# ---------------------------------------------------------------- textual ---

def fix_base_ctor(lines):
    """`base._002Ector(args);` in a body -> `: base(args)` on the signature."""
    n = 0
    i = 0
    while i < len(lines):
        m = re.match(r'^(\s*)base\._002Ector\((.*)\);\s*$', lines[i])
        if not m:
            i += 1
            continue
        args = m.group(2).strip()
        j = i - 1
        while j >= 0 and lines[j].strip() != '{':
            j -= 1
        if j < 0:
            i += 1
            continue
        k = j - 1
        while k >= 0 and lines[k].strip() == '':
            k -= 1
        if args:
            indent = re.match(r'^\s*', lines[k]).group(0)
            lines[k] = lines[k].rstrip() + '\n' + indent + '\t: base(' + args + ')'
        del lines[i]
        n += 1
    return n


def textual(root):
    counts = {}

    def bump(k, v=1):
        counts[k] = counts.get(k, 0) + v

    for f in cs_files(root):
        t = read(f)
        o = t

        # struct member access through a ref cast: ((Rect)(ref v)).x -> v.x
        t, k = re.subn(r'\(\((\w[\w\.]*)\)\(ref (\w+)\)\)', r'\2', t)
        bump('ref-struct access', k)

        # `((T)(ref v))._002Ector(a)` -> `v = new T(a)`
        t, k = re.subn(r'\(\((\w[\w\.]*)\)\(ref (\w+)\)\)\._002Ector\((.*?)\);',
                       r'\2 = new \1(\3);', t)
        bump('struct ctor call', k)

        # a concrete enumerator type the decompiler could not name
        t, k = re.subn(r'\bEnumerator<[^;=]*?> (\w+) = ', r'var \1 = ', t)
        bump('Enumerator<> -> var', k)

        # enum arithmetic in a switch: cases are ints, `enum - N` is an enum
        t, k = re.subn(r'switch \((operation|expressionType|type|op) - (\d+)\)',
                       r'switch ((int)\1 - \2)', t)
        bump('switch on enum arithmetic', k)

        # ConcurrentDictionary.TryGetValue takes `out`, not `ref`
        t, k = re.subn(r'(\.TryGetValue\([^;]*?), ref (\w+)\)', r'\1, out \2)', t)
        bump('TryGetValue ref -> out', k)

        # `(expr?)?.Member` parses as a nullable-type cast
        k = t.count('?)?.')
        if k:
            t = t.replace('?)?.', ')?.')
        bump('(x?)?. -> (x)?.', k)

        # explicit operator calls
        t, k = re.subn(r'(\w+)\.op_Implicit\(([^()]*(?:\([^()]*\)[^()]*)*)\)', r'(\1)(\2)', t)
        bump('op_Implicit -> cast', k)

        # get-only auto-property assigned in a constructor
        for name in set(re.findall(r'private readonly \w[\w\.<>\[\], ]* _003C(\w+)_003Ek__BackingField;', t)):
            t, k = re.subn(r'(\n\t\t)' + name + r' = ',
                           r'\1_003C' + name + r'_003Ek__BackingField = ', t)
            bump('backing-field assignment', k)

        lines = t.split('\n')
        k = fix_base_ctor(lines)
        bump('base._002Ector -> initializer', k)
        t = '\n'.join(lines)

        if t != o:
            write(f, t)

    for k in sorted(counts):
        if counts[k]:
            print('  %-34s %d' % (k, counts[k]))
    return counts


# ----------------------------------------------------------------- errors ---

def errors(root, log):
    text = open(log, encoding='utf-8', errors='replace').read()

    # CS0721: IL allows an abstract-sealed type as a parameter type, C# does not
    statics = set(re.findall(r"CS0721: '([\w\.]+?)(?:<[^']*>)?': static types cannot be used as parameters", text))
    statics = {s.split('.')[-1] for s in statics}
    n = 0
    if statics:
        for f in cs_files(root):
            t = read(f)
            o = t
            for s in statics:
                t = re.sub(r'\b(public|internal|private|protected)\s+static\s+class\s+' + re.escape(s) + r'\b',
                           r'\1 class ' + s, t)
            if t != o:
                write(f, t)
                n += 1
        print('  %-34s %d types across %d files' % ('static class -> class', len(statics), n))

    # CS0122 / CS0051 / CS0053: obfuscated IL reaches private and protected
    # members across type boundaries; widen to internal
    if re.search(r'CS0122|CS0051|CS0053', text):
        decls = 0
        files = 0
        for f in cs_files(root):
            lines = read(f).split('\n')
            k = 0
            for i, l in enumerate(lines):
                if re.match(r'^\s*private ', l):
                    lines[i] = re.sub(r'^(\s*)private ', r'\1internal ', l, count=1)
                    k += 1
                elif re.match(r'^\s*protected (?!internal )', l) and 'override' not in l:
                    lines[i] = re.sub(r'^(\s*)protected ', r'\1internal ', l, count=1)
                    k += 1
            if k:
                write(f, '\n'.join(lines))
                decls += k
                files += 1
        print('  %-34s %d declarations across %d files' % ('private/protected -> internal', decls, files))


def main():
    if len(sys.argv) < 3:
        print(__doc__)
        return 2
    mode, root = sys.argv[1], sys.argv[2]
    if mode in ('textual', 'all'):
        print('textual fixes:')
        textual(root)
    if mode in ('errors', 'all'):
        if len(sys.argv) < 4:
            print('errors mode needs a build log')
            return 2
        print('error-driven fixes:')
        errors(root, sys.argv[3])
    return 0


if __name__ == '__main__':
    sys.exit(main())
