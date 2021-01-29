namespace Spooky.Ui
{
    public static class UiStateExtentions
    {        
        public static void Enable(this UiStateSO uiState)
        {
            uiState.Set(true);
        }

        public static void Disable(this UiStateSO uiState)
        {
            uiState.Set(false);
        }

        public static void Set(this UiStateSO uiState, bool enable)
        {
            UiStateController.Instance.SetState(uiState, enable);
        }
    }
}