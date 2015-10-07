using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace BrokenShoeLeague.Domain
{
    public static class Utils
    {
        public static double CalculatePerformance(int jj, int jg, int jp, int je, int assists, int goals, int ag, int jjp  = 0)
        {
            if (jj <= 0)
                return 0;
            const double wGoals = 0.5;
            const double wAssists = 0.25;
            const double wWin = 0.2;
            const double wDraw = 1 / 15.0;
            const double wLost = 0.1;
            return Math.Round((wWin * jg + wDraw * je - wLost * jp + wGoals * goals + wAssists * assists) / jj, 3);
            //return Math.Round((wGoals * goals + wAssists * assists + w3 * jg + w4 * je) / (jj + w5 * jp), 3);
        }

        public static double CalculatePerformance(Player player)
        {
            return CalculatePerformance(player.PlayerRecords);
        }

        public static double CalculatePerformance(PlayerRecord pRecord)
        {
            return CalculatePerformance(pRecord.PlayedGames,pRecord.Wins,pRecord.Losts,pRecord.Draws,pRecord.Assists,pRecord.Goals,pRecord.AllowedGoals);
        }

        public static double CalculatePerformance(IEnumerable<PlayerRecord> stats)
        {
            int jj = 0, jg = 0, je = 0, jp = 0, assists = 0, goals = 0, ag = 0;
            foreach (var stat in stats)
            {
                jj += stat.PlayedGames;
                jg += stat.Wins;
                jp += stat.Losts;
                je += stat.Draws;
                assists += stat.Assists;
                goals += stat.Goals;
                ag += stat.AllowedGoals;
            }

            return CalculatePerformance(jj, jg, jp, je, assists, goals, ag);
        }

        public static double CalculatePerformanceAverage(Player player)
        {
            var ave = player.PlayerRecords.Any()
                ? player.PlayerRecords.Average(
                    stat => CalculatePerformance(stat.PlayedGames, stat.Wins, stat.Losts, stat.Draws, stat.Assists, stat.Goals, stat.AllowedGoals))
                : 0;

            return Math.Round(ave, 3);
        }

        public static void SendMailToUsers(string text, List<string> emailList)
        {
            const string from = "ltr.sportcity.contact@gmail.com";
            var msg = new MailMessage
            {
                From = new MailAddress(from),
                Subject = "Notification",
                Body = BuildBodyText(text),
                IsBodyHtml = true
            };

            foreach (var email in emailList)
                msg.To.Add(email);

            ServicePointManager.ServerCertificateValidationCallback = (s, certificate, chain, sslPolicyErrors) => true;
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new NetworkCredential(from, "ltrHalaMadrid"),
                EnableSsl = true
            };

            smtp.Send(msg);
        }

        private static string BuildBodyText(string message)
        {
            return String.Format(
                //"Hola, este mensaje es enviado desde http://ligadeltenisroto.somee.com debido a que su correo esta en la lista de notificaciones.\n {0}",message);
                "{0}",message);
        }
    }
}