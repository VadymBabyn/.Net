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
  public partial class UpdateBaseDemandForm : Form {
    private Validation _validation = new Validation();
    BaseDemand _BaseDemand = new BaseDemand();

    public UpdateBaseDemandForm() {
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
        BaseDemandForm._selectedBaseDemand.IsDelete = true; ;
        this.Close();
      }
    }

    private void ExitBtn_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void LoadAllDate() {
      RegionTBox.Text = BaseDemandForm._selectedBaseDemand.Region;
      ApartmentAreaMinTBox.Text = BaseDemandForm._selectedBaseDemand.ApartmentAreaMin.ToString();
      ApartmentAreaMaxTBox.Text = BaseDemandForm._selectedBaseDemand.ApartmentAreaMax.ToString();
      NumberRroomsTBox.Text = BaseDemandForm._selectedBaseDemand.NumberRrooms.ToString();
      PriceMinTBox.Text = BaseDemandForm._selectedBaseDemand.PriceMin.ToString();
      PriceMaxTBox.Text = BaseDemandForm._selectedBaseDemand.PriceMax.ToString();
      ClientCoordinatesTBox.Text = BaseDemandForm._selectedBaseDemand.ClientCoordinates;
    }

    private void SaveData() {
      BaseDemandForm._selectedBaseDemand.Region = RegionTBox.Text;
      BaseDemandForm._selectedBaseDemand.ApartmentAreaMin = Convert.ToInt32(ApartmentAreaMinTBox.Text);
      BaseDemandForm._selectedBaseDemand.ApartmentAreaMax = Convert.ToInt32(ApartmentAreaMaxTBox.Text);
      BaseDemandForm._selectedBaseDemand.NumberRrooms = Convert.ToInt32(NumberRroomsTBox.Text);
      BaseDemandForm._selectedBaseDemand.PriceMin = Convert.ToDouble(PriceMinTBox.Text);
      BaseDemandForm._selectedBaseDemand.PriceMax = Convert.ToDouble(PriceMaxTBox.Text);
      BaseDemandForm._selectedBaseDemand.ClientCoordinates = ClientCoordinatesTBox.Text;
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

    private void UpdateBaseDemandForm_KeyDown(object sender, KeyEventArgs e) {
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
