using RealEstateOffice.AppCode;
using RealEstateOffice.BLL;
using RealEstateOffice.Providers;
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
  public partial class BaseDemandSerchForm : Form {
    private Validation _validation = new Validation();
    private BaseDemandProvider _BaseDemandProvider = new BaseDemandProvider();
    private List<BaseDemand> _BaseDemandList = new List<BaseDemand>();
    private SearchBLL _SearchBLL = new SearchBLL();


    public BaseDemandSerchForm() {
      InitializeComponent();
    }

    private void SearchPriceBtn_Click(object sender, EventArgs e) {
      if (IsDataEnteringCorrect()) {
        _BaseDemandList = _SearchBLL.GetBaseDemandByPrice(Convert.ToDouble(PriceTBox.Text));
        SetNumber();
        LoadDataInBaseDemandGridView(_BaseDemandList);
      }
    }

    private void AreaSearchBtn_Click(object sender, EventArgs e) {
      if (IsDataAreaCorrect()) {
        _BaseDemandList = _SearchBLL.GetBaseDemandByArea(Convert.ToInt32(AreaMinTBox.Text));
        SetNumber();
        LoadDataInBaseDemandGridView(_BaseDemandList);
      }
    }

    private void RegionSearchBtn_Click(object sender, EventArgs e) {
      if (IsDataRegionorrect()) {
        _BaseDemandList = _SearchBLL.GetBaseDemandByRegion(RegionTBox.Text);
        SetNumber();
        LoadDataInBaseDemandGridView(_BaseDemandList);
      }
    }

    private void SetNumber() {
      for (int i = 0; i < _BaseDemandList.Count; i++) {
        _BaseDemandList[i].Number = i + 1;
      }
    }

    private void LoadDataInBaseDemandGridView(List<BaseDemand> BaseDemandList) {
      BaseDemandGridView.DataSource = null;
      BaseDemandGridView.Columns.Clear();
      BaseDemandGridView.AutoGenerateColumns = false;
      BaseDemandGridView.RowHeadersVisible = false;

      BaseDemandGridView.DataSource = BaseDemandList;

      DataGridViewColumn numberColumn = new DataGridViewTextBoxColumn();
      numberColumn.HeaderText = "№";
      numberColumn.DataPropertyName = "Number";
      numberColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
      numberColumn.Width = 60;
      BaseDemandGridView.Columns.Add(numberColumn);

      DataGridViewColumn ClientCoordinatesColumn = new DataGridViewTextBoxColumn();
      ClientCoordinatesColumn.HeaderText = "Координати покупця";
      ClientCoordinatesColumn.DataPropertyName = "ClientCoordinates";
      ClientCoordinatesColumn.Width = 250;
      BaseDemandGridView.Columns.Add(ClientCoordinatesColumn);

      DataGridViewColumn RegionColumn = new DataGridViewTextBoxColumn();
      RegionColumn.HeaderText = "Район";
      RegionColumn.DataPropertyName = "Region";
      RegionColumn.Width = 150;
      BaseDemandGridView.Columns.Add(RegionColumn);

      DataGridViewColumn ApartmentAreaMinColumn = new DataGridViewTextBoxColumn();
      ApartmentAreaMinColumn.HeaderText = "Площа min";
      ApartmentAreaMinColumn.DataPropertyName = "ApartmentAreaMin";
      ApartmentAreaMinColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
      ApartmentAreaMinColumn.Width = 60;
      BaseDemandGridView.Columns.Add(ApartmentAreaMinColumn);

      DataGridViewColumn ApartmentAreaMaxColumn = new DataGridViewTextBoxColumn();
      ApartmentAreaMaxColumn.HeaderText = "Площа max";
      ApartmentAreaMaxColumn.DataPropertyName = "ApartmentAreaMax";
      ApartmentAreaMaxColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
      ApartmentAreaMaxColumn.Width = 60;
      BaseDemandGridView.Columns.Add(ApartmentAreaMaxColumn);

      DataGridViewColumn NumberRroomsColumn = new DataGridViewTextBoxColumn();
      NumberRroomsColumn.HeaderText = "Кімнати";
      NumberRroomsColumn.DataPropertyName = "NumberRrooms";
      NumberRroomsColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
      NumberRroomsColumn.Width = 50;
      BaseDemandGridView.Columns.Add(NumberRroomsColumn);

      DataGridViewColumn PriceMinColumn = new DataGridViewTextBoxColumn();
      PriceMinColumn.HeaderText = "Вартість min";
      PriceMinColumn.DataPropertyName = "PriceMin";
      PriceMinColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
      PriceMinColumn.Width = 80;
      BaseDemandGridView.Columns.Add(PriceMinColumn);

      DataGridViewColumn PriceMaxColumn = new DataGridViewTextBoxColumn();
      PriceMaxColumn.HeaderText = "Вартість max";
      PriceMaxColumn.DataPropertyName = "PriceMax";
      PriceMaxColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
      PriceMaxColumn.Width = 80;
      BaseDemandGridView.Columns.Add(PriceMaxColumn);

      for (int i = 0; i < BaseDemandGridView.Columns.Count; i++) {
        BaseDemandGridView.Columns[i].HeaderCell.Style.BackColor = Color.LightGray;
      }

    }


    private bool IsDataEnteringCorrect() {
      bool isCorrect = true;
      if (_validation.IsDataConvertToDouble(PriceTBox.Text)) {
        PriceValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        PriceValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      return isCorrect;
    }

    private bool IsDataAreaCorrect() {
      bool isCorrect = true;
      if (_validation.IsDataConvertToInt(AreaMinTBox.Text)) {
        AreaMinValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        AreaMinValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      return isCorrect;
    }

    private bool IsDataRegionorrect() {
      bool isCorrect = true;
      if (_validation.IsDataEntering(RegionTBox.Text)) {
        RegionValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        RegionValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      return isCorrect;
    }

    private void BaseDemandSerchForm_KeyDown(object sender, KeyEventArgs e) {
      if (e.KeyValue == (char)Keys.Escape) {
        this.Close();
      } else if (e.KeyValue == (char)Keys.F1) {
        HelpsForm hf = new HelpsForm();
        hf.Show();
      }
    }

  }
}
