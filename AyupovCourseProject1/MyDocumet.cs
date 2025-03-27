using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyupovCourseProject1
{
    public class MyDocument
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string SenderName { get; set; } = "Отсутствует значение";
        public string DocumentTitle { get; set; } = "Отсутствует значение";
        public DateTime ReceiptDate { get; set; } = DateTime.Now;
        public string DocumentTopic { get; set; } = "Созданный по умолчанию документ";
        public string DocumentContent { get; set; } = "";

        
        /// <summary>
        /// Конструктор по умолчанию класса MyDocument
        /// </summary>
        public MyDocument() { }

        /// <summary>
        /// Конструктор с параметрами класса MyDocument
        /// </summary>
        /// <param name="senderName">Имя отправителя</param>
        /// <param name="documentTitle">Заголовок документа</param>
        /// <param name="receiptDate">Дата созания документа</param>
        /// <param name="documentTopic">Тема документа</param>
        /// <param name="documentContetnt">Содержание документа</param>
        public MyDocument(string senderName, string documentTitle, DateTime receiptDate, string documentTopic, string documentContetnt)
        {
            SenderName = senderName;
            DocumentTitle = documentTitle;
            ReceiptDate = receiptDate;
            DocumentTopic = documentTopic;
            DocumentContent = documentContetnt;
        }
    }
}
