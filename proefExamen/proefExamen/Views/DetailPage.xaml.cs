using proefExamen.Models;
using proefExamen.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace proefExamen
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public Area area { get; set; }
        public AreaData areaData { get; set; }
        public DetailPage(Area a)
        {
            InitializeComponent();
            area = a;
            loadPageAsync();
        }

        private async Task loadPageAsync()
        {
            try
            {
                areaData = await QualityManager.GetAreaDataAsync(area.Id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            imgArea.Source = ImageSource.FromStream(() => new HttpClient().GetStreamAsync(areaData.imgMobile).Result);
            lblName.Text = areaData.Name;
            lblMayor.Text = areaData.Mayor;
            lblFullName.Text = areaData.FullName;
            lblContinent.Text = areaData.Continent;
        }

        private void btnBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void btnQualityScores_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new ScorePage(area));
        }
    }
}