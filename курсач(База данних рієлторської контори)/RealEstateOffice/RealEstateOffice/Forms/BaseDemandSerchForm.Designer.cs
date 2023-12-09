
namespace RealEstateOffice.Forms {
  partial class BaseDemandSerchForm {
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      this.panel1 = new System.Windows.Forms.Panel();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.RegionTBox = new System.Windows.Forms.TextBox();
      this.RegionValiadtionLbl = new System.Windows.Forms.Label();
      this.LastNameLbl = new System.Windows.Forms.Label();
      this.RegionSearchBtn = new System.Windows.Forms.Button();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.AreaSearchBtn = new System.Windows.Forms.Button();
      this.AreaMinValiadtionLbl = new System.Windows.Forms.Label();
      this.AreaMinTBox = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.SearchPriceBtn = new System.Windows.Forms.Button();
      this.PriceTBox = new System.Windows.Forms.TextBox();
      this.label10 = new System.Windows.Forms.Label();
      this.PriceValiadtionLbl = new System.Windows.Forms.Label();
      this.BaseDemandGridView = new System.Windows.Forms.DataGridView();
      this.panel1.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.BaseDemandGridView)).BeginInit();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.groupBox3);
      this.panel1.Controls.Add(this.groupBox2);
      this.panel1.Controls.Add(this.groupBox1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(800, 96);
      this.panel1.TabIndex = 1;
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.RegionTBox);
      this.groupBox3.Controls.Add(this.RegionValiadtionLbl);
      this.groupBox3.Controls.Add(this.LastNameLbl);
      this.groupBox3.Controls.Add(this.RegionSearchBtn);
      this.groupBox3.Location = new System.Drawing.Point(540, 12);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(258, 72);
      this.groupBox3.TabIndex = 6;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Площа";
      // 
      // RegionTBox
      // 
      this.RegionTBox.Location = new System.Drawing.Point(87, 15);
      this.RegionTBox.MaxLength = 200;
      this.RegionTBox.Name = "RegionTBox";
      this.RegionTBox.Size = new System.Drawing.Size(152, 20);
      this.RegionTBox.TabIndex = 7;
      // 
      // RegionValiadtionLbl
      // 
      this.RegionValiadtionLbl.AutoSize = true;
      this.RegionValiadtionLbl.ForeColor = System.Drawing.Color.Red;
      this.RegionValiadtionLbl.Location = new System.Drawing.Point(68, 18);
      this.RegionValiadtionLbl.Name = "RegionValiadtionLbl";
      this.RegionValiadtionLbl.Size = new System.Drawing.Size(11, 13);
      this.RegionValiadtionLbl.TabIndex = 58;
      this.RegionValiadtionLbl.Text = "*";
      // 
      // LastNameLbl
      // 
      this.LastNameLbl.AutoSize = true;
      this.LastNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.LastNameLbl.Location = new System.Drawing.Point(15, 17);
      this.LastNameLbl.Name = "LastNameLbl";
      this.LastNameLbl.Size = new System.Drawing.Size(52, 16);
      this.LastNameLbl.TabIndex = 56;
      this.LastNameLbl.Text = "Район:";
      // 
      // RegionSearchBtn
      // 
      this.RegionSearchBtn.Location = new System.Drawing.Point(158, 41);
      this.RegionSearchBtn.Name = "RegionSearchBtn";
      this.RegionSearchBtn.Size = new System.Drawing.Size(81, 23);
      this.RegionSearchBtn.TabIndex = 8;
      this.RegionSearchBtn.Text = "Знайти";
      this.RegionSearchBtn.UseVisualStyleBackColor = true;
      this.RegionSearchBtn.Click += new System.EventHandler(this.RegionSearchBtn_Click);
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.AreaSearchBtn);
      this.groupBox2.Controls.Add(this.AreaMinValiadtionLbl);
      this.groupBox2.Controls.Add(this.AreaMinTBox);
      this.groupBox2.Controls.Add(this.label4);
      this.groupBox2.Location = new System.Drawing.Point(276, 12);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(258, 72);
      this.groupBox2.TabIndex = 3;
      this.groupBox2.TabStop = false;
      // 
      // AreaSearchBtn
      // 
      this.AreaSearchBtn.Location = new System.Drawing.Point(158, 41);
      this.AreaSearchBtn.Name = "AreaSearchBtn";
      this.AreaSearchBtn.Size = new System.Drawing.Size(81, 23);
      this.AreaSearchBtn.TabIndex = 5;
      this.AreaSearchBtn.Text = "Знайти";
      this.AreaSearchBtn.UseVisualStyleBackColor = true;
      this.AreaSearchBtn.Click += new System.EventHandler(this.AreaSearchBtn_Click);
      // 
      // AreaMinValiadtionLbl
      // 
      this.AreaMinValiadtionLbl.AutoSize = true;
      this.AreaMinValiadtionLbl.ForeColor = System.Drawing.Color.Red;
      this.AreaMinValiadtionLbl.Location = new System.Drawing.Point(127, 16);
      this.AreaMinValiadtionLbl.Name = "AreaMinValiadtionLbl";
      this.AreaMinValiadtionLbl.Size = new System.Drawing.Size(11, 13);
      this.AreaMinValiadtionLbl.TabIndex = 54;
      this.AreaMinValiadtionLbl.Text = "*";
      // 
      // AreaMinTBox
      // 
      this.AreaMinTBox.Location = new System.Drawing.Point(146, 13);
      this.AreaMinTBox.MaxLength = 200;
      this.AreaMinTBox.Name = "AreaMinTBox";
      this.AreaMinTBox.Size = new System.Drawing.Size(93, 20);
      this.AreaMinTBox.TabIndex = 4;
      this.AreaMinTBox.Text = "0";
      this.AreaMinTBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label4.Location = new System.Drawing.Point(6, 16);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(54, 16);
      this.label4.TabIndex = 49;
      this.label4.Text = "Площа:";
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.SearchPriceBtn);
      this.groupBox1.Controls.Add(this.PriceTBox);
      this.groupBox1.Controls.Add(this.label10);
      this.groupBox1.Controls.Add(this.PriceValiadtionLbl);
      this.groupBox1.Location = new System.Drawing.Point(12, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(258, 72);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      // 
      // SearchPriceBtn
      // 
      this.SearchPriceBtn.Location = new System.Drawing.Point(158, 41);
      this.SearchPriceBtn.Name = "SearchPriceBtn";
      this.SearchPriceBtn.Size = new System.Drawing.Size(81, 23);
      this.SearchPriceBtn.TabIndex = 2;
      this.SearchPriceBtn.Text = "Знайти";
      this.SearchPriceBtn.UseVisualStyleBackColor = true;
      this.SearchPriceBtn.Click += new System.EventHandler(this.SearchPriceBtn_Click);
      // 
      // PriceTBox
      // 
      this.PriceTBox.Location = new System.Drawing.Point(146, 15);
      this.PriceTBox.MaxLength = 10;
      this.PriceTBox.Name = "PriceTBox";
      this.PriceTBox.Size = new System.Drawing.Size(93, 20);
      this.PriceTBox.TabIndex = 1;
      this.PriceTBox.Text = "0";
      this.PriceTBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label10.Location = new System.Drawing.Point(6, 18);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(67, 16);
      this.label10.TabIndex = 51;
      this.label10.Text = "Вартість:";
      // 
      // PriceValiadtionLbl
      // 
      this.PriceValiadtionLbl.AutoSize = true;
      this.PriceValiadtionLbl.ForeColor = System.Drawing.Color.Red;
      this.PriceValiadtionLbl.Location = new System.Drawing.Point(127, 18);
      this.PriceValiadtionLbl.Name = "PriceValiadtionLbl";
      this.PriceValiadtionLbl.Size = new System.Drawing.Size(11, 13);
      this.PriceValiadtionLbl.TabIndex = 53;
      this.PriceValiadtionLbl.Text = "*";
      // 
      // BaseDemandGridView
      // 
      this.BaseDemandGridView.AllowUserToAddRows = false;
      this.BaseDemandGridView.AllowUserToDeleteRows = false;
      dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
      this.BaseDemandGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
      this.BaseDemandGridView.BackgroundColor = System.Drawing.SystemColors.Control;
      this.BaseDemandGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.BaseDemandGridView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.BaseDemandGridView.GridColor = System.Drawing.SystemColors.Control;
      this.BaseDemandGridView.Location = new System.Drawing.Point(0, 96);
      this.BaseDemandGridView.MultiSelect = false;
      this.BaseDemandGridView.Name = "BaseDemandGridView";
      this.BaseDemandGridView.ReadOnly = true;
      this.BaseDemandGridView.RowHeadersWidth = 20;
      dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.BaseDemandGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
      this.BaseDemandGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.BaseDemandGridView.Size = new System.Drawing.Size(800, 354);
      this.BaseDemandGridView.TabIndex = 90;
      this.BaseDemandGridView.TabStop = false;
      // 
      // BaseDemandSerchForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.BaseDemandGridView);
      this.Controls.Add(this.panel1);
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "BaseDemandSerchForm";
      this.Text = "Пошук по базі попиту";
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BaseDemandSerchForm_KeyDown);
      this.panel1.ResumeLayout(false);
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.BaseDemandGridView)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.TextBox RegionTBox;
    private System.Windows.Forms.Label RegionValiadtionLbl;
    private System.Windows.Forms.Label LastNameLbl;
    private System.Windows.Forms.Button RegionSearchBtn;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Button AreaSearchBtn;
    private System.Windows.Forms.Label AreaMinValiadtionLbl;
    private System.Windows.Forms.TextBox AreaMinTBox;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button SearchPriceBtn;
    private System.Windows.Forms.TextBox PriceTBox;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label PriceValiadtionLbl;
    private System.Windows.Forms.DataGridView BaseDemandGridView;
  }
}