#!/bin/bash
# Rips one fixture at script content level 3. `rip.sh <tag> <fixture-dir-name>`
# Output: Test/Out<tag>  log: Test/AR<tag>.log
set -u
cd "$(dirname "$0")/../.." || exit 1
export DOTNET_ROOT=${DOTNET_ROOT:-/home/user/.dotnet}
export PATH=$DOTNET_ROOT:$PATH
tag="$1"; fixture="$2"
rm -rf "Test/Out$tag"
dotnet Source/0Bins/AssetRipper.Tools.SystemTester/Release/AssetRipper.Tools.SystemTester.dll \
  --script-level 3 --reconstruct-bodies --struct-db StructDb \
  --output "Test/Out$tag" --log "Test/AR$tag.log" "Test/Input/$fixture"
echo "rip $tag exit=$?"
