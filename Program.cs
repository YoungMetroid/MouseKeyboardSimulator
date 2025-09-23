using MouseKeyBoardSimulation.Domain;
using MouseKeyBoardSimulation.Models;
using MouseKeyBoardSimulation.Presenter;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Text.Json.Nodes;

namespace MouseKeyBoardSimulation
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            ConcurrentQueue<MouseKeyboardEvent> events = new();
            var view = new MouseKeyBoardForm();
            var keyBoardService = new KeyBoardService(events);
            var mouseService = new MouseService(events);
            var serviceDictionary = new Dictionary<string, IMouseKeyboardService> {
                { "keyBoardService",keyBoardService as IMouseKeyboardService},
                { "mouseService",mouseService as IMouseKeyboardService}
            };
          
            
            JsonArray jsonArray = new JsonArray();
           
            JsonObject jsonObject = new JsonObject();
            jsonObject.Add("MouseEvent", "test");
            jsonObject.Add("KeyStorkeEvent", "test2");
            jsonArray.Add(jsonObject);

            Debug.WriteLine("Debuging:  " + jsonArray);
            var presenter = new MouseKeyBoardPresenter(view, serviceDictionary);
            Application.Run(view as Form);
        }
    }
}