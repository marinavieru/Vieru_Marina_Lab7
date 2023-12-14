namespace Vieru_Marina_Lab7;
using Vieru_Marina_Lab7.Models;

public partial class ListPage : ContentPage
{
    public ListPage()
    {
        InitializeComponent();
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (ShopList)BindingContext;
        slist.Date = DateTime.UtcNow;
        Shop selectedShop = (ShopPicker.SelectedItem as Shop);
        slist.ShopID = selectedShop.ID;
        await App.Database.SaveShopListAsync(slist);
        await Navigation.PopAsync();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (ShopList)BindingContext;
        await App.Database.DeleteShopListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked1(object sender, EventArgs e)
    {
        var slist = (ShopList)BindingContext;

        if (listView.SelectedItem != null && listView.SelectedItem is Product selectedProduct)
        {
            var confirmation = await DisplayAlert("Sterge produsul", $"Doriti sa stergeti {selectedProduct.Description}?", "Da", "Nu");

            if (confirmation)
            {

                await App.Database.DeleteProductAsync(selectedProduct);
                listView.ItemsSource = await App.Database.GetListProductsAsync(slist.ID);
            }
        }
        else
        {
            await DisplayAlert("Niciun produs selectat", "Selectati un produs.", "OK");
        }
    }

    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProductPage((ShopList)this.BindingContext)
        {
            BindingContext = new Product()
        });
    }


    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var items = await App.Database.GetShopsAsync();
        ShopPicker.ItemsSource = (System.Collections.IList)items;
        ShopPicker.ItemDisplayBinding = new Binding("ShopDetails");

        var shopl = (ShopList)BindingContext;
        listView.ItemsSource = await App.Database.GetListProductsAsync(shopl.ID);
    }
}