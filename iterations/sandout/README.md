# SandOut — số đo (`reports/SANDOUT_IPA.md`)

- `ARSO-first.log.gz` — rip 1, HEAD trước hai bản sửa; `ARSO-final.log.gz` — rip 3, cả hai bản sửa.
- `*-a.txt` — số đo của rip 1 (`rm`, `pf`, `stages`; `compile-a.txt` là rip 2 sau bản sửa skip, trước parse pass được
  chạy trước body pass). Không hậu tố — rip 3.
- `compile-stub.txt` / `compile-real.txt` — harness với stub / với `UNITY_EDITOR_DATA` của Editor 6000.0.72f1;
  `real-parse-errors.txt`, `parse-errors.txt`, `body-errors.txt`, `errors.txt` — dòng lỗi Roslyn tương ứng.
- Rip (`Test/OutSO*`) và IPA không commit; lệnh tái lập ở §6 của báo cáo.
- `ARSOR3.log.gz` — rip DLL + `--runtime-safe-bodies`, bản đã đẩy lên nhánh `project/sandout`;
  `runtime-safe/RuntimeSafeBodies.json.gz` — mọi thân bị thay và lý do; `runtime-safe/impostor-*` — Impostor trước
  (69s) và sau ba sửa generator.
- `miniunity/gate-runtime-safe-30s.json` + `recovered-*_29.0s.png` — cổng MiniUnity 30 s/scene trên bản đó;
  `miniunity/miniunity-sandout.diff` + `generated-edits.md` — bản vá MiniUnity cục bộ (cả `jit.check` và đếm message).
