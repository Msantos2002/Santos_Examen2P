using System;
using Microsoft.Maui.Controls;
namespace Santos_Examen2P
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void OnCounterClicked(object sender, EventArgs e)
        {
            try
            {
                decimal euros = string.IsNullOrWhiteSpace(MS_Euros.Text) ? 0 : Convert.ToDecimal(MS_Euros.Text);
                decimal dolares = string.IsNullOrWhiteSpace(MS_Dolares.Text) ? 0 : Convert.ToDecimal(MS_Dolares.Text);
                decimal pesos = string.IsNullOrWhiteSpace(MS_Pesos.Text) ? 0 : Convert.ToDecimal(MS_Pesos.Text);

                const decimal EuroToDollar = 1.10m;
                const decimal DollarToEuro = 0.91m;
                const decimal PesoToDollar = 0.00025m;
                const decimal DollarToPeso = 4000m;
                if (euros > 0)
                {
                    MS_Dolares.Text = (euros * EuroToDollar).ToString("N2");
                    MS_Pesos.Text = (euros * EuroToDollar * DollarToPeso).ToString("N2");
                }
                else if (dolares > 0)
                {
                    MS_Euros.Text = (dolares * DollarToEuro).ToString("N2");
                    MS_Pesos.Text = (dolares * DollarToPeso).ToString("N2");
                }
                else if (pesos > 0)
                {
                    MS_Dolares.Text = (pesos * PesoToDollar).ToString("N2");
                    MS_Euros.Text = (pesos * PesoToDollar * DollarToEuro).ToString("N2");
                }
                else
                {
                    DisplayAlert("Advertencia", "Por favor, ingrese un valor para convertir.", "OK");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
            }
        }
        private void OnBorrarClicked(object sender, EventArgs e)
        {
            MS_Euros.Text = string.Empty;
            MS_Dolares.Text = string.Empty;
            MS_Pesos.Text = string.Empty;
        }
    }
}
