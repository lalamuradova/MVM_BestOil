using MVM_BestOil.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVM_BestOil.View
{
    public interface IMainView
    {
        List<Oil> Oils {set; }
        Oil SelectedOil { get; set; }
        string Price { get; set; }
        bool QuantityChecked { get; set; }
        string LitrText { get; set; }
        string MoneyText { get; set; }
        string TotalText { get; set; }
        List<Refuiler> Refuilers {set; }
        bool MoneyEnable { get; set; }
        bool LitrEnable { get; set; }
        EventHandler<EventArgs> ComboboxChange { get; set; }
        EventHandler<EventArgs> QuantityChange { get; set; }
        EventHandler<EventArgs> MoneyChange { get; set; }
        EventHandler<EventArgs> CalculateChange { get; set; }
        EventHandler<EventArgs> ShowAllPaymentChange { get; set; }
    }
}
