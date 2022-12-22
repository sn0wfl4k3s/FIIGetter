using FIIGetter;

FundsExplorer
    .GetData()
    .Where(f => f.LiquidezDiaria > 20_000)
    .OrderByDescending(f => f.LiquidezDiaria)
    .OrderByDescending(f => f.CustoBeneficio())
    .GroupBy(f => f.Codigo)
    .Select(fs => fs.MinBy(f => f.LiquidezDiaria))
    .Take(10)
    .ToList()
    .ForEach(f => Console.WriteLine(f));
