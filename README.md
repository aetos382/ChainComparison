# ChainComparison

C# でチェーン比較式を書けるようにするライブラリです。

```csharp
// C# では通常このように書く必要がある
if (min <= value && value <= max) { ... }

// ChainComparison を使うと
if (min.ToChainComparable() <= value <= max) { ... }
```

## 使い方

`IComparable<T>` を実装した任意の型に対して使用できます。

```csharp
using ChainComparison;

int min = 0, value = 5, max = 10;

// 明示的にラップする方法
var wrapped = new ChainComparable<int>(min);
bool result = wrapped <= value <= max;  // true

// 暗黙的変換を使う方法
ChainComparable<int> start = 1;
bool inRange = start < 5 < 10;         // true

// 一方の端だけラップして、残りは通常の値で書ける
ChainComparable<int> a = 1;
bool ok = a < 2 < 3;  // true
```

## 対応演算子

`<`, `<=`, `>`, `>=`, `==`, `!=` のすべてに対応しています。

```csharp
ChainComparable<int> a = 1;
bool b1 = a < 2 < 3;    // true  (昇順)
bool b2 = a <= 1 <= 3;  // true  (等号を含む)
bool b3 = a > 0 > -1;   // false (降順)
bool b4 = a == 1 == 1;  // true  (等値)
```

## 評価の意味論

`a [op] b [op] c` は常に `a [op] b && b [op] c` と等価です。
ただし **`b` は 1 回のみ評価されます**。

```csharp
ChainComparable<int> GetValue() { /* 何らかの処理 */ return 5; }

ChainComparable<int> a = 1;
ChainComparable<int> c = 10;
bool result = a < GetValue() < c;
// GetValue() は 1 回だけ呼ばれる
// a < b && b < c と意味的に等価
```

前段の比較が `false` の場合、後段の比較演算は実行されません（短絡評価）。
ただし、C# の言語仕様により **オペランドの式は常に評価されます**。

```csharp
static ChainComparable<int> GetC() { Console.WriteLine("c を評価"); return 5; }

ChainComparable<int> a = 3, b = 1;
bool result = a < b < GetC();
// GetC() は呼ばれる（c の式は評価される）
```

## 対応フレームワーク

- .NET Standard 2.0 以上
- .NET 10.0

## ライセンス

[BSD-2-Clause-Patent](LICENSE)
