using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyupovCourseProject1
{
    public class MyDocument
    {
        public int ID { get; private set; }
        public string SenderName { get; set; } = "Отсутствует значение";
        public string DocumentTitle { get; set; } = "Отсутствует значение";
        public DateTime ReceiptDate { get; set; } = DateTime.Now;
        public string DocumentTopic { get; set; } = "Созданный по умолчанию документ";
        public string DocumentContent { get; set; } = "";
        public static int CountOfElements { get; private set; } = 0;

        public MyDocument()
        {
            CountOfElements++;
            ID = CountOfElements;
        }

        public MyDocument(string senderName, string documentTitle, DateTime receiptDate, string documentTopic, string documentContetnt) : this()
        {
            SenderName = senderName;
            DocumentTitle = documentTitle;
            ReceiptDate = receiptDate;
            DocumentTopic = documentTopic;
            DocumentContent = documentContetnt;
        }
    }
}
