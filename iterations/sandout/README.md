# SandOut — số đo (`reports/SANDOUT_IPA.md`)

- `ARSO-first.log.gz` — rip 1, HEAD trước hai bản sửa; `ARSO-final.log.gz` — rip 3, cả hai bản sửa.
- `*-a.txt` — số đo của rip 1 (`rm`, `pf`, `stages`; `compile-a.txt` là rip 2 sau bản sửa skip, trước parse pass được
  chạy trước body pass). Không hậu tố — rip 3.
- `compile-stub.txt` / `compile-real.txt` — harness với stub / với `UNITY_EDITOR_DATA` của Editor 6000.0.72f1;
  `real-parse-errors.txt`, `parse-errors.txt`, `body-errors.txt`, `errors.txt` — dòng lỗi Roslyn tương ứng.
- Rip (`Test/OutSO*`) và IPA không commit; lệnh tái lập ở §6 của báo cáo.
