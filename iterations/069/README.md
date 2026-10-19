# Iteration 069 — số đo cho kế hoạch (chưa phải iteration hoàn chỉnh)

Bản rip và phép đo đứng sau `docs/ITERATION_069_PLAN.md`, tạo trong container trống từ commit `68db4b31`:

- `logs/AR69s-*.log.gz` — baseline (source nguyên bản), `AR69g-*.log.gz` — với `patch-lazy-basetype-v2.diff` áp vào
  `Source/External/Cpp2IL.Core/Model/Contexts/GenericInstanceTypeAnalysisContext.cs` (chưa commit, xem kế hoạch mục A1).
  Tag: `i` Impostor, `p` Pinata, `j` JellyBlastV2, `z` RunFromZombies, `m` Merge-Room.
- `metrics/rm-*` `recovery_metrics.py`, `pf-*` `placeholder_families.py`, `compile-*` harness Roslyn (có body pass),
  `bodyerr-*` lỗi thân, `gc-*` golden corpus, `lbc-*` corpus hành vi tĩnh (Impostor), `loads-69d-p.tsv.gz`
  `CPP2IL_DUMP_LOADS` của Pinata trước patch.
- Rip output (`Test/Out69*`) không commit, tái lập bằng lệnh ở phụ lục B của kế hoạch.

## Cổng project (`reports/PROJECT_GATES_069.md`)

- `logs/AR69n-*.log.gz` — 5 fixture, Decompiled, sau C1 + abstract struct + luật Move (abstract struct còn ở luật cũ
  `BuildStubType`: `__Il2CppFullySharedGenericType` vẫn `abstract struct`); `AR69r-z.log.gz` — RunFromZombies với luật
  cuối (`ConfigureHierarchy`), khác 69n-z đúng một file; `AR69h-z.log.gz` — Hybrid + `--unity-editor`.
- `metrics/{rm,pf,gc,compile}-69n-*` so với `metrics/*-69s-*` (i, z, m) và `structdb/metrics/*-69k-*` (p, j).
- `miniunity/stages-69h-z.json` — `validate_unity_stages.py --miniunity` trên rip Hybrid; `miniunity/gate-69r-z.json`
  — `miniunity_gate.py` trên rip Decompiled (2854 lỗi, toàn bộ Newtonsoft.Json); `miniunity/rfz-hybrid-Game_4s.png`.
