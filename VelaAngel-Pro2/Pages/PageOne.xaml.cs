using System;
using System.IO;

namespace VelaAngel_Pro2.Pages
{
    public partial class PageOne : ContentPage
    {
        private string filePath;

        public PageOne()
        {
            InitializeComponent();

            string studentName = "VelaAngel";

            filePath = Path.Combine(FileSystem.AppDataDirectory, $"{studentName}.txt");

            LoadLastRecharge();
        }

        private void LoadLastRecharge()
        {
            
            if (File.Exists(filePath))
            {
                var data = File.ReadAllLines(filePath);
                if (data.Length >= 2)
                {
                    vcLabelName.Text = $"Nombre: {data[0]}";
                    vcLabelNumber.Text = $"Número: {data[1]}";
                }
            }
        }

        private async void OnRecargarClicked(object sender, EventArgs e)
        {
            string phoneNumber = vcEntryPhone.Text;
            string name = vcEntryName.Text;

            if (string.IsNullOrWhiteSpace(phoneNumber) || string.IsNullOrWhiteSpace(name))
            {
                await DisplayAlert("Error", "Por favor, complete todos los campos.", "OK");
                return;
            }

            // Guardar solo la última recarga en el archivo
            File.WriteAllLines(filePath, new[] { name, phoneNumber });

            // Mostrar mensaje de éxito
            await DisplayAlert("Éxito", "La recarga fue realizada con éxito.", "OK");

            // Actualizar los datos en la UI
            vcLabelName.Text = $"Nombre: {name}";
            vcLabelNumber.Text = $"Número: {phoneNumber}";

            // Limpiar los campos de entrada
            vcEntryPhone.Text = string.Empty;
            vcEntryName.Text = string.Empty;
        }
    }
}
