# Zadání samostatné práce – Unit testy

## Rozdělení skupin
- **Skupina C:** `Kosik.cs`
- **Skupina D:** `SpravaUzivatelu.cs`

---

## 📋 Pokyny k vypracování

1. **Stažení souboru:** Každý si ze svého repozitáře nebo týmu stáhne třídu určenou pro svou skupinu.
2. **Tvorba testů:** Vytvořte nový testovací projekt (MSTest) a napište unit testy pro metody ve vaší třídě.
3. **Odevzdání:** Celý vypracovaný projekt (včetně testů) odešlete v termínu přes **MS Teams**.

---

## 💡 Nápověda: Porovnávání kolekcí a polí

Pro ověřování výsledků metod, které vracejí pole nebo seznamy (např. `string[]` nebo `List<string>`), nepoužívejte klasický `Assert.AreEqual`. 

Pro kolekce slouží třída **`CollectionAssert`**:

```csharp
// Ověří, zda dvě kolekce obsahují přesně stejné prvky ve stejném pořadí
CollectionAssert.AreEqual(ocekavanePole, skutecnePole);
