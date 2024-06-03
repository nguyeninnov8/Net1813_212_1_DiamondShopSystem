using DiamondShopSystem.Business;
using DiamondShopSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DiamondShopSystem.WpfApp.UI
{
    /// <summary>
    /// Interaction logic for WRequestDetai.xaml
    /// </summary>
    public partial class WRequestDetail : Window
    {
        private readonly RequestDetailsBusiness _business;

        public WRequestDetail()
        {
            InitializeComponent();
            this._business ??= new RequestDetailsBusiness();
            this.LoadGrdRequestDetail();
        }
        private async void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = await _business.GetById(RequestDetailId.Text);

                if (item.Data == null)
                {
                    var requestDetail = new RequestDetail()
                    {
                        Id = RequestDetailId.Text,
                        Name = RequestDetailName.Text,
                        Price = Price.Text,
                        Jewelry = Jelwery.Text,
                    };

                    var result = await _business.Save(requestDetail);
                    MessageBox.Show(result.Message, "Save");
                }
                else
                {
                    var requestDetail = item.Data as RequestDetail;
                    requestDetail.Id = RequestDetailId.Text;
                    requestDetail.Name = RequestDetailName.Text;
                    requestDetail.Price = Price.Text;
                    requestDetail.Jewelry = Jelwery.Text;

                    var result = await _business.Update(requestDetail);
                    MessageBox.Show(result.Message, "Update");
                }
                RequestDetailId.Text = string.Empty;
                RequestDetailName.Text = string.Empty;
                Price.Text = string.Empty;
                Jelwery.Text = string.Empty;
                this.LoadGrdRequestDetail();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }
        private async void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {

        }
        private async void grdCustomer_ButtonDelete_Click(object sender, RoutedEventArgs e)
        {

        }
        private async void grdRequestDetail_ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            string requestDetailId = btn.CommandParameter.ToString();

            //MessageBox.Show(currencyCode);

            if (!string.IsNullOrEmpty(requestDetailId))
            {
                var requestDetailResult = await _business.GetById(requestDetailId);

                if (requestDetailResult.Status > 0 && requestDetailResult.Data != null)
                {
                    var item = requestDetailResult.Data as RequestDetail;
                    RequestDetailId.Text = item.Id;
                    RequestDetailName.Text = item.Name;
                    Price.Text = item.Price;
                    Jelwery.Text = item.Jewelry;
                }
            }
        }

        private async void LoadGrdRequestDetail()
        {
            var result = await _business.GetAll();

            if (result.Status > 0 && result.Data != null)
            {
                grdRequestDetail.ItemsSource = result.Data as List<RequestDetail>;
            }
            else
            {
                grdRequestDetail.ItemsSource = new List<RequestDetail>();
            }
        }
    }
}

