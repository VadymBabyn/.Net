using RealEstateOffice.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateOffice.BLL {
  class SearchBLL {
    private BaseOffersProvider _BaseOffersProvider = new BaseOffersProvider();
    private List<BaseOffers> _BaseOffersList = new List<BaseOffers>();
    private BaseDemandProvider _BaseDemandProvider = new BaseDemandProvider();
    private List<BaseDemand> _BaseDemandList = new List<BaseDemand>();

    public List<BaseOffers> GetBaseOffersByNumberRroomsAndPrice(int NumberRrooms, double Price) {
      List<BaseOffers> selectBaseOffers = new List<BaseOffers>();
      _BaseOffersList = _BaseOffersProvider.GetAllData();
      for (int i = 0; i < _BaseOffersList.Count; i++) {
        if (_BaseOffersList[i].NumberRrooms == NumberRrooms && _BaseOffersList[i].Price < Price) {
          selectBaseOffers.Add(_BaseOffersList[i]);
        }
      }
      return selectBaseOffers;
    }

    public List<BaseOffers> GetBaseOffersByMinMaxArea(int AreaMin, int AreaMax) {
      List<BaseOffers> selectBaseOffers = new List<BaseOffers>();
      _BaseOffersList = _BaseOffersProvider.GetAllData();
      for (int i = 0; i < _BaseOffersList.Count; i++) {
        if (_BaseOffersList[i].ApartmentArea > AreaMin && _BaseOffersList[i].ApartmentArea < AreaMax) {
          selectBaseOffers.Add(_BaseOffersList[i]);
        }
      }
      return selectBaseOffers;
    }

    public List<BaseOffers> GetBaseOffersByRegion(string Region) {
      List<BaseOffers> selectBaseOffers = new List<BaseOffers>();
      _BaseOffersList = _BaseOffersProvider.GetAllData();
      for (int i = 0; i < _BaseOffersList.Count; i++) {
        if (_BaseOffersList[i].Region.ToLower().Contains(Region.ToLower())) {
          selectBaseOffers.Add(_BaseOffersList[i]);
        }
      }
      return selectBaseOffers;
    }

    public List<BaseDemand> GetBaseDemandByPrice(double Price) {
      List<BaseDemand> selectBaseDemand = new List<BaseDemand>();
      _BaseDemandList = _BaseDemandProvider.GetAllData();
      for (int i = 0; i < _BaseDemandList.Count; i++) {
        if (_BaseDemandList[i].PriceMin < Price && _BaseDemandList[i].PriceMax > Price) {
          selectBaseDemand.Add(_BaseDemandList[i]);
        }
      }
      return selectBaseDemand;
    }

    public List<BaseDemand> GetBaseDemandByArea(int Area) {
      List<BaseDemand> selectBaseDemand = new List<BaseDemand>();
      _BaseDemandList = _BaseDemandProvider.GetAllData();
      for (int i = 0; i < _BaseDemandList.Count; i++) {
        if (_BaseDemandList[i].ApartmentAreaMin < Area && _BaseDemandList[i].ApartmentAreaMax > Area) {
          selectBaseDemand.Add(_BaseDemandList[i]);
        }
      }
      return selectBaseDemand;
    }

    public List<BaseDemand> GetBaseDemandByRegion(string Region) {
      List<BaseDemand> selectBaseDemand = new List<BaseDemand>();
      _BaseDemandList = _BaseDemandProvider.GetAllData();
      for (int i = 0; i < _BaseDemandList.Count; i++) {
        if (_BaseDemandList[i].Region.ToLower().Contains(Region.ToLower())) {
          selectBaseDemand.Add(_BaseDemandList[i]);
        }
      }
      return selectBaseDemand;
    }

  }
}
