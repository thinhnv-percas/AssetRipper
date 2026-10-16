#!/usr/bin/env python3
"""structdb_diff.py A B [--structs X,Y] [--types]
Semantic diff of two layout files: struct sizes, and every leaf field's position.
- a bitfield is compared by absolute bit (offset*8 + bitOffset), since generators differ on the storage-unit byte;
- an aggregate kept whole on one side and flattened to 'agg.member' on the other is not a difference
  as long as the members fit inside it;
- type spelling ('char*' vs 'char *', size_t vs unsigned long) is ignored unless --types."""
import gzip, json, re, sys

def load(p):
    raw = open(p, 'rb').read()
    if raw[:2] == b'\x1f\x8b':
        raw = gzip.decompress(raw)
    return json.loads(raw)

def pos(f):
    if 'bits' in f:
        return ('bit', f['offset'] * 8 + f.get('bitOffset', 0), f['bits'])
    return ('byte', f['offset'], f.get('size'))

a, b = load(sys.argv[1]), load(sys.argv[2])
only = set(sys.argv[sys.argv.index('--structs') + 1].split(',')) if '--structs' in sys.argv else None
types = '--types' in sys.argv
sa, sb = a['structs'], b['structs']
print('structs only in A:', sorted(set(sa) - set(sb)))
print('structs only in B:', sorted(set(sb) - set(sa)))
real = 0; cosmetic = 0
for n in sorted(set(sa) & set(sb)):
    if only and n not in only:
        continue
    x, y = sa[n], sb[n]
    out = []
    if x['size'] != y['size']:
        out.append(f'  SIZE {x["size"]} -> {y["size"]}')
    fx = {f['name']: f for f in x['fields']}; fy = {f['name']: f for f in y['fields']}
    def covered(name, other):
        # name is an aggregate on one side whose members are flattened on the other
        kids = [f for k, f in other.items() if k.startswith(name + '.')]
        return kids
    for k in list(fx) + [k for k in fy if k not in fx]:
        p, q = fx.get(k), fy.get(k)
        if p is None or q is None:
            have, other = (q, fx) if p is None else (p, fy)
            kids = covered(k, other)
            if kids:
                lo = have['offset']; hi = lo + (have.get('size') or 0)
                if all(lo <= c['offset'] < hi or (c['offset'] == lo) for c in kids):
                    cosmetic += 1; continue
            parts = k.split('.'); hit = False
            for i in range(len(parts) - 1, 0, -1):
                parent = '.'.join(parts[:i])
                if parent in other:
                    pf = other[parent]
                    hit = pf['offset'] <= have['offset'] < pf['offset'] + (pf.get('size') or 0)
                    break
            if hit:
                cosmetic += 1; continue
            out.append(f'  {k}: only in ' + ('B' if p is None else 'A') + ' @%#x' % have['offset'])
            continue
        if pos(p) != pos(q):
            out.append(f'  {k}: {pos(p)} -> {pos(q)}')
        elif types and re.sub(r'\s', '', p.get('type', '')) != re.sub(r'\s', '', q.get('type', '')):
            out.append(f'  {k}: type {p.get("type")} -> {q.get("type")}')
    if out:
        real += len(out); print(n); print('\n'.join(out))
print(f'TOTAL position/size differences: {real}  (aggregate flattening ignored: {cosmetic})')
