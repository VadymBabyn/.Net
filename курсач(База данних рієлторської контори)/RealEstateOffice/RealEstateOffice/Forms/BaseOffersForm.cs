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
  public partial class BaseOffersForm : Form {
    public static BaseOffers _selectedBaseOffers = new BaseOffers();
    private int _selectedRowIndex = 0;
    private Validation _validation = new Validation();
    private BaseOffersProvider _BaseOffersProvider = new BaseOffersProvider();
    public static List<BaseOffers> _BaseOffersList = new List<BaseOffers>();

    public BaseOffersForm() {
      InitializeComponent();
      DataLoad();
    }

    private void AddBtn_Click(object sender, EventArgs e) {
      Add();
    }

    private void Add() {
      if (IsDataEnteringCorrect()) {
        BaseOffers BaseOffers = new BaseOffers(RegionTBox.Text, AddressTBox.Text, Convert.ToInt32(HouseNumberTBox.Text), Convert.ToInt32(ApartmentNumberTBox.Text),
          Convert.ToInt32(NumberRroomsTBox.Text), ApplicantCoordinatesTBox.Text, Convert.ToInt32(ApartmentAreaTBox.Text), Convert.ToDouble(PriceTBox.Text));
        _BaseOffersList.Add(BaseOffers);
        _BaseOffersProvider.SaveBaseOffers(_BaseOffersList);
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

    private void BaseOffersGridView_CellClick(object sender, DataGridViewCellEventArgs e) {
      if (e.RowIndex >= 0) {
        _selectedRowIndex = e.RowIndex;
        _selectedBaseOffers = SelectBaseOffers(Convert.ToInt32(BaseOffersGridView[0, e.RowIndex].Value.ToString()), _BaseOffersList);
        UpdateBaseOffersForm updateBaseOffersForm = new UpdateBaseOffersForm();
        updateBaseOffersForm.ShowDialog();
        if (_selectedBaseOffers.IsDelete) {
          DeleteBaseOffersInfo(_selectedBaseOffers.Number);
        } else {
          SetDataInBaseOffersList();
        }
        _BaseOffersProvider.SaveBaseOffers(_BaseOffersList);
        DataLoad();
      }
    }

    private void DataLoad() {
      int firstRowIndex = 0;
      if (BaseOffersGridView.FirstDisplayedScrollingRowIndex > 0) {
        firstRowIndex = BaseOffersGridView.FirstDisplayedScrollingRowIndex;
      }
      try {
        _BaseOffersList.Clear();
        _BaseOffersList = _BaseOffersProvider.GetAllData();
        SetNumber();
        LoadDataInBaseOffersGridView(_BaseOffersList);
        if (_selectedRowIndex == BaseOffersGridView.Rows.Count) {
          _selectedRowIndex = BaseOffersGridView.Rows.Count - 1;
        }
        if (_selectedRowIndex >= 0) {
          BaseOffersGridView.FirstDisplayedScrollingRowIndex = firstRowIndex;
          BaseOffersGridView.Rows[_selectedRowIndex].Selected = true;
        }
      } catch (Exception ex) {
        MessageBox.Show(ex.ToString());
      }
    }

    private void LoadDataInBaseOffersGridView(List<BaseOffers> BaseOffersList) {
      BaseOffersGridView.DataSource = null;
      BaseOffersGridView.Columns.Clear();
      BaseOffersGridView.AutoGenerateColumns = false;
      BaseOffersGridView.RowHeadersVisible = false;

      BaseOffersGridView.DataSource = BaseOffersList;

      DataGridViewColumn numberColumn = new DataGridViewTextBoxColumn();
      numberColumn.HeaderText = "№";
      numberColumn.DataPropertyName = "Number";
      numberColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
      numberColumn.Width = 60;
      BaseOffersGridView.Columns.Add(numberColumn);

      DataGridViewColumn RegionColumn = new DataGridViewTextBoxColumn();
      RegionColumn.HeaderText = "Район";
      RegionColumn.DataPropertyName = "Region";
      RegionColumn.Width = 150;
      BaseOffersGridView.Columns.Add(RegionColumn);

      DataGridViewColumn HouseNumberColumn = new DataGridViewTextBoxColumn();
      HouseNumberColumn.HeaderText = "Номер будинку";
      HouseNumberColumn.DataPropertyName = "HouseNumber";
      HouseNumberColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
      HouseNumberColumn.Width = 100;
      BaseOffersGridView.Columns.Add(HouseNumberColumn);

      DataGridViewColumn ApartmentNumberColumn = new DataGridViewTextBoxColumn();
      ApartmentNumberColumn.HeaderText = "Квартира";
      ApartmentNumberColumn.DataPropertyName = "ApartmentNumber";
      ApartmentNumberColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
      ApartmentNumberColumn.Width = 50;
      BaseOffersGridView.Columns.Add(ApartmentNumberColumn);

      DataGridViewColumn ApartmentAreaColumn = new DataGridViewTextBoxColumn();
      ApartmentAreaColumn.HeaderText = "Площа";
      ApartmentAreaColumn.DataPropertyName = "ApartmentArea";
      ApartmentAreaColumn.Width = 50;
      ApartmentAreaColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
      BaseOffersGridView.Columns.Add(ApartmentAreaColumn);

      DataGridViewColumn NumberRroomsColumn = new DataGridViewTextBoxColumn();
      NumberRroomsColumn.HeaderText = "Кімнати";
      NumberRroomsColumn.DataPropertyName = "NumberRrooms";
      NumberRroomsColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
      NumberRroomsColumn.Width = 50;
      BaseOffersGridView.Columns.Add(NumberRroomsColumn);

      DataGridViewColumn PriceColumn = new DataGridViewTextBoxColumn();
      PriceColumn.HeaderText = "Вартість";
      PriceColumn.DataPropertyName = "Price";
      PriceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
      PriceColumn.Width = 120;
      BaseOffersGridView.Columns.Add(PriceColumn);

      DataGridViewColumn AddressColumn = new DataGridViewTextBoxColumn();
      AddressColumn.HeaderText = "Адреса";
      AddressColumn.DataPropertyName = "Address";
      AddressColumn.Width = 250;
      BaseOffersGridView.Columns.Add(AddressColumn);

      DataGridViewColumn ApplicantCoordinatesColumn = new DataGridViewTextBoxColumn();
      ApplicantCoordinatesColumn.HeaderText = "Координати заявника";
      ApplicantCoordinatesColumn.DataPropertyName = "ApplicantCoordinates";
      ApplicantCoordinatesColumn.Width = 250;
      BaseOffersGridView.Columns.Add(ApplicantCoordinatesColumn);

      for (int i = 0; i < BaseOffersGridView.Columns.Count; i++) {
        BaseOffersGridView.Columns[i].HeaderCell.Style.BackColor = Color.LightGray;
      }

    }

    private void ClearAllControls() {
      RegionTBox.Text = String.Empty;
      HouseNumberTBox.Text = "0";
      ApartmentNumberTBox.Text = "0";
      ApartmentAreaTBox.Text = "0";
      NumberRroomsTBox.Text = "0";
      PriceTBox.Text = "0";
      AddressTBox.Text = String.Empty;
      ApplicantCoordinatesTBox.Text = String.Empty;
    }

    private bool IsDataEnteringCorrect() {
      bool isCorrect = true;
      if (_validation.IsDataEntering(RegionTBox.Text)) {
        RegionValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        RegionValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (_validation.IsDataConvertToInt(HouseNumberTBox.Text)) {
        HouseNumberValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        HouseNumberValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (_validation.IsDataConvertToInt(ApartmentNumberTBox.Text)) {
        ApartmentNumberValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        ApartmentNumberValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (_validation.IsDataConvertToInt(ApartmentAreaTBox.Text)) {
        ApartmentAreaValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        ApartmentAreaValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (_validation.IsDataConvertToInt(NumberRroomsTBox.Text)) {
        NumberRroomsValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        NumberRroomsValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (_validation.IsDataEntering(AddressTBox.Text)) {
        AddressValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        AddressValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (_validation.IsDataEntering(ApplicantCoordinatesTBox.Text)) {
        ApplicantCoordinatesValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        ApplicantCoordinatesValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (_validation.IsDataConvertToDouble(PriceTBox.Text)) {
        PriceValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        PriceValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      return isCorrect;
    }

    private void SetDataInBaseOffersList() {
      for (int i = 0; i < _BaseOffersList.Count; i++) {
        if (_selectedBaseOffers.Number == _BaseOffersList[i].Number) {
          _BaseOffersList[i].Region = _selectedBaseOffers.Region;
          _BaseOffersList[i].Address = _selectedBaseOffers.Address;
          _BaseOffersList[i].HouseNumber = _selectedBaseOffers.HouseNumber;
          _BaseOffersList[i].ApartmentNumber = _selectedBaseOffers.ApartmentNumber;
          _BaseOffersList[i].ApartmentArea = _selectedBaseOffers.ApartmentArea;
          _BaseOffersList[i].NumberRrooms = _selectedBaseOffers.NumberRrooms;
          _BaseOffersList[i].ApplicantCoordinates = _selectedBaseOffers.ApplicantCoordinates;
          _BaseOffersList[i].Price = _selectedBaseOffers.Price;
        }
      }
    }

    private BaseOffers SelectBaseOffers(int Number, List<BaseOffers> BaseOffersList) {
      for (int i = 0; i < BaseOffersList.Count; i++) {
        if (Number == BaseOffersList[i].Number) {
          return BaseOffersList[i];
        }
      }
      return (new BaseOffers());
    }

    private void DeleteBaseOffersInfo(int Number) {
      for (int i = 0; i < _BaseOffersList.Count; i++) {
        if (Number == _BaseOffersList[i].Number) {
          _BaseOffersList.RemoveAt(i);
        }
      }
    }

    private void SetNumber() {
      for (int i = 0; i < _BaseOffersList.Count; i++) {
        _BaseOffersList[i].Number = i + 1;
      }
    }

    private void BaseOffersForm_KeyDown(object sender, KeyEventArgs e) {
      if (e.KeyValue == (char)Keys.Escape) {
        this.Close();
      } else if (e.KeyValue == (char)Keys.Enter) {
        Add();
      } else if (e.KeyValue == (char)Keys.F1) {
        HelpsForm hf = new HelpsForm();
        hf.Show();
      }
    }

  }
}
