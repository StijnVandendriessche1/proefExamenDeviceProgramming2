using proefExamen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace proefExamen.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScorePage : ContentPage
    {
        Area area = new Area();
        public ScorePage()
        {
            InitializeComponent();
        }
        public ScorePage(Area a)
        {
            InitializeComponent();
            area = a;
            loadPageAsync();
        }

        private async Task loadPageAsync()
        {
            lvwScores.ItemsSource = await QualityManager.GetQualityScoresAsync(area.Id);
            lblName.Text = area.Name;
        }

        private void btnBackToDetails_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void btnBackToMain_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }

        private async void btnAdd_Clicked(object sender, EventArgs e)
        {
            QualityScore score = (sender as Button).BindingContext as QualityScore;
            score.ScoreOutOf10++;
            await QualityManager.UpdateQualityScoreAsync(score);
            loadPageAsync();
        }

        private async void btnSubstract_Clicked(object sender, EventArgs e)
        {
            QualityScore score = (sender as Button).BindingContext as QualityScore;
            score.ScoreOutOf10--;
            await QualityManager.UpdateQualityScoreAsync(score);
            loadPageAsync();
        }
    }
}