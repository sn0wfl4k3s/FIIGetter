using FIIGetter.Extensions;
using FIIGetter.Models;
using HtmlAgilityPack;

namespace FIIGetter;

internal static class FundsExplorer
{
    public static IList<Fund> GetData()
    {
        var html = new HtmlDocument();

        var client = new HttpClient();

        var page = client.GetStringAsync("https://www.fundsexplorer.com.br/ranking").Result;

        html.LoadHtml(page);

        var table = html.GetElementbyId("table-ranking");

        var funds = new List<Fund>();

        foreach (var section in table.SelectNodes("tbody"))
        {
            foreach (var row in section.SelectNodes("tr"))
            {
                var cells = row.SelectNodes("td").ToArray();

                funds.Add(new Fund
                {
                    Codigo = cells[0].InnerText,
                    Setor = cells[1].InnerText,
                    PrecoAtual = cells[2].InnerText.Replace("R$", string.Empty).Trim().ToFloatOrNull(),
                    LiquidezDiaria = cells[3].InnerText.Trim().ToFloatOrNull(),
                    Dividendo = cells[4].InnerText.Replace("R$", string.Empty).Trim().ToFloatOrNull(),
                    DYAcumulado3M = cells[5].InnerText.Replace("%", string.Empty).Trim().ToFloatOrNull(),
                    DividendoYeld = cells[6].InnerText.Replace("%", string.Empty).Trim().ToFloatOrNull(),
                    DYAcumulado6M = cells[7].InnerText.Replace("%", string.Empty).Trim().ToFloatOrNull(),
                    DYAcumulado12M = cells[8].InnerText.Replace("%", string.Empty).Trim().ToFloatOrNull(),
                    DYMedia3M = cells[9].InnerText.Replace("%", string.Empty).Trim().ToFloatOrNull(),
                    DYMedia6M = cells[10].InnerText.Replace("%", string.Empty).Trim().ToFloatOrNull(),
                    DYMedia12M = cells[11].InnerText.Replace("%", string.Empty).Trim().ToFloatOrNull(),
                    DYAno = cells[12].InnerText.Replace("%", string.Empty).Trim().ToFloatOrNull(),
                    VariacaoPreco = cells[13].InnerText.Replace("%", string.Empty).Trim().ToFloatOrNull(),
                    RentabilidadePeriodo = cells[14].InnerText.Replace("%", string.Empty).Trim().ToFloatOrNull(),
                    RentabilidadeAcumulada = cells[15].InnerText.Replace("%", string.Empty).Trim().ToFloatOrNull(),
                    PatrimonioLiquido = cells[16].InnerText.Replace("%", string.Empty).Trim().ToFloatOrNull(),
                    VPA = cells[17].InnerText.Replace("%", string.Empty).Trim().ToFloatOrNull(),
                    PVPA = cells[18].InnerText.Replace("%", string.Empty).Trim().ToFloatOrNull(),
                    DYPatrimonial = cells[19].InnerText.Replace("%", string.Empty).Trim().ToFloatOrNull(),
                    VariacaoPatrimonial = cells[20].InnerText.Replace("%", string.Empty).Trim().ToFloatOrNull(),
                    RentabilidadePatrimonialPeriodo = cells[21].InnerText.Replace("%", string.Empty).Trim().ToFloatOrNull(),
                    RentabilidadePatrimonialAcumulada = cells[22].InnerText.Replace("%", string.Empty).Trim().ToFloatOrNull(),
                    VacanciaFisica = cells[23].InnerText.Replace("%", string.Empty).Trim().ToFloatOrNull(),
                    VacanciaFinanceira = cells[24].InnerText.Replace("%", string.Empty).Trim().ToFloatOrNull(),
                    QuantidadeAtivos = int.Parse(cells[25].InnerText),
                });
            }
        }

        return funds;
    }
}
