using Juce.Cheats.Widgets;
using System;
using UnityEngine;

namespace Juce.Cheats.WidgetsInteractors
{
    public class ToggleWidgetInteractor : IWidgetInteractor
    {
        private readonly ToggleWidget toggleWidget;

        private readonly string actionName;
        private readonly Func<bool> getAction;
        private readonly Action<bool> setAction;

        private bool state;

        public GameObject Widget => toggleWidget.gameObject;

        public ToggleWidgetInteractor(
            ToggleWidget toggleWidget,
            string actionName,
            Func<bool> getAction,
            Action<bool> setAction
            )
        {
            this.toggleWidget = toggleWidget;
            this.actionName = actionName;
            this.getAction = getAction;
            this.setAction = setAction;
        }

        public void Subscribe()
        {
            toggleWidget.Text.text = actionName;
            toggleWidget.Button.onClick.AddListener(OnButtonPressed);
        }

        public void Unsubscribe()
        {
            toggleWidget.Button.onClick.RemoveListener(OnButtonPressed);
        }

        public void Refresh()
        {
            state = getAction.Invoke();

            RefreshToggleCheck();
        }

        private void OnButtonPressed()
        {
            state = !state;

            RefreshToggleCheck();

            setAction.Invoke(state);
        }

        private void RefreshToggleCheck()
        {
            toggleWidget.ToggleCheck.gameObject.SetActive(state);
        }
    }
}
