using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnlineCookery
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageCakeInformation : ContentPage
    {
        int Id;
        int PriceForOne;
        int QuanityInStock;
        int SelectedQuanity;
        int TotalAmount;

        public PageCakeInformation(int idcake, string name, string category, int cost, string unit, double fats, double protein, double carbohydrates, string vitamins, string caterer, int quantity, string recipe)
        {
            InitializeComponent();

            Name.Text = $"Название: {name}";
            Category.Text = $"Категория: {category}";
            Cost.Text = $"Стоимость: {cost}";
            Unit.Text = $"Единица измерения: {unit}";
            Fats.Text = $"Жиры: {fats}";
            Protein.Text = $"Белки: {protein}";
            Carbohydrates.Text = $"Углеводы: {carbohydrates}";
            Vitamins.Text = $"Витамины: {vitamins}";
            Caterer.Text = $"Поставщик: {caterer}";
            Quantity.Text = $"Количество в наличии: {quantity}";
            Recipe.Text = $"Рецепт: {recipe}";

            Id = idcake;
            PriceForOne = cost;
            QuanityInStock = quantity;
        }

        static string CheckCasher(int SelectedQuanity, int QuanityInStock)
        {
            string message = "";

            if (SelectedQuanity > 10)
            {
                message = "Количество не может превышать 10 кг.";
            }
            else
            {
                if (SelectedQuanity < 1)
                {
                    message = "Количество не может быть меньше 1 кг.";
                }
                else
                {
                    if (SelectedQuanity > QuanityInStock)
                    {
                        message = "Количество не превышает тортов в наличии.";
                    }
                }
            }

            return message;
        }

        private void ButtonClickedCaclulate(object sender, EventArgs e)
        {
            string message = "";
            SelectedQuanity = Convert.ToInt32(EntryQuanity.Text);

            message = CheckCasher(SelectedQuanity, QuanityInStock);

            if (message != "")
            {
                DisplayAlert("Внимание", message, "Ок");
            }
            else
            {
                TotalAmount = Convert.ToInt32(EntryQuanity.Text) * Convert.ToInt32(PriceForOne);
                LabelAmount.Text = Convert.ToString(TotalAmount);
            }
        }

        private void ButtonClickedBuy(object sender, EventArgs e)
        {
            string message = "";
            SelectedQuanity = Convert.ToInt32(EntryQuanity.Text);

            message = CheckCasher(SelectedQuanity, QuanityInStock);

            if (message != "")
            {
                DisplayAlert("Внимание", message, "Ок");
            }
            else
            {
                TotalAmount = Convert.ToInt32(EntryQuanity.Text) * Convert.ToInt32(PriceForOne);
                LabelAmount.Text = Convert.ToString(TotalAmount);
                Navigation.PushAsync(new PagePlacingAnOrderCake(Id, PriceForOne, QuanityInStock, SelectedQuanity, TotalAmount));
            }
        }
    }
}