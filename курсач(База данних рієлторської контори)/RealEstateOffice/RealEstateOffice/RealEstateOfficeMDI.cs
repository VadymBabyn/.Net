using RealEstateOffice.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealEstateOffice {
  public partial class RealEstateOfficeMDI : Form {

    public RealEstateOfficeMDI() {
      InitializeComponent();
    }

    public void CloseAllWindows() {
      Form[] childArray = this.MdiChildren;
      foreach (Form childForm in childArray) {
        childForm.Close();
      }
    }

    private void пропозиційToolStripMenuItem_Click(object sender, EventArgs e) {
      CloseAllWindows();
      BaseOffersForm baseOffersForm = new BaseOffersForm();
      baseOffersForm.MdiParent = this;
      baseOffersForm.WindowState = FormWindowState.Maximized;
      baseOffersForm.Show();
    }

    private void попитуToolStripMenuItem_Click(object sender, EventArgs e) {
      CloseAllWindows();
      BaseDemandForm baseDemandForm = new BaseDemandForm();
      baseDemandForm.MdiParent = this;
      baseDemandForm.WindowState = FormWindowState.Maximized;
      baseDemandForm.Show();
    }

    private void пропозиційToolStripMenuItem1_Click(object sender, EventArgs e) {
      CloseAllWindows();
      BaseOffersSearchForm baseOffersSearchForm = new BaseOffersSearchForm();
      baseOffersSearchForm.MdiParent = this;
      baseOffersSearchForm.WindowState = FormWindowState.Maximized;
      baseOffersSearchForm.Show();
    }

    private void попитуToolStripMenuItem1_Click(object sender, EventArgs e) {
      CloseAllWindows();
      BaseDemandSerchForm baseDemandSerchForm = new BaseDemandSerchForm();
      baseDemandSerchForm.MdiParent = this;
      baseDemandSerchForm.WindowState = FormWindowState.Maximized;
      baseDemandSerchForm.Show();
    }

    private void вихідToolStripMenuItem_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void RealEstateOfficeMDI_Resize(object sender, EventArgs e) {
      this.BackgroundImage = Properties.Resources.img_bk;
    }
  }
}
