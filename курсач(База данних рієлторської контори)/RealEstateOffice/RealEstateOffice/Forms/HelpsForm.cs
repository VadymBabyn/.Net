using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealEstateOffice.Forms {
  public partial class HelpsForm : Form {
    public HelpsForm() {
      InitializeComponent();
    }

    private void HelpsForm_KeyDown(object sender, KeyEventArgs e) {
      if (e.KeyValue == (char)Keys.Escape) {
        this.Close();
      }
    }
  }
}
