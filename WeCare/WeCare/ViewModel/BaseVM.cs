using GalaSoft.MvvmLight;
using System.Threading.Tasks;

namespace WeCare.ViewModel
{
    public class BaseVM : ViewModelBase
    {
        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }
    }
}
