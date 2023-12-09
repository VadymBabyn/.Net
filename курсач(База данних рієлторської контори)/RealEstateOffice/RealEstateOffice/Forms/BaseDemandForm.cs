using RealEstateOffice.AppCode;
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
  public partial class BaseDemandForm : Form {
    public static BaseDemand _selectedBaseDemand = new BaseDemand();
    private int _selectedRowIndex = 0;
    private Validation _validation = new Validation();
    private BaseDemandProvider _BaseDemandProvider = new BaseDemandProvider();
    public static List<BaseDemand> _BaseDemandList = new List<BaseDemand>();

    public BaseDemandForm() {
      InitializeComponent();
      DataLoad();
    }

    private void AddBtn_Click(object sender, EventArgs e) {
      Add();
    }

    private void Add() {
      if (IsDataEnteringCorrect()) {
        BaseDemand BaseDemand = new BaseDemand(RegionTBox.Text, Convert.ToInt32(ApartmentAreaMinTBox.Text), Convert.ToInt32(ApartmentAreaMaxTBox.Text),
          Convert.ToInt32(NumberRroomsTBox.Text), ClientCoordinatesTBox.Text, Convert.ToDouble(PriceMinTBox.Text), Convert.ToDouble(PriceMaxTBox.Text));
        _BaseDemandList.Add(BaseDemand);
        _BaseDemandProvider.SaveBaseDemand(_BaseDemandList);
        DataLoad();
        ClearAllControls();
      }
    }

    private void ClearBtn_Click(object sender, EventArgs e) {
      ClearAllControls();
    }

    private void ExitBtn_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void BaseDemandGridView_CellClick(object sender, DataGridViewCellEventArgs e) {
      if (e.RowIndex >= 0) {
        _selectedRowIndex = e.RowIndex;
        _selectedBaseDemand = SelectBaseDemand(Convert.ToInt32(BaseDemandGridView[0, e.RowIndex].Value.ToString()), _BaseDemandList);
        UpdateBaseDemandForm updateBaseDemandForm = new UpdateBaseDemandForm();
        updateBaseDemandForm.ShowDialog();
        if (_selectedBaseDemand.IsDelete) {
          DeleteBaseDemandInfo(_selectedBaseDemand.Number);
        } else {
          SetDataInBaseDemandList();
        }
        _BaseDemandProvider.SaveBaseDemand(_BaseDemandList);
        DataLoad();
      }
    }

    private void DataLoad() {
      int firstRowIndex = 0;
      if (BaseDemandGridView.FirstDisplayedScrollingRowIndex > 0) {
        firstRowIndex = BaseDemandGridView.FirstDisplayedScrollingRowIndex;
      }
      try {
        _BaseDemandList.Clear();
        _BaseDemandList = _BaseDemandProvider.GetAllData();
        SetNumber();
        LoadDataInBaseDemandGridView(_BaseDemandList);
        if (_selectedRowIndex == BaseDemandGridView.Rows.Count) {
          _selectedRowIndex = BaseDemandGridView.Rows.Count - 1;
        }
        if (_selectedRowIndex >= 0) {
          BaseDemandGridView.FirstDisplayedScrollingRowIndex = firstRowIndex;
          BaseDemandGridView.Rows[_selectedRowIndex].Selected = true;
        }
      } catch (Exception ex) {
        MessageBox.Show(ex.ToString());
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

    private void ClearAllControls() {
      RegionTBox.Text = String.Empty;
      ApartmentAreaMinTBox.Text = "0";
      ApartmentAreaMaxTBox.Text = "0";
      NumberRroomsTBox.Text = "0";
      PriceMinTBox.Text = "0";
      PriceMaxTBox.Text = "0";
      ClientCoordinatesTBox.Text = String.Empty;
    }

    private bool IsDataEnteringCorrect() {
      bool isCorrect = true;
      if (_validation.IsDataEntering(RegionTBox.Text)) {
        RegionValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        RegionValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (_validation.IsDataConvertToInt(ApartmentAreaMinTBox.Text)) {
        ApartmentAreaMinValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        ApartmentAreaMinValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (_validation.IsDataConvertToInt(ApartmentAreaMaxTBox.Text)) {
        ApartmentAreaMaxValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        ApartmentAreaMaxValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (_validation.IsDataConvertToInt(NumberRroomsTBox.Text)) {
        NumberRroomsValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        NumberRroomsValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (_validation.IsDataConvertToInt(PriceMinTBox.Text)) {
        PriceMinValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        PriceMinValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (_validation.IsDataConvertToDouble(PriceMaxTBox.Text)) {
        PriceMaxValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        PriceMaxValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (_validation.IsDataEntering(ClientCoordinatesTBox.Text)) {
        ClientCoordinatesValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        ClientCoordinatesValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      return isCorrect;
    }

    private void SetDataInBaseDemandList() {
      for (int i = 0; i < _BaseDemandList.Count; i++) {
        if (_selectedBaseDemand.Number == _BaseDemandList[i].Number) {
          _BaseDemandList[i].Region = _selectedBaseDemand.Region;
          _BaseDemandList[i].ApartmentAreaMin = _selectedBaseDemand.ApartmentAreaMin;
          _BaseDemandList[i].ApartmentAreaMax = _selectedBaseDemand.ApartmentAreaMax;
          _BaseDemandList[i].NumberRrooms = _selectedBaseDemand.NumberRrooms;
          _BaseDemandList[i].PriceMin = _selectedBaseDemand.PriceMin;
          _BaseDemandList[i].PriceMax = _selectedBaseDemand.PriceMax;
          _BaseDemandList[i].ClientCoordinates = _selectedBaseDemand.ClientCoordinates;
        }
      }
    }

    private BaseDemand SelectBaseDemand(int Number, List<BaseDemand> BaseDemandList) {
      for (int i = 0; i < BaseDemandList.Count; i++) {
        if (Number == BaseDemandList[i].Number) {
          return BaseDemandList[i];
        }
      }
      return (new BaseDemand());
    }

    private void DeleteBaseDemandInfo(int Number) {
      for (int i = 0; i < _BaseDemandList.Count; i++) {
        if (Number == _BaseDemandList[i].Number) {
          _BaseDemandList.RemoveAt(i);
        }
      }
    }

    private void SetNumber() {
      for (int i = 0; i < _BaseDemandList.Count; i++) {
        _BaseDemandList[i].Number = i + 1;
      }
    }

    private void BaseDemandForm_KeyDown(object sender, KeyEventArgs e) {
      if (e.KeyValue == (char)Keys.Escape) {
        this.Close();
      } else if (e.KeyValue == (char)Keys.Enter) {
        Add();
      } else if (e.KeyValue == (char)Keys.F1) {
        HelpsForm  hf = new HelpsForm();
        hf.Show();
      }
    }

  }
}
