using RealEstateOffice.AppCode;
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
  public partial class UpdateBaseOffersForm : Form {
    private Validation _validation = new Validation();
    BaseOffers _BaseOffers = new BaseOffers();

    public UpdateBaseOffersForm() {
      InitializeComponent();
      LoadAllDate();
    }

    private void SaveBtn_Click(object sender, EventArgs e) {
      Save();
    }
    private void Save() {
      if (IsDataEnteringCorrect()) {
        SaveData();
        this.Close();
      }
    }

    private void DeleteBtn_Click(object sender, EventArgs e) {
      if (MessageBox.Show("Ви дійсно бажаєте видалити цей елемент?", "Видалити", MessageBoxButtons.YesNo) == DialogResult.Yes) {
        BaseOffersForm._selectedBaseOffers.IsDelete = true; ;
        this.Close();
      }
    }

    private void ExitBtn_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void LoadAllDate() {
      RegionTBox.Text = BaseOffersForm._selectedBaseOffers.Region;
      HouseNumberTBox.Text = BaseOffersForm._selectedBaseOffers.HouseNumber.ToString();
      ApartmentNumberTBox.Text = BaseOffersForm._selectedBaseOffers.ApartmentNumber.ToString();
      ApartmentAreaTBox.Text = BaseOffersForm._selectedBaseOffers.ApartmentArea.ToString();
      NumberRroomsTBox.Text = BaseOffersForm._selectedBaseOffers.NumberRrooms.ToString();
      PriceTBox.Text = BaseOffersForm._selectedBaseOffers.Price.ToString();
      AddressTBox.Text = BaseOffersForm._selectedBaseOffers.Address;
      ApplicantCoordinatesTBox.Text = BaseOffersForm._selectedBaseOffers.ApplicantCoordinates;
    }

    private void SaveData() {
      BaseOffersForm._selectedBaseOffers.Region = RegionTBox.Text;
      BaseOffersForm._selectedBaseOffers.HouseNumber = Convert.ToInt32(HouseNumberTBox.Text);
      BaseOffersForm._selectedBaseOffers.ApartmentNumber = Convert.ToInt32(ApartmentNumberTBox.Text);
      BaseOffersForm._selectedBaseOffers.ApartmentArea = Convert.ToInt32(ApartmentAreaTBox.Text);
      BaseOffersForm._selectedBaseOffers.NumberRrooms = Convert.ToInt32(NumberRroomsTBox.Text);
      BaseOffersForm._selectedBaseOffers.Price = Convert.ToDouble(PriceTBox.Text);
      BaseOffersForm._selectedBaseOffers.Address = AddressTBox.Text;
      BaseOffersForm._selectedBaseOffers.ApplicantCoordinates = ApplicantCoordinatesTBox.Text;
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

    private void UpdateBaseOffersForm_KeyDown(object sender, KeyEventArgs e) {
      if (e.KeyValue == (char)Keys.Escape) {
        this.Close();
      } else if (e.KeyValue == (char)Keys.Enter) {
        Save();
      } else if (e.KeyValue == (char)Keys.F1) {
        HelpsForm hf = new HelpsForm();
        hf.Show();
      }
    }
  }
}
