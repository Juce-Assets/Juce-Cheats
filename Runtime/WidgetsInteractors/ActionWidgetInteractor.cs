using Juce.Cheats.Widgets;
using System;
using UnityEngine;

namespace Juce.Cheats.WidgetsInteractors
{
    public class ActionWidgetInteractor : IWidgetInteractor
    {
        private readonly ActionWidget actionWidget;

        private readonly string actionName;
        private readonly Action action;

        public GameObject Widget => actionWidget.gameObject;

        public ActionWidgetInteractor(
            ActionWidget actionWidget,
            string actionName,
            Action action
            )
        {
            this.actionWidget = actionWidget;
            this.actionName = actionName;
            this.action = action;
        }

        public void Subscribe()
        {
            actionWidget.Text.text = actionName;
            actionWidget.Button.onClick.AddListener(OnButtonPressed);
        }

        public void Unsubscribe()
        {
            actionWidget.Button.onClick.RemoveListener(OnButtonPressed);
        }

        private void OnButtonPressed()
        {
            action?.Invoke();
        }
    }
}
