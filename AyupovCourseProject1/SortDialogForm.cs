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
    public partial class SortDialogForm : Form
    {
        public SortDialogForm()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            Close();
        }

        private void ButtonSortReeiptDate_Click(object sender, EventArgs e)
        {

        }
    }
}
