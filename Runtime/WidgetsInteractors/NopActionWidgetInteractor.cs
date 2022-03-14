using UnityEngine;

namespace Juce.Cheats.WidgetsInteractors
{
    public class NopActionWidgetInteractor : IWidgetInteractor
    {
        public static readonly NopActionWidgetInteractor Instance = new NopActionWidgetInteractor();

        public GameObject Widget => null;

        private NopActionWidgetInteractor()
        {

        }

        public void Subscribe()
        {
           
        }

        public void Unsubscribe()
        {
           
        }
    }
}
