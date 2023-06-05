using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnlineCookery
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagePlacingAnOrderCake : ContentPage
    {
        int Id;
        int PriceForOne;
        int QuanityInStock;
        int SelectedQuanity;
        int TotalAmount;

        public PagePlacingAnOrderCake(int idcake, int priceforone, int quanityinstock, int selectedquanity, int totalamount)
        {
            InitializeComponent();

            Id = idcake;
            PriceForOne = priceforone;
            QuanityInStock = quanityinstock;
            SelectedQuanity = selectedquanity;
            TotalAmount = totalamount;

            LabelQuanityInStock.Text = QuanityInStock.ToString();
            EntrySelectedQuanity.Text = SelectedQuanity.ToString();
            LabelTotalAmount.Text = TotalAmount.ToString();
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

        static void Casher(int TotalAmount, int SelectedQuanity, int PriceForOne, bool FourtyPrecent, bool TwentyPrecent, bool TenPrecent, Label LabelTotalAmount)
        {
            TotalAmount = SelectedQuanity * PriceForOne;

            int precent = 0;

            if (FourtyPrecent == true)
            {
                precent += 40;
            }
            if (TwentyPrecent == true)
            {
                precent += 20;
            }
            if (TenPrecent == true)
            {
                precent += 10;
            }

            if (precent > 0)
            {
                int OneProcent = TotalAmount / 100;
                int temp = OneProcent * precent;
                TotalAmount = TotalAmount + temp;
            }

            LabelTotalAmount.Text = Convert.ToString(TotalAmount);
        }

        private void ButtonClickedCaclulate(object sender, EventArgs e)
        {
            string message = "";
            SelectedQuanity = Convert.ToInt32(EntrySelectedQuanity.Text);

            message = CheckCasher(SelectedQuanity, QuanityInStock);

            if (message != "")
            {
                DisplayAlert("Внимание", message, "Ок");
            }
            else
            {
                Casher(TotalAmount, Convert.ToInt32(EntrySelectedQuanity.Text), PriceForOne, FourtyPrecent.IsChecked, TwentyPrecent.IsChecked, TenPrecent.IsChecked, LabelTotalAmount);
            }
        }

        private void ButtonClickedBuy(object sender, EventArgs e)
        {
            string message = "";
            SelectedQuanity = Convert.ToInt32(EntrySelectedQuanity.Text);

            message = CheckCasher(SelectedQuanity, QuanityInStock);

            if (message != "")
            {
                DisplayAlert("Внимание", message, "Ок");
            }
            else
            {
                DisplayAlert("Сообщение", "Спасибо за покупку!", "Ок");
                Casher(TotalAmount, Convert.ToInt32(EntrySelectedQuanity.Text), PriceForOne, FourtyPrecent.IsChecked, TwentyPrecent.IsChecked, TenPrecent.IsChecked, LabelTotalAmount);
                QuanityInStock = QuanityInStock - Convert.ToInt32(EntrySelectedQuanity.Text);
                Navigation.PushAsync(new PageChoiceCake(Id, QuanityInStock));
            }
        }
    }
}