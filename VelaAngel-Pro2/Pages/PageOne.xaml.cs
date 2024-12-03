using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace VelaAngel_Pro2.Pages
{
    public partial class PageOne : ContentPage
    {
        private string filePath;

        public PageOne()
        {
            InitializeComponent();
            // Generar la ruta del archivo basada en el nombre del estudiante
            string studentName = "VelaAngel";
            filePath = Path.Combine(FileSystem.AppDataDirectory, $"{studentName}.txt");

            // Cargar todas las recargas si existen
            LoadAllRecharges();
        }

        private void LoadAllRecharges()
        {
            // Verificar si el archivo existe
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    // Cada recarga se muestra como una línea en el StackLayout
                    vcRecargasStack.Children.Add(new Label { Text = line, FontSize = 14 });
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

            // Crear el texto de la recarga
            string rechargeRecord = $"Nombre: {name}, \n" +
                $"Número: {phoneNumber}";

            // Agregar la recarga al archivo
            File.AppendAllLines(filePath, new[] { rechargeRecord });

            // Mostrar mensaje de éxito
            await DisplayAlert("Éxito", "La recarga fue realizada con éxito.", "OK");

            // Mostrar la nueva recarga en la interfaz
            vcRecargasStack.Children.Add(new Label { Text = rechargeRecord, FontSize = 14 });

            // Limpiar los campos de entrada
            vcEntryPhone.Text = string.Empty;
            vcEntryName.Text = string.Empty;
        }
    }
}
