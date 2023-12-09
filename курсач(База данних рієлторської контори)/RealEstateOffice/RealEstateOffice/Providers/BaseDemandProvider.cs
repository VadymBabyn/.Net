using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateOffice.Providers {
  class BaseDemandProvider {
    private BinaryFormatter formatter = new BinaryFormatter();

    public void SaveBaseDemand(List<BaseDemand> listBaseDemand) {
      // створюємо обєкт BinaryFormatter
      // получаємо потік, куди будемо записувати серіалізований обєкт
      using (FileStream fs = new FileStream("BaseDemand.dat", FileMode.OpenOrCreate)) {
        formatter.Serialize(fs, listBaseDemand);

        Console.WriteLine("Об'єкт серіализований");
      }
    }
    public List<BaseDemand> GetAllData() {
      // десериалiзацiя
      List<BaseDemand> allBaseDemandList = new List<BaseDemand>();
      using (FileStream fs = new FileStream("BaseDemand.dat", FileMode.Open)) {
        List<BaseDemand> deserilizeBaseDemand = (List<BaseDemand>)formatter.Deserialize(fs);
        foreach (BaseDemand BaseDemand in deserilizeBaseDemand) {
          allBaseDemandList.Add(BaseDemand);
        }
      }
      allBaseDemandList.Sort(new BaseDemandListComparer("Region"));
      return allBaseDemandList;
    }

    public class BaseDemandListComparer : IComparer<BaseDemand> {
      private string _sortColumn;
      private bool _reverse;

      public int Compare(BaseDemand a, BaseDemand b) {
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

      public BaseDemandListComparer(string sortColumn) {
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
public class BaseDemand {
  private int _Number;
  private string _Region; //район
  private int _ApartmentAreaMin; //Площа квартири min
  private int _ApartmentAreaMax; //Площа квартири max
  private int _NumberRrooms; //Кількість кімнат 
  private string _ClientCoordinates; // координати  покупця
  private double _PriceMin; //вартість min
  private double _PriceMax; //вартість max
  private bool _IsDelete;

  public BaseDemand() {
    _Number = 0;
    _Region = String.Empty;
    _ApartmentAreaMin = 0;
    _NumberRrooms = 0;
    _ClientCoordinates = String.Empty;
    _ApartmentAreaMax = 0;
    _PriceMin = 0.0;
    _PriceMax = 0.0;
    _IsDelete = false;
  }

  public BaseDemand(string Region, int ApartmentAreaMin, int ApartmentAreaMax, int NumberRrooms, string ClientCoordinates, double PriceMin, double PriceMax) {
    _Region = Region;
    _ApartmentAreaMin = ApartmentAreaMin;
    _NumberRrooms = NumberRrooms;
    _ClientCoordinates = ClientCoordinates;
    _ApartmentAreaMax = ApartmentAreaMax;
    _PriceMin = PriceMin;
    _PriceMax = PriceMax;
  }

  public int Number {
    set { _Number = value; }
    get { return _Number; }
  }
  public string Region {
    set { _Region = value; }
    get { return _Region; }
  }
  public int ApartmentAreaMin {
    set { _ApartmentAreaMin = value; }
    get { return _ApartmentAreaMin; }
  }
  public int ApartmentAreaMax {
    set { _ApartmentAreaMax = value; }
    get { return _ApartmentAreaMax; }
  }
  public int NumberRrooms {
    set { _NumberRrooms = value; }
    get { return _NumberRrooms; }
  }
  public string ClientCoordinates {
    set { _ClientCoordinates = value; }
    get { return _ClientCoordinates; }
  }
  public double PriceMin {
    set { _PriceMin = value; }
    get { return _PriceMin; }
  }
  public double PriceMax {
    set { _PriceMax = value; }
    get { return _PriceMax; }
  }
  public bool IsDelete {
    set { _IsDelete = value; }
    get { return _IsDelete; }
  }

}