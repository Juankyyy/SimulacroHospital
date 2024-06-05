using System.Text;
using System.Text.Json;
using SimulacroHospital.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace SimulacroHospital.AddControllers
{
    public class MailController
    {
        public async void EnviarCorreo(string email, string paciente, string medico, string especialidad, DateOnly fecha)
        {
            try
            {
                string url = "https://api.mailersend.com/v1/email";

                string jwtToken = "mlsn.7c087bff0e96037eee4c0c54f883daa8b92bf308730ca6282a78df85504c5edf";

                var EmailMessage = new Email
                {
                    from = new From { email = "MS_XPsRZo@trial-yzkq340ooe34d796.mlsender.net" },
                    to = [
                        new To { email = email }
                    ],
                    subject = "Cita Médica",
                    text = $"Hola, {paciente} tu cita ha sido agendada con el médico {medico} especialista en {especialidad} en la fecha {fecha}",
                };

                string jsonBody = JsonSerializer.Serialize(EmailMessage);

                using(HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwtToken}");

                    StringContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Respuesta del servidor:");
                        Console.WriteLine(responseBody);
                        Console.WriteLine($"Se mandó correctamente el correo a {email} con el asunto: {EmailMessage.text}");
                    } else
                    {
                        Console.WriteLine($"La solicitud falló: {response.StatusCode}");
                        Console.WriteLine(response);
                    }
                }
            } catch
            {
                
            }
        }
    }
}
