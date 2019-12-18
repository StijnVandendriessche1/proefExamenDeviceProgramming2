using proefExamen.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace proefExamen
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //testModelsAsync();
            loadPageAsync();
        }

        private async Task loadPageAsync()
        {
            lvwAreas.ItemsSource = await QualityManager.GetAreasAsync();
        }

        private async Task testModelsAsync()
        {
            List<Area> areas = await QualityManager.GetAreasAsync();
            foreach(Area area in areas)
            {
                Debug.WriteLine($"naam: {area.Name}");
            }
            AreaData areaData = await QualityManager.GetAreaDataAsync("744daf84-8b6d-4d50-9231-0f4a601f06af");
            Debug.WriteLine($"Naam: {areaData.Name}, Land: {areaData.FullName}, Burgemeester: {areaData.Mayor}");
            List<QualityScore> qualityScore = await QualityManager.GetQualityScoresAsync("744daf84-8b6d-4d50-9231-0f4a601f06af");
            foreach(QualityScore qs in qualityScore)
            {
                Debug.WriteLine($"label: {qs.Topic}, score: {qs.ScoreOutOf10.ToString()}");
                qs.ScoreOutOf10 = 7;
                QualityManager.UpdateQualityScoreAsync(qs);
            }
        }

        private void lvwAreas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Area a = lvwAreas.SelectedItem as Area;
            Navigation.PushAsync(new DetailPage(a));
        }
    }
}
