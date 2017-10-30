using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using LatencyDiff.Model;
using LatencyDiff.Service;
using Xamarin.Forms;
using System.Diagnostics;

namespace LatencyDiff.ViewModel
{
    public class LatencyDiffViewModel : BindableBase
    {
        public ObservableCollection<Tag> Tags { get; set; } = new ObservableCollection<Tag>();
        public Command GetTagsCommand { get; set; }

        LatencyDifference _latencyDiff;
        public LatencyDifference LatencyDiff
        {
            get { return _latencyDiff; }
            set {
                SetProperty(ref _latencyDiff, value);
                OnPropertyChanged();
            }
        }

        long _diff;
        public long Diff
        {
            get { return _diff; }
            set
            {
                SetProperty(ref _diff, value);
                OnPropertyChanged();
            }
        }

        bool _busy;
        public bool IsBusy
        {
            get { return _busy; }
            set
            {
                SetProperty(ref _busy, value);
                OnPropertyChanged();
                //Update the can execute
                GetTagsCommand.ChangeCanExecute();
            }
        }

        public LatencyDiffViewModel()
        {
            Tags = new ObservableCollection<Tag>();
            GetTagsCommand = new Command(
                async () => GetTagsAsync(),
                () => !IsBusy);
        }

        public async void GetTagsAsync()
        {
            var sw = new Stopwatch();
 
            sw.Start();
            var res = await FunctionsService.GetTagsAsync("toshi0607");
            sw.Stop();
            var functionsTime = sw.ElapsedMilliseconds; 

            sw.Restart();

            sw.Start();
            var res2 = await ApiService.GetTagsAsync("toshi0607");
            sw.Stop();
            var Apitime = sw.ElapsedMilliseconds;

            LatencyDiff = new LatencyDifference(functionsTime, Apitime);

            foreach(var tag in res2)
            {
                var t = JsonConvert.DeserializeObject<Tag>(tag.ToString());
                Tags.Add(t);
            }
        }
    }
}
