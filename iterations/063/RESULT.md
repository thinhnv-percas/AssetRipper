# Iteration 063 — kết quả

Bản rip cuối: `Test/Out63g-{z,m,j,i,p}` (Impostor, Merge-Room, RunFromZombies, JellyBlastV2, Pinata) và
`Test/Out63o3-i` (JellyBlastV2, `CPP2IL_RECOVER_ALSO=Unity.TextMeshPro,UnityEngine.UI,Unity.Mathematics,
Unity.VisualScripting.Core`, chỉ để đo source oracle). Baseline: bản rip cuối 062 (`Out62m-*`), cùng script.

| | Impostor | Merge-Room | RunFromZombies | JellyBlastV2 | Pinata |
|---|---:|---:|---:|---:|---:|
| `Decompiling` lỗi / layout disagree / MonoBehaviour layout mismatch | 0/0/0 | 0/0/0 | 0/0/0 | 0/0/0 | 0/0/0 |
| EXACT | 4027 → 4042 | 11184 → 11221 | 2785 → 2785 | 3014 → 3027 | 12526 → 12533 |
| Placeholder (MEASUREMENT_CHANGE, FCMP) | 4291 → 4301 | 25580 → 25697 | 4578 → 4581 | 36304 → 36383 | 12974 → 12990 |
| Assembly-CSharp Roslyn (body pass) | 237 → 237 | 6 (2) → 5 (1) | 7 → 7 | 21 (10) → 11 (3038) | 1432 → 1355 |
| Golden improved / regressed | 2 / 3 | 2 / 1 | 0 / 0 | 9 / 0 | — |
| Storage TrueAlias | 1 | 0 | 0 | 2 | 0 |
| Logic interface corpus `--check` | 17/17 | 20/20 | 12 + 8 NOT_PRESENT | 19 + 1 STUBBED | — |
| Source behaviour | — | — | 1.0000 (35/35) | INDEPENDENT 0.6802 (904/1329) | — |

JellyBlast riêng:

| | |
|---|---|
| Provenance | source DERIVED từ IPA (`fe27775f`); 5 package PROVEN_BUILD_MATCH, PathCreator LIKELY; project SOURCE_MISMATCH |
| Serialized (so với derivation root) | GameObject 106/106, reference 228/228, script binding 173/173 |
| Prefab | 26 MATCH, 23 SOURCE_EDIT, 0 lỗi phục hồi, 21 NOT_IN_BUILD |
| Metal | 780 MSL (336 vertex, 444 fragment), 532 khác nhau, 384 parameter block, 0 `MTLB` |
| MSL vs source | TMP 3/3 agree (độc lập); Custom rebuilt 9 agree / 9 differ (build là tham chiếu) |
| P/Invoke | 131 `[DllImport("__Internal")]` khôi phục |
| Unity build (source 62f2, phục hồi 53f1) | `UNITY_NOT_AVAILABLE`, runtime `NOT_RUN`; 260 runtime scenario, 0 expected_state xác định |

Nguyên liệu: `provenance/`, `source-oracle/`, `serialized/`, `project/`, `shader/`, `metrics/`,
`unity-build/`.
