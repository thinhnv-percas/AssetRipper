#!/usr/bin/env python3
r"""
Rewrite dnSpy's raw `\uXXXX` identifier escapes into ILSpy's `_XXXX` form.

dnSpy.Console writes obfuscated identifiers as literal `
...`
sequences. ` ` is a space, which is not a valid C# identifier character, so
Roslyn rejects every one of them (CS1056, thousands per assembly). ILSpy instead
sanitises the same names to `_0020_000A...`, which compiles.

Converting is a text transformation, but a blind search-and-replace would also
rewrite `\uXXXX` escapes inside string and char literals, corrupting data. This
walks each file with a small state machine so only escapes in *code* positions
are touched -- literals (including verbatim and interpolated strings) and
comments are left alone.

Usage:
    python unescape_ids.py <dir> [...]
    python unescape_ids.py --check <dir>     # report only, change nothing
"""
import os, re, sys, glob

ESC = re.compile(r'(?:\\u[0-9A-Fa-f]{4})+')


def convert_code(chunk):
    """Turn runs of \\uXXXX into _XXXX_XXXX... (ILSpy's spelling)."""
    def repl(m):
        codes = re.findall(r'\\u([0-9A-Fa-f]{4})', m.group(0))
        return '_' + '_'.join(c.upper() for c in codes)
    return ESC.sub(repl, chunk)


def process(text):
    """Split into code / literal / comment spans and only convert the code ones."""
    out = []
    i = 0
    n = len(text)
    code_start = 0
    changed = 0

    def flush(end):
        nonlocal changed
        seg = text[code_start:end]
        new = convert_code(seg)
        if new != seg:
            changed += 1
        out.append(new)

    while i < n:
        c = text[i]
        nxt = text[i + 1] if i + 1 < n else ''

        if c == '/' and nxt == '/':                       # line comment
            flush(i)
            j = text.find('\n', i)
            j = n if j < 0 else j
            out.append(text[i:j])
            i = code_start = j
            continue

        if c == '/' and nxt == '*':                       # block comment
            flush(i)
            j = text.find('*/', i + 2)
            j = n if j < 0 else j + 2
            out.append(text[i:j])
            i = code_start = j
            continue

        if c == '@' and nxt == '"':                       # verbatim string
            flush(i)
            j = i + 2
            while j < n:
                if text[j] == '"':
                    if j + 1 < n and text[j + 1] == '"':
                        j += 2
                        continue
                    j += 1
                    break
                j += 1
            out.append(text[i:j])
            i = code_start = j
            continue

        if c == '"' or c == "'":                          # string / char literal
            flush(i)
            q = c
            j = i + 1
            while j < n:
                if text[j] == '\\':
                    j += 2
                    continue
                if text[j] == q:
                    j += 1
                    break
                if text[j] == '\n':                       # unterminated: bail out
                    break
                j += 1
            out.append(text[i:j])
            i = code_start = j
            continue

        i += 1

    flush(n)
    return ''.join(out), changed


def main():
    args = sys.argv[1:]
    check = False
    if args and args[0] == '--check':
        check = True
        args = args[1:]
    if not args:
        print(__doc__)
        return 2

    files = touched = 0
    for root in args:
        for g in glob.glob(os.path.join(root, '**', '*.cs'), recursive=True):
            if os.sep + 'obj' + os.sep in g or os.sep + 'bin' + os.sep in g:
                continue
            files += 1
            t = open(g, encoding='utf-8-sig').read()
            if '\\u' not in t:
                continue
            new, _ = process(t)
            if new != t:
                touched += 1
                if not check:
                    open(g, 'w', encoding='utf-8-sig', newline='').write(new)
    print('%s %d of %d files' % ('would rewrite' if check else 'rewrote', touched, files))
    return 0


if __name__ == '__main__':
    sys.exit(main())
