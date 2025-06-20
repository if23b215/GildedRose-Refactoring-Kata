Testing Strategy: 
Each test isolates one rule of the Gilded Rose kata—generic items degrade by 1 (or 2 after SellIn), 
Aged Brie improves (capped at 50), 
Sulfuras never changes, and 
Backstage passes have tiered increases then drop to zero. 
Tests use one item and clear assertion so any failure correctly identifies the violated rule.

Challenge Faced:
Because we’d already covered the Gilded Rose in a previous TDD course, the overall rules weren’t hard to grasp. Pinning down the exact thresholds for each item (“>10”, “6–10”, “1–5”, “≤0”) was still time-consuming and required careful, off-by-one–safe double-checking.