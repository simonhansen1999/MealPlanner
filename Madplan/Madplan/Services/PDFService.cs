using Madplan.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;

namespace Madplan.Services
{
    public class PDFService
    {
        public byte[] CreatePDF(List<AggregatedItem> items, string? listName = null)
        {
            var now = DateTime.Now;

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(35);
                    page.DefaultTextStyle(x => x.FontSize(11).FontFamily("Helvetica"));

                    // ───── HEADER ─────────────────────────────
                    page.Header().Column(header =>
                    {
                        header.Item().AlignCenter()
                            .Text(listName ?? "Indkøbsliste")
                            .FontSize(20)
                            .Bold()
                            .FontColor(Colors.Grey.Darken3);

                        header.Item().AlignCenter()
                            .Text($"Udskrevet {now:dd. MMMM yyyy}")
                            .FontSize(9)
                            .FontColor(Colors.Grey.Darken1);

                        header.Item().PaddingTop(10)
                            .LineHorizontal(1)
                            .LineColor(Colors.Grey.Lighten2);
                    });

                    // ───── CONTENT ────────────────────────────
                    page.Content().PaddingTop(15).Table(table =>
                    {
                        // Columns: checkbox, name, quantity, unit
                        table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(28);   // Checkbox
                            columns.RelativeColumn(1); // Name max width
                            columns.ConstantColumn(50);   // Quantity
                            columns.ConstantColumn(50);   // Unit
                        });

                        // Header row
                        table.Header(header =>
                        {
                            header.Cell().PaddingVertical(6);
                            header.Cell().Text("Vare").Bold();
                            header.Cell().Text("Antal").Bold();
                            header.Cell().Text("Enhed").Bold();

                            // Light separator below header
                            header.Cell().ColumnSpan(4)
                                .PaddingBottom(4)
                                .LineHorizontal(1)
                                .LineColor(Colors.Grey.Lighten2);
                        });

                        // Rows
                        bool even = false;

                        foreach (var item in items.OrderBy(i => i.IsManual).ThenBy(i => i.Name))
                        {
                            var bg = even ? Colors.Grey.Lighten4 : Colors.White;
                            even = !even;

                            // Checkbox cell
                            table.Cell()
                                .Background(bg)
                                .Padding(6)
                                .Border(1)
                                .Width(14)
                                .Height(14);

                            // Name
                            table.Cell()
                                .Background(bg)
                                .PaddingVertical(6)
                                .PaddingRight(5)
                                .Text(item.Name);

                            // Quantity
                            table.Cell()
                                .Background(bg)
                                .Padding(6)
                                .Text(item.Quantity.ToString("0.##"));

                            // Unit
                            table.Cell()
                                .Background(bg)
                                .Padding(6)
                                .Text(item.Unit);
                        }
                    });

                    // ───── FOOTER ─────────────────────────────
                    page.Footer().PaddingTop(10).AlignRight().Text(x =>
                    {
                        x.Span("Side ").FontSize(9).FontColor(Colors.Grey.Darken1);
                        x.CurrentPageNumber().FontSize(9).FontColor(Colors.Grey.Darken1);
                        x.Span(" / ").FontSize(9).FontColor(Colors.Grey.Darken1);
                        x.TotalPages().FontSize(9).FontColor(Colors.Grey.Darken1);
                    });
                });
            });

            return document.GeneratePdf();
        }
    }
}
