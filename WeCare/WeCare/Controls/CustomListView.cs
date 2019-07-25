using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace WeCare.Controls
{
    /// <summary>
    /// Controle customizado para chamar um command a partir de um ListView
    /// </summary>
    public class CustomListView : ListView
    {
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(CustomListView), null);        

        public ICommand Command
        {
            get { return (ICommand)this.GetValue(CommandProperty); }
            set { this.SetValue(CommandProperty, value); }
        }

        public CustomListView()
        {
            this.ItemTapped += OnItemTapped;            
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                Command?.Execute(e.Item);
                SelectedItem = null;
            }
        }
    }
}
