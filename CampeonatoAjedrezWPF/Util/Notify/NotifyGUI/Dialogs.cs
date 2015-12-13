using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notify.NotifyGUI
{
    public static class Dialogs
    {
        public static async void showMessage(string mensaje, string titulo, MetroWindow metro)
        {
            await metro.ShowMessageAsync(titulo, mensaje);
        }
        public static async Task<MessageDialogResult> showQuestionMessage(string mensaje, string titulo, MetroWindow metro)
        {
            return await metro.ShowMessageAsync(titulo, mensaje, style: MessageDialogStyle.AffirmativeAndNegative);
        }
        public static async Task<MessageDialogResult> showQuestionMessage(string mensaje, string titulo, MessageDialogStyle style, MetroWindow metro)
        {
            return await metro.ShowMessageAsync(titulo, mensaje, style: style);
        }
        public static async void showException(Exception ex, string tit, MetroWindow metro)
        {
            await metro.ShowExceptionAsync(tit, ex);
        }
        public static async Task<LoginDialogData> showLogin(MetroWindow metro, string titulo, string mensaje)
        {
            return await metro.ShowLoginAsync(titulo, mensaje, new LoginDialogSettings() { AffirmativeButtonText = "Iniciar", PasswordWatermark = "Contraseña", UsernameWatermark = "Usuario" }).ConfigureAwait(false);
        }
        public static async Task<ProgressDialogController> showProgress(string mensaje, string titulo, MetroWindow metro)
        {
            return await metro.ShowProgressAsync(titulo, mensaje);
        }

    }
}
