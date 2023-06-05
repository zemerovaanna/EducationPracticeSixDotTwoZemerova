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
    public partial class PageChoiceCake : ContentPage
    {
        Xamarin.Forms.ListView ListViewCakes;
        Xamarin.Forms.Label HeaderInformation;
        Xamarin.Forms.Entry EntryIdCake;

        int IdCake; //Индекс торта.
        int ChangesQuantity; //Изменённое количество.

        ClassCake DefaultCake;
        ClassCake CakeWithInscriptions;
        ClassCake CreamyCake;
        ClassCake CakeWithMastik;

        class Cake
        {
            public int Id { get; set; }
            public string Image { get; set; }
            public string Name { get; set; }
            public double Cost { get; set; }
        }

        public PageChoiceCake(int IdChoiceCake, int RemainingQuantity)
        {
            InitializeComponent();

            IdCake = IdChoiceCake;
            ChangesQuantity = RemainingQuantity;

            DefaultCake = new ClassCake();
            CakeWithInscriptions = new ClassCake();
            CreamyCake = new ClassCake();
            CakeWithMastik = new ClassCake();


            switch (IdCake)
            {


                case 0:
                    {
                        DefaultCake.Quantity = ChangesQuantity;
                        break;
                    }


                case 1:
                    {
                        CakeWithInscriptions.Quantity = ChangesQuantity;
                        break;
                    }


                case 2:
                    {
                        CreamyCake.Quantity = ChangesQuantity;
                        break;
                    }


                case 3:
                    {
                        CakeWithMastik.Quantity = ChangesQuantity;
                        break;
                    }


                default: break;
            }


            HeaderInformation = new Label
            {
                Text = "Онлайн Кулинария (заказ и покупка тортов).",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                TextColor = Color.LightBlue
            };

            ListViewCakes = new ListView();
            ListViewCakes.ItemsSource = new List<Cake>
        {
            new Cake {Id = 0, Image = "Cake.jpg", Name = "Торт Обычный.", Cost = 50},
            new Cake {Id = 1, Image = "Ten.jpg", Name = "Торт с надписями.", Cost = 75},
            new Cake {Id = 2, Image = "Twenty.jpg", Name = "Торт - Много крема.", Cost = 100},
            new Cake {Id = 3, Image = "Fourty.jpg", Name = "Торт со сложными фигурами из мастики.", Cost = 125},
        };
            ListViewCakes.ItemTemplate = new DataTemplate(() =>
            {
                ImageCell imageCell = new ImageCell
                {
                    TextColor = Color.LightYellow,
                    DetailColor = Color.White,
                };
                imageCell.SetBinding(ImageCell.TextProperty, "Name");
                imageCell.SetBinding(ImageCell.DetailProperty, "Id");
                imageCell.SetBinding(ImageCell.ImageSourceProperty, "Image");
                return imageCell;
            });

            Label NowDate = new Label
            {
                Text = $"{DateTime.Today.Year}-{DateTime.Today.Month}-{DateTime.Today.Day}",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                TextColor = Color.White
            };

            Label InformationForEntry = new Label
            {
                Text = "Введите индекс торта:",
                TextColor = Color.White
            };

            EntryIdCake = new Entry
            {

            };

            Xamarin.Forms.Button ButtonInformationCake = new Xamarin.Forms.Button()
            {
                Text = "Просмотр информации о торте",
            };
            ButtonInformationCake.Clicked += OnButtonClickedInformationCake;

            Xamarin.Forms.Button ButtonCalculatorPrice = new Xamarin.Forms.Button()
            {
                Text = "Расчёт стоимости торта",
            };
            ButtonCalculatorPrice.Clicked += OnButtonClicked1CalculatorPrice;

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children =
                {
                    HeaderInformation,

                    new StackLayout
                    {
                         HorizontalOptions = LayoutOptions.CenterAndExpand,
                         Children = { NowDate, ListViewCakes}
                    },
                    InformationForEntry,
                    EntryIdCake,
                    ButtonInformationCake,
                    ButtonCalculatorPrice
                }
            };
        }

        static string CheckId(string id)
        {
            string message = "";

            foreach (char symbol in id)
            {
                if (!char.IsDigit(symbol))
                {
                    message = "В поле для ввода индекса могут быть только цифры.";
                    break;
                }
            }

            return message;
        }

        private void OnButtonClickedInformationCake(object sender, EventArgs e)
        {
            string IdCakeInEntry = EntryIdCake.Text;
            if (!string.IsNullOrEmpty(IdCakeInEntry))
            {
                string message = "";
                message = CheckId(IdCakeInEntry);

                if (message == "")
                {
                    switch (Convert.ToInt32(IdCakeInEntry))
                    {


                        case 0:
                            {
                                DefaultCake.Id = 0;
                                DefaultCake.Name = "Обычный торт";
                                DefaultCake.Category = "Фруктовый";
                                DefaultCake.Cost = 50;
                                DefaultCake.Unit = "2";
                                DefaultCake.Fats = 1;
                                DefaultCake.Protein = 5;
                                DefaultCake.Carbohydrates = 2;
                                DefaultCake.Vitamins = "B2, B3";
                                DefaultCake.Caterer = "г. Екатеринбург";
                                DefaultCake.Quantity = ChangesQuantity;
                                DefaultCake.Recipe = "сахар, куриные яйца, мука, разрыхлитель, молоко";

                                Navigation.PushAsync(new PageCakeInformation(Convert.ToInt32(IdCakeInEntry), DefaultCake.Name, DefaultCake.Category, DefaultCake.Cost, DefaultCake.Unit, DefaultCake.Fats, DefaultCake.Protein, DefaultCake.Carbohydrates, DefaultCake.Vitamins, DefaultCake.Caterer, DefaultCake.Quantity, DefaultCake.Recipe));

                                break;
                            }


                        case 1:
                            {
                                CakeWithInscriptions.Id = 1;
                                CakeWithInscriptions.Name = "Торт с надписями";
                                CakeWithInscriptions.Category = "Шоколадный";
                                CakeWithInscriptions.Cost = 75;
                                CakeWithInscriptions.Unit = "10";
                                CakeWithInscriptions.Fats = 50;
                                CakeWithInscriptions.Protein = 100;
                                CakeWithInscriptions.Carbohydrates = 12;
                                CakeWithInscriptions.Vitamins = "A,B2,PP,E";
                                CakeWithInscriptions.Caterer = "г. Екатеринбург";
                                CakeWithInscriptions.Quantity = ChangesQuantity;
                                CakeWithInscriptions.Recipe = "сахар, куриные яйца, мука, разрыхлитель, шоколадное лицо, чёрный шоколад.";

                                Navigation.PushAsync(new PageCakeInformation(Convert.ToInt32(IdCakeInEntry), CakeWithInscriptions.Name, CakeWithInscriptions.Category, CakeWithInscriptions.Cost, CakeWithInscriptions.Unit, CakeWithInscriptions.Fats, CakeWithInscriptions.Protein, CakeWithInscriptions.Carbohydrates, CakeWithInscriptions.Vitamins, CakeWithInscriptions.Caterer, CakeWithInscriptions.Quantity, CakeWithInscriptions.Recipe));

                                break;
                            }


                        case 2:
                            {
                                CreamyCake.Id = 2;
                                CreamyCake.Name = "Торт - Много крема";
                                CreamyCake.Category = "Песочный";
                                CreamyCake.Cost = 100;
                                CreamyCake.Unit = "51";
                                CreamyCake.Fats = 120;
                                CreamyCake.Protein = 80;
                                CreamyCake.Carbohydrates = 70;
                                CreamyCake.Vitamins = "A, B-bar";
                                CreamyCake.Caterer = "г. Екатеринбург";
                                CreamyCake.Quantity = ChangesQuantity;
                                CreamyCake.Recipe = "малина, сахар, куриные яйца, мука, разрыхлитель, молоко";

                                Navigation.PushAsync(new PageCakeInformation(Convert.ToInt32(IdCakeInEntry), CreamyCake.Name, CreamyCake.Category, CreamyCake.Cost, CreamyCake.Unit, CreamyCake.Fats, CreamyCake.Protein, CreamyCake.Carbohydrates, CreamyCake.Vitamins, CreamyCake.Caterer, CreamyCake.Quantity, CreamyCake.Recipe));

                                break;
                            }


                        case 3:
                            {
                                CakeWithMastik.Id = 3;
                                CakeWithMastik.Name = "Торт с мастикой";
                                CakeWithMastik.Category = "Йогуртовый";
                                CakeWithMastik.Cost = 125;
                                CakeWithMastik.Unit = "2";
                                CakeWithMastik.Fats = 5;
                                CakeWithMastik.Protein = 1;
                                CakeWithMastik.Carbohydrates = 3;
                                CakeWithMastik.Vitamins = "A, PP";
                                CakeWithMastik.Caterer = "г. Екатеринбург";
                                CakeWithMastik.Quantity = ChangesQuantity;
                                CakeWithMastik.Recipe = "сахар, куриные яйца, мука, разрыхлитель, молоко, ваниль";

                                Navigation.PushAsync(new PageCakeInformation(Convert.ToInt32(IdCakeInEntry), CakeWithMastik.Name, CakeWithMastik.Category, CakeWithMastik.Cost, CakeWithMastik.Unit, CakeWithMastik.Fats, CakeWithMastik.Protein, CakeWithMastik.Carbohydrates, CakeWithMastik.Vitamins, CakeWithMastik.Caterer, CakeWithMastik.Quantity, CakeWithMastik.Recipe));

                                break;
                            }


                        default: DisplayAlert("Внимание", "Технические неполадки.", "Ок"); break;
                    }
                }
                else
                {
                    DisplayAlert("Внимание", message, "Ок");
                }
            }
            else
            {
                DisplayAlert("Внимание", "Поле для ввода индекса не заполнено.", "Ок");
            }
        }

        private void OnButtonClicked1CalculatorPrice(object sender, EventArgs e)
        {
            string IdCakeInEntry = EntryIdCake.Text;
            if (!string.IsNullOrEmpty(IdCakeInEntry))
            {
                string message = "";
                message = CheckId(IdCakeInEntry);

                if (message == "")
                {
                    switch (Convert.ToInt32(IdCakeInEntry))
                    {


                        case 0:
                            {
                                DefaultCake.Id = 0;
                                DefaultCake.Cost = 50;
                                DefaultCake.Quantity = ChangesQuantity;

                                Navigation.PushAsync(new PagePlacingAnOrderCake(Convert.ToInt32(IdCakeInEntry), DefaultCake.Cost, DefaultCake.Quantity, 1, 0));

                                break;
                            }


                        case 1:
                            {
                                CakeWithInscriptions.Id = 1;
                                CakeWithInscriptions.Cost = 75;
                                CakeWithInscriptions.Quantity = ChangesQuantity;

                                Navigation.PushAsync(new PagePlacingAnOrderCake(Convert.ToInt32(IdCakeInEntry), CakeWithInscriptions.Cost, CakeWithInscriptions.Quantity, 1, 0));

                                break;
                            }


                        case 2:
                            {
                                CreamyCake.Id = 2;
                                CreamyCake.Cost = 100;
                                CreamyCake.Quantity = ChangesQuantity;

                                Navigation.PushAsync(new PagePlacingAnOrderCake(Convert.ToInt32(IdCakeInEntry), CreamyCake.Cost, CreamyCake.Quantity, 1, 0));

                                break;
                            }


                        case 3:
                            {
                                CakeWithMastik.Id = 3;
                                CakeWithMastik.Quantity = ChangesQuantity;

                                Navigation.PushAsync(new PagePlacingAnOrderCake(Convert.ToInt32(IdCakeInEntry), CakeWithMastik.Cost, CakeWithMastik.Quantity, 1, 0));

                                break;
                            }


                        default: DisplayAlert("Внимание", "Технические неполадки.", "Ок"); break;
                    }
                }
                else
                {
                    DisplayAlert("Внимание", message, "Ок");
                }
            }
            else
            {
                DisplayAlert("Внимание", "Поле для ввода индекса не заполнено.", "Ок");
            }
        }
    }
}