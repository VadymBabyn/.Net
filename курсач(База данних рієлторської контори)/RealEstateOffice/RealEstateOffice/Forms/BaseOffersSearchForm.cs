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
  public partial class BaseOffersSearchForm : Form {
    private Validation _validation = new Validation();
    private BaseOffersProvider _BaseOffersProvider = new BaseOffersProvider();
    private List<BaseOffers> _BaseOffersList = new List<BaseOffers>();
    private SearchBLL _SearchBLL = new SearchBLL();

    public BaseOffersSearchForm() {
      InitializeComponent();
    }

    private void SearchBtn_Click(object sender, EventArgs e) {
      if (IsDataEnteringCorrect()) {
        _BaseOffersList = _SearchBLL.GetBaseOffersByNumberRroomsAndPrice(Convert.ToInt32(NumberRroomsTBox.Text), Convert.ToDouble(PriceTBox.Text));
        SetNumber();
        LoadDataInBaseOffersGridView(_BaseOffersList);
      }
      }

    private void AreaSearchBtn_Click(object sender, EventArgs e) {
      if (IsDataAreaCorrect()) {
        _BaseOffersList = _SearchBLL.GetBaseOffersByMinMaxArea(Convert.ToInt32(AreaMinTBox.Text), Convert.ToInt32(AreaMaxTBox.Text));
        SetNumber();
        LoadDataInBaseOffersGridView(_BaseOffersList);
      }
    }

    private void RegionSearchBtn_Click(object sender, EventArgs e) {
      if (IsDataRegionorrect()) {
        _BaseOffersList = _SearchBLL.GetBaseOffersByRegion(RegionTBox.Text);
        SetNumber();
        LoadDataInBaseOffersGridView(_BaseOffersList);
      }
    }

    private void SetNumber() {
      for (int i = 0; i < _BaseOffersList.Count; i++) {
        _BaseOffersList[i].Number = i + 1;
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


    private bool IsDataEnteringCorrect() {
      bool isCorrect = true;
      if (_validation.IsDataConvertToInt(NumberRroomsTBox.Text)) {
        NumberRroomsValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        NumberRroomsValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
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

    private bool IsDataAreaCorrect() {
      bool isCorrect = true;
      if (_validation.IsDataConvertToInt(AreaMinTBox.Text)) {
        AreaMinValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        AreaMinValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (_validation.IsDataConvertToInt(AreaMaxTBox.Text)) {
        AreaMaxValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        AreaMaxValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
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

    private void BaseOffersSearchForm_KeyDown(object sender, KeyEventArgs e) {
      if (e.KeyValue == (char)Keys.Escape) {
        this.Close();
      } else if (e.KeyValue == (char)Keys.F1) {
        HelpsForm hf = new HelpsForm();
        hf.Show();
      }
    }
  }
}
