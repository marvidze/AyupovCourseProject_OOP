using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace AyupovCourseProject1
{
    public class DocumentPdfTemplate : IDocument
    {
        private List<MyDocument> documents;

        /// <summary>
        /// Конструктор класса DocumentPdfTemplate
        /// </summary>
        /// <param name="documents"></param>
        public DocumentPdfTemplate(List<MyDocument> documents)
        {
            this.documents = documents;
        }

        /// <summary>
        /// Возвращает метаданные PDF-документа
        /// </summary>
        /// <returns>метаданные PDF-документа</returns>
        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        /// <summary>
        /// Основной метод, который формирует содержимое PDF
        /// </summary>
        /// <param name="container"></param>
        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(12));

                page.Header()
                    .AlignCenter()
                    .Text("Список документов")
                    .FontSize(20)
                    .SemiBold();

                page.Content()
                    .PaddingVertical(1, Unit.Centimetre)
                    .Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(); 
                            columns.RelativeColumn(3);
                            columns.RelativeColumn(3); 
                            columns.RelativeColumn(3); 
                            columns.RelativeColumn(3); 
                            columns.RelativeColumn(5); 
                        });

                        table.Header(header =>
                        {
                            header.Cell().Text("ID").Bold();
                            header.Cell().Text("Имя отправителя").Bold();
                            header.Cell().Text("Заголовок").Bold();
                            header.Cell().Text("Дата создания").Bold();
                            header.Cell().Text("Тема").Bold();
                            header.Cell().Text("Содержание").Bold();

                            header.Cell().ColumnSpan(6)
                                .PaddingTop(5).BorderBottom(2)
                                .BorderColor(Colors.Grey.Lighten2);
                        });

                        foreach (MyDocument doc in documents)
                        {
                            table.Cell().Text(doc.ID.ToString());
                            table.Cell().Text(doc.SenderName);
                            table.Cell().Text(doc.DocumentTitle);
                            table.Cell().Text(doc.ReceiptDate.ToString("dd.MM.yyyy"));
                            table.Cell().Text(doc.DocumentTopic);
                            table.Cell().Text(doc.DocumentContent);
                        }
                    });

                page.Footer()
                    .AlignCenter()
                    .Text(x =>
                    {
                        x.Span("Страница ");
                        x.CurrentPageNumber();
                    });
            });
        }
    }
}
