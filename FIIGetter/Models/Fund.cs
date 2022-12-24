namespace FIIGetter.Models;

internal class Fund
{
    public string Codigo { get; set; }
    public string Setor { get; set; }
    public float? PrecoAtual { get; set; }
    public float? LiquidezDiaria { get; set; }
    public float? Dividendo { get; set; }
    public float? DividendoYeld { get; set; }
    public float? DYAcumulado3M { get; set; }
    public float? DYAcumulado6M { get; set; }
    public float? DYAcumulado12M { get; set; }
    public float? DYMedia3M { get; set; }
    public float? DYMedia6M { get; set; }
    public float? DYMedia12M { get; set; }
    public float? DYAno { get; set; }
    public float? VariacaoPreco { get; set; }
    public float? RentabilidadePeriodo { get; set; }
    public float? RentabilidadeAcumulada { get; set; }
    public float? PatrimonioLiquido { get; set; }
    public float? VPA { get; set; }
    public float? PVPA { get; set; }
    public float? DYPatrimonial { get; set; }
    public float? VariacaoPatrimonial { get; set; }
    public float? RentabilidadePatrimonialPeriodo { get; set; }
    public float? RentabilidadePatrimonialAcumulada { get; set; }
    public float? VacanciaFisica { get; set; }
    public float? VacanciaFinanceira { get; set; }
    public int QuantidadeAtivos { get; set; }

    public static implicit operator string (Fund f)
    {
        return string.Join(" - ", new string[]
        {
            $" - {f.Codigo}".PadRight(7),
            $"por R$ {f.PrecoAtual:00.00}".PadRight(13),
            $"rendendo R$ {f.Dividendo:00.00}".PadRight(18),
            $"custo/beneficio: {f.CustoBeneficio():00.00}%".PadRight(24),
            $"Negociacoes: {f.LiquidezDiaria}",
        });
    }

    public float CustoBeneficio()
    {
        if (Dividendo.HasValue && PrecoAtual.HasValue)
        {
            return Dividendo.Value * 100 / PrecoAtual.Value;
        }

        return 0f;
    }
}
