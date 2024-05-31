using System.Text;
using System.Text.Json;
using SimulacroHospital.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace SimulacroHospital.AddControllers
{
    public class MailController
    {
        public async void EnviarCorreo()
        {
            try
            {
                string url = "https://api.mailersend.com/v1/email";

                string jwtToken = "mlsn.ef00247ed1fe020a372413c12e9cd053354dadad66892799d0ad833f7a4f8e9f";

                var EmailMessage = new Email
                {
                    from = new From { email = "trial-yzkq340ooe34d796.mlsender.net" },
                    to = new[]
                    {
                        new To { email = "juancamiloherrera960@gmail.com" }
                    },
                    subject = "Hola, este correo ha sido enviado con MailerSend",
                    text = "Hola, Tu cita ha sido agendada :)",
                    html = "Hola, Tu cita ha sido agendada :)"
                };

                string jsonBody = JsonSerializer.Serialize(EmailMessage);

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Content-Type", "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwtToken}");

                    StringContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Respuesta del servidor:");
                        Console.WriteLine(responseBody);
                    } else
                    {
                        Console.WriteLine($"La solicitud falló: {response.StatusCode}");
                    }
                }
            } catch
            {
                
            }
        }
    }
}
