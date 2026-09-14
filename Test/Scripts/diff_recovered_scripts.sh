#!/bin/bash
# Compares only the .cs files of two rips, which is the check that says whether a change touched the
# output at all.
#
# `diff -rq --include='*.cs' A B` is NOT a GNU diff option: it errors out, and with stderr discarded
# that reads as "no files differ". Three iterations reported an unchanged rip on that command without
# ever having compared one - the claims turned out to be true, but the evidence behind them was not.
set -u
a="$1"; b="$2"
work=$(mktemp -d)
trap 'rm -rf "$work"' EXIT

( cd "$a" && find . -name '*.cs' | sort ) > "$work/a.list"
( cd "$b" && find . -name '*.cs' | sort ) > "$work/b.list"

only=$(comm -3 "$work/a.list" "$work/b.list" | wc -l)
differ=0
while IFS= read -r f; do
  cmp -s "$a/$f" "$b/$f" || differ=$((differ + 1))
done < <(comm -12 "$work/a.list" "$work/b.list")

echo "only-in-one: $only  content-differs: $differ"
