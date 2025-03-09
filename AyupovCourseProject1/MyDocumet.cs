using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyupovCourseProject1
{
    class MyDocumet
    {
        public int ID { get; private set; }
        public string SenderName { get; private set; } = "Отсутствует значение";
        public string DocumentTitle { get; private set; } = "Отсутствует значение";
        public DateTime ReceiptDate { get; private set; } = DateTime.Now;
        public string DocumentTopic { get; private set; } = "Созданный по умолчанию документ";
        public string DocumentContetnt { get; private set; } = "";
        public static int CountOfElements { get; private set; } = 0;

        public MyDocumet()
        {
            CountOfElements++;
            ID = CountOfElements;
        }

        public MyDocumet(string senderName, string documentTitle, DateTime receiptDate, string documentTopic, string documentContetnt) : this()
        {
            SenderName = senderName;
            DocumentTitle = documentTitle;
            ReceiptDate = receiptDate;
            DocumentTopic = documentTopic;
            DocumentContetnt = documentContetnt;
        }
    }
}
