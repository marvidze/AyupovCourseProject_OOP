using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AyupovCourseProject1
{
    public partial class FilterDialogForm: Form
    {
        public DateTime startDate;
        public DateTime endTime;
        public FilterDialogForm()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            Close();
        }

        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            startDate = dateTimePickerFrom.Value;
            endTime = dateTimePickerTo.Value;
            if (startDate > endTime)
            {
                MessageBox.Show("Дата 'от' не может быть больше даты 'до'");
                return;
            }
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
