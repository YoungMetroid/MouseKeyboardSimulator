using MouseKeyBoardSimulation.Models;
using MouseKeyBoardSimulation.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseKeyBoardSimulation
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var view = new MouseKeyBoardForm();
            var keyBoardService  = new KeyBoardService("");
            var mouseService = new MouseService();
            var serviceDictionary = new Dictionary<string, IMouseKeyboardService> { 
                { "keyBoardService",keyBoardService as IMouseKeyboardService}, 
                { "mouseService",mouseService as IMouseKeyboardService} 
            };
            var presenter = new MouseKeyBoardPresenter(view, serviceDictionary);
            Application.Run(view as Form);
        }
    }
}
