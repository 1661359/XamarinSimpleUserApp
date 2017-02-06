using PropertyChanged;
using UserApp.Services;

namespace UserApp.ViewModel
{
    [ImplementPropertyChanged]
    public class  MainPageViewModel : IViewModel
    {
        private readonly AppSessionConfig appSessionConfig;
        
        public MainPageViewModel(AppSessionConfig appSessionConfig)
        {
            this.appSessionConfig = appSessionConfig;
            UserName = this.appSessionConfig.UserName;
        }

        public string UserName
        {
            get;
            set;
        }
        
    }
}
