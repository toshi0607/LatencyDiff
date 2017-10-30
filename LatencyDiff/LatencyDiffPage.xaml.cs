using Xamarin.Forms;
using LatencyDiff.Model;
using LatencyDiff.ViewModel;

namespace LatencyDiff
{
    public partial class LatencyDiffPage : ContentPage
    {
        LatencyDiffViewModel vm;

        public LatencyDiffPage()
        {
            InitializeComponent();

            vm = new LatencyDiffViewModel();
            BindingContext = vm;
        }
    }
}
