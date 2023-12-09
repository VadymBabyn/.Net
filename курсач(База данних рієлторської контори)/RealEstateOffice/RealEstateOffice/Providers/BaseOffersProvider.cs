using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateOffice.Providers {
  class BaseOffersProvider {
    private BinaryFormatter formatter = new BinaryFormatter();

    public void SaveBaseOffers(List<BaseOffers> listBaseOffers) {
      // створюємо обєкт BinaryFormatter
      // получаємо потік, куди будемо записувати серіалізований обєкт
      using (FileStream fs = new FileStream("BaseOffers.dat", FileMode.OpenOrCreate)) {
        formatter.Serialize(fs, listBaseOffers);

        Console.WriteLine("Об'єкт серіализований");
      }
    }
    public List<BaseOffers> GetAllData() {
      // десериалiзацiя
      List<BaseOffers> allBaseOffersList = new List<BaseOffers>();
      using (FileStream fs = new FileStream("BaseOffers.dat", FileMode.Open)) {
        List<BaseOffers> deserilizeBaseOffers = (List<BaseOffers>)formatter.Deserialize(fs);
        foreach (BaseOffers BaseOffers in deserilizeBaseOffers) {
          allBaseOffersList.Add(BaseOffers);
        }
      }
      allBaseOffersList.Sort(new BaseOffersListComparer("Region"));
      return allBaseOffersList;
    }

    public class BaseOffersListComparer : IComparer<BaseOffers> {
      private string _sortColumn;
      private bool _reverse;

      public int Compare(BaseOffers a, BaseOffers b) {
        int retVal = 0;
        switch (_sortColumn) {
          case "Region":
            retVal = a.Region.CompareTo(b.Region);
            break;
          case "Name":
            retVal = a.NumberRrooms.CompareTo(b.NumberRrooms);
            break;
        }
        int _reverseInt = 1;
        if ((_reverse)) {
          _reverseInt = -1;
        }
        return (retVal * _reverseInt);
      }

      public BaseOffersListComparer(string sortColumn) {
        if (sortColumn.Length == 0) {
          sortColumn = "Name asc";
        }
        _reverse = sortColumn.ToLowerInvariant().EndsWith(" asc");

        if (_reverse) {
          _sortColumn = sortColumn.Substring(0, sortColumn.Length - 5);
        } else {
          _sortColumn = sortColumn;
        }
      }
    }

  }
}



[Serializable]
public class BaseOffers {
  private int _Number;
  private string _Region; //район
  private string _Address; //адреса 
  private int _HouseNumber; //Номер будинку 
  private int _ApartmentNumber; //Номер квартири 
  private int _ApartmentArea; //Площа квартири 
  private int _NumberRrooms; //Кількість кімнат 
  private string _ApplicantCoordinates; // координати заявника 
  private double _Price; //вартість
  private bool _IsDelete;

  public BaseOffers() {
    _Number = 0;
    _Region = String.Empty;
    _Address = String.Empty;
    _HouseNumber = 0;
    _ApartmentNumber = 0;
    _NumberRrooms = 0;
    _ApplicantCoordinates = String.Empty;
    _ApartmentArea = 0;
    _Price = 0.0;
    _IsDelete = false;
  }

  public BaseOffers(string Region, string Address, int HouseNumber, int ApartmentNumber, int NumberRrooms, string ApplicantCoordinates, int ApartmentArea, double Price) {
    _Region = Region;
    _Address = Address;
    _HouseNumber = HouseNumber;
    _ApartmentNumber = ApartmentNumber;
    _NumberRrooms = NumberRrooms;
    _ApplicantCoordinates = ApplicantCoordinates;
    _ApartmentArea = ApartmentArea;
    _Price = Price;
  }

  public int Number {
    set { _Number = value; }
    get { return _Number; }
  }
  public string Region {
    set { _Region = value; }
    get { return _Region; }
  }
  public string Address {
    set { _Address = value; }
    get { return _Address; }
  }
  public int HouseNumber {
    set { _HouseNumber = value; }
    get { return _HouseNumber; }
  }
  public int ApartmentNumber {
    set { _ApartmentNumber = value; }
    get { return _ApartmentNumber; }
  }
  public int ApartmentArea {
    set { _ApartmentArea = value; }
    get { return _ApartmentArea; }
  }
  public int NumberRrooms {
    set { _NumberRrooms = value; }
    get { return _NumberRrooms; }
  }
  public string ApplicantCoordinates {
    set { _ApplicantCoordinates = value; }
    get { return _ApplicantCoordinates; }
  }
  public double Price {
    set { _Price = value; }
    get { return _Price; }
  }
  public bool IsDelete {
    set { _IsDelete = value; }
    get { return _IsDelete; }
  }

 }