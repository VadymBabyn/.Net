
namespace RealEstateOffice {
  partial class RealEstateOfficeMDI {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.components = new System.ComponentModel.Container();
      this.menuStrip = new System.Windows.Forms.MenuStrip();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.пропозиційToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.попитуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.пошукToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.пропозиційToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.попитуToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.вихідToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolTip = new System.Windows.Forms.ToolTip(this.components);
      this.menuStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip
      // 
      this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.пошукToolStripMenuItem,
            this.вихідToolStripMenuItem});
      this.menuStrip.Location = new System.Drawing.Point(0, 0);
      this.menuStrip.Name = "menuStrip";
      this.menuStrip.Size = new System.Drawing.Size(999, 24);
      this.menuStrip.TabIndex = 0;
      this.menuStrip.Text = "MenuStrip";
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.пропозиційToolStripMenuItem,
            this.попитуToolStripMenuItem});
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(43, 20);
      this.toolStripMenuItem1.Text = "База";
      // 
      // пропозиційToolStripMenuItem
      // 
      this.пропозиційToolStripMenuItem.Name = "пропозиційToolStripMenuItem";
      this.пропозиційToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.пропозиційToolStripMenuItem.Text = "Пропозицій";
      this.пропозиційToolStripMenuItem.Click += new System.EventHandler(this.пропозиційToolStripMenuItem_Click);
      // 
      // попитуToolStripMenuItem
      // 
      this.попитуToolStripMenuItem.Name = "попитуToolStripMenuItem";
      this.попитуToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.попитуToolStripMenuItem.Text = "Попиту";
      this.попитуToolStripMenuItem.Click += new System.EventHandler(this.попитуToolStripMenuItem_Click);
      // 
      // пошукToolStripMenuItem
      // 
      this.пошукToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.пропозиційToolStripMenuItem1,
            this.попитуToolStripMenuItem1});
      this.пошукToolStripMenuItem.Name = "пошукToolStripMenuItem";
      this.пошукToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
      this.пошукToolStripMenuItem.Text = "Пошук";
      // 
      // пропозиційToolStripMenuItem1
      // 
      this.пропозиційToolStripMenuItem1.Name = "пропозиційToolStripMenuItem1";
      this.пропозиційToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
      this.пропозиційToolStripMenuItem1.Text = "Пропозицій";
      this.пропозиційToolStripMenuItem1.Click += new System.EventHandler(this.пропозиційToolStripMenuItem1_Click);
      // 
      // попитуToolStripMenuItem1
      // 
      this.попитуToolStripMenuItem1.Name = "попитуToolStripMenuItem1";
      this.попитуToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
      this.попитуToolStripMenuItem1.Text = "Попиту";
      this.попитуToolStripMenuItem1.Click += new System.EventHandler(this.попитуToolStripMenuItem1_Click);
      // 
      // вихідToolStripMenuItem
      // 
      this.вихідToolStripMenuItem.Name = "вихідToolStripMenuItem";
      this.вихідToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
      this.вихідToolStripMenuItem.Text = "Вихід";
      this.вихідToolStripMenuItem.Click += new System.EventHandler(this.вихідToolStripMenuItem_Click);
      // 
      // RealEstateOfficeMDI
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackgroundImage = global::RealEstateOffice.Properties.Resources.img_bk;
      this.ClientSize = new System.Drawing.Size(999, 516);
      this.Controls.Add(this.menuStrip);
      this.IsMdiContainer = true;
      this.MainMenuStrip = this.menuStrip;
      this.Name = "RealEstateOfficeMDI";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Система управління базою даних ріелторської контори";
      this.Resize += new System.EventHandler(this.RealEstateOfficeMDI_Resize);
      this.menuStrip.ResumeLayout(false);
      this.menuStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }
    #endregion


    private System.Windows.Forms.MenuStrip menuStrip;
    private System.Windows.Forms.ToolTip toolTip;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem пропозиційToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem попитуToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem пошукToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem пропозиційToolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem попитуToolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem вихідToolStripMenuItem;
  }
}



