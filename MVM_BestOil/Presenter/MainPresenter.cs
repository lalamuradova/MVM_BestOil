using MVM_BestOil.Data;
using MVM_BestOil.Model;
using MVM_BestOil.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVM_BestOil.Presenter
{
    class MainPresenter
    {
        private readonly GasolineContext _db;
        private IMainView _view;
        
        public MainPresenter( IMainView view)
        {
            
            _db = new GasolineContext();
            if (_db.Oils.ToList().Count == 0)
            {
                _db.Oils.Add(new Model.Oil() { Name = "A-92", Price = 1 });
                _db.Oils.Add(new Model.Oil() { Name = "A-95", Price = 1.45 });
                _db.Oils.Add(new Model.Oil() { Name = "A-98", Price = 1.85 });
                _db.SaveChanges();
            }
           
            
            _view = view;
            var list = _db.Oils.ToList();
            _view.Oils = list;

            _view.ComboboxChange += ViewComboboxChange;

            _view.QuantityChange += ViewQuantityChange;
            _view.MoneyChange += ViewMoneyChange;
            _view.CalculateChange += ViewCalculateChange;
            _view.ShowAllPaymentChange += ShowAllPayment;
        }

        public void ViewComboboxChange(Object sender, EventArgs e)
        {
            var oil = _view.SelectedOil;
            _view.Price = oil.Price.ToString();

        }
        public void ViewQuantityChange(Object sender, EventArgs e)
        {
            _view.LitrEnable = true;
            _view.MoneyEnable = false;
        }
        public void ViewMoneyChange(Object sender, EventArgs e)
        {
            _view.LitrEnable = false;
            _view.MoneyEnable = true;

        }

        public void ViewCalculateChange(Object sender,EventArgs e)
        {
            double total = 0;
            if (_view.MoneyEnable == true)
            {
                total = double.Parse(_view.MoneyText);
                _view.TotalText = total.ToString();
                Refuiler refuiler = new Refuiler
                {
                    Gasoline = _view.SelectedOil.Name,
                    Price = double.Parse(_view.Price),
                    Pay = double.Parse(_view.TotalText),
                    Money = double.Parse(_view.MoneyText),   
                    
                };
                _db.Refuilers.Add(refuiler);
            }
            else
            {
                total = double.Parse(_view.LitrText) * double.Parse(_view.Price);
                _view.TotalText = total.ToString();
                Refuiler refuiler = new Refuiler
                {
                    Gasoline = _view.SelectedOil.Name,
                    Price = double.Parse(_view.Price),
                    Pay = double.Parse(_view.TotalText),
                    Quantity = int.Parse(_view.LitrText)
                };
                _db.Refuilers.Add(refuiler);
            }
           
                   
            _db.SaveChanges();
        }


        public void ShowAllPayment(Object sender,EventArgs e)
        {
            var list = _db.Refuilers.ToList();
            _view.Refuilers = list;
           
        }
    }
}
